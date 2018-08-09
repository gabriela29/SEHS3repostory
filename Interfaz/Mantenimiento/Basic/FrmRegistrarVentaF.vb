


Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid



Public Class Registrar_Ventas
    Public pregistrarvId
    Public ModoVentanaFlotante As Boolean
    Public vcodigo As Integer
    Public numero As String
    Public swNuevo As Boolean


    Private Sub Mostrar_Datos()

        Dim Objc As CapaObjetosNegocio.registrarv

        Objc = registrarvManager.GetItem(vcodigo)

        If Not Objc Is Nothing Then
            almacenText.Text = Objc.almacenaid
            Textcodigo_doc.Text = Objc.codigo_doc
            txtcod_persona.Text = Objc.codigo_per
            datefechae.Value = Objc.emision
            txtnombrec.Text = Objc.nombre_corto
            txtcodigosu.Text = Objc.codigo_sunat
            txtnumerop.Text = Objc.numero
            txtdocumentot.Text = Objc.tipo_doc_per
            txtdocumenton.Text = Objc.numero_doc_per
            txtpersona.Text = Objc.persona
            txtafecto.Text = Objc.afecto
            txtnoafecto.Text = Objc.noafecto
            txtigv.Text = Objc.igv
            txtdescuento.Text = Objc.descuento
            txtcantidadtotal.Text = Objc.total
            datefechao.Value = Objc.fecha_doc_ori
            txtsigno.Text = Objc.signo
            txtserieint.Text = Objc.serie_int
            txtnumeroint.Text = Objc.numero_int
            labeltabla.Text = Objc.tabla
            labeltablaid.Text = Objc.idtabla
            labelmes.Text = Objc.mes
            labelanio.Text = Objc.anio
        End If
        Objc = Nothing

    End Sub

    Private Function Actualizar() As Boolean

        Dim Objeto As New CapaObjetosNegocio.registrarv
        Dim fechae As String = "", ok As Long
        Dim fechao As String = "", si As Long

        Try
            fechae = LibreriasFormularios.Formato_Fecha(datefechae.Value)
            fechao = LibreriasFormularios.Formato_Fecha(datefechao.Value)

            With Objeto
                If vcodigo > 0 Then
                    ' .codigo_per = vcodigo
                Else
                    ' .codigo_per = -1
                End If
                .almacenaid = almacenText.Text.Trim
                .codigo_doc = Textcodigo_doc.Text.Trim
                .codigo_per = txtcod_persona.Text.Trim
                .emision = fechae
                .nombre_corto = txtnombrec.Text.Trim
                .codigo_sunat = txtcodigosu.Text.Trim
                .numero = txtnumerop.Text.Trim
                .tipo_doc_per = txtdocumentot.Text.Trim
                .numero_doc_per = txtdocumenton.Text.Trim
                .persona = txtpersona.Text.Trim
                .afecto = txtafecto.Text.Trim
                .noafecto = txtnoafecto.Text.Trim
                .igv = txtigv.Text.Trim
                .descuento = txtdescuento.Text.Trim
                .total = txtcantidadtotal.Text.Trim
                .codigo_doc = Textcodigo_doc.Text.Trim
                .fecha_doc_ori = fechao
                .signo = txtsigno.Text.Trim
                .serie_int = txtserieint.Text.Trim
                .numero_int = txtnumeroint.Text.Trim
                .tabla = labeltabla.Text.Trim
                .idtabla = labeltablaid.Text.Trim
                .mes = labelmes.Text.Trim
                .anio = labelanio.Text.Trim

            End With
            registrarvManager.Grabar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub btnCerrar1_Click(sender As Object, e As EventArgs) Handles btnCerrar1.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not txtnumerop.Text.Trim = "" Then
                    If Actualizar() Then
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Debe ingresar un nombre", "AVISO", MessageBoxButtons.OK)
                End If

                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FrmRegistrarVentaF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vcodigo > 0 Then
            Call Mostrar_Datos()
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmRegistrarVentaF_keyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If

    End Sub
End Class