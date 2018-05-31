<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInfoSEHS
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
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfoSEHS))
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.lblDNIRUC = New Infragistics.Win.Misc.UltraLabel()
    Me.LblNombre = New Infragistics.Win.Misc.UltraLabel()
    Me.BtnSeleccionar = New System.Windows.Forms.Button()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsdActualizar = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsExcelRes = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel()
    Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
    Me.picAjaxRes = New System.Windows.Forms.PictureBox()
    Me.dgvResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
    Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox3.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.lblDNIRUC)
    Me.gpCriterios.Controls.Add(Me.LblNombre)
    Me.gpCriterios.Controls.Add(Me.BtnSeleccionar)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(774, 88)
    Me.gpCriterios.TabIndex = 2
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'lblDNIRUC
    '
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance2.TextVAlignAsString = "Top"
    Me.lblDNIRUC.Appearance = Appearance2
    Me.lblDNIRUC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblDNIRUC.Location = New System.Drawing.Point(233, 17)
    Me.lblDNIRUC.Name = "lblDNIRUC"
    Me.lblDNIRUC.Size = New System.Drawing.Size(427, 15)
    Me.lblDNIRUC.TabIndex = 90
    '
    'LblNombre
    '
    Appearance3.BackColor = System.Drawing.Color.LemonChiffon
    Appearance3.BackColor2 = System.Drawing.Color.White
    Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
    Appearance3.ForeColor = System.Drawing.Color.MidnightBlue
    Appearance3.TextVAlignAsString = "Middle"
    Me.LblNombre.Appearance = Appearance3
    Me.LblNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNombre.Location = New System.Drawing.Point(110, 44)
    Me.LblNombre.Name = "LblNombre"
    Me.LblNombre.Size = New System.Drawing.Size(550, 23)
    Me.LblNombre.TabIndex = 38
    '
    'BtnSeleccionar
    '
    Me.BtnSeleccionar.BackColor = System.Drawing.Color.Transparent
    Me.BtnSeleccionar.FlatAppearance.BorderSize = 0
    Me.BtnSeleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.BtnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnSeleccionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnSeleccionar.Image = Global.Phoenix.My.Resources.Resources.find
    Me.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnSeleccionar.Location = New System.Drawing.Point(110, 13)
    Me.BtnSeleccionar.Name = "BtnSeleccionar"
    Me.BtnSeleccionar.Size = New System.Drawing.Size(117, 25)
    Me.BtnSeleccionar.TabIndex = 89
    Me.BtnSeleccionar.Text = "Seleccionar"
    Me.BtnSeleccionar.UseVisualStyleBackColor = False
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(4, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(100, 80)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'UltraGroupBox3
    '
    Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance4.BackColor = System.Drawing.Color.White
    Appearance4.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox3.ContentAreaAppearance = Appearance4
    Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
    Me.UltraGroupBox3.Controls.Add(Me.ToolStrip1)
    Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
    Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
    Me.UltraGroupBox3.Controls.Add(Me.dgvResumen)
    Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 90)
    Me.UltraGroupBox3.Name = "UltraGroupBox3"
    Me.UltraGroupBox3.Size = New System.Drawing.Size(770, 423)
    Me.UltraGroupBox3.TabIndex = 7
    Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackColor = System.Drawing.Color.White
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdActualizar, Me.ToolStripSeparator13, Me.tsExcelRes, Me.ToolStripSeparator1, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip1.Size = New System.Drawing.Size(764, 25)
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
    'tsExcelRes
    '
    Me.tsExcelRes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsExcelRes.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsExcelRes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsExcelRes.Name = "tsExcelRes"
    Me.tsExcelRes.Size = New System.Drawing.Size(23, 22)
    Me.tsExcelRes.Text = "Excel Lista"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
    'LblDeudaTotal
    '
    Me.LblDeudaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance5.BackColor = System.Drawing.Color.LemonChiffon
    Appearance5.BackColor2 = System.Drawing.Color.White
    Appearance5.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance5.TextHAlignAsString = "Right"
    Appearance5.TextVAlignAsString = "Middle"
    Me.LblDeudaTotal.Appearance = Appearance5
    Me.LblDeudaTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblDeudaTotal.Location = New System.Drawing.Point(505, 399)
    Me.LblDeudaTotal.Name = "LblDeudaTotal"
    Me.LblDeudaTotal.Size = New System.Drawing.Size(145, 17)
    Me.LblDeudaTotal.TabIndex = 87
    Me.LblDeudaTotal.Text = "0.00"
    '
    'lblRegistros_Res
    '
    Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance6.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance6.TextHAlignAsString = "Right"
    Appearance6.TextVAlignAsString = "Middle"
    Me.lblRegistros_Res.Appearance = Appearance6
    Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 400)
    Me.lblRegistros_Res.Name = "lblRegistros_Res"
    Me.lblRegistros_Res.Size = New System.Drawing.Size(107, 14)
    Me.lblRegistros_Res.TabIndex = 86
    Me.lblRegistros_Res.Text = "-"
    '
    'picAjaxRes
    '
    Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
    Me.picAjaxRes.Location = New System.Drawing.Point(3, 6)
    Me.picAjaxRes.Name = "picAjaxRes"
    Me.picAjaxRes.Size = New System.Drawing.Size(763, 381)
    Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxRes.TabIndex = 84
    Me.picAjaxRes.TabStop = False
    Me.picAjaxRes.Visible = False
    '
    'dgvResumen
    '
    Me.dgvResumen.AllowDrop = True
    Me.dgvResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance7.BackColor = System.Drawing.Color.White
    Me.dgvResumen.DisplayLayout.Appearance = Appearance7
    Me.dgvResumen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    Me.dgvResumen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
    Appearance8.BackColor = System.Drawing.Color.Transparent
    Me.dgvResumen.DisplayLayout.Override.CardAreaAppearance = Appearance8
    Me.dgvResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance9.FontData.BoldAsString = "True"
    Appearance9.FontData.Name = "Arial"
    Appearance9.FontData.SizeInPoints = 10.0!
    Appearance9.ForeColor = System.Drawing.Color.White
    Appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvResumen.DisplayLayout.Override.HeaderAppearance = Appearance9
    Me.dgvResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.RowSelectorAppearance = Appearance10
    Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.SelectedRowAppearance = Appearance11
    Me.dgvResumen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    Me.dgvResumen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvResumen.Location = New System.Drawing.Point(6, 28)
    Me.dgvResumen.Name = "dgvResumen"
    Me.dgvResumen.Size = New System.Drawing.Size(756, 365)
    Me.dgvResumen.TabIndex = 85
    '
    'bwLlenar_Res
    '
    '
    'FrmInfoSEHS
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(773, 514)
    Me.Controls.Add(Me.UltraGroupBox3)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmInfoSEHS"
    Me.Text = "INFO SEHS"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox3.ResumeLayout(False)
    Me.UltraGroupBox3.PerformLayout()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents BtnSeleccionar As System.Windows.Forms.Button
  Friend WithEvents LblNombre As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
  Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
  Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
  Friend WithEvents dgvResumen As Infragistics.Win.UltraWinGrid.UltraGrid
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tsdActualizar As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents tsExcelRes As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
  Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
  Friend WithEvents lblDNIRUC As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
