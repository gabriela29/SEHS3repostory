Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class iglesiaBD
        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String, ByVal vMisionId As Integer, ByVal vGrupoId As Long, _
                                      ByVal vdepartamentoid As Long, ByVal vProvinId As Long, ByVal vdistritoid As Long) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paiglesia_leer(vinicio integer, vfin integer, vunionid integer, vmisionid integer, vgrupoid integer, vnombre character varying, 
            'vdepartamentoid integer, vprovinciaid integer, vdistritoid integer)
            Dim oSP As New clsStored_Procedure("suscripcion.paiglesia_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("ininicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("infin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inunion", vUnion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmisionid", vMisionId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("ingrupoid", vGrupoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("indptoid", vdepartamentoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inprovinid", vProvinId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("indistritoid", vdistritoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function
        Public Shared Function GestIglesiaJuridica(ByVal vPeriodo As Integer, ByVal vdistritoid As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.paperiodo_iglesia_juridica_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vperiodo", vdistritoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdistrito", vdistritoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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