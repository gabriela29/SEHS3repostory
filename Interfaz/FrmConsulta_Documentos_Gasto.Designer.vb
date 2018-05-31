<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulta_Documentos_Gasto
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulta_Documentos_Gasto))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ExpanGroup = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtNumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtSerie = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.TxtRuc = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.TxtProveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cboDocumento = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.picAjax = New System.Windows.Forms.PictureBox()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bwDocs = New System.ComponentModel.BackgroundWorker()
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpanGroup.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterios.SuspendLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpanGroup
        '
        Me.ExpanGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.Color.White
        Me.ExpanGroup.ContentAreaAppearance = Appearance13
        Me.ExpanGroup.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.ExpanGroup.ExpandedSize = New System.Drawing.Size(629, 434)
        Me.ExpanGroup.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.None
        Me.ExpanGroup.Location = New System.Drawing.Point(-1, -1)
        Me.ExpanGroup.Name = "ExpanGroup"
        Me.ExpanGroup.Size = New System.Drawing.Size(629, 434)
        Me.ExpanGroup.TabIndex = 2
        Me.ExpanGroup.Text = "Listado de Documentos de:"
        Me.ExpanGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.gpCriterios)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.picAjax)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.dgvListado)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button1)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 16)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(623, 415)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'gpCriterios
        '
        Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
        Me.gpCriterios.ContentAreaAppearance = Appearance1
        Me.gpCriterios.Controls.Add(Me.txtNumero)
        Me.gpCriterios.Controls.Add(Me.txtSerie)
        Me.gpCriterios.Controls.Add(Me.UltraLabel1)
        Me.gpCriterios.Controls.Add(Me.UltraLabel12)
        Me.gpCriterios.Controls.Add(Me.btnBuscar)
        Me.gpCriterios.Controls.Add(Me.TxtRuc)
        Me.gpCriterios.Controls.Add(Me.cboAlmacen)
        Me.gpCriterios.Controls.Add(Me.TxtProveedor)
        Me.gpCriterios.Controls.Add(Me.cboDocumento)
        Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
        Me.gpCriterios.Location = New System.Drawing.Point(-3, -1)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(628, 84)
        Me.gpCriterios.TabIndex = 112
        Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtNumero
        '
        Appearance7.BackColor = System.Drawing.Color.LemonChiffon
        Appearance7.TextHAlignAsString = "Right"
        Me.txtNumero.Appearance = Appearance7
        Me.txtNumero.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNumero.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(445, 25)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(73, 24)
        Me.txtNumero.TabIndex = 113
        '
        'txtSerie
        '
        Appearance10.BackColor = System.Drawing.Color.LemonChiffon
        Appearance10.TextHAlignAsString = "Right"
        Me.txtSerie.Appearance = Appearance10
        Me.txtSerie.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtSerie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSerie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(395, 25)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(45, 24)
        Me.txtSerie.TabIndex = 112
        '
        'UltraLabel1
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance34.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance34
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel1.Location = New System.Drawing.Point(23, 58)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 15)
        Me.UltraLabel1.TabIndex = 111
        Me.UltraLabel1.Text = "RUC"
        '
        'UltraLabel12
        '
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance14.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance14
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(61, 9)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(345, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "  Almacén                                  Documento"
        '
        'btnBuscar
        '
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.btnBuscar.Appearance = Appearance3
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnBuscar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscar.Location = New System.Drawing.Point(524, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 57)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "&Mostrar"
        Me.btnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'TxtRuc
        '
        Appearance2.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtRuc.Appearance = Appearance2
        Me.TxtRuc.BackColor = System.Drawing.Color.LemonChiffon
        Me.TxtRuc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtRuc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRuc.Location = New System.Drawing.Point(61, 54)
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.ReadOnly = True
        Me.TxtRuc.Size = New System.Drawing.Size(140, 24)
        Me.TxtRuc.TabIndex = 110
        '
        'cboAlmacen
        '
        Appearance8.BackColor = System.Drawing.Color.LemonChiffon
        Me.cboAlmacen.Appearance = Appearance8
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
        Me.cboAlmacen.Location = New System.Drawing.Point(61, 27)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(154, 22)
        Me.cboAlmacen.TabIndex = 0
        '
        'TxtProveedor
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.TxtProveedor.Appearance = Appearance9
        Me.TxtProveedor.BackColor = System.Drawing.Color.Transparent
        Me.TxtProveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtProveedor.Location = New System.Drawing.Point(222, 56)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.ReadOnly = True
        Me.TxtProveedor.Size = New System.Drawing.Size(296, 21)
        Me.TxtProveedor.TabIndex = 0
        '
        'cboDocumento
        '
        Me.cboDocumento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance64.BackColor = System.Drawing.Color.White
        Me.cboDocumento.DisplayLayout.Appearance = Appearance64
        Me.cboDocumento.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance82.BackColor = System.Drawing.Color.Transparent
        Me.cboDocumento.DisplayLayout.Override.CardAreaAppearance = Appearance82
        Appearance83.BackColor = System.Drawing.Color.White
        Appearance83.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance83.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance83.FontData.BoldAsString = "True"
        Appearance83.FontData.Name = "Arial"
        Appearance83.FontData.SizeInPoints = 10.0!
        Appearance83.ForeColor = System.Drawing.Color.White
        Appearance83.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboDocumento.DisplayLayout.Override.HeaderAppearance = Appearance83
        Appearance96.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance96.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance96.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDocumento.DisplayLayout.Override.RowSelectorAppearance = Appearance96
        Appearance97.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance97.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance97.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDocumento.DisplayLayout.Override.SelectedRowAppearance = Appearance97
        Me.cboDocumento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboDocumento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDocumento.Location = New System.Drawing.Point(222, 26)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(167, 23)
        Me.cboDocumento.TabIndex = 109
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
        'picAjax
        '
        Me.picAjax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjax.BackColor = System.Drawing.Color.White
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(0, 82)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(623, 334)
        Me.picAjax.TabIndex = 111
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'dgvListado
        '
        Me.dgvListado.AllowDrop = True
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.BackColor = System.Drawing.Color.White
        Me.dgvListado.DisplayLayout.Appearance = Appearance11
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.dgvListado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvListado.Location = New System.Drawing.Point(2, 84)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(620, 324)
        Me.dgvListado.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(389, -18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 17)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(279, -14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 15)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bwDocs
        '
        '
        'FrmConsulta_Documentos_Gasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(628, 431)
        Me.Controls.Add(Me.ExpanGroup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsulta_Documentos_Gasto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Documentos Gasto"
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpanGroup.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterios.ResumeLayout(False)
        Me.gpCriterios.PerformLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpanGroup As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtRuc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cboDocumento As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents TxtProveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bwDocs As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtSerie As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
