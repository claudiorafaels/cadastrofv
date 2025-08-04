''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKLstAco
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe lista de ações do fluxo.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKLstAco
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lstTipoAcoes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnIcrobs As System.Web.UI.WebControls.Button
    Protected WithEvents btnRpdPrc As System.Web.UI.WebControls.Button
    Protected WithEvents btnPdrPrc As System.Web.UI.WebControls.Button
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents GrpDdoAco As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodFlu As System.Web.UI.WebControls.Label
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
            Dim iCodFlu As Integer
            Dim iCodRep As Integer
            Dim iCodAco As Integer
            Dim sNomRep As String

            'Recupera query string
            iCodRep = Request.QueryString("codRep")
            iCodFlu = Request.QueryString("codFlu")
            iCodAco = Request.QueryString("codAco")
            If iCodAco < 1 Then iCodAco = -1
            sNomRep = Server.UrlDecode(Request.QueryString("nomRep"))

            'Carrega dados
            CarregaTiposAcao()
            Me.lstTipoAcoes.SelectedIndex = Me.lstTipoAcoes.Items.IndexOf(Me.lstTipoAcoes.Items.FindByValue(iCodAco))
            CarregaAcoes(iCodFlu, iCodAco)

            'Preenche cabeçalho
            Me.txtCodNomRep.Text = iCodRep.ToString & " - " & sNomRep.ToString.Trim.ToUpper
            Me.lblCodFlu.Text = iCodFlu.ToString
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega tipos de ação.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregaTiposAcao()
        Dim BO_VAK As New VAK020.BO_VAKFluDstRep
        Dim oGrpDdoTipAco As DataSet

        oGrpDdoTipAco = BO_VAK.CsnTipAco
        With Me.lstTipoAcoes
            .DataSource = oGrpDdoTipAco
            .DataValueField = "CODACO"
            .DataTextField = "DESACOUSR"
            .DataBind()
            .Items.Insert(0, " ")
        End With
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega ações.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="iCodAco">Código da ação</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregaAcoes(ByVal iCodFlu As Integer, _
                             ByVal iCodAco As Integer)

        Dim BO_VAK As New VAK020.BO_VAKFluDstRep
        Dim oGrpDdoAco As DataSet

        oGrpDdoAco = BO_VAK.CsnLstAcoFlu(iCodFlu, iCodAco)
        Session("oGrpDdoAco") = oGrpDdoAco
        CarregaGrid(oGrpDdoAco)


        'Se o fluxo estiver CANCELADO ou CONCLUÍDO, não permitir a criação de novas ações
        Dim viwAco As DataView
        viwAco = New DataView(oGrpDdoAco.Tables(0))
        viwAco.RowFilter = "CODACO = 6 or CODACO = 8"
        If viwAco.Count > 0 Then
            Me.btnIcrobs.Enabled = False
            Me.btnRpdPrc.Enabled = False
            Me.btnPdrPrc.Enabled = False
        Else
            Me.btnIcrobs.Enabled = True
            Me.btnRpdPrc.Enabled = True
            Me.btnPdrPrc.Enabled = True
        End If

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega grid.
    ''' </summary>
    ''' <param name="oGrpDdoAco">Conjunto de dados(dataset)</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregaGrid(ByRef oGrpDdoAco As DataSet)
        Dim CpoOrd As String
        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodSup As Integer
        Dim iCodAco As Integer
        Dim iNumSeqPedOpn As Integer
        Dim iCodAcoSel As Integer
        Dim sInfoExtra As String

        Try
            'Carrega grid
            CpoOrd = Session("CpoOrdAco")
            oGrpDdoAco.Tables(0).DefaultView.Sort = CpoOrd
            GrpDdoAco.CurrentPageIndex = Session("PaginaAtualAcao")
            With GrpDdoAco
                .DataSource = oGrpDdoAco.Tables(0).DefaultView
                .DataBind()
            End With

            'Monta link para detalhes de ação
            iCodRep = Request.QueryString("codrep")
            iCodFlu = Request.QueryString("codFlu")
            sNomRep = Request.QueryString("nomRep")
            sTipAco = Request.QueryString("tipAco")
            iCodAco = IIf(Me.lstTipoAcoes.SelectedValue = " ", -1, Me.lstTipoAcoes.SelectedValue)
            For Each oLnhGrd As DataGridItem In GrpDdoAco.Items
                'iNumSeqPedOpn = oGrpDdoAco.Tables(0).Rows(oLnhGrd.DataSetIndex)("NUMSEQ")
                'sInfoExtra = Trim(oGrpDdoAco.Tables(0).Rows(oLnhGrd.DataSetIndex)("InformacaoExtra"))
                'iCodAcoSel = oGrpDdoAco.Tables(0).Rows(oLnhGrd.DataSetIndex)("CODACO")
                iNumSeqPedOpn = oLnhGrd.Cells(0).Text.Trim
                sInfoExtra = oLnhGrd.Cells(6).Text.Trim
                iCodAcoSel = oLnhGrd.Cells(1).Text.Trim
                Select Case iCodAcoSel
                    Case 4
                        'Comunicação enviada (email)
                        oLnhGrd.Cells(6).Text = "<A href='DocVAKDetAcoMsgEnv.aspx?codrep=" & iCodRep.ToString & _
                         "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & _
                            "&codaco=" & iCodAco.ToString & "&numseq=" & iNumSeqPedOpn & "'>" & sInfoExtra & "</A>"
                    Case 9
                        'Pedido de parecer
                        oLnhGrd.Cells(6).Text = "<A href='DocVAKRpdPrc.aspx?codrep=" & iCodRep.ToString & _
                         "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & _
                            "&codaco=" & iCodAco.ToString & "&numseq=" & iNumSeqPedOpn & "&CodAcoSel=9&TipFnc=Consultar'>" & sInfoExtra & "</A>"
                    Case 10
                        'Resposta de parecer
                        oLnhGrd.Cells(6).Text = "<A href='DocVAKRpdPrc.aspx?codrep=" & iCodRep.ToString & _
                         "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & _
                            "&codaco=" & iCodAco.ToString & "&numseq=" & iNumSeqPedOpn & "&CodAcoSel=10&TipFnc=Consultar'>" & sInfoExtra & "</A>"
                    Case Else
                        'Ação genérica (todas as outras)
                        oLnhGrd.Cells(6).Text = "<A href='DocVAKDetAco.aspx?codrep=" & iCodRep.ToString & _
                         "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & _
                            "&codaco=" & iCodAco.ToString & "&numseq=" & iNumSeqPedOpn & "'>" & sInfoExtra & "</A>"
                End Select
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Response evento mudança de página no grid.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoAco_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrpDdoAco.PageIndexChanged
        Dim CpoOrd As String
        Dim oGrpDdoAco As DataSet
        Dim oLnhGrd As DataGridItem
        Try
            GrpDdoAco.CurrentPageIndex = e.NewPageIndex
            Session("PaginaAtualAcao") = e.NewPageIndex
            oGrpDdoAco = Session("oGrpDdoAco")
            CarregaGrid(oGrpDdoAco)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento ordenação do grid.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoAco_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles GrpDdoAco.SortCommand
        Dim oGrpDdoAco As DataSet
        Dim oLnhGrd As DataGridItem
        Try
            Session("CpoOrdAco") = e.SortExpression
            oGrpDdoAco = Session("oGrpDdoAco")
            CarregaGrid(oGrpDdoAco)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento mudança no tipo de ação.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub lstTipoAcoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTipoAcoes.SelectedIndexChanged

        Dim iCodAco As Integer
        Dim iCodFlu As Integer

        If Me.lstTipoAcoes.SelectedIndex < 1 Then iCodAco = -1 Else iCodAco = Me.lstTipoAcoes.SelectedValue
        iCodFlu = Request.QueryString("codFlu")
        Session("PaginaAtualAcao") = Nothing
        CarregaAcoes(iCodFlu, iCodAco)

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

        iCodRep = Request.QueryString("codrep")
        iCodFlu = Request.QueryString("codFlu")
        sNomRep = Request.QueryString("nomRep")
        sTipAco = Request.QueryString("tipAco")
        Session("PaginaAtualAcao") = Nothing
        Server.Transfer("DocVAKFluDstRep.aspx?codrep=" & iCodRep.ToString _
            & "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & _
                "&tipAco=" & sTipAco)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão incluir observação.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnIcrobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIcrobs.Click

        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodAco As String

        iCodRep = Request.QueryString("CodRep")
        iCodFlu = Request.QueryString("CodFlu")
        sNomRep = Request.QueryString("NomRep")
        iCodAco = IIf(Me.lstTipoAcoes.SelectedValue.Trim = "", -1, Me.lstTipoAcoes.SelectedValue)
        If iCodAco < 1 Then iCodAco = -1
        sTipAco = Request.QueryString("tipAco")

        Server.Transfer("DocVAKIncObs.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão responder parecer.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnRpdPrc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpdPrc.Click

        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodAco As String

        iCodRep = Request.QueryString("CodRep")
        iCodFlu = Request.QueryString("CodFlu")
        sNomRep = Request.QueryString("NomRep")
        iCodAco = IIf(Me.lstTipoAcoes.SelectedValue.Trim = "", -1, Me.lstTipoAcoes.SelectedValue)
        If iCodAco < 1 Then iCodAco = -1
        sTipAco = Request.QueryString("tipAco")

        Server.Transfer("DocVAKLstPdrPrc.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão pedido parecer.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnPdrPrc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdrPrc.Click

        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodAco As String

        iCodRep = Request.QueryString("CodRep")
        iCodFlu = Request.QueryString("CodFlu")
        sNomRep = Request.QueryString("NomRep")
        iCodAco = IIf(Me.lstTipoAcoes.SelectedValue.Trim = "", -1, Me.lstTipoAcoes.SelectedValue)
        If iCodAco < 1 Then iCodAco = -1
        sTipAco = Request.QueryString("tipAco")
        Server.Transfer("DocVAKPdrPrc.aspx?codrep=" & iCodRep.ToString & _
             "&codflu=" & iCodFlu.ToString & "&nomRep=" & sNomRep & "&tipAco=" & sTipAco & "&codaco=" & iCodAco.ToString)
    End Sub

End Class