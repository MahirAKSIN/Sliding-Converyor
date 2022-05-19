Public Class frm_conveyorSetup

    'Dim LocalDB As New SQLiteTools("Conveyor")

    Private Sub frm_conveyorSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        Me.Text += " " & String.Format(" {0}", My.Application.Info.Version.ToString)

        If Not frm_Login.LocalDB.isThere("Select * from PRODUCTION") Then
            grd_production.DataSource = frm_Login.LocalDB.PopulateGrid("Select * from PRODUCTION order by Process_Date")
            grd_production.Refresh()
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        If (txt_harness.Text <> String.Empty) And (txt_quantity.Text <> String.Empty) And (txt_ProcessTime.Text <> String.Empty) And (txt_critical.Text <> String.Empty) Then

            txt_harness.Text = txt_harness.Text.Replace(vbCrLf, "")

            If frm_Login.LocalDB.isThere("Select * from PRODUCTION where Definition = '" & txt_harness.Text & "' ") Then

                frm_Login.LocalDB.ExecuteNonQuery("INSERT INTO PRODUCTION VALUES ( '" & txt_harness.Text & "', " & txt_ProcessTime.Text & ", " & txt_quantity.Text & ", " & txt_critical.Text & ", date('now')  )")
                MsgBox(fff("Inserted."))

                CLEAR()

            Else
                MsgBox(fff("System has this harness values. If you want to change, Please UPDATE it."))
                txt_harness.Text = String.Empty
            End If
        Else
            MsgBox(fff("You must fill all areas."))
        End If
    End Sub

    Private Sub grd_production_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_production.CellClick

        txt_harness.Text = grd_production.Item("Definition", grd_production.CurrentRow.Index).Value.ToString()
        txt_quantity.Text = grd_production.Item("QUANTITY", grd_production.CurrentRow.Index).Value.ToString()
        txt_ProcessTime.Text = grd_production.Item("Process_Time", grd_production.CurrentRow.Index).Value.ToString()
        txt_critical.Text = grd_production.Item("Critical", grd_production.CurrentRow.Index).Value.ToString()

    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If (txt_harness.Text <> String.Empty) And (txt_quantity.Text <> String.Empty) And (txt_ProcessTime.Text <> String.Empty) And (txt_critical.Text <> String.Empty) Then

            txt_harness.Text = txt_harness.Text.Replace(vbCrLf, "")

            If Not frm_Login.LocalDB.isThere("Select * from PRODUCTION where Definition = '" & txt_harness.Text & "' ") Then
                frm_Login.LocalDB.ExecuteNonQuery("UPDATE PRODUCTION SET Process_Time = " & txt_ProcessTime.Text & ", QUANTITY = " & txt_quantity.Text & ", Critical = " & txt_critical.Text & ", Process_Date = date('now') WHERE Definition = '" & txt_harness.Text & "' ")

                MsgBox(fff("Updated."))
                CLEAR()
            Else
                MsgBox(fff("This harness is not in the SYSTEM. Please SAVE it."))
            End If

        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click

        If Not frm_Login.LocalDB.isThere("select * from PRODUCTION where Definition = '" & txt_harness.Text & "' ") Then
            frm_Login.LocalDB.ExecuteNonQuery("Delete From PRODUCTION where Definition = '" & txt_harness.Text & "' ")
            MsgBox(fff("Deleted."))
            CLEAR()
        End If

    End Sub


    Private Sub txt_quantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_quantity.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub txt_ProcessTime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ProcessTime.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub txt_critical_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_critical.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub


    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        frm_mainForm.Show()
        Me.Close()
    End Sub

    Public Sub CLEAR()
        txt_harness.Text = String.Empty
        txt_quantity.Text = String.Empty
        txt_ProcessTime.Text = String.Empty
        txt_critical.Text = String.Empty

        If Not frm_Login.LocalDB.isThere("Select * from PRODUCTION") Then
            grd_production.DataSource = frm_Login.LocalDB.PopulateGrid("Select * from PRODUCTION order by Process_Date")
            grd_production.Refresh()
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