Imports System.IO
Public Class Manager
    Public Maindirectory As String = Form1.Maindirectory
    Public SDMfile As String = Form1.Drivepath
    Public Dictionary As New Dictionary(Of String, String)
    Public Openedfolder As String = Maindirectory
    Public Commands As New Commands
    Public Password As String = Form1.Password
    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Columns.Add("Name", 450)
        ListView1.Columns.Add("Type", 450)
        FoldersandFiles(Openedfolder)
    End Sub
    Public Sub FoldersandFiles(Folder As String)
        Try
            ListView1.Items.Clear()
            Dictionary.Clear()
            Dim dirs = IO.Directory.GetDirectories(Folder)
            Dim Files = IO.Directory.GetFiles(Folder)
            For Each Fol In dirs
                Dim dinfo As New DirectoryInfo(Fol)
                Dictionary.Add(dinfo.Name, dinfo.FullName)
                Dim listobject As ListViewItem
                listobject = ListView1.Items.Add(dinfo.Name, ImageList1.Images.Count - 1)
                listobject.SubItems.Add("Folder")
            Next
            For Each file In Files
                Dim finfo As New FileInfo(file)
                Dictionary.Add(finfo.Name, finfo.FullName)
                Dim listobject As ListViewItem
                listobject = ListView1.Items.Add(finfo.Name, ImageList1.Images.Count - 2)
                listobject.SubItems.Add("File")
            Next
            Openedfolder = Folder
        Catch ex As Exception
        MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Delete(Path As String, Type As String)
        Try
            Dim result = MsgBox("Are you sure you want to delete it?", MsgBoxStyle.OkCancel)
            If result = MsgBoxResult.Ok Then
                If Type = "Folder" Then
                    Dim listdir1 As New List(Of String)
                    Dim listdir2 As New List(Of String)
                    Dim Listdirectories As New List(Of String)
                    Dim ListFiles As New List(Of String)
                    listdir1.Add(Path)
                    Listdirectories.Add(Path)
                    Do
                        listdir2.Clear()
                        For Each item In listdir1
                            Dim Dirs() As String = IO.Directory.GetDirectories(item)
                            Dim Files() As String = IO.Directory.GetFiles(item)
                            For Each Di In Dirs
                                listdir2.Add(Di)
                                Listdirectories.Add(Di)
                            Next
                            For Each fil In Files
                                ListFiles.Add(fil)
                            Next
                        Next
                        listdir1.Clear()
                        For Each item In listdir2
                            Dim Dirs() As String = IO.Directory.GetDirectories(item)
                            Dim Files() As String = IO.Directory.GetFiles(item)
                            For Each Di In Dirs
                                listdir1.Add(Di)
                                Listdirectories.Add(Di)
                            Next
                            For Each fil In Files
                                ListFiles.Add(fil)
                            Next
                        Next
                    Loop While (listdir1.Count + listdir2.Count > 0)
                    For Each item In ListFiles
                        IO.File.Delete(item)
                    Next
                    For i = (Listdirectories.Count - 1) To 0 Step -1
                        Dim path1 As String = Listdirectories(i).ToString
                        IO.Directory.Delete(path1)
                    Next
                    ListFiles.Clear()
                    Listdirectories.Clear()
                ElseIf Type = "File" Then
                    IO.File.Delete(Path)
                End If
            End If
            FoldersandFiles(Openedfolder)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Addfile()
        Try
            Dim result = OpenFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                Dim FilePath As String = OpenFileDialog1.FileName
                Dim name As String = My.Computer.FileSystem.GetName(FilePath)
                Dim Target As String = Openedfolder & "\" & name
                IO.File.Move(FilePath, Target)
                FoldersandFiles(Openedfolder)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AddDirectory()
        Try
            Dim result = FolderBrowserDialog1.ShowDialog
            If result = DialogResult.OK Then
                Dim FolderPath As String = FolderBrowserDialog1.SelectedPath
                Dim name As String = My.Computer.FileSystem.GetName(FolderPath)
                Dim Target As String = Openedfolder & "\" & name
                IO.Directory.Move(FolderPath, Target)
                FoldersandFiles(Openedfolder)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub CreateDirectory()
        Try
            Dim Name As String = InputBox("Write the name of new folder!", "Name")
            If Name.Length > 0 Then
                IO.Directory.CreateDirectory(Openedfolder & "\" & Name)
                FoldersandFiles(Openedfolder)
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Use(Path As String, Type As String)
        Try
            If Type = "Folder" Then
                Dim result = FolderBrowserDialog1.ShowDialog
                If result = DialogResult.OK Then
                    Dim folder As String = FolderBrowserDialog1.SelectedPath
                    Dim name As String = My.Computer.FileSystem.GetName(Path)
                    Dim target As String = folder & "\" & name
                    Dim listdir1 As New List(Of String)
                    Dim listdir2 As New List(Of String)
                    Dim Listdirectories As New List(Of String)
                    Dim ListFiles As New List(Of String)
                    listdir1.Add(Path)
                    Listdirectories.Add(Path)
                    Do
                        listdir2.Clear()
                        For Each item In listdir1
                            Dim Dirs() As String = IO.Directory.GetDirectories(item)
                            Dim Files() As String = IO.Directory.GetFiles(item)
                            For Each Di In Dirs
                                listdir2.Add(Di)
                                Listdirectories.Add(Di)
                            Next
                            For Each fil In Files
                                ListFiles.Add(fil)
                            Next
                        Next
                        listdir1.Clear()
                        For Each item In listdir2
                            Dim Dirs() As String = IO.Directory.GetDirectories(item)
                            Dim Files() As String = IO.Directory.GetFiles(item)
                            For Each Di In Dirs
                                listdir1.Add(Di)
                                Listdirectories.Add(Di)
                            Next
                            For Each fil In Files
                                ListFiles.Add(fil)
                            Next
                        Next
                    Loop While (listdir1.Count + listdir2.Count > 0)
                    Dim LengthTominus As Integer = SetTarget(Path)
                    For i = (Listdirectories.Count - 1) To 0 Step -1
                        Dim FolderPath As String = Listdirectories(i)
                        Dim more As String = FolderPath.Remove(0, LengthTominus)
                        Dim TargetPath As String = folder & "\" & more
                        IO.Directory.CreateDirectory(TargetPath)
                    Next
                    For Each Fil In ListFiles
                        Dim FilePath As String = Fil
                        Dim more As String = FilePath.Remove(0, LengthTominus)
                        Dim TargetPath As String = folder & "\" & more
                        IO.File.Copy(FilePath, TargetPath)
                    Next
                    ListFiles.Clear()
                    Listdirectories.Clear()
                    MsgBox("This folder has been saved on this path ( " & target & ") And remember after using this folder delete it from there otherwise anyone can use it from on there")
                End If
            ElseIf Type = "File" Then
                Dim result = FolderBrowserDialog1.ShowDialog
                If result = DialogResult.OK Then
                    Dim folder As String = FolderBrowserDialog1.SelectedPath
                    Dim name As String = My.Computer.FileSystem.GetName(Path)
                    Dim target As String = folder & "\" & name
                    IO.File.Copy(Path, target)
                    MsgBox("This file has been saved on this path ( " & target & ") And remember after using this file delete it from there otherwise anyone can use it from on that path")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function SetTarget(Fol As String) As Integer
        Dim Name As String = My.Computer.FileSystem.GetName(Fol)
        Dim TotalLength As Integer = Fol.Length
        Dim Lengthsub As Integer = Name.Length
        Dim LengthtoMinus As Integer = TotalLength - Lengthsub
        Return LengthtoMinus
    End Function
    Private Sub OpenToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem2.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim Name As String = ListView1.SelectedItems.Item(0).Text
                Dim Type As String = ListView1.SelectedItems.Item(0).SubItems(1).Text
                If Type = "Folder" Then
                    Dim Folder As String = Dictionary(Name)
                    FoldersandFiles(Folder)
                Else
                End If
            Else
                MsgBox("Select a folder!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim name As String = ListView1.SelectedItems(0).Text
                Dim Type As String = ListView1.SelectedItems(0).SubItems(1).Text
                Dim Path As String = Dictionary(name)
                Delete(Path, Type)
            Else
                MsgBox("Please select a file or folder!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFileToolStripMenuItem.Click
        Try
            Addfile()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddDirectoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddDirectoryToolStripMenuItem1.Click
        Try
            AddDirectory()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateDirectoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CreateDirectoryToolStripMenuItem1.Click
        Try
            CreateDirectory()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseToolStripMenuItem.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim name As String = ListView1.SelectedItems().Item(0).Text
                Dim Type As String = ListView1.SelectedItems().Item(0).SubItems(1).Text
                Dim Path As String = Dictionary(name)
                Use(Path, Type)
            Else
                MsgBox("Please select a file or folder!")
            End If
        Catch ex As Exception
            msgbox(ex.message)
        End Try
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Try
            FoldersandFiles(Maindirectory)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem2.Click
        Try
            Commands.Pack(SDMfile, Maindirectory, Password)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Back()
        Try
            Dim Txt As String = Openedfolder
            Dim txtl() As String = Txt.Split("\")
            Dim newtxt As String = txtl(0)
            For i = 1 To txtl.Count - 2
                newtxt = newtxt & "\" & txtl(i)
            Next
            Openedfolder = newtxt
            If Openedfolder.Contains(Maindirectory) Then
                FoldersandFiles(Openedfolder)
            Else
                FoldersandFiles(Maindirectory)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        Try
            Back()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class