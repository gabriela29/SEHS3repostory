<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestion_Acceso
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
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestion_Acceso))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.BtnGrabarMenu = New Infragistics.Win.Misc.UltraButton()
        Me.chkMenu = New System.Windows.Forms.CheckBox()
        Me.TMenu = New Telerik.WinControls.UI.RadTreeView()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnGrabarModAlm = New Infragistics.Win.Misc.UltraButton()
        Me.chkModulos = New System.Windows.Forms.CheckBox()
        Me.TModulos = New Telerik.WinControls.UI.RadTreeView()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnGrabarOtros = New Infragistics.Win.Misc.UltraButton()
        Me.chkOtros = New System.Windows.Forms.CheckBox()
        Me.TOtros = New Telerik.WinControls.UI.RadTreeView()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtApe_Mat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtBuscar = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.GPUsuarios = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dgvCondicion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblBuscar = New Infragistics.Win.Misc.UltraLabel()
        Me.uTabs = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.TMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.TModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.TOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApe_Mat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPUsuarios.SuspendLayout()
        CType(Me.dgvCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uTabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.BtnGrabarMenu)
        Me.UltraTabPageControl1.Controls.Add(Me.chkMenu)
        Me.UltraTabPageControl1.Controls.Add(Me.TMenu)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(301, 450)
        '
        'BtnGrabarMenu
        '
        Me.BtnGrabarMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance12.BackColor = System.Drawing.Color.White
        Appearance12.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        Me.BtnGrabarMenu.Appearance = Appearance12
        Me.BtnGrabarMenu.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabarMenu.Location = New System.Drawing.Point(98, 419)
        Me.BtnGrabarMenu.Name = "BtnGrabarMenu"
        Me.BtnGrabarMenu.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabarMenu.TabIndex = 2
        Me.BtnGrabarMenu.Text = "&Grabar"
        Me.BtnGrabarMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkMenu
        '
        Me.chkMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMenu.BackColor = System.Drawing.Color.Transparent
        Me.chkMenu.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMenu.Location = New System.Drawing.Point(9, 424)
        Me.chkMenu.Name = "chkMenu"
        Me.chkMenu.Size = New System.Drawing.Size(110, 21)
        Me.chkMenu.TabIndex = 1
        Me.chkMenu.Text = "Activar Todo"
        Me.chkMenu.UseVisualStyleBackColor = False
        '
        'TMenu
        '
        Me.TMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TMenu.Location = New System.Drawing.Point(3, 2)
        Me.TMenu.Name = "TMenu"
        Me.TMenu.Size = New System.Drawing.Size(295, 411)
        Me.TMenu.SpacingBetweenNodes = -1
        Me.TMenu.TabIndex = 0
        Me.TMenu.Text = "Menu"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.btnGrabarModAlm)
        Me.UltraTabPageControl2.Controls.Add(Me.chkModulos)
        Me.UltraTabPageControl2.Controls.Add(Me.TModulos)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(301, 450)
        '
        'btnGrabarModAlm
        '
        Me.btnGrabarModAlm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.btnGrabarModAlm.Appearance = Appearance14
        Me.btnGrabarModAlm.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnGrabarModAlm.Location = New System.Drawing.Point(99, 418)
        Me.btnGrabarModAlm.Name = "btnGrabarModAlm"
        Me.btnGrabarModAlm.Size = New System.Drawing.Size(83, 27)
        Me.btnGrabarModAlm.TabIndex = 3
        Me.btnGrabarModAlm.Text = "&Grabar"
        Me.btnGrabarModAlm.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkModulos
        '
        Me.chkModulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkModulos.BackColor = System.Drawing.Color.Transparent
        Me.chkModulos.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkModulos.Location = New System.Drawing.Point(4, 424)
        Me.chkModulos.Name = "chkModulos"
        Me.chkModulos.Size = New System.Drawing.Size(110, 21)
        Me.chkModulos.TabIndex = 2
        Me.chkModulos.Text = "Activar Todo"
        Me.chkModulos.UseVisualStyleBackColor = False
        '
        'TModulos
        '
        Me.TModulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TModulos.Location = New System.Drawing.Point(0, 2)
        Me.TModulos.Name = "TModulos"
        Me.TModulos.Size = New System.Drawing.Size(298, 410)
        Me.TModulos.SpacingBetweenNodes = -1
        Me.TModulos.TabIndex = 1
        Me.TModulos.Text = "RadTreeView1"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.btnGrabarOtros)
        Me.UltraTabPageControl3.Controls.Add(Me.chkOtros)
        Me.UltraTabPageControl3.Controls.Add(Me.TOtros)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(301, 450)
        '
        'btnGrabarOtros
        '
        Me.btnGrabarOtros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnGrabarOtros.Appearance = Appearance1
        Me.btnGrabarOtros.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnGrabarOtros.Location = New System.Drawing.Point(104, 419)
        Me.btnGrabarOtros.Name = "btnGrabarOtros"
        Me.btnGrabarOtros.Size = New System.Drawing.Size(83, 27)
        Me.btnGrabarOtros.TabIndex = 4
        Me.btnGrabarOtros.Text = "&Grabar"
        Me.btnGrabarOtros.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chkOtros
        '
        Me.chkOtros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkOtros.BackColor = System.Drawing.Color.Transparent
        Me.chkOtros.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtros.Location = New System.Drawing.Point(4, 422)
        Me.chkOtros.Name = "chkOtros"
        Me.chkOtros.Size = New System.Drawing.Size(110, 21)
        Me.chkOtros.TabIndex = 2
        Me.chkOtros.Text = "Activar Todo"
        Me.chkOtros.UseVisualStyleBackColor = False
        '
        'TOtros
        '
        Me.TOtros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TOtros.Location = New System.Drawing.Point(0, 2)
        Me.TOtros.Name = "TOtros"
        Me.TOtros.Size = New System.Drawing.Size(298, 411)
        Me.TOtros.SpacingBetweenNodes = -1
        Me.TOtros.TabIndex = 1
        Me.TOtros.Text = "RadTreeView1"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.LightBlue
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.ForeColor = System.Drawing.Color.SteelBlue
        Appearance2.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(73, 1)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(678, 35)
        Me.UltraLabel1.TabIndex = 69
        Me.UltraLabel1.Text = "ADMINISTRACIÓN DE ACCESOS Y PERMISOS"
        '
        'btnBuscar
        '
        Appearance15.BackColor = System.Drawing.Color.LightBlue
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.Image = CType(resources.GetObject("Appearance15.Image"), Object)
        Me.btnBuscar.Appearance = Appearance15
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnBuscar.Location = New System.Drawing.Point(225, 64)
        Me.btnBuscar.Name = "btnBuscar"
        Appearance10.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnBuscar.PressedAppearance = Appearance10
        Me.btnBuscar.Size = New System.Drawing.Size(80, 23)
        Me.btnBuscar.TabIndex = 80
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtNombre
        '
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Me.txtNombre.Appearance = Appearance4
        Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(96, 64)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(121, 22)
        Me.txtNombre.TabIndex = 79
        '
        'txtApe_Mat
        '
        Appearance9.ForeColor = System.Drawing.Color.Navy
        Me.txtApe_Mat.Appearance = Appearance9
        Me.txtApe_Mat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtApe_Mat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApe_Mat.Location = New System.Drawing.Point(96, 36)
        Me.txtApe_Mat.MaxLength = 50
        Me.txtApe_Mat.Name = "txtApe_Mat"
        Me.txtApe_Mat.Size = New System.Drawing.Size(121, 22)
        Me.txtApe_Mat.TabIndex = 78
        '
        'txtBuscar
        '
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Me.txtBuscar.Appearance = Appearance3
        Me.txtBuscar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(96, 8)
        Me.txtBuscar.MaxLength = 50
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(121, 22)
        Me.txtBuscar.TabIndex = 77
        '
        'GPUsuarios
        '
        Me.GPUsuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GPUsuarios.Controls.Add(Me.dgvCondicion)
        Me.GPUsuarios.Controls.Add(Me.UltraLabel3)
        Me.GPUsuarios.Controls.Add(Me.UltraLabel2)
        Me.GPUsuarios.Controls.Add(Me.txtBuscar)
        Me.GPUsuarios.Controls.Add(Me.txtApe_Mat)
        Me.GPUsuarios.Controls.Add(Me.txtNombre)
        Me.GPUsuarios.Controls.Add(Me.lblBuscar)
        Me.GPUsuarios.Controls.Add(Me.btnBuscar)
        Me.GPUsuarios.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.GPUsuarios.Location = New System.Drawing.Point(-1, 53)
        Me.GPUsuarios.Name = "GPUsuarios"
        Me.GPUsuarios.Size = New System.Drawing.Size(449, 473)
        Me.GPUsuarios.TabIndex = 81
        Me.GPUsuarios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dgvCondicion
        '
        Me.dgvCondicion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCondicion.DisplayLayout.AddNewBox.Prompt = " Nuevo"
        Me.dgvCondicion.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.dgvCondicion.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvCondicion.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvCondicion.Location = New System.Drawing.Point(3, 93)
        Me.dgvCondicion.Name = "dgvCondicion"
        Me.dgvCondicion.Size = New System.Drawing.Size(442, 356)
        Me.dgvCondicion.TabIndex = 83
        '
        'UltraLabel3
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.SteelBlue
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Top"
        Me.UltraLabel3.Appearance = Appearance5
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel3.Location = New System.Drawing.Point(10, 68)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(82, 17)
        Me.UltraLabel3.TabIndex = 82
        Me.UltraLabel3.Text = "Nombre:"
        '
        'UltraLabel2
        '
        Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance11.ForeColor = System.Drawing.Color.SteelBlue
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Top"
        Me.UltraLabel2.Appearance = Appearance11
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel2.Location = New System.Drawing.Point(10, 38)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(82, 17)
        Me.UltraLabel2.TabIndex = 81
        Me.UltraLabel2.Text = "Ape. Materno:"
        '
        'lblBuscar
        '
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.Color.SteelBlue
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Top"
        Me.lblBuscar.Appearance = Appearance13
        Me.lblBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBuscar.Location = New System.Drawing.Point(10, 8)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(82, 17)
        Me.lblBuscar.TabIndex = 76
        Me.lblBuscar.Text = "Ape. Paterno:"
        '
        'uTabs
        '
        Me.uTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uTabs.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.uTabs.Controls.Add(Me.UltraTabPageControl1)
        Me.uTabs.Controls.Add(Me.UltraTabPageControl2)
        Me.uTabs.Controls.Add(Me.UltraTabPageControl3)
        Me.uTabs.Location = New System.Drawing.Point(449, 53)
        Me.uTabs.Name = "uTabs"
        Me.uTabs.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.uTabs.Size = New System.Drawing.Size(303, 473)
        Me.uTabs.TabIndex = 83
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraTab1.Appearance = Appearance6
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "MENU"
        UltraTab1.ToolTipText = "Sub Categorías"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "MODULOS"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "OTROS"
        Me.uTabs.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        Me.uTabs.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(301, 450)
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(65, 65)
        Me.UltraPictureBox1.TabIndex = 8
        '
        'FrmGestion_Acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(754, 528)
        Me.Controls.Add(Me.uTabs)
        Me.Controls.Add(Me.GPUsuarios)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmGestion_Acceso"
        Me.ShowInTaskbar = False
        Me.Text = "Gestion Acceso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.TMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.TModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.TOtros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApe_Mat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPUsuarios.ResumeLayout(False)
        Me.GPUsuarios.PerformLayout()
        CType(Me.dgvCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uTabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uTabs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtApe_Mat As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtBuscar As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GPUsuarios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uTabs As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents TMenu As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents TModulos As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents TOtros As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBuscar As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkMenu As System.Windows.Forms.CheckBox
    Friend WithEvents chkModulos As System.Windows.Forms.CheckBox
    Friend WithEvents chkOtros As System.Windows.Forms.CheckBox
    Friend WithEvents dgvCondicion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BtnGrabarMenu As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGrabarModAlm As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGrabarOtros As Infragistics.Win.Misc.UltraButton
End Class
