<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisor_PedidoWeb
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisor_PedidoWeb))
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
    Me.cv.TabIndex = 2
    Me.cv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    Me.cv.ViewTimeSelectionFormula = ""
    '
    'frmVisor_PedidoWeb
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(554, 440)
    Me.Controls.Add(Me.cv)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmVisor_PedidoWeb"
    Me.Text = "Visor Pedido Web"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents cv As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
