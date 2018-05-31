<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuenta_Detraccion
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuenta_Detraccion))
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsDAgregarCta = New System.Windows.Forms.ToolStripButton()
        Me.tsCerrar = New System.Windows.Forms.ToolStripButton()
        Me.tsActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.BackColor2 = System.Drawing.Color.White
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance19
        Me.UltraGroupBox4.Controls.Add(Me.cboAlmacen)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(1, 0)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(771, 85)
        Me.UltraGroupBox4.TabIndex = 65
        '
        'UltraLabel1
        '
        Appearance32.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance32.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance32.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance32
        Me.UltraLabel1.Location = New System.Drawing.Point(71, 29)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(445, 28)
        Me.UltraLabel1.TabIndex = 32
        Me.UltraLabel1.Text = "En esta ventana se configura la cuenta para la forma de pago de la detracción..."
        '
        'UltraLabel12
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance4.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance4
        Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(71, 6)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(489, 17)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "Tipos de documentos para los ingresos y salidas"
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
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox2.Controls.Add(Me.dgvListado)
        Me.UltraGroupBox2.Controls.Add(Me.ToolStrip1)
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox2.HeaderAppearance = Appearance1
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(7, 91)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(765, 389)
        Me.UltraGroupBox2.TabIndex = 67
        '
        'dgvListado
        '
        Me.dgvListado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance5.TextHAlignAsString = "Center"
        Me.dgvListado.DisplayLayout.CaptionAppearance = Appearance5
        Me.dgvListado.Location = New System.Drawing.Point(5, 33)
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.Size = New System.Drawing.Size(752, 352)
        Me.dgvListado.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator1, Me.tsDAgregarCta, Me.tsCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(759, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'tsDAgregarCta
        '
        Me.tsDAgregarCta.Image = Global.Phoenix.My.Resources.Resources.application_form_edit
        Me.tsDAgregarCta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDAgregarCta.Name = "tsDAgregarCta"
        Me.tsDAgregarCta.Size = New System.Drawing.Size(120, 22)
        Me.tsDAgregarCta.Text = "&Actualizar Cuenta"
        Me.tsDAgregarCta.ToolTipText = "Agregar Nro Cuenta"
        '
        'tsCerrar
        '
        Me.tsCerrar.Image = CType(resources.GetObject("tsCerrar.Image"), System.Drawing.Image)
        Me.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCerrar.Name = "tsCerrar"
        Me.tsCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tsCerrar.Text = "Cerrar"
        '
        'tsActualizar
        '
        Me.tsActualizar.Image = Global.Phoenix.My.Resources.Resources.Refresh
        Me.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsActualizar.Name = "tsActualizar"
        Me.tsActualizar.Size = New System.Drawing.Size(79, 22)
        Me.tsActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cboAlmacen
        '
        Appearance26.BackColor = System.Drawing.Color.LemonChiffon
        Me.cboAlmacen.Appearance = Appearance26
        Me.cboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance14.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.DisplayLayout.Appearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.FontData.BoldAsString = "True"
        Appearance16.FontData.Name = "Arial"
        Appearance16.FontData.SizeInPoints = 10.0!
        Appearance16.ForeColor = System.Drawing.Color.White
        Appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance18
        Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(71, 57)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(222, 22)
        Me.cboAlmacen.TabIndex = 33
        '
        'FrmCuenta_Detraccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(772, 492)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmCuenta_Detraccion"
        Me.ShowInTaskbar = False
        Me.Text = "Cuenta Detraccion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsDAgregarCta As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
