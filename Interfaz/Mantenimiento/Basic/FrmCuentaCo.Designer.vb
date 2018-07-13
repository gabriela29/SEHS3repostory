<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCuentaCo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentaCo))
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
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cbobanco = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtempresaid = New System.Windows.Forms.TextBox()
        Me.txtempresa = New System.Windows.Forms.TextBox()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtreferencia = New System.Windows.Forms.TextBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtsucursal = New System.Windows.Forms.TextBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.cbobanco, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCerrar.Location = New System.Drawing.Point(170, 362)
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
        Me.BtnGrabar.Location = New System.Drawing.Point(61, 362)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 33
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.Location = New System.Drawing.Point(105, 128)
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
        Me.UltraLabel6.Location = New System.Drawing.Point(13, 129)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel6.TabIndex = 53
        Me.UltraLabel6.Text = "Abreviatura:"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(105, 97)
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
        Me.UltraLabel5.Location = New System.Drawing.Point(13, 98)
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
        Me.UgbMCliente.Controls.Add(Me.cbobanco)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel10)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel9)
        Me.UgbMCliente.Controls.Add(Me.txtempresaid)
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
        Me.UgbMCliente.Location = New System.Drawing.Point(12, 41)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(303, 305)
        Me.UgbMCliente.TabIndex = 32
        '
        'cbobanco
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.cbobanco.DisplayLayout.Appearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.cbobanco.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.White
        Appearance9.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Arial"
        Appearance9.FontData.SizeInPoints = 10.0!
        Appearance9.ForeColor = System.Drawing.Color.White
        Appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cbobanco.DisplayLayout.Override.HeaderAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cbobanco.DisplayLayout.Override.RowSelectorAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cbobanco.DisplayLayout.Override.SelectedRowAppearance = Appearance11
        Me.cbobanco.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cbobanco.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cbobanco.Location = New System.Drawing.Point(104, 27)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(182, 22)
        Me.cbobanco.TabIndex = 65
        '
        'UltraLabel10
        '
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel10.Appearance = Appearance12
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel10.Location = New System.Drawing.Point(12, 29)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(72, 20)
        Me.UltraLabel10.TabIndex = 66
        Me.UltraLabel10.Text = "Banco:"
        '
        'UltraLabel9
        '
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel9.Appearance = Appearance13
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel9.Location = New System.Drawing.Point(13, 65)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel9.TabIndex = 63
        Me.UltraLabel9.Text = "Empresa Id:"
        '
        'txtempresaid
        '
        Me.txtempresaid.Location = New System.Drawing.Point(104, 63)
        Me.txtempresaid.MaxLength = 50
        Me.txtempresaid.Name = "txtempresaid"
        Me.txtempresaid.Size = New System.Drawing.Size(182, 20)
        Me.txtempresaid.TabIndex = 64
        '
        'txtempresa
        '
        Me.txtempresa.Location = New System.Drawing.Point(105, 272)
        Me.txtempresa.MaxLength = 10
        Me.txtempresa.Name = "txtempresa"
        Me.txtempresa.Size = New System.Drawing.Size(181, 20)
        Me.txtempresa.TabIndex = 60
        '
        'UltraLabel7
        '
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel7.Appearance = Appearance14
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(13, 274)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel7.TabIndex = 61
        Me.UltraLabel7.Text = "Empresa: "
        '
        'txtmoneda
        '
        Me.txtmoneda.Location = New System.Drawing.Point(104, 236)
        Me.txtmoneda.MaxLength = 10
        Me.txtmoneda.Name = "txtmoneda"
        Me.txtmoneda.Size = New System.Drawing.Size(182, 20)
        Me.txtmoneda.TabIndex = 58
        '
        'UltraLabel3
        '
        Appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance15.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance15
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 237)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel3.TabIndex = 59
        Me.UltraLabel3.Text = "Moneda:"
        '
        'txtreferencia
        '
        Me.txtreferencia.Location = New System.Drawing.Point(104, 199)
        Me.txtreferencia.MaxLength = 10
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(182, 20)
        Me.txtreferencia.TabIndex = 56
        '
        'UltraLabel2
        '
        Appearance16.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance16.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance16
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 200)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel2.TabIndex = 57
        Me.UltraLabel2.Text = "Referencia:"
        '
        'txtsucursal
        '
        Me.txtsucursal.Location = New System.Drawing.Point(105, 164)
        Me.txtsucursal.MaxLength = 10
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(181, 20)
        Me.txtsucursal.TabIndex = 54
        '
        'UltraLabel1
        '
        Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance17.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance17
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 166)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel1.TabIndex = 55
        Me.UltraLabel1.Text = "Sucursal:"
        '
        'FrmCuentaCo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 406)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.BtnGrabar)
        Me.Controls.Add(Me.UgbMCliente)
        Me.Name = "FrmCuentaCo"
        Me.Text = "CuentaCo"
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.cbobanco, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtempresaid As TextBox
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cbobanco As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
End Class
