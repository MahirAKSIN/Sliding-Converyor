Public Class frm_msg


    Private WithEvents tm As New Timer
    Private Sub frm_msg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If
        lbl_OK.Text = fff("HARNESS EXIST !")
        tm.Interval = 2000
        tm.Start()

        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class