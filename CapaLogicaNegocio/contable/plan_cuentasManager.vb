Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll

    Public Class plan_cuentasManager

        Public Shared Function GetRow(ByVal ctaMaestra As String, ByVal descripcion As String, ByVal xLimit As Integer) As DataTable
            Return plan_cuentasBD.GetRow(ctaMaestra, descripcion, xLimit)
        End Function

        Public Shared Function Plan_GetList(ByVal cuenta As Long, ByVal nombre As String, ByVal restrincode As String, ByVal xlimit As Long) As DataTable
            Return plan_cuentasBD.Plan_GetList(cuenta, nombre, restrincode, xlimit)
        End Function

        Public Shared Function Plan_CtaCte_GetList(ByVal vEntidad As Long) As DataTable
            Return plan_cuentasBD.PlanCtaCte_GetList(vEntidad)
        End Function

    Public Shared Function Plan_CtaCte_GetList(ByVal vEntidad As Long, ByVal vTipo As String, ByVal vNombre As String) As DataTable
      Return plan_cuentasBD.PlanCtaCte_GetList(vEntidad, vTipo, vNombre)
    End Function

    Public Shared Function GetList(ByVal ctaMaestra As String, ByVal descripcion As String, ByVal xLimit As Integer) As DataTable
            Return plan_cuentasBD.GetList(ctaMaestra, descripcion, xLimit)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As plan_cuentas
            Return plan_cuentasBD.GetItem(codigo)
        End Function

        Public Shared Function Grabar(ByRef objplan_cuentas As plan_cuentas) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = plan_cuentasBD.Grabar(objplan_cuentas)

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

        Public Shared Function Eliminar(ByVal Objplan_cuentas As plan_cuentas) As Boolean
            Dim rs As DataTable
            Try
                rs = plan_cuentasBD.Eliminar(Objplan_cuentas.codigo)
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

        '========================Gestion Plan Cta Cte=========================================
        Public Shared Function AgregarCtaCte(ByRef vEntidad As Long, ByVal myArr As String, ByVal vUsuarioId As Long, ByVal vCaja As String) As Long
            Dim rs As DataTable
            Dim vCodigo As Long = 0
            Try
                rs = plan_cuentasBD.Agregar_CtaCte(vEntidad, myArr, vUsuarioId, vCaja)
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


    End Class
End Namespace
