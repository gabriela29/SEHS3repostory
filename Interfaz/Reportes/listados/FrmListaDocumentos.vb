
Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop
Imports Telerik.WinControls.UI.Docking

Public Class FrmListaDocumentos

    Private Sub llenar_combos()
        Try

            With cboDocumento
                .DataSource = Nothing
                .DataSource = GestionTablas.dtperdoc
                .Refresh()
                .ValueMember = "documentoid"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End With

            With Me.cboAlmacen
                .DataSource = GestionTablas.dtFAlmacen
                '.DataBind()
                .ValueMember = "almacenid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDocumento.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub FrmListaDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenar_combos()
        cboDesde.Value = ("01/" & Now.Month & "/" & Now.Year)
        cboHasta.Value = Now.Date
    End Sub

    Private Sub chkxAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles chkxAlmacen.CheckedChanged
        If chkxAlmacen.CheckedValue Then
            cboAlmacen.Text = ""
        End If
    End Sub
End Class