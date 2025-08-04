Imports VAK020

''' -----------------------------------------------------------------------------
''' Project	 : CadastroFV
''' Class	 : DocVAKLstFluRep
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exibe lista de fluxo de desativação.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Claudio.Rafael]	14/3/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DocVAKLstFluRep
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents DatIni As eWorld.UI.CalendarPopup
    Protected WithEvents txtDatFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents DatFim As eWorld.UI.CalendarPopup
    Protected WithEvents btnConsultar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLstRep As System.Web.UI.WebControls.Button
    Protected WithEvents GrpDdoFluDst As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PnlDdoFlu As System.Web.UI.WebControls.Panel
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtCodRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomRep As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkMinhasPendencias As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDatIni As System.Web.UI.WebControls.TextBox

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
            Session("PagAnt") = "DocVAKLstFluRep.aspx"
            Me.txtCodRep.Attributes.Add("onkeypress", "TeclaNumerica(event)")
            CarregarFluxos()
        End If
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carrega fluxos.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CarregarFluxos()
        Try
            Dim oCsnLstRep As BO_VAKFluDstRep = New BO_VAKFluDstRep
            Dim dtsRepresentantes As DataSet
            Dim iCodSup As Integer
            Dim iCodRep As Integer
            Dim sNomRep As String
            Dim dDatIni As Date
            Dim dDatFim As Date
            Dim bMinhasPendencias As Boolean

            iCodSup = Session("CodSup")
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
            bMinhasPendencias = Me.chkMinhasPendencias.Checked
            If bMinhasPendencias Then
                dDatIni = New Date(1901, 1, 1)
                dDatFim = New Date(1901, 1, 1)
            Else
                dDatIni = New Date(Me.txtDatIni.Text.Split("/")(2), Me.txtDatIni.Text.Split("/")(1), Me.txtDatIni.Text.Split("/")(0)) 'CDate(Me.txtDatIni.Text)
                dDatFim = New Date(Me.txtDatFim.Text.Split("/")(2), Me.txtDatFim.Text.Split("/")(1), Me.txtDatFim.Text.Split("/")(0)) 'CDate(Me.txtDatFim.Text)

                If dDatIni > dDatFim Then
                    Response.Write("<script language=javascript>javascript:alert('A data inicial não pode ser maior que a data final.');</script>")
                    Exit Sub
                End If
            End If
            If Session("dtsRepresentantes") Is Nothing Then
                dtsRepresentantes = oCsnLstRep.CsnLstFluSup(iCodSup, iCodRep, sNomRep, dDatIni, dDatFim, bMinhasPendencias, -1)
                Session("dtsRepresentantes") = dtsRepresentantes
            Else
                dtsRepresentantes = Session("dtsRepresentantes")
            End If
            GrpDdoFluDst.CurrentPageIndex = Session("PaginaAtual")
            Me.GrpDdoFluDst.DataSource = dtsRepresentantes.Tables(0)
            Me.GrpDdoFluDst.DataBind()

            ColocarLinksNoGrid(Me.GrpDdoFluDst)

        Catch ex As Exception
            Label3.Text = ex.Message
            Label3.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub ColocarLinksNoGrid(ByVal grid As System.Web.UI.WebControls.DataGrid)
        Try
            For Each oLnhGrd As DataGridItem In grid.Items
                Dim iCodRepAtl As Integer = CInt(oLnhGrd.Cells(1).Text) 'ds.Tables(0).Rows(oLnhGrd.DataSetIndex)("CODREP")
                Dim iCodFluAtl As Integer = CInt(oLnhGrd.Cells(0).Text) 'ds.Tables(0).Rows(oLnhGrd.DataSetIndex)("CODFLUDSTREP")
                Dim sNomRepAtl As String = oLnhGrd.Cells(2).Text.Trim.ToUpper 'ds.Tables(0).Rows(oLnhGrd.DataSetIndex)("NOMREP")
                Dim sInicio As String = oLnhGrd.Cells(4).Text.Trim.ToUpper
                Dim sEstado As String = oLnhGrd.Cells(6).Text.Trim
                Dim sTipAco As String

                If sInicio = "SIM" Then
                    sTipAco = "Alterar"
                ElseIf sInicio = "SIM (REVISÃO)" Then
                    sTipAco = "Revisar"
                ElseIf sInicio = "NÃO" Then
                    sTipAco = "Consultar"
                End If

                oLnhGrd.Cells(6).Text = "<A href='DocVAKFluDstRep.aspx?codrep=" _
                       & iCodRepAtl.ToString & "&codFlu=" & iCodFluAtl.ToString & _
                         "&tipAco=" & sTipAco & "&nomRep=" & Server.UrlEncode(sNomRepAtl.Trim.ToUpper) & "'>" & sEstado & "</A>"
            Next
        Catch ex As Exception
            Label3.Text = ex.Message
            Label3.ForeColor = Color.Red
        End Try
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
        CarregarFluxos()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento mudança de página no grid.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoFluDst_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrpDdoFluDst.PageIndexChanged
        Dim CpoOrd As String
        Dim dtsRepresentantes As DataSet
        Dim oLnhGrd As DataGridItem
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

            ColocarLinksNoGrid(Me.GrpDdoFluDst)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento ordernar do grid.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GrpDdoFluDst_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles GrpDdoFluDst.SortCommand
        Dim CpoOrd As String = e.SortExpression
        Dim dtsRepresentantes As DataSet
        Dim oLnhGrd As DataGridItem
        Dim iQdeRec As Integer
        Try
            Session("CpoOrd") = CpoOrd
            dtsRepresentantes = Session("dtsRepresentantes")
            dtsRepresentantes.Tables(0).DefaultView.Sort = CpoOrd
            With GrpDdoFluDst
                .DataSource = dtsRepresentantes.Tables(0)
                .DataBind()
            End With

            ColocarLinksNoGrid(Me.GrpDdoFluDst)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento botão 'Lista de RCAs'.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnLstRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLstRep.Click
        Session("dtsRepresentantes") = Nothing
        Session("PaginaAtual") = Nothing
        Session("CpoOrd") = Nothing
        Server.Transfer("DOCVAKLstRep.aspx")
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Responde evento checar minhas pendências.
    ''' </summary>
    ''' <param name="sender">Objeto remetente</param>
    ''' <param name="e">Argumentos do evento</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Claudio.Rafael]	14/3/2008	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub chkMinhasPendencias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMinhasPendencias.CheckedChanged
        Dim DataTresMesesAtras As Date = Date.Today.AddMonths(-3)

        If Me.chkMinhasPendencias.Checked Then
            Me.txtDatIni.Text = ""
            Me.txtDatFim.Text = ""
            Me.txtCodRep.Text = ""
            Me.txtNomRep.Text = ""
            Me.DatIni.Enabled = False
            Me.DatFim.Enabled = False
            Me.txtCodRep.Enabled = False
            Me.txtNomRep.Enabled = False
        Else
            Me.txtDatIni.Text = Format(New Date(DataTresMesesAtras.Year, DataTresMesesAtras.Month, 1), "dd/MM/yyyy")
            Me.txtDatFim.Text = Format(Date.Today, "dd/MM/yyyy")
            Me.txtCodRep.Text = ""
            Me.txtNomRep.Text = ""
            Me.DatIni.Enabled = True
            Me.DatFim.Enabled = True
            Me.txtCodRep.Enabled = True
            Me.txtNomRep.Enabled = True
        End If
    End Sub

    Private Sub DatIni_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatIni.DateChanged
        txtDatIni.Text = Format(DatIni.SelectedDate, "dd/MM/yyyy")
    End Sub

    Private Sub DatFim_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatFim.DateChanged
        txtDatFim.Text = Format(DatFim.SelectedDate, "dd/MM/yyyy")
    End Sub

    Private Sub GrpDdoFluDst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpDdoFluDst.SelectedIndexChanged

    End Sub
End Class