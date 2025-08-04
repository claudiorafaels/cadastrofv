<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKRpdPrc.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKRpdPrc" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
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
						<TD width="8"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
						<TD bgColor="#e0eafc">
							<asp:Label id="Label3" runat="server" Font-Bold="True">Pedido de Parecer</asp:Label></TD>
						<TD style="WIDTH: 10px" vAlign="top" width="10"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
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
												<TD style="WIDTH: 149px" align="right">Fluxo:</TD>
												<TD>
													<asp:Label id="lblFluxo" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Representante:</TD>
												<TD>
													<asp:Label id="lblRepresentante" runat="server">0000 - XXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right" bgColor="#ffffff" height="5"></TD>
												<TD bgColor="#ffffff" height="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Núm.Seq.:</TD>
												<TD>
													<asp:Label id="lblNumSeqPed" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Data Solicitação:</TD>
												<TD>
													<asp:Label id="lblDatCriPed" runat="server">DD/MM/YYYY</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px; HEIGHT: 19px" align="right">Solicitante:</TD>
												<TD style="HEIGHT: 19px">
													<asp:Label id="lblNomRspPed" runat="server">XXXXXXXXXXXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">
													<asp:Label id="lblObs" runat="server" Width="133px">Pedido de Parecer:</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtPedOpn" runat="server" Width="100%" ReadOnly="True" MaxLength="240" TextMode="MultiLine"
														Rows="10"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right" bgColor="#ffffff" height="5"></TD>
												<TD bgColor="#ffffff" height="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Núm.Seq.:</TD>
												<TD>
													<asp:Label id="lblNumSeqRsp" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Data Resposta:</TD>
												<TD>
													<asp:Label id="lblDatCriRsp" runat="server">DD/MM/YYYY</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">Responsável pelo parecer:</TD>
												<TD>
													<asp:Label id="lblNomDsnPed" runat="server">XXXXXXXXXXXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 149px" align="right">
													<asp:Label id="Label4" runat="server" Width="164px">Parecer:</asp:Label></TD>
												<TD>
													<asp:TextBox id="txtRspOpn" runat="server" Width="100%" ReadOnly="True" MaxLength="240" TextMode="MultiLine"
														Rows="10"></asp:TextBox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 11.19%" vAlign="top" align="left"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 663px; HEIGHT: 13.15%" vAlign="top" align="right">&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnConfirmar" runat="server" Width="100px" Text="Confirmar"></asp:Button>&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnCancelar" runat="server" Width="100px" Text="Voltar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
