

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmSubCategoriaNM


    Public pCodigo As Integer, pCodigo_Cat As Integer
    Public rCodigo As Integer
    Public ModoVentanaFlotante As Boolean

    Private Sub llenar_combos()
        Try
            Me.cboCategoria.DataSource = categoriaManager.GetList("")
            Me.cboCategoria.DataBind()
            Me.cboCategoria.ValueMember = "categoriaid"
            Me.cboCategoria.DisplayMember = "nombre"
            Me.cboCategoria.MinDropDownItems = 2
            Me.cboCategoria.MaxDropDownItems = 4
            If pCodigo = 0 Then
                cboCategoria.Value = pCodigo_Cat
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Mostrar_Datos()
        Dim Objc As subcategoria

        Objc = subcategoriaManager.GetItem(pCodigo)

        If Not Objc Is Nothing Then
            cboCategoria.Value = Objc.categoriaid
            txtNombre.Text = Objc.nombre
            txtAbrev.Text = Objc.abrev
        End If
        Objc = Nothing

    End Sub


    Public Function Actualizar() As Boolean
        Dim Objeto As New subcategoria
        Try
            With Objeto
                If pCodigo > 0 Then
                    .subcategoriaid = pCodigo
                Else
                    .subcategoriaid = -1
                End If
                .categoriaid = cboCategoria.Value
                .nombre = TxtNombre.Text.Trim
                .abrev = txtAbrev.Text.Trim

            End With
            rCodigo = subcategoriaManager.Grabar(Objeto)
            If rCodigo > 0 Then
                Me.Close()
            End If
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not (cboCategoria.Text.Trim = "" Or txtNombre.Text.Trim = "") Then
                    Call Actualizar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FrmSubCategoriaNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmSubCategoriaNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()

        If pCodigo > 0 Then
            Call Mostrar_Datos()
        End If

    End Sub

    Private Sub cboCategoria_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCategoria.InitializeLayout
        With cboCategoria.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboCategoria.Width
            .Columns(2).Hidden = True
        End With
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
End Class