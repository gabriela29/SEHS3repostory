
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmGestion_CobranzaNM
  Public pPorcobrarId As Long, pNumCarta As Integer, pRespId As Long

  Private Sub Mostrar_Registro()
    Dim dtRs As New DataTable
    dtRs = por_cobrarManager.EmitirCartaG(pPorcobrarId, pNumCarta)
    lblNumCarta.Text = "Carta Número: " & pNumCarta
    For Each row As DataRow In dtRs.Rows
      lblCliente.Text = row("dniruc").ToString & " - " & row("nombre_cliente").ToString
      lblAgente.Text = row("agente").ToString
      lblDocumento.Text = row("numero").ToString
      lblProducto.Text = row("producto").ToString
      lblVencimiento.Text = row("vencimiento").ToString
      lblnDias.Text = row("ndias").ToString
      lblDeuda.Text = row("saldo").ToString
      pRespId = row("responsanbleid").ToString
      txtAdicional.Text = row("adicional").ToString
      TxtObservacion.Text = row("observacion").ToString
    Next row
  End Sub

  Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
    Dim ObjG As New porcobrar_gestion, vEmision As String = LibreriasFormularios.Formato_Fecha(Now.Date)

    With ObjG
      .Porcobrarid = pPorcobrarId
      .Num_Carta = pNumCarta
      .Emision = vEmision
      .Ndias = lblnDias.Text
      .Deuda = lblDeuda.Text
      .Adicional = txtAdicional.Text
      .Responsableid = pRespId
      .Estado = 1
      .Observacion = TxtObservacion.Text
      .UsuarioId = GestionSeguridadManager.idUsuario
      .caja = My.Computer.Name
    End With
    If porcobrar_gestionManager.Grabar(ObjG) > 0 Then
      Me.Close()
    End If
  End Sub

  Private Sub FrmGestion_CobranzaNM_Load(sender As Object, e As EventArgs) Handles Me.Load
    lblFecha.Text = Now.Date
    Call Mostrar_Registro()
  End Sub
End Class