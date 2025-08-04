Public Class DB_VAKUsrPsw

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Valida o acesso do usuario a base de dados.
    REM ''' </summary>
    REM ''' <param name="sCodRep">Codigo de acesso do usuario.</param>
    REM ''' <param name="sCodPswRepTmk">Senha de acesso do usuario.</param>
    REM ''' <param name="sVlrErr">Mensagem de erro retornada pela funcao.</param>
    REM ''' <returns>
    REM ''' String contendo valor "1" indicando que o usuario tem acesso permitido ao Banco de Dados.
    REM ''' </returns>
    REM ''' <remarks>
    REM '''     REM ''' Query utilizada: 
    REM ''' <code> SELECT 
    REM '''               NOMREP, TIPREP, T1.CODSUP, T1.DATDSTREP, T2.CODGER, T3.NOMGER, 
    REM '''               T2.NOMSUP, T1.DATRCBLPTREP, T1.DATDVLLPTREP, CURRENT DATE - 28 DAYS AS DATTOLRCB 
    REM '''          FROM  MRT.T0100116 T1 
    REM '''                INNER JOIN   MRT.T0100124 T2 ON T1.CODSUP = T2.CODSUP 
    REM '''                LEFT  JOIN   MRT.T0100051 T3 ON T2.CODGER = T3.CODGER 
    REM '''         WHERE 
    REM '''               T1.CODREP    = sCodRep 
    REM '''           AND CODPSWREPTMK = sCodPswRepTmk
    REM ''' </code>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/26/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------

    Public Function CsnUsrPsw(ByVal sCodRep As String, ByVal sCodPswRepTmk As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = "SELECT NOMREP, TIPREP, T1.CODSUP, T1.DATDSTREP, T2.CODGER, T3.NOMGER, T2.NOMSUP, " + _
            '          "       T1.DATRCBLPTREP, T1.DATDVLLPTREP, CURRENT DATE - 28 DAYS AS DATTOLRCB " + _
            '          " FROM  MRT.T0100116 T1 " + _
            '          "    INNER JOIN   MRT.T0100124 T2 ON T1.CODSUP = T2.CODSUP " + _
            '          "    LEFT  JOIN   MRT.T0100051 T3 ON T2.CODGER = T3.CODGER " + _
            '          " WHERE T1.CODREP    = " + sCodRep + _
            '          "   AND CODPSWREPTMK = " + sCodPswRepTmk + _
            '          "   AND T3.DATDSTGER IS NULL "

            'Conversão Oracle 16/02/06
            sCmdSql = "SELECT NOMREP, TIPREP, T1.CODSUP, TRUNC(T1.DATDSTREP) AS DATDSTREP, T2.CODGER, T3.NOMGER, T2.NOMSUP, " + _
                      "       TRUNC(T1.DATRCBLPTREP) AS DATRCBLPTREP, TRUNC(T1.DATDVLLPTREP) AS DATDVLLPTREP, (SYSDATE - 28) AS DATTOLRCB " + _
                      " FROM  MRT.T0100116 T1 " + _
                      "    INNER JOIN   MRT.T0100124 T2 ON T1.CODSUP = T2.CODSUP " + _
                      "    LEFT  JOIN   MRT.T0100051 T3 ON T2.CODGER = T3.CODGER " + _
                      " WHERE T1.CODREP    = " + sCodRep + _
                      "   AND CODPSWREPTMK = " + sCodPswRepTmk + _
                      "   AND T3.DATDSTGER IS NULL "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            oObeAcsDdo.ExcCmdSql(sVlrRet)

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then

                oObeAcsDdo = Nothing
            End If
        End Try
    End Function

End Class
