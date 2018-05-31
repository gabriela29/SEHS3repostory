
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmBoleteo_Bloque

  Public pCodigo As Long, pCodigo_Asis As Long, pCodigo_Almacen As Integer, pAlmacen As String
  Public pTipoPer As String = "", pCodigo_Per As Long
  Public pRaz_Social As String = "", pDireccion As String = "", pDireccionId As Long = 0
  Public pApe_Pat As String = "", pApe_Mat As String = "", pNombre As String = "", pDNI As String = "", pRUC As String = ""

  Public dtDocumento As DataTable, dtDzmo As DataTable, dtForma_Pago As DataTable
  Public vCodigo_Doc As Integer, vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0
  Public vOkR As Boolean, zReniec As Boolean

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtForma_Pago = New DataTable
    dtDzmo = New DataTable
    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = My.Computer.Name
    Try
      Call cursoresManager.Datos_Ventana_venta(pCodigo_Almacen, vCodigo_Usu,
                                                  vCaja, "BLOQUE", dtDocumento, dtDzmo, dtForma_Pago)

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
      .ValueMember = "codigo_serie"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If pCodigo > 0 Then
        .Value = pCodigo
      Else
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      End If
    End With

    With Me.cboDetalle_Pago
      .DataSource = Nothing
      .DataSource = dtForma_Pago 'tipo_forma_pagoManager.GetList("%%")
      .DataBind()
      .ValueMember = "tipofpid"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      End If
    End With

    picAjax.Visible = False
    'BtnGrabar.Visible = True


  End Sub

  Private Sub Llenar_Combos()

    Dim dtC As DataTable, dtM As DataTable
    Dim x As Integer = 1
    Dim opcionesv(x), opciones(x) As String

    opcionesv(0) = 0
    opcionesv(1) = 1

    opciones(0) = "CONTADO"
    opciones(1) = "CREDITO"

    dtC = DosOpcionesManager.GetList("Condicion", opcionesv, opciones, x)

    With cboCondicion
      .DataSource = dtC
      .ValueMember = "opcionesv"
      .DisplayMember = "opciones"
      If .Rows.Count > 0 Then
        If pCodigo = 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End If
    End With

    Dim m As Integer = 1
    Dim opcionesvm(m), opcionesm(m) As String

    opcionesvm(0) = "NS"
    opcionesvm(1) = "DO"

    opcionesm(0) = "SOLES"
    opcionesm(1) = "DÓLARES"

    dtM = DosOpcionesManager.GetList("Moneda", opcionesvm, opcionesm, m)

    With cboMoneda
      .DataSource = dtM
      .ValueMember = "opcionesv"
      .DisplayMember = "opciones"
      If .Rows.Count > 0 Then
        If pCodigo = 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End If
    End With

  End Sub

  Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
    If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
    If e.KeyCode <> Keys.Down Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) + 1
    If e.KeyCode <> Keys.Up Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) - 1
    If Val(lblBuscarpor.Tag) = 0 Then lblBuscarpor.Tag = 3
    If Val(lblBuscarpor.Tag) = 4 Then lblBuscarpor.Tag = 1
    Select Case Val(lblBuscarpor.Tag)
      Case Is = 1
        lblBuscarpor.Text = "Nombre:"
        txtBuscar.MaxLength = 50
      Case Is = 2
        lblBuscarpor.Text = "Código:"
        txtBuscar.MaxLength = 10
      Case Is = 3
        lblBuscarpor.Text = "Barras:"
        txtBuscar.MaxLength = 50
    End Select
  End Sub

  Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then

      Dim dtProducto As New DataTable, vProdId As Long = 0


      If lblBuscarpor.Tag = 1 Then 'nombre
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Almacen, 0, pCodigo_Asis, 2, 50, txtBuscar.Text.Trim, 0, "")
      ElseIf lblBuscarpor.Tag = 2 Then 'codigo
        If IsNumeric(txtBuscar.Text) Then
          vProdId = Long.Parse(txtBuscar.Text)
        End If
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Almacen, pCodigo_Asis, 2, 50, "", vProdId, "")
      ElseIf lblBuscarpor.Tag = 3 Then 'barras
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Almacen, pCodigo_Asis, 2, 50, "", 0, txtBuscar.Text.Trim)
      End If

      dgvListado.DataSource = dtProducto
      dgvListado.Visible = True
      gpProductos.Visible = True
      If Not dtProducto Is Nothing Then
        If dtProducto.Rows.Count > 0 Then
          dgvListado.Focus()
        Else
          txtBuscar.Focus()
        End If
      Else
        txtBuscar.Focus()
      End If

    End If

  End Sub

  Private Sub Habilitar_RUC_DNI(ByVal vTipo As Integer)

    Select Case vTipo
      Case 1
        lblClientePor.Text = "DNI:"
        txtRucDni.MaxLength = 8
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        TxtAnombreD.ReadOnly = True
        TxtAnombreD.Text = "..."
        TxtAnombreD.Visible = True
        lblPersonaId.Text = 0
        txtDireccion.Text = ""
      Case 2
        lblClientePor.Text = "RUC:"
        txtRucDni.MaxLength = 11
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        TxtAnombreD.ReadOnly = True
        TxtAnombreD.Text = "..."
        TxtAnombreD.Visible = True
        lblPersonaId.Text = 0
        txtDireccion.Text = ""
      Case 3
        lblClientePor.Text = "OTRO:"
        txtRucDni.MaxLength = 11
        txtRucDni.Text = "00000000000"
        txtRucDni.ReadOnly = True
        TxtAnombreD.Text = "OTROS CLIENTES"
        TxtAnombreD.ReadOnly = False
        TxtAnombreD.Visible = True
        lblPersonaId.Text = 0
        txtDireccion.Text = ""

    End Select

  End Sub

  Public Sub Listado_clientes()
    Dim testDialog As New FrmConsulta_Personas()
    'testDialog.Cod_Cat = 4
    If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Dim objP As New persona
      pCodigo_Per = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)

      objP = personaManager.GetItem(pCodigo_Per)
      If Not objP Is Nothing Then
        'pCodigo_Per = objP.personaid
        pTipoPer = objP.tipo
        pDNI = objP.dni
        If pTipoPer = "N" Then
          pRUC = objP.pernat_ruc
        Else
          pRUC = objP.ruc
        End If
        pDireccion = objP.direccion
        pApe_Pat = objP.ape_pat
        pApe_Mat = objP.ape_mat
        pNombre = objP.nombre
        pRaz_Social = objP.raz_soc
        If lblClientePor.Tag = 1 Then
          txtRucDni.Text = pDNI
        Else
          txtRucDni.Text = pRUC
        End If

        If pTipoPer = "N" Then
          TxtAnombreD.Text = pApe_Pat & " " & pApe_Mat & " " & pNombre
          vOkR = True
        Else
          TxtAnombreD.Text = pRaz_Social
          vOkR = True
        End If
        lblPersonaId.Text = pCodigo_Per
        txtDireccion.Text = objP.direccion
        pDireccionId = 0
        txtBuscar.Focus()
      Else
        txtRucDni.Focus()
      End If
      objP = Nothing
    End If
    testDialog.Dispose()
  End Sub

  Public Sub Buscar_Cliente(ByVal vTipo As String, ByVal vNumero As String)
    Dim objP As New persona
    objP = LibreriasFormularios.Datos_Persona(vTipo, txtRucDni.Text)
    If Not objP Is Nothing Then
      pCodigo_Per = objP.personaid
      lblPersonaId.Text = 0
      pTipoPer = objP.tipo
      pDNI = objP.dni
      pRUC = objP.ruc
      pDireccion = objP.direccion
      pApe_Pat = objP.ape_pat
      pApe_Mat = objP.ape_mat
      pNombre = objP.nombre
      pRaz_Social = objP.raz_soc
      If pTipoPer = "N" Then
        TxtAnombreD.Text = pApe_Pat & " " & pApe_Mat & " " & pNombre
        vOkR = True
      Else
        txtRucDni.Text = pRUC
        TxtAnombreD.Text = pRaz_Social
        vOkR = True
      End If
      txtDireccion.Text = objP.direccion
      pDireccionId = 0
      lblPersonaId.Text = pCodigo_Per
      txtBuscar.Focus()
    Else
      txtRucDni.Focus()
    End If
    objP = Nothing
  End Sub

  Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
    If e.KeyCode = Keys.Enter Then

      Dim vDoc As String = ""
      vOkR = False
      pDNI = ""
      pRUC = ""
      pApe_Pat = ""
      pApe_Mat = ""
      pNombre = ""
      pRaz_Social = ""
      pDireccion = ""
      pTipoPer = ""
      pCodigo_Per = -1

      Select Case lblClientePor.Tag
        Case Is = 1
          vDoc = "DNI"
        Case Is = 2
          vDoc = "RUC"
        Case Is = 3
          vDoc = "RUC"
      End Select
      If txtRucDni.Text.Trim = "" Then
        Call Listado_clientes()
      Else
        Call Buscar_Cliente(vDoc, txtRucDni.Text)
      End If

    Else
      If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
      If e.KeyCode <> Keys.Down Then lblClientePor.Tag = Val(lblClientePor.Tag) + 1
      If e.KeyCode <> Keys.Up Then lblClientePor.Tag = Val(lblClientePor.Tag) - 1
      If Val(lblClientePor.Tag) = 0 Then lblClientePor.Tag = 3
      If Val(lblClientePor.Tag) = 4 Then lblClientePor.Tag = 1
      Select Case lblClientePor.Tag
        Case Is = 1
          Call Habilitar_RUC_DNI(1)
        Case Is = 2
          Call Habilitar_RUC_DNI(2)
        Case Is = 3
          Call Habilitar_RUC_DNI(3)
      End Select
    End If
    If vOkR Then
      txtBuscar.Focus()
    End If

  End Sub

  Private Sub cboCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCondicion.InitializeLayout
    cboCondicion.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboCondicion.DisplayLayout.Bands(0).Columns(1).Width = cboCondicion.Width
  End Sub

  Private Sub cboDetalle_Pago_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDetalle_Pago.InitializeLayout
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboDetalle_Pago.DisplayLayout.Bands(0).Columns(0).Width = cboDetalle_Pago.Width
  End Sub

  Private Sub txtPaga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaga.KeyDown
    If e.KeyCode = Keys.Enter Then
      txtGlosaDP.Focus()
    End If
  End Sub

  Private Sub txtPaga_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaga.ValueChanged
    If IsNumeric(txtPaga.Text) Then
      lblVuelto.Text = FormatNumber((CSng(IIf(IsNumeric(txtPaga.Text), txtPaga.Text, 0)) - CSng(IIf(IsNumeric(lblTotal_Cobrar.Text), lblTotal_Cobrar.Text, 0))), 2, TriState.True, , TriState.False)
    Else
      lblVuelto.Text = FormatNumber(0, 2, TriState.True, , TriState.False)
    End If
  End Sub

  Private Sub FrmVender_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    FrmConsignacion_Ctrl_Bloque.Actualizar()
  End Sub

  Private Sub FrmVender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F9 Then
      ugbDetalle_Pago.Visible = True
      Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
      Me.txtPaga.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
      lblson.Text = Me.lblEnLetras.Text
      Me.lblVuelto.Text = "0"
      txtPaga.Focus()
      'MessageBox.Show("Procesado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ElseIf e.KeyCode = Keys.Escape Then
      If ugbDetalle_Pago.Visible = True Then
        ugbDetalle_Pago.Visible = False
        txtBuscar.Focus()
      ElseIf gpProductos.Visible = True Then
        gpProductos.Visible = False
        txtBuscar.Focus()
      Else
        Me.Close()
      End If
    End If
  End Sub

  Private Sub FrmVender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call Nueva_Venta()
    Dim vTipoD As String = ""
    vTipoD = IIf(txtRucDni.Text.Trim.Length = 11, "RUC", "DNI")

    Dim objP As New persona
    objP = personaManager.Datos_Persona_Basic("", "", pCodigo_Per)
    If Not objP Is Nothing Then
      pTipoPer = objP.tipo
      If pTipoPer = "N" Then
        txtRucDni.Text = objP.dni
        TxtAnombreD.Text = objP.ape_pat & " " & objP.ape_mat & " " & objP.nombre
        txtDireccion.Text = objP.direccion
      Else
        txtRucDni.Text = objP.ruc
        TxtAnombreD.Text = objP.raz_soc
      End If
    End If
    objP = Nothing

  End Sub

  Private Sub Nueva_Venta()
    Call Llenar_Combos()
    Call formatear_grid()
    lblBuscarpor.Tag = 1
    lblClientePor.Tag = 1
    Call Habilitar_RUC_DNI(1)

    If Not pCodigo_Per > 0 Then
      txtRucDni.Text = ""
      pCodigo_Per = -1
    End If

    'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small

    txtFecha.Value = Now.Date

    picAjax.Visible = True

    lblAlmacen.Tag = pCodigo_Almacen
    lblAlmacen.Text = pAlmacen

    GestionTablas.dtTemp = ClsGridDetallePagos.Crear_Grid_VentaP("boleteo")
    dgvDetalle_venta.DataSource = GestionTablas.dtTemp
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
    Call CalcularTotales()
    txtRucDni.Focus()
  End Sub

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

    If Not IsDate(txtFecha.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFecha, "Falta Ingresar fecha")
      camposConError.Add("FECHA")
    Else
      ErrorProvider1.SetError(txtFecha, Nothing)
    End If
    If vCodigo_Doc = 1 Then
      If Not lblClientePor.Tag = 2 Or Not txtRucDni.TextLength = 11 Or vOkR = False Then
        valido = False
        ErrorProvider1.SetError(txtRucDni, "En una factura debe ingresar RUC")
        camposConError.Add("RUC")
      Else
        ErrorProvider1.SetError(txtRucDni, Nothing)
      End If
    End If
    If cboCondicion.Text = "CREDITO" And Not IsDate(txtvencimiento.Value) Then
      valido = False
      ErrorProvider1.SetError(txtvencimiento, "Falta Ingresar fecha Vencimiento")
      camposConError.Add("VENCIMIENTO")
    Else
      ErrorProvider1.SetError(txtvencimiento, Nothing)
    End If

    If cboCondicion.Text = "CREDITO" Then
      If txtFecha.Value > txtvencimiento.Value Then

        valido = False
        ErrorProvider1.SetError(txtvencimiento, "El Vencimiento no debe menor a la fecha de emisión")
        camposConError.Add("VENCIMIENTO")
      Else
        ErrorProvider1.SetError(txtvencimiento, Nothing)
      End If
    End If
    If Not vOkR And cboCondicion.Text = "CREDITO" Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Cliente por ser una venta al CRÉDITO")
      camposConError.Add("RUC")
    Else
      ErrorProvider1.SetError(txtRucDni, Nothing)
    End If

    If Not IsNumeric(txtCambio.Text) Then
      valido = False
      ErrorProvider1.SetError(txtCambio, "El tipo de cambio debe se numérico")
      camposConError.Add("TC")
    Else
      ErrorProvider1.SetError(txtCambio, Nothing)
    End If

    If cboMoneda.Value = "DO" And Single.Parse(txtCambio.Text) <= 0 Then
      valido = False
      ErrorProvider1.SetError(cboMoneda, "El tipo de cambio es Dólares y debe especificar el tipo de cambio")
      camposConError.Add("RUC")
    Else
      ErrorProvider1.SetError(cboMoneda, Nothing)
    End If
    If vOkR = False And (lblClientePor.Tag = 1 Or lblClientePor.Tag = 2) Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Proveedor")
      camposConError.Add("RUC")
    Else
      ErrorProvider1.SetError(txtRucDni, Nothing)
    End If


    If cboCondicion.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(cboCondicion, "Debe Seleccionar si la compra es el crédito o Contado")
      camposConError.Add("cboCondicion")
    Else
      ErrorProvider1.SetError(cboCondicion, Nothing)
    End If

    If cboCondicion.Text = "CONTADO" Then
      If cboDetalle_Pago.Text = "" Then
        valido = False
        ErrorProvider1.SetError(cboDetalle_Pago, "Debe Seleccionar la forma de pago")
        camposConError.Add("cboDetalle_Pago")
      Else
        ErrorProvider1.SetError(cboDetalle_Pago, Nothing)
      End If
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
    Dim FEmi, FVence As String, vArray As String = "", vArrFP As String = "", ok, xIdProv As Long
    Dim xMISC, xMIGV As Single, vTiene, vTienef As Boolean
    Dim vNow As String = "", vComision As Single = 0, vLote As Long = 0
    Dim vPaga As Single = 0, vVuelto As Single = 0
    FEmi = ""
    FVence = ""

    Try

      FEmi = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
      If txtvencimiento.Visible = True Then
        FVence = LibreriasFormularios.Formato_Fecha(txtvencimiento.Text)
      End If

      vNow = LibreriasFormularios.Formato_Fecha(Now.Date)

      xIdProv = 0
      xMISC = 0
      xMIGV = Configuracion.pIGV

      With objV
        If pCodigo > 0 Then
          .ventaid = pCodigo
        Else
          .ventaid = -1
        End If

        .numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim) & ""
        .documentoid = vCodigo_Doc
        .almacenid = pCodigo_Almacen
        .clienteid = pCodigo_Per
        .nombre_cli = ""

        Select Case lblClientePor.Tag
          Case Is = 1
            .DNI = txtRucDni.Text
          Case Is = 2
            .RUC = txtRucDni.Text
          Case Is = 3
            .RUC = txtRucDni.Text
            .nombre_cli = TxtAnombreD.Text
        End Select
        .fecha = FEmi.Trim
        .moneda = cboMoneda.Value
        .condicion = cboCondicion.Text.Trim
        .vta_bruta = Single.Parse(lblSubTotal.Text)
        .descuento = 0
        .igv = Single.Parse(lblIGV.Text)
        .vta_total = Single.Parse(lblTotalDoc2.Text)
        If cboMoneda.Value = "NS" Then
          .cambio = "0.000"
        Else
          .cambio = Single.Parse(txtCambio.Text)
        End If

        .usuarioid = GestionSeguridadManager.idUsuario
        .caja = My.Computer.Name
        .estado = True
        .observacion = txtGlosaDP.Text.Trim & ""
        .cerrado = True
        .incluye_igv = True
        .descontar_stock = True
        .vendedorid = GestionSeguridadManager.idUsuario
        If vCodigo_Doc = 11 Then
          .signo = "-"
          .opcion = 1
        Else
          .signo = "+"
          .opcion = 0
        End If


        .valor_igv = xMIGV
        If Not lblClientePor.Tag = 3 Then
          .Ape_Pat = pApe_Pat
          .Ape_Mat = pApe_Mat
          .Nombre = pNombre
          .Raz_Soc = pRaz_Social
          .Direccion_Cliente = pDireccion
          .Tipo_per = pTipoPer
        End If
        .DireccionId = pDireccionId

        .referencia = "BCD" 'Boleteo Credito Denominacional
        .codigo_ref1 = pCodigo_Asis
        vArray = ""
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvDetalle_venta.Rows
          If dgvRw.Band.Index = 0 Then
            vTiene = True

            vArray = vArray & "['" & Str(dgvRw.Cells("id").Value).Trim & "', '" &
                                     Str(dgvRw.Cells("cantidad").Value).Trim & "','" &
                                     Str(dgvRw.Cells("precio").Value).Trim & "','" &
                                     Str(dgvRw.Cells("tipodscto").Value).Trim & "','" &
                                     Str(dgvRw.Cells("xctajedscto").Value).Trim & "','" &
                                     Str(dgvRw.Cells("dcto").Value).Trim & "','" &
                                     Str(vComision).Trim & "','" &
                                     IIf(CBool(dgvRw.Cells("afecto_igv").Value), "1", "0") & "','" &
                                     ("0") & "','" &
                                     IIf(CBool(dgvRw.Cells("exonerada").Value), "1", "0") & "'],"
          End If
        Next
        If vTiene Then
          vArray = Mid(vArray, 1, Len(vArray) - 1)
          vArray = "array[" & vArray & "]"
        Else
          vArray = "null"
        End If
        vArrFP = "null"
        .Vencimiento = FVence
        If cboCondicion.Text = "CONTADO" Then
          vPaga = Single.Parse(txtPaga.Text)
          vVuelto = Single.Parse(lblVuelto.Text)
          vArrFP = ""
          If Not cboDetalle_Pago.Text = "" Then
            vTienef = True
            vArrFP = vArrFP & "['" & Trim(Str(cboDetalle_Pago.Value)) & "', '" & Trim(Str(Me.lblTotal_Cobrar.Text)) & "','" & Trim(Str(Me.txtCambio.Text)) & "','" & Trim(Me.cboMoneda.Value) & "','" & Trim("-") & "'],"
          End If
          If vTienef Then
            vArrFP = Mid(vArrFP, 1, Len(vArrFP) - 1)
            vArrFP = "array[" & vArrFP & "]"
          Else
            vArrFP = "null"
          End If
        End If
      End With
      Dim myArr_CxC As String = "null"
      ok = ventaManager.Agregar(0, objV, vArray, vArrFP, vPaga, vVuelto, txtNroCuenta.Text.Trim, vCodigo_Serie, 0, 0, "", 0, myArr_CxC)

      If Not ok > 0 Then
        GrabarRegistroDoc = False
        Exit Function
      Else
        If Not vCodigo_Doc = 4 Then
          Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Almacen, vCodigo_Doc)
        End If
      End If

      GrabarRegistroDoc = True
      objV = Nothing
    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    If ValidarDatos() Then
      If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        If GrabarRegistroDoc() Then
          Call Nueva_Venta()
          ugbDetalle_Pago.Visible = False
          txtBuscar.Focus()
        End If
      End If
    End If
  End Sub

  Private Sub tsGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
    ugbDetalle_Pago.Visible = True
    Me.tapaContado.Visible = False

    Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
    Me.txtPaga.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
    lblson.Text = Me.lblEnLetras.Text
    Me.lblVuelto.Text = "0"
    If cboCondicion.Text = "CREDITO" Then
      Me.tapaContado.Visible = True
      txtGlosaDP.Focus()
    Else
      txtPaga.Focus()
    End If

  End Sub

  Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
    If Not cboDocumento.DataSource Is Nothing Then
      vCodigo_Doc = cboDocumento.ActiveRow.Cells("documentoid").Value
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

  Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Hidden = True
      '.Columns(2).Hidden = True
      .Columns("documento").Width = cboDocumento.Width
      '.Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
      .Columns(8).Hidden = True
      .Columns("codigo_serie").Hidden = True
      .Columns("copias").Hidden = True
    End With
  End Sub

  Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
    Dim xNum As Long = 0
    If IsNumeric(txtNumero.Text) Then
      xNum = txtNumero.Text
      txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
    End If
  End Sub

  Private Sub dgvListado_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvListado.DoubleClickRow
    'Call dgvListado_KeyDown(e.Row.ro , 0)
  End Sub

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.Enter Then
      If dgvListado.Rows.Count > 0 Then
        Dim vCodigo As Long
        vCodigo = (dgvListado.ActiveRow.Cells(0).Value)

        If Val(dgvListado.ActiveRow.Cells(7).Value) < 1 Then
          MessageBox.Show("No hay stock suficiente para vender", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
          dgvListado.Focus()
          Exit Sub
        End If

        If Existe_Item(dgvDetalle_venta.DataSource, vCodigo) Then
          MsgBox("El producto ya esta registrado en el documento.", vbInformation, "Ventas")
          dgvListado.Focus()
          Exit Sub
        End If

      End If

    End If
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

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Width = 30
      .Columns(0).Header.Caption = "ID"
      .Columns(1).Width = 300
      .Columns(1).Header.Caption = "PRODUCTO"
      .Columns(2).Width = 100
      .Columns(2).Header.Caption = "FAMILIA"
      .Columns(3).Width = 80
      .Columns(3).CellAppearance.TextHAlign = HAlign.Right
      .Columns(3).Header.Caption = "PRECIO"
      .Columns(4).Hidden = True
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Width = 80
      .Columns(7).Header.Caption = "STOCK"
      .Columns(7).CellAppearance.TextHAlign = HAlign.Center
      .Columns(7).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(8).Hidden = True
      .Columns(9).Hidden = True
      .Columns(10).Hidden = True
    End With

  End Sub

  Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single,
                                          ByVal vPrecio As Single, ByVal vDescuento As Single, ByVal vComision As Single,
                                          ByVal vAfecto_IGV As Boolean, ByVal xNuevo As Boolean, ByVal vTipoDscto As Integer,
                                          ByVal vEsXctaje As Boolean, ByVal vExonerada As Boolean, ByVal vDscto As Single) As Boolean
    Try
      Dim NwRow As DataRow
      If xNuevo Then
        NwRow = GestionTablas.dtTemp.NewRow
        NwRow.Item("id") = vCodigo
        NwRow.Item("cantidad") = vCantidad
        NwRow.Item("producto") = vNombre_Producto
        NwRow.Item("afecto_igv") = vAfecto_IGV
        NwRow.Item("afecto_dzmo") = False
        NwRow.Item("precio") = vPrecio

        NwRow.Item("subtotal") = ((vCantidad * vPrecio) - (vCantidad * vDscto))
        NwRow.Item("dcto") = vCantidad * vDscto

        NwRow.Item("item") = 0
        NwRow.Item("tipodscto") = vTipoDscto
        NwRow.Item("xctajedscto") = IIf(vEsXctaje, vDescuento, 0)
        NwRow.Item("exonerada") = vExonerada
        GestionTablas.dtTemp.Rows.Add(NwRow)
      Else
        NwRow = GestionTablas.dtTemp.Rows.Find(vCodigo)
        NwRow.Item("id") = vCodigo
        NwRow.Item("cantidad") = vCantidad
        NwRow.Item("producto") = vNombre_Producto
        NwRow.Item("afecto_igv") = vAfecto_IGV
        NwRow.Item("afecto_dzmo") = False
        NwRow.Item("precio") = vPrecio

        NwRow.Item("subtotal") = ((vCantidad * vPrecio) - (vCantidad * vDscto))
        NwRow.Item("dcto") = vCantidad * vDscto

        NwRow.Item("item") = 0
        NwRow.Item("tipodscto") = vTipoDscto
        NwRow.Item("xctajedscto") = IIf(vEsXctaje, vDescuento, 0)
        NwRow.Item("exonerada") = vExonerada
        GestionTablas.dtTemp.AcceptChanges()
        GestionTablas.dtTemp.Select()
      End If
      Return True

    Catch ex As Exception
      MessageBox.Show(ex.Message, "AVISO")
      Return False
    End Try

  End Function

  Public Function CalcularTotales() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vImporte_IGV As Single = 0, vImporte As Single = 0
    Dim vIGV As Single = 0, miIGV As Single = 0
    CalcularTotales = False
    miIGV = Configuracion.pIGV
    Try
      DtTot = GestionTablas.dtTemp

      For Each Drs In DtTot.Rows
        If Boolean.Parse(Drs("afecto_igv")) Then
          vImporte_IGV = vImporte_IGV + Single.Parse(Drs("subtotal").ToString)
        End If
        vImporte = vImporte + Single.Parse(Drs("subtotal").ToString)

      Next Drs

      vIGV = FormatNumber((vImporte_IGV * miIGV / (100 + miIGV)), 2, TriState.False, TriState.False)

      lblIGV.Text = vIGV

      lblSubTotal.Text = FormatNumber(vImporte - vIGV, 2, TriState.False, TriState.False)
      Me.lblTotalDoc.Text = FormatNumber(vImporte, 2, TriState.False, TriState.False)
      Me.lblTotalDoc2.Text = FormatNumber(vImporte, 2, TriState.False, TriState.False)
      'Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
      Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vImporte)
      CalcularTotales = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
    Call CalcularTotales()
  End Sub


  Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
    With dgvDetalle_venta.DisplayLayout.Bands(0)
      .Columns("id").Width = 20
      .Columns("cantidad").Width = 60
      .Columns("cantidad").Header.Caption = "Cant"
      .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
      .Columns("producto").Width = 300
      .Columns("afecto_igv").Header.Caption = "IGV"
      .Columns("afecto_igv").Width = 40
      .Columns("afecto_igv").CellAppearance.TextHAlign = HAlign.Center
      .Columns("afecto_dzmo").Hidden = True
      .Columns("precio").Header.Caption = "Precio"
      .Columns("precio").Width = 80
      .Columns("precio").CellAppearance.TextHAlign = HAlign.Right
      .Columns("dcto").Header.Caption = "Dscto"
      .Columns("dcto").Width = 80
      .Columns("dcto").CellAppearance.TextHAlign = HAlign.Right
      .Columns("subtotal").Header.Caption = "Importe"
      .Columns("subtotal").Width = 100
      .Columns("subtotal").CellAppearance.TextHAlign = HAlign.Right
      .Columns("subtotal").CellAppearance.BackColor = Color.LemonChiffon

      .Columns("item").Hidden = True
      .Columns("tipodscto").Hidden = True
      .Columns("xctajedscto").Hidden = True
      .Columns("exonerada").Hidden = True
    End With
  End Sub


  Private Sub cboMoneda_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMoneda.InitializeLayout
    cboMoneda.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboMoneda.DisplayLayout.Bands(0).Columns(0).Width = cboMoneda.Width
  End Sub

  Private Sub cboCondicion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCondicion.ValueChanged
    Dim vF As Date = Now.Date
    If IsDate(txtFecha.Value) Then
      vF = txtFecha.Value
    End If


    If cboCondicion.Text = "CREDITO" Then
      txtvencimiento.Text = vF.AddDays(15)
      txtvencimiento.Visible = True
    Else
      txtvencimiento.Visible = False
    End If
  End Sub

  Private Sub txtRucDni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucDni.ValueChanged
    vOkR = False
  End Sub

  Private Sub cboDetalle_Pago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDetalle_Pago.KeyDown
    If e.KeyCode = Keys.Enter Then
      txtPaga.Focus()
    End If
  End Sub

  Private Sub txtGlosaDP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGlosaDP.KeyDown
    If e.KeyCode = Keys.Enter Then
      btnGrabar.Focus()
    End If
  End Sub

  Public Function ObtenerPlanCtaCond(ByVal xBusca As String, ByVal xTipo As Integer) As Boolean
    Dim oPCta As New plan_cuentas
    Dim dtp As New DataTable
    Dim drws As DataRow

    Try
      If xTipo = 7 Then
        dtp = plan_cuentasManager.GetRow(xBusca, "", 1)
      Else
        dtp = plan_cuentasManager.GetList("", xBusca, 1)
      End If
      If dtp.Rows.Count > 0 Then
        For Each drws In dtp.Rows
          'pCtaMstra = CStr(drws("CtaMaestra"))
          lblNombre_Cuenta.Text = CStr(drws("NombreCta"))
          Exit For
        Next drws
      End If
      dtp = Nothing
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Public Sub ListadoPlanCtasAll()
    Dim testDialogP As New FrmConsulta_Plan_Ctas

    If testDialogP.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      If testDialogP.dgvListado.Rows.Count > 0 Then
        If Not testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value Is DBNull.Value Then
          txtNroCuenta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(5).Value)
          lblNombre_Cuenta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
        End If
      End If
    End If
    testDialogP.Dispose()
  End Sub

  Private Sub txtNroCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroCuenta.KeyDown
    'If e.KeyCode = Keys.F1 Then
    '    If Not Trim(txtNroCuenta.Text) = "" Then Exit Sub
    '    Call ListadoPlanCtasAll()
    'End If
  End Sub

  Private Sub txtNroCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroCuenta.Validated
    'CtaMstra = ""
    'If Not Trim(txtNroCuenta.Text) = "" Then
    '    If IsNumeric(txtNroCuenta.Text) Then
    '        Call ObtenerPlanCtaCond(Trim(txtNroCuenta.Text), 7)
    '    Else
    '        Call ObtenerPlanCtaCond(Trim(txtNroCuenta.Text), 4)
    '    End If
    'Else
    '    'CtaMstra = ""
    '    lblNombre_Cuenta.Text = ""
    'End If
  End Sub

  Private Sub formatear_grid()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    Me.dgvListado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    'Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    Me.dgvListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
      Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
    End If

    Me.dgvListado.DisplayLayout.Appearance = Appearance1

    Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

    Appearance62.BackColor = Color.RoyalBlue   'System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance62.BackColor2 = Color.LightCyan   'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = System.Drawing.Color.Blue
    Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

    Appearance63.BackColor = System.Drawing.Color.SteelBlue
    Appearance63.BackColor2 = System.Drawing.Color.LightCyan
    Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
    Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

    Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default

    ''Appearance64.BackColor = System.Drawing.Color.White
    Appearance64.BackColor = System.Drawing.Color.LightSteelBlue
    'Appearance64.BackColor2 = System.Drawing.Color.White
    'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical        
    'Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid

    ''Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
    'Para seleccionar toda la Fila
    Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
    'Me.dgvListado.Name = "dgvListado"
    'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
    'Me.dgvListado.TabIndex = 1
    'Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
  End Sub

  Private Sub UltraLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel4.Click
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
  End Sub

  Private Sub txtNroCuenta_ValueChanged(sender As Object, e As EventArgs) Handles txtNroCuenta.ValueChanged

  End Sub

  Private Sub txtBuscar_ValueChanged(sender As Object, e As EventArgs) Handles txtBuscar.ValueChanged

  End Sub
End Class