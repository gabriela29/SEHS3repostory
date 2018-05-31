
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Infragistics.Excel

Public Class FrmStocConsolidado

    Private Sub Llenar_Combos()
        With Me.cboUnidad
            '.DataBind()
            .ValueMember = "unidadnegocioid"
            .DisplayMember = "unidad"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If

        End With
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

    End Sub

    Private Sub FrmStocConsolidado_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Llenar_Combos()

    End Sub

    Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
        CheckForIllegalCrossThreadCalls = False

        Try
            Dim dtStock As New DataTable
            Dim vUnidad As Integer = 0, xok As Boolean

            If cboUnidad.Text = "" Then
                vUnidad = cboUnidad.Value
            End If

            xok = False 'reportes_gerencialesManager.Stock_valorado(vUnidad, cboMes.Value, cboUnidad.Value, 0, 0, 0, dtStock, "ALMACEN")

            e.Result = dtStock

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwListado_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwListado.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        If dgvListado.Rows.Count() > 0 Then
            dgvListado.Rows(0).Selected = True
            dgvListado.Focus()
        End If
        'Call LlenarRsKardexPROMEDIO(CType(e.Result, DataTable))
        'Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjaxBig.Visible = False
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        If Not bwListado.IsBusy Then
            picAjaxBig.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub


End Class