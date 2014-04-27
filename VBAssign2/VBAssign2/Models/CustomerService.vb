Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports VBAssign2.MyModels

Public Class CustomerService

    Public Function AddCustomer(m As VBALib.BO.Customer, id As Integer) As MyModels.Adapters.Customer
        Dim result = context_.Customers.Add(New MyModels.Adapters.Customer(m, id))
        context_.SaveChanges()
        Return result
    End Function

    Public Function GetAllCustomers() As List(Of MyModels.Adapters.Customer)
        Dim query = From cst In context_.Customers
                    Order By cst.Name
                    Select cst

        Return query.ToList()

    End Function

    Sub New(ctx As DataContext)
        If ctx IsNot Nothing Then
            context_ = ctx
        Else
            context_ = New DataContext
        End If
    End Sub

    Sub New()
        context_ = New DataContext
    End Sub

    Private context_ As DataContext

End Class
