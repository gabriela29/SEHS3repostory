Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio
Imports CapaObjetosNegocio.BO


Public Class FrmCuentaCo
    Public VCodigo As Integer, pCodigo_banco As Integer
    Public rCodigo As Integer
    Public ModoVentanaFlotante As Boolean

    Private Sub llenar_Combos()

        Try
            Me.cbobanco.DataSource = bancoManager.GetList("")
            Me.cbobanco.DataBind()
            Me.cbobanco.ValueMember = "bancoid"
            Me.cbobanco.DisplayMember = "nombre"
            Me.cbobanco.MinDropDownItems = 2
            Me.cbobanco.MaxDropDownItems = 4
            If VCodigo = 0 Then
                cbobanco.Value = pCodigo_banco
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub Mostrar_Datos()
        Dim Objc As cuentaCorriente

        Objc = CuentaCoManager.GetItem(VCodigo)

        If Not Objc Is Nothing Then
            cbobanco.Value = Objc.bancoid
            ' textbancoid.Text = Objc.bancoid
            txtnumero.Text = Objc.numero
            txtempresaid.Text = Objc.empresaid
            txtAbreviatura.Text = Objc.abreviatura
            txtsucursal.Text = Objc.sucursal
            txtreferencia.Text = Objc.referencia
            txtmoneda.Text = Objc.moneda
            txtempresa.Text = Objc.empresa

        End If
        Objc = Nothing

    End Sub





    Public Function Actualizar() As Boolean
        Dim Objeto As New cuentaCorriente
        Try
            With Objeto
                If VCodigo > 0 Then
                    .ctacteid = VCodigo
                Else
                    .ctacteid = -1

                End If

                .bancoid = cbobanco.Value
                .empresaid = txtempresaid.Text.Trim
                .numero = txtnumero.Text.Trim
                .abreviatura = txtAbreviatura.Text.Trim
                .sucursal = txtsucursal.Text.Trim
                .referencia = txtreferencia.Text.Trim
                .moneda = txtmoneda.Text.Trim
                .empresa = txtempresa.Text.Trim

            End With
            rCodigo = CuentaCoManager.Grabar(Objeto)
            If rCodigo > 0 Then
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not (cbobanco.Text.Trim = "" Or txtnumero.Text.Trim = "") Then
                    Call Actualizar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cbobanco_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbobanco.InitializeLayout
        With cbobanco.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cbobanco.Width
            .Columns(2).Hidden = True
        End With
    End Sub

    Private Sub FrmCuentaCo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub FrmCuentaCo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_Combos()

        If VCodigo > 0 Then
            Call Mostrar_Datos()
        End If
    End Sub




End Class