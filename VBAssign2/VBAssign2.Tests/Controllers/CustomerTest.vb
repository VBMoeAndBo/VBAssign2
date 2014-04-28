Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VBALib.BO


<TestClass()> Public Class CustomerTest

    Const NAME As String = "Joe Blow"
    Const EMAIL1 As String = "jblow@myseneca.ca"
    Const EMAIL2 As String = "joe.blow@senecacollege.ca"

    Dim c As Customer

    <TestInitialize()> Public Sub Initialize()

        Assert.IsNull(c)

        c = New Customer(NAME, EMAIL1)

        Assert.IsNotNull(c)

    End Sub

    ' called after each test case
    <TestCleanup()> Public Sub CleanUp()

        Assert.IsNotNull(c)

        c = Nothing

        Assert.IsNull(c)

    End Sub

    <TestMethod()> Public Sub ConstructorWithArgsCustomer()
        Assert.AreEqual(c.Name, NAME)
        Assert.AreEqual(c.Email, EMAIL1)
        Assert.AreNotEqual(c.Email, EMAIL2)
    End Sub

    <TestMethod(), ExpectedException(GetType(ArgumentException))> Public Sub CustomerNullName()

        c.Name = ""

    End Sub

    <TestMethod(), ExpectedException(GetType(ArgumentException))> Public Sub CustomerNullEmail()

        c.Email = ""

    End Sub

    <TestMethod()> Public Sub CustomerValidEmail2()

        c.Email = EMAIL2

        Assert.AreEqual(c.Email, EMAIL2)

    End Sub

    <TestMethod(), ExpectedException(GetType(ArgumentException))> Public Sub CustomerInvalidEmail()

        c.Email = "Hello@gmail.com"

    End Sub

    <TestMethod()> Public Sub DefaultConstructorCustomer()

        Dim d As Customer = New Customer()

        Assert.IsNull(d.Name)
        Assert.IsNull(d.Email)

    End Sub

End Class