
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmPermisos_Impresion
    Public _codigo As Integer
    Public ListadoRegistros As DataTable

    'Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub llenar_Combos()
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
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
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
        _codigo = 0
    End Sub

    Public Function ListarCondicion() As Boolean
        Dim objetos As New DataTable
        Dim cod_alm As Integer = 0
        If Not cboAlmacen.Text.Trim = "" Then
            cod_alm = cboAlmacen.Value
        End If

        Try
            ListadoRegistros = permisos_impresionManager.GetList(cod_alm, 0, 0)
            dgvListado.DataSource = ListadoRegistros
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub FrmPermisos_Impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call llenar_Combos()
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 200
        End With

    End Sub

    Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
        If Not cboAlmacen.Text.Trim = "" Then
            Call FrmPermisos_ImpresionNM.LimpiarControles()
            FrmPermisos_ImpresionNM.pAlmacenId = cboAlmacen.Value
            FrmPermisos_ImpresionNM.pAlmacen = cboAlmacen.Text
            FrmPermisos_ImpresionNM.ShowDialog()
            Call ListarCondicion()
        End If

    End Sub


    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If dgvListado.Selected.Rows.Count > 0 Then
            If MsgBox("¿Está seguro de Eliminar este Registro?", MsgBoxStyle.YesNo, "D'SIAM") = MsgBoxResult.Yes Then
                Call Eliminar(CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondicion()
            End If
        End If
    End Sub

    Public Function Eliminar(ByVal _id As Integer) As Boolean
        Dim Objeto As New permisos_impresion
        Try
            Objeto.codigo = _id
            permisos_impresionManager.Eliminar(Objeto)
            Objeto = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpModificar.Click
        If dgvListado.Selected.Rows.Count > 0 Then
            Dim vCodigo As Long = 0

            vCodigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

            If vCodigo > 0 Then
                FrmPermisos_ImpresionNM.vcodigo = vCodigo
                FrmPermisos_ImpresionNM.LblCodigo.Text = vCodigo
                FrmPermisos_ImpresionNM.pUsuario = dgvListado.DisplayLayout.ActiveRow.Cells(1).Value
                FrmPermisos_ImpresionNM.pAlmacen = cboAlmacen.Text
                FrmPermisos_ImpresionNM.ShowDialog()

            End If

        End If
    End Sub

    Private Sub tsActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar.Click
        Call ListarCondicion()
    End Sub
End Class