Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IOrdenPago" in both code and config file together.
<ServiceContract()>
Public Interface IOrdenPago

#Region "Inserciones a Base de Datos"
    <OperationContract()>
    Function InsertaPolNoPago(id_pv As Double, cod_usuario As String) As Boolean
#End Region

#Region "Eliminación de Base de Datos"
    <OperationContract()>
    Function EliminaPolNoPago(id_pv As String) As Boolean
#End Region


    <OperationContract()>
    Function ObtieneOrdenPago(nro_orden As String, Optional ByVal FiltroBrokerCia As String = "", Optional ByVal FiltroContrato As String = "", Optional ByVal FiltroPoliza As String = "",
                              Optional ByVal FiltroFecPago As String = "", Optional ByVal FiltroRamoCont As String = "", Optional ByVal FiltroUsuario As String = "", Optional ByVal FiltroEstatus As String = "",
                              Optional ByVal FiltroFecGen As String = "", Optional ByVal cod_moneda As Integer = -1, Optional ByVal FiltroAseg As String = "", Optional ByVal FiltroMonto As String = "",
                              Optional ByVal FitroNatOP As String = "", Optional ByVal intFirmas As Integer = -1,
                              Optional ByVal CodUsuPermiso As String = "") As List(Of spS_OrdenPago_Result)

    <OperationContract()>
    Function ObtieneContabilidadOP(nro_op As Integer) As List(Of spS_ContabilidadOP_Result)
End Interface
