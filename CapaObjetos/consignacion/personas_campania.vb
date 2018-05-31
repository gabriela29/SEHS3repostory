Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

  Public Class personas_campania

    Private mcodigo_cam As Integer
    Private mcodigo_alm As Integer
    Private mcodigo_asi As Long
    Private mcodigo_colp As Long
    Private mtipo As Integer
    Private mestado As Boolean
    Private mnrocuenta As String
    Private mc_costo As Long
    Private mobservacion As String
    Private musuario As String
    Private mcaja As String

    Public Property codigo_cam() As Integer
      Get
        Return mcodigo_cam
      End Get
      Set(ByVal value As Integer)
        mcodigo_cam = value
      End Set
    End Property

    Public Property codigo_alm() As Integer
      Get
        Return mcodigo_alm
      End Get
      Set(ByVal value As Integer)
        mcodigo_alm = value
      End Set
    End Property

    Public Property codigo_asi() As Long
      Get
        Return mcodigo_asi
      End Get
      Set(ByVal value As Long)
        mcodigo_asi = value
      End Set
    End Property

    Public Property codigo_colp() As Long
      Get
        Return mcodigo_colp
      End Get
      Set(ByVal value As Long)
        mcodigo_colp = value
      End Set
    End Property

    Public Property tipo() As Integer
      Get
        Return mtipo
      End Get
      Set(value As Integer)
        mtipo = value
      End Set
    End Property

    Public Property estado() As Boolean
      Get
        Return mestado
      End Get
      Set(value As Boolean)
        mestado = value
      End Set
    End Property
    Public Property nrocuenta() As String
      Get
        Return mnrocuenta
      End Get
      Set(ByVal value As String)
        mnrocuenta = value
      End Set
    End Property

    Public Property c_costo() As Long
      Get
        Return mc_costo
      End Get
      Set(ByVal value As Long)
        mc_costo = value
      End Set
    End Property

    Public Property observacion() As String
      Get
        Return mobservacion
      End Get
      Set(ByVal value As String)
        mobservacion = value
      End Set
    End Property

    Public Property usuario() As String
      Get
        Return musuario
      End Get
      Set(ByVal value As String)
        musuario = value
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

  End Class
End Namespace
