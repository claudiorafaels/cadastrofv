Imports System.Threading
Imports System.Globalization
Imports VB6 = Microsoft.VisualBasic

#Region " --------------- Classe ------------------"
Public Class DB_VAKRep

#Region "Metodos de Manipulacao de dados relacionados a MRT.T0155948"
    Public Function IsrApvPod(ByVal pDatHra As String, ByVal pCodFncApv As String, ByVal pCodFncApvSbt As String, ByVal pCodFncRpn As String, ByVal pDatIniDlg As String, ByVal pDatFimDlg As String, ByVal pDesObsDlg As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            str.Append(" INSERT INTO MRT.T0155948 (DATHRA, CODFNCAPV, CODFNCAPVSBT, CODFNCRPN, DATINIDLG, DATFIMDLG, DESOBSDLG) ")
            str.Append(" VALUES ( ")

            'If (Not pDatHra Is Nothing) And (pDatHra <> "") Then
            '    str.Append(FunFrmCpo(pDatHra))
            'Else
            '    str.Append("CURRENT TIMESTAMP")
            'End If

            'Conversão Oracle 16/02/06
            If (Not pDatHra Is Nothing) And (pDatHra <> "") Then
                str.Append("TO_TIMESTAMP('" & pDatHra & "','YYYY-MM-DD HH24:MI:SS')")
            Else
                str.Append("SYSTIMESTAMP")
            End If

            str.Append(", " & pCodFncApv)
            str.Append(", " & pCodFncApvSbt)
            str.Append(", " & pCodFncRpn)

            'str.Append(", " & FunFrmCpo(pDatIniDlg))
            'str.Append(", " & FunFrmCpo(pDatFimDlg))

            'Conversão Oracle 16/02/06
            If pDatIniDlg <> "NULL" Then
                pDatIniDlg = "TO_DATE('" & pDatIniDlg & "','YYYY-MM-DD')"
            End If
            If pDatFimDlg <> "NULL" Then
                pDatFimDlg = "TO_DATE('" & pDatFimDlg & "','YYYY-MM-DD')"
            End If
            str.Append(", " & pDatIniDlg)
            str.Append(", " & pDatFimDlg)

            str.Append(", " & FunFrmCpo(pDesObsDlg))

            str.Append(")")
            sCmdSql = str.ToString()
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return iCnt.ToString
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    'public function CsnApvPod(ByVal sCodFnc As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String 
    '    'objeto de acessa dados
    '    Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
    '    
    '    Dim sCmdSql As String
    '    Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

    '    Try
    '        

    '        str.Append(" SELECT CODFNCAPV, CODFNCAPVSBT, CODFNCRPN, DATFIMDLG, DATHRA, DATINIDLG, DESOBSDLG ")
    '        str.Append(" FROM MRT.T0155948 ")
    '        str.Append("       F.NOMUSRRCF AS UserName, ")
    '        str.Append("       F.NOMUSRENDOFF AS User, ")
    '        str.Append("       (CASE WHEN NOT (G.CODGER IS NULL) THEN 'X' ELSE '' END) As FlgGerVnd, ")
    '        str.Append("       (CASE WHEN NOT (A.CodFnc IS NULL) THEN 'X' ELSE '' END) As FlgAnsCrd ")
    '        str.Append("  FROM MRT.T0104596 F ")
    '        str.Append("       LEFT JOIN MRT.T0150393 A ON F.CodFnc = A.CodFnc ")
    '        str.Append("       LEFT JOIN MRT.T0100051 G ON F.CodFnc = G.CodFncGer ")
    '        str.Append(" WHERE F.CODFNC = " & sCodFnc)
    '        str.Append(" ORDER BY FlgGerVnd DESC, FlgAnsCrd DESC ")

    '        sCmdSql = str.ToString()

    '        'executa consulta
    '        Dim sVlrRet As String
    '        oItfAcsDdo.ExcCmdSqlLngMcoExn(sCmdSql, "mrt001", "VAK019;DB_VAKRep;ItfVAKRep;CnsApv")

    '        'retorno com sucesso
    '        Return sVlrRet
    '    Catch oObeEcc As Exception
    '        'levanta excecao que sera tratada no BO
    '        Throw
    '    Finally
    '        str = Nothing
    '        oObeAcsDdo = Nothing
    '    End Try
    'End Function

#End Region


#Region " Metodos de Manipulacao de dados relacionados a MRT.T0155931"

    ' Consulta aprovadores em potencial.
    Public Function CsnTotApv(ByVal sNomUsr As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            str.Append("SELECT F.CODFNC AS Codigo, ")
            str.Append("       F.NOMUSRRCF AS UserName, ")
            str.Append("       F.NOMUSRENDOFF AS User, ")
            str.Append("       (CASE WHEN NOT (G.CODGER IS NULL) THEN 'X' ELSE '' END) As FlgGerVnd, ")
            str.Append("       (CASE WHEN NOT (A.CodFnc IS NULL) THEN 'X' ELSE '' END) As FlgAnsCrd ")
            str.Append("  FROM MRT.T0104596 F ")
            str.Append("       LEFT JOIN MRT.T0150393 A ON F.CodFnc = A.CodFnc ")
            str.Append("       LEFT JOIN MRT.T0100051 G ON F.CodFnc = G.CodFncGer ")
            If sNomUsr Is Nothing Then
                str.Append(" WHERE G.DATDSTGER IS NULL ")
                str.Append(" ORDER BY FlgGerVnd DESC, FlgAnsCrd DESC ")
            Else
                str.Append("  WHERE F.NOMUSRRCF = '" & sNomUsr & "'")
                str.Append("    AND G.DATDSTGER IS NULL ")
            End If
            sCmdSql = str.ToString()

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
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    ' Consulta aprovadores em potencial.
    Public Function CsnApv(ByVal sCodFnc As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            str.Append("SELECT F.CODFNC AS Codigo, ")
            str.Append("       F.NOMUSRRCF AS UserName, ")
            str.Append("       F.NOMUSRENDOFF AS Usuario, ")
            str.Append("       (CASE WHEN NOT (G.CODGER IS NULL) THEN 'X' ELSE '' END) As FlgGerVnd, ")
            str.Append("       (CASE WHEN NOT (A.CodFnc IS NULL) THEN 'X' ELSE '' END) As FlgAnsCrd ")
            str.Append("  FROM MRT.T0104596 F ")
            str.Append("       LEFT JOIN MRT.T0150393 A ON F.CodFnc = A.CodFnc ")
            str.Append("       LEFT JOIN MRT.T0100051 G ON F.CodFnc = G.CodFncGer ")
            str.Append(" WHERE F.CODFNC = " & sCodFnc)
            str.Append("   AND G.DATDSTGER IS NULL ")
            str.Append(" ORDER BY FlgGerVnd DESC, FlgAnsCrd DESC ")

            sCmdSql = str.ToString()

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
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function


    Public Function CsnCodFnc(ByVal sNomUsrRde As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String

        Try
            sCmdSql = " SELECT CODFNC FROM MRT.T0104596 WHERE NOMUSRRCF = '" & sNomUsrRde & "' "

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            oObeAcsDdo.ExcCmdSql(CsnCodFnc)

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function CsnApvPod(ByVal sCodFnc As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try

            str = New System.Text.StringBuilder

            'str.Append(" SELECT Fnc.NOMUSRRCF, ApvPod.CODFNCAPV ")
            'str.Append("    FROM MRT.T0155948 ApvPod, MRT.T0104596 Fnc ")
            'str.Append(" WHERE ApvPod.CODFNCAPVSBT = " & sCodFnc)
            'str.Append("       AND CURRENT DATE BETWEEN ApvPod.DATINIDLG AND ApvPod.DATFIMDLG ")
            'str.Append("       AND ApvPod.CODFNCAPVSBT = Fnc.CodFnc ")
            'str.Append("  ORDER BY DATHRA DESC ")

            'Conversão Oracle 16/02/06
            str.Append(" SELECT Fnc.NOMUSRRCF, ApvPod.CODFNCAPV ")
            str.Append("    FROM MRT.T0155948 ApvPod, MRT.T0104596 Fnc ")
            str.Append(" WHERE ApvPod.CODFNCAPVSBT = " & sCodFnc)
            str.Append("       AND TRUNC(SYSDATE) BETWEEN ApvPod.DATINIDLG AND ApvPod.DATFIMDLG  ")
            str.Append("       AND ApvPod.CODFNCAPVSBT = Fnc.CodFnc ")
            str.Append("  ORDER BY DATHRA DESC ")

            sCmdSql = str.ToString()

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
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    ' Obtem o endereco de destino para retorno de parecer
    Public Function CsnCreDsnRetOpn(ByVal sNumReq As String, ByVal sNomUsrOrg As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try

            ' Obtem o ID do usuario para retorno do parecer.
            str = New System.text.StringBuilder

            'str.Append(" SELECT NOMUSR AS NOMUSRDSN, CODSTACADREP, coalesce(integer(codseqobs) + 1,1) As CODSEQOBS ")
            'str.Append(" FROM MRT.T0156332 ")
            'str.Append(" WHERE CODSEQOBS IN (SELECT coalesce(integer(codseqobs) - 1,1) ")
            'str.Append("  FROM MRT.T0156332 ")
            'str.Append(" WHERE NUMREQCADREP = " & sNumReq)
            'str.Append("   AND DATHRA IS NULL ")

            'Conversão Oracle 16/02/06
            str.Append(" SELECT NOMUSR AS NOMUSRDSN, CODSTACADREP, COALESCE(TO_NUMBER(CODSEQOBS) + 1,1) AS CODSEQOBS ")
            str.Append(" FROM MRT.T0156332 ")
            str.Append(" WHERE CODSEQOBS IN (SELECT COALESCE(TO_NUMBER(CODSEQOBS) - 1,1) ")
            str.Append("  FROM MRT.T0156332 ")
            str.Append(" WHERE NUMREQCADREP = " & sNumReq)
            str.Append("   AND DATHRA IS NULL ")

            If (sNomUsrOrg <> Nothing) Or (sNomUsrOrg <> "") Then
                str.Append("   AND UPPER(NOMUSR) = UPPER('" & sNomUsrOrg & "') ")
            End If
            str.Append(" ) ")
            str.Append(" AND NUMREQCADREP = " & sNumReq)
            sCmdSql = str.ToString()

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
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta de Aprovadores de Requisicoes.
    REM ''' </summary>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns>XML contendo resultado da consulta.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	1/18/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnApvReq(ByVal pNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

        Try
            'str.Append(" SELECT Fnc.NOMUSRRCF, ApvReq.NUMREQCADREP, ApvReq.DATHRA, ApvReq.CODFNCRPN, ApvReq.CODFNCAPV, ApvReq.CODFNCAPVSBT, ApvReq.DESOBSDLG ")
            'str.Append(" FROM MRT.T0155931 ApvReq, MRT.T0104596 Fnc ")

            'Conversão Oracle 16/02/06
            str.Append(" SELECT Fnc.NOMUSRRCF, ApvReq.NUMREQCADREP, TO_CHAR(ApvReq.DATHRA, 'YYYY-MM-DD HH24:MI:SS.FF') AS DATHRA, ApvReq.CODFNCRPN, ApvReq.CODFNCAPV, ApvReq.CODFNCAPVSBT, ApvReq.DESOBSDLG ")
            str.Append(" FROM MRT.T0155931 ApvReq, MRT.T0104596 Fnc ")

            If (Not pNumReqCadRep Is Nothing) Then
                str.Append(" WHERE ApvReq.NUMREQCADREP = " & pNumReqCadRep)
                str.Append("   AND ApvReq.CodFncApvSbt = Fnc.CodFnc ")
            End If
            str.Append(" ORDER BY NUMREQCADREP, DATHRA DESC ")
            sCmdSql = str.ToString()

            'sCmdSql = " SELECT DISTINCT CODESTUNI AS CODESTUNI  " & _
            '          " FROM MRT.T0100035 " & _
            '          " ORDER BY CODESTUNI "

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
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function AltApvReq(ByVal pNumReqCadRep As String, _
                               ByVal pDatHra As String, _
                               ByVal pCodFncRpn As String, _
                               ByVal pCodFncApv As String, _
                               ByVal pCodFncApvSbt As String, _
                               ByVal pDesObsDlg As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

        Try
            'str.Append(" UPDATE MRT.T0155931 ")
            'str.Append(" SET DATHRA = " & FunFrmCpo(pDatHra) + ",")
            'str.Append("     CODFNCRPN = " & pCodFncRpn + ",")
            'str.Append("     CODFNCAPV = " & pCodFncApv + ",")
            'str.Append("     CODFNCAPVSBT = " & pCodFncApvSbt + ",")
            'str.Append("     DESOBSDLG = " & FunFrmCpo(pDesObsDlg))
            'str.Append(" WHERE NUMREQCADREP = " + pNumReqCadRep)

            'Conversão Oracle 16/02/06
            If pDatHra <> "NULL" Then
                pDatHra = "TO_TIMESTAMP('" & pDatHra & "','YYYY-MM-DD HH24:MI:SS')"
            End If

            str.Append(" UPDATE MRT.T0155931 ")
            str.Append(" SET DATHRA = " & pDatHra + ",")
            str.Append("     CODFNCRPN = " & pCodFncRpn + ",")
            str.Append("     CODFNCAPV = " & pCodFncApv + ",")
            str.Append("     CODFNCAPVSBT = " & pCodFncApvSbt + ",")
            str.Append("     DESOBSDLG = " & FunFrmCpo(pDesObsDlg))
            str.Append(" WHERE NUMREQCADREP = " + pNumReqCadRep)

            sCmdSql = str.ToString()

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function AltCodStaCadRep(ByVal pNumReqCadRep As String, _
                                     ByVal psCodStaCadRep As String, _
                                     ByVal psCodStaCadRepNvo As String, _
                                     ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder

        Try
            str = New System.Text.StringBuilder
            str.Append(" update mrt.t0150350 ")
            str.Append(" set codstacadrep = " & psCodStaCadRepNvo)
            str.Append(" where numreqcadrep = " & pNumReqCadRep)
            str.Append(" and codstacadrep = " & psCodStaCadRep)

            sCmdSql = str.ToString()

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function IsrApvReq(ByVal pNumReqCadRep As String, _
                               ByVal pDatHra As String, _
                               ByVal pCodFncRpn As String, _
                               ByVal pCodFncApv As String, _
                               ByVal pCodFncApvSbt As String, _
                               ByVal pDesObsDlg As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

        Try
            str.Append(" INSERT INTO MRT.T0155931 (NUMREQCADREP,DATHRA,CODFNCRPN,CODFNCAPV,CODFNCAPVSBT,DESOBSDLG) ")
            str.Append(" VALUES ( " + pNumReqCadRep)

            'If (Not pDatHra Is Nothing) And (pDatHra <> "") Then
            '    str.Append(", " & FunFrmCpo(pDatHra))
            'Else
            '    str.Append(", CURRENT TIMESTAMP")
            'End If

            'Conversão Oracle 16/02/06
            If (Not pDatHra Is Nothing) And (pDatHra <> "") Then
                str.Append("TO_TIMESTAMP('" & pDatHra & "','YYYY-MM-DD HH24:MI:SS')")
            Else
                str.Append(", SYSTIMESTAMP")
            End If

            str.Append(", " & pCodFncRpn)
            str.Append(", " & pCodFncApv)
            str.Append(", " & pCodFncApvSbt)
            str.Append(", " & FunFrmCpo(pDesObsDlg))
            str.Append(")")
            sCmdSql = str.ToString()

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function EcsApvReq(ByVal pNumReqCadRep As String, _
                       ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            str.Append(" DELETE FROM MRT.T0155931 ")
            str.Append(" WHERE NUMREQCADREP = " + pNumReqCadRep)
            sCmdSql = str.ToString()
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            str = Nothing
            oObeAcsDdo = Nothing
        End Try
    End Function

#End Region

    '- Consulta todos estados
    Public Function CsnEst(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT DISTINCT CODESTUNI AS CODESTUNI  " & _
                      " FROM MRT.T0100035 " & _
                      " ORDER BY CODESTUNI "

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta Cidades de um estado
    Public Function CsnCid(ByVal sCodEst As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT CODCID, NOMCID " & _
                      " FROM MRT.T0100035 " & _
                      " WHERE CODESTUNI = '" & sCodEst & "' " & sCplCmdSql
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
            oObeAcsDdo = Nothing
        End Try
    End Function

#Region " --> Consulta Bairros de uma cidade"
    '- Consulta bairros de uma cidade
    Public Function CsnBai(ByVal sCodCid As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODBAI,NOMBAI " & _
                      " FROM MRT.T0100027 " & _
                      " WHERE CODCID = " & sCodCid & sCplCmdSql
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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " --> Consulta a tabela de representantes cadastrados"
    ' /**
    '  * Funcao     : CsnNumInsInuNacSegSoc
    '  * Descricao  : Consulta a tabela de representantes cadastrados buscando por ocorrencias
    '  *              de INSS cadastrados para CPF diferentes do fornecido.
    '  * Parametros : sNumInsInuNacSegSoc  Numero do INSS a ser verificado
    '  *              sNumCpfRep           Numero do CPF associado ao INSS a ser verificado
    '  * 
    '  * Retorno :  = 0 --> INSS nao cadastrado para todo CPF diferente do atual
    '              <> 0 --> INSS ja cadastrado para outro CPF
    '  */
    Public Function CsnNumInsInuNacSegSoc(ByVal sNumInsInuNacSegSoc As String, _
                                               ByVal sNumCpfRep As String, _
                                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String
            Dim str As System.Text.StringBuilder
            str = New System.Text.StringBuilder
            str.Append("SELECT COUNT(*) AS ISREP ")
            str.Append("  FROM MRT.T0100116 ")
            str.Append(" WHERE NUMCPFREP <> '" & sNumCpfRep & "'")
            str.Append("   AND NUMINSINUNACSEGSOC = " & sNumInsInuNacSegSoc)
            sCmdSql = str.ToString

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "--> Busca CPF associado a um INSS"
    ' /**
    '  * Funcao     : CsnCpf
    '  * Descricao  : Consulta a tabela de representantes cadastrados buscando o CPF vinculado a um INSS.
    '  * Parametros : sNumInsInuNacSegSoc  Numero do INSS a ser verificado
    '  * 
    '  * Retorno :  o CPF vinculado ao INSS fornecido.
    '  *            string vazia
    '  */
    Public Function CsnCpf(ByVal sNumInsInuNacSegSoc As String, _
                                ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            Dim str As System.Text.StringBuilder
            str = New System.Text.StringBuilder
            str.Append("SELECT DISTINCT NUMCPFREP ")
            str.Append("  FROM MRT.T0100116 ")
            str.Append(" WHERE NUMINSINUNACSEGSOC = " & sNumInsInuNacSegSoc)
            sCmdSql = str.ToString

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
            oObeAcsDdo = Nothing
        End Try

        'Try
        '    
        '    'comando sql 
        '    Dim sCmdSql As String

        '    sCmdSql = " SELECT CODCPLBAI, NOMCPLBAI " & _
        '              " FROM MRT.T0103905 " & _
        '              " WHERE CODBAI = " & sCodBai & sCplCmdSql

        '    'executa consulta
        '    Dim sVlrRet As String
        '    oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)

        '    'retorno com sucesso
        '    Return sVlrRet
        'Catch oObeEcc As Exception
        '    'levanta excecao que sera tratada no BO
        '    Throw
        'Finally
        '    oObeAcsDdo = Nothing
        'End Try
    End Function
#End Region


    '- Consulta complementos de um bairro
    Public Function CsnCplBai(ByVal sCodBai As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODCPLBAI, NOMCPLBAI " & _
                      " FROM MRT.T0103905 " & _
                      " WHERE CODBAI = " & sCodBai & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta bancos
    Public Function CsnBco(ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODBCO, NOMBCO " & _
                      " FROM MRT.T0100345 " & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta agências de um banco
    Public Function CsnAgeBco(ByVal sCodBco As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODAGEBCO, NOMAGEBCO, NUMDIGVRFAGEBCO " & _
                      " FROM MRT.T0104413 " & _
                      " WHERE CODBCO = " & sCodBco & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta todos segmentos de mercado
    Public Function CsnSgmMcd(ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODSGMMCD, DESSGMMCD " & _
                      " FROM MRT.T0105983 WHERE DESSGMMCD <> 'DESATIVADO' " & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta GM e GV do representante
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta o nome do Gerente de Mercado e seu Gerente de Vendas relacionado.
    REM ''' </summary>
    REM ''' <param name="sCodSup">Codigo do Gerente de Mercado a ser pesquisado</param>
    REM ''' <param name="sVlrErr">Variavel de mensagem de erro.</param>
    REM ''' <param name="sCplCmdSql">Complemento da busca.</param>
    REM ''' <returns>XML contendo os dados do Gerente de Mercado e seu Gerente de Vendas relacionado.</returns>
    REM ''' <remarks>
    REM ''' 
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	12/28/2004	Documentacao do metodo.
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnGerVnd(ByVal sCodSup As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT NOMSUP, GERVND.CODGER, NOMGER " & _
                      " FROM MRT.T0100124 GERMCD, MRT.T0100051 GERVND " & _
                      " WHERE GERMCD.CODSUP =  " & sCodSup & _
                      "       AND GERVND.CODGER = GERMCD.CODGER " & _
                      "       AND GERVND.DATDSTGER IS NULL " & _
                      "       AND GERMCD.DATDSTSUP IS NULL " & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    Public Function CsnGerVnd(ByVal sCodFnc As String, _
                              ByRef sVlrErr As String, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                              Optional ByVal bInsDst As Boolean = False) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CodFncGer, NomGer " + _
                      "   FROM MRT.T0100051 GV " + _
                      "  WHERE GV.CODFNCGER = " & sCodFnc
            If Not bInsDst Then
                sCmdSql += "    AND GV.DATDSTGER IS NULL "
            End If

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
            oObeAcsDdo = Nothing
        End Try
    End Function


#Region "--> Verifica se um funcionario eh aprovador"
    Public Function CsnFncApv(ByVal sCodFnc As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String
            Dim str As System.Text.StringBuilder
            str = New System.Text.StringBuilder
            Dim oGrpDdo As DataSet

            ' Verifica se eh Analista de Credito (retorno > 0)
            Dim isAC As Integer
            isAC = 0
            str.Append("Select 1 FROM MRT.T0150393 AC WHERE AC.FNC = " & sCodFnc)
            sCmdSql = str.ToString()
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(oGrpDdo)
            isAC = oGrpDdo.Tables(0).Rows.Count

            ' Verifica se eh Gerente de Vendas (retorno > 0)
            Dim isGv As Integer
            isGv = 0
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                str.Append(" SELECT 1 FROM MRT.T0100051 GV WHERE GV.CODFNCGER = " & sCodFnc)
                str.Append("    AND GV.DATDSTGER IS NULL ")
                sCmdSql = str.ToString()
                'executa consulta
                oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
                oObeAcsDdo.ExcCmdSql(oGrpDdo)
                isGv = oGrpDdo.Tables(0).Rows.Count
            End If

            Dim sVlrRet As String = (isAC > 0) Or (isGv > 0)

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "--> Verifica se um funcionario foi delegado a aprovador de requisicoes"
    Public Function CsnFncDlg(ByVal sCodFnc As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String
            Dim str As System.Text.StringBuilder
            str = New System.Text.StringBuilder

            ' Verifica se esta na tabela de aprovadores (retorno > 0)
            Dim isDlg As Integer
            isDlg = 0
            'str.Append("Select 1 FROM MRT.T0150393 AC WHERE AC.FNC = " & sCodFnc)
            'sCmdSql = str.ToString()
            'isDlg = oItfAcsDdo.ExcCmdSqlAtlBseDdo(sCmdSql, "mrt001", sVlrErr)

            Dim sVlrRet As String = (isDlg > 0)

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region


    '- Indica se o representante já trabalhou no martins
    Public Function CsnIdtRepTrb(ByVal sNumCpf As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " SELECT  DATDSTREP, DATCADREP, CODREP " & _
            '          " FROM MRT.T0100116 " & _
            '          " WHERE NUMCPFREP = '" & sNumCpf & "'"

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT TRUNC(DATDSTREP) AS DATDSTREP, TRUNC(DATCADREP) AS DATCADREP, CODREP " & _
                      " FROM MRT.T0100116 " & _
                      " WHERE NUMCPFREP = '" & sNumCpf & "'"

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Indica se o representante já trabalhou no martins(Tabela Funcionário)
    Public Function CsnIdtRepFnc(ByVal sNumCpf As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim dsCadRca As New DataSet

        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " select FNC.CODFNC, trunc(FNC.Datadsfnc) as Datadsfnc, trunc(FNC.Datdemfnc) as Datdemfnc " & _
                      " FROM MRT.t0100361 FNC " & _
                      " WHERE FNC.NUMCPFFNC = '" & sNumCpf & "'"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql.ToString)
            oObeAcsDdo.ExcCmdSql(dsCadRca)
            dsCadRca.Tables(0).TableName = "tblFncMrt"
            Return dsCadRca
        Finally
            oObeAcsDdo.Dispose()
        End Try
    End Function

    '- Indica se o representante existe na tabela temporária em aprovação
    Public Function CsnIdtRepTrbTmp(ByVal sNumCpf As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String
            'sCmdSql = " SELECT  NOMREP, DATSLC, CODSTACADREP " & _
            '          " FROM MRT.T0150415 " & _
            '          " WHERE NUMCPFREP = '" & sNumCpf & "' " & _
            '          " AND CODSTACADREP NOT IN (5, 7, 12, 13) "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT  NOMREP, TRUNC(DATSLC) AS DATSLC, CODSTACADREP " & _
                      " FROM MRT.T0150415 " & _
                      " WHERE NUMCPFREP = '" & sNumCpf & "' " & _
                      " AND CODSTACADREP NOT IN (5, 7, 9, 12, 13) "

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta territórios
    Public Function CsnTetRep(ByVal sCodTetVnd As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODREP " & _
                      " FROM MRT.T0133715  " & _
                      " WHERE CODTETVND = " & sCodTetVnd

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta resultado das provas
    Public Function CsnRstPva(ByVal sNumCpf As String, ByRef sVlrErr As String, ByVal sCplCmdSql As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try
            'comando sql 
            Dim sCmdSql As String

            '  sCmdSql = "SELECT (CASE WHEN CODAVL = 1 THEN 'MATEMATICA' ELSE 'PORTUGUES' END) As CODAVL, PERPVTAVL " + _
            '" FROM MRT.T0151306 " + _
            '" WHERE NUMCPF = '" + sNumCpf + "'" + _
            '" AND CODAVL IN (1,2)" + _
            '" ORDER BY DATINI DESC " + _
            '" FETCH FIRST 2 ROWS ONLY "

            'Conversão Oracle 02/03/06
            sCmdSql = "SELECT (CASE WHEN CODAVL = 1 THEN 'MATEMATICA' ELSE 'PORTUGUES' END) As CODAVL, PERPVTAVL " + _
          " FROM MRT.T0151306 " + _
          " WHERE ROWNUM < 3 " + _
          " AND NUMCPF = '" + sNumCpf + "'" + _
          " AND CODAVL IN (1,2)" + _
          " ORDER BY DATINI DESC    "

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
            oObeAcsDdo = Nothing
        End Try
    End Function
    '- Consulta todos os status
    Public Function CsnTotSta(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODSTACADREP, DESSTACADREP " & _
                      " FROM MRT.T0150334 "

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
            oObeAcsDdo = Nothing
        End Try
    End Function
    '- Consulta todos GVs
    Public Function CsnTotGerVnd(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODGER, NOMGER " & _
                      " FROM MRT.T0100051  " & _
                      " WHERE DATDSTGER IS NULL " & _
                      " ORDER BY CODGER "

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta GM de um GV
    Public Function CsnGerMcdGerVnd(ByVal sCodGerVnd As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT CODSUP, NOMSUP " & _
                      " FROM MRT.T0100124 " & _
                      " WHERE CODGER = " & sCodGerVnd & _
                      "       AND DATDSTSUP IS NULL " & _
                      " ORDER BY CODSUP "

            'executa consulta
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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Busca Acerto Pendente'
    Function CsnAcePnd(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " SELECT DATENVDOCACEREP, DATRCBDOCACEREP " & _
            '          " FROM MRT.T0132271 " & _
            '          " WHERE CODREP = " & sCodRep

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT TRUNC(DATENVDOCACEREP) AS DATENVDOCACEREP, TRUNC(DATRCBDOCACEREP) AS DATRCBDOCACEREP " & _
                      " FROM MRT.T0132271 " & _
                      " WHERE CODREP = " & sCodRep

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta ações trabalhistas'
    Function CsnAcoTrb(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try

            'comando sql 
            Dim sCmdSql As String
            sCmdSql = " SELECT DESMTVPNDREP " & _
                      " FROM MRT.T0132271 " & _
                      " WHERE CODREP = " & sCodRep
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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta ultimos 3 meses'
    Function CsnUltMes(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " SELECT	DISTINCT YEAR(CURRENT DATE - 2 MONTHS), MONTH(CURRENT DATE - 2 MONTHS),  " & _
            '          " YEAR(CURRENT DATE - 1 MONTHS), MONTH(CURRENT DATE - 1 MONTHS),  " & _
            '          " YEAR(CURRENT DATE), MONTH(CURRENT DATE ) " & _
            '          " FROM MRT.T0150334  "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT DISTINCT TO_CHAR(ADD_MONTHS(SYSDATE,-2),'YYYY'), TO_CHAR(ADD_MONTHS(SYSDATE,-2),'MM'), " & _
                      " TO_CHAR(ADD_MONTHS(SYSDATE,-1),'YYYY'), TO_CHAR(ADD_MONTHS(SYSDATE,-1),'MM'), " & _
                      " TO_CHAR(SYSDATE,'YYYY'), TO_CHAR(SYSDATE,'MM') " & _
                      " FROM MRT.T0150334  "

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
            oObeAcsDdo = Nothing
        End Try
    End Function

    '- Consulta valor venda do território'
    Function CsnVlrVndTet(ByVal sCodSup As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try
            '
            ''comando sql 
            'Dim sCmdSql As String
            'Dim str As System.Text.StringBuilder
            'str = New System.Text.StringBuilder
            'str.Append("SELECT B.CODTETVND, B.DESTETVND, A.CODREP, A.NOMREP")
            'str.Append("      (SELECT VALUE(SUM(VLRCMPCLI), 0) ")
            'str.Append("         FROM MRT.T0133774 C, MRT.T0100175 D ")
            'str.Append("        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAntAnt & ") As VLRCMP1, ")
            'str.Append("      (SELECT VALUE(SUM(VLRCMPCLI), 0) ")
            'str.Append("         FROM MRT.T0133774 C, MRT.T0100175 D ")
            'str.Append("         WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRefAnt & ") As VLRCMP2, ")
            'str.Append("      (SELECT VALUE(SUM(VLRCMPCLI), 0) ")
            'str.Append("         FROM MRT.T0133774 C, MRT.T0100175 D ")
            'str.Append("        WHERE B.CODTETVND = C.CODTETVND AND C.CODCLI = D.CODCLI AND ANOMESREF = " & sAnoMesRef & ") As VLRCMP3  ")
            'str.Append("   FROM MRT.T0100116 A, MRT.T0133715 B ")
            'str.Append("  WHERE A.CODREP = B.CODREP ")
            'str.Append("    AND A.CODSUP = " & sCodSup)
            'str.Append("    AND B.DATDSTTETVND IS NULL ")
            'str.Append("  ORDER BY B.CODTETVND ")
            'sCmdSql = str.ToString

            'sCmdSql = " WITH TABELA AS " & _
            '          "     (SELECT REP.NOMREP, VLRCMPCLI, ANOMESREF, TET.CODREP, CLITET.CODTETVND, TET.DESTETVND,REP.CODSUP " & _
            '          "        FROM MRT.T0100175 CLI, MRT.T0133774 CLITET, " & _
            '          "        MRT.T0133715 TET LEFT OUTER JOIN MRT.T0100116 REP ON TET.CODREP = REP.CODREP " & _
            '          " WHERE(CLI.CODCLI = CLITET.CODCLI) " & _
            '          "   AND CLITET.CODTETVND = TET.CODTETVND) " & _
            '          " SELECT CODTETVND, DESTETVND,CODREP, NOMREP, SUM(VLRCMP1) As VLRCMP1, SUM(VLRCMP2) As VLRCMP2, SUM(VLRCMP3) As VLRCMP3 " & _
            '          "   FROM ((SELECT CODTETVND, DESTETVND, CODREP, NOMREP, SUM(VLRCMPCLI) As VLRCMP1, 0 AS VLRCMP2, 0 AS VLRCMP3 " & _
            '          "          FROM TABELA  " & _
            '          "          WHERE ANOMESREF= " & sAnoMesRefAntAnt & _
            '          "          AND CODSUP= " & sCodSup & _
            '          "          GROUP BY CODTETVND,DESTETVND, CODREP, NOMREP) " & _
            '          "         UNION ALL " & _
            '          "         (SELECT CODTETVND, DESTETVND, CODREP, NOMREP, 0 AS VLRCMP1, SUM(VLRCMPCLI) As VLRCMP2, 0 AS VLRCMP3 " & _
            '          "          FROM TABELA " & _
            '          "          WHERE ANOMESREF= " & sAnoMesRefAnt & _
            '          "            AND CODSUP= " & sCodSup & _
            '          "          GROUP BY CODTETVND,DESTETVND, CODREP, NOMREP)  " & _
            '          "         UNION ALL " & _
            '          "         (SELECT CODTETVND,DESTETVND,CODREP, NOMREP, 0 AS VLRCMP1, 0 AS VLRCMP2, SUM(VLRCMPCLI) As VLRCMP3  " & _
            '          "          FROM TABELA " & _
            '          "          WHERE ANOMESREF= " & sAnoMesRef & _
            '          "          AND CODSUP= " & sCodSup & _
            '          "          GROUP BY CODTETVND,DESTETVND, CODREP, NOMREP)) As TMP " & _
            '          "  GROUP BY CODTETVND,DESTETVND, CODREP, NOMREP  "

            ''executa consulta
            'Dim sVlrRet As String
            'oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)

            ''retorno com sucesso
            'Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
    '- Consulta Dados Representante
    Public Function CsnDdoRep(ByVal sCplSql As String, ByVal sCplCmdSql As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try
            '"        TMPREP.CODSTACADREP, DESSTACADREP, NOMRPNPRXACO " & _  char(DATSLC,iso) As
            'sCmdSql = " SELECT DISTINCT TMPREP.NUMREQCADREP, NUMCPFREP, NOMREP, " & _
            '          "                 TMPREP.CODSTACADREP, DESSTACADREP, DATSLC " & _
            '          " FROM   MRT.T0150415 TMPREP, MRT.T0150334 STA " & sCplSql & _
            '          " WHERE  TMPREP.CODSTACADREP = STA.CODSTACADREP " & sCplCmdSql

            'Conversão Oracle 16/02/06
            'Alterado por André correção de uma falha na query com a inserção de alias
            sCmdSql = " SELECT DISTINCT TMPREP.NUMREQCADREP, TMPREP.NUMCPFREP, TMPREP.NOMREP, " & _
                      "                 TMPREP.CODSTACADREP, STA.DESSTACADREP, TRUNC(DATSLC) AS DATSLC " & _
                      " FROM   MRT.T0150415 TMPREP, MRT.T0150334 STA " & sCplSql & _
                      " WHERE  TMPREP.CODSTACADREP = STA.CODSTACADREP " & sCplCmdSql

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

    '- Consulta se já existe uma solicitação em andamento para o candidato em fluxo de aprovação.
    Public Function CsnSlcFluApv(ByVal sNumCpf As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Try
            sCmdSql = " SELECT NUMREQCADREP, NUMCPFREP " & _
            " FROM MRT.T0150415 " & _
            " WHERE CODSTACADREP NOT IN (9,13,14,15) " & _
            " AND NUMCPFREP = '" & sNumCpf & "'"

            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            oObeAcsDdo.ExcCmdSql(sVlrRet)
            Return sVlrRet
        Catch ex As Exception
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then
                oObeAcsDdo = Nothing
            End If
        End Try
    End Function

    '- Consulta Territorios de um GM
    Public Function CsnTetGerMcd(ByVal sCodGerMcd As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT TET.CODTETVND, TET.DESTETVND " & _
                      " FROM   MRT.T0133715 TET, MRT.T0100116 REP " & _
                      " WHERE  TET.CODREP = REP.CODREP " & _
                      "        AND REP.CODSUP = " & sCodGerMcd & _
                      " ORDER BY TET.CODTETVND"

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

#Region " ----------------- Consulta dados do gerente de mercado -------------"
    Function CsnDdoGerMcd(ByVal sCodSup As String, ByRef sVlrErr As String, _
                          ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT * FROM MRT.t0100124 WHERE CODSUP = " & sCodSup

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " ----------------- Consulta descrição de observação -------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta informacoes do Fluxo.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep"></param>
    REM ''' <param name="sCodSeqObs"></param>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/25/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnDdoDesObs(ByVal sNumReqCadRep As String, ByVal sCodSeqObs As String, ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
            str.Append(" select NUMREQCADREP, CODSEQOBS, DESOBS ")
            str.Append("  from mrt.t0150610 ")
            str.Append(" where NUMREQCADREP = " & sNumReqCadRep)
            If (Not sCodSeqObs Is Nothing) And (sCodSeqObs <> "") Then
                str.Append("   and CODSEQOBS = " & sCodSeqObs)
            End If

            sCmdSql = str.ToString

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
            oObeAcsDdo = Nothing
        End Try
    End Function



    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta os registros referentes a aprovacao de uma dada requisicao por Gerentes de Vendas.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep">Numero da requisicao a ser consultada.</param>
    REM ''' <param name="sVlrErr">Variave de retorno de erro.</param>
    REM ''' <returns>XML contendo os registros de retorno.</returns>
    REM ''' <remarks>
    REM ''' Busca por todos os registros da tabela MRT.T0150610 que contenham a descricao  'DOCUMENTO APROVADO PELO GERENTE DE VENDAS'
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/24/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnObsGerVndDesObs(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
            str.Append(" select NUMREQCADREP, CODSEQOBS, DESOBS ")
            str.Append("  from mrt.t0150610 ")
            str.Append(" where NUMREQCADREP = " & sNumReqCadRep)
            str.Append(" and UPPER(desobs) like  '%REPROVADO%' ")

            sCmdSql = str.ToString

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " ----------------- Consulta nome do usuário de rede -------------"
    Public Function CsnNomUsrRcf(ByVal sCodGer As String, ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            'sCmdSql = " select fnc.NOMUSRRCF " & _
            '         "  from mrt.t0100051 ger, mrt.t0104596 fnc " & _
            '         " where ger.CODGER = " & sCodGer & _
            '        " and ger.CODFNCGER = fnc.CODFNC " & _
            '       " AND ger.DATDSTGER IS NULL  "

            sCmdSql = "select fnc.NOMUSRRCF from mrt.t0100051 ger, mrt.t0104596 fnc " & _
            "where ger.CODFNCGER = fnc.CODFNC AND ger.DATDSTGER IS NULL " & _
            " and (ger.CODGER = " & sCodGer & _
            "      or fnc.codfnc in " & _
            "     (select min(codfncapvsbt) from mrt.t0155948 a, mrt.t0104596 b " & _
            "where trunc(sysdate) between datinidlg and datfimdlg and codfncapv in (select codfncger " & _
                                " from mrt.t0100051 where codger = " & sCodGer & " )))"

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " ----------------- Consulta dados das Competências -------------"
    Public Function CsnCtn(ByRef sVlrErr As String, ByVal sCplCmdSql As String, _
                           ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODCTNREP, DESTITCTNREP " & _
                      " FROM MRT.T0150636 " & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " ----------------- Consulta Avaliações do representante -------------"
    Public Function CsnDdoAvlRep(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT CTNREP.CODAVLREP,CTN.DESTITAVLREP, CTNREP.DESCDOAVLREP " & _
                      " FROM MRT.T0150466 CTNREP, MRT.T0150482 CTN " & _
                      "  WHERE CTNREP.CODAVLREP = CTN.CODAVLREP " & _
                      "  AND CTNREP.NUMREQCADREP = " & sNumReqCadRep

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
#End Region

#Region " ----------------- Consulta dados das Avaliações -------------"
    Public Function CsnDdoAvl(ByRef sVlrErr As String, ByVal sCplCmdSql As String, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try

            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODAVLREP, DESTITAVLREP " & _
                      " FROM MRT.T0150482 " & sCplCmdSql

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
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " ----------------- Consulta dados dos Títulos -------------"
    Public Function CsnDdoTit(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT * " & _
                      "   FROM MRT.T0150563 " & _
                      "  WHERE NUMREQCADREP = " & sNumReqCadRep

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
#End Region

#Region " ----------------- Consulta dados Ação Civil -------------"
    Public Function CsnDdoAcoCvl(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try
            str = New System.Text.StringBuilder
            'str.Append("SELECT NUMREQCADREP,CODSEQACOCVL,TIPACOCVL,DATOCOACOCVL,NOMCIDOCOACOCVLREP, ")
            'str.Append("       CODESTUNIOCOACOCVL,NUMETBACOCVL,NOMCRIACOCVL,NOMPESRCBACOCVL ")
            'str.Append("  FROM MRT.T0150547 ")
            'str.Append("  WHERE NUMREQCADREP = " & sNumReqCadRep)

            'Conversão Oracle 16/02/06
            str.Append("SELECT NUMREQCADREP,CODSEQACOCVL,TIPACOCVL,TRUNC(DATOCOACOCVL) AS DATOCOACOCVL,NOMCIDOCOACOCVLREP, ")
            str.Append("       CODESTUNIOCOACOCVL,NUMETBACOCVL,NOMCRIACOCVL,NOMPESRCBACOCVL ")
            str.Append("  FROM MRT.T0150547 ")
            str.Append("  WHERE NUMREQCADREP = " & sNumReqCadRep)

            sCmdSql = str.ToString
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            oObeAcsDdo.ExcCmdSql(sVlrRet)
            Return sVlrRet
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then
                oObeAcsDdo = Nothing
            End If
        End Try
    End Function
#End Region

#Region " ----------------- Consulta dados dos Protestos -------------"
    Public Function CsnDdoRcm(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try

            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
            str.Append("SELECT ")
            'str.Append("NUMREQCADREP, ")

            'str.Append("CODSEQRCM, DATOCORCM, VLROCORCM, NOMCIDETBOCORCM, ")
            'str.Append("CODESTUNIOCORCM,NUMETBOCORCM,NOMETBOCORCM FROM MRT.T0150520 ")
            'str.Append("WHERE NUMREQCADREP = " & sNumReqCadRep)

            'Conversão Oracle 15/02/06
            str.Append("CODSEQRCM, TRUNC(DATOCORCM) AS DATOCORCM, VLROCORCM, NOMCIDETBOCORCM, ")
            str.Append("CODESTUNIOCORCM,NUMETBOCORCM,NOMETBOCORCM FROM MRT.T0150520 ")
            str.Append("WHERE NUMREQCADREP = " & sNumReqCadRep)

            sCmdSql = str.ToString

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
#End Region

#Region " ----------------- Consulta territórios do representante -------------"

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta as vendas realizadas por um representante nos ultimos 3 meses.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep"></param>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/28/2005	Created
    REM '''     [Getulio de Morais Pereira] 28/01/2005 Inclusao da coluna 'Char(CLITET.VLRVNDTET) As STRVLRVNDTET' para tratamento de formatacao.
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnDdoTet(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String

        Try
            'sCmdSql = " SELECT CLITET.CODTETVND,TET.DESTETVND,REP.CODREP, REP.NOMREP, CLITET.ANOMESREF, CLITET.VLRVNDTET, Char(CLITET.VLRVNDTET) As STRVLRVNDTET " & _
            '          "   FROM MRT.T0150377 CLITET, MRT.T0133715 TET, MRT.T0100116 REP   " & _
            '          "  WHERE TET.CODTETVND = CLITET.CODTETVND " & _
            '          "    AND TET.CODREP = REP.CODREP " & _
            '          "    AND CLITET.NUMREQCADREP = " & sNumReqCadRep

            'Conversão Oracle 03/03/06
            sCmdSql = " SELECT CLITET.CODTETVND,TET.DESTETVND,REP.CODREP, REP.NOMREP, CLITET.ANOMESREF, CLITET.VLRVNDTET, TO_CHAR(CLITET.VLRVNDTET) As STRVLRVNDTET " & _
                      "   FROM MRT.T0150377 CLITET, MRT.T0133715 TET, MRT.T0100116 REP   " & _
                      "  WHERE TET.CODTETVND = CLITET.CODTETVND " & _
                      "    AND TET.CODREP = REP.CODREP " & _
                      "    AND CLITET.NUMREQCADREP = " & sNumReqCadRep

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

#End Region

#Region " ----------------- Consulta dados status -------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Consulta os status de uma dada requisicao.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep">Numero da requisicao a ser consultada.</param>
    REM ''' <param name="sVlrErr">String de erro ocorrido na consulta.</param>
    REM ''' <returns>XML contendo o resultado da consulta.</returns>
    REM ''' <remarks>
    REM ''' Retorna todos os status de uma dada requisicao onde o usuario da <BR>
    REM ''' ultima alteracao seja diferente da constante "PROCESSO".
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	1/4/2005	Documentacao do metodo.
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnDdoSta(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT ALTSTA.CODSTACADREP, STA.DESSTACADREP, ALTSTA.DATHRAULTALT , ALTSTA.NOMUSRULTALT " & _
            '          " FROM MRT.T0150334 STA, MRT.T0150350 ALTSTA " & _
            '          " WHERE STA.CODSTACADREP = ALTSTA.CODSTACADREP  " & _
            '          "   AND ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
            '          "   AND ALTSTA.NOMUSRULTALT <> 'PROCESSO' " & _
            '          " ORDER BY ALTSTA.DATHRAULTALT "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT ALTSTA.CODSTACADREP, STA.DESSTACADREP, TO_CHAR(ALTSTA.DATHRAULTALT, 'YYYY-MM-DD HH24:MI:SS.FF') AS DATHRAULTALT , ALTSTA.NOMUSRULTALT " & _
                      " FROM MRT.T0150334 STA, MRT.T0150350 ALTSTA " & _
                      " WHERE STA.CODSTACADREP = ALTSTA.CODSTACADREP  " & _
                      "   AND ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
                      "   AND ALTSTA.NOMUSRULTALT <> 'PROCESSO' " & _
                      " ORDER BY ALTSTA.DATHRAULTALT "


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

    Public Function CsnTotDdoStaReq(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String

        Try
            '  sCmdSql = " SELECT ALTSTA.CODSTACADREP, STA.DESSTACADREP, ALTSTA.DATHRAULTALT , ALTSTA.NOMUSRULTALT " & _
            '" FROM MRT.T0150334 STA, MRT.T0150350 ALTSTA " & _
            '" WHERE STA.CODSTACADREP = ALTSTA.CODSTACADREP  " & _
            '"   AND ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
            '" ORDER BY ALTSTA.DATHRAULTALT "

            'Conversão Oracle 15/02/06
            sCmdSql = " SELECT ALTSTA.CODSTACADREP, STA.DESSTACADREP, TO_CHAR(ALTSTA.DATHRAULTALT, 'YYYY-MM-DD HH24:MI:SS.FF') AS DATHRAULTALT, ALTSTA.NOMUSRULTALT " & _
                      " FROM MRT.T0150334 STA, MRT.T0150350 ALTSTA " & _
                      " WHERE STA.CODSTACADREP = ALTSTA.CODSTACADREP  " & _
                      "   AND ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
                      " ORDER BY ALTSTA.DATHRAULTALT "


            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            oObeAcsDdo.ExcCmdSql(sVlrRet)
            Return sVlrRet
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then oObeAcsDdo = Nothing
        End Try
    End Function


    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Remove status de uma dada requisicao.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep">Numero da requisicao</param>
    REM ''' <param name="sLstStaCadRep">Lista contendo os status a serem removidos.</param>
    REM ''' <param name="sVlrErr">Retorno de ocorrencia de erro na operacao de remocao.</param>
    REM ''' <returns>Quantidade de registros removidos</returns>
    REM ''' <remarks>
    REM ''' A lista de status deve ser da forma "(status1, status2, ..., statusN)"
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/15/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function EcsStaReq(ByVal sNumReqCadRep As String, _
                               ByVal sLstStaCadRep As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Int64
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim str As System.Text.StringBuilder
        Dim sCmdSql As String
        'Valor de retorno
        Dim iNumRgt As Integer

        Try
            str = New System.Text.StringBuilder
            str.Append(" DELETE FROM MRT.T0150350 STA ")
            str.Append("  WHERE STA.NUMREQCADREP = " + sNumReqCadRep)
            str.Append("    AND STA.CODSTACADREP IN " + sLstStaCadRep)
            sCmdSql = str.ToString()
            str = Nothing

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
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

#Region " ----------------- Consulta status de uma requisicao -------------"
    Public Function CsnDdoStaReq(ByVal sNumReqCadRep As String, ByVal sCodStaCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT ALTSTA.CODSTACADREP, ALTSTA.DATHRAULTALT , ALTSTA.NOMUSRULTALT " & _
            '          " FROM MRT.T0150350 ALTSTA " & _
            '          " WHERE ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
            '          "   AND ALTSTA.CODSTACADREP = " & sCodStaCadRep

            'Conversão Oracle 15/02/06
            sCmdSql = " SELECT ALTSTA.CODSTACADREP, TO_CHAR(ALTSTA.DATHRAULTALT, 'YYYY-MM-DD HH24:MI:SS.FF') AS DATHRAULTALT, ALTSTA.NOMUSRULTALT " & _
                                  " FROM MRT.T0150350 ALTSTA " & _
                                  " WHERE ALTSTA.NUMREQCADREP = " & sNumReqCadRep & _
                                  "   AND ALTSTA.CODSTACADREP = " & sCodStaCadRep

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
#End Region

#Region " ----------------- Consulta competências do representante -------------"
    Function CsnDdoCtn(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT CTNREP.CODCTNREP,CTN.DESTITCTNREP, CTNREP.VLRCTNREP " & _
                      " FROM MRT.T0150652 CTNREP, MRT.T0150636 CTN " & _
                      "  WHERE CTNREP.CODCTNREP = CTN.CODCTNREP " & _
                      "  AND CTNREP.NUMREQCADREP = " & sNumReqCadRep

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
#End Region


#Region " ----------------- Consulta todas as informações do representante -------------"
    Public Function CsnTotDdoRep(ByVal sNumReqCttRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT REP.NUMREQCADREP, REP.NUMCPFREP,REP.NUMDOCIDTREP,REP.NOMORGEMSDOCIDTREP, REP.NOMREP, " + _
            '          "        REP.DATSLC,REP.DATEFTFIM,REP.CODGERMCD,REP.CODGERVND,REP.CODSITREP,REP.TIPREP,REP.CODGRPVNDREP, " + _
            '          "        REP.CODGERTRP,REP.CODREGCOB,REP.CODSEX,REP.DATNSCREP,REP.NOMNACREP,REP.TIPESTCVLREP,REP.CODGRAECLREP," + _
            '          "        REP.TIPSITECLREP,REP.ENDREP,REP.CODBAI,REP.CODCPLBAI,REP.CODESTUNI,REP.CODCIDREP,REP.CODCEPREP, " + _
            '          "        REP.TIPSITRSIREP,REP.TIPVTGRSIREP,REP.TIPSITTLFREP,REP.NUMTLFREP,REP.NUMTLFCELREP,REP.TIPSITFAXREP, " + _
            '          "        REP.NUMFAXREP,REP.TIPSITREPCSHREG,REP.CODSGMMCD,REP.NUMINSINUNACSEGSOC,REP.NOMDEPREP,REP.DATNSCDEP, " + _
            '          "        REP.NUMDOCIDT,REP.NOMORGEMSDOCIDTDEP, REP.QDEFLHREP,REP.CODBCOREP,REP.CODAGEBCOREP,REP.CODCNTCRRBCOREP, " + _
            '          "        REP.NUMDIGVRFAGEBCOREP,REP.TIPNATREP,REP.DESACOTRBREP,REP.CODSTACADREP,REP.NUMRGTREPCSHREG, " + _
            '          "        REP.DATRGTREPCSHREG, REP.CODESTUNICSHREG, REP.TIPSITPESJURCSHREG, REP.QDEOCORCM, REP.VLRTOTRCM, " + _
            '          "        REP.QDEOCOACOCVL, REP.QDETITVNCNAOPGO, REP.QDEOCOCHQSEMFND, REP.DATULTOCOCHQSEMFND, REP.NOMBCOULTCHQSEMFND, " + _
            '          "        REP.DATHRARCBINFCRD, REP.INDRTCCRD, REP.INDACEPND, REP.INDVLDCPF, REP.CODUNDNGC, REP.NUMREQANTCADREP, " + _
            '          "        CID.NOMCID, BAI.NOMBAI, GM.NOMSUP, GV.NOMGER, CPLBAI.NOMCPLBAI, SGMMCD.DESSGMMCD, BCO.NOMBCO, " + _
            '          "        AGEBCO.NOMAGEBCO, STA.DESSTACADREP, REP.NOMULTCHQSEMFND, REP.TIPFRMPGT,GV.CODFNCGER " + _
            '          " FROM MRT.T0150415 REP " + _
            '          "        LEFT OUTER JOIN MRT.T0103905 CPLBAI ON REP.CODCPLBAI = CPLBAI.CODCPLBAI, " + _
            '          "        MRT.T0100035 CID," + _
            '          "        MRT.T0100027 BAI," + _
            '          "        MRT.T0100124 GM, " + _
            '          "        MRT.T0100051 GV, " + _
            '          "        MRT.T0105983 SGMMCD," + _
            '          "        MRT.T0100345 BCO," + _
            '          "        MRT.T0104413 AGEBCO," + _
            '          "        MRT.T0150334 STA " + _
            '          " WHERE  REP.NUMREQCADREP = " + sNumReqCttRep + _
            '          "        AND  REP.CODCIDREP = CID.CODCID" + _
            '          "        AND  REP.CODBAI = BAI.CODBAI" + _
            '          "        AND  REP.CODGERMCD = GM.CODSUP " + _
            '          "        AND  REP.CODGERVND = GV.CODGER " + _
            '          "        AND  REP.CODSGMMCD = SGMMCD.CODSGMMCD " + _
            '          "        AND  REP.CODBCOREP = BCO.CODBCO " + _
            '          "        AND  REP.CODBCOREP = AGEBCO.CODBCO " + _
            '          "        AND  REP.CODAGEBCOREP = AGEBCO.CODAGEBCO " + _
            '          "        AND  REP.CODSTACADREP = STA.CODSTACADREP " + _
            '          "        AND GV.DATDSTGER IS NULL "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT REP.NUMREQCADREP, REP.NUMCPFREP, REP.NUMDOCIDTREP, REP.NOMORGEMSDOCIDTREP, REP.NOMREP, " + _
                      "        TRUNC(REP.DATSLC) AS DATSLC, TRUNC(REP.DATEFTFIM) AS DATEFTFIM, REP.CODGERMCD, REP.CODGERVND, REP.CODSITREP, REP.TIPREP, REP.CODGRPVNDREP, " + _
                      "        REP.CODGERTRP, REP.CODREGCOB, REP.CODSEX, TRUNC(REP.DATNSCREP) AS DATNSCREP, REP.NOMNACREP, REP.TIPESTCVLREP, REP.CODGRAECLREP," + _
                      "        REP.TIPSITECLREP, REP.ENDREP, REP.CODBAI, REP.CODCPLBAI, REP.CODESTUNI, REP.CODCIDREP, REP.CODCEPREP, " + _
                      "        REP.TIPSITRSIREP, REP.TIPVTGRSIREP, REP.TIPSITTLFREP, REP.NUMTLFREP, REP.NUMTLFCELREP, REP.TIPSITFAXREP, " + _
                      "        REP.NUMFAXREP, REP.TIPSITREPCSHREG, REP.CODSGMMCD, REP.NUMINSINUNACSEGSOC, REP.NOMDEPREP, TRUNC(REP.DATNSCDEP) AS DATNSCDEP, " + _
                      "        REP.NUMDOCIDT, REP.NOMORGEMSDOCIDTDEP, REP.QDEFLHREP, REP.CODBCOREP, REP.CODAGEBCOREP, REP.CODCNTCRRBCOREP, " + _
                      "        REP.NUMDIGVRFAGEBCOREP, REP.TIPNATREP, REP.DESACOTRBREP, REP.CODSTACADREP, REP.NUMRGTREPCSHREG, " + _
                      "        TRUNC(REP.DATRGTREPCSHREG) AS DATRGTREPCSHREG, REP.CODESTUNICSHREG, REP.TIPSITPESJURCSHREG, REP.QDEOCORCM, REP.VLRTOTRCM, " + _
                      "        REP.QDEOCOACOCVL, REP.QDETITVNCNAOPGO, REP.QDEOCOCHQSEMFND, TRUNC(REP.DATULTOCOCHQSEMFND) AS DATULTOCOCHQSEMFND, REP.NOMBCOULTCHQSEMFND, " + _
                      "        TO_CHAR(REP.DATHRARCBINFCRD, 'YYYY-MM-DD HH24:MI:SS.FF') AS DATHRARCBINFCRD, REP.INDRTCCRD, REP.INDACEPND, REP.INDVLDCPF, REP.CODUNDNGC, REP.NUMREQANTCADREP, " + _
                      "        CID.NOMCID, BAI.NOMBAI, GM.NOMSUP, GV.NOMGER, CPLBAI.NOMCPLBAI, SGMMCD.DESSGMMCD, BCO.NOMBCO, " + _
                      "        AGEBCO.NOMAGEBCO, STA.DESSTACADREP, REP.NOMULTCHQSEMFND, REP.TIPFRMPGT,GV.CODFNCGER " + _
                      " FROM MRT.T0150415 REP " + _
                      "        LEFT OUTER JOIN MRT.T0103905 CPLBAI ON REP.CODCPLBAI = CPLBAI.CODCPLBAI, " + _
                      "        MRT.T0100035 CID," + _
                      "        MRT.T0100027 BAI," + _
                      "        MRT.T0100124 GM, " + _
                      "        MRT.T0100051 GV, " + _
                      "        MRT.T0105983 SGMMCD," + _
                      "        MRT.T0100345 BCO," + _
                      "        MRT.T0104413 AGEBCO," + _
                      "        MRT.T0150334 STA " + _
                      " WHERE  REP.NUMREQCADREP = " + sNumReqCttRep + _
                      "        AND  REP.CODCIDREP = CID.CODCID" + _
                      "        AND  REP.CODBAI = BAI.CODBAI" + _
                      "        AND  REP.CODGERMCD = GM.CODSUP " + _
                      "        AND  REP.CODGERVND = GV.CODGER " + _
                      "        AND  REP.CODSGMMCD = SGMMCD.CODSGMMCD " + _
                      "        AND  REP.CODBCOREP = BCO.CODBCO " + _
                      "        AND  REP.CODBCOREP = AGEBCO.CODBCO " + _
                      "        AND  REP.CODAGEBCOREP = AGEBCO.CODAGEBCO " + _
                      "        AND  REP.CODSTACADREP = STA.CODSTACADREP " + _
                      "        AND GV.DATDSTGER IS NULL "

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
#End Region

#Region " ----------------- Consulta CPF do representante -------------"
    Public Function CsnCpfRep(ByVal sNumCpfRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String

        Try
            sCmdSql = " SELECT  CODREP " + _
           " FROM MRT.T0100116 " + _
           " WHERE  NUMCPFREP = '" + sNumCpfRep + "'"

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
#End Region

#Region " ----------------- Consulta Datas na tabela de Segmento de Mercado -------------"
    Public Function CsnDatSgmMcd(ByVal sCodSgmMcd As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try
            ' sCmdSql = " SELECT  char(CURRENT DATE + QDEDIACRCPTCCALPRO DAYS, iso), char(CURRENT DATE + 21 MONTHS, iso) " + _
            '" FROM MRT.T0105983 " + _
            '" WHERE  CODSGMMCD = " + sCodSgmMcd

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT TO_CHAR(SYSDATE + QDEDIACRCPTCCALPRO, 'YYYY-MM-DD'), TO_CHAR(ADD_MONTHS(SYSDATE, 21), 'YYYY-MM-DD') " + _
           " FROM MRT.T0105983 " + _
           " WHERE  CODSGMMCD = " + sCodSgmMcd

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
#End Region

#Region " --------------- Consulta Número Da Próxima Requisição -----------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Obtem o numero da proxima requisicao a ser inserida.
    REM ''' </summary>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns>String contendo o numero da proxima requisicao disponivel para insercao.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	12/29/2004	Inclusao de comando de lock na tabela para sincronizar insercoes.
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnNroReq(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim sVlrRet As String
        Dim iCnt As Integer
        Try
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            'sCmdSql = " (select coalesce(max(integer(NUMREQCADREP)) + 1,1) from mrt.t0150415) "

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT COALESCE(MAX(TRUNC(NUMREQCADREP)) + 1,1) FROM MRT.t0150415 "

            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(sVlrRet)
            Return sVlrRet
        Catch oObeEcc As Exception
            Throw
        Finally
            If Not oObeAcsDdo Is Nothing Then oObeAcsDdo = Nothing
        End Try
    End Function

#End Region

#Region " --------------- Consulta Número Do Próximo Representante -----------------"
    Public Function CsnCodPrxRep(ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String

        Try
            sCmdSql = " SELECT MIN(CODREP) + 1 " & _
                      " FROM MRT.T0100116 " & _
                      " WHERE (CODREP + 1) NOT IN " & _
                      " (SELECT CODREP " & _
                      " FROM MRT.T0100116) " & _
                      " AND (CODREP + 1) NOT IN " & _
                      " (SELECT CODGER " & _
                      " FROM MRT.T0100051) "
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
#End Region

#Region " ----------------- Consulta tabela complementar da tabela de Representante  -------------"
    Public Function CsnCplTabRep(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT * " & _
                      " FROM MRT.T0118678 " & _
                      " WHERE CODREP = " & sCodRep

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
#End Region

#Region " ----------------- Consulta Dependente do Representante  -------------"
    Public Function CsnDepRep(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String

        Try


            sCmdSql = " SELECT * " & _
                      " FROM MRT.T0107315 " & _
                      " WHERE CODGRAPARREP = 2 AND CODREP = " & sCodRep

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
#End Region


#Region " ----------------- Consulta Pareceres sem retorno  -------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Retorna a quantidade TOTAL de pareceres pendentes para uma dada requisicao.
    REM ''' </summary>
    REM ''' <param name="psNumReqCadRep">Numero da requisicao a ser verificada.</param>
    REM ''' <param name="sVlrErr">Variavel de retorno de erro.</param>
    REM ''' <returns>XML contendo o numero de pareceres pendentes, segundo o emissor.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/26/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnTotRetOpn(ByVal psNumReqCadRep As String, _
                                  ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        'comando sql
        Dim sCmdSql As String

        Try


            sCmdSql = " SELECT COUNT(*) As QTD FROM MRT.T0156332 " & _
                      "  WHERE NUMREQCADREP = " & psNumReqCadRep & _
                      "    AND DATHRA IS NULL "

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
#End Region

    Public Function CsnRetOpn(ByVal psNumReqCadRep As String, _
                                                ByVal psCodStaCadRep As String, _
                                                ByVal psNomUsrDsn As String, _
                                                ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql(0) As String
        Dim str As System.Text.StringBuilder
        Try
            str = New System.Text.StringBuilder
            str.Append(" SELECT COUNT(*) As QTD FROM MRT.T0156332 ")
            str.Append("  WHERE NUMREQCADREP = " & psNumReqCadRep)
            ' str.Append("    AND CODSTACADREP = " & psCodStaCadRep)
            str.Append("    AND UPPER(NOMUSR) = UPPER('" & psNomUsrDsn & "')")
            str.Append("    AND DATHRA IS NULL ")

            sCmdSql(0) = str.ToString

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql(0))
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

#Region " --------------- Insere Dados na Tabela de Pedido e Retorno de Pareceres ------------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Insere registro indicadore de pedido / retorno de parecer.
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep">Numero da requisicao</param>
    REM ''' <param name="sCodStaCadRep">Codigo do Status para Pedido (18 / 20) e Retorno (19 / 21) de parecer.</param>
    REM ''' <param name="sCodSeqObs">Codigo da sequencia do fluxo que armazena a mensagem do parecer.</param>
    REM ''' <param name="sNomUsr">ID do usuario que solicitou / retornou o parecer</param>
    REM ''' <param name="sVlrErr">Variavel de retorno de mensagem de erro.</param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/25/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function IsrDdoPedRetOpn(ByVal sNumReqCadRep As String, _
                                                 ByVal sCodStaCadRep As String, _
                                                      ByVal sCodSeqObs As String, _
                                                      ByVal sNomUsr As String, _
                                                      ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim str As System.Text.StringBuilder
        Dim sCmdSql As String
        Dim iNumRgt As Integer
        Try
            str = New System.Text.StringBuilder
            str.Append(" INSERT INTO MRT.T0156332 (NUMREQCADREP, CODSTACADREP, CODSEQOBS, NOMUSR, DATHRA) ")
            str.Append(" VALUES ( " & sNumReqCadRep)
            str.Append("        , " & sCodStaCadRep)
            str.Append("        , " & sCodSeqObs)
            str.Append("        , '" & sNomUsr & "'")
            If sCodStaCadRep = "19" Or sCodStaCadRep = "21" Then
                str.Append("        , NULL")
            Else
                'str.Append("        , CURRENT TIMESTAMP")
                'Conversão Oracle 16/02/06
                str.Append("        , TRUNC(SYSDATE)")
            End If

            str.Append("        ) ")
            sCmdSql = str.ToString
            str = Nothing

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
            str = Nothing
        End Try
    End Function
#End Region

#Region " --------------- Altera registro de retorno de parecer  ------------------"
    Public Function AltDdoPetRetOpn(ByVal sNumReqCadRep As String, _
                                                      ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Dim sCmdSql As String
        Dim iNumRgt As Integer
        Dim str As System.Text.StringBuilder
        Try

            str = New System.Text.StringBuilder

            'str.Append(" UPDATE MRT.T0156332 ")
            'str.Append("    SET DATHRA = CURRENT TIMESTAMP ")
            'str.Append("  WHERE NUMREQCADREP = " & sNumReqCadRep)
            'str.Append("    AND DATHRA IS NULL ")

            'Conversão Oracle 16/02/06
            str.Append(" UPDATE MRT.T0156332 ")
            str.Append("    SET DATHRA = TRUNC(SYSDATE) ")
            str.Append("  WHERE NUMREQCADREP = " & sNumReqCadRep)
            str.Append("    AND DATHRA IS NULL ")

            sCmdSql = str.ToString
            str = Nothing
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
            str = Nothing
        End Try

    End Function


    Public Function AltDdoPetRetOpn(ByVal psNumReqCadRep As String, _
                                                      ByVal psNomUsrOrg As String, _
                                                      ByVal psCodSeqObs As String, _
                                                      ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Dim sCmdSql As String
        Dim iNumRgt As Integer
        Dim str As System.Text.StringBuilder
        Try

            str = New System.Text.StringBuilder

            'str.Append(" UPDATE MRT.T0156332 ")
            'str.Append("    SET DATHRA = CURRENT TIMESTAMP ")
            'str.Append("  WHERE NUMREQCADREP = " & psNumReqCadRep)
            'str.Append("    AND CODSEQOBS = " & psCodSeqObs)
            'str.Append("    AND UPPER(NOMUSR) = UPPER('" & psNomUsrOrg & "')")
            'str.Append("    AND DATHRA IS NULL ")

            'Conversão Oracle 16/02/06
            str.Append(" UPDATE MRT.T0156332 ")
            str.Append("    SET DATHRA = TRUNC(SYSDATE) ")
            str.Append("  WHERE NUMREQCADREP = " & psNumReqCadRep)
            str.Append("    AND CODSEQOBS = " & psCodSeqObs)
            str.Append("    AND UPPER(NOMUSR) = UPPER('" & psNomUsrOrg & "')")
            str.Append("    AND DATHRA IS NULL ")
            sCmdSql = str.ToString

            sCmdSql = str.ToString
            str = Nothing

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            Dim sVlrRet As String
            Dim iCnt As Integer
            oObeAcsDdo.ExcCmdSql(iCnt)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
            str = Nothing
        End Try

    End Function

#End Region

#Region " --> Obtem o numero da sequencia da mensagem do parecer"
    Public Function CsnCodSeqObsPetRetOpn(ByVal sNumReqCadRep As String, _
                                                  ByVal sCodStaCadRep As String, _
                                                  ByVal sNomUsrDsn As String, _
                                                  ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try


            str = New System.Text.StringBuilder

            str.Append(" SELECT CodSeqObs ")
            str.Append("   FROM MRT.T0156332 ")
            str.Append("  WHERE NUMREQCADREP = " & sNumReqCadRep)
            str.Append("    AND CODSTACADREP = " & sCodStaCadRep)
            str.Append("    AND UPPER(NOMUSR) = UPPER('" & sNomUsrDsn & "') ")
            'str.Append("    AND DATHRA IS NULL ")
            sCmdSql = str.ToString
            str = Nothing

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
            'liberando objetos
            oObeAcsDdo = Nothing
            str = Nothing
        End Try

    End Function


#End Region
#Region " --------------- Insere Dados na Tabela de Descrição de Observações ------------------"
    Public Function IsrDdoDesObs(ByVal sNumReqCadRep As String, ByVal sCodSeqObs As String, ByVal sDesObs As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            sCmdSql = " insert into mrt.t0150610 (NUMREQCADREP, CODSEQOBS, DESOBS) " & _
                      " values (" & sNumReqCadRep & "," & sCodSeqObs & ",'" & sDesObs & "')"
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region


#Region " --------------- Copia os dados do fluxo de uma requisicao em ressubmissao ------------------"
    Public Function IsrDdoDesObsNvo(ByVal sNumReqAntCadRep As String, ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim strCsn As System.Text.StringBuilder
        Dim strIsr As System.Text.StringBuilder
        Dim oGrpDdo As New DataSet
        Dim sCmdSql As String
        Dim iNumRgt As Integer
        Dim iCnt As Integer
        Dim iCodSeqObs As Integer
        Dim oCnxAux As IAU013.UO_IAUCnxAcsDdo

        Try
            strCsn = New System.Text.StringBuilder
            oCnxAux = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            strCsn.Append(" select codseqobs from mrt.t0150610 where numreqcadrep  = " & sNumReqAntCadRep & " and upper(desobs) like '%REPROVADO%' ")
            sCmdSql = strCsn.ToString
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(oGrpDdo)
            iCodSeqObs = oGrpDdo.Tables(0).Rows(0)("CodSeqObs")

            strCsn = New System.Text.StringBuilder
            oCnxAux = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            strCsn.Append(" select " & sNumReqCadRep & ", CODSEQOBS, DESOBS  from mrt.t0150610 where numreqcadrep = " & sNumReqAntCadRep)
            strCsn.Append(" and codseqobs < ( " & iCodSeqObs & " )")
            sCmdSql = strCsn.ToString
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnxAux, sCmdSql)
            oObeAcsDdo.ExcCmdSql(oGrpDdo)

            Dim sDesObs As String
            For iCnt = 0 To oGrpDdo.Tables(0).Rows.Count - 1
                strIsr = New System.Text.StringBuilder
                strIsr.Append(" insert into mrt.t0150610 (NUMREQCADREP, CODSEQOBS, DESOBS) ")
                strIsr.Append(" values (" & sNumReqCadRep & ", ")
                strIsr.Append(CType(oGrpDdo.Tables(0).Rows(iCnt)("CODSEQOBS"), String) & " , '")
                sDesObs = CType(oGrpDdo.Tables(0).Rows(iCnt)("DESOBS"), String)
                If sDesObs = "" Then
                    sDesObs = " "
                End If
                strIsr.Append(sDesObs & "')")
                sCmdSql = strIsr.ToString
                oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
                oObeAcsDdo.ExcCmdSql(iNumRgt)
            Next

            Return iCnt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

    ' Verifica a existencia de bloqueio por contrato quanto for recadastro de RCA
    Public Function CsnBlqOrdPgt(ByVal sCodRep As String, _
                                  ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try
            str = New System.Text.StringBuilder
            '-- Bloqueio por contrato
            str.Append(" SELECT count(*) As Qtd ")
            str.Append("   FROM MRT.T0111061 ")
            str.Append("  WHERE CODMTVBLQORDPGT = 28 ")
            str.Append("    AND CODREP = " & sCodRep)
            sCmdSql = str.ToString

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

    ' Verifica a existencia de RPA quanto for recadastro de RCA
    Public Function CsnRboPgtPvtEde(ByVal sNumCpfRep As String, _
                                     ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try
            str = New System.Text.StringBuilder
            ' -- RPA
            str.Append(" SELECT count(*) As Qtd ")
            str.Append("    FROM MRT.T0109067 ")
            str.Append("  WHERE FLGRBOPGTPVTEDE = 'N' ")
            str.Append("        AND NUMDOCEDE = '" & sNumCpfRep & "'")
            sCmdSql = str.ToString
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


    ' Verifica a existencia de acertos pendentes quanto for recadastro de RCA
    Public Function CsnInzPgo(ByVal sCodRep As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim str As System.Text.StringBuilder
        Try
            str = New System.Text.StringBuilder

            ' -- Acertos
            str.Append(" SELECT count(*) As Qtd ")
            str.Append("   FROM MRT.T0132271 ")
            str.Append(" WHERE CODREP = " & sCodRep)
            sCmdSql = str.ToString

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


#Region " --------------- Insere Dados na Tabela Temporária de Representantes ------------------"

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Insere dados do RCA na tabela temporaria.
    REM ''' </summary>
    REM ''' <param name="sNumReqCttRep"></param>
    REM ''' <param name="sNumCpfRep"></param>
    REM ''' <param name="sNumDocIdtRep"></param>
    REM ''' <param name="sNomOrgEmsDocIdtRep"></param>
    REM ''' <param name="sNomRep"></param>
    REM ''' <param name="sCodGerMcd"></param>
    REM ''' <param name="sCodGerVnd"></param>
    REM ''' <param name="sCodSex"></param>
    REM ''' <param name="sDatNscRep"></param>
    REM ''' <param name="sNomAcsRep"></param>
    REM ''' <param name="sTipEstCvlRep"></param>
    REM ''' <param name="sCodGraEclRep"></param>
    REM ''' <param name="sTipSitEclRep"></param>
    REM ''' <param name="sEndRep"></param>
    REM ''' <param name="sCodBai"></param>
    REM ''' <param name="sCodCplBai"></param>
    REM ''' <param name="sCodCidRep"></param>
    REM ''' <param name="sCodCepRep"></param>
    REM ''' <param name="sTipSitRsiRep"></param>
    REM ''' <param name="sTipVtgRsiRep"></param>
    REM ''' <param name="sTipSitTlfRep"></param>
    REM ''' <param name="sNumTlfRep"></param>
    REM ''' <param name="sNumTlfCelRep"></param>
    REM ''' <param name="sTipSitFaxRep"></param>
    REM ''' <param name="sNumFaxRep"></param>
    REM ''' <param name="sCodSgmMcd"></param>
    REM ''' <param name="sNumInsInuNacSegSoc"></param>
    REM ''' <param name="sNomDepRep"></param>
    REM ''' <param name="sDatNscDep"></param>
    REM ''' <param name="sNumDocIdt"></param>
    REM ''' <param name="sNomOrgEmsDocIdtDep"></param>
    REM ''' <param name="sQdeFlhRep"></param>
    REM ''' <param name="sCodBcoRep"></param>
    REM ''' <param name="sCodAgeBcoRep"></param>
    REM ''' <param name="sCodCntCrrBcoRep"></param>
    REM ''' <param name="sNumDigVrfAgeBcoRep"></param>
    REM ''' <param name="sTipNatRep"></param>
    REM ''' <param name="sDesAcoTrbRep"></param>
    REM ''' <param name="sCodStaCadRep"></param>
    REM ''' <param name="sDatRgtRepCshReg"></param>
    REM ''' <param name="sCodEstUniCshReg"></param>
    REM ''' <param name="sTipSitPesJrCshReg"></param>
    REM ''' <param name="sCodEstUni"></param>
    REM ''' <param name="sNumRgtRepCshRep"></param>
    REM ''' <param name="sIndAcePnd"></param>
    REM ''' <param name="sIndVldCpf"></param>
    REM ''' <param name="sCodUndNgc"></param>
    REM ''' <param name="sTipFrmPgt"></param>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	12/23/2004	Adequacao dos valores de constantes Regiao de Cobranca e Gerente de Transporte.
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function IsrDdoRep(ByVal sNumReqCttRep As String, ByVal sNumCpfRep As String, ByVal sNumDocIdtRep As String, _
                               ByVal sNomOrgEmsDocIdtRep As String, ByVal sNomRep As String, ByVal sCodGerMcd As String, _
                               ByVal sCodGerVnd As String, ByVal sCodSex As String, ByVal sDatNscRep As String, ByVal sNomAcsRep As String, _
                               ByVal sTipEstCvlRep As String, ByVal sCodGraEclRep As String, ByVal sTipSitEclRep As String, ByVal sEndRep As String, _
                               ByVal sCodBai As String, ByVal sCodCplBai As String, ByVal sCodCidRep As String, ByVal sCodCepRep As String, ByVal sTipSitRsiRep As String, _
                               ByVal sTipVtgRsiRep As String, ByVal sTipSitTlfRep As String, ByVal sNumTlfRep As String, ByVal sNumTlfCelRep As String, ByVal sTipSitFaxRep As String, _
                               ByVal sNumFaxRep As String, ByVal sCodSgmMcd As String, ByVal sNumInsInuNacSegSoc As String, _
                               ByVal sNomDepRep As String, ByVal sDatNscDep As String, ByVal sNumDocIdt As String, ByVal sNomOrgEmsDocIdtDep As String, _
                               ByVal sQdeFlhRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, _
                               ByVal sNumDigVrfAgeBcoRep As String, ByVal sTipNatRep As String, ByVal sDesAcoTrbRep As String, _
                               ByVal sCodStaCadRep As String, ByVal sDatRgtRepCshReg As String, ByVal sCodEstUniCshReg As String, _
                               ByVal sTipSitPesJrCshReg As String, ByVal sCodEstUni As String, ByVal sNumRgtRepCshRep As String, _
                               ByVal sIndAcePnd As String, ByVal sIndVldCpf As String, ByVal sCodUndNgc As String, _
                               ByVal sTipFrmPgt As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Dim CteGerTrp As Integer
        Dim CteCodRegCob As Integer
        Try
            CteGerTrp = 1
            CteCodRegCob = 2

            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim sVlrRet As String

            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            'insere na tabela temporária de representantes
            str.Append(" INSERT INTO MRT.T0150415(NUMREQCADREP,NUMCPFREP,NUMDOCIDTREP, ")
            str.Append("   NOMORGEMSDOCIDTREP,NOMREP,DATSLC,DATEFTFIM, ")
            str.Append("   CODGERMCD,CODGERVND,CODSITREP,TIPREP,CODGRPVNDREP,CODGERTRP, ")
            str.Append("   CODREGCOB,CODSEX,DATNSCREP,NOMNACREP, TIPESTCVLREP,CODGRAECLREP, ")
            str.Append("   TIPSITECLREP,ENDREP,CODBAI,CODCPLBAI,CODCIDREP,CODCEPREP,TIPSITRSIREP, ")
            str.Append("   TIPVTGRSIREP, TIPSITTLFREP,NUMTLFREP,NUMTLFCELREP,TIPSITFAXREP,NUMFAXREP, ")
            str.Append("   TIPSITREPCSHREG,CODSGMMCD,NUMINSINUNACSEGSOC, NOMDEPREP,DATNSCDEP,NUMDOCIDT, ")
            str.Append("   NOMORGEMSDOCIDTDEP,QDEFLHREP,CODBCOREP,CODAGEBCOREP,CODCNTCRRBCOREP, ")
            str.Append("   NUMDIGVRFAGEBCOREP,TIPNATREP,DESACOTRBREP,CODSTACADREP,DATRGTREPCSHREG, ")
            str.Append("   CODESTUNICSHREG,TIPSITPESJURCSHREG, CODESTUNI, INDACEPND, INDVLDCPF, CODUNDNGC, NUMRGTREPCSHREG, TIPFRMPGT) ")

            'str.Append(" VALUES (" + sNumReqCttRep + "," & FunFrmCpo(sNumCpfRep) & "," & FunFrmCpo(sNumDocIdtRep) & ",")
            'str.Append(FunFrmCpo(sNomOrgEmsDocIdtRep) + "," + FunFrmCpo(sNomRep) + ",CURRENT DATE,'0001-01-01', ")
            'str.Append(sCodGerMcd + "," + sCodGerVnd + " ,1,1,1," & CteGerTrp.ToString & ", ")
            'str.Append(CteCodRegCob.ToString + ", " + FunFrmCpo(sCodSex) + "," + FunFrmCpo(sDatNscRep) + "," + FunFrmCpo(sNomAcsRep) + "," + FunFrmCpo(sTipEstCvlRep) + "," + sCodGraEclRep + ",")
            'str.Append(FunFrmCpo(sTipSitEclRep) + "," + FunFrmCpo(sEndRep) + "," + sCodBai + "," + FunFrmCpoInt(sCodCplBai) + "," + sCodCidRep + "," + sCodCepRep + "," + FunFrmCpo(sTipSitRsiRep) + ",")
            'str.Append(sTipVtgRsiRep + "," + FunFrmCpo(sTipSitTlfRep) + "," + FunFrmCpo(sNumTlfRep) + "," + FunFrmCpo(sNumTlfCelRep) + "," + FunFrmCpo(sTipSitFaxRep) + "," + FunFrmCpo(sNumFaxRep) + ",")
            'str.Append(FunFrmCpo(sTipSitPesJrCshReg) + "," + sCodSgmMcd + "," + sNumInsInuNacSegSoc + "," + FunFrmCpo(sNomDepRep) + "," + FunFrmCpo(sDatNscDep) + "," + FunFrmCpo(sNumDocIdt) + ",")
            'str.Append(FunFrmCpo(sNomOrgEmsDocIdtDep) + "," + sQdeFlhRep + "," + sCodBcoRep + "," + sCodAgeBcoRep + "," + FunFrmCpo(sCodCntCrrBcoRep) + ",")
            'str.Append(FunFrmCpo(sNumDigVrfAgeBcoRep) + "," + FunFrmCpo(sTipNatRep) + "," + FunFrmCpo(sDesAcoTrbRep) + "," + sCodStaCadRep + "," + FunFrmCpo(sDatRgtRepCshReg) + ",")
            'str.Append(FunFrmCpo(sCodEstUniCshReg) + ",'PF'," & FunFrmCpo(sCodEstUni) & "," & sIndAcePnd & "," & sIndVldCpf & "," & sCodUndNgc & "," & FunFrmCpo(sNumRgtRepCshRep) & "," & FunFrmCpo(sTipFrmPgt) & ")")

            'Conversão Oracle 16/02/06
            If sDatNscRep <> "NULL" Then
                sDatNscRep = "TO_DATE('" & sDatNscRep & "', 'YYYY-MM-DD')"
            End If
            If sDatNscDep <> "NULL" Then
                sDatNscDep = "TO_DATE('" & sDatNscDep & "', 'YYYY-MM-DD')"
            End If
            If sDatRgtRepCshReg <> "NULL" Then
                sDatRgtRepCshReg = "TO_DATE('" & sDatRgtRepCshReg & "', 'YYYY-MM-DD')"
            End If

            str.Append(" VALUES (" + sNumReqCttRep + "," & FunFrmCpo(sNumCpfRep) & "," & FunFrmCpo(sNumDocIdtRep) & ",")
            str.Append(FunFrmCpo(sNomOrgEmsDocIdtRep) + "," + FunFrmCpo(sNomRep) + ", TRUNC(SYSDATE) , TO_DATE('0001-01-01', 'YYYY-MM-DD'), ")
            str.Append(sCodGerMcd + "," + sCodGerVnd + " ,1,1,1," & CteGerTrp.ToString & ", ")
            str.Append(CteCodRegCob.ToString + ", " + FunFrmCpo(sCodSex) + "," + sDatNscRep + "," + FunFrmCpo(sNomAcsRep) + "," + FunFrmCpo(sTipEstCvlRep) + "," + sCodGraEclRep + ",")
            str.Append(FunFrmCpo(sTipSitEclRep) + "," + FunFrmCpo(sEndRep) + "," + sCodBai + "," + FunFrmCpoInt(sCodCplBai) + "," + sCodCidRep + "," + sCodCepRep + "," + FunFrmCpo(sTipSitRsiRep) + ",")
            str.Append(sTipVtgRsiRep + "," + FunFrmCpo(sTipSitTlfRep) + "," + FunFrmCpo(sNumTlfRep) + "," + FunFrmCpo(sNumTlfCelRep) + "," + FunFrmCpo(sTipSitFaxRep) + "," + FunFrmCpo(sNumFaxRep) + ",")
            str.Append(FunFrmCpo(sTipSitPesJrCshReg) + "," + sCodSgmMcd + "," + sNumInsInuNacSegSoc + "," + FunFrmCpo(sNomDepRep) + "," + sDatNscDep + "," + FunFrmCpo(sNumDocIdt) + ",")
            str.Append(FunFrmCpo(sNomOrgEmsDocIdtDep) + "," + sQdeFlhRep + "," + sCodBcoRep + "," + sCodAgeBcoRep + "," + FunFrmCpo(sCodCntCrrBcoRep) + ",")
            str.Append(FunFrmCpo(sNumDigVrfAgeBcoRep) + "," + FunFrmCpo(sTipNatRep) + "," + FunFrmCpo(sDesAcoTrbRep) + "," + sCodStaCadRep + "," + sDatRgtRepCshReg + ",")
            str.Append(FunFrmCpo(sCodEstUniCshReg) + ",'PF'," & FunFrmCpo(sCodEstUni) & "," & sIndAcePnd & "," & sIndVldCpf & "," & sCodUndNgc & "," & FunFrmCpo(sNumRgtRepCshRep) & "," & FunFrmCpo(sTipFrmPgt) & ")")

            'executa inserção
            sCmdSql = str.ToString()
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Dados na Tabela de Protestos ------------------"
    Public Function IsrDdoRcm(ByVal sNumReqCttRep As String, _
                               ByVal sCodSeqRcm As String, _
                               ByVal DatOcoRcm As String, _
                               ByVal VlrOcoRcm As String, _
                               ByVal NomCidEtbOcoRcm As String, _
                               ByVal CodEstUniOcoRcm As String, _
                               ByVal NumEtbOcoRcm As String, _
                               ByVal NomEtbOcoRcm As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            'Conversão Oracle 16/02/06
            'str.Append("INSERT INTO MRT.T0150520 (")
            'str.Append("NUMREQCADREP, ")
            'str.Append("CODSEQRCM, DatOcoRcm, VlrOcoRcm, NomCidEtbOcoRcm, ")
            'str.Append("CODESTUNIOCORCM,NUMETBOCORCM,NOMETBOCORCM) VALUES (")
            'str.Append(sNumReqCttRep + ",")
            'str.Append(sCodSeqRcm + ",")
            'str.Append("'" + DatOcoRcm + "',")
            'str.Append(VlrOcoRcm + ",")
            'str.Append("'" & NomCidEtbOcoRcm & "',")
            'str.Append("'" & CodEstUniOcoRcm & "',")
            'str.Append(NumEtbOcoRcm + ",")
            'str.Append("'" & NomEtbOcoRcm & "')")

            str.Append("INSERT INTO MRT.T0150520 (")
            str.Append("NUMREQCADREP, ")
            str.Append("CODSEQRCM, DatOcoRcm, VlrOcoRcm, NomCidEtbOcoRcm, ")
            str.Append("CODESTUNIOCORCM,NUMETBOCORCM,NOMETBOCORCM) VALUES (")
            str.Append(sNumReqCttRep + ",")
            str.Append(sCodSeqRcm + ",")
            str.Append("TO_DATE('" + DatOcoRcm + "','YYYY-MM-DD'),")
            str.Append(VlrOcoRcm + ",")
            str.Append("'" & NomCidEtbOcoRcm & "',")
            str.Append("'" & CodEstUniOcoRcm & "',")
            str.Append(NumEtbOcoRcm + ",")
            str.Append("'" & NomEtbOcoRcm & "')")

            sCmdSql = str.ToString
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Dados na Tabela de Acao Civil ------------------"
    Public Function IsrDdoAcoCvl(ByVal sNumReqCttRep As String, _
                                  ByVal sCodSeqAcoCvl As String, _
                                  ByVal sTipAcoCvl As String, _
                                  ByVal sDatOcoAcoCvl As String, _
                                  ByVal sNomCidOcoAcoCvlRep As String, _
                                  ByVal sCodEstUniOcoAcoCvl As String, _
                                  ByVal sNumEtbAcoCvl As String, _
                                  ByVal sNomCriAcoCvl As String, _
                                  ByVal sNomPesRcbAcoCvl As String, _
                                  ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            'str.Append("INSERT INTO MRT.T0150547 (")
            'str.Append("NUMREQCADREP,CODSEQACOCVL,TIPACOCVL,DATOCOACOCVL,NOMCIDOCOACOCVLREP,CODESTUNIOCOACOCVL,")
            'str.Append("NUMETBACOCVL,NOMCRIACOCVL,NOMPESRCBACOCVL) VALUES (")
            'str.Append(sNumReqCttRep + ",")
            'str.Append(sCodSeqAcoCvl + ",")
            'str.Append(sTipAcoCvl + ",")
            'str.Append("'" + sDatOcoAcoCvl + "',")
            'str.Append("'" & sNomCidOcoAcoCvlRep & "',")
            'str.Append("'" & sCodEstUniOcoAcoCvl & "',")
            'str.Append(sNumEtbAcoCvl + ",")
            'str.Append("'" & sNomCriAcoCvl & "',")
            'str.Append("'" & sNomPesRcbAcoCvl & "')")

            'Conversão Oracle 16/02/06
            str.Append("INSERT INTO MRT.T0150547 (")
            str.Append("NUMREQCADREP,CODSEQACOCVL,TIPACOCVL,DATOCOACOCVL,NOMCIDOCOACOCVLREP,CODESTUNIOCOACOCVL,")
            str.Append("NUMETBACOCVL,NOMCRIACOCVL,NOMPESRCBACOCVL) VALUES (")
            str.Append(sNumReqCttRep + ",")
            str.Append(sCodSeqAcoCvl + ",")
            str.Append(sTipAcoCvl + ",")
            str.Append("TO_DATE('" + sDatOcoAcoCvl + "','YYYY-MM-DD'),")
            str.Append("'" & sNomCidOcoAcoCvlRep & "',")
            str.Append("'" & sCodEstUniOcoAcoCvl & "',")
            str.Append(sNumEtbAcoCvl + ",")
            str.Append("'" & sNomCriAcoCvl & "',")
            str.Append("'" & sNomPesRcbAcoCvl & "')")

            sCmdSql = str.ToString
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region


#Region " --------------- Insere Novos Dados na Tabela Temporária de Representantes ------------------"

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Insere dados do RCA na tabela temporaria.
    REM ''' </summary>
    REM ''' <param name="sNumReqCttRep"></param>
    REM ''' <param name="sNumCpfRep"></param>
    REM ''' <param name="sNumDocIdtRep"></param>
    REM ''' <param name="sNomOrgEmsDocIdtRep"></param>
    REM ''' <param name="sNomRep"></param>
    REM ''' <param name="sCodGerMcd"></param>
    REM ''' <param name="sCodGerVnd"></param>
    REM ''' <param name="sCodSex"></param>
    REM ''' <param name="sDatNscRep"></param>
    REM ''' <param name="sNomAcsRep"></param>
    REM ''' <param name="sTipEstCvlRep"></param>
    REM ''' <param name="sCodGraEclRep"></param>
    REM ''' <param name="sTipSitEclRep"></param>
    REM ''' <param name="sEndRep"></param>
    REM ''' <param name="sCodBai"></param>
    REM ''' <param name="sCodCplBai"></param>
    REM ''' <param name="sCodCidRep"></param>
    REM ''' <param name="sCodCepRep"></param>
    REM ''' <param name="sTipSitRsiRep"></param>
    REM ''' <param name="sTipVtgRsiRep"></param>
    REM ''' <param name="sTipSitTlfRep"></param>
    REM ''' <param name="sNumTlfRep"></param>
    REM ''' <param name="sNumTlfCelRep"></param>
    REM ''' <param name="sTipSitFaxRep"></param>
    REM ''' <param name="sNumFaxRep"></param>
    REM ''' <param name="sCodSgmMcd"></param>
    REM ''' <param name="sNumInsInuNacSegSoc"></param>
    REM ''' <param name="sNomDepRep"></param>
    REM ''' <param name="sDatNscDep"></param>
    REM ''' <param name="sNumDocIdt"></param>
    REM ''' <param name="sNomOrgEmsDocIdtDep"></param>
    REM ''' <param name="sQdeFlhRep"></param>
    REM ''' <param name="sCodBcoRep"></param>
    REM ''' <param name="sCodAgeBcoRep"></param>
    REM ''' <param name="sCodCntCrrBcoRep"></param>
    REM ''' <param name="sNumDigVrfAgeBcoRep"></param>
    REM ''' <param name="sTipNatRep"></param>
    REM ''' <param name="sDesAcoTrbRep"></param>
    REM ''' <param name="sCodStaCadRep"></param>
    REM ''' <param name="sDatRgtRepCshReg"></param>
    REM ''' <param name="sCodEstUniCshReg"></param>
    REM ''' <param name="sTipSitPesJrCshReg"></param>
    REM ''' <param name="sCodEstUni"></param>
    REM ''' <param name="sNumRgtRepCshRep"></param>
    REM ''' <param name="sIndAcePnd"></param>
    REM ''' <param name="sIndVldCpf"></param>
    REM ''' <param name="sCodUndNgc"></param>
    REM ''' <param name="sTipFrmPgt"></param>
    REM ''' <param name="sNumReqAntCadRep"></param>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	12/23/2004	Adequacao dos valores de constantes Regiao de Cobranca (1) e Gerente de Transporte (2).
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function IsrDdoRepNvo(ByVal sNumReqCttRep As String, _
                                 ByVal pNumCpfRep As String, _
                                 ByVal pNumDocIdtRep As String, _
                                 ByVal pNomOrgEmsDocIdtRep As String, _
                                 ByVal pNomRep As String, _
                                 ByVal pDatSlc As String, _
                                 ByVal pDatEftFim As String, _
                                 ByVal pCodGerMcd As String, _
                                 ByVal pCodGerVnd As String, _
                                 ByVal pCodSitRep As String, _
                                 ByVal pTipRep As String, _
                                 ByVal pCodGrpVndRep As String, _
                                 ByVal pCodGerTrp As String, _
                                 ByVal pCodRegCob As String, _
                                 ByVal pCodSex As String, _
                                 ByVal pDatNscRep As String, _
                                 ByVal pNomNacRep As String, _
                                 ByVal pTipEstCvlRep As String, _
                                 ByVal pCodGraEclRep As String, _
                                 ByVal pTipSitEclRep As String, _
                                 ByVal pEndRep As String, _
                                 ByVal pCodBai As String, _
                                 ByVal pCodCplBai As String, _
                                 ByVal pCodEstUni As String, _
                                 ByVal pCodCidRep As String, _
                                 ByVal pCodCepRep As String, _
                                 ByVal pTipSitRsiRep As String, _
                                 ByVal pTipVtgRsiRep As String, _
                                 ByVal pTipSitTlfRep As String, _
                                 ByVal pNumTlfRep As String, _
                                 ByVal pNumTlfCelRep As String, _
                                 ByVal pTipSitFaxRep As String, _
                                 ByVal pNumFaxRep As String, _
                                 ByVal pTipSitRepCshReg As String, _
                                 ByVal pCodSgmMcd As String, _
                                 ByVal pNumInsInuNacSegSoc As String, _
                                 ByVal pNomDepRep As String, _
                                 ByVal pDatNscDep As String, _
                                 ByVal pNumDocIdt As String, _
                                 ByVal pNomOrgEmsDocIdtDep As String, _
                                 ByVal pQdeFlhRep As String, _
                                 ByVal pCodBcoRep As String, _
                                 ByVal pCodAgeBcoRep As String, _
                                 ByVal pCodCntCrrBcoRep As String, _
                                 ByVal pNumDigVrfAgeBcoRep As String, _
                                 ByVal pTipNatRep As String, _
                                 ByVal pDesAcoTrbRep As String, _
                                 ByVal pCodStaCadRep As String, _
                                 ByVal pNumRgtRepCshReg As String, _
                                 ByVal pDatRgtRepCshReg As String, _
                                 ByVal pCodEstUniCshReg As String, _
                                 ByVal pTipSitPesJurCshReg As String, _
                                 ByVal pQdeOcoRcm As String, _
                                 ByVal pVlrTotRcm As String, _
                                 ByVal pQdeOcoAcoCvl As String, _
                                 ByVal pQdeTitVncNaoPgo As String, _
                                 ByVal pQdeOcoChqSemFnd As String, _
                                 ByVal pDatUltOcoChqSemFnd As String, _
                                 ByVal pNomBcoUltChqSemFnd As String, _
                                 ByVal pDatHraRcbInfCrd As String, _
                                 ByVal pIndRtcCrd As String, _
                                 ByVal pIndAcePnd As String, _
                                 ByVal pIndVldCpf As String, _
                                 ByVal pCodUndNgc As String, _
                                 ByVal pNomUltChqSemFnd As String, _
                                 ByVal pTipFrmPgt As String, _
                                 ByVal sNumReqAntCadRep As String, _
                                 ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        ' Constantes 
        Dim CteGerTrp As Integer
        Dim CteCodRegCob As Integer
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            str.Append("INSERT INTO mrt.t0150415 (NUMREQCADREP, NUMCPFREP, NUMDOCIDTREP, ")
            str.Append("NOMORGEMSDOCIDTREP, NOMREP, DATSLC, DATEFTFIM, CODGERMCD, CODGERVND, ")
            str.Append("CODSITREP, TIPREP, CODGRPVNDREP, CODGERTRP, CODREGCOB, CODSEX, ")
            str.Append("DATNSCREP, NOMNACREP, TIPESTCVLREP, CODGRAECLREP, TIPSITECLREP, ENDREP, ")
            str.Append("CODBAI, CODCPLBAI, CODESTUNI, CODCIDREP, CODCEPREP, ")
            str.Append("TIPSITRSIREP, TIPVTGRSIREP, TIPSITTLFREP, NUMTLFREP, NUMTLFCELREP, ")
            str.Append("TIPSITFAXREP, NUMFAXREP, TIPSITREPCSHREG, CODSGMMCD, NUMINSINUNACSEGSOC, ")
            str.Append("NOMDEPREP, DATNSCDEP, NUMDOCIDT, NOMORGEMSDOCIDTDEP, QDEFLHREP, ")
            str.Append("CODBCOREP, CODAGEBCOREP, CODCNTCRRBCOREP, NUMDIGVRFAGEBCOREP, TIPNATREP, ")
            str.Append("DESACOTRBREP, CODSTACADREP, NUMRGTREPCSHREG, DATRGTREPCSHREG, CODESTUNICSHREG, ")
            str.Append("TIPSITPESJURCSHREG, QDEOCORCM, VLRTOTRCM, QDEOCOACOCVL, QDETITVNCNAOPGO, ")
            str.Append("QDEOCOCHQSEMFND, DATULTOCOCHQSEMFND, NOMBCOULTCHQSEMFND, DATHRARCBINFCRD, INDRTCCRD, ")
            str.Append("INDACEPND, INDVLDCPF, CODUNDNGC, NOMULTCHQSEMFND, TIPFRMPGT, NUMREQANTCADREP)")
            str.Append(" VALUES ( ")
            str.Append(sNumReqCttRep)
            str.Append("," & FunFrmCpo(pNumCpfRep))
            str.Append("," & FunFrmCpo(pNumDocIdtRep))
            str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtRep))
            str.Append("," & FunFrmCpo(pNomRep))
            str.Append("," + "CURRENT DATE")
            str.Append("," & FunFrmCpo(pDatEftFim))
            str.Append("," + pCodGerMcd)
            str.Append("," + pCodGerVnd)
            str.Append("," + pCodSitRep)
            str.Append("," + pTipRep)
            str.Append("," + pCodGrpVndRep)
            str.Append("," + pCodGerTrp)
            str.Append("," + pCodRegCob)
            str.Append("," & FunFrmCpo(pCodSex))
            str.Append("," & FunFrmCpo(pDatNscRep))
            str.Append("," & FunFrmCpo(pNomNacRep))
            str.Append("," & FunFrmCpo(pTipEstCvlRep))
            str.Append("," + pCodGraEclRep)
            str.Append("," & FunFrmCpo(pTipSitEclRep))
            str.Append("," & FunFrmCpo(pEndRep))
            str.Append("," + pCodBai)
            str.Append("," & FunFrmCpoInt(pCodCplBai))
            str.Append("," & FunFrmCpo(pCodEstUni))
            str.Append("," + pCodCidRep)
            str.Append("," + pCodCepRep)
            str.Append("," & FunFrmCpo(pTipSitRsiRep))
            str.Append("," + pTipVtgRsiRep)
            str.Append("," & FunFrmCpo(pTipSitTlfRep))
            str.Append("," & FunFrmCpo(pNumTlfRep))
            str.Append("," & FunFrmCpo(pNumTlfCelRep))
            str.Append("," & FunFrmCpo(pTipSitFaxRep))
            str.Append("," & FunFrmCpo(pNumFaxRep))
            str.Append("," & FunFrmCpo(pTipSitRepCshReg))
            str.Append("," + pCodSgmMcd)
            str.Append("," + pNumInsInuNacSegSoc)
            str.Append("," & FunFrmCpo(pNomDepRep))
            str.Append("," & FunFrmCpo(pDatNscDep))
            str.Append("," & FunFrmCpo(pNumDocIdt))
            str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtDep))
            str.Append("," + pQdeFlhRep)
            str.Append("," + pCodBcoRep)
            str.Append("," + pCodAgeBcoRep)
            str.Append("," & FunFrmCpo(pCodCntCrrBcoRep))
            str.Append("," & FunFrmCpo(pNumDigVrfAgeBcoRep))
            str.Append("," & FunFrmCpo(pTipNatRep))
            str.Append("," & FunFrmCpo(pDesAcoTrbRep))
            str.Append("," + pCodStaCadRep)
            str.Append("," & FunFrmCpo(pNumRgtRepCshReg))
            str.Append("," & FunFrmCpo(pDatRgtRepCshReg))
            str.Append("," & FunFrmCpo(pCodEstUniCshReg))
            str.Append("," & FunFrmCpo(pTipSitPesJurCshReg))
            str.Append("," + pQdeOcoRcm)
            str.Append("," + pVlrTotRcm)
            str.Append("," + pQdeOcoAcoCvl)
            str.Append("," + pQdeTitVncNaoPgo)
            str.Append("," + pQdeOcoChqSemFnd)
            str.Append("," & FunFrmCpo(pDatUltOcoChqSemFnd))
            str.Append("," & FunFrmCpo(pNomBcoUltChqSemFnd))
            str.Append("," & FunFrmCpo(pDatHraRcbInfCrd))
            str.Append("," + pIndRtcCrd)
            str.Append("," + pIndAcePnd)
            str.Append("," + pIndVldCpf)
            str.Append("," + pCodUndNgc)
            str.Append("," & FunFrmCpo(pNomUltChqSemFnd))
            str.Append("," & FunFrmCpo(pTipFrmPgt))
            str.Append("," + sNumReqAntCadRep)

            'str.Append("INSERT INTO mrt.t0150415 (NUMREQCADREP, NUMCPFREP, NUMDOCIDTREP, ")
            'str.Append("NOMORGEMSDOCIDTREP, NOMREP, DATSLC, DATEFTFIM, CODGERMCD, CODGERVND, ")
            'str.Append("CODSITREP, TIPREP, CODGRPVNDREP, CODGERTRP, CODREGCOB, CODSEX, ")
            'str.Append("DATNSCREP, NOMNACREP, TIPESTCVLREP, CODGRAECLREP, TIPSITECLREP, ENDREP, ")
            'str.Append("CODBAI, CODCPLBAI, CODESTUNI, CODCIDREP, CODCEPREP, ")
            'str.Append("TIPSITRSIREP, TIPVTGRSIREP, TIPSITTLFREP, NUMTLFREP, NUMTLFCELREP, ")
            'str.Append("TIPSITFAXREP, NUMFAXREP, TIPSITREPCSHREG, CODSGMMCD, NUMINSINUNACSEGSOC, ")
            'str.Append("NOMDEPREP, DATNSCDEP, NUMDOCIDT, NOMORGEMSDOCIDTDEP, QDEFLHREP, ")
            'str.Append("CODBCOREP, CODAGEBCOREP, CODCNTCRRBCOREP, NUMDIGVRFAGEBCOREP, TIPNATREP, ")
            'str.Append("DESACOTRBREP, CODSTACADREP, NUMRGTREPCSHREG, DATRGTREPCSHREG, CODESTUNICSHREG, ")
            'str.Append("TIPSITPESJURCSHREG, QDEOCORCM, VLRTOTRCM, QDEOCOACOCVL, QDETITVNCNAOPGO, ")
            'str.Append("QDEOCOCHQSEMFND, DATULTOCOCHQSEMFND, NOMBCOULTCHQSEMFND, DATHRARCBINFCRD, INDRTCCRD, ")
            'str.Append("INDACEPND, INDVLDCPF, CODUNDNGC, NOMULTCHQSEMFND, TIPFRMPGT, NUMREQANTCADREP)")
            'str.Append(" VALUES ( ")
            'str.Append(sNumReqCttRep)
            'str.Append("," & FunFrmCpo(pNumCpfRep))
            'str.Append("," & FunFrmCpo(pNumDocIdtRep))
            'str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtRep))
            'str.Append("," & FunFrmCpo(pNomRep))
            'str.Append("," + "CURRENT DATE")
            'str.Append("," & FunFrmCpo(pDatEftFim))
            'str.Append("," + pCodGerMcd)
            'str.Append("," + pCodGerVnd)
            'str.Append("," + pCodSitRep)
            'str.Append("," + pTipRep)
            'str.Append("," + pCodGrpVndRep)
            'str.Append("," + pCodGerTrp)
            'str.Append("," + pCodRegCob)
            'str.Append("," & FunFrmCpo(pCodSex))
            'str.Append("," & FunFrmCpo(pDatNscRep))
            'str.Append("," & FunFrmCpo(pNomNacRep))
            'str.Append("," & FunFrmCpo(pTipEstCvlRep))
            'str.Append("," + pCodGraEclRep)
            'str.Append("," & FunFrmCpo(pTipSitEclRep))
            'str.Append("," & FunFrmCpo(pEndRep))
            'str.Append("," + pCodBai)
            'str.Append("," & FunFrmCpoInt(pCodCplBai))
            'str.Append("," & FunFrmCpo(pCodEstUni))
            'str.Append("," + pCodCidRep)
            'str.Append("," + pCodCepRep)
            'str.Append("," & FunFrmCpo(pTipSitRsiRep))
            'str.Append("," + pTipVtgRsiRep)
            'str.Append("," & FunFrmCpo(pTipSitTlfRep))
            'str.Append("," & FunFrmCpo(pNumTlfRep))
            'str.Append("," & FunFrmCpo(pNumTlfCelRep))
            'str.Append("," & FunFrmCpo(pTipSitFaxRep))
            'str.Append("," & FunFrmCpo(pNumFaxRep))
            'str.Append("," & FunFrmCpo(pTipSitRepCshReg))
            'str.Append("," + pCodSgmMcd)
            'str.Append("," + pNumInsInuNacSegSoc)
            'str.Append("," & FunFrmCpo(pNomDepRep))
            'str.Append("," & FunFrmCpo(pDatNscDep))
            'str.Append("," & FunFrmCpo(pNumDocIdt))
            'str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtDep))
            'str.Append("," + pQdeFlhRep)
            'str.Append("," + pCodBcoRep)
            'str.Append("," + pCodAgeBcoRep)
            'str.Append("," & FunFrmCpo(pCodCntCrrBcoRep))
            'str.Append("," & FunFrmCpo(pNumDigVrfAgeBcoRep))
            'str.Append("," & FunFrmCpo(pTipNatRep))
            'str.Append("," & FunFrmCpo(pDesAcoTrbRep))
            'str.Append("," + pCodStaCadRep)
            'str.Append("," & FunFrmCpo(pNumRgtRepCshReg))
            'str.Append("," & FunFrmCpo(pDatRgtRepCshReg))
            'str.Append("," & FunFrmCpo(pCodEstUniCshReg))
            'str.Append("," & FunFrmCpo(pTipSitPesJurCshReg))
            'str.Append("," + pQdeOcoRcm)
            'str.Append("," + pVlrTotRcm)
            'str.Append("," + pQdeOcoAcoCvl)
            'str.Append("," + pQdeTitVncNaoPgo)
            'str.Append("," + pQdeOcoChqSemFnd)
            'str.Append("," & FunFrmCpo(pDatUltOcoChqSemFnd))
            'str.Append("," & FunFrmCpo(pNomBcoUltChqSemFnd))
            'str.Append("," & FunFrmCpo(pDatHraRcbInfCrd))
            'str.Append("," + pIndRtcCrd)
            'str.Append("," + pIndAcePnd)
            'str.Append("," + pIndVldCpf)
            'str.Append("," + pCodUndNgc)
            'str.Append("," & FunFrmCpo(pNomUltChqSemFnd))
            'str.Append("," & FunFrmCpo(pTipFrmPgt))
            'str.Append("," + sNumReqAntCadRep)
            'str.Append(")")

            'Conversão Oracle 16/02/06
            If pDatEftFim <> "NULL" Then
                pDatEftFim = "TO_DATE('" & pDatEftFim & "', 'YYYY-MM-DD')"
            End If
            If pDatNscRep <> "NULL" Then
                pDatNscRep = "TO_DATE('" & pDatNscRep & "', 'YYYY-MM-DD')"
            End If
            If pDatNscDep <> "NULL" Then
                pDatNscDep = "TO_DATE('" & pDatNscDep & "', 'YYYY-MM-DD')"
            End If
            If pDatRgtRepCshReg <> "NULL" Then
                pDatRgtRepCshReg = "TO_DATE('" & pDatRgtRepCshReg & "', 'YYYY-MM-DD')"
            End If
            If pDatUltOcoChqSemFnd <> "NULL" Then
                pDatUltOcoChqSemFnd = "TO_DATE('" & pDatUltOcoChqSemFnd & "', 'YYYY-MM-DD')"
            End If
            If pDatHraRcbInfCrd <> "NULL" Then
                pDatHraRcbInfCrd = "TO_CHAR('" & pDatHraRcbInfCrd & "', 'YYYY-MM-DD HH24:MI:SS.FF')"
            End If

            str.Append("INSERT INTO mrt.t0150415 (NUMREQCADREP, NUMCPFREP, NUMDOCIDTREP, ")
            str.Append("NOMORGEMSDOCIDTREP, NOMREP, DATSLC, DATEFTFIM, CODGERMCD, CODGERVND, ")
            str.Append("CODSITREP, TIPREP, CODGRPVNDREP, CODGERTRP, CODREGCOB, CODSEX, ")
            str.Append("DATNSCREP, NOMNACREP, TIPESTCVLREP, CODGRAECLREP, TIPSITECLREP, ENDREP, ")
            str.Append("CODBAI, CODCPLBAI, CODESTUNI, CODCIDREP, CODCEPREP, ")
            str.Append("TIPSITRSIREP, TIPVTGRSIREP, TIPSITTLFREP, NUMTLFREP, NUMTLFCELREP, ")
            str.Append("TIPSITFAXREP, NUMFAXREP, TIPSITREPCSHREG, CODSGMMCD, NUMINSINUNACSEGSOC, ")
            str.Append("NOMDEPREP, DATNSCDEP, NUMDOCIDT, NOMORGEMSDOCIDTDEP, QDEFLHREP, ")
            str.Append("CODBCOREP, CODAGEBCOREP, CODCNTCRRBCOREP, NUMDIGVRFAGEBCOREP, TIPNATREP, ")
            str.Append("DESACOTRBREP, CODSTACADREP, NUMRGTREPCSHREG, DATRGTREPCSHREG, CODESTUNICSHREG, ")
            str.Append("TIPSITPESJURCSHREG, QDEOCORCM, VLRTOTRCM, QDEOCOACOCVL, QDETITVNCNAOPGO, ")
            str.Append("QDEOCOCHQSEMFND, DATULTOCOCHQSEMFND, NOMBCOULTCHQSEMFND, DATHRARCBINFCRD, INDRTCCRD, ")
            str.Append("INDACEPND, INDVLDCPF, CODUNDNGC, NOMULTCHQSEMFND, TIPFRMPGT, NUMREQANTCADREP)")
            str.Append(" VALUES ( ")

            str.Append(sNumReqCttRep)

            str.Append("," & FunFrmCpo(pNumCpfRep))
            str.Append("," & FunFrmCpo(pNumDocIdtRep))
            str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtRep))
            str.Append("," & FunFrmCpo(pNomRep))
            str.Append("," + "TRUNC(SYSDATE)")
            str.Append("," & pDatEftFim)
            str.Append("," + pCodGerMcd)
            str.Append("," + pCodGerVnd)
            str.Append("," + pCodSitRep)
            str.Append("," + pTipRep)
            str.Append("," + pCodGrpVndRep)

            str.Append("," + pCodGerTrp)
            str.Append("," + pCodRegCob)

            str.Append("," & FunFrmCpo(pCodSex))
            str.Append("," & pDatNscRep)
            str.Append("," & FunFrmCpo(pNomNacRep))
            str.Append("," & FunFrmCpo(pTipEstCvlRep))
            str.Append("," + pCodGraEclRep)
            str.Append("," & FunFrmCpo(pTipSitEclRep))
            str.Append("," & FunFrmCpo(pEndRep))
            str.Append("," + pCodBai)
            str.Append("," & FunFrmCpoInt(pCodCplBai))
            str.Append("," & FunFrmCpo(pCodEstUni))
            str.Append("," + pCodCidRep)
            str.Append("," + pCodCepRep)
            str.Append("," & FunFrmCpo(pTipSitRsiRep))
            str.Append("," + pTipVtgRsiRep)
            str.Append("," & FunFrmCpo(pTipSitTlfRep))
            str.Append("," & FunFrmCpo(pNumTlfRep))
            str.Append("," & FunFrmCpo(pNumTlfCelRep))
            str.Append("," & FunFrmCpo(pTipSitFaxRep))
            str.Append("," & FunFrmCpo(pNumFaxRep))
            str.Append("," & FunFrmCpo(pTipSitRepCshReg))
            str.Append("," + pCodSgmMcd)
            str.Append("," + pNumInsInuNacSegSoc)
            str.Append("," & FunFrmCpo(pNomDepRep))
            str.Append("," & pDatNscDep)
            str.Append("," & FunFrmCpo(pNumDocIdt))
            str.Append("," & FunFrmCpo(pNomOrgEmsDocIdtDep))
            str.Append("," + pQdeFlhRep)
            str.Append("," + pCodBcoRep)
            str.Append("," + pCodAgeBcoRep)
            str.Append("," & FunFrmCpo(pCodCntCrrBcoRep))
            str.Append("," & FunFrmCpo(pNumDigVrfAgeBcoRep))
            str.Append("," & FunFrmCpo(pTipNatRep))
            str.Append("," & FunFrmCpo(pDesAcoTrbRep))
            str.Append("," + pCodStaCadRep)
            str.Append("," & FunFrmCpo(pNumRgtRepCshReg))
            str.Append("," & pDatRgtRepCshReg)
            str.Append("," & FunFrmCpo(pCodEstUniCshReg))
            str.Append("," & FunFrmCpo(pTipSitPesJurCshReg))
            str.Append("," + pQdeOcoRcm)
            str.Append("," + pVlrTotRcm)
            str.Append("," + pQdeOcoAcoCvl)
            str.Append("," + pQdeTitVncNaoPgo)
            str.Append("," + pQdeOcoChqSemFnd)
            str.Append("," & pDatUltOcoChqSemFnd)
            str.Append("," & FunFrmCpo(pNomBcoUltChqSemFnd))
            str.Append("," & pDatHraRcbInfCrd)
            str.Append("," + pIndRtcCrd)
            str.Append("," + pIndAcePnd)
            str.Append("," + pIndVldCpf)
            str.Append("," + pCodUndNgc)
            str.Append("," & FunFrmCpo(pNomUltChqSemFnd))
            str.Append("," & FunFrmCpo(pTipFrmPgt))
            str.Append("," + sNumReqAntCadRep)
            str.Append(")")

            str.Append(")")
            sCmdSql = str.ToString()
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region " --------------- Insere Dados na Tabela de Alteração de status ------------------"
    Public Function IsrDdoAltSta(ByVal sCodStaCadRep As String, ByVal sNumReqCttRep As String, ByVal sNomUsrUltAlt As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            '  sCmdSql = " INSERT INTO MRT.T0150350 (CODSTACADREP,NUMREQCADREP, DATHRAULTALT, NOMUSRULTALT) " + _
            '"  VALUES (" + sCodStaCadRep + "," + sNumReqCttRep + ", CURRENT TIMESTAMP, '" + sNomUsrUltAlt + "')"

            'Conversão Oracle 16/02/06
            sCmdSql = " INSERT INTO MRT.T0150350 (CODSTACADREP,NUMREQCADREP, DATHRAULTALT, NOMUSRULTALT) " + _
                      "  VALUES (" + sCodStaCadRep + "," + sNumReqCttRep + ", SYSTIMESTAMP, '" + sNomUsrUltAlt + "')"

            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            Throw
        Finally
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "----------------- Insere Dados na Tabela de Territórios do Representante ------------------"
    Public Function IsrDdoTetRep(ByVal sCodTetVnd As String, _
                                 ByVal sNumReqCttRep As String, _
                                 ByVal sAnoMesRef As String, _
                                 ByVal sVlrVndTet As String, _
                                 ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim iNumRgt As Integer
        Dim strVlr As String
        Dim FrmNumSql As String
        Try
            'Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US", False)
            If VB6.Format(1, "0.00") = "1,00" Then
                strVlr = Replace(sVlrVndTet, ".", "@")
                strVlr = Replace(strVlr, ",", ".")
                FrmNumSql = Replace(strVlr, "@", "")
            Else
                FrmNumSql = Replace(sVlrVndTet, ",", "")
            End If

            'insere na tabela de territorios de venda
            sCmdSql = " INSERT INTO MRT.T0150377 (CODTETVND, NUMREQCADREP, ANOMESREF, VLRVNDTET) " + _
                      " VALUES (" + sCodTetVnd + ", " + sNumReqCttRep + ", " + sAnoMesRef + ", " + FrmNumSql + ")"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region "----------------- Insere Dados na Tabela de Avaliações do Representante ------------------- "
    Public Function IsrDdoAvlRep(ByVal sNumReqCadRep As String, ByVal sCodAvlRep As String, ByVal sDesCdoAvlRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            'insere na tabela temporária de representantes
            sCmdSql = " INSERT INTO MRT.T0150466 (NUMREQCADREP,CODAVLREP,DESCDOAVLREP) " + _
                      " VALUES(" + sNumReqCadRep + "," + sCodAvlRep + ",'" + sDesCdoAvlRep + "')"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try
    End Function
#End Region

#Region "----------------- Insere Dados na Tabela de Competências do Representante ------------------- "

    Public Function IsrDdoCtnRep(ByVal sNumReqCadRep As String, ByVal sCodCtnRep As String, ByVal sVlrCtnRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim iNumRgt As Integer

        Try
            sCmdSql = " INSERT INTO MRT.T0150652 (NUMREQCADREP,CODCTNREP,VLRCTNREP) " + _
                      " VALUES(" + sNumReqCadRep + "," + sCodCtnRep + "," + sVlrCtnRep + ")"

            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            Throw
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Dados do Representante na Tabela de Representantes ------------------"
    Public Function IsrDdoRepTabRep(ByVal sCodRep As String, ByVal sNomRep As String, ByVal sEndRep As String, _
                               ByVal sNumTlfRep As String, ByVal sNumDocIdtRep As String, ByVal sCodSup As String, ByVal sCodGrpVndRep As String, _
                               ByVal sTipRep As String, ByVal sFlgPgtCmsRep As String, ByVal sCodRegCob As String, ByVal sCodGerTrp As String, _
                               ByVal sCodCidRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, ByVal sNumDigVrfAgeBcoRep As String, _
                               ByVal sCodCepRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCpfRep As String, ByVal sDatNscRep As String, _
                               ByVal sCodEstUniCshReg As String, ByVal sCodSgmMcd As String, ByVal sDatRgtRepCshReg As String, _
                               ByVal sNumRgtRepCshReg As String, ByVal sTipNatRep As String, ByVal sTipSitPesJurCshReg As String, ByVal sNomOrgEmsDocIdtRep As String, _
                               ByVal sCodGraEclRep As String, ByVal sTipSitEclRep As String, ByVal sTipVtgRsiRep As String, ByVal sTipSitRsiRep As String, _
                               ByVal sTipSitTlfRep As String, ByVal sNumFaxRep As String, ByVal sTipSitFaxRep As String, ByVal sQdeFlhRep As String, ByVal sTipSitRepCshReg As String, _
                               ByVal sCodSex As String, ByVal sNomNacRep As String, ByVal sTipEstCvlRep As String, ByVal sCodPswRepTmk As String, _
                               ByVal sCodPswRepLivPco As String, ByVal sCodSgmMcdCop As String, ByVal sNumInsInuNacSegSoc As String, ByVal sNumTlfCelRep As String, _
                               ByVal sCodSitRep As String, ByVal sCodUndNgc As String, ByVal sCodBai As String, ByVal sCodCplBai As String, _
                               ByVal sTipFrmPgt As String, ByVal sDatIniPtcCalPro As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            'insere na tabela de representantes
            sCmdSql = " INSERT INTO MRT.T0100116(" + _
                      "     CODREP, NOMREP, ENDREP, NUMTLFREP, NUMDOCIDTREP, CODSUP, CODGRPVNDREP, " + _
                      "     FLGDSTREP, DATDSTREP, DATCADREP, TIPREP, FLGPGTCMSREP, CODLIVPCO, CODREGCOB, " + _
                      "     CODGERTRP, CODCIDREP, CODBCOREP, CODAGEBCOREP, NUMDIGVRFAGEBCOREP, CODCEPREP, " + _
                      "     NUMCGCEMPREP, CODCNTCRRBCOREP, NUMCPFREP, DATNSCREP, DATULTTNMREP, NOMEMPREP, " + _
                      "     TIPFRMPGT, TIPCNTCRRREP, CODMTVDSTEDEVND, TIPACECMSREP, CODESTUNICSHREG, " + _
                      "     CODSGMMCD, DATRGTREPCSHREG, NUMRGTREPCSHREG, TIPNATREP, TIPSITPESJURCSHREG, " + _
                      "     NOMORGEMSDOCIDTREP, CODGRAECLREP, TIPSITECLREP, TIPVTGRSIREP, TIPSITRSIREP, " + _
                      "     TIPSITTLFREP, NUMFAXREP, TIPSITFAXREP, QDEFLHREP, DATACEFIMREP, TIPSITREPCSHREG, " + _
                      "     CODSEX, NOMNACREP, TIPESTCVLREP, VLRSLDBLQREP, CODPSWREPTMK, CODPSWREPLIVPCO, " + _
                      "     DATALTPSWTMK, DATRCBLPTREP, DATDVLLPTREP, DATINIPTCCALPRO, PERPVTVNDREP, CODSGMMCDCOP, " + _
                      "     NUMINSINUNACSEGSOC, DATASNCTTREP, NUMTLFCELREP, PERBLQCMSREPENVRBO, PERBLQCMSREPCOBESP, " + _
                      "     ENDEMPREP, CODBAIEMPREP, CODCPLBAIEMPREP, CODCEPEMPREP, CODSITREP, QDEDIASEMPED, " + _
                      "     NUMCADMNCCRB, DATULTPEDLPT, DATULTPEDREP, CODUNDNGC, CODBAI, CODCPLBAI, CODEMP, " + _
                      "     CODCTBREP, FLGDSCATPFATCRGREP, NUMDIGVRFCODCTBREP, FLGLIBBLQSLDREP, FLGTRNLPT, " + _
                      "     CODGRPAFD, QDECLIEVLREP, FLGLIBINFPTOETN, TIPEQPIFR, CODGIRNGCCTT, FLGLIBBLQCMSENVRBO, " + _
                      "     FLGLIBBLQCMSCOBESP, VLRLIMCRDORDPGT, FLGTIPFLXDINREP, VLRSLDULTENVORDPGT, VLRSLDDISENVORDPGT, TIPUTZVNDSMP)"

            'sCmdSql = sCmdSql + _
            '          " VALUES ( " + sCodRep + ", " + FunFrmCpo(sNomRep) + ", " + FunFrmCpo(sEndRep) + ", " + _
            '                    FunFrmCpo(sNumTlfRep) + ", " + FunFrmCpo(sNumDocIdtRep) + ", " + sCodSup + ", " + sCodGrpVndRep + ", " + _
            '                    " ' ', NULL, CURRENT DATE," + sTipRep + ", " + _
            '                    FunFrmCpo(sFlgPgtCmsRep) + ", NULL, " + sCodRegCob + ", " + sCodGerTrp + ", " + _
            '                    sCodCidRep + ", " + sCodBcoRep + ", " + sCodAgeBcoRep + ", " + FunFrmCpo(sNumDigVrfAgeBcoRep) + ", " + _
            '                    sCodCepRep + ", NULL," + FunFrmCpo(sCodCntCrrBcoRep    ) + ", " + FunFrmCpo(sNumCpfRep) + ", " + _
            '                    FunFrmCpo(sDatNscRep) + ", NULL, NULL, " + FunFrmCpo(sTipFrmPgt) + ", " + _
            '                    " 'F', NULL, 'E', " + FunFrmCpo(sCodEstUniCshReg) + ", " + _
            '                    sCodSgmMcd + ", " + FunFrmCpo(sDatRgtRepCshReg) + ", " + FunFrmCpo(sNumRgtRepCshReg) + ", " + FunFrmCpo(sTipNatRep) + ", " + _
            '                    FunFrmCpo(sTipSitPesJurCshReg) + ", " + FunFrmCpo(sNomOrgEmsDocIdtRep) + ", " + sCodGraEclRep + ", " + FunFrmCpo(sTipSitEclRep) + ", " + _
            '                    sTipVtgRsiRep + ", " + FunFrmCpo(sTipSitRsiRep) + ", " + FunFrmCpo(sTipSitTlfRep) + ", " + FunFrmCpo(sNumFaxRep) + ", " + _
            '                    FunFrmCpo(sTipSitFaxRep) + ", " + sQdeFlhRep + ", NULL," + FunFrmCpo(sTipSitRepCshReg) + ", " + _
            '                    FunFrmCpo(sCodSex) + ", " + FunFrmCpo(sNomNacRep) + ", " + FunFrmCpo(sTipEstCvlRep) + ",0," + _
            '                    sCodPswRepTmk + ", " + sCodPswRepLivPco + ",CURRENT DATE + 30 DAYS,NULL," + _
            '                    "NULL, " + FunFrmCpo(sDatIniPtcCalPro) + ", 0," + sCodSgmMcdCop + ", " + _
            '                    sNumInsInuNacSegSoc + ",NULL," + FunFrmCpo(sNumTlfCelRep) + ",0,0,NULL,NULL,NULL," + _
            '                    "NULL," + sCodSitRep + ",0,NULL,'0001-01-01',NULL," + _
            '                    sCodUndNgc + ", " + sCodBai + ", " + _
            '                    FunFrmCpoInt(sCodCplBai) + ", 1, 0,' ', 0, ' ', ' ', 0, 0, '0', 0, 0,' ', ' ', 0, ' ', 0, 0)"

            'Conversão Oracle 16/02/06
            If sDatNscRep <> "NULL" Then
                sDatNscRep = "TO_DATE('" & sDatNscRep & "', 'YYYY-MM-DD')"
            End If
            If sDatRgtRepCshReg <> "NULL" Then
                sDatRgtRepCshReg = "TO_DATE('" & sDatRgtRepCshReg & "', 'YYYY-MM-DD')"
            End If
            If sDatIniPtcCalPro <> "NULL" Then
                sDatIniPtcCalPro = "TO_DATE('" & sDatIniPtcCalPro & "', 'YYYY-MM-DD')"
            End If

            sCmdSql = sCmdSql + _
                      " VALUES ( " + sCodRep + ", " + FunFrmCpo(sNomRep) + ", " + FunFrmCpo(sEndRep) + ", " + _
                                FunFrmCpo(sNumTlfRep) + ", " + FunFrmCpo(sNumDocIdtRep) + ", " + sCodSup + ", " + sCodGrpVndRep + ", " + _
                                " ' ', NULL, TRUNC(SYSDATE)," + sTipRep + ", " + _
                                FunFrmCpo(sFlgPgtCmsRep) + ", NULL, " + sCodRegCob + ", " + sCodGerTrp + ", " + _
                                sCodCidRep + ", " + sCodBcoRep + ", " + sCodAgeBcoRep + ", " + FunFrmCpo(sNumDigVrfAgeBcoRep) + ", " + _
                                sCodCepRep + ", NULL," + FunFrmCpo(sCodCntCrrBcoRep) + ", " + FunFrmCpo(sNumCpfRep) + ", " + _
                                sDatNscRep + ", NULL, NULL, " + FunFrmCpo(sTipFrmPgt) + ", " + _
                                " 'F', NULL, 'E', " + FunFrmCpo(sCodEstUniCshReg) + ", " + _
                                sCodSgmMcd + ", " + sDatRgtRepCshReg + ", " + FunFrmCpo(sNumRgtRepCshReg) + ", " + FunFrmCpo(sTipNatRep) + ", " + _
                                FunFrmCpo(sTipSitPesJurCshReg) + ", " + FunFrmCpo(sNomOrgEmsDocIdtRep) + ", " + sCodGraEclRep + ", " + FunFrmCpo(sTipSitEclRep) + ", " + _
                                sTipVtgRsiRep + ", " + FunFrmCpo(sTipSitRsiRep) + ", " + FunFrmCpo(sTipSitTlfRep) + ", " + FunFrmCpo(sNumFaxRep) + ", " + _
                                FunFrmCpo(sTipSitFaxRep) + ", " + sQdeFlhRep + ", NULL," + FunFrmCpo(sTipSitRepCshReg) + ", " + _
                                FunFrmCpo(sCodSex) + ", " + FunFrmCpo(sNomNacRep) + ", " + FunFrmCpo(sTipEstCvlRep) + ",0," + _
                                sCodPswRepTmk + ", " + sCodPswRepLivPco + ", TRUNC(SYSDATE + 30),NULL," + _
                                "NULL, " + sDatIniPtcCalPro + ", 0," + sCodSgmMcdCop + ", " + _
                                sNumInsInuNacSegSoc + ",NULL," + FunFrmCpo(sNumTlfCelRep) + ",0,0,NULL,NULL,NULL," + _
                                "NULL," + sCodSitRep + ",0,NULL,TO_DATE('0001-01-01','YYYY-MM-DD'),NULL," + _
                                sCodUndNgc + ", " + sCodBai + ", " + _
                                FunFrmCpoInt(sCodCplBai) + ", 1, 0,' ', 0, ' ', ' ', 0, 0, '0', 0, 0,' ', ' ', 0, ' ', 0, 0, " + _
                                " case when 4 in (select ARE.CODAREVND from MRT.T0100124 SUP " + _
                                " inner join MRT.T0100051 GER on SUP.CODGER = GER.CODGER " + _
                                " inner join MRT.T0133650 ARE on GER.CODGER = ARE.CODGER " + _
                                " where SUP.CODSUP = " & sCodSup & ") then 'S' else 'M' end) "

            'Valores
            'sCmdSql = sCmdSql + _
            '          " VALUES (" + sNumReqCttRep + ",'" + sNumCpfRep + "','" + sNumDocIdtRep + "','" + _
            '              sNomOrgEmsDocIdtRep + "','" + sNomRep + "',CURRENT DATE,'0001-01-01', " + _
            '              sCodGerMcd + "," + sCodGerVnd + " ,0,1,1,0, " + _
            '              "0, '" + sCodSex + "','" + sDatNscRep + "','" + sNomAcsRep + "','" + sTipEstCvlRep + "'," + sCodGraEclRep + ",'" + _
            '              sTipSitEclRep + "','" + sEndRep + "'," + sCodBai + "," + sCodCplBai + "," + sCodCidRep + "," + sCodCepRep + ",'" + sTipSitRsiRep + "'," + _
            '              sTipVtgRsiRep + ",'" + sTipSitTlfRep + "','" + sNumTlfRep + "','" + sNumTlfCelRep + "','" + sTipSitFaxRep + "','" + sNumFaxRep + "'," + _
            '              "'PF'," + sCodSgmMcd + "," + sNumInsInuNacSegSoc + ",'" + sNomDepRep + "','" + sDatNscDep + "','" + sNumDocIdt + "','" + _
            '              sNomOrgEmsDocIdtDep + "'," + sQdeFlhRep + "," + sCodBcoRep + "," + sCodAgeBcoRep + ",'" + sCodCntCrrBcoRep + "','" + _
            '              sNumDigVrfAgeBcoRep + "','" + sTipNatRep + "','" + sDesAcoTrbRep + "'," + sCodStaCadRep + ",'" + sDatRgtRepCshReg + "','" + _
            '              sCodEstUniCshReg + "','" + sTipSitPesJurCshReg + "','" + sCodEstUni & "'," & sIndAcePnd & "," & sIndVldCpf & "," & sCodUndNgc & ",'" & sNumRgtRepCshRep & "')"


            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region "  --------------- Insere Situação do Representante ------------------"
    Public Function IsrSitRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                              ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                              ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                              ByVal sNomEmpRep As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                              ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                              ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                              ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, _
                              ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        If sTipNatRep.Trim = "" Then
            sTipNatRep = "NULL"
        Else
            sTipNatRep = "'" & sTipNatRep & "'"
        End If
        If sNumDigVrfAgeBcoRep.Trim = "" Then
            sNumDigVrfAgeBcoRep = "NULL"
        Else
            sNumDigVrfAgeBcoRep = "'" & sNumDigVrfAgeBcoRep & "'"
        End If
        If sCodCntCrrBcoRep.Trim = "" Then
            sCodCntCrrBcoRep = "NULL"
        Else
            sCodCntCrrBcoRep = "'" & sCodCntCrrBcoRep & "'"
        End If
        If sNumCgcEmpRep.Trim = "" Then
            sNumCgcEmpRep = "NULL"
        Else
            sNumCgcEmpRep = "'" & sNumCgcEmpRep & "'"
        End If
        If sNomEmpRep.Trim = "" Then
            sNomEmpRep = "NULL"
        Else
            sNomEmpRep = "'" & sNomEmpRep & "'"
        End If
        If sEndEmpRep.Trim = "" Then
            sEndEmpRep = "NULL"
        Else
            sEndEmpRep = "'" & sEndEmpRep & "'"
        End If
        If sCodBaiEmpRep.Trim = "" Then
            sCodBaiEmpRep = "NULL"
        End If
        If sCodCplBaiEmpRep.Trim = "" Then
            sCodCplBaiEmpRep = "NULL"
        End If
        If sCodCepEmpRep.Trim = "" Then
            sCodCepEmpRep = "NULL"
        End If
        If sDatAsnCttRep.Trim = "" Then
            sDatAsnCttRep = "NULL"
        Else
            sDatAsnCttRep = "TO_DATE('" & sDatAsnCttRep & "','YYYY-MM-DD')"
        End If
        If sDatCadFilEmp.Trim = "" Then
            sDatCadFilEmp = "NULL"
        Else
            sDatCadFilEmp = "TO_DATE('" & sDatCadFilEmp & "','YYYY-MM-DD')"
        End If
        If sDatRgtRepCshReg = "NULL" Then
            sDatRgtRepCshReg = "0001-01-01"
        End If

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'insere na tabela temporária de representantes

            'sCmdSql = " INSERT INTO MRT.T0123949 (CODREP,DATHRAREF,CODSITREP) " + _
            '          "  VALUES (" + sCodRep + ", CURRENT TIMESTAMP, " + sCodSitRep + ")"

            'Conversão Oracle 16/02/06
            str.Append("INSERT INTO MRT.T0123949 (")
            str.Append("CODREP, DATHRAREF, CODSITREP, TIPSITPESJURCSHREG, TIPNATREP, CODBCOREP, CODAGEBCOREP, NUMDIGVRFAGEBCOREP,")
            str.Append("CODCNTCRRBCOREP, NUMCGCEMPREP, NOMEMPREP, ENDEMPREP, CODBAIEMPREP, CODCPLBAIEMPREP, CODCEPEMPREP, NUMRGTREPCSHREG,")
            str.Append("CODESTUNICSHREG, TIPSITREPCSHREG, DATRGTREPCSHREG, DATASNCTTREP, DATCADFILEMP, CODSUP, DATHRAALT)")
            str.Append(" VALUES (")
            str.Append(sCodRep & ",")
            str.Append("SYSDATE,")
            str.Append(sCodSitRep & ",")
            str.Append("'" & sTipSitPesJurCshReg & "',")
            str.Append(sTipNatRep & ",")
            str.Append(sCodBcoRep & ",")
            str.Append(sCodAgeBcoRep & ",")
            str.Append(sNumDigVrfAgeBcoRep & ",")
            str.Append(sCodCntCrrBcoRep & ",")
            str.Append(sNumCgcEmpRep & ",")
            str.Append(sNomEmpRep & ",")
            str.Append(sEndEmpRep & ",")
            str.Append(sCodBaiEmpRep & ",")
            str.Append(sCodCplBaiEmpRep & ",")
            str.Append(sCodCepEmpRep & ",")
            str.Append(FunFrmCpo(sNumRgtRepCshReg) & ",")
            str.Append(FunFrmCpo(sCodEstUniCshReg) & ",")
            str.Append(FunFrmCpo(sTipSitRepCshReg) & ",")
            str.Append("TO_DATE('" & sDatRgtRepCshReg & "','YYYY-MM-DD'),")
            str.Append(sDatAsnCttRep & ",")
            str.Append(sDatCadFilEmp & ",")
            str.Append(sCodSup & ",")
            str.Append("SYSTIMESTAMP)")

            sCmdSql = str.ToString
            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Tabela Complementar de Representante ------------------"
    Public Function IsrTabCplRep(ByVal sDatPrvCrdRsvRep As String, ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'insere na tabela temporária de representantes

            'sCmdSql = " INSERT INTO MRT.T0118678 (CODREP,VLRSLDRSVREPNVO,DATPRVCRDRSVREP) " + _
            '          "  VALUES (" + sCodRep + ", 0, '" + sDatPrvCrdRsvRep + "')"

            'Conversão Oracle 16/02/06
            sCmdSql = " INSERT INTO MRT.T0118678 (CODREP,VLRSLDRSVREPNVO,DATPRVCRDRSVREP) " + _
                      "  VALUES (" + sCodRep + ", 0, TO_DATE('" + sDatPrvCrdRsvRep + "','YYYY-MM-DD'))"


            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Dependente do Representante ------------------"
    Public Function IsrDepRep(ByVal sCodRep As String, ByVal sNomDep As String, ByVal sDatNscDep As String, ByVal sNumDocIdtDep As String, ByVal sNomOrgEmsIdtDep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'insere na tabela temporária de representantes

            'sCmdSql = " INSERT INTO MRT.T0107315 (CODREP,NOMDEPREP,CODGRAPARREP,DATNSCDEP,NUMDOCIDT,NOMORGEMSDOCIDTDEP) " + _
            '          " VALUES (" + _
            '            sCodRep + ", '" + sNomDep + "', 2, '" + sDatNscDep + "', " + _
            '          " '" + sNumDocIdtDep + "', '" + sNomOrgEmsIdtDep + "')"

            'Conversão Oracle 16/02/06
            sCmdSql = " INSERT INTO MRT.T0107315 (CODREP,NOMDEPREP,CODGRAPARREP,DATNSCDEP,NUMDOCIDT,NOMORGEMSDOCIDTDEP) " + _
                      " VALUES (" + _
                        sCodRep + ", '" + sNomDep + "', 2, TO_DATE('" + sDatNscDep + "','YYYY-MM-DD'), " + _
                      " '" + sNumDocIdtDep + "', '" + sNomOrgEmsIdtDep + "')"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Insere Territorio do Representante ------------------"
    Public Function IsrTetRep(ByVal sCodTet As String, ByVal sCodFncAnt As String, ByVal sCodFncRpn As String, ByVal sCodFncAltEde As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try


            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'insere na tabela temporária de representantes

            'sCmdSql = " INSERT INTO MRT.T0133693 (TIPEDE, CODEDE, DATHRAGRCHST, CODFNCRPNANT, CODFNCRPN, CODFNCRPNALTEDE) " + _
            '          " VALUES (26, " + _
            '            sCodTet + ", CURRENT TIMESTAMP, " + sCodFncAnt + ", " + sCodFncRpn + ", " + sCodFncAltEde + ")"

            'Conversão Oracle 16/02/06
            sCmdSql = " INSERT INTO MRT.T0133693 (TIPEDE, CODEDE, DATHRAGRCHST, CODFNCRPNANT, CODFNCRPN, CODFNCRPNALTEDE) " + _
                      " VALUES (26, " + _
                        sCodTet + ", SYSTIMESTAMP, " + sCodFncAnt + ", " + sCodFncRpn + ", " + sCodFncAltEde + ")"

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Altera Dados na Tabela de Descrição de Observações ------------------"
    Public Function AltDdoDesObs(ByVal sNumReqCadRep As String, ByVal sCodSeqObs As String, ByVal sDesObs As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo

        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'insere na tabela de observações 
            sCmdSql = " update mrt.t0150610 set DESOBS = '" & sDesObs & "'" & _
                      " where NUMREQCADREP = " & sNumReqCadRep & " and CODSEQOBS = " & sCodSeqObs

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " ---------------- Altera Dados da Tabela Temporária de Representantes ------------------"
    Public Function AltDdoRep(ByVal sNumReqCttRep As String, ByVal sNumCpfRep As String, ByVal sNumDocIdtRep As String, _
                               ByVal sNomOrgEmsDocIdtRep As String, ByVal sNomRep As String, ByVal sCodGerMcd As String, _
                               ByVal sCodGerVnd As String, ByVal sCodSex As String, ByVal sDatNscRep As String, ByVal sNomAcsRep As String, _
                               ByVal sTipEstCvlRep As String, ByVal sCodGraEclRep As String, ByVal sTipSitEclRep As String, ByVal sEndRep As String, _
                               ByVal sCodBai As String, ByVal sCodCplBai As String, ByVal sCodCidRep As String, ByVal sCodCepRep As String, ByVal sTipSitRsiRep As String, _
                               ByVal sTipVtgRsiRep As String, ByVal sTipSitTlfRep As String, ByVal sNumTlfRep As String, ByVal sNumTlfCelRep As String, ByVal sTipSitFaxRep As String, _
                               ByVal sNumFaxRep As String, ByVal sCodSgmMcd As String, ByVal sNumInsInuNacSegSoc As String, _
                               ByVal sNomDepRep As String, ByVal sDatNscDep As String, ByVal sNumDocIdt As String, ByVal sNomOrgEmsDocIdtDep As String, _
                               ByVal sQdeFlhRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, _
                               ByVal sNumDigVrfAgeBcoRep As String, ByVal sTipNatRep As String, ByVal sDesAcoTrbRep As String, _
                               ByVal sCodStaCadRep As String, ByVal sDatRgtRepCshReg As String, ByVal sCodEstUniCshReg As String, _
                               ByVal sTipSitRepCshReg As String, ByVal sTipSitPesJurCshReg As String, ByVal sCodEstUni As String, ByVal sNumRgtRepCshRep As String, _
                               ByVal sIndAcePnd As String, ByVal sIndVldCpf As String, ByVal sCodUndNgc As String, _
                               ByVal sTipFrmPgt As String, ByVal sIndRtcCrd As String, _
                               ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            'Dim strLock As System.Text.StringBuilder = New System.Text.StringBuilder
            'strLock.Append(" LOCK TABLE mrt.t0150415 IN EXCLUSIVE MODE ")
            '' Aplica Lock Exclusivo na tabela
            'sCmdSql = strLock.ToString()
            ''executa consulta
            'oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            'oObeAcsDdo.ExcCmdSql(iNumRgt)

            'altera dados na tabela temporária de representantes

            'sCmdSql = " UPDATE MRT.T0150415 " & _
            '        " SET NUMDOCIDTREP = '" & sNumDocIdtRep & "', NOMORGEMSDOCIDTREP = " & FunFrmCpo(sNomOrgEmsDocIdtRep) & "," & _
            '        "     NOMREP = " & FunFrmCpo(sNomRep) & ", CODSEX = " & FunFrmCpo(sCodSex) & ", DATNSCREP = " & FunFrmCpo(sDatNscRep) & ", NOMNACREP = " & FunFrmCpo(sNomAcsRep) & "," & _
            '        "     TIPESTCVLREP = " & FunFrmCpo(sTipEstCvlRep) & ", CODGRAECLREP =" & sCodGraEclRep & ", TIPSITECLREP =" & FunFrmCpo(sTipSitEclRep) & ", " & _
            '        "     ENDREP = " & FunFrmCpo(sEndRep) & ", CODBAI = " & sCodBai & ", CODCPLBAI = " & sCodCplBai & ", CODESTUNI = " & FunFrmCpo(sCodEstUni) & ", " & _
            '        "     CODCIDREP = " & sCodCidRep & ", CODCEPREP = " & sCodCepRep & ", TIPSITRSIREP =" & FunFrmCpo(sTipSitRsiRep) & ", " & _
            '        "     TIPVTGRSIREP = " & sTipVtgRsiRep & ", TIPSITTLFREP =" & FunFrmCpo(sTipSitTlfRep) & " ," & _
            '        "     NUMTLFREP = " & FunFrmCpo(sNumTlfRep) & ", NUMTLFCELREP =" & FunFrmCpo(sNumTlfCelRep) & ", TIPSITFAXREP =" & FunFrmCpo(sTipSitFaxRep) & ", " & _
            '        "     NUMFAXREP = " & FunFrmCpo(sNumFaxRep) & ", CODSGMMCD = " & sCodSgmMcd & ", NUMINSINUNACSEGSOC=" & FunFrmCpoInt(sNumInsInuNacSegSoc) & "," & _
            '        "     NOMDEPREP = " & FunFrmCpo(sNomDepRep) & ", DATNSCDEP = " & FunFrmCpo(sDatNscDep) & ", NUMDOCIDT = " & FunFrmCpo(sNumDocIdt) & ", " & _
            '        "     NOMORGEMSDOCIDTDEP = " & FunFrmCpo(sNomOrgEmsDocIdtDep) & ", QDEFLHREP = " & sQdeFlhRep & ", CODBCOREP = " & sCodBcoRep & ", " & _
            '        "     CODAGEBCOREP = " & sCodAgeBcoRep & ", CODCNTCRRBCOREP = " & FunFrmCpo(sCodCntCrrBcoRep) & ", NUMDIGVRFAGEBCOREP = " & FunFrmCpo(sNumDigVrfAgeBcoRep) & ", " & _
            '        "     CODSTACADREP = " & sCodStaCadRep & ", NUMRGTREPCSHREG = " & FunFrmCpo(sNumRgtRepCshRep) & ", DATRGTREPCSHREG = " & FunFrmCpo(sDatRgtRepCshReg) & ", " & _
            '        "     CODESTUNICSHREG = " & FunFrmCpo(sCodEstUniCshReg) & ", TIPSITREPCSHREG = " & FunFrmCpo(sTipSitRepCshReg) & ", " & _
            '        "     TIPSITPESJURCSHREG = " & FunFrmCpo(sTipSitPesJurCshReg) & ", " & _
            '        "     INDACEPND = " & sIndAcePnd & ", INDVLDCPF = " & sIndVldCpf & ", CODUNDNGC = " & sCodUndNgc & ", " & _
            '        "     TIPFRMPGT = " & FunFrmCpo(sTipFrmPgt) & ",  INDRTCCRD=" & sIndRtcCrd & _
            '        "     WHERE NUMREQCADREP = " & sNumReqCttRep

            'Conversão Oracle 16/02/06
            If sDatNscRep <> "NULL" Then
                sDatNscRep = "TO_DATE('" & sDatNscRep & "', 'YYYY-MM-DD')"
            End If
            If sDatNscDep <> "NULL" Then
                sDatNscDep = "TO_DATE('" & sDatNscDep & "', 'YYYY-MM-DD')"
            End If
            If sDatRgtRepCshReg <> "NULL" Then
                sDatRgtRepCshReg = "TO_DATE('" & sDatRgtRepCshReg & "', 'YYYY-MM-DD')"
            End If

            sCmdSql = " UPDATE MRT.T0150415 " & _
                    " SET NUMDOCIDTREP = '" & sNumDocIdtRep & "', NOMORGEMSDOCIDTREP = " & FunFrmCpo(sNomOrgEmsDocIdtRep) & "," & _
                    "     NOMREP = " & FunFrmCpo(sNomRep) & ", CODSEX = " & FunFrmCpo(sCodSex) & ", DATNSCREP = " & sDatNscRep & ", NOMNACREP = " & FunFrmCpo(sNomAcsRep) & "," & _
                    "     TIPESTCVLREP = " & FunFrmCpo(sTipEstCvlRep) & ", CODGRAECLREP =" & sCodGraEclRep & ", TIPSITECLREP =" & FunFrmCpo(sTipSitEclRep) & ", " & _
                    "     ENDREP = " & FunFrmCpo(sEndRep) & ", CODBAI = " & sCodBai & ", CODCPLBAI = " & sCodCplBai & ", CODESTUNI = " & FunFrmCpo(sCodEstUni) & ", " & _
                    "     CODCIDREP = " & sCodCidRep & ", CODCEPREP = " & sCodCepRep & ", TIPSITRSIREP =" & FunFrmCpo(sTipSitRsiRep) & ", " & _
                    "     TIPVTGRSIREP = " & sTipVtgRsiRep & ", TIPSITTLFREP =" & FunFrmCpo(sTipSitTlfRep) & " ," & _
                    "     NUMTLFREP = " & FunFrmCpo(sNumTlfRep) & ", NUMTLFCELREP =" & FunFrmCpo(sNumTlfCelRep) & ", TIPSITFAXREP =" & FunFrmCpo(sTipSitFaxRep) & ", " & _
                    "     NUMFAXREP = " & FunFrmCpo(sNumFaxRep) & ", CODSGMMCD = " & sCodSgmMcd & ", NUMINSINUNACSEGSOC=" & FunFrmCpoInt(sNumInsInuNacSegSoc) & "," & _
                    "     NOMDEPREP = " & FunFrmCpo(sNomDepRep) & ", DATNSCDEP = " & sDatNscDep & ", NUMDOCIDT = " & FunFrmCpo(sNumDocIdt) & ", " & _
                    "     NOMORGEMSDOCIDTDEP = " & FunFrmCpo(sNomOrgEmsDocIdtDep) & ", QDEFLHREP = " & sQdeFlhRep & ", CODBCOREP = " & sCodBcoRep & ", " & _
                    "     CODAGEBCOREP = " & sCodAgeBcoRep & ", CODCNTCRRBCOREP = " & FunFrmCpo(sCodCntCrrBcoRep) & ", NUMDIGVRFAGEBCOREP = " & FunFrmCpo(sNumDigVrfAgeBcoRep) & ", " & _
                    "     CODSTACADREP = " & sCodStaCadRep & ", NUMRGTREPCSHREG = " & FunFrmCpo(sNumRgtRepCshRep) & ", DATRGTREPCSHREG = " & sDatRgtRepCshReg & ", " & _
                    "     CODESTUNICSHREG = " & FunFrmCpo(sCodEstUniCshReg) & ", TIPSITREPCSHREG = " & FunFrmCpo(sTipSitRepCshReg) & ", " & _
                    "     TIPSITPESJURCSHREG = " & FunFrmCpo(sTipSitPesJurCshReg) & ", " & _
                    "     INDACEPND = " & sIndAcePnd & ", INDVLDCPF = " & sIndVldCpf & ", CODUNDNGC = " & sCodUndNgc & ", " & _
                    "     TIPFRMPGT = " & FunFrmCpo(sTipFrmPgt) & ",  INDRTCCRD=" & sIndRtcCrd & _
                    "     WHERE NUMREQCADREP = " & sNumReqCttRep

            'executa inserção
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Altera Status da requisição  ------------------"
    Public Function AltStaReq(ByVal sNumReq As String, ByVal sCodSta As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'altera status de acordo com parametros
            sCmdSql = " UPDATE MRT.T0150415 SET CODSTACADREP = " & sCodSta & _
                      " WHERE NUMREQCADREP = " & sNumReq

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region


#Region " --------------- Altera Tabela complementar do representante ------------------"
    Public Function AltTabCplRep(ByVal sDatPrvCrdRsvRep As String, ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try


            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'altera status de acordo com parametros
            sCmdSql = " UPDATE MRT.T0118678 SET DATPRVCRDRSVREP = '" & sDatPrvCrdRsvRep & _
                      "', VLRSLDRSVREPNVO = 0 " & _
                      " WHERE CODREP = " & sCodRep

            'Conversão Oracle 16/02/06
            sCmdSql = " UPDATE MRT.T0118678 SET DATPRVCRDRSVREP = TO_DATE('" & sDatPrvCrdRsvRep & _
                      "','YYYY-MM-DD'), VLRSLDRSVREPNVO = 0 " & _
                      " WHERE CODREP = " & sCodRep

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Altera dependente do representante ------------------"
    Public Function AltDepRep(ByVal sCodRep As String, ByVal sNomDep As String, ByVal sDatNscDep As String, ByVal sNumDocIdtDep As String, ByVal sNomOrgEmsIdtDep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo


        Try


            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'altera status de acordo com parametros

            'sCmdSql = " UPDATE MRT.T0107315 SET NOMDEPREP = '" & sNomDep & "'," & _
            '          "         DATNSCDEP = '" & sDatNscDep & "'," & _
            '          "         NUMDOCIDT = '" & sNumDocIdtDep & "'," & _
            '          "         NOMORGEMSDOCIDTDEP = '" & sNomOrgEmsIdtDep & "' " & _
            '          " WHERE CODGRAPARREP = 2 AND CODREP = " & sCodRep

            'Conversão Oracle 16/02/06
            sCmdSql = " UPDATE MRT.T0107315 SET NOMDEPREP = '" & sNomDep & "'," & _
                      "         DATNSCDEP = TO_DATE('" & sDatNscDep & "','YYYY-MM-DD')," & _
                      "         NUMDOCIDT = '" & sNumDocIdtDep & "'," & _
                      "         NOMORGEMSDOCIDTDEP = '" & sNomOrgEmsIdtDep & "' " & _
                      " WHERE CODGRAPARREP = 2 AND CODREP = " & sCodRep


            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " --------------- Altera dependente do representante ------------------"
    Public Function AltTetRep(ByVal sCodTetVnd As String, ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'altera status de acordo com parametros
            'sCmdSql = " UPDATE MRT.T0133715 SET CODREP = " & sCodRep & "," & _
            '          "         DATDISTETVND = NULL, " & _
            '          "         DATSBTREP = CURRENT DATE" & _
            '          " WHERE CODTETVND = " & sCodTetVnd

            'Conversão Oracle 16/02/06
            sCmdSql = " UPDATE MRT.T0133715 SET CODREP = " & sCodRep & "," & _
                      "         DATDISTETVND = NULL, " & _
                      "         DATSBTREP = TRUNC(SYSDATE)" & _
                      " WHERE CODTETVND = " & sCodTetVnd

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " ---------------- Exclui Dados da Tabela de Territórios do Representante ------------------"

    Public Function EcsDdoTetRep(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            'exclui dados na tabela de territorios do representante
            sCmdSql = " DELETE FROM MRT.T0150377 WHERE NUMREQCADREP = " & sNumReqCadRep

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " ---------------- Exclui Dados da Tabela de Competências do Representante ------------------"

    Public Function EcsDdoCtnRep(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'exclui dados na tabela de competências do representante
            sCmdSql = " DELETE FROM MRT.T0150652 WHERE NUMREQCADREP = " & sNumReqCadRep

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region " ---------------- Exclui Dados da Tabela de Avaliações do Representante ------------------"

    Public Function EcsDdoAvlRep(ByVal sNumReqCadRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer

            'exclui dados na tabela de competências do representante
            sCmdSql = " DELETE FROM MRT.T0150466 WHERE NUMREQCADREP = " & sNumReqCadRep

            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

#Region "-------------------- Formata Campo ------------------"
    'Se o campo for diferente de NULL, formata, colocando aspas
    Function FunFrmCpo(ByVal sCpo As String) As String
        If sCpo = "NULL" Then
            Return "NULL"
        Else
            If sCpo = "" Then
                Return "' '"
            Else
                Return "'" + sCpo + "'"
            End If
        End If
    End Function
#End Region

#Region "-------------------- Formata Campo Inteiro ------------------"
    'Se o campo for diferente de NULL
    Function FunFrmCpoInt(ByVal sCpo As String) As String
        If sCpo.Trim = "" Then
            Return "NULL"
        Else
            Return sCpo
        End If
    End Function
#End Region

#Region " ----------------- Consulta informações do representante ja existente -------------"

    Public Function CsnDdoRepExt(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try

            sCmdSql = " SELECT Cid.CODESTUNI as CODESTUNI, NOMREP, NUMDOCIDTREP, NOMORGEMSDOCIDTREP, NUMINSINUNACSEGSOC, " & _
                      "   CODUNDNGC, NUMRGTREPCSHREG, DATRGTREPCSHREG, TIPSITPESJURCSHREG, CODESTUNICSHREG, " & _
                      "   TIPSITREPCSHREG, Rep.CODSEX, DATNSCREP, NOMNACREP, TIPESTCVLREP, CODGRAECLREP, TIPSITECLREP, " & _
                      "   CODCIDREP, CODBAI, CODCPLBAI, ENDREP, CODCEPREP, TIPSITRSIREP, TIPVTGRSIREP, NUMTLFREP, " & _
                      "   TIPSITTLFREP, NUMFAXREP, TIPSITFAXREP, NUMTLFCELREP, CODSGMMCD, QDEFLHREP, CODBCOREP, " & _
                      "   CODAGEBCOREP, NUMDIGVRFAGEBCOREP, CODCNTCRRBCOREP, Bco.NOMBCO , Age.NOMAGEBCO,  " & _
                      "   Dep.NOMDEPREP, Dep.DATNSCDEP, Dep.NUMDOCIDT, Dep.NOMORGEMSDOCIDTDEP " & _
                      " FROM MRT.T0100116 Rep, MRT.T0100035 Cid, MRT.T0100345 Bco, MRT.T0104413 Age, MRT.T0107315 Dep " & _
                      " WHERE Rep.CODREP = " & sCodRep & _
                      "   AND Rep.CodCidRep = Cid.CodCid " & _
                      "   AND Rep.CodBcoRep = Bco.CodBco " & _
                      "   AND Rep.CodAgeBcoRep = Age.CodAgeBco " & _
                      "   AND Age.CodBco = Rep.CodBcoRep " & _
                      "   And Rep.CodRep = Dep.CodRep " & _
                      " ORDER BY DATCADREP DESC "

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
#End Region


    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Verifica se o usuario da rede e um usuario valido cadastrado.
    REM ''' </summary>
    REM ''' <param name="pNomUsrRcf">Nome de rede do usuario a ser verificado.</param>
    REM ''' <param name="sVlrErr"></param>
    REM ''' <returns>XML contendo valor inteiro indicando existencia (> 0) ou nao (= 0) do usuario pesquisado.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/30/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CnsUsrRcf(ByVal pNomUsrRcf As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql
        Dim sCmdSql As String
        Try
            sCmdSql = " select 1 as Status " & _
                      " from mrt.t0104596 " & _
                      " where NOMUSRRCF = UPPER('" & pNomUsrRcf.Trim & "')"

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

    Public Function CnsCodSeqObs(ByVal pNumReq As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Dim sVlrRet As String
        Try
            ' Caso esteja consultando o valor maximo de um numero a fim de 
            ' utilizá-lo será necessário utilizar o comando abaixo para que 
            ' duas aplicacoes nao pegue o mesmo número
            'sCmdSql = " LOCK TABLE mrt.t0150610 IN EXCLUSIVE MODE "

            ''executa consulta
            'oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)

            'oObeAcsDdo.ExcCmdSql(sVlrRet)

            'sCmdSql = " select coalesce(max(integer(CODSEQOBS)) + 1,1) as CodSeqObs " & _
            '          " from mrt.t0150610 " & _
            '          " where NUMREQCADREP = " & pNumReq

            'Conversão Oracle 16/02/06
            sCmdSql = " SELECT COALESCE(MAX(TO_NUMBER(CODSEQOBS)) + 1,1) AS CodSeqObs " & _
                      " FROM MRT.t0150610 " & _
                      " WHERE NUMREQCADREP = " & pNumReq


            'executa consulta
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
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

    '- Consulta agência de um banco
    Public Function CsnAgeBcoUnc(ByVal iCodBco As Integer, _
                                 ByVal iCodAgeBco As Integer, _
                                 ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        'objeto de acessa dados
        Dim oAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            'comando sql 
            Dim sCmdSql As String

            sCmdSql = " SELECT CODAGEBCO, NOMAGEBCO, NUMDIGVRFAGEBCO " & _
                      " FROM MRT.T0104413 " & _
                      " WHERE CODBCO = " & iCodBco.ToString & _
                      " AND CODAGEBCO = " & iCodAgeBco.ToString
            'executa consulta
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oAcsDdo.ExcCmdSql(CsnAgeBcoUnc)
        Catch oEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oAcsDdo = Nothing
        End Try
    End Function

    '- Consulta banco único
    Public Function CsnBcoUnc(ByVal iCodBco As Integer, _
                              ByRef sVlrErr As String, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        'objeto de acessa dados
        Dim oAcsDdo As New IAU013.UO_IAUAcsDdo
        'comando sql 
        Dim sCmdSql As String
        Try
            sCmdSql = " SELECT CODBCO, NOMBCO " & _
                      " FROM MRT.T0100345 " & _
                      " WHERE CODBCO = " & iCodBco.ToString
            'executa consulta
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oAcsDdo.ExcCmdSql(CsnBcoUnc)
        Catch oEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oAcsDdo = Nothing
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta Cidade e Estado (Unidade da Federação) por CEP
    ''' </summary>
    ''' <param name="sCep">Número do CEP</param>
    ''' <param name="sVlrErr">Valor do erro</param>
    ''' <param name="oCnx">Conexão com o banco de dados</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	15/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnCidEstCep(ByVal sCep As String, _
                                 ByRef sVlrErr As String, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As New IAU013.UO_IAUAcsDdo
        Dim sCmdSql As String
        Try
            'sCmdSql = " SELECT 	CODCID, NOMCID, CODESTUNI " & _
            '" FROM MRT.T0100035 " & _
            '" WHERE " & sCep & " BETWEEN CODCEPINI AND CODCEPFIM AND DATDSTCID IS NULL " & _
            '" ORDER BY CODCEPINI desc FETCH FIRST 1 ROW ONLY "

            'Migração Oracle 16/02/06
            sCmdSql = " select CID.CODCID, CID.NOMCID, CID.CODESTUNI " & _
            " from MRT.T0100035 CID " & _
            " inner join MRT.T0106378 CEP on CID.CODCID = CEP.CODCIDCEP " & _
            " where CEP.CODCEP = " & sCep & " "

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oAcsDdo.ExcCmdSql(CsnCidEstCep)
        Catch oEcc As Exception
            Throw
        Finally
            oAcsDdo = Nothing
        End Try
    End Function

#Region " ----------------- Alteração da Empresa do Representante -------------"
    Public Function IsrDdoHstEmpRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                                    ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                    ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                                    ByVal sNomEmpRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                                    ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                                    ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                                    ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, ByVal sDatHraAlt As String, _
                                    ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        If sTipNatRep.Trim = "" Then
            sTipNatRep = "NULL"
        Else
            sTipNatRep = "'" & sTipNatRep & "'"
        End If
        If sNumDigVrfAgeBcoRep.Trim = "" Then
            sNumDigVrfAgeBcoRep = "NULL"
        Else
            sNumDigVrfAgeBcoRep = "'" & sNumDigVrfAgeBcoRep & "'"
        End If
        If sCodCntCrrBcoRep.Trim = "" Then
            sCodCntCrrBcoRep = "NULL"
        Else
            sCodCntCrrBcoRep = "'" & sCodCntCrrBcoRep & "'"
        End If
        If sNumCgcEmpRep.Trim = "" Then
            sNumCgcEmpRep = "NULL"
        Else
            sNumCgcEmpRep = "'" & sNumCgcEmpRep & "'"
        End If
        If sNomEmpRep.Trim = "" Then
            sNomEmpRep = "NULL"
        Else
            sNomEmpRep = "'" & sNomEmpRep & "'"
        End If

        If sNumInsInuNacSegSoc.Trim = "" Then
            sNumInsInuNacSegSoc = "NULL"
        Else
            sNumInsInuNacSegSoc = "'" & sNumInsInuNacSegSoc & "'"
        End If

        If sEndEmpRep.Trim = "" Then
            sEndEmpRep = "NULL"
        Else
            sEndEmpRep = "'" & sEndEmpRep & "'"
        End If
        If sCodBaiEmpRep.Trim = "" Then
            sCodBaiEmpRep = "NULL"
        End If
        If sCodCplBaiEmpRep.Trim = "" Then
            sCodCplBaiEmpRep = "NULL"
        End If
        If sCodCepEmpRep.Trim = "" Then
            sCodCepEmpRep = "NULL"
        End If
        If sDatAsnCttRep.Trim = "" Then
            sDatAsnCttRep = "NULL"
        Else
            sDatAsnCttRep = "TO_DATE('" & sDatAsnCttRep & "','YYYY-MM-DD')"
        End If
        If sDatCadFilEmp.Trim = "" Then
            sDatCadFilEmp = "NULL"
        Else
            sDatCadFilEmp = "TO_DATE('" & sDatCadFilEmp & "','YYYY-MM-DD')"
        End If

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            str.Append("INSERT INTO MRT.T0123949 (")
            str.Append("CODREP, DATHRAREF, CODSITREP, TIPSITPESJURCSHREG, TIPNATREP, CODBCOREP, CODAGEBCOREP, NUMDIGVRFAGEBCOREP,")
            str.Append("CODCNTCRRBCOREP, NUMCGCEMPREP, NOMEMPREP, NUMINSINUNACSEGSOC, ENDEMPREP, CODBAIEMPREP, CODCPLBAIEMPREP, CODCEPEMPREP, NUMRGTREPCSHREG,")
            str.Append("CODESTUNICSHREG, TIPSITREPCSHREG, DATRGTREPCSHREG, DATASNCTTREP, DATCADFILEMP, CODSUP, DATHRAALT)")
            str.Append(" VALUES (")
            str.Append(sCodRep & ",")
            str.Append("SYSDATE,")
            str.Append(sCodSitRep & ",")
            str.Append("'" & sTipSitPesJurCshReg & "',")
            str.Append(sTipNatRep & ",")
            str.Append(sCodBcoRep & ",")
            str.Append(sCodAgeBcoRep & ",")
            str.Append(sNumDigVrfAgeBcoRep & ",")
            str.Append(sCodCntCrrBcoRep & ",")
            str.Append(sNumCgcEmpRep & ",")
            str.Append(sNomEmpRep & ",")
            str.Append(sNumInsInuNacSegSoc & ",")
            str.Append(sEndEmpRep & ",")
            str.Append(sCodBaiEmpRep & ",")
            str.Append(sCodCplBaiEmpRep & ",")
            str.Append(sCodCepEmpRep & ",")
            str.Append("'" & sNumRgtRepCshReg & "',")
            str.Append("'" & sCodEstUniCshReg & "',")
            str.Append("'" & sTipSitRepCshReg & "',")
            str.Append("TO_DATE('" & sDatRgtRepCshReg & "','YYYY-MM-DD'),")
            str.Append(sDatAsnCttRep & ",")
            str.Append(sDatCadFilEmp & ",")
            str.Append(sCodSup & ",")
            str.Append(sDatHraAlt & ")")

            sCmdSql = str.ToString
            'executa
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function

    Public Function AltDdoHstEmpRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                                    ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                    ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                                    ByVal sNomEmpRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                                    ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                                    ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                                    ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, ByVal sDatHraAlt As String, _
                                    ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        If sTipNatRep.Trim = "" Then
            sTipNatRep = "NULL"
        Else
            sTipNatRep = "'" & sTipNatRep & "'"
        End If
        If sNumDigVrfAgeBcoRep.Trim = "" Then
            sNumDigVrfAgeBcoRep = "NULL"
        Else
            sNumDigVrfAgeBcoRep = "'" & sNumDigVrfAgeBcoRep & "'"
        End If
        If sCodCntCrrBcoRep.Trim = "" Then
            sCodCntCrrBcoRep = "NULL"
        Else
            sCodCntCrrBcoRep = "'" & sCodCntCrrBcoRep & "'"
        End If
        If sNumCgcEmpRep.Trim = "" Then
            sNumCgcEmpRep = "NULL"
        Else
            sNumCgcEmpRep = "'" & sNumCgcEmpRep & "'"
        End If
        If sNomEmpRep.Trim = "" Then
            sNomEmpRep = "NULL"
        Else
            sNomEmpRep = "'" & sNomEmpRep & "'"
        End If

        If sNumInsInuNacSegSoc.Trim = "" Then
            sNumInsInuNacSegSoc = "NULL"
        Else
            sNumInsInuNacSegSoc = "'" & sNumInsInuNacSegSoc & "'"
        End If

        If sEndEmpRep.Trim = "" Then
            sEndEmpRep = "NULL"
        Else
            sEndEmpRep = "'" & sEndEmpRep & "'"
        End If
        If sCodBaiEmpRep.Trim = "" Then
            sCodBaiEmpRep = "NULL"
        End If
        If sCodCplBaiEmpRep.Trim = "" Then
            sCodCplBaiEmpRep = "NULL"
        End If
        If sCodCepEmpRep.Trim = "" Then
            sCodCepEmpRep = "NULL"
        End If
        If sDatAsnCttRep.Trim = "" Then
            sDatAsnCttRep = "NULL"
        Else
            sDatAsnCttRep = "TO_DATE('" & sDatAsnCttRep & "','YYYY-MM-DD')"
        End If
        If sDatCadFilEmp.Trim = "" Then
            sDatCadFilEmp = "NULL"
        Else
            sDatCadFilEmp = "TO_DATE('" & sDatCadFilEmp & "','YYYY-MM-DD')"
        End If

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            str.Append("UPDATE MRT.T0123949")
            str.Append(" SET CODSITREP = " & sCodSitRep & ",")
            str.Append("    TIPSITPESJURCSHREG = '" & sTipSitPesJurCshReg & "',")
            str.Append("    TIPNATREP = " & sTipNatRep & ",")
            str.Append("    CODBCOREP = " & sCodBcoRep & ",")
            str.Append("    CODAGEBCOREP = " & sCodAgeBcoRep & ",")
            str.Append("    NUMDIGVRFAGEBCOREP = " & sNumDigVrfAgeBcoRep & ",")
            str.Append("    CODCNTCRRBCOREP = " & sCodCntCrrBcoRep & ",")
            str.Append("    NUMCGCEMPREP = " & sNumCgcEmpRep & ",")
            str.Append("    NOMEMPREP = " & sNomEmpRep & ",")
            str.Append("    NUMINSINUNACSEGSOC = " & sNumInsInuNacSegSoc & ",")
            str.Append("    ENDEMPREP = " & sEndEmpRep & ",")
            str.Append("    CODBAIEMPREP = " & sCodBaiEmpRep & ",")
            str.Append("    CODCPLBAIEMPREP = " & sCodCplBaiEmpRep & ",")
            str.Append("    CODCEPEMPREP = " & sCodCepEmpRep & ",")
            str.Append("    NUMRGTREPCSHREG = '" & sNumRgtRepCshReg & "',")
            str.Append("    CODESTUNICSHREG = '" & sCodEstUniCshReg & "',")
            str.Append("    TIPSITREPCSHREG = '" & sTipSitRepCshReg & "',")
            str.Append("    DATRGTREPCSHREG = TO_DATE('" & sDatRgtRepCshReg & "','YYYY-MM-DD'),")
            str.Append("    DATASNCTTREP = " & sDatAsnCttRep & ",")
            str.Append("    DATCADFILEMP = " & sDatCadFilEmp & ",")
            str.Append("    CODSUP = " & sCodSup & ",")
            str.Append("    DATHRAALT = " & sDatHraAlt)
            str.Append(" WHERE CODREP = " & sCodRep)
            str.Append("  AND DATHRAALT IS NULL")

            sCmdSql = str.ToString
            'executa
            sVlrErr = sCmdSql

            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt

        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO            
            Throw New Exception(sVlrErr)
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function

    Public Function DelDdoHstEmpRep(ByVal sCodRep As String, ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            str.Append(" DELETE FROM MRT.T0123949 ")
            str.Append(" WHERE CODREP = " & sCodRep)
            str.Append("  AND DATHRAALT IS NULL")

            sCmdSql = str.ToString
            'executa
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)
            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function

    Public Function AltDdoTabRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                                 ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                 ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                                 ByVal sNomEmpRep As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                                 ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                                 ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                                 ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, _
                                 ByRef sVlrErr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        If sTipNatRep.Trim = "" Then
            sTipNatRep = "NULL"
        Else
            sTipNatRep = "'" & sTipNatRep & "'"
        End If
        If sNumDigVrfAgeBcoRep.Trim = "" Then
            sNumDigVrfAgeBcoRep = "NULL"
        Else
            sNumDigVrfAgeBcoRep = "'" & sNumDigVrfAgeBcoRep & "'"
        End If
        If sCodCntCrrBcoRep.Trim = "" Then
            sCodCntCrrBcoRep = "NULL"
        Else
            sCodCntCrrBcoRep = "'" & sCodCntCrrBcoRep & "'"
        End If
        If sNumCgcEmpRep.Trim = "" Then
            sNumCgcEmpRep = "NULL"
        Else
            sNumCgcEmpRep = "'" & sNumCgcEmpRep & "'"
        End If
        If sNomEmpRep.Trim = "" Then
            sNomEmpRep = "NULL"
        Else
            sNomEmpRep = "'" & sNomEmpRep & "'"
        End If
        If sEndEmpRep.Trim = "" Then
            sEndEmpRep = "NULL"
        Else
            sEndEmpRep = "'" & sEndEmpRep & "'"
        End If
        If sCodBaiEmpRep.Trim = "" Then
            sCodBaiEmpRep = "NULL"
        End If
        If sCodCplBaiEmpRep.Trim = "" Then
            sCodCplBaiEmpRep = "NULL"
        End If
        If sCodCepEmpRep.Trim = "" Then
            sCodCepEmpRep = "NULL"
        End If
        If sDatAsnCttRep.Trim = "" Then
            sDatAsnCttRep = "TO_DATE('1900-01-01','YYYY-MM-DD')"
        Else
            sDatAsnCttRep = "TO_DATE('" & sDatAsnCttRep & "','YYYY-MM-DD')"
        End If
        If sDatCadFilEmp.Trim = "" Then
            sDatCadFilEmp = "NULL"
        Else
            sDatCadFilEmp = "TO_DATE('" & sDatCadFilEmp & "','YYYY-MM-DD')"
        End If

        'objeto de acessa dados
        Dim oObeAcsDdo As New IAU013.UO_IAUAcsDdo
        Try
            Dim sCmdSql As String
            Dim iNumRgt As Integer
            Dim str As System.Text.StringBuilder = New System.Text.StringBuilder

            'Atualiza T0100116
            str.Append("UPDATE MRT.T0100116")
            str.Append(" SET CODSITREP = " & sCodSitRep & ",")
            str.Append("    TIPSITPESJURCSHREG = '" & sTipSitPesJurCshReg & "',")
            str.Append("    TIPNATREP = " & sTipNatRep & ",")
            str.Append("    CODBCOREP = " & sCodBcoRep & ",")
            str.Append("    CODAGEBCOREP = " & sCodAgeBcoRep & ",")
            str.Append("    NUMDIGVRFAGEBCOREP = " & sNumDigVrfAgeBcoRep & ",")
            str.Append("    CODCNTCRRBCOREP = " & sCodCntCrrBcoRep & ",")
            str.Append("    NUMCGCEMPREP = " & sNumCgcEmpRep & ",")
            str.Append("    NOMEMPREP = " & sNomEmpRep & ",")
            str.Append("    ENDEMPREP = " & sEndEmpRep & ",")
            str.Append("    CODBAIEMPREP = " & sCodBaiEmpRep & ",")
            str.Append("    CODCPLBAIEMPREP = " & sCodCplBaiEmpRep & ",")
            str.Append("    CODCEPEMPREP = " & sCodCepEmpRep & ",")
            str.Append("    NUMRGTREPCSHREG = '" & sNumRgtRepCshReg & "',")
            str.Append("    CODESTUNICSHREG = '" & sCodEstUniCshReg & "',")
            str.Append("    TIPSITREPCSHREG = '" & sTipSitRepCshReg & "',")
            str.Append("    DATRGTREPCSHREG = TO_DATE('" & sDatRgtRepCshReg & "','YYYY-MM-DD'),")
            str.Append("    DATASNCTTREP = " & sDatAsnCttRep & ",")
            str.Append("    CODSUP = " & sCodSup)
            str.Append(" WHERE CODREP = " & sCodRep)

            sCmdSql = str.ToString

            'executa
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)

            str = New System.Text.StringBuilder

            'Atualiza T0118678
            str.Append("UPDATE MRT.T0118678")
            str.Append(" SET DATCADFILEMP = " & sDatCadFilEmp)
            str.Append(" WHERE CODREP = " & sCodRep)

            sCmdSql = str.ToString

            'executa
            oObeAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql)
            oObeAcsDdo.ExcCmdSql(iNumRgt)

            Return iNumRgt
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            'liberando objetos
            oObeAcsDdo = Nothing
        End Try

    End Function
#End Region

End Class

#End Region