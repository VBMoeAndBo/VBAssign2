Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports VBAssign2.MyModels
Imports VBALib
Imports VBAssign2.MyModels.Adapters

Namespace ViewModels
    Public Class CustomerBase
        <Key()>
        Public Property cstId As Integer
        Public Property Name As String
        Public Property Email As String

    End Class

    Public Class CustomerFull
        Inherits CustomerBase
        Public Sub New()
            Me.Orders = New List(Of Order)
        End Sub

        Public Property Phone As String
        Public Property Orders As List(Of Order)

    End Class

    Public Class CustomerForHttpGet
        
        <Display(Name:="Name: ")>
        Public Property Name As String
        <Display(Name:="Email: ")>
        Public Property Email As String
        <Display(Name:="Phone: ")>
        Public Property Phone As String
        Public Property ordersList As SelectList

        Sub Clear()
            Name = String.Empty
            Email = String.Empty
            Phone = String.Empty
            ordersList = Nothing
        End Sub
    End Class

    Public Class CustomerForHttpPost

        <Required>
        Public Property Name As String
        <Required>
        Public Property Email As String

        Public Property Phone As String

        Public Property ordersList As List(Of Order)

    End Class
End Namespace

