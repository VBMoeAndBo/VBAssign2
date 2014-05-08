Imports VBALib.BO
Imports System.ComponentModel.DataAnnotations

Namespace MyModels.Adapters
    <Schema.Table("Orders")>
    Public Class Order
        <Key()>
        Public Property ordId As Integer
        Public Property cstId As Integer

        <Schema.ForeignKey("cstId")>
        Public Property Customer As MyModels.Adapters.Customer

        Dim libOrder As VBALib.BO.Order

        Public Sub New()
            libOrder = New VBALib.BO.Order
            libOrdState = New ModelStateDictionary
        End Sub

        Public Sub New(d As Date, itms As List(Of VBALib.BO.Item))
            libOrder = New VBALib.BO.Order(itms, d)
            libOrdState = New ModelStateDictionary
        End Sub

        Public Property ordItems As List(Of Adapters.Item)

        Public Property ordDate As Date
            Get
                Return libOrder.ordDate
            End Get
            Set(value As Date)
                Try
                    libOrder.ordDate = value
                Catch ex As Exception
                    '* IMPORTANT key value should be same as the property
                    libOrdState.AddModelError("ordDate", ex.Message)
                End Try
            End Set
        End Property


        Dim libOrdState As ModelStateDictionary

        Public ReadOnly Property OrdState() As ModelStateDictionary
            Get
                Return libOrdState
            End Get
        End Property
    End Class
End Namespace
