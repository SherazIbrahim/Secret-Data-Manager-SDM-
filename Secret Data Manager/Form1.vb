Imports System.IO
Public Class Form1
    Public Commands As New Commands
    Public Drivepath As String = ""
    Public MainDir As String = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
    Public Namef As String = ""
    Public Folder As String = ""
    Public Maindirectory As String = ""
    Public Password As String = "Password"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim result = FolderBrowserDialog1.ShowDialog
            If result = DialogResult.OK Then
                TextBox1.Text = FolderBrowserDialog1.SelectedPath
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            TextBox2.Text = "Secret"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text.Length > 0 AndAlso TextBox2.Text.Length > 0 AndAlso TextBox3.Text.Length > 0 Then
                If TextBox3.Text = Password Then
                    Namef = TextBox2.Text
                    Folder = TextBox1.Text
                    Drivepath = Folder & "\" & Namef & ".SDM"
                    If IO.File.Exists(Drivepath) Then
                        Commands.UnPack(Drivepath, Password)
                        Maindirectory = MainDir & "\" & Namef
                        Me.Hide()
                        Manager.Show()
                    Else
                        Dim filestream As New IO.FileStream(Drivepath, IO.FileMode.OpenOrCreate)
                        filestream.Flush()
                        filestream.Dispose()
                        Maindirectory = MainDir & "\" & Namef
                        Directory.CreateDirectory(Maindirectory)
                        Me.Hide()
                        Manager.Show()
                    End If
                Else
                    Dim Result = MsgBox("Wrong Password", MsgBoxStyle.OkOnly)
                    If Result = MsgBoxResult.Ok Then
                        Dim p As Process = Process.GetCurrentProcess
                        p.Kill()
                    End If
                End If
            Else
                MsgBox("Please select a SDM file")
        End If
        Catch ex As Exception
        Dim result = MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        If result = MsgBoxResult.Ok Then
            Dim p As Process = Process.GetCurrentProcess
            p.Kill()
        End If
        End Try
    End Sub
End Class
