Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports VBAssign2.MyModels
Imports VBALib

Namespace ViewModels
    Public Class CustomerBase
        <Key()>
        Public Property cstId As Integer
        Public Property Name As String
    End Class

    Public Class CustomerFull
        Inherits CustomerBase
        Public Sub New()
            Me.orders = New List(Of OrderFull)
        End Sub
        Public Property Email As String
        Public Property Phone As String
        Public Property Orders As ICollection(Of OrderFull)

    End Class

    Public Class CustomerForHttpGet
        <Display(Name:="Id: ")>
        Public Property cstId As Integer
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
        <Required>
        Public Property Phone As String

        Public Property ordersList As SelectList
 
    End Class
End Namespace

