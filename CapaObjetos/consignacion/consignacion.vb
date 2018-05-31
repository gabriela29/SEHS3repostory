Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
  Public Class consignacion
    Private mCodigo As Long
    Private mCodigo_Documento As Integer
    Private mNumero As String
    Private mCodigo_Almacen As Integer
    Private mCodigo_Campania As Integer
    Private mCodigo_Asistente As Long
    Private mfecha As String
    Private mTotal As Single
    Private mporcentaje_dzmo As Single
    Private mCodigo_Usuario As Long
    Private mcaja As String
    Private mEstado As Boolean
    Private mSigno_Positivo As Boolean
    Private mImporte_Dzmo As Single
    Private mTipo As Integer
    Private mCodigo_Dist_Ref As Long
    Private mCodigo_Ref1 As Long

    Public Property Codigo() As Long
      Get
        Return mCodigo
      End Get
      Set(ByVal value As Long)
        mCodigo = value
      End Set
    End Property

    Public Property Codigo_Documento() As Integer
      Get
        Return mCodigo_Documento
      End Get
      Set(ByVal value As Integer)
        mCodigo_Documento = value
      End Set
    End Property

    Public Property Numero() As String
      Get
        Return mNumero
      End Get
      Set(ByVal value As String)
        mNumero = value
      End Set
    End Property

    Public Property Codigo_Almacen() As Integer
      Get
        Return mCodigo_Almacen
      End Get
      Set(ByVal value As Integer)
        mCodigo_Almacen = value
      End Set
    End Property

    Public Property Codigo_Campania() As Integer
      Get
        Return mCodigo_Campania
      End Get
      Set(ByVal value As Integer)
        mCodigo_Campania = value
      End Set
    End Property

    Public Property Codigo_Asistente() As Long
      Get
        Return mCodigo_Asistente
      End Get
      Set(ByVal value As Long)
        mCodigo_Asistente = value
      End Set
    End Property

    Public Property fecha() As String
      Get
        Return mfecha
      End Get
      Set(ByVal value As String)
        mfecha = value
      End Set
    End Property

    Public Property Total() As Single
      Get
        Return mTotal
      End Get
      Set(ByVal value As Single)
        mTotal = value
      End Set
    End Property

    Public Property porcentaje_dzmo() As Single
      Get
        Return mporcentaje_dzmo
      End Get
      Set(ByVal value As Single)
        mporcentaje_dzmo = value
      End Set
    End Property

    Public Property Codigo_Usuario() As Long
      Get
        Return mCodigo_Usuario
      End Get
      Set(ByVal value As Long)
        mCodigo_Usuario = value
      End Set
    End Property

    Public Property caja() As String
      Get
        Return mcaja
      End Get
      Set(ByVal value As String)
        mcaja = value
      End Set
    End Property

    Public Property Estado() As Boolean
      Get
        Return mEstado
      End Get
      Set(ByVal value As Boolean)
        mEstado = value
      End Set
    End Property

    Public Property Signo_Positivo() As Boolean
      Get
        Return mSigno_Positivo
      End Get
      Set(ByVal value As Boolean)
        mSigno_Positivo = value
      End Set
    End Property

    Public Property Importe_Dzmo() As Single
      Get
        Return mImporte_Dzmo
      End Get
      Set(ByVal value As Single)
        mImporte_Dzmo = value
      End Set
    End Property

    Public Property Tipo() As Integer
      Get
        Return mTipo
      End Get
      Set(ByVal value As Integer)
        mTipo = value
      End Set
    End Property

    Public Property Codigo_Dist_Ref() As Long
      Get
        Return mCodigo_Dist_Ref
      End Get
      Set(ByVal value As Long)
        mCodigo_Dist_Ref = value
      End Set
    End Property

    Public Property Codigo_Ref1() As Long
      Get
        Return mCodigo_Ref1
      End Get
      Set(ByVal value As Long)
        mCodigo_Ref1 = value
      End Set
    End Property
  End Class
End Namespace
