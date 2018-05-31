Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class permisos_modulo

        Private mcodigo_per As Long
        Private mcodigo_alm As Integer
        Private mcodigo_mod As Integer

        Public Property codigo_per() As Long
            Get
                Return mcodigo_per
            End Get
            Set(ByVal value As Long)
                mcodigo_per = value
            End Set
        End Property

        Public Property codigo_alm() As Integer
            Get
                Return mcodigo_alm
            End Get
            Set(ByVal value As Integer)
                mcodigo_alm = value
            End Set
        End Property
        Public Property codigo_mod() As Integer
            Get
                Return mcodigo_mod
            End Get
            Set(ByVal value As Integer)
                mcodigo_mod = value
            End Set
        End Property
    End Class
End Namespace
