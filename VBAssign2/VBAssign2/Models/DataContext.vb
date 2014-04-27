Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.SqlServer
Imports VBAssign2.MyModels

'add profile data for the user by adding more properties
Namespace MyModels
    'changed from ApplicationDbContext to DataContext
    Public Class DataContext
        Inherits IdentityDbContext(Of ApplicationUser)

        ' customermized properties
        Public Overridable Property Customers As IDbSet(Of Adapters.Customer)
        Public Overridable Property Items As IDbSet(Of Adapters.Item)
        Public Overridable Property Orders As IDbSet(Of Adapters.Order)

        Protected Shadows Sub OnModelCreating(modelBuilder As DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

            '* Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity(Of IdentityUser).ToTable("Users")
            modelBuilder.Entity(Of ApplicationUser).ToTable("Users")

        End Sub

        Public Sub New()
            '* -- MF: changed from DefaultConnection to DataContext
            MyBase.New("DataContext")
        End Sub

        Public Property CustomerBases As System.Data.Entity.DbSet(Of ViewModels.CustomerBase)
        Public Property CustomerFulls As System.Data.Entity.DbSet(Of ViewModels.CustomerFull)
        Public Property OrderBases As System.Data.Entity.DbSet(Of ViewModels.OrderBase)
        Public Property OrderFulls As System.Data.Entity.DbSet(Of ViewModels.OrderFull)
        Public Property ItemBases As System.Data.Entity.DbSet(Of ViewModels.ItemBase)
        Public Property ItemFulls As System.Data.Entity.DbSet(Of ViewModels.ItemFull)

    End Class

End Namespace

