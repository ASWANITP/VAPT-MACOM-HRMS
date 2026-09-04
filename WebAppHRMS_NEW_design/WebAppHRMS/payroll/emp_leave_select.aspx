<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_leave_select.aspx.vb" Inherits="WebAppHRMS.Leave_Details_emp_leave_select_7d01b3032265" Title="Empwise Leave Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = sal.split('Txt');
        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function date(a) {
            alert('Please select date from Calendar by clicking on the Date Box.\nYou Cannot enter date by Typing !!');
            document.getElementById(cont_name[0] + a).value = "";
            document.getElementById(cont_name[0] + a).focus();
            return false;
        }

        function cliclick() {
            if (document.getElementById(cont_name[0] + "Txt_From").value == "") {
                alert('Please Enter From Date !!');
                document.getElementById(cont_name[0] + "Txt_From").focus();
                return false;
            }
            if (document.getElementById(cont_name[0] + "Txt_to").value == "") {
                alert('Please Enter To Date!!');
                document.getElementById(cont_name[0] + "Txt_to").focus();
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1">
            <tr>
                <td style="width: 122px; text-align: left">
                    <strong>Select Employee:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="Cmb_Employee" runat="server" Width="208px">
                    </asp:DropDownList></td>
                <td style="width: 153px; text-align: left">
                    <strong>Select Leave Type:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="Cmb_Leave" runat="server" Width="144px">
                        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Casual</asp:ListItem>
                        <asp:ListItem Value="2">Sick</asp:ListItem>
                        <asp:ListItem Value="3">Earned</asp:ListItem>
                        <asp:ListItem Value="4">L.O.P</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 122px; text-align: left">
                    <strong>From Date:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_From" onkeyup="date('Txt_From')" runat="server" Width="127px"></asp:TextBox></td>
                <td style="width: 153px; text-align: left">
                    <strong>To Date:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_to" onkeyup="date('Txt_to')" runat="server" Width="139px"></asp:TextBox></td>
            </tr>
        </table>
        <div style="text-align: center">
            <table style="width: 148px">
                <tr>
                    <td style="width: 61px; text-align: right; height: 7px;">
                        <input id="Cmd_Exit" type="button" value="EXIT" style="width: 71px" onclick="return Cmd_Exit_onclick()" /></td>
                    <td style="width: 105px; text-align: left; height: 7px;">
                        <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="71px" /></td>
                </tr>
            </table>
            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_Employee">
            </cc1:ListSearchExtender>
        </div>
        <cc1:CalendarExtender ID="CalendarExt_From" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_From"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExt_To" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_to"></cc1:CalendarExtender>
    </div>

    <br />
    <br />
</asp:Content>

