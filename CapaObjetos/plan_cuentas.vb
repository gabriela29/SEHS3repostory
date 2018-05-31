Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class plan_cuentas

        Private mcodigo As Long = -1

        Private mcuenta As Long
        Private mctacte As Long
        Private msct As Long
        Private mnombrecta As String
        Private mctamaestra As String
        Private mnivel As Long
        Private mabrev As String
        Private mentidad As String

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property
        Public Property cuenta() As Long
            Get
                Return mcuenta
            End Get
            Set(ByVal value As Long)
                mcuenta = value
            End Set
        End Property
        Public Property ctacte() As Long
            Get
                Return mctacte
            End Get
            Set(ByVal value As Long)
                mctacte = value
            End Set
        End Property
        Public Property sct() As Long
            Get
                Return msct
            End Get
            Set(ByVal value As Long)
                msct = value
            End Set
        End Property
        Public Property nombrecta() As String
            Get
                Return mnombrecta
            End Get
            Set(ByVal value As String)
                mnombrecta = value
            End Set
        End Property
        Public Property ctamaestra() As String
            Get
                Return mctamaestra
            End Get
            Set(ByVal value As String)
                mctamaestra = value
            End Set
        End Property
        Public Property nivel() As Long
            Get
                Return mnivel
            End Get
            Set(ByVal value As Long)
                mnivel = value
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

        Public Property entidad() As String
            Get
                Return mentidad
            End Get
            Set(ByVal value As String)
                mentidad = value
            End Set
        End Property

    End Class
End Namespace
