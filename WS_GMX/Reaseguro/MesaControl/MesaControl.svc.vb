' NOTE: You can use the "Rename" command on the context menu to change the class name "MesaControl" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select MesaControl.svc or MesaControl.svc.vb at the Solution Explorer and start debugging.
Public Class MesaControl
    Implements IMesaControl
    Public db As New MCtrlEntities
    Public Function ObtieneIndicadores(id_folio As Integer) As List(Of spS_IndicadoresMC_Result) Implements IMesaControl.ObtieneIndicadores
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_IndicadoresMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneIdFolio(Folio As String) As List(Of spS_IdFolioMC_Result) Implements IMesaControl.ObtieneIdFolio
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_IdFolioMC(Folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneNegocio(id_folio As String, cod_suc_ofi As Integer, fec_corte_ini As String, fec_corte_fin As String, cod_moneda As Integer,
                                   cod_usuario As String, estatus As Integer, strAsegurado As String, strGiro As String, strAgrupador As String,
                                   strRamo As String, strBroker As String, strCia As String) As List(Of spS_MesaControl_Result) Implements IMesaControl.ObtieneNegocio
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_MesaControl(id_folio, cod_suc_ofi, fec_corte_ini, fec_corte_fin, cod_moneda, cod_usuario, estatus, strAsegurado, strGiro, strAgrupador, strRamo, strBroker, strCia).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneRiesgo(id_folio As Integer) As List(Of spS_RiesgosMC_Result) Implements IMesaControl.ObtieneRiesgo
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_RiesgosMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneGrupos(id_folio As Integer) As List(Of spS_GruposMC_Result) Implements IMesaControl.ObtieneGrupos
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_GruposMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneReparto(id_folio As Integer) As List(Of spS_RepartoMC_Result) Implements IMesaControl.ObtieneReparto
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_RepartoMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneProgramaCapas(id_folio As Integer) As List(Of spS_ProgramaCapasMC_Result) Implements IMesaControl.ObtieneProgramaCapas
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_ProgramaCapasMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneCapas(id_folio As Integer) As List(Of spS_CapasMC_Result) Implements IMesaControl.ObtieneCapas
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_CapasMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneDistribucion(id_folio As Integer) As List(Of spS_DistribucionMC_Result) Implements IMesaControl.ObtieneDistribucion
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_DistribucionMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneBrokers(id_folio As Integer) As List(Of spS_IntermediarioMC_Result) Implements IMesaControl.ObtieneBrokers
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_IntermediarioMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneReaseguradores(id_folio As Integer) As List(Of spS_ReaseguradorMC_Result) Implements IMesaControl.ObtieneReaseguradores
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_ReaseguradorMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneSubjetividad(id_folio As Integer) As List(Of spS_SubjetividadMC_Result) Implements IMesaControl.ObtieneSubjetividad
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_SubjetividadMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtienePagos(id_folio As Integer) As List(Of spS_PagosMC_Result) Implements IMesaControl.ObtienePagos
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_PagosMC(id_folio).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtienePolizasAseg(txt_aseg As String) As List(Of spS_PolizasAsegurado_Result) Implements IMesaControl.ObtienePolizasAseg
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_PolizasAsegurado(txt_aseg).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneRiesgoPoliza(cod_suc As Integer, cod_ramo As Integer, nro_pol As Integer, aaaa_endoso As Integer, nro_endoso As Integer, cod_item As Integer, strSel As String) As List(Of spS_RiesgoPoliza_Result) Implements IMesaControl.ObtieneRiesgoPoliza
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_RiesgoPoliza(cod_suc, cod_ramo, nro_pol, aaaa_endoso, nro_endoso, cod_item, strSel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneUbicacionesPoliza(cod_suc As Integer, cod_ramo As Integer, nro_pol As Integer, aaaa_endoso As Integer, nro_endoso As Integer) As List(Of spS_UbicacionesPoliza_Result) Implements IMesaControl.ObtieneUbicacionesPoliza
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_UbicacionesPoliza(cod_suc, cod_ramo, nro_pol, aaaa_endoso, nro_endoso).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
End Class
