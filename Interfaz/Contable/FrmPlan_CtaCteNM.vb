Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPlan_CtaCteNM
    Public pregistrar_VentaId As Long, swNuevo As Boolean
    Public pEntidadId As Long, pNombre As String, pCtaCte As String
  Public pTipo As String

  Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
    Call AgregarLte()
  End Sub

  Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Public Function AgregarLte() As Boolean
    Dim Objeto As New lote, xOk As Boolean = False
    If Not pEntidadId > 0 Then
      MessageBox.Show("No hay una Entidad seleccionada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    If txtCtaCte.Text.Trim = "" Then
      MessageBox.Show("Debe ingresar un nro de Cta CTe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    If cboTipo.Text.Trim = "" Then
      MessageBox.Show("Debe ingresar un Tipo de Cta Cte", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    If txtNombre.Text.Trim = "" Then
      MessageBox.Show("Debe ingresar un Nombre de Cta Cte", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    Try
      Dim vArray As String = "", vTiene As Boolean, vFecha As String = ""
      Dim vCodigo As Long = 0
      'Almacenamos el array

      vTiene = True

      vArray = vArray & "['" & (txtCtaCte.Text.Trim) & "', '" &
                                                         Str(0).Trim & "','" &
                                                         vFecha & "','" &
                                                         txtNombre.Text.Trim & "','" &
                                                         cboTipo.Text.Trim & "']"

      vArray = "array[" & vArray & "]"
      vCodigo = plan_cuentasManager.AgregarCtaCte(lblEntidad.Text, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name)

      If vCodigo > 0 Then
        xOk = True
        Call FrmPlan_Ctacte.ListarCondicion()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
    Return xOk
  End Function

  Private Sub FrmPlan_CtaCteNM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{TAB}")
    End If
  End Sub





    Private Sub FrmPlan_CtaCteNM_Load(sender As Object, e As EventArgs) Handles Me.Load
    lblEntidad.Text = pEntidadId
  End Sub
End Class