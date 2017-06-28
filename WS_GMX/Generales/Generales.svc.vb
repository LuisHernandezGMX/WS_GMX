' NOTE: You can use the "Rename" command on the context menu to change the class name "Generales" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Generales.svc or Generales.svc.vb at the Solution Explorer and start debugging.
Imports System.Net.Mail
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class Generales
    Implements IGenerales

    Public db As New GralEntities
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

    Public Function ObtieneCatalogo(strPrefijo As String, Optional strCondicion As String = "", Optional strSel As String = "") As List(Of spS_CatalogosOP_Result2) Implements IGenerales.ObtieneCatalogo
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_CatalogosOP(strPrefijo, strCondicion, strSel).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetRamo(ByVal Id As Integer) As String Implements IGenerales.GetRamo
        Dim ramo As String = ""
        Using conn As New SqlConnection()
            'Obtiene cadena de conexión de Web Config
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
            Using cmd As New SqlCommand()
                cmd.CommandText = "select cod_ramo, txt_desc from  tramo where sn_ramo_comercial = -1 AND cod_ramo = @SearchId"
                cmd.Parameters.AddWithValue("@SearchId", Id)
                cmd.Connection = conn
                conn.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        ramo = sdr("txt_desc")
                    End While
                End Using
                conn.Close()
            End Using
            Return ramo
        End Using
    End Function

End Class
