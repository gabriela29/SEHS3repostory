Imports CapaDatos.Dal

Namespace Bll
  Public Class migracionManager
    Public Shared Function GetList(ByVal vOpcion As String) As DataTable
      Return migracionBD.GetList(vOpcion)

    End Function
  End Class

End Namespace
