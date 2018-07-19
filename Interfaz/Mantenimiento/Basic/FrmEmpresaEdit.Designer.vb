<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmpresaEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpresaEdit))
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.Btncerrar1 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Texturl = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.Textdireccion = New System.Windows.Forms.TextBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancelarEm = New Infragistics.Win.Misc.UltraButton()
        Me.TxtNom_empresa = New System.Windows.Forms.TextBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtruc = New System.Windows.Forms.TextBox()
        Me.BtnAceptarEm = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.LblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.Btncerrar1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-3, -2)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(436, 301)
        Me.UltraGroupBox1.TabIndex = 8
        Me.UltraGroupBox1.Text = "Actualizando Información"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'LblCodigo
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance1.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance1
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblCodigo.Location = New System.Drawing.Point(103, 19)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LblCodigo.TabIndex = 46
        '
        'UltraLabel4
        '
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance2.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance2
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 19)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel4.TabIndex = 47
        Me.UltraLabel4.Text = "Empresa"
        Me.UltraLabel4.Visible = False
        '
        'Btncerrar1
        '
        Appearance3.BackColor = System.Drawing.Color.LightBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.Btncerrar1.Appearance = Appearance3
        Me.Btncerrar1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.Btncerrar1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btncerrar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btncerrar1.Location = New System.Drawing.Point(407, 1)
        Me.Btncerrar1.Name = "Btncerrar1"
        Appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.Btncerrar1.PressedAppearance = Appearance4
        Me.Btncerrar1.Size = New System.Drawing.Size(29, 16)
        Me.Btncerrar1.TabIndex = 45
        Me.Btncerrar1.Text = "x"
        Me.Btncerrar1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraGroupBox2
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UltraGroupBox2.Appearance = Appearance5
        Appearance6.AlphaLevel = CType(30, Short)
        Appearance6.BackColor = System.Drawing.Color.RoyalBlue
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance6
        Me.UltraGroupBox2.Controls.Add(Me.Texturl)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox2.Controls.Add(Me.Textdireccion)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.btnCancelarEm)
        Me.UltraGroupBox2.Controls.Add(Me.TxtNom_empresa)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.txtruc)
        Me.UltraGroupBox2.Controls.Add(Me.BtnAceptarEm)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(15, 45)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(392, 215)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'Texturl
        '
        Me.Texturl.Location = New System.Drawing.Point(88, 125)
        Me.Texturl.MaxLength = 30
        Me.Texturl.Name = "Texturl"
        Me.Texturl.Size = New System.Drawing.Size(272, 20)
        Me.Texturl.TabIndex = 54
        '
        'UltraLabel5
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance7
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(42, 128)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(40, 20)
        Me.UltraLabel5.TabIndex = 55
        Me.UltraLabel5.Text = "URL:"
        '
        'Textdireccion
        '
        Me.Textdireccion.Location = New System.Drawing.Point(88, 93)
        Me.Textdireccion.MaxLength = 30
        Me.Textdireccion.Name = "Textdireccion"
        Me.Textdireccion.Size = New System.Drawing.Size(272, 20)
        Me.Textdireccion.TabIndex = 0
        '
        'UltraLabel1
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance8
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(13, 93)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(75, 20)
        Me.UltraLabel1.TabIndex = 53
        Me.UltraLabel1.Text = "Dirección:"
        '
        'btnCancelarEm
        '
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        Me.btnCancelarEm.Appearance = Appearance9
        Me.btnCancelarEm.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCancelarEm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarEm.Location = New System.Drawing.Point(218, 170)
        Me.btnCancelarEm.Name = "btnCancelarEm"
        Me.btnCancelarEm.Size = New System.Drawing.Size(83, 27)
        Me.btnCancelarEm.TabIndex = 4
        Me.btnCancelarEm.Text = "&Cancelar"
        Me.btnCancelarEm.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'TxtNom_empresa
        '
        Me.TxtNom_empresa.Location = New System.Drawing.Point(88, 26)
        Me.TxtNom_empresa.MaxLength = 30
        Me.TxtNom_empresa.Name = "TxtNom_empresa"
        Me.TxtNom_empresa.Size = New System.Drawing.Size(272, 20)
        Me.TxtNom_empresa.TabIndex = 0
        '
        'UltraLabel2
        '
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(41, 61)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(38, 20)
        Me.UltraLabel2.TabIndex = 51
        Me.UltraLabel2.Text = "RUC:"
        '
        'txtruc
        '
        Me.txtruc.Location = New System.Drawing.Point(88, 59)
        Me.txtruc.MaxLength = 30
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(213, 20)
        Me.txtruc.TabIndex = 0
        '
        'BtnAceptarEm
        '
        Appearance11.BackColor = System.Drawing.Color.White
        Appearance11.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        Me.BtnAceptarEm.Appearance = Appearance11
        Me.BtnAceptarEm.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnAceptarEm.Location = New System.Drawing.Point(81, 170)
        Me.BtnAceptarEm.Name = "BtnAceptarEm"
        Me.BtnAceptarEm.Size = New System.Drawing.Size(83, 27)
        Me.BtnAceptarEm.TabIndex = 3
        Me.BtnAceptarEm.Text = "&Grabar"
        Me.BtnAceptarEm.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraLabel3
        '
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(23, 28)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel3.TabIndex = 41
        Me.UltraLabel3.Text = "Nombre: "
        '
        'FrmEmpresaEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMinSize = New System.Drawing.Size(1, 2)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmpresaEdit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btncerrar1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Textdireccion As TextBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancelarEm As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtNom_empresa As TextBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtruc As TextBox
    Friend WithEvents BtnAceptarEm As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Texturl As TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
End Class
