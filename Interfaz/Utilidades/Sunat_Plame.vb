Imports System.IO
Imports System
Imports System.Globalization
Imports CapaLogicaNegocio.Bll

Public Class Sunat_Plame
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

    Public Shared Function Data_RH(ByVal vAlmacen As Integer, ByVal vMes As Integer, ByVal vAnio As Integer) As DataTable
        Dim xDtRh As New DataTable
        Try
            xDtRh = ReportesManager.Registro_RH(vAlmacen, vMes, vAnio, 0, "", True)
            Return xDtRh
        Catch ex As Exception
            Return xDtRh
        End Try
    End Function

    Public Shared Function Archivo_4ta(ByVal vAlmacen As Integer, ByVal vMes As Integer, ByVal vAnio As Integer, _
                                       ByVal vfd As FolderBrowserDialog, ByVal vExtexcion As String) As Boolean
        Dim xOk As Boolean = False, vRuta As String = "", vFile As String = "", vRutaFile As String = ""
        Dim xDTtemp As New DataTable
        xDTtemp = Data_RH(vAlmacen, vMes, vAnio)

        If Not xDTtemp Is Nothing Then
            If Not xDTtemp.Rows.Count > 0 Then
                Return xOk = False
                Exit Function
            End If
        Else
            Return xOk = False
            Exit Function
        End If

        Try

            vRuta = RutaFile(vfd)
            If vRuta = "" Then
                Return xOk = False
                Exit Function
            End If

            vFile = "0601" & vAnio & vMes.ToString("00") & GestionSeguridadManager.gRUCEmp & vExtexcion

            vRutaFile = vRuta & "\" & vFile
            Dim DtRw As DataRow
            Dim DELIMITADOR As String = "|"
            Dim ARCHIVO_CSV As String = ""
            Dim vFecha As String = ""
            ARCHIVO_CSV = vRutaFile

            Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)
                If vExtexcion = ".ps4" Then
                    'variable para almacenar la línea actual del dataview
                    Dim linea As String = String.Empty

                    For Each DtRw In xDTtemp.Rows
                        ' vaciar la línea
                        linea = String.Empty
                        linea = linea & Long.Parse(DtRw("tipo_doc")).ToString("00") & DELIMITADOR
                        linea = linea & DtRw("documento").ToString & DELIMITADOR
                        linea = linea & DtRw("ape_pat").ToString & DELIMITADOR
                        linea = linea & DtRw("ape_mat").ToString & DELIMITADOR
                        linea = linea & DtRw("nombre").ToString & DELIMITADOR

                        linea = linea & "1" & DELIMITADOR
                        linea = linea & "0" & DELIMITADOR
                        archivo.WriteLine(linea.ToString)

                    Next DtRw
                ElseIf vExtexcion = ".4ta" Then
                    'variable para almacenar la línea actual del dataview
                    Dim linea As String = String.Empty

                    For Each DtRw In xDTtemp.Rows
                        ' vaciar la línea
                        linea = String.Empty
                        linea = linea & Long.Parse(DtRw("tipo_doc")).ToString("00") & DELIMITADOR
                        linea = linea & DtRw("documento").ToString & DELIMITADOR
                        linea = linea & "R" & DELIMITADOR
                        linea = linea & DtRw("serie_doc").ToString & DELIMITADOR
                        linea = linea & DtRw("numero_doc").ToString & DELIMITADOR
                        linea = linea & Single.Parse(DtRw("importe")).ToString("0.00", CultureInfo.InvariantCulture) & DELIMITADOR

                        vFecha = LibreriasFormularios.Formato_Fechaddmmyyyy(DtRw("fecha").ToString)

                        linea = linea & vFecha & DELIMITADOR
                        linea = linea & vFecha & DELIMITADOR
                        linea = linea & IIf(Single.Parse(DtRw("retencion").ToString) > 0, "1", "0") & DELIMITADOR
                        linea = linea & DELIMITADOR
                        linea = linea & DELIMITADOR
                        archivo.WriteLine(linea.ToString)

                    Next DtRw
                End If
            End Using
            xOk = True
            Return xOk
            'Process.Start(ARCHIVO_CSV)
        Catch ex As Exception
            Return xOk
            MessageBox.Show(ex.Message, "VERIFICAR")
        End Try

    End Function


    '========================================= INICIO PLE R.V. & R.C===================================================
    Public Shared Function Exportar_RV_txt(ByVal vfd As FolderBrowserDialog, ByVal Dtp As DataTable, ByVal pMes As Integer, _
                                            ByVal pAnio As Integer, ByVal vFileName As String, ByRef rRutaFile As String) As Boolean


        Dim DtRw As DataRow, xOk As Boolean = False

        ' ruta del fichero de texto
        Dim vRuta As String = "", vRutaFile As String = ""
        vRuta = RutaFile(vfd)
        If vRuta = "" Then
            Return xOk = False
            Exit Function
        End If

        vRutaFile = vRuta & "\" & vFileName
        rRutaFile = vRutaFile
        Try

            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(vRutaFile)

                'variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty

                For Each DtRw In Dtp.Rows
                    ' vaciar la línea
                    linea = String.Empty

                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    linea = linea & DtRw("detalle").ToString

                    ' Escribir una línea con el método WriteLine
                    With archivo

                        .WriteLine(linea.ToString)
                    End With

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


    Public Shared Function Exportar_RC_txt(ByVal vfd As FolderBrowserDialog, ByVal Dtp As DataTable, ByVal pMes As Integer, _
                                            ByVal pAnio As Integer, ByVal vFileName As String, ByRef rRutaFile As String) As Boolean


        Dim DtRw As DataRow, xOk As Boolean = False

        ' ruta del fichero de texto
        Dim vRuta As String = "", vRutaFile As String = ""
        vRuta = RutaFile(vfd)
        If vRuta = "" Then
            Return xOk = False
            Exit Function
        End If

        vRutaFile = vRuta & "\" & vFileName
        rRutaFile = vRutaFile
        Try

            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(vRutaFile)

                'variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty

                For Each DtRw In Dtp.Rows
                    ' vaciar la línea
                    linea = String.Empty
                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    linea = linea & DtRw("detalle").ToString
                    ' Escribir una línea con el método WriteLine
                    With archivo

                        .WriteLine(linea.ToString)
                    End With
                Next DtRw

            End Using
            xOk = True
            ' Abrir con Process.Start el archivo de texto

            'MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
            'error
            Return xOk
        Catch ex As Exception
            Return xOk = False
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Function

    '========================================= FIN PLE R.V. & R.C===================================================

End Class

