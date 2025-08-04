Imports Microsoft.ApplicationBlocks.ExceptionManagement
Imports System.Configuration.ConfigurationSettings

''' -----------------------------------------------------------------------------
''' Project	 : VAK020
''' Class	 : BO_VAKFluDstRep
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Realiza operações de atualização e consulta para fluxo de desativação de representantes
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	13/02/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class BO_VAKFluDstRep

    Const _TAM_OBS = 2000 'Tamanho máximo para quebra de observações
    Const _COD_FNC_SISTEMA = 999998 'Código de funcionário para o Sistema

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Construtor da classe.
    ''' </summary>
    ''' <remarks>
    ''' Seta a identidade usada na thread atual.
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        SetThreadIdentity()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Seta a identidade usada na thread atual.
    ''' </summary>
    ''' <remarks>
    ''' Recurso usado em sites na internet no Martins.
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub SetThreadIdentity()
        Dim user As System.Security.Principal.WindowsIdentity
        user = System.Security.Principal.WindowsIdentity.GetCurrent
        Dim winPrincipal As System.Security.Principal.WindowsPrincipal
        winPrincipal = New System.Security.Principal.WindowsPrincipal(user)
        System.Threading.Thread.CurrentThread.CurrentPrincipal = winPrincipal
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Situações do fluxo de desativação
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum enmDesSitFlu
        Criado 'Para Iniciar
        Iniciado 'Para consulta
        Inexistente 'Para criação
        ARevisar 'Para revisar
    End Enum

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Ações no fluxo de desativação
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum enmTipAcoFlu
        SalvaFluxo
        IniciarFluxoIniciativaEmpresa
        IniciarFluxoIniciativaRepresentante
        NotificarParaCumprimentoContrato
        NotificarOutrosMotivos
    End Enum

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de RCAS (incluindo os sem fluxos) do GV
    ''' </summary>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="sNomRep">Nome do representante</param>
    ''' <param name="iQdeDiaSemPed">Quant. dias sem emissão de pedido de vendas</param>
    ''' <param name="iDesSitFlu">Situação do fluxo</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstRep(ByVal iCodSup As Integer, _
                       ByVal iCodRep As Integer, _
                       ByVal sNomRep As String, _
                       ByVal iQdeDiaSemPed As Integer, _
                       ByVal iDesSitFlu As enmDesSitFlu) As DataSet

        Dim oDBLstFluSup As New VAK020.DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim sDesSitFlu As String
        Try
            Select Case iDesSitFlu
                Case enmDesSitFlu.Criado
                    sDesSitFlu = "Criado"
                Case enmDesSitFlu.Inexistente
                    sDesSitFlu = "Inexistente"
                Case enmDesSitFlu.Iniciado
                    sDesSitFlu = "Iniciado"
                Case enmDesSitFlu.ARevisar
                    sDesSitFlu = "A Revisar"
                Case Else
                    sDesSitFlu = ""
            End Select
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnLstRep = oDBLstFluSup.CsnLstRep(oCnx, iCodSup, iCodRep, sNomRep, iQdeDiaSemPed, sDesSitFlu)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de documentos (Notas fiscais e RPAs) devidos pelo RCA
    ''' </summary>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstRpaNfsRep(ByVal iCodRep As Integer) As DataSet
        Dim oDBLstFluSup As New VAK020.DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnLstRpaNfsRep = oDBLstFluSup.CsnLstRpaNfsRep(oCnx, iCodRep)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de fluxo de desativação por gerente de mercado.
    ''' </summary>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="sNomRep">Nome do representante</param>
    ''' <param name="dDatIni">Data inicial</param>
    ''' <param name="dDatFim">Data final</param>
    ''' <param name="bMinhasPendencias">Minhas pendências (sim/não)</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstFluSup(ByVal iCodSup As Integer, _
                          ByVal iCodRep As Integer, _
                          ByVal sNomRep As String, _
                          ByVal dDatIni As Date, _
                          ByVal dDatFim As Date, _
                          ByVal bMinhasPendencias As Boolean, _
                          ByVal iCodFlu As Integer) As DataSet

        Dim oDBLstFluSup As New VAK020.DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnLstFluSup = oDBLstFluSup.CsnLstFluSup(oCnx, iCodSup, iCodRep, sNomRep, dDatIni, dDatFim, bMinhasPendencias, iCodFlu)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de motivos de desativação
    ''' </summary>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMtvDst(ByVal CodMtvDst As Integer) As DataSet
        Dim CsnMtv As New VAK020.DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnMtvDst = CsnMtv.CsnMtvDst(oCnx, CodMtvDst)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta representantes por gerente de mercado.
    ''' </summary>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnRepPorSup(ByVal iCodSup As Integer, _
                                 ByVal iCodRep As Integer) As DataSet

        Dim CsnRepSup As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnRepPorSup = CsnRepSup.CsnRepPorSup(iCodSup, iCodRep, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta cidades do mesmo estado da cidade do parâmetro
    ''' </summary>
    ''' <param name="iCodCid">Código da cidade</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnCidEstCid(ByVal iCodCid As Integer) As DataSet
        Dim DB_CsnCid As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnCidEstCid = DB_CsnCid.CsnCidEstUni(iCodCid, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta cidades da unidade da federação (estado)
    ''' </summary>
    ''' <param name="sCodEstUni">Código unidade da federação (estado)</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnCid(ByVal sCodEstUni As String) As DataSet
        Dim DB_CsnCid As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnCid = DB_CsnCid.CsnCid(sCodEstUni, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona fluxo de desativação do representante (grava, inicia fluxo,...)
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="dDatCri">Data da criação</param>
    ''' <param name="iCodMtvDst">Código motivo desativação</param>
    ''' <param name="sDesMtvDstRep">Descrição motivo de desativação do representante</param>
    ''' <param name="sEndRep">Endereço do representante</param>
    ''' <param name="sNumTlfRep">Número do telefone do representante</param>
    ''' <param name="sNumTlfCelRep">Número do telefone celular do representante</param>
    ''' <param name="sNumFaxRep">Número do fax do representante</param>
    ''' <param name="iCodCidRep">Código da cidade do representante</param>
    ''' <param name="iCodCepRep">Código do CEP do representante</param>
    ''' <param name="iCodRepSbtVnd">Código do representante de vendas substituto</param>
    ''' <param name="dDatDocSlcDst">Data do documento de solicitação de desativação</param>
    ''' <param name="fVlrArdDstRep">Valor do acordo da desativação do representante</param>
    ''' <param name="sObsFlu">Observação</param>
    ''' <param name="PgnRsp">Lista de perguntas e respostas do início da desativação</param>
    ''' <param name="AcoFlu">Tipo da ação a ser tomada pelo método(somente salvar, iniciar fluxo...)</param>
    ''' <param name="sUrlSis">Endereço web (URL do sistema para incluir no email(no caso de início de fluxo)</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AcoFluDstRep(ByRef iCodFlu As Integer, ByVal iCodRep As Integer, _
                            ByVal dDatCri As Date, ByVal iCodMtvDst As Integer, _
                            ByVal sDesMtvDstRep As String, ByVal sEndREp As String, _
                            ByVal sNumTlfRep As String, ByVal sNumTlfCelRep As String, _
                            ByVal sNumFaxRep As String, ByVal iCodCidRep As Integer, _
                            ByVal iCodCepRep As Long, ByVal iCodRepSbtVnd As Integer, _
                            ByVal dDatDocSlcDst As Date, ByVal fVlrArdDstRep As Double, _
                            ByVal sObsFlu As String, ByVal PgnRsp(,) As String, _
                            ByVal AcoFlu As enmTipAcoFlu, ByVal sUrlSis As String, ByVal CodTipDstRep As Integer)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim iCntRsp As Integer
        Dim iRspPgn As Integer
        Dim iCodFncRpnCri As Integer
        Dim iCodGer As Integer
        Dim sNomGer As String
        Dim sNomSup As String
        Dim oGrpDdo As DataSet
        Dim iCodFncGer As Integer
        Dim sNomRep As String
        Dim iQdeDiaSemPedRep As Integer
        Dim iCodSup As Integer
        Dim iCodTipDstRep As Integer
        Dim ValorTotalAcerto As Decimal = 0
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            'Consulta dados GM/GV
            oGrpDdo = DB_VAK020.CsnDdoRepSupGer(iCodRep, oCnx)
            iCodGer = oGrpDdo.Tables(0).Rows(0)("CODGER")
            iCodSup = oGrpDdo.Tables(0).Rows(0)("CODSUP")
            sNomGer = oGrpDdo.Tables(0).Rows(0)("NOMGER")
            sNomSup = oGrpDdo.Tables(0).Rows(0)("NOMSUP")
            iCodFncRpnCri = oGrpDdo.Tables(0).Rows(0)("CODFNCSUP")
            iCodFncGer = oGrpDdo.Tables(0).Rows(0)("CODFNCGER")
            sNomRep = oGrpDdo.Tables(0).Rows(0)("NOMREP")
            iQdeDiaSemPedRep = oGrpDdo.Tables(0).Rows(0)("QDEDIASEMPED")

            'Se for para cumprimento de contrato, 
            'verifica se o RCA está sem passar pedido há uma quantidade de dias suficiente 
            'para que possa ser notificado.
            If AcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato Then
                Dim iQdeDiaSemPedMin As Integer
                iQdeDiaSemPedMin = Convert.ToInt32(DB_VAK020.CsnCdoPmt(1, oCnx))
                If iQdeDiaSemPedRep < iQdeDiaSemPedMin Then
                    Throw New Exception("O representante precisa estar sem passar pedido há mais de " & _
                        iQdeDiaSemPedMin.ToString & " dias para que possa ser notificado para cumprimento " & _
                            "do contrato de representação comercial.")
                End If
            End If

            'Verifica se ação ainda é válida
            If iCodFlu <> 0 Then
                Dim dtsRepresentantes As DataSet
                dtsRepresentantes = CsnLstFluSup(iCodSup, -1, "", New Date(1901, 1, 1), _
                                                 New Date(1901, 1, 1), False, iCodFlu)
                If dtsRepresentantes.Tables(0).Rows(0)("AguardaInicioOuRevisao") = "Não" Then
                    Throw New Exception("O fluxo " & iCodFlu & " não está em um estado que permita a alteração.")
                End If
            End If

            'Consulta próximo código de fluxo
            If iCodFlu = 0 Then iCodFlu = DB_VAK020.CsnPrxCodFlu(oCnx)

            'Verifica se já não existem fluxos abertos (em andamento) para o representante.
            Dim dtsFluxosAbertos As DataSet
            dtsFluxosAbertos = DB_VAK020.CsnFluDstAbtRep(iCodRep, iCodFlu, oCnx)
            If dtsFluxosAbertos.Tables(0).Rows.Count > 0 Then
                Throw New Exception("Já existe pelo menos um fluxo em andamento para este representante. Um novo fluxo não pode ser iniciado.")
            End If

            'Define o código de desativação do representante
            Select Case AcoFlu
                Case enmTipAcoFlu.IniciarFluxoIniciativaEmpresa : iCodTipDstRep = 1
                Case enmTipAcoFlu.IniciarFluxoIniciativaRepresentante : iCodTipDstRep = 1
                Case enmTipAcoFlu.NotificarOutrosMotivos : iCodTipDstRep = 2
                Case enmTipAcoFlu.NotificarParaCumprimentoContrato : iCodTipDstRep = 4
                Case enmTipAcoFlu.SalvaFluxo : iCodTipDstRep = CodTipDstRep
            End Select

            'Deleta informações antigas no banco
            DB_VAK020.DelFluDstRep(iCodFlu, oCnx)

            'Insere novo fluxo
            DB_VAK020.IsrFluDstRep(iCodFlu, iCodRep, dDatCri, iCodFncRpnCri, _
                                   iCodMtvDst, sDesMtvDstRep, sEndREp, sNumTlfRep, _
                                   sNumTlfCelRep, sNumFaxRep, iCodCidRep, iCodCepRep, _
                                   iCodRepSbtVnd, dDatDocSlcDst, iCodTipDstRep, _
                                   fVlrArdDstRep, oCnx)

            'Se ação = SALVAR
            If AcoFlu = enmTipAcoFlu.SalvaFluxo Then

                'Insere observação    
                DB_VAK020.IsrObsFlu(iCodFlu, 0, 1, sObsFlu, oCnx)

                'Insere respostas
                Dim iQdeRspPgn As Integer = (UBound(PgnRsp) + 1) * -1
                For iRspPgn = -1 To iQdeRspPgn Step -1
                    DB_VAK020.IsrObsFlu(iCodFlu, iRspPgn, 1, PgnRsp((iRspPgn + 1) * -1, 1), oCnx)
                Next

            Else

                Dim iCodPrxAco As Integer = DB_VAK020.CsnPrxSeqAcoFlu(iCodFlu, oCnx)
                Dim iCodPrxObs As Integer = DB_VAK020.CsnPrxCodObsFlu(iCodFlu, oCnx)

                'INSERE AÇÃO 1 - FLUXO INICIADO
                DB_VAK020.IsrAcoFlu(iCodFlu, iCodPrxAco, 1, iCodFncRpnCri, iCodPrxObs, 0, oCnx)
                DB_VAK020.IsrObsFlu(iCodFlu, iCodPrxObs, 1, sObsFlu, oCnx)
                iCodPrxObs += 1
                iCodPrxAco += 1

                'INSERE AÇÕES PARA NOTIFICAÇÃO
                If AcoFlu = enmTipAcoFlu.NotificarOutrosMotivos Then
                    DB_VAK020.IsrAcoFlu(iCodFlu, iCodPrxAco, 3, iCodFncRpnCri, 0, 0, oCnx)
                    iCodPrxAco += 1
                ElseIf AcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato Then
                    DB_VAK020.IsrAcoFlu(iCodFlu, iCodPrxAco, 2, iCodFncRpnCri, 0, 0, oCnx)
                    iCodPrxAco += 1
                End If

                'Insere pedidos e respostas de parecer para cada pergunta (ações 9 e 10)
                For iRspPgn = LBound(PgnRsp) To UBound(PgnRsp)
                    Dim sPgn As String = PgnRsp(iRspPgn, 0)
                    Dim sRpn As String = PgnRsp(iRspPgn, 1)
                    'Insere pergunta como ação pedido de parecer / observação
                    DB_VAK020.IsrAcoFlu(iCodFlu, iCodPrxAco, 9, _COD_FNC_SISTEMA, iCodPrxObs, iCodFncRpnCri, oCnx)
                    IsrObsFlu(iCodFlu, iCodPrxObs, sPgn, oCnx)
                    iCodPrxObs += 1
                    iCodPrxAco += 1
                    'Insere pergunta como ação resposta de parecer / observação
                    DB_VAK020.IsrAcoFlu(iCodFlu, iCodPrxAco, 10, iCodFncRpnCri, iCodPrxObs, iCodPrxAco - 1, oCnx)
                    IsrObsFlu(iCodFlu, iCodPrxObs, sRpn, oCnx)
                    iCodPrxObs += 1
                    iCodPrxAco += 1
                Next

            End If

            'Testar se faz a aprovação automática
            Dim AprovarGVAutomaticamente As Boolean
            Select Case AcoFlu
                Case enmTipAcoFlu.IniciarFluxoIniciativaEmpresa

                    Dim ValorIndenizatorio As Decimal
                    Dim SaldoResidual As Decimal
                    Dim ValorMinimoAprovacaoGV As Decimal
                    Dim objInformacoesHistoricas As New InformacoesHistoricas.InformacoesHistoricas
                    Dim dtsInformacoesHistoricas As New InformacoesHistoricas.DatasetValoresIndenizatorios

                    dtsInformacoesHistoricas = objInformacoesHistoricas.MaiorMesValidoComIndiceDeCorrecaoCadastradoObter()
                    If dtsInformacoesHistoricas.tabelaIndicesCadastrados.Rows.Count > 0 Then
                        dtsInformacoesHistoricas.Merge(objInformacoesHistoricas.ValoresIndenizatoriosObter(iCodRep)) 'TblVlrInd
                        dtsInformacoesHistoricas.Merge(objInformacoesHistoricas.SaldoResidualRepresentanteObter(iCodRep)) 'TblSldRsd
                        oGrpDdo = DB_VAK020.ObterParametro(4, oCnx) 'TblPrm
                        If dtsInformacoesHistoricas.tabelaValoresIndenizatorios.Rows.Count > 0 Then
                            ValorIndenizatorio = _
                                CType(dtsInformacoesHistoricas.tabelaValoresIndenizatorios.Item(0).UMDOZEAVOS, Decimal) _
                                + CType(dtsInformacoesHistoricas.tabelaValoresIndenizatorios.Item(0).UMTERCO, Decimal)
                        Else
                            ValorIndenizatorio = 0
                        End If
                        If dtsInformacoesHistoricas.tabelaSaldoResidual.Rows.Count > 0 Then
                            SaldoResidual = _
                                CType(dtsInformacoesHistoricas.tabelaSaldoResidual.Item(0).VLRSLDRSD, Decimal)
                        Else
                            SaldoResidual = 0
                        End If
                        If oGrpDdo.Tables("TblPrm").Rows.Count > 0 Then
                            ValorMinimoAprovacaoGV = CType(oGrpDdo.Tables("TblPrm").Rows(0)("CDOPMT"), Decimal)
                        Else
                            Throw New Exception("O parâmetro 4 - VLR. MIN. P. APROVACAO DO GV não está cadastrado.")
                        End If
                        ValorTotalAcerto = ValorIndenizatorio + SaldoResidual
                        If ValorTotalAcerto >= ValorMinimoAprovacaoGV Then
                            AprovarGVAutomaticamente = False
                        Else
                            AprovarGVAutomaticamente = True
                        End If
                    Else
                        AprovarGVAutomaticamente = False
                    End If

                Case enmTipAcoFlu.IniciarFluxoIniciativaRepresentante
                    AprovarGVAutomaticamente = True
                Case enmTipAcoFlu.NotificarOutrosMotivos
                    AprovarGVAutomaticamente = False
                Case enmTipAcoFlu.NotificarParaCumprimentoContrato
                    AprovarGVAutomaticamente = True
                Case Else
                    AprovarGVAutomaticamente = False
            End Select

            If AprovarGVAutomaticamente Then

                AprovarFluxoGVAutomatico(iCodFlu, _
                                         AcoFlu, _
                                         dDatDocSlcDst, _
                                         999998, _
                                         iCodTipDstRep, _
                                         ValorTotalAcerto, _
                                         oCnx)

            Else
                'Enviar email para GV
                If AcoFlu <> enmTipAcoFlu.SalvaFluxo Then

                    Dim objMailSender As New Email.Email
                    Dim objMailAddress(1) As Email.EnderecoEmail
                    Dim sCabecalho As String
                    Dim sCorpo(6) As String
                    'Remetente
                    objMailAddress(0) = New Email.EnderecoEmail
                    With objMailAddress(0)
                        .TipoEntidade = Email.enmTipoEntidade.GerenteMercado
                        .TipoEndereco = Email.enmTipoEndereco.Remetente
                        .Endereco = Convert.ToString(iCodSup)
                    End With
                    'Destinatário
                    objMailAddress(1) = New Email.EnderecoEmail
                    With objMailAddress(1)
                        .TipoEntidade = Email.enmTipoEntidade.Funcionario
                        .TipoEndereco = Email.enmTipoEndereco.Destinatario
                        .Endereco = Convert.ToString(iCodFncGer)
                    End With
                    'Cabeçalho
                    sCabecalho = "Fluxo de Rescisão de Contrato com Representante Iniciado"
                    'Corpo
                    sCorpo(0) = "Prezado Gerente de Vendas, "
                    sCorpo(1) = "O Gerente de Mercado " & sNomSup.Trim.ToUpper & " "
                    sCorpo(2) = "iniciou um fluxo de desativação para "
                    sCorpo(3) = "o RCA " & sNomRep.Trim.ToUpper & "."
                    sCorpo(4) = "Para ver os detalhes e realizar as ações necessárias, acesse "
                    sCorpo(5) = "o sistema de Administração de Vendas (" & sUrlSis & ") "
                    sCorpo(6) = "e selecione a opção 'Rescisão de Contratos' no menu 'Representantes'."
                    'Enviar email
                    objMailSender.PreAuthenticate = True
                    objMailSender.Credentials = System.Net.CredentialCache.DefaultCredentials
                    objMailSender.EmailEnviar(BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL, sCabecalho, objMailAddress, sCorpo, "DST")
                End If

            End If

            oCnx.FimTscSuc()

        Catch oObeEcc As Exception

            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aprova fluxo pelo gerente de vendas automaticamente
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="AcoFlu">Tipo do fluxo de desativação</param>
    ''' <param name="dDatDocSlcDst">Data do documento de solicitação de desativação</param>
    ''' <param name="iCodFncRpnCri">Código funcionário responsável pela criação do fluxo</param>
    ''' <param name="TipoDesativacao">Tipo da desativação</param>
    ''' <param name="ValorTotalAcerto">Valor total do acerto</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AprovarFluxoGVAutomatico(ByVal iCodFlu As Integer, _
                                         ByVal AcoFlu As enmTipAcoFlu, _
                                         ByVal dDatDocSlcDst As Date, _
                                         ByVal iCodFncRpnCri As Integer, _
                                         ByVal TipoDesativacao As Constantes.TipoDesativacao, _
                                         ByVal ValorTotalAcerto As Decimal, _
                                         ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim boolTransfereTerritorios As Boolean = dDatDocSlcDst <> New Date(1, 1, 1)
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim ObservacaoTexto As String
        Try
            'Texto da observação
            Select Case AcoFlu
                Case enmTipAcoFlu.IniciarFluxoIniciativaEmpresa

                    ObservacaoTexto = "FLUXO APROVADO AUTOMATICAMENTE PELO SISTEMA (INICIATIVA DA EMPRESA COM VALOR RESCISORIO BAIXO)."

                Case enmTipAcoFlu.IniciarFluxoIniciativaRepresentante

                    ObservacaoTexto = "FLUXO APROVADO AUTOMATICAMENTE PELO SISTEMA (INICIATIVA DO REPRESENTANTE)."

                Case enmTipAcoFlu.NotificarParaCumprimentoContrato

                    ObservacaoTexto = "FLUXO APROVADO AUTOMATICAMENTE PELO SISTEMA (NOTIFICACAO PARA CUMPRIMENTO DE CONTRATO)."

            End Select

            If AcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaEmpresa OrElse _
                AcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaRepresentante Then
                '1 (NORMAL) se tiver clicado em “Iniciar fluxo”;
                TipoDesativacao = Constantes.TipoDesativacao.Indenizacao_Normal
            ElseIf AcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato Then
                '4 (NOTIFICAÇÃO PARA CUMPRIMENTO DE CONTRATO) se tiver clicado em “Notificar” com a opção "Para cumprimento de contrato de representação";
                TipoDesativacao = Constantes.TipoDesativacao.Notificacao_para_cumprimento_do_contrato
            ElseIf AcoFlu = enmTipAcoFlu.NotificarOutrosMotivos Then
                TipoDesativacao = Constantes.TipoDesativacao.Notificacao_para_rescisao_por_justo_motivo
                '2 (JUSTO MOTIVO) se tiver clicado em “Notificar” com a opção "Por outros motivos".
            End If

            'Acordo com o representante / Indenização normal
            Dim intTipoDesativacao As Integer
            If TipoDesativacao = Constantes.TipoDesativacao.Indenizacao_Normal Then

                intTipoDesativacao = 1

                Dim dsFLuxo As DataSet
                dsFLuxo = DB_VAK020.ObterParametro(2, oCnx)
                If dsFLuxo.Tables("TblPrm").Rows.Count > 0 Then
                    If dDatDocSlcDst = New Date(1, 1, 1) And _
                        Convert.ToDecimal(ValorTotalAcerto) >= _
                        Convert.ToDecimal(dsFLuxo.Tables("TblPrm").Rows(0)("CDOPMT").ToString.Replace(".", ",")) Then

                        AprovarFluxoGV(iCodFlu, _
                                       ObservacaoTexto, _
                                       1, _
                                       intTipoDesativacao, _
                                       TipoDesativacao, _
                                       True, _
                                       boolTransfereTerritorios, _
                                       iCodFncRpnCri, _
                                       AppSettings("ListaStatusEquipamentos"), _
                                       AppSettings("sim"), _
                                       New Date(1, 1, 1), _
                                       0, _
                                       oCnx)
                    Else
                        AprovarFluxoGV(iCodFlu, _
                                       ObservacaoTexto, _
                                       0, _
                                       intTipoDesativacao, _
                                       TipoDesativacao, _
                                       False, _
                                       boolTransfereTerritorios, _
                                       iCodFncRpnCri, _
                                       AppSettings("ListaStatusEquipamentos"), _
                                       AppSettings("sim"), _
                                       dDatDocSlcDst, _
                                       0, _
                                       oCnx)
                    End If
                Else
                    Throw New Exception("O parâmetro 2 - VLR. MIN. TRIBUNAL ARBITRAGEM não está cadastrado.")
                End If

            ElseIf AcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato Then  'Notificação para cumprimento de contrato.

                If InsereAcaoCumprimentoContrato(iCodFlu, _
                                              boolTransfereTerritorios, _
                                              dDatDocSlcDst, _
                                              iCodFncRpnCri, _
                                              ObservacaoTexto, _
                                              oCnx) = False Then
                    Exit Sub
                End If
            End If

        Catch oObeEcc As Exception

            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Inserir ação para cumprimento de contrato
    ''' </summary>
    ''' <param name="iCodFlu">Código de fluxo</param>
    ''' <param name="boolTransfereTerritorios"></param>
    ''' <param name="DataDocSolicitacaoDesativacao"></param>
    ''' <param name="iCodFncRpnCri"></param>
    ''' <param name="sTextoObservacao"></param>
    ''' <param name="oCnx"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function InsereAcaoCumprimentoContrato(ByVal iCodFlu As Integer, _
                                                   ByVal boolTransfereTerritorios As Boolean, _
                                                   ByVal DataDocSolicitacaoDesativacao As Date, _
                                                   ByVal iCodFncRpnCri As Integer, _
                                                   ByVal sTextoObservacao As String, _
                                                   ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Boolean

        Try
            Dim dsFluxo As New DataSet
            Dim dsRep As New DataSet
            Dim dias, diasSemPedido As Integer
            Dim sucesso As Boolean = True
            Dim DB_VAK020 As New DB_VAKFluDstRep

            dsFluxo.Merge(DB_VAK020.ObterParametro(1, oCnx))
            dsRep.EnforceConstraints = False
            dsRep.Merge(DB_VAK020.ObterRepresentantePorFluxo(iCodFlu, oCnx))
            dias = Convert.ToInt32(dsFluxo.Tables("TblPrm").Rows(0).Item("CDOPMT"))
            diasSemPedido = Convert.ToInt32(dsRep.Tables("TblRepFlu").Rows(0).Item("QDEDIASEMPED"))

            AprovarFluxoGV(iCodFlu, _
                           sTextoObservacao, _
                           0, _
                           4, _
                           Constantes.TipoDesativacao.Notificacao_para_cumprimento_do_contrato, _
                           False, _
                           boolTransfereTerritorios, _
                           iCodFncRpnCri, _
                           AppSettings("ListaStatusEquipamentos"), _
                           AppSettings("sim"), _
                           DataDocSolicitacaoDesativacao, _
                           Nothing, _
                           oCnx)
            sucesso = True
            Return sucesso
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de unidades da federação (estados)
    ''' </summary>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnEstUni() As DataSet
        Dim DB_Csn As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnEstUni = DB_Csn.CsnEstUni(oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta fluxo de desativação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="bObsProv">Observações provisórias? (sim/não) (caso do fluxo não iniciado - somente salvo).</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnFluDstRep(ByVal iCodFlu As Integer, _
                                 ByVal bObsProv As Boolean) As DataSet

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As New DataSet
        Try
            'Consulta fluxo
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo.Merge(DB_VAK020.CsnFluDstRep(iCodFlu, oCnx))

            'Consulta observações do fluxo (perguntas/respostas e observação)
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo.Merge(DB_VAK020.CsnObsFlu(iCodFlu, bObsProv, oCnx))

            Return oGrpDdo

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de ações do fluxo de desativação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnLstAcoFlu(ByVal iCodFlu As Integer, _
                                 ByVal iCodAco As Integer) As DataSet

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As New DataSet
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnLstAcoFlu = DB_VAK020.CsnLstAcoFlu(iCodFlu, iCodAco, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de tipos de ação
    ''' </summary>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnTipAco() As DataSet
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnTipAco = DB_VAK020.CsnTipAco(oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere observação do fluxo de desativação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodObs">Código da observação</param>
    ''' <param name="sDesObs">Descrição da observação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>1 - OK, <> 1 - Erro</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function IsrObsFlu(ByVal iCodFlu As Integer, _
                              ByVal iCodObs As Integer, _
                              ByVal sDesObs As String, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim iNumSeq As Integer = 1
        Dim iCnt As Integer
        Dim sTxtQbr As String
        Dim iIniPos As Integer = 1
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Do
            sTxtQbr = Mid(sDesObs, iIniPos, _TAM_OBS)
            DB_VAK020.IsrObsFlu(iCodFlu, iCodObs, iNumSeq, sTxtQbr, oCnx)
            iNumSeq += 1
            iIniPos = (iNumSeq - 1) * _TAM_OBS + 1
        Loop Until iIniPos > sDesObs.Length

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere ação OBSERVAÇÃO no fluxo de desativação.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="sDesObs">Descrição da observação</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub IsrAcoObsFlu(ByVal iCodFlu As Integer, _
                            ByVal iCodRep As Integer, _
                            ByVal sDesObs As String)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim iNumSeq As Integer
        Dim iCodObs As Integer
        Dim iCodFncRpnCri As Integer
        Dim oGrpDdo As DataSet
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'Busca código de funcionário do responsável pela criação da observação
            oGrpDdo = DB_VAK020.CsnDdoRepSupGer(iCodRep, oCnx)
            iCodFncRpnCri = oGrpDdo.Tables(0).Rows(0)("CODFNCSUP")
            'Busca próximo número de seqüência de ação para o fluxo
            iNumSeq = DB_VAK020.CsnPrxSeqAcoFlu(iCodFlu, oCnx)
            'Busca próximo número de observação para o fluxo
            iCodObs = DB_VAK020.CsnPrxCodObsFlu(iCodFlu, oCnx)
            'Insere AÇÃO 5 - OBSERVAÇÕES INCLUÍDAS
            DB_VAK020.IsrAcoFlu(iCodFlu, iNumSeq, 5, iCodFncRpnCri, iCodObs, 0, oCnx)
            'Insere observação
            IsrObsFlu(iCodFlu, iCodObs, sDesObs, oCnx)
            oCnx.FimTscSuc()
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere ação PEDIDO DE PARECER no fluxo de desativação.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="iCodFncDsn">Código do funcionário destinatário</param>
    ''' <param name="sDesObs">Descrição da observação</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub IsrAcoPdrPrc(ByVal iCodFlu As Integer, _
                            ByVal iCodRep As Integer, _
                            ByVal iCodFncDsn As Integer, _
                            ByVal sDesObs As String, _
                            ByVal sNomFncDsn As String, _
                            ByVal sURLSis As String)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim iNumSeq As Integer
        Dim iCodObs As Integer
        Dim iCodFncRpnCri As Integer
        Dim iCodSup As Integer
        Dim sNomSup As String
        Dim sNomRep As String
        Dim oGrpDdo As DataSet
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'Busca código de funcionário do responsável pela criação da observação
            oGrpDdo = DB_VAK020.CsnDdoRepSupGer(iCodRep, oCnx)
            iCodFncRpnCri = oGrpDdo.Tables(0).Rows(0)("CODFNCSUP")
            iCodSup = oGrpDdo.Tables(0).Rows(0)("CODSUP")
            sNomSup = oGrpDdo.Tables(0).Rows(0)("NOMSUP")
            sNomRep = oGrpDdo.Tables(0).Rows(0)("NOMREP")

            'Busca próximo número de seqüência de ação para o fluxo
            iNumSeq = DB_VAK020.CsnPrxSeqAcoFlu(iCodFlu, oCnx)
            'Busca próximo número de observação para o fluxo
            iCodObs = DB_VAK020.CsnPrxCodObsFlu(iCodFlu, oCnx)
            'Insere AÇÃO 5 - OBSERVAÇÕES INCLUÍDAS
            DB_VAK020.IsrAcoFlu(iCodFlu, iNumSeq, 9, iCodFncRpnCri, iCodObs, iCodFncDsn, oCnx)
            'Insere observação
            IsrObsFlu(iCodFlu, iCodObs, sDesObs, oCnx)
            EnvCreEtnPedOpn(iCodSup, sNomSup, iCodFncDsn, sNomFncDsn, sNomRep, sURLSis)
            oCnx.FimTscSuc()
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere ação PEDIDO DE PARECER no fluxo de desativação.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeqPedOpn">Núm. sequencial do pedido de parecer</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <param name="sDesObs">Descrição da observação</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub IsrAcoRspPrc(ByVal iCodFlu As Integer, _
                            ByVal iNumSeqPedOpn As Integer, _
                            ByVal iCodAco As Integer, _
                            ByVal sDesObs As String, _
                            ByVal sNomFncDsn As String, _
                            ByVal sURLSis As String)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim iPrxNumSeq As Integer
        Dim iPrxCodObs As Integer
        Dim oGrpDdo As DataSet
        Dim iCodFncRpnCri As Integer
        Dim iNumSeqPed As Integer
        Dim iCodSup As Integer
        Dim sNomSup As String
        Dim sNomRep As String
        Dim iCodFncDsn As Integer
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'Busca código de funcionário do responsável pela criação da observação
            oGrpDdo = DB_VAK020.CsnPedOpn(iCodFlu, iNumSeqPedOpn, iCodAco, oCnx)
            iCodFncRpnCri = oGrpDdo.Tables(0).Rows(0)("CODAUXPED")
            iCodFncDsn = oGrpDdo.Tables(0).Rows(0)("CODFNCPED")
            iNumSeqPed = oGrpDdo.Tables(0).Rows(0)("NUMSEQPED")
            iCodSup = oGrpDdo.Tables(0).Rows(0)("CODSUP")
            sNomSup = oGrpDdo.Tables(0).Rows(0)("NOMSUP")
            sNomRep = oGrpDdo.Tables(0).Rows(0)("NOMREP")
            'Busca próximo número de seqüência de ação para o fluxo
            iPrxNumSeq = DB_VAK020.CsnPrxSeqAcoFlu(iCodFlu, oCnx)
            'Busca próximo número de observação para o fluxo
            iPrxCodObs = DB_VAK020.CsnPrxCodObsFlu(iCodFlu, oCnx)
            'Insere AÇÃO 10 - RESPOSTA PARECER
            DB_VAK020.IsrAcoFlu(iCodFlu, iPrxNumSeq, 10, iCodFncRpnCri, iPrxCodObs, iNumSeqPed, oCnx)
            'Insere observação
            IsrObsFlu(iCodFlu, iPrxCodObs, sDesObs, oCnx)
            'Envia email
            EnvCreEtnRspOpn(iCodSup, sNomSup, iCodFncDsn, sNomFncDsn, sNomRep, sURLSis)
            'Finaliza transação
            oCnx.FimTscSuc()
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            oCnx.FimTscErr()
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de nomes de funcionários por trecho(parte) do nome do funcionário.
    ''' </summary>
    ''' <param name="sNomFnc">Trecho(parte) do nome do funcionário</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnUsrSisDst(ByVal sNomFnc As String) As DataSet
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnUsrSisDst = DB_VAK020.CsnUsrSisDst(sNomFnc, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta pedido de parecer
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeqPedOpn">Núm. sequencial do pedido de parecer</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <param name="sPedOpn">Observação do pedido de parecer</param>
    ''' <param name="sRspOpn">Observação da resposta do pedido de parecer</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnPedOpn(ByVal iCodFlu As Integer, _
                              ByVal iNumSeqPedOpn As Integer, _
                              ByVal iCodAco As Integer, _
                              ByRef sPedOpn As String, _
                              ByRef sRspOpn As String) As DataSet

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As DataSet
        Dim iCodObsPedOpn As Integer
        Dim iCodObsRspPedOpn As Integer
        Try
            'Consulta dados do pedido de parecer / resposta de parecer
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnPedOpn = DB_VAK020.CsnPedOpn(iCodFlu, iNumSeqPedOpn, iCodAco, oCnx)
            If CsnPedOpn.Tables(0).Rows.Count > 0 Then
                iCodObsPedOpn = CsnPedOpn.Tables(0).Rows(0)("CODOBSPED")
                If Not IsDBNull(CsnPedOpn.Tables(0).Rows(0)("CODOBSRSP")) Then
                    iCodObsRspPedOpn = CsnPedOpn.Tables(0).Rows(0)("CODOBSRSP")
                End If
            Else
                Throw New Exception("Não foram encontrados no banco informações sobre a ação de num.seq. " & iNumSeqPedOpn.ToString & " para o fluxo nro.: " & iCodFlu.ToString)
            End If

            'Consulta observação do pedido de parecer
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo = DB_VAK020.CsnObsAco(iCodFlu, iCodObsPedOpn, oCnx)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                For Each oLnh As DataRow In oGrpDdo.Tables(0).Rows
                    sPedOpn += oLnh("DESOBS")
                Next
            Else
                sPedOpn = " "
            End If

            'Consulta observação da resposta de parecer
            If iCodObsRspPedOpn <> 0 Then
                oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
                oGrpDdo = DB_VAK020.CsnObsAco(iCodFlu, iCodObsRspPedOpn, oCnx)
                If oGrpDdo.Tables(0).Rows.Count > 0 Then
                    For Each oLnh As DataRow In oGrpDdo.Tables(0).Rows
                        sRspOpn += oLnh("DESOBS")
                    Next
                Else
                    sRspOpn = " "
                End If
            Else
                sRspOpn = " "
            End If

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta ação genérica.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <param name="sObsAco">Observação da ação</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnAcoGen(ByVal iCodFlu As Integer, _
                              ByVal iNumSeq As Integer, _
                              ByRef sObsAco As String) As DataSet

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As DataSet
        Dim iCodObs As Integer
        Dim iCodAco As Integer
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnAcoGen = DB_VAK020.CsnAcoGen(iCodFlu, iNumSeq, oCnx)
            If CsnAcoGen.Tables(0).Rows.Count > 0 Then
                iCodObs = CsnAcoGen.Tables(0).Rows(0)("CODOBS")
                iCodAco = CsnAcoGen.Tables(0).Rows(0)("CODACO")
            Else
                Throw New Exception(" Não foi encontrado na base de dados a ação de núm seq. " & iNumSeq.ToString & " para o fluxo nro.: " & iCodFlu.ToString)
            End If

            If iCodAco <> 25 And iCodAco <> 29 And _
               iCodAco <> 37 And iCodAco <> 35 And _
               iCodAco <> 36 Then

                'Consulta observação da resposta de parecer
                oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
                oGrpDdo = DB_VAK020.CsnObsAco(iCodFlu, iCodObs, oCnx)
                If oGrpDdo.Tables(0).Rows.Count > 0 Then
                    For Each oLnh As DataRow In oGrpDdo.Tables(0).Rows
                        sObsAco += oLnh("DESOBS")
                    Next
                Else
                    sObsAco = " "
                End If

            End If

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta mensagem de correio eletrônico.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnMsgCreEtn(ByVal iCodFlu As Integer, _
                                 ByVal iNumSeq As Integer) As DataSet

        Dim iNumSeqMsg As Integer
        Dim iCodAco As Integer
        Dim BO_MSGCREETN As New BO_VAKCsnMsgCreEtn
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oGrpDdo As DataSet

        Try
            'Consulta número de seqüência do correio eletrônico
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo = DB_VAK020.CsnAcoGen(iCodFlu, iNumSeq, oCnx)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                iCodAco = oGrpDdo.Tables(0).Rows(0)("CODACO")
                If iCodAco <> 4 Then Throw New Exception("A ação núm seq.: " & iNumSeq.ToString & " do fluxo nro.: " & iCodFlu.ToString & " não é do tipo 'Comunicação Enviada'.")
                iNumSeqMsg = oGrpDdo.Tables(0).Rows(0)("CODAUXACO")
            Else
                Throw New Exception(" Não existem na base de dados informações sobre a ação núm seq.: " & iNumSeq.ToString & " do fluxo nro.: " & iCodFlu.ToString)
            End If

            'Consulta dados do correio eletrônico
            oGrpDdo.Merge(BO_MSGCREETN.CsnMsgCreEtn(iNumSeqMsg))
            Return oGrpDdo

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de pedidos de parecer em aberto do fluxo específico para o gerente de mercado
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnLstPedOpn(ByVal iCodFlu As Integer, _
                                 ByVal iCodRep As Integer) As DataSet

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim iCodFncRpnCri As Integer
        Dim oGrpDdo As DataSet
        Try
            'Consulta código de funcionário do GM 
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oGrpDdo = DB_VAK020.CsnDdoRepSupGer(iCodRep, oCnx)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                iCodFncRpnCri = oGrpDdo.Tables(0).Rows(0)("CODFNCSUP")
            Else
                Throw New Exception("Não existem dados do responsável pela resposta do parecer.")
            End If

            'Consulta lista de pedidos de parecer pendentes
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnLstPedOpn = DB_VAK020.CsnLstPedOpn(iCodFlu, iCodFncRpnCri, oCnx)

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    Public Function CsnTetVndRep(ByVal iCodRep As Integer) As DataSet
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnTetVndRep = DB_VAK020.CsnTetVndRep(iCodRep, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    Public Function EnvCreEtnPedOpn(ByVal iCodSup As Integer, _
                                    ByVal sNomSup As String, _
                                    ByVal iCodFncDsn As Integer, _
                                    ByVal sNomFncDsn As String, _
                                    ByVal sNomRep As String, _
                                    ByVal sURLSis As String)

        Dim objMailSender As New Email.Email
        Dim objMailAddress(1) As Email.EnderecoEmail
        Dim sCabecalho As String
        Dim sCorpo(5) As String
        'Remetente
        objMailAddress(0) = New Email.EnderecoEmail
        With objMailAddress(0)
            .TipoEntidade = Email.enmTipoEntidade.GerenteMercado
            .TipoEndereco = Email.enmTipoEndereco.Remetente
            .Endereco = Convert.ToString(iCodSup)
        End With
        'Destinatário
        objMailAddress(1) = New Email.EnderecoEmail
        With objMailAddress(1)
            .TipoEntidade = Email.enmTipoEntidade.Funcionario
            .TipoEndereco = Email.enmTipoEndereco.Destinatario
            .Endereco = Convert.ToString(iCodFncDsn)
        End With
        'Cabeçalho
        sCabecalho = "Rescisão de Contrato com Representante - Parecer Solicitado"
        'Corpo
        'Enviar email
        sCorpo(0) = "Prezado(a) " & sNomFncDsn.Trim & ","
        sCorpo(1) = sNomSup.Trim & " fez um pedido de parecer sobre "
        sCorpo(2) = "o fluxo de desativação do representante " & sNomRep.Trim & ". "
        sCorpo(3) = "Para dar seu parecer, acesse o sistema de "
        sCorpo(4) = "Administração de Vendas (" & sURLSis.Trim & ")"
        sCorpo(5) = "e selecione a opção 'Rescisão de Contratos' no menu 'Representantes'."
        objMailSender.PreAuthenticate = True
        objMailSender.Credentials = System.Net.CredentialCache.DefaultCredentials
        objMailSender.EmailEnviar(BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL, sCabecalho, objMailAddress, sCorpo, "DST")
    End Function

    Public Function EnvCreEtnRspOpn(ByVal iCodSup As Integer, _
                                    ByVal sNomSup As String, _
                                    ByVal iCodFncDsn As Integer, _
                                    ByVal sNomFncDsn As String, _
                                    ByVal sNomRep As String, _
                                    ByVal sURLSis As String)

        Dim objMailSender As New Email.Email
        Dim objMailAddress(1) As Email.EnderecoEmail
        Dim sCabecalho As String
        Dim sCorpo(5) As String
        'Remetente
        objMailAddress(0) = New Email.EnderecoEmail
        With objMailAddress(0)
            .TipoEntidade = Email.enmTipoEntidade.GerenteMercado
            .TipoEndereco = Email.enmTipoEndereco.Remetente
            .Endereco = Convert.ToString(iCodSup)
        End With
        'Destinatário
        objMailAddress(1) = New Email.EnderecoEmail
        With objMailAddress(1)
            .TipoEntidade = Email.enmTipoEntidade.Funcionario
            .TipoEndereco = Email.enmTipoEndereco.Destinatario
            .Endereco = Convert.ToString(iCodFncDsn)
        End With
        'Cabeçalho
        sCabecalho = "Rescisão de Contrato com Representante - Parecer Fornecido"
        'Corpo
        'Enviar email
        sCorpo(0) = "Prezado(a) " & sNomFncDsn.Trim & ","
        sCorpo(1) = sNomSup.Trim & " forneceu o parecer solicitado sobre  "
        sCorpo(2) = "o fluxo de desativação do representante " & sNomRep.Trim & ". "
        sCorpo(3) = "Para ver o parecer, acesse o sistema de "
        sCorpo(4) = "Administração de Vendas (" & sURLSis.Trim & ")"
        sCorpo(5) = "e selecione a opção 'Rescisão de Contratos' no menu 'Representantes'."

        objMailSender.PreAuthenticate = True
        objMailSender.Credentials = System.Net.CredentialCache.DefaultCredentials
        objMailSender.EmailEnviar(BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL, sCabecalho, objMailAddress, sCorpo, "DST")
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CodigoFluxo"></param>
    ''' <param name="ObservacaoTexto"></param>
    ''' <param name="CodAuxAco"></param>
    ''' <param name="CodTipDstRep"></param>
    ''' <param name="tipoDesativacao"></param>
    ''' <param name="valorMaior"></param>
    ''' <param name="boolTransfereTerritorios"></param>
    ''' <param name="CodigoFuncionarioResponsavel"></param>
    ''' <param name="ListaStatusEquipamentos"></param>
    ''' <param name="URLSistema"></param>
    ''' <param name="DataDocSolicitacaoDesativacao"></param>
    ''' <param name="strSituacaoAtualFluxo"></param>
    ''' <param name="intModuloSolicitante"></param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	3/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AprovarFluxoGV(ByVal CodigoFluxo As Integer, _
                              ByVal ObservacaoTexto As String, _
                              ByVal CodAuxAco As Integer, _
                              ByVal CodTipDstRep As Integer, _
                              ByVal tipoDesativacao As Constantes.TipoDesativacao, _
                              ByVal valorMaior As Boolean, _
                              ByVal boolTransfereTerritorios As Boolean, _
                              ByVal CodigoFuncionarioResponsavel As Integer, _
                              ByVal ListaStatusEquipamentos As String, _
                              ByVal URLSistema As String, _
                              ByVal DataDocSolicitacaoDesativacao As Date, _
                              ByVal decValorAcordo As Decimal, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)


        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim dsFluxo As New DataSet
        Dim dtrAcao As DataRow
        Dim dtrObs As DataRow
        Dim dsRCA As DataSet
        Dim intCodigoObservacao As Decimal
        Dim intContador As Integer
        Dim NomeRepresentante As String
        Dim CodigoSituacaoRepresentante As Decimal
        Dim CodigoRepresentante As Decimal
        Dim iCodPrxAco As Integer = DB_VAK020.CsnPrxSeqAcoFlu(CodigoFluxo, oCnx)
        Dim iCodPrxObs As Integer = DB_VAK020.CsnPrxCodObsFlu(CodigoFluxo, oCnx)

        Try
            'Inserir ação
            DB_VAK020.IsrAcoFlu(CodigoFluxo, _
                                iCodPrxAco, _
                                Constantes.Acao.FLUXO_APROVADO_GV, _
                                CodigoFuncionarioResponsavel, _
                                iCodPrxObs, _
                                CodAuxAco, _
                                oCnx)

            'Inserir observação
            Dim strObs() As String = Constantes.WordWrap(ObservacaoTexto, 2000)
            Dim intCount As Integer
            For intCount = 0 To strObs.Length - 1
                If Not strObs(intCount) Is Nothing Then
                    DB_VAK020.IsrObsFlu(CodigoFluxo, _
                                        iCodPrxObs, _
                                        intCount + 1, _
                                        strObs(intCount), _
                                        oCnx)
                End If
            Next

            'Consulta dados do representante do fluxo
            dsRCA = DB_VAK020.ObterRepresentantePorFluxo(CodigoFluxo, oCnx)
            If dsRCA.Tables("TblRepFlu").Rows.Count > 0 Then
                CodigoSituacaoRepresentante = Convert.ToDecimal(dsRCA.Tables("TblRepFlu").Rows(0)("CODSITREP"))
                NomeRepresentante = Convert.ToString(dsRCA.Tables("TblRepFlu").Rows(0)("NOMREP"))
                CodigoRepresentante = Convert.ToDecimal(dsRCA.Tables("TblRepFlu").Rows(0)("CODREP"))
            Else
                Throw New Exception("Não foi possível obter os dados do representante do fluxo nro.: " & CodigoFluxo)
            End If

            EmailEnviarAprovarFluxoGV(tipoDesativacao, _
                                      valorMaior, _
                                      Convert.ToString(NomeRepresentante), _
                                      CodigoFuncionarioResponsavel, _
                                      CodigoFluxo, _
                                      URLSistema, _
                                      oCnx)

            RelacionarFluxoComEquipamentos(CodigoFluxo, _
                                           ListaStatusEquipamentos, _
                                           URLSistema, _
                                           CodigoFuncionarioResponsavel, _
                                           oCnx)

            If boolTransfereTerritorios Then
                TransfereTerritoriosPorCodigoFluxo(CodigoFluxo, oCnx)
            End If

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia email para a ação "Aprovar fluxo pelo GV"
    ''' </summary>
    ''' <param name="tipo">Tipo de desativação</param>
    ''' <param name="maiorOuIgual">Valor maior ou igual</param>
    ''' <param name="NomeRCA">Nome do representante</param>
    ''' <param name="CodFncRemetente">Código do funcionário remetente</param>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="URLSistema">URL do sistema</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub EmailEnviarAprovarFluxoGV(ByVal tipo As Constantes.TipoDesativacao, _
                                         ByVal maiorOuIgual As Boolean, _
                                         ByVal NomeRCA As String, _
                                         ByVal CodFncRemetente As Decimal, _
                                         ByVal CodigoFluxo As Decimal, _
                                         ByVal URLSistema As String, _
                                         ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim webService As New Email.Email
        Try
            Select Case tipo

                Case Constantes.TipoDesativacao.Indenizacao_Normal

                    If maiorOuIgual Then
                        EnviarEmailAprovacaoGV(CodigoFluxo, URLSistema, True, tipo, oCnx)
                    Else 'Menor
                        EnviarEmailAprovacaoGV(CodigoFluxo, URLSistema, False, tipo, oCnx)
                    End If

                Case Constantes.TipoDesativacao.Notificacao_para_cumprimento_do_contrato

                    EnviarEmailAprovacaoGV(CodigoFluxo, URLSistema, False, tipo, oCnx)

            End Select
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Relaciona fluxo de desativação com equipamentos
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="ListaStatusEquipamentos">Lista status dos equipamentos</param>
    ''' <param name="URLSistema">URL do Sistema</param>
    ''' <param name="CodigoFuncionarioResponsavel">Código do funcionário responsável</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[raphael.sales]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub RelacionarFluxoComEquipamentos(ByVal CodigoFluxo As Decimal, _
                                              ByVal ListaStatusEquipamentos As String, _
                                              ByVal URLSistema As String, _
                                              ByVal CodigoFuncionarioResponsavel As Integer, _
                                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim dtsEquipamentosARelacionar As DataSet
        Dim dtsEquipamentosRelacionados As DataSet
        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim EquipamentoNumeroSerie As String
        Dim HouveAlteracoes As Boolean = False

        Try

            dtsEquipamentosARelacionar = DB_VAK020.ObterListaEquipamentoStatusRecuperacao(CInt(CodigoFluxo), ListaStatusEquipamentos, oCnx) 'TblEquiRel
            dtsEquipamentosRelacionados = DB_VAK020.RelacaoEquipamentosRelacionadosObter(CInt(CodigoFluxo), oCnx) 'TblEquiRel

            If dtsEquipamentosARelacionar.Tables("TblEquiRel").Rows.Count > 0 Then
                'Se houver equipamentos a relacionar com o fluxo...

                'Percorre o dataset ARelacionar, inserindo registros no dataset Relacionados e mantendo os que já estão lá.
                For Each linha As DataRow _
                    In dtsEquipamentosARelacionar.Tables("TblEquiRel").Rows
                    EquipamentoNumeroSerie = Convert.ToString(linha("NUMSEREQPIFR").Trim)
                    With dtsEquipamentosRelacionados.Tables("TblEquiRel")
                        .DefaultView.RowFilter = " NUMSEREQPIFR = '" & EquipamentoNumeroSerie & "'"
                        If .DefaultView.Count < 1 Then
                            Dim dtrFluxoEquipamento As DataRow
                            dtrFluxoEquipamento = dtsEquipamentosRelacionados.Tables("TblEquiRel").NewRow
                            dtrFluxoEquipamento("CODFLUDSTREP") = CodigoFluxo
                            dtrFluxoEquipamento("CODFNCALT") = 999998
                            dtrFluxoEquipamento("DATALT") = Date.Now
                            dtrFluxoEquipamento("NUMSEREQPIFR") = EquipamentoNumeroSerie
                            dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows.Add(dtrFluxoEquipamento)

                            DB_VAK020.InserirRelacionamentoFluxComEquipamento(CodigoFluxo, _
                                                                              EquipamentoNumeroSerie, _
                                                                              CodigoFuncionarioResponsavel, _
                                                                              oCnx)
                            'HouveAlteracoes = True
                        End If
                        .DefaultView.RowFilter = ""
                    End With
                Next

                'Percorre o dataset Relacionados, retirando dele os registros que não constam no dataset ARelacionar e mantendo os que constam.
                Dim iCntAux As Integer
                For iCntAux = 0 To dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows.Count - 1
                    EquipamentoNumeroSerie = Convert.ToString(dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows(iCntAux).Item("NUMSEREQPIFR")).Trim
                    With dtsEquipamentosARelacionar.Tables("TblEquiRel")
                        .DefaultView.RowFilter = " NUMSEREQPIFR = '" & EquipamentoNumeroSerie & "'"
                        If .DefaultView.Count < 1 Then
                            DB_VAK020.ExcluirRelacionamentoFluxComEquipamento(CodigoFluxo, _
                                                                              EquipamentoNumeroSerie, _
                                                                              oCnx)
                        End If
                        .DefaultView.RowFilter = ""
                    End With
                Next

                EnviarEmailAprovacaoGVComEquipamentos(CodigoFluxo, _
                                                      URLSistema, _
                                                      oCnx)

            Else
                'Se NÃO houver equipamentos a relacionar com o fluxo...
                If dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows.Count > 0 Then
                    Dim iCntAux As Integer
                    For iCntAux = 0 To dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows.Count - 1
                        EquipamentoNumeroSerie = _
                            dtsEquipamentosRelacionados.Tables("TblEquiRel").Rows(iCntAux)("NUMSEREQPIFR")
                        DB_VAK020.ExcluirRelacionamentoFluxComEquipamento(CodigoFluxo, _
                                                                          EquipamentoNumeroSerie, _
                                                                          oCnx)
                    Next
                    'HouveAlteracoes = True
                End If

                InserirEquipamentosRecuperados(CodigoFluxo, _
                                               999998, _
                                               "O SISTEMA IDENTIFICOU AUTOMATICAMENTE QUE NÃO HÁ EQUIPAMENTOS COM O REPRESENTANTE QUE PRECISEM SER RECUPERADOS.", _
                                               oCnx)

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Transfere territórios por código de fluxo
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub TransfereTerritoriosPorCodigoFluxo(ByVal CodigoFluxo As Decimal, _
                                                  ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Try
            Dim dtsTerritorios As New DataSet
            Dim dtsRepresentante As New DataSet
            Dim dtsFluxo As New DataSet
            Dim DuracaoDiasApropriacao As Integer
            Dim CodigoRepresentanteSubstituto As Decimal
            Dim CodigoRepresentante As Decimal
            Dim CodigoGerenteMercado As Integer
            Dim MatriculaGerenteMercado As Decimal
            Dim ExisteRCASubstitutoAtivo As Boolean
            Dim DB_VAK020 As New DB_VAKFluDstRep

            dtsRepresentante = DB_VAK020.ObterRepresentantePorFluxo(CodigoFluxo, oCnx)
            If dtsRepresentante.Tables("TblRepFlu").Rows.Count > 0 Then
                'Verificar se representante substituto está ativo, se não, transfere para o GM.
                If Not dtsRepresentante.Tables("TblRepFlu").Rows(0)("DATDSTREPSBTVND") Is DBNull.Value _
                   Or Convert.ToDecimal(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODREPSBTVND")) = 0 Then
                    CodigoRepresentanteSubstituto = Convert.ToDecimal(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODSUP"))
                    ExisteRCASubstitutoAtivo = False
                Else
                    CodigoRepresentanteSubstituto = Convert.ToDecimal(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODREPSBTVND"))
                    ExisteRCASubstitutoAtivo = True
                End If
                CodigoRepresentante = Convert.ToDecimal(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODREP"))
                MatriculaGerenteMercado = Convert.ToDecimal(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODFNCSUP"))
                CodigoGerenteMercado = Convert.ToInt32(dtsRepresentante.Tables("TblRepFlu").Rows(0)("CODSUP"))
            End If

            'Consultar parâmetro “Duração em dias da apropriação”
            dtsFluxo = DB_VAK020.ObterParametro(5, oCnx)
            Try
                DuracaoDiasApropriacao = Convert.ToInt32(dtsFluxo.Tables("TblPrm").Rows(0)("CDOPMT"))
            Catch ex As Exception
                Throw New Exception("Não foi possível converter o conteúdo do parâmetro 5 para número.")
            End Try

            'Solicitar transferência de territórios
            dtsTerritorios = DB_VAK020.ObterTerritoriosSemSoliticacaoTransferencia(CodigoFluxo, oCnx)
            If dtsTerritorios.Tables("TblSlcTrans").Rows.Count > 0 Then
                For Each linha As _
                  DataRow In _
                    dtsTerritorios.Tables("TblSlcTrans").Rows

                    'Atualiza território - MRT.T0133715
                    DB_VAK020.AtualizarTerritorio(linha("CODTETVND"), oCnx)

                    'Insere solicitação de transferência de território - MRT.T0135610 
                    DB_VAK020.InserirTerritorio(linha("CODSUP"), _
                                                CodigoRepresentante, _
                                                linha("CODTETVND"), _
                                                CodigoFluxo, _
                                                MatriculaGerenteMercado, _
                                                linha("CODREGVND"), _
                                                oCnx)


                    'Apropriação de território
                    If DuracaoDiasApropriacao > 0 AndAlso _
                       ExisteRCASubstitutoAtivo Then
                        'Verificar se existe apropriação para o território
                        dtsRepresentante.Merge(DB_VAK020.ObtemApropriacaoVigorTerritório(Convert.ToInt32(linha("CODTETVND")), oCnx))

                        'Se não existir, apropriar território
                        If dtsRepresentante.Tables("tblApropriacao").Rows.Count = 0 Then
                            DB_VAK020.InserirApropriacaoTerritorio(Convert.ToInt32(CodigoRepresentante), _
                                                                   Convert.ToInt32(CodigoRepresentanteSubstituto), _
                                                                   DuracaoDiasApropriacao, _
                                                                   linha("CODTETVND"), _
                                                                   oCnx)
                        End If

                    End If

                Next
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Envia email para a ação "Aprovação do Gerente de Vendas"
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="URLSistema">URL do sistema</param>
    ''' <param name="EnviarJuridico">Enviar email para o jurídico? (True/False)</param>
    ''' <param name="TipoDesativacao">Tipo da desativação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>ID do email</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function EnviarEmailAprovacaoGV(ByVal CodigoFluxo As Decimal, _
                                           ByVal URLSistema As String, _
                                           ByVal EnviarJuridico As Boolean, _
                                           ByVal TipoDesativacao As Constantes.TipoDesativacao, _
                                           ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer
        Try
            Dim wsEmail As New Email.Email
            Dim dsFuncionariosAutonomos As DataSet
            Dim dsFuncionariosJuridico As DataSet

            Dim DB_VAK020 As New DB_VAKFluDstRep
            Dim dsRCA As DataSet
            Dim strCabecalho As String
            Dim Corpo(5) As String

            Dim NomeGerenteVendas As String
            Dim NomeRCA As String
            Dim CodigoFuncionarioGV As Integer

            Dim EnderecosContador As Integer
            Dim IdEmail As Integer

            'Consulta dados representante
            dsRCA = DB_VAK020.ObterRepresentantePorFluxo(CodigoFluxo, oCnx) 'TblRepFlu
            If dsRCA.Tables("TblRepFlu").Rows.Count > 0 Then
                NomeGerenteVendas = Convert.ToString(dsRCA.Tables("TblRepFlu").Rows(0)("NOMGER")).Trim
                NomeRCA = Convert.ToString(dsRCA.Tables("TblRepFlu").Rows(0)("NOMREP")).Trim
                CodigoFuncionarioGV = Convert.ToInt32(dsRCA.Tables("TblRepFlu").Rows(0)("CODFNCGER"))
            Else
                Throw New Exception("Não foi possível retornar dados do representante do fluxo nro.: " & CodigoFluxo)
            End If

            '==== AUTÔNOMOS =====

            'Consulta Autônomos 
            dsFuncionariosAutonomos = _
                DB_VAK020.FuncionariosPorModuloObter(Constantes.ModulosAutorizacao.Autonomos, _
                                                     oCnx)
            EnderecosContador = dsFuncionariosAutonomos.Tables("TblFncMdl").Rows.Count
            Dim Endereco(EnderecosContador) As Email.EnderecoEmail

            'Endereço Remetente
            EnderecosContador = 0
            Endereco(EnderecosContador) = New Email.EnderecoEmail
            Endereco(EnderecosContador).Endereco = Convert.ToString(CodigoFuncionarioGV)
            Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Remetente
            Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
            EnderecosContador += 1

            'Endereço Destinatário - Autonomos
            For Each linha As DataRow In dsFuncionariosAutonomos.Tables("TblFncMdl").Rows
                Endereco(EnderecosContador) = New Email.EnderecoEmail
                Endereco(EnderecosContador).Endereco = Convert.ToString(linha("CODFNC"))
                Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Destinatario
                Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
                EnderecosContador += 1
            Next

            'Cabeçalho e corpo
            If TipoDesativacao = Constantes.TipoDesativacao.Indenizacao_Normal Then
                If EnviarJuridico Then
                    strCabecalho = "Fluxo de Rescisão de Contrato com Representante - Tribunal de Arbitragem"
                    Corpo(0) = "A desativação do representante " & NomeRCA.Trim
                    Corpo(1) = "necessita ser formalizada pelo Departamento Jurídico"
                    Corpo(2) = "através de um Tribunal de Arbitragem."
                    Corpo(3) = "Para ver os detalhes, acesse o sistema de Administração de Vendas"
                    Corpo(4) = "(" & URLSistema.Split(Convert.ToChar(","))(0) & ") e selecione a opção"
                    Corpo(5) = "'Rescisão de Contratos' no menu 'Representantes'."
                Else
                    strCabecalho = "Fluxo de Rescisão de Contrato com Representante Aprovado pelo Sistema"
                    Corpo(0) = "O sistema aprovou automaticamente o fluxo "
                    Corpo(1) = " de desativação do representante " & NomeRCA.Trim & "."
                    Corpo(2) = "Para ver os detalhes e realizar as ações necessárias, acesse o sistema"
                    Corpo(3) = "de Administração de Vendas (" & URLSistema.Split(Convert.ToChar(","))(0) & ")"
                    Corpo(4) = " e selecione a opção 'Rescisão de Contratos'"
                    Corpo(5) = " no menu 'Representantes'."
                End If
            ElseIf TipoDesativacao = Constantes.TipoDesativacao.Notificacao_para_cumprimento_do_contrato Then
                strCabecalho = "Fluxo de Rescisão de Contrato com Representante Aprovado pelo Sistema"
                Corpo(0) = "O Sistema aprovou automaticamente o fluxo "
                Corpo(1) = "de desativação do representante " & NomeRCA.Trim & "."
                Corpo(2) = "Para ver os detalhes e realizar as ações necessárias, acesse o sistema"
                Corpo(3) = "de Administração de Vendas (" & URLSistema.Split(Convert.ToChar(","))(0) & ")"
                Corpo(4) = "e selecione a opção 'Rescisão de Contratos'"
                Corpo(5) = "no menu 'Representantes'."
            End If

            IdEmail = wsEmail.EmailEnviar(51, strCabecalho, Endereco, Corpo, Constantes.APLICACAO_DELEGACAO)

            If EnviarJuridico Then

                '==== JURÍDICO ======

                'Consulta Jurídicos
                dsFuncionariosJuridico = _
                    DB_VAK020.FuncionariosPorModuloObter(Constantes.ModulosAutorizacao.Juridico, oCnx)
                EnderecosContador = dsFuncionariosJuridico.Tables("TblFncMdl").Rows.Count
                ReDim Endereco(EnderecosContador)

                'Endereço Remetente
                EnderecosContador = 0
                Endereco(EnderecosContador) = New Email.EnderecoEmail
                Endereco(EnderecosContador).Endereco = Convert.ToString(CodigoFuncionarioGV)
                Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Remetente
                Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
                EnderecosContador += 1

                'Endereço Destinatário - Autonomos
                For Each linha As DataRow In dsFuncionariosJuridico.Tables("TblFncMdl").Rows
                    Endereco(EnderecosContador) = New Email.EnderecoEmail
                    Endereco(EnderecosContador).Endereco = Convert.ToString(linha("CODFNC"))
                    Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Destinatario
                    Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
                    EnderecosContador += 1
                Next

                'Cabeçalho e corpo
                If TipoDesativacao = Constantes.TipoDesativacao.Indenizacao_Normal Then
                    strCabecalho = "Fluxo de Rescisão de Contrato com Representante - Tribunal de Arbitragem"
                    Corpo(0) = "A desativação do representante " & NomeRCA.Trim
                    Corpo(1) = "necessita ser formalizada através de um Tribunal de Arbitragem."
                    Corpo(2) = "Para ver os detalhes e realizar as ações necessárias, acesse o sistema"
                    Corpo(3) = "de Administração de Vendas (" & URLSistema.Split(Convert.ToChar(","))(0) & ")"
                    Corpo(4) = "e selecione a opção 'Rescisão de Contratos'"
                    Corpo(5) = "no menu 'Representantes'"
                End If

                IdEmail = wsEmail.EmailEnviar(51, strCabecalho, Endereco, Corpo, Constantes.APLICACAO_DELEGACAO)
            End If


            Return IdEmail

        Catch ex As Exception
            Throw
        End Try

    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Enviar email para aprovação do gerente de venda com equipamentos
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo de desativação</param>
    ''' <param name="URLSistema">URL do sistema</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function EnviarEmailAprovacaoGVComEquipamentos(ByVal CodigoFluxo As Integer, _
                                                          ByVal URLSistema As String, _
                                                          ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer


        Try
            Dim wsEmail As New Email.Email
            Dim dsFuncionariosContabilidade As DataSet
            Dim dsFuncionariosCMI As DataSet
            Dim dsRCA As DataSet

            Dim DB_VAK020 As New DB_VAKFluDstRep
            Dim strCabecalho As String
            Dim Corpo(4) As String

            Dim NomeGerenteVendas As String
            Dim NomeRCA As String
            Dim CodigoFuncionarioGV As Integer

            Dim EnderecosContador As Integer
            Dim IdEmail As Integer

            'Consultas
            dsFuncionariosContabilidade = DB_VAK020.FuncionariosPorModuloObter(Constantes.ModulosAutorizacao.Contabilidade, _
                                                                               oCnx) '
            dsFuncionariosCMI = DB_VAK020.FuncionariosPorModuloObter(Constantes.ModulosAutorizacao.CMI, _
                                                                     oCnx)
            dsRCA = DB_VAK020.ObterRepresentantePorFluxo(CodigoFluxo, _
                                                         oCnx)
            If dsRCA.Tables("TblRepFlu").Rows.Count > 0 Then
                NomeGerenteVendas = Convert.ToString(dsRCA.Tables("TblRepFlu").Rows(0)("NOMGER")).Trim
                NomeRCA = Convert.ToString(dsRCA.Tables("TblRepFlu").Rows(0)("NOMREP")).Trim
                CodigoFuncionarioGV = Convert.ToInt32(dsRCA.Tables("TblRepFlu").Rows(0)("CODFNCGER"))
            Else
                Throw New Exception("Não foi possível retornar dados do representante do fluxo nro.: " & CodigoFluxo)
            End If

            'Endereço Remetente
            EnderecosContador = _
                dsFuncionariosContabilidade.Tables("TblFncMdl").Rows.Count + _
                dsFuncionariosCMI.Tables("TblFncMdl").Rows.Count
            Dim Endereco(EnderecosContador) As Email.EnderecoEmail

            'Endereço Remetente
            EnderecosContador = 0
            Endereco(EnderecosContador) = New Email.EnderecoEmail
            Endereco(EnderecosContador).Endereco = Convert.ToString(CodigoFuncionarioGV)
            Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Remetente
            Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
            EnderecosContador += 1

            'Endereço Destinatário - Contabilidade
            For Each linha As DataRow In dsFuncionariosContabilidade.Tables("TblFncMdl").Rows
                Endereco(EnderecosContador) = New Email.EnderecoEmail
                Endereco(EnderecosContador).Endereco = Convert.ToString(linha("CODFNC"))
                Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Destinatario
                Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
                EnderecosContador += 1
            Next
            'Endereço Destinatário - CMI
            For Each linha As DataRow In dsFuncionariosCMI.Tables("TblFncMdl").Rows
                Endereco(EnderecosContador) = New Email.EnderecoEmail
                Endereco(EnderecosContador).Endereco = Convert.ToString(linha("CODFNC"))
                Endereco(EnderecosContador).TipoEndereco = Email.enmTipoEndereco.Destinatario
                Endereco(EnderecosContador).TipoEntidade = Email.enmTipoEntidade.Funcionario
                EnderecosContador += 1
            Next

            'Cabeçalho e corpo
            strCabecalho = "Fluxo de Rescisão de Contrato com Representante Aprovado pelo Sistema"
            Corpo(0) = "O sistema aprovou automaticamente "
            Corpo(1) = "o fluxo de desativação do representante " & NomeRCA
            Corpo(2) = "Para ver os detalhes e realizar as ações necessárias, acesse o sistema "
            Corpo(3) = "de Administração de Vendas (" & URLSistema.Split(Convert.ToChar(","))(0) & ") "
            Corpo(4) = "e selecione a opção 'Rescisão de Contratos' no menu 'Representantes'."
            IdEmail = wsEmail.EmailEnviar(51, strCabecalho, Endereco, Corpo, Constantes.APLICACAO_DELEGACAO)

            Return IdEmail

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Inserir ação equipamentos recuperados
    ''' </summary>
    ''' <param name="intCodigoFluxo">Código do fluxo</param>
    ''' <param name="intCodigoFuncionarioResponsavel">Código funcionário responsável</param>
    ''' <param name="strTextoObservacao">Texto da observação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	3/7/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub InserirEquipamentosRecuperados(ByVal intCodigoFluxo As Integer, _
                                              ByVal intCodigoFuncionarioResponsavel As Integer, _
                                              ByVal strTextoObservacao As String, _
                                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Dim oGrpDdo As DataSet
        Dim iCodPrxAco As Integer
        Dim iCodPrxObs As Integer
        Dim intCodigoTipoDesativacaoRCA As Integer
        Dim datDataCartaRescisao As Date
        Dim intCodigoRCA As Integer
        Dim intCodigoSituacaoRCA As Integer

        Try

            iCodPrxAco = DB_VAK020.CsnPrxSeqAcoFlu(intCodigoFluxo, oCnx)
            iCodPrxObs = DB_VAK020.CsnPrxCodObsFlu(intCodigoFluxo, oCnx)

            'Inserir ação
            DB_VAK020.IsrAcoFlu(intCodigoFluxo, _
                                iCodPrxAco, _
                                Constantes.Acao.EQUIPAMENTOS_RECUPERADOS, _
                                intCodigoFuncionarioResponsavel, _
                                iCodPrxObs, _
                                0, _
                                oCnx)

            'Inserir observação
            Dim strObs() As String = Constantes.WordWrap(strTextoObservacao, 2000)
            Dim intCount As Integer
            For intCount = 0 To strObs.Length - 1
                If Not strObs(intCount) Is Nothing Then
                    DB_VAK020.IsrObsFlu(intCodigoFluxo, _
                                        iCodPrxObs, _
                                        intCount + 1, _
                                        strObs(intCount), _
                                        oCnx)
                End If
            Next

            'Atualiza equipamentos
            DB_VAK020.FluxoEquipamentosStatusAtualizar(42, intCodigoFluxo, oCnx)
            DB_VAK020.FluxoEquipamentosHistoricoInserir(intCodigoFluxo, oCnx)

            oGrpDdo = DB_VAK020.ObterRepresentantePorFluxo(intCodigoFluxo, oCnx)
            If oGrpDdo.Tables("TblRepFlu").Rows.Count > 0 Then
                intCodigoSituacaoRCA = oGrpDdo.Tables("TblRepFlu").Rows(0)("CODSITREP")
                intCodigoTipoDesativacaoRCA = oGrpDdo.Tables("TblRepFlu").Rows(0)("CODTIPDSTREP")
                If Not IsDBNull(oGrpDdo.Tables("TblRepFlu").Rows(0)("DATDOCSLCDST")) Then
                    datDataCartaRescisao = oGrpDdo.Tables("TblRepFlu").Rows(0)("DATDOCSLCDST")
                Else
                    datDataCartaRescisao = New Date(1, 1, 1)
                End If
                intCodigoRCA = oGrpDdo.Tables("TblRepFlu").Rows(0)("CODREP")
            End If

            'Alterar situação do representante
            AlterarSituacaoRCAPorTipoDesativacao(intCodigoTipoDesativacaoRCA, _
                                                 datDataCartaRescisao, _
                                                 intCodigoRCA, _
                                                 intCodigoSituacaoRCA, _
                                                 intCodigoFuncionarioResponsavel, _
                                                 oCnx)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Altera SituaÇÃo RCA por tipo desativação
    ''' </summary>
    ''' <param name="intCodigoTipoDesativacaoRCA">Código do tipo de desativação do RCA</param>
    ''' <param name="DataCartaRescisao">Data da carta de rescisão</param>
    ''' <param name="intCodigoRCA">Código do representante</param>
    ''' <param name="intCodigoSituacaoRCA">Código da situação do RCA</param>
    ''' <param name="intCodigoFuncionarioResponsavel">Código do funcionário responsável</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	27/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AlterarSituacaoRCAPorTipoDesativacao(ByVal intCodigoTipoDesativacaoRCA As Integer, _
                                                    ByVal DataCartaRescisao As Date, _
                                                    ByVal intCodigoRCA As Integer, _
                                                    ByVal intCodigoSituacaoRCA As Integer, _
                                                    ByVal intCodigoFuncionarioResponsavel As Integer, _
                                                    ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)
        Try
            Dim intNvoCodSitRep As Integer = 0
            If DataCartaRescisao <> New Date(1, 1, 1) Then
                intNvoCodSitRep = 7
            ElseIf intCodigoTipoDesativacaoRCA = 1 Then
                intNvoCodSitRep = 8
            End If

            If intNvoCodSitRep <> 0 Then
                AlterarSituacaoRepresentante(intNvoCodSitRep, _
                                                         intCodigoRCA, _
                                                         intCodigoSituacaoRCA, _
                                                         intCodigoFuncionarioResponsavel, _
                                                         oCnx)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NovoCodigoSituacaoRepresentante"></param>
    ''' <param name="CodigoRepresentante"></param>
    ''' <param name="CodigoAnteriorSituacaoRepresentante"></param>
    ''' <param name="CodigoFuncionarioResponsavel"></param>
    ''' <param name="oCnx"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio]	27/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AlterarSituacaoRepresentante(ByVal NovoCodigoSituacaoRepresentante As Integer, _
                                            ByVal CodigoRepresentante As Integer, _
                                            ByVal CodigoAnteriorSituacaoRepresentante As Integer, _
                                            ByVal CodigoFuncionarioResponsavel As Integer, _
                                            ByVal oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim DB_VAK020 As New DB_VAKFluDstRep
        Try

            DB_VAK020.InserirHistorico("T0100116", _
                                       "CODSITREP", _
                                       Constantes.TipoDado.Numerico, _
                                       "CODREP", _
                                       CodigoRepresentante, _
                                       CodigoFuncionarioResponsavel, _
                                       CodigoAnteriorSituacaoRepresentante, _
                                       NovoCodigoSituacaoRepresentante, _
                                       oCnx)

            DB_VAK020.AtualizarSituacaoRepresentante(NovoCodigoSituacaoRepresentante, _
                                        CodigoRepresentante, _
                                        oCnx)

            DB_VAK020.InserirHistoricoAntigo(CodigoRepresentante, _
                                oCnx)

        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
        Finally
            oCnx.Dispose()
        End Try
    End Sub

End Class