Imports System.Data.Entity

Namespace ViewModels
    Public Class RepoCustomer
        Inherits RepoBase

        Public Function GetListOfCustomerBase() As List(Of CustomerBase)
            Dim csts = dc.Customers.OrderBy(Function(c) c.cstId)
            Dim cbls = New List(Of CustomerBase)
            For Each itm In csts
                Dim cst As New CustomerBase
                cst.cstId = itm.cstId
                cst.Name = itm.Name
                cbls.Add(cst)
            Next
            Return cbls
        End Function

        Public Function GetCustomerFullById(id? As Integer) As CustomerFull
            If (id Is Nothing) Then Return Nothing
            Dim cst = dc.Customers.Include(Function(c) c.Orders).FirstOrDefault(Function(c) c.cstId = id)
            Dim cf As New CustomerFull

            cf.cstId = cst.cstId
            cf.Name = cst.Name
            cf.email = cst.Email
            cf.phone = cst.Phone

            Dim cstOrders As New List(Of OrderFull)
            Dim cstItems As New List(Of ItemFull)
            For Each ord In cst.Orders
                'For Each itm In ord.ordItems
                '    Dim t As New ItemFull
                '    t.itmId = itm.itmId
                '    t.brand = itm.Brand
                '    t.name = itm.Name
                '    t.price = itm.Price
                '    t.quantity = itm.Quantity

                '    cstItems.Add(t)
                'Next
                Dim o As New OrderFull
                o.ordId = ord.ordId
                o.ordDate = ord.ordDate
                'o.items = cstItems
                cstOrders.Add(o)
            Next

            cf.orders = cstOrders

            Return cf

        End Function

        Public Function EditCustomer(id As Integer, cForm As FormCollection) As Boolean
            Dim nCst = dc.Customers.Include(Function(c) c.Orders).FirstOrDefault(Function(c) c.cstId = id)
                nCst.Name = cForm("Name").ToString
                nCst.Email = cForm("email").ToString
                nCst.Phone = cForm("phone").ToString
                nCst.Orders = nCst.Orders

            If dc.SaveChanges() Then
                Return True
            Else
                Return False
            End If
        End Function

        'Public Function CreateNewCustomer(cForm As FormCollection) As Boolean

        'End Function
    End Class
End Namespace

