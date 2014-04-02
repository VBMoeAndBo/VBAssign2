
Namespace BO
    Public Class Order
        Public ReadOnly Property OrderID As Integer
            Get
                Return _id
            End Get
        End Property
        Public Property OrderItems As List(Of OrderItem)
            Get
                Return _orderItems
            End Get
            Set(value As List(Of OrderItem))
                If IsNothing(value) Then
                    Throw New InvalidOrderException("Order cannot contain no items")
                End If
                Dim flag As Boolean = False
                For Each oi In value
                    If oi.Paid Then
                        flag = True
                    End If
                Next
                If flag = False Then
                    Throw New InvalidOrderException("Order must have at least one paid item")
                Else
                    _orderItems = value
                End If

            End Set
        End Property



        Public Sub New(ByVal orderItems As List(Of OrderItem))
            Me._id = -1
            Me.OrderItems = orderItems
        End Sub

        Public Overrides Function GetHashCode() As Integer
            Dim hash = 1 'default hash
            If Not IsNothing(_orderItems) Then
                'overflow is ok
                For Each oi In _orderItems
                    If oi.ItemID Mod 2 = 1 Then
                        hash = hash * 2 + oi.GetHashCode()
                    Else
                        hash -= hash * 5 + oi.GetHashCode()
                    End If

                Next
            End If
            Return hash
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim i As Order = CType(obj, Order)
            Return i._id = Me._id And i.OrderItems.SequenceEqual(Me.OrderItems)
        End Function
#Region "Friend functions"
        Friend Sub SetID(ByVal id As Integer)
            _id = id
        End Sub
        <Newtonsoft.Json.JsonConstructor()>
        Public Sub New(ByVal OrderID As Integer, ByVal OrderItems As List(Of OrderItem))
            Me._id = OrderID
            Me.OrderItems = OrderItems
        End Sub
#End Region
        Dim _id As Integer
        Dim _orderItems As New List(Of OrderItem)
    End Class

    Public Class InvalidOrderException
        Inherits System.Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class


End Namespace