Imports System.Web.Mvc

Public Class OrderController
    Inherits Controller

    Dim Ord As ViewModels.RepoOrder

    Public Sub New()
        Ord = New ViewModels.RepoOrder
    End Sub
    ' GET: /Order
    Function orderList() As ActionResult
        Return View(Ord.GetListOfOrderFull)
    End Function

    Function customerOrders(ByVal cstid As Integer) As ActionResult
        Return View()
    End Function
    ' GET: /Order/Details/5
    Function Details(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' GET: /Order/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Order/Create
    <HttpPost()>
    Function Create(ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add insert logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Order/Edit/5
    Function Edit(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Order/Edit/5
    <HttpPost()>
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Order/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Order/Delete/5
    <HttpPost()>
    Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add delete logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function
End Class