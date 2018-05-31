Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class centro_costo

        Private mcodigo_alm As Long
        Private mnombre As String
        Private mcentro_costo As Long
        Private morden As Integer
        Private mestado As Boolean
        Private mc_costo_old As Long

        Public Property nombre() As String
            Get
                Return mnombre
            End Get
            Set(ByVal value As String)
                mnombre = value
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

        Public Property centro_costo() As Long
            Get
                Return mcentro_costo
            End Get
            Set(ByVal value As Long)
                mcentro_costo = value
            End Set
        End Property

        Public Property orden() As Integer
            Get
                Return morden
            End Get
            Set(ByVal value As Integer)
                morden = value
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

        Public Property c_costo_old() As Long
            Get
                Return mc_costo_old
            End Get
            Set(ByVal value As Long)
                mc_costo_old = value
            End Set
        End Property
    End Class
End Namespace
