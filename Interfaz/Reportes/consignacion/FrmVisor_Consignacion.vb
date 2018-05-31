Imports System
Imports System.IO

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class FrmVisor_Consignacion

    Public Function RptDetalle_Guia(ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String) As Boolean
        Dim rpt As New rptDetalle_Consignacion

        rpt.SetDataSource(dt)

        rpt.SetParameterValue(0, vDetalle)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vEmpresa)

        cv.ReportSource = rpt
    End Function

    Public Function RptKardex_consignacion(ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String) As Boolean
        Dim rpt As New rptKardex_Consignacion

        rpt.SetDataSource(dt)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vDetalle)

        cv.ReportSource = rpt
    End Function

    Public Function RptStock(ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String, ByVal vCondicion As String) As Boolean
        Dim rpt As New rptConsignacion_Stock

        rpt.SetDataSource(dt)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vDetalle)
        rpt.SetParameterValue(3, vCondicion)
        cv.ReportSource = rpt

    End Function


    Public Function Imprimir_Guia(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer) As Boolean
        Dim rpt As New ReportDocument
        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable
        Dim NameRpt As String, vSerieTK As String = ""
        '=====================================
        Dim ObjPerm As New permisos_impresion

        Try

            ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, My.Computer.Name, vCodigo_Doc, 0)

            If Not ObjPerm Is Nothing Then
                NameRpt = ObjPerm.formato
                vSerieTK = ObjPerm.serie_TK
                If Existe_Archivo(NameRpt) Then
                    'If ventaManager.Datos_Impresion(vCodigo, rsCabecera, rsDetalle) Then
                    If cursoresManager.Datos_Imprimir_Guia(vCodigo, rsCabecera, rsDetalle) Then
                        If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
                            rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                            rsCabecera.TableName = "cabecera_guiaG_ttx"
                            rsDetalle.TableName = "detalle_guiaG_ttx"
                            rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                            rpt.Database.Tables("cabecera_guiaG_ttx").SetDataSource(rsCabecera)
                            rpt.Database.Tables("detalle_guiaG_ttx").SetDataSource(rsDetalle)
                            If Existe_Impresora(ObjPerm.impresora) Then
                                rpt.PrintOptions.PrinterName = ObjPerm.impresora
                            End If
                            'vStado = CBool(rsCabecera.Rows(0).Item("estado").ToString)
                            With rpt
                                If vCodigo_Doc = 1 Or vCodigo_Doc = 2 Or vCodigo_Doc = 11 Then
                                    'rpt.SetParameterValue(2, rsCabecera.Rows(0).Item("nombre_local").ToString)
                                    ''.FormulaFields.Item(1).Text = "'" & Obtener_Datos_Almacen(oDocumento.pCodigo_Almacen, "nombre") & "'"
                                    'rpt.SetParameterValue(2, rsCabecera.Rows(0).Item("direccion_local").ToString)
                                    ''.FormulaFields.Item(2).Text = "'" & Obtener_Datos_Almacen(oDocumento.pCodigo_Almacen, "direccion") & "'"
                                    'rpt.SetParameterValue(5, rsCabecera.Rows(0).Item("telefono_local").ToString)
                                    ''.FormulaFields.Item(5).Text = "'" & "Tlf: " & Obtener_Datos_Almacen(oDocumento.pCodigo_Almacen, "telefono") & "'"
                                    'rpt.SetParameterValue(3, rsCabecera.Rows(0).Item("ruc").ToString)
                                    ''.FormulaFields.Item(3).Text = "'" & "Ruc: " & Obtener_Datos_Almacen(oDocumento.pCodigo_Almacen, "ruc") & "'"
                                    'rpt.SetParameterValue(4, "'" & "Serie tk: " & ObjPerm.serie_TK & "'")
                                    ''.FormulaFields.Item(4).Text = "'" & "Serie tk: " & ObjPerm.serie_TK & "'"
                                    'If vStado = False Then
                                    '    rpt.SetParameterValue(6, "'" & "**A N U L A D O**" & "'")
                                    '    '.FormulaFields.Item(6).Text = "'" & "**A N U L A D O**" & "'"
                                    'End If
                                End If
                            End With

                            'rpt.PrintToPrinter(1, False, 0, 0)
                            cv.ReportSource = rpt
                            'cv.ReportSource = rpt
                            Imprimir_Guia = True
                        Else
                            MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
                        End If
                    End If
                Else
                    MsgBox("No Existe Archivo del Reporte :" & Chr(13) & NameRpt, MsgBoxStyle.Exclamation, "AVISO")
                End If

            Else
                MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
            End If
                'ObjPerm = Nothing

        Catch ex As Exception
            Imprimir_Guia = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Guia
    End Function



    '==============Genéricos=========================================================================

    Public Shared Function Editar_Cab(ByVal RsCab As DataTable, ByVal vserie_Tk As String) As DataTable
        Dim cRow As DataRow

        If Existe_Campo("importe_letras", RsCab) Then
            For Each cRow In RsCab.Rows

                cRow.Item("importe_letras") = Numeros_Letras.EnLetras(cRow.Item("total"))
                cRow.Item("serietk") = vserie_Tk
                RsCab.AcceptChanges()

            Next
        End If

        Return RsCab

    End Function


    Public Shared Function Existe_Campo(ByVal Name_Col As String, ByVal RsCab As DataTable) As Boolean
        Dim Cols As DataColumn
        Existe_Campo = False
        For Each Cols In RsCab.Columns
            If Cols.ColumnName.ToString = Name_Col Then
                Existe_Campo = True
                Exit For
            End If
        Next

        Return Existe_Campo

    End Function

    Public Shared Function Existe_Archivo(ByVal Name_File As String) As Boolean

        If System.IO.File.Exists(Name_File) Then

            Existe_Archivo = True

        End If

        Return Existe_Archivo

    End Function

    Public Shared Function Existe_Impresora(ByVal Name_Printer As String) As Boolean
        Dim Df As New PrintDocument
        Dim Printer As String
        'Impresora por Defecto        
        Dim sw_Df As String = Df.PrinterSettings.PrinterName

        For Each Printer In PrinterSettings.InstalledPrinters
            If Printer.ToString = Name_Printer Then
                Existe_Impresora = True
                Exit For
            End If
        Next

        Return Existe_Impresora
    End Function

End Class