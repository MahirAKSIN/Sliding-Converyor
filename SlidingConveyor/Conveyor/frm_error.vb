Imports HKE

Public Class frm_error

    Public Logger_Error As New LogFile(IO.Directory.GetCurrentDirectory() & "\LOG_ERROR")

    Private Sub frm_error_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rtxt_error.Text = frm_Login.error_string

        Logger_Error.WriteLog(Rtxt_error.Text)
    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        Dim exePath As String = frm_mainForm.ExecutablePath
        Process.Start(exePath)
        Environment.Exit(0)
    End Sub

End Class