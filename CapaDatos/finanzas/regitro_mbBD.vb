Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class regitro_mbBD
        Public Shared Function GetList(ByVal vTabla As String, ByVal vTablaId As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paregistro_mb_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("intabla", vTabla, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("intablaid", vTablaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Agregar(ByRef objMB As registro_mb, ByVal vAlmacen As Integer) As DataTable
      Dim vCadena As String = ""
      'finanzas.paregistro_mb_actualizar(innew boolean, inalmacenid integer, intable varchar, intableid integer, 
      'incuenta integer, inctacte varchar, incentro_costo varchar, innroope varchar, inimporte numeric, infecha date, inglosa varchar)
      Try
        vCadena = "select * from finanzas.paregistro_mb_actualizar(true,0, "
        vCadena = vCadena & " " & Trim(Str(vAlmacen)) & ","
        vCadena = vCadena & " '" & objMB.tabla & "',"
        vCadena = vCadena & " " & Trim(Str(objMB.tablaid)) & ","
        vCadena = vCadena & " " & Trim(Str(objMB.cuenta)) & ","
        vCadena = vCadena & " '" & Trim(objMB.ctacte) & "',"
        vCadena = vCadena & " '" & Trim(objMB.centro_costo) & "',"
        vCadena = vCadena & " '" & Trim(objMB.nrooperacion) & "',"
        vCadena = vCadena & " " & Trim(Str(objMB.importe)) & ","
        vCadena = vCadena & " '" & objMB.fecha & "',"
        vCadena = vCadena & " '" & objMB.fecha_registro & "',"
        vCadena = vCadena & " '" & Trim(objMB.glosa) & "',"
        vCadena = vCadena & " '" & Trim(objMB.usuario) & "',"
        vCadena = vCadena & " '" & Trim(objMB.caja) & "', "
        vCadena = vCadena & " '" & Trim(objMB.tipomonedaid) & "', "
        vCadena = vCadena & " " & Trim(Str(objMB.tipocambio))
        vCadena = vCadena & " )"

        Dim oConexion As New clsConexion
        Agregar = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paregistro_mb_eliminar")
            Try
                oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

    End Class
End Namespace

