
Imports Infragistics.Win
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmActualizar_Mov_Mercaderia
    Public pCodigo As Long = 0, xNew As Boolean = False
    'Para los combos iniciales
    Public dtModulo As DataTable, dtMov As DataTable, dtDoc As DataTable, dtSigno As DataTable
    'Variables
    Public vModulo As Integer = 0, vMovimiento As Integer, vDocumento As Integer, vSigno As String
    Public vReferencia As Boolean, vDscto As Boolean

    Private Sub llenar_Combos()
        Dim st As Boolean = False
        dtModulo = New DataTable
        dtMov = New DataTable
        dtDoc = New DataTable
        dtSigno = New DataTable

        Try

            st = det_mov_mercaderiaManager.GetCombos_Cursor(dtModulo, dtMov, dtDoc)

            With cboModulo
                .DataSource = Nothing
                .DataSource = dtModulo
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCodigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

            With cboMovimiento
                .DataSource = Nothing
                .DataSource = dtMov
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCodigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

            With cboDocumento
                .DataSource = Nothing
                .DataSource = dtDoc
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCodigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

            Dim opcionesv(2) As String, opciones(2) As String
            opcionesv(0) = "+"
            opcionesv(1) = "-"
            opciones(0) = "Positivo"
            opciones(1) = "Negativo"
            With cboSigno
                .DataSource = Nothing
                .DataSource = DosOpcionesManager.GetList("Opciones", opcionesv, opciones)
                .DataBind()
                .ValueMember = "Opcionesv"
                .DisplayMember = "Opciones"
                If .Rows.Count > 0 Then
                    If pCodigo = 0 Then
                        .SelectedRow = cboSigno.GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With


        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Mostrar_Registro()
        cboModulo.Value = vModulo
        cboMovimiento.Value = vMovimiento
        cboDocumento.Value = vDocumento
        cboSigno.Value = vSigno
        ChkIncluir_Ref.Checked = vReferencia
        chkIncluir_Dscto.Checked = vDscto

    End Sub

    Private Sub FrmActualizar_Mov_Mercaderia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_Combos()
        If pCodigo > 0 Then
            Call Mostrar_Registro()
        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub cboModulo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboModulo.InitializeLayout
        cboModulo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboModulo.DisplayLayout.Bands(0).Columns(1).Width = cboModulo.Width
    End Sub


    Private Sub cboMovimiento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMovimiento.InitializeLayout
        cboMovimiento.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboMovimiento.DisplayLayout.Bands(0).Columns(1).Width = cboMovimiento.Width
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        cboDocumento.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboDocumento.DisplayLayout.Bands(0).Columns(1).Width = cboDocumento.Width
    End Sub

    Private Sub cboSigno_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboSigno.InitializeLayout
        cboSigno.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboSigno.DisplayLayout.Bands(0).Columns(1).Width = cboSigno.Width
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim objc As New det_mov_mercaderia
        If MessageBox.Show("¿Desea grabar los datos?", "D'SIAM", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                With objc
                    .Codigo = pCodigo
                    .codigo_modulo = cboModulo.Value
                    .codigo_movimiento = cboMovimiento.Value
                    .codigo_doc = cboDocumento.Value
                    .signo = cboSigno.Value
                    .Incluir_Ref = ChkIncluir_Ref.Checked
                    .Columna_Dscto = chkIncluir_Dscto.Checked
                End With
                det_mov_mercaderiaManager.Grabar(objc, xNew)

                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        objc = Nothing
    End Sub
End Class