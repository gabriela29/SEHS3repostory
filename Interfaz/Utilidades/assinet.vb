Imports System
Imports Phoenix.sehs
Imports System.Configuration
Imports System.ServiceModel
Imports System.Xml
Imports System.IO
Imports System.Text

Public Class assinet
  Public Shared Function PrepararXml(ByVal vdtData As DataTable, ByVal pEntidad As Integer, ByVal pExternal As Integer, ByVal pPeriodo As String, ByVal pFecha As String, ByVal pNombre As String) As String
    Dim vXml As String
    Dim dtRow As DataRow
    Dim xVesrion As String = "1", xCont As Long = 0, vDueDate As String = "", vInvoceDate As String = ""
    Dim vXmlVer As String = """1.0""", xCoding As String = """utf-8"""

    vXml = "<?xml version=" & """1.0""" & " encoding=" & """utf-8""" & "?>"
    vXml = vXml & "<AASIS>"
    vXml = vXml & " <Context>"
    vXml = vXml & "     <AccountingEntity>" & pEntidad & "</AccountingEntity>"
    vXml = vXml & " </Context>"
    vXml = vXml & " <Component>"
    vXml = vXml & "     <Name>ExternalMultipleAccounting</Name>"
    'vXml = vXml & "     <Version>1</Version>"
    vXml = vXml & " </Component>"
    vXml = vXml & "     <Parameters>"
    vXml = vXml & "         <ExternalMultipleAccountingParams>"
    vXml = vXml & "         <ExternalSystem>" & pExternal & "</ExternalSystem>"
    vXml = vXml & "         </ExternalMultipleAccountingParams>"
    vXml = vXml & "     </Parameters>"
    vXml = vXml & " <Content>"
    vXml = vXml & " <JournalList>"
    vXml = vXml & "     <Journal>"
    vXml = vXml & "         <ItemId>1</ItemId>"
    vXml = vXml & "             <PostedPeriod>" & pPeriodo & "</PostedPeriod>"
    vXml = vXml & "             <JournalDate>" & pFecha & "</JournalDate>"
    vXml = vXml & "             <Description>" & pNombre & "</Description>"
    vXml = vXml & "             <Items>"

    For Each dtRow In vdtData.Rows
      'dtRow("item")
      vXml = vXml & "                 <Item>"
      vXml = vXml & "                     <ItemId>" & xCont & "</ItemId>"
      vXml = vXml & "                         <FundCode>" & dtRow("fondo") & "</FundCode>"
      vXml = vXml & "                         <FunctionCode>" & dtRow("centro_costo") & "</FunctionCode>"
      vXml = vXml & "                         <RestrictionCode>" & dtRow("restriccion") & "</RestrictionCode>"

      vXml = vXml & "                         <AccountCode>" & dtRow("cuenta") & "</AccountCode>"
      If dtRow("libre") = "" Then
        vXml = vXml & "                         <SubAccountCode />"
      Else
        vXml = vXml & "                         <SubAccountCode>" & dtRow("libre") & "</SubAccountCode>"
      End If



      vXml = vXml & "                         <EntityValue>" & dtRow("importe") & "</EntityValue>"
      vXml = vXml & "                         <Description>" & Mid(dtRow("glosa"), 1, 50).Trim & "</Description>"

      If dtRow("memo") = "" Then
        vXml = vXml & "                         <Memo />"
      Else
        vXml = vXml & "                         <Memo>" & dtRow("memo") & "</Memo>"
      End If

      'If dtRow("duefecha") = "" Then
      '    'vXml = vXml & "                         <DueDate />" & Chr(13)
      'Else
      '    vDueDate = LibreriasFormularios.Formato_Fecha_c(Date.Parse(dtRow("duefecha")))
      '    vXml = vXml & "                         <DueDate>" & vDueDate & "</DueDate>"
      'End If

      'vXml = vXml & "                         <Memo />"

      'If dtRow("invoicenumber") = "" Then
      '    'vXml = vXml & "                         <InvoiceNumber />" & Chr(13)
      'Else
      '    vInvoceDate = LibreriasFormularios.Formato_Fecha_c(Date.Parse(dtRow("InvoiceDate")))
      '    vXml = vXml & "                         <InvoiceNumber>" & dtRow("invoicenumber") & "</InvoiceNumber>"
      '    vXml = vXml & "                         <InvoiceNumber>" & vInvoceDate & "</InvoiceNumber>"
      'End If

      vXml = vXml & "                 </Item>"
      xCont = xCont + 1
    Next

    vXml = vXml & "             </Items>"
    vXml = vXml & "         </Journal>"
    vXml = vXml & " </JournalList>"
    vXml = vXml & " </Content>"
    vXml = vXml & " </AASIS>"

    Return vXml
  End Function

  Public Shared Function PrepararXmlDate(ByVal vdtData As DataTable, ByVal pEntidad As Integer, ByVal pExternal As Integer, ByVal pPeriodo As String, ByVal pFecha As String, ByVal pNombre As String) As String
    Dim vXml As String
    Dim dtRow As DataRow
    Dim xVesrion As String = "1", xCont As Long = 0, vDueDate As String = "", vInvoceDate As String = ""
    Dim vXmlVer As String = """1.0""", xCoding As String = """utf-8"""

    vXml = "<?xml version=" & """1.0""" & " encoding=" & """utf-8""" & "?>"
    vXml = vXml & "<AASIS>"
    vXml = vXml & " <Context>"
    vXml = vXml & "     <AccountingEntity>" & pEntidad & "</AccountingEntity>"
    vXml = vXml & " </Context>"
    vXml = vXml & " <Component>"
    vXml = vXml & "     <Name>ExternalMultipleAccounting</Name>"
    'vXml = vXml & "     <Version>1</Version>"
    vXml = vXml & " </Component>"
    vXml = vXml & "     <Parameters>"
    vXml = vXml & "         <ExternalMultipleAccountingParams>"
    vXml = vXml & "         <ExternalSystem>" & pExternal & "</ExternalSystem>"
    vXml = vXml & "         </ExternalMultipleAccountingParams>"
    vXml = vXml & "     </Parameters>"
    vXml = vXml & " <Content>"
    vXml = vXml & " <JournalList>"
    vXml = vXml & "     <Journal>"
    vXml = vXml & "         <ItemId>1</ItemId>"
    vXml = vXml & "             <PostedPeriod>" & pPeriodo & "</PostedPeriod>"
    vXml = vXml & "             <JournalDate>" & pFecha & "</JournalDate>"
    vXml = vXml & "             <Description>" & pNombre & "</Description>"
    vXml = vXml & "             <Items>"

    For Each dtRow In vdtData.Rows
      'dtRow("item")
      vXml = vXml & "                 <Item>"
      vXml = vXml & "                     <ItemId>" & xCont & "</ItemId>"
      vXml = vXml & "                         <FundCode>" & dtRow("fondo") & "</FundCode>"
      vXml = vXml & "                         <FunctionCode>" & dtRow("centro_costo") & "</FunctionCode>"
      vXml = vXml & "                         <RestrictionCode>" & dtRow("restriccion") & "</RestrictionCode>"

      vXml = vXml & "                         <AccountCode>" & dtRow("cuenta") & "</AccountCode>"
      If dtRow("libre") = "" Then
        vXml = vXml & "                         <SubAccountCode />"
      Else
        vXml = vXml & "                         <SubAccountCode>" & dtRow("libre") & "</SubAccountCode>"
      End If



      vXml = vXml & "                         <EntityValue>" & dtRow("importe") & "</EntityValue>"
      vXml = vXml & "                         <Description>" & Mid(dtRow("glosa"), 1, 50).Trim & "</Description>"


      vXml = vXml & "                         <DueDate />" & Chr(13)
      'If dtRow("duefecha") = "" Then
      '  'vXml = vXml & "                         <DueDate />" & Chr(13)
      'Else
      '  vDueDate = dtRow("duefecha") 'LibreriasFormularios.Formato_Fecha_c(Date.Parse(dtRow("duefecha")))
      '  vXml = vXml & "                         <DueDate>" & vDueDate & "</DueDate>"
      'End If

      If dtRow("memo") = "" Then
        vXml = vXml & "                         <Memo />"
      Else
        vXml = vXml & "                         <Memo>" & dtRow("memo") & "</Memo>"
      End If

      'If dtRow("invoicenumber") = "" Then
      '  'vXml = vXml & "                         <InvoiceNumber />" & Chr(13)
      'Else
      '  vInvoceDate = dtRow("InvoiceDate") ' LibreriasFormularios.Formato_Fecha_c(Date.Parse(dtRow("InvoiceDate")))
      '  vXml = vXml & "                         <InvoiceNumber>" & dtRow("invoicenumber") & "</InvoiceNumber>"
      '  vXml = vXml & "                         <InvoiceDate>" & vInvoceDate & "</InvoiceDate>"
      'End If

      vXml = vXml & "                 </Item>"
      xCont = xCont + 1
    Next

    vXml = vXml & "             </Items>"
    vXml = vXml & "         </Journal>"
    vXml = vXml & " </JournalList>"
    vXml = vXml & " </Content>"
    vXml = vXml & " </AASIS>"

    Return vXml
  End Function

  Public Shared Function Enviar_Assinet(ByVal pXml As String, ByVal pAdress As String) As String
    Dim xOk As Boolean = False
    System.Net.ServicePointManager.Expect100Continue = False
    Try
      Dim client As PayloadBusinessClient = New PayloadBusinessClient("BasicHttpBinding_PayloadBusiness")

      Dim ep = New EndpointAddress(pAdress)

      client.Endpoint.Address = ep

      Dim vRequest As String = "", xLoad As String = "", xResutl As String = ""

      Dim xmldoc As New XmlDataDocument()
      vRequest = pXml

      client.Open()
      If client.State = ServiceModel.CommunicationState.Opened Then

        xLoad = client.Load(vRequest)
        xResutl = client.Execute(xLoad)
        'xmldoc = client.Execute(xLoad)
        client.Close()
      End If

      Return xResutl
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return xOk
    End Try

  End Function


  Public Shared Function Assinet_xmlMonedas(ByVal vEntidad As Integer) As String
    Dim vXml As String = ""
    vXml = "<AASIS>" & Chr(13)
    vXml = vXml & " <Context>" & Chr(13)
    vXml = vXml & "  <AccountingEntity>" & vEntidad & "</AccountingEntity>" & Chr(13)
    vXml = vXml & " </Context>" & Chr(13)
    vXml = vXml & " <Component>" & Chr(13)
    vXml = vXml & "  <Name>CurrencyList</Name>" & Chr(13)
    vXml = vXml & " </Component>" & Chr(13)
    vXml = vXml & " <Parameters/>" & Chr(13)
    vXml = vXml & "</AASIS>" & Chr(13)
    Return vXml

  End Function

  Public Shared Function Adress(pEntidad As Integer) As String
    Dim pAdress As String = ""

    If pEntidad = 7114 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHS/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7312 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSAPCS/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7912 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMPS/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7012 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMSOP/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7512 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMLT/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7712 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMOP/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 7412 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPS/SEHSMAC/Services/Aasi.Net/Integration/PayloadService.svc/basic"

    ElseIf pEntidad = 17114 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UPN/SEHSNORTE/services/aasi.net/integration/payloadservice.svc/basic"

    ElseIf pEntidad = 8813 Then
      pAdress = "https://sad-us-fm-1.aasi.live.apps.sdasystems.org/UU/services/aasi.net/integration/payloadservice.svc/basic"

    Else
      pAdress = ""
    End If

    Return pAdress




  End Function




End Class
