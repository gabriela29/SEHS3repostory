Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class personaManager
        Public Shared Function GetItem(ByVal codigo As Long) As persona
            Return personaBD.GetItem(codigo)
        End Function

        Public Shared Function GetList(ByVal vapepat As String, ByVal vapemat As String, ByVal vnombre As String, ByVal vproceso As String, _
                                        ByVal varrrol As String, ByVal vfilas As Long, ByVal vpersonaid As Long) As DataTable
            Return personaBD.GetList(vapepat, vapemat, vnombre, vproceso, varrrol, vfilas, vpersonaid)
        End Function

        Public Shared Function Datos_Persona_Basic(ByVal vTipo As String, ByVal vNroDoc As String, ByVal vpersona As Long) As persona
            Return personaBD.Datos_Persona_Basic(vTipo, vNroDoc, vpersona)
        End Function

        Public Shared Function Datos_Persona_Colportaje(ByVal vTipo As String, ByVal vAlmacenId As Integer, ByVal vPersonaID As Long, ByVal vNroDoc As String) As persona
            Return personaBD.Datos_Persona_Colportaje(vTipo, vAlmacenId, vPersonaID, vNroDoc)
        End Function

        Public Shared Function Actualizar(ByVal objP As persona, ByVal varrphone As String, ByVal varremail As String, _
                                          ByVal varrsocialmedia As String, ByVal varrrol As String, ByVal varrdireccion As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = personaBD.Actualizar(objP, varrphone, varremail, varrsocialmedia, varrrol, varrdireccion)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If

            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function Actualizar_Basic(ByVal objP As persona, ByVal vrol As Integer) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = personaBD.Actualizar_Basic(objP, vrol)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then

                        vCodigo = rs.DataSet.Tables(0).Rows(0).Item("papersonaid_bydocumento")
                    
                    End If
                End If

            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function Actualizar_Linea_Credito(ByVal vAlmaceid As Integer, ByVal vPersonaid As Long, ByVal vImporte As Single) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = personaBD.Actualizar_Linea_Credito(vAlmaceid, vPersonaid, vImporte)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then

                        vCodigo = rs.DataSet.Tables(0).Rows(0).Item(("outid"))

                    End If
                End If

            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function Eliminar(ByVal vPersonaId As Long, ByVal vUsuario As Long, ByVal vIp As String) As Boolean
            Dim rs As DataTable
            Try
                rs = personaBD.Eliminar(vPersonaId, vUsuario, vIp)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar = True
                        Else
                            Eliminar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar = False
            End Try
            Return Eliminar
        End Function

        Public Shared Function Persona_Direccion_Actualizar(ByVal vPDId As Long, ByVal vpersonaid As Long, ByVal vSucursal As String, ByVal vDireccion As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = personaBD.Persona_Direccion_Actualizar(vPDId, vpersonaid, vSucursal, vDireccion)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If

            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function GetList_Direccion(ByVal vpersonaid As Long) As DataTable
            Return personaBD.GetList_Direccion(vpersonaid)
        End Function


    End Class

End Namespace

