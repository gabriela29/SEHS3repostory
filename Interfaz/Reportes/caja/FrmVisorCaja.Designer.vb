<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisorCaja
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
        Me.cvCaja = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cvCaja
        '
        Me.cvCaja.ActiveViewIndex = -1
        Me.cvCaja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cvCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cvCaja.Cursor = System.Windows.Forms.Cursors.Default
        Me.cvCaja.Location = New System.Drawing.Point(0, 0)
        Me.cvCaja.Name = "cvCaja"
        Me.cvCaja.SelectionFormula = ""
        Me.cvCaja.Size = New System.Drawing.Size(736, 505)
        Me.cvCaja.TabIndex = 0
        Me.cvCaja.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.cvCaja.ViewTimeSelectionFormula = ""
        '
        'FrmVisorCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 505)
        Me.Controls.Add(Me.cvCaja)
        Me.Name = "FrmVisorCaja"
        Me.Text = "Visualizador Reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cvCaja As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
