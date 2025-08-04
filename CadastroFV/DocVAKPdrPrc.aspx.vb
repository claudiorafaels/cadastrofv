''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKPdrPrc
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe formulário de inclusão de ação - PEDIDO DE PARECER.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKPdrPrc
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnConfirmar As System.Web.UI.WebControls.Button
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents txtNomFnc As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdCsnFnc As System.Web.UI.WebControls.Button
    Protected WithEvents lstFnc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
    ''' Responde evento botão confirmar.
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

        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sDesObs As String
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodFncDsn As Integer
        Dim sNomFncDsn As String
        Dim BO_VAK As New VAK020.BO_VAKFluDstRep
        Dim sURLSis As String

        'Valida informações
        If Me.lstFnc.SelectedIndex < 1 Then Response.Write("<script>alert('É necessário informar o funcionário para pedido de parecer.');</script>") : Exit Sub
        If Me.txtObs.Text.Trim.Length < 3 Then Response.Write("<script>alert('É necessário informar o texto do pedido de parecer.');</script>") : Exit Sub

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
        iCodFncDsn = Me.lstFnc.SelectedValue
        sNomFncDsn = Me.lstFnc.SelectedItem.Text
        sURLSis = System.Configuration.ConfigurationSettings.AppSettings("EnderecoSistema")
        BO_VAK.IsrAcoPdrPrc(iCodFlu, iCodRep, iCodFncDsn, sDesObs, sNomFncDsn, sURLSis)

        Response.Write("<script>alert('Pedido de parecer incluído com sucesso.');</script>")

        Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString _
            & "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & _
                "&tipAco=" & sTipAco)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão cancelar.
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

        iCodRep = Request.QueryString("codrep")
        iCodFlu = Request.QueryString("codFlu")
        sNomRep = Request.QueryString("nomRep")
        sTipAco = Request.QueryString("tipAco")
        Server.Transfer("DocVAKLstAco.aspx?codrep=" & iCodRep.ToString _
            & "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & _
                "&tipAco=" & sTipAco)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão consultar funcionário.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub cmdCsnFnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCsnFnc.Click
        Dim sNomFnc As String
        Dim oGrpDdo As DataSet
        Dim BO_VAK As New VAK020.BO_VAKFluDstRep
        sNomFnc = Me.txtNomFnc.Text.Trim.ToUpper
        If sNomFnc.Length > 0 Then
            oGrpDdo = BO_VAK.CsnUsrSisDst(sNomFnc)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                Me.lstFnc.DataSource = oGrpDdo
                Me.lstFnc.DataTextField = "NOMFNC"
                Me.lstFnc.DataValueField = "CODFNC"
                Me.lstFnc.DataBind()
                Me.lstFnc.Items.Insert(0, " ")
            End If
        End If
    End Sub
End Class