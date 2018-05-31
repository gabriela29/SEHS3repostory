Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class material
        Private mmaterialid As Long
        Private mnombre As String
        Private mdescripcion As String
        Private mprecio As Single
        Private medad_detalle As String
        Private mmaterialsubgrupoid As Long
        Private mestado As Boolean

        Public Property materialid() As Long
            Get
                Return mmaterialid
            End Get
            Set(value As Long)
                mmaterialid = value
            End Set
        End Property

        Public Property nombre As String
            Get
                Return mnombre
            End Get
            Set(value As String)
                mnombre = value
            End Set
        End Property

        Public Property descripcion As String
            Get
                Return mdescripcion
            End Get
            Set(value As String)
                mdescripcion = value
            End Set
        End Property
        Public Property precio As Single
            Get
                Return mprecio
            End Get
            Set(value As Single)
                mprecio = value
            End Set
        End Property
        Public Property edad_detalle As String
            Get
                Return medad_detalle
            End Get
            Set(value As String)
                medad_detalle = value
            End Set
        End Property
        Public Property materialsubgrupoid As Long
            Get
                Return mmaterialsubgrupoid
            End Get
            Set(value As Long)
                mmaterialsubgrupoid = value
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
    End Class
End Namespace

