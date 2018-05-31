<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBonificacion
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBonificacion))
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboCondicion = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.picAjax = New System.Windows.Forms.PictureBox
        Me.lblCondicion = New Infragistics.Win.Misc.UltraLabel
        Me.cboUnidad_Negocio = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        Me.picAjaxBig = New System.Windows.Forms.PictureBox
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.TpCliente = New System.Windows.Forms.ToolStrip
        Me.tsActualizar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.TpNuevo = New System.Windows.Forms.ToolStripButton
        Me.TpModificar = New System.Windows.Forms.ToolStripButton
        Me.TpEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsReporte = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tpCerrar = New System.Windows.Forms.ToolStripButton
        Me.bwAlmacen = New System.ComponentModel.BackgroundWorker
        Me.bwLlenar_Detalle = New System.ComponentModel.BackgroundWorker
        Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterios.SuspendLayout()
        CType(Me.cboCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidad_Negocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpCriterios
        '
        Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
        Me.gpCriterios.ContentAreaAppearance = Appearance4
        Me.gpCriterios.Controls.Add(Me.cboCondicion)
        Me.gpCriterios.Controls.Add(Me.picAjax)
        Me.gpCriterios.Controls.Add(Me.lblCondicion)
        Me.gpCriterios.Controls.Add(Me.cboUnidad_Negocio)
        Me.gpCriterios.Controls.Add(Me.cboAlmacen)
        Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
        Me.gpCriterios.Location = New System.Drawing.Point(0, 0)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(743, 88)
        Me.gpCriterios.TabIndex = 2
        Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cboCondicion
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.cboCondicion.Appearance = Appearance8
        Me.cboCondicion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboCondicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance91.BackColor = System.Drawing.Color.White
        Me.cboCondicion.DisplayLayout.Appearance = Appearance91
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.cboCondicion.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BackColor = System.Drawing.Color.White
        Appearance93.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.Name = "Arial"
        Appearance93.FontData.SizeInPoints = 10.0!
        Appearance93.ForeColor = System.Drawing.Color.White
        Appearance93.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboCondicion.DisplayLayout.Override.HeaderAppearance = Appearance93
        Appearance94.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance94.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCondicion.DisplayLayout.Override.RowSelectorAppearance = Appearance94
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCondicion.DisplayLayout.Override.SelectedRowAppearance = Appearance95
        Me.cboCondicion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboCondicion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboCondicion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondicion.Location = New System.Drawing.Point(57, 57)
        Me.cboCondicion.Name = "cboCondicion"
        Me.cboCondicion.Size = New System.Drawing.Size(582, 25)
        Me.cboCondicion.TabIndex = 91
        '
        'picAjax
        '
        Me.picAjax.BackColor = System.Drawing.Color.Transparent
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(231, 23)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(165, 24)
        Me.picAjax.TabIndex = 83
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'lblCondicion
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance34.TextVAlignAsString = "Top"
        Me.lblCondicion.Appearance = Appearance34
        Me.lblCondicion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCondicion.Location = New System.Drawing.Point(57, 4)
        Me.lblCondicion.Name = "lblCondicion"
        Me.lblCondicion.Size = New System.Drawing.Size(621, 15)
        Me.lblCondicion.TabIndex = 31
        Me.lblCondicion.Text = "  Unidad de Negocio                       Almacén                                " & _
            "   "
        '
        'cboUnidad_Negocio
        '
        Appearance5.BackColor = System.Drawing.Color.LemonChiffon
        Me.cboUnidad_Negocio.Appearance = Appearance5
        Me.cboUnidad_Negocio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboUnidad_Negocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance6.BackColor = System.Drawing.Color.White
        Me.cboUnidad_Negocio.DisplayLayout.Appearance = Appearance6
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.cboUnidad_Negocio.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.FontData.Name = "Arial"
        Appearance13.FontData.SizeInPoints = 10.0!
        Appearance13.ForeColor = System.Drawing.Color.White
        Appearance13.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboUnidad_Negocio.DisplayLayout.Override.HeaderAppearance = Appearance13
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance25.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad_Negocio.DisplayLayout.Override.RowSelectorAppearance = Appearance25
        Appearance26.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad_Negocio.DisplayLayout.Override.SelectedRowAppearance = Appearance26
        Me.cboUnidad_Negocio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboUnidad_Negocio.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboUnidad_Negocio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidad_Negocio.Location = New System.Drawing.Point(57, 22)
        Me.cboUnidad_Negocio.Name = "cboUnidad_Negocio"
        Me.cboUnidad_Negocio.Size = New System.Drawing.Size(164, 25)
        Me.cboUnidad_Negocio.TabIndex = 0
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
        Me.cboAlmacen.Location = New System.Drawing.Point(229, 22)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(167, 25)
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
        Me.UltraPictureBox1.Size = New System.Drawing.Size(46, 47)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox1.Controls.Add(Me.lbl)
        Me.UltraGroupBox1.Controls.Add(Me.picAjaxBig)
        Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
        Me.UltraGroupBox1.Controls.Add(Me.TpCliente)
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.HeaderAppearance = Appearance1
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 90)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(743, 326)
        Me.UltraGroupBox1.TabIndex = 67
        '
        'lbl
        '
        Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.ForeColor = System.Drawing.Color.LightBlue
        Appearance14.TextVAlignAsString = "Top"
        Me.lbl.Appearance = Appearance14
        Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(12, 303)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(188, 17)
        Me.lbl.TabIndex = 86
        Me.lbl.Text = "0 registros"
        '
        'picAjaxBig
        '
        Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
        Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
        Me.picAjaxBig.Location = New System.Drawing.Point(11, 31)
        Me.picAjaxBig.Name = "picAjaxBig"
        Me.picAjaxBig.Size = New System.Drawing.Size(719, 263)
        Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAjaxBig.TabIndex = 85
        Me.picAjaxBig.TabStop = False
        Me.picAjaxBig.Visible = False
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Me.dgvListado.DisplayLayout.Appearance = Appearance3
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvListado.Location = New System.Drawing.Point(6, 30)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(730, 269)
        Me.dgvListado.TabIndex = 22
        Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
        '
        'TpCliente
        '
        Me.TpCliente.BackColor = System.Drawing.Color.White
        Me.TpCliente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TpCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator4, Me.TpNuevo, Me.TpModificar, Me.TpEliminar, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.tsReporte, Me.ToolStripSeparator3, Me.tpCerrar})
        Me.TpCliente.Location = New System.Drawing.Point(3, 3)
        Me.TpCliente.Name = "TpCliente"
        Me.TpCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TpCliente.Size = New System.Drawing.Size(737, 25)
        Me.TpCliente.TabIndex = 21
        Me.TpCliente.Text = "ToolStrip2"
        '
        'tsActualizar
        '
        Me.tsActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
        Me.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsActualizar.Name = "tsActualizar"
        Me.tsActualizar.Size = New System.Drawing.Size(79, 22)
        Me.tsActualizar.Text = "&Actualizar"
        Me.tsActualizar.ToolTipText = "Mostrar Productos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TpNuevo
        '
        Me.TpNuevo.Image = CType(resources.GetObject("TpNuevo.Image"), System.Drawing.Image)
        Me.TpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpNuevo.Name = "TpNuevo"
        Me.TpNuevo.Size = New System.Drawing.Size(62, 22)
        Me.TpNuevo.Text = "&Nuevo"
        Me.TpNuevo.ToolTipText = "Nuevo"
        '
        'TpModificar
        '
        Me.TpModificar.Image = CType(resources.GetObject("TpModificar.Image"), System.Drawing.Image)
        Me.TpModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpModificar.Name = "TpModificar"
        Me.TpModificar.Size = New System.Drawing.Size(78, 22)
        Me.TpModificar.Text = "&Modificar"
        Me.TpModificar.ToolTipText = "Modificar"
        '
        'TpEliminar
        '
        Me.TpEliminar.Image = CType(resources.GetObject("TpEliminar.Image"), System.Drawing.Image)
        Me.TpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpEliminar.Name = "TpEliminar"
        Me.TpEliminar.Size = New System.Drawing.Size(70, 22)
        Me.TpEliminar.Text = "&Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsReporte
        '
        Me.tsReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReporte.Name = "tsReporte"
        Me.tsReporte.Size = New System.Drawing.Size(52, 22)
        Me.tsReporte.Text = "Reporte"
        Me.tsReporte.ToolTipText = "Listado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tpCerrar
        '
        Me.tpCerrar.Image = CType(resources.GetObject("tpCerrar.Image"), System.Drawing.Image)
        Me.tpCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tpCerrar.Name = "tpCerrar"
        Me.tpCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tpCerrar.Text = "Cerrar"
        '
        'bwAlmacen
        '
        '
        'bwLlenar_Detalle
        '
        '
        'FrmBonificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(742, 418)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.gpCriterios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FrmBonificacion"
        Me.Text = "Bonificación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterios.ResumeLayout(False)
        Me.gpCriterios.PerformLayout()
        CType(Me.cboCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidad_Negocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpCliente.ResumeLayout(False)
        Me.TpCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents lblCondicion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboUnidad_Negocio As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TpCliente As System.Windows.Forms.ToolStrip
    Friend WithEvents tsActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TpNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TpModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TpEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tpCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboCondicion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Detalle As System.ComponentModel.BackgroundWorker
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
