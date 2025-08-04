''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKIncObr
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe Incluir ação - INCLUIR OBSERVAÇÃO
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKIncObr
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnConfirmar As System.Web.UI.WebControls.Button
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button

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
            Dim iCodRep As Integer
            Dim iCodFlu As Integer
            Dim sNomRep As String
            iCodRep = Request.QueryString("codrep")
            iCodFlu = Request.QueryString("codFlu")
            sNomRep = Request.QueryString("nomRep")
            lblFluxo.Text = iCodFlu.ToString
            lblRepresentante.Text = iCodRep.ToString & " - " & Server.UrlDecode(sNomRep)
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde botão confirmar.
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

        If Me.txtObs.Text.Trim.Length > 3 Then

            Dim iCodRep As Integer
            Dim iCodFlu As Integer
            Dim sDesObs As String
            Dim sNomRep As String
            Dim sTipAco As String
            Dim BO_VAK As New VAK020.BO_VAKFluDstRep

            'Verifica se sessão ainda válida
            If (Session("TipRep") <> "GM") Then
                Session("CodErr") = "1"
                Response.Redirect("DocVAKVldUsr.aspx")
            End If

            'Recupera informações
            iCodRep = Request.QueryString("codrep")
            iCodFlu = Request.QueryString("codFlu")
            sNomRep = Request.QueryString("nomRep")
            sTipAco = Request.QueryString("tipAco")
            sDesObs = Me.txtObs.Text.Trim.ToUpper
            BO_VAK.IsrAcoObsFlu(iCodFlu, iCodRep, sDesObs)

            Response.Write("<script>alert('Observação incluída com sucesso.');</script>")

            Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString _
                & "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & _
                    "&tipAco=" & sTipAco)
        Else
            Response.Write("<script>alert('É necessário informar o texto da observação.');</script>")
        End If

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde botão cancelar.
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
        Dim iCodAco As Integer

        iCodRep = Request.QueryString("CodRep")
        iCodFlu = Request.QueryString("CodFlu")
        sNomRep = Request.QueryString("NomRep")
        iCodAco = Request.QueryString("CodAco")
        sTipAco = Request.QueryString("tipAco")

        Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)
    End Sub

End Class