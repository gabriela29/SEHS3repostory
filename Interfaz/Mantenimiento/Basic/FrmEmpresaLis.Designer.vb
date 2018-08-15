<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmpresaLis
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpresaLis))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lbl = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.txtnombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtruc = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBuscar = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.TpCliente = New System.Windows.Forms.ToolStrip()
        Me.TpNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TpModificar = New System.Windows.Forms.ToolStripButton()
        Me.TpEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReporte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dgvListadoempresa = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtLocaltionDoc2 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        CType(Me.txtnombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpCliente.SuspendLayout()
        CType(Me.dgvListadoempresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance1.ForeColor = System.Drawing.Color.LightBlue
        Appearance1.TextVAlignAsString = "Top"
        Me.lbl.Appearance = Appearance1
        Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(272, 409)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(188, 17)
        Me.lbl.TabIndex = 88
        Me.lbl.Text = "0 registros"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.LightBlue
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.ForeColor = System.Drawing.Color.SteelBlue
        Appearance2.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(66, -2)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(542, 27)
        Me.UltraLabel1.TabIndex = 89
        Me.UltraLabel1.Text = "EMPRESA"
        '
        'btnBuscar
        '
        Appearance3.BackColor = System.Drawing.Color.LightBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.btnBuscar.Appearance = Appearance3
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnBuscar.Location = New System.Drawing.Point(526, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnBuscar.PressedAppearance = Appearance4
        Me.btnBuscar.Size = New System.Drawing.Size(80, 23)
        Me.btnBuscar.TabIndex = 94
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtnombre
        '
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Me.txtnombre.Appearance = Appearance5
        Me.txtnombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(294, 29)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.NullText = "Nombre"
        Appearance6.ForeColor = System.Drawing.Color.DarkGray
        Me.txtnombre.NullTextAppearance = Appearance6
        Me.txtnombre.Size = New System.Drawing.Size(225, 22)
        Me.txtnombre.TabIndex = 92
        '
        'txtruc
        '
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.txtruc.Appearance = Appearance7
        Me.txtruc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtruc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.Location = New System.Drawing.Point(143, 29)
        Me.txtruc.MaxLength = 50
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NullText = "RUC"
        Appearance8.ForeColor = System.Drawing.Color.DarkGray
        Me.txtruc.NullTextAppearance = Appearance8
        Me.txtruc.Size = New System.Drawing.Size(145, 22)
        Me.txtruc.TabIndex = 91
        '
        'lblBuscar
        '
        Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance9.ForeColor = System.Drawing.Color.SteelBlue
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Top"
        Me.lblBuscar.Appearance = Appearance9
        Me.lblBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(67, 32)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(70, 17)
        Me.lblBuscar.TabIndex = 90
        Me.lblBuscar.Text = "Buscar:"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.LightBlue
        Appearance10.TextVAlignAsString = "Top"
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(6, 361)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(188, 17)
        Me.UltraLabel2.TabIndex = 87
        Me.UltraLabel2.Text = "0 registros"
        '
        'TpCliente
        '
        Me.TpCliente.BackColor = System.Drawing.Color.White
        Me.TpCliente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TpCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TpNuevo, Me.TpModificar, Me.TpEliminar, Me.ToolStripSeparator1, Me.tsReporte, Me.ToolStripSeparator3, Me.tpCerrar})
        Me.TpCliente.Location = New System.Drawing.Point(3, 3)
        Me.TpCliente.Name = "TpCliente"
        Me.TpCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TpCliente.Size = New System.Drawing.Size(598, 25)
        Me.TpCliente.TabIndex = 21
        Me.TpCliente.Text = "ToolStrip2"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsReporte
        '
        Me.tsReporte.Image = CType(resources.GetObject("tsReporte.Image"), System.Drawing.Image)
        Me.tsReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReporte.Name = "tsReporte"
        Me.tsReporte.Size = New System.Drawing.Size(68, 22)
        Me.tsReporte.Text = "Reporte"
        Me.tsReporte.ToolTipText = "Listado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tpCerrar
        '
        Me.tpCerrar.Image = CType(resources.GetObject("tpCerrar.Image"), System.Drawing.Image)
        Me.tpCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tpCerrar.Name = "tpCerrar"
        Me.tpCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tpCerrar.Text = "Cerrar"
        '
        'dgvListadoempresa
        '
        Me.dgvListadoempresa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoempresa.Location = New System.Drawing.Point(2, 44)
        Me.dgvListadoempresa.Name = "dgvListadoempresa"
        Me.dgvListadoempresa.Size = New System.Drawing.Size(599, 311)
        Me.dgvListadoempresa.TabIndex = 1
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.BackColor = System.Drawing.Color.White
        Appearance11.BackColor2 = System.Drawing.Color.White
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance11
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.TpCliente)
        Me.UltraGroupBox1.Controls.Add(Me.dgvListadoempresa)
        Me.UltraGroupBox1.Controls.Add(Me.txtLocaltionDoc2)
        Appearance14.BackColor = System.Drawing.Color.LightBlue
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.HeaderAppearance = Appearance14
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 58)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(604, 381)
        Me.UltraGroupBox1.TabIndex = 95
        '
        'txtLocaltionDoc2
        '
        Appearance12.BackColor = System.Drawing.Color.LightBlue
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.BorderColor = System.Drawing.Color.White
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Appearance12.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.txtLocaltionDoc2.Appearance = Appearance12
        Me.txtLocaltionDoc2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.txtLocaltionDoc2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.txtLocaltionDoc2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocaltionDoc2.Location = New System.Drawing.Point(0, 4)
        Me.txtLocaltionDoc2.Name = "txtLocaltionDoc2"
        Appearance13.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.txtLocaltionDoc2.PressedAppearance = Appearance13
        Me.txtLocaltionDoc2.Size = New System.Drawing.Size(39, 28)
        Me.txtLocaltionDoc2.TabIndex = 97
        Me.txtLocaltionDoc2.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 1)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(58, 50)
        Me.UltraPictureBox1.TabIndex = 96
        '
        'FrmEmpresaLis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(608, 438)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.lbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEmpresaLis"
        Me.Text = "Empresa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtnombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpCliente.ResumeLayout(False)
        Me.TpCliente.PerformLayout()
        CType(Me.dgvListadoempresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtnombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtruc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblBuscar As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TpCliente As ToolStrip
    Friend WithEvents TpNuevo As ToolStripButton
    Friend WithEvents TpModificar As ToolStripButton
    Friend WithEvents TpEliminar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsReporte As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tpCerrar As ToolStripButton
    Friend WithEvents dgvListadoempresa As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents txtLocaltionDoc2 As Infragistics.Win.Misc.UltraButton
End Class
