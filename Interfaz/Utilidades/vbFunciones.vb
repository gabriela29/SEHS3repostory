'Para Obtener Datos Sunat
Imports System
Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports CapaObjetosNegocio.BO

Public Class Funciones
  Public Shared Function Verificar_ruc(ByVal xNum As String) As Boolean
    Dim li_suma, li_residuo, li_diferencia, li_compara As Integer
    li_suma = (CInt(Mid(xNum, 1, 1)) * 5) + (CInt(Mid(xNum, 2, 1)) * 4) + (CInt(Mid(xNum, 3, 1)) * 3) + (CInt(Mid(xNum, 4, 1)) * 2) + (CInt(Mid(xNum, 5, 1)) * 7) + (CInt(Mid(xNum, 6, 1)) * 6) + (CInt(Mid(xNum, 7, 1)) * 5) + (CInt(Mid(xNum, 8, 1)) * 4) + (CInt(Mid(xNum, 9, 1)) * 3) + (CInt(Mid(xNum, 10, 1)) * 2)
    li_compara = CInt(Mid(xNum, 11, 1))
    li_residuo = li_suma Mod 11
    li_diferencia = Int(11 - li_residuo)
    If li_diferencia > 9 Then li_diferencia = li_diferencia - 10
    If li_diferencia <> li_compara Then
      Verificar_ruc = False
    Else
      Verificar_ruc = True
    End If
  End Function

  Public Shared Function Verificar_Cedula(ByVal nCedula As String) As Boolean
    Dim VerificaCedula As Boolean = True
    If Len(Trim(nCedula)) <> 10 Then
      VerificaCedula = False
    End If

    If Val(Mid(nCedula, 1, 2)) > 25 Then
      VerificaCedula = False
    End If

    If Val(Mid(nCedula, 3, 1)) > 5 Then
      VerificaCedula = False
    End If

    If VerificaCedula = False Then
      Verificar_Cedula = False
    Else
      Dim Total As Integer
      Dim Cifra As Integer
      Dim a As Integer
      Total = 0

      For a = 1 To 9

        If (a Mod 2) = 0 Then
          Cifra = Val(Mid(nCedula, a, 1))
        Else
          Cifra = Val(Mid(nCedula, a, 1)) * 2
          If Cifra > 9 Then
            Cifra = Cifra - 9
          End If
        End If
        Total = Total + Cifra
      Next

      Cifra = Total Mod 10

      If Cifra > 0 Then
        Cifra = 10 - Cifra
      End If
    End If
    Return Verificar_Cedula
  End Function

  'Consultar RUC SUNAT
  Private myCookie As CookieContainer

  Public Function Persona()
    Try
      myCookie = Nothing
      myCookie = New CookieContainer()
      'Permitir SSL
      ServicePointManager.Expect100Continue = True
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
      Return ReadCapcha()

    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return Nothing
    End Try
  End Function

  Private Function ReadCapcha() As Image
    Try
      Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image"), HttpWebRequest)
      myWebRequest.CookieContainer = myCookie
      myWebRequest.Proxy = Nothing
      myWebRequest.Credentials = CredentialCache.DefaultCredentials
      Dim myWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
      Dim myImgStream As Stream = myWebResponse.GetResponseStream()
      'myWebResponse.Close();
      Return Image.FromStream(myImgStream)

    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return Nothing
    End Try

  End Function

  Public Shared Function Obtener_Datos_Prov_Sunat(ByVal xNum As String) As datos_ruc
    Try
      Dim ImgCapcha As String
      Dim myUrl As String = String.Format("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&razSoc=&nroRuc={0}&nrodoc=&contexto=rrrrrrr&tQuery=on&search1=10015569943&codigo={1}&tipdoc=1&search2=&coddpto=&codprov=&coddist=&search3= ", xNum, ImgCapcha)
      Dim vObj As datos_ruc, xresul As String
      Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create(myUrl), HttpWebRequest)
      'myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";'esto creo que lo puse por gusto :/
      ''myWebRequest.CookieContainer = myCookie
      myWebRequest.Credentials = CredentialCache.DefaultCredentials
      myWebRequest.Proxy = Nothing
      Dim myHttpWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
      Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
      Dim myStreamReader As New StreamReader(myStream)
      Dim _WebSource As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())

      Dim separators() As String = {"td class=bg colspan=1>"}
      Dim vRuc As String


      Dim obj As New datos_ruc, word As String = ""
      Dim vStado As String, vSit As String
      Dim words() As String = _WebSource.Split(New Char(), ("< > \n \r")) '_WebSource.Split(separators, StringSplitOptions.RemoveEmptyEntries)
      For Each word In words
        'If "<table border=0 cellpadding=2 cellspacing=3 width=100% class=form-table>" Then

        vRuc = Mid(words(27), 26, 150) 'Replace(words(27), "td class=", "")
        obj.ruc = Mid(vRuc.Trim, 1, 11).Trim
        obj.Razon_Social = Mid(vRuc.Trim, 15, 120).Trim
        obj.Tipo_Per = Mid(words(33), 25, 150).Trim
        obj.Direccion = Mid(words(39), 29, 150).Trim
        vStado = Mid(words(61), 25, 50).Trim
        If Not vStado = "ACTIVO" Then
          vStado = Mid(words(55), 25, 50).Trim
        End If
        obj.Estado = vStado
        vSit = Mid(words(69), 35, 50).Trim
        If Not vSit = "HABIDO" Then
          vSit = Mid(words(63), 35, 50).Trim
        End If
        obj.Condicion = vSit
        obj.Direccion = Mid(words(75), 25, 150).Trim
        obj.Telefonos = Mid(words(85), 25, 150).Trim
        'xresul = xresul & word
        Exit For
        'End If
      Next
      vObj = obj
      xresul = _WebSource


      obj = Nothing

      Return vObj

      myHttpWebResponse.Close()


    Catch ex As Exception
      MessageBox.Show(ex.Message)
      Return Nothing
    End Try
  End Function


End Class
