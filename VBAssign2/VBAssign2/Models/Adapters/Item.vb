Imports VBALib.BO
Imports System.ComponentModel.DataAnnotations

Namespace MyModels.Adapters
    <Schema.Table("Items")>
    Public Class Item
        <Key()>
        Public Property itmId As Integer

        Public Property ordId As Integer

        <Schema.ForeignKey("ordId")>
        Public Property Order As MyModels.Adapters.Order

        Public Property Name As String
            Get
                Return item_.Name
            End Get
            Set(value As String)
                Try
                    itmState_.Clear()
                    item_.Name = value
                Catch ex As Exception
                    itmState_.AddModelError("Name", ex.Message)
                End Try
            End Set
        End Property
        Public Property Brand As String
            Get
                Return item_.Brand
            End Get
            Set(value As String)
                Try
                    itmState_.Clear()
                    item_.Brand = value
                Catch ex As Exception
                    itmState_.AddModelError("Brand", ex.Message)
                End Try
            End Set
        End Property
        Public Property Price As Double
            Get
                Return item_.Price
            End Get
            Set(value As Double)
                Try
                    itmState_.Clear()
                    item_.Price = value
                Catch ex As Exception
                    itmState_.AddModelError("Price", ex.Message)
                End Try
            End Set
        End Property
        Public Property Quantity As Integer
            Get
                Return item_.Quantity
            End Get
            Set(value As Integer)
                Try
                    itmState_.Clear()
                    item_.Quantity = value
                Catch ex As Exception
                    itmState_.AddModelError("Quantity", ex.Message)
                End Try
            End Set
        End Property

        Public Sub New()
            item_ = New VBALib.BO.Item
            itmState_ = New ModelStateDictionary
        End Sub

        Public Sub New(nm As String, br As String, pr As Double, qu As Integer)
            'itmId = id
            item_ = New VBALib.BO.Item(nm, br, pr, qu)
            itmState_ = New ModelStateDictionary
        End Sub

        Public Sub New(ByVal itm As VBALib.BO.Item, ByVal id As Integer)
            itmId = id
            item_ = New VBALib.BO.Item
            item_.Name = itm.Name
            item_.Brand = itm.Brand
            item_.Price = itm.Price
            item_.Quantity = itm.Quantity

            itmState_ = New ModelStateDictionary
        End Sub

        Dim item_ As VBALib.BO.Item
        Dim itmState_ As ModelStateDictionary

        Public ReadOnly Property ItemState() As ModelStateDictionary
            Get
                Return itmState_
            End Get
        End Property

        

    End Class
End Namespace