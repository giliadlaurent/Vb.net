
Public Class home



    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.Nodes.Clear()
        'Creating the root node 
        Dim root = New TreeNode("Application")
        TreeView1.Nodes.Add(root)
        TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 1"))
        'Creating child nodes under the first child 
        For loopindex As Integer = 1 To 4
            TreeView1.Nodes(0).Nodes(0).Nodes.Add(New  _
                TreeNode("Sub Project" & Str(loopindex)))
        Next loopindex
        ' creating child nodes under the root 
        TreeView1.Nodes(0).Nodes.Add(New TreeNode("Project 6"))
        'creating child nodes under the created child node 
        For loopindex As Integer = 1 To 3
            TreeView1.Nodes(0).Nodes(1).Nodes.Add(New  _
             TreeNode("Project File" & Str(loopindex)))
        Next loopindex
        ' Set the caption bar text of the form.   
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox1.SelectedValueChanged
        Label1.Text = ComboBox1.SelectedItem
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("CIVE")
        ComboBox1.Items.Add("COED")
        ComboBox1.Items.Add("HUMT")
        ComboBox1.Items.Add("COES")
        ComboBox1.Items.Add("CMD")
        ComboBox1.Items.Add("BGH")
        ComboBox1.Items.Add("MND")
        ComboBox1.Items.Add("KLO")
        ComboBox1.Items.Add("OEDS")
        ComboBox1.Items.Add("BDS")
        ComboBox1.Items.Add("TEWC")
        ComboBox1.Items.Add("OEW")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Sorted = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Items.Clear()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect


        Me.Text = "rinchuboy"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
       
        Try
            OpenFileDialog1.ShowDialog()
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
     Then
            My.Computer.FileSystem.WriteAllText _
            (SaveFileDialog1.FileName, RichTextBox1.Text, True)
        End If
    End Sub

    Function factorial(ByVal x As Double) As Double
        Dim result As Double
        If (x = 1) Then
            Return 1
        Else
            Try
                result = factorial(x - 1) * x
            Catch ex As Exception
                MsgBox("error ocured", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        Return result
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim input As Integer
            input = TextBox1.Text
            RichTextBox1.Text = factorial(input)
            TextBox1.Clear()
        Catch ex As Exception
            MsgBox("Error with your input", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class