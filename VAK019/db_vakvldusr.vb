
#Region " --------------- Classe ------------------"
Public Class DB_VAKVldUsr
    '- Consulta codigo do analista de credito de acordo com o nome
    Public Function CsnAnsCrd(ByVal sNomUsrRde As String, _
                              ByRef sVlrErr As String, _
                              ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim sCmdSql As String  'comando sql 
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo

        Try

            sCmdSql = " SELECT ANSCRD.CODANSCAD, FNC.NOMFNC " & _
                      " FROM   MRT.T0150393 ANSCRD,  mrt.t0100361 FNC " & _
                      " WHERE  ANSCRD.CODFNC = ( " & _
                      "                 SELECT CODFNC " & _
                      "                 FROM MRT.T0104596 " & _
                      "                 WHERE NOMUSRRCF = '" & sNomUsrRde & "')" & _
                      "  AND   ANSCRD.CODFNC = FNC.CODFNC "

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql) 'objeto de acessa dados
            oAcsDdo.ExcCmdSql(CsnAnsCrd)
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function
    '- Consulta codigo do analista de credito de acordo com o nome
    Public Function CsnGerVnd(ByVal sNomUsrRde As String, _
                              ByRef sVlrErr As String, _
                              ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        'objeto de acessa dados
        Dim sCmdSql As String  'comando sql 
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo

        Try
            sCmdSql = " SELECT CODGER, NOMGER " & _
                      " FROM   MRT.T0100051" & _
                      " WHERE  CODFNCGER = ( " & _
                      "                    SELECT CODFNC " & _
                      "                    FROM MRT.T0104596 " & _
                      "                    WHERE NOMUSRRCF = '" & sNomUsrRde & "')" & _
                      "    AND DATDSTGER IS NULL "

            'executa consulta
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sCmdSql) 'objeto de acessa dados
            oAcsDdo.ExcCmdSql(CsnGerVnd)
        Catch oObeEcc As Exception
            'levanta excecao que sera tratada no BO
            Throw
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function
End Class

#End Region
