Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class control_mes
        Private mmes As Long
        Private manio As Long
        Private mcodigo_uni As Long
        Private mapertura As String
        Private mcierre As String
        Private musuario_a As String
        Private musuario_b As String
        Private mcaja_a As String
        Private mcaja_b As String
        Private mcerrado As Boolean

        Public Property mes() As Long
            Get
                Return mmes
            End Get
            Set(ByVal value As Long)
                mmes = value
            End Set
        End Property
        Public Property anio() As Long
            Get
                Return manio
            End Get
            Set(ByVal value As Long)
                manio = value
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
        Public Property apertura() As String
            Get
                Return mapertura
            End Get
            Set(ByVal value As String)
                mapertura = value
            End Set
        End Property
        Public Property cierre() As String
            Get
                Return mcierre
            End Get
            Set(ByVal value As String)
                mcierre = value
            End Set
        End Property
        Public Property usuario_a() As String
            Get
                Return musuario_a
            End Get
            Set(ByVal value As String)
                musuario_a = value
            End Set
        End Property
        Public Property usuario_b() As String
            Get
                Return musuario_b
            End Get
            Set(ByVal value As String)
                musuario_b = value
            End Set
        End Property
        Public Property caja_a() As String
            Get
                Return mcaja_a
            End Get
            Set(ByVal value As String)
                mcaja_a = value
            End Set
        End Property
        Public Property caja_b() As String
            Get
                Return mcaja_b
            End Get
            Set(ByVal value As String)
                mcaja_b = value
            End Set
        End Property
        Public Property cerrado() As Boolean
            Get
                Return mcerrado
            End Get
            Set(ByVal value As Boolean)
                mcerrado = value
            End Set
        End Property
    End Class
End Namespace
