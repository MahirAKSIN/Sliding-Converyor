Public Class frm_mainForm
    Public ExecutablePath As String = IO.Directory.GetCurrentDirectory() & "\Conveyor.exe"

    'Dim LocalDB As New SQLiteTools("Conveyor")
    Private Sub frm_mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        If frm_Login.lvl = "Supervisor" Then
            btn_manuelAdmin.Visible = True
        Else
            btn_manuelAdmin.Visible = False
        End If
    End Sub

    Private Sub btn_monitor_Click(sender As Object, e As EventArgs) Handles btn_monitor.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_takeHarness Then
                f.Activate()
                f.Show()
                Return
            End If
        Next

        Dim myChild As New frm_takeHarness
        myChild.Show()
    End Sub

    Private Sub btn_conveyorSetup_Click(sender As Object, e As EventArgs) Handles btn_conveyorSetup.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_conveyorSetup Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_conveyorSetup
        myChild.Show()
    End Sub

    Private Sub btn_manuelAdmin_Click(sender As Object, e As EventArgs) Handles btn_manuelAdmin.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_main Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_main
        myChild.Show()
    End Sub

    Private Sub btn_manuel_Click(sender As Object, e As EventArgs) Handles btn_manuel.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_manuel Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_manuel
        myChild.Show()
    End Sub

    Private Sub btn_userSetup_Click(sender As Object, e As EventArgs) Handles btn_userSetup.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_UsertSetup Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_UsertSetup
        myChild.Show()
    End Sub


    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Parameter Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_Parameter
        myChild.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Statistics Then
                f.Activate()
                Return
            End If
        Next

        Dim myChild As New frm_Statistics
        myChild.Show()
    End Sub

    Public Function fff(ByVal s As String) As String
        If CStr(frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & frm_Login.language & ") and (key = '" & s & "') ", "Value")) <> String.Empty Then
            Return frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & frm_Login.language & ") and (key = '" & s & "') ", "Value")
        Else
            Return frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = 0) and (key = '" & s & "') ", "Value")
        End If
    End Function

    Public Sub FindControlRecursive(ByVal parent As Control)

        If parent Is Nothing Then Exit Sub
        If (Not (parent.Tag Is Nothing)) And (parent.Tag <> "") Then
            If frm_Login.LocalDB.isThere("SELECT * FROM CONTROLS WHERE (lng = 0) AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ") Then
                frm_Login.LocalDB.ExecuteNonQuery("INSERT INTO CONTROLS VALUES (0,'" & Me.Name & "','" & parent.Tag.ToString & "','" & parent.Name.ToString & "','" & parent.Text & "')")
            End If
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(child)
        Next

    End Sub

    Public Sub AssignControlRecursive(ByVal parent As Control)

        If parent Is Nothing Then Exit Sub
        If Not parent.Tag Is Nothing Then
            If Not frm_Login.LocalDB.isThere("Select * from CONTROLS Where lng = " & frm_Login.language & " AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ") Then
                parent.Text = frm_Login.LocalDB.GetSingleValue("SELECT * FROM CONTROLS WHERE (lng = " & frm_Login.language & ") AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ", "txt")
            End If
        End If
        For Each child As Control In parent.Controls
            AssignControlRecursive(child)
        Next

    End Sub

End Class