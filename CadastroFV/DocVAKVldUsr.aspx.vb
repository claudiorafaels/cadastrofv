Public Class DocVAKVldUsr
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents DesPsw As System.Web.UI.WebControls.TextBox
    Protected WithEvents DesNroCadGerMcd As System.Web.UI.WebControls.TextBox
    Protected WithEvents TitPSW As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents AcoVldUsr As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator

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
        Session("user") = ""
        'CursorLocation.CusorLocation.SetCursorLocation(Me.DesNroCadGerMcd)
        If IsPostBack Then
            logou(Me.DesNroCadGerMcd.Text, Me.DesPsw.Text)
        Else
            If Not Session("CodErr") Is Nothing Then
                If Session("CodErr") = "1" Then
                    'Response.Write(VIHUtl.funSetErr("Acesso Negado."))
                    Response.Write("Acesso Negado.")
                End If
            End If
        End If
        Session("CodErr") = "0"
    End Sub

    Private Sub logou(ByVal sUsr As String, ByVal sPwd As String)
        Dim oObeItf As New VAK019.BO_VAKCsnUsrPsw
        Dim oGrpDdo As New DataSet
        Dim sVlrRet As String
        Dim sCodRep, sNumReq As String
        Dim iNumReq As Int64
        Try
            sCodRep = Me.DesNroCadGerMcd.Text.Trim
            sVlrRet = oObeItf.CsnUsrPsw(sCodRep, Me.DesPsw.Text.Trim)
            ' objeto de leitura de string
            Dim oObeLetTxt As New System.IO.StringReader(sVlrRet)
            oGrpDdo.ReadXml(oObeLetTxt)
            oObeLetTxt.Close()
            If oGrpDdo.Tables(0).Rows.Count > 0 Then
                ' sCodRep = 70190 2971
                If (sCodRep = CType(oGrpDdo.Tables(0).Rows(0).Item(2), String).Trim) Then
                    If Not Request("NumReq") Is Nothing Then
                        sNumReq = Request("NumReq").ToString
                    End If
                    Session("CodRep") = sCodRep
                    Session("CodSup") = sCodRep
                    Session("TipRep") = "GM"
                    Session("user") = sCodRep
                    If (sNumReq = "") Then
                        Response.Redirect("DocVAKAutCtt.aspx")
                    Else
                        Response.Redirect("DocVAKDetRep.aspx?NumReq=" & sNumReq)
                    End If
                Else 'O usuario com a senha correta, mas nao e nem RCA, nem GM
                    'Response.Write(VIHUtl.funSetErr("Você não tem permissão para acessar essa página!"))
                    Response.Write("Você não tem permissão para acessar essa página!")
                End If
            Else 'Usuario com senha invalida
                'Response.Write(VIHUtl.funSetErr("Usuário/Senha Inválidos!"))
                Response.Write("Usuário/Senha Inválidos!")
            End If
        Catch oObeEcc As Exception
            'Response.Write(VIHUtl.funSetErr(oObeEcc.Message))
            Response.Write(oObeEcc.Message)
        Finally
            If Not oGrpDdo Is Nothing Then
                oGrpDdo.Dispose()
                oGrpDdo = Nothing
            End If
            'If Not oObeCli Is Nothing Then
            '    'oObeCli.Dispose()
            '    oObeCli = Nothing
            'End If
        End Try
    End Sub

    
   
   
End Class
