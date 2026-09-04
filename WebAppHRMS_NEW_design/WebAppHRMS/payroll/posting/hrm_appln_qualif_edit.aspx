<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_appln_qualif_edit.aspx.vb" Inherits="WebAppHRMS.Qualification_Addition_hrm_qualification_edit_617290ae5796" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
   
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = header.split('txt');

        function window_onload() {
            document.getElementById(cont[0] + "ddlQual").value = -1;
            document.getElementById("rowExPanel").style.display = "none";
            document.getElementById("rowQuPanel").style.display = "none";
            call_server("1$" + document.getElementById(cont[0] + "txtAppno").value, 1);
        }

        function call_receiver(arg) {
            var ap;
            ap = arg.split("@");
            if (ap[0] != '') {
                document.getElementById("rowQuPanel").style.display = "table-row";
                document.getElementById(cont[0] + "hidden1").value = ap[0];
                disp();
            }
            if (ap[1] != '') {
                document.getElementById("rowExPanel").style.display = "table-row";
                document.getElementById(cont[0] + "hidden2").value = ap[1];
                disp1();
            }
        }

        function disp() {
            var st, st3, st1, tot, st2;
            st1 = '';
            tot = '';
            st = '';
            if (document.getElementById(cont[0] + "hidden1").value != '') {
                st2 = document.getElementById(cont[0] + "hidden1").value.split("!");
                for (m = 0; m < st2.length - 1; m++) {
                    st3 = st2[m].split("*")
                    st1 = st1 + "<tr><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><small>" + st3[5] + "</td><td><small>" + st3[6] + "</td><td width=4% align=right style= 'font-size: 10pt;'><a href=javascript:delf(" + m + ")>Del</a></td></tr>"

                }
                st = st + "<table id='mytable' border='1'  width='100%' ><tr ><td><small><b>&nbsp;&nbsp;&nbsp;Qualification&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;Institute&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;University&nbsp;&nbsp;&nbsp;</b></td><td><small><b>Mark(%)</b></td><td><small><b>Year Pass</b></td><td><small><b>&nbsp;&nbsp;&nbsp;DELETE&nbsp;&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById(cont[0] + "Panel1").innerHTML = st1;
                document.getElementById("rowQuPanel").style.display = "table-row";
            }
            else {
                document.getElementById("rowQuPanel").style.display = "none";
            }
        }


        function disp1() {
            var st, st3, st1, tot, st2;
            st1 = '';
            tot = '';
            st = '';
            if (document.getElementById(cont[0] + "hidden2").value != '') {
                st2 = document.getElementById(cont[0] + "hidden2").value.split("!");
                for (m = 0; m < st2.length - 1; m++) {
                    st3 = st2[m].split("*")
                    st1 = st1 + "<tr><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><small>" + st3[5] + "</td><td><small>" + st3[6] + "</td><td><small>" + st3[7] + "</td><td><small>" + st3[8] + "</td><td><small>" + st3[9] + "</td><td width=4% align=right style= 'font-size: 10pt;'><a href=javascript:del(" + m + ")>Del</a></td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='100%' ><tr ><td><small><b>Organisation</b></td><td><small><b>&nbsp;&nbsp;&nbsp;Designation&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;From Date&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;To Date&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;Nature Of Duty&nbsp;&nbsp;&nbsp;</b></td><td><small><b>Contact Person</b></td><td><small><b>Contact Phone</b></td><td><small><b>Releiving Reaon</b></td><td><small><b>Salary</b></td><td><small><b>&nbsp;&nbsp;&nbsp;DELETE&nbsp;&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById(cont[0] + "Panel2").innerHTML = st1;
                document.getElementById("rowExPanel").style.display = "table-row";
            }
            else {
                document.getElementById("rowExPanel").style.display = "none";
            }
        }

        function delf(m) {
            var j = m, k
            var new_tran = ""
            var new_tran1 = ""
            var arr = document.getElementById(cont[0] + "hidden1").value.split("!")
            for (k = 0; k < j; k++) {
                new_tran = new_tran + arr[k] + "!"
            }
            for (k = j + 1; k < arr.length - 1; k++) {
                new_tran = new_tran + arr[k] + "!"
            }
            document.getElementById(cont[0] + "hidden1").value = new_tran;
            disp()
        }

        function del(m) {
            var j = m, k
            var new_tran = ""
            var new_tran1 = ""
            var arr = document.getElementById(cont[0] + "hidden2").value.split("!")
            for (k = 0; k < j; k++) {
                new_tran = new_tran + arr[k] + "!"
            }
            for (k = j + 1; k < arr.length - 1; k++) {
                new_tran = new_tran + arr[k] + "!"
            }
            document.getElementById(cont[0] + "hidden2").value = new_tran;
            disp1()
        }

        function btnAdd_onclick() {
            debugger;

            if (document.getElementById(cont[0] + "hdnQual").value == -1) {
                alert('Please Select Qualification..!!');
                document.getElementById(cont[0] + "ddlQual").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtInist").value == "") {
                alert('Please Enter Institution..!!');
                document.getElementById(cont[0] + "txtInist").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtUni").value == "") {
                alert('Please Enter University..!!');
                document.getElementById(cont[0] + "txtUni").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtMark").value == "") {
                alert('Please Enter Persentage of Mark..!!');
                document.getElementById(cont[0] + "txtMark").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtYpass").value == "") {
                alert('Please Enter Year of Pass..!!');
                document.getElementById(cont[0] + "txtYpass").focus();
                return false;
            }

            if (document.getElementById(cont[0] + "hidden1").value)
            //if (document.addEventListener("DOMContentLoaded", function () {
            //    document.getElementById(cont[0] + "hidden1").value != ""

            //}); 
            {
                var appno = document.getElementById(cont[0] + "txtAppno").value;
                var qual = document.getElementById(cont[0] + "ddlQual").value;

                var data = document.getElementById(cont[0] + "hidden1").value;
                //document.addEventListener("DOMContentLoaded", function () {
                //    var data = document.getElementById(cont[0] + "hidden1");

                //});

                var rows = data.split("!");
                for (i = 0; i <= rows.length - 1; i++) {
                    cols = rows[i].split("*");
                    if (cols[8] == qual) {
                        alert('Already Added..!');
                        document.getElementById(cont[0] + "ddlQual").value = -1;
                        document.getElementById(cont[0] + "txtInist").value = "";
                        document.getElementById(cont[0] + "txtUni").value = "";
                        document.getElementById(cont[0] + "txtMark").value = "";
                        document.getElementById(cont[0] + "txtYpass").value = "";
                        return false;
                    }
                }
                var ddlq = document.getElementById(cont[0] + "ddlQual").options[document.getElementById(cont[0] + "ddlQual").selectedIndex].text
                document.getElementById(cont[0] + "hidden1").value = document.getElementById(cont[0] +
                    "hidden1").value + document.getElementById(cont[0] +
                        "txtAppno").value + "*" + document.getElementById(cont[0] +
                            "txtName").value + "*" + ddlq + "*" + document.getElementById(cont[0] +
                                "txtInist").value + "*" + document.getElementById(cont[0] + "txtUni").value +
                    "*" + document.getElementById(cont[0] + "txtMark").value + "*" +
                    document.getElementById(cont[0] + "txtYpass").value + "**" +
                    document.getElementById(cont[0] + "ddlQual").value + "!";
            }
            disp();
            document.getElementById(cont[0] + "ddlQual").value = -1;
            document.getElementById(cont[0] + "txtInist").value = "";
            document.getElementById(cont[0] + "txtUni").value = "";
            document.getElementById(cont[0] + "txtMark").value = "";
            document.getElementById(cont[0] + "txtYpass").value = "";

        }

        function ClassOnchange() {
            document.getElementById(cont[0] + "hdnQual").value = document.getElementById(cont[0] + "ddlQual").value;
            return false;
        }
        function OnlettCaps(a) {
            var lett = document.getElementById(cont[0] + a).value;
            document.getElementById(cont[0] + a).value = lett.toUpperCase();
        }

        function YearCheck() {
            var a = document.getElementById(cont[0] + "txtYpass").value;
            if (isNaN(a)) {
                alert('Please Enter Year of Pass in Digits..!!');
                document.getElementById(cont[0] + "txtYpass").value = "";
                return false;
            }
        }

        function MarkCheck() {
            var a = document.getElementById(cont[0] + "txtMark").value;
            if (isNaN(a)) {
                alert('Please Enter Year of Pass in Digits..!!');
                document.getElementById(cont[0] + "txtMark").value = "";
                return false;
            }
        }

        function btnClear_onclick() {
            document.getElementById(cont[0] + "ddlQual").value = -1;
            document.getElementById(cont[0] + "txtInist").value = "";
            document.getElementById(cont[0] + "txtUni").value = "";
            document.getElementById(cont[0] + "txtMark").value = "";
            document.getElementById(cont[0] + "txtYpass").value = "";
        }

        //function YearLostFocus() {
        //    var a = document.getElementById(cont[0] + "txtYpass").value;
        //    if ((Math.abs(a) < 1900) || (Math.abs(a) > 2020)) {
        //        alert("Please Enter Valid Year...!!");
        //        document.getElementById(cont[0] + "txtYpass").value = "";
        //        document.getElementById(cont[0] + "txtYpass").focus();
        //        return false;
        //    }
        //}
        function YearLostFocus() {
            var a = parseInt(document.getElementById(cont[0] + "txtYpass").value, 10);
            var currentYear = new Date().getFullYear();  // Get the latest year dynamically

            if ((a < 1900) || (a > currentYear)) {
                alert("Please Enter Valid Year...!!");
                document.getElementById(cont[0] + "txtYpass").value = "";
                document.getElementById(cont[0] + "txtYpass").focus();
                return false;
            }
        }


        function DateFCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(cont[0] + "txtFDate").value = "";
            return false;
        }
        function DateTCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(cont[0] + "txtTDate").value = "";
            return false;
        }
        function checkFdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(cont[0] + Control).value != "") {
                var value1 = document.getElementById(cont[0] + Control).value;
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
                    document.getElementById(cont[0] + Control).value = '';
                    document.getElementById(cont[0] + Control).focus();
                    return false;
                }
            }
        }
        function checkTdate(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(cont[0] + Control).value != "") {
                var value1 = document.getElementById(cont[0] + Control).value;
                var dt = new Date().format("dd/MMM/yyyy")
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
                    document.getElementById(cont[0] + Control).value = '';
                    document.getElementById(cont[0] + Control).focus();
                    return false;
                }
                check_frmDt();
            }
        }


        function SalaryCheck() {
            var a = document.getElementById(cont[0] + "txtSalary").value;
            if (isNaN(a)) {
                alert('Please Enter Your Salary in Digits..!!');
                document.getElementById(cont[0] + "txtSalary").value = "";
                return false;
            }
        }

        function phnocheck() {
            var a = document.getElementById(cont[0] + "txtConph").value;
            if (isNaN(a)) {
                alert('Please Enter Your phone number in digits..!!');
                document.getElementById(cont[0] + "txtConph").value = "";
                return false;
            }
        }

        function check_frmDt() {
            var value1 = document.getElementById(cont[0] + "txtFdate").value;
            var value2 = document.getElementById(cont[0] + "txtTdate").value;

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
                alert("Can not Select- From Date Greater than- To Date")
                document.getElementById(cont[0] + "txtFdate").value = ' ';
                document.getElementById(cont[0] + "txtTdate").value = ' ';
                return false;
            }
        }


        function btnEadd_onclick() {
            if (document.getElementById(cont[0] + "txtOrg").value == "") {
                alert('Please Enter Organization..!!');
                document.getElementById(cont[0] + "txtOrg").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtDes").value == "") {
                alert('Please Enter Designation..!!');
                document.getElementById(cont[0] + "txtdes").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtFdate").value == "") {
                alert('Please Select From Date..!!');
                document.getElementById(cont[0] + "txtFdate").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtTdate").value == "") {
                alert('Please Select To Date..!!');
                document.getElementById(cont[0] + "txtTdate").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtDuty").value == "") {
                alert('Please Enter Nature of Duty..!!');
                document.getElementById(cont[0] + "txtDuty").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "txtSalary").value == "") {
                alert('Please Enter Salery Drawn..!!');
                document.getElementById(cont[0] + "txtSalary").focus();
                return false;
            }

            if (document.getElementById(cont[0] + "txtReason").value == "") {
                alert('Please Enter Reason For Leaving..!!');
                document.getElementById(cont[0] + "txtReason").focus();
                return false;
            }
            document.getElementById(cont[0] + "hidden2").value = document.getElementById(cont[0] + "hidden2").value + "*" + document.getElementById(cont[0] + "txtOrg").value + "*" + document.getElementById(cont[0] + "txtDes").value + "*" + document.getElementById(cont[0] + "txtFdate").value + "*" + document.getElementById(cont[0] + "txtTdate").value + "*" + document.getElementById(cont[0] + "txtDuty").value + "*" + document.getElementById(cont[0] + "txtCon").value + "*" + document.getElementById(cont[0] + "txtConph").value + "*" + document.getElementById(cont[0] + "txtReason").value + "*" + document.getElementById(cont[0] + "txtSalary").value + "!";
            disp1();

            document.getElementById(cont[0] + "txtOrg").value = "";
            document.getElementById(cont[0] + "txtDes").value = "";
            document.getElementById(cont[0] + "txtFdate").value = "";
            document.getElementById(cont[0] + "txtTdate").value = "";
            document.getElementById(cont[0] + "txtDuty").value = "";
            document.getElementById(cont[0] + "txtSalary").value = "";
            document.getElementById(cont[0] + "txtCon").value = "";
            document.getElementById(cont[0] + "txtConph").value = "";
            document.getElementById(cont[0] + "txtReason").value = "";
        }


        function btnEclear_onclick() {
            document.getElementById(cont[0] + "txtOrg").value = "";
            document.getElementById(cont[0] + "txtDes").value = "";
            document.getElementById(cont[0] + "txtFdate").value = "";
            document.getElementById(cont[0] + "txtTdate").value = "";
            document.getElementById(cont[0] + "txtDuty").value = "";
            document.getElementById(cont[0] + "txtSalary").value = "";
            document.getElementById(cont[0] + "txtCon").value = "";
            document.getElementById(cont[0] + "txtConph").value = "";
            document.getElementById(cont[0] + "txtReason").value = "";
        }



        function cmdExit_onclick() {
            window.open('../../home.aspx', '_self');
        }

        // ]]>
    </script>
    <script>
        window.onload = window_onload;

    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtFdate"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtTdate"></cc1:CalendarExtender>
        &nbsp;
        <table border="1" style="width: 80%">
            <tr>
                <td style="width: 10%; text-align: left"></td>
                <td style="width: 7%; text-align: left"></td>
                <td style="width: 8%; text-align: left"></td>
                <td style="width: 20%; text-align: left"></td>
            </tr>
            <tr>
                <td style="width: 10%; text-align: left">Application Number</td>
                <td style="width: 7%; text-align: left">
                    <asp:TextBox ID="txtAppno" runat="server" Width="95%" onblur="OnCodecheck()" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 8%; text-align: right">Applicants Name :
                </td>
                <td style="width: 20%; text-align: left">
                    <asp:TextBox ID="txtName" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="row2">
                <td colspan="4">
                    <strong><span style="color: #ff0066; text-decoration: underline">Add Qualification</span></strong></td>
            </tr>
            <tr id="row3">
                <td style="text-align: left;" colspan="2">Select Qualification</td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="ddlQual" runat="server" Width="95%" onchange="ClassOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row4">
                <td colspan="2" style="text-align: left;">Enter Institution</td>
                <td colspan="2" style="text-align: left;">
                    <asp:TextBox ID="txtInist" runat="server" Width="94%" onkeyup="OnlettCaps('txtInist')"></asp:TextBox></td>
            </tr>
            <tr id="row5">
                <td style="text-align: left;" colspan="2">Enter University</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtUni" runat="server" Width="94%" onkeyup="OnlettCaps('txtUni')"></asp:TextBox></td>
            </tr>
            <tr id="row6">
                <td style="width: 10%; height: 9px; text-align: left;">Enter Year Of Passing</td>
                <td style="width: 7%; height: 9px; text-align: left;">
                    <asp:TextBox ID="txtYpass" runat="server" Width="98%" onkeyup="return YearCheck()" MaxLength="4" onblur="YearLostFocus()"></asp:TextBox></td>
                <td style="width: 8%; height: 9px; text-align: right;">Mark(%)</td>
                <td style="width: 20%; height: 9px; text-align: left;">
                    <asp:TextBox ID="txtMark" runat="server" Width="26%" onkeyup="return MarkCheck()"></asp:TextBox></td>
            </tr>
            <tr id="row7">
                <td colspan="4" style="height: 9px; text-align: center">
                    <input id="btnAdd" style="width: 66px; height: 28px" type="button" value="ADD" onclick="return btnAdd_onclick()" />
                    <input id="btnClear" style="height: 28px" type="button" value="CLEAR" onclick="return btnClear_onclick()" />&nbsp;</td>
            </tr>
            <tr id="rowQuPanel">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="row8">
                <td colspan="4">
                    <span style="color: #ff0066; text-decoration: underline"><strong>Add Experience</strong></span></td>
            </tr>
            <tr id="row9">
                <td style="text-align: left; height: 28px;" colspan="2">Name of Organization</td>
                <td style="text-align: left; height: 28px;" colspan="2">
                    <asp:TextBox ID="txtOrg" runat="server" Width="95%" onkeyup="OnlettCaps('txtOrg')"></asp:TextBox></td>
            </tr>
            <tr id="row10">
                <td style="text-align: left;" colspan="2">Employee Designation
                </td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txtDes" runat="server" Width="95%" onkeyup="OnlettCaps('txtDes')"></asp:TextBox></td>
            </tr>
            <tr id="row11">
                <td style="width: 10%; height: 23px; text-align: left">Period From Date</td>
                <td style="width: 7%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtFdate" runat="server" Width="95%" onkeyup="DateFCheck()" onblur="checkFdate('txtFdate')"></asp:TextBox></td>
                <td style="width: 8%; height: 23px; text-align: left">Period To Date</td>
                <td style="width: 20%; height: 23px; text-align: left">
                    <asp:TextBox ID="txtTdate" runat="server" Width="95%" onkeyup="DateTCheck()" onblur="checkTdate('txtTdate')"></asp:TextBox></td>
            </tr>
            <tr id="row12">
                <td style="width: 10%; text-align: left">Nature Of Duty</td>
                <td style="width: 7%; text-align: left">
                    <asp:TextBox ID="txtDuty" runat="server" Width="95%" onkeyup="OnlettCaps('txtDuty')"></asp:TextBox></td>
                <td style="width: 8%; text-align: left">Salary Drawn</td>
                <td style="width: 20%; text-align: left">
                    <asp:TextBox ID="txtSalary" runat="server" Width="95%" onkeyup="return SalaryCheck()"></asp:TextBox></td>
            </tr>
            <tr id="row13">
                <td style="width: 10%; text-align: left">Contact Person</td>
                <td style="width: 7%; text-align: left">
                    <asp:TextBox ID="txtCon" runat="server" Width="95%" onkeyup="OnlettCaps('txtCon')"></asp:TextBox></td>
                <td style="width: 8%; text-align: left">Contact No.</td>
                <td style="width: 20%; text-align: left">
                    <asp:TextBox ID="txtConph" runat="server" Width="95%" onkeyup="return phnocheck()" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr id="row14">
                <td colspan="2" style="text-align: left">Reason For Leaving</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="95%" onkeyup="OnlettCaps('txtReason')"></asp:TextBox></td>
            </tr>
            <tr id="row15">
                <td colspan="4">&nbsp;<input id="btnEadd" style="width: 66px; height: 28px" type="button" value="ADD" onclick="return btnEadd_onclick()" />
                    <input id="btnEclear" style="width: 66px; height: 28px" type="button" value="CLEAR" onclick="return btnEclear_onclick()" /></td>
            </tr>
            <tr id="rowExPanel">
                <td colspan="4" style="height: 42px">
                    <asp:Panel ID="Panel2" runat="server" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center;">
                        <asp:Button ID="cmd_confirm" runat="server" Text="EDIT" Width="74px" OnClick="cmd_confirm_Click" />
                        &nbsp;&nbsp;
  <input id="cmdExit" style="width: 76px;" type="button" value="EXIT" onclick="return cmdExit_onclick()" />
                    </div>
                </td>
            </tr>
        </table>
        <input id="hidden1" runat="server" type="hidden" style="width: 9px" />
        <input id="hidden2" runat="server" type="hidden" style="width: 9px" /><br />
        &nbsp; &nbsp;&nbsp;
        <input id="hdnQual" runat="server" type="hidden" style="width: 9px" />
    </div>
</asp:Content>

