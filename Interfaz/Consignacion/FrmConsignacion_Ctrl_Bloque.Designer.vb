<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsignacion_Ctrl_Bloque
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsignacion_Ctrl_Bloque))
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
    Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.chkRango = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
    Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.cboHasta = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjaxRes = New System.Windows.Forms.PictureBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsmProcesos = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmnAddConsignacion = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmnBoletear = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmnDevolver = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsReportes = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmnuRptStock = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmnuDetalle_Doc = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsBoletas = New System.Windows.Forms.ToolStripButton()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel()
    Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
    Me.tsActualziar_Detalle = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsAgregar_Consignacion = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsdDetalle_Doc = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsGuiaDuplicado = New System.Windows.Forms.ToolStripButton()
    Me.tsDetExcel = New System.Windows.Forms.ToolStripButton()
    Me.lblTotalGuias = New Infragistics.Win.Misc.UltraLabel()
    Me.LblRegistros = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Detalle = New System.ComponentModel.BackgroundWorker()
    Me.utExcel = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.tsmnuRptStock1 = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.chkRango, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox3.SuspendLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox6.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip2.SuspendLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.Moccasin
    Appearance1.BackColor2 = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop20Bright
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.chkRango)
    Me.gpCriterios.Controls.Add(Me.cboDesde)
    Me.gpCriterios.Controls.Add(Me.cboHasta)
    Me.gpCriterios.Controls.Add(Me.UltraLabel1)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(0, 0)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(821, 89)
    Me.gpCriterios.TabIndex = 4
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'chkRango
    '
    Appearance2.FontData.Name = "Arial"
    Appearance2.FontData.SizeInPoints = 8.0!
    Me.chkRango.Appearance = Appearance2
    Me.chkRango.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.chkRango.Location = New System.Drawing.Point(417, 29)
    Me.chkRango.Name = "chkRango"
    Me.chkRango.Size = New System.Drawing.Size(108, 18)
    Me.chkRango.TabIndex = 112
    Me.chkRango.Text = "Rango"
    '
    'cboDesde
    '
    Appearance3.FontData.BoldAsString = "True"
    Appearance3.FontData.Name = "Tahoma"
    Appearance3.FontData.SizeInPoints = 10.0!
    Me.cboDesde.Appearance = Appearance3
    Me.cboDesde.DateButtons.Add(DateButton1)
    Me.cboDesde.Location = New System.Drawing.Point(282, 29)
    Me.cboDesde.Name = "cboDesde"
    Me.cboDesde.NonAutoSizeHeight = 21
    Me.cboDesde.Size = New System.Drawing.Size(116, 22)
    Me.cboDesde.TabIndex = 94
    Me.cboDesde.Value = "20/09/2009"
    '
    'cboHasta
    '
    Appearance4.FontData.BoldAsString = "True"
    Appearance4.FontData.Name = "Tahoma"
    Appearance4.FontData.SizeInPoints = 10.0!
    Me.cboHasta.Appearance = Appearance4
    Me.cboHasta.DateButtons.Add(DateButton2)
    Me.cboHasta.Location = New System.Drawing.Point(282, 56)
    Me.cboHasta.Name = "cboHasta"
    Me.cboHasta.NonAutoSizeHeight = 21
    Me.cboHasta.Size = New System.Drawing.Size(116, 22)
    Me.cboHasta.TabIndex = 93
    Me.cboHasta.Value = "20/09/2009"
    '
    'UltraLabel1
    '
    Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance5.ForeColor = System.Drawing.Color.SteelBlue
    Appearance5.TextVAlignAsString = "Top"
    Me.UltraLabel1.Appearance = Appearance5
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel1.Location = New System.Drawing.Point(61, 3)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(328, 28)
    Me.UltraLabel1.TabIndex = 91
    Me.UltraLabel1.Text = "Control Bloque"
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(417, 42)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'UltraLabel12
    '
    Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance6.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance6.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance6
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(61, 36)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(191, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "      Almacén                                          "
    '
    'cboAlmacen
    '
    Appearance7.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance8
    Appearance9.BackColor = System.Drawing.Color.White
    Appearance9.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance9.FontData.BoldAsString = "True"
    Appearance9.FontData.Name = "Arial"
    Appearance9.FontData.SizeInPoints = 10.0!
    Appearance9.ForeColor = System.Drawing.Color.White
    Appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance9
    Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance10
    Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance11
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(61, 55)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(191, 23)
    Me.cboAlmacen.TabIndex = 1
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(5, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(54, 57)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 91)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.UltraGroupBox3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.UltraGroupBox6)
    Me.SplitContainer1.Size = New System.Drawing.Size(820, 395)
    Me.SplitContainer1.SplitterDistance = 410
    Me.SplitContainer1.TabIndex = 9
    '
    'UltraGroupBox3
    '
    Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance12.BackColor = System.Drawing.Color.White
    Appearance12.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox3.ContentAreaAppearance = Appearance12
    Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
    Me.UltraGroupBox3.Controls.Add(Me.ToolStrip1)
    Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
    Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
    Me.UltraGroupBox3.Controls.Add(Me.dgvResumen)
    Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox3.Name = "UltraGroupBox3"
    Me.UltraGroupBox3.Size = New System.Drawing.Size(404, 389)
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
    Me.picAjaxRes.Location = New System.Drawing.Point(3, 28)
    Me.picAjaxRes.Name = "picAjaxRes"
    Me.picAjaxRes.Size = New System.Drawing.Size(397, 325)
    Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxRes.TabIndex = 84
    Me.picAjaxRes.TabStop = False
    Me.picAjaxRes.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator4, Me.tsmProcesos, Me.ToolStripSeparator3, Me.tsReportes, Me.ToolStripSeparator11, Me.tsBoletas, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip1.Size = New System.Drawing.Size(398, 25)
    Me.ToolStrip1.TabIndex = 88
    Me.ToolStrip1.Text = "ToolStrip2"
    '
    'tsActualizar
    '
    Me.tsActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsActualizar.Name = "tsActualizar"
    Me.tsActualizar.Size = New System.Drawing.Size(23, 22)
    Me.tsActualizar.Text = "Actualizar"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'tsmProcesos
    '
    Me.tsmProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmnAddConsignacion, Me.tsmnBoletear, Me.tsmnDevolver})
    Me.tsmProcesos.Image = Global.Phoenix.My.Resources.Resources.kservices
    Me.tsmProcesos.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsmProcesos.Name = "tsmProcesos"
    Me.tsmProcesos.Size = New System.Drawing.Size(83, 22)
    Me.tsmProcesos.Text = "Procesos"
    '
    'tsmnAddConsignacion
    '
    Me.tsmnAddConsignacion.BackColor = System.Drawing.Color.White
    Me.tsmnAddConsignacion.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsmnAddConsignacion.Name = "tsmnAddConsignacion"
    Me.tsmnAddConsignacion.Size = New System.Drawing.Size(192, 22)
    Me.tsmnAddConsignacion.Text = "Agregar Consignación"
    '
    'tsmnBoletear
    '
    Me.tsmnBoletear.BackColor = System.Drawing.Color.White
    Me.tsmnBoletear.Image = Global.Phoenix.My.Resources.Resources.application_go
    Me.tsmnBoletear.Name = "tsmnBoletear"
    Me.tsmnBoletear.Size = New System.Drawing.Size(192, 22)
    Me.tsmnBoletear.Text = "Boletear"
    '
    'tsmnDevolver
    '
    Me.tsmnDevolver.BackColor = System.Drawing.Color.White
    Me.tsmnDevolver.Image = Global.Phoenix.My.Resources.Resources.agt_reload16
    Me.tsmnDevolver.Name = "tsmnDevolver"
    Me.tsmnDevolver.Size = New System.Drawing.Size(192, 22)
    Me.tsmnDevolver.Text = "Devolver"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'tsReportes
    '
    Me.tsReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmnuRptStock, Me.tsmnuRptStock1, Me.tsmnuDetalle_Doc})
    Me.tsReportes.Image = Global.Phoenix.My.Resources.Resources.fileprint
    Me.tsReportes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsReportes.Name = "tsReportes"
    Me.tsReportes.Size = New System.Drawing.Size(82, 22)
    Me.tsReportes.Text = "&Reportes"
    '
    'tsmnuRptStock
    '
    Me.tsmnuRptStock.BackColor = System.Drawing.Color.White
    Me.tsmnuRptStock.Image = Global.Phoenix.My.Resources.Resources.zconcepto
    Me.tsmnuRptStock.Name = "tsmnuRptStock"
    Me.tsmnuRptStock.Size = New System.Drawing.Size(181, 22)
    Me.tsmnuRptStock.Text = "Stock "
    '
    'tsmnuDetalle_Doc
    '
    Me.tsmnuDetalle_Doc.BackColor = System.Drawing.Color.White
    Me.tsmnuDetalle_Doc.Image = Global.Phoenix.My.Resources.Resources.application_view_tile
    Me.tsmnuDetalle_Doc.Name = "tsmnuDetalle_Doc"
    Me.tsmnuDetalle_Doc.Size = New System.Drawing.Size(181, 22)
    Me.tsmnuDetalle_Doc.Text = "Detalle Documentos"
    Me.tsmnuDetalle_Doc.Visible = False
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
    '
    'tsBoletas
    '
    Me.tsBoletas.Image = Global.Phoenix.My.Resources.Resources.application_view_list
    Me.tsBoletas.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsBoletas.Name = "tsBoletas"
    Me.tsBoletas.Size = New System.Drawing.Size(65, 22)
    Me.tsBoletas.Text = "Boletas"
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
    'LblDeudaTotal
    '
    Me.LblDeudaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance13.BackColor = System.Drawing.Color.LemonChiffon
    Appearance13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance13.TextHAlignAsString = "Right"
    Appearance13.TextVAlignAsString = "Middle"
    Me.LblDeudaTotal.Appearance = Appearance13
    Me.LblDeudaTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblDeudaTotal.Location = New System.Drawing.Point(150, 365)
    Me.LblDeudaTotal.Name = "LblDeudaTotal"
    Me.LblDeudaTotal.Size = New System.Drawing.Size(145, 17)
    Me.LblDeudaTotal.TabIndex = 87
    Me.LblDeudaTotal.Text = "0.00"
    '
    'lblRegistros_Res
    '
    Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance14.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance14.TextHAlignAsString = "Right"
    Appearance14.TextVAlignAsString = "Middle"
    Me.lblRegistros_Res.Appearance = Appearance14
    Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 366)
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
    Appearance15.BackColor = System.Drawing.Color.White
    Me.dgvResumen.DisplayLayout.Appearance = Appearance15
    Me.dgvResumen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    Me.dgvResumen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
    Appearance16.BackColor = System.Drawing.Color.Transparent
    Me.dgvResumen.DisplayLayout.Override.CardAreaAppearance = Appearance16
    Me.dgvResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
    Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance17.FontData.BoldAsString = "True"
    Appearance17.FontData.Name = "Arial"
    Appearance17.FontData.SizeInPoints = 10.0!
    Appearance17.ForeColor = System.Drawing.Color.White
    Appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvResumen.DisplayLayout.Override.HeaderAppearance = Appearance17
    Me.dgvResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.RowSelectorAppearance = Appearance18
    Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance19.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.SelectedRowAppearance = Appearance19
    Me.dgvResumen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    Me.dgvResumen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvResumen.Location = New System.Drawing.Point(6, 28)
    Me.dgvResumen.Name = "dgvResumen"
    Me.dgvResumen.Size = New System.Drawing.Size(390, 331)
    Me.dgvResumen.TabIndex = 85
    '
    'UltraGroupBox6
    '
    Me.UltraGroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox6.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance20.BackColor = System.Drawing.Color.White
    Appearance20.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox6.ContentAreaAppearance = Appearance20
    Me.UltraGroupBox6.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox6.Controls.Add(Me.ToolStrip2)
    Me.UltraGroupBox6.Controls.Add(Me.lblTotalGuias)
    Me.UltraGroupBox6.Controls.Add(Me.LblRegistros)
    Me.UltraGroupBox6.Controls.Add(Me.dgvListado)
    Me.UltraGroupBox6.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox6.Name = "UltraGroupBox6"
    Me.UltraGroupBox6.Size = New System.Drawing.Size(400, 389)
    Me.UltraGroupBox6.TabIndex = 5
    Me.UltraGroupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(5, 3)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(390, 349)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 84
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'ToolStrip2
    '
    Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
    Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualziar_Detalle, Me.ToolStripSeparator1, Me.tsAgregar_Consignacion, Me.ToolStripSeparator2, Me.tsdDetalle_Doc, Me.ToolStripSeparator5, Me.tsGuiaDuplicado, Me.tsDetExcel})
    Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
    Me.ToolStrip2.Name = "ToolStrip2"
    Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip2.Size = New System.Drawing.Size(394, 25)
    Me.ToolStrip2.TabIndex = 91
    Me.ToolStrip2.Text = "ToolStrip2"
    '
    'tsActualziar_Detalle
    '
    Me.tsActualziar_Detalle.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsActualziar_Detalle.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsActualziar_Detalle.Name = "tsActualziar_Detalle"
    Me.tsActualziar_Detalle.Size = New System.Drawing.Size(79, 22)
    Me.tsActualziar_Detalle.Text = "&Actualizar"
    Me.tsActualziar_Detalle.ToolTipText = "Actualiza el Detalle"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsAgregar_Consignacion
    '
    Me.tsAgregar_Consignacion.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsAgregar_Consignacion.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsAgregar_Consignacion.Name = "tsAgregar_Consignacion"
    Me.tsAgregar_Consignacion.Size = New System.Drawing.Size(69, 22)
    Me.tsAgregar_Consignacion.Text = "Agregar"
    Me.tsAgregar_Consignacion.ToolTipText = "Agregar Consignación"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsdDetalle_Doc
    '
    Me.tsdDetalle_Doc.Image = Global.Phoenix.My.Resources.Resources.monitor
    Me.tsdDetalle_Doc.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsdDetalle_Doc.Name = "tsdDetalle_Doc"
    Me.tsdDetalle_Doc.Size = New System.Drawing.Size(90, 22)
    Me.tsdDetalle_Doc.Text = "Detalle Guia"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
    '
    'tsGuiaDuplicado
    '
    Me.tsGuiaDuplicado.Image = Global.Phoenix.My.Resources.Resources.printer
    Me.tsGuiaDuplicado.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsGuiaDuplicado.Name = "tsGuiaDuplicado"
    Me.tsGuiaDuplicado.Size = New System.Drawing.Size(81, 22)
    Me.tsGuiaDuplicado.Text = "Duplicado"
    '
    'tsDetExcel
    '
    Me.tsDetExcel.BackColor = System.Drawing.Color.Transparent
    Me.tsDetExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsDetExcel.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsDetExcel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDetExcel.Name = "tsDetExcel"
    Me.tsDetExcel.Size = New System.Drawing.Size(23, 22)
    Me.tsDetExcel.Text = "Excel"
    '
    'lblTotalGuias
    '
    Me.lblTotalGuias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance21.BackColor = System.Drawing.Color.LemonChiffon
    Appearance21.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance21.TextHAlignAsString = "Right"
    Appearance21.TextVAlignAsString = "Middle"
    Me.lblTotalGuias.Appearance = Appearance21
    Me.lblTotalGuias.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblTotalGuias.Location = New System.Drawing.Point(78, 366)
    Me.lblTotalGuias.Name = "lblTotalGuias"
    Me.lblTotalGuias.Size = New System.Drawing.Size(100, 17)
    Me.lblTotalGuias.TabIndex = 90
    Me.lblTotalGuias.Text = "0.00"
    '
    'LblRegistros
    '
    Me.LblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance22.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance22.TextVAlignAsString = "Middle"
    Me.LblRegistros.Appearance = Appearance22
    Me.LblRegistros.Location = New System.Drawing.Point(5, 366)
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
    Me.dgvListado.Size = New System.Drawing.Size(391, 327)
    Me.dgvListado.TabIndex = 17
    Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    '
    'bwLlenar_Res
    '
    '
    'bwLlenar_Detalle
    '
    '
    'tsmnuRptStock1
    '
    Me.tsmnuRptStock1.BackColor = System.Drawing.Color.White
    Me.tsmnuRptStock1.Name = "tsmnuRptStock1"
    Me.tsmnuRptStock1.Size = New System.Drawing.Size(181, 22)
    Me.tsmnuRptStock1.Text = "Sólo con Stock"
    '
    'FrmConsignacion_Ctrl_Bloque
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(821, 484)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmConsignacion_Ctrl_Bloque"
    Me.Text = "Consignacion Control Bloque"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.chkRango, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox3.ResumeLayout(False)
    Me.UltraGroupBox3.PerformLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox6.ResumeLayout(False)
    Me.UltraGroupBox6.PerformLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip2.ResumeLayout(False)
    Me.ToolStrip2.PerformLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvResumen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsActualziar_Detalle As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTotalGuias As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Detalle As System.ComponentModel.BackgroundWorker
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAgregar_Consignacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsdDetalle_Doc As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmnuRptStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmnuDetalle_Doc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboHasta As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmProcesos As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmnAddConsignacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmnBoletear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmnDevolver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsGuiaDuplicado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBoletas As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents chkRango As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents tsDetExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents utExcel As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
  Friend WithEvents tsmnuRptStock1 As ToolStripMenuItem
End Class
