<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturacion_Consignacion
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
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturacion_Consignacion))
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
        Me.gpPersona = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblCondicion = New Infragistics.Win.Misc.UltraLabel()
        Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.cboHasta = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.gpBotones = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel()
        Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
        Me.picAjaxRes = New System.Windows.Forms.PictureBox()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsdActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsNotaCredito = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsopReportes = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmDuplicado = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAdjunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
        Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
        Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterios.SuspendLayout()
        CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpPersona.SuspendLayout()
        CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBotones.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
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
        Me.gpCriterios.Controls.Add(Me.gpPersona)
        Me.gpCriterios.Controls.Add(Me.BtnMostrar)
        Me.gpCriterios.Controls.Add(Me.UltraLabel12)
        Me.gpCriterios.Controls.Add(Me.cboAlmacen)
        Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
        Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(716, 97)
        Me.gpCriterios.TabIndex = 2
        Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'gpPersona
        '
        Me.gpPersona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance22.BackColor = System.Drawing.Color.White
        Appearance22.BackColor2 = System.Drawing.Color.White
        Me.gpPersona.ContentAreaAppearance = Appearance22
        Me.gpPersona.Controls.Add(Me.lblCondicion)
        Me.gpPersona.Controls.Add(Me.cboDesde)
        Me.gpPersona.Controls.Add(Me.cboHasta)
        Me.gpPersona.Location = New System.Drawing.Point(38, 54)
        Me.gpPersona.Name = "gpPersona"
        Me.gpPersona.Size = New System.Drawing.Size(640, 34)
        Me.gpPersona.TabIndex = 90
        Me.gpPersona.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblCondicion
        '
        Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance17.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance17.TextVAlignAsString = "Top"
        Me.lblCondicion.Appearance = Appearance17
        Me.lblCondicion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCondicion.Location = New System.Drawing.Point(9, 10)
        Me.lblCondicion.Name = "lblCondicion"
        Me.lblCondicion.Size = New System.Drawing.Size(170, 15)
        Me.lblCondicion.TabIndex = 32
        Me.lblCondicion.Text = "Buscar por Fechas"
        '
        'cboDesde
        '
        Appearance72.FontData.BoldAsString = "True"
        Appearance72.FontData.Name = "Tahoma"
        Appearance72.FontData.SizeInPoints = 10.0!
        Me.cboDesde.Appearance = Appearance72
        Me.cboDesde.BackColor = System.Drawing.SystemColors.Window
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
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Tahoma"
        Appearance9.FontData.SizeInPoints = 10.0!
        Me.cboHasta.Appearance = Appearance9
        Me.cboHasta.BackColor = System.Drawing.SystemColors.Window
        Me.cboHasta.DateButtons.Add(DateButton2)
        Me.cboHasta.Location = New System.Drawing.Point(380, 6)
        Me.cboHasta.Name = "cboHasta"
        Me.cboHasta.NonAutoSizeHeight = 21
        Me.cboHasta.Size = New System.Drawing.Size(116, 22)
        Me.cboHasta.TabIndex = 3
        Me.cboHasta.Value = "20/09/2009"
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
        Me.BtnMostrar.FlatAppearance.BorderSize = 0
        Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
        Me.BtnMostrar.Location = New System.Drawing.Point(318, 8)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
        Me.BtnMostrar.TabIndex = 89
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'UltraLabel12
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance34.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance34
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(57, 4)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(497, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "    Almacén                                            "
        '
        'cboAlmacen
        '
        Appearance10.BackColor = System.Drawing.Color.LemonChiffon
        Appearance10.BackColor2 = System.Drawing.Color.White
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
        Me.cboAlmacen.Appearance = Appearance10
        Me.cboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance2.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.DisplayLayout.Appearance = Appearance2
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.FontData.BoldAsString = "True"
        Appearance19.FontData.Name = "Arial"
        Appearance19.FontData.SizeInPoints = 10.0!
        Appearance19.ForeColor = System.Drawing.Color.White
        Appearance19.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance21.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance21
        Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(58, 23)
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
        Me.gpBotones.Controls.Add(Me.UltraGroupBox3)
        Me.gpBotones.Controls.Add(Me.ToolStrip1)
        Me.gpBotones.Location = New System.Drawing.Point(-1, 98)
        Me.gpBotones.Name = "gpBotones"
        Me.gpBotones.Size = New System.Drawing.Size(715, 339)
        Me.gpBotones.TabIndex = 5
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Appearance25.BackColor = System.Drawing.Color.White
        Appearance25.BackColor2 = System.Drawing.Color.White
        Me.UltraGroupBox3.ContentAreaAppearance = Appearance25
        Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
        Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
        Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
        Me.UltraGroupBox3.Controls.Add(Me.dgvListado)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(6, 28)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(705, 307)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'LblDeudaTotal
        '
        Me.LblDeudaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance29.BackColor = System.Drawing.Color.LemonChiffon
        Appearance29.BackColor2 = System.Drawing.Color.White
        Appearance29.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
        Appearance29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance29.TextHAlignAsString = "Right"
        Appearance29.TextVAlignAsString = "Middle"
        Me.LblDeudaTotal.Appearance = Appearance29
        Me.LblDeudaTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblDeudaTotal.Location = New System.Drawing.Point(440, 283)
        Me.LblDeudaTotal.Name = "LblDeudaTotal"
        Me.LblDeudaTotal.Size = New System.Drawing.Size(145, 17)
        Me.LblDeudaTotal.TabIndex = 87
        Me.LblDeudaTotal.Text = "0.00"
        '
        'lblRegistros_Res
        '
        Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance46.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance46.ForeColor = System.Drawing.Color.LightSteelBlue
        Appearance46.TextHAlignAsString = "Right"
        Appearance46.TextVAlignAsString = "Middle"
        Me.lblRegistros_Res.Appearance = Appearance46
        Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 284)
        Me.lblRegistros_Res.Name = "lblRegistros_Res"
        Me.lblRegistros_Res.Size = New System.Drawing.Size(107, 14)
        Me.lblRegistros_Res.TabIndex = 86
        Me.lblRegistros_Res.Text = "-"
        '
        'picAjaxRes
        '
        Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
        Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
        Me.picAjaxRes.Location = New System.Drawing.Point(9, 9)
        Me.picAjaxRes.Name = "picAjaxRes"
        Me.picAjaxRes.Size = New System.Drawing.Size(688, 264)
        Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAjaxRes.TabIndex = 84
        Me.picAjaxRes.TabStop = False
        Me.picAjaxRes.Visible = False
        '
        'dgvListado
        '
        Me.dgvListado.AllowDrop = True
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Me.dgvListado.DisplayLayout.Appearance = Appearance3
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance5
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance7
        Me.dgvListado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvListado.Location = New System.Drawing.Point(6, 4)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(691, 273)
        Me.dgvListado.TabIndex = 85
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdActualizar, Me.ToolStripSeparator13, Me.tsDNuevo, Me.ToolStripSeparator3, Me.tsNotaCredito, Me.ToolStripSeparator2, Me.tsopReportes, Me.ToolStripSeparator11, Me.tsDSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(458, 25)
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
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsNotaCredito
        '
        Me.tsNotaCredito.Image = Global.Phoenix.My.Resources.Resources.agt_reload16
        Me.tsNotaCredito.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNotaCredito.Name = "tsNotaCredito"
        Me.tsNotaCredito.Size = New System.Drawing.Size(111, 22)
        Me.tsNotaCredito.Text = "Nota de Crédito"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsopReportes
        '
        Me.tsopReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDuplicado, Me.tsmAdjunto, Me.ToolStripSeparator4, Me.ToolStripMenuItem1})
        Me.tsopReportes.Image = Global.Phoenix.My.Resources.Resources.printer
        Me.tsopReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsopReportes.Name = "tsopReportes"
        Me.tsopReportes.Size = New System.Drawing.Size(82, 22)
        Me.tsopReportes.Text = "&Reportes"
        '
        'tsmDuplicado
        '
        Me.tsmDuplicado.BackColor = System.Drawing.Color.White
        Me.tsmDuplicado.Name = "tsmDuplicado"
        Me.tsmDuplicado.Size = New System.Drawing.Size(160, 22)
        Me.tsmDuplicado.Text = "Duplicado"
        '
        'tsmAdjunto
        '
        Me.tsmAdjunto.BackColor = System.Drawing.Color.White
        Me.tsmAdjunto.Name = "tsmAdjunto"
        Me.tsmAdjunto.Size = New System.Drawing.Size(160, 22)
        Me.tsmAdjunto.Text = "Duplica Adjunto"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.BackColor = System.Drawing.Color.White
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(157, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem1.Text = "Saldo Facturado"
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
        'bwAlmacen
        '
        '
        'bwLlenar_Res
        '
        '
        'FrmFacturacion_Consignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(714, 436)
        Me.Controls.Add(Me.gpBotones)
        Me.Controls.Add(Me.gpCriterios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmFacturacion_Consignacion"
        Me.Text = "Boleteo Consignación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterios.ResumeLayout(False)
        Me.gpCriterios.PerformLayout()
        CType(Me.gpPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpPersona.ResumeLayout(False)
        Me.gpPersona.PerformLayout()
        CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBotones.ResumeLayout(False)
        Me.gpBotones.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents gpBotones As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsdActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsopReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmDuplicado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAdjunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpPersona As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCondicion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents cboHasta As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents tsNotaCredito As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
