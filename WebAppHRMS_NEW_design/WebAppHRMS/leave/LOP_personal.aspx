<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LOP_personal.aspx.vb" Inherits="WebAppHRMS.LOP_to_Personal_Account_LOP_personal_3e0442e66734" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
    </script>

    <br />
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;<table border="1" style="width: 514px; height: 74px">
            <tr>
                <td style="width: 151px; text-align: right">Select Employee:&nbsp;
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_emp" runat="server" AutoPostBack="True" Width="350px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 151px; text-align: right">Select Leave :&nbsp;
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_leave" runat="server" Width="350px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 151px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 151px; text-align: right">
                    <input id="cmd_exit" style="width: 84px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; text-align: left">&nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_emp"></cc1:ListSearchExtender>
    </div>
</asp:Content>

