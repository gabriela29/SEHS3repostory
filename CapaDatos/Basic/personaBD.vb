Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class personaBD

        Public Shared Function GetItem(ByVal vPersonaId As Long) As persona
            Dim objpersona As persona = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.papersona_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing
            Try
                oSP.addParameter("inpersonaid", vPersonaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)

                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If

                Try
                    If Not objReader Is Nothing Then
                        objpersona = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objpersona
        End Function

        Public Shared Function GetList(ByVal vapepat As String, ByVal vapemat As String, ByVal vnombre As String, ByVal vproceso As String,
                                        ByVal varrrol As String, ByVal vfilas As Long, ByVal vpersonaid As Long) As DataTable
            Dim TempList As New DataTable
            Dim vConsulta As String
            Dim oConexion As New clsConexion
            'basic.papersona_consulta(vapepat character varying, vapemat character varying, vnombre character varying, vproceso character varying, arrrol integer[], vfilas integer, vpersonaid integer)
            Try
                vConsulta = "select * from basic.papersona_consulta ( "
                vConsulta = vConsulta & " '" & vapepat & "',"
                vConsulta = vConsulta & " '" & vapemat & "',"
                vConsulta = vConsulta & " '" & vnombre & "',"
                vConsulta = vConsulta & " '" & vproceso & "',"
                vConsulta = vConsulta & " " & IIf(varrrol.Trim = "", "null", varrrol) & ","
                vConsulta = vConsulta & " " & vfilas & ","
                vConsulta = vConsulta & " " & vpersonaid & ");"

                TempList = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As persona
            Dim objeto As persona = New persona

            objeto.personaid = objData.Item("personaid")
            objeto.tipo = objData.Item("tipo")
            objeto.rol = objData.Item("rol")
            objeto.direccion = objData.Item("direccion")
            objeto.telefono = objData.Item("telefono")
            objeto.email = objData.Item("email")
            objeto.estado = objData.Item("estado")
            objeto.registro = objData.Item("registro")
            objeto.distritoid = objData.Item("distritoid")
            objeto.foto = objData.Item("foto")
            objeto.nombre_comercial = objData.Item("nombre_comercial")
            objeto.titulo = objData.Item("titulo")
            objeto.ape_pat = objData.Item("ape_pat")
            objeto.ape_mat = objData.Item("ape_mat")
            objeto.nombre = objData.Item("nombre")
            objeto.nacimiento = IIf(IsDBNull(objData.Item("nacimiento")), "", objData.Item("nacimiento"))
            objeto.dni = objData.Item("dni")
            objeto.pernat_ruc = objData.Item("pernat_ruc")
            objeto.sexo = objData.Item("sexo")
            objeto.est_civil = objData.Item("est_civil")
            objeto.raz_soc = objData.Item("raz_soc")
            objeto.ruc = objData.Item("ruc")
            objeto.departamentoid = objData.Item("departamentoid")
            objeto.provinciaid = objData.Item("provinciaid")
            objeto.departamento_nombre = objData.Item("departamento_nombre")
            objeto.provincia_nombre = objData.Item("provincia_nombre")
            objeto.distrito_nombre = objData.Item("distrito_nombre")
            objeto.ape_pat_mayus = objData.Item("ape_pat_mayus")
            objeto.ape_mat_mayus = objData.Item("ape_mat_mayus")
            objeto.nombre_mayus = objData.Item("nombre_mayus")
            objeto.ape_pat_ab = objData.Item("ape_pat_ab")
            objeto.ape_mat_ab = objData.Item("ape_mat_ab")
            objeto.nombre_ab = objData.Item("nombre_ab")

            Return objeto
        End Function

        Public Shared Function Datos_Persona_Basic(ByVal vTipo As String, ByVal vNroDoc As String, ByVal vpersona As Long) As persona
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.papersona_consulta_basico")
            Dim oConexion As New clsConexion
            Dim objpersona As persona = Nothing
            Dim myRs As New DataTable
            Dim objReader As DataRow

            Try
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 5, ParameterDirection.Input)
                oSP.addParameter("vnrodoc", vNroDoc, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                myRs = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If Not myRs Is Nothing Then
                    If myRs.Rows.Count > 0 Then
                        objReader = myRs.Rows(0)
                    End If
                End If
                If Not objReader Is Nothing Then
                    objpersona = LlenarDatosRegistroB(objReader)
                End If
            Finally
                objReader = Nothing
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return objpersona
        End Function

        Public Shared Function Datos_Persona_Colportaje(ByVal vTipo As String, ByVal vAlmacenId As Integer, ByVal vPersonaID As Long, ByVal vNroDoc As String) As persona
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.papersona_consulta_basico")
            Dim oConexion As New clsConexion
            Dim objpersona As persona = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow

            Try
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("valmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersonaid", vPersonaID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnrodoc", vNroDoc, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                myRs = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If Not myRs Is Nothing Then
                    If myRs.Rows.Count > 0 Then
                        objReader = myRs.Rows(0)
                    End If
                End If
                If Not objReader Is Nothing Then
                    objpersona = LlenarDatosRegistroB(objReader)
                End If
            Finally
                objReader = Nothing
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return objpersona
        End Function

        Private Shared Function LlenarDatosRegistroB(ByVal objData As DataRow) As persona
            Dim objeto As persona = New persona
            objeto.personaid = objData.Item("personaid")
            objeto.tipo = objData.Item("tipo")
            objeto.ape_pat = objData.Item("ape_pat")
            objeto.ape_mat = objData.Item("ape_mat")
            objeto.nombre = objData.Item("nombre")
            objeto.raz_soc = objData.Item("raz_soc")
            objeto.direccion = objData.Item("direccion")
            objeto.ruc = objData.Item("ruc")
            objeto.dni = objData.Item("dni")
            objeto.distritoid = objData.Item("distritoid")
            objeto.nrolicencia = objData.Item("nrolicencia") & ""

            objeto.nrolicencia = objData.Item("nrolicencia") & ""
            objeto.nrocuenta = objData.Item("nrocuenta") & ""
            objeto.c_costo = objData.Item("c_costo") & ""
            objeto.codio_Asis = objData.Item("asistenteid")
            objeto.saldo = objData.Item("saldo")
            Return objeto

        End Function


        Public Shared Function Actualizar(ByVal objP As persona, ByVal varrphone As String, ByVal varremail As String,
                                          ByVal varrsocialmedia As String, ByVal varrrol As String, ByVal varrdireccion As String) As DataTable
            Dim vCadena As String = ""

            Try

                vCadena = "select * from basic.papersona_actualizar( "
                vCadena = vCadena & " " & IIf(objP.personaid > 0, "false", "true") & ", "
                vCadena = vCadena & " " & Trim(Str(objP.personaid)) & ", "
                vCadena = vCadena & " '" & Trim(objP.tipo) & "',"
                vCadena = vCadena & " '" & Trim(objP.titulo) & "',"
                vCadena = vCadena & " '" & Trim(objP.ape_pat) & "',"
                vCadena = vCadena & " '" & Trim(objP.ape_mat) & "',"
                vCadena = vCadena & " '" & Trim(objP.nombre) & "',"
                vCadena = vCadena & " '" & Trim(objP.dni) & "',"
                vCadena = vCadena & " '" & Trim(objP.pernat_ruc) & "',"
                vCadena = vCadena & " '" & Trim(objP.sexo) & "',"
                vCadena = vCadena & " '" & Trim(objP.est_civil) & "',"
                vCadena = vCadena & " '" & Trim(objP.nacimiento) & "',"
                vCadena = vCadena & " '" & Trim(objP.raz_soc) & "',"
                vCadena = vCadena & " '" & Trim(objP.ruc) & "',"
                vCadena = vCadena & " '" & Trim(objP.direccion) & "',"
                vCadena = vCadena & " '" & Trim(objP.foto) & "',"
                vCadena = vCadena & " '" & Trim(objP.nombre_comercial) & "',"
                vCadena = vCadena & " " & Trim(Str(objP.distritoid)) & ", "
                vCadena = vCadena & " " & Trim(varrphone) & ", "
                vCadena = vCadena & " " & Trim(varremail) & ", "
                vCadena = vCadena & " " & Trim(varrsocialmedia) & ", "
                vCadena = vCadena & " " & Trim(varrrol) & ", "
                vCadena = vCadena & " " & Trim(varrdireccion) & ", "
                vCadena = vCadena & " " & Trim(Str(objP.usuarioid)) & ", "
                vCadena = vCadena & " '" & Trim(objP.ip) & "' "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Actualizar_Basic(ByVal objP As persona, ByVal vrol As Integer) As DataTable
            Dim vCadena As String = ""
            'basic.papersonaid_bydocumento(intipo_per character varying, vrolid integer, indni character varying, inruc character varying, 
            'inape_pat character varying, inape_mat character varying, innombre character varying, indireccion character varying)
            Try

                vCadena = "select * from basic.papersonaid_bydocumento( "

                vCadena = vCadena & " '" & Trim(objP.tipo) & "',"
                vCadena = vCadena & " " & Trim(Str(vrol)) & ","
                vCadena = vCadena & " '" & Trim(objP.dni) & "',"
                vCadena = vCadena & " '" & Trim(objP.ruc) & "',"
                vCadena = vCadena & " '" & Trim(objP.ape_pat) & "',"
                vCadena = vCadena & " '" & Trim(objP.ape_mat) & "',"
                vCadena = vCadena & " '" & Trim(objP.nombre) & "',"
                vCadena = vCadena & " '" & Trim(objP.direccion) & "' "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                Actualizar_Basic = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Actualizar_Linea_Credito(ByVal vAlmaceid As Integer, ByVal vPersonaid As Long, ByVal vImporte As Single) As DataTable
            Dim vCadena As String = ""
            'basic.papersonaid_bydocumento(intipo_per character varying, vrolid integer, indni character varying, inruc character varying, 
            'inape_pat character varying, inape_mat character varying, innombre character varying, indireccion character varying)
            Try

                vCadena = "select * from finanzas.papersona_limite_credito_actualizar( "
                vCadena = vCadena & " " & Trim(Str(vAlmaceid)) & ","
                vCadena = vCadena & " " & Trim(Str(vPersonaid)) & ","
                vCadena = vCadena & " " & Trim(Str(vImporte)) & " "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                Actualizar_Linea_Credito = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vPersonaId As Long, ByVal vUsuario As Long, ByVal vIp As String) As DataTable
            'basic.papersona_eliminar(vpersonaid integer, vusuario integer, vip character varying)
            Dim vCadena As String = ""

            Try

                vCadena = "select * from basic.papersona_eliminar( "
                vCadena = vCadena & " " & Trim(Str(vPersonaId)) & ", "
                vCadena = vCadena & " " & Trim(vUsuario) & ", "
                vCadena = vCadena & " '" & Trim(vIp) & "');"

                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Persona_Direccion_Actualizar(ByVal vPDId As Long, ByVal vpersonaid As Long, ByVal vSucursal As String, ByVal vDireccion As String) As DataTable
            Dim TempList As New DataTable
            Dim vCadena As String
            Dim oConexion As New clsConexion
            'basic.papersona_direccion_actualizar(innew boolean, inpersonadireccionid integer, inpersonaid integer, insucursal character varying, indireccion character varying)
            Try
                vCadena = "select * from basic.papersona_direccion_actualizar ( "
                vCadena = vCadena & " " & IIf(vPDId > 0, "false", "true") & ", "
                vCadena = vCadena & " " & Trim(Str(vPDId)) & ", "
                vCadena = vCadena & " " & Trim(Str(vpersonaid)) & ", "
                vCadena = vCadena & " '" & Trim(vSucursal) & "',"
                vCadena = vCadena & " '" & Trim(vDireccion) & "'"
                vCadena = vCadena & ");"

                TempList = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Direccion(ByVal vpersonaid As Long) As DataTable
            Dim TempList As New DataTable
            Dim vConsulta As String
            Dim oConexion As New clsConexion

            Try
                vConsulta = "select * from basic.papersona_direccion_leer ( "
                vConsulta = vConsulta & " " & vpersonaid & ");"

                TempList = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
            End Try
            Return TempList
        End Function
    End Class

End Namespace