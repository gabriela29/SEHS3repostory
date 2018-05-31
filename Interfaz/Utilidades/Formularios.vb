Module Formularios
    ' Esta variable estática (compartida) servirá
    ' para mantener solo una instancia del formulario
    ' Este se puede usar para llamar así al formulario:
    '   FormBuscar.Show()
    ''Private fPagar As FrmActualizar_Operaciones = Nothing

    ''Public Property Buscar() As FrmActualizar_Operaciones
    ''    Get
    ''        If fPagar Is Nothing OrElse fPagar.IsDisposed Then
    ''            fPagar = New FrmActualizar_Operaciones
    ''        Else
    ''            fPagar.BringToFront()
    ''        End If
    ''        Return fPagar
    ''    End Get
    ''    Set(ByVal value As FrmActualizar_Operaciones)
    ''        fPagar = value
    ''    End Set
    ''End Property

    Private Function vXmlAssinet(ByVal vdtData As DataTable, ByVal pPeriodo As String, ByVal pFecha As String, ByVal pNombre As String) As String
        Dim vXml As String = ""
        Dim dtRow As DataRow
        Dim xCont As Long = 0
        vXml = "<AASIS>" & Chr(13)
        vXml = vXml & " <Context>" & Chr(13)
        vXml = vXml & "     <AccountingEntity>" & 7113 & "</AccountingEntity>" & Chr(13)
        vXml = vXml & " </Context>" & Chr(13)
        vXml = vXml & " <Component>" & Chr(13)
        vXml = vXml & "     <Name>ExternalMultipleAccounting</Name>" & Chr(13)
        vXml = vXml & " </Component>" & Chr(13)
        vXml = vXml & "     <Parameters>" & Chr(13)
        vXml = vXml & "         <ExternalMultipleAccountingParams>" & Chr(13)
        vXml = vXml & "         <ExternalSystem>" & 10 & "</ExternalSystem>" & Chr(13)
        vXml = vXml & "         </ExternalMultipleAccountingParams>" & Chr(13)
        vXml = vXml & "     </Parameters>" & Chr(13)
        vXml = vXml & " <Content>" & Chr(13)
        vXml = vXml & " <JournalList>" & Chr(13)
        vXml = vXml & "     <Journal>" & Chr(13)
        vXml = vXml & "         <ItemId>1</ItemId>" & Chr(13)
        vXml = vXml & "             <PostedPeriod>" & pPeriodo & "</PostedPeriod>" & Chr(13)
        vXml = vXml & "             <JournalDate>" & pFecha & "</JournalDate>" & Chr(13)
        vXml = vXml & "             <Description>" & pNombre & "</Description>" & Chr(13)
        vXml = vXml & "             <Items>" & Chr(13)

        For Each dtRow In vdtData.Rows
            'dtRow("item")
            vXml = vXml & "                 <Item>" & Chr(13)
            vXml = vXml & "                     <ItemId>" & xCont & "</ItemId>" & Chr(13)
            vXml = vXml & "                         <AccountCode>" & dtRow("cuenta") & "</AccountCode>" & Chr(13)
            If dtRow("libre") = "" Then
                vXml = vXml & "                         <SubAccountCode />" & Chr(13)
            Else
                vXml = vXml & "                         <SubAccountCode>" & dtRow("libre") & "</SubAccountCode>" & Chr(13)
            End If

            vXml = vXml & "                         <FundCode>" & dtRow("fondo") & "</FundCode>" & Chr(13)
            vXml = vXml & "                         <FunctionCode>" & "0000" & "</FunctionCode>" & Chr(13)
            vXml = vXml & "                         <RestrictionCode>" & dtRow("restriccion") & "</RestrictionCode>" & Chr(13)
            vXml = vXml & "                         <EntityValue>" & dtRow("importe") & "</EntityValue>" & Chr(13)
            vXml = vXml & "                         <Description>" & dtRow("glosa") & "</Description>" & Chr(13)
            vXml = vXml & "                         <Memo />" & Chr(13)
            vXml = vXml & "                 </Item>" & Chr(13)
            xCont = xCont + 1
        Next

        vXml = vXml & "             </Items>" & Chr(13)
        vXml = vXml & "         </Journal>" & Chr(13)
        vXml = vXml & " </JournalList>" & Chr(13)
        vXml = vXml & " </Content>" & Chr(13)
        vXml = vXml & " </AASIS>" & Chr(13)
        Return vXml
    End Function


    Private Sub Conta()
        '       Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter("asiento.xml", System.Text.Encoding.UTF8)
        ' myXmlTextWriter.Formatting = System.Xml.Formatting.Indented

        'myXmlTextWriter.WriteStartDocument(False)

        'myXmlTextWriter.WriteComment("Esto es un comentario")



        Dim vXml As String = ""
        vXml = "<AASIS>" & Chr(13)
        vXml = vXml & " <Context>" & Chr(13)
        vXml = vXml & "     <AccountingEntity>" & 7173 & "</AccountingEntity>" & Chr(13)
        vXml = vXml & " </Context>" & Chr(13)
        vXml = vXml & " <Component>" & Chr(13)
        vXml = vXml & "     <Name>ExternalMultipleAccounting</Name>" & Chr(13)
        vXml = vXml & " </Component>" & Chr(13)
        vXml = vXml & "     <Parameters>" & Chr(13)
        vXml = vXml & "         <ExternalMultipleAccountingParams>" & Chr(13)
        vXml = vXml & "         <ExternalSystem>9</ExternalSystem>" & Chr(13)
        vXml = vXml & "         </ExternalMultipleAccountingParams>" & Chr(13)
        vXml = vXml & "     </Parameters>" & Chr(13)
        vXml = vXml & " <Content>" & Chr(13)


        vXml = vXml & " <JournalList>" & Chr(13)
        vXml = vXml & "     <Journal>" & Chr(13)
        vXml = vXml & "         <ItemId>1</ItemId>" & Chr(13)
        vXml = vXml & "             <PostedPeriod>052014</PostedPeriod>" & Chr(13)
        vXml = vXml & "             <JournalDate>28052014</JournalDate>" & Chr(13)
        vXml = vXml & "             <Description>Prueba Integracion SAENET</Description>" & Chr(13)
        vXml = vXml & "             <Items>" & Chr(13)
        vXml = vXml & "                 <Item>" & Chr(13)
        vXml = vXml & "                     <ItemId>0</ItemId>" & Chr(13)
        vXml = vXml & "                         <AccountCode>4121001</AccountCode>" & Chr(13)
        vXml = vXml & "                         <SubAccountCode />" & Chr(13)
        vXml = vXml & "                         <FundCode>10</FundCode>" & Chr(13)
        vXml = vXml & "                         <FunctionCode>0000</FunctionCode>" & Chr(13)
        vXml = vXml & "                         <RestrictionCode>0E</RestrictionCode>" & Chr(13)
        vXml = vXml & "                         <EntityValue>1.00</EntityValue>" & Chr(13)
        vXml = vXml & "                         <Description>Pago de Agua</Description>" & Chr(13)
        vXml = vXml & "                         <Memo />" & Chr(13)
        vXml = vXml & "                 </Item>" & Chr(13)
        vXml = vXml & "                 <Item>" & Chr(13)
        vXml = vXml & "                     <ItemId>1</ItemId>" & Chr(13)
        vXml = vXml & "                         <AccountCode>4121001</AccountCode>" & Chr(13)
        vXml = vXml & "                         <SubAccountCode />" & Chr(13)
        vXml = vXml & "                         <FundCode>10</FundCode>" & Chr(13)
        vXml = vXml & "                         <FunctionCode>0000</FunctionCode>" & Chr(13)
        vXml = vXml & "                         <RestrictionCode>0E</RestrictionCode>" & Chr(13)
        vXml = vXml & "                         <EntityValue>1.00</EntityValue>" & Chr(13)
        vXml = vXml & "                         <Description>Pago de Agua</Description>" & Chr(13)
        vXml = vXml & "                         <Memo />" & Chr(13)
        vXml = vXml & "                 </Item>" & Chr(13)
        vXml = vXml & "                 <Item>" & Chr(13)
        vXml = vXml & "                     <ItemId>2</ItemId>" & Chr(13)
        vXml = vXml & "                         <AccountCode>1112001</AccountCode>" & Chr(13)
        vXml = vXml & "                         <SubAccountCode>15</SubAccountCode>" & Chr(13)
        vXml = vXml & "                         <FundCode>10</FundCode>" & Chr(13)
        vXml = vXml & "                         <FunctionCode>0000</FunctionCode>" & Chr(13)
        vXml = vXml & "                         <RestrictionCode>0A</RestrictionCode>" & Chr(13)
        vXml = vXml & "                         <EntityValue>-2</EntityValue>" & Chr(13)
        vXml = vXml & "                         <Description>Por el pago de Agua</Description>" & Chr(13)
        vXml = vXml & "                         <Memo />" & Chr(13)
        vXml = vXml & "                 </Item>" & Chr(13)
        vXml = vXml & "                 <Item>" & Chr(13)
        vXml = vXml & "                     <ItemId>3</ItemId>" & Chr(13)
        vXml = vXml & "                         <AccountCode>4121001</AccountCode>" & Chr(13)
        vXml = vXml & "                         <SubAccountCode />" & Chr(13)
        vXml = vXml & "                         <FundCode>10</FundCode>" & Chr(13)
        vXml = vXml & "                         <FunctionCode>0000</FunctionCode>" & Chr(13)
        vXml = vXml & "                         <RestrictionCode>0E</RestrictionCode>" & Chr(13)
        vXml = vXml & "                         <EntityValue>1.55</EntityValue>" & Chr(13)
        vXml = vXml & "                         <Description>Pago de Agua</Description>" & Chr(13)
        vXml = vXml & "                         <Memo />" & Chr(13)
        vXml = vXml & "                 </Item>" & Chr(13)
        vXml = vXml & "                 <Item>" & Chr(13)
        vXml = vXml & "                     <ItemId>4</ItemId>" & Chr(13)
        vXml = vXml & "                         <AccountCode>1112001</AccountCode>" & Chr(13)
        vXml = vXml & "                         <SubAccountCode>15</SubAccountCode>" & Chr(13)
        vXml = vXml & "                         <FundCode>10</FundCode>" & Chr(13)
        vXml = vXml & "                         <FunctionCode>0000</FunctionCode>" & Chr(13)
        vXml = vXml & "                         <RestrictionCode>0A</RestrictionCode>" & Chr(13)
        vXml = vXml & "                         <EntityValue>-1.55</EntityValue>" & Chr(13)
        vXml = vXml & "                         <Description>Por el pago de Agua</Description>" & Chr(13)
        vXml = vXml & "                         <Memo />" & Chr(13)
        vXml = vXml & "                 </Item>" & Chr(13)
        vXml = vXml & "             </Items>" & Chr(13)
        vXml = vXml & "         </Journal>" & Chr(13)

        vXml = vXml & " </JournalList>" & Chr(13)
        vXml = vXml & " </Content>" & Chr(13)
        vXml = vXml & " </AASIS>" & Chr(13)
        'TxtRequest.Text = vXml
        'txtResult.Text = ""
    End Sub


End Module
