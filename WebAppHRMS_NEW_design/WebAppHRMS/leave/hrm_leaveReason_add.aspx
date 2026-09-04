<%@ Page Language="VB" MasterPageFile="~/edp.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="hrm_leaveReason_add.aspx.vb" Inherits="WebAppHRMS.Leave_Reason_Add_hrm_leaveReason_add_53e492664793" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('txt');
        function detailDisplay() {
            document.getElementById(con[0] + "hdnCat").value = document.getElementById(con[0] + "ddlCat").value;
            document.getElementById(con[0] + "txtAdd").value = "";
            if (document.getElementById(con[0] + "hdncat").value != -1) {
                callserver("1$" + document.getElementById(con[0] + "hdnCat").value, 1);
            }
            else {
                document.getElementById(con[0] + "ddlRea").value = "";

            }
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1:
                    {
                        var dist = arg.split("@");
                        document.getElementById(con[0] + "ddlRea").options.length = 0;
                        if (dist[0] == "") { alert("No Details ..!!!"); return false; }
                        ComboFill(dist[0], "ddlRea");
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
        function labelChangeC() {
            document.getElementById(con[0] + "lblAdd").innerHTML = "Enter Category";
            document.getElementById(con[0] + "txtAdd").value = "";
        }
        function labelChangeR() {
            document.getElementById(con[0] + "lblAdd").innerHTML = "Enter Reason";
            document.getElementById(con[0] + "txtAdd").value = "";
        }
        function ReaOnChange() {
            document.getElementById(con[0] + "hdnRea").value = document.getElementById(con[0] + "ddlRea").value;
            document.getElementById(con[0] + "txtAdd").value = "";
        }
        function ConOnClick() {
            if (document.getElementById(con[0] + "rdCat").checked == true) {
                //        if(document.getElementById(con[0]+"ddlCat").value==-1)
                //        {
                //            alert("Select Category...!");
                //            document.getElementById(con[0]+"ddlCat").focus();
                //            return false;
                //        }
                if (document.getElementById(con[0] + "txtAdd").value == "") {
                    alert("Enter Category...! ");
                    document.getElementById(con[0] + "txtAdd").focus();
                    return false;
                }
            }
            if (document.getElementById(con[0] + "rdRea").checked == true) {
                if (document.getElementById(con[0] + "ddlCat").value == -1) {
                    alert("Select Category...!");
                    document.getElementById(con[0] + "ddlCat").focus();
                    return false;
                }
                //        if(document.getElementById(con[0]+"ddlRea").value==-1)
                //        {
                //            alert("Select Reason...!");
                //            document.getElementById(con[0]+"ddlRea").focus();
                //            return false;
                //        }
                if (document.getElementById(con[0] + "txtAdd").value == "") {
                    alert("Enter Reason...! ");
                    document.getElementById(con[0] + "txtAdd").focus();
                    return false;
                }
            }

        }
        function btnExit_onclick() {
            window.open("../Home.aspx", "_self");
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="hdnCat" runat="server" />
        <asp:HiddenField ID="hdnRea" runat="server" />
        <table border="1" style="width: 50%">
            <tr>
                <td style="width: 25%; text-align: left">Select Category</td>
                <td style="width: 25%; text-align: left">
                    <asp:DropDownList ID="ddlCat" runat="server" onchange="detailDisplay()" Width="98%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left">Select Reasons</td>
                <td style="width: 25%; text-align: left">
                    <asp:DropDownList ID="ddlRea" runat="server" onchange="ReaOnChange()" Width="98%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="rdCat" runat="server" Checked="True" onclick="labelChangeC()" GroupName="leave" Text="Add Category" />
                    <asp:RadioButton ID="rdRea" runat="server" GroupName="leave" onclick="labelChangeR()" Text="Add Reason" /></td>
            </tr>
            <tr>
                <td style="width: 25%">
                    <asp:Label ID="lblAdd" runat="server" Text="Enter Category"></asp:Label></td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtAdd" runat="server" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ConOnClick()" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 25%"></td>
                <td style="width: 25%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

