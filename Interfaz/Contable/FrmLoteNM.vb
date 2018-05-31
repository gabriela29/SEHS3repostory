Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Public Class FrmLoteNM
  Public pLoteId As Long, swNuevo As Boolean
  Public pAlmacenId As Integer, vAlmacen As String
  Public pTipo As String

  Private Sub llenar_combos()
    Try
      With cboTipo
        .DataSource = Nothing
        .DataSource = tipo_loteManager.GetList("")
        .Refresh()
        .ValueMember = "tipoloteid"
        .DisplayMember = "tipo"
        .MinDropDownItems = 2
        .MaxDropDownItems = 6
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With

      Dim lAnios As New ClsCrearMeses

      With cboMeses
        .DataSource = Nothing
        .DataSource = lAnios.GetList(False, False)
        .Refresh()
        .ValueMember = "codigo"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If

      End With

      With cboAnio
        .DataSource = Nothing
        .DataSource = lAnios.GetList_anios()
        .Refresh()
        .ValueMember = "nombre"
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

  Public Function AgregarLte() As Boolean
    Dim Objeto As New lote, xOk As Boolean = False
    If Not pAlmacenId > 0 Then
      MessageBox.Show("No hay un almacén seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    Try
      With Objeto
        .loteid = -1
        .tipoloteid = cboTipo.Value
        .almacenid = pAlmacenId
        .nombre = Trim(Me.TxtDescripLote.Text)
        .mes = cboMeses.Value
        .anio = cboAnio.Value
        .estado = True
        .usuarioid = GestionSeguridadManager.idUsuario
        .caja = GestionSeguridadManager.NombrePC

      End With

      If loteManager.Grabar(Objeto) > 0 Then
        xOk = True

      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
    Return xOk
  End Function

  Private Sub FrmLoteNM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{TAB}")
    End If
  End Sub

  Private Sub FrmLoteNM_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
    lblAlmacen.Text = vAlmacen
    cboAnio.Text = Year(Date.Now)
    cboMeses.Value = Now.Month
  End Sub

  Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub cboMeses_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMeses.InitializeLayout
    With cboMeses.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboMeses.Width
    End With
  End Sub

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
    If Not Trim(TxtDescripLote.Text) = "" And Not Trim(vAlmacen) = "" _
        And Not cboMeses.Text = "" And Not cboAnio.Text = "" Then
      If MsgBox("¿Está Seguro de Crear un Lote?", MsgBoxStyle.OkCancel, "D'Soft") = MsgBoxResult.Ok Then
        If AgregarLte() Then
          Me.Close()
        End If

      End If
    Else
      MsgBox("Faltan Opciones Importantes para porder crear el Lote", MsgBoxStyle.Exclamation, "AVISO")
    End If
  End Sub


End Class