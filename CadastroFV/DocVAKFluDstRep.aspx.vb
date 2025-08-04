Imports System.Configuration.ConfigurationSettings
Imports VAK020.BO_VAKFluDstRep

''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : Recisao
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe detalhes do fluxo de desativação do representante
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class Recisao
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents CheckBox2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents NomOpn As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatSlc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatEft As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RadioButton3 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RadioButton4 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents GrpDdoStaFlu As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents LnkGrv As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkEdt As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnPnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnOpnEtv As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnTetVnd As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoBco As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoCjg As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoRep As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LnkBtnDdoFlu As System.Web.UI.WebControls.LinkButton
    Protected WithEvents BtnAcoes As System.Web.UI.WebControls.Button
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtObsDst As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCodFlu As System.Web.UI.WebControls.Label
    Protected WithEvents MsgBoxWeb As New VAK016.Web.MessageBoxWeb
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodNomRep As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents DatCri As eWorld.UI.CalendarPopup
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lstMtvDst As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDesMtvDstRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtVlrAcd As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtObsFlu As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents txtEndREp As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumTlfRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumTelCelRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumFaxRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodCepRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents rdoSupSbt As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdoRepSbt As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lstOtrRep As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grdPgnRsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdIniFlu As System.Web.UI.WebControls.Button
    Protected WithEvents rdoIniEmp As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdoIniRep As System.Web.UI.WebControls.RadioButton
    Protected WithEvents txtSolicDemissao As System.Web.UI.WebControls.Label
    Protected WithEvents txtDatSlcDem As eWorld.UI.CalendarPopup
    Protected WithEvents cmdNotRep As System.Web.UI.WebControls.Button
    Protected WithEvents rdoNotCmpCtt As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdoOtrMtv As System.Web.UI.WebControls.RadioButton
    Protected WithEvents cmdLstAco As System.Web.UI.WebControls.Button
    Protected WithEvents cmdGrvFlu As System.Web.UI.WebControls.Button
    Protected WithEvents cmdVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents lstEstUni As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lstCidRep As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblAviso As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label

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
        Dim sCodRep As Integer
        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sTipAco As String
        Dim sNomRep As String
        Try
            If Not Page.IsPostBack Then

                cmdIniFlu.Attributes.Add("onClick", "javascript:return confirm('Deseja realmente iniciar o fluxo?');")
                cmdNotRep.Attributes.Add("onClick", "javascript:return confirm('Deseja realmente notificar o representante?');")

                'Recupera query string
                iCodRep = Request.QueryString("codrep")
                Session("iCodRep") = iCodRep
                iCodFlu = Request.QueryString("codFlu")
                sTipAco = Request.QueryString("tipAco")
                Session("sTipAco") = sTipAco
                sNomRep = Server.UrlDecode(Request.QueryString("nomRep"))

                Me.txtCodCepRep.Attributes.Add("onkeypress", "TeclaNumerica(event)")

                'Atualiza cód./nome representante na tela
                txtCodNomRep.Text = iCodRep.ToString & " - " & sNomRep.ToString.Trim.ToUpper

                'Carregar combos
                CarregarCombos()

                'Se fluxo já criado, carregar dados do banco
                If sTipAco = "Alterar" Then
                    CarregarDados(iCodFlu, True, sTipAco)
                ElseIf sTipAco = "Criar" Then
                    CarregarPerguntas()
                ElseIf sTipAco = "Revisar" Then
                    CarregarDados(iCodFlu, False, sTipAco)
                    CarregarPerguntas()
                Else
                    CarregarDados(iCodFlu, False, sTipAco)
                End If

                rdoIniRep_CheckedChanged(Nothing, Nothing)

                If sTipAco = "Consultar" Then ControlesDesabilitar()
                If sTipAco = "Criar" Or sTipAco = "Alterar" Then Me.cmdLstAco.Enabled = False

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Desabilita controles.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ControlesDesabilitar()
        lstMtvDst.Enabled = False
        txtDesMtvDstRep.ReadOnly = True
        txtEndREp.ReadOnly = True
        txtNumTlfRep.ReadOnly = True
        txtNumTelCelRep.ReadOnly = True
        txtNumFaxRep.ReadOnly = True
        txtCodCepRep.ReadOnly = True
        rdoSupSbt.Enabled = False
        rdoRepSbt.Enabled = False
        lstOtrRep.Enabled = False
        rdoRepSbt.Enabled = False
        lstCidRep.Enabled = False
        lstEstUni.Enabled = False
        txtDatSlcDem.Enabled = False
        txtVlrAcd.ReadOnly = True
        txtObsFlu.ReadOnly = True
        grdPgnRsp.Enabled = False
        rdoIniEmp.Enabled = False
        rdoIniRep.Enabled = False
        rdoNotCmpCtt.Enabled = False
        rdoOtrMtv.Enabled = False
        cmdGrvFlu.Enabled = False
        cmdIniFlu.Enabled = False
        cmdNotRep.Enabled = False
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega dados do fluxo.
    ''' </summary>
    ''' <param name="iCodFlu">Código do fluxo</param>
    ''' <param name="bObsProv"></param>
    ''' <param name="sTipAco"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregarDados(ByVal iCodFlu As Integer, _
                              ByVal bObsProv As Boolean, _
                              ByVal sTipAco As String)

        Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep
        Dim dsFluDst As DataSet
        Dim oFlu As DataRow
        Dim oObs As DataTable

        'Consulta dados no banco
        dsFluDst = BO_VAKFlu.CsnFluDstRep(iCodFlu, bObsProv)
        oFlu = dsFluDst.Tables("TblFluDstRep").Rows(0)
        oObs = dsFluDst.Tables("TblObsFlu")

        'Carrega dados gerais
        lstMtvDst.SelectedIndex = _
            lstMtvDst.Items.IndexOf(lstMtvDst.Items.FindByValue(oFlu("CodMtvDstEdeVnd")))
        txtDesMtvDstRep.Text = Trim(oFlu("DesMtvDstRep"))
        txtEndREp.Text = Trim(oFlu("EndRep"))
        txtNumTlfRep.Text = Trim(oFlu("NumTlfRep"))
        txtNumTelCelRep.Text = Trim(oFlu("NumTlfCelRep"))
        txtNumFaxRep.Text = Trim(oFlu("NumFaxRep"))
        txtCodCepRep.Text = oFlu("CodCepRep")
        If oFlu("CodRepSbtVnd") = 0 Then
            rdoSupSbt.Checked = True
            rdoRepSbt.Checked = False
            lstOtrRep.Enabled = False
        Else
            rdoSupSbt.Checked = False
            rdoRepSbt.Checked = True
            lstOtrRep.SelectedIndex = _
                lstOtrRep.Items.IndexOf(lstOtrRep.Items.FindByValue(oFlu("CodRepSbtVnd")))
            lstOtrRep.Enabled = True
        End If
        If Not IsDBNull(oFlu("DatDocSlcDst")) Then
            txtDatSlcDem.SelectedDate = oFlu("DatDocSlcDst")
        End If
        txtVlrAcd.Text = IIf(IsDBNull(oFlu("VlrArdDstRep")), "", oFlu("VlrArdDstRep"))
        txtObsFlu.Text = Trim(oObs.Rows(0)("DesObs"))

        If CInt(oFlu("CodTipDstRep")) = 2 Then
            rdoIniEmp.Checked = False
            rdoIniRep.Checked = False
            rdoNotCmpCtt.Checked = False
            rdoOtrMtv.Checked = True
        ElseIf CInt(oFlu("CodTipDstRep")) = 4 Then
            rdoIniEmp.Checked = False
            rdoIniRep.Checked = False
            rdoNotCmpCtt.Checked = True
            rdoOtrMtv.Checked = False
        ElseIf IsDBNull(oFlu("DatDocSlcDst")) Then
            rdoIniEmp.Checked = True
            rdoIniRep.Checked = False
            rdoNotCmpCtt.Checked = False
            rdoOtrMtv.Checked = False
        ElseIf Not IsDBNull(oFlu("DatDocSlcDst")) Then
            rdoIniEmp.Checked = False
            rdoIniRep.Checked = True
            rdoNotCmpCtt.Checked = False
            rdoOtrMtv.Checked = False
        Else
            rdoIniEmp.Checked = True
            rdoIniRep.Checked = False
            rdoNotCmpCtt.Checked = False
            rdoOtrMtv.Checked = False
        End If

        carregarCidade(oFlu("CodCidRep"))

        'Carrega perguntas/respostas
        If bObsProv Then
            Dim iCodPgn As Integer = 1
            Dim sDesPgn As String
            Dim dtsPerguntas As New VAK020.PerguntasRespostas
            Do
                sDesPgn = AppSettings("Pergunta" & iCodPgn.ToString)
                If sDesPgn <> "" Then dtsPerguntas.PerguntasRespostas.AddPerguntasRespostasRow(sDesPgn, Trim(oObs.Rows(iCodPgn)("DesObs")))
                iCodPgn += 1
            Loop Until sDesPgn = ""
            Session("dtsPerguntas") = dtsPerguntas
            grdPgnRsp.DataSource = dtsPerguntas.Tables(0)
            grdPgnRsp.DataBind()
        Else
            If sTipAco <> "Revisar" Then grdPgnRsp.Visible = False
        End If

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega cidade.
    ''' </summary>
    ''' <param name="iCodCid">Código da cidade</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub carregarCidade(ByVal iCodCid As Integer)
        Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep
        Dim dsFluDst As DataSet

        dsFluDst = BO_VAKFlu.CsnCidEstCid(iCodCid)

        lstCidRep.DataSource = dsFluDst.Tables(0)
        lstCidRep.DataTextField = "NOMCID"
        lstCidRep.DataValueField = "CODCID"
        lstCidRep.DataBind()
        lstCidRep.SelectedIndex = lstCidRep.Items.IndexOf(lstCidRep.Items.FindByValue(iCodCid))
        lstEstUni.SelectedIndex = _
            lstEstUni.Items.IndexOf( _
                lstEstUni.Items.FindByValue(dsFluDst.Tables(0).Rows(0)("CODESTUNI")))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega combos (unidades da federação, motivos de desativação).
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregarCombos()
        Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep
        Dim dsEstados As DataSet
        Dim dsMtvDst As DataSet
        Dim dsOtrRep As DataSet
        Dim iCodRep As Integer

        'Carrega unidades da federação
        dsEstados = BO_VAKFlu.CsnEstUni
        lstEstUni.DataSource = dsEstados.Tables(0)
        lstEstUni.DataValueField = "CODESTUNI"
        lstEstUni.DataTextField = "CODESTUNI"
        lstEstUni.DataBind()
        lstEstUni.Items.Insert(0, " ")

        'Carrega motivos desativação
        dsMtvDst = BO_VAKFlu.CsnMtvDst(-1)
        lstMtvDst.DataSource = dsMtvDst.Tables(0)
        lstMtvDst.DataValueField = "CODMTVDSTEDEVND"
        lstMtvDst.DataTextField = "DESMTVDSTEDEVND"
        lstMtvDst.DataBind()
        lstMtvDst.Items.Insert(0, " ")

        'Carrega RCAs do gerente de mercado
        dsOtrRep = BO_VAKFlu.CsnRepPorSup(Session("CodSup"), Session("iCodRep"))
        'dsOtrRep = BO_VAKFlu.CsnRepPorSup(355, Session("iCodRep")) 'TODO: Retirar isto.
        iCodRep = Request.QueryString("codrep")
        lstOtrRep.DataSource = dsOtrRep.Tables(0)
        lstOtrRep.DataValueField = "CODREP"
        lstOtrRep.DataTextField = "NOMREP"
        lstOtrRep.DataBind()
        lstOtrRep.Items.Insert(0, " ")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega perguntas.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregarPerguntas()
        Dim iCodPgn As Integer = 1
        Dim sDesPgn As String
        Dim dtsPerguntas As New VAK020.PerguntasRespostas
        Do
            sDesPgn = AppSettings("Pergunta" & iCodPgn.ToString)
            iCodPgn += 1
            If sDesPgn <> "" Then dtsPerguntas.PerguntasRespostas.AddPerguntasRespostasRow(sDesPgn, "")
        Loop Until sDesPgn = ""
        Session("dtsPerguntas") = dtsPerguntas
        grdPgnRsp.DataSource = dtsPerguntas.Tables(0)
        grdPgnRsp.DataBind()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona botão ações.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub BtnAcoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcoes.Click
        Server.Transfer("DocVAKAco.aspx")
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
    Private Sub cmdVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVoltar.Click
        Server.Transfer(Session("PagAnt"))
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Valida dados digitados no formulário.
    ''' </summary>
    ''' <param name="sMsgErr">Mensagem de erro</param>
    ''' <returns>Verdadeiro, se formulário válido - Falso, se formulário inválido.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function FormularioValidar(ByRef sMsgErr As String) As Boolean
        Dim oLnh As DataGridItem
        sMsgErr = ""
        If lstMtvDst.SelectedIndex < 1 Then sMsgErr = "Informe o tipo de motivo de desativação." : Exit Function
        If txtDesMtvDstRep.Text.Trim.Length < 3 Then sMsgErr = "Informe a descrição do motivo da desativação." : Exit Function
        If txtObsFlu.Text.Trim.Length < 3 Then sMsgErr = "Informe a observação do fluxo." : Exit Function
        If txtObsFlu.Text.Trim.Length > 2000 Then sMsgErr = "A observação não pode ter mais que 2000 caracteres." : Exit Function
        If txtEndREp.Text.Trim.Length < 3 Then sMsgErr = "Informe o endereço do representante." : Exit Function
        If txtNumTlfRep.Text.Trim.Length < 3 Then sMsgErr = "Informe o telefone do representante." : Exit Function
        If txtNumTelCelRep.Text.Trim.Length < 3 Then sMsgErr = "Informe o celular do representante." : Exit Function
        If txtCodCepRep.Text.Trim.Length < 8 Then sMsgErr = "Informe o CEP do representante (oito dígitos)." : Exit Function
        If rdoRepSbt.Checked AndAlso lstOtrRep.SelectedIndex < 1 Then sMsgErr = "Informe o representante substituto." : Exit Function
        If lstCidRep.SelectedIndex < 0 Then sMsgErr = "Informe a cidade do representante." : Exit Function
        If rdoIniRep.Checked AndAlso txtDatSlcDem.SelectedDate = Nothing Then sMsgErr = "Informe a data da carta de solicitação da demissão." : Exit Function
        If txtDesMtvDstRep.Text.Length > 240 Then sMsgErr = "O motivo da desativação não pode ter mais que 240 caracteres." : Exit Function
        For Each oLnh In grdPgnRsp.Items
            If CType(oLnh.Cells(1).Controls(1), TextBox).Text.Trim.Length < 3 Then
                sMsgErr = " Preencher todas as respostas. " : Exit Function
            End If
        Next
        FormularioValidar = True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona botões salvar, iniciar fluxo e notificar representante.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub cmdGrvFlu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
         Handles cmdGrvFlu.Click, cmdIniFlu.Click, cmdNotRep.Click

        Try
            Dim sMsgErr As String
            Dim AcoFlu As enmTipAcoFlu
            Dim iCodRep As Integer = Request.QueryString("codrep")
            Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep

            'Verifica se sessão ainda válida
            If (Session("TipRep") <> "GM") Then
                Session("CodErr") = "1"
                Response.Redirect("DocVAKVldUsr.aspx")
            End If

            'Identifica qual ação 
            If CType(sender, Button).ID = "cmdGrvFlu" Then
                AcoFlu = enmTipAcoFlu.SalvaFluxo
            ElseIf CType(sender, Button).ID = "cmdIniFlu" Then
                If rdoIniEmp.Checked Then
                    AcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaEmpresa
                ElseIf rdoIniRep.Checked Then
                    AcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaRepresentante
                Else
                    Throw New Exception("Erro ao iniciar fluxo. Selecione uma das opções para início de fluxo, e não para notificação.")
                End If
            ElseIf CType(sender, Button).ID = "cmdNotRep" Then
                If rdoNotCmpCtt.Checked Then
                    AcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato
                ElseIf rdoOtrMtv.Checked Then
                    AcoFlu = enmTipAcoFlu.NotificarOutrosMotivos
                Else
                    Throw New Exception("Erro ao notificar. Selecione uma das opções para notificação, e não para início de fluxo.")
                End If
            End If

            'Alertar, se houver territórios relacionados.
            If (CType(sender, Button).ID = "cmdIniFlu" And rdoIniEmp.Checked) Or _
               CType(sender, Button).ID = "cmdNotRep" Then
                Dim dsTerritorios As DataSet
                dsTerritorios = BO_VAKFlu.CsnTetVndRep(iCodRep)
                If Not IsDBNull(dsTerritorios.Tables(0)) AndAlso dsTerritorios.Tables(0).Rows.Count > 0 AndAlso CInt(dsTerritorios.Tables(0).Rows(0).Item(0)) > 0 Then
                    Response.Write("<script>alert('Lembre-se de transferir ou apropriar os territórios que ainda se encontram com o representante " & _
                    "para outro representante ou para você, no momento oportuno. A apropriação automática para o representante substituto " & _
                    "informado será feita mais adiante no fluxo de desativação apenas se você ainda não tiver feito a transferência ou apropriação manualmente.');</script>")
                End If
            End If

            'Valida informações e executa ação
            If FormularioValidar(sMsgErr) Then
                FluxoAcionar(AcoFlu)
            Else
                Response.Write("<script>alert('" & sMsgErr & "');</script>")
            End If

        Catch ex As Exception
            If Not (TypeOf (ex) Is System.Threading.ThreadAbortException) Then
                Response.Write("<script>alert('" & ex.Message & "');</script>")
            End If
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona fluxo (salvar, iniciar fluxo...)
    ''' </summary>
    ''' <param name="TipAcoFlu">Tipo da ação no fluxo.</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub FluxoAcionar(ByVal TipAcoFlu As enmTipAcoFlu)
        Dim iCodFluDstRep As Integer
        Dim iCodRep As Integer
        Dim dDatCri As Date
        Dim iCodMtvDstEdeVnd
        Dim sDesMtvDstRep As String
        Dim sEndRep As String
        Dim sNumTlfRep As String
        Dim sNumTlfCelRep As String
        Dim sNumFaxRep As String
        Dim iCodCidRep As Integer
        Dim iCodCepRep As Long
        Dim iCodRepSbtVnd As Integer
        Dim dDatDocSlcDst As Date
        Dim iCodTipDstRep As Integer
        Dim fVlrArdDstRep As Double
        Dim sTipAco As String
        Dim sObsFlu As String
        Dim oLnh As DataGridItem
        Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep
        Dim msg As New VAK016.Web.MessageBoxWeb
        Dim sMsgAcoSuc As String
        Dim iCodSup As Integer
        Dim sUrlSis As String
        Dim sMsgAux As String = ""

        'Captura informações
        sTipAco = Request.QueryString("tipAco")
        iCodFluDstRep = Request.QueryString("codFlu")
        iCodRep = Request.QueryString("codrep")
        If sTipAco = "A Revisar" OrElse sTipAco = "Criado" Then dDatCri = Me.DatCri.SelectedDate
        iCodMtvDstEdeVnd = Me.lstMtvDst.SelectedValue
        sDesMtvDstRep = Me.txtDesMtvDstRep.Text.Trim.ToUpper.Replace(vbCrLf, " ")
        If sDesMtvDstRep.Length > 250 Then
            Throw New Exception("A descrição do motivo da desativação ultrapassou o número máximo de caracteres permitido (250).")
        End If
        sEndRep = IIf(Me.txtEndREp.Text.Trim.Length < 1, " ", Me.txtEndREp.Text.Trim.ToUpper)
        sNumTlfRep = IIf(Me.txtNumTlfRep.Text.Trim.Length < 1, " ", Me.txtNumTlfRep.Text.Trim.ToUpper)
        sNumTlfCelRep = IIf(Me.txtNumTelCelRep.Text.Trim.Length < 1, " ", Me.txtNumTelCelRep.Text.Trim.ToUpper)
        sNumFaxRep = IIf(Me.txtNumFaxRep.Text.Trim.Length < 1, " ", Me.txtNumFaxRep.Text.Trim.ToUpper)
        iCodCidRep = IIf(lstCidRep.SelectedIndex < 1, 0, lstCidRep.SelectedValue)
        iCodCepRep = IIf(Me.txtCodCepRep.Text.Trim.Length < 1, 0, Me.txtCodCepRep.Text.Trim.ToUpper)
        iCodRepSbtVnd = IIf(Me.rdoSupSbt.Checked, 0, Me.lstOtrRep.SelectedValue)
        dDatDocSlcDst = IIf(rdoIniRep.Checked, Me.txtDatSlcDem.SelectedDate, Nothing)
        If Me.txtVlrAcd.Text.Trim = "" Then
            fVlrArdDstRep = -1
        Else
            fVlrArdDstRep = Convert.ToDouble(Me.txtVlrAcd.Text, Threading.Thread.CurrentThread.CurrentCulture.NumberFormat)
        End If

        If rdoIniEmp.Checked Or rdoIniRep.Checked Then
            iCodTipDstRep = 1
        ElseIf rdoNotCmpCtt.Checked Then
            iCodTipDstRep = 4
        Else
            iCodTipDstRep = 2
        End If
        sObsFlu = Me.txtObsFlu.Text.Trim.ToUpper

        'Armazena perguntas / respostas
        Dim PgnRsp(Me.grdPgnRsp.Items.Count - 1, 1) As String
        Dim iItemAtual As Integer = 0
        For Each oLnh In Me.grdPgnRsp.Items
            PgnRsp(iItemAtual, 0) = oLnh.Cells(0).Text.Trim.ToUpper
            PgnRsp(iItemAtual, 1) = CType(oLnh.Cells(1).Controls(1), TextBox).Text.Trim.ToUpper
            iItemAtual += 1
        Next

        'Busca URL do Sistema (para compor o email)
        sUrlSis = AppSettings("EnderecoSistema")

        'Ação no fluxo
        BO_VAKFlu.AcoFluDstRep(iCodFluDstRep, iCodRep, dDatCri, _
            iCodMtvDstEdeVnd, sDesMtvDstRep, sEndRep, sNumTlfRep, sNumTlfCelRep, _
              sNumFaxRep, iCodCidRep, iCodCepRep, iCodRepSbtVnd, dDatDocSlcDst, _
                 fVlrArdDstRep, sObsFlu, PgnRsp, TipAcoFlu, sUrlSis, iCodTipDstRep)

        'Mensagem de sucesso para o usuário
        If TipAcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaEmpresa OrElse TipAcoFlu = enmTipAcoFlu.IniciarFluxoIniciativaRepresentante Then
            sMsgAcoSuc = " iniciado "
        ElseIf TipAcoFlu = enmTipAcoFlu.NotificarOutrosMotivos OrElse TipAcoFlu = enmTipAcoFlu.NotificarParaCumprimentoContrato Then
            sMsgAcoSuc = " iniciado "
        ElseIf TipAcoFlu = enmTipAcoFlu.SalvaFluxo Then
            sMsgAcoSuc = " salvo "
        End If

        If TipAcoFlu = enmTipAcoFlu.SalvaFluxo Then
            sMsgAux = "O fluxo foi salvo, mas não foi iniciado. Para iniciar o fluxo, retorne a este formulário e clique em Iniciar Fluxo ou Notificar."
        End If

        Response.Write("<script>alert('Fluxo " & iCodFluDstRep.ToString & sMsgAcoSuc & "com sucesso. " & sMsgAux & "');</script>")
        Session("dtsRepresentantes") = Nothing
        Server.Transfer(Session("PagAnt"), True)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde mudança no agente que iniciou o fluxo (representante ou empresa).
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub rdoIniRep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdoIniEmp.CheckedChanged, rdoIniRep.CheckedChanged, rdoNotCmpCtt.CheckedChanged, rdoOtrMtv.CheckedChanged

        If rdoIniRep.Checked Then
            txtSolicDemissao.Visible = True
            txtDatSlcDem.Visible = True
        Else
            txtSolicDemissao.Visible = False
            txtDatSlcDem.Visible = False
        End If

        If rdoOtrMtv.Checked Then
            lblAviso.Text = "O objetivo desta notificação é gerar uma rescisão por justo motivo. " & _
                            "Este tipo de rescisão exige uma análise por parte do Departamento Jurídico da empresa. " & _
                            "Forneça o máximo de informações que tiver disponível e que possam auxiliar a análise e a " & _
                            "elaboração da notificação."
            lblAviso.Visible = True
        Else
            lblAviso.Text = ""
            lblAviso.Visible = False
        End If

        If rdoIniEmp.Checked Or rdoIniRep.Checked Then
            cmdIniFlu.Enabled = True
            cmdNotRep.Enabled = False
        Else
            cmdIniFlu.Enabled = False
            cmdNotRep.Enabled = True
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde à mudañça de unidade da federação.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub lstEstUni_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEstUni.SelectedIndexChanged

        Dim sEstUni As String
        Dim dsCidade As DataSet
        Dim BO_VAKFlu As New VAK020.BO_VAKFluDstRep

        sEstUni = lstEstUni.SelectedValue
        dsCidade = BO_VAKFlu.CsnCid(sEstUni)
        lstCidRep.DataSource = dsCidade.Tables(0)
        lstCidRep.DataValueField = "CODCID"
        lstCidRep.DataTextField = "NOMCID"
        lstCidRep.DataBind()
        lstCidRep.Items.Insert(0, " ")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde ao clique no botão Ver e executar ações.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub cmdLstAco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLstAco.Click
        Dim iCodRep As Integer
        Dim iCodFlu As Integer
        Dim sNomRep As String
        Dim sTipAco As String
        Dim iCodSup As Integer
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
    ''' REsponse à mudança no checkbox de substituto.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub rdoRepSbt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles rdoRepSbt.CheckedChanged, rdoSupSbt.CheckedChanged
        If rdoSupSbt.Checked Then
            lstOtrRep.SelectedIndex = -1
            lstOtrRep.Enabled = False
        Else
            lstOtrRep.Enabled = True
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Preenchimento do grid.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub grdPgnRsp_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) _
        Handles grdPgnRsp.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim dtsPerguntas As DataSet
            dtsPerguntas = Session("dtsPerguntas")
            If Session("sTipAco") <> "Criar" Then CType(e.Item.Cells(1).Controls(1), TextBox).Text = dtsPerguntas.Tables(0).Rows(e.Item.DataSetIndex)(1)
        End If
    End Sub

End Class