Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmVisorTickets
    Public Function RptTickets_Anticipos(vCodigo As Long, vCodigo_Alm As Integer, vCodigo_Doc As Integer, ByVal vTipoId As Integer, ByVal vPeriodo As String, vArray As String) As Boolean

        Dim Report As ReportDocument

        If vCodigo_Doc = 1 Or vCodigo_Doc = 37 Then
            Report = New MiFacturaTk  'ReportDocument
        Else
            Report = New MiBoletaTk  'ReportDocument
        End If

        Dim opciones(1) As String
        Dim rsCabecera, rsDetalle As New DataTable
        Dim vNamePC As String = "XANTICIPO"
        Dim ObjPerm As New permisos_impresion
        ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vCodigo_Alm, vNamePC, vCodigo_Doc, 0)
        If Not ObjPerm Is Nothing Then
            Dim vFormato As String = "", vSerieTK As String = "", vImpresora As String = ""
            vFormato = ObjPerm.formato
            vSerieTK = ObjPerm.serie_TK
            vImpresora = ObjPerm.impresora


            If movimiento_bancarioManager.Datos_Imprimir_Anticipos_Fact(vCodigo, vCodigo_Alm, vTipoId, vPeriodo, rsCabecera, rsDetalle) Then
                rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                rsCabecera.TableName = "dtcabecera"
                rsDetalle.TableName = "dtdetalle"
                'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                Report.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                Report.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                Report.PrintOptions.PrinterName = vImpresora
                vSerieTK = ObjPerm.serie_TK
                Me.CrystalReportViewer1.ReportSource = Report
            End If

        End If
        ObjPerm = Nothing

    End Function

    Public Function RptTickets_Suscripcion(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer, _
                                            ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String, _
                                            ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, ByVal vDMid As Long) As Boolean

        Dim Report As ReportDocument


        If vDocumentoid = 1 Or vDocumentoid = 37 Then
            Report = New MiFacturaTk  'ReportDocument
        Else
            Report = New MiBoletaTk  'ReportDocument
        End If

        Dim opciones(1) As String
        Dim rsCabecera, rsDetalle As New DataTable
        Dim vNamePC As String = GestionSeguridadManager.NombrePC
        Dim ObjPerm As New permisos_impresion
        ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vAlmacenid, vNamePC, vDocumentoid, 0)

        If Not ObjPerm Is Nothing Then
            Dim vFormato As String = "", vSerieTK As String = "", vImpresora As String = ""
            vFormato = ObjPerm.formato
            vSerieTK = ObjPerm.serie_TK
            vImpresora = ObjPerm.impresora


            If movimiento_bancarioManager.Datos_Imprimir_Suscripcion_Fact(vAlmacenid, vIglesiaid, vPeriodoid, vPersonaid, vDocumentoid, vDesde, _
                                                                            vHasta, vNumDesde, vNumHasta, vDMid, rsCabecera, rsDetalle) Then
                rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                rsCabecera.TableName = "dtcabecera"
                rsDetalle.TableName = "dtdetalle"
                'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                Report.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                Report.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                Report.PrintOptions.PrinterName = vImpresora
                vSerieTK = ObjPerm.serie_TK
                Me.CrystalReportViewer1.ReportSource = Report
            End If

        End If
        ObjPerm = Nothing

    End Function

    Public Function RptTickets_Pedido(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer, _
                                        ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String, _
                                        ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                                        ByVal vDMid As Long, ByVal vUnidadId As Integer, ByVal vTipo As String) As Boolean

        Dim Report As ReportDocument


        If vDocumentoid = 1 Or vDocumentoid = 37 Then
            Report = New MiFacturaTk  'ReportDocument
        Else
            Report = New MiBoletaTk  'ReportDocument
        End If

        Dim opciones(1) As String
        Dim rsCabecera, rsDetalle As New DataTable
        Dim vNamePC As String = GestionSeguridadManager.NombrePC
        Dim ObjPerm As New permisos_impresion
        ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vAlmacenid, vNamePC, vDocumentoid, 0)

        If Not ObjPerm Is Nothing Then
            Dim vFormato As String = "", vSerieTK As String = "", vImpresora As String = ""
            vFormato = ObjPerm.formato
            vSerieTK = ObjPerm.serie_TK
            vImpresora = ObjPerm.impresora


            If movimiento_bancarioManager.Datos_Imprimir_Pedido_Fact(vAlmacenid, vIglesiaid, vPeriodoid, vPersonaid, vDocumentoid, vDesde, _
                                                                            vHasta, vNumDesde, vNumHasta, vDMid, vUnidadId, vTipo, rsCabecera, rsDetalle) Then
                rsCabecera = Editar_Cab(rsCabecera, vSerieTK)
                rsCabecera.TableName = "dtcabecera"
                rsDetalle.TableName = "dtdetalle"
                'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)
                Report.Database.Tables("dtcabecera").SetDataSource(rsCabecera)
                Report.Database.Tables("dtdetalle").SetDataSource(rsDetalle)
                Report.PrintOptions.PrinterName = vImpresora
                vSerieTK = ObjPerm.serie_TK
                Me.CrystalReportViewer1.ReportSource = Report
            End If

        End If
        ObjPerm = Nothing

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


End Class