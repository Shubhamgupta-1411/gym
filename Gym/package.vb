Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.Notice
Imports Mysqlx.XDevAPI.Common


Public Class package
    Dim trainerfee As String
    Dim result As String
    Dim midpayment As String
    Dim tfee As String
    Dim storemanmeHere As String


    Public conn As MySqlConnection = New MySqlConnection
    Public cmd As MySqlCommand = New MySqlCommand

    Public dr As MySqlDataReader
    Public sql, sql2, User As String
    Public dt As DataTable


    Public Sub connect()

        cmd.CommandText = sql

        cmd.CommandType = CommandType.Text

        cmd.Connection = conn

        conn.Open()
        dr = cmd.ExecuteReader

    End Sub


    Private Sub Populate()
        conn.Open()
        Dim query = "select * from trainer"
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

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        ' Perform the desired action when the text box is clicked


        Dim searchTerm As String = TextBox1.Text

        sql = "SELECT * FROM members WHERE mname LIKE '%" & searchTerm & "%'"
        'sql = "SELECT * FROM Products WHERE productid=" & searchTerm & ""



        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(sql, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()




    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            'Dim selectedCell As DataGridViewCell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim selectedRow As DataGridViewRow = DataGridView2.Rows(e.RowIndex)


            Dim selectedItem As String = selectedRow.Cells.ToString()
            Label21.Text = selectedRow.Cells(1).Value.ToString()
            Label23.Text = selectedRow.Cells(0).Value.ToString()


            Dim midpayment As String = Label23.Text
            Dim memName As String = Label21.Text


            Dim paymentScreen As New MakePayment(selectedValue, tfee, midpayment, memName)

        End If
    End Sub




    Private Sub members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;user id=root;port=3306;password=#001;database=gymm"
        Populate()
    End Sub

    Dim selectedRadioButton As String

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
        'Dim obj As New package()
        ' obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim tfee As String = Label25.Text
        Dim midpayment As String = Label13.Text
        Dim memName As String = Label21.Text
        Dim obj As New MakePayment(selectedRadioButton, tfee, midpayment, memName)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)
        'Dim obj As New report(selectedValue, Result, midpayment)
        ' obj.Show()
        Me.Hide()
    End Sub
    Dim selectedValue As String
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub



    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            selectedRadioButton = 1 * 800

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            selectedRadioButton = 6 * 800
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            selectedRadioButton = 12 * 800
        End If
    End Sub


    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            'Dim selectedCell As DataGridViewCell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)


            Dim selectedItem As String = selectedRow.Cells.ToString()
            Label13.Text = selectedRow.Cells(0).Value.ToString()
            Label14.Text = selectedRow.Cells(1).Value.ToString()
            Label16.Text = selectedRow.Cells(2).Value.ToString()
            Label25.Text = selectedRow.Cells(3).Value.ToString()

            Dim tfee As String = Label25.Text
            Dim midpayment As String = Label23.Text

            Dim memName As String = Label21.Text
            ' Navigate to the payment screen and pass the text for the new label
            Dim paymentScreen As New MakePayment(selectedValue, tfee, midpayment, memName)
            'paymentScreen.ShowLabel(Label25.Text)
            'Label14.Text = selectedItem
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If String.IsNullOrEmpty(Label21.Text) Or String.IsNullOrEmpty(Label23.Text) Then
            ' Show message box with the message "hii"
            MessageBox.Show(" Please Select Members")
        Else
            Dim tfee As String = Label25.Text
            Dim midpayment As String = Label23.Text
            Dim memName As String = Label21.Text
            Dim obj As New MakePayment(selectedRadioButton, tfee, midpayment, memName)
            'Dim obj As New MakePayment()
            obj.Show()
            Me.Hide()
        End If
    End Sub


    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim searchTerm As String = TextBox1.Text.Trim()

        sql = "SELECT * FROM members WHERE mname LIKE '%" & searchTerm & "%'"



        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(sql, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim()

        sql = "SELECT * FROM members WHERE mname LIKE '%" & searchTerm & "%'"



        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(sql, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class