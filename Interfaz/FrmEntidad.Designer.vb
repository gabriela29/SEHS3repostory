<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntidad
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntidad))
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.btnCancelar = New Infragistics.Win.Misc.UltraButton()
    Me.cboUnidad = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.CmdAceptar = New Infragistics.Win.Misc.UltraButton()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox1.SuspendLayout()
    CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGroupBox1
    '
    Me.UltraGroupBox1.Controls.Add(Me.btnCancelar)
    Me.UltraGroupBox1.Controls.Add(Me.cboUnidad)
    Me.UltraGroupBox1.Controls.Add(Me.CmdAceptar)
    Me.UltraGroupBox1.Controls.Add(Me.UltraPictureBox1)
    Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
    Me.UltraGroupBox1.Location = New System.Drawing.Point(0, -1)
    Me.UltraGroupBox1.Name = "UltraGroupBox1"
    Me.UltraGroupBox1.Size = New System.Drawing.Size(339, 126)
    Me.UltraGroupBox1.TabIndex = 1
    Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
    '
    'btnCancelar
    '
    Me.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton
    Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancelar.Location = New System.Drawing.Point(84, 82)
    Me.btnCancelar.Name = "btnCancelar"
    Me.btnCancelar.Size = New System.Drawing.Size(63, 26)
    Me.btnCancelar.TabIndex = 87
    Me.btnCancelar.Text = "&Cancelar"
    Me.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    Me.btnCancelar.Visible = False
    '
    'cboUnidad
    '
    Me.cboUnidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
    Appearance1.BackColor = System.Drawing.Color.White
    Me.cboUnidad.DisplayLayout.Appearance = Appearance1
    Me.cboUnidad.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance2.BackColor = System.Drawing.Color.Transparent
    Me.cboUnidad.DisplayLayout.Override.CardAreaAppearance = Appearance2
    Appearance3.BackColor = System.Drawing.Color.White
    Appearance3.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance3.FontData.BoldAsString = "True"
    Appearance3.FontData.Name = "Arial"
    Appearance3.FontData.SizeInPoints = 10.0!
    Appearance3.ForeColor = System.Drawing.Color.White
    Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboUnidad.DisplayLayout.Override.HeaderAppearance = Appearance3
    Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboUnidad.DisplayLayout.Override.RowSelectorAppearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboUnidad.DisplayLayout.Override.SelectedRowAppearance = Appearance5
    Me.cboUnidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboUnidad.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboUnidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboUnidad.Location = New System.Drawing.Point(130, 42)
    Me.cboUnidad.Name = "cboUnidad"
    Me.cboUnidad.Size = New System.Drawing.Size(192, 23)
    Me.cboUnidad.TabIndex = 0
    '
    'CmdAceptar
    '
    Me.CmdAceptar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton
    Me.CmdAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.CmdAceptar.Location = New System.Drawing.Point(187, 82)
    Me.CmdAceptar.Name = "CmdAceptar"
    Me.CmdAceptar.Size = New System.Drawing.Size(63, 26)
    Me.CmdAceptar.TabIndex = 1
    Me.CmdAceptar.Text = "&Aceptar"
    Me.CmdAceptar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
    '
    'UltraPictureBox1
    '
    Appearance6.BackColor = System.Drawing.Color.LightBlue
    Appearance6.BackColor2 = System.Drawing.Color.White
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.UltraPictureBox1.Appearance = Appearance6
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.Location = New System.Drawing.Point(2, 2)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(122, 112)
    Me.UltraPictureBox1.TabIndex = 10
    '
    'UltraLabel1
    '
    Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance7.TextHAlignAsString = "Center"
    Me.UltraLabel1.Appearance = Appearance7
    Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel1.Location = New System.Drawing.Point(130, 13)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(192, 16)
    Me.UltraLabel1.TabIndex = 8
    Me.UltraLabel1.Text = "UNIDAD NEGOCIO"
    '
    'FrmEntidad
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(338, 124)
    Me.ControlBox = False
    Me.Controls.Add(Me.UltraGroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmEntidad"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox1.ResumeLayout(False)
    Me.UltraGroupBox1.PerformLayout()
    CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cboUnidad As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CmdAceptar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
