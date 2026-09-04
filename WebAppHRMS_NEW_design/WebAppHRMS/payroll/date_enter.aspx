<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="date_enter.aspx.vb" Inherits="WebAppHRMS.specificempattend_atterepo_f4f6fb1e7482" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont = loanno.split('txt');
        function KeyUps(a) {
            debugger;
            alert('Please Select Date Using Calendar..!!!');
            document.getElementById(cont[0] + a).value = document.getElementById(cont[0] + "hidLeaveFrom").value;
            document.getElementById(cont[0] + a).text = "";
            document.getElementById(cont[0] + a).focus();
            return false;
        }
        function KeyUps1(a) {
            alert('Please Select Date Using Calendar..!!');
            document.getElementById(cont[0] + a).value = document.getElementById(cont[0] + "hidLeaveFrom").value;
            document.getElementById(cont[0] + a).focus();
            return false;
        }
        function Fill_Dateto() {
            var day1, day2, day3;
            var month1, month2, month3;
            var year1, year2, year3;
            if ((document.getElementById(cont[0] + "txtLeaveToDate").value != "") && (document.getElementById(cont[0] + "txtLeaveFrom").value != "")) {
                value1 = document.getElementById(cont[0] + "txtLeaveFrom").value;
                value2 = document.getElementById(cont[0] + "txtLeaveToDate").value;

                day1 = value1.substring(0, value1.indexOf("/"));
                month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                day2 = value2.substring(0, value2.indexOf("/"));
                month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                date1 = year1 + "/" + month1 + "/" + day1;
                date2 = year2 + "/" + month2 + "/" + day2;
                //date3 = year3+"/"+month3+"/"+day3;

                firstDate = Date.parse(date1);
                secondDate = Date.parse(date2);
                //thirdDate = Date.parse(date3);            

                msPerDay = 24 * 60 * 60 * 1000;

                dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                if (dbd < 0) {
                    alert("Wrong Entry..!! Your FromDate Greater than ToDate.. Please Change..!!")
                    document.getElementById(cont[0] + "txtLeaveFrom").value = document.getElementById(cont[0] + "hidLeaveFrom").value;
                    document.getElementById(cont[0] + "txtLeaveToDate").value = document.getElementById(cont[0] + "hidLeaveTo").value;
                    document.getElementById(cont[0] + "txtLeaveFrom").focus();
                    return false;
                }
            }
        }
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 360px; height: 144px">
            <tr>
                <td colspan="4" style="height: 49px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <strong style="background-color: #ffcc33"><span style="font-size: 14pt">EMPLPOYEE DETAILS&nbsp;</span></strong></td>
            </tr>
            <tr>
                <td style="width: 324px; height: 39px; text-align: center;">FOR THE DATE</td>
                <td style="width: 100px; height: 39px">
                    <%--<asp:TextBox ID="from_dt" runat="server" onkeyup="return KeyUps('from_dt')" onchange="Fill_Dateto()"></asp:TextBox>
                    --%>
                    <asp:TextBox ID="txtLeaveFrom" onkeyup="return KeyUps('txtLeaveFrom')" onchange="Fill_Dateto()" runat="server" Style="font-family: 'Bookman Old Style'; text-align: center"
                        Width="152px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLeaveFrom" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 44px">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="121px" />
                    &nbsp;<asp:Button ID="Button2" runat="server" Text="EXIT" Width="133px" /></td>
                <input id="hidLeaveFrom" runat="server" style="width: 12px" type="hidden" />
            </tr>
        </table>
    </div>
</asp:Content>

