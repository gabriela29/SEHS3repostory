<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUbigeoConsulta
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUbigeoConsulta))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblRegistros = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.ExpanGroup = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.picAjax = New System.Windows.Forms.PictureBox()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEditar = New Infragistics.Win.Misc.UltraButton()
        Me.TxtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.TxtApe_Mat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnMostrar = New Infragistics.Win.Misc.UltraButton()
        Me.TxtApe_Pat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpanGroup.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtApe_Mat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtApe_Pat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance1
        Me.UltraGroupBox4.Controls.Add(Me.lblRegistros)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(534, 48)
        Me.UltraGroupBox4.TabIndex = 5
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.Color.SteelBlue
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Top"
        Me.lblRegistros.Appearance = Appearance13
        Me.lblRegistros.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblRegistros.Location = New System.Drawing.Point(272, 13)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(256, 13)
        Me.lblRegistros.TabIndex = 44
        Me.lblRegistros.Text = "-"
        '
        'UltraLabel12
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.Navy
        Appearance34.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance34
        Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(80, 10)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(275, 16)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Listado de Ubigeo"
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(7, 8)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'ExpanGroup
        '
        Me.ExpanGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpanGroup.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.ExpanGroup.ExpandedSize = New System.Drawing.Size(534, 371)
        Me.ExpanGroup.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.None
        Me.ExpanGroup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpanGroup.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColor = System.Drawing.Color.Blue
        Me.ExpanGroup.HeaderAppearance = Appearance11
        Me.ExpanGroup.Location = New System.Drawing.Point(0, 48)
        Me.ExpanGroup.Name = "ExpanGroup"
        Me.ExpanGroup.Size = New System.Drawing.Size(534, 371)
        Me.ExpanGroup.TabIndex = 6
        Me.ExpanGroup.Text = "     Distrito             Provincia           Departamento"
        Me.ExpanGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.picAjax)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.dgvListado)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnEditar)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.TxtNombre)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.TxtApe_Mat)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.btnMostrar)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.TxtApe_Pat)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button1)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 19)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(528, 349)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'picAjax
        '
        Me.picAjax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjax.BackColor = System.Drawing.Color.White
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(0, 6)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(528, 346)
        Me.picAjax.TabIndex = 84
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvListado.DisplayLayout.Appearance = Appearance31
        UltraGridBand1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.BorderStyleFilterCell = Infragistics.Win.UIElementBorderStyle.Solid
        UltraGridBand1.Override.BorderStyleFilterRow = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
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
        Me.dgvListado.Location = New System.Drawing.Point(-3, 32)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(534, 318)
        Me.dgvListado.TabIndex = 60
        Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
        '
        'btnEditar
        '
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnEditar.Appearance = Appearance2
        Me.btnEditar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(528, 5)
        Me.btnEditar.Name = "btnEditar"
        Appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnEditar.PressedAppearance = Appearance3
        Me.btnEditar.Size = New System.Drawing.Size(36, 24)
        Me.btnEditar.TabIndex = 59
        Me.btnEditar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        Me.btnEditar.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(233, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(82, 23)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtApe_Mat
        '
        Me.TxtApe_Mat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtApe_Mat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApe_Mat.Location = New System.Drawing.Point(123, 5)
        Me.TxtApe_Mat.Name = "TxtApe_Mat"
        Me.TxtApe_Mat.Size = New System.Drawing.Size(86, 23)
        Me.TxtApe_Mat.TabIndex = 1
        '
        'btnMostrar
        '
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnMostrar.Appearance = Appearance12
        Me.btnMostrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnMostrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrar.Location = New System.Drawing.Point(338, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Appearance14.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnMostrar.PressedAppearance = Appearance14
        Me.btnMostrar.Size = New System.Drawing.Size(68, 23)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.Text = "&Mostrar"
        Me.btnMostrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'TxtApe_Pat
        '
        Me.TxtApe_Pat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtApe_Pat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApe_Pat.Location = New System.Drawing.Point(21, 5)
        Me.TxtApe_Pat.Name = "TxtApe_Pat"
        Me.TxtApe_Pat.Size = New System.Drawing.Size(85, 23)
        Me.TxtApe_Pat.TabIndex = 0
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
        'FrmUbigeoConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(534, 419)
        Me.Controls.Add(Me.ExpanGroup)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUbigeoConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Ubigeo"
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpanGroup.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtApe_Mat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtApe_Pat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents ExpanGroup As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEditar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtApe_Mat As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnMostrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtApe_Pat As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
