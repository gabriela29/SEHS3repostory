<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCapcha
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCapcha))
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.LblResul = New Infragistics.Win.Misc.UltraLabel()
    Me.txtDNID = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtTelefonos = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtDireccion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.TxtHabido = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtActivo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtTipoPer = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtRazSocial = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtRuc = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.gpCapcha = New Infragistics.Win.Misc.UltraGroupBox()
    Me.btnMostrarImg = New Infragistics.Win.Misc.UltraButton()
    Me.txtRucDni = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.BtnOk = New Infragistics.Win.Misc.UltraButton()
    Me.lblNombreDoc = New Infragistics.Win.Misc.UltraLabel()
    Me.txtCapcha = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.pictureCapcha = New System.Windows.Forms.PictureBox()
    Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.txtDNID, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TxtHabido, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtActivo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtTipoPer, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtRazSocial, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.gpCapcha, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCapcha.SuspendLayout()
    CType(Me.txtRucDni, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtCapcha, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pictureCapcha, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox1.ContentAreaAppearance = Appearance1
    Me.UltraGroupBox1.Controls.Add(Me.LblResul)
    Me.UltraGroupBox1.Controls.Add(Me.txtDNID)
    Me.UltraGroupBox1.Controls.Add(Me.txtTelefonos)
    Me.UltraGroupBox1.Controls.Add(Me.txtDireccion)
    Me.UltraGroupBox1.Controls.Add(Me.TxtHabido)
    Me.UltraGroupBox1.Controls.Add(Me.txtActivo)
    Me.UltraGroupBox1.Controls.Add(Me.txtTipoPer)
    Me.UltraGroupBox1.Controls.Add(Me.txtRazSocial)
    Me.UltraGroupBox1.Controls.Add(Me.txtRuc)
    Me.UltraGroupBox1.Controls.Add(Me.gpCapcha)
    Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
    Me.UltraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(297, 196)
    Me.UltraGroupBox1.TabIndex = 0
    Me.UltraGroupBox1.Text = "Obtener Datos"
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'LblResul
    '
    Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance2.ForeColor = System.Drawing.Color.Navy
    Me.LblResul.Appearance = Appearance2
    Me.LblResul.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblResul.ImageTransparentColor = System.Drawing.Color.Empty
    Me.LblResul.Location = New System.Drawing.Point(6, 185)
    Me.LblResul.Name = "LblResul"
    Me.LblResul.Size = New System.Drawing.Size(284, 17)
    Me.LblResul.TabIndex = 100
    '
    'txtDNID
    '
    Me.txtDNID.Location = New System.Drawing.Point(320, 27)
    Me.txtDNID.Name = "txtDNID"
    Me.txtDNID.Size = New System.Drawing.Size(276, 23)
    Me.txtDNID.TabIndex = 55
    '
    'txtTelefonos
    '
    Me.txtTelefonos.Location = New System.Drawing.Point(8, 284)
    Me.txtTelefonos.Name = "txtTelefonos"
    Me.txtTelefonos.Size = New System.Drawing.Size(276, 23)
    Me.txtTelefonos.TabIndex = 54
    '
    'txtDireccion
    '
    Me.txtDireccion.Location = New System.Drawing.Point(8, 257)
    Me.txtDireccion.Name = "txtDireccion"
    Me.txtDireccion.Size = New System.Drawing.Size(276, 23)
    Me.txtDireccion.TabIndex = 53
    '
    'TxtHabido
    '
    Me.TxtHabido.Location = New System.Drawing.Point(320, 164)
    Me.TxtHabido.Name = "TxtHabido"
    Me.TxtHabido.Size = New System.Drawing.Size(276, 23)
    Me.TxtHabido.TabIndex = 52
    '
    'txtActivo
    '
    Me.txtActivo.Location = New System.Drawing.Point(320, 135)
    Me.txtActivo.Name = "txtActivo"
    Me.txtActivo.Size = New System.Drawing.Size(276, 23)
    Me.txtActivo.TabIndex = 51
    '
    'txtTipoPer
    '
    Me.txtTipoPer.Location = New System.Drawing.Point(320, 108)
    Me.txtTipoPer.Name = "txtTipoPer"
    Me.txtTipoPer.Size = New System.Drawing.Size(276, 23)
    Me.txtTipoPer.TabIndex = 50
    '
    'txtRazSocial
    '
    Me.txtRazSocial.Location = New System.Drawing.Point(320, 81)
    Me.txtRazSocial.Name = "txtRazSocial"
    Me.txtRazSocial.Size = New System.Drawing.Size(276, 23)
    Me.txtRazSocial.TabIndex = 49
    '
    'txtRuc
    '
    Me.txtRuc.Location = New System.Drawing.Point(320, 54)
    Me.txtRuc.Name = "txtRuc"
    Me.txtRuc.Size = New System.Drawing.Size(276, 23)
    Me.txtRuc.TabIndex = 48
    '
    'gpCapcha
    '
    Appearance3.BackColor = System.Drawing.Color.White
    Me.gpCapcha.Appearance = Appearance3
    Me.gpCapcha.Controls.Add(Me.btnMostrarImg)
    Me.gpCapcha.Controls.Add(Me.txtRucDni)
    Me.gpCapcha.Controls.Add(Me.BtnOk)
    Me.gpCapcha.Controls.Add(Me.lblNombreDoc)
    Me.gpCapcha.Controls.Add(Me.txtCapcha)
    Me.gpCapcha.Controls.Add(Me.UltraLabel3)
    Me.gpCapcha.Controls.Add(Me.pictureCapcha)
    Me.gpCapcha.Location = New System.Drawing.Point(6, 21)
    Me.gpCapcha.Name = "gpCapcha"
    Me.gpCapcha.Size = New System.Drawing.Size(284, 161)
    Me.gpCapcha.TabIndex = 0
    '
    'btnMostrarImg
    '
    Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance4.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance4.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.btnMostrarImg.Appearance = Appearance4
    Me.btnMostrarImg.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnMostrarImg.Location = New System.Drawing.Point(39, 135)
    Me.btnMostrarImg.Name = "btnMostrarImg"
    Me.btnMostrarImg.Size = New System.Drawing.Size(198, 24)
    Me.btnMostrarImg.TabIndex = 3
    Me.btnMostrarImg.Text = "Mostrar Otra Imagen"
    Me.btnMostrarImg.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'txtRucDni
    '
    Me.txtRucDni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtRucDni.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRucDni.Location = New System.Drawing.Point(93, 7)
    Me.txtRucDni.MaxLength = 11
    Me.txtRucDni.Name = "txtRucDni"
    Me.txtRucDni.ReadOnly = True
    Me.txtRucDni.Size = New System.Drawing.Size(143, 22)
    Me.txtRucDni.TabIndex = 2
    '
    'BtnOk
    '
    Appearance5.BackColor = System.Drawing.Color.White
    Appearance5.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance5.Image = Global.Phoenix.My.Resources.Resources.accept
    Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
    Me.BtnOk.Appearance = Appearance5
    Me.BtnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.BtnOk.Location = New System.Drawing.Point(240, 33)
    Me.BtnOk.Name = "BtnOk"
    Me.BtnOk.Size = New System.Drawing.Size(38, 27)
    Me.BtnOk.TabIndex = 1
    Me.BtnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'lblNombreDoc
    '
    Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance6.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance6.TextHAlignAsString = "Right"
    Me.lblNombreDoc.Appearance = Appearance6
    Me.lblNombreDoc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblNombreDoc.Location = New System.Drawing.Point(6, 10)
    Me.lblNombreDoc.Name = "lblNombreDoc"
    Me.lblNombreDoc.Size = New System.Drawing.Size(81, 17)
    Me.lblNombreDoc.TabIndex = 106
    Me.lblNombreDoc.Text = "Documento:"
    '
    'txtCapcha
    '
    Me.txtCapcha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtCapcha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCapcha.Location = New System.Drawing.Point(93, 33)
    Me.txtCapcha.MaxLength = 4
    Me.txtCapcha.Name = "txtCapcha"
    Me.txtCapcha.Size = New System.Drawing.Size(143, 22)
    Me.txtCapcha.TabIndex = 0
    '
    'UltraLabel3
    '
    Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance7.ForeColor = System.Drawing.Color.CornflowerBlue
    Appearance7.TextHAlignAsString = "Right"
    Me.UltraLabel3.Appearance = Appearance7
    Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel3.Location = New System.Drawing.Point(6, 36)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(81, 17)
    Me.UltraLabel3.TabIndex = 104
    Me.UltraLabel3.Text = "Capcha:"
    '
    'pictureCapcha
    '
    Me.pictureCapcha.Location = New System.Drawing.Point(39, 59)
    Me.pictureCapcha.Name = "pictureCapcha"
    Me.pictureCapcha.Size = New System.Drawing.Size(199, 73)
    Me.pictureCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pictureCapcha.TabIndex = 102
    Me.pictureCapcha.TabStop = False
    '
    'btnCerrar
    '
    Appearance8.BackColor = System.Drawing.Color.LightBlue
    Appearance8.BackColor2 = System.Drawing.Color.White
    Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance8.ForeColor = System.Drawing.Color.Navy
    Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
    Me.btnCerrar.Appearance = Appearance8
    Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
    Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCerrar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnCerrar.Location = New System.Drawing.Point(261, 0)
    Me.btnCerrar.Name = "btnCerrar"
    Appearance9.BorderAlpha = Infragistics.Win.Alpha.Transparent
    Me.btnCerrar.PressedAppearance = Appearance9
    Me.btnCerrar.Size = New System.Drawing.Size(29, 16)
    Me.btnCerrar.TabIndex = 47
    Me.btnCerrar.Text = "x"
    Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'FrmCapcha
    '
    Me.AcceptButton = Me.BtnOk
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.CancelButton = Me.btnCerrar
    Me.ClientSize = New System.Drawing.Size(296, 198)
    Me.ControlBox = False
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmCapcha"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    Me.UltraGroupBox1.PerformLayout()
    CType(Me.txtDNID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TxtHabido, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtActivo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtTipoPer, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtRazSocial, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.gpCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCapcha.ResumeLayout(False)
    Me.gpCapcha.PerformLayout()
    CType(Me.txtRucDni, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pictureCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents gpCapcha As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtRucDni As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNombreDoc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCapcha As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents pictureCapcha As System.Windows.Forms.PictureBox
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnMostrarImg As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDNID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTelefonos As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDireccion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtHabido As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtActivo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTipoPer As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtRazSocial As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtRuc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents LblResul As Infragistics.Win.Misc.UltraLabel
End Class
