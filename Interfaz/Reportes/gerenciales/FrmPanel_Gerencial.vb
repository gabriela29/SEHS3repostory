Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Telerik.WinControls.UI


Public Class FrmPanel_Gerencial
  Public DtLocal As DataTable, pDesde As String, pHasta As String, pUnidadId As Integer = 0, pAlmacenId As Integer = 0
  Public pDtFamilia As DataTable, pFicha As String, pMes As Integer = 0, pAnio As Integer = 0

  Private Sub LoadNodes()
    Dim index As Integer = 0, g As Integer = 0, vNodo As String = ""
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
      Dim node As RadTreeNode ' RadTreeNode(vNodo, My.Resources.printer, True)
      For g = 1 To 4
        If g = 1 Then
          vNodo = "Venta por Clientes"
          node = New RadTreeNode(vNodo, My.Resources.printer, True)
          Me.rTreePanel.Nodes.Add(node)
        ElseIf g = 2 Then
          vNodo = "Cuentas por Cobrar"
          node = New RadTreeNode(vNodo, My.Resources.printer, True)
          Me.rTreePanel.Nodes.Add(node)
        ElseIf g = 3 Then
          vNodo = "Productos"
          node = New RadTreeNode(vNodo, My.Resources.printer, True)
          Me.rTreePanel.Nodes.Add(node)
        ElseIf g = 4 Then
          vNodo = "Colportaje"
          node = New RadTreeNode(vNodo, My.Resources.printer, True)
          Me.rTreePanel.Nodes.Add(node)
        End If

        Dim child As RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)

        For index = 1 To 5
          If g = 1 Then
            If index = 1 Then
              child = New RadTreeNode
              child.Value = "Ventas"
              child.Text = "Venta por Clientes"
              node.Nodes.Add(child)
            ElseIf index = 2 Then
              child = New RadTreeNode
              child.Value = "Amortizaciones"
              child.Text = "Amortizaciones"
              'child.Image = My.Resources.page_add
              node.Nodes.Add(child)
            ElseIf index = 3 Then
              child = New RadTreeNode
              child.Value = "EstadoResultados"
              child.Text = "Estado de Resultados"
              'child.Image = My.Resources.page_add
              node.Nodes.Add(child)
            End If
          ElseIf g = 2 Then

            If index = 1 Then
              child = New RadTreeNode
              child.Value = "Ndias"
              child.Text = "Agrupado por Días Vencidos"
              node.Nodes.Add(child)
            ElseIf index = 2 Then
              child = New RadTreeNode
              child.Value = "resumengp"
              child.Text = "Resumen por Asistente"
              node.Nodes.Add(child)
            ElseIf index = 3 Then
              child = New RadTreeNode
              child.Value = "resumenppc"
              child.Text = "Saldo Porvisión Incobrables"
              node.Nodes.Add(child)
            ElseIf index = 4 Then
              child = New RadTreeNode
              child.Value = "listaDeudaProvCast"
              child.Text = "Por Cobrar Porvisión & Castigo"
              node.Nodes.Add(child)
            End If
          ElseIf g = 3 Then
            If index = 1 Then
              child = New RadTreeNode
              child.Value = "NdiasProd"
              child.Text = "Producto Nro Días Última Fecha Compra"
              node.Nodes.Add(child)
            End If
          ElseIf g = 4 Then
            If index = 1 Then
              child = New RadTreeNode
              child.Value = "listaPagosColportaje"
              child.Text = "Pagos por venta de colportaje"
              node.Nodes.Add(child)
            End If
          End If

        Next
      Next
      'Me.rTreePanel.Nodes.Add(node)


      ' Next
    End Using
    watch.[Stop]()
    'Me.rTreeMenu.ExpandAll()

    'Me.radProgressBar1.Value1 = 50000
    'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
  End Sub

  Private Sub rTreeMenu_NodeMouseClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles rTreePanel.NodeMouseClick
    Call Habilitar(False)
    If e.Node.Value = "Ventas" Then
      BtnMostrar.Enabled = True
      CboFecha1.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
      cboAuxiliar.Enabled = True
      Call Habilitar_cboAuxiliar("Ventas")
    ElseIf e.Node.Value = "Amortizaciones" Then
      BtnMostrar.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
      cboAuxiliar.Enabled = True
      Call Habilitar_cboAuxiliar("Amortizaciones")
    ElseIf e.Node.Value = "Ndias" Then
      BtnMostrar.Enabled = True
      cboAuxiliar.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
      Call Habilitar_cboAuxiliar("Ndias")
    ElseIf e.Node.Value = "resumengp" Then
      BtnMostrar.Enabled = True
      CboFecha1.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
    ElseIf e.Node.Value = "EstadoResultados" Then
      BtnMostrar.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
      cboMes.Enabled = True
      cboAnio.Enabled = True
    ElseIf e.Node.Value = "resumenppc" Then
      BtnMostrar.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
    ElseIf e.Node.Value = "listaDeudaProvCast" Then
      BtnMostrar.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
    ElseIf e.Node.Value = "NdiasProd" Then
      BtnMostrar.Enabled = True
      cboAnio.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
      lblProducto.Enabled = True
      btnLista_Producto.Enabled = True
      CboFamilia.Enabled = True
    ElseIf e.Node.Value = "listaPagosColportaje" Then
      BtnMostrar.Enabled = True
      CboFecha1.Enabled = True
      CboFecha2.Enabled = True
      cboUnidad.Enabled = True
      cboAlmacen.Enabled = True
    End If

  End Sub

  Private Sub Habilitar(ByVal Valor As Boolean)
    cboUnidad_Negocio.Enabled = True 'Valor
    cboAlmacen.Enabled = True 'Valor
    UltraLabel5.Visible = False 'Importe

    UltraLabel3.Visible = False 'Nro Cuenta
    UltraLabel2.Visible = False 'RUC
    cboAuxiliar1.Enabled = Valor
    cboAuxiliar.Enabled = Valor
    CboFamilia.Enabled = Valor
    cboMes.Enabled = Valor
    cboAnio.Enabled = Valor
    CboFecha1.Enabled = Valor
    CboFecha2.Enabled = Valor
    LblPersona.Enabled = Valor
    btnBuscaPer.Enabled = Valor
    lblProducto.Enabled = Valor
    btnLista_Producto.Enabled = Valor
    txtImporte.Enabled = Valor
    txtCtaMaestra.Enabled = Valor
    txtRuc.Enabled = Valor
    btnBusca_Cta.Enabled = Valor
    chkAux1.Checked = False
    chkAux1.Enabled = Valor
    chkAux1.Text = "..."
    ChkAux2.Checked = False
    ChkAux2.Enabled = Valor
    ChkAux2.Text = "..."
    chkAux3.Checked = False
    chkAux3.Enabled = Valor
    chkAux3.Text = "..."
    chkAux4.Checked = False
    chkAux4.Enabled = Valor
    chkAux4.Text = "..."
    BtnMostrar.Enabled = Valor
    LblPersona.Text = ""
    LblPersona.Tag = 0
    lblProducto.Text = ""
    lblProducto.Tag = 0
  End Sub

  Private Sub llenar_combos()
    Try

      pDtFamilia = subcategoriaManager.GetList(0, "")

      Dim lMeses As New ClsCrearMeses

      With cboMes
        .DataSource = Nothing
        .DataSource = lMeses.GetList(False, False)
        .Refresh()
        .ValueMember = "codigo"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With
      With cboAnio
        .DataSource = Nothing
        .DataSource = lMeses.GetList_anios()
        .Refresh()
        .ValueMember = "nombre"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          .Text = Now.Date.Year
        End If
      End With

      With CboFamilia
        .DataSource = Nothing
        .DataSource = pDtFamilia
        .DataBind()
        .ValueMember = "subcategoriaid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
      End With

      With cboSubCategoria
        .DataSource = Nothing
        .DataSource = pDtFamilia
        .DataBind()
        .ValueMember = "subcategoriaid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 6
      End With

      With cboSubCategoriaVta
        .DataSource = Nothing
        .DataSource = pDtFamilia
        .DataBind()
        .ValueMember = "subcategoriaid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 6
      End With

      With Me.cboUnidad_Negocio
        .DataSource = GestionTablas.dtUnidad
        '.DataBind()
        .ValueMember = "unidadnegocioid"
        .DisplayMember = "unidad"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With

      With Me.cboUnidadVta
        .DataSource = GestionTablas.dtUnidad
        '.DataBind()
        .ValueMember = "unidadnegocioid"
        .DisplayMember = "unidad"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With
      ''Referencia Venta
      Dim x As Integer = 6, dtL As New DataTable
      Dim opcionesv(x), opciones(x) As String
      opcionesv(0) = ""
      opcionesv(1) = "BCC"
      opcionesv(2) = "BCD"
      opcionesv(3) = "DMID"
      opcionesv(4) = "V.I.P."
      opcionesv(5) = "L.V.I.P."

      opciones(0) = "Todos"
      opciones(1) = "BCC"
      opciones(2) = "BDC"
      opciones(3) = "DMID"
      opciones(4) = "VIP"
      opciones(5) = "L.VIP"

      dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

      With cboReferencia
        .DataSource = Nothing
        .DataSource = dtL
        .Refresh()
        .ValueMember = "opcionesv"
        .DisplayMember = "opciones"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With


      ''Grid
      With cboMeses
        .DataSource = Nothing
        .DataSource = lMeses.GetList(False, False)
        .Refresh()
        .ValueMember = "codigo"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With
      With cboAnios
        .DataSource = Nothing
        .DataSource = lMeses.GetList_anios()
        .Refresh()
        .ValueMember = "nombre"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          .Text = Now.Date.Year
        End If
      End With
      With Me.cboUnidad
        .DataSource = GestionTablas.dtUnidad
        '.DataBind()
        .ValueMember = "unidadnegocioid"
        .DisplayMember = "unidad"
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

  Private Sub Habilitar_cboAuxiliar(ByVal vNode As String)
    Dim dtL As DataTable
    Dim x As Integer = 6
    Select Case vNode
      Case "Amortizaciones"
        With cboAuxiliar
          .DataSource = Nothing
          .DataSource = rolManager.GetList()
          .DataBind()
        End With
      Case "ventas"
        With cboAuxiliar
          .DataSource = Nothing
          .DataSource = rolManager.GetList()
          .DataBind()
        End With
      Case "Ndias"

        Dim opcionesv(x), opciones(x) As String
        opcionesv(0) = 0
        opcionesv(1) = 1
        opcionesv(2) = 2
        opcionesv(3) = 3
        opcionesv(4) = 4
        opcionesv(5) = 5
        opcionesv(6) = 6

        opciones(0) = "Todos"
        opciones(1) = "Permanentes"
        opciones(2) = "Estudiantes"
        opciones(3) = "Nacionales"
        opciones(4) = "Asistente"
        opciones(5) = "Individual"
        opciones(6) = "Iglesia"

        dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

        With cboAuxiliar
          .DataSource = Nothing
          .DataSource = dtL
          .Refresh()
          .ValueMember = "opcionesv"
          .DisplayMember = "opciones"
          If .Rows.Count > 0 Then
            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          End If
        End With


    End Select

  End Sub

  Private Sub Permisos_Almacen()
    If Not cboUnidad_Negocio.Text = "" And chkAllAlmacenes.Checked = False Then
      Dim FilterP As String = "unidadnegocioid = " & cboUnidad_Negocio.Value
      Dim dvP As DataView
      If Not GestionTablas.dtAlmacen Is Nothing Then
        dvP = New DataView(GestionTablas.dtAlmacen, FilterP, "", DataViewRowState.CurrentRows)
        With Me.cboAlmacen
          .DataSource = dvP
          '.DataBind()
          .ValueMember = "almacenid"
          .DisplayMember = "nombre"
          .MinDropDownItems = 2
          .MaxDropDownItems = 4
          If .Rows.Count > 0 Then
            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          End If

        End With
      Else
        dvP = Nothing
      End If
    Else
      cboAlmacen.DataSource = Nothing
    End If

  End Sub

  Private Sub FrmPanel_Gerencial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Call llenar_combos()
    Call LoadNodes()
    Me.CboFecha1.Value = Date.Now
    Me.CboFecha2.Value = Date.Now
    Me.cboDesdeVta.Value = Date.Now
    Me.cboHastaVta.Value = Date.Now

    Call LibreriasFormularios.formatear_grid(dgvListado)
    Call LibreriasFormularios.formatear_grid(dgvVentas)
    Call Habilitar(False)

  End Sub

  Private Sub Ventas()
    Dim myArrRol As String = ""

    If Not cboAuxiliar.Text = "" Then
      myArrRol = Trim(Str(cboAuxiliar.Value)) & ","
      myArrRol = Mid(myArrRol, 1, Len(myArrRol) - 1)
      myArrRol = "array[" & myArrRol & "]"
    Else
      myArrRol = "null"
    End If

    pDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    DtLocal = reportes_gerencialesManager.Ventas_cliente_Audi(0, pUnidadId, pAlmacenId, 0, pDesde, pHasta, "", myArrRol)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorVentas_Clientes
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = cboUnidad_Negocio.Text & IIf(cboAlmacen.Text = "", "", " - ") & cboAlmacen.Text
        rFrm.pTitulo = "Ventas por Cliente"
        rFrm.pCondicion = "Desde: " & CboFecha1.Value & " Hasta: " & CboFecha2.Value
        Call LibreriasFormularios.Ver_Form(rFrm, "Venta Cliente")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
    ' Dim node As New RadTreeNode
    Dim child As New RadTreeNode
    child = rTreePanel.SelectedNode
    If child.Value = "Ventas" Then
      Call Ventas()
    ElseIf child.Value = "Amortizaciones" Then
      Call Amortizacones()
    ElseIf child.Value = "Ndias" Then
      Call PorCobrarNdias()
    ElseIf child.Value = "resumengp" Then
      Call ResumenGrupos()
    ElseIf child.Value = "EstadoResultados" Then
      Call Estado_Resultado()
    ElseIf child.Value = "resumenppc" Then
      Call SaldoProvisiones()
    ElseIf child.Value = "listaDeudaProvCast" Then
      Call PorCobrar_Provisiones_Cast()
    ElseIf child.Value = "NdiasProd" Then
      Call PorCobrarNdiasProd()
    ElseIf child.Value = "listaPagosColportaje" Then
      Call ListaPagosColportaje()
    End If
  End Sub

  Private Sub Amortizacones()
    Dim myArrRol As String = ""

    If Not cboAuxiliar.Text = "" Then
      myArrRol = Trim(Str(cboAuxiliar.Value)) & ","
      myArrRol = Mid(myArrRol, 1, Len(myArrRol) - 1)
      myArrRol = "array[" & myArrRol & "]"
    Else
      myArrRol = "null"
    End If

    pDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    DtLocal = reportes_gerencialesManager.Amortizaciones_cliente_Audi(0, pUnidadId, pAlmacenId, 0, pDesde, pHasta, "", myArrRol)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorVentas_Clientes
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = cboUnidad_Negocio.Text & IIf(cboAlmacen.Text = "", "", " - ") & cboAlmacen.Text
        rFrm.pTitulo = "Amortizaciones por Cliente - Sin Notas de Crédito"
        rFrm.pCondicion = "Desde: " & CboFecha1.Value & " Hasta: " & CboFecha2.Value
        Call LibreriasFormularios.Ver_Form(rFrm, "Amortizaciones Cliente")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub PorCobrarNdias()
    Dim xCondi As String = ""
    pUnidadId = 0
    pAlmacenId = 0
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value
    xCondi = xCondi & " - " & cboAuxiliar.Text

    DtLocal = por_cobrarManager.RptPorCobrar_Ndias(False, "", pHasta, pUnidadId, pAlmacenId, 0, cboAuxiliar.Text, 0)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim frm As New FrmVisor_PorCobrar
        frm.RptPorCobrar_Ndias(DtLocal, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi)

        Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar N Días")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub ResumenGrupos()
    Dim xCondi As String = "", pUnidad As String = "CONSOLIDADO"
    pUnidadId = 0
    pAlmacenId = 0
    pDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
      pUnidad = cboUnidad.Text
    Else

    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    xCondi = xCondi & "Desde: " & CboFecha1.Value & "  Hasta: " & Me.CboFecha2.Value
    xCondi = xCondi & " - " & cboAuxiliar.Text

    DtLocal = por_cobrarManager.RptPorCobrar_Res_GP(False, pDesde, pHasta, 0, pUnidadId, pAlmacenId, "")


    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim frm As New FrmVisor_PorCobrar
        frm.RptPorCobrar_Res_GP(DtLocal, GestionSeguridadManager.gEmpresa, pUnidad, cboAlmacen.Text, xCondi)

        Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar Resumen GP")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub Estado_Resultado()
    Dim vLocal As String = ""
    pUnidadId = 0
    pAlmacenId = 0
    pMes = 0
    pAnio = 0

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If
    If cboMes.Text = "" Then
      MessageBox.Show("Debe seleccionar un mes", "Verificar")
      Exit Sub
    Else
      If cboMes.Value = 0 Then
        MessageBox.Show("Debe seleccionar un mes", "Verificar")
        Exit Sub
      Else
        pMes = cboMes.Value
      End If
    End If
    If cboAnio.Text = "" Then
      MessageBox.Show("Debe seleccionar un Año", "Verificar")
      Exit Sub
    Else
      pAnio = cboAnio.Text
    End If
    vLocal = cboUnidad_Negocio.Text & IIf(cboAlmacen.Text = "", "", " - ") & cboAlmacen.Text
    If vLocal = "" Then
      vLocal = "CONSOLIDADO"
    End If
    DtLocal = reportes_gerencialesManager.Estado_Resultados(0, pUnidadId, pAlmacenId, pMes, pAnio)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorGerencialCrystal
        rFrm.pRpt = "ER"
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = vLocal
        rFrm.pTitulo = "Estado de Resultados"
        rFrm.pCondicion = "Mes: " & cboMes.Text & " Anio: " & cboAnio.Text
        Call LibreriasFormularios.Ver_Form(rFrm, "Estado Resultados")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub SaldoProvisiones()

    pDesde = "" 'LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    pUnidadId = 0
    pAlmacenId = 0
    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    DtLocal = reportes_gerencialesManager.Saldo_Provisiones(0, pUnidadId, pAlmacenId, 0, pDesde, pHasta, 0)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_PorCobrar
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = cboUnidad_Negocio.Text & IIf(cboAlmacen.Text = "", "", " - ") & cboAlmacen.Text
        rFrm.pTitulo = "Saldo de Provisiones"
        rFrm.pCondicion = "Hasta: " & CboFecha2.Value '"Desde: " & CboFecha1.Value &
        rFrm.pRpt = "PSP"
        Call LibreriasFormularios.Ver_Form(rFrm, "Saldo CxC")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub PorCobrar_Provisiones_Cast()

    pDesde = "" 'LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    pUnidadId = 0
    pAlmacenId = 0
    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
    End If

    DtLocal = reportes_gerencialesManager.PorCobrar_Provisiones_Cast(0, pUnidadId, pAlmacenId, 0, pDesde, pHasta, 0)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisor_PorCobrar
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = cboUnidad_Negocio.Text & IIf(cboAlmacen.Text = "", "", " - ") & cboAlmacen.Text
        rFrm.pTitulo = "Deuda, Provisiones & Castigo"
        rFrm.pCondicion = "Hasta: " & CboFecha2.Value '"Desde: " & CboFecha1.Value &
        rFrm.pRpt = "DPC"
        Call LibreriasFormularios.Ver_Form(rFrm, "Porcobrar Prov")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub PorCobrarNdiasProd()
    Dim xCondi As String = "", vFamiliaid As Integer = 0, vProductoid As Long = 0, xLocal As String = "CONSOLIDADO"
    pUnidadId = 0
    pAlmacenId = 0


    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
      xLocal = cboUnidad.Text
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
      xLocal = xLocal & " - " & cboAlmacen.Text
    End If


    pAnio = cboAnio.Text
    xCondi = "Año: " & cboAnio.Text

    If lblProducto.Tag > 0 Then
      vProductoid = lblProducto.Tag
      xCondi = xCondi & " - Producto: " & lblProducto.Tag
    End If
    If Not CboFamilia.Text = "" Then
      vFamiliaid = CboFamilia.Value
      xCondi = xCondi & " - Familia: " & CboFamilia.Value
    End If

    DtLocal = reportes_gerencialesManager.Producto_NDias_UltimaFech_Comp(0, pUnidadId, pAlmacenId, pAnio, vFamiliaid, vProductoid, True)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorGerencialCrystal
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = xLocal
        rFrm.pTitulo = "Listado de Productos con N Días desde su última fecha de compra"
        rFrm.pCondicion = xCondi
        rFrm.pRpt = "NDIASPRODUCTO"

        Call LibreriasFormularios.Ver_Form(rFrm, "N Días Producto")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub ListaPagosColportaje()
    Dim xCondi As String = "", xLocal As String = "CONSOLIDADO"
    Dim vAsistenteid As Long = 0, vColportorId As Long = 0

    pUnidadId = 0
    pAlmacenId = 0

    If Not cboUnidad_Negocio.Text = "" Then
      pUnidadId = cboUnidad_Negocio.Value
      xLocal = cboUnidad.Text
    End If
    If Not cboAlmacen.Text = "" Then
      pAlmacenId = cboAlmacen.Value
      xLocal = xLocal & " - " & cboAlmacen.Text
    End If

    pDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
    pHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    xCondi = "Desde: " & pDesde & " Hasta: " & pHasta


    DtLocal = reportes_gerencialesManager.Listado_Pagos_Colportaje(0, pUnidadId, pAlmacenId, vAsistenteid, vColportorId, pDesde, pHasta, "")

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorGerencialCrystal
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = xLocal
        rFrm.pTitulo = "Listado de Pagos de Colportaje"
        rFrm.pCondicion = xCondi
        rFrm.pRpt = "listaPagosColportaje"

        Call LibreriasFormularios.Ver_Form(rFrm, "Pago Colportaje")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub cboUnidad_Negocio_ValueChanged(sender As Object, e As EventArgs) Handles cboUnidad_Negocio.ValueChanged
    Call Permisos_Almacen()
  End Sub

  Private Sub chkAllUnidades_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllUnidades.CheckedChanged
    If chkAllUnidades.Checked Then
      cboUnidad_Negocio.Enabled = False
      cboUnidad_Negocio.Text = ""
      cboAlmacen.Text = ""
      chkAllAlmacenes.Checked = True

    Else
      cboUnidad_Negocio.Enabled = True
    End If
  End Sub

  Private Sub chkAllAlmacenes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllAlmacenes.CheckedChanged
    If chkAllAlmacenes.Checked Then
      cboAlmacen.Text = ""
      cboAlmacen.Enabled = False
    Else
      cboAlmacen.Enabled = True
    End If
  End Sub

  Private Sub tsDSalir_Click(sender As Object, e As EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  ''=========================================FICHA GRID DINÁMICO==================================================================================
  Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
    CheckForIllegalCrossThreadCalls = False

    Try
      Dim dtStock As New DataTable
      Dim zUnidad As Integer = 0, xOk As Boolean, zStock As Single = 0, vSubCategoria As Integer = 0, vGrupo As String = "ALMACEN"
      Dim vDesde As String = "", vHasta As String = "", vSql As String = ""





      If pFicha = "STOCK" Then
        If Not cboUnidad.Text = "" Then
          zUnidad = cboUnidad.Value
        End If
        If IsNumeric(txtImportes.Text) Then
          zStock = Long.Parse(txtImportes.Text)
        End If
        If Not cboSubCategoria.Text.Trim = "" Then
          vSubCategoria = cboSubCategoria.Value
        End If
        If cboMeses.Value = 0 Then
          MessageBox.Show("Debe seleccionar un mes", "AVISO")
          Exit Sub
        End If
        vGrupo = IIf(chkAgrupar.Checked, "UNIDAD", "ALMACEN")
        gpCriterios.Enabled = False

        If chkStockSoles.Checked Then
          vSql = "inventarios.pareporte_stock_valorado_consolidado"
        Else
          vSql = "inventarios.pareporte_stock_consolidado"
        End If

      ElseIf pFicha = "VENTA" Then
          If Not cboUnidadVta.Text = "" Then
          zUnidad = cboUnidadVta.Value
        End If
        If IsNumeric(txtImporteVta.Text) Then
          zStock = Single.Parse(txtImportes.Text)
        End If
        If Not cboSubCategoriaVta.Text.Trim = "" Then
          vSubCategoria = cboSubCategoriaVta.Value
        End If

        vDesde = LibreriasFormularios.Formato_Fecha(cboDesdeVta.Value)
        vHasta = LibreriasFormularios.Formato_Fecha(cboHastaVta.Value)
        vGrupo = IIf(chkAgruparVta.Checked, "UNIDAD", "ALMACEN")
        gpCriteriosVta.Enabled = False
        If chkSoles.Checked Then
          vSql = "inventarios.pareporte_ventas_consolidados"
        Else
          vSql = "inventarios.pareporte_ventas_consolidado"
        End If
      End If


      xOk = reportes_gerencialesManager.Stock_valorado(zUnidad, cboMeses.Value, cboAnios.Value, "", zStock,
                                                       vSubCategoria, dtStock, vGrupo, vDesde, vHasta, pFicha, vSql,
                                                       cboReferencia.Value, chkProducto.Checked, chkNeto.Checked, chkIGV.Checked)

      e.Result = dtStock

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwListado_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwListado.RunWorkerCompleted
    If pFicha = "STOCK" Then
      dgvListado.DataSource = CType(e.Result, DataTable)

      If dgvListado.Rows.Count() > 0 Then
        dgvListado.Rows(0).Selected = True
        dgvListado.Focus()
      End If
      Me.lbl.Text = dgvListado.Rows.Count & " Registros"
      picAjaxBig.Visible = False
      gpCriterios.Enabled = True

    ElseIf pFicha = "VENTA" Then
      dgvVentas.DataSource = CType(e.Result, DataTable)

      If dgvVentas.Rows.Count() > 0 Then
        dgvVentas.Rows(0).Selected = True
        dgvVentas.Focus()
      End If
      'Call LlenarRsKardexPROMEDIO(CType(e.Result, DataTable))
      Me.lblRegistrosVta.Text = dgvVentas.Rows.Count & " Registros"
      lblTotal.Text = "Total= " & CalcularTotales(CType(e.Result, DataTable))
      picVtas.Visible = False
      gpCriteriosVta.Enabled = True
    End If

  End Sub

  Public Function CalcularTotales(ByVal DtTotales As DataTable) As String
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vTotal As Single
    Try
      DtTot = DtTotales
      CalcularTotales = "0"
      For Each Drs In DtTot.Rows
        vTotal = vTotal + CSng(Drs("total").ToString)
      Next Drs

      CalcularTotales = FormatNumber(vTotal, 2, TriState.False, TriState.False)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "Test.xls")
  End Sub

  Private Sub Exportar_Vta_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvVentas, ugExcelExporter, "CantidadesVtas.xls")
  End Sub

  Private Sub tsExcel_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
    Call Exportar_Excel()
  End Sub

  Private Sub chkConsDinamico_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsDinamico.CheckedChanged
    If chkConsDinamico.Checked Then
      cboUnidad.Text = ""
    End If
  End Sub

  Private Sub dgvListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("productoid").Header.VisiblePosition = 0
      .Columns("productoid").Header.Caption = "ID"
      .Columns("productoid").Width = 20
      .Columns("producto").Width = 240
      .Columns("total").CellAppearance.TextHAlign = HAlign.Right
      .Columns("total").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("total").Width = 80
    End With
  End Sub

  Private Sub tsMovProd_Click(sender As Object, e As EventArgs) Handles tsMovProd.Click
    pAnio = cboAnios.Text
    pMes = cboMeses.Value

    pUnidadId = 0
    pAlmacenId = 0
    If Not cboUnidad.Text = "" Then
      pUnidadId = cboUnidad.Value
    End If

    DtLocal = reportes_gerencialesManager.Movimiento_Producto(0, pUnidadId, pAlmacenId, pAnio, pMes, 0)

    If Not DtLocal Is Nothing Then
      If DtLocal.Rows.Count > 0 Then
        Dim rFrm As New FrmVisorGerencialCrystal
        rFrm.pdtData = DtLocal
        rFrm.pEmpresa = GestionSeguridadManager.gEmpresa
        rFrm.pLocal = IIf(pUnidadId = 0, "CONSOLIDADO", cboUnidad.Text)
        rFrm.pTitulo = "Listado Movimiento Poructo Resumen"
        rFrm.pCondicion = "Año: " & cboAnios.Text  '"Desde: " & CboFecha1.Value &
        rFrm.pRpt = "PM"
        Call LibreriasFormularios.Ver_Form(rFrm, "Porcobrar Prov")
      Else
        MessageBox.Show("No hay datos que mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End If
  End Sub

  Private Sub btnLista_Producto_Click(sender As Object, e As EventArgs) Handles btnLista_Producto.Click
    Dim testDialog As New FrmConsulta_Productos

    If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Me.lblProducto.Tag = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
      Me.lblProducto.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
    Else
      lblProducto.Text = ""
      lblProducto.Tag = 0
    End If
    testDialog.Dispose()
  End Sub

  Private Sub tsdActualizarMS_Click(sender As Object, e As EventArgs) Handles tsdActualizarMS.Click
    If Not bwListado.IsBusy Then
      pFicha = "STOCK"
      picAjaxBig.Visible = True
      bwListado.RunWorkerAsync()
    End If
  End Sub


  Private Sub tsPDF_Click(sender As Object, e As EventArgs) Handles tsPDF.Click
    Me.UltraGridDocumentExporter1.Export(
Me.dgvListado,
"C:\Phoenix\pdf_Report.pdf", UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)

  End Sub

  Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles tsCerrarVtas.Click
    Me.Close()
  End Sub

  Private Sub tsActualizarVtas_Click(sender As Object, e As EventArgs) Handles tsActualizarVtas.Click
    If Not bwListado.IsBusy Then
      pFicha = "VENTA"
      picVtas.Visible = True
      bwListado.RunWorkerAsync()
    End If
  End Sub

  Private Sub dgvVentas_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dgvVentas.InitializeLayout
    With dgvVentas.DisplayLayout.Bands(0)
      .Columns("productoid").Header.VisiblePosition = 0
      .Columns("productoid").Header.Caption = "ID"
      .Columns("productoid").Width = 20
      .Columns("producto").Width = 240
      .Columns("total").CellAppearance.TextHAlign = HAlign.Right
      .Columns("total").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("total").Width = 80
    End With
  End Sub

  Private Sub chkConsVta_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsVta.CheckedChanged
    If chkConsVta.Checked Then
      cboUnidadVta.Text = ""
    End If
  End Sub

  Private Sub tsExcelVtas_Click(sender As Object, e As EventArgs) Handles tsExcelVtas.Click
    Call Exportar_Vta_Excel()
  End Sub

End Class