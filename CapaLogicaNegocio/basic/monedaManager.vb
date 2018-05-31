Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

  Public Class monedaManager
    Public Shared Function GetList(ByVal vNombre As String) As DataTable
      Return monedaBD.GetList(vNombre)
    End Function

  End Class
End Namespace
