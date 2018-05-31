Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class transferir_stockBD
        Public Shared Function GetList(ByVal vano_origen As Integer, ByVal vano_destino As Integer, ByVal vcodigo_almacen As Integer) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.patransferencia_stock_leer")
            Dim oConexion As New clsConexion

            Try
                oSP.addParameter("vano_origen", vano_origen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vano_destino", vano_destino, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_almacen", vcodigo_almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Transferir(ByVal vano_origen As Integer, ByVal vano_destino As Integer, _
                                            ByVal vcodigo_almacen As Integer, ByVal vcodigo_tipo As Integer, ByVal vcodigo_doc As Integer, _
                                            ByVal vcodigo_persona As Long, ByVal vusuario As Long, ByVal vcaja As String) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.patransferencia_stock")
            Dim oConexion As New clsConexion

            Try
                oSP.addParameter("vano_origen", vano_origen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vano_destino", vano_destino, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_almacen", vcodigo_almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_tipo", vcodigo_tipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_doc", vcodigo_doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_persona", vcodigo_persona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vusuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vcaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        '    inventarios.patransferencia_stock(
        'vano_origen integer,
        'vano_destino integer,
        'vcodigo_almacen integer,
        'vcodigo_tipo integer,
        'vcodigo_doc integer,
        'vcodigo_persona integer,
        'vusuario integer,
        'vcaja character varying)
    End Class
End Namespace

