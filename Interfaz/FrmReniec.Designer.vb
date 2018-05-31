<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReniec
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReniec))
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.gpCapcha = New Infragistics.Win.Misc.UltraGroupBox()
    Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtApe_Mat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.txtApe_Pat = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.LblResul = New Infragistics.Win.Misc.UltraLabel()
    Me.txtRucDni = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.txtCapcha = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
    Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
    Me.pictureCapcha = New System.Windows.Forms.PictureBox()
    Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
    Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
    Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.gpCapcha, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCapcha.SuspendLayout()
    CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtApe_Mat, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtApe_Pat, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.UltraGroupBox1.Controls.Add(Me.gpCapcha)
    Me.UltraGroupBox1.Controls.Add(Me.UltraButton1)
    Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
    Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
    Me.UltraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, -1)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(393, 224)
    Me.UltraGroupBox1.TabIndex = 1
    Me.UltraGroupBox1.Text = "Obtener Datos RENIEC"
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'gpCapcha
    '
    Appearance2.BackColor = System.Drawing.Color.White
    Me.gpCapcha.Appearance = Appearance2
    Me.gpCapcha.Controls.Add(Me.txtNombre)
    Me.gpCapcha.Controls.Add(Me.txtApe_Mat)
    Me.gpCapcha.Controls.Add(Me.txtApe_Pat)
    Me.gpCapcha.Controls.Add(Me.LblResul)
    Me.gpCapcha.Controls.Add(Me.txtRucDni)
    Me.gpCapcha.Controls.Add(Me.UltraLabel1)
    Me.gpCapcha.Controls.Add(Me.txtCapcha)
    Me.gpCapcha.Controls.Add(Me.UltraLabel3)
    Me.gpCapcha.Controls.Add(Me.pictureCapcha)
    Me.gpCapcha.Location = New System.Drawing.Point(6, 21)
    Me.gpCapcha.Name = "gpCapcha"
    Me.gpCapcha.Size = New System.Drawing.Size(378, 158)
    Me.gpCapcha.TabIndex = 0
    '
    'txtNombre
    '
    Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtNombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtNombre.Location = New System.Drawing.Point(218, 108)
    Me.txtNombre.Name = "txtNombre"
    Me.txtNombre.ReadOnly = True
    Me.txtNombre.Size = New System.Drawing.Size(154, 22)
    Me.txtNombre.TabIndex = 109
    '
    'txtApe_Mat
    '
    Me.txtApe_Mat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtApe_Mat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtApe_Mat.Location = New System.Drawing.Point(218, 82)
    Me.txtApe_Mat.Name = "txtApe_Mat"
    Me.txtApe_Mat.ReadOnly = True
    Me.txtApe_Mat.Size = New System.Drawing.Size(154, 22)
    Me.txtApe_Mat.TabIndex = 108
    '
    'txtApe_Pat
    '
    Me.txtApe_Pat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtApe_Pat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtApe_Pat.Location = New System.Drawing.Point(218, 56)
    Me.txtApe_Pat.Name = "txtApe_Pat"
    Me.txtApe_Pat.ReadOnly = True
    Me.txtApe_Pat.Size = New System.Drawing.Size(154, 22)
    Me.txtApe_Pat.TabIndex = 107
    '
    'LblResul
    '
    Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance3.ForeColor = System.Drawing.Color.Navy
    Me.LblResul.Appearance = Appearance3
    Me.LblResul.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblResul.ImageTransparentColor = System.Drawing.Color.Empty
    Me.LblResul.Location = New System.Drawing.Point(6, 135)
    Me.LblResul.Name = "LblResul"
    Me.LblResul.Size = New System.Drawing.Size(367, 17)
    Me.LblResul.TabIndex = 99
    '
    'txtRucDni
    '
    Me.txtRucDni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtRucDni.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRucDni.Location = New System.Drawing.Point(60, 5)
    Me.txtRucDni.MaxLength = 8
    Me.txtRucDni.Name = "txtRucDni"
    Me.txtRucDni.ReadOnly = True
    Me.txtRucDni.Size = New System.Drawing.Size(143, 22)
    Me.txtRucDni.TabIndex = 105
    '
    'UltraLabel1
    '
    Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance4.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel1.Appearance = Appearance4
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel1.Location = New System.Drawing.Point(4, 8)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(64, 17)
    Me.UltraLabel1.TabIndex = 106
    Me.UltraLabel1.Text = "DNI:"
    '
    'txtCapcha
    '
    Me.txtCapcha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.txtCapcha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtCapcha.Location = New System.Drawing.Point(60, 31)
    Me.txtCapcha.MaxLength = 8
    Me.txtCapcha.Name = "txtCapcha"
    Me.txtCapcha.Size = New System.Drawing.Size(143, 22)
    Me.txtCapcha.TabIndex = 0
    '
    'UltraLabel3
    '
    Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance5.ForeColor = System.Drawing.Color.Navy
    Me.UltraLabel3.Appearance = Appearance5
    Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraLabel3.Location = New System.Drawing.Point(4, 34)
    Me.UltraLabel3.Name = "UltraLabel3"
    Me.UltraLabel3.Size = New System.Drawing.Size(64, 17)
    Me.UltraLabel3.TabIndex = 104
    Me.UltraLabel3.Text = "Capcha:"
    '
    'pictureCapcha
    '
    Me.pictureCapcha.Location = New System.Drawing.Point(6, 56)
    Me.pictureCapcha.Name = "pictureCapcha"
    Me.pictureCapcha.Size = New System.Drawing.Size(199, 74)
    Me.pictureCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pictureCapcha.TabIndex = 102
    Me.pictureCapcha.TabStop = False
    '
    'UltraButton1
    '
    Appearance6.BackColor = System.Drawing.Color.LightBlue
    Appearance6.BackColor2 = System.Drawing.Color.White
    Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance6.ForeColor = System.Drawing.Color.Navy
    Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
    Me.UltraButton1.Appearance = Appearance6
    Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
    Me.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.UltraButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UltraButton1.Location = New System.Drawing.Point(350, 2)
    Me.UltraButton1.Name = "UltraButton1"
    Appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent
    Me.UltraButton1.PressedAppearance = Appearance7
    Me.UltraButton1.Size = New System.Drawing.Size(29, 16)
    Me.UltraButton1.TabIndex = 47
    Me.UltraButton1.Text = "x"
    Me.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'btnCerrar
    '
    Appearance8.BackColor = System.Drawing.Color.White
    Appearance8.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
    Me.btnCerrar.Appearance = Appearance8
    Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCerrar.Location = New System.Drawing.Point(53, 182)
    Me.btnCerrar.Name = "btnCerrar"
    Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
    Me.btnCerrar.TabIndex = 2
    Me.btnCerrar.Text = "&Cerrar"
    Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'BtnGrabar
    '
    Appearance9.BackColor = System.Drawing.Color.White
    Appearance9.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance9.Image = Global.Phoenix.My.Resources.Resources.accept
    Me.BtnGrabar.Appearance = Appearance9
    Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.BtnGrabar.Location = New System.Drawing.Point(255, 182)
    Me.BtnGrabar.Name = "BtnGrabar"
    Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
    Me.BtnGrabar.TabIndex = 1
    Me.BtnGrabar.Text = "&OK"
    Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'FrmReniec
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.CancelButton = Me.btnCerrar
    Me.ClientSize = New System.Drawing.Size(389, 221)
    Me.ControlBox = False
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmReniec"
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    CType(Me.gpCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCapcha.ResumeLayout(False)
    Me.gpCapcha.PerformLayout()
    CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtApe_Mat, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtApe_Pat, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtRucDni, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pictureCapcha, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents gpCapcha As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblResul As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtRucDni As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCapcha As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents pictureCapcha As System.Windows.Forms.PictureBox
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtApe_Mat As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtApe_Pat As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
