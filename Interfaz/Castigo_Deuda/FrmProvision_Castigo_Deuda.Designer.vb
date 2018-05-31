<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProvision_Castigo_Deuda
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProvision_Castigo_Deuda))
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.chkTodos = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsDActualizar = New System.Windows.Forms.ToolStripButton()
    Me.tsDNuevo = New System.Windows.Forms.ToolStripButton()
    Me.tsDEditar = New System.Windows.Forms.ToolStripButton()
    Me.tsDDelete = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsExcel = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDReporte = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsCerrar = New System.Windows.Forms.ToolStripButton()
    Me.LblTotal = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.bwLlenar_Grid = New System.ComponentModel.BackgroundWorker()
    Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox4.SuspendLayout()
    CType(Me.chkTodos, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox2.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox4
    '
    Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackColor2 = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraGroupBox4.ContentAreaAppearance = Appearance1
    Me.UltraGroupBox4.Controls.Add(Me.chkTodos)
    Me.UltraGroupBox4.Controls.Add(Me.cboAlmacen)
    Me.UltraGroupBox4.Controls.Add(Me.UltraLabel12)
    Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
    Me.UltraGroupBox4.Location = New System.Drawing.Point(0, 0)
    Me.UltraGroupBox4.Name = "UltraGroupBox4"
    Me.UltraGroupBox4.Size = New System.Drawing.Size(655, 65)
    Me.UltraGroupBox4.TabIndex = 65
    '
    'chkTodos
    '
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.FontData.Name = "Arial"
    Appearance2.FontData.SizeInPoints = 8.0!
    Me.chkTodos.Appearance = Appearance2
    Me.chkTodos.BackColor = System.Drawing.Color.Transparent
    Me.chkTodos.BackColorInternal = System.Drawing.Color.Transparent
    Me.chkTodos.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.chkTodos.Location = New System.Drawing.Point(356, 33)
    Me.chkTodos.Name = "chkTodos"
    Me.chkTodos.Size = New System.Drawing.Size(168, 18)
    Me.chkTodos.TabIndex = 113
    Me.chkTodos.Text = "Todos"
    '
    'cboAlmacen
    '
    Appearance3.BackColor = System.Drawing.Color.LemonChiffon
    Appearance3.BackColor2 = System.Drawing.Color.White
    Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
    Me.cboAlmacen.Appearance = Appearance3
    Appearance4.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.White
    Appearance6.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance6.FontData.BoldAsString = "True"
    Appearance6.FontData.Name = "Arial"
    Appearance6.FontData.SizeInPoints = 10.0!
    Appearance6.ForeColor = System.Drawing.Color.White
    Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance8
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(64, 31)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(286, 26)
    Me.cboAlmacen.TabIndex = 69
    '
    'UltraLabel12
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance9.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance9
    Me.UltraLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(64, 6)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(312, 19)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "Administración de Provisión de Castigo de Deudas"
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
    Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance10.BackColor = System.Drawing.Color.White
    Appearance10.BackColor2 = System.Drawing.Color.White
    Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
    Me.UltraGroupBox2.ContentAreaAppearance = Appearance10
    Me.UltraGroupBox2.Controls.Add(Me.ToolStrip1)
    Appearance11.BackColor = System.Drawing.Color.LightBlue
    Appearance11.BackColor2 = System.Drawing.Color.White
    Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraGroupBox2.HeaderAppearance = Appearance11
    Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
    Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 66)
    Me.UltraGroupBox2.Name = "UltraGroupBox2"
    Me.UltraGroupBox2.Size = New System.Drawing.Size(655, 31)
    Me.UltraGroupBox2.TabIndex = 67
    '
    'ToolStrip1
    '
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDActualizar, Me.tsDNuevo, Me.tsDEditar, Me.tsDDelete, Me.ToolStripSeparator3, Me.tsExcel, Me.ToolStripSeparator1, Me.tsDReporte, Me.ToolStripSeparator2, Me.tsCerrar})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip1.Size = New System.Drawing.Size(649, 25)
    Me.ToolStrip1.TabIndex = 21
    Me.ToolStrip1.Text = "ToolStrip2"
    '
    'tsDActualizar
    '
    Me.tsDActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDActualizar.Name = "tsDActualizar"
    Me.tsDActualizar.Size = New System.Drawing.Size(63, 22)
    Me.tsDActualizar.Text = "Actualizar"
    Me.tsDActualizar.ToolTipText = "Actualizar"
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
    Me.tsDEditar.Visible = False
    '
    'tsDDelete
    '
    Me.tsDDelete.Image = CType(resources.GetObject("tsDDelete.Image"), System.Drawing.Image)
    Me.tsDDelete.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDDelete.Name = "tsDDelete"
    Me.tsDDelete.Size = New System.Drawing.Size(70, 22)
    Me.tsDDelete.Text = "&Eliminar"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'tsExcel
    '
    Me.tsExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsExcel.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.tsExcel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsExcel.Name = "tsExcel"
    Me.tsExcel.Size = New System.Drawing.Size(23, 22)
    Me.tsExcel.Text = "ToolStripButton1"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsDReporte
    '
    Me.tsDReporte.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDReporte.Name = "tsDReporte"
    Me.tsDReporte.Size = New System.Drawing.Size(52, 22)
    Me.tsDReporte.Text = "Reporte"
    Me.tsDReporte.ToolTipText = "Si desea ver reporte sólo de uno, Seleccione un Registro, de lo contrario verá de" &
    " todo el colegio"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsCerrar
    '
    Me.tsCerrar.Image = CType(resources.GetObject("tsCerrar.Image"), System.Drawing.Image)
    Me.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsCerrar.Name = "tsCerrar"
    Me.tsCerrar.Size = New System.Drawing.Size(59, 22)
    Me.tsCerrar.Text = "Cerrar"
    '
    'LblTotal
    '
    Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance12.BackColor = System.Drawing.Color.Lavender
    Appearance12.BackColor2 = System.Drawing.Color.White
    Appearance12.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance12.TextHAlignAsString = "Right"
    Appearance12.TextVAlignAsString = "Middle"
    Me.LblTotal.Appearance = Appearance12
    Me.LblTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblTotal.Location = New System.Drawing.Point(302, 416)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(246, 18)
    Me.LblTotal.TabIndex = 89
    Me.LblTotal.Text = "0.00"
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance13.TextHAlignAsString = "Center"
    Me.dgvListado.DisplayLayout.CaptionAppearance = Appearance13
    Me.dgvListado.Location = New System.Drawing.Point(0, 99)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(655, 309)
    Me.dgvListado.TabIndex = 87
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(12, 72)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(638, 332)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 88
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'bwLlenar_Grid
    '
    '
    'FrmProvision_Castigo_Deuda
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(657, 440)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.picAjaxBig)
    Me.Controls.Add(Me.dgvListado)
    Me.Controls.Add(Me.UltraGroupBox2)
    Me.Controls.Add(Me.UltraGroupBox4)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FrmProvision_Castigo_Deuda"
    Me.Text = "Provision Castigo Deuda"
    CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox4.ResumeLayout(False)
    Me.UltraGroupBox4.PerformLayout()
    CType(Me.chkTodos, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox2.ResumeLayout(False)
    Me.UltraGroupBox2.PerformLayout()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsDActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblTotal As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
  Friend WithEvents chkTodos As Infragistics.Win.UltraWinEditors.UltraCheckEditor
  Friend WithEvents bwLlenar_Grid As System.ComponentModel.BackgroundWorker
  Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
  Friend WithEvents tsExcel As ToolStripButton
  Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
