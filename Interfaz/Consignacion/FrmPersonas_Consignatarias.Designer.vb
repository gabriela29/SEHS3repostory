<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersonas_Consignatarias
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPersonas_Consignatarias))
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox
        Me.BtnMostrar = New System.Windows.Forms.Button
        Me.picAjax = New System.Windows.Forms.PictureBox
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.cboUnidad_Negocio = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.picAjaxRes = New System.Windows.Forms.PictureBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsdAddAsistente = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.tsQuitarAsistente = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.tsDSalir = New System.Windows.Forms.ToolStripButton
        Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel
        Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel
        Me.dgvResumen = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker
        Me.bwAlmacen = New System.ComponentModel.BackgroundWorker
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterios.SuspendLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidad_Negocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpCriterios
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
        Me.gpCriterios.ContentAreaAppearance = Appearance1
        Me.gpCriterios.Controls.Add(Me.BtnMostrar)
        Me.gpCriterios.Controls.Add(Me.picAjax)
        Me.gpCriterios.Controls.Add(Me.UltraLabel12)
        Me.gpCriterios.Controls.Add(Me.cboUnidad_Negocio)
        Me.gpCriterios.Controls.Add(Me.cboAlmacen)
        Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
        Me.gpCriterios.Location = New System.Drawing.Point(-2, -1)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(547, 68)
        Me.gpCriterios.TabIndex = 3
        Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
        Me.BtnMostrar.FlatAppearance.BorderSize = 0
        Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
        Me.BtnMostrar.Location = New System.Drawing.Point(389, 13)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
        Me.BtnMostrar.TabIndex = 89
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'picAjax
        '
        Me.picAjax.BackColor = System.Drawing.Color.Transparent
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(209, 25)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(174, 23)
        Me.picAjax.TabIndex = 83
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'UltraLabel12
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance34.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance34
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(61, 9)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(345, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "  Unidad de Negocio                 Almacén                                      " & _
            "    "
        '
        'cboUnidad_Negocio
        '
        Appearance8.BackColor = System.Drawing.Color.LemonChiffon
        Me.cboUnidad_Negocio.Appearance = Appearance8
        Me.cboUnidad_Negocio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboUnidad_Negocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance91.BackColor = System.Drawing.Color.White
        Me.cboUnidad_Negocio.DisplayLayout.Appearance = Appearance91
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.cboUnidad_Negocio.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BackColor = System.Drawing.Color.White
        Appearance93.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.Name = "Arial"
        Appearance93.FontData.SizeInPoints = 10.0!
        Appearance93.ForeColor = System.Drawing.Color.White
        Appearance93.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboUnidad_Negocio.DisplayLayout.Override.HeaderAppearance = Appearance93
        Appearance94.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance94.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad_Negocio.DisplayLayout.Override.RowSelectorAppearance = Appearance94
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad_Negocio.DisplayLayout.Override.SelectedRowAppearance = Appearance95
        Me.cboUnidad_Negocio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboUnidad_Negocio.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboUnidad_Negocio.Location = New System.Drawing.Point(61, 27)
        Me.cboUnidad_Negocio.Name = "cboUnidad_Negocio"
        Me.cboUnidad_Negocio.Size = New System.Drawing.Size(142, 22)
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
        Me.cboAlmacen.Location = New System.Drawing.Point(209, 27)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(174, 22)
        Me.cboAlmacen.TabIndex = 1
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(7, 7)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(47, 42)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColor2 = System.Drawing.Color.White
        Me.UltraGroupBox3.ContentAreaAppearance = Appearance9
        Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
        Me.UltraGroupBox3.Controls.Add(Me.ToolStrip1)
        Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
        Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
        Me.UltraGroupBox3.Controls.Add(Me.dgvResumen)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(-2, 67)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(547, 337)
        Me.UltraGroupBox3.TabIndex = 7
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'picAjaxRes
        '
        Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
        Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
        Me.picAjaxRes.Location = New System.Drawing.Point(3, 30)
        Me.picAjaxRes.Name = "picAjaxRes"
        Me.picAjaxRes.Size = New System.Drawing.Size(540, 271)
        Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAjaxRes.TabIndex = 84
        Me.picAjaxRes.TabStop = False
        Me.picAjaxRes.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdAddAsistente, Me.ToolStripSeparator13, Me.tsQuitarAsistente, Me.ToolStripSeparator9, Me.ToolStripSeparator11, Me.tsDSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(541, 25)
        Me.ToolStrip1.TabIndex = 88
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'tsdAddAsistente
        '
        Me.tsdAddAsistente.Image = Global.Phoenix.My.Resources.Resources.add_user
        Me.tsdAddAsistente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdAddAsistente.Name = "tsdAddAsistente"
        Me.tsdAddAsistente.Size = New System.Drawing.Size(69, 22)
        Me.tsdAddAsistente.Text = "&Agregar"
        Me.tsdAddAsistente.ToolTipText = "Agregar Asistente"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'tsQuitarAsistente
        '
        Me.tsQuitarAsistente.Image = Global.Phoenix.My.Resources.Resources.img_anulado
        Me.tsQuitarAsistente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsQuitarAsistente.Name = "tsQuitarAsistente"
        Me.tsQuitarAsistente.Size = New System.Drawing.Size(60, 22)
        Me.tsQuitarAsistente.Text = "&Quitar"
        Me.tsQuitarAsistente.ToolTipText = "Quita el Asistente de la Lista"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
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
        Me.LblDeudaTotal.Location = New System.Drawing.Point(371, 313)
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
        Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 314)
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
        Appearance3.BackColor = System.Drawing.Color.White
        Me.dgvResumen.DisplayLayout.Appearance = Appearance3
        Me.dgvResumen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvResumen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.dgvResumen.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Me.dgvResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvResumen.DisplayLayout.Override.HeaderAppearance = Appearance5
        Me.dgvResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvResumen.DisplayLayout.Override.RowSelectorAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvResumen.DisplayLayout.Override.SelectedRowAppearance = Appearance7
        Me.dgvResumen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvResumen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvResumen.Location = New System.Drawing.Point(6, 28)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.Size = New System.Drawing.Size(533, 279)
        Me.dgvResumen.TabIndex = 85
        '
        'FrmPersonas_Consignatarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(544, 405)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.gpCriterios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FrmPersonas_Consignatarias"
        Me.ShowInTaskbar = False
        Me.Text = "Personas Consignatarias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterios.ResumeLayout(False)
        Me.gpCriterios.PerformLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidad_Negocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboUnidad_Negocio As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsdAddAsistente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsQuitarAsistente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvResumen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
End Class
