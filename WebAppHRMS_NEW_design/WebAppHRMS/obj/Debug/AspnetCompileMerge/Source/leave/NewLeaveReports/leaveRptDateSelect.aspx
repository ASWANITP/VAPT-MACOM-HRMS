<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leaveRptDateSelect.aspx.vb" Inherits="WebAppHRMS.leaveRptDateSelect_63e46aaf7405" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function correct(a, e) {

            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()

        }

        document.addEventListener("DOMContentLoaded", function () {
            var textBox = document.getElementById('<%= TextBox2.ClientID %>');

            // Prevent manual typing of alphabets and numbers
            textBox.addEventListener('keypress', function (event) {
                event.preventDefault(); // Block user input
            });


            function OnClientDateSelection(sender, args) {
                var selectedDate = args.get_selectedDate().format('dd/MMM/yyyy');
                textBox.value = selectedDate;
            }
        });

        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table style="border-right: darkslategray 1px outset; table-layout: fixed; border-top: darkslategray 1px outset; border-left: darkslategray 1px outset; width: 500px; border-bottom: darkslategray 1px outset; border-collapse: separate; height: auto">
            <tr style="height: 30px;">
                <td colspan="2" style="background-color: #5d7b9d; color: white;">&nbsp;<strong>DAILY&nbsp; LEAVE&nbsp; STATUS&nbsp; REPORT</strong></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>SELECT DATE</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" onkeyup="return correct('TextBox2',event)" Width="139px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 28px"></td>
                <td style="height: 28px">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="121px" /></td>
                <td style="text-align: left">
                    <asp:Button ID="Button2" runat="server" Text="EXIT" Width="133px" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        &nbsp;
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

