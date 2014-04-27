Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports VBAssign2.MyModels
Imports VBALib

Namespace ViewModels
    Public Class OrderBase
        <Key()>
        Public Property ordId As Integer

    End Class

    Public Class OrderFull
        Inherits OrderBase
        Public Sub New()
            Me.items = New List(Of ItemFull)
        End Sub
        Public Property ordDate As Date
        Public Property customer As CustomerFull
        Public Property items As ICollection(Of ItemFull)
    End Class
End Namespace

