
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class materialManager

        Public Shared Function material_leer(ByVal vmaterialgrupoid As Integer, ByVal vmaterialsubgrupoid As Integer, ByVal vnombre As String) As DataTable
            Return MaterialBD.material_leerBD(vmaterialgrupoid, vmaterialsubgrupoid, vnombre)
        End Function

        Public Shared Function material_noperiodo_leer(ByVal vperiodo As Integer, ByVal vlimite As Integer, ByVal vnombre As String) As DataTable
            Return MaterialBD.material_noperiodo_leerBD(vperiodo, vlimite, vnombre)
        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As material
            Return MaterialBD.GetItem(vCodigo)
        End Function

        Public Shared Function Grabar(ByVal xCodigo As Long, ByVal xNew As Boolean, ByVal objProd As material) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = MaterialBD.Actualizar(xCodigo, xNew, objProd)

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

        Public Shared Function Eliminar(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = MaterialBD.Eliminar(vCodigo)
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

        Public Shared Function Material_Periodo(ByVal vPeriodo As Long, ByVal vTipo As Integer) As DataTable
            Dim vDtR As New DataTable
            If vTipo = 4 Then
                vDtR = MaterialBD.Material_Periodo(vPeriodo)
            Else
                vDtR = MaterialBD.Material_Pedido_Periodo(vPeriodo, vTipo)
            End If

            Return vDtR
        End Function

        Public Shared Function Material_Periodo_Actualizar(ByVal vnew As Boolean, ByVal inperiodoid As Integer, ByVal inmaterialid As Long, ByVal indetalle As String, _
                                                    ByVal inprecio As Single, ByVal incantidad As Long, ByVal inusuarioid As Long, ByVal inip As String) As Long

            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = MaterialBD.Material_Periodo_Actualizar(vnew, inperiodoid, inmaterialid, indetalle, _
                                                                     inprecio, incantidad, inusuarioid, inip)

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

        Public Shared Function Material_Periodo_Eliminar(ByVal vCodigo As Long, ByVal vArr As String) As Boolean
            Dim rs As DataTable
            Dim vOk As Boolean = False
            Try
                rs = MaterialBD.Material_Periodo_Eliminar(vCodigo, vArr)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vOk = True
                        Else
                            vOk = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                vOk = False
            End Try
            Return vOk
        End Function

        Public Shared Function Material_Periodo_Producto(ByVal vPeriodo As Long, ByVal vMaterialid As Long, ByVal vProducto As Long) As DataTable
            Return MaterialBD.Material_Producto_Periodo(vPeriodo, vMaterialid, vProducto)
        End Function

        Public Shared Function Material_Periodo_Producto_Actualizar(ByVal vnew As Boolean, ByVal tipoPedidoID As Integer, ByVal inperiodoid As Integer, _
                                                                    ByVal inmaterialid As Long, ByVal inproductoid As Long, ByVal inprecio As Single, _
                                                                    ByVal incantidad As Long, ByVal inusuarioid As Long, ByVal inip As String) As Long

            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = MaterialBD.Material_Periodo_Producto_Actualizar(vnew, tipoPedidoID, inperiodoid, inmaterialid, inproductoid, _
                                                                     inprecio, incantidad, inusuarioid, inip)

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

        Public Shared Function Material_Periodo_Producto_Eliminar(ByVal vTipoPedidoid As Integer, ByVal vPeriodo As Long, ByVal vMaterial As Long, _
                                                                  ByVal vArr As String, ByVal vUsuarioId As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Dim vOk As Boolean = False
            Try
                rs = MaterialBD.Material_Periodo_Producto_Eliminar(vTipoPedidoid, vPeriodo, vMaterial, vArr, vUsuarioId, vCaja)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vOk = True
                        Else
                            vOk = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                vOk = False
            End Try
            Return vOk
        End Function

        Public Shared Function Material_Producto_Periodo_rpt(ByVal vPeriodoid As Long, ByVal vTipoPedidoid As Long, ByVal vMaterialid As Long) As DataTable
            Return MaterialBD.Material_Producto_Periodo_rpt(vPeriodoid, vTipoPedidoid, vMaterialid)
        End Function

    End Class
End Namespace