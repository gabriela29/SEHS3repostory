Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class unidad_medida

        Private munidadmedidaid As Long = -1
        Private mnombre As String
        Private mabrev As String
        Private mcodigo_conta As String

        Public Property unidadmedidaid() As Long
            Get
                Return munidadmedidaid
            End Get
            Set(ByVal value As Long)
                munidadmedidaid = value
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

        Public Property abrev() As String
            Get
                Return mabrev
            End Get
            Set(ByVal value As String)
                mabrev = value
            End Set
        End Property

        Public Property codigo_conta() As String
            Get
                Return mcodigo_conta
            End Get
            Set(ByVal value As String)
                mcodigo_conta = value
            End Set
        End Property
    End Class
End Namespace
