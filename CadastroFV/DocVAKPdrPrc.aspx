<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKPdrPrc.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKPdrPrc" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cadastro da Força de Vendas</title>
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="comum/DocFunCmuJS.htm"></script>
	</HEAD>
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 136px" runat="server"
				Font-Names="Verdana" BackColor="White" Width="100%" Font-Size="X-Small" ForeColor="Red"
				Height="192px">
				<TABLE id="Table21" style="VERTICAL-ALIGN: top; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
					width="100%" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 18px" width="8"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
						<TD style="HEIGHT: 18px" bgColor="#e0eafc">
							<asp:Label id="Label3" runat="server" Font-Bold="True">Pedido de Parecer</asp:Label></TD>
						<TD style="WIDTH: 10px; HEIGHT: 18px" vAlign="top" width="10"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
					</TR>
					<TR vAlign="top">
						<TD width="10" bgColor="#e0eafc"></TD>
						<TD vAlign="top">
							<TABLE id="Table23" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
								borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
								bgColor="#e0eafc" border="0">
								<TR>
									<TD style="HEIGHT: 11.19%" vAlign="top" align="left">
										<TABLE id="Table24" style="HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc"
											border="0">
											<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 88px; HEIGHT: 16px" align="right">&nbsp;Fluxo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</TD>
												<TD style="HEIGHT: 16px">
													<asp:Label id="lblFluxo" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 88px" align="right">Representante:</TD>
												<TD>
													<asp:Label id="lblRepresentante" runat="server">0000 - XXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 88px" align="left">Destinatário:</TD>
												<TD>
													<asp:TextBox id="txtNomFnc" runat="server" Width="112px" MaxLength="10"></asp:TextBox>
													<asp:Button id="cmdCsnFnc" runat="server" Text="Consulta"></asp:Button>
													<asp:DropDownList id="lstFnc" runat="server" Width="328px"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 88px" align="right">
													<asp:Label id="lblObs" runat="server" Width="133px">Pedido Parecer:</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtObs" runat="server" Width="100%" MaxLength="240" Rows="10" TextMode="MultiLine"></asp:TextBox></TD>
											</TR>
										</TABLE>
										<asp:Label id="Label1" runat="server" ForeColor="Navy" Font-Bold="True">Atenção: A resposta ao pedido de parecer pode ser delegada pelo destinatário a outra pessoa.</asp:Label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 11.19%" vAlign="top" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 663px; HEIGHT: 13.15%" vAlign="top" align="right">
										<asp:Button id="btnConfirmar" runat="server" Width="100px" Text="Confirmar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnCancelar" runat="server" Width="100px" Text="Cancelar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 10px" width="10" bgColor="#e0eafc"></TD>
					</TR>
				</TABLE>
				<P>&nbsp;</P>
			</asp:panel><uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab></form>
	</body>
</HTML>
