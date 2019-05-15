Imports MySql.Data.MySqlClient
Public Class Form1
    Dim mysqlCon As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim constr As String = "Database=vb;" & _
            "Data Source=localhost;" & _
            "User Id=root;Password="
        mysqlCon = New MySqlConnection(constr)
        Try
            If TextBox1.Text = "" Then
                MsgBox("Firstname is required", MsgBoxStyle.Exclamation, "Warning")
                'Button1.Visible = False
            ElseIf TextBox2.Text = "" Then
                MsgBox("Password required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox1.Text = "" And TextBox1.Text = "" Then
                MsgBox("Firstname or Password required", MsgBoxStyle.Critical, "Warning")
            Else
                Button1.Visible = True
                mysqlCon.Open()
                'MessageBox.Show("connection is ok")
                Dim sql As String = "INSERT INTO student VALUES(NULL ,'" & TextBox1.Text & "','" & TextBox2.Text & "')"
                cmd = New MySqlCommand(sql, mysqlCon)
                reader = cmd.ExecuteReader
                MsgBox("Data inserted succefully", MsgBoxStyle.MsgBoxRtlReading, "Succefull")
                TextBox1.Clear()
                TextBox2.Clear()
                mysqlCon.Close()
            End If

        Catch ex As MySqlException
            MsgBox("failed to connect", MsgBoxStyle.Exclamation, ex.Message)
        Finally
            mysqlCon.Dispose()
        End Try

    End Sub

    Private Sub login(sender As Object, e As EventArgs) Handles Button1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Me.Hide()
        Form2.ShowDialog()
    End Sub

    Private Sub btl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(forms As Object, xxx As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Form3.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button1.Visible = False
        ElseIf TextBox2.Text = "" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

        
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox1.Text = "" Then
            Button1.Visible = False
        ElseIf TextBox2.Text = "" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

    End Sub
End Class
