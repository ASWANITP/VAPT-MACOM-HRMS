<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="incentive_allowance_select.aspx.vb" Inherits="WebAppHRMS.TA_UPD_VER3_incentive_allowance_select_e01e86ac8030" Title="Incentives and Allowances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont_name = sal.split('Txt');
        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        function checknumber(t) {
            var a = document.getElementById(cont_name[0] + t).value;
            if (isNaN(a)) {
                alert('Please enter correct value in number format!!');
                document.getElementById(cont_name[0] + t).value = "";
                document.getElementById(cont_name[0] + t).focus();
                return false;
            }
        }

        function cliclick() {
            if (document.getElementById(cont_name[0] + "Txt_itemValue").value == "") {
                alert('Please Enter correct Value!!');
                document.getElementById(cont_name[0] + "Txt_itemValue").focus();
                return false;
            }
        }

        function init() {
            document.getElementById(cont_name[0] + "Txt_itemValue").value = "";
        }
        window.onload = init;


        // ]]>
    </script>


    <div style="text-align: center">
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 470px">
            <tr>
                <td style="width: 197px; height: 23px; text-align: left">
                    <strong>Select Employee:</strong></td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:DropDownList ID="Cmb_Employee" runat="server" Width="254px" ToolTip="Select Employee By Clicking!!" Style="cursor: hand">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 197px; text-align: left; height: 1px;">
                    <strong>Select Item to Insert/Update:</strong></td>
                <td style="width: 100px; text-align: left; height: 1px;">
                    <asp:DropDownList ID="Cmb_Item" runat="server" Width="180px" ToolTip="Select Item From this..!!" Style="cursor: hand" TabIndex="1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 197px; text-align: left; height: 1px;">
                    <strong>Enter
                    Item Value:</strong></td>
                <td style="width: 100px; text-align: left; height: 1px;">
                    <asp:TextBox ID="Txt_itemValue" onkeyup="return checknumber('Txt_itemValue')" runat="server" BackColor="LemonChiffon" MaxLength="8"
                        Width="89px" Style="cursor: text" TabIndex="2" ToolTip="Insert The Item Value by Typing..!!"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="1" style="height: 1px">
            <tr>
                <td style="width: 86px; height: 14px; text-align: left">
                    <input id="Cmd_Exit" style="width: 85px; cursor: hand; border-left-style: solid;" type="button" value="EXIT" tabindex="3" onclick="return Cmd_Exit_onclick()" tooltip="Click  to go back..!!" /></td>
                <td style="width: 86px; height: 14px; text-align: left">
                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="89px" Style="cursor: hand" TabIndex="4" ToolTip="Click this Button to Enter The Value..!!" /></td>
                <td style="width: 86px; height: 14px; text-align: left">
                    <asp:Button ID="Cmd_Report" runat="server" TabIndex="5" Text="REPORT" ToolTip="Click This to get Itemwise Report..!!"
                        Width="85px" Style="cursor: hand" /></td>
            </tr>
        </table>
        <cc1:ListSearchExtender ID="ListSearch_Employee" runat="server" TargetControlID="Cmb_Employee">
        </cc1:ListSearchExtender>
        &nbsp;
        <br />
        <br />
    </div>
</asp:Content>


