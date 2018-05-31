
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Public Class FrmCierre_Mes
    Private Sub llenar_combos()
        Try

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

    Private Sub Obtener_Mes()
        Dim ObCM As New control_mes
        ObCM = control_mesManager.GetItem(cboAlmacen.Value, 0, 0)
        If Not ObCM Is Nothing Then
            With ObCM
                cboMes.Value = .mes
                cboAnio.Text = .anio
                LblCerrado.Visible = .cerrado
            End With
        End If
        ObCM = Nothing
        If LblCerrado.Visible Then
            tsAperturar.Visible = True
            tsCerrar.Visible = False
        Else
            tsAperturar.Visible = False
            tsCerrar.Visible = True
        End If
    End Sub


    Private Sub FrmCierre_Mes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call llenar_combos()
        Call Obtener_Mes()

        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged

        dgvListado.DataSource = Nothing
        tsAperturar.Visible = False
        tsCerrar.Visible = False
        LblCerrado.Visible = False

        Call Obtener_Mes()
    End Sub

    Private Sub dgvListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 40
            .Columns(1).Width = 250
            .Columns(2).Width = 150
            '.Columns(3).Hidden = True
        End With
    End Sub

    Private Sub tsCerrar_Click(sender As Object, e As EventArgs) Handles tsCerrar.Click
        tsAperturar.Visible = False
        Dim xDt As New DataTable, xMes As Integer = 0, xAnio As String = ""
        If MessageBox.Show("¿Estas seguro de cerrar el mes?", "REPONDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            xDt = control_mesManager.Cierre_Mes(cboAlmacen.Value, cboMes.Value, cboAnio.Text)
            If Not xDt Is Nothing Then
                If xDt.DataSet.Tables(0).Rows.Count >= 1 Then
                    If xDt.DataSet.Tables(0).Rows(0).Item("frm") = "CONTROL_MES" And xDt.DataSet.Tables(0).Rows(0).Item("codigo") > 0 Then
                        xMes = xDt.DataSet.Tables(0).Rows(0).Item("codigo")
                        xAnio = xDt.DataSet.Tables(0).Rows(0).Item("detalle")
                        dgvListado.Visible = False
                        cboMes.Value = xMes
                        cboAnio.Text = xAnio
                        LblCerrado.Visible = True
                        tsAperturar.Visible = True
                        tsCerrar.Visible = False
                    Else
                        dgvListado.DataSource = xDt
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsAperturar_Click(sender As Object, e As EventArgs) Handles tsAperturar.Click
        tsCerrar.Visible = False
        Dim xDt As New DataTable, xMes As Integer = 0, xAnio As String = ""
        If MessageBox.Show("Antes de cerrar el mes debe verificar: " & Chr(13) & _
                           "1.- Registro de Venta" & Chr(13) & _
                           "2.- Registro de Compra" & Chr(13) & _
                           "3.- Registro Honorarios" & Chr(13) & _
                           "4.- Costo de Venta" & Chr(13) & _
                           "Los cuales seran registrados para el consolidado", _
                           "REPONDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            xDt = control_mesManager.Aperturar_Mes(cboAlmacen.Value, cboMes.Value, cboAnio.Text)
            If Not xDt Is Nothing Then
                If xDt.DataSet.Tables(0).Rows.Count >= 1 Then
                    If xDt.DataSet.Tables(0).Rows(0).Item("tipo") = "MES" And xDt.DataSet.Tables(0).Rows(0).Item("codigo") > 0 Then
                        xMes = xDt.DataSet.Tables(0).Rows(0).Item("codigo")
                        xAnio = xDt.DataSet.Tables(0).Rows(0).Item("descripcion")
                        dgvListado.DataSource = xDt
                        dgvListado.Visible = True
                        cboMes.Value = xMes
                        cboAnio.Text = xAnio
                        LblCerrado.Visible = False
                        tsAperturar.Visible = False
                        tsCerrar.Visible = True
                    Else
                        dgvListado.DataSource = xDt
                    End If
                End If
            End If
        End If
    End Sub
End Class