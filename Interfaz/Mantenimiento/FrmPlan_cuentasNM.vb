
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmPlan_cuentasNM
    Dim codigo As Integer, vContable, vCtaCte, vSct As Integer, vNombre, vCtaM, vOpcional, vAbrev As String, vNivel As Integer

    Public ModoVentanaFlotante As Boolean


    Public Function Agregar() As Boolean
        Dim Objeto As New plan_cuentas
        Try
            With Objeto
                .codigo = -1
                .cuenta = vContable
                .ctacte = vCtaCte
                .sct = vSct
                .entidad = vOpcional
                .nombrecta = vNombre
                .ctamaestra = vCtaM
                .nivel = vNivel
                .abrev = vAbrev

            End With

            plan_cuentasManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Modificar() As Boolean
        Dim Objeto As New plan_cuentas
        Try
            With Objeto
                .codigo = codigo
                .cuenta = vContable
                .ctacte = vCtaCte
                .sct = vSct
                .entidad = vOpcional
                .nombrecta = vNombre
                .ctamaestra = vCtaM
                .nivel = vNivel
                .abrev = vAbrev
            End With
            plan_cuentasManager.Grabar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "D'SIAM", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If EnVariables() Then
                    If Trim(Me.LblCodigo.Text) = "" Then
                        Call Agregar()
                    Else
                        Call Modificar()
                    End If
                End If
                Call FrmPlan_Cuentas.ListarCondicion()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function EnVariables() As Boolean
        Try
            If Not Trim(LblCodigo.Text) = "" Then
                codigo = CInt(LblCodigo.Text)
            End If
            vContable = CInt(TxtContable.Text)
            vCtaCte = IIf(Trim(TxtCtaCte.Text) = "", 0, Trim(TxtCtaCte.Text))
            vSct = IIf(Trim(TxtSct.Text) = "", 0, Trim(TxtSct.Text))
            vOpcional = IIf(Trim(txtOpcional.Text) = "", "", Trim(txtOpcional.Text))
            vNombre = Trim(TxtNombre.Text)
            vCtaM = Trim(TxtCtaMaestra.Text)
            vNivel = CInt(TxtNivel.Text)
            vAbrev = Trim(txtAbrev.Text)
            EnVariables = True

        Catch ex As Exception
            MsgBox(ex.Message)
            EnVariables = False
        End Try
    End Function

    Public Function LimpiarControles() As Boolean
        Me.LblCodigo.Text = ""
        Me.TxtContable.Text = ""        
        Me.TxtCtaCte.Text = ""
        TxtSct.Text = ""
        TxtNombre.Text = ""
        TxtCtaMaestra.Text = ""
        TxtNivel.Text = ""
        txtAbrev.Text = ""
        txtOpcional.Text = ""
    End Function

    Private Sub FrmConcepto_AcademicoNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub TxtContable_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContable.Validated
        TxtCtaMaestra.Text = Trim(TxtContable.Text) & Trim(TxtCtaCte.Text) & Trim(TxtSct.Text) & Trim(txtOpcional.Text)
    End Sub


    Private Sub TxtCtaCte_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCtaCte.Validated
        TxtCtaMaestra.Text = Trim(TxtContable.Text) & Trim(TxtCtaCte.Text) & Trim(TxtSct.Text) & Trim(txtOpcional.Text)
    End Sub

    Private Sub TxtSct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSct.Validated
        TxtCtaMaestra.Text = Trim(TxtContable.Text) & Trim(TxtCtaCte.Text) & Trim(TxtSct.Text) & Trim(txtOpcional.Text)
    End Sub

    Private Sub TxtNombre_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNombre.Validated
        TxtCtaMaestra.Text = Trim(TxtContable.Text) & Trim(TxtCtaCte.Text) & Trim(TxtSct.Text) & Trim(txtOpcional.Text)
    End Sub

    Private Sub txtOpcional_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOpcional.Validated
        TxtCtaMaestra.Text = Trim(TxtContable.Text) & Trim(TxtCtaCte.Text) & Trim(TxtSct.Text) & Trim(txtOpcional.Text)
    End Sub
End Class