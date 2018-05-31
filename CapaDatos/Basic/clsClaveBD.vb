Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports System.Text
Imports System.Security.Cryptography
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class ClaveBD
        Public Shared Function GetItem(ByVal vUsuario As String, ByVal vCodigo As String) As Long
            Dim objpersona As clave = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow
            Dim oConexion As New clsConexion
            Dim vNewClave As String, vCadena As String
            Dim NvCodigo As Long = 0
            vNewClave = GenerarMD5(vCodigo)
            vCadena = "select p.personaid,p.tipo,p.direccion,pn.dni,pn.ruc,''::varchar as telefono,c.usuario,p.rol, "
            vCadena = vCadena & "(coalesce(ape_pat,'') || ' ' || coalesce(ape_mat,'') || ' '  || coalesce(nombre,''))::varchar as nombre_persona "
            vCadena = vCadena & "from basic.persona p inner join basic.clave c on p.personaid=c.personaid  "
            vCadena = vCadena & "inner join basic.persona_natural pn on p.personaid=pn.personaid "
            vCadena = vCadena & "where estado = True And c.usuario ='" & Trim(vUsuario) & "'"
            vCadena = vCadena & " and c.clave='" & vNewClave & "' limit 1"

            myRs = oConexion.Ejecutar_Consulta(vCadena)

            Try
                objReader = Nothing
                If myRs.Rows.Count > 0 Then
                    NvCodigo = myRs.Rows(0).Item(0)
                End If

            Catch ex As Exception
                Exit Try
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return NvCodigo
        End Function

        Public Shared Function GenerarHash(ByVal Texto As String) As String
            'Creamos un objeto de codificación Unicode que
            'representa una codificación UTF-16 de caracteres Unicode. 
            Dim Codificar As New UnicodeEncoding()
            'Declaramos una matriz (array) de tipo Byte para recuperar dentro los bytes del texto
            'utilizando el objeto Codificar
            Dim ByteTexto() As Byte = Codificar.GetBytes(Texto)
            'Instanciamos el objeto MD5 
            Dim Md5 As New MD5CryptoServiceProvider()
            'Se calcula el Hash del Texto en bytes 
            Dim ByteHash() As Byte = Md5.ComputeHash(ByteTexto)
            'convertimos el texto en bytes en texto legible(cadena) 
            Return Convert.ToBase64String(ByteHash)
            'Eliminamos los objetos usados con Nothing
            Codificar = Nothing
            ByteTexto = Nothing
        End Function

        Public Shared Function GenerarMD5(ByVal Texto As String) As String
            Dim MD5 As New Security.Cryptography.MD5CryptoServiceProvider

            Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Texto)

            ByteString = md5.ComputeHash(ByteString)

            Dim FinalString As String = Nothing
            'Se calcula el Hash del Texto en bytes 
            For Each bt As Byte In ByteString
                FinalString &= bt.ToString("x2")
            Next
            Return FinalString
        End Function

        Public Shared Function GetItemUs(ByVal vUsuario As String, ByVal vCodigo As String) As clave
            Dim objC As clave = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow
            Dim oConexion As New clsConexion
            Dim vNewClave As String, vCadena As String
            Dim NvCodigo As Long = 0
            vNewClave = GenerarMD5(vCodigo)
            vCadena = "select p.personaid,p.tipo,p.direccion,pn.dni,pn.ruc,''::varchar as telefono,coalesce(c.usuario,'') as usuario,p.rol, "
            vCadena = vCadena & "(coalesce(ape_pat,'') || ' ' || coalesce(ape_mat,'') || ' '  || coalesce(nombre,''))::varchar as nombre_persona "
            vCadena = vCadena & "from basic.persona p left join basic.clave c on c.personaid=p.personaid "
            vCadena = vCadena & "left join basic.persona_natural pn on pn.personaid=p.personaid "
            vCadena = vCadena & "where estado = True And c.usuario ='" & Trim(vUsuario) & "'"
            vCadena = vCadena & " and c.clave='" & vNewClave & "' limit 1"

            myRs = oConexion.Ejecutar_Consulta(vCadena)

            Try
                objReader = Nothing
                If myRs.Rows.Count > 0 Then
                    objReader = myRs.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objC = LlenarDatosPersona(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try

            Catch ex As Exception
                Exit Try
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return objC
        End Function

        Public Shared Function GetItemUs(ByVal vCodigo As Long) As clave
            Dim objC As clave = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow
            Dim oConexion As New clsConexion
            Dim vNewClave As String, vCadena As String
            Dim NvCodigo As Long = 0
            vNewClave = GenerarMD5(vCodigo)
            vCadena = "select p.personaid,p.tipo,p.direccion,pn.dni,pn.ruc,''::varchar as telefono,coalesce(c.usuario,'') as usuario,p.rol, "
            vCadena = vCadena & "(coalesce(ape_pat,'') || ' ' || coalesce(ape_mat,'') || ' '  || coalesce(nombre,''))::varchar as nombre_persona "
            vCadena = vCadena & "from basic.persona p left join basic.clave c on c.personaid=p.personaid "
            vCadena = vCadena & "left join basic.persona_natural pn on pn.personaid=p.personaid "
            vCadena = vCadena & "where estado = True And p.personaid =" & vCodigo

            myRs = oConexion.Ejecutar_Consulta(vCadena)

            Try
                objReader = Nothing
                If myRs.Rows.Count > 0 Then
                    objReader = myRs.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objC = LlenarDatosPersona(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try

            Catch ex As Exception
                Exit Try
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return objC
        End Function

        Private Shared Function LlenarDatosPersona(ByVal objData As DataRow) As clave
            Dim objeto As clave = New clave
            objeto.codigo = objData.Item("personaid")
            objeto.tipo = objData.Item("tipo")
            objeto.nombre = objData.Item("nombre_persona")
            objeto.usuario = objData.Item("usuario")
            'objeto.codigo_cat = objData.Item("codigo_cat")

            Return objeto
        End Function

        Public Shared Function Actualizar(xNew As Boolean, ByVal objC As clave) As Boolean
            Dim vCadena As String = "", vFree As String = "", xDt As New DataTable
            'inpersonaid, inusuario_nuevo, inclave_nueva, inclave_temporal, inrenovar_clave, intipo_cambio
            Try
                If xNew Then
                    vCadena = "insert into basic.clave values ( "
                    vCadena = vCadena & " " & Trim(Str(objC.codigo)) & ","
                    vCadena = vCadena & " '" & Trim((objC.usuario)) & "',"
                    vCadena = vCadena & " '" & Trim(GenerarMD5(objC.clave)) & "',"
                    vCadena = vCadena & " '" & vFree & "',"
                    vCadena = vCadena & " false " & ","
                    vCadena = vCadena & " 'A'"
                    vCadena = vCadena & " )"
                Else
                    vCadena = "Update basic.clave set "
                    vCadena = vCadena & " usuario='" & objC.usuario & "',"
                    vCadena = vCadena & " clave='" & GenerarMD5(objC.clave) & "'"
                    vCadena = vCadena & " where personaid=" & objC.codigo

                End If
                Dim oConexion As New clsConexion
                xDt = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                Return True
            Finally
                vCadena = ""
            End Try
        End Function

    End Class

    
End Namespace

