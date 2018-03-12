' NOTE: You can use the "Rename" command on the context menu to change the class name "Bordereaux" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Bordereaux.svc or Bordereaux.svc.vb at the Solution Explorer and start debugging.
Public Class Bordereaux
    Implements IBordereaux
    Public db As New UATEntities

    Public Function GetAjustesHist(fec_desde As String, fec_hasta As String) As List(Of spS_AjusteHistBdx_Result2) Implements IBordereaux.GetAjustesHist
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_AjusteHistBdx(fec_desde, fec_hasta).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function
End Class
