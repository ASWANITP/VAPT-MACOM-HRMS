<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Compenastory_assign.aspx.vb" Inherits="WebAppHRMS.Compenastory_assign_5a9845185764" Title="Untitled Page" EnableEventValidation="true" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        var cont_name = master_no.split("txt")



        function OnkeyUpChqDate(Control) {
            if (document.getElementById(cont[0] + Control).value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
            }
        }



        function checkDt() {

            dateFrom = document.getElementById(cont_name[0] + "txt_Compdate").value;
            checkDate(dateFrom)
        }
        function returnFalse() {
            return false;
        }
        function checkDate(dateFrom) {
            var day1, day2;
            var month1, month2;
            var year1, year2;

            var dt = new Date().format("dd/MMM/yyyy");
            var value3 = dt;

            if (dateFrom == "") {
                dateFrom = new Date().format("dd/MMM/yyyy");
            }

            value1 = dateFrom;


            day1 = value1.substring(0, value1.indexOf("/"));
            month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
            year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

            day2 = value3.substring(0, value3.indexOf("/"));
            month2 = value3.substring(value3.indexOf("/") + 1, value3.lastIndexOf("/"));
            year2 = value3.substring(value3.lastIndexOf("/") + 1, value3.length);

            date1 = year1 + "/" + month1 + "/" + day1;
            date2 = year2 + "/" + month2 + "/" + day2;


            firstDate = Date.parse(date1)
            secondDate = Date.parse(date2)

            msPerDay = 24 * 60 * 60 * 1000

            if (firstDate.valueOf() >= secondDate.valueOf()) {
                alert("Compensatory Can't be Assigned on future date !");
                document.getElementById(cont_name[0] + "txt_Compdate").value = "";
                return false;
            }
            else {

                return true;
            }

        }

        function confirmonclick() {
            var com_dat = document.getElementById(cont_name[0] + "txt_Compdate").value;
            var stat = document.getElementById(cont_name[0] + "dplState").value;

            if (document.getElementById(cont_name[0] + "txt_compname").value == "") {
                alert("Please enter compensatory name");
                return false;
            }

            else if (com_dat == "") {
                alert("Please Select From date");
                return false;
            }
            else if (stat == "-1") {
                alert("Please Select state ");
                return false;
            }

        }
        function preventBackspace(e) {
            var evt = e || window.event;
            if (evt) {
                var keyCode = evt.charCode || evt.keyCode;
                if (keyCode === 8) {
                    if (evt.preventDefault) {
                        evt.preventDefault();
                    } else {
                        evt.returnValue = false;
                    }
                }
            }
        }
        // ]]>

        function validate(key) {

            var keycode = (key.which) ? key.which : key.keyCode;
            if (!(keycode == 8 || keycode == 32 || keycode == 40 || keycode == 41 || keycode == 45 || keycode == 47) && (keycode < 48 || keycode > 57) && (keycode < 65 || keycode > 90) && (keycode < 97 || keycode > 122)) {
                return false;
            }
        }
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 630px; height: 80px">
            <tr>
                <td align="center" colspan="2" style="height: 6px">
                    <span>ADD COMPENSATORY </span></td>
            </tr>
            <tr>
                <td align="center" style="width: 279px; text-align: right; height: 28px;">Compensatory Name &nbsp;
                </td>
                <td align="center" style="width: 149px; text-align: center; height: 28px;">
                    <asp:TextBox ID="txt_compname" runat="server" Width="280px" onkeypress="return validate(event)" onpaste="return false"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="text-align: right; height: 28px; width: 279px;">Compensatory Date &nbsp;
                </td>
                <td align="center" style="width: 149px; text-align: left; height: 28px;">
                    <asp:TextBox ID="txt_Compdate" runat="server" Width="168px" onkeypress="return false" onPaste="return false" onKeyDown="return preventBackspace()"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="width: 279px; height: 28px; text-align: right">State &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
                <td align="center" style="width: 149px; height: 28px; text-align: left">
                    <asp:DropDownList ID="dplState" runat="server" Width="176px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" style="text-align: right; width: 279px; height: 1px;">Punching Status &nbsp;
                </td>
                <td align="center" style="width: 149px; text-align: left; height: 1px;">
                    <asp:DropDownList ID="dplPunchStat" runat="server" Width="176px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" style="text-align: right; width: 279px;">
                    <asp:Button ID="btn_cancel" runat="server" Text="EXIT" Width="96px" />
                    &nbsp;
                </td>
                <td align="center" style="width: 149px; text-align: left">&nbsp;
                    <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" Width="96px" OnClientClick="return confirmonclick()" /></td>
            </tr>
            <tr>
                <td align="center" style="height: 12px" colspan="2">&nbsp;<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_Compdate"></cc1:CalendarExtender>
                    <asp:HiddenField ID="hdn_state" runat="server" />
                    <asp:HiddenField ID="hdn_punchstat" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

