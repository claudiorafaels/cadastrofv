<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKLstFluRep.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKLstFluRep" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cadastro da Força de Vendas</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
		<script language="javascript">
     		function TeclaNumerica(e)
			{
				if (document.all)
					var tecla = e.keyCode;
				if (tecla > 47 && tecla < 58) // numeros de 0 a 9
					return true;
				else {
						if (tecla != 8) // backspace
							event.keyCode = 0;
							//return false;
						else
							return true;
					}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; POSITION: absolute; TOP: 144px; LEFT: 8px" runat="server"
				Height="192px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="#E7EBFF" Font-Names="Verdana">
				<TABLE style="WIDTH: 100%; VERTICAL-ALIGN: top" id="Table21" border="0" cellSpacing="0"
					cellPadding="0" align="center">
					<TR style="HEIGHT: 16px">
						<TD><IMG id="Img9" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD bgColor="#e0eafc" colSpan="4"></TD>
						<TD vAlign="top" width="10"><IMG id="Img10" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD></TD>
						<TD bgColor="#e0eafc" colSpan="4">
							<asp:Label id="Label3" runat="server" BackColor="#E7EBFF" Font-Bold="True">Fluxos de Desativação - Filtros</asp:Label></TD>
						<TD vAlign="top" width="10"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD bgColor="#e0eafc"></TD>
						<TD style="WIDTH: 5px">
							<asp:Label id="Label2" runat="server" BackColor="#E7EBFF">RCA:</asp:Label></TD>
						<TD style="WIDTH: 26px"></TD>
						<TD style="WIDTH: 234px">Data da Criação entre:</TD>
						<TD></TD>
						<TD bgColor="#e0eafc"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" bgColor="#e0eafc"></TD>
						<TD style="WIDTH: 5px; HEIGHT: 23px">
							<asp:Label id="Label4" runat="server" BackColor="#E7EBFF">Código/Nome:</asp:Label></TD>
						<TD style="WIDTH: 26px; HEIGHT: 23px">
							<asp:TextBox id="txtCodRep" runat="server" Width="48px" MaxLength="6" Enabled="False"></asp:TextBox>
							<asp:TextBox id="txtNomRep" runat="server" Width="233px" MaxLength="15" Enabled="False"></asp:TextBox></TD>
						<TD style="WIDTH: 234px; HEIGHT: 23px">
							<asp:textbox id="txtDatIni" tabIndex="6" runat="server" MaxLength="10" ReadOnly="True"></asp:textbox>
							<ew:calendarpopup id="DatIni" tabIndex="7" runat="server" Width="0px" Height="21px" Enabled="False"
								ClearDateText=" " GoToTodayText="Data Atual:" AllowArbitraryText="False" AutoPostBack="True">
								<ButtonStyle BorderStyle="Groove" Font-Bold="True" ForeColor="Black" BackColor="ControlLightLight"></ButtonStyle>
								<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></TodayDayStyle>
								<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="SkyBlue"></SelectedDateStyle>
								<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></GoToTodayStyle>
								<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></ClearDateStyle>
								<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="SteelBlue"
									BackColor="White"></WeekendStyle>
								<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
									BackColor="Black"></MonthHeaderStyle>
								<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
									BackColor="WhiteSmoke"></OffMonthStyle>
								<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
									BackColor="#0F4871"></DayHeaderStyle>
								<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></WeekdayStyle>
							</ew:calendarpopup>e
							<asp:textbox id="txtDatFim" tabIndex="8" runat="server" MaxLength="10" ReadOnly="True"></asp:textbox>
							<ew:calendarpopup id="DatFim" tabIndex="9" runat="server" Width="0px" Height="21px" Enabled="False"
								ClearDateText=" " GoToTodayText="Data Atual:" AllowArbitraryText="False" AutoPostBack="True">
								<ButtonStyle BorderStyle="Groove" Font-Bold="True" ForeColor="Black" BackColor="ControlLightLight"></ButtonStyle>
								<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></TodayDayStyle>
								<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="SkyBlue"></SelectedDateStyle>
								<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></GoToTodayStyle>
								<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></ClearDateStyle>
								<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="SteelBlue"
									BackColor="White"></WeekendStyle>
								<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
									BackColor="Black"></MonthHeaderStyle>
								<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
									BackColor="WhiteSmoke"></OffMonthStyle>
								<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
									BackColor="#0F4871"></DayHeaderStyle>
								<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></WeekdayStyle>
							</ew:calendarpopup></TD>
						<TD style="HEIGHT: 23px">&nbsp;
						</TD>
						<TD style="WIDTH: 10px; HEIGHT: 23px" bgColor="#e0eafc" width="10"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD style="HEIGHT: 23px" bgColor="#e0eafc" width="17"></TD>
						<TD style="WIDTH: 176px; HEIGHT: 23px" colSpan="2">
							<asp:CheckBox id="chkMinhasPendencias" runat="server" Width="185px" AutoPostBack="True" Text="Somente minhas pendências"
								Checked="True"></asp:CheckBox></TD>
						<TD style="WIDTH: 234px; HEIGHT: 23px"></TD>
						<TD style="HEIGHT: 23px"></TD>
						<TD style="HEIGHT: 23px" bgColor="#e0eafc" width="10"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD style="HEIGHT: 25px" bgColor="#e0eafc" width="17"></TD>
						<TD style="WIDTH: 5px; HEIGHT: 25px">
							<asp:Button id="btnConsultar" runat="server" BackColor="White" Text="Consultar"></asp:Button></TD>
						<TD style="WIDTH: 26px; HEIGHT: 25px"></TD>
						<TD style="WIDTH: 234px; HEIGHT: 25px">
							<asp:Button id="btnLstRep" runat="server" BackColor="White" Text="Lista de RCAs..."></asp:Button></TD>
						<TD style="HEIGHT: 25px" bgColor="#e0eafc" width="10"></TD>
					</TR>
					<TR style="HEIGHT: 16px">
						<TD bgColor="#e0eafc"></TD>
						<TD colSpan="4">
							<P>&nbsp;</P>
							<asp:datagrid id="GrpDdoFluDst" runat="server" BackColor="White" Width="100%" Height="24px" BorderStyle="None"
								BorderColor="#999999" CellPadding="3" GridLines="Vertical" BorderWidth="1px" AutoGenerateColumns="False"
								PageSize="50" AllowPaging="True" AllowSorting="True">
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
								<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CODFLUDSTREP" SortExpression="CODFLUDSTREP" HeaderText="Fluxo">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CODREP" SortExpression="CODREP" HeaderText="Cod. Repres.">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NOMREP" SortExpression="NOMREP" HeaderText="Nome">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DATCRI" SortExpression="DATCRI" HeaderText="Cria&#231;&#227;o/In&#237;cio Fluxo"
										DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AguardaInicioOuRevisao" SortExpression="AguardaInicioOuRevisao" HeaderText="Aguardando in&#237;cio?">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AguardaRespostaDeParecerPeloGM" SortExpression="AguardaRespostaDeParecerPeloGM"
										HeaderText="Aguardando parecer?">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="Estado">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
						<TD bgColor="#e0eafc"></TD>
					</TR>
				</TABLE>
				<DIV style="HEIGHT: 16px"></DIV>
			</asp:panel></form>
	</body>
</HTML>
