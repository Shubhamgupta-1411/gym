Public Class members
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
        Dim obj As New package()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim obj As New Equipment_inventory()
        obj.Show()
        Me.Hide()
    End Sub
End Class