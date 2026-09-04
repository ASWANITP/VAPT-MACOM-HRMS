<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="new_block_branch_first.aspx.vb" Inherits="WebAppHRMS.new_punch_block_rpt_new_block_branch_new_block_branch_a25aa5d92304" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table border="1" style="left: 0px; position: relative; top: 0px">
                    <caption>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_month">
                        </cc1:CalendarExtender>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager></caption>
                    <tr>
                        <td style="width: 725px; height: 10px;">
                            <strong>Select Branch Name</strong></td>
                        <td style="width: 100px; height: 10px;">
                            <asp:DropDownList ID="br_drop" runat="server" Height="120px" Style="left: 2px; position: relative;
                                top: 0px" Width="219px">
                            </asp:DropDownList></td>
                        <td colspan="2" style="height: 10px">
                            <strong>Select Day Of month</strong></td>
                        <td style="width: 100px; height: 10px;">
                            <asp:TextBox ID="txt_month" runat="server" Style="position: relative"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 725px; height: 9px;">
                        </td>
                        <td style="width: 100px; height: 9px;">
                        </td>
                        <td style="width: 64px; height: 9px;">
                            <asp:Button ID="Button1" runat="server" Style="left: 2px; position: relative; top: 0px"
                                Text="Confirm" Width="72px" /></td>
                        <td style="width: 77px; height: 9px;">
                            <input id="Reset1" style="width: 58px; position: relative" type="reset" value="Exit" onclick="return Reset1_onclick()" /></td>
                        <td style="width: 100px; height: 9px;">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

