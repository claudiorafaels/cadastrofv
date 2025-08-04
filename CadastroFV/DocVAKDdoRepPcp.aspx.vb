Imports Microsoft.ApplicationBlocks.ExceptionManagement
Imports System.Configuration.ConfigurationSettings

' /**
'  * Alteracoes:
'  * . Funcao : VerificaPreenchimento()
'  *            . Data : 13/12/2004
'  *            . Autor : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
'  *            . Adicao de trecho de codigo para verificacao do preenchimento de campos obrigatorios
'  *              [nome, data de nascimento, quantidade de filhos] na aba Conjuge.
'  *            
'  */
Public Class DocVAKDdoRepPcp
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label33 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox25 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label34 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox20 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox19 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label31 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox18 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    Protected WithEvents GrpDdoStaFlu As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DatEft As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitDatEft As System.Web.UI.WebControls.Label
    Protected WithEvents DatSlc As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitDatSlc As System.Web.UI.WebControls.Label
    Protected WithEvents NomOpn As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitOpn As System.Web.UI.WebControls.Label
    Protected WithEvents LstFlu As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitFlu As System.Web.UI.WebControls.Label
    Protected WithEvents RspPrxAco As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitRspPrxAco As System.Web.UI.WebControls.Label
    Protected WithEvents NomSta As System.Web.UI.WebControls.Label
    Protected WithEvents TitSta As System.Web.UI.WebControls.Label
    Protected WithEvents NumReq As System.Web.UI.WebControls.Label
    Protected WithEvents TitNumReq As System.Web.UI.WebControls.Label
    Protected WithEvents LstSgmMcd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitSgmMcd As System.Web.UI.WebControls.Label
    Protected WithEvents NumCel As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCel As System.Web.UI.WebControls.Label
    Protected WithEvents NumFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitFax As System.Web.UI.WebControls.Label
    Protected WithEvents LstSitTlf As System.Web.UI.WebControls.DropDownList
    Protected WithEvents NumTlf As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitTlf As System.Web.UI.WebControls.Label
    Protected WithEvents LstVtg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LstRsi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitRsi As System.Web.UI.WebControls.Label
    Protected WithEvents TitCep As System.Web.UI.WebControls.Label
    Protected WithEvents TitEnd As System.Web.UI.WebControls.Label
    Protected WithEvents LstCplBai As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitCpl As System.Web.UI.WebControls.Label
    Protected WithEvents TitBai As System.Web.UI.WebControls.Label
    Protected WithEvents TitCid As System.Web.UI.WebControls.Label
    Protected WithEvents LstEst As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEst As System.Web.UI.WebControls.Label
    Protected WithEvents TitEcl As System.Web.UI.WebControls.Label
    Protected WithEvents LstEstCvl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEstCvl As System.Web.UI.WebControls.Label
    Protected WithEvents TitDatNsc As System.Web.UI.WebControls.Label
    Protected WithEvents LstEstCshReg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEstCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents TitOrgEms As System.Web.UI.WebControls.Label
    Protected WithEvents TitCrtIdt As System.Web.UI.WebControls.Label
    Protected WithEvents TitCpf As System.Web.UI.WebControls.Label
    Protected WithEvents TitNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents NomGerMcd As System.Web.UI.WebControls.Label
    Protected WithEvents TitGerMcd As System.Web.UI.WebControls.Label
    Protected WithEvents NomGerVnd As System.Web.UI.WebControls.Label
    Protected WithEvents TitGerVnd As System.Web.UI.WebControls.Label
    Protected WithEvents DesMsgRepTrbMrt As System.Web.UI.WebControls.Label
    Protected WithEvents LnkBtnDdoFlu As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoRep As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnTetVnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnOpnEtv As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnPnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents PnlOpnEtv As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlDdoRep As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlDdoCjg As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlPnd As System.Web.UI.WebControls.Panel
    Protected WithEvents LnkBtnDdoBco As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoCjg As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DatNsc As eWorld.UI.CalendarPopup
    Protected WithEvents Calendarpopup2 As eWorld.UI.CalendarPopup
    Protected WithEvents DesOrgEms As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitInss As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumInss As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents TitDatCadCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents DatCadCshReg As eWorld.UI.CalendarPopup
    Protected WithEvents TitSitCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents DesEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitRstQld As System.Web.UI.WebControls.Label
    Protected WithEvents TitRstQde As System.Web.UI.WebControls.Label
    Protected WithEvents TitNomCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNomCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumCrtIdtCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCrtIdtCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitOrgEmsCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesOrgEmsCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumFlhCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumFlhCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitDatNscCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DatNscCjg As eWorld.UI.CalendarPopup
    Protected WithEvents TitUndNgc As System.Web.UI.WebControls.Label
    Protected WithEvents btnIsr As System.Web.UI.WebControls.Button
    Protected WithEvents DesNumCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgOrgEms As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEstCvl As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEst As System.Web.UI.WebControls.Image
    Protected WithEvents ImgCplBai As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEnd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgCep As System.Web.UI.WebControls.Image
    Protected WithEvents ImgRsi As System.Web.UI.WebControls.Image
    Protected WithEvents ImgVtg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNomCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumFlhCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgDatNscCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgGerVnd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgGerMcd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgDatNsc As System.Web.UI.WebControls.Image
    Protected WithEvents MsgBoxWeb As VAK016.Web.MessageBoxWeb
    Protected WithEvents GrpDdoAvl As System.Web.UI.WebControls.DataGrid
    Protected WithEvents GrpDdoRstQde As System.Web.UI.WebControls.DataGrid
    Protected WithEvents GrpDdoCtn As System.Web.UI.WebControls.DataGrid
    Protected WithEvents IdtPrbSrs As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents IdtAcePnd As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents IdtVldCpf As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents MsgRstAvl As System.Web.UI.WebControls.Label
    Protected WithEvents ImgRstAvl As System.Web.UI.WebControls.Image
    Protected WithEvents MsgRstCtn As System.Web.UI.WebControls.Label
    Protected WithEvents ImgRstCtn As System.Web.UI.WebControls.Image
    Protected WithEvents RblVldCpf As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitVldCpf As System.Web.UI.WebControls.Label
    Protected WithEvents DesAcoTrb As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitAcoTrb As System.Web.UI.WebControls.Label
    Protected WithEvents RblAcePnd As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitAcePnd As System.Web.UI.WebControls.Label
    Protected WithEvents DesPrbSrs As System.Web.UI.WebControls.TextBox
    Protected WithEvents RblPrbSrs As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitPrbSrs As System.Web.UI.WebControls.Label
    Protected WithEvents txtJaEnviou As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatNsc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatCadCshReg As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatNscCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgSgmMcd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumCrtIdtCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgOrgEmsCjg As System.Web.UI.WebControls.Image
    Protected WithEvents LstSitFax As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RadBtnSex As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ImgSex As System.Web.UI.WebControls.Image
    Protected WithEvents TitSex As System.Web.UI.WebControls.Label
    Protected WithEvents TitNac As System.Web.UI.WebControls.Label
    Protected WithEvents ImgNomRep As System.Web.UI.WebControls.Image
    Protected WithEvents DesNomRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgEcl As System.Web.UI.WebControls.Image
    Protected WithEvents LstCplEcl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents NumGraEcl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ImgNac As System.Web.UI.WebControls.Image
    Protected WithEvents DesNac As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgNumCpf As System.Web.UI.WebControls.Image
    Protected WithEvents DesNumCpf As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgNumCrtIdt As System.Web.UI.WebControls.Image
    Protected WithEvents DesNumCrtIdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesCshReg As System.Web.UI.WebControls.TextBox
    Protected WithEvents LstSitCshReg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ImgCid As System.Web.UI.WebControls.Image
    Protected WithEvents LstCid As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ImgBai As System.Web.UI.WebControls.Image
    Protected WithEvents LstNomBai As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LstUndNgc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ImgUndNgc As System.Web.UI.WebControls.Image
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNomTet As System.Web.UI.WebControls.Label
    Protected WithEvents lblNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents txtVlrVndTre As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMesTre As System.Web.UI.WebControls.Label
    Protected WithEvents txtVlrVndDois As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMesDois As System.Web.UI.WebControls.Label
    Protected WithEvents txtVlrVndUm As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMesUm As System.Web.UI.WebControls.Label
    Protected WithEvents btnCsnTet As System.Web.UI.WebControls.Button
    Protected WithEvents txtTetVnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumBco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumAge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumCtaCrr As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgNomBco As System.Web.UI.WebControls.Image
    Protected WithEvents ImgAgeBco As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumCntCrr As System.Web.UI.WebControls.Image
    Protected WithEvents ImgVlrVndTet As System.Web.UI.WebControls.Image
    Protected WithEvents btnCsnBco As System.Web.UI.WebControls.Button
    Protected WithEvents lblNomBco As System.Web.UI.WebControls.Label
    Protected WithEvents btnCsnAge As System.Web.UI.WebControls.Button
    Protected WithEvents lblNomAge As System.Web.UI.WebControls.Label
    Protected WithEvents csnCep As System.Web.UI.WebControls.Button
    Protected WithEvents btnDesativar As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private GrpDdoVlrVnd As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtNumBco.Attributes.Add("onBlur", "javascript:__doPostBack('btnCsnBco');")
        Me.txtNumAge.Attributes.Add("onBlur", "javascript:__doPostBack('btnCsnAge','');")
        Me.txtTetVnd.Attributes.Add("onBlur", "javascript:__doPostBack('btnCsnTet','');")
        Me.DesNumCep.Attributes.Add("onBlur", "javascript:__doPostBack('csnCep','');")

        'Response.Write(System.Threading.Thread.CurrentThread.CurrentCulture.ToString)
        'Verifica login
        If (Session("TipRep") <> "GM") Then
            Session("CodErr") = "1"
            Response.Redirect("DocVAKVldUsr.aspx")
        End If

        Response.Write(Session("objVAKUtl").funSetErr("INICAD"))
        If Not IsPostBack Then
            Session("objVAKUtl").funLimpaObj()
            CsnTotDdoRep()
        End If

        'O campo "unidade de negócio" está sendo retirado do formulário. Gravará fixo 1.
        TitUndNgc.Visible = False
        LstUndNgc.Visible = False
        ImgUndNgc.Visible = False
    End Sub

    Private Sub CsnTotDdoRep()
        Dim sLstEst, sLstBco, sLstSgmMcd, sLstGerVnd, sLstCtn, sLstAvl As String
        Dim sLstTet, sUltMes, sVlrVndTet, sVlrErr As String
        Dim AuxRow As DataRow

        Try
            OcultaImagens()
            Esconde_Panel()
            SetStyle(Me.PnlDdoRep)
            DesNumCpf.Attributes.Add("onkeypress", "FormataCpf('DesNumCpf',11,event)")
            DesNumCep.Attributes.Add("onkeypress", "FormataCep('DesNumCep',10,event)")
            NumTlf.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            NumFax.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            NumCel.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            DesNumFlhCjg.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            DesNumInss.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            DesDatNsc.Attributes.Add("onkeypress", "FormataData('DesDatNsc',event)")
            DesDatCadCshReg.Attributes.Add("onkeypress", "FormataData('DesDatCadCshReg',event)")
            DesDatNscCjg.Attributes.Add("onkeypress", "FormataData('DesDatNscCjg',event)")
            txtTetVnd.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            Me.txtNumAge.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            Me.txtNumBco.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            Me.txtNumCtaCrr.Attributes.Add("onkeypress", "TeclaNumTraco(event)")
            'Pega o código do GM
            Session("objVAKUtl").pprCodGerMcd = Session("CodRep")

            If InfCadRep_Load(Session("objVAKUtl").pprCodGerMcd, Nothing, sLstBco, sLstSgmMcd, sLstGerVnd, sLstCtn, sLstAvl, sLstTet, sUltMes, sVlrVndTet, sVlrErr) Then
                Session("objVAKUtl").pprGrpDdoEst = Nothing
                Session("objVAKUtl").pprGrpDdoBco = Nothing
                Session("objVAKUtl").pprGrpDdoSgmMcd = Nothing
                Session("objVAKUtl").pprGrpDdoGerVnd = Nothing
                Session("objVAKUtl").pprGrpDdoAvl = Nothing
                Session("objVAKUtl").pprGrpDdoCtn = Nothing
                Session("objVAKUtl").pprGrpDdoTet = Nothing
                Session("objVAKUtl").pprGrpDdoUltMes = Nothing
                Session("objVAKUtl").pprGrpDdoVlrVndTet = Nothing

                'Session("objVAKUtl").pprGrpDdoEst = Session("objVAKUtl").funXMLToDataSet(sLstEst, 0, 0, "C")
                Session("objVAKUtl").pprGrpDdoBco = Session("objVAKUtl").funXMLToDataSet(sLstBco, 0, 1, "D")
                Session("objVAKUtl").pprGrpDdoSgmMcd = Session("objVAKUtl").funXMLToDataSet(sLstSgmMcd, 0, 1, "D")
                Session("objVAKUtl").pprGrpDdoGerVnd = Session("objVAKUtl").funXMLDS(sLstGerVnd)
                Session("objVAKUtl").pprGrpDdoAvl = Session("objVAKUtl").funXMLDS(sLstAvl)
                Session("objVAKUtl").pprGrpDdoCtn = Session("objVAKUtl").funXMLDS(sLstCtn)
                Session("objVAKUtl").pprGrpDdoTet = Session("objVAKUtl").funXMLToDataSet(sLstTet, 0, 1, "C")
                Session("objVAKUtl").pprGrpDdoUltMes = Session("objVAKUtl").funXMLDS(sUltMes)
                Session("objVAKUtl").pprGrpDdoVlrVndTet = Session("objVAKUtl").funXMLDS(sVlrVndTet)
            Else : Throw New Exception(sVlrErr)
            End If

            'Carrega Informações Estados
            'If Not VAKUtl.pprGrpDdoEst Is Nothing Then
            '    'Carrega lista de estados core
            '    LstEstCshReg.DataSource = VAKUtl.pprGrpDdoEst.Tables(0)
            '    LstEstCshReg.DataValueField = VAKUtl.pprGrpDdoEst.Tables(0).Columns(0).ColumnName
            '    LstEstCshReg.DataTextField = VAKUtl.pprGrpDdoEst.Tables(0).Columns(0).ColumnName
            '    LstEstCshReg.Items.Add("")
            '    LstEstCshReg.DataBind()
            '    'Carrega lista de estados
            '    LstEst.DataSource = VAKUtl.pprGrpDdoEst.Tables(0)
            '    LstEst.DataValueField = VAKUtl.pprGrpDdoEst.Tables(0).Columns(0).ColumnName
            '    LstEst.DataTextField = VAKUtl.pprGrpDdoEst.Tables(0).Columns(0).ColumnName
            '    LstEst.Items.Add("")
            '    LstEst.DataBind()
            'End If

            'Carrega informações Segmentos de Mercado
            If Not Session("objVAKUtl").pprGrpDdoSgmMcd Is Nothing Then
                'Insere registro vazio
                AuxRow = Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).NewRow
                AuxRow("CODSGMMCD") = -1
                AuxRow("DESSGMMCD") = ""
                Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).Rows.Add(AuxRow)
                Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).DefaultView.Sort = "DESSGMMCD"

                LstSgmMcd.DataSource = Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).DefaultView
                LstSgmMcd.DataValueField = Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).Columns(0).ColumnName
                LstSgmMcd.DataTextField = Session("objVAKUtl").pprGrpDdoSgmMcd.Tables(0).Columns(1).ColumnName
                LstSgmMcd.DataBind()
            End If

            'Carrega informações Gerente de Vendas e Gerente de Mercado
            If Not Session("objVAKUtl").pprGrpDdoGerVnd Is Nothing Then
                Session("objVAKUtl").pprNomGerMcd = Session("objVAKUtl").pprGrpDdoGerVnd.Tables(0).Rows.Item(0)(0).ToString.Trim
                NomGerMcd.Text = Session("objVAKUtl").pprCodGerMcd & " - " & Session("objVAKUtl").pprNomGerMcd
                Session("objVAKUtl").pprCodGerVnd = Session("objVAKUtl").pprGrpDdoGerVnd.Tables(0).Rows.Item(0)(1).ToString.Trim
                Session("objVAKUtl").pprNomGerVnd = Session("objVAKUtl").pprGrpDdoGerVnd.Tables(0).Rows.Item(0)(2).ToString.Trim
                NomGerVnd.Text = Session("objVAKUtl").pprCodGerVnd & " - " & Session("objVAKUtl").pprNomGerVnd
            End If

            'Carrega informações do Banco
            If Not Session("objVAKUtl").pprGrpDdoBco Is Nothing Then
                'Insere registro vazio
                AuxRow = Session("objVAKUtl").pprGrpDdoBco.Tables(0).NewRow
                AuxRow("CODBCO") = -1
                AuxRow("NOMBCO") = ""
                Session("objVAKUtl").pprGrpDdoBco.Tables(0).Rows.Add(AuxRow)
                Session("objVAKUtl").pprGrpDdoBco.Tables(0).DefaultView.Sort = "NOMBCO"

                'LstNomBco.DataSource = Session("objVAKUtl").pprGrpDdoBco.Tables(0).DefaultView
                'LstNomBco.DataValueField = Session("objVAKUtl").pprGrpDdoBco.Tables(0).Columns(0).ColumnName
                'LstNomBco.DataTextField = Session("objVAKUtl").pprGrpDdoBco.Tables(0).Columns(1).ColumnName
                'LstNomBco.Items.Add("")
                'LstNomBco.DataBind()
                'AgeBco_Sel()
            End If

            ' ---------------------------------------------------------------------
            ' Carrega informações Valor Venda Territorio
            ' ---------------------------------------------------------------------
            ' Formata os valores segundo o padrao numerico "Portugues do Brasil"
            'Dim aux_1, aux_2, aux_3 As String
            'For i As Int16 = 0 To VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows.Count - 1
            '    aux_1 = VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP1").ToString
            '    aux_2 = VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP2").ToString
            '    aux_3 = VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP3").ToString
            '    VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP1") = VAKUtl.funFrmNum(aux_1)
            '    VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP2") = VAKUtl.funFrmNum(aux_2)
            '    VAKUtl.pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP3") = VAKUtl.funFrmNum(aux_3)
            'Next
            ' Formata os valores segundo o padrao numerico "Portugues do Brasil"
            'Dim aux_1, aux_2, aux_3 As Double
            'For i As Int16 = 0 To Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows.Count - 1
            '    aux_1 = CType(Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP1"), Double)
            '    aux_2 = CType(Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP2"), Double)
            '    aux_3 = CType(Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP3"), Double)
            '    Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP1") = Session("objVAKUtl").funFrmNum(CStr(aux_1))
            '    Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP2") = Session("objVAKUtl").funFrmNum(CStr(aux_2))
            '    Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).Rows(i).Item("VLRCMP3") = Session("objVAKUtl").funFrmNum(CStr(aux_3))
            'Next
            'GrpDdoVlrVnd.DataSource = Session("objVAKUtl").pprGrpDdoVlrVndTet.Tables(0).DefaultView
            'GrpDdoVlrVnd.DataBind()  REM Preenche a tabela com os valores obtidos do DB
            'GrpDdoVlrVnd.Visible = True
            'Dim linha As DataRow
            'If Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows.Count > 0 Then
            '    GrpDdoVlrVnd.Columns(5).HeaderText = CType(Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(1), String).PadLeft(2, "0") & "/" & Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(0)
            '    GrpDdoVlrVnd.Columns(6).HeaderText = CType(Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(3), String).PadLeft(2, "0") & "/" & Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(2)
            '    GrpDdoVlrVnd.Columns(7).HeaderText = CType(Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(5), String).PadLeft(2, "0") & "/" & Session("objVAKUtl").pprGrpDdoUltMes.Tables(0).Rows(0)(4)
            '    GrpDdoVlrVnd.DataBind()  REM Preenche a tabela com os valores obtidos do DB
            '    GrpDdoVlrVnd.Visible = True
            'Else
            '    GrpDdoVlrVnd.Visible = False
            'End If

            'Resultado qualitativo (competência)
            If Not Session("objVAKUtl").pprGrpDdoAvl Is Nothing Then
                GrpDdoAvl.DataSource = Session("objVAKUtl").pprGrpDdoAvl.Tables(0).DefaultView
                GrpDdoAvl.DataBind()
                GrpDdoAvl.Visible = True
            End If
            If Not Session("objVAKUtl").pprGrpDdoCtn Is Nothing Then
                GrpDdoCtn.DataSource = Session("objVAKUtl").pprGrpDdoCtn.Tables(0).DefaultView
                GrpDdoCtn.DataBind()
                GrpDdoCtn.Visible = True
            End If


        Catch oErr As Exception
            Err(oErr.Message)
        End Try

    End Sub

    Private Sub LnkBtnDdoFlu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnDdoFlu.Click
        Esconde_Panel()
        SetStyle(Me.PnlDdoFlu)
    End Sub

    Private Sub LnkBtnDdoRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnDdoRep.Click
        Esconde_Panel()
        SetStyle(Me.PnlDdoRep)
    End Sub

    Private Sub LnkBtnDdoCjg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnDdoCjg.Click
        Esconde_Panel()
        SetStyle(Me.PnlDdoCjg)
    End Sub

    Private Sub LnkBtnOpnEtv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnOpnEtv.Click
        Esconde_Panel()
        SetStyle(Me.PnlOpnEtv)
    End Sub

    Private Sub LnkBtnPnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnPnd.Click
        Esconde_Panel()
        SetStyle(Me.PnlPnd)
    End Sub

    Private Sub Esconde_Panel()
        Me.PnlDdoFlu.Visible = False
        Me.PnlDdoRep.Visible = False
        Me.PnlDdoCjg.Visible = False
        Me.PnlOpnEtv.Visible = False
        Me.PnlPnd.Visible = False
    End Sub

    Private Sub SetStyle(ByRef Pnl As Panel)
        With Pnl
            .Attributes.CssStyle.Remove("TOP")
            .Attributes.CssStyle.Remove("LEFT")
            .Attributes.CssStyle.Remove("POSITION")
            .CssClass = "ativa"
            .Visible = True
        End With
    End Sub

    Private Sub Err(ByVal s As String)
        Response.Write(Session("objVAKUtl").funSetErr(s))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sCodSup"></param>
    ''' <param name="sLstEst">Lista dos Estados</param>
    ''' <param name="sLstBco">Lista dos Bancos cadastrados</param>
    ''' <param name="sLstSgmMcd">Lista dos Segmentos de Mercado</param>
    ''' <param name="sLstGerVnd">Lista dos Gerentes de Vendas</param>
    ''' <param name="sLstCtn">Lista das Competencias</param>
    ''' <param name="sLstAvl">Lista das Avaliacoes</param>
    ''' <param name="sLstTet">Lista dos Territorios</param>
    ''' <param name="sUltMes"></param>
    ''' <param name="sVlrVndTet"></param>
    ''' <param name="sErr"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Parametro sLstEst = nothing implica uso de dados estaticos (nao acessa o Banco de Dados).
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/2/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function InfCadRep_Load(ByVal sCodSup As String, _
      ByRef sLstEst As String, ByRef sLstBco As String, _
      ByRef sLstSgmMcd As String, ByRef sLstGerVnd As String, _
      ByRef sLstCtn As String, ByRef sLstAvl As String, ByRef sLstTet As String, _
      ByRef sUltMes As String, ByRef sVlrVndTet As String, ByRef sErr As String) As Boolean
        Try
            Dim oObeCsnInfCadRepItf As New VAK019.BO_VAKCsnRep
            InfCadRep_Load = oObeCsnInfCadRepItf.CsnInfCadRep(sCodSup, Nothing, sLstBco, sLstSgmMcd, sLstGerVnd, sLstCtn, sLstTet, sUltMes, sVlrVndTet, sLstAvl)
        Catch oErr As Exception
            sErr = oErr.Message
            Err(oErr.Message)
            InfCadRep_Load = False
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega lista de Agencias Bancarias (list box).
    ''' </summary>
    ''' <param name="sCodBco">Codigo do banco correspondente.</param>
    ''' <returns>XML contendo o resultado da busca.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/2/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function AgeBco_Load(ByVal sCodBco As String) As String
        Try
            Dim oObeCsnAgeBcoItf As New VAK019.BO_VAKCsnRep
            AgeBco_Load = oObeCsnAgeBcoItf.CsnAgeBco(sCodBco)
        Catch oErr As Exception
            Err(oErr.Message)
            AgeBco_Load = "<xml></xml>"
        End Try
    End Function

    Private Sub AgeBco_Sel()
        'Dim oAuxDs As New DataSet
        'Dim oAuxRow
        'If LstNomBco.SelectedItem.Text <> "" Then
        '    oAuxDs = Nothing
        '    oAuxDs = Session("objVAKUtl").funXMLToDataSet(AgeBco_Load(LstNomBco.SelectedItem.Value), 0, 1, "3")
        '    If oAuxDs.Tables(0).Rows.Count > 0 Then

        '    End If
        'End If
    End Sub

    Private Sub lstNomBco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'AgeBco_Sel()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega lista (list box) de Cidades.
    ''' </summary>
    ''' <param name="sCodEst">Codigo do Estado correspondente.</param>
    ''' <returns>XML contendo resultado da busca.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/2/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function Cid_Load(ByVal sCodEst As String) As String
        Try
            Dim oObeCsnCidItf As New VAK019.BO_VAKCsnRep
            Cid_Load = oObeCsnCidItf.CsnCid(sCodEst)
        Catch oErr As Exception
            Err(oErr.Message)
            Cid_Load = "<xml></xml>"
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega lista de Bairros (list box).
    ''' </summary>
    ''' <param name="sCodCid">Codigo da cidade correspondente.</param>
    ''' <returns>XML contendo o resultado da busca.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/2/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function Bai_Load(ByVal sCodCid As String) As String
        Try
            Dim oObeCsnBaiItf As New VAK019.BO_VAKCsnRep
            Bai_Load = oObeCsnBaiItf.CsnBai(sCodCid)
        Catch oErr As Exception
            Err(oErr.Message)
            Bai_Load = "<xml></xml>"
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega lista de Complemento de Bairro (list box).
    ''' </summary>
    ''' <param name="sCodBai">Codigo do bairro correspondente.</param>
    ''' <returns>XML contendo o resultado da busca.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/2/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function CplBai_Load(ByVal sCodBai As String) As String
        Try
            Dim oObeCsnCplBaiItf As New VAK019.BO_VAKCsnRep
            CplBai_Load = oObeCsnCplBaiItf.CsnCplBai(sCodBai)
        Catch oErr As Exception
            Err(oErr.Message)
            CplBai_Load = "<xml></xml>"
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica se o candidato ja foi representante Martins.
    ''' </summary>
    ''' <param name="sNumCpf">Numero de CPF do candidato</param>
    ''' <param name="sIdtRepTrb"></param>
    ''' <param name="sRstPva">Dados dos resultados das provas</param>
    ''' <param name="sAcePnd">Dados de acertos pendentes</param>
    ''' <param name="sAcoTrb">Dados de acoes trabalhistas</param>
    ''' <param name="sIdtRepTrbTmp">Dados do cadastro do candidato</param>
    ''' <returns>TRUE, caso ja tenha sido representante Martins</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/22/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function InfRepCpf_Load(ByVal sNumCpf As String, ByRef sIdtRepTrb As String, ByRef sRstPva As String, ByRef sAcePnd As String, ByRef sAcoTrb As String, ByRef sIdtRepTrbTmp As String) As Boolean
        Try
            Dim oObeCsnInfRepCpfItf As New VAK019.BO_VAKCsnRep
            InfRepCpf_Load = oObeCsnInfRepCpfItf.CsnInfRepCpf(sNumCpf, sIdtRepTrb, sRstPva, sAcePnd, sAcoTrb, sIdtRepTrbTmp)
        Catch oErr As Exception
            Err(oErr.Message)
            InfRepCpf_Load = False
        End Try
    End Function


    Private Function InfRepCpfRpa_Load(ByVal sNumCpf As String, ByRef sMsgBlqOrdPgt As String, ByRef sMsgRboPgtPvtEde As String, ByRef sMsgInzPgo As String) As Boolean
        Try
            Dim oObeCsnInfRepCpfItf As New VAK019.BO_VAKCsnRep
            InfRepCpfRpa_Load = oObeCsnInfRepCpfItf.CsnInfRepCpfRpa(sNumCpf, sMsgBlqOrdPgt, sMsgRboPgtPvtEde, sMsgInzPgo)
        Catch oErr As Exception
            Err(oErr.Message)
            InfRepCpfRpa_Load = False
        End Try
    End Function


    Public Sub lstEst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstEst.SelectedIndexChanged
        'Dim oAuxDs As New DataSet
        'Dim oAuxRow As DataRow
        'LstCid.DataSource = Nothing
        'LstCid.Items.Clear()
        'If LstEst.SelectedItem.Text <> "" Then
        '    oAuxDs = Nothing
        '    oAuxDs = Session("objVAKUtl").funXMLToDataSet(Cid_Load(LstEst.SelectedItem.Text), 0, 1, "D")
        '    If oAuxDs.Tables(0).Rows.Count > 0 Then
        '        'Insere registro vazio
        '        oAuxRow = oAuxDs.Tables(0).NewRow
        '        oAuxRow("CODCID") = -1
        '        oAuxRow("NOMCID") = ""
        '        oAuxDs.Tables(0).Rows.Add(oAuxRow)
        '        oAuxDs.Tables(0).DefaultView.Sort = "NOMCID"

        '        'Carrega lista de cidades do estado
        '        LstCid.DataSource = oAuxDs.Tables(0).DefaultView
        '        LstCid.DataValueField = oAuxDs.Tables(0).Columns(0).ColumnName
        '        LstCid.DataTextField = oAuxDs.Tables(0).Columns(1).ColumnName
        '        LstCid.Items.Add("")
        '        LstCid.DataBind()
        '    End If
        'End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preenche os combos da cidade e do estado da união
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	15/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AbsLstCidEstUni()

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preenche o combo dos bairros da cidade
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[????????]	??/?/200?	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub AbsLstBai()
        Dim oAuxDs As New DataSet
        Dim oAuxRow As DataRow
        LstNomBai.DataSource = Nothing
        LstNomBai.Items.Clear()
        If LstCid.SelectedItem.Text <> "" Then
            oAuxDs = Nothing
            oAuxDs = Session("objVAKUtl").funXMLToDataSet(Bai_Load(LstCid.SelectedItem.Value), 0, 1, "D")
            If oAuxDs.Tables(0).Rows.Count > 0 Then
                'Insere registro vazio
                oAuxRow = oAuxDs.Tables(0).NewRow
                oAuxRow("CODBAI") = -1
                oAuxRow("NOMBAI") = ""
                oAuxDs.Tables(0).Rows.Add(oAuxRow)
                oAuxDs.Tables(0).DefaultView.Sort = "NOMBAI"

                'Carrega lista de bairros da cidade
                LstNomBai.DataSource = oAuxDs.Tables(0).DefaultView
                LstNomBai.DataValueField = oAuxDs.Tables(0).Columns(0).ColumnName
                LstNomBai.DataTextField = oAuxDs.Tables(0).Columns(1).ColumnName
                LstNomBai.Items.Add("")
                LstNomBai.DataBind()
            End If
        End If
    End Sub

    Private Sub lstNomBai_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oAuxDs As New DataSet
        Dim oAuxRow As DataRow
        LstCplBai.DataSource = Nothing
        LstCplBai.Items.Clear()
        If LstNomBai.SelectedItem.Text <> "" Then
            oAuxDs = Nothing
            oAuxDs = Session("objVAKUtl").funXMLToDataSet(CplBai_Load(LstNomBai.SelectedItem.Value), 0, 1, "D")
            If oAuxDs.Tables(0).Rows.Count > 0 Then
                'Insere registro vazio
                oAuxRow = oAuxDs.Tables(0).NewRow
                oAuxRow("CODCPLBAI") = -1
                oAuxRow("NOMCPLBAI") = ""
                oAuxDs.Tables(0).Rows.Add(oAuxRow)
                oAuxDs.Tables(0).DefaultView.Sort = "NOMCPLBAI"

                'Carrega lista de complemento de bairros da cidade
                LstCplBai.DataSource = oAuxDs.Tables(0)
                LstCplBai.DataValueField = oAuxDs.Tables(0).Columns(0).ColumnName
                LstCplBai.DataTextField = oAuxDs.Tables(0).Columns(1).ColumnName
                LstCplBai.Items.Add("")
                LstCplBai.DataBind()
            End If

            'Me.DesEnd.Text = Me.LstNomBai.SelectedItem.Text.Substring(0, Me.LstNomBai.SelectedItem.Text.LastIndexOf("-"))
        End If
    End Sub

    Private Sub DesNumCpf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesNumCpf.TextChanged
        Dim oAuxDs As New DataSet
        Dim BO As New VAK019.BO_VAKCsnRep
        Dim dsFncMrt As New DataSet
        Dim oAuxDsTmp As New DataSet
        Session("TrabalhouMartins") = False
        Dim sAuxCodRep, sAuxCpf, sAuxIdtRep, sAuxRstPva, sAuxAcePnd, sAuxAcoTrb, sAuxIdtRepTmp As String

        If DesNumCpf.Text.Trim <> "" Then
            sAuxCpf = Session("objVAKUtl").funTiraMascara(DesNumCpf.Text.Trim)
            DesNumCpf.Text = Session("objVAKUtl").funMascaraCPF(sAuxCpf)

           

            If Session("objVAKUtl").funVerificaCPF(DesNumCpf.Text.Trim) Then

             
                If InfRepCpf_Load(sAuxCpf, sAuxIdtRep, sAuxRstPva, sAuxAcePnd, sAuxAcoTrb, sAuxIdtRepTmp) Then

                    'Verifica se cpf existe na tabela temporária
                    oAuxDsTmp = Nothing
                    oAuxDsTmp = Session("objVAKUtl").funXMLDS(sAuxIdtRepTmp)
                    If Not oAuxDsTmp Is Nothing Then
                        If oAuxDsTmp.Tables(0).Rows.Count > 0 Then
                            MsgBoxWeb.Text = "Existe um documento para este CPF que está em aprovação. Não é possível continuar o cadastro."
                            MsgBoxWeb.Redirecionar = "DocVAKAutCtt.aspx"
                            Exit Sub
                        End If
                    End If

                    'Verficar se realizou as provas no formar
                    oAuxDs = Nothing
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxRstPva)
                    'PH - Suspensão temporária da verificação das provas do Formar, pois este ficará fora do ar por um período.
                    'If oAuxDs.Tables(0).Rows.Count = 0 Then
                    '    MsgBoxWeb.Text = "Candidato a representante ainda não realizou as provas no Formar. Não é possível continuar o cadastro."
                    '    MsgBoxWeb.Redirecionar = "DocVAKAutCtt.aspx"
                    '    Exit Sub
                    'End If

                    'Resultado da prova
                    Session("objVAKUtl").pprGrpDdoRstPva = oAuxDs
                    GrpDdoRstQde.DataSource = Session("objVAKUtl").pprGrpDdoRstPva
                    GrpDdoRstQde.DataBind()
                    GrpDdoRstQde.Visible = True

                    'Verifica se a nota e igual a zero
                    'PH - Suspensão temporária da verificação das provas do Formar, pois este ficará fora do ar por um período.
                    'If oAuxDs.Tables(0).Rows(0).Item(1) = 0 Or oAuxDs.Tables(0).Rows(1).Item(1) = 0 Then
                    '    ativaScript()
                    'End If

                    'Verifica se o representante ja trabalhou no Martins
                    oAuxDs = Nothing
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxIdtRep)
                    If oAuxDs.Tables(0).Rows.Count > 0 Then
                        sAuxCodRep = CType(oAuxDs.Tables(0).Rows(0)("CodRep"), String)

                        'Verifica se o representante ainda está ativo no Martins
                        If Convert.IsDBNull(oAuxDs.Tables(0).Rows(0)("DatDstRep")) Then
                            MsgBoxWeb.Text = "Representante está ativo no Martins. Não é possível continuar o cadastro."
                            MsgBoxWeb.Redirecionar = "DocVAKAutCtt.aspx"
                            Exit Sub
                        End If

                        'Acerto pendente
                        oAuxDsTmp = Nothing
                        oAuxDsTmp = Session("objVAKUtl").funXMLDS(sAuxAcePnd)
                        Session("objVAKUtl").pprGrpDdoAcePnd = oAuxDsTmp
                        'Verifica acertos pendentes
                        If Not Session("objVAKUtl").pprGrpDdoAcePnd Is Nothing Then
                            If Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows.Count > 0 Then
                                If (Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows(0)(0) <> "01/01/0001" And _
                                    Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows(0)(1) = "01/01/0001") Then
                                    RblAcePnd.SelectedValue = "1"
                                    MsgBoxWeb.Text = "Existem acertos pendentes para este representante. Não será possível prosseguir com o cadastro."
                                    MsgBoxWeb.Redirecionar = "DocVAKAutCtt.aspx"
                                    Exit Sub
                                Else
                                    RblAcePnd.SelectedValue = "0"
                                End If
                            Else
                                RblAcePnd.SelectedValue = "0"
                            End If
                        Else
                            RblAcePnd.SelectedValue = "0"
                        End If

                        'Identifica data que o representante trabalhou no Martins
                        'DesMsgRepTrbMrt.Text = "Este representante já trabalhou no Martins de " & _
                        '                       oAuxDs.Tables(0).Rows(0)("DatCadRep") & " ate " & oAuxDs.Tables(0).Rows(0)("DatDstRep")
                        DesMsgRepTrbMrt.Text = "Este candidato já prestou serviços à empresa. Por isso, sua contratação dependerá da aprovação da diretoria de vendas."

                        Session("TrabalhouMartins") = True

                        ' Gruarda mensagem para gravacao no fluxo [MRT.T0150610]
                        Session("objVAKUtl").pprMsgRep = " Observacao: este candidato ja foi representante Martins de " & _
                                                         oAuxDs.Tables(0).Rows(0)("DatCadRep") & " ate " & oAuxDs.Tables(0).Rows(0)("DatDstRep")

                        Dim sMsgBlqOrdPgt, sMsgRboPgtPvtEde, sMsgInzPgo As String
                        Dim sMsg As String
                        If InfRepCpfRpa_Load(sAuxCpf, sMsgBlqOrdPgt, sMsgRboPgtPvtEde, sMsgInzPgo) Then
                            If sMsgBlqOrdPgt <> "" Then
                                Session("objVAKUtl").pprMsgRep = Session("objVAKUtl").pprMsgRep & " " & sMsgBlqOrdPgt & vbNewLine
                                '527.220.406-97
                                DesMsgRepTrbMrt.Text = DesMsgRepTrbMrt.Text & "." & Chr(13) & sMsgBlqOrdPgt
                                'MsgBoxWeb.Text = sMsgBlqOrdPgt
                                'MsgBoxWeb.Redirecionar = "DocVAKDdoRepPcp.aspx"
                            End If
                            If sMsgRboPgtPvtEde <> "" Then
                                Session("objVAKUtl").pprMsgRep = Session("objVAKUtl").pprMsgRep & " " & sMsgRboPgtPvtEde & vbNewLine
                                DesMsgRepTrbMrt.Text = DesMsgRepTrbMrt.Text & Chr(13) & sMsgRboPgtPvtEde
                                'MsgBoxWeb.Text = sMsgRboPgtPvtEde
                                'MsgBoxWeb.Redirecionar = "DocVAKDdoRepPcp.aspx"
                            End If
                            If sMsgInzPgo <> "" Then
                                Session("objVAKUtl").pprMsgRep = Session("objVAKUtl").pprMsgRep & " " & sMsgInzPgo & vbNewLine
                                DesMsgRepTrbMrt.Text = DesMsgRepTrbMrt.Text & Chr(13) & sMsgInzPgo
                                'MsgBoxWeb.Text = sMsgInzPgo
                                'MsgBoxWeb.Redirecionar = "DocVAKDdoRepPcp.aspx"
                            End If
                        End If
                        DesMsgRepTrbMrt.Visible = True

                        'Preenche dados do representante
                        If Not PreencheDdoRepExr(sAuxCodRep) Then
                            Throw New Exception("Erro ao buscar informações do representante.")
                        End If

                        'Ações trabalhistas
                        oAuxDs = Nothing
                        oAuxDs = Session("objVAKUtl").funXMLDS(sAuxAcoTrb)
                        Session("objVAKUtl").pprGrpDdoAcoTrb = oAuxDs
                        'Verifica ações trabalhistas
                        If Not Session("objVAKUtl").pprGrpDdoAcoTrb Is Nothing Then
                            If Session("objVAKUtl").pprGrpDdoAcoTrb.Tables(0).Rows.Count > 0 Then
                                DesAcoTrb.Text = CType(Session("objVAKUtl").pprGrpDdoAcoTrb.Tables(0).Rows(0)(0), String).Trim
                            Else
                                DesAcoTrb.Text = ""
                            End If
                        Else
                            DesAcoTrb.Text = ""
                        End If
                    Else
                        DesMsgRepTrbMrt.Visible = False
                    End If
                End If
                If Session("TrabalhouMartins") = True Then
                    btnIsr.Attributes.Add("OnClick", "javascript:return confirm('Este candidato já prestou serviços à empresa. Por isso, sua contratação dependerá da aprovação da diretoria de vendas. Deseja enviar para aprovação?');")
                End If
                dsFncMrt = BO.CsnIdtRepFnc(sAuxCpf)
                If dsFncMrt.Tables("tblFncMrt").Rows.Count > 0 Then
                    btnIsr.Attributes.Add("OnClick", "javascript:return confirm('Este candidato já prestou serviços à empresa. Por isso, sua contratação dependerá da aprovação da diretoria de vendas. Deseja enviar para aprovação?');")
                    Session("TrabalhouMartins") = True
                    DesMsgRepTrbMrt.Text = DesMsgRepTrbMrt.Text & Chr(13) & "Este candidato já prestou serviços à empresa. Por isso, sua contratação dependerá da aprovação da diretoria de vendas."
                    DesMsgRepTrbMrt.Visible = True
                End If

            Else
                MsgBoxWeb.Text = "CPF inválido!"
                DesNumCpf.Text = ""
            End If
        Else
            DesMsgRepTrbMrt.Visible = False
            RblAcePnd.SelectedValue = "0"
            DesAcoTrb.Text = ""
        End If
    End Sub

#Region "--> Verifica Preenchimento"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Funcao para verificacao de campos de preenchimento obrigatorio.
    ''' </summary>
    ''' <returns>Valor booleano indicando ocorrencia ou nao de pelo menos um campo obrigatorio nao preenchido
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''    VerificaPreenchimento() <BR>
    '''          . Data : 13/12/2004 <BR>
    '''          . Autor : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br] <BR>
    '''          . Adicao de trecho de codigo para verificacao do preenchimento de campos obrigatorios <BR>
    '''            [nome, data de nascimento, quantidade de filhos] na aba Conjuge.
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function VerificaPreenchimento() As Boolean

        Dim iIndice As Integer
        Dim bSelecao, bVazio, bErro As Boolean

        bErro = False
        bVazio = False
        bSelecao = False

        '----------------------
        'DADOS DO REPRESENTANTE
        '----------------------
        'Gerente de Vendas
        If NomGerVnd.Text.Trim <> "" Then
            ImgGerVnd.Visible = False
        Else
            ImgGerVnd.Visible = True
            bErro = True
        End If
        'Gerente de Mercado
        If NomGerMcd.Text.Trim <> "" Then
            ImgGerMcd.Visible = False
        Else
            ImgGerMcd.Visible = True
            bErro = True
        End If
        'Nome 
        If DesNomRep.Text.Trim <> "" Then
            ImgNomRep.Visible = False
        Else
            ImgNomRep.Visible = True
            bErro = True
        End If
        'CPF
        If DesNumCpf.Text.Trim <> "" Then
            If Session("objVAKUtl").funVerificaCPF(DesNumCpf.Text.Trim) Then
                ImgNumCpf.Visible = False
            Else
                MsgBoxWeb.Text = "CPF inválido!"
                DesNumCpf.Text = ""
                ImgNumCpf.Visible = True
                bErro = True
            End If
        Else
            ImgNumCpf.Visible = True
            bErro = True
        End If
        'INSS
        If DesNumInss.Text.Trim <> "" Then
            If Not Session("objVAKUtl").funVerificaINSS(DesNumInss.Text.Trim) Then
                MsgBoxWeb.Text = "INSS inválido!"
                DesNumInss.Text = ""
                bErro = True
            End If
        End If
        'RG
        If DesNumCrtIdt.Text.Trim <> "" Then
            ImgNumCrtIdt.Visible = False
        Else
            ImgNumCrtIdt.Visible = True
            bErro = True
        End If
        'Orgão Emissor
        If DesOrgEms.Text.Trim <> "" Then
            ImgOrgEms.Visible = False
        Else
            ImgOrgEms.Visible = True
            bErro = True
        End If

        'Unidade de Negocio
        'O campo "unidade de negócio" está sendo retirado do formulário. Gravará fixo 1.
        'If LstUndNgc.SelectedValue.Trim <> "" Then
        '    ImgUndNgc.Visible = False
        'Else
        '    ImgUndNgc.Visible = True
        '    bErro = True
        'End If

        'Sexo
        If RadBtnSex.SelectedValue.Trim <> "" Then
            ImgSex.Visible = False
        Else
            ImgSex.Visible = True
            bErro = True
        End If
        'Data Nascimento
        If DesDatNsc.Text <> "" Then
            ImgDatNsc.Visible = False
        Else
            ImgDatNsc.Visible = True
            bErro = True
        End If
        'Nacionalidade
        If DesNac.Text.Trim <> "" Then
            ImgNac.Visible = False
        Else
            ImgNac.Visible = True
            bErro = True
        End If
        'Estado Civil
        If LstEstCvl.SelectedValue.Trim <> "" Then
            ImgEstCvl.Visible = False
        Else
            ImgEstCvl.Visible = True
            bErro = True
        End If
        'Grau Escolaridade e Complemento Escolaridade
        If NumGraEcl.SelectedValue.Trim <> "" And _
           LstCplEcl.SelectedValue.Trim <> "" Then
            ImgEcl.Visible = False
        Else
            ImgEcl.Visible = True
            bErro = True
        End If
        'Estado
        'If LstEst.SelectedValue.Trim <> "" Then
        If (Not LstEst Is Nothing) And (Not LstEst.SelectedValue.Trim.Equals(String.Empty)) Then
            ImgEst.Visible = False
        Else
            ImgEst.Visible = True
            bErro = True
        End If
        'Cidade
        'If LstCid.SelectedValue.Trim <> "" Then
        If (Not LstCid Is Nothing) And _
           (Not LstCid.SelectedValue.Trim.Equals(String.Empty)) And _
           (Not LstCid.SelectedValue.Trim.Equals("-1")) Then
            ImgCid.Visible = False
        Else
            ImgCid.Visible = True
            bErro = True
        End If

        'Bairro
        'If LstNomBai.SelectedValue.Trim <> "" Then
        If (Not LstNomBai Is Nothing) And _
           (Not LstNomBai.SelectedValue.Trim.Equals(String.Empty)) And _
           (Not LstNomBai.SelectedValue.Trim.Equals("-1")) Then
            ImgBai.Visible = False
        Else
            ImgBai.Visible = True
            bErro = True
        End If

        'Complemento de Bairro
        'If LstCplBai.SelectedValue.Trim <> "" Then
        '    ImgCplBai.Visible = False
        'Else
        '    ImgCplBai.Visible = True
        '    bErro = True
        'End If

        'Endereço
        'If DesEnd.Text.Trim <> "" Then
        If (Not DesEnd Is Nothing) And (Not DesEnd.Text.Trim.Equals(String.Empty)) And (DesEnd.Text.Trim <> "") Then
            ImgEnd.Visible = False
        Else
            ImgEnd.Visible = True
            bErro = True
        End If
        'Cep
        'If DesNumCep.Text.Trim <> "" Then
        If (Not DesNumCep Is Nothing) And (Not DesNumCep.Text.Trim.Equals(String.Empty)) Then
            ImgCep.Visible = False
        Else
            ImgCep.Visible = True
            bErro = True
        End If
        'Residencia
        If LstRsi.SelectedValue.Trim <> "" Then
            ImgRsi.Visible = False
        Else
            ImgRsi.Visible = True
            bErro = True
        End If
        'Voltagem
        If LstVtg.SelectedValue.Trim <> "" Then
            ImgVtg.Visible = False
        Else
            ImgVtg.Visible = True
            bErro = True
        End If
        'Segmento de mercado
        If LstSgmMcd.SelectedItem.Text.Trim <> "" Then
            ImgSgmMcd.Visible = False
        Else
            ImgSgmMcd.Visible = True
            bErro = True
        End If
        '-----------
        'Dados Banco
        '-----------
        'Banco 
        If Not (Me.lblNomBco.Text.Trim = "" Or Me.lblNomBco.Text.Trim = "Banco inexistente") Then
            ImgNomBco.Visible = False
        Else
            ImgNomBco.Visible = True
            bErro = True
        End If
        'Agencia
        If Not (Me.lblNomAge.Text.Trim = "" Or Me.lblNomAge.Text.Trim = "Agência inexistente") Then
            ImgAgeBco.Visible = False
        Else
            ImgAgeBco.Visible = True
            bErro = True
        End If
        'Conta Corrente
        ' --- Validação de obrigatoriedade da conta corrente retirada em 15/07/2005 -----------------------
        If Me.txtNumCtaCrr.Text.Trim <> "" Then
            ImgNumCntCrr.Visible = False
            'ElseIf LstNomBco.SelectedValue <> 275 Then 'Felipel
        ElseIf Me.txtNumBco.Text.Trim.TrimStart("0") <> "33" Then
            ImgNumCntCrr.Visible = True
            bErro = True
        End If

        '----------
        'Território
        '----------
        If Me.lblNomTet.Text = "" Or Me.lblNomTet.Text = "Território inexistente" Then
            ImgVlrVndTet.Visible = True
            bErro = True
        End If

        '-----------
        'Avaliação
        '-----------
        For iIndice = 0 To GrpDdoAvl.Items.Count - 1
            bVazio = CType(GrpDdoAvl.Items(iIndice).FindControl("DesRstAvl"), TextBox).Text.Trim = ""
            If bVazio Then
                ImgRstAvl.Visible = False
                MsgRstAvl.Visible = False
                Exit For
            End If
        Next
        If bVazio Then
            ImgRstAvl.Visible = True
            MsgRstAvl.Visible = True
            bErro = True
        End If

        '-----------
        'Competência
        '-----------
        For iIndice = 0 To GrpDdoCtn.Items.Count - 1
            bVazio = CType(GrpDdoCtn.Items(iIndice).FindControl("DesNotCtn"), TextBox).Text.Trim = ""
            If bVazio Then
                ImgRstCtn.Visible = False
                MsgRstCtn.Visible = False
                Exit For
            End If
        Next
        If bVazio Then
            ImgRstCtn.Visible = True
            MsgRstCtn.Visible = True
            bErro = True
        End If

        '-----------
        'Conjuge
        '-----------
        'If (Not DesDatNscCjg.Text.Trim.Equals(String.Empty)) And (DesNomCjg.Text.Trim.Equals(String.Empty)) Then
        '    ' nome do conjuge esta vazio, para data de nascimento existente
        '    ImgNomCjg.Visible = True
        '    bErro = True
        'ElseIf (Not DesNomCjg.Text.Trim.Equals(String.Empty)) And (DesDatNscCjg.Text.Trim.Equals(String.Empty)) Then
        '    ' nome do conjuge esta vazio, para data de nascimento existente
        '    ImgDatNscCjg.Visible = True
        '    bErro = True
        'Else
        '    ImgNomCjg.Visible = False
        '    ImgDatNscCjg.Visible = False
        'End If
        Dim bDesNomCjg As Boolean = DesNomCjg.Text.Trim.Equals(String.Empty)
        Dim bDesDatNscCjg As Boolean = DesDatNscCjg.Text.Trim.Equals(String.Empty)
        Dim bDesNumCrtIdtCjg As Boolean = DesNumCrtIdtCjg.Text.Trim.Equals(String.Empty)
        Dim bDesOrgEmsCjg As Boolean = DesOrgEmsCjg.Text.Trim.Equals(String.Empty)
        If DesNumFlhCjg.Text.Trim.Equals(String.Empty) Then
            DesNumFlhCjg.Text = "0"
        End If

        If (bDesNomCjg) And (bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (bDesNomCjg) And (bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (bDesNomCjg) And (bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (bDesNomCjg) And (Not bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (bDesNomCjg) And (Not bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (bDesNomCjg) And (Not bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (bDesNomCjg) And (Not bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = True
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (Not bDesNomCjg) And (bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (Not bDesNomCjg) And (bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (Not bDesNomCjg) And (bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (Not bDesNomCjg) And (bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = True
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (Not bDesNomCjg) And (Not bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = True
            bErro = True
        ElseIf (Not bDesNomCjg) And (Not bDesDatNscCjg) And (bDesNumCrtIdtCjg) And (Not bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = True
            ImgOrgEmsCjg.Visible = False
            bErro = True
        ElseIf (Not bDesNomCjg) And (Not bDesDatNscCjg) And (Not bDesNumCrtIdtCjg) And (bDesOrgEmsCjg) Then
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = True
            bErro = True
        Else
            ImgNomCjg.Visible = False
            ImgDatNscCjg.Visible = False
            ImgNumCrtIdtCjg.Visible = False
            ImgOrgEmsCjg.Visible = False
        End If

        Return Not bErro
    End Function
#End Region

    Private Sub OcultaImagens()
        ImgGerVnd.Visible = False
        ImgGerMcd.Visible = False
        ImgNomRep.Visible = False
        ImgNumCpf.Visible = False
        ImgNumCrtIdt.Visible = False
        ImgOrgEms.Visible = False
        ImgUndNgc.Visible = False
        ImgSex.Visible = False
        ImgDatNsc.Visible = False
        ImgNac.Visible = False
        ImgEstCvl.Visible = False
        ImgEcl.Visible = False
        ImgEst.Visible = False
        ImgCid.Visible = False
        ImgBai.Visible = False
        ImgCplBai.Visible = False
        ImgEnd.Visible = False
        ImgCep.Visible = False
        ImgRsi.Visible = False
        ImgVtg.Visible = False

        ' Flags da aba Conjuge
        ImgNomCjg.Visible = False
        ImgNumFlhCjg.Visible = False
        ImgDatNscCjg.Visible = False
        ImgOrgEmsCjg.Visible = False
        ImgNumCrtIdtCjg.Visible = False

        ImgNomBco.Visible = False
        ImgAgeBco.Visible = False
        ImgNumCntCrr.Visible = False
        ImgVlrVndTet.Visible = False
        'MsgSelTet.Visible = False
        ImgRstAvl.Visible = False
        MsgRstAvl.Visible = False
        ImgRstCtn.Visible = False
        MsgRstCtn.Visible = False
        ImgSgmMcd.Visible = False
    End Sub

    Function ConstroiXMLDdoRep(ByVal NumCpfRep As String, ByVal NumDocIdtRep As String, ByVal NomOrgEmsDocIdtRep As String, _
        ByVal NomRep As String, ByVal CodGerMcd As String, ByVal CodGerVnd As String, _
        ByVal CodSex As String, ByVal DatNscRep As String, ByVal NomNacRep As String, _
        ByVal TipEstCvlRep As String, ByVal CodGraEclRep As String, ByVal TipSitEclRep As String, _
        ByVal EndRep As String, ByVal CodBai As String, ByVal CodCplBai As String, _
        ByVal CodCidRep As String, ByVal CodCepRep As String, ByVal TipSitRsiRep As String, _
        ByVal TipVtgRsiRep As String, ByVal TipSitTlfRep As String, ByVal NumTlfRep As String, _
        ByVal NumTlfCelRep As String, ByVal TipSitFaxRep As String, ByVal NumFaxRep As String, _
        ByVal CodSgmMcd As String, ByVal NumInsInuNacSegSoc As String, ByVal NomDepRep As String, _
        ByVal DatNscDep As String, ByVal NumDocIdt As String, ByVal NomOrgEmsDocIdt As String, _
        ByVal QdeFlhRep As String, ByVal CodBcoRep As String, ByVal CodAgeBcoRep As String, _
        ByVal CodCntCrrBcoRep As String, ByVal NumDigVrfAgeBcoRep As String, ByVal TipNatRep As String, _
        ByVal DesAcoTrbRep As String, ByVal CodStaCadRep As String, ByVal DatRgtRepCshReg As String, _
        ByVal CodEstUniCshReg As String, ByVal TipSitPesJurCshReg As String, _
        ByVal TipSitRepCshReg As String, _
        ByVal CodEstUni As String, _
        ByVal NumRgtRepCshRep As String, ByVal IndAcePnd As String, ByVal IndVldCpf As String, _
        ByVal CodUndNgc As String, ByVal TipFrmPgt As String) As String

        Dim sAuxXML As String
        Try
            sAuxXML = "<?xml version='1.0' ?>" & Chr(13) & _
                      "    <dados>" & Chr(13) & _
                      "        <numcpfrep>" & NumCpfRep & "</numcpfrep>" & Chr(13) & _
                      "        <numdocidtrep>" & NumDocIdtRep & "</numdocidtrep>" & Chr(13) & _
                      "        <nomorgemsdocidtrep>" & NomOrgEmsDocIdtRep & "</nomorgemsdocidtrep>" & Chr(13) & _
                      "        <nomrep>" & NomRep & "</nomrep>" & Chr(13) & _
                      "        <codgermcd>" & CodGerMcd & "</codgermcd>" & Chr(13) & _
                      "        <codgervnd>" & CodGerVnd & "</codgervnd>" & Chr(13) & _
                      "        <codsex>" & CodSex & "</codsex>" & Chr(13) & _
                      "        <datnscrep>" & DatNscRep & "</datnscrep>" & Chr(13) & _
                      "        <nomnacrep>" & NomNacRep & "</nomnacrep>" & Chr(13) & _
                      "        <tipestcvlrep>" & TipEstCvlRep & "</tipestcvlrep>" & Chr(13) & _
                      "        <codgraeclrep>" & CodGraEclRep & "</codgraeclrep>" & Chr(13) & _
                      "        <tipsiteclrep>" & TipSitEclRep & "</tipsiteclrep>" & Chr(13) & _
                      "        <endrep>" & EndRep & "</endrep>" & Chr(13) & _
                      "        <codbai>" & CodBai & "</codbai>" & Chr(13) & _
                      "        <codcplbai>" & CodCplBai & "</codcplbai>" & Chr(13) & _
                      "        <codcidrep>" & CodCidRep & "</codcidrep>" & Chr(13) & _
                      "        <codceprep>" & CodCepRep & "</codceprep>" & Chr(13) & _
                      "        <tipsitrsirep>" & TipSitRsiRep & "</tipsitrsirep>" & Chr(13) & _
                      "        <tipvtgrsirep>" & TipVtgRsiRep & "</tipvtgrsirep>" & Chr(13) & _
                      "        <tipsittlfrep>" & TipSitTlfRep & "</tipsittlfrep>" & Chr(13) & _
                      "        <numtlfrep>" & NumTlfRep & "</numtlfrep>" & Chr(13) & _
                      "        <numtlfcelrep>" & NumTlfCelRep & "</numtlfcelrep>" & Chr(13) & _
                      "        <tipsitfaxrep>" & TipSitFaxRep & "</tipsitfaxrep>" & Chr(13) & _
                      "        <numfaxrep>" & NumFaxRep & "</numfaxrep>" & Chr(13) & _
                      "        <codsgmmcd>" & CodSgmMcd & "</codsgmmcd>" & Chr(13) & _
                      "        <numinsinunacsegsoc>" & NumInsInuNacSegSoc & "</numinsinunacsegsoc>" & Chr(13) & _
                      "        <nomdeprep>" & NomDepRep & "</nomdeprep>" & Chr(13) & _
                      "        <datnscdep>" & DatNscDep & "</datnscdep>" & Chr(13) & _
                      "        <numdocidt>" & NumDocIdt & "</numdocidt>" & Chr(13) & _
                      "        <nomorgemsdocidt>" & NomOrgEmsDocIdt & "</nomorgemsdocidt>" & Chr(13) & _
                      "        <qdeflhrep>" & QdeFlhRep & "</qdeflhrep>" & Chr(13) & _
                      "        <codbcorep>" & CodBcoRep & "</codbcorep>" & Chr(13) & _
                      "        <codagebcorep>" & CodAgeBcoRep & "</codagebcorep>" & Chr(13) & _
                      "        <codcntcrrbcorep>" & CodCntCrrBcoRep & "</codcntcrrbcorep>" & Chr(13) & _
                      "        <numdigvrfagebcorep>" & NumDigVrfAgeBcoRep & "</numdigvrfagebcorep>" & Chr(13) & _
                      "        <tipnatrep>" & TipNatRep & "</tipnatrep>" & Chr(13) & _
                      "        <desacotrbrep>" & DesAcoTrbRep & "</desacotrbrep>" & Chr(13) & _
                      "        <codstacadrep>" & CodStaCadRep & "</codstacadrep>" & Chr(13) & _
                      "        <datrgtrepcshreg>" & DatRgtRepCshReg & "</datrgtrepcshreg>" & Chr(13) & _
                      "        <codestunicshreg>" & CodEstUniCshReg & "</codestunicshreg>" & Chr(13) & _
                      "        <tipsitpesjurcshreg>" & TipSitPesJurCshReg & "</tipsitpesjurcshreg>" & Chr(13) & _
                      "        <tipsitrepcshreg>" & TipSitRepCshReg & "</tipsitrepcshreg>" & Chr(13) & _
                      "        <codestuni>" & CodEstUni & "</codestuni>" & Chr(13) & _
                      "        <numrgtrepcshrep>" & NumRgtRepCshRep & "</numrgtrepcshrep>" & Chr(13) & _
                      "        <indacepnd>" & IndAcePnd & "</indacepnd>" & Chr(13) & _
                      "        <indvldcpf>" & IndVldCpf & "</indvldcpf>" & Chr(13) & _
                      "        <codundngc>" & CodUndNgc & "</codundngc>" & Chr(13) & _
                      "        <tipfrmpgt>" & TipFrmPgt & "</tipfrmpgt>" & Chr(13) & _
                      "    </dados>"
            'Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function

    Function ConstroiXMLTetRep()
        Dim iIndice As Integer
        Dim bSelecao As Boolean
        Dim sAuxXML, sCod, sMes1, sMes2, sMes3, sVal1, sVal2, sVal3 As String
        Dim GrpDdoVlrVnd As DataSet = Session("GrpDdoVlrVnd")
        Try
            sAuxXML = "<?xml version='1.0'?>" & Chr(13) & _
                      "    <dados> " & Chr(13)
            sCod = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(0), String)
            sMes1 = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(0), String) & CType(GrpDdoVlrVnd.Tables(0).Rows(0)(1), String).PadLeft(2, "0")
            sMes2 = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(2), String) & CType(GrpDdoVlrVnd.Tables(0).Rows(0)(3), String).PadLeft(2, "0")
            sMes3 = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(4), String) & CType(GrpDdoVlrVnd.Tables(0).Rows(0)(5), String).PadLeft(2, "0")
            sVal1 = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(4), Double).ToString("#,##0.00")
            sVal2 = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(5), Double).ToString("#,##0.00")
            sVal3 = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(6), Double).ToString("#,##0.00")
            sAuxXML = sAuxXML & "        <territorio>" & Chr(13) & _
                                "            <codtetvnd>" & sCod & "</codtetvnd>" & Chr(13) & _
                                "            <anomesref>" & sMes1 & "</anomesref> " & Chr(13) & _
                                "            <vlrvndtet>" & sVal1 & "</vlrvndtet>" & Chr(13) & _
                                "        </territorio>" & Chr(13) & _
                                "        <territorio>" & Chr(13) & _
                                "            <codtetvnd>" & sCod & "</codtetvnd>" & Chr(13) & _
                                "            <anomesref>" & sMes2 & "</anomesref> " & Chr(13) & _
                                "            <vlrvndtet>" & sVal2 & "</vlrvndtet>" & Chr(13) & _
                                "        </territorio>" & Chr(13) & _
                                "        <territorio>" & Chr(13) & _
                                "            <codtetvnd>" & sCod & "</codtetvnd>" & Chr(13) & _
                                "            <anomesref>" & sMes3 & "</anomesref> " & Chr(13) & _
                                "            <vlrvndtet>" & sVal3 & "</vlrvndtet>" & Chr(13) & _
                                "        </territorio>" & Chr(13)
            sAuxXML = sAuxXML & "    </dados>"
            '            Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function

    Function ConstroiXMLCtnRep()
        Dim iIndice As Integer
        Dim sAuxXML, sAuxCod, sAuxDes As String
        Try
            sAuxXML = "<?xml version='1.0'?>" & Chr(13) & _
                      "    <dados> " & Chr(13)
            For iIndice = 0 To GrpDdoCtn.Items.Count - 1
                sAuxCod = GrpDdoCtn.Items(iIndice).Cells(0).Text.Trim
                sAuxDes = CType(GrpDdoCtn.Items(iIndice).FindControl("DesNotCtn"), TextBox).Text.Trim()
                sAuxXML = sAuxXML & "        <competencia> " & Chr(13) & _
                                    "            <codctnrep>" & sAuxCod & "</codctnrep>" & Chr(13) & _
                                    "            <descodctnrep>" & sAuxDes & "</descodctnrep> " & Chr(13) & _
                                    "        </competencia> " & Chr(13)
            Next
            sAuxXML = sAuxXML & "    </dados>"
            'Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function

    Function ConstroiXMLAvlRep()
        Dim iIndice As Integer
        Dim sAuxXML, sAuxCod, sAuxDes As String
        Try
            sAuxXML = "<?xml version='1.0'?>" & Chr(13) & _
                      "    <dados> " & Chr(13)
            For iIndice = 0 To GrpDdoAvl.Items.Count - 1
                sAuxCod = GrpDdoAvl.Items(iIndice).Cells(0).Text.Trim
                sAuxDes = CType(GrpDdoAvl.Items(iIndice).FindControl("DesRstAvl"), TextBox).Text.Trim()
                sAuxXML = sAuxXML & "        <avaliacao> " & Chr(13) & _
                                    "            <codavlrep>" & sAuxCod & "</codavlrep>" & Chr(13) & _
                                    "            <desavlctnrep>" & sAuxDes & "</desavlctnrep> " & Chr(13) & _
                                    "        </avaliacao> " & Chr(13)
            Next
            sAuxXML = sAuxXML & "    </dados>"
            'Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub DesNumInss_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesNumInss.TextChanged
        If DesNumInss.Text.Trim <> "" Then
            If Not Session("objVAKUtl").funVerificaINSS(DesNumInss.Text.Trim) Then
                MsgBoxWeb.Text = "INSS inválido!"
                DesNumInss.Text = ""
            End If
        End If
    End Sub

    Private Sub LstAgeBco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodBco As String
        CodBco = txtNumBco.Text.Trim
        If Me.txtNumAge.Text.Trim <> "" Then
            Session("objVAKUtl").pprDigAgeBco = Mid$(Me.txtNumAge.Text.Trim, 7, 1)
        Else
            Session("objVAKUtl").pprDigAgeBco = " "
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Evento OnClick do botao de insercao
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Acoes :
    '''      . insere as informacoes do RCA na tabela temporaria.
    '''      . monitora ocorrencias de tentativa de insercao de registros duplicados na tabela temporaria,
    '''        registrando mensagens de aviso ("Warning") no log ("Application") do Sistema Operacional (Event Viewer).
    ''' </remarks>
    ''' <history>
    '''     [Getulio de Morais Pereira]	15/12/2004	Tratamento contra insercao de dados redundantes. <BR>
    ''' 	[Getulio de Morais Pereira]	23/12/2004	Tratamento de Aprovacao Automatica de Requisicao. <BR>
    '''     [Getulio de Morais Pereira] 27/12/2004  Tratamento de TipFrmPgt em funcao do Banco <BR>
    '''                                             
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnIsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIsr.Click
        'Objeto
        Dim oObeIsrItfVAKRep As New VAK019.BO_VAKCadRep

        'Outros
        Dim sXMLDdoRep, sXMLTetRep, sXMLCtnRep, sXMLAvlRep, sMsgErr, _
            NumCpfRep, NumDocIdtRep, NomOrgEmsDocIdtRep, NomRep, _
            CodGerMcd, CodGerVnd, CodSex, DatNscRep, NomNacRep, _
            TipEstCvlRep, CodGraEclRep, TipSitEclRep, EndRep, _
            CodBai, CodCplBai, CodCidRep, CodCepRep, TipSitRsiRep, _
            TipVtgRsiRep, TipSitTlfRep, NumTlfRep, NumTlfCelRep, _
            TipSitFaxRep, NumFaxRep, CodSgmMcd, NumInsInuNacSegSoc, _
            NomDepRep, DatNscDep, NumDocIdt, NomOrgEmsDocIdt, _
            QdeFlhRep, CodBcoRep, CodAgeBcoRep, CodCntCrrBcoRep, _
            NumDigVrfAgeBcoRep, TipNatRep, DesAcoTrbRep, CodStaCadRep, _
            DatRgtRepCshReg, CodEstUniCshReg, _
            CodEstUni, NumRgtRepCshRep, IndAcePnd, IndVldCpf, _
            CodUndNgc, DdoFlu, TipFrmPgt, NumReq As String

        Dim TipSitPesJurCshReg As String REM Tipo de empresa
        Dim TipSitRepCshReg As String    REM Core

        ' Todo RCA eh NOVATO, quando cadastrado (Grupo de Incentivo = 1).
        Session("objVAKUtl").pprCodGrpVndRep = "1"

        If VerificaPreenchimento() Then
            Try ' VerificaPreenchimento == TRUE
                NumCpfRep = Session("objVAKUtl").funTiraMascara(DesNumCpf.Text.Trim)
                NumDocIdtRep = DesNumCrtIdt.Text.Trim
                NomOrgEmsDocIdtRep = DesOrgEms.Text.Trim
                NomRep = Session("objVAKUtl").FunVldTxt(DesNomRep.Text.Trim)
                CodGerMcd = Session("objVAKUtl").pprCodGerMcd
                CodGerVnd = Session("objVAKUtl").pprCodGerVnd
                CodSex = RadBtnSex.SelectedValue
                DatNscRep = Session("objVAKUtl").funFrmDatIsr(DatNsc)
                NomNacRep = DesNac.Text.Trim
                TipEstCvlRep = LstEstCvl.SelectedValue
                CodGraEclRep = NumGraEcl.SelectedValue
                TipSitEclRep = LstCplEcl.SelectedValue
                EndRep = Session("objVAKUtl").FunVldTxt(DesEnd.Text.Trim)
                CodBai = LstNomBai.SelectedValue.ToString
                If (CodBai = "-1") Then CodBai = ""
                CodCplBai = LstCplBai.SelectedValue.ToString
                If (CodCplBai = "-1") Then CodCplBai = ""
                CodCidRep = LstCid.SelectedValue.ToString
                If (CodCidRep = "-1") Then CodCidRep = ""
                CodCepRep = Session("objVAKUtl").funTiraMascara(DesNumCep.Text.Trim)
                TipSitRsiRep = LstRsi.SelectedValue
                TipVtgRsiRep = LstVtg.SelectedValue

                ' Telefone do RCA
                TipSitTlfRep = LstSitTlf.SelectedValue
                NumTlfRep = NumTlf.Text.Trim
                ' FAX do RCA
                TipSitFaxRep = LstSitFax.SelectedValue
                NumFaxRep = NumFax.Text.Trim
                ' Celular do RCA
                NumTlfCelRep = NumCel.Text.Trim

                If LstSgmMcd.SelectedValue = -1 Then
                    CodSgmMcd = ""
                Else
                    CodSgmMcd = LstSgmMcd.SelectedValue
                End If

                NumInsInuNacSegSoc = DesNumInss.Text.Trim


                ' --------------------------------------------
                ' Dados do Conjuge
                ' --------------------------------------------
                NomDepRep = Session("objVAKUtl").FunVldTxt(DesNomCjg.Text.Trim)
                If DatNscCjg.SelectedDate.Year = 1 Then
                    DatNscDep = ""
                Else
                    DatNscDep = Session("objVAKUtl").funFrmDatIsr(DatNscCjg)
                End If
                NumDocIdt = DesNumCrtIdtCjg.Text.Trim
                NomOrgEmsDocIdt = DesOrgEmsCjg.Text.Trim
                QdeFlhRep = DesNumFlhCjg.Text.Trim
                ' --------------------------------------------
                ' Dados do Banco do Representante
                ' --------------------------------------------
                CodBcoRep = Me.txtNumBco.Text.Trim
                If (CodBcoRep = "-1") Then CodBcoRep = ""
                CodAgeBcoRep = Me.txtNumAge.Text.Trim
                If (CodAgeBcoRep = "-1") Then CodAgeBcoRep = ""

                CodCntCrrBcoRep = Me.txtNumCtaCrr.Text.Trim

                If (CodCntCrrBcoRep = "") And (Me.txtNumBco.Text.Trim.TrimStart("0") = "33") Then
                    TipFrmPgt = "R"
                Else
                    TipFrmPgt = "B"
                End If

                NumDigVrfAgeBcoRep = Session("objVAKUtl").pprDigAgeBco
                TipNatRep = "F" ' Todo RCA eh Pessoa Fisica
                DesAcoTrbRep = Session("objVAKUtl").FunVldTxt(DesAcoTrb.Text.Trim)

                If DatCadCshReg.SelectedDate.Year = 1 Then
                    DatRgtRepCshReg = ""
                Else
                    DatRgtRepCshReg = Session("objVAKUtl").funFrmDatIsr(DatCadCshReg)
                End If
                CodEstUniCshReg = LstEstCshReg.SelectedValue

                'TipSitPesJurCshReg = LstSitCshReg.SelectedValue
                TipSitPesJurCshReg = "PF"
                TipSitRepCshReg = LstSitCshReg.SelectedValue

                CodEstUni = LstEst.SelectedValue
                NumRgtRepCshRep = DesCshReg.Text.Trim
                IndAcePnd = RblAcePnd.SelectedItem.Value
                IndVldCpf = "0" ' O CPF do RCA eh valido, por default.

                'O campo "unidade de negócio" está sendo retirado do formulário. Gravará fixo 1.
                CodUndNgc = 1 'CodUndNgc = LstUndNgc.SelectedValue

                CodStaCadRep = "1" ' Status = NOVO

                If Session("TrabalhouMartins") = True Then
                    CodStaCadRep = "0"
                    'oObeIsrItfVAKRep.EnviarEmailAnalistaCredito(Session("CodSup"), _
                    '                                            NomRep, NumCpfRep, _
                    '                                            CInt(NumReq), _
                    '                                            AppSettings("simBo"))
                End If
                sXMLDdoRep = ConstroiXMLDdoRep(NumCpfRep, NumDocIdtRep, NomOrgEmsDocIdtRep, NomRep, _
                             CodGerMcd, CodGerVnd, CodSex, DatNscRep, NomNacRep, _
                             TipEstCvlRep, CodGraEclRep, TipSitEclRep, EndRep, _
                            CodBai, CodCplBai, CodCidRep, CodCepRep, TipSitRsiRep, _
                             TipVtgRsiRep, TipSitTlfRep, NumTlfRep, NumTlfCelRep, _
                             TipSitFaxRep, NumFaxRep, CodSgmMcd, NumInsInuNacSegSoc, _
                             NomDepRep, DatNscDep, NumDocIdt, NomOrgEmsDocIdt, _
                             QdeFlhRep, CodBcoRep, CodAgeBcoRep, CodCntCrrBcoRep, _
                             NumDigVrfAgeBcoRep, TipNatRep, DesAcoTrbRep, CodStaCadRep, _
                             DatRgtRepCshReg, CodEstUniCshReg, TipSitPesJurCshReg, TipSitRepCshReg, _
                             CodEstUni, NumRgtRepCshRep, IndAcePnd, IndVldCpf, CodUndNgc, TipFrmPgt)
                If sXMLDdoRep = "" Then
                    Throw New Exception("Erro ao construir XML Dados Representante")
                End If
                sXMLTetRep = ConstroiXMLTetRep()
                If sXMLTetRep = "" Then
                    Throw New Exception("Erro ao construir XML Território")
                End If
                sXMLCtnRep = ConstroiXMLCtnRep()
                If sXMLCtnRep = "" Then
                    Throw New Exception("Erro ao construir XML Competência")
                End If
                sXMLAvlRep = ConstroiXMLAvlRep()
                If sXMLAvlRep = "" Then
                    Throw New Exception("Erro ao construir XML Avaliação")
                End If

                ' ------------------------------
                ' Assegurando insercao de apenas 1 registro na tabela temporaria de representantes
                ' ------------------------------
                Dim oObeCsnItfVAKRep As New VAK019.BO_VAKCsnRep
                Dim retorno As String
                Dim ds As DataSet
                Dim dsFluAvl As DataSet

                ' Verifica a existencia do CPF do RCA na tabela temporaria
                retorno = oObeCsnItfVAKRep.CsnDdoRep("", "", NumCpfRep, "", "", "", "", "", "", "1900-01-01")
                ds = Session("objVAKUtl").funXMLDS(retorno)
                dsFluAvl = Session("objVAKUtl").funXMLDS(oObeCsnItfVAKRep.CsnSlcFluApv(NumCpfRep))
                Dim oCnx As IAU013.UO_IAUCnxAcsDdo

                Dim bMsgLog As Boolean = False ' Indica tentativa de duplicacao de registro
                Dim bExisteINSS As Boolean = False ' Indica existencia de INSS ja cadastrado 

                If ((Not ds Is Nothing) And (ds.Tables(0).Rows.Count > 0)) Or ((Not dsFluAvl Is Nothing) And (dsFluAvl.Tables(0).Rows.Count > 0)) Then ' Monitoramento de insercao
                    ' descarta insercao e publica mensagem de aviso no log (EventLog) para monitoramento.
                    Dim ev As System.Diagnostics.EventLog
                    Dim msg As String

                    bMsgLog = True
                    msg = " Usuario : " & Session("objVAKUtl").funUsr() & vbCrLf & _
                          " Gerente de Mercado : [" & CodGerMcd & "] - " & Session("objVAKUtl").pprNomGerMcd & vbCrLf & _
                          " Gerente de Vendas  : [" & CodGerVnd & "] - " & Session("objVAKUtl").pprNomGerVnd & vbCrLf & _
                          " Sessao : " & Session.SessionID.ToString & vbCrLf & _
                          " Timeout da sessao : " & Session.Timeout.ToString & vbCrLf & _
                          " Mensagem : o RCA [" & Session("objVAKUtl").funMascaraCPF(NumCpfRep) & "] ja foi cadastrado."

                    ev = New System.Diagnostics.EventLog
                    ev.Source = "ExceptionManagerPublishedException"
                    ev.Log = "Application"
                    Try
                        If Not ev.SourceExists(ev.Source) Then
                            ev.CreateEventSource(ev.Source, "Application")
                        End If
                        ev.WriteEntry(msg, Diagnostics.EventLogEntryType.Warning)
                        sMsgErr = "1"
                    Catch b As Exception
                        MsgBoxWeb.Text = "A entrada [ '" & ev.Source.ToString & "' ] nao foi encontrada no Log de Eventos do Windows. " & _
                                         "Entre em contato com o Administrador do sistema."
                    Finally
                        ev = Nothing
                    End Try
                Else ' Insercao do registro na tabela temporaria
                    If (Not NumInsInuNacSegSoc Is Nothing) And (NumInsInuNacSegSoc.Equals(String.Empty)) Then
                        bExisteINSS = False
                    Else
                        bExisteINSS = existeINSS(NumInsInuNacSegSoc, NumCpfRep)
                    End If

                    If bExisteINSS Then
                        ' INSS JA CADASTRADO
                        ' A conclusao do processo deve ser bloqueada!
                        sMsgErr = "1"
                        MsgBoxWeb.Text = "O INSS [ " + DesNumInss.Text.Trim + " ] ja esta cadastrado!"
                    Else
                        ' INSS ainda nao cadastrado
                        bMsgLog = False
                        DdoFlu = "******************************************************************* " & _
                                 "  Documento enviado para aprovacao pelo GM " & NomGerMcd.Text & _
                                 "  Em : " & Format("dd/MM/yyyy hh:mm:ss", Now)
                        ' Concatena observacao caso o candidato ja tenha trabalhado no martins como representante.
                        If Session("objVAKUtl").pprMsgRep <> "" Then
                            DdoFlu = DdoFlu & Session("objVAKUtl").pprMsgRep
                        End If
                        sMsgErr = oObeIsrItfVAKRep.IsrDdoRep(sXMLDdoRep, "GM" & CodGerMcd.Trim.PadLeft(6, "0"), _
                                                        sXMLTetRep, sXMLCtnRep, sXMLAvlRep, _
                                                        DdoFlu, NumReq, Session("TrabalhouMartins"), AppSettings("simBo"))
                    End If

                    ' ----------------------------------------------------------------------
                    ' Habilitacao Automatica
                    ' ----------------------------------------------------------------------
                    Dim sDdoFlu As String
                    Dim bAprAut As Boolean = habilitaAprovacaoAutomatica(NumCpfRep, sDdoFlu)
                    If bAprAut AndAlso Session("TrabalhouMartins") <> True Then
                        Try
                            Dim sVlrRetIsr As String = sMsgErr
                            Dim sVlrErr As String
                            Dim oObeItfCadRep As New VAK019.DB_VAKRep

                            Dim StaApv As String = "4"
                            Dim UsrApv As String = "GV" ' "APROV. AUTOMATICA" "GV"
                            oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
                            oCnx.IniTsc()

                            'If Session("TrabalhouMartins") = True Then
                            '    StaApv = "0"
                            '    oObeIsrItfVAKRep.EnviarEmailAnalistaCredito(Session("CodSup"))
                            'End If

                            ' Insere na tabela de alteração de status [mrt.t0150350]
                            If sVlrRetIsr <> "" Then
                                sVlrRetIsr = ""
                                sVlrRetIsr = oObeItfCadRep.IsrDdoAltSta(StaApv, NumReq, UsrApv, sVlrErr, oCnx)
                            End If
                            ' Insere Registro no historico do fluxo [mrt.t0150610]
                            If sVlrRetIsr <> "" Then
                                sVlrRetIsr = ""
                                sDdoFlu = DdoFlu + " " + sDdoFlu
                                'sVlrRetIsr = oObeItfCadRep.IsrDdoDesObs(NumReq, StaApv, sDdoFlu, sVlrRetIsr)
                                sVlrRetIsr = oObeItfCadRep.AltDdoDesObs(NumReq, "1", sDdoFlu, sVlrRetIsr, oCnx)
                            End If
                            ' alterar o status do RCA na tabela temporaria [MRT.T0150415]
                            If sVlrRetIsr <> "" Then
                                sVlrRetIsr = ""
                                sVlrRetIsr = oObeItfCadRep.AltStaReq(NumReq, StaApv, UsrApv, oCnx)
                            End If
                            ' Liberando objetos
                            oObeItfCadRep = Nothing
                            StaApv = Nothing
                            sVlrRetIsr = Nothing
                            UsrApv = Nothing
                            oCnx.FimTscSuc()
                        Catch ex As Exception
                            oCnx.FimTscErr()
                            Throw
                        Finally
                            oCnx.Dispose()
                        End Try
                    End If ' Aprovacao Automatica de RCA
                    ' ----------------------------------------------------------------------
                End If ' Monitoramento de insercao

                ds.Dispose()
                If sMsgErr <> "1" Then ' Houve erro na insercao do registro ?
                    Throw New Exception(sMsgErr)
                Else ' Qual foi a mensagem retornada (insercao OK / tentativa de duplicacao) ?
                    If (Not bMsgLog) Then ' Insercao bem sucedida
                        If Not bExisteINSS Then
                            MsgBoxWeb.Text = "Registro inserido com sucesso! Número da requisição : " & NumReq
                            Me.txtJaEnviou.Text = "1"
                            ' Dar refresh
                            'CsnTotDdoRep()
                        End If
                    Else ' Tentativa de duplicacao
                        MsgBoxWeb.Text = "Tentativa de duplicacao dos dados do RCA [ " & Session("objVAKUtl").funMascaraCPF(NumCpfRep) & " ]. Por favor, informe o Administrador do Sistema."
                    End If
                End If
            Catch ex As Exception
                Err(ex.Message.ToString.Replace(Chr(10), ""))
            End Try
        Else ' VerificaPreenchimento == FALSE
            MsgBoxWeb.Text = "Foram encontrados erros ou existem campos obrigatórios que não foram preenchidos. Verifique as informações e tente novamente."
        End If
    End Sub

#Region "--> habilitaAprovacaoAutomatica"
    ' /**
    '  * Funcao     : habilitaAprovacaoAutomatica
    '  * Descricao  : verifica a possibilidade de habilitar ou nao a aprovacao automatica de um RCA
    '  * Parametros : 
    '  *              numCpf = numero de CPF do RCA a ser verificado
    '  *              msgFlu = mensagem a ser impressa no Fluxo do Sistema, caso aprovacao seja habilitada
    '  * Retorno    : TRUE  = o aproveitamento de cada prova do RCA foi superior ou igual ao minimo 
    '  *                      estabelecido para aprovacao automatica
    '  *              FALSE = o aproveitamento de cada prova do RCA foi inferior ao minimo 
    '  *                      estabelecido para aprovacao automatica
    '  * Autor      : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
    '  * Data       ' 14/12/2004
    '  */
    Private Function habilitaAprovacaoAutomatica(ByVal numCpf As String, ByRef msgFlu As String) As Boolean
        Dim flag As Boolean = False
        Dim oObeItfDdoAvlRep As VAK019.DB_VAKRep = New VAK019.DB_VAKRep
        Dim sVlrErrAvlRep As String
        Dim oCnx As IAU013.UO_IAUCnxAcsDdo
        oCnx = New IAU013.UO_IAUCnxAcsDdo("DB001", "BOADM")
        Dim strAvl As String = oObeItfDdoAvlRep.CsnRstPva(numCpf, sVlrErrAvlRep, "", oCnx)
        Dim dsAvlRep As DataSet = Session("objVAKUtl").funXMLDS(strAvl)
        Dim msgAvl As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim media As Decimal = 0.0          ' Media das notas
        Dim notaMat As Decimal = 0.0        ' Nota da prova de matematica
        Dim notaPort As Decimal = 0.0       ' Nota da prova de portugues

        If (Not dsAvlRep Is Nothing) And (dsAvlRep.Tables(0).Rows.Count > 0) Then
            ' Existe nota para este CPF
            With dsAvlRep.Tables(0)
                notaMat = .Rows(0).Item(1)
                notaPort = .Rows(1).Item(1)
                'media = (notaMat + notaPort) / 2
                If (notaMat >= Session("objVAKUtl").pprVlrMnmPvtAvl) And (notaPort >= Session("objVAKUtl").pprVlrMnmPvtAvl) Then
                    msgAvl.Append("******************************************************************* " & vbNewLine)
                    msgAvl.Append("  Documento aprovado automaticamente em funcao das notas" & vbNewLine)
                    msgAvl.Append("  obtidas pelo candidato no Formar." & vbNewLine)
                    'msgAvl.Append("          +-------------+------------+" & vbNewLine)
                    'msgAvl.Append("          |   Prova     |    Nota    |" & vbNewLine)
                    'msgAvl.Append("          +-------------+------------+" & vbNewLine)
                    'msgAvl.Append("          | Matematica  | " & notaMat.ToString.Trim.PadLeft(10) & " |" & vbNewLine)
                    'msgAvl.Append("          | Portugues   | " & notaPort.ToString.Trim.PadLeft(10) & " |" & vbNewLine)
                    'msgAvl.Append("          +-------------+------------+" & vbNewLine)
                    'msgAvl.Append("          | Media       | " & (media).ToString.Trim.PadLeft(10) & " |" & vbNewLine)
                    'msgAvl.Append("          +-------------+------------+" & vbNewLine)
                    msgAvl.Append("  Data : " & Format("dd/MM/yyyy hh:mm:ss", Now) & vbNewLine)
                Else
                    msgAvl.Append("")
                End If
            End With
        Else
            ' Nao existe nota para este CPF
            msgAvl.Append("")
        End If
        ' Retorno da funcao
        msgFlu = msgAvl.ToString()
        Return ((notaMat >= Session("objVAKUtl").pprVlrMnmPvtAvl) And (notaPort >= Session("objVAKUtl").pprVlrMnmPvtAvl))
    End Function
#End Region

#Region "--> existeINSS"
    ' /**
    '  * Funcao : consultaINSS
    '  * Descricao : consultar a tabela de Representantes buscando por INSS cadastrados
    '  * Parametro : numINSS --> numero de INSS a ser verificado
    '  * Retorno   : TRUE --> o INSS nao esta cadastrado (nao bloqueia cadastro do RCA)
    '  *             FALSE --> o INSS ainda nao esta cadastrado
    '  * 
    '  * Autor     : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
    '  * Data      : 16/12/2004
    '  */
    Function existeINSS(ByVal numINSS As String, ByVal numCPF As String) As Boolean
        ' ---------------------------------------------------------------
        ' Verifica se o INSS ja esta cadastrado para o CPF em questao
        ' ---------------------------------------------------------------
        Dim sRepCadastrado As String
        Dim oObeDdoRep As VAK019.BO_VAKCsnRep
        '        Dim oObeItfVAKRep As VAK019.ItfVAKCsnRep
        Try
            oObeDdoRep = New VAK019.BO_VAKCsnRep
            sRepCadastrado = oObeDdoRep.CsnNumInsInuNacSegSoc(numINSS, numCPF)

            Dim ds As DataSet
            Dim quant As String = ""
            ds = Session("objVAKUtl").funXMLDS(sRepCadastrado)
            If (Not ds Is Nothing) And (ds.Tables(0).Rows.Count > 0) Then
                'If Convert.ToInt32(ds.Tables(0).Rows(0)("ISREP")).Trim <> "" Then
                quant = ds.Tables(0).Rows(0).Item(0)
                'End If
            End If


            Return Not quant.Equals("0")
        Catch ex As Exception
            Err(ex.Message)
            Return False
        Finally
            oObeDdoRep = Nothing
            ' oObeItfVAKRep = Nothing
        End Try
    End Function
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preencho o formulario de cadastro com informacoes pre-existentes no sistema.
    ''' </summary>
    ''' <param name="sCodRep">Codigo do representante Martins.</param>
    ''' <returns>Valor booleano indicando sucesso/fracasso no preenchimento dos dados.</returns>
    ''' <remarks>
    ''' Funcao auxiliar para preenchimento do formulario de cadastro.
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	2/24/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Function PreencheDdoRepExr(ByVal sCodRep As String) As Boolean
        Dim sXMLDdoRepExr As String
        Dim oDsDdoRepExr As New DataSet
        Dim oObeCsnRepExrItf As New VAK019.BO_VAKCsnRep
        Try
            ' Obtem dados do candidato (provenientes da tabela MRT.T0100116)
            sXMLDdoRepExr = oObeCsnRepExrItf.CsnDdoRepExt(sCodRep)
            oDsDdoRepExr = Nothing
            oDsDdoRepExr = Session("objVAKUtl").funXMLDS(sXMLDdoRepExr)
            If Not oDsDdoRepExr Is Nothing Then
                With oDsDdoRepExr.Tables(0)
                    If .Rows.Count > 0 Then
                        ' - REPRESENTANTE                            
                        DesNomRep.Text = Convert.ToString(.Rows(0)("NOMREP")).Trim
                        DesNumCrtIdt.Text = Convert.ToString(.Rows(0)("NUMDOCIDTREP")).Trim
                        DesOrgEms.Text = Convert.ToString(.Rows(0)("NOMORGEMSDOCIDTREP")).Trim
                        DesNumInss.Text = Convert.ToString(.Rows(0)("NUMINSINUNACSEGSOC")).Trim
                        If DesNumInss.Text = "0" Then
                            DesNumInss.Text = ""
                        End If

                        'O campo "unidade de negócio" está sendo retirado do formulário. Gravará fixo 1.
                        'LstUndNgc.SelectedItem.Value = .Rows(0)("CODUNDNGC")

                        DesCshReg.Text = Convert.ToString(.Rows(0)("NUMRGTREPCSHREG")).Trim
                        ' Data do Core [OK!]
                        If Not Convert.IsDBNull(.Rows(0)("DATRGTREPCSHREG")) Then
                            DatCadCshReg.SelectedDate = .Rows(0)("DATRGTREPCSHREG")
                            DesDatCadCshReg.Text = DatCadCshReg.SelectedDate.ToShortDateString
                        End If
                        'Situação Core
                        Try : LstSitCshReg.SelectedValue = Convert.ToString(.Rows(0)("TIPSITREPCSHREG")).Trim
                        Catch oObeEcc As Exception : LstSitCshReg.SelectedIndex = 0
                        End Try
                        'Estado Core
                        Try : LstEstCshReg.SelectedValue = Convert.ToString(.Rows(0)("CODESTUNICSHREG"))
                        Catch oObeEcc As Exception : LstEstCshReg.SelectedIndex = 0
                        End Try
                        'VAKUtl.pprCodEstCshReg = .Rows(0)("CODESTUNICSHREG")
                        Session("objVAKUtl").pprCodEstCshReg = LstEstCshReg.SelectedValue

                        If Not Convert.IsDBNull(.Rows(0)("CODESTUNI")) Then
                            Session("objVAKUtl").pprCodEst = Convert.ToString(.Rows(0)("CODESTUNI")).Trim
                        Else
                            Session("objVAKUtl").pprCodEst = ""
                        End If
                        If Not Convert.IsDBNull(.Rows(0)("CODCIDREP")) Then
                            Session("objVAKUtl").pprCodCid = Convert.ToString(.Rows(0)("CODCIDREP")).Trim
                        Else
                            Session("objVAKUtl").pprCodCid = ""
                        End If
                        If Not Convert.IsDBNull(.Rows(0)("CODBAI")) Then
                            Session("objVAKUtl").pprCodBai = Convert.ToString(.Rows(0)("CODBAI")).Trim
                        Else
                            Session("objVAKUtl").pprCodBai = ""
                        End If
                        If Not Convert.IsDBNull(.Rows(0)("CODCPLBAI")) Then
                            Session("objVAKUtl").pprCodCplBai = Convert.ToString(.Rows(0)("CODCPLBAI")).Trim
                        Else
                            Session("objVAKUtl").pprCodCplBai = ""
                        End If

                        ' Quantidade de filhos [OK!]
                        If Convert.ToString(.Rows(0)("QDEFLHREP")).Trim <> "" Then
                            DesNumFlhCjg.Text = Convert.ToString(.Rows(0)("QDEFLHREP")).Trim
                        Else
                            DesNumFlhCjg.Text = "0"
                        End If
                        'Sexo
                        If Convert.ToString(.Rows(0)("CODSEX")).Trim <> "" Then
                            RadBtnSex.SelectedValue = .Rows(0)("CODSEX")
                        End If

                        ' Data de nascimento do candidato [OK!]
                        DatNsc.SelectedDate = .Rows(0)("DATNSCREP")
                        DesDatNsc.Text = DatNsc.SelectedDate.ToShortDateString

                        ' Nacionalidade do candidato [OK!]
                        DesNac.Text = Convert.ToString(.Rows(0)("NOMNACREP")).Trim

                        'Estado Civil
                        If "CDSV".IndexOf(Convert.ToString(.Rows(0)("TIPESTCVLREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPESTCVLREP")).Trim <> "" Then
                            LstEstCvl.SelectedValue = .Rows(0)("TIPESTCVLREP")
                        End If
                        'Grau escolar
                        If "123".IndexOf(Convert.ToString(.Rows(0)("CODGRAECLREP"))) >= 0 And Convert.ToString(.Rows(0)("CODGRAECLREP")).Trim <> "" Then
                            NumGraEcl.SelectedValue = .Rows(0)("CODGRAECLREP")
                        End If
                        'Situação grau escolar
                        If "CI".IndexOf(Convert.ToString(.Rows(0)("TIPSITECLREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPSITECLREP")).Trim <> "" Then
                            LstCplEcl.SelectedValue = .Rows(0)("TIPSITECLREP")
                        End If
                        'DesEnd.Text = Convert.ToString(.Rows(0)("ENDREP")).Trim
                        Dim str As String
                        str = Convert.ToString(.Rows(0)("ENDREP")).Trim
                        If str.Length > DesEnd.MaxLength Then
                            str = str.Substring(0, DesEnd.MaxLength - 1)
                        End If
                        DesEnd.Text = str

                        'Preenche CEP
                        DesNumCep.Text = Session("objVAKUtl").funMascaraCEP(Session("objVAKUtl").funTiraMascara(Convert.ToString(.Rows(0)("CODCEPREP")).Trim))

                        'Preenche Cidade/Estado
                        Me.csnCep_Click(Me, Nothing)

                        'Preenche / Seleciona combo Bairro
                        AbsLstBai()
                        Me.LstNomBai.SelectedIndex = _
                            Me.LstNomBai.Items.IndexOf( _
                                Me.LstNomBai.Items.FindByValue( _
                                    Convert.ToString(.Rows(0)("CODBAI"))))

                        'Preenche / Seleciona Complemento de Bairro [OK!]
                        If Not (IsDBNull(.Rows(0)("CODCPLBAI"))) Then
                            Me.LstCplBai.SelectedIndex = _
                                Me.LstCplBai.Items.IndexOf( _
                                    Me.LstCplBai.Items.FindByValue( _
                                        Convert.ToString(.Rows(0)("CODCPLBAI"))))
                        End If

                        'Residencia
                        If "AP".IndexOf(Convert.ToString(.Rows(0)("TIPSITRSIREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPSITRSIREP")).Trim <> "" Then
                            LstRsi.SelectedValue = .Rows(0)("TIPSITRSIREP")
                        End If
                        'Voltagem
                        If "110220".IndexOf(Convert.ToString(.Rows(0)("TIPVTGRSIREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPVTGRSIREP")).Trim.Length = 3 Then
                            LstVtg.SelectedValue = .Rows(0)("TIPVTGRSIREP")
                        End If
                        'Telefone
                        NumTlf.Text = Convert.ToString(.Rows(0)("NUMTLFREP")).Trim
                        If "SN".IndexOf(Convert.ToString(.Rows(0)("TIPSITTLFREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPSITTLFREP")).Trim <> "" Then
                            LstSitTlf.SelectedValue = .Rows(0)("TIPSITTLFREP")
                        End If
                        'Fax
                        NumFax.Text = Convert.ToString(.Rows(0)("NUMFAXREP")).Trim
                        If "SN".IndexOf(Convert.ToString(.Rows(0)("TIPSITFAXREP"))) >= 0 And Convert.ToString(.Rows(0)("TIPSITFAXREP")).Trim <> "" Then
                            LstSitFax.SelectedValue = .Rows(0)("TIPSITFAXREP")
                        End If
                        'Celular
                        NumCel.Text = Convert.ToString(.Rows(0)("NUMTLFCELREP")).Trim
                        'Segmento de Mercado
                        Try : LstSgmMcd.SelectedValue = .Rows(0)("CODSGMMCD")
                        Catch oObeEcc As Exception : LstSgmMcd.SelectedIndex = 0
                        End Try
                        ' - BANCO
                        If Not Convert.IsDBNull(.Rows(0)("TIPSITPESJURCSHREG")) Then
                            If .Rows(0)("TIPSITPESJURCSHREG") = "PF" Then
                                'Selecionar banco
                                Try
                                    Me.txtNumBco.Text = Convert.ToString(.Rows(0)("CODBCOREP"))
                                    Me.lblNomBco.Text = Convert.ToString(.Rows(0)("NOMBCO"))
                                Catch oObeEcc As Exception
                                    Me.txtNumBco.Text = ""
                                    Me.lblNomBco.Text = ""
                                End Try
                                'Verificar se selecionou o banco
                                If Me.txtNumBco.Text <> "0" Then
                                    'Selecionar agencia
                                    Try
                                        Me.txtNumAge.Text = Convert.ToString(.Rows(0)("CODAGEBCOREP"))
                                        Me.lblNomAge.Text = Convert.ToString(.Rows(0)("NOMAGEBCO"))
                                    Catch oObeEcc As Exception
                                        Me.txtNumAge.Text = ""
                                        Me.lblNomAge.Text = ""
                                    End Try

                                    'Verificar se o digito da agencia selecionado no combo é igual ao digito
                                    'retornado pela consulta
                                    Try
                                        If Convert.ToString(.Rows(0)("NUMDIGVRFAGEBCOREP")) = Mid$(Me.txtNumAge.Text.Trim, 7, 1) Then
                                            Session("objVAKUtl").pprDigAgeBco = Convert.ToString(.Rows(0)("NUMDIGVRFAGEBCOREP"))
                                            'Selecionar conta corrente
                                            Me.txtNumCtaCrr.Text = Convert.ToString(.Rows(0)("CODCNTCRRBCOREP")).Trim
                                        Else
                                            Me.txtNumAge.Text = ""
                                            Session("objVAKUtl").pprDigAgeBco = ""
                                            Me.txtNumCtaCrr.Text = ""
                                        End If
                                    Catch ex As Exception
                                        Me.txtNumAge.Text = ""
                                        Session("objVAKUtl").pprDigAgeBco = ""
                                        Me.txtNumCtaCrr.Text = ""
                                    End Try
                                End If
                            End If
                        End If
                        'Cônjuge
                        DesNomCjg.Text = Convert.ToString(.Rows(0)("NOMDEPREP")).Trim
                        DesNumCrtIdtCjg.Text = Convert.ToString(.Rows(0)("NUMDOCIDT")).Trim
                        DesOrgEmsCjg.Text = Convert.ToString(.Rows(0)("NOMORGEMSDOCIDTDEP")).Trim
                        DesDatNscCjg.Text = CType(.Rows(0)("DATNSCDEP"), Date).ToString("dd/MM/yyyy")
                    End If
                End With
            End If
            'Err("")
            Return True
        Catch oErr As Exception
            Err(oErr.Message)
            Return False
        End Try
    End Function

    Private Sub DesDatNsc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DesDatNsc.TextChanged
        Dim sAuxData As String
        If CType(sender, TextBox).Text.Trim <> "" Then
            sAuxData = Session("objVAKUtl").funValidaData(CType(sender, TextBox).Text.Trim)
            If sAuxData = "" Then
                CType(sender, TextBox).Text = ""
                Err("Data Inválida.")
                DatNsc.SelectedDate = Nothing
            Else
                DatNsc.SelectedDate = sAuxData
            End If
        End If
    End Sub

    Private Sub DatNsc_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatNsc.DateChanged
        DesDatNsc.Text = Format(DatNsc.SelectedDate, "dd/MM/yyyy")
    End Sub

    Private Sub DesDatCadCshReg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DesDatCadCshReg.TextChanged
        Dim sAuxData As String
        If CType(sender, TextBox).Text.Trim <> "" Then
            sAuxData = Session("objVAKUtl").funValidaData(CType(sender, TextBox).Text.Trim)
            If sAuxData = "" Then
                CType(sender, TextBox).Text = ""
                Err("Data Inválida.")
                DatCadCshReg.SelectedDate = Nothing
            Else
                DatCadCshReg.SelectedDate = sAuxData
            End If
        End If
    End Sub

    Private Sub DatCadCshReg_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatCadCshReg.DateChanged
        DesDatCadCshReg.Text = Format(DatCadCshReg.SelectedDate, "dd/MM/yyyy")
    End Sub

    Private Sub DesDatNscCjg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DesDatNscCjg.TextChanged
        Dim sAuxData As String
        If CType(sender, TextBox).Text.Trim <> "" Then
            sAuxData = Session("objVAKUtl").funValidaData(CType(sender, TextBox).Text.Trim)
            If sAuxData = "" Then
                CType(sender, TextBox).Text = ""
                Err("Data Inválida.")
                DatNscCjg.SelectedDate = Nothing
            Else
                DatNscCjg.SelectedDate = sAuxData
            End If
        End If
    End Sub

    Private Sub DatNscCjg_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatNscCjg.DateChanged
        DesDatNscCjg.Text = Format(DatNscCjg.SelectedDate, "dd/MM/yyyy")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta valores de venda do território
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	29/3/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnCsnTet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCsnTet.Click
        Dim oAcsDdo As New VAK019.BO_VAKCsnRep
        Dim sCodSup As String = Session("objVAKUtl").pprCodGerMcd
        Dim iCodTet As Integer
        Try
            Me.lblMesUm.Text = "Mês 1"
            Me.lblMesDois.Text = "Mês 2"
            Me.lblMesTre.Text = "Mês 3"
            Me.txtVlrVndUm.Text = ""
            Me.txtVlrVndDois.Text = ""
            Me.txtVlrVndTre.Text = ""
            Me.lblNomTet.Text = ""
            Me.lblNomRep.Text = ""
            Me.ImgVlrVndTet.Visible = False
            If Me.txtTetVnd.Text.Trim.Length >= 1 Then
                iCodTet = CType(Me.txtTetVnd.Text.Trim, Integer)
                GrpDdoVlrVnd = oAcsDdo.CsnInfCadRep(sCodSup, iCodTet)
                If GrpDdoVlrVnd.Tables("tblDdo").Rows.Count >= 1 Then
                    'Nome dos últimos três meses
                    Me.lblMesUm.Text = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(1), String).PadLeft(2, "0") & "/" & _
                                             CType(GrpDdoVlrVnd.Tables(0).Rows(0)(0), String)
                    Me.lblMesDois.Text = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(3), String).PadLeft(2, "0") & "/" & _
                                             CType(GrpDdoVlrVnd.Tables(0).Rows(0)(2), String)
                    Me.lblMesTre.Text = CType(GrpDdoVlrVnd.Tables(0).Rows(0)(5), String).PadLeft(2, "0") & "/" & _
                                             CType(GrpDdoVlrVnd.Tables(0).Rows(0)(4), String)
                    If Not GrpDdoVlrVnd.Tables(1).Rows.Count < 1 Then
                        'Valores de venda dos últimos três meses
                        Me.txtVlrVndUm.Text = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(4), Double).ToString("#,##0.00")
                        Me.txtVlrVndDois.Text = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(5), Double).ToString("#,##0.00")
                        Me.txtVlrVndTre.Text = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(6), Double).ToString("#,##0.00")

                        'Nome do representante atual
                        Me.lblNomRep.Text = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(3), String)

                        'Nome do território
                        Me.lblNomTet.Text = CType(GrpDdoVlrVnd.Tables(1).Rows(0)(1), String)
                    End If
                    Session("GrpDdoVlrVnd") = GrpDdoVlrVnd
                Else
                    Me.lblNomTet.Text = "Território inexistente"
                End If
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta banco do cliente
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	13/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnCsnBco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCsnBco.Click
        Dim oAcsDdo As New VAK019.BO_VAKCsnRep
        Dim oGrpDdo As DataSet
        Me.txtNumAge.Text = ""
        Me.txtNumCtaCrr.Text = ""
        Me.lblNomAge.Text = ""
        Me.lblNomBco.Text = ""
        If Me.txtNumBco.Text.Trim <> "" Then
            oGrpDdo = oAcsDdo.CsnBcoUnc(CType(Me.txtNumBco.Text.Trim, Integer))
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                lblNomBco.Text = CType(oGrpDdo.Tables(0).Rows(0)(1), String).Trim
            Else
                lblNomBco.Text = "Banco Inexistente"
            End If
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Consulta agência do cliente
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	13/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnCsnAge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCsnAge.Click
        Dim oAcsDdo As New VAK019.BO_VAKCsnRep
        Dim oGrpDdo As New DataSet
        Me.txtNumCtaCrr.Text = ""
        Me.lblNomAge.Text = ""
        If Me.txtNumBco.Text.Trim <> "" And Me.txtNumAge.Text.Trim <> "" Then
            oGrpDdo = oAcsDdo.CsnAgeBcoUnc(Me.txtNumBco.Text.Trim, Me.txtNumAge.Text.Trim)
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                Me.lblNomAge.Text = CType(oGrpDdo.Tables(0).Rows(0)(1), String)
            Else
                Me.lblNomAge.Text = "Agência inexistente"
            End If
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Evento mudar CEP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[crsilva]	15/4/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub csnCep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csnCep.Click
        Dim oGrpDdo As New DataSet
        Dim oAcsDdo As New VAK019.BO_VAKCsnRep
        Dim sCep As String

        sCep = Me.DesNumCep.Text.Trim.Replace("-", "").Replace(".", "")
        If sCep <> "" Then
            oGrpDdo = oAcsDdo.CsnCidEstCep(sCep)
            If Not (IsNothing(oGrpDdo)) AndAlso oGrpDdo.Tables(0).Rows.Count > 0 Then
                'Preenche combo cidade
                With Me.LstCid
                    .DataSource = oGrpDdo
                    .DataTextField = "NOMCID"
                    .DataValueField = "CODCID"
                    .DataBind()
                End With

                'Preenche combo estado
                With Me.LstEst
                    .DataSource = oGrpDdo
                    .DataTextField = "CODESTUNI"
                    .DataValueField = "CODESTUNI"
                    .DataBind()
                End With

                'Preenche combo bairros
                AbsLstBai()
            End If
        End If
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Server.Transfer("DocVAKAutCtt.aspx")
    End Sub

    Private Sub btnDesativar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesativar.Click
        DesNumCrtIdt.Attributes.Remove("OnFocus")
        DesNomRep.Attributes.Remove("OnFocus")
        RadBtnSex.Attributes.Remove("OnFocus")
        NumGraEcl.Attributes.Remove("OnFocus")
        LstCplEcl.Attributes.Remove("OnFocus")
        LstEstCvl.Attributes.Remove("OnFocus")
        DesNac.Attributes.Remove("OnFocus")
        DesOrgEms.Attributes.Remove("OnFocus")
        DesCshReg.Attributes.Remove("OnFocus")
        txtNumCtaCrr.Attributes.Remove("OnFocus")
        DesEnd.Attributes.Remove("OnFocus")
        NumTlf.Attributes.Remove("OnFocus")
        NumFax.Attributes.Remove("OnFocus")
        LstSitTlf.Attributes.Remove("OnFocus")
        LstSitFax.Attributes.Remove("OnFocus")
        NumCel.Attributes.Remove("OnFocus")
        LstRsi.Attributes.Remove("OnFocus")
        LstVtg.Attributes.Remove("OnFocus")
        DesNomCjg.Attributes.Remove("OnFocus")
        DesNumCrtIdtCjg.Attributes.Remove("OnFocus")
        DesNumFlhCjg.Attributes.Remove("OnFocus")
    End Sub
    Private Sub ativaScript()
        DesNumCrtIdt.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesNomRep.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        RadBtnSex.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        NumGraEcl.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstCplEcl.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstEstCvl.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesNac.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesOrgEms.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesCshReg.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        txtNumCtaCrr.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesEnd.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        NumTlf.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        NumFax.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstSitTlf.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstSitFax.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        NumCel.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstRsi.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        LstVtg.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesNomCjg.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesNumCrtIdtCjg.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
        DesNumFlhCjg.Attributes.Add("OnFocus", "javascript:if(!YNconfirm('Pelo menos uma das notas das provas deste candidato está zerada. Isso pode significar que ainda não foi realizada. Recomenda-se aguardar a realização das provas. Deseja continuar mesmo assim?')){location='DocVakAutCtt.aspx'}else{__doPostBack('btnDesativar','')}")
    End Sub


End Class