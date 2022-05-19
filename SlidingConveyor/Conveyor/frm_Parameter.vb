Public Class frm_Parameter
    'Dim LocalDB As New SQLiteTools("Conveyor")
    Dim delaytime As Integer
    Private Sub frm_Parameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If
        txt_delaytime.Text = frm_Login.LocalDB.GetSingleValue("Select *  from INI where key = 'casedelay'", "value")

    End Sub

    Private Sub btn_delay_Click(sender As Object, e As EventArgs) Handles btn_delay.Click

        If txt_delaytime.Text <> String.Empty Then
            If frm_Login.LocalDB.isThere("select * from INI where key = 'casedelay' ") Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into INI  values ('casedelay', '" & txt_delaytime.Text & "')")
            Else
                frm_Login.LocalDB.ExecuteNonQuery("update INI set value = '" & txt_delaytime.Text & "' where key = 'casedelay' ")
            End If
            MsgBox(fff("Process successful"))
            'frm_Parameter_FormClosed(sender, e)
        End If

    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        'frm_mainForm.Show()
        Me.Close()
    End Sub

    Private Sub frm_Parameter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frm_mainForm.Show()
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