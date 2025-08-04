<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKLstAco.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKLstAco" %>
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
			<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 128px"
				runat="server" Height="192px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="White" Font-Names="Verdana">
				<TABLE id="Table21" style="VERTICAL-ALIGN: top" cellSpacing="0" cellPadding="0" width="100%"
					align="center" border="0">
					<TR>
						<TD width="8"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
						<TD bgColor="#e0eafc"></TD>
						<TD style="WIDTH: 12px" vAlign="top" width="12"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
					</TR>
					<TR vAlign="top">
						<TD width="10" bgColor="#e0eafc"></TD>
						<TD vAlign="top">
							<TABLE id="Table23" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
								borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
								bgColor="#e0eafc" border="0">
								<TR>
									<TD style="WIDTH: 100%" vAlign="top" align="right">
										<TABLE id="Table24" style="WIDTH: 100%; HEIGHT: 201px" cellSpacing="1" cellPadding="1"
											bgColor="#e0eafc" border="0">
											<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 73px" align="right"></TD>
												<TD>
													<asp:Label id="Label3" runat="server">Fluxo:</asp:Label>
													<asp:Label id="lblCodFlu" runat="server" BackColor="#E7EBFF">0000</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 73px" align="right"></TD>
												<TD>
													<asp:Label id="Label4" runat="server" BackColor="#E7EBFF">Representante:</asp:Label>
													<asp:Label id="txtCodNomRep" runat="server" BackColor="#E7EBFF">0000 - NOME DO REPRESENTANTE</asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 73px" align="right">
													<asp:Label id="Label2" runat="server">Ações:</asp:Label></TD>
												<TD>
													<asp:datagrid id="GrpDdoAco" runat="server" BackColor="White" Width="100%" Height="24px" AllowSorting="True"
														AllowPaging="True" AutoGenerateColumns="False" BorderWidth="1px" GridLines="Vertical" CellPadding="3"
														BorderColor="#999999" BorderStyle="None">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="NUMSEQ" SortExpression="NUMSEQ" HeaderText="Seq.">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODACO" SortExpression="CODACO" HeaderText="C&#243;d.A&#231;&#227;o">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DESACOUSR" SortExpression="DESACOUSR" HeaderText="A&#231;&#227;o">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DATCRI" SortExpression="DATCRI, NUMSEQ" HeaderText="Data A&#231;&#227;o"
																DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODFNCRPNCRI" SortExpression="CODFNCRPNCRI" HeaderText="C&#243;d.">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NOMFNC" SortExpression="NOMFNC" HeaderText="Respons&#225;vel">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="InformacaoExtra" HeaderText="Detalhes">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 73px; HEIGHT: 18px" align="right"></TD>
												<TD style="HEIGHT: 18px">
													<asp:Label id="Label1" runat="server">Tipo de Ação</asp:Label>:
													<asp:DropDownList id="lstTipoAcoes" runat="server" Width="232px" AutoPostBack="True"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 73px" align="right"></TD>
												<TD>
													<asp:Button id="btnIcrobs" runat="server" Text="Incluir Observações"></asp:Button>
													<asp:Button id="btnPdrPrc" runat="server" Text="Pedir Parecer"></asp:Button>
													<asp:Button id="btnRpdPrc" runat="server" Text="Responder Parecer"></asp:Button>
													<asp:Button id="btnVoltar" runat="server" Width="96px" Text="Voltar"></asp:Button></TD>
											</TR>
										</TABLE>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%; HEIGHT: 13.15%" vAlign="top" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 12px" width="12" bgColor="#e0eafc"></TD>
					</TR>
				</TABLE>
				<P>&nbsp;</P>
				<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				</P>
			</asp:panel></form>
	</body>
</HTML>
