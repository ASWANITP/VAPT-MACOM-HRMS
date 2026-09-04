<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="RemovePunchBlock.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_RemoveDateBlock_c07538d45380" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cont = loanno.split('txt')

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }

        function OnBlurEmpCode() {
            EmpCode = document.getElementById(cont[0] + "txt_Code").value;
            var Status = "-11";

            if (EmpCode == "") { alert("Enter Employ Code...!!!"); document.getElementById(cont[0] + "txt_Code").focus(); return false; }
            var EmpLength = EmpCode.length;
            if (Math.abs(EmpLength) < 5) { alert("Employee Code Not a Valid "); document.getElementById(cont[0] + "txt_Code").focus(); return false; }
            ToData = EmpCode + "%" + Status;
            ToServer(ToData + "#" + 1, 1)
        }


        function OnClickConfirm() {

            var EmpCode = document.getElementById(cont[0] + "txt_Code").value;
            var Status = "-22";
            if (EmpCode == "") {
                alert("Enter Employ Code...!!!");
                document.getElementById(cont[0] + "txt_Code").focus();
                return false;
            }
            ToData = EmpCode + "%" + Status;
            ToServer(ToData + "#" + 2, 2)
        }

        function FromServer(arg, context) {
            var Data = arg.split("@")
            switch (context) {
                case 1:
                    if (Data[0] == "") { alert("No Employee Exist..!!!"); return false }
                    document.getElementById(cont[0] + "txt_Name").value = Data[0];
                    break;
                case 2:
                    alert(arg)
                    document.getElementById(cont[0] + "txt_Code").value = "";
                    document.getElementById(cont[0] + "txt_Name").value = "";
                    break;
            }
        }

        function IsNumberOnly() {
            if (isNaN(document.getElementById(cont[0] + "txt_Code").value)) { document.getElementById(cont[0] + "txt_Code").value = ""; return false; }

        }
        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 40%; font-family: Courier New">
            <tr>
                <td style="width: 20%; height: 23px;">Enter Employ Code</td>
                <td style="width: 20%; height: 23px;">
                    <asp:TextBox ID="txt_Code" runat="server" onfocusout="IsNumberOnly()" Width="175px" MaxLength="5"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 23px;">Employ Name</td>
                <td style="width: 20%; height: 23px;">
                    <asp:TextBox ID="txt_Name" runat="server" Width="175px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 23px" colspan="2">
                    <input id="Button2" type="button" value="CONFIRM" onclick="OnClickConfirm()" style="width: 72px; font-family: 'Courier New'" />
                    <input id="Button1" style="width: 56px; font-family: 'Courier New';"
                        type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

