Imports VBA01Lib.BO

Namespace DA
    Public Interface DAInterface
        Sub WriteCustomer(ByVal cust As List(Of Customer))
        Function ReadCustomer() As List(Of Customer)
        Sub WriteItem(ByVal itm As List(Of Item))
        Function ReadItem() As List(Of Item)
    End Interface

End Namespace
