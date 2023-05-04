Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Notice
Imports Mysqlx.XDevAPI.Common

Public Class members
    Public conn As MySqlConnection = New MySqlConnection
    Public cmd As MySqlCommand = New MySqlCommand

    Public dr As MySqlDataReader
    Public sql, sql2, User As String
    Public dt As DataTable
    Dim tfee As String
    Dim midpayment As String
    Dim result As String
    Dim storemanmeHere As String

    Dim memName As String

    Public Sub connect()

        cmd.CommandText = sql

        cmd.CommandType = CommandType.Text

        cmd.Connection = conn

        conn.Open()
        dr = cmd.ExecuteReader

    End Sub
    Private Sub Populate()
        conn.Open()
        Dim query = "select * from members"
        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(query, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)


        conn.Close()
    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
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
    Dim selectedValue As String
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click


        Dim obj As New MakePayment(selectedValue, tfee, midpayment, memName)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;user id=root;port=3306;password=#001;database=gymm"
        Populate()
    End Sub




    Function GenerateRandomKey2() As String
        Dim chars As String = "0123489"
        Dim rnd As New Random()
        Dim result As New String(Enumerable.Repeat(chars, 4).Select(Function(x) x(rnd.Next(x.Length))).ToArray())


        Return result
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        TextBox4.Text = Format(DateTimePicker1.Value, "yyyy/MM/dd")




        Dim selectedoption As String = ""
        Dim selectedoption2 As String = ""

        If TextBox1.Text = "" Then
            MessageBox.Show("Enter Name")



        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("Please Enter AGE")

        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("Please enter Phone Number")

            ' Check if the entered value is less than 10
        ElseIf Not String.IsNullOrEmpty(TextBox3.Text.Length) AndAlso CInt(TextBox3.Text.Length) < 10 Then
            ' If so, set the text to 10
            MessageBox.Show("I need 10")


            ' Set the selection start to the end of the text to prevent the cursor from jumping to the beginning
            'TextBox3.SelectionStart = TextBox3.Text.Length



        ElseIf RadioButton1.Checked = False And RadioButton2.Checked = False Then

            MessageBox.Show("please select gender")


        Else

            Dim selectedValue As String

            If RadioButton1.Checked Then
                selectedValue = RadioButton1.Text
            ElseIf RadioButton2.Checked Then
                selectedValue = RadioButton2.Text
            Else
                ' Neither radio button is selected
                selectedValue = ""
            End If


            sql = "INSERT into members(
                            memberid,
                            mname,
                            mage,
                            mgender,
                            mphoneno,
                            joiningdate
                            ) 
                    values(
                        '" & GenerateRandomKey2() & "', 
                        '" & TextBox1.Text & "',
                        '" & TextBox2.Text & "',
                        '" & selectedValue & "',
                        '" & TextBox3.Text & "',
                        '" & TextBox4.Text & "'
                    )"

            connect()
            MessageBox.Show("Saved Succesfully")





            conn.Close()
        End If
        Populate()

        conn.Close()
    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub
    Private Sub textbox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Check if the entered character is alphabetic
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If not, suppress the key press event
            e.Handled = True
        End If
    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub


    Private Sub textbox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Check if the entered character is a digit or control character
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If not, suppress the key press event
            e.Handled = True
        End If
    End Sub

    Private Sub textbox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox3.KeyPress
        ' Check if the entered character is a digit or control character
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If not, suppress the key press event
            e.Handled = True
        ElseIf TextBox3.Text.Length > 10 Then
            ' If so, truncate the text to the first 2 characters
            TextBox3.Text = TextBox3.Text.Substring(0, 0)
            ' Set the selection start to the end of the text to prevent the cursor from jumping to the beginning
            TextBox3.SelectionStart = TextBox3.Text.Length

        End If
    End Sub
    Private Sub textbox3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub textbox2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox2.TextChanged
        ' Check if the length of the textbox's text is greater than 2
        If TextBox2.Text.Length > 2 Then
            ' If so, truncate the text to the first 2 characters
            TextBox2.Text = TextBox2.Text.Substring(0, 2)
            ' Set the selection start to the end of the text to prevent the cursor from jumping to the beginning
            TextBox2.SelectionStart = TextBox2.Text.Length
        End If
    End Sub




    Private Sub cCheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
End Class