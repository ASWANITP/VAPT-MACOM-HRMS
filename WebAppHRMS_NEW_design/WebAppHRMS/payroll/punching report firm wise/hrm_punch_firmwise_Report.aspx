<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_punch_firmwise_Report.aspx.vb" Inherits="WebAppHRMS.hrm_punch_firmwise_Report_a92882ea8526" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('txt');

        function DateCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(con[0] + "txtDate").value = "";
            return false;
        }
        function checkFdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(con[0] + Control).value != "") {
                var value1 = document.getElementById(con[0] + Control).value;
                var dt = new Date().format("dd/MMM/yyyy");
                var value2 = dt;

                day1 = value1.substring(0, value1.indexOf("/"));
                month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                day2 = value2.substring(0, value2.indexOf("/"));
                month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                date1 = year1 + "/" + month1 + "/" + day1;
                date2 = year2 + "/" + month2 + "/" + day2;

                firstDate = Date.parse(date1)
                secondDate = Date.parse(date2)

                msPerDay = 24 * 60 * 60 * 1000

                dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                if (dbd < 0) {
                    alert("Please Do Not Enter Future Date ..!!")
                    document.getElementById(con[0] + Control).value = '';
                    document.getElementById(con[0] + Control).focus();
                    return false;
                }
            }
        }
        function ddlFirmChange() {
            document.getElementById(con[0] + "hdnFirm").value = document.getElementById(con[0] + "ddlFirm").value;
        }
        function OnclickConfirm() {
            if (document.getElementById(con[0] + "ddlFirm").value == -1) {
                alert("Please Select Firm...!");
                document.getElementById(con[0] + "ddlFirm").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtDate").value == "") {
                alert("Please Select the Date....!");
                document.getElementById(con[0] + "txtDate").focus();
                return false;
            }
        }
        function btnExit_onclick() {
            window.open("../../Home.aspx", "_self");
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txtDate"></cc1:CalendarExtender>
        <asp:HiddenField ID="hdnFirm" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Select Firm</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlFirm" runat="server" Width="98%" onchange="ddlFirmChange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Select Date For Month</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="80%" onkeyup="DateCheck()" onblur="checkFdate('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return OnclickConfirm()" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

