Imports VBA01Lib.BO
Imports Newtonsoft.Json
Namespace DA

    Public Class JSONInterface
        Implements DAInterface

#Region "Customer"
        Public Sub WriteCustomer(ByVal custList As List(Of Customer)) Implements DAInterface.WriteCustomer
            Using sw As New IO.StreamWriter(filename_Customer, False)
                sw.WriteLine(JsonConvert.SerializeObject(custList, _formatting, _settings))
            End Using
        End Sub

        Public Function ReadCustomer() As List(Of Customer) Implements DAInterface.ReadCustomer
            Try
                Using sr As New IO.StreamReader(filename_Customer)
                    Dim list = JsonConvert.DeserializeObject(Of List(Of Customer))(sr.ReadToEnd)
                    If IsNothing(list) Then
                        Return New List(Of Customer)
                    Else
                        Return list
                    End If
                End Using
            Catch ex As System.IO.FileNotFoundException
                Return New List(Of Customer)
            End Try
        End Function
#End Region
#Region "Item"
        Public Sub WriteItem(ByVal item As List(Of Item)) Implements DAInterface.WriteItem
            Using sw As New IO.StreamWriter(filename_Item, False)
                sw.WriteLine(JsonConvert.SerializeObject(item, _formatting, _settings))
            End Using
        End Sub
        Public Function ReadItem() As List(Of Item) Implements DAInterface.ReadItem
            Try
                Using sr As New IO.StreamReader(filename_Item)
                    Dim list = JsonConvert.DeserializeObject(Of List(Of Item))(sr.ReadToEnd)
                    If IsNothing(list) Then
                        Return New List(Of Item)
                    Else
                        Return list
                    End If
                End Using
            Catch ex As System.IO.FileNotFoundException
                Return New List(Of Item)
            End Try
        End Function
#End Region
        Public Sub New()
            'JSON settings
            _settings = New JsonSerializerSettings()
            _settings.TypeNameHandling = TypeNameHandling.Arrays
            _formatting = Newtonsoft.Json.Formatting.Indented
        End Sub

        Dim filename_Customer As String = "CustomerList.json"
        Dim filename_Item As String = "ItemList.json"

        Dim _settings As JsonSerializerSettings
        Dim _formatting As Formatting
    End Class
End Namespace