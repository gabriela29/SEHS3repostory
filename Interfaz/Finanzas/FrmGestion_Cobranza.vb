
Imports System.ComponentModel
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmGestion_Cobranza
  Public ListadoDoc As DataTable
  Public _codigo As Long, pFicha As String

  Private Sub llenar_combos()
    Try
      Dim dtAsis As New DataTable
      dtAsis = Control_AsistenteManager.Leer_Asistentes_Cbo(GestionSeguridadManager.gUnidadId, 0, 0)

      With Me.cboAsistente
        .DataSource = dtAsis
        '.DataBind()
        .ValueMember = "codigo_asi"
        .DisplayMember = "asistente"
        .MinDropDownItems = 2
        .MaxDropDownItems = 8
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If

      End With

      With Me.cboAlmacen
        .DataSource = GestionTablas.dtFAlmacen
        '.DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If
      End With

      Dim dtL As DataTable
      Dim x As Integer = 6
      Dim opcionesv(x), opciones(x) As String
      opcionesv(0) = 1
      opcionesv(1) = 2
      opcionesv(2) = 3
      opcionesv(3) = 4
      opcionesv(4) = 5
      opcionesv(5) = 6

      opciones(0) = "Carta 1"
      opciones(1) = "Carta 2"
      opciones(2) = "Carta 3"
      opciones(3) = "Carta 4"
      opciones(4) = "Carta 5"
      opciones(5) = "Carta 6"

      dtL = DosOpcionesManager.GetList("cboCarta", opcionesv, opciones, x)

      With cboNumCarta
        .DataSource = Nothing
        .DataSource = dtL
        .Refresh()
        .ValueMember = "opcionesv"
        .DisplayMember = "opciones"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If
      End With

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Almacén"
      .Columns(1).Width = cboAlmacen.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
    If cboAlmacen.ActiveRow Is Nothing Then
      If Not cboAlmacen.Text = "" Then
        cboAlmacen.Focus()
      End If
    End If
    _codigo = 0
  End Sub

  Private Sub FrmGestion_Cobranza_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
    CboFecha2.Text = Now.Date
    Call LibreriasFormularios.formatear_grid_Panel(dgvListado)
    Call LibreriasFormularios.formatear_grid_Panel(dgvCarta)
    Call Totales_Cero()
  End Sub

  Private Sub cboTipo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
    With cboTipo.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboTipo.Width
    End With

  End Sub

  Public Sub Mostrar_Detalles()
    picAjaxBig.Visible = True
    picCarta.Visible = True
    dgvListado.DataSource = Nothing
    dgvCarta.DataSource = Nothing
    gpCriterios.Enabled = False
    gpBotones.Enabled = False
    gpBotonesB.Enabled = False
    Call Totales_Cero()
    If Not bwLlenar_Detalle.IsBusy Then
      bwLlenar_Detalle.RunWorkerAsync()
    End If
  End Sub

  Private Sub bwLlenar_Detalle_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Detalle.DoWork
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String, vPersona As Long = 0
    Dim vUs As Long = 0, vNumCarta As Integer = 0
    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    If IsNumeric(lblPersonaId.Text) Then
      If lblPersonaId.Text > 0 Then
        vPersona = Long.Parse(lblPersonaId.Text)
      End If
    End If
    If pFicha = "PENDIENTE" Then
      vNumCarta = 0
    Else
      vNumCarta = cboNumCarta.Value
    End If
    If Not cboAsistente.Text = "" Then
      vUs = cboAsistente.Value
    End If

    ListadoDoc = porcobrar_gestionManager.porcobrar_Gestion_Leer(xCod_uni, xCod_Alm, vHasta, "", vPersona, vUs, vNumCarta)

    e.Result = ListadoDoc

  End Sub

  Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted
    If pFicha = "PENDIENTE" Then
      dgvListado.DataSource = ListadoDoc
      Call CalcularTotales_Det()
    Else
      dgvCarta.DataSource = ListadoDoc
      'Call CalcularTotales_Det()
    End If
    picCarta.Visible = False
    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
    gpBotonesB.Enabled = True
    Me.LblRegistros.Text = dgvListado.Rows.Count & " Registros"

  End Sub

  Public Function CalcularTotales_Det() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vDeuda, vPagos, vSaldo As Single
    Dim vCod_a As Long = 0
    vDeuda = 0
    vPagos = 0
    vSaldo = 0
    CalcularTotales_Det = False
    'If Not Trim(TxtDNI_RUC.Text) = "" Then
    '    vCod_a = CInt(TxtDNI_RUC.Text)
    'End If
    Try
      DtTot = ListadoDoc 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

      For Each Drs In DtTot.Rows

        vDeuda = vDeuda + CSng(Drs("importe").ToString)
        vPagos = vPagos + CSng(Drs("pagos").ToString)
        vSaldo = vSaldo + CSng(Drs("saldo").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
      Me.lblTotalDeuda.Text = FormatNumber(vDeuda, 2, TriState.False, TriState.False)
      Me.lblTotalPagos.Text = FormatNumber(vPagos, 2, TriState.False, TriState.False)
      Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
      CalcularTotales_Det = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub Totales_Cero()

    Me.lblTotalDeuda.Text = "0.00"
    Me.lblTotalPagos.Text = "0.00"
    Me.lblTotalSaldo.Text = "0.00"
  End Sub

  Private Sub cboAlmacen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.ValueChanged
    dgvListado.DataSource = Nothing
    dgvCarta.DataSource = Nothing
    _codigo = 0
    Call Totales_Cero()
  End Sub
  Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "gPC.xls")
  End Sub

  Public Sub Listado_clientes()
    Dim testDialog As New FrmConsulta_Personas()
    'testDialog.Cod_Cat = 4
    TxtAnombreD.Text = ""
    lblPersonaId.Text = "-2"

    If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Dim objP As New persona
      lblPersonaId.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
      TxtAnombreD.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
    End If
    testDialog.Dispose()
  End Sub

  Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
    Call Listado_clientes()
  End Sub

  Private Sub TxtAnombreD_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAnombreD.KeyDown
    If e.KeyCode = Keys.Enter Then
      If TxtAnombreD.Text = "" Then
        Call Listado_clientes()
      End If
    Else
      TxtAnombreD.Text = ""
      lblPersonaId.Text = "-2"
    End If
  End Sub

  Private Sub tsdActualizar_Click_1(sender As Object, e As EventArgs) Handles tsdActualizar.Click
    pFicha = "PENDIENTE"
    Call Mostrar_Detalles()
  End Sub

  Private Sub mnuOpModelo1_Click(sender As Object, e As EventArgs) Handles mnuOpModelo1.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo1.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub mnuOpModelo2_Click(sender As Object, e As EventArgs) Handles mnuOpModelo2.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCarta(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo2.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub mnuOpModelo3_Click(sender As Object, e As EventArgs) Handles mnuOpModelo3.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo3.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub mnuOpModelo4_Click(sender As Object, e As EventArgs) Handles mnuOpModelo4.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo4.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub mnuOpModelo5_Click(sender As Object, e As EventArgs) Handles mnuOpModelo5.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo5.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub tsdPasaraCarta_Click(sender As Object, e As EventArgs) Handles tsdPasaraCarta.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = 0
        Dim xFrm As New FrmGestion_CobranzaNM
        Dim Rs As New DataTable
        _codigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
        Rs = por_cobrarManager.EmitirCartaG(_codigo, 0)
        xFrm.pPorcobrarId = _codigo
        xFrm.pNumCarta = 1
        xFrm.ShowDialog()
      End If
    End If


  End Sub

  Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
    Me.Close()
  End Sub

  Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
    pFicha = "FCARTA"
    Call Mostrar_Detalles()
  End Sub

  Private Sub tsLetter_Click(sender As Object, e As EventArgs) Handles tsLetter.Click
    If cboAlmacen.Value > 0 And cboNumCarta.Value > 0 Then
      If dgvCarta.Rows.Count > 0 Then
        If dgvCarta.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0, vNomFile As String = "", vNumCarta As Integer = cboNumCarta.Value
          vIdDet = dgvCarta.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, vNumCarta)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              'vNumCarta = Rs.DataSet.Tables(0).Rows(0).Item("num_carta").ToString

              vNomFile = "modelo" & vNumCarta & ".docx"
              If LibreriasFormularios.Emitir_Carta(vNomFile, vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub cboNumCarta_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboNumCarta.InitializeLayout
    cboNumCarta.DisplayLayout.Bands(0).Columns(0).Width = cboNumCarta.Width
  End Sub

  Private Sub dgvListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Width = 20
      .Columns(1).Width = 20
      .Columns(3).Width = 50
      .Columns("nombre").Width = 190
      .Columns("ndias").Width = 40

      .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
      .Columns("pagos").CellAppearance.TextHAlign = HAlign.Right
      .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right

      .Columns("unidadid").Hidden = True
      .Columns("unidad").Hidden = True
      .Columns("uabrev").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("almacen").Hidden = True
      .Columns("aabrev").Hidden = True
      .Columns("num_carta").Hidden = True
      .Columns("xdias").Hidden = True

    End With
  End Sub

  Private Sub dgvCarta_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvCarta.InitializeLayout
    With dgvCarta.DisplayLayout.Bands(0)
      .Columns(0).Width = 20
      .Columns(1).Width = 20
      .Columns(3).Width = 50
      .Columns("nombre").Width = 190
      .Columns("xdias").Header.VisiblePosition = 6
      .Columns("ndias").Header.Caption = "NDIAS"
      .Columns("ndias").Width = 60
      .Columns("xdias").Hidden = True
      .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
      .Columns("pagos").CellAppearance.TextHAlign =HAlign.Right
      .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("unidadid").Hidden = True
      .Columns("unidad").Hidden = True
      .Columns("uabrev").Hidden = True
      .Columns("almacenid").Hidden = True
      .Columns("almacen").Hidden = True
      .Columns("aabrev").Hidden = True

    End With
  End Sub

  Private Sub tsNextCar_Click(sender As Object, e As EventArgs) Handles tsNextCar.Click

    If dgvCarta.Rows.Count > 0 Then
      If dgvCarta.Selected.Rows.Count > 0 Then
        If cboNumCarta.Value = 6 Then
          MessageBox.Show("Ya no hay más formatos de cartas", "AVISO")
          Exit Sub
        End If
        _codigo = 0
        Dim xFrm As New FrmGestion_CobranzaNM
        Dim Rs As New DataTable, vNum_Carta As Integer = cboNumCarta.Value
        If vNum_Carta < 6 Then
          vNum_Carta += 1
        End If
        _codigo = dgvCarta.DisplayLayout.ActiveRow.Cells(0).Value
        Rs = por_cobrarManager.EmitirCartaG(_codigo, vNum_Carta)
        xFrm.pPorcobrarId = _codigo
        xFrm.pNumCarta = vNum_Carta
        xFrm.ShowDialog()
      End If
    End If
  End Sub

  Private Sub mnuOpModelo6_Click(sender As Object, e As EventArgs) Handles mnuOpModelo6.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then

          Dim Rs As New DataTable, vIdDet As Long = 0
          vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

          Rs = por_cobrarManager.EmitirCartaG(vIdDet, 0)
          If Not Rs Is Nothing Then
            If Rs.DataSet.Tables(0).Rows.Count > 0 Then


              Dim vCliente As String = "", vDniruc As String = "", vDireccion As String = ""
              Dim vDistrito As String = "", vProvincia As String = "", vDpto As String = ""
              Dim vAgente As String = "", vNumero As String = "", vProducto As String = ""
              Dim vTotal As Single = 0, vAbono As Single = 0, vSaldo As Single = 0

              vCliente = Rs.DataSet.Tables(0).Rows(0).Item("nombre_cliente").ToString
              vDniruc = Rs.DataSet.Tables(0).Rows(0).Item("dniruc").ToString
              vDireccion = Rs.DataSet.Tables(0).Rows(0).Item("direccion").ToString
              vDistrito = Rs.DataSet.Tables(0).Rows(0).Item("distrito").ToString
              vProvincia = Rs.DataSet.Tables(0).Rows(0).Item("provincia").ToString
              vDpto = Rs.DataSet.Tables(0).Rows(0).Item("departamento").ToString
              vAgente = Rs.DataSet.Tables(0).Rows(0).Item("agente").ToString
              vNumero = Rs.DataSet.Tables(0).Rows(0).Item("numero").ToString
              vProducto = Rs.DataSet.Tables(0).Rows(0).Item("producto").ToString
              vTotal = Rs.DataSet.Tables(0).Rows(0).Item("total").ToString
              vAbono = Rs.DataSet.Tables(0).Rows(0).Item("abono").ToString
              vSaldo = Rs.DataSet.Tables(0).Rows(0).Item("saldo").ToString
              If LibreriasFormularios.Emitir_Carta("modelo6.docx", vCliente, vDniruc, vDireccion, vDistrito, vProvincia, vDpto, vAgente, vNumero, vProducto, vTotal, vAbono, vSaldo) Then

              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub cboNumCarta_ValueChanged(sender As Object, e As EventArgs) Handles cboNumCarta.ValueChanged
    dgvCarta.DataSource = Nothing

  End Sub

  Private Sub RptDetalle_Suscripcion()

    Dim xCod_uni, xCod_Alm As Integer, vHasta As String, vPersona As Long = 0
    Dim vUs As Long = 0, vNumCarta As Integer = 0
    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    If IsNumeric(lblPersonaId.Text) Then
      If lblPersonaId.Text > 0 Then
        vPersona = Long.Parse(lblPersonaId.Text)
      End If
    End If
    If pFicha = "PENDIENTE" Then
      vNumCarta = 0
    Else
      vNumCarta = cboNumCarta.Value
    End If
    If Not cboAsistente.Text = "" Then
      vUs = cboAsistente.Value
    End If

    ListadoDoc = porcobrar_gestionManager.porcobrar_Gestion_Leer(xCod_uni, xCod_Alm, vHasta, "", vPersona, vUs, vNumCarta)

    Dim frm As New FrmVisor_Listado
    frm.RptGestionCobranza(ListadoDoc, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Gestión Cobranza", "")
    Call LibreriasFormularios.Ver_Form(frm, "Gestión Cobranza.")

  End Sub

  Private Sub tsRptPC_Click(sender As Object, e As EventArgs) Handles tsRptPC.Click
    pFicha = "PENDIENTE"
    Call RptDetalle_Suscripcion()
  End Sub

  Private Sub tsRptGestionC_Click(sender As Object, e As EventArgs) Handles tsRptGestionC.Click
    pFicha = "CARTA"
    Call RptDetalle_Suscripcion()
  End Sub

  Private Sub dgvCarta_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvCarta.InitializeRow
    e.Row.Expanded = False
    e.Row.ExpansionIndicator = ShowExpansionIndicator.CheckOnDisplay

    Try
      If e.Row.Band.Index = 0 Then

        If e.Row.Cells("xdias").Value >= 15 Then
          e.Row.Cells("xdias").Appearance.Image = Global.Phoenix.My.Resources.Resources.i_aviso
        End If

      End If
    Finally

    End Try
  End Sub
End Class