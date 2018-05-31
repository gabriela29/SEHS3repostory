Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop
Imports Telerik.WinControls.UI.Docking

Public Class FrmIngreso_Importacion
  Public _codigo As Long, _Codigo_Doc As Integer
  Dim objApp As Excel.Application
  Dim objBook As Excel._Workbook
  Private FrmAdd As DocumentWindow
  Private FrmNC As DocumentWindow


  Private Sub llenar_combos()
    Try

      With cboDocumento
        .DataSource = Nothing
        .DataSource = GestionTablas.dtperdoc
        .Refresh()
        .ValueMember = "documentoid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With

      With Me.cboAlmacen
        .DataSource = GestionTablas.dtFAlmacen
        '.DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
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

  Private Sub cboUnidad_Negocio_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    'If Not bwAlmacen.IsBusy Then
    '    cboAlmacen.Text = [String].Empty
    '    picAjax.Visible = True
    '    bwAlmacen.RunWorkerAsync()
    'End If
    _codigo = 0
  End Sub

  Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
    If cboAlmacen.ActiveRow Is Nothing Then
      If Not cboAlmacen.Text = "" Then
        cboAlmacen.Focus()
      End If
    End If
    _codigo = 0
  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0


    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If

    vOpcion = cboDocumento.Value
    vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
    vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

    DtRes = importacionManager.Leer(xCod_Alm, 0, 0, "", vDesde, vHasta, 200)

    e.Result = DtRes

  End Sub

  Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted
    dgvListado.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Res(CType(e.Result, DataTable))
    picAjaxRes.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
    'dgvListado.Refresh()
    Me.lblRegistros_Res.Text = dgvListado.Rows.Count & " Registros"
  End Sub

  Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vDeudaVenc, vDeudaMora, vDeudaSM
    Dim vCod_a As Long = 0
    vDeudaVenc = 0
    vDeudaMora = 0
    vDeudaSM = 0
    CalcularTotales_Res = False
    'If Not Trim(TxtDNI_RUC.Text) = "" Then
    '    vCod_a = CInt(TxtDNI_RUC.Text)
    'End If
    Try
      DtTot = DtTotales 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

      For Each Drs In DtTot.Rows

        'Select Case Trim(Drs("tipo").ToString)
        '    Case "M"
        '        vDeudaMora = CSng(Drs("monto").ToString)
        '    Case "V"
        '        vDeudaVenc = CSng(Drs("monto").ToString)
        '    Case "T"
        '        vDeudaSM = CSng(Drs("monto").ToString)

        'End Select
        'vTotal = vTotal + CSng(Drs("").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
      'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
      'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
      'Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
      CalcularTotales_Res = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20
      .Columns(1).Hidden = True
      .Columns(2).Width = 100
      .Columns(2).Header.Caption = "TIPO"
      .Columns(3).Width = 100
      .Columns(3).Header.Caption = "FECHA"
      .Columns(4).Hidden = True
      .Columns(5).Width = 100
      .Columns(5).Header.Caption = "DOCUMENTO"
      .Columns(6).Width = 120
      .Columns(6).Header.Caption = "NUMERO"
      .Columns(7).Width = 40
      .Columns(7).Header.Caption = " "
      .Columns(8).Hidden = True
      .Columns(9).Width = 250
      .Columns(9).Header.Caption = "PERSONA"
      .Columns(10).Hidden = True
      .Columns(11).Width = 50
      .Columns(11).Header.Caption = " "
      .Columns(12).Width = 80
      .Columns(12).Header.Caption = "SUB TOTAL"
      .Columns(12).CellAppearance.TextHAlign = HAlign.Right
      .Columns(13).Hidden = True
      .Columns(14).Width = 80
      .Columns(14).Header.Caption = "IGV"
      .Columns(14).CellAppearance.TextHAlign = HAlign.Right
      .Columns(15).Width = 80
      .Columns(15).Header.Caption = "TOTAL"
      .Columns(15).CellAppearance.TextHAlign = HAlign.Right
      .Columns(16).Hidden = True
      .Columns(17).Width = 100
      .Columns(18).Width = 100
      .Columns(19).Hidden = True
      .Columns(20).Hidden = True
      .Columns(21).Hidden = True
      .Columns(22).Hidden = True
      .Columns(23).Hidden = True
      .Columns(24).Hidden = True
      .Columns(25).Width = 40
      '.Columns(26).Hidden = True
      '.Columns(27).Width = 40
      '.Columns(28).Hidden = True
      '.Columns(29).Width = 40
    End With
  End Sub

  Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
    _codigo = 0
    'Call Totales_Cero()
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        _Codigo_Doc = Integer.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_doc").Value))
        'Call Mostrar_Detalles()
      Else
        _codigo = 0
      End If
    End If
  End Sub

  Private Sub FrmIngreso_Importacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub


  Private Sub FrmIngreso_Importacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

  End Sub

  Private Sub FrmIngreso_Importacion_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
    cboDesde.Value = ("01/" & Now.Month & "/" & Now.Year)
    cboHasta.Value = Now.Date
  End Sub

  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
    Call Actualizar()
  End Sub

  Public Sub Actualizar()
    picAjaxRes.Visible = True
    gpCriterios.Enabled = False
    gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    _codigo = 0
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboDocumento.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActualizar.Click
    Call Actualizar()
  End Sub

  Private Sub tsdCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdCompra.Click

    FrmAdd = Nothing

    If FrmAdd Is Nothing Then
      FrmAdd = New DocumentWindow()
      FrmAdd.Text = "Compra"
      FrmAdd.CloseAction = DockWindowCloseAction.Hide

      Dim yForm As New FrmIngresar_Importacion
      yForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      yForm.TopLevel = False
      yForm.Dock = DockStyle.Fill
      FrmAdd.Controls.Add(yForm)
      MDIMenu.RadDock1.AddDocument(FrmAdd)
      'yForm.Inicializa()
      yForm.pCodigo_Almacen = cboAlmacen.Value
      yForm.pAlmacen = cboAlmacen.Text
      yForm.pTipo_Mov = Tipo_Mov_Mercaderia.tCompras
      yForm.Show()
    Else
      FrmAdd.Show()
    End If
    MDIMenu.RadDock1.ActiveWindow = FrmAdd

  End Sub

  Private Sub tsdADetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdADetalle.Click
    Try
      Dim dtTemp As New DataTable
      _codigo = 0
      'Call Totales_Cero()
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        End If
      End If
      If _codigo = 0 Then Exit Sub
      dtTemp = Reportes_ComprasManager.Detalle_Documento(_codigo)

      FrmAdd = Nothing

      If FrmAdd Is Nothing Then
        FrmAdd = New DocumentWindow()
        FrmAdd.Text = "Detalle Compra"
        FrmAdd.CloseAction = DockWindowCloseAction.Hide

        Dim yForm As New FrmVisor_Compras
        yForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        yForm.TopLevel = False
        yForm.Dock = DockStyle.Fill
        FrmAdd.Controls.Add(yForm)
        MDIMenu.RadDock1.AddDocument(FrmAdd)
        yForm.RptIngresos_Mercaderia_Detalle(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle Documento de Ingreso")

        yForm.Show()

      Else
        FrmAdd.Show()
      End If
      MDIMenu.RadDock1.ActiveWindow = FrmAdd

    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Sub

  Private Sub RptAsinto_Lotes(ByVal vCodigo As Long, ByVal xLote As String, ByVal xTipo As String, ByVal vProcesar As Boolean, ByVal vSubTitulo As String)


    Dim DtpLt As New DataTable
    Dim vLote As String = ""
    Try

      If Trim(vCodigo) > 0 Then
        DtpLt = lote_gastoManager.Asiento_Lote_Mercaderia(vCodigo, xTipo)
      Else
        MsgBox("Debe Seleccionar un Lote", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
        Exit Sub
      End If

      Dim frm As New FrmVisorGastos
      vLote = vCodigo & " - " & xLote
      frm.RptAsiento_Lote(DtpLt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, vSubTitulo, vLote)   'Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vLote)
      Call LibreriasFormularios.Ver_Form(frm, "Asiento Ing.")
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub tsAsi_Futuro_Prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAsi_Futuro_Prov.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells(9).Value
        Call RptAsinto_Lotes(dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value, xLote, "PROVISIONAR", False, "ASIENTO PROVISIÓN")
      End If
    End If
  End Sub

  Private Sub tsAsFutMovMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAsFutMovMer.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells(9).Value
        Call RptAsinto_Lotes(dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value, xLote, "MOVIMIENTO", False, "ASIENTO MOVIMIENTO MERCADERIA")
      End If
    End If
  End Sub

  Private Sub tsProv_Excell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProv_Excell.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells(9).Value
        Call BtnExcel(dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value, xLote, "PROVISIONAR")
      End If
    End If

  End Sub

  Private Sub tsExcelMov_Mer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcelMov_Mer.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then
        xLote = dgvListado.DisplayLayout.ActiveRow.Cells(9).Value
        Call BtnExcel(dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value, xLote, "MOVIMIENTO")
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
        DtRpt = lote_gastoManager.Asiento_Lote_Mercaderia(vCodigo_Lote, xTipo)
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

  Private Sub tsModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsModificar.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))

      End If
    End If

  End Sub

  Private Sub tsCerrar3_Click(sender As Object, e As EventArgs) Handles tsCerrar3.Click
    Me.Close()
  End Sub

  Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click

    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim vTienePermiso As Boolean = False
        Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "ingresomercaderia-delete", vTienePermiso)
        If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
          If MessageBox.Show("Esto Afectará el control de Stock (Resultando en negativos) ¿Desea Anular?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim vxCodigo As Long = 0
            vxCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))

            If ingreso_mercaderiaManager.Eliminar(vxCodigo, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
              Call Actualizar()
            End If
          End If
        End If
      End If
    End If

  End Sub

  Private Sub tsNCMixto_Click(sender As Object, e As EventArgs) Handles tsNCMixto.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        If MessageBox.Show("¿Está seguro de Hacer una nota de crédito?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

          FrmAdd = Nothing

          If FrmAdd Is Nothing Then
            FrmAdd = New DocumentWindow()
            FrmAdd.Text = "N.C. Ingreso"
            FrmAdd.CloseAction = DockWindowCloseAction.Hide
          Else
            FrmAdd.Show()
          End If
          MDIMenu.RadDock1.ActiveWindow = FrmAdd
        End If

      End If
    End If
  End Sub


End Class