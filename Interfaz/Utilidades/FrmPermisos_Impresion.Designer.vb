<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisos_Impresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisos_Impresion))
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.TpCliente = New System.Windows.Forms.ToolStrip()
        Me.tsActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TpNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TpModificar = New System.Windows.Forms.ToolStripButton()
        Me.TpEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tpCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.picAjax = New System.Windows.Forms.PictureBox()
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.TpCliente.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.UltraPictureBox1.TabIndex = 8
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.BackColor2 = System.Drawing.Color.White
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance18
        Me.UltraGroupBox1.Controls.Add(Me.TpCliente)
        Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.HeaderAppearance = Appearance1
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-3, 70)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(656, 323)
        Me.UltraGroupBox1.TabIndex = 9
        '
        'TpCliente
        '
        Me.TpCliente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TpCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator1, Me.TpNuevo, Me.TpModificar, Me.TpEliminar, Me.tpCerrar})
        Me.TpCliente.Location = New System.Drawing.Point(3, 3)
        Me.TpCliente.Name = "TpCliente"
        Me.TpCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TpCliente.Size = New System.Drawing.Size(650, 25)
        Me.TpCliente.TabIndex = 21
        Me.TpCliente.Text = "ToolStrip2"
        '
        'tsActualizar
        '
        Me.tsActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
        Me.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsActualizar.Name = "tsActualizar"
        Me.tsActualizar.Size = New System.Drawing.Size(79, 22)
        Me.tsActualizar.Text = "&Actualizar"
        Me.tsActualizar.ToolTipText = "Mostrar Registros"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TpNuevo
        '
        Me.TpNuevo.Image = CType(resources.GetObject("TpNuevo.Image"), System.Drawing.Image)
        Me.TpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpNuevo.Name = "TpNuevo"
        Me.TpNuevo.Size = New System.Drawing.Size(62, 22)
        Me.TpNuevo.Text = "&Nuevo"
        Me.TpNuevo.ToolTipText = "Nuevo"
        '
        'TpModificar
        '
        Me.TpModificar.Image = CType(resources.GetObject("TpModificar.Image"), System.Drawing.Image)
        Me.TpModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpModificar.Name = "TpModificar"
        Me.TpModificar.Size = New System.Drawing.Size(78, 22)
        Me.TpModificar.Text = "&Modificar"
        Me.TpModificar.ToolTipText = "Modificar"
        '
        'TpEliminar
        '
        Me.TpEliminar.Image = CType(resources.GetObject("TpEliminar.Image"), System.Drawing.Image)
        Me.TpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpEliminar.Name = "TpEliminar"
        Me.TpEliminar.Size = New System.Drawing.Size(70, 22)
        Me.TpEliminar.Text = "&Eliminar"
        '
        'tpCerrar
        '
        Me.tpCerrar.Image = CType(resources.GetObject("tpCerrar.Image"), System.Drawing.Image)
        Me.tpCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tpCerrar.Name = "tpCerrar"
        Me.tpCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tpCerrar.Text = "Cerrar"
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.Location = New System.Drawing.Point(4, 29)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(649, 294)
        Me.dgvListado.TabIndex = 1
        '
        'UltraLabel12
        '
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance13.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance13
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(72, 12)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(497, 15)
        Me.UltraLabel12.TabIndex = 32
        Me.UltraLabel12.Text = "  Almacén                                           "
        '
        'picAjax
        '
        Me.picAjax.BackColor = System.Drawing.Color.Transparent
        Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
        Me.picAjax.Location = New System.Drawing.Point(72, 40)
        Me.picAjax.Name = "picAjax"
        Me.picAjax.Size = New System.Drawing.Size(209, 24)
        Me.picAjax.TabIndex = 85
        Me.picAjax.TabStop = False
        Me.picAjax.Visible = False
        '
        'cboAlmacen
        '
        Appearance10.BackColor = System.Drawing.Color.LemonChiffon
        Appearance10.BackColor2 = System.Drawing.Color.White
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
        Me.cboAlmacen.Appearance = Appearance10
        Me.cboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance2.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.DisplayLayout.Appearance = Appearance2
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.FontData.BoldAsString = "True"
        Appearance19.FontData.Name = "Arial"
        Appearance19.FontData.SizeInPoints = 10.0!
        Appearance19.ForeColor = System.Drawing.Color.White
        Appearance19.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance21.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance21
        Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(72, 39)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(209, 25)
        Me.cboAlmacen.TabIndex = 84
        '
        'bwAlmacen
        '
        '
        'FrmPermisos_Impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(653, 393)
        Me.Controls.Add(Me.picAjax)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.UltraLabel12)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmPermisos_Impresion"
        Me.Text = "Gestión Permisos Impresión"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.TpCliente.ResumeLayout(False)
        Me.TpCliente.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TpCliente As System.Windows.Forms.ToolStrip
    Friend WithEvents TpNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TpModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TpEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tpCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents tsActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
