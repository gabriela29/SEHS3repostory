<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGrupo
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGrupo))
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.ContCat = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsDNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsDEditar = New System.Windows.Forms.ToolStripButton
        Me.tsDDelete = New System.Windows.Forms.ToolStripButton
        Me.tsCerrar = New System.Windows.Forms.ToolStripButton
        Me.txtLocaltionDoc = New Infragistics.Win.Misc.UltraButton
        Me.lbl = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.ContCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContCat.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.BackColor2 = System.Drawing.Color.White
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance19
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(491, 47)
        Me.UltraGroupBox4.TabIndex = 64
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel12
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance4.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance4
        Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(71, 6)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(414, 42)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Se Registra los Grupos en las que está clasificado el Catálogo de Productos..."
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(6, 7)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'ContCat
        '
        Me.ContCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.ContCat.ContentAreaAppearance = Appearance7
        Me.ContCat.Controls.Add(Me.lbl)
        Me.ContCat.Controls.Add(Me.dgvListado)
        Me.ContCat.Controls.Add(Me.ToolStrip1)
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ContCat.HeaderAppearance = Appearance1
        Me.ContCat.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.ContCat.Location = New System.Drawing.Point(0, 49)
        Me.ContCat.Name = "ContCat"
        Me.ContCat.Size = New System.Drawing.Size(489, 320)
        Me.ContCat.TabIndex = 66
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.Location = New System.Drawing.Point(9, 32)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(475, 261)
        Me.dgvListado.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDNuevo, Me.tsDEditar, Me.tsDDelete, Me.tsCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(483, 25)
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
        'tsDEditar
        '
        Me.tsDEditar.Image = CType(resources.GetObject("tsDEditar.Image"), System.Drawing.Image)
        Me.tsDEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDEditar.Name = "tsDEditar"
        Me.tsDEditar.Size = New System.Drawing.Size(78, 22)
        Me.tsDEditar.Text = "&Modificar"
        Me.tsDEditar.ToolTipText = "Modificar"
        '
        'tsDDelete
        '
        Me.tsDDelete.Image = CType(resources.GetObject("tsDDelete.Image"), System.Drawing.Image)
        Me.tsDDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDDelete.Name = "tsDDelete"
        Me.tsDDelete.Size = New System.Drawing.Size(70, 22)
        Me.tsDDelete.Text = "&Eliminar"
        '
        'tsCerrar
        '
        Me.tsCerrar.Image = CType(resources.GetObject("tsCerrar.Image"), System.Drawing.Image)
        Me.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCerrar.Name = "tsCerrar"
        Me.tsCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tsCerrar.Text = "Cerrar"
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
        Me.txtLocaltionDoc.Location = New System.Drawing.Point(4, 66)
        Me.txtLocaltionDoc.Name = "txtLocaltionDoc"
        Appearance54.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.txtLocaltionDoc.PressedAppearance = Appearance54
        Me.txtLocaltionDoc.Size = New System.Drawing.Size(31, 24)
        Me.txtLocaltionDoc.TabIndex = 69
        Me.txtLocaltionDoc.Text = "x"
        Me.txtLocaltionDoc.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lbl
        '
        Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.ForeColor = System.Drawing.Color.LightBlue
        Appearance14.TextVAlignAsString = "Top"
        Me.lbl.Appearance = Appearance14
        Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(12, 298)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(188, 17)
        Me.lbl.TabIndex = 87
        Me.lbl.Text = "0 registros"
        '
        'FrmGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(490, 370)
        Me.Controls.Add(Me.ContCat)
        Me.Controls.Add(Me.txtLocaltionDoc)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmGrupo"
        Me.ShowInTaskbar = False
        Me.Text = "Grupos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.ContCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContCat.ResumeLayout(False)
        Me.ContCat.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents ContCat As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLocaltionDoc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
End Class
