<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKLstRpaNotFscRca.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKLstRpaNotFscRca" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cadastro da Força de Vendas</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab>
			<asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 136px" runat="server"
				Height="192px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="#E7EBFF" Font-Names="Verdana">
				<TABLE id="Table21" style="VERTICAL-ALIGN: top; WIDTH: 100%" cellSpacing="0" cellPadding="0"
					align="center" border="0">
					<TR style="HEIGHT: 16px">
						<TD width="8"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
						<TD bgColor="#e0eafc" colSpan="4"></TD>
						<TD style="WIDTH: 10px" vAlign="top" width="10"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD width="10" bgColor="#e0eafc"></TD>
						<TD colSpan="4">
							<asp:Label id="Label3" runat="server" BackColor="#E7EBFF" Font-Bold="True">RPAs/Notas Fiscais devidas pelo RCA</asp:Label></TD>
						<TD style="WIDTH: 10px" width="10" bgColor="#e0eafc"></TD>
					</TR>
					<TR>
						<TD width="10" bgColor="#e0eafc"></TD>
						<TD colSpan="4">
							<P>&nbsp;</P>
							<asp:datagrid id="GrpDdoLstRpa" runat="server" BackColor="White" Width="200px" PageSize="50" AutoGenerateColumns="False"
								BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
								<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ANOMESREF" SortExpression="ANOMESREF" HeaderText="M&#234;s/Ano">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
						<TD style="WIDTH: 10px" width="10" bgColor="#e0eafc"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD width="10" bgColor="#e0eafc"></TD>
						<TD colSpan="4">
							<asp:Button id="cmdVoltar" runat="server" Width="112px" Text="Voltar"></asp:Button></TD>
						<TD style="WIDTH: 10px" width="10" bgColor="#e0eafc"></TD>
					</TR>
				</TABLE>
			</asp:panel></FORM>
	</body>
</HTML>
