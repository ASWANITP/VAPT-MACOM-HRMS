<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="comp_new_add.aspx.vb" Inherits="WebAppHRMS.staffaccount_compensatory_add_new_06608cc45600" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        //return window_onload();
        window.onload = callback;
        function callback() {
            return window_onload();
        }
        // ]]>
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cs = cont_name.split("Txt_compen");

        function cmd_ext_onclick() {
            window.open('../../home.aspx', '_self');
        }
        function listadd() {
            debugger;

            document.getElementById("txt_del").style.display = "inline";
            if (document.getElementById(cs[0] + "chk_state").checked == true) {

                document.getElementById(cs[0] + "chk_dist").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_branch").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_emp").style.visibility = 'hidden';


                if (document.getElementById(cs[0] + "cmb_state").value == -1) {
                    alert("Select State");
                    return false;
                }
                for (b = 0; b < document.getElementById(cs[0] + "ListBox1").options.length; b++) {
                    if (document.getElementById(cs[0] + "ListBox1").options[b].value == document.getElementById(cs[0] + "cmb_state").value) {
                        alert("Already Added");
                        return false;
                    }
                }


                var option1 = document.createElement("OPTION")
                option1.text = option1.text + document.getElementById(cs[0] + "cmb_state").options[document.getElementById(cs[0] + "cmb_state").selectedIndex].text;
                option1.value = document.getElementById(cs[0] + "cmb_state").value;
                if (document.getElementById(cs[0] + "Hidden2").value == "") {
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "cmb_state").value;
                }
                else {

                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "Hidden2").value + "#" + document.getElementById(cs[0] + "cmb_state").value;
                }


                document.getElementById(cs[0] + "ListBox1").options.add(option1);
            }


            if (document.getElementById(cs[0] + "chk_dist").checked == true) {
                document.getElementById(cs[0] + "chk_state").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_branch").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_emp").style.visibility = 'hidden';

                if (document.getElementById(cs[0] + "cmb_dist").value == -1) {


                    alert("Select District");
                    return false;
                }

                for (b = 0; b < document.getElementById(cs[0] + "ListBox1").options.length; b++) {
                    if (document.getElementById(cs[0] + "ListBox1").options[b].value == document.getElementById(cs[0] + "cmb_dist").value) {
                        alert("Already Added");
                        return false;
                    }
                }


                var option1 = document.createElement("OPTION")
                option1.text = option1.text + document.getElementById(cs[0] + "cmb_dist").options[document.getElementById(cs[0] + "cmb_dist").selectedIndex].text;
                option1.value = document.getElementById(cs[0] + "cmb_dist").value;
                if (document.getElementById(cs[0] + "Hidden2").value == "") {
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "cmb_dist").value;
                }
                else {
                    //            
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "Hidden2").value + "#" + document.getElementById(cs[0] + "cmb_dist").value;
                }


             document.getElementById(cs[0] + "ListBox1").options.add(option1);
            }




            if (document.getElementById(cs[0] + "chk_branch").checked == true) {
                document.getElementById(cs[0] + "chk_state").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_emp").style.visibility = 'hidden';
                if (document.getElementById(cs[0] + "cmb_branch").value == -1) {
                    alert("Select Branch");
                    return false;
                }
                for (b = 0; b < document.getElementById(cs[0] + "ListBox1").options.length; b++) {
                    if (document.getElementById(cs[0] + "ListBox1").options[b].value == document.getElementById(cs[0] + "cmb_branch").value) {
                        alert("Already Added");
                        return false;
                    }
                }


                var option1 = document.createElement("OPTION")
                option1.text = option1.text + document.getElementById(cs[0] + "cmb_branch").options[document.getElementById(cs[0] + "cmb_branch").selectedIndex].text;
                option1.value = document.getElementById(cs[0] + "cmb_branch").value;
                if (document.getElementById(cs[0] + "Hidden2").value == "") {
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "cmb_branch").value;
                }
                else {
                    //            
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "Hidden2").value + "#" + document.getElementById(cs[0] + "cmb_branch").value;
                }


                document.getElementById(cs[0] + "ListBox1").options.add(option1);
            }
            if (document.getElementById(cs[0] + "chk_emp").checked == true)
            {
                document.getElementById(cs[0] + "chk_state").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_branch").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").style.visibility = 'hidden';




                if (document.getElementById(cs[0] + "cmb_emp").value == -1) {
                    alert("Select Employee");
                    return false;
                }
                // document.getElementById("r3").style.display="inline";
                // document.getElementById("r4").style.display="inline";

                for (b = 0; b < document.getElementById(cs[0] + "ListBox1").options.length; b++) {
                    if (document.getElementById(cs[0] + "ListBox1").options[b].value == document.getElementById(cs[0] + "cmb_emp").value) {
                        alert("Already Added");
                        return false;
                    }
                }


                var option1 = document.createElement("OPTION")
                option1.text = option1.text + document.getElementById(cs[0] + "cmb_emp").options[document.getElementById(cs[0] + "cmb_emp").selectedIndex].text;
                option1.value = document.getElementById(cs[0] + "cmb_emp").value;
                if (document.getElementById(cs[0] + "Hidden2").value == "") {
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "cmb_emp").value;
                }
                else {
                    //            
                    document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "Hidden2").value + "#" + document.getElementById(cs[0] + "cmb_emp").value;
                }


                document.getElementById(cs[0] + "ListBox1").options.add(option1);
            }

        }




        function del() {
            debugger;
            var count;
            for (count = document.getElementById(cs[0] + "ListBox1").options.length - 1; count >= 0; count--) {
                if (document.getElementById(cs[0] + "ListBox1").options[count].selected) {
                    var ar = document.getElementById(cs[0] + "Hidden2").value.split("#")
                    document.getElementById(cs[0] + "Hidden2").value = ""
                    for (n = 0; n < ar.length; n++) {
                        if (ar[n] != document.getElementById(cs[0] + "ListBox1").options[count].value) {
                            if (document.getElementById(cs[0] + "Hidden2").value == "") {
                                document.getElementById(cs[0] + "Hidden2").value = ar[n]
                            }
                            else {
                                document.getElementById(cs[0] + "Hidden2").value = document.getElementById(cs[0] + "Hidden2").value + "#" + ar[n]
                            }
                        }
                    }
                    document.getElementById(cs[0] + "ListBox1").remove(count);

                }
            }


            if (document.getElementById(cs[0] + "ListBox1").options.length == 0) {
                document.getElementById("txt_del").style.display = "none";
                document.getElementById(cs[0] + "chk_state").style.visibility = 'visible';
                document.getElementById(cs[0] + "chk_dist").style.visibility = 'visible';
                document.getElementById(cs[0] + "chk_branch").style.visibility = 'visible';
                document.getElementById(cs[0] + "chk_emp").style.visibility = 'visible';
            }
            else {
                document.getElementById("txt_del").style.display = "inline";
            }
        }
        function fill() {
            debugger;
            if (document.getElementById(cs[0] + "Hidden2").value == "") {
                if (document.getElementById(cs[0] + "chk_state").checked == true) {
                    alert("Add states");

                }
                if (document.getElementById(cs[0] + "chk_dist").checked == true) {
                    alert("Add Districts");
                }
                if (document.getElementById(cs[0] + "chk_zone").checked == true) {
                    alert("Add Zones");
                }
                if (document.getElementById(cs[0] + "chk_area").checked == true) {
                    alert("Add Areas");
                }
                if (document.getElementById(cs[0] + "chk_region").checked == true) {
                    alert("Add Region");
                }
                if (document.getElementById(cs[0] + "chk_branch").checked == true) {
                    alert("Add Branches");
                }
                if (document.getElementById(cs[0] + "chk_emp").checked == true) {
                    alert("Add Employees");
                }

                return false;
            }

            var ans = confirm('Are you Sure To Proceed?')
            if (ans == false) {
                return false;
            }
        }

        function da(a) {
            alert('Please Enter Date using Calendar!!');
            document.getElementById(cs[0] + a).value = "";

        }

        function checkDate(a) {
            var day1, day2;
            var month1, month2;
            var year1, year2;

            value1 = document.getElementById(cs[0] + a).value;
            value2 = new Date().format("dd/MM/yyyy");

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
                alert("Please Select Future Date");
                document.getElementById(cs[0] + a).value = "";
                return false;
            }
        }

        function window_onload() {
            debugger;
            var access = document.getElementById(cs[0] + "hid_access").value
            if (access == 1) {
                document.getElementById(cs[0] + "lbl_msg").style.visibility = 'hidden';
                var str = document.getElementById(cs[0] + "Hidden2").value;
                if (str == "") {
                    document.getElementById("rw2").style.display = "none"
                    document.getElementById("rw1").style.display = "none"
                    document.getElementById("txt_del").style.display = "none";
                    document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                    document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                    document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                    document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                    document.getElementById(cs[0] + "chk_assigncomp").checked = false;
                    document.getElementById(cs[0] + "chk_addcomp").checked = false;
                }
                else {
                    document.getElementById("rw1").style.display = "none"
                    var data
                    data = document.getElementById(cs[0] + "hid_load").value.split("*");
                    if (data[1] == 3) {
                        document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'visible';
                        document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                    }
                    else if (data[1] == 1) {
                        document.getElementById(cs[0] + 'cmb_state').style.visibility = 'visible';
                        document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                    }
                    else if (data[1] == 2) {
                        document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'visible';
                        document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                    }
                    else if (data[1] == 4) {
                        document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'visible';
                        document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                        document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                    }



                }
            }
            else {
                document.getElementById("rw2").style.display = "none"
                document.getElementById("rw1").style.display = "none"
                document.getElementById("txt_del").style.display = "none";
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_assigncomp").style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_addcomp").style.visibility = 'hidden';
                document.getElementById("chk_row").style.display = "none"
                document.getElementById(cs[0] + "lbl_msg").style.visibility = 'visible';
            }
        }
        function chk_add() {
            debugger;
            if (document.getElementById(cs[0] + "chk_assigncomp").checked == true) {
                document.getElementById(cs[0] + "chk_addcomp").checked = false;
                document.getElementById("rw2").style.display = "inline"
                document.getElementById("rw1").style.display = "none"
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").checked = false;
                document.getElementById(cs[0] + "chk_branch").checked = false;
                document.getElementById(cs[0] + "chk_state").checked = false;
                document.getElementById(cs[0] + "chk_emp").checked = false;
                ToServer(1, 1);
            }
            else {
                document.getElementById(cs[0] + "chk_addcomp").checked = true;
                document.getElementById(cs[0] + "chk_assigncomp").checked = false;
                document.getElementById("rw2").style.display = "none"
                document.getElementById("rw1").style.display = "inline"
            }


        }
        function chk_add1() {
            if (document.getElementById(cs[0] + "chk_addcomp").checked == true) {
                document.getElementById(cs[0] + "chk_assigncomp").checked = false;
                document.getElementById("rw2").style.display = "none"
                document.getElementById("rw1").style.display = "inline"
                document.getElementById(cs[0] + "Txt_compen").value = "";
            }
            else {
                document.getElementById(cs[0] + "chk_assigncomp").checked = true;
                document.getElementById(cs[0] + "chk_addcomp").checked = false;

                document.getElementById("rw2").style.display = "inline"
                document.getElementById("rw1").style.display = "none"
            }
        }
        function chkstatus() {
            debugger;
            if (document.getElementById(cs[0] + "chk_state").checked == true) {
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'visible';
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").checked = false;
                document.getElementById(cs[0] + "chk_branch").checked = false;
                document.getElementById(cs[0] + "chk_emp").checked = false;
            }
            else {
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_state").checked = false;
            }
        }

        function chkstatus1() {
            debugger;
            if (document.getElementById(cs[0] + "chk_emp").checked == true) {
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'visible';
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").checked = false;
                document.getElementById(cs[0] + "chk_branch").checked = false;
                document.getElementById(cs[0] + "chk_state").checked = false;
            }
            else {
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_emp").checked = false;
            }
        }

        function chkstatus2() {
            debugger;

            if (document.getElementById(cs[0] + "chk_dist").checked == true) {
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'visible';
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_state").checked = false;
                document.getElementById(cs[0] + "chk_branch").checked = false;
                document.getElementById(cs[0] + "chk_emp").checked = false;
            }
            else {
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").checked = false;
            }
        }

        function chkstatus3() {
            debugger;

            if (document.getElementById(cs[0] + "chk_branch").checked == true) {
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'visible';
                document.getElementById(cs[0] + 'cmb_dist').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_state').style.visibility = 'hidden';
                document.getElementById(cs[0] + 'cmb_emp').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_dist").checked = false;
                document.getElementById(cs[0] + "chk_state").checked = false;
                document.getElementById(cs[0] + "chk_emp").checked = false;
            }
            else {
                document.getElementById(cs[0] + 'cmb_branch').style.visibility = 'hidden';
                document.getElementById(cs[0] + "chk_branch").checked = false;
            }

        }

        function validate(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            if (!(keycode == 8 || keycode == 32 || keycode == 40 || keycode == 41 || keycode == 45 || keycode == 47) && (keycode < 48 || keycode > 57) && (keycode < 65 || keycode > 90) && (keycode < 97 || keycode > 122)) {
                return false;
            }

        }
        function FromServer(arg, context) {
            debugger;
            if (context == 1) {
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_dt"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_exdt"></cc1:CalendarExtender>
        <%--<cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_area">
        </cc1:ListSearchExtender>--%>
        <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_branch">
        </cc1:ListSearchExtender>
        <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_dist">
        </cc1:ListSearchExtender>
        <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_emp">
        </cc1:ListSearchExtender>
        <%-- <cc1:ListSearchExtender ID="ListSearchExtender5" runat="server" TargetControlID="cmb_region">
        </cc1:ListSearchExtender>--%>
        <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_state">
        </cc1:ListSearchExtender>
        <%--<cc1:ListSearchExtender ID="ListSearchExtender7" runat="server" TargetControlID="cmb_zone">
        </cc1:ListSearchExtender>--%>
        <cc1:ListSearchExtender ID="ListSearchExtender8" runat="server" TargetControlID="cmb_comp">
        </cc1:ListSearchExtender>

        <table border="1" style="width: 650px; height: 251px">
            <tr id="chk_row" style="background-color: GrayText">
                <td colspan="2" style="font-family: 'Courier New'; text-align: right">
                    <asp:CheckBox ID="chk_addcomp" runat="server" Font-Bold="True" ForeColor="white"
                        Text="ADD COMPENSATORY" Width="200px" /></td>
                <td colspan="2" style="width: 265px; font-family: Times New Roman; text-align: left">
                    <asp:CheckBox ID="chk_assigncomp" runat="server" Font-Bold="True"
                        Font-Names="Courier New" Font-Size="12pt" ForeColor="white" Text="ASSIGN COMPENSATORY"
                        Width="234px" /></td>
            </tr>
            <tr>
                <td colspan="4" style="font-family: 'Courier New'; height: 33px; text-align: right">
                    <div style="text-align: center">
                        <table border="1" style="width: 640px" id="rw1">
                            <tr>
                                <td style="width: 100px; height: 22px">
                                    <strong>Enter Compensatory</strong></td>
                                <td style="width: 94px; height: 22px; text-align: left">
                                    <asp:TextBox ID="Txt_compen" runat="server" Width="377px" onkeypress="return validate(event)" onpaste="return false" MaxLength="50"></asp:TextBox></td>
                                <td style="width: 100px; height: 22px">
                                    <asp:Button ID="cmd_addc" runat="server" Text="ADD" Width="96px" BackColor="white" Font-Bold="True" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-family: 'Courier New'; text-align: center">
                    <table border="1" style="width: 590px; height: 251px" id="rw2">
                        <tr>
                            <td colspan="2" style="font-family: 'Courier New'; text-align: right">
                                <strong>Select&nbsp; Compensatory</strong></td>
                            <td colspan="2" style="font-family: Times New Roman; text-align: left">
                                <asp:DropDownList ID="cmb_comp" runat="server" Width="340px" Style="font-family: 'Courier New'">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 687px; text-align: right; height: 26px;">
                                <span style="font-family: Courier New"><strong>Comp.Date</strong></span></td>
                            <td style="width: 50px; font-family: Times New Roman; height: 26px;">
                                <asp:TextBox ID="txt_dt" runat="server" onkeyup="da('txt_dt')" Style="font-family: 'Courier New'" Width="119px"></asp:TextBox></td>



                            <%--<asp:TextBox ID="TextBox1" runat="server"  onkeyup="da('txt_dt')" onblur="checkDate('txt_dt')" style="font-family: 'Courier New'" Width="119px"></asp:TextBox></td>
                            --%>
                            <td style="width: 100px; font-family: Times New Roman; text-align: right; height: 26px;">
                                <span style="font-family: Courier New"><strong>Expiry&nbsp;Date</strong></span></td>
                            <td style="width: 100px; font-family: Times New Roman; height: 26px;">
                                <asp:TextBox ID="txt_exdt" runat="server" onkeyup="da('txt_exdt')" onblur="checkDate('txt_exdt')" Width="109px" Style="font-family: 'Courier New'"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 687px; text-align: left">
                                <asp:CheckBox ID="chk_state" runat="server" Text="Select States" Width="225px" /><span style="font-family: Courier New"></span></td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_state" runat="server" Width="340px" Style="font-family: 'Courier New'">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 687px; text-align: left">
                                <asp:CheckBox ID="chk_dist" runat="server" Text="Select Districts" Width="229px" /></td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_dist" runat="server" Width="340px" Style="font-family: 'Courier New'">
                                </asp:DropDownList></td>
                        </tr>
                        <%--<%--<tr>
                <td colspan="2" style="width: 687px; text-align: left">
                    <asp:CheckBox ID="chk_zone" runat="server" Text="Select Zones" Width="231px" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_zone" runat="server"  Width="340px" style="font-family: 'Courier New'">
                    </asp:DropDownList></td>
                        </tr>
                        <tr>
                <td colspan="2" style="width: 687px; text-align: left">
                    <asp:CheckBox ID="chk_area" runat="server" Text="Select Areas" Width="229px" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_area" runat="server"  Width="340px" style="font-family: 'Courier New'">
                    </asp:DropDownList></td>
                        </tr>
                        <tr>
                <td colspan="2" style="width: 687px; text-align: left">
                    <asp:CheckBox ID="chk_region" runat="server" Text="Select Regions" Width="199px" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_region" runat="server"  Width="340px" style="font-family: 'Courier New'">
                    </asp:DropDownList></td>
                        </tr>
                        --%>
                        &nbsp;<tr>
                            <td colspan="2" style="width: 687px; text-align: left">
                                <asp:CheckBox ID="chk_branch" runat="server" Text="Select Branches" Width="209px" /></td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_branch" runat="server" Width="340px" Style="font-family: 'Courier New'">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 687px; text-align: left">
                                <asp:CheckBox ID="chk_emp" runat="server" Text="Select Employee Codes" Width="237px" /></td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_emp" runat="server" Width="340px" Style="font-family: 'Courier New'">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <input id="cmd_insert" type="button" onclick="listadd()" value="INSERT" style="font-family: 'Courier New'; font-weight: bold; background-color: gainsboro;" />
                                <input id="txt_del" type="button" onclick="del()" value="DELETE" style="font-family: 'Courier New'; font-weight: bold; background-color: gainsboro;" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:ListBox ID="ListBox1" runat="server" Width="582px" AppendDataBoundItems="True" Style="font-family: 'Verdana'" BackColor="GrayText" Font-Bold="True" ForeColor="white" Font-Size="Medium" Rows="6"></asp:ListBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center; height: 28px;">&nbsp;<asp:Button ID="cmd_confirm" runat="server" OnClientClick="return fill()" Text="CONFIRM" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" Width="98px" />&nbsp;</td>
                        </tr>
                    </table>
                    <div style="text-align: center">

                        <asp:Label ID="lbl_msg" runat="server" Text="You Are Not authorized" Font-Bold="True" Font-Names="Verdana" Font-Size="Larger" ForeColor="Red" Width="424px"></asp:Label>
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <input id="cmd_ext" style="width: 70px; font-family: 'Courier New'; font-weight: bold; background-color: gainsboro;" type="button" value="EXIT" onclick="return cmd_ext_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <input id="hid_details" style="width: 5px" type="hidden" runat="server" />
    <input id="Hidden2" runat="server" style="width: 1px" type="hidden" />
    <input id="hid_load" runat="server" style="width: 8px" type="hidden" />
    <input id="hid_access" runat="server" style="width: 8px" type="hidden" />
</asp:Content>
