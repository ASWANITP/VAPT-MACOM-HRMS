<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="WEEK OFF.aspx.vb" Inherits="WebAppHRMS.HRM_WEEK_OFF_bb422d926143" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('ddl');

        function btnExit_onclick() {
            window.open("../../home.aspx", "_self");
        }

        function ddlOnchange() {
            document.getElementById(con[0] + "hiddn1").value = document.getElementById(con[0] + "ddlbranch").value;
        }

        function OnconfClick() {
            if (document.getElementById(con[0] + "ddlbranch").value == -1) {
                alert("Please Select the Branch Name");
                document.getElementById(con[0] + "ddlbranch").focus();
                return false;
            }
        }
    </script>

    <div style="text-align: center">
        <asp:HiddenField ID="hiddn1" runat="server" />
        <br />
        <table border="1" style="width: 55%; position: relative; left: 0px; top: 0px;">
            <tr>
                <td colspan="2" style="width: 15%">Branch Name</td>
                <td colspan="3" style="width: 15%">
                    <asp:DropDownList ID="ddlbranch" runat="server" Style="position: relative; left: -6px; top: 0px;"
                        Width="95%" onchange="ddlOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 23px" colspan="5">
                    <asp:Button ID="btncnfrm" runat="server" Style="left: -21px; position: relative" Text="CONFIRM"
                        Width="80px" OnClientClick="return OnconfClick()" />
                    <input id="btnExit" style="width: 80px; position: relative; height: 24px" type="button"
                        value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td colspan="5" style="height: 23px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

