Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class categoria_personaManager
        Public Shared Function GetList() As DataTable
            Return categoria_personaBD.GetList()
        End Function
        Public Shared Function GetItem(ByVal codigo As Integer) As categoria_persona
            Return categoria_personaBD.GetItem(codigo)
        End Function
        Public Shared Function Grabar(ByRef objcategoria_persona As categoria_persona) As Integer
            Try
                Dim idcategoria_persona = categoria_personaBD.Grabar(objcategoria_persona)
                Return idcategoria_persona
            Finally
            End Try
        End Function
        Public Shared Function Eliminar(ByVal Objcategoria_persona As categoria_persona) As Boolean
            Return categoria_personaBD.Eliminar(Objcategoria_persona.codigo)
        End Function
    End Class
End Namespace
