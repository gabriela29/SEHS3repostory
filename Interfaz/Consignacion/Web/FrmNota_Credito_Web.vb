Imports System.ComponentModel
Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win.UltraWinGrid
Imports Telerik.WinControls.UI.Docking
Public Class FrmNota_Credito_Web
  Private FrmAdd As DocumentWindow
  Public pFicha As String = ""

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
      With cboCampania
        .DataSource = campaniaManager.Campania_leer("")
        .ValueMember = "campaniaid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          'If pCodigo > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
          '  cboTipo.Value = pCCOSTO
          'End If
        End If
      End With
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

  Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboDocumento.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged
    If Not cboAlmacen.Text = "" Then
      With Me.cboAsistente
        .DataSource = Control_AsistenteManager.Leer_Asistentes(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, cboCampania.Value)
        '.DataBind()
        .ValueMember = "codigo_per"
        .DisplayMember = "persona"
        .MinDropDownItems = 2
        .MaxDropDownItems = 10
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With
    End If
  End Sub

  Private Sub FrmNota_Credito_Web_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
  End Sub

  Private Sub cboAsistente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboAsistente.InitializeLayout
    With cboAsistente.DisplayLayout.Bands(0)
      .Columns("codigo_per").Hidden = True
      .Columns("nrodocumento").Width = 80
      .Columns("nrodocumento").Header.Caption = "DNI-RUC"
      .Columns("persona").Width = cboAsistente.Width
      .Columns("sexo").Hidden = True
      .Columns("nrocuenta").Hidden = True
      .Columns("importe").Hidden = True
      .Columns("observacion").Hidden = True
      .Columns("usuario").Hidden = True
      .Columns("caja").Hidden = True
      .Columns("almacen").Hidden = True
      .Columns("codigo_alm").Hidden = True
      .Columns("fecha").Hidden = True
    End With

  End Sub

  Private Sub tsActualizar_Click(sender As Object, e As EventArgs) Handles tsActualizar.Click
    pFicha = "P"
    Call Actualizar()
  End Sub

  Public Sub Actualizar()

    If Not bwPendiente.IsBusy Then
      picAjaxBig.Visible = True
      bwPendiente.RunWorkerAsync()
    End If
  End Sub
  Private Sub bwPendiente_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwPendiente.DoWork
    Try
      Dim dtT As New DataTable, vPendiente As Boolean
      vPendiente = IIf(pFicha = "P", True, False)
      dtT = devolucionasiswebManager.Leer_Dev_Asis_Pendiente(cboCampania.Value, cboAlmacen.Value, cboAsistente.Value, "", "", True, vPendiente)
      e.Result = dtT
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Sub bwPendiente_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwPendiente.RunWorkerCompleted
    If pFicha = "P" Then
      dgvListado.DataSource = CType(e.Result, DataTable)
      LblRegistros.Text = dgvListado.Rows.Count & " Registros"
      'Call CalcularTotalesSPendientes()
      picAjaxBig.Visible = False
    Else
      dgvFacturados.DataSource = CType(e.Result, DataTable)
      LblRegistros.Text = dgvListado.Rows.Count & " Registros"
      'Call CalcularTotalesSPendientes()
      picAjaxBig.Visible = False
    End If
  End Sub

  Private Sub dgvListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("devolucionid").Header.Caption = "ID"
      .Columns("registro_text").Hidden = True
      .Columns("fecha").Header.Caption = "FECHA"
      .Columns("fecha").Width = 80
      .Columns("campaniaid").Hidden = True
      .Columns("campania_nombre").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("almacen_nombre").Hidden = True
      .Columns("personaid").Width = 40
      .Columns("persona_nombre").Header.Caption = "ASISTENTE"
      .Columns("persona_nombre").Width = 220
      .Columns("total").Header.Caption = "TOTAL"
      .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("estado").Width = 20
      .Columns("cerrado").Width = 20
      .Columns("usuarioid").Hidden = True
      .Columns("ip").Hidden = True
      .Columns("condicion").Hidden = True
      '.Columns("condicion").Width = 70
      .Columns("stock").Width = 50
      .Columns("stock").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("codigo_ref").Width = 50
      .Columns("codigo_ref").Header.Caption = "VENTAID"
    End With
  End Sub

  Private Sub dgvFacturados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvFacturados.InitializeLayout
    With dgvFacturados.DisplayLayout.Bands(0)
      .Columns("devolucionid").Header.Caption = "ID"
      .Columns("registro_text").Hidden = True
      .Columns("fecha").Header.Caption = "FECHA"
      .Columns("fecha").Width = 80
      .Columns("campaniaid").Hidden = True
      .Columns("campania_nombre").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("almacen_nombre").Hidden = True
      .Columns("personaid").Width = 40
      .Columns("persona_nombre").Header.Caption = "ASISTENTE"
      .Columns("persona_nombre").Width = 220
      .Columns("total").Header.Caption = "TOTAL"
      .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("estado").Width = 20
      .Columns("cerrado").Width = 20
      .Columns("usuarioid").Hidden = True
      .Columns("ip").Hidden = True
      .Columns("condicion").Header.Caption = "CONDICION"
      .Columns("condicion").Width = 70
      .Columns("stock").Hidden = True
    End With
  End Sub

  Private Sub tsDetalle_Pendiente_Click(sender As Object, e As EventArgs) Handles tsDetalle_Pendiente.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0
        tCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))

        dtTemp = reportes_colportajewebManager.Devolucion_Detalle_Web(tCodigo)

        Dim frm As New frmVisor_PedidoWeb

        frm.RptDetalle_Pedido(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle Devolución Nro: " & tCodigo.ToString)
        Call LibreriasFormularios.Ver_Form(frm, "Detalle Dev. Web.")
      End If
    End If
  End Sub

  Private Sub tsFacturar_Click(sender As Object, e As EventArgs) Handles tsFacturar.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then

        Dim vCodigo As Long = 0, vCodigo_Ref As Long = 0, vAsistente As String = "", vUsuarioId As Long = 0
        Dim _Estado As Boolean = False, _Cerrado As Boolean = False, vStock As Long = -1

        vCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("devolucionid").Value))
        vCodigo_Ref = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_ref").Value))

        vStock = dgvListado.DisplayLayout.ActiveRow.Cells("stock").Value

        _Estado = Boolean.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("estado").Value)
        _Cerrado = Boolean.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("cerrado").Value)

        If vStock < 0 Then
          MessageBox.Show("No se puede facturar por no haber STOCK suficiente", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Exit Sub
        End If

        vUsuarioId = GestionSeguridadManager.idUsuario
        FrmAdd = Nothing
        If _Estado Then
          If _Cerrado Then
            If FrmAdd Is Nothing Then
              FrmAdd = New DocumentWindow()
              FrmAdd.Text = "Facturar N.C. Colportor Web"
              FrmAdd.CloseAction = DockWindowCloseAction.Hide

              Dim yForm As New FrmNota_Credito_Colportor
              yForm.FormBorderStyle = FormBorderStyle.None
              yForm.TopLevel = False
              yForm.Dock = DockStyle.Fill
              FrmAdd.Controls.Add(yForm)
              MDIMenu.RadDock1.AddDocument(FrmAdd)

              yForm.pCodigo = vCodigo_Ref
              yForm.pDevolucionId = vCodigo
              yForm.pCodigo_Alm = cboAlmacen.Value
              yForm.pAlmacen = cboAlmacen.Text
              yForm.pDevolucionWeb = True
              yForm.Show()
            Else
              FrmAdd.Show()
            End If
            MDIMenu.RadDock1.ActiveWindow = FrmAdd
          Else
            MessageBox.Show("No se puede facturar un depósito sin cerrar", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        Else
          MessageBox.Show("No se puede facturar un depósito ANULADO", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
      End If
    End If
  End Sub

  Private Sub tsCambiarCerrado_Click(sender As Object, e As EventArgs) Handles tsCambiarCerrado.Click
    Dim _Codigo As Long = 0, _vUs As Long = 0, _vCaja As String = ""
    _vUs = GestionSeguridadManager.idUsuario
    _vCaja = My.Computer.Name
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        If MessageBox.Show("¿Está seguro de Cambiar de estado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
          _Codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
          If devolucionasiswebManager.Cambiar_Cerrado(_Codigo, _vUs, _vCaja) Then
            pFicha = "P"
            Call Actualizar()
          End If
        End If
      End If

    End If
  End Sub

  Private Sub tsRptFDetalle_Click(sender As Object, e As EventArgs) Handles tsRptFDetalle.Click
    If dgvFacturados.Rows.Count > 0 Then
      If dgvFacturados.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0
        tCodigo = Long.Parse((dgvFacturados.DisplayLayout.ActiveRow.Cells(0).Value))

        dtTemp = reportes_colportajewebManager.Detalle_Documento(tCodigo)

        Dim frm As New frmVisor_PedidoWeb

        frm.RptDetalle_Pedido(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle pedido Nro: " & tCodigo.ToString)
        Call LibreriasFormularios.Ver_Form(frm, "Detalle Ped. Web.")
      End If
    End If
  End Sub

  Private Sub tsRptFResProd_Click(sender As Object, e As EventArgs) Handles tsRptFResProd.Click
    If dgvFacturados.Rows.Count > 0 Then
      If dgvFacturados.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0
        tCodigo = Long.Parse((dgvFacturados.DisplayLayout.ActiveRow.Cells(0).Value))

        dtTemp = reportes_colportajewebManager.Resumen_Pedido_Productos(tCodigo)

        Dim frm As New frmVisor_PedidoWeb

        frm.RptResumen_Producto_Pedido(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Resumen de Productos del pedido Nro: " & tCodigo.ToString)
        Call LibreriasFormularios.Ver_Form(frm, "Res. Ped. Web.")
      End If
    End If
  End Sub

  Private Sub tsCerrarDocs_Click(sender As Object, e As EventArgs) Handles tsCerrarDocs.Click
    Me.Close()
  End Sub

  Private Sub tsCerrarD_Click(sender As Object, e As EventArgs) Handles tsCerrarD.Click
    Me.Close()
  End Sub

  Private Sub tsPrintDOS_Click(sender As Object, e As EventArgs) Handles tsPrintDOS.Click
    Dim vCodigo_Doc As Integer = 0, vCodigoF As Long = 0

    If cboDocumento.Text = "" Then
      MessageBox.Show("Debe seleccionar un tipo documento", "AVISO")
      Exit Sub
    Else
      vCodigo_Doc = cboDocumento.Value
    End If
    vCodigo_Doc = cboDocumento.Value
    If dgvFacturados.Rows.Count > 0 Then
      If dgvFacturados.Selected.Rows.Count > 0 Then
        vCodigoF = Long.Parse((dgvFacturados.DisplayLayout.ActiveRow.Cells(0).Value))
      End If
    End If
    If vCodigoF > 0 Then
      Dim vDtCabecera As New DataTable, vDtDetalle As New DataTable, vDtDzmo As New DataTable
      If ventaManager.Datos_Impresion_PWC(Long.Parse(vCodigoF), cboAlmacen.Value, vDtCabecera, vDtDetalle) Then
        If Impresion_WSpool.Print_Ticket(vCodigo_Doc, cboAlmacen.Value, cboAlmacen.Text, GestionSeguridadManager.NombrePC, vDtCabecera, vDtDetalle) Then
          'Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, vCodigo_Doc)
        End If
      End If
      vDtDzmo = reportes_consignacionManager.Datos_Impresion_Dzmo_PWC(vCodigoF)
      If Impresion_WSpool.Print_Recibo_Dzmo(20, cboAlmacen.Value, cboAlmacen.Text, GestionSeguridadManager.NombrePC, vDtDzmo) Then
        'Call ClsImpresiones.Imprimir_Rpt_DZMO(Long.Parse(ok), pCodigo_Alm, vCodigo_DocD, vFormatoD, vSerieTkD, vCopiasD, vImpresoraD)
      End If
    End If
  End Sub

  Private Sub tsMostrarFact_Click(sender As Object, e As EventArgs) Handles tsMostrarFact.Click
    pFicha = "F"
    Call Actualizar()
  End Sub

  Private Sub tsExportaExcell_Click(sender As Object, e As EventArgs) Handles tsExportaExcell.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "DevolerWebNC.xls")
  End Sub
End Class