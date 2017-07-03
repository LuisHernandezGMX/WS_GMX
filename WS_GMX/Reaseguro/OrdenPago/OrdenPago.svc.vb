' NOTE: You can use the "Rename" command on the context menu to change the class name "OrdenPago" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select OrdenPago.svc or OrdenPago.svc.vb at the Solution Explorer and start debugging.

Public Class OrdenPago
    Implements IOrdenPago
    Public db As New OPEntities

#Region "Inserciones a Base de Datos"
    Public Function InsertaPolNoPago(id_pv As Double, cod_usuario As String) As String Implements IOrdenPago.InsertaPolNoPago
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spI_PolNoPago(id_pv, cod_usuario).ToList
            strResultado = Resultado(0).ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
        Return strResultado
    End Function
#End Region

#Region "Eliminación de Base de Datos"
    Public Function EliminaPolNoPago(id_pv As String) As String Implements IOrdenPago.EliminaPolNoPago
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spD_PolNoPago(id_pv).ToList
            strResultado = Resultado(0).ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
        Return strResultado
    End Function
#End Region

End Class
