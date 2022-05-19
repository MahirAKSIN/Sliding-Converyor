Imports System.Data.SqlTypes
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frm_Statistics
    'Dim LocalDB As New SQLiteTools("Conveyor")

    Dim sqlStr As SqlString
    Private Sub frm_Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
                FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        cmb_type.SelectedIndex = 1
        grd_statistic.DataSource = frm_Login.LocalDB.PopulateGrid("Select * from STATISTICs where Type = 'Production'")
        'grd_statistic.Refresh()

        'Mahir Aksin --->'20190705''
    End Sub

    Private Sub btn_Filter_Click(sender As Object, e As EventArgs) Handles btn_Filter.Click
        sqlStr = "select *  from STATISTICs WHERE "
        If cmb_type.SelectedIndex <> 0 Then
            sqlStr += "type = '" & cmb_type.SelectedItem.ToString & "' AND "
        End If
        sqlStr = sqlStr + "StartingTime BETWEEN '" + dtp_StartDate.Text + " 00:00:00' AND '" + dtp_FinishDate.Text + " 23:59:59' ORDER BY FinishedTime ASC"


        grd_statistic.DataSource = frm_Login.LocalDB.PopulateGrid(sqlStr)
    End Sub

    Private Sub btn_ExportToExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportToExcel.Click
        SFD.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        SFD.FilterIndex = 3
        SFD.FileName = String.Empty
        SFD.InitialDirectory = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)), "Documents")
        ' Show it
        If SFD.ShowDialog(Me) = DialogResult.OK Then
            Dim dt As DataTable


            Dim objXLApp As New Excel.Application
            Dim i, j As Integer
            Dim objXLWb As Excel.Workbook = objXLApp.Workbooks.Add()


            Dim objXLWs As Excel.Worksheet = CType(objXLWb.Worksheets.Add(), Excel.Worksheet)

            objXLWs = CType(objXLWb.Worksheets.Add(), Excel.Worksheet)
            objXLWs.Name = "STATISTICs"

            objXLWs.Cells(1, 1) = "Type"
            objXLWs.Cells(1, 2) = "Info"
            objXLWs.Cells(1, 3) = "StartedTime"
            objXLWs.Cells(1, 4) = "FinishedTime"

            sqlStr = "select *  from STATISTICs WHERE "
            If cmb_type.SelectedIndex <> 0 Then
                sqlStr += "Type = '" & cmb_type.SelectedItem.ToString & "' AND "
            End If
            sqlStr = sqlStr + "StartingTime BETWEEN '" + dtp_StartDate.Text + " 00:00:00' AND '" + dtp_FinishDate.Text + " 23:59:59' ORDER BY FinishedTime ASC"

            dt = frm_Login.LocalDB.PopulateGrid(sqlStr)

            For i = 1 To dt.Rows.Count
                For j = 1 To dt.Columns.Count
                    objXLWs.Cells(i + 1, j) = dt.Rows(i - 1).Item(j - 1).ToString()
                Next j
            Next i

            objXLWb.Application.DisplayAlerts = False
            TryCast(objXLWb.Sheets(4), Excel.Worksheet).Delete()
            'TryCast(objXLWb.Sheets(4), Excel.Worksheet).Delete()
            'TryCast(objXLWb.Sheets(4), Excel.Worksheet).Delete()
            objXLWb.Application.DisplayAlerts = True

            objXLWs.SaveAs(SFD.FileName)

            objXLWb.Close()
            objXLApp.Quit()

            MsgBox(fff("Process of Excel Export Succesful !"), MsgBoxStyle.OkOnly, "EXCEL EXPORT")
        End If
    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        frm_mainForm.Show()
        Me.Close()

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