<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPersona_CampaniaNM
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPersona_CampaniaNM))
    Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpDatos = New Infragistics.Win.Misc.UltraGroupBox()
    Me.Lblerror = New System.Windows.Forms.Label()
    Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ChkEstado = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
    Me.cboTipo = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtObservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtDNI = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
    Me.lblNombreCta = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.lblAsistente = New Infragistics.Win.Misc.UltraLabel()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtCtaMaestra = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
    Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
    Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
    CType(Me.gpDatos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpDatos.SuspendLayout()
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox2.SuspendLayout()
    CType(Me.ChkEstado, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtDNI, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtCtaMaestra, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'gpDatos
    '
    Me.gpDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor2 = System.Drawing.Color.White
    Me.gpDatos.ContentAreaAppearance = Appearance1
    Me.gpDatos.Controls.Add(Me.Lblerror)
    Me.gpDatos.Controls.Add(Me.UltraGroupBox2)
    Me.gpDatos.Controls.Add(Me.btnCerrar)
    Me.gpDatos.Controls.Add(Me.BtnGrabar)
    Me.gpDatos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gpDatos.Location = New System.Drawing.Point(-1, 0)
    Me.gpDatos.Name = "gpDatos"
    Me.gpDatos.Size = New System.Drawing.Size(488, 320)
    Me.gpDatos.TabIndex = 1
    Me.gpDatos.Text = "Actualiza Asistente..."
    Me.gpDatos.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'Lblerror
    '
    Me.Lblerror.BackColor = System.Drawing.Color.Transparent
    Me.Lblerror.ForeColor = System.Drawing.Color.White
    Me.Lblerror.Location = New System.Drawing.Point(113, 269)
    Me.Lblerror.Name = "Lblerror"
    Me.Lblerror.Size = New System.Drawing.Size(240, 30)
    Me.Lblerror.TabIndex = 109
    '
    'UltraGroupBox2
    '
    Appearance2.BackColor = System.Drawing.Color.White
    Me.UltraGroupBox2.ContentAreaAppearance = Appearance2
    Me.UltraGroupBox2.Controls.Add(Me.ChkEstado)
    Me.UltraGroupBox2.Controls.Add(Me.cboTipo)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel7)
    Me.UltraGroupBox2.Controls.Add(Me.txtObservacion)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
    Me.UltraGroupBox2.Controls.Add(Me.txtDNI)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
    Me.UltraGroupBox2.Controls.Add(Me.lblNombreCta)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox2.Controls.Add(Me.lblAsistente)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
    Me.UltraGroupBox2.Controls.Add(Me.txtCtaMaestra)
    Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
    Me.UltraGroupBox2.Location = New System.Drawing.Point(6, 22)
    Me.UltraGroupBox2.Name = "UltraGroupBox2"
    Me.UltraGroupBox2.Size = New System.Drawing.Size(480, 237)
    Me.UltraGroupBox2.TabIndex = 0
    Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'ChkEstado
    '
    Appearance3.FontData.BoldAsString = "True"
    Appearance3.FontData.Name = "Tahoma"
    Appearance3.FontData.SizeInPoints = 11.0!
    Appearance3.ForeColor = System.Drawing.Color.Navy
    Me.ChkEstado.Appearance = Appearance3
    Me.ChkEstado.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.ChkEstado.Location = New System.Drawing.Point(106, 110)
    Me.ChkEstado.Name = "ChkEstado"
    Me.ChkEstado.Size = New System.Drawing.Size(201, 26)
    Me.ChkEstado.TabIndex = 5
    Me.ChkEstado.Text = "Activo?"
    '
    'cboTipo
    '
    Appearance4.BackColor = System.Drawing.Color.LemonChiffon
    Me.cboTipo.Appearance = Appearance4
    Appearance5.FontData.BoldAsString = "True"
    Appearance5.FontData.Name = "Tahoma"
    Appearance5.ForeColor = System.Drawing.Color.Red
    Appearance5.TextHAlignAsString = "Right"
    Me.cboTipo.ButtonAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.White
    Me.cboTipo.DisplayLayout.Appearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.Transparent
    Me.cboTipo.DisplayLayout.Override.CardAreaAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.White
    Appearance8.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance8.FontData.BoldAsString = "True"
    Appearance8.FontData.Name = "Arial"
    Appearance8.FontData.SizeInPoints = 10.0!
    Appearance8.ForeColor = System.Drawing.Color.White
    Appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboTipo.DisplayLayout.Override.HeaderAppearance = Appearance8
    Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboTipo.DisplayLayout.Override.RowSelectorAppearance = Appearance9
    Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboTipo.DisplayLayout.Override.SelectedRowAppearance = Appearance10
    Me.cboTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboTipo.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboTipo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboTipo.Location = New System.Drawing.Point(107, 73)
    Me.cboTipo.Name = "cboTipo"
    Me.cboTipo.Size = New System.Drawing.Size(329, 25)
    Me.cboTipo.TabIndex = 4
    '
    'UltraLabel7
    '
    Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance11.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel7.Appearance = Appearance11
    Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel7.Location = New System.Drawing.Point(7, 78)
    Me.UltraLabel7.Name = "UltraLabel7"
    Me.UltraLabel7.Size = New System.Drawing.Size(96, 16)
    Me.UltraLabel7.TabIndex = 101
    Me.UltraLabel7.Text = "Tipo:"
    '
    'txtObservacion
    '
    Me.txtObservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtObservacion.Location = New System.Drawing.Point(106, 202)
    Me.txtObservacion.MaxLength = 80
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.Size = New System.Drawing.Size(330, 23)
    Me.txtObservacion.TabIndex = 7
    Me.txtObservacion.Text = "..."
    '
    'UltraLabel2
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel2.Appearance = Appearance12
    Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel2.Location = New System.Drawing.Point(2, 205)
    Me.UltraLabel2.Name = "UltraLabel2"
    Me.UltraLabel2.Size = New System.Drawing.Size(103, 16)
    Me.UltraLabel2.TabIndex = 96
    Me.UltraLabel2.Text = "Observación:"
    '
    'txtDNI
    '
    Appearance13.BackColor = System.Drawing.Color.LemonChiffon
    Me.txtDNI.Appearance = Appearance13
    Me.txtDNI.BackColor = System.Drawing.Color.LemonChiffon
    Me.txtDNI.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtDNI.Location = New System.Drawing.Point(107, 10)
    Me.txtDNI.MaxLength = 10
    Me.txtDNI.Name = "txtDNI"
    Me.txtDNI.Size = New System.Drawing.Size(125, 23)
    Me.txtDNI.TabIndex = 0
    '
    'UltraLabel5
    '
    Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance14.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel5.Appearance = Appearance14
    Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel5.Location = New System.Drawing.Point(7, 13)
    Me.UltraLabel5.Name = "UltraLabel5"
    Me.UltraLabel5.Size = New System.Drawing.Size(115, 16)
    Me.UltraLabel5.TabIndex = 91
    Me.UltraLabel5.Text = "DNI:"
    '
    'lblNombreCta
    '
    Appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance15.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance15.TextVAlignAsString = "Middle"
    Me.lblNombreCta.Appearance = Appearance15
    Me.lblNombreCta.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dashed
    Me.lblNombreCta.Location = New System.Drawing.Point(107, 176)
    Me.lblNombreCta.Name = "lblNombreCta"
    Me.lblNombreCta.Size = New System.Drawing.Size(329, 20)
    Me.lblNombreCta.TabIndex = 0
    '
    'UltraLabel1
    '
    Appearance16.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance16.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel1.Appearance = Appearance16
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel1.Location = New System.Drawing.Point(6, 42)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(95, 15)
    Me.UltraLabel1.TabIndex = 89
    Me.UltraLabel1.Text = "Nombre:"
    '
    'lblAsistente
    '
    Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance17.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance17.TextVAlignAsString = "Middle"
    Me.lblAsistente.Appearance = Appearance17
    Me.lblAsistente.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Dashed
    Me.lblAsistente.Location = New System.Drawing.Point(107, 39)
    Me.lblAsistente.Name = "lblAsistente"
    Me.lblAsistente.Size = New System.Drawing.Size(329, 20)
    Me.lblAsistente.TabIndex = 1
    '
    'UltraLabel3
    '
    Appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance18.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel3.Appearance = Appearance18
    Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel3.Location = New System.Drawing.Point(6, 178)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(100, 15)
    Me.UltraLabel3.TabIndex = 87
    Me.UltraLabel3.Text = "Nombre Cuenta"
    '
    'txtCtaMaestra
    '
    Me.txtCtaMaestra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtCtaMaestra.Location = New System.Drawing.Point(107, 148)
    Me.txtCtaMaestra.MaxLength = 7
    Me.txtCtaMaestra.Name = "txtCtaMaestra"
    Me.txtCtaMaestra.Size = New System.Drawing.Size(330, 23)
    Me.txtCtaMaestra.TabIndex = 6
    '
    'UltraLabel4
    '
    Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance19.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel4.Appearance = Appearance19
    Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel4.Location = New System.Drawing.Point(3, 151)
    Me.UltraLabel4.Name = "UltraLabel4"
    Me.UltraLabel4.Size = New System.Drawing.Size(103, 16)
    Me.UltraLabel4.TabIndex = 3
    Me.UltraLabel4.Text = "Cuenta Contable"
    '
    'btnCerrar
    '
    Appearance20.BackColor = System.Drawing.Color.White
    Appearance20.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance20.Image = CType(resources.GetObject("Appearance20.Image"), Object)
    Me.btnCerrar.Appearance = Appearance20
    Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCerrar.Location = New System.Drawing.Point(24, 272)
    Me.btnCerrar.Name = "btnCerrar"
    Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
    Me.btnCerrar.TabIndex = 2
    Me.btnCerrar.Text = "&Cerrar"
    Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'BtnGrabar
    '
    Appearance21.BackColor = System.Drawing.Color.White
    Appearance21.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance21.Image = CType(resources.GetObject("Appearance21.Image"), Object)
    Me.BtnGrabar.Appearance = Appearance21
    Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.BtnGrabar.Location = New System.Drawing.Point(359, 272)
    Me.BtnGrabar.Name = "BtnGrabar"
    Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
    Me.BtnGrabar.TabIndex = 1
    Me.BtnGrabar.Text = "&Grabar"
    Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'FrmPersona_CampaniaNM
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(487, 323)
    Me.Controls.Add(Me.gpDatos)
    Me.Name = "FrmPersona_CampaniaNM"
    Me.Text = "FrmPersona_CampaniaNM"
    CType(Me.gpDatos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpDatos.ResumeLayout(False)
    CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox2.ResumeLayout(False)
    Me.UltraGroupBox2.PerformLayout()
    CType(Me.ChkEstado, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtDNI, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtCtaMaestra, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents gpDatos As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents Lblerror As Label
  Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
  Friend WithEvents ChkEstado As Infragistics.Win.UltraWinEditors.UltraCheckEditor
  Friend WithEvents cboTipo As Infragistics.Win.UltraWinGrid.UltraCombo
  Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtObservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtDNI As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents lblNombreCta As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents lblAsistente As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents txtCtaMaestra As Infragistics.Win.UltraWinEditors.UltraTextEditor
  Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
  Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
  Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
End Class
