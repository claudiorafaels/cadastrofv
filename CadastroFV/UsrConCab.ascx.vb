Imports System.Text
Public Class Cab
    Inherits System.Web.UI.UserControl
    Protected WithEvents lblSistema As System.Web.UI.WebControls.Label
    Protected WithEvents imgTabImage As System.Web.UI.WebControls.Image
    Protected WithEvents imgBevel As System.Web.UI.WebControls.Image
    Protected WithEvents imgLogo As System.Web.UI.WebControls.Image
    Protected WithEvents ctlMenu As SolpartWebControls.SolpartMenu
    Protected WithEvents oNomSis As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton3 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton4 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents oUsr As System.Web.UI.WebControls.Label
    Protected WithEvents oInfNvg As System.Web.UI.WebControls.Label
    Protected WithEvents oDat As System.Web.UI.WebControls.Label
    Protected WithEvents TitErr As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.oNomSis.Text = New System.Configuration.AppSettingsReader().GetValue("SISTEMA", GetType(String))
        Me.oDat.Text = Format(Now(), "dd/MM/yyyy")
        'Me.oUsr.Text = Split(System.Security.Principal.WindowsIdentity.GetCurrent.Name.ToString, "\")(1)
        Me.oUsr.Text = Session("user")
        If Session("bLogUsr") = True Then
            Me.oUsr.Text = Session("ArrayLogUsr").Item(1)               'Obtem o Nome do Usuário Logado
            Me.oUsr.Text = Me.oUsr.Text.ToUpper()
        End If
    End Sub

    Private Sub TitErr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles TitErr.Load
        Me.TitErr.Text = CType(Me.Session("MsgErr"), String)
    End Sub

    Private Sub oInfNvg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles oInfNvg.Load
        Me.oInfNvg.Text = CType(Me.Session("InfNvg"), String)
    End Sub
End Class