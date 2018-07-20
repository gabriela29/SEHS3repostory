

Imports CapaLogicaNegocio
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarVentaF
    Public pregistrarvId As Long, swNuevo As Boolean
    Public xalmacenaid As Long, xnombre_c As String, xcodigo_sunat As String, xnumero As String, xtipo_documento_per As String, xnumero_doc_per As String, xpersona As String
    Public xafecto As Long, xnoafecto As Long

    Public dtDatos As DataTable

    Private Sub txtnombrec_ValueChanged(sender As Object, e As EventArgs) Handles txtnombrec.ValueChanged

    End Sub

    Private Sub UgvDatos_Click(sender As Object, e As EventArgs) Handles UgvDatos.Click

    End Sub

    Private Sub Mostrar_Registro()
        Dim dtRow As DataRow

        For Each dtRow In dtDatos.Rows
            datefechae.Value = dtRow("fecha_emision")
            txtnombrec.Text = dtRow("nombre_corto")
            txtcodigosu.Text = dtRow("codigo_sunat")
            txtnumerop.Text = dtRow("numero")
            txtdocumentot.Text = dtRow("tipo_doc_per")
            txtdocumenton.Text = dtRow("numero_doc_per")
            txtpersona.Text = dtRow("persona")
            txtafecto.Text = dtRow("afecto")
            txtnoafecto.Text = dtRow("noafecto")
            txtigv.Text = dtRow("igv")
            txtdescuento.Text = dtRow("dscto")
            datefechao.Value = dtRow("fecha_doc_ori")
            txtcodigoo.Text = dtRow("cod_doc_ori")
            txtserieo.Text = dtRow("serie_doc_ori")
            txtnumeror.Text = dtRow("numero_doc_ori")
            txtsigno.Text = dtRow("signo")
            txtserieint.Text = dtRow("serie_int")
            txtnumeroint.Text = dtRow("numero_int")
            labeltabla.Text = dtRow("tabla")
            labeltablaid.Text = dtRow("tablaid")
            labelmes.Text = dtRow("mes")
            labelaño.Text = dtRow("anio")

        Next

    End Sub


    Private Sub btnCerrar1_Click(sender As Object, e As EventArgs) Handles btnCerrar1.Click
        Me.Close()
    End Sub


    Private Sub FrmRegistrarVentaF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmRegistrarVentaF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not bwdatos.IsBusy Then

            bwdatos.RunWorkerAsync()
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim CamposConError As New Specialized.StringCollection
        Dim campo As String


        If Not IsDate(datefechae.Value) Then

            valido = False
            ErrorProvider1.SetError(datefechae, "Fecha de emisión no válido")
            CamposConError.Add("FECHA")
        Else
            ErrorProvider1.SetError(datefechae, Nothing)
        End If

        If Trim(txtnombrec.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtnombrec, "Debe tener datos personales")
            CamposConError.Add("NOMBRE")
        Else
            ErrorProvider1.SetError(txtnombrec, Nothing)
        End If

        If Trim(txtcodigosu.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtcodigosu, "CODIGO SUNAT NO VALIDO")
            CamposConError.Add("CODIGO-SUNAT")
        Else
            ErrorProvider1.SetError(txtcodigosu, Nothing)

        End If

        If Trim(txtnumerop.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtnumerop, "NUMERO NO VALIDO")
            CamposConError.Add("NUMERO")
        Else
            ErrorProvider1.SetError(txtnumerop, Nothing)

        End If

        If Trim(txtdocumenton.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtdocumenton, "NUMERO NO VALIDO")
            CamposConError.Add("NUMERO")
        Else
            ErrorProvider1.SetError(txtdocumenton, Nothing)

        End If

        If Trim(txtpersona.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtpersona, "NOMBRE DE PERSONA NO VALIDO")
            CamposConError.Add("PERSONA")
        Else
            ErrorProvider1.SetError(txtpersona, Nothing)

        End If

        If Trim(txtafecto.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtafecto, "AFECTO INCORRECTO")
            CamposConError.Add("AFECTO")
        Else
            ErrorProvider1.SetError(txtpersona, Nothing)

        End If

        If Trim(txtnoafecto.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtnoafecto, "NO-AFECTO INCORRECTO")
            CamposConError.Add("NO-AFECTO")
        Else
            ErrorProvider1.SetError(txtpersona, Nothing)

        End If

        If Trim(txtigv.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtigv, "IGV INVALIDO")
            CamposConError.Add("IGV")
        Else
            ErrorProvider1.SetError(txtigv, Nothing)

        End If

        If Trim(txtdescuento.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtdescuento, "Debe tener un descuento")
            CamposConError.Add("DESCUENTO")
        Else
            ErrorProvider1.SetError(txtdescuento, Nothing)

        End If

        If Trim(txtcantidadtotal.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtcantidadtotal, "Total no calculado")
            CamposConError.Add("TOTAL")
        Else
            ErrorProvider1.SetError(txtcantidadtotal, Nothing)

        End If

        If Not IsDate(datefechao.Value) Then

            valido = False
            ErrorProvider1.SetError(datefechao, "Fecha de origen válido")
            CamposConError.Add("FECHA")
        Else
            ErrorProvider1.SetError(datefechao, Nothing)
        End If

        If Trim(txtcodigoo.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtcodigoo, "Debe ingresar el codigo")
            CamposConError.Add("CODIGO")
        Else
            ErrorProvider1.SetError(txtcodigoo, Nothing)

        End If

        If Trim(txtserieo.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtserieo, "Debe ingresar la serie")
            CamposConError.Add("SERIE")
        Else
            ErrorProvider1.SetError(txtserieo, Nothing)

        End If

        If Trim(txtnumeror.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtnumeror, "Debe ingresar el numero de orden")
            CamposConError.Add("NUMERO-ORDEN")
        Else
            ErrorProvider1.SetError(txtnumeror, Nothing)

        End If

        If Trim(txtsigno.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtsigno, "Debe ingresar el signo")
            CamposConError.Add("SIGNO")
        Else
            ErrorProvider1.SetError(txtsigno, Nothing)

        End If

        If Trim(txtserieint.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtserieint, "La serie no esta registrada")
            CamposConError.Add("SERIE-INT")
        Else
            ErrorProvider1.SetError(txtserieint, Nothing)

        End If

        If Trim(txtnumeroint.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtnumeroint, "Debe ingresar el numero")
            CamposConError.Add("NUMERO-INT")
        Else
            ErrorProvider1.SetError(txtnumeroint, Nothing)

        End If



        If labeltabla.Text = "" Then
            valido = False
            ErrorProvider1.SetError(labeltabla, "FALTA REGISTRAR TABLA ")
            CamposConError.Add("tabla")
        Else
            ErrorProvider1.SetError(labeltabla, Nothing)
        End If

        If labeltablaid.Text = "" Then
            valido = False
            ErrorProvider1.SetError(labeltablaid, "Falta seleccionar Estado Civil ")
            CamposConError.Add("Tablaid")
        Else
            ErrorProvider1.SetError(labeltablaid, Nothing)
        End If

        If labelaño.Text = "" Then
            valido = False
            ErrorProvider1.SetError(labelaño, "Falta Mes ")
            CamposConError.Add("Mes")
        Else
            ErrorProvider1.SetError(labelaño, Nothing)
        End If

        If Not valido Then
            lblErrorR.Text = "Falta un valor en: "

            For Each campo In CamposConError
                lblErrorR.Text &= campo & ", "
            Next
            lblErrorR.Text = lblErrorR.Text.Substring(0, lblErrorR.Text.Length - 2)
        End If
        Return valido
    End Function

    Private Function GrabarRegistroDoc() As Boolean 'AQUI SE REGISTRARA LOS DATOS DEL FORMULARIO


        Dim objR As New registrarv
        Dim dgvRw As UltraGridRow
        Dim fechae As String = "", ok As Long
        Dim fechao As String = "", si As Long
        Dim vacodigo_per As String = "null"

        Try
            fechae = LibreriasFormularios.Formato_Fecha(datefechae.Value)
            fechao = LibreriasFormularios.Formato_Fecha(datefechao.Value)

            With objR
                If xalmacenaid > 0 Then
                    .almacenaid = xalmacenaid

                Else
                    .almacenaid = 0
                End If
                .codigo_per = Textcodigo_doc.Text.Trim & ""
                .emision = fechae
                .nombre_corto = txtnombrec.Text.Trim & ""
                .codigo_sunat = txtcodigosu.Text.Trim & ""
                .numero = txtnumerop.Text.Trim & ""
                .tipo_doc_per = txtdocumentot.Text.Trim & ""
                .numero_doc_per = txtdocumenton.Text.Trim & ""
                .persona = txtpersona.Text.Trim & ""
                .afecto = txtafecto.Text.Trim & ""
                .noafecto = txtnoafecto.Text.Trim & ""
                .igv = txtigv.Text.Trim & ""
                .descuento = txtdescuento.Text.Trim & ""
                .total = txtcantidadtotal.Text.Trim & ""
                .codigo_doc = Textcodigo_doc.Text.Trim & ""
                .fecha_doc_ori = fechao
                .cod_doc_ori = txtcodigoo.Text.Trim & ""
                .serie_doc_ori = txtserieo.Text.Trim & ""
                .numero_doc_ori = txtnumeror.Text.Trim & ""
                .signo = txtsigno.Text.Trim & ""
                .serie_int = txtserieint.Text.Trim & ""
                .numero_int = txtnumeroint.Text.Trim & ""
                .tabla = labeltabla.Text.Trim & ""
                .idtabla = labeltablaid.Text.Trim & ""
                .mes = labelmes.Text.Trim & ""
                .anio = labelaño.Text.Trim & ""

            End With
            ok = registrarvManager.Grabar(objR)

            If ok > 0 Then
                GrabarRegistroDoc = True
            End If
            objR = Nothing
        Catch ex As Exception
            GrabarRegistroDoc = False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de guardar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If GrabarRegistroDoc() Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Public Sub Buscar_Registrarv(ByVal vTipo As String, ByVal vNumero As String)
        Dim objRe As New registrarv

        If Not objRe Is Nothing Then


            If objRe.codigo_per > 0 Then
                MessageBox.Show("Documento ya existe en la base datos", "AVISO", MessageBoxButtons.OK)

                labelmes.Text = objRe.mes
                labelaño.Text = objRe.anio


            End If

        End If









    End Sub




End Class