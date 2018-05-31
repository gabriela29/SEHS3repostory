
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmCentro_CostoNM    
    Public vAlmacen As Integer, vNombre_Alm As String, vC_Costo As Long, swNuevo As Boolean

    Public ModoVentanaFlotante As Boolean


    Public Function Agregar(ByVal objcc As centro_costo) As Boolean
        Dim Objeto As New centro_costo
        Try
            With Objeto
                .codigo_alm = objcc.codigo_alm
                .centro_costo = objcc.centro_costo
                .nombre = objcc.nombre
                .orden = 0                
                .estado = objcc.estado
                .c_costo_old = objcc.c_costo_old
            End With

            centro_costoManager.Grabar(Objeto, True, 0)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Modificar(ByVal objcc As centro_costo) As Boolean
        Dim Objeto As New centro_costo
        Try
            With Objeto
                .codigo_alm = objcc.codigo_alm
                .centro_costo = objcc.centro_costo
                .nombre = objcc.nombre
                .orden = 0
                .estado = objcc.estado
                .c_costo_old = objcc.c_costo_old
            End With
            centro_costoManager.Grabar(Objeto, False, vC_Costo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim objc As New centro_costo
        If MessageBox.Show("¿Desea grabar los datos?", "D'SIAM", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                objc = EnVariables()
                If swNuevo Then
                    Call Agregar(objc)
                Else
                    Call Modificar(objc)
                End If

                Call FrmCentros_Costo.Listado_Condicion_Detalles(0)
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        objc = Nothing
    End Sub

    Public Function EnVariables() As centro_costo
        Dim objce As New centro_costo

        Try

            With objce
                .codigo_alm = vAlmacen
                .centro_costo = txtC_costo.Text
                .nombre = Trim(txtDescripcion.Text)
                .orden = 0
                .c_costo_old = txtC_Costo_Ant.Text
                .estado = ChkEstado.Checked
            End With
            Return objce
        Catch ex As Exception
            Return objce
            objce = Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function LimpiarControles() As Boolean
        Me.LblCodigo.Text = ""
        Me.txtC_costo.Text = ""
        vC_Costo = 0
        vAlmacen = 0
        vNombre_Alm = ""
        txtC_costo.Text = ""
        txtC_Costo_Ant.Text = ""
        ChkEstado.Checked = False
    End Function

    Private Sub FrmCuenta_CorrienteNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmCuenta_CorrienteNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblAlmacen.Text = vNombre_Alm
        ChkEstado.Checked = True
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    
End Class