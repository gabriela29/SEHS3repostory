
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class iglesiaManager
        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String, ByVal vMisionId As Integer, ByVal vGrupoId As Long, _
                                          ByVal vdepartamentoid As Long, ByVal vProvinId As Long, ByVal vdistritoid As Long) As DataTable
            Return iglesiaBD.GetList(vUnion, vNombre, vMisionId, vGrupoId, vdepartamentoid, vProvinId, vdistritoid)
        End Function

        Public Shared Function GestIglesiaJuridica(ByVal vPeriodo As Integer, ByVal vdistritoid As Long) As DataTable
            Return iglesiaBD.GestIglesiaJuridica(vPeriodo, vdistritoid)
        End Function

    End Class
End Namespace