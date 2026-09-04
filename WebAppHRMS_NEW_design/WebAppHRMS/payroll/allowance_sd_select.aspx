<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="allowance_sd_select.aspx.vb" Inherits="WebAppHRMS.SD_CONFIRM_REPORT_allowance_sd_select_b49557c14996" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = sal.split('Cmb');
        function Check_Department_onclick() {
            if (document.getElementById(cont_name[0] + "Check_Department").checked == true) {
                document.getElementById(cont_name[0] + "Cmb_Department").disabled = false;
                document.getElementById(cont_name[0] + "Hid_Department").value = document.getElementById(cont_name[0] + "Cmb_Department").value;
            }
            if (document.getElementById(cont_name[0] + "Check_Department").checked == false) {
                document.getElementById(cont_name[0] + "Cmb_Department").disabled = true;
                document.getElementById(cont_name[0] + "Hid_Department").value = 0;
            }
        }

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function cmbonchange() {
            document.getElementById(cont_name[0] + "Hid_Department").value = document.getElementById(cont_name[0] + "Cmb_Department").value;
        }
        function init() {
            if (document.getElementById(cont_name[0] + "Check_Department").checked == true) {
                document.getElementById(cont_name[0] + "Cmb_Department").disabled = false;
                document.getElementById(cont_name[0] + "Hid_Department").value = document.getElementById(cont_name[0] + "Cmb_Department").value;
            }
            if (document.getElementById(cont_name[0] + "Check_Department").checked == false) {
                document.getElementById(cont_name[0] + "Cmb_Department").disabled = true;
                document.getElementById(cont_name[0] + "Hid_Department").value = 0;
            }
        }
        window.onload = init;

        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <table border="1">
            <tr>
                <td style="width: 147px; text-align: left">
                    <strong>Select Incentive:</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="Cmb_Incentive" runat="server" Width="254px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 147px; text-align: left">
                    <strong>Select Department:</strong></td>
                <td style="width: 1px; text-align: left">
                    <input id="Check_Department" type="checkbox" onclick="return Check_Department_onclick()" runat="server" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="Cmb_Department" onchange="cmbonchange()" runat="server" Width="226px">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="1" style="width: 104px">
            <tr>
                <td style="width: 100px; text-align: right">
                    <input id="Cmd_Exit" type="button" value="EXIT" style="width: 80px" onclick="return Cmd_Exit_onclick()" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>

        <asp:HiddenField ID="Hid_Department" runat="server" Value="0" />
        <br />
    </div>
</asp:Content>

