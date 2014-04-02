Imports System.Text.RegularExpressions
Imports VBA01Lib.BL

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
                    Throw New InvalidCustomerException("Name cannot be empty")
                Else
                    _name = value
                End If

            End Set
        End Property
        Public Property Email As List(Of String)
            Get
                Return _email
            End Get
            Set(value As List(Of String))
                Dim flag1 As Boolean = True
                Dim flag2 As Boolean = True
                If IsNothing(value) Or value.Count = 0 Then
                    Throw New InvalidCustomerException("Email cannot be empty")
                End If

                If Not Regex.IsMatch(value.Item(0), "[a-zA-Z0-9]+@myseneca\.ca$") And Not Regex.IsMatch(value.Item(0), "[a-zA-Z0-9]+\.[a-zA-Z0-9]+@senecacollege\.ca$") Then
                    flag1 = False
                End If
                If value.Count = 2 Then
                    If Not Regex.IsMatch(value.Item(1), "[a-zA-Z0-9]+@myseneca\.ca$") And Not Regex.IsMatch(value.Item(1), "[a-zA-Z0-9]+\.[a-zA-Z0-9]+@senecacollege\.ca$") And value.Item(1).Trim.Length > 0 Then
                        flag2 = False
                    End If
                End If

                If flag1 = False Or flag2 = False Then
                    Throw New InvalidCustomerException("One or more email addresses are invalid")
                Else
                    _email = value
                End If

            End Set
        End Property
        Public Property OrderList As List(Of Order)
            Get
                Return _orderList
            End Get
            Set(value As List(Of Order))
                If value IsNot Nothing Then
                    For Each o In value
                        If o.OrderID = -1 Then
                            _lastOrderID += 1
                            o.SetID(_lastOrderID)
                        End If
                    Next
                    _orderList = value
                Else

                    _orderList = New List(Of Order)
                End If

            End Set
        End Property

        Dim _lastOrderID As Integer
        Dim _email As List(Of String)
        Dim _name As String
        Dim _id As Integer
        Dim _orderList As List(Of Order)


        Public Sub New()
            _id = -1
            Me.Name = "new"
            Me.Email = New List(Of String) From {"default@myseneca.ca", ""}
            Dim ordL As List(Of Order) = Nothing
            Me.OrderList = ordL
        End Sub

        Public Sub New(ByVal name As String, ByVal email As List(Of String), Optional ByVal orders As List(Of Order) = Nothing)
            _id = -1
            Me._lastOrderID = 0
            Me.Name = name
            Me.Email = email
            Me.OrderList = orders

        End Sub
        Public Overrides Function GetHashCode() As Integer
            Dim hash = 17 'default hash
            If (Not IsNothing(_id)) Or (Not IsNothing(_email)) Or (Not IsNothing(_email)) Then
                'overflow is ok
                hash = hash * 23 + Me._id.GetHashCode()
                hash = hash * 23 + Me._name.GetHashCode()
                For Each e In _email
                    hash = hash * 23 + e.GetHashCode()
                Next
                For Each o In _orderList
                    hash = hash * 23 + o.GetHashCode()
                Next
            End If
            Return hash
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim c As Customer = CType(obj, Customer)
            Return Me.CustomerID = c.CustomerID And Me.Name = c.Name And Me.Email.SequenceEqual(c.Email) And Me.OrderList.SequenceEqual(c.OrderList)
        End Function
#Region "Friend functions"
        Friend Sub SetID(ByVal id As Integer)
            _id = id
        End Sub
        <Newtonsoft.Json.JsonConstructor()>
        Friend Sub New(ByVal CustomerID As Integer, ByVal Name As String, ByVal Email As List(Of String), ByVal OrderList As List(Of Order))
            _id = CustomerID
            Me.Name = Name
            Me.Email = Email
            Me.OrderList = OrderList
        End Sub
#End Region

    End Class

    Public Class InvalidCustomerException
        Inherits System.Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class

End Namespace
