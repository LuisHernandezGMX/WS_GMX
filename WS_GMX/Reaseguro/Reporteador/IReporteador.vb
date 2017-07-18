Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IReporteador" in both code and config file together.
<ServiceContract()>
Public Interface IReporteador

    <OperationContract()>
    Function InsertaVersionReporte(cod_modulo As Integer, cod_submodulo_web As Integer, cod_reporte As Integer,
                                          cod_usuario As String, descripcion As String, filtros As String, formato As String,
                                          Optional sn_Temporal As Integer = 0) As List(Of Nullable(Of Int32))

End Interface
