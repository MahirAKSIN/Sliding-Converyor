Imports System.Text
Imports LBSoft.IndustrialCtrls.Leds

Public Class frm_main

#Region "Case Steps"
    Public Enum CaseSteps
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
        IsRightLiftUp
        isRightBelow2ndPiston
        isRight1stTray
    End Enum

#End Region

    Dim stepProcess As CaseSteps = Nothing

    Dim startTime As DateTime
    Dim endTime As DateTime
    Dim elapsed As TimeSpan

    Dim red, orange As Boolean
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)
    Dim delaytime As Integer = CInt(frm_Login.LocalDB.GetSingleValue("Select * from INI where key = 'casedelay' ", "value"))

    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If

        checkOutputState("Y20")
        checkOutputState("Y30")
        checkOutputState("Y40")
        checkOutputState("Y50")
        checkOutputState("Y60")


        stepProcess = CaseSteps.LeftLiftDown

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
        checkState("X30")
        checkState("X40")
        checkState("X50")
        checkState("X60")
        checkState("X70")

        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon1ORange), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Orange), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon1Red), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Red), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon2Orange), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Orange), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon2Red), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Red), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon3Orange), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Orange), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon3Red), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Red), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon4Orange), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Orange), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon4Red), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Red), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon5Orange), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Orange), Me), res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Andon5Red), frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Red), Me), res, req)

        red = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Red), Me)

        orange = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Orange), Me)


        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonRed), red, res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonOrange), orange, res, req)
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonGreen), Not (red Or orange), res, req)

        tmr_Indicator.Enabled = True

    End Sub


    Private Sub Y40_CheckedChanged(sender As Object, e As EventArgs) Handles Y0.CheckedChanged, Y1.CheckedChanged, Y2.CheckedChanged, Y3.CheckedChanged,
        Y20.CheckedChanged, Y21.CheckedChanged, Y22.CheckedChanged, Y23.CheckedChanged, Y24.CheckedChanged, Y25.CheckedChanged, Y26.CheckedChanged, Y27.CheckedChanged,
        Y30.CheckedChanged, Y31.CheckedChanged, Y32.CheckedChanged, Y33.CheckedChanged, Y34.CheckedChanged, Y35.CheckedChanged, Y36.CheckedChanged, Y37.CheckedChanged,
        Y40.CheckedChanged, Y41.CheckedChanged, Y42.CheckedChanged, Y43.CheckedChanged, Y44.CheckedChanged, Y45.CheckedChanged, Y46.CheckedChanged, Y47.CheckedChanged,
        Y50.CheckedChanged, Y51.CheckedChanged, Y52.CheckedChanged, Y53.CheckedChanged, Y54.CheckedChanged, Y55.CheckedChanged, Y56.CheckedChanged, Y57.CheckedChanged,
        Y60.CheckedChanged, Y61.CheckedChanged, Y62.CheckedChanged, Y63.CheckedChanged, Y64.CheckedChanged, Y65.CheckedChanged, Y66.CheckedChanged, Y67.CheckedChanged

        If sender.CheckState Then
            frm_Login.PLCDO(sender.Name.ToString, 1, res, req)
        Else
            frm_Login.PLCDO(sender.Name.ToString, 0, res, req)
        End If

    End Sub


    Private Sub tmr_Process_Tick(sender As Object, e As EventArgs) Handles tmr_Process.Tick

        tmr_Process.Enabled = False


        Select Case stepProcess

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
                                                  fff("Left piston UP") & "              (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "             (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                  fff("4. Sensor Active") & "                 (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf
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
                        frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isLeftLiftUpAbovePistonRight','" & dummy & "', datetime('now'),null)")

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
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me) And (Not red) Then

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

            Case CaseSteps.IsRightLiftUp
                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndPiston), frm_Login.RightBelow2ndPiston.left, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("Right Piston UP") & "   (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                                                  fff("9. sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                                  fff("8. sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf
                        MsgBox(dummy)

                        Exit Sub
                    End If

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
                  frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 0, res, req)

                    stepProcess = 99

                    startTime = Now

                Else

                    endTime = Now
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delaytime Then
                        Dim dummy As String = fff("8. sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                                                  fff("9. sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
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


    Private Sub btn_Enable_Process_Click(sender As Object, e As EventArgs) Handles btn_Enable_Process.Click

        If (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And
          (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me) And
            frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me)) Then

            stepProcess = CaseSteps.LeftLiftDown
            tmr_Process.Enabled = True
        Else
            MsgBox(fff("Right piston UP") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                   fff("Left piston UP") & "           (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                   fff("1. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                   fff("2. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                   fff("4. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf &
                   fff("8. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                   fff("9. Sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                   fff("Right bottom 1. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf &
                   fff("Right bottom 2. Lock UP") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                   fff("Left top Lock UP") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf)

        End If

    End Sub


    Private Sub btn_Disable_Process_Click(sender As Object, e As EventArgs) Handles btn_Disable_Process.Click

        tmr_Process.Enabled = False

    End Sub


    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click

        tmr_Process.Enabled = False
        tmr_Indicator.Enabled = False


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