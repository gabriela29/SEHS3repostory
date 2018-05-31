<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlmacenEdit
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlmacenEdit))
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraCheckEditor1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ChkEstado = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cboUnidad = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.txtAbrev = New System.Windows.Forms.TextBox()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UltraGroupBox1.Controls.Add(Me.UgbMCliente)
        Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(467, 354)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.Text = "Actualizando Almacén"
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
        Me.UltraButton1.Location = New System.Drawing.Point(429, 0)
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
        Me.btnCerrar.Location = New System.Drawing.Point(57, 318)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance6
        Appearance7.AlphaLevel = CType(30, Short)
        Appearance7.BackColor = System.Drawing.Color.RoyalBlue
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance7
        Me.UgbMCliente.Controls.Add(Me.TextBox3)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel6)
        Me.UgbMCliente.Controls.Add(Me.UltraCheckEditor1)
        Me.UgbMCliente.Controls.Add(Me.ChkEstado)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel3)
        Me.UgbMCliente.Controls.Add(Me.TextBox2)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel2)
        Me.UgbMCliente.Controls.Add(Me.TextBox1)
        Me.UgbMCliente.Controls.Add(Me.cboUnidad)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel1)
        Me.UgbMCliente.Controls.Add(Me.TxtNombre)
        Me.UgbMCliente.Controls.Add(Me.txtAbrev)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(3, 45)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(457, 265)
        Me.UgbMCliente.TabIndex = 0
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(144, 230)
        Me.TextBox3.MaxLength = 10
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(95, 20)
        Me.TextBox3.TabIndex = 7
        '
        'UltraLabel6
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel6.Appearance = Appearance8
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(27, 231)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(111, 20)
        Me.UltraLabel6.TabIndex = 61
        Me.UltraLabel6.Text = "Centro Costo Ini.:"
        '
        'UltraCheckEditor1
        '
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.ItalicAsString = "False"
        Appearance9.FontData.Name = "Verdana"
        Appearance9.FontData.SizeInPoints = 9.0!
        Appearance9.ForeColor = System.Drawing.Color.Navy
        Me.UltraCheckEditor1.Appearance = Appearance9
        Me.UltraCheckEditor1.BackColor = System.Drawing.Color.Transparent
        Me.UltraCheckEditor1.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraCheckEditor1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.UltraCheckEditor1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UltraCheckEditor1.Location = New System.Drawing.Point(258, 191)
        Me.UltraCheckEditor1.Name = "UltraCheckEditor1"
        Me.UltraCheckEditor1.Size = New System.Drawing.Size(154, 20)
        Me.UltraCheckEditor1.TabIndex = 6
        Me.UltraCheckEditor1.Text = "Es Principal?"
        '
        'ChkEstado
        '
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.ItalicAsString = "False"
        Appearance10.FontData.Name = "Verdana"
        Appearance10.FontData.SizeInPoints = 9.0!
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.ChkEstado.Appearance = Appearance10
        Me.ChkEstado.BackColor = System.Drawing.Color.Transparent
        Me.ChkEstado.BackColorInternal = System.Drawing.Color.Transparent
        Me.ChkEstado.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Location = New System.Drawing.Point(27, 191)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(135, 20)
        Me.ChkEstado.TabIndex = 5
        Me.ChkEstado.Text = "Estado."
        '
        'UltraLabel3
        '
        Appearance11.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance11.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(27, 157)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel3.TabIndex = 57
        Me.UltraLabel3.Text = "Teléfono:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(144, 157)
        Me.TextBox2.MaxLength = 40
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(268, 20)
        Me.TextBox2.TabIndex = 4
        '
        'UltraLabel2
        '
        Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance12.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(27, 117)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel2.TabIndex = 55
        Me.UltraLabel2.Text = "Dirección:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(144, 117)
        Me.TextBox1.MaxLength = 40
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(268, 20)
        Me.TextBox1.TabIndex = 3
        '
        'cboUnidad
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Me.cboUnidad.DisplayLayout.Appearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.cboUnidad.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Appearance15.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.FontData.Name = "Arial"
        Appearance15.FontData.SizeInPoints = 10.0!
        Appearance15.ForeColor = System.Drawing.Color.White
        Appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboUnidad.DisplayLayout.Override.HeaderAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance16.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad.DisplayLayout.Override.RowSelectorAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.cboUnidad.DisplayLayout.Override.SelectedRowAppearance = Appearance17
        Me.cboUnidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboUnidad.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboUnidad.Location = New System.Drawing.Point(144, 13)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(268, 22)
        Me.cboUnidad.TabIndex = 0
        '
        'UltraLabel1
        '
        Appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance18.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance18
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(27, 15)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel1.TabIndex = 53
        Me.UltraLabel1.Text = "Unidad:"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(144, 52)
        Me.TxtNombre.MaxLength = 40
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(268, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'txtAbrev
        '
        Me.txtAbrev.Location = New System.Drawing.Point(144, 85)
        Me.txtAbrev.MaxLength = 10
        Me.txtAbrev.Name = "txtAbrev"
        Me.txtAbrev.Size = New System.Drawing.Size(95, 20)
        Me.txtAbrev.TabIndex = 2
        '
        'UltraLabel5
        '
        Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance19.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance19
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(27, 86)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Nombre Corto:"
        '
        'UltraLabel8
        '
        Appearance20.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance20.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance20
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(27, 52)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Nombre: "
        '
        'BtnGrabar
        '
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.Image = CType(resources.GetObject("Appearance21.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance21
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(331, 318)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'FrmAlmacenEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 359)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAlmacenEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.UltraCheckEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtAbrev As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboUnidad As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraCheckEditor1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ChkEstado As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
