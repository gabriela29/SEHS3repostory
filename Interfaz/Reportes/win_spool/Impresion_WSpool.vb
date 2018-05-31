Imports System.Drawing.Printing
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class Impresion_WSpool
    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + _
    "c6" + Chr(1) + Chr(27) + "R3" + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)

    Private Shared Function Limpiar_Cadena(vCadena As String, vTipoImp As String) As String
        vCadena = Arreglar_Cadena(vCadena, 164, "ñ")
        vCadena = Arreglar_Cadena(vCadena, 165, "Ñ")
        vCadena = Arreglar_Cadena(vCadena, 160, "á")
        vCadena = Arreglar_Cadena(vCadena, 161, "í")
        vCadena = Arreglar_Cadena(vCadena, 162, "ó")
        vCadena = Arreglar_Cadena(vCadena, 163, "ú")
        vCadena = Arreglar_Cadena(vCadena, 130, "é")

        vCadena = Arreglar_Cadena(vCadena, 167, "º")

        Dim Draft As String
        Select Case vTipoImp
            Case "MATRICIAL" : Draft = Chr(27) & "x0"
        End Select

        'Cadena = Draft & Cadena & vbCrLf
        Return vCadena
    End Function

    Private Shared Function Arreglar_Cadena(vCadena As String, Asc_Char As Integer, Caracter As String) As String
        Dim X As Integer, Texto As String, A() As String
        If InStr(vCadena, Caracter) > 0 Then
            A = Split(vCadena, Caracter)
            For X = 0 To UBound(A)
                Texto = Texto & A(X) & Chr(Asc_Char)
            Next
            Texto = Microsoft.VisualBasic.Left(Texto, Len(Texto) - 1)
        Else
            Texto = vCadena
        End If
        Arreglar_Cadena = Texto
    End Function

    Private Shared Sub AddCadena(ByRef vCadena As String, vLeft As Boolean, vCol As Integer, vCadAdd As String)
        Dim vEspBlanco As String

        If vLeft Then
            vEspBlanco = vCol - Len(vCadena)
        Else
            vEspBlanco = vCol - Len(vCadena) - Len(vCadAdd)
        End If

        If vEspBlanco > 0 Then
            vCadena = vCadena & Space(vEspBlanco)
        ElseIf vEspBlanco < 0 Then
            vCadena = Microsoft.VisualBasic.Left(vCadena, Len(vCadena) - Convert.ToInt32(vEspBlanco))
        End If
        vCadena = vCadena & vCadAdd
    End Sub

    Public Shared Function Existe_Impresora(ByVal Name_Printer As String) As Boolean
        Dim Df As New PrintDocument
        Dim Printer As String
        'Impresora por Defecto        
        Dim sw_Df As String = Df.PrinterSettings.PrinterName

        For Each Printer In PrinterSettings.InstalledPrinters
            If Printer.ToString = Name_Printer Then
                Existe_Impresora = True
                Exit For
            End If
        Next

        Return Existe_Impresora
    End Function

  Public Shared Function Print_Ticket(ByVal vDocumentoid As Integer, ByVal vAlmacenId As Integer, ByVal vAlmacen As String, ByVal vCaja As String,
                                      ByVal dtCabecera As DataTable, ByVal dtDetalle As DataTable) As Boolean
    Dim pd As New PrintDialog()
    Dim xOk As Boolean = False
    Dim cRow As DataRow, cRowD As DataRow, vCodigo As Long = 0
    Dim Sp As String, vCadena As String, vTipoDoc As String = "", vItem As String = ""
    Dim vSerieTK As String = "", vNOM_Print As String = "BIXOLON SRP-270"
    Dim tCant As Long = 0, tBruto As Double = 0, tNeto As Double = 0, tDscto As Double = 0
    Dim tExo As Double = 0, tAfecto As Double = 0, tInafecto As Double = 0, tIGV As Double = 0
    Dim tExonerado As Double = 0

    If vDocumentoid = 1 Or vDocumentoid = 37 Or vDocumentoid = 36 Then
      vTipoDoc = "TICKET FACTURA"
    ElseIf vDocumentoid = 11 Then
      vTipoDoc = "NOTA DE CREDITO"
    Else
      vTipoDoc = "TICKET BOLETA"
    End If

    '=====================================
    Dim ObjPerm As New permisos_impresion
    Dim vStado As Boolean
    Try
      ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vAlmacenId, vCaja, vDocumentoid, 0)

      If Not ObjPerm Is Nothing Then
        vSerieTK = ObjPerm.serie_TK
        If Not ObjPerm.impresion Then
          xOk = False
          Exit Function
        End If
        If Not Existe_Impresora(ObjPerm.impresora) Then
          xOk = False
          Exit Function
        Else
          vNOM_Print = ObjPerm.impresora
        End If

        If dtCabecera.Rows.Count > 0 And dtDetalle.Rows.Count > 0 Then
          For Each cRow In dtCabecera.Rows
            'Encabezado
            vCadena = (eInit + eCentre + UCase(GestionSeguridadManager.gEmpresa)) & vbNewLine
            vCadena = vCadena & (GestionSeguridadManager.gDirEmpresa) & vbNewLine
            vCadena = vCadena & vbNewLine
            vCadena = vCadena & ((vAlmacen)) & vbNewLine
            vCadena = vCadena & (GestionSeguridadManager.vDirAlmacen) & vbNewLine
            vCadena = vCadena & ("Telféfono: " & GestionSeguridadManager.vTelAlmacen) & vbNewLine
            vCadena = vCadena & ("RUC: " & GestionSeguridadManager.gRUCEmp) & vbNewLine
            vCadena = vCadena & ("S/N: " & vSerieTK) & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & (vTipoDoc) & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine

            'Seccion 1
            vCodigo = cRow.Item("codigo")
            vItem = ""
            AddCadena(vItem, True, 1, cRow.Item("fecha"))
            AddCadena(vItem, False, 30, cRow.Item("numero"))
            vCadena = vCadena & (vItem) & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & (eLeft) + vbNewLine
            vCadena = vCadena & ("CLIENTE: " & IIf(cRow.Item("cliente") = "", cRow.Item("nombre_cli"), cRow.Item("cliente"))) & vbNewLine
            vCadena = vCadena & ("DNI/RUC: " & cRow.Item("documento_identidad")) & vbNewLine
            vCadena = vCadena & cRow.Item("observacion") & vbNewLine
            vCadena = vCadena & vbNewLine
            vCadena = vCadena & cRow.Item("condicion") & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & ("DETALLE/CANT. x PRECIO  IMPORTE") & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine
            tIGV = Single.Parse(cRow.Item("igv"))

            Dim Filter As String = "codigo = " & vCodigo
            Dim drArr() As DataRow, tDtDet As New DataTable
            drArr = Nothing
            If Not dtDetalle Is Nothing Then
              drArr = dtDetalle.Select(Filter, Nothing, DataViewRowState.CurrentRows)
            End If

            tDtDet = drArr.CopyToDataTable()

            'Detalle
            For Each cRowD In tDtDet.Rows
              vCadena = vCadena & Left(cRowD.Item("producto"), 31) & vbNewLine
              vItem = ""
              AddCadena(vItem, False, 3, Str(cRowD.Item("cantidad")))
              AddCadena(vItem, True, 8, "x")
              AddCadena(vItem, False, 17, Str(cRowD.Item("precio")))
              AddCadena(vItem, False, 30, Str(cRowD.Item("bruto")))
              vCadena = vCadena & (vItem) & vbNewLine
              If Single.Parse(cRowD.Item("dcto")) > 0 Then
                vItem = ""
                AddCadena(vItem, False, 30, Str(cRowD.Item("dcto")))
                vCadena = vCadena & (vItem) & vbNewLine
                tDscto = tDscto + Single.Parse(cRowD.Item("dcto"))
              End If

              tCant = tCant + (cRowD.Item("cantidad"))
              tBruto = tBruto + (cRowD.Item("bruto"))

              If Boolean.Parse(cRowD.Item("afecto_igv")) And Boolean.Parse(cRowD.Item("exonerada")) = False Then
                tAfecto = tAfecto + (cRowD.Item("subtotal"))
              ElseIf Boolean.Parse(cRowD.Item("exonerada")) Then
                tExonerado = tExonerado + (cRowD.Item("subtotal"))
              Else
                tInafecto = tInafecto + (cRowD.Item("subtotal"))
              End If
              tNeto = tNeto + (cRowD.Item("subtotal"))
            Next

            FormatNumber(0, 2, TriState.True, , TriState.False)

            'Footer
            vCadena = vCadena & ("--------------------------------") & vbNewLine
            vItem = ""
            AddCadena(vItem, True, 1, "Inafecto")
            AddCadena(vItem, False, 30, FormatNumber(tInafecto, 2, TriState.True, , TriState.False))
            vCadena = vCadena & (vItem) & vbNewLine

            vItem = ""
            AddCadena(vItem, True, 1, "Exonerado")
            AddCadena(vItem, False, 30, FormatNumber(tExonerado, 2, TriState.True, , TriState.False))
            vCadena = vCadena & (vItem) & vbNewLine

            If Not vTipoDoc = "TICKET BOLETA" Then
              vItem = ""
              AddCadena(vItem, True, 1, "Afecto")
              AddCadena(vItem, False, 30, FormatNumber((tAfecto - tIGV), 2, TriState.True, , TriState.False))
              vCadena = vCadena & (vItem) & vbNewLine

              vItem = ""
              AddCadena(vItem, True, 1, "IGV")
              AddCadena(vItem, False, 30, Str(FormatNumber(tIGV, 2, TriState.True, , TriState.False)))
              vCadena = vCadena & (vItem) & vbNewLine
            Else
              vItem = ""
              AddCadena(vItem, True, 1, "Afecto")
              AddCadena(vItem, False, 30, FormatNumber((tAfecto), 2, TriState.True, , TriState.False))
              vCadena = vCadena & (vItem) & vbNewLine
            End If

            vItem = ""
            AddCadena(vItem, True, 1, "TOTAL")
            AddCadena(vItem, False, 30, FormatNumber(tNeto, 2, TriState.True, , TriState.False))
            vCadena = vCadena & (vItem) & vbNewLine

            vCadena = vCadena & ("--------------------------------") & vbNewLine
            If Boolean.Parse(cRow.Item("estado")) Then
              vCadena = vCadena & ("Son: " & Numeros_Letras.EnLetras(tNeto)) & vbNewLine
            Else
              vCadena = vCadena & ("**** A N U L A D O ***") & vbNewLine
            End If


            vCadena = vCadena & vbNewLine
            vCadena = vCadena & ("ITEMS:   " & tCant) & vbNewLine

            vCadena = vCadena & vbNewLine
            vItem = ""
            AddCadena(vItem, True, 1, vCaja)
            AddCadena(vItem, False, 30, Now.Hour & ":" & Now.Minute)
            vCadena = vCadena & (vItem) & vbNewLine
            vCadena = vCadena & ("Atendido Por: " & GestionSeguridadManager.sUsuario) & vbNewLine
            vCadena = vCadena & (eInit + eCentre + "Gracias por su preferencia") & vbNewLine

            vCadena = vCadena & vbNewLine
            vCadena = vCadena & vbNewLine
            vCadena = vCadena & vbNewLine

            vCadena = vCadena & vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer

            tNeto = 0
            tDscto = 0
            tExo = 0
            tAfecto = 0
            tInafecto = 0
            Sp = Limpiar_Cadena(vCadena, "")

            'pd.PrinterSettings = New PrinterSettings()
            ''If (pd.ShowDialog() = DialogResult.OK) Then
            ' Print the file to the printer.
            WinSpool.SendStringToPrinter(vNOM_Print, Sp)
          Next

          xOk = True
        Else
          MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
        End If

      Else
        MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
      End If

    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AVISO")
      xOk = False

    End Try

    Return xOk
    ''End If
  End Function

  Public Shared Function Print_Recibo_Dzmo(ByVal vDocumentoid As Integer, ByVal vAlmacenId As Integer, ByVal vAlmacen As String, ByVal vCaja As String,
                                            ByVal dtCabecera As DataTable) As Boolean
    Dim pd As New PrintDialog()
    Dim xOk As Boolean = False
    Dim cRow As DataRow, vCodigo As Long = 0
    Dim Sp As String, vCadena As String, vTipoDoc As String = "RECIBO DIEZMO", vItem As String = ""
    Dim vSerieTK As String = "", vNOM_Print As String = "BIXOLON SRP-270"
    Dim tCant As Long = 0, tBruto As Single = 0, tNeto As Single = 0, tDscto As Single = 0
    Dim tExo As Single = 0, tAfecto As Single = 0, tInafecto As Single = 0, tIGV As Single = 0

    '=====================================
    Dim ObjPerm As New permisos_impresion
    Dim vStado As Boolean
    Try
      ObjPerm = permisos_impresionManager.Get_Dato_Impresion(GestionSeguridadManager.idUsuario, vAlmacenId, "DZMO", vDocumentoid, 0)

      If Not ObjPerm Is Nothing Then
        vSerieTK = ObjPerm.serie_TK
        If Not ObjPerm.impresion Then
          xOk = False
          Exit Function
        End If
        If Not Existe_Impresora(ObjPerm.impresora) Then
          xOk = False
          Exit Function
        Else
          vNOM_Print = ObjPerm.impresora
        End If

        If dtCabecera.Rows.Count > 0 Then
          For Each cRow In dtCabecera.Rows
            'Encabezado
            vCadena = (eInit + eCentre + UCase(GestionSeguridadManager.gEmpresa)) & vbNewLine
            'vCadena = vCadena & (GestionSeguridadManager.gDirEmpresa) & vbNewLine
            vCadena = vCadena & vbNewLine
            vCadena = vCadena & ((vAlmacen)) & vbNewLine
            vCadena = vCadena & (GestionSeguridadManager.vDirAlmacen) & vbNewLine
            'vCadena = vCadena & ("Telféfono: " & GestionSeguridadManager.vTelAlmacen) & vbNewLine
            'vCadena = vCadena & ("RUC: " & GestionSeguridadManager.gRUCEmp) & vbNewLine
            'vCadena = vCadena & ("S/N: " & vSerieTK) & vbNewLine
            vCadena = vCadena & vbNewLine
            'vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & (cRow.Item("documento")) & vbNewLine
            'vCadena = vCadena & ("--------------------------------") & vbNewLine

            'Seccion 1
            vCodigo = cRow.Item("codigo")
            vItem = ""
            AddCadena(vItem, True, 1, cRow.Item("fecha"))
            AddCadena(vItem, False, 30, cRow.Item("numero"))
            vCadena = vCadena & (vItem) & vbNewLine
            'vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & (eLeft) + vbNewLine
            vCadena = vCadena & ("CLIENTE: " & cRow.Item("colportor")) & vbNewLine
            vCadena = vCadena & vbNewLine
            'vCadena = vCadena & ("--------------------------------") & vbNewLine
            vCadena = vCadena & ("DETALLE                 IMPORTE") & vbNewLine
            vCadena = vCadena & ("--------------------------------") & vbNewLine

            'Footer

            vItem = ""
            AddCadena(vItem, True, 1, cRow.Item("observacion"))
            AddCadena(vItem, False, 30, FormatNumber(cRow.Item("monto"), 2, TriState.True, , TriState.False))
            vCadena = vCadena & (vItem) & vbNewLine


            vCadena = vCadena & ("--------------------------------") & vbNewLine
            'vItem = ""
            'AddCadena(vItem, True, 1, "TOTAL")
            'AddCadena(vItem, False, 30, FormatNumber(cRow.Item("monto"), 2, TriState.True, , TriState.False))
            'vCadena = vCadena & (vItem) & vbNewLine

            'vCadena = vCadena & ("--------------------------------") & vbNewLine

            If Boolean.Parse(cRow.Item("estado")) Then
              tNeto = cRow.Item("monto")
              vCadena = vCadena & ("Son: " & Numeros_Letras.EnLetras(tNeto)) & vbNewLine
            Else
              vCadena = vCadena & ("**** A N U L A D O ***") & vbNewLine
            End If

            vCadena = vCadena & vbNewLine
            vItem = ""
            AddCadena(vItem, True, 1, vCaja)
            AddCadena(vItem, False, 30, Now.Hour & ":" & Now.Minute)
            vCadena = vCadena & (vItem) & vbNewLine
            vCadena = vCadena & ("Atendido Por: " & GestionSeguridadManager.sUsuario) & vbNewLine
            'vCadena = vCadena & (eInit + eCentre + "Gracias por su preferencia") & vbNewLine

            vCadena = vCadena & vbNewLine
            vCadena = vCadena & vbNewLine
            vCadena = vCadena & vbNewLine

            vCadena = vCadena & vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer

            tNeto = 0
            tDscto = 0
            tExo = 0
            tAfecto = 0
            tInafecto = 0
            Sp = Limpiar_Cadena(vCadena, "")

            'pd.PrinterSettings = New PrinterSettings()
            ''If (pd.ShowDialog() = DialogResult.OK) Then
            ' Print the file to the printer.
            WinSpool.SendStringToPrinter(vNOM_Print, Sp)
          Next

          xOk = True
        Else
          MsgBox("No hay Registros que mostrar", MsgBoxStyle.Exclamation, "AVISO")
        End If

      Else
        MsgBox("No puede leer o no encuentra un Permiso de impresión", MsgBoxStyle.Exclamation, "AVISO")
      End If

    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AVISO")
      xOk = False

    End Try

    Return xOk
    ''End If
  End Function

  Public Shared Function Print_Demo(ByVal vAlmacen As String) As Boolean
        Dim Sp As String, vCadena As String, vTipoDoc As String = "", vItem As String = "", vNOM_Print As String = "BIXOLON SRP-270"
        vCadena = (eInit + eCentre + UCase(GestionSeguridadManager.gEmpresa)) & vbNewLine
        vCadena = vCadena & (GestionSeguridadManager.gDirEmpresa) & vbNewLine
        vCadena = vCadena & vbNewLine
        vCadena = vCadena & ((vAlmacen)) & vbNewLine
        vCadena = vCadena & (GestionSeguridadManager.vDirAlmacen) & vbNewLine
        vCadena = vCadena & ("Telféfono: " & GestionSeguridadManager.vTelAlmacen) & vbNewLine
        vItem = ""
        AddCadena(vItem, True, 1, "RUC:" & GestionSeguridadManager.gRUCEmp & " - ")
        AddCadena(vItem, False, 20, "N/S:FF9G153839")
        vCadena = vCadena & (vItem) & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vCadena = vCadena & (vTipoDoc) & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vCadena = vCadena & ("07/01/2015    0016-00009288") & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vCadena = vCadena & (eLeft) + vbNewLine
        vCadena = vCadena & ("CLIENTE: SANCHEZ BECERRA, DALILA") & vbNewLine
        vCadena = vCadena & ("DNI/RUC: 42044590") & vbNewLine
        vCadena = vCadena & ("SUSB: CANADá-BUENOS AIRES-CANADA") & vbNewLine
        vCadena = vCadena & vbNewLine
        vCadena = vCadena & ("CONTADO") & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vCadena = vCadena & ("DETALLE/CANT. x PRECIO  IMPORTE") & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine

        'Detalle
        vCadena = vCadena & ("GUIA DE ESTUDIO MAESTRO I TRIM") & vbNewLine
        vItem = ""
        AddCadena(vItem, False, 3, "2")
        AddCadena(vItem, True, 8, "x")
        AddCadena(vItem, False, 17, "7.00")
        AddCadena(vItem, False, 30, "14.00")
        vCadena = vCadena & (vItem) & vbNewLine
        vCadena = vCadena & ("MATINAL TELA NIÑOS GENIAL DIOS") & vbNewLine
        vItem = ""
        AddCadena(vItem, False, 3, "5381")
        AddCadena(vItem, True, 8, "x")
        AddCadena(vItem, False, 17, "17.00")
        AddCadena(vItem, False, 30, "1221.00")
        vCadena = vCadena & (vItem) & vbNewLine

        'Footer
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vItem = ""
        AddCadena(vItem, True, 1, "TOTAL")
        AddCadena(vItem, False, 30, "S/.55,238.00")
        vCadena = vCadena & (vItem) & vbNewLine
        vCadena = vCadena & ("--------------------------------") & vbNewLine
        vCadena = vCadena & ("Son: ") & vbNewLine

        vCadena = vCadena & vbNewLine
        vCadena = vCadena & ("ITEMS:     2") & vbNewLine

        vCadena = vCadena & vbNewLine
        vItem = ""
        AddCadena(vItem, True, 1, "Almacén")
        AddCadena(vItem, False, 30, "9:30 PM")
        vCadena = vCadena & (vItem) & vbNewLine
        vCadena = vCadena & ("Atendido Por: " & GestionSeguridadManager.sUsuario) & vbNewLine
        vCadena = vCadena & (eInit + eCentre + "Gracias por su preferencia") & vbNewLine

        vCadena = vCadena & vbNewLine
        vCadena = vCadena & vbNewLine
        vCadena = vCadena & vbNewLine

        vCadena = vCadena & vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer

        Sp = Limpiar_Cadena(vCadena, "MATRICIAL")

        ' pd.PrinterSettings = New PrinterSettings()
        ''If (pd.ShowDialog() = DialogResult.OK) Then
        ' Print the file to the printer.
        WinSpool.SendStringToPrinter(vNOM_Print, Sp)
    End Function

End Class
