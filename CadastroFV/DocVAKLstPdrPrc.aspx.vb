''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKLstPdrPrc
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe lista de pedidos de parecer pendentes.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKLstPdrPrc
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents GrpDdoAco As System.Web.UI.WebControls.DataGrid

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

            Dim BO_VAK As New VAK020.BO_VAKFluDstRep
            Dim oGrpDdo As DataSet
            Dim oGrpDdoAux As DataSet
            Dim iCodRep As Integer
            Dim iCodFlu As Integer
            Dim sNomRep As String
            Dim sTipAco As String
            Dim iCodAco As String
            Dim iNumSeqPedOpn As Integer
            Dim iCodAcoSel As Integer

            'Obter dados
            iCodRep = Request.QueryString("CodRep")
            iCodFlu = Request.QueryString("CodFlu")
            sNomRep = Request.QueryString("NomRep")
            iCodAco = IIf(Request.QueryString("codaco") = " ", -1, Request.QueryString("codaco"))
            sTipAco = Request.QueryString("tipAco")

            'Prrencher cabeçalho
            Me.lblFluxo.Text = iCodFlu
            Me.lblRepresentante.Text = iCodRep & " - " & sNomRep

            'Prrencher grid
            oGrpDdo = BO_VAK.CsnLstPedOpn(iCodFlu, iCodRep)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                Me.GrpDdoAco.DataSource = oGrpDdo
                Me.GrpDdoAco.DataBind()
                For Each oLnhGrd As DataGridItem In GrpDdoAco.Items
                    iNumSeqPedOpn = oGrpDdo.Tables(0).Rows(oLnhGrd.DataSetIndex)("NUMSEQ")
                    iCodAcoSel = oGrpDdo.Tables(0).Rows(oLnhGrd.DataSetIndex)("CODACO")
                    oLnhGrd.Cells(2).Text = "<A href='DocVAKRpdPrc.aspx?codrep=" & iCodRep.ToString & _
                     "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & _
                        "&codaco=" & iCodAco.ToString & "&codAcoSel=" & iCodAcoSel & "&numseq=" & iNumSeqPedOpn & "&TipFnc=Responder'>Responder</A>"
                Next
            Else
                Response.Write("<script>alert('Não existem pedidos de parecer em aberto.');</script>")
                btnVoltar_Click(Me, Nothing)
            End If
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão voltar.
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