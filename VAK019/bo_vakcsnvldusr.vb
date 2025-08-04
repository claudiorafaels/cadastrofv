Imports Microsoft.ApplicationBlocks.ExceptionManagement

#Region " --------------- Classe ------------------"

Public Class BO_VAKCsnVldUsr
    'Consulta se o usuario é Analista de credito ou GV
    Public Function CsnAnsCrdGerVnd(ByVal sNomUsrRde As String, ByRef sCodUsrRcf As String, ByRef sNomFnc As String) As String
        'objeto
        Dim oCsn As DB_VAKVldUsr
        'xml
        Dim oLetTxtMco As System.IO.StringReader
        Dim oLetTxtMcoGer As System.IO.StringReader
        'Dataset
        Dim oGrpDdoRep As New DataSet
        Dim oGrpDdoGer As New DataSet
        'valor de retorno
        Dim sVlrRet As String
        Dim sVlrErr As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo

        Try
            'executa db
            oCsn = New DB_VAKVldUsr

            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
            sVlrRet = oCsn.CsnAnsCrd(sNomUsrRde, sVlrErr, oCnx)
            oCnx.Dispose()

            oLetTxtMco = New System.IO.StringReader(sVlrRet)
            oGrpDdoRep.ReadXml(oLetTxtMco)

            If oGrpDdoRep.Tables(0).Rows.Count = 0 Then

                oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
                sVlrRet = oCsn.CsnGerVnd(sNomUsrRde, sVlrErr, oCnx)
                oCnx.Dispose()

                oLetTxtMcoGer = New System.IO.StringReader(sVlrRet)
                oGrpDdoGer.ReadXml(oLetTxtMcoGer)

                If oGrpDdoGer.Tables(0).Rows.Count = 0 Then
                    Return "0" 'O usuario não é analista nem gv
                Else
                    sCodUsrRcf = oGrpDdoGer.Tables(0).Rows(0).Item("codger")
                    sNomFnc = oGrpDdoGer.Tables(0).Rows(0).Item("nomger")
                    Return "1" 'O usuário é um GV
                End If
            Else
                sCodUsrRcf = oGrpDdoRep.Tables(0).Rows(0).Item("codanscad")
                sNomFnc = oGrpDdoRep.Tables(0).Rows(0).Item("nomfnc")
                Return "2" 'O usuario é um Analista
            End If
        Catch oObeEcc As Exception
            'publica erro no log
            ExceptionManager.Publish(oObeEcc)
            'mensagem de erro para o usuario()
            sVlrErr = "Houve um problema ao consultar se o usuario é Analista de Credito ou Gerente de Vendas. Entre em contato com o Administrador do Sistema!"
            Throw New Exception(sVlrErr)
        Finally
            oCsn = Nothing
            oCnx.Dispose()
        End Try
    End Function
End Class

#End Region