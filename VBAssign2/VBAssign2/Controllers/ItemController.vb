Imports System.Web.Mvc

Public Class ItemController
    Inherits Controller

    Dim Cst As ViewModels.RepoCustomer
    Dim Ord As ViewModels.RepoOrder
    Dim Itm As ViewModels.RepoItem
    Public Sub New()
        Cst = New ViewModels.RepoCustomer
        Ord = New ViewModels.RepoOrder
        Itm = New ViewModels.RepoItem
    End Sub

    ' GET: /Item
    Function itemList() As ActionResult
        Return View(Itm.GetListOfItemFull)
    End Function

    ' GET: /Item/Details/5
    Function Details(ByVal id As Integer) As ActionResult
        If (id > 0) Then
            Return View(Itm.GetItemFullById(id))
        Else
            Dim vme As New ViewModels.VM_Error()
            vme.ErrorMessages("ExceptionMessage") = "Sorry that id was not found."
            Return View("MyError", vme)
        End If
    End Function

    ' GET: /Item/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Item/Create
    <HttpPost()>
    Function Create(ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add insert logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Item/Edit/5
    Function Edit(ByVal id? As Integer) As ActionResult
        If (id > 0) Then
            Return View(Itm.GetItemFullById(id))
        Else
            Dim vme As New ViewModels.VM_Error()
            vme.ErrorMessages("ExceptionMessage") = "Sorry that id was not found."
            Return View("MyError", vme)
        End If
    End Function

    ' POST: /Item/Edit/5
    <HttpPost()>
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' GET: /Item/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Item/Delete/5
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