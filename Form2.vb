Imports MySql.Data.MySqlClient
Public Class Form2
    Dim mysqlCon As MySqlConnection
    Dim cmd As MySqlCommand
    Dim adpt As MySqlDataAdapter
    Dim table As New DataTable
    Dim bind As New BindingSource
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim constr As String = "Database=vb;" & _
           "Data Source=localhost;" & _
           "User Id=root;Password="
        mysqlCon = New MySqlConnection(constr)
        Try
            If TextBox1.Text = "" Then
                MsgBox("firstname is required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox2.Text = "" Then
                MsgBox("Lastname required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox3.Text = "" Then
                MsgBox("middlename required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox5.Text = "" Then
                MsgBox("Gender required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox6.Text = "" Then
                MsgBox("Collage required", MsgBoxStyle.Exclamation, "Warning")
            ElseIf TextBox7.Text = "" Then
                MsgBox("Course required", MsgBoxStyle.Exclamation, "Warning")
            Else
                mysqlCon.Open()
                'MessageBox.Show("connection is ok")
                Dim sql As String = "INSERT INTO register VALUES(NULL ,'" & TextBox1.Text & "','" & TextBox2.Text & _
                    "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                cmd = New MySqlCommand(sql, mysqlCon)
                cmd.ExecuteNonQuery()

                MsgBox("Data Saved", MsgBoxStyle.Information, "Succefull")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                mysqlCon.Close()
                TextBox7.Clear()
            End If
           
        Catch ex As MySqlException
            MsgBox("failed to connect", MsgBoxStyle.Exclamation, ex.Message)
        Finally
            mysqlCon.Dispose()
        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Me.Show()

    End Sub

    Private Sub ToolStripContainer1_ContentPanel_Load(sender As Object, e As EventArgs)
        Me.Show()
    End Sub

    Private Sub ToolStripContainer1_BottomToolStripPanel_Click(sender As Object, e As EventArgs)
        Me.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim adpt As MySqlDataAdapter
        Dim table As New DataTable
        Dim bind As New BindingSource
        Try
            mysqlCon.Open()
            Dim quey As String = "SELECT * FROM register"
            cmd = New MySqlCommand(quey, mysqlCon)
            adpt.SelectCommand = cmd
            adpt.Fill(table)
            bind.DataSource = table
            DataGridView1.DataSource = adpt
            adpt.Update(table)
            cmd.ExecuteNonQuery()
            mysqlCon.Close()


        Catch ex As MySqlException
            MsgBox("Error", MsgBoxStyle.Critical, "Error")
        Finally
            mysqlCon.Dispose()
        End Try
    End Sub
End Class