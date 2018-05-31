<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKardex
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
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKardex))
    Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.btnPDF = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.btnLista_Producto = New Infragistics.Win.Misc.UltraButton()
    Me.lblProducto = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAnio = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.lbl = New Infragistics.Win.Misc.UltraLabel()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
    Me.bwListado = New System.ComponentModel.BackgroundWorker()
    Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.gpCriterios.Controls.Add(Me.btnPDF)
    Me.gpCriterios.Controls.Add(Me.Button1)
    Me.gpCriterios.Controls.Add(Me.btnLista_Producto)
    Me.gpCriterios.Controls.Add(Me.lblProducto)
    Me.gpCriterios.Controls.Add(Me.cboAnio)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -1)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(745, 105)
    Me.gpCriterios.TabIndex = 5
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'btnPDF
    '
    Me.btnPDF.BackColor = System.Drawing.Color.Transparent
    Me.btnPDF.FlatAppearance.BorderSize = 0
    Me.btnPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.btnPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnPDF.Image = Global.Phoenix.My.Resources.Resources.page_white_acrobat
    Me.btnPDF.Location = New System.Drawing.Point(483, 61)
    Me.btnPDF.Name = "btnPDF"
    Me.btnPDF.Size = New System.Drawing.Size(37, 33)
    Me.btnPDF.TabIndex = 93
    Me.btnPDF.UseVisualStyleBackColor = False
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.Transparent
    Me.Button1.FlatAppearance.BorderSize = 0
    Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Button1.Image = Global.Phoenix.My.Resources.Resources.page_excel
    Me.Button1.Location = New System.Drawing.Point(440, 62)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(37, 31)
    Me.Button1.TabIndex = 92
    Me.Button1.UseVisualStyleBackColor = False
    '
    'btnLista_Producto
    '
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.BorderAlpha = Infragistics.Win.Alpha.Transparent
    Me.btnLista_Producto.Appearance = Appearance2
    Me.btnLista_Producto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
    Me.btnLista_Producto.Location = New System.Drawing.Point(537, 13)
    Me.btnLista_Producto.Name = "btnLista_Producto"
    Me.btnLista_Producto.Size = New System.Drawing.Size(149, 18)
    Me.btnLista_Producto.TabIndex = 91
    Me.btnLista_Producto.Text = "Seleccionar Producto"
    Me.btnLista_Producto.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'lblProducto
    '
    Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance3.ForeColor = System.Drawing.Color.Navy
    Appearance3.TextVAlignAsString = "Top"
    Me.lblProducto.Appearance = Appearance3
    Me.lblProducto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.lblProducto.Location = New System.Drawing.Point(82, 13)
    Me.lblProducto.Name = "lblProducto"
    Me.lblProducto.Size = New System.Drawing.Size(449, 18)
    Me.lblProducto.TabIndex = 90
    '
    'cboAnio
    '
    Appearance4.BackColor = System.Drawing.Color.White
    Me.cboAnio.Appearance = Appearance4
    Me.cboAnio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance5.BackColor = System.Drawing.Color.White
    Me.cboAnio.DisplayLayout.Appearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.Transparent
    Me.cboAnio.DisplayLayout.Override.CardAreaAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.White
    Appearance7.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance7.FontData.BoldAsString = "True"
    Appearance7.FontData.Name = "Arial"
    Appearance7.FontData.SizeInPoints = 10.0!
    Appearance7.ForeColor = System.Drawing.Color.White
    Appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAnio.DisplayLayout.Override.HeaderAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAnio.DisplayLayout.Override.RowSelectorAppearance = Appearance8
    Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAnio.DisplayLayout.Override.SelectedRowAppearance = Appearance9
    Me.cboAnio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAnio.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAnio.Location = New System.Drawing.Point(261, 70)
    Me.cboAnio.Name = "cboAnio"
    Me.cboAnio.Size = New System.Drawing.Size(100, 23)
    Me.cboAnio.TabIndex = 80
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(367, 56)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'UltraLabel12
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance10.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance10
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(66, 54)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(497, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "   Almacén                                            Año"
    '
    'cboAlmacen
    '
    Appearance11.BackColor = System.Drawing.Color.LemonChiffon
    Appearance11.BackColor2 = System.Drawing.Color.White
    Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
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
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(66, 69)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(189, 25)
    Me.cboAlmacen.TabIndex = 1
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.AutoSize = True
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(18, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance17.BackColor = System.Drawing.Color.White
    Appearance17.BackColor2 = System.Drawing.Color.White
    Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
    Me.UltraGroupBox1.ContentAreaAppearance = Appearance17
    Me.UltraGroupBox1.Controls.Add(Me.lbl)
    Me.UltraGroupBox1.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
    Appearance19.BackColor = System.Drawing.Color.LightBlue
    Appearance19.BackColor2 = System.Drawing.Color.White
    Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraGroupBox1.HeaderAppearance = Appearance19
    Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
    Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 105)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(745, 315)
    Me.UltraGroupBox1.TabIndex = 67
    '
    'lbl
    '
    Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance18.ForeColor = System.Drawing.Color.LightBlue
    Appearance18.TextVAlignAsString = "Top"
    Me.lbl.Appearance = Appearance18
    Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl.Location = New System.Drawing.Point(12, 292)
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
    Me.picAjaxBig.Location = New System.Drawing.Point(11, 7)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(721, 265)
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
    Me.dgvListado.Location = New System.Drawing.Point(6, 7)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(733, 280)
    Me.dgvListado.TabIndex = 87
    '
    'bwListado
    '
    '
    'FrmKardex
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(743, 419)
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmKardex"
    Me.Text = "Kardex"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboAnio As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents lblProducto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnLista_Producto As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwListado As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPDF As System.Windows.Forms.Button
End Class
