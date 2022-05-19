Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports LBSoft.IndustrialCtrls.Leds

Public Class frm_Login

    Dim ini As New INIfile(IO.Directory.GetCurrentDirectory() & "\elopar.ini")

    Public LocalDB As New SQLiteTools("Conveyor")

    'Dim hl As New hyperlockusb(CShort(ini.ReadValue("HYPERLOCK", "UserCode")), ini.ReadValue("HYPERLOCK", "DeviceID"))
    'Dim chipher As New Crypt("ab")

    Public lvl As String = String.Empty
    Public UsName As String = String.Empty

    Public language As String = CInt(ini.ReadValue("SYSTEM", "Lang"))
    'Dim List_lng As List(Of String) = Nothing
    'Dim List_LngName As List(Of String) = Nothing

    Dim List_lng As List(Of String) = Nothing
    Dim List_LngName As List(Of String) = Nothing

    Dim Logger As New LogFile(IO.Directory.GetCurrentDirectory() & "\LOG_DELTA")
    ' DMT Declerations 
    Public Shared hDMTDll As System.IntPtr ' handle of a loaded dll , used for dynamic link 
    Delegate Sub DelegateClose(ByVal conn_num As Integer) ' function pointer for disconnection

    Declare Auto Function LoadLibrary Lib "kernel32.dll" (ByVal dllPath As String) As IntPtr
    Declare Auto Function FreeLibrary Lib "kernel32.dll" (ByVal hDll As IntPtr) As Boolean

    Public Shared CloseModbus As DelegateClose
    Dim ip As Integer

    Dim strDev As String
    Dim dev_qty As Integer
    Dim addr As Integer

    Public Shared conn_num As Integer = 0
    Dim status As Integer = 0
    Dim comm_type As Integer = 1 ' 0:RS-232 , 1:Ethernet
    Dim strProduct As String = "DVP"
    Dim slave_addr As Integer = 1

    Public data_from_dev(7) As UInt32

    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    Public error_string As String

    Public Shared backup As String
    Public Shared oldVersionAddress As String
    Public Shared newVersionAddress As String
    Public Shared progName As String
    Public Shared versionUpdate As String

    Dim OldVersion As String
    Dim NewVersion As String

    Dim isNew As Boolean = False

    Dim firstRun As String = ini.ReadValue("SYSTEM", "FirstRun")
    Dim availableDrive As Char = ini.ReadValue("SYSTEM", "AvailableDrive")

    Public Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As Integer) As Integer

    Public Const RESOURCETYPE_DISK As Long = &H1
    Private Const ERROR_BAD_NETPATH = 53&
    Private Const ERROR_NETWORK_ACCESS_DENIED = 65&
    Private Const ERROR_INVALID_PASSWORD = 86&
    Private Const ERROR_NETWORK_BUSY = 54&

    Public Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As String
        Public lpRemoteName As String
        Public lpComment As String
        Public lpProvider As String
    End Structure

#Region "Socket Error Definitions"
    Enum SocketErr
        Nosocketerror
        Invalidsocketerrorcode
        Acceptingremotesocketerror
        Socketcannotbebound
        Bufferoverflows
        Socketcannotbeconnected
        Sockethasbeendisconnected
        FilelengthdoesNotmatchtheexpectedvalue
        Filemodificationtimeanddatesdonotmatch
        Afilesystemerroroccurs
        Acquiringsocketoptionerror
        Couldnotresolvehostname
        Initializationerror
        Listenerror
        Acquiringpeernameerror
        Unknownprotocolrequested
        Receivingerror
        Requesttimeout
        Unknownservicerequested
        Incorrectsocketoptionsettings
        Acquiringsocketnameerror
        Unknownsockettyperequested
        Transmissionerror
    End Enum

#End Region

#Region "INPUT Definitions"
    Public Enum INPUTs
        LeftLiftPistonDown = 20
        LeftLifttPistonUp
        LeftAboveLockUP
        LeftAboveLockDown
        RightBelow2ndPistonRight
        RightBelow2ndPistonLeft
        RightBelow2ndLockDown
        RightBelow2ndLockUp
        AbovePistonLeft = 30
        AbovePistonRight
        RightBelow1stPistonLeft
        RightBelow1stPistonRight
        RightBelow1stLockRight
        RightBelow1stLockLeft
        RigtLiftPistonUp
        RightLiftPistonDown
        TrayRight1stUp = 40
        TrayRightUp
        TrayRight2ndUp
        TrayLeft1stUp
        TrayLeft1stDown
        TrayLeft2ndDown
        TrayLeft2ndUp
        TrayRight2ndDown
        Operator5Red = 50
        Operator5Orange
        Operator4Red
        Operator4Orange
        TrayRight3rdDown = 60
        Operator1Red
        Operator1Orange
        Operator2Red
        Operator2Orange
        Operator3Red
        Operator3Orange
        IsTrayRightDown
        LightBarrierSensor1 = 70 'ışık bariyeri
        LeftISHarness
        Left2ISharness
        SensorBar
        EmergenyStop  'Low-Active
        EmergenyStop2 'basıldığında 1 basılmadıgında 0
        LightBarrierSensor2
        LightBarrierSensor3
    End Enum

#End Region

    Public Function generateInputId(ByVal id As INPUTs) As String
        Return "X" & id
    End Function

    Public Function getInputStatus(ByVal inputStr As String, ByVal control As Control) As Boolean
        Dim b As Boolean = Nothing
        Dim c As LBLed
        For Each ctrl As Control In control.Controls
            If (TypeOf ctrl Is LBLed) And (ctrl.Name.ToString.StartsWith("X")) Then
                c = DirectCast(ctrl, LBLed)
                If c.Name = inputStr Then
                    If c.State = LBLed.LedState.On Then
                        b = True
                    Else
                        b = False
                    End If
                End If
            End If
        Next
        Return b
    End Function

#Region "OUTPUT Definitions"
    Public Enum OUTPUTs
        RightBelow1stLock = 20
        RightBelow1stPiston
        RightBelow2ndLock
        RightBelow2ndPiston
        LeftLockAboveLock
        AbovePiston
        RightLift
        LeftLift
        Andon5Red = 30
        Andon5Orange
        AndonRed
        AndonGreen
        AndonOrange
        Andon1Red = 40
        Andon1ORange
        Andon2Red
        Andon2Orange
        Andon3Red
        Andon3Orange
        Andon4Red
        Andon4Orange
        Buzzer1 = 60
        Buzzer2
        Barrier
        ValfBar = 67

    End Enum

#Region "OUTPUT Directions"
    Public Enum RightBelow1stLock
        up = 0
        down
    End Enum

    Public Enum RightBelow1stPiston ' ???
        right = 0
        left
    End Enum

    Public Enum RightBelow2ndLock
        up = 0
        down
    End Enum

    Public Enum RightBelow2ndPiston ' ???
        right = 0
        left
    End Enum

    Public Enum LeftLockAboveLock
        up = 0
        down

    End Enum

    Public Enum RightLift
        up = 0
        down
    End Enum

    Public Enum LeftLift
        up = 0
        down

    End Enum

    Public Enum AbovePiston ' ???
        left = 0
        right
    End Enum

    Public Enum Barrier 'ışık bariyeri
        pasive = 0
        active
    End Enum

    Public Enum ValfBar
        pasive = 0
        active
    End Enum

#End Region

#End Region

    Public Function generateOutputId(ByVal id As OUTPUTs) As String
        Return "Y" & id
    End Function


    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load


#If DEBUG Then

        LocalDB.ExecuteNonQuery("DELETE FROM MESSAGES WHERE lng = 0 ")
        Dim path As String = AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\Debug\", "")
        Dim rx As New Regex("fff\(\""(.*?)\""\)")
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(path, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.vb")
            If Not foundFile.Contains("Designer") And foundFile.Contains("frm_") Then
                Dim lines() As String = System.IO.File.ReadAllLines(foundFile)
                For Each line In lines
                    For Each match In rx.Matches(line)
                        If LocalDB.isThere("SELECT * FROM MESSAGES WHERE (lng = 0) AND (key = '" & match.ToString.Replace("fff(""", "").Replace(""")", "") & "') ") Then
                            LocalDB.ExecuteNonQuery("INSERT INTO MESSAGES VALUES(0,'" & match.ToString.Replace("fff(""", "").Replace(""")", "") & "','" & match.ToString.Replace("fff(""", "").Replace(""")", "") & "') ")
                        End If
                    Next
                Next
            End If
        Next
        LocalDB.ExecuteNonQuery("DELETE FROM MESSAGES WHERE key = '"""", ""' ")

        FindControlRecursive(Me)
#Else
        AssignControlRecursive(Me)
#End If


        'If firstRun = "0" Then
        '    availableDrive = firstavaliabledrive()
        '    MapDrive(availableDrive, "\\" & ip & newVersionAddress)
        '    ini.WriteValue("SYSTEM", "FirstRun", "1")
        'End If


        'newVersionAddress = availableDrive & ":"
        'backup = Application.StartupPath & "\BackUp"
        'oldVersionAddress = Application.StartupPath
        'newVersionAddress = ini.ReadValue("SYSTEM", "NewVersionAddress")
        'progName = My.Application.Info.AssemblyName & ".exe"
        'versionUpdate = Application.StartupPath

        'If System.IO.File.Exists(newVersionAddress & "\" & progName) Then 'Lokasyonda dosya var mı?

        '    OldVersion = FileVersionInfo.GetVersionInfo(oldVersionAddress & "\" & progName).FileVersion
        '    NewVersion = FileVersionInfo.GetVersionInfo(newVersionAddress & "\" & progName).FileVersion

        '    isNew = CompareVersions(OldVersion, NewVersion)

        '    If isNew Then 'Dosyanın versiyonu daha yeni mi?

        '        MsgBox(fff("The Program s new version is exist. Please wait for us to update version."), MsgBoxStyle.OkOnly)

        '        If Not isFileOpen(newVersionAddress & "\" & progName) Then 'Dosya Kullanımda mı? - ana programda da yapmak gerekicek!
        '            Dim myFile As New System.Diagnostics.Process
        '            With myFile
        '                .StartInfo.UseShellExecute = True
        '                .StartInfo.WorkingDirectory = versionUpdate & "\"
        '                .StartInfo.FileName = "VersionUpdate.exe"
        '                .StartInfo.Arguments = " """ & backup & """ """ & oldVersionAddress & """ """ & newVersionAddress & """ """ & progName & """ "
        '                .StartInfo.Verb = "runas"
        '            End With
        '            myFile.Start()

        '            Environment.Exit(0)
        '        Else
        '            MsgBox(("This Update process can't working. Because another computer is updating. The process will be retried later."))
        '        End If

        '    End If
        'End If

        List_lng = LocalDB.PopulateComboBox("Select lng from LANGs", "lng", False)
        List_LngName = LocalDB.PopulateComboBox("Select  LngName from LANGs", "LngName", False)

        ComboIcon1.ImageList = (LocalDB.GetImageS("select LngPic from LANGs order by lng"))

        For i = 0 To List_lng.Count - 1
            ComboIcon1.Items.Add(New ComboBoxIconItem(List_LngName.Item(i).ToString(), CInt(List_lng.Item(i).ToString())))
        Next

        ComboIcon1.SelectedIndex = language

        Me.Text += " " & String.Format(" {0}", My.Application.Info.Version.ToString)


        ' DLL Loader
        Dim dllpath As String
        dllpath = System.Environment.CurrentDirectory
        dllpath = dllpath.Replace("bin\Debug", "")
        dllpath = dllpath.Replace("\\", "\\\\")
        dllpath = dllpath.Insert(dllpath.Length, "DMT.dll") ' obtain the relative path where the DMT.dll resides
        hDMTDll = LoadLibrary(dllpath) ' explicitly link to DMT.dll        Dim path As String


        ' DMT Initialize
        ip = BitConverter.ToInt32(IPAddress.Parse("192.168.1.200").GetAddressBytes(), 0) ' same as inet_addr()
        CloseModbus = AddressOf DMT.CloseSocket

        Dim socketcounter As Integer = 1
        Dim status As Integer = 0
        Dim conn_num As Integer = 0

        ' PLC Initialize 

        Do
            socketcounter += 1
            status = DMT.OpenModbusTCPSocket(conn_num, ip)
            If status < 0 Then
                'Logger.WriteLog("TCP Socket Error :" & DMT.GetLastSocketErr())
                DMT.ResetSocketErr()
            End If
            If socketcounter > 3 Then
                GoTo endofload
            End If
        Loop While (status < 0) And (socketcounter < 5)


endofload:

        If socketcounter > 3 Then
            FreeLibrary(hDMTDll)
            CloseModbus.Invoke(conn_num)
            MsgBox(fff("PLC ethernet cable not connected and / or no PLC feed !") & vbCrLf & fff("The Program is Closing... "))
            Application.Exit()
        End If
        PLCDO(generateOutputId(OUTPUTs.ValfBar), ValfBar.active, res, req)
    End Sub


    Private Sub btn_OK_Login_Click(sender As Object, e As EventArgs) Handles btn_OK_Login.Click
        If Application.OpenForms().Count > 1 Then
            For count As Integer = My.Application.OpenForms.Count - 1 To 1 Step -1

                My.Application.OpenForms(count).Close()

            Next
        End If

        If (txt_Password.Text = "CORLU") Then
            lvl = "Supervisor"
            frm_mainForm.Activate()
            frm_mainForm.Show()
            Me.Hide()
        Else
            If LocalDB.isThere("SELECT * FROM LOGIN WHERE password = '" & txt_Password.Text & "'") Then
                CreateObject("WScript.Shell").Popup(fff("WRONG Password"), 1, "WCT - Wrong Password", 64)
                txt_Password.Text = String.Empty
                txt_Password.Focus()
            Else
                lvl = LocalDB.GetSingleValue("SELECT level FROM LOGIN WHERE password = '" & txt_Password.Text & "' ", "level")
                UsName = LocalDB.GetSingleValue("SELECT username FROM LOGIN WHERE password = '" & txt_Password.Text & "' ", "username")

                If (lvl = "Supervisor") Then
                    frm_mainForm.Activate()
                    frm_mainForm.Show()
                    Me.Hide()

                ElseIf (lvl = "Mechanic") Then
                    frm_mainForm.Activate()
                    frm_mainForm.Show()
                    Me.Hide()

                Else lvl = "Operator"
                    frm_information.Activate()
                    frm_information.Show()
                    Me.Hide()

                End If

            End If

        End If
    End Sub


    Private Sub txt_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btn_OK_Login_Click(sender, e)
            e.Handled = True
        End If
    End Sub


    Private Sub btn_Cancel_Login_Click(sender As Object, e As EventArgs) Handles btn_Cancel_Login.Click
        Me.Close()
    End Sub


    Public Function CompareVersions(currentVersion As String, newVersion As String)

        Dim isGreater As Boolean = False

        Dim oldVersionNumbers = currentVersion.Split(".")
        Dim newVersionNumbers = newVersion.Split(".")

        For i = 0 To oldVersionNumbers.Count - 1
            If newVersionNumbers(i) > oldVersionNumbers(i) Then '= kalkacak !! denemek için konuldu.
                isGreater = True
            End If
        Next

        Return isGreater
    End Function


    Function isFileOpen(FName As String) As Boolean

        Try
            'CREATE A FILE STREAM FROM THE FILE, OPENING IT FOR READ ONLY EXCLUSIVE ACCESS
            Dim FS As IO.FileStream = IO.File.Open(FName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
            'CLOSE AND CLEAN UP RIGHT AWAY, IF THE OPEN SUCCEEDED, WE HAVE OUR ANSWER ALREADY
            FS.Close()
            FS.Dispose()
            FS = Nothing
            Return False
            'Catch ex As IO.IOException
            '    'IF AN IO EXCEPTION IS THROWN, WE COULD NOT GET EXCLUSIVE ACCESS TO THE FILE
            'Return False
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                ' do something here, either close the file if you have a handle, show a msgbox, retry  or as a last resort terminate the process - which could cause corruption and lose data
                Return True
            End If
            Return True
        End Try

    End Function


    Private Shared Function IsFileLocked(exception As Exception) As Boolean

        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33

    End Function


    Public Sub FindControlRecursive(ByVal parent As Control)

        If parent Is Nothing Then Exit Sub
        If (Not (parent.Tag Is Nothing)) And (parent.Tag <> "") Then
            If LocalDB.isThere("SELECT * FROM CONTROLS WHERE (lng = 0) AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ") Then
                LocalDB.ExecuteNonQuery("INSERT INTO CONTROLS VALUES (0,'" & Me.Name & "','" & parent.Tag.ToString & "','" & parent.Name.ToString & "','" & parent.Text & "')")
            End If
        End If
        For Each child As Control In parent.Controls
            FindControlRecursive(child)
        Next

    End Sub


    Public Sub AssignControlRecursive(ByVal parent As Control)

        If parent Is Nothing Then Exit Sub
        If Not parent.Tag Is Nothing Then
            If Not LocalDB.isThere("Select * from CONTROLS Where lng = " & language & " AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ") Then
                parent.Text = LocalDB.GetSingleValue("SELECT * FROM CONTROLS WHERE (lng = " & language & ") AND (frm = '" & Me.Name & "') AND (typ = '" & parent.Tag.ToString & "') AND (control = '" & parent.Name.ToString & "') ", "txt")
            End If
        End If
        For Each child As Control In parent.Controls
            AssignControlRecursive(child)
        Next

    End Sub


    Public Function fff(ByVal s As String) As String
        If CStr(LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & language & ") and (key = '" & s & "') ", "Value")) <> String.Empty Then
            Return LocalDB.GetSingleValue("select * from MESSAGES where (lng = " & language & ") and (key = '" & s & "') ", "Value")
        Else
            Return LocalDB.GetSingleValue("select * from MESSAGES where (lng = 0) and (key = '" & s & "') ", "Value")
        End If
    End Function


    Public Sub PLCWriteRAM(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByVal reqx As StringBuilder, ByVal resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.WriteMultiRegsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                DMT.ResetSocketErr
                Logger.WriteLog("PLCWriteRAM Error  :" & err.ToString)
                If err = SocketErr.Sockethasbeendisconnected Then
                    DMT.OpenModbusTCPSocket(conn_num, ip)
                End If
            End If
        Loop While (ret < 0)

    End Sub


    Public Sub PLCReadRAM(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByRef reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.ReadHoldRegsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                DMT.ResetSocketErr
                Logger.WriteLog("PLCReadRAM Error  :" & err.ToString)
                If err = SocketErr.Sockethasbeendisconnected Then
                    DMT.OpenModbusTCPSocket(conn_num, ip)
                End If
            End If
        Loop While (ret < 0)

    End Sub


    Public Sub PLCDO(ByVal device As String, ByRef data As UInt32, ByVal reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, 1)
        Dim ret As Integer

        Do
            ret = DMT.WriteSingleCoilW(comm_type, conn_num, slave_addr, addr, data, reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                DMT.ResetSocketErr
                Logger.WriteLog("PLCDO Error  :" & err.ToString)
                If err = SocketErr.Sockethasbeendisconnected Then
                    DMT.OpenModbusTCPSocket(conn_num, ip)
                End If
            End If
        Loop While (ret < 0)

    End Sub


    Public Sub PLCDI(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByRef reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.ReadInputsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                DMT.ResetSocketErr
                Logger.WriteLog("PLCDI Error  :" & err.ToString)
                If err = SocketErr.Sockethasbeendisconnected Then
                    DMT.OpenModbusTCPSocket(conn_num, ip)
                End If
            End If
        Loop While (ret < 0)

    End Sub


    Private Sub ComboIcon1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboIcon1.SelectedIndexChanged
        language = ComboIcon1.SelectedIndex
        ini.WriteValue("SYSTEM", "Lang", language)
    End Sub
    Public Function MapDrive(ByVal DriveLetter As String, ByVal UNCPath As String) As Boolean
        Dim nr As NETRESOURCE
        Dim Username As String
        Dim Password As String

        nr = New NETRESOURCE
        nr.lpRemoteName = UNCPath
        nr.lpLocalName = DriveLetter & ":"
        Username = "YEL\ybed.eloparsupport.c" '(add parameters to pass this if necessary)
        Password = "4321-qwer" '(add parameters to pass this if necessary)
        nr.dwType = RESOURCETYPE_DISK

        Dim result As Integer
        result = WNetAddConnection2(nr, Password, Username, 0)

        If result = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function firstavaliabledrive() As Char
        Dim drives As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim existingdrives() As DriveInfo = DriveInfo.GetDrives()

        For Each drv In existingdrives
            drives = drives.Replace(drv.ToString.Replace(":\", "").ToString, "")
        Next
        For i As Integer = drives.Length - 1 To 0 Step -1
            If Not IO.Directory.Exists(drives(i) & ":\") Then
                Return drives(i)
                Exit For
            End If
        Next

    End Function
End Class