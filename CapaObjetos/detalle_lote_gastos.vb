Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO

    Public Class detalle_lote_gastos

        Private mcodigo As Long = -1
        Private mcodigo_lote As Long        
        Private mcodigo_doc As Integer
        Private mserie As String
        Private mnumero As String
        Private mruc As String
        Private memision As String
        Private mvencimiento As String
        Private mregistro As String
        Private mcondicion As String
        Private mcodigo_con As Long
        Private mnrocuenta As String
        Private mglosa As String
        Private mtipo_importe As Integer
        Private mafecto As Single
        Private minafecto As Single
        Private mimporte_igv As Single
        Private mimporte_isc As Single
        Private mimporte_renta As Single
        Private mimporte_sp As Single
        Private motros As Single
        Private mtotal As Single
        Private mvalor_igv As Single
        Private mvalor_isc As Single
        Private mvalor_renta As Single
        Private mcomision As Single
        Private mtipo_sp As Integer
        Private mmoneda As String
        Private mcambio As Single
        Private msigno As String
        Private mcodigo_ref As Long
        Private mcodigo_usu As Long
        Private mcaja As String
        Private mactivo As Boolean
        Private mmixto As Boolean
        Private mtipo As String
        'Datos Varios
        Private mnumero_f As String
        Private mnumero_nodomi As String
        Private manio_emision As String
        Private mdep_aduanera As String
        Private mestado As Integer
        'Datos extras        
        Private mproveedor As String
        Private mdireccion As String
        Private mnumero_ref As String
        Private mmonto_ref As Single

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property

        Public Property codigo_lote() As Long
            Get
                Return mcodigo_lote
            End Get
            Set(ByVal value As Long)
                mcodigo_lote = value
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

        Public Property serie() As String
            Get
                Return mserie
            End Get
            Set(ByVal value As String)
                mserie = value
            End Set
        End Property

        Public Property numero() As String
            Get
                Return mnumero
            End Get
            Set(ByVal value As String)
                mnumero = value
            End Set
        End Property

        Public Property emision() As String
            Get
                Return memision
            End Get
            Set(ByVal value As String)
                memision = value
            End Set
        End Property

        Public Property vencimiento() As String
            Get
                Return mvencimiento
            End Get
            Set(ByVal value As String)
                mvencimiento = value
            End Set
        End Property

        Public Property registro() As String
            Get
                Return mregistro
            End Get
            Set(ByVal value As String)
                mregistro = value
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

        Public Property codigo_con() As Long
            Get
                Return mcodigo_con
            End Get
            Set(ByVal value As Long)
                mcodigo_con = value
            End Set
        End Property

        Public Property nrocuenta() As String
            Get
                Return mnrocuenta
            End Get
            Set(ByVal value As String)
                mnrocuenta = value
            End Set
        End Property

        Public Property glosa() As String
            Get
                Return mglosa
            End Get
            Set(ByVal value As String)
                mglosa = value
            End Set
        End Property

        Public Property tipo_importe() As Integer
            Get
                Return mtipo_importe
            End Get
            Set(ByVal value As Integer)
                mtipo_importe = value
            End Set
        End Property

        Public Property afecto() As Single
            Get
                Return mafecto
            End Get
            Set(ByVal value As Single)
                mafecto = value
            End Set
        End Property

        Public Property inafecto() As Single
            Get
                Return minafecto
            End Get
            Set(ByVal value As Single)
                minafecto = value
            End Set
        End Property

        Public Property importe_igv() As Single
            Get
                Return mimporte_igv
            End Get
            Set(ByVal value As Single)
                mimporte_igv = value
            End Set
        End Property

        Public Property importe_sc() As Single
            Get
                Return mimporte_isc
            End Get
            Set(ByVal value As Single)
                mimporte_isc = value
            End Set
        End Property

        Public Property importe_renta() As Single
            Get
                Return mimporte_renta
            End Get
            Set(ByVal value As Single)
                mimporte_renta = value
            End Set
        End Property

        Public Property importe_sp() As Single
            Get
                Return mimporte_sp
            End Get
            Set(ByVal value As Single)
                mimporte_sp = value
            End Set
        End Property

        Public Property otros() As Single
            Get
                Return motros
            End Get
            Set(ByVal value As Single)
                motros = value
            End Set
        End Property

        Public Property total() As Single
            Get
                Return mtotal
            End Get
            Set(ByVal value As Single)
                mtotal = value
            End Set
        End Property

        Public Property valor_igv() As Single
            Get
                Return mvalor_igv
            End Get
            Set(ByVal value As Single)
                mvalor_igv = value
            End Set
        End Property

        Public Property valor_isc() As Single
            Get
                Return mvalor_isc
            End Get
            Set(ByVal value As Single)
                mvalor_isc = value
            End Set
        End Property

        Public Property valor_renta() As Single
            Get
                Return mvalor_renta
            End Get
            Set(ByVal value As Single)
                mvalor_renta = value
            End Set
        End Property

        Public Property comision() As Single
            Get
                Return mcomision
            End Get
            Set(ByVal value As Single)
                mcomision = value
            End Set
        End Property

        Public Property tipo_sp() As Integer
            Get
                Return mtipo_sp
            End Get
            Set(ByVal value As Integer)
                mtipo_sp = value
            End Set
        End Property

        Public Property moneda() As String
            Get
                Return mmoneda
            End Get
            Set(ByVal value As String)
                mmoneda = value
            End Set
        End Property

        Public Property cambio() As Single
            Get
                Return mcambio
            End Get
            Set(ByVal value As Single)
                mcambio = value
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

        Public Property codigo_ref() As Long
            Get
                Return mcodigo_ref
            End Get
            Set(ByVal value As Long)
                mcodigo_ref = value
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

        Public Property codigo_usu() As Long
            Get
                Return mcodigo_usu
            End Get
            Set(ByVal value As Long)
                mcodigo_usu = value
            End Set
        End Property

        Public Property activo() As Boolean
            Get
                Return mactivo
            End Get
            Set(ByVal value As Boolean)
                mactivo = value
            End Set
        End Property

        Public Property mixto() As Boolean
            Get
                Return mmixto
            End Get
            Set(ByVal value As Boolean)
                mmixto = value
            End Set
        End Property

        Public Property tipo() As String
            Get
                Return mtipo
            End Get
            Set(ByVal value As String)
                mtipo = value
            End Set
        End Property


        Public Property numero_f() As String
            Get
                Return mnumero_f
            End Get
            Set(ByVal value As String)
                mnumero_f = value
            End Set
        End Property

        Public Property numero_nodomi() As String
            Get
                Return mnumero_nodomi
            End Get
            Set(ByVal value As String)
                mnumero_nodomi = value
            End Set
        End Property

        Public Property anio_emision() As String
            Get
                Return manio_emision
            End Get
            Set(ByVal value As String)
                manio_emision = value
            End Set
        End Property

        Public Property dep_aduanera() As String
            Get
                Return mdep_aduanera
            End Get
            Set(ByVal value As String)
                mdep_aduanera = value
            End Set
        End Property

        Public Property estado() As String
            Get
                Return mestado
            End Get
            Set(ByVal value As String)
                mestado = value
            End Set
        End Property



        Public Property ruc() As String
            Get
                Return mruc
            End Get
            Set(ByVal value As String)
                mruc = value
            End Set
        End Property

        Public Property proveedor() As String
            Get
                Return mproveedor
            End Get
            Set(ByVal value As String)
                mproveedor = value
            End Set
        End Property

        Public Property direccion() As String
            Get
                Return mdireccion
            End Get
            Set(ByVal value As String)
                mdireccion = value
            End Set
        End Property

        Public Property numero_ref() As String
            Get
                Return mnumero_ref
            End Get
            Set(ByVal value As String)
                mnumero_ref = value
            End Set
        End Property

        Public Property monto_ref() As Single
            Get
                Return monto_ref
            End Get
            Set(ByVal value As Single)
                mmonto_ref = value
            End Set
        End Property
    End Class
End Namespace
