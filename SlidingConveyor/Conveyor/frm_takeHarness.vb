Public Class frm_takeHarness

    'Dim LocalDB As New SQLiteTools("Conveyor")

    Public Shared harness As String = String.Empty
    Public Shared startindex As Integer

    Private Sub frm_takeHarness_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        Me.Text += " " & String.Format(" {0}", My.Application.Info.Version.ToString)

        cmb_Harness.DataSource = frm_Login.LocalDB.PopulateComboBox("Select * from PRODUCTION", "Definition", True)
        cmb_Harness.Refresh()

        cmb_Harness.SelectedIndex = 0

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        If cmb_Harness.SelectedIndex <> 0 Then
            harness = cmb_Harness.SelectedItem.ToString()
            If cmb_Harness.SelectedItem.ToString() = frm_Login.LocalDB.GetSingleValue("select * from STATISTICs where type = 'Production' order by StartingTime desc limit 1", "info") Then
                Dim index As String = frm_Login.LocalDB.GetSingleValue("select * from STATISTICs where type = 'Production' order by StartingTime desc limit 1", "detail")
                If index.Split(" ")(0) <> index.Split(" ")(2) Then
                    Dim mesage As Integer = MsgBox(fff("This harness operation is not complete. Do you want to continue?"), MsgBoxStyle.YesNo)

                    If mesage = vbYes Then
                        startindex = Val(index.Split(" ")(0))
                    Else
                        startindex = 0 ' cancel
                    End If
                Else
                    startindex = 0
                End If
            Else
                startindex = 0
            End If

            For Each f As Form In Application.OpenForms
                If TypeOf f Is frm_information Then
                    f.Activate()
                    Return
                End If
            Next

            Dim myChild As New frm_information
            myChild.Show()

            Me.Hide()
        End If
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