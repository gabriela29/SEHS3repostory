

Imports CapaLogicaNegocio
Imports CapaLogicaNegocio.BLL
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarVentaF
    Public xcodigoId As Long, xnombre_c As String, xcodigo_sunat As String, xnumero As String, xtipo_documento_per As String, xnumero_doc_per As String, xpersona As String
    Public xafecto As Long, xnoafecto As Long
    Public dtDatos As DataTable




    Private Sub Mostrar_Registro() 'AQUI SE REGISTRARA LOS DATOS DEL FORMULARIO
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
            txtnumeror.Text = dtRow("total")


            txtcantidadtotal.Text = dtRow("total")









        Next


    End Sub





End Class