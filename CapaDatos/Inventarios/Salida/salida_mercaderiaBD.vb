Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class salida_mercaderiaBD
        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.pasalida_mercaderia_cambiar_estado")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
            Dim oSP As New clsStored_Procedure("pasalida_mercaderia_cambiar_estado")
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

        Public Shared Function Consulta_Salidas(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, _
                                               ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paconsulta_Salida")
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

        Public Shared Function Leer(ByVal valmacen As Integer, ByVal vdocumento As Integer, ByVal vPersona As Long, ByVal vrazsoc As String, _
                                    ByVal vdesde As String, ByVal vhasta As String, ByVal vlimite As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.pasalida_mercaderia_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", valmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)                
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vrazsoc", vrazsoc, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Traslado_Pendiente(ByVal valmacen As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.patraslado_mercaderia_pendiente")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", valmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)             

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
            Dim oSP As New clsStored_Procedure("inventarios.pasalida_mercaderia_eliminar")
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

        Public Shared Function Agregar(ByRef objSM As salida_mercaderia, ByVal myArr As String, ByVal vSerieId As Long) As DataTable
            Dim vCadena As String = ""

            Try

                vCadena = "select * from inventarios.pasalida_mercaderia_actualizar(true,"
                vCadena = vCadena & " 0,"
                vCadena = vCadena & " " & Trim(Str(objSM.Codigo_tipo)) & ","
                vCadena = vCadena & " '" & Trim(objSM.Numero) & "',"
                vCadena = vCadena & " " & Trim(Str(objSM.Codigo_Documento)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.Codigo_Almacen)) & ", "
                vCadena = vCadena & " " & Trim(Str(objSM.codigo_persona)) & ","
                vCadena = vCadena & " '" & Trim(objSM.fecha) & "',"
                vCadena = vCadena & " '" & Trim(objSM.Moneda) & "',"
                vCadena = vCadena & " '" & objSM.condicion & "',"
                vCadena = vCadena & " " & Trim(Str(objSM.vta_Bruta)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.Descuento)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.IGV)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.Vta_Total)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.Cambio)) & ","
                vCadena = vCadena & " " & Trim(Str(objSM.Usuarioid)) & ","
                vCadena = vCadena & " '" & objSM.caja & "',"
                vCadena = vCadena & " " & IIf(objSM.Estado, "true", "false") & ","
                vCadena = vCadena & " '" & Trim(objSM.Observacion) & "',"
                vCadena = vCadena & " " & IIf(objSM.Cerrado, "true", "false") & ","
                vCadena = vCadena & " " & IIf(objSM.Incluye_IGV, "true", "false") & ","
                vCadena = vCadena & " '" & Trim(objSM.Referencia) & "',"
                vCadena = vCadena & " " & Trim(Str(objSM.Codigo_Ref1)) & ", "
                vCadena = vCadena & " " & Trim(Str(objSM.Codigo_Ref2)) & ", "
                vCadena = vCadena & " " & IIf(objSM.Descontar_Stock, "true", "false") & ", "
                vCadena = vCadena & " " & Trim(Str(objSM.Valor_igv)) & ", "
                vCadena = vCadena & " " & Trim(myArr) & ", "

                vCadena = vCadena & " " & Trim(Str(vSerieId)) & " "
                vCadena = vCadena & ")"

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
            Dim oSP As New clsStored_Procedure("paventa_leer_items")
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

        Public Shared Function Datos_Impresion_Cab(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paimprimir_venta_cabecera")
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

        Public Shared Function Datos_Impresion_Det(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paimprimir_venta_detalle")
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

    End Class
End Namespace
