<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClave
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
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClave))
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblError = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTitulo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblPersona = New Infragistics.Win.Misc.UltraLabel()
        Me.txtUsuario = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.PictureBox1)
        Me.UltraGroupBox1.Controls.Add(Me.lblError)
        Me.UltraGroupBox1.Controls.Add(Me.lblTitulo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButton1)
        Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox1.Controls.Add(Me.UgbMCliente)
        Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(495, 327)
        Me.UltraGroupBox1.TabIndex = 2
        Me.UltraGroupBox1.Text = "Acceso al Sistema"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel5
        '
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance21.ForeColor = System.Drawing.SystemColors.Desktop
        Appearance21.TextVAlignAsString = "Top"
        Me.UltraLabel5.Appearance = Appearance21
        Me.UltraLabel5.Location = New System.Drawing.Point(87, 50)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(390, 34)
        Me.UltraLabel5.TabIndex = 69
        Me.UltraLabel5.Text = "Recuerde que la clave debe tener como minimo 6 caracteres y como máximo 20. Se le" & _
    " recomienda cambiar periodicamente su contraseña. "
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'lblError
        '
        Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance19.ForeColor = System.Drawing.Color.Navy
        Appearance19.TextVAlignAsString = "Middle"
        Me.lblError.Appearance = Appearance19
        Me.lblError.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblError.Location = New System.Drawing.Point(129, 288)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(258, 29)
        Me.lblError.TabIndex = 67
        '
        'lblTitulo
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblTitulo.Appearance = Appearance5
        Me.lblTitulo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(87, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(402, 21)
        Me.lblTitulo.TabIndex = 66
        Me.lblTitulo.Text = "CAMBIO DE DATOS PARA EL ACCESO"
        '
        'UltraButton1
        '
        Appearance53.BackColor = System.Drawing.Color.LightBlue
        Appearance53.BackColor2 = System.Drawing.Color.White
        Appearance53.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance53.ForeColor = System.Drawing.Color.Navy
        Appearance53.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UltraButton1.Appearance = Appearance53
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UltraButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButton1.Location = New System.Drawing.Point(460, 1)
        Me.UltraButton1.Name = "UltraButton1"
        Appearance54.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraButton1.PressedAppearance = Appearance54
        Me.UltraButton1.Size = New System.Drawing.Size(29, 16)
        Me.UltraButton1.TabIndex = 45
        Me.UltraButton1.Text = "x"
        Me.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnCerrar
        '
        Appearance35.BackColor = System.Drawing.Color.White
        Appearance35.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance35.Image = CType(resources.GetObject("Appearance35.Image"), Object)
        Me.btnCerrar.Appearance = Appearance35
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(40, 291)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance3
        Appearance2.AlphaLevel = CType(30, Short)
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance2
        Me.UgbMCliente.Controls.Add(Me.lblPersona)
        Me.UgbMCliente.Controls.Add(Me.txtUsuario)
        Me.UgbMCliente.Controls.Add(Me.txtClave)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel2)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(2, 90)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(489, 192)
        Me.UgbMCliente.TabIndex = 0
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblPersona
        '
        Appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance28.ForeColor = System.Drawing.Color.CornflowerBlue
        Appearance28.TextVAlignAsString = "Middle"
        Me.lblPersona.Appearance = Appearance28
        Me.lblPersona.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPersona.Location = New System.Drawing.Point(7, 20)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(468, 21)
        Me.lblPersona.TabIndex = 70
        Me.lblPersona.Text = "..."
        '
        'txtUsuario
        '
        Appearance6.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.txtUsuario.Appearance = Appearance6
        Me.txtUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtUsuario.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(179, 75)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(168, 29)
        Me.txtUsuario.TabIndex = 0
        '
        'txtClave
        '
        Appearance27.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtClave.Appearance = Appearance27
        Me.txtClave.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtClave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtClave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(179, 124)
        Me.txtClave.MaxLength = 20
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(168, 22)
        Me.txtClave.TabIndex = 1
        '
        'UltraLabel2
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.Navy
        Appearance34.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance34
        Me.UltraLabel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(59, 82)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(112, 17)
        Me.UltraLabel2.TabIndex = 63
        Me.UltraLabel2.Text = "USUARIO:"
        '
        'UltraLabel8
        '
        Appearance30.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance30.ForeColor = System.Drawing.Color.Navy
        Appearance30.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance30
        Me.UltraLabel8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(58, 126)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(113, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "INGRESE CLAVE:"
        '
        'BtnGrabar
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance1
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(393, 291)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'FrmClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(493, 326)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClave"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblError As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTitulo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtUsuario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPersona As Infragistics.Win.Misc.UltraLabel
End Class
