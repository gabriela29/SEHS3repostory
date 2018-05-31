
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmPor_CobrarNM
    Public pCodigo As Long, pCodigo_Per As Long, pCodigo_Alm As Integer, pAlmacen As String
    Public dtDocumento As DataTable, dtC_Costo As DataTable
    Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0

    Public Function LimpiarControles() As Boolean
        Me.txtRucDni.Text = ""
        Me.TxtAnombreD.Text = ""
        Me.txtNroCuenta.Text = ""
        txtNombreCuenta.Text = ""
        cboCentro_Costo.Text = ""
        txtEmision.Text = ""
        txtVencimiento.Text = ""
        txtImporte.Text = "0.00"
        txtGlosa.Text = ""
    End Function

    Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Usu As Long, vCaja As String = ""
        dtDocumento = New DataTable
        dtC_Costo = New DataTable
        vCodigo_Usu = GestionSeguridadManager.idUsuario
        vCaja = "XCCARGO"
        Try
            Call cursoresManager.Datos_Ventana_PorCobrar(pCodigo_Alm, vCodigo_Usu, _
                                                        vCaja, dtDocumento, dtC_Costo)

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
                .Value = pCodigo
            Else
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With Me.cboCentro_Costo
            .DataSource = Nothing
            .DataSource = dtC_Costo  'tipo_forma_pagoManager.GetList("%%")
            .DataBind()
            .ValueMember = "centro_costo"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If pCodigo > 0 Then
                .Value = pCodigo
            Else
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        picAjax.Visible = False
        'BtnGrabar.Visible = True


    End Sub

    Private Sub FrmPor_CobrarNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmPor_CobrarNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblAlmacen.Text = pAlmacen
        txtEmision.Value = Now.Date
        txtVencimiento.Value = DateAdd(DateInterval.Day, 15, Now.Date)
        lblClientePor.Tag = 1

        If Not bwDatos.IsBusy Then
            bwDatos.RunWorkerAsync()
        End If
    End Sub

    Private Sub Consultar_Reniec()
        If IsNumeric(txtRucDni.Text) Then
            If txtRucDni.Text.Trim.Length = 8 Then
                Dim ObjPe As New persona
                ObjPe = personaManager.Datos_Persona_Basic("N", txtRucDni.Text.Trim, 0)
                If Not ObjPe Is Nothing Then
                    pCodigo_Per = Long.Parse(ObjPe.personaid)
                    Me.TxtAnombreD.Text = ObjPe.ape_pat & " " & ObjPe.ape_mat & " " & ObjPe.nombre
                End If
            Else
                MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
                txtRucDni.Focus()
            End If
        Else
            MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
            txtRucDni.Focus()
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
                TxtAnombreD.Text = ""
                TxtAnombreD.Visible = True
            Case 2
                lblClientePor.Text = "RUC:"
        txtRucDni.MaxLength = 12
        txtRucDni.Text = ""
                txtRucDni.ReadOnly = False
                TxtAnombreD.ReadOnly = True
                TxtAnombreD.Text = ""
                TxtAnombreD.Visible = True
        End Select
    End Sub

    Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lblClientePor.Tag = 1 Then
                Call Consultar_Reniec()
            ElseIf lblClientePor.Tag = 2 Then
                Call Consulta_DNI_SUNAT()
            End If
        Else
            If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
            If e.KeyCode <> Keys.Down Then lblClientePor.Tag = Val(lblClientePor.Tag) + 1
            If e.KeyCode <> Keys.Up Then lblClientePor.Tag = Val(lblClientePor.Tag) - 1
            If Val(lblClientePor.Tag) = 0 Then lblClientePor.Tag = 3
            If Val(lblClientePor.Tag) = 3 Then lblClientePor.Tag = 1
            Select Case lblClientePor.Tag
                Case Is = 1
                    Call Habilitar_RUC_DNI(1)
                Case Is = 2
                    Call Habilitar_RUC_DNI(2)
            End Select
        End If
    End Sub

  Private Sub Consulta_DNI_SUNAT()
    Dim vProv As String = ""
    TxtAnombreD.Text = ""

    If Not Trim(txtRucDni.Text) = "" Then
      If txtRucDni.TextLength >= 11 Then
        If Not IsNumeric(txtRucDni.Text) Then Exit Sub
        Dim ObjPe As New persona
        ObjPe = personaManager.Datos_Persona_Basic("J", txtRucDni.Text.Trim, 0)
        If Not ObjPe Is Nothing Then
          pCodigo_Per = Long.Parse(ObjPe.personaid)
          Me.TxtAnombreD.Text = ObjPe.raz_soc
        End If
      Else
        MsgBox("Debe tener 11 dígitos el RUC", MsgBoxStyle.Exclamation, "AVISO")
        txtRucDni.Focus()
      End If

    End If
  End Sub

  Public Sub ListadoPlanCtasAll()
        Dim testDialogP As New FrmConsulta_Plan_Ctas

        If testDialogP.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If testDialogP.dgvListado.Rows.Count > 0 Then
                If Not testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value Is DBNull.Value Then
                    txtNroCuenta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(5).Value)
                    txtNombreCuenta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
                End If
            End If
        End If
        testDialogP.Dispose()
    End Sub

    Private Sub txtNroCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroCuenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            If Not Trim(txtNroCuenta.Text) = "" Then Exit Sub
            Call ListadoPlanCtasAll()
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
                    txtNombreCuenta.Text = CStr(drws("NombreCta"))
                    Exit For
                Next drws
            End If
            dtp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txtNroCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroCuenta.Validated
                'CtaMstra = ""
        If Not Trim(txtNroCuenta.Text) = "" Then
            Dim vNombreCta As String = ""
            Call LibreriasFormularios.ObtenerNombreCta(txtNroCuenta.Text.Trim, vNombreCta)
            txtNombreCuenta.Text = vNombreCta
        Else
            'CtaMstra = ""
            txtNombreCuenta.Text = ""
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

    Private Sub cboCentro_Costo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCentro_Costo.InitializeLayout
        cboCentro_Costo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboCentro_Costo.DisplayLayout.Bands(0).Columns(1).Width = cboCentro_Costo.Width
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        If pCodigo_Per = 0 Or pCodigo_Alm = 0 Then
            valido = False
            ErrorProvider1.SetError(txtRucDni, "Falta Seleccinar y/o ingresar Cliente y/o Almacen")
            camposConError.Add("Codigo Per / Codigo Alm")
        Else
            ErrorProvider1.SetError(txtRucDni, Nothing)
        End If

        If Trim(txtRucDni.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtRucDni, "Falta Ingresar Nro Documento")
            camposConError.Add("RucDni")
        Else
            ErrorProvider1.SetError(txtRucDni, Nothing)
        End If

        If TxtAnombreD.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(TxtAnombreD, "Debe Seleccionar Cliente")
            camposConError.Add("CLIENTE")
        Else
            ErrorProvider1.SetError(TxtAnombreD, Nothing)
        End If

        If cboDocumento.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(cboDocumento, "Debe Seleccionar Documento")
            camposConError.Add("DOCUMENTO")
        Else
            ErrorProvider1.SetError(cboDocumento, Nothing)
        End If

        If txtSerie.Text.Trim = "0000" Then
            valido = False
            ErrorProvider1.SetError(txtSerie, "Debe Seleccionar Documento")
            camposConError.Add("SERIE")
        Else
            ErrorProvider1.SetError(txtSerie, Nothing)
        End If

        If Not IsDate(txtEmision.Value) Then
            valido = False
            ErrorProvider1.SetError(txtEmision, "Debe Ingresar una fecha válida")
            camposConError.Add("EMISION")
        Else
            ErrorProvider1.SetError(txtEmision, Nothing)
        End If

        If Not IsDate(txtVencimiento.Value) Then
            valido = False
            ErrorProvider1.SetError(txtVencimiento, "Debe Ingresar una fecha de vencimiento válida")
            camposConError.Add("VENCIMIEnTO")
        Else
            ErrorProvider1.SetError(txtVencimiento, Nothing)
        End If

        'If cboCentro_Costo.Text.Trim = "" Then
        '    valido = False
        '    ErrorProvider1.SetError(cboCentro_Costo, "Debe Seleccionar Centro Costo")
        '    camposConError.Add("Centro Costo")
        'Else
        '    ErrorProvider1.SetError(cboCentro_Costo, Nothing)
        'End If

        If Not CSng(txtImporte.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(txtImporte, "El Importe debe ser mayor a Cero (0)")
            camposConError.Add("IMPORTE")
        Else
            ErrorProvider1.SetError(txtImporte, Nothing)
        End If

        'If txtNroCuenta.Text.Trim = "" Then
        '    valido = False
        '    ErrorProvider1.SetError(txtNroCuenta, "Debe Seleccionar una cuenta")
        '    camposConError.Add("CUENTA")
        'Else
        '    ErrorProvider1.SetError(txtNroCuenta, Nothing)
        'End If

        'If txtNombreCuenta.Text.Trim = "" Then
        '    valido = False
        '    ErrorProvider1.SetError(txtNombreCuenta, "Debe Seleccionar una cuenta")
        '    camposConError.Add("Nombre Cuenta")
        'Else
        '    ErrorProvider1.SetError(txtNombreCuenta, Nothing)
        'End If

        If Not valido Then
            Lblerror.Text = "Introduzca y/o Seleccione un valor en  "

            For Each campo In camposConError
                Lblerror.Text &= campo & ", "
            Next
            Lblerror.Text = Lblerror.Text.Substring(0, Lblerror.Text.Length - 2)
        End If
        Return valido
    End Function

    Public Function Actualizar() As Boolean
        Dim Objeto As New por_cobrar
        Dim vEmi As String = "", vVence As String = ""
        vEmi = LibreriasFormularios.Formato_Fecha(txtEmision.Value)
        vVence = LibreriasFormularios.Formato_Fecha(txtVencimiento.Value)
        Try
            With Objeto
                .Codigo = pCodigo
                .Codigo_Documento = cboDocumento.Value
                .Numero = txtSerie.Text & "-" & txtNumero.Text
                .condicion = "CREDITO"
                .Letra = ""
                .Renovacion = 0
                .Codigo_Persona = pCodigo_Per
                .fecha = vEmi
                .Vencimiento = vVence
                .Moneda = "NS"
                .Importe = txtImporte.Text
                .Saldo = txtImporte.Text
                .Cambio = 0
                .Signo = "+"
                .Observacion = txtGlosa.Text
                .Referencia_Exterior = ""
                .Codigo1_RefExt = 0
                .Codigo2_RefExt = 0
                .UsuarioId = GestionSeguridadManager.idUsuario
                .caja = My.Computer.Name
                .Cerrado = True
                .Estado = True
                .Codigo_Almacen = pCodigo_Alm

                .Incluir_Registro = False
                .NroCuenta = txtNroCuenta.Text
                .C_Costo = cboCentro_Costo.Value

            End With

            If por_cobrarManager.Grabar(Objeto) > 0 Then
                Me.Close()
            End If
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
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

End Class