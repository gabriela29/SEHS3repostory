Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmArqueo_Fondo_Fijo
    Public ListadoDoc As DataTable, pCodigo_Per As Long

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

        End With
    End Sub

    Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
        If cboAlmacen.ActiveRow Is Nothing Then
            If Not cboAlmacen.Text = "" Then
                cboAlmacen.Focus()
            End If
        End If
    End Sub

    Public Sub Llenar_datos_Grid()

        Dim vDesde, vHasta As String, xCod_uni As Integer = 0
        Dim _codigoP As Long = 0
        ListadoDoc = New DataTable

        vDesde = ""
        vHasta = ""

        If Not Trim(cboAlmacen.Text) = "" Then
            xCod_uni = CInt(cboAlmacen.Value)
        End If

        vDesde = Year(Me.CboFecha1.Value) & "/" & Format(Month(Me.CboFecha1.Value), "00") & "/" & Format(Day(Me.CboFecha1.Value), "00")
        vHasta = Year(Me.CboFecha2.Value) & "/" & Format(Month(Me.CboFecha2.Value), "00") & "/" & Format(Day(Me.CboFecha2.Value), "00")


        ' create and bind sample DataSet
        ListadoDoc = arqueo_fondo_fManager.GetList_Fondo_Fijo(pCodigo_Per, xCod_uni, vDesde, vHasta)

        dgvListado.DataSource = ListadoDoc
        dgvListado.Refresh()
        Me.LblRegistros.Text = "Existen " & dgvListado.Rows.Count & " Registros Mostrados"

    End Sub

    Private Sub FrmArqueo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call llenar_combos()
        LblNombre.Text = GestionSeguridadManager.sNombeUS
        lblCodigo.Text = GestionSeguridadManager.idUsuario
        pCodigo_Per = GestionSeguridadManager.idUsuario
        Me.CboFecha1.Value = Now.Date
        Me.CboFecha2.Value = Now.Date
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Call Llenar_datos_Grid()
    End Sub

    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
        If cboAlmacen.Text = "" Then
            MsgBox("Debe Seleccionar una Unidad de Negocio", MsgBoxStyle.Exclamation, "AVISO")
            cboAlmacen.Focus()
            Exit Sub
        End If

        If Not IsNumeric(lblCodigo.Text) Or Me.LblNombre.Text.Trim = "" Then
            MsgBox("Debe Seleccionar un usuario", MsgBoxStyle.Exclamation, "AVISO")
            lblCodigo.Focus()
            Exit Sub
        End If

        Dim FrAko As New FrmArqueo_Fondo_FijoNM
        FrAko.LblUnidad.Text = cboAlmacen.Text
        FrAko.pCodigo_Uni = GestionSeguridadManager.gUnidadId
        FrAko.pCodigo_Alm = cboAlmacen.Value
        FrAko.lblUsuario.Text = LblNombre.Text
        FrAko.pUsuarioID = pCodigo_Per

        FrAko.ShowDialog()
        FrAko.Dispose()
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                If CBool(dgvListado.ActiveRow.Cells("cerrado").Value) = False Then
                    Call Eliminar_Arqueo(dgvListado.ActiveRow.Cells("codigo").Value)
                Else
                    If GestionSeguridadManager.sUsuario = "adminasea" Or GestionSeguridadManager.sUsuario = "admin" Then
                        If MsgBox("El Arqueo está cerrado está seguro de eliminarlo?", MsgBoxStyle.YesNo, "CONFIRME") = MsgBoxResult.Yes Then
                            Call Eliminar_Arqueo(dgvListado.ActiveRow.Cells("codigo").Value)
                            Call Llenar_datos_Grid()
                        End If
                    Else
                        MsgBox("No Puede se eliminado el Arqueo por estar Cerrado", MsgBoxStyle.Exclamation, "AVISO")
                    End If
                End If
            End If
        End If
    End Sub

    Private Function Eliminar_Arqueo(ByVal _Codigo As Long) As Boolean
        Eliminar_Arqueo = arqueo_fondo_fManager.Eliminar(_Codigo)
    End Function

    Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns("fecha").CellActivation = Activation.NoEdit
            .Columns("fecha").Width = 140
            .Columns("detalle").Width = 240
        End With
    End Sub

    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        Try
            If e.Row.Band.Index = 0 Then
                If e.Row.Cells("cerrado").Value = True Then
                    e.Row.Cells("fecha").Appearance.Image = Global.Phoenix.My.Resources.Resources.lock
                    'Else
                    '   e.Row.Cells("fecha").Appearance.Image = Global.Cliente.My.Resources.Resources.edit_add
                End If
            End If
        Finally

        End Try
    End Sub

    Private Sub tsDCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDCerrar.Click
        Dim Cambiar_Estado As Long
        Dim vCodigo As Long = 0
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                If CBool(dgvListado.ActiveRow.Cells("cerrado").Value) = False Then
                    If Not CSng(dgvListado.ActiveRow.Cells("diferencia").Value) = 0 Then
                        MsgBox("Para poder ser cerrado debe estar en Diferecia cero(o)", MsgBoxStyle.Exclamation, "AVISO")
                    Else
                        If MsgBox("Está a Punto Cerrar el Arqueo, una vez hecho esto no podrá hacer más cambios para este día. " & Chr(13) & "¿Desea Seguir ?", MsgBoxStyle.YesNo, "CONFIRME") = MsgBoxResult.Yes Then
                            vCodigo = dgvListado.ActiveRow.Cells(0).Value
                            Cambiar_Estado = arqueo_fondo_fManager.Cambiar_Estado(vCodigo, True)
                            Call Llenar_datos_Grid()
                        End If
                    End If
                Else
                    MsgBox("El arqueo está cerrado", MsgBoxStyle.Exclamation, "AVISO")
                End If
            End If
        End If


    End Sub

    Private Sub tsDReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim vCodigo As Long = 0, vCodigo_Uni As Integer = 0
        Dim vDet As String
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                vCodigo = dgvListado.ActiveRow.Cells(0).Value
                vDet = dgvListado.ActiveRow.Cells("detalle").Value
                If Not Trim(cboAlmacen.Text) = "" Then
                    vCodigo_Uni = cboAlmacen.Value
                End If
                Call RptArqueo_FF(vCodigo, vCodigo_Uni, vDet)
            Else
                MsgBox("Debe Seleccionar un Registro", MsgBoxStyle.Exclamation, "D'Soft")
            End If
        End If
    End Sub

    Private Sub RptArqueo_FF(ByVal vCodigo As Long, ByVal vCodigo_Uni As Integer, ByVal vDet As String)


        Dim DtAk As New DataTable

        Try
            If Trim(vCodigo) > 0 Then
                DtAk = arqueo_fondo_fManager.GetRpt(vCodigo)
                If DtAk.Rows.Count > 0 Then
                    Dim frm As New FrmVisorCaja
                    frm.RptArqueo_FF(DtAk, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "ARQUEO FONDO FIJO", vDet)
                    Call LibreriasFormularios.Ver_Form(frm, "Reporte A.F.F.")
                Else
                    MsgBox("No hay Registros que Mostrar", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
                End If
            Else
                MsgBox("Debe Seleccionar un Arqueo", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
                Exit Sub
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

End Class