Imports Npgsql
Imports System.Configuration
Imports System.Data
Imports CapaObjetosNegocio.BO

Public Class clsConexion
  Public pConexion As NpgsqlConnection
  Private Shared objCon As NpgsqlConnection

  Sub New()
    Try
      'Me.pConexion = New NpgsqlConnection
      Me.pConexion = New NpgsqlConnection
      Dim Cadena As String
      Cadena = pCadena()

      Me.pConexion.ConnectionString = Cadena '"server=localhost;Port=5433;database=nt;user id=postgres;password=postgres"
      'Driver={PostgreSQL};Server=IP address;Port=5432;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
      Me.pConexion.Open()

    Catch ex As Exception
      MsgBox("Error al intentar conectarse a la base de datos: " & ex.Message, MsgBoxStyle.Information, ex.Source)
    End Try
  End Sub

  Public Shared ReadOnly Property ObtenerConexion() As NpgsqlConnection
    Get
      If Not IsNothing(objCon) Then
        If objCon.ConnectionString = "" Then
          If objCon.State = ConnectionState.Open Then
            Return objCon
          Else
            Return abrirconexion()
          End If
        Else
          Return abrirconexion()
        End If
      Else
        Return abrirconexion()
      End If
    End Get
  End Property

  Private Shared Function abrirconexion() As NpgsqlConnection
    'objCon = New NpgsqlConnection(ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString)
    Dim vCadena As String
    vCadena = pCadena()
    If IsNothing(objCon) Then
      objCon = New NpgsqlConnection(vCadena)
      objCon.Open()
    Else
      If Not objCon.State = ConnectionState.Open Then
        objCon.ClearPool()
        objCon = New NpgsqlConnection(vCadena)
        objCon.Open()
      End If
    End If
    Return objCon
  End Function

  Private Shared Function pCadena() As String
    Dim Cadena As String = ""


        'Cadena = ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
        'Cadena = "Server=sehs.org.pe;Port=5432;Database=sehsorgp_sehssur;Uid=sehsorgp;Pwd=e8TDKURoR4;"
        'Cadena = "Server=sehs.org.pe;Port=5432;Database=sehsorgp_sehssur2;Uid=sehsorgp;Pwd=e8TDKURoR4;"

        'Cadena = "Server=10.71.15.3;Port=5432;Database=nuevotiempo;Uid=postgres;Pwd=1234;"
        'Cadena = "Server=localhost;Port=5432;Database=edicas;Uid=postgres;Pwd=postgres;"
        'Cadena = "Server=localhost;Port=5432;Database=norte;Uid=postgres;Pwd=postgres;CommandTimeout=0; pooling=false;"
        'Cadena = "Server=localhost;Port=5432;Database=nt;Uid=postgres;Pwd=postgres;CommandTimeout=0; pooling=false;"
        'Cadena = "Server=sehs.org.pe;Port=5432;Database=sehsorgp_copy;Uid=sehsorgp;Pwd=e8TDKURoR4;"

        Cadena = "Server=localhost;Port=5432;Database=sehs8;Uid=postgres;Pwd=postgres;CommandTimeout=0; pooling=false;"

        Return Cadena
  End Function

  Public Shared Function cerrarconexion() As Boolean
    If objCon.State = ConnectionState.Open Then
      'objCon.Close()
      Return True
    End If
  End Function

  Public Function Ejecutar_Consulta(ByVal vConsulta As String) As DataTable
    Try
      'Dim oAdapter As NpgsqlDataAdapter
      Dim oAdapter As NpgsqlDataAdapter
      Dim oDataSet As DataSet

      oAdapter = New NpgsqlDataAdapter(vConsulta, pConexion)

      oDataSet = New DataSet
      oAdapter.Fill(oDataSet, "myRecordset")
      Ejecutar_Consulta = oDataSet.Tables("myRecordset")

    Catch ex As Exception
      MsgBox("Error al ejecutar la consulta: " & ex.Message, MsgBoxStyle.Information, ex.Source)
      Ejecutar_Consulta = Nothing
    End Try
  End Function

  Public Function ConsultarPA(ByVal objSP As clsStored_Procedure) As DataTable
    Try
      Dim oDataT As New DataTable
      Dim oCmd As New NpgsqlCommand(objSP.pNombre, Me.pConexion)
      Dim oPrm As clsParameter
      Dim miParametro As NpgsqlParameter

      oCmd.CommandType = CommandType.StoredProcedure
      For Each oPrm In objSP.pParametros
        miParametro = New NpgsqlParameter(oPrm.pNombre, oPrm.pTipo_Dato)
        miParametro.Value = oPrm.pValor
        miParametro.Direction = oPrm.pDireccion
        oCmd.Parameters.Add(miParametro)
      Next

      Dim oAdapter As New NpgsqlDataAdapter(oCmd)
      oAdapter.Fill(oDataT)
      ConsultarPA = oDataT
      oAdapter = Nothing

      miParametro = Nothing
      oPrm = Nothing
      oCmd = Nothing

    Catch ex As Exception
      MsgBox("Error al ejecutar el procedimiento almacenado: " & ex.Message, MsgBoxStyle.Information, ex.Source)
      ConsultarPA = Nothing
    End Try
  End Function

  Public Function Ejecutar_Consulta(ByVal objSP As clsStored_Procedure) As DataTable
    Try
      Dim oDataSet As New DataSet
      Dim oCmd As New NpgsqlCommand(objSP.pNombre, Me.pConexion)
      Dim oPrm As clsParameter
      Dim miParametro As NpgsqlParameter

      oCmd.CommandType = CommandType.StoredProcedure
      For Each oPrm In objSP.pParametros
        miParametro = New NpgsqlParameter(oPrm.pNombre, oPrm.pTipo_Dato)
        miParametro.Value = oPrm.pValor
        miParametro.Direction = oPrm.pDireccion
        oCmd.Parameters.Add(miParametro)
      Next

      Dim oAdapter As New NpgsqlDataAdapter(oCmd)
      oAdapter.Fill(oDataSet)
      Ejecutar_Consulta = oDataSet.Tables(0)
      oAdapter = Nothing

      miParametro = Nothing
      oPrm = Nothing
      oCmd = Nothing
      oDataSet = Nothing

    Catch ex As Exception
      MsgBox("Error al ejecutar el procedimiento almacenado: " & ex.Message, MsgBoxStyle.Information, ex.Source)
      Ejecutar_Consulta = Nothing
    End Try
  End Function

  Public Sub Cerrar_Conexion()
    If Not Me.pConexion Is Nothing Then
      'If Me.pConexion.State = ConnectionState.Open Then
      Me.pConexion.Close()
      Me.pConexion.ClearPool()
      'End If
    End If
  End Sub

  Protected Overrides Sub Finalize()
    Me.pConexion = Nothing
  End Sub
End Class
