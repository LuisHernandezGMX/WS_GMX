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
End Class
