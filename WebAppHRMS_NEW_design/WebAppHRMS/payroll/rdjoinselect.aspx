<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="rdjoinselect.aspx.vb" Inherits="WebAppHRMS.RD_Deduction_rdjoinselect_27bb72a19269" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont_name = sal.split('Txt');
        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        function checknum(a) {
            var ecode = document.getElementById(cont_name[0] + a).value;
            if (isNaN(ecode)) {
                document.getElementById(cont_name[0] + a).value = ""
                return false;
            }

        }
        function cliclick() {

            if (document.getElementById(cont_name[0] + "Txt_EmpFrom").value == "") {
                alert('Please Enter Min Emp Code !!');
                return false;
            }
            if (document.getElementById(cont_name[0] + "Txt_EmpTo").value == "") {
                alert('Please Enter Max Emp Code !!');
                return false;
            }
        }
        // ]]>
    </script>

    <br />
    <br />

    <br />

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td style="width: 145px; text-align: left">
                    <strong>Emp Code From:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_EmpFrom" onkeyup="return checknum('Txt_EmpFrom')" runat="server" MaxLength="5" TabIndex="1"></asp:TextBox></td>
                <td style="width: 100px; text-align: left">
                    <strong>Emp Code To:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_EmpTo" onkeyup="return checknum('Txt_EmpTo')" runat="server" MaxLength="5" TabIndex="2"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <input id="Cmd_Exit" type="button" value="EXIT" style="width: 66px" onclick="return Cmd_Exit_onclick()" tabindex="3" /></td>
                <td colspan="2" style="text-align: left">
                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" TabIndex="4" /></td>
            </tr>
        </table>
    </div>
    <br />
    <div style="text-align: center">
        <br />
        <br />
        <br />
        &nbsp;
    </div>
</asp:Content>

