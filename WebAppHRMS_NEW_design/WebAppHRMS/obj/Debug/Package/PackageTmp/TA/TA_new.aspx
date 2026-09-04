<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="TA_new.aspx.vb" Inherits="WebAppHRMS.TA_TA_new_d8ccc1921082" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 8) || (charCode == 32))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }
        function isNumberKey(evt, element) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 8))
                return false;
        }
        objec = obj_name.split('txt');
        function checkDate(sender, args) {
            // I change the < operator to >
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a day earlier than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }
        function btn_exit_onclick() {
            window.open('../Home.aspx', '_self');
        }
        function caluculate_fare() {
            var k = document.getElementById('txt_km').value;
            var rt = document.getElementById('txt_rate').value;
            var fr;
            fr = k * rt;
            document.getElementById('txt_fare').value = fr;
        }
        function caluculate_fr() {
            var k = document.getElementById('txt_km').value;
            var rt = document.getElementById('txt_rate').value;
            var fr;
            fr = k * rt;
            document.getElementById('txt_fare').value = fr;
        }
        function caluculate_ta() {
            var rr = parseInt(document.getElementById('txt_fare').value);
            var bat = parseInt(document.getElementById('txt_bata').value);
            var ta;
            ta = parseInt(rr + bat);
            document.getElementById('txt_totta').value = parseInt(ta);
        }
        function calculate_totta() {
            var rr = parseInt(document.getElementById('txt_fare').value);
            var bat = parseInt(document.getElementById('txt_bata').value);
            if (bat = "NaN") {
                var bat = 0;
                var ta;
                ta = parseInt(rr + bat);
                document.getElementById('txt_totta').value = parseInt(ta);
            }
            else {
                var ta;
                ta = parseInt(rr + bat);
                document.getElementById('txt_totta').value = parseInt(ta);
            }
        }
        var ak = [];
        function fill_tab() {
            var emp = document.getElementById(objec[0] + 'txt_empcode').value;
            if (emp == "") {
                alert(" Enter employeecode ");
                return false;
            }
            var dat = document.getElementById(objec[0] + 'txt_date').value;
            if (dat == "") {
                alert(" Select date ");
                return false;
            }
            var dis = document.getElementById(objec[0] + 'txt_nmdis').value;
            if (dis == "") {
                alert(" Enter District");
                return false;
            }
            var frm = document.getElementById(objec[0] + 'txt_frmpl').value;
            if (frm == "") {
                alert(" Enter From Place");
                return false;
            }
            var top = document.getElementById(objec[0] + 'txt_topl').value;
            if (top == "") {
                alert(" Enter To Place");
                return false;
            }
            var firm = "<%=txt_firm.ClientID %>";
            var fm = document.getElementById(objec[0] + 'txt_firm').value;
            if (fm == "") {
                alert(" Enter Firm");
                return false;
            }
            var k = document.getElementById('txt_km').value;
            if (k == "") {
                alert(" Enter km");
                return false;
            }
            var rt = document.getElementById('txt_rate').value;
            if (rt == "") {
                alert(" Enter rate");
                return false;
            }
            var fr = document.getElementById('txt_fare').value;
            var bt = document.getElementById('txt_bata').value;
            var tot = document.getElementById('txt_totta').value;

            var dt;
            var st;
            var hid = document.getElementById(objec[0] + 'hid_details').value;
            if (hid != "") {
                dt = hid.split("$");
                for (i = 0; i < dt.length - 1; i++) {
                    st = dt[i].split("#");
                }
            }
            if (hid == "") {
                hid = emp + "#" + dat + "#" + dis + "#" + frm + "#" + top + "#" + fm + "#" + k + "#" + rt + "#" + fr + "#" + bt + "#" + tot;
            }
            else {
                hid = emp + "#" + hid + "#" + dat + "#" + dis + "#" + frm + "#" + top + "#" + fm + "#" + k + "#" + rt + "#" + fr + "#" + bt + "#" + tot;
            }

            disp(hid)
        }
        function disp(data) {
            var dt;
            var st;
            var hidfield = data;

            if (hidfield != "") {
                var tabledata = {
                    "emp": "",
                    "date": "",
                    "district": "",
                    "fromplace": "",
                    "toplace": "",
                    "firm": "",
                    "km": "",
                    "rate": "",
                    "fare": "",
                    "bata": "",
                    "totta": ""
                };
                dt = hidfield.split("#");
               /* -------------------VAPT HTML INJECTION---------------*/
                tabledata.emp = validateField(dt[0]);
                tabledata.date = validateField(dt[1]);
                tabledata.district = validateField(dt[2]);
                tabledata.fromplace = validateField(dt[3]);
                tabledata.toplace = validateField(dt[4]);
                tabledata.firm = validateField(dt[5]);

                // numeric fields: validate as numbers
                tabledata.km = Number(dt[6]) || null;
                tabledata.rate = Number(dt[7]) || null;
                tabledata.fare = Number(dt[8]) || null;
                tabledata.bata = Number(dt[9]) || null;
                tabledata.totta = Number(dt[10]) || null;
               /* -------------------------------------------------------*/
                ak.push(tabledata);
                tab = "<table align=center width=500px border=1><tr style='color: Blue'><td colspan=11 align=center><b>Movement&nbsp;Chart</b></td></tr>"
                tab = tab + "<tr><td><b>Emp&nbsp;Code</b></td><td><b>Date</b></td><td><b>District</b></td><td><b>From&nbsp;Place</b></td><td><b>To&nbsp;Place</b></td><td><b>Firm</b></td><td><b>KM</b></td><td><b>Rate</b></td><td><b>Fare</b></td><td><b>Bata</b></td><td><b>Total&nbsp;TA</b></td>"
                for (i = 0; i < ak.length; i++) {
                    tab = tab + "<tr><td>" + ak[i].emp + "</td><td>" + ak[i].date + "</td><td>" + ak[i].district + "</td><td>" + ak[i].fromplace + "</td><td>" + ak[i].toplace + "</td><td>" + ak[i].firm + "</td><td>" + ak[i].km + "</td><td>" + ak[i].rate + "</td><td>" + ak[i].fare + "</td><td>" + ak[i].bata + "</td><td>" + ak[i].totta + "</td><td><a href=javascript:del('" + i + "')>del</td></tr>"

                    if (i == ak.length - 1) {
                        var totalvalue = 0;


                        for (var j = 0; j < ak.length; j++) {
                            totalvalue = totalvalue + parseInt(ak[j].totta);
                        }

                        tab = tab + "<tfoot><tr><td>Total TA : </td><td>" + totalvalue + "</td></tr></tfoor>";

                    }

                }

                document.getElementById(objec[0] + "Panel1").innerHTML = tab;
                document.getElementById(objec[0] + 'txt_date').value = "";
                document.getElementById(objec[0] + 'txt_nmdis').value = "";
                document.getElementById(objec[0] + 'txt_frmpl').value = "";
                document.getElementById(objec[0] + 'txt_topl').value = "";
                document.getElementById(objec[0] + 'txt_firm').value = "";
                document.getElementById('txt_km').value = "";
                document.getElementById('txt_rate').value = "";
                document.getElementById('txt_fare').value = "";
                document.getElementById('txt_bata').value = "";
                document.getElementById('txt_totta').value = "";
            }

        }
        /*---------------------VAPT HTML INJECTION-----------------*/
        function validateField(input) {
            // Only check strings; numbers are fine
            if (typeof input !== "string") return input;

            // Regex to detect special HTML characters
            const forbiddenPattern = /[<>"'&]/;

            // If any forbidden character exists, return null
            if (forbiddenPattern.test(input)) {
                return null;
            }

            return input;
        }
        //-------------------------------------------------
        function del(id) {
            ak.splice(id, 1);

            tab = "<table align=center width=500px border=1><tr style='color: Blue'><td colspan=11 align=center><b>Movement&nbsp;Chart</b></td></tr>"
            tab = tab + "<tr><td><b>Emp&nbsp;Code</b></td><td><b>Date</b></td><td><b>District</b></td><td><b>From&nbsp;Place</b></td><td><b>To&nbsp;Place</b></td><td><b>Firm</b></td><td><b>KM</b></td><td><b>Rate</b></td><td><b>Fare</b></td><td><b>Bata</b></td><td><b>Total&nbsp;TA</b></td>"
            for (i = 0; i < ak.length; i++) {
                tab = tab + "<tr><td>" + ak[i].emp + "</td><td>" + ak[i].date + "</td><td>" + ak[i].district + "</td><td>" + ak[i].fromplace + "</td><td>" + ak[i].toplace + "</td><td>" + ak[i].firm + "</td><td>" + ak[i].km + "</td><td>" + ak[i].rate + "</td><td>" + ak[i].fare + "</td><td>" + ak[i].bata + "</td><td>" + ak[i].totta + "</td><td><a href=javascript:del('" + i + "')>del</td></tr>"
                if (i == ak.length - 1) {
                    var totalvalue = 0;


                    for (var j = 0; j < ak.length; j++) {
                        totalvalue = totalvalue + parseInt(ak[j].totta);
                    }

                    tab = tab + "<tfoot><tr><td>Total TA : </td><td>" + totalvalue + "</td></tr></tfoor>";

                }


            }
            document.getElementById(objec[0] + "Panel1").innerHTML = tab;
            document.getElementById(objec[0] + 'txt_date').value = "";
            document.getElementById(objec[0] + 'txt_nmdis').value = "";
            document.getElementById(objec[0] + 'txt_frmpl').value = "";
            document.getElementById(objec[0] + 'txt_topl').value = "";
            document.getElementById(objec[0] + 'txt_firm').value = "";
            document.getElementById('txt_km').value = "";
            document.getElementById('txt_rate').value = "";
            document.getElementById('txt_fare').value = "";
            document.getElementById('txt_bata').value = "";
            document.getElementById('txt_totta').value = "";
        }
        function fill_dtl() {
            debugger;
            if (ak.length > 0) {
                var confirmstr = "";
                for (var i = 0; i <= ak.length - 1; i++) {
                    if (confirmstr == "") {
                        confirmstr = i + "*" + ak[i].emp + "*" + ak[i].date + "*" + ak[i].district + "*" + ak[i].fromplace + "*" + ak[i].toplace + "*" + ak[i].firm + "*" + ak[i].km + "*" + ak[i].rate + "*" + ak[i].fare + "*" + ak[i].bata + "*" + ak[i].totta + "#";
                    }
                    else {
                        confirmstr = confirmstr + i + "*" + ak[i].emp + "*" + ak[i].date + "*" + ak[i].district + "*" + ak[i].fromplace + "*" + ak[i].toplace + "*" + ak[i].firm + "*" + ak[i].km + "*" + ak[i].rate + "*" + ak[i].fare + "*" + ak[i].bata + "*" + ak[i].totta + "#";
                    }
                }
                var data = call_server(confirmstr);
            }
            else {
                var emp = document.getElementById(objec[0] + 'txt_empcode').value;
                if (emp == "") {
                    alert(" Enter employeecode ");
                    return false;
                }
                var dat = document.getElementById(objec[0] + 'txt_date').value;
                if (dat == "") {
                    alert(" Select date ");
                    return false;
                }
                var dis = document.getElementById(objec[0] + 'txt_nmdis').value;
                if (dis == "") {
                    alert(" Enter District");
                    return false;
                }
                var frm = document.getElementById(objec[0] + 'txt_frmpl').value;
                if (frm == "") {
                    alert(" Enter From Place");
                    return false;
                }
                var top = document.getElementById(objec[0] + 'txt_topl').value;
                if (top == "") {
                    alert(" Enter To Place");
                    return false;
                }
                var firm = "<%=txt_firm.ClientID %>";
                var fm = document.getElementById(objec[0] + 'txt_firm').value;
                if (fm == "") {
                    alert(" Enter Firm");
                    return false;
                }
                var k = document.getElementById('txt_km').value;
                if (k == "") {
                    alert(" Enter km");
                    return false;
                }
                var rt = document.getElementById('txt_rate').value;
                if (rt == "") {
                    alert(" Enter rate");
                    return false;
                }
            }
        }
        function call_receiver(arg1) {
            alert(arg1);
            window.open('../Home.aspx', '_self');
        }
    </script>

    <div class="col-md-12">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row ">
            <div class="ma-header">
                <div class="col-md-12">
                    <h3 style="color: #091221" align="center">
                        <i class="icon-reorder"></i>TRAVEL ALLOWANCE REQUEST</h3>
                </div>
            </div>
        </div>
        <div class="widget box align-center border=1">
            <div class="form-group" align="center">
                <br />
                <div class="col-md-2">
                </div>
                <label class="col-md-2 cntr-text" id="lbl_employee" runat="server">
                    Enter Employee Code</label>
                <asp:TextBox ID="txt_empcode" runat="server" Height="30px" Width="100px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" />
                &nbsp;
            </div>
        </div>
    </div>
    <div runat="server" align="center" id="EditDiv">
        <table border="1" style="width: 40%; height: 40%">
            <tr>
                <th colspan="1" style="text-align: center">Employee Name</th>
                <th colspan="1" style="text-align: center">Department Name</th>
                <th colspan="1" style="text-align: center">Designation</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txt_empname" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_depnm" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_desig" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <div runat="server" align="center" id="Div1">
        <table border="1" style="width: 40%; height: 40%">
            <tr>
                <th colspan="1" style="text-align: center">Native Place</th>
                <th colspan="1" style="text-align: center">Native District</th>
                <th colspan="1" style="text-align: center">Native State</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txt_ntvpl" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_ntvdis" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_ntvstat" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <div runat="server" align="center" id="Div2">
        <table border="1" style="width: 40%; height: 40%">
            <tr>
                <th colspan="1" style="text-align: center">Station Branch</th>
                <th colspan="1" style="text-align: center">Station District</th>
                <th colspan="1" style="text-align: center">Station State</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txt_stsbr" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_stsdis" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_stsstat" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <br />
    <div runat="server" align="center" id="Div3">
        <input id="hid_details" runat="server" style="width: 16px" type="hidden" />
        <table border="1" style="width: 50%; height: 50%">
            <tr>
                <th colspan="1">Date</th>
                <th colspan="1" style="text-align: center;">Name Of District</th>
                <th colspan="1" style="text-align: center">From Place</th>
                <th colspan="1" style="text-align: center">To Place</th>
                <th colspan="1" style="text-align: center">Firm</th>
                <th colspan="1" style="text-align: center">KM</th>
                <th colspan="1" style="text-align: center">Rate</th>
                <th colspan="1" style="text-align: center">Fare</th>
                <th colspan="1" style="text-align: center">Bata</th>
                <th colspan="1" style="text-align: center">Total TA</th>
            </tr>
            <tr>
                <td>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" OnClientDateSelectionChanged="checkDate" Format="dd/MMM/yyyy"
                        TargetControlID="txt_date"></cc1:CalendarExtender>
                    <asp:TextBox ID="txt_date" runat="server" Width="100px" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td style="width: 100%">
                    <asp:TextBox ID="txt_nmdis" runat="server" Width="110px" AutoPostBack="false"  onkeypress="return onlyAlphabets(event,this);" onpaste="return false;"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_frmpl" runat="server" Width="110px" AutoPostBack="false" onkeypress="return onlyAlphabets(event,this);" onpaste="return false;"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_topl" runat="server" Width="110px" AutoPostBack="false" onkeypress="return onlyAlphabets(event,this);" onpaste="return false;"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_firm" runat="server" Width="110px" AutoPostBack="false" onkeypress="return onlyAlphabets(event,this);" onpaste="return false;"></asp:TextBox></td>
                <td>
                    <input type="text" id="txt_km" onchange="return caluculate_fr()" maxlength="4" onkeypress="return isNumberKey(event);" onpaste="return false;"
                        style="width: 90px" /></td>
                <td>
                    <input type="text" id="txt_rate" onchange="return caluculate_fare()" maxlength="4" onkeypress="return isNumberKey(event);" onpaste="return false;"
                        style="width: 90px" /></td>
                <td>
                    <input type="text" id="txt_fare" readonly="readonly" onkeyup="return calculate_totta()"
                        style="width: 90px" /></td>
                <td>
                    <input type="text" id="txt_bata" onchange="return caluculate_ta()" maxlength="4" onkeypress="return isNumberKey(event);" onpaste="return false;"
                        style="width: 90px" /></td>
                <td>
                    <input type="text" id="txt_totta" readonly="readonly" style="width: 110px" /></td>
                <td colspan="5" style="text-align: center; width: 47px;">
                    <input id="btn_add" type="button" value="ADD" onclick="return fill_tab()" style="width: 100px" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table border="1" style="width: 40%; height: 40%" id="tbl_dyn">
            <tr id="row1" runat="server" align="center">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Height="300px" Width="100%" ScrollBars="Auto">
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div runat="server" align="center" id="div4" visible="false">
        <table align="center">
            <tr>
                <td align="center">
                    <b>added&nbsp;details</b></td>
            </tr>
            <asp:GridView ID="grid_view1" runat="server" AutoGenerateColumns="false" DataKeyNames="ta_id"
                OnRowCommand="GridView1_RowCommand" align="center">
                <Columns>
                    <asp:BoundField DataField="ta_id" HeaderText="sl_no" />
                    <asp:BoundField DataField="ta_date" HeaderText="ta date" />
                    <asp:BoundField DataField="district" HeaderText="district" />
                    <asp:BoundField DataField="frm_plc" HeaderText="from place" />
                    <asp:BoundField DataField="to_plc" HeaderText="to place" />
                    <asp:BoundField DataField="firm" HeaderText="firm" />
                    <asp:BoundField DataField="km" HeaderText="km" />
                    <asp:BoundField DataField="rate" HeaderText="rate" />
                    <asp:BoundField DataField="fare" HeaderText="fare" />
                    <asp:BoundField DataField="bata" HeaderText="bata" />
                    <asp:BoundField DataField="total_ta" HeaderText="total ta" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" Text="Del" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div align="center">
        <input id="btn_confirm" type="button" value="CONFIRM" style="width: 80px" onclick="return fill_dtl()" />
        <input id="btn_exit" type="button" value="EXIT" style="width: 80px" onclick="return btn_exit_onclick()" />
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
