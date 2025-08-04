''' -----------------------------------------------------------------------------
''' Project	 : VAK020
''' Class	 : DB_VAKFluDstRep
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
Public Class DB_VAKFluDstRep

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tipos de ações possíveis no fluxo de desativação do representante (RCA).
    ''' </summary>
    ''' <remarks>
    ''' Sempre que incluir novas ações na base de dados, deve-se incluir neste enumerador.
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	22/01/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum enmTipAcoFlu
        FluxoIniciado
        NotificacaoCumprimentoContrato
        NotificacaoOutrosMotivos
        ComunicaoEnviada
        ObservacoesIncluidas
        FluxoCancelado
        RcaNotificado
        FluxoConcluido
        ParecerSolicitado
        ParecerRespondido
        FluxoReijeitado
    End Enum


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta pendências de RPA e notas fiscais do representante (RCA).
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <param name="iCodRep">Código do representante (RCA)</param>
    ''' <returns>Conjunto de dados (dataset) com pendências</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	21/01/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnPndRpaNotFscRep(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                                ByVal iCodRep As Integer) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select count(prv.anomesref) ")
            oStrBld.Append(" from mrt.T0109067 prv ")
            oStrBld.Append(" inner join mrt.t0100116 rep ")
            oStrBld.Append(" on prv.numdocede = rep.NUMCGCEMPREP ")
            oStrBld.Append(" where  FLGRBOPGTPVTEDE = 'S' ")
            oStrBld.Append(" and rep.codrep = " & iCodRep)

            oStrBld.Append(" union ")

            oStrBld.Append(" select count(prv.anomesref) ")
            oStrBld.Append(" from mrt.T0109067 prv ")
            oStrBld.Append(" inner join mrt.t0100116 rep ")
            oStrBld.Append(" on prv.numdocede = rep.numcpfrep ")
            oStrBld.Append(" where  FLGRBOPGTPVTEDE = 'S' ")
            oStrBld.Append(" and rep.codrep = " & iCodRep)

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)

            oAcsDdo.ExcCmdSql(CsnPndRpaNotFscRep)
            CsnPndRpaNotFscRep.Tables(0).TableName = "tblPrvRep"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de ações de um fluxo.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <param name="iCodFluDstRep">Código do fluxo de desativação do representante</param>
    ''' <returns>Conjunto de dados (dataset) com lista de açõs do fluxo</returns>
    ''' <remarks>
    ''' SQL06
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	22/01/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstAcoFluRep(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                             ByVal iCodFluDstRep As Integer, _
                             Optional ByVal iTipAco As enmTipAcoFlu = -1) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select fluaco.numseq, aco.desacousr, fluaco.datcri, ")
            oStrBld.Append(" fnc.nomfnc, obs.desobs ")
            oStrBld.Append(" from mrt.rlcfludstrepaco fluaco ")
            oStrBld.Append(" inner join mrt.cadacofludstrep aco on aco.codaco = fluaco.codaco ")
            oStrBld.Append(" inner join mrt.t0100361 fnc on fnc.codfnc = fluaco.codfncrpncri ")
            oStrBld.Append(" left join mrt.cadobsfludstrep obs on obs.codfludstrep = fluaco.codfludstrep ")
            oStrBld.Append(" and obs.codobs = fluaco.codobs ")
            oStrBld.Append(" and obs.numseq = 1 ")
            oStrBld.Append(" where fluaco.codfludstrep = " & iCodFluDstRep)
            If iTipAco <> -1 Then
                oStrBld.Append(" and fluaco.codaco =  " & iTipAco)
            End If
            oStrBld.Append(" order by fluaco.datcri ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnLstAcoFluRep)
            CsnLstAcoFluRep.Tables(0).TableName = "tblLstFluDstRep"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de RCAS (incluindo os sem fluxos) do GV.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="sNomRep">Nome do representante</param>
    ''' <param name="iQdeDiaSemPed">Quant. dias sem emissão de pedido de vendas</param>
    ''' <param name="sDesSitFlu">Situação do fluxo de desativação</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstRep(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                       ByVal iCodSup As Integer, _
                       ByVal iCodRep As Integer, _
                       ByVal sNomRep As String, _
                       ByVal iQdeDiaSemPed As Integer, _
                       ByVal sDesSitFlu As String) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim oGrpDdo As DataSet
        Try
            oStrBld.Append(" with TABAUX as ( " & vbCrLf)
            oStrBld.Append(" select REP.CODREP, REP.NOMREP, REP.QDEDIASEMPED, " & vbCrLf)
            oStrBld.Append("   case when " & vbCrLf)
            oStrBld.Append("   (select count(FLU.CODFLUDSTREP) from MRT.CADFLUDSTREP FLU " & vbCrLf)
            oStrBld.Append("    where FLU.CODREP = REP.CODREP " & vbCrLf)
            oStrBld.Append("    and (select count(*) from MRT.RLCFLUDSTREPACO ACO where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("         and ACO.CODACO = 1) = 0) > 0 then 'Criado' " & vbCrLf)
            oStrBld.Append("   when " & vbCrLf)
            oStrBld.Append("   (select count(FLU.CODFLUDSTREP) from MRT.CADFLUDSTREP FLU " & vbCrLf)
            oStrBld.Append("    where FLU.CODREP = REP.CODREP " & vbCrLf)
            oStrBld.Append("    and (select ACO.CODACO from MRT.RLCFLUDSTREPACO ACO " & vbCrLf)
            oStrBld.Append("    where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP and ACO.NUMSEQ = " & vbCrLf)
            oStrBld.Append("     (select max(ULTACO.NUMSEQ) from MRT.RLCFLUDSTREPACO ULTACO " & vbCrLf)
            oStrBld.Append("      where ULTACO.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("      and ULTACO.CODACO not in (4,5,9,10,16,18,19,22,23,24,25,26,27,28))) = 11) > 0 then 'A Revisar' " & vbCrLf)
            oStrBld.Append("   when " & vbCrLf)
            oStrBld.Append("   (select count(FLU.CODFLUDSTREP) from MRT.CADFLUDSTREP FLU " & vbCrLf)
            oStrBld.Append("    where FLU.CODREP = REP.CODREP " & vbCrLf)
            oStrBld.Append("    and (select count(*) from MRT.RLCFLUDSTREPACO ACO where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("         and ACO.CODACO = 1) > 0 " & vbCrLf)
            oStrBld.Append("    and (select count(*) from MRT.RLCFLUDSTREPACO ACO where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("         and ACO.CODACO in (6,8)) = 0 " & vbCrLf)
            oStrBld.Append("   ) > 0 then 'Iniciado' " & vbCrLf)
            oStrBld.Append("   else 'Inexistente' end as FluxoDeDesativacao, " & vbCrLf)
            oStrBld.Append("   (select count(*) from MRT.T0109067 DOC " & vbCrLf)
            oStrBld.Append("    where DOC.TIPEDE = 3 and DOC.FLGRBOPGTPVTEDE = 'N' and DOC.NUMDOCEDE in " & vbCrLf)
            oStrBld.Append("     (select distinct(HST.CDONVOCPO) as NUMDOC from MRT.HSTALTTABADMVND HST " & vbCrLf)
            oStrBld.Append("      where HST.NOMTAB = 'T0100116' and HST.CODCHVTAB = REP.CODREP " & vbCrLf)
            oStrBld.Append("      and HST.NOMCPO = 'NUMCGCEMPREP' and HST.CDONVOCPO is not null " & vbCrLf)
            oStrBld.Append("      and trim(HST.CDONVOCPO) not in ('0','') " & vbCrLf)
            oStrBld.Append("        union " & vbCrLf)
            oStrBld.Append("      select REPFIS.NUMCPFREP as NUMDOC from MRT.T0100116 REPFIS " & vbCrLf)
            oStrBld.Append("      where REPFIS.CODREP = REP.CODREP " & vbCrLf)
            oStrBld.Append("        union " & vbCrLf)
            oStrBld.Append("      select REPJUR.NUMCGCEMPREP as NUMDOC from MRT.T0100116 REPJUR " & vbCrLf)
            oStrBld.Append("      where REPJUR.CODREP = REP.CODREP and REPJUR.NUMCGCEMPREP is not null)) " & vbCrLf)
            'oStrBld.Append("   as QuantidadeDeRecibosDevidos, 1 as CodigoDoFluxoMaisRecente " & vbCrLf) 'ALTERAR HARD CODE AQUI.
            oStrBld.Append("   as QuantidadeDeRecibosDevidos " & vbCrLf)
            oStrBld.Append(" from MRT.T0100116 REP " & vbCrLf)
            oStrBld.Append(" where REP.DATDSTREP is null and REP.TIPREP <> 4 and REP.CODSUP = " & iCodSup.ToString & vbCrLf)
            If iQdeDiaSemPed <> -1 Then
                oStrBld.Append("  and  REP.QDEDIASEMPED >= " & iQdeDiaSemPed.ToString & vbCrLf)
            End If
            If iCodRep <> -1 Then
                oStrBld.Append("  and REP.CODREP = " & iCodRep.ToString & vbCrLf)
            End If
            If sNomRep.Trim.Length > 0 Then
                oStrBld.Append("  and REP.NOMREP like '%" & sNomRep.Trim.ToUpper & "%' " & vbCrLf)
            End If
            oStrBld.Append(" ) " & vbCrLf)
            oStrBld.Append(" select TAB.CODREP, TAB.NOMREP, TAB.QDEDIASEMPED, TAB.FluxoDeDesativacao, " & vbCrLf)
            oStrBld.Append(" TAB.QuantidadeDeRecibosDevidos, " & vbCrLf)
            oStrBld.Append(" case when TAB.FluxoDeDesativacao = 'Inexistente' then 0 else " & vbCrLf)
            oStrBld.Append(" (select max(ULTFLU.CODFLUDSTREP) from MRT.CADFLUDSTREP ULTFLU " & vbCrLf)
            oStrBld.Append(" where ULTFLU.CODREP = TAB.CODREP) end as CodigoDoFluxoMaisRecente " & vbCrLf)
            oStrBld.Append(" from TABAUX TAB " & vbCrLf)
            If sDesSitFlu <> "" Then
                oStrBld.Append(" where TAB.FluxoDeDesativacao = '" & sDesSitFlu.Trim & "'" & vbCrLf)
            End If

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            oGrpDdo.Tables(0).TableName = "tblLstRep"
            Return oGrpDdo
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de RPAs/NFs devidos pelo RCA.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstRpaNfsRep(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                             ByVal iCodRep As Integer) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select DOC.ANOMESREF from MRT.T0109067 DOC  ")
            oStrBld.Append(" where DOC.TIPEDE = 3 and DOC.FLGRBOPGTPVTEDE = 'N' and DOC.NUMDOCEDE in  ")
            oStrBld.Append("   (     select distinct(HST.CDONVOCPO) as NUMDOC from MRT.HSTALTTABADMVND HST  ")
            oStrBld.Append("         where HST.NOMTAB = 'T0100116' and HST.CODCHVTAB = " & iCodRep.ToString)
            oStrBld.Append("         and HST.NOMCPO = 'NUMCGCEMPREP' and HST.CDONVOCPO is not null  ")
            oStrBld.Append("         and trim(HST.CDONVOCPO) not in ('0','')  ")
            oStrBld.Append("      union  ")
            oStrBld.Append("         select REP.NUMCPFREP as NUMDOC from MRT.T0100116 REP  ")
            oStrBld.Append("         where REP.CODREP = " & iCodRep.ToString)
            oStrBld.Append("      union  ")
            oStrBld.Append("         select REP.NUMCGCEMPREP as NUMDOC from MRT.T0100116 REP  ")
            oStrBld.Append("         where REP.CODREP = " & iCodRep.ToString & " and REP.NUMCGCEMPREP is not null  ")
            oStrBld.Append("   )  ")
            oStrBld.Append(" ORDER BY DOC.ANOMESREF ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnLstRpaNfsRep)
            CsnLstRpaNfsRep.Tables(0).TableName = "tblLstRpaNfsRep"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de fluxos do Gerente de Mercado.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="sNomRep">Nome do representante</param>
    ''' <param name="dDatIni">Data inicial</param>
    ''' <param name="dDatFim">Data final</param>
    ''' <param name="bMinhasPendencias">Minhas pendências (sim/não)</param>
    ''' <param name="iCodFlu">Código Fluxo</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnLstFluSup(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, _
                          ByVal iCodSup As Integer, _
                          ByVal iCodRep As Integer, _
                          ByVal sNomRep As String, _
                          ByVal dDatIni As Date, _
                          ByVal dDatFim As Date, _
                          ByVal bMinhasPendencias As Boolean, _
                          ByVal iCodFlu As Integer) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oStrBld.Append(" with TABAUX as ( ")
            oStrBld.Append(" select FLU.CODFLUDSTREP, REP.CODREP, REP.NOMREP, FLU.DATCRI,  " & vbCrLf)
            oStrBld.Append("  " & vbCrLf)
            oStrBld.Append(" case when " & vbCrLf)
            oStrBld.Append("   (select count(*) from MRT.RLCFLUDSTREPACO PEDOPN " & vbCrLf)
            oStrBld.Append("     left join MRT.RLCFLUDSTREPACO RSPOPN " & vbCrLf)
            oStrBld.Append("     on PEDOPN.CODFLUDSTREP = RSPOPN.CODFLUDSTREP and PEDOPN.NUMSEQ = " & vbCrLf)
            oStrBld.Append("        case when length(translate(trim(RSPOPN.CODAUXACO),' +-.0123456789',' ')) is null then to_number(RSPOPN.CODAUXACO) else -1 end " & vbCrLf)
            oStrBld.Append("     and PEDOPN.CODACO = 9 and RSPOPN.CODACO = 10 " & vbCrLf)
            oStrBld.Append("    where FLU.CODFLUDSTREP = PEDOPN.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("     and case when length(translate(trim(PEDOPN.CODAUXACO),' +-.0123456789',' ')) is null then to_number(PEDOPN.CODAUXACO) else -1 end = SUP.CODFNCSUP " & vbCrLf)
            oStrBld.Append("     and RSPOPN.NUMSEQ is null) > 0 then 'Sim' " & vbCrLf)
            oStrBld.Append("                                    else 'Não' " & vbCrLf)
            oStrBld.Append("                                    end as AguardaRespostaDeParecerPeloGM,  " & vbCrLf)
            oStrBld.Append("  " & vbCrLf)
            oStrBld.Append(" case when " & vbCrLf)
            oStrBld.Append("   (select ACO.CODACO from MRT.RLCFLUDSTREPACO ACO " & vbCrLf)
            oStrBld.Append("    where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP and ACO.NUMSEQ = " & vbCrLf)
            oStrBld.Append("     (select max(ULTACO.NUMSEQ) from MRT.RLCFLUDSTREPACO ULTACO " & vbCrLf)
            oStrBld.Append("      where ULTACO.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
            oStrBld.Append("      and ULTACO.CODACO not in (4,5,9,10,16,18,19,22,23,24,25,26,27,28))) = 11 " & vbCrLf)
            oStrBld.Append(" then 'Sim (revisão)' " & vbCrLf)
            oStrBld.Append(" when (select count(*) from MRT.RLCFLUDSTREPACO ACO " & vbCrLf)
            oStrBld.Append("    where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP and ACO.CODACO = 1) = 0 " & vbCrLf)
            oStrBld.Append(" then 'Sim' else 'Não' end as AguardaInicioOuRevisao, " & vbCrLf)

            oStrBld.Append(" case when (select count(*) from MRT.RLCFLUDSTREPACO ACO " & vbCrLf)
            oStrBld.Append(" where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP and ACO.CODACO = 8) > 0 " & vbCrLf)
            oStrBld.Append(" then 'Concluído' " & vbCrLf)
            oStrBld.Append(" when (select count(*) from MRT.RLCFLUDSTREPACO ACO " & vbCrLf)
            oStrBld.Append(" where ACO.CODFLUDSTREP = FLU.CODFLUDSTREP and ACO.CODACO = 6) > 0 " & vbCrLf)
            oStrBld.Append(" then 'Cancelado' " & vbCrLf)
            oStrBld.Append(" else 'Em Andamento' end as Estado " & vbCrLf)

            oStrBld.Append("  " & vbCrLf)
            oStrBld.Append(" from MRT.CADFLUDSTREP FLU " & vbCrLf)
            oStrBld.Append(" inner join MRT.T0100116 REP on FLU.CODREP = REP.CODREP " & vbCrLf)
            oStrBld.Append(" inner join MRT.T0100124 SUP on REP.CODSUP = SUP.CODSUP " & vbCrLf)
            oStrBld.Append(" where REP.TIPREP <> 4  " & vbCrLf)
            oStrBld.Append("  " & vbCrLf)
            If iCodFlu <> -1 Then
                oStrBld.Append(" and FLU.CODFLUDSTREP = " & iCodFlu.ToString & vbCrLf)
            End If
            If iCodRep <> -1 Then
                oStrBld.Append(" and REP.CODREP = " & iCodRep.ToString & vbCrLf)
            End If
            oStrBld.Append("  " & vbCrLf)
            If sNomRep <> "" Then
                oStrBld.Append(" and REP.NOMREP like '%" & sNomRep.ToUpper & "%' " & vbCrLf)
            End If
            oStrBld.Append(" and SUP.DATDSTSUP is null and SUP.CODSUP = " & iCodSup.ToString & vbCrLf)
            If dDatIni > New Date(1901, 1, 1) And dDatFim > New Date(1901, 1, 1) Then
                oStrBld.Append(" and FLU.DATCRI between date '" & Format(dDatIni, "yyyy-MM-dd") & "' and date '" & Format(dDatFim.AddDays(1), "yyyy-MM-dd") & "'" & vbCrLf)
            End If
            oStrBld.Append(" ) " & vbCrLf)
            oStrBld.Append(" select TAB.CODFLUDSTREP, TAB.CODREP, TAB.NOMREP, TAB.DATCRI, " & vbCrLf)
            oStrBld.Append(" case when TAB.Estado = 'Em Andamento' then " & vbCrLf)
            oStrBld.Append(" TAB.AguardaRespostaDeParecerPeloGM else 'Não' end as " & vbCrLf)
            oStrBld.Append(" AguardaRespostaDeParecerPeloGM, " & vbCrLf)
            oStrBld.Append(" case when TAB.Estado = 'Em Andamento' then TAB.AguardaInicioOuRevisao else " & vbCrLf)
            oStrBld.Append(" 'Não' end as AguardaInicioOuRevisao, " & vbCrLf)
            oStrBld.Append(" TAB.Estado " & vbCrLf)
            oStrBld.Append(" from TABAUX TAB " & vbCrLf)
            '-- A cláusula "where" abaixo é aplicada por inteiro ou não é aplicada. " & vbCrLf)
            If bMinhasPendencias Then
                oStrBld.Append(" where TAB.Estado = 'Em Andamento' and " & vbCrLf)
                oStrBld.Append(" (TAB.AguardaRespostaDeParecerPeloGM = 'Sim' " & vbCrLf)
                oStrBld.Append(" or TAB.AguardaInicioOuRevisao like 'Sim%') " & vbCrLf)
            End If
            oStrBld.Append(" order by TAB.NOMREP ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnLstFluSup)
            CsnLstFluSup.Tables(0).TableName = "tblFluSup"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta cidades da unidade da federação (estado) da cidade.
    ''' </summary>
    ''' <param name="iCodCid">Código da cidade</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnCidEstUni(ByVal iCodCid As Integer, _
                          ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CID.CODCID, CID.NOMCID, CID.CODESTUNI")
            oStrBld.Append(" from MRT.T0100035 CID where CID.DATDSTCID is null ")
            oStrBld.Append(" and CID.CODESTUNI = (select CODESTUNI from MRT.T0100035 WHERE ")
            oStrBld.Append(" codcid = " & iCodCid.ToString & ")")
            oStrBld.Append(" order by NOMCID ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)

            oAcsDdo.ExcCmdSql(CsnCidEstUni)
            CsnCidEstUni.Tables(0).TableName = "tblCid"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta cidades da unidade da federação (estado).
    ''' </summary>
    ''' <param name="sEstUni">Código da unidade da federação (estado)</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnCid(ByVal sEstUni As String, _
                    ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CID.CODCID, CID.NOMCID")
            oStrBld.Append(" from MRT.T0100035 CID where CID.DATDSTCID is null ")
            oStrBld.Append(" and CID.CODESTUNI = '" & sEstUni & "'")
            oStrBld.Append(" order by NOMCID ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnCid)
            CsnCid.Tables(0).TableName = "tblCid"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta motivos da desativação.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	13/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnMtvDst(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo, ByVal CodMtvDst As Integer) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append("select codmtvdstedevnd, desmtvdstedevnd from mrt.t0105215 ")
            If CodMtvDst > -1 Then
                oStrBld.Append("where codmtvdstedevnd = " & CodMtvDst.ToString & " ")
            End If
            oStrBld.Append("order by desmtvdstedevnd ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnMtvDst)
            CsnMtvDst.Tables(0).TableName = "TabelaMotivoDesativacao"
        Finally
            oAcsDdo.Dispose()
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta representantes por gerente de mercado (podendo excluir um determinado da lista).
    ''' </summary>
    ''' <param name="iCodSup">Código do gerente de mercado</param>
    ''' <param name="iCodRep">Código do representante para não ser listado</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset) com lista de representantes do gerente de mercado</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	4/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnRepPorSup(ByVal iCodSup As Integer, _
                          ByVal iCodRep As Integer, _
                          ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select codrep, nomrep from mrt.t0100116 where codsup = " & iCodSup)
            oStrBld.Append(" and DATDSTREP is null and TIPREP <> 4")
            If iCodRep <> -1 Then
                oStrBld.Append(" and CODREP <> " & iCodRep.ToString)
            End If
            oStrBld.Append("order by nomrep ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnRepPorSup)
            CsnRepPorSup.Tables(0).TableName = "TabelaRepresentante"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta próximo código disponível para código de fluxo de desativação.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Próximo código disponível para código de fluxo de desativação</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function CsnPrxCodFlu(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim oGrpDdo As DataSet
        Try
            oStrBld.Append(" select nvl(max(codfludstrep), 0) + 1 from mrt.cadfludstrep ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            CsnPrxCodFlu = oGrpDdo.Tables(0).Rows(0)(0)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Deleta dados provisórios relacionadas ao fluxo.
    ''' </summary>
    ''' <param name="iCodFluDstRep">Código do fluxo de desativação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>1 - OK - <> 1 - ERRO</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function DelFluDstRep(ByVal iCodFluDstRep As Integer, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim oStrBld2 As Text.StringBuilder = New Text.StringBuilder
        Dim oStrBld3 As Text.StringBuilder = New Text.StringBuilder
        Try
            'Deleta fluxo
            oStrBld.Append(" delete from mrt.cadfludstrep where codfludstrep = " & iCodFluDstRep.ToString)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(DelFluDstRep)

            'Deleta observações
            oStrBld3.Append(" delete from mrt.cadobsfludstrep where codfludstrep = " & iCodFluDstRep.ToString)
            oStrBld3.Append(" and codobs <= 0 ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld3.ToString)
            oAcsDdo.ExcCmdSql(DelFluDstRep)

        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere fluxo de desativação do representante.
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
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>1 - OK - <>1 - ERRO</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function IsrFluDstRep(ByVal iCodFlu As Integer, ByVal iCodRep As Integer, _
                                 ByVal dDatCri As Date, ByVal iCodFncRpnCri As Integer, _
                                 ByVal iCodMtvDst As Integer, ByVal sDesMtvDstRep As String, _
                                 ByVal sEndREp As String, ByVal sNumTlfRep As String, _
                                 ByVal sNumTlfCelRep As String, ByVal sNumFaxRep As String, _
                                 ByVal iCodCidRep As Integer, ByVal iCodCepRep As Long, _
                                 ByVal iCodRepSbtVnd As Integer, ByVal dDatDocSlcDst As Date, _
                                 ByVal iCodTipDstRep As Integer, ByVal fVlrArdDstRep As Double, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" insert into mrt.cadfludstrep ")
            oStrBld.Append(" (CodFluDstRep, CodRep, DatCri, CodFncRpnCri, CodMtvDstEdeVnd, ")
            oStrBld.Append("  DesMtvDstRep, EndRep, NumTlfRep, NumTlfCelRep, ")
            oStrBld.Append("  NumFaxRep, CodCidRep, CodCepRep, CodRepSbtVnd, DatDocSlcDst, ")
            oStrBld.Append("  CodTipDstRep, VlrArdDstRep) ")
            oStrBld.Append(" values(" & iCodFlu & ", " & iCodRep & ",  trunc(sysdate), ")
            oStrBld.Append(iCodFncRpnCri & ", " & iCodMtvDst & ", '" & sDesMtvDstRep & "', ")
            oStrBld.Append("'" & sEndREp & "','" & sNumTlfRep & "', '" & sNumTlfCelRep & "', ")
            oStrBld.Append("'" & sNumFaxRep & "', " & iCodCidRep & ", " & iCodCepRep & ",")
            oStrBld.Append(iCodRepSbtVnd & ",")
            If dDatDocSlcDst = New Date(1, 1, 1) Then
                oStrBld.Append("null, ")
            Else
                oStrBld.Append("date '" & Format(dDatDocSlcDst, "yyyy-MM-dd") & "', ")
            End If
            oStrBld.Append(iCodTipDstRep & ", ")
            If fVlrArdDstRep = -1 Then
                oStrBld.Append("null)")
            Else
                oStrBld.Append(fVlrArdDstRep.ToString(New Globalization.CultureInfo("en-us")) & ")")
            End If
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(IsrFluDstRep)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere ação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <param name="iCodFncRpnCri">Código func. responsável pela criação</param>
    ''' <param name="iCodObs">Código da observação</param>
    ''' <param name="iCodAuxAco">Código auxiliar da ação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>1 - OK - <>1 - ERRO</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function IsrAcoFlu(ByVal iCodFlu As Integer, _
                              ByVal iNumSeq As Integer, _
                              ByVal iCodAco As Integer, _
                              ByVal iCodFncRpnCri As Integer, _
                              ByVal iCodObs As Integer, _
                              ByVal iCodAuxAco As Integer, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" insert into mrt.rlcfludstrepaco ")
            oStrBld.Append(" (CodFluDstRep, NumSeq, CodAco, DatCri, CodFncRpnCri, CodObs, CodAuxAco) ")
            oStrBld.Append(" values ( " & iCodFlu & ", " & iNumSeq & ", " & iCodAco)
            oStrBld.Append(" , sysdate, " & iCodFncRpnCri & ", ")
            oStrBld.Append(iCodObs & ", " & iCodAuxAco & ")")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(IsrAcoFlu)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere observação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodObs">Código da observação</param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <param name="sDesObs">Descrição da observação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>1 - OK - <>1 - ERRO</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function IsrObsFlu(ByVal iCodFlu As Integer, _
                              ByVal iCodObs As Integer, _
                              ByVal iNumSeq As Integer, _
                              ByVal sDesObs As String, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" insert into MRT.CADOBSFLUDSTREP (CODFLUDSTREP, CODOBS, NUMSEQ, DESOBS) ")
            oStrBld.Append(" values (" & iCodFlu & ", " & iCodObs & ", " & iNumSeq & ", '")
            oStrBld.Append(sDesObs & "')")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(IsrObsFlu)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta fluxo de desativação
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnFluDstRep(ByVal iCodFlu As Integer, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select FLU.CODFLUDSTREP, FLU.CODREP, FLU.DATCRI, FLU.CODFNCRPNCRI, CODMTVDSTEDEVND, ")
            oStrBld.Append("  FLU.DESMTVDSTREP, FLU.ENDREP, FLU.NUMTLFREP, FLU.NUMTLFCELREP, ")
            oStrBld.Append("  FLU.NUMFAXREP, FLU.CODCIDREP, FLU.CODCEPREP, FLU.CODREPSBTVND, FLU.DATDOCSLCDST, ")
            oStrBld.Append("  FLU.CODTIPDSTREP, FLU.VLRARDDSTREP ")
            oStrBld.Append("  from MRT.CADFLUDSTREP FLU where FLU.CODFLUDSTREP = " & iCodFlu)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnFluDstRep)
            CsnFluDstRep.Tables(0).TableName = "TblFluDstRep"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' ----------------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta fluxos de desativação abertos (ainda em andamento) para um representante.
    ''' </summary>
    ''' <param name="iCodFlu">Código do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Pedro.Henrique]	21/11/2013	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnFluDstAbtRep(ByVal iCodRep As Integer, _
                                    ByVal iCodFlu As Integer, _
                                    ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select FLU.CODFLUDSTREP ")
            oStrBld.Append(" from MRT.CADFLUDSTREP FLU ")
            oStrBld.Append(" left join MRT.RLCFLUDSTREPACO ACO on FLU.CODFLUDSTREP = ACO.CODFLUDSTREP ")
            oStrBld.Append("                                  and ACO.CODACO in (6,8) ")
            oStrBld.Append(" where FLU.CODREP = " & iCodRep)
            oStrBld.Append(" and FLU.CODFLUDSTREP <> " & iCodFlu)
            oStrBld.Append(" and ACO.NUMSEQ is null ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnFluDstAbtRep)
            CsnFluDstAbtRep.Tables(0).TableName = "TblFluDstAbtRep"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta ações do fluxo
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnAcoFlu(ByVal iCodFlu As Integer, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CodFluDstRep, NumSeq, CodAco, DatCri, CodFncRpnCri, CodObs, CodAuxAco ")
            oStrBld.Append(" from mrt.cadfludstrep where CodFluDstRep = " & iCodFlu)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnAcoFlu)
            CsnAcoFlu.Tables(0).TableName = "TblAcoFlu"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta observações do fluxo (provisórias ou definitivas)
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="bObsProv">Observações provisórias? (sim/não)</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnObsFlu(ByVal iCodFlu As Integer, _
                              ByVal bObsProv As Boolean, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CADOBS.CODFLUDSTREP, CADOBS.CODOBS, CADOBS.NUMSEQ, CADOBS.DESOBS ")
            oStrBld.Append(" from MRT.CADOBSFLUDSTREP CADOBS where CADOBS.CODFLUDSTREP = " & iCodFlu)
            If bObsProv Then
                oStrBld.Append(" and CADOBS.CODOBS <= 0 ")
            Else
                oStrBld.Append(" and CADOBS.CODOBS = (select max(rlc.codobs) from MRT.RLCFLUDSTREPACO RLC where RLC.CODFLUDSTREP = " & iCodFlu & " and RLC.CODACO = 1) ")
            End If
            oStrBld.Append(" order by CADOBS.CODOBS desc ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnObsFlu)
            CsnObsFlu.Tables(0).TableName = "TblObsFlu"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de ações do fluxo
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnLstAcoFlu(ByVal iCodFlu As Integer, _
                                 ByVal iCodAco As Integer, _
                                 ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select RLC.NUMSEQ, RLC.CODACO, ACO.DESACOUSR, RLC.DATCRI, RLC.CODFNCRPNCRI, FNC.NOMFNC,  ")
            oStrBld.Append(" nvl(OBS.DESOBS, ' ') || case when (select count(*) from MRT.CADOBSFLUDSTREP OBS  ")
            oStrBld.Append(" where OBS.CODFLUDSTREP = RLC.CODFLUDSTREP and OBS.CODOBS = RLC.CODOBS  ")
            oStrBld.Append(" and OBS.NUMSEQ > 1) > 0 then '...' else '' end as DESOBS,  ")
            oStrBld.Append(" case when RLC.CODACO = 9 then 'Para: ' || trim(nvl((select FNC.NOMFNC from MRT.T0100361 FNC  ")
            oStrBld.Append(" where FNC.CODFNC = case when length(translate(trim(RLC.CODAUXACO),' +-.0123456789',' ')) is null then to_number(RLC.CODAUXACO) else -1 end),' '))  ")
            oStrBld.Append(" when RLC.CODACO = 10 then 'Resposta à solicitação número ' || RLC.CODAUXACO  ")
            oStrBld.Append(" when RLC.CODACO = 4 then 'Assunto: ' || (select DESASSCREETN from MRT.T0134274 CRE where CRE.TIPMSGCREETN = " & BO_VAKCsnMsgCreEtn._ID_SISTEMA_EMAIL & " and CRE.NUMSEQMSGCREETN = case when length(translate(trim(RLC.CODAUXACO),' +-.0123456789',' ')) is null then to_number(RLC.CODAUXACO) else -1 end) ")
            oStrBld.Append(" else 'Detalhar' end as InformacaoExtra   ")
            oStrBld.Append(" from MRT.RLCFLUDSTREPACO RLC  ")
            oStrBld.Append(" inner join MRT.T0100361 FNC on RLC.CODFNCRPNCRI = FNC.CODFNC  ")
            oStrBld.Append(" inner join MRT.CADACOFLUDSTREP ACO on RLC.CODACO = ACO.CODACO  ")
            oStrBld.Append(" left join MRT.CADOBSFLUDSTREP OBS on RLC.CODOBS = OBS.CODOBS   ")
            oStrBld.Append("                                   and RLC.CODFLUDSTREP = OBS.CODFLUDSTREP  ")
            oStrBld.Append("                                   and OBS.NUMSEQ = 1  ")
            oStrBld.Append(" where RLC.CODFLUDSTREP = " & iCodFlu.ToString)
            If iCodAco <> -1 Then
                oStrBld.Append(" and RLC.CODACO = " & iCodAco.ToString)
            End If
            oStrBld.Append(" order by RLC.DATCRI, RLC.NUMSEQ ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnLstAcoFlu)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta todos tipos de ações
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnTipAco(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select ACO.CODACO, ACO.DESACOUSR from MRT.CADACOFLUDSTREP ACO order by ACO.DESACOUSR")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnTipAco)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta unidades da federação (estados)
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnEstUni(ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select distinct codestuni ")
            oStrBld.Append(" from mrt.t0100035 ")
            oStrBld.Append(" where codestuni <> ' ' ")
            oStrBld.Append(" order by codestuni ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnEstUni)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta conteúdo do parâmetro.
    ''' </summary>
    ''' <param name="iCodPmt">Código do parâmetro</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Valor do parâmetro</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnCdoPmt(ByVal iCodPmt As Integer, _
                              ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As String

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select pmt.cdopmt from mrt.cadpmtfludstrep pmt where pmt.codpmt = " & iCodPmt)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                Return oGrpDdo.Tables(0).Rows(0)("CDOPMT")
            Else
                Throw New Exception("Não existe parâmetro " & iCodPmt.ToString & " no banco de dados.")
            End If
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta informações da equipe de vendas(REP>GM>GV) por representante
    ''' </summary>
    ''' <param name="iCodRep">Código do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnDdoRepSupGer(ByVal iCodRep As Integer, _
                                    ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select rep.codrep, rep.nomrep, rep.qdediasemped, ")
            oStrBld.Append(" sup.codfncsup, sup.codsup, sup.nomsup, ")
            oStrBld.Append(" ger.codfncger, ger.codger, ger.nomger ")
            oStrBld.Append(" from mrt.t0100116 rep ")
            oStrBld.Append(" inner join mrt.t0100124 sup ")
            oStrBld.Append(" on rep.codsup = sup.codsup ")
            oStrBld.Append(" inner join mrt.t0100051 ger ")
            oStrBld.Append(" on ger.codger = sup.codger ")
            oStrBld.Append(" where rep.codrep = " & iCodRep.ToString)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnDdoRepSupGer)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta próximo número sequencial de ação para o fluxo
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Próximo número sequencial de ação para o fluxo</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnPrxSeqAcoFlu(ByVal iCodFlu As Integer, _
                                    ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select coalesce(max(ACO.NUMSEQ), 0) + 1 as PRXNUMSEQ from mrt.RLCFLUDSTREPACO aco where codfludstrep = " & iCodFlu)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            Return oGrpDdo.Tables(0).Rows(0)("PRXNUMSEQ")
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta próximo número sequencial de ação para o fluxo
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Próximo número sequencial de ação para o fluxo</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnPrxCodObsFlu(ByVal iCodFlu As Integer, _
                                    ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select coalesce(max(OBS.CODOBS), 0) + 1 as PRXCODOBS from mrt.cadobsfludstrep obs where codfludstrep = " & iCodFlu)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            Return oGrpDdo.Tables(0).Rows(0)("PRXCODOBS")
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta usuários do sistema por trecho(parte) do nome.
    ''' </summary>
    ''' <param name="sNomFnc">Trecho do nome do funcionário</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' 	[Claudio.Rafael]	21/5/2009	Modified
    '''      A consulta passa a trazer apenas os usuários do sistema.
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnUsrSisDst(ByVal sNomFnc As String, _
                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select distinct FNC.CODFNC, FNC.NOMFNC from MRT.T0100361 FNC ")
            oStrBld.Append(" inner join mrt.t0104596 rde on rde.codfnc = fnc.codfnc ")
            oStrBld.Append(" inner join mrt.rlcmdusisdstrepfnc usu on fnc.codfnc = usu.codfnc ")
            oStrBld.Append(" where FNC.DATDEMFNC is null and FNC.NOMFNC like '%" & sNomFnc.Trim.ToUpper & "%' ")
            oStrBld.Append(" union ")
            oStrBld.Append(" select distinct FNC.CODFNC, FNC.NOMFNC from MRT.T0100361 FNC ")
            oStrBld.Append(" inner join mrt.t0104596 rde on rde.codfnc = fnc.codfnc ")
            oStrBld.Append(" inner join mrt.t0100051 ger on fnc.codfnc = ger.codfncger ")
            oStrBld.Append(" where FNC.DATDEMFNC is null and GER.DATDSTGER is null ")
            oStrBld.Append(" and FNC.NOMFNC like '%" & sNomFnc.Trim.ToUpper & "%' ")
            oStrBld.Append(" order by NOMFNC ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnUsrSisDst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta pedido / resposta de parecer por número sequencial (do pedido ou da resposta).
    ''' </summary>
    ''' <param name="iCodFluDstRep"></param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnPedOpn(ByVal iCodFluDstRep As Integer, _
                              ByVal iNumSeq As Integer, _
                              ByVal iCodAco As Integer, _
                              ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select FLU.CODFLUDSTREP, REP.CODREP, REP.NOMREP, SUP.CODSUP, SUP.NOMSUP, ")
            oStrBld.Append(" ACOPED.NUMSEQ AS NUMSEQPED, ACOPED.DATCRI AS DATCRIPED, FNCPED.CODFNC AS CODFNCPED,")
            oStrBld.Append(" FNCPED.NOMFNC AS NOMFNCPED,ACORSP.NUMSEQ AS NUMSEQRSP, ACORSP.DATCRI AS DATCRIRSP,")
            oStrBld.Append(" FNCRSP.CODFNC AS CODFNCRSP, FNCRSP.NOMFNC AS NOMFNCRSP, ")
            oStrBld.Append(" ACOPED.CODOBS AS CODOBSPED, ACORSP.CODOBS AS CODOBSRSP, ACOPED.CODAUXACO AS CODAUXPED, ")
            oStrBld.Append(" SUP.CODFNCSUP, SUP.NOMSUP ")
            oStrBld.Append(" from MRT.CADFLUDSTREP FLU ")
            oStrBld.Append(" inner join MRT.RLCFLUDSTREPACO ACOPED on FLU.CODFLUDSTREP = ACOPED.CODFLUDSTREP ")
            oStrBld.Append(" inner join MRT.T0100116 REP on REP.CODREP = FLU.CODREP ")
            oStrBld.Append(" inner join MRT.T0100124 SUP on SUP.CODSUP = REP.CODSUP ")
            oStrBld.Append(" inner join MRT.T0100361 FNCPED on FNCPED.CODFNC = ACOPED.CODFNCRPNCRI ")
            oStrBld.Append(" left join MRT.RLCFLUDSTREPACO ACORSP on ")
            oStrBld.Append("    ACORSP.CODFLUDSTREP = ACOPED.CODFLUDSTREP ")
            oStrBld.Append("    and ACOPED.CODACO = 9 ")
            oStrBld.Append("    and ACORSP.CODACO = 10 ")
            oStrBld.Append("    and ACOPED.NUMSEQ = case when length(translate(trim(ACORSP.CODAUXACO),' +-.0123456789',' ')) is null then to_number(ACORSP.CODAUXACO) else -1 end ")
            oStrBld.Append(" left join MRT.T0100361 FNCRSP on FNCRSP.CODFNC = ACORSP.CODFNCRPNCRI ")
            oStrBld.Append(" where ")
            If iCodAco = 9 Then
                oStrBld.Append(" ACOPED.NUMSEQ = " & iNumSeq.ToString)
            ElseIf iCodAco = 10 Then
                oStrBld.Append(" ACORSP.NUMSEQ = " & iNumSeq.ToString)
            End If
            oStrBld.Append(" and FLU.CODFLUDSTREP = " & iCodFluDstRep.ToString)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnPedOpn)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta observações da ação.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodObs">Código da observação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnObsAco(ByVal iCodFlu As Integer, _
                              ByVal iCodObs As Integer, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CADOBS.NUMSEQ, CADOBS.DESOBS ")
            oStrBld.Append(" from MRT.CADOBSFLUDSTREP CADOBS where CADOBS.CODFLUDSTREP = " & iCodFlu.ToString)
            oStrBld.Append(" and CADOBS.CODOBS = " & iCodObs.ToString)
            oStrBld.Append(" order by CADOBS.NUMSEQ ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnObsAco)
            CsnObsAco.Tables(0).TableName = "TblObsAco"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta ações (exceto mensagem enviada e pedido/resposta parecer)
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iNumSeq">Número sequencial da ação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnAcoGen(ByVal iCodFlu As Integer, _
                              ByVal iNumSeq As Integer, _
                              ByVal oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select FLU.CODFLUDSTREP, REP.CODREP, REP.NOMREP,")
            oStrBld.Append(" ACO.NUMSEQ, ACO.DATCRI, FNC.CODFNC,")
            oStrBld.Append(" FNC.NOMFNC, ACO.CODOBS, ACO.CODAUXACO, CADACO.CODACO, CADACO.DESACOUSR ")
            oStrBld.Append(" from MRT.CADFLUDSTREP FLU ")
            oStrBld.Append(" inner join MRT.RLCFLUDSTREPACO ACO on FLU.CODFLUDSTREP = ACO.CODFLUDSTREP ")
            oStrBld.Append(" inner join MRT.T0100116 REP on REP.CODREP = FLU.CODREP ")
            oStrBld.Append(" inner join MRT.T0100361 FNC on FNC.CODFNC = ACO.CODFNCRPNCRI ")
            oStrBld.Append(" inner join MRT.CADACOFLUDSTREP CADACO on CADACO.CODACO = ACO.CODACO ")
            'oStrBld.Append(" left join MRT.T0105215 MTVDST on ACO.CODAUXACO = case when ACO.CODACO = 34 then MTVDST.CODMTVDSTEDEVND else MTVDST.DESMTVDSTEDEVND end ")
            oStrBld.Append(" where ACO.CODFLUDSTREP = " & iCodFlu.ToString)
            oStrBld.Append(" and ACO.NUMSEQ = " & iNumSeq.ToString)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnAcoGen)
            CsnAcoGen.Tables(0).TableName = "TblAcoGen"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta lista de pedidos de parecer pendentes (por funcionário).
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodFncRpnCri">Código func. responsável pela criação</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnLstPedOpn(ByVal iCodFlu As Integer, _
                                 ByVal iCodFncRpnCri As Integer, _
                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select ACOPED.NUMSEQ, FNCSLC.NOMFNC, ACOPED.DATCRI,  ACOPED.CODACO from MRT.RLCFLUDSTREPACO ACOPED ")
            oStrBld.Append(" inner join MRT.T0100361 FNCSLC on ACOPED.CODFNCRPNCRI = FNCSLC.CODFNC ")
            oStrBld.Append(" left join MRT.RLCFLUDSTREPACO ACORSP on ACOPED.CODFLUDSTREP = ACORSP.CODFLUDSTREP ")
            oStrBld.Append(" and ACOPED.NUMSEQ = case when length(translate(trim(ACORSP.CODAUXACO),' +-.0123456789',' ')) is null then to_number(ACORSP.CODAUXACO) else -1 end ")
            oStrBld.Append(" and ACOPED.CODACO = 9 and ACORSP.CODACO = 10 ")
            oStrBld.Append(" where ACOPED.CODFLUDSTREP = " & iCodFlu.ToString)
            oStrBld.Append(" and ACOPED.CODAUXACO = '" & iCodFncRpnCri.ToString & "' ")
            oStrBld.Append(" and ACORSP.NUMSEQ is null ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnLstPedOpn)
            CsnLstPedOpn.Tables(0).TableName = "TblLstPedOpn"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    Public Function CsnTetVndRep(ByVal iCodRep As Integer, _
                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select count(TET.CODTETVND) ")
            oStrBld.Append(" from MRT.T0133715 TET ")
            oStrBld.Append(" where TET.CODREP =  " & iCodRep.ToString)
            oStrBld.Append(" and TET.DATDSTTETVND is null ")
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(CsnTetVndRep)
            CsnTetVndRep.Tables(0).TableName = "TblTetVndRep"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta o maior mês válido com índice de correção monetária.
    ''' </summary>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function MaiorMesValidoComIndiceDeCorrecaoCadastradoObter(ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select max(MESREF) as MESREF ")
            oStrBld.Append(" from MRT.T0100094 ")
            oStrBld.Append(" where TIPMOE = 1 ")
            oStrBld.Append(" and (MESREF = to_number(to_char(sysdate,'YYYYMM')) ")
            oStrBld.Append(" or MESREF = to_number(to_char(sysdate,'YYYYMM')) - 1) ")

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(MaiorMesValidoComIndiceDeCorrecaoCadastradoObter)
            MaiorMesValidoComIndiceDeCorrecaoCadastradoObter.Tables(0).TableName = "TblMarMesCorMntRep"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta os Valores Indenizatorios do representante especificado.
    ''' </summary>
    ''' <param name="CodigoRepresentante">Código do Representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[raphael.sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ValoresIndenizatoriosObter(ByVal CodigoRepresentante As Integer, _
                                               ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            With oStrBld
                .Append(" with TABMESREF as ( " & vbCrLf)
                .Append(" select max(MESREF) as MESREF from MRT.T0100094 " & vbCrLf)
                .Append(" where TIPMOE = 1 " & vbCrLf)
                .Append(" and (MESREF = to_number(to_char(sysdate,'YYYYMM')) or MESREF = to_number(to_char(sysdate,'YYYYMM')) - 1) " & vbCrLf)
                .Append(" ), " & vbCrLf)
                .Append(" ULTCMS as ( " & vbCrLf)
                .Append(" select trunc(nvl(max(DATREFMES),sysdate)) as DATREFMES " & vbCrLf)
                .Append(" from MRT.T0123531 " & vbCrLf)
                .Append(" where VLRMNSPVTREP > 0 and CODREP = ").Append(CodigoRepresentante).Append(vbCrLf)
                .Append(" ), " & vbCrLf)
                .Append(" TABAUX as ( " & vbCrLf)
                .Append(" select " & vbCrLf)
                .Append(" sum(case when CMS.VLRCMSTOTREPSIT/MOEANI.VLRMOE*MOENVO.VLRMOE < " & vbCrLf)
                .Append(" CMS.VLRCMSTOTREPSIT " & vbCrLf)
                .Append(" then CMS.VLRCMSTOTREPSIT " & vbCrLf)
                .Append(" else CMS.VLRCMSTOTREPSIT/MOEANI.VLRMOE*MOENVO.VLRMOE end /12) as " & vbCrLf)
                .Append(" UMDOZEAVOS, " & vbCrLf)
                .Append(" 0 as UMTERCO " & vbCrLf)
                .Append(" from TABMESREF, MRT.T0100094 MOENVO, MRT.T0131542 CMS " & vbCrLf)
                .Append(" inner join MRT.T0100094 MOEANI on CMS.ANOMESREF = MOEANI.MESREF " & vbCrLf)
                .Append(" where " & vbCrLf)
                .Append(" MOEANI.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.MESREF = TABMESREF.MESREF and " & vbCrLf)
                .Append(" CMS.ANOMESREF between 199201 and 199812 and " & vbCrLf)
                .Append(" CMS.CODREP = ").Append(CodigoRepresentante).Append(vbCrLf)
                .Append(" union all " & vbCrLf)
                .Append(" select " & vbCrLf)
                .Append(" sum(case when CMS.VLRMNSPVTREP/MOEANI.VLRMOE*MOENVO.VLRMOE < " & vbCrLf)
                .Append(" CMS.VLRMNSPVTREP " & vbCrLf)
                .Append(" then CMS.VLRMNSPVTREP " & vbCrLf)
                .Append(" else CMS.VLRMNSPVTREP/MOEANI.VLRMOE*MOENVO.VLRMOE end /12) as " & vbCrLf)
                .Append(" UMDOZEAVOS, " & vbCrLf)
                .Append(" 0 as UMTERCO " & vbCrLf)
                .Append(" from TABMESREF, MRT.T0100094 MOENVO, MRT.T0123531 CMS " & vbCrLf)
                .Append(" inner join MRT.T0100094 MOEANI on " & vbCrLf)
                .Append(" to_number(to_char(CMS.DATREFMES,'YYYYMM')) = MOEANI.MESREF " & vbCrLf)
                .Append(" where " & vbCrLf)
                .Append(" MOEANI.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.MESREF = TABMESREF.MESREF and " & vbCrLf)
                .Append(" trunc(CMS.DATREFMES) >= date '1999-01-01' and " & vbCrLf)
                .Append(" CMS.CODREP = ").Append(CodigoRepresentante).Append(vbCrLf)
                .Append(" union all " & vbCrLf)
                .Append(" select " & vbCrLf)
                .Append(" 0 as UMDOZEAVOS, " & vbCrLf)
                .Append(" case when months_between(nvl(REP.DATDSTREP,sysdate),REP.DATCADREP) < 6 " & vbCrLf)
                .Append(" then 0 " & vbCrLf)
                .Append(" else " & vbCrLf)
                .Append(" sum(case when CMS.VLRMNSPVTREP/MOEANI.VLRMOE*MOENVO.VLRMOE < " & vbCrLf)
                .Append(" CMS.VLRMNSPVTREP " & vbCrLf)
                .Append(" then CMS.VLRMNSPVTREP " & vbCrLf)
                .Append(" else CMS.VLRMNSPVTREP/MOEANI.VLRMOE*MOENVO.VLRMOE end /3) " & vbCrLf)
                .Append(" end as UMTERCO " & vbCrLf)
                .Append(" from TABMESREF, ULTCMS, MRT.T0100094 MOENVO, MRT.T0123531 CMS " & vbCrLf)
                .Append(" inner join MRT.T0100094 MOEANI on " & vbCrLf)
                .Append(" to_number(to_char(CMS.DATREFMES,'YYYYMM')) = MOEANI.MESREF " & vbCrLf)
                .Append(" inner join MRT.T0100116 REP on CMS.CODREP = REP.CODREP " & vbCrLf)
                .Append(" where " & vbCrLf)
                .Append(" MOEANI.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.TIPMOE = 1 and " & vbCrLf)
                .Append(" MOENVO.MESREF = TABMESREF.MESREF and " & vbCrLf)
                .Append(" trunc(CMS.DATREFMES) between add_months(ULTCMS.DATREFMES,-2) and " & vbCrLf)
                .Append(" ULTCMS.DATREFMES and " & vbCrLf)
                .Append(" CMS.CODREP = ").Append(CodigoRepresentante).Append(vbCrLf)
                .Append(" group by REP.DATCADREP, REP.DATDSTREP " & vbCrLf)
                .Append(" ) " & vbCrLf)
                .Append(" select round(sum(nvl(UMDOZEAVOS,0)),2) as UMDOZEAVOS, round(sum(nvl(UMTERCO,0)),2) as UMTERCO from " & vbCrLf)
                .Append(" TABAUX " & vbCrLf)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ValoresIndenizatoriosObter)
            ValoresIndenizatoriosObter.Tables(0).TableName = "TblVlrInd"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta o saldo residual do representante especificado.
    ''' </summary>
    ''' <param name="CodigoRepresentante">Código do Representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function SaldoResidualRepresentanteObter(ByVal CodigoRepresentante As Integer, _
                                                    ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            With oStrBld
                .Append(" select round(VLRSLDANTCNTCRRREP + VLRDBTCNTCRRREP + VLRCRDCNTCRRREP, 2) as VLRSLDRSD" & vbCrLf)
                .Append(" from MRT.T0123531 " & vbCrLf)
                .Append(" where CODREP = ").Append(CodigoRepresentante).Append(vbCrLf)
                .Append(" and DATREFMES = (select max(DATREFMES) from MRT.T0123531 ").Append(vbCrLf)
                .Append("                  where CODREP = ").Append(CodigoRepresentante).Append(")").Append(vbCrLf)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(SaldoResidualRepresentanteObter)
            SaldoResidualRepresentanteObter.Tables(0).TableName = "TblSldRsd"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta o parametros.
    ''' </summary>
    ''' <param name="CodigoParametro">Código do Parâmetro</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterParametro(ByVal CodigoParametro As Integer, _
                                   ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select PMT.CODPMT, PMT.DESPMT, PMT.CDOPMT ")
            oStrBld.Append(" from MRT.CADPMTFLUDSTREP PMT ")
            oStrBld.Append(" where PMT.CODPMT = ").Append(CodigoParametro)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObterParametro)
            ObterParametro.Tables(0).TableName = "TblPrm"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta os representantes por fluxos.
    ''' </summary>
    ''' <param name="CodigofluxoDesativacaoRepresentante">Código do fluxo da desativação do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterRepresentantePorFluxo(ByVal CodigoFluxoDesativacaoRep As Integer, _
                                               ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oGrpDdo As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            With oStrBld
                .Append(" select REP.CODREP, REP.NOMREP, REP.QDEDIASEMPED, REP.DATDSTREP, DIR.CODFNCGERDIV, ")
                .Append(" SUP.CODFNCSUP, SUP.CODSUP, SUP.NOMSUP, REP.CODSITREP, SIT.DESSITREP, ")
                .Append(" GER.CODFNCGER, GER.CODGER, GER.NOMGER, FLU.CODTIPDSTREP, FLU.CODREPSBTVND, REP2.DATDSTREP as DATDSTREPSBTVND, ")
                .Append(" REP.TIPSITPESJURCSHREG, FLU.CODMTVDSTEDEVND, FLU.DESMTVDSTREP, FLU.DATDOCSLCDST ")
                .Append(" from MRT.CADFLUDSTREP FLU ")
                .Append(" inner join MRT.T0100116 REP ")
                .Append(" on REP.CODREP = FLU.CODREP ")
                .Append(" inner join MRT.T0123698 SIT ")
                .Append(" on SIT.CODSITREP = REP.CODSITREP ")
                .Append(" inner join MRT.T0100116 REP2 ")
                .Append(" on REP2.CODREP = FLU.CODREPSBTVND ")
                .Append(" inner join MRT.T0100124 SUP ")
                .Append(" on REP.CODSUP = SUP.CODSUP ")
                .Append(" inner join MRT.T0100051 GER ")
                .Append(" on GER.CODGER = SUP.CODGER ")
                .Append(" inner join MRT.T0123248 DIR ")
                .Append(" on GER.CODGERDIV = DIR.CODGERDIV ")
                .Append(" where FLU.CODFLUDSTREP = ").Append(CodigoFluxoDesativacaoRep)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObterRepresentantePorFluxo)
            ObterRepresentantePorFluxo.Tables(0).TableName = "TblRepFlu"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta próximo número sequencial de ação para o fluxo
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Próximo número sequencial de ação para o fluxo</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterCodObservacaoPorFluxo(ByVal iCodFlu As Integer, _
                                               ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As Integer

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select nvl(max(a.codobs), 0) + 1 as codobs ")
            oStrBld.Append(" from mrt.cadobsfludstrep obs where codfludstrep = " & iCodFlu)
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(oGrpDdo)
            oGrpDdo.Tables(0).TableName = "TblObsFlu"
            Return oGrpDdo.Tables(0).Rows(0)("PRXCODOBS")
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta o fluxo.
    ''' </summary>
    ''' <param name="CodigofluxoDesativacaoRepresentante">Código do fluxo da desativação do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterFluxoTotal(ByVal CodigofluxoDesativacaoRepresentante As Integer, _
                                    ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            oStrBld.Append(" select CODFLUDSTREP, ")
            oStrBld.Append(" CODREP, ")
            oStrBld.Append(" DATCRI, ")
            oStrBld.Append(" CODFNCRPNCRI, ")
            oStrBld.Append(" CODMTVDSTEDEVND, ")
            oStrBld.Append(" DESMTVDSTREP, ")
            oStrBld.Append(" ENDREP, ")
            oStrBld.Append(" NUMTLFREP, ")
            oStrBld.Append(" NUMTLFCELREP, ")
            oStrBld.Append(" NUMFAXREP, ")
            oStrBld.Append(" CODCIDREP, ")
            oStrBld.Append(" CODCEPREP, ")
            oStrBld.Append(" CODREPSBTVND, ")
            oStrBld.Append(" DATDOCSLCDST, ")
            oStrBld.Append(" CODTIPDSTREP, ")
            oStrBld.Append(" VLRARDDSTREP ")
            oStrBld.Append(" from MRT.CADFLUDSTREP ")
            oStrBld.Append(" where CODFLUDSTREP = ").Append(CodigofluxoDesativacaoRepresentante)

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObterFluxoTotal)
            ObterFluxoTotal.Tables(0).TableName = "TblFluTot"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta os funcionários por módulo.
    ''' </summary>
    ''' <param name="CodigoModulo">Código do Modulo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function FuncionariosPorModuloObter(ByVal CodigoModulo As Integer, _
                                               ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try

            With oStrBld
                .Append(" select MDU.CODMDU, MDU.DESMDU, MDUFNC.CODFNC, FNC.NOMFNC ")
                .Append(" from MRT.RLCMDUSISDSTREPFNC MDUFNC ")
                .Append(" inner join MRT.CADMDUSISDSTREP MDU ")
                .Append(" on MDUFNC.CODMDU = MDU.CODMDU ")
                .Append(" inner join MRT.T0100361 FNC ")
                .Append(" on MDUFNC.CODFNC = FNC.CODFNC ")
                .Append(" where FNC.DATDEMFNC is null ")
                .Append(" and MDU.CODMDU = ").Append(CodigoModulo)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(FuncionariosPorModuloObter)
            FuncionariosPorModuloObter.Tables(0).TableName = "TblFncMdl"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtêm a lista de equipamentos em recuperação por status
    ''' </summary>
    ''' <param name="CodigofluxoDesativacaoRepresentante">Código do fluxo da desativação do representante</param>
    ''' <param name="ListaStatus">Lista os status</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterListaEquipamentoStatusRecuperacao(ByVal CodigoFluxo As Integer, _
                                                           ByVal ListaStatus As String, _
                                                           ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try
            With oStrBld
                .Append(" select distinct FLU.CODFLUDSTREP, LOTE.NUMSEREQPIFR " & vbCrLf)
                .Append(" from MRT.CADFLUDSTREP FLU  " & vbCrLf)
                .Append(" inner join MRT.T0138520 LOTE " & vbCrLf)
                .Append(" on FLU.CODREP = LOTE.CODUSREQPIFR " & vbCrLf)
                .Append(" where LOTE.TIPUSREQPIFR = 'RE' " & vbCrLf)
                .Append(" and LOTE.CODSTAORDSVCIFR not in (").Append(ListaStatus).Append(")")
                .Append(" and FLU.CODFLUDSTREP = ").Append(CodigoFluxo)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObterListaEquipamentoStatusRecuperacao)
            ObterListaEquipamentoStatusRecuperacao.Tables(0).TableName = "TblEquiRel"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta a lista de equipamento de status dos representantes por fluxos.
    ''' </summary>
    ''' <param name="CodigofluxoDesativacaoRepresentante">Código do fluxo da desativação do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function RelacaoEquipamentosRelacionadosObter(ByVal CodigoFluxoDesativacaoRep As Integer, _
                                                         ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try

            With oStrBld
                oStrBld.Append(" select RLC.CODFLUDSTREP, RLC.NUMSEREQPIFR, RLC.VLRDCLEQPIFR, RLC.DATALT, RLC.CODFNCALT " & vbCrLf)
                oStrBld.Append(" from MRT.RLCFLUDSTREPEQPIFR RLC " & vbCrLf)
                oStrBld.Append(" where RLC.CODFLUDSTREP =  ").Append(CodigoFluxoDesativacaoRep)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(RelacaoEquipamentosRelacionadosObter)
            RelacaoEquipamentosRelacionadosObter.Tables(0).TableName = "TblEquiRel"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Exclue relacionamento do fluxo com equipamento de informática
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="NumSerEqpIfr">Número de série do equipamento de informática</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub ExcluirRelacionamentoFluxComEquipamento(ByVal CodigoFluxo As Integer, _
                                                       ByVal NumSerEqpIfr As String, _
                                                       ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                oStrBld.Append(" delete from MRT.RLCFLUDSTREPEQPIFR " & vbCrLf)
                oStrBld.Append(" where CODFLUDSTREP = ").Append(CodigoFluxo)
                oStrBld.Append(" and NUMSEREQPIFR =  '").Append(NumSerEqpIfr.Trim).Append("'")
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Exclue relacionamento do fluxo com equipamento de informática
    ''' </summary>
    ''' <param name="CodigoFluxo">Código do fluxo</param>
    ''' <param name="NumSerEqpIfr">Número de série do equipamento de informática</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub InserirRelacionamentoFluxComEquipamento(ByVal CodigoFluxo As Integer, _
                                                       ByVal NumeroSerie As String, _
                                                       ByVal CodigoResponsavel As Integer, _
                                                       ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                oStrBld.Append(" insert into MRT.RLCFLUDSTREPEQPIFR " & vbCrLf)
                oStrBld.Append(" (CODFLUDSTREP, NUMSEREQPIFR, VLRDCLEQPIFR, DATALT, CODFNCALT) " & vbCrLf)
                oStrBld.Append(" values (" & CodigoFluxo.ToString & ",")
                oStrBld.Append(" '" & NumeroSerie.Trim & "',")
                oStrBld.Append(" null,")
                oStrBld.Append(" trunc(sysdate),")
                oStrBld.Append(CodigoResponsavel.ToString & ")")
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza o status do equipamento do fluxo.
    ''' </summary>
    ''' <param name="CodigoStatus">Código de status</param>
    ''' <param name="CodigoFluxo">Código do Fluxo</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	20/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub FluxoEquipamentosStatusAtualizar(ByVal CodigoStatus As Integer, _
                                                ByVal CodigoFluxo As Integer, _
                                                ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" update MRT.T0138520 set CODENRUSRIFR = 'DST', DATHRAALTSTAEQPIFR = sysdate,  " & vbCrLf)
                .Append(" CODSTAORDSVCIFR = ").Append(CodigoStatus).Append(" where NUMSEREQPIFR in ")
                .Append(" (select RLC.NUMSEREQPIFR from MRT.RLCFLUDSTREPEQPIFR RLC " & vbCrLf)
                .Append(" inner join MRT.CADFLUDSTREP FLU on RLC.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
                .Append(" inner join MRT.T0138520 LOTE on RLC.NUMSEREQPIFR = LOTE.NUMSEREQPIFR and FLU.CODREP = LOTE.CODUSREQPIFR and LOTE.TIPUSREQPIFR = 'RE' " & vbCrLf)
                .Append(" where FLU.CODFLUDSTREP = ").Append(CodigoFluxo).Append(") ")
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere os histórico de equipamentos.
    ''' </summary>
    ''' <param name="CodigoTerritorioVenda">Código do território de venda</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	20/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub FluxoEquipamentosHistoricoInserir(ByVal CodigoFluxo As Integer, _
                                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" insert into MRT.T0138911(NUMSEREQPIFR,DATHRAALTSTAEQPIFR,CODSTAORDSVCIFR, " & vbCrLf)
                .Append(" CODUSREQPIFR,CODENRUSRIFR,TIPUSREQPIFR,TIPEDEUSR,NUMCONLMTCTB,DATHRAALT, " & vbCrLf)
                .Append(" DESOBSSTAEQPIFR) " & vbCrLf)
                .Append(" select LOTE.NUMSEREQPIFR, LOTE.DATHRAALTSTAEQPIFR, LOTE.CODSTAORDSVCIFR, " & vbCrLf)
                .Append(" LOTE.CODUSREQPIFR, LOTE.CODENRUSRIFR, LOTE.TIPUSREQPIFR, LOTE.TIPEDEUSR, " & vbCrLf)
                .Append(" LOTE.NUMCONLMTCTB, LOTE.DATHRAALT, " & vbCrLf)
                .Append(" 'STATUS DO EQUIPAMENTO ALTERADO PELO SISTEMA DE RESCISAO DE CONTRATOS COM' " & vbCrLf)
                .Append(" || ' REPRESENTANTES (ADMVENDAS), FLUXO NUMERO ' || ").Append(CodigoFluxo).Append(" || '.' ")
                .Append(" from MRT.T0138520 LOTE where LOTE.NUMSEREQPIFR in " & vbCrLf)
                .Append(" (select RLC.NUMSEREQPIFR from MRT.RLCFLUDSTREPEQPIFR RLC " & vbCrLf)
                .Append(" inner join MRT.CADFLUDSTREP FLU on RLC.CODFLUDSTREP = FLU.CODFLUDSTREP " & vbCrLf)
                .Append(" inner join MRT.T0138520 LOTE on RLC.NUMSEREQPIFR = LOTE.NUMSEREQPIFR and FLU.CODREP = LOTE.CODUSREQPIFR and LOTE.TIPUSREQPIFR = 'RE' " & vbCrLf)
                .Append(" where FLU.CODFLUDSTREP = ").Append(CodigoFluxo).Append(") ")
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza situação do representante
    ''' </summary>
    ''' <param name="CodigoSituacaoRepresentante">Código da situação do representante</param>
    ''' <param name="CodigoRepresentante">Código do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	27/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AtualizarSituacaoRepresentante(ByVal CodigoSituacaoRepresentante As Integer, _
                                              ByVal CodigoRepresentante As Integer, _
                                              ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" update MRT.T0100116 REP  " & vbCrLf)
                .Append(" set REP.CODSITREP =  ").Append(CodigoSituacaoRepresentante)
                .Append(" where rep.codrep = ").Append(CodigoRepresentante)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere histórico antigo
    ''' </summary>
    ''' <param name="CodigoRepresentante">Código do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	27/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub InserirHistoricoAntigo(ByVal CodigoRepresentante As Integer, _
                                      ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" insert into MRT.T0123949 " & vbCrLf)
                .Append("   select codrep, sysdate, codsitrep, codsup, tipsitpesjurcshreg, tipnatrep, codbcorep, codagebcorep, " & vbCrLf)
                .Append("   numdigvrfagebcorep, codcntcrrbcorep, numcgcemprep, nomemprep, endemprep, codbaiemprep,  " & vbCrLf)
                .Append("   codcplbaiemprep, codcepemprep, numrgtrepcshreg, codestunicshreg, tipsitrepcshreg, datasncttrep,  " & vbCrLf)
                .Append("   null, sysdate, datrgtrepcshreg, numinsinunacsegsoc " & vbCrLf)
                .Append("   from mrt.t0100116 where codrep = ").Append(CodigoRepresentante)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

    Public Sub InserirHistorico(ByVal strNomeTabela As String, _
                                ByVal strNomeCampo As String, _
                                ByVal TipoCampo As Constantes.TipoDado, _
                                ByVal strNomeCampoChave As String, _
                                ByVal intCodigoChave As Integer, _
                                ByVal CodigoResponsavel As Integer, _
                                ByVal ConteudoAntigo As String, _
                                ByVal ConteudoNovo As String, _
                                ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" insert into MRT.HSTALTTABADMVND " & vbCrLf)
                .Append("   (NOMTAB, CODCHVTAB, DATALT, NOMCPO, CODRPNALT, CDOANTCPO, CDONVOCPO)  " & vbCrLf)
                .Append(" values  " & vbCrLf)
                .Append("  ('" & strNomeTabela.Trim.ToUpper & "', " & intCodigoChave.ToString & vbCrLf)
                .Append("  , sysdate, '" & strNomeCampo.Trim.ToUpper & "', " & CodigoResponsavel & vbCrLf)
                If intCodigoChave > -1 Then
                    .Append(" , (select ")
                    If TipoCampo = Constantes.TipoDado.Data Or TipoCampo = Constantes.TipoDado.DataHora Or TipoCampo = Constantes.TipoDado.Numerico Then .Append(" to_char( ")
                    If TipoCampo = Constantes.TipoDado.Alfanumerico Then .Append(" trim( ")
                    .Append(" " & strNomeCampo & " ")
                    If TipoCampo = Constantes.TipoDado.Data Then .Append(",'YYYY-MM-DD')")
                    If TipoCampo = Constantes.TipoDado.DataHora Then .Append(",'YYYY-MM-DD HH24:MI:SS')")
                    If TipoCampo = Constantes.TipoDado.Numerico Or TipoCampo = Constantes.TipoDado.Alfanumerico Then .Append(")")
                    .Append(" from MRT." & strNomeTabela & " where " & strNomeCampoChave & " = " & intCodigoChave.ToString & ") ")
                Else
                    .Append(", '" & ConteudoAntigo & "'")
                End If
                .Append(", '" & ConteudoNovo & "') ")
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta os territorios sem solicitação dos representantes por fluxos.
    ''' </summary>
    ''' <param name="CodigofluxoDesativacaoRepresentante">Código do fluxo da desativação do representante</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <returns>Conjunto de dados (dataset)</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	17/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ObterTerritoriosSemSoliticacaoTransferencia(ByVal CodigoFluxoDesativacaoRep As Integer, _
                                                                ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try

            With oStrBld
                .Append(" select TET.CODTETVND, TET.DESTETVND, REP.CODREP, REP.CODSUP, " & vbCrLf)
                .Append(" FLU.CODREPSBTVND, FLU.CODFLUDSTREP, SUP.CODFNCSUP, TET.CODREGVND " & vbCrLf)
                .Append(" from MRT.T0133715 TET " & vbCrLf)
                .Append(" inner join MRT.CADFLUDSTREP FLU on TET.CODREP = FLU.CODREP " & vbCrLf)
                .Append(" inner join MRT.T0100116 REP on TET.CODREP = REP.CODREP " & vbCrLf)
                .Append(" inner join MRT.T0100124 SUP on REP.CODSUP = SUP.CODSUP " & vbCrLf)
                .Append(" where FLU.CODFLUDSTREP = ").Append(CodigoFluxoDesativacaoRep)
                .Append(" and TET.DATDSTTETVND is null " & vbCrLf)
                .Append(" and TET.CODTETVND not in " & vbCrLf)
                .Append(" (select REQ.CODTETVND from MRT.T0135610 REQ " & vbCrLf)
                .Append(" where REQ.TIPALTREQ = 2 " & vbCrLf)
                .Append(" and REQ.CODREP = FLU.CODREP " & vbCrLf)
                .Append(" and REQ.DATHRAFIMPPS is null " & vbCrLf)
                .Append(" and REQ.TIPSTAPPS <> 2)  " & vbCrLf)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObterTerritoriosSemSoliticacaoTransferencia)
            ObterTerritoriosSemSoliticacaoTransferencia.Tables(0).TableName = "TblSlcTrans"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtem apropriação em vigor para o território.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael Sales]	14/01/2010	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Friend Shared Function ObtemApropriacaoVigorTerritório(ByVal CodigoTerritorio As Integer, _
                                                           ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As DataSet
        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oGrpDdo As DataSet
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Try

            oStrBld.Append(" select * from MRT.T0104839 ")
            oStrBld.Append(" where CODGIR = ").Append(CodigoTerritorio)
            oStrBld.Append(" and trunc(sysdate) between DATINIVGRRLC and DATFIMVGRRLC ")

            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(ObtemApropriacaoVigorTerritório)
            ObtemApropriacaoVigorTerritório.Tables(0).TableName = "tblApropriacao"
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    Friend Shared Function InserirApropriacaoTerritorio(ByVal CodigoRepresentante As Integer, _
                                                        ByVal CodigoRepresentanteSubstituto As Integer, _
                                                        ByVal DuracaoDiasApropriacao As Integer, _
                                                        ByVal CodigoTerritorio As Integer, _
                                                        ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim sql As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With sql

                .Append(" insert into MRT.T0104839 " & vbCrLf)
                .Append(" (CODREPTTRVND, CODREPSBTVND, DATHRAGRCRLC, DATINIVGRRLC," & vbCrLf)
                .Append(" DATFIMVGRRLC, DATDSTRLC, CODFNCRPNARZRLC, CODFNCRPNDSTRLC," & vbCrLf)
                .Append(" NOMREPTTRVND, CODGIR, DATGRCPCOSBT) " & vbCrLf)
                .Append(" values " & vbCrLf)
                .Append(" ( ").Append(CodigoRepresentante).Append(" , ")
                .Append(CodigoRepresentanteSubstituto).Append(" , ")
                .Append(" systimestamp ,  " & vbCrLf)
                .Append(" trunc(sysdate), " & vbCrLf)
                .Append(" trunc(sysdate) + ").Append(DuracaoDiasApropriacao).Append(" -1 , ")
                .Append(" date '0001-01-01', " & vbCrLf)
                .Append(" 99998, " & vbCrLf)
                .Append(" 0, " & vbCrLf)
                .Append(" 'rep', " & vbCrLf)
                .Append(CodigoTerritorio).Append(", ")
                .Append(" null )" & vbCrLf)

                oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, sql.ToString)
                oAcsDdo.ExcCmdSql(iRst)
            End With
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Atualiza os territórios.
    ''' </summary>
    ''' <param name="CodigoTerritorioVenda">Código do território de venda</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	20/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AtualizarTerritorio(ByVal CodigoTerritorioVenda As Integer, _
                                   ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" update MRT.T0133715 TET set TET.DATDISTETVND = trunc(sysdate) " & vbCrLf) 'Território vago.
                .Append(" where TET.CODTETVND = ").Append(CodigoTerritorioVenda).Append(" and TET.DATDISTETVND is null  " & vbCrLf)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Insere os territórios.
    ''' </summary>
    ''' <param name="CodigoTerritorioVenda">Código do território de venda</param>
    ''' <param name="oCnx">Conexão com banco de dados</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Raphael.Sales]	20/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub InserirTerritorio(ByVal CodigoGerenteMercado As Integer, _
                                 ByVal CodigoRepresentante As Integer, _
                                 ByVal CodigoTerritorioVenda As Integer, _
                                 ByVal CodigoFluxo As Integer, _
                                 ByVal MatriculaGerenteMercado As Integer, _
                                 ByVal RegionalTerritorio As Integer, _
                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo)

        Dim oAcsDdo As IAU013.UO_IAUAcsDdo
        Dim oStrBld As Text.StringBuilder = New Text.StringBuilder
        Dim iRst As Integer
        Try
            With oStrBld
                .Append(" insert into MRT.T0135610 " & vbCrLf)
                .Append(" (CODREQ, CODGERMCD, TIPALTREQ, TIPSTAPPS, CODTETVND, CODTETVNDPPS, CODREP, " & vbCrLf)
                .Append(" CODREPPPS, CODMTVALT, DATHRACADREQ, DATHRAINIFLUAPV, DATHRAFIMFLUAPV, " & vbCrLf)
                .Append(" DATHRAFIMPPS, DESJSTPPS, DESJSTULTAPV, CODFNCULTAPV, DESALARGRREQTETVND, " & vbCrLf)
                .Append(" INDVLDCADNACCRB, INDVLDINSESTCLI, INDVLDPTERSCCLI, CODREGVNDPPS, DATINIVGRRLC, " & vbCrLf)
                .Append(" DATFIMVGRRLC, QDEDIAAPP) " & vbCrLf)
                .Append(" values " & vbCrLf)
                .Append(" ( (select max(CODREQ) + 1 from MRT.T0135610), ").Append(CodigoGerenteMercado).Append(" , 2, 1, ").Append(CodigoTerritorioVenda).Append(" , ")
                .Append(" 0, ").Append(CodigoRepresentante).Append(" ,  ").Append(CodigoGerenteMercado).Append(" , ")
                .Append(" 9, sysdate, sysdate, sysdate, null, " & vbCrLf)
                .Append(" 'TRANSFERENCIA DE TERRITORIO SOLICITADA AUTOMATICAMENTE PELO SISTEMA DE ' " & vbCrLf)
                .Append(" || 'RESCISAO DE CONTRATOS COM REPRESENTANTES (ADMVENDAS), EM FUNCAO DA ' " & vbCrLf)
                .Append(" || 'DESATIVACAO DO REPRESENTANTE.', " & vbCrLf)
                .Append(" 'TRANSFERENCIA DE TERRITORIO APROVADA DE ACORDO COM O FLUXO ' || ").Append(CodigoFluxo)
                .Append(" || ' DO SISTEMA DE RESCISAO DE CONTRATOS COM REPRESENTANTES (ADMVENDAS).', " & vbCrLf)
                .Append(MatriculaGerenteMercado).Append(", ' ', 0, 0, 0, ").Append(RegionalTerritorio).Append(" , trunc(sysdate), ")
                .Append(" trunc(sysdate), 0) " & vbCrLf)
            End With
            oAcsDdo = New IAU013.UO_IAUAcsDdo(oCnx, oStrBld.ToString)
            oAcsDdo.ExcCmdSql(iRst)
        Finally
            If Not oAcsDdo Is Nothing Then
                oAcsDdo = Nothing
            End If
        End Try
    End Sub

End Class