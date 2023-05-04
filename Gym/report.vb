Public Class report
    Dim result As String
    Dim midpayment As String
    Dim storemanmeHere As String
    Dim tfee As String
    Dim memName As String


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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj As New report(selectedValue, result, midpayment, storemanmeHere)
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub






    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Function GenerateRandomKey2() As String
        Dim chars As String = "0123489"
        Dim rnd As New Random()
        Dim resultreportid As New String(Enumerable.Repeat(chars, 4).Select(Function(x) x(rnd.Next(x.Length))).ToArray())


        Return resultreportid
    End Function
    Public Sub New(selectedValue As String, result As String, midpayment As String, storemanmeHere As String)
        ' This call is required by the designer.
        InitializeComponent()


        Label15.Text = midpayment
        Label13.Text = result
        Label12.Text = GenerateRandomKey2()
        Label14.Text = storemanmeHere



        If String.IsNullOrEmpty(Label15.Text) Then
            Label17.Text = "NOt PAID"

        Else

            Label17.Text = "PAID"
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub report_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        home.Show()
        Me.Close()

    End Sub

    Private Sub GroupBox1_Enter_1(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class