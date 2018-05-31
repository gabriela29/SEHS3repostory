
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid.ExcelExport
'Imports Infragistics.Excel

Public Class FrmProductos_Campania
    Private Sub llenar_combos()
    Try

      With cboCampania
        .DataSource = Nothing
        .DataSource = campaniaManager.Campania_leer("")
        .Refresh()
        .ValueMember = "campaniaid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "pcamp.xls")

  End Sub

  Private Sub FrmProductos_Campania_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    'Call formatear_grid()
    Call llenar_combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

  Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
    CheckForIllegalCrossThreadCalls = False

    Try
      Dim dtKardex As New DataTable

      dtKardex = productos_campaniaManager.Producto_Campania_leer(cboCampania.Value, 0, 0)

      e.Result = dtKardex

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

        Me.lbl.Text = dgvListado.Rows.Count & " Registros"
        picAjaxBig.Visible = False
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Actualizar()
    End Sub

    Private Sub tsExcel_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
        Call Exportar_Excel()
    End Sub

    Private Sub tsDSalir_Click(sender As Object, e As EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub tsdActualizar_Click(sender As Object, e As EventArgs) Handles tsdActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                If MessageBox.Show("¿Está seguro de eliminar este Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If productos_campaniaManager.Eliminar(Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))) Then
                        Call Actualizar()
                    End If
                End If

            End If
        End If
    End Sub

    Public Sub Actualizar()
        If Not bwListado.IsBusy Then
            picAjaxBig.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub tsAgregar_Click(sender As Object, e As EventArgs) Handles tsAgregar.Click

        Dim xFr As New FrmProductos_CampaniaNM
        With xFr
            xFr.pCodigo = 0
            xFr.ShowDialog()
        End With

    End Sub

    Private Sub Editar()
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Dim _codigo As Long, xFr As New FrmProductos_CampaniaNM
                _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                With xFr
                    xFr.pCodigo = _codigo
                    xFr.ShowDialog()
                End With

            End If
        End If
    End Sub
    Private Sub tsEditar_Click(sender As Object, e As EventArgs) Handles tsEditar.Click
        Call Editar()
    End Sub

    Private Sub dgvListado_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles dgvListado.DoubleClickRow
        Call Editar()
    End Sub

    Private Sub dgvListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Width = 30
            .Columns(1).Header.Caption = "ID_PRO"
            .Columns(2).Width = 350
            .Columns(2).Header.Caption = "PRODUCTO"
            .Columns(3).Width = 100
            .Columns(3).Header.Caption = "ABREVIATURA"
            .Columns(4).Width = 80
            .Columns(4).Header.Caption = "PRECIO"
            .Columns(4).CellAppearance.TextHAlign = HAlign.Right
            .Columns(4).CellAppearance.BackColor = Color.LemonChiffon
            .Columns("afecto_igv").Width = 60
            .Columns("afecto_igv").Header.Caption = "IGV"
            .Columns("afecto_dzmo").Width = 70
            .Columns("afecto_dzmo").Header.Caption = "DZMO"
            .Columns("afecto_plus_esc").Hidden = True
            .Columns("stock").Hidden = True
        End With
    End Sub

    Private Sub dgvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Editar()
        End If
    End Sub
End Class