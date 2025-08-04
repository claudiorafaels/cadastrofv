<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKLstPdrPrc.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKLstPdrPrc" %>
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
			<asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; POSITION: absolute; TOP: 136px; LEFT: 0px" runat="server"
				Height="192px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="White" Font-Names="Verdana">
				<TABLE style="HEIGHT: 136px; VERTICAL-ALIGN: top" id="Table21" border="0" cellSpacing="0"
					cellPadding="0" width="100%" align="center">
					<TR>
						<TD width="8"><IMG id="Img9" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD bgColor="#e0eafc">
							<asp:Label id="Label3" runat="server" Font-Bold="True">Pedidos de Parecer Pendentes</asp:Label></TD>
						<TD style="WIDTH: 10px" vAlign="top" width="10"><IMG id="Img10" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD bgColor="#e0eafc" width="10"></TD>
						<TD vAlign="top">
							<TABLE style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
								id="Table23" border="0" cellSpacing="0" borderColor="#96b1cb" cellPadding="0" width="100%"
								bgColor="#e0eafc" align="center" height="100%">
								<TR>
									<TD style="HEIGHT: 11.19%" vAlign="top" align="left">
										<TABLE style="HEIGHT: 24px" id="Table24" border="0" cellSpacing="1" cellPadding="1" width="100%"
											bgColor="#e0eafc">
											<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 134px" align="left">Fluxo:</TD>
												<TD>
													<asp:Label id="lblFluxo" runat="server">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 134px" align="left">Representante:</TD>
												<TD>
													<asp:Label id="lblRepresentante" runat="server">0000 - XXXXXXXXX</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 134px" align="right">
													<asp:Label id="lblObs" runat="server" Width="144px">Pedidos Parecer:</asp:Label></TD>
												<TD>
													<asp:datagrid id="GrpDdoAco" runat="server" BackColor="White" Width="100%" Height="24px" AllowSorting="True"
														AutoGenerateColumns="False" BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999"
														BorderStyle="None" PageSize="100">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="NOMFNC" HeaderText="Solicitante">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DATCRI" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn HeaderText="A&#231;&#227;o">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 663px; HEIGHT: 13.15%" vAlign="top" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnVoltar" runat="server" Width="100px" Text="Voltar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 10px" bgColor="#e0eafc" width="10"></TD>
					</TR>
				</TABLE>
				<P>&nbsp;</P>
			</asp:panel><uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab></form>
	</body>
</HTML>
