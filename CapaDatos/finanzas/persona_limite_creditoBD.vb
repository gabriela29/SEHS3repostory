
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class persona_limite_creditoBD
        Public Shared Function GetList(ByVal vUnidadId As Integer, ByVal vAlmacenid As Integer, ByVal vNumero As String, ByVal vPaterno As String, _
                                       ByVal vMaterno As String, ByVal vNombre As String, ByVal vTipo As String, ByVal vLimite As Long) As DataTable
            Dim TempList As New DataTable
            'finanzas.papersona_limite_credito_leer(inunidadid integer, inalmacenid integer, innumero varchar,
            'inpaterno varchar, inmaterno varchar, innombre varchar, intipo varchar, inlimite integer)
            Dim oSP As New clsStored_Procedure("finanzas.papersona_limite_credito_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inunidadid", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inalmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inpaterno", vPaterno, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inmaterno", vMaterno, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inlimite", vLimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Actualizar(ByRef vAlmacenid As Integer, vPersonaid As Long, vImporte As Single) As DataTable
            Dim vCadena As String = ""
            'finanzas.papersona_limite_credito_actualizar(inalmacenid integer, inpersonaid integer, inimporte numeric)
            Try
                vCadena = "select * from finanzas.paregistro_mb_actualizar(true,0, "
                vCadena = vCadena & " " & Trim(Str(vAlmacenid)) & ","
                vCadena = vCadena & " " & Trim(Str(vPersonaid)) & ","
                vCadena = vCadena & " " & Trim(Str(vImporte)) & ""
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

    End Class
End Namespace


