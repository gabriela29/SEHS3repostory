
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO


Public Class FrmBancoLis
    Public _codigo As Integer
    Public ListadoRegistros As DataTable


    Public Function ListarCondicion() As Boolean
        Dim objetos As New DataTable
        Dim cod_alm As Integer = 0

        Try
            ListadoRegistros = permisos_impresionManager.GetList(cod_alm, 0, 0)
            dgvListadobanco.DataSource = ListadoRegistros
            dgvListadobanco.DataBind()
            If dgvListadobanco.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListadobanco_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListadobanco.InitializeLayout
        With dgvListadobanco.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 200
        End With

    End Sub

    Private Sub tsCerrar_Click(sender As Object, e As EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDNuevo_Click(sender As Object, e As EventArgs) Handles tsDNuevo.Click
        Dim xFrmBanco As New frmBanco
        xFrmBanco.vBancoid = 0
        xFrmBanco.ShowDialog()
    End Sub

    Private Sub tsDEditar_Click(sender As Object, e As EventArgs) Handles tsDEditar.Click
        If dgvListadobanco.Rows.Count > 0 Then
            Dim xbancoid As Long = 0
            If dgvListadobanco.Selected.Rows.Count > 0 Then
                xbancoid = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value
                Dim xFrmPer As New FrmPersonaEdit
                xFrmPer.vPersonaId = xbancoid
                xFrmPer.ShowDialog()
            End If
        End If
    End Sub



    Private Sub tsDDelete_Click(sender As Object, e As EventArgs) Handles tsDDelete.Click
        If dgvListadobanco.Selected.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Call ListarCondicion()
            End If
        End If
    End Sub


End Class