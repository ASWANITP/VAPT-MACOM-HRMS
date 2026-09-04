<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_AllowanceUpdation.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_HRM_AllowanceUpdation_482c3fd51836" Title="Untitled Page" %>

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

        function window_onload() {
            //KRISHNADAS Dec-10
            debugger;
            document.getElementById("rw2").style.display = "none"
            document.getElementById("rw1").style.display = "none"
            document.getElementById("panel_row").style.display = "none";
            document.getElementById("amount_row").style.display = "none";
            document.getElementById("date_row").style.display = "none";
            document.getElementById("del_row").style.display = "none";
            document.getElementById("un_row").style.display = "table-row";
            document.getElementById(cs[0] + 'Button1').style.visibility = 'hidden';
            document.getElementById(cs[0] + 'Button3').style.visibility = 'hidden';
            document.getElementById(cs[0] + "chk_del").checked = false;
            document.getElementById(cs[0] + "chk_add").checked = false;
        }


        function chk_add1() {
            debugger;
            if (document.getElementById(cs[0] + "chk_add").checked == true) {
                document.getElementById(cs[0] + "chk_del").checked = false;
                document.getElementById("rw1").style.display = "table-row";
                document.getElementById("rw2").style.display = "table-row";
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("amount_row").style.display = "table-row";
                document.getElementById("date_row").style.display = "table-row";
                document.getElementById("del_row").style.display = "none";
                document.getElementById("un_row").style.display = "table-row";
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                document.getElementById(cs[0] + "txt_code").value = "";
                document.getElementById(cs[0] + "txt_amount").value = "";
                document.getElementById(cs[0] + 'Button3').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                var selitem = document.getElementById(cs[0] + "cmb_allowance").selectedIndex;
                var givenValue = document.getElementById(cs[0] + "cmb_allowance").options[0].text
                for (var x = 0; x < document.getElementById(cs[0] + "cmb_allowance").length - 1; x++) {
                    if (givenValue == document.getElementById(cs[0] + "cmb_allowance").options[x].text)
                        document.getElementById(cs[0] + "cmb_allowance").selectedIndex = x;
                }
            }
            else {
                document.getElementById(cs[0] + "chk_del").checked = true;
                document.getElementById(cs[0] + "chk_add").checked = false;
                document.getElementById("rw2").style.display = "none"
                document.getElementById("rw1").style.display = "table-row"
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("amount_row").style.display = "none";
                document.getElementById("date_row").style.display = "none";
                document.getElementById("del_row").style.display = "none";
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                document.getElementById("un_row").style.display = "table-row";
                document.getElementById(cs[0] + 'Button3').style.visibility = 'visible';
                document.getElementById(cs[0] + 'Button1').style.visibility = 'hidden';
                document.getElementById(cs[0] + "cmb_allowance").SelectedIndex = "0"
                var selitem = document.getElementById(cs[0] + "cmb_allowance").selectedIndex;
                var givenValue = document.getElementById(cs[0] + "cmb_allowance").options[0].text
                for (var x = 0; x < document.getElementById(cs[0] + "cmb_allowance").length - 1; x++) {
                    if (givenValue == document.getElementById(cs[0] + "cmb_allowance").options[x].text)
                        document.getElementById(cs[0] + "cmb_allowance").selectedIndex = x;
                }
            }
        }


        function chk_del1() {
            debugger;
            if (document.getElementById(cs[0] + "chk_del").checked == true) {
                document.getElementById(cs[0] + "chk_add").checked = false;
                document.getElementById("rw1").style.display = "table-row";
                document.getElementById("rw2").style.display = "none";
                document.getElementById("panel_row").style.display = "none";
                document.getElementById("amount_row").style.display = "none";
                document.getElementById("date_row").style.display = "none";
                document.getElementById("del_row").style.display = "none";
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                document.getElementById("un_row").style.display = "table-row";
                document.getElementById(cs[0] + 'Button3').style.visibility = 'visible';
                document.getElementById(cs[0] + 'Button1').style.visibility = 'hidden';
                document.getElementById(cs[0] + "cmb_allowance").SelectedIndex = "0"
                var selitem = document.getElementById(cs[0] + "cmb_allowance").selectedIndex;
                var givenValue = document.getElementById(cs[0] + "cmb_allowance").options[0].text
                for (var x = 0; x < document.getElementById(cs[0] + "cmb_allowance").length - 1; x++) {
                    if (givenValue == document.getElementById(cs[0] + "cmb_allowance").options[x].text)
                        document.getElementById(cs[0] + "cmb_allowance").selectedIndex = x;
                }
            }
            else {
                document.getElementById(cs[0] + "chk_add").checked = true;
                document.getElementById(cs[0] + "chk_del").checked = false;
                document.getElementById("rw2").style.display = "table-row"
                document.getElementById("rw1").style.display = "table-row"
                document.getElementById("panel_row").style.display = "table-row";
                document.getElementById("amount_row").style.display = "table-row";
                document.getElementById("date_row").style.display = "table-row";
                document.getElementById("del_row").style.display = "none";
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                document.getElementById("un_row").style.display = "table-row";
                document.getElementById(cs[0] + "txt_code").value = "";
                document.getElementById(cs[0] + "txt_amount").value = "";
                document.getElementById(cs[0] + 'Button3').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'Button1').style.visibility = 'visible';
                document.getElementById(cs[0] + "cmb_allowance").SelectedIndex = "0"
                var selitem = document.getElementById(cs[0] + "cmb_allowance").selectedIndex;
                var givenValue = document.getElementById(cs[0] + "cmb_allowance").options[0].text
                for (var x = 0; x < document.getElementById(cs[0] + "cmb_allowance").length - 1; x++) {
                    if (givenValue == document.getElementById(cs[0] + "cmb_allowance").options[x].text)
                        document.getElementById(cs[0] + "cmb_allowance").selectedIndex = x;
                }
            }
        }
        function all_select() {
            if (document.getElementById(cs[0] + "chk_del").checked == true) {

                data = document.getElementById(cs[0] + "cmb_allowance").value;
                if (data != 0) {
                    data = data + "%" + 33;
                    ToServer(data + "#" + 2, 2);
                }
            }
        }
        function display_check() {

            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cs[0] + "Hid_del").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById(cs[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cs[0] + "Hid_del").value.split("!");
            ar = st2.length - 1;
            if (document.getElementById(cs[0] + "Hid_del").value != "")
                document.getElementById("hid_Counter").value = 0


            {
                for (i = 0; i < ar; i++) {
                    document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value) + 1;
                    var coun = document.getElementById("hid_Counter").value;
                    st3 = st2[i].split("*");
                    st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + coun + "</td><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><input type='checkbox' id='chkm_" + i + "' name='txtm_" + i + "'></td></tr>"
                }
                st = st + "<table border=1 style='width:775px; height: 36px; text-align:left'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>SLNO</b></td><td><b>&nbsp;EMP CODE&nbsp;</b></td><td><b>&nbsp;EMP NAME &nbsp;</b></td><td><b>&nbsp;AMOUNT &nbsp;</b></td><td><b>&nbsp;MARK TO DELETE </b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "table-row";
            }
            document.getElementById(cs[0] + "Panel1").innerHTML = st1;
            document.getElementById(cs[0] + "Panel1").style.height = 45 * ar;
        }





        function Button2_onclick() {
            window.open('../home.aspx', '_self')
        }
        var cs = loanno.split('txt')

        function btn_okonclick() {
            if (document.getElementById(cs[0] + "txt_code").value == "") {
                alert('Please Enter Emp Code');
                document.getElementById(cs[0] + "txt_code").focus();
                return false;
            }
            document.getElementById("amount_row").style.display = "table-row";
            document.getElementById("date_row").style.display = "table-row";
            data = document.getElementById(cs[0] + "txt_code").value;
            data = data + "%" + 22;
            ToServer(data + "#" + 1, 1);

        }

        function FromServer(arg, context) {
            var Data = arg.split("@");
            debugger;
            if (context == 1) {

                document.getElementById(cs[0] + "hidden1").value = arg;
                if (document.getElementById(cs[0] + "hidden1").value == "") {
                    alert('No Details to Display / Employee is not Live');
                    document.getElementById(cs[0] + "txt_code").focus();
                    document.getElementById("amount_row").style.display = "none";
                    document.getElementById("date_row").style.display = "none";

                }
                disp();

            }
            else if (context == 2) {
                document.getElementById(cs[0] + "Hid_del").value = arg;
                if (document.getElementById(cs[0] + "Hid_del").value == "") {
                    alert('No Details to Delete / Employee is not Live');
                    document.getElementById("amount_row").style.display = "none";
                    document.getElementById("date_row").style.display = "none";

                }
                display_check();
            }
            else if (context == 3) {
                var msg
                if (arg != "") {
                    msg = arg;
                }
                else {
                    msg = "Something went Wrong.. Try again";
                }
                alert(msg);
            }
        }
        function disp() {

            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cs[0] + "hidden1").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById(cs[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cs[0] + "hidden1").value.split("@")
            ar = st2.length - 1;
            if (document.getElementById(cs[0] + "hidden1").value != "") {
                for (i = 0; i < ar; i++) {
                    st3 = st2[i].split("!")
                    st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td></tr>"

                }
                st = st + "<table border=1 style='width:775px; height: 36px; text-align:left'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>EMP CODE</b></td><td><b>NAME</b></td><td><b>POST</b></td><td><b>DESIGNATION</b></td><td><b>BRANCH</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "table-row";
            }
            document.getElementById(cs[0] + "Panel1").innerHTML = st1;
            document.getElementById(cs[0] + "Panel1").style.height = 45 * ar;
        }
        function del(id) {
            var at = "";
            var rid;
            ar = document.getElementById(cs[0] + "hidden1").value.split("!")
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
            document.getElementById(cs[0] + "hidden1").value = at
            disp(document.getElementById(cs[0] + "hidden1").value)
        }



        function isNumberKey(ids) {
            var charcode = (event.which) ? event.which : event.keyCode
            if (ids == 1) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32)) {
                    return true;
                }
                else
                    return false;
            }
            if (ids == 2) {
                if ((charcode > 96 && charcode < 127) || (charcode < 91 && charcode > 64) || (charcode == 32) || (charcode > 46 && charcode < 58)) {
                    return true;
                }
                else
                    return false;
            }

            if (ids == 3) {
                if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                    return false;
                }
                else
                    return true;
            }

        }

        function Numberonly(Control) {
            if (isNaN(document.getElementById(cs[0] + Control).value)) {
                document.getElementById(cs[0] + Control).value = "";
                return false;
            }
        }


        function OnkeyUpChqDate(Control) {
            if (document.getElementById(cs[0] + Control).value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cs[0] + Control).value = document.getElementById(cs[0] + "hdn_sysdate").value;
            }
        }





        function delconfirm() {
            var selitem = document.getElementById(cs[0] + "cmb_allowance").value;
            var Flag = confirm("Are You Sure to Confirm");
            if (Flag == true) {
                document.getElementById(cs[0] + "Hidden4").value = "";

                if (document.getElementById(cs[0] + "hid_del").value != "") {
                    var st3 = "";
                    st2 = document.getElementById(cs[0] + "hid_del").value.split("!")
                    ar = st2.length
                    for (i = 0; i < ar - 1; i++) {
                        st3 = st2[i].split("*")
                        var Regular = "T";
                        if (document.getElementById("chkm_" + i + "").checked == false) Regular = "F";
                        document.getElementById(cs[0] + "Hidden4").value += st3[0] + "^" + st3[1] + "^" + st3[2] + "^" + Regular + "$";
                    }
                }
                var Dataa = document.getElementById(cs[0] + "Hidden4").value;
                data = selitem + "@" + Dataa + "%" + 44;
                ToServer(data + "#" + 3, 3);
            }
            if (Flag == false) {
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center; height: 250" id="hidden4">
        <table border="1" style="width: 47%; height: 56px; text-align: left">
            <tr style="background-color: #CCCCEE;">
                <td style="width: 20%; text-align: right">
                    <asp:CheckBox ID="chk_add" runat="server" Text="ADD" Font-Bold="True" ForeColor="Black" /></td>
                <td colspan="2" style="text-align: center">
                    <asp:CheckBox ID="chk_del" runat="server" Text="DELETE" Font-Bold="True" ForeColor="Black" /></td>
            </tr>
            <tr id="rw1">
                <td style="width: 20%; text-align: right;">Select Allowance&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_allowance" runat="server" Width="264px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="rw2">
                <td style="width: 20%; text-align: right; height: 28px;">Emp Code&nbsp;
                </td>
                <td style="width: 20%; text-align: left; height: 28px;">
                    <asp:TextBox ID="txt_code" onkeypress="return isNumberKey(3)" runat="server" Width="181px" MaxLength="6"></asp:TextBox></td>
                <td style="width: 5%; text-align: left; height: 28px;">
                    <input id="btn_ok" style="width: 42px" onclick="btn_okonclick()" type="button" value="OK" /></td>
            </tr>
            <tr id="panel_row" style="display: none;">
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" Height="60px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="amount_row" style="display: none;">
                <td style="width: 20%; text-align: right">Amount&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_amount" onfocusout="Numberonly('txt_amount')" runat="server" Width="181px" MaxLength="6" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <tr id="date_row" style="display: none;">
                <td style="width: 20%; text-align: right">Effective Date&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_date" runat="server" Width="181px" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr id="del_row">
                <td colspan="3" style="text-align: center"></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">&nbsp;<asp:Button ID="Button1" runat="server" Text="Confirm" /><asp:Button ID="Button3" runat="server" Text="Confirm" OnClientClick="delconfirm()" /><input id="Button2" runat="server" style="width: 65px" type="button" value="Exit" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr id="un_row">
                <td style="height: 23px;" colspan="3"></td>
            </tr>
        </table>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_date"></cc1:CalendarExtender>
        <asp:HiddenField ID="hdn_sysdate" runat="server" />
        &nbsp;
        &nbsp;&nbsp;
        <input id="hid_key" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_Counter" style="width: 1px" type="hidden" />
        <input id="Hid_del" runat="server" style="width: 1px" type="hidden" />
        <input id="Hidden4" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_rep" runat="server" style="width: 1px" type="hidden" />
        <input id="hidden1" runat="server" style="width: 1px" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
</asp:Content>

