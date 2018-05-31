Module Spool
    '    Private Structure DOCINFO
    '        Public pDocName As String
    '        Public pOutputFile As String
    '        Public pDatatype As String
    '    End Structure

    '    Private Declare Function ClosePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
    '    Private Declare Function EndDocPrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
    '    Private Declare Function EndPagePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
    '    Private Declare Function OpenPrinter Lib "winspool.drv" Alias "OpenPrinterA" (ByVal pPrinterName As String, phPrinter As Long, ByVal pDefault As Long) As Long
    '    Private Declare Function StartDocPrinter Lib "winspool.drv" Alias "StartDocPrinterA" (ByVal hPrinter As Long, ByVal Level As Long, pDocInfo As DOCINFO) As Long
    '    Private Declare Function StartPagePrinter Lib "winspool.drv" (ByVal hPrinter As Long) As Long
    '    Private Declare Function WritePrinter Lib "winspool.drv" (ByVal hPrinter As Long, pBuf As Any, ByVal cdBuf As Long, pcWritten As Long) As Long

    '    Dim lhPrinter As Long
    '    Dim lReturn As Long
    '    Dim lDoc As Long
    '    Dim MyDocInfo As DOCINFO
    '    Dim lpcWritten As Long
    '    Dim Cadena As String

    '    Public Function Iniciar_Impresion(Impresora As String, Titulo As String) As Boolean
    '        lReturn = OpenPrinter(Impresora, lhPrinter, 0)
    '        If lReturn = 0 Then
    '            Iniciar_Impresion = False
    '            Exit Function
    '        End If
    '        Iniciar_Impresion = True
    '        MyDocInfo.pDocName = Titulo
    '        MyDocInfo.pOutputFile = vbNullString
    '        MyDocInfo.pDatatype = vbNullString
    '        lDoc = StartDocPrinter(lhPrinter, 1, MyDocInfo)
    '        Call StartPagePrinter(lhPrinter)
    '    End Function

    '    Public Sub Comprimir_Letra()
    '        Cadena = Chr(15)
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    Public Sub Descomprimir_Letra()
    '        Cadena = Chr(18)
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    'Public Sub Imprimir(Cadena As String, Optional vTipoImp As String)
    '        Cadena = Arreglar_Cadena(Cadena, 164, "ñ")
    '        Cadena = Arreglar_Cadena(Cadena, 165, "Ñ")
    '        Cadena = Arreglar_Cadena(Cadena, 160, "á")
    '        Cadena = Arreglar_Cadena(Cadena, 161, "í")
    '        Cadena = Arreglar_Cadena(Cadena, 162, "ó")
    '        Cadena = Arreglar_Cadena(Cadena, 163, "ú")
    '        Cadena = Arreglar_Cadena(Cadena, 130, "é")
    '        Cadena = Arreglar_Cadena(Cadena, 167, "º")
    '        Dim Draft As String
    '        Select Case vTipoImp
    '            Case "MATRICIAL" : Draft = Chr(27) & "x0"
    '        End Select

    '        Cadena = Draft & Cadena & vbCrLf
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    Private Function Arreglar_Cadena(Cadena As String, Asc_Char As Integer, Caracter As String) As String
    '        Dim X As Integer, Texto As String, A() As String
    '        If InStr(Cadena, Caracter) > 0 Then
    '            A = Split(Cadena, Caracter)
    '            For X = 0 To UBound(A)
    '                Texto = Texto & A(X) & Chr(Asc_Char)
    '            Next
    '            Texto = Left(Texto, Len(Texto) - 1)
    '        Else
    '            Texto = Cadena
    '        End If
    '        Arreglar_Cadena = Texto
    '    End Function

    '    Public Sub Imprimir_Doble_Ancho(Cadena As String)
    '        Cadena = Chr(27) & Chr(87) & Chr(1) & Cadena & Chr(27) & Chr(87) & Chr(0)
    '        Call Imprimir(Cadena, "")
    '    End Sub

    '    Public Sub Lineas_Vacias(Lineas As Integer)
    '        Dim Cadena As String, X As Integer
    '        Cadena = "" & vbCrLf
    '        For X = 1 To Lineas
    '        lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '        Next
    '    End Sub

    '    Private Sub sub_finalice()
    '        lReturn = ClosePrinter(lhPrinter)
    '    End Sub

    '    Public Sub Enddoc()
    '        lReturn = EndDocPrinter(lhPrinter)
    '    End Sub

    '    Public Sub EndPage()
    '        lReturn = EndPagePrinter(lhPrinter)
    '    End Sub

    '    Public Sub Repetir_Caracter(Caracter As String, Numero As Long)
    '        Dim Cadena As String
    '    Cadena = String(Numero, Caracter) & vbCrLf
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    'Private Function Ansi2Ascii(Texto As String, Optional Pos As Long) As String
    '    '    Static Orig As String
    '    '    Static Dest As String
    '    '    Static NumCar As Long
    '    '    If Pos < 1 Then Pos = Len(Texto)
    '    '    Orig = Texto
    '    '    Dest = Space(Pos)
    '    '
    '    '    NumCar = CharToOem(Orig, Dest)
    '    '
    '    '    Ansi2Ascii = Dest
    '    'End Function
    '    '

    '    Public Sub Espaciado0()
    '        Cadena = Chr(27) & "0"
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    Public Sub Espaciado1()
    '        Cadena = Chr(27) & "1"
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    Public Sub Espaciado2()
    '        Cadena = Chr(27) & "2"
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub

    '    Public Sub Espaciado3()
    '        Cadena = Chr(27) & "3"
    '    lReturn = WritePrinter(lhPrinter, ByVal Cadena, Len(Cadena), lpcWritten)
    '    End Sub
    '    Public Sub Expulsar_Papel()
    '        Imprimir(Chr(12), "")
    '    End Sub

End Module
