Imports System.Collections.Specialized
Imports System.IO, System.Net, System.Text, System.Text.RegularExpressions, System.Console
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Management
Module Module1
    Dim cpuinfo As String
    Dim banner As String = "   _____ ______ _______   _____ _   _ ______ ____  _____  __  __       _______ _____ ____  _   _ 
  / ____|  ____|__   __| |_   _| \ | |  ____/ __ \|  __ \|  \/  |   /\|__   __|_   _/ __ \| \ | |
 | |  __| |__     | |      | | |  \| | |__ | |  | | |__) | \  / |  /  \  | |    | || |  | |  \| |
 | | |_ |  __|    | |      | | | . ` |  __|| |  | |  _  /| |\/| | / /\ \ | |    | || |  | | . ` |
 | |__| | |____   | |     _| |_| |\  | |   | |__| | | \ \| |  | |/ ____ \| |   _| |_ |__| | |\  |
  \_____|______|  |_|    |_____|_| \_|_|    \____/|_|  \_\_|  |_/_/    \_\_|  |_____\____/|_| \_|

                                      FOLLOW ME ON INSTAGRAM => instagram.com/xaed or @xaed                                                                                                 
"


    Sub Main()

        Dim pubip, hwid, privip As String
        pubip = getpubip()
        hwid = gethwid()
        privip = getprivip()
again:
        Console.Clear()
        Write(banner)
        Console.ForegroundColor = ConsoleColor.Blue
        Write(vbNewLine + "[1] Get Public IP | [2] Get Private IP | [3] Get HWID | [4] Get ALL" + vbNewLine + "[+] Choice : ")
        Dim choice As String = ReadLine()
        Console.ForegroundColor = ConsoleColor.Green
        If choice = "1" Then
            Write(vbNewLine & "[+] Public IP : " & pubip)
            MsgBox("Public IP : " & pubip)
            Write(vbNewLine & "[X] Press Enter To Exit ...")
            ReadLine()
            Environment.Exit(0)
        ElseIf choice = "2" Then
            Write(vbNewLine & "[+] Private IP : " & privip)
            MsgBox("Private IP : " & privip)
            Write(vbNewLine & "[X] Press Enter To Exit ...")
            ReadLine()
            Environment.Exit(0)
        ElseIf choice = "3" Then
            Write(vbNewLine & "[+] HWID : " & hwid)
            MsgBox("HWID : " & hwid)
            Write(vbNewLine & "[X] Press Enter To Exit ...")
            ReadLine()
            Environment.Exit(0)
        ElseIf choice = "4" Then
            Write(vbNewLine & "[+] Public IP : " & pubip & vbNewLine & "[+] Private IP : " & privip & vbNewLine & "[+] HWID : " & hwid)
            MsgBox("[+] Public IP : " & pubip & vbNewLine & "[+] Private IP : " & privip & vbNewLine & "[+] HWID : " & hwid)
            Write(vbNewLine & "[X] Press Enter To Exit ...")
            ReadLine()
            Environment.Exit(0)
        Else
            MsgBox("Wrong Choice !")
            GoTo again
        End If
    End Sub
    Function getpubip() As String
        Dim asa As String
        Using aa As New WebClient
            asa = aa.DownloadString("https://api.ipify.org/?format=json")
        End Using
        Return Regex.Match(asa, """ip"":""(.*?)""").Groups(1).Value
    End Function
    Function gethwid()
        Dim mc As New ManagementClass("win32_processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances
        For Each mo As ManagementObject In moc
            If cpuinfo = "" Then
                cpuinfo = mo.Properties("processorID").Value.ToString
                Exit For
            End If
        Next
        Return cpuinfo
    End Function
    Function getprivip()
        Dim hostname As String = Net.Dns.GetHostName
        Dim ipaddress As String = CType(Net.Dns.GetHostByName(hostname).AddressList.GetValue(0), Net.IPAddress).ToString
        Return ipaddress
    End Function
End Module
