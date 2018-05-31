Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class venta_guiaBD
        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_cambiar_estado")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Cambiar_Estado_Descontar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_cambiar_estado_descontar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consulta_Ventas(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, _
                                               ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paConsulta_Ventas_guia")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsigno", vSigno, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                                     ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, _
                                     ByVal vNumHasta As String, ByVal vNumero As String, ByVal vCliente As Long, _
                                     ByVal vRazon_Social As String, ByVal vSigno As String, ByVal vReferencia As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa__guia_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vvendedor", vVendedor, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecdesde", vFecDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vfechasta", vFecHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumdesde", vNumDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumhasta", vNumHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vraz_social", vRazon_Social, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)
                oSP.addParameter("vsigno", vSigno, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vreferencia", vReferencia, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_guia_eliminar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Agregar(ByRef objVG As venta_guia, ByVal myArr As String) As DataTable
            Dim vCadena As String = ""

            Try
                vCadena = "select * from paventa_guia_actualizar(true, "
                vCadena = vCadena & " 0,"
                vCadena = vCadena & " '" & objVG.numero & "',"
                vCadena = vCadena & " " & Trim(Str(objVG.ventaid)) & ","
                vCadena = vCadena & " " & Trim(Str(objVG.almacenid)) & ","
                vCadena = vCadena & " " & Trim(Str(objVG.clienteid)) & ","

                vCadena = vCadena & " " & Trim(Str(objVG.transporteid)) & ","
                vCadena = vCadena & " " & Trim(Str(objVG.choferid)) & ","

                vCadena = vCadena & " '" & objVG.fecha_emi & "',"
                vCadena = vCadena & " '" & objVG.fecha_tras & "',"
                vCadena = vCadena & " '" & objVG.hora_tras & "',"

                vCadena = vCadena & " '" & Trim(objVG.desde) & "',"
                vCadena = vCadena & " '" & Trim(objVG.hasta) & "',"

                vCadena = vCadena & " '" & Trim(objVG.marca) & "',"
                vCadena = vCadena & " '" & Trim(objVG.placa) & "',"

                vCadena = vCadena & " '" & Trim(objVG.licencia) & "',"
                vCadena = vCadena & " '" & Trim(objVG.constancia) & "',"

                vCadena = vCadena & " true," 'estado
                vCadena = vCadena & " '" & objVG.usuario & "',"
                vCadena = vCadena & " '" & objVG.caja & "',"

                vCadena = vCadena & " " & Trim(Str(objVG.impresiones)) & ","
                vCadena = vCadena & " " & IIf(objVG.reservado, "true", "false") & ","
                vCadena = vCadena & " " & IIf(objVG.descontar_stock, "true", "false") & ","
                vCadena = vCadena & " false," ' cerrado

                vCadena = vCadena & " " & Trim(myArr) & ", "

                vCadena = vCadena & " " & Trim(Str(objVG.serie)) & ","
                vCadena = vCadena & " " & Trim(Str(objVG.correlativo)) & " "

                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                Agregar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Leer_Items(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_guia_leer_items")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_cambiar_cierre")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function


    End Class
End Namespace
