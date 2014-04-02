Namespace BO
    Public Class OrderItem
        Inherits Item

        Public Property Paid As Boolean
            Get
                Return _paid
            End Get
            Set(value As Boolean)

                _paid = value

            End Set
        End Property

        Public Property Quantity As Integer
            Get
                Return _quantity
            End Get
            Set(value As Integer)
                If IsNothing(value) Or value = 0 Then
                    Throw New InvalidOrderItemException("Null or zero quantity")
                Else
                    _quantity = value
                End If
            End Set
        End Property

        Public Sub New(ByVal Item As Item, ByVal paid As Boolean, ByVal quantity As Integer)
            MyBase.New(Item.ItemID, Item.ItemName, Item.ItemPrice)
            If Item.ItemID = -1 Then
                Throw New InvalidOrderItemException("Unsaved item detected. Save your item before creating an OrderItem")
            End If
            Me.Paid = paid
            Me.Quantity = quantity
        End Sub
        <Newtonsoft.Json.JsonConstructor()>
        Public Sub New(ByVal paid As Boolean, ByVal quantity As Integer, ByVal ItemID As Integer, ByVal ItemName As String, ByVal ItemPrice As Double)
            MyBase.New(ItemID, ItemName, ItemPrice)
            If ItemID = -1 Then
                Throw New InvalidOrderItemException("Unsaved item detected. Save your item before creating an OrderItem")
            End If
            _paid = paid
            _quantity = quantity
        End Sub
        Public Overrides Function GetHashCode() As Integer
            Dim hash = 0
            If Not IsNothing(_paid) Then
                'overflow is ok
                hash = hash * 2 + MyBase.GetHashCode()
                hash -= hash * 5 + _paid.GetHashCode()
                hash = hash * 2 + _quantity.GetHashCode()
            End If
            Return hash
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim i As OrderItem = CType(obj, OrderItem)
            Return Me.Paid = i.Paid And Me.Quantity = i.Quantity And Me.ItemID = i.ItemID And Me.ItemName = i.ItemName And Me.ItemPrice = i.ItemPrice
        End Function
        Dim _quantity As Integer
        Dim _paid As Boolean
    End Class

    Public Class InvalidOrderItemException
        Inherits System.Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class

End Namespace
