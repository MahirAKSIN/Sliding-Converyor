Imports System.Text
Imports LBSoft.IndustrialCtrls.Leds


Public Class frm_information



    Public Enum CaseSteps
        ThereExist 'Conveyorde harnessin varlığını kontrolü

        LeftLiftDown 'sol asansörün aşagı hareketi
        isLeftLiftDownAndTrayisOut 'sol asansor aşağıda ve çekmece içinde değil mi
        LeftLiftUpPistonRight 'Sol asansör yukarı  ve üst piston sağa hareketi
        isLeftLiftUpAbovePistonRight 'Sol asansör yukardaysa üst piston sola
        isAbovePistonLeft 'üst piston soldaysa üstteki kilit yukarı
        RightLiftDown ' sağ asansör aşağı
        isRightLiftDown 'Sağ asansör aşağıdaysa piston sola
        isRightBelow1stPiston 'Sağdailk piston sağa
        RightLiftUp 'sağ asansör yukarı
        RightLift
        'IsRightLiftUp
        isRightBelow2ndPiston 'ikinci piston sola
        isRight1stTray 'altta birincide çekmece var mı
        EndofProcess = 99
    End Enum
    'Andonların durumları için
    Dim OrangeStates() As Boolean = {False, False, False, False, False}
    Dim RedStates() As Boolean = {False, False, False, False, False}

    'CaseSteplerdeki gecikme
    Dim startTime As DateTime
    Dim endTime As DateTime
    Dim elapsed As TimeSpan
    Dim delaytime As Integer = CInt(frm_Login.LocalDB.GetSingleValue("Select * from INI where key = 'casedelay' ", "value"))

    Dim stepProcess As CaseSteps = CaseSteps.ThereExist

    Dim barrier1 As Boolean = False 'ışık bariyeri 1
    Dim barrier2 As Boolean = False 'ışık bariyeri 2
    Dim barrier3 As Boolean = False 'ışık bariyeri 3

    Dim red, orange As Boolean
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    Dim systemerorled As Boolean = False
    Dim identifed_time As Integer = 0
    Dim critical_Value As Integer = 0

    Dim count As Integer = 0
    Public Sub inc(ByVal p As ProgressBar)
        If p.Value < p.Maximum Then
            p.Value += 1
        End If
    End Sub

    Private Sub frm_information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tmr_Indicator.Enabled = True

#If DEBUG Then
        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 0, res, req) 'kısık sesli buzzerı kapaama
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req) 'yüksek sesli buzzerı kapama
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.ValfBar), frm_Login.ValfBar.active, res, req) 'ana valfi açma

        'If Not LocalDB.isThere("Select * from STATISTICs") Then
        '    grd_statistic.DataSource = LocalDB.PopulateGrid("Select * from STATISTICs order by StartingTime", "STATISTICs")
        '    grd_statistic.Refresh()
        'End If


        checkState("X0") 'checkstate durumlarını okumak almak için
        checkState("X20")
        checkState("X30")
        checkState("X40")
        checkState("X50")
        checkState("X60")
        checkState("X70")

#Region "StatuesButon"


#End Region

        Me.Text += " " & String.Format(" {0}", My.Application.Info.Version.ToString)

        LbDM_All.Value = CInt(frm_Login.LocalDB.GetSingleValue("Select * from PRODUCTION where Definition = '" & frm_takeHarness.harness & "' ", "QUANTITY")) 'ekrandan girilen konveyorun işlem sayısı
        identifed_time = CInt(frm_Login.LocalDB.GetSingleValue("Select * from PRODUCTION where Definition = '" & frm_takeHarness.harness & "' ", "Process_Time")) 'işlem süresi
        critical_Value = CInt(frm_Login.LocalDB.GetSingleValue("Select * from PRODUCTION where Definition = '" & frm_takeHarness.harness & "' ", "Critical")) 'kısık sesli buzzerın konveyorun hareketini yapıcağı kritik zaman

        LbDM_completed.Value = frm_takeHarness.startindex
        ProgressBar1.Maximum = identifed_time


        'Konveyörün başlangıç pozisyonunun koşulları

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

            LbBut_StartStop.Enabled = True

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

    Private Sub tmr_countDown_Tick(sender As Object, e As EventArgs) Handles tmr_countDown.Tick
        'progresbarın,barierin kontrolü,orange sarı buton operatorlerin sarı butona basma durumunda bir sonraki prosesi beklemesi
        If Not red Then
            'LbDM_completed.Value += 1

            If count < CInt(identifed_time / 4) Then
                ProgressBar1.ForeColor = Color.LimeGreen
                inc(ProgressBar1)
                'ProgressBar1.Value += 1
                count += 1


            ElseIf (count >= CInt(identifed_time / 4)) And count < CInt(identifed_time / 2) Then
                ProgressBar1.ForeColor = Color.Yellow
                ProgressBar1.Value += 1
                count += 1

            ElseIf (count >= CInt(identifed_time / 2)) And count < (identifed_time - critical_Value) Then
                ProgressBar1.ForeColor = Color.Orange
                inc(ProgressBar1)
                'ProgressBar1.Value += 1
                count += 1

            ElseIf count >= (identifed_time - critical_Value) And count < identifed_time Then
                ProgressBar1.ForeColor = Color.Red
                inc(ProgressBar1)
                'ProgressBar1.Value += 1
                count += 1
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 1, res, req)
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Barrier), frm_Login.Barrier.active, res, req)

            ElseIf count = identifed_time Then
                tmr_countDown.Enabled = False
                tmr_Process.Enabled = True
                'barrier = True
                count = 0
                stepProcess = CaseSteps.ThereExist
                'LbDM_completed.Value += 1
                startTime = Now
            End If
        Else
            tmr_countDown.Enabled = False
            tmr_Process.Enabled = False
            LbBut_StartStop.Label = "START"

            LbBut_StartStop.ButtonColor = Color.Green
            txt_statistic.Text = fff("Operator Pushed the Yellow Button.")
        End If

    End Sub

    Private Sub tmr_Process_Tick(sender As Object, e As EventArgs) Handles tmr_Process.Tick

        tmr_Process.Enabled = False

        Select Case stepProcess

            Case CaseSteps.ThereExist

                If (Not ((frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftISHarness), Me)) Or 'harness kontrolü yapan iki sensörde yok diyorsa
                   (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Left2ISharness), Me)))) And (Not red) Then

                    stepProcess += 1
                    barrier1 = True

                    startTime = Now 'Bu yapı girilen delay time ne kadarsa orn 5 sn startimedan 5 sn sonrasına kadar işlem sağlanmıyorsa else düşürüyor

                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Harness Exist") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftISHarness), Me).ToString & vbCrLf &
                                                  fff("Harnes Exist2") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Left2ISharness), Me).ToString & vbCrLf

                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','ThereExist','" & dummy & "', datetime('now'),null)")
                            barrier1 = False
                            systemerorled = True
                            txt_statistic.Text = dummy

                            frm_msg.Activate()
                            frm_msg.Show()

                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.LeftLiftDown

                ' sol asansor asagi on sartlari ''ikisensor daha var
                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me) And 'A5 kilidi kilitli
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And '4.sensor var
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And 'sol piston yukarda
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And '5.sensor araba yok dedi
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me) And  'A3 kilitli
                    (Not ((frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftISHarness), Me)) Or
                    (frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Left2ISharness), Me)))) And (Not red) Then

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLift), frm_Login.LeftLift.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Right Bottom 2. Lock UP") & "   (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndLockUp), Me).ToString & vbCrLf &
                                                  fff("Left Top Lock UP") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf &
                                                  fff("Left Piston UP") & "            (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                  fff("4. Sensor Active") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf

                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','LeftLiftDown','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True

                            MsgBox(dummy)

                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If

                End If


            Case CaseSteps.isLeftLiftDownAndTrayisOut

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me) And 'Sol asansör aşağıda
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And ' 5. sensör(sol asansor alt)  çekmece yok
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me)) And (Not red) Then '6.sensor çekmece yok

                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Left piston Bottom") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "        (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                 fff("6. Sensor De-Active") & "         (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft2ndDown), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isLeftLiftDownAndTrayisOut','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)

                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.LeftLiftUpPistonRight

                ' sol asansor yukarı ön koşulları
                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me) And '9. sensor var
                        (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me)) And '5. sensor yok
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me) And 'sol piston aşağıda
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And' 4.sensor görmicek
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me) And (Not red) Then 'A5 kilitli

                    ' isik bariyerine voltaj ver + boolean active et
                    'barrier = True
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLift), frm_Login.LeftLift.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.up, res, req) ' önceki case de olmazsa koyulabilr
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AbovePiston), frm_Login.AbovePiston.right, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("9. Sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                                  fff("Left Top Lock Up") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftAboveLockUP), Me).ToString & vbCrLf &
                                                  fff("Left piston Bottom") & "    (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLiftPistonDown), Me).ToString & vbCrLf &
                                                  fff("5. Sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stDown), Me).ToString & vbCrLf &
                                                  fff("4. Sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','LeftLiftUpPistonRight', '" & dummy & "',datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If
            Case CaseSteps.isLeftLiftUpAbovePistonRight

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me) And 'Sol asansör yukarda
                  (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me)) And '4.sensor yok
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me) And (Not red) Then 'Üst piston sağda


                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLockAboveLock), frm_Login.LeftLockAboveLock.down, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AbovePiston), frm_Login.AbovePiston.left, res, req)

                    stepProcess += 1
                    barrier2 = True
                    barrier3 = True
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Left Piston UP") & "       (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LeftLifttPistonUp), Me).ToString & vbCrLf &
                                                  fff("Up Piston RIGHT") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonRight), Me).ToString & vbCrLf &
                                                  fff("4. Sensor De-Active") & " (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isLeftLiftUpAbovePistonRight','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            'tmr_Indicator.Enabled = False
                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.isAbovePistonLeft

                If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And '1.sensör araba görmüyorsa
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me) And 'üst piston Soldaysa
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me) And (Not red) Then '4.sensör aktifse

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.LeftLockAboveLock), frm_Login.LeftLockAboveLock.up, res, req)
                    barrier1 = False
                    barrier2 = False
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("1. Sensor De-Active") & "   (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                  fff("Up Piston Left") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.AbovePistonLeft), Me).ToString & vbCrLf &
                                                   fff("4. Sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayLeft1stUp), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isAbovePistonLeft', '" & dummy & "',datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            'tmr_Indicator.Enabled = False
                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.RightLiftDown

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me) And ' Sağ alt 1.Kilit kilitli
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And 'Sağ asansör yukarda
                        (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And ' 3.Sensör görmüyorsa
                    (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And (Not red) Then ' 1.sensör görmüyorsa

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightLift), frm_Login.RightLift.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else

                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("1. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                  fff("3. Sensor De-Active") & "      (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf &
                                                       fff("Right Piston UP") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                                                    fff("Right Bottom 1. Lock UP") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stLockRight), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','RightLiftDown', '" & dummy & "',datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.isRightLiftDown

                If (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me)) And '1. sensör görmüyorsa 
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And '8. sensör aktif
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me) And (Not red) Then 'Sağ asansör aşağıda

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stPiston), frm_Login.RightBelow1stPiston.left, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("1. Sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                   fff("Right Piston Bottom") & "  (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightLiftPistonDown), Me).ToString & vbCrLf &
                                                   fff("8. sensor Active") & "     (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isRightLiftDown', '" & dummy & "',datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.isRightBelow1stPiston

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me) And (Not red) Then 'Sağ alt 1. piston solda

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stPiston), frm_Login.RightBelow1stPiston.right, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stLock), frm_Login.RightBelow1stLock.down, res, req)

                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Right Bottom 1. Piston LEFT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonLeft), Me).ToString
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isRightBelow1stPiston','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If



            Case CaseSteps.RightLiftUp

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me) And 'Sağ alt 1. piston sağda
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me)) And  ' 8. sensör aktif değil
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me)) And '3.sensor görmüyorsa sonradan eklendi 20.06
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me)) And '10. sensör görmicek sonradan eklendi 20.06
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me)) And '2.sensör görmüyorsa
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me) And '1. sensor aktif
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me) And (Not red) Then '9. sensör aktif

                    'barrier = True
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndPiston), frm_Login.RightBelow2ndPiston.left, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow1stLock), frm_Login.RightBelow1stLock.up, res, req)
                    'System.Threading.Thread.Sleep(500)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightLift), frm_Login.RightLift.up, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then

                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("1. Sensor Active") & "         (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight1stUp), Me).ToString & vbCrLf &
                                                 fff("9. Sensor Active") & "          (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                              fff("Right Bottom 1. Piston RIGHT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow1stPistonRight), Me).ToString & vbCrLf &
                                                  fff("10. sensor De-Active") & "    (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.IsTrayRightDown), Me).ToString & vbCrLf &
                                                  fff("3. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndUp), Me).ToString & vbCrLf &
                                                  fff("2. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRightUp), Me).ToString & vbCrLf &
                                                  fff("8. sensor De-Active") & "     (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','RightLiftUp','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
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
                    'barrier = False
                    systemerorled = True
                    MsgBox(dummy)
                    tmr_countDown.Enabled = False
                    frm_mainForm.Show()
                    Me.Close()
                    Exit Sub

                ElseIf frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) Then
                    stepProcess += 1

                End If


            Case CaseSteps.isRightBelow2ndPiston

                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me) And (Not red) Then 'Sağ alt 2. piston solda

                    'barrier = False
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndPiston), frm_Login.RightBelow2ndPiston.right, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.down, res, req)
                    stepProcess += 1
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("Right Bottom 2. Piston LEFT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonLeft), Me).ToString
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isRightBelow2ndPiston', '" & dummy & "',datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)


                            'tmr_Indicator.Enabled = False
                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

            Case CaseSteps.isRight1stTray


                If frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me) And '8. sensor aktif
                   (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me)) And '9. sensor aktif değil
                    frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me) And 'sağ asansör yukarda
                   frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me) And (Not red) Then 'Sağ alt 2. piston sağda 

                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.RightBelow2ndLock), frm_Login.RightBelow2ndLock.up, res, req)
                    frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 0, res, req)

                    barrier3 = False

                    stepProcess = CaseSteps.EndofProcess
                    startTime = Now
                Else
                    If Not red Then
                        endTime = Now
                        elapsed = endTime.Subtract(startTime)
                        If elapsed.TotalSeconds > delaytime Then
                            Dim dummy As String = fff("8. sensor Active") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight2ndDown), Me).ToString & vbCrLf &
                                                   fff("Right Piston UP") & "      (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RigtLiftPistonUp), Me).ToString & vbCrLf &
                                                  fff("9. sensor De-Active") & "  (false) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.TrayRight3rdDown), Me).ToString & vbCrLf &
                                           fff("Right Bottom 2. Piston RIGHT") & " (true) : " & frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.RightBelow2ndPistonRight), Me).ToString
                            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('System','isRight1stTray','" & dummy & "', datetime('now'),null)")
                            'barrier = False
                            systemerorled = True
                            MsgBox(dummy)

                            tmr_countDown.Enabled = False
                            frm_mainForm.Show()
                            Me.Close()
                            Exit Sub
                        End If
                    Else
                        txt_statistic.Text = fff("Red Button Pressed !")
                    End If
                End If

        End Select

        If stepProcess <> CaseSteps.EndofProcess Then
            tmr_Process.Enabled = True
           
        Else

            If LbDM_completed.Value < LbDM_All.Value Then
                LbDM_completed.Value += 1
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Production','" & frm_takeHarness.harness.ToString & "','" & LbDM_completed.Value.ToString & " of " & LbDM_All.Value.ToString & "',datetime('now'),null)")
                tmr_countDown.Enabled = True

                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Barrier), frm_Login.Barrier.pasive, res, req)
                ProgressBar1.Value = 0
            Else

                frm_takeHarness.Show()
                Me.Close()
            End If

        End If

    End Sub

    Private Sub LbBut_StartStop_Click(sender As Object, e As EventArgs) Handles LbBut_StartStop.Click

        If LbBut_StartStop.Label = "START" Then
            tmr_Indicator.Enabled = True
            tmr_countDown.Enabled = True
            LbBut_StartStop.Label = "STOP"
            LbBut_StartStop.ButtonColor = Color.Red

        Else
            tmr_Indicator.Enabled = False
            tmr_countDown.Enabled = False
            LbBut_StartStop.Label = "START"
            LbBut_StartStop.ButtonColor = Color.Green
        End If


    End Sub

    Private Sub tmr_Indicator_Tick(sender As Object, e As EventArgs) Handles tmr_Indicator.Tick

        tmr_Indicator.Enabled = False

        checkState("X0")
        checkState("X20")
        checkState("X30")
        checkState("X40")
        checkState("X50")
        checkState("X60")
        checkState("X70")

        'Acil stop ve barrierlerin kontrolünü yapıyoruz.
        If ((Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LightBarrierSensor1), Me)) And (barrier1 = True)) Or
                ((Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LightBarrierSensor2), Me)) And (barrier2 = True)) Or
                ((Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.LightBarrierSensor3), Me)) And (barrier3 = True)) Or
          (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.EmergenyStop2), Me)) Or
          (Not frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.EmergenyStop), Me)) Then

            frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.ValfBar), frm_Login.ValfBar.pasive, res, req) 'pasive havayı kesme
            frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer2), 0, res, req)
            frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)

            Dim dummy As String = fff("One of the following has occured ") & vbCrLf &
                                  fff("Light Barrier") & vbCrLf &
                                  fff("Emergeny Stop") & vbCrLf &
                                  fff("For StartUp position Please call maintenance man !") & vbCrLf
            frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Emergency','" & stepProcess & "','" & dummy & "', datetime('now'),null)")
            MsgBox(dummy)
            Me.Close()
            Exit Sub
        End If


        'Operatörlerin lambalarının durumları
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

        If OrangeStates(0) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Orange), Me) Then
            OrangeStates(0) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Orange), Me)
            If OrangeStates(0) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator1Orange', ' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("1. Operator pressed Yellow Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator1Orange' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("1. Operator Un-Pressed Yellow Button")
            End If
        End If

        If OrangeStates(1) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Orange), Me) Then
            OrangeStates(1) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Orange), Me)
            If OrangeStates(1) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator2Orange',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("2. Operator pressed Yellow Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator2Orange' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("2. Operator Un-Pressed Yellow Button")
            End If
        End If

        If OrangeStates(2) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Orange), Me) Then
            OrangeStates(2) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Orange), Me)
            If OrangeStates(2) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator3Orange',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("3. Operator pressed Yellow Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator3Orange' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("3. Operator Un-Pressed Yellow Button")
            End If
        End If

        If OrangeStates(3) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Orange), Me) Then
            OrangeStates(3) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Orange), Me)
            If OrangeStates(3) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator4Orange',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("4. Operator pressed Yellow Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator4Orange' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("4. Operator Un-Pressed Yellow Button")
            End If
        End If

        If OrangeStates(4) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Orange), Me) Then
            OrangeStates(4) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Orange), Me)
            If OrangeStates(4) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator5Orange',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("5. Operator pressed Yellow Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator5Orange' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("5. Operator Un-Pressed Yellow Button")
            End If
        End If

        If RedStates(0) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Red), Me) Then
            RedStates(0) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Red), Me)
            If RedStates(0) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator1Red', ' Operatör butona bastı' ,datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("1. Operator pressed Red Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator1Red' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("1. Operator Un-Pressed Red Button")
            End If
        End If

        If RedStates(1) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Red), Me) Then
            RedStates(1) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Red), Me)
            If RedStates(1) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator2Red',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("2. Operator pressed Red Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator2Red' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("2. Operator Un-Pressed Red Button")
            End If
        End If

        If RedStates(2) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Red), Me) Then
            RedStates(2) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Red), Me)
            If RedStates(2) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator3Red',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("3. Operator pressed Red Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator3Red' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("3. Operator Un-Pressed Red Button")
            End If
        End If

        If RedStates(3) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Red), Me) Then
            RedStates(3) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Red), Me)
            If RedStates(3) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator4Red',' Operatör butona bastı' , datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("4. Operator pressed Red Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator4Red' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("4. Operator Un-Pressed Red Button")
            End If
        End If

        If RedStates(4) <> frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Red), Me) Then
            RedStates(4) = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Red), Me)
            If RedStates(4) Then
                frm_Login.LocalDB.ExecuteNonQuery("insert into STATISTICs values ('Operator','Operator5Red', ' Operatör butona bastı' ,datetime('now'),null)")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 1, res, req)
                txt_statistic.Text = fff("5. Operator pressed Red Button")

            Else
                frm_Login.LocalDB.ExecuteNonQuery("update STATISTICs set finishedTime = datetime('now') " &
                                        "where StartingTime = (select StartingTime from  STATISTICs where info = 'Operator5Red' " &
                                        "and FinishedTime is null order by StartingTime desc limit 1 ) ")
                frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.Buzzer1), 0, res, req)
                txt_statistic.Text = fff("5. Operator Un-Pressed Red Button")
            End If
        End If
        'herhangi bir kırmızı buton basıldığında 1 olan boolean değer
        red = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Red), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Red), Me) Or systemerorled
        'herhangi bir turuncu butıon basıldığında 1 olan boolean değer
        orange = frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator1Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator2Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator3Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator4Orange), Me) Or
                        frm_Login.getInputStatus(frm_Login.generateInputId(frm_Login.INPUTs.Operator5Orange), Me)


        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonRed), red, res, req)  'büyük andondaki kırmızı lambayı yakar
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonOrange), orange, res, req) 'büyük andondaki turuncu lambayı yakar
        frm_Login.PLCDO(frm_Login.generateOutputId(frm_Login.OUTPUTs.AndonGreen), Not (red Or orange), res, req) 'büyük andondaki yeşi lambayı yakar

        Yellow_BigAndom.State = orange
        Red_BigAndom.State = red
        Green_BigAndom.State = Not (red Or orange)

        tmr_Indicator.Enabled = True
    End Sub

    Private Sub frm_information_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frm_takeHarness.Show()
        frm_takeHarness.Close()
        frm_mainForm.Show()
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