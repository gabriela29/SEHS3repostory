<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlan_CtaCteNM
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlan_CtaCteNM))
    Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.cboTipo = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtCtaCte = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
    Me.lblEntidad = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
    Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox2.SuspendLayout()
    CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtCtaCte, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.UltraGroupBox1.Location = New System.Drawing.Point(1, 2)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(486, 303)
    Me.UltraGroupBox1.TabIndex = 3
    Me.UltraGroupBox1.Text = "Actualizar Cta Cte"
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'UltraGroupBox2
    '
    Appearance2.BackColor = System.Drawing.Color.White
    Me.UltraGroupBox2.ContentAreaAppearance = Appearance2
    Me.UltraGroupBox2.Controls.Add(Me.txtNombre)
    Me.UltraGroupBox2.Controls.Add(Me.cboTipo)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
    Me.UltraGroupBox2.Controls.Add(Me.txtCtaCte)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
    Me.UltraGroupBox2.Controls.Add(Me.lblEntidad)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox2.Location = New System.Drawing.Point(13, 22)
    Me.UltraGroupBox2.Name = "UltraGroupBox2"
    Me.UltraGroupBox2.Size = New System.Drawing.Size(454, 169)
    Me.UltraGroupBox2.TabIndex = 0
    Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'txtNombre
    '
    Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtNombre.Location = New System.Drawing.Point(152, 132)
    Me.txtNombre.MaxLength = 50
    Me.txtNombre.Name = "txtNombre"
    Me.txtNombre.Size = New System.Drawing.Size(277, 23)
    Me.txtNombre.TabIndex = 3
    '
    'cboTipo
    '
    Me.cboTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance3.BackColor = System.Drawing.Color.White
    Me.cboTipo.DisplayLayout.Appearance = Appearance3
    Me.cboTipo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance4.BackColor = System.Drawing.Color.Transparent
    Me.cboTipo.DisplayLayout.Override.CardAreaAppearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.White
    Appearance5.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance5.FontData.BoldAsString = "True"
    Appearance5.FontData.Name = "Arial"
    Appearance5.FontData.SizeInPoints = 10.0!
    Appearance5.ForeColor = System.Drawing.Color.White
    Appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboTipo.DisplayLayout.Override.HeaderAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboTipo.DisplayLayout.Override.RowSelectorAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboTipo.DisplayLayout.Override.SelectedRowAppearance = Appearance7
    Me.cboTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboTipo.Location = New System.Drawing.Point(152, 55)
    Me.cboTipo.Name = "cboTipo"
    Me.cboTipo.Size = New System.Drawing.Size(277, 23)
    Me.cboTipo.TabIndex = 1
    '
    'UltraLabel5
    '
    Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance8.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance8.TextHAlignAsString = "Right"
    Me.UltraLabel5.Appearance = Appearance8
    Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel5.Location = New System.Drawing.Point(15, 59)
    Me.UltraLabel5.Name = "UltraLabel5"
    Me.UltraLabel5.Size = New System.Drawing.Size(127, 15)
    Me.UltraLabel5.TabIndex = 100
    Me.UltraLabel5.Text = "Tipo:"
    '
    'UltraLabel3
    '
    Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance9.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance9.TextHAlignAsString = "Right"
    Me.UltraLabel3.Appearance = Appearance9
    Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel3.Location = New System.Drawing.Point(15, 135)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(127, 15)
    Me.UltraLabel3.TabIndex = 98
    Me.UltraLabel3.Text = "Nombre:"
    '
    'txtCtaCte
    '
    Me.txtCtaCte.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtCtaCte.Location = New System.Drawing.Point(152, 89)
    Me.txtCtaCte.MaxLength = 50
    Me.txtCtaCte.Name = "txtCtaCte"
    Me.txtCtaCte.Size = New System.Drawing.Size(277, 23)
    Me.txtCtaCte.TabIndex = 2
    '
    'UltraLabel4
    '
    Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance10.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance10.TextHAlignAsString = "Right"
    Me.UltraLabel4.Appearance = Appearance10
    Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel4.Location = New System.Drawing.Point(15, 92)
    Me.UltraLabel4.Name = "UltraLabel4"
    Me.UltraLabel4.Size = New System.Drawing.Size(127, 16)
    Me.UltraLabel4.TabIndex = 3
    Me.UltraLabel4.Text = "Cta Cte:"
    '
    'lblEntidad
    '
    Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance11.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance11.TextVAlignAsString = "Middle"
    Me.lblEntidad.Appearance = Appearance11
    Me.lblEntidad.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dashed
    Me.lblEntidad.Location = New System.Drawing.Point(152, 23)
    Me.lblEntidad.Name = "lblEntidad"
    Me.lblEntidad.Size = New System.Drawing.Size(277, 20)
    Me.lblEntidad.TabIndex = 0
    '
    'UltraLabel1
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance12.TextHAlignAsString = "Right"
    Me.UltraLabel1.Appearance = Appearance12
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel1.Location = New System.Drawing.Point(15, 25)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(127, 15)
    Me.UltraLabel1.TabIndex = 38
    Me.UltraLabel1.Text = "Entidad:"
    '
    'btnCerrar
    '
    Appearance13.BackColor = System.Drawing.Color.White
    Appearance13.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
    Me.btnCerrar.Appearance = Appearance13
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
    Appearance14.BackColor = System.Drawing.Color.White
    Appearance14.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
    Me.BtnGrabar.Appearance = Appearance14
    Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.BtnGrabar.Location = New System.Drawing.Point(359, 197)
    Me.BtnGrabar.Name = "BtnGrabar"
    Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
    Me.BtnGrabar.TabIndex = 1
    Me.BtnGrabar.Text = "&Grabar"
    Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'FrmPlan_CtaCteNM
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(490, 246)
    Me.ControlBox = False
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.KeyPreview = True
    Me.Name = "FrmPlan_CtaCteNM"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox2.ResumeLayout(False)
    Me.UltraGroupBox2.PerformLayout()
    CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtCtaCte, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents cboTipo As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtCtaCte As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents lblEntidad As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
  Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
End Class
