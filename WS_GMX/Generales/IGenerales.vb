Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGenerales" in both code and config file together.
<ServiceContract()>
Public Interface IGenerales

    <OperationContract()>
    Function EnviaCorreo(strTo As String, strBody As String, strSubject As String, Optional strCc As String = vbNullString, Optional strBco As String = vbNullString) As Boolean

    <OperationContract()>
    Function ObtieneCatalogo(strPrefijo As String, Optional strCondicion As String = "", Optional strSel As String = "") As List(Of spS_CatalogosOP_Result)

End Interface
