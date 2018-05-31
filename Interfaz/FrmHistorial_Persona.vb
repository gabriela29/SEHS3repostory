Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmHistorial_Persona
    Public pCodigo_Per As Long, pPersona As String
    Private Sub FrmHistorial_Persona_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        LblPersona.Text = pPersona
        dgvListado.DataSource = por_cobrarManager.Info_Sehs(pCodigo_Per, "")
    End Sub
End Class