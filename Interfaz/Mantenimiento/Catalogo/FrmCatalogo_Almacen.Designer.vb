<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatalogo_Almacen
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
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatalogo_Almacen))
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.lbl = New Infragistics.Win.Misc.UltraLabel()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.TpCliente = New System.Windows.Forms.ToolStrip()
    Me.tsActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsKardex = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsUbicacion = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsPrevioVta = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsReporte = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.tpCerrar = New System.Windows.Forms.ToolStripButton()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.txtFilas = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtBuscar = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.lblBuscar = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.utExcel = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.bwLlenar_Grid = New System.ComponentModel.BackgroundWorker()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TpCliente.SuspendLayout()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.txtFilas, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackColor2 = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
    Me.UltraGroupBox1.ContentAreaAppearance = Appearance1
    Me.UltraGroupBox1.Controls.Add(Me.lbl)
    Me.UltraGroupBox1.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
    Me.UltraGroupBox1.Controls.Add(Me.TpCliente)
    Appearance4.BackColor = System.Drawing.Color.LightBlue
    Appearance4.BackColor2 = System.Drawing.Color.White
    Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraGroupBox1.HeaderAppearance = Appearance4
    Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
    Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 94)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(777, 395)
    Me.UltraGroupBox1.TabIndex = 67
    '
    'lbl
    '
    Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.ForeColor = System.Drawing.Color.LightBlue
    Appearance2.TextVAlignAsString = "Top"
    Me.lbl.Appearance = Appearance2
    Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl.Location = New System.Drawing.Point(12, 372)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(188, 17)
    Me.lbl.TabIndex = 86
    Me.lbl.Text = "0 registros"
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(11, 30)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(753, 333)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 85
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance3.BackColor = System.Drawing.Color.White
    Me.dgvListado.DisplayLayout.Appearance = Appearance3
    UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
    Me.dgvListado.Location = New System.Drawing.Point(6, 30)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(764, 338)
    Me.dgvListado.TabIndex = 22
    Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    '
    'TpCliente
    '
    Me.TpCliente.BackColor = System.Drawing.Color.White
    Me.TpCliente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.TpCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar, Me.ToolStripSeparator4, Me.tsKardex, Me.ToolStripSeparator2, Me.tsUbicacion, Me.ToolStripSeparator1, Me.tsPrevioVta, Me.ToolStripSeparator5, Me.tsReporte, Me.ToolStripSeparator3, Me.tpCerrar})
    Me.TpCliente.Location = New System.Drawing.Point(3, 3)
    Me.TpCliente.Name = "TpCliente"
    Me.TpCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.TpCliente.Size = New System.Drawing.Size(771, 25)
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
    Me.tsActualizar.ToolTipText = "Mostrar Productos"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'tsKardex
    '
    Me.tsKardex.Image = Global.Phoenix.My.Resources.Resources.zconcepto
    Me.tsKardex.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsKardex.Name = "tsKardex"
    Me.tsKardex.Size = New System.Drawing.Size(62, 22)
    Me.tsKardex.Text = "Kardex"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsUbicacion
    '
    Me.tsUbicacion.Image = Global.Phoenix.My.Resources.Resources.application_view_tile
    Me.tsUbicacion.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsUbicacion.Name = "tsUbicacion"
    Me.tsUbicacion.Size = New System.Drawing.Size(80, 22)
    Me.tsUbicacion.Text = "Ubicación"
    Me.tsUbicacion.ToolTipText = "Definir su ubicación"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsPrevioVta
    '
    Me.tsPrevioVta.Image = Global.Phoenix.My.Resources.Resources.money
    Me.tsPrevioVta.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsPrevioVta.Name = "tsPrevioVta"
    Me.tsPrevioVta.Size = New System.Drawing.Size(92, 22)
    Me.tsPrevioVta.Text = "Precio Venta"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
    '
    'tsReporte
    '
    Me.tsReporte.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsReporte.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsReporte.Name = "tsReporte"
    Me.tsReporte.Size = New System.Drawing.Size(99, 22)
    Me.tsReporte.Text = "Exportar Excel"
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
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance5.BackColor = System.Drawing.Color.CornflowerBlue
    Appearance5.BackColor2 = System.Drawing.Color.White
    Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop20Bright
    Me.gpCriterios.ContentAreaAppearance = Appearance5
    Me.gpCriterios.Controls.Add(Me.txtFilas)
    Me.gpCriterios.Controls.Add(Me.txtBuscar)
    Me.gpCriterios.Controls.Add(Me.lblBuscar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel1)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(779, 95)
    Me.gpCriterios.TabIndex = 69
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'txtFilas
    '
    Appearance6.ForeColor = System.Drawing.Color.Navy
    Appearance6.TextHAlignAsString = "Right"
    Me.txtFilas.Appearance = Appearance6
    Me.txtFilas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtFilas.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtFilas.Location = New System.Drawing.Point(479, 60)
    Me.txtFilas.MaxLength = 50
    Me.txtFilas.Name = "txtFilas"
    Me.txtFilas.Size = New System.Drawing.Size(80, 22)
    Me.txtFilas.TabIndex = 94
    Me.txtFilas.Text = "50"
    '
    'txtBuscar
    '
    Appearance7.ForeColor = System.Drawing.Color.Navy
    Me.txtBuscar.Appearance = Appearance7
    Me.txtBuscar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtBuscar.Location = New System.Drawing.Point(293, 60)
    Me.txtBuscar.MaxLength = 50
    Me.txtBuscar.Name = "txtBuscar"
    Me.txtBuscar.Size = New System.Drawing.Size(159, 22)
    Me.txtBuscar.TabIndex = 93
    '
    'lblBuscar
    '
    Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance8.ForeColor = System.Drawing.Color.SteelBlue
    Appearance8.TextHAlignAsString = "Center"
    Appearance8.TextVAlignAsString = "Top"
    Me.lblBuscar.Appearance = Appearance8
    Me.lblBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblBuscar.Location = New System.Drawing.Point(293, 38)
    Me.lblBuscar.Name = "lblBuscar"
    Me.lblBuscar.Size = New System.Drawing.Size(159, 17)
    Me.lblBuscar.TabIndex = 92
    Me.lblBuscar.Text = "Ingrese Nombre:"
    '
    'UltraLabel1
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.Color.Navy
    Appearance9.TextVAlignAsString = "Top"
    Me.UltraLabel1.Appearance = Appearance9
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel1.Location = New System.Drawing.Point(96, 6)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(609, 28)
    Me.UltraLabel1.TabIndex = 91
    Me.UltraLabel1.Text = "CATALOTOGO DE PRODUCTOS POR ALMACÉN"
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(7, 6)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(83, 69)
    Me.UltraPictureBox1.TabIndex = 68
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(609, 42)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'UltraLabel12
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.Color.SteelBlue
    Appearance10.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance10
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(96, 40)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(191, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "      Almacén                                          "
    '
    'cboAlmacen
    '
    Appearance11.BackColor = System.Drawing.Color.LemonChiffon
    Me.cboAlmacen.Appearance = Appearance11
    Appearance12.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance12
    Appearance13.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance13
    Appearance14.BackColor = System.Drawing.Color.White
    Appearance14.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance14.FontData.BoldAsString = "True"
    Appearance14.FontData.Name = "Arial"
    Appearance14.FontData.SizeInPoints = 10.0!
    Appearance14.ForeColor = System.Drawing.Color.White
    Appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance14
    Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance15
    Appearance16.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance16.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance16
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(96, 59)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(191, 23)
    Me.cboAlmacen.TabIndex = 1
    '
    'bwLlenar_Grid
    '
    '
    'FrmCatalogo_Almacen
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(778, 492)
    Me.Controls.Add(Me.gpCriterios)
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmCatalogo_Almacen"
    Me.ShowInTaskbar = False
    Me.Text = "Catalogo por Almacén"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    Me.UltraGroupBox1.PerformLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TpCliente.ResumeLayout(False)
    Me.TpCliente.PerformLayout()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.txtFilas, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
  Private WithEvents picAjaxBig As PictureBox
  Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
  Friend WithEvents TpCliente As ToolStrip
  Friend WithEvents tsActualizar As ToolStripButton
  Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Friend WithEvents tsKardex As ToolStripButton
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Friend WithEvents tsReporte As ToolStripButton
  Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
  Friend WithEvents tpCerrar As ToolStripButton
  Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents BtnMostrar As Button
  Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents utExcel As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
  Friend WithEvents bwLlenar_Grid As System.ComponentModel.BackgroundWorker
  Friend WithEvents txtBuscar As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents lblBuscar As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtFilas As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents tsUbicacion As ToolStripButton
  Friend WithEvents tsPrevioVta As ToolStripButton
  Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
