<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcesar_Info
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcesar_Info))
    Me.picAjax = New System.Windows.Forms.PictureBox()
    Me.pb2 = New System.Windows.Forms.ProgressBar()
    Me.lblData = New System.Windows.Forms.Label()
    Me.lblInformacion = New System.Windows.Forms.Label()
    Me.pb = New System.Windows.Forms.ProgressBar()
    Me.bwPLE = New System.ComponentModel.BackgroundWorker()
    Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
    CType(Me.picAjax, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'picAjax
    '
    Me.picAjax.BackColor = System.Drawing.Color.Transparent
    Me.picAjax.Image = CType(resources.GetObject("picAjax.Image"), System.Drawing.Image)
    Me.picAjax.Location = New System.Drawing.Point(1, 42)
    Me.picAjax.Name = "picAjax"
    Me.picAjax.Size = New System.Drawing.Size(367, 78)
    Me.picAjax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjax.TabIndex = 89
    Me.picAjax.TabStop = False
    Me.picAjax.Visible = False
    '
    'pb2
    '
    Me.pb2.Location = New System.Drawing.Point(1, 100)
    Me.pb2.Name = "pb2"
    Me.pb2.Size = New System.Drawing.Size(367, 20)
    Me.pb2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pb2.TabIndex = 90
    '
    'lblData
    '
    Me.lblData.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblData.ForeColor = System.Drawing.Color.Blue
    Me.lblData.Location = New System.Drawing.Point(5, 72)
    Me.lblData.Name = "lblData"
    Me.lblData.Size = New System.Drawing.Size(360, 19)
    Me.lblData.TabIndex = 88
    Me.lblData.Text = "..."
    Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblInformacion
    '
    Me.lblInformacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblInformacion.ForeColor = System.Drawing.Color.Navy
    Me.lblInformacion.Location = New System.Drawing.Point(1, 9)
    Me.lblInformacion.Name = "lblInformacion"
    Me.lblInformacion.Size = New System.Drawing.Size(364, 22)
    Me.lblInformacion.TabIndex = 87
    Me.lblInformacion.Text = "..."
    Me.lblInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'pb
    '
    Me.pb.Location = New System.Drawing.Point(4, 42)
    Me.pb.Name = "pb"
    Me.pb.Size = New System.Drawing.Size(363, 28)
    Me.pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pb.TabIndex = 86
    '
    'bwPLE
    '
    Me.bwPLE.WorkerReportsProgress = True
    '
    'FrmProcesar_Info
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(370, 123)
    Me.Controls.Add(Me.picAjax)
    Me.Controls.Add(Me.pb2)
    Me.Controls.Add(Me.lblData)
    Me.Controls.Add(Me.lblInformacion)
    Me.Controls.Add(Me.pb)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmProcesar_Info"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Procesando Información..."
    CType(Me.picAjax, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Private WithEvents picAjax As System.Windows.Forms.PictureBox
    Friend WithEvents pb2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents lblInformacion As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents bwPLE As System.ComponentModel.BackgroundWorker
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
