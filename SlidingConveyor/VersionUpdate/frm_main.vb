Imports System.IO
Imports System.Runtime.InteropServices

Public Class frm_main

    Private mArgs() As String

    Dim UpdateLogger As New LogCSV(IO.Directory.GetCurrentDirectory() & "\UpdateLog", "DateTime, File")

    Dim backup As String
    Dim oldVersionAddress
    Dim newVersionAddress As String
    Dim progName As String

    Dim OldVersion As String
    Dim NewVersion As String

    Dim isNew As Boolean = False

    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If System.IO.File.Exists(newVersionAddress & "\" & progName) Then 'Lokasyonda dosya var mı?

        '    OldVersion = FileVersionInfo.GetVersionInfo(oldVersionAddress & "\" & progName).FileVersion
        '    NewVersion = FileVersionInfo.GetVersionInfo(newVersionAddress & "\" & progName).FileVersion

        '    isNew = CompareVersions(OldVersion, NewVersion)

        '    If isNew Then 'Dosyanın versiyonu daha yeni mi?

        '------------------------
        Me.Cursor = Cursors.WaitCursor

        LoadArguments()

        OldVersion = FileVersionInfo.GetVersionInfo(oldVersionAddress & "\" & progName).FileVersion
        NewVersion = FileVersionInfo.GetVersionInfo(newVersionAddress & "\" & progName).FileVersion

        If Not isFileOpen(newVersionAddress & "\" & progName) Then 'Dosya Kullanımda mı? - ana programda da yapmak gerekicek!
            FileProcess()
        Else
            MsgBox(("This Update process can't working. Because another computer is updating. The process will be retried later."))
            btn_Run_Click(sender, e)
        End If
        Me.Cursor = Cursors.Default
        '------------------------

        '    End If

        'End If
    End Sub

    Private Sub btn_Run_Click(sender As Object, e As EventArgs) Handles btn_Run.Click
        Dim myFile As New System.Diagnostics.Process
        With myFile
            .StartInfo.WorkingDirectory = oldVersionAddress & "\"
            .StartInfo.FileName = progName

        End With
        myFile.Start()

        Environment.Exit(0)
    End Sub

    Public Sub FileProcess()

        'Rtxt_Info.Text = "Old Version is Moving to BackUp File..." & vbCrLf
        My.Computer.FileSystem.MoveFile(oldVersionAddress & "\" & progName, backup & "\" & progName, True)

        'Rtxt_Info.Text = "New Version is Taking..." & vbCrLf
        My.Computer.FileSystem.CopyFile(newVersionAddress & "\" & progName, oldVersionAddress & "\" & progName, True)

        UpdateLogger.WriteLog("UPDATED.  Old Version : " & OldVersion & " & New Version : " & NewVersion)

        Rtxt_Info.Text = "Process Completed Succesfully." & vbCrLf
        Rtxt_Info.Text = "New Version of Program is installed." & vbCrLf & "Please click Run button for Open New Version."
        btn_Run.Visible = True

    End Sub

    Private Shared Function IsFileLocked(exception As Exception) As Boolean

        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33

    End Function

    Function isFileOpen(FName As String) As Boolean

        Try
            'CREATE A FILE STREAM FROM THE FILE, OPENING IT FOR READ ONLY EXCLUSIVE ACCESS
            Dim FS As IO.FileStream = IO.File.Open(FName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            'CLOSE AND CLEAN UP RIGHT AWAY, IF THE OPEN SUCCEEDED, WE HAVE OUR ANSWER ALREADY
            FS.Close()
            FS.Dispose()
            FS = Nothing
            Return False
            'Catch ex As IO.IOException
            '    'IF AN IO EXCEPTION IS THROWN, WE COULD NOT GET EXCLUSIVE ACCESS TO THE FILE
            'Return False
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                ' do something here, either close the file if you have a handle, show a msgbox, retry  or as a last resort terminate the process - which could cause corruption and lose data
                Return True
            End If
            Return True
        End Try

    End Function

    Private Function LoadArguments() As String()
        'Throw New NotImplementedException
        mArgs = Environment.GetCommandLineArgs

        If mArgs.Length > 0 Then

            'For Each arg In mArgs
            '    MsgBox(arg.ToString)
            'Next


            backup = mArgs(1)
            oldVersionAddress = mArgs(2)
            newVersionAddress = mArgs(3)
            progName = mArgs(4)
        End If
        LoadArguments = mArgs
    End Function

End Class
