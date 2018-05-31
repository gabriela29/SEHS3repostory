Imports System
Imports System.IO

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class ClsImpresiones

    Public Shared Function Imprimir_Rpt(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer, _
                                        ByVal vFormato As String, ByVal vSerieTK As String, ByVal vCopias As Integer, ByVal vImpresora As String) As Boolean
        Dim rpt As New ReportDocument
        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable

        '=====================================
        'Dim ObjPerm As New permisos_impresion
        Dim vStado As Boolean
        Try

            'ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, My.Computer.Name, vCodigo_Doc, 0)

            If Not (vFormato = "" Or vCodigo_Doc = 0) Then
                'NameRpt = ObjPerm.formato
                'vSerieTK = ObjPerm.serie_TK
                If Existe_Archivo(vFormato) Then
                    If ventaManager.Datos_Impresion(vCodigo, rsCabecera, rsDetalle) Then
                        If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
                            rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                            rsCabecera.TableName = "dtcabecera"
                            rsDetalle.TableName = "dtdetalle"
                            'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                            rpt.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                            rpt.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                            If Existe_Impresora(vImpresora) Then
                                rpt.PrintOptions.PrinterName = vImpresora
                            End If
                            vStado = CBool(rsCabecera.Rows(0).Item("estado").ToString)
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

                            rpt.PrintToPrinter(1, False, 0, 0)

                            Imprimir_Rpt = True
                        Else
                            MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
                        End If
                    End If
                Else
                    MsgBox("No Existe Archivo del Reporte :" & Chr(13) & vFormato, MsgBoxStyle.Exclamation, "AVISO")
                End If

            Else
                MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
            End If
            'ObjPerm = Nothing

        Catch ex As Exception
            Imprimir_Rpt = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Rpt
    End Function

    Public Shared Function Imprimir_Rpt_MB(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer, _
                                            ByVal vNamePC As String, ByVal vLegal As Boolean, sIng As Boolean) As Boolean

        Dim rpt As ReportDocument
        If vLegal Then
            If vCodigo_Doc = 1 Or vCodigo_Doc = 37 Then
                rpt = New MiFacturaTk  'ReportDocument
            ElseIf vCodigo_Doc = 11 Then
                rpt = New MiNotaCreditoTK
            Else
                rpt = New MiBoletaTk  'ReportDocument
            End If
        Else
            If vCodigo_Doc = 11 Then
                rpt = New MiNotaCreditoTK
            Else
                rpt = New MiRecibo_InternoTk
            End If
        End If


        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable

        '=====================================
        Dim ObjPerm As New permisos_impresion
        Dim vStado As Boolean
        Try

            ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, vNamePC, vCodigo_Doc, 0)
            If Not ObjPerm Is Nothing Then
                Dim vFormato As String = "", vSerieTK As String = "", vImpresora As String = ""
                vFormato = ObjPerm.formato
                vSerieTK = ObjPerm.serie_TK
                vImpresora = ObjPerm.impresora

                If Not (vFormato = "" Or vCodigo_Doc = 0) Then
                    'NameRpt = ObjPerm.formato
                    'vSerieTK = ObjPerm.serie_TK
                    If Existe_Archivo(vFormato) Then
                        If movimiento_bancarioManager.Datos_Impresion(vCodigo, rsCabecera, rsDetalle, sIng) Then
                            If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
                                rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                                rsCabecera.TableName = "dtcabecera"
                                rsDetalle.TableName = "dtdetalle"
                                'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                                rpt.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                                rpt.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                                If Existe_Impresora(vImpresora) Then
                                    rpt.PrintOptions.PrinterName = vImpresora
                                End If
                                vStado = CBool(rsCabecera.Rows(0).Item("estado").ToString)

                                rpt.PrintToPrinter(1, False, 0, 0)

                                Imprimir_Rpt_MB = True
                            Else
                                MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
                            End If
                        End If
                    Else
                        MsgBox("No Existe Archivo del Reporte :" & Chr(13) & vFormato, MsgBoxStyle.Exclamation, "AVISO")
                    End If

                Else
                    MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
                End If
            Else
                MsgBox("No tiene Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
            End If
            ObjPerm = Nothing

        Catch ex As Exception
            Imprimir_Rpt_MB = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Rpt_MB
    End Function

    Public Shared Function Imprimir_Rpt(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer) As Boolean
        Dim rpt As ReportDocument
        If vCodigo_Doc = 1 Or vCodigo_Doc = 37 Then
            rpt = New MiFacturaTk  'ReportDocument
        ElseIf vCodigo_Doc = 11 Then
            rpt = New MiNotaCreditoTK
        ElseIf vCodigo_Doc = 36 Then
            rpt = New MiFactura
        Else
            rpt = New MiBoletaTk  'ReportDocument
        End If


        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable
        Dim NameRpt As String, vSerieTK As String = ""
        '=====================================
        Dim ObjPerm As New permisos_impresion
        Dim vStado As Boolean
        Try

            ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, My.Computer.Name, vCodigo_Doc, 0)

            If Not ObjPerm Is Nothing Then

                NameRpt = ObjPerm.formato
                vSerieTK = ObjPerm.serie_TK
                If Not ObjPerm.impresion Then
                    Imprimir_Rpt = False
                    Exit Function
                End If

                If Existe_Archivo(NameRpt) Then
                    If ventaManager.Datos_Impresion(vCodigo, rsCabecera, rsDetalle) Then
                        If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
                            rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                            rsCabecera.TableName = "dtcabecera"
                            rsDetalle.TableName = "dtdetalle"
                            'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                            rpt.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                            rpt.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                            If Existe_Impresora(ObjPerm.impresora) Then
                                rpt.PrintOptions.PrinterName = ObjPerm.impresora
                            End If
                            vStado = CBool(rsCabecera.Rows(0).Item("estado").ToString)
                            With rpt
                                If vCodigo_Doc = 1 Or vCodigo_Doc = 2 Or vCodigo_Doc = 11 Then

                                End If
                            End With

                            rpt.PrintToPrinter(1, False, 0, 0)

                            Imprimir_Rpt = True
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
            Imprimir_Rpt = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Rpt
    End Function

    Public Shared Function Imprimir_Rpt_DZMO(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer, _
                                                ByVal vFormato As String, ByVal vSerieTK As String, ByVal vCopias As Integer, ByVal vImpresora As String) As Boolean
        Dim rpt As New MiRecibo_DzmoTk  'ReportDocument
        Dim rsData As New DataTable

        '=====================================
        'Dim ObjPerm As New permisos_impresion

        Try

            'ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, My.Computer.Name, vCodigo_Doc, 0)

            If Not (vFormato = "" Or vCodigo_Doc = 0) Then
                'NameRpt = ObjPerm.formato
                'vSerieTK = ObjPerm.serie_TK
                If Existe_Archivo(vFormato) Then
                    rsData = reportes_consignacionManager.Detalle_Documento(vCodigo)
                    If rsData.Rows.Count > 0 Then
                        If rsData.Rows.Count > 0 Then

                            'rpt.Load(vFormato, OpenReportMethod.OpenReportByDefault)
                            rpt.SetDataSource(rsData)
                            If Existe_Impresora(vImpresora) Then
                                rpt.PrintOptions.PrinterName = vImpresora
                            End If
                            'vStado = CBool(rsData.Rows(0).Item("estado").ToString)
                            With rpt

                            End With

                            rpt.PrintToPrinter(1, False, 0, 0)

                            Imprimir_Rpt_DZMO = True
                        Else
                            MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
                        End If
                    End If
                Else
                    MsgBox("No Existe Archivo del Reporte :" & Chr(13) & vFormato, MsgBoxStyle.Exclamation, "AVISO")
                End If

            Else
                MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
            End If
            'ObjPerm = Nothing

        Catch ex As Exception
            Imprimir_Rpt_DZMO = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Rpt_DZMO
    End Function

    Public Shared Function Imprimir_Rpt_DZMO(ByRef vCodigo As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Doc As Integer) As Boolean
        Dim rpt As New MiRecibo_DzmoTk 'ReportDocument
        Dim rsData As New DataTable
        Dim NameRpt As String, vSerieTK As String = ""
        '=====================================
        Dim ObjPerm As New permisos_impresion

        Try

            ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, "DZMO", vCodigo_Doc, 0)

            If Not ObjPerm Is Nothing Then
                NameRpt = ObjPerm.formato
                vSerieTK = ObjPerm.serie_TK
                If Existe_Archivo(NameRpt) Then
                    rsData = reportes_consignacionManager.Detalle_Documento(vCodigo)
                    If rsData.Rows.Count > 0 Then
                        If rsData.Rows.Count > 0 Then

                            'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                            rpt.SetDataSource(rsData)
                            If Existe_Impresora(ObjPerm.impresora) Then
                                rpt.PrintOptions.PrinterName = ObjPerm.impresora
                            End If
                            'vStado = CBool(rsData.Rows(0).Item("estado").ToString)
                            With rpt

                            End With

                            rpt.PrintToPrinter(1, False, 0, 0)

                            Imprimir_Rpt_DZMO = True
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
            Imprimir_Rpt_DZMO = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Rpt_DZMO
    End Function

    Public Shared Function Imprimir_Recibo_Interno_pc(ByRef vCodigo As Long, ByVal vFormato As String, ByVal vImpresora As String, ByVal vSerie_tk As String, ByVal vCopias As Long) As Boolean
        Dim rpt As New ReportDocument

        Dim rsData As New DataTable

        Dim NameRpt As String
        '=====================================
        Dim ObjOp As New movimiento_bancario

        NameRpt = ""
        Try
            rsData = movimiento_bancarioManager.Reporte_Recibo_Interno_pc(vCodigo)

            If Not rsData Is Nothing Then

                If vCodigo > 0 Then

                    If Not vFormato.Trim = "" Then
                        'NameRpt = ObjPerm.formato
                        NameRpt = vFormato.Trim
                        If Existe_Archivo(NameRpt) Then
                            If rsData.Rows.Count > 0 Then
                                rsData = Editar_Cab(rsData, "--")

                                rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)

                                rpt.SetDataSource(rsData)



                                'rpt.SetParameterValue(0, vSerie_tk)

                                If Existe_Impresora(vImpresora.Trim) Then
                                    rpt.PrintOptions.PrinterName = vImpresora.Trim
                                End If

                                rpt.PrintToPrinter(vCopias, False, 0, 0)

                                Imprimir_Recibo_Interno_pc = True
                            Else
                                MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
                            End If
                        Else
                            MsgBox("No Existe Archivo del Reporte :" & Chr(13) & NameRpt, MsgBoxStyle.Exclamation, "AVISO")
                        End If

                        'Else
                        'MsgBox("No puede leer la clase Permiso", MsgBoxStyle.Exclamation, "AVISO")
                    End If
                Else 'Si no hay Codigo de Permiso
                    MsgBox("No tiene Permiso de Impresión", MsgBoxStyle.Exclamation, "AVISO")
                End If
            Else 'Si no hay Operacion
                MsgBox("No existe Registro del Documento", MsgBoxStyle.Exclamation, "AVISO")
            End If

        Catch ex As Exception
            Imprimir_Recibo_Interno_pc = False
            MsgBox(ex.Message.ToString)
        End Try
        Return Imprimir_Recibo_Interno_pc
    End Function

    Public Shared Function Imprimir_Rpt_Cursor_NC(ByRef vCodigo As Long) As Boolean
        Dim rpt As New ReportDocument
        Dim rsPermisos As New DataTable
        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable

        '=====================================
        'Dim ObjOp As New operacion, vCodigo_Permi As Long, ObjPerm As New permisos_impresion

        'NameRpt = ""
        'Try
        '    Call operacionManager.Datos_Impresion_Cursor(vCodigo, GestionSeguridadManager.idUsuario, "999", _
        '                                                 rsPermisos, rsCabecera, rsDetalle)
        '    If Not rsPermisos Is Nothing Then
        '        'vCodigo_Permi = permisos_impresionManager.Existe_Codigo(GestionSeguridadManager.idUsuario, ObjOp.codigo_uni, My.Computer.Name, ObjOp.codigo_doc, 0)
        '        vCodigo_Permi = rsPermisos.Rows(0).Item(0).ToString
        '        If vCodigo_Permi > 0 Then
        '            'ObjPerm = permisos_impresionManager.GetItem(vCodigo_Permi)
        '            If CBool(rsPermisos.Rows(0).Item(0).ToString) Then
        '                'NameRpt = ObjPerm.formato
        '                NameRpt = rsPermisos.Rows(0).Item("formato").ToString
        '                If Existe_Archivo(NameRpt) Then
        '                    'rsCabecera = operacionManager.Datos_Impresion_Cab(vCodigo)
        '                    'rsDetalle = operacionManager.Datos_Impresion_Det(vCodigo)
        '                    If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
        '                        rsCabecera = Editar_Cab(rsCabecera)
        '                        rsCabecera.TableName = "Cabecera_Boleta_ttx"
        '                        rsDetalle.TableName = "Detalle_Boleta_TTX"
        '                        rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
        '                        rpt.Database.Tables("Cabecera_Boleta_ttx").SetDataSource(rsCabecera)
        '                        rpt.Database.Tables("Detalle_Boleta_TTX").SetDataSource(rsDetalle)

        '                        rpt.SetParameterValue(0, rsPermisos.Rows(0).Item("serie_tk").ToString)

        '                        If Existe_Impresora(rsPermisos.Rows(0).Item("impresora").ToString) Then
        '                            rpt.PrintOptions.PrinterName = rsPermisos.Rows(0).Item("impresora").ToString
        '                        End If

        '                        rpt.PrintToPrinter(1, False, 0, 0)

        '                        Imprimir_Rpt_Cursor_NC = True
        '                    Else
        '                        MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
        '                    End If
        '                Else
        '                    MsgBox("No Existe Archivo del Reporte :" & Chr(13) & NameRpt, MsgBoxStyle.Exclamation, "AVISO")
        '                End If

        '                'Else
        '                'MsgBox("No puede leer la clase Permiso", MsgBoxStyle.Exclamation, "AVISO")
        '            End If
        '        Else 'Si no hay Codigo de Permiso
        '            MsgBox("No tiene Permiso de Impresión", MsgBoxStyle.Exclamation, "AVISO")
        '        End If
        '    Else 'Si no hay Operacion
        '        MsgBox("No existe Registro del Documento", MsgBoxStyle.Exclamation, "AVISO")
        '    End If

        'Catch ex As Exception
        '    Imprimir_Rpt_Cursor_NC = False
        '    MsgBox(ex.Message.ToString)
        'End Try
        'Return Imprimir_Rpt_Cursor_NC
    End Function

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

    '==============Genéricos=========================================================================
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
