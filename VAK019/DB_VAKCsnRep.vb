Public Class DB_VAKCsnRep

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta últimos meses
    ''' </summary>
    ''' <param name="oCnx">Conexão com o banco de dados</param>
    ''' <returns>string xml contendo os dados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	28/3/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnUltMes(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT	DISTINCT YEAR(CURRENT DATE - 2 MONTHS), MONTH(CURRENT DATE - 2 MONTHS),  " & _
            '          " YEAR(CURRENT DATE - 1 MONTHS), MONTH(CURRENT DATE - 1 MONTHS),  " & _
            '          " YEAR(CURRENT DATE), MONTH(CURRENT DATE ) " & _
            '          " FROM MRT.T0150334  "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT DISTINCT TO_CHAR(ADD_MONTHS(SYSDATE,-2),'YYYY'), TO_CHAR(ADD_MONTHS(SYSDATE,-2),'MM'), " & _
                      " TO_CHAR(ADD_MONTHS(SYSDATE,-1),'YYYY'), TO_CHAR(ADD_MONTHS(SYSDATE,-1),'MM'), " & _
                      " TO_CHAR(SYSDATE,'YYYY'), TO_CHAR(SYSDATE,'MM') " & _
                      " FROM MRT.T0150334  "


            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oAcsDdo.ExcCmdSql(CsnUltMes)
            CsnUltMes.Tables(0).TableName = "tblMesAno"
        Catch oEcc As Exception
            Throw
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta valor de venda do território
    ''' </summary>
    ''' <param name="sCodSup">Código do supervisor</param>
    ''' <param name="sAnoMesRef">Ano mês de referência</param>
    ''' <param name="sAnoMesRefAnt">Ano mês de referência anterior</param>
    ''' <param name="sAnoMesRefAntAnt">Ano mês de referência anterior anterior</param>
    ''' <param name="oCnx">Conexão com o banco de dados</param>
    ''' <returns>string xml contendo os dados</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	28/3/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnVlrVndTet(ByVal sCodSup As String, _
                          ByVal sAnoMesRef As String, _
                          ByVal sAnoMesRefAnt As String, _
                          ByVal sAnoMesRefAntAnt As String, _
                          ByVal iCodTetVnd As Integer, _
                          ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT B.CODTETVND, B.DESTETVND, A.CODREP, A.NOMREP, " & _
            '            "      (SELECT VALUE(SUM(VLRCMPCLI), 0) " & _
            '            "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
            '            "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAntAnt & ") As VLRCMP1, " & _
            '            "      (SELECT VALUE(SUM(VLRCMPCLI), 0) " & _
            '            "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
            '            "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAnt & ") As VLRCMP2, " & _
            '            "      (SELECT VALUE(SUM(VLRCMPCLI), 0) " & _
            '            "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
            '            "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRef & ") As VLRCMP3  " & _
            '            "   FROM MRT.T0100116 A, MRT.T0133715 B " & _
            '            "  WHERE A.CODREP = B.CODREP " & _
            '            "    AND A.CODSUP = " & sCodSup & _
            '            "    AND B.DATDSTTETVND IS NULL " & _
            '            "    AND B.CODTETVND = " & iCodTetVnd.ToString & _
            '            "  ORDER BY B.CODTETVND "

            'Conversão Oracle 02/03/06
            sCmdSql = " SELECT B.CODTETVND, B.DESTETVND, A.CODREP, A.NOMREP, " & _
                        "      (SELECT COALESCE(SUM(VLRCMPCLI), 0) " & _
                        "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
                        "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAntAnt & ") As VLRCMP1, " & _
                        "      (SELECT COALESCE(SUM(VLRCMPCLI), 0) " & _
                        "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
                        "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAnt & ") As VLRCMP2, " & _
                        "      (SELECT COALESCE(SUM(VLRCMPCLI), 0) " & _
                        "         FROM MRT.T0133774 C, MRT.T0100175 D " & _
                        "        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRef & ") As VLRCMP3  " & _
                        "   FROM MRT.T0100116 A, MRT.T0133715 B " & _
                        "  WHERE A.CODREP = B.CODREP " & _
                        "    AND A.CODSUP = " & sCodSup & _
                        "    AND B.DATDSTTETVND IS NULL " & _
                        "    AND B.CODTETVND = " & iCodTetVnd.ToString & _
                        "  ORDER BY B.CODTETVND "

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oAcsDdo.ExcCmdSql(CsnVlrVndTet)
            CsnVlrVndTet.Tables(0).TableName = "tblDdo"
        Catch oEcc As Exception
            Throw
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

#Region " ----------------- Alteração da Empresa do Representante -------------"
    Function CsnDdoHstEmpRep(ByVal sCodRep As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        'comando sql
        Dim sCmdSql As String
        Try
            sCmdSql = " SELECT A.CODSUP, D.NOMREP, A.CODSITREP, A.TIPSITPESJURCSHREG, D.TIPSITPESJURCSHREG AS TIPSITPESREP, A.NUMCGCEMPREP, A.NOMEMPREP, " & _
                      "        A.NUMINSINUNACSEGSOC, C.CODESTUNI, B.CODCID, A.CODBAIEMPREP, A.CODCPLBAIEMPREP, A.CODCEPEMPREP, " & _
                      "        A.ENDEMPREP, TRUNC(A.DATASNCTTREP) AS DATASNCTTREP, TRUNC(A.DATCADFILEMP) AS DATCADFILEMP, " & _
                      "        A.NUMRGTREPCSHREG, A.CODESTUNICSHREG, A.TIPSITREPCSHREG, TRUNC(A.DATRGTREPCSHREG) AS DATRGTREPCSHREG, " & _
                      "        A.CODBCOREP, A.CODAGEBCOREP, A.NUMDIGVRFAGEBCOREP, A.CODCNTCRRBCOREP, A.TIPNATREP, D.TIPFRMPGT, " & _
                      "        (SELECT COUNT(*) FROM MRT.T0104405 WHERE CODEDEORDPGT = A.CODREP AND  TIPORDPGT = 'C' AND " & _
                      "                TIPEDEORDPGT = 3 AND TIPFRMPGT IN ('B','R') AND CODSITORDPGT = ' ') AS CODSITORDPGT " & _
                      "   FROM MRT.T0123949 A " & _
                      "        LEFT JOIN MRT.T0100027 B ON (B.CODBAI = A.CODBAIEMPREP) " & _
                      "        LEFT JOIN MRT.T0100035 C ON (C.CODCID = B.CODCID) " & _
                      "        INNER JOIN MRT.T0100116 D ON (D.CODREP = A.CODREP) " & _
                      "  WHERE A.CODREP = " & sCodRep & _
                      "    AND A.DATHRAALT IS NULL"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnDdoHstEmpRep)
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then
                oObeAcsDdo = Nothing
            End If
        End Try
    End Function

    Function CsnDdoEmpRep(ByVal sCodRep As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        'comando sql
        Dim sCmdSql As String
        Try
            sCmdSql = " SELECT A.CODSUP, A.NOMREP, A.CODSITREP, A.TIPSITPESJURCSHREG, A.NUMCGCEMPREP, A.NOMEMPREP, " & _
                      "        A.NUMINSINUNACSEGSOC, C.CODESTUNI, B.CODCID, A.CODBAIEMPREP, A.CODCPLBAIEMPREP, A.CODCEPEMPREP, " & _
                      "        A.ENDEMPREP, TRUNC(A.DATASNCTTREP) AS DATASNCTTREP, TRUNC(D.DATCADFILEMP) AS DATCADFILEMP, " & _
                      "        A.NUMRGTREPCSHREG, A.CODESTUNICSHREG, A.TIPSITREPCSHREG, TRUNC(A.DATRGTREPCSHREG) AS DATRGTREPCSHREG, " & _
                      "        A.CODBCOREP, A.CODAGEBCOREP, A.NUMDIGVRFAGEBCOREP, A.CODCNTCRRBCOREP, A.TIPNATREP, A.TIPFRMPGT, " & _
                      "        (SELECT COUNT(*) FROM MRT.T0104405 WHERE CODEDEORDPGT = A.CODREP AND  TIPORDPGT = 'C' AND " & _
                      "                TIPEDEORDPGT = 3 AND TIPFRMPGT IN ('B','R') AND CODSITORDPGT = ' ') AS CODSITORDPGT " & _
                      "   FROM MRT.T0100116 A " & _
                      "        LEFT JOIN MRT.T0118678 D ON (D.CODREP = A.CODREP) " & _
                      "        LEFT JOIN MRT.T0100027 B ON (B.CODBAI = A.CODBAIEMPREP) " & _
                      "        LEFT JOIN MRT.T0100035 C ON (C.CODCID = B.CODCID) " & _
                      "  WHERE A.CODREP = " & sCodRep

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnDdoEmpRep)
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then
                oObeAcsDdo = Nothing
            End If
        End Try
    End Function
#End Region

End Class