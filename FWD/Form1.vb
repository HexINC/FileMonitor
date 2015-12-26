Imports System.IO
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.Nodes.Add(New TreeNode("Created"))
        TreeView1.Nodes.Add(New TreeNode("Deleted"))
        TreeView1.Nodes.Add(New TreeNode("Edited"))
        TreeView1.Nodes.Add(New TreeNode("Renamed"))
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fbd.ShowDialog()
        Label1.Text = fbd.SelectedPath
        FSW.Path = Label1.Text
    End Sub

    'FileSystemWatcher Events and other events
    Sub FileCreated(sender As Object, e As System.IO.FileSystemEventArgs) Handles FSW.Created
        TreeView1.Nodes(0).Nodes.Add(e.FullPath)
    End Sub
    Sub FileDeleted(sender As Object, e As System.IO.FileSystemEventArgs) Handles FSW.Deleted
        TreeView1.Nodes(1).Nodes.Add(e.FullPath)
    End Sub
    Sub FileRenamed(sender As Object, e As System.IO.FileSystemEventArgs) Handles FSW.Renamed
        TreeView1.Nodes(3).Nodes.Add(e.FullPath)
    End Sub
    Sub FileEdited(sender As Object, e As System.IO.FileSystemEventArgs) Handles FSW.Changed
        TreeView1.Nodes(2).Nodes.Add(e.FullPath)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Label6.Text = (TreeView1.SelectedNode.Text)
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ''tool strip functions
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        RemoveHandler FSW.Created, AddressOf FileCreated
        RemoveHandler FSW.Deleted, AddressOf FileDeleted
        RemoveHandler FSW.Renamed, AddressOf FileRenamed
        RemoveHandler FSW.Changed, AddressOf FileEdited
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        AddHandler FSW.Created, AddressOf FileCreated
        AddHandler FSW.Deleted, AddressOf FileDeleted
        AddHandler FSW.Renamed, AddressOf FileRenamed
        AddHandler FSW.Changed, AddressOf FileEdited
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Clipboard.SetText(Label6.Text)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim FilePath1 As String = Label6.Text
            Dim NewPath As String = InputBox("Path To Copy File To?")
            File.Copy(FilePath1, NewPath)
            MsgBox("Done")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(New TreeNode("Created"))
        TreeView1.Nodes.Add(New TreeNode("Deleted"))
        TreeView1.Nodes.Add(New TreeNode("Edited"))
        TreeView1.Nodes.Add(New TreeNode("Renamed"))
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

End Class
