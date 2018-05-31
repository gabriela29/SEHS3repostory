Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmActualizar_Asistente
  Public pCodigo_Alm As Integer, pCodigo_Per As Long, pNroCuenta As String, pTipo As String
  Public pCampaniaId As Integer, pCampania As String
  Private Sub Llenar_Combos()

    With cboTipo
      .DataSource = tipopersonacampaniaManager.Tipo_Persona_Campania_leer("")
      .ValueMember = "tipopersonacid"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        'If pCodigo > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
        '  cboTipo.Value = pCCOSTO
        'End If
      End If
    End With

  End Sub

  Private Sub FrmActualizar_Asistente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    'If e.KeyChar = Chr(Keys.Enter) Then
    '    SendKeys.Send("{tab}")
    'End If
  End Sub

  Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
    If e.KeyCode = Keys.Enter Then
      Dim ObjPe As New persona
      Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

      ObjPe = personaManager.Datos_Persona_Basic("N", txtDNI.Text.Trim, 0)
      If Not ObjPe Is Nothing Then
        pCodigo_Per = Long.Parse(ObjPe.personaid)
        vApe_Pat = ObjPe.ape_pat
        vApe_Mat = ObjPe.ape_mat
        vNombre = ObjPe.nombre
        lblAsistente.Text = vApe_Pat & " " & vApe_Mat & ", " & vNombre
        lblAsistente.Tag = pCodigo_Per
        lblDeuda.Text = ObjPe.saldo
        txtCtaMaestra.Focus()
      Else
        lblAsistente.Text = ""
        lblAsistente.Tag = 0
        txtDNI.Focus()
      End If
    End If
  End Sub

  Public Sub ListadoPlanCtasAll()
    Dim testDialogP As New FrmConsulta_Plan_Ctas

    If testDialogP.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      If testDialogP.dgvListado.Rows.Count > 0 Then
        If Not testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value Is DBNull.Value Then
          txtCtaMaestra.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(5).Value)
          lblNombreCta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
        End If
      End If
    End If
    testDialogP.Dispose()
  End Sub

  Private Sub FrmActualizar_Asistente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    lblAsistente.Tag = 0
    lblCampania.Text = pCampania
    Call Llenar_Combos()
  End Sub

  Private Sub txtCtaMaestra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaMaestra.KeyDown
    If e.KeyCode = Keys.F1 Then
      If Not Trim(txtCtaMaestra.Text) = "" Then Exit Sub
      ' Call ListadoPlanCtasAll()
    End If
    If e.KeyCode = Keys.Enter Then
      txtObservacion.Focus()
    End If
  End Sub

  Private Sub txtCtaMaestra_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaMaestra.Validated
    'CtaMstra = ""
    If Not Trim(txtCtaMaestra.Text) = "" Then
      If IsNumeric(txtCtaMaestra.Text) Then
        Dim vNombreCta As String = ""
        Call LibreriasFormularios.ObtenerNombreCta(txtCtaMaestra.Text.Trim, vNombreCta)
        lblNombreCta.Text = vNombreCta
      End If
    Else
      'CtaMstra = ""
      lblNombreCta.Text = ""
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
          lblNombreCta.Text = CStr(drws("NombreCta"))
          Exit For
        Next drws
      End If
      dtp = Nothing
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub btnHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorial.Click
    If pCodigo_Per > 0 And Single.Parse(lblDeuda.Text) > 0 Then
      FrmHistorial_Persona.pPersona = lblAsistente.Text
      FrmHistorial_Persona.pCodigo_Per = pCodigo_Per
      FrmHistorial_Persona.ShowDialog()
    End If
  End Sub

  Public Function Actualizar() As Boolean
    Dim Objeto As New personas_campania
    Try
      With Objeto
        .codigo_cam = pCampaniaId
        .codigo_alm = pCodigo_Alm
        .codigo_asi = pCodigo_Per
        .codigo_colp = 0
        .nrocuenta = txtCtaMaestra.Text & ""
        .tipo = cboTipo.Value
        .estado = ChkEstado.Checked
        .c_costo = 0
        If pTipo = "" Then
          .observacion = txtObservacion.Text & ""
        Else
          .observacion = pTipo
        End If

        .usuario = GestionSeguridadManager.sUsuario
        .caja = My.Computer.Name

      End With

      If Control_AsistenteManager.Grabar(True, Objeto) > 0 Then
        Me.Close()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    If pCodigo_Per = 0 Or pCodigo_Alm = 0 Then
      valido = False
      ErrorProvider1.SetError(txtDNI, "Falta Seleccinar y/o ingresar Asistente y/o Almacen")
      camposConError.Add("Codigo Per / Codigo Alm")
    Else
      ErrorProvider1.SetError(txtDNI, Nothing)
    End If

    If Trim(txtDNI.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtDNI, "Falta Ingresar Nro Documento")
      camposConError.Add("txtDNI")
    Else
      ErrorProvider1.SetError(txtDNI, Nothing)
    End If

    If cboTipo.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblAsistente, "Debe Seleccionar Tipo")
      camposConError.Add("Tipo")
    Else
      ErrorProvider1.SetError(cboTipo, Nothing)
    End If
    If lblCampania.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblAsistente, "Debe Seleccionar Campaña")
      camposConError.Add("Campaña")
    Else
      ErrorProvider1.SetError(cboTipo, Nothing)
    End If

    If Not GestionSeguridadManager.sUsuario = "admin" Then
      If CSng(lblDeuda.Text) > 0 Then
        valido = False
        ErrorProvider1.SetError(lblDeuda, "El Asistente tiene deuda por lo cual no puede agregarlo en su sucursal")
        camposConError.Add("Deuda")
      Else
        ErrorProvider1.SetError(lblDeuda, Nothing)
      End If
    End If
    If txtCtaMaestra.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(txtCtaMaestra, "Debe Seleccionar una cuenta")
      camposConError.Add("CUENTA")
    Else
      ErrorProvider1.SetError(txtCtaMaestra, Nothing)
    End If

    If lblNombreCta.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblNombreCta, "Debe Seleccionar una cuenta")
      camposConError.Add("Nombre Cuenta")
    Else
      ErrorProvider1.SetError(lblNombreCta, Nothing)
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
    If MessageBox.Show("¿Desea grabar los datos?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      Try
        If ValidarDatos() Then

          Call Actualizar()

        End If


      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If
  End Sub

  Private Sub cboTipo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboTipo.InitializeLayout
    With cboTipo.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboTipo.Width
    End With
  End Sub

  Private Sub txtDNI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.ValueChanged

  End Sub

  Private Sub txtCtaMaestra_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaMaestra.ValueChanged

  End Sub

  Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
    If e.KeyCode = Keys.Enter Then
      BtnGrabar.Focus()
    End If
  End Sub
End Class