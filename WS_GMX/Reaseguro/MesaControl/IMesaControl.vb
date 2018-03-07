Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IMesaControl" in both code and config file together.
<ServiceContract()>
Public Interface IMesaControl

    <OperationContract()>
    Function ObtieneIndicadores(id_folio As Integer) As List(Of spS_IndicadoresMC_Result)

    <OperationContract()>
    Function ObtieneIdFolio(Folio As String) As List(Of spS_IdFolioMC_Result)

    <OperationContract()>
    Function ObtieneNegocio(id_folio As String, cod_suc_ofi As Integer, fec_corte_ini As String, fec_corte_fin As String, cod_moneda As Integer,
                            cod_usuario As String, estatus As Integer, strAsegurado As String, strGiro As String, strAgrupador As String,
                            strRamo As String, strBroker As String, strCia As String) As List(Of spS_MesaControl_Result)

    <OperationContract()>
    Function ObtieneRiesgo(id_folio As Integer) As List(Of spS_RiesgosMC_Result)

    <OperationContract()>
    Function ObtieneGrupos(id_folio As Integer) As List(Of spS_GruposMC_Result)

    <OperationContract()>
    Function ObtieneReparto(id_folio As Integer) As List(Of spS_RepartoMC_Result)

    <OperationContract()>
    Function ObtieneProgramaCapas(id_folio As Integer) As List(Of spS_ProgramaCapasMC_Result)

    <OperationContract()>
    Function ObtieneCapas(id_folio As Integer) As List(Of spS_CapasMC_Result)

    <OperationContract()>
    Function ObtieneDistribucion(id_folio As Integer) As List(Of spS_DistribucionMC_Result)

    <OperationContract()>
    Function ObtieneBrokers(id_folio As Integer) As List(Of spS_IntermediarioMC_Result)

    <OperationContract()>
    Function ObtieneReaseguradores(id_folio As Integer) As List(Of spS_ReaseguradorMC_Result)

    <OperationContract()>
    Function ObtieneSubjetividad(id_folio As Integer) As List(Of spS_SubjetividadMC_Result)

    <OperationContract()>
    Function ObtienePolizasAseg(txt_aseg As String) As List(Of spS_PolizasAsegurado_Result)

    <OperationContract()>
    Function ObtieneRiesgoPoliza(cod_suc As Integer, cod_ramo As Integer, nro_pol As Integer, aaaa_endoso As Integer, nro_endoso As Integer, cod_item As Integer, strSel As String) As List(Of spS_RiesgoPoliza_Result)

    <OperationContract()>
    Function ObtieneUbicacionesPoliza(cod_suc As Integer, cod_ramo As Integer, nro_pol As Integer, aaaa_endoso As Integer, nro_endoso As Integer) As List(Of spS_UbicacionesPoliza_Result)
End Interface
