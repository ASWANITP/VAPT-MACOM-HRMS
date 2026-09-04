<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="extend_compen.aspx.vb" Inherits="WebAppHRMS.compensatory_extension_extend_compen_122a91077953" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
window.open('../../Home.aspx','_self')
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 935px; height: 104px;">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_cal">
                </cc1:CalendarExtender>
                <strong>
                <span style="font-size: 14pt; color: #cc3333">COMPENSATORY EXTENSION FOR&nbsp;
                    EMPLOYEES</span></strong></caption>
            <tr>
                <td style="width: 276px; text-align: left;">
                    <strong style="font-style: normal">Select Employee</strong></td>
                <td colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drp_emp" runat="server" AutoPostBack="True" Width="432px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 276px; text-align: left; height: 26px;">
                    <strong>Compensatory </strong>
                </td>
                <td style="width: 103px; height: 26px;">
                    <asp:DropDownList ID="drp_comp" runat="server" AutoPostBack="True" Width="304px">
                    </asp:DropDownList></td>
                <td style="width: 171px; height: 26px;">
                    <strong>Expiry Date</strong></td>
                <td style="width: 92px; height: 26px;">
                    <asp:TextBox ID="txt_cal" runat="server" Width="241px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 276px; height: 23px">
                </td>
                <td style="height: 23px; text-align: center;" colspan="2">
                    </td>
                <td style="width: 92px; height: 23px">
                </td>
            </tr>
            <tr>
                <td style="width: 276px; height: 28px;">
                </td>
                <td style="height: 28px;" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="88px" /><input id="Reset1" style="width: 79px" type="reset" value="EXIT" onclick="return Reset1_onclick()" /></td>
                <td style="width: 92px; height: 28px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

