Imports System.Reflection.Emit
Imports Google.Protobuf.Reflection.FieldDescriptorProto.Types
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Notice
Imports Mysqlx.XDevAPI.Common

Public Class MakePayment


    Public conn As MySqlConnection = New MySqlConnection
    Public cmd As MySqlCommand = New MySqlCommand

    Public dr As MySqlDataReader
    Public sql, sql2, User As String
    Public dt As DataTable
    Dim tfee As String
    Dim midpayment As String
    Dim selectedRadioButton As String
    Dim storemanmeHere As String
    Dim selectedValue As String

    Dim result As String


    Dim memName As String

    Dim store As String


    Public Sub connect()

        cmd.CommandText = sql

        cmd.CommandType = CommandType.Text

        cmd.Connection = conn

        conn.Open()
        dr = cmd.ExecuteReader

    End Sub
    Private Sub members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;user id=root;port=3306;password=#001;database=gymm"

    End Sub




    Public Sub New(selectedValue As String, tfee As String, midpayment As String, memName As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add initialization code here, using the selectedValue parameter as needed
        ' For example, display the selected value in a label
        'Label17.Text = "Selected Package: " & selectedValue
        Label18.Text = selectedValue


        storemanmeHere = memName






        ' Declare integer variables to hold the converted values
        Dim value1 As Integer
        Dim value2 As Integer

        ' Convert the text value of Label13 to an integer
        If Integer.TryParse(tfee, value1) Then
            ' Conversion succeeded, value1 now holds the integer value of Label13
        Else
            ' Conversion failed
        End If


        If Integer.TryParse(selectedValue, value2) Then

        Else

        End If

        ' Add the two integer values together and display the result
        Dim result As Integer = value1 + value2


        Label19.Text = tfee
        Label21.Text = midpayment


        Label20.Text = result






        If (selectedValue < 801) Then
            'Label10.Text = "1 Month"
            packagechooosed = "1 MONTH"
            Label17.Text = "1 Month Package  |" + "800"

        ElseIf (selectedValue >= 801 And selectedValue <= 4800) Then
            'Label10.Text = "6 Month"
            packagechooosed = "6 MONTH"
            Label17.Text = "6 Month Package  |" + "4800"
        ElseIf (selectedValue >= 4800 And selectedValue <= 9600) Then
            ' Label10.Text = "12 Month"
            packagechooosed = "12 MONTH"
            Label17.Text = "12 Month Package |" + "9600"

        End If

    End Sub
    Dim packagechooosed As String

    Public Sub ShowLabel(labelText As String)

        ' Set the text of the label to the passed in text
        Label13.Text = labelText


    End Sub



    Private Sub MakePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Dim obj As New home()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim obj As New members()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim obj As New Trainers()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim obj As New package()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        home.Show()
        Me.Close()

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim obj As New report(selectedValue, Result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Function GenerateRandomKey2() As String
        Dim chars As String = "0123489"
        Dim rnd As New Random()
        Dim result As New String(Enumerable.Repeat(chars, 4).Select(Function(x) x(rnd.Next(x.Length))).ToArray())


        Return result
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        If RadioButton1.Checked Then
            store = "CARD"

        ElseIf RadioButton2.Checked Then
            store = "CASH"

        ElseIf RadioButton3.Checked Then
            store = "UPI"
        ElseIf RadioButton4.Checked Then

            store = "NET BANKING"




        End If


        If Not RadioButton1.Checked And Not RadioButton2.Checked And Not RadioButton3.Checked And Not RadioButton4.Checked Then
            MessageBox.Show("Must Select Payment Method")
        Else


            sql = "INSERT into payment(
                            paymentid,
                            memberid,
                            paymentmethodl,
                            package,
                            totalamount,
                            trainerfee
                            ) 
                    values(
                        '" & GenerateRandomKey2() & "', 
                        '" & Label21.Text & "',
                        '" & store & "',
                        '" & packagechooosed & "',
                        '" & Label20.Text & "',
                        '" & Label19.Text & "'
                    )"

            connect()
            MessageBox.Show("Saved Succesfully")

            Dim tfee As String = Label21.Text
            Dim midpayment As String = Label20.Text
            Dim reportMname As String = storemanmeHere
            Dim obj As New report(selectedRadioButton, tfee, midpayment, storemanmeHere)
            obj.Show()
            'Me.Hide()
            Me.Close()


        End If





        conn.Close()



        conn.Close()
    End Sub
End Class