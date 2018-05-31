Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmActualiza_Provision_Castigo_Deuda
  Public vUnidad_Negocio As String, vCodigo_Uni As Integer, xCalcular As Boolean = True
  Public vAlmacen As String, vAlmacenid As Integer

  Private Sub FrmActualiza_Provision_Castigo_Deuda_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
    dgvListado.DataSource = Nothing
    txtFec_Hasta_Venc.Value = Date.Now.Date
    txtFecha.Value = Date.Now.Date
    LblAlmacen.Tag = vAlmacenid
    LblAlmacen.Text = vAlmacen
    LblUnidad.Text = vUnidad_Negocio
    Call LibreriasFormularios.formatear_grid_Edit(dgvListado)
    Me.WindowState = FormWindowState.Maximized

  End Sub

  Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork
    Dim DtObl_L As New DataTable, DtGrid As New DataTable
    Dim xCod_Proc As Long = 0, vHasta As String = ""
    vHasta = LibreriasFormularios.Formato_Fecha(txtFec_Hasta_Venc.Value)
    xCod_Proc = LblAlmacen.Tag

    DtObl_L = por_cobrarManager.PorCobrar_Prov_Castigo(vCodigo_Uni, vAlmacenid, vHasta, Long.Parse(txtHastaNDias.Text))

    e.Result = DtObl_L

  End Sub

  Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted
    dgvListado.DataSource = CType(e.Result, DataTable)
    Call Calcular_Totales_Grid()
    picAjax.Visible = False

    Me.LblRegistros.Text = "Existen " & dgvListado.Rows.Count & " Registros Mostrados"
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("porcobrarid").Header.Caption = "ID"
      .Columns("porcobrarid").Width = 20
      .Columns("porcobrarid").CellActivation = Activation.NoEdit
      .Columns("clienteid").Header.Caption = "CL"
      .Columns("clienteid").Width = 20
      .Columns("clienteid").CellActivation = Activation.NoEdit
      .Columns("rucdni").Header.Caption = "RUC DNI"
      .Columns("rucdni").Width = 90
      .Columns("rucdni").CellActivation = Activation.NoEdit
      .Columns("nombre").Header.Caption = "NOMBRE"
      .Columns("nombre").Width = 280
      .Columns("nombre").CellActivation = Activation.NoEdit
      .Columns("emision").Header.Caption = "EMISION"
      .Columns("emision").Width = 80
      .Columns("emision").CellActivation = Activation.NoEdit
      .Columns("vencimiento").Header.Caption = "VENCIMIENTO"
      .Columns("vencimiento").Width = 80
      .Columns("vencimiento").CellActivation = Activation.NoEdit
      .Columns("ndias").Header.Caption = "DIAS"
      .Columns("ndias").Width = 60
      .Columns("ndias").CellActivation = Activation.NoEdit
      .Columns("ndias").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("ndias").CellAppearance.FontData.Bold = DefaultableBoolean.True
      .Columns("documento").Header.Caption = "DOCUMENTO"
      .Columns("documento").Width = 120
      .Columns("documento").CellActivation = Activation.NoEdit

      .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
      .Columns("importe").Width = 80
      .Columns("importe").CellActivation = Activation.NoEdit

      .Columns("pagos").CellAppearance.TextHAlign = HAlign.Right
      .Columns("pagos").Width = 80
      .Columns("pagos").CellActivation = Activation.NoEdit
      .Columns("saldo").CellAppearance.FontData.Bold = DefaultableBoolean.True
      .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("saldo").Width = 80
      .Columns("saldo").CellActivation = Activation.NoEdit
      '.Columns("castigo").CellAppearance.BackColor = Color.LemonChiffon
      '.Columns("castigo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("castigo").Hidden = True

      .Columns("detalle").Header.Caption = "DETALLE"
      .Columns("detalle").Width = 100
      .Columns("detalle").MaxLength = 150

      .Columns("direccion").CellActivation = Activation.NoEdit
      .Columns("telefono").CellActivation = Activation.NoEdit
      .Columns("email").CellActivation = Activation.NoEdit
      .Columns("observacion").CellActivation = Activation.NoEdit
      .Columns("caja").CellActivation = Activation.NoEdit
      .Columns("unidadid").Hidden = True
      .Columns("unidad").CellActivation = Activation.NoEdit
      .Columns("uabrev").CellActivation = Activation.NoEdit
      .Columns("almacenid").Hidden = True
      .Columns("almacen").CellActivation = Activation.NoEdit
      .Columns("aabrev").CellActivation = Activation.NoEdit
    End With
  End Sub

  Private Sub Calcular_Totales_Grid()
    Dim dgvRw As UltraGridRow
    Dim vSaldo As Single = 0, vCastigo As Single = 0

    For Each dgvRw In dgvListado.Rows
      If dgvRw.Band.Index = 0 Then
        vSaldo += dgvRw.Cells("saldo").Value

        'vCastigo += dgvRw.Cells("castigo").Value

      End If
    Next

    Me.LblTotalSel.Text = FormatNumber(vSaldo, 2, TriState.True, , TriState.False)
    Me.lblTotalTemp.Text = FormatNumber(vSaldo, 2, TriState.True, , TriState.False)

  End Sub

  Private Function ValidarControles() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String


    'Nro Voto
    If txtNroVoto.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(txtNroVoto, "Debe ingresar nro de Voto, de lo contrario registrar (0)")
      camposConError.Add("NROVOTO")
    Else
      ErrorProvider1.SetError(txtNroVoto, Nothing)
    End If

    ' Fecha
    If Not IsDate(Me.txtFecha.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFecha, "Fecha No Válida")
      camposConError.Add("FECHA")
    Else
      ErrorProvider1.SetError(txtFecha, Nothing)
    End If
    ' Fecha Hasta
    If Not IsDate(txtFec_Hasta_Venc.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFec_Hasta_Venc, "Fecha No Válida")
      camposConError.Add("FECHA_HASTA")
    Else
      ErrorProvider1.SetError(txtFec_Hasta_Venc, Nothing)
    End If

    If Not (Me.txtFecha.Value = txtFec_Hasta_Venc.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFec_Hasta_Venc, "Las fechas deben ser iguales")
      camposConError.Add("FECHA_HASTA")
    Else
      ErrorProvider1.SetError(txtFec_Hasta_Venc, Nothing)
    End If

    ' Observación
    If Trim(Me.txtObservacion.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtObservacion, "Debe Registrar una Observación")
      camposConError.Add("Observacion")
    Else
      ErrorProvider1.SetError(txtObservacion, Nothing)
    End If

    ' lblProceso
    If (Me.LblAlmacen.Text) = "" Or vAlmacenid = 0 Then
      valido = False
      ErrorProvider1.SetError(LblAlmacen, "No hay Almacén Activo")
      camposConError.Add("Proceso")
    Else
      ErrorProvider1.SetError(LblAlmacen, Nothing)
    End If

    ' Unidad
    If (Me.LblUnidad.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(LblUnidad, "Datos de Unidad no válido")
      camposConError.Add("UNIDAD")
    Else
      ErrorProvider1.SetError(LblUnidad, Nothing)
    End If


    ' Total a Cobrar
    If Not CSng(Me.LblTotalSel.Text) > 0 Then
      valido = False
      ErrorProvider1.SetError(lblTotalTemp, "El monto a Castigar debe ser Mayor de Cero(0)")
      camposConError.Add("TOTAL")
    Else
      ErrorProvider1.SetError(lblTotalTemp, Nothing)
    End If




    If Not valido Then
      Lblerror.Text = "Introduzca y/o Seleccione un valor en  "

      For Each campo In camposConError
        Lblerror.Text &= campo & ", "
      Next
      Lblerror.Text = Lblerror.Text.Substring(0, Lblerror.Text.Length - 2)
    End If

    Return valido
  End Function

  Private Sub BtnGrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGrabar.Click
    Dim vTiene As Boolean = False
    Dim dgvRw As UltraGridRow
    Dim xIdRet As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
    Dim vArray As String = "", xFecha As String = "", xFech_Dias As String = ""

    If MessageBox.Show("¿Está Seguro de Grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If
    Try

      If ValidarControles() Then
        If BtnGrabar.Text = "&Grabar" Then
          xFecha = LibreriasFormularios.Formato_Fecha(txtFecha.Value)
          xFech_Dias = LibreriasFormularios.Formato_Fecha(txtFec_Hasta_Venc.Value)

          'Lo metemos en el array los Grid
          vArray = ""

          'Deudas a Castigar
          For Each dgvRw In Me.dgvListado.Rows
            If dgvRw.Band.Index = 0 Then
              If dgvRw.Cells("saldo").Value > 0 Then
                vTiene = True
                vArray = vArray & "['" & Trim(Str(dgvRw.Cells("porcobrarid").Value)) & "', '" &
                                    Trim(Str(dgvRw.Cells("saldo").Value)) & "', '" &
                                    Trim(Str(dgvRw.Cells("saldo").Value)) & "', '" &
                                    Trim((dgvRw.Cells("detalle").Value)) & "', '" &
                                    Trim(Str(dgvRw.Cells("ndias").Value)) & "'],"
              End If
            End If
          Next

          If vTiene Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
          Else
            vArray = "null"
          End If

          xIdRet = por_cobrarManager.Grabar_Prov_Castigo(vAlmacenid, xFecha, txtNroVoto.Text, txtObservacion.Text, xFech_Dias,
                                                         txtHastaNDias.Text, vArray, vCod_us, My.Computer.Name)

          Me.Close()
          MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click

    If Not bwLlenar_Grid.IsBusy Then
      picAjax.Visible = True
      bwLlenar_Grid.RunWorkerAsync()
    End If
  End Sub

  Private Sub dgvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyValue = Keys.Up Or e.KeyValue = Keys.Down Or
    e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then

      Call LibreriasFormularios.Navy_Cells_uGrid(sender, e)

    End If
  End Sub

  Private Sub dgvListado_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles dgvListado.AfterCellUpdate
    Call Calcular_Totales_Grid()
  End Sub

  Private Sub dgvListado_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles dgvListado.BeforeCellUpdate
    If e.Cell.Column.Index = 11 Then 'Castiga
      If e.Cell.Text.Trim = "" Then
        MsgBox("El Monto a Castigar debe ser Mayor y/o Igual a Cero(0)", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
      If Not CSng(e.Cell.Text) >= 0 Then
        MsgBox("El Monto a Cancelar debe ser Mayor y/o Igual a Cero(0)", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
      If CSng(e.Cell.Text) > CSng(dgvListado.ActiveRow.Cells("saldo").Value) Then
        MsgBox("El Monto a Castigar no debe ser mayor al Saldo", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
    End If
  End Sub
End Class