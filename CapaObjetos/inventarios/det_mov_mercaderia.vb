
Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class det_mov_mercaderia
        Private mcodigo As Long
        Private mcodigo_modulo As Integer
        Private mcodigo_movimiento As Integer
        Private mcodigo_doc As Integer

        Private msigno As String
        Private mIncluir_Ref As Boolean
        Private mColumna_Dscto As Boolean


        Public Property Codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property

        Public Property codigo_modulo() As Integer
            Get
                Return mcodigo_modulo
            End Get
            Set(ByVal value As Integer)
                mcodigo_modulo = value
            End Set
        End Property

        Public Property codigo_movimiento() As Integer
            Get
                Return mcodigo_movimiento
            End Get
            Set(ByVal value As Integer)
                mcodigo_movimiento = value
            End Set
        End Property

        Public Property codigo_doc() As Integer
            Get
                Return mcodigo_doc
            End Get
            Set(ByVal value As Integer)
                mcodigo_doc = value
            End Set
        End Property

        Public Property signo() As String
            Get
                Return msigno
            End Get
            Set(ByVal value As String)
                msigno = value
            End Set
        End Property

        Public Property Incluir_Ref() As Boolean
            Get
                Return mIncluir_Ref
            End Get
            Set(ByVal value As Boolean)
                mIncluir_Ref = value
            End Set
        End Property

        Public Property Columna_Dscto() As Boolean
            Get
                Return mColumna_Dscto
            End Get
            Set(ByVal value As Boolean)
                mColumna_Dscto = value
            End Set
        End Property

    End Class
End Namespace

