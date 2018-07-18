<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBanco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBanco))
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
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.Textreferencia = New System.Windows.Forms.TextBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnAceptar = New Infragistics.Win.Misc.UltraButton()
        Me.TxtNom_banco = New System.Windows.Forms.TextBox()
        Me.txtabreviatura = New System.Windows.Forms.TextBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.Btncerrar1 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnCerrar.Appearance = Appearance1
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(169, 131)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'Textreferencia
        '
        Me.Textreferencia.Location = New System.Drawing.Point(109, 88)
        Me.Textreferencia.MaxLength = 5
        Me.Textreferencia.Name = "Textreferencia"
        Me.Textreferencia.Size = New System.Drawing.Size(95, 20)
        Me.Textreferencia.TabIndex = 52
        '
        'UltraLabel1
        '
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance2.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(27, 90)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(75, 20)
        Me.UltraLabel1.TabIndex = 53
        Me.UltraLabel1.Text = "Referencia:"
        '
        'BtnAceptar
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.BtnAceptar.Appearance = Appearance3
        Me.BtnAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnAceptar.Location = New System.Drawing.Point(64, 131)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(83, 27)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'TxtNom_banco
        '
        Me.TxtNom_banco.Location = New System.Drawing.Point(109, 21)
        Me.TxtNom_banco.MaxLength = 30
        Me.TxtNom_banco.Name = "TxtNom_banco"
        Me.TxtNom_banco.Size = New System.Drawing.Size(213, 20)
        Me.TxtNom_banco.TabIndex = 0
        '
        'txtabreviatura
        '
        Me.txtabreviatura.Location = New System.Drawing.Point(109, 54)
        Me.txtabreviatura.MaxLength = 5
        Me.txtabreviatura.Name = "txtabreviatura"
        Me.txtabreviatura.Size = New System.Drawing.Size(95, 20)
        Me.txtabreviatura.TabIndex = 2
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.LblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.Btncerrar1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(349, 236)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.Text = "Actualizando Información"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'LblCodigo
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance4
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblCodigo.Location = New System.Drawing.Point(103, 19)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LblCodigo.TabIndex = 46
        '
        'UltraLabel4
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance5
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 19)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel4.TabIndex = 47
        Me.UltraLabel4.Text = "Banco"
        Me.UltraLabel4.Visible = False
        '
        'Btncerrar1
        '
        Appearance6.BackColor = System.Drawing.Color.LightBlue
        Appearance6.BackColor2 = System.Drawing.Color.White
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.ForeColor = System.Drawing.Color.Navy
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.Btncerrar1.Appearance = Appearance6
        Me.Btncerrar1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.Btncerrar1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btncerrar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btncerrar1.Location = New System.Drawing.Point(313, 0)
        Me.Btncerrar1.Name = "Btncerrar1"
        Appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.Btncerrar1.PressedAppearance = Appearance7
        Me.Btncerrar1.Size = New System.Drawing.Size(29, 16)
        Me.Btncerrar1.TabIndex = 45
        Me.Btncerrar1.Text = "x"
        Me.Btncerrar1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraGroupBox2
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UltraGroupBox2.Appearance = Appearance8
        Appearance9.AlphaLevel = CType(30, Short)
        Appearance9.BackColor = System.Drawing.Color.RoyalBlue
        Appearance9.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance9
        Me.UltraGroupBox2.Controls.Add(Me.Textreferencia)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox2.Controls.Add(Me.TxtNom_banco)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.txtabreviatura)
        Me.UltraGroupBox2.Controls.Add(Me.BtnAceptar)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(2, 43)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(340, 168)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel2
        '
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(9, 58)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel2.TabIndex = 51
        Me.UltraLabel2.Text = "Nombre Corto:"
        '
        'UltraLabel3
        '
        Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance11.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(44, 23)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel3.TabIndex = 41
        Me.UltraLabel3.Text = "Nombre: "
        '
        'frmBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(339, 231)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBanco"
        Me.ShowInTaskbar = False
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtNom_banco As TextBox
    Friend WithEvents txtabreviatura As TextBox
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnAceptar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Textreferencia As TextBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btncerrar1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
