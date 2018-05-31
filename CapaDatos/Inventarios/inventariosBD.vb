Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class inventariosBD
        Public Shared Function Mi_Stock(ByVal vProductoId As Long, ByVal vAlmacenid As Integer, ByVal vAnio As Integer) As DataTable
            Dim TempList As New DataTable
            Dim vFuncion As String = ""


            vFuncion = "inventarios.pamistock"


            Dim oSP As New clsStored_Procedure(vFuncion)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vproducto", vProductoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()

            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Transferencia_Stock(ByVal vPositivos As Boolean, ByVal vAno_Origen As Integer, ByVal vAno_Destino As Integer, _
                                                 ByVal vCodigo_Almacen As Integer, ByVal vCodigo_Tipo As Integer, ByVal vCodigo_Documento As Integer, _
                                                 ByVal vCodigo_Proveedor As Long, ByVal vUsuario As String, ByVal vCaja As String, _
                                                 ByVal vCantidad As Integer) As DataTable
            Dim TempList As New DataTable
            Dim vFuncion As String = ""

            If vPositivos Then
                vFuncion = "paTransferencia_Stock_Positivos"
            Else
                vFuncion = "paTransferencia_Stock_Negativos"
            End If

            Dim oSP As New clsStored_Procedure(vFuncion)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vano_origen", vAno_Origen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vano_destino", vAno_Destino, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_alm", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_tipo", vCodigo_Tipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_doc", vCodigo_Documento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vproveedor", vCodigo_Proveedor, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcantidad", vCantidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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

