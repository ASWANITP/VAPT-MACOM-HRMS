<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leav_canc_to.aspx.vb" Inherits="WebAppHRMS.leave_leav_canc_b481b37b4524" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        var cont = cont_name.split("txt");
        function fill() {
            var arr, cnt, arr2;
            arr = document.getElementById(cont[0] + "cmb_emp").value.split("*")
            document.getElementById(cont[0] + "txt_code").value = arr[0]
            document.getElementById(cont[0] + "txt_name").value = arr[1]
            document.getElementById(cont[0] + "txt_type").value = arr[2]
            document.getElementById(cont[0] + "txt_appl_dt").value = arr[6]
            document.getElementById(cont[0] + "txt_from").value = arr[3]
            document.getElementById(cont[0] + "txt_to").value = arr[4]
            document.getElementById(cont[0] + "txt_reason").value = arr[7]
            document.getElementById(cont[0] + "txt_days").value = arr[5]
            document.getElementById(cont[0] + "hid_seq").value = arr[8]
        }
        function Button2_onclick() {
            window.open("../home.aspx", '_self')
        }
        function check_null() {
            if (document.getElementById(cont[0] + "cmb_emp").options[document.getElementById(cont[0] + "cmb_emp").selectedIndex].text == "NO LEAVE TO BE CANCELLED") {
                alert("NO LEAVE TO BE CANCELLED")
                return false;
            }
        }
    </script>
    <div style="text-align: center">
        <table border="1" style="width: 624px; height: 55px">
            <tr>
                <td colspan="5">
                    <strong><span style="font-size: 14pt; font-family: Courier New;">LEAVE CANCELLATION</span></strong></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="668px" OnChange="return fill()" Font-Names="Courier New">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="lbl_message" runat="server" Width="668px" Font-Names="Courier New"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 15px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Code</span></td>
                <td style="width: 12px; height: 15px; text-align: left;">
                    <input id="txt_code" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
                <td style="width: 130px; height: 15px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Name</span></td>
                <td style="height: 15px; text-align: left;" colspan="2">
                    <input id="txt_name" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 8px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave Type</span></td>
                <td style="width: 12px; height: 8px; text-align: left;">
                    <input id="txt_type" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
                <td style="width: 130px; height: 8px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave&nbsp;Apply&nbsp;Date</span></td>
                <td style="height: 8px; text-align: left;" colspan="2">
                    <input id="txt_appl_dt" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 5px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave From </span>
                </td>
                <td style="width: 12px; height: 5px; text-align: left;">
                    <input id="txt_from" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
                <td style="width: 130px; height: 5px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave To</span></td>
                <td style="height: 5px; text-align: left;" colspan="2">
                    <input id="txt_to" type="text" style="width: 127px; font-size: 11pt; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 210px; height: 4px; text-align: left;">
                    <span style="font-size: 11pt; font-family: Courier New">Reason</span></td>
                <td colspan="2" style="height: 4px; text-align: left">
                    <input id="txt_reason" style="width: 275px; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" />&nbsp;</td>
                <td style="width: 44px; height: 4px; text-align: left;">Days</td>
                <td style="width: 102px; height: 4px; text-align: left">
                    <input id="txt_days" style="width: 79px; font-size: 11pt; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 12px; text-align: right">
                    <input id="hid_seq" runat="server" style="width: 7px" type="hidden" />
                    <input id="hid_value" runat="server" style="width: 1px" type="hidden" />
                    <asp:Button ID="Button1" runat="server" Text="Confirm" Width="87px" OnClientClick="return check_null()" Style="font-size: 11pt; font-family: 'Courier New'" Height="26px" /></td>
                <td style="height: 12px; text-align: left;" colspan="3">
                    <input id="Button2" style="width: 75px; font-size: 11pt; font-family: 'Courier New';" type="button" value="Exit" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

