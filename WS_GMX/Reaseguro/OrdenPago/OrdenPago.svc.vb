' NOTE: You can use the "Rename" command on the context menu to change the class name "OrdenPago" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select OrdenPago.svc or OrdenPago.svc.vb at the Solution Explorer and start debugging.

Public Class OrdenPago
    Implements IOrdenPago
    Public db As New OPEntities

#Region "Inserciones a Base de Datos"
    Public Function InsertaPolNoPago(id_pv As Double, cod_usuario As String) As Boolean Implements IOrdenPago.InsertaPolNoPago
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spI_PolNoPago(id_pv, cod_usuario).ToList
            Return IIf(Resultado(0).ToString() = "1", True, False)
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Eliminación de Base de Datos"
    Public Function EliminaPolNoPago(id_pv As String) As Boolean Implements IOrdenPago.EliminaPolNoPago
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spD_PolNoPago(id_pv).ToList
            Return IIf(Resultado(0).ToString() = "1", True, False)
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

    Public Function ObtieneOrdenPago(nro_orden As String, Optional ByVal FiltroBrokerCia As String = "", Optional ByVal FiltroContrato As String = "", Optional ByVal FiltroPoliza As String = "",
                                     Optional ByVal FiltroFecPago As String = "", Optional ByVal FiltroRamoCont As String = "", Optional ByVal FiltroUsuario As String = "", Optional ByVal FiltroEstatus As String = "",
                                     Optional ByVal FiltroFecGen As String = "", Optional ByVal cod_moneda As Integer = -1, Optional ByVal FiltroAseg As String = "", Optional ByVal FiltroMonto As String = "",
                                     Optional ByVal FitroNatOP As String = "", Optional ByVal intFirmas As Integer = -1,
                                     Optional ByVal CodUsuPermiso As String = "") As List(Of spS_OrdenPago_Result) Implements IOrdenPago.ObtieneOrdenPago
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_OrdenPago(nro_orden, FiltroBrokerCia, FiltroContrato, FiltroPoliza, FiltroFecPago,
                                         FiltroRamoCont, FiltroUsuario, FiltroEstatus, FiltroFecGen, cod_moneda, FiltroAseg,
                                         FiltroMonto, FitroNatOP, intFirmas, CodUsuPermiso).ToList
        Catch ex As Exception

        End Try
        Return Resultado
    End Function

    Public Function ObtieneContabilidadOP(nro_op As Integer) As List(Of spS_ContabilidadOP_Result) Implements IOrdenPago.ObtieneContabilidadOP
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_ContabilidadOP(nro_op).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
End Class
