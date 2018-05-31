

Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmNota_Credito_Colportor

  Public pCodigo As Long, pDevolucionId As Long, pCodigo_Alm As Integer, pAlmacen As String
  Public pMoneda As String, pCambio As Single, pReferencia As String = "", pCodigo_Ref1 As Long
  Public pTipoPer As String, pCodigo_Per As Long, pCodigo_Asis As Long, pDireccion As String, pApe_Pat As String, pApe_Mat As String, pPersona As String
  Public dtVenta As DataTable
  Public dtDocumento As DataTable, dtDoc_Dzmo As DataTable, dtSaldos As DataTable, dtCabecera As DataTable
  Public vFormato As String, vImpresora As String, vSerieTk As String, vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long
  Public vFormatoD As String, vImpresoraD As String, vSerieTkD As String, vImprimirD As Boolean, vCopiasD As Integer
  Public vCodigo_DocD As Integer, vCodigo_SerieD As Long, vSerieD As String, vNumeroD As Long
  Public vOkR As Boolean, zReniec As Boolean, pTipo As Integer, pDevolucionWeb As Boolean

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtDoc_Dzmo = New DataTable
    dtSaldos = New DataTable
    dtCabecera = New DataTable
    dtVenta = New DataTable

    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = My.Computer.Name
    Try
      If pDevolucionWeb Then
        Call cursoresManager.Datos_Ventana_Web_NC_Colp(pCodigo_Alm, pCodigo_Per, pCodigo, pDevolucionId, vCodigo_Usu,
                                                        vCaja, dtDocumento, dtDoc_Dzmo, dtSaldos, dtCabecera, dtVenta)
      Else
        Call cursoresManager.Datos_Ventana_NC_Colp(pCodigo_Alm, pCodigo_Per, pCodigo, vCodigo_Usu,
                                                    vCaja, dtDocumento, dtDoc_Dzmo, dtSaldos, dtCabecera, dtVenta)
      End If

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
      If pCodigo > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    If Not dtDoc_Dzmo Is Nothing Then
      If dtDoc_Dzmo.Rows.Count > 0 Then
        Dim objReader As DataRow
        'Dim dSerie As String = "", dNUmero As Long = 0
        objReader = dtDoc_Dzmo.Rows(0)

        vSerieD = objReader.Item("serie")
        vNumeroD = objReader.Item("correlativo")
        txtRecibo_Dzmo.Text = vSerieD & "-" & Format(vNumeroD, "00000000")

        vCodigo_DocD = objReader.Item("codigo")
        vFormatoD = objReader.Item("formato")
        vImpresoraD = objReader.Item("impresora")
        vSerieTkD = objReader.Item("serie_tk")
        vImprimirD = CBool(objReader.Item("imprimir"))
        vCopiasD = objReader.Item("copias")
        vCodigo_SerieD = objReader.Item("codigo_serie")
      End If
    End If

    If Not dtCabecera Is Nothing Then
      If dtCabecera.Rows.Count > 0 Then
        Dim objRc As DataRow
        'Dim dSerie As String = "", dNUmero As Long = 0
        objRc = dtCabecera.Rows(0)

        pCodigo_Per = objRc.Item("codigo_cli")
        TxtAnombreD.Text = objRc.Item("colportor")
        pCodigo_Asis = objRc.Item("codigo_ref1")
        txtAsistente.Text = objRc.Item("asistente")
        txtRucDni.Text = objRc.Item("dniruc")
        txtNroReferencia.Text = objRc.Item("doc_referencia")

        lblC_Costo.Text = objRc.Item("c_costo")
        txtNroCuenta.Text = objRc.Item("nrocuenta")
        pMoneda = objRc.Item("moneda")
        pCambio = objRc.Item("cambio")
        pReferencia = objRc.Item("referencia")
        pCodigo_Ref1 = objRc.Item("codigo_ref1")

      End If
    End If
    dgvDetalle_venta.DataSource = dtVenta
    dgvDetalle_Pagos.DataSource = dtSaldos
    picAjax.Visible = False
    Call CalcularTotales()
    'BtnGrabar.Visible = True
  End Sub

  Private Sub Datos_Colportor()
    Dim ObjPe As New persona
    Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

    ObjPe = personaManager.Datos_Persona_Colportaje("N", pCodigo_Alm, pCodigo_Per, "")

    If Not ObjPe Is Nothing Then
      'pCodigo_Per = Long.Parse(ObjP.personaid)
      vApe_Pat = ObjPe.ape_pat
      vApe_Mat = ObjPe.ape_mat
      vNombre = ObjPe.nombre
      TxtAnombreD.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
      lblC_Costo.Text = ObjPe.nrocuenta & ""
      pCodigo_Asis = Long.Parse(ObjPe.codio_Asis)
      vOkR = True
      Call Datos_Asistente()
      'lblNombreCta.Text = ObjPe.nrocuenta & ""
      'txtBuscar.Focus()
    Else
      TxtAnombreD.Text = ""
      lblC_Costo.Text = ""
      vOkR = False
    End If
  End Sub

  Private Sub Datos_Asistente()
    Dim ObjPe As New persona
    Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

    ObjPe = personaManager.Datos_Persona_Basic("N", "", pCodigo_Asis)

    If Not ObjPe Is Nothing Then

      vApe_Pat = ObjPe.ape_pat
      vApe_Mat = ObjPe.ape_mat
      vNombre = ObjPe.nombre
      txtAsistente.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
      txtNroCuenta.Text = ObjPe.nrocuenta & ""
    Else
      txtAsistente.Text = ""
      txtNroCuenta.Text = ""
    End If
  End Sub

  Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
    If e.KeyCode = Keys.Enter Then
      '    Dim ObjPe As New persona
      '    Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

      '    ObjPe = personaManager.Datos_Persona_Basic(pCodigo_Alm, "N", txtRucDni.Text)

      '    If Not ObjPe Is Nothing Then
      '        pCodigo_Per = Long.Parse(ObjP.personaid)
      '        vApe_Pat = ObjPe.ape_pat
      '        vApe_Mat = ObjPe.ape_mat
      '        vNombre = ObjPe.nombre
      '        TxtAnombreD.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
      '        'lblC_Costo.Text = ObjPe.nrocuenta & ""
      '        Call Datos_Colportor()
      '        'lblNombreCta.Text = ObjPe.nrocuenta & ""
      txtBuscar.Focus()
      '    Else
      '        TxtAnombreD.Text = ""
      '        txtRucDni.Focus()
      '    End If
    End If
  End Sub

  Private Sub Nueva_Venta()
    Dim vF As Date = Now.Date
    If IsDate(txtFecha.Value) Then
      vF = txtFecha.Value
    End If
    '       pMoneda = ""
    '       pCambio = 0
    '       pCodigo_Ref = 0
    '       pTipoPer = ""
    '       pCodigo_Per = 0
    'pCodigo_Asis =0, pDireccion  = "", pApe_Pat  = "", pApe_Mat  = "", pPersona  = ""
    '       Private dtVenta As DataTable
    '        dtDocumento As DataTable, dtDoc_Dzmo As DataTable, dtSaldos As DataTable, dtCabecera As DataTable
    '        vFormato  = "", vImpresora  = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0
    '        vFormatoD  = "", vImpresoraD  = "", vSerieTkD = "", vImprimirD As Boolean, vCopiasD As Integer
    '        vCodigo_DocD As Integer = 0, vCodigo_SerieD As Long = 0, vSerieD  = "", vNumeroD As Long = 0
    '        vOkR As Boolean, zReniec As Boolean, pTipo As Integer = 0
    'Call Llenar_Combos()
    'Call formatear_grid()
    'lblClientePor.Tag = 1
    lblBuscarpor.Tag = 1
    'Call Habilitar_RUC_DNI(1)
    'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small

    txtFecha.Value = Now.Date
    'txtvencimiento.Text = vF.AddDays(15)

    picAjax.Visible = True

    lblAlmacen.Tag = pCodigo_Alm
    lblAlmacen.Text = pAlmacen

    'dtVenta = ClsGridDetallePagos.Crear_Grid_Venta("venta")
    'dgvDetalle_venta.DataSource = dtVenta
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
    'Call CalcularTotales()
    txtRucDni.Focus()
  End Sub

  Private Sub FrmNota_Credito_Colportor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      If ugbDetalle_Pago.Visible = True Then
        ugbDetalle_Pago.Visible = False
        txtBuscar.Focus()
        'ElseIf gpProductos.Visible = True Then
        '    gpProductos.Visible = False
        '    txtBuscar.Focus()
      Else
        Me.Close()
      End If
    End If
  End Sub

  Private Sub FrmNota_Credito_Colportor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    txtRucDni.Text = ""
    TxtAnombreD.Text = ""
    lblC_Costo.Text = ""

    txtAsistente.Text = ""
    txtNroCuenta.Text = ""
    txtRecibo_Dzmo.Text = ""

    Call Nueva_Venta()

  End Sub

  Private Sub dgvDetalle_venta_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalle_venta.AfterCellUpdate
    If e.Cell.Column.Index = 2 Then
      Dim vCantidad As Single = 0, vPrecio As Single = 0, vDscto As Single = 0, vImporte As Single = 0
      vCantidad = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("cantidad").Value)
      vPrecio = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("precio").Value)
      vDscto = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("dcto").Value)
      vImporte = vCantidad * vPrecio - vDscto
      dgvDetalle_venta.ActiveRow.Cells("subtotal").Value = FormatNumber(vImporte, 2, TriState.False, TriState.False)

      Call CalcularTotales()
    End If
  End Sub

  Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
    Call CalcularTotales()
  End Sub

  Private Sub dgvDetalle_venta_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles dgvDetalle_venta.BeforeCellUpdate
    If e.Cell.Column.Index = 2 Then 'Cantidad
      If e.Cell.Text.Trim = "" Then
        MsgBox("La Cantidad debe ser Mayor y/o Igual a Cero(0)", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
      If Not CSng(e.Cell.Text) >= 0 Then
        MsgBox("La Cantidad debe ser Mayor y/o Igual a Cero(0)", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If
      If CSng(e.Cell.Text) > Single.Parse(dgvDetalle_venta.ActiveRow.Cells("stock").Value) Then
        MsgBox("La Cantidad no debe ser mayor al Stock", MsgBoxStyle.Exclamation, "AVISO")
        e.Cell.CancelUpdate()
        e.Cancel = True
        Exit Sub
      End If

    End If
  End Sub

  Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
    With dgvDetalle_venta.DisplayLayout.Bands(0)
      .Columns("id").Hidden = True
      .Columns("id").CellActivation = Activation.NoEdit
      .Columns("stock").Width = 40
      .Columns("stock").CellActivation = Activation.NoEdit
      .Columns("stock").CellAppearance.TextHAlign = HAlign.Center
      .Columns("cantidad").Width = 60
      .Columns("cantidad").Header.Caption = "Cant"
      .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
      .Columns("cantidad").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("producto").Width = 335
      .Columns("producto").CellActivation = Activation.NoEdit
      .Columns("afecto_igv").Header.Caption = "IGV"
      .Columns("afecto_igv").Width = 40
      .Columns("afecto_igv").CellAppearance.TextHAlign = HAlign.Center
      .Columns("afecto_igv").CellActivation = Activation.NoEdit
      .Columns("afecto_dzmo").Header.Caption = "DZMO"
      .Columns("afecto_dzmo").Width = 40
      .Columns("afecto_dzmo").CellAppearance.TextHAlign = HAlign.Center
      .Columns("afecto_dzmo").CellActivation = Activation.NoEdit
      .Columns("precio").Header.Caption = "Precio"
      .Columns("precio").Width = 70
      .Columns("precio").CellAppearance.TextHAlign = HAlign.Right
      .Columns("precio").CellActivation = Activation.NoEdit
      .Columns("subtotal").Header.Caption = "Sub Total"
      .Columns("subtotal").Width = 80
      .Columns("subtotal").CellAppearance.TextHAlign = HAlign.Right
      .Columns("subtotal").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("subtotal").CellActivation = Activation.NoEdit
      .Columns("dcto").Hidden = True
      .Columns("item").Hidden = True
    End With
  End Sub

  Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
    If Not cboDocumento.DataSource Is Nothing Then

      txtSerie.Text = cboDocumento.ActiveRow.Cells("serie").Value
      txtNumero.Text = Format((cboDocumento.ActiveRow.Cells("correlativo").Value), "00000000")
      vFormato = cboDocumento.ActiveRow.Cells("formato").Value
      vImpresora = cboDocumento.ActiveRow.Cells("impresora").Value
      vSerieTk = cboDocumento.ActiveRow.Cells("serie_tk").Value
      vImprimir = CBool(cboDocumento.ActiveRow.Cells("imprimir").Value)
      vCopias = cboDocumento.ActiveRow.Cells("copias").Value
      vCodigo_Serie = cboDocumento.ActiveRow.Cells("codigo_serie").Value
    End If
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

  Public Function Existe_Item(ByVal dtGrid As DataTable, ByVal vCodigo As Long) As Boolean
    Dim Filter As String = "id = " & vCodigo
    Dim drArr() As DataRow
    If Not dtGrid Is Nothing Then
      drArr = dtGrid.Select(Filter, Nothing, DataViewRowState.CurrentRows)
      Existe_Item = drArr.Length > 0
    End If

    drArr = Nothing
  End Function

  Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single,
                                       ByVal vPrecio As Single, ByVal vDescuento As Single, ByVal vComision As Single,
                                       ByVal vAfecto_IGV As Boolean, ByVal vAfecto_Dzmo As Boolean) As Boolean
    Try
      Dim NwRow As DataRow

      NwRow = dtVenta.NewRow
      NwRow.Item("id") = vCodigo
      NwRow.Item("cantidad") = vCantidad
      NwRow.Item("producto") = vNombre_Producto
      NwRow.Item("afecto_igv") = vAfecto_IGV
      NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
      NwRow.Item("precio") = vPrecio
      NwRow.Item("subtotal") = vCantidad * vPrecio - vDescuento
      NwRow.Item("dcto") = vDescuento
      NwRow.Item("item") = 0
      dtVenta.Rows.Add(NwRow)
      Call CalcularTotales()
      Return True

    Catch ex As Exception
      Return False
    End Try

  End Function

  Public Function CalcularTotales() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vImporte_IGV As Single = 0, vImporte As Single = 0
    Dim vPorc_Dzmo As Single = 0, Total_Dzmo As Single = 0
    Dim vIGV As Single = 0, miIGV As Single = 0
    CalcularTotales = False
    miIGV = Configuracion.pIGV
    vPorc_Dzmo = Configuracion.pDZMO

    Try
      DtTot = dtVenta

      For Each Drs In DtTot.Rows
        If Boolean.Parse(Drs("afecto_igv")) Then
          vImporte_IGV = vImporte_IGV + Single.Parse(Drs("subtotal").ToString)
        End If
        If CBool(Drs("afecto_dzmo")) Then
          Total_Dzmo = Total_Dzmo + (Single.Parse(Drs("subtotal").ToString) * vPorc_Dzmo / 100)
        End If

        vImporte = vImporte + Single.Parse(Drs("subtotal").ToString)

      Next Drs

      vIGV = FormatNumber((vImporte_IGV * miIGV / (100 + miIGV)), 2, TriState.False, TriState.False)

      lblIGV.Text = vIGV

      lblSubTotal.Text = FormatNumber(vImporte - vIGV, 2, TriState.False, TriState.False)
      Me.lblTotalDoc.Text = FormatNumber(vImporte + Total_Dzmo, 2, TriState.False, TriState.False)
      Me.lblTotalDoc2.Text = FormatNumber(vImporte + Total_Dzmo, 2, TriState.False, TriState.False)
      lblDZMO.Text = FormatNumber(Total_Dzmo, 2, TriState.False, TriState.False)
      'Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
      Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vImporte + Total_Dzmo)
      CalcularTotales = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    If cboDocumento.Text = "" Then
      valido = False
      ErrorProvider1.SetError(cboDocumento, "Debe Seleccionar un Documento Primero")
      camposConError.Add("DOCUMENTO")
    Else
      ErrorProvider1.SetError(cboDocumento, Nothing)
    End If

    If Trim(txtSerie.Text) = "" Or vCodigo_Serie = 0 Then
      valido = False
      ErrorProvider1.SetError(txtSerie, "Falta Ingresar Serie")
      camposConError.Add("SERIE")
    Else
      ErrorProvider1.SetError(txtSerie, Nothing)
    End If

    If Trim(txtNumero.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtNumero, "Falta Ingresar Nro Documento")
      camposConError.Add("NUMERO")
    Else
      ErrorProvider1.SetError(txtNumero, Nothing)
    End If

    If txtRecibo_Dzmo.Text = "" Or vCodigo_SerieD = 0 Then
      valido = False
      ErrorProvider1.SetError(txtRecibo_Dzmo, "Falta Ingresar Nro RECIBO DIEZMO")
      camposConError.Add("DZMO")
    Else
      ErrorProvider1.SetError(txtRecibo_Dzmo, Nothing)
    End If

    If Not IsDate(txtFecha.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFecha, "Falta Ingresar fecha")
      camposConError.Add("FECHA")
    Else
      ErrorProvider1.SetError(txtFecha, Nothing)
    End If

    If txtNroReferencia.Text = "" Then
      valido = False
      ErrorProvider1.SetError(txtNroReferencia, "No hay documento de referencia")
      camposConError.Add("REFERENCIA")
    Else
      ErrorProvider1.SetError(txtNroReferencia, Nothing)
    End If

    If vOkR = False And (lblClientePor.Tag = 1 Or lblClientePor.Tag = 2) Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Colportor")
      camposConError.Add("RUC")
    Else
      ErrorProvider1.SetError(txtRucDni, Nothing)
    End If

    If lblC_Costo.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblC_Costo, "Falta Ingresar Centro Costo")
      camposConError.Add("CCOSTO")
    Else
      ErrorProvider1.SetError(lblC_Costo, Nothing)
    End If

    If (txtAsistente.Text = "") Then
      valido = False
      ErrorProvider1.SetError(txtAsistente, "Falta Ingresar Nombre Asistente")
      camposConError.Add("ASISTENTE")
    Else
      ErrorProvider1.SetError(txtAsistente, Nothing)
    End If

    If (txtNroCuenta.Text = "") Then
      valido = False
      ErrorProvider1.SetError(txtNroCuenta, "Falta Ingresar nro Cuenta")
      camposConError.Add("NROCUENTA")
    Else
      ErrorProvider1.SetError(txtNroCuenta, Nothing)
    End If

    If Not CSng(lblTotalDoc.Text) > 0 Then
      valido = False
      ErrorProvider1.SetError(lblTotalDoc, "El Monto debe ser mayor a cero (0)")
      camposConError.Add("TOTALDOC")
    Else
      ErrorProvider1.SetError(lblTotalDoc, Nothing)
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

  Private Function GrabarRegistroDoc() As Boolean

    Dim objV As New venta
    Dim dgvRw As UltraGridRow
    Dim FEmi, FVence As String, vArray As String = "", vArrFP As String = "", myArr_CxC As String, ok, xIdProv As Long
    Dim xMISC, xMIGV As Single, vTiene
    Dim xMiDZMP As Single, vNroCuenta As String = ""
    Dim vNow As String = "", vComision As Single = 0, vLote As Long = 0
    Dim vSubTotal As Single = 0, vTotal As Single = 0, vPaga As Single = 0, vVuelto As Single = 0
    Dim vDZMO As Single = 0
    FEmi = ""
    FVence = ""

    Try

      FEmi = LibreriasFormularios.Formato_Fecha(txtFecha.Text)

      FVence = FEmi

      vNow = LibreriasFormularios.Formato_Fecha(Now.Date)

      xIdProv = 0
      xMISC = 0
      xMIGV = Configuracion.pIGV
      xMiDZMP = Configuracion.pDZMO
      vDZMO = Single.Parse(lblDZMO.Text)
      vTotal = (Single.Parse(lblTotalDoc.Text))
      vSubTotal = (Single.Parse(lblSubTotal.Text))
      If Not pCodigo > 0 And Not pCodigo_Ref1 > 0 Then
        MessageBox.Show("No tiene documento de referencia, vuelva a intentarlo", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Function
      End If
      With objV
        '' If pCodigo > 0 Then
        '.ventaid = pCodigo
        'Else
        .ventaid = -1
        'End If

        .numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim) & ""
        .documentoid = cboDocumento.Value
        .almacenid = pCodigo_Alm
        .clienteid = pCodigo_Per
        .nombre_cli = "" 'TxtAnombreD.Text
        .RUC = "" 'txtRucDni.Text.Trim
        .fecha = FEmi.Trim
        .moneda = pMoneda
        .condicion = "CREDITO"
        .vta_bruta = Single.Parse(vSubTotal) 'Single.Parse(lblSubTotal.Text)
        .descuento = 0
        .igv = Single.Parse(lblIGV.Text)
        .vta_total = Single.Parse(vTotal)


        .cambio = pCambio

        .usuarioid = GestionSeguridadManager.idUsuario
        .caja = My.Computer.Name
        .estado = True
        .observacion = txtNroReferencia.Text
        .cerrado = True
        .incluye_igv = True
        .descontar_stock = True
        .vendedorid = GestionSeguridadManager.idUsuario

        .signo = "-"
        .opcion = 1
        .valor_igv = xMIGV

        .centro_costos = lblC_Costo.Text

        .referencia = pReferencia '"BCC" 'Boleteo Credito Colportaje
        .codigo_ref = pCodigo
        .codigo_ref1 = pCodigo_Ref1
        .codigo_ref2 = pDevolucionId

        vArray = ""
        vTiene = False
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvDetalle_venta.Rows
          If dgvRw.Band.Index = 0 Then
            If Single.Parse(dgvRw.Cells("stock").Value) < Single.Parse(dgvRw.Cells("cantidad").Value) Then
              MessageBox.Show("Hay cantidades que superan al stock, VERIFICAR")
              Exit Function
            End If
            If Single.Parse(dgvRw.Cells("cantidad").Value) > 0 Then
              vTiene = True

              vArray = vArray & "['" & Str(dgvRw.Cells("id").Value).Trim & "', '" &
                                       Str(dgvRw.Cells("cantidad").Value).Trim & "','" &
                                       Str(dgvRw.Cells("precio").Value).Trim & "','" &
                                       Str(0).Trim & "','" &
                                       Str(0).Trim & "','" &
                                       Str(0).Trim & "','" &
                                       Str(vComision).Trim & "','" &
                                       IIf(CBool(dgvRw.Cells("afecto_igv").Value), "1", "0") & "','" &
                                       IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), "1", "0") & "','" &
                                       ("0") & "'],"

            End If

          End If
        Next
        If vTiene Then
          vArray = Mid(vArray, 1, Len(vArray) - 1)
          vArray = "array[" & vArray & "]"
        Else
          vArray = "null"
        End If
        vArrFP = ""
        vTiene = True

        vArrFP = vArrFP & "['" & Trim(Str(99)) & "', '" & Trim(Str(lblTotal_Cobrar.Text)) & "','" & Trim(Str(pCambio)) & "','" & Trim(pMoneda) & "','" & Trim("Pago con NC:" & txtNumero.Text) & "'],"

        If vTiene Then
          vArrFP = Mid(vArrFP, 1, Len(vArrFP) - 1)
          vArrFP = "array[" & vArrFP & "]"
        Else
          vArrFP = "null"
        End If

        .Vencimiento = FVence

        myArr_CxC = ""
        vTiene = False
        For Each dgvRw In Me.dgvDetalle_Pagos.Rows
          If dgvRw.Band.Index = 0 Then
            If Single.Parse(dgvRw.Cells("paga").Value) > 0 Then
              vTiene = True
              myArr_CxC = myArr_CxC & "['" & Trim(Str(0)) & "', '" &
                                           Trim(Str(dgvRw.Cells("codigo").Value)) & "','" &
                                           Trim(Str(dgvRw.Cells("paga").Value)) & "'],"
            End If

          End If
        Next

        If vTiene Then
          myArr_CxC = Mid(myArr_CxC, 1, Len(myArr_CxC) - 1)
          myArr_CxC = "array[" & myArr_CxC & "]"
        Else
          myArr_CxC = "null"
        End If

      End With
      vNroCuenta = txtNroCuenta.Text.Trim

      ok = ventaManager.Agregar(ok, objV, vArray, vArrFP, vPaga, vVuelto, vNroCuenta, vCodigo_Serie, vCodigo_SerieD,
                                vCodigo_DocD, txtRecibo_Dzmo.Text.Trim, vDZMO, myArr_CxC)

      If Not ok > 0 Then
        GrabarRegistroDoc = False
        Exit Function
      Else
        Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, cboDocumento.Value)

        Call ClsImpresiones.Imprimir_Rpt_DZMO(Long.Parse(ok), pCodigo_Alm, vCodigo_DocD, vFormatoD, vSerieTkD, vCopiasD, vImpresoraD)
        GrabarRegistroDoc = True
      End If


      objV = Nothing

    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub tsGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
    If ValidarDatos() Then
      ugbDetalle_Pago.Visible = True

      Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
      Me.txtPaga.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
      lblSaldo.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
      lblson.Text = Me.lblEnLetras.Text

    End If
  End Sub

  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    If Single.Parse(lblSaldo.Text) <= 0.05 Then
      If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        If GrabarRegistroDoc() Then
          Me.Close()

        End If
      End If
    Else
      MessageBox.Show("El saldo debe ser igual a Cero", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

  Private Sub Calcular_Totales_Pago()
    Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
    dtDgv = dgvDetalle_Pagos
    Dim vPaga As Single = 0
    Dim vTotal As Single = 0

    For Each dgvRw In dtDgv.Rows
      If dgvRw.Band.Index = 0 Then
        vPaga += dgvRw.Cells("paga").Value
      End If
    Next
    vTotal = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
    Me.txtPaga.Text = FormatNumber(vPaga, 2, TriState.True, , TriState.False)
    Me.lblSaldo.Text = FormatNumber(vTotal - vPaga, 2, TriState.True, , TriState.False)
    Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vPaga)
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

  Private Sub dgvDetalle_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle_venta.KeyDown
    If e.KeyValue = Keys.Up Or e.KeyValue = Keys.Down Or
            e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then

      Call LibreriasFormularios.Navy_Cells_uGrid(sender, e)

    End If
  End Sub

  Private Sub dgvDetalle_venta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dgvDetalle_venta.Validating
    dgvDetalle_venta.UpdateData()
  End Sub

End Class