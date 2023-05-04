Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common

Public Class home
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
    Dim selectedValue As String
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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

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

    Private Sub Populate2()
        conn.Open()
        Dim query = "select * from trainer"
        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(query, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)


        conn.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim searchTerm As String = TextBox4.Text.Trim()

        sql = "SELECT * FROM trainer WHERE trainername LIKE '%" & searchTerm & "%'"



        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter(sql, conn)
        Dim builder As MySqlCommandBuilder
        builder = New MySqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        conn.Close()

    End Sub
    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

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
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub




    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;user id=root;port=3306;password=#001;database=gymm"
        Populate()
        Populate2()
        Dim borrowernum As Integer
        conn.Open()
        Dim sql = "select COUNT(memberid) from members"
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand(sql, conn)
        borrowernum = cmd.ExecuteScalar
        borrowerlbl.Text = borrowernum
        conn.Close()






        Dim loannum As Integer
        conn.Open()
        sql = "select COUNT(trainerid) from trainer"

        cmd = New MySqlCommand(sql, conn)
        loannum = cmd.ExecuteScalar
        Label12.Text = loannum
        conn.Close()




    End Sub
End Class