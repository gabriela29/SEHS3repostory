Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class movimiento_bancarioManager

        Public Shared Function pamovimiento_bancario_leer_ing(ByVal vcuenta As Integer, ByVal vdocumento As Integer, ByVal vdesde As String, ByVal vhasta As String, _
                                                               ByVal vtipo As String, ByVal vcodigo_tip As Integer, ByVal vpersona As Long, ByVal valmacen As Integer, _
                                                               ByVal vlote As Long, ByVal vSerie As String)
            Return movimiento_bancarioBD.pamovimiento_bancario_leer_ing(vcuenta, vdocumento, vdesde, vhasta, vtipo, vcodigo_tip, vpersona, valmacen, vlote, vSerie)
        End Function


        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = movimiento_bancarioBD.Cambiar_Estado(vCodigo, vUsuario, vCaja)

                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vOk = True
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vOk
        End Function

        Public Shared Function Reporte_Recibo_Interno_pc(ByVal vCodigo As Long) As DataTable
            Return movimiento_bancarioBD.Reporte_Recibo_Interno_pc(vCodigo)
        End Function

        Public Shared Function Registrar_Anticipo_Web(ByRef objMB As movimiento_bancario, ByVal vTipoFpId As Integer, ByVal vSerieId As Long, _
                                                      ByVal myArr_MB As String, ByVal myArr_RMB As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = movimiento_bancarioBD.Registrar_Anticipo_Web(objMB, vTipoFpId, vSerieId, myArr_MB, myArr_RMB)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function Grabar(ByRef objmb As movimiento_bancario, ByVal myArrFP As String, ByVal myArrCXC_CXP As String, ByVal myArrPre As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = movimiento_bancarioBD.Grabar(objmb, myArrFP, myArrCXC_CXP, myArrPre)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = movimiento_bancarioBD.Eliminar(vCodigo, vUsuario, vCaja)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar = True
                        Else
                            Eliminar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar = False
            End Try
            Return Eliminar
        End Function

        Public Shared Function Datos_Impresion(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable, ByVal sIng As Boolean) As Boolean
            Dim xok As Boolean = False
            Try
                If sIng Then
                    xok = cursoresBD.Datos_Imprimir_MB_Ing(vCodigo, dtCabecera, dtDetalle)
                Else
                    xok = cursoresBD.Datos_Imprimir_MB(vCodigo, dtCabecera, dtDetalle)
                End If

                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle

            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

        Public Shared Function Datos_Imprimir_Anticipos_Fact(ByVal vCodigo As Long, ByVal vAlmacenid As Integer, ByVal vTipoid As Integer, ByVal vPeriodo As String, _
                                                             ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresBD.Datos_Imprimir_Anticipos_Fact(vCodigo, vAlmacenid, vTipoid, vPeriodo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle

            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

        Public Shared Function Datos_Imprimir_Suscripcion_Fact(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer, _
                                                                 ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String, _
                                                                 ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                                                                 ByVal vDMid As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresBD.Datos_Imprimir_Suscripciones_Vta(vAlmacenid, vIglesiaid, vPeriodoid, vPersonaid, vDocumentoid, vDesde, _
                                                                 vHasta, vNumDesde, vNumHasta, vDMid, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle

            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

        Public Shared Function Datos_Imprimir_Pedido_Fact(ByVal vAlmacenid As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoid As Integer, _
                                                         ByVal vPersonaid As Long, ByVal vDocumentoid As Integer, ByVal vDesde As String, _
                                                         ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                                                         ByVal vDMid As Long, ByVal vUnidadId As Integer, ByVal vTipo As String, _
                                                         ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresBD.Datos_Imprimir_Pedido_Vta(vAlmacenid, vIglesiaid, vPeriodoid, vPersonaid, vDocumentoid, vDesde, _
                                                                 vHasta, vNumDesde, vNumHasta, vDMid, vUnidadId, vTipo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle

            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

        Public Shared Function Actualizar_NroCta(ByVal xCodigo As Long, ByVal xNroCta As String) As Boolean

            Try
                Actualizar_NroCta = movimiento_bancarioBD.Actualizar_NroCta(xCodigo, xNroCta)
                'outerrornumber

            Finally

            End Try
            Return Actualizar_NroCta
        End Function

    Public Shared Function Registrar_Uso_Sobrante(ByVal vMovBanId As Long, ByVal myArrCxC As String) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = movimiento_bancarioBD.Registrar_Uso_Sobrante(vMovBanId, myArrCxC)
        'outerrornumber
        If Not rs Is Nothing Then
          If rs.DataSet.Tables(0).Rows.Count > 0 Then
            If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
              vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
            Else
              MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
            End If
          End If
        End If
      Finally
        rs = Nothing
      End Try
      Return vCodigo
    End Function

    Public Shared Function Movimiento_BancarioTFP(ByVal vUni As Integer, ByVal vAlmId As Integer, ByVal vTFP As Integer,
                                                     ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Return movimiento_bancarioBD.Movimiento_BancarioTFP(vUni, vAlmId, vTFP, vDesde, vHasta)
    End Function

    Public Shared Function tipo_forma_pago_leer(ByVal xNombre As String) As DataTable

      Try
        tipo_forma_pago_leer = movimiento_bancarioBD.tipo_forma_pago_leer(xNombre)

      Finally

      End Try
      Return tipo_forma_pago_leer
    End Function

  End Class
End Namespace

