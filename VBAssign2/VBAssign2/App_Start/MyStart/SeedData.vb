'*************************************************************************
'* Filename: /Models/SeedData.vb
'* By:       MF
'* Last Modified Date: 12 Aug 2012
'* Purpose:  Drop and Create database, then seed the database with initial values
'*
'**************************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity
Imports VBAssign2.MyModels
Imports VBALib.BO
Imports System.Globalization

'* All methods are Shared to avoid creating explicit instance of object just to initialize DB
Public Class SeedData

    Public Sub InitializeDbWithValues(context As DataContext)
        Dim how2Seed = "" '"VALUES"       '* controls how

        '' left this here to demonstrate how I debugged unit testing issues
        'Using sw = New IO.StreamWriter("logFile.txt", True)
        '    sw.WriteLine("InitializeDbWithValues: deciding how to initialize JSON")
        'End Using

        '* how2Seed controls whether to use JSON file or not
        If (how2Seed = "VALUES") Then : SeedWithValues(context)
        Else : SeedFromFile(context)   ' uses JSON given or default
        End If

    End Sub


    Private Sub SeedFromFile(context As DataContext)

        '* read from json file stored in App_Data folder
        Dim jsonCustomers As List(Of VBALib.BO.Customer)
        Dim aCustomer As New VBALib.BO.Customer

        jsonCustomers = VBALib.BO.CustomerHelper.DeserializeJSON(jsonFile_)

        '* Create list of MvcMessageAdapters to hold only records
        '* that are valid for given business rules (IsValid flag
        '* set to false when any exception occurs in properties)
        Dim mvcCustomers = New List(Of Adapters.Customer)

        Dim pId As Integer = 0

        For Each jCst In jsonCustomers
            If (jCst.IsValid) Then

                mvcCustomers.Add(New Adapters.Customer(jCst, pId))
                pId = pId + 1
            End If
        Next

        '' left this here to demonstrate how I debugged unit testing issues
        'Using sw = New IO.StreamWriter("logFile.txt", True)
        '    sw.WriteLine("Read json, now writing to database")
        'End Using

        '* Add to the Messages table (master in the database)
        mvcCustomers.ForEach(Function(g) context.Customers.Add(g))


        '* Free records
        jsonCustomers = Nothing
        mvcCustomers = Nothing

        '   MyBase.Seed(context)
    End Sub

    Private Sub SeedWithValues(context As DataContext)

        'Dim formatter As New DateTimeFormatInfo()
        'formatter.ShortDatePattern = "dd/MM/yyyy"
        'formatter.DateSeparator = "/"

        ''* Add items to the master table (Message) first
        'Dim cstList = New List(Of Adapters.Customer) From {
        '    New Adapters.Customer With {.Name = "Bob Liu", .Email = "bob@myseneca.ca", .Phone = "6472566789"},
        '    New Adapters.Customer With {.Name = "Moe", .Email = "Moe@myseneca.ca", .Phone = "6471234567"},
        '    New Adapters.Customer With {.Name = "John Smith", .Email = "johnsmith@senecacollege.ca", .Phone = "4161239876"}
        '}
        'cstList.ForEach(Function(c) context.Customers.Add(c))

        'Dim ordList = New List(Of Adapters.Order) From {
        '    New Adapters.Order With {.cstId = 1, .ordDate = Convert.ToDateTime("29/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 1, .ordDate = Convert.ToDateTime("29/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 1, .ordDate = Convert.ToDateTime("30/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 2, .ordDate = Convert.ToDateTime("30/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 2, .ordDate = Convert.ToDateTime("30/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 3, .ordDate = Convert.ToDateTime("30/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 3, .ordDate = Convert.ToDateTime("30/03/2014", formatter)},
        '    New Adapters.Order With {.cstId = 3, .ordDate = Convert.ToDateTime("31/03/2014", formatter)}
        '}
        'ordList.ForEach(Function(o) context.Orders.Add(o))

        'Dim itmList = New List(Of Adapters.Item) From {
        '    New Adapters.Item With {.ordId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
        '    New Adapters.Item With {.ordId = 1, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 2, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"},
        '    New Adapters.Item With {.ordId = 2, .Name = "Rice", .Brand = "GolenRoll", .Price = "9.99", .Quantity = "1"},
        '    New Adapters.Item With {.ordId = 2, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 3, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 3, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 3, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 3, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "3"},
        '    New Adapters.Item With {.ordId = 4, .Name = "Rice", .Brand = "GolenRoll", .Price = "9.99", .Quantity = "1"},
        '    New Adapters.Item With {.ordId = 4, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
        '    New Adapters.Item With {.ordId = 4, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 4, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"},
        '    New Adapters.Item With {.ordId = 5, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 5, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 5, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 6, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 6, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "3"},
        '    New Adapters.Item With {.ordId = 7, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 7, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 8, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
        '    New Adapters.Item With {.ordId = 8, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
        '    New Adapters.Item With {.ordId = 8, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"},
        '    New Adapters.Item With {.ordId = 8, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"}
        '}
        'itmList.ForEach(Function(i) context.Items.Add(i))
        'MyBase.Seed(context)


        Dim formatter As New DateTimeFormatInfo()
        formatter.ShortDatePattern = "dd/MM/yyyy"
        formatter.DateSeparator = "/"

        '* Add items to the master table (Message) first
        Dim cstList = New List(Of Adapters.Customer) From {
            New Adapters.Customer With {.cstId = 1, .Name = "Bob Liu", .Email = "bob@myseneca.ca", .Phone = "6472566789",
                                        .Orders = New List(Of Adapters.Order) From {
                                            New Adapters.Order With {.ordId = 1, .ordDate = Convert.ToDateTime("29/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 3, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 2, .ordDate = Convert.ToDateTime("29/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 4, .Name = "Rice", .Brand = "GolenRoll", .Price = "9.99", .Quantity = "1"},
                                                                         New Adapters.Item With {.itmId = 5, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 6, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 7, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 3, .ordDate = Convert.ToDateTime("30/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "3"}
                                                                     }}
                                        }},
         New Adapters.Customer With {.cstId = 2, .Name = "Moe", .Email = "Moe@myseneca.ca", .Phone = "6471234567",
                                        .Orders = New List(Of Adapters.Order) From {
                                            New Adapters.Order With {.ordId = 1, .ordDate = Convert.ToDateTime("30/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 4, .Name = "Rice", .Brand = "GolenRoll", .Price = "9.99", .Quantity = "1"},
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 3, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 2, .ordDate = Convert.ToDateTime("30/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 5, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 7, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 3, .ordDate = Convert.ToDateTime("30/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 6, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "3"}
                                                                     }}
                                        }},
        New Adapters.Customer With {.cstId = 3, .Name = "John Smith", .Email = "johnsmith@senecacollege.ca", .Phone = "4161239876",
                                        .Orders = New List(Of Adapters.Order) From {
                                            New Adapters.Order With {.ordId = 1, .ordDate = Convert.ToDateTime("30/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 5, .Name = "Noodle", .Brand = "GeneralMill", .Price = "2.59", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 6, .Name = "Bread", .Brand = "BigBread", .Price = "2.99", .Quantity = "2"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 2, .ordDate = Convert.ToDateTime("31/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 4, .Name = "Rice", .Brand = "GolenRoll", .Price = "9.99", .Quantity = "1"},
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "3"}
                                                                     }},
                                            New Adapters.Order With {.ordId = 3, .ordDate = Convert.ToDateTime("31/03/2014", formatter),
                                                                     .ordItems = New List(Of Adapters.Item) From {
                                                                         New Adapters.Item With {.itmId = 1, .Name = "Beef", .Brand = "Maple", .Price = "5.99", .Quantity = "3"},
                                                                         New Adapters.Item With {.itmId = 2, .Name = "Pork", .Brand = "GeneralMill", .Price = "3.99", .Quantity = "2"},
                                                                         New Adapters.Item With {.itmId = 3, .Name = "Fish", .Brand = "GreenSee", .Price = "6.99", .Quantity = "1"},
                                                                         New Adapters.Item With {.itmId = 7, .Name = "Chicken", .Brand = "GreenMeat", .Price = "3.99", .Quantity = "2"}
                                                                     }}
                                        }}
        }
        cstList.ForEach(Function(c) context.Customers.Add(c))

    End Sub

    Dim jsonFile_ As String

    Public Sub New()
        jsonFile_ = HttpContext.Current.Server.MapPath("~/App_Data/CustomerList.json")
    End Sub

    Public Sub New(jsonFilename As String)
        jsonFile_ = jsonFilename
    End Sub

End Class