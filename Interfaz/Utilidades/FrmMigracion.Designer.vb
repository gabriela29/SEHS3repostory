<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMigracion
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
    Me.BtnProcesar = New System.Windows.Forms.Button()
    Me.PB1 = New System.Windows.Forms.ProgressBar()
    Me.PB2 = New System.Windows.Forms.ProgressBar()
    Me.lblInformacion = New System.Windows.Forms.Label()
    Me.bwData = New System.ComponentModel.BackgroundWorker()
    Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
    Me.bwFile = New System.ComponentModel.BackgroundWorker()
    Me.SuspendLayout()
    '
    'BtnProcesar
    '
    Me.BtnProcesar.Location = New System.Drawing.Point(72, 112)
    Me.BtnProcesar.Name = "BtnProcesar"
    Me.BtnProcesar.Size = New System.Drawing.Size(242, 53)
    Me.BtnProcesar.TabIndex = 0
    Me.BtnProcesar.Text = "Procesar"
    Me.BtnProcesar.UseVisualStyleBackColor = True
    '
    'PB1
    '
    Me.PB1.Location = New System.Drawing.Point(12, 194)
    Me.PB1.Name = "PB1"
    Me.PB1.Size = New System.Drawing.Size(403, 23)
    Me.PB1.TabIndex = 1
    '
    'PB2
    '
    Me.PB2.Location = New System.Drawing.Point(12, 223)
    Me.PB2.Name = "PB2"
    Me.PB2.Size = New System.Drawing.Size(403, 23)
    Me.PB2.TabIndex = 2
    '
    'lblInformacion
    '
    Me.lblInformacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblInformacion.ForeColor = System.Drawing.Color.Navy
    Me.lblInformacion.Location = New System.Drawing.Point(12, 42)
    Me.lblInformacion.Name = "lblInformacion"
    Me.lblInformacion.Size = New System.Drawing.Size(411, 22)
    Me.lblInformacion.TabIndex = 88
    Me.lblInformacion.Text = "..."
    Me.lblInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'bwData
    '
    Me.bwData.WorkerReportsProgress = True
    '
    'bwFile
    '
    Me.bwFile.WorkerReportsProgress = True
    '
    'FrmMigracion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(427, 275)
    Me.Controls.Add(Me.lblInformacion)
    Me.Controls.Add(Me.PB2)
    Me.Controls.Add(Me.PB1)
    Me.Controls.Add(Me.BtnProcesar)
    Me.Name = "FrmMigracion"
    Me.Text = "Migración"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents BtnProcesar As Button
  Friend WithEvents PB1 As ProgressBar
  Friend WithEvents PB2 As ProgressBar
  Friend WithEvents lblInformacion As Label
  Friend WithEvents bwData As System.ComponentModel.BackgroundWorker
  Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
  Friend WithEvents bwFile As System.ComponentModel.BackgroundWorker
End Class
