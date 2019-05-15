Imports MySql.Data.MySqlClient
Public Class Form3
    Dim mysqlcon As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim constr As String = "Database=vb;" & _
         "Data Source=localhost;" & _
         "User Id=root;Password="
        mysqlCon = New MySqlConnection(constr)
        Try
                mysqlCon.Open()
                'MessageBox.Show("connection is ok")
            Dim sql As String = "SELECT * FROM student"
                cmd = New MySqlCommand(sql, mysqlCon)
                reader = cmd.ExecuteReader
            'reader.Read()
            'MsgBox((reader.GetString(0) & ", " & reader.GetString(1) & "," & reader.GetString(2)))
            'reader.Close()
        Catch ex As MySqlException
            MsgBox("failed to connect", MsgBoxStyle.Exclamation, ex.Message)
        Finally
            mysqlcon.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        reader.Read()

        MsgBox((reader.GetString(0) & ", " & reader.GetString(1) & "," & reader.GetString(2)))
        reader.Close()
    End Sub

    Private Sub btnf_Click(sender As Object, e As EventArgs) Handles btnf.Click
    End Sub
    Function fa(ByVal x As Integer) As Integer
        Dim result As Integer
        If (x = 1) Then
            Return 1
        Else
            result = fa(x - 1) * x
            Return result
        End If
    End Function

    Sub main()
        fa(7)
        MsgBox(fa(6))
    End Sub
End Class