Public Class DocVAKDetRep
    Inherits System.Web.UI.Page
    Protected WithEvents LnkEdt As System.Web.UI.WebControls.LinkButton
    Protected WithEvents MsgBoxWeb As VAK016.Web.MessageBoxWeb
    Protected WithEvents ImgOrgEms As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNomRep As System.Web.UI.WebControls.Image
    Protected WithEvents ImgGerMcd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgGerVnd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEcl As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEstCvl As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNac As System.Web.UI.WebControls.Image
    Protected WithEvents ImgDatNsc As System.Web.UI.WebControls.Image
    Protected WithEvents ImgSex As System.Web.UI.WebControls.Image
    Protected WithEvents ImgUndNgc As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumCrtIdt As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumCpf As System.Web.UI.WebControls.Image
    Protected WithEvents ImgVtg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgRsi As System.Web.UI.WebControls.Image
    Protected WithEvents ImgCep As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEnd As System.Web.UI.WebControls.Image
    Protected WithEvents ImgCplBai As System.Web.UI.WebControls.Image
    Protected WithEvents ImgBai As System.Web.UI.WebControls.Image
    Protected WithEvents ImgCid As System.Web.UI.WebControls.Image
    Protected WithEvents ImgEst As System.Web.UI.WebControls.Image
    Protected WithEvents ImgDatNscCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumFlhCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNomCjg As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNumCntCrr As System.Web.UI.WebControls.Image
    Protected WithEvents ImgAgeBco As System.Web.UI.WebControls.Image
    Protected WithEvents ImgNomBco As System.Web.UI.WebControls.Image
    Protected WithEvents MsgSelTet As System.Web.UI.WebControls.Label
    Protected WithEvents ImgVlrVndTet As System.Web.UI.WebControls.Image
    Protected WithEvents MsgRstAvl As System.Web.UI.WebControls.Label
    Protected WithEvents ImgRstAvl As System.Web.UI.WebControls.Image
    Protected WithEvents ImgRstCtn As System.Web.UI.WebControls.Image
    Protected WithEvents MsgRstCtn As System.Web.UI.WebControls.Label
    Protected WithEvents DatCadCshReg As eWorld.UI.CalendarPopup
    Protected WithEvents DatNsc As eWorld.UI.CalendarPopup
    Protected WithEvents DatNscCjg As eWorld.UI.CalendarPopup
    Protected WithEvents LnkGrv As System.Web.UI.WebControls.LinkButton
    Protected WithEvents DesDatNsc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatCadCshReg As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesDatNscCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgSgmMcd As System.Web.UI.WebControls.Image
    Protected WithEvents LnkBtnEdt As System.Web.UI.WebControls.LinkButton

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents RblVldCpf As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitVldCpf As System.Web.UI.WebControls.Label
    Protected WithEvents DesAcoTrb As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitAcoTrb As System.Web.UI.WebControls.Label
    Protected WithEvents RblAcePnd As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitAcePnd As System.Web.UI.WebControls.Label
    Protected WithEvents DesPrbSrs As System.Web.UI.WebControls.TextBox
    Protected WithEvents RblPrbSrs As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitPrbSrs As System.Web.UI.WebControls.Label
    Protected WithEvents PnlPnd As System.Web.UI.WebControls.Panel
    Protected WithEvents GrpDdoRstQde As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TitRstQde As System.Web.UI.WebControls.Label
    Protected WithEvents GrpDdoCtn As System.Web.UI.WebControls.DataGrid
    Protected WithEvents GrpDdoAvl As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TitRstQld As System.Web.UI.WebControls.Label
    Protected WithEvents PnlOpnEtv As System.Web.UI.WebControls.Panel
    Protected WithEvents GrpDdoVlrVnd As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TitVlr As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoTetVnd As System.Web.UI.WebControls.Panel
    Protected WithEvents TitDdo As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCntCrr As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCntCrr As System.Web.UI.WebControls.Label
    Protected WithEvents LstAgeBco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitAge As System.Web.UI.WebControls.Label
    Protected WithEvents LstNomBco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitBco As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoBco As System.Web.UI.WebControls.Panel
    Protected WithEvents TitDatNscCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumFlhCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumFlhCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesOrgEmsCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitOrgEmsCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCrtIdtCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNumCrtIdtCjg As System.Web.UI.WebControls.Label
    Protected WithEvents DesNomCjg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNomCjg As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoCjg As System.Web.UI.WebControls.Panel
    Protected WithEvents LnkBtnDdoFlu As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoRep As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoBco As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnTetVnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoCjg As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnOpnEtv As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnPnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LstSgmMcd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitSgmMcd As System.Web.UI.WebControls.Label
    Protected WithEvents NumCel As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCel As System.Web.UI.WebControls.Label
    Protected WithEvents LstSitFax As System.Web.UI.WebControls.DropDownList
    Protected WithEvents NumFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitFax As System.Web.UI.WebControls.Label
    Protected WithEvents LstSitTlf As System.Web.UI.WebControls.DropDownList
    Protected WithEvents NumTlf As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitTlf As System.Web.UI.WebControls.Label
    Protected WithEvents LstVtg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitVtg As System.Web.UI.WebControls.Label
    Protected WithEvents LstRsi As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitRsi As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCep As System.Web.UI.WebControls.Label
    Protected WithEvents DesEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitEnd As System.Web.UI.WebControls.Label
    Protected WithEvents LstCplBai As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitCpl As System.Web.UI.WebControls.Label
    Protected WithEvents LstNomBai As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitBai As System.Web.UI.WebControls.Label
    Protected WithEvents LstCid As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitCid As System.Web.UI.WebControls.Label
    Protected WithEvents LstEst As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEst As System.Web.UI.WebControls.Label
    Protected WithEvents LstCplEcl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents NumGraEcl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEcl As System.Web.UI.WebControls.Label
    Protected WithEvents LstEstCvl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEstCvl As System.Web.UI.WebControls.Label
    Protected WithEvents DesNac As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNac As System.Web.UI.WebControls.Label
    Protected WithEvents TitDatNsc As System.Web.UI.WebControls.Label
    Protected WithEvents RadBtnSex As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TitSex As System.Web.UI.WebControls.Label
    Protected WithEvents LstEstCshReg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitEstCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents LstSitCshReg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitSitCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents TitDatCadCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents DesCshReg As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCshReg As System.Web.UI.WebControls.Label
    Protected WithEvents LstUndNgc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TitUndNgc As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumInss As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitInss As System.Web.UI.WebControls.Label
    Protected WithEvents DesOrgEms As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitOrgEms As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCrtIdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCrtIdt As System.Web.UI.WebControls.Label
    Protected WithEvents DesNumCpf As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitCpf As System.Web.UI.WebControls.Label
    Protected WithEvents DesNomRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents NomGerMcd As System.Web.UI.WebControls.Label
    Protected WithEvents TitGerMcd As System.Web.UI.WebControls.Label
    Protected WithEvents NomGerVnd As System.Web.UI.WebControls.Label
    Protected WithEvents TitGerVnd As System.Web.UI.WebControls.Label
    Protected WithEvents DesMsgRepTrbMrt As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoRep As System.Web.UI.WebControls.Panel
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
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm

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
        'Objeto
        Dim oObeCsnItfVAKRep As New VAK019.BO_VAKCsnRep
        'Dataset
        Dim oDsDdoRep As New DataSet
        Dim oDsDdoCtn As New DataSet
        Dim oDsDdoSta As New DataSet
        Dim oDsDdoRstAvl As New DataSet
        Dim oDsDdoTet As New DataSet
        Dim oDsDdoAvlRep As New DataSet
        'XML
        Dim sNumReq, sXMLDdoRep, sXMLDdoCtn, sXMLDdoSta, sXMLDdoRstAvl As String
        Dim sXMLDdoTet, sXMLDdoRcm, sXMLDdoAcoCvl, sXMLDdoTit, sXMLDdoAvlRep As String

        'Outros
        Dim sDesObs, sDesFlu, sDesInfRep As String
        Dim iNumReq As Int64

        ' Obtem o numero da requisicao diretamente da URL
        If Not Request("NumReq") Is Nothing Then
            sNumReq = Request("NumReq").ToString
        End If

        'Verifica login
        If (Session("TipRep") <> "GM") Then
            Session("CodErr") = "1"
            If (sNumReq = "") Then
                Response.Redirect("DocVAKVldUsr.aspx")
            Else
                Response.Redirect("DocVAKVldUsr.aspx?NumReq=" & sNumReq)
            End If
        End If

        If Not IsPostBack Then
            Try
                ' Reinicia as variaveis globais
                Session("objVAKUtl").pprCodSitRep = ""         ' 
                Session("objVAKUtl").pprCodRegCob = ""         ' Codigo da Regiao de Cobranca
                Session("objVAKUtl").pprTipRep = ""            ' 
                Session("objVAKUtl").pprCodGerTrp = ""         ' Gerente de Transporte
                Session("objVAKUtl").pprCodGrpVndRep = ""      ' Codigo do Grupo de Vendas (Grupo de Incentivo)
                Session("objVAKUtl").pprCodGerMcd = ""         ' Codigo do Gerente de Mercado
                Session("objVAKUtl").pprCodGerVnd = ""         ' Codigo do Gerente de Vendas
                Session("objVAKUtl").pprCodEstCshReg = ""
                Session("objVAKUtl").pprCodEst = ""            ' Codigo do Estado
                Session("objVAKUtl").pprCodCid = ""            ' Codigo da Cidade
                Session("objVAKUtl").pprCodBai = ""            ' Codigo do Bairro
                Session("objVAKUtl").pprCodCplBai = ""         ' Codigo do Complemento de Bairro
                Session("objVAKUtl").pprCodSgmMcd = ""         ' Codigo do Segmento de Mercado
                Session("objVAKUtl").pprCodBco = ""            ' Codigo do Banco
                Session("objVAKUtl").pprDigAgeBco = ""         ' Digito Verificador da Agencia do Banco
                Session("objVAKUtl").pprCodAgeBco = ""         ' Codigo da Agencia do Banco

                TitRspPrxAco.Visible = False
                RspPrxAco.Visible = False
                TitOpn.Visible = False
                NomOpn.Visible = False
                OcultaImagens()
                Esconde_Panel()

                ' Vinculando eventos a componentes de edicao
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
                SetStyle(Me.PnlDdoFlu)

                If Request("NumReq") Is Nothing Then ' Obtem numero da requisicao da var. global
                    sNumReq = Session("objVAKUtl").pprNumReqCttRep
                Else ' Obtem numero da requisicao da URL
                    sNumReq = Request("NumReq").ToString
                    iNumReq = Int64.Parse(sNumReq)
                    iNumReq = iNumReq - 168
                    sNumReq = Math.Sqrt(Double.Parse(iNumReq.ToString)).ToString
                End If

                If (sNumReq <> "") Then
                    ' Consulta a base de dados
                    sXMLDdoRep = oObeCsnItfVAKRep.CsnTotDdoRep(sNumReq, sXMLDdoCtn, sXMLDdoSta, sXMLDdoRstAvl, sXMLDdoTet, sXMLDdoRcm, sXMLDdoAcoCvl, sXMLDdoTit, sXMLDdoAvlRep, sDesObs)
                    sDesInfRep = oObeCsnItfVAKRep.FrmDdoRep(sXMLDdoRep, sXMLDdoRcm, sXMLDdoAcoCvl, sXMLDdoTit)
                    oObeCsnItfVAKRep = Nothing

                    'Converte XML pra DataSet
                    oDsDdoRep = Session("objVAKUtl").funXMLDS(sXMLDdoRep)
                    oDsDdoCtn = Session("objVAKUtl").funXMLDS(sXMLDdoCtn)
                    oDsDdoSta = Session("objVAKUtl").funXMLDS(sXMLDdoSta)
                    oDsDdoRstAvl = Session("objVAKUtl").funXMLDS(sXMLDdoRstAvl)
                    oDsDdoTet = Session("objVAKUtl").funXMLDS(sXMLDdoTet)
                    oDsDdoAvlRep = Session("objVAKUtl").funXMLDS(sXMLDdoAvlRep)

                    'Carrega informações - Representante
                    If Not oDsDdoRep Is Nothing Then
                        With oDsDdoRep.Tables(0)
                            If .Rows.Count > 0 Then
                                ' - FLUXO
                                NumReq.Text = CType(.Rows(0)("NUMREQCADREP"), String).Trim
                                NomSta.Text = CType(.Rows(0)("CODSTACADREP"), String).Trim & " - " & CType(.Rows(0)("DESSTACADREP"), String).Trim
                                'RspPrxAco = POR ENQUANTO SEM
                                LstFlu.Text = sDesObs.Trim
                                'LstFlu.Text = CType(.Rows(0)("DESOBS"), String).Trim
                                'NomOpn = NÃO PRECISA POR AINDA
                                DatSlc.Text = CType(.Rows(0)("DATSLC"), String).Trim
                                If CType(.Rows(0)("DATEFTFIM"), String).Trim <> "00:00:00" Then
                                    DatEft.Text = CType(.Rows(0)("DATEFTFIM"), String).Trim
                                    DatEft.Visible = True
                                    TitDatEft.Visible = True
                                Else
                                    DatEft.Visible = False
                                    TitDatEft.Visible = False
                                    DatEft.Text = ""
                                End If
                                ' - REPRESENTANTE                            
                                Session("objVAKUtl").pprCodGerMcd = CType(.Rows(0)("CODGERMCD"), String).Trim
                                Session("objVAKUtl").pprCodGerVnd = CType(.Rows(0)("CODGERVND"), String).Trim
                                NomGerMcd.Text = CType(.Rows(0)("CODGERMCD"), String).Trim & " - " & CType(.Rows(0)("NOMSUP"), String).Trim
                                NomGerVnd.Text = CType(.Rows(0)("CODGERVND"), String).Trim & " - " & CType(.Rows(0)("NOMGER"), String).Trim
                                DesNomRep.Text = CType(.Rows(0)("NOMREP"), String).Trim
                                DesNumCpf.Text = Session("objVAKUtl").funMascaraCPF(Session("objVAKUtl").funTiraMascara(CType(.Rows(0)("NUMCPFREP"), String).Trim))
                                DesNumCrtIdt.Text = CType(.Rows(0)("NUMDOCIDTREP"), String).Trim
                                DesOrgEms.Text = CType(.Rows(0)("NOMORGEMSDOCIDTREP"), String).Trim
                                If Not Convert.IsDBNull(.Rows(0)("NUMINSINUNACSEGSOC")) Then
                                    DesNumInss.Text = CType(.Rows(0)("NUMINSINUNACSEGSOC"), String).Trim
                                    If DesNumInss.Text = "0" Then
                                        DesNumInss.Text = ""
                                    End If
                                End If
                                LstUndNgc.SelectedItem.Value = .Rows(0)("CODUNDNGC")
                                If Not Convert.IsDBNull(.Rows(0)("NUMRGTREPCSHREG")) Then
                                    DesCshReg.Text = CType(.Rows(0)("NUMRGTREPCSHREG"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("DATRGTREPCSHREG")) Then
                                    DatCadCshReg.SelectedDate = .Rows(0)("DATRGTREPCSHREG")
                                    DesDatCadCshReg.Text = Format(DatCadCshReg.SelectedDate, "dd/MM/yyyy")
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("TIPSITREPCSHREG")) Then
                                    If CType(.Rows(0)("TIPSITREPCSHREG"), String).Trim <> "" Then
                                        'Situação Core
                                        Try
                                            LstSitCshReg.SelectedValue = Convert.ToString(.Rows(0)("TIPSITREPCSHREG")).Trim
                                            'LstSitCshReg.SelectedValue = .Rows(0)("TIPSITREPCSHREG")
                                        Catch oObeEcc As Exception : LstSitCshReg.SelectedIndex = 0
                                        End Try
                                    End If
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("CODESTUNICSHREG")) Then
                                    LstEstCshReg.Items.Add(CType(.Rows(0)("CODESTUNICSHREG"), String).Trim)
                                    Session("objVAKUtl").pprCodEstCshReg = .Rows(0)("CODESTUNICSHREG")
                                End If
                                RadBtnSex.SelectedValue = .Rows(0)("CODSEX")
                                DatNsc.SelectedDate = .Rows(0)("DATNSCREP")
                                DesDatNsc.Text = Format(DatNsc.SelectedDate, "dd/MM/yyyy")
                                DesNac.Text = .Rows(0)("NOMNACREP")
                                LstEstCvl.SelectedValue = .Rows(0)("TIPESTCVLREP")
                                NumGraEcl.SelectedValue = .Rows(0)("CODGRAECLREP")
                                LstCplEcl.SelectedValue = .Rows(0)("TIPSITECLREP")
                                Session("objVAKUtl").pprCodEst = .Rows(0)("CODESTUNI")
                                LstEst.Items.Add(CType(.Rows(0)("CODESTUNI"), String).Trim)
                                LstCid.Items.Add(CType(.Rows(0)("NOMCID"), String).Trim & " - " & CType(.Rows(0)("CODCIDREP"), String).Trim)
                                LstCid.Visible = True
                                Session("objVAKUtl").pprCodCid = .Rows(0)("CODCIDREP")
                                LstNomBai.Items.Add(CType(.Rows(0)("NOMBAI"), String).Trim & " - " & CType(.Rows(0)("CODBAI"), String).Trim)
                                Session("objVAKUtl").pprCodBai = .Rows(0)("CODBAI")
                                If Not Convert.IsDBNull(.Rows(0)("CODCPLBAI")) Then
                                    If Not Convert.IsDBNull(.Rows(0)("NOMCPLBAI")) Then
                                        LstCplBai.Items.Add(CType(.Rows(0)("NOMCPLBAI"), String).Trim & " - " & CType(.Rows(0)("CODCPLBAI"), String).Trim)
                                        LstCplBai.SelectedItem.Value = CType(.Rows(0)("CODCPLBAI"), String).Trim
                                        Session("objVAKUtl").pprCodCplBai = .Rows(0)("CODCPLBAI")
                                    End If
                                End If
                                LstCplBai.Visible = True

                                'DesEnd.Text = CType(.Rows(0)("ENDREP"), String).Trim
                                Dim str As String
                                str = CType(.Rows(0)("ENDREP"), String).Trim
                                If str.Length > DesEnd.MaxLength Then
                                    str = str.Substring(0, DesEnd.MaxLength - 1)
                                End If
                                DesEnd.Text = str


                                DesNumCep.Text = Session("objVAKUtl").funMascaraCEP(Session("objVAKUtl").funTiraMascara(CType(.Rows(0)("CODCEPREP"), String).Trim))
                                If Not Convert.IsDBNull(.Rows(0)("TIPSITRSIREP")) Then
                                    LstRsi.SelectedValue = .Rows(0)("TIPSITRSIREP")
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("TIPVTGRSIREP")) Then
                                    LstVtg.SelectedValue = .Rows(0)("TIPVTGRSIREP")
                                End If

                                ' Telefone do RCA
                                If Not Convert.IsDBNull(.Rows(0)("NUMTLFREP")) Then
                                    NumTlf.Text = CType(.Rows(0)("NUMTLFREP"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("TIPSITTLFREP")) Then
                                    'LstSitTlf.SelectedValue = .Rows(0)("TIPSITTLFREP")
                                    Dim aux As String
                                    aux = .Rows(0)("TIPSITTLFREP").trim
                                    If (Not aux Is Nothing) And (aux.Equals("S") Or aux.Equals("N") Or aux.Equals("A") Or aux.Equals("P")) Then
                                        LstSitTlf.SelectedValue = aux
                                    End If
                                    aux = Nothing
                                End If
                                ' FAX do RCA
                                If Not Convert.IsDBNull(.Rows(0)("NUMFAXREP")) Then
                                    NumFax.Text = CType(.Rows(0)("NUMFAXREP"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("TIPSITFAXREP")) Then
                                    'LstSitFax.SelectedValue = .Rows(0)("TIPSITFAXREP")
                                    Dim aux As String = .Rows(0)("TIPSITFAXREP")
                                    If (Not aux Is Nothing) And (aux.Equals("S") Or aux.Equals("N") Or aux.Equals("A") Or aux.Equals("P")) Then
                                        LstSitFax.SelectedValue = aux
                                    End If
                                    aux = Nothing
                                End If

                                ' Celular do RCA
                                If Not Convert.IsDBNull(.Rows(0)("NUMTLFCELREP")) Then
                                    NumCel.Text = CType(.Rows(0)("NUMTLFCELREP"), String).Trim
                                End If

                                LstSgmMcd.Items.Add(.Rows(0)("DESSGMMCD") & " - " & .Rows(0)("CODSGMMCD"))
                                Session("objVAKUtl").pprCodSgmMcd = .Rows(0)("CODSGMMCD")
                                ' - CONJUGE
                                If Not Convert.IsDBNull(.Rows(0)("NOMDEPREP")) Then
                                    DesNomCjg.Text = CType(.Rows(0)("NOMDEPREP"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("NUMDOCIDT")) Then
                                    DesNumCrtIdtCjg.Text = CType(.Rows(0)("NUMDOCIDT"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("NOMORGEMSDOCIDTDEP")) Then
                                    DesOrgEmsCjg.Text = CType(.Rows(0)("NOMORGEMSDOCIDTDEP"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("QDEFLHREP")) Then
                                    DesNumFlhCjg.Text = CType(.Rows(0)("QDEFLHREP"), String).Trim
                                End If
                                If Not Convert.IsDBNull(.Rows(0)("DATNSCDEP")) Then
                                    DatNscCjg.SelectedDate = .Rows(0)("DATNSCDEP")
                                    DesDatNscCjg.Text = Format(DatNscCjg.SelectedDate, "dd/MM/yyyy")
                                End If
                                ' - BANCO
                                LstNomBco.Items.Add(CType(.Rows(0)("NOMBCO"), String).Trim & " - " & CType(.Rows(0)("CODBCOREP"), String).Trim)
                                Session("objVAKUtl").pprCodBco = .Rows(0)("CODBCOREP")
                                LstAgeBco.Items.Add(CType(.Rows(0)("CODAGEBCOREP"), String).Trim & "-" & CType(.Rows(0)("NUMDIGVRFAGEBCOREP"), String).Trim & " - " & CType(.Rows(0)("NOMAGEBCO"), String).Trim)
                                Session("objVAKUtl").pprDigAgeBco = .Rows(0)("NUMDIGVRFAGEBCOREP")
                                Session("objVAKUtl").pprCodAgeBco = .Rows(0)("CODAGEBCOREP")
                                If Not Convert.IsDBNull(.Rows(0)("CODCNTCRRBCOREP")) Then
                                    DesNumCntCrr.Text = CType(.Rows(0)("CODCNTCRRBCOREP"), String).Trim
                                End If
                                ' - PENDENCIAS
                                RblPrbSrs.SelectedValue = .Rows(0)("INDRTCCRD")
                                DesPrbSrs.Text = sDesInfRep.Trim
                                RblAcePnd.SelectedValue = .Rows(0)("INDACEPND")
                                If Not Convert.IsDBNull(.Rows(0)("DESACOTRBREP")) Then
                                    DesAcoTrb.Text = CType(.Rows(0)("DESACOTRBREP"), String).Trim
                                End If
                                RblVldCpf.SelectedValue = .Rows(0)("INDVLDCPF")
                                'DesVldCpf = POR ENQUANTO SEM
                            End If
                        End With
                    End If
                    'Carrega informações - Competência
                    If Not oDsDdoCtn Is Nothing Then
                        If oDsDdoCtn.Tables(0).Rows.Count > 0 Then
                            GrpDdoCtn.DataSource = oDsDdoCtn.Tables(0).DefaultView
                            GrpDdoCtn.DataBind()
                            GrpDdoCtn.Visible = True
                        End If
                    End If
                    'Carrega informações - Status
                    If Not oDsDdoSta Is Nothing Then
                        If oDsDdoSta.Tables(0).Rows.Count > 0 Then
                            oDsDdoSta.Tables(0).DefaultView.Sort = "DATHRAULTALT"
                            GrpDdoStaFlu.DataSource = oDsDdoSta.Tables(0).DefaultView
                            GrpDdoStaFlu.DataBind()
                            GrpDdoStaFlu.Visible = True
                        End If
                    End If
                    'Carrega informações - Resultado Avaliação
                    If Not oDsDdoRstAvl Is Nothing Then
                        If oDsDdoRstAvl.Tables(0).Rows.Count > 0 Then
                            GrpDdoRstQde.DataSource = oDsDdoRstAvl.Tables(0).DefaultView
                            GrpDdoRstQde.DataBind()
                            GrpDdoRstQde.Visible = True
                        End If
                    End If

                    Dim currCult As System.Globalization.CultureInfo
                    Dim newCult As System.Globalization.CultureInfo
                    currCult = System.Threading.Thread.CurrentThread.CurrentCulture  REM armazena a cultura atual
                    newCult = New System.Globalization.CultureInfo("en-US", False)          REM forca para ser en-US
                    System.Threading.Thread.CurrentThread.CurrentCulture = newCult

                    'Carrega informações - Território
                    If Not oDsDdoTet Is Nothing Then
                        If oDsDdoTet.Tables(0).Rows.Count > 0 Then
                            ' Formata os valores segundo o padrao numerico "Portugues do Brasil"
                            Dim aux_1, aux_2, aux_3 As String
                            For i As Int16 = 0 To oDsDdoTet.Tables(0).Rows.Count - 1
                                aux_1 = Session("objVAKUtl").funFrmStrNro(oDsDdoTet.Tables(0).Rows(i).Item("STRVLRCMP1"))
                                aux_1 = Decimal.Parse(aux_1).ToString("N")
                                oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP1") = aux_1.Replace(",", "+").Replace(".", ",").Replace("+", ".")

                                aux_2 = Session("objVAKUtl").funFrmStrNro(oDsDdoTet.Tables(0).Rows(i).Item("STRVLRCMP2"))
                                aux_2 = Decimal.Parse(aux_2).ToString("N")
                                oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP2") = aux_2.Replace(",", "+").Replace(".", ",").Replace("+", ".")

                                aux_3 = Session("objVAKUtl").funFrmStrNro(oDsDdoTet.Tables(0).Rows(i).Item("STRVLRCMP3"))
                                aux_3 = Decimal.Parse(aux_3).ToString("N")

                                'oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP3") = aux_3.Replace(",", "+").Replace(".", ",").Replace("+", ".")
                                'aux_1 = CType(oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP1"), Double)
                                'aux_2 = CType(oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP2"), Double)
                                'aux_3 = CType(oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP3"), Double)
                                'oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP1") = VAKUtl.funFrmNum(CStr(aux_1))
                                'oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP2") = VAKUtl.funFrmNum(CStr(aux_2))
                                'oDsDdoTet.Tables(0).Rows(i).Item("VLRCMP3") = VAKUtl.funFrmNum(CStr(aux_3))
                            Next
                            System.Threading.Thread.CurrentThread.CurrentCulture = currCult  REM retorna ao estado anterior
                            currCult = Nothing
                            newCult = Nothing


                            GrpDdoVlrVnd.DataSource = oDsDdoTet.Tables(0).DefaultView
                            GrpDdoVlrVnd.Columns(4).HeaderText = Right$(oDsDdoTet.Tables(0).Rows(0)(4), 2) & "/" & Left$(oDsDdoTet.Tables(0).Rows(0)(4), 4)
                            GrpDdoVlrVnd.Columns(5).HeaderText = Right$(oDsDdoTet.Tables(0).Rows(0)(6), 2) & "/" & Left$(oDsDdoTet.Tables(0).Rows(0)(6), 4)
                            GrpDdoVlrVnd.Columns(6).HeaderText = Right$(oDsDdoTet.Tables(0).Rows(0)(8), 2) & "/" & Left$(oDsDdoTet.Tables(0).Rows(0)(8), 4)
                            GrpDdoVlrVnd.DataBind()
                            GrpDdoVlrVnd.Visible = True
                        End If
                    End If

                    'Carrega informações - Avaliação
                    If Not oDsDdoAvlRep Is Nothing Then
                        If oDsDdoAvlRep.Tables(0).Rows.Count > 0 Then
                            GrpDdoAvl.DataSource = oDsDdoAvlRep.Tables(0).DefaultView
                            GrpDdoAvl.DataBind()
                            GrpDdoAvl.Visible = True
                        End If
                    End If
                    Err("")
                End If

            Catch oErr As Exception
                Err(oErr.Message)
            End Try
        End If
    End Sub

    Private Sub Err(ByVal s As String)
        Response.Write(Session("objVAKUtl").funSetErr(s))
    End Sub

    Private Sub Esconde_Panel()
        Me.PnlDdoFlu.Visible = False
        Me.PnlDdoRep.Visible = False
        Me.PnlDdoCjg.Visible = False
        Me.PnlDdoBco.Visible = False
        Me.PnlDdoTetVnd.Visible = False
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

    Private Sub LnkBtnDdoBco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnDdoBco.Click
        Esconde_Panel()
        SetStyle(PnlDdoBco)
    End Sub

    Private Sub LnkBtnTetVnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnTetVnd.Click
        Esconde_Panel()
        SetStyle(Me.PnlDdoTetVnd)
    End Sub

    Private Sub LnkBtnOpnEtv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnOpnEtv.Click
        Esconde_Panel()
        SetStyle(Me.PnlOpnEtv)
    End Sub

    Private Sub LnkBtnPnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnPnd.Click
        Esconde_Panel()
        SetStyle(Me.PnlPnd)
    End Sub

    Private Sub LnkEdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkEdt.Click
        'Objeto
        Dim oObeEdtItfVAKRep As New VAK019.BO_VAKCsnRep
        'Dataset
        Dim oDsDdoEst As New DataSet
        Dim oDsDdoCid As New DataSet
        Dim oDsDdoBai As New DataSet
        Dim oDsDdoCplBai As New DataSet
        Dim oDsDdoSgmMcd As New DataSet
        Dim oDsDdoBco As New DataSet
        Dim oDsDdoAgeBco As New DataSet
        'XML
        Dim sXMLDdoEst, sXMLDdoCid, sXMLDdoBai, sXMLDdoCplBai, sXMLDdoBco, sXMLDdoAgeBco, sXMLDdoSgmMcd As String
        'Outros
        Dim AuxRow As DataRow
        Try
            If oObeEdtItfVAKRep.CsnInfAltRep(Session("objVAKUtl").pprCodEst, Session("objVAKUtl").pprCodCid, Session("objVAKUtl").pprCodBai, Session("objVAKUtl").pprCodBco, sXMLDdoEst, sXMLDdoCid, sXMLDdoBai, sXMLDdoCplBai, sXMLDdoBco, sXMLDdoAgeBco, sXMLDdoSgmMcd) Then
                'Estados
                oDsDdoEst = Session("objVAKUtl").funXMLToDataSet(sXMLDdoEst, 0, 0, "C")
                If Not oDsDdoEst Is Nothing Then
                    'Carrega lista de estados core
                    LstEstCshReg.DataSource = oDsDdoEst.Tables(0)
                    LstEstCshReg.DataValueField = oDsDdoEst.Tables(0).Columns(0).ColumnName
                    LstEstCshReg.DataTextField = oDsDdoEst.Tables(0).Columns(0).ColumnName
                    LstEstCshReg.Items.Add("")
                    LstEstCshReg.DataBind()
                    'Carrega lista de estados
                    LstEst.DataSource = oDsDdoEst.Tables(0)
                    LstEst.DataValueField = oDsDdoEst.Tables(0).Columns(0).ColumnName
                    LstEst.DataTextField = oDsDdoEst.Tables(0).Columns(0).ColumnName
                    LstEst.Items.Add("")
                    LstEst.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Estados.")
                End If

                'Cidade
                oDsDdoCid = Session("objVAKUtl").funXMLToDataSet(sXMLDdoCid, 0, 1, "D")
                If Not oDsDdoCid Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoCid.Tables(0).NewRow
                    AuxRow("CODCID") = -1
                    AuxRow("NOMCID") = ""
                    oDsDdoCid.Tables(0).Rows.Add(AuxRow)
                    oDsDdoCid.Tables(0).DefaultView.Sort = "NOMCID"

                    'Carrega lista de cidades do estado
                    LstCid.DataSource = oDsDdoCid.Tables(0).DefaultView
                    LstCid.DataValueField = oDsDdoCid.Tables(0).Columns(0).ColumnName
                    LstCid.DataTextField = oDsDdoCid.Tables(0).Columns(1).ColumnName
                    LstCid.Items.Add("")
                    LstCid.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Cidades.")
                End If

                'Bairro
                oDsDdoBai = Session("objVAKUtl").funXMLToDataSet(sXMLDdoBai, 0, 1, "D")
                If Not oDsDdoBai Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoBai.Tables(0).NewRow
                    AuxRow("CODBAI") = -1
                    AuxRow("NOMBAI") = ""
                    oDsDdoBai.Tables(0).Rows.Add(AuxRow)
                    oDsDdoBai.Tables(0).DefaultView.Sort = "NOMBAI"

                    'Carrega lista de bairros da cidade
                    LstNomBai.DataSource = oDsDdoBai.Tables(0).DefaultView
                    LstNomBai.DataValueField = oDsDdoBai.Tables(0).Columns(0).ColumnName
                    LstNomBai.DataTextField = oDsDdoBai.Tables(0).Columns(1).ColumnName
                    LstNomBai.Items.Add("")
                    LstNomBai.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Bairros.")
                End If

                'Complemento do Bairro
                oDsDdoCplBai = Session("objVAKUtl").funXMLToDataSet(sXMLDdoCplBai, 0, 1, "D")
                If Not oDsDdoCplBai Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoCplBai.Tables(0).NewRow
                    AuxRow("CODCPLBAI") = -1
                    AuxRow("NOMCPLBAI") = ""
                    oDsDdoCplBai.Tables(0).Rows.Add(AuxRow)
                    oDsDdoCplBai.Tables(0).DefaultView.Sort = "NOMCPLBAI"

                    'Carrega lista de complemento de bairros da cidade
                    LstCplBai.DataSource = oDsDdoCplBai.Tables(0)
                    LstCplBai.DataValueField = oDsDdoCplBai.Tables(0).Columns(0).ColumnName
                    LstCplBai.DataTextField = oDsDdoCplBai.Tables(0).Columns(1).ColumnName
                    LstCplBai.Items.Add("")
                    LstCplBai.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Complementos do Bairro.")
                End If

                'Banco
                oDsDdoBco = Session("objVAKUtl").funXMLToDataSet(sXMLDdoBco, 0, 1, "D")
                If Not oDsDdoBco Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoBco.Tables(0).NewRow
                    AuxRow("CODBCO") = -1
                    AuxRow("NOMBCO") = ""
                    oDsDdoBco.Tables(0).Rows.Add(AuxRow)
                    oDsDdoBco.Tables(0).DefaultView.Sort = "NOMBCO"

                    LstNomBco.DataSource = oDsDdoBco.Tables(0).DefaultView
                    LstNomBco.DataValueField = oDsDdoBco.Tables(0).Columns(0).ColumnName
                    LstNomBco.DataTextField = oDsDdoBco.Tables(0).Columns(1).ColumnName
                    LstNomBco.Items.Add("")
                    LstNomBco.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Bancos.")
                End If

                'Agência Banco
                oDsDdoAgeBco = Session("objVAKUtl").funXMLToDataSet(sXMLDdoAgeBco, 0, 1, "3")
                If Not oDsDdoAgeBco Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoAgeBco.Tables(0).NewRow
                    AuxRow("CODAGEBCO") = -1
                    AuxRow("NOMAGEBCO") = ""
                    AuxRow("NUMDIGVRFAGEBCO") = ""
                    oDsDdoAgeBco.Tables(0).Rows.Add(AuxRow)
                    oDsDdoAgeBco.Tables(0).DefaultView.Sort = "NOMAGEBCO"

                    'Carrega lista de agencias do banco
                    LstAgeBco.DataSource = oDsDdoAgeBco.Tables(0)
                    LstAgeBco.DataValueField = oDsDdoAgeBco.Tables(0).Columns(0).ColumnName
                    LstAgeBco.DataTextField = oDsDdoAgeBco.Tables(0).Columns(1).ColumnName
                    LstAgeBco.Items.Add("")
                    LstAgeBco.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Agências do Banco.")
                End If

                'Segmento de Mercado
                oDsDdoSgmMcd = Session("objVAKUtl").funXMLToDataSet(sXMLDdoSgmMcd, 0, 1, "D")
                If Not oDsDdoSgmMcd Is Nothing Then
                    'Insere registro vazio
                    AuxRow = oDsDdoSgmMcd.Tables(0).NewRow
                    AuxRow("CODSGMMCD") = -1
                    AuxRow("DESSGMMCD") = ""
                    oDsDdoSgmMcd.Tables(0).Rows.Add(AuxRow)
                    oDsDdoSgmMcd.Tables(0).DefaultView.Sort = "DESSGMMCD"

                    LstSgmMcd.DataSource = oDsDdoSgmMcd.Tables(0).DefaultView
                    LstSgmMcd.DataValueField = oDsDdoSgmMcd.Tables(0).Columns(0).ColumnName
                    LstSgmMcd.DataTextField = oDsDdoSgmMcd.Tables(0).Columns(1).ColumnName
                    LstSgmMcd.DataBind()
                Else
                    Throw New Exception("Erro ao carregar informações para edição do registro - Segmentos de Mercado.")
                End If

                DesNomRep.Enabled = True
                DesNumCrtIdt.Enabled = True
                DesOrgEms.Enabled = True
                DesNumInss.Enabled = True
                LstUndNgc.Enabled = True
                DesCshReg.Enabled = True
                DatCadCshReg.Enabled = True
                DesDatCadCshReg.Enabled = True

                LstSitCshReg.Enabled = True

                If Session("objVAKUtl").pprCodEstCshReg <> "" Then
                    LstEstCshReg.SelectedValue = Session("objVAKUtl").pprCodEstCshReg
                End If
                LstEstCshReg.Enabled = True

                RadBtnSex.Enabled = True
                DatNsc.Enabled = True
                DesDatNsc.Enabled = True

                DesNac.Enabled = True
                LstEstCvl.Enabled = True
                NumGraEcl.Enabled = True
                LstCplEcl.Enabled = True
                If Session("objVAKUtl").pprCodEst <> "" Then
                    LstEst.SelectedValue = Session("objVAKUtl").pprCodEst
                End If
                LstEst.Enabled = True
                If Session("objVAKUtl").pprCodCid <> "" Then
                    LstCid.SelectedValue = Session("objVAKUtl").pprCodCid
                End If
                LstCid.Enabled = True
                If Session("objVAKUtl").pprCodBai <> "" Then
                    LstNomBai.SelectedValue = Session("objVAKUtl").pprCodBai
                End If
                LstNomBai.Enabled = True
                If Session("objVAKUtl").pprCodCplBai <> "" Then
                    LstCplBai.SelectedValue = Session("objVAKUtl").pprCodCplBai
                End If
                LstCplBai.Enabled = True

                DesEnd.Enabled = True
                DesNumCep.Enabled = True
                LstRsi.Enabled = True
                LstVtg.Enabled = True
                NumTlf.Enabled = True
                LstSitTlf.Enabled = True
                NumFax.Enabled = True
                LstSitFax.Enabled = True
                NumCel.Enabled = True
                If Session("objVAKUtl").pprCodSgmMcd <> "" Then
                    LstSgmMcd.SelectedValue = Session("objVAKUtl").pprCodSgmMcd
                End If
                LstSgmMcd.Enabled = True

                ' - CONJUGE
                DesNomCjg.Enabled = True
                DesNumCrtIdtCjg.Enabled = True
                DesOrgEmsCjg.Enabled = True
                DesNumFlhCjg.Enabled = True
                DatNscCjg.Enabled = True
                DesDatNscCjg.Enabled = True

                ' - BANCO
                If Session("objVAKUtl").pprCodBco <> "" Then
                    LstNomBco.SelectedValue = Session("objVAKUtl").pprCodBco
                End If
                LstNomBco.Enabled = True
                If Session("objVAKUtl").pprCodAgeBco <> "" Then
                    LstAgeBco.SelectedValue = Session("objVAKUtl").pprCodAgeBco
                End If
                LstAgeBco.Enabled = True
                DesNumCntCrr.Enabled = True
                RblVldCpf.Enabled = True
                RblPrbSrs.Enabled = True
                Err("")
            Else
                Throw New Exception("Erro ao carregar informações para edição do registro.")
            End If
        Catch oErr As Exception
            Err(oErr.Message)
        End Try
    End Sub

    Private Function AgeBco_Load(ByVal sCodBco As String) As String
        Try
            Dim oObeCsnAgeBcoItf As New VAK019.BO_VAKCsnRep
            AgeBco_Load = oObeCsnAgeBcoItf.CsnAgeBco(sCodBco)
            Err("")
        Catch oErr As Exception
            Err(oErr.Message)
            AgeBco_Load = "<xml></xml>"
        End Try
    End Function

    Private Sub AgeBco_Sel()
        Dim oAuxDs As New DataSet
        Dim oAuxRow
        LstAgeBco.DataSource = Nothing
        LstAgeBco.Items.Clear()
        If LstNomBco.SelectedItem.Text <> "" Then
            oAuxDs = Session("objVAKUtl").funXMLToDataSet(AgeBco_Load(LstNomBco.SelectedItem.Value), 0, 1, "3")
            If oAuxDs.Tables(0).Rows.Count > 0 Then
                'Insere registro vazio
                oAuxRow = oAuxDs.Tables(0).NewRow
                oAuxRow("CODAGEBCO") = -1
                oAuxRow("NOMAGEBCO") = ""
                oAuxRow("NUMDIGVRFAGEBCO") = ""
                oAuxDs.Tables(0).Rows.Add(oAuxRow)
                oAuxDs.Tables(0).DefaultView.Sort = "NOMAGEBCO"
                Session("objVAKUtl").pprDigAgeBco = ""

                'Carrega lista de agencias do banco
                LstAgeBco.DataSource = oAuxDs.Tables(0)
                LstAgeBco.DataValueField = oAuxDs.Tables(0).Columns(0).ColumnName
                LstAgeBco.DataTextField = oAuxDs.Tables(0).Columns(1).ColumnName
                LstAgeBco.Items.Add("")
                LstAgeBco.DataBind()
            End If
        End If
    End Sub

    Private Sub lstNomBco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstNomBco.SelectedIndexChanged
        AgeBco_Sel()
    End Sub

    Private Function Cid_Load(ByVal sCodEst As String) As String
        Try
            Dim oObeCsnCidItf As New VAK019.BO_VAKCsnRep
            Cid_Load = oObeCsnCidItf.CsnCid(sCodEst)
            Err("")
        Catch oErr As Exception
            Err(oErr.Message)
            Cid_Load = "<xml></xml>"
        End Try
    End Function

    Private Function Bai_Load(ByVal sCodCid As String) As String
        Try
            Dim oObeCsnBaiItf As New VAK019.BO_VAKCsnRep
            Bai_Load = oObeCsnBaiItf.CsnBai(sCodCid)
            Err("")
        Catch oErr As Exception
            Err(oErr.Message)
            Bai_Load = "<xml></xml>"
        End Try
    End Function

    Private Function CplBai_Load(ByVal sCodBai As String) As String
        Try
            Dim oObeCsnCplBaiItf As New VAK019.BO_VAKCsnRep
            CplBai_Load = oObeCsnCplBaiItf.CsnCplBai(sCodBai)
            Err("")
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
            Err("")
        Catch oErr As Exception
            Err(oErr.Message)
            InfRepCpf_Load = False
        End Try
    End Function

    Private Sub lstEst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstEst.SelectedIndexChanged
        Dim oAuxDs As New DataSet
        Dim oAuxRow As DataRow

        LstCid.DataSource = Nothing
        LstCid.Items.Clear()
        If LstEst.SelectedItem.Text <> "" Then
            oAuxDs = Session("objVAKUtl").funXMLToDataSet(Cid_Load(LstEst.SelectedItem.Text), 0, 1, "D")
            If oAuxDs.Tables(0).Rows.Count > 0 Then
                'Insere registro vazio
                oAuxRow = oAuxDs.Tables(0).NewRow
                oAuxRow("CODCID") = -1
                oAuxRow("NOMCID") = ""
                oAuxDs.Tables(0).Rows.Add(oAuxRow)
                oAuxDs.Tables(0).DefaultView.Sort = "NOMCID"

                'Carrega lista de cidades do estado
                LstCid.DataSource = oAuxDs.Tables(0).DefaultView
                LstCid.DataValueField = oAuxDs.Tables(0).Columns(0).ColumnName
                LstCid.DataTextField = oAuxDs.Tables(0).Columns(1).ColumnName
                LstCid.Items.Add("")
                LstCid.DataBind()
            End If
        End If
    End Sub

    Private Sub lstCid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstCid.SelectedIndexChanged
        Dim oAuxDs As New DataSet
        Dim oAuxRow As DataRow
        LstNomBai.DataSource = Nothing
        LstNomBai.Items.Clear()
        If LstCid.SelectedItem.Text <> "" Then
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

    Private Sub lstNomBai_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstNomBai.SelectedIndexChanged
        Dim oAuxDs As New DataSet
        Dim oAuxRow As DataRow
        LstCplBai.DataSource = Nothing
        LstCplBai.Items.Clear()
        If LstNomBai.SelectedItem.Text <> "" Then
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
            Dim str As String
            str = Me.LstNomBai.SelectedItem.Text.Substring(0, Me.LstNomBai.SelectedItem.Text.LastIndexOf("-"))
            If str.Length > DesEnd.MaxLength Then
                str = str.Substring(0, DesEnd.MaxLength - 1)
            End If
            Me.DesEnd.Text = str
        End If
    End Sub

    Private Sub DesNumCpf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesNumCpf.TextChanged
        Dim oAuxDs As New DataSet
        Dim sAuxCpf, sAuxIdtRep, sAuxRstPva, sAuxAcePnd, sAuxAcoTrb, sAuxIdtRepTmp As String

        If DesNumCpf.Text.Trim <> "" Then
            sAuxCpf = Session("objVAKUtl").funTiraMascara(DesNumCpf.Text.Trim)
            DesNumCpf.Text = Session("objVAKUtl").funMascaraCPF(sAuxCpf)
            If Session("objVAKUtl").funVerificaCPF(DesNumCpf.Text.Trim) Then
                If InfRepCpf_Load(sAuxCpf, sAuxIdtRep, sAuxRstPva, sAuxAcePnd, sAuxAcoTrb, sAuxIdtRepTmp) Then
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxIdtRep)
                    If oAuxDs.Tables(0).Rows.Count > 0 Then
                        'Identifica representante trabalhou no Martins
                        DesMsgRepTrbMrt.Text = "Este representante já trabalhou no Martins de " & _
                           oAuxDs.Tables(0).Rows(0)(1) & " ate " & oAuxDs.Tables(0).Rows(0)(0)
                        DesMsgRepTrbMrt.Visible = True
                    Else : DesMsgRepTrbMrt.Visible = False
                    End If
                    'Resultado da prova
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxRstPva)
                    Session("objVAKUtl").pprGrpDdoRstPva = oAuxDs
                    'Acerto pendente
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxAcePnd)
                    Session("objVAKUtl").pprGrpDdoAcePnd = oAuxDs
                    'Ações trabalhistas
                    oAuxDs = Session("objVAKUtl").funXMLDS(sAuxAcoTrb)
                    Session("objVAKUtl").pprGrpDdoAcoTrb = oAuxDs
                    'Verifica acertos pendentes
                    If Not Session("objVAKUtl").pprGrpDdoAcePnd Is Nothing Then
                        If Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows.Count > 0 Then
                            If (Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows(0)(0) <> "01/01/0001" And _
                                Session("objVAKUtl").pprGrpDdoAcePnd.Tables(0).Rows(0)(1) = "01/01/0001") Then
                                RblAcePnd.SelectedValue = "1"
                                MsgBoxWeb.Text = "Existem acertos pendentes para este representante. Não será possível prosseguir com o cadastro."
                                MsgBoxWeb.Redirecionar = "DocVAKAutCtt.aspx"
                            Else
                                RblAcePnd.SelectedValue = "0"
                            End If
                        Else
                            RblAcePnd.SelectedValue = "0"
                        End If
                    Else
                        RblAcePnd.SelectedValue = "0"
                    End If
                    'Verifica ações trabalhistas
                    If Not Session("objVAKUtl").pprGrpDdoAcoTrb Is Nothing Then
                        If Session("objVAKUtl").pprGrpDdoAcoTrb.Tables(0).Rows.Count > 0 Then
                            DesAcoTrb.Text = Session("objVAKUtl").pprGrpDdoAcoTrb.Tables(0).Rows(0)(0)
                        Else
                            DesAcoTrb.Text = ""
                        End If
                    Else
                        DesAcoTrb.Text = ""
                    End If
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

    Private Sub DesNumInss_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesNumInss.TextChanged
        If DesNumInss.Text.Trim <> "" Then
            If Not Session("objVAKUtl").funVerificaINSS(DesNumInss.Text.Trim) Then
                MsgBoxWeb.Text = "INSS inválido!"
                DesNumInss.Text = ""
            End If
        End If
    End Sub

    Private Sub LstAgeBco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstAgeBco.SelectedIndexChanged
        If LstAgeBco.SelectedItem.Text <> "" Then
            Session("objVAKUtl").pprDigAgeBco = Mid$(LstAgeBco.SelectedItem.Text.Trim, 7, 1)
        Else
            Session("objVAKUtl").pprDigAgeBco = ""
        End If
    End Sub

    Function VerificaPreenchimento() As Boolean
        Dim bErro As Boolean
        bErro = False

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
        If LstUndNgc.SelectedValue.Trim <> "" Then
            ImgUndNgc.Visible = False
        Else
            ImgUndNgc.Visible = True
            bErro = True
        End If
        'Sexo
        If RadBtnSex.SelectedValue.Trim <> "" Then
            ImgSex.Visible = False
        Else
            ImgSex.Visible = True
            bErro = True
        End If
        'Data Nascimento
        If DatNsc.SelectedDate.ToString <> "" Then
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
        If LstEst.SelectedValue.Trim <> "" Then
            ImgEst.Visible = False
        Else
            ImgEst.Visible = True
            bErro = True
        End If
        'Cidade
        If LstCid.SelectedValue.Trim <> "" Then
            ImgCid.Visible = False
        Else
            ImgCid.Visible = True
            bErro = True
        End If
        'Bairro
        If LstNomBai.SelectedValue.Trim <> "" Then
            ImgBai.Visible = False
        Else
            ImgBai.Visible = True
            bErro = True
        End If
        'Endereço
        If DesEnd.Text.Trim <> "" Then
            ImgEnd.Visible = False
        Else
            ImgEnd.Visible = True
            bErro = True
        End If
        'Cep
        If DesNumCep.Text.Trim <> "" Then
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
        If LstNomBco.SelectedValue.Trim <> "" Then
            ImgNomBco.Visible = False
        Else
            ImgNomBco.Visible = True
            bErro = True
        End If
        'Agencia
        If LstAgeBco.SelectedValue.Trim <> "" Then
            ImgAgeBco.Visible = False
        Else
            ImgAgeBco.Visible = True
            bErro = True
        End If
        'Conta Corrente
        If DesNumCntCrr.Text.Trim <> "" Then
            ImgNumCntCrr.Visible = False
        ElseIf LstNomBco.SelectedValue <> 33 Then
            ImgNumCntCrr.Visible = True
            bErro = True
        End If

        Return Not bErro
    End Function

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
        ImgNomCjg.Visible = False
        ImgNumFlhCjg.Visible = False
        ImgDatNscCjg.Visible = False
        ImgNomBco.Visible = False
        ImgAgeBco.Visible = False
        ImgNumCntCrr.Visible = False
        ImgVlrVndTet.Visible = False
        MsgSelTet.Visible = False
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
            Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function

    Function ConstroiXMLTetRep()
        Dim iIndice As Integer
        Dim sAuxXML, sCod, sMes1, sMes2, sMes3, sVal1, sVal2, sVal3 As String
        Try
            sAuxXML = "<?xml version='1.0'?>" & Chr(13) & _
                      "    <dados> " & Chr(13)
            For iIndice = 0 To GrpDdoVlrVnd.Items.Count - 1
                sCod = GrpDdoVlrVnd.Items(iIndice).Cells(0).Text.Trim
                sMes1 = Right$(GrpDdoVlrVnd.Columns(4).HeaderText, 4) & Left$(GrpDdoVlrVnd.Columns(4).HeaderText, 2)
                sMes2 = Right$(GrpDdoVlrVnd.Columns(5).HeaderText, 4) & Left$(GrpDdoVlrVnd.Columns(5).HeaderText, 2)
                sMes3 = Right$(GrpDdoVlrVnd.Columns(6).HeaderText, 4) & Left$(GrpDdoVlrVnd.Columns(6).HeaderText, 2)
                sVal1 = Session("objVAKUtl").funFrmNumIsr(GrpDdoVlrVnd.Items(iIndice).Cells(4).Text)
                sVal2 = Session("objVAKUtl").funFrmNumIsr(GrpDdoVlrVnd.Items(iIndice).Cells(5).Text)
                sVal3 = Session("objVAKUtl").funFrmNumIsr(GrpDdoVlrVnd.Items(iIndice).Cells(6).Text)

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
            Next
            sAuxXML = sAuxXML & "    </dados>"
            Err("")
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
                sAuxDes = GrpDdoCtn.Items(iIndice).Cells(1).Text.Trim
                sAuxXML = sAuxXML & "        <competencia> " & Chr(13) & _
                                    "            <codctnrep>" & sAuxCod & "</codctnrep>" & Chr(13) & _
                                    "            <descodctnrep>" & sAuxDes & "</descodctnrep> " & Chr(13) & _
                                    "        </competencia> " & Chr(13)
            Next
            sAuxXML = sAuxXML & "    </dados>"
            Err("")
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
                sAuxDes = GrpDdoAvl.Items(iIndice).Cells(1).Text.Trim
                sAuxXML = sAuxXML & "        <avaliacao> " & Chr(13) & _
                                    "            <codavlrep>" & sAuxCod & "</codavlrep>" & Chr(13) & _
                                    "            <desavlctnrep>" & sAuxDes & "</desavlctnrep> " & Chr(13) & _
                                    "        </avaliacao> " & Chr(13)
            Next
            sAuxXML = sAuxXML & "    </dados>"
            Err("")
            Return sAuxXML
        Catch ex As Exception
            Err(ex.Message)
            Return ""
        End Try
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Salva alteracoes nas informacoes do RCA em processo de cadastramento.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Getulio de Morais Pereira] 27/12/2004  Tratamento de TipFrmPgt em funcao do Banco <BR>
    ''' 
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub LnkGrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkGrv.Click
        'Objeto
        Dim oObeAltItfVAKRep As New VAK019.BO_VAKCadRep
        Dim oObeCsnGerVnd As VAK019.BO_VAKCsnVldUsr
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
            CodEstUni, NumRgtRepCshRep, IndAcePnd, IndVldCpf, CodUndNgc, _
            DdoFlu, sCodUsrRcf, sNomFnc, sNomUsr, TipFrmPgt, sNumReq As String

        Dim TipSitPesJurCshReg As String REM Tipo de empresa
        Dim TipSitRepCshReg As String    REM Situacao do Core

        Dim iNumReq As Int64

        If VerificaPreenchimento() Then
            Try
                If Request("NumReq") Is Nothing Then
                    sNumReq = Session("objVAKUtl").pprNumReqCttRep
                Else
                    sNumReq = Request("NumReq").ToString
                    iNumReq = Int64.Parse(sNumReq)
                    iNumReq = iNumReq - 168
                    sNumReq = Math.Sqrt(Double.Parse(iNumReq.ToString)).ToString
                End If

                If (sNumReq <> "") Then
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
                    CodBai = LstNomBai.SelectedValue
                    CodCplBai = LstCplBai.SelectedValue
                    CodCidRep = LstCid.SelectedValue
                    CodCepRep = Session("objVAKUtl").funTiraMascara(DesNumCep.Text.Trim)
                    TipSitRsiRep = LstRsi.SelectedValue
                    TipVtgRsiRep = LstVtg.SelectedValue
                    TipSitTlfRep = LstSitTlf.SelectedValue
                    NumTlfRep = NumTlf.Text.Trim
                    NumTlfCelRep = NumCel.Text.Trim
                    TipSitFaxRep = LstSitFax.SelectedValue
                    NumFaxRep = NumFax.Text.Trim
                    CodSgmMcd = LstSgmMcd.SelectedValue
                    NumInsInuNacSegSoc = DesNumInss.Text.Trim
                    NomDepRep = Session("objVAKUtl").FunVldTxt(DesNomCjg.Text.Trim)
                    If DatNscCjg.SelectedDate.Year = 1 Then
                        DatNscDep = ""
                    Else
                        DatNscDep = Session("objVAKUtl").funFrmDatIsr(DatNscCjg)
                    End If
                    NumDocIdt = DesNumCrtIdtCjg.Text.Trim
                    NomOrgEmsDocIdt = DesOrgEmsCjg.Text.Trim
                    QdeFlhRep = DesNumFlhCjg.Text.Trim
                    CodBcoRep = LstNomBco.SelectedValue
                    CodAgeBcoRep = LstAgeBco.SelectedValue

                    CodCntCrrBcoRep = DesNumCntCrr.Text.Trim

                    'If CodCntCrrBcoRep <> "" Then
                    '    TipFrmPgt = "B"
                    'Else
                    '    TipFrmPgt = "R"
                    'End If
                    If (Not CodCntCrrBcoRep Is Nothing) And (CodCntCrrBcoRep.Equals(String.Empty)) And (LstNomBco.SelectedValue = 33) Then
                        TipFrmPgt = "R"
                    Else
                        TipFrmPgt = "B"
                    End If

                    NumDigVrfAgeBcoRep = Session("objVAKUtl").pprDigAgeBco
                    TipNatRep = "F"
                    DesAcoTrbRep = Session("objVAKUtl").FunVldTxt(DesAcoTrb.Text.Trim)
                    CodStaCadRep = "8"
                    If DatCadCshReg.SelectedDate.Year = 1 Then
                        DatRgtRepCshReg = ""
                    Else
                        DatRgtRepCshReg = Session("objVAKUtl").funFrmDatIsr(DatCadCshReg)
                    End If
                    CodEstUniCshReg = LstEstCshReg.SelectedValue

                    ' TipSitPesJurCshReg = LstSitCshReg.SelectedValue
                    TipSitPesJurCshReg = "PF"
                    TipSitRepCshReg = LstSitCshReg.SelectedValue

                    CodEstUni = LstEst.SelectedValue
                    NumRgtRepCshRep = DesCshReg.Text.Trim
                    IndAcePnd = RblAcePnd.SelectedItem.Value
                    IndVldCpf = "0"
                    CodUndNgc = LstUndNgc.SelectedValue
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
                    'Chamando BO para buscar dados usuário
                    Dim oObeCsnItfGerVnd As New VAK019.BO_VAKCsnVldUsr
                    sNomUsr = Session("objVAKUtl").funUsr()
                    oObeCsnItfGerVnd.CsnAnsCrdGerVnd(sNomUsr, sCodUsrRcf, sNomFnc)
                    'Dados do Fluxo
                    DdoFlu = "**************************************************" & Chr(13) & "Documento alterado:" & Chr(13) & "Por: " & sCodUsrRcf & " - " & sNomFnc & Chr(13) & "Data: " & Date.Today
                    'Chamando BO para Alteração
                    sMsgErr = oObeAltItfVAKRep.AltDdoRep(sXMLDdoRep, sNomUsr, sXMLTetRep, sXMLCtnRep, sNumReq, sXMLAvlRep, DdoFlu)
                    If sMsgErr <> "1" Then
                        Throw New Exception(sMsgErr)
                    Else
                        MsgBoxWeb.Text = "Registro alterado com sucesso!"
                    End If
                    oObeCsnItfGerVnd = Nothing
                    Err("")
                End If
            Catch ex As Exception
                Err(ex.Message)
            End Try
        Else
            MsgBoxWeb.Text = "Foram encontrados erros ou existem campos obrigatórios que não foram preenchidos. Verifique as informações!"
        End If
    End Sub

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

    Private Sub GrpDdoVlrVnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpDdoVlrVnd.SelectedIndexChanged

    End Sub
End Class
