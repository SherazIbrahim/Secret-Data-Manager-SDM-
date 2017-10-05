Imports System.IO
Public Class Commands

    Public Sub Pack(SDMfile As String, MainPath As String, Password As String)
        Try
            Dim List As New List(Of String)
            Dim List2 As New List(Of String)
            Dim List3 As New List(Of String)
            Dim List4 As New List(Of String)
            List.Add(MainPath)
            List4.Add(MainPath)
            Do
                List2.Clear()
                For Each item In List
                    Dim Dirs() As String = IO.Directory.GetDirectories(item)
                    Dim Files() As String = IO.Directory.GetFiles(item)
                    For Each Di In Dirs
                        List2.Add(Di)
                        List4.Add(Di)
                    Next
                    For Each fil In Files
                        List3.Add(fil)
                    Next
                Next
                List.Clear()
                For Each item In List2
                    Dim Dirs() As String = IO.Directory.GetDirectories(item)
                    Dim Files() As String = IO.Directory.GetFiles(item)
                    For Each Di In Dirs
                        List.Add(Di)
                        List4.Add(Di)
                    Next
                    For Each fil In Files
                        List3.Add(fil)
                    Next
                Next
            Loop While ((List.Count + List2.Count) > 0)
            Dim Path As String = SDMfile
            Dim Stream As New IO.FileStream(Path, IO.FileMode.OpenOrCreate)
            Stream.Position = 0
            Dim Writer As New IO.BinaryWriter(Stream)
            Dim Countofdir As Long = List4.Count
            Writer.Write(Countofdir.ToString)
            For Each item In List4
                Writer.Write(item)
            Next
            Dim Countoffile As Long = List3.Count
            Writer.Write(Countoffile.ToString)
            For Each item In List3
                Dim f As New IO.FileInfo(item)
                Writer.Write(item)
                Dim bytes = IO.File.ReadAllBytes(f.FullName)
                Writer.Write(bytes.Length.ToString)
                Writer.Write(bytes)
                IO.File.Delete(item)
            Next
            Writer.Flush()
            Stream.Dispose()
            Writer.Dispose()
            For i = (List4.Count - 1) To 0 Step -1
                Dim path1 As String = List4(i).ToString
                IO.Directory.Delete(path1)
            Next
            List.Clear()
            List2.Clear()
            List4.Clear()
            List3.Clear()
            Dim Bytes1() As Byte = IO.File.ReadAllBytes(SDMfile)
            Dim encrypted() As Byte = encrypt(Bytes1, Password)
            IO.File.WriteAllBytes(SDMfile, encrypted)
            Dim P As Process = Process.GetCurrentProcess
            P.Kill()
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub
    Public Sub UnPack(SDMfile As String, Password As String)
        Try
            Dim Bytes1() As Byte = IO.File.ReadAllBytes(SDMfile)
            Dim decrypted() As Byte = Decrypt(Bytes1, Password)
            Dim Stream As New IO.FileStream(SDMfile, IO.FileMode.Open)
            Stream.Position = 0
            Dim writer1 As New BinaryWriter(Stream)
            writer1.Write(decrypted)
            writer1.Flush()
            writer1.Dispose()
            Stream.Dispose()
            Dim fStream = New FileStream(SDMfile, IO.FileMode.Open)
            Dim Reader As New IO.BinaryReader(fStream)
            Dim Countdir As Long = Val(Reader.ReadString)
            For i = 0 To Countdir - 1
                Dim Dire As String = Reader.ReadString
                IO.Directory.CreateDirectory(Dire)
            Next
            Dim Countfile As Long = Val(Reader.ReadString)
            For i = 0 To Countfile - 1
                Dim Path As String = Reader.ReadString
                Dim Length As Long = Val(Reader.ReadString)
                Dim Bytes() As Byte = Reader.ReadBytes(Length)
                IO.File.WriteAllBytes(Path, Bytes)
            Next
            Reader.Dispose()
            fStream.Dispose()
            IO.File.Delete(SDMfile)
            Dim filestream As New FileStream(SDMfile, IO.FileMode.OpenOrCreate)
            filestream.Position = 0
            filestream.Flush()
            filestream.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public Shared Function CircularPositionPositive(ByVal Current As Integer, ByVal Max As Integer) As Integer
        Dim value = ((Current / Max) - Math.Truncate(Current / Max)) * Max
        If value < 0 Then
            value = Max + value
        End If
        Return value
    End Function
    Public Shared Function encrypt(ByVal Data As Byte(), ByVal Password As String) As Byte()
        Dim Encrypted(Data.Count - 1) As Byte
        Dim Passpos As Integer
        Dim Passchar As Char
        Dim b As Integer
        Dim a As Integer
        For i = 0 To Data.Count - 1
            Passpos = CircularPositionPositive(i, Password.Count - 1)
            Passchar = Password(Passpos)
            b = Asc(Passchar)
            a = Data(i)
            Encrypted(i) = a Xor b
        Next
        Return Encrypted
    End Function
    Public Shared Function Decrypt(ByVal Data As Byte(), ByVal Password As String) As Byte()
        Dim Encrypted(Data.Count - 1) As Byte
        Dim Passpos As Integer
        Dim Passchar As Char
        Dim b As Integer
        Dim a As Integer
        For i = 0 To Data.Count - 1
            Passpos = CircularPositionPositive(i, Password.Count - 1)
            Passchar = Password(Passpos)
            b = Asc(Passchar)
            a = Data(i)
            Encrypted(i) = a Xor b
        Next
        Return Encrypted
    End Function
End Class
