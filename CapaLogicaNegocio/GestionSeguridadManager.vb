
Namespace Bll

  Public Class Configuracion
    Public Shared pObl_Detraccion As Boolean = True

    Public Shared pNom_Moneda As String
    Public Shared pSimbolo_Moneda As String

    Public Shared pIGV As Single
    Public Shared pDZMO As Single = 10
    Public Shared pLimiteRH As Integer
    Public Shared pRENTA As Integer = 8
    Public Shared pDETRAC As Single = 4


  End Class

  Public Class Variables_Temp
    Public Shared pCantidad As Single
  End Class

  Public Class GestionSeguridadManager
    Public Shared Servidor As String
    Public Shared idUsuario As Long
    Public Shared sUsuario As String
    Public Shared sNombeUS As String

    Public Shared gEmpresaId As Integer
    Public Shared gEmpresa As String
    Public Shared gDirEmpresa As String
    Public Shared gRUCEmp As String

    Public Shared gUnidadId As Integer
    Public Shared gUnidad As String
    Public Shared gEntidad As Integer

    Public Shared vDirAlmacen As String
    Public Shared vTelAlmacen As String

    Public Shared mAdministracion As Integer = 1
    Public Shared mTesoreria As Integer = 2
    Public Shared Serie As String
    Public Shared NombrePC As String
        Public Shared miIP As String
        Public Shared nnumero As String
        Public Shared vConexion As String



    End Class

  Public Class Gestion_Permisos_Especiales

    Public Shared edit_persona As Boolean
    Public Shared edit_ocupacion As Boolean
    Public Shared edit_user As Boolean
    Public Shared edit_password As Boolean
    Public Shared show_password As Boolean
    Public Shared cons_asistencia As Boolean
    Public Shared cons_nota As Boolean
    Public Shared cons_anecdotico As Boolean
    Public Shared cons_obligacion As Boolean
    Public Shared cons_imagen As Boolean
    Public Shared mat_add As Boolean
    Public Shared mat_edit As Boolean
    Public Shared mat_delete As Boolean
    Public Shared mat_cambiar_proceso As Boolean
    Public Shared mat_detalle As Boolean
    Public Shared obl_add As Boolean
    Public Shared obl_edit As Boolean
    Public Shared obl_delete As Boolean
    Public Shared obl_close As Boolean
    Public Shared ope_add As Boolean
    Public Shared ope_edit As Boolean
    Public Shared ope_delete As Boolean
    Public Shared ope_close As Boolean
    Public Shared ope_state As Boolean
    Public Shared mat_con_saldo As Boolean

    Public Shared venForzarConStock As Boolean
    Public Shared venCambiar_Precio As Boolean
    Public Shared venCambiar_Descuento As Boolean
  End Class

  Public Class GestionModulos
    Public Shared modIngreso As Integer = 1
    Public Shared modSalida As Integer = 2
    Public Shared modVentas As Integer = 3
    Public Shared modColportaje As Integer = 4
    Public Shared modGastos As Integer = 5
  End Class

  Public Class Tipo_Mov_Mercaderia
    Public Shared tCompras As Integer = 1
    Public Shared tTraslado As Integer = 2
    Public Shared tInv_Ini As Integer = 3
    Public Shared tVentas As Integer = 5
    Public Shared tConsignacion As Integer = 6
    Public Shared tDistribucion As Integer = 7
    Public Shared tPagos As Integer = 8
    Public Shared tDevolucion As Integer = 9
    Public Shared tProforma As Integer = 10
    Public Shared tAJUSTE As Integer = 11
  End Class

  Public Class Tipo_Mov_Bancario
    Public Shared tVenta As Integer = 1
    Public Shared tAmortCXC As Integer = 2
    Public Shared tSalida As Integer = 3
    Public Shared tIngreso As Integer = 7
    Public Shared tAmortCXP As Integer = 8
    Public Shared tAnticipo As Integer = 10

  End Class
  Public Class GestionTablas
    Public Shared dtMenu As DataTable
    Public Shared dtUnidad As DataTable
    Public Shared dtAlmacen As DataTable
    Public Shared dtFAlmacen As DataView
    Public Shared dtperdoc As DataTable
    Public Shared dtPermisos As DataTable
    Public Shared dtplan As DataTable
    Public Shared dtctacte As DataTable
    Public Shared dtconf As DataTable
    Public Shared dtTemp As DataTable
  End Class

  'Public Class Valores_Sunat
  '  Public Shared pIGV As Single
  '  Public Shared pDZMO As Single = 10
  '  Public Shared pLimiteRH As Integer
  '  Public Shared pRENTA As Integer = 8
  '  Public Shared pDETRAC As Single = 4
  'End Class

  Public Class Valores_Temp
    Public Shared pCodigo_Per As String
    Public Shared pTipoPer As String
    Public Shared pApe_Pat As String
    Public Shared pApe_Mat As String
    Public Shared pNombre As String
    Public Shared pRaz As String
    Public Shared pDNI As String
    Public Shared pRUC As String
    Public Shared pDireccion As String
    Public Shared pOk As Boolean

  End Class

  Public Class ServicioAssinet
    Public Shared Function pServicioAssinet(ByVal vEntidad As Integer) As String
      Dim xEndPonit As String = ""

      If vEntidad = 7114 Then
        xEndPonit = ""
      End If

      Return xEndPonit

    End Function


  End Class

End Namespace
