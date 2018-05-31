Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class distrito_misioneroManager
        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String, ByVal vMisionId As Integer, ByVal vdepartamentoid As Long) As DataTable
            Return distrito_misioneroBD.GetList(vUnion, vNombre, vMisionId, vdepartamentoid)
        End Function
    End Class
End Namespace

