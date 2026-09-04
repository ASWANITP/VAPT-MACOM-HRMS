<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="selectcandidate.aspx.vb" Inherits="WebAppHRMS.SELECTCANTIDATE_selectcandidate_a6fe50a72941" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        //alert("s")
        window.onload = callback;
        function callback() {
            return window_onload();
        }
        // ]]>

    </script>

    <script language="javascript" type="text/javascript">
     
        function window_onload() {

        }
        var txt
        txt = disb.substr(0, disb.indexOf('cmd'));

        function sent_data_proc() {
            debugger;
            //for (k=1;k<=document.getElementById(txt+"hid_max").value;k++)
            //{
            //if(document.getElementById("txt_"+k).checked==true and  )
            //}
            //hid_data_sent
            //hid_max
            document.getElementById(txt + "hid_data_sent").value = ""
            for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                if (document.getElementByName("txt_" + k).checked == true) {
                    var arr
                    arr = document.getElementById("txt_" + k).id.split("_")
                    document.getElementById(txt + "hid_data_sent").value += "!" + arr[1]
                }
            }
            document.getElementById(txt + "Hid_max1").value = ""
            for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                if (document.getElementById("txt1_" + k).checked == true) {
                    var arr
                    arr = document.getElementById("txt1_" + k).id.split("_")
                    document.getElementById(txt + "Hid_max1").value += "!" + arr[1]
                }
            }
            //--------------
            document.getElementById(txt + "Hid_max2").value = ""
            for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                if (document.getElementById("txt2_" + k).checked == true) {
                    var arr
                    arr = document.getElementById("txt2_" + k).id.split("_")
                    document.getElementById(txt + "Hid_max2").value += "!" + arr[1]
                }


            }
            //alert(document.getElementById(txt+"hid_data_sent").value)
        }
        // ]]>

        function Chk_all_onclick() {
            debugger;
            if (document.getElementById("Chk_all").checked == true) {

                document.getElementById("Checkbox1").checked = false
                document.getElementById("Checkbox2").checked = false


                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt1_" + k).checked = false
                    document.getElementById("txt1_" + k).disabled = true
                }

                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt2_" + k).checked = false
                    document.getElementById("txt2_" + k).disabled = true
                }


                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt_" + k).checked = true
                    document.getElementById("txt_" + k).disabled = false
                }
            }


            if (document.getElementById("Chk_all").checked == false) {
                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt_" + k).checked = false

                }
            }

        }

        function Checkbox1_onclick() {

            debugger;
            if (document.getElementById("Checkbox1").checked == true) {
                document.getElementById("Checkbox2").checked = false
                document.getElementById("Chk_all").checked = false

                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt_" + k).checked = false
                    document.getElementById("txt_" + k).disabled = true

                }
                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt2_" + k).checked = false
                    document.getElementById("txt2_" + k).disabled = true
                }
                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {

                    document.getElementById("txt1_" + k).checked = true
                    document.getElementById("txt1_" + k).disabled = false
                }
            }


            if (document.getElementById("Checkbox1").checked == false) {

                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt1_" + k).checked = false

                }
            }

        }


        function Checkbox2_onclick() {
            debugger;
            if (document.getElementById("Checkbox2").checked == true) {
                document.getElementById("Checkbox1").checked = false
                document.getElementById("Chk_all").checked = false


                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt_" + k).checked = false
                    document.getElementById("txt_" + k).disabled = true
                }
                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt1_" + k).checked = false
                    document.getElementById("txt1_" + k).disabled = true

                }

                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt2_" + k).checked = true
                    document.getElementById("txt2_" + k).disabled = false
                }


            }


            if (document.getElementById("Checkbox2").checked == false) {

                for (k = 1; k <= document.getElementById(txt + "hid_max").value; k++) {
                    document.getElementById("txt2_" + k).checked = false
                }
            }

        }

        function ch1(id) {
            debugger;
            //alert(document.getElementById("chk_"+id).checked)
            //for (k=1;k<=document.getElementById("chk_"+id).value;k++)
            //{
            if (document.getElementById("chk_" + id).checked == true) {

                document.getElementById("chk1_" + id).checked = false
                document.getElementById("chk2_" + id).checked = false
                document.getElementById("chk1_" + id).disabled = false
                document.getElementById("chk2_" + id).disabled = false
            }
            else {
                document.getElementById("chk1_" + id).disabled = false
                document.getElementById("chk2_" + id).disabled = false
            }
        }

        //if(document.getElementById("chk_"+id).checked==false)
        //{

        //document.getElementById("chk1_"+id).checked=false
        //document.getElementById("chk2_"+id).checked=false
        //}

        function ch2(id) {
            debugger;
            //alert(document.getElementById("chk_"+id).checked)
            //for (k=1;k<=document.getElementById("chk_"+id).value;k++)
            //{
            if (document.getElementById("chk1_" + id).checked == true) {

                document.getElementById("chk_" + id).checked = false
                document.getElementById("chk2_" + id).checked = false
                document.getElementById("chk_" + id).disabled = false
                document.getElementById("chk2_" + id).disabled = false
            }
            else {
                document.getElementById("chk_" + id).disabled = false
                document.getElementById("chk2_" + id).disabled = false

            }
        }


        function ch3(id) {
            debugger;
            //alert(document.getElementById("chk_"+id).checked)
            //for (k=1;k<=document.getElementById("chk_"+id).value;k++)
            //{
            if (document.getElementById("chk2_" + id).checked == true) {

                document.getElementById("chk_" + id).checked = false
                document.getElementById("chk1_" + id).checked = false
                document.getElementById("chk_" + id).disabled = false
                document.getElementById("chk1_" + id).disabled = false
            }
            else {
                document.getElementById("chk_" + id).disabled = false
                document.getElementById("chk1_" + id).disabled = false
            }
        }

        //}

        //function ch2()
        //{
        //alert("hell")
        //for (k=1;k<=document.getElementById(txt+"hid_max").value;k)
        //{
        //if(document.getElementById("txt1_"+k).checked=true)
        //{

        //document.getElementById("txt_"+k).checked=false
        //document.getElementById("txt2_"+k).checked=false
        //}
        //}
        //}

        //function ch3()
        //{
        //alert("hel")
        //for (k=1;k<=document.getElementById(txt+"hid_max").value;k--)
        //{
        //if(document.getElementById("txt2_"+k).checked=true)
        //{

        //document.getElementById("txt1_"+k).checked=false
        //document.getElementById("txt_"+k).checked=false
        //}
        //}
        //}
        function check_dt() {
            debugger;
            alert("Select Date From Calender");
            return false;
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="Txt_Date"></cc1:CalendarExtender>
    <br />
    <div style="text-align: center">
        <table style="text-align: center">
            <tr>
                <td colspan="4" style="height: 50px; background-color: #ffcc00; text-align: center">
                    <strong><span style="font-size: 14pt; color: #ff0033">SELECTION FROM SHORT LISTED</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: center">
                    <strong>SELECT DATE<span style="color: #ff0033">*</span></strong></td>
                <td colspan="1" style="text-align: center">
                    <asp:TextBox ID="Txt_Date" runat="server" AutoPostBack="True" Width="203px" onkeypress="return check_dt()"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong><span style="color: #3300ff">SELECT CATEGORY &nbsp; &nbsp; </span></strong></td>
                <td style="height: 23px; text-align: left; width: 492px;" colspan="2">
                    <span style="color: #660000"><strong>CLEARED</strong></span><input id="Chk_all" type="checkbox" onclick="return Chk_all_onclick()" />
                    &nbsp; &nbsp;&nbsp; <span style="color: #660000"><strong>PENDING</strong></span><input
                        id="Checkbox1" type="checkbox" onclick="return Checkbox1_onclick()" />
                    &nbsp; &nbsp; <span style="color: #660000"><strong>REJECTED</strong></span><input id="Checkbox2" type="checkbox" onclick="return Checkbox2_onclick()" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 6px; text-align: center">&nbsp;


    <asp:Panel ID="Panel1" runat="server" Width="701px">
        <br />
    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 6px; text-align: center">
                    <br />
                    <table style="text-align: center">
                        <tr>
                            <td style="width: 124px">
                                <asp:Button ID="cmd_confirm" OnClientClick="sent_data_proc()" runat="server" Text="CONFIRM" BackColor="#FFC0C0" Font-Bold="True" ForeColor="Black" Width="135px" /></td>
                            <td style="width: 22px">
                                <input id="hid_max" runat="server" style="width: 13px" type="hidden" /></td>
                            <td style="width: 112px">
                                <asp:Button ID="Button1" runat="server" BackColor="#FFC0C0" Font-Bold="True" Text="EXIT"
                                    Width="141px" ForeColor="Black" BorderColor="Transparent" /></td>
                            <td style="width: 10px">
                                <input id="hid_data_sent" runat="server" style="width: 16px" type="hidden" /></td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="Hid_max1" runat="server" />
                    <asp:HiddenField ID="Hid_max2" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
</asp:Content>

