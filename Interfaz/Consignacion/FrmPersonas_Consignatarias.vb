Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports System.IO

Public Class FrmPersonas_Consignatarias
    Public _codigo As Long
    Public ListadoDoc As DataTable

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

            st = permisos_moduloManager.Leer_Almacenes_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modColportaje, vCodigo_Unidad)

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

    Private Sub cboUnidad_Negocio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.Validated
        'If Not bwAlmacen.IsBusy Then
        '    cboAlmacen.Text = [String].Empty
        '    picAjax.Visible = True
        '    bwAlmacen.RunWorkerAsync()
        'End If
    End Sub

    Private Sub cboUnidad_Negocio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.ValueChanged
        cboAlmacen.DataSource = Nothing
        gpCriterios.Enabled = True
        dgvResumen.DataSource = Nothing

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
            End If
        End If
    End Sub


    Private Sub FrmPersonas_Consignatarias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()

        Call Totales_Cero()
    End Sub

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        Dim DtRes As New DataTable
        Dim xCod_uni, xCod_Alm As Integer ', vHasta As String

        If Not Trim(cboUnidad_Negocio.Text) = "" Then
            xCod_uni = CInt(cboUnidad_Negocio.Value)
        End If
        If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
        End If

        'vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

        DtRes = Control_AsistenteManager.Leer_Asistentes(xCod_uni, xCod_Alm, 0)
        e.Result = DtRes

    End Sub

    Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

        dgvResumen.DataSource = CType(e.Result, DataTable)
        Call CalcularTotales_Res(CType(e.Result, DataTable))
        picAjaxRes.Visible = False
        gpCriterios.Enabled = True
        'gpBotones.Enabled = True
        'dgvListado.Refresh()
        Me.lblRegistros_Res.Text = dgvResumen.Rows.Count & " Registros"

    End Sub

    Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
        Dim DtTot As New DataTable
        Dim Drs As DataRow
        Dim vDeudaVenc, vDeudaMora, vDeudaSM, vTotal As Single
        Dim vCod_a As Long = 0
        vDeudaVenc = 0
        vDeudaMora = 0
        vDeudaSM = 0
        CalcularTotales_Res = False

        Try
            DtTot = DtTotales 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

            For Each Drs In DtTot.Rows

                'Select Case Trim(Drs("tipo").ToString)
                '    Case "M"
                '        vDeudaMora = CSng(Drs("monto").ToString)
                '    Case "V"
                '        vDeudaVenc = CSng(Drs("monto").ToString)
                '    Case "T"
                '        vDeudaSM = CSng(Drs("monto").ToString)

                'End Select
                vTotal = vTotal + CSng(Drs("importe").ToString)
                'vTotal = CSng(vDeudaSM + vDeudaMora)

            Next Drs
            'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
            'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
            'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
            Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
            CalcularTotales_Res = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Totales_Cero()

        Me.LblDeudaTotal.Text = "0.00"
    End Sub

    Private Sub dgvResumen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvResumen.InitializeLayout
        With dgvResumen.DisplayLayout.Bands(0)
            .Columns(0).Header.Caption = "ID"
            .Columns(0).Width = 20
            .Columns(1).Header.Caption = "Documento"
            .Columns(1).Width = 80
            .Columns(2).Header.Caption = "Asistente"
            .Columns(2).Width = 220
            .Columns(3).Hidden = True
            .Columns(4).Header.Caption = "N° Cuenta"
            .Columns(4).Width = 120

            .Columns(5).Width = 80
            .Columns(5).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(5).CellAppearance.TextHAlign = HAlign.Right

            .Columns(9).Width = 150
            .Columns(10).Hidden = True
        End With
    End Sub

    Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        picAjaxRes.Visible = True
        gpCriterios.Enabled = False
        'gpBotones.Enabled = False

        dgvResumen.DataSource = Nothing
        LblDeudaTotal.Text = "0.00"
        Call Totales_Cero()
        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboAlmacen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.ValueChanged
        dgvResumen.DataSource = Nothing

        Call Totales_Cero()
    End Sub


    Private Sub tsdAddAsistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdAddAsistente.Click
        FrmActualizar_Asistente.pCodigo_Alm = cboAlmacen.Value
        FrmActualizar_Asistente.pTipo = "P:C:"
        FrmActualizar_Asistente.ShowDialog()
    End Sub

    Private Sub tsQuitarAsistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsQuitarAsistente.Click

        If Not dgvResumen.DataSource Is Nothing Then
            If dgvResumen.Selected.Rows.Count > 0 Then
                If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
                    If Control_AsistenteManager.Eliminar(0, cboAlmacen.Value, (dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value), 0) Then
                        If Not bwLlenar_Res.IsBusy Then
                            bwLlenar_Res.RunWorkerAsync()
                        End If
                    End If
                End If
            End If
        End If

    End Sub


End Class