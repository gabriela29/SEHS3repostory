







Imports CapaObjetosNegocio

Namespace BO

    Public Class registrarv
        Private mcodigo_per As Long = -1
        Private memision As Date
        Private mnombre_corto As String
        Private mcodigo_sunat As Integer
        Private mnumero As Integer
        Private mtipo_doc_per As String
        Private mnumero_doc_per As Integer
        Private mpersona As String
        Private mafecto As Integer
        Private mnoafecto As Integer
        Private migv As Integer
        Private mdescuento As Integer
        Private mtotal As Integer
        Private mcambio As Integer
        Private mestado As Integer
        Private mfecha_doc_ori As Date
        Private mserie_doc_ori As String
        Private mcodigo_doc_ori As String
        Private mnumero_doc_ori As Integer
        Private msigno As String
        Private mserie As String
        Private mnumero_int As String
        Private mcodigo_doc As Integer
        Private malmacenaid As Integer
        Private mtabla As String
        Private midtabla As String
        Private mcod_ass As Integer
        Private mmes As Integer
        Private manio As Integer



        Public Property codigo_per() As Long
            Get
                Return mcodigo_per
            End Get
            Set(ByVal value As Long)
                mcodigo_per = value
            End Set
        End Property

        Public Property emision() As Date
            Get
                Return memision
            End Get
            Set(ByVal value As Date)
                memision = value
            End Set
        End Property

        Public Property nombre_corto() As String
            Get
                Return mnombre_corto
            End Get
            Set(ByVal value As String)
                mnombre_corto = value
            End Set
        End Property

        Public Property codigo_sunat() As Integer
            Get
                Return mcodigo_sunat
            End Get
            Set(ByVal value As Integer)
                mcodigo_sunat = value
            End Set
        End Property

        Public Property numero() As Integer
            Get
                Return mnumero
            End Get
            Set(ByVal value As Integer)
                mnumero = value
            End Set
        End Property

        Public Property tipo_doc_per() As String
            Get
                Return mtipo_doc_per
            End Get
            Set(ByVal value As String)
                mtipo_doc_per = value
            End Set
        End Property

        Public Property numero_doc_per() As Integer
            Get
                Return mnumero_doc_per
            End Get
            Set(ByVal value As Integer)
                mnumero_doc_per = value
            End Set
        End Property

        Public Property persona() As String
            Get
                Return mpersona
            End Get
            Set(ByVal value As String)
                mpersona = value
            End Set
        End Property

        Public Property afecto() As Integer
            Get
                Return mafecto
            End Get
            Set(ByVal value As Integer)
                mafecto = value
            End Set
        End Property

        Public Property noafecto() As Integer
            Get
                Return mnoafecto
            End Get
            Set(ByVal value As Integer)
                mnoafecto = value
            End Set
        End Property

        Public Property igv() As Integer
            Get
                Return migv
            End Get
            Set(ByVal value As Integer)
                migv = value
            End Set
        End Property

        Public Property descuento() As Integer
            Get
                Return mdescuento
            End Get
            Set(ByVal value As Integer)
                mdescuento = value
            End Set
        End Property

        Public Property total() As Integer
            Get
                Return mtotal
            End Get
            Set(ByVal value As Integer)
                mtotal = value
            End Set
        End Property

        Public Property cambio() As Integer
            Get
                Return mcambio
            End Get
            Set(ByVal value As Integer)
                mcambio = value
            End Set
        End Property

        Public Property estado() As Integer
            Get
                Return mestado
            End Get
            Set(ByVal value As Integer)
                mestado = value
            End Set
        End Property

        Public Property fecha_doc_ori() As Date
            Get
                Return mfecha_doc_ori
            End Get
            Set(ByVal value As Date)
                mfecha_doc_ori = value
            End Set
        End Property

        Public Property codigo_doc_ori() As String
            Get
                Return mcodigo_doc_ori
            End Get
            Set(ByVal value As String)
                mcodigo_doc_ori = value
            End Set
        End Property



        Public Property serie_doc_ori() As String
            Get
                Return mserie_doc_ori
            End Get
            Set(ByVal value As String)
                mserie_doc_ori = value
            End Set
        End Property

        Public Property numero_doc_ori() As Integer
            Get
                Return mnumero_doc_ori
            End Get
            Set(ByVal value As Integer)
                mnumero_doc_ori = value
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

        Public Property serie() As String
            Get
                Return mserie
            End Get
            Set(ByVal value As String)
                mserie = value
            End Set
        End Property

        Public Property numero_int() As String
            Get
                Return mnumero_int
            End Get
            Set(ByVal value As String)
                mnumero_int = value
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

        Public Property almacenaid() As Integer
            Get
                Return malmacenaid
            End Get
            Set(ByVal value As Integer)
                malmacenaid = value
            End Set
        End Property

        Public Property tabla() As String
            Get
                Return mtabla
            End Get
            Set(ByVal value As String)
                mtabla = value
            End Set
        End Property

        Public Property idtabla() As String
            Get
                Return midtabla
            End Get
            Set(ByVal value As String)
                midtabla = value
            End Set
        End Property

        Public Property cod_ass() As Integer
            Get
                Return mcod_ass
            End Get
            Set(ByVal value As Integer)
                mcod_ass = value
            End Set
        End Property

        Public Property mes() As Integer
            Get
                Return mmes
            End Get
            Set(ByVal value As Integer)
                mmes = value
            End Set
        End Property

        Public Property anio() As Integer
            Get
                Return manio
            End Get
            Set(ByVal value As Integer)
                manio = value
            End Set
        End Property


    End Class
End Namespace



