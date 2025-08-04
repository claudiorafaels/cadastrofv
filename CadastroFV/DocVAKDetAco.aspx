<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKDetAco.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKDetAco" %>
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
				Height="192px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="White" Font-Names="Verdana">
				<TABLE id="Table21" style="VERTICAL-ALIGN: top; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
					width="100%" align="center" border="0">
					<TR>
						<TD width="8"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
						<TD bgColor="#e0eafc">&nbsp;
							<asp:Label id="Label3" runat="server" Font-Bold="True">Ação</asp:Label></TD>
						<TD style="WIDTH: 10px" vAlign="top" width="10"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 388px" width="10" bgColor="#e0eafc"></TD>
						<TD style="HEIGHT: 388px" vAlign="top">
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
												<TD style="WIDTH: 211px; HEIGHT: 19px" align="right">
													<asp:Label id="Label2" runat="server" Width="133px" Font-Bold="True">Fluxo:</asp:Label></TD>
												<TD style="HEIGHT: 19px">
													<asp:Label id="lblFluxo" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 19px" align="right"></TD>
												<TD style="HEIGHT: 19px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 17px" align="right">
													<asp:Label id="Label4" runat="server" Width="133px" Font-Bold="True">Representante:</asp:Label></TD>
												<TD style="HEIGHT: 17px">
													<asp:Label id="lblRepresentante" runat="server">0000 - XXXXXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 19px" align="right">
													<asp:Label id="Label5" runat="server" Width="133px" Font-Bold="True">Núm. Seq.:</asp:Label></TD>
												<TD style="HEIGHT: 19px">
													<asp:Label id="lblNumSeq" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 20px" align="right">
													<asp:Label id="Label7" runat="server" Width="133px" Font-Bold="True">Ação:</asp:Label></TD>
												<TD style="HEIGHT: 20px">
													<asp:Label id="lblAco" runat="server">0000 - XXXXXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 20px" align="right">
													<asp:Label id="Label6" runat="server" Width="133px" Font-Bold="True">Data da ação:</asp:Label></TD>
												<TD style="HEIGHT: 20px">
													<asp:Label id="lblDatCri" runat="server">DD/MM/YYYY</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 20px" align="right">
													<asp:Label id="Label9" runat="server" Width="133px" Font-Bold="True">Responsável:</asp:Label></TD>
												<TD style="HEIGHT: 20px">
													<asp:Label id="lblRspAco" runat="server">0000 - XXXXXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px; HEIGHT: 20px" align="right">
													<asp:Label id="lblAux" runat="server" Width="133px" Font-Bold="True" Visible="False">Auxiliar:</asp:Label></TD>
												<TD style="HEIGHT: 20px">
													<asp:Label id="lblAuxCdo" runat="server" Visible="False">XXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px" align="right">
													<asp:Label id="lblObs" runat="server" Width="133px" Font-Bold="True">Observação:</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtObs" runat="server" Width="100%" MaxLength="240" TextMode="MultiLine" Rows="10"
														ReadOnly="True"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px" align="right"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 211px" align="right"></TD>
												<TD>
													<asp:Button id="btnVoltar" runat="server" Width="100px" Text="Voltar"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 10px; HEIGHT: 388px" width="10" bgColor="#e0eafc"></TD>
					</TR>
				</TABLE>
				<P>&nbsp;</P>
			</asp:panel><uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab></form>
	</body>
</HTML>
