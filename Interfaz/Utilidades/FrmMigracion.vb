Imports System.ComponentModel
Imports System.IO
Imports CapaLogicaNegocio.Bll

Public Class FrmMigracion
  Public Shared Function RutaFile(vfd As FolderBrowserDialog) As String
    Dim vRutaFile As String = ""
    Try
      ' Configuración del FolderBrowserDialog  
      With vfd

        .Reset() ' resetea  

        ' leyenda  
        .Description = " Seleccionar una carpeta "
        ' Path " Escritorio o Mis documentos si kiere "  
        .SelectedPath = Environment.SpecialFolder.Desktop 'Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' deshabilita el botón " crear nueva carpeta "  
        .ShowNewFolderButton = False
        '.RootFolder = Environment.SpecialFolder.Desktop  
        '.RootFolder = Environment.SpecialFolder.StartMenu  

        Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

        ' si se presionó el botón aceptar ...  
        If ret = Windows.Forms.DialogResult.OK Then
          vRutaFile = .SelectedPath
        End If

        .Dispose()
        Return vRutaFile
      End With
    Catch oe As Exception
      Return ""
      MsgBox(oe.Message, MsgBoxStyle.Critical)
    End Try
  End Function

  Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
    bwData.RunWorkerAsync()
  End Sub

  Private Sub bwData_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwData.DoWork
    Dim DtData As New DataTable
    DtData = migracionManager.GetList("")

    e.Result = DtData

  End Sub

  Private Sub bwData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwData.RunWorkerCompleted
    Dim dtTemp As New DataTable
    Dim vFileName As String = "Migracion.txt", vRutaFile As String = ""
    dtTemp = CType(e.Result, DataTable)

    If Not dtTemp Is Nothing Then
      If dtTemp.Rows.Count > 0 Then
        If Exportar_RV_txt(FolderBrowserDialog1, dtTemp, vFileName, vRutaFile) Then
          Process.Start(vRutaFile)
          Me.Close()
        End If
      Else
        MessageBox.Show("No hay Data que procesar", "AVISO")
      End If
    Else
      MessageBox.Show("No hay Data que procesar", "AVISO")
    End If

  End Sub


  Public Function Exportar_RV_txt(ByVal vfd As FolderBrowserDialog, ByVal Dtp As DataTable,
                                         ByVal vFileName As String, ByRef rRutaFile As String) As Boolean


    Dim DtRw As DataRow, xOk As Boolean = False, V As Long = 1

    ' ruta del fichero de texto
    Dim vRuta As String = "", vRutaFile As String = ""
    vRuta = RutaFile(vfd)
    If vRuta = "" Then
      Return xOk = False
      Exit Function
    End If

    vRutaFile = vRuta & "\" & vFileName
    rRutaFile = vRutaFile
    PB1.Minimum = 1
    PB1.Maximum = 1
    PB2.Minimum = 0
    PB2.Maximum = Dtp.Rows.Count

    Try

      'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
      Using archivo As StreamWriter = New StreamWriter(vRutaFile)

        'variable para almacenar la línea actual del dataview
        Dim linea As String = String.Empty

        For Each DtRw In Dtp.Rows
          ' vaciar la línea
          linea = String.Empty

          ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
          linea = linea & DtRw("contenido").ToString
          lblInformacion.Text = linea
          PB2.Value = V
          ' Escribir una línea con el método WriteLine
          With archivo

            .WriteLine(linea.ToString)
          End With
          V += 1
        Next DtRw

      End Using
      ' Abrir con Process.Start el archivo de texto            
      'MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
      'error
      xOk = True
      Return xOk
    Catch ex As Exception
      MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
      Return xOk
    End Try
  End Function

End Class