<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisor_PorCobrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisor_PorCobrar))
        Me.cvCompras = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cvCompras
        '
        Me.cvCompras.ActiveViewIndex = -1
        Me.cvCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cvCompras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cvCompras.Cursor = System.Windows.Forms.Cursors.Default
        Me.cvCompras.Location = New System.Drawing.Point(0, 0)
        Me.cvCompras.Name = "cvCompras"
        Me.cvCompras.SelectionFormula = ""
        Me.cvCompras.Size = New System.Drawing.Size(657, 467)
        Me.cvCompras.TabIndex = 2
        Me.cvCompras.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.cvCompras.ViewTimeSelectionFormula = ""
        '
        'FrmVisor_PorCobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(657, 467)
        Me.Controls.Add(Me.cvCompras)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVisor_PorCobrar"
        Me.Text = "Reporte por Cobrar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cvCompras As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
