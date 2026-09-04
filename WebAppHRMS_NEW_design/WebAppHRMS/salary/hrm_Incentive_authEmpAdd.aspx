<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Incentive_authEmpAdd.aspx.vb" Inherits="WebAppHRMS.Incetive_AthorisedEmp_Add_hrm_Incentive_authEmpAdd_c7211eda6869" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('txt');

        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
        }
        function ddlOnchange() {
            document.getElementById(con[0] + "hdnIns").value = document.getElementById(con[0] + "ddlIns").value
        }
        function detailDisplay() {
            if (isNaN(document.getElementById(con[0] + "txtEcode").value)) {
                document.getElementById(con[0] + "txtEcode").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                document.getElementById(con[0] + "txtEname").value = "";
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value != "") {
                callserver("1$" + document.getElementById(con[0] + "txtEcode").value, 1);
            }
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Select Valid Employee Code");
                            document.getElementById(con[0] + "txtEname").value = "";
                            document.getElementById(con[0] + "txtEcode").value = "";
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txtEname").value = accdtl[0];
                        }
                        break;
                    }
            }

        }
        function OnConfClick() {
            if (document.getElementById(con[0] + "ddlIns").value == -1) {
                alert("Please Select Incentive...!!!");
                document.getElementById(con[0] + "ddlIns").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEcode").value == "") {
                alert("Please Enter Employee Code...!!!");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txtEname").value == "") {
                alert("Please Enter Valid Employee Code...!!!");
                document.getElementById(con[0] + "txtEcode").focus();
                return false;
            }
        }
        function btnExit_onclick() {
            window.open("../Home.aspx", "_self");
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="ddlIns"></cc1:ListSearchExtender>
        <asp:HiddenField ID="hdnIns" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2">Select Incentive</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlIns" runat="server" Width="95%" onchange="ddlOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left; height: 41px;">Enter Emp. Code</td>
                <td style="width: 14%; height: 41px;">
                    <asp:TextBox ID="txtEcode" runat="server" Width="97%" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="6"></asp:TextBox></td>
                <td style="width: 13%; text-align: left; height: 41px;">Emp. Name</td>
                <td style="width: 15%; height: 41px;">
                    <asp:TextBox ID="txtEname" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return OnConfClick()" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%"></td>
                <td style="width: 14%"></td>
                <td style="width: 13%"></td>
                <td style="width: 15%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

