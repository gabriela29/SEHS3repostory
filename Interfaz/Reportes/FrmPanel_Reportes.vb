Imports System
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop
Imports System.IO
Imports Telerik.WinControls.UI
Imports Infragistics.Win.UltraWinGrid.ExcelExport


Public Class FrmPanel_Reportes
    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Public dtCatPer As DataTable, dtDocuemntos As DataTable
    Public pRV As String = ""

  Private Sub Listado_Opciones()

    Dim dtL As DataTable
    Dim x As Integer = 40
    Dim opcionesv(x), opciones(x) As String

    opcionesv(1) = 1

    opcionesv(3) = 3
    opcionesv(4) = 4

    opcionesv(11) = 11
    opcionesv(12) = 12
    opcionesv(13) = 13

    opcionesv(20) = 20

    opcionesv(18) = 18

    opcionesv(23) = 23
    opcionesv(26) = 26
    opcionesv(27) = 27

    opcionesv(31) = 31
    opcionesv(32) = 32
    opcionesv(33) = 33

    opciones(1) = "Stock Valorizado Balance"

    opciones(3) = "Ventas"
    opciones(4) = "Ranking Ventas"

    opciones(11) = "Registro Compra"
    opciones(12) = "Registro Venta"
    opciones(13) = "Recibo por Honorarios"

    opciones(20) = "Listado Saldo Inicial"

    opciones(18) = "Listado Dzmo por Colportor"

    opciones(23) = "Listado Movimiento Caja"

    opciones(26) = "Kardex "
    opciones(27) = "Kardex Consignación"

    opciones(31) = "Consolidado Registro Venta"
    opciones(32) = "Consolidado Registro Compra"
    opciones(33) = "DAOT"

    dtL = DosOpcionesManager.GetList("Panel_Rpt", opcionesv, opciones, x)
    dgvListado.DataSource = dtL
    dgvListado.Refresh()

  End Sub


  Private Sub FrmPanel_Reportes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    'LblUsuario.Tag = GestionSeguridadManager.idUsuario
    'LblUsuario.Text = GestionSeguridadManager.sUsuario
    lblProducto.Tag = 0
    lblPersonaId.Text = 0
    Call Listado_Opciones()
        Call llenar_combos()
        Me.CboFecha1.Value = Date.Now
        Me.CboFecha2.Value = Date.Now
        cboAnio.Text = Year(Date.Now)
        Call Habilitar(False)
        Call LibreriasFormularios.formatear_grid_Panel(dgvListado)
        Call LibreriasFormularios.formatear_grid(dgvDE)
        Me.cboDesde.Value = Date.Now
        Me.cboHasta.Value = Date.Now

    End Sub

    Private Sub MenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As RadMenuItem = CType(sender, RadMenuItem)

        Select Case menuItem.Text
            Case "CONTABILIZAR"
                Call Ejecutar_Info(1, "CONTABILIZAR")
            Case "Generar .4ta"
                Call Generar_Sunat(13, ".4ta")

            Case "Generar .ps4"
                Call Generar_Sunat(13, ".ps4")

            Case "Generar PLE R.V."
                Call Generar_Sunat(31, "RVPLE")

            Case "Exportar Excel R.V."
                Call Generar_Sunat(31, "RVEXCEL")

            Case "Generar PLE R.C."
                Call Generar_Sunat(32, "RCPLE")

            Case "Exportar Excel R.C."
                Call Generar_Sunat(32, "RCEXCEL")
        End Select

    End Sub

    Private Sub Generar_Sunat(ByVal vOpcion As Integer, ByVal vDato As String)

        Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
        Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0, vAlmacen As Integer = 0
        Dim vEmpresa As String = "", vRucEmp As String = "", vAnio As Integer = 0, vAlmacenid As Integer = 0
        Dim xNameFile As String = ""
        Select Case vOpcion
            Case 13
                If Not cboMes.Value > 0 Then
                    MessageBox.Show("Debe Seleccionar Mes", "SELECCIONAR", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    vMes = cboMes.Value
                End If

                If ChkAux2.Checked = False Then
                    vAlmacen = cboAlmacen.Value
                End If

                vAnio = Integer.Parse(cboAnio.Text)

                xNameFile = "0601" & cboAnio.Text & Integer.Parse(cboMes.Value).ToString("00") & GestionSeguridadManager.gRUCEmp & vDato
                If Sunat_Plame.Archivo_4ta(vAlmacen, vMes, vAnio, FolderBrowserDialog1, vDato) Then
                    MessageBox.Show("Proceso Terminado", "Información")
                End If
            Case 31

                If cboMes.Text = "" And cboAnio.Text = "" Then
                    MessageBox.Show("Debe Seleccionar Mes y Anio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If cboMes.Value >= 0 And cboAnio.Text > 0 Then
                    vMes = cboMes.Value
                    xComen = cboMes.Text & " / " & cboAnio.Text
                End If
                If Not cboAlmacen.Text.Trim = "" Then
                    vAlmacenid = cboAlmacen.Value
                End If
                vEmpresa = GestionSeguridadManager.gEmpresa
                vRucEmp = GestionSeguridadManager.gRUCEmp

                Dim frmP As New FrmProcesar_Info
                With frmP
                    .pNombre_Empresa = vEmpresa
                    .pRUC = vRucEmp
                    .pNombre_Uni = ""
                    .pmes = vMes
                    .pAnio = cboAnio.Text
                    .pOpcion = 31
                    .pAlmacenId = vAlmacenid
                    .pPLE_txt = IIf(vDato = "RVPLE", True, False) 'chkAux4.Checked
                    .pPeriodo = cboMes.Text & " - " & cboAnio.Text
                    .ShowDialog()
                End With
            Case 32
                'btnExcel.Visible = False

                If cboMes.Text = "" And cboAnio.Text = "" Then
                    MessageBox.Show("Debe Seleccionar Mes y Anio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If cboMes.Value >= 0 And cboAnio.Text > 0 Then
                    vMes = cboMes.Value
                    xComen = cboMes.Text & " / " & cboAnio.Text
                End If
                vEmpresa = GestionSeguridadManager.gEmpresa
                vRucEmp = GestionSeguridadManager.gRUCEmp
                If Not cboAlmacen.Text.Trim = "" Then
                    vAlmacenid = cboAlmacen.Value
                End If
                Dim frmP As New FrmProcesar_Info
                With frmP
                    .pNombre_Empresa = vEmpresa
                    .pRUC = vRucEmp
                    .pNombre_Uni = ""
                    .pmes = vMes
                    .pAnio = cboAnio.Text
                    .pOpcion = 32
                    .pAlmacenId = vAlmacenid
                    .pPLE_txt = IIf(vDato = "RCPLE", True, False) 'chkAux3.Checked
                    .pPeriodo = cboMes.Text & " - " & cboAnio.Text
                    .ShowDialog()
                End With
        End Select

    End Sub

    Private Sub Ejecutar_Info(ByVal vOpcion As Integer, ByVal vDato As String)
        Dim DtRpt As New DataTable, vMsg As String = ""
        Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
        Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0, vAlmacen As Integer
        Dim vEmpresa As String = "", vRucEmp As String = "", vAnio As Integer = 0
        Dim xNameFile As String = ""
        Try


            If vOpcion = 1 Then
                If vDato = "CONTABILIZAR" Then
                    If Not cboMes.Value > 0 Then
                        MessageBox.Show("Debe Seleccionar Mes", "SELECCIONAR", MessageBoxButtons.OK)
                        Exit Sub
                    Else
                        vMes = cboMes.Value
                    End If
                    If Not cboAnio.Text > 0 Then
                        MessageBox.Show("Debe Seleccionar Año", "SELECCIONAR", MessageBoxButtons.OK)
                        Exit Sub
                    Else
                        vAnio = cboAnio.Text
                    End If
                    vAlmacen = cboAlmacen.Value
                    If MessageBox.Show("Está seguro de contabilizar", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If MessageBox.Show("Esto cerrará el mes ¿Desea continuar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If ReportesManager.Stock_valorado_Actualziar(vMes, vAnio, vAlmacen) Then
                                MessageBox.Show("Operación con Éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Habilitar_Categoria(ByVal vOpcion As Integer)
        Try
            CboFamilia.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DSIAM")
        End Try
    End Sub

  Private Sub Habilitar_cboAuxiliar(ByVal vOpcion As Integer)
    Dim dtC As New DataTable, dtC1 As New DataTable
    Dim x As Integer = 0
    Select Case vOpcion
      Case 1
        x = 3
        Dim opcionesv(x), opciones(x) As String
        opcionesv(0) = 0
        opcionesv(1) = 1
        opcionesv(2) = 2
        opcionesv(3) = 3

        opciones(0) = "Valorizado Balance"
        opciones(1) = "Costo de Venta"
        opciones(2) = "Venta de Costo"
        opciones(3) = "Hoja de Trabajo"

        dtC = DosOpcionesManager.GetList("Condicion", opcionesv, opciones, x)

        With cboAuxiliar
          .DataSource = dtC
          .ValueMember = "opcionesv"
          .DisplayMember = "opciones"
          If .Rows.Count > 0 Then

            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)

          End If
        End With
        x = 4
        Dim opcionesvx(x), opcionesx(x) As String
        opcionesvx(0) = 1
        opcionesvx(1) = 0
        opcionesvx(2) = -1
        opcionesvx(3) = 99
        opcionesvx(4) = 999

        opcionesx(0) = "Mayor a Cero"
        opcionesx(1) = "Igual a Cero"
        opcionesx(2) = "Negativos"
        opcionesx(3) = "Mayor Igual a Cero"
        opcionesx(4) = "+/- Todos"

        dtC1 = DosOpcionesManager.GetList("Condicion", opcionesvx, opcionesx, x)

        With cboAuxiliar1
          .DataSource = dtC1
          .ValueMember = "opcionesv"
          .DisplayMember = "opciones"
          If .Rows.Count > 0 Then

            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)

          End If
        End With

        chkAux1.Enabled = True
        chkAux1.Text = "Resumen"

        ChkAux2.Enabled = True
        ChkAux2.Text = "Mostrar Costo"

        btnGenerar.Items.Clear()


      Case 3 'Opciones
        x = 6
        Dim opcionesv(x), opciones(x) As String
        opcionesv(0) = 0
        opcionesv(1) = 1
        opcionesv(2) = 2
        opcionesv(3) = 3
        opcionesv(4) = 4
        opcionesv(5) = 5
        opcionesv(6) = 6

        opciones(0) = "Registro de Ingresos"
        opciones(1) = "Asiento Provisión"
        opciones(2) = "Asientos de Ingresos Caja"
        opciones(3) = "Asientos de Sustento Caja"
        opciones(4) = "Resumen Asientos de Caja"

        opciones(5) = "Contado y Crédito"

        opciones(6) = "Sub Categoria"


        dtC = DosOpcionesManager.GetList("Condicion", opcionesv, opciones, x)

        With cboAuxiliar
          .DataSource = dtC
          .ValueMember = "opcionesv"
          .DisplayMember = "opciones"
          If .Rows.Count > 0 Then

            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)

          End If
        End With
        ChkAux2.Enabled = True
        ChkAux2.Text = "Consolidado"
      Case 4 'Opciones
        x = 1
        Dim opcionesv(x), opciones(x) As String
        opcionesv(0) = 0
        opcionesv(1) = 1

        opciones(0) = "Productos"
        opciones(1) = "Clientes"

        dtC = DosOpcionesManager.GetList("Condicion", opcionesv, opciones, x)

        With cboAuxiliar
          .DataSource = dtC
          .ValueMember = "opcionesv"
          .DisplayMember = "opciones"
          If .Rows.Count > 0 Then

            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)

          End If
        End With
        chkAux1.Enabled = False
        chkAux1.Text = ""
      Case 11
        btnGenerar.Items.Clear()
        Dim menuItem As New RadMenuItem()
        menuItem.Text = "Generar PLE R.C."
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click
      Case 12
        btnGenerar.Items.Clear()
        Dim menuItem As New RadMenuItem()
        menuItem.Text = "Generar PLE R.V."
        btnGenerar.Items.Add(menuItem)
        With cboAuxiliar
          .DataSource = dtDocuemntos
          .ValueMember = "documentoid"
          .DisplayMember = "nombre"
          If .Rows.Count > 0 Then

            '.SelectedRow = .GetRow(ChildRow.First)

          End If
        End With
        cboAuxiliar.Text = ""

        AddHandler menuItem.Click, AddressOf MenuItem_Click
      Case 13 'Generar
        btnGenerar.Items.Clear()
        Dim menuItem As New RadMenuItem()
        menuItem.Text = "Generar .4ta"
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click

        menuItem = New RadMenuItem
        menuItem.Text = "Generar .ps4"
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click
      Case 20
        With cboAuxiliar
          .DataSource = Nothing
          .DataSource = GestionTablas.dtperdoc
          .Refresh()
          .ValueMember = "documentoid"
          .DisplayMember = "nombre"
          If .Rows.Count > 0 Then
            .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          End If
        End With

      Case 31
        btnGenerar.Items.Clear()
        Dim menuItem As New RadMenuItem()
        menuItem.Text = "Generar PLE R.V."
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click

        menuItem = New RadMenuItem
        menuItem.Text = "Exportar Excel R.V."
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click

      Case 32
        btnGenerar.Items.Clear()
        Dim menuItem As New RadMenuItem()
        menuItem.Text = "Generar PLE R.C."
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click

        menuItem = New RadMenuItem
        menuItem.Text = "Generar PLE R.C. Test"
        btnGenerar.Items.Add(menuItem)
        AddHandler menuItem.Click, AddressOf MenuItem_Click

      Case 23

        With cboAuxiliar1
          .DataSource = dtDocuemntos
          .ValueMember = "documentoid"
          .DisplayMember = "nombre"
          If .Rows.Count > 0 Then

            '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)

          End If
        End With
    End Select

  End Sub


  Private Sub dgvListado_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgvListado.AfterSelectChange

    Dim lsel As UltraGridRow
    Dim SaldoSel As Single
    Dim vMes As Integer = 0, vAlmacen As Integer = 0
    SaldoSel = 0

    With dgvListado.Selected
      Call Habilitar(False)
      If .Rows.Count > 0 Then
        For Each lsel In .Rows
          If lsel.Band.Index = 0 Then
            If IsDBNull(lsel.Cells(0).Value) Then Exit Sub
            Select Case lsel.Cells(0).Value
              Case 1
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = True
                cboAuxiliar.Enabled = True
                Call Habilitar_cboAuxiliar(1)
                cboAuxiliar1.Enabled = True
                CboFamilia.Enabled = True
                Call Habilitar_Categoria(1)
                cboMes.Enabled = True
                cboMes.Value = Now.Month
                cboAnio.Enabled = True
                cboAnio.Text = Now.Year
                btnGenerar.Enabled = True
                btnGenerar.Text = "Opciones"

              Case 3
                BtnMostrar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                chkAux1.Enabled = True
                Call Habilitar_cboAuxiliar(3)
                cboAuxiliar.Enabled = True
              Case 4
                BtnMostrar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                'chkAux1.Enabled = True
                'chkAux1.Text = ".csv"
                'chkAux1.Checked = False
                Call Habilitar_cboAuxiliar(4)
                cboAuxiliar.Enabled = True
                CboFamilia.Enabled = True
              Case 11
                BtnMostrar.Enabled = True
                cboMes.Enabled = True
                cboAnio.Enabled = True
                ChkAux2.Enabled = True
                ChkAux2.Text = "Histórico"
                ChkAux2.Checked = False
                Call Habilitar_cboAuxiliar(11)
                btnGenerar.Enabled = True
                btnGenerar.Text = "Generar"

              Case 12
                BtnMostrar.Enabled = True
                cboMes.Enabled = True
                cboAnio.Enabled = True
                chkAux1.Enabled = True
                LblPersona.Enabled = True
                btnBuscaPer.Enabled = True
                chkAux1.Text = "Rango Fecha"
                ChkAux2.Enabled = True
                ChkAux2.Text = "Histórico"
                ChkAux2.Checked = False
                chkAux3.Enabled = True
                chkAux3.Text = "Agrupado por Cliente"
                chkAux3.Checked = False
                pRV = "RangoFecha"
                Call Habilitar_cboAuxiliar(12)
                cboAuxiliar.Enabled = True
                chkAux4.Enabled = True
                chkAux4.Text = "Sólo MB"
              Case 13
                BtnMostrar.Enabled = True
                cboMes.Enabled = True
                cboAnio.Enabled = True
                chkAux1.Enabled = True
                chkAux1.Text = "Registro Anual"
                chkAux1.Checked = False
                ChkAux2.Enabled = True
                ChkAux2.Text = "Consolidado"
                ChkAux2.Checked = False
                chkAux3.Checked = False
                Call Habilitar_cboAuxiliar(13)
                btnGenerar.Enabled = True
                btnGenerar.Text = "Generar"
              Case 20
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = True
                cboAuxiliar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                Call Habilitar_cboAuxiliar(20)

              Case 18
                BtnMostrar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                chkAux1.Enabled = True
                chkAux1.Text = "Sólo saldos"
                chkAux1.Checked = False
                ChkAux2.Enabled = True
                ChkAux2.Text = "Sin Nota de Crédito"
                ChkAux2.Checked = False

              Case 23
                BtnMostrar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                chkAux1.Enabled = True
                chkAux1.Text = "Resumen"
                chkAux1.Checked = True

                ChkAux2.Enabled = True
                ChkAux2.Text = "Ingreso"
                ChkAux2.Checked = True

                chkAux3.Enabled = True
                chkAux3.Text = "Salida"
                chkAux3.Checked = False

                chkAux4.Enabled = True
                chkAux4.Text = "Sólo Efectivo"
                chkAux4.Checked = False

                cboAuxiliar.Enabled = True
                cboAuxiliar1.Enabled = True
                Call Habilitar_cboAuxiliar(23)

              Case 26
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = True
                CboFamilia.Enabled = True
                Call Habilitar_Categoria(1)
                cboMes.Enabled = True
                cboAnio.Enabled = True
                btnLista_Producto.Enabled = True
                If GestionSeguridadManager.sUsuario = "admin" Then
                  chkAux1.Text = "Recalcular"
                  chkAux1.Enabled = True
                End If
                ChkAux2.Text = "Histórico"
                ChkAux2.Enabled = True
                BtnMostrar.Enabled = True
              Case 27
                BtnMostrar.Enabled = True
                CboFecha1.Enabled = True
                CboFecha2.Enabled = True
                btnLista_Producto.Enabled = True
                btnLista_Producto.Enabled = True
                btnBuscaPer.Enabled = True

              Case 31
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = False
                chkAux1.Enabled = True
                chkAux1.Text = "Rango Fecha"
                ChkAux2.Enabled = True
                ChkAux2.Text = "Histórico"
                ChkAux2.Checked = True
                UltraLabel2.Visible = True
                txtRuc.Enabled = True
                pRV = "RangoFecha"
                Call Habilitar_cboAuxiliar(31)
                cboMes.Enabled = True
                cboAnio.Enabled = True
                btnGenerar.Enabled = True
                btnGenerar.Text = "Generar"

              Case 32
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = False

                ChkAux2.Enabled = True
                ChkAux2.Text = "Histórico"
                ChkAux2.Checked = True

                cboMes.Enabled = True
                cboAnio.Enabled = True
                'UltraLabel3.Visible = True
                'txtCtaMaestra.Enabled = True
                UltraLabel2.Visible = True
                txtRuc.Enabled = True
                Call Habilitar_cboAuxiliar(32)
                btnBusca_Cta.Enabled = True
                btnGenerar.Enabled = True
                btnGenerar.Text = "Generar"

              Case 33
                BtnMostrar.Enabled = True
                cboAlmacen.Enabled = False
                cboMes.Enabled = True
                cboAnio.Enabled = True
                UltraLabel5.Visible = True
                txtImporte.Enabled = True
                txtImporte.Text = "1"
                chkAux1.Enabled = True
                chkAux1.Text = "VENTAS"
                chkAux1.Checked = False

            End Select

            'If lsel.Cells("codigo").Value > 0 And Not (lsel.Cells("orden").Value = 2) Then
            '    SaldoSel += lsel.Cells("saldo").Value
            'Else
            '    If (lsel.Cells("orden").Value = 2) Then
            '        lsel.Selected = False
            '    End If
            'End If
          End If

        Next

      End If
    End With

  End Sub

  Private Sub Habilitar(ByVal Valor As Boolean)
        cboAlmacen.Enabled = True 'Valor
        UltraLabel5.Visible = False 'Importe

        UltraLabel3.Visible = False 'Nro Cuenta
        UltraLabel2.Visible = False 'RUC
        cboAuxiliar1.Enabled = Valor
        cboAuxiliar.Enabled = Valor
        CboFamilia.Enabled = Valor
        cboMes.Enabled = Valor
        cboAnio.Enabled = Valor
        CboFecha1.Enabled = Valor
        CboFecha2.Enabled = Valor
        LblPersona.Enabled = Valor
        btnBuscaPer.Enabled = Valor
        lblProducto.Enabled = Valor
        btnLista_Producto.Enabled = Valor
        txtImporte.Enabled = Valor
        txtCtaMaestra.Enabled = Valor
        txtRuc.Enabled = Valor
        btnBusca_Cta.Enabled = Valor
        chkAux1.Checked = False
        chkAux1.Enabled = Valor
        chkAux1.Text = "..."
        ChkAux2.Checked = False
        ChkAux2.Enabled = Valor
        ChkAux2.Text = "..."
        chkAux3.Checked = False
        chkAux3.Enabled = Valor
        chkAux3.Text = "..."
        chkAux4.Checked = False
        chkAux4.Enabled = Valor
        chkAux4.Text = "..."
        btnGenerar.Items.Clear()
        BtnMostrar.Enabled = Valor
        cboMes.Value = 0
    pRV = ""
    LblPersona.Text = ""
    LblPersona.Tag = 0
    lblProducto.Text = ""
    lblProducto.Tag = 0

  End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        dgvListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dgvListado.DisplayLayout.Bands(0).Columns(1).Width = dgvListado.Width - 30
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.BackColor = Color.BlanchedAlmond


    End Sub

    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        e.Row.Cells(1).Appearance.Image = Global.Phoenix.My.Resources.Resources.printer
    End Sub

    Private Sub llenar_combos()
        Try


            Dim lMeses As New ClsCrearMeses

            With cboMes
                .DataSource = Nothing
                .DataSource = lMeses.GetList(False, False)
                .Refresh()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With
            With cboAnio
                .DataSource = Nothing
                .DataSource = lMeses.GetList_anios()
                .Refresh()
                .ValueMember = "nombre"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

            With CboFamilia
                .DataSource = Nothing
                .DataSource = subcategoriaManager.GetList(0, "")
                .DataBind()
                .ValueMember = "subcategoriaid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
            End With

            dtCatPer = New DataTable
            dtDocuemntos = New DataTable

            'dtCatPer = categoria_personaManager.GetList()
            dtDocuemntos = GestionTablas.dtperdoc

            With Me.cboAlmacen
                .DataSource = GestionTablas.dtFAlmacen
                '.DataBind()
                .ValueMember = "almacenid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

            With Me.cboAlmacenDE
                .DataSource = GestionTablas.dtFAlmacen
                '.DataBind()
                .ValueMember = "almacenid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

            With cboDocumentoDE
                .DataSource = Nothing
                .DataSource = dtDocuemntos
                .Refresh()
                .ValueMember = "documentoid"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
        End With
    End Sub

    Private Sub cboAlmacenDE_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacenDE.InitializeLayout
        With cboAlmacenDE.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True
        End With
    End Sub

    Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
        If cboAlmacen.ActiveRow Is Nothing Then
            If Not cboAlmacen.Text = "" Then
                cboAlmacen.Focus()
            End If
        End If
    End Sub

    Private Sub cboMes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMes.InitializeLayout
        cboMes.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboMes.DisplayLayout.Bands(0).Columns(1).Width = cboMes.Width
    End Sub

  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
    Dim vProc As Integer = 0, sAuxiliar As String = "", vAuxiliar As Integer = 0, cboAux As Integer = 0, cboAux1 As Integer = 0
    Dim vMes As Integer = 0, xComen As String = "", xSub As String = "", vAnio As Integer = 0
    Dim vAlmacenid As Integer = 0, vAlmacen As String = "", vUniId As Integer = GestionSeguridadManager.gUnidadId
    Dim vProducto As Long = 0, vPersona As Long = 0, vCatPer As Integer = 0, vFamilia As Integer = 0
    Dim vDesde As String = "", vHasta As String = "", vDocumentoid As Integer = 0
    Dim vEmpresa As String = GestionSeguridadManager.gEmpresa, vRUC As String = GestionSeguridadManager.gRUCEmp

    If dgvListado.Selected.Rows.Count > 0 Then
      If IsDBNull(dgvListado.ActiveRow.Cells(0).Value) Then
        Exit Sub
      End If
      Select Case dgvListado.ActiveRow.Cells(0).Value
        Case 1
          If Not cboMes.Value > 0 Then
            MessageBox.Show("Debe Seleccionar Mes", "SELECCIONAR", MessageBoxButtons.OK)
            Exit Sub
          Else
            vMes = cboMes.Value
          End If

          If Not cboAnio.Text > 0 Then
            MessageBox.Show("Debe Seleccionar Año", "SELECCIONAR", MessageBoxButtons.OK)
            Exit Sub
          Else
            vanio = cboAnio.Text
          End If

          If Not CboFamilia.Text = "" Then
            vFamilia = CboFamilia.Value
          End If
          If Not cboAlmacen.Text = "" Then
            vAlmacenid = cboAlmacen.Value
            vAlmacen = cboAlmacen.Text
          Else
            vAlmacen = GestionSeguridadManager.gUnidad
          End If

          vUniId = GestionSeguridadManager.gUnidadId
          cboAux1 = cboAuxiliar1.Value
          Dim frm As New FrmVisor_Listado
          If cboAuxiliar.Value = 0 Then
            xSub = "STOCK VALORADO"
            xComen = "Periodo: " & cboMes.Text & " - " & cboAnio.Text

            frm.RptStock_Valorado_Balance(Trim(GestionSeguridadManager.gEmpresa),
                                            vAlmacen, xSub, vMes, vAnio, vAlmacenid, 0, xComen, chkAux1.Checked, vFamilia, vUniId, False, ChkAux2.Checked, cboAux1)
            Call LibreriasFormularios.Ver_Form(frm, "Stock Valorado")

          ElseIf cboAuxiliar.Value = 1 Then
            xSub = "COSTO DE VENTA"
            xComen = "Periodo: " & cboMes.Text & " - " & cboAnio.Text
            frm.RptStock_Valorado_Balance(Trim(GestionSeguridadManager.gEmpresa),
                                      vAlmacen, xSub, vMes, vAnio, vAlmacenid, 1, xComen, False, 0, vUniId, False, False, cboAux1)

            Call LibreriasFormularios.Ver_Form(frm, "Costo Venta")
          ElseIf cboAuxiliar.Value = 2 Then
            xSub = "VENTA AL COSTO"
            xComen = "Periodo: " & cboMes.Text & " - " & cboAnio.Text
            frm.RptStock_Valorado_Balance(Trim(GestionSeguridadManager.gEmpresa),
                                            vAlmacen, xSub, vMes, vAnio, vAlmacenid, 2, xComen, chkAux1.Checked, vFamilia, vUniId, False, False, cboAux1)
            Call LibreriasFormularios.Ver_Form(frm, "Stock Valorado")

          ElseIf cboAuxiliar.Value = 3 Then
            xSub = "HOJA DE TRABAJO"
            xComen = "Periodo: " & cboMes.Text & " - " & cboAnio.Text

            frm.RptStock_Valorado_Balance(Trim(GestionSeguridadManager.gEmpresa),
                                            vAlmacen, xSub, vMes, vAnio, vAlmacenid, 3, xComen, chkAux1.Checked, vFamilia, vUniId, False, ChkAux2.Checked, cboAux1)
            Call LibreriasFormularios.Ver_Form(frm, "Hoja Trabajo")

          End If


        Case 3

          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          If ChkAux2.Checked Then
            vUniId = 0
          End If

          If cboAuxiliar.Value = 0 Then
            xSub = "LISTADO DE VENTAS"
            xComen = "Registro de Ingresos del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 1 Then
            xSub = "Asiento Provisión"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 2 Then
            xSub = "Asientos de Caja Ingresos"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 3 Then
            xSub = "Asientos de Caja Sustento"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 4 Then
            xSub = "Resumen Asiento de Caja"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 5 Then
            xSub = "Ingresos al Contado y Crédito"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 6 Then
            xSub = "Ventas por Sub Categoría"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          End If
          If Not cboAlmacen.Text = "" Then
            vAlmacen = cboAlmacen.Value
            vAlmacenid = cboAlmacen.Value
          End If

          If chkAux1.Checked = False Then
            Dim frm As New FrmVisor_Ventas
            sAuxiliar = IIf(cboAuxiliar.Value = 0, "", cboAuxiliar.Text)
            If cboAuxiliar.Value = 0 Then
              frm.rptRegistro_Ingresos(vAlmacen, vDesde, vHasta, 0, GestionSeguridadManager.gEmpresa,
                                          cboAlmacen.Text, xSub, xComen)
              LibreriasFormularios.Ver_Form(frm, "Reporte Ingresos")
            ElseIf cboAuxiliar.Value = 1 Then
              Dim dtTemp As New DataTable

              'dtTemp = reportes_ventasManager.Asiento_Prov_Ingreso(vDesde, vHasta, cboAlmacen.Value)

              frm.RptAsiento_Prov_Ingresos(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "ASIENTO VENTA PROVISIÓN", xComen)
              LibreriasFormularios.Ver_Form(frm, "Asiento Ingresos")

            ElseIf cboAuxiliar.Value = 2 Then

              frm.rptDet_Movimiento_Caja_Ing(cboAlmacen.Value, vDesde, vHasta, 0, GestionSeguridadManager.gEmpresa,
                                             cboAlmacen.Text, "Ingresos - Movimiento Caja", xComen)
              frm.MdiParent = Me.MdiParent
              frm.Show()

            ElseIf cboAuxiliar.Value = 3 Then
              frm.rptDet_Movimiento_Caja_Sus(cboAlmacen.Value, vDesde, vHasta, 0, GestionSeguridadManager.gEmpresa,
                                             cboAlmacen.Text, "Egresos y Depósitos al Banco - Movimiento Caja", xComen)
              LibreriasFormularios.Ver_Form(frm, "Movimiento Caja")

            ElseIf cboAuxiliar.Value = 4 Then

              frm.rptMovimiento_Caja(cboAlmacen.Value, vDesde, vHasta, 0, GestionSeguridadManager.gEmpresa,
                                     cboAlmacen.Text, "Resumen - Movimiento Caja", xComen)
              LibreriasFormularios.Ver_Form(frm, "Movimiento Caja")

            ElseIf cboAuxiliar.Value = 5 Then
              frm.rptVentas_Documento("", vDesde, vHasta, 0, "", "", vAlmacenid, GestionSeguridadManager.gEmpresa,
                                      cboAlmacen.Text, xSub, xComen)

              LibreriasFormularios.Ver_Form(frm, "Detalle Doc. Venta")
            ElseIf cboAuxiliar.Value = 6 Then
              frm.rptVentas_SubCategoria("TODOS", vDesde, vHasta, 0, vAlmacenid, GestionSeguridadManager.gEmpresa,
                                      cboAlmacen.Text, xSub, xComen, vUniId)

              LibreriasFormularios.Ver_Form(frm, "Venta por Familias")

            End If


          Else
            Dim dtData As New DataTable, xNameFile As String = ""


            xNameFile = "C:\ctr_ing\ctr_i" & cboAlmacen.Text & "."
            xNameFile = xNameFile & LibreriasFormularios.Formato_Fecha_b(CboFecha1.Text) & "."
            xNameFile = xNameFile & LibreriasFormularios.Formato_Fecha_b(CboFecha2.Text) & ".csv"

            If cboAuxiliar.Value = 1 Then
              'dtData = reportes_ventasManager.Asiento_Prov_Ingreso(vDesde, vHasta, cboAlmacen.Value)
              xComen = "Detalle de Movimientos del: " & Me.CboFecha1.Text & " Al " & Me.CboFecha2.Text
              Call Guardar_CSV(xNameFile, dtData, xComen)
            ElseIf cboAuxiliar.Value = 2 Then
              dtData = reportes_ventasManager.Movimiento_Caja(vPersona, cboAlmacen.Value, vDesde, vHasta, 1)
              xComen = cboAuxiliar.Text & " " & Me.CboFecha1.Text
              Call Guardar_CSV_Caja(xNameFile, dtData, xComen, 1)
            ElseIf cboAuxiliar.Value = 3 Then
              dtData = reportes_ventasManager.Movimiento_Caja(vPersona, cboAlmacen.Value, vDesde, vHasta, 2)
              xComen = cboAuxiliar.Text & " " & Me.CboFecha1.Text
              Call Guardar_CSV_Caja(xNameFile, dtData, xComen, 2)
            End If

          End If
        Case 4
          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

          If cboAuxiliar.Value = 0 Then
            xSub = "LISTADO DE RANKING POR PRODUCTOS"
            xComen = "DEL: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          ElseIf cboAuxiliar.Value = 1 Then
            xSub = "LISTADO DE RANKING POR CLIENTES"
            xComen = "Del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          End If
          If Not CboFamilia.Text = "" Then
            vCatPer = CboFamilia.Value
          End If

          vAlmacen = cboAlmacen.Value


          Dim frm As New FrmVisor_Ventas
          sAuxiliar = IIf(cboAuxiliar.Value = 0, "", cboAuxiliar.Text)
          If cboAuxiliar.Value = 0 Then
            frm.rptRanking_Ventas("producto", "mas", "cantidad", vDesde, vHasta, cboAlmacen.Value, 0,
                                        GestionSeguridadManager.gEmpresa,
                                        cboAlmacen.Text, xSub, xComen, 0, GestionSeguridadManager.gUnidadId)
            Call LibreriasFormularios.Ver_Form(frm, "Rankinh")
          ElseIf cboAuxiliar.Value = 1 Then

            frm.rptRanking_Ventas("cliente", "mas", "cantidad", vDesde, vHasta, cboAlmacen.Value, 0,
                                        Trim(GestionSeguridadManager.gEmpresa),
                                        cboAlmacen.Text, xSub, xComen, vCatPer, GestionSeguridadManager.gUnidadId)
            Call LibreriasFormularios.Ver_Form(frm, "RANKING")

          End If




        Case 11
          If chkAux1.Checked = False Then
            vMes = cboMes.Value
          End If
          If chkAllAlmacen.Checked Then
            vAlmacenid = 0
          Else
            vAlmacenid = cboAlmacen.Value
          End If


          Dim frm As New FrmVisualizador_Varios

          frm.RptRegistro_Compras_sunat(vUniId, vAlmacenid, vMes, CInt(cboAnio.Text), 0, txtRuc.Text, chkAux3.Checked, vEmpresa, vRUC, cboAlmacen.Text,
                                         "Registro de Compra", cboMes.Text & "-" & cboAnio.Text)
          Call LibreriasFormularios.Ver_Form(frm, "Registro Compra")

        Case 12
          xComen = (cboMes.Text & " / " & cboAnio.Text)
          vanio = Integer.Parse(cboAnio.Text)
          vMes = cboMes.Value
          vUniId = GestionSeguridadManager.gUnidadId
          Dim vTabla As String = ""
          If chkAux1.Checked Then
            vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
            vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
            vanio = 0
            vMes = 0
            xComen = vDesde & " / " & vHasta
          End If

          If chkAllAlmacen.Checked Then
            vAlmacen = 0
          Else
            vAlmacenid = cboAlmacen.Value
          End If
          vPersona = 0
          If Not lblPersonaId.Text = "" Then
            vPersona = Long.Parse(lblPersonaId.Text)
            xComen = " Cliente: " & LblPersona.Text
          End If
          If Not cboAuxiliar.Text = "" Then
            vDocumentoid = cboAuxiliar.Value
            xComen = xComen & " - " & cboAuxiliar.Text
          End If

          If chkAux4.Checked Then
            vTabla = "MB"
            xComen = xComen & " - " & "Sólo MB"
          End If

          Dim frm As New FrmVisualizador_Varios
          If chkAux3.Checked Then
            frm.RptRegistro_Ventas_gClie(vUniId, vAlmacenid, vMes, CInt(cboAnio.Text), vPersona, "",
                                     Trim(GestionSeguridadManager.gEmpresa),
                                     cboAlmacen.Text, "REGISTRO DE VENTA AGRUPADO POR CLIENTE",
                                     xComen, ChkAux2.Checked, vDesde, vHasta, vDocumentoid, vTabla)
            Call LibreriasFormularios.Ver_Form(frm, "Registro Ventas Cli.")
          Else
            frm.RptRegistro_Ventas_Sunat(vUniId, vAlmacenid, vMes, vanio, vPersona, "",
                                     Trim(GestionSeguridadManager.gEmpresa),
                                     cboAlmacen.Text, "REGISTRO DE VENTA",
                                     xComen, ChkAux2.Checked, vDesde, vHasta, vDocumentoid, vTabla)
            Call LibreriasFormularios.Ver_Form(frm, "Registro Ventas")
          End If

        Case 13
          If chkAux1.Checked = False Then
            vMes = cboMes.Value
          End If
          If ChkAux2.Checked = False Then
            vAlmacenid = cboAlmacen.Value
          End If

          Dim frm As New FrmVisualizador_Varios
          vEmpresa = GestionSeguridadManager.gEmpresa
          frm.RptRegistro_RH(vAlmacenid, vMes, CInt(cboAnio.Text), vEmpresa, cboAlmacen.Text,
                                          0, Trim(txtCtaMaestra.Text) & "", True, False, cboMes.Text & "-" & cboAnio.Text, vRUC)
          Call LibreriasFormularios.Ver_Form(frm, "Registro RH")

        Case 18
          Dim vDetalle As Boolean = True, vNC As Boolean = True
          vAlmacen = cboAlmacen.Value
          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          xSub = "Listado Diezmo por Colportor"
          xComen = "De: " & vDesde & " A " & vHasta
          If chkAux1.Checked Then
            xSub = "Listado Diezmo por Colportor - SALDOS"
            vDetalle = False
          End If

          If ChkAux2.Checked Then
            xSub = "Listado Diezmo por Colportor - SALDOS (sin nota de crédito)"
            vNC = False
          End If

          Dim frm As New FrmVisor_Ventas

          frm.rptLista_Dzmo(vAlmacen, vDesde, vHasta, vDetalle, vNC,
                                   Trim(GestionSeguridadManager.gEmpresa),
                                   cboAlmacen.Text, xSub, xComen)
          Call LibreriasFormularios.Ver_Form(frm, "Lista Diezmo")
        Case 20

          cboAux = 0
          vAlmacen = cboAlmacen.Value
          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          If Not cboAuxiliar.Text = "" Then
            cboAux = cboAuxiliar.Value
          End If

          Dim nDtl As New DataTable
          nDtl = ReportesManager.rptListado_PorCobrarN(0, vAlmacen, vDesde, vHasta, cboAux)

          Dim frm As New FrmVisor_PorCobrar
          vEmpresa = GestionSeguridadManager.gEmpresa
          frm.RptPorCobrarN(nDtl, vEmpresa, cboAlmacen.Text, "Lista Saldos Iniciales")
          Call LibreriasFormularios.Ver_Form(frm, "Lista Saldos Iniciales")
        Case 23
          Dim vTipo As String = "A", vEfectivo As Integer = 0
          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

          If chkAux1.Checked And ChkAux2.Checked And chkAux3.Checked Then
            xSub = "Listado de Movimiento de Caja (resumen por persona/ingresos y egresos)"

          End If
          If chkAux1.Checked And ChkAux2.Checked And chkAux3.Checked = False Then
            xSub = "Listado de Movimiento de Caja (resumen por persona/ingresos)"
            vTipo = "I"
          End If
          If chkAux1.Checked And ChkAux2.Checked = False And chkAux3.Checked = True Then
            xSub = "Listado de Movimiento de Caja (resumen por persona/egresos)"
            vTipo = "S"
          End If


          If chkAux1.Checked = False And ChkAux2.Checked And chkAux3.Checked Then
            xSub = "Listado de Movimiento de Caja (detalle/ingresos y egresos)"
          End If
          If chkAux1.Checked = False And ChkAux2.Checked And chkAux3.Checked = False Then
            xSub = "Listado de Movimiento de Caja (detalle/ingresos)"
            vTipo = "I"
          End If
          If chkAux1.Checked = False And ChkAux2.Checked = False And chkAux3.Checked = True Then
            xSub = "Listado de Movimiento de Caja (detalle/egresos)"
            vTipo = "S"
          End If
          If chkAux4.Checked Then
            vEfectivo = 1
          End If

          If cboAuxiliar.Text = "" And cboAuxiliar1.Text = "" Then

            xComen = "Registro de Ingresos del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value)
          End If


          xComen = "Registro de Ingresos del: " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha1.Value) & " Al " & LibreriasFormularios.Formato_Fecha_Mostrar(CboFecha2.Value) & " " & cboAuxiliar.Text & " " & cboAuxiliar1.Text
          If cboAuxiliar.Text <> "" Then
            cboAux = cboAuxiliar.Value
          End If
          If cboAuxiliar1.Text <> "" Then
            cboAux1 = cboAuxiliar.Value
          End If

          vAlmacen = cboAlmacen.Value


          Dim nDtl As New DataTable
          nDtl = ReportesManager.rptListado_Mov_Caja(vTipo, vAlmacen, vDesde, vHasta, "", 0, cboAux1, vEfectivo, cboAux)

          Dim frmvc As New FrmVisorCaja


          frmvc.RptList_Mov_Caja(nDtl, GestionSeguridadManager.gEmpresa,
                                         cboAlmacen.Text, xSub, xComen, chkAux1.Checked)
          Call LibreriasFormularios.Ver_Form(frmvc, "Mov. Caja")
        Case 26
          If Not cboMes.Value > 0 Then
            MessageBox.Show("Debe Seleccionar Mes", "SELECCIONAR", MessageBoxButtons.OK)
            Exit Sub
          Else
            vMes = cboMes.Value
          End If
          If cboAnio.Text = "" Then
            MessageBox.Show("Debe Seleccionar Anio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
          End If
          vMes = cboMes.Value
          vAnio = cboAnio.Text
          vProducto = lblProducto.Tag
          vAlmacen = cboAlmacen.Value
          If Not CboFamilia.Text = "" Then
            vFamilia = CboFamilia.Value
          End If

          Dim frm As New FrmVisualizador_Varios
          vEmpresa = Trim(GestionSeguridadManager.gEmpresa)
          frm.RptRegistro_Kardex(vMes, vAnio, vProducto, vAlmacen, vFamilia, True, GestionSeguridadManager.gUnidadId, chkAux1.Checked, ChkAux2.Checked,
                                 GestionSeguridadManager.gRUCEmp, cboMes.Text & " - " & cboAnio.Text,
                                 vEmpresa, cboAlmacen.Text)
          Call LibreriasFormularios.Ver_Form(frm, "Kardex")

        Case 27
          vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersona = lblPersonaId.Text
          vProducto = lblProducto.Tag
          vAlmacen = cboAlmacen.Value
          Dim nDt As New DataTable
          nDt = reportes_consignacionManager.rptKardex(vAlmacen, vProducto, vDesde, vHasta, vPersona)
          xComen = "Kardex Consignación Periodo : " & CboFecha1.Value & " A " & CboFecha2.Value

          If nDt.Rows.Count > 0 Then

            Dim frm As New FrmVisor_Consignacion
            vEmpresa = Trim(GestionSeguridadManager.gEmpresa)
            frm.RptKardex_consignacion(nDt, Trim(GestionSeguridadManager.gEmpresa), cboAlmacen.Text, xComen)
            Call LibreriasFormularios.Ver_Form(frm, "Kardex Consig.")

          Else
            MessageBox.Show("No hay Registros que mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
          End If

        Case 31

          xComen = IIf(cboMes.Value > 0, cboMes.Text & " / ", "") & cboAnio.Text
          vanio = Integer.Parse(cboAnio.Text)
          If cboAnio.Text = "" Then
            MessageBox.Show("Debe Seleccionar Mes y Anio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
          End If

          vMes = cboMes.Value
          If chkAux1.Checked Then
            vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
            vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)
            xComen = "Desde: " & cboDesde.Value & " Hasta: " & cboHasta.Value
            vanio = 0
          End If

          If Not txtRuc.Text.Trim = "" Then
            xComen = xComen & " Doc.: " & txtRuc.Text
          End If


          Dim frm As New FrmVisualizador_Varios

          frm.RptRegistro_Ventas_Sunat(0, 0, vMes, vanio, 0, txtRuc.Text,
                                       GestionSeguridadManager.gEmpresa, "Registro de Ventas",
                                       xComen, vRUC, ChkAux2.Checked, vDesde, vHasta, 0, "")


          Call LibreriasFormularios.Ver_Form(frm, "Registro Ventas")
        Case 32
          xComen = ""
          If cboAnio.Text = "" Then
            MessageBox.Show("Debe Seleccionar Mes y Anio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
          End If

          vMes = cboMes.Value
          xComen = IIf(vMes > 0, cboMes.Text & " / ", "") & cboAnio.Text
          If Not txtRuc.Text.Trim = "" Then
            xComen = xComen & " Doc.: " & txtRuc.Text
          End If
          Dim frm As New FrmVisualizador_Varios

          frm.RptRegistro_Compras_sunat(0, 0, vMes, CInt(cboAnio.Text), lblPersonaId.Text, txtRuc.Text, ChkAux2.Checked, vEmpresa, vRUC,
                                          "Registro de Compras", "", xComen)
          Call LibreriasFormularios.Ver_Form(frm, "Registro Compras Sunat")


        Case 33
          xComen = "CONSOLIDADO COMPRAS - " & cboAnio.Text

          If chkAux1.Checked Then
            xComen = "CONSOLIDADO VENTAS - " & cboAnio.Text
          End If
          vMes = cboMes.Value
          If vMes > 0 Then
            xComen = xComen & " del mes: " & cboMes.Text
          End If
          Dim frm As New FrmVisualizador_Varios

          frm.RptRegistro_Daot(0, vMes, chkAux1.Checked, Integer.Parse(cboAnio.Text), txtImporte.Text,
                               vEmpresa, vRUC, xComen, "DAOT - " & cboAnio.Text, xComen)
          Call LibreriasFormularios.Ver_Form(frm, "DAOT")

      End Select
    End If

  End Sub

  Private Sub RptAsinto_Gastos_Condicion()

        Dim DtpLt As New DataTable
        Dim vLote As String = ""
        Dim vDesde As String = "", vHasta As String = ""
        Try
            vDesde = LibreriasFormularios.Formato_Fecha(CboFecha1.Value)
            vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

            If Not Trim(Me.txtCtaMaestra.Text) = "" Then
                DtpLt = detalle_lote_gastosManager.Asiento_Codigocion(GestionSeguridadManager.gUnidadId, Trim(txtCtaMaestra.Text), 0, vDesde, vHasta)
            Else
                MsgBox("Debe Ingresar un Nro de Cuenta", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
                Exit Sub
            End If

            'Dim frm As New FrmVisorGastos
            'vLote = "Gastos de la Cuenta: " & Trim(txtCtaMaestra.Text) & " Entre: " & vDesde & " - " & vHasta
            'frm.RptAsiento_Lote(DtpLt, Trim(GestionSeguridadManager.gEmpresa), cboUnidad_Negocio.Text, vLote)

            'frm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Generar_xyz()

        Dim DtRpt As New DataTable, xCondi As String = "", vMsg As String = ""
        Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
        Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0, vAlmacen As Integer
        Dim vEmpresa As String = "", vRucEmp As String = "", vAnio As Integer = 0
        Dim xNameFile As String = ""
        Try
            If "0" = "CONTABILIZAR" Then
                If Not cboMes.Value > 0 Then
                    MessageBox.Show("Debe Seleccionar Mes", "SELECCIONAR", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    vMes = cboMes.Value
                End If
                If Not cboAnio.Text > 0 Then
                    MessageBox.Show("Debe Seleccionar Año", "SELECCIONAR", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    vAnio = cboAnio.Text
                End If
                vAlmacen = cboAlmacen.Value
                If MessageBox.Show("Está seguro de contabilizar", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If MessageBox.Show("Esto cerrará el mes ¿Desea continuar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If ReportesManager.Stock_valorado_Actualziar(vMes, vAnio, vAlmacen) Then
                            MessageBox.Show("Operación con Éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If
                    End If

                End If

            Else
            
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportarExcel(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

        Dim DtRw As DataRow
        Dim xfield, V, H As Long
        Dim Centro_Costo As Long = 0
        Dim xPt As String = ""
        xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


        Dim objCelda As Excel.Range

        objCelda = ObExel.Range("E2", Type.Missing)
        objCelda.EntireColumn.ColumnWidth = 3
        objCelda = ObExel.Range("F3", Type.Missing)
        objCelda.EntireColumn.ColumnWidth = 3
        objCelda = ObExel.Range("G3", Type.Missing)
        objCelda.EntireColumn.ColumnWidth = 40
        objCelda = ObExel.Range("H3", Type.Missing)
        objCelda.EntireColumn.ColumnWidth = 3
        objCelda = ObExel.Range("I3", Type.Missing)
        objCelda.EntireColumn.ColumnWidth = 3
        'objCelda = objHojaExcel.Range("C3", Type.Missing)
        'objCelda.Value = "Nombre"

        'objCelda = objHojaExcel.Range("D3", Type.Missing)
        'objCelda.Value = "Precio RD$"
        'objCelda.EntireColumn .Width =
        objCelda = ObExel.Range("D2", Type.Missing)
        If xPt = "." Then
            objCelda.EntireColumn.NumberFormat = "0.00"
        Else
            objCelda.EntireColumn.NumberFormat = "0,00"
        End If

        xfield = 1
        V = 2
        H = 1


        'ObExel.Workbooks.Add()
        'Empezamos a Pasar los datos a Excel
        'Primera Linea
        'ObExel.Cells(1, 1) = unidad_negocioManager.GetList_Unidad_Entidad_GetRow(cboUnidad_Negocio.Value)
        ' ''Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)
        'ObExel.Cells(1, 2) = xCondi

        For Each DtRw In Dtp.Rows
            With ObExel

                'Demas Lineas
                .Cells(V, H) = (DtRw("cuenta"))
                .Cells(V, H + 1) = (DtRw("ctacte"))
                .Cells(V, H + 2) = (DtRw("c_costo"))

                If CSng(DtRw("monto_debe")) > 0 Then
                    .Cells(V, H + 3) = FormatNumber(CSng(DtRw("monto_debe")), 2, TriState.True, TriState.False, TriState.True)
                Else
                    .Cells(V, H + 3) = FormatNumber(CSng(DtRw("monto_haber")), 2, TriState.True, TriState.False, TriState.True)
                End If
                .Cells(V, H + 4) = " "
                .Cells(V, H + 5) = " "


                .Cells(V, H + 6) = Mid(Trim(DtRw("glosa")), 1, 50)


                .Cells(V, H + 7) = " "
                .Cells(V, H + 8) = "N"

            End With
            V = V + 1
        Next DtRw

        ObExel.Visible = True
    End Sub

    ' botón para recorrer guardarlo en el archivo 

    Private Function Guardar_CSV(ByVal vNameFile As String, ByVal Dtp As DataTable, ByVal xCondi As String) As Boolean

        Const DELIMITADOR As String = ";"
        Dim DtRw As DataRow
        Dim Centro_Costo As Long = 0
        ' ruta del fichero de texto
        Dim ARCHIVO_CSV As String = ""
        ARCHIVO_CSV = vNameFile '"C:\ctr_" & cboUnidad_Negocio.Value & "." & Format(CboFecha1.Text, "ddmmyy") & "." & Format(CboFecha2.Text, "ddmmyy") & ".csv"

        Try
            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

                'variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty

                linea = "7124" & DELIMITADOR
                linea = linea & xCondi
                archivo.WriteLine(linea.ToString)
                ''Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)

                ' Recorrer las filas del dataTable
                ' Recorrer la cantidad de columnas que contiene el dataTable
                For Each DtRw In Dtp.Rows
                    ' vaciar la línea
                    linea = String.Empty

                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    'linea = linea & .Item(col, fila).Value.ToString & DELIMITADOR                    
                    linea = linea & DtRw("cuenta").ToString & DELIMITADOR
                    'Demas Lineas
                    ''linea = linea & DtRw("cuenta").ToString & DELIMITADOR
                    linea = linea & DtRw("ctacte").ToString & DELIMITADOR
                    linea = linea & DtRw("c_costo").ToString & DELIMITADOR

                    'If CSng(DtRw("monto_debe")) > 0 Then
                    linea = linea & FormatNumber(CSng(DtRw("monto_debe")), 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR
                    'Else
                    'linea = linea & FormatNumber(CSng(DtRw("monto_haber")), 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR
                    'End If
                    linea = linea & "" & DELIMITADOR
                    linea = linea & "" & DELIMITADOR


                    linea = linea & Mid(Trim(DtRw("glosa")), 1, 50) & DELIMITADOR


                    linea = linea & "" & DELIMITADOR
                    linea = linea & "N"
                    ' Escribir una línea con el método WriteLine
                    With archivo
                        ' eliminar el último caracter ";" de la cadena
                        ''linea = linea.Remove(linea.Length - 1).ToString
                        ' escribir la fila
                        .WriteLine(linea.ToString)
                    End With
                Next DtRw

            End Using
            Guardar_CSV = True
            ' Abrir con Process.Start el archivo de texto
            ''Process.Start(ARCHIVO_CSV)
            MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
            'error
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function Guardar_CSV_Caja(ByVal vNameFile As String, ByVal Dtp As DataTable, ByVal xCondi As String, ByVal xTipo As Integer) As Boolean

        Const DELIMITADOR As String = ";"
        Dim DtRw As DataRow
        Dim Centro_Costo As Long = 0
        ' ruta del fichero de texto
        Dim ARCHIVO_CSV As String = ""
        ARCHIVO_CSV = vNameFile '"C:\ctr_" & cboUnidad_Negocio.Value & "." & Format(CboFecha1.Text, "ddmmyy") & "." & Format(CboFecha2.Text, "ddmmyy") & ".csv"

        Try
            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

                'variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty
                Dim xLi As Long = 0, vImporte As Single = 0
                linea = "7124" & DELIMITADOR
                linea = linea & xCondi
                archivo.WriteLine(linea.ToString)
                ''Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)

                ' Recorrer las filas del dataTable

                ' Recorrer la cantidad de columnas que contiene el dataTable
                For Each DtRw In Dtp.Rows
                    ' vaciar la línea
                    linea = String.Empty
                    If xLi = 0 Then
                        linea = DtRw("ctagp").ToString & DELIMITADOR
                        linea = linea & DELIMITADOR 'DtRw("ctacte").ToString & DELIMITADOR
                        linea = linea & DtRw("c_costo").ToString & DELIMITADOR

                        If xTipo = 1 Then
                            linea = linea & FormatNumber(CSng(DtRw("debito")), 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR
                        Else
                            vImporte = Single.Parse(DtRw("debito")) * -1
                            linea = linea & FormatNumber(vImporte, 2, TriState.True, TriState.False, TriState.True) & DELIMITADOR

                        End If

                        linea = linea & "" & DELIMITADOR
                        linea = linea & "" & DELIMITADOR


                        linea = linea & Mid(Trim(DtRw("glosa")), 1, 50) & DELIMITADOR


                        linea = linea & "" & DELIMITADOR
                        linea = linea & "N"
                        archivo.WriteLine(linea.ToString)
                        xLi = xLi + 1
                    End If
                    linea = String.Empty
                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                    'linea = linea & .Item(col, fila).Value.ToString & DELIMITADOR                    
                    linea = DtRw("cuenta").ToString & DELIMITADOR
                    'Demas Lineas
                    ''linea = linea & DtRw("cuenta").ToString & DELIMITADOR
                    linea = linea & DtRw("ctacte").ToString & DELIMITADOR
                    linea = linea & DtRw("c_costo").ToString & DELIMITADOR

                    If xTipo = 1 Then
                        vImporte = Single.Parse(DtRw("credito")) * -1
                        linea = linea & vImporte & DELIMITADOR
                    Else
                        vImporte = Single.Parse(DtRw("credito"))
                        linea = linea & vImporte & DELIMITADOR
                    End If

                    linea = linea & "" & DELIMITADOR
                    linea = linea & "" & DELIMITADOR


                    linea = linea & Mid(Trim(DtRw("detalle")), 1, 50) & DELIMITADOR


                    linea = linea & "" & DELIMITADOR
                    linea = linea & "N"

                    ' Escribir una línea con el método WriteLine
                    With archivo
                        ' eliminar el último caracter ";" de la cadena
                        ''linea = linea.Remove(linea.Length - 1).ToString
                        ' escribir la fila
                        .WriteLine(linea.ToString)
                    End With

                Next DtRw

            End Using
            Guardar_CSV_Caja = True
            ' Abrir con Process.Start el archivo de texto
            ''Process.Start(ARCHIVO_CSV)
            MessageBox.Show("El Archivo se Guardó en: " & ARCHIVO_CSV, "INFORMACIÓN", MessageBoxButtons.OK)
            'error
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Sub ExportarExcel_RH(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

        Dim DtRw As DataRow
        Dim xfield, V, H As Long
        Dim Centro_Costo As Long = 0
        Dim xPt As String = ""

        'ObExel = CreateObject("Excel.Application")
        'ObExel. (App.Path & "\Txt\honorarios.xls")

        'xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


        'Dim objCelda As Excel.Range

        ''objCelda = ObExel.Range("E2", Type.Missing)
        ''objCelda.EntireColumn.ColumnWidth = 3
        ''objCelda = ObExel.Range("F3", Type.Missing)
        ''objCelda.EntireColumn.ColumnWidth = 3
        ''objCelda = ObExel.Range("G3", Type.Missing)
        ''objCelda.EntireColumn.ColumnWidth = 40
        ''objCelda = ObExel.Range("H3", Type.Missing)
        ''objCelda.EntireColumn.ColumnWidth = 3
        ''objCelda = ObExel.Range("I3", Type.Missing)
        ''objCelda.EntireColumn.ColumnWidth = 3
        'objCelda = objHojaExcel.Range("C3", Type.Missing)
        'objCelda.Value = "Nombre"

        'objCelda = objHojaExcel.Range("D3", Type.Missing)
        'objCelda.Value = "Precio RD$"
        'objCelda.EntireColumn .Width =
        ''objCelda = ObExel.Range("D2", Type.Missing)
        ''If xPt = "." Then
        ''    objCelda.EntireColumn.NumberFormat = "0.00"
        ''Else
        ''    objCelda.EntireColumn.NumberFormat = "0,00"
        ''End If

        xfield = 1
        V = 5
        H = 2


    'ObExel.Workbooks.Add()
    'Empezamos a Pasar los datos a Excel
    'Primera Linea        
    'Centro_Costo = unidad_negocioManager.GetList_Unidad_Centro_Costo_GetRow(cboUnidad_Negocio.Value)
    ObExel.Cells(1, 3) = xCondi

        For Each DtRw In Dtp.Rows
            With ObExel

                'Demas Lineas
                .Cells(V, H) = (DtRw("rucdni"))
                .Cells(V, H + 1) = Trim(DtRw("apepat"))
                .Cells(V, H + 2) = Trim(DtRw("apemat"))
                .Cells(V, H + 3) = Trim(DtRw("nombre"))
                If IsDate(DtRw("nacimiento")) Then
                    .Cells(V, H + 4) = (DtRw("nacimiento"))
                Else
                    .Cells(V, H + 4) = " "
                End If
                .Cells(V, H + 5) = Trim(DtRw("serie"))
                .Cells(V, H + 6) = Trim(DtRw("numero"))
                .Cells(V, H + 7) = (DtRw("emision"))
                .Cells(V, H + 8) = (DtRw("cancelacion"))
                .Cells(V, H + 9) = (DtRw("importe"))
                .Cells(V, H + 10) = DtRw("rtrh")
                .Cells(V, H + 11) = DtRw("rh")

            End With
            V = V + 1
        Next DtRw

    End Sub

    Private Sub cboNivel_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAuxiliar1.InitializeLayout
        With cboAuxiliar1.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboAuxiliar1.Width
        End With

    End Sub

    Private Sub cboGrado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAuxiliar.InitializeLayout
        With cboAuxiliar.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboAuxiliar.Width

            '.Columns(9).Hidden = True
        End With
    End Sub

    Private Sub btnBuscaUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaPer.Click
        Call ListadoClie()
    End Sub

    Public Sub ListadoClie()
    Dim testDialog As New FrmConsulta_Personas()
    testDialog.Cod_Cat = 4
    If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Me.lblPersonaId.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
      Me.LblPersona.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
    Else
      'TxtCodAsistente.Text = ""
    End If
    testDialog.Dispose()
  End Sub

  Private Sub btnClearUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUS.Click
    LblPersona.Text = "usuario"
    LblPersona.Tag = 0
    lblPersonaId.Text = 0
  End Sub

    Private Sub btnLista_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLista_Producto.Click
        Dim testDialog As New FrmConsulta_Productos

        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.lblProducto.Tag = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            Me.lblProducto.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
        Else
            lblProducto.Text = ""
            lblProducto.Tag = 0
        End If
        testDialog.Dispose()
    End Sub

  Private Sub cboAuxiliar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAuxiliar.ValueChanged
    If dgvListado.Selected.Rows.Count > 0 Then
      If IsDBNull(dgvListado.ActiveRow.Cells(0).Value) Then
        Exit Sub
      End If
      Select Case dgvListado.ActiveRow.Cells(0).Value
        Case 1
          If Not cboAuxiliar.Text = "" Then
            If cboAuxiliar.Value = 0 Then
              ChkAux2.Checked = True
              ChkAux2.Text = "Mostrar Costo"
              ChkAux2.Enabled = True
              cboAuxiliar1.Value = 1
            Else
              ChkAux2.Checked = False
              ChkAux2.Text = "..."
              ChkAux2.Enabled = False
            End If
          End If
        Case 3

          If cboAuxiliar.Value = 1 Or cboAuxiliar.Value = 2 Or cboAuxiliar.Value = 3 Then
            'CboFecha2.Enabled = False
            chkAux1.Text = ".csv"
            chkAux1.Enabled = True
          Else
            'CboFecha2.Enabled = True
            chkAux1.Text = "..."
            chkAux1.Enabled = False
          End If
      End Select

    End If

  End Sub

  Private Sub CboFamilia_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboFamilia.InitializeLayout
        'sc.abreviatura, sc.codigo_cat::integer, c.nombre 
        With CboFamilia.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = CboFamilia.Width
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            '.Columns(4).Hidden = True
        End With
    End Sub

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        Dim DtRes As New DataTable
        Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vDoc As Integer = 0, vPersona As Long = 0


        xCod_uni = Integer.Parse(GestionSeguridadManager.gUnidadId)

        If Not Trim(Me.cboAlmacenDE.Text) = "" Then
            xCod_Alm = CInt(cboAlmacenDE.Value)
        End If
        If Not cboDocumentoDE.Text = "" Then
            vDoc = cboDocumentoDE.Value
        End If
        If Not lblPersonaId.Text = "" Then
            vPersona = Long.Parse(lblPersonaId.Text)
        End If

        vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

        DtRes = Reportes_VariosManager.Listado_Documentos_Emitidos(xCod_uni, xCod_Alm, vDoc, vPersona, vDesde, vHasta, chkIM.Checked, chkConsig.Checked, chkVta.Checked, chkSM.Checked)

        e.Result = DtRes

    End Sub

    Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

        dgvDE.DataSource = CType(e.Result, DataTable)
        picAjaxBig.Visible = False
        gpCriterios.Enabled = True

        'dgvListado.Refresh()
        Me.lbl.Text = dgvListado.Rows.Count & " Registros"
    Call Totales_DE()
  End Sub

  Private Sub Totales_DE()
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vImporte As Single = 0
    Try
      DtTot = dgvDE.DataSource

      For Each Drs In DtTot.Rows
        vImporte = vImporte + Single.Parse(Drs("importe").ToString)
      Next Drs

      lblTotalDE.Text = vImporte
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Public Sub Actualizar()
        picAjaxBig.Visible = True
        gpCriterios.Enabled = False
        dgvDE.DataSource = Nothing

        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub

    Private Sub tsdActualizarMS_Click(sender As Object, e As EventArgs) Handles tsdActualizarMS.Click
        Call Actualizar()
    End Sub

    Private Sub cboDocumentoDE_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumentoDE.InitializeLayout
        With cboDocumentoDE.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDocumentoDE.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub chkxAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles chkxAlmacen.CheckedChanged
        If chkxAlmacen.Checked Then
            cboAlmacenDE.Text = ""
        End If
    End Sub

    Private Sub tsDSalir_Click(sender As Object, e As EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvDE, ugExcelExporter, "List_DE.xls")
  End Sub

    Private Sub tsExcel_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
        Call Exportar_Excel()
    End Sub

    Public Sub Listado_clientes()
        Dim testDialog As New FrmConsulta_Personas()
        'testDialog.Cod_Cat = 4
        TxtAnombreD.Text = ""
        lblPersonaId.Text = ""
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim objP As New persona
            lblPersonaId.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            TxtAnombreD.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)

        End If
        testDialog.Dispose()
    End Sub

    Private Sub btnBuscarPersona_Click(sender As Object, e As EventArgs) Handles btnBuscarPersona.Click
        Call Listado_clientes()
    End Sub

    Private Sub TxtAnombreD_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAnombreD.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtAnombreD.Text = "" Then
                Call Listado_clientes()
            End If
        Else
            TxtAnombreD.Text = ""
            lblPersonaId.Text = ""
        End If
    End Sub


    Private Sub chkAllAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllAlmacen.CheckedChanged
        If chkAllAlmacen.Checked Then
            cboAlmacen.Text = ""
        End If
    End Sub

    Private Sub chkAux1_CheckedChanged(sender As Object, e As EventArgs) Handles chkAux1.CheckedChanged
        If pRV = "RangoFecha" Then
            cboMes.Value = 0
            cboMes.Enabled = Not chkAux1.Checked
            cboAnio.Enabled = Not chkAux1.Checked
            CboFecha1.Enabled = chkAux1.Checked
            CboFecha2.Enabled = chkAux1.Checked

        End If
    End Sub
End Class