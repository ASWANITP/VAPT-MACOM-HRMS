<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_applied_status.aspx.vb" Inherits="WebAppHRMS.Leave_Module_leave_applied_status_3f8d0f7a8364" Title="Untitled Page" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    
      <script src="https://cdnjs.cloudflare.com/ajax/libs/crypto-js/4.1.1/crypto-js.min.js"></script>
   
    <%----VAPT clear text------%>
    <script type="text/javascript">
        function encryptData(plainText) {
            var keyString = document.getElementById("<%= hdnEdata.ClientID %>").value;
            // Convert key and IV to WordArray
            var secretKey = CryptoJS.enc.Utf8.parse(keyString);
            var iv = CryptoJS.enc.Utf8.parse(keyString);

            // Perform AES 
            var encrypted = CryptoJS.AES.encrypt(
                CryptoJS.enc.Utf8.parse(plainText),
                secretKey,
                {
                    iv: iv,
                    mode: CryptoJS.mode.CBC,
                    padding: CryptoJS.pad.Pkcs7
                }
            );

            // Return ciphertext in Base64 format
            return encrypted.ciphertext.toString(CryptoJS.enc.Base64);
        }
        window.onload = function () {
            var ddl = document.getElementById("<%= cmb_code.ClientID %>");
            document.getElementById("<%= hdnSelectedEmp.ClientID %>").value = encryptData(ddl.options[ddl.selectedIndex].value);
            ddl.options[ddl.selectedIndex].value = encryptData(ddl.options[ddl.selectedIndex].value);
            ddl.onchange = function () {
                var selectedValue = ddl.options[ddl.selectedIndex].value;
                ddl.options[ddl.selectedIndex].value = encryptData(selectedValue);
                document.getElementById("<%= hdnSelectedEmp.ClientID %>").value = encryptData(selectedValue);
             };
            var user = document.getElementById("<%= txt_to.ClientID %>");
           // document.getElementById("<%= txt_to.ClientID %>").value = encryptData(document.getElementById("<%= txt_to.ClientID %>").value);
            user.onchange = function () {
                this.value = encryptData(this.value);  // change input type to password
               
            };
            var user = document.getElementById("<%= txt_from.ClientID %>");
            //document.getElementById("<%= txt_from.ClientID %>").value = encryptData(document.getElementById("<%= txt_from.ClientID %>").value);
            user.onchange = function () {
                this.value = encryptData(this.value);  // change input type to password
               
            };
        };
    </script>
    <br />
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 503px; height: 99px">
            <tr>
                <td style="width: 186px; text-align: right">Employee Name :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_code" runat="server" Width="340px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 186px; text-align: right" rowspan="2">Leave&nbsp; &nbsp;Apply Date
                </td>
                <td style="width: 16px; height: 33px; text-align: right;">From :
                </td>
                <td style="width: 100px; height: 33px; text-align: left">
                    <asp:TextBox ID="txt_from" onblur="check_date('txt_from')" runat="server"></asp:TextBox>
                    &nbsp; &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_from"></cc1:CalendarExtender>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 16px; height: 33px; text-align: right">To :
                </td>
                <td style="width: 100px; height: 33px; text-align: left">
                    <asp:TextBox ID="txt_to" onblur="check_date('txt_to')" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_to"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <input id="Button1" style="width: 68px" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
                                <td style="width: 100px">
                                   <%-- <asp:Button ID="cmd_confirm" runat="server" OnClientClick="return checkconfirm()" Text="CONFIRM" Width="79px" />--%>
                                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="79px" />

                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <input id="hdn_sysdate" type="hidden" runat="server" />
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
        </cc1:ListSearchExtender>
    <%--   ---- VAPT Clear text--%>
          <asp:HiddenField ID="hdnEdata" runat="server" />
          <asp:HiddenField ID="hdnSelectedEmp" runat="server" />
    </div>
</asp:Content>

