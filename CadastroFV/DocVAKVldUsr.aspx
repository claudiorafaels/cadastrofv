<%@ Page Language="vb" AutoEventWireup="false" AspCompat="true" Codebehind="DocVAKVldUsr.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKVldUsr"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DocVAKVldUsr</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 368px; HEIGHT: 128px; TOP: 112px; LEFT: 200px"
				cellSpacing="0" cellPadding="0" width="368" align="center" border="0">
				<TR>
					<TD style="WIDTH: 432px; HEIGHT: 49px" background="images/ArqImgTitFnd.jpg" colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 177px; HEIGHT: 42px" align="center" bgColor="#9cbbd1"><asp:label id="TitPSW" runat="server" ForeColor="Transparent" CssClass="tit" Height="17px"
							Width="40px">Código</asp:label>:</TD>
					<TD style="WIDTH: 900px; HEIGHT: 42px" bgColor="#9cbbd1"><asp:textbox id="DesNroCadGerMcd" runat="server" Width="136px"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" Width="16" ControlToValidate="DesNroCadGerMcd"
							ErrorMessage="<img src=&quot;images/ArqImgAla.gif&quot; alt=&quot;Código deve conter apenas números!&quot; border=&quot;0&quot; onclick=&quot;alert('Código deve conter apenas números!')&quot;>" ValidationExpression="(^\d*$)" Height="15"></asp:regularexpressionvalidator>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="16px" Height="15px" ErrorMessage="<img src=&quot;images/ArqImgAla.gif&quot; alt=&quot;Preenchimento obrigatório!&quot; border=&quot;0&quot; onclick=&quot;alert('Preenchimento obrigatório!')&quot;>"
							ControlToValidate="DesNroCadGerMcd"></asp:RequiredFieldValidator></TD>
					<TD style="WIDTH: 66px; HEIGHT: 42px" bgColor="#9cbbd1"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 177px; HEIGHT: 41px" align="center" bgColor="#9cbbd1"><asp:label id="Label1" runat="server" ForeColor="Transparent" CssClass="tit" Height="17px"
							Width="40px">Senha: </asp:label></TD>
					<TD style="WIDTH: 900px; HEIGHT: 41px" bgColor="#9cbbd1"><asp:textbox id="DesPsw" runat="server" Width="136px" TextMode="Password"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" Width="16" ControlToValidate="DesPsw"
							ErrorMessage="<img src=&quot;images/ArqImgAla.gif&quot; alt=&quot;Senha deve conter apenas números!&quot; border=&quot;0&quot; onclick=&quot;alert('Senha deve conter apenas números!')&quot;>" ValidationExpression="(^\d*$)" Height="15"></asp:regularexpressionvalidator>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="16px" Height="15px" ErrorMessage="<img src=&quot;images/ArqImgAla.gif&quot; alt=&quot;Preenchimento obrigatório!&quot; border=&quot;0&quot; onclick=&quot;alert('Preenchimento obrigatório!')&quot;>"
							ControlToValidate="DesPsw"></asp:RequiredFieldValidator></TD>
					<TD style="WIDTH: 66px; HEIGHT: 41px" bgColor="#9cbbd1"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 950px; HEIGHT: 42px" align="right" bgColor="#9cbbd1" colSpan="2">
						<asp:Button id="AcoVldUsr" runat="server" CssClass="btn" Width="64px" Text="Login" ForeColor="White"
							BackColor="DimGray"></asp:Button></TD>
					<TD style="WIDTH: 10px" bgColor="#9cbbd1"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
