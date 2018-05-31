<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisor_Consignacion
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisor_Consignacion))
    Me.cv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.SuspendLayout()
    '
    'cv
    '
    Me.cv.ActiveViewIndex = -1
    Me.cv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.cv.Cursor = System.Windows.Forms.Cursors.Default
    Me.cv.Location = New System.Drawing.Point(0, 0)
    Me.cv.Name = "cv"
    Me.cv.SelectionFormula = ""
    Me.cv.Size = New System.Drawing.Size(551, 437)
    Me.cv.TabIndex = 1
    Me.cv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    Me.cv.ViewTimeSelectionFormula = ""
    '
    'FrmVisor_Consignacion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(551, 437)
    Me.Controls.Add(Me.cv)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FrmVisor_Consignacion"
    Me.Text = "Reporte"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents cv As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
