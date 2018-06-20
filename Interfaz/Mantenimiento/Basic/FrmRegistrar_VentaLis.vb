
Imports CapaLogicaNegocio
Imports CapaLogicaNegocio.BLL
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrar_VentaLis
    Public pregistrarvId As Long, swNuevo As Boolean
    Public _codigo As Integer
    Public ListadoRegistros As DataTable


    Private Sub FrmRegistrar_VentaLis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub



    Public Function ListarCondiciones() As Boolean
        Dim xLimit As Integer
        Dim vArray As String = "", vTiene As Boolean = False
        Dim dgvRw As UltraGridRow
        xLimit = Integer.Parse(txtLimite.Text)


        If vTiene Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If


        Try
            ListadoRegistros = registrarvManager.GetList(txtalmacen.Text, txtmes.Text, txtanio.Text, "", vArray, xLimit, 0)
            dgvListadoregis.DataSource = ListadoRegistros
            'dgvListado.DataBind()
            If dgvListadoregis.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function


    Private Sub dgvListado_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListadoregis.AfterRowsDeleted
        Call Eliminar(CInt(_codigo))
        Call ListarCondiciones()
    End Sub

    Private Sub dgvListadoregis_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListadoregis.AfterRowUpdate
        Call ListarCondiciones()
    End Sub



    Public Function Eliminar(ByVal _id As Integer) As Boolean
        'Eliminar = personaManager.Eliminar(_id, GestionSeguridadManager.idUsuario, GestionSeguridadManager.miIP)
    End Function

    Private Sub dgvListadoregis_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListadoregis.BeforeSelectChange
        If dgvListadoregis.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                _codigo = Long.Parse((dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Value))
            Else
                _codigo = 0
            End If
        End If
    End Sub

    Private Sub dgvListadoregis_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListadoregis.InitializeLayout
        With dgvListadoregis.DisplayLayout.Bands(0)
            .Columns(0).Header.Caption = "CODIGO"
            .Columns(0).Width = 20
            .Columns(1).Hidden = True
            .Columns(2).Header.Caption = "NOMBRE"
            .Columns(2).Width = 80
            .Columns(3).Header.Caption = "CODIGO-SUNAT"
            .Columns(3).Width = 80

            .Columns(4).Header.Caption = "TIPO  DE DOCUMENTO"
            .Columns(4).Width = 350
            .Columns("persona").Width = 200
            .Columns("Persona").Header.Caption = "NOMBRE DE PERSONA"
            .Columns("afecto").Width = 180
            .Columns("afecto").Header.Caption = "AFECTO"
            .Columns("serie_int").Width = 180
            .Columns("serie_int").Header.Caption = "SERIE"
            .Columns("numero:int").Hidden = True
            .Columns("codigo_doc").Hidden = True
            .Columns("almacenid").Hidden = True
        End With

        'Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpEliminar_Click(sender As Object, e As EventArgs) Handles TpEliminar.Click
        If dgvListadoregis.Selected.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call Eliminar(CInt(dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondiciones()
            End If
        End If
    End Sub

    Private Sub dgvListadoregis_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListadoregis.BeforeRowsDeleted
        _codigo = CInt(dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Value)
    End Sub


    Private Sub TpNuevo_Click(sender As Object, e As EventArgs) Handles TpNuevo.Click
        Dim frm As FrmRegistrarVentaF = New FrmRegistrarVentaF
        frm.swNuevo = True
        frm.ShowDialog()
    End Sub

    Private Sub llenar_combos()
        Try
            With dgvListadoregis 'Por verse

                .DataSource = Nothing
                .DataSource = rolManager.GetList()
                .DataBind()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "existe ya !")
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

    Private Sub tsReporte_Click(sender As Object, e As EventArgs) Handles tsReporte.Click

    End Sub

    Private Sub FrmRegistrar_VentaLis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call llenar_combos()
        Call LibreriasFormularios.formatear_grid(dgvListadoregis)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call ListarCondiciones()

    End Sub

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
        If dgvListadoregis.Rows.Count > 0 Then
            Dim xregistrarvId As Long = 0
            If dgvListadoregis.Selected.Rows.Count > 0 Then
                xregistrarvId = dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Value
                Dim xFrmregistrar As New FrmRegistrarVentaF
                xFrmregistrar.pregistrarvId = xregistrarvId
                xFrmregistrar.ShowDialog()
            End If
        End If


    End Sub


End Class