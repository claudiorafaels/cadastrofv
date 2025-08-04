Imports VAK020

''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DOCVAKLstRep
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe lista de representantes e fluxos.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DOCVAKLstRep
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents btnConsultar As System.Web.UI.WebControls.Button
    Protected WithEvents GrpDdoFluDst As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDiaSemPed As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdbCriado As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbIniciado As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbInexistente As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbTodos As System.Web.UI.WebControls.RadioButton
    Protected WithEvents btnLstFlu As System.Web.UI.WebControls.Button
    Protected WithEvents rdbARevisar As System.Web.UI.WebControls.RadioButton

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
    ''' 	[claudio.rafael]	04/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Session("PagAnt") = "DOCVAKLstRep.aspx"
            Me.txtCodRep.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            Me.txtDiaSemPed.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            CarregarRepresentantes(False)
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega representantes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	04/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregarRepresentantes(ByVal CarregarLista As Boolean)
        Dim oCsnLstRep As BO_VAKFluDstRep = New BO_VAKFluDstRep
        Dim dtsRepresentantes As DataSet
        Dim iCodSup As Integer
        Dim iCodRep As Integer
        Dim sNomRep As String
        Dim iQdeDiaSemPed As Integer
        Dim iDesSitFlu As BO_VAKFluDstRep.enmDesSitFlu
        Dim oLnhGrd As DataGridItem
        Dim iQdeRec As Integer
        Dim iCodRepAtl As Integer
        Dim iCodFluAtl As Integer
        Dim sTipAco As String
        Dim sNomRepAtl As String

        iCodSup = Session("CodSup") '355
        If Me.txtCodRep.Text.Trim.Length > 0 Then
            iCodRep = Convert.ToInt32(Me.txtCodRep.Text)
        Else
            iCodRep = -1
        End If
        If Me.txtNomRep.Text.Trim.Length > 0 Then
            sNomRep = Me.txtNomRep.Text
        Else
            sNomRep = ""
        End If
        If Me.txtDiaSemPed.Text.Trim.Length > 0 Then
            iQdeDiaSemPed = Convert.ToInt32(Me.txtDiaSemPed.Text)
        Else
            iQdeDiaSemPed = -1
        End If
        If rdbCriado.Checked Then
            iDesSitFlu = BO_VAKFluDstRep.enmDesSitFlu.Criado
        ElseIf rdbInexistente.Checked Then
            iDesSitFlu = BO_VAKFluDstRep.enmDesSitFlu.Inexistente
        ElseIf rdbIniciado.Checked Then
            iDesSitFlu = BO_VAKFluDstRep.enmDesSitFlu.Iniciado
        ElseIf rdbARevisar.Checked Then
            iDesSitFlu = BO_VAKFluDstRep.enmDesSitFlu.ARevisar
        Else
            iDesSitFlu = -1
        End If

        If Not Session("dtsRepresentantes") Is Nothing Then
            dtsRepresentantes = Session("dtsRepresentantes")
        ElseIf Not CarregarLista Then
            Session("dtsRepresentantes") = Nothing
            dtsRepresentantes = Nothing
        Else
            dtsRepresentantes = oCsnLstRep.CsnLstRep(iCodSup, iCodRep, sNomRep, iQdeDiaSemPed, iDesSitFlu)
            Session("dtsRepresentantes") = dtsRepresentantes
        End If

        GrpDdoFluDst.CurrentPageIndex = Session("PaginaAtual")

        If Not IsNothing(dtsRepresentantes) Then
            Me.GrpDdoFluDst.DataSource = dtsRepresentantes.Tables(0)
        End If

        Me.GrpDdoFluDst.DataBind()
        Me.GrpDdoFluDst.Columns(5).Visible = False
        For Each oLnhGrd In GrpDdoFluDst.Items
            iQdeRec = oLnhGrd.Cells(2).Text
            If iQdeRec = 0 Then oLnhGrd.Cells(2).Text = 0
            'Transferir para tela de detalhes do fluxo
            If oLnhGrd.Cells(3).Text = "Inexistente" Then
                sTipAco = "Criar"
            ElseIf oLnhGrd.Cells(3).Text = "Criado" Then
                sTipAco = "Alterar"
            ElseIf oLnhGrd.Cells(3).Text = "Iniciado" Then
                sTipAco = "Consultar"
            ElseIf oLnhGrd.Cells(3).Text = "A Revisar" Then
                sTipAco = "Revisar"
            End If
            iCodRepAtl = oLnhGrd.Cells(0).Text
            iCodFluAtl = oLnhGrd.Cells(5).Text
            sNomRepAtl = oLnhGrd.Cells(1).Text
            oLnhGrd.Cells(3).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                  "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & oLnhGrd.Cells(3).Text & "</A>"
            oLnhGrd.Cells(6).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                  "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & sTipAco & "</A>"
        Next
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão consultar.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Session("dtsRepresentantes") = Nothing
        Session("PaginaAtual") = Nothing
        Session("CpoOrd") = Nothing
        CarregarRepresentantes(True)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Manipula o evento GrpDdoFluDst.PageIndexChanged
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' Controla a paginação do grid que lista os RCAs
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	01/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoFluDst_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrpDdoFluDst.PageIndexChanged
        Dim CpoOrd As String
        Dim dtsRepresentantes As DataSet
        Dim oLnhGrd As DataGridItem
        Dim iQdeRec As Integer
        Dim sTipAco As String
        Dim iCodRepAtl As Integer
        Dim iCodFluAtl As Integer
        Dim sNomRepAtl As String
        Try
            GrpDdoFluDst.CurrentPageIndex = e.NewPageIndex
            Session("PaginaAtual") = e.NewPageIndex
            CpoOrd = Session("CpoOrd")
            dtsRepresentantes = Session("dtsRepresentantes")
            dtsRepresentantes.Tables(0).DefaultView.Sort = CpoOrd
            With GrpDdoFluDst
                .DataSource = dtsRepresentantes.Tables(0)
                .DataBind()
            End With
            Me.GrpDdoFluDst.Columns(5).Visible = False
            For Each oLnhGrd In GrpDdoFluDst.Items
                iQdeRec = oLnhGrd.Cells(2).Text
                If iQdeRec = 0 Then oLnhGrd.Cells(2).Text = 0
                'Transferir para tela de detalhes do fluxo
                If oLnhGrd.Cells(3).Text = "Inexistente" Then
                    sTipAco = "Criar"
                ElseIf oLnhGrd.Cells(3).Text = "Criado" Then
                    sTipAco = "Alterar"
                ElseIf oLnhGrd.Cells(3).Text = "Iniciado" Then
                    sTipAco = "Consultar"
                ElseIf oLnhGrd.Cells(3).Text = "A Revisar" Then
                    sTipAco = "Revisar"
                End If
                iCodRepAtl = oLnhGrd.Cells(0).Text
                iCodFluAtl = oLnhGrd.Cells(5).Text
                sNomRepAtl = oLnhGrd.Cells(1).Text
                oLnhGrd.Cells(3).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                    & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                      "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & oLnhGrd.Cells(3).Text & "</A>"
                oLnhGrd.Cells(6).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                    & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                      "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & sTipAco & "</A>"
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Manipula o evento GrpDdoFluDst.SortCommand
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' Controla a ordenação do grid que lista os RCA's disponíveis
    ''' </remarks>
    ''' <history>
    ''' 	[claudio.rafael]	01/02/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoFluDst_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles GrpDdoFluDst.SortCommand
        Dim CpoOrd As String = e.SortExpression
        Dim dtsRepresentantes As DataSet
        Dim oLnhGrd As DataGridItem
        Dim iQdeRec As Integer
        Dim sTipAco As String
        Dim iCodRepAtl As Integer
        Dim iCodFluAtl As Integer
        Dim sNomRepAtl As String
        Try
            Session("CpoOrd") = CpoOrd
            dtsRepresentantes = Session("dtsRepresentantes")
            dtsRepresentantes.Tables(0).DefaultView.Sort = CpoOrd
            With GrpDdoFluDst
                .DataSource = dtsRepresentantes.Tables(0)
                .DataBind()
            End With
            Me.GrpDdoFluDst.Columns(5).Visible = False
            For Each oLnhGrd In GrpDdoFluDst.Items
                iQdeRec = oLnhGrd.Cells(2).Text
                If iQdeRec = 0 Then oLnhGrd.Cells(2).Text = 0
                'Transferir para tela de detalhes do fluxo
                If oLnhGrd.Cells(3).Text = "Inexistente" Then
                    sTipAco = "Criar"
                ElseIf oLnhGrd.Cells(3).Text = "Criado" Then
                    sTipAco = "Alterar"
                ElseIf oLnhGrd.Cells(3).Text = "Iniciado" Then
                    sTipAco = "Consultar"
                ElseIf oLnhGrd.Cells(3).Text = "A Revisar" Then
                    sTipAco = "Revisar"
                End If
                iCodRepAtl = oLnhGrd.Cells(0).Text
                iCodFluAtl = oLnhGrd.Cells(5).Text
                sNomRepAtl = oLnhGrd.Cells(1).Text
                oLnhGrd.Cells(3).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                    & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                      "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & oLnhGrd.Cells(3).Text & "</A>"
                oLnhGrd.Cells(6).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                    & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                      "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & sTipAco & "</A>"
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão 'Fluxos de desativação...'
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnLstFlu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLstFlu.Click
        Session("dtsRepresentantes") = Nothing
        Session("PaginaAtual") = Nothing
        Session("CpoOrd") = Nothing
        Server.Transfer("DocVAKLstFluRep.aspx")
    End Sub
End Class