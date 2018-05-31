Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class persona

        Private mpersonaid As Long = -1
        Private mtipo As String
        Private mrol As String
        Private mdireccion As String
        Private mtelefono As String
        Private memail As String
        Private mestado As Boolean
        Private mregistro As Date
        Private mdistritoid As Long
        Private mfoto As String
        Private mnombre_comercial As String
        Private mtitulo As String
        Private mape_pat As String
        Private mape_mat As String
        Private mnombre As String
        Private mnacimiento As String
        Private mdni As String
        Private mpernat_ruc As String
        Private msexo As String
        Private mest_civil As String
        Private mraz_soc As String
        Private mruc As String
        Private mdepartamentoid As Long
        Private mprovinciaid As Long
        Private mdepartamento_nombre As String
        Private mprovincia_nombre As String
        Private mdistrito_nombre As String
        Private mape_pat_mayus As String
        Private mape_mat_mayus As String
        Private mnombre_mayus As String
        Private mape_pat_ab As String
        Private mape_mat_ab As String
        Private mnombre_ab As String
        Private musuarioid As Long
        Private mip As String

        Private mnrolicencia As String
        Private mnrocuenta As String
        Private mc_costo As String
        Private mcodio_Asis As Long
        Private msaldo As Single

        Public Property personaid() As Long
            Get
                Return mpersonaid
            End Get
            Set(ByVal value As Long)
                mpersonaid = value
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

        Public Property rol() As String
            Get
                Return mrol
            End Get
            Set(ByVal value As String)
                mrol = value
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

        Public Property telefono() As String
            Get
                Return mtelefono
            End Get
            Set(ByVal value As String)
                mtelefono = value
            End Set
        End Property

        Public Property email() As String
            Get
                Return memail
            End Get
            Set(ByVal value As String)
                memail = value
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

        Public Property registro() As Date
            Get
                Return mregistro
            End Get
            Set(ByVal value As Date)
                mregistro = value
            End Set
        End Property

        Public Property distritoid() As Long
            Get
                Return mdistritoid
            End Get
            Set(ByVal value As Long)
                mdistritoid = value
            End Set
        End Property

        Public Property foto() As String
            Get
                Return mfoto
            End Get
            Set(ByVal value As String)
                mfoto = value
            End Set
        End Property

        Public Property nombre_comercial() As String
            Get
                Return mnombre_comercial
            End Get
            Set(ByVal value As String)
                mnombre_comercial = value
            End Set
        End Property

        Public Property titulo() As String
            Get
                Return mtitulo
            End Get
            Set(ByVal value As String)
                mtitulo = value
            End Set
        End Property

        Public Property ape_pat() As String
            Get
                Return mape_pat
            End Get
            Set(ByVal value As String)
                mape_pat = value
            End Set
        End Property

        Public Property ape_mat() As String
            Get
                Return mape_mat
            End Get
            Set(ByVal value As String)
                mape_mat = value
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

        Public Property nacimiento() As String
            Get
                Return mnacimiento
            End Get
            Set(ByVal value As String)
                mnacimiento = value
            End Set
        End Property

        Public Property dni() As String
            Get
                Return mdni
            End Get
            Set(ByVal value As String)
                mdni = value
            End Set
        End Property

        Public Property pernat_ruc() As String
            Get
                Return mpernat_ruc
            End Get
            Set(ByVal value As String)
                mpernat_ruc = value
            End Set
        End Property

        Public Property sexo() As String
            Get
                Return msexo
            End Get
            Set(ByVal value As String)
                msexo = value
            End Set
        End Property

        Public Property est_civil() As String
            Get
                Return mest_civil
            End Get
            Set(ByVal value As String)
                mest_civil = value
            End Set
        End Property

        Public Property raz_soc() As String
            Get
                Return mraz_soc
            End Get
            Set(ByVal value As String)
                mraz_soc = value
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

        Public Property departamentoid() As Long
            Get
                Return mdepartamentoid
            End Get
            Set(ByVal value As Long)
                mdepartamentoid = value
            End Set
        End Property

        Public Property provinciaid() As Long
            Get
                Return mprovinciaid
            End Get
            Set(ByVal value As Long)
                mprovinciaid = value
            End Set
        End Property

        Public Property departamento_nombre() As String
            Get
                Return mdepartamento_nombre
            End Get
            Set(ByVal value As String)
                mdepartamento_nombre = value
            End Set
        End Property

        Public Property provincia_nombre() As String
            Get
                Return mprovincia_nombre
            End Get
            Set(ByVal value As String)
                mprovincia_nombre = value
            End Set
        End Property

        Public Property distrito_nombre() As String
            Get
                Return mdistrito_nombre
            End Get
            Set(ByVal value As String)
                mdistrito_nombre = value
            End Set
        End Property

        Public Property ape_pat_mayus() As String
            Get
                Return mape_pat_mayus
            End Get
            Set(ByVal value As String)
                mape_pat_mayus = value
            End Set
        End Property

        Public Property ape_mat_mayus() As String
            Get
                Return mape_mat_mayus
            End Get
            Set(ByVal value As String)
                mape_mat_mayus = value
            End Set
        End Property

        Public Property nombre_mayus() As String
            Get
                Return mnombre_mayus
            End Get
            Set(ByVal value As String)
                mnombre_mayus = value
            End Set
        End Property

        Public Property ape_pat_ab() As String
            Get
                Return mape_pat_ab
            End Get
            Set(ByVal value As String)
                mape_pat_ab = value
            End Set
        End Property

        Public Property ape_mat_ab() As String
            Get
                Return mape_mat_ab
            End Get
            Set(ByVal value As String)
                mape_mat_ab = value
            End Set
        End Property

        Public Property nombre_ab() As String
            Get
                Return mnombre_ab
            End Get
            Set(ByVal value As String)
                mnombre_ab = value
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

        Public Property ip() As String
            Get
                Return mip
            End Get
            Set(ByVal value As String)
                mip = value
            End Set
        End Property


        Public Property nrolicencia() As String
            Get
                Return mnrolicencia
            End Get
            Set(ByVal value As String)
                mnrolicencia = value
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

        Public Property c_costo() As String
            Get
                Return mc_costo
            End Get
            Set(ByVal value As String)
                mc_costo = value
            End Set
        End Property

        Public Property codio_Asis() As Long
            Get
                Return mcodio_Asis
            End Get
            Set(ByVal value As Long)
                mcodio_Asis = value
            End Set
        End Property

        Public Property saldo() As Long
            Get
                Return msaldo
            End Get
            Set(ByVal value As Long)
                msaldo = value
            End Set
        End Property
    End Class
End Namespace
