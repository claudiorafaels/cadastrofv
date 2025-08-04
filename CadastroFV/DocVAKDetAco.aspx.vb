''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKDetAco
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe detalhes da ação (ação genérica, exceto mensagem enviada e solicitação/resposta parecer.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKDetAco
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumSeq As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAco As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDatCri As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents lblRspAco As System.Web.UI.WebControls.Label
    Protected WithEvents lblAux As System.Web.UI.WebControls.Label
    Protected WithEvents lblAuxCdo As System.Web.UI.WebControls.Label
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carga da página.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim iNumSeq As Integer
            Dim iCodFlu As Integer
            Dim sObsAco As String
            Dim BO_VAK As New VAK020.BO_VAKFluDstRep
            Dim oGrpDdo As DataSet
            iCodFlu = Request.QueryString("CodFlu")
            iNumSeq = Request.QueryString("NumSeq")
            oGrpDdo = BO_VAK.CsnAcoGen(iCodFlu, iNumSeq, sObsAco)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                Dim sCodAuxAco As String
                Dim iCodAco As Integer
                sCodAuxAco = oGrpDdo.Tables(0).Rows(0)("CODAUXACO")
                iCodAco = oGrpDdo.Tables(0).Rows(0)("CODACO")
                Me.lblFluxo.Text = oGrpDdo.Tables(0).Rows(0)("CODFLUDSTREP")
                Me.lblRepresentante.Text = oGrpDdo.Tables(0).Rows(0)("CODREP") & " - " & oGrpDdo.Tables(0).Rows(0)("NOMREP")
                Me.lblNumSeq.Text = oGrpDdo.Tables(0).Rows(0)("NUMSEQ")
                Me.lblDatCri.Text = Format(oGrpDdo.Tables(0).Rows(0)("DATCRI"), "dd/MM/yyyy")
                Me.lblRspAco.Text = oGrpDdo.Tables(0).Rows(0)("CODFNC") & " - " & oGrpDdo.Tables(0).Rows(0)("NOMFNC")
                Me.lblAco.Text = oGrpDdo.Tables(0).Rows(0)("CODACO") & " - " & oGrpDdo.Tables(0).Rows(0)("DESACOUSR")

                If iCodAco <> 25 And iCodAco <> 29 And _
                   iCodAco <> 37 And iCodAco <> 35 And _
                    iCodAco <> 36 Then
                    Me.txtObs.Text = sObsAco
                Else
                    Me.txtObs.Visible = False
                    Me.lblObs.Visible = False
                End If

                'Campo auxiliar

                If iCodAco = 15 Then
                    'ACERTO REALIZADO EM TRIBUNAL DE ARBITRAGEM
                    Me.lblAux.Text = "Realização do acerto:"
                    Me.lblAuxCdo.Text = Format(New Date(Left(sCodAuxAco, 4), Mid(sCodAuxAco, 5, 2), Right(sCodAuxAco, 2)), "dd/MM/yyyy")
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 26 Then
                    'NOTIFICAÇÃO PARA RESCISÃO DO CONTRATO DE LOCAÇÃO DO EQUIPAMENTO RETORNADA
                    Me.lblAux.Text = "Assinatura da notificação:"
                    Me.lblAuxCdo.Text = Format(New Date(Left(sCodAuxAco, 4), Mid(sCodAuxAco, 5, 2), Right(sCodAuxAco, 2)), "dd/MM/yyyy")
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 33 Then
                    'CARTA DE RESCISÃO RECEBIDA
                    Me.lblAux.Text = "Recebimento da carta de rescisão:"
                    Me.lblAuxCdo.Text = Format(New Date(Left(sCodAuxAco, 4), Mid(sCodAuxAco, 5, 2), Right(sCodAuxAco, 2)), "dd/MM/yyyy")
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 16 Then
                    'RESULTADO DA AÇÃO DE REINTEGRAÇÃO DE POSSE INFORMADO
                    Me.lblAux.Text = "Resultado da ação de reintegração:"
                    If sCodAuxAco = "0" Then
                        Me.lblAuxCdo.Text = "Negativo"
                    ElseIf sCodAuxAco = "1" Then
                        Me.lblAuxCdo.Text = "Positivo"
                    End If
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 28 Then
                    'BAIXA DE EQUIPAMENTOS COMO PERDA ANALISADA
                    Me.lblAux.Text = "Baixa dos equipamentos como perda:"
                    If sCodAuxAco = "0" Then
                        Me.lblAuxCdo.Text = "Rejeitada"
                    ElseIf sCodAuxAco = "1" Then
                        Me.lblAuxCdo.Text = "Aprovada"
                    End If
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 34 Then
                    'MOTIVO DA DESATIVAÇÃO ALTERADO
                    Dim iCodMtvDst As Integer = oGrpDdo.Tables(0).Rows(0)("CODAUXACO")
                    Dim oGrpDdoMtvDst As DataSet = BO_VAK.CsnMtvDst(iCodMtvDst)
                    Dim sDesMtvDst As String
                    If oGrpDdoMtvDst.Tables(0).Rows.Count > 0 Then
                        sDesMtvDst = oGrpDdoMtvDst.Tables(0).Rows(0)("DESMTVDSTEDEVND")
                    Else
                        sDesMtvDst = " "
                    End If
                    Me.lblAux.Text = "Novo motivo da desativação:"
                    Me.lblAuxCdo.Text = iCodMtvDst & " - " & sDesMtvDst
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                ElseIf iCodAco = 7 Then
                    'NOTIFICAÇÃO RETORNADA
                    Me.lblAux.Text = "Representante pode ser desativado?"
                    If sCodAuxAco = "0" Then
                        Me.lblAuxCdo.Text = "Não"
                    ElseIf sCodAuxAco = "1" Then
                        Me.lblAuxCdo.Text = "Sim"
                    End If
                    Me.lblAux.Visible = True
                    Me.lblAuxCdo.Visible = True
                Else
                    Me.lblAux.Visible = False
                    Me.lblAuxCdo.Visible = False
                End If
            Else
                Throw New Exception("Não existe na base de dados informações sobre a ação com núm.seq. " & iNumSeq.ToString & " do fluxo nro.: " & iCodFlu.ToString)
            End If
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona botão voltar.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoltar.Click

        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodAco As String

        iCodRep = Request.QueryString("CodRep")
        iCodFlu = Request.QueryString("CodFlu")
        sNomRep = Request.QueryString("NomRep")
        iCodAco = Request.QueryString("CodAco")
        sTipAco = Request.QueryString("tipAco")

        Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)
    End Sub
End Class
