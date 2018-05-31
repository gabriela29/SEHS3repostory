Imports System.ComponentModel
Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win.UltraWinGrid
Imports Telerik.WinControls.UI.Docking

Public Class FrmDeposito_Web
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

  Private Sub FrmDeposito_Web_Load(sender As Object, e As EventArgs) Handles Me.Load
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
      dtT = depositocolpwebManager.Leer_Deposito_Pendiente(cboCampania.Value, cboAlmacen.Value, cboAsistente.Value, "", "")
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
      .Columns("depositoid").Header.Caption = "ID"
      .Columns("depositoid").Width = 20
      .Columns("registro_text").Hidden = True
      .Columns("fecha").Header.Caption = "FECHA"
      .Columns("fecha").Width = 80
      .Columns("campaniaid").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("colportorid").Width = 20
      .Columns("colportor_nombre").Header.Caption = "COLPORTOR"
      .Columns("colportor_nombre").Width = 220
      .Columns("asistenteid").Width = 20
      .Columns("asistente_nombre").Header.Caption = "ASISTENTE"
      .Columns("asistente_nombre").Width = 180
      .Columns("importe").Header.Caption = "IMPORTE"
      .Columns("importe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("importe").Width = 80
      .Columns("total").Header.Caption = "TOTAL"
      .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("total").Width = 80
      .Columns("estado").Width = 20
      .Columns("cerrado").Width = 20
      .Columns("usuarioid").Hidden = True
      .Columns("ip").Hidden = True
      .Columns("operacion").Header.Caption = "#OPE"
      .Columns("operacion").Width = 50
      .Columns("banco").Width = 70
    End With
  End Sub

  Private Sub dgvFacturados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvFacturados.InitializeLayout
    With dgvFacturados.DisplayLayout.Bands(0)
      .Columns("depositoid").Header.Caption = "ID"
      .Columns("depositoid").Width = 20
      .Columns("registro_text").Hidden = True
      .Columns("fecha").Header.Caption = "FECHA"
      .Columns("fecha").Width = 80
      .Columns("campaniaid").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("colportorid").Width = 20
      .Columns("colportor_nombre").Header.Caption = "COLPORTOR"
      .Columns("colportor_nombre").Width = 220
      .Columns("asistenteid").Width = 20
      .Columns("asistente_nombre").Header.Caption = "ASISTENTE"
      .Columns("asistente_nombre").Width = 180
      .Columns("importe").Header.Caption = "IMPORTE"
      .Columns("importe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("importe").Width = 80
      .Columns("total").Header.Caption = "TOTAL"
      .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
      .Columns("total").Width = 80
      .Columns("estado").Width = 20
      .Columns("cerrado").Width = 20
      .Columns("usuarioid").Hidden = True
      .Columns("ip").Hidden = True
      .Columns("operacion").Header.Caption = "#OPE"
      .Columns("operacion").Width = 50
      .Columns("banco").Width = 70
    End With
  End Sub

  Private Sub tsDetalle_Pendiente_Click(sender As Object, e As EventArgs) Handles tsDetalle_Pendiente.Click
    Try
      Dim _Codigo As Long = 0, _File As String = ""
      Dim dtTemp As New DataTable
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          If dgvListado.Selected.Rows.Count = 1 Then
            _Codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
            If Not (dgvListado.DisplayLayout.ActiveRow.Cells("voucher").Value) = "" Then
              _File = ((dgvListado.DisplayLayout.ActiveRow.Cells("voucher").Value))
            End If
          Else
            MessageBox.Show("Sólo debe seleccionar un Registro", "AVISO", MessageBoxButtons.OK)
            Exit Sub
          End If

        End If
      End If

      If _Codigo = 0 Then Exit Sub
      dtTemp = reportes_colportajewebManager.Deposito_Detalle_Web(_Codigo)
      Dim yForm As New frmVisor_PedidoWeb

      yForm.RptDetalle_Deposito(_Codigo, dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle de Depósito Web Colportaje", "Depósito Nro: " & _Codigo, _File)

      Call LibreriasFormularios.Ver_Form(yForm, "Detalle Pagos")


    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try
  End Sub

  Private Sub tsFacturar_Click(sender As Object, e As EventArgs) Handles tsFacturar.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then

        Dim vCodigo As Long = 0, vAsistenteId As Long = 0, vAsistente As String = "", vUsuarioId As Long = 0
        Dim vColportorid As Long = 0, vColportor As String = ""
        Dim _Estado As Boolean = False, _Cerrado As Boolean = False, vImporte As Single = 0

        vCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("depositoid").Value))
        vColportorid = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("colportorid").Value))
        vColportor = dgvListado.DisplayLayout.ActiveRow.Cells("colportor_nombre").Value

        vAsistenteId = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("asistenteid").Value))
        vAsistente = dgvListado.DisplayLayout.ActiveRow.Cells("asistente_nombre").Value

        vImporte = Single.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("importe").Value))

        _Estado = Boolean.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("estado").Value)
        _Cerrado = Boolean.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("cerrado").Value)

        If _Cerrado = False Then
          MessageBox.Show("No se puede facturar por no estar cerrado", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Exit Sub
        End If

        vUsuarioId = GestionSeguridadManager.idUsuario
        FrmAdd = Nothing
        If _Estado Then
          If _Cerrado Then
            If FrmAdd Is Nothing Then
              FrmAdd = New DocumentWindow()
              FrmAdd.Text = "Facturar Depósito Colportor Web"
              FrmAdd.CloseAction = DockWindowCloseAction.Hide

              Dim yForm As New FrmFacturar_Deposito_Web
              yForm.FormBorderStyle = FormBorderStyle.None
              yForm.TopLevel = False
              yForm.Dock = DockStyle.Fill
              FrmAdd.Controls.Add(yForm)
              MDIMenu.RadDock1.AddDocument(FrmAdd)
              yForm.pDepositoId = vCodigo
              yForm.pColportorId = vColportorid
              yForm.pColportor = vColportor
              yForm.pAsistenteid = vAsistenteId
              yForm.pAsistente = vAsistente
              yForm.pCodigo_Alm = cboAlmacen.Value
              yForm.pAlmacen = cboAlmacen.Text
              yForm.pImporte = vImporte
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
        If MessageBox.Show("¿Está seguro de Cambiar Cerrado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
          _Codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
          If depositocolpwebManager.Cambiar_Cerrado(_Codigo, _vUs, _vCaja) Then
            pFicha = "P"
            Call Actualizar()
          End If
        End If
      End If

    End If
  End Sub

  Private Sub tsRptFDetalle_Click(sender As Object, e As EventArgs) Handles tsRptFDetalle.Click
    Try
      Dim _Codigo As Long = 0, _File As String = ""
      Dim dtTemp As New DataTable
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          If dgvListado.Selected.Rows.Count = 1 Then
            _Codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
            If Not (dgvListado.DisplayLayout.ActiveRow.Cells("voucher").Value) = "" Then
              _File = ((dgvListado.DisplayLayout.ActiveRow.Cells("voucher").Value))
            End If
          Else
            MessageBox.Show("Sólo debe seleccionar un Registro", "AVISO", MessageBoxButtons.OK)
            Exit Sub
          End If

        End If
      End If

      If _Codigo = 0 Then Exit Sub
      dtTemp = reportes_colportajewebManager.Deposito_Detalle_Web(_Codigo)
      Dim yForm As New frmVisor_PedidoWeb

      yForm.RptDetalle_Deposito(_Codigo, dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle de Depósito Web Colportaje", "Depósito Nro: " & _Codigo, _File)

      Call LibreriasFormularios.Ver_Form(yForm, "Detalle Pagos")


    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try
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
        vCodigoF = Long.Parse((dgvFacturados.DisplayLayout.ActiveRow.Cells("movbanid").Value))
      End If
    End If
    If vCodigoF > 0 Then
      If Val(vCodigoF) > 0 Then

        Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(vCodigoF), cboAlmacen.Value, cboDocumento.Value, "XCOBRAR", False, False)

      End If
    End If
  End Sub

  Private Sub tsMostrarFact_Click(sender As Object, e As EventArgs) Handles tsMostrarFact.Click
    pFicha = "F"
    Call Actualizar()
  End Sub

  Private Sub tsExportaExcell_Click(sender As Object, e As EventArgs) Handles tsExportaExcell.Click

  End Sub
End Class