Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class FrmRpt_Compras

    Private Sub llenar_combos()
        Try

            With cboDocumento
                .DataSource = Nothing
                .DataSource = documentoManager.GetList("")
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Permiso_Impresion()
        'Dim ObjPerm As New permisos_impresion
        'Dim vCodigo_Permi As Long = 0, NameRpt As String = "", vSerieTk As String = ""
        'vCodigo_Permi = permisos_impresionManager.Existe_Codigo(GestionSeguridadManager.idUsuario, lblUnidad_Negocio.Tag, "abc", cboDocumento.Value, 0)
        'If vCodigo_Permi > 0 Then
        '    ObjPerm = permisos_impresionManager.GetItem(vCodigo_Permi)
        '    If Not ObjPerm Is Nothing Then
        '        NameRpt = ObjPerm.formato
        '        vSerieTk = ObjPerm.serie_TK
        '        If Not System.IO.File.Exists(NameRpt) Then
        '            MessageBox.Show("No existe el archivo: " & NameRpt, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '            BtnBuscar.Visible = False
        '        Else
        '            BtnBuscar.Visible = True
        '        End If
        '    End If
        'End If
        'ObjPerm = Nothing
        'If NameRpt.Trim = "" Then
        '    LblRuta.Text = "NO TIENE PERMISO DE IMPRESIÓN o NO SELECCIONÓ EL FORMATO!!!"
        '    lblSerieTK.Text = ""
        '    BtnBuscar.Visible = False
        'Else
        '    LblRuta.Text = NameRpt
        '    lblSerieTK.Text = vSerieTk
        '    BtnBuscar.Visible = True
        'End If

    End Sub

    Private Sub FrmRpt_Documentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()

        picAjaxBig.Visible = False
        CrystalReportViewer1.Visible = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If LblRuta.Text = "" Then
            MessageBox.Show("No tiene permiso de impresion o el Archivo no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Not bwData.IsBusy Then
                picAjaxBig.Visible = True
                bwData.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bwData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwData.DoWork
        Dim rpt As New ReportDocument        
        Dim xCod_uni As Integer = 0, vCogio_Doc As Integer = 0
        Dim vNumDesde As Long = 0, vNumHasta As Long = 0
        Dim DtPr As New DataTable

        Try


            If Not Trim(lblUnidad_Negocio.Text) = "" Then
                xCod_uni = CInt(lblUnidad_Negocio.Tag)
            End If
            If Not Trim(cboDocumento.Text) = "" Then
                vCogio_Doc = CInt(cboDocumento.Value)
            End If

            'If ChkFecha.Checked Then
            '    vDesde = Year(Me.CboFecha1.Value) & "/" & Format(Month(Me.CboFecha1.Value), "00") & "/" & Format(Day(Me.CboFecha1.Value), "00")
            '    vHasta = Year(Me.CboFecha2.Value) & "/" & Format(Month(Me.CboFecha2.Value), "00") & "/" & Format(Day(Me.CboFecha2.Value), "00")
            'End If
            If Not IsNumeric(txtNumDesde.Text) Then
                MessageBox.Show("Debe Indicar el número de inicio del Documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Not IsNumeric(txtNumHasta.Text) Then
                MessageBox.Show("Debe Indicar hasta que número desea mostra el Documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If CSng(txtNumDesde.Text) > CSng(txtNumHasta.Text) Then
                MessageBox.Show("El número inicial no debe ser mayor al número final a mostra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                vNumDesde = txtNumDesde.Value
                vNumHasta = txtNumHasta.Value
            End If

            ' create and bind sample DataSet
            ''DtPr = provision_legalManager.Rpt_Provision_Print_Documentos(0, xCod_uni, "", "", vNumDesde, vNumHasta, vCogio_Doc)
            ''e.Result = DtPr
        Catch ex As Exception
            e.Result = Nothing
            MessageBox.Show("El número inicial no debe ser mayor al número final a mostra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub bwData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwData.RunWorkerCompleted
        ' Llenar DataSet ya sea desde una base de datos, un web service, o datos ingresados por el usuario
        Dim dsDatos As New DataTable
        dsDatos = CType(e.Result, DataTable)
        lblRegistros.Text = dsDatos.Rows.Count & " Registros Mostrados..."
        ' Creamos el objeto
        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        ' Indicamos la ruta del archivo del reporte que requerimos. En este caso suponemos que está en la raiz de nuestro proyecto
        'rpt.FileName = "D:\DiscoC\SoftwareColegio\Interfaz\Reportes\miBoleta.rpt" 'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)

        rpt.Load(LblRuta.Text, OpenReportMethod.OpenReportByDefault)


        ' Establecemos nuestro DataSet como origen de datos de nuestro reporte
        CrystalReportViewer1.Visible = True
        rpt.SetDataSource(dsDatos)
        If chkBoleta.Checked = False Then
            rpt.SetParameterValue(0, lblSerieTK.Text)
        End If
        ' Indicamos al Report Viewer cual es el reporte que queremos mostrar
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.DisplayStatusBar = True
        CrystalReportViewer1.Show()
        picAjaxBig.Visible = False
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "DOCUMENTO"
            .Columns(1).Width = cboDocumento.Width
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True


        End With
    End Sub

    Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
        LblRuta.Text = ""
        Call Permiso_Impresion()
    End Sub
End Class