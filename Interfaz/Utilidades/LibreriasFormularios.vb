Option Explicit On
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Telerik.WinControls.UI
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Word = Microsoft.Office.Interop.Word
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Infragistics.Win.UltraWinEditors
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.UI.Docking

Public Class LibreriasFormularios

  Public Shared Function Consultar_DNI_Reniec(ByVal vDNI As String, ByVal vRUC As String) As persona

    Dim ObjPe As New persona

    Dim testDialog As New FrmReniec()
    testDialog.pNumero = vDNI.Trim
    testDialog.pRUC = vRUC.Trim
    If testDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
      ObjPe.personaid = testDialog.pPersonaid
      ObjPe.ape_pat = CStr(testDialog.txtApe_Pat.Text)
      ObjPe.ape_mat = CStr(testDialog.txtApe_Mat.Text)
      ObjPe.nombre = CStr(testDialog.txtNombre.Text)
    Else
      ObjPe.personaid = 0
      ObjPe.ape_pat = ""
      ObjPe.ape_mat = ""
      ObjPe.nombre = ""
    End If
    'vOkR = testDialog.vOkR
    testDialog.Dispose()
    Return ObjPe
    ObjPe = Nothing

  End Function

  Public Shared Function Datos_Persona(ByVal vTipo_Doc As String, ByVal vNumero As String) As persona
    Dim ObjPe As New persona
    Dim ObjPer As New persona
    Dim vTipo As String = ""
    Dim vPersonaId As Long = 0, vDni As String = "", vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""
    Dim vRuc As String = "", vRaz_soc As String = "", vDireccion As String = ""
    Dim reg As Regex
    reg = New Regex("[^a-zA-Z0-9 ]")
    'string textoSinAcentos = reg.Replace(textoNormalizado, "");
    Try

      ObjPe = personaManager.Datos_Persona_Basic("", vNumero.Trim, 0)

      If Not ObjPe Is Nothing Then
        vPersonaId = Long.Parse(ObjPe.personaid)
        vTipo = Trim(ObjPe.tipo)
        vDireccion = Trim(ObjPe.direccion)
        vRuc = Trim(ObjPe.ruc) & ""
        vDni = Trim(ObjPe.dni) & ""
        If ObjPe.tipo = "N" Then
          vApe_Pat = ObjPe.ape_pat
          vApe_Mat = ObjPe.ape_mat
          vNombre = ObjPe.nombre
        ElseIf ObjPe.tipo = "J" Then
          vRaz_soc = ObjPe.raz_soc
        End If
      Else
        If vTipo_Doc = "RUC" Then
          Dim ObjDS As New datos_ruc
          'Funciones.Verificar_ruc(vNumero.Trim)
          ObjDS = Consulta_RUC_SUNAT(vNumero.Trim)
          If Not ObjDS Is Nothing Then
            vPersonaId = ObjDS.personaid
            vRaz_soc = ObjDS.Razon_Social
            vDireccion = ObjDS.Direccion
            vTipo = ObjDS.Tipo_Per

            If vTipo = "N" Then
              Dim ObjRENIEC As persona
              vDni = Mid(vNumero.Trim, 3, 8)
              vRuc = vNumero
              ObjPer.dni = vDni

              ObjRENIEC = Consultar_DNI_Reniec(vDni.Trim, vRuc)
              If Not ObjRENIEC Is Nothing Then
                vPersonaId = Long.Parse(ObjRENIEC.personaid)
                vApe_Pat = reg.Replace(ObjRENIEC.ape_pat, "")
                vApe_Mat = reg.Replace(ObjRENIEC.ape_mat, "")
                vNombre = reg.Replace(ObjRENIEC.nombre, "")
              End If
            Else
              vRuc = vNumero
            End If
          End If

        ElseIf vTipo_Doc = "DNI" Then 'si es DNI
          Dim ObjRENIECD As persona
          ObjRENIECD = Consultar_DNI_Reniec(vNumero.Trim, vRuc)
          If Not ObjRENIECD Is Nothing Then
            vTipo = "N"
            vDni = vNumero.Trim
            vPersonaId = Long.Parse(ObjRENIECD.personaid)
            vApe_Pat = reg.Replace(ObjRENIECD.ape_pat, "")
            vApe_Mat = reg.Replace(ObjRENIECD.ape_mat, "")
            vNombre = reg.Replace(ObjRENIECD.nombre, "")
          End If
        End If
      End If

      ObjPer.personaid = vPersonaId
      ObjPer.tipo = vTipo
      ObjPer.direccion = vDireccion
      ObjPer.dni = vDni
      ObjPer.ape_pat = vApe_Pat
      ObjPer.ape_mat = vApe_Mat
      ObjPer.nombre = vNombre
      ObjPer.ruc = vRuc
      ObjPer.raz_soc = vRaz_soc
    Catch ex As Exception
      MsgBox(ex.Message.ToString)
      ObjPe = Nothing
      ObjPer = Nothing
    End Try
    Return ObjPer
    ObjPe = Nothing
    ObjPer = Nothing
  End Function

  Public Shared Function Consulta_RUC_SUNAT(ByVal vDNI As String) As datos_ruc

    Dim ObjR As New datos_ruc

    Dim testD As New FrmCapcha
    testD.pNumero = vDNI.Trim

    If testD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
      With ObjR
        .personaid = testD.pPersonaid
        .ruc = testD.txtRucDni.Text
        .Razon_Social = Regex.Replace(testD.txtRazSocial.Text, "'", String.Empty)
        .Tipo_Per = testD.txtTipoPer.Text
        .Dni = testD.txtDNID.Text
        .Estado = testD.txtActivo.Text
        .Condicion = testD.TxtHabido.Text
        .Direccion = Regex.Replace(testD.txtDireccion.Text, "'", String.Empty)
        .Telefonos = testD.txtTelefonos.Text
      End With

    End If
    'vOkR = testDialog.vOkR
    testD.Dispose()
    Return ObjR
    ObjR = Nothing

  End Function

  Public Shared Function Datos_Persona_Local(ByVal vTipo_Doc As String, ByVal vNumero As String) As persona
    Dim ObjPe As New persona
    Dim ObjPer As New persona
    Dim vTipo As String = ""
    Dim vPersonaId As Long = 0, vDni As String = "", vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""
    Dim vRuc As String = "", vRaz_soc As String = "", vDireccion As String = ""
    Dim reg As Regex
    reg = New Regex("[^a-zA-Z0-9 ]")
    'string textoSinAcentos = reg.Replace(textoNormalizado, "");
    Try

      ObjPe = personaManager.Datos_Persona_Basic("", vNumero.Trim, 0)

      If Not ObjPe Is Nothing Then
        vPersonaId = Long.Parse(ObjPe.personaid)
        vTipo = Trim(ObjPe.tipo)
        vDireccion = Trim(ObjPe.direccion)
        vRuc = Trim(ObjPe.ruc) & ""
        vDni = Trim(ObjPe.dni) & ""
        If ObjPe.tipo = "N" Then
          vApe_Pat = ObjPe.ape_pat
          vApe_Mat = ObjPe.ape_mat
          vNombre = ObjPe.nombre
        ElseIf ObjPe.tipo = "J" Then
          vRaz_soc = ObjPe.raz_soc
        End If
      End If

      ObjPer.personaid = vPersonaId
      ObjPer.tipo = vTipo
      ObjPer.direccion = vDireccion
      ObjPer.dni = vDni
      ObjPer.ape_pat = vApe_Pat
      ObjPer.ape_mat = vApe_Mat
      ObjPer.nombre = vNombre
      ObjPer.ruc = vRuc
      ObjPer.raz_soc = vRaz_soc

    Catch ex As Exception
      MsgBox(ex.Message.ToString)
      ObjPe = Nothing
      ObjPer = Nothing
    End Try
    Return ObjPer
    ObjPe = Nothing
    ObjPer = Nothing
  End Function

  Public Shared Function isUTF8(ByVal ptstr As String)
    Dim tUTFencoded As String
    Dim tUTFencodedaux
    Dim tUTFencodedASCII As String
    Dim ptstrASCII As String
    Dim iaux, iaux2 As Integer
    Dim ffound As Boolean

    ffound = False
    ptstrASCII = ""

    For iaux = 1 To Len(ptstr)
      ptstrASCII = ptstrASCII & Asc(Mid(ptstr, iaux, 1)) & "|"
    Next

    tUTFencoded = "Ä|Å|Ç|É|Ñ|Ö|Ì|á|�|â|ä|ã|å|ç|é|è|ê|ë|í|ì|î|ï|ñ|ó|ò|ô|ö|õ|ú|ù|û|ü|�|°|¢|£|§|•|¶|ß|®|©|™|´|¨|�|Æ|Ø|∞|±|≤|≥|¥|µ|∂|∑|∏|π|∫|ª|º|Ω|æ|ø|¿|¡|¬|√|ƒ|≈|∆|«|»|…|�|À|Ã|Õ|Œ|�|�|�|“|”|‘|’|÷|◊|ÿ|Ÿ|⁄|€|‹|›|ﬁ|ﬂ|‡|·|‚|„|‰|Â|Ú|Á|Ë|È|Í|Î|Ï|Ì|�|�||Ò|Ú|Û|Ù|ı|ˆ|˜|¯|˘|˙|˚|¸|˝|˛|ˇ" &
            "�|š|¦|²|³|¹|¼|½|¾|Ð|×|Ý|Þ|ð|ý|þ" &
            "�|∞|≤|≥|∂|∑|∏|π|∫|Ω|√|≈|∆|◊|⁄|ﬁ|ﬂ||ı|˘|˙|˚|˝|˛|ˇ"

    tUTFencodedaux = Split(tUTFencoded, "|")
    If UBound(tUTFencodedaux) > 0 Then
      iaux = 0
      Do While Not ffound And Not iaux > UBound(tUTFencodedaux)
        If InStr(1, ptstr, tUTFencodedaux(iaux), vbTextCompare) > 0 Then
          ffound = True
        End If

        If Not ffound Then
          'ASCII numeric search
          tUTFencodedASCII = ""
          For iaux2 = 1 To Len(tUTFencodedaux(iaux))
            'gets ASCII numeric sequence
            tUTFencodedASCII = tUTFencodedASCII & Asc(Mid(tUTFencodedaux(iaux), iaux2, 1)) & "|"
          Next
          'tUTFencodedASCII = Left(tUTFencodedASCII, Len(tUTFencodedASCII) - 1)

          'compares numeric sequences
          If InStr(1, ptstrASCII, tUTFencodedASCII) > 0 Then
            ffound = True
          End If
        End If

        iaux = iaux + 1
      Loop
    End If

    isUTF8 = ffound
  End Function

  Function DecodeUTF8(s)
    Dim i
    Dim c
    Dim n

    s = s & " "

    i = 1
    Do While i <= Len(s)
      c = Asc(Mid(s, i, 1))
      If c And &H80 Then
        n = 1
        Do While i + n < Len(s)
          If (Asc(Mid(s, i + n, 1)) And &HC0) <> &H80 Then
            Exit Do
          End If
          n = n + 1
        Loop
        If n = 2 And ((c And &HE0) = &HC0) Then
          c = Asc(Mid(s, i + 1, 1)) + &H40 * (c And &H1)
        Else
          c = 191
        End If
        s = Left(s, i - 1) + Chr(c) + Mid(s, i + n)
      End If
      i = i + 1
    Loop
    DecodeUTF8 = s
  End Function


  Public Shared Sub ObtenerNombreCta(ByVal vNroCuenta As Long, ByRef vCuenta As String)
    Dim Filter As String = "cuenta = " & vNroCuenta
    Dim dv As DataView, dtRowP As DataRowView
    vCuenta = ""
    If Not GestionTablas.dtplan Is Nothing Then
      dv = New DataView(GestionTablas.dtplan, Filter, "", DataViewRowState.CurrentRows)
      For Each dtRowP In dv
        vCuenta = dtRowP.Item("nombre").ToString
      Next

    End If
  End Sub

  Public Shared Sub TienePermiso(ByVal vPersonaID As Long, ByVal vProceso As String, ByRef vTiene As Boolean)
    Dim Filter As String = "nombre = '" & vProceso & "'"
    Dim dv As DataView, dtRowP As DataRowView
    vProceso = ""
    vTiene = False
    If Not GestionTablas.dtPermisos Is Nothing Then
      dv = New DataView(GestionTablas.dtPermisos, Filter, "", DataViewRowState.CurrentRows)
      For Each dtRowP In dv
        vTiene = dtRowP.Item("estado").ToString
      Next
    End If
  End Sub

  Public Shared Sub Asignar_Configuracion(ByVal vTipo As String, ByVal vCodigo As Long, ByVal vNom_Col As String, ByRef vDato As String)
    Dim Filter As String = "tipo = '" & vTipo & "' and codigo=" & vCodigo
    Dim dv As DataView, dtRowP As DataRowView
    vDato = ""
    If Not GestionTablas.dtconf Is Nothing Then
      dv = New DataView(GestionTablas.dtconf, Filter, "", DataViewRowState.CurrentRows)
      For Each dtRowP In dv
        vDato = dtRowP.Item(vNom_Col).ToString
      Next
    End If
  End Sub

  Public Shared Sub ActivarControles(ByRef Contenedor As Object, ByVal Valor As Boolean)
    Dim objControl As Control = CType(Contenedor, Control)
    If objControl.Controls.Count > 0 Then
      For Each c As Control In objControl.Controls
        If c.Controls.Count > 0 Then
          Call ActivarControles(c, Valor)
        End If
        Select Case c.GetType.Name.Trim
          Case "UltraCalendarCombo"
            CType(c, Infragistics.Win.UltraWinSchedule.UltraCalendarCombo).ReadOnly = Not Valor
          Case "ComboBox"
            CType(c, ComboBox).Enabled = Valor
          Case "UltraTextEditor"
            CType(c, Infragistics.Win.UltraWinEditors.UltraTextEditor).ReadOnly = Not Valor
          Case "TextBox"
            CType(c, TextBox).ReadOnly = Not Valor
          Case "Button"
            CType(c, Button).Enabled = Valor
          Case "UltraButton"
            CType(c, Infragistics.Win.Misc.UltraButton).Enabled = Valor
          Case "UltraGrid"
            CType(c, Infragistics.Win.UltraWinGrid.UltraGrid).DisplayLayout.Override.AllowUpdate = IIf(Valor, 1, 2)
          Case "UltraCombo"
            CType(c, Infragistics.Win.UltraWinGrid.UltraCombo).ReadOnly = Not Valor
          Case "UltraDateTimeEditor"
            CType(c, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).ReadOnly = Not Valor
        End Select
      Next
    End If
  End Sub

  Public Shared Sub LimpiarControles(ByRef Contenedor As Object)
    Dim objControl As Control = CType(Contenedor, Control)
    If objControl.Controls.Count > 0 Then
      For Each c As Control In objControl.Controls
        If c.Controls.Count > 0 Then
          Call LimpiarControles(c)
        End If
        'MessageBox.Show(c.GetType.Name.Trim)
        Select Case c.GetType.Name.Trim
          Case "ComboBox"
            CType(c, ComboBox).SelectedIndex = -1
          Case "UltraTextEditor"
            CType(c, UltraTextEditor).Text = ""
          Case "TextBox"
            CType(c, TextBox).Text = ""
          Case "UltraDateTimeEditor"
            CType(c, UltraDateTimeEditor).Value = DBNull.Value
          Case "UltraCombo"
            CType(c, UltraCombo).SelectedRow = CType(c, UltraCombo).GetRow(ChildRow.First)
          Case "UltraPictureBox"
            CType(c, UltraPictureBox).Image = Nothing
        End Select
      Next
    End If
  End Sub

  Public Shared Sub Navy_Cells_uGrid(ByVal sender As Object, ByVal e As KeyEventArgs)
    Dim xGrid As UltraGrid
    xGrid = sender

    Select Case e.KeyValue
      Case Keys.Up

        xGrid.PerformAction(UltraGridAction.ExitEditMode, False, False)
        xGrid.PerformAction(UltraGridAction.AboveCell, False, False)
        e.Handled = True
        xGrid.PerformAction(UltraGridAction.EnterEditMode, False, False)

      Case Keys.Down

        xGrid.PerformAction(UltraGridAction.ExitEditMode, False, False)
        xGrid.PerformAction(UltraGridAction.BelowCell, False, False)
        e.Handled = True
        xGrid.PerformAction(UltraGridAction.EnterEditMode, False, False)

      Case Keys.Right

        xGrid.PerformAction(UltraGridAction.ExitEditMode, False, False)
        xGrid.PerformAction(UltraGridAction.NextCell, False, False)
        e.Handled = True
        xGrid.PerformAction(UltraGridAction.EnterEditMode, False, False)

      Case Keys.Left

        xGrid.PerformAction(UltraGridAction.ExitEditMode, False, False)
        xGrid.PerformAction(UltraGridAction.PrevCell, False, False)
        e.Handled = True
        xGrid.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Select

  End Sub

  'Public Shared Function ConversionImagen(ByVal nombrearchivo As String) As Byte()
  '    'Declaramos fs para poder abrir la imagen.
  '    Dim fs As FileStream
  '    Dim br As BinaryReader
  '    Dim imagen As Byte()

  '    fs = New FileStream(nombrearchivo, FileMode.Open)

  '    ' Declaramos un lector binario para pasar la imagen
  '    'a bytes
  '    br = New BinaryReader(fs)
  '    'byte[] imagen = new byte[(int)fs.Length];
  '    imagen = New Byte()

  '    br.Read(imagen, 0, (fs.Length))
  '    br.Close()
  '    fs.Close()
  '    Return imagen

  'End Function

  Public Shared Function Extrae(ByVal Cadena As String, ByVal Parte As String, ByVal L_R As String) As String
    Dim i As Integer

    i = InStr(Cadena, Parte)
    If i Then
      If UCase(L_R) = "L" Then
        Extrae = Mid$(Cadena, 1, i - 1)
      Else
        Extrae = Mid$(Cadena, i + 1, Cadena.Length)
      End If
    Else
      Extrae = Cadena
    End If
    Return Extrae
  End Function

  Public Shared Function Kitar(ByVal Cadena As String, ByVal Parte As String) As String
    Dim i As Integer

    i = InStr(Cadena, Parte)
    If i Then
      Kitar = Left$(Cadena, i - 1) & Mid$(Cadena, i + Len(Parte))
    Else
      Kitar = Cadena
    End If
  End Function

  Public Shared Function Obtener_Empresa(ByVal vCodigo As Integer) As String
    Obtener_Empresa = ""
    Dim ObjE As empresa
    ObjE = empresaManager.GetItem_x_UNeg(vCodigo)
    If Not ObjE Is Nothing Then
      Obtener_Empresa = ObjE.nombre
    End If
    ObjE = Nothing
    Return Obtener_Empresa
  End Function

  Public Shared Function Obtener_Empresa_y_RUC(ByVal vCodigo As Integer) As empresa


    Obtener_Empresa_y_RUC = empresaManager.GetItem_x_UNeg(vCodigo)

    Return Obtener_Empresa_y_RUC
  End Function

  Public Shared Function Formato_Fecha(ByVal vFecha As Date) As String
    Formato_Fecha = ""
    Formato_Fecha = (vFecha.Year) & "/" & Format(vFecha.Month, "00") & "/" & Format(vFecha.Day, "00")
    Return Formato_Fecha
  End Function

  Public Shared Function Formato_Fechaddmmyyyy(ByVal vFecha As Date) As String
    Formato_Fechaddmmyyyy = ""
    Formato_Fechaddmmyyyy = Format(vFecha.Day, "00") & "/" & Format(vFecha.Month, "00") & "/" & (vFecha.Year)
    Return Formato_Fechaddmmyyyy
  End Function

  Public Shared Function Formato_Hora(ByVal vFecha As Date) As String
    Formato_Hora = ""
    Formato_Hora = (vFecha.Hour) & ":" & Format(vFecha.Minute, "00")
    Return Formato_Hora
  End Function

  Public Shared Function Formato_Fecha_b(ByVal vFecha As Date) As String
    Formato_Fecha_b = ""
    Formato_Fecha_b = (vFecha.Year) & Format(vFecha.Month, "00") & Format(vFecha.Day, "00")
    Return Formato_Fecha_b
  End Function

  Public Shared Function Formato_Fecha_c(ByVal vFecha As Date) As String
    Formato_Fecha_c = ""
    Formato_Fecha_c = Format(vFecha.Day, "00") & Format(vFecha.Month, "00") & (vFecha.Year)
    Return Formato_Fecha_c
  End Function

  Public Shared Function Formato_Fecha_Mostrar(ByVal vFecha As Date) As String
    Formato_Fecha_Mostrar = ""
    Formato_Fecha_Mostrar = Format(vFecha.Day, "00") & "/" & Format(vFecha.Month, "00") & "/" & (vFecha.Year)
    Return Formato_Fecha_Mostrar
  End Function

  Public Shared Function Obtener_mes(ByVal vMes As Integer) As String

    Obtener_mes = ""
    Select Case vMes
      Case 1
        Obtener_mes = "ENERO"
      Case 2
        Obtener_mes = "FEBRERO"
      Case 3
        Obtener_mes = "MARZO"
      Case 4
        Obtener_mes = "ABRIL"
      Case 5
        Obtener_mes = "MAYO"
      Case 6
        Obtener_mes = "JUNIO"
      Case 7
        Obtener_mes = "JULIO"
      Case 8
        Obtener_mes = "AGOSTO"
      Case 9
        Obtener_mes = "SETIEMBRE"
      Case 10
        Obtener_mes = "OCTUBRE"
      Case 11
        Obtener_mes = "NOVIEMBRE"
      Case 12
        Obtener_mes = "DICIEMBRE"
    End Select


    Return Obtener_mes
  End Function

  Public Shared Function Exportar_UltraGrid_Excel(ByVal dgvListado As UltraGrid, ByVal utExcel As UltraGridExcelExporter, ByVal vNameFile As String) As Boolean
    'AddHandler uex.CellExported, AddressOf ugExcelExporter_CellExported        
    Dim vOk As Boolean = False

    Try

      utExcel.Export(dgvListado, vNameFile)

      Process.Start(vNameFile)
      vOk = True
    Catch ex As Exception
      vOk = False
    End Try

    Return vOk

  End Function

  Public Shared Function Emitir_Carta(ByVal vFile As String, ByVal vCliente As String, ByVal vDni As String,
                                          ByVal vDirec As String, ByVal vDist As String, ByVal vProv As String, ByVal vDpto As String,
                                          ByVal vAgente As String, ByVal vNro As String, ByVal vNomb_Sus As String,
                                          ByVal vTotal As Single, ByVal vTAmortiza As Single, ByVal vSaldo As Single) As Boolean
    Dim oWord As Word.Application
    Dim oDoc As Word.Document
    'Dim Letras As String = ""
    'Dim dgvRw As UltraGridRow
    'Dim vImport As Single = 0
    ''Dim oTable As Word.Table
    ''Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph
    ''Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
    ''Dim oRng As Word.Range
    ''Dim oShape As Word.InlineShape
    ''Dim oChart As Object
    ''Dim Pos As Double
    'Letras = Numeros_Letras.EnLetras(vTotal)
    'Start Word and open the document template.
    oWord = CreateObject("Word.Application")

    oWord.Documents.Add(Template:="C:\phoenix\" & vFile)
    oWord.Visible = True
    oDoc = oWord.ActiveDocument
    oDoc.Bookmarks.Item("Fecha").Range.Text = Now.ToLongDateString
    oDoc.Bookmarks.Item("Cliente").Range.Text = vCliente
    oDoc.Bookmarks.Item("DNI").Range.Text = vDni

    oDoc.Bookmarks.Item("Direccion").Range.Text = vDirec
    oDoc.Bookmarks.Item("Distrito").Range.Text = vDist
    oDoc.Bookmarks.Item("Provincia").Range.Text = vProv
    oDoc.Bookmarks.Item("Departamento").Range.Text = vDpto

    oDoc.Bookmarks.Item("Agente").Range.Text = vAgente
    oDoc.Bookmarks.Item("Nro").Range.Text = vNro
    oDoc.Bookmarks.Item("Suscripcion").Range.Text = vNomb_Sus

    oDoc.Bookmarks.Item("TotalPagar").Range.Text = vTotal
    oDoc.Bookmarks.Item("TotalAmortizacion").Range.Text = vTAmortiza
    If Not (vFile = "modelo5.docx" Or vFile = "modelo5.docx") Then
      oDoc.Bookmarks.Item("SaldoActual").Range.Text = vSaldo
    End If

    'oDoc.Bookmarks.Item("mes").Range.Text = LibreriasFormularios.Obtener_mes(Date.Now.Month)

    'oWord.ActiveDocument.PrintOut(False, , , , , , , 2)

    'oWord.ActiveDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges)

    'oWord.Quit(False)
  End Function

  Public Shared Function Emitir_Carta_Sehs(ByVal vFile As String, ByVal vPersonaid As Long, ByVal vUnidadid As Integer, ByVal vSaldo As Single) As Boolean
    Dim cDt As New DataTable
    cDt = por_cobrarManager.EmitirCarta(vPersonaid, vUnidadid)

    If Not cDt Is Nothing Then
      If cDt.DataSet.Tables(0).Rows.Count > 0 Then
        With cDt.DataSet.Tables(0).Rows(0)
          Dim oWord As Word.Application
          Dim oDoc As Word.Document

          oWord = CreateObject("Word.Application")

          oWord.Documents.Add(Template:="C:\phoenix\" & vFile)
          oWord.Visible = True
          oDoc = oWord.ActiveDocument

          oDoc.Bookmarks.Item("Ciudad").Range.Text = .Item(9).ToString
          oDoc.Bookmarks.Item("DireccionLocal").Range.Text = .Item("direccionlocal").ToString
          oDoc.Bookmarks.Item("TelefonoLocal").Range.Text = .Item("telefonolocal").ToString

          oDoc.Bookmarks.Item("Fecha").Range.Text = Now.ToLongDateString

          oDoc.Bookmarks.Item("Cliente").Range.Text = .Item("Cliente").ToString
          oDoc.Bookmarks.Item("CodigoCli").Range.Text = .Item("dniruc").ToString
          oDoc.Bookmarks.Item("DireccionCli").Range.Text = .Item("direccion").ToString
          oDoc.Bookmarks.Item("UbigeoClie").Range.Text = .Item("distrito").ToString & " - " & .Item("provincia").ToString & " - " & .Item("departamento").ToString

          oDoc.Bookmarks.Item("Deuda").Range.Text = vSaldo

          'oDoc.Bookmarks.Item("mes").Range.Text = LibreriasFormularios.Obtener_mes(Date.Now.Month)

          'oWord.ActiveDocument.PrintOut(False, , , , , , , 2)

          'oWord.ActiveDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges)

          'oWord.Quit(False)
        End With
      End If
    End If
  End Function
  Public Shared Sub SoloNumeros(ByRef sender As Object, ByRef e As KeyPressEventArgs,
                               ByRef oTextBox As UltraTextEditor, ByVal isDecimal As Boolean, ByVal isNegativo As Boolean)

    If isDecimal Then
      'Consultamos el separador decimal por defecto en la pc
      Dim separadorDecimal As String
      separadorDecimal = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
      'verificamos que no sea coma ","
      If separadorDecimal = "," Then
        e.Handled = True
        Return
      End If
      '// Esto es para el caso que se quiera imponer un determinado separador decimal
      ' Si en el control hay ya escrito un separador decimal,
      ' deshechamos insertar otro separador m�s.
      '
      'If Not DirectCast(sender, UltraTextEditor).Text.IndexOf(separadorDecimal) >= 0 Then
      '    e.Handled = True
      '    Return
      'End If

      ' Insertamos el separador decimal.
      '
      'DirectCast(sender, UltraTextEditor).SelectedText = separadorDecimal
      'e.Handled = True

    ElseIf Convert.ToInt32(e.KeyChar) = 8 Then
      ' Se ha pulsado la tecla retroceso
    ElseIf isNegativo Then
      If e.KeyChar = "-"c Then
        ' �nicamente si no est� seleccionado el texto del control
        If oTextBox.SelectionLength = 0 Then

          ' Solo permito el signo menos si aparece en primera posici�n
          If oTextBox.SelectionStart <> 0 Then e.Handled = True

          ' Si en el control hay ya escrito un signo menos,
          ' deshechamos todos los que posteriormente se escriban
          If DirectCast(sender, UltraTextEditor).Text.IndexOf("-") >= 0 Then
            e.Handled = True
          End If

        End If
      End If
    ElseIf Not (Char.IsDigit(e.KeyChar)) Then
      ' No se ha pulsado un d�gito.
      e.Handled = True

    End If

  End Sub

  Public Shared Sub SoloNumeros(ByRef sender As Object, ByRef e As KeyPressEventArgs,
                                  ByRef oTextBox As TextBox, ByVal isDecimal As Boolean, ByVal isNegativo As Boolean)


    If isDecimal Then
      'Consultamos el separador decimal por defecto en la pc
      Dim separadorDecimal As String
      separadorDecimal = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
      'verificamos que no sea coma ","
      If separadorDecimal = "," Then
        e.Handled = True
        Return
      End If

    ElseIf Convert.ToInt32(e.KeyChar) = 8 Then
      ' Se ha pulsado la tecla retroceso
    ElseIf isNegativo Then
      If e.KeyChar = "-"c Then
        ' �nicamente si no est� seleccionado el texto del control
        If oTextBox.SelectionLength = 0 Then

          ' Solo permito el signo menos si aparece en primera posici�n
          If oTextBox.SelectionStart <> 0 Then e.Handled = True

          ' Si en el control hay ya escrito un signo menos,
          ' deshechamos todos los que posteriormente se escriban
          If DirectCast(sender, TextBox).Text.IndexOf("-") >= 0 Then
            e.Handled = True
          End If

        End If
      End If

    ElseIf Not (Char.IsDigit(e.KeyChar)) Then
      ' No se ha pulsado un d�gito.
      e.Handled = True

    End If

  End Sub

  Public Shared Sub SoloNumeros(ByRef sender As Object, ByRef e As KeyPressEventArgs,
                           ByRef oTextBox As RadTextBox, ByVal isDecimal As Boolean, ByVal isNegativo As Boolean)

    If isDecimal Then
      'Consultamos el separador decimal por defecto en la pc
      Dim separadorDecimal As String
      separadorDecimal = Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
      'verificamos que no sea coma ","
      If separadorDecimal = "," Then
        e.Handled = True
        Return
      End If
      '// Esto es para el caso que se quiera imponer un determinado separador decimal
      ' Si en el control hay ya escrito un separador decimal,
      ' deshechamos insertar otro separador m�s.
      '
      'If Not DirectCast(sender, UltraTextEditor).Text.IndexOf(separadorDecimal) >= 0 Then
      '    e.Handled = True
      '    Return
      'End If

      ' Insertamos el separador decimal.
      '
      'DirectCast(sender, UltraTextEditor).SelectedText = separadorDecimal
      'e.Handled = True

    ElseIf Convert.ToInt32(e.KeyChar) = 8 Then
      ' Se ha pulsado la tecla retroceso
    ElseIf isNegativo Then
      If e.KeyChar = "-"c Then
        ' �nicamente si no est� seleccionado el texto del control
        If oTextBox.SelectionLength = 0 Then

          ' Solo permito el signo menos si aparece en primera posici�n
          If oTextBox.SelectionStart <> 0 Then e.Handled = True

          ' Si en el control hay ya escrito un signo menos,
          ' deshechamos todos los que posteriormente se escriban
          If DirectCast(sender, UltraTextEditor).Text.IndexOf("-") >= 0 Then
            e.Handled = True
          End If

        End If
      End If
    ElseIf Not (Char.IsDigit(e.KeyChar)) Then
      ' No se ha pulsado un d�gito.
      e.Handled = True

    End If

  End Sub

  Public Shared Sub Ver_Form(yForm As Form, xCaption As String)
    Dim FrmAdd As DocumentWindow
    FrmAdd = Nothing

    If FrmAdd Is Nothing Then
      FrmAdd = New DocumentWindow()
      FrmAdd.Text = xCaption
      FrmAdd.CloseAction = DockWindowCloseAction.Hide

      yForm.FormBorderStyle = FormBorderStyle.None
      yForm.TopLevel = False
      yForm.Dock = DockStyle.Fill
      FrmAdd.Controls.Add(yForm)
      MDIMenu.RadDock1.AddDocument(FrmAdd)

      yForm.Show()

    Else
      FrmAdd.Show()
    End If

    MDIMenu.RadDock1.ActiveWindow = FrmAdd
  End Sub

  Public Shared Sub formatear_grid(ByVal dgvListado As UltraGrid)
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    dgvListado.DisplayLayout.Override.AllowAddNew = UltraWinGrid.AllowAddNew.No
    'dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
    dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowColMoving = UltraWinGrid.AllowColMoving.NotAllowed
    dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
      Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
    End If

    dgvListado.DisplayLayout.Appearance = Appearance1

    dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect

    Appearance62.BackColor = Color.RoyalBlue   'Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance62.BackColor2 = Color.LightCyan   'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = Color.Blue
    Appearance62.ThemedElementAlpha = Alpha.Transparent
    dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

    Appearance63.BackColor = Color.SteelBlue
    Appearance63.BackColor2 = Color.LightCyan
    Appearance63.BackGradientStyle = GradientStyle.Vertical
    Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
    dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

    dgvListado.DisplayLayout.Override.HeaderClickAction = UltraWinGrid.HeaderClickAction.SortSingle

    ''Appearance64.BackColor = Color.White
    Appearance64.BackColor = Color.LightSteelBlue
    'Appearance64.BackColor2 = Color.White
    'Appearance64.BackGradientStyle = GradientStyle.Vertical        
    'Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    dgvListado.DisplayLayout.RowConnectorStyle = UltraWinGrid.RowConnectorStyle.Solid

    ''Me.dgvListado.Font = New Font("Times New Roman", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    'dgvListado.DisplayLayout.Override.SelectTypeRow = UltraWinGrid.SelectType.Default
    'Para seleccionar toda la Fila
    dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect
    dgvListado.UpdateMode = UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    'Me.dgvListado.Location = New Point(0, 60)
    'Me.dgvListado.Name = "dgvListado"
    'Me.dgvListado.Size = New Size(656, 239)
    'Me.dgvListado.TabIndex = 1
    'Me.dgvListado.UpdateMode = UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
  End Sub

  Public Shared Sub formatear_grid_Edit(ByVal dgvListado As UltraGrid)
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    'dgvListado.DisplayLayout.Override.AllowAddNew = UltraWinGrid.AllowAddNew.No
    'dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
    'dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowColMoving = UltraWinGrid.AllowColMoving.NotAllowed
    dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
      Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
    End If

    dgvListado.DisplayLayout.Appearance = Appearance1

    dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect

    Appearance62.BackColor = Color.RoyalBlue   'Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance62.BackColor2 = Color.LightCyan   'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = Color.Blue
    Appearance62.ThemedElementAlpha = Alpha.Transparent
    dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

    Appearance63.BackColor = Color.SteelBlue
    Appearance63.BackColor2 = Color.LightCyan
    Appearance63.BackGradientStyle = GradientStyle.Vertical
    Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
    dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

    dgvListado.DisplayLayout.Override.HeaderClickAction = UltraWinGrid.HeaderClickAction.Default

    ''Appearance64.BackColor = Color.White
    Appearance64.BackColor = Color.LightSteelBlue
    'Appearance64.BackColor2 = Color.White
    'Appearance64.BackGradientStyle = GradientStyle.Vertical        
    'Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    dgvListado.DisplayLayout.RowConnectorStyle = UltraWinGrid.RowConnectorStyle.Solid

    ''Me.dgvListado.Font = New Font("Times New Roman", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    'dgvListado.DisplayLayout.Override.SelectTypeRow = UltraWinGrid.SelectType.Default
    'Para seleccionar toda la Fila
    'dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect
    'Me.dgvListado.Location = New Point(0, 60)
    'Me.dgvListado.Name = "dgvListado"
    'Me.dgvListado.Size = New Size(656, 239)
    'Me.dgvListado.TabIndex = 1
    'Me.dgvListado.UpdateMode = UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
  End Sub

  Public Shared Sub formatear_grid_Panel(ByVal dgvListado As UltraGrid)
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    dgvListado.DisplayLayout.Override.AllowAddNew = UltraWinGrid.AllowAddNew.No
    'dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
    dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowColMoving = UltraWinGrid.AllowColMoving.NotAllowed
    dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[True]
    dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 98
    Appearance1.BackColor = Color.White 'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
    Appearance1.ImageBackground = Global.Phoenix.My.Resources.Resources.usuarios         'foto_e_commerce_1
    dgvListado.DisplayLayout.Appearance = Appearance1

    dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect
    '--------------------------
    Appearance62.BackGradientStyle = GradientStyle.None
    Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 8.25!
    Appearance62.ForeColor = Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
    Appearance62.ImageBackground = CType(Infragistics.Documents.Excel.Resources.GetObject("Appearance55.ImageBackground"), Image)
    Appearance62.ImageBackgroundStyle = ImageBackgroundStyle.Tiled
    Appearance62.TextHAlignAsString = "Left"
    Appearance62.ThemedElementAlpha = Alpha.Transparent
    dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62
    dgvListado.DisplayLayout.Override.HeaderStyle = HeaderStyle.XPThemed

    dgvListado.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle

    ''Appearance64.BackColor = Color.White
    Appearance64.BackColor = Color.LemonChiffon
    Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    'dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    dgvListado.DisplayLayout.RowConnectorStyle = RowConnectorStyle.Solid

    ''dgvListado.Font = New Font("Times New Roman", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    dgvListado.DisplayLayout.Override.SelectTypeRow = SelectType.Single
    'Para seleccionar toda la Fila
    dgvListado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

  End Sub

  Public Shared Sub formatear_grid_multiSelect(ByVal dgvListado As UltraGrid)
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    dgvListado.DisplayLayout.Override.AllowAddNew = UltraWinGrid.AllowAddNew.No
    'dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
    dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    dgvListado.DisplayLayout.Override.AllowColMoving = UltraWinGrid.AllowColMoving.NotAllowed
    dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
      Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
    End If

    dgvListado.DisplayLayout.Appearance = Appearance1

    dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect

    Appearance62.BackColor = Color.RoyalBlue   'Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance62.BackColor2 = Color.LightCyan   'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = Color.Blue
    Appearance62.ThemedElementAlpha = Alpha.Transparent
    dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

    Appearance63.BackColor = Color.SteelBlue
    Appearance63.BackColor2 = Color.LightCyan
    Appearance63.BackGradientStyle = GradientStyle.Vertical
    Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
    dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

    dgvListado.DisplayLayout.Override.HeaderClickAction = UltraWinGrid.HeaderClickAction.Default

    ''Appearance64.BackColor = Color.White
    Appearance64.BackColor = Color.LightSteelBlue
    'Appearance64.BackColor2 = Color.White
    'Appearance64.BackGradientStyle = GradientStyle.Vertical        
    'Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    dgvListado.DisplayLayout.RowConnectorStyle = UltraWinGrid.RowConnectorStyle.Solid

    ''dgvListado.Font = New Font("Times New Roman", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    'dgvListado.DisplayLayout.Override.SelectTypeRow = UltraWinGrid.SelectType.Default
    'Para seleccionar toda la Fila
    dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect
    'dgvListado.Location = New Point(0, 60)
    'dgvListado.Name = "dgvListado"
    'dgvListado.Size = New Size(656, 239)
    'dgvListado.TabIndex = 1
    'dgvListado.UpdateMode = UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
  End Sub

  'Private Sub formatear_grid()
  '    Dim Appearance1 As Appearance = New Appearance
  '    Dim Appearance62 As Appearance = New Appearance
  '    Dim Appearance63 As Appearance = New Appearance
  '    Dim Appearance64 As Appearance = New Appearance
  '    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
  '    Me.dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
  '    Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
  '    Me.dgvListado.DisplayLayout.Override.AllowAddNew = UltraWinGrid.AllowAddNew.No
  '    'Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
  '    Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
  '    Me.dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
  '    Me.dgvListado.DisplayLayout.Override.AllowColMoving = UltraWinGrid.AllowColMoving.NotAllowed
  '    Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[True]
  '    Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
  '    Me.dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

  '    Appearance1.AlphaLevel = 98
  '    Appearance1.BackColor = Color.White 'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
  '    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
  '    'Appearance1.ImageBackgroundAlpha = Alpha.UseAlphaLevel
  '    ''Appearance1.BorderAlpha = Alpha.Opaque

  '    'Appearance1.BackColor = Color.White
  '    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
  '    Appearance1.ImageBackground = Global.Phoenix.My.Resources.Resources.fileprint        'foto_e_commerce_1
  '    Me.dgvListado.DisplayLayout.Appearance = Appearance1

  '    Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
  '    Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
  '    'Me.dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect
  '    '--------------------------
  '    Appearance62.BackGradientStyle = GradientStyle.None
  '    Appearance62.FontData.BoldAsString = "True"
  '    Appearance62.FontData.Name = "Tahoma"
  '    Appearance62.FontData.SizeInPoints = 8.25!
  '    Appearance62.ForeColor = Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
  '    Appearance62.ImageBackground = CType(Resources.GetObject("Appearance55.ImageBackground"), Image)
  '    Appearance62.ImageBackgroundStyle = ImageBackgroundStyle.Tiled
  '    Appearance62.TextHAlignAsString = "Left"
  '    Appearance62.ThemedElementAlpha = Alpha.Transparent
  '    Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62
  '    Me.dgvListado.DisplayLayout.Override.HeaderStyle = HeaderStyle.XPThemed

  '    Me.dgvListado.DisplayLayout.Override.HeaderClickAction = UltraWinGrid.HeaderClickAction.SortSingle

  '    ''Appearance64.BackColor = Color.White
  '    Appearance64.BackColor = Color.LemonChiffon
  '    Appearance64.FontData.BoldAsString = "True"
  '    Appearance64.ForeColor = Color.Navy
  '    'Appearance64.ForeColor = Color.White
  '    Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

  '    Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
  '    'dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
  '    Me.dgvListado.DisplayLayout.RowConnectorStyle = UltraWinGrid.RowConnectorStyle.Solid

  '    ''Me.dgvListado.Font = New Font("Times New Roman", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

  '    'para Seleccionar solo una Fila
  '    Me.dgvListado.DisplayLayout.Override.SelectTypeRow = UltraWinGrid.SelectType.Single
  '    'Para seleccionar toda la Fila
  '    Me.dgvListado.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.RowSelect

  'End Sub

End Class
