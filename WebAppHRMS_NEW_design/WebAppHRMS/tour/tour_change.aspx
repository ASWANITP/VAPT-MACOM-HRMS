<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="tour_change.aspx.vb" Inherits="WebAppHRMS.tour_cancellation_tour_cancellation_76b853294593" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = loanno.split('cmb');
        function Button1_onclick() {
            window.open('../home.aspx', '_self');
        }
        function call_receiver(arg1) {
            var arg10 = arg1.split("^")
            if (arg10[1] == 3) {
                alert(arg10[0]);
                window.open('tour_change.aspx', '_self');
            }
            else {
                if (arg10[1] == 2) {
                    if (arg10[0] == 0) {
                        document.getElementById(cont[0] + "cmd_comfirm").disabled = true;
                        document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'hidden';
                        var option1 = document.createElement("OPTION");
                        option1.value = 0;
                        option1.text = "NO Record to Select"
                        document.getElementById(cont[0] + "cmb_tour").add(option1);
                        document.getElementById(cont[0] + "Hidden2").value = 0;
                        document.getElementById(cont[0] + "lbl_fromdt").value = "No data";
                        document.getElementById(cont[0] + "lbl_todate").value = "No data";
                        document.getElementById(cont[0] + "lbl_fromtime").value = "No data";
                        document.getElementById(cont[0] + "lbl_totime").value = "No data";
                        document.getElementById(cont[0] + "lbl_advance").value = "No data";
                        document.getElementById(cont[0] + "lbl_tobranch").value = "No data";
                        document.getElementById(cont[0] + "lbl_purpose").value = "No data";
                    }
                    else {
                        document.getElementById(cont[0] + "cmd_comfirm").disabled = false;
                        document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'visible';
                        document.getElementById(cont[0] + "cmb_tour").style.visibility = 'visible';
                        document.getElementById(cont[0] + "cmb_tour").options.length = 0;
                        var rs1 = arg10[0].split("!")
                        for (h = 0; h < rs1.length - 1; h++) {

                            var dt1 = rs1[h].split("*")
                            var option1 = document.createElement("OPTION");
                            option1.value = dt1[1];
                            option1.text = dt1[0]
                            document.getElementById(cont[0] + "cmb_tour").add(option1);


                            var dat = dt1[1].split("#")
                            document.getElementById(cont[0] + "Hidden2").value = dat[0];
                            document.getElementById(cont[0] + "lbl_fromdt").value = dat[1];
                            document.getElementById(cont[0] + "lbl_todate").value = dat[2];
                            document.getElementById(cont[0] + "lbl_fromtime").value = dat[3];
                            document.getElementById(cont[0] + "lbl_totime").value = dat[4];
                            document.getElementById(cont[0] + "lbl_advance").value = dat[5];
                            document.getElementById(cont[0] + "lbl_tobranch").value = dat[6];
                            document.getElementById(cont[0] + "lbl_purpose").value = dat[7];

                        }
                    }
                }
                else {
                    if (arg10[0] == 0) {
                        document.getElementById(cont[0] + "cmd_comfirm").disabled = true;
                        document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'hidden';
                        var option1 = document.createElement("OPTION");
                        option1.value = 0;
                        option1.text = "NO Tour To Cancel"
                        document.getElementById(cont[0] + "cmb_emp").add(option1);
                        document.getElementById(cont[0] + "cmb_tour").add(option1);
                        // document.getElementById(cont[0]+"Hidden2").value=document.getElementById(cont[0]+"cmb_tour").value;
                        document.getElementById(cont[0] + "lbl_fromdt").value = "No data";
                        document.getElementById(cont[0] + "lbl_todate").value = "No data";
                        document.getElementById(cont[0] + "lbl_fromtime").value = "No data";
                        document.getElementById(cont[0] + "lbl_totime").value = "No data";
                        document.getElementById(cont[0] + "lbl_advance").value = "No data";
                        document.getElementById(cont[0] + "lbl_tobranch").value = "No data";
                        document.getElementById(cont[0] + "lbl_purpose").value = "No data";
                    }
                    else {
                        document.getElementById(cont[0] + "cmd_comfirm").disabled = false;
                        document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'visible';
                        document.getElementById(cont[0] + "cmb_tour").style.visibility = 'visible';

                        var option1 = document.createElement("OPTION");
                        option1.value = 0;
                        option1.text = 'Select Employee';
                        document.getElementById(cont[0] + "cmb_emp").add(option1);
                        document.getElementById(cont[0] + "Hidden2").value = 0;
                        var rs1 = arg10[0].split("#")
                        for (h = 0; h < rs1.length - 1; h++) {
                            var dt1 = rs1[h].split("-")
                            var option1 = document.createElement("OPTION");
                            option1.value = dt1[0];
                            option1.text = dt1[0] + " - " + dt1[1];
                            document.getElementById(cont[0] + "cmb_emp").add(option1);
                            document.getElementById(cont[0] + "Hidden1").value = dt1[0];
                            var dat = dt1[1].split("#")
                            document.getElementById(cont[0] + "Hidden2").value = dat[0];
                        }
                    }
                }
            }
        }

        function window_onload() {
            call_server("3@" + "hh");
        }
        function filltour() {
            document.getElementById(cont[0] + "cmb_tour").options.length = 0;
            document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "cmb_emp").value;
            if (document.getElementById(cont[0] + "Hidden1").value != 0) {
                call_server("1@" + document.getElementById(cont[0] + "Hidden1").value);
            }
            else {
                document.getElementById(cont[0] + "cmb_tour").options.length = 0;
                document.getElementById(cont[0] + "lbl_fromdt").value = "No data";
                document.getElementById(cont[0] + "lbl_todate").value = "No data";
                document.getElementById(cont[0] + "lbl_fromtime").value = "No data";
                document.getElementById(cont[0] + "lbl_totime").value = "No data";
                document.getElementById(cont[0] + "lbl_advance").value = "No data";
                document.getElementById(cont[0] + "lbl_tobranch").value = "No data";
                document.getElementById(cont[0] + "lbl_purpose").value = "No data";
                document.getElementById(cont[0] + "cmd_comfirm").disabled = true;
                document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'hidden';;
            }
        }
        function chgtxt() {
            // document.getElementById(cont[0]+"Hidden2").value=document.getElementById(cont[0]+"cmb_tour").value;
            var dat1 = document.getElementById(cont[0] + "cmb_tour").value.split("#")
            if (dat1[1] == 0) {
                document.getElementById(cont[0] + "lbl_fromdt").value = "No data";
                document.getElementById(cont[0] + "lbl_todate").value = "No data";
                document.getElementById(cont[0] + "lbl_fromtime").value = "No data";
                document.getElementById(cont[0] + "lbl_totime").value = "No data";
                document.getElementById(cont[0] + "lbl_advance").value = "No data";
                document.getElementById(cont[0] + "lbl_tobranch").value = "No data";
                document.getElementById(cont[0] + "lbl_purpose").value = "No data";
                document.getElementById(cont[0] + "cmd_comfirm").disabled = true;
                document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'hidden';
            }
            else {
                document.getElementById(cont[0] + "lbl_fromdt").value = dat1[1];
                document.getElementById(cont[0] + "lbl_todate").value = dat1[2];
                document.getElementById(cont[0] + "lbl_fromtime").value = dat1[3];
                document.getElementById(cont[0] + "lbl_totime").value = dat1[4];
                document.getElementById(cont[0] + "lbl_advance").value = dat1[5];
                document.getElementById(cont[0] + "lbl_tobranch").value = dat1[6];
                document.getElementById(cont[0] + "lbl_purpose").value = dat1[7];
                document.getElementById(cont[0] + "cmd_comfirm").disabled = false;
                document.getElementById(cont[0] + "cmd_comfirm").style.visibility = 'visible';
                call_server("1@" + document.getElementById(cont[0] + "Hidden1").value);

            }
            return true;
        }

        function cmd_comfirm_onclick() {
            //document.getElementById(cont[0]+"Hidden2").value=document.getElementById(cont[0]+"cmb_tour").value;
            call_server("2@" + document.getElementById(cont[0] + "cmb_tour").value);
        }
        function chgdt() {
            document.getElementById(cont[0] + "Txt_chng_dt").value = "";
            alert('select from calender');

        }
        // ]]>
    </script>

    <div style="text-align: center">

        <div style="text-align: center">
            <table border="1" style="width: 788px; height: 1px">
                <tr>
                    <td colspan="2" style="height: 38px">
                        <strong><span style="color: #cc0099; text-decoration: underline; font-weight: bold; font-size: 14pt; font-family: 'Courier New';">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            TOUR DATE CHANGE</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 169px; height: 7px; text-align: right">
                        <span style="font-size: 11pt; font-family: Courier New">Select Employee :</span></td>
                    <td style="width: 100px; height: 7px; text-align: left">
                        <asp:DropDownList ID="cmb_emp" OnChange="return filltour()" runat="server" AutoPostBack="false" Width="612px" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 169px; height: 7px; text-align: right">
                        <span style="font-weight: normal; font-size: 11pt; font-family: 'Courier New';">Select Tour :</span>
                    </td>
                    <td style="width: 100px; height: 7px; text-align: left">
                        <asp:DropDownList ID="cmb_tour" OnChange="return chgtxt()" runat="server" AutoPostBack="false" Width="612px" Style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 7px; text-align: center">
                        <br />
                        <table border="1" style="width: 648px; height: 95px">
                            <tr>
                                <td style="width: 151px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">From Date :</td>
                                <td style="width: 76px; height: 3px; text-align: left">
                                    <input id="lbl_fromdt" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                                <td style="width: 173px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">To Date :</td>
                                <td style="width: 100px; height: 3px; text-align: left">
                                    <input id="lbl_todate" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                            </tr>
                            <tr>
                                <td style="width: 151px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">From Time :</td>
                                <td style="width: 76px; height: 23px; text-align: left">
                                    <input id="lbl_fromtime" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                        type="text" /></td>
                                <td style="width: 173px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">To Time :</td>
                                <td style="width: 100px; height: 23px; text-align: left">
                                    <input id="lbl_totime" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                            </tr>
                            <tr>
                                <td style="width: 151px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">Advance :</td>
                                <td style="width: 76px; text-align: left">
                                    <input id="lbl_advance" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                                <td style="width: 173px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">To Branch/Place :</td>
                                <td style="width: 100px; text-align: left">
                                    <input id="lbl_tobranch" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';"
                                        type="text" /></td>
                            </tr>
                            <tr>
                                <td style="width: 151px; text-align: left; font-weight: normal; font-size: 11pt; font-family: 'Courier New';">Tour Purpose:</td>
                                <td colspan="3" style="text-align: left">
                                    <input id="lbl_purpose" runat="server" readonly="readonly" style="width: 139px; font-weight: normal; font-size: 11pt; font-family: 'Courier New';" type="text" /></td>
                            </tr>
                            <tr>
                                <td style="font-weight: normal; font-size: 11pt; width: 151px; font-family: 'Courier New'; text-align: left">
                                    <strong><span style="color: #cc0033">Change TO Date</span></strong></td>
                                <td colspan="3" style="text-align: left">
                                    <asp:TextBox ID="Txt_chng_dt" onkeyup="return chgdt()" runat="server" Width="139px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table border="1" style="width: 204px">
                            <tr>
                                <td style="width: 100px">
                                    <input id="cmd_comfirm" type="button" value="CONFIRM" runat="server" style="font-weight: bold; font-size: 12pt; width: 89px; font-family: 'Courier New'; height: 27px;" /></td>
                                <td style="width: 100px">&nbsp;<input id="Button1" style="width: 89px; font-weight: bold; font-size: 12pt; font-family: 'Courier New'; height: 27px;" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
                            </tr>
                        </table>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="Txt_chng_dt"></cc1:CalendarExtender>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <input id="Hidden1" type="hidden" runat="server" style="width: 1px" />&nbsp;<input id="Hidden2" type="hidden" runat="server" style="width: 1px" />
    </div>
</asp:Content>

