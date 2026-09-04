<%@ Control Language="vb" AutoEventWireup="false" CodeFile="datefiller.ascx.vb" Inherits="branch.datefiller" %>
<%@ Register Src="~/control/uc_date.ascx" TagPrefix="uc1" TagName="uc_date" %>
<table id="Table1" cellspacing="1" cellpadding="1" width="50%" align="center" border="1">
    <tr>
        <td align="center" colspan="4">
            <input id="hid_date" runat="server" type="hidden" style="width: 11px" />Enter Date
            <input id="hid_date1" runat="server" type="hidden" style="width: 6px" /></td>
    </tr>
    <tr>
        <td style="width: 179px">FROM&nbsp;DATE :</td>
        <td style="width: 154px">
            <uc1:uc_date ID="Uc_date1" runat="server" />
        </td>
        <td style="width: 85px">TO&nbsp;DATE :</td>
        <td>
            <uc1:uc_date ID="Uc_date2" runat="server" />
        </td>
    </tr>
</table>
