<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="man_power.aspx.vb" Inherits="WebAppHRMS.manpower_reqq_2df121803273" Title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        var cont_name = header.split('txt');

        function checkdt1() {
            debugger;
            var a = document.getElementById(cont_name[0] + "txt_date").value;
            checkDate(document.getElementById(cont_name[0] + "txt_date").value, document.getElementById(cont_name[0] + "txt_exp_dt").value, 3);
        }

        function checkdt2() {
            debugger;
            var a = document.getElementById(cont_name[0] + "txt_exp_dt").value;
            checkDate(document.getElementById(cont_name[0] + "txt_exp_dt").value, document.getElementById(cont_name[0] + "txt_date").value, 5);
        }


        function checkDate(dateFrom, dateTo, stat) {
            debugger;

            var day1, day2, day3;
            var month1, month2, month3;
            var year1, year2, year3;

            var dt = new Date().format("dd/MMM/yyyy");
            var value3 = dt;

            if ((dateFrom == "") || (dateTo == "")) {
                if (dateFrom == "") {
                    dateFrom = new Date().format("dd/MMM/yyyy");
                }
                if (dateTo == "") {
                    dateTo = new Date().format("dd/MMM/yyyy");
                }
            }

            value1 = dateFrom;
            value2 = dateTo;

            day1 = value1.substring(0, value1.indexOf("/"));
            month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
            year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

            day2 = value2.substring(0, value2.indexOf("/"));
            month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
            year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

            day3 = value3.substring(0, value3.indexOf("/"));
            month3 = value3.substring(value3.indexOf("/") + 1, value3.lastIndexOf("/"));
            year3 = value3.substring(value3.lastIndexOf("/") + 1, value3.length);

            date1 = year1 + "/" + month1 + "/" + day1;
            date2 = year2 + "/" + month2 + "/" + day2;
            date3 = year3 + "/" + month3 + "/" + day3;

            firstDate = Date.parse(date1)
            secondDate = Date.parse(date2)
            thirdDate = Date.parse(date3)


            msPerDay = 24 * 60 * 60 * 1000

            dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
            dbd1 = Math.round((thirdDate.valueOf() - firstDate.valueOf()) / msPerDay);
            dbd2 = Math.round((thirdDate.valueOf() - secondDate.valueOf()) / msPerDay);
            if (stat == 1) {

                if (dbd1 < 0 || dbd2 < 0) {
                    alert('Please Do not enter Future Date..!!');
                    return false;
                }

            }

            if (stat == 2) {

                if (dbd1 < dbd2) {
                    alert('Check the dates');
                    document.getElementById(cont_name[0] + "txt_from").value = ""
                    document.getElementById(cont_name[0] + "txt_to").value = ""
                    return false;
                }
            }

            if (stat == 3) {

                if (dbd1 > 0 || dbd2 > 0) {
                    alert('Please Do not enter Past Date..!!');
                    document.getElementById(cont_name[0] + "txt_date").value = ""
                    return false;
                }

            }

            if (stat == 5) {

                if (dbd1 > 0 || dbd2 > 0) {
                    alert('Please Do not enter Past Date..!!');
                    document.getElementById(cont_name[0] + "txt_exp_dt").value = ""
                    return false;
                }

            }




            if (stat == 4) {
                if (dbd > 62) {
                    alert("Check Date")
                    return false;
                }
            }
            return true;

        }



        function da(a) {
            debugger;
            alert('Please Enter Date using Calendar!!');
            document.getElementById(cont_name[0] + a).value = "";
            return false;
        }



        function job_title(e, t) {
            debugger;
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }

                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32))
                    return true;

                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }



        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }




        function qualif_check(e, t) {
            debugger;
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }

                var res = String.fromCharCode(charCode);
                if (/[^a-zA-Z0-9]/.test(res)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }



        function check_con() {
            debugger;
            var a = document.getElementById(cont_name[0] + "cmb_firm").selectedIndex;
            var b = document.getElementById(cont_name[0] + "cmb_tenure").selectedIndex;
            var c = document.getElementById(cont_name[0] + "cmb_reason").selectedIndex;
            var d = document.getElementById(cont_name[0] + "txt_date").value;
            var e = document.getElementById(cont_name[0] + "Txt_job").value;
            var f = document.getElementById(cont_name[0] + "txt_div").value;
            var g = document.getElementById(cont_name[0] + "txt_no_req").value;
            var h = document.getElementById(cont_name[0] + "txt_exp_dt").value;
            var i = document.getElementById(cont_name[0] + "txt_stren").value;
            var j = document.getElementById(cont_name[0] + "txt_qualif").value;
            var k = document.getElementById(cont_name[0] + "txt_pay").value;
            var l = document.getElementById(cont_name[0] + "txt_exp").value;
            var m = document.getElementById(cont_name[0] + "txt_no_vacancy").value;
            var n = document.getElementById(cont_name[0] + "txt_loc").value;

            if (document.getElementById(cont_name[0] + "EDIT").checked) {
                if (document.getElementById(cont_name[0] + "txt_id").value == "") {
                    alert("Enter ID....!");
                    return false;
                }
            }






            if (b == 0) {
                alert("Choose Tenure");
                return false
            }
            if (e == "") {
                alert("Please Enter job Title");
                return false
            }

            if (f == "") {
                alert("Please Enter Division");
                return false
            }

            if (g == "") {
                alert("Please Enter Number of requirments");
                return false
            }
            if (i == "") {
                alert("Please Enter Current Strength");
                return false
            }
            if (j == "") {
                alert("Please Enter Qualification Details");
                return false
            }
            if (k == "") {
                alert("Please Enter PayScale");
                return false
            }
            if (l == "") {
                alert("Please Enter Expirience Details");
                return false
            }
            if (m == "") {
                alert("Please Enter Number of Vacancies");
                return false
            }
            if (n == "") {
                alert("Please Enter Location");
                return false
            }

            if (c == 0) {
                alert("Please Choose Reason");
                return false
            }

            if (document.getElementById("row").style.display == "inline") {
                if (document.getElementById(cont_name[0] + "txt_info").value == "") {
                    alert("Please Enter Additional Information")
                    return false
                }
            }

            if (!document.getElementById(cont_name[0] + "male").checked) {
                if (!document.getElementById(cont_name[0] + "female").checked) {
                    alert("Please choose Gender")
                    return false;
                }
            }
        }


        function getitem(e, t) {
            debugger;
            var e1 = document.getElementById(cont_name[0] + "cmb_reason").value;
            var e2 = e1.split("*");
            if (e2[1] == 1) {
                document.getElementById("row").style.display = "inline";
                document.getElementById(cont_name[0] + "txt_info").value = "";
            }
            else
                document.getElementById("row").style.display = "none";
        }


        function go() {
            window.open('../home.aspx', '_self');
        }




























    </script>
    <div style="text-align: center">
        <table border="1" style="width: 646px; height: 59px; margin: 0px auto;">
            <tr>
                <td colspan="5" style="height: 24px;">
                    <span style="font-size: 14pt; font-family: Courier New"><span style="color: #000000"></span>
                        <p align="center" style="margin-bottom: 0in; line-height: 150%">
                            <font face="Times New Roman, serif"><font size="3"><u><b><font face="Gisha, serif">MANPOWER
                                REQUISITION FORM</font></b></u></font></font>
                        </p>
                    </span></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 3px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_date"></cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_exp_dt"></cc1:CalendarExtender>
                    <asp:Label ID="Label15" runat="server" Width="448px"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="1" style="height: 3px">
                    <asp:RadioButton ID="ADD" runat="server" Font-Bold="True" Font-Size="Larger"
                        GroupName="ADDEDIT" Text="ADD" AutoPostBack="true" /></td>
                <td colspan="1" style="width: 498px; height: 3px">
                    <asp:RadioButton ID="EDIT" runat="server" Font-Bold="True" Font-Size="Larger" GroupName="ADDEDIT" Text="EDIT" AutoPostBack="true" /></td>
                <td colspan="5" style="height: 3px"></td>
            </tr>
            <tr id="tr_edit" runat="server" visible="false">
                <td colspan="1" style="height: 3px; text-align: left">
                    <asp:Label ID="Label17" runat="server" Text="Enter ID"></asp:Label></td>
                <td colspan="1" style="width: 498px; height: 3px; text-align: left;">
                    <asp:TextBox ID="txt_id" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox></td>
                <td colspan="5" style="height: 3px; text-align: left;">
                    <asp:Button ID="btn_search" runat="server" Text="Search" Font-Bold="True" Height="32px" Width="64px" /></td>
            </tr>
            <tr id="lbl_msg" runat="server" visible="false">
                <td colspan="7" style="height: 3px; text-align: center;">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="Red" Text="NO RECORD FOUND. PLEASE CHECK ID YOU HAVE ENTERED"
                        Width="480px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 134px; height: 7px; text-align: left" valign="middle">
                    <span style="font-size: 11pt">
                        <asp:Label ID="Label1" runat="server" Text="Date Of Requirment :" Height="24px" Width="144px"></asp:Label></span></td>


                <td style="height: 7px; text-align: left;" colspan="2" rowspan="">
                    <span style="font-size: 11pt">

                        <asp:TextBox ID="txt_date" runat="server" Font-Size="10pt"
                            Width="200px" AutoPostBack="True" onkeyup="return da('txt_date')"></asp:TextBox>

                        <%--<asp:TextBox ID="" runat="server" Width="200px">
                       </asp:TextBox>
                        --%>



                        <%--------------------------------------------------------------------onkeyup="da('txt_date')"--%>
                         
                         
                    </span></td>

                <td colspan="1" style="width: 4823138px; height: 7px; text-align: left" rowspan=""></td>
                <td style="width: 184px; height: 7px; text-align: left;" rowspan=""></td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left">
                    <span style="font-size: 11pt;">
                        <asp:Label ID="Label2" runat="server" Text="Requested By :" Width="144px"></asp:Label></span></td>
                <td style="height: 1px; text-align: left;" colspan="2"><span style="font-size: 11pt; font-family: Courier New">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="200px" Height="18px">
                    </asp:DropDownList></span></td>
                <td colspan="1" style="width: 4823138px; height: 1px; text-align: left"></td>
                <td style="width: 184px; height: 1px; text-align: center;"></td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left">
                    <asp:Label ID="Label3" runat="server" Text="Job Title" Width="144px"></asp:Label></td>
                <td colspan="2" style="height: 1px; text-align: left">
                    <asp:TextBox ID="Txt_job" runat="server" Width="200px" onkeypress="return job_title(event,this)"></asp:TextBox></td>
                <td colspan="1" style="width: 4823138px; height: 1px; text-align: left">
                    <asp:Label ID="Label5" runat="server" Text="Division" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: center">
                    <asp:TextBox ID="txt_div" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left">
                    <asp:Label ID="Label4" runat="server" Text="No Of Requirments :" Width="144px"></asp:Label></td>
                <td colspan="2" style="height: 1px; text-align: left">
                    <asp:TextBox ID="txt_no_req" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox></td>
                <td colspan="1" style="width: 4823138px; height: 1px; text-align: left">
                    <asp:Label ID="Label6" runat="server" Text="Expected Date:" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: center">
                    <asp:TextBox ID="txt_exp_dt" runat="server" Width="200px" onkeyup="return da('txt_exp_dt')">
                    
                    <%-- '<%-------------------------------------------------onkeyup="da('txt_exp_dt')"--%>
                    
                    
                    </asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 1px; text-align: center;">
                    <span><strong><u>JOB DETAILS</u></strong></span></td>
            </tr>

            <%--</tr>--%>

            <tr>
                <td style="width: 134px; height: 1px; text-align: left;">
                    <asp:Label ID="Label7" runat="server" Text="Tenure" Width="144px"></asp:Label></td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">
                    <asp:DropDownList ID="cmb_tenure" runat="server" Height="24px" Width="200px">
                        <asp:ListItem Value="0" Text="------SELECT------" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="TEMPORARY"></asp:ListItem>
                        <asp:ListItem Value="2" Text="PERMENENT"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 1px; text-align: left;" colspan="2">
                    <asp:Label ID="Label8" runat="server" Text="Total Strength Existing" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_stren" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left;">
                    <asp:Label ID="Label9" runat="server" Text="Qualification Required/Desired" ToolTip="144"
                        Width="144px"></asp:Label></td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_qualif" runat="server" Width="200px" onkeypress="return qualif_check(event,this)"></asp:TextBox>
                </td>
                <td style="height: 1px; text-align: left;" colspan="2">&nbsp;<asp:Label ID="Label10" runat="server" Text="PayScale for the Position" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_pay" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left;">Expirience Required</td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_exp" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox></td>
                <td style="height: 1px; text-align: left;" colspan="2">
                    <asp:Label ID="Label11" runat="server" Text="No Of Vacancies" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_no_vacancy" runat="server" Width="200px" onkeypress="return onlyNos(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left;">
                    <asp:Label ID="Label12" runat="server" Text="Location" Width="144px"></asp:Label></td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_loc" runat="server" Width="200px" onkeypress="return job_title(event,this)"></asp:TextBox>
                </td>
                <td style="height: 1px; text-align: left;" colspan="2">&nbsp;<asp:Label ID="Label13" runat="server" Text="gender" Width="144px"></asp:Label></td>
                <td style="width: 184px; height: 1px; text-align: left">
                    <asp:RadioButton ID="male" GroupName="gender" runat="server" Text="MALE" />
                    &nbsp; &nbsp; &nbsp;
                    <asp:RadioButton ID="female" GroupName="gender" runat="server" Text="FEMALE" />
                </td>
            </tr>
            <tr>
                <td style="width: 134px; height: 1px; text-align: left;">
                    <asp:Label ID="Label14" runat="server" Text="Reason For Requirment" Width="144px"></asp:Label></td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">&nbsp;<asp:DropDownList ID="cmb_reason" runat="server" Width="200px" onchange="getitem(event,this)">
                </asp:DropDownList></td>
                <td style="height: 1px; text-align: left; font-family: 'Courier New';" colspan="2">&nbsp;&nbsp;</td>
                <td style="width: 184px; height: 1px; text-align: left">&nbsp;</td>
            </tr>
            <tr id="row" style="display: none">
                <td style="width: 134px; height: 1px; text-align: left">
                    <asp:Label ID="Label16" runat="server" Text="Enter Information" Width="144px"></asp:Label></td>
                <td align="left" style="width: 498px; height: 1px; text-align: left">
                    <asp:TextBox ID="txt_info" runat="server" Width="200px" onkeypress="return job_title(event,this)"></asp:TextBox></td>
                <td colspan="2" style="font-family: 'Courier New'; height: 1px; text-align: left"></td>
                <td style="width: 184px; height: 1px; text-align: left"></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 15px">&nbsp;<asp:Button ID="btn_confirm" runat="server" Text="APPLY" Width="151px" OnClientClick="return check_con()" Font-Bold="True" Height="40px" />&nbsp;
                    <asp:Button ID="btn_exit" runat="server" Height="40px" Text="EXIT" Width="151px" Font-Bold="True" OnClientClick="go()" /><%--&nbsp;<input id="btn_exit" style="width: 136px; font-family: 'Courier New'; font-weight: bold;height=40px";" type="button" value="EXIT" onclick="return Button2_onclick()" />
                    --%></td>
            </tr>
        </table>
    </div>


</asp:Content>

