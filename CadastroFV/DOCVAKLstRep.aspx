<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DOCVAKLstRep.aspx.vb" Inherits="VAKItfUsrWeb.DOCVAKLstRep" smartNavigation="True" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="UsrConCab" Src="UsrConCab.ascx" %>
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
<TABLE style="WIDTH: 100%; VERTICAL-ALIGN: top" id=Table21 border=0 
cellSpacing=0 cellPadding=0 align=center>
  <TR style="HEIGHT: 16px">
    <TD width=8><IMG id=Img9 src="images/ImgTabDesEsqTop.gif" width=16 
      height=18></TD>
    <TD bgColor=#e0eafc colSpan=4></TD>
    <TD style="WIDTH: 10px" vAlign=top width=10><IMG id=Img10 
      src="images/ImgTabDesDra01.gif" width=16 height=18></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD style="HEIGHT: 25px" bgColor=#e0eafc width=10></TD>
    <TD style="HEIGHT: 25px" colSpan=3 align=left>&nbsp; 
<asp:Label id=Label3 runat="server" BackColor="#E7EBFF" Font-Bold="True">Lista de RCAs - Filtros</asp:Label></TD>
    <TD style="HEIGHT: 25px"></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD style="HEIGHT: 25px" bgColor=#e0eafc width=10></TD>
    <TD style="HEIGHT: 25px" align=left>
<asp:Label id=Label1 runat="server" BackColor="#E7EBFF" Width="48px">Fluxo:</asp:Label></TD>
    <TD style="HEIGHT: 25px">
<asp:RadioButton id=rdbCriado runat="server" BackColor="#E7EBFF" GroupName="Fluxo" Text="Criado"></asp:RadioButton>
<asp:RadioButton id=rdbIniciado runat="server" BackColor="#E7EBFF" GroupName="Fluxo" Text="Iniciado"></asp:RadioButton>
<asp:RadioButton id=rdbInexistente runat="server" BackColor="#E7EBFF" GroupName="Fluxo" Text="Inexistente"></asp:RadioButton>
<asp:RadioButton id=rdbARevisar runat="server" BackColor="#E7EBFF" GroupName="Fluxo" Text="A Revisar"></asp:RadioButton>
<asp:RadioButton id=rdbTodos runat="server" BackColor="#E7EBFF" GroupName="Fluxo" Text="Todos" Checked="True"></asp:RadioButton></TD>
    <TD style="HEIGHT: 25px" align=right>Dias s/ pedido: 
<asp:TextBox id=txtDiaSemPed runat="server" Width="48px" MaxLength="3"></asp:TextBox></TD>
    <TD style="HEIGHT: 25px"></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD bgColor=#e0eafc width=10></TD>
    <TD align=left>
<asp:Label id=Label2 runat="server" BackColor="#E7EBFF">RCA:</asp:Label></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD style="HEIGHT: 23px" bgColor=#e0eafc width=10></TD>
    <TD style="HEIGHT: 23px">
<asp:Label id=Label4 runat="server" BackColor="#E7EBFF">Cód./Nome:</asp:Label></TD>
    <TD style="HEIGHT: 23px">
<asp:TextBox id=txtCodRep runat="server" Width="48px" MaxLength="6"></asp:TextBox>
<asp:TextBox id=txtNomRep runat="server" Width="285px" MaxLength="15"></asp:TextBox></TD>
    <TD style="HEIGHT: 23px"></TD>
    <TD style="HEIGHT: 23px">&nbsp; </TD>
    <TD style="HEIGHT: 23px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD bgColor=#e0eafc width=10></TD>
    <TD>
<asp:Button id=btnConsultar runat="server" BackColor="White" Width="100px" Text="Consultar"></asp:Button></TD>
    <TD></TD>
    <TD align=right>
<asp:Button id=btnLstFlu runat="server" BackColor="White" Text="Fluxos de desativação..."></asp:Button></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD bgColor=#e0eafc width=10></TD>
    <TD></TD>
    <TD></TD>
    <TD></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR>
  <TR style="HEIGHT: 16px">
    <TD bgColor=#e0eafc width=10></TD>
    <TD colSpan=4>
<asp:datagrid id=GrpDdoFluDst runat="server" BackColor="White" Width="100%" Height="24px" PageSize="50" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False" BorderWidth="1px" GridLines="Vertical" CellPadding="3" BorderColor="#999999" BorderStyle="None">
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
								<ItemStyle CssClass="tableData" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#0F4871"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CODREP" SortExpression="CODREP" HeaderText="C&#243;d.">
										<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NOMREP" SortExpression="NOMREP" HeaderText="Nome RCA">
										<HeaderStyle HorizontalAlign="Center" Width="22%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QDEDIASEMPED" SortExpression="QDEDIASEMPED" HeaderText="Dias s/ pedido">
										<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FluxoDeDesativacao" SortExpression="FluxoDeDesativacao" HeaderText="Fluxo">
										<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Qtd. Recibos Devidos">
										<HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<A href='DocVAKLstRpaNotFscRca.aspx?codrep=<%# Container.DataItem("CODREP") %>&nomrep=<%# Container.DataItem("NOMREP") %>'>
												<%# Container.DataItem("QuantidadeDeRecibosDevidos") %>
											</A>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CodigoDoFluxoMaisRecente">
										<HeaderStyle Width="13%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="13%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
    <TD style="WIDTH: 10px" bgColor=#e0eafc width=10></TD></TR></TABLE>
<DIV style="HEIGHT: 16px"></DIV>
			</asp:panel></form>
	</body>
</HTML>
