<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulta_Plan_Ctas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsulta_Plan_Ctas))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ExpanGroup = New Infragistics.Win.Misc.UltraExpandableGroupBox
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
        Me.picAjax = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtLimite = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.CmbOpcion = New System.Windows.Forms.ComboBox
        Me.TxtBusca = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.bwPlan = New System.ComponentModel.BackgroundWorker
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpanGroup.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBusca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpanGroup
        '
        Me.ExpanGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpanGroup.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.ExpanGroup.ExpandedSize = New System.Drawing.Size(616, 404)
        Me.ExpanGroup.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.None
        Me.ExpanGroup.Location = New System.Drawing.Point(-2, 0)
        Me.ExpanGroup.Name = "ExpanGroup"
        Me.ExpanGroup.Size = New System.Drawing.Size(616, 404)
        Me.ExpanGroup.TabIndex = 0
        Me.ExpanGroup.Text = "Listado Plan de Cuentas..."
        Me.ExpanGroup.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.picAjax)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Button1)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtLimite)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.CmbOpcion)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.TxtBusca)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.dgvListado)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 16)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(610, 385)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'picAjax
        '
        Me.picAjax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjax.BackColor = System.Drawing.Color.White
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(4, 28)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(604, 352)
        Me.picAjax.TabIndex = 85
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button2.Location = New System.Drawing.Point(526, -14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 15)
        Me.Button2.TabIndex = 58
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(445, -14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 15)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtLimite
        '
        Appearance4.TextHAlignAsString = "Right"
        Me.txtLimite.Appearance = Appearance4
        Me.txtLimite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtLimite.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimite.Location = New System.Drawing.Point(389, -2)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(34, 24)
        Me.txtLimite.TabIndex = 56
        Me.txtLimite.Text = "20"
        '
        'CmbOpcion
        '
        Me.CmbOpcion.FormattingEnabled = True
        Me.CmbOpcion.Items.AddRange(New Object() {"Nombre", "Cuenta"})
        Me.CmbOpcion.Location = New System.Drawing.Point(22, 0)
        Me.CmbOpcion.Name = "CmbOpcion"
        Me.CmbOpcion.Size = New System.Drawing.Size(108, 21)
        Me.CmbOpcion.TabIndex = 4
        Me.CmbOpcion.TabStop = False
        '
        'TxtBusca
        '
        Me.TxtBusca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtBusca.Location = New System.Drawing.Point(137, 1)
        Me.TxtBusca.Name = "TxtBusca"
        Me.TxtBusca.Size = New System.Drawing.Size(215, 21)
        Me.TxtBusca.TabIndex = 0
        '
        'dgvListado
        '
        Me.dgvListado.AllowDrop = True
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Me.dgvListado.DisplayLayout.Appearance = Appearance1
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance6
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.dgvListado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvListado.Location = New System.Drawing.Point(2, 27)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(607, 354)
        Me.dgvListado.TabIndex = 1
        '
        'bwPlan
        '
        '
        'FrmConsulta_Plan_Ctas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(614, 403)
        Me.Controls.Add(Me.ExpanGroup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsulta_Plan_Ctas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan de Cuentas..."
        CType(Me.ExpanGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpanGroup.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBusca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpanGroup As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TxtBusca As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CmbOpcion As System.Windows.Forms.ComboBox
    Friend WithEvents txtLimite As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents bwPlan As System.ComponentModel.BackgroundWorker
End Class
