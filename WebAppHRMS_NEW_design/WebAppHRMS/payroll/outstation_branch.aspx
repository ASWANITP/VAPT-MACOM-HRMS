<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="outstation_branch.aspx.vb" Inherits="WebAppHRMS.New_TA_Report_outstation_branch_b3ed3af28676" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont_name = sal.split('Cmb');
        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }


        function cliclick() {
            var b1 = document.getElementById(cont_name[0] + "Cmb_Branch").value;
            var b2 = document.getElementById(cont_name[0] + "Cmb_BranchTo").value;
            if (parseInt(b1) > parseInt(b2)) {
                alert('Please select big or Equal number in Second Branch Box than First Box!!');
                return false;
            }
        }

        // ]]>
    </script>


    <br />
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />


        <div style="text-align: center">
            <table border="1" style="width: 445px">
                <tr>
                    <td style="width: 212px; text-align: left">
                        <strong>From Branch:</strong></td>
                    <td style="width: 84px; text-align: left">
                        <asp:DropDownList ID="Cmb_Branch" runat="server" Width="228px" Style="cursor: hand" TabIndex="2">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 212px; text-align: left">
                        <strong>To Branch:</strong></td>
                    <td style="width: 84px; text-align: left">
                        <asp:DropDownList ID="Cmb_BranchTo" runat="server" Style="cursor: hand" TabIndex="3" Width="228px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 212px; text-align: center;">
                        <input id="Cmd_Exit" style="width: 72px; cursor: hand;" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" tabindex="4" /></td>
                    <td style="width: 212px; text-align: center;">&nbsp;<asp:Button ID="Cmd_Report" OnClientClick="return cliclick()" runat="server" Text="REPORT" Style="cursor: hand" TabIndex="5" /></td>
                </tr>
            </table>
            <cc1:ListSearchExtender ID="ListSearchBranchFrom" runat="server" TargetControlID="Cmb_Branch"></cc1:ListSearchExtender>
            <cc1:ListSearchExtender ID="ListSearchBranchTo" runat="server" TargetControlID="Cmb_BranchTo">
            </cc1:ListSearchExtender>
            <br />
            <br />
        </div>
        <br />
    </div>
</asp:Content>

