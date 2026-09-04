<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="hrm_weekof_Change.aspx.vb" Inherits="WebAppHRMS.week_off_Change_hrm_weekof_Change_6e54092f5216" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('txt');

        function ddlBranchOnchange() {
            document.getElementById(con[0] + "hdnBranch").value = document.getElementById(con[0] + "ddlBranch").value;
            if (document.getElementById(con[0] + "hdnBranch").value == -1) {
                document.getElementById(con[0] + "ddlEcode").options.length = 0;
                document.getElementById(con[0] + "txtEcode").value = "";
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtBranch").value = "";
                document.getElementById(con[0] + "txtPost").value = "";
                document.getElementById(con[0] + "txtDep").value = "";
                document.getElementById(con[0] + "txtDay").value = "";
                document.getElementById(con[0] + "ddlDay").value = -1;
                return false;
            }
            else {
                callserver("1$" + document.getElementById(con[0] + "hdnBranch").value, 1);
                document.getElementById(con[0] + "txtEcode").value = "";
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtBranch").value = "";
                document.getElementById(con[0] + "txtPost").value = "";
                document.getElementById(con[0] + "txtDep").value = "";
                document.getElementById(con[0] + "txtDay").value = "";
                document.getElementById(con[0] + "ddlDay").value = -1;
                return false;
            }
        }
        function ddlEcodeOnchange() {
            document.getElementById(con[0] + "hdnEcode").value = document.getElementById(con[0] + "ddlEcode").value;
            if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                document.getElementById(con[0] + "txtEcode").value = "";
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtBranch").value = "";
                document.getElementById(con[0] + "txtPost").value = "";
                document.getElementById(con[0] + "txtDep").value = "";
                document.getElementById(con[0] + "txtDay").value = "";
                document.getElementById(con[0] + "ddlDay").value = -1;
                return false;
            }
            else {
                callserver("2$" + document.getElementById(con[0] + "hdnEcode").value, 2);
                return false;
            }
        }
        function call_receiver(arg, context) {

            switch (context) {
                case 1:
                    {
                        var dist = arg.split("@");
                        document.getElementById(con[0] + "ddlEcode").options.length = 0;
                        if (dist[0] == "") {
                            alert("No Details ..!!!");
                            return false;
                        }
                        ComboFill(dist[0], "ddlEcode");
                        break;
                    }
                case 2:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("This Employee has weekly off not assigned...!!! Please Assign Week Off.....!!!");
                            document.getElementById(con[0] + "txtEcode").value = "";
                            document.getElementById(con[0] + "txtEname").value = "";
                            document.getElementById(con[0] + "txtBranch").value = "";
                            document.getElementById(con[0] + "txtPost").value = "";
                            document.getElementById(con[0] + "txtDep").value = "";
                            document.getElementById(con[0] + "txtDay").value = "";
                            document.getElementById(con[0] + "ddlDay").value = -1;
                            document.getElementById(con[0] + "ddlEcode").value = -1;
                            return false;
                        }
                        else {

                            document.getElementById(con[0] + "txtEcode").value = accdtl[0];
                            document.getElementById(con[0] + "txtEname").value = accdtl[1];
                            document.getElementById(con[0] + "txtBranch").value = accdtl[2];
                            document.getElementById(con[0] + "txtPost").value = accdtl[3];
                            document.getElementById(con[0] + "txtDep").value = accdtl[4];
                            document.getElementById(con[0] + "txtDay").value = accdtl[5];
                            document.getElementById(con[0] + "ddlDay").value = -1;
                        }
                        break;
                    }
            }
        }
        function ComboFill(Data, ComboName) {
            if (Data[0] == '') return;

            var rows = Data.split("*");
            for (a = 0; a < rows.length; a++) {
                var cols = rows[a].split("$");
                var option1 = document.createElement("OPTION");
                option1.value = cols[0];
                option1.text = cols[1];
                document.getElementById(con[0] + ComboName).add(option1);
            }
        }
        function onBtnBranchClick() {
            if (document.getElementById(con[0] + "ddlBranch").value == -1) {
                alert("Please Select Branch...!");
                document.getElementById(con[0] + "ddlBranch").focus();
                return false;
            }
        }
        function btnViewDtl_onclick() {
            if (document.getElementById(con[0] + "ddlBranch").value == -1) {
                alert("Please Select Branch...!");
                document.getElementById(con[0] + "ddlBranch").focus();
            }
            else {
                window.open('Week_Off_Report.aspx?bran_name=' + document.getElementById(con[0] + "ddlBranch").value + '');
            }
        }
        function btnEmployee_onclick() {
            if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                alert("Please Select Employee...!");
                document.getElementById(con[0] + "ddlEcode").focus();
            }
            else if (document.getElementById(con[0] + "ddlEcode").value == "") {
                alert("Please Select Branch...!");
                document.getElementById(con[0] + "ddlBranch").focus();
            }
            else {
                window.open('Week_Off_Status.aspx?emp_id=' + document.getElementById(con[0] + "ddlEcode").value + '');
            }
        }
        function ddlDayonChange() {
            document.getElementById(con[0] + "hdnDay").value = document.getElementById(con[0] + "ddlDay").value;
        }
        function onConfClick() {
            if (document.getElementById(con[0] + "ddlBranch").value == -1) {
                alert("Please Select Branch...!");
                document.getElementById(con[0] + "ddlBranch").focus();
                return false;
            }
            if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                alert("Please Select Employee...!");
                document.getElementById(con[0] + "ddlEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "ddlDay").value == -1) {
                alert("Please Select Day...!");
                document.getElementById(con[0] + "ddlDay").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtReason").value == "") {
                alert("Please Enter Reason...!");
                document.getElementById(con[0] + "txtReason").focus();
                return false;
            }
        }
        function btnExit_onclick() {
            window.open("../home.aspx", "_self");
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <asp:HiddenField ID="hdnBranch" runat="server" />
        <asp:HiddenField ID="hid_zonal" runat="server" />
        <asp:HiddenField ID="hdnDay" runat="server" />
        <table border="1" style="width: 70%">
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Select Branch</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="98%" onchange="ddlBranchOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btnViewDtl" type="button" value="Click To View Weekly OFF Status of Branch" onclick="return btnViewDtl_onclick()" />&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Select Employee</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlEcode" runat="server" Width="98%" onchange="ddlEcodeOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Emp Code</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEcode" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Employee Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEname" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtBranch" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Post</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtPost" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Department</td>
                <td style="width: 15%; text-align: left">
                    <asp:TextBox ID="txtDep" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Current Week off Day</td>
                <td style="width: 15%; text-align: left">
                    <asp:TextBox ID="txtDay" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btnEmployee" type="button" value="Click To View Week OFF Status of Employee" onclick="return btnEmployee_onclick()" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Select Day</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlDay" runat="server" Width="99%" onchange="ddlDayonChange()">
                        <asp:ListItem Value="-1">-----Select Day-----</asp:ListItem>
                        <asp:ListItem Value="1">SUNDAY</asp:ListItem>
                        <asp:ListItem Value="2">MONDAY</asp:ListItem>
                        <asp:ListItem Value="3">TUESDAY</asp:ListItem>
                        <asp:ListItem Value="4">WEDNESDAY</asp:ListItem>
                        <asp:ListItem Value="5">THURSDAY</asp:ListItem>
                        <asp:ListItem Value="6">FRIDAY</asp:ListItem>
                        <asp:ListItem Value="7">SATURDAY</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <strong>Reason For Change</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return onConfClick()" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
                <td style="width: 15%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

