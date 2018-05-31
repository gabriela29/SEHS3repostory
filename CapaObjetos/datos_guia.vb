Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class datos_guia

        Private mcodigo_ven As Long
        Private mfecha_trans As String
        Private mdesde As String
        Private mhasta As String
        Private mcodigo_emp As Long
        Private mruc_trans As String
        Private mnombre_trans As String
        Private mdireccion_trans As String
        Private mmarca As String
        Private mplaca As String
        Private mcodigo_cho As Long
        Private mdni_cho As String
        Private mape_pat As String
        Private mape_mat As String
        Private mnombre As String
        Private mnrolicencia As String





        Public Property codigo_ven() As Long
            Get
                Return mcodigo_ven
            End Get
            Set(ByVal value As Long)
                mcodigo_ven = value
            End Set
        End Property

        Public Property fecha_trans() As String
            Get
                Return mfecha_trans
            End Get
            Set(ByVal value As String)
                mfecha_trans = value
            End Set
        End Property
        Public Property desde() As String
            Get
                Return mdesde
            End Get
            Set(ByVal value As String)
                mdesde = value
            End Set
        End Property
        Public Property hasta() As String
            Get
                Return mhasta
            End Get
            Set(ByVal value As String)
                mhasta = value
            End Set
        End Property

        Public Property codigo_emp() As Long
            Get
                Return mcodigo_emp
            End Get
            Set(ByVal value As Long)
                mcodigo_emp = value
            End Set
        End Property

        Public Property ruc_trans() As String
            Get
                Return mruc_trans
            End Get
            Set(ByVal value As String)
                mruc_trans = value
            End Set
        End Property

        Public Property marca() As String
            Get
                Return mmarca
            End Get
            Set(ByVal value As String)
                mmarca = value
            End Set
        End Property

        Public Property placa()
            Get
                Return mplaca
            End Get
            Set(ByVal value)
                mplaca = value
            End Set
        End Property

        Public Property codigo_cho()
            Get
                Return mcodigo_cho
            End Get
            Set(ByVal value)
                mcodigo_cho = value
            End Set
        End Property

        Public Property nombre_trans() As String
            Get
                Return mnombre_trans
            End Get
            Set(ByVal value As String)
                mnombre_trans = value
            End Set
        End Property

        Public Property direccion_trans() As String
            Get
                Return mdireccion_trans
            End Get
            Set(ByVal value As String)
                mdireccion_trans = value
            End Set
        End Property

        Public Property dni_cho() As String
            Get
                Return mdni_cho
            End Get
            Set(ByVal value As String)
                mdni_cho = value
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

        Public Property nrolicencia() As String
            Get
                Return mnrolicencia
            End Get
            Set(ByVal value As String)
                mnrolicencia = value
            End Set
        End Property

    End Class
End Namespace
