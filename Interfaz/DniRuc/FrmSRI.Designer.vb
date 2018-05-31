<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSRI
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSRI))
    Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
    Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
    Me.SuspendLayout()
    '
    'WebBrowser2
    '
    Me.WebBrowser2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.WebBrowser2.Location = New System.Drawing.Point(6, 1)
    Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser2.Name = "WebBrowser2"
    Me.WebBrowser2.Size = New System.Drawing.Size(774, 616)
    Me.WebBrowser2.TabIndex = 2
    Me.WebBrowser2.Url = New System.Uri("", System.UriKind.Relative)
    '
    'RichTextBox3
    '
    Me.RichTextBox3.Location = New System.Drawing.Point(786, 1)
    Me.RichTextBox3.Name = "RichTextBox3"
    Me.RichTextBox3.Size = New System.Drawing.Size(336, 385)
    Me.RichTextBox3.TabIndex = 7
    Me.RichTextBox3.Text = ""
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(786, 392)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(93, 33)
    Me.Button4.TabIndex = 8
    Me.Button4.Text = "Button4"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'RichTextBox1
    '
    Me.RichTextBox1.Location = New System.Drawing.Point(786, 431)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.Size = New System.Drawing.Size(336, 187)
    Me.RichTextBox1.TabIndex = 9
    Me.RichTextBox1.Text = ""
    '
    'FrmSRI
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(1126, 621)
    Me.Controls.Add(Me.RichTextBox1)
    Me.Controls.Add(Me.Button4)
    Me.Controls.Add(Me.RichTextBox3)
    Me.Controls.Add(Me.WebBrowser2)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FrmSRI"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "S.R.I."
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents WebBrowser2 As WebBrowser
  Friend WithEvents RichTextBox3 As RichTextBox
  Friend WithEvents Button4 As Button
  Friend WithEvents RichTextBox1 As RichTextBox
End Class
