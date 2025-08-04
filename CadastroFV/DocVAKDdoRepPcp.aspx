<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKDdoRepPcp.aspx.vb" Inherits="VAKItfUsrWeb.DocVAKDdoRepPcp"%>
<%@ Register TagPrefix="cc2" Namespace="VAK016.Web" Assembly="VAK016" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="SolpartWebControls" Assembly="SolpartWebControls" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DocVAKDdoRepPcp</title>
		<LINK rel="stylesheet" type="text/css" href="comum/default.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="comum/DocFunCmuJS.htm"></script>
		<script language="javascript">
			function YNconfirm(txt){
				return typeof(suporteVBscript)=="undefined"?confirm(txt):VBconfirm(txt)==6
			}					
								
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
			function TeclaNumTraco(e)
			{
				if (document.all)
					var tecla = e.keyCode;
				if (tecla > 47 && tecla < 58 || tecla == 45) // numeros de 0 a 9 ou "-"
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
					//document.all.LnkBtnDdoFlu.click();			
					alert("Não é permitido acessar o Fluxo na tela de cadastro!");
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
		<script language="vbscript">
		suporteVBscript=1
		function VBconfirm(mensagem) 
			VBconfirm=msgbox(mensagem,vbyesno)
		end function
		</script>
	</HEAD>
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 16px" id="PnlDdoFlu" runat="server"
				Height="128px" ForeColor="Red" Font-Size="X-Small" Width="496px" BackColor="White" Visible="False"
				Font-Names="Verdana">
				<TABLE style="WIDTH: 755px; HEIGHT: 300px; VERTICAL-ALIGN: top" id="Table21" border="0"
					cellSpacing="0" cellPadding="0" align="center">
					<TR vAlign="bottom">
						<TD style="HEIGHT: 16px" width="8"></TD>
						<TD style="HEIGHT: 16px" height="16">
							<TABLE style="TABLE-LAYOUT: fixed" id="Table22" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD height="17" vAlign="top"><IMG border="0" src="images\abaflu.JPG" useMap="DocVAKNavCadRep.aspx#lnk">
										<MAP name="lnk">
											<AREA href="javascript:troca2()" shape="RECT" coords="71,0,179,16">
											<AREA href="javascript:troca3()" shape="RECT" coords="186,0,269,16">
											<AREA href="javascript:troca6()" shape="RECT" coords="276,0,360,16">
											<AREA href="javascript:troca7()" shape="RECT" coords="365,0,455,16">
										</MAP>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 16px" width="8"></TD>
					</TR>
					<TR>
						<TD width="8"><IMG id="Img9" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD bgColor="#e0eafc"></TD>
						<TD vAlign="top" width="8"><IMG id="Img10" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD bgColor="#e0eafc" width="10"></TD>
						<TD vAlign="top">
							<TABLE style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
								id="Table23" border="0" cellSpacing="0" borderColor="#96b1cb" cellPadding="0" width="100%"
								bgColor="#e0eafc" align="center" height="100%">
								<TR>
									<TD style="HEIGHT: 100%" vAlign="top" align="right">
										<TABLE style="HEIGHT: 24px" id="Table24" border="0" cellSpacing="1" cellPadding="1" width="100%"
											bgColor="#e0eafc">
											<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitNumReq" runat="server" ForeColor="Black" Height="17px">Nro Requisição:</asp:label></TD>
												<TD>
													<asp:label id="NumReq" runat="server" Font-Size="X-Small" ForeColor="Maroon" Height="17px">0001/2004</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitSta" runat="server" ForeColor="Black" Height="17px">Status:</asp:label></TD>
												<TD style="HEIGHT: 18px">
													<asp:label id="NomSta" runat="server" Font-Size="X-Small" ForeColor="Maroon" Height="17px">Novo</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitRspPrxAco" runat="server" ForeColor="Black" Height="17px">Resp. próxima ação:</asp:label></TD>
												<TD style="WIDTH: 360px">
													<asp:textbox id="RspPrxAco" runat="server" Width="184px" CssClass="tit" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitFlu" runat="server" ForeColor="Black" Height="17px">Fluxo:</asp:label></TD>
												<TD style="WIDTH: 360px">
													<asp:textbox id="LstFlu" runat="server" Visible="False" Width="600px" Height="200px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitOpn" runat="server" ForeColor="Black" Height="17px"> Pareceres:</asp:label></TD>
												<TD style="WIDTH: 360px">
													<asp:textbox id="NomOpn" runat="server" Width="184px" CssClass="tit" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitDatSlc" runat="server" ForeColor="Black" Height="17px">Data Solicitação:</asp:label></TD>
												<TD style="WIDTH: 360px">
													<asp:textbox id="DatSlc" runat="server" Width="72px" CssClass="tit" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 171px" align="right">
													<asp:label id="TitDatEft" runat="server" ForeColor="Black" Height="17px">Data Efetivação:</asp:label></TD>
												<TD style="WIDTH: 360px">
													<asp:textbox id="DatEft" runat="server" Width="72px" CssClass="tit" ReadOnly="True"></asp:textbox></TD>
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
												<asp:BoundColumn DataField="Status" HeaderText="Status">
													<HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Usuario" HeaderText="Usu&#225;rio Altera&#231;&#227;o">
													<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Data" HeaderText="Data Altera&#231;&#227;o">
													<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
						<TD bgColor="#e0eafc" width="8"></TD>
					</TR>
					<TR>
						<TD width="8"><IMG src="images/ImgTabDesEsqIfo.gif" width="16" height="16"></TD>
						<TD background="images/ImgFnd.gif" width="100%"></TD>
						<TD width="8"><IMG src="images/ImgTabDesDraIfo.gif" width="16" height="16"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<DIV style="VISIBILITY: visible" id="Div1"></DIV>
			<asp:panel style="Z-INDEX: 102; POSITION: absolute; TOP: 616px; LEFT: 16px" id="PnlDdoRep"
				runat="server" Height="128px" ForeColor="Red" Font-Size="X-Small" Width="496px" BackColor="White"
				Visible="False" Font-Names="Verdana">
				<TABLE style="WIDTH: 755px; HEIGHT: 435px" id="Table25" border="0" cellSpacing="0" cellPadding="0"
					width="630" align="center">
					<TR vAlign="bottom">
						<TD style="WIDTH: 17px; HEIGHT: 8px" width="17"></TD>
						<TD style="HEIGHT: 8px" height="8">
							<TABLE style="TABLE-LAYOUT: fixed; HEIGHT: 12px" id="Table26" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD height="17" vAlign="top"><IMG border="0" src="images\abaflu.JPG" useMap="DocVAKNavCadRep.aspx#lnk">
										<MAP name="lnk">
											<AREA href="javascript:troca2()" shape="RECT" coords="71,0,179,16">
											<AREA href="javascript:troca3()" shape="RECT" coords="186,0,269,16">
											<AREA href="javascript:troca6()" shape="RECT" coords="276,0,360,16">
											<AREA href="javascript:troca7()" shape="RECT" coords="365,0,455,16">
										</MAP>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 8px" width="8"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 17px" width="17"><IMG id="Img11" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD bgColor="#e0eafc"></TD>
						<TD vAlign="top" width="8"><IMG id="Img12" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="WIDTH: 17px" bgColor="#e0eafc" width="17"></TD>
						<TD vAlign="top">
							<TABLE style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
								id="Table27" border="0" cellSpacing="0" borderColor="#96b1cb" cellPadding="0" width="100%"
								bgColor="#e0eafc" align="center" height="100%">
								<TR>
									<TD style="HEIGHT: 100%" vAlign="top">
										<TABLE style="HEIGHT: 24px" id="Table28" border="0" cellSpacing="1" cellPadding="1" width="100%"
											bgColor="#e0eafc">
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 18px"></TD> <!--TD colSpan="4"><BR>
											<TD-->
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 18px"></TD>
											<TR>
												<TD style="WIDTH: 474px" colSpan="4" align="center">
													<asp:Label id="DesMsgRepTrbMrt" runat="server" Visible="False" ForeColor="#C00000" Height="13px"
														Font-Bold="True"></asp:Label></TD>
												<TD align="center"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitGerVnd" runat="server" ForeColor="Black" Height="17px">G.V:</asp:label></TD>
												<TD colSpan="4">
													<asp:label id="NomGerVnd" runat="server" Width="464px" Font-Size="X-Small" ForeColor="Black"
														Height="17px">Nome do gerente de vendas</asp:label>
													<asp:Image id="ImgGerVnd" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitGerMcd" runat="server" ForeColor="Black" Height="17px">G.M:</asp:label></TD>
												<TD colSpan="4">
													<asp:label id="NomGerMcd" runat="server" Width="464px" Font-Size="X-Small" ForeColor="Black"
														Height="17px">Nome do gerente de mercado</asp:label>
													<asp:Image id="ImgGerMcd" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right"></TD>
												<TD style="WIDTH: 291px" colSpan="2"></TD>
												<TD style="WIDTH: 84px" align="right"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="Label7" runat="server" ForeColor="Black" Height="17px">Território:</asp:label></TD>
												<TD style="WIDTH: 133px">
													<asp:TextBox id="txtTetVnd" runat="server" Width="72px"></asp:TextBox>
													<asp:Button id="btnCsnTet" runat="server" Width="24px" Text="..."></asp:Button>
													<asp:Image id="ImgVlrVndTet" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 157px">
													<asp:label id="lblNomTet" runat="server" Width="171px" Font-Size="X-Small" ForeColor="Black"
														Height="17px"></asp:label></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="Label8" runat="server" ForeColor="Black" Height="17px">Representante:</asp:label></TD>
												<TD>
													<asp:label id="lblNomRep" runat="server" Width="224px" Font-Size="X-Small" ForeColor="Black"
														Height="17px"></asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="Label11" runat="server" ForeColor="Black" Height="17px">Vendas do Território:</asp:label></TD>
												<TD colSpan="7">
													<asp:label id="lblMesUm" runat="server" Width="56px" ForeColor="Black" Height="17px">Mês 1:</asp:label>
													<asp:TextBox id="txtVlrVndUm" runat="server" Width="72px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:label id="lblMesDois" runat="server" Width="57px" ForeColor="Black" Height="17px">Mês 2:</asp:label>
													<asp:TextBox id="txtVlrVndDois" runat="server" Width="72px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;
													<asp:label id="lblMesTre" runat="server" Width="64px" ForeColor="Black" Height="17px">Mês 3:</asp:label>
													<asp:TextBox id="txtVlrVndTre" runat="server" Width="72px" ReadOnly="True"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right"></TD>
												<TD style="WIDTH: 394px" colSpan="3"></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 25px" align="right">
													<asp:label id="TitNomRep" runat="server" ForeColor="Black" Height="17px" CssClass="INPUT">Nome do Proponente:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 25px" colSpan="2">
													<asp:textbox id="DesNomRep" runat="server" Width="230px" MaxLength="100"></asp:textbox>
													<asp:Image id="ImgNomRep" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="TitSex" runat="server" ForeColor="Black" Height="17px">Sexo:</asp:label></TD>
												<TD>
													<asp:RadioButtonList id="RadBtnSex" runat="server" Width="140px" Font-Size="XX-Small" Height="0px" RepeatDirection="Horizontal"
														RepeatLayout="Flow">
														<asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
														<asp:ListItem Value="F">Feminino</asp:ListItem>
													</asp:RadioButtonList>
													<asp:Image id="ImgSex" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 27px" align="right">
													<asp:label id="TitEcl" runat="server" ForeColor="Black" Height="17px">Escolaridade:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 27px" colSpan="2">
													<asp:dropdownlist id="NumGraEcl" runat="server" Width="40px">
														<asp:ListItem Value="1">1&#186;</asp:ListItem>
														<asp:ListItem Value="2">2&#186;</asp:ListItem>
														<asp:ListItem Value="3">3&#186;</asp:ListItem>
													</asp:dropdownlist>
													<asp:dropdownlist id="LstCplEcl" runat="server" Width="95px">
														<asp:ListItem Value="C">C-Completo</asp:ListItem>
														<asp:ListItem Value="I">I-Incompleto</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgEcl" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 27px" align="right">
													<asp:label id="TitEstCvl" runat="server" ForeColor="Black" Height="17px">Estado Civil:</asp:label></TD>
												<TD style="HEIGHT: 27px" colSpan="3">
													<asp:dropdownlist id="LstEstCvl" runat="server" Width="86px">
														<asp:ListItem Value="C">C-Casado</asp:ListItem>
														<asp:ListItem Value="D">D-Divorciado</asp:ListItem>
														<asp:ListItem Value="S">S-Solteiro</asp:ListItem>
														<asp:ListItem Value="V">V-Vi&#250;vo</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgEstCvl" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 27px" align="right">
													<asp:label id="TitNac" runat="server" ForeColor="Black" Height="17px">Nacionalidade:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 27px" colSpan="2">
													<asp:textbox id="DesNac" runat="server" Width="120px" MaxLength="15"></asp:textbox>
													<asp:Image id="ImgNac" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 27px" align="right">
													<asp:label id="TitDatNsc" runat="server" ForeColor="Black" Height="17px">Data Nascimento:</asp:label></TD>
												<TD style="HEIGHT: 27px" colSpan="3">
													<asp:TextBox id="DesDatNsc" runat="server" Width="86px" MaxLength="10" AutoPostBack="True"></asp:TextBox>
													<ew:calendarpopup id="DatNsc" tabIndex="28" runat="server" Width="0px" Height="21px" AutoPostBack="True"
														ClearDateText="Nenhuma" Nullable="True" AllowArbitraryText="False" GoToTodayText="Data Atual:">
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
													<asp:Image id="ImgDatNsc" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitCpf" runat="server" ForeColor="Black" Height="17px">CPF:</asp:label></TD>
												<TD style="WIDTH: 291px" colSpan="2">
													<asp:TextBox id="DesNumCpf" runat="server" Width="115px" MaxLength="14" AutoPostBack="True"></asp:TextBox>
													<asp:Image id="ImgNumCpf" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="TitInss" runat="server" ForeColor="Black" Height="17px">INSS:</asp:label></TD>
												<TD colSpan="3"><!-- RETIRAR ESTE COMENTARIO DE BLOCO ANTES DE LIBERAR ! -->
													<asp:textbox id="DesNumInss" runat="server" Width="90px" MaxLength="11" AutoPostBack="True"></asp:textbox><!-- --></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 25px" align="right">
													<asp:label id="TitCrtIdt" runat="server" ForeColor="Black" Height="17px">RG:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 25px" colSpan="2">
													<asp:textbox id="DesNumCrtIdt" runat="server" Width="90px" MaxLength="11"></asp:textbox>
													<asp:Image id="ImgNumCrtIdt" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 25px" align="right">
													<asp:label id="TitOrgEms" runat="server" ForeColor="Black" Height="17px">Órgão Emissor:</asp:label></TD>
												<TD style="HEIGHT: 25px">
													<asp:textbox id="DesOrgEms" runat="server" Width="50px" MaxLength="5"></asp:textbox>
													<asp:Image id="ImgOrgEms" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 21px" align="right">
													<asp:label id="TitCshReg" runat="server" ForeColor="Black" Height="17px">Core:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 21px" colSpan="2">
													<asp:textbox id="DesCshReg" runat="server" Width="85px" MaxLength="10"></asp:textbox></TD>
												<TD style="WIDTH: 84px; HEIGHT: 21px" align="right">
													<asp:label id="TitDatCadCshReg" runat="server" Width="87px" ForeColor="Black" Height="17px">Data Cadastro Core:</asp:label></TD>
												<TD style="HEIGHT: 21px" colSpan="3">
													<asp:TextBox id="DesDatCadCshReg" runat="server" Width="86px" MaxLength="10" AutoPostBack="True"></asp:TextBox><!-- RETIRAR ESTE COMENTARIO DE BLOCO ANTES DE LIBERAR ! -->
													<ew:calendarpopup id="DatCadCshReg" tabIndex="28" runat="server" Width="0px" Height="21px" AutoPostBack="True"
														ClearDateText="Nenhuma" Nullable="True" AllowArbitraryText="False" GoToTodayText="Data Atual:">
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
													</ew:calendarpopup><!-- --></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 25px" align="right">
													<asp:label id="TitSitCshReg" runat="server" ForeColor="Black" Height="17px">Situação Core:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 25px" colSpan="2">
													<asp:DropDownList id="LstSitCshReg" runat="server" Width="104px">
														<asp:ListItem Value=" "></asp:ListItem>
														<asp:ListItem Value="PR">PR-Protocolo</asp:ListItem>
													</asp:DropDownList></TD>
												<TD style="WIDTH: 84px; HEIGHT: 25px" align="right">
													<asp:label id="TitEstCshReg" runat="server" ForeColor="Black" Height="17px">Estado Core:</asp:label></TD>
												<TD style="HEIGHT: 25px"><!-- RETIRAR ESTE COMENTARIO DE BLOCO ANTES DE LIBERAR ! --><BUTTONSTYLE BackColor="ControlLightLight" ForeColor="Black" BorderStyle="Groove" Font-Bold="True">
														<asp:dropdownlist id="LstEstCshReg" runat="server" Width="48px">
															<asp:ListItem Value=" "></asp:ListItem>
															<asp:ListItem Value="AC">AC</asp:ListItem>
															<asp:ListItem Value="AL">AL</asp:ListItem>
															<asp:ListItem Value="AM">AM</asp:ListItem>
															<asp:ListItem Value="AP">AP</asp:ListItem>
															<asp:ListItem Value="BA">BA</asp:ListItem>
															<asp:ListItem Value="CE">CE</asp:ListItem>
															<asp:ListItem Value="DF">DF</asp:ListItem>
															<asp:ListItem Value="ES">ES</asp:ListItem>
															<asp:ListItem Value="GO">GO</asp:ListItem>
															<asp:ListItem Value="MA">MA</asp:ListItem>
															<asp:ListItem Value="MG">MG</asp:ListItem>
															<asp:ListItem Value="MS">MS</asp:ListItem>
															<asp:ListItem Value="MT">MT</asp:ListItem>
															<asp:ListItem Value="PA">PA</asp:ListItem>
															<asp:ListItem Value="PB">PB</asp:ListItem>
															<asp:ListItem Value="PE">PE</asp:ListItem>
															<asp:ListItem Value="PI">PI</asp:ListItem>
															<asp:ListItem Value="PR">PR</asp:ListItem>
															<asp:ListItem Value="RJ">RJ</asp:ListItem>
															<asp:ListItem Value="RN">RN</asp:ListItem>
															<asp:ListItem Value="RO">RO</asp:ListItem>
															<asp:ListItem Value="RR">RR</asp:ListItem>
															<asp:ListItem Value="RS">RS</asp:ListItem>
															<asp:ListItem Value="SC">SC</asp:ListItem>
															<asp:ListItem Value="SE">SE</asp:ListItem>
															<asp:ListItem Value="SP">SP</asp:ListItem>
															<asp:ListItem Value="TO">TO</asp:ListItem>
														</asp:dropdownlist>
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
														ForeColor="Black"></WEEKDAYSTYLE><!-- --></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 14px" align="right"></TD>
												<TD style="WIDTH: 291px; HEIGHT: 14px" colSpan="2"></TD>
												<TD style="WIDTH: 84px; HEIGHT: 14px" align="right"></TD>
												<TD style="HEIGHT: 14px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 14px" align="right">
													<asp:label id="Label3" runat="server" ForeColor="Black" Height="17px" DESIGNTIMEDRAGDROP="5292">Banco:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 14px" colSpan="2">
													<asp:textbox id="txtNumBco" runat="server" Width="40px" MaxLength="5"></asp:textbox>
													<asp:Button id="btnCsnBco" runat="server" Width="24px" Text="..."></asp:Button>
													<asp:label id="lblNomBco" runat="server" Width="200px" Font-Size="X-Small" ForeColor="Black"
														Height="17px"></asp:label>
													<asp:Image id="ImgNomBco" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 14px" align="right">
													<asp:label id="Label4" runat="server" ForeColor="Black" Height="17px">Agência:</asp:label></TD>
												<TD style="HEIGHT: 14px">
													<asp:textbox id="txtNumAge" runat="server" Width="56px" MaxLength="10"></asp:textbox>
													<asp:Button id="btnCsnAge" runat="server" Width="24px" Text="..."></asp:Button>
													<asp:label id="lblNomAge" runat="server" Width="128px" Font-Size="X-Small" ForeColor="Black"
														Height="17px"></asp:label>
													<asp:Image id="ImgAgeBco" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 14px" align="right">
													<asp:label id="Label2" runat="server" Width="75px" ForeColor="Black" Height="17px">Conta Corrente:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 14px" colSpan="2">
													<asp:textbox id="txtNumCtaCrr" runat="server" Width="100px" MaxLength="12"></asp:textbox>
													<asp:Image id="ImgNumCntCrr" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 14px" align="right"></TD>
												<TD style="HEIGHT: 14px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 14px" align="right"></TD>
												<TD style="WIDTH: 291px; HEIGHT: 14px" colSpan="2"></TD>
												<TD style="WIDTH: 84px; HEIGHT: 14px" align="right"></TD>
												<TD style="HEIGHT: 14px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 18px" align="right">
													<asp:label id="TitCep" runat="server" ForeColor="Black" Height="17px">CEP:</asp:label></TD>
												<TD style="WIDTH: 133px; HEIGHT: 18px">
													<asp:textbox id="DesNumCep" runat="server" Width="85px" MaxLength="10"></asp:textbox>
													<asp:Button id="csnCep" runat="server" Width="24px" Text="..."></asp:Button>
													<asp:Image id="ImgCep" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 157px; HEIGHT: 18px" align="right">
													<asp:label id="TitEst" runat="server" ForeColor="Black" Height="17px">Estado:</asp:label>
													<asp:dropdownlist id="LstEst" runat="server" Width="48px" AutoPostBack="True">
														<asp:ListItem Value=" "></asp:ListItem>
														<asp:ListItem Value="AC">AC</asp:ListItem>
														<asp:ListItem Value="AL">AL</asp:ListItem>
														<asp:ListItem Value="AM">AM</asp:ListItem>
														<asp:ListItem Value="AP">AP</asp:ListItem>
														<asp:ListItem Value="BA">BA</asp:ListItem>
														<asp:ListItem Value="CE">CE</asp:ListItem>
														<asp:ListItem Value="DF">DF</asp:ListItem>
														<asp:ListItem Value="ES">ES</asp:ListItem>
														<asp:ListItem Value="GO">GO</asp:ListItem>
														<asp:ListItem Value="MA">MA</asp:ListItem>
														<asp:ListItem Value="MG">MG</asp:ListItem>
														<asp:ListItem Value="MS">MS</asp:ListItem>
														<asp:ListItem Value="MT">MT</asp:ListItem>
														<asp:ListItem Value="PA">PA</asp:ListItem>
														<asp:ListItem Value="PB">PB</asp:ListItem>
														<asp:ListItem Value="PE">PE</asp:ListItem>
														<asp:ListItem Value="PI">PI</asp:ListItem>
														<asp:ListItem Value="PR">PR</asp:ListItem>
														<asp:ListItem Value="RJ">RJ</asp:ListItem>
														<asp:ListItem Value="RN">RN</asp:ListItem>
														<asp:ListItem Value="RO">RO</asp:ListItem>
														<asp:ListItem Value="RR">RR</asp:ListItem>
														<asp:ListItem Value="RS">RS</asp:ListItem>
														<asp:ListItem Value="SC">SC</asp:ListItem>
														<asp:ListItem Value="SE">SE</asp:ListItem>
														<asp:ListItem Value="SP">SP</asp:ListItem>
														<asp:ListItem Value="TO">TO</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgEst" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 18px" align="right">
													<asp:label id="TitCid" runat="server" ForeColor="Black" Height="17px">Cidade:</asp:label></TD>
												<TD style="HEIGHT: 18px">
													<asp:dropdownlist id="LstCid" runat="server" Width="216px" AutoPostBack="True"></asp:dropdownlist>
													<asp:Image id="ImgCid" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 26px" align="right">
													<asp:label id="TitBai" runat="server" ForeColor="Black" Height="17px">Bairro:</asp:label></TD>
												<TD style="WIDTH: 291px; HEIGHT: 26px" colSpan="2">
													<asp:dropdownlist id="LstNomBai" runat="server" Width="180px" AutoPostBack="True"></asp:dropdownlist>
													<asp:Image id="ImgBai" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px; HEIGHT: 26px" align="right">
													<asp:label id="TitCpl" runat="server" Width="64px" ForeColor="Black" Height="17px">Complemento:</asp:label></TD>
												<TD style="HEIGHT: 26px">
													<asp:dropdownlist id="LstCplBai" runat="server" Width="216px" AutoPostBack="True"></asp:dropdownlist>
													<asp:Image id="ImgCplBai" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitEnd" runat="server" ForeColor="Black" Height="17px">Endereço:</asp:label></TD>
												<TD style="WIDTH: 291px" colSpan="2">
													<asp:textbox id="DesEnd" runat="server" Width="224px" MaxLength="30"></asp:textbox>
													<asp:Image id="ImgEnd" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="TitRsi" runat="server" ForeColor="Black" Height="17px">Residência:</asp:label></TD>
												<TD>
													<asp:dropdownlist id="LstRsi" runat="server" Width="88px">
														<asp:ListItem Value="A">A-Alugada</asp:ListItem>
														<asp:ListItem Value="P">P-Pr&#243;pria</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgRsi" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image>
													<asp:dropdownlist id="LstVtg" runat="server" Width="88px">
														<asp:ListItem Value="110">110 Volts</asp:ListItem>
														<asp:ListItem Value="220">220 Volts</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgVtg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitTlf" runat="server" ForeColor="Black" Height="17px">Telefone:</asp:label></TD>
												<TD style="WIDTH: 133px">
													<asp:textbox id="NumTlf" runat="server" Width="105px" MaxLength="13"></asp:textbox></TD>
												<TD style="WIDTH: 157px" align="left">
													<asp:dropdownlist id="LstSitTlf" runat="server" Width="96px">
														<asp:ListItem></asp:ListItem>
														<asp:ListItem Value="N">A-Alugado</asp:ListItem>
														<asp:ListItem Value="S">P-Pr&#243;prio</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="TitCel" runat="server" ForeColor="Black" Height="17px"> Celular:</asp:label></TD>
												<TD colSpan="3">
													<asp:textbox id="NumCel" runat="server" Width="105px" MaxLength="13"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px; HEIGHT: 18px" align="right">
													<asp:label id="TitFax" runat="server" ForeColor="Black" Height="17px">Fax:</asp:label></TD>
												<TD style="WIDTH: 131px; HEIGHT: 18px">
													<asp:textbox id="NumFax" runat="server" Width="105px" MaxLength="13"></asp:textbox></TD>
												<TD style="WIDTH: 157px; HEIGHT: 18px">
													<asp:dropdownlist id="LstSitFax" runat="server" Width="96px">
														<asp:ListItem></asp:ListItem>
														<asp:ListItem Value="N">A-Alugado</asp:ListItem>
														<asp:ListItem Value="S">P-Pr&#243;prio</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD style="HEIGHT: 18px" colSpan="2"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 66px" align="right">
													<asp:label id="TitUndNgc" runat="server" ForeColor="Black" Height="17px">Unidade de Negócio:</asp:label></TD>
												<TD style="WIDTH: 291px" colSpan="2">
													<asp:dropdownlist id="LstUndNgc" runat="server" Width="128px">
														<asp:ListItem Value="1">1-Atacado</asp:ListItem>
														<asp:ListItem Value="3">3-Broker</asp:ListItem>
													</asp:dropdownlist>
													<asp:Image id="ImgUndNgc" runat="server" Visible="False" ToolTip="Preenchimento obrigatório!"
														ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 84px" align="right">
													<asp:label id="TitSgmMcd" runat="server" ForeColor="Black" Height="17px">Seg. Mercado:</asp:label></TD>
												<TD>
													<asp:dropdownlist id="LstSgmMcd" runat="server" Width="216px"></asp:dropdownlist>
													<asp:Image id="ImgSgmMcd" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD bgColor="#e0eafc" width="8"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 17px" width="17"><IMG src="images/ImgTabDesEsqIfo.gif" width="16" height="16"></TD>
						<TD background="images/ImgFnd.gif" width="100%"></TD>
						<TD width="8"><IMG src="images/ImgTabDesDraIfo.gif" width="16" height="16"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<div style="DISPLAY: none; VISIBILITY: hidden" id="EleDdoBtn"><asp:linkbutton style="Z-INDEX: 112; POSITION: absolute; TOP: 3080px; LEFT: 496px" id="LnkBtnPnd"
					runat="server" ForeColor="Black" Font-Size="XX-Small" Font-Names="Arial">Pendencia</asp:linkbutton><asp:linkbutton style="Z-INDEX: 111; POSITION: absolute; TOP: 3080px; LEFT: 416px" id="LnkBtnOpnEtv"
					runat="server" ForeColor="Black" Font-Size="XX-Small" Font-Names="Arial">Avaliacao</asp:linkbutton><asp:linkbutton style="Z-INDEX: 107; POSITION: absolute; TOP: 3080px; LEFT: 192px" id="LnkBtnDdoCjg"
					runat="server" ForeColor="Black" Font-Size="XX-Small" BackColor="Transparent" Font-Names="Arial" BorderStyle="None" Font-Bold="True">Conjuge</asp:linkbutton><asp:linkbutton style="Z-INDEX: 109; POSITION: absolute; TOP: 3080px; LEFT: 336px" id="LnkBtnTetVnd"
					runat="server" ForeColor="Black" Font-Size="XX-Small" Font-Names="Arial">Territorio</asp:linkbutton><asp:linkbutton style="Z-INDEX: 108; POSITION: absolute; TOP: 3080px; LEFT: 264px" id="LnkBtnDdoBco"
					runat="server" ForeColor="Black" Font-Size="XX-Small" BackColor="Transparent" Font-Names="Arial" BorderStyle="None" Font-Bold="True">Banco</asp:linkbutton><asp:linkbutton style="Z-INDEX: 106; POSITION: absolute; TOP: 3080px; LEFT: 88px" id="LnkBtnDdoRep"
					runat="server" ForeColor="Black" Font-Size="XX-Small" BackColor="Transparent" Font-Names="Arial" BorderStyle="None" Font-Bold="True">Representante</asp:linkbutton><asp:linkbutton style="Z-INDEX: 105; POSITION: absolute; TOP: 3080px; LEFT: 24px" id="LnkBtnDdoFlu"
					runat="server" ForeColor="Black" Font-Size="XX-Small" Font-Names="Arial">Fluxo</asp:linkbutton></div>
			<asp:panel style="Z-INDEX: 103; POSITION: absolute; TOP: 1376px; LEFT: 16px" id="PnlDdoCjg"
				runat="server" Height="128px" ForeColor="Red" Font-Size="X-Small" Width="496px" BackColor="White"
				Visible="False" Font-Names="Verdana">
				<TABLE style="WIDTH: 755px; HEIGHT: 100px" id="Table17" border="0" cellSpacing="0" cellPadding="0"
					width="630" align="center">
					<TR vAlign="bottom">
						<TD style="HEIGHT: 13px" width="8"></TD>
						<TD style="HEIGHT: 13px" height="13">
							<TABLE style="TABLE-LAYOUT: fixed; HEIGHT: 12px" id="Table18" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD height="17" vAlign="top"><IMG border="0" src="images\abaflu.JPG" useMap="DocVAKNavCadRep.aspx#lnk">
										<MAP name="lnk">
											<AREA href="javascript:troca2()" shape="RECT" coords="71,0,179,16">
											<AREA href="javascript:troca3()" shape="RECT" coords="186,0,269,16">
											<AREA href="javascript:troca6()" shape="RECT" coords="276,0,360,16">
											<AREA href="javascript:troca7()" shape="RECT" coords="365,0,455,16">
										</MAP>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 13px" width="8"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" width="8"><IMG id="Img7" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD style="HEIGHT: 19px" bgColor="#e0eafc"></TD>
						<TD style="HEIGHT: 19px" vAlign="top" width="8"><IMG id="Img8" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD bgColor="#e0eafc" width="8"></TD>
						<TD vAlign="top">
							<TABLE style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
								id="Table19" border="0" cellSpacing="0" borderColor="#96b1cb" cellPadding="0" width="100%"
								bgColor="#e0eafc" align="center" height="100%">
								<TR>
									<TD style="HEIGHT: 100%" vAlign="top">
										<TABLE style="HEIGHT: 24px" id="Table20" border="0" cellSpacing="1" cellPadding="1" width="100%"
											bgColor="#e0eafc">
											<TR> <!--TD colSpan="4"><BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 76px" align="right">
													<asp:label id="TitNomCjg" runat="server" ForeColor="Black" Height="17px">Nome:</asp:label></TD>
												<TD colSpan="3">
													<asp:textbox id="DesNomCjg" runat="server" Width="230px" MaxLength="30"></asp:textbox>
													<asp:Image id="ImgNomCjg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 76px" align="right">
													<asp:label id="TitNumCrtIdtCjg" runat="server" ForeColor="Black" Height="17px">RG:</asp:label></TD>
												<TD>
													<asp:textbox id="DesNumCrtIdtCjg" runat="server" Width="90px" MaxLength="11"></asp:textbox>
													<asp:Image id="ImgNumCrtIdtCjg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 225px" align="right">
													<asp:label id="TitOrgEmsCjg" runat="server" ForeColor="Black" Height="17px">Órgão Emissor:</asp:label></TD>
												<TD>
													<asp:textbox id="DesOrgEmsCjg" runat="server" Width="50px" MaxLength="5"></asp:textbox>
													<asp:Image id="ImgOrgEmsCjg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 76px" align="right">
													<asp:label id="TitNumFlhCjg" runat="server" ForeColor="Black" Height="17px">Nº Filhos:</asp:label></TD>
												<TD>
													<asp:textbox id="DesNumFlhCjg" runat="server" Width="25px" MaxLength="2">0</asp:textbox>
													<asp:Image id="ImgNumFlhCjg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
												<TD style="WIDTH: 225px" align="right">
													<asp:label id="TitDatNscCjg" runat="server" ForeColor="Black" Height="17px">Data Nascimento:</asp:label></TD>
												<TD>
													<asp:TextBox id="DesDatNscCjg" runat="server" Width="86px" MaxLength="10" AutoPostBack="True"></asp:TextBox>
													<ew:calendarpopup id="DatNscCjg" tabIndex="28" runat="server" Width="0px" Height="21px" AutoPostBack="True"
														ClearDateText="Nenhuma" Nullable="True" AllowArbitraryText="False" GoToTodayText="Data Atual:"
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
													<asp:Image id="ImgDatNscCjg" runat="server" ToolTip="Preenchimento obrigatório!" ImageUrl="images/ArqImgAla.gif"></asp:Image></TD>
											</TR>
										</TABLE>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD bgColor="#e0eafc" width="8"></TD>
					</TR>
					<TR>
						<TD width="8"><IMG src="images/ImgTabDesEsqIfo.gif" width="16" height="16"></TD>
						<TD background="images/ImgFnd.gif" width="100%"></TD>
						<TD width="8"><IMG src="images/ImgTabDesDraIfo.gif" width="16" height="16"></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel style="Z-INDEX: 113; POSITION: absolute; TOP: 1664px; LEFT: 16px" id="PnlOpnEtv"
				runat="server" Height="128px" ForeColor="Red" Font-Size="X-Small" Width="496px" BackColor="White" Visible="False"
				Font-Names="Verdana">
				<TABLE style="WIDTH: 755px" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="631"
					align="center">
					<TR vAlign="bottom">
						<TD style="HEIGHT: 10px" width="8"></TD>
						<TD style="WIDTH: 722px; HEIGHT: 10px" height="10">
							<TABLE style="TABLE-LAYOUT: fixed; HEIGHT: 12px" id="Table5" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD height="17" vAlign="bottom"><IMG border="0" src="images\abaflu.JPG" useMap="DocVAKNavCadRep.aspx#lnk">
										<MAP name="lnk">
											<AREA href="javascript:troca2()" shape="RECT" coords="71,0,179,16">
											<AREA href="javascript:troca3()" shape="RECT" coords="186,0,269,16">
											<AREA href="javascript:troca6()" shape="RECT" coords="276,0,360,16">
											<AREA href="javascript:troca7()" shape="RECT" coords="365,0,455,16">
										</MAP>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 10px" width="8"></TD>
					</TR>
					<TR>
						<TD width="8"><IMG id="Img1" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD style="WIDTH: 722px" bgColor="#e0eafc"></TD>
						<TD vAlign="top" width="8"><IMG id="Img2" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 585px" bgColor="#e0eafc" width="10"></TD>
						<TD style="WIDTH: 722px; HEIGHT: 585px" bgColor="#e0eafc" vAlign="top">
							<TABLE style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px"
								id="Table6" border="0" cellSpacing="0" borderColor="#96b1cb" cellPadding="0" bgColor="#e0eafc"
								align="center">
								<TR>
									<TD vAlign="top" align="center">
										<TABLE style="WIDTH: 639px; HEIGHT: 481px" id="Table8" border="0" cellSpacing="1" cellPadding="1"
											width="639" bgColor="#e0eafc">
											<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2"><BR>
											</TD--></TR>
											<TR>
												<TD style="WIDTH: 212px" colSpan="2" align="left">
													<asp:label id="TitRstQld" runat="server" Width="141px" ForeColor="Black" Height="17px" Font-Bold="True">Resultado  Qualitativo:</asp:label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 345px" vAlign="top" align="center"></TD>
												<TD style="HEIGHT: 345px" vAlign="top" align="center">
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
																<HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Descri&#231;&#227;o">
																<HeaderStyle HorizontalAlign="Center" Width="400px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
																<ItemTemplate>
																	<asp:TextBox id="DesRstAvl" runat="server" Width="400px" Height="50px" TextMode="MultiLine" MaxLength="254"></asp:TextBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
													<asp:Image id="ImgRstAvl" runat="server" ToolTip="É obrigatório o preenchimento de todos os itens de avaliação"
														ImageUrl="images/ArqImgAla.gif"></asp:Image>&nbsp;
													<asp:Label id="MsgRstAvl" runat="server" ForeColor="Red">É obrigatório o preenchimento de todos os itens de avaliação</asp:Label></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 207px" vAlign="top" align="center"></TD>
												<TD style="HEIGHT: 207px" vAlign="top" align="center">
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
																<asp:TemplateColumn HeaderText="Nota">
																	<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox id="DesNotCtn" runat="server" Width="25px" Height="24px" MaxLength="2">0</asp:TextBox>
																		<asp:RangeValidator id="IndVldNotCtn" runat="server" Type="Integer" MinimumValue="0" MaximumValue="10"
																			ControlToValidate="DesNotCtn" ErrorMessage="<img src=&quot;images/ArqImgAla.gif&quot; alt=&quot;Valor deve ser numérico entre 0 e 10!&quot; border=&quot;0&quot; onclick=&quot;alert('Valor deve ser numérico entre 0 e 10!')&quot;>"></asp:RangeValidator>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
														</asp:datagrid>
														<asp:Image id="ImgRstCtn" runat="server" ToolTip="É obrigatório o preenchimento de todas as notas"
															ImageUrl="images/ArqImgAla.gif"></asp:Image>&nbsp;
														<asp:Label id="MsgRstCtn" runat="server" ForeColor="Red">É obrigatório o preenchimento de todas as notas</asp:Label></P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 212px; HEIGHT: 23px" colSpan="2" align="left">
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
						<TD style="HEIGHT: 585px" bgColor="#e0eafc" width="8"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 2px" width="8"><IMG src="images/ImgTabDesEsqIfo.gif" width="16" height="16"></TD>
						<TD style="WIDTH: 722px; HEIGHT: 2px" background="images/ImgFnd.gif" width="722"></TD>
						<TD style="HEIGHT: 2px" width="8"><IMG src="images/ImgTabDesDraIfo.gif" width="16" height="16"></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel style="Z-INDEX: 104; POSITION: absolute; TOP: 2536px; LEFT: 16px" id="PnlPnd" runat="server"
				Height="128px" ForeColor="Red" Font-Size="X-Small" Width="496px" BackColor="White" Visible="False"
				Font-Names="Verdana">
				<TABLE style="WIDTH: 755px" id="Table1" border="0" cellSpacing="0" cellPadding="0" width="631"
					align="center">
					<TR vAlign="bottom">
						<TD style="HEIGHT: 3px" width="8"></TD>
						<TD style="HEIGHT: 3px" height="3">
							<TABLE style="TABLE-LAYOUT: fixed; HEIGHT: 12px" id="Table2" border="0" cellSpacing="0"
								cellPadding="0">
								<TR>
									<TD height="17" vAlign="bottom"><IMG border="0" src="images\abaflu.JPG" useMap="DocVAKNavCadRep.aspx#lnk">
										<MAP name="lnk">
											<AREA href="javascript:troca2()" shape="RECT" coords="71,0,179,16">
											<AREA href="javascript:troca3()" shape="RECT" coords="186,0,269,16">
											<AREA href="javascript:troca6()" shape="RECT" coords="276,0,360,16">
											<AREA href="javascript:troca7()" shape="RECT" coords="365,0,455,16">
										</MAP>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 3px" width="8"></TD>
					</TR>
					<TR>
						<TD width="8"><IMG id="Img31" src="images/ImgTabDesEsqTop.gif" width="16" height="18"></TD>
						<TD bgColor="#e0eafc"></TD>
						<TD vAlign="top" width="8"><IMG id="Img32" src="images/ImgTabDesDra01.gif" width="16" height="18"></TD>
					</TR>
					<TR vAlign="top">
						<TD style="HEIGHT: 263px" bgColor="#e0eafc" width="10"></TD>
						<TD style="HEIGHT: 263px" bgColor="#e0eafc" vAlign="top">
							<TABLE style="WIDTH: 721px; HEIGHT: 190px" id="Table7" border="0" cellSpacing="1" cellPadding="1"
								width="721" bgColor="#e0eafc">
								<TR> <!--TD style="WIDTH: 183px" align="right" colSpan="2"><BR>												
											</TD--></TR>
								<TR>
									<TD colSpan="2" align="center"></TD>
								</TR>
								<TR>
									<TD align="right">
										<asp:label id="TitPrbSrs" runat="server" ForeColor="Black" Height="17px">Problema Serasa:</asp:label></TD>
									<TD>
										<asp:RadioButtonList id="RblPrbSrs" runat="server" Width="100px" Font-Size="XX-Small" Height="0px" RepeatDirection="Horizontal"
											RepeatLayout="Flow" Enabled="False">
											<asp:ListItem Value="S">Sim</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 237px; HEIGHT: 40px" align="right"></TD>
									<TD style="HEIGHT: 40px">
										<asp:textbox id="DesPrbSrs" runat="server" Width="368px" Height="164px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right">
										<asp:label id="TitAcePnd" runat="server" ForeColor="Black" Height="17px">Acertos Pendentes:</asp:label></TD>
									<TD style="HEIGHT: 17px">
										<asp:RadioButtonList id="RblAcePnd" runat="server" Width="100px" Font-Size="XX-Small" Height="0px" RepeatDirection="Horizontal"
											RepeatLayout="Flow" Enabled="False">
											<asp:ListItem Value="1">Sim</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">N&#227;o</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD align="right">
										<asp:label id="TitAcoTrb" runat="server" ForeColor="Black" Height="17px">Ações Trabalhistas/Cívis:</asp:label></TD>
									<TD style="WIDTH: 360px">
										<asp:textbox id="DesAcoTrb" runat="server" Width="368px" Height="120px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right">
										<asp:label id="TitVldCpf" runat="server" ForeColor="Black" Height="17px">Validação CPF:</asp:label></TD>
									<TD style="WIDTH: 360px; HEIGHT: 21px">
										<asp:RadioButtonList id="RblVldCpf" runat="server" Width="100px" Font-Size="XX-Small" Height="0px" RepeatDirection="Horizontal"
											RepeatLayout="Flow" Enabled="False">
											<asp:ListItem Value="S">Sim</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 237px; HEIGHT: 23px" align="right"></TD>
									<TD style="WIDTH: 360px; HEIGHT: 23px"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 263px" bgColor="#e0eafc" width="8"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 8px" width="8"><IMG src="images/ImgTabDesEsqIfo.gif" width="16" height="16"></TD>
						<TD style="HEIGHT: 8px" background="images/ImgFnd.gif" width="100%"></TD>
						<TD style="HEIGHT: 8px" width="8"><IMG src="images/ImgTabDesDraIfo.gif" width="16" height="16"></TD>
					</TR>
				</TABLE>
			</asp:panel><uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><cc2:messageboxweb id="MsgBoxWeb" runat="server"></cc2:messageboxweb><asp:button style="Z-INDEX: 116; POSITION: absolute; TOP: 24px; LEFT: 432px" id="btnDesativar"
				runat="server" Height="13px" Visible="False" Text="Button"></asp:button>
			<div style="DISPLAY: none"><asp:button style="Z-INDEX: 114; POSITION: absolute; TOP: 3064px; LEFT: 592px" id="btnIsr" runat="server"
					Width="112px" Text="Inserir"></asp:button><asp:textbox style="Z-INDEX: 110; POSITION: absolute; TOP: 3048px; LEFT: 496px" id="txtJaEnviou"
					runat="server" Width="48px"></asp:textbox></div>
		</form>
		<DIV></DIV>
	</body>
</HTML>
