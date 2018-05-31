Imports CapaLogicaNegocio.Bll
Public Class Numeros_Letras
  'numeros a letras
  Public Shared Function EnLetras(ByVal numero As String) As String
    Dim B, paso As Long
    Dim expresion As String = "", entero As String = ""
    Dim deci As String = "", Flag As String
    Flag = "N"
    For paso = 1 To Len(numero)
      If Mid(numero, paso, 1) = "." Or Mid(numero, paso, 1) = "," Then
        Flag = "S"
      Else
        If Flag = "N" Then
          entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
        Else
          deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
        End If
      End If
    Next paso

    If Len(deci) = 1 Then
      deci = deci & "0"
    End If

    Flag = "N"
    If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
      For paso = Len(entero) To 1 Step -1
        B = Len(entero) - (paso - 1)
        Select Case paso
          Case 3, 6, 9
            Select Case Mid(entero, B, 1)
              Case "1"
                If Mid(entero, B + 1, 1) = "0" And Mid(entero, B + 2, 1) = "0" Then
                  expresion = expresion & "cien "
                Else
                  expresion = expresion & "ciento "
                End If
              Case "2"
                expresion = expresion & "doscientos "
              Case "3"
                expresion = expresion & "trescientos "
              Case "4"
                expresion = expresion & "cuatrocientos "
              Case "5"
                expresion = expresion & "quinientos "
              Case "6"
                expresion = expresion & "seiscientos "
              Case "7"
                expresion = expresion & "setecientos "
              Case "8"
                expresion = expresion & "ochocientos "
              Case "9"
                expresion = expresion & "novecientos "
            End Select

          Case 2, 5, 8
            Select Case Mid(entero, B, 1)
              Case "1"
                If Mid(entero, B + 1, 1) = "0" Then
                  Flag = "S"
                  expresion = expresion & "diez "
                End If
                If Mid(entero, B + 1, 1) = "1" Then
                  Flag = "S"
                  expresion = expresion & "once "
                End If
                If Mid(entero, B + 1, 1) = "2" Then
                  Flag = "S"
                  expresion = expresion & "doce "
                End If
                If Mid(entero, B + 1, 1) = "3" Then
                  Flag = "S"
                  expresion = expresion & "trece "
                End If
                If Mid(entero, B + 1, 1) = "4" Then
                  Flag = "S"
                  expresion = expresion & "catorce "
                End If
                If Mid(entero, B + 1, 1) = "5" Then
                  Flag = "S"
                  expresion = expresion & "quince "
                End If
                If Mid(entero, B + 1, 1) > "5" Then
                  Flag = "N"
                  expresion = expresion & "dieci"
                End If

              Case "2"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "veinte "
                  Flag = "S"
                Else
                  expresion = expresion & "veinti"
                  Flag = "N"
                End If

              Case "3"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "treinta "
                  Flag = "S"
                Else
                  expresion = expresion & "treinta y "
                  Flag = "N"
                End If

              Case "4"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "cuarenta "
                  Flag = "S"
                Else
                  expresion = expresion & "cuarenta y "
                  Flag = "N"
                End If

              Case "5"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "cincuenta "
                  Flag = "S"
                Else
                  expresion = expresion & "cincuenta y "
                  Flag = "N"
                End If

              Case "6"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "sesenta "
                  Flag = "S"
                Else
                  expresion = expresion & "sesenta y "
                  Flag = "N"
                End If

              Case "7"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "setenta "
                  Flag = "S"
                Else
                  expresion = expresion & "setenta y "
                  Flag = "N"
                End If

              Case "8"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "ochenta "
                  Flag = "S"
                Else
                  expresion = expresion & "ochenta y "
                  Flag = "N"
                End If

              Case "9"
                If Mid(entero, B + 1, 1) = "0" Then
                  expresion = expresion & "noventa "
                  Flag = "S"
                Else
                  expresion = expresion & "noventa y "
                  Flag = "N"
                End If
            End Select

          Case 1, 4, 7
            Select Case Mid(entero, B, 1)
              Case "1"
                If Flag = "N" Then
                  If paso = 1 Then
                    expresion = expresion & "uno "
                  Else
                    expresion = expresion & "un "
                  End If
                End If
              Case "2"
                If Flag = "N" Then
                  expresion = expresion & "dos "
                End If
              Case "3"
                If Flag = "N" Then
                  expresion = expresion & "tres "
                End If
              Case "4"
                If Flag = "N" Then
                  expresion = expresion & "cuatro "
                End If
              Case "5"
                If Flag = "N" Then
                  expresion = expresion & "cinco "
                End If
              Case "6"
                If Flag = "N" Then
                  expresion = expresion & "seis "
                End If
              Case "7"
                If Flag = "N" Then
                  expresion = expresion & "siete "
                End If
              Case "8"
                If Flag = "N" Then
                  expresion = expresion & "ocho "
                End If
              Case "9"
                If Flag = "N" Then
                  expresion = expresion & "nueve "
                End If
            End Select
        End Select
        If paso = 4 Then
          If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
            (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
             Len(entero) <= 6) Then
            expresion = expresion & "mil "
          End If
        End If
        If paso = 7 Then
          If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
            expresion = expresion & "millón "
          Else
            expresion = expresion & "millones "
          End If
        End If
      Next paso
      If deci <> "" Then
        If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
          EnLetras = "menos " & expresion & "con " & deci & "/100"
        Else
          EnLetras = expresion & "con " & deci & "/100 " & Configuracion.pNom_Moneda
        End If
      Else
        If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
          EnLetras = "menos " & expresion
        Else
          EnLetras = expresion & "00/100 " & Configuracion.pNom_Moneda
        End If
      End If
    Else 'si el numero a convertir esta fuera del rango superior e inferior
      EnLetras = ""
    End If
  End Function
End Class
