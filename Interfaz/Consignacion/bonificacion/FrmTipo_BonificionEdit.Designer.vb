﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipo_BonificionEdit
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipo_BonificionEdit))
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Lblerror = New System.Windows.Forms.Label
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboHasta = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.txtAlmacen = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.ChkEstado = New System.Windows.Forms.CheckBox
        Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.Lblerror)
        Me.UltraGroupBox1.Controls.Add(Me.LblCodigo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraButton1)
        Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox1.Controls.Add(Me.UgbMCliente)
        Me.UltraGroupBox1.Controls.Add(Me.BtnGrabar)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-1, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(395, 275)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "Actualizanado Tipo Bonificación"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'Lblerror
        '
        Me.Lblerror.BackColor = System.Drawing.Color.Transparent
        Me.Lblerror.ForeColor = System.Drawing.Color.White
        Me.Lblerror.Location = New System.Drawing.Point(100, 232)
        Me.Lblerror.Name = "Lblerror"
        Me.Lblerror.Size = New System.Drawing.Size(150, 33)
        Me.Lblerror.TabIndex = 110
        '
        'LblCodigo
        '
        Appearance32.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance32.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance32.TextHAlignAsString = "Right"
        Appearance32.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance32
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblCodigo.Location = New System.Drawing.Point(103, 19)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LblCodigo.TabIndex = 46
        '
        'UltraLabel4
        '
        Appearance33.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance33.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel4.Appearance = Appearance33
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
        Me.UltraButton1.Location = New System.Drawing.Point(362, 0)
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
        Me.btnCerrar.Location = New System.Drawing.Point(13, 237)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        Me.btnCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UgbMCliente
        '
        Me.UgbMCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance21
        Appearance2.AlphaLevel = CType(30, Short)
        Appearance2.BackColor = System.Drawing.Color.RoyalBlue
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance2
        Me.UgbMCliente.Controls.Add(Me.cboHasta)
        Me.UgbMCliente.Controls.Add(Me.cboDesde)
        Me.UgbMCliente.Controls.Add(Me.txtAlmacen)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel2)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel1)
        Me.UgbMCliente.Controls.Add(Me.ChkEstado)
        Me.UgbMCliente.Controls.Add(Me.txtNombre)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel5)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel8)
        Me.UgbMCliente.Location = New System.Drawing.Point(2, 43)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(390, 185)
        Me.UgbMCliente.TabIndex = 0
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cboHasta
        '
        Appearance9.FontData.BoldAsString = "True"
        Appearance9.FontData.Name = "Tahoma"
        Appearance9.FontData.SizeInPoints = 10.0!
        Me.cboHasta.Appearance = Appearance9
        Me.cboHasta.BackColor = System.Drawing.SystemColors.Window
        Me.cboHasta.DateButtons.Add(DateButton1)
        Me.cboHasta.Location = New System.Drawing.Point(80, 118)
        Me.cboHasta.Name = "cboHasta"
        Me.cboHasta.NonAutoSizeHeight = 21
        Me.cboHasta.Size = New System.Drawing.Size(116, 22)
        Me.cboHasta.TabIndex = 3
        Me.cboHasta.Value = "20/09/2009"
        '
        'cboDesde
        '
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Tahoma"
        Appearance6.FontData.SizeInPoints = 10.0!
        Me.cboDesde.Appearance = Appearance6
        Me.cboDesde.BackColor = System.Drawing.SystemColors.Window
        Me.cboDesde.DateButtons.Add(DateButton2)
        Me.cboDesde.Location = New System.Drawing.Point(80, 81)
        Me.cboDesde.Name = "cboDesde"
        Me.cboDesde.NonAutoSizeHeight = 21
        Me.cboDesde.Size = New System.Drawing.Size(116, 22)
        Me.cboDesde.TabIndex = 2
        Me.cboDesde.Value = "20/09/2009"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAlmacen.Location = New System.Drawing.Point(80, 16)
        Me.txtAlmacen.MaxLength = 50
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(257, 21)
        Me.txtAlmacen.TabIndex = 0
        '
        'UltraLabel2
        '
        Appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance7
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(10, 121)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel2.TabIndex = 53
        Me.UltraLabel2.Text = "Desde:"
        '
        'UltraLabel1
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 17)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel1.TabIndex = 52
        Me.UltraLabel1.Text = "Almacén:"
        '
        'ChkEstado
        '
        Me.ChkEstado.BackColor = System.Drawing.Color.Transparent
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEstado.ForeColor = System.Drawing.Color.Navy
        Me.ChkEstado.Location = New System.Drawing.Point(6, 156)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(80, 23)
        Me.ChkEstado.TabIndex = 4
        Me.ChkEstado.Text = "Estado"
        Me.ChkEstado.UseVisualStyleBackColor = False
        '
        'txtNombre
        '
        Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNombre.Location = New System.Drawing.Point(80, 48)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(257, 21)
        Me.txtNombre.TabIndex = 1
        '
        'UltraLabel5
        '
        Appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(10, 84)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel5.TabIndex = 51
        Me.UltraLabel5.Text = "Desde:"
        '
        'UltraLabel8
        '
        Appearance31.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance31.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel8.Appearance = Appearance31
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(10, 49)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(86, 20)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Nombre: "
        '
        'BtnGrabar
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance1
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(256, 234)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(83, 27)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmTipo_BonificionEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(392, 274)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTipo_BonificionEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Lblerror As System.Windows.Forms.Label
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ChkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAlmacen As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboHasta As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
