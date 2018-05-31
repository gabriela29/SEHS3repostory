Imports Microsoft.Reporting.WinForms
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPanel_Suscripciones
  Public DtLocal As DataTable, pDesde As String, pHasta As String, pUnidadId As Integer = 0, pAlmacenId As Integer = 0
  Public dtDM As DataTable, dtIglesia As DataTable

  Private Sub LoadNodes()
    Dim index As Integer = 0
    Dim watch As Stopwatch = Stopwatch.StartNew()

    'Dim FilterP As String = "padre = 0 "
    'Dim dvP As DataView, dtRowP As DataRowView
    'If Not GestionTablas.dtMenu Is Nothing Then
    '    dvP = New DataView(GestionTablas.dtMenu, FilterP, "", DataViewRowState.CurrentRows)

    'Else
    '    Me.rTreePanel.Nodes.Clear()
    '    Exit Sub
    'End If

    Using Me.rTreePanel.DeferRefresh()
      Me.rTreePanel.Nodes.Clear()
      'For Each dtRowP In dvP
      index += 1

      Dim node As New RadTreeNode("Opciones", My.Resources.printer, True)
      For index = 1 To 5
        Dim child As New RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)
        If index = 1 Then
          child.Value = "CDM"
          child.Text = "Coodinadores De Distritos Misioneros"
          'child.Image = My.Resources.page_add
        ElseIf index = 2 Then
          child.Value = "CIGLESIAS"
          child.Text = "Coordinadores De Iglesias"
          'child.Image = My.Resources.page_add
        ElseIf index = 3 Then
          child.Value = "PPDM"
          child.Text = "Pedidos Distritos Misioneros"
        ElseIf index = 4 Then
          child.Value = "PPIGLESIAS"
          child.Text = "Pedidos De Iglesias"
          'child.Image = My.Resources.page_add
        ElseIf index = 5 Then
          child.Value = "RPTPEDIDOS"
          child.Text = "Pedidos"
        End If

        node.Nodes.Add(child)
      Next
      Me.rTreePanel.Nodes.Add(node)


      ' Next
    End Using
    watch.[Stop]()
    'Me.rTreeMenu.ExpandAll()

    'Me.radProgressBar1.Value1 = 50000
    'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
  End Sub

  Private Sub llenar_combos()
    Try


      Dim lMeses As New ClsCrearMeses

      With cboMes
        .DataSource = Nothing
        .DataSource = lMeses.GetList(False, False)
        .Refresh()
        .ValueMember = "codigo"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

      With cboAnio
        .DataSource = Nothing
        .DataSource = lMeses.GetList_anios()
        .Refresh()
        .ValueMember = "nombre"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

      With cboPeriodo
        .DataSource = Nothing
        .DataSource = periodoManager.GetList(0, 0, "")
        .DataBind()
        .ValueMember = "periodoid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 10
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If

      End With

      With cboTipoPedido
        .DataSource = Nothing
        .DataSource = pedidoManager.GetList_Tipo("")
        .DataBind()
        .ValueMember = "tipopedidoid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 10
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With


    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub cboPeriodo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboPeriodo.InitializeLayout
    With cboPeriodo.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboPeriodo.Width
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
    End With
  End Sub

  Private Sub cboPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles cboPeriodo.ValueChanged
    If Not bwDM.IsBusy Then
      cboDM.Text = [String].Empty
      picAjaxI.Visible = True
      bwDM.RunWorkerAsync()
    End If
  End Sub

  Private Sub Habilitar(ByVal vValor As Boolean)
    chkMision.Visible = vValor
  End Sub

  Private Sub FrmPanel_Suscripciones_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call LoadNodes()
    Call llenar_combos()

  End Sub

  Private Sub bwDM_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDM.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vPeriodo As Long = 0, vxOk As Boolean = False
    Dim st As New DataTable
    dtDM = New DataTable
    dtIglesia = New DataTable

    Try

      If Not cboPeriodo Is Nothing Then
        If Not cboPeriodo.Text = "" Then
          vPeriodo = cboPeriodo.Value
        End If
      End If
      pUnidadId = GestionSeguridadManager.gUnidadId
      vxOk = cursoresManager.Datos_Ventana_Suscripcion(vPeriodo, pUnidadId, dtDM, dtIglesia)

      e.Result = vxOk

    Catch ex As Exception
      st = Nothing
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwDM_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDM.RunWorkerCompleted
    'If sender = bwPrecarga Then
    cboDM.DataSource = Nothing
    cboIglesia.DataSource = Nothing

    If Not dtDM Is Nothing Then

      With Me.cboDM
        .DataSource = dtDM
        '.DataBind()
        .ValueMember = "grupoid"
        .DisplayMember = "grupo"
        .MinDropDownItems = 2
        .MaxDropDownItems = 10
        'If .Rows.Count > 0 Then
        '    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        'End If

      End With
    End If

    picAjaxI.Visible = False

  End Sub

  Private Sub cboDM_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDM.ValueChanged
    lblUnion.Text = ""
    lblUnion.Tag = 0
    lblMision.Text = ""
    lblMision.Tag = 0
    If Not cboDM.DataSource Is Nothing And Not cboDM.ActiveRow Is Nothing Then
      If Not cboDM.Text = "" Then
        If cboDM.ActiveRow.Activated Then
          lblUnion.Text = cboDM.ActiveRow.Cells("nom_union").Value
          lblUnion.Tag = cboDM.ActiveRow.Cells("unionid").Value
          lblMision.Text = cboDM.ActiveRow.Cells("mision").Value
          lblMision.Tag = cboDM.ActiveRow.Cells("misionid").Value
        End If

      End If

      cboIglesia.DataSource = Nothing
      Call ObtenerIglesias(cboDM.Value)
    Else

      cboIglesia.DataSource = Nothing
    End If
  End Sub

  Public Sub ObtenerIglesias(ByVal vDMid As Long)
    Dim Filter As String = "grupoid =" & vDMid
    Dim dv As DataView
    If Not dtIglesia Is Nothing Then
      dv = New DataView(dtIglesia, Filter, "", DataViewRowState.CurrentRows)
      If dv.Count > 0 Then 'Sino hay datos

        With cboIglesia
          .DataSource = Nothing
          .DataSource = dv
          .DataBind()
          .ValueMember = "personaid"
          .DisplayMember = "raz_soc"
          .MinDropDownItems = 2
          .MaxDropDownItems = 10
          'If .Rows.Count > 0 Then
          '    'If pCodigo_Det = 0 Then
          '    '    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          '    'End If

          'End If
        End With
      End If
    Else

    End If

  End Sub

  Private Sub cboIglesia_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboIglesia.InitializeLayout
    With cboIglesia.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboIglesia.Width
      .Columns(1).Header.Caption = "Cliente"
      .Columns(2).Hidden = True
    End With
  End Sub

  Private Sub cboDM_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboDM.InitializeLayout
    cboDM.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboDM.DisplayLayout.Bands(0).Columns(1).Width = cboDM.Width
    cboDM.DisplayLayout.Bands(0).Columns(2).Hidden = True
    cboDM.DisplayLayout.Bands(0).Columns(3).Hidden = True
    cboDM.DisplayLayout.Bands(0).Columns(4).Hidden = True
    cboDM.DisplayLayout.Bands(0).Columns(5).Hidden = True
  End Sub

  Private Sub RptCoordinadorDM()
    If cboPeriodo.Text = "" Then
      Exit Sub
    End If
    If cboDM.Text = "" Then
      Exit Sub
    End If

    DtLocal = reportes_suscripcionManager.Coordinadores_Periodo_Grupo(cboPeriodo.Value, lblUnion.Tag, lblMision.Tag, "")

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_Suscrip_Cristal
        rFrm.Coordinador_Periodo_Grupo(DtLocal, lblUnion.Text, lblMision.Text, "Coordinadores, Responsables de Distritos Misioneros", "Periodo: " & cboPeriodo.Text)

        Call LibreriasFormularios.Ver_Form(rFrm, "Distrito Misionero")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub RptPedidosDM()


    If cboPeriodo.Text = "" Then
      Exit Sub
    End If
    If cboDM.Text = "" Then
      Exit Sub
    End If

    DtLocal = reportes_suscripcionManager.Pedidos_Periodo_Grupo(cboPeriodo.Value, lblUnion.Tag, lblMision.Tag, "")

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_Suscrip_Cristal
        rFrm.Coordinador_Periodo_Grupo(DtLocal, lblUnion.Text, lblMision.Text, "Pedidos por Distritos Misioneros", "Periodo: " & cboPeriodo.Text)
        'rFrm.Coordinador_Periodo_Grupo = DtLocal
        'rFrm.pEmpresa = lblUnion.Text
        '        rFrm.pLocal = lblMision.Text
        '        rFrm.pTitulo = "Pedidos por Distritos Misioneros"
        '        rFrm.pCondicion = "Periodo: " & cboPeriodo.Text
        '        rFrm.pRpt = "PPDM"
        Call LibreriasFormularios.Ver_Form(rFrm, "Distrito Misionero")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub RptCoordinadorIglesia()
    Dim vDM As Long = 0

    If cboPeriodo.Text = "" Then
      Exit Sub
    End If
    If cboDM.Text = "" Then
      Exit Sub
    End If
    If chkAllDM.Checked = False Then
      vDM = cboDM.Value
    End If

    DtLocal = reportes_suscripcionManager.Coordinadores_Periodo_Iglesia(cboPeriodo.Value, lblUnion.Tag, lblMision.Tag, vDM, "")

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_Suscrip_Cristal
        rFrm.Pedidos_Periodo_Grupo_Iglesia(DtLocal, lblUnion.Text, lblMision.Text, "Coordinadores, Responsables de Iglesias", "Periodo: " & cboPeriodo.Text)
        'rFrm.pdtData = DtLocal
        'rFrm.pEmpresa = lblUnion.Text
        '        rFrm.pLocal = lblMision.Text
        '        rFrm.pTitulo = "Coordinadores, Responsables de Iglesias"
        '        rFrm.pCondicion = "Periodo: " & cboPeriodo.Text
        '        rFrm.pRpt = "CIGLESIAS"
        Call LibreriasFormularios.Ver_Form(rFrm, "Distrito - Iglesia")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub RptPedidosPeriodoIglesia()
    Dim vDM As Long = 0

    If cboPeriodo.Text = "" Then
      Exit Sub
    End If
    If cboDM.Text = "" Then
      Exit Sub
    End If
    If chkAllDM.Checked = False Then
      vDM = cboDM.Value
    End If

    DtLocal = reportes_suscripcionManager.Pedidos_Periodo_Iglesia(cboPeriodo.Value, lblUnion.Tag, lblMision.Tag, vDM, "")

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_Suscrip_Cristal
        rFrm.Pedidos_Periodo_Grupo_Iglesia(DtLocal, lblUnion.Text, lblMision.Text, "Pedidos por Iglesias", "Periodo: " & cboPeriodo.Text)
        'rFrm.pdtData = DtLocal
        '        rFrm.pEmpresa = lblUnion.Text
        '        rFrm.pLocal = lblMision.Text
        '        rFrm.pTitulo = "Pedidos por Iglesias"
        '        rFrm.pCondicion = "Periodo: " & cboPeriodo.Text
        '        rFrm.pRpt = "PPIGLESIAS"
        Call LibreriasFormularios.Ver_Form(rFrm, "Distrito - Iglesia")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub RptPedidosPeriodo()
    Dim vDM As Long = 0, vNombDM As String = "", vMisionid As Long = 0
    Dim vTipo As Integer = 0
    If cboPeriodo.Text = "" Then
      Exit Sub
    End If
    If cboDM.Text = "" Then
      Exit Sub
    End If
    If chkMision.Checked = False Then
      vMisionid = lblMision.Tag
      vNombDM = lblMision.Text
    End If
    If cboTipoPedido.Text = "" Then
      Exit Sub
    Else
      vTipo = cboTipoPedido.Value
    End If
    If chkAllDM.Checked = False Then
      vDM = cboDM.Value
      vNombDM = vNombDM & "-" & cboDM.Text
    End If

    If vNombDM = "" Then
      vNombDM = "CONSOLIDADO"
    End If
    DtLocal = reportes_suscripcionManager.Pedidos_Agenda_Detalle(cboPeriodo.Value, 0, vTipo, vDM, vMisionid)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim frm As New FrmVisor_Suscrip_Cristal
        frm.RptMaterial_Pedido(DtLocal, GestionSeguridadManager.gEmpresa, vNombDM, "Detalle Pedidos " & cboTipoPedido.Text, "Periodo: " & cboPeriodo.Text)
        Call LibreriasFormularios.Ver_Form(frm, "Detalle Pedidos ")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
    ' Dim node As New RadTreeNode
    Dim child As New RadTreeNode
    child = rTreePanel.SelectedNode
    If child.Value = "CDM" Then
      Call RptCoordinadorDM()
    ElseIf child.Value = "PPDM" Then
      Call RptPedidosDM()
    ElseIf child.Value = "CIGLESIAS" Then
      Call RptCoordinadorIglesia()
    ElseIf child.Value = "PPIGLESIAS" Then
      Call RptPedidosPeriodoIglesia()
    ElseIf child.Value = "RPTPEDIDOS" Then
      Call RptPedidosPeriodo()
    Else

    End If
  End Sub

  Private Sub rTreePanel_SelectedNodeChanged(sender As Object, e As RadTreeViewEventArgs) Handles rTreePanel.SelectedNodeChanged
    Call Habilitar(False)
    cboTipoPedido.Visible = False
    Select Case e.Node.Value
      Case "RPTPEDIDOS"
        chkMision.Visible = True
        cboTipoPedido.Visible = True
    End Select
  End Sub
End Class