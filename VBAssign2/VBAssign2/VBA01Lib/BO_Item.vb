Namespace BO
    Public Class Item
        Public ReadOnly Property ItemID As Integer
            Get
                Return _id
            End Get
        End Property
        Public Property ItemName As String
            Get
                Return _name
            End Get
            Set(value As String)
                If IsNothing(value) Or value = "" Then
                    Throw New InvalidItemException("Item name cannot be empty")
                Else
                    _name = value
                End If
            End Set
        End Property
        Public Property ItemPrice As Double
            Get
                Return _price
            End Get
            Set(value As Double)
                If value >= 0 Then
                    _price = value
                Else
                    Throw New InvalidItemException("Price cannot be negative")
                End If
            End Set
        End Property

        

        Public Sub New(ByVal name As String, ByVal price As Double)
            _id = -1
            Me.ItemName = name
            Me.ItemPrice = price
        End Sub
        <Newtonsoft.Json.JsonConstructor()>
        Public Sub New(ByVal ItemID As Integer, ByVal ItemName As String, ByVal ItemPrice As Double)
            _id = ItemID
            Me.ItemName = ItemName
            Me.ItemPrice = ItemPrice
        End Sub


        Public Overrides Function GetHashCode() As Integer
            Dim hash = 1 'default hash
            If (Not IsNothing(_id)) Or (Not IsNothing(_name)) Or (Not IsNothing(_price)) Then
                'overflow is ok
                hash = hash * 2 + Me._id.GetHashCode()
                hash -= hash * 5 + Me._name.GetHashCode()
                hash = hash * 2 + Me._price.GetHashCode()
            End If
            Return hash
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim i As Item = CType(obj, Item)
            Return Me.ItemID = i.ItemID And Me.ItemName = i.ItemName And Me.ItemPrice = i.ItemPrice
        End Function



        Dim _id As Integer
        Dim _name As String
        Dim _price As Double
    End Class
    Public Class InvalidItemException
        Inherits System.Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class


End Namespace
