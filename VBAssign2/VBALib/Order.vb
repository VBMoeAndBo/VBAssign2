
Namespace BO
    Public Class Order
        Public ReadOnly Property OrderID As Integer
            Get
                Return _id
            End Get
        End Property
        Public Property Items As List(Of Item)
            Get
                Return _items
            End Get
            Set(value As List(Of Item))
                If IsNothing(value) Then
                    Throw New ArgumentException("Order cannot contain no items")
                Else
                    _items = value
                End If

            End Set
        End Property
        Public Property ordDate As Date
            Get
                Return _ordDate
            End Get
            Set(value As Date)
                If IsNothing(value) Then
                    Throw New ArgumentException("Order Date is required")
                Else
                    _ordDate = value
                End If
            End Set
        End Property

        Public Sub New()
            ''_id = -1
            '_ordDate = New Date
            '_items = Nothing
        End Sub
        Public Sub New(orderItems As List(Of Item), Optional orderDate As Date = Nothing)
            '_id = -1
            ordDate = orderDate
            If IsNothing(orderDate) Then
                ordDate = Date.Now
            End If
            _items = orderItems

        End Sub


        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim i As Order = CType(obj, Order)
            Return i._id = Me._id And i.Items.SequenceEqual(Me.Items)
        End Function

#Region "Friend functions"
        Friend Sub SetID(ByVal id As Integer)
            _id = id
        End Sub

#End Region

        Dim _id As Integer
        Dim _ordDate As Date
        Dim _items As New List(Of Item)
    End Class


End Namespace