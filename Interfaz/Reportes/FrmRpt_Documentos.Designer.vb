<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRpt_Compras
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRpt_Compras))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtNumHasta = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtNumDesde = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.BtnBuscar = New Infragistics.Win.Misc.UltraButton
        Me.cboDocumento = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.lblUnidad_Negocio = New Infragistics.Win.Misc.UltraLabel
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.bwData = New System.ComponentModel.BackgroundWorker
        Me.picAjaxBig = New System.Windows.Forms.PictureBox
        Me.LblRuta = New Infragistics.Win.Misc.UltraLabel
        Me.lblRegistros = New Infragistics.Win.Misc.UltraLabel
        Me.lblSerieTK = New Infragistics.Win.Misc.UltraLabel
        Me.chkBoleta = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.txtNumHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle

        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 74)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(741, 309)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance1
        Me.UltraGroupBox4.Controls.Add(Me.chkBoleta)
        Me.UltraGroupBox4.Controls.Add(Me.txtNumHasta)
        Me.UltraGroupBox4.Controls.Add(Me.txtNumDesde)
        Me.UltraGroupBox4.Controls.Add(Me.BtnBuscar)
        Me.UltraGroupBox4.Controls.Add(Me.cboDocumento)
        Me.UltraGroupBox4.Controls.Add(Me.lblUnidad_Negocio)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(-2, -1)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(743, 55)
        Me.UltraGroupBox4.TabIndex = 64
        '
        'txtNumHasta
        '
        Appearance18.ForeColor = System.Drawing.Color.Navy
        Appearance18.TextHAlignAsString = "Right"
        Appearance18.TextVAlignAsString = "Middle"
        Me.txtNumHasta.Appearance = Appearance18
        Me.txtNumHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNumHasta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumHasta.Location = New System.Drawing.Point(394, 26)
        Me.txtNumHasta.MaxLength = 7
        Me.txtNumHasta.Name = "txtNumHasta"
        Me.txtNumHasta.Size = New System.Drawing.Size(88, 24)
        Me.txtNumHasta.TabIndex = 90
        '
        'txtNumDesde
        '
        Appearance2.ForeColor = System.Drawing.Color.Navy
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtNumDesde.Appearance = Appearance2
        Me.txtNumDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNumDesde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDesde.Location = New System.Drawing.Point(300, 26)
        Me.txtNumDesde.MaxLength = 7
        Me.txtNumDesde.Name = "txtNumDesde"
        Me.txtNumDesde.Size = New System.Drawing.Size(88, 24)
        Me.txtNumDesde.TabIndex = 89
        '
        'BtnBuscar
        '
        Appearance27.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance27.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance27.ImageVAlign = Infragistics.Win.VAlign.Top
        Me.BtnBuscar.Appearance = Appearance27
        Me.BtnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(522, -2)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(87, 52)
        Me.BtnBuscar.TabIndex = 85
        Me.BtnBuscar.Text = "&Mostrar"
        Me.BtnBuscar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'cboDocumento
        '
        Appearance14.BackColor = System.Drawing.Color.LemonChiffon
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
        Me.cboDocumento.Appearance = Appearance14
        Me.cboDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance15.BackColor = System.Drawing.Color.White
        Me.cboDocumento.DisplayLayout.Appearance = Appearance15
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Me.cboDocumento.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.Color.White
        Appearance20.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance20.FontData.BoldAsString = "True"
        Appearance20.FontData.Name = "Arial"
        Appearance20.FontData.SizeInPoints = 10.0!
        Appearance20.ForeColor = System.Drawing.Color.White
        Appearance20.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboDocumento.DisplayLayout.Override.HeaderAppearance = Appearance20
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance25.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDocumento.DisplayLayout.Override.RowSelectorAppearance = Appearance25
        Appearance26.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboDocumento.DisplayLayout.Override.SelectedRowAppearance = Appearance26
        Me.cboDocumento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboDocumento.Location = New System.Drawing.Point(71, 28)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(223, 22)
        Me.cboDocumento.TabIndex = 65
        '
        'lblUnidad_Negocio
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance4.TextVAlignAsString = "Top"
        Me.lblUnidad_Negocio.Appearance = Appearance4
        Me.lblUnidad_Negocio.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblUnidad_Negocio.Location = New System.Drawing.Point(71, 6)
        Me.lblUnidad_Negocio.Name = "lblUnidad_Negocio"
        Me.lblUnidad_Negocio.Size = New System.Drawing.Size(445, 19)
        Me.lblUnidad_Negocio.TabIndex = 31
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.AutoSize = True
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraPictureBox1.Location = New System.Drawing.Point(1, -1)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'bwData
        '
        '
        'picAjaxBig
        '
        Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
        Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
        Me.picAjaxBig.Location = New System.Drawing.Point(1, 74)
        Me.picAjaxBig.Name = "picAjaxBig"
        Me.picAjaxBig.Size = New System.Drawing.Size(740, 309)
        Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAjaxBig.TabIndex = 85
        Me.picAjaxBig.TabStop = False
        Me.picAjaxBig.Visible = False
        '
        'LblRuta
        '
        Me.LblRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.ForeColor = System.Drawing.Color.LightSteelBlue
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.LblRuta.Appearance = Appearance3
        Me.LblRuta.Location = New System.Drawing.Point(435, 54)
        Me.LblRuta.Name = "LblRuta"
        Me.LblRuta.Size = New System.Drawing.Size(300, 14)
        Me.LblRuta.TabIndex = 86
        Me.LblRuta.Text = "-"
        '
        'lblRegistros
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.SteelBlue
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblRegistros.Appearance = Appearance5
        Me.lblRegistros.Location = New System.Drawing.Point(1, 55)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(178, 14)
        Me.lblRegistros.TabIndex = 87
        Me.lblRegistros.Text = "-"
        '
        'lblSerieTK
        '
        Appearance46.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance46.ForeColor = System.Drawing.Color.SteelBlue
        Appearance46.TextVAlignAsString = "Middle"
        Me.lblSerieTK.Appearance = Appearance46
        Me.lblSerieTK.Location = New System.Drawing.Point(185, 54)
        Me.lblSerieTK.Name = "lblSerieTK"
        Me.lblSerieTK.Size = New System.Drawing.Size(122, 14)
        Me.lblSerieTK.TabIndex = 88
        Me.lblSerieTK.Text = "-"
        '
        'chkBoleta
        '
        Me.chkBoleta.Location = New System.Drawing.Point(617, 19)
        Me.chkBoleta.Name = "chkBoleta"
        Me.chkBoleta.Size = New System.Drawing.Size(120, 20)
        Me.chkBoleta.TabIndex = 91
        Me.chkBoleta.Text = "Boleta"
        '
        'FrmRpt_Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(741, 383)
        Me.Controls.Add(Me.lblSerieTK)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.LblRuta)
        Me.Controls.Add(Me.picAjaxBig)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRpt_Compras"
        Me.Text = "Reporte Documentos..."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.txtNumHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblUnidad_Negocio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents cboDocumento As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents bwData As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtNumHasta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNumDesde As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents LblRuta As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblSerieTK As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkBoleta As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
