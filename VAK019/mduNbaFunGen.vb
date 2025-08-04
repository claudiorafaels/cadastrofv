REM ''' -----------------------------------------------------------------------------
REM ''' <summary>
REM ''' Modulo com funcoes genericas para envio de e-mail.
REM ''' </summary>
REM ''' <remarks>
REM ''' </remarks>
REM ''' <history>
REM ''' 	[Carlos Eduardo R. Dutra]	11/08/2004	Created
REM ''' </history>
REM ''' -----------------------------------------------------------------------------

Imports System.Web.Mail
Module mduFunGenEnvCre

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Definicao para formato de mensagens de e-mail.
    REM ''' </summary>
    REM ''' <remarks>
    REM ''' Formatos permitidos: TXT ou HTML
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Carlos Eduardo R. Dutra]	11/08/2004	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Enum EnuFrmCre
        Htm = 1
        Txt = 0
    End Enum


    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Funcao geradora de senha aleatória.
    REM ''' </summary>
    REM ''' <param name="intTam">Numero de caracteres para criacao da senha.</param>
    REM ''' <returns>Senha gerada.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Carlos Eduardo R. Dutra]	11/08/2004	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function PswAle(ByVal intTam As Integer) As String
        Static rand As New Random
        Dim strPsw As New System.Text.StringBuilder(intTam)
        Dim cnr As Integer

        For cnr = 1 To intTam
            Dim charIndex As Integer
            ' Coloca obrigatoriamente numeros na 3a e 4a posição
            If cnr = 3 Or cnr = 4 Then
                charIndex = rand.Next(48, 57)
                strPsw.Append(Chr(charIndex))
            Else
                ' Permite apenas letras e números 
                Do
                    charIndex = rand.Next(48, 123)
                Loop Until (charIndex >= 48 AndAlso charIndex <= 57) OrElse (charIndex _
                >= 65 AndAlso charIndex <= 90) OrElse (charIndex >= 97 AndAlso _
                charIndex <= 122)
                ' acrescenta caracter à senha 
                strPsw.Append(Chr(charIndex))
            End If

        Next
        Return strPsw.ToString()
    End Function


    ' Parametros : ByVal pstrEndOri As String     Endereco de origem
    '              ByVal pstrEndDsn As String     Endereco de destino
    '              ByVal pstrFrmCre As EnuFrmCre  Formato da mensagem [htm, txt]
    '              ByVal pstrAssMsg As String     Assinatura da mensagem (subject)
    '              ByVal pstrMsg As String        Corpo da mensagem
    ' Retorno : Short
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Metodo para envio de mensagens de e-mail.
    REM ''' </summary>
    REM ''' <param name="pstrEndOri">Endereco de origem.</param>
    REM ''' <param name="pstrEndDsn">Endereco de destino.</param>
    REM ''' <param name="pstrFrmCre">Formato do texto da mensagem (txt / html).</param>
    REM ''' <param name="pstrAssMsg">Assunto da mensagem.</param>
    REM ''' <param name="pstrMsg">Mensagem a ser enviada.</param>
    REM ''' <param name="pstrSmtpSrv">Endereco do servidor de envio (SMTP).</param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' pstrFrmCre = 0 --> txt
    REM ''' pstrFrmCre = 1 --> html
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Carlos Eduardo R. Dutra]	11/08/2004	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function EnvCre(ByVal pstrEndOri As String, _
                           ByVal pstrEndDsn As String, _
                           ByVal pstrFrmCre As EnuFrmCre, _
                           ByVal pstrAssMsg As String, _
                           ByVal pstrMsg As String, _
                           ByVal pstrSmtpSrv As String) As Short

        ' Enviando senha para o usuario que a solicitou
        Try
            Dim objCre As New System.Web.Mail.MailMessage
            objCre.From = pstrEndOri
            objCre.To = pstrEndDsn
            objCre.BodyFormat = pstrFrmCre
            objCre.Subject = pstrAssMsg
            objCre.Body = pstrMsg
            System.Web.Mail.SmtpMail.SmtpServer.Insert(0, pstrSmtpSrv)
            System.Web.Mail.SmtpMail.Send(objCre)
            EnvCre = 1
        Catch
#If Not Debug Then
    Throw
#End If
        End Try

    End Function

End Module

