Namespace BO
  Public Class porcobrar_gestion
    Private pPorcobrarid As Long
    Private pNum_carta As Integer
    Private pEmision As String
    Private pNdias As Integer
    Private pDeuda As Single
    Private pAdicional As Single
    Private pResponsableid As Long
    Private pEstado As Integer
    Private pObservacion As String
    Private pUsuarioid As Long
    Private pCaja As String

    Public Property Porcobrarid() As Long
      Get
        Return pPorcobrarid
      End Get
      Set(ByVal value As Long)
        pPorcobrarid = value
      End Set
    End Property

    Public Property Num_Carta As Integer
      Get
        Return pNum_carta
      End Get
      Set(value As Integer)
        pNum_carta = value
      End Set
    End Property

    Public Property Emision As String
      Get
        Return pEmision
      End Get
      Set(value As String)
        pEmision = value
      End Set
    End Property

    Public Property Ndias As Integer
      Get
        Return pNdias
      End Get
      Set(value As Integer)
        pNdias = value
      End Set
    End Property
    Public Property Deuda As Single
      Get
        Return pDeuda
      End Get
      Set(value As Single)
        pDeuda = value
      End Set
    End Property
    Public Property Adicional As Single
      Get
        Return pAdicional
      End Get
      Set(value As Single)
        pAdicional = value
      End Set
    End Property
    Public Property Responsableid As Long
      Get
        Return pResponsableid
      End Get
      Set(value As Long)
        pResponsableid = value
      End Set
    End Property

    Public Property Estado() As Integer
      Get
        Return pEstado
      End Get
      Set(ByVal value As Integer)
        pEstado = value
      End Set
    End Property
    Public Property Observacion() As String
      Get
        Return pObservacion
      End Get
      Set(ByVal value As String)
        pObservacion = value
      End Set
    End Property
    Public Property UsuarioId() As Long
      Get
        Return pUsuarioid
      End Get
      Set(ByVal value As Long)
        pUsuarioid = value
      End Set
    End Property

    Public Property caja() As String
      Get
        Return pCaja
      End Get
      Set(ByVal value As String)
        pCaja = value
      End Set
    End Property

  End Class
End Namespace

