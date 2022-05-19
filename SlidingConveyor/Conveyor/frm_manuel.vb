Imports System.Text
Imports LBSoft.IndustrialCtrls.Leds

Public Class frm_manuel

    Dim stepProcess As CaseSteps = Nothing

    Dim red, orange As Boolean
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    Dim Locked_Color As Color = Color.Red
    Dim UnLocked_Color As Color = Color.Green

    Dim startTime As DateTime
    Dim endTime As DateTime
    Dim elapsed As TimeSpan
    Dim delaytime As Integer = CInt(frm_Login.LocalDB.GetSingleValue("Select * from INI where key = 'casedelay' ", "value"))

    Dim PistonLeft_Color As Color = Color.Blue
    Dim PistonRight_Color As Color = Color.Orange

    Dim UP As String = "UP"
    Dim DOWN As String = "DOWN"
    Shadows RIGHT As String = "RIGHT"
    Shadows LEFT As String = "LEFT"
#Region "Case Steps"
    Public Enum CaseSteps
        ThereExist
        LeftLiftDown
        isLeftLiftDownAndTrayisOut
        LeftLiftUpPistonRight
        isLeftLiftUpAbovePistonRight
        'isAbovePistonRight
        isAbovePistonLeft
        RightLiftDown
        isRightLiftDown
        isRightBelow1stPiston
        RightLiftUp
        RightLift
        'IsRightLiftUp
        isRightBelow2ndPiston
        isRight1stTray
    End Enum

#End Region
    Public Function castCaseStep(ByVal s As String) As CaseSteps
        Select Case s
            Case "LeftLiftDown"
                Return CaseSteps.LeftLiftDown
            Case "isAbovePistonLeft"
                Return CaseSteps.isAbovePistonLeft
            Case "isLeftLiftDownAndTrayisOut"
                Return CaseSteps.isLeftLiftDownAndTrayisOut
            Case "isLeftLiftUpAbovePistonRight"
                Return CaseSteps.isLeftLiftUpAbovePistonRight
            Case "isRight1stTray"
                Return CaseSteps.isRight1stTray
            Case "isRightBelow1stPiston"
                Return CaseSteps.isRightBelow1stPiston
            Case "isRightBelow2ndPiston"
                Return CaseSteps.isRightBelow2ndPiston
            Case "isRightLiftDown"
                Return CaseSteps.isRightLiftDown
            Case "ThereExist"
                Return CaseSteps.ThereExist
            Case "LeftLiftUpPistonRight"
                Return CaseSteps.LeftLiftUpPistonRight
            Case "RightLiftDown"
                Return CaseSteps.RightLiftDown
            Case "RightLiftUp"
                Return CaseSteps.RightLiftUp
            Case Else
                Return Nothing
        End Select
    End Function


    Public Sub RefreshScreen()

        If frm_Login.data_from_dev(0) = frm_Login.RightBelow1stLock.down Then
            PictureBox7.Visible = False
            pboxup1P.Visible = True
            'PictureBox7.Image.RotateFlip(RotateFlipType.Rotate180FlipNone) 'oku 180 derece döndürme,

            'PictureBox7.Refresh()
            LbBtn_Kilit_SagAlt1.Label = UP
            LbBtn_Kilit_SagAlt1.ButtonColor = UnLocked_Color
        Else
            PictureBox7.Visible = True
            pboxup1P.Visible = False
            LbBtn_Kilit_SagAlt1.Label = DOWN
            LbBtn_Kilit_SagAlt1.ButtonColor = Locked_Color
        End If

        If frm_Login.data_from_dev(1) = frm_Login.RightBelow1stPiston.right Then
            'PictureBox5.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox5.Refresh()
            PictureBox5.Visible = False
            PictureBox8.Visible = True
            LbBtn_Piston_SagAlt1.Label = LEFT
            LbBtn_Kilit_SagAlt1.ButtonColor = PistonLeft_Color
        Else
            PictureBox5.Visible = True
            PictureBox8.Visible = False
            LbBtn_Piston_SagAlt1.Label = RIGHT
            LbBtn_Kilit_SagAlt1.ButtonColor = PistonRight_Color
        End If

        If frm_Login.data_from_dev(2) = frm_Login.RightBelow2ndLock.down Then
            ''If Not (LbBtn_Kilit_SagAlt2.Label = DOWN) Then
            'PictureBox6.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            ''End If
            PictureBox6.Visible = False
            pboxup2P.Visible = True
            LbBtn_Kilit_SagAlt2.Label = UP
            LbBtn_Kilit_SagAlt2.ButtonColor = UnLocked_Color
        Else
            PictureBox6.Visible = True
            pboxup2P.Visible = False
            LbBtn_Kilit_SagAlt2.Label = DOWN
            LbBtn_Kilit_SagAlt2.ButtonColor = Locked_Color
        End If

        If frm_Login.data_from_dev(3) = frm_Login.RightBelow2ndPiston.right Then
            'PictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox2.Refresh()
            PictureBox2.Visible = False
            pboxsag2.Visible = True
            LbBtn_Piston_SagAlt2.Label = LEFT
            LbBtn_Kilit_SagAlt2.ButtonColor = PistonLeft_Color
        Else
            PictureBox2.Visible = True
            pboxsag2.Visible = False
            LbBtn_Piston_SagAlt2.Label = RIGHT
            LbBtn_Kilit_SagAlt2.ButtonColor = PistonRight_Color
        End If

        If frm_Login.data_from_dev(4) = frm_Login.LeftLockAboveLock.down Then
            'PictureBox9.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox9.Refresh()
            PictureBox9.Visible = False
            pboxupust.Visible = True
            LbBtn_Kilit_solUst.Label = UP
            LbBtn_Kilit_solUst.ButtonColor = UnLocked_Color
        Else
            PictureBox9.Visible = True
            pboxupust.Visible = False
            LbBtn_Kilit_solUst.Label = DOWN
            LbBtn_Kilit_solUst.ButtonColor = Locked_Color
        End If

        If frm_Login.data_from_dev(5) = frm_Login.AbovePiston.right Then
            'PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox1.Refresh()
            PictureBox1.Visible = False
            pboxsagust.Visible = True
            LbBtn_Piston_Ust.Label = LEFT
            LbBtn_Piston_Ust.ButtonColor = PistonLeft_Color
        Else
            PictureBox1.Visible = True
            pboxsagust.Visible = False
            LbBtn_Piston_Ust.Label = RIGHT
            LbBtn_Piston_Ust.ButtonColor = PistonRight_Color
        End If

        If frm_Login.data_from_dev(6) = frm_Login.RightLift.down Then
            'PictureBox4.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox4.Refresh()
            PictureBox4.Visible = False
            pboxupR.Visible = True
            LbBtn_Piston_Sag.Label = UP
            LbBtn_Piston_Sag.ButtonColor = PistonRight_Color
        Else
            PictureBox4.Visible = True
            pboxupR.Visible = False
            LbBtn_Piston_Sag.Label = DOWN
            LbBtn_Piston_Sag.ButtonColor = PistonLeft_Color
        End If

        If frm_Login.data_from_dev(7) = frm_Login.LeftLift.down Then
            'PictureBox3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            'PictureBox3.Refresh()
            PictureBox3.Visible = False
            pboxupL.Visible = True
            LbBtn_Piston_Sol.Label = UP
            LbBtn_Piston_Sol.ButtonColor = PistonRight_Color
        Else
            PictureBox3.Visible = True
            pboxupL.Visible = False
            LbBtn_Piston_Sol.Label = DOWN
            LbBtn_Piston_Sol.ButtonColor = PistonLeft_Color
        End If
    End Sub


    Private Sub frm_manuel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.ValfBar), frm_Login.ValfBar.active, res, req)

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        If Not frm_Login.LocalDB.isThere("select * from STATISTICs where ((Type='System') or (Type='Emergency'))  and FinishedTime is null order by StartingTime desc limit 1  ") Then
            txt_detail.Text = fff("You should check Cut-Off Valve Checkbox in order to run the system. ") & vbCrLf & frm_Login.LocalDB.GetSingleValue("select * from STATISTICs where ((Type='System') or (Type='Emergency'))  and FinishedTime is null order by StartingTime desc limit 1   ", "detail")
            btn_arızagider.Enabled = True
        Else
            txt_detail.Text = String.Empty
            btn_arızagider.Enabled = False
        End If


        'frm_Login.PLCDI("Y20", 8, frm_Login.data_from_dev, res, req)
        'Y20.Checked = frm_Login.data_from_dev(0)
        'Y21.Checked = frm_Login.data_from_dev(1)
        'Y22.Checked = frm_Login.data_from_dev(2)
        'Y23.Checked = frm_Login.data_from_dev(3)
        'Y24.Checked = frm_Login.data_from_dev(4)
        'Y25.Checked = frm_Login.data_from_dev(5)
        'Y26.Checked = frm_Login.data_from_dev(6)
        'Y27.Checked = frm_Login.data_from_dev(7)

        checkOutputState("Y20")

        RefreshScreen()

        checkOutputState("Y60")

        If Y67.Checked Then
            LbBut_StartStop.Enabled = True
        End If

        'stepProcess = CaseSteps.LeftLiftDown

        tmr_Indicator.Enabled = True
        tmr_Process.Enabled = False

    End Sub


    Public Sub checkOutputState(ByVal outputBlock As String)

        frm_Login.PLCDI(outputBlock, 8, frm_Login.data_from_dev, res, req)
        Dim c As New CheckBox

        For Each ctrl As Control In Me.Controls
            If (TypeOf ctrl Is CheckBox) And (ctrl.Name.ToString.StartsWith("Y")) Then
                If (CInt(ctrl.Name.Remove(0, 1)) >= CInt(outputBlock.Remove(0, 1))) And (CInt(ctrl.Name.Remove(0, 1)) <= CInt(outputBlock.Remove(0, 1)) + 7) Then
                    c = DirectCast(ctrl, CheckBox)
                    If frm_Login.data_from_dev(CInt(ctrl.Name.Remove(0, 1)) Mod 10) = 1 Then
                        c.Checked = True
                    Else
                        c.Checked = False
                    End If
                End If
            End If
        Next

    End Sub


    Public Sub checkState(ByVal inputBlock As String)

        frm_Login.PLCDI(inputBlock, 8, frm_Login.data_from_dev, res, req)
        Dim c As New LBLed

        For Each ctrl As Control In Me.Controls
            If (TypeOf ctrl Is LBLed) And (ctrl.Name.ToString.StartsWith("X")) Then
                If (CInt(ctrl.Name.Remove(0, 1)) >= CInt(inputBlock.Remove(0, 1))) And (CInt(ctrl.Name.Remove(0, 1)) <= CInt(inputBlock.Remove(0, 1)) + 7) Then
                    c = DirectCast(ctrl, LBLed)
                    If frm_Login.data_from_dev(CInt(ctrl.Name.Remove(0, 1)) Mod 10) = 1 Then
                        c.State = LBLed.LedState.On
                    Else
                        c.State = LBLed.LedState.Off
                    End If
                End If
            End If
        Next

    End Sub


    Private Sub tmr_Indicator_Tick(sender As Object, e As EventArgs) Handles tmr_Indicator.Tick

        tmr_Indicator.Enabled = False

        checkState("X20")
        'RefreshScreen()
        checkState("X30")
        checkState("X40")
        checkState("X50")
        checkState("X60")

        tmr_Indicator.Enabled = True

    End Sub


    Public Sub Y40_CheckedChanged(sender As Object, e As EventArgs) Handles Y30.CheckedChanged, Y31.CheckedChanged, Y32.CheckedChanged, Y33.CheckedChanged, Y34.CheckedChanged, Y35.CheckedChanged, Y36.CheckedChanged, Y37.CheckedChanged,
                Y40.CheckedChanged, Y41.CheckedChanged, Y42.CheckedChanged, Y43.CheckedChanged, Y44.CheckedChanged, Y45.CheckedChanged, Y46.CheckedChanged, Y47.CheckedChanged,
                Y60.CheckedChanged, Y61.CheckedChanged, Y62.CheckedChanged, Y63.CheckedChanged, Y64.CheckedChanged, Y65.CheckedChanged, Y66.CheckedChanged, Y67.CheckedChanged,
                Y20.CheckedChanged, Y21.CheckedChanged, Y22.CheckedChanged, Y23.CheckedChanged, Y24.CheckedChanged, Y25.CheckedChanged, Y26.CheckedChanged, Y27.CheckedChanged
        'Y0.CheckedChanged, Y1.CheckedChanged, Y2.CheckedChanged, Y3.CheckedChanged,
        'Y50.CheckedChanged, Y51.CheckedChanged, Y52.CheckedChanged, Y53.CheckedChanged, Y54.CheckedChanged, Y55.CheckedChanged, Y56.CheckedChanged, Y57.CheckedChanged,
        If sender.CheckState Then
            frm_Login.PLCDO(sender.Name.ToString, 1, res, req)
        Else
            frm_Login.PLCDO(sender.Name.ToString, 0, res, req)
        End If

        If sender.Name.ToString = "Y67" Then
            If sender.CheckState Then
                LbBut_StartStop.Enabled = True
            Else
                LbBut_StartStop.Enabled = False
            End If
        End If

    End Sub


    Private Sub LbBut_StartStop_Click(sender As Object, e As EventArgs) Handles LbBut_StartStop.Click

        If LbBut_StartStop.Label = "START" Then

            If frm_Login.LocalDB.GetSingleValue("select * from STATISTICs where FinishedTime is null order by StartingTime desc limit 1", "type") = "Emergency" Then
                stepProcess = frm_Login.LocalDB.GetSingleValue("select * from STATISTICs order by StartingTime desc limit 1", "info")

            ElseIf frm_Login.LocalDB.GetSingleValue("select * from STATISTICs where FinishedTime is null order by StartingTime desc limit 1", "type") = "System" Then
                stepProcess = castCaseStep(frm_Login.LocalDB.GetSingleValue("select * from STATISTICs order by StartingTime desc limit 1", "info"))
            Else
                stepProcess = 0
            End If
            If txt_detail.Text <> String.Empty Then
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set FinishedTime=datetime('now') " &
                             "where StartingTime = (select StartingTime from  STATISTICs where  FinishedTime is null order by StartingTime desc limit 1 )")
                txt_detail.Text = String.Empty
            End If
            LbBtn_Kilit_SagAlt1.Enabled = False
            LbBtn_Kilit_SagAlt2.Enabled = False
            LbBtn_Kilit_solUst.Enabled = False
            LbBtn_Piston_Sag.Enabled = False
            LbBtn_Piston_SagAlt1.Enabled = False
            LbBtn_Piston_SagAlt2.Enabled = False
            LbBtn_Piston_Sol.Enabled = False
            LbBtn_Piston_Ust.Enabled = False

            tmr_Process.Enabled = True
            frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 1, res, req)
            frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Barrier), frm_Login.Barrier.active, res, req)
            startTime = Now
            LbBut_StartStop.Label = "STOP"
            LbBut_StartStop.ButtonColor = Color.Red

        Else
            tmr_Process.Enabled = False
            LbBut_StartStop.Label = "START"
            LbBut_StartStop.ButtonColor = Color.Green
        End If


    End Sub


    Private Sub tmr_Process_Tick(sender As Object, e As EventArgs) Handles tmr_Process.Tick

        tmr_Process.Enabled = False


        Select Case stepProcess
            Case CaseSteps.ThereExist
                If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And
                  frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And
                  frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me) And
                  frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me) And
                  frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And
                 frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And
                (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) And
                 frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me) And
                 frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me) And
                 frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me)) And
                 (Not ((frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftISHarness), Me)) Or 'harness kontrolü yapan iki sensörde yok diyorsa
                   (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Left2ISharness), Me)))) And (Not red) Then


                    stepProcess += 1

                    startTime = Now 'Bu yapı girilen delay time ne kadarsa orn 5 sn startimedan 5 sn sonrasına kadar işlem sağlanmıyorsa else düşürüyor

                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = MsgBox(fff("Right piston UP") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                                                         fff("Left piston UP") & "           (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                         fff("1. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                         fff("2. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                                                         fff("4. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf &
                                                         fff("8. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                                                         fff("9. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                                         fff("Right bottom 1. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                                                         fff("Right bottom 2. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                                                         fff("Left top Lock UP") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf)
                            '           fff("Harness Exist") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftISHarness), Me).ToString & vbCrLf &
                            'fff("Harnes Exist2") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Left2ISharness), Me).ToString & vbCrLf

                            'frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','ThereExist','" & dummy & "', datetime('now'),null)")
                            'txt_detail.Text = dummy
                            MsgBox(dummy)
                            Exit Sub
                        End If
                    Else
                    End If
                End If

            Case CaseSteps.LeftLiftDown

                ' sol asansor asagi on sartlari ''ikisensor daha var
                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me) And 'A5 kilidi kilitli
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And '4.sensor var
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And 'sol piston yukarda
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And '5.sensor araba yok dedi
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me) And (Not red) Then 'A3 kilitli

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLift), frm_Login.LeftLift.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Right Bottom 2. Lock UP") & "        (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                                                  fff("Left Up Lock UP") & "           (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf &
                                                  fff("Left piston Up") & "              (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "             (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                  fff("4. Sensor Active") & "                 (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf

                        'frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','LeftLiftDown','" & dummy & "', datetime('now'),null)")
                        'txt_detail.Text = dummy
                        MsgBox(dummy)
                        Exit Sub
                    End If
                End If

            Case CaseSteps.isLeftLiftDownAndTrayisOut

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me) And
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me)) And (Not red) Then

                    stepProcess += 1
                    startTime = Now
                Else
                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Left piston BOTTOM") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                 fff("6. Sensor De-Active") & "         (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me).ToString & vbCrLf

                        'frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isLeftLiftDownAndTrayisOut','" & dummy & "', datetime('now'),null)")
                        'txt_detail.Text = dummy
                        MsgBox(dummy)

                        Exit Sub
                    End If

                End If


            Case CaseSteps.LeftLiftUpPistonRight

                ' sol asansor yukarı ön koşulları
                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me) And
                        (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And '5. sensor
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me) And 'sol piston aşağıda
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And' 4.sensor görmicek
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me) And (Not red) Then 'A5 kilitli

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLift), frm_Login.LeftLift.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.up, res, req) ' önceki case de olmazsa koyulabilr
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AbovePiston), frm_Login.AbovePiston.right, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("9. Sensor Active") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                                  fff("Left Up Lock UP") & "    (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf &
                                                  fff("Left piston BOTTOM") & "       (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                  fff("4. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf

                        'frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','LeftLiftUpPistonRight','" & dummy & "', datetime('now'),null)")
                        'txt_detail.Text = dummy
                        MsgBox(dummy)
                        Exit Sub
                    End If
                End If
            Case CaseSteps.isLeftLiftUpAbovePistonRight

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And
                  (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me) And (Not red) Then

                    'frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AbovePiston), frm_Login.AbovePiston.right, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLockAboveLock), frm_Login.LeftLockAboveLock.down, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AbovePiston), frm_Login.AbovePiston.left, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Left piston UP") & "       (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                  fff("Up Piston RIGHT") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me).ToString & vbCrLf &
                                                  fff("4. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf

                        MsgBox(dummy)

                        Exit Sub
                    End If
                End If



            Case CaseSteps.isAbovePistonLeft

                If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me) And
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLockAboveLock), frm_Login.LeftLockAboveLock.up, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("1. Sensor De-Active") & "   (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                  fff("Up Piston LEFT") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me).ToString & vbCrLf &
                                                   fff("4. Sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf

                        MsgBox(dummy)
                        Exit Sub
                    End If
                End If

            Case CaseSteps.RightLiftDown

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And
                  (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And
                  (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightLift), frm_Login.RightLift.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("1. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                  fff("Right Piston UP") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                                                  fff("Right Bottom 1. Lock UP") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf
                        MsgBox(dummy)
                        Exit Sub
                    End If

                End If

            Case CaseSteps.isRightLiftDown

                If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stPiston), frm_Login.RightBelow1stPiston.left, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("1. Sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                   fff("Right Piston BOTTOM") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me).ToString & vbCrLf &
                                                   fff("8. sensor Active") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf
                        MsgBox(dummy)
                        Exit Sub
                    End If
                End If


            Case CaseSteps.isRightBelow1stPiston

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stPiston), frm_Login.RightBelow1stPiston.right, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stLock), frm_Login.RightBelow1stLock.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Right Bottom 1. Piston LEFT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me).ToString

                        MsgBox(dummy)

                        Exit Sub
                    End If

                End If

            Case CaseSteps.RightLiftUp

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me) And
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And '3.sensor görmüyorsa sonradan eklendi 20.06
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me)) And '10. sensör görmicek sonradan eklendi 20.06
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndPiston), frm_Login.RightBelow2ndPiston.left, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stLock), frm_Login.RightBelow1stLock.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightLift), frm_Login.RightLift.up, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("1. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                  fff("Right Bottom 1. Piston RIGHT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me).ToString & vbCrLf &
                                                  fff("10. sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me).ToString & vbCrLf &
                                                  fff("3. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf &
                                                  fff("8. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf

                        MsgBox(dummy)

                        Exit Sub
                    End If

                End If

            Case CaseSteps.RightLift

                If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me)) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me) And '3.sensor görüyorsa sonradan eklendi 20.06
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me)) Then

                    Dim dummy As String = fff("2. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                                          fff("10. sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me).ToString & vbCrLf &
                                          fff("3. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf

                    frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isRightBelow2ndPiston', '" & dummy & "',datetime('now'),null)")
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.ValfBar), frm_Login.ValfBar.pasive, res, req) 'pasive havayı kesme

                    MsgBox(dummy)
                    Exit Sub

                ElseIf frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) Then
                    stepProcess += 1

                End If


            Case CaseSteps.isRightBelow2ndPiston

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndPiston), frm_Login.RightBelow2ndPiston.right, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Right Bottom 2. Piston LEFT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me).ToString
                        MsgBox(dummy)
                        Exit Sub
                    End If

                End If


            Case CaseSteps.isRight1stTray

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) And
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me) And (Not red) Then 'not ekledim

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 0, res, req)
                    Dim dummy As String = fff("Conveyor is in Start position !")
                    txt_detail.Text = dummy
                    LbBut_StartStop.Label = "START"
                    LbBut_StartStop.ButtonColor = Color.Green
                    stepProcess = 99
                    startTime = Now

                    'Manual ekranda sistem hareket ettikten sonraki durumu okuma 19/10/2018
                    checkOutputState("Y20")

                    RefreshScreen()

                    checkOutputState("Y60")

                    If Y67.Checked Then
                        LbBut_StartStop.Enabled = True
                    End If

                    LbBtn_Kilit_SagAlt1.Enabled = True
                    LbBtn_Kilit_SagAlt2.Enabled = True
                    LbBtn_Kilit_solUst.Enabled = True
                    LbBtn_Piston_Sag.Enabled = True
                    LbBtn_Piston_SagAlt1.Enabled = True
                    LbBtn_Piston_SagAlt2.Enabled = True
                    LbBtn_Piston_Sol.Enabled = True
                    LbBtn_Piston_Ust.Enabled = True

                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("8. sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                                                  fff("9. sensör De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                               fff("Right Bottom 2. Piston RIGHT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me).ToString
                        MsgBox(dummy)
                        Exit Sub
                    End If

                End If

        End Select

        If stepProcess <> 99 Then
            tmr_Process.Enabled = True
        End If

    End Sub


    Private Sub LbBtn_Kilit_solUst_Click(sender As Object, e As EventArgs) Handles LbBtn_Kilit_solUst.Click

        If LbBtn_Kilit_solUst.Label = DOWN Then
            If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) Then 'sol piston yukarıda

                PictureBox9.Visible = True
                pboxupust.Visible = False
                Y24.Checked = frm_Login.LeftLockAboveLock.down
                LbBtn_Kilit_solUst.Label = UP
                LbBtn_Kilit_solUst.ButtonColor = UnLocked_Color
            Else
                MsgBox(fff("Left Piston UP") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf)
            End If
        Else
            If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndUp), Me)) Then 'Sensör 7 görmesin
                PictureBox9.Visible = False
                pboxupust.Visible = True
                Y24.Checked = frm_Login.LeftLockAboveLock.up
                LbBtn_Kilit_solUst.Label = DOWN
                LbBtn_Kilit_solUst.ButtonColor = Locked_Color

            Else
                MsgBox(fff("7. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndUp), Me).ToString & vbCrLf)
            End If
        End If
    End Sub


    Private Sub LbBtn_Kilit_SagAlt1_Click(sender As Object, e As EventArgs) Handles LbBtn_Kilit_SagAlt1.Click

        If LbBtn_Kilit_SagAlt1.Label = DOWN Then

            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me)) And 'Sağ piston aşağıda
                (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) Then 'Sensör 1 görmesin

                PictureBox7.Visible = False
                pboxup1P.Visible = True
                Y20.Checked = frm_Login.RightBelow1stLock.down
                LbBtn_Kilit_SagAlt1.Label = UP
                LbBtn_Kilit_SagAlt1.ButtonColor = UnLocked_Color
            Else
                MsgBox(fff("Right piston BOTTOM") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me).ToString & vbCrLf &
                       fff("1. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf)
            End If

        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And 'Sensör 1 görsün
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And 'Sensör 8 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) Then 'Sensör 9 görsün                

                PictureBox7.Visible = True
                pboxup1P.Visible = False
                Y20.Checked = frm_Login.RightBelow1stLock.up
                LbBtn_Kilit_SagAlt1.Label = DOWN
                LbBtn_Kilit_SagAlt1.ButtonColor = Locked_Color
            Else
                MsgBox(fff("1. Sensor Active") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                       fff("8. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                       fff("9. Sensor Active") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf)

            End If
        End If
    End Sub


    Private Sub LbBtn_Kilit_SagAlt2_Click(sender As Object, e As EventArgs) Handles LbBtn_Kilit_SagAlt2.Click

        If LbBtn_Kilit_SagAlt2.Label = DOWN Then
            If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) Then 'Sensör 8 görmesin

                PictureBox6.Visible = False
                pboxup2P.Visible = True
                Y22.Checked = frm_Login.RightBelow2ndLock.down
                LbBtn_Kilit_SagAlt2.Label = UP
                LbBtn_Kilit_SagAlt2.ButtonColor = UnLocked_Color
            Else
                MsgBox(fff("8. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf)

            End If
        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And 'Sensör 8 görsün
                (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) Then 'Sensör 9 görmesin

                PictureBox6.Visible = True
                pboxup2P.Visible = False
                Y22.Checked = frm_Login.RightBelow2ndLock.up
                LbBtn_Kilit_SagAlt2.Label = DOWN
                LbBtn_Kilit_SagAlt2.ButtonColor = Locked_Color
            Else
                MsgBox(fff("8. Sensor Active") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                       fff("9. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf)
            End If
        End If
    End Sub


    Private Sub LbBtn_Piston_Ust_Click(sender As Object, e As EventArgs) Handles LbBtn_Piston_Ust.Click

        If LbBtn_Piston_Ust.Label = LEFT Then
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me)) And 'Sol Piston yukarda
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And 'Sensör 4 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me)) And 'Üst Piston Sağda 
                (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me)) And 'Sensör 2 görsün
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockDown), Me)) Then 'A5 Kilitli değil


                PictureBox1.Visible = True
                pboxsagust.Visible = False
                Y25.Checked = frm_Login.AbovePiston.left
                    LbBtn_Piston_Ust.Label = RIGHT
                    LbBtn_Piston_Ust.ButtonColor = PistonRight_Color
                Else
                MsgBox(fff("Up piston RIGHT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me).ToString & vbCrLf &
                 fff("Left piston UP") & "            (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                 fff("Left Up Lock BOTTOM") & "       (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockDown), Me).ToString & vbCrLf &
                 fff("2. Sensor Active") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                 fff("4. Sensor De-Active") & "       (false): " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf)
            End If
        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me)) And 'Sağ Piston yukarda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And 'Sensör 1 görsün
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me)) Then 'Üst Piston Solda 


                PictureBox1.Visible = False
                pboxsagust.Visible = True

                Y25.Checked = frm_Login.AbovePiston.right
                LbBtn_Piston_Ust.Label = LEFT
                LbBtn_Piston_Ust.ButtonColor = PistonLeft_Color
            Else
                MsgBox(fff("Right piston UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                  fff("1. Sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                  fff("UP piston LEFT") & "        (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me).ToString & vbCrLf)
            End If
        End If
    End Sub


    Private Sub LbBtn_Piston_Sol_Click(sender As Object, e As EventArgs) Handles LbBtn_Piston_Sol.Click

        If LbBtn_Piston_Sol.Label = DOWN Then
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me)) And 'A3 kilitli
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me)) And 'A5 Kilitli
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me)) And 'Sol Asansör yukarda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) Then 'Sensör 4 görsün


                PictureBox3.Visible = False
                pboxupL.Visible = True
                Y27.Checked = frm_Login.LeftLift.down
                LbBtn_Piston_Sol.Label = UP
                LbBtn_Piston_Sol.ButtonColor = PistonRight_Color
            Else
                MsgBox(fff("Right Bottom 2.Lock UP") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                  fff("Left Up Lock UP") & "             (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf &
                  fff("Left piston UP") & "              (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                  fff("4. Sensor Active") & "            (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf)

            End If
        Else
            If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And 'Sensör 5 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me)) And 'A5 Kilitli
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me)) And 'Sol Asansör aşağıda
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And 'Sensör 4 görmesin
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me)) And 'Sensör 6 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) Then 'Sensör 9 görsün


                PictureBox3.Visible = True
                pboxupL.Visible = False
                Y27.Checked = frm_Login.LeftLift.up
                LbBtn_Piston_Sol.Label = DOWN
                LbBtn_Piston_Sol.ButtonColor = PistonLeft_Color
            Else
                MsgBox(fff("Left Piston Bottom") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me).ToString & vbCrLf &
                  fff("5. Sensor De-Active") & "     false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                  fff("4. Sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf &
                  fff("6. Sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me).ToString & vbCrLf &
                  fff("9. Sensor Active") & "        (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                  fff("Left up Lock UP") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf)

            End If
        End If
    End Sub


    Private Sub LbBtn_Piston_Sag_Click(sender As Object, e As EventArgs) Handles LbBtn_Piston_Sag.Click

        If LbBtn_Piston_Sag.Label = DOWN Then
            If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And 'Sensör 1 görmesin
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me)) And 'Sensör 2 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me)) And 'Sağ Asansör yukarda
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And 'Sensör 3 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me)) Then 'A1 Kilitli


                PictureBox4.Visible = False
                pboxupR.Visible = True

                Y26.Checked = frm_Login.RightLift.down
                    LbBtn_Piston_Sag.Label = UP
                    LbBtn_Piston_Sag.ButtonColor = PistonRight_Color

                Else
                MsgBox(fff("1. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                       fff("2. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                       fff("Right piston UP") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                       fff("Right Bottom 1. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                       fff("3. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf)

            End If
        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And 'Sensör 1 görsün
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me)) And 'Sensör 2 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me)) And 'Sağ Asansör aşağıda
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And 'Sensör 3 görmesin
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me)) And '10.sensör görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me)) Then 'A1 Kilitli


                PictureBox4.Visible = True
                pboxupR.Visible = False

                Y26.Checked = frm_Login.RightLift.up
                Y26.Refresh()
                LbBtn_Piston_Sag.Label = DOWN
                LbBtn_Piston_Sag.ButtonColor = PistonLeft_Color

            Else
                MsgBox(fff("1. Sensor Active") & "    (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                  fff("2. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                  fff("Right piston BOTTOM") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me).ToString & vbCrLf &
                  fff("Right Bottom 1. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                  fff("10. Sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me).ToString & vbCrLf &
                  fff("3. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf)
            End If
        End If
    End Sub


    Private Sub LbBtn_Piston_SagAlt1_Click(sender As Object, e As EventArgs) Handles LbBtn_Piston_SagAlt1.Click

        If LbBtn_Piston_SagAlt1.Label = LEFT Then
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me)) And 'A2 Sağda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me)) And 'A3 Kilitli
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And 'Sensör 8 görsün
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me)) Then 'A1 Kilitli


                PictureBox5.Visible = True
                PictureBox8.Visible = False
                Y21.Checked = frm_Login.RightBelow1stPiston.left
                LbBtn_Piston_SagAlt1.Label = RIGHT
                LbBtn_Kilit_SagAlt1.ButtonColor = PistonRight_Color
            Else
                MsgBox(fff("8. Sensor Active") & "        (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                    fff("Right Bottom 2. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                    fff("Right Bottom 1. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                    fff("Right Bottom 1. piston RIGHT") & "   (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me).ToString & vbCrLf)
            End If
        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me)) And 'A2 Solda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me)) And 'A3 Kilitli
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me)) And 'Sağ Piston aşağıda
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And 'Sensör 1 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And 'Sensör 8 görsün
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockLeft), Me)) Then 'A1 Kilitli değil

                PictureBox5.Visible = False
                PictureBox8.Visible = True
                Y21.Checked = frm_Login.RightBelow1stPiston.right
                LbBtn_Piston_SagAlt1.Label = LEFT
                LbBtn_Kilit_SagAlt1.ButtonColor = PistonLeft_Color
            Else
                MsgBox(fff("1. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                 fff("Right Bottom 1. Piston LEFT") & "   (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me).ToString & vbCrLf &
                 fff("Right piston BOTTOM") & "        (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me).ToString & vbCrLf &
                 fff("Right Bottom 1. Lock BOTTOM") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockLeft), Me).ToString & vbCrLf &
                 fff("Right Bottom 2. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                 fff("8. Sensor Active") & "           (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf)

            End If
        End If
    End Sub


    Private Sub LbBtn_Piston_SagAlt2_Click(sender As Object, e As EventArgs) Handles LbBtn_Piston_SagAlt2.Click

        If LbBtn_Piston_SagAlt2.Label = LEFT Then
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me)) And 'A4 Sağda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) Then 'Sensör 9 görsün
                PictureBox2.Visible = True
                pboxsag2.Visible = False
                Y23.Checked = frm_Login.RightBelow2ndPiston.left
                LbBtn_Piston_SagAlt2.Label = RIGHT
                LbBtn_Kilit_SagAlt2.ButtonColor = PistonRight_Color
            Else
                MsgBox(fff("Right Bottom 2. Piston RIGHT") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me).ToString & vbCrLf &
                       fff("9. Sensor Active") & "             (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf)
            End If
        Else
            If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me)) And 'A4 Solda
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockDown), Me)) And 'A3 Kilitli Değil
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me)) And 'A1 Kilitli
               (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And 'Sensör 8 görmesin
               (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) Then 'Sensör 9 görsün

                PictureBox2.Visible = False
                pboxsag2.Visible = True
                Y23.Checked = frm_Login.RightBelow2ndPiston.right
                LbBtn_Piston_SagAlt2.Label = LEFT
                LbBtn_Kilit_SagAlt2.ButtonColor = PistonLeft_Color

            Else
                MsgBox(fff("Right Bottom 2. Piston LEFT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me).ToString & vbCrLf &
                 fff("Right Bottom 2. Lock BOTTOM") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockDown), Me).ToString & vbCrLf &
                 fff("Right Bottom 1. Lock UP") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                 fff("9. sensor Active") & "               (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                 fff("8. Sensor De-Active") & "           (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf)
            End If
        End If
    End Sub


    Private Sub btn_arızagider_Click(sender As Object, e As EventArgs) Handles btn_arızagider.Click
        If txt_detail.Text <> String.Empty Then
            frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set FinishedTime=datetime('now') " &
                                "where StartingTime = (select StartingTime from  STATISTICs where  FinishedTime is null order by StartingTime desc limit 1 )")
            txt_detail.Text = String.Empty
        End If
    End Sub


    Private Sub btn_Exit_Click_1(sender As Object, e As EventArgs) Handles btn_Exit.Click

        tmr_Indicator.Enabled = False
        tmr_Process.Enabled = False
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