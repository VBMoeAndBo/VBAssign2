' Filename: /Models/Adapters/Customer
' purpose: wrapper to communicate with the customer class in VBAssign1 dll

Imports VBALib.BO
Imports System.ComponentModel.DataAnnotations

' i added one more
Namespace MyModels.Adapters

    <Schema.Table("Customers")>
    Public Class Customer
        <Key()>
        Public Property cstId As Integer
        Public Property Name As String
            Get
                Return customer.Name
            End Get
            Set(value As String)
                Try
                    ' msgState.Clear()
                    customer.Name = value
                Catch ex As Exception
                    _cstState.AddModelError("Name", ex.Message)
                End Try
            End Set
        End Property
        Public Property Email As String
            Get
                Return customer.Email
            End Get
            Set(value As String)
                Try
                    'msgState.Clear()
                    customer.Email = value
                Catch ex As Exception
                    _cstState.AddModelError("Email", ex.Message)
                End Try
            End Set
        End Property
        Public Property Phone As String
            Get
                Return customer.Phone
            End Get
            Set(value As String)
                Try
                    ' msgState.Clear()
                    customer.Phone = value
                Catch ex As Exception
                    _cstState.AddModelError("Phone", ex.Message)
                End Try
            End Set
        End Property
        Public Property Orders As List(Of Adapters.Order)

        Public Sub New()
            customer = New VBALib.BO.Customer
            orders_ = New List(Of Adapters.Order)
            _cstState = New ModelStateDictionary
        End Sub

        Public Sub New(ByVal cst As VBALib.BO.Customer, ByVal id As Integer)
            cstId = id
            customer = New VBALib.BO.Customer
            customer.Name = cst.Name
            customer.Email = cst.Email
            customer.Phone = cst.Phone

            Dim cOrders As New List(Of Adapters.Order)
            Dim cItems As New List(Of Adapters.Item)
            For Each ord In cst.Orders
                For Each itm In ord.Items
                    cItems.Add(New Adapters.Item With {
                                 .itmId = itm.ItemID,
                                 .Brand = itm.Brand,
                                 .Name = itm.Name,
                                 .Price = itm.Price,
                                 .Quantity = itm.Quantity})
                Next
                cOrders.Add(New Adapters.Order With {
                              .ordId = ord.OrderID,
                              .ordDate = ord.ordDate,
                              .ordItems = cItems})
            Next
            Orders = cOrders

            _cstState = New ModelStateDictionary
        End Sub

        Dim customer As VBALib.BO.Customer
        Dim orders_ As List(Of Adapters.Order)
        Dim _cstState As ModelStateDictionary

        Public ReadOnly Property CstState() As ModelStateDictionary
            Get
                Return _cstState
            End Get
        End Property
    End Class


End Namespace

