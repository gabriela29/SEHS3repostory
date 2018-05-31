Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class producto
        Private mProductoId As Long = -1
        Private mNombre_Producto As String
        Private mPresentacion As String
        Private mPrecio_Compra As Single
        Private mPrecio_VA As Single
        Private mPrecio_VB As Single
        Private mPrecio_VC As Single
        Private mPrecio_VD As Single

        Private mPeso As Single
        Private mStock_Minimo As Long
        Private mStock_Maximo As Long
        Private mCodigo_Barras As String
        Private mExonerado As Boolean
        Private mAfecto_Igv As Boolean

        Private mfraccion As Boolean
        Private mfraccionproductoid As Long
        Private mfraccioncantidad As Long
        Private mmarcaid As Long

        Private mSubCategoriaId As Integer
        Private mGrupoId As Integer
        Private mUnidadMedidaId As Integer

        Private mestado As Boolean        
        Private musuarioid As Long

        Private meditorialid As Long
        Private meditorial As String
        Private medicion As String
        Private mpaginas As Integer
        Private malto As Integer
        Private mancho As Integer
        Private mautorid As Long
        Private mautor As String


        Public Property ProductoId() As Long
            Get
                Return mProductoId
            End Get
            Set(ByVal value As Long)
                mProductoId = value
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

        Public Property Precio_VC() As Single
            Get
                Return mPrecio_VC
            End Get
            Set(ByVal value As Single)
                mPrecio_VC = value
            End Set
        End Property

        Public Property Precio_VD() As Single
            Get
                Return mPrecio_VD
            End Get
            Set(ByVal value As Single)
                mPrecio_VD = value
            End Set
        End Property

        Public Property Peso() As Single
            Get
                Return mPeso
            End Get
            Set(ByVal value As Single)
                mPeso = value
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

        Public Property Exonerado() As Boolean
            Get
                Return mExonerado
            End Get
            Set(ByVal value As Boolean)
                mExonerado = value
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

        Public Property SubCategoriaId() As Integer
            Get
                Return mSubCategoriaId
            End Get
            Set(ByVal value As Integer)
                mSubCategoriaId = value
            End Set
        End Property

        Public Property GrupoId() As Integer
            Get
                Return mGrupoId
            End Get
            Set(ByVal value As Integer)
                mGrupoId = value
            End Set
        End Property

        Public Property UnidadMedidaId() As Integer
            Get
                Return mUnidadMedidaId
            End Get
            Set(ByVal value As Integer)
                mUnidadMedidaId = value
            End Set
        End Property

        Public Property fraccion() As Boolean
            Get
                Return mfraccion
            End Get
            Set(ByVal value As Boolean)
                mfraccion = value
            End Set
        End Property

        Public Property fraccionproductoid() As Long
            Get
                Return mfraccionproductoid
            End Get
            Set(ByVal value As Long)
                mfraccionproductoid = value
            End Set
        End Property

        Public Property fraccioncantidad() As Long
            Get
                Return mfraccioncantidad
            End Get
            Set(ByVal value As Long)
                mfraccioncantidad = value
            End Set
        End Property

        Public Property marcaid() As Long
            Get
                Return mmarcaid
            End Get
            Set(ByVal value As Long)
                mmarcaid = value
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

        Public Property usuarioid() As Long
            Get
                Return musuarioid
            End Get
            Set(ByVal value As Long)
                musuarioid = value
            End Set
        End Property

        Public Property editorialid() As Long
            Get
                Return meditorialid
            End Get
            Set(value As Long)
                meditorialid = value
            End Set
        End Property

        Public Property editorial() As String
            Get
                Return meditorial
            End Get
            Set(value As String)
                meditorial = value
            End Set
        End Property

        Public Property edicion As String
            Get
                Return medicion
            End Get
            Set(value As String)
                medicion = value
            End Set
        End Property

        Public Property paginas As Integer
            Get
                Return mpaginas
            End Get
            Set(value As Integer)
                mpaginas = value
            End Set
        End Property

        Public Property alto As Integer
            Get
                Return malto
            End Get
            Set(value As Integer)
                malto = value
            End Set
        End Property
        Public Property ancho As Integer
            Get
                Return mancho
            End Get
            Set(value As Integer)
                mancho = value
            End Set
        End Property

        Public Property autorid As Long
            Get
                Return mautorid
            End Get
            Set(value As Long)
                mautorid = value

            End Set
        End Property

        Public Property autor As String
            Get
                Return mautor
            End Get
            Set(value As String)
                mautor = value
            End Set
        End Property
    End Class
End Namespace
