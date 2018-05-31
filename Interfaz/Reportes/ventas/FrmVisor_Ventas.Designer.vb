<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisor_Ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisor_Ventas))
        Me.crvVisor = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvVisor
        '
        Me.crvVisor.ActiveViewIndex = -1
        Me.crvVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvVisor.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvVisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvVisor.Location = New System.Drawing.Point(0, 0)
        Me.crvVisor.Name = "crvVisor"
        Me.crvVisor.SelectionFormula = ""
        Me.crvVisor.Size = New System.Drawing.Size(614, 414)
        Me.crvVisor.TabIndex = 2
        Me.crvVisor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crvVisor.ViewTimeSelectionFormula = ""
        '
        'FrmVisor_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 414)
        Me.Controls.Add(Me.crvVisor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVisor_Ventas"
        Me.Text = "Visualizador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvVisor As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
