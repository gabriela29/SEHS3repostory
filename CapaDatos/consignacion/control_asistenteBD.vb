Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class control_asistenteBD
        Public Shared Function Leer_Asistentes(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.papersonas_campania_leer_asistente")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Asistentes_Cbo(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.papersonas_campania_leer_asistentecbo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Grabar(ByRef objPC As personas_campania) As DataTable
      Dim vCadena As String = ""
      'incodigo_cam integer, incodigo_alm integer, incodigo_asi integer, incodigo_colp integer, nrocuenta character varying, 
      'observacion character varying, usuario character varying, caja
      Try
        vCadena = "select * from colportaje.papersonas_campania_actualizar(true,"
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_cam)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_alm)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_asi)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_colp)) & ", "
        vCadena = vCadena & " '" & objPC.nrocuenta & "',"
        vCadena = vCadena & "  " & Trim(Str(objPC.c_costo)) & ","
        vCadena = vCadena & " '" & objPC.observacion & "',"
        vCadena = vCadena & " '" & objPC.usuario & "',"
        vCadena = vCadena & " '" & objPC.caja & "'"
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Grabar = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Trasladar_Colportor(ByRef objPC As personas_campania, ByVal vAlmacenid As Integer,
                                               ByVal vAsistenteid As Long, ByVal vSaldo As Single) As DataTable
      Dim vCadena As String = ""

      Try
        vCadena = "select * from colportaje.papersonas_trasladar_colportor("
        vCadena = vCadena & " " & Trim(Str(vAlmacenid)) & ","
        vCadena = vCadena & " " & Trim(Str(vAsistenteid)) & ", "

        vCadena = vCadena & " " & Trim(Str(objPC.codigo_cam)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_alm)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_asi)) & ","
        vCadena = vCadena & " " & Trim(Str(objPC.codigo_colp)) & ","
        vCadena = vCadena & "  " & Trim(Str(objPC.c_costo)) & ","
        vCadena = vCadena & "  " & Trim(Str(vSaldo)) & ","
        vCadena = vCadena & " '" & objPC.observacion & "',"
        vCadena = vCadena & " '" & objPC.usuario & "',"
        vCadena = vCadena & " '" & objPC.caja & "'"
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Trasladar_Colportor = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Actualizar(ByRef objPC As personas_campania) As DataTable

      Dim vCadena As String = ""
      'incodigo_cam integer, incodigo_alm integer, incodigo_asi integer, incodigo_colp integer, nrocuenta character varying, 
      'observacion character varying, usuario character varying, caja
      Try
        vCadena = "update colportaje.personas_campania set c_costo= "
        vCadena = vCadena & "  " & Trim(Str(objPC.c_costo)) & " "
        vCadena = vCadena & " where "
        vCadena = vCadena & " almacenid= " & Trim(Str(objPC.codigo_alm)) & " and "
        vCadena = vCadena & " asistenteid= " & Trim(Str(objPC.codigo_asi)) & " and "
        vCadena = vCadena & " campaniaid= " & Trim(Str(objPC.codigo_cam)) & " and "
        vCadena = vCadena & " colportorid= " & Trim(Str(objPC.codigo_colp))


        Dim oConexion As New clsConexion
        Actualizar = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Eliminar(ByVal vcampania As Integer, ByVal valmacen As Integer, ByVal vasistente As Long, ByVal vColportor As Long) As DataTable
            Dim vCadena As String = ""
            Dim vVacio As String = "", vCCosto As Integer = 0
            'colportaje.papersonas_campania_eliminar(incodigo_cam integer, incodigo_alm integer, incodigo_asi integer, incodigo_colp integer)
            Try
                vCadena = "select * from colportaje.papersonas_campania_eliminar(false,"
        vCadena = vCadena & " " & Trim(Str(vcampania)) & ","
        vCadena = vCadena & " " & Trim(Str(valmacen)) & ","
                vCadena = vCadena & " " & Trim(Str(vasistente)) & ","
                vCadena = vCadena & " " & Trim(Str(vColportor)) & " "              
                vCadena = vCadena & ")"

                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Leer_Colportores(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, _
                                                ByVal vCampania As Integer, ByVal vAsistente As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.papersona_campania_leer_colportor")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vasistente", vAsistente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Leer_Colportores_Tras(ByVal vUnidad As Integer, ByVal vAlmacen As Integer,
                                                ByVal vCampania As Integer, ByVal vAsistente As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.papersona_campania_leer_tras")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vasistente", vAsistente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paporcobrar_experian")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Trasladar_Colportor_Bloque(ByVal vCampaniaId As Integer, ByVal vAlmacenid As Integer, ByVal vAsistenteid As Long, ByVal VCampDest As Integer,
                                                      ByVal vCcosto As Integer, ByVal vArray As String, ByVal inUs As String, ByVal inCaja As String) As DataTable
      Dim vCadena As String = ""

      Try
        vCadena = "select * from colportaje.papersonas_campania_traslado("
        vCadena = vCadena & " " & Trim(Str(vCampaniaId)) & ","
        vCadena = vCadena & " " & Trim(Str(vAlmacenid)) & ","
        vCadena = vCadena & " " & Trim(Str(vAsistenteid)) & ", "
        vCadena = vCadena & " " & Trim(Str(VCampDest)) & ","
        vCadena = vCadena & " " & Trim(Str(vCcosto)) & ","
        vCadena = vCadena & " " & vArray & ","
        vCadena = vCadena & " '" & inUs & "',"
        vCadena = vCadena & " '" & inCaja & "'"
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Trasladar_Colportor_Bloque = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

  End Class

End Namespace
