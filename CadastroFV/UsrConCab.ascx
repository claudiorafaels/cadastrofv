<%@ Register TagPrefix="cc1" Namespace="SolpartWebControls" Assembly="SolpartWebControls" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="UsrConCab.ascx.vb" Inherits="VAKItfUsrWeb.Cab" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P>
	<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="98%" border="0">
		<TR class="HeadBg">
			<TD style="HEIGHT: 7px" align="left" width="100%" colSpan="2" height="7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="oNomSis" runat="server" Font-Names="Tahoma" ForeColor="Black" Font-Size="12pt"
					Font-Bold="True" Width="100%">Nome do Sistema</asp:label></TD>
			<TD style="HEIGHT: 7px" width="100%" height="7"></TD>
		</TR>
		<TR class="HeadBg">
			<TD vAlign="bottom" align="left" height="25">&nbsp;<asp:image id="imgLogo" runat="server" Width="42px" ImageUrl="Images/LogoMartins.gif" Height="33px"
					AlternateText="LOGO" ToolTip="HOME"></asp:image>&nbsp;&nbsp;</TD>
			<TD vAlign="middle" width="100%" height="25">
				<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR class="HeadBg" vAlign="bottom">
						<TD width="100%" height="25">
							<TABLE id="Table3" height="25" cellSpacing="0" cellPadding="0" width="100%" align="left"
								border="0">
								<TR>
									<TD style="HEIGHT: 14px" width="60" rowSpan="2"><asp:image id="imgTabImage" runat="server" ImageUrl="images/tabimage.gif" height="27px" width="60"
											borderwidth="0"></asp:image></TD>
									<TD style="HEIGHT: 2px" width="100%" bgColor="#333333" colSpan="3" height="2"><asp:image id="imgBevel" runat="server" ImageUrl="images/bevel.gif" height="6px" width="100%"
											BorderWidth="0"></asp:image></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 8px" align="left" bgColor="#333333" height="8"><cc1:solpartmenu id="ctlMenu" runat="server" Font-Names="Tahoma,Arial,Helvetica" ForeColor="WhiteSmoke"
											Font-Size="9pt" Font-Bold="True" MenuDataXMLFileName="data/MenuData.xml" MenuEffects-MouseOverExpand="True" SystemImagesPath="Images/" BackColor="#333333"
											MenuEffects-Style="filter:progid:DXImageTransform.Microsoft.Shadow(color='DimGray', Direction=135, Strength=4) ;" MenuEffects-MouseOverDisplay="Highlight"
											SelectedColor="#0F4871" ShadowColor="#404040" IconBackgroundColor="#333333" HighlightColor="#FF8080" SelectedForeColor="WhiteSmoke" IconWidth="0" SelectedBorderColor="#333333"
											Moveable="False" MenuBarHeight="10" MenuItemHeight="21" MenuBorderWidth="0" ForceDownlevel="False" MouseOutHideDelay="1" MenuEffects-MouseOutHideDelay="500"
											MenuEffects-ShadowStrength="4"></cc1:solpartmenu></TD>
									<TD style="HEIGHT: 8px" align="left" width="100%" bgColor="#333333" height="8">&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR class="HeadBg">
			<TD style="HEIGHT: 19px" vAlign="top" align="left" width="100%" bgColor="whitesmoke"
				colSpan="2" height="19">
				<TABLE id="Table4" height="10" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR vAlign="top">
						<TD class="TabBg" style="HEIGHT: 2px" vAlign="middle" noWrap align="left" bgColor="#0f4871"
							height="2"></TD>
						<TD class="TabBg" style="WIDTH: 150px; HEIGHT: 2px" vAlign="middle" noWrap align="left"
							bgColor="#0f4871" height="2">&nbsp;<asp:label id="oUsr" runat="server" Font-Names="Tahoma" ForeColor="WhiteSmoke" Font-Size="8pt"
								Font-Bold="True" CssClass="SelectedTab">User</asp:label>&nbsp;</TD>
						<TD noWrap align="left" bgColor="#0f4871" colSpan="2"><asp:label id="oInfNvg" runat="server" Font-Names="Tahoma" ForeColor="WhiteSmoke" Font-Size="8pt"
								Font-Bold="True" CssClass="SelectedTab">Home > Level2 > Level3 > Level4</asp:label></TD>
						<TD class="TabBg" vAlign="middle" noWrap align="right" bgColor="#0f4871" height="3"><asp:label id="oDat" runat="server" Font-Names="Tahoma" ForeColor="WhiteSmoke" Font-Size="8pt"
								Font-Bold="True" CssClass="SelectedTab">Date</asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 152px; BACKGROUND-COLOR: whitesmoke" align="left" colSpan="2" height="34">
							<A onclick="javascript:history.back()" href="#"><IMG id="ArqImgAnt" style="MARGIN-RIGHT: 3px" alt="Voltar" src="images/ArqImgAnt.gif"
									border="0"> </A><A onclick="javascript:history.forward()" href="#"><IMG id="ArqImgPrx" style="MARGIN-RIGHT: 3px" alt="Próximo" src="images/ArqImgPrx.gif"
									border="0"> </A><A onclick="javascript:location='DocVakAutCtt.aspx'" href="#">
								<IMG id="ArqImgTpc" style="MARGIN-RIGHT: 3px" alt="Home" src="images/ArqImgTpc.gif" border="0">
							</A>
							<!--
							<A onclick="window.open('DocVAKDlgAcoApv.aspx','_blank','width=450,height=300')" href="#">
							-->
							<IMG id="ImgEnv" onmouseover="javascript:this.style.cursor='hand'" style="DISPLAY:none;VISIBILITY:hidden;MARGIN-RIGHT:3px"
								onclick="window.parent.document.all.btnIsr.click();" alt="Enviar" src="images/ArqImgEnv.gif"
								border="0">&nbsp;&nbsp; 
							<!--
									<A href="javascript:location='http://ntnot005/MS/VAV/BCOVAVPRMEQIVND/BcoVAVPrmEqiVnd.nsf'" target="_blank">
									-->
							<!--
							</A>
							-->
						</TD>
						<td style="TEXT-ALIGN: left" colSpan="3">
							<P align="center"><asp:label id="TitErr" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" runat="server"
									Visible="True"></asp:label></P>
						</td>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</P>
