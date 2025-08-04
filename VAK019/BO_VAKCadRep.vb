Imports Microsoft.ApplicationBlocks.ExceptionManagement
Imports System.Web.Mail
Imports System.Xml

Public Class BO_VAKCadRep

    Public Const _ID_SISTEMA_EMAIL = 51

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


#Region "--> Regras de Negocio para Pedido e Retorno de parecer "
    Public Function PedOpn(ByVal psNumReqCadRep As String, _
                           ByVal psTipUsr As String, _
                           ByVal psNomUsrOrg As String, _
                           ByVal psNomUsrDsn As String, _
                           ByVal psDesObs As String, _
                           ByRef psVlrErr As String) As Boolean

        Dim sCodSeqObs As String
        Dim iCodSeqObs As Int64
        Dim objVAKRep As VAK019.DB_VAKRep
        Dim sVlrRet As String
        Dim ds As DataSet
        Dim sCodStaCadRep As String = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try

            objVAKRep = New VAK019.DB_VAKRep
            Select Case psTipUsr
                Case "GERVND"
                    sCodStaCadRep = "18"
                Case "ANSCRD"
                    sCodStaCadRep = "20"
                Case Else

            End Select

            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            ' Obtem o proximo registro disponivel da sequencia do fluxo
            sVlrRet = objVAKRep.CnsCodSeqObs(psNumReqCadRep, psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            sVlrRet = ""
            sCodSeqObs = ds.Tables(0).Rows(0).Item(0)
            ds = Nothing

            ' Insere o registro indicador do pedido de parecer (pra quem foi feito o pedido)
            sVlrRet = objVAKRep.IsrDdoPedRetOpn(psNumReqCadRep, sCodStaCadRep, sCodSeqObs, psNomUsrOrg, psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            ' Insere na tabela de fluxo
            sVlrRet = objVAKRep.IsrDdoDesObs(psNumReqCadRep, sCodSeqObs, RetVlrSpace(psDesObs), psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If

            iCodSeqObs = Integer.Parse(sCodSeqObs)
            iCodSeqObs = iCodSeqObs + 1
            Dim iCodStaCadRep As Integer = Integer.Parse(sCodStaCadRep)

            sVlrRet = objVAKRep.IsrDdoPedRetOpn(psNumReqCadRep, (iCodStaCadRep + 1).ToString, iCodSeqObs.ToString, psNomUsrDsn, psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            Dim sDesFlu As String
            sDesFlu = "*******************************************************************" + Chr(13) + _
                      " O pedido de parecer enviado por " & psNomUsrOrg & " a " & psNomUsrDsn & " ainda nao foi atendido." + Chr(13)
            sVlrRet = objVAKRep.IsrDdoDesObs(psNumReqCadRep, iCodSeqObs.ToString, sDesFlu, psVlrErr, oCnx)
            sDesFlu = Nothing
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            oCnx.FimTscSuc()
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            oCnx.FimTscErr()
            Return False
        Finally
            sCodSeqObs = Nothing
            objVAKRep = Nothing
            objVAKRep = Nothing
            sVlrRet = Nothing
            ds = Nothing
            iCodSeqObs = Nothing
            oCnx.Dispose()
        End Try
    End Function

    Public Function RetOpn(ByVal psNumReqCadRep As String, _
                                            ByVal psTipUsr As String, _
                                            ByVal psNomUsrOrg As String, _
                                            ByVal psNomUsrDsn As String, _
                                            ByVal psDesObs As String, _
                                            ByVal psCodSeqObs As String, _
                                            ByRef psVlrErr As String) As Boolean

        Dim iCodSeqObs As Int64
        Dim objVAKRep As VAK019.DB_VAKRep
        Dim sVlrRet As String
        Dim ds As DataSet
        Dim sCodStaCadRep As String = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try

            objVAKRep = New VAK019.DB_VAKRep

            Select Case psTipUsr.Trim
                Case "GERVND"
                    sCodStaCadRep = "19"
                Case "ANSCRD"
                    sCodStaCadRep = "21"
            End Select
            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            ' Insere o registro indicador do pedido de parecer (pra quem foi feito o pedido)
            sVlrRet = objVAKRep.AltDdoPetRetOpn(psNumReqCadRep, psNomUsrOrg, psCodSeqObs, psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            ' Atualiza a tabela de fluxo
            sVlrRet = objVAKRep.AltDdoDesObs(psNumReqCadRep, psCodSeqObs, RetVlrSpace(psDesObs), psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception(psVlrErr)
            End If
            oCnx.FimTscSuc()
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            oCnx.FimTscErr()
            Return False
        Finally
            objVAKRep = Nothing
            objVAKRep = Nothing
            sVlrRet = Nothing
            ds = Nothing
            iCodSeqObs = Nothing
            oCnx.Dispose()
        End Try
    End Function

    Public Function CncRetOpn(ByVal psNumReqCadRep As String, _
                              ByVal psTipUsr As String, _
                              ByVal psNomUsrOrg As String, _
                              ByVal psDesObs As String, _
                              ByRef psVlrErr As String) As Boolean

        Dim sCodSeqObs As String
        Dim iCodSeqObs As Int64

        Dim objVAKRep As VAK019.DB_VAKRep
        Dim sVlrRet As String
        Dim ds As DataSet
        Dim sCodStaCadRep As String = ""
        Dim sNomUsrDsn As String            REM usuario de destino do parecer (para retorno)
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try


            sNomUsrDsn = ""

            Select Case psTipUsr
                Case "GERVND"
                    sCodStaCadRep = "18"
                Case "ANSCRD"
                    sCodStaCadRep = "20"
            End Select

            objVAKRep = New VAK019.DB_VAKRep

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Obtem a lista de destinatarios para retorno de parecer
            sVlrRet = objVAKRep.CsnCreDsnRetOpn(psNumReqCadRep, Nothing, psVlrErr, oCnx)
            If psVlrErr <> "" Then
                Throw New Exception
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            sVlrRet = ""

            If (Not ds Is Nothing) And (ds.Tables(0).Rows.Count > 0) Then
                ' Atualiza as referencias no FLUXO para cada parecer pendente
                Dim idx As Int32
                For idx = 0 To ds.Tables(0).Rows.Count - 1
                    sCodSeqObs = ds.Tables(0).Rows(idx)("CODSEQOBS")
                    sVlrRet = objVAKRep.AltDdoDesObs(psNumReqCadRep, sCodSeqObs, psDesObs, psVlrErr, oCnx)
                    If psVlrErr <> "" Then
                        Throw New Exception
                    End If
                Next
                ' Cancela os pareceres pendentes
                sVlrRet = objVAKRep.AltDdoPetRetOpn(psNumReqCadRep, psVlrErr, oCnx)
                If psVlrErr <> "" Then
                    Throw New Exception
                End If
            End If
            ds = Nothing
            oCnx.FimTscSuc()
        Catch ex As Exception
            oCnx.FimTscErr()
        Finally
            oCnx.Dispose()
        End Try
    End Function

#End Region

#Region "---------------------- Insere Dados Temporários do Representante --------------------"

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Insere dados de um RCA na tabela temporaria.
    REM ''' </summary>
    REM ''' <param name="sTxtMcoRep"></param>
    REM ''' <param name="sNomUsrUltAlt"></param>
    REM ''' <param name="sTxtMcoTetRep"></param>
    REM ''' <param name="sTxtMcoCtnRep"></param>
    REM ''' <param name="sTxtMcoAvlRep"></param>
    REM ''' <param name="sDesObsFlu"></param>
    REM ''' <param name="sNumReqCadRep"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[Getulio de Morais Pereira]	12/23/2004	Retirada de chamada de funcao para retorno de valor <BR>
    REM '''                                             NULL dos campos NOT NULL na tabela temporaria
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function IsrDdoRep(ByVal sTxtMcoRep As String, _
                              ByVal sNomUsrUltAlt As String, _
                              ByVal sTxtMcoTetRep As String, _
                              ByVal sTxtMcoCtnRep As String, _
                              ByVal sTxtMcoAvlRep As String, _
                              ByVal sDesObsFlu As String, _
                              ByRef sNumReqCadRep As String, _
                              ByVal TrabalhouMartins As Boolean, _
    ByVal Link As String) As String
        ''objeto
        Dim oObeIsrDdoRep As DB_VAKRep

        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oObeLetTxtMcoTetRep As System.IO.StringReader
        Dim oObeLetTxtMcoCtnRep As System.IO.StringReader
        Dim oObeLetTxtMcoAvlRep As System.IO.StringReader
        Dim oObeLetTxtMcoNroReq As System.IO.StringReader
        Dim oObeLetTxtMcoNomUsr As System.IO.StringReader
        Dim oObeLetTxtMcoNomGerMcd As System.IO.StringReader

        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoTetRep As New DataSet
        Dim oGrpDdoCtnRep As New DataSet
        Dim oGrpDdoAvlRep As New DataSet
        Dim oGrpDdoNroReq As New DataSet
        Dim oGrpDdoNomUsr As New DataSet
        Dim oGrpDdoNomGerMcd As New DataSet

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String

        Dim sVlrRetIsr As String

        'dados da tabela temporária de representantes
        Dim sNumReqCttRep, sNumCpfRep, sNumDocIdtRep, sNomOrgEmsDocIdtRep, sNomRep, sCodGerMcd As String
        Dim sCodGerVnd, sCodSex, sDatNscRep, sNomAcsRep, sTipEstCvlRep, sCodGraEclRep As String
        Dim sTipSitEclRep, sEndRep, sCodBai, sCodCplBai, sCodCidRep, sCodCepRep, sTipSitRsiRep As String
        Dim sTipVtgRsiRep, sTipSitTlfRep, sNumTlfRep, sNumTlfCelRep, sTipSitFaxRep, sNumFaxRep As String
        Dim sCodSgmMcd, sNumInsInuNacSegSoc, sNomDepRep As String
        Dim sDatNscDep, sNumDocIdt, sNomOrgEmsDocIdtDep, sQdeFlhRep, sCodBcoRep, sCodAgeBcoRep As String
        Dim sCodCntCrrBcoRep, sNumDigVrfAgeBcoRep, sTipNatRep, sDesAcoTrbRep, sCodStaCadRep As String
        Dim sDatRgtRepCshReg, sCodEstUniCshReg, sTipSitPesJrCshReg, sTipFrmPgt As String

        Dim sCodEstUni, sNumRgtRepCshRep, sIndAcePnd, sIndVldCpf, sCodUndNgc As String

        'dados da tabela de territórios do representante
        Dim sCodTetVnd, sAnoMesRef As String
        Dim dVlrVndTet As Double

        'dados da tabela de competências do representante
        Dim sCodCtnRep, sDesCdoCtnRep As String

        'dados da tabela de avaliações do representante
        Dim sCodAvlRep, sDesCdoAvlRep As String

        'nome do usuário de rede e dados do email
        Dim sNomUsrRcf, sNomGerMcd, strAssunto, strServidorSMTP, strDe, strPara As String

        Dim dVlrPrv As Double
        Dim iCntPrv As Integer
        Dim iNumReq As Int64
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Dim sVlrVndTet As String
        Try
            sVlrRet = ""
            sNumReqCttRep = ""
            oObeLetTxtMco = New System.IO.StringReader(sTxtMcoRep)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If

            ' -----------------------------------
            ' Campos da tabela MRT.T0150415
            ' -----------------------------------
            sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item(0)
            sNumDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(1) ' campo NOT NULL na tabela
            sNomOrgEmsDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(2) ' campo NOT NULL na tabela
            sNomRep = oGrpDdoRep.Tables(0).Rows(0).Item(3) ' campo NOT NULL na tabela
            sCodGerMcd = oGrpDdoRep.Tables(0).Rows(0).Item(4) ' campo NOT NULL na tabela
            sCodGerVnd = oGrpDdoRep.Tables(0).Rows(0).Item(5) ' campo NOT NULL na tabela
            sCodSex = oGrpDdoRep.Tables(0).Rows(0).Item(6) ' campo NOT NULL na tabela
            sDatNscRep = oGrpDdoRep.Tables(0).Rows(0).Item(7) ' campo NOT NULL na tabela

            ' --> NomNacRep
            sNomAcsRep = oGrpDdoRep.Tables(0).Rows(0).Item(8) ' campo NOT NULL na tabela

            sTipEstCvlRep = oGrpDdoRep.Tables(0).Rows(0).Item(9) ' campo NOT NULL na tabela
            sCodGraEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(10) ' campo NOT NULL na tabela
            sTipSitEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(11) ' campo NOT NULL na tabela
            sEndRep = oGrpDdoRep.Tables(0).Rows(0).Item(12) ' campo NOT NULL na tabela
            sCodBai = oGrpDdoRep.Tables(0).Rows(0).Item(13) ' campo NOT NULL na tabela
            sCodCplBai = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(14)) ' ok
            sCodCidRep = oGrpDdoRep.Tables(0).Rows(0).Item(15) ' campo NOT NULL na tabela
            sCodCepRep = oGrpDdoRep.Tables(0).Rows(0).Item(16) ' campo NOT NULL na tabela
            sTipSitRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(17) ' campo NOT NULL na tabela
            sTipVtgRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(18) ' campo NOT NULL na tabela

            ' Telefone do RCA
            sTipSitTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(19)) ' ok
            sNumTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(20)) ' ok
            ' FAX do RCA
            sTipSitFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(22)) ' ok
            sNumFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(23)) ' ok
            ' Celular do RCA
            sNumTlfCelRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(21)) ' ok

            sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item(24) ' campo NOT NULL na tabela
            sNumInsInuNacSegSoc = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(25)) ' ok
            sNomDepRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(26)) ' ok
            sDatNscDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(27)) ' ok
            sNumDocIdt = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(28)) ' ok
            sNomOrgEmsDocIdtDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(29)) ' ok
            sQdeFlhRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(30)) ' ok

            sCodBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(31)) ' campo NOT NULL na tabela
            sCodAgeBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(32)) ' campo NOT NULL na tabela
            sCodCntCrrBcoRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(33)) ' ok
            sNumDigVrfAgeBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(34)) ' campo NOT NULL na tabela

            sTipNatRep = oGrpDdoRep.Tables(0).Rows(0).Item(35) ' campo NOT NULL na tabela

            ' --> 
            sDesAcoTrbRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(36))

            sCodStaCadRep = oGrpDdoRep.Tables(0).Rows(0).Item(37) ' campo NOT NULL na tabela
            sDatRgtRepCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(38)) ' ok
            'sCodEstUniCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(39)) ' ok
            sCodEstUniCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("codestunicshreg"))

            'sTipSitPesJrCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(40) ' ok
            sTipSitPesJrCshReg = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item("tipsitpesjurcshreg")) ' ok

            'sCodEstUni = oGrpDdoRep.Tables(0).Rows(0).Item(41) ' campo NOT NULL na tabela
            sCodEstUni = oGrpDdoRep.Tables(0).Rows(0).Item("codestuni") ' campo NOT NULL na tabela

            sNumRgtRepCshRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NUMRGTREPCSHREP")) ' ok
            sIndAcePnd = oGrpDdoRep.Tables(0).Rows(0).Item("INDACEPND") ' campo NOT NULL na tabela
            sIndVldCpf = oGrpDdoRep.Tables(0).Rows(0).Item("INDVLDCPF") ' campo NOT NULL na tabela
            sCodUndNgc = oGrpDdoRep.Tables(0).Rows(0).Item("CODUNDNGC") ' campo NOT NULL na tabela
            sTipFrmPgt = oGrpDdoRep.Tables(0).Rows(0).Item("TIPFRMPGT") ' campo NOT NULL na tabela

            ' Interacao com camada de dados
            oObeIsrDdoRep = New DB_VAKRep

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Obtem o numero da proxima requisicao (disponivel)
            sNumReqCttRep = oObeIsrDdoRep.CsnNroReq(sVlrErr, oCnx)
            oObeLetTxtMcoNroReq = New System.IO.StringReader(sNumReqCttRep)
            oGrpDdoNroReq.ReadXml(oObeLetTxtMcoNroReq)
            sNumReqCttRep = oGrpDdoNroReq.Tables(0).Rows(0).Item(0)
            sNumReqCadRep = sNumReqCttRep    ' Contem o numero da proxima requisicao disponivel

            ' Insere dados na tabela temporária de representantes
            sVlrRetIsr = oObeIsrDdoRep.IsrDdoRep(sNumReqCttRep, sNumCpfRep, sNumDocIdtRep, sNomOrgEmsDocIdtRep, _
                                                 sNomRep, sCodGerMcd, sCodGerVnd, sCodSex, sDatNscRep, sNomAcsRep, _
                                                 sTipEstCvlRep, sCodGraEclRep, sTipSitEclRep, sEndRep, sCodBai, sCodCplBai, _
                                                 sCodCidRep, sCodCepRep, sTipSitRsiRep, sTipVtgRsiRep, sTipSitTlfRep, sNumTlfRep, _
                                                 sNumTlfCelRep, sTipSitFaxRep, sNumFaxRep, sCodSgmMcd, sNumInsInuNacSegSoc, _
                                                 sNomDepRep, sDatNscDep, sNumDocIdt, sNomOrgEmsDocIdtDep, sQdeFlhRep, sCodBcoRep, _
                                                 sCodAgeBcoRep, sCodCntCrrBcoRep, sNumDigVrfAgeBcoRep, sTipNatRep, sDesAcoTrbRep, _
                                                 sCodStaCadRep, sDatRgtRepCshReg, sCodEstUniCshReg, sTipSitPesJrCshReg, _
                                                 sCodEstUni, sNumRgtRepCshRep, sIndAcePnd, sIndVldCpf, sCodUndNgc, sTipFrmPgt, sVlrErr, oCnx)

            ' Insere na tabela de alteração de status
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                sVlrRetIsr = oObeIsrDdoRep.IsrDdoAltSta(sCodStaCadRep, sNumReqCttRep, sNomUsrUltAlt, sVlrErr, oCnx)
            End If

            ' Insere na tabela de territórios de representantes
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""

                oObeLetTxtMcoTetRep = New System.IO.StringReader(sTxtMcoTetRep)
                oGrpDdoTetRep.ReadXml(oObeLetTxtMcoTetRep)

                Try
                    If oGrpDdoTetRep.Tables(0).Rows.Count = 0 Then
                        sVlrErr = "O documento XML do Território dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                        Throw New Exception(sVlrErr)
                    End If
                Catch
                    sVlrErr = "O documento XML do Território dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End Try
            End If

            For iCntPrv = 0 To oGrpDdoTetRep.Tables(0).Rows.Count - 1
                sCodTetVnd = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(0)
                sAnoMesRef = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(1)
                sAnoMesRef.PadLeft(6, "0")
                sVlrVndTet = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(2)
                sVlrRetIsr = oObeIsrDdoRep.IsrDdoTetRep(sCodTetVnd, sNumReqCttRep, sAnoMesRef, sVlrVndTet, sVlrErr, oCnx)
            Next

            ' Insere na tabela de competências de representantes
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""

                oObeLetTxtMcoCtnRep = New System.IO.StringReader(sTxtMcoCtnRep)
                oGrpDdoCtnRep.ReadXml(oObeLetTxtMcoCtnRep)

                Try
                    If oGrpDdoCtnRep.Tables(0).Rows.Count = 0 Then
                        sVlrErr = "O documento XML das Competências dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                        Throw New Exception(sVlrErr)
                    End If
                Catch
                    sVlrErr = "O documento XML das Competências dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End Try

                For iCntPrv = 0 To oGrpDdoCtnRep.Tables(0).Rows.Count - 1
                    sCodCtnRep = oGrpDdoCtnRep.Tables(0).Rows(iCntPrv).Item(0)
                    sDesCdoCtnRep = oGrpDdoCtnRep.Tables(0).Rows(iCntPrv).Item(1)
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoCtnRep(sNumReqCttRep, sCodCtnRep, sDesCdoCtnRep, sVlrErr, oCnx)
                Next
            End If

            ' Insere na tabela de avaliações de representantes
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""

                oObeLetTxtMcoAvlRep = New System.IO.StringReader(sTxtMcoAvlRep)
                oGrpDdoAvlRep.ReadXml(oObeLetTxtMcoAvlRep)

                Try
                    If oGrpDdoAvlRep.Tables(0).Rows.Count = 0 Then
                        sVlrErr = "O documento XML das Avaliações dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                        Throw New Exception(sVlrErr)
                    End If
                Catch
                    sVlrErr = "O documento XML das Avaliações dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End Try

                For iCntPrv = 0 To oGrpDdoAvlRep.Tables(0).Rows.Count - 1
                    sCodAvlRep = oGrpDdoAvlRep.Tables(0).Rows(iCntPrv).Item(0)
                    sDesCdoAvlRep = oGrpDdoAvlRep.Tables(0).Rows(iCntPrv).Item(1)
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoAvlRep(sNumReqCttRep, sCodAvlRep, sDesCdoAvlRep, sVlrErr, oCnx)
                Next
            End If
            ' Insere descrição de observação e fluxo
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                sVlrRetIsr = oObeIsrDdoRep.IsrDdoDesObs(sNumReqCttRep, "1", sDesObsFlu, sVlrRetIsr, oCnx)
            End If
            '' Insere observação de acertos pendentes
            'If sVlrRetIsr <> "" Then
            '    sVlrRetIsr = ""
            '    sVlrRetIsr = oObeIsrItfVAKRep.IsrDdoDesObs(sNumReqCttRep, "2", sDesAcePnd, sVlrRetIsr)
            'End If
            '' Insere observação de descrição do fluxo
            'If sVlrRetIsr <> "" Then
            '    sVlrRetIsr = ""
            '    sVlrRetIsr = oObeIsrItfVAKRep.IsrDdoDesObs(sNumReqCttRep, "2", sDesFlu, sVlrRetIsr)
            'End If

            ' =======================================================================
            ' Envia email para o gerente de vendas: GV
            ' =======================================================================
            sNomUsrRcf = oObeIsrDdoRep.CsnNomUsrRcf(sCodGerVnd, sVlrErr, oCnx)
            oObeLetTxtMcoNomUsr = New System.IO.StringReader(sNomUsrRcf)
            oGrpDdoNomUsr.ReadXml(oObeLetTxtMcoNomUsr)
            If oGrpDdoNomUsr.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do nome do gerente de vendas está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            sNomUsrRcf = oGrpDdoNomUsr.Tables(0).Rows(0).Item("nomusrrcf")
            ' Busca o nome do gerente de mercado (From)
            sNomGerMcd = oObeIsrDdoRep.CsnDdoGerMcd(sCodGerMcd, sVlrErr, oCnx)
            oObeLetTxtMcoNomGerMcd = New System.IO.StringReader(sNomGerMcd)
            oGrpDdoNomGerMcd.ReadXml(oObeLetTxtMcoNomGerMcd)
            If oGrpDdoNomGerMcd.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do nome do gerente de mercado está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            sNomGerMcd = oGrpDdoNomGerMcd.Tables(0).Rows(0).Item("nomsup")
            strServidorSMTP = "172.16.14.137"
            'strServidorSMTP = "smtp.pc24treynet"

            iNumReq = Int64.Parse(sNumReqCttRep)
            iNumReq = (iNumReq * iNumReq) + 168
            sNumReqCttRep = iNumReq.ToString
            strAssunto = "Cadastro de RCA"
            '' Inserido por André 30/08/2007
            '' Apura se o candidato foi aprovado automaticamente e notifica o GV via e-mail
            Dim strAvl As String = oObeIsrDdoRep.CsnRstPva(sNumCpfRep, sVlrErr, "", oCnx)
            Dim dsAvlRep As DataSet = New DataSet
            dsAvlRep.ReadXml(New System.IO.StringReader(strAvl))
            Dim notaMat As Decimal = 0
            Dim notaPort As Decimal = 0

            If (Not dsAvlRep Is Nothing) And (dsAvlRep.Tables(0).Rows.Count > 0) Then
                notaMat = dsAvlRep.Tables(0).Rows(0).Item(1)
                notaPort = dsAvlRep.Tables(0).Rows(1).Item(1)
            End If

            If sNomRep.Trim.Length > 30 Then
                sNomRep = sNomRep.Trim.Substring(0, 30)
            Else
                sNomRep = sNomRep.Trim
            End If

            Dim strMensagem(4) As String
            If notaMat >= 60 And notaPort >= 60 Then
                strAssunto = "Cadastro de RCA aprovado automaticamente - " & sNomRep
                strMensagem(0) = "O candidato a RCA " & sNomRep
                strMensagem(1) = "foi automaticamente aprovado devido a seu desempenho "
                strMensagem(2) = "nas provas de Língua Portuguesa e Matemática."
                strMensagem(3) = "Caso deseje verificar o andamento do fluxo, consulte o link abaixo:"
                strMensagem(4) = "http://sim/BO/DocVAKDetRep.aspx?NumReq=" & sNumReqCttRep
            Else
                strAssunto = "Cadastro de RCA aguardando sua aprovação - " & sNomRep
                strMensagem(0) = "O seguinte documento aguarda sua aprovação: "
                strMensagem(1) = " "
                strMensagem(2) = "Link para acesso ao documento:"
                strMensagem(3) = "http://sim/BO/DocVAKDetRep.aspx?NumReq=" & sNumReqCttRep
                strMensagem(4) = " "
            End If

            strDe = sNomUsrRcf.ToLower().Trim & "@martins.com.br"   'sNomGerVnd
            strPara = sNomUsrRcf.ToLower().Trim & "@martins.com.br"

            'strPara = "luciene@[9.1.1.1]"

            'cria BO
            'Dim iEnvMsg As Short
            'iEnvMsg = 0
            'iEnvMsg = EnvCre(strDe, strPara, mduFunGenEnvCre.EnuFrmCre.Txt, strAssunto, strMensagem, strServidorSMTP)
            'AppSettings("simBo") Link
            If TrabalhouMartins = True Then
                EnviarEmailAnalistaCredito(oCnx, _
                                           sCodGerMcd, _
                                           sNomRep, _
                                           sNumCpfRep, _
                                           CInt(sNumReqCttRep), _
                                           Link)
            Else

                Dim wsEmail As New Email.Email
                Dim Enderecos(1) As Email.EnderecoEmail
                Enderecos(0) = New Email.EnderecoEmail
                With Enderecos(0)
                    .Endereco = strDe
                    .TipoEndereco = Email.enmTipoEndereco.Remetente
                    .TipoEntidade = Email.enmTipoEntidade.Externo
                End With
                Enderecos(1) = New Email.EnderecoEmail
                With Enderecos(1)
                    .Endereco = strPara
                    .TipoEndereco = Email.enmTipoEndereco.Destinatario
                    .TipoEntidade = Email.enmTipoEntidade.Externo
                End With
                wsEmail.EmailEnviar(_ID_SISTEMA_EMAIL, strAssunto, Enderecos, strMensagem, "")

            End If
            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            'ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao inserir dados do representante. Entre em contato com o Administrador do Sistema!" & " " & oObeEcc.Message
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeIsrDdoRep = Nothing
        End Try
    End Function
#End Region

    'Envia email para os analistas de Credito.
    Public Sub EnviarEmailAnalistaCredito(ByRef oCnx As IAU013.UO_IAUCnxAcsDdo, _
                                          ByVal CodigoFuncionario As Integer, _
                                          ByVal NomeRep As String, _
                                          ByVal CPF As String, _
                                          ByVal NumeroRequerimento As Integer, _
                                          ByVal Endereco As String)
        Try

            Dim BO As New VAK019.DB_VAKAnsCrd
            Dim sVlrRet As String
            'Objeto para transformacao de String em xml
            Dim oObeLetTxt As System.IO.StringReader
            'Resultado das pesquisas de acao, fornecedor, comprador ...
            Dim oGrpDdo As DataSet
            Dim strAssunto As String
            sVlrRet = BO.CsnEmailAnalistaCredito("", oCnx)

            oObeLetTxt = New System.IO.StringReader(sVlrRet)
            oGrpDdo = New DataSet
            oGrpDdo.ReadXml(oObeLetTxt)
            Dim strMensagem(4) As String

            If oGrpDdo.Tables(0).Rows.Count > 0 Then

                strAssunto = " CADASTROFV - DOCUMENTO PARA APROVACAO  "
                strMensagem(0) = "Foi cadastrado um candidato que ja prestou servicos na empresa."
                strMensagem(1) = "Nome: " & NomeRep
                strMensagem(2) = "CPF: " & CPF
                strMensagem(3) = "Link para acesso ao documento: "
                strMensagem(4) = Endereco & NumeroRequerimento



                Dim wsEmail As New Email.Email
                Dim Enderecos(oGrpDdo.Tables(0).Rows.Count + 1) As Email.EnderecoEmail
                Enderecos(0) = New Email.EnderecoEmail
                With Enderecos(0)
                    .Endereco = CodigoFuncionario.ToString
                    .TipoEndereco = Email.enmTipoEndereco.Remetente
                    .TipoEntidade = Email.enmTipoEntidade.GerenteMercado
                End With
                For i As Integer = 0 To oGrpDdo.Tables(0).Rows.Count - 1
                    Enderecos(i + 1) = New Email.EnderecoEmail
                    With Enderecos(i + 1)
                        .Endereco = oGrpDdo.Tables(0).Rows(i)("ENDERECO")
                        .TipoEndereco = Email.enmTipoEndereco.Destinatario
                        .TipoEntidade = Email.enmTipoEntidade.Externo
                    End With
                Next

                wsEmail.EmailEnviar(_ID_SISTEMA_EMAIL, strAssunto, Enderecos, strMensagem, "")
            End If
        Catch ex As Exception
            Throw New Exception("Erro: " & ex.Message)
        End Try

    End Sub

#Region "---------------------- Insere Novos Dados Temporários do Representante --------------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Inserir novo registro de um mesmo RCA na tabela temporaria de representantes, 
    REM ''' com vinculo a requisicao anterior
    REM ''' </summary>
    REM ''' <param name="sTxtMcoRep">Dados do RCA em questao</param>
    REM ''' <param name="sNomUsrUltAlt">Usuario que fez a insercao do novo registro</param>
    REM ''' <param name="sTxtMcoTetRep">Dados relativos ao territorio de vendas do representante em questao</param>
    REM ''' <param name="sTxtMcoAvlRep">Dados relativos a avaliacao do RCA (provenientes do Formar)</param>
    REM ''' <param name="sDesObsFlu">Informacoes sobre o fluxo</param>
    REM ''' <param name="sNumReqAntCadRep">numero da requisicao atual (sera a requisicao anterior ao novo registro)</param>
    REM ''' <param name="sNumReqCadRep">parametro por referencia para retorno do numero da nova requisicao</param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	Autor : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function IsrDdoRepNvo(ByVal sTxtMcoRep As String, _
                                 ByVal sNomUsrUltAlt As String, _
                                 ByVal sTxtMcoTetRep As String, _
                                 ByVal sTxtMcoAvlRep As String, _
                                 ByVal sDesObsFlu As String, _
                                 ByVal sNumReqAntCadRep As String, _
                                 ByVal sDesObsOcl As String, _
                                 ByRef sNumReqCadRep As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        'objeto
        Dim oObeIsrDdoRep As DB_VAKRep

        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oObeLetTxtMcoTetRep As System.IO.StringReader
        Dim oObeLetTxtMcoCtnRep As System.IO.StringReader
        Dim oObeLetTxtMcoAvlRep As System.IO.StringReader
        Dim oObeLetTxtMcoNroReq As System.IO.StringReader
        Dim oObeLetTxtMcoNomUsr As System.IO.StringReader
        Dim oObeLetTxtMcoNomGerMcd As System.IO.StringReader
        ' Dataset
        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoTetRep As New DataSet
        Dim oGrpDdoCtnRep As New DataSet
        Dim oGrpDdoAvlRep As New DataSet
        Dim oGrpDdoNroReq As New DataSet
        Dim oGrpDdoNomUsr As New DataSet
        Dim oGrpDdoNomGerMcd As New DataSet
        'valores de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim sVlrRetIsr As String

        'dados da tabela temporária de representantes
        Dim sNumReqCttRep As String
        Dim sNumCpfRep As String
        Dim sNumDocIdtRep As String
        Dim sNomOrgEmsDocIdtRep As String
        Dim sNomRep As String
        Dim sDatSlc As String
        Dim sDatEftFim As String
        Dim sCodGerMcd As String
        Dim sCodGerVnd As String
        Dim sCodSitRep As String
        Dim sTipRep As String
        Dim sCodGrpVndRep As String
        Dim sCodGerTrp As String
        Dim sCodRegCob As String
        Dim sCodSex As String
        Dim sDatNscRep As String
        Dim sNomNacRep As String
        Dim sTipEstCvlRep As String
        Dim sCodGraEclRep As String
        Dim sTipSitEclRep As String
        Dim sEndRep As String
        Dim sCodBai As String
        Dim sCodCplBai As String
        Dim sCodEstUni As String
        Dim sCodCidRep As String
        Dim sCodCepRep As String
        Dim sTipSitRsiRep As String
        Dim sTipVtgRsiRep As String
        Dim sTipSitTlfRep As String
        Dim sNumTlfRep As String
        Dim sNumTlfCelRep As String
        Dim sTipSitFaxRep As String
        Dim sNumFaxRep As String
        Dim sTipSitRepCshReg As String
        Dim sCodSgmMcd As String
        Dim sNumInsInuNacSegSoc As String
        Dim sNomDepRep As String
        Dim sDatNscDep As String
        Dim sNumDocIdt As String
        Dim sNomOrgEmsDocIdtDep As String
        Dim sQdeFlhRep As String
        Dim sCodBcoRep As String
        Dim sCodAgeBcoRep As String
        Dim sCodCntCrrBcoRep As String
        Dim sNumDigVrfAgeBcoRep As String
        Dim sTipNatRep As String
        Dim sDesAcoTrbRep As String
        Dim sCodStaCadRep As String
        Dim sNumRgtRepCshReg As String
        Dim sDatRgtRepCshReg As String
        Dim sCodEstUniCshReg As String
        Dim sTipSitPesJurCshReg As String
        Dim sQdeOcoRcm As String
        Dim sVlrTotRcm As String
        Dim sQdeOcoAcoCvl As String
        Dim sQdeTitVncNaoPgo As String
        Dim sQdeOcoChqSemFnd As String
        Dim sDatUltOcoChqSemFnd As String
        Dim sNomBcoUltChqSemFnd As String
        Dim sDatHraRcbInfCrd As String
        Dim sIndRtcCrd As String
        Dim sIndAcePnd As String
        Dim sIndVldCpf As String
        Dim sCodUndNgc As String
        Dim sNomUltChqSemFnd As String
        Dim sTipFrmPgt As String


        Dim sUltCodStaCadRep As String  REM codigo do ultimo status da requisicao nova (copia da antiga)

        'dados da tabela de territórios do representante
        Dim sCodTetVnd, sAnoMesRef, sVlrVndTet As String

        'dados da tabela de competências do representante
        Dim sCodCtnRep, sDesCdoCtnRep, sVlrCtnRep As String

        'dados da tabela de avaliações do representante
        Dim sCodAvlRep, sDesCdoAvlRep As String

        'nome do usuário de rede e dados para envio de email
        Dim sNomUsrRcf, sNomGerMcd, strAssunto, strServidorSMTP, strDe, strPara As String

        Dim dVlrPrv As Double
        Dim iCntPrv As Integer
        Dim iNumReq As Int64
        Try
            sVlrRet = ""
            sNumReqCttRep = ""
            oObeLetTxtMco = New System.IO.StringReader(sTxtMcoRep)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            'executa db
            oObeIsrDdoRep = New DB_VAKRep

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' -----------------------------------
            ' Campos da tabela MRT.T0150415
            ' -----------------------------------
            ' Obtem o proximo Numero de Requisicao (o maior + 1)
            sNumReqCttRep = oObeIsrDdoRep.CsnNroReq(sVlrErr, oCnx)

            oObeLetTxtMcoNroReq = New System.IO.StringReader(sNumReqCttRep)
            oGrpDdoNroReq.ReadXml(oObeLetTxtMcoNroReq)
            sNumReqCttRep = oGrpDdoNroReq.Tables(0).Rows(0).Item(0)
            sNumReqCadRep = sNumReqCttRep                      ' Guarda o novo numero de requisicao

            ' Status retornaveis : sUltCodStaCadRep = ("", "1", "2", "3", "6")
            sUltCodStaCadRep = CpiDdoSta(sNumReqAntCadRep, sNumReqCadRep, sNomUsrUltAlt, oCnx)

            Select Case sUltCodStaCadRep
                Case "1"
                    sCodStaCadRep = "1"
                    ' status 1 --> Requisicao ressubmetida pelo Analista de Credito <<<<>>>>>
                    ' a partir da requisicao <<<<>>>>
                Case "2"
                    sCodStaCadRep = "6"    ' ok
                Case "3"
                    sCodStaCadRep = "8"    ' ok 
                Case "6"
                    sCodStaCadRep = "8"
                Case Else
                    sCodStaCadRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodStaCadRep") ' campo NOT NULL na tabela
            End Select
            ' -------------------------------------------------------------
            ' Obtencao dos dados do candidato a RCA (tela de apresentacao).
            ' -------------------------------------------------------------
            sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item("NUMCPFREP")
            sNumDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumDocIdtRep") ' campo NOT NULL na tabela
            sNomOrgEmsDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomOrgEmsDocIdtRep") ' campo NOT NULL na tabela
            sNomRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomRep") ' campo NOT NULL na tabela
            sCodGerMcd = oGrpDdoRep.Tables(0).Rows(0).Item("CodGerMcd") ' campo NOT NULL na tabela
            sCodGerVnd = oGrpDdoRep.Tables(0).Rows(0).Item("CodGerVnd") ' campo NOT NULL na tabela
            sCodSex = oGrpDdoRep.Tables(0).Rows(0).Item("CodSex") ' campo NOT NULL na tabela
            sDatNscRep = oGrpDdoRep.Tables(0).Rows(0).Item("DatNscRep") ' campo NOT NULL na tabela

            ' --> NomNacRep
            sNomNacRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomNacRep") ' campo NOT NULL na tabela
            Dim sNomAcsRep As String = sNomNacRep

            sTipEstCvlRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipEstCvlRep") ' campo NOT NULL na tabela
            sCodGraEclRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodGraEclRep") ' campo NOT NULL na tabela
            sTipSitEclRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitEclRep") ' campo NOT NULL na tabela
            sEndRep = oGrpDdoRep.Tables(0).Rows(0).Item("EndRep") ' campo NOT NULL na tabela
            sCodBai = oGrpDdoRep.Tables(0).Rows(0).Item("CodBai") ' campo NOT NULL na tabela
            sCodCplBai = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("CodCplBai")) ' OK

            sCodCidRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodCidRep") ' campo NOT NULL na tabela
            sCodCepRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodCepRep") ' campo NOT NULL na tabela
            sTipSitRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitRsiRep") ' campo NOT NULL na tabela
            sTipVtgRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipVtgRsiRep") ' campo NOT NULL na tabela
            sTipSitTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("TipSitTlfRep")) ' OK
            sNumTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumTlfRep")) ' OK
            sNumTlfCelRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumTlfCelRep")) ' OK
            sTipSitFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("TipSitFaxRep")) ' OK
            sNumFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumFaxRep")) ' OK            sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item(24) ' campo NOT NULL na tabela
            sNumInsInuNacSegSoc = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumInsInuNacSegSoc")) ' OK
            sNomDepRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NomDepRep")) ' OK
            sDatNscDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatNscDep")) ' OK
            sNumDocIdt = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumDocIdt")) ' OK
            sNomOrgEmsDocIdtDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NomOrgEmsDocIdtDep")) ' OK
            sQdeFlhRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("QdeFlhRep")) ' OK
            sCodBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodBcoRep") ' campo NOT NULL na tabela
            sCodAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodAgeBcoRep") ' campo NOT NULL na tabela
            sCodCntCrrBcoRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("CodCntCrrBcoRep")) ' OK

            sNumDigVrfAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumDigVrfAgeBcoRep") ' campo NOT NULL na tabela
            sTipNatRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipNatRep") ' campo NOT NULL na tabela

            ' --> 
            sDesAcoTrbRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DesAcoTrbRep"))

            sDatRgtRepCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatRgtRepCshReg")) ' OK
            sCodEstUniCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("CodEstUniCshReg")) ' OK
            If (oGrpDdoRep.Tables(0).Rows(0).Item("TipSitPesJurCshReg") = "") Then
                sTipSitPesJurCshReg = " "
            Else
                sTipSitPesJurCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitPesJurCshReg") ' OK
            End If

            sCodEstUni = oGrpDdoRep.Tables(0).Rows(0).Item("CodEstUni") ' campo NOT NULL na tabela
            sNumRgtRepCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NumRgtRepCshReg")) ' OK
            sIndAcePnd = oGrpDdoRep.Tables(0).Rows(0).Item("IndAcePnd") ' campo NOT NULL na tabela
            sIndVldCpf = oGrpDdoRep.Tables(0).Rows(0).Item("IndVldCpf") ' campo NOT NULL na tabela
            sCodUndNgc = oGrpDdoRep.Tables(0).Rows(0).Item("CodUndNgc") ' campo NOT NULL na tabela
            sTipFrmPgt = oGrpDdoRep.Tables(0).Rows(0).Item("TipFrmPgt") ' campo NOT NULL na tabela


            sDatSlc = oGrpDdoRep.Tables(0).Rows(0).Item("DatSlc") ' NOT NULL
            sDatEftFim = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatEftFim")) ' OK
            sCodSitRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodSitRep") ' NOT NULL
            sTipRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipRep") ' NOT NULL
            sCodGrpVndRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodGrpVndRep") ' NOT NULL
            sCodGerTrp = oGrpDdoRep.Tables(0).Rows(0).Item("CodGerTrp") ' NOT NULL
            sCodRegCob = oGrpDdoRep.Tables(0).Rows(0).Item("CodRegCob") ' NOT NULL
            sTipSitRepCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitRepCshReg") ' NOT NULL
            sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item("CodSgmMcd") ' NOT NULL
            sQdeOcoRcm = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("QdeOcoRcm")) ' OK

            sVlrTotRcm = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("VlrTotRcm")) ' OK
            If sVlrTotRcm.IndexOf(",") > 0 Then
                sVlrTotRcm = sVlrTotRcm.Replace(".", "").Replace(",", ".")
            End If

            sQdeOcoAcoCvl = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("QdeOcoAcoCvl")) ' OK
            sQdeTitVncNaoPgo = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("QdeTitVncNaoPgo")) ' OK
            sQdeOcoChqSemFnd = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("QdeOcoChqSemFnd")) ' OK
            sDatUltOcoChqSemFnd = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatUltOcoChqSemFnd")) ' OK
            sNomBcoUltChqSemFnd = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NomBcoUltChqSemFnd")) ' OK
            sDatHraRcbInfCrd = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatHraRcbInfCrd")) ' OK
            sIndRtcCrd = oGrpDdoRep.Tables(0).Rows(0).Item("IndRtcCrd") ' NOT NULL
            sNomUltChqSemFnd = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("NomUltChqSemFnd")) ' OK


            ' Insere dados na tabela temporária de representantes [mrt.t0150415]
            sVlrRetIsr = oObeIsrDdoRep.IsrDdoRepNvo(sNumReqCttRep, _
                                              sNumCpfRep, _
                                              sNumDocIdtRep, _
                                              sNomOrgEmsDocIdtRep, _
                                              sNomRep, _
                                              sDatSlc, _
                                              sDatEftFim, _
                                              sCodGerMcd, _
                                              sCodGerVnd, _
                                              sCodSitRep, _
                                              sTipRep, _
                                              sCodGrpVndRep, _
                                              sCodGerTrp, _
                                              sCodRegCob, _
                                              sCodSex, _
                                              sDatNscRep, _
                                              sNomNacRep, _
                                              sTipEstCvlRep, _
                                              sCodGraEclRep, _
                                              sTipSitEclRep, _
                                              sEndRep, _
                                              sCodBai, _
                                              sCodCplBai, _
                                              sCodEstUni, _
                                              sCodCidRep, _
                                              sCodCepRep, _
                                              sTipSitRsiRep, _
                                              sTipVtgRsiRep, _
                                              sTipSitTlfRep, _
                                              sNumTlfRep, _
                                              sNumTlfCelRep, _
                                              sTipSitFaxRep, _
                                              sNumFaxRep, _
                                              sTipSitRepCshReg, _
                                              sCodSgmMcd, _
                                              sNumInsInuNacSegSoc, _
                                              sNomDepRep, _
                                              sDatNscDep, _
                                              sNumDocIdt, _
                                              sNomOrgEmsDocIdtDep, _
                                              sQdeFlhRep, _
                                              sCodBcoRep, _
                                              sCodAgeBcoRep, _
                                              sCodCntCrrBcoRep, _
                                              sNumDigVrfAgeBcoRep, _
                                              sTipNatRep, _
                                              sDesAcoTrbRep, _
                                              sCodStaCadRep, _
                                              sNumRgtRepCshReg, _
                                              sDatRgtRepCshReg, _
                                              sCodEstUniCshReg, _
                                              sTipSitPesJurCshReg, _
                                              sQdeOcoRcm, _
                                              sVlrTotRcm, _
                                              sQdeOcoAcoCvl, _
                                              sQdeTitVncNaoPgo, _
                                              sQdeOcoChqSemFnd, _
                                              sDatUltOcoChqSemFnd, _
                                              sNomBcoUltChqSemFnd, _
                                              sDatHraRcbInfCrd, _
                                              sIndRtcCrd, _
                                              sIndAcePnd, _
                                              sIndVldCpf, _
                                              sCodUndNgc, _
                                              sNomUltChqSemFnd, _
                                              sTipFrmPgt, _
                                              sNumReqAntCadRep, _
                                              sVlrErr, oCnx)

            ' Insere na tabela de alteração de status [mrt.t0150350]
            If sVlrRetIsr <> "" And sCodStaCadRep <> "1" Then
                sVlrRetIsr = ""
                sVlrRetIsr = oObeIsrDdoRep.IsrDdoAltSta(sCodStaCadRep, sNumReqCttRep, sNomUsrUltAlt, sVlrErr, oCnx)
            End If

            ' Insere na tabela de territórios de representantes [mrt.t0150377]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""

                oObeLetTxtMcoTetRep = New System.IO.StringReader(sTxtMcoTetRep)
                oGrpDdoTetRep.ReadXml(oObeLetTxtMcoTetRep)

                'fixo
                If oGrpDdoTetRep.Tables(0).Rows.Count = 0 Then
                    sVlrErr = "O documento XML do Território dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End If
                For iCntPrv = 0 To oGrpDdoTetRep.Tables(0).Rows.Count - 1
                    sCodTetVnd = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(0)
                    sAnoMesRef = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(1)
                    sVlrVndTet = oGrpDdoTetRep.Tables(0).Rows(iCntPrv).Item(2)
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoTetRep(sCodTetVnd, sNumReqCttRep, sAnoMesRef, sVlrVndTet, sVlrErr, oCnx)
                Next
            End If

            'Insere na tabela de competências de representantes [mrt.t0150652]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                Dim sTxtMcoCtnRep As String
                sTxtMcoCtnRep = oObeIsrDdoRep.CsnDdoCtn(sNumReqAntCadRep, sVlrErr, oCnx)
                Dim ds As New DataSet
                ds.ReadXml(New System.IO.StringReader(sTxtMcoCtnRep))
                If ds.Tables(0).Rows.Count = 0 Then
                    sVlrErr = "O documento XML das Competências dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End If
                For iCntPrv = 0 To ds.Tables(0).Rows.Count - 1
                    sCodCtnRep = ds.Tables(0).Rows(iCntPrv).Item(0)
                    sVlrCtnRep = ds.Tables(0).Rows(iCntPrv).Item(2)
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoCtnRep(sNumReqCadRep, sCodCtnRep, sVlrCtnRep, sVlrErr, oCnx)
                Next
            End If ' sVlrRetIsr de Competencias


            ' Insere na tabela de avaliações de representantes [mrt.t0150466]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""

                oObeLetTxtMcoAvlRep = New System.IO.StringReader(sTxtMcoAvlRep)
                oGrpDdoAvlRep.ReadXml(oObeLetTxtMcoAvlRep)

                If oGrpDdoAvlRep.Tables(0).Rows.Count = 0 Then
                    sVlrErr = "O documento XML das Avaliações dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End If

                For iCntPrv = 0 To oGrpDdoAvlRep.Tables(0).Rows.Count - 1
                    sCodAvlRep = oGrpDdoAvlRep.Tables(0).Rows(iCntPrv).Item("CODAVLREP")
                    sDesCdoAvlRep = oGrpDdoAvlRep.Tables(0).Rows(iCntPrv).Item("DESCDOAVLREP")
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoAvlRep(sNumReqCttRep, sCodAvlRep, sDesCdoAvlRep, sVlrErr, oCnx)
                Next
            End If
            ' Insere descrição de observação e fluxo [mrt.t0150610]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                ' Obtem o proximo numero da sequencia
                sVlrRetIsr = oObeIsrDdoRep.CnsCodSeqObs(sNumReqCttRep, sVlrErr, oCnx)
                Dim d As DataSet = New DataSet
                d.ReadXml(New System.IO.StringReader(sVlrRetIsr))
                sVlrRetIsr = ""
                Dim sCodSeqObs As String = d.Tables(0).Rows(0).Item(0)
                d = Nothing
                ' Insere na tabela              
                sVlrRetIsr = oObeIsrDdoRep.IsrDdoDesObs(sNumReqCttRep, sCodSeqObs, RetVlrSpace(sDesObsFlu), sVlrRetIsr, oCnx)
            End If

            'Insere na tabela de Protestos [mrt.t0150520]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                Dim sTxtMcoRcmRep As String
                sTxtMcoRcmRep = oObeIsrDdoRep.CsnDdoRcm(sNumReqAntCadRep, sVlrErr, oCnx)
                Dim ds As New DataSet
                ds.ReadXml(New System.IO.StringReader(sTxtMcoRcmRep))
                'If ds.Tables(0).Rows.Count = 0 Then
                '    sVlrErr = "O documento XML de Protestos do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                '    Throw New Exception(sVlrErr)
                'End If

                Dim sCodSeqRcm, DatOcoRcm, VlrOcoRcm, NomCidEtbOcoRcm, CodEstUniOcoRcm, NumEtbOcoRcm, NomEtbOcoRcm As String
                For iCntPrv = 0 To ds.Tables(0).Rows.Count - 1
                    sCodSeqRcm = (ds.Tables(0).Rows(iCntPrv).Item(0))
                    DatOcoRcm = (ds.Tables(0).Rows(iCntPrv).Item(1))
                    VlrOcoRcm = (ds.Tables(0).Rows(iCntPrv).Item(2))
                    If VlrOcoRcm.IndexOf(",") > 0 Then
                        VlrOcoRcm = VlrOcoRcm.Replace(".", "").Replace(",", ".")
                    End If
                    NomCidEtbOcoRcm = Trim((ds.Tables(0).Rows(iCntPrv).Item(3)))
                    CodEstUniOcoRcm = Trim((ds.Tables(0).Rows(iCntPrv).Item(4)))
                    NumEtbOcoRcm = (ds.Tables(0).Rows(iCntPrv).Item(5))
                    NomEtbOcoRcm = Trim((ds.Tables(0).Rows(iCntPrv).Item(6)))
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoRcm(sNumReqCadRep, sCodSeqRcm, DatOcoRcm, VlrOcoRcm, NomCidEtbOcoRcm, CodEstUniOcoRcm, NumEtbOcoRcm, NomEtbOcoRcm, sVlrErr, oCnx)
                Next
            End If ' sVlrRetIsr de Protestos

            'Insere na tabela de Acao Civil [mrt.t0150547]
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                Dim sTxtMcoAcoCvlRep As String
                sTxtMcoAcoCvlRep = oObeIsrDdoRep.CsnDdoAcoCvl(sNumReqAntCadRep, sVlrErr, oCnx)
                Dim ds As New DataSet
                ds.ReadXml(New System.IO.StringReader(sTxtMcoAcoCvlRep))

                Dim sCodSeqAcoCvl, sTipAcoCvl, sDatOcoAcoCvl, sNomCidOcoAcoCvlRep, sCodEstUniOcoAcoCvl, sNumEtbAcoCvl, sNomCriAcoCvl, sNomPesRcbAcoCvl As String
                For iCntPrv = 0 To ds.Tables(0).Rows.Count - 1
                    sCodSeqAcoCvl = (ds.Tables(0).Rows(iCntPrv).Item(1))
                    sTipAcoCvl = (ds.Tables(0).Rows(iCntPrv).Item(2))
                    sDatOcoAcoCvl = (ds.Tables(0).Rows(iCntPrv).Item(3))
                    sNomCidOcoAcoCvlRep = Trim((ds.Tables(0).Rows(iCntPrv).Item(4)))
                    sCodEstUniOcoAcoCvl = Trim((ds.Tables(0).Rows(iCntPrv).Item(5)))
                    sNumEtbAcoCvl = (ds.Tables(0).Rows(iCntPrv).Item(6))
                    sNomCriAcoCvl = Trim((ds.Tables(0).Rows(iCntPrv).Item(7)))
                    sNomPesRcbAcoCvl = Trim((ds.Tables(0).Rows(iCntPrv).Item(8)))
                    sVlrRetIsr = oObeIsrDdoRep.IsrDdoAcoCvl(sNumReqCttRep, sCodSeqAcoCvl, sTipAcoCvl, sDatOcoAcoCvl, sNomCidOcoAcoCvlRep, sCodEstUniOcoAcoCvl, sNumEtbAcoCvl, sNomCriAcoCvl, sNomPesRcbAcoCvl, sVlrErr, oCnx)
                Next
            End If ' sVlrRetIsr de Acao Civil

            ' Envia email para o gerente de vendas: GV
            sNomUsrRcf = oObeIsrDdoRep.CsnNomUsrRcf(sCodGerVnd, sVlrErr, oCnx)
            oObeLetTxtMcoNomUsr = New System.IO.StringReader(sNomUsrRcf)
            oGrpDdoNomUsr.ReadXml(oObeLetTxtMcoNomUsr)
            If oGrpDdoNomUsr.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do nome do gerente de vendas está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            sNomUsrRcf = oGrpDdoNomUsr.Tables(0).Rows(0).Item("nomusrrcf")
            ' Busca o nome do gerente de mercado (From)
            sNomGerMcd = oObeIsrDdoRep.CsnDdoGerMcd(sCodGerMcd, sVlrErr, oCnx)
            oObeLetTxtMcoNomGerMcd = New System.IO.StringReader(sNomGerMcd)
            oGrpDdoNomGerMcd.ReadXml(oObeLetTxtMcoNomGerMcd)
            If oGrpDdoNomGerMcd.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do nome do gerente de mercado está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            sNomGerMcd = oGrpDdoNomGerMcd.Tables(0).Rows(0).Item("nomsup")
            strServidorSMTP = "172.16.14.137"
            'strServidorSMTP = "smtp.pc24treynet"

            iNumReq = Int64.Parse(sNumReqCttRep)
            iNumReq = (iNumReq * iNumReq) + 168
            sNumReqCttRep = iNumReq.ToString
            strAssunto = "Cadastro de RCA aguardando sua aprovação"
            Dim strMensagem(2) As String
            strMensagem(0) = "O seguinte documento está aguardando sua aprovação. "
            strMensagem(1) = "Link para acesso ao documento: "
            strMensagem(2) = "http://sim/BO/DocVAKDetRep.aspx?NumReq=" & sNumReqCttRep

            strDe = sNomUsrRcf.ToLower().Trim & "@martins.com.br"   'sNomGerVnd
            strPara = sNomUsrRcf.ToLower().Trim & "@martins.com.br"
            'strPara = "luciene@[9.1.1.1]"

            'cria BO

            'Dim iEnvMsg As Short
            'iEnvMsg = 0
            'iEnvMsg = EnvCre(strDe, strPara, mduFunGenEnvCre.EnuFrmCre.Txt, strAssunto, strMensagem, strServidorSMTP)
            Dim wsEmail As New Email.Email
            Dim Enderecos(1) As Email.EnderecoEmail
            Enderecos(0) = New Email.EnderecoEmail
            With Enderecos(0)
                .Endereco = strDe
                .TipoEndereco = Email.enmTipoEndereco.Remetente
                .TipoEntidade = Email.enmTipoEntidade.Externo
            End With
            Enderecos(1) = New Email.EnderecoEmail
            With Enderecos(1)
                .Endereco = strPara
                .TipoEndereco = Email.enmTipoEndereco.Destinatario
                .TipoEntidade = Email.enmTipoEntidade.Externo
            End With
            wsEmail.EmailEnviar(_ID_SISTEMA_EMAIL, strAssunto, Enderecos, strMensagem, "")
            oCnx.FimTscSuc()

            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao inserir dados do representante. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeIsrDdoRep = Nothing
        End Try
    End Function
#End Region


    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Copia as informacoes do historico de alteracoes de status de uma requisicao.
    REM ''' </summary>
    REM ''' <param name="sNumReqAnt">Codigo da requisicao original.</param>
    REM ''' <param name="sNumReq">Codigo da requisicao nova (ressubmetida).</param>
    REM ''' <param name="sNomUsrUltAlt"></param>
    REM ''' <returns>Codigo do ultimo status da requisicao anterior.</returns>
    REM ''' <remarks>
    REM ''' Efetua a copia das informacoes de alteracao de status para a requisicao ressubmetida.
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/22/2005	Created
    REM ''' </history>
    REM ''' ----------------------------------------------------------------------------- 
    Public Function CpiDdoSta(ByVal sNumReqAnt As String, ByVal sNumReq As String, ByVal sNomUsrUltAlt As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        Dim obeVAKRep As VAK019.DB_VAKRep
        Dim sVlrErr As String
        Dim sVlrRet As String
        Dim ds As DataSet
        Dim idx As Integer

        Dim sDesFluReq As String REM Descricao do fluxo para a requisicao
        Dim sDesStaReq As String REM Descricao dos status da requisicao
        Dim sUltCodStaCadRep As String REM ultimo status copiado
        Dim sCodStaCadRep As String

        Try

            sUltCodStaCadRep = ""
            obeVAKRep = New VAK019.DB_VAKRep

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            sDesStaReq = obeVAKRep.CsnTotDdoStaReq(sNumReqAnt, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sDesStaReq))
            If ds.Tables(0).Rows.Count > 0 Then
                For idx = 0 To ds.Tables(0).Rows.Count - 1
                    'sVlrRet = ds.Tables(0).Rows(idx).Item("NOMUSRULTALT")
                    sCodStaCadRep = ds.Tables(0).Rows(idx).Item("CODSTACADREP")
                    If (sCodStaCadRep <> "5") And (sCodStaCadRep <> "7") And (sCodStaCadRep <> "9") Then
                        Select Case sCodStaCadRep
                            Case "3"
                                sVlrRet = obeVAKRep.IsrDdoAltSta(sCodStaCadRep.Trim, sNumReq, sNomUsrUltAlt, sVlrErr, oCnx)
                            Case "4" REM copia o registro da aprovacao do GV para a nova reqisicao
                                Dim sNomUsr As String = ds.Tables(0).Rows(idx).Item("NOMUSRULTALT")
                                sVlrRet = obeVAKRep.IsrDdoAltSta(sCodStaCadRep.Trim, sNumReq, sNomUsr.Trim, sVlrErr, oCnx)
                                sNomUsr = Nothing

                                '' copia a descricao do fluxo
                                'CpiDesFlu(sNumReqAnt, sNumReq)
                            Case Else REM copia os demais status
                                sVlrRet = obeVAKRep.IsrDdoAltSta(sCodStaCadRep.Trim, sNumReq, sNomUsrUltAlt, sVlrErr, oCnx)
                        End Select
                        sUltCodStaCadRep = sCodStaCadRep.Trim
                        If sVlrErr <> "" Then
                            Throw New Exception(sVlrErr)
                        End If
                    End If
                Next

                ' copia a descricao do fluxo
                sDesStaReq = obeVAKRep.IsrDdoDesObsNvo(sNumReqAnt, sNumReq, sVlrErr, oCnx)
                If sVlrErr <> "" Then
                    Throw New Exception(sVlrErr)
                End If
            End If
            oCnx.FimTscSuc()

            Return sUltCodStaCadRep
        Catch ex As Exception
            oCnx.FimTscErr()
            Throw New Exception(ex.Message)
        Finally
            oCnx.Dispose()
            obeVAKRep = Nothing
            sVlrErr = Nothing
            sVlrRet = Nothing
            sCodStaCadRep = Nothing
            ds = Nothing
            idx = Nothing
        End Try
    End Function

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Copia as observaces do fluxo, segundo o padrao "APROVADO PELO GERENTE DE VENDAS"
    REM ''' </summary>
    REM ''' <param name="sNumReqAnt">Codigo da requisicao original.</param>
    REM ''' <param name="sNumReqNvo">Codigo da requisicao nova (ressubmetida).</param>
    REM ''' <remarks>
    REM ''' Subrotina auxiliar para copia de registros do fluxo, quando uma dada requisicao estiver em ressubmissao.
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/24/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Sub CpiDesFlu(ByVal sNumReqAnt As String, ByVal sNumReqNvo As String)
        Dim sVlrRet As String
        Dim sVlrErr As String

        Dim obeItfVAKRep As New VAK019.DB_VAKRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim dSet As DataSet

        Dim i As Int32
        Dim sDESOBS As String
        Dim sCodSeqObs As String
        Try

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Obtem o item do fluxo que contenha REPROVADO na descricao
            sVlrRet = obeItfVAKRep.CsnObsGerVndDesObs(sNumReqAnt, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            dSet = New DataSet
            dSet.ReadXml(New System.IO.StringReader(sVlrRet))
            sVlrRet = ""
            sCodSeqObs = dSet.Tables(0).Rows(0).Item("CODSEQOBS")

            If dSet.Tables(0).Rows.Count > 0 Then

                For i = 0 To dSet.Tables(0).Rows.Count - 1
                    sDESOBS = dSet.Tables(0).Rows(i).Item("DESOBS")

                    sDESOBS = ppctxt(sDESOBS)

                    ' Obtem o proximo numero da sequencia
                    sVlrRet = obeItfVAKRep.CnsCodSeqObs(sNumReqNvo, sVlrErr, oCnx)
                    Dim d As DataSet = New DataSet
                    d.ReadXml(New System.IO.StringReader(sVlrRet))
                    sVlrRet = ""
                    sCodSeqObs = d.Tables(0).Rows(0).Item(0)
                    d = Nothing
                    ' Insere na tabela
                    sVlrRet = obeItfVAKRep.IsrDdoDesObs(sNumReqNvo, sCodSeqObs, sDESOBS, sVlrErr, oCnx)
                    If sVlrErr <> "" Then
                        Throw New Exception(sVlrErr)
                    End If
                    sCodSeqObs = ""
                Next
            End If
            oCnx.FimTscSuc()
        Catch ex As Exception
            oCnx.FimTscErr()
            Throw New Exception(ex.Message)
        Finally
            oCnx.Dispose()
            sVlrRet = Nothing
            sVlrErr = Nothing
            obeItfVAKRep = Nothing
            dSet = Nothing
            i = Nothing
            sDESOBS = Nothing
        End Try

    End Sub

#Region "---------------------- Altera Dados do Representante --------------------"

    Public Function AltDdoRep(ByVal sTxtMcoRep As String, ByVal sNomUsrUltAlt As String, ByVal sTxtMcoTetRep As String, ByVal sTxtMcoCtnRep As String, ByVal sNumReqCadRep As String, ByVal sTxtMcoAvlRep As String, ByVal sDesFlu As String) As String

        Dim oObeAltItfVAKRep As New DB_VAKRep

        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oObeLetTxtMcoTetRep As System.IO.StringReader
        Dim oObeLetTxtMcoCtnRep As System.IO.StringReader
        Dim oObeLetTxtMcoAvlRep As System.IO.StringReader
        Dim oObeLetTxtMcoSta As System.IO.StringReader

        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoSta As New DataSet
        Dim oGrpDdoTetRep As New DataSet
        Dim oGrpDdoCtnRep As New DataSet
        Dim oGrpDdoAvlRep As New DataSet

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim sVlrRetAlt, sVlrRetCsn As String

        'dados da tabela temporária de representantes
        Dim sNumCpfRep, sNumDocIdtRep, sNomOrgEmsDocIdtRep, sNomRep, sCodGerMcd As String
        Dim sCodGerVnd, sCodSex, sDatNscRep, sNomAcsRep, sTipEstCvlRep, sCodGraEclRep As String
        Dim sTipSitEclRep, sEndRep, sCodBai, sCodCplBai, sCodCidRep, sCodCepRep, sTipSitRsiRep As String
        Dim sTipVtgRsiRep, sTipSitTlfRep, sNumTlfRep, sNumTlfCelRep, sTipSitFaxRep, sNumFaxRep As String
        Dim sCodSgmMcd, sNumInsInuNacSegSoc, sNomDepRep As String
        Dim sDatNscDep, sNumDocIdt, sNomOrgEmsDocIdtDep, sQdeFlhRep, sCodBcoRep, sCodAgeBcoRep As String
        Dim sCodCntCrrBcoRep, sNumDigVrfAgeBcoRep, sTipNatRep, sDesAcoTrbRep, sCodStaCadRep As String
        Dim sDatRgtRepCshReg, sCodEstUniCshReg, sTipSitPesJrCshReg, sTipSitRepCshReg, sTipFrmPgt As String

        Dim sCodEstUni, sNumRgtRepCshRep, sIndAcePnd, sIndVldCpf, sCodUndNgc, sIndRtcCrd As String

        'dados da tabela de territórios do representante
        Dim sCodTetVnd, sAnoMesRef, sVlrVndTet As String

        'dados da tabela de competências do representante
        Dim sCodCtnRep, sDesCdoCtnRep As String

        'dados da tabela de avaliações do representante
        Dim sCodAvlRep, sDesCdoAvlRep As String

        Dim dVlrPrv As Double
        Dim iCntPrv As Integer

        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try

            sVlrRet = ""

            'Cria DB

            oObeLetTxtMco = New System.IO.StringReader(sTxtMcoRep)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            ' -----------------------------------
            ' Campos da tabela MRT.T0150415
            ' -----------------------------------
            sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item(0) ' campo NOT NULL na tabela
            sNumDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(1) ' campo NOT NULL na tabela
            sNomOrgEmsDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(2) ' campo NOT NULL na tabela
            sNomRep = oGrpDdoRep.Tables(0).Rows(0).Item(3) ' campo NOT NULL na tabela
            sCodGerMcd = oGrpDdoRep.Tables(0).Rows(0).Item(4) ' campo NOT NULL na tabela
            sCodGerVnd = oGrpDdoRep.Tables(0).Rows(0).Item(5) ' campo NOT NULL na tabela
            sCodSex = oGrpDdoRep.Tables(0).Rows(0).Item(6) ' campo NOT NULL na tabela
            sDatNscRep = oGrpDdoRep.Tables(0).Rows(0).Item(7) ' ok

            ' --> NomNacRep
            sNomAcsRep = oGrpDdoRep.Tables(0).Rows(0).Item(8) ' campo NOT NULL na tabela

            sTipEstCvlRep = oGrpDdoRep.Tables(0).Rows(0).Item(9) ' campo NOT NULL na tabela
            sCodGraEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(10) ' campo NOT NULL na tabela
            sTipSitEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(11) ' campo NOT NULL na tabela
            sEndRep = oGrpDdoRep.Tables(0).Rows(0).Item(12) ' campo NOT NULL na tabela
            sCodBai = oGrpDdoRep.Tables(0).Rows(0).Item(13) ' campo NOT NULL na tabela
            sCodCplBai = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(14)) ' ok
            sCodCidRep = oGrpDdoRep.Tables(0).Rows(0).Item(15) ' campo NOT NULL na tabela
            sCodCepRep = oGrpDdoRep.Tables(0).Rows(0).Item(16) ' campo NOT NULL na tabela
            sTipSitRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(17) ' campo NOT NULL na tabela
            sTipVtgRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(18) ' campo NOT NULL na tabela

            ' Telefone do RCA
            sTipSitTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(19)) ' ok
            sNumTlfRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(20)) ' ok
            ' FAX do RCA
            sTipSitFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(22)) ' ok
            sNumFaxRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(23)) ' ok
            ' Celular do RCA
            sNumTlfCelRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(21)) ' ok

            sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item(24) ' campo NOT NULL na tabela
            sNumInsInuNacSegSoc = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(25)) ' ok
            sNomDepRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(26)) ' ok
            sDatNscDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(27)) ' ok
            sNumDocIdt = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(28)) ' ok
            sNomOrgEmsDocIdtDep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(29)) ' ok
            sQdeFlhRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(30)) ' ok

            sCodBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(31)) ' campo NOT NULL na tabela
            sCodAgeBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(32)) ' campo NOT NULL na tabela
            sCodCntCrrBcoRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(33)) ' ok
            sNumDigVrfAgeBcoRep = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(34))        ' campo NOT NULL na tabela

            sTipNatRep = oGrpDdoRep.Tables(0).Rows(0).Item(35) ' campo NOT NULL na tabela

            ' --> 
            sDesAcoTrbRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(36))

            sCodStaCadRep = oGrpDdoRep.Tables(0).Rows(0).Item(37) ' campo NOT NULL na tabela
            sDatRgtRepCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(38)) ' ok
            sCodEstUniCshReg = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(39)) ' ok
            If (oGrpDdoRep.Tables(0).Rows(0).Item(40) = "") Then
                sTipSitPesJrCshReg = " "
            Else
                sTipSitPesJrCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(40) ' ok
            End If
            sTipSitRepCshReg = RetVlrSpace(oGrpDdoRep.Tables(0).Rows(0).Item(41))

            sCodEstUni = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(42)) ' campo NOT NULL na tabela
            sNumRgtRepCshRep = RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(43)) ' ok
            sIndAcePnd = oGrpDdoRep.Tables(0).Rows(0).Item(44) ' campo NOT NULL na tabela
            sIndVldCpf = oGrpDdoRep.Tables(0).Rows(0).Item(45) ' campo NOT NULL na tabela
            sCodUndNgc = oGrpDdoRep.Tables(0).Rows(0).Item(46) ' campo NOT NULL na tabela
            sTipFrmPgt = oGrpDdoRep.Tables(0).Rows(0).Item(47) ' campo NOT NULL na tabela
            sIndRtcCrd = oGrpDdoRep.Tables(0).Rows(0).Item(48) ' campo NOT NULL na tabela

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()


            ' Altera dados na tabela temporária de representantes
            sVlrRetAlt = oObeAltItfVAKRep.AltDdoRep(sNumReqCadRep, sNumCpfRep, sNumDocIdtRep, sNomOrgEmsDocIdtRep, _
                                                 sNomRep, sCodGerMcd, sCodGerVnd, sCodSex, sDatNscRep, sNomAcsRep, _
                                                 sTipEstCvlRep, sCodGraEclRep, sTipSitEclRep, sEndRep, sCodBai, sCodCplBai, _
                                                 sCodCidRep, sCodCepRep, sTipSitRsiRep, sTipVtgRsiRep, sTipSitTlfRep, sNumTlfRep, _
                                                 sNumTlfCelRep, sTipSitFaxRep, sNumFaxRep, sCodSgmMcd, sNumInsInuNacSegSoc, _
                                                 sNomDepRep, sDatNscDep, sNumDocIdt, sNomOrgEmsDocIdtDep, sQdeFlhRep, sCodBcoRep, _
                                                 sCodAgeBcoRep, sCodCntCrrBcoRep, sNumDigVrfAgeBcoRep, sTipNatRep, sDesAcoTrbRep, _
                                                 sCodStaCadRep, sDatRgtRepCshReg, sCodEstUniCshReg, sTipSitRepCshReg, sTipSitPesJrCshReg, _
                                                 sCodEstUni, sNumRgtRepCshRep, sIndAcePnd, sIndVldCpf, sCodUndNgc, sTipFrmPgt, sIndRtcCrd, sVlrErr, oCnx)


            ' Insere na tabela de alteração de status
            If sVlrRetAlt <> "" Then
                sVlrRetAlt = ""
                'consulta se este status ja esta na tabela de alteracao de status
                sVlrRetCsn = oObeAltItfVAKRep.CsnDdoStaReq(sNumReqCadRep, sCodStaCadRep, sVlrErr, oCnx)
                oObeLetTxtMcoSta = New System.IO.StringReader(sVlrRetCsn)
                oGrpDdoSta.ReadXml(oObeLetTxtMcoSta)
                If oGrpDdoSta.Tables(0).Rows.Count = 0 Then
                    sVlrRetAlt = oObeAltItfVAKRep.IsrDdoAltSta(sCodStaCadRep, sNumReqCadRep, sNomUsrUltAlt, sVlrErr, oCnx)
                Else
                    sVlrRetAlt = "1"
                End If
            End If


            ' Altera dados da descrição do fluxo
            If sVlrRetAlt <> "" Then
                sVlrRetAlt = ""
                'sVlrRetAlt = oObeAltItfVAKRep.AltDdoDesObs(sNumReqCadRep, "1", sDesFlu, sVlrErr)
                REM ====================================================================
                REM Outra forma de arquivar as observacoes no fluxo:
                REM ====================================================================
                'Consulta a descrição da observação da requisição 
                Dim oObeDBRep As DB_VAKRep = New DB_VAKRep
                Dim sCodSeqObs As String = ""
                sCodSeqObs = oObeDBRep.CnsCodSeqObs(sNumReqCadRep, sVlrErr, oCnx)
                Dim sXML As System.IO.StringReader = New System.IO.StringReader(sCodSeqObs)
                Dim ds As DataSet
                ds = New DataSet
                ds.ReadXml(sXML)
                sCodSeqObs = ds.Tables(0).Rows(0).Item("CodSeqObs")
                sVlrRetAlt = oObeAltItfVAKRep.IsrDdoDesObs(sNumReqCadRep, sCodSeqObs, RetVlrSpace(sDesFlu), sVlrErr, oCnx)
                oObeDBRep = Nothing
                oObeAltItfVAKRep = Nothing
                sCodSeqObs = Nothing
                sXML = Nothing
                ds = Nothing
            End If

            oCnx.FimTscSuc()

            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao alterar dados do representante. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
        End Try
    End Function
#End Region

#Region "---------------------- Envia Email --------------------"
    Public Sub EnviarEmail(ByVal strDe As String, ByVal strPara As String, _
                           ByVal strAssunto As String, ByVal strMensagem As String, ByVal enumFormato As MailFormat, _
                           ByVal strSMTP As String, ByVal enumPrioridade As MailPriority, _
                           Optional ByVal strCaminhoAnexo As String = Nothing)

        'Utilizamos o bloco try, catch para tratar eventuais erros 
        Try

            'Instanciamos uma nova mensagem de e-mail 
            Dim oMail As New MailMessage

            'Vamos acrescentar os paramêtros necessarios agora 

            'Para quem é o email - strPara 
            'Para passar o nome da pessoa, coloque o nome dela seguido do email entre parenteses 
            oMail.To = strPara

            'Quem envia o e-mail - strDe 
            'Seguir exemplo do campo "Para" 
            oMail.From = strDe

            'O assunto da mensagem - strAssunto 
            oMail.Subject = strAssunto

            'A mensagem em si, pode ser texto ou html - strMensagem 
            oMail.Body = strMensagem

            'O tipo da mensagem: Texto ou Html - enumFormato 
            oMail.BodyFormat = enumFormato

            'Prioridade da mensagem: Low, Normal ou High - enumPrioridade 
            oMail.Priority = enumPrioridade

            'Agora verificamos se a mensagem possui anexos - strAnexos 
            'Para anexar arquivos, passe um array contendo os caminhos dos arquivos a serem anexados 
            'Notem que este parametro é opcional 
            If Not IsNothing(strCaminhoAnexo) Then
                'Adicionamos os anexos 1 à 1 
                Dim strAnexo As String

                For Each strAnexo In strCaminhoAnexo
                    Dim mailAnexo As New MailAttachment(strAnexo)
                    oMail.Attachments.Add(mailAnexo)
                Next
            End If

            'Agora definimos o servidor smpt a ser utilizado, verifique isso 
            'com o provedor onde seu site está hospedado - strSMTP 
            'Geralmente é smtp.provedor.com.br 
            SmtpMail.SmtpServer = strSMTP

            'Enfim, enviamos o e-mail 
            SmtpMail.Send(oMail)

        Catch ex As Exception
            Err.Raise(Err.Number, Err.Source, ex.ToString)
        End Try

    End Sub
#End Region

#Region "---------------------- Altera Status de uma requisição --------------------"
    Public Function AltStaReq(ByVal sNumReq As String, ByVal sCodSta As String, ByVal sNomUsrUltAlt As String) As String
        'objeto
        Dim oObeAltItfReq As New DB_VAKRep

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim sVlrRetAlt As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            sVlrRet = ""

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Altera dados na tabela temporária de representantes
            sVlrRetAlt = oObeAltItfReq.AltStaReq(sNumReq, sCodSta, sVlrErr, oCnx)
            ' Insere dados na tabela de status
            If sVlrRetAlt <> "" Then
                sVlrRetAlt = oObeAltItfReq.IsrDdoAltSta(sCodSta, sNumReq, sNomUsrUltAlt, sVlrErr, oCnx)
            End If
            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao alterar o statos da requisição. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeAltItfReq = Nothing
        End Try
    End Function
#End Region

#Region "---------------------- Altera Dados na Tabela de Descrição de Observações --------------------"
    Public Function AltDdoDesObs(ByVal sNumReqCadRep As String, ByVal sCodSeqObs As String, ByVal sDesObs As String) As String
        'objeto
        Dim oObeItfObs As New DB_VAKRep

        'descrição da observação
        Dim sNvoDesObs As String
        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        'Dataset
        Dim oGrpDdoRep As New DataSet
        'valor de retorno
        Dim sVlrRet As String
        'valor de retorno da consulta
        Dim sVlrRetCsn As String
        'valor de retorno da alterações
        Dim sVlrRetAlt As String
        'string de erro
        Dim sVlrErr As String

        Dim oCnx As IAU013.UO_IAUCnxAcsDdo


        Try
            sVlrRet = ""

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            'Consulta a descrição da observação da requisição 
            sVlrRetCsn = oObeItfObs.CsnDdoDesObs(sNumReqCadRep, sCodSeqObs, sVlrErr, oCnx)

            oObeLetTxtMco = New System.IO.StringReader(sVlrRetCsn)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
            End If

            'Concatena a antiga observação com a nova
            sNvoDesObs = oGrpDdoRep.Tables(0).Rows(0).Item("DESOBS") + Chr(13) + sDesObs

            ' Altera dados na tabela temporária de representantes
            sVlrRetAlt = oObeItfObs.AltDdoDesObs(sNumReqCadRep, sCodSeqObs, sNvoDesObs, sVlrErr, oCnx)

            oCnx.FimTscSuc()

            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao alterar a observação da requisição. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeItfObs = Nothing
        End Try
    End Function
#End Region

#Region "---------------------- Insere Dados Do Representante Na Tabela de Representantes --------------------"
    Public Function IsrDdoRepTabRep(ByVal sTxtMcoRep As String, ByVal sTxtMcoTetRep As String, _
                                    ByRef sCodRep As String, _
                                    ByRef sNomUsr As String, _
                                    ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        ''objeto
        Dim oObeIsrItfVAKRep As New DB_VAKRep
        'xml
        Dim oObeLetTxtMcoRep As System.IO.StringReader
        Dim oObeLetTxtMcoTetRep As System.IO.StringReader
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oObeLetTxtMcoSgmMcd As System.IO.StringReader

        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoSgmMcd As New DataSet
        Dim oGrpDdoCplRep As New DataSet
        Dim oGrpDdoCodRep As New DataSet
        Dim oGrpDdoDep As New DataSet
        Dim oGrpDdoTetRep As New DataSet
        Dim oGrpDdoTet As New DataSet

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim sVlrRetIsr As String
        Dim sVlrAtuSit As String
        Dim sVlrDep As String
        Dim sVlrRetSgmMcd As String
        Dim sVlrCplTabRep As String
        Dim sVlrRetTet As String

        'dados da tabela de representantes
        Dim sCodEmp, sNomRep, sEndRep As String
        Dim sNumTlfRep, sNumDocIdtRep, sCodSup, sCodGerVnd, vsCodGrpVndRep As String
        Dim sTipRep, sFlgPgtCmsRep, sCodRegCob, sCodGerTrp As String
        Dim sCodCidRep, sCodBcoRep, sCodAgeBcoRep, sNumDigVrfAgeBcoRep As String
        Dim sCodCepRep, sCodCntCrrBcoRep, sNumCpfRep As String
        Dim sDatNscRep, sCodEstUniCshReg, sTipFrmPgt As String
        Dim sCodSgmMcd, sDatRgtRepCshReg, sNumRgtRepCshReg, sTipNatRep As String
        Dim sNomOrgEmsDocIdtRep, sCodGraEclRep, sTipSitEclRep As String
        Dim sTipVtgRsiRep, sTipSitRsiRep, sTipSitTlfRep, sNumFaxRep As String
        Dim sTipSitFaxRep, sQdeFlhRep As String
        Dim sCodSex, sNomNacRep, sTipEstCvlRep, sDatIniPtcCalPro As String
        Dim sCodPswRepTmk, sCodPswRepLivPco As String
        Dim sCodSgmMcdCop, sNumInsInuNacSegSoc, sNumTlfCelRep, sCodSitRep As String
        Dim sCodUndNgc, sCodBai, sCodCplBai, sNomDep As String
        Dim sDatNscDep, sNumDocIdtDep, sNomOrgEmsIdtDep, sDatPrvCrdRsvRep As String
        Dim sCodFncGer As String
        Dim dDatAtu As Date

        Dim sTipSitPesJurCshReg As String
        Dim sTipSitRepCshReg As String    REM core 

        'dados da tabela de territórios do representante
        Dim sCodTetVnd, sVlrTetVnd, sCodFncAnt As String
        Dim iCntTet As Integer

        Try
            sVlrRet = ""
            sCodRep = ""
            oObeLetTxtMcoRep = New System.IO.StringReader(sTxtMcoRep)
            oGrpDdoRep.ReadXml(oObeLetTxtMcoRep)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If

            'Consulta o proximo codigo do representante
            sCodRep = oObeIsrItfVAKRep.CsnCodPrxRep(sVlrErr, oCnx)

            'Atribui o codigo a variavel sCodRep
            oObeLetTxtMco = New System.IO.StringReader(sCodRep)
            oGrpDdoCodRep.ReadXml(oObeLetTxtMco)
            sCodRep = oGrpDdoCodRep.Tables(0).Rows(0).Item(0)
            sNomUsr = sCodRep

            'Atribui os valores do xml as variaveis
            sCodEmp = oGrpDdoRep.Tables(0).Rows(0).Item(0)
            sNomRep = oGrpDdoRep.Tables(0).Rows(0).Item(1)
            sEndRep = oGrpDdoRep.Tables(0).Rows(0).Item(2)
            sNumTlfRep = oGrpDdoRep.Tables(0).Rows(0).Item(3)
            sNumDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(4)
            sCodSup = oGrpDdoRep.Tables(0).Rows(0).Item(5)
            sCodGerVnd = oGrpDdoRep.Tables(0).Rows(0).Item(6)
            vsCodGrpVndRep = oGrpDdoRep.Tables(0).Rows(0).Item(7)
            sTipRep = oGrpDdoRep.Tables(0).Rows(0).Item(8)
            If sTipRep = "4" Then
                sFlgPgtCmsRep = "N"
            Else
                sFlgPgtCmsRep = "S"
            End If

            sCodGerTrp = oGrpDdoRep.Tables(0).Rows(0).Item(9)
            sCodCidRep = oGrpDdoRep.Tables(0).Rows(0).Item(10)
            sCodBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item(11)
            sCodAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item(12)
            sNumDigVrfAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item(13)
            sCodCepRep = oGrpDdoRep.Tables(0).Rows(0).Item(14)
            sCodCntCrrBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item(15)
            sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item(16)
            sDatNscRep = oGrpDdoRep.Tables(0).Rows(0).Item(17)
            sCodEstUniCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(18)
            sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item(19)
            sDatRgtRepCshReg = Me.RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item(20))
            sNumRgtRepCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(21)
            sTipNatRep = oGrpDdoRep.Tables(0).Rows(0).Item(22)

            sTipSitPesJurCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(23)

            sNomOrgEmsDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item(24)
            sCodGraEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(25)
            sTipSitEclRep = oGrpDdoRep.Tables(0).Rows(0).Item(26)
            sTipVtgRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(27)
            sTipSitRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item(28)
            sTipSitTlfRep = oGrpDdoRep.Tables(0).Rows(0).Item(29)
            sNumFaxRep = oGrpDdoRep.Tables(0).Rows(0).Item(30)
            sTipSitFaxRep = oGrpDdoRep.Tables(0).Rows(0).Item(31)
            sQdeFlhRep = oGrpDdoRep.Tables(0).Rows(0).Item(32)

            sTipSitRepCshReg = oGrpDdoRep.Tables(0).Rows(0).Item(33)  REM ????

            sCodSex = oGrpDdoRep.Tables(0).Rows(0).Item(34)
            sNomNacRep = oGrpDdoRep.Tables(0).Rows(0).Item(35)
            sTipEstCvlRep = oGrpDdoRep.Tables(0).Rows(0).Item(36)
            sCodPswRepTmk = sCodRep
            sCodPswRepLivPco = sCodRep
            sCodSgmMcdCop = sCodSgmMcd
            sNumInsInuNacSegSoc = oGrpDdoRep.Tables(0).Rows(0).Item(37)

            sNumTlfCelRep = oGrpDdoRep.Tables(0).Rows(0).Item(38)
            sCodSitRep = oGrpDdoRep.Tables(0).Rows(0).Item(39)
            sCodUndNgc = oGrpDdoRep.Tables(0).Rows(0).Item(40)
            sCodBai = oGrpDdoRep.Tables(0).Rows(0).Item(41)
            sCodCplBai = oGrpDdoRep.Tables(0).Rows(0).Item(42)
            sTipFrmPgt = oGrpDdoRep.Tables(0).Rows(0).Item(43)

            sCodRegCob = oGrpDdoRep.Tables(0).Rows(0).Item(44)

            'Dependentes
            sNomDep = oGrpDdoRep.Tables(0).Rows(0).Item(45)
            sDatNscDep = oGrpDdoRep.Tables(0).Rows(0).Item(46)
            sNumDocIdtDep = oGrpDdoRep.Tables(0).Rows(0).Item(47)
            sNomOrgEmsIdtDep = oGrpDdoRep.Tables(0).Rows(0).Item(48)
            sCodFncGer = oGrpDdoRep.Tables(0).Rows(0).Item(49)

            'Insert na tabela de Seg Mercado
            sVlrRetSgmMcd = oObeIsrItfVAKRep.CsnDatSgmMcd(sCodSgmMcd, sVlrErr, oCnx)
            oObeLetTxtMcoSgmMcd = New System.IO.StringReader(sVlrRetSgmMcd)
            oGrpDdoSgmMcd.ReadXml(oObeLetTxtMcoSgmMcd)
            If oGrpDdoSgmMcd.Tables(0).Rows.Count <> 0 Then
                sDatIniPtcCalPro = oGrpDdoSgmMcd.Tables(0).Rows(0).Item(0)
                sDatPrvCrdRsvRep = oGrpDdoSgmMcd.Tables(0).Rows(0).Item(1)
            Else
                sDatIniPtcCalPro = "NULL"
            End If

            'sDatIniPtcCalPro = "2004-05-20"
            'sDatPrvCrdRsvRep = "2006-02-13"

            'Atribui os valores do xml as variaveis
            REM '''sCodEmp = oGrpDdoRep.Tables(0).Rows(0).Item("CodEmp")
            REM '''sNomRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomRep")
            REM '''sEndRep = oGrpDdoRep.Tables(0).Rows(0).Item("EndRep")
            REM '''sNumTlfRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumTlfRep")
            REM '''sNumDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumDocIdtRep")
            REM '''sCodSup = oGrpDdoRep.Tables(0).Rows(0).Item("CodSup")
            REM '''sCodGerVnd = oGrpDdoRep.Tables(0).Rows(0).Item("CodGerVnd")
            REM '''vsCodGrpVndRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodGrpVndRep")
            REM '''sTipRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipRep")
            REM '''If sTipRep = "4" Then
            REM '''    sFlgPgtCmsRep = "N"
            REM '''Else
            REM '''    sFlgPgtCmsRep = "S"
            REM '''End If

            REM '''sCodGerTrp = oGrpDdoRep.Tables(0).Rows(0).Item("CodGerTrp")
            REM '''sCodCidRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodCidRep")
            REM '''sCodBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodBcoRep")
            REM '''sCodAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodAgeBcoRep")
            REM '''sNumDigVrfAgeBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumDigVrfAgeBcoRep")
            REM '''sCodCepRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodCepRep")
            REM '''sCodCntCrrBcoRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodCntCrrBcoRep")
            REM '''sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumCpfRep")
            REM '''sDatNscRep = oGrpDdoRep.Tables(0).Rows(0).Item("DatNscRep")
            REM '''sCodEstUniCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("CodEstUniCshReg")
            REM '''sCodSgmMcd = oGrpDdoRep.Tables(0).Rows(0).Item("CodSgmMcd")
            REM '''sDatRgtRepCshReg = Me.RetVlrNul(oGrpDdoRep.Tables(0).Rows(0).Item("DatRgtRepCshReg"))
            REM '''sNumRgtRepCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("NumRgtRepCshReg")
            REM '''sTipNatRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipNatRep")
            REM '''sTipSitPesJurCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitPesJurCshReg")
            REM '''sNomOrgEmsDocIdtRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomOrgEmsDocIdtRep")
            REM '''sCodGraEclRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodGraEclRep")
            REM '''sTipSitEclRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitEclRep")
            REM '''sTipVtgRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipVtgRsiRep")
            REM '''sTipSitRsiRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitRsiRep")
            REM '''sTipSitTlfRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitTlfRep")
            REM '''sNumFaxRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumFaxRep")
            REM '''sTipSitFaxRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitFaxRep")
            REM '''sQdeFlhRep = oGrpDdoRep.Tables(0).Rows(0).Item("QdeFlhRep")
            REM '''sTipSitRepCshReg = oGrpDdoRep.Tables(0).Rows(0).Item("TipSitRepCshReg")
            REM '''sCodSex = oGrpDdoRep.Tables(0).Rows(0).Item("CodSex")
            REM '''sNomNacRep = oGrpDdoRep.Tables(0).Rows(0).Item("NomNacRep")
            REM '''sTipEstCvlRep = oGrpDdoRep.Tables(0).Rows(0).Item("TipEstCvlRep")
            REM '''sCodPswRepTmk = sCodRep
            REM '''sCodPswRepLivPco = sCodRep
            REM '''sCodSgmMcdCop = sCodSgmMcd
            REM '''sNumInsInuNacSegSoc = oGrpDdoRep.Tables(0).Rows(0).Item("NumInsInuNacSegSoc")

            REM '''sNumTlfCelRep = oGrpDdoRep.Tables(0).Rows(0).Item("NumTlfCelRep")
            REM '''sCodSitRep = oGrpDdoRep.Tables(0).Rows(0).Item("CodSitRep")
            REM '''sCodUndNgc = oGrpDdoRep.Tables(0).Rows(0).Item("CodUndNgc")
            REM '''sCodBai = oGrpDdoRep.Tables(0).Rows(0).Item("CodBai")
            REM '''sCodCplBai = oGrpDdoRep.Tables(0).Rows(0).Item("CodCplBai")
            REM '''sTipFrmPgt = oGrpDdoRep.Tables(0).Rows(0).Item("TipFrmPgt")

            REM '''sCodRegCob = oGrpDdoRep.Tables(0).Rows(0).Item("CodRegCob")

            REM ''''Dependentes
            REM '''sNomDep = oGrpDdoRep.Tables(0).Rows(0).Item("NomDep")
            REM '''sDatNscDep = oGrpDdoRep.Tables(0).Rows(0).Item("DatNscDep")
            REM '''sNumDocIdtDep = oGrpDdoRep.Tables(0).Rows(0).Item("NumDocIdtDep")
            REM '''sNomOrgEmsIdtDep = oGrpDdoRep.Tables(0).Rows(0).Item("NomOrgEmsIdtDep")
            REM '''sCodFncGer = oGrpDdoRep.Tables(0).Rows(0).Item("CodFncGer")

            REM ''''Insert na tabela de Seg Mercado
            REM '''sVlrRetSgmMcd = oObeIsrItfVAKRep.CsnDatSgmMcd(sCodSgmMcd, sVlrErr)
            REM '''oObeLetTxtMcoSgmMcd = New System.IO.StringReader(sVlrRetSgmMcd)
            REM '''oGrpDdoSgmMcd.ReadXml(oObeLetTxtMcoSgmMcd)
            REM '''If oGrpDdoSgmMcd.Tables(0).Rows.Count <> 0 Then
            REM '''    sDatIniPtcCalPro = oGrpDdoSgmMcd.Tables(0).Rows(0).Item(0)
            REM '''    sDatPrvCrdRsvRep = oGrpDdoSgmMcd.Tables(0).Rows(0).Item(1)
            REM '''Else
            REM '''    sDatIniPtcCalPro = "NULL"
            REM '''End If

            'sDatIniPtcCalPro = "2004-05-20"
            'sDatPrvCrdRsvRep = "2006-02-13"

            ' Insere dados na tabela de representantes
            sVlrRetIsr = oObeIsrItfVAKRep.IsrDdoRepTabRep(sCodRep, sNomRep, sEndRep, _
                                                        sNumTlfRep, sNumDocIdtRep, sCodSup, vsCodGrpVndRep, _
                                                        sTipRep, sFlgPgtCmsRep, sCodRegCob, sCodGerTrp, _
                                                        sCodCidRep, sCodBcoRep, sCodAgeBcoRep, sNumDigVrfAgeBcoRep, _
                                                        sCodCepRep, sCodCntCrrBcoRep, sNumCpfRep, sDatNscRep, _
                                                        sCodEstUniCshReg, sCodSgmMcd, sDatRgtRepCshReg, _
                                                        sNumRgtRepCshReg, sTipNatRep, sTipSitPesJurCshReg, sNomOrgEmsDocIdtRep, _
                                                        sCodGraEclRep, sTipSitEclRep, sTipVtgRsiRep, sTipSitRsiRep, _
                                                        sTipSitTlfRep, sNumFaxRep, sTipSitFaxRep, sQdeFlhRep, _
                                                        sTipSitRepCshReg, sCodSex, sNomNacRep, sTipEstCvlRep, _
                                                        sCodPswRepTmk, sCodPswRepLivPco, sCodSgmMcdCop, sNumInsInuNacSegSoc, _
                                                        sNumTlfCelRep, sCodSitRep, sCodUndNgc, sCodBai, sCodCplBai, sTipFrmPgt, sDatIniPtcCalPro, sVlrErr, oCnx)

            ' Atualiza tabela complementar da tabela de Representante
            If sVlrRetIsr <> "" Then
                oObeLetTxtMco = Nothing
                sVlrCplTabRep = oObeIsrItfVAKRep.CsnCplTabRep(sCodRep, sVlrErr, oCnx)
                oObeLetTxtMco = New System.IO.StringReader(sVlrCplTabRep)
                oGrpDdoCplRep.ReadXml(oObeLetTxtMco)
                If oGrpDdoCplRep.Tables(0).Rows.Count <> 0 Then
                    sVlrCplTabRep = oObeIsrItfVAKRep.AltTabCplRep(sDatPrvCrdRsvRep, sCodRep, sVlrErr, oCnx)
                Else
                    sVlrCplTabRep = oObeIsrItfVAKRep.IsrTabCplRep(sDatPrvCrdRsvRep, sCodRep, sVlrErr, oCnx)
                End If
            End If

            ' Atualiza situação Representante
            If sCodSitRep <> "0" And sVlrRetIsr <> "" Then
                sVlrAtuSit = ""
                sVlrAtuSit = oObeIsrItfVAKRep.IsrSitRep(sCodRep, sCodSitRep, sTipSitPesJurCshReg, sTipNatRep, _
                                                        sCodBcoRep, sCodAgeBcoRep, sNumDigVrfAgeBcoRep, sCodCntCrrBcoRep, _
                                                        "", "", "", "", "", "", sNumRgtRepCshReg, sCodEstUniCshReg, _
                                                        sTipSitRepCshReg, sDatRgtRepCshReg, "", "", sCodSup, sVlrErr, oCnx)
            End If

            'Atualiza dependentes
            If sNomDep <> "" And sVlrRetIsr <> "" Then
                sVlrDep = ""
                oObeLetTxtMco = Nothing
                sVlrDep = oObeIsrItfVAKRep.CsnDepRep(sCodRep, sVlrErr, oCnx)
                oObeLetTxtMco = New System.IO.StringReader(sVlrDep)
                oGrpDdoDep.ReadXml(oObeLetTxtMco)
                If oGrpDdoDep.Tables(0).Rows.Count <> 0 Then
                    sVlrDep = oObeIsrItfVAKRep.AltDepRep(sCodRep, sNomDep, sDatNscDep, sNumDocIdtDep, sNomOrgEmsIdtDep, sVlrErr, oCnx)
                Else
                    sVlrDep = oObeIsrItfVAKRep.IsrDepRep(sCodRep, sNomDep, sDatNscDep, sNumDocIdtDep, sNomOrgEmsIdtDep, sVlrErr, oCnx)
                End If
            End If

            ' Insere na tabela de territórios de representantes
            If sVlrRetIsr <> "" Then
                sVlrRetIsr = ""
                oObeLetTxtMcoTetRep = New System.IO.StringReader(sTxtMcoTetRep)
                oGrpDdoTet.ReadXml(oObeLetTxtMcoTetRep)

                If oGrpDdoTet.Tables(0).Rows.Count = 0 Then
                    sVlrErr = "O documento XML do Território dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End If

                For iCntTet = 0 To oGrpDdoTet.Tables(0).Rows.Count - 1
                    'Select
                    oObeLetTxtMco = Nothing
                    sCodTetVnd = oGrpDdoTet.Tables(0).Rows(iCntTet).Item(0)
                    sVlrRetTet = oObeIsrItfVAKRep.CsnTetRep(sCodTetVnd, sVlrErr, oCnx)
                    oObeLetTxtMco = New System.IO.StringReader(sVlrRetTet)
                    oGrpDdoTetRep.ReadXml(oObeLetTxtMco)
                    If oGrpDdoTetRep.Tables(0).Rows.Count <> 0 Then
                        sCodFncAnt = oGrpDdoTetRep.Tables(0).Rows(0).Item(0)
                    End If

                    'Update
                    sVlrRetTet = ""
                    oObeLetTxtMco = Nothing
                    sVlrRetTet = oObeIsrItfVAKRep.AltTetRep(sCodTetVnd, sCodRep, sVlrErr, oCnx)

                    'Insert
                    sVlrRetTet = ""
                    oObeLetTxtMco = Nothing
                    sVlrRetTet = oObeIsrItfVAKRep.IsrTetRep(sCodTetVnd, sCodFncAnt, sCodRep, sCodFncGer, sVlrErr, oCnx)
                    oGrpDdoTetRep.Tables(0).Clear()
                    sCodFncAnt = ""
                Next
            End If


            'sVlrErr

            Return sCodRep
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao inserir dados do representante. Entre em contato com o Administrador do Sistema!"
                'sVlrErr = oObeEcc.Message
            End If
            Throw New Exception(sVlrErr)
        Finally
            oObeIsrItfVAKRep = Nothing
        End Try
    End Function
#End Region

#Region "---------------------- Aprova Dados Do Representante --------------------"
    Public Function ApvDdoRep(ByVal sNumReqCadRep As String, ByVal staDoc As String, ByVal flgTipUsr As String, ByVal sDesObsOcl As String, ByVal sCodUsrRcf As String, ByVal sNomFnc As String, ByVal sNomUsrRcf As String, ByRef sNvoStaDoc As String) As String

        Dim sDesFlu, sMsgFlu, strRet As String

        ' Objeto
        Dim oObeCadItfVAKRep As New VAK019.DB_VAKRep
        Dim sVlrErr As String

        'descrição da observação
        Dim sNvoDesObs As String
        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        'Dataset
        Dim oGrpDdoRep As New DataSet
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            sMsgFlu = "******************************************************************* " & Chr(13) & _
                      "  Documento aprovado "

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            If staDoc <> "" Then
                'se for gv: 
                If flgTipUsr <> "" Then
                    ' Alterar o status do documento
                    If flgTipUsr = "GERVND" Then
                        sMsgFlu &= "pelo Gerente de Vendas " & _
                                      sCodUsrRcf & " - " & sNomFnc & Chr(13) & _
                                   "  Em: " & Format("dd/MM/yyyy hh:mm:ss", Now) & Chr(13)
                        Select Case staDoc
                            Case "1"
                                sNvoStaDoc = "4"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                            Case "2"
                                sNvoStaDoc = "3"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                            Case "6"
                                sNvoStaDoc = "8"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                        End Select
                    Else
                        If flgTipUsr = "ANSCRD" Then
                            sMsgFlu &= "pelo Analista de Crédito " & _
                               sCodUsrRcf & " - " & sNomFnc & Chr(13) & _
                            "  Em: " & Format("dd/MM/yyyy hh:mm:ss", Now) & Chr(13)

                            Select Case staDoc
                                Case "0"

                                    sNvoStaDoc = "1"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If

                                    ' =======================================================================
                                    ' Envia email para o gerente de vendas: GV
                                    ' =======================================================================
                                    Dim AssuntoEmail As String
                                    Dim NumeroRequisicaoCodificado As String
                                    Dim oGrpDdoNomUsr As New Data.DataSet
                                    Dim rep As New DB_VAKRep
                                    Dim RemetenteEmail As String
                                    Dim DestinatarioEmail As String
                                    Dim dts As New Data.DataSet
                                    Dim CodigoGerenteVendas As String
                                    Dim NomeRepresentante As String
                                    Dim NomeUsuarioRedeGV As String

                                    'Consulta dados da requisição
                                    dts = funXMLToDataSet(rep.CsnTotDdoRep(sNumReqCadRep, sVlrErr, oCnx), 0, 1, "D")
                                    If dts.Tables(0).Rows.Count > 0 Then
                                        CodigoGerenteVendas = CType(dts.Tables(0).Rows(0)("CODGERVND"), String)
                                        NomeRepresentante = Left(CType(dts.Tables(0).Rows(0)("NOMREP"), String).Trim, 30)
                                    Else
                                        Throw New Exception("Requisição não encontrada: " & sNumReqCadRep.ToString)
                                    End If

                                    'Obtêm nome de usuário de rede do gerente de vendas para endereço destinatário de email
                                    oGrpDdoNomUsr = funXMLToDataSet(rep.CsnNomUsrRcf(CodigoGerenteVendas, sVlrErr, oCnx), 0, 1, "D")
                                    If oGrpDdoNomUsr.Tables(0).Rows.Count = 0 Then
                                        sVlrErr = "O documento XML do nome do gerente de vendas está vazio. Por favor, entre em contato com o administrador do Sistema!"
                                        Throw New Exception(sVlrErr)
                                    End If
                                    NomeUsuarioRedeGV = oGrpDdoNomUsr.Tables(0).Rows(0).Item("nomusrrcf")
                                    DestinatarioEmail = NomeUsuarioRedeGV.ToLower().Trim & "@martins.com.br"


                                    'Busca email do analista de crédito (remetente)
                                    Dim csnEmail As New DB_VAKAnsCrd
                                    oGrpDdoRep = funXMLToDataSet(csnEmail.CsnCrrEtnSgn(sNomUsrRcf, oCnx), 0, 1, "D")
                                    If oGrpDdoRep.Tables(0).Rows.Count > 0 Then
                                        RemetenteEmail = CType(oGrpDdoRep.Tables(0).Rows(0)(0), String).Trim.ToLower
                                    Else
                                        Throw New Exception("Email alternativo não encontrado.")
                                    End If

                                    'Codifica número da requisição
                                    Dim CodigoRequisicao As Integer
                                    CodigoRequisicao = Int64.Parse(sNumReqCadRep)
                                    CodigoRequisicao = (CodigoRequisicao * CodigoRequisicao) + 168
                                    NumeroRequisicaoCodificado = CodigoRequisicao.ToString


                                    'Monta mensagem do email
                                    Dim strMensagem(4) As String
                                    AssuntoEmail = "Cadastro de RCA aguardando sua aprovação - " & NomeRepresentante
                                    strMensagem(0) = "O seguinte documento aguarda sua aprovação: "
                                    strMensagem(1) = " "
                                    strMensagem(2) = "Link para acesso ao documento:"
                                    strMensagem(3) = "http://sim/BO/DocVAKDetRep.aspx?NumReq=" & NumeroRequisicaoCodificado
                                    strMensagem(4) = " "


                                    'Envia email
                                    Dim wsEmail As New Email.Email
                                    Dim Enderecos(1) As Email.EnderecoEmail
                                    Enderecos(0) = New Email.EnderecoEmail
                                    With Enderecos(0)
                                        .Endereco = RemetenteEmail
                                        .TipoEndereco = Email.enmTipoEndereco.Remetente
                                        .TipoEntidade = Email.enmTipoEntidade.Externo
                                    End With
                                    Enderecos(1) = New Email.EnderecoEmail
                                    With Enderecos(1)
                                        .Endereco = DestinatarioEmail
                                        .TipoEndereco = Email.enmTipoEndereco.Destinatario
                                        .TipoEntidade = Email.enmTipoEntidade.Externo
                                    End With
                                    wsEmail.EmailEnviar(_ID_SISTEMA_EMAIL, AssuntoEmail, Enderecos, strMensagem, String.Empty)

                                Case "2"
                                    sNvoStaDoc = "6"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If
                                Case "3"
                                    sNvoStaDoc = "8"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If
                            End Select
                        End If
                    End If

                    If (sDesObsOcl <> "") Then
                        sMsgFlu &= "  Observacao : " & sDesObsOcl
                    End If
                    sDesFlu = Chr(13) & sMsgFlu & Chr(13)

                    'Consulta a descrição da observação da requisição 
                    Dim oObeDBRep As DB_VAKRep = New DB_VAKRep
                    oGrpDdoRep.Tables.Clear()
                    strRet = oObeDBRep.CnsCodSeqObs(sNumReqCadRep, sVlrErr, oCnx)
                    oObeLetTxtMco = New System.IO.StringReader(strRet)
                    oGrpDdoRep.ReadXml(oObeLetTxtMco)
                    strRet = oGrpDdoRep.Tables(0).Rows(0).Item(0)
                    strRet = oObeCadItfVAKRep.IsrDdoDesObs(sNumReqCadRep, strRet, RetVlrSpace(sDesFlu), sVlrErr, oCnx)
                End If
            End If
            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao aprovar dados do representante. Entre em contato com o Administrador do Sistema!"
                'sVlrErr = oObeEcc.Message
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCadItfVAKRep = Nothing
        End Try

    End Function
#End Region

#Region "---------------------- Reprova Dados Do Representante --------------------"
    Public Function RpvDdoRep(ByVal sNumReqCadRep As String, _
                              ByVal staDoc As String, _
                              ByVal flgTipUsr As String, _
                              ByVal sDesObsOcl As String, _
                              ByVal sCodUsrRcf As String, _
                              ByVal sNomFnc As String, _
                              ByVal sNomUsrRcf As String, _
                              ByRef sNvoStaDoc As String, _
                              ByVal CodigoGM As String, _
    ByVal NomeRep As String, _
    ByVal CPFRep As String, _
    ByVal LinkAcesso As String) As String

        Dim sDesFlu, sMsgFlu, strRet As String

        ' Objeto
        Dim oObeCadItfVAKRep As New VAK019.DB_VAKRep
        Dim sVlrErr As String

        'descrição da observação
        Dim sNvoDesObs As String
        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        'Dataset
        Dim oGrpDdoRep As New DataSet

        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try

            sMsgFlu = "******************************************************************* " & Chr(13) & _
                      "  Documento reprovado "

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            If staDoc <> "" Then
                'se for gv: 
                If flgTipUsr <> "" Then
                    ' Alterar o status do documento
                    If flgTipUsr = "GERVND" Then
                        sMsgFlu &= "pelo Gerente de Vendas " & _
                                      sCodUsrRcf & " - " & sNomFnc & Chr(13) & _
                                   "  Em: " & Format("dd/MM/yyyy hh:mm:ss", Now) & Chr(13)

                        Select Case staDoc
                            Case "1"
                                sNvoStaDoc = "5"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                            Case "2"
                                sNvoStaDoc = "5"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                            Case "6"
                                sNvoStaDoc = "5"
                                ' Altera dados na tabela temporária de representantes
                                strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                ' Insere dados na tabela de status
                                If strRet <> "" Then
                                    strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                End If
                        End Select
                    Else
                        If flgTipUsr = "ANSCRD" Then
                            sMsgFlu &= "pelo Analista de Crédito " & _
                               sCodUsrRcf & " - " & sNomFnc & Chr(13) & _
                            "  Em: " & Format("dd/MM/yyyy hh:mm:ss", Now) & Chr(13)

                            Select Case staDoc
                                Case "0"
                                    sNvoStaDoc = "9"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If
                                    EnviarEmailGM(oCnx, sNomUsrRcf, CodigoGM, NomeRep, CPFRep, LinkAcesso, sNumReqCadRep)
                                Case "2"
                                    sNvoStaDoc = "7"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If
                                Case "3"
                                    sNvoStaDoc = "7"
                                    ' Altera dados na tabela temporária de representantes
                                    strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                                    ' Insere dados na tabela de status
                                    If strRet <> "" Then
                                        strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                                    End If
                            End Select
                        End If
                    End If

                    'sDesObs = sDesObs & Chr(13) & sMsgObs & sDesObsOcl
                    If (sDesObsOcl <> "") Then
                        sMsgFlu &= "  Observação : " & sDesObsOcl
                    End If

                    'sDesFlu = sDesFlu & Chr(13) & sMsgFlu
                    sDesFlu = Chr(13) & sMsgFlu

                    REM ''''Consulta a descrição da observação da requisição 
                    REM '''strRet = oObeCadItfVAKRep.CsnDdoDesObs(sNumReqCadRep, "1", sVlrErr)

                    REM '''oObeLetTxtMco = New System.IO.StringReader(strRet)
                    REM '''oGrpDdoRep.ReadXml(oObeLetTxtMco)

                    REM '''If oGrpDdoRep.Tables(0).Rows.Count <> 0 Then
                    REM '''    'Concatena a antiga observação com a nova
                    REM '''    sNvoDesObs = oGrpDdoRep.Tables(0).Rows(0).Item("DESOBS") + Chr(13) + sDesFlu
                    REM '''Else
                    REM '''    sNvoDesObs = sDesFlu
                    REM '''End If

                    REM '''' Altera a descrição do Fluxo sobre a reprovação
                    REM '''strRet = oObeCadItfVAKRep.AltDdoDesObs(sNumReqCadRep, "1", sNvoDesObs, sVlrErr)
                    REM ====================================================================
                    REM Outra forma de arquivar as observacoes no fluxo:
                    REM ====================================================================
                    'Consulta a descrição da observação da requisição 
                    Dim oObeDBRep As DB_VAKRep = New DB_VAKRep
                    strRet = oObeDBRep.CnsCodSeqObs(sNumReqCadRep, sVlrErr, oCnx)
                    oObeLetTxtMco = New System.IO.StringReader(strRet)
                    oGrpDdoRep.ReadXml(oObeLetTxtMco)
                    strRet = oGrpDdoRep.Tables(0).Rows(0).Item(0)
                    strRet = oObeCadItfVAKRep.IsrDdoDesObs(sNumReqCadRep, strRet, RetVlrSpace(sDesFlu), sVlrErr, oCnx)
                End If
            End If
            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao reprovar dados do representante. Entre em contato com o Administrador do Sistema!"
                'sVlrErr = oObeEcc.Message
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCadItfVAKRep = Nothing
        End Try
    End Function
#End Region

    'Envia email para o Gerente de Mercado.
    Public Sub EnviarEmailGM(ByRef oCnx As IAU013.UO_IAUCnxAcsDdo, _
                            ByVal sNomUsrRcf As String, _
                            ByVal CodigoGM As Integer, _
                            ByVal NomeRep As String, _
                            ByVal CPFRep As String, _
                            ByVal LinkAcesso As String, _
                            ByVal NumeroReq As String)

        Dim strAssunto As String
        Dim strDe As String
        Dim csnEmail As New DB_VAKAnsCrd
        Dim strMensagem(5) As String
        Dim oGrpDdoRep As New Data.DataSet
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim strRet As String

        Try

            strRet = csnEmail.CsnCrrEtnSgn(sNomUsrRcf, oCnx)
            oObeLetTxtMco = New System.IO.StringReader(strRet)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count > 0 Then
                strDe = CType(oGrpDdoRep.Tables(0).Rows(0)(0), String).Trim.ToLower
            Else
                Throw New Exception("Email alternativo não encontrado.")
            End If

            strAssunto = "CADASTROFV - CADASTRAMENTO REJEITADO "
            strMensagem(0) = "O cadastramento do candidato foi rejeitado porque o mesmo ja prestou servicos na empresa."
            strMensagem(1) = "Nome: " & NomeRep
            strMensagem(2) = "CPF: " & CPFRep
            strMensagem(3) = "Requisicao: " & NumeroReq
            strMensagem(4) = "Caso deseje verificar o Documento, consulte o link abaixo:"
            strMensagem(5) = LinkAcesso


            Dim wsEmail As New Email.Email
            Dim Enderecos(1) As Email.EnderecoEmail
            Enderecos(0) = New Email.EnderecoEmail
            With Enderecos(0)
                .Endereco = strDe
                .TipoEndereco = Email.enmTipoEndereco.Remetente
                .TipoEntidade = Email.enmTipoEntidade.Externo
            End With

            Enderecos(1) = New Email.EnderecoEmail
            With Enderecos(1)
                .Endereco = CodigoGM
                .TipoEndereco = Email.enmTipoEndereco.Destinatario
                .TipoEntidade = Email.enmTipoEntidade.GerenteMercado
            End With


            wsEmail.EmailEnviar(_ID_SISTEMA_EMAIL, strAssunto, Enderecos, strMensagem, "")
        Catch ex As Exception
            Throw New Exception("Erro: " & ex.Message)
        End Try

    End Sub

#Region "---------------------- Conclui Dados Do Representante --------------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' 
    REM ''' </summary>
    REM ''' <param name="sNumReqCadRep"></param>
    REM ''' <param name="staDoc"></param>
    REM ''' <param name="flgTipUsr"></param>
    REM ''' <param name="sDesObsOcl"></param>
    REM ''' <param name="sCodUsrRcf"></param>
    REM ''' <param name="sNomFnc"></param>
    REM ''' <param name="sNomUsrRcf"></param>
    REM ''' <param name="sNvoStaDoc"></param>
    REM ''' <param name="sCodEmp"></param>
    REM ''' <param name="sNomRep"></param>
    REM ''' <param name="sEndRep"></param>
    REM ''' <param name="sNumTlfRep"></param>
    REM ''' <param name="sNumDocIdtRep"></param>
    REM ''' <param name="sCodGerMcd"></param>
    REM ''' <param name="sCodCidRep"></param>
    REM ''' <param name="sCodBcoRep"></param>
    REM ''' <param name="sCodAgeBcoRep"></param>
    REM ''' <param name="sNumDigVrfAgeBcoRep"></param>
    REM ''' <param name="sCodCepRep"></param>
    REM ''' <param name="sCodCntCrrBcoRep"></param>
    REM ''' <param name="sDatNscRep"></param>
    REM ''' <param name="sCodEstUniCshReg"></param>
    REM ''' <param name="sCodSgmMcd"></param>
    REM ''' <param name="sDatRgtRepCshReg"></param>
    REM ''' <param name="sNumRgtRepCshRep"></param>
    REM ''' <param name="sTipNatRep"></param>
    REM ''' <param name="sTipSitPesJurCshReg"></param>
    REM ''' <param name="sNomOrgEmsDocIdtRep"></param>
    REM ''' <param name="sCodGraEclRep"></param>
    REM ''' <param name="sTipSitEclRep"></param>
    REM ''' <param name="sTipVtgRsiRep"></param>
    REM ''' <param name="sTipSitRsiRep"></param>
    REM ''' <param name="sTipSitTlfRep"></param>
    REM ''' <param name="sNumFaxRep"></param>
    REM ''' <param name="sTipSitFaxRep"></param>
    REM ''' <param name="sQdeFlhRep"></param>
    REM ''' <param name="sCodSex"></param>
    REM ''' <param name="sNomNacRep"></param>
    REM ''' <param name="sTipEstCvlRep"></param>
    REM ''' <param name="sNumInsInuNacSegSoc"></param>
    REM ''' <param name="sNumTlfCelRep"></param>
    REM ''' <param name="sCodSitRep"></param>
    REM ''' <param name="sCodUndNgc"></param>
    REM ''' <param name="sNumCpfRep"></param>
    REM ''' <param name="sCodBai"></param>
    REM ''' <param name="sCodCplBai"></param>
    REM ''' <param name="sTipFrmPgt"></param>
    REM ''' <param name="sCodRegCob"></param>
    REM ''' <param name="sNomDepRep"></param>
    REM ''' <param name="sTipRep"></param>
    REM ''' <param name="sCodGerTrp"></param>
    REM ''' <param name="sDatNscDep"></param>
    REM ''' <param name="sNumDocIdt"></param>
    REM ''' <param name="sNomOrgEmsDocIdt"></param>
    REM ''' <param name="sCodGerVnd"></param>
    REM ''' <param name="sCodGrpVndRep"></param>
    REM ''' <param name="sCodFncGer"></param>
    REM ''' <param name="sTxtMcoTet"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/2/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function FimDdoRep(ByVal sNumReqCadRep As String, ByVal staDoc As String, ByVal flgTipUsr As String, ByVal sDesObsOcl As String, ByVal sCodUsrRcf As String, ByVal sNomFnc As String, ByVal sNomUsrRcf As String, ByRef sNvoStaDoc As String, _
                                ByVal sCodEmp As String, ByVal sNomRep As String, ByVal sEndRep As String, ByVal sNumTlfRep As String, ByVal sNumDocIdtRep As String, ByVal sCodGerMcd As String, ByVal sCodCidRep As String, _
                                ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCepRep As String, ByVal sCodCntCrrBcoRep As String, _
                                ByVal sDatNscRep As String, ByVal sCodEstUniCshReg As String, ByVal sCodSgmMcd As String, ByVal sDatRgtRepCshReg As String, ByVal sNumRgtRepCshRep As String, _
                                ByVal sTipNatRep As String, ByVal sTipSitPesJurCshReg As String, ByVal sNomOrgEmsDocIdtRep As String, ByVal sCodGraEclRep As String, ByVal sTipSitEclRep As String, _
                                ByVal sTipVtgRsiRep As String, ByVal sTipSitRsiRep As String, ByVal sTipSitTlfRep As String, ByVal sNumFaxRep As String, ByVal sTipSitFaxRep As String, ByVal sQdeFlhRep As String, _
                                ByVal sTipSitRepCshReg As String, _
                                ByVal sCodSex As String, ByVal sNomNacRep As String, ByVal sTipEstCvlRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sNumTlfCelRep As String, _
                                ByVal sCodSitRep As String, ByVal sCodUndNgc As String, ByVal sNumCpfRep As String, ByVal sCodBai As String, ByVal sCodCplBai As String, ByVal sTipFrmPgt As String, ByVal sCodRegCob As String, _
                                ByVal sNomDepRep As String, ByVal sTipRep As String, ByVal sCodGerTrp As String, ByVal sDatNscDep As String, ByVal sNumDocIdt As String, ByVal sNomOrgEmsDocIdt As String, ByVal sCodGerVnd As String, ByVal sCodGrpVndRep As String, _
                                ByVal sCodFncGer As String, ByVal sTxtMcoTet As String) As String

        Dim sDesFlu, sMsgFlu, strRet As String
        Dim oObeCadItfVAKRep As New VAK019.DB_VAKRep
        Dim sCodRep As String = ""
        Dim sNomUsr As String = ""
        Dim sVlrErr As String

        'descrição da observação
        Dim sNvoDesObs As String
        'xml
        Dim oObeLetTxtMco As System.IO.StringReader
        'Dataset
        Dim oGrpDdoRep As New DataSet
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try

            sMsgFlu = "******************************************************************* " & Chr(13) & _
                      "  Documento concluído "

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            If staDoc <> "" Then
                'se for gv: 
                If flgTipUsr <> "" Then

                    ' Alterar o status do documento
                    If flgTipUsr = "ANSCRD" Then
                        sMsgFlu &= "pelo Analista de Crédito " & _
                            sCodUsrRcf & " - " & sNomFnc & Chr(13) & _
                            "  Em: " & Format("dd/MM/yyyy hh:mm:ss", Now) & Chr(13)

                        If staDoc = "10" Then
                            sNvoStaDoc = "11"
                            ' Altera dados na tabela temporária de representantes
                            strRet = oObeCadItfVAKRep.AltStaReq(sNumReqCadRep, sNvoStaDoc, sVlrErr, oCnx)
                            ' Insere dados na tabela de status
                            If strRet <> "" Then
                                strRet = oObeCadItfVAKRep.IsrDdoAltSta(sNvoStaDoc, sNumReqCadRep, sNomUsrRcf, sVlrErr, oCnx)
                            End If
                        End If

                        'sDesFlu = sDesFlu & Chr(13) & sMsgFlu
                        sDesFlu = Chr(13) & sMsgFlu

                        REM ====================================================================
                        REM Arquivando as observacoes no fluxo:
                        REM ====================================================================
                        'Consulta a descrição da observação da requisição 
                        Dim oObeDBRep As DB_VAKRep = New DB_VAKRep
                        strRet = oObeDBRep.CnsCodSeqObs(sNumReqCadRep, sVlrErr, oCnx)
                        oObeLetTxtMco = New System.IO.StringReader(strRet)
                        oGrpDdoRep.ReadXml(oObeLetTxtMco)
                        strRet = oGrpDdoRep.Tables(0).Rows(0).Item(0)
                        strRet = oObeCadItfVAKRep.IsrDdoDesObs(sNumReqCadRep, strRet, RetVlrSpace(sDesFlu), sVlrErr, oCnx)

                        ' Inserir na tabela de representante, 
                        ' Inserir dependente de representante 
                        ' Relacionar o representante ao território
                       

                        sVlrErr = Me.FunCadRep(sCodEmp, sNomRep, sEndRep, sNumTlfRep, sNumDocIdtRep, sCodGerMcd, sCodCidRep, _
                                  sCodBcoRep, sCodAgeBcoRep, sNumDigVrfAgeBcoRep, sCodCepRep, sCodCntCrrBcoRep, _
                                  sDatNscRep, sCodEstUniCshReg, sCodSgmMcd, sDatRgtRepCshReg, sNumRgtRepCshRep, _
                                  sTipNatRep, sTipSitPesJurCshReg, sNomOrgEmsDocIdtRep, sCodGraEclRep, sTipSitEclRep, _
                                  sTipVtgRsiRep, sTipSitRsiRep, sTipSitTlfRep, sNumFaxRep, sTipSitFaxRep, sQdeFlhRep, _
                                  sTipSitRepCshReg, sCodSex, sNomNacRep, sTipEstCvlRep, sNumInsInuNacSegSoc, sNumTlfCelRep, _
                                  sCodSitRep, sCodUndNgc, sNumCpfRep, sCodBai, sCodCplBai, sTipFrmPgt, sCodRegCob, _
                                  sNomDepRep, sTipRep, sCodGerTrp, sDatNscDep, sNumDocIdt, sNomOrgEmsDocIdt, sCodGerVnd, sCodGrpVndRep, sCodFncGer, sTxtMcoTet, sCodRep, sNomUsr, oCnx)
                        If sVlrErr = "" Then
                            Throw New Exception(sVlrErr)
                        End If
                        'If sVlrErr <> "" Then
                        '    Throw New Exception(sVlrErr)
                        'End If
                    End If
                End If
            End If        'sDesObs = sDesObs & Chr(13) & sMsgObs & sDesObsOcl
            If (sDesObsOcl <> "") Then
                sMsgFlu &= "  Observação : " & sDesObsOcl
            End If
            Dim Diretorio As New ServidorDiretorios.ServidorDiretorios
            If Diretorio.criarUsuario(sNomUsr, sCodRep) = False Then
                Throw New Exception("Erro ao criar usuário!")
            End If

            oCnx.FimTscSuc()

            'Return "1"
            Return sVlrErr
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao reprovar dados do representante. Entre em contato com o Administrador do Sistema!"
                'sVlrErr = oObeEcc.Message
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCadItfVAKRep = Nothing
        End Try
    End Function
#End Region

#Region "---------------------- Cadastra Representante --------------------"
    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' 
    REM ''' </summary>
    REM ''' <param name="sCodEmp"></param>
    REM ''' <param name="sNomRep"></param>
    REM ''' <param name="sEndRep"></param>
    REM ''' <param name="sNumTlfRep"></param>
    REM ''' <param name="sNumDocIdtRep"></param>
    REM ''' <param name="sCodSup"></param>
    REM ''' <param name="sCodCidRep"></param>
    REM ''' <param name="sCodBcoRep"></param>
    REM ''' <param name="sCodAgeBcoRep"></param>
    REM ''' <param name="sNumDigVrfAgeBcoRep"></param>
    REM ''' <param name="sCodCepRep"></param>
    REM ''' <param name="sCodCntCrrBcoRep"></param>
    REM ''' <param name="sDatNscRep"></param>
    REM ''' <param name="sCodEstUniCshReg"></param>
    REM ''' <param name="sCodSgmMcd"></param>
    REM ''' <param name="sDatRgtRepCshReg"></param>
    REM ''' <param name="sNumRgtRepCshReg"></param>
    REM ''' <param name="sTipNatRep"></param>
    REM ''' <param name="sTipSitPesJurCshReg"></param>
    REM ''' <param name="sNomOrgEmsDocIdtRep"></param>
    REM ''' <param name="sCodGraEclRep"></param>
    REM ''' <param name="sTipSitEclRep"></param>
    REM ''' <param name="sTipVtgRsiRep"></param>
    REM ''' <param name="sTipSitRsiRep"></param>
    REM ''' <param name="sTipSitTlfRep"></param>
    REM ''' <param name="sNumFaxRep"></param>
    REM ''' <param name="sTipSitFaxRep"></param>
    REM ''' <param name="sQdeFlhRep"></param>
    REM ''' <param name="sTipSitRepCshReg"></param>
    REM ''' <param name="sCodSex"></param>
    REM ''' <param name="sNomNacRep"></param>
    REM ''' <param name="sTipEstCvlRep"></param>
    REM ''' <param name="sNumInsInuNacSegSoc"></param>
    REM ''' <param name="sNumTlfCelRep"></param>
    REM ''' <param name="sCodSitRep"></param>
    REM ''' <param name="sCodUndNgc"></param>
    REM ''' <param name="sNumCpfRep"></param>
    REM ''' <param name="sCodBai"></param>
    REM ''' <param name="sCodCplBai"></param>
    REM ''' <param name="sTipFrmPgt"></param>
    REM ''' <param name="sCodRegCob"></param>
    REM ''' <param name="sNomDep"></param>
    REM ''' <param name="sTipRep"></param>
    REM ''' <param name="sCodGerTrp"></param>
    REM ''' <param name="sDatNscDep"></param>
    REM ''' <param name="sNumDocIdtDep"></param>
    REM ''' <param name="sNomOrgEmsIdtDep"></param>
    REM ''' <param name="sCodGerVnd"></param>
    REM ''' <param name="psCodGrpVndRep"></param>
    REM ''' <param name="sCodFncGer"></param>
    REM ''' <param name="sTxtMcoTet"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/2/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function FunCadRep(ByVal sCodEmp As String, ByVal sNomRep As String, ByVal sEndRep As String, ByVal sNumTlfRep As String, _
                                ByVal sNumDocIdtRep As String, ByVal sCodSup As String, ByVal sCodCidRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCepRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sDatNscRep As String, _
                                ByVal sCodEstUniCshReg As String, ByVal sCodSgmMcd As String, ByVal sDatRgtRepCshReg As String, ByVal sNumRgtRepCshReg As String, _
                                ByVal sTipNatRep As String, ByVal sTipSitPesJurCshReg As String, ByVal sNomOrgEmsDocIdtRep As String, ByVal sCodGraEclRep As String, _
                                ByVal sTipSitEclRep As String, ByVal sTipVtgRsiRep As String, ByVal sTipSitRsiRep As String, ByVal sTipSitTlfRep As String, ByVal sNumFaxRep As String, _
                                ByVal sTipSitFaxRep As String, ByVal sQdeFlhRep As String, _
                                ByVal sTipSitRepCshReg As String, ByVal sCodSex As String, ByVal sNomNacRep As String, _
                                ByVal sTipEstCvlRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sNumTlfCelRep As String, ByVal sCodSitRep As String, ByVal sCodUndNgc As String, _
                                ByVal sNumCpfRep As String, ByVal sCodBai As String, ByVal sCodCplBai As String, ByVal sTipFrmPgt As String, ByVal sCodRegCob As String, ByVal sNomDep As String, _
                                ByVal sTipRep As String, ByVal sCodGerTrp As String, ByVal sDatNscDep As String, ByVal sNumDocIdtDep As String, ByVal sNomOrgEmsIdtDep As String, _
                                ByVal sCodGerVnd As String, ByVal psCodGrpVndRep As String, ByVal sCodFncGer As String, ByVal sTxtMcoTet As String, _
                                ByRef sCodRep As String, ByRef sNomUsr As String, ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oObeItf As New VAK019.BO_VAKCadRep
        Dim sVlrErr As String
        Dim sVlrRet As String
        'Objeto para transformacao de String em xml
        Dim oObeLetTxt As System.IO.StringReader
        'Resultado das pesquisas de acao, fornecedor, comprador ...
        Dim oGrpDdo As DataSet
        Dim oObeTxtMco As XmlDocument
        'Outros
        Dim iIndice As Integer

        Try
            'Criando objeto xml
            Dim sTxtMcoPmt As String = "<representantes></representantes>"
            oObeTxtMco = New XmlDocument
            oObeTxtMco.LoadXml(sTxtMcoPmt)

            Dim oObeIte As System.Xml.XmlNode = oObeTxtMco.DocumentElement

            oObeIte.AppendChild(FncGrdObeEle("CodEmp", sCodEmp, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NomRep", sNomRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("EndRep", sEndRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumTlfRep", sNumTlfRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumDocIdtRep", sNumDocIdtRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodSup", sCodSup, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodGerVnd", sCodGerVnd, oObeTxtMco))

            oObeIte.AppendChild(FncGrdObeEle("CodGrpVndRep", psCodGrpVndRep, oObeTxtMco))
            'oObeIte.AppendChild(FncGrdObeEle("CodGrpVndRep", "1", oObeTxtMco))

            oObeIte.AppendChild(FncGrdObeEle("TipRep", sTipRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodGerTrp", sCodGerTrp, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodCidRep", sCodCidRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodBcoRep", sCodBcoRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodAgeBcoRep", sCodAgeBcoRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumDigVrfAgeBcoRep", sNumDigVrfAgeBcoRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodCepRep", sCodCepRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodCntCrrBcoRep", sCodCntCrrBcoRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumCpfRep", sNumCpfRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("DatNscRep", sDatNscRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodEstUniCshReg", sCodEstUniCshReg, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodSgmMcd", sCodSgmMcd, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("DatRgtRepCshReg", sDatRgtRepCshReg, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumRgtRepCshReg", sNumRgtRepCshReg, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipNatRep", sTipNatRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitPesJurCshReg", sTipSitPesJurCshReg, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NomOrgEmsDocIdtRep", sNomOrgEmsDocIdtRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodGraEclRep", sCodGraEclRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitEclRep", sTipSitEclRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipVtgRsiRep", sTipVtgRsiRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitRsiRep", sTipSitRsiRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitTlfRep", sTipSitTlfRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumFaxRep", sNumFaxRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitFaxRep", sTipSitFaxRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("QdeFlhRep", sQdeFlhRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipSitRepCshReg", sTipSitRepCshReg, oObeTxtMco)) REM core
            oObeIte.AppendChild(FncGrdObeEle("CodSex", sCodSex, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NomNacRep", sNomNacRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipEstCvlRep", sTipEstCvlRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumInsInuNacSegSoc", sNumInsInuNacSegSoc, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumTlfCelRep", sNumTlfCelRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodSitRep", sCodSitRep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodUndNgc", sCodUndNgc, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodBai", sCodBai, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodCplBai", sCodCplBai, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("TipFrmPgt", sTipFrmPgt, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodRegCob", sCodRegCob, oObeTxtMco))
            'Dependentes
            oObeIte.AppendChild(FncGrdObeEle("NomDep", sNomDep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("DatNscDep", sDatNscDep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NumDocIdtDep", sNumDocIdtDep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("NomOrgEmsIdtDep", sNomOrgEmsIdtDep, oObeTxtMco))
            oObeIte.AppendChild(FncGrdObeEle("CodFncGer", sCodFncGer, oObeTxtMco))

            sTxtMcoPmt = oObeTxtMco.OuterXml
            sVlrRet = oObeItf.IsrDdoRepTabRep(sTxtMcoPmt, sTxtMcoTet, sCodRep, sNomUsr, oCnx)

            If sVlrRet = "" Then
                Throw New Exception(sVlrErr)
            End If

            'If sVlrRet <> "1" Then
            '    Throw New Exception(sVlrErr)
            'Else
            '    sVlrRet = ""
            'End If

            Return sVlrRet
        Catch oObeEcc As Exception
            Return oObeEcc.Message
        Finally
            If Not oObeItf Is Nothing Then
                oObeItf = Nothing
            End If
        End Try
    End Function
#End Region

#Region "---------------------- Gera Elemento XML --------------------"
    Public Function FncGrdObeEle(ByVal sNomPmt As String, ByVal sVlrPmt As String, ByRef oObeTxtMco As XmlDocument) As XmlElement
        Dim oObeEle As System.Xml.XmlElement
        Dim oObeAtrPri As System.Xml.XmlAttribute
        Dim oObeAtrSgn As System.Xml.XmlAttribute

        oObeEle = oObeTxtMco.CreateElement(sNomPmt)
        oObeEle.InnerText = sVlrPmt

        Return oObeEle
    End Function
#End Region

#Region "-------------------- Transforma para NULL ------------------"
    Function RetVlrNul(ByVal sCpo As String) As String
        If sCpo = "" Then
            Return "NULL"
        Else
            Return sCpo
        End If
    End Function
    'Troca "" para " " - Usado para Oracle
    Function RetVlrSpace(ByVal sCpo As String) As String
        If sCpo = "" Then
            Return " "
        Else
            Return sCpo
        End If
    End Function

#End Region

#Region " ----------------- LIMPA CAMPO DE CARACTERES ASCII DE CONTROLE ----------------------- "
    Private Function ppctxt(ByVal txt As String) As String
        txt = Replace(txt, Chr(0), "")
        txt = Replace(txt, Chr(1), "")
        txt = Replace(txt, Chr(2), "")
        txt = Replace(txt, Chr(3), "")
        txt = Replace(txt, Chr(4), "")
        txt = Replace(txt, Chr(5), "")
        txt = Replace(txt, Chr(6), "")
        txt = Replace(txt, Chr(7), "")
        txt = Replace(txt, Chr(8), "")
        txt = Replace(txt, Chr(9), "")
        txt = Replace(txt, Chr(10), "")
        txt = Replace(txt, Chr(11), "")
        txt = Replace(txt, Chr(12), "")
        txt = Replace(txt, Chr(13), "")
        txt = Replace(txt, Chr(14), "")
        txt = Replace(txt, Chr(15), "")
        txt = Replace(txt, Chr(16), "")
        txt = Replace(txt, Chr(17), "")
        txt = Replace(txt, Chr(18), "")
        txt = Replace(txt, Chr(19), "")
        txt = Replace(txt, Chr(20), "")
        txt = Replace(txt, Chr(21), "")
        txt = Replace(txt, Chr(22), "")
        txt = Replace(txt, Chr(23), "")
        txt = Replace(txt, Chr(24), "")
        txt = Replace(txt, Chr(25), "")
        txt = Replace(txt, Chr(26), "")
        txt = Replace(txt, Chr(27), "")
        txt = Replace(txt, Chr(28), "")
        txt = Replace(txt, Chr(29), "")
        txt = Replace(txt, Chr(30), "")
        txt = Replace(txt, Chr(31), "")
        ppctxt = txt
    End Function

#End Region

#Region " ----------------- Alteração da Empresa do Representante -------------"
    Public Function IsrDdoHstEmpRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                                    ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                    ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                                    ByVal sNomEmpRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                                    ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                                    ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                                    ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, ByVal sAltTabRep As String) As String
        'objeto
        Dim oObeIsr As New DB_VAKRep

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Dim sDatHraAlt As String

        Try
            sVlrRet = ""

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Insere dados na tabela de status
            If sAltTabRep = "S" Then
                sVlrRet = oObeIsr.AltDdoTabRep(sCodRep, sCodSitRep, sTipSitPesJurCshReg, _
                                               sTipNatRep, sCodBcoRep, sCodAgeBcoRep, _
                                               sNumDigVrfAgeBcoRep, sCodCntCrrBcoRep, sNumCgcEmpRep, _
                                               sNomEmpRep, sEndEmpRep, sCodBaiEmpRep, _
                                               sCodCplBaiEmpRep, sCodCepEmpRep, sNumRgtRepCshReg, _
                                               sCodEstUniCshReg, sTipSitRepCshReg, sDatRgtRepCshReg, _
                                               sDatAsnCttRep, sDatCadFilEmp, sCodSup, _
                                               sVlrErr, oCnx)
                sDatHraAlt = "TRUNC(SYSDATE)"
            Else
                sDatHraAlt = "NULL"
            End If

            sVlrRet = oObeIsr.IsrDdoHstEmpRep(sCodRep, sCodSitRep, sTipSitPesJurCshReg, _
                                              sTipNatRep, sCodBcoRep, sCodAgeBcoRep, _
                                              sNumDigVrfAgeBcoRep, sCodCntCrrBcoRep, sNumCgcEmpRep, _
                                              sNomEmpRep, sNumInsInuNacSegSoc, sEndEmpRep, sCodBaiEmpRep, _
                                              sCodCplBaiEmpRep, sCodCepEmpRep, sNumRgtRepCshReg, _
                                              sCodEstUniCshReg, sTipSitRepCshReg, sDatRgtRepCshReg, _
                                              sDatAsnCttRep, sDatCadFilEmp, sCodSup, sDatHraAlt, _
                                              sVlrErr, oCnx)

            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao inserir histórico do representante. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeIsr = Nothing
        End Try
    End Function

    Public Function AltDdoHstEmpRep(ByVal sCodRep As String, ByVal sCodSitRep As String, ByVal sTipSitPesJurCshReg As String, _
                                    ByVal sTipNatRep As String, ByVal sCodBcoRep As String, ByVal sCodAgeBcoRep As String, _
                                    ByVal sNumDigVrfAgeBcoRep As String, ByVal sCodCntCrrBcoRep As String, ByVal sNumCgcEmpRep As String, _
                                    ByVal sNomEmpRep As String, ByVal sNumInsInuNacSegSoc As String, ByVal sEndEmpRep As String, ByVal sCodBaiEmpRep As String, _
                                    ByVal sCodCplBaiEmpRep As String, ByVal sCodCepEmpRep As String, ByVal sNumRgtRepCshReg As String, _
                                    ByVal sCodEstUniCshReg As String, ByVal sTipSitRepCshReg As String, ByVal sDatRgtRepCshReg As String, _
                                    ByVal sDatAsnCttRep As String, ByVal sDatCadFilEmp As String, ByVal sCodSup As String, ByVal sAltTabRep As String) As String
        'objeto
        Dim oObeAlt As New DB_VAKRep

        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Dim sDatHraAlt As String

        Try
            sVlrRet = ""

            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Insere dados na tabela de status
            If sAltTabRep = "S" Then
                sVlrRet = oObeAlt.AltDdoTabRep(sCodRep, sCodSitRep, sTipSitPesJurCshReg, _
                                               sTipNatRep, sCodBcoRep, sCodAgeBcoRep, _
                                               sNumDigVrfAgeBcoRep, sCodCntCrrBcoRep, sNumCgcEmpRep, _
                                               sNomEmpRep, sEndEmpRep, sCodBaiEmpRep, _
                                               sCodCplBaiEmpRep, sCodCepEmpRep, sNumRgtRepCshReg, _
                                               sCodEstUniCshReg, sTipSitRepCshReg, sDatRgtRepCshReg, _
                                               sDatAsnCttRep, sDatCadFilEmp, sCodSup, _
                                               sVlrErr, oCnx)
                sDatHraAlt = "TRUNC(SYSDATE)"
            Else
                sDatHraAlt = "NULL"
            End If

            sVlrRet = oObeAlt.AltDdoHstEmpRep(sCodRep, sCodSitRep, sTipSitPesJurCshReg, _
                                              sTipNatRep, sCodBcoRep, sCodAgeBcoRep, _
                                              sNumDigVrfAgeBcoRep, sCodCntCrrBcoRep, sNumCgcEmpRep, _
                                              sNomEmpRep, sNumInsInuNacSegSoc, sEndEmpRep, sCodBaiEmpRep, _
                                              sCodCplBaiEmpRep, sCodCepEmpRep, sNumRgtRepCshReg, _
                                              sCodEstUniCshReg, sTipSitRepCshReg, sDatRgtRepCshReg, _
                                              sDatAsnCttRep, sDatCadFilEmp, sCodSup, sDatHraAlt, _
                                              sVlrErr, oCnx)

            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao alterar histórico do representante. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeAlt = Nothing
        End Try
    End Function

    Public Function DelDdoHstEmpRep(ByVal sCodRep As String) As String
        'objeto
        Dim oObeDel As New DB_VAKRep

        'valor de retorno
        Dim iVlrRet As Integer
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            sVlrErr = ""
            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Insere dados na tabela de status
            iVlrRet = oObeDel.DelDdoHstEmpRep(sCodRep, sVlrErr, oCnx)

            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            'If sVlrErr = "" Then
            If iVlrRet <> 0 Then
                sVlrErr = "Houve um problema ao excluir alteraração do histórico do representante. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeDel = Nothing
        End Try
    End Function
#End Region


#Region "Quebra textos"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 'WordWrap' - Quebra texto
    ''' </summary>
    ''' <param name="strTexto">Texto a ser quebrado</param>
    ''' <param name="intTamanhoMaximoLinha">Tamanho máximo para cada linha</param>
    ''' <returns>array de strings com texto quebrado</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function WordWrap(ByVal strTexto As String, _
                                    ByVal intTamanhoMaximoLinha As Integer) As String()

        Dim Linhas As New Collections.ArrayList
        Dim strLinhaAtual As String
        Dim intIndiceUltimoBranco As Integer

        While strTexto.Length > intTamanhoMaximoLinha
            intIndiceUltimoBranco = Left(strTexto, intTamanhoMaximoLinha).LastIndexOf(" ")
            strLinhaAtual = Mid(strTexto, 1, intIndiceUltimoBranco) & " "
            strTexto = Mid(strTexto, intIndiceUltimoBranco + 2)
            Linhas.Add(strLinhaAtual)
        End While
        strLinhaAtual = strTexto
        Linhas.Add(strLinhaAtual)

        Dim strRetorno(Linhas.Count - 1) As String
        Dim iCnt As Integer
        For iCnt = 0 To Linhas.Count - 1
            strRetorno(iCnt) = Convert.ToString(Linhas(iCnt))
        Next
        Return strRetorno
    End Function
#End Region

    Public Function funXMLToDataSet(ByVal sLngMcoExt As String, ByVal iColCod As Integer, ByVal iColDes As Integer, ByVal cPos As Char) As DataSet
        Dim oGrpDdo As New DataSet
        Dim oObeLin As DataRow
        Dim iRegistro As Integer

        If sLngMcoExt = "" Then
            Return Nothing
        End If

        With oGrpDdo
            .ReadXml(New System.IO.StringReader(sLngMcoExt))
            iRegistro = 0
            For Each oObeLin In .Tables(0).Rows
                If (.Tables(0).Columns.Count > 1) And (.Tables(0).Rows.Count > 0) Then
                    If cPos = "D" Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColDes), String).Trim & " - " & CType(oObeLin(iColCod), String).Trim
                    ElseIf cPos = "C" Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColCod), String).Trim & " - " & CType(oObeLin(iColDes), String).Trim
                    ElseIf cPos = "3" And .Tables(0).Columns.Count >= 3 Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColCod), String).Trim.PadLeft(5, "0") & "-" & CType(oObeLin(iColCod + 2), String).Trim & " - " & CType(oObeLin(iColCod + 1), String).Trim
                    End If
                Else : Exit For
                End If
                iRegistro = iRegistro + 1
            Next
        End With
        Return oGrpDdo
    End Function
End Class