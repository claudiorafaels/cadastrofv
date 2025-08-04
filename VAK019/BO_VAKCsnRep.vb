Imports VAK019.DB_VAKCsnRep
Imports Microsoft.ApplicationBlocks.ExceptionManagement

Public Class BO_VAKCsnRep

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


    Public Function CsnInfCadRep(ByVal sCodSup As String, _
                                 ByVal iCodTetVnd As Integer) As DataSet

        Dim oObeCsnItfInfCadRep As New DB_VAKCsnRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oCnsDdo As New DB_VAKCsnRep
        Dim sAnoMesRef As String
        Dim sAnoMesRefAnt As String
        Dim sAnoMesRefAntAnt As String
        Dim oGrpDdo As New DataSet
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            'Consulta últimos três meses
            oGrpDdo.Tables.Add(oObeCsnItfInfCadRep.CsnUltMes(oCnx).Tables(0).Copy)
            sAnoMesRefAntAnt = CType(oGrpDdo.Tables(0).Rows(0)(0), String) + _
                         CType(oGrpDdo.Tables(0).Rows(0)(1), String).PadLeft(2, "0")
            sAnoMesRefAnt = CType(oGrpDdo.Tables(0).Rows(0)(2), String) + _
                         CType(oGrpDdo.Tables(0).Rows(0)(3), String).PadLeft(2, "0")
            sAnoMesRef = CType(oGrpDdo.Tables(0).Rows(0)(4), String) + _
                         CType(oGrpDdo.Tables(0).Rows(0)(5), String).PadLeft(2, "0")
            'Consulta valores de venda por território
            oGrpDdo.Tables.Add(oObeCsnItfInfCadRep.CsnVlrVndTet(sCodSup, sAnoMesRef, sAnoMesRefAnt, sAnoMesRefAntAnt, iCodTetVnd, oCnx).Tables(0).Copy)
            oCnx.FimTscSuc()
            Return oGrpDdo
        Catch oEcc As Exception
            Dim oExp As New Exception("Erro ao consultar valores de venda")
            oCnx.FimTscErr()
            ExceptionManager.Publish(oEcc)
            Throw oExp
        Finally
            If Not oCnx Is Nothing Then oCnx.Dispose()
        End Try
    End Function


    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Verifica se o nome do usuario de rede esta cadastrado no sistema.
    REM ''' </summary>
    REM ''' <param name="pNomUsrRcf">Nome de rede do usuario a ser verificado.</param>
    REM ''' <returns>String vazia, caso o usuario seja invalido ou o endereco de e-mail caso contrario.</returns>
    REM ''' <remarks>
    REM ''' Metodo utilizado para formacao do endereco de envio de Pedido de Parecer.
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/30/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnCreUsrRcf(ByVal pNomUsrRcf As String) As String
        'objeto
        Dim oObeCsnItfUsrRcf As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        sCplCmdSql = ""

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")

            sVlrRet = oObeCsnItfUsrRcf.CnsUsrRcf(pNomUsrRcf, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            Dim sXML As System.IO.StringReader = New System.IO.StringReader(sVlrRet)
            Dim ds As DataSet
            ds = New DataSet
            ds.ReadXml(sXML)
            If ds.Tables(0).Rows.Count > 0 Then
                sVlrRet = ds.Tables(0).Rows(0).Item("Status")
            Else
                sVlrRet = "0"
            End If

            sXML = Nothing
            ds = Nothing
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar usuarios cadastrados. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oObeCsnItfUsrRcf = Nothing
        End Try
    End Function


#Region " Metodos de Manipulacao de dados relacionados a MRT.T0155931"

    ' Consulta todos os aprovadores delegados a uma dada requisicao
    Public Function CsnApvReq(ByVal pNumReqCadRep As String) As String
        'objeto
        Dim oObeCsnItfApvReq As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfApvReq.CsnApvReq(pNumReqCadRep, sVlrErr, oCnx)

            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar as requisicoes delegadas. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oObeCsnItfApvReq = Nothing
            oCnx.Dispose()
        End Try
    End Function

#End Region

    Public Function CsnCid(ByVal sCodEst As String) As String
        'objeto
        Dim oObeCsnItfCid As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")

            'montando o complemento sql
            If sCodEst <> "" Then
                sCplCmdSql = sCodEst
            End If

            sVlrRet = oObeCsnItfCid.CsnCid(sCplCmdSql, sVlrErr, " ORDER BY NOMCID ", oCnx)

            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar cidades. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oObeCsnItfCid = Nothing
            oCnx.Dispose()
        End Try
    End Function

#Region " --> Consulta bairro de uma cidade"
    Public Function CsnBai(ByVal sCodCid As String) As String
        'objeto
        Dim oObeCsnItfBai As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try

            'montando o complemento sql
            If sCodCid <> "" Then
                sCplCmdSql = sCodCid
            End If
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfBai.CsnBai(sCplCmdSql, sVlrErr, " ORDER BY NOMBAI ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar bairros. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfBai = Nothing
        End Try
    End Function
#End Region


#Region "--> "
    Public Function CsnNumInsInuNacSegSoc(ByVal sNumInsInuNacSegSoc As String, _
                                          ByVal sNumCpfRep As String) As String
        'objeto
        Dim oObeCsnItfNumInsInuNacSegSoc As New DB_VAKRep
        'valor de retorno
        Dim sVlrErr As String = ""
        Dim sRet As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sRet = oObeCsnItfNumInsInuNacSegSoc.CsnNumInsInuNacSegSoc(sNumInsInuNacSegSoc, sNumCpfRep, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar Representantes Cadastrados com INSS = " & _
                      sNumInsInuNacSegSoc & _
                      ". Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfNumInsInuNacSegSoc = Nothing
        End Try
    End Function
#End Region

    Public Function CsnCplBai(ByVal sCodBai As String) As String
        'objeto
        Dim oObeCsnItfCplBai As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim ocnx As IAU013.UO_IAUCnxAcsDdo
        Try
            ocnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            'montando o complemento sql
            If sCodBai <> "" Then
                sCplCmdSql = sCodBai
            End If
            sVlrRet = oObeCsnItfCplBai.CsnCplBai(sCplCmdSql, sVlrErr, " ORDER BY NOMCPLBAI ", ocnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar complementos de bairros. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            ocnx.Dispose()
            oObeCsnItfCplBai = Nothing
        End Try
    End Function


    Public Function CsnAgeBco(ByVal sCodBco As String) As String
        'objeto
        Dim oObeCsnItfAgeBco As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            'montando o complemento sql
            If sCodBco <> "" Then
                sCplCmdSql = sCodBco
            End If
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfAgeBco.CsnAgeBco(sCplCmdSql, sVlrErr, " ORDER BY CODAGEBCO ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar agências de banco. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfAgeBco = Nothing
        End Try
    End Function

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' 
    REM ''' </summary>
    REM ''' <param name="sNumCpf"></param>
    REM ''' <param name="sXmlIdtRepTrb"></param>
    REM ''' <param name="sXmlRstPva"></param>
    REM ''' <param name="sXmlAcePnd"></param>
    REM ''' <param name="sXmlAcoTrb"></param>
    REM ''' <param name="sXmlIdtRepTrbTmp"></param>
    REM ''' <returns></returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	1/26/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnInfRepCpf(ByVal sNumCpf As String, _
                                      ByRef sXmlIdtRepTrb As String, _
                                      ByRef sXmlRstPva As String, _
                                      ByRef sXmlAcePnd As String, _
                                      ByRef sXmlAcoTrb As String, _
                                      ByRef sXmlIdtRepTrbTmp As String) As Boolean
        'objeto
        Dim oObeCsnItfInfRepCpf As New DB_VAKRep
        'valor de retorno
        Dim sVlrErr As String
        'varivel auxiliar
        Dim sCodRep As String
        Dim dsAux As New DataSet
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'verifica se representante trabalhou no Martins
            sXmlIdtRepTrb = oObeCsnItfInfRepCpf.CsnIdtRepTrb(sNumCpf, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'verifica se representante existe tabela temporaria
            sXmlIdtRepTrbTmp = oObeCsnItfInfRepCpf.CsnIdtRepTrbTmp(sNumCpf, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'carrega resultado das provas
            sXmlRstPva = oObeCsnItfInfRepCpf.CsnRstPva(sNumCpf, sVlrErr, "", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'converte informações do representante
            dsAux.ReadXml(New System.IO.StringReader(sXmlIdtRepTrb))
            'verifica se ele ja foi representante Martins
            If dsAux.Tables(0).Rows.Count > 0 Then
                'Pega o código do representante
                sCodRep = dsAux.Tables(0).Rows(0)(2)
                'carrega acertos pendentes
                sXmlAcePnd = oObeCsnItfInfRepCpf.CsnAcePnd(sCodRep, sVlrErr, oCnx)
                If sVlrErr <> "" Then
                    Throw New Exception(sVlrErr)
                End If
                'carrega ações trabahistas
                sXmlAcoTrb = oObeCsnItfInfRepCpf.CsnAcoTrb(sCodRep, sVlrErr, oCnx)
                If sVlrErr <> "" Then
                    Throw New Exception(sVlrErr)
                End If
            End If
            oCnx.FimTscSuc()

            'retorno com sucesso
            Return True
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar as informações do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
            Return False
        Finally
            oCnx.Dispose()
            oObeCsnItfInfRepCpf = Nothing
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
    Public Function CsnIdtRepFnc(ByVal sNumCpf As String) As DataSet
        Dim DB_CsnCid As New DB_VAKRep
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnIdtRepFnc = DB_CsnCid.CsnIdtRepFnc(sNumCpf, oCnx)
        Catch oObeEcc As Exception
            ExceptionManager.Publish(oObeEcc)
            Throw
        Finally
            oCnx.Dispose()
        End Try
    End Function

    Public Function CsnInfRepCpfRpa(ByVal sNumCpf As String, _
                                     ByRef sMsgBlqOrdPgt As String, _
                                     ByRef sMsgRboPgtPvtEde As String, _
                                     ByRef sMsgInzPgo As String) As Boolean

        Dim oObeCsnItfInfRepCpf As New DB_VAKRep
        Dim sVlrErr As String
        Dim sVlrRet As String

        Dim sCodRep As String
        Dim ds As DataSet
        Dim aux As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            ' Obtem o codigo do representante (CodRep) do periodo em que foi representante Martins
            sVlrRet = oObeCsnItfInfRepCpf.CsnIdtRepTrb(sNumCpf, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            If ds.Tables(0).Rows.Count > 0 Then
                sCodRep = ds.Tables(0).Rows(0)("CODREP")
            End If
            ds = Nothing

            ' Verifica se o candidato tem contrato bloqueado
            sVlrRet = oObeCsnItfInfRepCpf.CsnBlqOrdPgt(sCodRep, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            If ds.Tables(0).Rows.Count > 0 Then
                aux = ds.Tables(0).Rows(0)("Qtd")
                If Integer.Parse(aux.Trim) > 0 Then
                    sMsgBlqOrdPgt = "Este candidato esta bloqueado porque deve contrato do periodo em que foi representante Martins."
                Else
                    sMsgBlqOrdPgt = ""
                End If
            End If
            ds = Nothing

            ' verifica se o candidato deve RPA
            sVlrRet = oObeCsnItfInfRepCpf.CsnRboPgtPvtEde(sNumCpf, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            If ds.Tables(0).Rows.Count > 0 Then
                aux = ds.Tables(0).Rows(0)("Qtd")
                If Integer.Parse(aux.Trim) > 0 Then
                    sMsgRboPgtPvtEde = "Este candidato esta bloqueado porque deve RPA do periodo em que foi representante Martins."
                Else
                    sMsgRboPgtPvtEde = ""
                End If
            End If
            ds = Nothing

            ' verifica se o candidato tem acertos pendentes
            sVlrRet = oObeCsnItfInfRepCpf.CsnInzPgo(sCodRep, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ds = New DataSet
            ds.ReadXml(New System.IO.StringReader(sVlrRet))
            If ds.Tables(0).Rows.Count > 0 Then
                aux = ds.Tables(0).Rows(0)("Qtd")
                If Integer.Parse(aux.Trim) = 0 Then
                    sMsgInzPgo = "Este candidato esta bloqueado porque tem acertos pendentes do periodo em que foi representante Martins."
                Else
                    sMsgInzPgo = ""
                End If
            End If
            ds = Nothing
            oCnx.FimTscSuc()

            'retorno com sucesso
            Return True
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar as informações do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
            Return False
        Finally
            oCnx.Dispose()
            oObeCsnItfInfRepCpf = Nothing
        End Try
    End Function

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' Obtem informacoes para cadastro de candidatos a representante.
    REM ''' </summary>
    REM ''' <param name="sCodSup">Codigo do Gerente de Vendas.</param>
    REM ''' <param name="sXmlEst">XML Contendo lista dos Estados.</param>
    REM ''' <param name="sXmlBco"></param>
    REM ''' <param name="sXmlSgmMcd"></param>
    REM ''' <param name="sXmlGerVnd"></param>
    REM ''' <param name="sXmlCtn"></param>
    REM ''' <param name="sXmlTet"></param>
    REM ''' <param name="sXmlUltMes"></param>
    REM ''' <param name="sXmlVlrVndTet"></param>
    REM ''' <param name="sXmlAvl"></param>
    REM ''' <returns>
    REM ''' </returns>
    REM ''' <remarks>
    REM ''' Parametro sXmlEst = nothing implica uso de dados estaticos (nao acessa o Banco de Dados).
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/2/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnInfCadRep(ByVal sCodSup As String, _
                                  ByRef sXmlEst As String, _
                                  ByRef sXmlBco As String, _
                                  ByRef sXmlSgmMcd As String, _
                                  ByRef sXmlGerVnd As String, _
                                  ByRef sXmlCtn As String, _
                                  ByRef sXmlTet As String, _
                                  ByRef sXmlUltMes As String, _
                                  ByRef sXmlVlrVndTet As String, _
                                  ByRef sXmlAvl As String) As Boolean
        'objeto
        Dim oObeCsnItfInfCadRep As New DB_VAKRep
        'valor de retorno
        Dim sVlrErr As String
        'variáveis auxiliares
        Dim sAnoMesRef, sAnoMesRefAnt, sAnoMesRefAntAnt As String
        Dim dsAux As New DataSet
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'carrega estados
            If (Not sXmlEst Is Nothing) Then
                sXmlEst = oObeCsnItfInfCadRep.CsnEst(sVlrErr, oCnx)
                If sVlrErr <> "" Then
                    Throw New Exception(sVlrErr)
                End If
            Else
            End If

            'carrega segmentos de mercado
            sXmlSgmMcd = oObeCsnItfInfCadRep.CsnSgmMcd(sVlrErr, " ORDER BY DESSGMMCD ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'carrega bancos
            sXmlBco = oObeCsnItfInfCadRep.CsnBco(sVlrErr, " ORDER BY CODBCO ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'carrega GM e GV
            sXmlGerVnd = oObeCsnItfInfCadRep.CsnGerVnd(sCodSup, sVlrErr, " ORDER BY NOMGER ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'carrega competências
            sXmlCtn = oObeCsnItfInfCadRep.CsnCtn(sVlrErr, " ORDER BY DESTITCTNREP ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ''carrega avaliações 
            sXmlAvl = oObeCsnItfInfCadRep.CsnDdoAvl(sVlrErr, " ORDER BY CODAVLREP ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'carrega territórios
            sXmlTet = oObeCsnItfInfCadRep.CsnTetGerMcd(sCodSup, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            ''busca ultimos 3 mêses
            'sXmlUltMes = oObeCsnItfInfCadRep.CsnUltMes(sVlrErr)
            'If sVlrErr <> "" Then
            '    Throw New Exception(sVlrErr)
            'End If
            ''busca valor venda ultimos 3 mêses
            'dsAux.ReadXml(New System.IO.StringReader(sXmlUltMes))
            'sAnoMesRef = CType(dsAux.Tables(0).Rows(0)(4), String).Trim.PadLeft(4, "0") & CType(dsAux.Tables(0).Rows(0)(5), String).PadLeft(2, "0")
            'sAnoMesRefAnt = CType(dsAux.Tables(0).Rows(0)(2), String).Trim.PadLeft(4, "0") & CType(dsAux.Tables(0).Rows(0)(3), String).PadLeft(2, "0")
            'sAnoMesRefAntAnt = CType(dsAux.Tables(0).Rows(0)(0), String).Trim.PadLeft(4, "0") & CType(dsAux.Tables(0).Rows(0)(1), String).PadLeft(2, "0")
            'sXmlVlrVndTet = oObeCsnItfInfCadRep.CsnVlrVndTet(sCodSup, sVlrErr)
            'If sVlrErr <> "" Then
            '    Throw New Exception(sVlrErr)
            'End If
            'retorno com sucesso
            oCnx.FimTscSuc()
            Return True
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar as informações cadastrais do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
            Return False
        Finally
            oCnx.Dispose()
            oObeCsnItfInfCadRep = Nothing
        End Try
    End Function

    Public Function CsnTotSta() As String
        'objeto
        Dim oObeCsnItfSta As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfSta.CsnTotSta(sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar Status. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfSta = Nothing
        End Try
    End Function
    'Consulta todos os Gerentes de Vendas
    Public Function CsnTotGerVnd() As String
        'objeto
        Dim oObeCsnItfGerVnd As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfGerVnd.CsnTotGerVnd(sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar os Gerentes de Vendas. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfGerVnd = Nothing
        End Try
    End Function

    Public Function CsnGerMcdGerVnd(ByVal sCodGer As String) As String
        'objeto
        Dim oObeCsnItfGer As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfGer.CsnGerMcdGerVnd(sCodGer, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar Gerente de Mercado. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfGer = Nothing
        End Try
    End Function

    '- Consulta Dados do Representante
    Public Function CsnDdoRep(ByVal sNumReq As String, ByVal sNomRep As String, ByVal sNumCpf As String, _
      ByVal sCodSta As String, ByVal sCodTet As String, ByVal sCodGerVnd As String, ByVal sCodGerMcd As String, _
      ByVal sDatIniSlc As String, ByVal sDatFimSlc As String, Optional ByVal sDatDstRep As String = "") As String
        'objeto
        Dim oCsnDdoRepItf As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        'valor de erro
        Dim sVlrErr As String
        'complemento sql - from
        Dim sCplSql As String
        sCplSql = ""
        'complemento sql - where
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            'montando o complemento sql 

            'Numero requisição
            If sNumReq <> "" Then
                sCplCmdSql += "   AND TMPREP.NUMREQCADREP = " & sNumReq
            End If
            'Nome representante
            If sNomRep <> "" Then
                sCplCmdSql += "   AND TMPREP.NOMREP  LIKE '%" & Trim(sNomRep) & "%'"
            End If

            If sNumCpf <> "" Then
                sCplCmdSql += "   AND TMPREP.NUMCPFREP = '" & sNumCpf & "'"
            End If

            If sCodSta <> "" Then
                sCplCmdSql += "   AND TMPREP.CODSTACADREP = " & sCodSta
            End If

            If sCodTet <> "" Then
                sCplSql += ", MRT.T0150377 TETREP"
                sCplCmdSql += "   AND TMPREP.NUMREQCADREP = TETREP.NUMREQCADREP "
                sCplCmdSql += "   AND TETREP.CODTETVND = " & sCodTet
            End If

            If sCodGerVnd <> "" Then
                sCplCmdSql += "   AND CODGERVND = " & sCodGerVnd
            End If
            If sCodGerMcd <> "" Then
                sCplCmdSql += "   AND CODGERMCD = " & sCodGerMcd
            End If

            'If (sDatIniSlc <> "") Then
            '    sCplCmdSql += "  AND DATSLC >= '" + sDatIniSlc + "'"
            'End If

            'If (sDatFimSlc <> "") Then
            '    sCplCmdSql += "  AND DATSLC <= '" + sDatFimSlc + "' "
            'End If

            'Conversão Oracle 16/02/06
            If (sDatIniSlc <> "") Then
                sCplCmdSql += "  AND DATSLC >= TO_DATE('" + sDatIniSlc + "','YYYY-MM-DD')"
            End If

            If (sDatFimSlc <> "") Then
                sCplCmdSql += "  AND DATSLC <= TO_DATE('" + sDatFimSlc + "','YYYY-MM-DD') "
            End If

            'Data de destativação do representante (caso o mesmo já tenha sido representante antes).
            'Se receber 01/01/1900 (1900-01-01), verifica se a data de desativação é nula.
            If sDatDstRep <> "" Then
                sCplSql += ", MRT.T0100116 REP "
                sCplCmdSql += " AND TMPREP.NUMCPFREP = REP.NUMCPFREP "
                If sDatDstRep = "1900-01-01" Then
                    sCplCmdSql += " AND REP.DATDSTREP IS NULL "
                Else
                    sCplCmdSql += " AND REP.DATDSTREP <= TO_DATE('" + sDatDstRep + "', 'YYYY-MM-DD') "
                End If
            End If

            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            'sCplCmdSql += " WHERE UPPER(DESCOP) LIKE UPPER('%" + Trim(sDesCop) + "%')"
            sVlrRet = oCsnDdoRepItf.CsnDdoRep(sCplSql, sCplCmdSql, sVlrErr, oCnx)
            'retorno com sucesso
            Return sVlrRet
            'ocorreu algum erro
        Catch oObeEcc As Exception
            'publica erro no log
            'ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar os dados do Representante. Entre em contato com o Administrador do Sistema!" & " " & oObeEcc.Message
            Return ""
        Finally
            'liberando objetos
            oCnx.Dispose()
            If Not oCsnDdoRepItf Is Nothing Then oCsnDdoRepItf = Nothing
        End Try
    End Function

    Public Function CsnSlcFluApv(ByVal sNumCpf As String) As String
        Dim oObeCsnSlcApv As New DB_VAKRep
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnSlcApv.CsnSlcFluApv(sNumCpf, oCnx)
            Return sVlrRet

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            sVlrErr = "Houve um problema ao consultar os dados da solicitação. Entre em contato com o Administrador do Sistema!" & " " & ex.Message
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnSlcApv = Nothing
        End Try
    End Function

    Public Function CsnTetGerMcd(ByVal sCodGerMcd As String) As String
        'objeto
        Dim oObeCsnItfTet As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfTet.CsnTetGerMcd(sCodGerMcd, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar Territórios. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfTet = Nothing
        End Try
    End Function

#Region " ------------------ Consulta Informações do Representante para Alteração ----------------"
    Function CsnInfAltRep(ByVal sCodEstUni As String, ByVal sCodCid As String, ByVal sCodBai As String, _
                          ByVal sCodBco As String, ByRef sTxtMcoDdoEstUni As String, ByRef sTxtMcoDdoCidEst As String, _
                          ByRef sTxtMcoDdoBaiCid As String, ByRef sTxtMcoDdoCplBai As String, ByRef sTxtMcoDdoBco As String, _
                          ByRef sTxtMcoDdoAgeBco As String, ByRef sTxtMcoDdoSgmMcd As String) As Boolean


        'objeto
        Dim oObeCsnItfInfCadRep As New DB_VAKRep
        'valor de retorno
        Dim sVlrErr As String
        'variáveis auxiliares
        Dim sAnoMesRef, sAnoMesRefAnt, sAnoMesRefAntAnt As String
        Dim dsAux As New DataSet
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()
            'Consulta todos os estados
            sTxtMcoDdoEstUni = oObeCsnItfInfCadRep.CsnEst(sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todas as cidades do estado
            sTxtMcoDdoCidEst = oObeCsnItfInfCadRep.CsnCid(sCodEstUni, sVlrErr, " ORDER BY NOMCID ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todos os bairros de uma cidade
            sTxtMcoDdoBaiCid = oObeCsnItfInfCadRep.CsnBai(sCodCid, sVlrErr, " ORDER BY NOMBAI ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todos os complemento bairros de um bairro
            sTxtMcoDdoCplBai = oObeCsnItfInfCadRep.CsnCplBai(sCodBai, sVlrErr, " ORDER BY NOMCPLBAI ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todos os bancos
            sTxtMcoDdoBco = oObeCsnItfInfCadRep.CsnBco(sVlrErr, " ORDER BY CODBCO ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todas as agencias do banco
            sTxtMcoDdoAgeBco = oObeCsnItfInfCadRep.CsnAgeBco(sCodBco, sVlrErr, " ORDER BY CODAGEBCO ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'Consulta todos os segmentos de mercados
            sTxtMcoDdoSgmMcd = oObeCsnItfInfCadRep.CsnSgmMcd(sVlrErr, " ORDER BY DESSGMMCD ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            oCnx.FimTscSuc()

            'retorno com sucesso
            Return True
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar as informações do representante para alteração. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
            Return False
        Finally
            oCnx.Dispose()
            oObeCsnItfInfCadRep = Nothing
        End Try
    End Function
#End Region

#Region " ------------------ Consulta Avaliações ----------------"
    Public Function CsnDdoAvl() As String
        'objeto
        Dim oObeCsnItfCtn As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfCtn.CsnDdoAvl(sVlrErr, " ORDER BY CODAVLREP ", oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar avaliações. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfCtn = Nothing
        End Try
    End Function
#End Region

#Region " ------------------ Consulta todas as informações do representante ----------------"

    REM ''' -----------------------------------------------------------------------------
    REM ''' <summary>
    REM ''' 
    REM ''' </summary>
    REM ''' <param name="sNumReqCttRep">Numero da requisicao a ser pesquisada.</param>
    REM ''' <param name="sTxtMcoDdoCtn">Dados de Competencias do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoSta">Dados de Status do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoRstAvl">Dados de Provas do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoTet">Dados de Territorio do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoRcm">Dados de Protestos / Reclamacoes do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoAcoCvl">Dados de Acao Civil do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoDdoTit">Dados de Titulos do candidato a RCA.</param>
    REM ''' <param name="sTxtMcoAvlRep">Dados de Avaliacoes do candidato a RCA.</param>
    REM ''' <param name="sDesObsFlu">Dados do Fluxo do candidato a RCA.</param>
    REM ''' <returns>Todas as informacoes do representante.</returns>
    REM ''' <remarks>
    REM ''' </remarks>
    REM ''' <history>
    REM ''' 	[gperei]	2/1/2005	Created
    REM ''' </history>
    REM ''' -----------------------------------------------------------------------------
    Public Function CsnTotDdoRep(ByVal sNumReqCttRep As String, _
                                 ByRef sTxtMcoDdoCtn As String, _
                                 ByRef sTxtMcoDdoSta As String, _
                                 ByRef sTxtMcoDdoRstAvl As String, _
                                 ByRef sTxtMcoDdoTet As String, _
                                 ByRef sTxtMcoDdoRcm As String, _
                                 ByRef sTxtMcoDdoAcoCvl As String, _
                                 ByRef sTxtMcoDdoTit As String, _
                                 ByRef sTxtMcoAvlRep As String, _
                                 ByRef sDesObsFlu As String) As String
        'objeto
        Dim oObeCsnItfRep As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String

        'XML Representante
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oGrpDdoRep As New DataSet
        Dim sNumCpfRep As String
        'XML das descrições 
        Dim oObeLetTxtMcoObs, oObeLetTxtMcoAcePnd, oObeLetTxtMcoFlu, oObeLetTxtMcoTet As System.IO.StringReader
        Dim oObeGrvTxtMcoTet As System.IO.StringWriter

        Dim oGrpDdoObs As New DataSet
        Dim oGrpDdoAcePnd As New DataSet
        Dim oGrpDdoFlu As New DataSet
        Dim oGrpDdoTet As New DataSet
        Dim oGrpDdoRstTet As New DataSet
        Dim sTxtMcoDesObs, sTxtMcoDesAcePnd, sTxtMcoDesFlu As String

        Dim sCodTetVnd, sDesTetVnd, sCodRep, sNomRep, sAnoMesRef1, sAnoMesRef2, sAnoMesRef3, sVlrCmp1, sVlrCmp2, sVlrCmp3
        'Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Dim oCnxCsn As IAU013.UO_IAUCnxAcsDdo

        Try
            'oCnx.IniTsc()

            ' Consulta todas as informações do representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfRep.CsnTotDdoRep(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()

            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Recupera NumCpf
            oObeLetTxtMco = New System.IO.StringReader(sVlrRet)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If

            sNumCpfRep = oGrpDdoRep.Tables(0).Rows(0).Item("numcpfrep").trim

            ' Consulta competências do representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoCtn = oObeCsnItfRep.CsnDdoCtn(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoCtn = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Status do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoSta = oObeCsnItfRep.CsnDdoSta(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoSta = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Territórios do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoTet = oObeCsnItfRep.CsnDdoTet(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            oObeLetTxtMcoTet = New System.IO.StringReader(sTxtMcoDdoTet)
            oGrpDdoTet.ReadXml(oObeLetTxtMcoTet)

            If oGrpDdoTet.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Território dos Representantes está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            Dim iCnt As Integer
            oGrpDdoRstTet.Tables.Add()
            oGrpDdoRstTet.Tables(0).Columns.Add("codtetvnd")
            oGrpDdoRstTet.Tables(0).Columns.Add("destetvnd")
            oGrpDdoRstTet.Tables(0).Columns.Add("codrep")
            oGrpDdoRstTet.Tables(0).Columns.Add("nomrep")
            oGrpDdoRstTet.Tables(0).Columns.Add("anomesref1")
            oGrpDdoRstTet.Tables(0).Columns.Add("vlrcmp1")
            oGrpDdoRstTet.Tables(0).Columns.Add("anomesref2")
            oGrpDdoRstTet.Tables(0).Columns.Add("vlrcmp2")
            oGrpDdoRstTet.Tables(0).Columns.Add("anomesref3")
            oGrpDdoRstTet.Tables(0).Columns.Add("vlrcmp3")

            oGrpDdoRstTet.Tables(0).Columns.Add("strvlrcmp1") REM valores formatados como string
            oGrpDdoRstTet.Tables(0).Columns.Add("strvlrcmp2")
            oGrpDdoRstTet.Tables(0).Columns.Add("strvlrcmp3")
            Dim sStrVlrCmp1, sStrVlrCmp2, sStrVlrCmp3 As String

            iCnt = 0
            While iCnt < oGrpDdoTet.Tables(0).Rows.Count - 1
                sCodTetVnd = oGrpDdoTet.Tables(0).Rows(iCnt).Item(0)
                sDesTetVnd = oGrpDdoTet.Tables(0).Rows(iCnt).Item(1)
                sCodRep = oGrpDdoTet.Tables(0).Rows(iCnt).Item(2)
                sNomRep = oGrpDdoTet.Tables(0).Rows(iCnt).Item(3)
                sAnoMesRef1 = oGrpDdoTet.Tables(0).Rows(iCnt).Item(4)
                sAnoMesRef2 = oGrpDdoTet.Tables(0).Rows(iCnt + 1).Item(4)
                sAnoMesRef3 = oGrpDdoTet.Tables(0).Rows(iCnt + 2).Item(4)
                sVlrCmp1 = oGrpDdoTet.Tables(0).Rows(iCnt).Item(5)
                sVlrCmp2 = oGrpDdoTet.Tables(0).Rows(iCnt + 1).Item(5)
                sVlrCmp3 = oGrpDdoTet.Tables(0).Rows(iCnt + 2).Item(5)

                sStrVlrCmp1 = oGrpDdoTet.Tables(0).Rows(iCnt).Item(6)     REM valores formatados como strings
                sStrVlrCmp2 = oGrpDdoTet.Tables(0).Rows(iCnt + 1).Item(6)
                sStrVlrCmp3 = oGrpDdoTet.Tables(0).Rows(iCnt + 2).Item(6)

                oGrpDdoRstTet.Tables(0).Rows.Add(New Object() {sCodTetVnd, sDesTetVnd, sCodRep, sNomRep, sAnoMesRef1, _
                                                               sVlrCmp1, sAnoMesRef2, sVlrCmp2, sAnoMesRef3, _
                                                               sVlrCmp3, sStrVlrCmp1, sStrVlrCmp2, sStrVlrCmp3})
                iCnt += 3
            End While
            oObeGrvTxtMcoTet = New System.IO.StringWriter
            oGrpDdoRstTet.WriteXml(oObeGrvTxtMcoTet)
            sTxtMcoDdoTet = oObeGrvTxtMcoTet.ToString()
            If sTxtMcoDdoTet = "" Then
                Throw New Exception(sVlrErr)
            End If

            '' Consulta Avaliação do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoRstAvl = oObeCsnItfRep.CsnRstPva(sNumCpfRep, sVlrErr, "", oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoRstAvl = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Protestos/Reclamações do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoRcm = oObeCsnItfRep.CsnDdoRcm(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoRcm = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Ação Civil do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoAcoCvl = oObeCsnItfRep.CsnDdoAcoCvl(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoAcoCvl = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Títulos do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDdoTit = oObeCsnItfRep.CsnDdoTit(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoDdoTit = "" Then
                Throw New Exception(sVlrErr)
            End If

            ' Consulta Avaliações do Representante
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoAvlRep = oObeCsnItfRep.CsnDdoAvlRep(sNumReqCttRep, sVlrErr, oCnxCsn)
            oCnxCsn.Dispose()
            If sTxtMcoAvlRep = "" Then
                Throw New Exception(sVlrErr)
            End If

            '' Consulta Descrição da Observação e Fluxo
            'sTxtMcoDesObs = oObeCsnItfRep.CsnDdoDesObs(sNumReqCttRep, "1", sVlrErr)
            'oObeLetTxtMcoObs = New System.IO.StringReader(sTxtMcoDesObs)
            'oGrpDdoObs.ReadXml(oObeLetTxtMcoObs)
            'sDesObsFlu = ""
            'If oGrpDdoObs.Tables(0).Rows.Count > 0 Then
            '    sDesObsFlu = oGrpDdoObs.Tables(0).Rows(0).Item("desobs")
            'End If

            ' Quanto segundo parametro = nothing, retorna todo o fluxo
            oCnxCsn = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sTxtMcoDesObs = oObeCsnItfRep.CsnDdoDesObs(sNumReqCttRep, Nothing, sVlrErr, oCnxCsn)

            oCnxCsn.Dispose()
            oObeLetTxtMcoObs = New System.IO.StringReader(sTxtMcoDesObs)
            oGrpDdoObs.ReadXml(oObeLetTxtMcoObs)
            sDesObsFlu = ""
            If oGrpDdoObs.Tables(0).Rows.Count > 0 Then
                Dim i As Int64 = 0
                For i = 0 To oGrpDdoObs.Tables(0).Rows.Count - 1
                    sDesObsFlu = sDesObsFlu & vbNewLine & _
                                 oGrpDdoObs.Tables(0).Rows(i).Item("desobs")
                Next
            End If

            sDesObsFlu = ppctxt(sDesObsFlu)

            '' Consulta Descrição da Acertos Pendentes
            'sTxtMcoDesAcePnd = oObeCsnItfRep.CsnDdoDesObs(sNumReqCttRep, "2", sVlrErr)
            'oObeLetTxtMcoAcePnd = New System.IO.StringReader(sTxtMcoDesAcePnd)
            'oGrpDdoAcePnd.ReadXml(oObeLetTxtMcoAcePnd)
            'sDesAcePnd = ""
            'If oGrpDdoAcePnd.Tables(0).Rows.Count > 0 Then
            '    sDesAcePnd = oGrpDdoAcePnd.Tables(0).Rows(0).Item("desobs")
            'End If

            '' Consulta Descrição do Fluxo
            'sTxtMcoDesFlu = oObeCsnItfRep.CsnDdoDesObs(sNumReqCttRep, "2", sVlrErr)
            'oObeLetTxtMcoFlu = New System.IO.StringReader(sTxtMcoDesFlu)
            'oGrpDdoFlu.ReadXml(oObeLetTxtMcoFlu)
            'sDesFlu = ""
            'If oGrpDdoFlu.Tables(0).Rows.Count > 0 Then
            '    sDesFlu = oGrpDdoFlu.Tables(0).Rows(0).Item("desobs")
            'End If

            'Retorno com sucesso. Retorna o XML com informações do representante
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar informações do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnxCsn.Dispose()
            oObeCsnItfRep = Nothing
        End Try
    End Function
#End Region

#Region " ------------------ Formata informações do representante ----------------"
    Public Function FrmDdoRep(ByVal sTxtMcoDdoRep As String, ByVal sTxtMcoDdoRcm As String, ByVal sTxtMcoDdoAcoCvl As String, ByVal sTxtMcoDdoTit As String) As String
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String

        'XML Representante, Protesto, Ação Civil e Títulos
        Dim oObeLetTxtMco As System.IO.StringReader
        Dim oObeLetTxtMcoAcoCvl As System.IO.StringReader
        Dim oObeLetTxtMcoRcm As System.IO.StringReader
        Dim oObeLetTxtMcoTit As System.IO.StringReader

        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoAcoCvl As New DataSet
        Dim oGrpDdoRcm As New DataSet
        Dim oGrpDdoTit As New DataSet

        'Dados do representante
        Dim sQdeOcoRcm, sVlrTotRcm, sQdeOcoAcoCvl, sQdeTitVncNaoPgo, sQdeOcoChqSemFnd, sDatUltOcoChqSemFnd, sNomBcoUltChqSemFnd, sDatHraRcbInfCrd, sIndRtcCrd, sIndAcePnd, sIndVldCpf, sCodUndNgc, sNomUltChqSemFnd As String

        'Dados dos Protestos
        Dim sCodSeqRcm, sDatOcoRcm, sVlrOcoRcm, sNomCidEtbOcoRcm, sEstUniOcoRcm, sNumEtbOcoRcm, sNomEtbOcoRcm As String

        'Dados das Ações Civis
        Dim sCodSeqAcoCvl, sTipAcoCvl, sDatOcoAcoCvl, sNomCidOcoAcoCvlRep, sCodEstUniOcoAcoCvl, sNumEtbAcoCvl, sNomCriAcoCvl, sNomPesRcbAcoCvl As String

        'Dados do Titulos 
        Dim sCodSeqTitVnc, sDatTitVncNaoPgo, sRazSocInfTitVnc, sVlrTitVncNaoPgo, sDesCttTitVncNaoPgo As String

        Dim nroOco, iCnr As Integer
        Try
            sVlrRet = ""
            'Dados do Representante
            oObeLetTxtMco = New System.IO.StringReader(sTxtMcoDdoRep)
            oGrpDdoRep.ReadXml(oObeLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML do Representante está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If

            If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("qdeocorcm")) Then
                sQdeOcoRcm = "0"
            Else
                sQdeOcoRcm = oGrpDdoRep.Tables(0).Rows(0).Item("qdeocorcm")
            End If

            If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("vlrtotrcm")) Then
                sVlrTotRcm = "0"
            Else
                sVlrTotRcm = oGrpDdoRep.Tables(0).Rows(0).Item("vlrtotrcm")
                If sVlrTotRcm.IndexOf(",") > 0 Then
                    sVlrTotRcm = sVlrTotRcm.Replace(".", "").Replace(",", ".")
                End If

            End If

            If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("qdeocoacocvl")) Then
                sQdeOcoAcoCvl = "0"
            Else
                sQdeOcoAcoCvl = oGrpDdoRep.Tables(0).Rows(0).Item("qdeocoacocvl")
            End If

            If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("qdetitvncnaopgo")) Then
                sQdeTitVncNaoPgo = "0"
            Else
                sQdeTitVncNaoPgo = oGrpDdoRep.Tables(0).Rows(0).Item("qdetitvncnaopgo")
            End If

            If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("qdeocochqsemfnd")) Then
                sQdeOcoChqSemFnd = "0"
            Else
                sQdeOcoChqSemFnd = oGrpDdoRep.Tables(0).Rows(0).Item("qdeocochqsemfnd")
                sDatUltOcoChqSemFnd = oGrpDdoRep.Tables(0).Rows(0).Item("datultocochqsemfnd")

                If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("nombcoultchqsemfnd")) Then
                    sNomBcoUltChqSemFnd = " "
                Else
                    sNomBcoUltChqSemFnd = oGrpDdoRep.Tables(0).Rows(0).Item("nombcoultchqsemfnd")
                End If

                If Convert.IsDBNull(oGrpDdoRep.Tables(0).Rows(0).Item("nomultchqsemfnd")) Then
                    sNomUltChqSemFnd = " "
                Else : sNomUltChqSemFnd = oGrpDdoRep.Tables(0).Rows(0).Item("nomultchqsemfnd")
                End If

                sDatHraRcbInfCrd = oGrpDdoRep.Tables(0).Rows(0).Item("dathrarcbinfcrd")
            End If

            'Dados dos Cheques sem Fundo
            If (sQdeOcoChqSemFnd > 0) Then
                sVlrRet &= "Dados dos Cheques sem Fundo " & Chr(13)
                sVlrRet &= "  Quantidade de Cheques sem Fundo: " & sQdeOcoChqSemFnd & Chr(13)
                If (sDatUltOcoChqSemFnd <> "") Then
                    sVlrRet &= "  Data do último Cheque sem Fundo: " & Format("dd/MM/yyyy", sDatUltOcoChqSemFnd) & Chr(13)
                End If
                If (sNomBcoUltChqSemFnd <> "") Then
                    sVlrRet &= "  Banco do último Cheque sem Fundo: " & sNomBcoUltChqSemFnd & Chr(13)
                End If
                If (sNomUltChqSemFnd <> "") Then
                    sVlrRet &= "  Nome do último Cheque sem Fundo: " & sNomUltChqSemFnd
                End If
                sVlrRet &= Chr(13) & Chr(13)
            End If

            'Dados dos Protestos
            If (sQdeOcoRcm > 0) Then
                oObeLetTxtMcoRcm = New System.IO.StringReader(sTxtMcoDdoRcm)
                oGrpDdoRcm.ReadXml(oObeLetTxtMcoRcm)

                If oGrpDdoRcm.Tables(0).Rows.Count > 0 Then
                    sVlrRet &= "Dados dos Protestos " & Chr(13)
                    sVlrRet &= "  Quantidade de Protestos: " & sQdeOcoRcm & Chr(13)
                    sVlrRet &= "  Valor Total: " & sVlrTotRcm
                    If (sQdeOcoRcm > 3) Then
                        nroOco = 2
                    Else
                        nroOco = sQdeOcoRcm - 1
                    End If
                    For iCnr = 0 To nroOco
                        sCodSeqRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("codseqrcm")
                        sDatOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("datocorcm")
                        sVlrOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("vlrocorcm")
                        If sVlrOcoRcm.IndexOf(",") > 0 Then
                            sVlrOcoRcm = sVlrOcoRcm.Replace(".", "").Replace(",", ".")
                        End If
                        sNomCidEtbOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("nomcidetbocorcm")
                        sEstUniOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("codestuniocorcm")
                        sNumEtbOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("numetbocorcm")
                        sNomEtbOcoRcm = oGrpDdoRcm.Tables(0).Rows(iCnr).Item("nometbocorcm")
                        sVlrRet &= Chr(13) & Chr(13) & "  Código Protesto: " & sCodSeqRcm & Chr(13) & _
                                                       "  Data Ocorrência: " & Format("dd/mm/yyyy", sDatOcoRcm) & Chr(13) & _
                                                       "  Valor Ocorrência: " & sVlrOcoRcm
                    Next
                    sVlrRet &= Chr(13) & Chr(13)
                End If
            End If

            'Dados das Ações Civis
            If (sQdeOcoAcoCvl > 0) Then
                oObeLetTxtMcoAcoCvl = New System.IO.StringReader(sTxtMcoDdoAcoCvl)
                oGrpDdoAcoCvl.ReadXml(oObeLetTxtMcoAcoCvl)

                If oGrpDdoAcoCvl.Tables(0).Rows.Count > 0 Then
                    sVlrRet &= "Dados das Ações Civis " & Chr(13)
                    sVlrRet &= "  Quantidade de Ações Civis: " & sQdeOcoAcoCvl

                    If (sQdeOcoAcoCvl > 3) Then
                        nroOco = 2
                    Else
                        nroOco = sQdeOcoAcoCvl - 1
                    End If
                    For iCnr = 0 To nroOco
                        sCodSeqAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("codseqacocvl")
                        sTipAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("tipacocvl")
                        sDatOcoAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("datocoacocvl")
                        sNomCidOcoAcoCvlRep = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("nomcidocoacocvlrep")
                        sCodEstUniOcoAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("codestuniocoacocvl")
                        sNumEtbAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("numetbacocvl")
                        sNomCriAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("nomcriacocvl")
                        sNomPesRcbAcoCvl = oGrpDdoAcoCvl.Tables(0).Rows(iCnr).Item("nompesrcbacocvl")
                        sVlrRet &= Chr(13) & Chr(13) & "  Código Ação Civil: " & sCodSeqAcoCvl & Chr(13) & _
                                                       "  Data Ocorrência: " & Format("dd/mm/yyyy", sDatOcoAcoCvl) & Chr(13) & _
                                                       "  Tipo Ação Civil: " & sTipAcoCvl
                    Next
                    sVlrRet &= Chr(13) & Chr(13)
                End If
            End If

            'Dados dos Títulos não pagos
            If (sQdeTitVncNaoPgo > 0) Then
                oObeLetTxtMcoTit = New System.IO.StringReader(sTxtMcoDdoTit)
                oGrpDdoTit.ReadXml(oObeLetTxtMcoTit)

                If oGrpDdoTit.Tables(0).Rows.Count > 0 Then
                    sVlrRet &= "Dados dos Títulos Vencidos não Pagos " & Chr(13)
                    sVlrRet &= "  Quantidade de Títulos Vencidos: " & sQdeTitVncNaoPgo

                    If (sQdeTitVncNaoPgo > 3) Then
                        nroOco = 2
                    Else
                        nroOco = sQdeTitVncNaoPgo - 1
                    End If
                    For iCnr = 0 To nroOco
                        sCodSeqTitVnc = oGrpDdoTit.Tables(0).Rows(iCnr).Item("codseqtitvnc")
                        sDatTitVncNaoPgo = oGrpDdoTit.Tables(0).Rows(iCnr).Item("dattitvncnaopgo")
                        sRazSocInfTitVnc = oGrpDdoTit.Tables(0).Rows(iCnr).Item("razsocinftitvnc")
                        sVlrTitVncNaoPgo = oGrpDdoTit.Tables(0).Rows(iCnr).Item("vlrtitvncnaopgo")
                        sDesCttTitVncNaoPgo = oGrpDdoTit.Tables(0).Rows(iCnr).Item("desctttitvncnaopgo")
                        sVlrRet &= Chr(13) & Chr(13) & "  Código Título: " & sCodSeqTitVnc & Chr(13) & _
                                                       "  Razao Social do Título: " & sRazSocInfTitVnc & Chr(13) & _
                                                       "  Data Título : " & Format("dd/mm/yyyy", sDatTitVncNaoPgo) & Chr(13) & _
                                                       "  Valor Título: " & sVlrTitVncNaoPgo
                    Next
                    sVlrRet &= Chr(13)
                End If
            End If

            'Retorno com sucesso. Retorna string informações do representante
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao formatar informações do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        End Try
    End Function
#End Region

    Public Function CsnDdoRepExt(ByVal sCodRep As String) As String
        'objeto
        Dim oObeCsnItfDdoRepExt As New DB_VAKRep
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnItfDdoRepExt.CsnDdoRepExt(sCodRep, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar dados do representante existente. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnItfDdoRepExt = Nothing
        End Try
    End Function

    Public Function CsnAgeBcoUnc(ByVal iCodBco As Integer, _
                                 ByVal iCodAgeBco As Integer) As DataSet
        'objeto
        Dim oCsnAgeBcoUnc As New DB_VAKRep
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnAgeBcoUnc = oCsnAgeBcoUnc.CsnAgeBcoUnc(iCodBco, iCodAgeBco, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
        Catch oEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar agência de banco. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oCsnAgeBcoUnc = Nothing
        End Try
    End Function

    Public Function CsnBcoUnc(ByVal iCodBco As Integer) As DataSet
        'objeto
        Dim oCsnBcoUnc As New DB_VAKRep
        Dim sVlrErr As String
        'complemento sql
        Dim sCplCmdSql As String
        sCplCmdSql = ""
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnBcoUnc = oCsnBcoUnc.CsnBcoUnc(iCodBco, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
        Catch oEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar banco. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oCsnBcoUnc = Nothing
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta estado / cidade por CEP
    ''' </summary>
    ''' <param name="sCeo"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	15/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CsnCidEstCep(ByVal sCep As String) As DataSet
        Dim oCsnCidEstCep As New DB_VAKRep
        Dim sVlrErr As String
        Dim sCplCmdSql As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            CsnCidEstCep = oCsnCidEstCep.CsnCidEstCep(sCep, sVlrErr, oCnx)
            If sVlrErr <> "" Then
                Throw New Exception(sVlrErr)
            End If
        Catch oEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar cidade/estado por CEP. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oCsnCidEstCep = Nothing
        End Try
    End Function

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
    Public Function CsnDdoHstEmpRep(ByVal sCodRep As String) As DataSet
        'objeto
        Dim oObeCsnDdoRep As New DB_VAKCsnRep

        'valor de retorno
        Dim sVlrRet As DataSet
        Dim sVlrErr As String

        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnDdoRep.CsnDdoHstEmpRep(sCodRep, oCnx)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar informações do histórico do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnDdoRep = Nothing
        End Try
    End Function

    Public Function CsnDdoEmpRep(ByVal sCodRep As String) As DataSet
        'objeto
        Dim oObeCsnDdoRep As New DB_VAKCsnRep

        'valor de retorno
        Dim sVlrRet As DataSet
        Dim sVlrErr As String

        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oObeCsnDdoRep.CsnDdoEmpRep(sCodRep, oCnx)
            'retorno com sucesso
            Return sVlrRet
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            sVlrErr = "Houve um problema ao consultar informações do representante. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeCsnDdoRep = Nothing
        End Try
    End Function
#End Region

End Class