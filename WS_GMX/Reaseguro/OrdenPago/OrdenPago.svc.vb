' NOTE: You can use the "Rename" command on the context menu to change the class name "OrdenPago" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select OrdenPago.svc or OrdenPago.svc.vb at the Solution Explorer and start debugging.

Public Class OrdenPago
    Implements IOrdenPago

    Public db As New OPEntities
    Public Function ObtieneAclaraciones(id_pv As Integer) As String Implements IOrdenPago.ObtieneAclaraciones
        Dim Resultado As IList = Nothing
        Dim StrResultado As String = ""
        Dim Funcs As New FuncionesConversion
        Try
            Resultado = db.spS_Aclaracion(id_pv).ToList
            For Each Item In Resultado
                StrResultado = Funcs.RempCarEsp(Funcs.ConvertRtf2Html(Replace(Item.Descripcion.ToString(), vbCrLf, "")))
                StrResultado = Replace(Replace(StrResultado, vbCrLf, ""), vbTab, "")
            Next
        Catch ex As Exception
            Return String.Empty
        End Try
        Return StrResultado
    End Function

End Class
