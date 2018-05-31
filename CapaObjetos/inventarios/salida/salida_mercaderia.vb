Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class salida_mercaderia
        Private Mcodigo As Long
        Private MCodigo_Tipo As Integer
        Private MNumero As String
        Private MCodigo_Documento As Integer

        Private MCodigo_Almacen As Integer
        Private MCodigo_Persona As Long

        Private Mfecha As String
        Private MMoneda As String
        Private Mcondicion As String
        Private MVta_Bruta As Single
        Private MDescuento As Single
        Private MIGV As Single
        Private MVta_Total As Single
        Private MCambio As Single
        Private MUsuarioId As Long
        Private Mcaja As String
        Private Mestado As Boolean
        Private MObservacion As String
        Private MCerrado As Boolean
        Private MIncluye_IGV As Boolean
        Private mReferencia As String
        Private mCodigo_Ref1 As Long
        Private mCodigo_Ref2 As Long
        Private MDescontar_Stock As Boolean
        Private MValor_IGV As Single
        Private MCodigo_Alm_Dest As Integer

        Public Property Codigo() As Long
            Get
                Return mCodigo
            End Get
            Set(ByVal value As Long)
                mCodigo = value
            End Set
        End Property

        Public Property Codigo_tipo() As Integer
            Get
                Return MCodigo_Tipo
            End Get
            Set(ByVal value As Integer)
                MCodigo_Tipo = value
            End Set
        End Property

        Public Property Numero() As String
            Get
                Return mNumero
            End Get
            Set(ByVal value As String)
                mNumero = value
            End Set
        End Property

        Public Property Codigo_Documento() As Integer
            Get
                Return MCodigo_Documento
            End Get
            Set(ByVal value As Integer)
                mCodigo_Documento = value
            End Set
        End Property

        Public Property Codigo_Almacen() As Integer
            Get
                Return mCodigo_Almacen
            End Get
            Set(ByVal value As Integer)
                mCodigo_Almacen = value
            End Set
        End Property

        Public Property codigo_persona() As Long
            Get
                Return MCodigo_Persona
            End Get
            Set(ByVal value As Long)
                MCodigo_Persona = value
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

        Public Property Moneda() As String
            Get
                Return mMoneda
            End Get
            Set(ByVal value As String)
                mMoneda = value
            End Set
        End Property

        Public Property condicion() As String
            Get
                Return mcondicion
            End Get
            Set(ByVal value As String)
                mcondicion = value
            End Set
        End Property

        Public Property vta_Bruta() As Single
            Get
                Return mvta_Bruta
            End Get
            Set(ByVal value As Single)
                MVta_Bruta = value
            End Set
        End Property

        Public Property Descuento() As Single
            Get
                Return mDescuento
            End Get
            Set(ByVal value As Single)
                mDescuento = value
            End Set
        End Property

        Public Property IGV() As Single
            Get
                Return mIGV
            End Get
            Set(ByVal value As Single)
                mIGV = value
            End Set
        End Property

        Public Property Vta_Total() As Single
            Get
                Return MVta_Total
            End Get
            Set(ByVal value As Single)
                MVta_Total = value
            End Set
        End Property

        Public Property Cambio() As Single
            Get
                Return MCambio
            End Get
            Set(ByVal value As Single)
                MCambio = value
            End Set
        End Property

        Public Property Usuarioid() As String
            Get
                Return MUsuarioId
            End Get
            Set(ByVal value As String)
                MUsuarioId = value
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

        Public Property Estado() As Boolean
            Get
                Return mEstado
            End Get
            Set(ByVal value As Boolean)
                mEstado = value
            End Set
        End Property

        Public Property Observacion() As String
            Get
                Return mObservacion
            End Get
            Set(ByVal value As String)
                mObservacion = value
            End Set
        End Property

        Public Property Cerrado() As Boolean
            Get
                Return mCerrado
            End Get
            Set(ByVal value As Boolean)
                mCerrado = value
            End Set
        End Property

        Public Property Incluye_IGV() As Boolean
            Get
                Return mIncluye_IGV
            End Get
            Set(ByVal value As Boolean)
                mIncluye_IGV = value
            End Set
        End Property

        Public Property Referencia() As String
            Get
                Return mReferencia
            End Get
            Set(ByVal value As String)
                mReferencia = value
            End Set
        End Property

        Public Property Codigo_Ref1 As Long
            Get
                Return mCodigo_Ref1
            End Get
            Set(ByVal value As Long)
                mCodigo_Ref1 = value
            End Set
        End Property

        Public Property Codigo_Ref2 As Long
            Get
                Return mCodigo_Ref2
            End Get
            Set(ByVal value As Long)
                mCodigo_Ref2 = value
            End Set
        End Property

        Public Property Descontar_Stock() As Boolean
            Get
                Return mDescontar_Stock
            End Get
            Set(ByVal value As Boolean)
                mDescontar_Stock = value
            End Set
        End Property

        Public Property Valor_igv() As Single
            Get
                Return mValor_igv
            End Get
            Set(ByVal value As Single)
                mValor_igv = value
            End Set
        End Property

        Public Property Codigo_Alm_Dest() As Integer
            Get
                Return MCodigo_Alm_Dest
            End Get
            Set(ByVal value As Integer)
                MCodigo_Alm_Dest = value
            End Set
        End Property


    End Class
End Namespace
