' NOTE: You can use the "Rename" command on the context menu to change the class name "RecSiniestros" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select RecSiniestros.svc or RecSiniestros.svc.vb at the Solution Explorer and start debugging.
Imports WS_GMX

Public Class RecSiniestros
    Implements IRecSiniestros
    Public db As New RecordEntities


#Region "Fase de Recuperacion"
    Public Function ActualizaFaseRecup(id_Fase As Int32, strFase As String) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaFaseRecup
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spU_FaseRecupera(id_Fase, strFase).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
    Public Function InsertaFaseRecup(strFase As String) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.InsertaFaseRecup
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spI_FaseRecupera(strFase).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
    Public Function EliminaFaseRecup(id_Fase As Int32) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.EliminaFaseRecup
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spD_FaseRecupera(id_Fase).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

#End Region
#Region "Estatus Siniestros"
    Public Function InsertaEstatusStro(strEstatus As String, id_Fase As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.InsertaEstatusStro
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spi_Estatus_Stro(strEstatus, id_Fase).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ActualizaEstatusStro(id_Estatus As Int32, strFase As String, id_Fase As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaEstatusStro
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spu_estatus_stro(id_Estatus, strFase, id_Fase).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function EliminaEstatusStro(id_Estatus As Int32) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.EliminaEstatusStro
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spd_estatus_stro(id_Estatus).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
#End Region
#Region "Niveles"
    Public Function InsertaNivel(strNivel As String, DiasT As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.InsertaNivel
        Dim Resultado As IList = Nothing
        Try

            Resultado = db.spi_Nivel_Aviso(strNivel, DiasT).ToList

        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ActualizaNivel(id_Nivel As Int32, strNivel As String, DiasT As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaNivel
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spu_nivel_aviso(id_Nivel, strNivel, DiasT).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function EliminaNivel(id_Nivel As Int32) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.EliminaNivel
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spd_nivel_aviso(id_Nivel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
#End Region
#Region "Aviso Usuarios"
    Public Function InsertaAvUsuario(cod_usuario As String, cod_sector As Integer, id_nivel As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.InsertaAvUsuario
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spi_taviso_Usuario(cod_usuario, cod_sector, id_nivel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ActualizaAvUsuario(cod_usuario As String, cod_sector As Integer, idav As Integer, id_nivel As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaAvUsuario
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spu_taviso_Usuario(cod_usuario, cod_sector, idav, id_nivel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function EliminaAvUsuario(idav As Int32) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.EliminaAvUsuario
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spd_taviso_Usuario(idav).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
#End Region
#Region "Job"
    Public Function ActualizaJobParam(srtHora As String, blnActivo As Boolean) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaJobParam
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spU_ActivaJob(srtHora, blnActivo).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ActualizaHoraJob(strHoraIni As String, strFechaIni As String, Activado As Boolean) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.ActualizaHoraJob
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.ModJob(strHoraIni, strFechaIni, Activado).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
#End Region
#Region "ConsultaSiniestros"
    Public Function ObtieneSiniestros(tipo_mov As Integer, nro_stro As String, broker As String, aseg As String, reaseg As String,
                                      cod_ramo_conta As String, poliza As String, Optional fec_desde As String = vbNullString,
                                      Optional fec_hasta As String = vbNullString) As List(Of sp_rptMovSinxReas_Result) Implements IRecSiniestros.ObtieneSiniestros
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.sp_rptMovSinxReas(tipo_mov, nro_stro, broker, aseg, reaseg, cod_ramo_conta, poliza, fec_desde, fec_hasta).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
#End Region
#Region "Ajustes"
    Public Function GuardaAjustes(siniestro As Integer, consecutivo As Integer, reasegurador_ant As String, reasegurador As String, corredor_ant As String, corredor As String,
                                  reg_rea_ant As String, reg_rea As String, fec_ini_vig_ant As String, fec_ini_vig As String, fec_fin_vig_ant As String, fec_fin_vig As String,
                                  causa_stro_ant As String, causa_stro As String, dir_stro_ant As String, dir_stro As String, ajustador_ant As String, ajustador As String,
                                  fecha_ajuste As String, usuarioLog As String) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.GuardaAjustes
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spI_AjustesSin(siniestro, consecutivo, reasegurador_ant, reasegurador, corredor_ant, corredor, reg_rea_ant, reg_rea, fec_ini_vig_ant, fec_ini_vig, fec_fin_vig_ant, fec_fin_vig,
                                         causa_stro_ant, causa_stro, dir_stro_ant, dir_stro, ajustador_ant, ajustador, fecha_ajuste, usuarioLog).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function


#End Region

    Public Function InsertaPolNoAC(id_pv As Integer, cod_usuario As String, cod_submod_web As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.InsertaPolNoAC
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spI_PolNoAC(id_pv, cod_usuario, cod_submod_web).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function EliminaPolNoAC(id_pv As Integer, cod_submod_web As Integer) As List(Of Nullable(Of Int32)) Implements IRecSiniestros.EliminaPolNoAC
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spD_PolNoAC(id_pv, cod_submod_web).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtienePolNoAC(cod_submod_web As Integer) As List(Of spS_EndososNoAC_Result) Implements IRecSiniestros.ObtienePolNoAC
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_EndososNoAC(cod_submod_web).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

#Region "Aviso de Cobro"

    Public Function ObtieneRepartoFac(id_pv As Integer, nro_stro As String) As List(Of sp_RepartoReaFac_Result) Implements IRecSiniestros.ObtieneRepartoFac
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.sp_RepartoReaFac(id_pv, nro_stro).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

#End Region

End Class
