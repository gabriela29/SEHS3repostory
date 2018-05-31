Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class FrmInfoSEHS
    Public pCodigo_Per As Long = 0, dtListado As DataTable

    Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
        Dim DtTot As New DataTable
        Dim Drs As DataRow
        Dim vTotal As Single

        Try
            DtTot = DtTotales

            For Each Drs In DtTot.Rows

                vTotal = vTotal + CSng(Drs("saldo").ToString)

            Next Drs

            Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
            CalcularTotales_Res = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        dtListado = New DataTable

        If Not IsNumeric(pCodigo_Per) Then
            Exit Sub
        End If
        If Not pCodigo_Per > 0 Then
            Exit Sub
        End If

        dtListado = por_cobrarManager.Info_Sehs(pCodigo_Per, "")

    End Sub

    Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

        dgvResumen.DataSource = dtListado
        Call CalcularTotales_Res(dtListado)
        picAjaxRes.Visible = False
        gpCriterios.Enabled = True
        'dgvListado.Refresh()
        Me.lblRegistros_Res.Text = dgvResumen.Rows.Count & " Registros"

    End Sub

    Private Sub Actualizar()
        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub

    Public Sub Listado_clientes()
        Dim testDialog As New FrmConsulta_Personas()

        pCodigo_Per = -1
        LblNombre.Text = ""
        lblDNIRUC.Text = ""
        dgvResumen.DataSource = Nothing
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            pCodigo_Per = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            LblNombre.Text = testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value
            lblDNIRUC.Text = testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(2).Value & " " & testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(3).Value
            Call Actualizar()

        End If
        testDialog.Dispose()
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles BtnSeleccionar.Click
        Call Listado_clientes()
    End Sub

    Private Sub tsDSalir_Click(sender As Object, e As EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub tsdActualizar_Click(sender As Object, e As EventArgs) Handles tsdActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub dgvResumen_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvResumen.InitializeLayout
        With dgvResumen.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns("almacen").Width = 150
            .Columns("rucdni").Width = 100
            .Columns("nombre").Width = 350
            .Columns("saldo").Width = 80
            .Columns("saldo").CellAppearance.BackColor = Color.LemonChiffon
            .Columns("saldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With
    End Sub

  Private Sub Exportar_Excel()
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvResumen, ugExcelExporter, "infosehs.xls")
  End Sub

  Private Sub tsActivarCuenta_Click(sender As Object, e As EventArgs)

  End Sub

  Private Sub tsExcelRes_Click(sender As Object, e As EventArgs) Handles tsExcelRes.Click
    Call Exportar_Excel()
  End Sub
End Class