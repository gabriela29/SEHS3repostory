Imports CapaDatos.Dal

Namespace Bll
  Public Class campaniaManager
    Public Shared Function Campania_leer(ByVal vNombre As String) As DataTable

      Return campaniaBD.Campania_leer(vNombre)

    End Function
  End Class
End Namespace

