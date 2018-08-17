<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class importar
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
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(67, 85)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(600, 291)
        Me.DGV1.TabIndex = 1
        '
        'btnimportar
        '
        Me.btnimportar.Location = New System.Drawing.Point(244, 31)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(75, 48)
        Me.btnimportar.TabIndex = 2
        Me.btnimportar.Text = "importar"
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Location = New System.Drawing.Point(457, 31)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(75, 48)
        Me.btnexportar.TabIndex = 4
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'importar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.btnimportar)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "importar"
        Me.Text = "importar"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV1 As DataGridView
    Friend WithEvents btnimportar As Button
    Friend WithEvents btnexportar As Button
End Class
