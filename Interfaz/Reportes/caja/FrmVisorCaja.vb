Imports System
Imports System.IO

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class FrmVisorCaja

    Public Function RptArqueo(ByVal dtTmp As DataTable, ByVal vEmpresa As String, _
                                    ByVal vLocal As String, ByVal vDetalle As String) As Boolean
        Dim rpt As New RptArqueo_Caja

        rpt.SetDataSource(dtTmp)

        'rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vEmpresa)
        rpt.SetParameterValue(2, vLocal)
        rpt.SetParameterValue(3, vDetalle)
        cvCaja.ReportSource = rpt
    End Function

    Public Function RptArqueo_FF(ByVal dtTmp As DataTable, ByVal vEmpresa As String, _
                                            ByVal vLocal As String, ByVal vDetalle As String, ByVal vNombreLote As String) As Boolean
        Dim rpt As New RptArqueo_FF

        rpt.SetDataSource(dtTmp)

        rpt.SetParameterValue(2, vEmpresa)
        rpt.SetParameterValue(3, vLocal)
        rpt.SetParameterValue(4, vDetalle)
        rpt.SetParameterValue(1, vNombreLote)

        cvCaja.ReportSource = rpt
    End Function

    Public Function RptIngresos_Concepto(ByVal dtTmp As DataTable, ByVal vEmpresa As String, _
                                        ByVal vLocal As String, ByVal vSt As String, ByVal vDetalle As String, ByVal vUSuario As String) As Boolean
        'Dim rpt As New Rpt_Ing_Acad_Conc

        'rpt.SetDataSource(dtTmp)

        'rpt.SetParameterValue(0, vEmpresa)
        'rpt.SetParameterValue(1, vLocal)
        'rpt.SetParameterValue(2, vSt)
        'rpt.SetParameterValue(5, vDetalle)
        'rpt.SetParameterValue(4, My.Computer.Name)
        'rpt.SetParameterValue(3, vUSuario)

        'cvCaja.ReportSource = rpt
    End Function

    Public Function RptList_Mov_Caja(ByVal dtl As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, _
                                    ByVal vSubTitulo As String, ByVal vCond As String, ByVal vRes As Boolean) As Boolean
        Dim rpt As New rptListado_Mov_Caja   'RptAsiento_Ctr

        rpt.SetDataSource(dtl)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vSubTitulo)
        rpt.SetParameterValue(3, vCond)
        rpt.SetParameterValue(4, GestionSeguridadManager.sUsuario)
        rpt.SetParameterValue(5, My.Computer.Name)
        rpt.GroupHeaderSection2.SectionFormat.EnableSuppress = vRes
        rpt.DetailSection2.SectionFormat.EnableSuppress = vRes
        rpt.GroupFooterSection1.SectionFormat.EnableSuppress = vRes
        cvCaja.ReportSource = rpt
    End Function

    Public Function RptAsiento(ByVal dtTmp As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String) As Boolean
        Dim rpt As New RptAsiento_Ctr

        rpt.SetDataSource(dtTmp)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vDetalle)
        rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)

        cvCaja.ReportSource = rpt
    End Function

    Public Function Previo_Rpt_Documento_Cursor(ByRef vCodigo As Long) As Boolean
        Dim rpt As New ReportDocument
        Dim rsPermisos As New DataTable
        Dim rsCabecera As New DataTable
        Dim rsDetalle As New DataTable

        '=====================================
        ''Dim ObjOp As New operacion, vCodigo_Permi As Long, ObjPerm As New permisos_impresion

        ''NameRpt = ""
        ''Try
        ''    Call operacionManager.Datos_Impresion_Cursor(vCodigo, GestionSeguridadManager.idUsuario, My.Computer.Name, _
        ''                                                 rsPermisos, rsCabecera, rsDetalle)
        ''    If Not rsPermisos Is Nothing Then
        ''        'vCodigo_Permi = permisos_impresionManager.Existe_Codigo(GestionSeguridadManager.idUsuario, ObjOp.codigo_uni, My.Computer.Name, ObjOp.codigo_doc, 0)
        ''        vCodigo_Permi = rsPermisos.Rows(0).Item(0).ToString
        ''        If vCodigo_Permi > 0 Then
        ''            'ObjPerm = permisos_impresionManager.GetItem(vCodigo_Permi)
        ''            If CBool(rsPermisos.Rows(0).Item(0).ToString) Then
        ''                'NameRpt = ObjPerm.formato
        ''                NameRpt = rsPermisos.Rows(0).Item("formato").ToString
        ''                If Existe_Archivo(NameRpt) Then
        ''                    'rsCabecera = operacionManager.Datos_Impresion_Cab(vCodigo)
        ''                    'rsDetalle = operacionManager.Datos_Impresion_Det(vCodigo)
        ''                    If rsCabecera.Rows.Count > 0 And rsDetalle.Rows.Count > 0 Then
        ''                        rsCabecera = Editar_Cab(rsCabecera)
        ''                        rsCabecera.TableName = "Cabecera_Boleta_ttx"
        ''                        rsDetalle.TableName = "Detalle_Boleta_TTX"
        ''                        rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
        ''                        rpt.Database.Tables("Cabecera_Boleta_ttx").SetDataSource(rsCabecera)
        ''                        rpt.Database.Tables("Detalle_Boleta_TTX").SetDataSource(rsDetalle)

        ''                        rpt.SetParameterValue(0, rsPermisos.Rows(0).Item("serie_tk").ToString)

        ''                        If Existe_Impresora(rsPermisos.Rows(0).Item("impresora").ToString) Then
        ''                            rpt.PrintOptions.PrinterName = rsPermisos.Rows(0).Item("impresora").ToString
        ''                        End If


        ''                        'rpt.PrintToPrinter(1, False, 0, 0)

        ''                        cvCaja.ReportSource = rpt
        ''                        Previo_Rpt_Documento_Cursor = True
        ''                    Else
        ''                        MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
        ''                    End If
        ''                Else
        ''                    MsgBox("No Existe Archivo del Reporte :" & Chr(13) & NameRpt, MsgBoxStyle.Exclamation, "AVISO")
        ''                End If

        ''                'Else
        ''                'MsgBox("No puede leer la clase Permiso", MsgBoxStyle.Exclamation, "AVISO")
        ''            End If
        ''        Else 'Si no hay Codigo de Permiso
        ''            MsgBox("No tiene Permiso de Impresión", MsgBoxStyle.Exclamation, "AVISO")
        ''        End If
        ''    Else 'Si no hay Operacion
        ''        MsgBox("No existe Registro del Documento", MsgBoxStyle.Exclamation, "AVISO")
        ''    End If

        'Catch ex As Exception
        '    Previo_Rpt_Documento_Cursor = False
        '    MsgBox(ex.Message.ToString)
        'End Try
        'Return Previo_Rpt_Documento_Cursor
    End Function

    '==============Genéricos=========================================================================
    Public Shared Function Editar_Cab(ByVal RsCab As DataTable) As DataTable
        Dim cRow As DataRow

        If Existe_Campo("importe_letras", RsCab) Then
            For Each cRow In RsCab.Rows

                cRow.Item("importe_letras") = Numeros_Letras.EnLetras(cRow.Item("importe"))
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

    '==============FIN Genéricos=========================================================================

End Class