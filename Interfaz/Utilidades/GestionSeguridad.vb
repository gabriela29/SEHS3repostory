Imports CapaObjetosNegocio.BO
Imports CapaLogicaNegocio.Bll
Imports System.Net

Public Class GestionSeguridad
    'Public Shared idUsuario As Long
    'Public Shared NombreUS As String
    'Public Shared Serie As Integer
    'Public Shared NombrePC As String

    Public Shared Sub LeerConfiguracionMenusOpciones(ByVal idPersonal As Long)
        'Dim Mc As ToolStripMenuItem
        'Dim frmMenuPrincipal As New frmMenuPrincipal
        'For Each Mc In frmMenuPrincipal.MenuStrip.Items
        '    If Not Mc.Text = "-" Then
        '        If UbicarMenuConfiguracion(CInt(idPersonal), Mc.Name) = 0 Then '1=Solo Lectura, 2=Total
        '            Mc.Enabled = False
        '        Else
        '            Mc.Enabled = True
        '        End If
        '    End If

        '    If (Mc.DropDownItems.Count > 0) Then
        '        Try
        '            ConfigurarOpcionesMenu(Mc.DropDownItems, CInt(idPersonal))
        '        Catch ex As Exception

        '        End Try
        '    End If
        'Next
    End Sub

    Public Shared Function ObtenermiIP() As String
        'Dim ip As Net.Dns
        Dim nombre_Host As String = Net.Dns.GetHostName
        Dim este_Host As Net.IPHostEntry = Dns.GetHostEntry(My.Computer.Name)
        Dim direccion_Ip As String = este_Host.AddressList(0).ToString
        ObtenermiIP = direccion_Ip

    End Function

    Public Shared Function getIp() As String
        Dim ip As System.Net.IPHostEntry
        ip = Dns.GetHostEntry(My.Computer.Name)

        Dim valorIp As String, xCont As Integer = 0

        valorIp = ""

        For Each valor As IPAddress In ip.AddressList
            If xCont = 4 Then
                valorIp = valor.ToString()
            End If

            xCont += 1
        Next

        getIp = valorIp

    End Function

    Public Shared Function SolomiIP() As String
        Dim ip As System.Net.IPHostEntry
        ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
        SolomiIP = ip.AddressList(0).ToString

    End Function

    Private Shared Sub ConfigurarOpcionesMenu(ByRef colOpcionesMenu As ToolStripItemCollection, ByVal idPersonal As Integer)
        Dim itmOpcion As ToolStripItem
        For Each itmOpcion In colOpcionesMenu
            If Not itmOpcion.Text.Trim = "-" Then
                If UbicarMenuConfiguracion(idPersonal, itmOpcion.Name) = 0 Then '1=Solo Lectura, 2=Total
                    itmOpcion.Enabled = False
                Else
                    itmOpcion.Enabled = True
                End If
            End If
            Try
                If CType(itmOpcion, ToolStripMenuItem).DropDownItems.Count > 0 Then
                    ConfigurarOpcionesMenu(CType(itmOpcion, ToolStripMenuItem).DropDownItems, idPersonal)
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Public Shared Function UbicarMenuConfiguracion(ByVal idPersonal As Integer, ByVal NombreMenu As String) As Integer
        'Dim objPersonal As New Trabajador
        'objPersonal = TrabajadorManager.GetItem(idPersonal)
        'If objPersonal.NivelAcceso = 1 Then '1=Administrador, 2=Operador
        '    Return 2
        'Else
        '    Dim opcionesMenu As New Accesos_Usuarios_Menus
        '    opcionesMenu = Accesos_Usuarios_MenusManager.ObtenerItemGrabado(idPersonal, NombreMenu)
        '    Return opcionesMenu.Permiso
        'End If
        'objPersonal = Nothing
    End Function



End Class
