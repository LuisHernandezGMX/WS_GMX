Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGenerales" in both code and config file together.
<ServiceContract()>
Public Interface IGenerales


#Region "Inserciones a Base de Datos"
    <OperationContract()>
    Function InsertaBitacora(cod_modulo As Integer, cod_submodulo_web As Integer, cod_usuario As String, Descripcion As String) As Boolean

    <OperationContract()>
    Function InsertaError(cod_modulo As Integer, cod_submodulo_web As Integer, cod_usuario As String, ErrorWeb As String) As Boolean

    <OperationContract()>
    Function InsertaATabla(strTabla As String, strKey As String, strDatos As String) As Boolean
#End Region


    <OperationContract()>
    Function IsAuthenticated(Domain As String, username As String, pwd As String) As Boolean

    <OperationContract()>
    Function ObtieneUsuario(cod_usuarioNT As String) As List(Of spS_Usuario_Result)

    <OperationContract()>
    Function ObtieneMenu(cod_usuario As String, cod_modulo As Integer) As List(Of spS_MenuWeb_Result)

    <OperationContract()>
    Function EnviaCorreo(strTo As String, strBody As String, strSubject As String, Optional strCc As String = vbNullString, Optional strBco As String = vbNullString) As Boolean

    <OperationContract()>
    Function ObtieneCatalogo(strPrefijo As String, Optional strCondicion As String = "", Optional strSel As String = "") As List(Of spS_CatalogosOP_Result2)

    <OperationContract()>
    Function ObtienePolizas(cod_suc As Integer, cod_ramo As Integer, nro_pol As Double, str_pol As String, bln_garantias As Boolean,
                            FechaIni As String, FechaFin As String, sn_Ajuste As Integer, Optional submod_web As Integer = -1) As List(Of spS_ListaPoliza_Result)

    <OperationContract()>
    Function ObtieneEndosos(str_pol As String, FecEmision As String) As List(Of spS_ListaEndoso_Result)

    <OperationContract()>
    Function ObtienePagador(id_pv As Double) As List(Of spS_Pagador_Result)

    <OperationContract()>
    Function ObtienePagadorCuotas(id_pv As Double, ind_pag As Integer, cod_aseg As Double) As List(Of spS_PagadorCuotas_Result)

    <OperationContract()>
    Function ObtieneDetallePagoCuota(id_pv As Double, cod_aseg As Double, ind_pag As Integer, nro_cuota As Integer) As List(Of spS_DetallePagosCob_Result)

    <OperationContract()>
    Function ObtieneEndososNoPago(cod_usuario As String) As List(Of spS_EndososNoPagoOP_Result)

    <OperationContract()>
    Function ObtieneAclaraciones(id_pv As Integer) As String

    <OperationContract()>
    Function ObtieneParametro(cPAR_Id As Integer) As String

    <OperationContract()>
    Function ActualizaParametro(cPAR_Id As Int32, cPAR_Value As String) As List(Of Nullable(Of Int32))
End Interface
