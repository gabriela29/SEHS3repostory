Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAbono_PorCobrar
  Public DtG As New DataTable

  Public pCodigo As Long, id_tipoDoc As Integer, xBA As Boolean = False, pNC As Boolean
  Public Cerrar As Boolean = False, vDoc_Legal As Boolean = False
  Public dtDocumento As DataTable, dtTipo_Pago As DataTable
  Public pCodigo_Alm As Integer, vCodigo_Per1 As Long
  Public vCodigo_Us As Integer, vCaja As String = "XCOBRAR"
  Public xCont As Integer = 0, vIngreso As Boolean, vImprimir As Boolean, vCopias As Long, pVenta As Boolean, pCodigo_Ref1 As Long
  Public vFormato As String = "", vImpresora As String = "", vSerieTk As String = ""

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    dtDocumento = New DataTable
    dtTipo_Pago = New DataTable
    If vIngreso Then
      If pNC Then
        vCaja = "XCOBRARNC"
      Else
        vCaja = "XCOBRAR"
      End If
    Else
      If pNC Then
        vCaja = "XPAGARNC"
      Else
        vCaja = "XPAGAR"
      End If
    End If

    Try
      Call cursoresManager.Datos_Venta_Cancela_pcp("PC", pCodigo_Alm, vCodigo_Us, vCaja, vDoc_Legal,
                                                    dtDocumento, dtTipo_Pago)

      e.Result = dtDocumento

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted

    dgvDetalle_Pagos.DataSource = DtG
    Call Calcular_Totales_Grid()

    With cboDocumento
      .DataSource = Nothing
      .DataSource = dtDocumento
      .DataBind()
      .ValueMember = "codigo"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If id_tipoDoc > 0 Then
        .Value = id_tipoDoc
      Else
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

    With Me.cboDetalle_Pago
      .DataSource = Nothing
      .DataSource = dtTipo_Pago 'tipo_forma_pagoManager.GetList("%%")
      .DataBind()
      .ValueMember = "codigo"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      End If
    End With

    xCont += 1

    picAjax.Visible = False
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
    Dim vPaga As Single = 0, vSobra As Single = 0

    For Each dgvRw In dtDgv.Rows
      If dgvRw.Band.Index = 0 Then
        vPaga += dgvRw.Cells("Amortiza").Value
      End If
    Next
    vSobra = IIf(IsNumeric(txtSobrante.Text), txtSobrante.Text, 0)

    Me.lblTotalCobrar.Text = FormatNumber(vPaga + vSobra, 2, TriState.True, , TriState.False)
    Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vPaga + vSobra)
  End Sub

  Private Sub FrmAbono_PorCobrar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub


  Private Sub FrmAbono_PorCobrar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    vCodigo_Us = GestionSeguridadManager.idUsuario
    vCaja = (My.Computer.Name)
    picAjax.Visible = True

    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If


  End Sub

  Private Sub dgvDetalle_Pagos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_Pagos.InitializeLayout
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

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

  Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
    Dim xNum As Long = 0
    If IsNumeric(txtNumero.Text) Then
      xNum = txtNumero.Text
      txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
    End If
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

    ''Ruc o DNI
    'If (Me.txtRucDni.Text) = "0" Then
    '    valido = False
    '    ErrorProvider1.SetError(TxtAnombreD, "Debe seleccionar a Nombre de quien se emite el Documento")
    '    camposConError.Add("DNI/RUC")
    'Else
    '    ErrorProvider1.SetError(TxtAnombreD, Nothing)
    'End If

    'COntable


    If Me.lblNroCuenta.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblNroCuenta, "Debe Relacionar a la persona con una cuenta maestra")
      camposConError.Add("NroCTA")
    Else
      ErrorProvider1.SetError(lblNroCuenta, Nothing)
    End If

    If (Me.lblC_Costo.Text.Trim) = "" Then
      valido = False
      ErrorProvider1.SetError(lblC_Costo, "Debe ingresar un Centro de Costo")
      camposConError.Add("C.COSTO")
    Else
      ErrorProvider1.SetError(lblC_Costo, Nothing)
    End If



    ' Empresa
    If (Me.LblEmpresa.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(LblEmpresa, "Datos de la Empresa son IMPORTANTES")
      camposConError.Add("EMPRESA")
    Else
      ErrorProvider1.SetError(LblEmpresa, Nothing)
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
      ErrorProvider1.SetError(ugTotales, "El monto del Documento debe ser Mayor de Cero(0)")
      camposConError.Add("TOTAL")
    Else
      ErrorProvider1.SetError(ugTotales, Nothing)
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
    Dim ObjMB As New movimiento_bancario
    Dim dgvRw As UltraGridRow
    Dim vCodigo As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
    Dim vCod_Abo As Long = 0, vSerie As Long = 0
    Dim xFecha As String, xGlosa As String = ""
    Dim vPaga As Single = 0, Vuelto As Single = 0
    Try

      If ValidarControles() Then
        If BtnGrabar.Text = "&Grabar" Then
          ugbDetalle_Pago.Visible = True
          Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalCobrar.Text, 2, TriState.True, , TriState.False)
          Me.txtPaga.Text = FormatNumber(Me.lblTotalCobrar.Text, 2, TriState.True, , TriState.False)
          If pVenta And pNC Then
            xGlosa = "Dscto. Nota Crédito Venta"
          Else
            xGlosa = "Amortización de cuenta x Pagar"
          End If

          lblson.Text = Me.lblEnLetras.Text
          Me.lblVuelto.Text = "0"
          BtnGrabar.Text = "&Emitir"

          txtPaga.Focus()
        Else
          ' Total a Cobrar
          If Not (CSng(Me.txtPaga.Text) >= CSng(Me.lblTotalCobrar.Text)) Then
            MsgBox("El monto que paga debe ser Igual o Mayor al Importe a Cobrar", MsgBoxStyle.Exclamation, "CORREGIR")
            Exit Sub
          End If

          BtnGrabar.Text = "&Grabar"

          '========================Iniciamos el Grabado===============================
          'Lo metemos en el array FP
          Dim vArrFP As String, vCambio As Single = 0
          vArrFP = ""

          If Not Trim(cboDetalle_Pago.Text) = "" Then
            If CSng(Me.lblTotal_Cobrar.Text) > 0 Then
              vTiene = True
              vArrFP = vArrFP & "['" & Trim(Str(Me.cboDetalle_Pago.Value)) & "', '" _
                                     & Trim(Str(lblTotal_Cobrar.Text)) & "','" _
                                     & Trim(Str(vCambio)) & "','" _
                                     & Trim("NS") & "','" _
                                     & Trim(xGlosa) & "','" _
                                     & Trim(Str(CboSeries.Value)) & "'],"
            End If
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
              If CSng(dgvRw.Cells("Amortiza").Value) > 0 Then
                vTiene = True
                vArrCuentas = vArrCuentas & "['" & Trim(Str(vCod_Abo)) & "', '" &
                                             Trim(Str(dgvRw.Cells("codigo").Value)) & "','" &
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
            If pVenta Then
              .Tipo = "N"
            Else
              .Tipo = IIf(vIngreso, "I", "S")
            End If

            .Codigo_Documento = Val(cboDocumento.Value)
            .Numero = (CboSeries.Text.Trim & "-" & txtNumero.Text.Trim)
            .Codigo_CtaCte = 1 'Val(cboCuenta.BoundText)
            If pVenta And pNC Then
              .Codigo_Tip = 11 'Dscto con Nota de Crédito
            Else
              .Codigo_Tip = 2 'Amortización de cuenta x cobrar
            End If

            .Codigo_Persona = vCodigo_Per1

            .fecha = xFecha
            .Moneda = "NS"
            .Importe = CSng(lblTotal_Cobrar.Text)
            .Cambio = 0
            .Observacion = (txtGlosaDP.Text.Trim)
            .codigo_ref = 0
            .Codigo_Usuario = GestionSeguridadManager.idUsuario
            .Usuario = GestionSeguridadManager.sUsuario
            .caja = My.Computer.Name
            .Cerrado = False
            .Estado = True
            .Codigo1_RefExt = 0
            If pVenta And pNC Then
              .Referencia_Exterior = "VE"
              .Codigo1_RefExt = pCodigo_Ref1
            Else
              .Referencia_Exterior = ""
            End If


            .Codigo2_RefExt = 0
            .Codigo_alm = pCodigo_Alm

            .NroCuenta = Me.lblNroCuenta.Text & ""
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
            .Vuelto = Single.Parse(lblVuelto.Text)
            .Centro_Costo = (lblC_Costo.Text)
            .Sobra = Single.Parse(txtSobrante.Text)
            vCodigo = movimiento_bancarioManager.Grabar(ObjMB, vArrFP, vArrCuentas, vArrPre)

          End With

          If vCodigo > 0 And vImprimir Then
            Call Imprimir_Rpt(vCodigo, vDoc_Legal)
          End If

          Call FrmPor_Cobrar.Mostrar_Detalles()
          Cerrar = True

          Me.Close()
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Imprimir_Rpt(ByVal vCodigo As Long, ByVal vLegal As Boolean)
    If Val(vCodigo) > 0 Then

      Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(vCodigo), pCodigo_Alm, cboDocumento.Value, vCaja, False, False)
      'If ClsImpresiones.Imprimir_Recibo_Interno_pc(vCodigo, vFormato, vImpresora, vSerieTk, vCopias) Then 'If ClsImpresiones.Imprimir_Rpt(xIdRet) Then
      '    'If operacionManager.Incrementar_Impresiones(xIdRet) Then
      '    '    Cerrar = True
      '    'End If
      'End If
    End If

  End Sub

  Private Sub txtPaga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaga.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      'SendKeys.Send("{TAB}")
      'Button1.Focus()
      'btnFalso.Focus()
    End If
  End Sub

  Private Sub txtGlosaDP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosaDP.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      'SendKeys.Send("{TAB}")
      'Button1.Focus()
      'btnFalso.Focus()
    End If
  End Sub


  Private Sub cboDetalle_Pago_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDetalle_Pago.InitializeLayout
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Width = cboDetalle_Pago.Width
  End Sub

  Private Sub txtPaga_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaga.ValueChanged
    If IsNumeric(txtPaga.Text) Then
      lblVuelto.Text = FormatNumber((CSng(IIf(IsNumeric(txtPaga.Text), txtPaga.Text, 0)) - CSng(IIf(IsNumeric(lblTotal_Cobrar.Text), lblTotal_Cobrar.Text, 0))), 2, TriState.True, , TriState.False)
    Else
      lblVuelto.Text = FormatNumber(0, 2, TriState.True, , TriState.False)
    End If
  End Sub

  Private Sub lblNroCuenta_Validated(sender As Object, e As EventArgs) Handles lblNroCuenta.Validated
    If Not Trim(lblNroCuenta.Text) = "" Then
      Dim vNombreCta As String = ""
      Call LibreriasFormularios.ObtenerNombreCta(lblNroCuenta.Text.Trim, vNombreCta)
      lblPersona2Orig.Text = vNombreCta
    Else
      'CtaMstra = ""
      lblPersona2Orig.Text = ""
    End If
  End Sub

  Private Sub txtSobrante_Validated(sender As Object, e As EventArgs) Handles txtSobrante.Validated
    If txtSobrante.Text.Trim = "" Then
      txtSobrante.Text = "0.00"
    End If
    Call Calcular_Totales_Grid()
  End Sub

End Class