<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_ResigTermi_DtChange.aspx.vb" Inherits="WebAppHRMS.Resig_Termi_Date_Change_hrm_ResigTermi_DtChange_c6e950528361" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>
    <script language="javascript" type="text/javascript">
        var con = header.split('txt');

        function btnExit_onclick() {
            window.open("../../Home.aspx", "_self");
        }
        function detailDisplay() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtPost").value = "";
                document.getElementById(con[0] + "txtDes").value = "";
                document.getElementById(con[0] + "txtRdate").value = "";
                document.getElementById(con[0] + "txtAdate").value = "";
                document.getElementById(con[0] + "hidTermiDate").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value != "") {
                callserver("1$" + document.getElementById(con[0] + "txtEcode").value, 1);
            }
        }
        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
        }
        function call_receiver(arg, context) {
            //debugger;
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Enter Resigned/Terminated Employee Code");
                            document.getElementById(con[0] + "txtEcode").value = "";
                            document.getElementById(con[0] + "txtEname").value = "";
                            document.getElementById(con[0] + "txtPost").value = "";
                            document.getElementById(con[0] + "txtDes").value = "";
                            document.getElementById(con[0] + "txtRdate").value = "";
                            document.getElementById(con[0] + "txtAdate").value = "";
                            document.getElementById(con[0] + "hidTermiDate").value = "";
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txtEname").value = accdtl[0];
                            document.getElementById(con[0] + "txtPost").value = accdtl[1];
                            document.getElementById(con[0] + "txtDes").value = accdtl[2];
                            document.getElementById(con[0] + "txtRdate").value = accdtl[3];
                            document.getElementById(con[0] + "hidTermiDate").value = accdtl[3];
                        }
                        break;
                    }
            }
        }
        function DateCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(con[0] + "txtAdate").value = "";
            return false;
        }
        function check_date(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(con[0] + Control).value != "") {
                var value1 = document.getElementById(con[0] + Control).value;
                var dt = document.getElementById(con[0] + "txtRdate").value;
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
                    alert("Please Do Not Enter Date Greater than Resig/Termi date..!!")
                    document.getElementById(con[0] + Control).value = '';
                    document.getElementById(con[0] + Control).focus();
                    return false;
                }
                if (document.getElementById(con[0] + "txtRdate").value == "") {
                    alert("Enter Employee Code");
                    document.getElementById(con[0] + "txtAdate").value = "";
                    return false;
                }
            }
        }
        function window_onload() {
            document.getElementById(con[0] + "txtEcode").focus();
            document.getElementById(con[0] + "hidTermiDate").value = "";
        }
        function ConfOnClick() {
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert("Please Enter Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtAdate").value == "") {
                alert("Please Select Actual Terminated/Resigned Date");
                document.getElementById(con[0] + "txtAdate").focus();
                return false;
            }
            if (document.getElementById(con[0] + "hidTermiDate").value == "") {
                alert("Please Enter Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
        }
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtAdate"></cc1:CalendarExtender>
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2">Enter Employee Code</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtEcode" runat="server" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="6" Width="60%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">&nbsp;Emp. Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEname" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                <td style="width: 15%">Post</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtPost" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">Designation
                </td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtDes" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                <td style="width: 15%">Resi/Termi. Date</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtRdate" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Actual Terminated/Resigned Date</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtAdate" runat="server" onkeyup="DateCheck()" onchange="check_date('txtAdate')" Width="65%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px">
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConfOnClick()" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%; height: 23px"></td>
                <td style="width: 15%; height: 23px"></td>
                <td style="width: 15%; height: 23px"></td>
                <td style="width: 15%; height: 23px"></td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidTermiDate" runat="server" />
</asp:Content>

