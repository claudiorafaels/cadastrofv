Public Class DocVAKCsnRep
    Inherits System.Web.UI.Page
    Public sCodSup As String
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents LstSta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents GrpDdoRep As System.Web.UI.WebControls.DataGrid
    Protected WithEvents AcoNvoPsq As System.Web.UI.WebControls.Button
    Protected WithEvents NomRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatIniSlc As eWorld.UI.CalendarPopup
    Protected WithEvents TitNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents TitDatSlc As System.Web.UI.WebControls.Label
    Protected WithEvents TitAte As System.Web.UI.WebControls.Label
    Protected WithEvents NumReq As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumReq As System.Web.UI.WebControls.Label
    Protected WithEvents NumCpf As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumCpf As System.Web.UI.WebControls.Label
    Protected WithEvents AcoCsn As System.Web.UI.WebControls.Button
    Protected WithEvents MsgBox As VAK016.Web.MessageBoxWeb
    Protected WithEvents TitSta As System.Web.UI.WebControls.Label
    Protected WithEvents LstTet As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitTet As System.Web.UI.WebControls.Label
    Protected WithEvents DesDatIniSlc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatFimSlc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatFimSlc As eWorld.UI.CalendarPopup

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Response.Write(System.Threading.Thread.CurrentThread.CurrentCulture.ToString)

        'DataSet de dados
        Dim ds As New DataSet
        sCodSup = Session("CodRep")
        NumCpf.Attributes.Add("onkeypress", "FormataCpf('NumCpf',11,event)")
        DesDatIniSlc.Attributes.Add("onkeypress", "FormataData('DesDatIniSlc',event)")
        DesDatFimSlc.Attributes.Add("onkeypress", "FormataData('DesDatFimSlc',event)")

        If (Session("TipRep") <> "GM") Then
            Session("CodErr") = "1"
            Response.Redirect("DocVAKVldUsr.aspx")
        End If
        If Not IsPostBack Then
            Session("objVAKUtl").funLimpaObj()

            Me.Session("sortOrder") = True
            Me.Session("sortColumn") = "NUMREQCADREP"
            PcdCsnTotSta()
            PcdCsnTetVndGerMcd(sCodSup)
        End If
    End Sub

    Private Sub AcoCsn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcoCsn.Click
        Dim sNumReq As String
        Dim sNomRep As String
        Dim sNumCpf As String
        Dim sCodSta As String
        Dim sCodTet As String
        Dim sDatIniSlc As String
        Dim sDatFimSlc As String
        'Atribuição de valores
        sNumReq = Me.NumReq.Text.Trim
        sNomRep = Me.NomRep.Text.Trim
        sNumCpf = Session("objVAKUtl").funTiraMascara(Me.NumCpf.Text)
        sCodSta = Session("objVAKUtl").funPegaCodigo(Me.LstSta.SelectedItem.Text)
        If Me.LstTet.Items.Count <> 0 Then
            sCodTet = Session("objVAKUtl").funPegaCodigo(Me.LstTet.SelectedItem.Text)
        Else
            sCodTet = ""
        End If
        sDatIniSlc = Session("objVAKUtl").funFrmDatIsr(Me.DatIniSlc)
        sDatFimSlc = Session("objVAKUtl").funFrmDatIsr(Me.DatFimSlc)
        If sDatIniSlc = "1-01-01" Then
            sDatIniSlc = ""
        End If
        If sDatFimSlc = "1-01-01" Then
            sDatFimSlc = ""
        End If
        'Verifica se a opção todos está selecionada
        If sCodSta = "Todos" Then
            sCodSta = ""
        End If
        If sCodTet = "Todos" Then
            sCodTet = ""
        End If

        If Not ((sNumReq = "") And (sNomRep = "") And (sNumCpf = "") And (sCodSta = "") And (sCodTet = "") And (sCodSup = "") And (sDatIniSlc = "") And (sDatFimSlc = "")) Then
            PcdCsnDdoRep(sNumReq, sNomRep, sNumCpf, sCodSta, sCodTet, "", sCodSup, sDatIniSlc, sDatFimSlc)
        Else
            Response.Write(Session("objVAKUtl").funSetErr("Pelo menos um dos campos deve ser preenchido"))
        End If
    End Sub

    Private Sub AcoNvoPsq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcoNvoPsq.Click
        Me.NumReq.Text = ""
        Me.NomRep.Text = ""
        Me.NumCpf.Text = ""
        Me.LstSta.SelectedIndex = 0
        Me.LstTet.SelectedIndex = 0
        Me.DatIniSlc.Nullable = True
        Me.DatFimSlc.Nullable = True
        Me.GrpDdoRep.DataSource = Nothing
        Me.GrpDdoRep.DataBind()
    End Sub
#Region "---- Funções de acesso a componente ----"
    'Consulta que popula o DropDownList de Status
    Private Sub PcdCsnTotSta()
        Dim oObeCsnTotStaItf As New VAK019.BO_VAKCsnRep

        Dim sVlrRet As String
        Try
            sVlrRet = oObeCsnTotStaItf.CsnTotSta()
            'Se tiver true a função coloca a primeira como "TODOS"
            Me.LstSta.DataSource = Session("objVAKUtl").funXMLArray(sVlrRet, True)
            Me.LstSta.DataBind()
        Catch oObeEcc As Exception
            Response.Write(Session("objVAKUtl").funSetErr(oObeEcc.Message))
            'MsgBox.Text = oObeEcc.Message
        Finally
            If Not oObeCsnTotStaItf Is Nothing Then
                oObeCsnTotStaItf = Nothing
            End If
        End Try
    End Sub

    Private Sub PcdCsnTetVndGerMcd(ByVal sCodSup As String)
        Dim oObeCsnTotStaItf As New VAK019.BO_VAKCsnRep
        Dim sVlrRet As String
        Try
            sVlrRet = oObeCsnTotStaItf.CsnTetGerMcd(sCodSup)
            'Se tiver true a função coloca a primeira opção como "TODOS"
            Me.LstTet.DataSource = Session("objVAKUtl").funXMLArray(sVlrRet, True)
            Me.LstTet.DataBind()
        Catch oObeEcc As Exception
            Response.Write(Session("objVAKUtl").funSetErr(oObeEcc.Message))
            'MsgBox.Text = oObeEcc.Message
        Finally
            If Not oObeCsnTotStaItf Is Nothing Then
                oObeCsnTotStaItf = Nothing
            End If
        End Try
    End Sub
    Private Sub PcdCsnDdoRep(ByVal sNumReq As String, ByVal sNomRep As String, ByVal sNumCpf As String, ByVal sCodSta As String, ByVal sCodTet As String, ByVal sCodGerVnd As String, ByVal sCodGerMcd As String, ByVal sDatIniSlc As String, ByVal sDatFimSlc As String)
        Dim oObeItf As New VAK019.BO_VAKCsnRep
        Dim sVlrErr As String
        Dim sVlrRet As String
        'Objeto para transformacao de String em xml
        Dim oObeLetTxt As System.IO.StringReader
        'Resultado das pesquisas de acao, fornecedor, comprador ...
        Dim oGrpDdo As DataSet

        Try
            sVlrRet = oObeItf.CsnDdoRep(sNumReq, sNomRep, sNumCpf, sCodSta, sCodTet, sCodGerVnd, sCodGerMcd, sDatIniSlc, sDatFimSlc)
            oObeLetTxt = New System.IO.StringReader(sVlrRet)
            oGrpDdo = New DataSet
            oGrpDdo.ReadXml(oObeLetTxt)
            If (oGrpDdo.Tables(0).Rows.Count > 0) Then
                'Me.GrpDdoRep.DataSource = oGrpDdo.Tables(0)
                'Me.GrpDdoRep.DataBind()
                Me.Session("xml") = oGrpDdo.Tables(0)
                bindDataGrid(Me.Session("sortColumn"))
            Else
                Response.Write(Session("objVAKUtl").funSetErr("Nenhum registro foi encontrado para o filtro especificado!"))
                Me.GrpDdoRep.DataSource = Nothing
                Me.GrpDdoRep.DataBind()
            End If
            'End If
        Catch oObeEcc As Exception
            Response.Write(Session("objVAKUtl").funSetErr(oObeEcc.Message.ToString.Replace(Chr(10), "")))
            'MsgBox.Text = oObeEcc.Message
        Finally
            If Not oObeItf Is Nothing Then
                oObeItf = Nothing
            End If
        End Try
    End Sub
#End Region

    Private Sub GrpDdoRep_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrpDdoRep.EditCommand
        Session("objVAKUtl").pprNumReqCttRep = GrpDdoRep.Items(e.Item.ItemIndex).Cells(2).Text
        Response.Redirect("DocVAKDetRep.aspx#Csn")
    End Sub

    Private Sub NomRep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NomRep.TextChanged
        Me.NomRep.Text = Session("objVAKUtl").FunVldTxt(Me.NomRep.Text)
    End Sub

    Private Sub NumCpf_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumCpf.TextChanged
        Dim sAuxCpf As String
        If NumCpf.Text.Trim <> "" Then
            sAuxCpf = Session("objVAKUtl").funTiraMascara(NumCpf.Text.Trim)
            NumCpf.Text = Session("objVAKUtl").funMascaraCPF(sAuxCpf)
            If Not Session("objVAKUtl").funVerificaCPF(NumCpf.Text.Trim) Then
                MsgBox.Text = "CPF inválido!"
                NumCpf.Text = ""
            End If
        End If
    End Sub

    Private Sub GrpDdoRep_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles GrpDdoRep.SortCommand
        'Limpar imagem do cabeçalho
        Session("objVAKUtl").funGrpDdoClearImage(Me.GrpDdoRep, Me.Session("sortColumn"))

        If Me.Session("sortColumn") = e.SortExpression Then
            Me.Session("sortOrder") = Not Me.Session("sortOrder")
        Else
            Me.Session("sortColumn") = e.SortExpression
            Me.Session("sortOrder") = True
        End If

        If Me.Session("sortOrder") Then
            Session("objVAKUtl").funGrpDdoPutImage(Me.GrpDdoRep, Me.Session("sortColumn"), "ASC")
        Else
            Session("objVAKUtl").funGrpDdoPutImage(Me.GrpDdoRep, Me.Session("sortColumn"), "DESC")
        End If
        bindDataGrid(Me.Session("sortColumn"))
    End Sub

    Private Sub DesDatIniSlc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DesDatIniSlc.TextChanged
        Dim sAuxData As String
        If CType(sender, TextBox).Text.Trim <> "" Then
            sAuxData = Session("objVAKUtl").funValidaData(CType(sender, TextBox).Text.Trim)
            If sAuxData = "" Then
                CType(sender, TextBox).Text = ""
                MsgBox.Text = "Data Inválida"
                DatIniSlc.SelectedDate = Nothing
            Else
                DatIniSlc.SelectedDate = sAuxData
            End If
        End If
    End Sub

    Private Sub DatIniSlc_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatIniSlc.DateChanged
        DesDatIniSlc.Text = Format(DatIniSlc.SelectedDate, "dd/MM/yyyy")
    End Sub

    Private Sub DesDatFimSlc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesDatFimSlc.TextChanged
        Dim sAuxData As String
        If CType(sender, TextBox).Text.Trim <> "" Then
            sAuxData = Session("objVAKUtl").funValidaData(CType(sender, TextBox).Text.Trim)
            If sAuxData = "" Then
                CType(sender, TextBox).Text = ""
                MsgBox.Text = "Data Inválida"
                DatFimSlc.SelectedDate = Nothing
            Else
                DatFimSlc.SelectedDate = sAuxData
            End If
        End If
    End Sub

    Private Sub DatFimSlc_DateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatFimSlc.DateChanged
        DesDatFimSlc.Text = Format(DatFimSlc.SelectedDate, "dd/MM/yyyy")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preenche o quadro de resultado de pesquisa de RCA.
    ''' </summary>
    ''' <param name="sortField">Parametro opcional para ordenacao.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Getulio de Morais Pereira]	1/3/2005	Introducao de trecho de codigo-fonte para formatacao do CPF.
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub bindDataGrid(Optional ByVal sortField As String = "NUMREQCADREP")
        Dim oLetTxt As System.IO.StringReader
        Dim oGrpDdo As DataSet = New DataSet
        Dim oGrpDdoVis As DataView = New DataView

        oGrpDdoVis = CType(Me.Session("xml"), DataTable).DefaultView
        If sortField = "DESCOP" Then
            Me.Session("sortColumn") = "NUMREQCADREP"
            sortField = "NUMREQCADREP"
        End If
        oGrpDdoVis.Sort = sortField + IIf(Me.Session("sortOrder"), " ASC", " DESC")

        ' Preenchimento de quadro de exibicao da consulta de RCAs
        Me.GrpDdoRep.DataSource = oGrpDdoVis
        Dim i As Integer = 0
        Dim aux As String
        For i = 0 To oGrpDdoVis.Table.Rows.Count - 1
            aux = oGrpDdoVis.Table.Rows(i)("NUMCPFREP").trim
            If aux.Length = 11 Then
                aux = Session("objVAKUtl").funMascaraCPF(aux)
                oGrpDdoVis.Table.Rows(i)("NUMCPFREP") = aux
            End If
        Next
        aux = Nothing
        i = Nothing

        Me.GrpDdoRep.DataBind()
    End Sub
    Private Sub GrpDdoRep_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrpDdoRep.PageIndexChanged
        Me.GrpDdoRep.CurrentPageIndex = e.NewPageIndex
        bindDataGrid(Me.Session("sortColumn"))
    End Sub
End Class
