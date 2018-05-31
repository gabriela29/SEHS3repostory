Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

  Public Class almacen

    Private mcodigo As Long = -1
    Private mnombre As String
    Private mdireccion As String
    Private mcodigo_uni As Long
    Private mmonto As Single
    Private mtelefono As String

    Public Property codigo() As Long
      Get
        Return mcodigo
      End Get
      Set(ByVal value As Long)
        mcodigo = value
      End Set

    End Property
    Public Property nombre() As String
      Get
        Return mnombre
      End Get
      Set(ByVal value As String)
        mnombre = value
      End Set
    End Property
    Public Property direccion() As String
      Get
        Return mdireccion
      End Get
      Set(ByVal value As String)
        mdireccion = value
      End Set
    End Property
    Public Property codigo_uni() As Long
      Get
        Return mcodigo_uni
      End Get
      Set(ByVal value As Long)
        mcodigo_uni = value
      End Set
    End Property
    Public Property monto() As Single
      Get
        Return mmonto
      End Get
      Set(ByVal value As Single)
        mmonto = value
      End Set
    End Property
    Public Property telefono() As String
      Get
        Return mtelefono
      End Get
      Set(ByVal value As String)
        mtelefono = value
      End Set
    End Property
  End Class
End Namespace
