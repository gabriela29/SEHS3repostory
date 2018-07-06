<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBancoLis
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBancoLis))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.ContCat = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dgvListadobanco = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsDNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsDEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsDDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsCerrar = New System.Windows.Forms.ToolStripButton()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.ContCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContCat.SuspendLayout()
        CType(Me.dgvListadobanco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance1
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(3, 2)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(629, 70)
        Me.UltraGroupBox4.TabIndex = 65
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
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
        'ContCat
        '
        Me.ContCat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.ContCat.ContentAreaAppearance = Appearance2
        Me.ContCat.Controls.Add(Me.dgvListadobanco)
        Me.ContCat.Controls.Add(Me.ToolStrip1)
        Appearance3.BackColor = System.Drawing.Color.LightBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ContCat.HeaderAppearance = Appearance3
        Me.ContCat.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.ContCat.Location = New System.Drawing.Point(3, 72)
        Me.ContCat.Name = "ContCat"
        Me.ContCat.Size = New System.Drawing.Size(629, 375)
        Me.ContCat.TabIndex = 67
        '
        'dgvListadobanco
        '
        Me.dgvListadobanco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvListadobanco.Location = New System.Drawing.Point(3, 32)
        Me.dgvListadobanco.Name = "dgvListadobanco"
        Me.dgvListadobanco.Size = New System.Drawing.Size(623, 343)
        Me.dgvListadobanco.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDNuevo, Me.tsDEditar, Me.tsDDelete, Me.tsCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(623, 25)
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
        'FrmBancoLis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 459)
        Me.Controls.Add(Me.ContCat)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Name = "FrmBancoLis"
        Me.Text = "FrmBancoLis"
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.ContCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContCat.ResumeLayout(False)
        Me.ContCat.PerformLayout()
        CType(Me.dgvListadobanco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents ContCat As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvListadobanco As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsDNuevo As ToolStripButton
    Friend WithEvents tsDEditar As ToolStripButton
    Friend WithEvents tsDDelete As ToolStripButton
    Friend WithEvents tsCerrar As ToolStripButton
End Class
