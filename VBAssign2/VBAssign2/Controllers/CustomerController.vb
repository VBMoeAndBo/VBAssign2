﻿Imports System.Web.Mvc
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
        Return View(customer)
    End Function

    ' POST: /Customer/Create
    
    <HttpPost()>
    Function Create(ByVal newCustomer As CustomerForHttpPost) As ActionResult

        If (Not ModelState.IsValid) Then
            ModelState.AddModelError("CreateCustomer", "Customer not created due to invalid or missing data")
            Return View(customer)
        End If


        Dim createdCustomer = Cst.createCustomer(newCustomer, Me.ModelState)
        If createdCustomer Is Nothing Then
            Return View(customer)
        Else
            Return RedirectToAction("Details", New With {.id = createdCustomer.cstId})
        End If




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