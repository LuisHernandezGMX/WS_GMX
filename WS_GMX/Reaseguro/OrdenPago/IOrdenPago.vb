Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IOrdenPago" in both code and config file together.
<ServiceContract()>
Public Interface IOrdenPago

    <OperationContract()>
    Function ObtieneAclaraciones(id_pv As Integer) As String

End Interface
