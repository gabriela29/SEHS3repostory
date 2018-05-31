Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class tipopersonacampaniaManager
    Public Shared Function Tipo_Persona_Campania_leer(ByVal vNombre As String) As DataTable

      Return tipopersonacampaniaBD.Tipo_persona_Campania_leer(vNombre)

    End Function
  End Class
End Namespace

