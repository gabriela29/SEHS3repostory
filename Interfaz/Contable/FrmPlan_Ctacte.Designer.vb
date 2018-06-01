<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPlan_Ctacte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlan_Ctacte))
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gpConsulta = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnRegistroV = New System.Windows.Forms.Button()
        Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.cboEntidad = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.GroupBox = New Infragistics.Win.Misc.UltraGroupBox()
        Me.picAjaxBig = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDigitación = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCerrarD = New System.Windows.Forms.ToolStripButton()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLocation = New Infragistics.Win.Misc.UltraButton()
        Me.lblPendientes = New Infragistics.Win.Misc.UltraLabel()
        Me.bwLlenar_Grid = New System.ComponentModel.BackgroundWorker()
        CType(Me.gpConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpConsulta.SuspendLayout()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpConsulta
        '
        Me.gpConsulta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gpConsulta.ContentAreaAppearance = Appearance1
        Me.gpConsulta.Controls.Add(Me.btnRegistroV)
        Me.gpConsulta.Controls.Add(Me.txtNombre)
        Me.gpConsulta.Controls.Add(Me.cboEntidad)
        Me.gpConsulta.Controls.Add(Me.cboTipo)
        Me.gpConsulta.Controls.Add(Me.BtnMostrar)
        Me.gpConsulta.Controls.Add(Me.UltraLabel2)
        Me.gpConsulta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpConsulta.Location = New System.Drawing.Point(1, 2)
        Me.gpConsulta.Name = "gpConsulta"
        Me.gpConsulta.Size = New System.Drawing.Size(664, 87)
        Me.gpConsulta.TabIndex = 3
        Me.gpConsulta.Text = "         Entidad                     Tipo"
        '
        'btnRegistroV
        '
        Me.btnRegistroV.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnRegistroV.BackColor = System.Drawing.Color.MistyRose
        Me.btnRegistroV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRegistroV.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnRegistroV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRegistroV.Location = New System.Drawing.Point(356, 21)
        Me.btnRegistroV.Name = "btnRegistroV"
        Me.btnRegistroV.Size = New System.Drawing.Size(121, 37)
        Me.btnRegistroV.TabIndex = 92
        Me.btnRegistroV.Text = "Registro Venta"
        Me.btnRegistroV.UseVisualStyleBackColor = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(64, 56)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(181, 23)
        Me.txtNombre.TabIndex = 97
        Me.txtNombre.Visible = False
        '
        'cboEntidad
        '
        Me.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidad.FormattingEnabled = True
        Me.cboEntidad.Items.AddRange(New Object() {"7114", "7312", "7912", "7012", "7512", "7712", "7412", "17114"})
        Me.cboEntidad.Location = New System.Drawing.Point(11, 21)
        Me.cboEntidad.Name = "cboEntidad"
        Me.cboEntidad.Size = New System.Drawing.Size(113, 22)
        Me.cboEntidad.TabIndex = 96
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance2.BackColor = System.Drawing.Color.White
        Me.cboTipo.DisplayLayout.Appearance = Appearance2
        Me.cboTipo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.cboTipo.DisplayLayout.Override.CardAreaAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial"
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.White
        Appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboTipo.DisplayLayout.Override.HeaderAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboTipo.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboTipo.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.cboTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.Location = New System.Drawing.Point(141, 20)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(104, 23)
        Me.cboTipo.TabIndex = 95
        '
        'BtnMostrar
        '
        Me.BtnMostrar.FlatAppearance.BorderSize = 0
        Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
        Me.BtnMostrar.Location = New System.Drawing.Point(266, 41)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
        Me.BtnMostrar.TabIndex = 88
        Me.BtnMostrar.UseVisualStyleBackColor = True
        '
        'UltraLabel2
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance7.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.UltraLabel2.Appearance = Appearance7
        Me.UltraLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(11, 61)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(63, 15)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Nombre"
        '
        'GroupBox
        '
        Me.GroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox.Controls.Add(Me.picAjaxBig)
        Me.GroupBox.Controls.Add(Me.ToolStrip1)
        Me.GroupBox.Controls.Add(Me.dgvListado)
        Me.GroupBox.Controls.Add(Me.btnLocation)
        Me.GroupBox.Location = New System.Drawing.Point(1, 92)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(664, 311)
        Me.GroupBox.TabIndex = 4
        Me.GroupBox.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'picAjaxBig
        '
        Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjaxBig.BackColor = System.Drawing.Color.White
        Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
        Me.picAjaxBig.Location = New System.Drawing.Point(0, 52)
        Me.picAjaxBig.Name = "picAjaxBig"
        Me.picAjaxBig.Size = New System.Drawing.Size(659, 256)
        Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAjaxBig.TabIndex = 91
        Me.picAjaxBig.TabStop = False
        Me.picAjaxBig.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator10, Me.tsNuevo, Me.ToolStripSeparator2, Me.tsDigitación, Me.ToolStripSeparator1, Me.tsCerrarD})
        Me.ToolStrip1.Location = New System.Drawing.Point(2, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(660, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsActualizar
        '
        Me.tsActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
        Me.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsActualizar.Name = "tsActualizar"
        Me.tsActualizar.Size = New System.Drawing.Size(23, 22)
        Me.tsActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'tsNuevo
        '
        Me.tsNuevo.Image = Global.Phoenix.My.Resources.Resources.add
        Me.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNuevo.Name = "tsNuevo"
        Me.tsNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsNuevo.Text = "&Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsDigitación
        '
        Me.tsDigitación.Image = Global.Phoenix.My.Resources.Resources.table_edit
        Me.tsDigitación.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDigitación.Name = "tsDigitación"
        Me.tsDigitación.Size = New System.Drawing.Size(78, 22)
        Me.tsDigitación.Text = "&Modificar"
        Me.tsDigitación.ToolTipText = "Digitación Documento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsCerrarD
        '
        Me.tsCerrarD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsCerrarD.Image = Global.Phoenix.My.Resources.Resources.Salir
        Me.tsCerrarD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCerrarD.Name = "tsCerrarD"
        Me.tsCerrarD.Size = New System.Drawing.Size(23, 22)
        Me.tsCerrarD.Text = "ToolStripButton1"
        '
        'dgvListado
        '
        Me.dgvListado.AllowDrop = True
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance8.BackColor = System.Drawing.Color.White
        Me.dgvListado.DisplayLayout.Appearance = Appearance8
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 10.0!
        Appearance10.ForeColor = System.Drawing.Color.White
        Appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance12
        Me.dgvListado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvListado.Location = New System.Drawing.Point(4, 31)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(655, 277)
        Me.dgvListado.TabIndex = 2
        '
        'btnLocation
        '
        Appearance13.BackColor = System.Drawing.Color.LightBlue
        Appearance13.BackColor2 = System.Drawing.Color.White
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance13.ForeColor = System.Drawing.Color.Navy
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.btnLocation.Appearance = Appearance13
        Me.btnLocation.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btnLocation.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.Location = New System.Drawing.Point(31, 8)
        Me.btnLocation.Name = "btnLocation"
        Appearance14.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnLocation.PressedAppearance = Appearance14
        Me.btnLocation.Size = New System.Drawing.Size(33, 17)
        Me.btnLocation.TabIndex = 67
        Me.btnLocation.Text = "x"
        Me.btnLocation.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblPendientes
        '
        Me.lblPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance15.ForeColor = System.Drawing.Color.LightSteelBlue
        Appearance15.TextVAlignAsString = "Top"
        Me.lblPendientes.Appearance = Appearance15
        Me.lblPendientes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendientes.Location = New System.Drawing.Point(5, 409)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(170, 15)
        Me.lblPendientes.TabIndex = 94
        Me.lblPendientes.Text = "..."
        '
        'bwLlenar_Grid
        '
        '
        'FrmPlan_Ctacte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 428)
        Me.Controls.Add(Me.lblPendientes)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.gpConsulta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPlan_Ctacte"
        Me.ShowInTaskbar = False
        Me.Text = "Plan Ctacte"
        CType(Me.gpConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpConsulta.ResumeLayout(False)
        Me.gpConsulta.PerformLayout()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpConsulta As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboTipo As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnMostrar As Button
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxBig As PictureBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsDigitación As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsCerrarD As ToolStripButton
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLocation As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblPendientes As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboEntidad As ComboBox
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents bwLlenar_Grid As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnRegistroV As Button
End Class
