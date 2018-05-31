Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal

  Public Class tipo_loteBD

    'Public Shared Function GetItem(ByVal codigo As Integer) As serie
    '  Dim objserie As serie = Nothing
    '  Dim TempList As New DataTable
    '  Dim oSP As New clsStored_Procedure("contable.patipo_lote_getrow")
    '  Dim oConexion As New clsConexion
    '  Dim objReader As DataRow
    '  Try
    '    oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
    '    TempList = oConexion.Ejecutar_Consulta(oSP)
    '    objReader = Nothing
    '    If TempList.Rows.Count > 0 Then
    '      objReader = TempList.Rows(0)
    '    End If
    '    Try
    '      If Not objReader Is Nothing Then
    '        objserie = LlenarDatosRegistro(objReader)
    '      End If
    '    Finally
    '      objReader = Nothing
    '    End Try
    '  Finally
    '    oConexion.Cerrar_Conexion()
    '    oConexion = Nothing
    '    oSP = Nothing
    '  End Try
    '  Return objserie
    'End Function

    Public Shared Function GetList(ByVal descripcion As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.patipo_lote_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    'Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As serie
    '  Dim objeto As serie = New serie
    '  objeto.codigo = objData.Item("codigo")
    '  objeto.codigo_emp = objData.Item("codigo_emp")
    '  objeto.serie = objData.Item("serie")
    '  objeto.codigo_doc = objData.Item("codigo_doc")
    '  objeto.correlativo = objData.Item("correlativo")
    '  objeto.estado = objData.Item("estado")
    '  Return objeto
    'End Function

    'Public Shared Function Grabar(ByRef objserie As serie) As DataTable
    '  Dim oSP As New clsStored_Procedure("basic.paserie_actualizar")
    '  Try
    '    'innew boolean, incodigo integer, incodigo_emp integer, incodigo_doc integer, inserie character varying, 
    '    'incorrelativo bigint, inestado boolean
    '    If objserie.codigo = -1 Then
    '      oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
    '    Else
    '      oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
    '    End If
    '    oSP.addParameter("incodigo", objserie.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

    '    oSP.addParameter("incodigo_emp", objserie.codigo_emp, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

    '    oSP.addParameter("incodigo_doc", objserie.codigo_doc, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

    '    oSP.addParameter("inserie", objserie.serie, NpgsqlTypes.NpgsqlDbType.Varchar, 4, ParameterDirection.Input)

    '    oSP.addParameter("incorrelativo", objserie.correlativo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

    '    oSP.addParameter("inestado", objserie.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)

    '    Dim oConexion As New clsConexion
    '    Grabar = oConexion.Ejecutar_Consulta(oSP)
    '    oConexion.Cerrar_Conexion()
    '    oConexion = Nothing
    '  Finally
    '    oSP = Nothing
    '  End Try
    'End Function
    Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
      Dim oSP As New clsStored_Procedure("basic.paserie_eliminar")
      Try
        oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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
