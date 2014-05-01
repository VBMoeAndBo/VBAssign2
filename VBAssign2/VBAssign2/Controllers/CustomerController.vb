Imports System.Web.Mvc
Imports VBAssign2.ViewModels
Imports VBAssign2.MyModels

Public Class CustomerController
    Inherits Controller

    Dim Cst As ViewModels.RepoCustomer
    Dim Ord As ViewModels.RepoOrder
    Dim Itm As ViewModels.RepoItem

    Private db As New DataContext

    Shared customer As New VBAssign2.ViewModels.CustomerForHttpGet
    Public Sub New()
        Cst = New ViewModels.RepoCustomer
        Ord = New ViewModels.RepoOrder
        Itm = New ViewModels.RepoItem
    End Sub

    ' GET: /Customer
    Function Index() As ActionResult
        Return View(Cst.GetListOfCustomerBase)
    End Function

    ' GET: /Customer/Details/5
    Function Details(ByVal id? As Integer) As ActionResult
        If (id IsNot Nothing) And (id > 0) Then
            Return View(Cst.GetCustomerFullById(id))
        Else
            Dim vme As New ViewModels.VM_Error()
            vme.ErrorMessages("ExceptionMessage") = "Sorry that id was not found."
            Return View("MyError", vme)
        End If
    End Function

    ' GET: /Customer/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Customer/Create
    'Function Create(<Bind(Include:="ID,Title,ReleaseDate,Genre,Price,Rating")> ByVal movie As Movie) As ActionResult
    '    If ModelState.IsValid Then
    '        db.Movies.Add(movie)
    '        db.SaveChanges()
    '        Return RedirectToAction("Index")
    '    End If
    '    Return View(movie)
    'End Function
    <HttpPost()>
    Function Create(ByVal customer As CustomerFull) As ActionResult
        Try
            If ModelState.IsValid Then
                db.Customers.Add(customer)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If


        Catch
            Return View(customer)
        End Try
    End Function

    ' GET: /Customer/Edit/5
    Function Edit(ByVal id? As Integer) As ActionResult
        If (id > 0) Then

            Return View(Cst.GetCustomerFullById(id))
        Else
            Dim vme As New ViewModels.VM_Error()
            vme.ErrorMessages("ExceptionMessage") = "Sorry that id was not found."
            Return View("MyError", vme)
        End If

    End Function

    ' POST: /Customer/Edit/5
    <HttpPost()>
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult

        If (id > 0) And Cst.EditCustomer(id, collection) Then
            Return RedirectToAction("Index")
        Else
            Dim vme As New ViewModels.VM_Error()
            vme.ErrorMessages("ExceptionMessage") = "Sorry that id was not found."
            Return View("MyError", vme)
        End If

    End Function

    ' GET: /Customer/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    ' POST: /Customer/Delete/5
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