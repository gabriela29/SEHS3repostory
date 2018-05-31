<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisorVentas_Clientes
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rvVisor = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.EGerencialesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.EGerencialesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvVisor
        '
        Me.rvVisor.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dtsVentasClientes"
        ReportDataSource1.Value = Me.EGerencialesBindingSource
        Me.rvVisor.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvVisor.LocalReport.ReportEmbeddedResource = "Phoenix.rptVentas_Clientes.rdlc"
        Me.rvVisor.Location = New System.Drawing.Point(0, 0)
        Me.rvVisor.Name = "rvVisor"
        Me.rvVisor.Size = New System.Drawing.Size(529, 392)
        Me.rvVisor.TabIndex = 0
        '
        'EGerencialesBindingSource
        '
        Me.EGerencialesBindingSource.DataSource = GetType(Phoenix.EGerenciales)
        '
        'FrmVisorVentas_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(529, 392)
        Me.Controls.Add(Me.rvVisor)
        Me.Name = "FrmVisorVentas_Clientes"
        Me.Text = "Visor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EGerencialesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvVisor As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents EGerencialesBindingSource As System.Windows.Forms.BindingSource
End Class
