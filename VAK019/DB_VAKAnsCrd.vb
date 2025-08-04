Public Class DB_VAKAnsCrd

#Region "'- Consulta codigo de funcionario de acordo com nome"
    Public Function CsnFnc(ByVal sNomFnc As String, _
                            ByRef sVlrErr As String, _
                            ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " SELECT CODFNC, NOMUSRRCF " & _
            '          " FROM MRT.T0104596 " & _
            '          " WHERE NOMUSRRCF LIKE '%" & sNomFnc & "%'" & _
            '          " ORDER BY CODFNC"

            sCmdSql = " SELECT USR.NOMUSRRCF , FNC.CODFNC , FNC.NOMFNC, '' as DESENDCREETNFNC, 1 as INDCREETNPAD " & _
                      " FROM MRT.T0100361 FNC , MRT.T0104596 USR " & _
                      " WHERE NOMUSRRCF LIKE '%" & sNomFnc & "%'" & _
                      "       AND FNC.CODFNC  = USR.CODFNC"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnFnc)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " -------------- Consulta Funcionário pelo Código ------------------"
    Public Function CsnCodFnc(ByVal sCodFnc As String, _
                               ByRef sVlrErr As String, _
                               ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT CODFNC, NOMUSRRCF " & _
                      " FROM MRT.T0104596 " & _
                      " WHERE CODFNC = " & sCodFnc

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnCodFnc)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region


#Region " -------------- Consulta email alternativo------------------"
    Public Function CsnCrrEtnSgn(ByVal sNomUsrRde As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Try
            sCmdSql = " select"
            sCmdSql += " case when a.indcreetnpad = 1 then"
            sCmdSql += " trim(lower(b.nomusrrcf)) ||"
            sCmdSql += " lower('@martins.com.br')"
            sCmdSql += " else"
            sCmdSql += " trim(lower(a.desendcreetnfnc))"
            sCmdSql += " end as endereco "
            sCmdSql += " from mrt.t0150393 a"
            sCmdSql += " , mrt.t0104596 b"
            sCmdSql += " where(a.codfnc = b.codfnc)"
            sCmdSql += " and trim(upper(b.nomusrrcf)) = '" & sNomUsrRde.ToUpper.Trim & "'"
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnCrrEtnSgn)
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function

#End Region

#Region "------------ Consulta todos os analista de créditos --------------------"
    Public Function CsnTotAnsCrd(ByRef sVlrErr As String, _
                                  ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " SELECT CODANSCAD, ANSCRD.CODFNC, NOMUSRRCF " & _
            '          "   FROM MRT.T0150393 ANSCRD, MRT.T0104596 FNC " & _
            '          "  WHERE ANSCRD.CODFNC = FNC.CODFNC " & _
            '          " ORDER BY NOMUSRRCF "

            sCmdSql = " SELECT ANSCRD.CODANSCAD, FNC.CODFNC , USR.NOMUSRRCF, FNC.NOMFNC, ANSCRD.DESENDCREETNFNC , ANSCRD.INDCREETNPAD " & _
                      " FROM MRT.T0150393 ANSCRD,  MRT.T0100361 FNC , MRT.T0104596 USR " & _
                      " WHERE ANSCRD.CODFNC = USR.CODFNC " & _
                      "       AND ANSCRD.CODFNC = FNC.CODFNC "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnTotAnsCrd)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function CsnEmailAnalistaCredito(ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT distinct " & _
            " CASE WHEN A.INDCREETNPAD = 1 THEN " & _
            "  TRIM(LOWER(B.NOMUSRRCF)) || " & _
            "  LOWER('@MARTINS.COM.BR') " & _
            " ELSE " & _
            "  TRIM(LOWER(A.DESENDCREETNFNC)) " & _
            " END AS ENDERECO " & _
            " FROM MRT.T0150393 A " & _
            " , MRT.T0104596 B " & _
            " WHERE A.CODFNC = B.CODFNC "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(CsnEmailAnalistaCredito)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "------------ Insere analista de crédito--------------------"
    Public Function IsrDdoAnsCrd(ByVal sCodFnc As String, _
                                 ByVal sDesEndCreEtn As String, _
                                 ByVal iIndCreEtnPad As Integer, _
                                 ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String
            Dim iCnt As Integer

            '  sCmdSql = " INSERT INTO MRT.T0150393 (CODANSCAD, CODFNC) " & _
            '" VALUES ((select char(coalesce(max(integer(CODANSCAD)) + 1,0)) from MRT.T0150393), " & sCodFnc & ") "

            'Conversão Oracle 16/02/06
            sCmdSql = " INSERT INTO MRT.T0150393 (CODANSCAD, CODFNC, DESENDCREETNFNC, INDCREETNPAD) " & _
                      " VALUES ((SELECT TO_CHAR(COALESCE(MAX(TO_NUMBER(CODANSCAD)) + 1,0)) FROM MRT.T0150393), " & _
                      sCodFnc & ","
            If sDesEndCreEtn.Trim <> "" Then
                sCmdSql = sCmdSql & "'" & sDesEndCreEtn.Trim.ToUpper & "'"
            Else
                sCmdSql = sCmdSql & " null "
            End If
            sCmdSql = sCmdSql & "," & iIndCreEtnPad & ") "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iCnt)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "------------ Exclui os analista de crédito--------------------"
    Public Function EcsDdoAnsCrd(ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String
            Dim iCnt As Integer

            sCmdSql = " DELETE FROM MRT.T0150393 "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iCnt)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

End Class