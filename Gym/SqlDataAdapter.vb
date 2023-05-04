Imports MySql.Data.MySqlClient

Friend Class SqlDataAdapter
    Private v As String
    Private conn As MySqlConnection

    Public Sub New(v As String, conn As MySqlConnection)
        Me.v = v
        Me.conn = conn
    End Sub
End Class
