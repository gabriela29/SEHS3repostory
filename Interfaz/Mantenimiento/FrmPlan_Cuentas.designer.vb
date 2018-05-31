<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlan_Cuentas
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlan_Cuentas))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtLimite = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnMostrar = New Infragistics.Win.Misc.UltraButton
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.ChkCta = New System.Windows.Forms.CheckBox
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsDNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsDEditar = New System.Windows.Forms.ToolStripButton
        Me.tsDDelete = New System.Windows.Forms.ToolStripButton
        Me.tsCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.txtLocaltionDoc = New Infragistics.Win.Misc.UltraButton
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.TextHAlignAsString = "Center"
        Me.dgvListado.DisplayLayout.CaptionAppearance = Appearance5
        Me.dgvListado.Location = New System.Drawing.Point(3, 82)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(610, 292)
        Me.dgvListado.TabIndex = 1
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.BackColor2 = System.Drawing.Color.White
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance19
        Me.UltraGroupBox4.Controls.Add(Me.txtLimite)
        Me.UltraGroupBox4.Controls.Add(Me.btnMostrar)
        Me.UltraGroupBox4.Controls.Add(Me.txtBuscar)
        Me.UltraGroupBox4.Controls.Add(Me.ChkCta)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(-1, -2)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(620, 54)
        Me.UltraGroupBox4.TabIndex = 63
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtLimite
        '
        Appearance4.TextHAlignAsString = "Right"
        Me.txtLimite.Appearance = Appearance4
        Me.txtLimite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtLimite.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimite.Location = New System.Drawing.Point(397, 23)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(34, 24)
        Me.txtLimite.TabIndex = 55
        Me.txtLimite.Text = "50"
        '
        'btnMostrar
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnMostrar.Appearance = Appearance2
        Me.btnMostrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnMostrar.Location = New System.Drawing.Point(437, 23)
        Me.btnMostrar.Name = "btnMostrar"
        Appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnMostrar.PressedAppearance = Appearance3
        Me.btnMostrar.Size = New System.Drawing.Size(58, 22)
        Me.btnMostrar.TabIndex = 54
        Me.btnMostrar.Text = "&Ver"
        Me.btnMostrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(176, 25)
        Me.txtBuscar.MaxLength = 50
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(217, 22)
        Me.txtBuscar.TabIndex = 33
        '
        'ChkCta
        '
        Me.ChkCta.AutoSize = True
        Me.ChkCta.BackColor = System.Drawing.Color.Transparent
        Me.ChkCta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCta.ForeColor = System.Drawing.Color.Navy
        Me.ChkCta.Location = New System.Drawing.Point(71, 27)
        Me.ChkCta.Name = "ChkCta"
        Me.ChkCta.Size = New System.Drawing.Size(99, 18)
        Me.ChkCta.TabIndex = 32
        Me.ChkCta.Text = "Por Cuenta"
        Me.ChkCta.UseVisualStyleBackColor = False
        '
        'UltraLabel12
        '
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance6.ForeColor = System.Drawing.Color.SteelBlue
        Appearance6.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance6
        Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(71, 6)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(543, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Se Recomienda la responsable manipulación, para la consistencia de los reportes."
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'UltraGroupBox2
        '
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
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 51)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(335, 31)
        Me.UltraGroupBox2.TabIndex = 65
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDNuevo, Me.tsDEditar, Me.tsDDelete, Me.tsCerrar, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(329, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'tsDNuevo
        '
        Me.tsDNuevo.Image = CType(resources.GetObject("tsDNuevo.Image"), System.Drawing.Image)
        Me.tsDNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDNuevo.Name = "tsDNuevo"
        Me.tsDNuevo.Size = New System.Drawing.Size(58, 22)
        Me.tsDNuevo.Text = "&Nuevo"
        Me.tsDNuevo.ToolTipText = "Nuevo"
        '
        'tsDEditar
        '
        Me.tsDEditar.Image = CType(resources.GetObject("tsDEditar.Image"), System.Drawing.Image)
        Me.tsDEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDEditar.Name = "tsDEditar"
        Me.tsDEditar.Size = New System.Drawing.Size(70, 22)
        Me.tsDEditar.Text = "&Modificar"
        Me.tsDEditar.ToolTipText = "Modificar"
        '
        'tsDDelete
        '
        Me.tsDDelete.Image = CType(resources.GetObject("tsDDelete.Image"), System.Drawing.Image)
        Me.tsDDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDDelete.Name = "tsDDelete"
        Me.tsDDelete.Size = New System.Drawing.Size(63, 22)
        Me.tsDDelete.Text = "&Eliminar"
        '
        'tsCerrar
        '
        Me.tsCerrar.Image = CType(resources.GetObject("tsCerrar.Image"), System.Drawing.Image)
        Me.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCerrar.Name = "tsCerrar"
        Me.tsCerrar.Size = New System.Drawing.Size(58, 22)
        Me.tsCerrar.Text = "Cerrar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'txtLocaltionDoc
        '
        Appearance53.BackColor = System.Drawing.Color.LightBlue
        Appearance53.BackColor2 = System.Drawing.Color.White
        Appearance53.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance53.ForeColor = System.Drawing.Color.Navy
        Appearance53.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.txtLocaltionDoc.Appearance = Appearance53
        Me.txtLocaltionDoc.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.txtLocaltionDoc.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.txtLocaltionDoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocaltionDoc.Location = New System.Drawing.Point(5, 65)
        Me.txtLocaltionDoc.Name = "txtLocaltionDoc"
        Appearance54.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.txtLocaltionDoc.PressedAppearance = Appearance54
        Me.txtLocaltionDoc.Size = New System.Drawing.Size(29, 17)
        Me.txtLocaltionDoc.TabIndex = 66
        Me.txtLocaltionDoc.Text = "x"
        Me.txtLocaltionDoc.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'FrmPlan_Cuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(618, 376)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.txtLocaltionDoc)
        Me.MinimizeBox = False
        Me.Name = "FrmPlan_Cuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listado Plan de Cuentas..."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLocaltionDoc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ChkCta As System.Windows.Forms.CheckBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtLimite As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnMostrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
