Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAlmacenEdit
    Public ModoVentanaFlotante As Boolean
    Public id_Unidadid As Integer

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmAlmacenEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub llenar_combos()
        Try

            Me.cboUnidad.DataSource = empresaManager.GetList("%%")
            Me.cboUnidad.DataBind()
            Me.cboUnidad.ValueMember = "empresaid"
            Me.cboUnidad.DisplayMember = "nombre"
            Me.cboUnidad.MinDropDownItems = 2
            Me.cboUnidad.MaxDropDownItems = 4
            If id_Unidadid > 0 Then
                cboUnidad.Value = id_Unidadid
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmAlmacenEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call 
    End Sub
End Class