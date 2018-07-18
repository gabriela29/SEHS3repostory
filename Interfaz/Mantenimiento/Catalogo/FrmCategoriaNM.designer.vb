<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoriaNM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCategoriaNM))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.txtAbrev = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.LblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButton1)
        Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
        Me.UltraGroupBox1.Controls.Add(Me.UgbMCliente)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-5, -1)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(335, 209)
        Me.UltraGroupBox1.TabIndex = 6
        Me.UltraGroupBox1.Text = "Actualizanado Categorías"
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
        Me.UltraLabel4.Text = "Código"
        Me.UltraLabel4.Visible = False
        '
        'UltraButton1
        '
        Appearance3.BackColor = System.Drawing.Color.LightBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UltraButton1.Appearance = Appearance3
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UltraButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButton1.Location = New System.Drawing.Point(296, 0)
        Me.UltraButton1.Name = "UltraButton1"
        Appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraButton1.PressedAppearance = Appearance4
        Me.UltraButton1.Size = New System.Drawing.Size(29, 16)
        Me.UltraButton1.TabIndex = 45
        Me.UltraButton1.Text = "x"
        Me.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnCerrar
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnCerrar.Appearance = Appearance5
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(179, 172)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'BtnGrabar
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance6
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(90, 172)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance7
        Appearance8.AlphaLevel = CType(30, Short)
        Appearance8.BackColor = System.Drawing.Color.RoyalBlue
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance8
        Me.UgbMCliente.Controls.Add(Me.TxtNombre)
        Me.UgbMCliente.Controls.Add(Me.txtAbrev)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(2, 43)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(327, 123)
        Me.UgbMCliente.TabIndex = 0
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(99, 28)
        Me.TxtNombre.MaxLength = 30
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(221, 20)
        Me.TxtNombre.TabIndex = 0
        '
        'txtAbrev
        '
        Me.txtAbrev.Location = New System.Drawing.Point(99, 61)
        Me.txtAbrev.MaxLength = 5
        Me.txtAbrev.Name = "txtAbrev"
        Me.txtAbrev.Size = New System.Drawing.Size(95, 20)
        Me.txtAbrev.TabIndex = 2
        '
        'UltraLabel5
        '
        Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance9.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance9
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 62)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Nombre Corto:"
        '
        'UltraLabel8
        '
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance10
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 28)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Nombre: "
        '
        'FrmCategoriaNM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(328, 207)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCategoriaNM"
        Me.ShowInTaskbar = False
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtAbrev As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
End Class
