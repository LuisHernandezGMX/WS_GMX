Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IFirmasDigital" in both code and config file together.
<ServiceContract()>
Public Interface IFirmasDigital

    <OperationContract()>
    Function ActualizaFirma(NumOp As String, TipoPer As Integer, CodUsu As String) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function ObtieneUsuarioFirmaE(TipoUsuario As Integer) As List(Of spS_UsuarioFirma_Result)

    <OperationContract()>
    Function ObtienePermisosXUsu(CodUsu As String) As List(Of spS_PermisosxUSuFirma_Result)

    <OperationContract()>
    Function ActualizaDestinatarioFirma(CodUsu As String, CodRol As Integer) As List(Of Nullable(Of Int32))

End Interface
