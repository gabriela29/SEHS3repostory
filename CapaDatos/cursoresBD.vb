Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class cursoresBD

    Public Shared Function Inicializa_Windows(ByVal vPersonaid As Long, ByRef dtmenu As DataTable, ByRef dtunidad As DataTable,
                                                ByRef dtAlmacen As DataTable, ByRef dtpermisos As DataTable, ByRef dtperdoc As DataTable,
                                                ByRef dtplan As DataTable, ByRef dtctacte As DataTable, ByRef dtconf As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vcodigo integer, vmovimiento integer, vmodulo integer
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("painicializa_window", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vPersonaid
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtmenu, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtunidad, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtAlmacen, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtpermisos, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtperdoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtplan, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtctacte, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtconf, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()
        t = Nothing
        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing

        objCon.Close()
        objCon.ClearPool()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      objCon = Nothing

      Return True
    End Function

    Public Shared Function Permisos_Windows(ByVal vPersonaid As Long, ByRef dtmenu As DataTable, ByRef dtmod_emp As DataTable, ByRef dtotros As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vcodigo integer, vmovimiento integer, vmodulo integer
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("basic.papermisos_menu_window_leer_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vPersonaid
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtmenu, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtmod_emp, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtotros, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
        objCon.ClearPool()
      Finally
        CType(objCon, IDisposable).Dispose()
        objCon = Nothing
      End Try
      Return True
    End Function

        Public Shared Function Datos_Ventana_RegisVentas(ByVal Codigo_IdPersona As Long,
                                                         ByRef tabla As DataTable, ByRef idtabla As DataTable, ByRef mes As DataTable,
                                                        ByRef año As DataTable)
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim ObjParam As NpgsqlParameter
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("contable.registro_venta", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                ObjParam = New NpgsqlParameter
                ObjParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                ObjParam.Size = 4
                ObjParam.ParameterName = "codigo_per"
                ObjParam.Value = Codigo_IdPersona
                objCmd.Parameters.Add(ObjParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(tabla, objReader)
                objReader.NextResult()

                dar.FillFromReader(idtabla, objReader)
                objReader.NextResult()

                dar.FillFromReader(mes, objReader)
                objReader.NextResult()

                dar.FillFromReader(año, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()

                objReader.Close()

                CType(objReader, IDisposable).Dispose()
                objCmd = Nothing
                objReader = Nothing
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return True

        End Function







        Public Shared Function Datos_Ventana_Persona(ByVal vPersonaId As Long, ByRef dtRol As DataTable, ByRef dtEstCivil As DataTable,
                                           ByRef dtOtroDoc As DataTable, ByRef dtDpto As DataTable, ByRef dtDireccion As DataTable,
                                           ByRef dtTpTelefono As DataTable, ByRef dtTelefono As DataTable, ByRef dtTipoEmail As DataTable,
                                           ByRef dtEmail As DataTable, ByRef dtTipoRedes As DataTable, ByRef dtRedes As DataTable, ByRef dtDatos As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("basic.paventana_persona_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersonaid"
        objParam.Value = vPersonaId
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtRol, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtEstCivil, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtOtroDoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDpto, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDireccion, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTpTelefono, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTelefono, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTipoEmail, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtEmail, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTipoRedes, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtRedes, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDatos, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Importacion(ByVal vCodigo_Movimiento As Integer, ByVal vModulo As Integer,
                                                      ByRef dtDocumento As DataTable, ByRef dtAduana As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_importacion_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vmovimiento"
        objParam.Value = vCodigo_Movimiento
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vmodulo"
        objParam.Value = vModulo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtAduana, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Ing_Mer_Edit(ByVal vCodigo As Long, ByVal vMov As Integer, ByVal vModulo As Long,
                                                      ByRef dtDoc As DataTable, ByRef dtCab As DataTable, ByRef dtDet As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vcodigo integer, vmovimiento integer, vmodulo integer
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paingreso_mercaderia_getrow", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vmov"
        objParam.Value = vMov
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vmod"
        objParam.Value = vModulo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtCab, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDet, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Venta_Cancela_pc(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                  ByVal vCaja As String, ByVal vDocLegal As Boolean,
                                                  ByRef dtDocumento As DataTable,
                                                  ByVal dtTP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paventana_cancela_inicializa_pc", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
        objParam.Size = 2
        objParam.ParameterName = "vdoclegal"
        objParam.Value = vDocLegal
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Venta_Cancela_pp(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                           ByVal vCaja As String, ByVal vDocLegal As Boolean,
                                           ByRef dtLote As DataTable,
                                           ByVal dtTP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paventana_cancela_inicializa_pp", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
        objParam.Size = 2
        objParam.ParameterName = "vdoclegal"
        objParam.Value = vDocLegal
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtLote, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtTP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Venta(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                  ByVal vCaja As String, ByVal vFrm As String,
                                                  ByRef dtDoc As DataTable, ByRef dtDoc_Dzmo As DataTable,
                                                  ByRef dtFP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_venta_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "frm"
        objParam.Value = vFrm
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDoc_Dzmo, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtFP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Anticipos(ByVal vAlmacen As Integer, ByVal vUsuario As Long, ByVal vCaja As String,
                                                    ByRef dtDoc As DataTable, ByRef dtFP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paventana_inicializa_anticipo", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtFP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Boleteo_Colp(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                        ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                        ByRef dtDoc_Dzmo As DataTable, ByRef dtFP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_venta_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDoc_Dzmo, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtFP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_NC_Colp(ByVal vAlmacen As Integer, ByVal vCliente As Long, ByVal vventaid As Long, ByVal vUsuario As Long,
                                                ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                ByRef dtDoc_Dzmo As DataTable, ByRef dtSaldos As DataTable,
                                                ByRef dtCab As DataTable, ByRef dtVenta As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_notacredito_colp_ini", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersona"
        objParam.Value = vCliente
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vventaid"
        objParam.Value = vventaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDoc_Dzmo, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtSaldos, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtCab, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Web_NC_Colp(ByVal vAlmacen As Integer, ByVal vCliente As Long, ByVal vventaid As Long, ByVal vDevolucionId As Long, ByVal vUsuario As Long,
                                                      ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                      ByRef dtDoc_Dzmo As DataTable, ByRef dtSaldos As DataTable,
                                                      ByRef dtCab As DataTable, ByRef dtVenta As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_notacredito_colp_webini", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        'objParam = New NpgsqlParameter
        'objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        'objParam.Size = 4
        'objParam.ParameterName = "vpersona"
        'objParam.Value = vCliente
        'objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vventaid"
        objParam.Value = vventaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vdevolucionid"
        objParam.Value = vDevolucionId
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDoc_Dzmo, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtSaldos, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtCab, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Web_Dev_Asis(ByVal vAlmacen As Integer, ByVal vAsistenteid As Long, ByVal vDevolucionid As Long, ByVal vUsuario As Long,
                                                      ByVal vCaja As String, ByRef dtDocumento As DataTable, ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("colportaje.paventana_devolucion_consig_ini", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vDevolucionid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vasistente"
        objParam.Value = vAsistenteid
        objCmd.Parameters.Add(objParam)



        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Liquidacion_VIP(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                            ByVal vCaja As String, ByVal vCodigo_Ref As Long, ByRef dtDocumento As DataTable,
                                                            ByRef dtGp As DataTable, ByRef dtFP As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_venta_liquidacion_vip", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo_ref"
        objParam.Value = vCodigo_Ref
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtGp, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtFP, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Venta_NC(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                  ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                  ByRef dtRef As DataTable, ByRef dtSaldos As DataTable, ByRef dtVenta As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_venta_ini_nc", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtRef, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtSaldos, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Compra_NC(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                      ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                      ByRef dtVenta As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_ingreso_ini_nc", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Venta_Guia(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                       ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                       ByRef dtVenta As DataTable, ByVal dtVenta_Det As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("paventana_venta_guia_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtVenta_Det, objReader)
        objReader.NextResult()


        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Salida(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                   ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                   ByRef dtAlm_Dest As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paventana_salida_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtAlm_Dest, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_PorCobrar(ByVal vAlmacen As Integer, ByVal vUsuario As Long,
                                                      ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                      ByRef dtCC As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paventana_porcobrar_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtCC, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Venta(ByVal vCodigo As Long, ByRef dtCabecera As DataTable,
                                                ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paimprimir_venta_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Venta_PWC(ByVal vCodigo As Long, ByVal vAlmacenid As Integer, ByRef dtCabecera As DataTable,
                                                    ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paimprimir_venta_pwcolp_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacenid"
        objParam.Value = vAlmacenid
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Guia(ByVal vCodigo As Long, ByRef dtCabecera As DataTable,
                                                    ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("colportaje.paimprimir_guia_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_MB(ByVal vCodigo As Long, ByRef dtCabecera As DataTable,
                                        ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paimprimir_mb_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_MB_Ing(ByVal vCodigo As Long, ByRef dtCabecera As DataTable,
                                                    ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paimprimir_mb_cursor_ing", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Anticipos_Fact(ByVal vCodigo As Long, ByVal vAlmacenid As Integer, ByVal vTipoId As Integer, ByVal vPeriodo As String,
                                                         ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vCodigo integer, valmacenid integer, vtipoid integer, vperiodo
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paimprimir_anticipos_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo"
        objParam.Value = vCodigo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacenid"
        objParam.Value = vAlmacenid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vtipoid"
        objParam.Value = vTipoId
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vperiodo"
        objParam.Value = vPeriodo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Suscripciones_Vta(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer,
                                                             ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String,
                                                             ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String,
                                                             ByVal vDMid As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paimprimir_venta_sus_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacenid"
        objParam.Value = vAlmacenid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "viglesiaid"
        objParam.Value = vIglesiaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vperiodoid"
        objParam.Value = vPeriodoid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersonaid"
        objParam.Value = vPersonaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vdocumentoid"
        objParam.Value = vDocumentoid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vdesde"
        objParam.Value = vDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vhasta"
        objParam.Value = vDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vnumdesde"
        objParam.Value = vNumDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vnumhasta"
        objParam.Value = vNumHasta
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vdmid"
        objParam.Value = vDMid
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Imprimir_Pedido_Vta(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer,
                                                     ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String,
                                                     ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String,
                                                     ByVal vDMid As Long, ByVal vUnidadId As Integer, ByVal vTipo As String,
                                                     ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("inventarios.paimprimir_venta_pedido_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacenid"
        objParam.Value = vAlmacenid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "viglesiaid"
        objParam.Value = vIglesiaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vperiodoid"
        objParam.Value = vPeriodoid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersonaid"
        objParam.Value = vPersonaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vdocumentoid"
        objParam.Value = vDocumentoid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vdesde"
        objParam.Value = vDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vhasta"
        objParam.Value = vDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vnumdesde"
        objParam.Value = vNumDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vnumhasta"
        objParam.Value = vNumDesde
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vdmid"
        objParam.Value = vDMid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vunidadid"
        objParam.Value = vUnidadId
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 20
        objParam.ParameterName = "vtipo"
        objParam.Value = vTipo
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Plan_cta(ByVal vEntidad As Long, ByRef dtPlan As DataTable,
                                            ByRef dtCtaCte As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paplan_cta_cursor", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "ventidad"
        objParam.Value = vEntidad
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtPlan, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtCtaCte, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Datos_Ventana_Suscripcion(ByVal vPeriodo As Long, ByVal vUnidadId As Long,
                                                     ByRef dtDM As DataTable, ByRef dtIglesias As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      Dim oOk As Boolean = False
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("suscripcion.paventana_suscripcion_inicializa", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vperiodo"
        objParam.Value = vPeriodo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vunidad"
        objParam.Value = vUnidadId
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDM, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtIglesias, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()
        oOk = True
        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()

      End Try
      Return oOk
    End Function

    Public Shared Function Datos_Ventana_Dep_Colp_Web(ByVal vAlmacen As Integer, ByVal vPersonaid As Long, ByVal vUsuario As Long,
                                                             ByVal vCaja As String, ByRef dtDocumento As DataTable, ByRef dtSaldos As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("colportaje.paventana_deposito_web_ini", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vcodigo_alm"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersonaid"
        objParam.Value = vPersonaid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vcaja"
        objParam.Value = vCaja
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDocumento, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtSaldos, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

  End Class
End Namespace
