<%@ Control Language="vb" AutoEventWireup="false" CodeFile="datefiller.ascx.vb" Inherits="branch.datefiller" %>
<%@ Register Src="~/control/uc_date.ascx" TagPrefix="uc1" TagName="uc_date" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="50%" align="center" border="1">
	<TR>
		<TD align="center" colSpan="4">
            <input id="hid_date" runat="server" type="hidden" style="width: 11px" />Enter Date
            <input id="hid_date1" runat="server" type="hidden" style="width: 6px" /></TD>
	</TR>
	<TR>
		<TD style="width: 179px">FROM&nbsp;DATE :</TD>
		<TD style="width: 154px">
            <uc1:uc_date ID="Uc_date1" runat="server" />
		</TD>
		<TD style="width: 85px">TO&nbsp;DATE :</TD>
		<TD >
            <uc1:uc_date ID="Uc_date2" runat="server" />
		</TD>
	</TR>
</TABLE>