﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActualizar_Item_Boleteo
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActualizar_Item_Boleteo))
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.txtCantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton
        Me.lblProducto = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblAfectoDzmo = New Infragistics.Win.Misc.UltraLabel
        Me.lblAfecto = New Infragistics.Win.Misc.UltraLabel
        Me.ugStock = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblMsgSstock = New Infragistics.Win.Misc.UltraLabel
        Me.lblStock = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txtPrecio = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtDscto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.ugStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugStock.SuspendLayout()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDscto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCantidad
        '
        Appearance19.ForeColor = System.Drawing.Color.SteelBlue
        Appearance19.TextHAlignAsString = "Right"
        Me.txtCantidad.Appearance = Appearance19
        Me.txtCantidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(327, 91)
        Me.txtCantidad.MaxLength = 7
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(153, 31)
        Me.txtCantidad.TabIndex = 0
        Me.txtCantidad.Text = "0"
        '
        'UltraLabel8
        '
        Appearance17.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance17.ForeColor = System.Drawing.Color.Navy
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance17
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(194, 91)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(127, 26)
        Me.UltraLabel8.TabIndex = 41
        Me.UltraLabel8.Text = "Cantidad:"
        '
        'BtnGrabar
        '
        Appearance1.ForeColor = System.Drawing.Color.Orange
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance1
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnGrabar.Location = New System.Drawing.Point(327, 212)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(153, 41)
        Me.BtnGrabar.TabIndex = 3
        Me.BtnGrabar.Text = "&Actualizar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblProducto
        '
        Appearance34.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance34.ForeColor = System.Drawing.Color.MediumBlue
        Appearance34.TextVAlignAsString = "Top"
        Me.lblProducto.Appearance = Appearance34
        Me.lblProducto.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(64, 5)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(424, 44)
        Me.lblProducto.TabIndex = 31
        Me.lblProducto.Text = "..."
        '
        'UltraGroupBox4
        '
        Appearance3.AlphaLevel = CType(95, Short)
        Appearance3.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance3
        Me.UltraGroupBox4.Controls.Add(Me.lblAfectoDzmo)
        Me.UltraGroupBox4.Controls.Add(Me.lblAfecto)
        Me.UltraGroupBox4.Controls.Add(Me.lblProducto)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(-2, -1)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(492, 82)
        Me.UltraGroupBox4.TabIndex = 46
        '
        'lblAfectoDzmo
        '
        Appearance31.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance31.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblAfectoDzmo.Appearance = Appearance31
        Me.lblAfectoDzmo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAfectoDzmo.Location = New System.Drawing.Point(329, 58)
        Me.lblAfectoDzmo.Name = "lblAfectoDzmo"
        Me.lblAfectoDzmo.Size = New System.Drawing.Size(153, 16)
        Me.lblAfectoDzmo.TabIndex = 43
        Me.lblAfectoDzmo.Text = "..."
        '
        'lblAfecto
        '
        Appearance16.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance16.ForeColor = System.Drawing.Color.Red
        Me.lblAfecto.Appearance = Appearance16
        Me.lblAfecto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAfecto.Location = New System.Drawing.Point(84, 58)
        Me.lblAfecto.Name = "lblAfecto"
        Me.lblAfecto.Size = New System.Drawing.Size(129, 16)
        Me.lblAfecto.TabIndex = 42
        Me.lblAfecto.Text = "..."
        '
        'ugStock
        '
        Me.ugStock.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Appearance12.BackColor = System.Drawing.Color.White
        Appearance12.BackColor2 = System.Drawing.Color.White
        Me.ugStock.ContentAreaAppearance = Appearance12
        Me.ugStock.Controls.Add(Me.lblMsgSstock)
        Me.ugStock.Controls.Add(Me.lblStock)
        Me.ugStock.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugStock.Location = New System.Drawing.Point(5, 82)
        Me.ugStock.Name = "ugStock"
        Me.ugStock.Size = New System.Drawing.Size(155, 126)
        Me.ugStock.TabIndex = 105
        Me.ugStock.Text = "STOCK ACTUAL"
        Me.ugStock.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblMsgSstock
        '
        Appearance68.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance68.BorderColor = System.Drawing.Color.LightSteelBlue
        Appearance68.TextHAlignAsString = "Center"
        Appearance68.TextVAlignAsString = "Middle"
        Me.lblMsgSstock.Appearance = Appearance68
        Me.lblMsgSstock.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lblMsgSstock.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblMsgSstock.Location = New System.Drawing.Point(2, 69)
        Me.lblMsgSstock.Name = "lblMsgSstock"
        Me.lblMsgSstock.Size = New System.Drawing.Size(151, 55)
        Me.lblMsgSstock.TabIndex = 105
        Me.lblMsgSstock.Text = "El sistema requiere stock para vender"
        '
        'lblStock
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Red
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblStock.Appearance = Appearance8
        Me.lblStock.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold)
        Me.lblStock.Location = New System.Drawing.Point(4, 28)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(147, 39)
        Me.lblStock.TabIndex = 104
        Me.lblStock.Text = "0"
        '
        'UltraLabel6
        '
        Appearance18.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance18.ForeColor = System.Drawing.Color.Navy
        Appearance18.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance18
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(194, 133)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(127, 26)
        Me.UltraLabel6.TabIndex = 106
        Me.UltraLabel6.Text = "Precio:"
        '
        'UltraLabel7
        '
        Appearance15.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance15.ForeColor = System.Drawing.Color.Navy
        Appearance15.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance15
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(194, 176)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(127, 26)
        Me.UltraLabel7.TabIndex = 107
        Me.UltraLabel7.Text = "DSCTO:"
        Me.UltraLabel7.Visible = False
        '
        'txtPrecio
        '
        Appearance20.ForeColor = System.Drawing.Color.SteelBlue
        Appearance20.TextHAlignAsString = "Right"
        Me.txtPrecio.Appearance = Appearance20
        Me.txtPrecio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPrecio.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(327, 130)
        Me.txtPrecio.MaxLength = 7
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(153, 31)
        Me.txtPrecio.TabIndex = 1
        Me.txtPrecio.Text = "0.00"
        '
        'txtDscto
        '
        Appearance7.ForeColor = System.Drawing.Color.SteelBlue
        Appearance7.TextHAlignAsString = "Right"
        Me.txtDscto.Appearance = Appearance7
        Me.txtDscto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDscto.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDscto.Location = New System.Drawing.Point(327, 172)
        Me.txtDscto.MaxLength = 7
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.Size = New System.Drawing.Size(153, 31)
        Me.txtDscto.TabIndex = 2
        Me.txtDscto.Text = "0.00"
        Me.txtDscto.Visible = False
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(62, 64)
        Me.UltraPictureBox1.TabIndex = 6
        '
        'FrmActualizar_Item_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(489, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtDscto)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.UltraLabel6)
        Me.Controls.Add(Me.ugStock)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.BtnGrabar)
        Me.Controls.Add(Me.UltraLabel8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmActualizar_Item_Venta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingrese cantidad y precio..."
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.ugStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugStock.ResumeLayout(False)
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDscto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents lblProducto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugStock As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblMsgSstock As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblStock As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAfectoDzmo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAfecto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPrecio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDscto As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
