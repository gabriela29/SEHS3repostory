Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmRegistro_MBNM

  Public CtaMstra As String, _NroReg As Long, vCentro_Costo As Long, xBA As Boolean = False, vTipo As String, vFecha_Reg As Date
  Public NroLote As Long, Lote As String, vCodigo_Almacen As Integer, vAlmacen As String, vCerrado As Boolean
  Public pAnio As String, pMes As String, pEntidad As Long, pTabla As String, pTablaId As Long, pTotal As Single
  Public pDtPlan As DataTable, pDtCtaCte As DataTable

  Private Sub MostrarDatoGrid()
    'Call cursoresManager.Datos_Plan_CtaCte(pEntidad, pDtPlan, pDtCtaCte)

    txtImporte.Text = pTotal
    Call Llenar_Combos()
  End Sub

  Private Sub Llenar_Combos()

    Dim dtC As DataTable

    dtC = centro_costoManager.GetListcbo(vCodigo_Almacen, 0)

    With cboCentro_Costo_Pago
      .DataSource = dtC
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        If NroLote = 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End If
    End With

    With cboCuentaB
      .DataSource = Nothing
      .DataSource = pDtPlan
      .DataBind()
      .ValueMember = "plancuentaid"
      .DisplayMember = "cuenta"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then

      End If
    End With
    With cboMoneda
      .DataSource = Nothing
      .DataSource = monedaManager.GetList("")
      .ValueMember = "tipomonedaid"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      End If
    End With
  End Sub

  Private Sub cboMoneda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboMoneda.InitializeLayout
    cboMoneda.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboMoneda.DisplayLayout.Bands(0).Columns(1).Width = cboMoneda.Width
  End Sub

  Private Sub FrmRegistro_MB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub

  Private Sub FrmRegistro_MB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LblNroLote.Text = NroLote
    LblNroLote.Tag = NroLote
    LblDescripLote.Text = Lote
    LblDescripLote.Tag = vCodigo_Almacen
    Me.Text = vTipo & "-" & vAlmacen
    lblPeriodo.Text = pAnio & " - " & pMes
    TxtFechaEmi.Value = Now.Date

    pDtPlan = GestionTablas.dtplan
    pDtCtaCte = New DataTable
    pDtCtaCte = plan_cuentasManager.Plan_CtaCte_GetList(GestionSeguridadManager.gEntidad)
    Call MostrarDatoGrid()

    dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
  End Sub

  Private Sub cboCuentaB_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCuentaB.InitializeLayout
    With cboCuentaB.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns("cuenta").Width = (cboCuentaB.Width + cboCuentaB.Width)
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      '.Columns(3).Hidden = True

    End With
  End Sub

  Public Function ObtenerSubCtasB(ByVal vSubCtaCode As String) As Boolean
    Dim Filter As String = "subctacode = '" & vSubCtaCode & "'"
    Dim dv As DataView
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

  Private Sub cboCuentaB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCuentaB.Validated
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
        If ObtenerSubCtasB(vCtaCde) Then

        End If

      End If
    End If
  End Sub

  Private Sub cboCtaCteB_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCtaCteB.InitializeLayout
    With cboCtaCteB.DisplayLayout.Bands(0)
      '.Columns(0).Hidden = True
      .Columns("ctacte").Width = cboCuentaB.Width
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      '.Columns(3).Hidden = True

    End With
  End Sub
  Private Sub cboCtaCteB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCtaCteB.Validated
    If cboCtaCteB.ActiveRow Is Nothing Then
      If Not cboCtaCteB.Text = "" Then
        cboCtaCteB.Focus()
        lblNombreCtaCteB.Text = ""
      End If
    Else
      lblNombreCtaCteB.Text = cboCtaCteB.ActiveRow.Cells("nombre").Value
    End If
  End Sub

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String


    If Trim(cboCuentaB.Text) = "" Or lblNombreCtaB.Text = "" Then
      valido = False
      ErrorProvider1.SetError(cboCuentaB, "Falta Ingresar Nro de Cuenta ")
      camposConError.Add("CUENTASUSTENTO")
    Else
      ErrorProvider1.SetError(cboCuentaB, Nothing)
    End If
    If Not cboCuentaB.Text = "" Then
      If Not cboCuentaB.ActiveRow.Cells("subctacode").Value = "" Then
        If Trim(cboCtaCteB.Text) = "" Or lblNombreCtaCteB.Text = "" Then
          valido = False
          ErrorProvider1.SetError(cboCuentaB, "Falta Ingresar Nro de CtaCte")
          camposConError.Add("CUENTACTESUSTENTO")
        Else
          ErrorProvider1.SetError(cboCtaCteB, Nothing)
        End If
      End If
    End If

    If Trim(cboCentro_Costo_Pago.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtGlosaCC, "Falta seleccionar Centro de costo ")
      camposConError.Add("CENTROCOSTO")
    Else
      ErrorProvider1.SetError(cboCentro_Costo_Pago, Nothing)
    End If

    If Trim(txtGlosaCC.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtGlosaCC, "Falta Ingresar Glosa de Sustento ")
      camposConError.Add("CUENTASUSTENTO")
    Else
      ErrorProvider1.SetError(txtGlosaCC, Nothing)
    End If

    If Not Trim(cboMoneda.Value) = "NS" Then
      If Not Single.Parse(txtTipoCambio.Text) > 0 Then
        valido = False
        ErrorProvider1.SetError(cboMoneda, "Falta ingresar el tipo de cambio ")
        camposConError.Add("TC")
      Else
        ErrorProvider1.SetError(cboMoneda, Nothing)
      End If
    End If

    If Not valido Then
      Dim vErr As String = ""
      'lblError.Text = "Introduzca y/o Seleccione un valor en  "

      For Each campo In camposConError
        vErr &= campo & ", "
      Next
      MessageBox.Show(vErr)
      'lblError.Text = lblError.Text.Substring(0, lblError.Text.Length - 2)
    End If
    Return valido
  End Function

  Public Function AgregarMB() As Boolean
    Dim Objeto As New registro_mb, xOk As Boolean = False, vfecha As String, vFecha_R As String
    If Not vCodigo_Almacen > 0 Then
      MessageBox.Show("No hay un almacén seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Function
    End If
    Try
      vfecha = LibreriasFormularios.Formato_Fecha(TxtFechaEmi.Value)
      If IsDate(vFecha_Reg) Then
        vFecha_R = LibreriasFormularios.Formato_Fecha(vFecha_Reg)
      Else
        vFecha_R = ""
      End If

      With Objeto
        .registrombid = 0
        .tabla = pTabla
        .tablaid = pTablaId
        .cuenta = Trim(cboCuentaB.Text)
        .ctacte = Trim(cboCtaCteB.Text)
        .centro_costo = cboCentro_Costo_Pago.Value
        .nrooperacion = txtNroOPeracion.Text & ""
        .fecha = vfecha
        .fecha_registro = vFecha_R
        .glosa = txtGlosaCC.Text & ""
        .importe = FormatNumber(Me.txtImporte.Text, 2, TriState.True, , TriState.False)
        .tipomonedaid = cboMoneda.Value
        If cboMoneda.Value = "NS" Then
          .tipocambio = 0
        Else
          .tipocambio = Single.Parse(txtTipoCambio.Text)
        End If
        .usuario = GestionSeguridadManager.sUsuario
        .caja = GestionSeguridadManager.NombrePC

      End With

      If registro_mbManager.Agregar(0, Objeto, vCodigo_Almacen) > 0 Then
        xOk = True
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
    Return xOk
  End Function

  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    If ValidarDatos() Then
      If AgregarMB() Then
        Call FrmArqueo_IngresosNM.Actualizar()
        Me.Close()
      End If
    End If
  End Sub

  Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    Me.Close()
  End Sub

  Private Sub tsMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMostrar.Click
    Call Mostrar()
  End Sub

  Private Sub tsEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEliminar.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then

        If registro_mbManager.Eliminar(dgvListado.DisplayLayout.ActiveRow.Cells("registrombid").Value) Then
          Call Mostrar()
        End If
      End If
    End If

  End Sub

  Private Sub Mostrar()
    dgvListado.DataSource = registro_mbManager.GetList(pTabla, pTablaId)
    LblRegistros.Text = dgvListado.Rows.Count
  End Sub

  Private Sub cboCentro_Costo_Pago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboCentro_Costo_Pago.InitializeLayout
    With cboCentro_Costo_Pago.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboCentro_Costo_Pago.Width

    End With
  End Sub

  Private Sub cboMoneda_ValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.ValueChanged
    txtTipoCambio.Visible = False
    lblTC.Visible = False
    txtTipoCambio.Text = 0
    If Not cboMoneda.DataSource Is Nothing Then
      If Not cboMoneda.Text = "" Then
        If Trim(cboMoneda.ActiveRow.Cells("tipomonedaid").Value) <> "NS" Then
          txtTipoCambio.Visible = True
          lblTC.Visible = True
        End If
      End If
    End If
  End Sub
End Class