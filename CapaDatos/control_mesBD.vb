Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
Public Class control_mesBD
        Public Shared Function GetItem(ByVal valmacenid As Integer, ByVal vmes As Integer, ByVal vanio As Integer) As control_mes
            Dim objcontrol_mes As control_mes = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("pacontrol_mes_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP.addParameter("inalmacenid", valmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objcontrol_mes = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objcontrol_mes
        End Function

        Public Shared Function Cierre_Mes(ByVal vUnidad As Integer, ByVal vmes As Integer, ByVal vAnio As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("pacierre_mes")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inalmacenid", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Aperturar_Mes(ByVal vUnidad As Integer, ByVal vmes As Integer, ByVal vAnio As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paaperturar_mes")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inalmacenid", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As control_mes
           Dim objeto As control_mes  = New control_mes
	         Objeto.mes = objData.Item("mes")
	         Objeto.anio = objData.Item("anio")
	         Objeto.cerrado = objData.Item("cerrado")
           Return objeto
        End Function

        Public Shared Function Grabar(ByRef objcontrol_mes As control_mes) As DataTable
           Dim oSP As New clsStored_Procedure("pacontrol_mes_actualizar")
           Try
               If objcontrol_mes.mes = -1 Then
               oSP.addParameter("innew", True,NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
               Else
               oSP.addParameter("innew", False,NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
               End If
               oSP.addParameter("inmes", objcontrol_mes.mes, NpgsqlTypes.NpgsqlDbType.Integer,4,ParameterDirection.Input)

               oSP.addParameter("inanio", objcontrol_mes.anio, NpgsqlTypes.NpgsqlDbType.Integer,4,ParameterDirection.Input)

               oSP.addParameter("incodigo_uni", objcontrol_mes.codigo_uni, NpgsqlTypes.NpgsqlDbType.Integer,4,ParameterDirection.Input)

               oSP.addParameter("inapertura", objcontrol_mes.apertura, NpgsqlTypes.NpgsqlDbType.date,4,ParameterDirection.Input)

               oSP.addParameter("incierre", objcontrol_mes.cierre, NpgsqlTypes.NpgsqlDbType.date,4,ParameterDirection.Input)

               oSP.addParameter("inusuario_a", objcontrol_mes.usuario_a, NpgsqlTypes.NpgsqlDbType.varchar,20,ParameterDirection.Input)

               oSP.addParameter("inusuario_b", objcontrol_mes.usuario_b, NpgsqlTypes.NpgsqlDbType.varchar,20,ParameterDirection.Input)

               oSP.addParameter("incaja_a", objcontrol_mes.caja_a, NpgsqlTypes.NpgsqlDbType.varchar,50,ParameterDirection.Input)

               oSP.addParameter("incaja_b", objcontrol_mes.caja_b, NpgsqlTypes.NpgsqlDbType.varchar,50,ParameterDirection.Input)

               oSP.addParameter("incerrado", objcontrol_mes.cerrado, NpgsqlTypes.NpgsqlDbType.Boolean,1,ParameterDirection.Input)

               Dim oConexion As New clsConexion
               Grabar = oConexion.Ejecutar_Consulta(oSP)
               oConexion.Cerrar_Conexion()
               oConexion = Nothing
               Finally
               oSP = Nothing
               End Try
        End Function

        Public Shared Function Cerrar_Aperturar(ByRef objcontrol_mes As control_mes) As DataTable
            Dim oSP As New clsStored_Procedure("pacontrol_mes_cerrar_aperturar")
            Try
                oSP.addParameter("inmes", objcontrol_mes.mes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inanio", objcontrol_mes.anio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_uni", objcontrol_mes.codigo_uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("infecha", objcontrol_mes.apertura, NpgsqlTypes.NpgsqlDbType.Date, 4, ParameterDirection.Input)

                oSP.addParameter("inusuario", objcontrol_mes.usuario_a, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("incaja", objcontrol_mes.caja_a, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Cerrar_Aperturar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vMes As Long, ByVal vAnio As Long, ByVal vUnidad As Long) As DataTable
            Dim oSP As New clsStored_Procedure("pacontrol_mes_eliminar")
            Try
                oSP.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("incodigo_uni", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
