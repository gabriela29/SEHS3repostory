Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

  Public Class permisos_impresion
    Private mcodigo As Long = -1

    Private mcodigo_usu As Long
    Private mcodigo_alm As Long
    Private mcaja As String
    Private mformato As String
    Private mcodigo_ser As Long
    Private mimpresora As String
    Private mcodigo_doc As Long
    Private mnom_documento As String
    Private mimpresion As Boolean
    Private mcodigo_emp As Long
    Private mserie_TK As String
    Private mcopias As Integer

    Public Property codigo() As Long
      Get
        Return mcodigo
      End Get
      Set(ByVal value As Long)
        mcodigo = value
      End Set
    End Property
    Public Property codigo_usu() As Long
      Get
        Return mcodigo_usu
      End Get
      Set(ByVal value As Long)
        mcodigo_usu = value
      End Set
    End Property
    Public Property codigo_alm() As Long
      Get
        Return mcodigo_alm
      End Get
      Set(ByVal value As Long)
        mcodigo_alm = value
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
    Public Property formato() As String
      Get
        Return mformato
      End Get
      Set(ByVal value As String)
        mformato = value
      End Set
    End Property
    Public Property codigo_ser() As Long
      Get
        Return mcodigo_ser
      End Get
      Set(ByVal value As Long)
        mcodigo_ser = value
      End Set
    End Property
    Public Property impresora() As String
      Get
        Return mimpresora
      End Get
      Set(ByVal value As String)
        mimpresora = value
      End Set
    End Property
    Public Property codigo_doc() As Long
      Get
        Return mcodigo_doc
      End Get
      Set(ByVal value As Long)
        mcodigo_doc = value
      End Set
    End Property

    Public Property nom_documento() As String
      Get
        Return mnom_documento
      End Get
      Set(ByVal value As String)
        mnom_documento = value
      End Set
    End Property

    Public Property impresion() As Boolean
      Get
        Return mimpresion
      End Get
      Set(ByVal value As Boolean)
        mimpresion = value
      End Set
    End Property
    Public Property codigo_emp() As Long
      Get
        Return mcodigo_emp
      End Get
      Set(ByVal value As Long)
        mcodigo_emp = value
      End Set
    End Property

    Public Property serie_TK() As String
      Get
        Return mserie_TK
      End Get
      Set(ByVal value As String)
        mserie_TK = value
      End Set
    End Property

    Public Property copias() As Integer
      Get
        Return mcopias
      End Get
      Set(ByVal value As Integer)
        mcopias = value
      End Set
    End Property
  End Class
End Namespace
