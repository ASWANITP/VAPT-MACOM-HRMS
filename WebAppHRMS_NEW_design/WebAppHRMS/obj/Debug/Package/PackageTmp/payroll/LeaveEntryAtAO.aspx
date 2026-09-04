<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LeaveEntryAtAO.aspx.vb" Inherits="WebAppHRMS.payroll_LeaveEntryAtAO_b18b22962543" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript" for="window" event="onload">

        window.onload = callback;
        function callback() {
            return WindowOnload();
        }
    </script>
    <script type="text/javascript">
        var cont_name = header.split("txt");
        function btnOK_onclick() {
            EmployeeOnchange();
            FillLeaveDetails()
        }
        function EmpCodeOnkeydown() {
            if (window.event.keyCode == 27) { document.getElementById("btnExit").focus(); return; }
            if (window.event.keyCode == 13) btnOK_onclick();
            else {
                document.getElementById(cont_name[0] + "txtEmpName").value = "";
                document.getElementById("rowDetails").style.display = "none";
                document.getElementById("btnConfirm").disabled = true;
            }
        }
        function EmployeeOnchange() {
            var EmpCode = document.getElementById(cont_name[0] + "txtEmpCode").value;
            document.getElementById("btnConfirm").style.cursor = "wait";
            toServer("1?" + EmpCode, 1);
        }
        function FillLeaveDetails() {

            data = document.getElementById(cont_name[0] + "txtEmpCode").value;
            data = data + "%" + 222;
            toServer("4?" + data, 4);
            document.getElementById("row2").style.display = "none";
        }
        function CheckApplied() {
            if (document.getElementById(cont_name[0] + "chkApplication").checked == true)
                document.getElementById(cont_name[0] + "txtAppliedDt").disabled = false;
            else
                document.getElementById(cont_name[0] + "txtAppliedDt").disabled = true;
        }
        function CheckFutureDate() {
            var AppliedDt = document.getElementById(cont_name[0] + "txtAppliedDt").value;
            document.getElementById("btnConfirm").style.cursor = "wait";
            toServer("2?" + AppliedDt, 2);
        }
        function DateOnkeyup() {
            if (window.event.keyCode != 13) document.getElementById("btnConfirm").style.cursor = "wait";
        }
        function GetDays() {
            var FromDt = document.getElementById(cont_name[0] + "txtFromDt").value;
            var ToDt = document.getElementById(cont_name[0] + "txtToDt").value;
            var Type = document.getElementById(cont_name[0] + "cmbLeaveType").value;
            var EmpCode = document.getElementById(cont_name[0] + "txtEmpCode").value;
            document.getElementById("btnConfirm").style.cursor = "wait";
            toServer("3?" + FromDt + "?" + ToDt + "?" + Type + "?" + EmpCode, 3);
        }
        function checkWaiting() {
            if (document.getElementById("btnConfirm").style.cursor == "wait") {
                //      if (document.getElementById(cont_name[0]+"RadioButton2").checked==true)
                document.getElementById(cont_name[0] + "txtReason").focus();
                //      if (document.getElementById(cont_name[0]+"RadioButton1").checked==true && document.getElementById(cont_name[0]+"DropDownList1").value==0)
                //      {document.getElementById(cont_name[0]+"DropDownList1").focus();}

                document.getElementById("colForMessage").innerHTML = "Please Wait...";
            }
        }
        function btnConfirm_onclick() {
            debugger;
            if (document.getElementById("btnConfirm").style.cursor == "wait") {
                document.getElementById("colForMessage").style.color = "Blue";
                return;
            }
            //--//-- Abstraction --//--//
            var EmpCode = document.getElementById(cont_name[0] + "txtEmpCode").value;
            var Applied = 0;
            if (document.getElementById(cont_name[0] + "chkApplication").checked == true) Applied = 1;
            var AppliedDt = document.getElementById(cont_name[0] + "txtAppliedDt").value;
            var LeaveType = document.getElementById(cont_name[0] + "cmbLeaveType").value;
            var FromDt = document.getElementById(cont_name[0] + "txtFromDt").value;
            var ToDt = document.getElementById(cont_name[0] + "txtToDt").value;
            var WorkingDays = document.getElementById(cont_name[0] + "txtDays").value;
            var Reason = document.getElementById(cont_name[0] + "txtReason").value;


            var TotalDays = document.getElementById(cont_name[0] + "hidTotalDays").value;
            var chairman = 0;
            if (document.getElementById(cont_name[0] + "check_Chairman").checked == true) {
                chairman = 1;
            }
            else {
                chairman = 0;
            }
            //--//-----------------//--//
            //--//-- Validations --//--//
            if (Reason.replace(/^\s+/g, "") == "") { alert("You Should Specify The Reason !"); document.getElementById(cont_name[0] + "txtReason").focus(); return; }

            var lYear = document.getElementById(cont_name[0] + "txtFromDt").value.split("/"); //-- Getting FromDate Year
            var nYear = document.getElementById(cont_name[0] + "txtToDt").value.split("/");   //-- Getting ToDate Year
            if (Math.abs(lYear[2]) < Math.abs(new Date().getFullYear()) - 1) { alert("You Are Too Late To Update !"); return; }
            if (Math.abs(nYear[2]) > Math.abs(new Date().getFullYear()) && Math.abs(LeaveType) >= 1 && Math.abs(LeaveType <= 2)) { alert("You Are Too Early To Update !"); return; }
            if (Math.abs(WorkingDays) == 0) { alert("Verify Dates !"); document.getElementById(cont_name[0] + "txtFromDt").focus(); return; }
            if (Math.abs(TotalDays) > 3 && LeaveType == 1) { alert("Only 3 Consecutive Casual Leaves Are Allowed !"); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
            var Casual = document.getElementById(cont_name[0] + "txtCasual").value;
            var Sick = document.getElementById(cont_name[0] + "txtSick").value;
            var Earned = document.getElementById(cont_name[0] + "txtEarned").value;
            if (Math.abs(lYear[2]) == Math.abs(new Date().getFullYear())) {
                if (LeaveType == 1 && Math.abs(Casual) == 0) { alert("No Casual Leave Pending !"); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
                if (LeaveType == 1 && WorkingDays > Math.abs(Casual)) { alert("Casual Leave Pending is Only " + Casual); return; }
                if (LeaveType == 2 && Math.abs(Sick) == 0) { alert("No Sick Leave Pending !"); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
                if (LeaveType == 2 && WorkingDays > Math.abs(Sick)) { alert("Sick Leave Pending is Only " + Sick); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
                if (LeaveType == 3 && Math.abs(Earned) == 0) { alert("No Earned Leave Pending !"); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
                if (LeaveType == 3 && WorkingDays > Math.abs(Earned)) { alert("Earned Leave Pending is Only " + Earned); document.getElementById(cont_name[0] + "cmbLeaveType").focus(); return; }
            }
            if (confirm('Are You Sure ? ') == false) return;
            //--//-----------------//--//
            //sreeeeeee
            var DataChk = document.getElementById(cont_name[0] + "hid_check").value;
            //sreeee DropDownList1
            if (document.getElementById(cont_name[0] + "DropDownList1").value != 0) { Reason = document.getElementById(cont_name[0] + "DropDownList1").options[document.getElementById(cont_name[0] + "DropDownList1").selectedIndex].text + ":" + Reason; }

            var Data = "";

            Data += "9" + "?" + EmpCode + "?" + Applied + "?" + AppliedDt + "?" + LeaveType + "?";
            Data += FromDt + "?" + ToDt + "?" + WorkingDays + "?" + Reason + "?" + TotalDays + "?" + chairman + "?" + DataChk;
            document.getElementById("btnConfirm").style.cursor = "wait";
            toServer(Data, 9);
        }
        function fromServer(Arg, Context) {
            debugger;
            switch (Context) {
                case 1:
                    {
                        var Name_Casual_Sick_Earned = Arg.split("?");
                        if (Name_Casual_Sick_Earned[4] == "Error") {
                            alert(Name_Casual_Sick_Earned[5]); break;
                        }
                        document.getElementById("rowDetails").style.display = "table";
                        document.getElementById(cont_name[0] + "txtEmpName").value = Name_Casual_Sick_Earned[0];
                        document.getElementById(cont_name[0] + "txtCasual").value = Name_Casual_Sick_Earned[1];
                        document.getElementById(cont_name[0] + "txtSick").value = Name_Casual_Sick_Earned[2];
                        document.getElementById(cont_name[0] + "txtEarned").value = Name_Casual_Sick_Earned[3];

                        document.getElementById(cont_name[0] + "chkApplication").checked = true;
                        document.getElementById(cont_name[0] + "txtAppliedDt").disabled = false;
                        document.getElementById(cont_name[0] + "txtAppliedDt").focus();

                        document.getElementById("btnConfirm").disabled = false;
                        break;
                    }
                case 2:
                    {
                        if (Arg != "0") {
                            alert("Applied Date Should Not Be a Future Date !");
                            document.getElementById(cont_name[0] + "txtAppliedDt").value = document.getElementById(cont_name[0] + "hidSystemDate").value;
                            document.getElementById(cont_name[0] + "txtAppliedDt").focus();
                        }
                        break;
                    }
                case 3:
                    {
                        var TotalDays_WorkingDays = Arg.split("?");
                        document.getElementById(cont_name[0] + "hidTotalDays").value = TotalDays_WorkingDays[0];
                        document.getElementById(cont_name[0] + "txtDays").value = TotalDays_WorkingDays[1];
                        document.getElementById(cont_name[0] + "txtFromDt").value = TotalDays_WorkingDays[2];
                        document.getElementById(cont_name[0] + "txtToDt").value = TotalDays_WorkingDays[3];
                        break;
                    }


                case 4:
                    var Data = Arg.split("@");
                    {
                        document.getElementById(cont_name[0] + "Hidden1").value = Data[0];
                        disp();
                        break;
                    }


                case 9:
                    {
                        var data = Arg.split("?");
                        alert(data[0])
                        if (data[0] == "Successfully Inserted !") {
                            document.getElementById(cont_name[0] + "chkApplication").checked == true;
                            document.getElementById(cont_name[0] + "txtAppliedDt").value = document.getElementById(cont_name[0] + "hidSystemDate").value;
                            document.getElementById(cont_name[0] + "cmbLeaveType").value = 1;
                            document.getElementById(cont_name[0] + "txtFromDt").value = document.getElementById(cont_name[0] + "hidSystemDate").value;
                            document.getElementById(cont_name[0] + "txtToDt").value = document.getElementById(cont_name[0] + "hidSystemDate").value;
                            document.getElementById(cont_name[0] + "txtDays").value = 1;
                            document.getElementById(cont_name[0] + "txtReason").value = "";
                            document.getElementById(cont_name[0] + "hidTotalDays").value = 1;
                            document.getElementById(cont_name[0] + "txtCasual").value = data[1];
                            document.getElementById(cont_name[0] + "txtSick").value = data[2];
                            document.getElementById(cont_name[0] + "txtEarned").value = data[3];
                        }
                        else document.getElementById(cont_name[0] + "cmbLeaveType").focus();
                        break;
                    }
            }
            document.getElementById("btnConfirm").style.cursor = "pointer";
            document.getElementById("colForMessage").innerHTML = "";
        }
        function isValidDate(ctrl) // Server Control Only
        {
            var s = document.getElementById(cont_name[0] + ctrl).value;
            var dateFormat = /^\d{1,4}[\.|\/|-]\d{1,2}[\.|\/|-]\d{1,4}$/;// format D(D)/M(M)/(YY)YY
            if (dateFormat.test(s)) {
                s = s.replace(/0*(\d*)/gi, "$1");// remove any leading zeros from date values
                var dateArray = s.split("/");
                if (Math.abs(dateArray.length) != 3) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                    return;
                }
                dateArray[1] = dateArray[1] - 1;// correct month value
                // Digit Check In Year
                if (dateArray[2].length != 4) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                    return;
                }
                // correct year value
                if (dateArray[2].length < 4)
                    dateArray[2] = (parseInt(dateArray[2]) < 50) ? 2000 + parseInt(dateArray[2]) : 1900 + parseInt(dateArray[2]);
                var testDate = new Date(dateArray[2], dateArray[1], dateArray[0]);
                if (testDate.getDate() != dateArray[0] || testDate.getMonth() != dateArray[1] || testDate.getFullYear() != dateArray[2]) {
                    alert("Incorrect Date Format!");
                    document.getElementById(cont_name[0] + ctrl).focus();
                    return;
                }
            }
            else {
                alert("Incorrect Date Format!");
                document.getElementById(cont_name[0] + ctrl).focus();
                return;
            }
        }
        function WindowOnload() {
            document.getElementById(cont_name[0] + "txtEmpCode").focus();
            document.getElementById("btnConfirm").disabled = true;
            document.getElementById(cont_name[0] + "check_Chairman").checked = false;
        }
        function FocusToServer(Ctrl) { if (window.event.keyCode == 13) document.getElementById(cont_name[0] + Ctrl).focus(); if (window.event.keyCode == 27) document.getElementById("btnConfirm").focus(); }
        function FocusToClient(Ctrl) { if (window.event.keyCode == 13) document.getElementById(Ctrl).focus(); if (window.event.keyCode == 27) document.getElementById("btnConfirm").focus(); }
        function btnExit_onclick() { window.open('../home.aspx', '_self'); }



        function disp() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont_name[0] + "Hidden1").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("sree").style.display = "none";
                document.getElementById(cont_name[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cont_name[0] + "Hidden1").value.split("~")
            ar = st2.length - 1;
            if (document.getElementById(cont_name[0] + "Hidden1").value != "") {
                for (i = 0; i < ar; i++) {
                    //        count=count+1
                    st3 = st2[i].split("!")
                    document.getElementById(cont_name[0] + "hid1").value = st3[6]
                    if (st3[4] == 1) { st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><small>" + st3[5] + "</td><td><small>-</td><td><small>-</td><td><input type='checkbox' id='chk_" + i + "' name='txt_" + i + "' onclick=chkk('" + i + "','chk_" + i + "')></td><td>-</td></tr>" }
                    else                                                                                                                                                                                                 //onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL" onclick=chek('chk_"+i+"')<a href=javascript:chkk('" + i + "')>
                    { st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><small>" + st3[5] + "</td><td><small>-</td><td><small>-</td><td><input type='checkbox'  id='chk_" + i + "' name='txt_" + i + "' onclick=chkk('" + i + "','chk_" + i + "')></td><td><small><a href=javascript:edit('" + i + "')>Edit</td></tr>" }
                    count = count + 1
                }
                st = st + "<table id='mytable' border=1 width='80%'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>FROM&nbsp;DATE</b></td><td><b>&nbsp;&nbsp;TO&nbsp;DATE&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;&nbsp;&nbsp;LEAVE&nbsp;TYPE&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><b>DURATION</b></td><td><b>&nbsp;&nbsp;&nbsp;&nbsp;LEAVE&nbsp;REASON&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><b>PARTIAL&nbsp;FRAOM&nbsp;DATE</b></td><td><b>PARTIAL&nbsp;TO&nbsp;DATE</b></td><td><b>CHECK</b></td><td><b>EDIT</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("sree").style.display = "table-row";
                document.getElementById("panel_row").style.display = "table-row";
            }
            document.getElementById(cont_name[0] + "Panel1").innerHTML = st1;
        }



        function del(id) {
            //debugger;
            var at = "";
            var rid;
            ar = document.getElementById("Hidden1").value.split("!")
            for (funi = 0; funi < ar.length; funi++) {
                if (funi != id) {
                    if (at != "") {
                        at = at + "!" + ar[funi]
                    }
                    else {
                        at = ar[funi]
                    }
                }
            }
            document.getElementById(cont_name[0] + "Hidden1").value = at
            disp(document.getElementById(cont_name[0] + "Hidden1").value)
        }



        function chek() {
            //debugger;
            for (k = 1; k <= document.getElementById(cont_name[0] + "hid1").value; k++) {
                document.getElementById("txt_" + i).checked = true;

            }
        }



        function edit(id) { //debugger;
            document.getElementById("row2").style.display = "table-row";
            document.getElementById("Hidden9").value = 1;
            document.getElementById(cont_name[0] + "TextBox1").focus();
            var at = "";
            var rid;
            ar = document.getElementById(cont_name[0] + "Hidden1").value.split("~")
            for (q = 0; q < ar.length - 1; q++) {
                if (q == id) {
                    var st3;
                    st3 = ar[q].split("!")


                    document.getElementById(cont_name[0] + "TextBox1").value = st3[1];
                    document.getElementById(cont_name[0] + "TextBox2").value = st3[2];
                    document.getElementById("Hidden3").value = id;
                    document.getElementById("Hidden7").value = st3[1];
                    document.getElementById("Hidden8").value = st3[1];

                }
            }
        }
        function cmd_ok_onclick() { //debugger;
            if (document.getElementById(cont_name[0] + "TextBox1").value == "" && document.getElementById(cont_name[0] + "TextBox2").value == "") {
                alert('Please Enter Partial Date');
                document.getElementById(cont_name[0] + "TextBox1").focus();
                return false;
            }
            var kn = document.getElementById("Hidden3").value;
            id = parseInt(kn) + parseInt(1);
            document.getElementById("row2").style.display = "none";
            document.getElementById("Hidden9").value = 0;
            var rid = document.getElementById('mytable').rows[id].cells;
            rid[5].innerHTML = document.getElementById(cont_name[0] + "TextBox1").value;
            rid[6].innerHTML = document.getElementById(cont_name[0] + "TextBox2").value;
            if (document.getElementById("Hidden6").value == 2) {
                if (document.getElementById("Hidden7").value != document.getElementById(cont_name[0] + "TextBox1").value || document.getElementById("Hidden7").value != document.getElementById(cont_name[0] + "TextBox2").value) {
                    document.getElementById(cont_name[0] + "Hidden6").value = 1;
                }
            }
            var ar;
            var rid;
            document.getElementById("Hidden4").value = "";
            ar = document.getElementById(cont_name[0] + "Hidden1").value.split("~");
            for (funi = 0; funi < ar.length - 1; funi++) {
                var pr = ar[funi].split("!")

                if (parseInt(funi) + parseInt(1) == id) {
                    //document.getElementById("Hidden4").value=document.getElementById("Hidden4").value+document.getElementById(cont_name[0]+"TextBox1").value+"!"+document.getElementById(cont_name[0]+"TextBox2").value+"!"+pr[2]+"!"+pr[3]+"!"+pr[4]+"!"+pr[5]+"~";
                    document.getElementById("Hidden4").value = document.getElementById("Hidden4").value + pr[0] + "!" + pr[1] + "!" + pr[2] + "!" + pr[3] + "!" + pr[4] + "!" + pr[5] + "!" + pr[6] + "!" + pr[7] + "!" + document.getElementById(cont_name[0] + "TextBox1").value + "!" + document.getElementById(cont_name[0] + "TextBox2").value + "~";
                }
                else {
                    document.getElementById("Hidden4").value = document.getElementById("Hidden4").value + pr[0] + "!" + pr[1] + "!" + pr[2] + "!" + pr[3] + "!" + pr[4] + "!" + pr[5] + "!" + pr[6] + "!" + pr[7] + "!" + " " + "!" + " " + "~";
                }

            }

            document.getElementById(cont_name[0] + "Hidden1").value = document.getElementById("Hidden4").value;

        }







        function chkk(id, a) {
            //debugger;
            var at = "";
            var rid;
            ar = document.getElementById(cont_name[0] + "Hidden1").value.split("~")

            // if (document.getElementById(cont_name[0]+"a").checked==true)
            if (document.getElementById(a).checked == true) {
                for (funi = 0; funi < ar.length; funi++) {
                    if (funi == id) {
                        if (at != "") {
                            at = at + "!" + ar[funi]
                        }
                        else {
                            at = ar[funi]
                        }
                    }
                }
                if (document.getElementById(cont_name[0] + "hid_check").value != "") { document.getElementById(cont_name[0] + "hid_check").value = document.getElementById(cont_name[0] + "hid_check").value + at + '^'; }
                else { document.getElementById(cont_name[0] + "hid_check").value = at + '^'; }
            }
            else {
                var at = "";
                var rid;
                ar = document.getElementById(cont_name[0] + "hid_check").value.split("^")
                for (funi = 0; funi < ar.length; funi++) {
                    if (funi != id) {
                        if (at != "") {
                            at = at + "!" + ar[funi]
                        }
                        else {
                            at = ar[funi]
                        }
                    }
                }
                document.getElementById(cont_name[0] + "hid_check").value = at
            }

        }


        function OnclickPenal() {

            if (document.getElementById(cont_name[0] + "RadioButton1").checked == true)
                document.getElementById("Reas").style.display = "none";
            document.getElementById("Penalty").style.display = "table-row";

        }
        function OnclickReason() {

            if (document.getElementById(cont_name[0] + "RadioButton2").checked == true)
                document.getElementById("Reas").style.display = "table-row";
            document.getElementById("Penalty").style.display = "none";

        }
    </script>
    <div id="divTotal" style="text-align: center; font-family: 'poppins'; color: midnightblue;">
        <div style="text-align: center">
            <table border="1" style="width: 76%; font-family: 'Book Antiqua'; height: 246px;">
                <tr>
                    <td style="width: 50%">Employee Code</td>
                    <td style="width: 50%; text-align: left;">
                        <input id="txtEmpCode" runat="server" type="text" />
                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <input id="btnOK" style="width: 70px; cursor: pointer; font-family: 'Book Antiqua';" type="button" value="OK" onclick="return btnOK_onclick()" /></td>
                </tr>
                <tr>
                    <td style="width: 50%; height: 28px;">Employee Name</td>
                    <td style="width: 50%; text-align: left; height: 28px;">
                        <input id="txtEmpName" runat="server" size="40" type="text" readonly="readOnly" /></td>
                </tr>
                <tr id="sree" style="display: none">
                    <td colspan="2">
                        <table border="0" style="width: 985px; height: 143px">
                            <tr id="panel_row">
                                <td colspan="4">
                                    <asp:Panel ID="Panel1" runat="server">
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr id="row2" style="display: none">
                                <td colspan="4" style="height: 12px">Partial From Date&nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server" Width="151px"></asp:TextBox>
                                    &nbsp; Partial To Date &nbsp;
                                    <asp:TextBox ID="TextBox2" runat="server" Width="137px"></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <input id="cmd_ok" onclick=" return cmd_ok_onclick()" style="width: 82px" type="button"
                                        value="OK" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%"></td>
                    <td style="width: 50%"></td>
                </tr>
            </table>
        </div>
        <table id="rowDetails" border="1" style="width: 81%; font-family: 'Book Antiqua'; display: none;">
            <tr style="height: 40px">
                <td colspan="2">Whether Leave Form Submitted &nbsp; &nbsp;&nbsp;
                        <input id="chkApplication" type="checkbox" checked="CHECKED" runat="server" />
                </td>
                <td colspan="2" rowspan="2">
                    <strong>Pending Leave Details</strong></td>
            </tr>
            <tr>
                <td style="width: 25%">Applied On</td>
                <td style="width: 25%; text-align: left;">
                    <strong><span
                        style="font-size: 10pt; color: #f08080">
                        <asp:TextBox ID="txtAppliedDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
            </tr>
            <tr>
                <td style="width: 25%">Leave Type</td>
                <td style="width: 25%; text-align: left;"><strong><span
                    style="font-size: 10pt; color: lightcoral">
                    <asp:DropDownList ID="cmbLeaveType" runat="server" Font-Names="Courier New" Width="70%">
                    </asp:DropDownList></span></strong></td>
                <td style="width: 25%">Casual</td>
                <td style="width: 25%; text-align: left;">
                    <input id="txtCasual" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">From Date</td>
                <td style="width: 25%; text-align: left;">
                    <strong><span
                        style="font-size: 10pt; color: lightcoral">
                        <asp:TextBox ID="txtFromDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
                <td style="width: 25%">Sick</td>
                <td style="width: 25%; text-align: left;">
                    <input id="txtSick" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">To Date</td>
                <td style="width: 25%; text-align: left;">
                    <strong><span
                        style="font-size: 10pt; color: lightcoral">
                        <asp:TextBox ID="txtToDt" runat="server" Width="32%"></asp:TextBox>
                        dd/mm/yyyy</span></strong></td>
                <td style="width: 25%">Earned</td>
                <td style="width: 25%; text-align: left;">
                    <input id="txtEarned" type="text" readonly="readOnly" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 25%">No. of Days</td>
                <td style="width: 25%; text-align: left;">
                    <input id="txtDays" type="text" readonly="readOnly" runat="server" /></td>
                <td colspan="2">
                    <asp:CheckBox ID="check_Chairman" runat="server" Text=" Tick Whether this Leave Approved by Chairman"
                        Width="419px" /></td>
            </tr>
            <tr id="Penalty">
                <td style="width: 25%; height: 20px">Penalty</td>
                <td colspan="3" style="height: 20px; text-align: left">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="618px">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem Value="1">PENALTY LEAVE</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="Reas">
                <td style="width: 25%; height: 28px;">Reason</td>
                <td colspan="3" style="text-align: left; height: 28px;">
                    <input id="txtReason" type="text" size="97" maxlength="100" runat="server" /></td>
            </tr>
            <tr>
                <td id="colForMessage" colspan="4"></td>
            </tr>
        </table>
        <input id="hidTotalDays" runat="server" style="width: 11px" type="hidden" />
        <input id="hidSystemDate" runat="server" style="width: 11px" type="hidden" /><br />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="TextBox2"></cc1:CalendarExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 22%">
            <tr>
                <td style="width: 50%">
                    <input id="btnConfirm" style="width: 88px; cursor: pointer; font-family: 'Book Antiqua'; height: 26px"
                        type="button" value="CONFIRM" onfocus="checkWaiting()" onmouseover="checkWaiting()" onclick="return btnConfirm_onclick()" /></td>
                <td style="width: 50%">
                    <input id="btnExit" style="width: 88px; cursor: pointer; font-family: 'Book Antiqua'; height: 26px"
                        type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="TextBox1">
    </cc1:CalendarExtender>--%>
    <%--<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <%--  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="TextBox2">
    </cc1:CalendarExtender>--%>
    <asp:HiddenField ID="hid1" runat="server" />
    <input id="Hidden2" style="width: 40px" type="hidden" /><input id="Hidden9" style="width: 19px"
        type="hidden" /><input id="Hidden3" style="width: 28px" type="hidden" /><input id="Hidden4"
            style="width: 4px" type="hidden" /><input id="Hidden6" style="width: 26px" type="hidden" /><input
                id="Hidden1" style="width: 35px" type="hidden" runat="server" /><input id="Hidden5" style="width: 10px"
                    type="hidden" /><input id="Hidden7" style="width: 5px" type="hidden" /><input id="Hidden8"
                        style="width: 2px" type="hidden" /><input id="Hidden10" runat="server" style="width: 13px"
                            type="hidden" />
    <input id="hid_check" runat="server" type="hidden" />
</asp:Content>

