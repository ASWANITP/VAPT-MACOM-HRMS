<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_TA_UPDATE_NEW.aspx.vb" Inherits="WebAppHRMS.HRM_JEWEL_TA_KRISHNADAS_e8a008a62815" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">

        return window_onload()
    </script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">
return window_onload()
    </script>
    <script type="text/javascript">

        ////REQ ID==10621=====>JEWEL TA APPLICATION=====>14-DEC-2015 KRISHNADAS

        var source, destination;
        var directionsDisplay;
        var directionsService = new google.maps.DirectionsService();
        google.maps.event.addDomListener(window, 'load', function () {
            new google.maps.places.SearchBox(document.getElementById('txtSource'));
            new google.maps.places.SearchBox(document.getElementById('txtDestination'));
            directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
        });

        function GetRoute() {
            //debugger;
            var actual_source = document.getElementById("txtSource").value;
            var actual_destination = document.getElementById("txtDestination").value;
            if (document.getElementById("txtSource").value == "" || document.getElementById("txtDestination").value == "" || document.getElementById("txtSource").value == "Enter a query" || document.getElementById("txtDestination").value == "Enter a query") {
                alert("Invalid Source or destination");
                return false;
            }
            document.getElementById('<%= hid_distance.ClientID %>').value = 0;
    document.getElementById('<%= hid_distan.ClientID %>').value = "";
    if (document.getElementById('<%= Chk_map.ClientID %>').checked == true) {
                document.getElementById("disp_map").style.display = "inline"
            }
            else {
                document.getElementById("disp_map").style.display = "none"
            }
            var mumbai = new google.maps.LatLng(10.5276416, 76.2144349);
            var mapOptions = {
                zoom: 7,
                center: mumbai
            };
            map = new google.maps.Map(document.getElementById('dvMap'), mapOptions);
            directionsDisplay.setMap(map);
            //directionsDisplay.setPanel(document.getElementById('dvPanel'));

            //*********DIRECTIONS AND ROUTE**********************//
            source = document.getElementById("txtSource").value;
            destination = document.getElementById("txtDestination").value;

            var request = {
                origin: source,
                destination: destination,
                travelMode: google.maps.TravelMode.DRIVING
            };
            directionsService.route(request, function (response, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(response);
                }
            });

            //*********DISTANCE AND DURATION**********************//
            var service = new google.maps.DistanceMatrixService();
            service.getDistanceMatrix({
                origins: [source],
                destinations: [destination],
                travelMode: google.maps.TravelMode.DRIVING,
                unitSystem: google.maps.UnitSystem.METRIC,
                avoidHighways: false,
                avoidTolls: false
            }, function (response, status) {
                if (status == google.maps.DistanceMatrixStatus.OK && response.rows[0].elements[0].status != "ZERO_RESULTS") {
                    var distance = response.rows[0].elements[0].distance.text;
                    var duration = response.rows[0].elements[0].duration.text;
                    var dvDistance = document.getElementById("dvDistance");
                    dvDistance.innerHTML = "";
                    dvDistance.innerHTML += "Distance: " + distance + "<br />";
                    dvDistance.innerHTML += "Duration:" + duration;

                }
                else {
                    alert("Unable to find the distance via road.");
                }
            });

        }

        function chk_add1() {
            //debugger;
            if (document.getElementById('<%= Chk_map.ClientID %>').checked == true) {
                var source = document.getElementById("txtSource").value;
                var destination = document.getElementById("txtDestination").value;
                if (source != "" && destination != "") {
                    document.getElementById("maintab").style.height = "250px";
                    GetRoute();
                }
            }
            else {
                if (document.getElementById("disp_map").style.display == "inline") {
                    document.getElementById("maintab").style.height = "120px";
                    document.getElementById("disp_map").style.display = "none"
                }
            }
        }

        function window_onload() {
            //debugger;
            document.getElementById("disp_map").style.display = "none"
            document.getElementById("maintab").style.height = "128px";
            document.getElementById('<%= label8.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= label10.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= txt_purpose.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= txt_amnt.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= hid_distance.ClientID %>').value = 0;
    document.getElementById('<%= hid_info.ClientID %>').value = "";
    document.getElementById('<%= hid_distan.ClientID %>').value = "";
    document.getElementById('<%= hid_total.ClientID %>').value = "";
    document.getElementById('<%= hid_real.ClientID %>').value = "";
    document.getElementById('<%= txt_empcode.ClientID %>').focus();

        }

        function EmpNameFind() {

            if (document.getElementById('<%= txt_empcode.ClientID %>').value == "" || parseInt(document.getElementById('<%= txt_empcode.ClientID %>').value) < 9999) {
        alert('Please Enter a Valid Employee Code..!!');
        document.getElementById('<%= txt_empcode.ClientID %>').value = "";
       document.getElementById('<%= hidempcode.ClientID %>').value = 0;
       document.getElementById('<%= txt_empcode.ClientID %>').focus();
       document.getElementById('<%= txt_empname.ClientID %>').value = "";
       document.getElementById("txtSource").value = "";
       document.getElementById("txtDestination").value = "";

       return false;
   }
   else {
       if (document.getElementById('<%= txt_empcode.ClientID %>').value != document.getElementById('<%= hid_userid.ClientID %>').value) {
           alert('Please Enter Own Employee Code..!!');
           document.getElementById('<%= txt_empcode.ClientID %>').value = "";
         document.getElementById('<%= hidempcode.ClientID %>').value = 0;
         document.getElementById('<%= txt_empcode.ClientID %>').focus();
         document.getElementById('<%= txt_empname.ClientID %>').value = "";
         document.getElementById("txtSource").value = "";
         document.getElementById("txtDestination").value = "";
         return false;
     }
     else {
         var data
         document.getElementById('<%= hidempcode.ClientID %>').value = document.getElementById('<%= txt_empcode.ClientID %>').value;
         data = document.getElementById('<%= hidempcode.ClientID %>').value
                    data = data + "%" + 22;
                    ToServer(data + "#" + 1, 1);
                }
            }
        }
        function EmpCodeKeyUp() {
            document.getElementById('<%= hidempcode.ClientID %>').value = 0;
    var a = document.getElementById('<%= txt_empcode.ClientID %>').value;
    if (isNaN(a)) {
        alert('Please enter correct Employee Code in number Format!!');
        document.getElementById('<%= txt_empcode.ClientID %>').value = "";
       document.getElementById('<%= txt_empcode.ClientID %>').focus();
                return false;
            }
        }


        function FromServer(arg, context) {
            //debugger;  
            if (context == 1) {
                if (arg == "NOT FOUND") {
                    alert('There is No Employee Exists..Please Check..!!');
                    document.getElementById('<%= hidempcode.ClientID %>').value = 0;
           document.getElementById('<%= txt_empcode.ClientID %>').value = "";
           document.getElementById('<%= txt_empname.ClientID %>').value = "";
           document.getElementById('<%= txt_empcode.ClientID %>').focus();
       }
       else {
           document.getElementById('<%= txt_empname.ClientID %>').value = arg;
                }

            }
        }

        function KeyUps() {
            alert('Please Select Date Using Calendar..!!');
            document.getElementById('<%= txt_fromdt.ClientID %>').value = document.getElementById('<%= hidLeaveFrom.ClientID %>').value;
    document.getElementById('<%= txt_fromdt.ClientID %>').focus();
            return false;
        }
        function KeyUps1() {
            alert('Please Select Date Using Calendar..!!');
            document.getElementById('<%= txt_todt.ClientID %>').value = document.getElementById('<%= hidLeaveto.ClientID %>').value;
    document.getElementById('<%= txt_todt.ClientID %>').focus();
            return false;
        }



        function Fill_Dateto() {
            var day1, day2, day3;
            var month1, month2, month3;
            var year1, year2, year3;
            if ((document.getElementById('<%= txt_todt.ClientID %>').value != "") && (document.getElementById('<%= txt_fromdt.ClientID %>').value != "")) {
        value1 = document.getElementById('<%= txt_fromdt.ClientID %>').value;
        value2 = document.getElementById('<%= txt_todt.ClientID %>').value;
        date3 = document.getElementById('<%= hid_sysdate.ClientID %>').value;

        day1 = value1.substring(0, value1.indexOf("/"));
        month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
        year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

        day2 = value2.substring(0, value2.indexOf("/"));
        month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
        year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

        date1 = year1 + "/" + month1 + "/" + day1;
        date2 = year2 + "/" + month2 + "/" + day2;

        firstDate = Date.parse(date1);
        secondDate = Date.parse(date2);
        curr_dt = Date.parse(date3);
        diff = Math.ceil((curr_dt - firstDate) / (1000 * 3600 * 24));

        msPerDay = 24 * 60 * 60 * 1000;

        dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
        if (dbd < 0) {
            alert("Wrong Entry..!! Your FromDate Greater than ToDate.. Please Change..!!")
            document.getElementById('<%= txt_fromdt.ClientID %>').value = document.getElementById('<%= hidLeaveFrom.ClientID %>').value;
                document.getElementById('<%= txt_todt.ClientID %>').value = document.getElementById('<%= hidLeaveto.ClientID %>').value;
                document.getElementById('<%= txt_fromdt.ClientID %>').focus();
                return false;
            }
            else if (firstDate > curr_dt || secondDate > curr_dt) {
                alert("Wrong Entry..!!Future Date Not Allowed.!")

                document.getElementById('<%= txt_fromdt.ClientID %>').value = document.getElementById('<%= hidLeaveFrom.ClientID %>').value;
                document.getElementById('<%= txt_todt.ClientID %>').value = document.getElementById('<%= hidLeaveto.ClientID %>').value;
                document.getElementById('<%= txt_fromdt.ClientID %>').focus();
                return false;
            }
            else if (diff > 45) {
                alert("Wrong Entry..!!You cant apply. Back date application restricted to 45 days..")

                document.getElementById('<%= txt_fromdt.ClientID %>').value = document.getElementById('<%= hidLeaveFrom.ClientID %>').value;
                document.getElementById('<%= txt_todt.ClientID %>').value = document.getElementById('<%= hidLeaveto.ClientID %>').value;
                document.getElementById('<%= txt_fromdt.ClientID %>').focus();
                    return false;
                }
            }
        }

        function purposechange() {
            var purpose
            purpose = document.getElementById('<%= cmb_purpose.ClientID %>').value;
    if (purpose == 12) {
        document.getElementById('<%= label8.ClientID %>').style.visibility = 'visible';
    document.getElementById('<%= txt_purpose.ClientID %>').style.visibility = 'visible';
}
else {
    document.getElementById('<%= label8.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= txt_purpose.ClientID %>').style.visibility = 'hidden';
            }
        }

        function modechange() {
            var mode;
            mode = document.getElementById('<%= cmb_mode.ClientID %>').value;
    if (mode != 2 && mode != 1 && mode != -1) {
        document.getElementById('<%= label10.ClientID %>').style.visibility = 'visible';
    document.getElementById('<%= txt_amnt.ClientID %>').style.visibility = 'visible';
    document.getElementById('<%= txt_amnt.ClientID %>').value = 0;
}
else {
    document.getElementById('<%= txt_amnt.ClientID %>').value = 0;
    document.getElementById('<%= label10.ClientID %>').style.visibility = 'hidden';
    document.getElementById('<%= txt_amnt.ClientID %>').style.visibility = 'hidden';
            }
        }

        function Addgrid() {
            //debugger;
            var data, emp_code, fromdt, todt, source, destination, distance, purpose, mode, txtpurpose, amount, passdata, distadata, dist1, type, emp_name, mode_text;
            emp_code = document.getElementById('<%= hidempcode.ClientID %>').value;
    emp_name = document.getElementById('<%= txt_empname.ClientID %>').value;
    fromdt = document.getElementById('<%= txt_fromdt.ClientID %>').value;
    todt = document.getElementById('<%= txt_todt.ClientID %>').value;
    source = document.getElementById("txtSource").value;
    destination = document.getElementById("txtDestination").value;
    distance = document.getElementById('<%= hid_distance.ClientID %>').value
    purpose = document.getElementById('<%= cmb_purpose.ClientID %>').value;
    mode = document.getElementById('<%= cmb_mode.ClientID %>').value;
    mode_text = document.getElementById('<%= cmb_mode.ClientID %>').options[document.getElementById('<%= cmb_mode.ClientID %>').selectedIndex].text
    amount = parseFloat(document.getElementById('<%= txt_amnt.ClientID %>').value);
    txtpurpose = document.getElementById('<%= txt_purpose.ClientID %>').value;
    type = document.getElementById('<%= cmb_type.ClientID %>').value;
    distadata = document.getElementById('dvDistance').innerHTML
    if (distadata == "") {
        alert('Please Enter source/destination..Distance not generated')
        return false
    }
    else {

        dist1 = distadata.split("<BR>Duration:")
        var kpres = dist1[0].indexOf('km')
        var dist1new
        if (kpres > 0) {
            dist1new = dist1[0].replace('km', '');
            distanceee = dist1new.split("Distance:")
            distance = parseFloat(distanceee[1])
        }
        else {
            dist1new = dist1[0].replace('m', '');
            distanceee = dist1new.split("Distance:")
            distanceee = parseFloat(distanceee[1] / 1000);
            distance = parseFloat(distanceee)
        }






    }
    if (emp_code == "") {
        alert('Please Enter Employee Code')
        return false;
    }
    if (fromdt == "" || todt == "") {
        alert('Please Select Date');
        return false;
    }
    if (source == "" || destination == "") {
        alert('Please Enter source/destination');
        return false;
    }
    if (distance == "" || distance == 0) {
        alert('Please Enter source/destination..Distance not generated');
        return false;
    }
    if (purpose == -1) {
        alert('Please select Purpose');
        return false;
    }
    if (mode == -1) {
        alert('Please select Mode');
        return false;
    }
    if (mode != 2 && mode != 1 && mode != -1) {
        if (isNaN(amount)) {
            alert('Please Enter Amount Properly');
            return false;
        }
    }
    if (purpose == 12 && txtpurpose == "") {
        alert('Please Enter Purpose Of Tour')
        return false
    }
    if (type == -1) {
        alert('Please Select Type Of Tour')
        return false
    }
    else {
        passdata = emp_code + "*" + emp_name + "*" + fromdt + "*" + todt + "*" + source + "*" + destination + "*" + distance + "*" + purpose + "*" + txtpurpose + "*" + mode + "*" + amount + "*" + type + "*" + mode_text + "!"
        document.getElementById('<%= hid_data.ClientID %>').value = "";
    document.getElementById('<%= hid_data.ClientID %>').value = passdata;
                display_check()
            }
        }

        function display_check() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot, st4, st5, st6;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            stlast = "";
            var emp, place, dat, mode, bus, bike, other, type, dummy_amount, mod_txt
            var amnt1, amnt4, amnt3, amnt2;
            var total_amount = parseFloat("0");
            if (document.getElementById('<%= hid_data.ClientID %>').value == "") {
        document.getElementById("panel_row").style.display = "none";
        document.getElementById('<%= Panel1.ClientID %>').innerHTML = "";
        return;
    }

    document.getElementById('<%= hid_info.ClientID %>').value += document.getElementById('<%= hid_data.ClientID %>').value;

    st5 = document.getElementById('<%= hid_data.ClientID %>').value
    st2 = document.getElementById('<%= hid_info.ClientID %>').value.split("!");
    ar = st2.length - 1;
    if (document.getElementById('<%= hid_data.ClientID %>').value != "")
        document.getElementById('<%= hid_Counter.ClientID %>').value = 0
    document.getElementById('<%= hid_real.ClientID %>').value = ""
    {
        for (i = 0; i < ar; i++) {
            document.getElementById('<%= hid_Counter.ClientID %>').value = Math.abs(document.getElementById('<%= hid_Counter.ClientID %>').value) + 1;
            var coun = document.getElementById('<%= hid_Counter.ClientID %>').value;
            st3 = st2[i].split("*");
            emp = st3[0] + "-" + st3[1];
            dat = st3[2] + " TO " + st3[3];
            place = st3[4] + " TO " + st3[5]
            distan = st3[6] + "KM";
            mode = st3[9]
            type = st3[11]
            mod_txt = st3[12]
            if (mode == 1) {
                bus = parseFloat(document.getElementById('<%= hid_bus.ClientID %>').value);
            amnt1 = st3[6].replace(',', '');
            if (type == 1) {
                amount = parseFloat(amnt1 * bus).toFixed(2);
            }
            else {
                dummy_amount = parseFloat(amnt1 * bus).toFixed(2);
                amount = dummy_amount * 2;
            }
        }
        else if (mode == 2) {
            amnt1 = st3[6].replace(',', '');
            bike = parseFloat(document.getElementById('<%= hid_bike.ClientID %>').value);
                if (type == 1) {
                    amount = parseFloat(amnt1 * bike).toFixed(2);
                }
                else {
                    dummy_amount = parseFloat(amnt1 * bike).toFixed(2);
                    amount = dummy_amount * 2;
                }
            }
            else {
                //        amnt1=st3[6].replace(',','');
                amnt3 = parseFloat(st3[10]);
                if (type == 1) {
                    amount = parseFloat(amnt3).toFixed(2);
                }
                else {
                    dummy_amount = parseFloat(amnt3).toFixed(2);;
                    amount = parseFloat(dummy_amount).toFixed(2);
                }
            }
            document.getElementById('<%= hid_real.ClientID %>').value += st2[i] + "*" + amount + "!";
            total_amount = (parseFloat(total_amount) + parseFloat(amount)).toFixed(2);
            st1 = st1 + "<tr  bgcolor='#CCDDEE'><td><small>" + coun + "</td><td><small>" + emp + "</td><td><small>" + dat + "</td><td><small>" + place + "</td><td><small>&nbsp;&nbsp;" + mod_txt + "</td><td><small>" + distan + "</td><td><small>" + amount + "</td><td><a href=javascript:delf(" + i + ")>Delete</a></td></tr>"
        }
        st = st + "<table id='grid' border=1 style='width:775px; height:100%; text-align:left'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>SLNO</b></td><td><b>&nbsp;EMPLOYEE&nbsp;</b></td><td><b>&nbsp;DATE &nbsp;</b></td><td><b>&nbsp;PLACE &nbsp;</b></td><td><b>&nbsp;&nbsp;&nbsp;&nbsp;MODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><b>&nbsp;DISTANCE </b></td><td><b>&nbsp;AMOUNT </b></td><td><b>&nbsp;DELETE </b></td></tr>"
        stlast = "<tr  bgcolor='#CCDDEE'><td colspan='6'><small>TOTAL</td><td><small>" + total_amount + "</td><td><small></td></tr>"
        st1 = st + st1 + tot + stlast + "</table>"
        document.getElementById("panel_row").style.display = "inline";

    }
    document.getElementById('<%= Panel1.ClientID %>').innerHTML = st1;
    document.getElementById('<%= Panel1.ClientID %>').style.height = document.getElementById('grid').style.height;
        }

        function delf(i) {
            //debugger;
            var j = i, k, inner = 0
            var new_tran = ""
            var new_tran1 = ""
            var new_tran2 = ""
            var temp_tran = ""

            var artb = document.getElementById('<%= hid_info.ClientID %>').value.split("!")
    var arsp
    var arsp1
    arsp = document.getElementById('<%= hid_data.ClientID %>').value.split("!")
    for (k = 0; k < j; k++) {
        new_tran = artb[k] + "!" + new_tran
    }
    for (k = j + 1; k < artb.length - 1; k++) {
        inner += 1
        if (k != artb.length - 2) {
            new_tran = artb[k] + "!" + new_tran
        }
        else {
            new_tran1 = artb[k] + "!" + new_tran1
        }
    }

    var temp
    temp = new_tran.split("!")
    var lengt = parseInt(temp.length - 1)
    for (k = 0; k < lengt; k++) {
        temp_tran = temp[k] + "!" + temp_tran
        new_tran = temp_tran
    }


    if (inner != 0) {
        document.getElementById('<%= hid_info.ClientID %>').value = new_tran
        document.getElementById('<%= hid_data.ClientID %>').value = new_tran1
    }
    else {
        document.getElementById('<%= hid_info.ClientID %>').value = ""
        document.getElementById('<%= hid_data.ClientID %>').value = new_tran
            }
            display_check()

        }



        function Numberonly() {
            if (isNaN(document.getElementById('<%= txt_amnt.ClientID %>').value)) {
        document.getElementById('<%= txt_amnt.ClientID %>').value = "";
                return false;
            }
        }

    </script>

    <div style="text-align: center; height: 250; text-align: center;" id="hidden4">
        <table border="1" id="header_tab" style="width: 120px">
            <tr>
                <td style="width: 827px">
                    <asp:Label ID="lbl_head" runat="server" Width="720px" Font-Bold="True" Font-Size="Larger">TRAVEL ALLOWANCE CLAIM</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 827px">
                    <asp:Label ID="Lbl_branch" runat="server" Width="584px" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <table id="maintab" border="1" style="height: 248px; width: 1px;">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label1" runat="server" Width="140px" Font-Bold="True" Text="Employee Code"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txt_empcode" runat="server" Width="200px" onkeyup="return EmpCodeKeyUp()" onchange="return EmpNameFind()" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="Label2" runat="server" Width="140px" Font-Bold="True" Text="Employee Name"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txt_empname" runat="server" Width="200px" ReadOnly="True" TabIndex="1" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label5" runat="server" Width="140px" Font-Bold="True" Text="From Date"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txt_fromdt" runat="server" Width="200px" onkeyup="return KeyUps()" onchange="Fill_Dateto()" onkeydown="return (event.keyCode!=13);" TabIndex="2"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="Label6" runat="server" Width="140px" Font-Bold="True" Text="To Date"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txt_todt" runat="server" Width="200px" onkeyup="return KeyUps1()" onchange="Fill_Dateto()" onkeydown="return (event.keyCode!=13);" TabIndex="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Source:" Width="140px"></asp:Label>
                </td>
                <td style="text-align: left">
                    <input type="text" id="txtSource" style="width: 200px" onkeydown="return (event.keyCode!=13);" tabindex="4" />
                </td>
                <td style="text-align: left">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Destination: " Width="140px">
                    </asp:Label></td>
                <td colspan="4" style="text-align: left; width: 366px;">
                    <input type="text" id="txtDestination" style="width: 200px" onkeydown="return (event.keyCode!=13);" tabindex="5" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <input type="button" value="Get Distance" onclick="GetRoute()" tabindex="6" /></td>
                <td colspan="4" style="text-align: right; width: 366px;">
                    <asp:CheckBox ID="Chk_map" runat="server" Text="View Map" Width="112px" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="dvDistance">
                    </div>
                </td>
            </tr>
            <tr id="disp_map">
                <td style="height: 240px" colspan="6">
                    <div id="dvMap" style="width: 640px; height: 280px; overflow: auto">
                    </div>
                </td>
                <%--<td style="height:240px" colspan="2">
        <div id="dvPanel" style="width: 300px; height: 244px; overflow:auto ">
        </div>
    </td>--%>
            </tr>









            <tr>
                <td style="text-align: left">
                    <asp:Label ID="Label7" runat="server" Width="140px" Font-Bold="True" Text="Tour Purpose"></asp:Label>
                </td>
                <td style="text-align: left">&nbsp;<asp:DropDownList ID="cmb_purpose" runat="server" Width="200px" TabIndex="7">
                </asp:DropDownList></td>
                <td style="text-align: left">
                    <asp:Label ID="Label8" runat="server" Width="140px" Font-Bold="True" Text="Purpose"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txt_purpose" runat="server" Width="200px" TabIndex="8"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="Label9" runat="server" Width="140px" Font-Bold="True" Text="Mode"></asp:Label>
                </td>
                <td style="text-align: left;">&nbsp;<asp:DropDownList ID="cmb_mode" runat="server" Width="200px" TabIndex="9">
                </asp:DropDownList></td>
                <td style="text-align: left;">
                    <asp:Label ID="Label10" runat="server" Width="140px" Font-Bold="True" Text="Amount"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txt_amnt" runat="server" Width="200px" TabIndex="10" onkeypress="return Numberonly()" MaxLength="5">0</asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="Label11" runat="server" Width="140px" Font-Bold="True" Text="Type"></asp:Label>
                </td>
                <td style="text-align: left;">&nbsp;<asp:DropDownList ID="cmb_type" runat="server" Width="200px" TabIndex="11">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList></td>
                <td style="text-align: left;" colspan="2">&nbsp;&nbsp;</td>
            </tr>


            <tr>
                <td style="text-align: center;" colspan="4">&nbsp;<input id="Button1" type="button" value="Add" onclick="return Addgrid()" style="width: 56px; height: 24px" tabindex="12" />
                    &nbsp;&nbsp;</td>
            </tr>

            <tr id="panel_row" style="display: none;">
                <td colspan="4" style="text-align: left">
                    <asp:Panel ID="Panel1" runat="server" Height="60px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_apply" runat="server" Text="Apply" Height="32px" Width="80px" TabIndex="13" />
                    <asp:Button ID="btn_exit" runat="server" Text="Exit" Height="32px" Width="80px" TabIndex="14" />
                </td>
            </tr>








        </table>

        <input id="hid_distance" runat="server" style="width: 1px" type="hidden" />
        <input id="hidempcode" runat="server" style="width: 1px" type="hidden" />
        <input id="hidLeaveFrom" runat="server" style="width: 1px" type="hidden" />
        <input id="hidLeaveto" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_data" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_distan" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_Counter" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_bus" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_bike" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_total" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_info" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_real" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_userid" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_sysdate" runat="server" style="width: 1px" type="hidden" />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_Fromdt"></cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_todt"></cc1:CalendarExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
</asp:Content>

