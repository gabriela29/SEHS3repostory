
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmMovimiento_BancarioNM

    Public DtG As New DataTable, pCodigo_Per As Long, pTipoPer As String = ""
    Public id_tipoDoc As Integer, xBA As Boolean = False, pNC As Boolean
    Public Cerrar As Boolean = False, vDoc_Legal As Boolean = False
    Public dtDocumento As DataTable, dtForma_Pago As DataTable, dtDzmo As DataTable
    Public pCodigo_Alm As Integer, vCodigo_Per1 As Long
    Public vCodigo_Us As Integer, pTipo As String
    Public xCont As Integer = 0, vIngreso As Boolean, vImprimir As Boolean, vCopias As Long
    Public vFormato As String = "", vImpresora As String = "", vSerieTk As String = ""
    Public vCodigo_Doc As Integer, vCodigo_Serie As Long = 0
    Public vOkR As Boolean, zReniec As Boolean
    Public pApe_Pat As String = "", pApe_Mat As String = "", pNombre As String = "", pDNI As String = "", pRUC As String = ""
    Public pRaz_Social As String = "", pDireccion As String = "", pDireccionId As Long = 0

    Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Usu As Long, vCaja As String = ""
        dtDocumento = New DataTable
        dtForma_Pago = New DataTable
        dtDzmo = New DataTable
        vCodigo_Usu = GestionSeguridadManager.idUsuario
        vCaja = My.Computer.Name
        Try
            Call cursoresManager.Datos_Ventana_venta(pCodigo_Alm, vCodigo_Usu, _
                                                        vCaja, "VENTA", dtDocumento, dtDzmo, dtForma_Pago)

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
            If .Rows.Count > 0 Then
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

    Private Sub FrmMovimiento_BancarioNM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmMovimiento_BancarioNM_Load(sender As Object, e As EventArgs) Handles Me.Load
        vCodigo_Us = GestionSeguridadManager.idUsuario
        picAjax.Visible = True
        txtFecha.Value = Now.Date
        If Not bwDatos.IsBusy Then
            bwDatos.RunWorkerAsync()
        End If
        txtRucDni.Focus()
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
            .Columns(3).Width = 60
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
        If vCodigo_Serie = 0 Then
            valido = False
            ErrorProvider1.SetError(txtSerie, "No hay Serie y/o Debe Seleccionar Una")
            camposConError.Add("SERIE")
        Else
            ErrorProvider1.SetError(txtSerie, Nothing)
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
        If (Me.txtRucDni.Text) = "" Or pCodigo_Per = 0 Or Long.Parse(lblPersonaId.Text) = 0 Then
            valido = False
            ErrorProvider1.SetError(TxtAnombreD, "Debe seleccionar a Nombre de quien se emite el Documento")
            camposConError.Add("DNI/RUC")
        Else
            ErrorProvider1.SetError(TxtAnombreD, Nothing)
        End If

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

        ' Total a Cobrar
        If Not CSng(Me.lblTotal_Cobrar.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(lblTotal_Cobrar, "El monto del Documento debe ser Mayor de Cero(0)")
            camposConError.Add("TOTAL")
        Else
            ErrorProvider1.SetError(lblTotal_Cobrar, Nothing)
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
        'Dim dgvRw As UltraGridRow
        Dim vCodigo As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
        Dim vCod_Abo As Long = 0, vSerie As Long = 0
        Dim xFecha As String
        Dim vPaga As Single = 0, Vuelto As Single = 0
        Try

            If ValidarControles() Then
                If BtnGrabar.Text = "&Grabar" Then
                    ugbDetalle_Pago.Visible = True
                    Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotal_Cobrar.Text, 2, TriState.True, , TriState.False)
                    Me.txtPaga.Text = FormatNumber(Me.lblTotal_Cobrar.Text, 2, TriState.True, , TriState.False)

                    lblson.Text = Me.lblson.Text
                    Me.lblVuelto.Text = "0"
                    BtnGrabar.Text = "&Emitir"

                    txtPaga.Focus()
                Else
                    ' Total a Cobrar
                    If Not (CSng(Me.txtPaga.Text) >= CSng(Me.lblTotal_Cobrar.Text)) Then
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
                                                   & Trim(txtGlosaDP.Text) & "','" _
                                                   & Trim(Str(vCodigo_Serie)) & "'],"
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

                    'For Each dgvRw In Me.dgvDetalle_Pagos.Rows
                    '    If dgvRw.Band.Index = 0 Then
                    '        If CSng(dgvRw.Cells("Amortiza").Value) > 0 Then
                    '            vTiene = True
                    '            vArrCuentas = vArrCuentas & "['" & Trim(Str(vCod_Abo)) & "', '" & _
                    '                                         Trim(Str(dgvRw.Cells("codigo").Value)) & "','" & _
                    '                                         Trim(Str(dgvRw.Cells("Amortiza").Value)) & "'],"
                    '        End If

                    '    End If
                    'Next

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
                    vNumero = Trim(txtSerie.Text) & "-" & Trim(txtNumero.Text)
                    vIngreso = True


                    With ObjMB
                        .Codigo = -1
                        .Tipo = IIf(vIngreso, "I", "S")
                        .Codigo_Documento = vCodigo_Doc
                        .Numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim)
                        .Codigo_CtaCte = 1 'Val(cboCuenta.BoundText)
                        If pTipo = "ANTICIPO" Then
                            .Codigo_Tip = Tipo_Mov_Bancario.tAnticipo
                        Else
                            .Codigo_Tip = Tipo_Mov_Bancario.tIngreso
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

                        .Referencia_Exterior = ""

                        .Codigo1_RefExt = 0
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

            Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(vCodigo), pCodigo_Alm, cboDocumento.Value, My.Computer.Name, vLegal, True)
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
            lblNombreCta.Text = vNombreCta
        Else
            'CtaMstra = ""
            lblNombreCta.Text = ""
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

            Case 2
                lblClientePor.Text = "RUC:"
                txtRucDni.MaxLength = 11
                txtRucDni.Text = ""
                txtRucDni.ReadOnly = False
                TxtAnombreD.ReadOnly = True
                TxtAnombreD.Text = "..."
                TxtAnombreD.Visible = True
                lblPersonaId.Text = 0

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
                'txtDireccion.Text = objP.direccion
                pDireccionId = 0
                lblNroCuenta.Focus()
            Else
                txtRucDni.Focus()
            End If
            objP = Nothing
        End If
        testDialog.Dispose()
    End Sub

    Public Sub Buscar_Cliente(ByVal vTipo As String, ByVal vNumero As String)
        Dim objP As New persona
        objP = LibreriasFormularios.Datos_Persona_Local(vTipo, txtRucDni.Text)
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

            pDireccionId = 0
            lblPersonaId.Text = pCodigo_Per
            lblNroCuenta.Focus()
        Else
            txtRucDni.Focus()
        End If
        objP = Nothing
    End Sub

    Private Sub txtRucDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRucDni.KeyDown
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
            If Val(lblClientePor.Tag) = 0 Then lblClientePor.Tag = 2
            If Val(lblClientePor.Tag) = 3 Then lblClientePor.Tag = 1
            Select Case lblClientePor.Tag
                Case Is = 1
                    Call Habilitar_RUC_DNI(1)
                Case Is = 2
                    Call Habilitar_RUC_DNI(2)
            End Select
        End If
        If vOkR Then
            lblNroCuenta.Focus()
        End If
    End Sub
End Class