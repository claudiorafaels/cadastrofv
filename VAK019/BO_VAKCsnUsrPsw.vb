Imports Microsoft.ApplicationBlocks.ExceptionManagement

Public Class BO_VAKCsnUsrPsw


    Public Sub New()
        SetThreadIdentity()
    End Sub

    Private Sub SetThreadIdentity()
        Dim user As System.Security.Principal.WindowsIdentity
        user = System.Security.Principal.WindowsIdentity.GetCurrent
        Dim winPrincipal As System.Security.Principal.WindowsPrincipal
        winPrincipal = New System.Security.Principal.WindowsPrincipal(user)
        System.Threading.Thread.CurrentThread.CurrentPrincipal = winPrincipal
    End Sub

    Public Function CsnUsrPsw(ByVal sCodRep As String, ByVal sCodPswRepTmk As String) As String
        'objeto
        Dim oObeCsnItfUsrPsw As New DB_VAKUsrPsw
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfUsrPsw.CsnUsrPsw(sCodRep, sCodPswRepTmk, sVlrErr, oCnx)

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao verificar usuário e senha. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            If Not oObeCsnItfUsrPsw Is Nothing Then
                oObeCsnItfUsrPsw = Nothing
            End If
        End Try
    End Function

End Class
