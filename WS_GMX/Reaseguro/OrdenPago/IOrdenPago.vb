Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IOrdenPago" in both code and config file together.
<ServiceContract()>
Public Interface IOrdenPago

#Region "Inserciones a Base de Datos"
    <OperationContract()>
    Function InsertaPolNoPago(id_pv As Double, cod_usuario As String) As String
#End Region

#Region "Eliminación de Base de Datos"
    Function EliminaPolNoPago(id_pv As String) As String
#End Region
End Interface
