Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Microsoft.Office.Interop
Imports System.IO

Public Class FrmReportes_Asistencia
  '  Dim objApp As Excel.Application
  '  Dim objBook As Excel._Workbook

  '  Private Sub bwUsuario_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUsuario.DoWork
  '    'CheckForIllegalCrossThreadCalls = False

  '    'Dim ObjPer As New persona

  '    'Try

  '    '    ObjPer = personaManager.GetItem(CInt(LblUsuario.Tag))


  '    '    e.Result = ObjPer

  '    '    ObjPer = Nothing
  '    'Catch ex As Exception

  '    '    MsgBox(ex.Message)
  '    'End Try
  '  End Sub

  '  Private Sub bwUsuario_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUsuario.RunWorkerCompleted
  '    ''If sender = bwPrecarga Then
  '    'Dim ObjP As New persona
  '    'ObjP = CType(e.Result, persona)
  '    'LblUsuario.Tag = ""
  '    'If Not ObjP Is Nothing Then
  '    '    Me.LblUsuario.Tag = Trim(ObjP.personaid)
  '    '    Me.LblUsuario.Text = Trim(ObjP.nombre)
  '    'Else
  '    '    MsgBox("Código no Encontrado", MsgBoxStyle.Information, "INFORMACIÓN")
  '    '    Me.btnBuscaUs.Focus()
  '    'End If

  '    ''picAjax.Visible = False

  '  End Sub

  '  Private Sub Listado_Opciones()
  '    Dim dtL As DataTable
  '    Dim x As Integer = 36
  '    Dim opcionesv(x), opciones(x) As String

  '    opcionesv(0) = 0
  '    opcionesv(1) = 1
  '    opcionesv(2) = 2
  '    opcionesv(3) = 3
  '    opcionesv(4) = 4
  '    opcionesv(5) = 5
  '    opcionesv(6) = 6
  '    opcionesv(7) = 7
  '    opcionesv(8) = 8
  '    opcionesv(9) = 9
  '    opcionesv(10) = 10
  '    opcionesv(11) = 11
  '    opcionesv(12) = 12
  '    opcionesv(13) = 13
  '    opcionesv(14) = 14
  '    opcionesv(15) = 15
  '    opcionesv(16) = 16
  '    opcionesv(17) = 17
  '    opcionesv(18) = 18
  '    opcionesv(19) = 19
  '    opcionesv(20) = 20
  '    opcionesv(21) = 21
  '    opcionesv(22) = 22
  '    opcionesv(23) = 23
  '    opcionesv(24) = 24
  '    opcionesv(25) = 25
  '    opcionesv(26) = 26
  '    opcionesv(27) = 27 'Libre
  '    opcionesv(28) = 28
  '    opcionesv(29) = 29
  '    opcionesv(30) = 30
  '    opcionesv(31) = 31
  '    opcionesv(32) = 32
  '    opcionesv(33) = 33
  '    opcionesv(34) = 34
  '    opcionesv(35) = 35
  '    opcionesv(36) = 36

  '    opciones(0) = "Asiento de Ingresos"
  '    opciones(1) = "Ingresos Resumidos"
  '    opciones(2) = "Ingresos Detallados"
  '    opciones(3) = "Ingresos de un Concepto" '"Ingresos de un Concepto"
  '    opciones(4) = "Asiento de Lote de Gasto"
  '    opciones(5) = "Asiento de Reversión"
  '    opciones(6) = "Listado Prorrogas"
  '    opciones(7) = "Saldo de Oblgaciones / Grado"
  '    opciones(8) = "Presupuesto / Precapitat"
  '    opciones(9) = "Estado de Cuenta Individual"
  '    opciones(10) = "Asiento - Venta"
  '    opciones(11) = "Ingresos de un Concepto por Sección"
  '    opciones(12) = "Asiento de Gasto por Condición"
  '    opciones(13) = "---"
  '    opciones(14) = "Registro de Venta"
  '    opciones(15) = "Registro de Compra"
  '    opciones(16) = "Registro de Recibo por Honorarios"
  '    opciones(17) = "---"
  '    opciones(18) = "Obligaciones por Cobrar"
  '    opciones(19) = "Obligaciones Cobradas"
  '    opciones(20) = "Escalas de Pago"
  '    opciones(21) = "Resumen de Obligaciones por Proceso"
  '    opciones(22) = "Resumen de Obligaciones por Alumno"
  '    opciones(23) = "---"
  '    opciones(24) = "Descuentos Detallados"
  '    opciones(25) = "Descuentos Resumidos por Alumno"
  '    opciones(26) = "Descuentos Resumidos por Grado/Seccion"
  '    opciones(27) = "---"
  '    opciones(28) = "Consolidado Por Cobrar"
  '    opciones(29) = "Consolidado Cobrado"
  '    opciones(30) = "Consolidado Resumen Obligaciones"
  '    opciones(31) = "Consolidado Registro Venta"
  '    opciones(32) = "Consolidado Registro Compra"
  '    opciones(33) = "Consolidado Registro RH"
  '    opciones(34) = "Consolidado Compras DAOT"
  '    opciones(35) = "---"
  '    opciones(36) = "Análisis de Obligaciones Cons"

  '    dtL = DosOpcionesManager.GetList("Panel_Rpt", opcionesv, opciones, x)
  '    ''dgvListado.DataSource = dtL
  '    ''dgvListado.Refresh()

  '  End Sub


  '  Private Sub FrmPanel_Reportes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  '    'LblUsuario.Tag = GestionSeguridadManager.idUsuario
  '    'LblUsuario.Text = GestionSeguridadManager.sUsuario

  '    Call Listado_Opciones()
  '    Call llenar_combos()
  '    Me.CboFecha1.Value = Date.Now
  '    Me.CboFecha2.Value = Date.Now
  '  End Sub

  '  Private Sub dgvListado_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs)

  '    Dim SaldoSel As Single
  '    SaldoSel = 0

  '    'With dgvListado.Selected
  '    '    Call Habilitar(False)
  '    '    If .Rows.Count > 0 Then
  '    '        For Each lsel In .Rows
  '    '            If lsel.Band.Index = 0 Then
  '    '                Select Case lsel.Cells(0).Value
  '    '                    Case 0
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        LblUsuario.Enabled = True
  '    '                        btnBuscaUs.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Formato .CSV"
  '    '                        chkAux1.Checked = True
  '    '                        btnExcel.Enabled = True
  '    '                    Case 1, 2
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        LblUsuario.Enabled = True
  '    '                        btnBuscaUs.Enabled = True
  '    '                    Case 3
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                    Case 4
  '    '                        BtnMostrar.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Formato .CSV"
  '    '                        chkAux1.Checked = True
  '    '                        btnExcel.Enabled = True
  '    '                    Case 5
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                        LblUsuario.Enabled = True
  '    '                        btnBuscaUs.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Formato .CSV"
  '    '                        chkAux1.Checked = True
  '    '                        ChkAux2.Enabled = True
  '    '                        ChkAux2.Text = "Detallado"
  '    '                        ChkAux2.Checked = False
  '    '                        btnExcel.Enabled = True
  '    '                    Case 6
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        cboGrado.Enabled = True
  '    '                        CboSeccion.Enabled = True
  '    '                    Case 7, 11
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                        CboSeccion.Enabled = True
  '    '                        LblUsuario.Enabled = True
  '    '                        btnBuscaUs.Enabled = True
  '    '                    Case 8
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                    Case 9
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                    Case 10
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        btnExcel.Enabled = True
  '    '                    Case 12
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha1.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                    Case 14
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                        cboAnio.Enabled = True
  '    '                        btnExcel.Enabled = True
  '    '                    Case 15, 16
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                        cboAnio.Enabled = True
  '    '                        btnExcel.Enabled = True
  '    '                    Case 18
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Inluido Retirados"
  '    '                        chkAux1.Checked = True
  '    '                        ChkAux2.Enabled = True
  '    '                        ChkAux2.Text = "Inluir Deuda Castigadas"
  '    '                        ChkAux2.Checked = True
  '    '                        cboGrado.Enabled = True
  '    '                    Case 19
  '    '                        BtnMostrar.Enabled = True
  '    '                        CboFecha2.Enabled = True
  '    '                        cboGrado.Enabled = True
  '    '                    Case 20
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboMes.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Clasificar por Grado"
  '    '                        chkAux1.Checked = True
  '    '                        ChkAux2.Enabled = True
  '    '                        ChkAux2.Text = "Inluye los Alumnos Retirados"
  '    '                        ChkAux2.Checked = True
  '    '                    Case 22
  '    '                        BtnMostrar.Enabled = True
  '    '                        cboGrado.Enabled = True
  '    '                        chkAux1.Enabled = True
  '    '                        chkAux1.Text = "Mostrar Clasificado por Sección"
  '    '                        chkAux1.Checked = True

  '    '                End Select
  '    '                'If lsel.Cells("codigo").Value > 0 And Not (lsel.Cells("orden").Value = 2) Then
  '    '                '    SaldoSel += lsel.Cells("saldo").Value
  '    '                'Else
  '    '                '    If (lsel.Cells("orden").Value = 2) Then
  '    '                '        lsel.Selected = False
  '    '                '    End If
  '    '                'End If
  '    '            End If

  '    '        Next

  '    '    End If
  '    'End With

  '  End Sub

  '  Private Sub Habilitar(ByVal Valor As Boolean)
  '    cboUnidad_Negocio.Enabled = True 'Valor
  '    cboGrado.Enabled = Valor
  '    CboSeccion.Enabled = Valor
  '    cboMes.Enabled = Valor
  '    cboAnio.Enabled = Valor
  '    CboFecha1.Enabled = Valor
  '    CboFecha2.Enabled = Valor
  '    LblUsuario.Enabled = Valor
  '    btnBuscaUs.Enabled = Valor
  '    btnExcel.Enabled = Valor
  '  End Sub

  '  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
  '    ''dgvListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
  '    ''dgvListado.DisplayLayout.Bands(0).Columns(1).Width = dgvListado.Width - 30
  '    ''Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
  '    ''dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.BackColor = Color.BlanchedAlmond

  '    ''dgvListado.DisplayLayout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnBottom
  '    ''dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.BackColor = Color.BlanchedAlmond
  '    'Call formatear_grid()
  '  End Sub

  '  Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs)
  '    e.Row.Cells(1).Appearance.Image = Global.Phoenix.My.Resources.Resources.printer
  '  End Sub

  '  Private Sub llenar_combos()
  '    Try
  '      'With cboUnidad_Negocio
  '      '    .DataSource = Nothing
  '      '    .DataSource = unidad_negocioManager.GetList(GestionSeguridadManager.idUsuario, GestionSeguridadManager.mTesoreria, 0, 0, 0)
  '      '    .DataBind()
  '      '    .ValueMember = "codigo_uni"
  '      '    .DisplayMember = "nombre"
  '      '    .MinDropDownItems = 2
  '      '    .MaxDropDownItems = 4
  '      '    If .Rows.Count > 0 Then
  '      '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
  '      '    End If

  '      'End With


  '      Dim lMeses As New ClsCrearMeses

  '      With cboMes
  '        .DataSource = Nothing
  '        .DataSource = lMeses.GetList(False, False)
  '        .Refresh()
  '        .ValueMember = "codigo"
  '        .DisplayMember = "nombre"
  '        If .Rows.Count > 0 Then
  '          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
  '        End If

  '      End With
  '      With cboAnio
  '        .DataSource = Nothing
  '        .DataSource = lMeses.GetList_anios()
  '        .Refresh()
  '        .ValueMember = "nombre"
  '        .DisplayMember = "nombre"
  '        If .Rows.Count > 0 Then
  '          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
  '        End If

  '      End With

  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub Mostrar_Proceso_Matricula()
  '    Dim vCodigo_Unidad As Integer
  '    Dim vCodigo_Pro As Integer = 0
  '    Try
  '      vCodigo_Unidad = 0
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vCodigo_Unidad = CInt(cboUnidad_Negocio.Value)
  '      End If


  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub cboUnidad_Negocio_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnidad_Negocio.InitializeLayout
  '    With cboUnidad_Negocio.DisplayLayout.Bands(0)
  '      .Columns(0).Hidden = True
  '      .Columns(1).Width = cboUnidad_Negocio.Width
  '      .Columns(2).Hidden = True
  '    End With
  '  End Sub

  '  Private Sub cboUnidad_Negocio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.ValueChanged
  '    Call Mostrar_Proceso_Matricula()
  '  End Sub

  '  Private Sub cboMes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMes.InitializeLayout
  '    cboMes.DisplayLayout.Bands(0).Columns(0).Hidden = True
  '    cboMes.DisplayLayout.Bands(0).Columns(1).Width = cboMes.Width
  '  End Sub

  '  Private Sub RptAsinto_Ventas()

  '    Dim DtpAI As New DataTable
  '    Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = ""
  '    Dim vMsg As String = "", vDet As String
  '    Try
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vUni = cboUnidad_Negocio.Value
  '      Else
  '        vMsg = "Debe Seleccionar una Unidad Negocio"
  '      End If
  '      If IsDate(Me.CboFecha1.Value) And IsDate(CboFecha2.Value) Then
  '        vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
  '        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
  '      Else
  '        vMsg = "Fechas No Válidas"
  '      End If

  '      If Trim(vMsg) = "" Then
  '        vDet = "Asiento de Venta de: " & vDesde & " a " & vHasta
  '        'DtpAI = arqueo_ingresoManager.Asiento_Venta(vUni, vDesde, vHasta)
  '        'Dim frm As New FrmVisorCaja
  '        'frm.RptAsiento(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet)
  '        'frm.Show()
  '      Else
  '        MsgBox(vMsg, MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
  '        Exit Sub
  '      End If


  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub RptAsinto_Ingresos()

  '    Dim DtpAI As New DataTable
  '    Dim vUni As Integer = 0, vProc As Integer = 0, vDesde As String = "", vHasta As String = ""
  '    Dim vMsg As String = "", vDet As String, vUsuario As Integer = 0
  '    Try
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vUni = cboUnidad_Negocio.Value
  '      Else
  '        vMsg = "Debe Seleccionar un Proceso"
  '      End If

  '      If IsDate(Me.CboFecha1.Value) And IsDate(CboFecha2.Value) Then
  '        vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
  '        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
  '      Else
  '        vMsg = "Fechas No Válidas"
  '      End If

  '      If Trim(vMsg) = "" Then
  '        vDet = "Asiento de Ingresos de: " & vDesde & " a " & vHasta
  '        If LblUsuario.Tag > 0 Then
  '          vUsuario = LblUsuario.Tag
  '        End If
  '        'DtpAI = arqueo_ingresoManager.Asiento_Ing(vProc, vDesde, vHasta, vUsuario)
  '        'Dim frm As New FrmVisorCaja
  '        'frm.RptAsiento(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet)
  '        'frm.Show()
  '      Else
  '        MsgBox(vMsg, MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
  '        Exit Sub
  '      End If


  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub RptAsinto_Reversion()

  '    Dim DtpAI As New DataTable
  '    Dim vUni As Integer = 0, vProc As Integer = 0, vDesde As String = "", vHasta As String = ""
  '    Dim vMsg As String = "", vDet As String, vMes As Integer = 0
  '    Try
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vUni = cboUnidad_Negocio.Value
  '      Else
  '        vMsg = "Debe Seleccionar un Proceso"
  '      End If

  '      If Not Trim(cboMes.Text) = "" Then
  '        If cboMes.Value > 0 Then
  '          vMes = cboMes.Value
  '        Else
  '          vMsg = "Debe Seleccionar un Mes a Revertir"
  '        End If

  '      Else
  '        vMsg = "Debe Seleccionar un Mes a Revertir"
  '      End If

  '      If IsDate(Me.CboFecha1.Value) And IsDate(CboFecha2.Value) Then
  '        vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
  '        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
  '      Else
  '        vMsg = "Fechas No Válidas"
  '      End If
  '      If ChkAux2.Checked Then
  '        If Trim(vMsg) = "" Then
  '          vDet = "Detalle Asiento de Reversión del mes: " & cboMes.Text & " Cobrados de:" & vDesde & " a " & vHasta
  '          If cboMes.Value > 0 Then
  '            vMes = cboMes.Value
  '          End If
  '          'DtpAI = arqueo_ingresoManager.Detalle_Asiento_Reversion(vProc, vDesde, vHasta, vMes)
  '          'Dim frm As New FrmVisorCaja
  '          'frm.RptDetalle_Asiento_Reversion(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet)
  '          'frm.Show()
  '        Else
  '          MsgBox(vMsg, MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
  '          Exit Sub
  '        End If
  '      Else
  '        If Trim(vMsg) = "" Then
  '          vDet = "Asiento de Reversión del mes: " & cboMes.Text & " Cobrados de:" & vDesde & " a " & vHasta
  '          If cboMes.Value > 0 Then
  '            vMes = cboMes.Value
  '          End If
  '          'DtpAI = arqueo_ingresoManager.Asiento_Reversion(vProc, vDesde, vHasta, vMes)
  '          'Dim frm As New FrmVisorCaja
  '          'frm.RptAsiento(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet)
  '          'frm.Show()
  '        Else
  '          MsgBox(vMsg, MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
  '          Exit Sub
  '        End If
  '      End If
  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub RptDetalle_Ingresos(ByVal vSp As String, ByVal Concep As Boolean, ByVal vGOp As Integer, ByVal vOp As Integer)

  '    Dim DtpAI As New DataTable
  '    Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = ""
  '    Dim vProc As Integer = 0, vConc As Integer = 0, vCodigo_Us As Integer
  '    Dim vMsg As String = "", vUs As String = "", vSt As String = ""
  '    Dim vmes As Integer = 0, vNivel As Integer = 0, vGrado As Integer = 0, vSaldo As Integer = 0, vSec As Integer = 0
  '    Try
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vUni = cboUnidad_Negocio.Value
  '      Else
  '        vMsg = "Debe Seleccionar un Proceso"
  '      End If

  '      If IsDate(Me.CboFecha1.Value) And IsDate(CboFecha2.Value) Then
  '        vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
  '        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
  '      Else
  '        vMsg = "Fechas No Válidas "
  '      End If
  '      If LblUsuario.Tag > 0 Then
  '        vUs = LblUsuario.Text
  '        vCodigo_Us = LblUsuario.Tag
  '      Else
  '        vUs = GestionSeguridadManager.sUsuario
  '        vCodigo_Us = 0
  '      End If


  '      Select Case vGOp
  '        Case 1
  '          'If Trim(vMsg) = "" Then
  '          '    If vOp = 1 Then
  '          '        vDet = "Detalle de Ingresos Agrupados por Documentos: " & vDesde & " a " & vHasta
  '          '        DtpAI = ReportesManager.ingresos_detalle(vSp, vUni, vDesde, vHasta, vCodigo_Us)
  '          '        Dim frm As New FrmVisorCaja
  '          '        frm.RptIngresos_Documento(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet, vUs)
  '          '        frm.Show()
  '          '    ElseIf vOp = 2 Then
  '          '        vDet = "Detalle de Ingresos : " & vDesde & " a " & vHasta
  '          '        DtpAI = ReportesManager.ingresos_detalle(vSp, vUni, vDesde, vHasta, vCodigo_Us)
  '          '        Dim frm As New FrmVisorCaja
  '          '        frm.RptIngresos_Concepto(DtpAI, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vDet, vUs)
  '          '        frm.Show()
  '          '    End If
  '          'Else
  '          '    MsgBox(vMsg, MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
  '          '    Exit Sub
  '          'End If
  '      End Select


  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
  '    ''Dim vProc As Integer = 0
  '    ''Dim vMes As Integer = 0, xComen As String = "", xSub As String = "", vanio As Integer = 0
  '    ''Dim vDesde As String = "", vHasta As String = ""
  '    ''If dgvListado.Selected.Rows.Count > 0 Then
  '    ''    If IsDBNull(dgvListado.ActiveRow.Cells(0).Value) Then
  '    ''        Exit Sub
  '    ''    End If
  '    ''    Select Case dgvListado.ActiveRow.Cells(0).Value
  '    ''        Case 0
  '    ''            Call RptAsinto_Ingresos()
  '    ''        Case 1
  '    ''            Call RptDetalle_Ingresos("parpt_ingresos_detalle", False, 1, 1)
  '    ''        Case 2
  '    ''            Call RptDetalle_Ingresos("parpt_ingresos_detalle_concepto", True, 1, 2)
  '    ''        Case 3
  '    ''            Call RptDetalle_Ingresos("pareporte_ingresos_academicos_concepto", True, 1, 3)
  '    ''    End Select
  '    ''End If

  '  End Sub

  '  Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

  '    Dim DtRpt As New DataTable, vMsg As String = ""
  '    Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
  '    Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0
  '    Dim vEmpresa As String = "", vRucEmp As String = ""
  '    Dim xNameFile As String = ""
  '    Try
  '      Dim objBooks As Excel.Workbooks
  '      Dim objSheets As Excel.Sheets
  '      Dim objSheet As Excel._Worksheet
  '      'Dim range As Excel.Range

  '      objApp = New Excel.Application()
  '      objBooks = objApp.Workbooks
  '      objBook = objBooks.Add
  '      objSheets = objBook.Worksheets
  '      objSheet = objSheets(1)
  '      If Not Trim(cboUnidad_Negocio.Text) = "" Then
  '        vUni = cboUnidad_Negocio.Value
  '      Else
  '        vMsg = "Debe Seleccionar una Unidad Negocio"
  '        Exit Sub
  '      End If


  '      If IsDate(Me.CboFecha1.Value) And IsDate(CboFecha2.Value) Then
  '        vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
  '        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
  '      Else
  '        vMsg = "Fechas No Válidas"
  '        Exit Sub
  '      End If



  '      ''If dgvListado.Selected.Rows.Count > 0 Then
  '      ''    Select Case dgvListado.ActiveRow.Cells(0).Value
  '      ''        Case 0
  '      ''            If LblUsuario.Tag > 0 Then
  '      ''                vUsuario = LblUsuario.Tag
  '      ''            End If
  '      ''            ''DtRpt = arqueo_ingresoManager.Asiento_Ing(vProc, vDesde, vHasta, vUsuario)
  '      ''            xCondi = "Asiento de Ingresos del: " & Me.CboFecha1.Text & " Al " & Me.CboFecha2.Text
  '      ''            If chkAux1.Checked = True Then
  '      ''                xNameFile = "C:\ctr_i" & cboUnidad_Negocio.Value & "."
  '      ''                xNameFile = xNameFile & LibreriasFormularios.Formato_Fecha_b(CboFecha1.Text) & "."
  '      ''                xNameFile = xNameFile & LibreriasFormularios.Formato_Fecha_b(CboFecha2.Text) & ".csv"
  '      ''                Call Guardar_CSV(xNameFile, DtRpt, xCondi)
  '      ''            Else
  '      ''                Call ExportarExcel(objApp, DtRpt, xCondi)
  '      ''            End If


  '      ''            objApp.Visible = True


  '      ''            btnExcel.Visible = True
  '      ''    End Select
  '      ''End If
  '    Catch ex As Exception
  '      MsgBox(ex.Message)
  '    End Try
  '  End Sub

  '  Private Sub ExportarExcel(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

  '    Dim DtRw As DataRow
  '    Dim xfield, V, H As Long
  '    Dim Centro_Costo As Long = 0
  '    Dim xPt As String = ""
  '    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


  '    Dim objCelda As Excel.Range

  '    objCelda = ObExel.Range("E2", Type.Missing)
  '    objCelda.EntireColumn.ColumnWidth = 3
  '    objCelda = ObExel.Range("F3", Type.Missing)
  '    objCelda.EntireColumn.ColumnWidth = 3
  '    objCelda = ObExel.Range("G3", Type.Missing)
  '    objCelda.EntireColumn.ColumnWidth = 40
  '    objCelda = ObExel.Range("H3", Type.Missing)
  '    objCelda.EntireColumn.ColumnWidth = 3
  '    objCelda = ObExel.Range("I3", Type.Missing)
  '    objCelda.EntireColumn.ColumnWidth = 3
  '    'objCelda = objHojaExcel.Range("C3", Type.Missing)
  '    'objCelda.Value = "Nombre"

  '    'objCelda = objHojaExcel.Range("D3", Type.Missing)
  '    'objCelda.Value = "Precio RD$"
  '    'objCelda.EntireColumn .Width =
  '    objCelda = ObExel.Range("D2", Type.Missing)
  '    If xPt = "." Then
  '      objCelda.EntireColumn.NumberFormat = "0.00"
  '    Else
  '      objCelda.EntireColumn.NumberFormat = "0,00"
  '    End If

  '    xfield = 1
  '    V = 2
  '    H = 1


  '    'ObExel.Workbooks.Add()
  '    'Empezamos a Pasar los datos a Excel
  '    'Primera Linea
  '    'ObExel.Cells(1, 1) = unidad_negocioManager.GetList_Unidad_Entidad_GetRow(cboUnidad_Negocio.Value)
  '    'Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)
  '    'ObExel.Cells(1, 2) = xCondi

  '    For Each DtRw In Dtp.Rows
  '      With ObExel

  '        'Demas Lineas
  '        .Cells(V, H) = (DtRw("cuenta"))
  '        .Cells(V, H + 1) = (DtRw("ctacte"))
  '        .Cells(V, H + 2) = Centro_Costo

  '        If CSng(DtRw("monto_debe")) > 0 Then
  '          .Cells(V, H + 3) = FormatNumber(CSng(DtRw("monto_debe")), 2, TriState.True, TriState.False, TriState.True)
  '        Else
  '          .Cells(V, H + 3) = FormatNumber(CSng(DtRw("monto_haber")), 2, TriState.True, TriState.False, TriState.True)
  '        End If
  '        .Cells(V, H + 4) = " "
  '        .Cells(V, H + 5) = " "


  '        .Cells(V, H + 6) = Mid(Trim(DtRw("glosa")), 1, 50)


  '        .Cells(V, H + 7) = " "
  '        .Cells(V, H + 8) = "N"

  '      End With
  '      V = V + 1
  '    Next DtRw

  '    ObExel.Visible = True
  '  End Sub

  '  ' botón para recorrer guardarlo en el archivo 

  '  Private Function Guardar_CSV(ByVal vNameFile As String, ByVal Dtp As DataTable, ByVal xCondi As String) As Boolean

  '    Const DELIMITADOR As String = ";"
  '    Dim DtRw As DataRow
  '    Dim Centro_Costo As Long = 0
  '    ' ruta del fichero de texto
  '    Dim ARCHIVO_CSV As String = ""
  '    ARCHIVO_CSV = vNameFile '"C:\ctr_" & cboUnidad_Negocio.Value & "." & Format(CboFecha1.Text, "ddmmyy") & "." & Format(CboFecha2.Text, "ddmmyy") & ".csv"

  '    Try
  '      'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
  '      Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

  '        'variable para almacenar la línea actual del dataview
  '        Dim linea As String = String.Empty

  '        ''linea = unidad_negocioManager.GetList_Unidad_Entidad_GetRow(cboUnidad_Negocio.Value) & DELIMITADOR
  '        ''linea = linea & xCondi
  '        ''archivo.WriteLine(linea.ToString)
  '        ''Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)

  '        ' Recorrer las filas del dataTable
  '        ' Recorrer la cantidad de columnas que contiene el dataTable
  '        For Each DtRw In Dtp.Rows
  '          ' vaciar la línea
  '          linea = String.Empty

  '          ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
  '          'linea = linea & .Item(col, fila).Value.ToString & DELIMITADOR                    
  '          linea = linea & DtRw("cuenta").ToString & DELIMITADOR
  '          'Demas Lineas
  '          linea = linea & DtRw("cuenta").ToString & DELIMITADOR
  '          linea = linea & DtRw("ctacte").ToString & DELIMITADOR
  '          linea = linea & Centro_Costo & DELIMITADOR

  '          If CSng(DtRw("monto_debe")) > 0 Then
  '            linea = linea & FormatNumber(CSng(DtRw("monto_debe")), 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR
  '          Else
  '            linea = linea & FormatNumber(CSng(DtRw("monto_haber")), 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR
  '          End If
  '          linea = linea & "" & DELIMITADOR
  '          linea = linea & "" & DELIMITADOR


  '          linea = linea & Mid(Trim(DtRw("glosa")), 1, 50) & DELIMITADOR


  '          linea = linea & "" & DELIMITADOR
  '          linea = linea & "N"
  '          ' Escribir una línea con el método WriteLine
  '          With archivo
  '            ' eliminar el último caracter ";" de la cadena
  '            ''linea = linea.Remove(linea.Length - 1).ToString
  '            ' escribir la fila
  '            .WriteLine(linea.ToString)
  '          End With
  '        Next DtRw

  '      End Using
  '      Guardar_CSV = True
  '      ' Abrir con Process.Start el archivo de texto
  '      ''Process.Start(ARCHIVO_CSV)
  '      MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
  '      'error
  '    Catch ex As Exception
  '      MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
  '    End Try
  '  End Function

  '  Private Sub ExportarExcel_RH(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

  '    Dim DtRw As DataRow
  '    Dim xfield, V, H As Long
  '    Dim Centro_Costo As Long = 0
  '    Dim xPt As String = ""

  '    'ObExel = CreateObject("Excel.Application")
  '    'ObExel. (App.Path & "\Txt\honorarios.xls")

  '    'xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


  '    'Dim objCelda As Excel.Range

  '    ''objCelda = ObExel.Range("E2", Type.Missing)
  '    ''objCelda.EntireColumn.ColumnWidth = 3
  '    ''objCelda = ObExel.Range("F3", Type.Missing)
  '    ''objCelda.EntireColumn.ColumnWidth = 3
  '    ''objCelda = ObExel.Range("G3", Type.Missing)
  '    ''objCelda.EntireColumn.ColumnWidth = 40
  '    ''objCelda = ObExel.Range("H3", Type.Missing)
  '    ''objCelda.EntireColumn.ColumnWidth = 3
  '    ''objCelda = ObExel.Range("I3", Type.Missing)
  '    ''objCelda.EntireColumn.ColumnWidth = 3
  '    'objCelda = objHojaExcel.Range("C3", Type.Missing)
  '    'objCelda.Value = "Nombre"

  '    'objCelda = objHojaExcel.Range("D3", Type.Missing)
  '    'objCelda.Value = "Precio RD$"
  '    'objCelda.EntireColumn .Width =
  '    ''objCelda = ObExel.Range("D2", Type.Missing)
  '    ''If xPt = "." Then
  '    ''    objCelda.EntireColumn.NumberFormat = "0.00"
  '    ''Else
  '    ''    objCelda.EntireColumn.NumberFormat = "0,00"
  '    ''End If

  '    xfield = 1
  '    V = 5
  '    H = 2


  '    'ObExel.Workbooks.Add()
  '    'Empezamos a Pasar los datos a Excel
  '    'Primera Linea
  '    ''ObExel.Cells(1, 1) = unidad_negocioManager.GetList_Unidad_Entidad_GetRow(cboUnidad_Negocio.Value)
  '    ' ''Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)
  '    ''ObExel.Cells(1, 3) = xCondi

  '    For Each DtRw In Dtp.Rows
  '      With ObExel

  '        'Demas Lineas
  '        .Cells(V, H) = (DtRw("rucdni"))
  '        .Cells(V, H + 1) = Trim(DtRw("apepat"))
  '        .Cells(V, H + 2) = Trim(DtRw("apemat"))
  '        .Cells(V, H + 3) = Trim(DtRw("nombre"))
  '        If IsDate(DtRw("nacimiento")) Then
  '          .Cells(V, H + 4) = (DtRw("nacimiento"))
  '        Else
  '          .Cells(V, H + 4) = " "
  '        End If
  '        .Cells(V, H + 5) = Trim(DtRw("serie"))
  '        .Cells(V, H + 6) = Trim(DtRw("numero"))
  '        .Cells(V, H + 7) = (DtRw("emision"))
  '        .Cells(V, H + 8) = (DtRw("cancelacion"))
  '        .Cells(V, H + 9) = (DtRw("importe"))
  '        .Cells(V, H + 10) = DtRw("rtrh")
  '        .Cells(V, H + 11) = DtRw("rh")

  '      End With
  '      V = V + 1
  '    Next DtRw

  '  End Sub

  '  Private Function Exportar_Registro_Ventas(ByVal gNombre_Empresa As String, ByVal gRUC As String,
  '                                             ByVal vcodigo_unidad As Integer, ByVal vmes As Integer,
  '                                             ByVal vanio As Integer, ByVal vPeriodo As String) As Boolean
  '    Dim DtOb As New DataTable
  '    Dim V As Long, H As Long, xR As Long
  '    Dim DtRw As DataRow

  '    On Error GoTo ExpExcel

  '    DtOb = ReportesManager.Registro_Venta(vcodigo_unidad, vanio, vmes, 0, "", False, True, "", "", 0, "")

  '    If Not DtOb.Rows.Count > 0 Then
  '      MsgBox("No hay Registro que Exportar", vbExclamation, "AVISO")
  '      Exit Function
  '    End If

  '    Dim oExcel As Excel.ApplicationClass
  '    Dim oBooks As Excel.Workbooks
  '    Dim oBook As Excel.WorkbookClass
  '    Dim oSheet As Excel.Worksheet

  '    ' Inicia Excel y abre el workbook
  '    oExcel = CreateObject("Excel.Application")

  '    oBooks = oExcel.Workbooks
  '    'oBook = oExcel.Workbooks.Add

  '    oBook = oBooks.Open(
  '        "C:\xxx\registroventa.xls")

  '    oSheet = oBook.Sheets(1)

  '    'Const ROW_FIRST = 3
  '    'Dim iRow As Int64 = 1

  '    ' Encabezado
  '    'oSheet.Cells(ROW_FIRST, 1) = "ID"

  '    V = 12
  '    H = 1
  '    xR = 0
  '    oSheet.Cells(3, 6) = vPeriodo
  '    oSheet.Cells(4, 6) = gRUC
  '    If vcodigo_unidad > 0 Then
  '      oSheet.Cells(5, 6) = gNombre_Empresa & " / " & cboUnidad_Negocio.Text
  '    Else
  '      oSheet.Cells(5, 6) = gNombre_Empresa
  '    End If

  '    For Each DtRw In DtOb.Rows
  '      With oSheet
  '        xR = xR + 1
  '        'Demas Lineas
  '        .Cells(V, H) = xR
  '        .Cells(V, H + 1) = DtRw("emision")
  '        'If Not DtRw("emision") = DtRw("cancelacion") Then
  '        '.Cells(V, H + 2) = DtRw("cancelacion")
  '        'End If
  '        .Cells(V, H + 3) = DtRw("codigo_sunat")
  '        .Cells(V, H + 4) = DtRw("serie_doc")
  '        .Cells(V, H + 5) = DtRw("numero_doc")
  '        .Cells(V, H + 6) = DtRw("tipo_doc_per")
  '        .Cells(V, H + 7) = DtRw("numero_doc_per")
  '        .Cells(V, H + 8) = DtRw("persona")
  '        .Cells(V, H + 11) = DtRw("total")
  '        '.Cells(V, H + 15) = DtRw("igv")
  '        '.Cells(V, H + 16) = DtRw("sb_nograbado")
  '        '.Cells(V, H + 17) = DtRw("isc")
  '        '.Cells(V, H + 18) = DtRw("otros")
  '        .Cells(V, H + 16) = DtRw("Total")
  '      End With
  '      'H = H + 1
  '      V = V + 1
  '    Next DtRw

  '    oExcel.Visible = True

  '    Exportar_Registro_Ventas = True
  '    '' Cierra todo
  '    ''oBook.Close(True)
  '    System.Runtime.InteropServices.Marshal.
  '        ReleaseComObject(oBook)
  '    oBook = Nothing

  '    System.Runtime.InteropServices.Marshal.
  '        ReleaseComObject(oBooks)
  '    oBooks = Nothing

  '    ''oExcel.Quit()
  '    System.Runtime.InteropServices.Marshal.
  '        ReleaseComObject(oExcel)
  '    oExcel = Nothing
  '    Exit Function


  '    ''ObjExcel = CreateObject("Excel.Application")
  '    ' ''ObjExcel = excelApp.Workbooks.Open("C:\Program Files\DISClient\Templates\TemplateMerge.xls")
  '    ''ObjExcel.Application.Workbooks.Open("c:\xxx\registrocompra.xls")
  'ExpExcel:
  '    MsgBox("Conflicto: " & Err.Description, vbExclamation, "AVISO")
  '    oExcel = Nothing
  '  End Function

  '  Private Sub btnBuscaUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaUs.Click
  '    Call ListadoClie()
  '    Call EncontrarClie_x_idClie()
  '  End Sub

  '  Public Sub ListadoClie()
  '    'Dim testDialog As New FrmConsulta_Personas()
  '    'testDialog.Cod_Cat = 4
  '    'If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
  '    '    Me.LblUsuario.Tag = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)

  '    'Else
  '    '    'TxtCodAsistente.Text = ""
  '    'End If
  '    'testDialog.Dispose()
  '  End Sub

  '  Private Function EncontrarClie_x_idClie() As Boolean
  '    'Dim ObjPer As New persona
  '    'Try
  '    '    If Not IsNumeric(LblUsuario.Tag) Then Exit Function
  '    '    ObjPer = personaManager.GetItem(CInt(LblUsuario.Tag))
  '    '    Me.LblUsuario.Text = ""
  '    '    If Not IsNothing(ObjPer) Then
  '    '        If ObjPer.codigo_cat = 4 Then
  '    '            If ObjPer.tipo = "N" Then
  '    '                LblUsuario.Text = CStr(ObjPer.ape_pat) + " " + CStr(ObjPer.ape_mat) + " " + CStr(ObjPer.nombre)
  '    '            Else
  '    '                LblUsuario.Text = CStr(ObjPer.raz_soc)
  '    '            End If
  '    '        End If
  '    '    End If
  '    'Catch ex As Exception
  '    '    MsgBox(ex.Message)
  '    'End Try
  '  End Function

  '  Private Sub btnClearUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUS.Click
  '    LblUsuario.Text = "usuario"
  '    LblUsuario.Tag = 0
  '  End Sub

End Class