<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos_CampaniaNM
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
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos_CampaniaNM))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UgbMCliente = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblError = New Infragistics.Win.Misc.UltraLabel()
        Me.chkAfecto_IGV = New System.Windows.Forms.CheckBox()
        Me.BtnGrabar = New Infragistics.Win.Misc.UltraButton()
        Me.ChkAfecto_Dzmo = New System.Windows.Forms.CheckBox()
        Me.txtProducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPrecioS = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAbreviatura = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UgbMCliente.SuspendLayout()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbreviatura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UgbMCliente
        '
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.UgbMCliente.Appearance = Appearance21
        Appearance2.AlphaLevel = CType(30, Short)
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Me.UgbMCliente.ContentAreaAppearance = Appearance2
        Me.UgbMCliente.Controls.Add(Me.txtAbreviatura)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel3)
        Me.UgbMCliente.Controls.Add(Me.lblError)
        Me.UgbMCliente.Controls.Add(Me.chkAfecto_IGV)
        Me.UgbMCliente.Controls.Add(Me.BtnGrabar)
        Me.UgbMCliente.Controls.Add(Me.ChkAfecto_Dzmo)
        Me.UgbMCliente.Controls.Add(Me.txtProducto)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel2)
        Me.UgbMCliente.Controls.Add(Me.txtPrecioS)
        Me.UgbMCliente.Controls.Add(Me.UltraLabel1)
        Me.UgbMCliente.Location = New System.Drawing.Point(1, 2)
        Me.UgbMCliente.Name = "UgbMCliente"
        Me.UgbMCliente.Size = New System.Drawing.Size(582, 210)
        Me.UgbMCliente.TabIndex = 1
        Me.UgbMCliente.Text = "Producto a Colportaje"
        Me.UgbMCliente.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblError
        '
        Appearance19.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance19.ForeColor = System.Drawing.Color.Navy
        Appearance19.TextVAlignAsString = "Middle"
        Me.lblError.Appearance = Appearance19
        Me.lblError.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblError.Location = New System.Drawing.Point(117, 19)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(446, 17)
        Me.lblError.TabIndex = 70
        '
        'chkAfecto_IGV
        '
        Me.chkAfecto_IGV.BackColor = System.Drawing.Color.Transparent
        Me.chkAfecto_IGV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAfecto_IGV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAfecto_IGV.ForeColor = System.Drawing.Color.Navy
        Me.chkAfecto_IGV.Location = New System.Drawing.Point(11, 181)
        Me.chkAfecto_IGV.Name = "chkAfecto_IGV"
        Me.chkAfecto_IGV.Size = New System.Drawing.Size(105, 23)
        Me.chkAfecto_IGV.TabIndex = 86
        Me.chkAfecto_IGV.Text = "Afecto IGV"
        Me.chkAfecto_IGV.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.BtnGrabar.Appearance = Appearance1
        Me.BtnGrabar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnGrabar.Location = New System.Drawing.Point(342, 143)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(107, 61)
        Me.BtnGrabar.TabIndex = 68
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'ChkAfecto_Dzmo
        '
        Me.ChkAfecto_Dzmo.BackColor = System.Drawing.Color.LemonChiffon
        Me.ChkAfecto_Dzmo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAfecto_Dzmo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAfecto_Dzmo.ForeColor = System.Drawing.Color.Navy
        Me.ChkAfecto_Dzmo.Location = New System.Drawing.Point(6, 133)
        Me.ChkAfecto_Dzmo.Name = "ChkAfecto_Dzmo"
        Me.ChkAfecto_Dzmo.Size = New System.Drawing.Size(110, 23)
        Me.ChkAfecto_Dzmo.TabIndex = 85
        Me.ChkAfecto_Dzmo.Text = "Afecto Dzmo"
        Me.ChkAfecto_Dzmo.UseVisualStyleBackColor = False
        '
        'txtProducto
        '
        Me.txtProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtProducto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(102, 41)
        Me.txtProducto.MaxLength = 150
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(474, 22)
        Me.txtProducto.TabIndex = 0
        '
        'UltraLabel2
        '
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance3.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel2.Location = New System.Drawing.Point(9, 87)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(76, 17)
        Me.UltraLabel2.TabIndex = 83
        Me.UltraLabel2.Text = "Precio S/.:"
        '
        'txtPrecioS
        '
        Appearance12.TextHAlignAsString = "Right"
        Me.txtPrecioS.Appearance = Appearance12
        Me.txtPrecioS.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPrecioS.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioS.Location = New System.Drawing.Point(102, 84)
        Me.txtPrecioS.MaxLength = 11
        Me.txtPrecioS.Name = "txtPrecioS"
        Me.txtPrecioS.Size = New System.Drawing.Size(100, 22)
        Me.txtPrecioS.TabIndex = 1
        Me.txtPrecioS.Text = "0.00"
        '
        'UltraLabel1
        '
        Appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 46)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(76, 17)
        Me.UltraLabel1.TabIndex = 84
        Me.UltraLabel1.Text = "Producto:"
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAbreviatura.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbreviatura.Location = New System.Drawing.Point(365, 84)
        Me.txtAbreviatura.MaxLength = 10
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(211, 22)
        Me.txtAbreviatura.TabIndex = 87
        '
        'UltraLabel3
        '
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance13.ForeColor = System.Drawing.Color.Navy
        Me.UltraLabel3.Appearance = Appearance13
        Me.UltraLabel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel3.Location = New System.Drawing.Point(275, 87)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(95, 17)
        Me.UltraLabel3.TabIndex = 88
        Me.UltraLabel3.Text = "Abreviatura:"
        '
        'FrmProductos_CampaniaNM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 215)
        Me.Controls.Add(Me.UgbMCliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductos_CampaniaNM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Campania"
        CType(Me.UgbMCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UgbMCliente.ResumeLayout(False)
        Me.UgbMCliente.PerformLayout()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbreviatura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UgbMCliente As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtProducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPrecioS As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkAfecto_IGV As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAfecto_Dzmo As System.Windows.Forms.CheckBox
    Friend WithEvents lblError As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGrabar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAbreviatura As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
