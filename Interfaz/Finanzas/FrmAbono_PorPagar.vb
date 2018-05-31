Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmAbono_PorPagar
  Public DtG As New DataTable
  Public id_tipoDoc As Integer, xBA As Boolean = False, pNC As Boolean
  Public Cerrar As Boolean = False, vDoc_Legal As Boolean = False
  Public dtLote As DataTable, dtTipo_Pago As DataTable, pDtCtaCte As DataTable
  Public pCodigo_Alm As Integer, vCodigo_Per1 As Long
  Public vCodigo_Us As Integer, vCaja As String = "XPAGAR"
  Public xCont As Integer = 0, vIngreso As Boolean, vImprimir As Boolean, vCopias As Long
  Public vFormato As String = "", vImpresora As String = "", vSerieTk As String = ""

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    dtLote = New DataTable
    dtTipo_Pago = New DataTable

    Try
      Call cursoresManager.Datos_Venta_Cancela_pcp("PP", pCodigo_Alm, vCodigo_Us, vCaja, vDoc_Legal,
                                                    dtLote, dtTipo_Pago)

      e.Result = dtLote

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted

    dgvDetalle_Pagos.DataSource = DtG
    Call Calcular_Totales_Grid()

    With cboDocumento
      .DataSource = Nothing
      .DataSource = dtLote
      .DataBind()
      .ValueMember = "codigo"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If id_tipoDoc > 0 Then
        .Value = id_tipoDoc
      Else
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      End If
    End With
    'With CboSeries
    '    .DataSource = Nothing
    '    .DataSource = dtDocumento
    '    .DataBind()
    '    .ValueMember = "codigo_serie"
    '    .DisplayMember = "serie"
    '    .MinDropDownItems = 2
    '    .MaxDropDownItems = 4
    '    If .Rows.Count > 0 Then
    '        .SelectedRow = CboSeries.GetRow(UltraWinGrid.ChildRow.First)
    '    End If
    'End With

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
    vSobra = 0

    Me.lblTotalCobrar.Text = FormatNumber(vPaga + vSobra, 2, TriState.True, , TriState.False)
    Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vPaga + vSobra)
  End Sub

  Private Sub FrmAbono_PorCobrar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub

  Private Sub LLenarCombos()
    With cboMoneda
      .DataSource = Nothing
      .DataSource = monedaManager.GetList("")
      .DataBind()
      .ValueMember = "tipomonedaid"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        'If pCodigo_Det = 0 Then
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        'End If
      End If
    End With
    With cboCentro_Costo_Pago
      .DataSource = Nothing
      .DataSource = centro_costoManager.GetListcbo(pCodigo_Alm, 0)
      .DataBind()
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        'If pCodigo_Det = 0 Then
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        'End If
      End If
    End With

    With cboCuentaB
      .DataSource = Nothing
      .DataSource = GestionTablas.dtplan
      .DataBind()
      .ValueMember = "plancuentaid"
      .DisplayMember = "cuenta"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then

      End If
    End With
  End Sub

  Private Sub FrmAbono_PorCobrar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    vCodigo_Us = GestionSeguridadManager.idUsuario
    vCaja = (My.Computer.Name)
    picAjax.Visible = True

    Call LLenarCombos()

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
    Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    Appearance1.BorderColor = Color.Black
    Appearance1.BorderAlpha = Alpha.Default

    Me.dgvDetalle_Pagos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
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

  Private Sub cboMoneda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboMoneda.InitializeLayout
    With cboMoneda.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboMoneda.Width
    End With
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

  Private Sub cboCuentaB_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboCuentaB.InitializeLayout
    With cboCuentaB.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns("cuenta").Width = cboCuentaB.Width
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      '.Columns(3).Hidden = True
      .Columns(4).Hidden = True
    End With
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

  Private Function ValidarControles() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    ' ''Documento
    ''If cboDocumento.Value = 0 Then
    ''    valido = False
    ''    ErrorProvider1.SetError(cboDocumento, "No hay Documento y/o Debe Seleccionar Uno")
    ''    camposConError.Add("DOCUMENTO")
    ''Else
    ''    ErrorProvider1.SetError(cboDocumento, Nothing)
    ''End If

    ' ''Numero Documento
    ''If Trim(txtNumero.Text) = "00000000" Then
    ''    valido = False
    ''    ErrorProvider1.SetError(txtNumero, "Debe Ingresar un Número de Documento")
    ''    camposConError.Add("NÚMERO")
    ''Else
    ''    ErrorProvider1.SetError(txtNumero, Nothing)
    ''End If

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
    Dim xFecha As String
    Dim vPaga As Single = 0, Vuelto As Single = 0
    Try

      If ValidarControles() Then
        If BtnGrabar.Text = "&Grabar" Then
          ugbDetalle_Pago.Visible = True
          Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalCobrar.Text, 2, TriState.True, , TriState.False)

          lblson.Text = Me.lblEnLetras.Text

          BtnGrabar.Text = "&Emitir"


        Else

          BtnGrabar.Text = "&Grabar"

          '========================Iniciamos el Grabado===============================
          'Lo metemos en el array FP
          Dim vArrFP As String, vCambio As Single = 0
          vArrFP = ""
          If txtTipoCambio.Visible = True Then
            vCambio = Single.Parse(txtTipoCambio.Text)
          End If

          If Not Trim(cboDetalle_Pago.Text) = "" Then
            If CSng(Me.lblTotal_Cobrar.Text) > 0 Then
              vTiene = True
              vArrFP = vArrFP & "['" & Trim(Str(Me.cboDetalle_Pago.Value)) & "', '" _
                                     & Trim(Str(lblTotal_Cobrar.Text)) & "','" _
                                     & Trim(Str(vCambio)) & "','" _
                                     & Trim(cboMoneda.Value) & "']," _
              '& Trim(txtGlosaDP.Text) & "','" _
              '& Trim(Str(CboSeries.Value)) & "'],"
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

          'Lo metemos en el array Registro MB
          Dim vArrRB As String = "", vCCp As String = IIf(cboCentro_Costo_Pago.Text = "", "", cboCentro_Costo_Pago.Value)
          vTiene = False
          If Not cboCuentaB.Text = "" Then
            vTiene = True
            vArrRB = ""
            vArrRB = "['" & Trim(Str(cboCuentaB.Text)) & "','" _
                                         & Trim((cboCtaCteB.Text)) & "','" _
                                         & Trim(vCCp) & "','" _
                                         & Trim(txtNroOPeracion.Text) & "','" _
                                         & Trim(GestionSeguridadManager.sUsuario) & "'],"
          End If

          If vTiene Then
            vArrRB = Mid(vArrRB, 1, Len(vArrRB) - 1)
            vArrRB = "array[" & vArrRB & "]"
          Else
            vArrRB = "null"
          End If


          Dim vNumero As String
          xFecha = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
          vNumero = Trim(txtNumero.Text)

          With ObjMB
            .Codigo = -1
            .Tipo = "S" 'IIf(vIngreso, "I", "S")
            .Codigo_Documento = 6 'Val(cboDocumento.Value)
            .Numero = txtNumero.Text.Trim
            .Codigo_CtaCte = 1 'Val(cboCuenta.BoundText)
            .Codigo_Tip = 8 'Amortización de cuenta x Pagar
            .Codigo_Persona = vCodigo_Per1

            .fecha = xFecha
            .Moneda = cboMoneda.Value
            .Importe = CSng(lblTotal_Cobrar.Text)
            If txtTipoCambio.Visible Then
              .Cambio = Single.Parse(txtTipoCambio.Text)
            Else
              .Cambio = 0
            End If
            .Observacion = (txtGlosaCC.Text.Trim)
            .codigo_ref = 0
            .Codigo_Usuario = GestionSeguridadManager.idUsuario
            .Usuario = GestionSeguridadManager.sUsuario
            .caja = My.Computer.Name
            .Cerrado = False
            .Estado = True

            .Referencia_Exterior = ""

            .Codigo1_RefExt = 0
            .Codigo2_RefExt = 0
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
            .Importe_Pago = Single.Parse(lblTotalCobrar.Text)
            .Vuelto = Single.Parse(0)
            .Centro_Costo = ""
            .Sobra = 0
            vCodigo = movimiento_bancarioManager.Grabar(ObjMB, vArrFP, vArrCuentas, vArrRB)

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

      Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(vCodigo), pCodigo_Alm, cboDocumento.Value, "XCOBRAR", False, False)
      'If ClsImpresiones.Imprimir_Recibo_Interno_pc(vCodigo, vFormato, vImpresora, vSerieTk, vCopias) Then 'If ClsImpresiones.Imprimir_Rpt(xIdRet) Then
      '    'If operacionManager.Incrementar_Impresiones(xIdRet) Then
      '    '    Cerrar = True
      '    'End If
      'End If
    End If

  End Sub


  Private Sub cboDetalle_Pago_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDetalle_Pago.InitializeLayout
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Width = cboDetalle_Pago.Width
  End Sub

  Private Sub cboDocumento_ValueChanged(sender As Object, e As EventArgs) Handles cboDocumento.ValueChanged
    txtNumero.Text = "0"
    If Not cboDocumento.DataSource Is Nothing Then
      If Not cboDocumento.Text = "" Then
        txtNumero.Text = (cboDocumento.ActiveRow.Cells("correlativo").Value)
        lblPeriodo.Text = cboDocumento.ActiveRow.Cells("serie").Value
      End If
    End If
  End Sub

  Private Sub cboMoneda_ValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.ValueChanged
    txtTipoCambio.Visible = (cboMoneda.Value = "DO")
  End Sub

  Public Function ObtenerSubCtas(ByVal vSubCtaCode As String) As Boolean
    Dim Filter As String = "subctacode = '" & vSubCtaCode & "'"
    Dim pDtPlan As New DataTable
    Dim dv As DataView
    pDtPlan = GestionTablas.dtplan
    If Not pDtPlan Is Nothing Then
      dv = New DataView(pDtCtaCte, Filter, "", DataViewRowState.CurrentRows)
      If dv.Count > 0 Then 'Sino hay datos
        cboCtaCteB.DataSource = dv
      End If
    Else
      cboCtaCteB.Enabled = False
      lblNombreCtaCteB.Text = ""
    End If

  End Function

  Private Sub cboCuentaB_Validated(sender As Object, e As EventArgs) Handles cboCuentaB.Validated
    If cboCuentaB.ActiveRow Is Nothing Then
      If Not cboCuentaB.Text = "" Then
        cboCuentaB.Focus()
        lblNombreCtaB.Text = ""
      End If
    Else
      Dim vCtaCde As String = ""
      vCtaCde = cboCuentaB.ActiveRow.Cells("subctacode").Value
      lblNombreCtaB.Text = cboCuentaB.ActiveRow.Cells("nombre").Value
      cboCtaCteB.DataSource = Nothing
      If Not vCtaCde.Trim = "" Then
        If ObtenerSubCtas(vCtaCde) Then

        End If

      End If
    End If
  End Sub

  Private Sub cboCtaCteB_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboCtaCteB.InitializeLayout
    With cboCtaCteB.DisplayLayout.Bands(0)
      '.Columns(0).Hidden = True
      .Columns("ctacte").Width = cboCtaCteB.Width
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      .Columns(3).Hidden = True

    End With
  End Sub

  Private Sub cboCtaCteB_Validated(sender As Object, e As EventArgs) Handles cboCtaCteB.Validated
    If cboCtaCteB.ActiveRow Is Nothing Then
      If Not cboCtaCteB.Text = "" Then
        cboCtaCteB.Focus()
        lblNombreCtaCteB.Text = ""
      End If
    Else
      lblNombreCtaCteB.Text = cboCtaCteB.ActiveRow.Cells("nombre").Value
    End If
  End Sub

  Private Sub cboCentro_Costo_Pago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboCentro_Costo_Pago.InitializeLayout
    With cboCentro_Costo_Pago.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboCentro_Costo_Pago.Width

    End With
  End Sub
End Class