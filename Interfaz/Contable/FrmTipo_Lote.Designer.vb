<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipo_Lote
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
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipo_Lote))
    Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.cboMeses = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAnio = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
    Me.TxtDescripLote = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
    Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
    Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
    Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraTextEditor2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox2.SuspendLayout()
    CType(Me.cboMeses, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TxtDescripLote, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox1.ContentAreaAppearance = Appearance1
    Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
    Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
    Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
    Me.UltraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 0)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(537, 235)
    Me.UltraGroupBox1.TabIndex = 3
    Me.UltraGroupBox1.Text = "Crear un Nuevo Tipo de Lote..."
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'UltraGroupBox2
    '
    Appearance2.BackColor = System.Drawing.Color.White
    Me.UltraGroupBox2.ContentAreaAppearance = Appearance2
    Me.UltraGroupBox2.Controls.Add(Me.UltraTextEditor2)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
    Me.UltraGroupBox2.Controls.Add(Me.UltraTextEditor1)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox2.Controls.Add(Me.cboMeses)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
    Me.UltraGroupBox2.Controls.Add(Me.cboAnio)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
    Me.UltraGroupBox2.Controls.Add(Me.TxtDescripLote)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
    Me.UltraGroupBox2.Location = New System.Drawing.Point(13, 22)
    Me.UltraGroupBox2.Name = "UltraGroupBox2"
    Me.UltraGroupBox2.Size = New System.Drawing.Size(454, 169)
    Me.UltraGroupBox2.TabIndex = 0
    Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'cboMeses
    '
    Me.cboMeses.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance5.BackColor = System.Drawing.Color.White
    Me.cboMeses.DisplayLayout.Appearance = Appearance5
    Me.cboMeses.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance6.BackColor = System.Drawing.Color.Transparent
    Me.cboMeses.DisplayLayout.Override.CardAreaAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.White
    Appearance7.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance7.FontData.BoldAsString = "True"
    Appearance7.FontData.Name = "Arial"
    Appearance7.FontData.SizeInPoints = 10.0!
    Appearance7.ForeColor = System.Drawing.Color.White
    Appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboMeses.DisplayLayout.Override.HeaderAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboMeses.DisplayLayout.Override.RowSelectorAppearance = Appearance8
    Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboMeses.DisplayLayout.Override.SelectedRowAppearance = Appearance9
    Me.cboMeses.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboMeses.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboMeses.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboMeses.Location = New System.Drawing.Point(152, 131)
    Me.cboMeses.Name = "cboMeses"
    Me.cboMeses.Size = New System.Drawing.Size(119, 23)
    Me.cboMeses.TabIndex = 3
    '
    'UltraLabel3
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance10.TextHAlignAsString = "Right"
    Me.UltraLabel3.Appearance = Appearance10
    Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel3.Location = New System.Drawing.Point(15, 135)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(127, 15)
    Me.UltraLabel3.TabIndex = 98
    Me.UltraLabel3.Text = "Mes:"
    '
    'cboAnio
    '
    Me.cboAnio.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance11.BackColor = System.Drawing.Color.White
    Me.cboAnio.DisplayLayout.Appearance = Appearance11
    Me.cboAnio.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance12.BackColor = System.Drawing.Color.Transparent
    Me.cboAnio.DisplayLayout.Override.CardAreaAppearance = Appearance12
    Appearance13.BackColor = System.Drawing.Color.White
    Appearance13.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance13.FontData.BoldAsString = "True"
    Appearance13.FontData.Name = "Arial"
    Appearance13.FontData.SizeInPoints = 10.0!
    Appearance13.ForeColor = System.Drawing.Color.White
    Appearance13.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAnio.DisplayLayout.Override.HeaderAppearance = Appearance13
    Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance14.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAnio.DisplayLayout.Override.RowSelectorAppearance = Appearance14
    Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAnio.DisplayLayout.Override.SelectedRowAppearance = Appearance15
    Me.cboAnio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAnio.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAnio.Location = New System.Drawing.Point(346, 131)
    Me.cboAnio.Name = "cboAnio"
    Me.cboAnio.Size = New System.Drawing.Size(83, 23)
    Me.cboAnio.TabIndex = 4
    '
    'UltraLabel2
    '
    Appearance16.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance16.ForeColor = System.Drawing.Color.CornflowerBlue
    Me.UltraLabel2.Appearance = Appearance16
    Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel2.Location = New System.Drawing.Point(297, 135)
    Me.UltraLabel2.Name = "UltraLabel2"
    Me.UltraLabel2.Size = New System.Drawing.Size(43, 15)
    Me.UltraLabel2.TabIndex = 96
    Me.UltraLabel2.Text = "Año:"
    '
    'TxtDescripLote
    '
    Me.TxtDescripLote.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.TxtDescripLote.Location = New System.Drawing.Point(152, 12)
    Me.TxtDescripLote.MaxLength = 50
    Me.TxtDescripLote.Name = "TxtDescripLote"
    Me.TxtDescripLote.Size = New System.Drawing.Size(277, 23)
    Me.TxtDescripLote.TabIndex = 2
    '
    'UltraLabel4
    '
    Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance17.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance17.TextHAlignAsString = "Right"
    Me.UltraLabel4.Appearance = Appearance17
    Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel4.Location = New System.Drawing.Point(15, 15)
    Me.UltraLabel4.Name = "UltraLabel4"
    Me.UltraLabel4.Size = New System.Drawing.Size(127, 16)
    Me.UltraLabel4.TabIndex = 3
    Me.UltraLabel4.Text = "Descripción:"
    '
    'btnCerrar
    '
    Appearance18.BackColor = System.Drawing.Color.White
    Appearance18.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance18.Image = CType(resources.GetObject("Appearance18.Image"), Object)
    Me.btnCerrar.Appearance = Appearance18
    Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCerrar.Location = New System.Drawing.Point(53, 197)
    Me.btnCerrar.Name = "btnCerrar"
    Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
    Me.btnCerrar.TabIndex = 2
    Me.btnCerrar.Text = "&Cerrar"
    Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'BtnGrabar
    '
    Appearance19.BackColor = System.Drawing.Color.White
    Appearance19.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance19.Image = CType(resources.GetObject("Appearance19.Image"), Object)
    Me.BtnGrabar.Appearance = Appearance19
    Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.BtnGrabar.Location = New System.Drawing.Point(359, 197)
    Me.BtnGrabar.Name = "BtnGrabar"
    Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
    Me.BtnGrabar.TabIndex = 1
    Me.BtnGrabar.Text = "&Grabar"
    Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'UltraTextEditor1
    '
    Me.UltraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.UltraTextEditor1.Location = New System.Drawing.Point(152, 41)
    Me.UltraTextEditor1.MaxLength = 50
    Me.UltraTextEditor1.Name = "UltraTextEditor1"
    Me.UltraTextEditor1.Size = New System.Drawing.Size(119, 23)
    Me.UltraTextEditor1.TabIndex = 99
    '
    'UltraLabel1
    '
    Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance4.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance4.TextHAlignAsString = "Right"
    Me.UltraLabel1.Appearance = Appearance4
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel1.Location = New System.Drawing.Point(15, 44)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(127, 16)
    Me.UltraLabel1.TabIndex = 100
    Me.UltraLabel1.Text = "Tipo:"
    '
    'UltraTextEditor2
    '
    Me.UltraTextEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.UltraTextEditor2.Location = New System.Drawing.Point(346, 41)
    Me.UltraTextEditor2.MaxLength = 50
    Me.UltraTextEditor2.Name = "UltraTextEditor2"
    Me.UltraTextEditor2.Size = New System.Drawing.Size(83, 23)
    Me.UltraTextEditor2.TabIndex = 101
    '
    'UltraLabel5
    '
    Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance3.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance3.TextHAlignAsString = "Right"
    Me.UltraLabel5.Appearance = Appearance3
    Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel5.Location = New System.Drawing.Point(277, 44)
    Me.UltraLabel5.Name = "UltraLabel5"
    Me.UltraLabel5.Size = New System.Drawing.Size(63, 16)
    Me.UltraLabel5.TabIndex = 102
    Me.UltraLabel5.Text = "Código:"
    '
    'FrmTipo_Lote
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(535, 277)
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTipo_Lote"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.Text = "Tipo Lote Actualizar"
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox2.ResumeLayout(False)
    Me.UltraGroupBox2.PerformLayout()
    CType(Me.cboMeses, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TxtDescripLote, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents UltraTextEditor2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents cboMeses As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents cboAnio As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents TxtDescripLote As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
  Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
End Class
