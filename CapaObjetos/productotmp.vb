Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class productotmp
        Private mCodigo As Long = -1
        Private mNombre_Producto As String
        Private mPresentacion As String
        Private mPrecio_Compra As Single
        Private mPrecio_VA As Single
        Private mPrecio_VB As Single

        Private mStock_Minimo As Long
        Private mStock_Maximo As Long
        Private mCodigo_Barras As String
        Private mAfecto_Dzmo As Boolean
        Private mAfecto_Igv As Boolean
        Private mCodigo_SubCategoria As Integer
        Private mCodigo_Grupo As Integer
        Private mCodigo_Unidad_Medida As Integer
        Private mPaginas As Long

        Public Property Codigo() As Long
            Get
                Return mCodigo
            End Get
            Set(ByVal value As Long)
                mCodigo = value
            End Set
        End Property

        Public Property Nombre_Producto() As String
            Get
                Return mNombre_Producto
            End Get
            Set(ByVal value As String)
                mNombre_Producto = value
            End Set
        End Property

        Public Property Presentacion() As String
            Get
                Return mPresentacion
            End Get
            Set(ByVal value As String)
                mPresentacion = value
            End Set
        End Property

        Public Property Precio_Compra() As Single
            Get
                Return mPrecio_Compra
            End Get
            Set(ByVal value As Single)
                mPrecio_Compra = value
            End Set
        End Property

        Public Property Precio_VA() As Single
            Get
                Return mPrecio_VA
            End Get
            Set(ByVal value As Single)
                mPrecio_VA = value
            End Set
        End Property

        Public Property Precio_VB() As Single
            Get
                Return mPrecio_VB
            End Get
            Set(ByVal value As Single)
                mPrecio_VB = value
            End Set
        End Property

        Public Property Stock_Minimo() As Long
            Get
                Return mStock_Minimo
            End Get
            Set(ByVal value As Long)
                mStock_Minimo = value
            End Set
        End Property

        Public Property Stock_Maximo() As Long
            Get
                Return mStock_Maximo
            End Get
            Set(ByVal value As Long)
                mStock_Maximo = value
            End Set
        End Property

        Public Property Codigo_Barras() As String
            Get
                Return mCodigo_Barras
            End Get
            Set(ByVal value As String)
                mCodigo_Barras = value
            End Set
        End Property

        Public Property Afecto_Dzmo() As Boolean
            Get
                Return mAfecto_Dzmo
            End Get
            Set(ByVal value As Boolean)
                mAfecto_Dzmo = value
            End Set
        End Property

        Public Property Afecto_Igv() As Boolean
            Get
                Return mAfecto_Igv
            End Get
            Set(ByVal value As Boolean)
                mAfecto_Igv = value
            End Set
        End Property

        Public Property Codigo_SubCategoria() As Integer
            Get
                Return mCodigo_SubCategoria
            End Get
            Set(ByVal value As Integer)
                mCodigo_SubCategoria = value
            End Set
        End Property

        Public Property Codigo_Grupo() As Integer
            Get
                Return mCodigo_Grupo
            End Get
            Set(ByVal value As Integer)
                mCodigo_Grupo = value
            End Set
        End Property

        Public Property Codigo_Unidad_Medida() As Integer
            Get
                Return mCodigo_Unidad_Medida
            End Get
            Set(ByVal value As Integer)
                mCodigo_Unidad_Medida = value
            End Set
        End Property

        Public Property Paginas() As Long
            Get
                Return mPaginas
            End Get
            Set(ByVal value As Long)
                mPaginas = value
            End Set
        End Property

    End Class
End Namespace
