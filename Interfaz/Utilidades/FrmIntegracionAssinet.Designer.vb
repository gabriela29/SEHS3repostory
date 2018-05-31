<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIntegracionAssinet
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
    Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIntegracionAssinet))
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
    Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
    Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.uTabControl = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
    Me.TxtRequest = New System.Windows.Forms.RichTextBox()
    Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
    Me.txtResult = New System.Windows.Forms.RichTextBox()
    Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
    Me.lbl = New Infragistics.Win.Misc.UltraLabel()
    Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsExcel = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsGrabar = New System.Windows.Forms.ToolStripButton()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.LblRegistros = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.cboEntidad = New System.Windows.Forms.ComboBox()
    Me.cboOpciones = New System.Windows.Forms.ComboBox()
    Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.utTab = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
    Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
    Me.btnTransferir = New Infragistics.Win.Misc.UltraButton()
    Me.utExcel = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
    Me.txtServicio = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.lblServicio = New Infragistics.Win.Misc.UltraLabel()
    Me.txtEntidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.cboFecha = New System.Windows.Forms.DateTimePicker()
    Me.lblFecha = New Infragistics.Win.Misc.UltraLabel()
    Me.txtAnio = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.lblAnio = New Infragistics.Win.Misc.UltraLabel()
    Me.uTabControl.SuspendLayout()
    Me.UltraTabPageControl2.SuspendLayout()
    Me.UltraTabPageControl3.SuspendLayout()
    Me.ToolStrip2.SuspendLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox4.SuspendLayout()
    CType(Me.utTab, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.utTab.SuspendLayout()
    CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'uTabControl
    '
    Me.uTabControl.Controls.Add(Me.TxtRequest)
    Me.uTabControl.Location = New System.Drawing.Point(1, 22)
    Me.uTabControl.Name = "uTabControl"
    Me.uTabControl.Size = New System.Drawing.Size(739, 237)
    '
    'TxtRequest
    '
    Me.TxtRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TxtRequest.Location = New System.Drawing.Point(3, 9)
    Me.TxtRequest.Name = "TxtRequest"
    Me.TxtRequest.Size = New System.Drawing.Size(725, 224)
    Me.TxtRequest.TabIndex = 2
    Me.TxtRequest.Text = ""
    '
    'UltraTabPageControl2
    '
    Me.UltraTabPageControl2.Controls.Add(Me.txtResult)
    Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
    Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
    Me.UltraTabPageControl2.Size = New System.Drawing.Size(739, 237)
    '
    'txtResult
    '
    Me.txtResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtResult.Location = New System.Drawing.Point(3, 5)
    Me.txtResult.Name = "txtResult"
    Me.txtResult.Size = New System.Drawing.Size(733, 256)
    Me.txtResult.TabIndex = 3
    Me.txtResult.Text = ""
    '
    'UltraTabPageControl3
    '
    Me.UltraTabPageControl3.Controls.Add(Me.lbl)
    Me.UltraTabPageControl3.Controls.Add(Me.ToolStrip2)
    Me.UltraTabPageControl3.Controls.Add(Me.dgvListado)
    Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
    Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
    Me.UltraTabPageControl3.Size = New System.Drawing.Size(739, 237)
    '
    'lbl
    '
    Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance1.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance1.TextVAlignAsString = "Middle"
    Me.lbl.Appearance = Appearance1
    Me.lbl.Location = New System.Drawing.Point(7, 245)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(118, 14)
    Me.lbl.TabIndex = 93
    Me.lbl.Text = "-"
    '
    'ToolStrip2
    '
    Me.ToolStrip2.BackColor = System.Drawing.Color.White
    Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.tsExcel, Me.ToolStripSeparator1, Me.tsGrabar})
    Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip2.Name = "ToolStrip2"
    Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip2.Size = New System.Drawing.Size(739, 25)
    Me.ToolStrip2.TabIndex = 92
    Me.ToolStrip2.Text = "ToolStrip2"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsExcel
    '
    Me.tsExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsExcel.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsExcel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsExcel.Name = "tsExcel"
    Me.tsExcel.Size = New System.Drawing.Size(23, 22)
    Me.tsExcel.Text = "Excel"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsGrabar
    '
    Me.tsGrabar.Image = Global.Phoenix.My.Resources.Resources.minidisk
    Me.tsGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsGrabar.Name = "tsGrabar"
    Me.tsGrabar.Size = New System.Drawing.Size(62, 22)
    Me.tsGrabar.Text = "&Grabar"
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
    Me.dgvListado.Location = New System.Drawing.Point(4, 28)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(731, 214)
    Me.dgvListado.TabIndex = 18
    Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    '
    'UltraGroupBox4
    '
    Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance2.BackColor = System.Drawing.Color.White
    Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
    Me.UltraGroupBox4.ContentAreaAppearance = Appearance2
    Me.UltraGroupBox4.Controls.Add(Me.LblRegistros)
    Me.UltraGroupBox4.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
    Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
    Me.UltraGroupBox4.Location = New System.Drawing.Point(0, -1)
    Me.UltraGroupBox4.Name = "UltraGroupBox4"
    Me.UltraGroupBox4.Size = New System.Drawing.Size(753, 52)
    Me.UltraGroupBox4.TabIndex = 3
    Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'LblRegistros
    '
    Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance3.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance3.TextHAlignAsString = "Right"
    Appearance3.TextVAlignAsString = "Middle"
    Me.LblRegistros.Appearance = Appearance3
    Me.LblRegistros.Location = New System.Drawing.Point(470, 4)
    Me.LblRegistros.Name = "LblRegistros"
    Me.LblRegistros.Size = New System.Drawing.Size(167, 14)
    Me.LblRegistros.TabIndex = 79
    Me.LblRegistros.Text = "-"
    '
    'UltraLabel1
    '
    Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance4.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance4.TextVAlignAsString = "Top"
    Me.UltraLabel1.Appearance = Appearance4
    Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!)
    Me.UltraLabel1.Location = New System.Drawing.Point(84, 27)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(458, 15)
    Me.UltraLabel1.TabIndex = 44
    Me.UltraLabel1.Text = "Seleccione las opciones que requiera obtener por Entidad"
    '
    'UltraLabel12
    '
    Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance5.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance5.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance5
    Me.UltraLabel12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(84, 6)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(251, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "Obtener datos de ASSINET"
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(6, 4)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(72, 43)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'cboEntidad
    '
    Me.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboEntidad.FormattingEnabled = True
    Me.cboEntidad.Items.AddRange(New Object() {"SEHS", "APCS", "MPS", "MSOP", "MLT", "MOP", "MAC", "NORTE", "MEN", "MES", "UU", "MMOP"})
    Me.cboEntidad.Location = New System.Drawing.Point(171, 57)
    Me.cboEntidad.Name = "cboEntidad"
    Me.cboEntidad.Size = New System.Drawing.Size(288, 21)
    Me.cboEntidad.TabIndex = 14
    '
    'cboOpciones
    '
    Me.cboOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboOpciones.FormattingEnabled = True
    Me.cboOpciones.Items.AddRange(New Object() {"Tipo Monedas", "Plan de Cuentas", "Plan de Cuentas Auxiliar", "Sub Cuentas", "Otros"})
    Me.cboOpciones.Location = New System.Drawing.Point(119, 83)
    Me.cboOpciones.Name = "cboOpciones"
    Me.cboOpciones.Size = New System.Drawing.Size(340, 21)
    Me.cboOpciones.TabIndex = 13
    '
    'UltraLabel2
    '
    Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance6.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance6.TextVAlignAsString = "Top"
    Me.UltraLabel2.Appearance = Appearance6
    Me.UltraLabel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel2.Location = New System.Drawing.Point(12, 59)
    Me.UltraLabel2.Name = "UltraLabel2"
    Me.UltraLabel2.Size = New System.Drawing.Size(101, 15)
    Me.UltraLabel2.TabIndex = 32
    Me.UltraLabel2.Text = "Entidad"
    '
    'UltraLabel3
    '
    Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance7.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance7.TextVAlignAsString = "Top"
    Me.UltraLabel3.Appearance = Appearance7
    Me.UltraLabel3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel3.Location = New System.Drawing.Point(12, 85)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(101, 15)
    Me.UltraLabel3.TabIndex = 33
    Me.UltraLabel3.Text = "Operación"
    '
    'utTab
    '
    Me.utTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.utTab.Controls.Add(Me.UltraTabSharedControlsPage1)
    Me.utTab.Controls.Add(Me.uTabControl)
    Me.utTab.Controls.Add(Me.UltraTabPageControl2)
    Me.utTab.Controls.Add(Me.UltraTabPageControl3)
    Me.utTab.Location = New System.Drawing.Point(12, 157)
    Me.utTab.Name = "utTab"
    Me.utTab.SharedControlsPage = Me.UltraTabSharedControlsPage1
    Me.utTab.Size = New System.Drawing.Size(741, 260)
    Me.utTab.TabIndex = 34
    UltraTab1.TabPage = Me.uTabControl
    UltraTab1.Text = "Consulta"
    UltraTab2.TabPage = Me.UltraTabPageControl2
    UltraTab2.Text = "Respuesta"
    UltraTab3.TabPage = Me.UltraTabPageControl3
    UltraTab3.Text = "Data"
    Me.utTab.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
    Me.utTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
    '
    'UltraTabSharedControlsPage1
    '
    Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
    Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
    Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(739, 237)
    '
    'btnTransferir
    '
    Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance8.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
    Me.btnTransferir.Appearance = Appearance8
    Me.btnTransferir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnTransferir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnTransferir.ImageSize = New System.Drawing.Size(32, 32)
    Me.btnTransferir.Location = New System.Drawing.Point(474, 59)
    Me.btnTransferir.Name = "btnTransferir"
    Me.btnTransferir.Size = New System.Drawing.Size(128, 53)
    Me.btnTransferir.TabIndex = 67
    Me.btnTransferir.Text = "&Procesar"
    Me.btnTransferir.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'UltraButton1
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
    Me.UltraButton1.Appearance = Appearance9
    Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.UltraButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraButton1.ImageSize = New System.Drawing.Size(32, 32)
    Me.UltraButton1.Location = New System.Drawing.Point(613, 59)
    Me.UltraButton1.Name = "UltraButton1"
    Me.UltraButton1.Size = New System.Drawing.Size(128, 53)
    Me.UltraButton1.TabIndex = 68
    Me.UltraButton1.Text = "&Procesar"
    Me.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    Me.UltraButton1.Visible = False
    '
    'txtServicio
    '
    Me.txtServicio.Location = New System.Drawing.Point(119, 132)
    Me.txtServicio.Name = "txtServicio"
    Me.txtServicio.Size = New System.Drawing.Size(340, 21)
    Me.txtServicio.TabIndex = 69
    Me.txtServicio.Visible = False
    '
    'lblServicio
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance10.TextVAlignAsString = "Top"
    Me.lblServicio.Appearance = Appearance10
    Me.lblServicio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblServicio.Location = New System.Drawing.Point(12, 136)
    Me.lblServicio.Name = "lblServicio"
    Me.lblServicio.Size = New System.Drawing.Size(101, 15)
    Me.lblServicio.TabIndex = 70
    Me.lblServicio.Text = "Servicio"
    Me.lblServicio.Visible = False
    '
    'txtEntidad
    '
    Me.txtEntidad.Location = New System.Drawing.Point(119, 57)
    Me.txtEntidad.Name = "txtEntidad"
    Me.txtEntidad.ReadOnly = True
    Me.txtEntidad.Size = New System.Drawing.Size(46, 21)
    Me.txtEntidad.TabIndex = 71
    '
    'cboFecha
    '
    Me.cboFecha.CustomFormat = "yyyy/MM/dd"
    Me.cboFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.cboFecha.Location = New System.Drawing.Point(119, 108)
    Me.cboFecha.Name = "cboFecha"
    Me.cboFecha.Size = New System.Drawing.Size(108, 20)
    Me.cboFecha.TabIndex = 72
    Me.cboFecha.Value = New Date(2016, 4, 21, 14, 56, 34, 0)
    Me.cboFecha.Visible = False
    '
    'lblFecha
    '
    Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance11.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance11.TextVAlignAsString = "Top"
    Me.lblFecha.Appearance = Appearance11
    Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblFecha.Location = New System.Drawing.Point(12, 110)
    Me.lblFecha.Name = "lblFecha"
    Me.lblFecha.Size = New System.Drawing.Size(101, 15)
    Me.lblFecha.TabIndex = 73
    Me.lblFecha.Text = "Fecha"
    Me.lblFecha.Visible = False
    '
    'txtAnio
    '
    Me.txtAnio.Location = New System.Drawing.Point(403, 107)
    Me.txtAnio.Name = "txtAnio"
    Me.txtAnio.Size = New System.Drawing.Size(56, 21)
    Me.txtAnio.TabIndex = 74
    Me.txtAnio.Visible = False
    '
    'lblAnio
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance12.TextVAlignAsString = "Top"
    Me.lblAnio.Appearance = Appearance12
    Me.lblAnio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblAnio.Location = New System.Drawing.Point(361, 110)
    Me.lblAnio.Name = "lblAnio"
    Me.lblAnio.Size = New System.Drawing.Size(36, 15)
    Me.lblAnio.TabIndex = 75
    Me.lblAnio.Text = "Año"
    Me.lblAnio.Visible = False
    '
    'FrmIntegracionAssinet
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(753, 418)
    Me.Controls.Add(Me.lblAnio)
    Me.Controls.Add(Me.txtAnio)
    Me.Controls.Add(Me.lblFecha)
    Me.Controls.Add(Me.cboFecha)
    Me.Controls.Add(Me.txtEntidad)
    Me.Controls.Add(Me.lblServicio)
    Me.Controls.Add(Me.txtServicio)
    Me.Controls.Add(Me.UltraButton1)
    Me.Controls.Add(Me.btnTransferir)
    Me.Controls.Add(Me.utTab)
    Me.Controls.Add(Me.UltraLabel3)
    Me.Controls.Add(Me.UltraLabel2)
    Me.Controls.Add(Me.cboEntidad)
    Me.Controls.Add(Me.cboOpciones)
    Me.Controls.Add(Me.UltraGroupBox4)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmIntegracionAssinet"
    Me.Text = "Integracion Assinet"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.uTabControl.ResumeLayout(False)
    Me.UltraTabPageControl2.ResumeLayout(False)
    Me.UltraTabPageControl3.ResumeLayout(False)
    Me.UltraTabPageControl3.PerformLayout()
    Me.ToolStrip2.ResumeLayout(False)
    Me.ToolStrip2.PerformLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox4.ResumeLayout(False)
    CType(Me.utTab, System.ComponentModel.ISupportInitialize).EndInit()
    Me.utTab.ResumeLayout(False)
    CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents cboEntidad As System.Windows.Forms.ComboBox
    Friend WithEvents cboOpciones As System.Windows.Forms.ComboBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utTab As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents uTabControl As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents TxtRequest As System.Windows.Forms.RichTextBox
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btnTransferir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents utExcel As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents tsGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtServicio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblServicio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtEntidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cboFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAnio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblAnio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
