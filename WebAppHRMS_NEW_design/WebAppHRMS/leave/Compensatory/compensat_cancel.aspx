<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="compensat_cancel.aspx.vb" Inherits="WebAppHRMS.staffaccount_compensat_cancel_3dafddb82523" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script for="window" event="onload">return WindowOnload()</script>
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('cmb');
        function WindowOnload() {
            call_server("1*" + document.getElementById(con[0] + "hid_key").value, 1);
        }
        function compensatoryOnchange() {
            //debugger;
            var brid = document.getElementById(con[0] + "cmb_com").value;
            document.getElementById(con[0] + "Hidden1").value = brid;
            call_server("2*" + brid, 2);
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1:
                    {    //debugger;
                        document.getElementById(con[0] + "cmb_com").options.length = 0;
                        var rows = arg.split("%");
                        if (rows.length < 2) {
                            alert("No Compensatory to Cancel");
                            return false;
                        }
                        for (a = 0; a < rows.length; a++) {
                            var cols = rows[a].split("@");
                            var option1 = document.createElement("OPTION");
                            option1.value = cols[0];
                            option1.text = cols[1];
                            document.getElementById(con[0] + "cmb_com").add(option1);
                        }
                        break;
                    }
                case 2:
                    {
                        // document.getElementById(con[0]+"Hidden1").value=arg;
                        var a = arg.split("#");
                        document.getElementById(con[0] + "txt_empcd").value = a[0];
                        document.getElementById(con[0] + "txt_enm").value = a[1];
                        document.getElementById(con[0] + "txt_appl").value = a[2];
                        document.getElementById(con[0] + "txt_leave").value = a[3];
                        document.getElementById(con[0] + "txt_rsn").value = a[4];
                        break;
                    }
            }
        }
        function fillcheck() {
            if (document.getElementById(con[0] + "cmb_com").value == "-1" || document.getElementById(con[0] + "cmb_com").value == "") {
                alert("Select Compensatory");
                return false;
            }
        }


        function cmd_ext_onclick() {
            window.open('../../home.aspx', '_self');
        }



        // ]]>
    </script>


    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="text-align: center; background-color: mintcream;">
                    <span style="font-size: 14pt; font-family: Courier New; color: #cc3333;"><strong>COMPENSATORY CANCELLATION</strong></span></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <span style="font-family: Courier New"><strong>Select Compensatory</strong></span></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_com" runat="server" Width="298px" Style="font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;Code</span></td>
                <td style="width: 100px">
                    <input id="txt_empcd" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'" /></td>
                <td style="width: 126px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;name</span></td>
                <td style="width: 99px">
                    <input id="txt_enm" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'" /></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: left">
                    <span style="font-family: Courier New">Leave Date</span></td>
                <td style="width: 100px">
                    <input id="txt_leave" runat="server" readonly="readonly" type="text" style="font-family: 'Courier New'" /></td>
                <td style="width: 126px; text-align: left">
                    <span style="font-family: Courier New">Applied Date</span></td>
                <td style="width: 99px">
                    <input id="txt_appl" runat="server" readonly="readonly" type="text" style="font-family: 'Courier New'" /></td>
            </tr>
            <tr>
                <td style="width: 109px; text-align: left">
                    <span style="font-family: Courier New">Reason</span></td>
                <td colspan="3" style="text-align: left">
                    <input id="txt_rsn" runat="server" style="width: 467px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <input id="Hidden1" runat="server" style="width: 1px" type="hidden" />
                    <input id="hid_key" runat="server" style="width: 1px" type="hidden" />
                    <asp:Button ID="cmd_confirm" runat="server" OnClientClick="return fillcheck()" Text="CONFIRM" Style="font-family: 'Courier New'" /></td>
                <td colspan="2" style="text-align: left">
                    <input id="cmd_ext" style="width: 70px; font-family: 'Courier New';" type="button" value="EXIT" onclick="return cmd_ext_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

