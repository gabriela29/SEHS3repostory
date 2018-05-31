Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class concepto_gasto
        Private mcodigo As Long = -1
        Private mnombre As String
        Private mestado As Boolean        

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

        Public Property estado() As Boolean
            Get
                Return mestado
            End Get
            Set(ByVal value As Boolean)
                mestado = value
            End Set
        End Property



    End Class
End Namespace
