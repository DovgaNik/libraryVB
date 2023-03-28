Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub InShaAllahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InShaAllahToolStripMenuItem.Click
        FormHelp.Show()
    End Sub

    Private Sub AddANewBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddANewBookToolStripMenuItem.Click
        'Dim bookName As String
        'bookName = InputBox("Plese, enter the name of the book you want to add: ", "New book").Trim
        'If bookName <> Nothing Then
        '    CheckedListBox.Items.Add(bookName)
        'Else
        '    MessageBox.Show("You did not enter a correct value!!!")
        'End If

    End Sub

    Private Sub RemoveABookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveABookToolStripMenuItem.Click
        'Dim selIndex As Integer
        'selIndex = CheckedListBox.SelectedIndex

        'If selIndex <> -1 Then
        '    CheckedListBox.Items.RemoveAt(selIndex)
        'Else
        '    MessageBox.Show("You've selected nothing!!!")
        'End If
    End Sub

    Private Sub CreateANewDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateANewDatabaseToolStripMenuItem.Click
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("BookID", "BookID")
        DataGridView1.Columns.Add("Name", "Name")
        DataGridView1.Columns.Add("Author", "Author")
        DataGridView1.Columns.Add("Is Borrowed", "Is borrowed")
        DataGridView1.Columns.Add("Borrow date", "Borrow date")
        DataGridView1.Columns.Add("Return date", "Return date")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim fileName
        Dim opDg As New OpenFileDialog

        opDg.Filter = "text files|*.txt|documents|*.doc;*.docx;*.pdf|all files|*.*"
        opDg.FilterIndex = 1
        opDg.DefaultExt = ".txt"
        opDg.AddExtension = True
        opDg.InitialDirectory = "D:\"

        If opDg.ShowDialog() = DialogResult.OK Then
            fileName = opDg.FileName
            MessageBox.Show(fileName)
        Else
            MessageBox.Show("No")
        End If
    End Sub
End Class
