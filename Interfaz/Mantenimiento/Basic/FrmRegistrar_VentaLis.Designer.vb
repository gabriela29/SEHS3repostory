<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistrar_VentaLis
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrar_VentaLis))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lbl = New Infragistics.Win.Misc.UltraLabel()
        Me.TpCliente = New System.Windows.Forms.ToolStrip()
        Me.TpNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TpModificar = New System.Windows.Forms.ToolStripButton()
        Me.TpEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReporte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dgvListadoregis = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtLocaltionDoc3 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.lblBuscar = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtmes = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtanio = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtLimite = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtalmacen = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtcodigo_per = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.TpCliente.SuspendLayout()
        CType(Me.dgvListadoregis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtmes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtanio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtalmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodigo_per, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lbl.Location = New System.Drawing.Point(6, 370)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(188, 28)
        Me.lbl.TabIndex = 87
        Me.lbl.Text = "0 registros"
        '
        'TpCliente
        '
        Me.TpCliente.BackColor = System.Drawing.Color.White
        Me.TpCliente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TpCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TpNuevo, Me.TpModificar, Me.TpEliminar, Me.ToolStripSeparator1, Me.tsReporte, Me.ToolStripSeparator3, Me.tpCerrar})
        Me.TpCliente.Location = New System.Drawing.Point(3, 3)
        Me.TpCliente.Name = "TpCliente"
        Me.TpCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TpCliente.Size = New System.Drawing.Size(732, 25)
        Me.TpCliente.TabIndex = 21
        Me.TpCliente.Text = "ToolStrip2"
        '
        'TpNuevo
        '
        Me.TpNuevo.Image = Global.Phoenix.My.Resources.Resources.add
        Me.TpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpNuevo.Name = "TpNuevo"
        Me.TpNuevo.Size = New System.Drawing.Size(62, 22)
        Me.TpNuevo.Text = "&Nuevo"
        Me.TpNuevo.ToolTipText = "Nuevo"
        '
        'TpModificar
        '
        Me.TpModificar.Image = Global.Phoenix.My.Resources.Resources.application_form_edit
        Me.TpModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TpModificar.Name = "TpModificar"
        Me.TpModificar.Size = New System.Drawing.Size(78, 22)
        Me.TpModificar.Text = "&Modificar"
        Me.TpModificar.ToolTipText = "Modificar"
        '
        'TpEliminar
        '
        Me.TpEliminar.Image = Global.Phoenix.My.Resources.Resources.cancel
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
        Me.tsReporte.Image = Global.Phoenix.My.Resources.Resources.monitor
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
        Me.tpCerrar.Image = Global.Phoenix.My.Resources.Resources.Salir
        Me.tpCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tpCerrar.Name = "tpCerrar"
        Me.tpCerrar.Size = New System.Drawing.Size(59, 22)
        Me.tpCerrar.Text = "Cerrar"
        '
        'dgvListadoregis
        '
        Me.dgvListadoregis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoregis.Location = New System.Drawing.Point(11, 31)
        Me.dgvListadoregis.Name = "dgvListadoregis"
        Me.dgvListadoregis.Size = New System.Drawing.Size(734, 333)
        Me.dgvListadoregis.TabIndex = 1
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance2
        Me.UltraGroupBox1.Controls.Add(Me.dgvListadoregis)
        Me.UltraGroupBox1.Controls.Add(Me.lbl)
        Me.UltraGroupBox1.Controls.Add(Me.TpCliente)
        Me.UltraGroupBox1.Controls.Add(Me.txtLocaltionDoc3)
        Appearance5.BackColor = System.Drawing.Color.LightBlue
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.HeaderAppearance = Appearance5
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(1, 74)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(738, 397)
        Me.UltraGroupBox1.TabIndex = 74
        '
        'txtLocaltionDoc3
        '
        Appearance3.BackColor = System.Drawing.Color.LightBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.txtLocaltionDoc3.Appearance = Appearance3
        Me.txtLocaltionDoc3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.txtLocaltionDoc3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.txtLocaltionDoc3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocaltionDoc3.Location = New System.Drawing.Point(6, 15)
        Me.txtLocaltionDoc3.Name = "txtLocaltionDoc3"
        Appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.txtLocaltionDoc3.PressedAppearance = Appearance4
        Me.txtLocaltionDoc3.Size = New System.Drawing.Size(48, 38)
        Me.txtLocaltionDoc3.TabIndex = 98
        Me.txtLocaltionDoc3.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(1, -2)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(56, 50)
        Me.UltraPictureBox1.TabIndex = 84
        '
        'btnBuscar
        '
        Appearance6.BackColor = System.Drawing.Color.LightBlue
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.btnBuscar.Appearance = Appearance6
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnBuscar.Location = New System.Drawing.Point(481, 46)
        Me.btnBuscar.Name = "btnBuscar"
        Appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnBuscar.PressedAppearance = Appearance7
        Me.btnBuscar.Size = New System.Drawing.Size(80, 23)
        Me.btnBuscar.TabIndex = 83
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblBuscar
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.SteelBlue
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Top"
        Me.lblBuscar.Appearance = Appearance8
        Me.lblBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(12, 49)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(70, 17)
        Me.lblBuscar.TabIndex = 79
        Me.lblBuscar.Text = "Buscar:"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.LightBlue
        Appearance9.BackColor2 = System.Drawing.Color.White
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.ForeColor = System.Drawing.Color.SteelBlue
        Appearance9.TextVAlignAsString = "Top"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(63, -2)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(676, 45)
        Me.UltraLabel1.TabIndex = 78
        Me.UltraLabel1.Text = "REGISTRO DE VENTAS"
        '
        'txtmes
        '
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.txtmes.Appearance = Appearance10
        Me.txtmes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtmes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmes.Location = New System.Drawing.Point(281, 45)
        Me.txtmes.MaxLength = 50
        Me.txtmes.Name = "txtmes"
        Me.txtmes.NullText = "Mes"
        Appearance11.ForeColor = System.Drawing.Color.DarkGray
        Me.txtmes.NullTextAppearance = Appearance11
        Me.txtmes.Size = New System.Drawing.Size(102, 22)
        Me.txtmes.TabIndex = 85
        '
        'txtanio
        '
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Me.txtanio.Appearance = Appearance12
        Me.txtanio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtanio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(389, 44)
        Me.txtanio.MaxLength = 50
        Me.txtanio.Name = "txtanio"
        Me.txtanio.NullText = "Año"
        Appearance13.ForeColor = System.Drawing.Color.DarkGray
        Me.txtanio.NullTextAppearance = Appearance13
        Me.txtanio.Size = New System.Drawing.Size(86, 22)
        Me.txtanio.TabIndex = 86
        '
        'txtLimite
        '
        Appearance14.ForeColor = System.Drawing.Color.Navy
        Appearance14.TextHAlignAsString = "Right"
        Me.txtLimite.Appearance = Appearance14
        Me.txtLimite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtLimite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimite.Location = New System.Drawing.Point(578, 44)
        Me.txtLimite.MaxLength = 50
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(63, 22)
        Me.txtLimite.TabIndex = 87
        Me.txtLimite.Text = "50"
        '
        'txtalmacen
        '
        Appearance15.ForeColor = System.Drawing.Color.Navy
        Me.txtalmacen.Appearance = Appearance15
        Me.txtalmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtalmacen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalmacen.Location = New System.Drawing.Point(178, 46)
        Me.txtalmacen.MaxLength = 50
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.NullText = "Almacen"
        Appearance16.ForeColor = System.Drawing.Color.DarkGray
        Me.txtalmacen.NullTextAppearance = Appearance16
        Me.txtalmacen.Size = New System.Drawing.Size(97, 22)
        Me.txtalmacen.TabIndex = 80
        '
        'txtcodigo_per
        '
        Appearance17.ForeColor = System.Drawing.Color.Navy
        Me.txtcodigo_per.Appearance = Appearance17
        Me.txtcodigo_per.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodigo_per.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo_per.Location = New System.Drawing.Point(88, 46)
        Me.txtcodigo_per.MaxLength = 50
        Me.txtcodigo_per.Name = "txtcodigo_per"
        Me.txtcodigo_per.NullText = "Codigo"
        Appearance18.ForeColor = System.Drawing.Color.DarkGray
        Me.txtcodigo_per.NullTextAppearance = Appearance18
        Me.txtcodigo_per.Size = New System.Drawing.Size(84, 22)
        Me.txtcodigo_per.TabIndex = 88
        '
        'FrmRegistrar_VentaLis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(738, 472)
        Me.Controls.Add(Me.txtcodigo_per)
        Me.Controls.Add(Me.txtLimite)
        Me.Controls.Add(Me.txtanio)
        Me.Controls.Add(Me.txtmes)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtalmacen)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRegistrar_VentaLis"
        Me.Text = "Registro de Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TpCliente.ResumeLayout(False)
        Me.TpCliente.PerformLayout()
        CType(Me.dgvListadoregis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtmes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtanio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtalmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodigo_per, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TpCliente As ToolStrip
    Friend WithEvents TpNuevo As ToolStripButton
    Friend WithEvents TpModificar As ToolStripButton
    Friend WithEvents TpEliminar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsReporte As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tpCerrar As ToolStripButton
    Friend WithEvents dgvListadoregis As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblBuscar As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtmes As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtanio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtLimite As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtalmacen As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtLocaltionDoc3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtcodigo_per As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
