<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Emp_Off_Updt.aspx.vb" Inherits="WebAppHRMS._7DaysWorking_hrm_Emp_Off_Updt_a762d4196657" Title="Untitled Page" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
        window.onload = callback;
        function callback() {
            return window_onload();
        }
    </script>

    <script language="javascript" type="text/javascript">
        var cont = master_no.split("cmb");

        function Button3_onclick() {
            window.open('../home.aspx', '_self')
        }
        function fill_details() {
            debugger;
            document.getElementById("panel_row1").style.display = "none";
            document.getElementById("paneld").style.display = "none";
            if (document.getElementById(cont[0] + "cmb_Employee").value == 0) {
                alert('Please Select Employee.');
                document.getElementById(cont[0] + "cmb_Employee").focus();
                return false;
            }


            if (document.getElementById("row").style.display == "table-row") {
                if (document.getElementById(cont[0] + "cmb_Day").value == 0) {
                    alert('Please Select Day.');
                    document.getElementById(cont[0] + "cmb_Day").focus();
                    return false;
                }
            }


            if (document.getElementById("rowBH").style.display == "table-row") {
                if (document.getElementById(cont[0] + "cmb_DayBH").value == 0) {
                    alert('Please Select Day.');
                    document.getElementById(cont[0] + "cmb_DayBH").focus();
                    return false;
                }
            }





            if (document.getElementById(cont[0] + "Hidden1").value != "") {

                st2 = document.getElementById(cont[0] + "Hidden1").value.split("!")
                ar = st2.length - 1;
                for (i = 0; i < ar; i++) {

                    st3 = st2[i].split("*")


                    //if(st3[0]==document.getElementById(cont[0]+"cmb_Employee").value && st3[2]==document.getElementById(cont[0]+"cmb_Day").value)
                    if (st3[0] == document.getElementById(cont[0] + "cmb_Employee").value) {
                        {
                            alert("Same Employee Can Not Be Added More Than Once");
                            return false;
                        }

                    }

                    if (st3[2] == document.getElementById(cont[0] + "cmb_Day").value) {

                        if (document.getElementById(cont[0] + "hidden2").value == 2) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 2) {
                                alert("One Day Maximum 2 Leave Is Allowed");
                                return false;
                            }
                        }


                        if (document.getElementById(cont[0] + "hidden2").value == 3) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 3) {
                                alert("One Day Maximum 3 Leave Is Allowed");
                                return false;
                            }
                        }



                        if (document.getElementById(cont[0] + "hidden2").value == 4) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 4) {
                                alert("One Day Maximum 4 Leave Is Allowed");
                                return false;
                            }
                        }


                        if (document.getElementById(cont[0] + "hidden2").value == 5) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 5) {
                                alert("One Day Maximum 5 Leave Is Allowed");
                                return false;
                            }
                        }



                        if (document.getElementById(cont[0] + "hidden2").value == 6) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 6) {
                                alert("One Day Maximum 6 Leave Is Allowed");
                                return false;
                            }
                        }


                        if (document.getElementById(cont[0] + "hidden2").value == 7) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 7) {
                                alert("One Day Maximum 7 Leave Is Allowed");
                                return false;
                            }
                        }


                        if (document.getElementById(cont[0] + "hidden2").value == 8) {
                            document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                            var coun = document.getElementById("hid_Counter").value;
                            if (document.getElementById("hid_Counter").value > 8) {
                                alert("One Day Maximum 8 Leave Is Allowed");
                                return false;
                            }
                        }


                    }
                }
            }


            if (document.getElementById(cont[0] + "Hidden1").value == "") {
                if (document.getElementById("row").style.display == "table-row") {
                    document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "cmb_Employee").value + '*' +
                        document.getElementById(cont[0] + "cmb_Employee").options[document.getElementById(cont[0] + "cmb_Employee").selectedIndex].text + '*' +
                        document.getElementById(cont[0] + "cmb_Day").value + '*' +
                        document.getElementById(cont[0] + "cmb_Day").options[document.getElementById(cont[0] + "cmb_Day").selectedIndex].text + '*' + '!'
                }


                if (document.getElementById("rowBH").style.display == "table-row") {
                    document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "cmb_Employee").value + '*' +
                        document.getElementById(cont[0] + "cmb_Employee").options[document.getElementById(cont[0] + "cmb_Employee").selectedIndex].text + '*' +
                        document.getElementById(cont[0] + "cmb_DayBH").value + '*' +
                        document.getElementById(cont[0] + "cmb_DayBH").options[document.getElementById(cont[0] + "cmb_DayBH").selectedIndex].text + '*' + '!'
                }





            }
            else {
                if (document.getElementById("row").style.display == "table-row") {
                    document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "Hidden1").value +
                        document.getElementById(cont[0] + "cmb_Employee").value + '*' +
                        document.getElementById(cont[0] + "cmb_Employee").options[document.getElementById(cont[0] + "cmb_Employee").selectedIndex].text + '*' +
                        document.getElementById(cont[0] + "cmb_Day").value + '*' +
                        document.getElementById(cont[0] + "cmb_Day").options[document.getElementById(cont[0] + "cmb_Day").selectedIndex].text + '*' + '!'

                }

                if (document.getElementById("rowBH").style.display == "table-row") {
                    document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "Hidden1").value +
                        document.getElementById(cont[0] + "cmb_Employee").value + '*' +
                        document.getElementById(cont[0] + "cmb_Employee").options[document.getElementById(cont[0] + "cmb_Employee").selectedIndex].text + '*' +
                        document.getElementById(cont[0] + "cmb_DayBH").value + '*' +
                        document.getElementById(cont[0] + "cmb_DayBH").options[document.getElementById(cont[0] + "cmb_DayBH").selectedIndex].text + '*' + '!'

                }



            }
            disp()
            document.getElementById(cont[0] + "cmb_Employee").value = "0";
            document.getElementById(cont[0] + "cmb_Day").value = "0";
            document.getElementById("hid_Counter").value = 1;
        }
        function disp() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont[0] + "Hidden1").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("panelC").style.display = "none";
                document.getElementById(cont[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cont[0] + "Hidden1").value.split("!");
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                for (i = 0; i < ar; i++) {
                    st3 = st2[i].split("*");
                    st1 = st1 + "<tr  bgcolor='MistyRose'><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[3] + "</td><td><small><a href=javascript:del('" + i + "')>del</td></tr>"
                }
                st = st + "<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>&nbsp;EMPLOYEE&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMPLOYEE&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;COMPENSATORY&nbsp;DAY&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;DELETE&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "table-row";
                document.getElementById("panelC").style.display = "table-row";
                document.getElementById("panel_row1").style.display = "none";
                document.getElementById("paneld").style.display = "none";
            }
            document.getElementById(cont[0] + "Panel1").innerHTML = st1;
        }



        function disp1() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont[0] + "hid_data").value == "") {
                document.getElementById("panel_row1").style.display = "none";
                document.getElementById("paneld").style.display = "none";
                document.getElementById(cont[0] + "Panel2").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cont[0] + "hid_data").value.split("!");
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "hid_data").value != "") {
                for (i = 0; i < ar; i++) {
                    st3 = st2[i].split("*");
                    st1 = st1 + "<tr  bgcolor='MistyRose'><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><input type='checkbox' id='chkm_" + i + "' name='txtm_" + i + "'></td></tr>"
                }
                st = st + "<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>&nbsp;EMPLOYEE&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMPLOYEE&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;COMPENSATORY&nbsp;DAY&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;MARK IF DELETING ONLY&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row1").style.display = "table-row";
                document.getElementById("paneld").style.display = "table-row";
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("panelC").style.display = "none";
            }
            document.getElementById(cont[0] + "Panel2").innerHTML = st1;
        }



        function del(id) {
            //debugger;
            var at = "";
            var rid;
            ar = document.getElementById(cont[0] + "Hidden1").value.split("!")
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
            document.getElementById(cont[0] + "Hidden1").value = at
            disp(document.getElementById(cont[0] + "Hidden1").value)
        }


        function OnkeyUpChqDate(Control) {
            if (document.getElementById(cont[0] + Control).value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
            }
        }


        function check_date(Control) {
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
                if (dbd > 0) {
                    alert("Please Do Not Enter Past Date ..!!")
                    document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
                    document.getElementById(cont[0] + Control).focus();
                    return false;
                }
            }

        }

        function FillEmployDetails() {
            data = document.getElementById(cont[0] + "cmb_Employee").value;
            BR = document.getElementById(cont[0] + "hid_branch").value;
            data = data + "%" + BR + "%" + 111;
            ToServer(data + "#" + 1, 1);

        }
        function FillAddedDetails() {
            BR = document.getElementById(cont[0] + "hid_branch").value;
            data = BR + "%" + 111;
            ToServer(data + "#" + 2, 2);

        }


        function FromServer(arg, context) {
            //debugger;
            //var Data=arg.split("@")
            var Data = arg

            switch (context) {
                case 1:
                    //         if(document.getElementById(cont[0]+"cmb_Employee").value==0)
                    //           {
                    //               document.getElementById("row").style.display="none";
                    //               document.getElementById("rowBH").style.display="none";
                    //               return false;
                    //           }
                    //         else
                    //         {
                    //         Data1=Data[0].split("~")
                    //         arg1=Data1[0].split("!")
                    if (arg == 1) {
                        document.getElementById("row").style.display = "none";
                        document.getElementById("rowBH").style.display = "table-row";
                        return true;
                    }
                    if (arg == 0) {
                        document.getElementById("row").style.display = "table-row";
                        document.getElementById(cont[0] + "hid_Em").value = document.getElementById(cont[0] + "cmb_Employee").value;
                        document.getElementById("rowBH").style.display = "none";
                        return true;
                    }


                    //        }  
                    break;
                case 2:
                    var Data = arg.split("@")

                    if (Data[0] == "") {
                        alert("No Assign Today!!!")
                        document.getElementById("panel_row1").style.display = "none";
                        document.getElementById("paneld").style.display = "none";
                        return false;

                    }
                    else {

                        document.getElementById(cont[0] + "hid_data").value = Data[0];
                        document.getElementById("panel_row").style.display = "none";
                        document.getElementById("panelC").style.display = "none";
                        disp1();


                    }
                    break;

                case 3:

                    alert(arg);
                    window.open('hrm_Emp_Off_Change.aspx', '_self');
                    break;

                case 4:
                    var Data = arg.split("@")
                    document.getElementById(cont[0] + "cmb_Employee").options.length = 0;
                    document.getElementById(cont[0] + "hid_Em").value = document.getElementById(cont[0] + "cmb_Employee").value;
                    if (Data[0] == "") { alert("No Details ..!!!"); return false; }
                    ComboFill(Data[0], "cmb_Employee");
                    break;
            }
        }
        function ComboFill(Data, ComboName) {
            if (Data[0] == '') return;

            var rows = Data.split("*");
            for (a = 0; a < rows.length; a++) {
                var cols = rows[a].split("$");
                var option1 = document.createElement("OPTION");
                option1.value = cols[0];
                option1.text = cols[1];
                document.getElementById(cont[0] + ComboName).add(option1);
            }

        }
        //function OnClickConfirm()
        // {
        //       //debugger;     
        //        var brid=document.getElementById(cont[0]+"hid_branch").value;
        //        var Str=document.getElementById(cont[0]+"Hidden1").value;
        //        var Fromdt=document.getElementById(cont[0]+"txt_Date").value;              
        //       ToData = Str+"%"+brid+"%"+Fromdt+"%"+reason;
        //       ToServer(ToData+"#"+2,2)
        //}
        function window_onload() {
            var Status = "-33";
            ToServer(Status + "#" + 4, 4);
        }

        function Button6_onclick() {
            window.open('../home.aspx', '_self')
        }
        function onclickdelete() {
            //debugger;
            document.getElementById(cont[0] + "Hidden4").value = "";

            if (document.getElementById(cont[0] + "hid_data").value != "") {
                var st3 = "";
                st2 = document.getElementById(cont[0] + "hid_data").value.split("!")
                ar = st2.length
                for (ii = 0; ii < ar - 1; ii++) {
                    st3 = st2[ii].split("*")
                    var Delete = "T";
                    if (document.getElementById("chkm_" + ii + "").checked == false) Delete = "F";
                    document.getElementById(cont[0] + "Hidden4").value += st3[0] + "^" + st3[2] + "^" + Delete + "$";
                }
            }
            //    if (document.getElementById(cont[0]+"RadioButton1").checked==true)
            //    {var CREDIT=11}
            //    if (document.getElementById(cont[0]+"RadioButton2").checked==true)
            //    {var CREDIT=22}

            var DELData = document.getElementById(cont[0] + "Hidden4").value;
            var CODE = document.getElementById(cont[0] + "hid_branch").value;
            data = DELData + "%" + CODE + "%" + 112;
            ToServer(data + "#" + 3, 3);

        }

        function Button7_onclick() {
            window.open('../home.aspx', '_self')
        }
        function OnClickRadiobutton1() {
            var Status = "-33";
            ToServer(Status + "#" + 4, 4);
        }
        function OnClickRadiobutton2() {
            var Status = "-44";
            ToServer(Status + "#" + 4, 4);
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="hid_s2" runat="server" />
        <table border="1" style="border: unset;">
            <tr>
                <td colspan="2" style="font-size: 13pt; height: 29px;">Select <span style="font-size: 12pt">Employee</span></td>
                <td style="text-align: left; font-size: 12pt; height: 29px;" colspan="2">
                    <asp:DropDownList ID="cmb_Employee" onchange="FillEmployDetails()" runat="server" Width="294px" Font-Names="Times New Roman" Font-Size="Medium">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row" style="display: none; font-size: 12pt;">
                <td colspan="2" style="font-size: 12pt; height: 29px;">Select Day</td>
                <td colspan="2" style="height: 29px; text-align: left;">
                    <asp:DropDownList ID="cmb_Day" runat="server" Width="294px" Font-Names="Times New Roman" Font-Size="Medium">
                        <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                        <asp:ListItem Value="1">SUNDAY</asp:ListItem>
                        <asp:ListItem Value="2">MONDAY</asp:ListItem>
                        <asp:ListItem Value="3">TUESDAY</asp:ListItem>
                        <asp:ListItem Value="4">WEDNESDAY</asp:ListItem>
                        <asp:ListItem Value="5">THURSDAY</asp:ListItem>
                        <asp:ListItem Value="6">FRIDAY</asp:ListItem>
                        <asp:ListItem Value="7">SATURDAY</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="rowBH" style="display: none; font-size: 12pt;">
                <td colspan="2" style="font-size: 12pt">Select Day</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_DayBH" runat="server" Width="294px" Font-Names="Times New Roman" Font-Size="Medium">
                        <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                        <asp:ListItem Value="1">SUNDAY</asp:ListItem>
                        <asp:ListItem Value="2">MONDAY</asp:ListItem>
                        <asp:ListItem Value="3">TUESDAY</asp:ListItem>
                        <asp:ListItem Value="4">WEDNESDAY</asp:ListItem>
                        <asp:ListItem Value="5">THURSDAY</asp:ListItem>
                        <asp:ListItem Value="6">FRIDAY</asp:ListItem>
                        <asp:ListItem Value="7">SATURDAY</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="2" style="font-size: 12pt">From Date</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_Date" runat="server" onblur="check_date('txt_Date')" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="199px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="4" style="font-size: 12pt; height: 23px">
                    <asp:LinkButton ID="LinkButton1" runat="server" Width="303px">View Weekly off Status Report</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 22px; text-align: center;">
                    <input id="Button1" type="button" value="ADD" onclick="fill_details()" style="font-size: 12pt; font-family: 'Times New Roman'; width: 69px;" />&nbsp;
                    <input id="Button4" type="button" onclick="FillAddedDetails()" value="VIEW OR DELETE ADDED EMPLOYEES" style="font-size: 12.5pt; width: 316px; font-family: 'Times New Roman'; height: 27px" />
                    <%--<input id="Button7" type="button" value="EXIT" onclick="return Button7_onclick()" style="width: 56px; height: 26px" /></td>--%>
            </tr>
            <tr id="panel_row">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="panelC" style="display: none;">
                <td colspan="4">
                    <asp:Button ID="Button2" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="CONFIRMs" Width="93px" Style="font-size: 12pt" />&nbsp;&nbsp;
                    <input id="Button3" style="font-size: 12pt; width: 87px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button3_onclick()" /></td>
            </tr>
            <%--            <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
            </tr>--%>
            <tr id="panel_row1">
                <td colspan="4">
                    <asp:Panel ID="Panel2" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="paneld" style="display: none;">
                <td colspan="4">
                    <input id="Button5" onclick="onclickdelete()" style="font-size: 12.5pt; font-family: 'Times New Roman'; width: 96px;" type="button"
                        value="CONFIRMd" />
                    &nbsp;
                    <input id="Button6" style="font-size: 12.5pt; width: 87px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button6_onclick()" /></td>
            </tr>
            <%--            <tr>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
            </tr>--%>
        </table>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_Date"></cc1:CalendarExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdn_sysdate" runat="server" />
        <asp:HiddenField ID="hid_Em"
            runat="server" />

        <asp:HiddenField ID="hid_dep" runat="server" />
        <input id="Hidden1" runat="server" type="hidden" style="width: 1px" />
        <input id="hid_Counter" type="hidden" style="width: 1px" />
        <input id="hid_branch" runat="server" style="width: 1px" type="hidden" />
        <input id="Hidden2" runat="server" type="hidden" style="width: 1px" />
        <input id="hid_s" runat="server" type="hidden" />
        <input id="hid_count" runat="server" type="hidden" />
        <asp:HiddenField ID="hid_data" runat="server" />
        <input id="Hidden4" runat="server" type="hidden" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
</asp:Content>

