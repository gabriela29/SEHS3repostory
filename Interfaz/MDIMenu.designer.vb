<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMenu))
        Dim RibbonTab1 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("mnuInicio")
        Dim RibbonGroup1 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("gpSalir")
        Dim ButtonTool17 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Salir")
        Dim ButtonTool35 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Control_Mes")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Salir")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("utbMenuH")
        Dim ButtonTool34 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Control_Mes")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Salir")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblBuild = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblServidor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUnidad = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEquipo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMoneda = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblIGV = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MnuSubOpDefinirAccesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpSucursal = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpAlmacen = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpCampania = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpConfParam = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpTipoMov = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpTipoDoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpConfMovDoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpMnuETransporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpMnuChofer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCategoríaPersona = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpTipoDocId = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpUbigeo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpClasificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpAsistentes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpColportores = New System.Windows.Forms.ToolStripMenuItem()
        Me._MDIMenu_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UTBManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._MDIMenu_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._MDIMenu_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._MDIMenu_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.RadDock1 = New Telerik.WinControls.UI.Docking.RadDock()
        Me.ToolWindow1 = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.pgOpciones = New Telerik.WinControls.UI.RadPageView()
        Me.gpMenu = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rTreeMenu = New Telerik.WinControls.UI.RadTreeView()
        Me.gpConf = New Telerik.WinControls.UI.RadPageViewPage()
        Me.ToolTabStrip1 = New Telerik.WinControls.UI.Docking.ToolTabStrip()
        Me.DocumentContainer1 = New Telerik.WinControls.UI.Docking.DocumentContainer()
        Me.RadDropDownButton1 = New Telerik.WinControls.UI.RadDropDownButton()
        Me.ToolTabStrip2 = New Telerik.WinControls.UI.Docking.ToolTabStrip()
        Me.StatusStrip.SuspendLayout()
        CType(Me.UTBManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadDock1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolWindow1.SuspendLayout()
        CType(Me.pgOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpMenu.SuspendLayout()
        CType(Me.rTreeMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolTabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadDropDownButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolTabStrip2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblBuild, Me.lblServidor, Me.lblUnidad, Me.lblUsuario, Me.lblEquipo, Me.lblMoneda, Me.lblIGV})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 548)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(922, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblBuild
        '
        Me.lblBuild.Image = Global.Phoenix.My.Resources.Resources.cog_add
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(32, 17)
        Me.lblBuild.Text = "..."
        '
        'lblServidor
        '
        Me.lblServidor.Image = CType(resources.GetObject("lblServidor.Image"), System.Drawing.Image)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(32, 17)
        Me.lblServidor.Text = "..."
        '
        'lblUnidad
        '
        Me.lblUnidad.Image = Global.Phoenix.My.Resources.Resources.gohome
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(32, 17)
        Me.lblUnidad.Text = "..."
        '
        'lblUsuario
        '
        Me.lblUsuario.Image = CType(resources.GetObject("lblUsuario.Image"), System.Drawing.Image)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(32, 17)
        Me.lblUsuario.Text = "..."
        '
        'lblEquipo
        '
        Me.lblEquipo.Image = Global.Phoenix.My.Resources.Resources.monitor
        Me.lblEquipo.Name = "lblEquipo"
        Me.lblEquipo.Size = New System.Drawing.Size(32, 17)
        Me.lblEquipo.Text = "..."
        '
        'lblMoneda
        '
        Me.lblMoneda.Image = Global.Phoenix.My.Resources.Resources.money
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(32, 17)
        Me.lblMoneda.Text = "..."
        '
        'lblIGV
        '
        Me.lblIGV.Image = Global.Phoenix.My.Resources.Resources.zconcepto
        Me.lblIGV.Name = "lblIGV"
        Me.lblIGV.Size = New System.Drawing.Size(44, 17)
        Me.lblIGV.Text = "0.00"
        '
        'MnuSubOpDefinirAccesos
        '
        Me.MnuSubOpDefinirAccesos.Name = "MnuSubOpDefinirAccesos"
        Me.MnuSubOpDefinirAccesos.Size = New System.Drawing.Size(209, 22)
        Me.MnuSubOpDefinirAccesos.Text = "&Definir Accesos al Sistema"
        '
        'MnuOpEmpresa
        '
        Me.MnuOpEmpresa.Name = "MnuOpEmpresa"
        Me.MnuOpEmpresa.Size = New System.Drawing.Size(209, 22)
        Me.MnuOpEmpresa.Text = "Empresa"
        '
        'MnuOpSucursal
        '
        Me.MnuOpSucursal.Name = "MnuOpSucursal"
        Me.MnuOpSucursal.Size = New System.Drawing.Size(209, 22)
        Me.MnuOpSucursal.Text = "Sucursal"
        '
        'MnuOpAlmacen
        '
        Me.MnuOpAlmacen.Name = "MnuOpAlmacen"
        Me.MnuOpAlmacen.Size = New System.Drawing.Size(209, 22)
        Me.MnuOpAlmacen.Text = "Almacen"
        '
        'MnuOpCampania
        '
        Me.MnuOpCampania.Name = "MnuOpCampania"
        Me.MnuOpCampania.Size = New System.Drawing.Size(209, 22)
        Me.MnuOpCampania.Text = "Campaña(s)"
        '
        'MnuOpConfParam
        '
        Me.MnuOpConfParam.Name = "MnuOpConfParam"
        Me.MnuOpConfParam.Size = New System.Drawing.Size(209, 22)
        Me.MnuOpConfParam.Text = "Configuración Parámetros"
        '
        'MnuOpTipoMov
        '
        Me.MnuOpTipoMov.Name = "MnuOpTipoMov"
        Me.MnuOpTipoMov.Size = New System.Drawing.Size(176, 22)
        Me.MnuOpTipoMov.Text = "Tipo Movimiento"
        '
        'MnuOpTipoDoc
        '
        Me.MnuOpTipoDoc.Name = "MnuOpTipoDoc"
        Me.MnuOpTipoDoc.Size = New System.Drawing.Size(176, 22)
        Me.MnuOpTipoDoc.Text = "Tipo Documento"
        '
        'MnuOpConfMovDoc
        '
        Me.MnuOpConfMovDoc.Name = "MnuOpConfMovDoc"
        Me.MnuOpConfMovDoc.Size = New System.Drawing.Size(176, 22)
        Me.MnuOpConfMovDoc.Text = "Series Documentos"
        '
        'OpMnuETransporte
        '
        Me.OpMnuETransporte.Name = "OpMnuETransporte"
        Me.OpMnuETransporte.Size = New System.Drawing.Size(151, 22)
        Me.OpMnuETransporte.Text = "E. Transporte"
        '
        'OpMnuChofer
        '
        Me.OpMnuChofer.Name = "OpMnuChofer"
        Me.OpMnuChofer.Size = New System.Drawing.Size(151, 22)
        Me.OpMnuChofer.Text = "Chofer"
        '
        'MnuCategoríaPersona
        '
        Me.MnuCategoríaPersona.Name = "MnuCategoríaPersona"
        Me.MnuCategoríaPersona.Size = New System.Drawing.Size(179, 22)
        Me.MnuCategoríaPersona.Text = "Categoría Persona"
        '
        'MnuOpTipoDocId
        '
        Me.MnuOpTipoDocId.Name = "MnuOpTipoDocId"
        Me.MnuOpTipoDocId.Size = New System.Drawing.Size(179, 22)
        Me.MnuOpTipoDocId.Text = "Tipo Doc. Identidad"
        '
        'MnuOpUbigeo
        '
        Me.MnuOpUbigeo.Name = "MnuOpUbigeo"
        Me.MnuOpUbigeo.Size = New System.Drawing.Size(179, 22)
        Me.MnuOpUbigeo.Text = "Ubigeo"
        '
        'MnuOpClasificar
        '
        Me.MnuOpClasificar.Name = "MnuOpClasificar"
        Me.MnuOpClasificar.Size = New System.Drawing.Size(183, 22)
        Me.MnuOpClasificar.Text = "&Clasificar Persona(s)"
        '
        'MnuOpProveedores
        '
        Me.MnuOpProveedores.Name = "MnuOpProveedores"
        Me.MnuOpProveedores.Size = New System.Drawing.Size(183, 22)
        Me.MnuOpProveedores.Text = "&Proveedores"
        '
        'MnuOpClientes
        '
        Me.MnuOpClientes.Name = "MnuOpClientes"
        Me.MnuOpClientes.Size = New System.Drawing.Size(183, 22)
        Me.MnuOpClientes.Text = "&Clientes"
        '
        'MnuOpAsistentes
        '
        Me.MnuOpAsistentes.Name = "MnuOpAsistentes"
        Me.MnuOpAsistentes.Size = New System.Drawing.Size(183, 22)
        Me.MnuOpAsistentes.Text = "&Asistentes"
        '
        'MnuOpColportores
        '
        Me.MnuOpColportores.Name = "MnuOpColportores"
        Me.MnuOpColportores.Size = New System.Drawing.Size(183, 22)
        Me.MnuOpColportores.Text = "&Colportores"
        '
        '_MDIMenu_Toolbars_Dock_Area_Left
        '
        Me._MDIMenu_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._MDIMenu_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._MDIMenu_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._MDIMenu_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MDIMenu_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 4
        Me._MDIMenu_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 160)
        Me._MDIMenu_Toolbars_Dock_Area_Left.Name = "_MDIMenu_Toolbars_Dock_Area_Left"
        Me._MDIMenu_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(4, 388)
        Me._MDIMenu_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UTBManager1
        '
        'UTBManager1
        '
        Me.UTBManager1.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.[False]
        Me.UTBManager1.DesignerFlags = 1
        Me.UTBManager1.DockWithinContainer = Me
        Me.UTBManager1.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UTBManager1.Ribbon.ApplicationMenuButtonImage = Global.Phoenix.My.Resources.Resources.large_logo
        RibbonTab1.Caption = "Inicio"
        RibbonGroup1.Caption = "Cerrar Sistema"
        ButtonTool17.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool17})
        RibbonTab1.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup1})
        Me.UTBManager1.Ribbon.NonInheritedRibbonTabs.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonTab() {RibbonTab1})
        Me.UTBManager1.Ribbon.QuickAccessToolbar.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool35, ButtonTool4})
        Me.UTBManager1.Ribbon.Visible = True
        Me.UTBManager1.ShowFullMenusDelay = 500
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        UltraToolbar1.Text = "utbMenuH"
        Me.UTBManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        ButtonTool34.SharedPropsInternal.AppearancesSmall.Appearance = Appearance1
        ButtonTool34.SharedPropsInternal.Caption = "       "
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        ButtonTool2.SharedPropsInternal.AppearancesSmall.Appearance = Appearance2
        Me.UTBManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool34, ButtonTool2})
        '
        '_MDIMenu_Toolbars_Dock_Area_Right
        '
        Me._MDIMenu_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._MDIMenu_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._MDIMenu_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._MDIMenu_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MDIMenu_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 4
        Me._MDIMenu_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(918, 160)
        Me._MDIMenu_Toolbars_Dock_Area_Right.Name = "_MDIMenu_Toolbars_Dock_Area_Right"
        Me._MDIMenu_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(4, 388)
        Me._MDIMenu_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UTBManager1
        '
        '_MDIMenu_Toolbars_Dock_Area_Top
        '
        Me._MDIMenu_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._MDIMenu_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._MDIMenu_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._MDIMenu_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MDIMenu_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._MDIMenu_Toolbars_Dock_Area_Top.Name = "_MDIMenu_Toolbars_Dock_Area_Top"
        Me._MDIMenu_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(922, 160)
        Me._MDIMenu_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UTBManager1
        '
        '_MDIMenu_Toolbars_Dock_Area_Bottom
        '
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 548)
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.Name = "_MDIMenu_Toolbars_Dock_Area_Bottom"
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(922, 0)
        Me._MDIMenu_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UTBManager1
        '
        'RadDock1
        '
        Me.RadDock1.ActiveWindow = Me.ToolWindow1
        Me.RadDock1.BackColor = System.Drawing.Color.Transparent
        Me.RadDock1.Controls.Add(Me.ToolTabStrip1)
        Me.RadDock1.Controls.Add(Me.DocumentContainer1)
        Me.RadDock1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadDock1.DocumentManager.DocumentInsertOrder = Telerik.WinControls.UI.Docking.DockWindowInsertOrder.InFront
        Me.RadDock1.IsCleanUpTarget = True
        Me.RadDock1.Location = New System.Drawing.Point(4, 160)
        Me.RadDock1.MainDocumentContainer = Me.DocumentContainer1
        Me.RadDock1.Name = "RadDock1"
        Me.RadDock1.Padding = New System.Windows.Forms.Padding(5)
        '
        '
        '
        Me.RadDock1.RootElement.AccessibleDescription = Nothing
        Me.RadDock1.RootElement.AccessibleName = Nothing
        Me.RadDock1.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 200, 200)
        Me.RadDock1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.RadDock1.RootElement.Padding = New System.Windows.Forms.Padding(5)
        Me.RadDock1.Size = New System.Drawing.Size(914, 388)
        Me.RadDock1.SplitterWidth = 4
        Me.RadDock1.TabIndex = 10
        Me.RadDock1.TabStop = False
        Me.RadDock1.Text = "RadDock1"
        '
        'ToolWindow1
        '
        Me.ToolWindow1.Caption = Nothing
        Me.ToolWindow1.Controls.Add(Me.pgOpciones)
        Me.ToolWindow1.Location = New System.Drawing.Point(1, 24)
        Me.ToolWindow1.Name = "ToolWindow1"
        Me.ToolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.ToolWindow1.Size = New System.Drawing.Size(248, 352)
        Me.ToolWindow1.Text = "MENU"
        '
        'pgOpciones
        '
        Me.pgOpciones.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pgOpciones.Controls.Add(Me.gpMenu)
        Me.pgOpciones.Controls.Add(Me.gpConf)
        Me.pgOpciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgOpciones.Location = New System.Drawing.Point(0, 0)
        Me.pgOpciones.Name = "pgOpciones"
        '
        '
        '
        Me.pgOpciones.RootElement.AccessibleDescription = Nothing
        Me.pgOpciones.RootElement.AccessibleName = Nothing
        Me.pgOpciones.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 400, 300)
        Me.pgOpciones.SelectedPage = Me.gpMenu
        Me.pgOpciones.Size = New System.Drawing.Size(248, 352)
        Me.pgOpciones.TabIndex = 0
        Me.pgOpciones.Text = "..."
        Me.pgOpciones.ViewMode = Telerik.WinControls.UI.PageViewMode.Outlook
        '
        'gpMenu
        '
        Me.gpMenu.BackColor = System.Drawing.Color.White
        Me.gpMenu.Controls.Add(Me.rTreeMenu)
        Me.gpMenu.Location = New System.Drawing.Point(5, 31)
        Me.gpMenu.Name = "gpMenu"
        Me.gpMenu.Size = New System.Drawing.Size(238, 210)
        Me.gpMenu.Text = "MENU"
        '
        'rTreeMenu
        '
        Me.rTreeMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rTreeMenu.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rTreeMenu.Location = New System.Drawing.Point(0, 0)
        Me.rTreeMenu.Name = "rTreeMenu"
        '
        '
        '
        Me.rTreeMenu.RootElement.AccessibleDescription = Nothing
        Me.rTreeMenu.RootElement.AccessibleName = Nothing
        Me.rTreeMenu.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 150, 250)
        Me.rTreeMenu.Size = New System.Drawing.Size(238, 200)
        Me.rTreeMenu.SpacingBetweenNodes = -1
        Me.rTreeMenu.TabIndex = 0
        Me.rTreeMenu.Text = "RadTreeView1"
        '
        'gpConf
        '
        Me.gpConf.BackColor = System.Drawing.Color.White
        Me.gpConf.Location = New System.Drawing.Point(5, 31)
        Me.gpConf.Name = "gpConf"
        Me.gpConf.Size = New System.Drawing.Size(238, 210)
        Me.gpConf.Text = "  ...   "
        '
        'ToolTabStrip1
        '
        Me.ToolTabStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolTabStrip1.Controls.Add(Me.ToolWindow1)
        Me.ToolTabStrip1.Location = New System.Drawing.Point(5, 5)
        Me.ToolTabStrip1.Name = "ToolTabStrip1"
        '
        '
        '
        Me.ToolTabStrip1.RootElement.AccessibleDescription = Nothing
        Me.ToolTabStrip1.RootElement.AccessibleName = Nothing
        Me.ToolTabStrip1.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 200, 200)
        Me.ToolTabStrip1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.ToolTabStrip1.SelectedIndex = 0
        Me.ToolTabStrip1.Size = New System.Drawing.Size(250, 378)
        Me.ToolTabStrip1.SizeInfo.AbsoluteSize = New System.Drawing.Size(250, 200)
        Me.ToolTabStrip1.SizeInfo.SplitterCorrection = New System.Drawing.Size(50, 0)
        Me.ToolTabStrip1.TabIndex = 1
        Me.ToolTabStrip1.TabStop = False
        '
        'DocumentContainer1
        '
        Me.DocumentContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DocumentContainer1.Location = New System.Drawing.Point(259, 5)
        Me.DocumentContainer1.Name = "DocumentContainer1"
        Me.DocumentContainer1.Padding = New System.Windows.Forms.Padding(5)
        '
        '
        '
        Me.DocumentContainer1.RootElement.AccessibleDescription = Nothing
        Me.DocumentContainer1.RootElement.AccessibleName = Nothing
        Me.DocumentContainer1.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 200, 200)
        Me.DocumentContainer1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocumentContainer1.RootElement.Padding = New System.Windows.Forms.Padding(5)
        Me.DocumentContainer1.Size = New System.Drawing.Size(650, 378)
        Me.DocumentContainer1.SizeInfo.AbsoluteSize = New System.Drawing.Size(341, 200)
        Me.DocumentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill
        Me.DocumentContainer1.SizeInfo.SplitterCorrection = New System.Drawing.Size(-50, 0)
        Me.DocumentContainer1.SplitterWidth = 4
        Me.DocumentContainer1.TabIndex = 0
        Me.DocumentContainer1.TabStop = False
        '
        'RadDropDownButton1
        '
        Me.RadDropDownButton1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.RadDropDownButton1.Location = New System.Drawing.Point(125, 31)
        Me.RadDropDownButton1.Name = "RadDropDownButton1"
        '
        '
        '
        Me.RadDropDownButton1.RootElement.AccessibleDescription = Nothing
        Me.RadDropDownButton1.RootElement.AccessibleName = Nothing
        Me.RadDropDownButton1.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 140, 24)
        Me.RadDropDownButton1.Size = New System.Drawing.Size(123, 25)
        Me.RadDropDownButton1.TabIndex = 2
        Me.RadDropDownButton1.Text = "Opciones"
        '
        'ToolTabStrip2
        '
        Me.ToolTabStrip2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolTabStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolTabStrip2.Name = "ToolTabStrip2"
        '
        '
        '
        Me.ToolTabStrip2.RootElement.AccessibleDescription = Nothing
        Me.ToolTabStrip2.RootElement.AccessibleName = Nothing
        Me.ToolTabStrip2.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 200, 200)
        Me.ToolTabStrip2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.ToolTabStrip2.Size = New System.Drawing.Size(292, 266)
        Me.ToolTabStrip2.TabIndex = 0
        Me.ToolTabStrip2.TabStop = False
        '
        'MDIMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(922, 570)
        Me.Controls.Add(Me.RadDropDownButton1)
        Me.Controls.Add(Me.RadDock1)
        Me.Controls.Add(Me._MDIMenu_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._MDIMenu_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._MDIMenu_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me._MDIMenu_Toolbars_Dock_Area_Top)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIMenu"
        Me.Text = "Menu Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.UTBManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadDock1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolWindow1.ResumeLayout(False)
        CType(Me.pgOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpMenu.ResumeLayout(False)
        CType(Me.rTreeMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolTabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadDropDownButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolTabStrip2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblServidor As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MnuSubOpDefinirAccesos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpEmpresa As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpSucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpAlmacen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpCampania As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpConfParam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpTipoMov As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpTipoDoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpConfMovDoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpMnuETransporte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpMnuChofer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCategoríaPersona As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpTipoDocId As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents MnuOpUbigeo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpClasificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpProveedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpAsistentes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpColportores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UTBManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _MDIMenu_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _MDIMenu_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _MDIMenu_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _MDIMenu_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEquipo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUnidad As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RadDock1 As Telerik.WinControls.UI.Docking.RadDock
    Friend WithEvents ToolWindow1 As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents ToolTabStrip1 As Telerik.WinControls.UI.Docking.ToolTabStrip
    Friend WithEvents DocumentContainer1 As Telerik.WinControls.UI.Docking.DocumentContainer
    Friend WithEvents ToolTabStrip2 As Telerik.WinControls.UI.Docking.ToolTabStrip
    Friend WithEvents pgOpciones As Telerik.WinControls.UI.RadPageView
    Friend WithEvents gpMenu As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents gpConf As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents rTreeMenu As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents RadDropDownButton1 As Telerik.WinControls.UI.RadDropDownButton
    Friend WithEvents lblBuild As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents lblMoneda As ToolStripStatusLabel
  Friend WithEvents lblIGV As ToolStripStatusLabel
End Class
