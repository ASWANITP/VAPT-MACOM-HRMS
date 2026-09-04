<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_report.aspx.vb" Inherits="WebAppHRMS.Emp_Master_Data_emp_report_9a03365d6661" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <![CDATA[
        function correct(a, e) {
            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()
        }
        // ]]>
        window.onload = function () {
            window_onload();
        };

        function Button2_Click() {
            window.open("../../../home.aspx", '_self')
        }
       
        document.addEventListener("DOMContentLoaded", function () {
            var textBox = document.getElementById('<%= TextBox1.ClientID %>');

            // Prevent manual typing of alphabets and numbers
            textBox.addEventListener('keypress', function (event) {
                event.preventDefault(); // Block user input
            });

            
            function OnClientDateSelection(sender, args) {
                var selectedDate = args.get_selectedDate().format('dd/MMM/yyyy');
                textBox.value = selectedDate; 
            }
        });



        function window_onload() {
            debugger;
            document.getElementById("jio").innerHTML = "<img src='esp.gif' alt='gif image' />";
            ToServer(1, 1);
            return false;
        }

        function FromServer(arg, context) {
            debugger;
            document.getElementById("jio").innerHTML = arg;
        }

        function passpage(code, pin) {
            debugger;
            window.open("masterpiece.aspx?code=" + code + "&pin=" + pin, "_self");
        }

        function passpage1(code) {
            debugger;
            window.open("allow_split.aspx?code=" + code, "_self");
        }

        function passpage2(code) {
            debugger;
            window.open("tlmgr.aspx?code=" + code, "_self");
        }
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 731px; height: 217px; margin: auto;">
            <tr>
                <td colspan="2">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <strong style="background-color: #ffcc33">
                        <span style="font-size: 14pt">DATE WISE EMPLOYEE MASTER REPORT</span>
                    </strong>
                </td>
            </tr>
            <tr>

                <td style="width: 100px; height: 39px; text-align: center">DATE</td>
                <td colspan="2" style="height: 42px; text-align: center">
                    <asp:TextBox ID="TextBox1" runat="server" Width="225px"  Placeholder="Select Date"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="CONFIRM" Width="121px" />
                    &nbsp;&nbsp;
<%--                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="EXIT" Width="133px" />--%>
                    <Button ID="Button2" type="button"  style="Width:121px;" OnClick="Button2_Click()" >EXIT</button>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
