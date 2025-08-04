Imports Microsoft.ApplicationBlocks.ExceptionManagement

Public Class BO_VAKCsnAnsCrd

#Region "Consulta os funcionarios para cadastro de Analista de credito"
    Public Function CsnFnc(ByVal sNomFnc As String) As String
        'objeto
        Dim oObeCsnFnc As DB_VAKAnsCrd
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            'executa db
            oObeCsnFnc = New DB_VAKAnsCrd

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")

            sVlrRet = oObeCsnFnc.CsnFnc(sNomFnc, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar funcionários. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oObeCsnFnc = Nothing
        End Try
    End Function
#End Region

#Region "------------ Consulta todos os análistas de créditos --------------"
    Function CsnTotAnsCrdFnc() As String
        'objeto
        Dim oObeCsnAnsCrd As DB_VAKAnsCrd
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")

            'executa db
            oObeCsnAnsCrd = New DB_VAKAnsCrd
            sVlrRet = oObeCsnAnsCrd.CsnTotAnsCrd(sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar todas as análises de créditos. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oObeCsnAnsCrd = Nothing
        End Try
    End Function
#End Region

End Class
