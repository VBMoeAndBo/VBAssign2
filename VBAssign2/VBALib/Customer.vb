Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports System.IO

Namespace BO
    Public Class Customer
        Public ReadOnly Property CustomerID As Integer
            Get
                Return _id
            End Get
        End Property
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                If value = "" Then
                    valid_ = False
                    Throw New ArgumentException("Name cannot be empty")
                Else
                    _name = value
                End If

            End Set
        End Property
        Public Property Email As String
            Get
                Return _email
            End Get
            Set(value As String)
                If Not Regex.IsMatch(value, "[a-zA-Z0-9]+@myseneca\.ca$") And Not Regex.IsMatch(value, "[a-zA-Z0-9]+\.[a-zA-Z0-9]+@senecacollege\.ca$") Then
                    valid_ = False
                    Throw New ArgumentException("Email address is invalid, must be of format 'xxx@myseneca.ca' or 'xxx.xxx@senecacollege.ca'")
                Else
                    _email = value
                End If

            End Set
        End Property

        Public Property Phone As String
            Get
                Return _phone
            End Get
            Set(value As String)
                _phone = value
            End Set
        End Property
        Public Property Orders As List(Of Order)
            Get
                Return _orders
            End Get
            Set(value As List(Of Order))
                If value IsNot Nothing Then
                    For Each o In value
                        If o.OrderID = -1 Then
                            _lastOrderID += 1
                            o.SetID(_lastOrderID)
                        End If
                    Next
                    _orders = value
                Else

                    _orders = New List(Of Order)
                End If

            End Set
        End Property
        ReadOnly Property IsValid() As Boolean
            Get
                Return valid_
            End Get
        End Property


        Dim _lastOrderID As Integer
        Dim _email As String
        Dim _name As String
        Dim _phone As String
        Dim _id As Integer
        Dim _orders As List(Of Order)
        Dim valid_ As Boolean


        Public Sub New()
            '_id = -1
            'Me.Name = "new"
            'Me.Email = "default@myseneca.ca"
            'Dim ordL As List(Of Order) = Nothing
            'Me.Orders = ordL
            'Me.Phone = ""
            'valid_ = True
        End Sub

        'Public Sub New(n As String, e As String)
        '    Name = n
        '    Email = e
        'End Sub

        Public Sub New(name As String, email As String, Optional ByVal id As Integer = -1, Optional ByVal phone As String = "", Optional ByVal orders As List(Of Order) = Nothing)
            _id = id
            Me.Name = name
            Me.Email = email
            Me.Orders = orders
            Me.Phone = phone
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim c As Customer = CType(obj, Customer)
            Return Me.CustomerID = c.CustomerID And Me.Name = c.Name And Me.Email.SequenceEqual(c.Email) And Me.Orders.SequenceEqual(c.Orders)
        End Function

#Region "Friend functions"
        Friend Sub SetID(ByVal id As Integer)
            _id = id
        End Sub
        <Newtonsoft.Json.JsonConstructor()>
        Friend Sub New(ByVal CustomerID As Integer, ByVal Name As String, ByVal Email As String, ByVal OrderList As List(Of Order))
            _id = CustomerID
            Me.Name = Name
            Me.Email = Email
            Me.Orders = OrderList
        End Sub
#End Region

    End Class

    Public Module CustomerHelper
        '* deserialize given JSON file back to list of message objects
        Function DeserializeJSON(jsonFilename As String) As List(Of Customer)

            Dim jsonString As String
            Dim Hello As String

            Using sr As New IO.StreamReader(jsonFilename)
                jsonString = sr.ReadToEnd()
                Hello = ""
            End Using

            Try
                Dim js = New JsonSerializerSettings

                js.Converters.Add(New CustomerConverter)   '* handles message exceptions
                Dim meh = New MyJsonErrorHandler          '* reset exception flag in JsonConverter
                js.Error = AddressOf meh.Reset

                Return JsonConvert.DeserializeObject(Of List(Of Customer))(jsonString, js)
            Catch
                Return Nothing
            End Try
        End Function

    End Module
    Public Class MyJsonErrorHandler
        Public Sub Reset(sender As Object, args As Serialization.ErrorEventArgs)
            If args.CurrentObject Is args.ErrorContext.OriginalObject Then
                args.ErrorContext.Handled = True
            End If
        End Sub
    End Class
End Namespace
