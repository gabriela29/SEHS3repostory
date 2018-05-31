Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class unidad_negocioManager
        Public Shared Function GetList_Grupo(ByVal vCodigo As Integer) As DataTable
            Return unidad_negocioBD.GetList_Grupo(vCodigo)
        End Function

        Public Shared Function GetList_Iglesia(ByVal vCodigo As Integer) As DataTable
            Return unidad_negocioBD.GetList_Iglesia(vCodigo)
        End Function

    End Class
End Namespace
