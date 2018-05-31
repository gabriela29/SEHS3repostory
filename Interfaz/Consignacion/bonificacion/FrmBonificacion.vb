Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class FrmBonificacion


    Private Sub llenar_combos()
        Try
            With cboUnidad_Negocio
                .DataSource = Nothing
                .DataSource = permisos_moduloManager.Leer_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modVentas)
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

            'Dim dtL As DataTable
            'Dim x As Integer = 6
            'Dim opcionesv(x), opciones(x) As String
            'opcionesv(0) = 0
            'opcionesv(1) = 1
            'opcionesv(2) = 2
            'opcionesv(3) = 3
            'opcionesv(4) = 4
            'opcionesv(5) = 5
            'opcionesv(6) = 6

            'opciones(0) = "Todos"
            'opciones(1) = "Permanentes"
            'opciones(2) = "Estudiantes"
            'opciones(3) = "Nacionales"
            'opciones(4) = "Asistente"
            'opciones(5) = "Individual"
            'opciones(6) = "Iglesia"

            'dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

            'With cboTipo
            '    .DataSource = Nothing
            '    .DataSource = dtL
            '    .Refresh()
            '    .ValueMember = "opcionesv"
            '    .DisplayMember = "opciones"
            '    If .Rows.Count > 0 Then
            '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            '    End If
            'End With


            'Dim lMeses As New ClsCrearMeses

            'With cboMes
            '    .DataSource = Nothing
            '    .DataSource = lMeses.GetList(False, False)
            '    .Refresh()
            '    .ValueMember = "codigo"
            '    .DisplayMember = "nombre"
            '    If .Rows.Count > 0 Then
            '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            '    End If

            'End With

            'With cboAnio
            '    .DataSource = Nothing
            '    .DataSource = lMeses.GetList_anios()
            '    .Refresh()
            '    .ValueMember = "nombre"
            '    .DisplayMember = "nombre"
            '    If .Rows.Count > 0 Then
            '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            '    End If

            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwAlmacen_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAlmacen.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Unidad As Integer
        Dim st As New DataTable

        Try
            vCodigo_Unidad = 0
            If Not Trim(cboUnidad_Negocio.Text) = "" Then
                vCodigo_Unidad = CInt(cboUnidad_Negocio.Value)
            End If

            st = permisos_moduloManager.Leer_Almacenes_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modVentas, vCodigo_Unidad)

            e.Result = st

        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwAlmacen_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAlmacen.RunWorkerCompleted
        'If sender = bwPrecarga Then
        If e.Result Is Nothing Then
            cboAlmacen.DataSource = Nothing
        Else
            With Me.cboAlmacen
                .DataSource = CType(e.Result, DataTable)
                '.DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    Call LLenar_Tipo()
                End If

            End With
        End If

        picAjax.Visible = False

    End Sub

    Private Sub cboUnidad_Negocio_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnidad_Negocio.InitializeLayout
        With cboUnidad_Negocio.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboUnidad_Negocio.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboUnidad_Negocio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.ValueChanged
        cboAlmacen.DataSource = Nothing
        gpCriterios.Enabled = True

        dgvListado.DataSource = Nothing

        Call Totales_Cero()
        If Not bwAlmacen.IsBusy Then
            cboAlmacen.Text = [String].Empty
            picAjax.Visible = True
            bwAlmacen.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
        If cboAlmacen.ActiveRow Is Nothing Then
            If Not cboAlmacen.Text = "" Then
                cboAlmacen.Focus()
            Else
                Call LLenar_Tipo()
            End If
        End If

    End Sub

    Private Sub LLenar_Tipo()

        If Not cboAlmacen.Text = "" Then
            With cboCondicion
                .DataSource = Nothing
                .DataSource = bonificacion_tipoManager.GetList(cboAlmacen.Value, "")
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With
        End If

    End Sub

    Private Sub Totales_Cero()

        'Me.lblTotalDeuda.Text = "0.00"
        'Me.lblTotalPagos.Text = "0.00"
        'Me.lblTotalSaldo.Text = "0.00"
    End Sub

    Private Sub FrmBonificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()

        Call LibreriasFormularios.formatear_grid(dgvListado)
        Call Totales_Cero()
    End Sub

    Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub bwLlenar_Detalle_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Detalle.DoWork
        Dim DtColp As New DataTable
        Dim xTipo, xCod_Alm As Integer, vHasta As String

        If Not Trim(cboCondicion.Text) = "" Then
            xTipo = CInt(cboCondicion.Value)
        End If
        If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

        ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
        ' create and bind sample DataSet
        DtColp = bonificacionManager.GetList(xCod_Alm, xTipo, 0, "")

        e.Result = DtColp
        'Ctas = 0
    End Sub

    Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted

        dgvListado.DataSource = CType(e.Result, DataTable)
        ' Call CalcularTotales_Det(CType(e.Result, DataTable))

        picAjaxBig.Visible = False
        gpCriterios.Enabled = True
        'gpBotones.Enabled = True
        dgvListado.Enabled = True

        'Me.LblRegistros.Text = dgvListado.Rows.Count & " Registros"

    End Sub

    Public Sub Actualizar()
        picAjaxBig.Visible = True
        gpCriterios.Enabled = False

        dgvListado.DataSource = Nothing

        If Not bwLlenar_Detalle.IsBusy Then
            bwLlenar_Detalle.RunWorkerAsync()
        End If
    End Sub

    Private Sub tsActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub cboCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCondicion.InitializeLayout
        With cboCondicion.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns("nombre").Width = cboCondicion.Width
            .Columns("desde").Hidden = True
            .Columns("hasta").Hidden = True
            .Columns("estado").Hidden = True
        End With
    End Sub

    Private Sub cboCondicion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCondicion.ValueChanged
        dgvListado.DataSource = Nothing
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
        FrmBonificacionEdit.vAlmacenId = cboAlmacen.Value
        FrmBonificacionEdit.vAlmacen = cboAlmacen.Text
        FrmBonificacionEdit.dtTipo = cboCondicion.DataSource
        FrmBonificacionEdit.ShowDialog()
    End Sub

    Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "boni_tmp.xls")
  End Sub

    Private Sub tsReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReporte.Click
        Call Exportar_Excel()
    End Sub
End Class