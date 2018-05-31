<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBonificacionEdit
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBonificacionEdit))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblAlmacen = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.lblRegistros = New Infragistics.Win.Misc.UltraLabel
        Me.cboTipo = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ExpanGroup = New Infragistics.Win.Misc.UltraExpandableGroupBox
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.lblImporte_Min = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.cboDestino = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnDetalle = New Infragistics.Win.Misc.UltraButton
        Me.btnEditar = New Infragistics.Win.Misc.UltraButton
        Me.btnMostrar = New Infragistics.Win.Misc.UltraButton
        Me.picAjax = New System.Windows.Forms.PictureBox
        Me.lblHasta = New Infragistics.Win.Misc.UltraLabel
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel
        Me.lblBuscarpor = New Infragistics.Win.Misc.UltraLabel
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnAsignar = New Infragistics.Win.Misc.UltraButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker
        Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.bwAgregar = New System.ComponentModel.BackgroundWorker
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpanGroup.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.cboDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance1
        Me.UltraGroupBox4.Controls.Add(Me.lblAlmacen)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(857, 63)
        Me.UltraGroupBox4.TabIndex = 5
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblAlmacen
        '
        Appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance22.ForeColor = System.Drawing.Color.Navy
        Appearance22.TextVAlignAsString = "Middle"
        Me.lblAlmacen.Appearance = Appearance22
        Me.lblAlmacen.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlmacen.Location = New System.Drawing.Point(80, 32)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(455, 25)
        Me.lblAlmacen.TabIndex = 93
        Me.lblAlmacen.Text = "..."
        '
        'UltraLabel12
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance34.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance34
        Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(80, 10)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(275, 16)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Lista de Ventas Realizadas"
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(7, 8)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(67, 40)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.Color.SteelBlue
        Appearance13.TextVAlignAsString = "Top"
        Me.lblRegistros.Appearance = Appearance13
        Me.lblRegistros.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblRegistros.Location = New System.Drawing.Point(9, 394)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(256, 13)
        Me.lblRegistros.TabIndex = 44
        Me.lblRegistros.Text = "-"
        '
        'cboTipo
        '
        Appearance12.BackColor = System.Drawing.Color.White
        Appearance12.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.cboTipo.Appearance = Appearance12
        Me.cboTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance14.BackColor = System.Drawing.Color.White
        Me.cboTipo.DisplayLayout.Appearance = Appearance14
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Me.cboTipo.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.Color.White
        Appearance25.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial"
        Appearance25.FontData.SizeInPoints = 10.0!
        Appearance25.ForeColor = System.Drawing.Color.White
        Appearance25.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboTipo.DisplayLayout.Override.HeaderAppearance = Appearance25
        Appearance26.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboTipo.DisplayLayout.Override.RowSelectorAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance27.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboTipo.DisplayLayout.Override.SelectedRowAppearance = Appearance27
        Me.cboTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboTipo.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.Location = New System.Drawing.Point(64, 3)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(402, 25)
        Me.cboTipo.TabIndex = 94
        '
        'ExpanGroup
        '
        Me.ExpanGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpanGroup.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.ExpanGroup.ExpandedSize = New System.Drawing.Size(857, 439)
        Me.ExpanGroup.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.None
        Me.ExpanGroup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpanGroup.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColor = System.Drawing.Color.Navy
        Me.ExpanGroup.HeaderAppearance = Appearance11
        Me.ExpanGroup.Location = New System.Drawing.Point(0, 63)
        Me.ExpanGroup.Name = "ExpanGroup"
        Me.ExpanGroup.Size = New System.Drawing.Size(857, 439)
        Me.ExpanGroup.TabIndex = 6
        Me.ExpanGroup.Text = "Buscar..."
        Me.ExpanGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblImporte_Min)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel1)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.cboDestino)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnDetalle)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnEditar)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnMostrar)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblRegistros)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.picAjax)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblHasta)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblDesde)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.cboTipo)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblBuscarpor)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.dgvListado)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnAsignar)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button1)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 19)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(851, 417)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'UltraLabel2
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Top"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(317, 35)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(61, 16)
        Me.UltraLabel2.TabIndex = 116
        Me.UltraLabel2.Text = "Meta:"
        '
        'lblImporte_Min
        '
        Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance19.ForeColor = System.Drawing.Color.Navy
        Appearance19.TextHAlignAsString = "Right"
        Appearance19.TextVAlignAsString = "Middle"
        Me.lblImporte_Min.Appearance = Appearance19
        Me.lblImporte_Min.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte_Min.Location = New System.Drawing.Point(384, 35)
        Me.lblImporte_Min.Name = "lblImporte_Min"
        Me.lblImporte_Min.Size = New System.Drawing.Size(66, 18)
        Me.lblImporte_Min.TabIndex = 115
        Me.lblImporte_Min.Text = "0.00"
        '
        'UltraLabel1
        '
        Appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance28.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance28.TextHAlignAsString = "Right"
        Appearance28.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance28
        Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(2, 35)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(61, 16)
        Me.UltraLabel1.TabIndex = 114
        Me.UltraLabel1.Text = "Destino:"
        '
        'cboDestino
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.cboDestino.Appearance = Appearance6
        Me.cboDestino.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Me.cboDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance7.BackColor = System.Drawing.Color.White
        Me.cboDestino.DisplayLayout.Appearance = Appearance7
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.cboDestino.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.FontData.BoldAsString = "True"
        Appearance16.FontData.Name = "Arial"
        Appearance16.FontData.SizeInPoints = 10.0!
        Appearance16.ForeColor = System.Drawing.Color.White
        Appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboDestino.DisplayLayout.Override.HeaderAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDestino.DisplayLayout.Override.RowSelectorAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDestino.DisplayLayout.Override.SelectedRowAppearance = Appearance18
        Me.cboDestino.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboDestino.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboDestino.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestino.Location = New System.Drawing.Point(64, 31)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(247, 25)
        Me.cboDestino.TabIndex = 113
        '
        'btnDetalle
        '
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance2.Image = Global.Phoenix.My.Resources.Resources.application_view_list
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnDetalle.Appearance = Appearance2
        Me.btnDetalle.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Location = New System.Drawing.Point(807, 14)
        Me.btnDetalle.Name = "btnDetalle"
        Appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnDetalle.PressedAppearance = Appearance3
        Me.btnDetalle.Size = New System.Drawing.Size(38, 28)
        Me.btnDetalle.TabIndex = 112
        Me.btnDetalle.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnEditar
        '
        Appearance20.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance20.Image = Global.Phoenix.My.Resources.Resources.page_excel
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnEditar.Appearance = Appearance20
        Me.btnEditar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(763, 14)
        Me.btnEditar.Name = "btnEditar"
        Appearance23.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnEditar.PressedAppearance = Appearance23
        Me.btnEditar.Size = New System.Drawing.Size(38, 28)
        Me.btnEditar.TabIndex = 111
        Me.btnEditar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnMostrar
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.Image = Global.Phoenix.My.Resources.Resources.Busca
        Me.btnMostrar.Appearance = Appearance4
        Me.btnMostrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnMostrar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnMostrar.Location = New System.Drawing.Point(666, 12)
        Me.btnMostrar.Name = "btnMostrar"
        Appearance8.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnMostrar.PressedAppearance = Appearance8
        Me.btnMostrar.Size = New System.Drawing.Size(91, 30)
        Me.btnMostrar.TabIndex = 110
        Me.btnMostrar.Text = "&Mostrar"
        Me.btnMostrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'picAjax
        '
        Me.picAjax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjax.BackColor = System.Drawing.Color.White
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(0, 62)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(851, 320)
        Me.picAjax.TabIndex = 84
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'lblHasta
        '
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance21.ForeColor = System.Drawing.Color.Navy
        Appearance21.TextHAlignAsString = "Right"
        Appearance21.TextVAlignAsString = "Middle"
        Me.lblHasta.Appearance = Appearance21
        Me.lblHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.Location = New System.Drawing.Point(554, 7)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(66, 18)
        Me.lblHasta.TabIndex = 106
        '
        'lblDesde
        '
        Appearance29.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance29.ForeColor = System.Drawing.Color.Navy
        Appearance29.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance29
        Me.lblDesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(477, 7)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(66, 18)
        Me.lblDesde.TabIndex = 105
        '
        'lblBuscarpor
        '
        Appearance30.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance30.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Top"
        Me.lblBuscarpor.Appearance = Appearance30
        Me.lblBuscarpor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarpor.Location = New System.Drawing.Point(2, 7)
        Me.lblBuscarpor.Name = "lblBuscarpor"
        Me.lblBuscarpor.Size = New System.Drawing.Size(61, 16)
        Me.lblBuscarpor.TabIndex = 102
        Me.lblBuscarpor.Text = "Tipo:"
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvListado.DisplayLayout.Appearance = Appearance31
        Me.dgvListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance32.BackColor = System.Drawing.Color.Transparent
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance45.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance45.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance45.FontData.BoldAsString = "True"
        Appearance45.FontData.Name = "Arial"
        Appearance45.FontData.SizeInPoints = 10.0!
        Appearance45.ForeColor = System.Drawing.Color.White
        Appearance45.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance45
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Appearance47.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance47.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance48.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance48
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvListado.Location = New System.Drawing.Point(-3, 60)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(857, 325)
        Me.dgvListado.TabIndex = 60
        Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
        '
        'btnAsignar
        '
        Me.btnAsignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.Image = Global.Phoenix.My.Resources.Resources.app_cal
        Me.btnAsignar.Appearance = Appearance10
        Me.btnAsignar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnAsignar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAsignar.Location = New System.Drawing.Point(642, 386)
        Me.btnAsignar.Name = "btnAsignar"
        Appearance15.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnAsignar.PressedAppearance = Appearance15
        Me.btnAsignar.Size = New System.Drawing.Size(91, 30)
        Me.btnAsignar.TabIndex = 3
        Me.btnAsignar.Text = "&Asignar"
        Me.btnAsignar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(390, -16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 16)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(287, -16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 15)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bwLlenar_Res
        '
        '
        'FrmBonificacionEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(857, 501)
        Me.Controls.Add(Me.ExpanGroup)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBonificacionEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Bonificación"
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpanGroup.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.cboDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents lblAlmacen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboTipo As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ExpanGroup As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents lblBuscarpor As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAsignar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblHasta As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnMostrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnEditar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnDetalle As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboDestino As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblImporte_Min As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents bwAgregar As System.ComponentModel.BackgroundWorker
End Class
