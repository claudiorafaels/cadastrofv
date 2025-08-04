''' -----------------------------------------------------------------------------
''' Project	 : VAK020
''' Class	 : DB_VAKCsnMsgCreEtn
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Consulta informações da mensagem de correio eletrônico.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DB_VAKCsnMsgCreEtn

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta corpo do texto da mensagem de correio eletrônico
    ''' </summary>
    ''' <param name="iNumSeqMsg">Número seq. mensagem correio eletrônico</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMsgCreEtn(ByVal iNumSeqMsg As Integer, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select MSG.DESTXTLNHFISCREETN from MRT.T0134290 MSG ")
            oStrBld.Append(" where MSG.TIPMSGCREETN = " & BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL)
            oStrBld.Append(" and MSG.NUMSEQMSGCREETN = " & iNumSeqMsg.ToString)
            oStrBld.Append(" order by MSG.NUMSEQLNHFISCREETN ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnMsgCreEtn)
            CsnMsgCreEtn.Tables(0).TableName = "tblCsnMsgCreEtn"
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta endereços (remetente, destinatários(com cópia, c/c oculta) da mensagem de correio eletrônico.
    ''' </summary>
    ''' <param name="iNumSeqMsg">Número seq. mensagem correio eletrônico</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMsgCreEtnEnd(ByVal iNumSeqMsg As Integer, _
                                    ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select MSGEND.TIPENDCREETN, MSGEND.IDTENDCREETN from MRT.T0134282 MSGEND ")
            oStrBld.Append(" where MSGEND.TIPMSGCREETN = " & BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL)
            oStrBld.Append(" and MSGEND.NUMSEQMSGCREETN = " & iNumSeqMsg)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnMsgCreEtnEnd)
            CsnMsgCreEtnEnd.Tables(0).TableName = "tblMsgCreEtnEnd"
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta assunto da mensagem de correio eletrônico.
    ''' </summary>
    ''' <param name="iNumSeqMsg">Número seq. mensagem correio eletrônico</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMsgCreEtnCab(ByVal iNumSeqMsg As Integer, _
                                   ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select MSGCAB.DESASSCREETN from MRT.T0134274 MSGCAB ")
            oStrBld.Append(" where MSGCAB.TIPMSGCREETN = " & BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL)
            oStrBld.Append(" and MSGCAB.NUMSEQMSGCREETN = " & iNumSeqMsg.ToString)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnMsgCreEtnCab)
            CsnMsgCreEtnCab.Tables(0).TableName = "tblCsnMsgCreEtnCab"
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

End Class
