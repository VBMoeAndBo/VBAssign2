Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.SqlServer

'add profile data for the user by adding more properties
Namespace MyModels
    'changed from ApplicationDbContext to DataContext
    Public Class DataContext
        Inherits IdentityDbContext(Of ApplicationUser)

        ' customermized properties
        Public Overridable Property Customer As IDbSet(Of Adapters.Customer)


    End Class

End Namespace

