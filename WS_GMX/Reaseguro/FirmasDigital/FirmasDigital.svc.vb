' NOTE: You can use the "Rename" command on the context menu to change the class name "FirmasDigital" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select FirmasDigital.svc or FirmasDigital.svc.vb at the Solution Explorer and start debugging.
Imports WS_GMX

Public Class FirmasDigital
    Implements IFirmasDigital

    Public db As New GMXEntities
    Public Function ActualizaFirma(NumOp As String, TipoPer As Integer, CodUsu As String) As Integer Implements IFirmasDigital.ActualizaFirma
        Dim Resultado As Integer
        Try
            Resultado = db.spU_ActualizaFirmas(NumOp, TipoPer, CodUsu)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneUsuarioFirmaE(TipoUsuario As Integer) As List(Of spS_UsuarioFirma_Result) Implements IFirmasDigital.ObtieneUsuarioFirmaE
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_UsuarioFirma(TipoUsuario).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ActualizaDestinatarioFirma(CodUsu As String, CodRol As Integer) As List(Of Nullable(Of Int32)) Implements IFirmasDigital.ActualizaDestinatarioFirma
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spU_RolPredeterminado(CodUsu, CodRol).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtienePermisosXUsu(CodUsu As String) As List(Of spS_PermisosxUSuFirma_Result) Implements IFirmasDigital.ObtienePermisosXUsu
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_PermisosxUSuFirma(CodUsu).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

End Class
