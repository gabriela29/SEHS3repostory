

Public Class EResponsables_Grupo

    Public Property grupoid() As Single
    Public Property nombre() As String
    Public Property abreviatura() As String
    Public Property responsableid() As Single
    Public Property rucdni() As String
    Public Property responsable_nombre() As String
    Public Property responsable_direccion() As String
    Public Property responsable_telefono() As String
    Public Property responsable_email() As String
    Public Property responsable_foto() As String
    Public Property responsable_sexo() As String
    Public Property cantidad_iglesias() As Single
    Public Property total_depositos() As Single
    Public Property total_suscripcion() As Single

End Class


Public Class EResponsables_Iglesia
    Public Property iglesiaid() As Long
    Public Property nombre() As String
    Public Property abreviatura() As String
    Public Property grupoid() As Long
    Public Property grupo_nombre() As String
    Public Property grupo_abreviatura() As String
    Public Property responsableid() As Long
    Public Property rucdni() As String
    Public Property responsable_nombre() As String
    Public Property responsable_direccion() As String
    Public Property responsable_telefono() As String
    Public Property responsable_email() As String
    Public Property responsable_foto() As String
    Public Property responsable_sexo() As String
    Public Property total_depositos() As Single
    Public Property total_suscripcion() As Single

End Class

Public Class EDetalle_Deposito
    Public Property depositoid As Long
    Public Property fecha As Date
    Public Property responsable As String
    Public Property banco As String
    Public Property cerrado As String
    Public Property DNI As String
    Public Property Miembro As String
    Public Property suscripcion As Single
    Public Property deposito As Single
    Public Property porcobrar As Byte()
End Class

Public Class EDetalle_Suscripcion
    Public Property suscripcionid As Long
    Public Property fecha As Date
    Public Property registro As Date
    Public Property numero As String
    Public Property periodo As String
    Public Property responsable As String
    Public Property dnisus As String
    Public Property nombre_sus As String
    Public Property telefono_sus As String
    Public Property materialid As Long
    Public Property nombre As String
    Public Property cantidad As Long
    Public Property precio As Single
    Public Property importe As Single
    Public Property observacion As String
End Class