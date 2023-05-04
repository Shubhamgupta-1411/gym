Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Reportf





    Public conn As MySqlConnection = New MySqlConnection
    Public cmd As MySqlCommand = New MySqlCommand

    Public dr As MySqlDataReader
    Public sql, sql2, User As String
    Public dt As DataTable
    Dim result As String
    Dim midpayment As String
    Dim selectedValue As String
    Dim selectedRadioButton As String
    Dim tfee As String
    Dim memName As String
    Dim storemanmeHere As String


    Public Sub connect()

        cmd.CommandText = sql

        cmd.CommandType = CommandType.Text

        cmd.Connection = conn

        conn.Open()
        dr = cmd.ExecuteReader

    End Sub

    Private Sub members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;user id=root;port=3306;password=#001;database=gymm"
        Populate()
    End Sub


    Function GenerateRandomKey2() As String
        Dim chars As String = "0123456789"
        Dim rnd As New Random()
        Dim result As New String(Enumerable.Repeat(chars, 4).Select(Function(x) x(rnd.Next(x.Length))).ToArray())


        Return result
    End Function
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

            'Dim selectedCell As DataGridViewCell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)


            Dim selectedItem As String = selectedRow.Cells.ToString()
            Label18.Text = selectedRow.Cells(0).Value.ToString()


            Dim reportValue As String
            reportValue = Label18.Text


            Label19.Text = selectedRow.Cells(1).Value.ToString()

        End If
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
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()




    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

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


    Public Sub New(selectedValue As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add initialization code here, using the selectedValue parameter as needed
        ' For example, display the selected value in a label
        Label9.Text = "Selected Package: " & selectedValue
        Label16.Text = selectedValue
        If (selectedValue < 801) Then
            Label10.Text = "1 Month"
            Label17.Text = "1 Month"

        ElseIf (selectedValue >= 801 And selectedValue <= 4800) Then
            Label10.Text = "6 Month"
            Label17.Text = "6 Month"
        ElseIf (selectedValue >= 4800 And selectedValue <= 9600) Then
            Label10.Text = "12 Month"
            Label17.Text = "12 Month"

        End If

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

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click


        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Application.Exit()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        sql = "INSERT into payment(
                            paymentid,
                            custname,
                            custid,
                            selectedpackage,
                            totalprice
                            
                            ) 
                    values(
                        '" & GenerateRandomKey2() & "', 
                        '" & Label19.Text & "',
                        '" & Label18.Text & "',
                        '" & Label16.Text & "',
                        '" & Label17.Text & "'
                        
                    )"

        connect()
        Dim obj As New MakePayment(selectedRadioButton, tfee, midpayment, memName)
        'Dim obj As New MakePayment()
        obj.Show()
        Me.Close()

        conn.Close()
        Populate()

        conn.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

End Class