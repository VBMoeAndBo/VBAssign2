Imports VBA01Lib.BO
Imports VBA01Lib.DA

Namespace BL

    Public Class Controller
        Dim DAInterface As DAInterface

        Shared _customerList As List(Of Customer)
        Shared _itemList As List(Of Item)

        Public ReadOnly Property customerList As List(Of Customer)
            Get
                Return _customerList
            End Get
        End Property
        Public ReadOnly Property itemList As List(Of Item)
            Get
                Return _itemList
            End Get
        End Property
        Public ReadOnly Property lastCustomerID As Integer
            Get
                Dim max_id As Integer = 0
                For Each c In _customerList
                    If max_id < c.CustomerID Then
                        max_id = c.CustomerID
                    End If
                Next
                Return max_id
            End Get
        End Property
        Public ReadOnly Property lastItemID As Integer
            Get
                Dim max_id As Integer = 0
                For Each i In _itemList
                    If max_id < i.ItemID Then
                        max_id = i.ItemID
                    End If
                Next
                Return max_id
            End Get
        End Property

        Public Sub New()
            'initialize interfaces
            DAInterface = New JSONInterface()

            'initialize lists
            If IsNothing(_customerList) Then
                _customerList = Me.getCustomerList()
            End If
            If IsNothing(_itemList) Then
                _itemList = Me.getItemList()
            End If

        End Sub
        Private Sub Update()
            DAInterface.WriteCustomer(_customerList)
            DAInterface.WriteItem(_itemList)
        End Sub

#Region "Customer"

        Public Function SaveCustomer(ByVal cust As Customer) As Integer
            If cust.CustomerID = -1 Then
                Me.createCustomer(New Customer(Me.lastCustomerID + 1, cust.Name, cust.Email, cust.OrderList))
                Return lastCustomerID
            Else
                Me.updateCustomer(cust)
                Return cust.CustomerID
            End If
        End Function
        Public Sub deleteCustomer(ByVal customer As Customer)
            Dim index = _customerList.IndexOf(customer)
            If index = -1 Then
                Throw New ControllerException("Customer not found or was modified (Delete). ID = " & customer.CustomerID)
            Else
                _customerList.RemoveAt(index)
                Update()
            End If
        End Sub
        Private Function getCustomerList() As List(Of Customer)
            Return DAInterface.ReadCustomer()
        End Function

        Public Function getcustomer(ByVal id As Integer) As Customer
            Return Me.getCustomerList().Find(Function(c) c.CustomerID = id)
        End Function
        Private Sub createCustomer(ByVal newCustomer As Customer)
            _customerList.Add(newCustomer)
            Update()
        End Sub
        Private Sub updateCustomer(ByVal customer As Customer)
            Dim original As Customer = _customerList.Find(Function(c) c.CustomerID = customer.CustomerID)
            Dim index As Integer = _customerList.IndexOf(original)
            If Not index = -1 Then
                _customerList(index).Name = customer.Name
                _customerList(index).Email = customer.Email
                Update()
            Else
                Throw New ControllerException("Customer not found (Update). ID = " & customer.CustomerID)
            End If
        End Sub

        Public Function getCustLastOrderId(ByVal customer As Customer) As Integer
            Dim maxId As Integer = 0
            If Not IsNothing(customer.OrderList) Then
                For Each ord In customer.OrderList
                    If maxId < ord.OrderID Then
                        maxId = ord.OrderID
                    End If
                Next
            End If
            Return (maxId + 1)
        End Function

#End Region

#Region "Item"
        Public Sub SaveItem(ByVal item As Item)
            If item.ItemID = -1 Then
                createItem(New Item(Me.lastItemID + 1, item.ItemName, item.ItemPrice))
            Else
                Me.updateItem(item)
            End If
        End Sub
        Public Sub deleteItem(ByVal item As Item)
            Dim index = _itemList.IndexOf(item)
            If Not index = -1 Then
                _itemList.RemoveAt(index)
                Update()
            Else
                Throw New ControllerException("Item not found or was modified (Delete). ID = " & item.ItemID)
            End If
        End Sub
        Private Function getItemList() As List(Of Item)
            Return DAInterface.ReadItem()
        End Function
        Private Sub createItem(ByVal newItem As Item)
            _itemList.Add(newItem)
            Update()
        End Sub
        Private Sub updateItem(ByVal item As Item)
            Dim original As Item = _itemList.Find(Function(i) i.ItemID = item.ItemID)
            Dim index As Integer = _itemList.IndexOf(original)
            If Not index = -1 Then
                _itemList(index).ItemName = item.ItemName
                _itemList(index).ItemPrice = item.ItemPrice
                Update()
            Else
                Throw New ControllerException("Item not found (Update). ID = " & item.ItemID)
            End If
        End Sub

#End Region

    End Class
    Public Class ControllerException
        Inherits System.Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class

End Namespace
