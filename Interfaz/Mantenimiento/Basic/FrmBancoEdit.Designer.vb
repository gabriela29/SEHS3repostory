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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBanco))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.Textreferencia = New System.Windows.Forms.TextBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnAceptar = New Infragistics.Win.Misc.UltraButton()
        Me.TxtNom_banco = New System.Windows.Forms.TextBox()
        Me.txtabreviatura = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'UgbMCliente
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance1
        Appearance2.AlphaLevel = CType(30, Short)
        Appearance2.BackColor = System.Drawing.Color.RoyalBlue
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance2
        Me.UgbMCliente.Controls.Add(Me.btnCerrar)
        Me.UgbMCliente.Controls.Add(Me.Textreferencia)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel1)
        Me.UgbMCliente.Controls.Add(Me.BtnAceptar)
        Me.UgbMCliente.Controls.Add(Me.TxtNom_banco)
        Me.UgbMCliente.Controls.Add(Me.txtabreviatura)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(1, 0)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(388, 189)
        Me.UgbMCliente.TabIndex = 1
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnCerrar
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.btnCerrar.Appearance = Appearance3
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(222, 137)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'Textreferencia
        '
        Me.Textreferencia.Location = New System.Drawing.Point(99, 95)
        Me.Textreferencia.MaxLength = 5
        Me.Textreferencia.Name = "Textreferencia"
        Me.Textreferencia.Size = New System.Drawing.Size(95, 20)
        Me.Textreferencia.TabIndex = 52
        '
        'UltraLabel1
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 97)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel1.TabIndex = 53
        Me.UltraLabel1.Text = "Referencia:"
        '
        'BtnAceptar
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.BtnAceptar.Appearance = Appearance5
        Me.BtnAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnAceptar.Location = New System.Drawing.Point(84, 137)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(83, 27)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'TxtNom_banco
        '
        Me.TxtNom_banco.Location = New System.Drawing.Point(99, 28)
        Me.TxtNom_banco.MaxLength = 30
        Me.TxtNom_banco.Name = "TxtNom_banco"
        Me.TxtNom_banco.Size = New System.Drawing.Size(221, 20)
        Me.TxtNom_banco.TabIndex = 0
        '
        'txtabreviatura
        '
        Me.txtabreviatura.Location = New System.Drawing.Point(99, 61)
        Me.txtabreviatura.MaxLength = 5
        Me.txtabreviatura.Name = "txtabreviatura"
        Me.txtabreviatura.Size = New System.Drawing.Size(95, 20)
        Me.txtabreviatura.TabIndex = 2
        '
        'UltraLabel5
        '
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance6.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance6
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 62)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Nombre Corto:"
        '
        'UltraLabel8
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance7
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 28)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Nombre: "
        '
        'frmBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(385, 187)
        Me.ControlBox = False
        Me.Controls.Add(Me.UgbMCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBanco"
        Me.ShowInTaskbar = False
        Me.Text = "Banco"
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TxtNom_banco As TextBox
    Friend WithEvents txtabreviatura As TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnAceptar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Textreferencia As TextBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
