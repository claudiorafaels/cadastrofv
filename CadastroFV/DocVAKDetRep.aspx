<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="VAK016.Web" Assembly="VAK016, Version=1.0.0.0, PublicKeyToken=a7033ac69e502179" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKDetRep.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKDetRep"%>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DocVAKDetRep</title>
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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

			function FormataCep(campo,tammax,teclapres) {
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
					if ( tam <= 1 ){ 
	 					document.forms[0][campo].value = vr ; }
	 				if ( (tam > 1) && (tam <= 5) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 1 ) + '-' + vr.substr( tam - 1, tam ) ;} 
	 				if ( (tam >5) && (tam <= 7) ){
	 					document.forms[0][campo].value = vr.substr( 0, tam - 5 ) + '.' + vr.substr( tam - 5, 3 ) + '-' + vr.substr( tam - 2, tam ) ; }				 	
				}
				else event.keyCode = 0;
			}

			function MascaraCEP (formato, keypress, objeto)
				{
				campo = eval (objeto);
				if (formato=='CEP')
					{
					caracteres = '01234567890';
					separacoes = 1;
					separacao1 = '-';
					conjuntos = 2;
					conjunto1 = 5;
					conjunto2 = 3;
					if ((caracteres.search(String.fromCharCode (keypress))!=-1) && campo.value.length < 
					(conjunto1 + conjunto2 + 1))
						{
						if (campo.value.length == conjunto1) 
						campo.value = campo.value + separacao1;
						}
					else 
						event.returnValue = false;
					}
				}

			function CriticaCampos()
			{
			if (document.Geral.CEP.value == "")
			{
				alert("Informe no mínimo os 5(cinco) primeiros dígitos do CEP. Ex. 70001");
				document.Geral.CEP.focus();
				return (false);
			}

			if (document.Geral.CEP.value.length <= 4)
			{
   				alert("Informe no mínimo os 5(cinco) primeiros dígitos do CEP. Ex. 70001");
   				document.Geral.CEP.focus();
   				return (false);
			}  
			  
			{ 
			var Numeros = "0123456789-";
			var Posic, Carac;
			var Temp = document.Geral.CEP.value.length;    
			var Cont = 0;
			for (var i=0; i < Temp; i++)   
			{  
			Carac =  document.Geral.CEP.value.charAt (i);
			Posic  = Numeros.indexOf (Carac);   
			if (Posic == -1)   
				{	  
    				alert("Informe um CEP válido. Ex. 70001-970");
    				document.Geral.CEP.focus();
    				return (false);
				}
			}   
			}
			}
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
		function troca1() {		
					document.all.LnkBtnDdoFlu.click();			
		}
		function troca2() {			
					document.all.LnkBtnDdoRep.click();
		}	
		function troca3() {
					document.all.LnkBtnDdoCjg.click();
		}
		function troca4() {
					document.all.LnkBtnDdoBco.click();
		}		
		function troca5() {
					document.all.LnkBtnTetVnd.click();
		}
		function troca6() {
					document.all.LnkBtnOpnEtv.click();
		}
		function troca7() {
					document.all.LnkBtnPnd.click();
		}		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<DIV style="Z-INDEX: 101; LEFT: 8px; WIDTH: 10px; POSITION: absolute; TOP: 8px; HEIGHT: 10px"
			ms_positioning="text2D">
			<FORM id="Form1" method="post" runat="server">
				<asp:panel id="PnlDdoFlu" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server"
					Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small"
					ForeColor="Red" Height="128px">
					<TABLE id="Table21" style="VERTICAL-ALIGN: top; WIDTH: 755px; HEIGHT: 300px" cellSpacing="0"
						cellPadding="0" align="center" border="0">
						<TR vAlign="bottom">
							<TD style="WIDTH: 2px; HEIGHT: 16px" width="2"></TD>
							<TD style="HEIGHT: 16px" height="16">
								<TABLE id="Table22" style="TABLE-LAYOUT: fixed" cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD vAlign="top" height="17"><IMG src="images/AbaFlu.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="71,0,179,16" href="javascript:troca2()">
												<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
												<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
												<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
											</MAP>
										</TD> <!--
								<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/ImgTabDesMei01.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra01.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/ImgTabDesMei02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/ImgTabDesMei02.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/ImgTabDesMei02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/ImgTabDesMei02.gif"
									height="17"><u>T</u>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 16px" width="8"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 2px" width="2"><IMG id="Img9" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD bgColor="#e0eafc"></TD>
							<TD vAlign="top" width="8"><IMG id="Img10" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD style="WIDTH: 2px" width="2" bgColor="#e0eafc"></TD>
							<TD vAlign="top">
								<TABLE id="Table23" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
									borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
									bgColor="#e0eafc" border="0">
									<TR>
										<TD style="HEIGHT: 100%" vAlign="top" align="right">
											<TABLE id="Table24" style="HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc"
												border="0">
												<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitNumReq" runat="server" ForeColor="Black" Height="17px">Nro Requisição:</asp:label></TD>
													<TD>
														<asp:label id="NumReq" runat="server" Font-Size="X-Small" ForeColor="Maroon" Height="17px">0000</asp:label></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px; HEIGHT: 18px" align="right">
														<asp:label id="TitSta" runat="server" ForeColor="Black" Height="17px">Status:</asp:label></TD>
													<TD style="HEIGHT: 18px">
														<asp:label id="NomSta" runat="server" Font-Size="X-Small" ForeColor="Maroon" Height="17px">Novo</asp:label></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitRspPrxAco" runat="server" Visible="False" ForeColor="Black" Height="17px">Resp. próxima ação:</asp:label></TD>
													<TD style="WIDTH: 360px">
														<asp:textbox id="RspPrxAco" runat="server" Visible="False" Width="184px" Enabled="False" CssClass="tit"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitFlu" runat="server" ForeColor="Black" Height="17px">Fluxo:</asp:label></TD>
													<TD style="WIDTH: 360px">
														<asp:textbox id="LstFlu" runat="server" Width="600px" ForeColor="DimGray" Height="200px" ReadOnly="True"
															TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitOpn" runat="server" Visible="False" ForeColor="Black" Height="17px"> Pareceres:</asp:label></TD>
													<TD style="WIDTH: 360px">
														<asp:textbox id="NomOpn" runat="server" Visible="False" Width="184px" Enabled="False" CssClass="tit"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitDatSlc" runat="server" ForeColor="Black" Height="17px">Data Solicitação:</asp:label></TD>
													<TD style="WIDTH: 360px">
														<asp:textbox id="DatSlc" runat="server" Width="72px" Enabled="False" CssClass="tit"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 180px" align="right">
														<asp:label id="TitDatEft" runat="server" ForeColor="Black" Height="17px">Data Efetivação:</asp:label></TD>
													<TD style="WIDTH: 360px">
														<asp:textbox id="DatEft" runat="server" Width="72px" Enabled="False" CssClass="tit"></asp:textbox></TD>
												</TR>
											</TABLE>
											<asp:datagrid id="GrpDdoStaFlu" runat="server" Visible="False" BackColor="White" Width="603px"
												AutoGenerateColumns="False" BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999"
												BorderStyle="None">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<Columns>
													<asp:BoundColumn DataField="DESSTACADREP" HeaderText="Status">
														<HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NOMUSRULTALT" HeaderText="Usu&#225;rio Altera&#231;&#227;o">
														<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DATHRAULTALT" HeaderText="Data Altera&#231;&#227;o">
														<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TABLE>
							</TD>
							<TD width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 2px" width="2"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD width="100%" background="images/ImgFnd.gif"></TD>
							<TD width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<DIV id="Div1" style="VISIBILITY: visible"></DIV>
				<asp:panel id="PnlDdoRep" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 600px"
					runat="server" Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small"
					ForeColor="Red" Height="128px">
					<TABLE id="Table25" style="WIDTH: 755px; HEIGHT: 435px" cellSpacing="0" cellPadding="0"
						width="630" align="center" border="0">
						<TR vAlign="bottom">
							<TD style="WIDTH: 17px; HEIGHT: 8px" width="17"></TD>
							<TD style="HEIGHT: 8px" height="8">
								<TABLE id="Table26" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
									border="0">
									<TR>
										<TD vAlign="top" height="17"><IMG src="images/AbaRep.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="0,0,67,16" href="javascript:troca1()">
												<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
												<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
												<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
											</MAP>
										</TD> <!--
											<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/meio02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/meio01.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra01.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/meio02.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/meio02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/meio02.gif"
									height="17"><u>T</u>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/meio02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/meio02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
							--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 8px" width="8"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17px" width="17"><IMG id="Img11" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD bgColor="#e0eafc"></TD>
							<TD vAlign="top" width="8"><IMG id="Img12" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD style="WIDTH: 17px" width="17" bgColor="#e0eafc"></TD>
							<TD vAlign="top">
								<TABLE id="Table27" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
									borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
									bgColor="#e0eafc" border="0">
									<TR>
										<TD style="HEIGHT: 100%" vAlign="top">
											<TABLE id="Table28" style="HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc"
												border="0">
												<TR> <!--TD colSpan="4"><BR>
											<TD-->
												<TR>
												<TR>
													<TD align="center" colSpan="4">
														<asp:Label id="DesMsgRepTrbMrt" runat="server" Visible="False" ForeColor="#C00000" Font-Bold="True">Este representante já trabalhou no Martins de 02/02/2003 ate 02/04/2003</asp:Label></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitGerVnd" runat="server" ForeColor="Black" Height="17px">G.V:</asp:label></TD>
													<TD colSpan="3">
														<asp:label id="NomGerVnd" runat="server" Font-Size="X-Small" ForeColor="Black" Height="17px">Gerente Vendas</asp:label>
														<asp:Image id="ImgGerVnd" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitGerMcd" runat="server" ForeColor="Black" Height="17px">G.M:</asp:label></TD>
													<TD colSpan="3">
														<asp:label id="NomGerMcd" runat="server" Font-Size="X-Small" ForeColor="Black" Height="17px">Gerente Mercado</asp:label>
														<asp:Image id="ImgGerMcd" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitNomRep" runat="server" ForeColor="Black" Height="17px" CssClass="INPUT">Nome:</asp:label></TD>
													<TD colSpan="3">
														<asp:textbox id="DesNomRep" runat="server" Width="230px" Enabled="False" MaxLength="30"></asp:textbox>
														<asp:Image id="ImgNomRep" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitCpf" runat="server" ForeColor="Black" Height="17px">CPF:</asp:label></TD>
													<TD>
														<asp:TextBox id="DesNumCpf" runat="server" Width="115px" Enabled="False" MaxLength="14" AutoPostBack="True"></asp:TextBox>
														<asp:Image id="ImgNumCpf" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD align="right">
														<asp:label id="TitDatNsc" runat="server" ForeColor="Black" Height="17px">Data Nascimento:</asp:label></TD>
													<TD colSpan="3">
														<asp:TextBox id="DesDatNsc" runat="server" Width="86px" Enabled="False" MaxLength="10" AutoPostBack="True"></asp:TextBox>
														<ew:calendarpopup id="DatNsc" tabIndex="28" runat="server" Width="0px" Height="21px" Enabled="False"
															AutoPostBack="True" AllowArbitraryText="False" ClearDateText="Nenhuma" Nullable="True" GoToTodayText="Data Atual:">
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
														</ew:calendarpopup>
														<asp:Image id="ImgDatNsc" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 25px" align="right">
														<asp:label id="TitCrtIdt" runat="server" ForeColor="Black" Height="17px">RG:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 25px">
														<asp:textbox id="DesNumCrtIdt" runat="server" Width="90px" Enabled="False" MaxLength="11"></asp:textbox>
														<asp:Image id="ImgNumCrtIdt" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif"
															ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="HEIGHT: 25px" align="right">
														<asp:label id="TitOrgEms" runat="server" ForeColor="Black" Height="17px">Órgão Emissor:</asp:label></TD>
													<TD style="HEIGHT: 25px">
														<asp:textbox id="DesOrgEms" runat="server" Width="50px" Enabled="False" MaxLength="5"></asp:textbox>
														<asp:Image id="ImgOrgEms" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 24px" align="right">
														<asp:label id="TitCshReg" runat="server" ForeColor="Black" Height="17px">Core:</asp:label></TD>
													<TD style="HEIGHT: 24px">
														<asp:textbox id="DesCshReg" runat="server" Width="85px" Enabled="False" MaxLength="10"></asp:textbox></TD>
													<TD style="HEIGHT: 24px" align="right">
														<asp:label id="TitDatCadCshReg" runat="server" ForeColor="Black" Height="17px">Data Cadastro Core:</asp:label></TD>
													<TD style="HEIGHT: 24px" colSpan="3">
														<asp:TextBox id="DesDatCadCshReg" runat="server" Width="86px" Enabled="False" MaxLength="10"
															AutoPostBack="True"></asp:TextBox>
														<ew:calendarpopup id="DatCadCshReg" tabIndex="28" runat="server" Width="0px" Height="21px" Enabled="False"
															AutoPostBack="True" AllowArbitraryText="False" ClearDateText="Nenhuma" Nullable="True" GoToTodayText="Data Atual:">
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
												</TR>
												<TR>
													<TD style="HEIGHT: 16px" align="right">
														<asp:label id="TitSitCshReg" runat="server" ForeColor="Black" Height="17px">Situação Core:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 16px">
														<asp:DropDownList id="LstSitCshReg" runat="server" Width="104px" Enabled="False">
															<asp:ListItem Value=" "></asp:ListItem>
															<asp:ListItem Value="PR">PR-Protocolo</asp:ListItem>
														</asp:DropDownList></TD>
													<TD style="HEIGHT: 16px" align="right">
														<asp:label id="TitEstCshReg" runat="server" ForeColor="Black" Height="17px">Estado Core:</asp:label></TD>
													<TD style="HEIGHT: 16px"><BUTTONSTYLE BackColor="ControlLightLight" ForeColor="Black" BorderStyle="Groove" Font-Bold="True">
															<asp:dropdownlist id="LstEstCshReg" runat="server" Width="48px" Enabled="False"></asp:dropdownlist>
														</BUTTONSTYLE><TODAYDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></TODAYDAYSTYLE><SELECTEDDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="SkyBlue" Font-Size="XX-Small"
															ForeColor="Black"></SELECTEDDATESTYLE><GOTOTODAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></GOTOTODAYSTYLE><CLEARDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></CLEARDATESTYLE><WEEKENDSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="SteelBlue"></WEEKENDSTYLE><MONTHHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="Black" Font-Size="XX-Small"
															ForeColor="White"></MONTHHEADERSTYLE><OFFMONTHSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="WhiteSmoke" Font-Size="XX-Small"
															ForeColor="Gray"></OFFMONTHSTYLE><DAYHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="#0F4871" Font-Size="XX-Small"
															ForeColor="White"></DAYHEADERSTYLE><WEEKDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></WEEKDAYSTYLE><BUTTONSTYLE BackColor="ControlLightLight" ForeColor="Black" BorderStyle="Groove" Font-Bold="True"></BUTTONSTYLE><TODAYDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></TODAYDAYSTYLE><SELECTEDDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="SkyBlue" Font-Size="XX-Small"
															ForeColor="Black"></SELECTEDDATESTYLE><GOTOTODAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></GOTOTODAYSTYLE><CLEARDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></CLEARDATESTYLE><WEEKENDSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="SteelBlue"></WEEKENDSTYLE><MONTHHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="Black" Font-Size="XX-Small"
															ForeColor="White"></MONTHHEADERSTYLE><OFFMONTHSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="WhiteSmoke" Font-Size="XX-Small"
															ForeColor="Gray"></OFFMONTHSTYLE><DAYHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="#0F4871" Font-Size="XX-Small"
															ForeColor="White"></DAYHEADERSTYLE><WEEKDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></WEEKDAYSTYLE><BUTTONSTYLE BackColor="ControlLightLight" ForeColor="Black" BorderStyle="Groove" Font-Bold="True"></BUTTONSTYLE><TODAYDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></TODAYDAYSTYLE><SELECTEDDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="SkyBlue" Font-Size="XX-Small"
															ForeColor="Black"></SELECTEDDATESTYLE><GOTOTODAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></GOTOTODAYSTYLE><CLEARDATESTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></CLEARDATESTYLE><WEEKENDSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="SteelBlue"></WEEKENDSTYLE><MONTHHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="Black" Font-Size="XX-Small"
															ForeColor="White"></MONTHHEADERSTYLE><OFFMONTHSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="WhiteSmoke" Font-Size="XX-Small"
															ForeColor="Gray"></OFFMONTHSTYLE><DAYHEADERSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="#0F4871" Font-Size="XX-Small"
															ForeColor="White"></DAYHEADERSTYLE><WEEKDAYSTYLE Font-Names="Verdana,Helvetica,Tahoma,Arial" BackColor="White" Font-Size="XX-Small"
															ForeColor="Black"></WEEKDAYSTYLE></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 25px" align="right">
														<asp:label id="TitInss" runat="server" ForeColor="Black" Height="17px">INSS:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 25px">
														<asp:textbox id="DesNumInss" runat="server" Width="90px" Enabled="False" MaxLength="11" AutoPostBack="True"></asp:textbox></TD>
													<TD style="HEIGHT: 25px" align="right"></TD>
													<TD style="HEIGHT: 25px"></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitSex" runat="server" ForeColor="Black" Height="17px">Sexo:</asp:label></TD>
													<TD style="WIDTH: 227px">
														<asp:RadioButtonList id="RadBtnSex" runat="server" Width="140px" Font-Size="XX-Small" Height="0px" Enabled="False"
															RepeatDirection="Horizontal" RepeatLayout="Flow">
															<asp:ListItem Value="M">Masculino</asp:ListItem>
															<asp:ListItem Value="F" Selected="True">Feminino</asp:ListItem>
														</asp:RadioButtonList>
														<asp:Image id="ImgSex" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD align="right"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 20px" align="right">
														<asp:label id="TitNac" runat="server" ForeColor="Black" Height="17px">Nacionalidade:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 20px">
														<asp:textbox id="DesNac" runat="server" Width="120px" Enabled="False" MaxLength="15"></asp:textbox>
														<asp:Image id="ImgNac" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="HEIGHT: 20px" align="right"></TD>
													<TD style="HEIGHT: 20px"></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" align="right">
														<asp:label id="TitEcl" runat="server" ForeColor="Black" Height="17px">Escolaridade:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 23px">
														<asp:dropdownlist id="NumGraEcl" runat="server" Width="40px" Enabled="False">
															<asp:ListItem Value="1">1&#186;</asp:ListItem>
															<asp:ListItem Value="2">2&#186;</asp:ListItem>
															<asp:ListItem Value="3">3&#186;</asp:ListItem>
														</asp:dropdownlist>
														<asp:dropdownlist id="LstCplEcl" runat="server" Width="95px" Enabled="False">
															<asp:ListItem Value="C">C-Completo</asp:ListItem>
															<asp:ListItem Value="I">I-Incompleto</asp:ListItem>
														</asp:dropdownlist>
														<asp:Image id="ImgEcl" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="HEIGHT: 23px" align="right">
														<asp:label id="TitEstCvl" runat="server" ForeColor="Black" Height="17px">Estado Civil:</asp:label></TD>
													<TD style="HEIGHT: 23px">
														<asp:dropdownlist id="LstEstCvl" runat="server" Width="86px" Enabled="False">
															<asp:ListItem Value="C">C-Casado</asp:ListItem>
															<asp:ListItem Value="D">D-Divorciado</asp:ListItem>
															<asp:ListItem Value="S">S-Solteiro</asp:ListItem>
															<asp:ListItem Value="V">V-Vi&#250;vo</asp:ListItem>
														</asp:dropdownlist>
														<asp:Image id="ImgEstCvl" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 18px" align="right">
														<asp:label id="TitEst" runat="server" ForeColor="Black" Height="17px">Estado:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 18px">
														<asp:dropdownlist id="LstEst" runat="server" Width="48px" Enabled="False" AutoPostBack="True"></asp:dropdownlist>
														<asp:Image id="ImgEst" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="HEIGHT: 18px" align="right">
														<asp:label id="TitCid" runat="server" ForeColor="Black" Height="17px">Cidade:</asp:label></TD>
													<TD style="HEIGHT: 18px">
														<asp:dropdownlist id="LstCid" runat="server" Width="250px" Enabled="False" AutoPostBack="True"></asp:dropdownlist>
														<asp:Image id="ImgCid" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 3px" align="right">
														<asp:label id="TitBai" runat="server" ForeColor="Black" Height="17px">Bairro:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 3px">
														<asp:dropdownlist id="LstNomBai" runat="server" Width="180px" Enabled="False" AutoPostBack="True"></asp:dropdownlist>
														<asp:Image id="ImgBai" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="HEIGHT: 3px" align="right">
														<asp:label id="TitCpl" runat="server" ForeColor="Black" Height="17px">Complemento:</asp:label></TD>
													<TD style="HEIGHT: 3px">
														<asp:dropdownlist id="LstCplBai" runat="server" Width="250px" Enabled="False" AutoPostBack="True"></asp:dropdownlist>
														<asp:Image id="ImgCplBai" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitEnd" runat="server" ForeColor="Black" Height="17px">Endereço:</asp:label></TD>
													<TD colSpan="3">
														<asp:textbox id="DesEnd" runat="server" Width="230px" Enabled="False" MaxLength="30"></asp:textbox>
														<asp:Image id="ImgEnd" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitCep" runat="server" ForeColor="Black" Height="17px">CEP:</asp:label></TD>
													<TD>
														<asp:textbox id="DesNumCep" runat="server" Width="85px" Enabled="False" MaxLength="10"></asp:textbox>
														<asp:Image id="ImgCep" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD align="right">
														<asp:label id="TitUndNgc" runat="server" ForeColor="Black" Height="17px">Unidade de Negócio:</asp:label></TD>
													<TD colSpan="3">
														<asp:dropdownlist id="LstUndNgc" runat="server" Width="128px" Enabled="False">
															<asp:ListItem Value="1">1-Atacado</asp:ListItem>
															<asp:ListItem Value="3">3-Broker</asp:ListItem>
														</asp:dropdownlist>
														<asp:Image id="ImgUndNgc" runat="server" Visible="False" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitRsi" runat="server" ForeColor="Black" Height="17px">Residência:</asp:label></TD>
													<TD style="WIDTH: 227px">
														<asp:dropdownlist id="LstRsi" runat="server" Width="88px" Enabled="False">
															<asp:ListItem Value="A">A-Alugada</asp:ListItem>
															<asp:ListItem Value="P">P-Pr&#243;pria</asp:ListItem>
														</asp:dropdownlist>
														<asp:Image id="ImgRsi" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD align="right">
														<asp:label id="TitVtg" runat="server" ForeColor="Black" Height="17px">Voltagem:</asp:label></TD>
													<TD>
														<asp:dropdownlist id="LstVtg" runat="server" Width="88px" Enabled="False">
															<asp:ListItem Value="110">110 Volts</asp:ListItem>
															<asp:ListItem Value="220">220 Volts</asp:ListItem>
														</asp:dropdownlist>
														<asp:Image id="ImgVtg" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitTlf" runat="server" ForeColor="Black" Height="17px">Telefone:</asp:label></TD>
													<TD style="WIDTH: 227px">
														<asp:textbox id="NumTlf" runat="server" Width="105px" Enabled="False" MaxLength="13"></asp:textbox></TD>
													<TD colSpan="2">
														<asp:dropdownlist id="LstSitTlf" runat="server" Width="96px" Enabled="False">
															<asp:ListItem></asp:ListItem>
															<asp:ListItem Value="N">A-Alugado</asp:ListItem>
															<asp:ListItem Value="S">P-Pr&#243;prio</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 18px" align="right">
														<asp:label id="TitFax" runat="server" ForeColor="Black" Height="17px">Fax:</asp:label></TD>
													<TD style="WIDTH: 227px; HEIGHT: 18px">
														<asp:textbox id="NumFax" runat="server" Width="105px" Enabled="False" MaxLength="13"></asp:textbox></TD>
													<TD style="HEIGHT: 18px" colSpan="2">
														<asp:dropdownlist id="LstSitFax" runat="server" Width="96px" Enabled="False">
															<asp:ListItem></asp:ListItem>
															<asp:ListItem Value="N">A-Alugado</asp:ListItem>
															<asp:ListItem Value="S">P-Pr&#243;prio</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD align="right">
														<asp:label id="TitCel" runat="server" ForeColor="Black" Height="17px"> Celular:</asp:label></TD>
													<TD style="WIDTH: 227px">
														<asp:textbox id="NumCel" runat="server" Width="105px" Enabled="False" MaxLength="13"></asp:textbox></TD>
													<TD align="right">
														<asp:label id="TitSgmMcd" runat="server" ForeColor="Black" Height="17px">Seg. Mercado:</asp:label></TD>
													<TD>
														<asp:dropdownlist id="LstSgmMcd" runat="server" Width="250px" Enabled="False"></asp:dropdownlist>
														<asp:Image id="ImgSgmMcd" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17px" width="17"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD width="100%" background="images/ImgFnd.gif"></TD>
							<TD width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<DIV id="EleDdoBtn" style="DISPLAY: none; VISIBILITY: hidden"><asp:linkbutton id="LnkBtnPnd" style="Z-INDEX: 114; LEFT: 496px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black">Pendencia</asp:linkbutton><asp:linkbutton id="LnkBtnOpnEtv" style="Z-INDEX: 113; LEFT: 416px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black">Avaliacao</asp:linkbutton><asp:linkbutton id="LnkBtnDdoCjg" style="Z-INDEX: 110; LEFT: 192px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" BackColor="Transparent" Font-Size="XX-Small" ForeColor="Black" BorderStyle="None" Font-Bold="True">Conjuge</asp:linkbutton><asp:linkbutton id="LnkBtnTetVnd" style="Z-INDEX: 112; LEFT: 336px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black">Territorio</asp:linkbutton><asp:linkbutton id="LnkBtnDdoBco" style="Z-INDEX: 111; LEFT: 264px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" BackColor="Transparent" Font-Size="XX-Small" ForeColor="Black" BorderStyle="None" Font-Bold="True">Banco</asp:linkbutton><asp:linkbutton id="LnkBtnDdoRep" style="Z-INDEX: 109; LEFT: 88px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" BackColor="Transparent" Font-Size="XX-Small" ForeColor="Black" BorderStyle="None" Font-Bold="True">Representante</asp:linkbutton><asp:linkbutton id="LnkBtnDdoFlu" style="Z-INDEX: 108; LEFT: 24px; POSITION: absolute; TOP: 3488px"
						runat="server" Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black">Fluxo</asp:linkbutton><asp:linkbutton id="LnkEdt" style="Z-INDEX: 114; LEFT: 584px; POSITION: absolute; TOP: 3488px" runat="server"
						Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black">Editar</asp:linkbutton><asp:linkbutton id="LnkGrv" style="Z-INDEX: 104; LEFT: 648px; POSITION: absolute; TOP: 3488px" runat="server"
						Font-Names="Arial" Font-Size="XX-Small" ForeColor="Black" DESIGNTIMEDRAGDROP="1430">Gravar</asp:linkbutton></DIV>
				<asp:panel id="PnlDdoCjg" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 1240px"
					runat="server" Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small"
					ForeColor="Red" Height="128px">
					<TABLE id="Table17" style="WIDTH: 755px; HEIGHT: 100px" cellSpacing="0" cellPadding="0"
						width="630" align="center" border="0">
						<TR vAlign="bottom">
							<TD style="HEIGHT: 13px" width="8"></TD>
							<TD style="HEIGHT: 13px" height="13">
								<TABLE id="Table18" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
									border="0">
									<TR>
										<TD vAlign="top" height="17"><IMG src="images/AbaCjg.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="0,0,66,16" href="javascript:troca1()">
												<AREA shape="RECT" coords="72,0,179,16" href="javascript:troca2()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
												<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
												<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
											</MAP>
										</TD> <!--
								<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/ImgTabDesMei02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/ImgTabDesMei02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/ImgTabDesMei01.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra01.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/ImgTabDesMei02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/ImgTabDesMei02.gif"
									height="17">T</U>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 13px" width="8"></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 18px" width="8"><IMG id="Img7" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD style="HEIGHT: 18px" bgColor="#e0eafc"></TD>
							<TD style="HEIGHT: 18px" vAlign="top" width="8"><IMG id="Img8" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD width="8" bgColor="#e0eafc"></TD>
							<TD vAlign="top">
								<TABLE id="Table19" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
									borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
									bgColor="#e0eafc" border="0">
									<TR>
										<TD style="HEIGHT: 100%" vAlign="top">
											<TABLE id="Table20" style="HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc"
												border="0">
												<TR> <!--TD colSpan="4"><BR>
											</TD--></TR>
												<TR>
													<TD style="WIDTH: 76px" align="right">
														<asp:label id="TitNomCjg" runat="server" ForeColor="Black" Height="17px">Nome:</asp:label></TD>
													<TD colSpan="3">
														<asp:textbox id="DesNomCjg" runat="server" Width="230px" Enabled="False" MaxLength="30"></asp:textbox>
														<asp:Image id="ImgNomCjg" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 76px" align="right">
														<asp:label id="TitNumCrtIdtCjg" runat="server" ForeColor="Black" Height="17px">RG:</asp:label></TD>
													<TD>
														<asp:textbox id="DesNumCrtIdtCjg" runat="server" Width="90px" Enabled="False" MaxLength="11"></asp:textbox></TD>
													<TD style="WIDTH: 225px" align="right">
														<asp:label id="TitOrgEmsCjg" runat="server" ForeColor="Black" Height="17px">Órgão Emissor:</asp:label></TD>
													<TD>
														<asp:textbox id="DesOrgEmsCjg" runat="server" Width="50px" Enabled="False" MaxLength="5"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 76px" align="right">
														<asp:label id="TitNumFlhCjg" runat="server" ForeColor="Black" Height="17px">Nº Filhos:</asp:label></TD>
													<TD>
														<asp:textbox id="DesNumFlhCjg" runat="server" Width="25px" Enabled="False" MaxLength="2"></asp:textbox>
														<asp:Image id="ImgNumFlhCjg" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
													<TD style="WIDTH: 225px" align="right">
														<asp:label id="TitDatNscCjg" runat="server" ForeColor="Black" Height="17px">Data Nascimento:</asp:label></TD>
													<TD>
														<asp:TextBox id="DesDatNscCjg" runat="server" Width="86px" Enabled="False" MaxLength="10" AutoPostBack="True"></asp:TextBox>
														<ew:calendarpopup id="DatNscCjg" tabIndex="28" runat="server" Width="0px" Height="21px" Enabled="False"
															AutoPostBack="True" AllowArbitraryText="False" ClearDateText="Nenhuma" Nullable="True" GoToTodayText="Data Atual:"
															PadSingleDigits="True">
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
														</ew:calendarpopup>
														<asp:Image id="ImgDatNscCjg" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
												</TR>
											</TABLE>
											<P>&nbsp;</P>
											<P>&nbsp;</P>
											<P>&nbsp;</P>
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD width="8"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD width="100%" background="images/ImgFnd.gif"></TD>
							<TD width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="PnlDdoBco" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 1528px"
					runat="server" Font-Names="Verdana" Visible="False" BackColor="White" Font-Size="X-Small" ForeColor="Red">
					<P>
						<TABLE id="Table29" style="WIDTH: 755px; HEIGHT: 230px" cellSpacing="0" cellPadding="0"
							width="755" align="center" border="0">
							<TR vAlign="bottom">
								<TD style="WIDTH: 17px; HEIGHT: 13px" width="17"></TD>
								<TD style="HEIGHT: 13px" height="13">
									<TABLE id="Table30" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
										border="0">
										<TR>
											<TD vAlign="top" height="17"><IMG height="18" src="images/AbaDdoBco.jpg" width="718" useMap="DocVAKNavCadRep.aspx#lnk"
													border="0"> <MAP name="lnk">
													<AREA shape="RECT" coords="0,0,66,16" href="javascript:troca1()">
													<AREA shape="RECT" coords="72,0,179,16" href="javascript:troca2()">
													<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
													<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
													<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
													<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
												</MAP>
											</TD> <!--
								<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/ImgTabDesMei02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/ImgTabDesMei02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/ImgTabDesMei01.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra01.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/ImgTabDesMei02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/ImgTabDesMei02.gif"
									height="17">T</U>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								--></TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 13px" width="8"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 17px; HEIGHT: 18px" width="17"><IMG id="Img13" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
								<TD style="HEIGHT: 18px" bgColor="#e0eafc"></TD>
								<TD style="HEIGHT: 18px" vAlign="top" width="8"><IMG id="Img14" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
							</TR>
							<TR vAlign="top">
								<TD style="WIDTH: 17px" width="17" bgColor="#e0eafc"></TD>
								<TD vAlign="top">
									<TABLE id="Table31" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
										borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
										bgColor="#e0eafc" border="0">
										<TR>
											<TD style="HEIGHT: 100%" vAlign="top">
												<P>
													<TABLE id="Table16" style="WIDTH: 694px; HEIGHT: 80px" cellSpacing="1" cellPadding="1"
														width="694" align="center" bgColor="#e0eafc" border="0">
														<TR>
														</TR>
														<TR>
															<TD style="WIDTH: 141px; HEIGHT: 22px" align="right">
																<asp:label id="TitBco" runat="server" ForeColor="Black" Height="17px">Banco:</asp:label></TD>
															<TD style="HEIGHT: 22px">
																<asp:DropDownList id="LstNomBco" runat="server" Width="280px" Enabled="False" AutoPostBack="True"></asp:DropDownList>
																<asp:Image id="ImgNomBco" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 141px" align="right">
																<asp:label id="TitAge" runat="server" ForeColor="Black" Height="17px">Agência:</asp:label></TD>
															<TD>
																<asp:DropDownList id="LstAgeBco" runat="server" Width="280px" Enabled="False" AutoPostBack="True"></asp:DropDownList>
																<asp:Image id="ImgAgeBco" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 141px" align="right">
																<asp:label id="TitCntCrr" runat="server" ForeColor="Black" Height="17px">Conta Corrente:</asp:label></TD>
															<TD>
																<asp:textbox id="DesNumCntCrr" runat="server" Width="100px" Enabled="False" MaxLength="12"></asp:textbox>
																<asp:Image id="ImgNumCntCrr" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Preenchimento obrigatório!"></asp:Image></TD>
														</TR>
													</TABLE>
												</P>
												<P>&nbsp;</P>
												<P>
													<asp:label id="TitDdo" runat="server" ForeColor="Black" Height="17px" Font-Bold="True">* Dados referentes à pessoa física</asp:label></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="8" bgColor="#e0eafc"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 17px" width="17" height="16"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
								<TD width="100%" background="images/ImgFnd.gif" height="16"></TD>
								<TD width="8" height="16"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
							</TR>
						</TABLE>
					</P>
					<P>&nbsp;</P>
				</asp:panel><asp:panel id="PnlDdoTetVnd" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 1800px"
					runat="server" Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small"
					ForeColor="Red" Height="128px">
					<TABLE id="Table9" style="WIDTH: 755px; HEIGHT: 200px" cellSpacing="0" cellPadding="0"
						width="630" align="center" border="0">
						<TR vAlign="bottom">
							<TD style="WIDTH: 17px; HEIGHT: 4px" width="17"></TD>
							<TD style="HEIGHT: 4px" height="4">
								<TABLE id="Table10" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
									border="0">
									<TR>
										<TD vAlign="bottom" height="17"><IMG src="images/AbaTetVnd.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="0,0,66,16" href="javascript:troca1()">
												<AREA shape="RECT" coords="72,0,179,16" href="javascript:troca2()">
												<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
												<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
											</MAP>
										</TD> <!--
								<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/ImgTabDesMei02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/ImgTabDesMei02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/ImgTabDesMei02.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/ImgTabDesMei02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq01.gif" width="8" align="bottom"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/ImgTabDesMei01.gif"
									height="17"><u>T</u>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra01.gif" width="8" align="bottom"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8" align="bottom"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8" align="bottom"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 4px" width="8"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17px" width="17"><IMG id="Img3" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD bgColor="#e0eafc"></TD>
							<TD vAlign="top" width="8"><IMG id="Img4" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD style="WIDTH: 17px; HEIGHT: 273px" width="17" bgColor="#e0eafc"></TD>
							<TD style="HEIGHT: 273px" vAlign="top">
								<TABLE id="Table11" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
									borderColor="#96b1cb" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
									bgColor="#e0eafc" border="0">
									<TR>
										<TD style="HEIGHT: 100%" vAlign="top" align="center">
											<TABLE id="Table12" style="HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="100%" bgColor="#e0eafc"
												border="0">
												<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2"><BR>
											</TD--></TR>
												<TR>
													<TD style="WIDTH: 100%" align="center" colSpan="2">
														<asp:label id="TitVlr" runat="server" ForeColor="Black" Height="17px" Font-Bold="True">Valor Vendido pelo(s) território(s) nos 3 ultimos meses:</asp:label>&nbsp;</TD>
												</TR>
											</TABLE>
											<asp:datagrid id="GrpDdoVlrVnd" runat="server" Visible="False" BackColor="White" AutoGenerateColumns="False"
												BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<Columns>
													<asp:BoundColumn DataField="CODTETVND" HeaderText="C&#243;digo">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DESTETVND" HeaderText="Territ&#243;rio">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CODREP" HeaderText="C&#243;digo">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NOMREP" HeaderText="Representante">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="VLRCMP1" HeaderText="Mes1" DataFormatString="{0:N2}">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="VLRCMP2" HeaderText="Mes2" DataFormatString="{0:N2}">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="VLRCMP3" HeaderText="Mes3" DataFormatString="{0:N2}">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
											<asp:Image id="ImgVlrVndTet" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="Selecione pelo menos um território"></asp:Image>
											<asp:Label id="MsgSelTet" runat="server" ForeColor="Red">Selecione pelo menos um território</asp:Label>&nbsp;
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 273px" width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 17px" width="17"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD width="100%" background="images/ImgFnd.gif"></TD>
							<TD width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="PnlOpnEtv" style="Z-INDEX: 116; LEFT: 16px; POSITION: absolute; TOP: 2168px"
					runat="server" Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small"
					ForeColor="Red" Height="720px">
					<TABLE id="Table4" style="WIDTH: 755px" cellSpacing="0" cellPadding="0" width="631" align="center"
						border="0">
						<TR vAlign="bottom">
							<TD style="HEIGHT: 10px" width="8"></TD>
							<TD style="WIDTH: 722px; HEIGHT: 10px" height="10">
								<TABLE id="Table5" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
									border="0">
									<TR>
										<TD vAlign="bottom" height="17"><IMG src="images/AbaAvl.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="0,0,66,16" href="javascript:troca1()">
												<AREA shape="RECT" coords="71,0,179,16" href="javascript:troca2()">
												<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
												<AREA shape="RECT" coords="633,0,718,16" href="javascript:troca7()">
											</MAP>
										</TD> <!--
								<td style="HEIGHT: 17px" vAlign="bottom" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/esquerda02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/meio02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/direita02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/esquerda02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/meio02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/direita02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/esquerda02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/meio02.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/direita02.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/esquerda02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/meio02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/direita02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/esquerda02.gif" width="8" align="bottom"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/meio02.gif"
									height="17"><u>T</u>erritório Vendas</U></td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/direita02.gif" width="8" align="bottom"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/esquerda01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/meio01.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="bottom" align="left" width="8" height="17"><IMG height="16" src="images/direita01.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/esquerda02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/meio02.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/direita02.gif" width="8"></td>
								--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 10px" width="8"></TD>
						</TR>
						<TR>
							<TD width="8"><IMG id="Img1" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD style="WIDTH: 722px" bgColor="#e0eafc"></TD>
							<TD vAlign="top" width="8"><IMG id="Img2" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD style="HEIGHT: 585px" width="10" bgColor="#e0eafc"></TD>
							<TD style="WIDTH: 722px; HEIGHT: 585px" vAlign="top" bgColor="#e0eafc">
								<TABLE id="Table6" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px"
									borderColor="#96b1cb" cellSpacing="0" cellPadding="0" align="center" bgColor="#e0eafc"
									border="0">
									<TR>
										<TD vAlign="top" align="center">
											<TABLE id="Table8" style="WIDTH: 639px; HEIGHT: 481px" cellSpacing="1" cellPadding="1"
												width="639" bgColor="#e0eafc" border="0">
												<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2"><BR>
											</TD--></TR>
												<TR>
													<TD style="WIDTH: 212px; HEIGHT: 23px" align="left" colSpan="2">
														<asp:label id="TitRstQld" runat="server" Width="141px" ForeColor="Black" Height="17px" Font-Bold="True">Resultado  Qualitativo:</asp:label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 224px" vAlign="top" align="center"></TD>
													<TD style="HEIGHT: 224px" vAlign="top" align="center">
														<asp:datagrid id="GrpDdoAvl" runat="server" Visible="False" BackColor="White" Width="631px" AutoGenerateColumns="False"
															BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
															<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
															<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
															<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
															<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="CODAVLREP" ReadOnly="True">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="DESTITAVLREP" ReadOnly="True" HeaderText="Avalia&#231;&#227;o">
																	<HeaderStyle HorizontalAlign="Left" Width="280px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn HeaderText="Descri&#231;&#227;o">
																	<ItemTemplate>
																		<asp:TextBox id=DesRstAvl runat="server" Width="400px" ForeColor="DimGray" Height="50px" ReadOnly="True" TextMode="MultiLine" MaxLength="254" Text='<%# DataBinder.Eval(Container, "DataItem.DESCDOAVLREP") %>'>
																		</asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
														</asp:datagrid>&nbsp;
														<asp:Image id="ImgRstAvl" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="É obrigatório o preenchimento de todos os itens de avaliação"></asp:Image>
														<asp:Label id="MsgRstAvl" runat="server" ForeColor="Red">É obrigatório o preenchimento de todos os itens de avaliação</asp:Label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 171px" vAlign="top" align="center"></TD>
													<TD style="HEIGHT: 171px" vAlign="top" align="center">
														<P>
															<asp:datagrid id="GrpDdoCtn" runat="server" Visible="False" BackColor="White" Width="270px" AutoGenerateColumns="False"
																BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
																<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
																<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
																<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
																<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
																<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="CODCTNREP" ReadOnly="True">
																		<HeaderStyle Width="40px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="DESTITCTNREP" ReadOnly="True" HeaderText="Compet&#234;ncia">
																		<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="VLRCTNREP" ReadOnly="True" HeaderText="Nota"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
															</asp:datagrid>&nbsp;
															<asp:Image id="ImgRstCtn" runat="server" ImageUrl="images/ArqImgAla.gif" ToolTip="É obrigatório o preenchimento de todas as notas"></asp:Image>
															<asp:Label id="MsgRstCtn" runat="server" ForeColor="Red">É obrigatório o preenchimento de todas as notas</asp:Label></P>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 212px; HEIGHT: 23px" align="left" colSpan="2">
														<asp:label id="TitRstQde" runat="server" Width="158px" ForeColor="Black" Height="17px" Font-Bold="True">Resultado  Quantitativo:</asp:label></TD>
												</TR>
											</TABLE>
											<asp:datagrid id="GrpDdoRstQde" runat="server" Visible="False" BackColor="White" AutoGenerateColumns="False"
												BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<Columns>
													<asp:BoundColumn DataField="CODAVL" HeaderText="Avalia&#231;&#227;o">
														<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PERPVTAVL" HeaderText="% Aprova&#231;&#227;o">
														<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 585px" width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 2px" width="8"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD style="WIDTH: 722px; HEIGHT: 2px" width="722" background="images/ImgFnd.gif"></TD>
							<TD style="HEIGHT: 2px" width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel><asp:panel id="PnlPnd" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 2920px" runat="server"
					Font-Names="Verdana" Visible="False" BackColor="White" Width="496px" Font-Size="X-Small" ForeColor="Red"
					Height="128px">
					<TABLE id="Table1" style="WIDTH: 755px" cellSpacing="0" cellPadding="0" width="631" align="center"
						border="0">
						<TR vAlign="bottom">
							<TD style="HEIGHT: 3px" width="8"></TD>
							<TD style="HEIGHT: 3px" height="3">
								<TABLE id="Table2" style="TABLE-LAYOUT: fixed; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
									border="0">
									<TR>
										<TD vAlign="bottom" height="17"><IMG src="images/AbaPnd.jpg" useMap="DocVAKNavCadRep.aspx#lnk" border="0">
											<MAP name="lnk">
												<AREA shape="RECT" coords="0,0,66,16" href="javascript:troca1()">
												<AREA shape="RECT" coords="71,0,179,16" href="javascript:troca2()">
												<AREA shape="RECT" coords="186,0,269,16" href="javascript:troca3()">
												<AREA shape="RECT" coords="276,0,393,16" href="javascript:troca4()">
												<AREA shape="RECT" coords="400,0,534,16" href="javascript:troca5()">
												<AREA shape="RECT" coords="541,0,626,16" href="javascript:troca6()">
											</MAP>
										</TD> <!--
								<td style="HEIGHT: 17px" vAlign="top" align="right" width="8" height="17"><IMG id="EleEsqCli" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiCli" title="Dados do Fluxo" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoFlu()" align="center" width="42" background="images/ImgTabDesMei02.gif"
									height="17"><u>F</u>luxo</td>
								<td style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG id="EleDirCli" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG id="EleEsqEnd" height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiEnd" title="Dados do Representante" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoRep()" align="center" width="85" background="images/ImgTabDesMei02.gif"
									height="17"><u>R</u>epresentante</td>
								<td style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG id="EleDirEnd" height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiRep" title="Dados do Cônjuge" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoCjg()" align="center" width="50" background="images/ImgTabDesMei02.gif"
									height="17"><u>C</u>ônjuge</td>
								<td id="EleDirRep" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiTitAbt" title="Dados Bancários" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoBco()" align="center" width="100" background="images/ImgTabDesMei02.gif"
									height="17"><u>D</u>ados Bancários</td>
								<td id="EleDirTitAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8" align="bottom"></td>
								<td class="btnCls" id="EleMeiTitLqd" title="Territórios de Vendas" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoTetVnd()" align="center" width="120" background="images/ImgTabDesMei02.gif"
									height="17"><u>T</u>erritório Vendas</td>
								<td id="EleDirTitLqd" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8" align="bottom"></td>
								<td id="EleEsqOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq02.gif" width="8"></td>
								<td class="btnCls" id="EleMeiOpeVdr" title="Dados da Entrevista" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoEtv()" align="center" width="60" background="images/ImgTabDesMei02.gif"
									height="17"><u>E</u>ntrevista</td>
								<td id="EleDirOpeVdr" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra02.gif" width="8"></td>
								<td id="EleEsqChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesEsq01.gif" width="8"></td>
								<td class="btnCls" id="EleMeiChqAbt" title="Pendências" style="HEIGHT: 17px; nowrap: ; textAlign: rigth"
									onclick="parent.FunSelDdoPnd()" align="center" width="60" background="images/ImgTabDesMei01.gif"
									height="17"><u>P</u>endências</td>
								<td id="EleDirChqAbt" style="HEIGHT: 17px" vAlign="top" align="left" width="8" height="17"><IMG height="16" src="images/ImgTabDesDra01.gif" width="8" align="bottom"></td>
								--></TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 3px" width="8"></TD>
						</TR>
						<TR>
							<TD width="8"><IMG id="Img31" height="18" src="images/ImgTabDesEsqTop.gif" width="16"></TD>
							<TD bgColor="#e0eafc"></TD>
							<TD vAlign="top" width="8"><IMG id="Img32" height="18" src="images/ImgTabDesDra01.gif" width="16"></TD>
						</TR>
						<TR vAlign="top">
							<TD style="HEIGHT: 263px" width="10" bgColor="#e0eafc"></TD>
							<TD style="HEIGHT: 263px" vAlign="top" bgColor="#e0eafc">
								<TABLE id="Table7" style="WIDTH: 721px; HEIGHT: 190px" cellSpacing="1" cellPadding="1"
									width="721" bgColor="#e0eafc" border="0">
									<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2"><BR>												
											</TD--></TR>
									<TR>
										<TD align="center" colSpan="2"></TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:label id="TitPrbSrs" runat="server" ForeColor="Black" Height="17px">Problema Serasa:</asp:label></TD>
										<TD>
											<asp:RadioButtonList id="RblPrbSrs" runat="server" Width="300px" Font-Size="XX-Small" Height="0px" Enabled="False"
												RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="1">Sim</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">N&#227;o</asp:ListItem>
												<asp:ListItem Value="2" Selected="True">Consulta com Problema</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 237px; HEIGHT: 40px" align="right"></TD>
										<TD style="HEIGHT: 40px">
											<asp:textbox id="DesPrbSrs" runat="server" Width="368px" ForeColor="DimGray" Height="164px" ReadOnly="True"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:label id="TitAcePnd" runat="server" ForeColor="Black" Height="17px">Acertos Pendentes:</asp:label></TD>
										<TD style="HEIGHT: 17px">
											<asp:RadioButtonList id="RblAcePnd" runat="server" Width="100px" Font-Size="XX-Small" Height="0px" Enabled="False"
												RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="1">Sim</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">N&#227;o</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:label id="TitAcoTrb" runat="server" ForeColor="Black" Height="17px">Ações Trabalhistas/Cívis:</asp:label></TD>
										<TD style="WIDTH: 360px">
											<asp:textbox id="DesAcoTrb" runat="server" Width="368px" ForeColor="DimGray" Height="120px" ReadOnly="True"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:label id="TitVldCpf" runat="server" ForeColor="Black" Height="17px">Validação CPF:</asp:label></TD>
										<TD style="WIDTH: 360px; HEIGHT: 21px">
											<asp:RadioButtonList id="RblVldCpf" runat="server" Width="100px" Font-Size="XX-Small" Height="0px" Enabled="False"
												RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="1">Sim</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">N&#227;o</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 237px; HEIGHT: 23px" align="right"></TD>
										<TD style="WIDTH: 360px; HEIGHT: 23px"></TD>
									</TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 263px" width="8" bgColor="#e0eafc"></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 8px" width="8"><IMG height="16" src="images/ImgTabDesEsqIfo.gif" width="16"></TD>
							<TD style="HEIGHT: 8px" width="100%" background="images/ImgFnd.gif"></TD>
							<TD style="HEIGHT: 8px" width="8"><IMG height="16" src="images/ImgTabDesDraIfo.gif" width="16"></TD>
						</TR>
					</TABLE>
				</asp:panel></FORM>
		</DIV>
		<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><cc1:messageboxweb id="MsgBoxWeb" runat="server"></cc1:messageboxweb>
	</body>
</HTML>
