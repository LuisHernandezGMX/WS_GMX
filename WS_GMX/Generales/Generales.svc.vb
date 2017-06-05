' NOTE: You can use the "Rename" command on the context menu to change the class name "Generales" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Generales.svc or Generales.svc.vb at the Solution Explorer and start debugging.
Imports System.Net.Mail
Public Class Generales
    Implements IGenerales

    Public db As New GMXEntities
    Public Function EnviaCorreo(strTo As String, strBody As String, strSubject As String, Optional strCc As String = vbNullString, Optional strBco As String = vbNullString) As Boolean Implements IGenerales.EnviaCorreo
        Dim cm = ConfigurationManager.AppSettings
        Dim Mensaje As New MailMessage
        Try
            Mensaje.To.Add(strTo)
            If strCc <> vbNullString Then
                Mensaje.CC.Add(strCc)
            End If
            If strBco <> vbNullString Then
                Mensaje.Bcc.Add(strBco)
            End If

            Mensaje.From = New MailAddress(cm("SMTPFromAddress"), cm("SMTPFrom"), Encoding.UTF8)
            Mensaje.Subject = strSubject
            Mensaje.Body = strBody
            Mensaje.IsBodyHtml = True
            Mensaje.BodyEncoding = System.Text.Encoding.UTF8
            Mensaje.Priority = MailPriority.Normal
            Dim cli As New SmtpClient
            cli.Port = cm("SMTPPort")
            cli.Host = cm("SMTPServer")
            cli.Credentials = New System.Net.NetworkCredential(cm("SMTPUsu"), cm("SMTPPass"))
            cli.EnableSsl = False

            cli.Send(Mensaje)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "error")
            Return False
        End Try

    End Function

    Public Function ObtieneCatalogo(strPrefijo As String, Optional strCondicion As String = "", Optional strSel As String = "") As List(Of spS_CatalogosOP_Result) Implements IGenerales.ObtieneCatalogo
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_CatalogosOP(strPrefijo, strCondicion, strSel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function


End Class
