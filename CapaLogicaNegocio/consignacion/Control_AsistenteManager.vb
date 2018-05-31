Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class Control_AsistenteManager

        Public Shared Function Leer_Asistentes(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer) As DataTable
            Return control_asistenteBD.Leer_Asistentes(vUnidad, vAlmacen, vCampania)
        End Function

        Public Shared Function Leer_Asistentes_Cbo(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer) As DataTable
            Return control_asistenteBD.Leer_Asistentes_Cbo(vUnidad, vAlmacen, vCampania)
        End Function

        Public Shared Function Leer_Colportores(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vAsistente As Long) As DataTable
            Return control_asistenteBD.Leer_Colportores(vUnidad, vAlmacen, vCampania, vAsistente)
        End Function

    Public Shared Function Leer_Colportores_Tras(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vAsistente As Long) As DataTable
      Return control_asistenteBD.Leer_Colportores_Tras(vUnidad, vAlmacen, vCampania, vAsistente)
    End Function

    Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Return por_cobrarBD.Leer_Experian(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)
        End Function

        Public Shared Function Grabar(ByVal vNew As Boolean, ByRef objPC As personas_campania) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                If vNew Then
                    rs = control_asistenteBD.Grabar(objPC)

                    If Not rs Is Nothing Then
                        If rs.DataSet.Tables(0).Rows.Count > 0 Then
                            If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                                vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                            Else
                                MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                            End If
                        End If
                    End If

                Else
                    rs = control_asistenteBD.Actualizar(objPC)

                    vCodigo = 1

                End If


            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

    Public Shared Function Trasladar_Colportor(ByRef objPC As personas_campania, ByVal vAlmacenid As Integer,
                                                ByVal vAsistenteid As Long, ByVal vSaldo As Single) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try

        rs = control_asistenteBD.Trasladar_Colportor(objPC, vAlmacenid, vAsistenteid, vSaldo)
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

    Public Shared Function Eliminar(ByVal vcampania As Integer, ByVal valmacen As Integer, ByVal vasistente As Long, ByVal vColportor As Long) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = control_asistenteBD.Eliminar(vcampania, valmacen, vasistente, vColportor)

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
    Public Shared Function Trasladar_Colportor_Bloque(ByVal vCampaniaId As Integer, ByVal vAlmacenid As Integer, ByVal vAsistenteid As Long, ByVal VCampDest As Integer,
                                                      ByVal vCcosto As Integer, ByVal vArray As String, ByVal inUs As String, ByVal inCaja As String) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try

        rs = control_asistenteBD.Trasladar_Colportor_Bloque(vCampaniaId, vAlmacenid, vAsistenteid, VCampDest, vCcosto, vArray, inUs, inCaja)
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
  End Class
End Namespace