
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmPersonaLis
    Public _codigo As Integer
    Public ListadoRegistros As DataTable

    Private Sub FrmPersona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Public Function ListarCondicion() As Boolean
        Dim xLimit As Integer
        Dim vArray As String = "", vTiene As Boolean = False
        Dim dgvRw As UltraGridRow
        xLimit = Integer.Parse(txtLimite.Text)
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvCondicion.Selected.Rows
            If dgvRw.Band.Index = 0 Then
                vTiene = True
                vArray = vArray & Trim(Str(dgvRw.Cells("rolid").Value)) & ","
            End If
        Next


        If vTiene Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If

        Try
            ListadoRegistros = personaManager.GetList(Trim(Me.txtBuscar.Text), txtApe_Mat.Text, txtNombre.Text, "", vArray, xLimit, 0)
            dgvListado.DataSource = ListadoRegistros
            'dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub dgvListado_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListado.AfterRowsDeleted
        Call Eliminar(CInt(_codigo))
        Call ListarCondicion()
    End Sub

    Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
        Call ListarCondicion()
    End Sub

    Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
        _codigo = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
    End Sub

    Public Function Eliminar(ByVal _id As Integer) As Boolean
        'Eliminar = personaManager.Eliminar(_id, GestionSeguridadManager.idUsuario, GestionSeguridadManager.miIP)
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
            Else
                _codigo = 0
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Header.Caption = "ID"
            .Columns(0).Width = 20
            .Columns(1).Hidden = True
            .Columns(2).Header.Caption = "DNI"
            .Columns(2).Width = 80
            .Columns(3).Header.Caption = "RUC"
            .Columns(3).Width = 80

            .Columns(4).Header.Caption = "NOMBRE"
            .Columns(4).Width = 350
            .Columns("email").Width = 200
            .Columns("email").Header.Caption = "E-Mail"
            .Columns("telefono").Width = 180
            .Columns("telefono").Header.Caption = "Teléfono"
            .Columns("rol").Width = 180
            .Columns("rol").Header.Caption = "Rol"
            .Columns("foto").Hidden = True
            .Columns("sexo").Hidden = True
            .Columns("usuario").Hidden = True
        End With

        'Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If dgvListado.Selected.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar esta persona?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call Eliminar(CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondicion()
            End If
        End If
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
        'Call FrmPersonaNM.LimpiarControles()
        'FrmPersonaEdit.pCodigo = 0
        Dim xFrmPer As New FrmPersonaEdit
        xFrmPer.vPersonaId = 0
        xFrmPer.ShowDialog()
        'Call ListarCondicion()
    End Sub

    Private Sub FrmPersona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Private Sub llenar_combos()
        Try
            With dgvCondicion
                .DataSource = Nothing
                .DataSource = rolManager.GetList()
                .DataBind()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "E-MANAGER")
        End Try

    End Sub

    Private Sub Reporte()

        Dim DtpLt As New DataTable

        Try
            'If Not Trim(Me.cboCod_Cat.Text) = "" Then
            '    vCod_Cat = cboCod_Cat.Value
            '    DtpLt = personaManager.GetList_Rpt(vCod_Cat)
            'Else
            '    MsgBox("Debe Seleccionar una categoría", MsgBoxStyle.Exclamation, "D'Soft") 'DtSum = MpCtaCte.CtaCteAsistente(CInt(Val(TxtCodAsistente.Text)), 1, 1)
            '    Exit Sub
            'End If

            Dim frm As New FrmVisor_Listado

            'frm.RptListado_Persona(DtpLt, GestionSeguridadManager.Servidor, "Listado General de Personas", cboCod_Cat.Text)

            frm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvCondicion.InitializeLayout
        With dgvCondicion.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "ROLES"
            .Columns(1).Width = 200
            .Columns("abreviatura").Hidden = True
            .Columns("imagen").Hidden = True
            .Columns("estructura").Hidden = True
            .Columns("tipo").Hidden = True
            .Columns("pordefecto").Hidden = True
            .Columns("orden").Hidden = True
            .Columns("estado").Hidden = True
        End With
        Me.dgvCondicion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
        Me.dgvCondicion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Call ListarCondicion()
    End Sub

    Private Sub tsReporte_Click(sender As Object, e As EventArgs) Handles tsReporte.Click

    End Sub

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
        If dgvListado.Rows.Count > 0 Then
            Dim xPersonaId As Long = 0
            If dgvListado.Selected.Rows.Count > 0 Then
                xPersonaId = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
                Dim xFrmPer As New FrmPersonaEdit
                xFrmPer.vPersonaId = xPersonaId
                xFrmPer.ShowDialog()
            End If
        End If


    End Sub
End Class