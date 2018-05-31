Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO

    Public Class lote_gastos
        Private mcodigo As Long = -1

        Private mcod_almacen As Long
        Private mdescripcion As String
        Private mfecha As String
        Private mfecha_cierre As String
        Private mestado As Boolean
        Private mcod_us As Long
        Private mtipo As String

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property
        Public Property cod_almacen() As Long
            Get
                Return mcod_almacen
            End Get
            Set(ByVal value As Long)
                mcod_almacen = value
            End Set
        End Property
        Public Property descripcion() As String
            Get
                Return mdescripcion
            End Get
            Set(ByVal value As String)
                mdescripcion = value
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
        Public Property fecha_cierre() As String
            Get
                Return mfecha_cierre
            End Get
            Set(ByVal value As String)
                mfecha_cierre = value
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
        Public Property cod_us() As Long
            Get
                Return mcod_us
            End Get
            Set(ByVal value As Long)
                mcod_us = value
            End Set
        End Property
        Public Property tipo() As String
            Get
                Return mtipo
            End Get
            Set(ByVal value As String)
                mtipo = value
            End Set
        End Property
    End Class
End Namespace
