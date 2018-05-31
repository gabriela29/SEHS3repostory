Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Microsoft.Office.Interop
Imports System.IO

Public Class FrmProcesar_Info

  Public pOpcion As Integer, pAlmacen As Integer, pHasta As String, pAnio As Integer, pEmpresa As String, pPLE_txt As Boolean
  Public pmes As Integer, pcodigo_per As Long, pcuenta As String, pswlegal As Boolean
  Public pPeriodo As String, pRUC As String, pNombre_Empresa As String, pNombre_Uni As String, pAlmacenId As Integer
  Public dtLima As DataTable, dtArquipa As DataTable, dtCuzco As DataTable, dtPuno As DataTable, dtPucallpa As DataTable, dtHuancayo As DataTable
  Dim vEmp As Integer, vEmpresa As String

  Private Function Crear_Archivo(ByVal NombreFile As String) As String
    Dim vRuta As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim
    Dim vFile As String = vRuta & NombreFile
    Dim vFile2 As String = vRuta & "C:" & NombreFile

    Try
      If File.Exists(vFile) Then
        Dim sr As New StreamWriter(vFile)
        sr.WriteLine("")
        sr.Close()
      Else
        Dim vsr As New StreamWriter(vFile)
        vsr.WriteLine("")
        'vFile = vFile2
        vsr.Close()
      End If
      Return vFile
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return vFile
    End Try

  End Function

  '=================Inicio Proceso COMPRA VENTA======================================================================
  Private Sub bwPLE_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwPLE.DoWork
    Dim DtData As New DataTable
    ' Dim vUnidad As Integer = 0, vHasta As String = "", vAnio = ""

    If pOpcion = 31 Then
      DtData = ReportesManager.Registro_Venta_PLE(pAnio, pmes, GestionSeguridadManager.gEmpresaId, pAlmacenId)
    ElseIf pOpcion = 32 Then
      DtData = ReportesManager.Registro_Compras_PLE(pAnio, pmes, GestionSeguridadManager.gEmpresaId, pAlmacenId)
    End If

    e.Result = DtData

  End Sub

  Private Sub bwPLE_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwPLE.RunWorkerCompleted

    'If Not bwExcel.IsBusy Then
    '    lblInformacion.Text = "Exportando al Excel..."
    '    picAjax.Visible = True
    '    bwExcel.RunWorkerAsync()
    'End If
    Dim dtTemp As New DataTable
    Dim vFileName As String = "", vRutaFile As String = ""
    If pOpcion = 31 Then
      If pPLE_txt Then
        'Call Grabar txt

        'vFileName = ("LE" & pRUC & pAnio & pmes.ToString("00") & "00" & "14" & "01" & "00" & "00" & "1" & "1" & "1" & "1" & ".txt")
        dtTemp = CType(e.Result, DataTable)
        'Call Exportar_RV_txt(CType(e.Result, DataTable))
        If Not dtTemp Is Nothing Then
          If dtTemp.Rows.Count > 0 Then
            vFileName = dtTemp.Rows(0).Item("archivo").ToString

            If Sunat_Plame.Exportar_RV_txt(FolderBrowserDialog1, dtTemp, pmes, pAnio, vFileName, vRutaFile) Then
              Process.Start(vRutaFile)
              Me.Close()
            End If
          Else
            MessageBox.Show("No hay Data que procesar", "AVISO")
          End If
        Else
          MessageBox.Show("No hay Data que procesar", "AVISO")
        End If

      Else
        Call Exportar_Registro_Ventas(CType(e.Result, DataTable))
      End If
    ElseIf pOpcion = 32 Then

      If pPLE_txt Then
        'Call Grabar txt
        'vFileName = ("LE" & pRUC & pAnio & pmes.ToString("00") & "00" & "08" & "01" & "00" & "00" & "1" & "1" & "1" & "1" & ".txt")
        dtTemp = CType(e.Result, DataTable)
        'Call Exportar_RC_txt(CType(e.Result, DataTable))
        If Not dtTemp Is Nothing Then
          If dtTemp.Rows.Count > 0 Then
            vFileName = dtTemp.Rows(0).Item("archivo").ToString
            If Sunat_Plame.Exportar_RC_txt(FolderBrowserDialog1, dtTemp, pmes, pAnio, vFileName, vRutaFile) Then
              Process.Start(vRutaFile)
              Me.Close()
            End If
          Else
            MessageBox.Show("No hay Data que procesar", "AVISO")
          End If
        Else
          MessageBox.Show("No hay Data que procesar", "AVISO")
        End If
      Else
        Call Exportar_Registro_Compras(CType(e.Result, DataTable))
      End If
    End If
  End Sub
  '=================FIN Proceso COMPRA VENTA======================================================================

  '=================Inicio Registro Ventas======================================================================
  Private Function Exportar_Registro_Ventas(ByVal DtOb As DataTable) As Boolean

    '    Dim V As Long, H As Long, xR As Long
    '    Dim DtRw As DataRow
    '    Dim xPt As String = "", vNroDocPer As String = "0"
    '    Dim vBoleta As Single = 0, vStado As Integer = 0, vCod_Sunat As String = "0"
    '    Dim vEmision As Date, vFRegistro As Date, vMesEmi As Long = 0
    '    On Error GoTo ExpExcel

    '    If Not DtOb.Rows.Count > 0 Then
    '      MsgBox("No hay Registro que Exportar", vbExclamation, "AVISO")
    '      Exit Function
    '    End If
    '    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
    '    Dim oExcel As Excel.ApplicationClass
    '    Dim oBooks As Excel.Workbooks
    '    Dim oBook As Excel.WorkbookClass
    '    Dim oSheet As Excel.Worksheet
    '    Dim oCelda As Excel.Range


    '    ' Inicia Excel y abre el workbook
    '    oExcel = CreateObject("Excel.Application")

    '    oBooks = oExcel.Workbooks
    '    oBook = oExcel.Workbooks.Add

    '    'oBook = oBooks.Open("C:\xxx\registrocompra.xls")

    '    oSheet = oBook.Sheets(1)

    '    'Const ROW_FIRST = 3
    '    'Dim iRow As Int64 = 1

    '    ' Encabezado
    '    'oSheet.Cells(ROW_FIRST, 1) = "ID"
    '    oCelda = oSheet.Range("O1", Type.Missing)
    '    oCelda = oSheet.Range("V1", Type.Missing)
    '    If xPt = "." Then
    '      oCelda.EntireColumn.NumberFormat = "0.00"
    '    Else
    '      oCelda.EntireColumn.NumberFormat = "0,00"
    '    End If
    '    oCelda = oSheet.Range("W1", Type.Missing)
    '    If xPt = "." Then
    '      oCelda.EntireColumn.NumberFormat = "0.000"
    '    Else
    '      oCelda.EntireColumn.NumberFormat = "0,000"
    '    End If
    '    oCelda = oSheet.Range("F1", Type.Missing)
    '    oCelda.EntireColumn.NumberFormat = "00"
    '    oCelda = oSheet.Range("Y1", Type.Missing)
    '    oCelda.EntireColumn.NumberFormat = "00"
    '    oCelda = oSheet.Range("K1", Type.Missing)
    '    oCelda.EntireColumn.ColumnWidth = 15
    '    V = 1
    '    H = 1
    '    xR = 0
    '    picAjax.Visible = False
    '    pb.Visible = True
    '    pb.Minimum = 0
    '    pb.Maximum = 1
    '    pb.Value = 1
    '    pb2.Visible = True
    '    pb2.Minimum = 0
    '    pb2.Maximum = DtOb.Rows.Count
    '    lblInformacion.Text = "Enviando Excel: " & pRUC & " del " & pPeriodo

    '    For Each DtRw In DtOb.Rows
    '      With oSheet
    '        xR = xR + 1

    '        If V <= DtOb.Rows.Count Then
    '          pb2.Value = V
    '        End If
    '        lblData.Text = " RUC: " & DtRw("numero_doc_per")
    '        Application.DoEvents()
    '        'Demas Lineas
    '        .Cells(V, H) = pAnio & pmes.ToString("00") & "00"
    '        .Cells(V, H + 3) = DtRw("emision")
    '        vCod_Sunat = DtRw("codigo_sunat")
    '        'If vCod_Sunat = "14" Then
    '        .Cells(V, H + 4) = "" 'DtRw("cancelacion")
    '        'End If
    '        .Cells(V, H + 5) = DtRw("codigo_sunat").ToString
    '        .Cells(V, H + 6) = DtRw("serie_int").ToString
    '        .Cells(V, H + 7) = DtRw("numero_int").ToString
    '        .Cells(V, H + 8) = 0 'Consolidado no dan derecho fiscal
    '        .Cells(V, H + 9) = DtRw("tipo_doc_per")
    '        vNroDocPer = Trim(DtRw("numero_doc_per"))
    '        If vNroDocPer.Trim = "" Then
    '          vNroDocPer = "0"
    '        End If
    '        .Cells(V, H + 10) = vNroDocPer.Trim  'DtRw("numero_doc_per")
    '        .Cells(V, H + 11) = Mid(DtRw("persona"), 1, 100).Trim
    '        .Cells(V, H + 12) = 0 'rsRex!importe_a
    '        .Cells(V, H + 13) = 0 'rsRex!igv_a
    '        .Cells(V, H + 14) = FormatNumber(CSng(DtRw("total")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 15) = 0 'rsRex!importe_a
    '        .Cells(V, H + 16) = 0 'rsRex!importe_a
    '        .Cells(V, H + 17) = 0 'rsRex!importe_a
    '        .Cells(V, H + 18) = 0 'rsRex!importe_a
    '        .Cells(V, H + 19) = 0 'rsRex!importe_a
    '        .Cells(V, H + 20) = 0 'rsRex!importe_a
    '        .Cells(V, H + 21) = FormatNumber(CSng(DtRw("total")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 22) = "0.000" 'DtRw("tipo_cambio")

    '        .Cells(V, H + 23) = IIf(IsDate(DtRw("fecha_doc_ori")), DtRw("fecha_doc_ori"), "01/01/0001")
    '        .Cells(V, H + 24) = DtRw("cod_doc_ori")
    '        .Cells(V, H + 25) = DtRw("serie_doc_ori")
    '        .Cells(V, H + 26) = DtRw("numero_doc_ori")
    '        .Cells(V, H + 27) = "0" 'DtRw("fob")
    '        vEmision = DtRw("emision")

    '        If CBool(DtRw("estado")) = True And vEmision.Date.Month = pmes And vEmision.Date.Year = pAnio Then  'And (vCod_Sunat = "01" Or vCod_Sunat = "03" Or vCod_Sunat = "15" Or vCod_Sunat = "16") Then
    '          vStado = 1
    '        ElseIf CBool(DtRw("estado")) = False Then
    '          vStado = 2
    '        End If

    '        .Cells(V, H + 28) = vStado 'Estado
    '        .Cells(V, H + 29) = "" 'Libre

    '      End With
    '      'H = H + 1
    '      V = V + 1
    '    Next DtRw

    '    oExcel.Visible = True

    '    Exportar_Registro_Ventas = True
    '    '' Cierra todo
    '    ''oBook.Close(True)
    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oBook)
    '    oBook = Nothing

    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oBooks)
    '    oBooks = Nothing

    '    ''oExcel.Quit()
    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oExcel)
    '    oExcel = Nothing
    '    Me.Close()
    '    Exit Function
    '    '' Cierra todo
    '    ''oBook.Close(True)
    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oBook)
    '    ''oBook = Nothing

    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oBooks)
    '    ''oBooks = Nothing

    '    ''oExcel.Quit()
    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oExcel)
    '    ''oExcel = Nothing

    '    ''ObjExcel = CreateObject("Excel.Application")
    '    ' ''ObjExcel = excelApp.Workbooks.Open("C:\Program Files\DISClient\Templates\TemplateMerge.xls")
    '    ''ObjExcel.Application.Workbooks.Open("c:\xxx\registrocompra.xls")
    'ExpExcel:
    '    MsgBox("Conflicto: " & Err.Description, vbExclamation, "AVISO")
    '    oExcel = Nothing
  End Function

  Private Function Exportar_RV_txt(ByVal Dtp As DataTable) As Boolean

    Const DELIMITADOR As String = "|"
    Dim DtRw As DataRow
    Dim Centro_Costo As Long = 0, V As Long = 1
    Dim vBoleta As Single = 0, vStado As Integer = 0, vCod_Sunat As String = "0"
    Dim vEmision As Date, vMesEmi As Long = 0, vNroDocPer As String = "0"

    ' ruta del fichero de texto
    Dim ARCHIVO_CSV As String = "", vFileName As String = ""
    vFileName = ("LE" & pRUC & pAnio & pmes.ToString("00") & "00" & "14" & "01" & "00" & "00" & "1" & "1" & "1" & "1")
    ARCHIVO_CSV = Crear_Archivo("\" & vFileName & ".txt")  'vNameFile '"C:\ctr_" & cboUnidad_Negocio.Value & "." & Format(CboFecha1.Text, "ddmmyy") & "." & Format(CboFecha2.Text, "ddmmyy") & ".csv"

    Try
      picAjax.Visible = False
      pb.Visible = True
      pb.Minimum = 0
      pb.Maximum = 1
      pb.Value = 1
      pb2.Visible = True
      pb2.Minimum = 0
      pb2.Maximum = Dtp.Rows.Count
      lblInformacion.Text = "excribiendo txt: " & pRUC & " del " & pPeriodo

      'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
      Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'variable para almacenar la línea actual del dataview
        Dim linea As String = String.Empty

        For Each DtRw In Dtp.Rows
          ' vaciar la línea
          linea = String.Empty
          If V <= Dtp.Rows.Count Then
            pb2.Value = V
          End If
          lblData.Text = " RUC: " & DtRw("numero_doc_per")
          Application.DoEvents()
          ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador

          linea = pAnio & pmes.ToString("00") & "00" & DELIMITADOR
          linea = linea & "RV" & V & DELIMITADOR
          linea = linea & "M" & V & DELIMITADOR
          vEmision = DtRw("emision")
          linea = linea & DtRw("emision") & DELIMITADOR
          'vCod_Sunat = DtRw("codigo_sunat")
          'If vCod_Sunat = "14" Then
          'linea = linea & DtRw("cancelacion") & DELIMITADOR
          'Else
          linea = linea & DELIMITADOR
          'End If
          linea = linea & DtRw("codigo_sunat").ToString & DELIMITADOR
          linea = linea & DtRw("serie_int") & DELIMITADOR
          linea = linea & DtRw("numero_int") & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & DtRw("tipo_doc_per").ToString & DELIMITADOR

          vNroDocPer = Trim(DtRw("numero_doc_per"))
          If vNroDocPer.Trim = "" Then
            vNroDocPer = "0"
          End If
          linea = linea & vNroDocPer & DELIMITADOR
          linea = linea & Mid(DtRw("persona"), 1, 60).Trim & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          'FormatNumber(CSng(DtRw("importe")), 2, TriState.True, TriState.False, TriState.True)
          linea = linea & FormatNumber(CSng(DtRw("total")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & FormatNumber(CSng(DtRw("total")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR

          linea = linea & "0.000" & DELIMITADOR

          linea = linea & IIf(IsDate(DtRw("fecha_doc_ori")), DtRw("fecha_doc_ori"), "01/01/0001") & DELIMITADOR

          linea = linea & DtRw("cod_doc_ori") & DELIMITADOR
          linea = linea & DtRw("serie_doc_ori") & DELIMITADOR
          linea = linea & DtRw("numero_doc_ori") & DELIMITADOR
          linea = linea & "0" & DELIMITADOR

          If CBool(DtRw("estado")) = True And vEmision.Date.Month = pmes And vEmision.Date.Year = pAnio Then  'And (vCod_Sunat = "01" Or vCod_Sunat = "03" Or vCod_Sunat = "15" Or vCod_Sunat = "16") Then
            vStado = 1
          ElseIf CBool(DtRw("estado")) = False Then
            vStado = 2
            'ElseIf vMesEmi >= 0 And vMesEmi <= 12 Then
            '    vStado = 6
            'ElseIf vMesEmi > 12 Then
            '    vStado = 7
          End If

          linea = linea & vStado & DELIMITADOR
          linea = linea & "" & DELIMITADOR
          ' Escribir una línea con el método WriteLine
          With archivo
            ' eliminar el último caracter ";" de la cadena
            ''linea = linea.Remove(linea.Length - 1).ToString
            ' escribir la fila
            .WriteLine(linea.ToString)
          End With
          V = V + 1
        Next DtRw

      End Using
      Exportar_RV_txt = True
      ' Abrir con Process.Start el archivo de texto
      Process.Start(ARCHIVO_CSV)
      'MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
      'error
      Me.Close()
    Catch ex As Exception
      MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
    End Try
  End Function

  '=================Fin Registro Venta======================================================================

  '=================Inicio Registro compra======================================================================
  Private Function Exportar_Registro_Compras(ByVal DtOb As DataTable) As Boolean

    '    Dim V As Long, H As Long, xR As Long
    '    Dim DtRw As DataRow
    '    Dim xPt As String = ""
    '    Dim vBoleta As Single = 0, vStado As Integer = 0, vCod_Sunat As String = "0"
    '    Dim vEmision As Date, vFRegistro As Date, vMesEmi As Long = 0
    '    On Error GoTo ExpExcel

    '    If Not DtOb.Rows.Count > 0 Then
    '      MsgBox("No hay Registro que Exportar", vbExclamation, "AVISO")
    '      Exit Function
    '    End If
    '    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
    '    Dim oExcel As Excel.ApplicationClass
    '    Dim oBooks As Excel.Workbooks
    '    Dim oBook As Excel.WorkbookClass
    '    Dim oSheet As Excel.Worksheet
    '    Dim oCelda As Excel.Range


    '    ' Inicia Excel y abre el workbook
    '    oExcel = CreateObject("Excel.Application")

    '    oBooks = oExcel.Workbooks
    '    oBook = oExcel.Workbooks.Add

    '    'oBook = oBooks.Open("C:\xxx\registrocompra.xls")

    '    oSheet = oBook.Sheets(1)

    '    'Const ROW_FIRST = 3
    '    'Dim iRow As Int64 = 1

    '    ' Encabezado
    '    'oSheet.Cells(ROW_FIRST, 1) = "ID"
    '    oCelda = oSheet.Range("T1", Type.Missing)
    '    oCelda = oSheet.Range("W1", Type.Missing)
    '    If xPt = "." Then
    '      oCelda.EntireColumn.NumberFormat = "0.00"
    '    Else
    '      oCelda.EntireColumn.NumberFormat = "0,00"
    '    End If
    '    oCelda = oSheet.Range("F1", Type.Missing)
    '    oCelda.EntireColumn.NumberFormat = "00"
    '    oCelda = oSheet.Range("Z1", Type.Missing)
    '    oCelda.EntireColumn.NumberFormat = "00"
    '    oCelda = oSheet.Range("I1", Type.Missing)
    '    oCelda.EntireColumn.NumberFormat = "00000000"
    '    oCelda.EntireColumn.ColumnWidth = 15
    '    oCelda = oSheet.Range("L1", Type.Missing)
    '    oCelda.EntireColumn.ColumnWidth = 15
    '    V = 1
    '    H = 1
    '    xR = 0
    '    picAjax.Visible = False
    '    pb.Visible = True
    '    pb.Minimum = 0
    '    pb.Maximum = 1
    '    pb.Value = 1
    '    pb2.Visible = True
    '    pb2.Minimum = 0
    '    pb2.Maximum = DtOb.Rows.Count
    '    lblInformacion.Text = "Enviando Excel: " & pRUC & " del " & pPeriodo

    '    For Each DtRw In DtOb.Rows
    '      With oSheet
    '        xR = xR + 1

    '        If V <= DtOb.Rows.Count Then
    '          pb2.Value = V
    '        End If
    '        lblData.Text = " RUC: " & DtRw("numero_doc_per")
    '        Application.DoEvents()
    '        'Demas Lineas
    '        .Cells(V, H) = pAnio & pmes.ToString("00") & "00"
    '        .Cells(V, H + 3) = DtRw("fecha")
    '        vCod_Sunat = DtRw("codigo_contable")
    '        If vCod_Sunat = "14" Then
    '          .Cells(V, H + 4) = DtRw("vencimiento")
    '        End If
    '        .Cells(V, H + 5) = DtRw("codigo_contable").ToString
    '        .Cells(V, H + 6) = DtRw("serie")
    '        .Cells(V, H + 7) = 0 'rsRex!anio_dua              
    '        .Cells(V, H + 8) = DtRw("numero")
    '        .Cells(V, H + 9) = 0 'Consolidado no dan derecho fiscal
    '        .Cells(V, H + 10) = DtRw("tipo_doc_persona")
    '        .Cells(V, H + 11) = DtRw("numero_doc_per")
    '        .Cells(V, H + 12) = Mid(DtRw("nombre_persona"), 1, 60).Trim
    '        .Cells(V, H + 13) = FormatNumber(CSng(DtRw("importe_a")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 14) = FormatNumber(CSng(DtRw("igv_a")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 15) = FormatNumber(CSng(DtRw("importe_b")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 16) = FormatNumber(CSng(DtRw("igv_b")), 2, TriState.True, TriState.False, TriState.True)

    '        .Cells(V, H + 17) = FormatNumber(CSng(DtRw("importe_c")), 2, TriState.True, TriState.False, TriState.True)
    '        .Cells(V, H + 18) = FormatNumber(CSng(DtRw("igv_c")), 2, TriState.True, TriState.False, TriState.True)
    '        vBoleta = (CSng(DtRw("nogravado"))) '+ CSng(DtRw("boleta")))
    '        .Cells(V, H + 19) = FormatNumber(CSng(vBoleta), 2, TriState.True, TriState.False, TriState.True)

    '        .Cells(V, H + 20) = DtRw("isc")
    '        .Cells(V, H + 21) = DtRw("otros")
    '        .Cells(V, H + 22) = DtRw("Total")
    '        .Cells(V, H + 23) = "0.000" 'DtRw("tipo_cambio")
    '        .Cells(V, H + 24) = "01/01/0001" 'DtRw("fecha_ref")
    '        .Cells(V, H + 25) = "00" 'DtRw("tipo_doc_ref")
    '        .Cells(V, H + 26) = "-" 'DtRw("serie_ref")
    '        .Cells(V, H + 27) = "" 'DtRw("cod_dep_adua")
    '        .Cells(V, H + 28) = "-" 'DtRw("numro_doc_ref")
    '        .Cells(V, H + 29) = "-" 'DtRw("nro_no_domici")
    '        .Cells(V, H + 30) = "01/01/0001" 'DtRw("fecha_detrac")
    '        .Cells(V, H + 31) = "0" 'DtRw("nro_detrac")
    '        .Cells(V, H + 32) = "0" 'DtRw("marca_comprobante")
    '        vEmision = DtRw("fecha")
    '        vFRegistro = DtRw("fecha_registro")
    '        If vFRegistro > vEmision Then
    '          vMesEmi = DateDiff(DateInterval.Month, vEmision, vFRegistro)
    '        End If

    '        If (Single.Parse(DtRw("igv_a")) + Single.Parse(DtRw("igv_b")) + Single.Parse(DtRw("igv_c"))) = 0 Then
    '          vStado = 0
    '        ElseIf vEmision.Date.Month = pmes And vEmision.Date.Year = pAnio Then
    '          vStado = 1
    '        ElseIf vMesEmi >= 0 And vMesEmi <= 12 Then
    '          vStado = 6
    '        ElseIf vMesEmi > 12 Then
    '          vStado = 7
    '        End If

    '        .Cells(V, H + 33) = vStado 'Estado
    '        .Cells(V, H + 35) = "" 'Libre

    '      End With
    '      'H = H + 1
    '      V = V + 1
    '    Next DtRw

    '    oExcel.Visible = True

    '    Exportar_Registro_Compras = True
    '    '' Cierra todo
    '    ''oBook.Close(True)
    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oBook)
    '    oBook = Nothing

    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oBooks)
    '    oBooks = Nothing

    '    ''oExcel.Quit()
    '    System.Runtime.InteropServices.Marshal.
    '        ReleaseComObject(oExcel)
    '    oExcel = Nothing
    '    Me.Close()
    '    Exit Function
    '    '' Cierra todo
    '    ''oBook.Close(True)
    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oBook)
    '    ''oBook = Nothing

    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oBooks)
    '    ''oBooks = Nothing

    '    ''oExcel.Quit()
    '    ''System.Runtime.InteropServices.Marshal. _
    '    ''    ReleaseComObject(oExcel)
    '    ''oExcel = Nothing

    '    ''ObjExcel = CreateObject("Excel.Application")
    '    ' ''ObjExcel = excelApp.Workbooks.Open("C:\Program Files\DISClient\Templates\TemplateMerge.xls")
    '    ''ObjExcel.Application.Workbooks.Open("c:\xxx\registrocompra.xls")
    'ExpExcel:
    '    MsgBox("Conflicto: " & Err.Description, vbExclamation, "AVISO")
    '    oExcel = Nothing
  End Function

  Private Function Exportar_RC_txt(ByVal Dtp As DataTable) As Boolean

    Const DELIMITADOR As String = "|"
    Dim DtRw As DataRow
    Dim Centro_Costo As Long = 0, V As Long = 1
    Dim vBoleta As Single = 0, vStado As Integer = 0, vCod_Sunat As String = "0"
    Dim vEmision As Date, vFRegistro As Date, vMesEmi As Long = 0
    Dim cAlm As String = ""
    ' ruta del fichero de texto
    Dim ARCHIVO_CSV As String = "", vFileName As String = ""
    vFileName = ("LE" & pRUC & pAnio & pmes.ToString("00") & "00" & "08" & "01" & "00" & "00" & "1" & "1" & "1" & "1")
    ARCHIVO_CSV = Crear_Archivo("\" & vFileName & ".txt")  'vNameFile '"C:\ctr_" & cboUnidad_Negocio.Value & "." & Format(CboFecha1.Text, "ddmmyy") & "." & Format(CboFecha2.Text, "ddmmyy") & ".csv"

    Try
      picAjax.Visible = False
      pb.Visible = True
      pb.Minimum = 0
      pb.Maximum = 1
      pb.Value = 1
      pb2.Visible = True
      pb2.Minimum = 0
      pb2.Maximum = Dtp.Rows.Count
      lblInformacion.Text = "excribiendo txt: " & pRUC & " del " & pPeriodo

      'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
      Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'variable para almacenar la línea actual del dataview
        Dim linea As String = String.Empty

        For Each DtRw In Dtp.Rows
          ' vaciar la línea
          linea = String.Empty
          If V <= Dtp.Rows.Count Then
            pb2.Value = V
          End If
          lblData.Text = " RUC: " & DtRw("numero_doc_per")
          Application.DoEvents()
          ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
          cAlm = Mid(DtRw("almacen"), 1, 2)
          linea = pAnio & pmes.ToString("00") & "00" & DELIMITADOR
          linea = linea & cAlm & "RC" & V & DELIMITADOR
          linea = linea & "M" & V & DELIMITADOR
          linea = linea & DtRw("fecha") & DELIMITADOR
          vCod_Sunat = DtRw("codigo_contable")
          If vCod_Sunat = "14" Then
            linea = linea & DtRw("vencimiento") & DELIMITADOR
          Else
            linea = linea & DELIMITADOR
          End If
          linea = linea & DtRw("codigo_contable").ToString & DELIMITADOR
          linea = linea & DtRw("serie") & DELIMITADOR
          linea = linea & 0 & DELIMITADOR

          linea = linea & DtRw("numero") & DELIMITADOR
          linea = linea & 0 & DELIMITADOR
          linea = linea & DtRw("tipo_doc_persona") & DELIMITADOR
          linea = linea & DtRw("numero_doc_per") & DELIMITADOR
          linea = linea & Mid(DtRw("nombre_persona"), 1, 60).Trim & DELIMITADOR
          linea = linea & 0 & FormatNumber(CSng(DtRw("importe_a")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          linea = linea & 0 & FormatNumber(CSng(DtRw("igv_a")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          linea = linea & 0 & FormatNumber(CSng(DtRw("importe_b")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          linea = linea & 0 & FormatNumber(CSng(DtRw("igv_b")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          'FormatNumber(CSng(DtRw("importe")), 2, TriState.True, TriState.False, TriState.True)
          linea = linea & FormatNumber(CSng(DtRw("importe_c")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          linea = linea & FormatNumber(CSng(DtRw("igv_c")), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR
          vBoleta = (CSng(DtRw("nogravado"))) '+ CSng(DtRw("boleta")))
          linea = linea & FormatNumber(CSng(vBoleta), 2, TriState.True, TriState.False, TriState.False) & DELIMITADOR

          linea = linea & DtRw("isc") & DELIMITADOR
          linea = linea & DtRw("otros") & DELIMITADOR
          linea = linea & DtRw("Total") & DELIMITADOR
          linea = linea & "0.000" & DELIMITADOR
          linea = linea & "01/01/0001" & DELIMITADOR
          linea = linea & "00" & DELIMITADOR
          linea = linea & "-" & DELIMITADOR
          linea = linea & "" & DELIMITADOR
          linea = linea & "-" & DELIMITADOR
          linea = linea & "-" & DELIMITADOR
          linea = linea & "01/01/0001" & DELIMITADOR
          linea = linea & "0" & DELIMITADOR
          linea = linea & "0" & DELIMITADOR
          vEmision = DtRw("fecha")
          vFRegistro = DtRw("fecha_registro")
          If vFRegistro > vEmision Then
            vMesEmi = DateDiff(DateInterval.Month, vEmision, vFRegistro)
          End If

          If (Single.Parse(DtRw("igv_a")) + Single.Parse(DtRw("igv_b")) + Single.Parse(DtRw("igv_c"))) = 0 _
              And (vCod_Sunat = "01" Or vCod_Sunat = "03" Or vCod_Sunat = "15" Or vCod_Sunat = "16") Then
            vStado = 0
          ElseIf vEmision.Date.Month = pmes And vEmision.Date.Year = pAnio Then
            vStado = 1
          ElseIf vMesEmi >= 0 And vMesEmi <= 12 Then
            vStado = 6
          ElseIf vMesEmi > 12 Then
            vStado = 7
          End If

          linea = linea & vStado & DELIMITADOR
          linea = linea & "" & DELIMITADOR
          ' Escribir una línea con el método WriteLine
          With archivo
            ' eliminar el último caracter ";" de la cadena
            ''linea = linea.Remove(linea.Length - 1).ToString
            ' escribir la fila
            .WriteLine(linea.ToString)
          End With
          V = V + 1
        Next DtRw

      End Using
      Exportar_RC_txt = True
      ' Abrir con Process.Start el archivo de texto
      Process.Start(ARCHIVO_CSV)
      'MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
      'error
      Me.Close()
    Catch ex As Exception
      MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
    End Try
  End Function

  '=================Fin Registro compra======================================================================

  Private Sub FrmProcesar_Info_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pb.Visible = False
    lblInformacion.Text = "Procesando Información"
    Try
      Select Case pOpcion
        Case 31
          If Not bwPLE.IsBusy Then
            picAjax.Visible = True
            bwPLE.RunWorkerAsync()
          End If
        Case 32
          If Not bwPLE.IsBusy Then
            picAjax.Visible = True
            bwPLE.RunWorkerAsync()
          End If
        Case 39
          'If pEmpresa = "TODAS" Then
          '    If Not bwProsceso.IsBusy Then
          '        picAjax.Visible = True
          '        bwProsceso.RunWorkerAsync()
          '    End If
          'Else
          '    If Not bwProcesoUna.IsBusy Then
          '        picAjax.Visible = True
          '        bwProcesoUna.RunWorkerAsync()
          '    End If
          'End If
      End Select
    Catch ex As Exception

    End Try
  End Sub
End Class