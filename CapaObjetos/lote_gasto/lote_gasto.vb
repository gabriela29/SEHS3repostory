
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class lote_gasto

        Private mlotegastoid As Long = -1
        Private malmacenid As Integer
        Private mnombre As String
        Private mmes As Integer
        Private manio As Integer
        Private mestado As Boolean
        Private musuarioid As Long
        Private mcaja As String
        Private mimporte As Single

        Public Property lotegastoid() As Long
            Get
                Return mlotegastoid
            End Get
            Set(ByVal value As Long)
                mlotegastoid = value
            End Set
        End Property

        Public Property almacenid() As Integer
            Get
                Return malmacenid
            End Get
            Set(ByVal value As Integer)
                malmacenid = value
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

        Public Property mes() As Integer
            Get
                Return mmes
            End Get
            Set(ByVal value As Integer)
                mmes = value
            End Set
        End Property

        Public Property anio() As Integer
            Get
                Return manio
            End Get
            Set(ByVal value As Integer)
                manio = value
            End Set
        End Property

        Public Property estado() As Boolean
            Get
                Return mestado
            End Get
            Set(ByVal value As Boolean)
                mestado = value
            End Set
        End Property

        Public Property usuarioid() As Long
            Get
                Return musuarioid
            End Get
            Set(ByVal value As Long)
                musuarioid = value
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

        Public Property importe() As Single
            Get
                Return mimporte
            End Get
            Set(ByVal value As Single)
                mimporte = value
            End Set
        End Property

    End Class
End Namespace

