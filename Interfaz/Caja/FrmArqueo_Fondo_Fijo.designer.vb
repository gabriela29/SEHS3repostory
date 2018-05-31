<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArqueo_Fondo_Fijo
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
        Dim tsDReporte As System.Windows.Forms.ToolStripButton
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArqueo_Fondo_Fijo))
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblRegistros = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.CboFecha2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.CboFecha1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.LblNombre = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsDNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsDCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bwUsuario = New System.ComponentModel.BackgroundWorker()
        Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
        Me.lblCodigo = New Infragistics.Win.Misc.UltraLabel()
        tsDReporte = New System.Windows.Forms.ToolStripButton()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.CboFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsDReporte
        '
        tsDReporte.Image = Global.Phoenix.My.Resources.Resources.demo
        tsDReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        tsDReporte.Name = "tsDReporte"
        tsDReporte.Size = New System.Drawing.Size(68, 22)
        tsDReporte.Text = "&Reporte"
        AddHandler tsDReporte.Click, AddressOf Me.tsDReporte_Click
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Moccasin
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance3
        Me.UltraGroupBox4.Controls.Add(Me.LblRegistros)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Controls.Add(Me.cboAlmacen)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(-1, -1)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(719, 52)
        Me.UltraGroupBox4.TabIndex = 1
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'LblRegistros
        '
        Appearance46.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance46.ForeColor = System.Drawing.Color.LightSteelBlue
        Appearance46.TextHAlignAsString = "Right"
        Appearance46.TextVAlignAsString = "Middle"
        Me.LblRegistros.Appearance = Appearance46
        Me.LblRegistros.Location = New System.Drawing.Point(466, 6)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(250, 14)
        Me.LblRegistros.TabIndex = 79
        Me.LblRegistros.Text = "-"
        '
        'UltraLabel12
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance8.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance8
        Me.UltraLabel12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(84, 4)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(251, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Control de Arqueos... (Fondo Fijo)."
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance91.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.DisplayLayout.Appearance = Appearance91
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BackColor = System.Drawing.Color.White
        Appearance93.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.Name = "Arial"
        Appearance93.FontData.SizeInPoints = 10.0!
        Appearance93.ForeColor = System.Drawing.Color.White
        Appearance93.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance93
        Appearance94.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance94.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance94
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance95
        Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(84, 23)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(232, 22)
        Me.cboAlmacen.TabIndex = 0
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance22.BackColor = System.Drawing.Color.DarkOrange
        Appearance22.BackColor2 = System.Drawing.Color.NavajoWhite
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance22
        Me.UltraGroupBox1.Controls.Add(Me.lblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.BtnBuscar)
        Me.UltraGroupBox1.Controls.Add(Me.CboFecha2)
        Me.UltraGroupBox1.Controls.Add(Me.CboFecha1)
        Me.UltraGroupBox1.Controls.Add(Me.LblNombre)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 50)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(719, 74)
        Me.UltraGroupBox1.TabIndex = 2
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel1
        '
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance2.ForeColor = System.Drawing.Color.White
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 10)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(63, 15)
        Me.UltraLabel1.TabIndex = 86
        Me.UltraLabel1.Text = "DNI:"
        '
        'BtnBuscar
        '
        Appearance27.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance27.ForeColor = System.Drawing.Color.White
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Me.BtnBuscar.Appearance = Appearance27
        Me.BtnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnBuscar.Font = New System.Drawing.Font("Elephant", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(343, 10)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(142, 35)
        Me.BtnBuscar.TabIndex = 84
        Me.BtnBuscar.Text = "&BUSCAR"
        Me.BtnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'CboFecha2
        '
        Appearance72.FontData.Name = "Tahoma"
        Appearance72.FontData.SizeInPoints = 10.0!
        Me.CboFecha2.Appearance = Appearance72
        Me.CboFecha2.BackColor = System.Drawing.SystemColors.Window
        Me.CboFecha2.DateButtons.Add(DateButton1)
        Me.CboFecha2.Location = New System.Drawing.Point(218, 35)
        Me.CboFecha2.Name = "CboFecha2"
        Me.CboFecha2.NonAutoSizeHeight = 21
        Me.CboFecha2.Size = New System.Drawing.Size(98, 22)
        Me.CboFecha2.TabIndex = 3
        Me.CboFecha2.Value = "20/09/2009"
        '
        'CboFecha1
        '
        Appearance23.FontData.Name = "Tahoma"
        Appearance23.FontData.SizeInPoints = 10.0!
        Me.CboFecha1.Appearance = Appearance23
        Me.CboFecha1.BackColor = System.Drawing.SystemColors.Window
        Me.CboFecha1.DateButtons.Add(DateButton2)
        Me.CboFecha1.Location = New System.Drawing.Point(75, 35)
        Me.CboFecha1.Name = "CboFecha1"
        Me.CboFecha1.NonAutoSizeHeight = 21
        Me.CboFecha1.Size = New System.Drawing.Size(98, 22)
        Me.CboFecha1.TabIndex = 2
        Me.CboFecha1.Value = "20/09/2009"
        '
        'LblNombre
        '
        Appearance17.BackColor = System.Drawing.Color.LemonChiffon
        Appearance17.BackColor2 = System.Drawing.Color.White
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.Color.MidnightBlue
        Appearance17.TextVAlignAsString = "Middle"
        Me.LblNombre.Appearance = Appearance17
        Me.LblNombre.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Rounded3
        Me.LblNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.Location = New System.Drawing.Point(75, 6)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(241, 23)
        Me.LblNombre.TabIndex = 38
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox2.Controls.Add(Me.ToolStrip1)
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox2.HeaderAppearance = Appearance1
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(2, 124)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(717, 31)
        Me.UltraGroupBox2.TabIndex = 67
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDNuevo, Me.tsDCerrar, Me.ToolStripSeparator3, tsDReporte, Me.ToolStripSeparator2, Me.tsDDelete, Me.ToolStripSeparator1, Me.tsCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(711, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'tsDNuevo
        '
        Me.tsDNuevo.Image = CType(resources.GetObject("tsDNuevo.Image"), System.Drawing.Image)
        Me.tsDNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDNuevo.Name = "tsDNuevo"
        Me.tsDNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsDNuevo.Text = "&Nuevo"
        Me.tsDNuevo.ToolTipText = "Nuevo"
        '
        'tsDCerrar
        '
        Me.tsDCerrar.Image = Global.Phoenix.My.Resources.Resources.lock
        Me.tsDCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDCerrar.Name = "tsDCerrar"
        Me.tsDCerrar.Size = New System.Drawing.Size(70, 22)
        Me.tsDCerrar.Text = "&CERRAR"
        Me.tsDCerrar.ToolTipText = "Cerrar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsDDelete
        '
        Me.tsDDelete.Image = CType(resources.GetObject("tsDDelete.Image"), System.Drawing.Image)
        Me.tsDDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDDelete.Name = "tsDDelete"
        Me.tsDDelete.Size = New System.Drawing.Size(70, 22)
        Me.tsDDelete.Text = "&Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsCerrar
        '
        Me.tsCerrar.Image = CType(resources.GetObject("tsCerrar.Image"), System.Drawing.Image)
        Me.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCerrar.Name = "tsCerrar"
        Me.tsCerrar.Size = New System.Drawing.Size(49, 22)
        Me.tsCerrar.Text = "Salir"
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.TextHAlignAsString = "Center"
        Me.dgvListado.DisplayLayout.CaptionAppearance = Appearance5
        Me.dgvListado.Location = New System.Drawing.Point(4, 155)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(714, 278)
        Me.dgvListado.TabIndex = 66
        '
        'lblCodigo
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.White
        Appearance34.TextHAlignAsString = "Right"
        Appearance34.TextVAlignAsString = "Top"
        Me.lblCodigo.Appearance = Appearance34
        Me.lblCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.Location = New System.Drawing.Point(6, 38)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(63, 15)
        Me.lblCodigo.TabIndex = 87
        '
        'FrmArqueo_Fondo_Fijo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(717, 433)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmArqueo_Fondo_Fijo"
        Me.Text = "Control de Arqueos Fondo FIJO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.CboFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CboFecha1 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents LblNombre As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CboFecha2 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bwUsuario As System.ComponentModel.BackgroundWorker
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblCodigo As Infragistics.Win.Misc.UltraLabel
End Class
