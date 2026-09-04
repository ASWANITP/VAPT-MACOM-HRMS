<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="empsearch.aspx.vb" Inherits="WebAppHRMS.raj_empsearch_f1c626619061" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont = loanno.split('txt');

        function cmdExit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function CheckCodeClick() {
            if (document.getElementById(cont[0] + "checkEmpCode").checked == true) {
                document.getElementById(cont[0] + "checkEmpName").checked = false;
                document.getElementById(cont[0] + "txtEmpCode").disabled = false;
                document.getElementById(cont[0] + "txtEmpName").value = "";
                document.getElementById(cont[0] + "txtEmpName").disabled = true;
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "checkEmpCode").checked == false) {
                document.getElementById(cont[0] + "checkEmpName").checked = true;
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").disabled = true;
                document.getElementById(cont[0] + "txtEmpName").disabled = false;
                document.getElementById(cont[0] + "txtEmpName").value = "";
                document.getElementById(cont[0] + "txtEmpName").focus();
                return false;
            }
        }
        function CheckNameClick() {
            if (document.getElementById(cont[0] + "checkEmpName").checked == true) {
                document.getElementById(cont[0] + "checkEmpCode").checked = false;
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").disabled = true;
                document.getElementById(cont[0] + "txtEmpName").disabled = false;
                document.getElementById(cont[0] + "txtEmpName").value = "";
                document.getElementById(cont[0] + "txtEmpName").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "checkEmpName").checked == false) {
                document.getElementById(cont[0] + "checkEmpCode").checked = true;
                document.getElementById(cont[0] + "txtEmpCode").disabled = false;
                document.getElementById(cont[0] + "txtEmpName").value = "";
                document.getElementById(cont[0] + "txtEmpName").disabled = true;
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").focus();
                return false;
            }
        }
        function OnConfirmCheck() {
            if ((document.getElementById(cont[0] + "checkEmpCode").checked == true) && (document.getElementById(cont[0] + "checkEmpName").checked == true)) {
                init;
                return false;
            }
            if ((document.getElementById(cont[0] + "checkEmpCode").checked == false) && (document.getElementById(cont[0] + "checkEmpName").checked == false)) {
                init;
                return false;
            }
            if (document.getElementById(cont[0] + "checkEmpCode").checked == true) {
                if ((document.getElementById(cont[0] + "txtEmpCode").value == "") || (document.getElementById(cont[0] + "txtEmpCode").value < 10001)) {
                    alert('Please Enter a Valid Employee Code..!! Enter in Digits..!!');
                    document.getElementById(cont[0] + "txtEmpCode").disabled = false;
                    document.getElementById(cont[0] + "txtEmpCode").value = "";
                    document.getElementById(cont[0] + "txtEmpCode").focus();
                    return false;
                }
            }
            if (document.getElementById(cont[0] + "checkEmpName").checked == true) {
                if (document.getElementById(cont[0] + "txtEmpName").value == "") {
                    alert('Please Enter Name or Part of Name of Employee..!!');
                    document.getElementById(cont[0] + "txtEmpName").disabled = false;
                    document.getElementById(cont[0] + "txtEmpName").value = "";
                    document.getElementById(cont[0] + "txtEmpName").focus();
                    return false;
                }
            }
        }
        function EmpCodeKeyUp() {
            var a = document.getElementById(cont[0] + "txtEmpCode").value;
            if (isNaN(a)) {
                alert('Please enter correct Employee Code in number Format!!');
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").focus();
                return false;
            }
        }
        function EmpCodeFind() {
            if (document.getElementById(cont[0] + "txtEmpCode").value == "" || parseInt(document.getElementById(cont[0] + "txtEmpCode").value) < 10001) {
                alert('Please Enter a Valid Employee Code..!!');
                document.getElementById(cont[0] + "txtEmpCode").value = "";
                document.getElementById(cont[0] + "txtEmpCode").focus();
                return false;
            }
            else {
                call_server("1$" + document.getElementById(cont[0] + "txtEmpCode").value);
            }
        }
        function call_receiver(arg1) {
            var arg2, dat;
            arg2 = arg1.split("@");
            if (arg2[0] == 11) {
                if (arg2[1] == "N") {
                    alert('There is No Employee Exists in This Code..!! Please Check..!!');
                    document.getElementById(cont[0] + "txtEmpCode").value = "";
                    document.getElementById(cont[0] + "txtEmpCode").focus();
                }
            }
        }
        function IsCharacter(a) {
            //var strValidChars = "0123456789.";   //"0123456789.-";
            var strString = document.getElementById(cont[0] + a).value;
            var strValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ. ";  ///  0123456789 also der..!!
            var strChar;
            var blnResult = true;
            if (strString.length == 0) return false;
            // test strString consists of valid characters listed above
            for (i = 0; i < strString.length && blnResult == true; i++) {
                strChar = strString.charAt(i);
                if (strValidChars.indexOf(strChar) == -1) {
                    blnResult = false;
                    strString = "";
                    document.getElementById(cont[0] + a).value = "";
                    alert("Please Enter Characters only..!");
                }
            }
            strString = strString.toUpperCase();
            document.getElementById(cont[0] + a).value = strString;
            return blnResult;
        }
        function init() {
            document.getElementById(cont[0] + "checkEmpCode").checked = true;
            document.getElementById(cont[0] + "checkEmpName").checked = false;
            document.getElementById(cont[0] + "txtEmpCode").value = "";
            document.getElementById(cont[0] + "txtEmpName").value = "";
            document.getElementById(cont[0] + "txtEmpName").disabled = true;
            document.getElementById(cont[0] + "txtEmpCode").disabled = false;
            document.getElementById(cont[0] + "txtEmpCode").focus();
        }
        window.onload = init;
    </script>

    <div style="text-align: center">
        <br />
        <table border="1" style="width: 52%; font-family: 'Bookman Old Style'; font-variant: small-caps;">
            <tr>
                <td style="width: 35%; text-align: left;">&nbsp;<asp:CheckBox ID="checkEmpCode" onclick="CheckCodeClick()" runat="server" Width="320px" Text=" Enter Employee Code" Style="cursor: hand; font-family: 'Bookman Old Style'" /></td>
                <td style="width: 35%; text-align: left;">
                    <asp:TextBox ID="txtEmpCode" onkeyup="return EmpCodeKeyUp()" onchange="return EmpCodeFind()" runat="server" MaxLength="6" Style="font-family: 'Bookman Old Style'; text-align: center"
                        Width="154px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 35%; text-align: left">&nbsp;<asp:CheckBox ID="checkEmpName" onclick="CheckNameClick()" runat="server" Width="318px" Text=" Enter Name/Part of Name" Style="cursor: hand; font-family: 'Bookman Old Style'" /></td>
                <td style="width: 35%; text-align: left">
                    <asp:TextBox ID="txtEmpName" onkeyup="return IsCharacter('txtEmpName')" runat="server" MaxLength="12" Style="font-family: 'Bookman Old Style'"
                        Width="154px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <div style="text-align: center">
                        <table style="width: 158px">
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Button ID="cmdConfirm" OnClientClick="return OnConfirmCheck()" runat="server" Style="cursor: hand; font-family: 'Bookman Old Style'"
                                        Text="Confirm" /></td>
                                <td style="width: 100px; text-align: left">
                                    <input id="cmdExit" style="cursor: hand; font-family: 'Bookman Old Style'; width: 81px;" type="button"
                                        value="Exit" onclick="return cmdExit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

