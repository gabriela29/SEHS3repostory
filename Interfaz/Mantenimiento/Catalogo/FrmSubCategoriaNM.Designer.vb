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
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSubCategoriaNM))
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.UltraButton1.Location = New System.Drawing.Point(354, 0)
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
        Me.btnCerrar.Location = New System.Drawing.Point(242, 198)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UgbMCliente.Appearance = Appearance21
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
        Me.cboCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance91.BackColor = System.Drawing.Color.White
        Me.cboCategoria.DisplayLayout.Appearance = Appearance91
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.cboCategoria.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BackColor = System.Drawing.Color.White
        Appearance93.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.Name = "Arial"
        Appearance93.FontData.SizeInPoints = 10.0!
        Appearance93.ForeColor = System.Drawing.Color.White
        Appearance93.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboCategoria.DisplayLayout.Override.HeaderAppearance = Appearance93
        Appearance94.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance94.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCategoria.DisplayLayout.Override.RowSelectorAppearance = Appearance94
        Appearance95.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance95.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance95.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboCategoria.DisplayLayout.Override.SelectedRowAppearance = Appearance95
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
        Appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance28.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel6.Appearance = Appearance28
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
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance3
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 58)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Nombre:"
        '
        'UltraLabel8
        '
        Appearance31.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance31.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance31
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 18)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Categoria:"
        '
        'BtnGrabar
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance1
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
        Appearance32.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance32.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance32.TextHAlignAsString = "Right"
        Appearance32.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance32
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblCodigo.Location = New System.Drawing.Point(104, 29)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LblCodigo.TabIndex = 0
        '
        'UltraLabel4
        '
        Appearance33.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance33.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance33
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
