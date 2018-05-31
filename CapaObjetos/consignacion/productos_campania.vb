Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class productos_campania
        Private mproductoscampaniaid As Long
        Private mcampaniaid As Integer
        Private mproductoid As Long
        Private mprecio As Single
        Private mafecto_igv As Boolean
        Private mafecto_dzmo As Boolean
        Private mafecto_plus_esc As Boolean
        Private musuarioid As Long
        Private mcaja As String
        Private mabreviatura As String
        Private mProducto As String

        Public Property productoscampaniaid() As Long
            Get
                Return mproductoscampaniaid
            End Get
            Set(ByVal value As Long)
                mproductoscampaniaid = value
            End Set
        End Property

        Public Property campaniaid() As Integer
            Get
                Return mcampaniaid
            End Get
            Set(value As Integer)
                mcampaniaid = value
            End Set
        End Property

        Public Property productoid() As Long
            Get
                Return mproductoid
            End Get
            Set(value As Long)
                mproductoid = value
            End Set
        End Property

        Public Property precio() As Single
            Get
                Return mprecio
            End Get
            Set(value As Single)
                mprecio = value
            End Set
        End Property
        Public Property afecto_igv() As Boolean
            Get
                Return mafecto_igv
            End Get
            Set(value As Boolean)
                mafecto_igv = value
            End Set
        End Property

        Public Property afecto_dzmo() As Boolean
            Get
                Return mafecto_dzmo
            End Get
            Set(value As Boolean)
                mafecto_dzmo = value
            End Set
        End Property

        Public Property afecto_plus_esc() As Boolean
            Get
                Return mafecto_plus_esc
            End Get
            Set(value As Boolean)
                mafecto_plus_esc = value
            End Set
        End Property

        Public Property usuarioid() As String
            Get
                Return musuarioid
            End Get
            Set(ByVal value As String)
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

        Public Property Producto() As String
            Get
                Return mProducto
            End Get
            Set(value As String)
                mProducto = value
            End Set
        End Property

        Public Property Abreviatura() As String
            Get
                Return mabreviatura
            End Get
            Set(value As String)
                mabreviatura = value
            End Set
        End Property

    End Class
End Namespace


