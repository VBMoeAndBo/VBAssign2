Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports VBAssign2.MyModels
Imports VBALib

Namespace ViewModels

    Public Class ItemBase
        <Key()>
        Public Property itmId As Integer
    End Class

    Public Class ItemFull
        Inherits ItemBase
        Public Property name As String
        Public Property brand As String
        Public Property quantity As Integer
        Public Property price As Double

    End Class
End Namespace

