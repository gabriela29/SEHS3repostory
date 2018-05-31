<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisor_Listado
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
        Me.cvProductos = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cvProductos
        '
        Me.cvProductos.ActiveViewIndex = -1
        Me.cvProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cvProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.cvProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cvProductos.Location = New System.Drawing.Point(0, 0)
        Me.cvProductos.Name = "cvProductos"
        Me.cvProductos.SelectionFormula = ""
        Me.cvProductos.Size = New System.Drawing.Size(628, 505)
        Me.cvProductos.TabIndex = 0
        Me.cvProductos.ViewTimeSelectionFormula = ""
        '
        'FrmVisor_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 505)
        Me.Controls.Add(Me.cvProductos)
        Me.Name = "FrmVisor_Listado"
        Me.Text = "Visualizador Reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cvProductos As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
