Namespace BO
  Public Class clsAuxiliar
    Private mcadena As String
    Public Property cadena() As String
      Get
        Return mcadena
      End Get
      Set(ByVal value As String)
        mcadena = value
      End Set
    End Property
  End Class

End Namespace
