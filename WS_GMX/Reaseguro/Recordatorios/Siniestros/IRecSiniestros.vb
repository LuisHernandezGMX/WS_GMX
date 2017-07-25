Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IRecSiniestros" in both code and config file together.
<ServiceContract()>
Public Interface IRecSiniestros

#Region "Fase de Recuperación"
    <OperationContract()>
    Function ActualizaFaseRecup(id_Fase As Int32, strFase As String) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function InsertaFaseRecup(strFase As String) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function EliminaFaseRecup(id_Fase As Int32) As List(Of Nullable(Of Int32))

#End Region
#Region "Estatus Siniestro"
    <OperationContract()>
    Function InsertaEstatusStro(strEstatus As String, id_Fase As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function ActualizaEstatusStro(id_Estatus As Int32, strFase As String, id_Fase As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function EliminaEstatusStro(id_Estatus As Int32) As List(Of Nullable(Of Int32))
#End Region
#Region "Niveles"
    <OperationContract()>
    Function InsertaNivel(strNivel As String, DiasT As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function ActualizaNivel(id_Nivel As Int32, strNivel As String, DiasT As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function EliminaNivel(id_Nivel As Int32) As List(Of Nullable(Of Int32))
#End Region
#Region "Aviso Usuarios"
    <OperationContract()>
    Function InsertaAvUsuario(cod_usuario As String, cod_sector As Integer, id_nivel As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function ActualizaAvUsuario(cod_usuario As String, cod_sector As Integer, idav As Integer, id_nivel As Integer) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function EliminaAvUsuario(idav As Int32) As List(Of Nullable(Of Int32))
#End Region
#Region "Job"
    <OperationContract()>
    Function ActualizaJobParam(srtHora As String, blnActivo As Boolean) As List(Of Nullable(Of Int32))

    <OperationContract()>
    Function ActualizaHoraJob(srtHoraIni As String, strFechaIni As String, Activado As Boolean) As List(Of Nullable(Of Int32))
#End Region
#Region "ConsultaSiniestros"
    <OperationContract()>
    Function ObtieneSiniestros(tipo_mov As Integer, nro_stro As String, broker As String, aseg As String, reaseg As String,
                                      cod_ramo_conta As String, poliza As String, Optional fec_desde As String = vbNullString,
                                      Optional fec_hasta As String = vbNullString) As List(Of sp_rptMovSinxReas_Result)
#End Region
End Interface
