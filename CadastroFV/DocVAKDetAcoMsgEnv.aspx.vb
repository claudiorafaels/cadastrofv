''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKDetAcoMsgEnv
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe detalhes da ação do tipo MENSAGEM ENVIADA (EMAIL).
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKDetAcoMsgEnv
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFluxo As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblRepresentante As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumSeq As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblObs As System.Web.UI.WebControls.Label
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents lblRem As System.Web.UI.WebControls.Label
    Protected WithEvents txtMsg As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAssunto As System.Web.UI.WebControls.Label
    Protected WithEvents lblDsn As System.Web.UI.WebControls.Label
    Protected WithEvents lblComCop As System.Web.UI.WebControls.Label
    Protected WithEvents lblComCopOcu As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDatCri As System.Web.UI.WebControls.Label

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
    ''' Tipos de endereço de email.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Enum enmTipoEndereco
        Remetente
        Destinatario
        ComCopia
        ComCopiaOculta
    End Enum

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
            Dim iNumSeq As Integer
            Dim BO_VAK020 As New VAK020.BO_VAKFluDstRep
            Dim oGrpDdo As DataSet
            Dim sMsgCreEtn As String

            'Consulta dados do email enviado
            iCodFlu = Request.QueryString("CodFlu")
            iNumSeq = Request.QueryString("NumSeq")
            oGrpDdo = BO_VAK020.CsnMsgCreEtn(iCodFlu, iNumSeq)

            'Preenche informações gerais
            If oGrpDdo.Tables("TblAcoGen").Rows.Count > 0 Then
                Me.lblFluxo.Text = oGrpDdo.Tables("TblAcoGen").Rows(0)("CODFLUDSTREP")
                Me.lblRepresentante.Text = oGrpDdo.Tables("TblAcoGen").Rows(0)("CODREP") & " - " & _
                                           oGrpDdo.Tables("TblAcoGen").Rows(0)("NOMREP")
                Me.lblNumSeq.Text = oGrpDdo.Tables("TblAcoGen").Rows(0)("NUMSEQ")
                Me.lblAssunto.Text = oGrpDdo.Tables("tblCsnMsgCreEtnCab").Rows(0)("DESASSCREETN")
                Me.lblDatCri.Text = Format(oGrpDdo.Tables("TblAcoGen").Rows(0)("DATCRI"), "dd/MM/yyyy")
            End If

            'Limpa caixas com endereços de email
            Me.lblRem.Text = ""
            Me.lblDsn.Text = ""
            Me.lblComCop.Text = ""
            Me.lblComCopOcu.Text = ""

            'Preenche endereços (remetente, destinatário, com cópia, com cópia oculta)
            For Each oLnh As DataRow In oGrpDdo.Tables("tblMsgCreEtnEnd").Rows
                Select Case oLnh("TIPENDCREETN")
                    Case 1 : Me.lblRem.Text += Trim(oLnh("IDTENDCREETN")) & ";"
                    Case 2 : Me.lblDsn.Text += Trim(oLnh("IDTENDCREETN")) & ";"
                    Case 3 : Me.lblComCop.Text += Trim(oLnh("IDTENDCREETN")) & ";"
                    Case 4 : Me.lblComCopOcu.Text += Trim(oLnh("IDTENDCREETN")) & ";"
                End Select
            Next

            'Preenche corpo da mensagem
            For Each oLnh As DataRow In oGrpDdo.Tables("tblCsnMsgCreEtn").Rows
                txtMsg.Text += oLnh("DESTXTLNHFISCREETN") & vbCrLf
            Next

        End If
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Aciona botão voltar
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