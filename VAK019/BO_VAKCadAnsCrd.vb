Imports Microsoft.ApplicationBlocks.ExceptionManagement

Public Class BO_VAKCadAnsCrd

#Region "---------------------- Insere Dados do Analista de Créditos ---------------"
    Public Function IsrDdoAnsCrd(ByVal oGrpDdoAnsCrd As DataSet, _
                                 ByRef oCnx As IAU013.UO_IAUCnxAcsDdo) As String
        ''objeto
        Dim oObeIsrDdoAnsCrd As DB_VAKAnsCrd

        'xml
        Dim oObeLetTxtMcoAnsCrd As System.IO.StringReader
        Dim oObeLetTxtMcoFnc As System.IO.StringReader

        Dim oGrpDdoFnc As New DataSet

        'valor de retorno
        Dim sVlrRet, sVlrRetCsn As String
        Dim sVlrErr As String

        'dados da tabela de analista de crédito
        Dim sCodFnc As String
        Dim sDesEndCreEtn As String
        Dim iIndCreEtnPad As Integer


        Dim iCntFnc As Integer

        Try
            sVlrRet = ""
            'executa db
            oObeIsrDdoAnsCrd = New DB_VAKAnsCrd
            If oGrpDdoAnsCrd.Tables(0).Rows.Count = 0 Then
                sVlrErr = "O documento XML de analistas de crédito está vazio. Por favor, entre em contato com o administrador do Sistema!"
                Throw New Exception(sVlrErr)
            End If
            For iCntFnc = 0 To oGrpDdoAnsCrd.Tables(0).Rows.Count - 1
                sCodFnc = oGrpDdoAnsCrd.Tables(0).Rows(iCntFnc).Item(0)
                If Not IsDBNull(oGrpDdoAnsCrd.Tables(0).Rows(iCntFnc).Item(1)) Then
                    sDesEndCreEtn = oGrpDdoAnsCrd.Tables(0).Rows(iCntFnc).Item(1)
                Else
                    sDesEndCreEtn = ""
                End If

                iIndCreEtnPad = oGrpDdoAnsCrd.Tables(0).Rows(iCntFnc).Item(2)

                ' Verifica se o funcionario existe
                sVlrRetCsn = oObeIsrDdoAnsCrd.CsnCodFnc(sCodFnc, sVlrErr, oCnx)
                oObeLetTxtMcoFnc = New System.IO.StringReader(sVlrRetCsn)
                oGrpDdoFnc.ReadXml(oObeLetTxtMcoFnc)

                If oGrpDdoFnc.Tables(0).Rows.Count = 0 Then
                    sVlrErr = "O funcionário de código " & sCodFnc & " não existe. Por favor, entre em contato com o administrador do Sistema!"
                    Throw New Exception(sVlrErr)
                End If

                sVlrRet = oObeIsrDdoAnsCrd.IsrDdoAnsCrd(sCodFnc, sDesEndCreEtn, iIndCreEtnPad, sVlrErr, oCnx)
            Next
            Return "1"
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao inserir dados dos analistas de créditos. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oObeIsrDdoAnsCrd = Nothing
        End Try
    End Function
#End Region

#Region "---------------------- Altera Dados do Analista de Créditos------------------- "
    Public Function AltDdoAnsCrd(ByVal dts As DataSet) As String
        'objeto
        Dim oObeEcsDdoAnsCrd As DB_VAKAnsCrd
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        'valor de retorno
        Dim sVlrRet, sVlrRetEcs As String
        Dim sVlrErr As String

        Try
            'Abre a conexão
            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            oCnx.IniTsc()

            sVlrRet = ""

            'executa db
            oObeEcsDdoAnsCrd = New DB_VAKAnsCrd
            sVlrRet = ""
            ' Exclui os analistas de creditos
            sVlrRetEcs = oObeEcsDdoAnsCrd.EcsDdoAnsCrd(sVlrErr, oCnx)
            ' Inclui os analistas de créditos
            sVlrRet = IsrDdoAnsCrd(dts, oCnx)
            oCnx.FimTscSuc()
            Return "1"
        Catch oObeEcc As Exception
            oCnx.FimTscErr()
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario
            If sVlrErr = "" Then
                sVlrErr = "Houve um problema ao alterar dados dos analistas de créditos. Entre em contato com o Administrador do Sistema!"
            End If
            Throw New Exception(sVlrErr)
        Finally
            oCnx.Dispose()
            oObeEcsDdoAnsCrd = Nothing
        End Try
    End Function
#End Region

End Class