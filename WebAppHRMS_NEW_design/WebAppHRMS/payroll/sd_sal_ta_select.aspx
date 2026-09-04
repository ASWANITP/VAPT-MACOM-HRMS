<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="sd_sal_ta_select.aspx.vb" Inherits="WebAppHRMS.sd_sal_ta_report_sd_sal_ta_select_9ce61f503296" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = sal.split('Cmb');
        function Check_Salary_onclick() {
            if (document.getElementById(cont_name[0] + "Check_Salary").checked == true) {
                document.getElementById(cont_name[0] + "Check_Incentive").checked = false;
                document.getElementById(cont_name[0] + "Hid_Type").value = 1;
            }
            if (document.getElementById(cont_name[0] + "Check_Salary").checked == false) {
                document.getElementById(cont_name[0] + "Hid_Type").value = 0;
            }
        }

        function Check_Incentive_onclick() {
            if (document.getElementById(cont_name[0] + "Check_Incentive").checked == true) {
                document.getElementById(cont_name[0] + "Check_Salary").checked = false;
                document.getElementById(cont_name[0] + "Hid_Type").value = 2;
            }
            if (document.getElementById(cont_name[0] + "Check_Incentive").checked == false) {
                document.getElementById(cont_name[0] + "Hid_Type").value = 0;
            }
        }

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function cliclick() {
            if ((document.getElementById(cont_name[0] + "Check_Salary").checked == false) && (document.getElementById(cont_name[0] + "Check_Incentive").checked == false)) {
                alert('Please Select Salary or Incentives !!');
                return false;
            }
            if ((document.getElementById(cont_name[0] + "Check_Confirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false)) {
                alert('Please Select SD Confirmed List Or Not Confirmed List !!');
                return false;
            }
        }
        function CheckConfirmClick() {
            if (document.getElementById(cont_name[0] + "Check_Confirmed").checked == true) {
                document.getElementById(cont_name[0] + "Check_NotConfirmed").checked = false;
                document.getElementById(cont_name[0] + "Hid_SDType").value = 1;
            }
            if ((document.getElementById(cont_name[0] + "Check_Confirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 0;
            }
            if ((document.getElementById(cont_name[0] + "Check_Confirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == true)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 2;
            }
        }
        function CheckNotConfirmClick() {
            if (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == true) {
                document.getElementById(cont_name[0] + "Check_Confirmed").checked = false;
                document.getElementById(cont_name[0] + "Hid_SDType").value = 2;
            }
            if ((document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_Confirmed").checked == false)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 0;
            }
            if ((document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_Confirmed").checked == true)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 1;
            }
        }

        function init() {
            if (document.getElementById(cont_name[0] + "Check_Salary").checked == true) {
                document.getElementById(cont_name[0] + "Check_Incentive").checked = false;
                document.getElementById(cont_name[0] + "Hid_Type").value = 1;
            }
            if (document.getElementById(cont_name[0] + "Check_Incentive").checked == true) {
                document.getElementById(cont_name[0] + "Check_Salary").checked = false;
                document.getElementById(cont_name[0] + "Hid_Type").value = 2;
            }

            if (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == true) {
                document.getElementById(cont_name[0] + "Check_Confirmed").checked = false;
                document.getElementById(cont_name[0] + "Hid_SDType").value = 2;
            }
            if ((document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_Confirmed").checked == false)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 0;
            }
            if ((document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_Confirmed").checked == true)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 1;
            }

            if (document.getElementById(cont_name[0] + "Check_Confirmed").checked == true) {
                document.getElementById(cont_name[0] + "Check_NotConfirmed").checked = false;
                document.getElementById(cont_name[0] + "Hid_SDType").value = 1;
            }
            if ((document.getElementById(cont_name[0] + "Check_Confirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == false)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 0;
            }
            if ((document.getElementById(cont_name[0] + "Check_Confirmed").checked == false) && (document.getElementById(cont_name[0] + "Check_NotConfirmed").checked == true)) {
                document.getElementById(cont_name[0] + "Hid_SDType").value = 2;
            }
        }
        window.onload = init;

        // ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <br />
            <br />
            <div style="text-align: center">
                &nbsp;
            </div>
            <div style="text-align: center">
                &nbsp;
            </div>
            <div style="text-align: center">
                <table border="1">
                    <tr>
                        <td rowspan="3" style="width: 132px; text-align: left">
                            <div style="text-align: left">
                                <table>
                                    <tr>
                                        <td style="width: 10px">
                                            <input id="Check_Salary" type="checkbox" onclick="return Check_Salary_onclick()" runat="server" style="cursor: hand" /></td>
                                        <td style="width: 152px">
                                            <strong>Salary</strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10px">
                                            <input id="Check_Incentive" type="checkbox" onclick="return Check_Incentive_onclick()" runat="server" style="cursor: hand" tabindex="1" /></td>
                                        <td style="width: 152px">
                                            <strong>Incentives</strong></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td rowspan="3" style="width: 173px; text-align: left">
                            <div style="text-align: left">
                                <table>
                                    <tr>
                                        <td style="width: 13px">
                                            <input id="Check_Confirmed" type="checkbox" onclick="CheckConfirmClick()" runat="server" /></td>
                                        <td style="width: 143px">
                                            <strong>SD Confirmed</strong></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px">
                                            <input id="Check_NotConfirmed" type="checkbox" onclick="CheckNotConfirmClick()" runat="server" /></td>
                                        <td style="width: 143px">
                                            <strong>SD Not Confirmed</strong></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td rowspan="3" style="width: 412px; text-align: left">
                            <div style="text-align: left">
                                <table>
                                    <tr>
                                        <td colspan="1" style="width: 268px">&nbsp; <strong>Select Department :</strong></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="Cmb_Department" runat="server" Width="252px" Style="cursor: hand" TabIndex="2">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 268px; text-align: left"></td>
                                        <td colspan="2" style="text-align: left">
                                            <div style="text-align: left">
                                                <table style="width: 67px">
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <input id="Cmd_Exit" type="button" value="EXIT" style="width: 84px; cursor: hand;" onclick="return Cmd_Exit_onclick()" tabindex="3" /></td>
                                                        <td style="width: 59546px">
                                                            <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Style="cursor: hand" TabIndex="4" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="Hid_Type" runat="server" Value="0" />
            <asp:HiddenField ID="Hid_SDType" runat="server" Value="0" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

