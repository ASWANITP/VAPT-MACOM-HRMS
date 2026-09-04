<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_newr_branch.aspx.vb" Inherits="WebAppHRMS.general_emp_newr_branch_5d6ad89c9657" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open("../home.aspx","_self");
}

// ]]>
</script>

    <table align="center" border="1">
        <tr>
            <td style="text-align: center;" colspan="4">
                <strong>UPDATE NEAR BRANCH</strong></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Employee Code</td>
            <td style="width: 100px">
                <input id="txt_empcode" readonly="readonly" type="text" runat="server" /></td>
            <td style="width: 100px">
                Employee&nbsp;Name</td>
            <td style="width: 100px">
                <input id="txt_empnm" readonly="readonly" type="text" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                Branch Name</td>
            <td style="width: 100px">
                <select id="cmb_branch" style="width: 184px" runat="server">
                    <option selected="selected"></option>
                </select>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 23px; text-align: center;" colspan="4">
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" />
                <input id="cmd_exit" style="width: 64px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
        </tr>
    </table>
</asp:Content>

