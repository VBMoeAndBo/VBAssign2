Imports System.Data.Entity

Namespace ViewModels
    Public Class RepoItem
        Inherits RepoBase
        Public Function GetListOfItemFull() As List(Of ItemFull)
            Dim items = dc.Items.OrderBy(Function(i) i.Name)
            Dim ibls = New List(Of ItemFull)
            For Each itm In items
                Dim i As New ItemFull
                i.itmId = itm.itmId
                i.name = itm.Name
                i.brand = itm.Brand
                i.price = itm.Price
                i.quantity = itm.Quantity
                ibls.Add(i)
            Next
            Return ibls
        End Function

        Public Function GetItemFullById(id? As Integer) As ItemFull
            If (id Is Nothing) Then Return Nothing
            Dim item = dc.Items.Find(Function(i) i.itmId = id)
            Dim itf As New ItemFull
            itf.itmId = item.itmId
            itf.name = item.Name
            itf.brand = item.Brand
            itf.price = item.Price
            itf.quantity = item.Quantity

            Return itf
        End Function

        Public Function EditItem(id As Integer, cForm As FormCollection) As Boolean
            Dim nCst = dc.Items.Find(Function(i) i.itmId = id)
            nCst.Name = cForm("name").ToString
            nCst.Brand = cForm("brand").ToString
            nCst.Price = Convert.ToDouble(cForm("price"))
            nCst.Quantity = Convert.ToInt32(cForm("quantity"))

            If dc.SaveChanges() Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

