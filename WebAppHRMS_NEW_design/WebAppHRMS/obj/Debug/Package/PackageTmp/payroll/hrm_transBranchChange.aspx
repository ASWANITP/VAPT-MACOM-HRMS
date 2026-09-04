<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_transBranchChange.aspx.vb" Inherits="WebAppHRMS.Transfer_Branch_Change_hrm_transBranchChange_0fe5d1481819" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>

    <script language="javascript" type="text/javascript">
        var con = header.split('txt');
        function window_onload() {
            document.getElementById("rowBranch").style.display = 'Inline';
            document.getElementById("rowDate").style.display = 'none';
        }
        function detailDisplay() {
            debugger;
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                document.getElementById(con[0] + "txtEname").value = "";
                document.getElementById(con[0] + "txtDep").value = "";
                document.getElementById(con[0] + "txtDes").value = "";
                document.getElementById(con[0] + "txtBranch").value = "";
                document.getElementById(con[0] + "txtPost").value = "";
                document.getElementById(con[0] + "txtJdate").value = "";
                document.getElementById(con[0] + "ddlBranch").value = -1;
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value != "") {
                callserver("1$" + document.getElementById(con[0] + "txtEcode").value, 1);
            }
        }

        function call_receiver(arg, context) {
            //debugger;
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Select valid Employee Code");
                            document.getElementById(con[0] + "txtEcode").value = "";
                            document.getElementById(con[0] + "txtEname").value = "";
                            document.getElementById(con[0] + "txtDep").value = "";
                            document.getElementById(con[0] + "txtDes").value = "";
                            document.getElementById(con[0] + "txtBranch").value = "";
                            document.getElementById(con[0] + "txtPost").value = "";
                            document.getElementById(con[0] + "txtJdate").value = "";
                            document.getElementById(con[0] + "ddlBranch").value = -1;
                            document.getElementById(con[0] + "txtEcode").focus();
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txtEname").value = accdtl[0];
                            document.getElementById(con[0] + "txtDep").value = accdtl[1];
                            document.getElementById(con[0] + "txtDes").value = accdtl[2];
                            document.getElementById(con[0] + "txtBranch").value = accdtl[3];
                            document.getElementById(con[0] + "txtPost").value = accdtl[4];
                            document.getElementById(con[0] + "txtJdate").value = accdtl[5];
                            document.getElementById(con[0] + "ddlBranch").value = -1;

                        }
                        break;
                    }
            }
        }
        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
        }
        function rdBranchClick() {
            document.getElementById("rowBranch").style.display = 'Inline';
            document.getElementById("rowDate").style.display = 'none';
            document.getElementById(con[0] + "txtDate").value = "";
            document.getElementById(con[0] + "ddlBranch").value = -1;
        }
        function rdDateClick() {
            document.getElementById("rowBranch").style.display = 'none';
            document.getElementById("rowDate").style.display = 'Inline';
            document.getElementById(con[0] + "txtDate").value = "";
            document.getElementById(con[0] + "ddlBranch").value = -1;
        }
        function ddlOnChange() {
            document.getElementById(con[0] + "hdnBranch").value = document.getElementById(con[0] + "ddlBranch").value;
        }
        function check_date(Control) {
            var day1, day2;
            var month1, month2;
            var year1, year2;
            if (document.getElementById(con[0] + Control).value != "") {
                var value1 = document.getElementById(con[0] + Control).value;
                var dt = new Date().format("dd/MMM/yyyy");
                var value2 = dt;

                day1 = value1.substring(0, value1.indexOf("/"));
                month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
                year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

                day2 = value2.substring(0, value2.indexOf("/"));
                month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
                year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

                date1 = year1 + "/" + month1 + "/" + day1;
                date2 = year2 + "/" + month2 + "/" + day2;

                firstDate = Date.parse(date1)
                secondDate = Date.parse(date2)

                msPerDay = 24 * 60 * 60 * 1000

                dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);
                if (dbd > 0) {
                    alert("Please Do Not Enter Earlier Date ..!!")
                    document.getElementById(con[0] + Control).value = '';
                    document.getElementById(con[0] + Control).focus();
                    return false;
                }
            }

        }
        function DateCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(con[0] + "txtDate").value = '';
            return false;
        }
        function onclickconf() {
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert("Please Enter Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEname").value == "") {
                alert("Please Enter Valid Employee Code");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "rdBranch").checked == true) {
                if (document.getElementById(con[0] + "ddlBranch").value == -1) {
                    alert("Please Select Branch...!");
                    document.getElementById(con[0] + "ddlBranch").focus();
                    return false;
                }
            }
            if (document.getElementById(con[0] + "rdDate").checked == true) {
                if (document.getElementById(con[0] + "txtDate").value == "") {
                    alert("Please Select Date...!");
                    document.getElementById(con[0] + "txtDate").focus();
                    return false;
                }
            }
        }
        function btnExit_onclick() {
            window.open('../home.aspx', '_self');
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txtDate"></cc1:CalendarExtender>
        <asp:HiddenField ID="hdnBranch" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">Enter Employee Code</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtEcode" runat="server" Width="80%" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Employee Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Department</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtDep" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Designation</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtDes" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">Post</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtPost" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">Join Date</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtJdate" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:RadioButton ID="rdBranch" runat="server" Checked="True" GroupName="cha" Text="Branch" onclick="rdBranchClick()" />
                    <asp:RadioButton ID="rdDate" runat="server" GroupName="cha" Text="Date" onclick="rdDateClick()" /></td>
            </tr>
            <tr id="rowBranch">
                <td colspan="2" style="text-align: left">Change Branch</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="85%" onchange="ddlOnChange()">
                    </asp:DropDownList></td>
            </tr>
            <tr id="rowDate">
                <td colspan="2" style="text-align: left">Change Date</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="83%" onkeyup="DateCheck()" onblur="check_date('txtDate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return onclickconf()" />
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

