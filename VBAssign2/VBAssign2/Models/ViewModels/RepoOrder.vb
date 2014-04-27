Imports System.Data.Entity

Namespace ViewModels
    Public Class RepoOrder
        Inherits RepoBase
        Public Function GetListOfOrderFull() As List(Of OrderFull)
            Dim ords = dc.Orders.OrderBy(Function(o) o.ordId)
            Dim obls = New List(Of OrderFull)
            For Each ord In ords
                Dim o As New OrderFull
                o.ordId = ord.ordId
                o.ordDate = ord.ordDate
                'o.customer.cstId = ord.Customer.cstId
                obls.Add(o)
            Next
            Return obls
        End Function

        Public Function GetOrderFullById(id? As Integer) As OrderFull
            If (id Is Nothing) Then Return Nothing
            Dim ord = dc.Orders.Include(Function(o) o.ordItems).FirstOrDefault(Function(o) o.ordId = id)
            Dim odf As New OrderFull
            odf.ordId = ord.ordId
            odf.ordDate = ord.ordDate

            Dim odItms As New List(Of ItemFull)
            For Each itm In ord.ordItems
                Dim i As New ItemFull
                i.itmId = itm.itmId
                i.name = itm.Name
                i.brand = itm.Brand
                i.price = itm.Price
                i.quantity = itm.Quantity

                odItms.Add(i)
            Next
            odf.items = odItms

            Return odf
        End Function
    End Class
End Namespace

