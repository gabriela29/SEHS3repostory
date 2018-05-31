Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAbono_PorCobrarII
  Public DtG As New DataTable

  Public pCodigo As Long, xBA As Boolean = False, pNC As Boolean
  Public dtTipo_Pago As DataTable
  Public pCodigo_Alm As Integer, vCodigo_Per1 As Long
  Public xCont As Integer = 0, pCodigo_Ref1 As Long
  Private Sub Llenar_Combos()

    dgvDetalle_Pagos.DataSource = DtG
    Call Calcular_Totales_Grid()


    With Me.cboDetalle_Pago
      .DataSource = Nothing
      .DataSource = dtTipo_Pago
      .DataBind()
      .ValueMember = "movbanid"
      .DisplayMember = "sobrante"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    xCont += 1

    BtnGrabar.Visible = True
    If dgvDetalle_Pagos.Rows.Count > 0 Then
      'dgvDetalle.ActiveCell = dgvDetalle.Rows(0).Cells(3)
      'dgvDetalle_Pagos.Rows(0).Cells("Amortizar").Value = 100
      dgvDetalle_Pagos.ActiveCell = dgvDetalle_Pagos.Rows(0).Cells("Amortiza")
      dgvDetalle_Pagos.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End If

  End Sub

  Private Sub Calcular_Totales_Grid()
    Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
    dtDgv = dgvDetalle_Pagos
    Dim vPaga As Single = 0

    For Each dgvRw In dtDgv.Rows
      If dgvRw.Band.Index = 0 Then
        vPaga += dgvRw.Cells("Amortiza").Value
      End If
    Next

    Me.lblTotalCobrar.Text = FormatNumber(vPaga, 2, TriState.True, , TriState.False)
    Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vPaga)
  End Sub

  Private Sub FrmAbono_PorCobrarII_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub


  Private Sub FrmAbono_PorCobrarII_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Call Llenar_Combos()
  End Sub

  Private Sub dgvDetalle_Pagos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_Pagos.InitializeLayout
    Dim Appearance1 As Appearance = New Appearance

    With dgvDetalle_Pagos.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = 120
      .Columns(1).CellActivation = Activation.NoEdit
      .Columns(1).Header.Caption = "Documento"

      .Columns(2).Width = 100
      .Columns(2).CellActivation = Activation.NoEdit

      .Columns("Vencimiento").Width = 100
      .Columns("Vencimiento").CellActivation = Activation.NoEdit

      .Columns("Saldo").Width = 80
      .Columns("Saldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("Saldo").CellAppearance.BackColor = Color.PaleGreen
      .Columns("Saldo").CellAppearance.AlphaLevel = 50
      .Columns("Saldo").CellAppearance.BackColorAlpha = Alpha.UseAlphaLevel
      .Columns("Saldo").CellActivation = Activation.NoEdit

      .Columns("Amortiza").Width = 100
      .Columns("Amortiza").CellAppearance.TextHAlign = HAlign.Right
      .Columns("Amortiza").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("Amortiza").CellAppearance.ForeColor = Color.Red

      '.Columns("NroCuenta").Header.Caption = "N° Cuenta"
      '.Columns("NroCuenta").Width = 120
      '.Columns("NroCuenta").CellActivation = Activation.NoEdit

      '.Columns("C_Costo").Header.Caption = "C.Costo"
      '.Columns("C_Costo").Width = 80
      '.Columns("C_Costo").CellActivation = Activation.NoEdit

      .Columns("observacion").Width = 120
      .Columns("observacion").MaxLength = 40
    End With

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    Appearance1.BorderColor = Color.Black
    Appearance1.BorderAlpha = Alpha.Default

    Me.dgvDetalle_Pagos.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed
    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
    Appearance1.ImageBackground = Global.Phoenix.My.Resources.Resources.kexibig  'foto_e_commerce_1
    Me.dgvDetalle_Pagos.DisplayLayout.Appearance = Appearance1
    Me.dgvDetalle_Pagos.DisplayLayout.Appearance.ForeColor = Color.Navy
    Me.dgvDetalle_Pagos.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
  End Sub

  Private Sub dgvDetalle_Pagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle_Pagos.KeyDown

    If e.KeyValue = Keys.Up Or e.KeyValue = Keys.Down Or
        e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then

      Call LibreriasFormularios.Navy_Cells_uGrid(sender, e)

    End If
  End Sub

  Private Sub dgvDetalle_Pagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalle_Pagos.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      'SendKeys.Send("{TAB}")
      'Button1.Focus()

    End If
  End Sub

  Private Sub dgvDetalle_Pagos_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalle_Pagos.AfterCellUpdate

    Call Calcular_Totales_Grid()

  End Sub

  Private Sub dgvDetalle_Pagos_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles dgvDetalle_Pagos.BeforeCellUpdate

    If e.Cell.Column.Index = 5 Then 'Amortiza
      If e.Cell.Text.Trim = "" Then
        MsgBox("El Monto a Cancelar debe ser Mayor y/o Igual a Cero(0)", MsgBoxStyle.Exclamation, "AVISO")
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
      If CSng(e.Cell.Text) > CSng(dgvDetalle_Pagos.ActiveRow.Cells("Saldo").Value) Then
        MsgBox("El Monto a Cancelar no debe ser mayor al Saldo", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
    End If

  End Sub

  Private Sub dgvDetalle_Pagos_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_Pagos.AfterRowsDeleted
    Call Calcular_Totales_Grid()
  End Sub

  Private Sub dgvDetalle_Pagos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dgvDetalle_Pagos.Validating

    dgvDetalle_Pagos.UpdateData()

  End Sub

  Private Function ValidarControles(ByVal vEmitir As Boolean) As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String


    ' Empresa
    If (Me.LblEmpresa.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(LblEmpresa, "Datos de la Empresa son IMPORTANTES")
      camposConError.Add("EMPRESA")
    Else
      ErrorProvider1.SetError(LblEmpresa, Nothing)
    End If

    ' Sobrante
    If (Me.cboDetalle_Pago.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(dgvDetalle_Pagos, "Debe seleccionar una forma de pago")
      camposConError.Add("SOBRANTE")
    Else
      ErrorProvider1.SetError(cboDetalle_Pago, Nothing)
    End If

    ' Grid
    If Not (Me.dgvDetalle_Pagos.Rows.Count) > 0 Then
      valido = False
      ErrorProvider1.SetError(dgvDetalle_Pagos, "No hay Conceptos que Abonar")
      camposConError.Add("DETALLES")
    Else
      ErrorProvider1.SetError(dgvDetalle_Pagos, Nothing)
    End If

    ' Total a Cobrar
    If Not CSng(Me.lblTotalCobrar.Text) > 0 Then
      valido = False
      ErrorProvider1.SetError(lblTotalCobrar, "El monto del Documento debe ser Mayor de Cero(0)")
      camposConError.Add("TOTAL")
    Else
      ErrorProvider1.SetError(lblTotalCobrar, Nothing)
    End If
    If vEmitir Then
      'no pagar mas del sobrante
      Dim vSobrante As Single = 0
      vSobrante = cboDetalle_Pago.Text
      If Not (vSobrante - Single.Parse(txtPaga.Text)) >= 0 Then
        valido = False
        ErrorProvider1.SetError(txtPaga, "No debe ser mayor a: " & vSobrante)
        camposConError.Add("PAGA")
      Else
        ErrorProvider1.SetError(txtPaga, Nothing)
      End If

      If Single.Parse(lblVuelto.Text) <> 0 Then
        valido = False
        ErrorProvider1.SetError(lblVuelto, "La diferencia Debe ser igual a cero 0")
        camposConError.Add("VUELTO")
      Else
        ErrorProvider1.SetError(lblVuelto, Nothing)
      End If
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

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
    Dim xF As Boolean = False, vTiene As Boolean = False
    Dim dgvRw As UltraGridRow
    Dim vCodigo As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
    Dim vCod_Abo As Long = 0
    Dim vPaga As Single = 0, Vuelto As Single = 0
    Try

      If ValidarControles(False) Then
        If BtnGrabar.Text = "&Grabar" Then
          ugbDetalle_Pago.Visible = True
          Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalCobrar.Text, 2, TriState.True, , TriState.False)
          Me.txtPaga.Text = FormatNumber(Me.lblTotalCobrar.Text, 2, TriState.True, , TriState.False)

          lblson.Text = Me.lblEnLetras.Text
          Me.lblVuelto.Text = "0"
          BtnGrabar.Text = "&Emitir"

          txtPaga.Focus()
        Else
          If ValidarControles(True) = False Then
            Exit Sub
          End If
          ' Total a Cobrar
          If Not (CSng(Me.txtPaga.Text) >= CSng(Me.lblTotalCobrar.Text)) Then
            MsgBox("El monto que paga debe ser Igual o Mayor al Importe a Cobrar", MsgBoxStyle.Exclamation, "CORREGIR")
            Exit Sub
          End If
          BtnGrabar.Enabled = False
          'BtnGrabar.Text = "&Grabar"

          '========================Iniciamos el Grabado===============================

          'Lo metemos en el array Cta Cte
          Dim vArrCuentas As String
          vArrCuentas = ""
          vTiene = False

          For Each dgvRw In Me.dgvDetalle_Pagos.Rows
            If dgvRw.Band.Index = 0 Then
              If CSng(dgvRw.Cells("Amortiza").Value) > 0 Then
                vTiene = True
                vArrCuentas = vArrCuentas & "['" & Trim(Str(dgvRw.Cells("codigo").Value)) & "','" &
                                                   Trim(Str(dgvRw.Cells("Amortiza").Value)) & "'],"
              End If

            End If
          Next

          If vTiene Then
            vArrCuentas = Mid(vArrCuentas, 1, Len(vArrCuentas) - 1)
            vArrCuentas = "array[" & vArrCuentas & "]"
          Else
            vArrCuentas = "null"
          End If


          vCodigo = movimiento_bancarioManager.Registrar_Uso_Sobrante(cboDetalle_Pago.Value, vArrCuentas)
          Call FrmPor_Cobrar.Mostrar_Detalles()

          Me.Close()
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub cboDetalle_Pago_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles cboDetalle_Pago.InitializeLayout
    With cboDetalle_Pago.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns("nombre_corto").Width = 40
      .Columns("numero").Width = 50
      .Columns("fecha").Width = 80
      .Columns("importe").Hidden = True
      .Columns("sobrante").Width = 80
      .Columns("observacion").Hidden = True
      .Columns("codigo_mb").Hidden = True
      .Columns("documentoid").Hidden = True
    End With
  End Sub

  Private Sub txtPaga_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaga.ValueChanged
    If IsNumeric(txtPaga.Text) Then
      lblVuelto.Text = FormatNumber((CSng(IIf(IsNumeric(txtPaga.Text), txtPaga.Text, 0)) - CSng(IIf(IsNumeric(lblTotal_Cobrar.Text), lblTotal_Cobrar.Text, 0))), 2, TriState.True, , TriState.False)
    Else
      lblVuelto.Text = FormatNumber(0, 2, TriState.True, , TriState.False)
    End If
  End Sub

  Private Sub txtPaga_Validated(sender As Object, e As EventArgs) Handles txtPaga.Validated
    If cboDetalle_Pago.Text = "" Then
      MessageBox.Show("Debe Seleccionar una forma de Pago", "AVISO")
      Exit Sub
    End If
    'If Single.Parse(lblVuelto.Text) <> 0 Then
    '  MessageBox.Show("La diferencia Debe ser igual a cero 0", "AVISO")
    '  txtPaga.Focus()
    'End If

    'Dim vSobrante As Single = 0
    'vSobrante = cboDetalle_Pago.Text
    'If txtPaga.Text > vSobrante Then
    '  MessageBox.Show("No debe ser mayor a: " & vSobrante, "AVISO")
    '  txtPaga.Focus()
    'End If
  End Sub
End Class