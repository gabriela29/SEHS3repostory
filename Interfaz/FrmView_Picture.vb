Imports System.Drawing.Printing
Imports System.Drawing.Graphics
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class FrmView_Picture
    Public pFile As String

    Private Sub FrmView_Picture_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyData = Keys.Control + Keys.P Then
            'PrintForm1.Print()
            Dim prd As PrintDocument
            prd = New PrintDocument

            AddHandler prd.PrintPage, AddressOf OnPrintPage

            prd.Print()


        End If
    End Sub

    Private Sub FrmView_Picture_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim req As Net.HttpWebRequest = Net.HttpWebRequest.Create(pFile)
        'req.Credentials = New Net.NetworkCredential("usernamehere", "passwordhere")
        Dim res As Net.HttpWebResponse = DirectCast(req.GetResponse, Net.HttpWebResponse)
        Dim img As Image = New System.Drawing.Bitmap(res.GetResponseStream)
        res.Close()
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = img
    End Sub

    Private Sub OnPrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim hwndForm As IntPtr
        hwndForm = Me.Handle

        Dim hdcDIBSection As IntPtr
        Dim hdcRef As IntPtr
        Dim hbmDIBSection As IntPtr
        Dim hbmDIBSectionOld As IntPtr
        Dim BMPheader As Win32APICall.BITMAPINFOHEADER

        hdcRef = Win32APICall.GetDC(IntPtr.Zero)
        hdcDIBSection = Win32APICall.CreateCompatibleDC(hdcRef)
        Win32APICall.ReleaseDC(IntPtr.Zero, hdcRef)

        BMPheader.biBitCount = 24
        BMPheader.biClrImportant = 0
        BMPheader.biClrUsed = 0
        BMPheader.biCompression = Win32APICall.BI_RGB
        BMPheader.biSize = 40
        BMPheader.biHeight = Me.Height
        BMPheader.biPlanes = 1
        BMPheader.biSizeImage = 0
        BMPheader.biWidth = Me.Width
        BMPheader.biXPelsPerMeter = 0
        BMPheader.biYPelsPerMeter = 0

        hbmDIBSection = Win32APICall.CreateDIBSection(hdcDIBSection, BMPheader, Win32APICall.DIB_RGB_COLORS, _
        IntPtr.Zero, IntPtr.Zero, 0)

        hbmDIBSectionOld = Win32APICall.SelectObject(hdcDIBSection, hbmDIBSection)
        Win32APICall.PatBlt(hdcDIBSection, 0, 0, Me.Width, Me.Height, Win32APICall.WHITENESS)
        Win32APICall.PrintWindow(hwndForm, hdcDIBSection, 0)
        Win32APICall.SelectObject(hdcDIBSection, hbmDIBSectionOld)

        Dim imageFrm As Bitmap
        imageFrm = Image.FromHbitmap(hbmDIBSection)
        e.Graphics.DrawImage(imageFrm, 0, 0)

        Win32APICall.DeleteDC(hdcDIBSection)
        Win32APICall.DeleteObject(hbmDIBSection)
    End Sub

End Class

Public Class Win32APICall

    Public Const DIB_RGB_COLORS = 0
    Public Const BI_RGB = 0
    Public Const WHITENESS = 16711778

    <DllImport("user32.dll", EntryPoint:="PrintWindow", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function PrintWindow(ByVal hWnd As IntPtr, ByVal hDC As IntPtr, ByVal dwFlags As Integer) As UInt32
    End Function

    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Structure BITMAPINFOHEADER
        Dim biSize As Int32
        Dim biWidth As Int32
        Dim biHeight As Int32
        Dim biPlanes As Int16
        Dim biBitCount As Int16
        Dim biCompression As Int32
        Dim biSizeImage As Int32
        Dim biXPelsPerMeter As Int32
        Dim biYPelsPerMeter As Int32
        Dim biClrUsed As Int32
        Dim biClrImportant As Int32
    End Structure

    <DllImport("gdi32.dll", EntryPoint:="CreateDIBSection", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function CreateDIBSection(ByVal hdc As IntPtr, ByRef pbmi As BITMAPINFOHEADER, _
    ByVal iUsage As Int32, ByVal ppvBits As IntPtr, ByVal hSection As IntPtr, _
    ByVal dwOffset As Int32) As IntPtr
    End Function

    <DllImport("gdi32.dll", EntryPoint:="PatBlt", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function PatBlt(ByVal hDC As IntPtr, ByVal nXLeft As Int32, _
        ByVal nYLeft As Int32, ByVal nWidth As Int32, ByVal nHeight As Int32, _
        ByVal dwRop As Int32) As Boolean
    End Function

    <DllImport("gdi32.dll", EntryPoint:="SelectObject", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function SelectObject(ByVal hDC As IntPtr, ByVal hObj As IntPtr) As IntPtr
    End Function

    <DllImport("GDI32.dll", EntryPoint:="CreateCompatibleDC", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function CreateCompatibleDC(ByVal hRefDC As IntPtr) As IntPtr
    End Function

    <DllImport("GDI32.dll", EntryPoint:="DeleteDC", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function DeleteDC(ByVal hDC As IntPtr) As Boolean
    End Function

    <DllImport("GDI32.dll", EntryPoint:="DeleteObject", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function DeleteObject(ByVal hObj As IntPtr) As Boolean
    End Function

    <DllImport("User32.dll", EntryPoint:="ReleaseDC", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Boolean
    End Function

    <DllImport("User32.dll", EntryPoint:="GetDC", SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
    End Function


End Class

