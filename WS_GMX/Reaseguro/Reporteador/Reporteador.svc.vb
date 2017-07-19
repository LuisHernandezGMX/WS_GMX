' NOTE: You can use the "Rename" command on the context menu to change the class name "Reporteador" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Reporteador.svc or Reporteador.svc.vb at the Solution Explorer and start debugging.
Public Class Reporteador
    Implements IReporteador

    Public db As New ReportEntities
    Public Function InsertaVersionReporte(cod_modulo As Integer, cod_submodulo_web As Integer, cod_reporte As Integer,
                                          cod_usuario As String, descripcion As String, filtros As String, formato As String,
                                          Optional sn_Temporal As Integer = 0) As List(Of Nullable(Of Int32)) Implements IReporteador.InsertaVersionReporte
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spI_VersionReporte(cod_modulo, cod_submodulo_web, cod_reporte, cod_usuario,
                                              descripcion, filtros, formato, sn_Temporal)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneVersionReporte(cod_reporte As Integer, Optional cod_config As Integer = -1, Optional cod_usuario As String = "") As List(Of spS_VersionReporte_Result) Implements IReporteador.ObtieneVersionReporte
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_VersionReporte(cod_reporte, cod_config, cod_usuario).ToList

        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
End Class
