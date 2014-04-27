Imports VBAssign2.MyModels

Namespace ViewModels

    Public Class RepoBase
        Public Sub New()
            dc = New DataContext

            '* turn off lazy loading, we do it ourselves
            dc.Configuration.ProxyCreationEnabled = False
            dc.Configuration.LazyLoadingEnabled = False

        End Sub

        Protected dc As DataContext
    End Class
End Namespace

