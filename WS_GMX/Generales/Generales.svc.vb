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

    Public Function ObtienePolizas(cod_suc As Integer, cod_ramo As Integer, nro_pol As Double, str_pol As String, bln_garantias As Boolean,
                                   FechaIni As String, FechaFin As String, sn_Ajuste As Integer) As List(Of spS_ListaPoliza_Result) Implements IGenerales.ObtienePolizas
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_ListaPoliza(cod_suc, cod_ramo, nro_pol, str_pol, bln_garantias, FechaIni, FechaFin, sn_Ajuste).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneParametro(cPAR_Id As Integer) As String Implements IGenerales.ObtieneParametro
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spS_cPAR_Parametros(cPAR_Id).ToList
            strResultado = Resultado(0).ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
        Return strResultado
    End Function
End Class
