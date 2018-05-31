<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisorGerencialCrystal
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisorGerencialCrystal))
    Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
    Me.SuspendLayout()
    '
    'crv1
    '
    Me.crv1.ActiveViewIndex = -1
    Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
    Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.crv1.Location = New System.Drawing.Point(0, 0)
    Me.crv1.Name = "crv1"
    Me.crv1.SelectionFormula = ""
    Me.crv1.Size = New System.Drawing.Size(780, 556)
    Me.crv1.TabIndex = 3
    Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
    Me.crv1.ViewTimeSelectionFormula = ""
    '
    'FrmVisorGerencialCrystal
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(780, 556)
    Me.Controls.Add(Me.crv1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FrmVisorGerencialCrystal"
    Me.Text = "Visor"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
