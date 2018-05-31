Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class ClaveManager

        Public Shared Function GetItem(ByVal vUsuario As String, ByVal vCodigo As String) As Long
            Return ClaveBD.GetItem(vUsuario, vCodigo)
        End Function

        Public Shared Function GetItemUs(ByVal vUsuario As String, ByVal vCodigo As String) As clave
            Return ClaveBD.GetItemUs(vUsuario, vCodigo)
        End Function

        Public Shared Function GetItemUs(ByVal vCodigo As Long) As clave
            Return ClaveBD.GetItemUs(vCodigo)
        End Function

        Public Shared Function Actualizar(ByVal xNew As Boolean, ByVal objC As clave) As Boolean

            Dim vCodigo As Boolean = False
            Try
                Actualizar = ClaveBD.Actualizar(xNew, objC)
                'outerrornumber

            Finally

            End Try
            Return Actualizar
        End Function

    End Class
End Namespace
