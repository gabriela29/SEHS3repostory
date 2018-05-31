Imports System
Imports System.Data
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO

Namespace Bll

  Public Class clsCtrlPagosDataSet

    Public Function MkCtrlPagosDataSet(ByVal DtDoc As DataTable, ByVal DtDet As DataTable) As DataSet

      ' Declaramos el DataSet para contener la informacion en Arbol
      Dim workDataSet As DataSet = New System.Data.DataSet("EstadoCuenta")

      ' Agragamos la DataTable Obligaciones
      ''Dim custData As New CrearGridOblManager()
      workDataSet.Tables.Add(DtDoc)

      ' Agregamos los Abonos
      ''Dim ordData As New CrearGridPagosManager()
      workDataSet.Tables.Add(DtDet) 'ordData.GetList(workDataSet.Tables("Cabecera"), "Detalle", DtDet))

      ' Creamos la Relacion entre Las Obligaciones y los Abonos Mediante el Código
      'If DtDet.Rows.Count > 0 Then


      Dim relCustOrder As New DataRelation("EstadoCta" _
          , workDataSet.Tables("Cabecera").Columns("codigo") _
          , workDataSet.Tables("Detalle").Columns("codigo"))
      workDataSet.Relations.Add(relCustOrder)

      'End If
      ' Retornamos el DataSet
      Return workDataSet

    End Function

  End Class

  '=======Inicio Grid Estado de Cuenta ======================================================================
  Public Class CrearGridOblManager
    Public Function GetList(ByVal NomTable As String, ByVal DtData As DataTable) As DataTable
      Dim MisPar(28) As String, MisTipos(28) As String, objDt As DataTable

      MisPar(0) = "codigo"
      MisTipos(0) = "System.Single"
      MisPar(1) = "fecha"
      MisTipos(1) = "System.DateTime"
      MisPar(2) = "codigo_con"
      MisTipos(2) = "System.Int32"
      MisPar(3) = "concepto"
      MisTipos(3) = "System.String"
      MisPar(4) = "mes_cuota"
      MisTipos(4) = "System.Int32"
      MisPar(5) = "importe"
      MisTipos(5) = "System.Single"
      MisPar(6) = "descuento"
      MisTipos(6) = "System.Single"
      MisPar(7) = "saldo"
      MisTipos(7) = "System.Single"
      MisPar(8) = "vencimiento"
      MisTipos(8) = "System.DateTime"
      MisPar(9) = "fecha_prorroga"
      MisTipos(9) = "System.String"
      MisPar(10) = "importe_prorroga"
      MisTipos(10) = "System.Single"
      MisPar(11) = "unidad"
      MisTipos(11) = "System.String"
      MisPar(12) = "proceso"
      MisTipos(12) = "System.String"
      MisPar(13) = "ano_proceso"
      MisTipos(13) = "System.Int32"
      MisPar(14) = "obl_principal"
      MisTipos(14) = "System.Int32"
      MisPar(15) = "codigo_pro"
      MisTipos(15) = "System.Int32"
      MisPar(16) = "caja"
      MisTipos(16) = "System.String"
      MisPar(17) = "usuario"
      MisTipos(17) = "System.String"
      MisPar(18) = "cerrado"
      MisTipos(18) = "System.Boolean"
      MisPar(19) = "estado"
      MisTipos(19) = "System.Boolean"
      MisPar(20) = "codigo_alu"
      MisTipos(20) = "System.Single"
      MisPar(21) = "codigo_uni"
      MisTipos(21) = "System.Int32"
      MisPar(22) = "provisionada"
      MisTipos(22) = "System.Int32"
      MisPar(23) = "generada"
      MisTipos(23) = "System.Boolean"
      MisPar(24) = "codigo_ref"
      MisTipos(24) = "System.Single"
      MisPar(25) = "orden"
      MisTipos(25) = "System.Int32"
      MisPar(26) = "genera_mora"
      MisTipos(26) = "System.Boolean"
      MisPar(27) = "mora_generada"
      MisTipos(27) = "System.Boolean"

      objDt = DataTableDesvinculado.GenerarDataTable(NomTable, MisPar, MisTipos)

      Return objDt
    End Function


  End Class

  '=======Fin Grid Estado de Cuenta===========================================================================
  '================================================================================================



  '=======Inicio Grid Pagos y/o Abonos====================================================================
  Public Class CrearGridPagosManager
    Public Function GetList(ByVal v_cabeceraDataTable As DataTable, ByVal NomTable As String, ByVal DtDet As DataTable) As DataTable
      Dim MyPar(12) As String, MyTip(12) As String, objDtp As DataTable

      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "codigo_ope"
      MyTip(1) = "System.Single"
      MyPar(2) = "fecha"
      MyTip(2) = "System.DateTime"
      MyPar(3) = "importe"
      MyTip(3) = "System.Single"
      MyPar(4) = "codigo_doc"
      MyTip(4) = "System.Int32"
      MyPar(5) = "documento"
      MyTip(5) = "System.String"
      MyPar(6) = "numero"
      MyTip(6) = "System.String"
      MyPar(7) = "lugar_pago"
      MyTip(7) = "System.String"
      MyPar(8) = "usuario"
      MyTip(8) = "System.String"
      MyPar(9) = "caja"
      MyTip(9) = "System.String"
      MyPar(10) = "signo"
      MyTip(10) = "System.String"
      MyPar(11) = "estado"
      MyTip(11) = "System.Boolean"


      objDtp = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtp
    End Function


  End Class

  '=======Fin Grid Abonos=======================================================================

  '=======Inicio Meses====================================================================
  Public Class ClsCrearMeses
    Public Function GetList(ByVal Abrev As Boolean, ByVal SoloM As Boolean) As DataTable
      Dim MyPar(2) As String, MyTip(2) As String, objDt As DataTable
      Dim NwRow As DataRow, x As Int16
      MyPar(0) = "codigo"
      MyTip(0) = "System.Int16"
      MyPar(1) = "nombre"
      MyTip(1) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("monthname", MyPar, MyTip)

      For x = IIf(SoloM, 1, 0) To 12
        NwRow = objDt.NewRow
        NwRow.Item("codigo") = x
        NwRow.Item("nombre") = MonthName(x, Abrev)
        objDt.Rows.Add(NwRow)
      Next

      Return objDt
    End Function

    Private Function MonthName(ByVal nMes As Int16, ByVal Abrev As Boolean) As String
      Dim xNomb As String
      xNomb = ""
      Select Case nMes
        Case 0
          xNomb = "Seleccione"
        Case 1
          xNomb = IIf(Abrev, "Ene", "Enero")
        Case 2
          xNomb = IIf(Abrev, "Feb", "Febrero")
        Case 3
          xNomb = IIf(Abrev, "Mar", "Marzo")
        Case 4
          xNomb = IIf(Abrev, "Abrl", "Abril")
        Case 5
          xNomb = IIf(Abrev, "May", "Mayo")
        Case 6
          xNomb = IIf(Abrev, "Jun", "Junio")
        Case 7
          xNomb = IIf(Abrev, "Jul", "Julio")
        Case 8
          xNomb = IIf(Abrev, "Ago", "Agosto")
        Case 9
          xNomb = IIf(Abrev, "Sep", "Septiembre")
        Case 10
          xNomb = IIf(Abrev, "Oct", "Octubre")
        Case 11
          xNomb = IIf(Abrev, "Nov", "Noviembre")
        Case 12
          xNomb = IIf(Abrev, "Dic", "Diciembre")
      End Select
      Return xNomb
    End Function

    Public Function GetList_anios() As DataTable
      Dim MyPar(1) As String, MyTip(1) As String, objDt As DataTable
      Dim NwRow As DataRow, x As Int16
      MyPar(0) = "nombre"
      MyTip(0) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("anios", MyPar, MyTip)

      For x = Year(Now.Date) - 5 To Year(Now.Date) + 5
        NwRow = objDt.NewRow
        NwRow.Item("nombre") = x
        objDt.Rows.Add(NwRow)
      Next

      Return objDt
    End Function
  End Class
  '=======Fin Meses=======================================================================

  '==============================================================================================================
  Public Class ClsTablitas
    Public Shared Function Get_Direccion(ByVal NomTable As String) As DataTable
      Dim MyPar(3) As String, MyTip(3) As String, objDtf As DataTable
      'sucursal,direccion
      MyPar(0) = "sucursal"
      MyTip(0) = "System.String"

      MyPar(1) = "direccion"
      MyTip(1) = "System.String"

      MyPar(2) = "personadireccionid"
      MyTip(2) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("key2", objDtf.Columns("personadireccionid"), True)

      Return objDtf
    End Function

    Public Shared Function Get_Telefono(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      'sucursal,direccion
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"

      MyPar(1) = "tipotelefonoid"
      MyTip(1) = "System.Single"

      MyPar(2) = "tipo"
      MyTip(2) = "System.String"

      MyPar(3) = "numero"
      MyTip(3) = "System.String"

      MyPar(4) = "detalle"
      MyTip(4) = "System.String"

      MyPar(5) = "principal"
      MyTip(5) = "System.Boolean"

      MyPar(6) = "publico"
      MyTip(6) = "System.Boolean"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("codigopk", objDtf.Columns("codigo"), True)

      Return objDtf
    End Function

    Public Shared Function Get_EMail(ByVal NomTable As String) As DataTable
      Dim MyPar(3) As String, MyTip(3) As String, objDtf As DataTable
      'sucursal,direccion
      MyPar(0) = "codigo"
      MyTip(0) = "System.String"

      MyPar(1) = "tipo"
      MyTip(1) = "System.String"

      MyPar(2) = "email"
      MyTip(2) = "System.String"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("keyem", objDtf.Columns("codigo"), True)

      Return objDtf
    End Function

    Public Shared Function Get_Sociales(ByVal NomTable As String) As DataTable
      Dim MyPar(3) As String, MyTip(3) As String, objDtf As DataTable
      'sucursal,direccion
      MyPar(0) = "tiposocialmediaid"
      MyTip(0) = "System.String"

      MyPar(1) = "tipo"
      MyTip(1) = "System.String"

      MyPar(2) = "url"
      MyTip(2) = "System.String"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("keyrs", objDtf.Columns("tiposocialmediaid"), True)

      Return objDtf
    End Function

    Public Shared Function Get_Distribucion_Gasto(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "fondo"
      MyTip(0) = "System.Single"

      MyPar(1) = "cuenta"
      MyTip(1) = "System.String"
      MyPar(2) = "ctacte"
      MyTip(2) = "System.String"

      MyPar(3) = "centro_costo"
      MyTip(3) = "System.String"
      MyPar(4) = "importe"
      MyTip(4) = "System.Single"

      MyPar(5) = "glosa"
      MyTip(5) = "System.String"

      MyPar(6) = "id"
      MyTip(6) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("key7", objDtf.Columns("id"), True)

      Return objDtf

    End Function

    Public Shared Function Get_Asiento(ByVal NomTable As String) As DataTable
      Dim MyPar(14) As String, MyTip(14) As String, objDtf As DataTable

      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"

      MyPar(1) = "fecha"
      MyTip(1) = "System.DateTime"

      MyPar(2) = "cuenta"
      MyTip(2) = "System.Single"

      MyPar(3) = "nom_cuenta"
      MyTip(3) = "System.String"

      MyPar(4) = "ctacte"
      MyTip(4) = "System.String"

      MyPar(5) = "nom_ctacte"
      MyTip(5) = "System.String"

      MyPar(6) = "fondoid"
      MyTip(6) = "System.Single"

      MyPar(7) = "fondo"
      MyTip(7) = "System.String"

      MyPar(8) = "centro_costo"
      MyTip(8) = "System.String"

      MyPar(9) = "restriccion"
      MyTip(9) = "System.String"

      MyPar(10) = "importe"
      MyTip(10) = "System.Single"

      MyPar(11) = "importeme"
      MyTip(11) = "System.Single"

      MyPar(12) = "glosa"
      MyTip(12) = "System.String"

      'MyPar(13) = "num_factrua"
      'MyTip(13) = "System.String"

      'MyPar(14) = "fecha_factura"
      'MyTip(14) = "System.String"

      'MyPar(15) = "vence_factura"
      'MyTip(15) = "System.String"

      MyPar(13) = "id"
      MyTip(13) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("key7", objDtf.Columns("id"), True)

      Return objDtf

    End Function

    Public Function Get_Tipo_Lote(ByVal Abrev As Boolean) As DataTable
      Dim MyPar(2) As String, MyTip(2) As String, objDt As DataTable
      Dim NwRow As DataRow
      MyPar(0) = "codigo"
      MyTip(0) = "System.Int16"
      MyPar(1) = "nombre"
      MyTip(1) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("tipolote", MyPar, MyTip)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 0
      NwRow.Item("nombre") = "Todos"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 1
      NwRow.Item("nombre") = "RC"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 2
      NwRow.Item("nombre") = "RH"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 3
      NwRow.Item("nombre") = "RI"
      objDt.Rows.Add(NwRow)

      Return objDt
    End Function

    Public Function Get_Estado_Lote(ByVal Abrev As Boolean) As DataTable
      Dim MyPar(2) As String, MyTip(2) As String, objDt As DataTable
      Dim NwRow As DataRow
      MyPar(0) = "codigo"
      MyTip(0) = "System.Int16"
      MyPar(1) = "nombre"
      MyTip(1) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("estadolote", MyPar, MyTip)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 0
      NwRow.Item("nombre") = "Todos"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 1
      NwRow.Item("nombre") = "Contabilizados"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 2
      NwRow.Item("nombre") = "Por Reponer"
      objDt.Rows.Add(NwRow)

      NwRow = objDt.NewRow
      NwRow.Item("codigo") = 3
      NwRow.Item("nombre") = "Por Cerrar"
      objDt.Rows.Add(NwRow)

      Return objDt
    End Function

    Public Shared Function Get_Grupos_VIP(ByVal vNombre As String) As DataTable
      Dim MyPar(6) As String, MyTip(6) As String, objDt As DataTable
      'codigo_gru integer, grupo varchar, cantidad long, max_facturar integer, emitido integer, saldo
      MyPar(0) = "codigo_gru"
      MyTip(0) = "System.Int32"

      MyPar(1) = "grupo"
      MyTip(1) = "System.String"

      MyPar(2) = "cantidad"
      MyTip(2) = "System.Int32"

      MyPar(3) = "facturar"
      MyTip(3) = "System.Int32"

      MyPar(4) = "emitido"
      MyTip(4) = "System.Int32"

      MyPar(5) = "saldo"
      MyTip(5) = "System.Int32"

      objDt = DataTableDesvinculado.GenerarDataTable("dtgrupovip", MyPar, MyTip)


      Return objDt
    End Function

    Public Shared Function Crear_Grid_Kardex(ByVal NomTable As String) As DataTable
      Dim MyPar(16) As String, MyTip(16) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "fecha"
      MyTip(0) = "System.DateTime"
      MyPar(1) = "num_doc"
      MyTip(1) = "System.String"
      MyPar(2) = "tipo"
      MyTip(2) = "System.Int32"
      MyPar(3) = "Detalle"
      MyTip(3) = "System.String"
      MyPar(4) = "CantCompra"
      MyTip(4) = "System.Single"
      MyPar(5) = "PreCompra"
      MyTip(5) = "System.Single"
      MyPar(6) = "TotCompra"
      MyTip(6) = "System.Single"

      MyPar(7) = "CantVenta"
      MyTip(7) = "System.Single"
      MyPar(8) = "PreVenta"
      MyTip(8) = "System.Single"
      MyPar(9) = "TotVenta"
      MyTip(9) = "System.Single"

      MyPar(10) = "CantSaldo"
      MyTip(10) = "System.Single"
      MyPar(11) = "PreSaldo"
      MyTip(11) = "System.Single"
      MyPar(12) = "TotSaldo"
      MyTip(12) = "System.Single"
      MyPar(13) = "Totales"
      MyTip(13) = "System.Single"
      MyPar(14) = "ref"
      MyTip(14) = "System.String"
      MyPar(15) = "codigo"
      MyTip(15) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      Return objDtf
    End Function

    Public Shared Function Get_Plan_Cuentas(ByVal vNombre As String) As DataTable
      Dim MyPar(13) As String, MyTip(13) As String, objDt As DataTable

      MyPar(0) = "Code"
      MyTip(0) = "System.Int32"

      MyPar(1) = "Name"
      MyTip(1) = "System.String"

      MyPar(2) = "Id"
      MyTip(2) = "System.Int32"

      MyPar(3) = "IsActive"
      MyTip(3) = "System.Boolean"

      MyPar(4) = "Nature"
      MyTip(4) = "System.Int32"

      MyPar(5) = "ParentCode"
      MyTip(5) = "System.String"

      MyPar(6) = "ParentId"
      MyTip(6) = "System.Int32"

      MyPar(7) = "Account_Id"
      MyTip(7) = "System.Int32"

      MyPar(8) = "RestringCode"
      MyTip(8) = "System.String"

      MyPar(9) = "RestringName"
      MyTip(9) = "System.String"

      MyPar(10) = "SubCtaCode"
      MyTip(10) = "System.String"

      MyPar(11) = "SubCtaName"
      MyTip(11) = "System.String"

      MyPar(12) = "vEnumType"
      MyTip(12) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("dtplanctas", MyPar, MyTip)


      Return objDt
    End Function

    Public Shared Function Get_Plan_ctacte(ByVal vNombre As String) As DataTable
      Dim MyPar(4) As String, MyTip(4) As String, objDt As DataTable
      'ctacte,nombre,subctacode,subctaid
      MyPar(0) = "ctacte"
      MyTip(0) = "System.String"

      MyPar(1) = "nombre"
      MyTip(1) = "System.String"

      MyPar(2) = "subctacode"
      MyTip(2) = "System.String"

      MyPar(3) = "subctaid"
      MyTip(3) = "System.Int32"

      objDt = DataTableDesvinculado.GenerarDataTable("dtctactes", MyPar, MyTip)


      Return objDt
    End Function

    Public Shared Function Get_Persona_Us(ByVal vNombre As String) As DataTable
      Dim MyPar(3) As String, MyTip(3) As String, objDt As DataTable
      'codigo_gru integer, grupo varchar, cantidad long, max_facturar integer, emitido integer, saldo
      MyPar(0) = "personaid"
      MyTip(0) = "System.Int32"

      MyPar(1) = "nombre"
      MyTip(1) = "System.String"

      MyPar(2) = "acceso"
      MyTip(2) = "System.String"

      objDt = DataTableDesvinculado.GenerarDataTable("dtpersonaus", MyPar, MyTip)


      Return objDt
    End Function

    Public Shared Function Get_Facturacion_Anticipo(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "depositoid"
      MyTip(0) = "System.Single"

      MyPar(1) = "numero"
      MyTip(1) = "System.String"

      MyPar(2) = "personaid"
      MyTip(2) = "System.String"

      MyPar(3) = "dni"
      MyTip(3) = "System.String"

      MyPar(4) = "nombre"
      MyTip(4) = "System.String"

      MyPar(5) = "importe"
      MyTip(5) = "System.Single"

      MyPar(6) = "observacion"
      MyTip(6) = "System.String"


      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Get_Pasar_Colp(ByVal NomTable As String) As DataTable
      Dim MyPar(4) As String, MyTip(4) As String, objDtf As DataTable
      'sucursal,direccion
      MyPar(0) = "colportorid"
      MyTip(0) = "System.Single"

      MyPar(1) = "dni"
      MyTip(1) = "System.String"

      MyPar(2) = "colportor"
      MyTip(2) = "System.String"

      MyPar(3) = "importe"
      MyTip(3) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("key2", objDtf.Columns("colportorid"), True)

      Return objDtf
    End Function

  End Class
  '==============================================================================================================

  '=======Inicio Grid Cancelación ====================================================================


  '=======Fin Cronograma Financiado=======================================================================

  '============================================================================================================

  '=======Inicio Grid Cancelacion de Conceptos====================================================================
  Public Class ClsGridDetallePagos
    Public Shared Function Crear_Grid(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "Nombre_Corto"
      MyTip(1) = "System.String"
      MyPar(2) = "Número"
      MyTip(2) = "System.String"

      MyPar(3) = "Vencimiento"
      MyTip(3) = "System.DateTime"
      MyPar(4) = "Saldo"
      MyTip(4) = "System.Single"
      MyPar(5) = "Amortiza"
      MyTip(5) = "System.Single"

      MyPar(6) = "observacion"
      MyTip(6) = "System.String"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Crear_Grid_Venta(ByVal NomTable As String) As DataTable
      Dim MyPar(9) As String, MyTip(9) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "id"
      MyTip(0) = "System.Single"
      MyPar(1) = "cantidad"
      MyTip(1) = "System.Single"
      MyPar(2) = "producto"
      MyTip(2) = "System.String"
      MyPar(3) = "afecto_igv"
      MyTip(3) = "System.Boolean"
      MyPar(4) = "afecto_dzmo"
      MyTip(4) = "System.Boolean"
      MyPar(5) = "precio"
      MyTip(5) = "System.Single"
      MyPar(6) = "dcto"
      MyTip(6) = "System.Single"

      MyPar(7) = "subtotal"
      MyTip(7) = "System.Single"
      MyPar(8) = "item"
      MyTip(8) = "System.Single"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("keyid", objDtf.Columns("id"), True)

      Return objDtf
    End Function

    Public Shared Function Crear_Grid_VentaP(ByVal NomTable As String) As DataTable
      Dim MyPar(12) As String, MyTip(12) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "id"
      MyTip(0) = "System.Single"
      MyPar(1) = "cantidad"
      MyTip(1) = "System.Single"
      MyPar(2) = "producto"
      MyTip(2) = "System.String"
      MyPar(3) = "afecto_igv"
      MyTip(3) = "System.Boolean"
      MyPar(4) = "afecto_dzmo"
      MyTip(4) = "System.Boolean"
      MyPar(5) = "precio"
      MyTip(5) = "System.Single"
      MyPar(6) = "dcto"
      MyTip(6) = "System.Single"

      MyPar(7) = "subtotal"
      MyTip(7) = "System.Single"
      MyPar(8) = "item"
      MyTip(8) = "System.Single"

      MyPar(9) = "tipodscto"
      MyTip(9) = "System.Single"

      MyPar(10) = "xctajedscto"
      MyTip(10) = "System.Single"

      MyPar(11) = "exonerada"
      MyTip(11) = "System.Boolean"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      objDtf.Constraints.Add("keyid", objDtf.Columns("id"), True)

      Return objDtf
    End Function
    Public Shared Function Crear_Grid_Liquidacion(ByVal NomTable As String) As DataTable
      Dim MyPar(11) As String, MyTip(11) As String, objDtf As DataTable
      'codigo,registro,nombre_corto,numero,total,cancela,observacion
      MyPar(0) = "id"
      MyTip(0) = "System.Single"
      MyPar(1) = "cantidad"
      MyTip(1) = "System.Single"
      MyPar(2) = "producto"
      MyTip(2) = "System.String"
      MyPar(3) = "afecto_igv"
      MyTip(3) = "System.Boolean"
      MyPar(4) = "afecto_dzmo"
      MyTip(4) = "System.Boolean"
      MyPar(5) = "precio"
      MyTip(5) = "System.Single"
      MyPar(6) = "dcto"
      MyTip(6) = "System.Single"

      MyPar(7) = "subtotal"
      MyTip(7) = "System.Single"
      MyPar(8) = "item"
      MyTip(8) = "System.Single"
      MyPar(9) = "grupo"
      MyTip(9) = "System.Single"
      MyPar(10) = "exonerada"
      MyTip(10) = "System.Boolean"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)
      Return objDtf
    End Function

    Public Shared Function Datos_Mora(ByVal objDt As DataTable, ByVal Codigo As Long) As tabla_virtual
      Dim objTv As tabla_virtual = Nothing
      Dim Drv As DataRow
      Dim xM As Single = 0, xCod As Long
      xM = 0
      xCod = 0
      If Not objDt Is Nothing Then
        For Each Drv In objDt.Rows
          If Drv.Item("Codigo_Ref") = Codigo Then
            xM = Drv.Item("saldo")
            xCod = Drv.Item("codigo_con")
            objTv = LlenarDatosRegistro(xCod, "", xM)
            Exit For
          End If
        Next
      End If

      Return objTv

    End Function

    Private Shared Function LlenarDatosRegistro(ByVal vCod As Long, ByVal vNomb As String, ByVal vImp As Single) As tabla_virtual
      Dim objeto As tabla_virtual = New tabla_virtual
      objeto.codigo = vCod
      objeto.nombre = vNomb
      objeto.importe = vImp
      Return objeto
    End Function

    Public Shared Function Crear_Grid_Provision(ByVal NomTable As String) As DataTable
      Dim MyPar(14) As String, MyTip(14) As String, objDtf As DataTable
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "concepto"
      MyTip(1) = "System.String"
      MyPar(2) = "importe"
      MyTip(2) = "System.Single"
      MyPar(3) = "dscto"
      MyTip(3) = "System.Single"
      MyPar(4) = "tp_dscto"
      MyTip(4) = "System.Int32"
      MyPar(5) = "mora"
      MyTip(5) = "System.Single"
      MyPar(6) = "total"
      MyTip(6) = "System.Single"
      MyPar(7) = "cancela"
      MyTip(7) = "System.Single"
      MyPar(8) = "codigo_con"
      MyTip(8) = "System.Single"
      MyPar(9) = "codigo_mora"
      MyTip(9) = "System.Single"
      MyPar(10) = "codigo_alu"
      MyTip(10) = "System.Single"
      MyPar(11) = "codigo_pro"
      MyTip(11) = "System.Single"
      MyPar(12) = "nmes"
      MyTip(12) = "System.Single"
      MyPar(13) = "alumno"
      MyTip(13) = "System.String"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Crear_Grid_Boleteo(ByVal NomTable As String) As DataTable

      Dim MyPar(14) As String, MyTip(14) As String, objDtf As DataTable
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "codigo_alu"
      MyTip(1) = "System.Single"
      MyPar(2) = "codigo_con"
      MyTip(2) = "System.Single"
      MyPar(3) = "codigo_apo"
      MyTip(3) = "System.Single"
      MyPar(4) = "serie"
      MyTip(4) = "System.Int32"
      MyPar(5) = "numero"
      MyTip(5) = "System.Single"
      MyPar(6) = "alumno"
      MyTip(6) = "System.String"
      MyPar(7) = "concepto"
      MyTip(7) = "System.String"
      MyPar(8) = "vencimiento"
      MyTip(8) = "System.DateTime"
      MyPar(9) = "importe"
      MyTip(9) = "System.Single"
      MyPar(10) = "descuento"
      MyTip(10) = "System.Single"
      MyPar(11) = "cargo"
      MyTip(11) = "System.Single"
      MyPar(12) = "saldo"
      MyTip(12) = "System.Single"
      MyPar(13) = "orden"
      MyTip(13) = "System.Int32"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Crear_Grid_Nota_Credito(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "concepto"
      MyTip(1) = "System.String"
      MyPar(2) = "importe"
      MyTip(2) = "System.Single"
      MyPar(3) = "ing_monto"
      MyTip(3) = "System.Single"
      MyPar(4) = "saldo"
      MyTip(4) = "System.Single"
      MyPar(5) = "codigo_con"
      MyTip(5) = "System.Single"
      MyPar(6) = "codigo_pro"
      MyTip(6) = "System.Single"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Crear_Grid_Nota_Credito_prov(ByVal NomTable As String) As DataTable
      Dim MyPar(9) As String, MyTip(9) As String, objDtf As DataTable
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "concepto"
      MyTip(1) = "System.String"
      MyPar(2) = "importe"
      MyTip(2) = "System.Single"
      MyPar(3) = "ing_monto"
      MyTip(3) = "System.Single"
      MyPar(4) = "nsaldo"
      MyTip(4) = "System.Single"
      MyPar(5) = "codigo_con"
      MyTip(5) = "System.Single"
      MyPar(6) = "codigo_pro"
      MyTip(6) = "System.Single"
      MyPar(7) = "saldo_obl"
      MyTip(7) = "System.Single"
      MyPar(8) = "codigo_obl"
      MyTip(8) = "System.Single"

      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

    Public Shared Function Llenar_Datos_Boleteo(ByVal objDt As DataTable, ByVal vSerie As String, ByVal vNumero As Long) As DataTable
      Dim objTv As New DataTable
      Dim Drv As DataRow, NvoReg As DataRow
      Dim vx As Long = vNumero
      objTv = Crear_Grid_Boleteo("tbboleteo")

      If Not objDt Is Nothing Then
        For Each Drv In objDt.Rows
          If Drv.Item("saldo") > 0 Then
            NvoReg = objTv.NewRow
            NvoReg.Item("codigo") = Drv.Item("codigo")
            NvoReg.Item("codigo_alu") = Drv.Item("codigo_alu")

            NvoReg.Item("codigo_con") = Drv.Item("codigo_con")

            NvoReg.Item("codigo_apo") = Drv.Item("codigo_apo")

            NvoReg.Item("serie") = vSerie

            NvoReg.Item("numero") = vx

            NvoReg.Item("alumno") = Drv.Item("alumno")

            NvoReg.Item("concepto") = Drv.Item("concepto")

            NvoReg.Item("vencimiento") = Drv.Item("vencimiento")
            'Para aquellas instituciones que boletean manual antes de Iniciar el Sistema
            'If Drv.Item("cargo") > Drv.Item("saldo") Then
            '    NvoReg.Item("importe") = Drv.Item("saldo")
            '    NvoReg.Item("descuento") = 0
            '    NvoReg.Item("cargo") = Drv.Item("saldo")
            'Else
            NvoReg.Item("importe") = Drv.Item("importe")
            NvoReg.Item("descuento") = Drv.Item("descuento")
            NvoReg.Item("cargo") = Drv.Item("cargo")
            'End If


            NvoReg.Item("saldo") = Drv.Item("saldo")

            NvoReg.Item("orden") = Drv.Item("orden")

            objTv.Rows.Add(NvoReg)
            vx += 1
          End If
        Next
      End If

      Return objTv

    End Function

    Public Shared Function Crear_Grid_Castigo_Deuda(ByVal NomTable As String) As DataTable
      Dim MyPar(7) As String, MyTip(7) As String, objDtf As DataTable
      MyPar(0) = "codigo"
      MyTip(0) = "System.Single"
      MyPar(1) = "codigo_alu"
      MyTip(1) = "System.Single"
      MyPar(2) = "codigo_con"
      MyTip(2) = "System.Single"
      MyPar(3) = "alumno"
      MyTip(3) = "System.String"
      MyPar(4) = "concepto"
      MyTip(4) = "System.String"
      MyPar(5) = "vencimiento"
      MyTip(5) = "System.DateTime"
      MyPar(6) = "importe"
      MyTip(6) = "System.Single"
      objDtf = DataTableDesvinculado.GenerarDataTable(NomTable, MyPar, MyTip)

      Return objDtf
    End Function

  End Class

End Namespace