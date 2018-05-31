Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class plan_cuentasBD
        Public Shared Function GetItem(ByVal codigo As Long) As plan_cuentas
            Dim objplan_cuentas As plan_cuentas = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paplan_cuentas_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objplan_cuentas = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objplan_cuentas
        End Function

        Public Shared Function GetRow(ByVal ctaMaestra As String, ByVal descripcion As String, ByVal xLimit As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paplan_cuentas_get")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inctamaestra", ctaMaestra, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inlimit", xLimit, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Plan_GetList(ByVal cuenta As Long, ByVal nombre As String, ByVal restrincode As String, ByVal xlimit As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paplan_cuenta_consulta")
            Dim oConexion As New clsConexion
            Try
                'finanzas.paplan_cuenta_consulta(cuenta integer, nombre varchar, restrincode varchar, xlimit integer)
                oSP.addParameter("incuenta", cuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inrestrincode", restrincode, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("inlimit", xlimit, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function PlanCtaCte_GetList(ByVal vEntidad As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.paplan_ctacte_consulta")
      Dim oConexion As New clsConexion
      Try
        'finanzas.paplan_cuenta_consulta(cuenta integer, nombre varchar, restrincode varchar, xlimit integer)
        oSP.addParameter("inentidad", vEntidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function PlanCtaCte_GetList(ByVal vEntidad As Long, ByVal vTipo As String, ByVal vNombre As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.paplan_ctacte_consulta")
      Dim oConexion As New clsConexion
      Try
        'finanzas.paplan_cuenta_consulta(cuenta integer, nombre varchar, restrincode varchar, xlimit integer)
        oSP.addParameter("inentidad", vEntidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList(ByVal ctaMaestra As String, ByVal descripcion As String, ByVal xLimit As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("contable.paplan_cuentas_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inctamaestra", ctaMaestra, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inlimit", xLimit, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As plan_cuentas
            Dim objeto As plan_cuentas = New plan_cuentas
            objeto.codigo = objData.Item("codigo")
            objeto.cuenta = objData.Item("cuenta")
            objeto.ctacte = IIf(IsDBNull(objData.Item("ctacte")), 0, objData.Item("ctacte"))
            objeto.sct = IIf(IsDBNull(objData.Item("sct")), 0, objData.Item("sct"))
            objeto.nombrecta = objData.Item("nombrecta")
            objeto.ctamaestra = objData.Item("ctamaestra")
            objeto.nivel = objData.Item("nivel")
            objeto.abrev = objData.Item("abrev")
            objeto.entidad = objData.Item("entidad")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objplan_cuentas As plan_cuentas) As DataTable
            Dim oSP As New clsStored_Procedure("paplan_cuentas_actualizar")
            Try
                If objplan_cuentas.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objplan_cuentas.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incuenta", objplan_cuentas.cuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inctacte", IIf(objplan_cuentas.ctacte > 0, objplan_cuentas.ctacte, DBNull.Value), NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("insct", IIf(objplan_cuentas.sct > 0, objplan_cuentas.sct, DBNull.Value), NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombrecta", objplan_cuentas.nombrecta, NpgsqlTypes.NpgsqlDbType.Varchar, 250, ParameterDirection.Input)

                oSP.addParameter("inctamaestra", objplan_cuentas.ctamaestra, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("innivel", objplan_cuentas.nivel, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inabrev", objplan_cuentas.abrev, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("inestado", True, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                oSP.addParameter("inentidad", objplan_cuentas.entidad, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("paplan_cuentas_eliminar")
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


        '========================Gestion Plan Cta Cte=========================================
        Public Shared Function Agregar_CtaCte(ByRef vEntidad As Long, ByVal myArr As String, ByVal vUsuarioId As Long, ByVal vCaja As String) As DataTable
            Dim vCadena As String = ""
            'contable.paplan_ctacte_actualizar(inentidad integer, myarr character varying[], inusuarioid integer, incaja character varying)
            Try

                vCadena = "select * from contable.paplan_ctacte_actualizar("
                vCadena = vCadena & " " & Trim(Str(vEntidad)) & ","

                vCadena = vCadena & " " & Trim(myArr) & ","

                vCadena = vCadena & " " & Trim(Str(vUsuarioId)) & ","

                vCadena = vCadena & " '" & Trim(vCaja) & "');"

                Dim oConexion As New clsConexion
                Agregar_CtaCte = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function


    End Class
End Namespace
