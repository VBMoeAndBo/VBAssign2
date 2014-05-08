Imports Newtonsoft.Json
Imports System.IO

Namespace BO
    Public Class Item
        Public ReadOnly Property ItemID As Integer
            Get
                Return _id
            End Get
        End Property
        Public Property Name As String
        '    Get
        '        Return _name
        '    End Get
        '    Set(value As String)
        '        If IsNothing(value) Or value = "" Then
        '            _valid = False
        '            Throw New ArgumentException("Item name cannot be empty")
        '        Else
        '            _name = value
        '        End If
        '    End Set
        'End Property
        Public Property Price As Double
        '    Get
        '        Return _price
        '    End Get
        '    Set(value As Double)
        '        If value >= 0 Then
        '            _price = value
        '        Else
        '            _valid = False
        '            Throw New ArgumentException("Price cannot be negative")
        '        End If
        '    End Set
        'End Property

        Public Property Quantity As Integer
        '    Get
        '        Return _quantity
        '    End Geta
        '    Set(value As Integer)
        '        If value >= 0 Then
        '            _quantity = value
        '        Else
        '            _valid = False
        '            Throw New ArgumentException("Quantity must be greater than or equal to 0")
        '        End If
        '    End Set
        'End Property

        Public Property Brand As String
        '    Get
        '        Return _brand
        '    End Get
        '    Set(value As String)
        '        If value = "" Then
        '            _valid = False
        '            Throw New ArgumentException("Brand is required")
        '        Else
        '            _brand = value
        '        End If
        '    End Set
        'End Property

        ReadOnly Property IsValid() As Boolean
            Get
                Return _valid
            End Get
        End Property

        Public Sub New(name As String, brand As String, price As Double, quantity As Integer)
            '_id = id
            _valid = True
            Me.Name = name
            Me.Price = price
            Me.Brand = brand
            Me.Quantity = quantity
        End Sub

        '<Newtonsoft.Json.JsonConstructor()>
        Public Sub New()
            ''_id = -1
            'Me.Name = "name"
            'Me.Price = 1.0
            'Me.Quantity = 1
            'Me.Brand = "brand"
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim i As Item = CType(obj, Item)
            Return Me.ItemID = i.ItemID And Me.Name = i.Name And Me.Price = i.Price
        End Function



        Dim _id As Integer
        'Dim _name As String
        'Dim _price As Double
        'Dim _quantity As Integer
        'Dim _brand As String
        Dim _valid As Boolean

    End Class

    Public Module ItemHelper
        '* deserialize given JSON file back to list of message objects
        Function DeserializeJSON(jsonFilename As String) As List(Of Item)

            Dim jsonString As String

            Using sr As New IO.StreamReader(jsonFilename)
                jsonString = sr.ReadToEnd()
            End Using

            Try
                Dim js = New JsonSerializerSettings

                js.Converters.Add(New ItemConverter)   '* handles message exceptions
                Dim meh = New MyJsonErrorHandler          '* reset exception flag in JsonConverter
                js.Error = AddressOf meh.Reset

                Return JsonConvert.DeserializeObject(Of List(Of Item))(jsonString, js)
            Catch
                Return Nothing
            End Try
        End Function

    End Module
    'Public Class MyJsonErrorHandler
    '    Public Sub Reset(sender As Object, args As Serialization.ErrorEventArgs)
    '        If args.CurrentObject Is args.ErrorContext.OriginalObject Then
    '            args.ErrorContext.Handled = True
    '        End If
    '    End Sub
    'End Class

End Namespace
