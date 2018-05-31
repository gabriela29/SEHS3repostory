Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class gestion_accesoManager
        Public Shared Function Actualizar_Menu(vPersonaId As Long, vArray As String, vUsuarioId As Long, vIp As String) As Boolean
            Try
                Actualizar_Menu = gestion_accesoBD.Actualizar_Menu(vPersonaId, vArray, vUsuarioId, vIp)
                Return Actualizar_Menu
            Finally

            End Try
        End Function

        Public Shared Function Actualizar_Mod_alm(vPersonaId As Long, vArray As String, vUsuarioId As Long, vIp As String) As Boolean
            Try
                Actualizar_Mod_alm = gestion_accesoBD.Actualizar_ModAlm(vPersonaId, vArray, vUsuarioId, vIp)
                Return Actualizar_Mod_alm
            Finally

            End Try
        End Function

        Public Shared Function Actualizar_Otros(vPersonaId As Long, vArray As String, vUsuarioId As Long, vIp As String) As Boolean
            Try
                Actualizar_Otros = gestion_accesoBD.Actualizar_Otros(vPersonaId, vArray, vUsuarioId, vIp)
                Return Actualizar_Otros
            Finally

            End Try
        End Function

    End Class
End Namespace

