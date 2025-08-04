''' -----------------------------------------------------------------------------
''' Project	 : VAK020
''' Class	 : Constantes
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Centraliza as constantes globais utilizados pela aplicação
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[claudio.rafael]	23/7/2009	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Constantes

    Public Const APLICACAO_DELEGACAO As String = "DST"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tipos de desativação
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum TipoDesativacao As Integer
        Notificacao_para_cumprimento_do_contrato = 0
        Notificacao_para_rescisao_por_justo_motivo = 1
        Acordo_com_o_representante = 2
        Indenizacao_Normal = 3
    End Enum

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Módulos do sistema
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	24/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum ModulosAutorizacao
        Desconhecido = 0
        Autonomos = 1
        Juridico = 2
        CMI = 3
        Consulta = 4
        Vendas = 5
        Contabilidade = 6
    End Enum

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Ações da desativação do fluxo
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	23/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum Acao As Integer
        ACAO_DESCONHECIDA = 0
        FLUXO_INICIADO = 1
        NOTIF_CUMPRIMENTO_CONTRATO_SOLICITADA = 2
        NOTIF_OUTROS_MOTIVOS_SOLICITADA = 3
        COMUNICACAO_ENVIADA = 4
        OBSERVACOES_INCLUIDAS = 5
        FLUXO_CANCELADO = 6
        RCA_NOTIFICADO_CUMP_CONTRATO = 7
        FLUXO_CONCLUIDO = 8
        PARECER_SOLICITADO = 9
        PARECER_FORNECIDO = 10
        REVISAO_SOLICITADA = 11
        FLUXO_APROVADO_GV = 12
        FLUXO_RETORNADO_GV = 13
        TEXTO_NOTIFICACAO_OUTROS_MOTIVOS_CRIADO = 14
        ACERTO_REALIZADO_TRIB_ARBITRAGEM = 15
        RESULTADO_ACAO_REINTEGRACAO_POSSE_INFORMADO = 16
        FLUXO_APROVACAO_INDENIZACAO_INICIADO = 17
        ACAO_REINTEGRACAO_POSSE_SOLICITADA = 18
        SOLICITACAO_ACAO_REINTEGRACAO_POSSE_CANCELADA = 19
        INDENIZACAO_LANCADA_EXTRATO_DO_REPRESENTANTE = 20
        SALDO_RESIDUAL_COMISSAO_LANCADO_EXTRATO = 21
        BAIXA_DE_EQUIPAMENTOS_PERDA_SOLICITADA = 22
        EQUIPAMENTOS_BAIXADOS_COMO_PERDA = 23
        EQUIPAMENTOS_RECUPERADOS = 24
        NOTIF_RESC_CONTRATO_LOC_EQUIP_EMITIDA = 25
        NOTIF_RESC_CONTRATO_LOC_EQUIP_RETORNADA = 26
        EQUIPAMENTOS_QUITADOS = 27
        BAIXA_EQUIPAMENTOS_COMO_PERDA_ANALISADA = 28
        NOTIFICACAO_EMITIDA = 29
        REPRESENTANTE_DESATIVADO = 30
        NOTIFICACAO_ASSINADA = 31
        FLUXO_APROVACAO_SALDO_RESIDUAL_COMISSAO_INICIADO = 32
        CARTA_RESCISAO_RECEBIDA = 33
        MOTIVO_DESATIVACAO_ALTERADO = 34
        PAGAMENTO_INDENIZACAO_SOLICITADO = 35
        PAGAMENTO_SALDO_RESIDUAL_COMISSAO_SOLICITADO = 36
        LISTA_VALORES_PAGAMENTO_GERADA = 37
        VALOR_RESCISORIO_CALCULADO = 38
    End Enum

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tipo de dado
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	27/7/2009	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Enum TipoDado
        Numerico
        Alfanumerico
        Data
        DataHora
    End Enum


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

End Class