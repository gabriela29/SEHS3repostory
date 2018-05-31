Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinListBar
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports System.Reflection
Imports System
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Docking
Imports System.Deployment.Application

Public Class MDIMenu
  Private mLocation As String
  Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    Global.System.Windows.Forms.Application.Exit()
  End Sub

  Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    Me.LayoutMdi(MdiLayout.Cascade)
  End Sub

  Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    Me.LayoutMdi(MdiLayout.TileVertical)
  End Sub

  Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    Me.LayoutMdi(MdiLayout.TileHorizontal)
  End Sub

  Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    Me.LayoutMdi(MdiLayout.ArrangeIcons)
  End Sub

  Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Close all child forms of the parent.
    For Each ChildForm As Form In Me.MdiChildren
      ChildForm.Close()
    Next
  End Sub

  Private m_ChildFormNumber As Integer = 0

  Private Sub MDIMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    If Not GestionSeguridadManager.gUnidad = "" Then
      lblUnidad.Text = GestionSeguridadManager.gEntidad & " - " & GestionSeguridadManager.gUnidad
      lblServidor.Text = GestionSeguridadManager.Servidor
    End If

  End Sub

  Private ReadOnly Property FileMajorPart() As Int32
    Get
      Return System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileMajorPart
    End Get
  End Property
  Private ReadOnly Property FileMinorPart() As Int32
    Get
      Return System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileMinorPart
    End Get
  End Property
  Private ReadOnly Property FileBuildPart() As Int32
    Get
      Return System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileBuildPart
    End Get
  End Property
  Private ReadOnly Property FilePrivatePart() As Int32
    Get
      Return System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FilePrivatePart
    End Get
  End Property
  '
  Private ReadOnly Property FileVersion() As String
    Get
      Return System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion.ToString
    End Get
  End Property
  '
  Private ReadOnly Property EXEName() As String
    Get
      Return System.IO.Path.GetFileName(mLocation)
    End Get
  End Property

  Private Function mostrarInfo() As String
    mLocation = System.Reflection.Assembly.GetExecutingAssembly.Location

    Dim vVersion As String = ""
    vVersion = vVersion & EXEName
    vVersion = vVersion & " " & FileVersion

    vVersion = vVersion & " " & FileMajorPart
    vVersion = vVersion & " " & FileMinorPart
    vVersion = vVersion & " " & FileBuildPart
    vVersion = vVersion & " " & FilePrivatePart
    Return vVersion
  End Function

  Private Sub FrmMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'lblBuild.Text = mostrarInfo()
    '

    frmAccesoSistema.ShowDialog()
    lblServidor.Text = ""
    lblUsuario.Text = GestionSeguridadManager.sUsuario
    lblEquipo.Text = GestionSeguridadManager.NombrePC

    Me.IsMdiContainer = True
    Me.RadDock1.AutoDetectMdiChildren = True
    Me.RadDock1.ShowDocumentCloseButton = True


    Me.rTreeMenu.ItemHeight = 27
    Me.rTreeMenu.AllowDefaultContextMenu = True

    If Not GestionTablas.dtUnidad Is Nothing Then
      If GestionTablas.dtUnidad.Rows.Count > 0 Then

        GestionSeguridadManager.gUnidadId = GestionTablas.dtUnidad.Rows(0).Item("unidadnegocioid").ToString
        GestionSeguridadManager.gUnidad = GestionTablas.dtUnidad.Rows(0).Item("unidad").ToString
        GestionSeguridadManager.gEntidad = GestionTablas.dtUnidad.Rows(0).Item("entidad").ToString
        GestionSeguridadManager.gEmpresaId = GestionTablas.dtUnidad.Rows(0).Item("empresaid").ToString
        GestionSeguridadManager.gEmpresa = GestionTablas.dtUnidad.Rows(0).Item("empresa").ToString
        GestionSeguridadManager.gDirEmpresa = GestionTablas.dtUnidad.Rows(0).Item("direccion").ToString
        GestionSeguridadManager.gRUCEmp = GestionTablas.dtUnidad.Rows(0).Item("ruc").ToString
        GestionSeguridadManager.Servidor = GestionTablas.dtUnidad.Rows(0).Item("url").ToString
        Call Permisos_Almacen()
        Call LoadNodes()

      End If
    End If

    lblUnidad.Text = GestionSeguridadManager.gEntidad & " - " & GestionSeguridadManager.gUnidad
    lblServidor.Text = GestionSeguridadManager.Servidor
    lblMoneda.Text = Configuracion.pNom_Moneda
    lblIGV.Text = Configuracion.pIGV
  End Sub


  Private Sub UTBManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTBManager1.ToolClick
    Select Case e.Tool.Key
      Case "Control_Mes"    ' ButtonTool
        ' Place code here
        FrmMigracion.MdiParent = Me
        FrmMigracion.Show()
        FrmMigracion.BringToFront()

      Case "Catalogo_Producto"    ' ButtonTool
        ' Place code here
        'FrmCatalogo.MdiParent = Me
        'FrmCatalogo.Show()
        'FrmCatalogo.BringToFront()
        ToolWindow1.Show()

      Case "Categorias_SubCategorias"
        FrmCategorias_Sub.MdiParent = Me
        FrmCategorias_Sub.Show()
        FrmCategorias_Sub.BringToFront()

      Case "Marcas"
        FrmMarca.MdiParent = Me
        FrmMarca.Show()
        FrmMarca.BringToFront()

      Case "Grupos"
        FrmGrupo.MdiParent = Me
        FrmGrupo.Show()
        FrmGrupo.BringToFront()
      Case "Unidad_Medida"
        FrmUnidad_Medida.MdiParent = Me
        FrmUnidad_Medida.Show()
        FrmUnidad_Medida.BringToFront()

      Case "Documento"
        FrmSeriesDocumento.MdiParent = Me
        FrmSeriesDocumento.Show()
        FrmSeriesDocumento.BringToFront()
      Case "Persona"    ' ButtonTool
        ' Place code here
        FrmPersonaLis.MdiParent = Me
        FrmPersonaLis.Show()
      Case "Rol"
        FrmGestion_Acceso.MdiParent = Me
        FrmGestion_Acceso.Show()
        FrmGestion_Acceso.BringToFront()
      Case "Ingreso_Consignacion"    ' ButtonTool
                ' Place code here
      Case "Productos_Campania"
        FrmProductos_Campania.MdiParent = Me
        FrmProductos_Campania.Show()
        FrmProductos_Campania.BringToFront()
      Case "Ingreso_Traslado"    ' ButtonTool
                ' Place code here

      Case "Registro_Salida"    ' ButtonTool
        ' Place code here
        FrmSalida_traslado.MdiParent = Me
        FrmSalida_traslado.Show()

      Case "Registro_de_Ingresos"
        FrmMovimiento_Bancario.MdiParent = Me
        FrmMovimiento_Bancario.Show()
        FrmMovimiento_Bancario.BringToFront()
      Case "Plan_Cuentas"    ' ButtonTool
        ' Place code here
        FrmPlan_Cuentas.MdiParent = Me
        FrmPlan_Cuentas.Show()

      Case "Centro_Costos"    ' ButtonTool
        ' Place code here
        FrmCentros_Costo.MdiParent = Me
        FrmCentros_Costo.Show()

      Case "Arqueo_Ingresos"    ' ButtonTool
        ' Place code here
        FrmArqueo_Ingresos.MdiParent = Me
        FrmArqueo_Ingresos.Show()
                FrmArqueo_Ingresos.BringToFront()


            Case "Caja_Chica"    ' ButtonTool
                ' Place code here
                FrmArqueo_Fondo_Fijo.MdiParent = Me
        FrmArqueo_Fondo_Fijo.Show()

      Case "Asiento_Ingresos"    ' ButtonTool
                ' Place code here

      Case "Asiento_Lotes"    ' ButtonTool
                ' Place code here

              '=================================================MnuConsignacion====================

            Case "Control_Asistentes"
        FrmControl_Asistentes.MdiParent = Me
        FrmControl_Asistentes.Show()

      Case "Cuentas_Cobrar"    ' ButtonTool
        ' Place code here
        FrmPor_Cobrar.vDesde = False
        FrmPor_Cobrar.MdiParent = Me
        FrmPor_Cobrar.Show()
      Case "Panel_Reportes"
        FrmPanel_Reportes.MdiParent = Me
        FrmPanel_Reportes.Show()
      Case "Consignacion_Asistente"
        FrmConsignacion_Asistente.MdiParent = Me
        FrmConsignacion_Asistente.Show()
        FrmConsignacion_Asistente.BringToFront()
      Case "Boleteo_Colportor"
        FrmFacturacion_Consignacion.pRef = "BCC"
        FrmFacturacion_Consignacion.MdiParent = Me
        FrmFacturacion_Consignacion.Show()
        FrmFacturacion_Consignacion.BringToFront()
      Case "tipo_bonificacion"
        FrmTipo_Bonificacion.MdiParent = Me
        FrmTipo_Bonificacion.Show()
        FrmTipo_Bonificacion.BringToFront()
      Case "bonificacion_destino"
        FrmDestino_Bonificacion.MdiParent = Me
        FrmDestino_Bonificacion.Show()
        FrmDestino_Bonificacion.BringToFront()
      Case "bonificacion"
        FrmBonificacion.MdiParent = Me
        FrmBonificacion.Show()
        FrmBonificacion.BringToFront()
      Case "Estado_Cuenta"
        FrmPor_Cobrar.vDesde = True
        FrmPor_Cobrar.MdiParent = Me
        FrmPor_Cobrar.Show()
      Case "Venta_VIP"    ' ButtonTool
                ' Place code here

      Case "Control_Por_Guia"
        FrmConsignacion_Ctrl_Guia.MdiParent = Me
        FrmConsignacion_Ctrl_Guia.Show()
      Case "Personas_Cuenta"
        FrmPersonas_Consignatarias.MdiParent = Me
        FrmPersonas_Consignatarias.Show()
      Case "Control_Bloque"
        FrmConsignacion_Ctrl_Bloque.MdiParent = Me
        FrmConsignacion_Ctrl_Bloque.Show()

      Case "Permisos_Impresion"
        FrmPermisos_Impresion.MdiParent = Me
        FrmPermisos_Impresion.Show()
      Case "Conf_Mov_Mercaderia"
        FrmConf_Doc_Mov.MdiParent = Me
        FrmConf_Doc_Mov.Show()

      Case "Kardex"
        FrmKardex.MdiParent = Me
        FrmKardex.Show()
        FrmKardex.BringToFront()

      Case "transferencia_stock"
        If GestionSeguridadManager.sUsuario = "admin" Then
          FrmTransferir_Saldos.MdiParent = Me
          FrmTransferir_Saldos.Show()
          FrmTransferir_Saldos.BringToFront()
        End If
      Case "Integracion_ASSINET"
        If GestionSeguridadManager.sUsuario = "admin" Then
          FrmIntegracionAssinet.MdiParent = Me
          FrmIntegracionAssinet.Show()
          FrmIntegracionAssinet.BringToFront()
        End If
      Case "Salir"    ' ButtonTool
        ' Place code here
        If MessageBox.Show("Está seguro de cerrar el sistema", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
          Global.System.Windows.Forms.Application.Exit()
        End If

    End Select

  End Sub

  Private Sub Close_Windows()


    'For Each ChildForm As Form In RadDock1.DocumentManager.DocumentCloseActivation
    '    Dim dw As DockWindow = Me.RadDock1(ChildForm.Name)
    '    RadDock1.CloseWindow(dw)
    'Next
    RadDock1.CloseAllWindows()

  End Sub

  Private Sub lblUnidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUnidad.Click
    If MessageBox.Show("Esto cerrará todas las ventanas abiertas ¿está seguro de seguir?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      'For Each ChildForm As Form In Me.MdiChildren
      '    ChildForm.Close()
      'Next
      Call Close_Windows()
      ToolWindow1.Show()
      FrmEntidad.ShowDialog()
    End If

  End Sub

  Private Sub Permisos_Almacen()
    Dim FilterP As String = "unidadnegocioid = " & GestionSeguridadManager.gUnidadId
    Dim dvP As DataView
    If Not GestionTablas.dtAlmacen Is Nothing Then
      dvP = New DataView(GestionTablas.dtAlmacen, FilterP, "", DataViewRowState.CurrentRows)
      GestionTablas.dtFAlmacen = dvP
    Else
      dvP = Nothing
    End If
  End Sub

  Private Sub LoadNodes()
    Dim index As Integer = 0
    Dim watch As Stopwatch = Stopwatch.StartNew()

    Dim FilterP As String = "padre = 0 "
    Dim dvP As DataView, dtRowP As DataRowView
    If Not GestionTablas.dtMenu Is Nothing Then
      dvP = New DataView(GestionTablas.dtMenu, FilterP, "", DataViewRowState.CurrentRows)

    Else
      Me.rTreeMenu.Nodes.Clear()
      Exit Sub
    End If

    Using Me.rTreeMenu.DeferRefresh()
      Me.rTreeMenu.Nodes.Clear()
      For Each dtRowP In dvP
        index += 1

        Dim node As New RadTreeNode(dtRowP.Item("titulo").ToString, My.Resources.application_home, IIf(index = 1, True, False))

        Dim FilterH As String = "padre = " & dtRowP.Item("menuwindowid").ToString
        Dim dvH As DataView, dtRowH As DataRowView


        dvH = New DataView(GestionTablas.dtMenu, FilterH, "", DataViewRowState.CurrentRows)

        For Each dtRowH In dvH
          Dim child As New RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)
          child.Value = dtRowH.Item("form")
          child.Text = dtRowH.Item("titulo")
          child.Image = My.Resources.page_add
          node.Nodes.Add(child)
        Next

        Me.rTreeMenu.Nodes.Add(node)
      Next
    End Using
    watch.[Stop]()
    'Me.rTreeMenu.ExpandAll()

    'Me.radProgressBar1.Value1 = 50000
    'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
  End Sub

  Private Sub rTreeMenu_NodeMouseClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles rTreeMenu.NodeMouseClick
    If e.Node.Value = "Catalogo" Then
      FrmCatalogo.MdiParent = Me
      FrmCatalogo.Show()
      FrmCatalogo.BringToFront()
    ElseIf e.Node.Value = "Persona" Then
      FrmPersonaLis.MdiParent = Me
      FrmPersonaLis.Show()
      FrmPersonaLis.BringToFront()

    ElseIf e.Node.Value = "Salida" Then
      FrmSalida_traslado.MdiParent = Me
      FrmSalida_traslado.Show()
      FrmSalida_traslado.BringToFront()
    ElseIf e.Node.Value = "PorCobrar" Then
      FrmPor_Cobrar.MdiParent = Me
      FrmPor_Cobrar.Show()
      FrmPor_Cobrar.BringToFront()
    ElseIf e.Node.Value = "PorPagar" Then
      FrmPor_Pagar.MdiParent = Me
      FrmPor_Pagar.Show()
      FrmPor_Pagar.BringToFront()

      'Manteniento
    ElseIf e.Node.Value = "Documento" Then
      FrmSeriesDocumento.MdiParent = Me
      FrmSeriesDocumento.Show()
      FrmSeriesDocumento.BringToFront()

    ElseIf e.Node.Value = "Almacen" Then
      FrmAlmacen.MdiParent = Me
      FrmAlmacen.Show()
      FrmAlmacen.BringToFront()

      'Movimiento
    ElseIf e.Node.Value = "MB" Then
      FrmMovimiento_Bancario.MdiParent = Me
      FrmMovimiento_Bancario.Show()
      FrmMovimiento_Bancario.BringToFront()

    ElseIf e.Node.Value = "Importacion" Then
      FrmIngreso_Importacion.MdiParent = Me
      FrmIngreso_Importacion.Show()
      FrmIngreso_Importacion.BringToFront()
    ElseIf e.Node.Value = "Gestion_Cobranza" Then
      FrmGestion_Cobranza.MdiParent = Me
      FrmGestion_Cobranza.Show()
      FrmGestion_Cobranza.BringToFront()
    ElseIf e.Node.Value = "InfoSehs" Then
      FrmInfoSEHS.MdiParent = Me
      FrmInfoSEHS.Show()
      FrmInfoSEHS.BringToFront()
    ElseIf e.Node.Value = "ProvCastigo" Then
      FrmProvision_Castigo_Deuda.MdiParent = Me
      FrmProvision_Castigo_Deuda.Show()
      FrmProvision_Castigo_Deuda.BringToFront()
    ElseIf e.Node.Value = "Lote" Then
      FrmLote.MdiParent = Me
      FrmLote.Show()
      FrmLote.BringToFront()
    ElseIf e.Node.Value = "PlanCtaCte" Then
      FrmPlan_Ctacte.MdiParent = Me
      FrmPlan_Ctacte.Show()
      FrmPlan_Ctacte.BringToFront()

      'Consignacion
    ElseIf e.Node.Value = "limitecredito" Then
      FrmPersonas_Limite_Credito.MdiParent = Me
      FrmPersonas_Limite_Credito.Show()
      FrmPersonas_Limite_Credito.BringToFront()
    ElseIf e.Node.Value = "Control_Asisentes" Then
      FrmControl_Asistentes.MdiParent = Me
      FrmControl_Asistentes.Show()
      FrmControl_Asistentes.BringToFront()

    ElseIf e.Node.Value = "Productos_Campania" Then
      FrmProductos_Campania.MdiParent = Me
      FrmProductos_Campania.Show()
      FrmProductos_Campania.BringToFront()

    ElseIf e.Node.Value = "Consignacion_Asistente" Then
      FrmConsignacion_Asistente.MdiParent = Me
      FrmConsignacion_Asistente.Show()
      FrmConsignacion_Asistente.BringToFront()

    ElseIf e.Node.Value = "Boleteo_Colportor" Then
      FrmConsignacion_Asistente.MdiParent = Me
      FrmConsignacion_Asistente.Show()
      FrmConsignacion_Asistente.BringToFront()

    ElseIf e.Node.Value = "Consignacion_Ctrl_Bloque" Then
      FrmConsignacion_Ctrl_Bloque.MdiParent = Me
      FrmConsignacion_Ctrl_Bloque.Show()
      FrmConsignacion_Ctrl_Bloque.BringToFront()

    ElseIf e.Node.Value = "Boleteo_We_Colportor" Then
      FrmPedido_Web.MdiParent = Me
      FrmPedido_Web.Show()
      FrmPedido_Web.BringToFront()
    ElseIf e.Node.Value = "Deposito_We_Colportor" Then
      FrmDeposito_Web.MdiParent = Me
      FrmDeposito_Web.Show()
      FrmDeposito_Web.BringToFront()
    ElseIf e.Node.Value = "Devolucion_We_Colportor" Then
      FrmDevolucion_Asis_Web.MdiParent = Me
      FrmDevolucion_Asis_Web.Show()
      FrmDevolucion_Asis_Web.BringToFront()
    ElseIf e.Node.Value = "NC_We_Colportor" Then
      FrmNota_Credito_Web.MdiParent = Me
      FrmNota_Credito_Web.Show()
      FrmNota_Credito_Web.BringToFront()

      'Rutina Mes - Día
    ElseIf e.Node.Value = "ArqueoIngreso" Then  ' ButtonTool
      ' Place code here
      FrmArqueo_Ingresos.MdiParent = Me
      FrmArqueo_Ingresos.Show()
      FrmArqueo_Ingresos.BringToFront()

    ElseIf e.Node.Value = "AqueoGasto" Then  ' ButtonTool
      ' Place code here
      FrmArqueo_Fondo_Fijo.MdiParent = Me
      FrmArqueo_Fondo_Fijo.Show()
      FrmArqueo_Fondo_Fijo.BringToFront()

      '""
      'Reprotes
    ElseIf e.Node.Value = "Reportes" Then
      FrmPanel_Reportes.MdiParent = Me
      FrmPanel_Reportes.Show()
      FrmPanel_Reportes.BringToFront()

    ElseIf e.Node.Value = "ReportesG" Then
      FrmPanel_Gerencial.MdiParent = Me
      FrmPanel_Gerencial.Show()
      FrmPanel_Gerencial.BringToFront()

    ElseIf e.Node.Value = "PanelSuscripciones" Then
      FrmPanel_Suscripciones.MdiParent = Me
      FrmPanel_Suscripciones.Show()
      FrmPanel_Suscripciones.BringToFront()

      'Utilidades
    ElseIf e.Node.Value = "Acceso" Then
      FrmGestion_Acceso.MdiParent = Me
      FrmGestion_Acceso.Show()
      FrmGestion_Acceso.BringToFront()

    ElseIf e.Node.Value = "TransferStock" Then
      FrmTransferir_Saldos.MdiParent = Me
      FrmTransferir_Saldos.Show()
      FrmTransferir_Saldos.BringToFront()

    ElseIf e.Node.Value = "PermisosPrint" Then
      FrmPermisos_Impresion.MdiParent = Me
      FrmPermisos_Impresion.Show()
      FrmPermisos_Impresion.BringToFront()

    ElseIf e.Node.Value = "Assinet" Then
      FrmIntegracionAssinet.MdiParent = Me
      FrmIntegracionAssinet.Show()
      FrmIntegracionAssinet.BringToFront()
    ElseIf e.Node.Value = "ControlMes" Then
      FrmCierre_Mes.MdiParent = Me
      FrmCierre_Mes.Show()
      FrmCierre_Mes.BringToFront()

    End If
  End Sub

  Private Sub RadDock1_DockWindowRemoved(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.Docking.DockWindowEventArgs) Handles RadDock1.DockWindowRemoved
    e.DockWindow.Close()
  End Sub

  Private Sub contextRadDropDownButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles RadDropDownButton1.MouseDown
    Dim active As DockWindow = Me.RadDock1.DocumentManager.ActiveDocument
    If active Is Nothing Then
      Return
    End If

    Dim service As ContextMenuService = Me.RadDock1.GetService(Of ContextMenuService)()
    If service Is Nothing Then
      Return
    End If

    Dim bounds As Rectangle = Me.RadDropDownButton1.Bounds
    bounds = Me.RadDropDownButton1.Parent.RectangleToScreen(bounds)
    Dim location As New Point(bounds.X, bounds.Bottom + 1)
    service.DisplayContextMenu(active, location)
  End Sub

End Class
