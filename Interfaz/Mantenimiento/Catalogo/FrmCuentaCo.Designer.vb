<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentaCo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentaCo))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.textbancoid = New System.Windows.Forms.TextBox()
        Me.txtempresa = New System.Windows.Forms.TextBox()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtreferencia = New System.Windows.Forms.TextBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtsucursal = New System.Windows.Forms.TextBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtempresaid = New System.Windows.Forms.TextBox()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraLabel4
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance1.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance1
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(19, 15)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel4.TabIndex = 35
        Me.UltraLabel4.Text = "Código"
        Me.UltraLabel4.Visible = False
        '
        'btnCerrar
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCerrar.Appearance = Appearance2
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(176, 344)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 34
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'BtnGrabar
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance3
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(56, 344)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 33
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.Location = New System.Drawing.Point(99, 113)
        Me.txtAbreviatura.MaxLength = 10
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(181, 20)
        Me.txtAbreviatura.TabIndex = 4
        '
        'UltraLabel6
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel6.Appearance = Appearance4
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(7, 114)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel6.TabIndex = 53
        Me.UltraLabel6.Text = "Abreviatura:"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(99, 82)
        Me.txtnumero.MaxLength = 50
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(181, 20)
        Me.txtnumero.TabIndex = 3
        '
        'UltraLabel5
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 83)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Numero: "
        '
        'UgbMCliente
        '
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UgbMCliente.Appearance = Appearance6
        Me.UgbMCliente.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularInset
        Me.UgbMCliente.Controls.Add(Me.txtempresaid)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel9)
        Me.UgbMCliente.Controls.Add(Me.textbancoid)
        Me.UgbMCliente.Controls.Add(Me.txtempresa)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel7)
        Me.UgbMCliente.Controls.Add(Me.txtmoneda)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel3)
        Me.UgbMCliente.Controls.Add(Me.txtreferencia)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel2)
        Me.UgbMCliente.Controls.Add(Me.txtsucursal)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel1)
        Me.UgbMCliente.Controls.Add(Me.txtAbreviatura)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel6)
        Me.UgbMCliente.Controls.Add(Me.txtnumero)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(12, 41)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(303, 297)
        Me.UgbMCliente.TabIndex = 32
        '
        'textbancoid
        '
        Me.textbancoid.Location = New System.Drawing.Point(98, 16)
        Me.textbancoid.MaxLength = 50
        Me.textbancoid.Name = "textbancoid"
        Me.textbancoid.Size = New System.Drawing.Size(182, 20)
        Me.textbancoid.TabIndex = 62
        '
        'txtempresa
        '
        Me.txtempresa.Location = New System.Drawing.Point(99, 257)
        Me.txtempresa.MaxLength = 10
        Me.txtempresa.Name = "txtempresa"
        Me.txtempresa.Size = New System.Drawing.Size(181, 20)
        Me.txtempresa.TabIndex = 60
        '
        'UltraLabel7
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel7.Appearance = Appearance8
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(7, 259)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel7.TabIndex = 61
        Me.UltraLabel7.Text = "Empresa: "
        '
        'txtmoneda
        '
        Me.txtmoneda.Location = New System.Drawing.Point(98, 221)
        Me.txtmoneda.MaxLength = 10
        Me.txtmoneda.Name = "txtmoneda"
        Me.txtmoneda.Size = New System.Drawing.Size(182, 20)
        Me.txtmoneda.TabIndex = 58
        '
        'UltraLabel3
        '
        Appearance9.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance9.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance9
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 222)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel3.TabIndex = 59
        Me.UltraLabel3.Text = "Moneda:"
        '
        'txtreferencia
        '
        Me.txtreferencia.Location = New System.Drawing.Point(98, 184)
        Me.txtreferencia.MaxLength = 10
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(182, 20)
        Me.txtreferencia.TabIndex = 56
        '
        'UltraLabel2
        '
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(6, 185)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel2.TabIndex = 57
        Me.UltraLabel2.Text = "Referencia:"
        '
        'txtsucursal
        '
        Me.txtsucursal.Location = New System.Drawing.Point(99, 149)
        Me.txtsucursal.MaxLength = 10
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(181, 20)
        Me.txtsucursal.TabIndex = 54
        '
        'UltraLabel1
        '
        Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance11.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance11
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 151)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel1.TabIndex = 55
        Me.UltraLabel1.Text = "Sucursal:"
        '
        'UltraLabel8
        '
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance12
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 18)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Banco Id:"
        '
        'txtempresaid
        '
        Me.txtempresaid.Location = New System.Drawing.Point(98, 48)
        Me.txtempresaid.MaxLength = 50
        Me.txtempresaid.Name = "txtempresaid"
        Me.txtempresaid.Size = New System.Drawing.Size(182, 20)
        Me.txtempresaid.TabIndex = 64
        Me.txtempresaid.UseWaitCursor = True
        '
        'UltraLabel9
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel9.Appearance = Appearance7
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel9.Location = New System.Drawing.Point(7, 50)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel9.TabIndex = 63
        Me.UltraLabel9.Text = "Empresa Id:"
        '
        'FrmCuentaCo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 389)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.BtnGrabar)
        Me.Controls.Add(Me.UgbMCliente)
        Me.Name = "FrmCuentaCo"
        Me.Text = "CuentaCo"
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAbreviatura As TextBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtnumero As TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtempresa As TextBox
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtmoneda As TextBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtreferencia As TextBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtsucursal As TextBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents textbancoid As TextBox
    Friend WithEvents txtempresaid As TextBox
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
End Class
