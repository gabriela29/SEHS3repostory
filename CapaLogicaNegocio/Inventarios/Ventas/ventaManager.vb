Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class ventaManager

        Public Shared Function GetItem(ByVal codigo As Long) As venta
            Return ventaBD.GetItem(codigo)
        End Function

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = ventaBD.Cambiar_Estado(vCodigo, vUsuario, vCaja)
                'outerrornumber
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

        Public Shared Function Cambiar_Estado_Descontar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = ventaBD.Cambiar_Estado_Descontar(vCodigo, vUsuario, vCaja)
                'outerrornumber
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

        Public Shared Function Venta_Guia_Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                                                 ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                                                 ByVal vNumero As String, ByVal vCliente As Long, ByVal vRazon_Social As String) As DataTable

            Return ventaBD.Venta_Guia_Leer(vAlmacen, vlimite, vdocumento, vVendedor, vFecDesde, vFecHasta, vNumDesde, vNumHasta, vNumero, vCliente, vRazon_Social)

        End Function

        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                     ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                     ByVal vNumero As String, ByVal vCliente As Long, ByVal vRazon_Social As String, ByVal vSigno As String, ByVal vRef As String) As DataTable

            Return ventaBD.Leer(vAlmacen, vlimite, vdocumento, vVendedor, vFecDesde, vFecHasta, vNumDesde, vNumHasta, vNumero, vCliente, vRazon_Social, vSigno, vRef)

        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = ventaBD.Eliminar(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As venta, ByVal myArr As String, ByVal vArrFP As String, _
                                       ByVal vPaga As Single, ByVal vVuelto As Single, ByVal vMaestra As String, ByVal vCodigo_Serie As Integer, _
                                       ByVal vCodigo_Seried As Integer, ByVal vCodigo_Doc_D As Integer, ByVal vNumeroD As String, _
                                       ByVal vImporte_D As Single, ByVal myArr_CxC As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = ventaBD.Agregar(objv, myArr, vArrFP, vPaga, vVuelto, vMaestra, vCodigo_Serie, _
                                        vCodigo_Seried, vCodigo_Doc_D, vNumeroD, vImporte_D, myArr_CxC)
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

        Public Shared Function Leer_Items(ByVal vCodigo As Long) As DataTable
            Return ventaBD.Leer_Items(vCodigo)
        End Function

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

            Return ventaBD.Cambiar_Cierre(vCodigo, vUsuario, vCaja)

        End Function

        Public Shared Function Datos_Impresion(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresManager.Datos_Imprimir_Venta(vCodigo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle



            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

    Public Shared Function Datos_Impresion_PWC(ByVal vCodigo As Long, ByVal vAlmacenid As Integer, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
      Dim xok As Boolean = False
      Try
        xok = cursoresManager.Datos_Imprimir_Venta_PWC(vCodigo, vAlmacenid, dtCabecera, dtDetalle)
        'dtCabecera = dtCabecera
        'dtDetalle = dtDetalle



      Catch ex As Exception
        xok = False
      End Try

      Return xok
    End Function

    'Public Shared Function Datos_Impresion(ByVal vCodigo As Long) As DataTable

    '    Return ventaBD.Eliminar(vCodigo)

    'End Function

    Public Shared Function Consulta_Ventas(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable

            Return ventaBD.Consulta_Ventas(vAlmacen, vSigno, vCliente, vdocumento, vNumero)

        End Function

        Public Shared Function Saldo_Fact_Colportaje_Res(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vDesde As String, _
                                                         ByVal vHasta As String, ByVal vMeta As Single, ByVal vdestinoid As Long, _
                                                         ByVal vtipoid As Integer, ByVal vglosa As String, ByVal vusuarioid As Long, _
                                                         ByVal vcaja As String, ByVal myarray As String) As DataTable

            Return ventaBD.Saldo_Fact_Colportaje_Res(vAlmacenId, vPersonaid, vDesde, vHasta, vMeta, _
                                                     vdestinoid, vtipoid, vglosa, vusuarioid, vcaja, myarray)

        End Function

        Public Shared Function Actualizar_x(ByRef vVentaid As Long, ByVal objV As venta) As Boolean

            Dim rs As DataTable
            Actualizar_x = False
            Try
                rs = ventaBD.Actualizar_x(objV)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vVentaid = rs.DataSet.Tables(0).Rows(0).Item("outid")
                            Actualizar_x = True
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return Actualizar_x
        End Function

    Public Shared Function Cambiar_Usuario(ByVal vVentaID As Long, ByVal vUsuarioId As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = ventaBD.Cambiar_Usuario(vVentaID, vUsuarioId, vCaja)
        'outerrornumber
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

  End Class
End Namespace
