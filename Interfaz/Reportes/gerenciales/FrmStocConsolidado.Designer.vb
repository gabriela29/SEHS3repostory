<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStocConsolidado
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStocConsolidado))
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cboMes = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboAnio = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.cboUnidad = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lbl = New Infragistics.Win.Misc.UltraLabel()
        Me.picAjaxBig = New System.Windows.Forms.PictureBox()
        Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bwUnidad = New System.ComponentModel.BackgroundWorker()
        Me.bwListado = New System.ComponentModel.BackgroundWorker()
        Me.ugExcelExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCriterios.SuspendLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gpCriterios.Controls.Add(Me.cboMes)
        Me.gpCriterios.Controls.Add(Me.btnPDF)
        Me.gpCriterios.Controls.Add(Me.Button1)
        Me.gpCriterios.Controls.Add(Me.cboAnio)
        Me.gpCriterios.Controls.Add(Me.BtnMostrar)
        Me.gpCriterios.Controls.Add(Me.UltraLabel12)
        Me.gpCriterios.Controls.Add(Me.cboUnidad)
        Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
        Me.gpCriterios.Location = New System.Drawing.Point(0, 0)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(733, 88)
        Me.gpCriterios.TabIndex = 6
        Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cboMes
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Me.cboMes.Appearance = Appearance2
        Me.cboMes.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance3.BackColor = System.Drawing.Color.White
        Me.cboMes.DisplayLayout.Appearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.cboMes.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.Name = "Arial"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboMes.DisplayLayout.Override.HeaderAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboMes.DisplayLayout.Override.RowSelectorAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboMes.DisplayLayout.Override.SelectedRowAppearance = Appearance7
        Me.cboMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboMes.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.Location = New System.Drawing.Point(263, 23)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(127, 23)
        Me.cboMes.TabIndex = 94
        '
        'btnPDF
        '
        Me.btnPDF.BackColor = System.Drawing.Color.Transparent
        Me.btnPDF.FlatAppearance.BorderSize = 0
        Me.btnPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPDF.Image = Global.Phoenix.My.Resources.Resources.page_white_acrobat
        Me.btnPDF.Location = New System.Drawing.Point(111, 53)
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
        Me.Button1.Location = New System.Drawing.Point(68, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 31)
        Me.Button1.TabIndex = 92
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cboAnio
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Me.cboAnio.Appearance = Appearance8
        Me.cboAnio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        Appearance9.BackColor = System.Drawing.Color.White
        Me.cboAnio.DisplayLayout.Appearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Me.cboAnio.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.White
        Appearance11.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.FontData.Name = "Arial"
        Appearance11.FontData.SizeInPoints = 10.0!
        Appearance11.ForeColor = System.Drawing.Color.White
        Appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboAnio.DisplayLayout.Override.HeaderAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAnio.DisplayLayout.Override.RowSelectorAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboAnio.DisplayLayout.Override.SelectedRowAppearance = Appearance13
        Me.cboAnio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboAnio.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(396, 23)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(84, 23)
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
        Me.BtnMostrar.Location = New System.Drawing.Point(502, 23)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
        Me.BtnMostrar.TabIndex = 89
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'UltraLabel12
        '
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance14.TextVAlignAsString = "Top"
        Me.UltraLabel12.Appearance = Appearance14
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(68, 5)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(497, 15)
        Me.UltraLabel12.TabIndex = 31
        Me.UltraLabel12.Text = "   Unidad Negocio                                            Mes                 " &
    "        Año"
        '
        'cboUnidad
        '
        Appearance15.BackColor = System.Drawing.Color.LemonChiffon
        Appearance15.BackColor2 = System.Drawing.Color.White
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
        Me.cboUnidad.Appearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Me.cboUnidad.DisplayLayout.Appearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Me.cboUnidad.DisplayLayout.Override.CardAreaAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.FontData.BoldAsString = "True"
        Appearance18.FontData.Name = "Arial"
        Appearance18.FontData.SizeInPoints = 10.0!
        Appearance18.ForeColor = System.Drawing.Color.White
        Appearance18.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboUnidad.DisplayLayout.Override.HeaderAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance19.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad.DisplayLayout.Override.RowSelectorAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad.DisplayLayout.Override.SelectedRowAppearance = Appearance20
        Me.cboUnidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboUnidad.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboUnidad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidad.Location = New System.Drawing.Point(68, 23)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(189, 25)
        Me.cboUnidad.TabIndex = 1
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
        Me.UltraPictureBox1.Size = New System.Drawing.Size(44, 43)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColor2 = System.Drawing.Color.White
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance21
        Me.UltraGroupBox1.Controls.Add(Me.lbl)
        Me.UltraGroupBox1.Controls.Add(Me.picAjaxBig)
        Me.UltraGroupBox1.Controls.Add(Me.dgvListado)
        Appearance23.BackColor = System.Drawing.Color.LightBlue
        Appearance23.BackColor2 = System.Drawing.Color.White
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox1.HeaderAppearance = Appearance23
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.BottomOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-6, 121)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(739, 351)
        Me.UltraGroupBox1.TabIndex = 68
        '
        'lbl
        '
        Me.lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance22.ForeColor = System.Drawing.Color.LightBlue
        Appearance22.TextVAlignAsString = "Top"
        Me.lbl.Appearance = Appearance22
        Me.lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(12, 328)
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
        Me.picAjaxBig.Location = New System.Drawing.Point(11, 21)
        Me.picAjaxBig.Name = "picAjaxBig"
        Me.picAjaxBig.Size = New System.Drawing.Size(715, 287)
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
        Me.dgvListado.Size = New System.Drawing.Size(727, 316)
        Me.dgvListado.TabIndex = 87
        '
        'bwListado
        '
        '
        'FrmStocConsolidado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(733, 473)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.gpCriterios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStocConsolidado"
        Me.Text = "Stock Consolidado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCriterios.ResumeLayout(False)
        Me.gpCriterios.PerformLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboAnio As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboUnidad As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents cboMes As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lbl As Infragistics.Win.Misc.UltraLabel
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwUnidad As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwListado As System.ComponentModel.BackgroundWorker
    Friend WithEvents ugExcelExporter As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
