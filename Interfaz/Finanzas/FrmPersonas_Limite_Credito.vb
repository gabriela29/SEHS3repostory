
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmPersonas_Limite_Credito
    Public pTipo As String = ""
    Public ListadoRegistros As DataTable
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

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

    Private Sub FrmPersonas_Limite_Credito_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call llenar_combos()
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Public Function ListarCondicion() As Boolean
        Dim xLimit As Integer = 10, vUnidadId As Integer = GestionSeguridadManager.gUnidadId
        Dim vAlmacenid As Integer = 0

        If IsNumeric(txtLimite.Text) Then
            xLimit = txtLimite.Text
        End If
        If Not cboAlmacen.Text = "" Then
            vAlmacenid = cboAlmacen.Value
        End If
        Try
            ListadoRegistros = persona_limite_creditoManager.GetList(vUnidadId, vAlmacenid, "", Trim(Me.txtBuscar.Text), txtApe_Mat.Text, txtNombre.Text, pTipo, xLimit)
            dgvListado.DataSource = ListadoRegistros
            'dgvListado.DataBind()
            lbl.Text = dgvListado.Rows.Count & " Registros"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub tsBtnAsistente_Click(sender As Object, e As EventArgs) Handles tsBtnAsistente.Click
        pTipo = "ASISTENTE"
        If ListarCondicion() Then

        End If
    End Sub

    Private Sub tsBtnColportor_Click(sender As Object, e As EventArgs) Handles tsBtnColportor.Click
        pTipo = "COLPORTOR"
        If ListarCondicion() Then

        End If
    End Sub

    Private Sub tsBtnAsignados_Click(sender As Object, e As EventArgs) Handles tsBtnAsignados.Click
        pTipo = "ALLLINEACREDITO"
        If ListarCondicion() Then

        End If
    End Sub

    Private Sub tsBtnAll_Click(sender As Object, e As EventArgs) Handles tsBtnAll.Click
        pTipo = "ALLPERSONA"
        If ListarCondicion() Then

        End If
    End Sub

    Private Sub tpCerrar_Click(sender As Object, e As EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Dim vPersona As String = "", vPersonaId As Long
                vPersonaId = dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value
                vPersona = dgvListado.DisplayLayout.ActiveRow.Cells("persona").Value
                Call Actualizar(vPersona, vPersonaId)
            End If
        End If
    End Sub

    Private Sub Actualizar(ByVal vPersona As String, ByVal vPersonaId As Long)
        'FrmLote_GastosNM.ShowDialog()
        popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmPersona_Limite_Credito = New FrmPersona_Limite_Credito


        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = True
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
            frm.pAlmacenId = cboAlmacen.Value
            frm.vAlmacen = cboAlmacen.Text
            frm.pPersona = vPersona
            frm.pPersonaId = vPersonaId

        End With
        Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

        popupHelper.ShowPopup(Me, frm, location)
    End Sub

    Private Sub dgvListado_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles dgvListado.DoubleClickRow
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Dim vPersona As String = "", vPersonaId As Long
                vPersonaId = dgvListado.DisplayLayout.ActiveRow.Cells("codigo").Value
                vPersona = dgvListado.DisplayLayout.ActiveRow.Cells("persona").Value
                Call Actualizar(vPersona, vPersonaId)
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(0).Header.Caption = "ID"
            .Columns(2).Width = 280
            .Columns(3).Width = 80
            .Columns(3).CellAppearance.TextHAlign = HAlign.Right


        End With
    End Sub
End Class