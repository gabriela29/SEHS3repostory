


Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class bonificacionManager
        Public Shared Function GetList(ByVal vAlmacenid As Integer, ByVal vTipo As Integer, ByVal vDestino As Integer, ByVal vNombre As String) As DataTable
            Return bonificacionBD.GetList(vAlmacenid, vTipo, vDestino, vNombre)
        End Function
    End Class
End Namespace

