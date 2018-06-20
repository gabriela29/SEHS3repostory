
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace BLL

    Public Class registrarvManager

        Public Shared Function GetItem(ByVal codigo_registrarv As Long) As registrarv
            Return registrarVBD.GetItem(codigo_registrarv)
        End Function

        Public Shared Function GetList(ByVal vidalmacen As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal vproceso As String,
                                       ByVal varrrol As String, ByVal vfilas As Long, ByVal vcodigo_per As Integer) As DataTable
            Return registrarVBD.GetList(vidalmacen, vmes, vanio, vproceso, varrrol, vfilas, vcodigo_per)
        End Function

        Public Shared Function Actualizar(ByVal objR As registrarv, vacodigo_per As String)
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = registrarVBD.Actualizar(objR, vacodigo_per)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                        vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                    Else
                        MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                    End If
                End If
            Catch ex As Exception

            End Try
            Return vCodigo
        End Function


        Public Shared Function Eliminar_Registrar(ByVal vcodigo_per As Long, ByVal vUsuario As Long, ByVal vIp As Integer) As Boolean

            Dim rs As DataTable
            Try
                rs = registrarVBD.Eliminar(vcodigo_per, vUsuario, vIp)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar_Registrar = True
                        Else
                            Eliminar_Registrar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar_Registrar = False
            End Try
            Return Eliminar_Registrar
        End Function


    End Class

End Namespace

