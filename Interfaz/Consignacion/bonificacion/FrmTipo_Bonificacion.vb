
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmTipo_Bonificacion
    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

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

    Private Sub cboUnidad_Negocio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.ValueChanged
        cboAlmacen.DataSource = Nothing
        gpCriterios.Enabled = True

        dgvListado.DataSource = Nothing

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

    Private Sub FrmTipo_Bonificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub FrmTipo_Bonificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        'Call ListarCondicion("")
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Public Function ListarCondicion(ByVal Descripcion As String) As Boolean
        Dim dtDB As New DataTable
        Try
            dtDB = bonificacion_tipoManager.GetList(cboAlmacen.Value, Descripcion)
            dgvListado.DataSource = dtDB
            'dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
                'dgvListado.Focus()
                'Call Listado_Subgrupo()
            End If
            lbl.Text = dgvListado.Rows.Count & " Registros Mostrados"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
        FrmTipo_BonificionEdit.pCodigo = 0
        FrmTipo_BonificionEdit.pAlmacen = cboAlmacen.Text
        FrmTipo_BonificionEdit.pAlmacenid = cboAlmacen.Value
        FrmTipo_BonificionEdit.ShowDialog()

    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDEditar.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                FrmTipo_BonificionEdit.pAlmacen = cboAlmacen.Text
                FrmTipo_BonificionEdit.pAlmacenid = cboAlmacen.Value
                FrmTipo_BonificionEdit.pCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                FrmTipo_BonificionEdit.ShowDialog()
                Call ListarCondicion("")
            End If

        End If
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                If MessageBox.Show("Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim vCodigo As Integer
                    vCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                    If bonificacion_tipoManager.Eliminar(vCodigo) Then
                        Call ListarCondicion("")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsDActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDActualizar.Click
        Call ListarCondicion("")
    End Sub
End Class