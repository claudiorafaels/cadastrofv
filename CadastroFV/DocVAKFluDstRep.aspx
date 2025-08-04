<%@ Register TagPrefix="cc1" Namespace="VAK016.Web" Assembly="VAK016" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocVAKFluDstRep.aspx.vb" Inherits="VAKItfUsrWeb.Recisao" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Cadastro da Força de Vendas</title>
		<meta content="True" name="vs_showGrid">
		<LINK href="comum/default.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="comum/DocFunCmuJS.htm"></script>
		<script language="javascript">
			var control = document.getElementById("lstMtvDst");
			if( control != null ){control.focus();}

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
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:usrconcab id="UsrConCab1" runat="server"></uc1:usrconcab><asp:panel id="Panel1" style="Z-INDEX: 101; POSITION: absolute; TOP: 144px; LEFT: 16px" runat="server"
				Height="624px" ForeColor="Red" Font-Size="X-Small" Width="100%" BackColor="White" Font-Names="Verdana">
<TABLE style="WIDTH: 100%; HEIGHT: 300px; VERTICAL-ALIGN: top" id=Table21 
border=0 cellSpacing=0 cellPadding=0 align=center>
  <TR>
    <TD style="WIDTH: 4px" width=4><IMG id=Img9 
      src="images/ImgTabDesEsqTop.gif" width=16 height=18></TD>
    <TD bgColor=#e0eafc>
<asp:Label id=lblCodFlu runat="server" BackColor="#E7EBFF" Font-Bold="True">Fluxo:</asp:Label></TD>
    <TD style="WIDTH: 11px" vAlign=top width=11><IMG id=Img10 
      src="images/ImgTabDesDra01.gif" width=16 height=18></TD></TR>
  <TR vAlign=top>
    <TD style="WIDTH: 4px; HEIGHT: 891px" bgColor=#e0eafc width=4></TD>
    <TD style="HEIGHT: 891px" vAlign=top width="100%" align=center>
      <TABLE 
      style="BORDER-RIGHT-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px" 
      id=Table23 border=0 cellSpacing=0 borderColor=#96b1cb cellPadding=0 
      width="100%" bgColor=#e0eafc align=center height="100%">
        <TR>
          <TD style="WIDTH: 100%; HEIGHT: 75.52%" vAlign=top align=center>
            <TABLE style="WIDTH: 100%; HEIGHT: 455px" id=Table24 border=0 
            cellSpacing=1 cellPadding=1 width=720>
              <TR><!--TD style="WIDTH: 183px" align="right" colSpan="2">doudou<BR>
											</TD--></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 14px" align=right>
<asp:Label id=Label2 runat="server" BackColor="#E7EBFF">Representante:</asp:Label></TD>
                <TD style="HEIGHT: 14px">
<asp:Label id=txtCodNomRep runat="server" BackColor="#E7EBFF">0000 - NOME DO REPRESENTANTE</asp:Label></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 26px" align=right>
<asp:Label id=Label9 runat="server" BackColor="#E7EBFF" Visible="False">Criação Fluxo:</asp:Label></TD>
                <TD style="HEIGHT: 26px">
<ew:calendarpopup id=DatCri tabIndex=7 runat="server" Width="88px" Height="21px" Visible="False" Culture="Portuguese (Brazil)" GoToTodayText="Data Atual:" AllowArbitraryText="False" Nullable="True" ClearDateText="Nenhuma">
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
													</ew:calendarpopup></TD></TR>
              <TR>
                <TD style="HEIGHT: 2px" bgColor=white borderColor=#ffff0e 
                width=1 colSpan=2></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 34px" align=right>
<asp:Label id=Label6 runat="server" BackColor="#E7EBFF">Motivo da Desativação:</asp:Label></TD>
                <TD style="HEIGHT: 34px">
<asp:DropDownList id=lstMtvDst runat="server" Width="312px"></asp:DropDownList></TD></TR><!-- bruno -->
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 14px" align=right>
<asp:Label id=Label10 runat="server" BackColor="#E7EBFF">Descrição do Motivo:</asp:Label></TD>
                <TD style="HEIGHT: 14px">
<asp:textbox id=txtDesMtvDstRep runat="server" Width="552px" TextMode="MultiLine" CssClass="tit" MaxLength="240"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 29px" align=right>
<asp:Label id=Label1 runat="server" BackColor="#E7EBFF">Valor do Acordo:</asp:Label></TD>
                <TD style="HEIGHT: 29px">&nbsp;R$ 
<asp:textbox style="TEXT-ALIGN: right" id=txtVlrAcd runat="server" Width="128px" CssClass="tit" Enabled="False"></asp:textbox>&nbsp; 
<asp:Label id=Label16 runat="server" BackColor="#E7EBFF" Font-Size="XX-Small" ForeColor="#0000C0">O valor do acordo, caso haja, será informado pelo GV quando este for aprovar o fluxo.</asp:Label></TD></TR>
              <TR>
                <TD style="HEIGHT: 2px" bgColor=white borderColor=#ffff0e 
                width=1 colSpan=2></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 2px" bgColor=#e7ebff 
                borderColor=#ffff0e width=175 align=right>
<asp:Label id=Label5 runat="server" BackColor="#E7EBFF">Observações:</asp:Label></TD>
                <TD style="HEIGHT: 2px" bgColor=#e7ebff borderColor=#ffff0e 
                width=1>
<asp:textbox id=txtObsFlu runat="server" Width="552px" TextMode="MultiLine" CssClass="tit" MaxLength="240" Rows="3"></asp:textbox></TD></TR>
              <TR>
                <TD style="HEIGHT: 2px" bgColor=#ffffff borderColor=#ffff0e 
                width=1 colSpan=2></TD></TR>
              <TR>
                <TD style="WIDTH: 175px" align=right></TD>
                <TD>Dados atualizados do representante</TD></TR>
              <TR>
                <TD style="WIDTH: 175px" align=right>
<asp:label id=Label15 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Endereço:</asp:label></TD>
                <TD>
<asp:textbox id=txtEndREp runat="server" Width="544px" CssClass="tit" MaxLength="30"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 24px" align=right>
<asp:label id=Label14 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Telefone:</asp:label></TD>
                <TD style="HEIGHT: 24px">
<asp:textbox id=txtNumTlfRep runat="server" CssClass="tit" MaxLength="13"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px" align=right>
<asp:label id=Label13 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Celular:</asp:label></TD>
                <TD>
<asp:textbox id=txtNumTelCelRep runat="server" CssClass="tit" MaxLength="13"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 16px" align=right>
<asp:label id=Label12 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Fax:</asp:label></TD>
                <TD style="HEIGHT: 16px">
<asp:textbox id=txtNumFaxRep runat="server" CssClass="tit" MaxLength="13"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 28px" align=right>
<asp:label id=Label11 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Cep:</asp:label></TD>
                <TD style="HEIGHT: 28px">
<asp:textbox id=txtCodCepRep runat="server" CssClass="tit" MaxLength="8"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 28px" align=right>
<asp:label id=Label8 runat="server" BackColor="#E7EBFF" ForeColor="Black" Height="17px">Cidade:</asp:label></TD>
                <TD style="HEIGHT: 28px">
<asp:DropDownList id=lstEstUni runat="server" AutoPostBack="True"></asp:DropDownList>
<asp:DropDownList id=lstCidRep runat="server" Width="280px"></asp:DropDownList></TD></TR>
              <TR>
                <TD style="HEIGHT: 2px" bgColor=white borderColor=#ffff0e 
                width=1 colSpan=2></TD></TR>
              <TR>
                <TD style="WIDTH: 175px; HEIGHT: 27px" align=right>
<asp:Label id=Label7 runat="server" BackColor="#E7EBFF" Width="157px">Transferir/apropriar territórios para:</asp:Label></TD>
                <TD style="HEIGHT: 27px" noWrap>
<asp:RadioButton id=rdoSupSbt runat="server" BackColor="#E7EBFF" AutoPostBack="True" Checked="True" GroupName="TransfTerr" Text="GM"></asp:RadioButton>&nbsp;&nbsp; 
<asp:RadioButton id=rdoRepSbt runat="server" BackColor="#E7EBFF" AutoPostBack="True" GroupName="TransfTerr" Text="Outro Representante:"></asp:RadioButton>
<asp:DropDownList id=lstOtrRep runat="server" Width="272px"></asp:DropDownList><BR>
<asp:Label id=Label17 runat="server" BackColor="#E7EBFF" Font-Size="XX-Small" ForeColor="#0000C0">Os territórios do representante serão transferidos para o GM e apropriados para um representante, caso algum tenha sido escolhido.</asp:Label></TD></TR>
              <TR>
                <TD style="HEIGHT: 2px" bgColor=white borderColor=#ffff0e 
                width=1 colSpan=2></TD></TR>
              <TR height=0>
                <TD style="HEIGHT: 2px" borderColor=#ffff0e width="100%" 
                colSpan=2>
<asp:datagrid id=grdPgnRsp runat="server" BackColor="White" Width="100%" Height="200px" BorderStyle="None" BorderColor="#999999" CellPadding="3" GridLines="Vertical" BorderWidth="1px" AutoGenerateColumns="False">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="DESPGN" ReadOnly="True" HeaderText="Perguntas">
																<HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Respostas">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemTemplate>
																	<asp:TextBox id="txtResposta" MaxLength="2000" runat="server" Width="98%"></asp:TextBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD></TR></TABLE></TD></TR>
        <TR>
          <TD style="HEIGHT: 2px" bgColor=white borderColor=#ffff0e width=1 
          colSpan=2></TD></TR>
        <TR>
          <TD>
<asp:Label id=lblAviso runat="server" ForeColor="Blue" Font-Bold="True" Visible="False">Aviso</asp:Label>
            <FIELDSET style="WIDTH: 98%; HEIGHT: 48px" 
            align=absMiddle><LEGEND>Fluxo de desativação</LEGEND>
<asp:Button id=cmdIniFlu runat="server" BackColor="#FFFFC0" Width="122px" ForeColor="Black" Height="22px" Text="Salvar e Iniciar Fluxo"></asp:Button>&nbsp;&nbsp; 
<asp:RadioButton id=rdoIniEmp runat="server" BackColor="#E7EBFF" AutoPostBack="True" Checked="True" GroupName="FluDst" Text="Iniciativa da Empresa"></asp:RadioButton>&nbsp; 
<asp:RadioButton id=rdoIniRep runat="server" BackColor="#E7EBFF" AutoPostBack="True" GroupName="FluDst" Text="Iniciativa do RCA"></asp:RadioButton>&nbsp; 
<asp:Label id=txtSolicDemissao runat="server" Font-Bold="True" Visible="False">Data da Carta de Demissão:  </asp:Label>
<ew:calendarpopup id=txtDatSlcDem tabIndex=7 runat="server" Width="88px" Height="21px" Visible="False" Culture="Portuguese (Brazil)" GoToTodayText="Data Atual:" AllowArbitraryText="False" Nullable="True" ClearDateText="Nenhuma">
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
											</ew:calendarpopup></FIELDSET> <BR>
            <FIELDSET 
            style="WIDTH: 98%; HEIGHT: 48px"><LEGEND>Notificação</LEGEND>
<asp:Button id=cmdNotRep runat="server" BackColor="#FFFFC0" Width="122px" Height="22px" Text="Salvar e Notificar"></asp:Button>&nbsp;&nbsp; 
<asp:RadioButton id=rdoNotCmpCtt runat="server" BackColor="#E7EBFF" AutoPostBack="True" GroupName="FluDst" Text="Para cumprimento de contrato"></asp:RadioButton>&nbsp; 
<asp:RadioButton id=rdoOtrMtv runat="server" BackColor="#E7EBFF" AutoPostBack="True" GroupName="FluDst" Text="Por outros motivos"></asp:RadioButton></FIELDSET> 
            &nbsp;<BR>
<asp:Button id=cmdLstAco runat="server" BackColor="White" Text="Ver e executar ações..."></asp:Button>&nbsp;&nbsp; 
<asp:Button id=cmdVoltar runat="server" BackColor="White" Width="100px" Text="Voltar"></asp:Button>&nbsp; 
<asp:Button id=cmdGrvFlu runat="server" BackColor="White" Width="163px" Text="Salvar - sem iniciar o fluxo"></asp:Button>&nbsp;</TD></TR>
        <TR>
          <TD vAlign=top align=right></TD></TR></TABLE></TD>
    <TD style="WIDTH: 11px" bgColor=#e0eafc 
width=11>&nbsp;</TD></TR></TABLE>
<TABLE>
  <TR height=30>
    <TD></TD></TR></TABLE>
			</asp:panel></form>
	</body>
</HTML>
