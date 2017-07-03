﻿' NOTE: You can use the "Rename" command on the context menu to change the class name "Generales" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Generales.svc or Generales.svc.vb at the Solution Explorer and start debugging.
Imports System.Net.Mail
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class Generales
    Implements IGenerales

    Public db As New GralEntities

#Region "Inserciones a Base de Datos"
    Public Function InsertaLogError(cod_usuario As String, Descripcion As String, hostname As String) As String Implements IGenerales.InsertaLogError
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spI_LogErrores(cod_usuario, Descripcion, hostname).ToList
            strResultado = Resultado(0).ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
        Return strResultado
    End Function

    Public Function InsertaATabla(strTabla As String, strKey As String, strDatos As String) As String Implements IGenerales.InsertaATabla
        Dim Resultado As IList = Nothing
        Dim strResultado As String = ""
        Try
            Resultado = db.spI_OfGread(strTabla, strKey, strDatos).ToList
            strResultado = Resultado(0).ToString()
        Catch ex As Exception
            Return String.Empty
        End Try
        Return strResultado
    End Function
#End Region


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

    Public Function ObtieneEndosos(str_pol As String, FecEmision As String) As List(Of spS_ListaEndoso_Result) Implements IGenerales.ObtieneEndosos
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_ListaEndoso(str_pol, FecEmision).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Function ObtienePagador(id_pv As Double) As List(Of spS_Pagador_Result) Implements IGenerales.ObtienePagador
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_Pagador(id_pv).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtienePagadorCuotas(id_pv As Double, ind_pag As Integer, cod_aseg As Double) As List(Of spS_PagadorCuotas_Result) Implements IGenerales.ObtienePagadorCuotas
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_PagadorCuotas(id_pv, ind_pag, cod_aseg).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Function ObtieneDetallePagoCuota(id_pv As Double, cod_aseg As Double, ind_pag As Integer, nro_cuota As Integer) As List(Of spS_DetallePagosCob_Result) Implements IGenerales.ObtieneDetallePagoCuota
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_DetallePagosCob(id_pv, cod_aseg, ind_pag, nro_cuota).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneEndososNoPago(cod_usuario As String) As List(Of spS_EndososNoPagoOP_Result) Implements IGenerales.ObtieneEndososNoPago
        Dim Resultado As IList = Nothing
        Try
            Resultado = db.spS_EndososNoPagoOP(cod_usuario).ToList
        Catch ex As Exception
            Return Nothing
        End Try
        Return Resultado
    End Function

    Public Function ObtieneAclaraciones(id_pv As Integer) As String Implements IGenerales.ObtieneAclaraciones
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
