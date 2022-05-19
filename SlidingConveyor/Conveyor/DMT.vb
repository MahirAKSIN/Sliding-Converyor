'Imports Microsoft.Win32 ' for the registry table
Imports System.Net ' for the ip address
'Imports System.Runtime.InteropServices ' for the P/Invoke
Imports System.Text ' for the StringBuilder

Public Class DMT
    '// Data Access
    Declare Auto Function RequestData Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal func_code As Integer, ByRef sendbuf As Byte, ByVal sendlen As Integer) As Integer
    Declare Auto Function ResponseData Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByRef slave_addr As Integer, ByRef func_code As Integer, ByRef recvbuf As Byte) As Integer

    '// Serial Communication
    Declare Auto Function OpenModbusSerial Lib "DMT.dll" (ByVal conn_num As Integer, ByVal baud_rate As Integer, ByVal data_len As Integer, ByVal parity As Char, ByVal stop_bits As Integer, ByVal modbus_mode As Integer) As Integer
    Declare Auto Sub CloseSerial Lib "DMT.dll" (ByVal conn_num As Integer)
    Declare Auto Function GetLastSerialErr Lib "DMT.dll" () As Integer
    Declare Auto Sub ResetSerialErr Lib "DMT.dll" ()

    '// Socket Communication
    Declare Auto Function OpenModbusTCPSocket Lib "DMT.dll" (ByVal conn_num As Integer, ByVal ipaddr As Integer) As Integer
    Declare Auto Sub CloseSocket Lib "DMT.dll" (ByVal conn_num As Integer)
    Declare Auto Function GetLastSocketErr Lib "DMT.dll" () As Integer
    Declare Auto Sub ResetSocketErr Lib "DMT.dll" ()
    Declare Auto Function ReadSelect Lib "DMT.dll" (ByVal conn_num As Integer, ByVal millisecs As Integer) As Integer

    '// MODBUS Address Calculation
    Declare Auto Function DevToAddrW Lib "DMT.dll" (ByVal series As String, ByVal device As String, ByVal qty As Integer) As Integer

    '// Wrapped MODBUS Funcion : 0x01
    Declare Auto Function ReadCoilsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_r As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x02
    Declare Auto Function ReadInputsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_r As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x03
    Declare Auto Function ReadHoldRegsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_r As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer
    Declare Auto Function ReadHoldRegs32W Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_r As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x04
    Declare Auto Function ReadInputRegsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_r As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x05		   
    Declare Auto Function WriteSingleCoilW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x06
    Declare Auto Function WriteSingleRegW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer
    Declare Auto Function WriteSingleReg32W Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x0F
    Declare Auto Function WriteMultiCoilsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer

    '// Wrapped MODBUS Funcion : 0x10
    Declare Auto Function WriteMultiRegsW Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer
    Declare Auto Function WriteMultiRegs32W Lib "DMT.dll" (ByVal comm_type As Integer, ByVal conn_num As Integer, ByVal slave_addr As Integer, ByVal dev_addr As Integer, ByVal qty As Integer, ByRef data_w As UInt32, ByVal req As StringBuilder, ByVal res As StringBuilder) As Integer


End Class
