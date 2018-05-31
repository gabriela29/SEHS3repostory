<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalida_traslado
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
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalida_traslado))
    Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.cboDocumento = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.gpPersona = New Infragistics.Win.Misc.UltraGroupBox()
    Me.lblCondicion = New Infragistics.Win.Misc.UltraLabel()
    Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.cboHasta = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.gpBotones = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjaxRes = New System.Windows.Forms.PictureBox()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsdActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsdProductos = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsbAjuste = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsopReportes = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmDuplicado = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmDetalle = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
    Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpPersona.SuspendLayout()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpBotones.SuspendLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.cboDocumento)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.gpPersona)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(699, 93)
    Me.gpCriterios.TabIndex = 2
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'cboDocumento
    '
    Appearance2.BackColor = System.Drawing.Color.White
    Me.cboDocumento.Appearance = Appearance2
    Me.cboDocumento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance3.BackColor = System.Drawing.Color.White
    Me.cboDocumento.DisplayLayout.Appearance = Appearance3
    Appearance4.BackColor = System.Drawing.Color.Transparent
    Me.cboDocumento.DisplayLayout.Override.CardAreaAppearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.White
    Appearance5.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance5.FontData.BoldAsString = "True"
    Appearance5.FontData.Name = "Arial"
    Appearance5.FontData.SizeInPoints = 10.0!
    Appearance5.ForeColor = System.Drawing.Color.White
    Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboDocumento.DisplayLayout.Override.HeaderAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboDocumento.DisplayLayout.Override.RowSelectorAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboDocumento.DisplayLayout.Override.SelectedRowAppearance = Appearance7
    Me.cboDocumento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboDocumento.Location = New System.Drawing.Point(262, 23)
    Me.cboDocumento.Name = "cboDocumento"
    Me.cboDocumento.Size = New System.Drawing.Size(291, 23)
    Me.cboDocumento.TabIndex = 80
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(618, 10)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'gpPersona
    '
    Me.gpPersona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance8.BackColor = System.Drawing.Color.White
    Appearance8.BackColor2 = System.Drawing.Color.White
    Me.gpPersona.ContentAreaAppearance = Appearance8
    Me.gpPersona.Controls.Add(Me.lblCondicion)
    Me.gpPersona.Controls.Add(Me.cboDesde)
    Me.gpPersona.Controls.Add(Me.cboHasta)
    Me.gpPersona.Location = New System.Drawing.Point(57, 52)
    Me.gpPersona.Name = "gpPersona"
    Me.gpPersona.Size = New System.Drawing.Size(640, 34)
    Me.gpPersona.TabIndex = 3
    Me.gpPersona.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'lblCondicion
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance9.TextVAlignAsString = "Top"
    Me.lblCondicion.Appearance = Appearance9
    Me.lblCondicion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblCondicion.Location = New System.Drawing.Point(9, 10)
    Me.lblCondicion.Name = "lblCondicion"
    Me.lblCondicion.Size = New System.Drawing.Size(170, 15)
    Me.lblCondicion.TabIndex = 32
    Me.lblCondicion.Text = "Buscar por Fechas"
    '
    'cboDesde
    '
    Appearance10.FontData.BoldAsString = "True"
    Appearance10.FontData.Name = "Tahoma"
    Appearance10.FontData.SizeInPoints = 10.0!
    Me.cboDesde.Appearance = Appearance10
    Me.cboDesde.DateButtons.Add(DateButton1)
    Me.cboDesde.Location = New System.Drawing.Point(185, 6)
    Me.cboDesde.Name = "cboDesde"
    Me.cboDesde.NonAutoSizeHeight = 21
    Me.cboDesde.Size = New System.Drawing.Size(116, 22)
    Me.cboDesde.TabIndex = 4
    Me.cboDesde.Value = "20/09/2009"
    '
    'cboHasta
    '
    Appearance11.FontData.BoldAsString = "True"
    Appearance11.FontData.Name = "Tahoma"
    Appearance11.FontData.SizeInPoints = 10.0!
    Me.cboHasta.Appearance = Appearance11
    Me.cboHasta.DateButtons.Add(DateButton2)
    Me.cboHasta.Location = New System.Drawing.Point(380, 6)
    Me.cboHasta.Name = "cboHasta"
    Me.cboHasta.NonAutoSizeHeight = 21
    Me.cboHasta.Size = New System.Drawing.Size(116, 22)
    Me.cboHasta.TabIndex = 3
    Me.cboHasta.Value = "20/09/2009"
    '
    'UltraLabel12
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance12.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance12
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(57, 4)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(497, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "     Almacén                                            Documento           "
    '
    'cboAlmacen
    '
    Appearance13.BackColor = System.Drawing.Color.LemonChiffon
    Appearance13.BackColor2 = System.Drawing.Color.White
    Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
    Me.cboAlmacen.Appearance = Appearance13
    Appearance14.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance14
    Appearance15.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance15
    Appearance16.BackColor = System.Drawing.Color.White
    Appearance16.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance16.FontData.BoldAsString = "True"
    Appearance16.FontData.Name = "Arial"
    Appearance16.FontData.SizeInPoints = 10.0!
    Appearance16.ForeColor = System.Drawing.Color.White
    Appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance16
    Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance17
    Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance18
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(67, 22)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(189, 25)
    Me.cboAlmacen.TabIndex = 1
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.AutoSize = True
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(4, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'gpBotones
    '
    Me.gpBotones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpBotones.Controls.Add(Me.picAjaxRes)
    Me.gpBotones.Controls.Add(Me.dgvListado)
    Me.gpBotones.Controls.Add(Me.ToolStrip1)
    Me.gpBotones.Location = New System.Drawing.Point(0, 93)
    Me.gpBotones.Name = "gpBotones"
    Me.gpBotones.Size = New System.Drawing.Size(698, 330)
    Me.gpBotones.TabIndex = 5
    '
    'picAjaxRes
    '
    Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
    Me.picAjaxRes.Location = New System.Drawing.Point(4, 55)
    Me.picAjaxRes.Name = "picAjaxRes"
    Me.picAjaxRes.Size = New System.Drawing.Size(688, 265)
    Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxRes.TabIndex = 86
    Me.picAjaxRes.TabStop = False
    Me.picAjaxRes.Visible = False
    '
    'dgvListado
    '
    Me.dgvListado.AllowDrop = True
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance19.BackColor = System.Drawing.Color.White
    Me.dgvListado.DisplayLayout.Appearance = Appearance19
    Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
    Appearance20.BackColor = System.Drawing.Color.Transparent
    Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance20
    Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance21.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
    Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance21.FontData.BoldAsString = "True"
    Appearance21.FontData.Name = "Arial"
    Appearance21.FontData.SizeInPoints = 10.0!
    Appearance21.ForeColor = System.Drawing.Color.White
    Appearance21.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance21
    Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Appearance22.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance22.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance22
    Appearance23.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance23.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance23
    Me.dgvListado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvListado.Location = New System.Drawing.Point(7, 35)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(681, 291)
    Me.dgvListado.TabIndex = 87
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackColor = System.Drawing.Color.White
    Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdActualizar, Me.ToolStripSeparator13, Me.tsdProductos, Me.ToolStripSeparator1, Me.tsbAjuste, Me.ToolStripSeparator2, Me.tsopReportes, Me.ToolStripSeparator11, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(6, 5)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    Me.ToolStrip1.Size = New System.Drawing.Size(507, 25)
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
    'tsdProductos
    '
    Me.tsdProductos.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsdProductos.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsdProductos.Name = "tsdProductos"
    Me.tsdProductos.Size = New System.Drawing.Size(120, 22)
    Me.tsdProductos.Text = "Registrar Traslado"
    Me.tsdProductos.ToolTipText = "Registrar Traslado"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsbAjuste
    '
    Me.tsbAjuste.Image = Global.Phoenix.My.Resources.Resources.ok
    Me.tsbAjuste.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsbAjuste.Name = "tsbAjuste"
    Me.tsbAjuste.Size = New System.Drawing.Size(109, 22)
    Me.tsbAjuste.Text = "Registrar Ajuste"
    Me.tsbAjuste.ToolTipText = "Registrar Salida como Ajuste"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsopReportes
    '
    Me.tsopReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDuplicado, Me.tsmDetalle})
    Me.tsopReportes.Image = Global.Phoenix.My.Resources.Resources.demo
    Me.tsopReportes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsopReportes.Name = "tsopReportes"
    Me.tsopReportes.Size = New System.Drawing.Size(82, 22)
    Me.tsopReportes.Text = "&Reportes"
    '
    'tsmDuplicado
    '
    Me.tsmDuplicado.BackColor = System.Drawing.Color.White
    Me.tsmDuplicado.Image = Global.Phoenix.My.Resources.Resources.printer
    Me.tsmDuplicado.Name = "tsmDuplicado"
    Me.tsmDuplicado.Size = New System.Drawing.Size(152, 22)
    Me.tsmDuplicado.Text = "Duplicado"
    '
    'tsmDetalle
    '
    Me.tsmDetalle.BackColor = System.Drawing.Color.White
    Me.tsmDetalle.Image = Global.Phoenix.My.Resources.Resources.fileprint
    Me.tsmDetalle.Name = "tsmDetalle"
    Me.tsmDetalle.Size = New System.Drawing.Size(152, 22)
    Me.tsmDetalle.Text = "Detalle"
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
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
    'bwLlenar_Res
    '
    '
    'lblRegistros_Res
    '
    Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance24.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance24.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance24.TextVAlignAsString = "Top"
    Me.lblRegistros_Res.Appearance = Appearance24
    Me.lblRegistros_Res.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblRegistros_Res.Location = New System.Drawing.Point(3, 429)
    Me.lblRegistros_Res.Name = "lblRegistros_Res"
    Me.lblRegistros_Res.Size = New System.Drawing.Size(170, 15)
    Me.lblRegistros_Res.TabIndex = 88
    Me.lblRegistros_Res.Text = "..."
    '
    'FrmSalida_traslado
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(698, 453)
    Me.Controls.Add(Me.lblRegistros_Res)
    Me.Controls.Add(Me.gpBotones)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MinimizeBox = False
    Me.Name = "FrmSalida_traslado"
    Me.Text = "Registro Salida Interna"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpPersona.ResumeLayout(False)
    Me.gpPersona.PerformLayout()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpBotones.ResumeLayout(False)
    Me.gpBotones.PerformLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents cboDocumento As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboHasta As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents gpBotones As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsdActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsopReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDuplicado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsdProductos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gpPersona As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents lblCondicion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents tsbAjuste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
