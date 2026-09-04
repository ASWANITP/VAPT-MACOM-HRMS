<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="transfer_report.aspx.vb" Inherits="WebAppHRMS.transferreport_transfer_report_a9d301e76240" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var contname = header.split('txt');

        function van() {
            alert("Please select date from calendar! ")
            return false;
        }

        function Validate() {
            if (document.getElementById(contname[0] + "txtEmpcode").value != "") {
                ToServer(document.getElementById(contname[0] + "txtEmpcode").value, 1);
                return false;
            }

        }

        function FromServer(arg, context) {
            var res = arg.split('@')
            document.getElementById(contname[0] + "lblname").innerText = res[1];

            if (res[0] == 0) {
                alert('Invalid employee code');
                document.getElementById(contname[0] + "txtEmpcode").value = "";
                document.getElementById(contname[0] + "txtEmpcode").focus();
                return false;
            }

        }

        function CheckEmpty() {
            if (document.getElementById(contname[0] + "txtEmpcode").value == "") {
                alert('Please enter employee code');
                document.getElementById(contname[0] + "txtEmpcode").focus();
                return false;
            }

        }

        // ]]>
    </script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 518px; background-color: transparent">
            <tr>
                <td colspan="2" style="height: 23px; background-color: #ffffcc">
                    <strong><span style="font-size: 14pt; color: #660000">EMPLOYEE TRANSFER DETAILS</span></strong></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">&nbsp;<%--<cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="cmb_select"></cc1:listsearchextender>--%>
                    <table border="1" style="width: 518px">
                        <tr>
                            <td style="width: 30%" align="left">EMPLOYEE CODE</td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="txtEmpcode" Width="90%" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 50%" align="left">&nbsp;<asp:Label ID="lblname" runat="server" ForeColor="maroon"></asp:Label></td>
                        </tr>
                    </table>
                    <div style="text-align: center">
                        <table style="width: 518px">
                            <tr>
                                <td style="width: 100px; height: 21px">FROM DATE</td>
                                <td style="width: 100px; height: 21px">
                                    <asp:TextBox ID="Txt_fdt" onkeypress="return van()" runat="server"></asp:TextBox></td>
                                <td style="width: 100px; height: 21px">TO DATE</td>
                                <td style="width: 100px; height: 21px">
                                    <asp:TextBox ID="Txt_tdt" onkeypress="return van()" runat="server" CausesValidation="True"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_fdt"></cc1:CalendarExtender>
                    &nbsp;
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_tdt"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <div style="text-align: center">
                        <table style="width: 504px">
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm" OnClientClick="javascript:return CheckEmpty()" runat="server" Text="CONFIRM" Width="87px" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="83px" /></td>
                                <td style="width: 100px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
</asp:Content>

