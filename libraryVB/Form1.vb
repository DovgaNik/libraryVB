Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public Function UnixToDateTime(ByVal strUnixTime As String) As DateTime

        Dim nTimestamp As Double = strUnixTime
        Dim nDateTime As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
        nDateTime = nDateTime.AddSeconds(nTimestamp)

        Return nDateTime

    End Function

    Function clearDB()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("BookID", "BookID")
        DataGridView1.Columns.Add("Name", "Name")
        DataGridView1.Columns.Add("Author", "Author")
        DataGridView1.Columns.Add("Is Borrowed", "Is borrowed")
        DataGridView1.Columns.Add("Borrow date", "Borrow date")
        DataGridView1.Columns.Add("Return date", "Return date")
    End Function

    Private Sub InShaAllahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InShaAllahToolStripMenuItem.Click
        FormHelp.Show()
    End Sub

    Private Sub AddANewBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddANewBookToolStripMenuItem.Click
        Dim bookname As String = InputBox("Plese, enter the name of the book you want to add: ", "New book").Trim()
        Dim authorname As String = InputBox("Plese, enter the name of the auther of the book you want to add: ", "New book").Trim()

        If bookname <> Nothing And authorname <> Nothing Then
            DataGridView1.Rows.Add(DataGridView1.Rows.Count - 1, bookname, authorname, 0, "N/A", "N/A")
        Else
            MessageBox.Show("You did not enter a correct value!!!")
        End If

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
        clearDB()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim fileName As String
        Dim opDg As New OpenFileDialog

        opDg.Filter = "Book database file|*.bookdb|All files|*.*"
        opDg.FilterIndex = 1
        opDg.DefaultExt = ".bookdb"
        opDg.AddExtension = True

        If opDg.ShowDialog() = DialogResult.OK Then
            fileName = opDg.FileName
        Else
            Exit Sub
        End If

        If File.Exists(fileName) Then

            clearDB()
            Dim objReader As New StreamReader(fileName)
            Dim ID As Integer
            ID = 0
            Do While objReader.Peek() <> -1

                Dim objects As String()
                objects = objReader.ReadLine().Split("|".ToCharArray)
                If objects.Count = 5 Then
                    DataGridView1.Rows.Add(ID, objects(0), objects(1), objects(2), UnixToDateTime(objects(3)), UnixToDateTime(objects(4)))
                End If
                ID += 1
            Loop


        Else
            MessageBox.Show("File " + fileName + " does not exist, plese check again!!!")
        End If

    End Sub
End Class
