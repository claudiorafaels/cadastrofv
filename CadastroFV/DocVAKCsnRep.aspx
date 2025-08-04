<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKCsnRep.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKCsnRep"%>
<%@ Register TagPrefix="cc1" Namespace="VAK016.Web" Assembly="VAK016" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DocVAKCsnRep</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function FormataData(campo,teclapres) {
				var tecla = teclapres.keyCode;
				vr = document.forms[0][campo].value;
				vr = vr.replace( "/", "" );
				vr = vr.replace( "/", "" );
				tam = vr.length;
				
				if (tam < 8 && tecla != 8){ tam = vr.length + 1 ; }

				if (tecla == 8 ){	tam = tam - 1 ; }

				if ( tecla == 8 || tecla >= 48 && tecla <= 57 ){
					if ( tam <= 2 ){
	 					document.forms[0][campo].value = vr ; }
	 				if ( (tam > 2) && (tam <= 4) ){
	 					document.forms[0][campo].value = vr.substr( 0, 2 ) + '/' + vr.substr( 2, tam ) ;}	 					
	 				if ( (tam > 4) && (tam <= 8) ){
	 					document.forms[0][campo].value = vr.substr( 0, 2 ) + '/' + vr.substr( 2, 2 ) + '/' + vr.substr( 4, tam - 4 ) ; }				 	
				}
				else event.keyCode = 0;
			}
			function FormataCpf(campo,tammax,teclapres) {
				var tecla = teclapres.keyCode;
				vr = document.forms[0][campo].value;
				vr = vr.replace( "/", "" );
				vr = vr.replace( "/", "" );
				vr = vr.replace( ",", "" );
				vr = vr.replace( ".", "" );
				vr = vr.replace( ".", "" );
				vr = vr.replace( ".", "" );
				vr = vr.replace( ".", "" );
				vr = vr.replace( "-", "" );
				vr = vr.replace( "-", "" );
				vr = vr.replace( "-", "" );
				vr = vr.replace( "-", "" );
				vr = vr.replace( "-", "" );
				tam = vr.length;

				if (tam < tammax && tecla != 8){ tam = vr.length + 1 ; }

				if (tecla == 8 ){	tam = tam - 1 ; }
					
				if ( tecla == 8 || tecla >= 48 && tecla <= 57 ){
					if ( tam <= 2 ){ 
	 					document.forms[0][campo].value = vr ; }
	 				if ( (tam > 2) && (tam <= 5) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 2 ) + '-' + vr.substr( tam - 2, tam ) ; }
	 				if ( (tam >= 6) && (tam <= 8) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 5 ) + '.' + vr.substr( tam - 5, 3 ) + '-' + vr.substr( tam - 2, tam ) ; }
	 				if ( (tam >= 9) && (tam <= 11) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 8 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + '-' + vr.substr( tam - 2, tam ) ; }
	 				if ( (tam >= 12) && (tam <= 14) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 11 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + '-' + vr.substr( tam - 2, tam ) ; }
	 				if ( (tam >= 15) && (tam <= 17) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 14 ) + '.' + vr.substr( tam - 14, 3 ) + '.' + vr.substr( tam - 11, 3 ) + '.' + vr.substr( tam - 8, 3 ) + '.' + vr.substr( tam - 5, 3 ) + '-' + vr.substr( tam - 2, tam ) ;}
				}		
 				else event.keyCode = 0;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><cc1:messageboxweb id="MsgBox" runat="server"></cc1:messageboxweb>
			<table style="WIDTH: 768px; HEIGHT: 465px" cellSpacing="0" cellPadding="0" width="768"
				align="left" border="0">
				<tr vAlign="top">
					<td vAlign="top">
						<table style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
							borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="0">
							<tr>
								<td width="20"></td>
								<td style="HEIGHT: 100%" vAlign="top">
									<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc" border="0">
										<TR>
											<TD colSpan="8"><BR>
											</TD>
										</TR>
										<TR>
											<td style="WIDTH: 23px" width="23"></td>
											<TD style="WIDTH: 173px" align="right"><asp:label id="TitNumReq" runat="server" ForeColor="Black" Font-Bold="True">Nro Requisição:</asp:label></TD>
											<TD style="WIDTH: 103px"><asp:textbox id="NumReq" tabIndex="1" runat="server" Width="85px"></asp:textbox></TD>
											<TD style="WIDTH: 30px" align="right"><asp:label id="TitNumCpf" runat="server" ForeColor="Black" Font-Bold="True">CPF:</asp:label></TD>
											<TD style="WIDTH: 232px"><asp:textbox id="NumCpf" tabIndex="2" runat="server" Width="127px" AutoPostBack="True" MaxLength="14"></asp:textbox></TD>
											<td style="WIDTH: 26px"></td>
											<td><asp:button id="AcoCsn" tabIndex="10" runat="server" Width="88px" Text="Consultar" BackColor="White"></asp:button></td>
											<td width="20" bgColor="#e0eafc"></td>
										</TR>
										<TR>
											<td style="WIDTH: 23px" width="23"></td>
											<TD style="WIDTH: 173px" align="right"><asp:label id="TitNomRep" runat="server" ForeColor="Black" Font-Bold="True">Nome:</asp:label></TD>
											<TD style="WIDTH: 381px" colSpan="4"><asp:textbox id="NomRep" tabIndex="3" runat="server" Width="306px" MaxLength="30"></asp:textbox></TD>
											<TD><asp:button id="AcoNvoPsq" tabIndex="11" runat="server" Width="88px" Text="Limpar" BackColor="White"></asp:button></TD>
											<td width="20" bgColor="#e0eafc"></td>
										</TR>
										<TR>
											<td style="WIDTH: 23px; HEIGHT: 13px" width="23"></td>
											<TD style="WIDTH: 173px; HEIGHT: 13px" align="right"><asp:label id="TitSta" runat="server" ForeColor="Black" Font-Bold="True">Status:</asp:label></TD>
											<TD style="WIDTH: 381px; HEIGHT: 13px" colSpan="4"><asp:dropdownlist id="LstSta" tabIndex="4" runat="server" Width="308px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 13px"></TD>
											<td style="HEIGHT: 13px" width="20" bgColor="#e0eafc" colSpan="4"></td>
										</TR>
										<TR>
											<td style="WIDTH: 23px; HEIGHT: 24px" width="23"></td>
											<TD style="WIDTH: 173px; HEIGHT: 24px" align="right"><asp:label id="TitTet" runat="server" ForeColor="Black" Font-Bold="True">Território:</asp:label></TD>
											<TD style="HEIGHT: 24px" colSpan="5"><asp:dropdownlist id="LstTet" tabIndex="5" runat="server" Width="308px"></asp:dropdownlist></TD>
											<td style="HEIGHT: 24px" width="20" bgColor="#e0eafc"></td>
										</TR>
										<TR>
											<td style="WIDTH: 23px" width="23"></td>
											<TD style="WIDTH: 173px" align="right"><asp:label id="TitDatSlc" runat="server" ForeColor="Black" Font-Bold="True">Data Solicitação:</asp:label></TD>
											<TD colSpan="5"><asp:textbox id="DesDatIniSlc" tabIndex="6" runat="server" Width="86px" AutoPostBack="True" MaxLength="10"></asp:textbox><ew:calendarpopup id="DatIniSlc" tabIndex="7" runat="server" Width="0px" AutoPostBack="True" ClearDateText="Nenhuma"
													Nullable="True" GoToTodayText="Data Atual:" AllowArbitraryText="False" Height="21px">
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
												</ew:calendarpopup>&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:label id="TitAte" runat="server" ForeColor="Black" Font-Bold="True">até:</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:textbox id="DesDatFimSlc" tabIndex="8" runat="server" Width="86px" AutoPostBack="True" MaxLength="10"></asp:textbox><ew:calendarpopup id="DatFimSlc" tabIndex="9" runat="server" Width="0px" AutoPostBack="True" ClearDateText="Nenhuma"
													Nullable="True" GoToTodayText="Data Atual:" AllowArbitraryText="False" Height="21px">
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
											<td width="20" bgColor="#e0eafc"></td>
										</TR>
										<TR>
											<TD colSpan="8" height="5"><BR>
											</TD>
										</TR>
										<TR>
											<td style="WIDTH: 23px" width="23" bgColor="#e0eafc"></td>
											<TD align="center" colSpan="6"><asp:datagrid id="GrpDdoRep" tabIndex="10" runat="server" Width="710px" BackColor="White" PageSize="5"
													AllowPaging="True" DataKeyField="NUMREQCADREP" AllowSorting="True" HorizontalAlign="Left" AutoGenerateColumns="False"
													BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
													<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="&lt;img src=&quot;images/ArqImgDet.gif&quot; alt=&quot;Exibir Detalhes...&quot; border=&quot;0&quot;&gt;">
															<HeaderStyle Width="10px"></HeaderStyle>
														</asp:EditCommandColumn>
														<asp:TemplateColumn Visible="False">
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemTemplate>
																<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:CheckBox id="CheckBox3" runat="server"></asp:CheckBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="NUMREQCADREP" SortExpression="NUMREQCADREP" HeaderText="Requisi&#231;&#227;o">
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="70px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:HyperLinkColumn Text="CPF" DataTextField="NUMCPFREP" SortExpression="NUMCPFREP" HeaderText="CPF">
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="100px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:HyperLinkColumn>
														<asp:BoundColumn DataField="NOMREP" SortExpression="NOMREP" HeaderText="Nome">
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="200px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESSTACADREP" SortExpression="DESSTACADREP" HeaderText="Status">
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="190px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" HeaderText="Resp. prox. a&#231;&#227;o">
															<HeaderStyle Font-Size="X-Small" Width="180px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DATSLC" SortExpression="DATSLC" HeaderText="Data Solicita&#231;&#227;o"
															DataFormatString="{0:dd/MM/yyyy}">
															<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="130px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="LightSteelBlue" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
											<td width="20" bgColor="#e0eafc"></td>
										</TR>
										<tr>
											<td align="center" colSpan="8"><br>
											</td>
										</tr>
									</TABLE>
								</td>
								<td width="20"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
