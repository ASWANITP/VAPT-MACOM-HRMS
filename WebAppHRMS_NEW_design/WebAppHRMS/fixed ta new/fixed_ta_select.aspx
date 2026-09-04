<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="fixed_ta_select.aspx.vb" Inherits="WebAppHRMS.fixed_TA_New_fixed_ta_select_15a025474773" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = loanno.split('check');

        function cmdExit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function init() {
            document.getElementById(cont[0] + "check_Area").checked = false;
            document.getElementById(cont[0] + "check_BH").checked = false;
            document.getElementById(cont[0] + "check_Others").checked = false;
            document.getElementById(cont[0] + "check_Special").checked = false;
            document.getElementById(cont[0] + "check_Employee").checked = false;
        }
        window.onload = init;

        function funccheckArea() {
            document.getElementById(cont[0] + "check_BH").checked = false;
            document.getElementById(cont[0] + "check_Others").checked = false;
            document.getElementById(cont[0] + "check_Special").checked = false;
            document.getElementById(cont[0] + "check_Employee").checked = false;
        }
        function funccheckBH() {
            if (document.getElementById(cont[0] + "check_BH").checked == true) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_Others").checked = false;
                document.getElementById(cont[0] + "check_Special").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
            if (document.getElementById(cont[0] + "check_BH").checked == false) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_Others").checked = false;
                document.getElementById(cont[0] + "check_Special").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
        }
        function funccheckOthers() {
            if (document.getElementById(cont[0] + "check_Others").checked == true) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_BH").checked = false;
                document.getElementById(cont[0] + "check_Special").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
            if (document.getElementById(cont[0] + "check_Others").checked == false) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_BH").checked = false;
                document.getElementById(cont[0] + "check_Special").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
        }
        function funccheckSpecial() {
            if (document.getElementById(cont[0] + "check_Special").checked == true) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_BH").checked = false;
                document.getElementById(cont[0] + "check_Others").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
            if (document.getElementById(cont[0] + "check_Special").checked == false) {
                document.getElementById(cont[0] + "check_Area").checked = false;
                document.getElementById(cont[0] + "check_BH").checked = false;
                document.getElementById(cont[0] + "check_Others").checked = false;
                document.getElementById(cont[0] + "check_Employee").checked = false;
            }
        }
        function funccheckEmployee() {
            document.getElementById(cont[0] + "check_Area").checked = false;
            document.getElementById(cont[0] + "check_BH").checked = false;
            document.getElementById(cont[0] + "check_Others").checked = false;
            document.getElementById(cont[0] + "check_Special").checked = false;
        }
        function oncliclick() {
            if (document.getElementById(cont[0] + "check_Others").checked == false && document.getElementById(cont[0] + "check_BH").checked == false && document.getElementById(cont[0] + "check_Area").checked == false && document.getElementById(cont[0] + "check_Special").checked == false && document.getElementById(cont[0] + "check_Employee").checked == false) {
                alert('Please Select any of the above Options and then CONFIRM..!!');
                return false;
            }
            else {
                if (document.getElementById(cont[0] + "check_Area").checked == true) {
                    window.open('areawise.aspx', '_self');
                }
                if (document.getElementById(cont[0] + "check_BH").checked == true) {
                    window.open('branchwise.aspx', '_self');
                }
                if (document.getElementById(cont[0] + "check_Others").checked == true) {
                    window.open('taothersall.aspx', '_self');
                }
                if (document.getElementById(cont[0] + "check_Special").checked == true) {
                    window.open('taspecial.aspx', '_self');
                }
                if (document.getElementById(cont[0] + "check_Employee").checked == true) {
                    window.open('empwisetotal.aspx', '_self');
                }
            }
        }
        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <div style="text-align: center">
            <table border="1" style="font-family: 'Courier New'">
                <tr>
                    <td style="width: 100px; text-align: left">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Select Fixed TA Report"
                            Width="278px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 146px;">
                        <table style="font-family: 'Courier New'">
                            <tr>
                                <td style="width: 100px; height: 22px; text-align: left">
                                    <asp:CheckBox ID="check_Area" runat="server" onclick="funccheckArea()" Style="cursor: hand; font-family: 'Courier New'"
                                        Text=" Area Manager(G) " Width="279px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left">
                                    <asp:CheckBox ID="check_BH" runat="server" onclick="funccheckBH()" Style="cursor: hand; font-family: 'Courier New'"
                                        Text=" BH (G) " Width="207px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left">
                                    <asp:CheckBox ID="check_Others" runat="server" onclick="funccheckOthers()" Style="cursor: hand; font-family: 'Courier New'"
                                        Text=" Others" Width="191px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left">
                                    <asp:CheckBox ID="check_Special" runat="server" onclick="funccheckSpecial()" Style="cursor: hand; font-family: 'Courier New'"
                                        Text=" Special Employees" Width="239px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left">
                                    <asp:CheckBox ID="check_Employee" runat="server" onclick="funccheckEmployee()" Style="cursor: hand; font-family: 'Courier New'"
                                        Text=" Employee Total" Width="248px" Font-Bold="False" Font-Italic="True" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="width: 100px; text-align: center;">
                        <table style="width: 284px">
                            <tr>
                                <td style="width: 100px; text-align: right; height: 26px;">
                                    <input id="cmdConfirm" onclick="return oncliclick()" style="width: 88px; cursor: hand; font-family: 'Courier New'"
                                        type="button" value="CONFIRM" /></td>
                                <td style="width: 100px; text-align: left; height: 26px;">
                                    <input id="Button1" style="width: 88px; cursor: hand; font-family: 'Courier New'"
                                        type="button" value="EXIT" onclick="return cmdExit_onclick()" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>

