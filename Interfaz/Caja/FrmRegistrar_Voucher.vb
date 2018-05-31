Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmRegistrar_Voucher
    Public pCuenta As Boolean
    Public pCodigo As Long, pCodigo_Alm As Integer, pTitulo As String, pFecha_Ing As Date


    Private Sub Llenar_Combos()

        Dim dtC As DataTable

    dtC = centro_costoManager.GetListcbo(pCodigo_Alm, 0)

    With cboCentroCosto
            .DataSource = dtC
            .ValueMember = "centro_costo"
            .DisplayMember = "nombre"
            If .Rows.Count > 0 Then
                If pCodigo = 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

    End Sub

    Private Sub FrmRegistrar_Voucher_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmRegistrar_Voucher_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Llenar_Combos()
        TxtEmision.Value = Now.Date
        lblFecha_Ingresos.Text = "Depósito de los Ingresos del: " & pFecha_Ing
        pCuenta = False
    End Sub

    Public Sub ListadoPlanCtasAll()
        Dim testDialogP As New FrmConsulta_Plan_Ctas

        If testDialogP.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If testDialogP.dgvListado.Rows.Count > 0 Then
                If Not testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value Is DBNull.Value Then
                    txtCtaMaestra.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(5).Value)
                    lblNombreCta.Text = CStr(testDialogP.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
                    pCuenta = True
                End If
            End If
        End If
        testDialogP.Dispose()
    End Sub

    Private Sub txtCtaMaestra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaMaestra.KeyDown
        If e.KeyCode = Keys.F1 Then
            If Not Trim(txtCtaMaestra.Text) = "" Then Exit Sub
            Call ListadoPlanCtasAll()
        End If
        'If e.KeyCode = Keys.Enter Then
        '    cboCentroCosto.Focus()
        'End If
    End Sub

    Private Sub txtCtaMaestra_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtaMaestra.Validated
        'CtaMstra = ""
        If pCuenta Then
            If Not Trim(txtCtaMaestra.Text) = "" Then
                If IsNumeric(txtCtaMaestra.Text) Then
                    Call ObtenerPlanCtaCond(Trim(txtCtaMaestra.Text), 7)
                Else
                    Call ObtenerPlanCtaCond(Trim(txtCtaMaestra.Text), 4)
                End If
            Else
                'CtaMstra = ""
                lblNombreCta.Text = ""
            End If
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

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        If Trim(TxtNroOpe.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(TxtNroOpe, "Falta Ingresar Nro de Operacion")
            camposConError.Add("OPERACION")
        Else
            ErrorProvider1.SetError(txtCtaMaestra, Nothing)
        End If

        'If Trim(cboCentroCosto.Text) = "" Then
        '    valido = False
        '    ErrorProvider1.SetError(cboCentroCosto, "Falta Seleccionar Centro de Costo")
        '    camposConError.Add("CCOSTO")
        'Else
        '    ErrorProvider1.SetError(cboCentroCosto, Nothing)
        'End If

        'If Trim(txtCtaMaestra.Text) = "" Or Trim(txtObservacion.Text) = "" Then
        '    valido = False
        '    ErrorProvider1.SetError(txtCtaMaestra, "Falta Ingresar Nro de Cuenta y/o Glosa")
        '    camposConError.Add("CUENTA")
        'Else
        '    ErrorProvider1.SetError(txtCtaMaestra, Nothing)
        'End If
  

        If TxtEmision.Visible = True Then
            If Not IsDate(TxtEmision.Value) Then
                valido = False
                ErrorProvider1.SetError(TxtEmision, "Falta Ingresar Emisión")
                camposConError.Add("EMISIÓN")
            Else
                ErrorProvider1.SetError(TxtEmision, Nothing)
            End If
        End If
        If Not CSng(LblTotalDoc.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(LblTotalDoc, "El Monto debe ser mayor a cero (0)")
            camposConError.Add("TOTALDOC")
        Else
            ErrorProvider1.SetError(LblTotalDoc, Nothing)
        End If




        If Not valido Then
            lblError.Text = "Introduzca y/o Seleccione un valor en  "

            For Each campo In camposConError
                lblError.Text &= campo & ", "
            Next
            lblError.Text = lblError.Text.Substring(0, lblError.Text.Length - 2)
        End If
        Return valido
    End Function

    Private Function GrabarRegistroDoc() As Boolean

        Dim objDlt As New movimiento_bancario

        Dim FEmi, FVence, FReg, FRet, vArray As String, ok, xIdProv As Long
        Dim xMISC, xMIGV As Single, vDireccion As String = ""

        FRet = ""
        FVence = ""
        FReg = ""
        Try

            FEmi = LibreriasFormularios.Formato_Fecha(TxtEmision.Value)

            FReg = LibreriasFormularios.Formato_Fecha(pFecha_Ing)

            xIdProv = 0
            xMISC = 0
            xMIGV = 0

            With objDlt
                If pCodigo > 0 Then
                    .Codigo = pCodigo
                Else
                    .Codigo = -1
                End If

                .Tipo = "S"
                .Codigo_alm = pCodigo_Alm
                .Codigo_CtaCte = 3 'Salida de dinero
                .Codigo_Documento = 21 'Voucher
                .Numero = TxtNroOpe.Text                
                .Codigo_Persona = 0
                .fecha = FEmi.Trim
                .Cancela = FReg.Trim
                .Fecha_Registro = FEmi.Trim


                .NroCuenta = txtCtaMaestra.Text.Trim
                .Centro_Costo = cboCentroCosto.Value
                .Observacion = txtObservacion.Text.Trim

                .Importe = 0
                .Importe_NoGrabado = FormatNumber(Me.lblTotalDoc.Text, 2, TriState.True, , TriState.False)
                .importe_igv = 0
                .Importe_Isc = 0
                .importe_renta = 0

                .Valor_igv = 0
                .Valor_Renta = 0

                .Moneda = "NS" 'cboMoneda.Value
                If txtTipoCambio.Visible = True Then
                    .cambio = txtTipoCambio.Text
                Else
                    .cambio = 0
                End If


                .codigo_ref = 0
                .Codigo_Tip = 1

                .caja = My.Computer.Name
                .Usuario = GestionSeguridadManager.sUsuario
                .Codigo_Usuario = GestionSeguridadManager.idUsuario
                .estado = 1

                vArray = "null"

            End With

            ok = movimiento_bancarioManager.Grabar(objDlt, vArray, vArray, vArray)

            If Not ok > 0 Then
                GrabarRegistroDoc = False
                Exit Function
            End If
            GrabarRegistroDoc = True
            objDlt = Nothing
        Catch ex As Exception
            GrabarRegistroDoc = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Btnayx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnayx.Click
        If ValidarDatos() Then

            If GrabarRegistroDoc() Then
                Call LimpiarControls()
                pCodigo = 0
            End If

            TxtNroOpe.Focus()
        End If
    End Sub

    Private Function LimpiarControls() As Boolean

        TxtNroOpe.Text = ""

        LblTotalDoc.Text = "0.00"

        TxtEmision.Value = Now.Date

    End Function

End Class