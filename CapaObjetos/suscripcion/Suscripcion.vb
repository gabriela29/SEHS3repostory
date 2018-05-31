
Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
  Public Class Suscripcion

    Private msuscripcionid As Long
    Private mfecha As String
    Private mnumero As String
    Private mperiodoid As Integer
    Private miglesiaid As Long
    Private mpersonaid As Long
    Private mtotal As Single
    Private mabonado As Single
    Private mobservacion As String
    Private musuarioid As Long
    Private mip As String
    Private mestado As Boolean
    Private mcerrado As Boolean
    Private mdiap As Integer

    Public Property suscripcionid As Long
      Get
        Return msuscripcionid
      End Get
      Set(value As Long)
        msuscripcionid = value
      End Set
    End Property

    Public Property fecha As String
      Get
        Return mfecha
      End Get
      Set(value As String)
        mfecha = value
      End Set
    End Property

    Public Property numero As String
      Get
        Return mnumero
      End Get
      Set(value As String)
        mnumero = value
      End Set
    End Property

    Public Property periodoid As Integer
      Get
        Return mperiodoid
      End Get
      Set(value As Integer)
        mperiodoid = value
      End Set
    End Property

    Public Property iglesiaid As Long
      Get
        Return miglesiaid
      End Get
      Set(value As Long)
        miglesiaid = value
      End Set
    End Property

    Public Property personaid As Long
      Get
        Return mpersonaid
      End Get
      Set(value As Long)
        mpersonaid = value
      End Set
    End Property

    Public Property total As Single
      Get
        Return mtotal
      End Get
      Set(value As Single)
        mtotal = value
      End Set
    End Property

    Public Property abonado As Single
      Get
        Return mabonado
      End Get
      Set(value As Single)
        mabonado = value
      End Set
    End Property

    Public Property observacion As String
      Get
        Return mobservacion
      End Get
      Set(value As String)
        mobservacion = value
      End Set
    End Property

    Public Property usuarioid As Long
      Get
        Return musuarioid
      End Get
      Set(value As Long)
        musuarioid = value
      End Set
    End Property

    Public Property ip As String
      Get
        Return mip
      End Get
      Set(value As String)
        mip = value
      End Set
    End Property

    Public Property estado As Boolean
      Get
        Return mestado
      End Get
      Set(value As Boolean)
        mestado = value
      End Set
    End Property

    Public Property cerrado As Boolean
      Get
        Return mcerrado
      End Get
      Set(value As Boolean)
        mcerrado = value
      End Set
    End Property

    Public Property diap As Integer
      Get
        Return mdiap
      End Get
      Set(value As Integer)
        mdiap = value
      End Set
    End Property
  End Class
End Namespace

