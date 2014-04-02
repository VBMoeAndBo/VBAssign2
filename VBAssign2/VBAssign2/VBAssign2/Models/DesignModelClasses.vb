﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace DesignModels

    Public Class Customer
        Public Sub New()
            Me.orders = New List(Of Order)()
        End Sub
        Public Property id As Integer
        Public Property name As String
        Public Property email1 As String
        Public Property email2 As String
        Public Property phoneNumber As String
        Public Property orders As ICollection(Of Order)

    End Class

    Public Class Order
        Public Sub New()
            Me.items = New List(Of Item)()
        End Sub
        Public Property id As Integer
        Public Property ordDate As Date
        Public Property customer As Customer
        Public Property items As ICollection(Of Item)
    End Class

    Public Class Item
        Public Property id As Integer
        Public Property name As String
        Public Property brand As String
        Public Property quality As String
        Public Property price As Double
        Public Property weight As Double

    End Class

End Namespace
