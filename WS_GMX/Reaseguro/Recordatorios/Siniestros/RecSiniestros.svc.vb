' NOTE: You can use the "Rename" command on the context menu to change the class name "RecSiniestros" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select RecSiniestros.svc or RecSiniestros.svc.vb at the Solution Explorer and start debugging.
Imports WS_GMX

Public Class RecSiniestros
    Implements IRecSiniestros
    Public db As New GMXEntities

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

End Class
