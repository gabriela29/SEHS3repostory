Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmFacturar_Deposito_Web
  Public pDepositoId As Long, pCodigo_Alm As Integer, pAlmacen As String, pImporte As Single
  Public pColportorId As Long, pColportor As String, pAsistenteid As Long, pAsistente As String
  Public dtDocumento As DataTable, dtSaldos As DataTable
  Public vFormato As String, vImpresora As String, vSerieTk As String, vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long, pCaja As String = "XCOBRAR"

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtSaldos = New DataTable

    vCodigo_Usu = GestionSeguridadManager.idUsuario

    Try
      Call cursoresManager.Datos_Ventana_Dep_Colp_Web(pCodigo_Alm, pColportorId, vCodigo_Usu,
                                                        pCaja, dtDocumento, dtSaldos)

      e.Result = dtDocumento

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted

    With cboDocumento
      .DataSource = Nothing
      .DataSource = dtDocumento
      .DataBind()
      .ValueMember = "codigo"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    With CboSeries
      .DataSource = Nothing
      .DataSource = dtDocumento
      .DataBind()
      .ValueMember = "codigo_serie"
      .DisplayMember = "serie"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = CboSeries.GetRow(ChildRow.First)
      End If
    End With

    dgvDetalle_Pagos.DataSource = dtSaldos
    picAjax.Visible = False

  End Sub

  Private Sub Nueva_Venta()
    Dim vF As Date = Now.Date
    If IsDate(txtFecha.Value) Then
      vF = txtFecha.Value
    End If
    txtFecha.Value = Now.Date

    picAjax.Visible = True

    lblAlmacen.Tag = pCodigo_Alm
    lblAlmacen.Text = pAlmacen

    TxtAnombreD.Text = pColportor
    txtAsistente.Text = pAsistente

    lblTotal_Cobrar.Text = pImporte
    lblson.Text = Numeros_Letras.EnLetras(pImporte)
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
  End Sub

  Private Sub FrmFacturar_Deposito_Web_Load(sender As Object, e As EventArgs) Handles Me.Load
    TxtAnombreD.Text = ""

    Call Nueva_Venta()
  End Sub

  Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
    Dim xNum As Long = 0
    If IsNumeric(txtNumero.Text) Then
      xNum = txtNumero.Text
      txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
    End If
  End Sub

  Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(2).Hidden = True
      .Columns("documento").Width = cboDocumento.Width
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
      .Columns(8).Hidden = True
      .Columns("codigo_serie").Hidden = True
    End With
  End Sub

  Private Sub CboSeries_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboSeries.InitializeLayout
    With CboSeries.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Hidden = True
      .Columns("serie").Width = CboSeries.Width
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
      .Columns(8).Hidden = True
      .Columns("codigo_serie").Hidden = True
    End With
  End Sub

  Private Sub CboSeries_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSeries.ValueChanged
    txtNumero.Text = "00000000"
    If Not CboSeries.DataSource Is Nothing Then
      If Not CboSeries.Text = "" Then
        txtNumero.Text = Format((CboSeries.ActiveRow.Cells("correlativo").Value), "00000000")
        vFormato = CboSeries.ActiveRow.Cells("formato").Value
        vImpresora = CboSeries.ActiveRow.Cells("impresora").Value
        vSerieTk = CboSeries.ActiveRow.Cells("serie_tk").Value
        vImprimir = CBool(CboSeries.ActiveRow.Cells("imprimir").Value)
        vCopias = CboSeries.ActiveRow.Cells("copias").Value
      End If
    End If
  End Sub

  Private Sub Calcular_Totales_Pago()
    Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
    dtDgv = dgvDetalle_Pagos
    Dim vPaga As Single = 0, vSobra As Single = 0
    Dim vTotal As Single = 0

    For Each dgvRw In dtDgv.Rows
      If dgvRw.Band.Index = 0 Then
        vPaga += dgvRw.Cells("paga").Value
      End If
    Next
    vSobra = IIf(IsNumeric(txtSobrante.Text), txtSobrante.Text, 0)
    vTotal = FormatNumber(Me.lblTotal_Cobrar.Text, 2, TriState.True, , TriState.False)
    Me.txtPaga.Text = FormatNumber((vPaga + vSobra), 2, TriState.True, , TriState.False)
    Me.lblSaldo.Text = FormatNumber(vTotal - (vPaga + vSobra), 2, TriState.True, , TriState.False)
    'Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vPaga)
  End Sub

  Private Sub dgvDetalle_Pagos_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalle_Pagos.AfterCellUpdate
    Call Calcular_Totales_Pago()
  End Sub

  Private Sub dgvDetalle_Pagos_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles dgvDetalle_Pagos.BeforeCellUpdate

    If e.Cell.Column.Index = 6 Then 'Amortiza
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

  Private Sub dgvDetalle_Pagos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_Pagos.InitializeLayout
    With dgvDetalle_Pagos.DisplayLayout.Bands(0)
      .Columns("codigo").Hidden = True
      .Columns("documento").Header.Caption = "ABREV"
      .Columns("documento").Width = 50
      .Columns("documento").CellActivation = Activation.NoEdit
      .Columns("numero").Width = 120
      .Columns("numero").CellActivation = Activation.NoEdit
      .Columns("fecha").Header.Caption = "EMISION"
      .Columns("fecha").Width = 80
      .Columns("fecha").CellActivation = Activation.AllowEdit
      .Columns("vencimiento").Header.Caption = "VENCE"
      .Columns("vencimiento").Width = 80
      .Columns("vencimiento").CellActivation = Activation.NoEdit
      .Columns("saldo").Width = 80
      .Columns("saldo").CellActivation = Activation.NoEdit
      .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("paga").Width = 80
      .Columns("paga").CellAppearance.TextHAlign = HAlign.Right
      .Columns("paga").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("paga").CellAppearance.ForeColor = Color.Red
      .Columns("observacion").Hidden = True
      .Columns("usuario").Hidden = True
      .Columns("caja").Hidden = True
      .Columns("condicion").Hidden = True
      .Columns("nrocuenta").Hidden = True
      .Columns("c_costo").Hidden = True
      .Columns("codigo_contable").Hidden = True
    End With
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
      btnGrabar.Focus()
    End If
  End Sub

  Private Sub dgvDetalle_Pagos_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dgvDetalle_Pagos.Validating
    dgvDetalle_Pagos.UpdateData()
  End Sub

  Private Function ValidarControles() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    'Documento
    If cboDocumento.Value = 0 Then
      valido = False
      ErrorProvider1.SetError(cboDocumento, "No hay Documento y/o Debe Seleccionar Uno")
      camposConError.Add("DOCUMENTO")
    Else
      ErrorProvider1.SetError(cboDocumento, Nothing)
    End If

    'Series
    If CboSeries.Value = 0 Then
      valido = False
      ErrorProvider1.SetError(CboSeries, "No hay Serie y/o Debe Seleccionar Una")
      camposConError.Add("SERIE")
    Else
      ErrorProvider1.SetError(CboSeries, Nothing)
    End If

    'Numero Documento
    If Trim(txtNumero.Text) = "00000000" Then
      valido = False
      ErrorProvider1.SetError(txtNumero, "Debe Ingresar un Número de Documento")
      camposConError.Add("NÚMERO")
    Else
      ErrorProvider1.SetError(txtNumero, Nothing)
    End If

    ' Fecha
    If Not IsDate(Me.txtFecha.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFecha, "Fecha No Válida")
      camposConError.Add("FECHA")
    Else
      ErrorProvider1.SetError(txtFecha, Nothing)
    End If

    ' A nombre D
    If (Me.TxtAnombreD.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(TxtAnombreD, "Debe seleccionar a Nombre de quien se emite el Documento")
      camposConError.Add("A NOMBRE D")
    Else
      ErrorProvider1.SetError(TxtAnombreD, Nothing)
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
    If Not CSng(Me.lblTotal_Cobrar.Text) > 0 Then
      valido = False
      ErrorProvider1.SetError(lblTotal_Cobrar, "El monto del Documento debe ser Mayor de Cero(0)")
      camposConError.Add("TOTAL")
    Else
      ErrorProvider1.SetError(lblTotal_Cobrar, Nothing)
    End If

    ' Saldo
    If Not CSng(Me.lblSaldo.Text) = 0 Then
      valido = False
      ErrorProvider1.SetError(lblSaldo, "El saldo no debe ser diferente a de Cero(0)")
      camposConError.Add("TOTAL")
    Else
      ErrorProvider1.SetError(lblSaldo, Nothing)
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

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Dim xF As Boolean = False, vTiene As Boolean = False
    Dim ObjMB As New movimiento_bancario
    Dim dgvRw As UltraGridRow
    Dim vCodigo As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
    Dim vCod_Abo As Long = 0, vSerie As Long = 0
    Dim xFecha As String, xGlosa As String = ""
    Dim vPaga As Single = 0, Vuelto As Single = 0
    Try

      If ValidarControles() Then

        '========================Iniciamos el Grabado===============================
        'Lo metemos en el array FP
        Dim vArrFP As String, vCambio As Single = 0
        vArrFP = ""

        If CSng(Me.lblTotal_Cobrar.Text) > 0 Then
          vTiene = True
          vArrFP = vArrFP & "['" & Trim(Str(3)) & "', '" _
                                 & Trim(Str(lblTotal_Cobrar.Text)) & "','" _
                                 & Trim(Str(vCambio)) & "','" _
                                 & Trim("NS") & "','" _
                                 & Trim(xGlosa) & "','" _
                                 & Trim(Str(CboSeries.Value)) & "'],"
        End If

        If vTiene Then
          vArrFP = Mid(vArrFP, 1, Len(vArrFP) - 1)
          vArrFP = "array[" & vArrFP & "]"
        Else
          vArrFP = "null"
        End If

        'Lo metemos en el array Cta Cte
        Dim vArrCuentas As String
        vArrCuentas = ""
        vTiene = False

        For Each dgvRw In Me.dgvDetalle_Pagos.Rows
          If dgvRw.Band.Index = 0 Then
            If CSng(dgvRw.Cells("paga").Value) > 0 Then
              vTiene = True
              vArrCuentas = vArrCuentas & "['" & Trim(Str(vCod_Abo)) & "', '" &
                                           Trim(Str(dgvRw.Cells("codigo").Value)) & "','" &
                                           Trim(Str(dgvRw.Cells("paga").Value)) & "'],"
            End If

          End If
        Next

        If vTiene Then
          vArrCuentas = Mid(vArrCuentas, 1, Len(vArrCuentas) - 1)
          vArrCuentas = "array[" & vArrCuentas & "]"
        Else
          vArrCuentas = "null"
        End If

        'Lo metemos en el array Prepagos
        Dim vArrPre As String
        vTiene = False
        vArrPre = ""
        'If rsPrepago.State = adStateOpen Then
        '    If rsPrepago.RecordCount > 0 Then
        '        rsPrepago.MoveFirst()
        '        Do While Not rsPrepago.EOF
        '            If Val(rsPrepago("amortizar")) > 0 Then
        '                vTiene = True
        '                vArrPre = vArrPre & "['" & Trim(Str(rsPrepago("codigo"))) & "', '" & Trim(Str(rsPrepago("amortizar"))) & "'],"
        '            End If
        '            rsPrepago.MoveNext()
        '        Loop
        '    End If
        'End If
        If vTiene Then
          vArrPre = Mid(vArrPre, 1, Len(vArrPre) - 1)
          vArrPre = "array[" & vArrPre & "]"
        Else
          vArrPre = "null"
        End If


        Dim vNumero As String
        xFecha = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
        vNumero = Trim(CboSeries.Text) & "-" & Trim(txtNumero.Text)

        With ObjMB
          .Codigo = -1
          .Tipo = "I"
          .Codigo_Documento = cboDocumento.Value
          .Numero = (CboSeries.Text.Trim & "-" & txtNumero.Text.Trim)
          .Codigo_CtaCte = 1 'Val(cboCuenta.BoundText)
          .Codigo_Tip = 2 'Amortización de cuenta x cobrar

          .Codigo_Persona = pColportorId

          .fecha = xFecha
          .Moneda = "NS"
          .Importe = CSng(lblTotal_Cobrar.Text)
          .Cambio = 0
          .Observacion = "DCW:"
          .codigo_ref = 0
          .Codigo_Usuario = GestionSeguridadManager.idUsuario
          .Usuario = GestionSeguridadManager.sUsuario
          .caja = My.Computer.Name
          .Cerrado = False
          .Estado = True
          .Codigo1_RefExt = 0

          .Referencia_Exterior = "DW"
          .Codigo1_RefExt = pDepositoId
          .Codigo2_RefExt = pAsistenteid
          .Codigo_alm = pCodigo_Alm

          .NroCuenta = ""
          .Importe_NoGrabado = 0
          .Valor_igv = 0
          .Importe_IGV = 0
          .Importe_rh = 0
          .Valor_Renta = 0
          .Importe_Renta = 0
          .Importe_Isc = 0
          .Importe_Otros_Imp = 0
          .Cancela = xFecha
          .Fecha_Registro = xFecha
          .Importe_Pago = Single.Parse(txtPaga.Text)
          .Vuelto = 0
          .Centro_Costo = ""
          .Sobra = Single.Parse(txtSobrante.Text)
          vCodigo = movimiento_bancarioManager.Grabar(ObjMB, vArrFP, vArrCuentas, vArrPre)

        End With

        If vCodigo > 0 And vImprimir Then
          Call Imprimir_Rpt(vCodigo, False)
        End If

        Call FrmDeposito_Web.Actualizar()

        Me.Close()

      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Imprimir_Rpt(ByVal vCodigo As Long, ByVal vLegal As Boolean)
    If Val(vCodigo) > 0 Then

      Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(vCodigo), pCodigo_Alm, cboDocumento.Value, pCaja, False, False)

    End If

  End Sub

  Private Sub txtSobrante_Validated(sender As Object, e As EventArgs) Handles txtSobrante.Validated
    If txtSobrante.Text.Trim = "" Then
      txtSobrante.Text = "0.00"
    End If
    Call Calcular_Totales_Pago()
  End Sub

End Class