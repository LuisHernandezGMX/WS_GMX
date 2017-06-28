Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGenerales" in both code and config file together.
<ServiceContract()>
Public Interface IGenerales

    <OperationContract()>
    Function EnviaCorreo(strTo As String, strBody As String, strSubject As String, Optional strCc As String = vbNullString, Optional strBco As String = vbNullString) As Boolean

    <OperationContract()>
    Function ObtieneCatalogo(strPrefijo As String, Optional strCondicion As String = "", Optional strSel As String = "") As List(Of spS_CatalogosOP_Result2)

    <OperationContract()>
    Function ObtienePolizas(cod_suc As Integer, cod_ramo As Integer, nro_pol As Double, str_pol As String, bln_garantias As Boolean,
                            FechaIni As String, FechaFin As String, sn_Ajuste As Integer) As List(Of spS_ListaPoliza_Result)
End Interface
