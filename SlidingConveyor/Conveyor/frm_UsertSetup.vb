Public Class frm_UsertSetup


    'Dim LocalDB As New SQLiteTools("Conveyor")

    Private Sub frm_UsertSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        Me.Text += " " & String.Format(" {0}", My.Application.Info.Version.ToString)

        btn_Insert_User.Enabled = False
        btn_Update_User.Enabled = False

        If Not frm_Login.LocalDB.isThere("SELECT * FROM LOGIN WHERE level <> 'Supervisor' ") Then
            grd_Data_Users.DataSource = frm_Login.LocalDB.PopulateGrid("SELECT * FROM LOGIN WHERE level <> 'Supervisor' ")
            grd_Data_Users.Rows(0).Selected = False
        End If


        If (cmb_selectLevel.Items.Count = 0) Then
            cmb_selectLevel.Items.Add(("Selection"))
            'cmb_selectLevel.Items.Add("Supervisor")
            cmb_selectLevel.Items.Add("Mechanic")
            cmb_selectLevel.Items.Add("Operator")
            cmb_selectLevel.SelectedIndex = 0
        End If

    End Sub

    Private Sub btn_New_User_Click(sender As Object, e As EventArgs) Handles btn_New_User.Click
        txt_Username.Text = String.Empty
        txt_Password.Text = String.Empty
        txt_Username.Enabled = True
        txt_Password.Enabled = True
        cmb_selectLevel.Enabled = True
        btn_Insert_User.Enabled = True
        btn_Edit_User.Enabled = False
        btn_Update_User.Enabled = False
        btn_Delete_User.Enabled = False
        btn_New_User.Enabled = False

        cmb_selectLevel.SelectedIndex = 0
        txt_Username.Focus()
    End Sub

    Private Sub btn_Edit_User_Click(sender As Object, e As EventArgs) Handles btn_Edit_User.Click
        If txt_Username.Text <> String.Empty Then
            txt_Password.Enabled = True
            cmb_selectLevel.Enabled = True
            btn_Delete_User.Enabled = False
            btn_Insert_User.Enabled = False
            btn_New_User.Enabled = False
            btn_Edit_User.Enabled = False
            btn_Update_User.Enabled = True
            cmb_selectLevel.Enabled = False
        Else
            MsgBox(fff("If you want to edit a user s password, please select one of them."), MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btn_Update_User_Click(sender As Object, e As EventArgs) Handles btn_Update_User.Click
        If txt_Username.Text <> String.Empty Then
            If txt_Password.Text <> String.Empty Then
                If cmb_selectLevel.SelectedIndex <> 0 Then
                    If (frm_Login.LocalDB.isThere("SELECT * FROM LOGIN WHERE password='" & txt_Password.Text.ToString & "'")) Then

                        Dim lvl = cmb_selectLevel.SelectedItem.ToString()
                        frm_Login.LocalDB.ExecuteNonQuery("UPDATE LOGIN SET password = '" & txt_Password.Text.ToString & "' , level = '" & lvl & "' WHERE username = '" & txt_Username.Text.ToString & "' ")
                        grd_Data_Users.DataSource = frm_Login.LocalDB.PopulateGrid("SELECT * FROM LOGIN ")

                        MsgBox(txt_Username.Text & " " & fff("is Updated") & " !")

                        txt_Password.Enabled = False
                        btn_Delete_User.Enabled = True
                        btn_Insert_User.Enabled = False
                        btn_New_User.Enabled = True
                        btn_Edit_User.Enabled = True
                        cmb_selectLevel.Enabled = False
                        btn_Update_User.Enabled = False

                        txt_Username.Text = String.Empty
                        txt_Password.Text = String.Empty
                        cmb_selectLevel.SelectedIndex = 0


                    Else
                        MsgBox(fff("The Password is already being used by another person.") & vbCrLf & fff("Please try another password for this user."), MsgBoxStyle.OkOnly)
                        txt_Password.Focus()
                    End If
                Else
                    MsgBox(fff("You must select a LEVEL for this user") & " !")
                    cmb_selectLevel.Focus()
                End If
            Else
                MsgBox(fff("You must Enter a PASSWORD") & " !")
                txt_Password.Focus()
            End If
        Else
            MsgBox(fff("You must Enter a USER NAME"), " !")
            txt_Username.Focus()
        End If
    End Sub

    Private Sub btn_Insert_User_Click(sender As Object, e As EventArgs) Handles btn_Insert_User.Click
        If txt_Username.Text <> String.Empty Then
            If txt_Password.Text <> String.Empty Then
                If cmb_selectLevel.SelectedIndex <> 0 Then
                    If (frm_Login.LocalDB.isThere("SELECT * FROM LOGIN WHERE username ='" & txt_Username.Text.ToString & "' ")) Then
                        If (frm_Login.LocalDB.isThere("SELECT * FROM LOGIN WHERE password='" & txt_Password.Text.ToString & "'")) Then

                            frm_Login.LocalDB.ExecuteNonQuery("INSERT INTO LOGIN VALUES ( '" & txt_Username.Text.ToString & "','" & txt_Password.Text.ToString & "','" & cmb_selectLevel.SelectedItem.ToString() & "') ")
                            grd_Data_Users.DataSource = frm_Login.LocalDB.PopulateGrid("SELECT * FROM LOGIN ")

                            MsgBox(txt_Username.Text & " " & fff("is Created") & " !")

                            txt_Password.Enabled = False
                            txt_Username.Enabled = False
                            btn_New_User.Enabled = True
                            btn_Edit_User.Enabled = True
                            btn_Update_User.Enabled = True
                            btn_Delete_User.Enabled = True
                            btn_Insert_User.Enabled = False
                            cmb_selectLevel.Enabled = False

                            txt_Username.Text = String.Empty
                            txt_Password.Text = String.Empty
                            cmb_selectLevel.SelectedIndex = 0

                        Else
                            MsgBox(fff("The Password is already using by another user."), MsgBoxStyle.OkOnly)
                            txt_Username.Focus()
                        End If
                    Else
                        MsgBox(fff("The User name is already using by another user."), MsgBoxStyle.OkOnly)
                        txt_Username.Focus()
                    End If
                Else
                    MsgBox(fff("You must select a LEVEL for this user") & " !")
                    cmb_selectLevel.Focus()
                End If
            Else
                MsgBox(fff("You must Enter a PASSWORD") & " !")
                txt_Password.Focus()
            End If
        Else
            MsgBox(fff("You must Enter a USER NAME") & " !")
            txt_Username.Focus()
        End If
    End Sub

    Private Sub btn_Delete_User_Click(sender As Object, e As EventArgs) Handles btn_Delete_User.Click
        If (txt_Username.Text <> String.Empty) Then

            If MsgBox(fff("The user") & " : " & txt_Username.Text & " " & fff("will be deleted. Are you sure?"), MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then

                frm_Login.LocalDB.ExecuteNonQuery("DELETE FROM LOGIN WHERE ( username='" & txt_Username.Text.ToString & "') AND (password='" & txt_Password.Text.ToString & "' ) ")

                MsgBox(txt_Username.Text & " " & fff("is deleted."))

                grd_Data_Users.DataSource = frm_Login.LocalDB.PopulateGrid("SELECT * FROM LOGIN ")

                txt_Username.Text = ""
                txt_Password.Text = ""
                cmb_selectLevel.SelectedIndex = 0

                btn_Insert_User.Enabled = False
            End If
        Else
            MsgBox(fff("If you want to delete a user, please select one of them."), MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub grd_Data_Users_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_Data_Users.CellClick
        txt_Username.Text = grd_Data_Users.Item("username", grd_Data_Users.CurrentRow.Index).Value.ToString()
        txt_Password.Text = grd_Data_Users.Item("password", grd_Data_Users.CurrentRow.Index).Value.ToString()
        cmb_selectLevel.SelectedItem = grd_Data_Users.Item("level", grd_Data_Users.CurrentRow.Index).Value.ToString()
    End Sub

    Private Sub btn_Exit_UserSetup_Click(sender As Object, e As EventArgs) Handles btn_Exit_UserSetup.Click
        If MsgBox(fff("Screen of User Setup is closing. Are you Sure?"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frm_mainForm.Show()
            Me.Close()
        End If
    End Sub

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

    Public Function fff(ByVal s As String) As String
        If CStr(frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & frm_Login.language & ") and (key = '" & s & "') ", "Value")) <> String.Empty Then
            Return frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & frm_Login.language & ") and (key = '" & s & "') ", "Value")
        Else
            Return frm_Login.LocalDB.GetSingleValue("select * from MESSAGES where (lng = 0) and (key = '" & s & "') ", "Value")
        End If
    End Function

End Class