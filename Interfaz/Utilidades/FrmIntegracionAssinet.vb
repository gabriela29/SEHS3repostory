Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.Web
Imports System.Xml
Imports System.IO
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Phoenix.sehs
Imports System.ServiceModel
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class FrmIntegracionAssinet
    Public pAdress As String = "", pEntidad As Integer = 0
    Dim pXml As String = ""
    Private Sub cboOpciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpciones.SelectedIndexChanged
        pXml = ""
        txtEntidad.ReadOnly = True
        lblFecha.Visible = False
        cboFecha.Visible = False
        lblAnio.Visible = False
        txtAnio.Visible = False
        txtServicio.Visible = False
        txtResult.Text = ""
        dgvListado.DataSource = Nothing
        utTab.Tabs(0).Selected = True

    If cboOpciones.Text = "Tipo Monedas" Then
      txtResult.Text = "Obtener los tipos de monedas"

    ElseIf cboOpciones.Text = "Plan de Cuentas" Then
      txtResult.Text = "Obtener el plan de cuentas principal"

    ElseIf cboOpciones.Text = "Sub Cuentas" Then
      lblFecha.Visible = True
      cboFecha.Visible = True
      txtResult.Text = "Obtener el plan cuentas corrientes, requiere fecha y hora desde cuando desea obtener"

    ElseIf cboOpciones.Text = "Plan de Cuentas Auxiliar" Then
      lblAnio.Visible = True
      txtAnio.Visible = True
      txtAnio.Text = Now.Year
      txtResult.Text = "Obtener el plan de cuentas auxiliar requiere año"

    ElseIf cboOpciones.Text = "Otros" Then
      lblFecha.Visible = False
      cboFecha.Visible = False
      lblServicio.Visible = True
      txtServicio.Visible = True
      txtEntidad.ReadOnly = False
      txtResult.Text = "Ingrese el XML con los parámetros y el nombre de la función a obtener"

    End If

    Call Preparar_XML_SEND()
  End Sub

    Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, utExcel, "assinet.xls")
  End Sub

    Private Sub Mostrar_Respuesta(ByVal xmldoc As String)
        Dim sr As New System.IO.StringReader(xmldoc)
        Dim reader As XmlTextReader
        Dim zResult As String = "", zLine As String = ""
        Dim ds As New DataSet()
        Dim Dt As New DataTable

        'Create the XML Reader
        reader = New XmlTextReader(sr)

        ds.ReadXml(reader)
        If ds.Tables.Count > 0 Then
            If cboOpciones.Text = "Tipo Monedas" Then
                dgvListado.DataSource = ds.Tables(6)
            ElseIf cboOpciones.Text = "Plan de Cuentas" Then
                dgvListado.DataSource = ds.Tables(6)
            ElseIf cboOpciones.Text = "Plan de Cuentas Auxiliar" Then
                dgvListado.DataSource = ds.Tables(8)
            ElseIf cboOpciones.Text = "Sub Cuentas" Then
                dgvListado.DataSource = ds.Tables(8)
            ElseIf cboOpciones.Text = "Departamentos" Then
                dgvListado.DataSource = ds.Tables(7)
            Else
                dgvListado.DataSource = ds
            End If

        Else
            dgvListado.DataSource = Nothing

        End If

        txtResult.Text = zResult

        If cboOpciones.Text = "Plan de Cuentas" Then
            Dim DtTemp As New DataTable
            DtTemp = Actiualizar_Grid_PlanCtas()
            dgvListado.DataSource = Nothing
            dgvListado.DataSource = DtTemp
        End If

        lbl.Text = dgvListado.Rows.Count
        'close the reader
        reader.Close()
    End Sub

  Private Sub Preparar_XML_SEND()

    pXml = ""
    If cboOpciones.Text = "Tipo Monedas" Then
      pXml = "<AASIS>" & Chr(13)
      pXml = pXml & " <Context>" & Chr(13)
      pXml = pXml & "  <AccountingEntity>" & txtEntidad.Text & "</AccountingEntity>" & Chr(13)
      pXml = pXml & " </Context>" & Chr(13)
      pXml = pXml & " <Component>" & Chr(13)
      pXml = pXml & "  <Name>CurrencyList</Name>" & Chr(13)
      pXml = pXml & " </Component>" & Chr(13)
      pXml = pXml & " <Parameters/>" & Chr(13)
      pXml = pXml & "</AASIS>" & Chr(13)
      TxtRequest.Text = pXml
    ElseIf cboOpciones.Text = "Plan de Cuentas" Then
      pXml = "<AASIS>" & Chr(13)
      pXml = pXml & " <Context>" & Chr(13)
      pXml = pXml & " <AccountingEntity>" & txtEntidad.Text & "</AccountingEntity>" & Chr(13)
      pXml = pXml & " </Context>" & Chr(13)
      pXml = pXml & " <Component>" & Chr(13)
      pXml = pXml & " <Name>ChartOfAccounts</Name>" & Chr(13)
      pXml = pXml & " </Component>" & Chr(13)
      pXml = pXml & " <Parameters/>" & Chr(13)
      pXml = pXml & " </AASIS>" & Chr(13)
      TxtRequest.Text = pXml
    ElseIf cboOpciones.Text = "Plan de Cuentas Auxiliar" Then
      pXml = "<AASIS>" & Chr(13)
      pXml = pXml & " <Context>" & Chr(13)
      pXml = pXml & " <AccountingEntity>" & txtEntidad.Text & "</AccountingEntity>" & Chr(13)
      pXml = pXml & " </Context>" & Chr(13)
      pXml = pXml & " <Component>" & Chr(13)
      pXml = pXml & " <Name>ChartOfAccountsAuxiliary</Name>" & Chr(13)
      pXml = pXml & " </Component>" & Chr(13)
      pXml = pXml & " <Parameters>" & Chr(13)
      pXml = pXml & " <ChartOfAccountsAuxiliaryParams>" & Chr(13)
      pXml = pXml & " <PeriodYear>" & txtAnio.Text & "</PeriodYear>" & Chr(13)
      pXml = pXml & " </ChartOfAccountsAuxiliaryParams>" & Chr(13)
      pXml = pXml & " </Parameters>" & Chr(13)
      pXml = pXml & " </AASIS>" & Chr(13)
      TxtRequest.Text = pXml
    ElseIf cboOpciones.Text = "Sub Cuentas" Then
      pXml = "<AASIS>" & Chr(13)
      pXml = pXml & " <Context>" & Chr(13)
      pXml = pXml & " <AccountingEntity>" & txtEntidad.Text & "</AccountingEntity>" & Chr(13)
      pXml = pXml & " </Context>" & Chr(13)
      pXml = pXml & " <Component>" & Chr(13)
      pXml = pXml & " <Name>SubAccountSyncList</Name>" & Chr(13)
      pXml = pXml & " </Component>" & Chr(13)
      pXml = pXml & " <Parameters>" & Chr(13)
      pXml = pXml & " <SubAccountsSyncListParams>" & Chr(13)
      pXml = pXml & " <UpdatedSince> " & cboFecha.Value & " 01:00:00.00 </UpdatedSince>" & Chr(13)
      pXml = pXml & " </SubAccountsSyncListParams>" & Chr(13)
      pXml = pXml & " </Parameters>" & Chr(13)
      pXml = pXml & " </AASIS>" & Chr(13)
      TxtRequest.Text = pXml
    ElseIf cboOpciones.Text = "Otros" Then

      pXml = TxtRequest.Text
    End If
  End Sub

  Private Function Procesar_Informacion2() As Boolean

    Dim xOk As Boolean = False
    System.Net.ServicePointManager.Expect100Continue = False
    Try

      If pXml = "" Then
        MessageBox.Show("No hay instrucciones a procesar", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Function
      End If

      Dim client As PayloadBusinessClient = New PayloadBusinessClient("BasicHttpBinding_PayloadBusiness")

      pAdress = txtServicio.Text.Trim

      Dim ep = New EndpointAddress(pAdress)

      client.Endpoint.Address = ep

      Dim vXml As String = "", xLoad As String = "", Resp As String = ""

      Dim xmldoc As New XmlDataDocument()

      vXml = pXml

      client.Open()
      If client.State = ServiceModel.CommunicationState.Opened Then

        xLoad = client.Load(vXml)
        vXml = client.Execute(xLoad)
        txtResult.Text = vXml
        'xmldoc = client.Execute(xLoad)
        client.Close()
      End If

      xOk = True
      Call Mostrar_Respuesta(vXml)
      Return xOk
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return xOk
    End Try
  End Function

  Private Sub cboEntidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEntidad.SelectedIndexChanged
        TxtRequest.Text = ""
        txtResult.Text = ""

        dgvListado.DataSource = Nothing

    If cboEntidad.Text = "SEHS" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHS/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7114
    ElseIf cboEntidad.Text = "APCS" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSAPCS/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7312
    ElseIf cboEntidad.Text = "MPS" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMPS/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7912
    ElseIf cboEntidad.Text = "MSOP" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMSOP/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7012
    ElseIf cboEntidad.Text = "MLT" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMLT/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7512
    ElseIf cboEntidad.Text = "MOP" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMOP/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7712
    ElseIf cboEntidad.Text = "MAC" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMAC/Services/Aasi.Net/Integration/PayloadService.svc/basic"
      pEntidad = 7412
    ElseIf cboEntidad.Text = "NORTE" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPN/SEHSNORTE/services/aasi.net/integration/payloadservice.svc/basic"
      pEntidad = 17114
    ElseIf cboEntidad.Text = "MEN" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UE/MEN/services/aasi.net/integration/payloadservice.svc/basic"
      pEntidad = 6312
    ElseIf cboEntidad.Text = "MES" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UE/MES/services/aasi.net/integration/payloadservice.svc/basic"
      pEntidad = 6212
    ElseIf cboEntidad.Text = "UU" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UU/services/aasi.net/integration/payloadservice.svc/basic"
      pEntidad = 8813
    ElseIf cboEntidad.Text = "MMOP" Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/MOP/services/aasi.net/integration/payloadservice.svc/basic"
      pEntidad = 7711
    Else
      pAdress = ""
      pEntidad = 0
    End If
    txtEntidad.Text = pEntidad
        txtServicio.Text = pAdress
    End Sub

    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        btnTransferir.Enabled = False
        If Procesar_Informacion2() Then
            If dgvListado.DataSource Is Nothing Then
                utTab.Tabs(1).Selected = True
            Else
                utTab.Tabs(2).Selected = True
            End If

        End If
        btnTransferir.Enabled = True
    End Sub

    Private Sub FrmIntegracionAssinet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LibreriasFormularios.formatear_grid(dgvListado)
        cboFecha.Value = Now.Date
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        'Me.dgvListado.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'Me.dgvListado.DisplayLayout.Bands(0).SortedColumns.Add("Country", False, True)
        'Me.dgvListado.DisplayLayout.Bands(0).SortedColumns.Add("City", False, True)
        'Me.dgvListado.Rows.ExpandAll(True)
    End Sub

    Private Sub tsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcel.Click
        Call Exportar_Excel()
    End Sub

    Private Function Actiualizar_Grid_PlanCtas() As DataTable
        Dim DtTemp As New DataTable, NwRow As DataRow
        Dim dgvTemp As UltraGridRow

        Dim xVeces As Integer = 0
        ' Dim ObjTv As tabla_virtual

        DtTemp = ClsTablitas.Get_Plan_Cuentas("dtPlanCtas")

        With dgvListado
            If .Rows.Count > 0 Then
                For Each dgvTemp In .Rows
                    If dgvTemp.Band.Index = 0 Then
                        If dgvTemp.Cells("Code").Value > 0 Then
                            NwRow = DtTemp.NewRow
                            NwRow.Item("Code") = dgvTemp.Cells("Code").Value     '    dgvTemp.Cells("Code").Value
                            NwRow.Item("Name") = dgvTemp.Cells("Name").Value
                            NwRow.Item("Id") = dgvTemp.Cells("Id").Value
                            NwRow.Item("IsActive") = CBool(dgvTemp.Cells("IsActive").Value)
                            NwRow.Item("Nature") = (dgvTemp.Cells("Nature").Value)
                            NwRow.Item("ParentCode") = (dgvTemp.Cells("ParentCode").Value)
                            NwRow.Item("ParentId") = dgvTemp.Cells("ParentId").Value
                            NwRow.Item("Account_Id") = dgvTemp.Cells("Account_Id").Value

                            NwRow.Item("RestringCode") = dgvTemp.ChildBands(0).Rows(0).ChildBands(0).Rows(0).Cells(0).Value
                            NwRow.Item("RestringName") = dgvTemp.ChildBands(0).Rows(0).ChildBands(0).Rows(0).Cells(1).Value

                            NwRow.Item("SubCtaCode") = IIf(dgvTemp.ChildBands(1).Rows(0).Cells(0).Value Is DBNull.Value, "", dgvTemp.ChildBands(1).Rows(0).Cells(0).Value)
                            NwRow.Item("SubCtaName") = IIf(dgvTemp.ChildBands(1).Rows(0).Cells(1).Value Is DBNull.Value, "", dgvTemp.ChildBands(1).Rows(0).Cells(1).Value)
                            NwRow.Item("vEnumType") = dgvTemp.ChildBands(1).Rows(0).Cells(2).Value

                        End If
                        'If xVeces = 3 Then
                        DtTemp.Rows.Add(NwRow)
                        xVeces = 0
                        'End If
                    End If
                Next

            End If
        End With

        Return DtTemp
    End Function


    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Try
            Dim vXml As String = assinet.Assinet_xmlMonedas(pEntidad)
            Dim pServicio As String = ServicioAssinet.pServicioAssinet(pEntidad)
            Dim vResult As String = ""

            vResult = assinet.Enviar_Assinet(vXml, pServicio)
            Dim sr As New System.IO.StringReader(vResult)
            Dim reader As XmlTextReader
            Dim ds As New DataSet()
            Dim Dt As New DataTable

            'Create the XML Reader
            reader = New XmlTextReader(sr)

            ds.ReadXml(reader)

            If ds.Tables.Count > 0 Then
                If cboOpciones.Text = "Tipo Monedas" Then
                    If ds.Tables.Count > 5 Then
                        If ds.Tables(6).Rows.Count > 0 Then
                            Dt = ds.Tables(6)
                        End If
                    End If
                ElseIf cboOpciones.Text = "Plan de Cuentas" Then
                    If ds.Tables(6).Rows.Count > 0 Then
                        Dt = ds.Tables(6)
                    End If
                ElseIf cboOpciones.Text = "Plan de Cuentas Auxiliar" Then
                    If ds.Tables(8).Rows.Count > 0 Then
                        Dt = ds.Tables(8)
                    End If
                ElseIf cboOpciones.Text = "Sub Cuentas" Then
                    If ds.Tables(8).Rows.Count > 0 Then
                        Dt = ds.Tables(8)
                    End If
                Else
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dt = ds.Tables(0)
                    End If
                End If

                dgvListado.DataSource = Dt 'ds.Tables(6)
            Else
                dgvListado.DataSource = Nothing

            End If

            txtResult.Text = vResult

            If dgvListado.DataSource Is Nothing Then
                utTab.Tabs(1).Selected = True
            Else
                utTab.Tabs(2).Selected = True
            End If

            If cboOpciones.Text = "Plan de Cuentas" Then
                Dim DtTemp As New DataTable
                DtTemp = Actiualizar_Grid_PlanCtas()
                dgvListado.DataSource = Nothing
                dgvListado.DataSource = DtTemp
            End If

            lbl.Text = dgvListado.Rows.Count
            'close the reader
            reader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsGrabar_Click(sender As Object, e As EventArgs) Handles tsGrabar.Click
        If cboOpciones.Text = "Sub Cuentas" Then
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    Dim vArray As String = "", vTiene As Boolean
                    Dim dgvRw As UltraGridRow, vCodigo As Long = 0

                Try
                        'Almacenamos el array
                        For Each dgvRw In Me.dgvListado.Selected.Rows
                            If dgvRw.Band.Index = 0 Then
                                vTiene = True

                                vArray = vArray & "['" & (dgvRw.Cells("code").Value).Trim & "', '" & _
                                                         Str(dgvRw.Cells("id").Value).Trim & "','" & _
                                                         dgvRw.Cells("ModifiedDate").Value.Trim & "','" & _
                                                         dgvRw.Cells("Name").Value.Trim & "','" & _
                                                         dgvRw.Cells("SubAccountTypeCode").Value.trim & "'],"

                            End If
                        Next
                        If vTiene Then
                            vArray = Mid(vArray, 1, Len(vArray) - 1)
                            vArray = "array[" & vArray & "]"
                        Else
                            vArray = "null"
                        End If
                        vCodigo = plan_cuentasManager.AgregarCtaCte(txtEntidad.Text, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name)
                        If vCodigo > 0 Then
                            MessageBox.Show("Actualizó correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try
                End If
            Else
                MessageBox.Show("Debe seleccionar uno o varios registros que desea actualizar", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub
End Class