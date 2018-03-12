Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IBordereaux" in both code and config file together.
<ServiceContract()>
Public Interface IBordereaux

    <OperationContract()>
    Function GetAjustesHist(fec_desden As String, fec_hasta As String) As List(Of spS_AjusteHistBdx_Result2)

End Interface
