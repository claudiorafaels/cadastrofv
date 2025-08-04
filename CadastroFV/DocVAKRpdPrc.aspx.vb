''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKRpdPrc
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe ação solicitação / resposta de parecer
''' </summary>
''' <remarks>
''' A página serve tanto para exibir o tipo de ação como para responder o parecedr.
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKRpdPrc
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents btnConfirmar As System.Web.UI.WebControls.Button
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNomRspPed As System.Web.UI.WebControls.Label
    Protected WithEvents txtPedOpn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRspOpn As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDatCriPed As System.Web.UI.WebControls.Label
    Protected WithEvents lblDatCriRsp As System.Web.UI.WebControls.Label
    Protected WithEvents lblNomDsnPed As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumSeqPed As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumSeqRsp As System.Web.UI.WebControls.Label

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
            Dim iCodFlu As Integer 'Fluxo
            Dim iNumSeqPedOpn As Integer 'Ação
            Dim BO_VAK As New VAK020.BO_VAKFluDstRep
            Dim oGrpDdo As DataSet
            Dim sPedOpn As String
            Dim sRspOpn As String
            Dim sTipFnc As String
            Dim iCodAco As Integer
            Dim iCodAcoSel As Integer

            'Consulta dados do pedido e resposta de parecer
            iCodFlu = Request.QueryString("CodFlu")
            iNumSeqPedOpn = Request.QueryString("NumSeq")
            sTipFnc = Request.QueryString("TipFnc")
            iCodAco = Request.QueryString("codAco")
            iCodAcoSel = Request.QueryString("CodAcoSel")
            oGrpDdo = BO_VAK.CsnPedOpn(iCodFlu, iNumSeqPedOpn, iCodAcoSel, sPedOpn, sRspOpn)

            'Preenche formulário
            Me.lblFluxo.Text = oGrpDdo.Tables(0).Rows(0)("CODFLUDSTREP")
            Me.lblRepresentante.Text = oGrpDdo.Tables(0).Rows(0)("CODREP") & " - " & Trim(oGrpDdo.Tables(0).Rows(0)("NOMREP"))
            Me.lblNumSeqPed.Text = oGrpDdo.Tables(0).Rows(0)("NUMSEQPED")
            Me.lblDatCriPed.Text = Format(oGrpDdo.Tables(0).Rows(0)("DATCRIPED"), "dd/MM/yyyy")
            Me.lblNomRspPed.Text = oGrpDdo.Tables(0).Rows(0)("CODFNCPED") & " - " & Trim(oGrpDdo.Tables(0).Rows(0)("NOMFNCPED"))
            Me.txtPedOpn.Text = sPedOpn.Trim
            If Not IsDBNull(oGrpDdo.Tables(0).Rows(0)("NUMSEQRSP")) Then
                Me.lblNumSeqRsp.Text = oGrpDdo.Tables(0).Rows(0)("NUMSEQRSP")
            Else
                Me.lblNumSeqRsp.Text = ""
            End If
            If Not IsDBNull(oGrpDdo.Tables(0).Rows(0)("DATCRIRSP")) Then
                Me.lblDatCriRsp.Text = Format(oGrpDdo.Tables(0).Rows(0)("DATCRIRSP"), "dd/MM/yyyy")
            Else
                Me.lblDatCriRsp.Text = "  /  /  "
            End If
            If Not IsDBNull(oGrpDdo.Tables(0).Rows(0)("NOMFNCRSP")) Then
                Me.lblNomDsnPed.Text = oGrpDdo.Tables(0).Rows(0)("CODFNCRSP") & " - " & Trim(oGrpDdo.Tables(0).Rows(0)("NOMFNCRSP"))
            Else
                Me.lblNomDsnPed.Text = ""
            End If
            Me.txtRspOpn.Text = sRspOpn.Trim

            If sTipFnc = "Consultar" Then
                ControlesBloquear(True)
            ElseIf sTipFnc = "Responder" Then
                ControlesBloquear(False)
            End If

        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Bloqueia controles como somente leitura.
    ''' </summary>
    ''' <param name="bSomenteLeitura">Somente leitura (sim/não)</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ControlesBloquear(ByVal bSomenteLeitura As Boolean)
        If bSomenteLeitura Then
            txtRspOpn.ReadOnly = True
            btnConfirmar.Visible = False
        Else
            txtRspOpn.ReadOnly = False
            btnConfirmar.Visible = True
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento do botão confirmar.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        Dim iCodFlu As Integer
        Dim iCodRep As Integer
        Dim sNomRep As String
        Dim iNumSeqPedOpn As Integer
        Dim sDesObs As String
        Dim sTipAco As String
        Dim iCodAco As Integer
        Dim sTipAcoFlu As String
        Dim iCodAcoSel As Integer
        Dim sNomFncDsn As String
        Dim sURLSis As String
        Dim BO_VAK As New VAK020.BO_VAKFluDstRep

        'Valida informações
        If Me.txtRspOpn.Text.Trim.Length < 3 Then Response.Write("<script>alert('É necessário informar o texto de resposta do parecer.');</script>") : Exit Sub

        'Verifica se sessão ainda válida
        If (Session("TipRep") <> "GM") Then
            Session("CodErr") = "1"
            Response.Redirect("DocVAKVldUsr.aspx")
        End If

        'Resposta informações
        iCodFlu = Request.QueryString("CodFlu")
        iNumSeqPedOpn = Request.QueryString("NumSeq")
        iCodAco = Request.QueryString("CodAco")
        iCodRep = Request.QueryString("CodRep")
        sNomRep = Request.QueryString("NomRep")
        sDesObs = Me.txtRspOpn.Text.Trim.ToUpper
        sTipAco = Request.QueryString("tipAco")
        iCodAcoSel = Request.QueryString("CodAcoSel")
        sNomFncDsn = lblNomRspPed.Text.ToUpper.Split("-")(1).Trim
        sURLSis = System.Configuration.ConfigurationSettings.AppSettings("EnderecoSistema")
        BO_VAK.IsrAcoRspPrc(iCodFlu, iNumSeqPedOpn, iCodAcoSel, sDesObs, sNomFncDsn, sURLSis)

        Response.Write("<script>alert('Resposta de parecer incluído com sucesso.');</script>")

        Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento do botão cancelar.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

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