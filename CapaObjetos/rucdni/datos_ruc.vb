Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

  Public Class datos_ruc
    Private mPersonaId As Long
    Private mRuc As String
    Private mRaz_Soc As String
    Private mDni As String
    Private mDireccion As String
    Private mEstado As String
    Private mCondicion As String
    Private mAgente_Ret As String
    Private mTipo_Per As String
    Private mTelefonos As String

    Public Property personaid() As Long
      Get
        Return mPersonaId
      End Get
      Set(ByVal value As Long)
        mPersonaId = value
      End Set
    End Property

    Public Property ruc() As String
      Get
        Return mRuc
      End Get
      Set(ByVal value As String)
        mRuc = value
      End Set
    End Property

    Public Property Razon_Social() As String
      Get
        Return mRaz_Soc
      End Get
      Set(ByVal value As String)
        mRaz_Soc = value
      End Set
    End Property

    Public Property Direccion() As String
      Get
        Return mDireccion
      End Get
      Set(ByVal value As String)
        mDireccion = value
      End Set
    End Property
    Public Property Estado() As String
      Get
        Return mEstado
      End Get
      Set(ByVal value As String)
        mEstado = value
      End Set
    End Property

    Public Property Condicion() As String
      Get
        Return mCondicion
      End Get
      Set(ByVal value As String)
        mCondicion = value
      End Set
    End Property

    Public Property Agente_Ret() As String
      Get
        Return mAgente_Ret
      End Get
      Set(ByVal value As String)
        mAgente_Ret = value
      End Set
    End Property

    Public Property Tipo_Per() As String
      Get
        Return mTipo_Per
      End Get
      Set(ByVal value As String)
        mTipo_Per = value
      End Set
    End Property

    Public Property Dni() As String
      Get
        Return mDni
      End Get
      Set(ByVal value As String)
        mDni = value
      End Set
    End Property

    Public Property Telefonos() As String
      Get
        Return mTelefonos
      End Get
      Set(ByVal value As String)
        mTelefonos = value
      End Set
    End Property

  End Class
End Namespace
