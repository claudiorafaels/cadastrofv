Imports Microsoft.ApplicationBlocks.ExceptionManagement

''' -----------------------------------------------------------------------------
''' Project	 : VAK020
''' Class	 : BO_VAKCsnMsgCreEtn
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Consulta mensagens de correio eletrônico gravadas na base
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class BO_VAKCsnMsgCreEtn

    Public Const _ID_SISTEMA_EMAIL = 51

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta mensagem de correio eletrônico (assunto, mensagem, remetente, destinatários) por 
    ''' número de seqüência da mensagem.
    ''' </summary>
    ''' <param name="iNumSeqMsg">Número seq. mensagem correio eletrônico</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMsgCreEtn(ByVal iNumSeqMsg As Integer) As DataSet

        Dim DB_VAK020 As New DB_VAKCsnMsgCreEtn
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As New DataSet
        Try
            'Consulta assunto
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo.Merge(DB_VAK020.CsnMsgCreEtnCab(iNumSeqMsg, oCnx))

            'Consulta endereços
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo.Merge(DB_VAK020.CsnMsgCreEtnEnd(iNumSeqMsg, oCnx))

            'Consulta mensagem
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo.Merge(DB_VAK020.CsnMsgCreEtn(iNumSeqMsg, oCnx))

            Return oGrpDdo

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

End Class
