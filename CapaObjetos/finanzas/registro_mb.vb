Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO


  Public Class registro_mb
    Private mregistrombid As Long
    Private mtabla As String
    Private mtablaid As Long
    Private mcuenta As Long
    Private mctacte As String
    Private mcentro_costo As String
    Private mnrooperacion As String
    Private mimporte As Single
    Private mfecha As String
    Private mfecha_Registro As String
    Private mglosa As String
    Private musuario As String
    Private mcaja As String
    Private mtipomonedaid As String
    Private mtipocambio As Single

    Public Property registrombid() As Long
      Get
        Return mregistrombid
      End Get
      Set(ByVal value As Long)
        mregistrombid = value
      End Set
    End Property

    Public Property tabla() As String
      Get
        Return mtabla
      End Get
      Set(ByVal value As String)
        mtabla = value
      End Set
    End Property

    Public Property tablaid() As Long
      Get
        Return mtablaid
      End Get
      Set(ByVal value As Long)
        mtablaid = value
      End Set
    End Property

    Public Property cuenta() As Long
      Get
        Return mcuenta
      End Get
      Set(ByVal value As Long)
        mcuenta = value
      End Set
    End Property

    Public Property ctacte() As String
      Get
        Return mctacte
      End Get
      Set(ByVal value As String)
        mctacte = value
      End Set
    End Property

    Public Property centro_costo() As String
      Get
        Return mcentro_costo
      End Get
      Set(ByVal value As String)
        mcentro_costo = value
      End Set
    End Property

    Public Property nrooperacion() As String
      Get
        Return mnrooperacion
      End Get
      Set(ByVal value As String)
        mnrooperacion = value
      End Set
    End Property

    Public Property importe() As Single
      Get
        Return mimporte
      End Get
      Set(ByVal value As Single)
        mimporte = value
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

    Public Property fecha_registro() As String
      Get
        Return mfecha_Registro
      End Get
      Set(ByVal value As String)
        mfecha_Registro = value
      End Set
    End Property

    Public Property glosa() As String
      Get
        Return mglosa
      End Get
      Set(ByVal value As String)
        mglosa = value
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

    Public Property tipomonedaid() As String
      Get
        Return mtipomonedaid
      End Get
      Set(ByVal value As String)
        mtipomonedaid = value
      End Set
    End Property

    Public Property tipocambio() As Single
      Get
        Return mtipocambio
      End Get
      Set(ByVal value As Single)
        mtipocambio = value
      End Set
    End Property

  End Class

End Namespace

