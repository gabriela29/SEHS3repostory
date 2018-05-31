<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos_Campania
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
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos_Campania))
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.lblProducto = New Infragistics.Win.Misc.UltraLabel()
    Me.cboCampania = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsdActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsAgregar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsEditar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsEliminar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsExcel = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.lbl = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.bwListado = New System.ComponentModel.BackgroundWorker()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.cboCampania, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.lblProducto)
    Me.gpCriterios.Controls.Add(Me.cboCampania)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(0, 0)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(696, 105)
    Me.gpCriterios.TabIndex = 6
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'lblProducto
    '
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.ForeColor = System.Drawing.Color.Navy
    Appearance2.TextVAlignAsString = "Top"
    Me.lblProducto.Appearance = Appearance2
    Me.lblProducto.Font = New System.Drawing.Font("Arial", 9.75!)
    Me.lblProducto.Location = New System.Drawing.Point(82, 13)
    Me.lblProducto.Name = "lblProducto"
    Me.lblProducto.Size = New System.Drawing.Size(566, 40)
    Me.lblProducto.TabIndex = 90
    Me.lblProducto.Text = "En esta ventana se configura los productos para suscripcion por año. Esta configu" &
    "ración es para todas las sucursales en sonsignación para colportaje."
    '
    'cboCampania
    '
    Appearance3.BackColor = System.Drawing.Color.White
    Me.cboCampania.Appearance = Appearance3
    Me.cboCampania.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance4.BackColor = System.Drawing.Color.White
    Me.cboCampania.DisplayLayout.Appearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.Transparent
    Me.cboCampania.DisplayLayout.Override.CardAreaAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.White
    Appearance6.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance6.FontData.BoldAsString = "True"
    Appearance6.FontData.Name = "Arial"
    Appearance6.FontData.SizeInPoints = 10.0!
    Appearance6.ForeColor = System.Drawing.Color.White
    Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboCampania.DisplayLayout.Override.HeaderAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboCampania.DisplayLayout.Override.RowSelectorAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboCampania.DisplayLayout.Override.SelectedRowAppearance = Appearance8
    Me.cboCampania.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboCampania.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboCampania.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboCampania.Location = New System.Drawing.Point(66, 70)
    Me.cboCampania.Name = "cboCampania"
    Me.cboCampania.Size = New System.Drawing.Size(182, 23)
    Me.cboCampania.TabIndex = 80
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(254, 61)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 32)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'UltraLabel12
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance9.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance9
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(66, 54)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(89, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "Campania"
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(6, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(70, 64)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance10.BackColor = System.Drawing.Color.White
    Appearance10.BackColor2 = System.Drawing.Color.White
    Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
    Me.UltraGroupBox1.ContentAreaAppearance = Appearance10
    Me.UltraGroupBox1.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox1.Controls.Add(Me.ToolStrip1)
    Me.UltraGroupBox1.Controls.Add(Me.lbl)
    Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
    Appearance12.BackColor = System.Drawing.Color.LightBlue
    Appearance12.BackColor2 = System.Drawing.Color.White
    Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraGroupBox1.HeaderAppearance = Appearance12
    Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
    Me.UltraGroupBox1.Location = New System.Drawing.Point(1, 106)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(695, 324)
    Me.UltraGroupBox1.TabIndex = 68
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(8, 5)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(679, 287)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 85
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackColor = System.Drawing.Color.White
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdActualizar, Me.ToolStripSeparator13, Me.tsAgregar, Me.ToolStripSeparator12, Me.tsEditar, Me.ToolStripSeparator1, Me.tsEliminar, Me.ToolStripSeparator2, Me.tsExcel, Me.ToolStripSeparator11, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    Me.ToolStrip1.Size = New System.Drawing.Size(689, 25)
    Me.ToolStrip1.TabIndex = 88
    Me.ToolStrip1.Text = "ToolStrip2"
    '
    'tsdActualizar
    '
    Me.tsdActualizar.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsdActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsdActualizar.Name = "tsdActualizar"
    Me.tsdActualizar.Size = New System.Drawing.Size(79, 22)
    Me.tsdActualizar.Text = "Actualizar"
    Me.tsdActualizar.ToolTipText = "Actualizar Saldos"
    '
    'ToolStripSeparator13
    '
    Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
    Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
    '
    'tsAgregar
    '
    Me.tsAgregar.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsAgregar.Name = "tsAgregar"
    Me.tsAgregar.Size = New System.Drawing.Size(69, 22)
    Me.tsAgregar.Text = "Agregar"
    '
    'ToolStripSeparator12
    '
    Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
    Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
    '
    'tsEditar
    '
    Me.tsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsEditar.Image = Global.Phoenix.My.Resources.Resources.application_edit
    Me.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsEditar.Name = "tsEditar"
    Me.tsEditar.Size = New System.Drawing.Size(23, 22)
    Me.tsEditar.Text = "Modificar"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.ForeColor = System.Drawing.SystemColors.Control
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsEliminar
    '
    Me.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsEliminar.Image = Global.Phoenix.My.Resources.Resources.deletemin
    Me.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsEliminar.Name = "tsEliminar"
    Me.tsEliminar.Size = New System.Drawing.Size(23, 22)
    Me.tsEliminar.Text = "Eliminar"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsExcel
    '
    Me.tsExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsExcel.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsExcel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsExcel.Name = "tsExcel"
    Me.tsExcel.Size = New System.Drawing.Size(23, 22)
    Me.tsExcel.Text = "Exportar Excel"
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
    '
    'tsDSalir
    '
    Me.tsDSalir.Image = CType(resources.GetObject("tsDSalir.Image"), System.Drawing.Image)
    Me.tsDSalir.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDSalir.Name = "tsDSalir"
    Me.tsDSalir.Size = New System.Drawing.Size(59, 22)
    Me.tsDSalir.Text = "&Cerrar"
    Me.tsDSalir.ToolTipText = "Cerrar Ventana"
    '
    'lbl
    '
    Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance11.ForeColor = System.Drawing.Color.LightBlue
    Appearance11.TextVAlignAsString = "Top"
    Me.lbl.Appearance = Appearance11
    Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl.Location = New System.Drawing.Point(12, 301)
    Me.lbl.Name = "lbl"
    Me.lbl.Size = New System.Drawing.Size(188, 17)
    Me.lbl.TabIndex = 86
    Me.lbl.Text = "0 registros"
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.dgvListado.Location = New System.Drawing.Point(6, 31)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(683, 265)
    Me.dgvListado.TabIndex = 87
    '
    'bwListado
    '
    '
    'FrmProductos_Campania
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(696, 432)
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmProductos_Campania"
    Me.ShowInTaskbar = False
    Me.Text = "Productos Campaña"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.cboCampania, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    Me.UltraGroupBox1.PerformLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblProducto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboCampania As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents bwListado As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsdActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
End Class
