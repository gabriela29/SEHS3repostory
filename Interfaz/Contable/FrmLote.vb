Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports CapaLogicaNegocio.Bll
Imports Microsoft.Office.Interop
Imports System.Xml

Public Class FrmLote

  Public pLoteId As Long, pEntidad As Long, pExternal As Integer = 10
  Public ListadoDoc As DataTable
  Public IdUsuario, pEmpresaId As Integer, pTipo As String, pFicha As String = ""
  Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
  Dim objApp As Excel.Application
  Dim objBook As Excel._Workbook

  Private Sub llenar_combos()
    Try
      With Me.cboAlmacen
        .DataSource = GestionTablas.dtFAlmacen
        '.DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

      Dim lAnios As New ClsCrearMeses

      With cboMeses
        .DataSource = Nothing
        .DataSource = lAnios.GetList(False, False)
        .Refresh()
        .ValueMember = "codigo"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

      With cboAnio
        .DataSource = Nothing
        .DataSource = lAnios.GetList_anios()
        .Refresh()
        .ValueMember = "nombre"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With


    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Almacén"
      .Columns(1).Width = cboAlmacen.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
    If cboAlmacen.ActiveRow Is Nothing Then
      If Not cboAlmacen.Text = "" Then
        cboAlmacen.Focus()
      End If
    End If

  End Sub

  Private Sub FrmLote_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()

    cboAnio.Text = Year(Date.Now)
    cboMeses.Value = Month(Date.Now)
  End Sub

  Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork
    Dim vCodigo_Uni As Integer = 0, vCodigo_Alm As Integer = 0, xtipo As String = "", vAnio As Integer = 0, vMes As Integer = 0
    Dim DtList As New DataTable

    vCodigo_Uni = GestionSeguridadManager.gUnidadId


    If Not Trim(cboAlmacen.Text) = "" Then
      vCodigo_Alm = cboAlmacen.Value
    End If

    If Not Trim(cboAnio.Text) = "" Then
      vAnio = cboAnio.Value
    End If

    vMes = cboMeses.Value

    Try
      DtList = loteManager.GetList(0, vCodigo_Alm, 0, "", Integer.Parse(vAnio), Integer.Parse(vMes), pFicha)

      e.Result = DtList

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted
    Try
      If pFicha = "BORRADOR" Then
        dgvListado.DataSource = CType(e.Result, DataTable)
        dgvListado.DataBind()
        If dgvListado.Rows.Count() > 0 Then

        End If
      ElseIf pFicha = "PROCESADO" Then
        dgvProvision.DataSource = CType(e.Result, DataTable)
        dgvProvision.DataBind()
        If dgvProvision.Rows.Count() > 0 Then

        End If
      ElseIf pFicha = "ASSINET" Then
        dgvReposicion.DataSource = CType(e.Result, DataTable)
        dgvReposicion.DataBind()
        If dgvReposicion.Rows.Count() > 0 Then

        End If
      End If
      picAjaxBig.Visible = False
      gpConsulta.Enabled = True
    Catch ex As Exception
      MessageBox.Show(ex.ToString)
    End Try
  End Sub

  Public Function ListarCondicion() As Boolean
    picAjaxBig.Visible = True
    gpConsulta.Enabled = False
    If Not bwLlenar_Grid.IsBusy Then
      bwLlenar_Grid.RunWorkerAsync()
    End If
  End Function

  Public Function ListarConta() As Boolean
    picAjaxBig.Visible = True
    gpConsulta.Enabled = False
    If Not bwLotesConta.IsBusy Then
      bwLotesConta.RunWorkerAsync()
    End If
  End Function

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(1).Hidden = True
      .Columns("fecha").Hidden = True
      .Columns(3).Width = 350

    End With
  End Sub

  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
    pFicha = "BORRADOR"
    Call ListarCondicion()
  End Sub


  Private Sub cboMeses_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMeses.InitializeLayout
    With cboMeses.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboMeses.Width
    End With
  End Sub

  Private Sub tsNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNuevo.Click
    'FrmLote_GastosNM.ShowDialog()    

    Dim frm As FrmLoteNM = New FrmLoteNM

    frm.swNuevo = True
    frm.pAlmacenId = cboAlmacen.Value
    frm.vAlmacen = cboAlmacen.Text

    With frm
      .pAlmacenId = cboAlmacen.Value
      .vAlmacen = cboAlmacen.Text
      .ShowDialog()
    End With
  End Sub

  Private Sub tsDigitación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDigitación.Click
    Dim xTipo As String = ""
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim FrmRC As New FrmLote_Detalle
        'With FrmRC
        'xTipo = dgvListado.DisplayLayout.ActiveRow.Cells("tipo").Value

        FrmRC.NroLote = dgvListado.DisplayLayout.ActiveRow.Cells("loteid").Value
        FrmRC.Lote = dgvListado.DisplayLayout.ActiveRow.Cells("nombre").Value
        FrmRC.vCodigo_Almacen = cboAlmacen.Value
        FrmRC.vAlmacen = cboAlmacen.Text
        FrmRC.vCerrado = dgvListado.DisplayLayout.ActiveRow.Cells("estado").Value
        FrmRC.pMes = dgvListado.DisplayLayout.ActiveRow.Cells("mes").Value
        FrmRC.pAnio = dgvListado.DisplayLayout.ActiveRow.Cells("anio").Value
        FrmRC.pEntidad = pEntidad
        Call LibreriasFormularios.Ver_Form(FrmRC, "Actualizar Lote")
        'End With

      Else
        MessageBox.Show("Debe seleccionar un Registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Else
      MessageBox.Show("No hay registros", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If

  End Sub

  Private Sub tsActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar.Click
    pFicha = "BORRADOR"
    Call ListarCondicion()
  End Sub

  Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    Me.Close()
  End Sub

  Private Sub tsCerrarD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrarD.Click
    Me.Close()
    MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
  End Sub

  Private Sub RptAsinto_Lotes(ByVal vCodigo As Long, ByVal xLote As String, ByVal xTipo As String, ByVal vProcesar As Boolean, ByVal vSubTitulo As String)


    Dim DtpLt As New DataTable
    Dim vLote As String = ""
    Try

      If Trim(vCodigo) > 0 Then
        DtpLt = loteManager.Asiento_Lote(vCodigo, vProcesar)
      Else
        MsgBox("Debe Seleccionar un Lote", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
        Exit Sub
      End If

      Dim frm As New FrmVisorGastos
      vLote = vCodigo & " - " & xLote
      frm.RptAsiento_Lote(DtpLt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, vSubTitulo, vLote)   'Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vLote)
      Call LibreriasFormularios.Ver_Form(frm, "Asiento Varios")
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub SendToAssinet(ByVal vLote As Long, ByVal pPeriodo As String, ByVal pNombre As String)
    Dim DtpLt As New DataTable

    Try
      Dim vFecha As String = ""
      If Trim(vLote) > 0 Then
        DtpLt = lote_gastoManager.Asiento_Lote_Gastos(vLote, "PROVISIONAR")
      Else
        MsgBox("Debe Seleccionar un Lote", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
        Exit Sub
      End If
      If Not DtpLt Is Nothing Then
        If DtpLt.Rows.Count > 0 Then
          vFecha = LibreriasFormularios.Formato_Fecha_c(Now.Date)
          Dim vXmlRequest As String

          'vXmlRequest = vXmlAssinet(DtpLt, pPeriodo, vFecha, pNombre)
          vXmlRequest = assinet.PrepararXml(DtpLt, pEntidad, 10, pPeriodo, vFecha, pNombre)

          Dim pServicio As String = ServicioAssinet.pServicioAssinet(pEntidad)
          Dim vResult As String = ""
          vResult = assinet.Enviar_Assinet(vXmlRequest, pServicio)

          FrmResult.pXml = vResult
          FrmResult.ShowDialog()

        End If
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub tsMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMostrar.Click
    pFicha = "PROCESADO"
    Call ListarCondicion()
  End Sub

  Private Sub tsProscesarAsientoProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProscesarAsientoProv.Click
    Dim DtRpt As New DataTable, xFecha As String = "", vNom_Lote As String = "", xFechaC As String = "", vPeriodo As String = ""
    Dim xLote As Long = 0, xEntidad As Integer = GestionSeguridadManager.gEntidad, vTipoLote As Integer = 0, vTipo As String = ""
    Dim vXML As String = "", xRequest As String = "", pAdrres As String = "", nnAssinet As String = ""
    Try
      If Trim(cboAlmacen.Text) = "" Then

        MessageBox.Show("Debe Seleccionar un Almacén", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Exit Sub
      End If

      If dgvProvision.Rows.Count > 0 Then
        If dgvProvision.Selected.Rows.Count > 0 Then

          vNom_Lote = GestionSeguridadManager.sUsuario & ": Provisón " & dgvProvision.DisplayLayout.ActiveRow.Cells("nombre").Value
          xLote = dgvProvision.DisplayLayout.ActiveRow.Cells("loteid").Value
          xFecha = dgvProvision.DisplayLayout.ActiveRow.Cells("fecha").Value
          nnAssinet = dgvProvision.DisplayLayout.ActiveRow.Cells("descripcion").Value
          vTipoLote = dgvProvision.DisplayLayout.ActiveRow.Cells("tipoid").Value
          vTipo = dgvProvision.DisplayLayout.ActiveRow.Cells("tipo").Value
          If nnAssinet = "" Then
            DtRpt = loteManager.Asiento_Procesado(xLote)
            'xFechaC = LibreriasFormularios.Formato_Fecha_conta(xFecha)
            vPeriodo = Format(cboMeses.Value, "00") & cboAnio.Text
            vXML = assinet.PrepararXml(DtRpt, xEntidad, vTipoLote, vPeriodo, xFechaC, vNom_Lote)
            pAdrres = assinet.Adress(xEntidad)
            xRequest = assinet.Enviar_Assinet(vXML, pAdrres)
            Call Mostrar_Respuesta(xRequest, xLote, xEntidad, vTipoLote)
          Else
            MessageBox.Show("Lote ya contabilizado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End If
      End If



    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Mostrar_Respuesta(ByVal xmldoc As String, ByVal vLote As Long, ByVal xEntidad As Integer, ByVal xTipo As String)
    Dim sr As New System.IO.StringReader(xmldoc)
    Dim reader As XmlTextReader
    Dim zResult As String = "", zLine As String = ""
    Dim ds As New DataSet()
    Dim Dt As New DataTable

    'Create the XML Reader
    reader = New XmlTextReader(sr)

    ds.ReadXml(reader)
    If ds.Tables.Count > 7 Then
      dgvRespuesta.DataSource = ds.Tables(8)
      If dgvRespuesta.Rows.Count > 0 Then
        Dim anLote As Long = 0, anGUI As String = ""
        anLote = dgvRespuesta.DisplayLayout.Rows(0).Cells(1).Value
        anGUI = dgvRespuesta.DisplayLayout.Rows(0).Cells(3).Value

        Dt = loteManager.Asiento_Assinet_Actualizar(vLote, xEntidad, anLote, anGUI, "xx", xTipo)

        dgvProvision.DataSource = Dt


      End If
    Else
      dgvRespuesta.DataSource = ds
      MessageBox.Show("No se contabilizó verificar en la ficha Respuesta", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If

    'close the reader
    reader.Close()
  End Sub

  Private Sub tsProvAsiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProvAsiento.Click
    If dgvProvision.Rows.Count > 0 Then
      Dim xLote As String = "", vTipo As String = ""
      If dgvProvision.Selected.Rows.Count > 0 Then
        xLote = dgvProvision.DisplayLayout.ActiveRow.Cells("nombre").Value
        vTipo = dgvProvision.DisplayLayout.ActiveRow.Cells("tipo").Value
        Call RptAsinto_Lotes(dgvProvision.DisplayLayout.ActiveRow.Cells("loteid").Value, xLote, vTipo, False, "ASIENTO VARIOS")
      End If
    End If
  End Sub

  Private Sub tsProvExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProvExcel.Click
    If dgvProvision.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvProvision.Selected.Rows.Count > 0 Then
        xLote = dgvProvision.DisplayLayout.ActiveRow.Cells("nombre").Value
        Call BtnExcel(dgvProvision.DisplayLayout.ActiveRow.Cells("loteid").Value, xLote, "PROVLG")
      End If
    End If
  End Sub

  Private Sub BtnExcel(ByVal vCodigo_Lote As Long, ByVal xLote As String, ByVal xTipo As String)

    Dim DtRpt As New DataTable, xCondi As String, vMsg As String = ""
    Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
    Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0
    Dim vEmpresa As String = "", vRucEmp As String = ""
    Dim xNameFile As String = ""
    Try
      Dim objBooks As Excel.Workbooks
      Dim objSheets As Excel.Sheets
      Dim objSheet As Excel._Worksheet
      'Dim range As Excel.Range

      objApp = New Excel.Application()
      objBooks = objApp.Workbooks
      objBook = objBooks.Add
      objSheets = objBook.Worksheets
      objSheet = objSheets(1)
      If Not Trim(cboAlmacen.Text) = "" Then
        vUni = cboAlmacen.Value
      Else
        vMsg = "Debe Seleccionar un Almacén"
        Exit Sub
      End If

      If vCodigo_Lote > 0 Then
        DtRpt = loteManager.Asiento_Lote(vCodigo_Lote, xTipo)
        xCondi = "Asiento de " & xTipo & " : " & xLote & " - " & vCodigo_Lote

        'Call ExportarExcel(objApp, DtRpt, xCondi)
        Call ExportarExcel_ASSINET(objApp, DtRpt, xCondi)
        'objApp.Visible = True
      Else
        Exit Sub
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub ExportarExcel_ASSINET(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

    Dim DtRw As DataRow
    Dim xfield, V, H As Long
    Dim Centro_Costo As Long = 0
    Dim xPt As String = ""
    Dim xCount As String = ""
    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


    Dim objCelda As Excel.Range

    ''objCelda = ObExel.Range("E2", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    ''objCelda = ObExel.Range("F3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    objCelda = ObExel.Range("H3", Type.Missing)
    objCelda.EntireColumn.ColumnWidth = 40
    ''objCelda = ObExel.Range("H3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    ''objCelda = ObExel.Range("I3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3

    ' ''objCelda = objHojaExcel.Range("C3", Type.Missing)
    ' ''objCelda.Value = "Nombre"


    objCelda = ObExel.Range("F2", Type.Missing)
    If xPt = "." Then
      objCelda.EntireColumn.NumberFormat = "0.00"
    Else
      objCelda.EntireColumn.NumberFormat = "0,00"
    End If

    xfield = 1
    V = 2
    H = 1


    'ObExel.Workbooks.Add()
    'Empezamos a Pasar los datos a Excel
    'Primera Linea
    ObExel.Cells(1, 1) = "AccountCode"

    ObExel.Cells(1, 2) = "SubAccountCode"

    ObExel.Cells(1, 3) = "FundCode"

    ObExel.Cells(1, 4) = "FunctionCode"

    ObExel.Cells(1, 5) = "RestrictionCode"

    ObExel.Cells(1, 6) = "EntityValue"

    ObExel.Cells(1, 7) = "SendMemo"

    ObExel.Cells(1, 8) = "Description"

    ObExel.Cells(1, 9) = "DueDate"

    ObExel.Cells(1, 10) = "Memo"

    ObExel.Cells(1, 11) = "InvoiceNumber"

    ObExel.Cells(1, 12) = "InvoiceDate"



    For Each DtRw In Dtp.Rows
      With ObExel

        'Demas Lineas
        .Cells(V, H) = (DtRw("cuenta"))
        .Cells(V, H + 1) = (DtRw("libre"))
        .Cells(V, H + 2) = 10
        .Cells(V, H + 3) = (DtRw("centro_costo"))

        .Cells(V, H + 4) = DtRw("restriccion")


        .Cells(V, H + 5) = FormatNumber(CSng(DtRw("importe")), 2, TriState.True, TriState.False, TriState.True)

        .Cells(V, H + 6) = "False"

        .Cells(V, H + 7) = Mid(Trim(DtRw("glosa")), 1, 50)
        If IsDate(DtRw("duefecha")) Then
          .Cells(V, H + 8) = DtRw("duefecha")

          .Cells(V, H + 10) = DtRw("invoicenumber")
          .Cells(V, H + 11) = DtRw("invoicedate")
        End If
      End With
      V = V + 1
    Next DtRw

    ObExel.Visible = True
  End Sub

  Private Sub RptContabilizar_Asinto_Lotes()


    Dim DtProv As New DataTable, DtPagos As New DataTable
    Dim vLote As String = ""
    Try



      If dgvListado.Rows.Count > 0 Then
        Dim xPeriodo As String = "", xNombre As String = ""
        If dgvListado.Selected.Rows.Count > 0 Then
          vLote = dgvListado.DisplayLayout.ActiveRow.Cells("loteid").Value
          xNombre = dgvListado.DisplayLayout.ActiveRow.Cells("nombre").Value
          xPeriodo = Format(dgvListado.DisplayLayout.ActiveRow.Cells("mes").Value, "00")
          xPeriodo = xPeriodo & dgvListado.DisplayLayout.ActiveRow.Cells("anio").Value
          If Trim(vLote) > 0 Then

            Call SendToAssinet(vLote, xPeriodo, xNombre)
          Else
            MsgBox("Debe Seleccionar un Lote", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
            Exit Sub
          End If
        End If
      End If


    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub RptProcesar_Asinto_Lotes(ByVal vCodigo As Long, ByVal xLote As String)
    Try
      If dgvListado.Rows.Count > 0 Then

        If dgvListado.Selected.Rows.Count > 0 Then
          xLote = dgvListado.DisplayLayout.ActiveRow.Cells("nombre").Value
          Call RptAsinto_Lotes(dgvListado.DisplayLayout.ActiveRow.Cells("loteid").Value, xLote, "ASIENTO", True, "ASIENTO LOTE")
        End If
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
    Me.Close()
  End Sub

  Private Sub tsAsiento_Reposicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAsiento_Reposicion.Click
    If dgvReposicion.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvReposicion.Selected.Rows.Count > 0 Then
        xLote = dgvReposicion.DisplayLayout.ActiveRow.Cells("nombre").Value
        Call RptAsinto_Lotes(dgvReposicion.DisplayLayout.ActiveRow.Cells("lotegastosid").Value, xLote, "PAGOLG", False, "ASIENTO DE PAGOS")
      End If
    End If
  End Sub

  Private Sub tsExcel_Reposicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcel_Reposicion.Click
    If dgvReposicion.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvReposicion.Selected.Rows.Count > 0 Then
        xLote = dgvReposicion.DisplayLayout.ActiveRow.Cells("nombre").Value
        Call BtnExcel(dgvReposicion.DisplayLayout.ActiveRow.Cells("lotegastosid").Value, xLote, "PAGOLG")
      End If
    End If
  End Sub

  Private Sub tsPgActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPgActualizar.Click
    pFicha = "ASSINET"
    Call ListarCondicion()
  End Sub

  Private Sub tsPrevio_Click(sender As Object, e As EventArgs) Handles tsPrevio.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells("nombre").Value
        Call RptAsinto_Lotes(dgvListado.DisplayLayout.ActiveRow.Cells("loteid").Value, xLote, "ASIENTO", False, "ASIENTO LOTE")
      End If
    End If
  End Sub

  Private Sub tsSendPagosAssinet_Click(sender As Object, e As EventArgs) Handles tsSendPagosAssinet.Click

  End Sub

  Private Sub dgvProvision_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvProvision.InitializeLayout

  End Sub

  Private Sub tsProcesar_Click(sender As Object, e As EventArgs) Handles tsProcesar.Click
    If dgvListado.Rows.Count > 0 Then
      Dim vLote As Long = 0, xLote As String = "", sReposicion As Single = 0
      If dgvListado.Selected.Rows.Count > 0 Then
        vLote = dgvListado.DisplayLayout.ActiveRow.Cells("loteid").Value
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells("nombre").Value
        sReposicion = Single.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("saldo").Value)
        If sReposicion = 0 Then
          If MessageBox.Show("Una vez enviado a para contabilidad ya no podrá hacer ningún cambio en este lote." & Chr(13) & "¿Aún asi esta seguro de proceder?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Call RptProcesar_Asinto_Lotes(vLote, xLote)

            Call ListarCondicion()
          End If
        Else
          MessageBox.Show("El SaldoRep debe estar en cero (0) para poder provisionar", "VERIFICAR", MessageBoxButtons.OK)
        End If
      End If
    End If
  End Sub
  Private Sub dgvProvision_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProvision.KeyDown
    If dgvProvision.Rows.Count > 0 Then
      If dgvProvision.Selected.Rows.Count > 0 Then
        Dim vTienePermiso As Boolean = False, _codigo As Long = 0

        If e.KeyData = Keys.Shift + Keys.Delete Then
          If dgvProvision.Rows.Count > 0 Then
            If dgvProvision.Selected.Rows.Count > 0 Then
              Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "gasto-delete", vTienePermiso)
              If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
                _codigo = Long.Parse((dgvProvision.DisplayLayout.ActiveRow.Cells(0).Value))
                If MessageBox.Show("¿Está seguro de Eliminar este Documento ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  If loteManager.Eliminar_Asiento(_codigo, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    pFicha = "ASSINET"
                    Call ListarCondicion()
                  End If
                End If
              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub dgvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListado.KeyDown
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim vTienePermiso As Boolean = False, _codigo As Long = 0

        If e.KeyData = Keys.Shift + Keys.Delete Then
          If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
              Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "gasto-delete", vTienePermiso)
              If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
                _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                If MessageBox.Show("¿Está seguro de Eliminar este Lote ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  If loteManager.Eliminar_Lote(_codigo, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    pFicha = "BORRADOR"
                    Call ListarCondicion()
                  End If
                End If
              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub dgvReposicion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvReposicion.KeyDown
    If dgvReposicion.Rows.Count > 0 Then
      If dgvReposicion.Selected.Rows.Count > 0 Then
        Dim vTienePermiso As Boolean = False, _codigo As Long = 0

        If e.KeyData = Keys.Shift + Keys.Delete Then
          If dgvReposicion.Rows.Count > 0 Then
            If dgvReposicion.Selected.Rows.Count > 0 Then
              Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "gasto-delete", vTienePermiso)
              If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
                _codigo = Long.Parse((dgvReposicion.DisplayLayout.ActiveRow.Cells(0).Value))
                If MessageBox.Show("¿Está seguro de Eliminar este Asiento ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  If loteManager.Eliminar_Asiento(_codigo, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    pFicha = "ASSINET"
                    Call ListarCondicion()
                  End If
                End If
              End If
            End If
          End If
        End If
      End If
    End If
  End Sub
End Class