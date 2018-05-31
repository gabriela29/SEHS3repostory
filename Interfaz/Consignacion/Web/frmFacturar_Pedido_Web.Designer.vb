<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturar_Pedido_Web
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
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturar_Pedido_Web))
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
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.picAjax = New System.Windows.Forms.PictureBox()
    Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.btnEmitir = New Infragistics.Win.Misc.UltraButton()
    Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtRecibo_Dzmo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtvencimiento = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
    Me.txtSerie = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtFecha = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
    Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtNumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboDocumento = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
    Me.lblAlmacen = New Infragistics.Win.Misc.UltraLabel()
    Me.bwDatos = New System.ComponentModel.BackgroundWorker()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox3.SuspendLayout()
    CType(Me.txtRecibo_Dzmo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox1
    '
    Appearance1.AlphaLevel = CType(50, Short)
    Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
    Me.UltraGroupBox1.Appearance = Appearance1
    Me.UltraGroupBox1.Controls.Add(Me.picAjax)
    Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox3)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
    Me.UltraGroupBox1.Controls.Add(Me.txtRecibo_Dzmo)
    Me.UltraGroupBox1.Controls.Add(Me.txtvencimiento)
    Me.UltraGroupBox1.Controls.Add(Me.txtSerie)
    Me.UltraGroupBox1.Controls.Add(Me.txtFecha)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
    Me.UltraGroupBox1.Controls.Add(Me.txtNumero)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox1.Controls.Add(Me.cboDocumento)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
    Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 55)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(385, 173)
    Me.UltraGroupBox1.TabIndex = 124
    Me.UltraGroupBox1.Text = "Datos del Documento"
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'picAjax
    '
    Me.picAjax.BackColor = System.Drawing.Color.Transparent
    Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
    Me.picAjax.Location = New System.Drawing.Point(1, 9)
    Me.picAjax.Name = "picAjax"
    Me.picAjax.Size = New System.Drawing.Size(380, 164)
    Me.picAjax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjax.TabIndex = 84
    Me.picAjax.TabStop = False
    Me.picAjax.Visible = False
    '
    'UltraGroupBox3
    '
    Appearance2.BackColor = System.Drawing.Color.RoyalBlue
    Me.UltraGroupBox3.ContentAreaAppearance = Appearance2
    Me.UltraGroupBox3.Controls.Add(Me.btnEmitir)
    Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 135)
    Me.UltraGroupBox3.Name = "UltraGroupBox3"
    Me.UltraGroupBox3.Size = New System.Drawing.Size(383, 38)
    Me.UltraGroupBox3.TabIndex = 136
    '
    'btnEmitir
    '
    Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance3.ForeColor = System.Drawing.Color.White
    Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
    Me.btnEmitir.Appearance = Appearance3
    Me.btnEmitir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnEmitir.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnEmitir.Location = New System.Drawing.Point(104, 6)
    Me.btnEmitir.Name = "btnEmitir"
    Me.btnEmitir.Size = New System.Drawing.Size(188, 26)
    Me.btnEmitir.TabIndex = 1
    Me.btnEmitir.Text = "&Emitir Documentos"
    Me.btnEmitir.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'UltraLabel8
    '
    Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance4.ForeColor = System.Drawing.Color.Navy
    Appearance4.TextHAlignAsString = "Right"
    Appearance4.TextVAlignAsString = "Top"
    Me.UltraLabel8.Appearance = Appearance4
    Me.UltraLabel8.Font = New System.Drawing.Font("Tahoma", 9.75!)
    Me.UltraLabel8.Location = New System.Drawing.Point(4, 101)
    Me.UltraLabel8.Name = "UltraLabel8"
    Me.UltraLabel8.Size = New System.Drawing.Size(75, 16)
    Me.UltraLabel8.TabIndex = 117
    Me.UltraLabel8.Text = "Rec. Dzmo :"
    '
    'txtRecibo_Dzmo
    '
    Appearance5.BackColor = System.Drawing.Color.White
    Appearance5.ForeColor = System.Drawing.Color.Red
    Appearance5.TextHAlignAsString = "Center"
    Appearance5.TextVAlignAsString = "Middle"
    Me.txtRecibo_Dzmo.Appearance = Appearance5
    Me.txtRecibo_Dzmo.BackColor = System.Drawing.Color.White
    Me.txtRecibo_Dzmo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtRecibo_Dzmo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRecibo_Dzmo.Location = New System.Drawing.Point(106, 98)
    Me.txtRecibo_Dzmo.MaxLength = 8
    Me.txtRecibo_Dzmo.Name = "txtRecibo_Dzmo"
    Me.txtRecibo_Dzmo.ReadOnly = True
    Me.txtRecibo_Dzmo.Size = New System.Drawing.Size(253, 21)
    Me.txtRecibo_Dzmo.TabIndex = 116
    '
    'txtvencimiento
    '
    Appearance6.BackColor = System.Drawing.Color.LemonChiffon
    Appearance6.FontData.BoldAsString = "True"
    Appearance6.FontData.SizeInPoints = 10.0!
    Appearance6.ForeColor = System.Drawing.Color.Red
    Me.txtvencimiento.Appearance = Appearance6
    Me.txtvencimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtvencimiento.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Date]
    Me.txtvencimiento.InputMask = "{LOC}dd/mm/yyyy"
    Me.txtvencimiento.Location = New System.Drawing.Point(198, 69)
    Me.txtvencimiento.Name = "txtvencimiento"
    Me.txtvencimiento.Size = New System.Drawing.Size(86, 23)
    Me.txtvencimiento.TabIndex = 114
    Me.txtvencimiento.Text = "//"
    '
    'txtSerie
    '
    Appearance7.BackColor = System.Drawing.Color.LemonChiffon
    Appearance7.ForeColor = System.Drawing.Color.Red
    Appearance7.TextHAlignAsString = "Center"
    Appearance7.TextVAlignAsString = "Middle"
    Me.txtSerie.Appearance = Appearance7
    Me.txtSerie.BackColor = System.Drawing.Color.LemonChiffon
    Me.txtSerie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtSerie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtSerie.Location = New System.Drawing.Point(106, 40)
    Me.txtSerie.MaxLength = 8
    Me.txtSerie.Name = "txtSerie"
    Me.txtSerie.ReadOnly = True
    Me.txtSerie.Size = New System.Drawing.Size(68, 22)
    Me.txtSerie.TabIndex = 109
    Me.txtSerie.Text = "0000"
    '
    'txtFecha
    '
    Appearance8.BackColor = System.Drawing.Color.LemonChiffon
    Appearance8.FontData.BoldAsString = "True"
    Appearance8.FontData.SizeInPoints = 10.0!
    Appearance8.ForeColor = System.Drawing.Color.Red
    Me.txtFecha.Appearance = Appearance8
    Me.txtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtFecha.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Date]
    Me.txtFecha.InputMask = "{LOC}dd/mm/yyyy"
    Me.txtFecha.Location = New System.Drawing.Point(106, 69)
    Me.txtFecha.Name = "txtFecha"
    Me.txtFecha.Size = New System.Drawing.Size(86, 23)
    Me.txtFecha.TabIndex = 3
    Me.txtFecha.Text = "//"
    '
    'UltraLabel7
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.Color.Navy
    Appearance9.TextHAlignAsString = "Center"
    Appearance9.TextVAlignAsString = "Middle"
    Me.UltraLabel7.Appearance = Appearance9
    Me.UltraLabel7.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel7.Location = New System.Drawing.Point(178, 41)
    Me.UltraLabel7.Name = "UltraLabel7"
    Me.UltraLabel7.Size = New System.Drawing.Size(14, 21)
    Me.UltraLabel7.TabIndex = 104
    Me.UltraLabel7.Text = "-"
    '
    'UltraLabel2
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.Color.Navy
    Appearance10.TextHAlignAsString = "Right"
    Appearance10.TextVAlignAsString = "Top"
    Me.UltraLabel2.Appearance = Appearance10
    Me.UltraLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel2.Location = New System.Drawing.Point(10, 76)
    Me.UltraLabel2.Name = "UltraLabel2"
    Me.UltraLabel2.Size = New System.Drawing.Size(69, 16)
    Me.UltraLabel2.TabIndex = 99
    Me.UltraLabel2.Text = "Fecha :"
    '
    'txtNumero
    '
    Appearance11.BackColor = System.Drawing.Color.LemonChiffon
    Appearance11.ForeColor = System.Drawing.Color.Red
    Appearance11.TextHAlignAsString = "Right"
    Appearance11.TextVAlignAsString = "Middle"
    Me.txtNumero.Appearance = Appearance11
    Me.txtNumero.BackColor = System.Drawing.Color.LemonChiffon
    Me.txtNumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtNumero.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNumero.Location = New System.Drawing.Point(198, 40)
    Me.txtNumero.MaxLength = 8
    Me.txtNumero.Name = "txtNumero"
    Me.txtNumero.ReadOnly = True
    Me.txtNumero.Size = New System.Drawing.Size(95, 22)
    Me.txtNumero.TabIndex = 2
    Me.txtNumero.Text = "00000000"
    '
    'UltraLabel1
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.Color.Navy
    Appearance12.TextHAlignAsString = "Right"
    Appearance12.TextVAlignAsString = "Top"
    Me.UltraLabel1.Appearance = Appearance12
    Me.UltraLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel1.Location = New System.Drawing.Point(8, 42)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(71, 16)
    Me.UltraLabel1.TabIndex = 86
    Me.UltraLabel1.Text = "Número:"
    '
    'cboDocumento
    '
    Appearance13.BackColor = System.Drawing.Color.LemonChiffon
    Me.cboDocumento.Appearance = Appearance13
    Me.cboDocumento.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance14.BackColor = System.Drawing.Color.White
    Me.cboDocumento.DisplayLayout.Appearance = Appearance14
    Me.cboDocumento.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance15.BackColor = System.Drawing.Color.Transparent
    Me.cboDocumento.DisplayLayout.Override.CardAreaAppearance = Appearance15
    Appearance16.BackColor = System.Drawing.Color.White
    Appearance16.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance16.FontData.BoldAsString = "True"
    Appearance16.FontData.Name = "Arial"
    Appearance16.FontData.SizeInPoints = 10.0!
    Appearance16.ForeColor = System.Drawing.Color.White
    Appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboDocumento.DisplayLayout.Override.HeaderAppearance = Appearance16
    Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboDocumento.DisplayLayout.Override.RowSelectorAppearance = Appearance17
    Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboDocumento.DisplayLayout.Override.SelectedRowAppearance = Appearance18
    Me.cboDocumento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboDocumento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboDocumento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboDocumento.Location = New System.Drawing.Point(106, 12)
    Me.cboDocumento.Name = "cboDocumento"
    Me.cboDocumento.Size = New System.Drawing.Size(253, 23)
    Me.cboDocumento.TabIndex = 0
    '
    'UltraLabel4
    '
    Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance19.ForeColor = System.Drawing.Color.Navy
    Appearance19.TextHAlignAsString = "Right"
    Appearance19.TextVAlignAsString = "Top"
    Me.UltraLabel4.Appearance = Appearance19
    Me.UltraLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
    Me.UltraLabel4.Location = New System.Drawing.Point(2, 19)
    Me.UltraLabel4.Name = "UltraLabel4"
    Me.UltraLabel4.Size = New System.Drawing.Size(82, 16)
    Me.UltraLabel4.TabIndex = 33
    Me.UltraLabel4.Text = "Documento:"
    '
    'lblAlmacen
    '
    Appearance20.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance20.ForeColor = System.Drawing.Color.Red
    Appearance20.TextHAlignAsString = "Center"
    Appearance20.TextVAlignAsString = "Middle"
    Me.lblAlmacen.Appearance = Appearance20
    Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
    Me.lblAlmacen.Location = New System.Drawing.Point(1, 12)
    Me.lblAlmacen.Name = "lblAlmacen"
    Me.lblAlmacen.Size = New System.Drawing.Size(392, 19)
    Me.lblAlmacen.TabIndex = 125
    Me.lblAlmacen.Text = "Almcén"
    '
    'bwDatos
    '
    '
    'frmFacturar_Pedido_Web
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(386, 227)
    Me.Controls.Add(Me.lblAlmacen)
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmFacturar_Pedido_Web"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Facturar Pedido Colportor Web"
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    Me.UltraGroupBox1.PerformLayout()
    CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox3.ResumeLayout(False)
    CType(Me.txtRecibo_Dzmo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboDocumento, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtRecibo_Dzmo As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents txtvencimiento As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
  Private WithEvents picAjax As PictureBox
  Friend WithEvents txtSerie As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents txtFecha As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
  Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtNumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents cboDocumento As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents lblAlmacen As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents btnEmitir As Infragistics.Win.Misc.UltraButton
  Friend WithEvents bwDatos As System.ComponentModel.BackgroundWorker
End Class
