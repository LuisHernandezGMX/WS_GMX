Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IRecSiniestros" in both code and config file together.
<ServiceContract()>
Public Interface IRecSiniestros

    <OperationContract()>
    Function ActualizaFaseRecup(id_Fase As Int32, strFase As String) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function InsertaFaseRecup(strFase As String) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function EliminaFaseRecup(id_Fase As Int32) As List(Of Nullable(Of Int32))
End Interface
