﻿
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win

Public Class FrmActualizar_Item_Cons
    Public pCodigo_Almacen As Integer
    Public pCodigo_Producto As Long
    Public pNombre_Producto As String
    Public pCantidad As Double
    Public pPrecio As Single
    Public pDescuento As Single
    Public pAfecto_IGV As Boolean
    Public pAfecto_Dzmo As Boolean
    Public pNuevo As Boolean

    Public pVer_Descuento As Boolean
    Public pVer_Precio As Boolean
    Public pVer_Comision As Boolean

    Public pComision As Single

    Public pCantidad_Adicional As Integer
    Public vStock As Long
    Public pDevolucion As Boolean
    '
    Public pCodigo_Grupo As Integer
    Public gQue_Form_Llama As String

    Public pTipoDscto As Integer
    Public pXctajeDscto As Boolean
    Public pExonerado As Boolean

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Not Single.Parse(txtCantidad.Text) > 0 Then
            MsgBox("La cantidad no puede ser cero . . .", vbInformation, "Cantidad incorrecta")
            txtCantidad.Focus()
            Exit Sub
        End If
        'If Gestion_Permisos_Especiales.venForzarConStock Then
        If Single.Parse(txtCantidad.Text) > Single.Parse(lblStock.Tag) Then
            MsgBox("No hay stock suficiente para vender la cantidad ingresada.", vbInformation, "Información")
            txtCantidad.Focus()
            Exit Sub
        End If
        'End If
        If gQue_Form_Llama = "COLPORTAJE" Then
            If pNuevo Then
                If FrmActualizar_Consignacion.Agregar_Producto(pCodigo_Producto, lblProducto.Text, CSng(txtCantidad.Text), CSng(txtPrecio.Text), CSng(txtDscto.Text), 0, Me.pAfecto_IGV, Me.pAfecto_Dzmo) = False Then
                    MsgBox("El producto ya esta registrado en el documento. . .", vbInformation, "Información")
                    txtCantidad.Focus()
                    Exit Sub
                End If
            Else
                'frmVenta.Edit_Item(pCodigo_Producto, CDbl(txtCantidad.Text), CDbl(txtPrecio.Text), CDbl(txtDescuento.Text), CDbl(txtComision.Text))
            End If
            'FrmActualizar_Consignacion.txtBuscar.Focus()
            Me.Close()
        ElseIf gQue_Form_Llama = "DEVOLUCION_BLK" Then
            If pNuevo Then
                If FrmDevolver_Bloque.Agregar_Producto(pCodigo_Producto, lblProducto.Text, CSng(txtCantidad.Text), CSng(txtPrecio.Text), CSng(txtDscto.Text), 0, Me.pAfecto_IGV, Me.pAfecto_Dzmo) = False Then
                    MsgBox("El producto ya esta registrado en el documento. . .", vbInformation, "Información")
                    txtCantidad.Focus()
                    Exit Sub
                End If
            Else
                'frmVenta.Edit_Item(pCodigo_Producto, CDbl(txtCantidad.Text), CDbl(txtPrecio.Text), CDbl(txtDescuento.Text), CDbl(txtComision.Text))
            End If
            'FrmActualizar_Consignacion.txtBuscar.Focus()
            Me.Close()

        ElseIf gQue_Form_Llama = "BOLETEO_COLP" Then

            If FrmBoleteo_Colportor.Agregar_Producto(pCodigo_Producto, lblProducto.Text, Single.Parse(txtCantidad.Text), Single.Parse(txtPrecio.Text), _
                                                     Single.Parse(txtDscto.Text), 0, Me.pAfecto_IGV, Me.pAfecto_Dzmo, pNuevo, 0, False, False, 0) = False Then
                MsgBox("El producto ya esta registrado en el documento. . .", vbInformation, "Información")
                txtCantidad.Focus()
                Exit Sub
            End If

      Me.Close()

      Me.Close()

    End If
    End Sub

    Private Sub FrmActualizar_Item_Cons_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmActualizar_Item_Venta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'txtPrecio.ReadOnly = Not Gestion_Permisos_Especiales.venCambiar_Precio
            If gQue_Form_Llama = "DETALLE_GUIA" Then
                '    Label2.Caption = "Peso:"
                'Else
                '    Label2.Visible = pVer_Precio
                '    txtPrecio.Visible = pVer_Precio
            End If

            If pVer_Descuento Then
                txtDscto.Visible = True
                chkEsXctajeDscto.Visible = True
            Else
                txtDscto.Visible = False
                chkEsXctajeDscto.Visible = False
            End If

            If Me.pAfecto_IGV Then
                lblAfecto.Text = "AFECTO A IGV"
            Else
                lblAfecto.Text = "NO AFECTO A IGV"
            End If

            If Me.pAfecto_Dzmo Then
                lblAfectoDzmo.Text = "AFECTO A DIEZMO"
            Else
                lblAfectoDzmo.Text = "NO AFECTO A DIEZMO"
            End If

            'If pVer_Comision Then
            '    Label5.Visible = (comModo_Comision = vUna_Sola_Comision)
            '    txtComision.Visible = (comModo_Comision = vUna_Sola_Comision)
            'Else
            '    Label5.Visible = False
            '    txtComision.Visible = False
            'End If
            'If Not txtComision.Visible Then
            '    Label3.Top = Label5.Top
            '    txtDescuento.Top = txtComision.Top
            'End If

            lblProducto.Text = pNombre_Producto
            txtCantidad.Text = FormatNumber(pCantidad, 0, vbTrue)
            txtPrecio.Text = FormatNumber(pPrecio, 2, vbTrue)
            'txtComision.Text = FormatNumber(pComision, 2, vbTrue)
            'txtDescuento.Text = FormatNumber(pDescuento, 2, vbTrue)

            If Me.pCantidad_Adicional > 0 Then
                vStock = vStock + Me.pCantidad_Adicional
            End If
            lblStock.Text = FormatNumber(vStock, 0, vbTrue)
            lblStock.Tag = vStock


            If Gestion_Permisos_Especiales.venForzarConStock Then
                Me.lblMsgSstock.Text = "El sistema requiere stock para vender"
            Else
                Me.lblMsgSstock.Text = "El sistema no requiere stock para vender"
            End If
            'imgCabecera.Picture = MDIForm1.imgMonitorBig.Picture
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            txtPrecio.Focus()            
        End If
    End Sub

    Private Sub txtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            If pVer_Descuento Then
                txtDscto.Focus()
            Else
                BtnGrabar.Focus()
            End If

        ElseIf e.KeyCode = Keys.Up Then
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtDscto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDscto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            BtnGrabar.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPrecio.Focus()
        End If
    End Sub

End Class