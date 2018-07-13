<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubCategoriaNM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSubCategoriaNM))
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
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cboCategoria = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txtAbrev = New System.Windows.Forms.TextBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.cboCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButton1)
        Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox1.Controls.Add(Me.UgbMCliente)
        Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
        Me.UltraGroupBox1.Controls.Add(Me.LblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(393, 233)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.Text = "Actualizanado Sub Categorias..."
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraButton1
        '
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.White
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance1.ForeColor = System.Drawing.Color.Navy
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.UltraButton1.Appearance = Appearance1
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.UltraButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.UltraButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraButton1.Location = New System.Drawing.Point(354, 0)
        Me.UltraButton1.Name = "UltraButton1"
        Appearance2.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraButton1.PressedAppearance = Appearance2
        Me.UltraButton1.Size = New System.Drawing.Size(29, 16)
        Me.UltraButton1.TabIndex = 45
        Me.UltraButton1.Text = "x"
        Me.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.btnCerrar.Location = New System.Drawing.Point(242, 198)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UgbMCliente.Appearance = Appearance4
        Me.UgbMCliente.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularInset
        Me.UgbMCliente.Controls.Add(Me.cboCategoria)
        Me.UgbMCliente.Controls.Add(Me.txtAbrev)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel6)
        Me.UgbMCliente.Controls.Add(Me.txtNombre)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(5, 55)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(376, 132)
        Me.UgbMCliente.TabIndex = 0
        '
        'cboCategoria
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Me.cboCategoria.DisplayLayout.Appearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.cboCategoria.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 10.0!
        Appearance7.ForeColor = System.Drawing.Color.White
        Appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboCategoria.DisplayLayout.Override.HeaderAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCategoria.DisplayLayout.Override.RowSelectorAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCategoria.DisplayLayout.Override.SelectedRowAppearance = Appearance9
        Me.cboCategoria.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboCategoria.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboCategoria.Location = New System.Drawing.Point(99, 16)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(252, 26)
        Me.cboCategoria.TabIndex = 1
        '
        'txtAbrev
        '
        Me.txtAbrev.Location = New System.Drawing.Point(99, 88)
        Me.txtAbrev.MaxLength = 10
        Me.txtAbrev.Name = "txtAbrev"
        Me.txtAbrev.Size = New System.Drawing.Size(134, 23)
        Me.txtAbrev.TabIndex = 4
        '
        'UltraLabel6
        '
        Appearance10.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel6.Appearance = Appearance10
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(7, 89)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel6.TabIndex = 53
        Me.UltraLabel6.Text = "Abreviatura:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(99, 57)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(252, 23)
        Me.txtNombre.TabIndex = 3
        '
        'UltraLabel5
        '
        Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance11.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance11
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 58)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Nombre:"
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
        Me.UltraLabel8.Text = "Categoria:"
        '
        'BtnGrabar
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance13
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(112, 198)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'LblCodigo
        '
        Appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance14.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance14
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblCodigo.Location = New System.Drawing.Point(104, 29)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LblCodigo.TabIndex = 0
        '
        'UltraLabel4
        '
        Appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance15.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance15
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(12, 29)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel4.TabIndex = 31
        Me.UltraLabel4.Text = "Código"
        Me.UltraLabel4.Visible = False
        '
        'FrmSubCategoriaNM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(391, 233)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSubCategoriaNM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.cboCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cboCategoria As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtAbrev As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
End Class
