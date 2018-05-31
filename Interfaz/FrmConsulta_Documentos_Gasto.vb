Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConsulta_Documentos_Gasto
    Public _vIDProv As Long, _vRuc As String, _xTipo_DOc As String, _vNombre_Prov As String

    Private Sub FrmConsulta_Documentos_Gasto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub bwDocs_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDocs.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Unidad As Integer
        Dim vCodigo_Prov As Long = 0, vRuc As String = "", vCodigo_Doc As Integer = 0
        Dim st As New DataTable

        Try
            vCodigo_Unidad = 0
            If Not Trim(cboAlmacen.Text) = "" Then
                vCodigo_Unidad = CInt(cboAlmacen.Value)
            End If
            If Not Trim(cboDocumento.Text) = "" Then
                vCodigo_Doc = CInt(cboDocumento.Value)
            End If
            If Not TxtRuc.Text.Trim = "" Then
                vRuc = TxtRuc.Text.Trim
            End If

            st = detalle_lote_gastosManager.Consulta_Documentos_Referencia(vCodigo_Unidad, _vIDProv, vRuc, vCodigo_Doc, "", "")

            e.Result = st

        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwPlan_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDocs.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        If dgvListado.Rows.Count() > 0 Then
            'dgvListado.ActiveCell = dgvListado.Rows(0).Cells(2)
            dgvListado.Rows(0).Selected = True
            dgvListado.Focus()
        End If
        'Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjax.Visible = False
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With e.Layout.Bands(0)
            .Columns(0).Hidden = True
            '.Columns("Cuenta").Width = 900
            '.Columns("CtaCte").Width = 700
            '.Columns("sct").Width = 400
            '.Columns("NombreCta").Width = 280
            '.Columns("CtaMaestra").Width = 1300
            '.Columns("Nivel").Hidden = True

        End With

    End Sub

    Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Llenar_Combos()
        CheckForIllegalCrossThreadCalls = False

        With cboAlmacen
            .DataSource = Nothing
            .DataSource = permisos_moduloManager.Leer_Almacenes(GestionSeguridadManager.idUsuario, GestionModulos.modVentas)
            .DataBind()
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If

        End With

        With cboDocumento
            .DataSource = Nothing
            .DataSource = documentoManager.GetList_Tipo(_xTipo_DOc)
            .Refresh()
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            If .Rows.Count > 0 Then
                '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With
    End Sub

    Private Sub FrmConsulta_Documentos_Gasto_Gasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Llenar_Combos()
        TxtRuc.Text = _vRuc
        TxtProveedor.Text = _vNombre_Prov
        'If Not bwDocs.IsBusy Then
        '    picAjax.Visible = True
        '    bwDocs.RunWorkerAsync()
        'End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not bwDocs.IsBusy Then
            picAjax.Visible = True
            bwDocs.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout

        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDocumento.Width
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
            .Columns(5).Hidden = True
            .Columns(6).Hidden = True
        End With

    End Sub


    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout

        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True
        End With

    End Sub
End Class