<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPor_Pagar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPor_Pagar))
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.gpPersona = New Infragistics.Win.Misc.UltraGroupBox()
    Me.TxtAnombreD = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.lblPersonaId = New Infragistics.Win.Misc.UltraLabel()
    Me.btnBuscarCliente = New Infragistics.Win.Misc.UltraButton()
    Me.lblCondicion = New Infragistics.Win.Misc.UltraLabel()
    Me.CboFecha2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.gpBotones = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsdActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDNuevo = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsResumen = New System.Windows.Forms.ToolStripButton()
    Me.tsopReportes = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmEstadoCuenta = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsMnuDetDocumentos = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsMnuDetDocCredito = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsExcelRes = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjaxRes = New System.Windows.Forms.PictureBox()
    Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel()
    Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
    Me.tsMnuOpcionesDet = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsopMnuDsctoNC = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsmExpDetExcel = New System.Windows.Forms.ToolStripButton()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.LblAPagar = New Infragistics.Win.Misc.UltraLabel()
    Me.lblTotalDeuda = New Infragistics.Win.Misc.UltraLabel()
    Me.lblTotalPagos = New Infragistics.Win.Misc.UltraLabel()
    Me.lblTotalSaldo = New Infragistics.Win.Misc.UltraLabel()
    Me.LblRegistros = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
    Me.tsActualiza_Detalle = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDuplicado = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDetalleDoc = New System.Windows.Forms.ToolStripButton()
    Me.tsEliminar = New System.Windows.Forms.ToolStripButton()
    Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Detalle = New System.ComponentModel.BackgroundWorker()
    Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.tsmEstadoCtaCons = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpPersona.SuspendLayout()
    CType(Me.TxtAnombreD, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CboFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpBotones.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox3.SuspendLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox6.SuspendLayout()
    Me.ToolStrip3.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip2.SuspendLayout()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.cboDesde)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.gpPersona)
    Me.gpCriterios.Controls.Add(Me.lblCondicion)
    Me.gpCriterios.Controls.Add(Me.CboFecha2)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(747, 88)
    Me.gpCriterios.TabIndex = 2
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'cboDesde
    '
    Appearance2.FontData.BoldAsString = "True"
    Appearance2.FontData.Name = "Tahoma"
    Appearance2.FontData.SizeInPoints = 10.0!
    Me.cboDesde.Appearance = Appearance2
    Me.cboDesde.DateButtons.Add(DateButton1)
    Me.cboDesde.Location = New System.Drawing.Point(283, 23)
    Me.cboDesde.Name = "cboDesde"
    Me.cboDesde.NonAutoSizeHeight = 21
    Me.cboDesde.Size = New System.Drawing.Size(114, 22)
    Me.cboDesde.TabIndex = 90
    Me.cboDesde.Value = "20/09/2009"
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(535, 7)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'gpPersona
    '
    Me.gpPersona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance3.BackColor = System.Drawing.Color.White
    Appearance3.BackColor2 = System.Drawing.Color.White
    Me.gpPersona.ContentAreaAppearance = Appearance3
    Me.gpPersona.Controls.Add(Me.TxtAnombreD)
    Me.gpPersona.Controls.Add(Me.lblPersonaId)
    Me.gpPersona.Controls.Add(Me.btnBuscarCliente)
    Me.gpPersona.Location = New System.Drawing.Point(99, 51)
    Me.gpPersona.Name = "gpPersona"
    Me.gpPersona.Size = New System.Drawing.Size(645, 34)
    Me.gpPersona.TabIndex = 3
    Me.gpPersona.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'TxtAnombreD
    '
    Appearance4.BackColor = System.Drawing.Color.Transparent
    Appearance4.ForeColor = System.Drawing.Color.Black
    Appearance4.TextVAlignAsString = "Middle"
    Me.TxtAnombreD.Appearance = Appearance4
    Me.TxtAnombreD.BackColor = System.Drawing.Color.Transparent
    Me.TxtAnombreD.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.TxtAnombreD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAnombreD.Location = New System.Drawing.Point(135, 7)
    Me.TxtAnombreD.MaxLength = 0
    Me.TxtAnombreD.Name = "TxtAnombreD"
    Me.TxtAnombreD.Size = New System.Drawing.Size(335, 22)
    Me.TxtAnombreD.TabIndex = 136
    '
    'lblPersonaId
    '
    Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance5.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance5.TextHAlignAsString = "Center"
    Appearance5.TextVAlignAsString = "Top"
    Me.lblPersonaId.Appearance = Appearance5
    Me.lblPersonaId.Font = New System.Drawing.Font("Arial Narrow", 8.25!)
    Me.lblPersonaId.Location = New System.Drawing.Point(527, 10)
    Me.lblPersonaId.Name = "lblPersonaId"
    Me.lblPersonaId.Size = New System.Drawing.Size(48, 16)
    Me.lblPersonaId.TabIndex = 135
    Me.lblPersonaId.Text = "-2"
    '
    'btnBuscarCliente
    '
    Appearance6.BackColor = System.Drawing.Color.White
    Appearance6.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
    Me.btnBuscarCliente.Appearance = Appearance6
    Me.btnBuscarCliente.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnBuscarCliente.Location = New System.Drawing.Point(13, 6)
    Me.btnBuscarCliente.Name = "btnBuscarCliente"
    Me.btnBuscarCliente.Size = New System.Drawing.Size(114, 23)
    Me.btnBuscarCliente.TabIndex = 134
    Me.btnBuscarCliente.Text = "&Proveedor"
    Me.btnBuscarCliente.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'lblCondicion
    '
    Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance7.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance7.TextVAlignAsString = "Top"
    Me.lblCondicion.Appearance = Appearance7
    Me.lblCondicion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblCondicion.Location = New System.Drawing.Point(109, 4)
    Me.lblCondicion.Name = "lblCondicion"
    Me.lblCondicion.Size = New System.Drawing.Size(621, 15)
    Me.lblCondicion.TabIndex = 31
    Me.lblCondicion.Text = "    Almacén                                   Desde                        Hasta " &
    "          "
    '
    'CboFecha2
    '
    Appearance8.FontData.BoldAsString = "True"
    Appearance8.FontData.Name = "Tahoma"
    Appearance8.FontData.SizeInPoints = 10.0!
    Me.CboFecha2.Appearance = Appearance8
    Me.CboFecha2.DateButtons.Add(DateButton2)
    Me.CboFecha2.Location = New System.Drawing.Point(405, 23)
    Me.CboFecha2.Name = "CboFecha2"
    Me.CboFecha2.NonAutoSizeHeight = 21
    Me.CboFecha2.Size = New System.Drawing.Size(114, 22)
    Me.CboFecha2.TabIndex = 3
    Me.CboFecha2.Value = "20/09/2009"
    '
    'cboAlmacen
    '
    Appearance9.BackColor = System.Drawing.Color.LemonChiffon
    Appearance9.BackColor2 = System.Drawing.Color.White
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
    Me.cboAlmacen.Appearance = Appearance9
    Appearance10.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance10
    Appearance11.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance11
    Appearance12.BackColor = System.Drawing.Color.White
    Appearance12.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance12.FontData.BoldAsString = "True"
    Appearance12.FontData.Name = "Arial"
    Appearance12.FontData.SizeInPoints = 10.0!
    Appearance12.ForeColor = System.Drawing.Color.White
    Appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance12
    Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance13
    Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance14.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance14
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(109, 22)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(167, 25)
    Me.cboAlmacen.TabIndex = 1
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(-10, -2)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(100, 80)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'gpBotones
    '
    Me.gpBotones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpBotones.Controls.Add(Me.ToolStrip1)
    Me.gpBotones.Location = New System.Drawing.Point(-1, 87)
    Me.gpBotones.Name = "gpBotones"
    Me.gpBotones.Size = New System.Drawing.Size(746, 28)
    Me.gpBotones.TabIndex = 5
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdActualizar, Me.ToolStripSeparator13, Me.tsDNuevo, Me.ToolStripSeparator3, Me.tsResumen, Me.tsopReportes, Me.ToolStripSeparator5, Me.ToolStripSeparator11, Me.tsExcelRes, Me.ToolStripSeparator1, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip1.Size = New System.Drawing.Size(424, 25)
    Me.ToolStrip1.TabIndex = 22
    Me.ToolStrip1.Text = "ToolStrip2"
    '
    'tsdActualizar
    '
    Me.tsdActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsdActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsdActualizar.Name = "tsdActualizar"
    Me.tsdActualizar.Size = New System.Drawing.Size(79, 22)
    Me.tsdActualizar.Text = "Actualizar"
    Me.tsdActualizar.ToolTipText = "Actualizar Saldos"
    '
    'ToolStripSeparator13
    '
    Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
    Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
    '
    'tsDNuevo
    '
    Me.tsDNuevo.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsDNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDNuevo.Name = "tsDNuevo"
    Me.tsDNuevo.Size = New System.Drawing.Size(69, 22)
    Me.tsDNuevo.Text = "&Agregar"
    Me.tsDNuevo.ToolTipText = "Agregar un Cargo"
    Me.tsDNuevo.Visible = False
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'tsResumen
    '
    Me.tsResumen.Image = Global.Phoenix.My.Resources.Resources.application_view_tile
    Me.tsResumen.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsResumen.Name = "tsResumen"
    Me.tsResumen.Size = New System.Drawing.Size(64, 22)
    Me.tsResumen.Text = "Totales"
    Me.tsResumen.ToolTipText = "Totales"
    '
    'tsopReportes
    '
    Me.tsopReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmEstadoCuenta, Me.tsmEstadoCtaCons, Me.tsMnuDetDocumentos, Me.tsMnuDetDocCredito})
    Me.tsopReportes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsopReportes.Name = "tsopReportes"
    Me.tsopReportes.Size = New System.Drawing.Size(66, 22)
    Me.tsopReportes.Text = "&Reportes"
    '
    'tsmEstadoCuenta
    '
    Me.tsmEstadoCuenta.BackColor = System.Drawing.Color.White
    Me.tsmEstadoCuenta.Image = Global.Phoenix.My.Resources.Resources.zconcepto
    Me.tsmEstadoCuenta.Name = "tsmEstadoCuenta"
    Me.tsmEstadoCuenta.Size = New System.Drawing.Size(236, 22)
    Me.tsmEstadoCuenta.Text = "Estado de Cuenta"
    '
    'tsMnuDetDocumentos
    '
    Me.tsMnuDetDocumentos.BackColor = System.Drawing.Color.White
    Me.tsMnuDetDocumentos.Image = Global.Phoenix.My.Resources.Resources.fileprint
    Me.tsMnuDetDocumentos.Name = "tsMnuDetDocumentos"
    Me.tsMnuDetDocumentos.Size = New System.Drawing.Size(236, 22)
    Me.tsMnuDetDocumentos.Text = "Detalle Documento Emitidos"
    Me.tsMnuDetDocumentos.Visible = False
    '
    'tsMnuDetDocCredito
    '
    Me.tsMnuDetDocCredito.BackColor = System.Drawing.Color.White
    Me.tsMnuDetDocCredito.Image = Global.Phoenix.My.Resources.Resources.month
    Me.tsMnuDetDocCredito.Name = "tsMnuDetDocCredito"
    Me.tsMnuDetDocCredito.Size = New System.Drawing.Size(236, 22)
    Me.tsMnuDetDocCredito.Text = "Detalle Documentos Crédito"
    Me.tsMnuDetDocCredito.Visible = False
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
    '
    'tsExcelRes
    '
    Me.tsExcelRes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsExcelRes.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsExcelRes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsExcelRes.Name = "tsExcelRes"
    Me.tsExcelRes.Size = New System.Drawing.Size(23, 22)
    Me.tsExcelRes.Text = "Excel Lista"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsDSalir
    '
    Me.tsDSalir.Image = CType(resources.GetObject("tsDSalir.Image"), System.Drawing.Image)
    Me.tsDSalir.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDSalir.Name = "tsDSalir"
    Me.tsDSalir.Size = New System.Drawing.Size(59, 22)
    Me.tsDSalir.Text = "&Cerrar"
    Me.tsDSalir.ToolTipText = "Cerrar Ventana"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 118)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.UltraGroupBox3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.UltraGroupBox6)
    Me.SplitContainer1.Size = New System.Drawing.Size(742, 384)
    Me.SplitContainer1.SplitterDistance = 390
    Me.SplitContainer1.TabIndex = 7
    '
    'UltraGroupBox3
    '
    Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance15.BackColor = System.Drawing.Color.White
    Appearance15.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox3.ContentAreaAppearance = Appearance15
    Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
    Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
    Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
    Me.UltraGroupBox3.Controls.Add(Me.dgvResumen)
    Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox3.Name = "UltraGroupBox3"
    Me.UltraGroupBox3.Size = New System.Drawing.Size(384, 378)
    Me.UltraGroupBox3.TabIndex = 6
    Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'picAjaxRes
    '
    Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
    Me.picAjaxRes.Location = New System.Drawing.Point(3, 9)
    Me.picAjaxRes.Name = "picAjaxRes"
    Me.picAjaxRes.Size = New System.Drawing.Size(377, 333)
    Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxRes.TabIndex = 84
    Me.picAjaxRes.TabStop = False
    Me.picAjaxRes.Visible = False
    '
    'LblDeudaTotal
    '
    Me.LblDeudaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance16.BackColor = System.Drawing.Color.LemonChiffon
    Appearance16.BackColor2 = System.Drawing.Color.White
    Appearance16.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance16.TextHAlignAsString = "Right"
    Appearance16.TextVAlignAsString = "Middle"
    Me.LblDeudaTotal.Appearance = Appearance16
    Me.LblDeudaTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblDeudaTotal.Location = New System.Drawing.Point(119, 354)
    Me.LblDeudaTotal.Name = "LblDeudaTotal"
    Me.LblDeudaTotal.Size = New System.Drawing.Size(145, 17)
    Me.LblDeudaTotal.TabIndex = 87
    Me.LblDeudaTotal.Text = "0.00"
    '
    'lblRegistros_Res
    '
    Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance17.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance17.TextHAlignAsString = "Right"
    Appearance17.TextVAlignAsString = "Middle"
    Me.lblRegistros_Res.Appearance = Appearance17
    Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 355)
    Me.lblRegistros_Res.Name = "lblRegistros_Res"
    Me.lblRegistros_Res.Size = New System.Drawing.Size(107, 14)
    Me.lblRegistros_Res.TabIndex = 86
    Me.lblRegistros_Res.Text = "-"
    '
    'dgvResumen
    '
    Me.dgvResumen.AllowDrop = True
    Me.dgvResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance18.BackColor = System.Drawing.Color.White
    Me.dgvResumen.DisplayLayout.Appearance = Appearance18
    Me.dgvResumen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    Me.dgvResumen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
    Appearance19.BackColor = System.Drawing.Color.Transparent
    Me.dgvResumen.DisplayLayout.Override.CardAreaAppearance = Appearance19
    Me.dgvResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
    Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance20.FontData.BoldAsString = "True"
    Appearance20.FontData.Name = "Arial"
    Appearance20.FontData.SizeInPoints = 10.0!
    Appearance20.ForeColor = System.Drawing.Color.White
    Appearance20.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvResumen.DisplayLayout.Override.HeaderAppearance = Appearance20
    Me.dgvResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance21.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.RowSelectorAppearance = Appearance21
    Appearance22.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance22.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.SelectedRowAppearance = Appearance22
    Me.dgvResumen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    Me.dgvResumen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvResumen.Location = New System.Drawing.Point(6, 4)
    Me.dgvResumen.Name = "dgvResumen"
    Me.dgvResumen.Size = New System.Drawing.Size(370, 344)
    Me.dgvResumen.TabIndex = 85
    '
    'UltraGroupBox6
    '
    Me.UltraGroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox6.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance23.BackColor = System.Drawing.Color.White
    Appearance23.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox6.ContentAreaAppearance = Appearance23
    Me.UltraGroupBox6.Controls.Add(Me.ToolStrip3)
    Me.UltraGroupBox6.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox6.Controls.Add(Me.LblAPagar)
    Me.UltraGroupBox6.Controls.Add(Me.lblTotalDeuda)
    Me.UltraGroupBox6.Controls.Add(Me.lblTotalPagos)
    Me.UltraGroupBox6.Controls.Add(Me.lblTotalSaldo)
    Me.UltraGroupBox6.Controls.Add(Me.LblRegistros)
    Me.UltraGroupBox6.Controls.Add(Me.dgvListado)
    Me.UltraGroupBox6.Controls.Add(Me.ToolStrip2)
    Me.UltraGroupBox6.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox6.Name = "UltraGroupBox6"
    Me.UltraGroupBox6.Size = New System.Drawing.Size(342, 378)
    Me.UltraGroupBox6.TabIndex = 5
    Me.UltraGroupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'ToolStrip3
    '
    Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMnuOpcionesDet, Me.ToolStripSeparator6, Me.tsmExpDetExcel})
    Me.ToolStrip3.Location = New System.Drawing.Point(3, 2)
    Me.ToolStrip3.Name = "ToolStrip3"
    Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip3.Size = New System.Drawing.Size(118, 25)
    Me.ToolStrip3.TabIndex = 92
    Me.ToolStrip3.Text = "ToolStrip3"
    '
    'tsMnuOpcionesDet
    '
    Me.tsMnuOpcionesDet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsopMnuDsctoNC})
    Me.tsMnuOpcionesDet.Image = Global.Phoenix.My.Resources.Resources.view_bottom
    Me.tsMnuOpcionesDet.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsMnuOpcionesDet.Name = "tsMnuOpcionesDet"
    Me.tsMnuOpcionesDet.Size = New System.Drawing.Size(86, 22)
    Me.tsMnuOpcionesDet.Text = "Opciones"
    '
    'tsopMnuDsctoNC
    '
    Me.tsopMnuDsctoNC.BackColor = System.Drawing.Color.White
    Me.tsopMnuDsctoNC.Image = Global.Phoenix.My.Resources.Resources.agt_reload161
    Me.tsopMnuDsctoNC.Name = "tsopMnuDsctoNC"
    Me.tsopMnuDsctoNC.Size = New System.Drawing.Size(133, 22)
    Me.tsopMnuDsctoNC.Text = "Dscto. N.C."
    '
    'ToolStripSeparator6
    '
    Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
    Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
    '
    'tsmExpDetExcel
    '
    Me.tsmExpDetExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsmExpDetExcel.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsmExpDetExcel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsmExpDetExcel.Name = "tsmExpDetExcel"
    Me.tsmExpDetExcel.Size = New System.Drawing.Size(23, 22)
    Me.tsmExpDetExcel.Text = "Exportar Excel"
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(5, 32)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(332, 316)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 84
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'LblAPagar
    '
    Me.LblAPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance24.BackColor = System.Drawing.Color.Lavender
    Appearance24.BackColor2 = System.Drawing.Color.White
    Appearance24.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance24.TextHAlignAsString = "Right"
    Appearance24.TextVAlignAsString = "Middle"
    Me.LblAPagar.Appearance = Appearance24
    Me.LblAPagar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblAPagar.Location = New System.Drawing.Point(237, 9)
    Me.LblAPagar.Name = "LblAPagar"
    Me.LblAPagar.Size = New System.Drawing.Size(100, 17)
    Me.LblAPagar.TabIndex = 80
    Me.LblAPagar.Text = "0.00"
    '
    'lblTotalDeuda
    '
    Me.lblTotalDeuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance25.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance25.TextHAlignAsString = "Right"
    Appearance25.TextVAlignAsString = "Middle"
    Me.lblTotalDeuda.Appearance = Appearance25
    Me.lblTotalDeuda.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblTotalDeuda.Location = New System.Drawing.Point(20, 355)
    Me.lblTotalDeuda.Name = "lblTotalDeuda"
    Me.lblTotalDeuda.Size = New System.Drawing.Size(100, 17)
    Me.lblTotalDeuda.TabIndex = 90
    Me.lblTotalDeuda.Text = "0.00"
    '
    'lblTotalPagos
    '
    Me.lblTotalPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance26.BackColor = System.Drawing.Color.Honeydew
    Appearance26.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance26.TextHAlignAsString = "Right"
    Appearance26.TextVAlignAsString = "Middle"
    Me.lblTotalPagos.Appearance = Appearance26
    Me.lblTotalPagos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblTotalPagos.Location = New System.Drawing.Point(126, 354)
    Me.lblTotalPagos.Name = "lblTotalPagos"
    Me.lblTotalPagos.Size = New System.Drawing.Size(100, 17)
    Me.lblTotalPagos.TabIndex = 89
    Me.lblTotalPagos.Text = "0.00"
    '
    'lblTotalSaldo
    '
    Me.lblTotalSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance27.BackColor = System.Drawing.Color.LemonChiffon
    Appearance27.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance27.TextHAlignAsString = "Right"
    Appearance27.TextVAlignAsString = "Middle"
    Me.lblTotalSaldo.Appearance = Appearance27
    Me.lblTotalSaldo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblTotalSaldo.Location = New System.Drawing.Point(232, 354)
    Me.lblTotalSaldo.Name = "lblTotalSaldo"
    Me.lblTotalSaldo.Size = New System.Drawing.Size(100, 17)
    Me.lblTotalSaldo.TabIndex = 88
    Me.lblTotalSaldo.Text = "0.00"
    '
    'LblRegistros
    '
    Me.LblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance28.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance28.TextVAlignAsString = "Middle"
    Me.LblRegistros.Appearance = Appearance28
    Me.LblRegistros.Location = New System.Drawing.Point(5, 355)
    Me.LblRegistros.Name = "LblRegistros"
    Me.LblRegistros.Size = New System.Drawing.Size(107, 14)
    Me.LblRegistros.TabIndex = 79
    Me.LblRegistros.Text = "-"
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
    Me.dgvListado.Location = New System.Drawing.Point(5, 30)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(333, 316)
    Me.dgvListado.TabIndex = 17
    Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    '
    'ToolStrip2
    '
    Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualiza_Detalle, Me.ToolStripSeparator2, Me.tsDuplicado, Me.ToolStripSeparator4, Me.tsDetalleDoc, Me.tsEliminar})
    Me.ToolStrip2.Location = New System.Drawing.Point(5, 4)
    Me.ToolStrip2.Name = "ToolStrip2"
    Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip2.Size = New System.Drawing.Size(180, 25)
    Me.ToolStrip2.TabIndex = 91
    Me.ToolStrip2.Text = "ToolStrip2"
    Me.ToolStrip2.Visible = False
    '
    'tsActualiza_Detalle
    '
    Me.tsActualiza_Detalle.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsActualiza_Detalle.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsActualiza_Detalle.Name = "tsActualiza_Detalle"
    Me.tsActualiza_Detalle.Size = New System.Drawing.Size(79, 22)
    Me.tsActualiza_Detalle.Text = "&Actualizar"
    Me.tsActualiza_Detalle.ToolTipText = "Actualizar Detalle"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsDuplicado
    '
    Me.tsDuplicado.Image = Global.Phoenix.My.Resources.Resources.printer
    Me.tsDuplicado.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDuplicado.Name = "tsDuplicado"
    Me.tsDuplicado.Size = New System.Drawing.Size(81, 22)
    Me.tsDuplicado.Text = "&Duplicado"
    Me.tsDuplicado.ToolTipText = "Imprimir Duplicado"
    Me.tsDuplicado.Visible = False
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'tsDetalleDoc
    '
    Me.tsDetalleDoc.Image = Global.Phoenix.My.Resources.Resources.demo
    Me.tsDetalleDoc.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDetalleDoc.Name = "tsDetalleDoc"
    Me.tsDetalleDoc.Size = New System.Drawing.Size(63, 22)
    Me.tsDetalleDoc.Text = "Detalle"
    '
    'tsEliminar
    '
    Me.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsEliminar.Image = Global.Phoenix.My.Resources.Resources.cancel
    Me.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsEliminar.Name = "tsEliminar"
    Me.tsEliminar.Size = New System.Drawing.Size(23, 22)
    Me.tsEliminar.Text = "Eliminar"
    '
    'bwLlenar_Res
    '
    '
    'bwLlenar_Detalle
    '
    '
    'tsmEstadoCtaCons
    '
    Me.tsmEstadoCtaCons.Name = "tsmEstadoCtaCons"
    Me.tsmEstadoCtaCons.Size = New System.Drawing.Size(236, 22)
    Me.tsmEstadoCtaCons.Text = "Estado de Cuenta Consolidado"
    '
    'FrmPor_Pagar
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(744, 502)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.gpBotones)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmPor_Pagar"
    Me.ShowInTaskbar = False
    Me.Text = "Por Pagar"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpPersona.ResumeLayout(False)
    Me.gpPersona.PerformLayout()
    CType(Me.TxtAnombreD, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CboFecha2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpBotones.ResumeLayout(False)
    Me.gpBotones.PerformLayout()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox3.ResumeLayout(False)
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox6.ResumeLayout(False)
    Me.UltraGroupBox6.PerformLayout()
    Me.ToolStrip3.ResumeLayout(False)
    Me.ToolStrip3.PerformLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip2.ResumeLayout(False)
    Me.ToolStrip2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents gpPersona As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCondicion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CboFecha2 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents gpBotones As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsdActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents tsResumen As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsopReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmEstadoCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMnuDetDocumentos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMnuDetDocCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExcelRes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents dgvResumen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsActualiza_Detalle As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDuplicado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDetalleDoc As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblAPagar As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTotalDeuda As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTotalPagos As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTotalSaldo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Detalle As System.ComponentModel.BackgroundWorker
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents TxtAnombreD As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPersonaId As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBuscarCliente As Infragistics.Win.Misc.UltraButton
  Friend WithEvents ToolStrip3 As ToolStrip
  Friend WithEvents tsmExpDetExcel As ToolStripButton
  Friend WithEvents tsMnuOpcionesDet As ToolStripDropDownButton
  Friend WithEvents tsopMnuDsctoNC As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
  Friend WithEvents tsmEstadoCtaCons As ToolStripMenuItem
End Class
