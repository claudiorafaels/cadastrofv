Imports VAK020

''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKLstRpaNotFscRca
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe lista de documentos pendentes do RCA (notas fiscais e RPAs).
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKLstRpaNotFscRca
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents cmdVoltar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents GrpDdoLstRpa As System.Web.UI.WebControls.DataGrid

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
            Dim oCsnLstRep As BO_VAKFluDstRep = New BO_VAKFluDstRep
            Dim dtsRepresentantes As DataSet
            Dim oLnhGrd As DataGridItem
            Dim sDatRpa, sNomRep As String
            iCodRep = Request.QueryString("codrep")
            sNomRep = Request.QueryString("nomrep")
            Label3.Text &= " " & sNomRep
            dtsRepresentantes = oCsnLstRep.CsnLstRpaNfsRep(iCodRep)
            If dtsRepresentantes.Tables("tblLstRpaNfsRep").Rows.Count > 0 Then
                Me.GrpDdoLstRpa.DataSource = dtsRepresentantes.Tables("tblLstRpaNfsRep")
                Me.GrpDdoLstRpa.DataBind()
                For Each oLnhGrd In GrpDdoLstRpa.Items
                    sDatRpa = oLnhGrd.Cells(0).Text
                    sDatRpa = Right(sDatRpa, 2) + "/" + Left(sDatRpa, 4)
                    oLnhGrd.Cells(0).Text = sDatRpa
                Next
            End If
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento do botão voltar.
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
        Server.Transfer("DOCVAKLstRep.aspx")
    End Sub
End Class
