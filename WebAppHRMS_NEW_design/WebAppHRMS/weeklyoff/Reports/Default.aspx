<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebAppHRMS.HRM_Default_e84cd19b5889" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('txt');

        function detailDisplay() {
            if (isNaN(document.getElementById(con[0] + "txtecode").value)) {
                document.getElementById(con[0] + "txtecode").value = "";
                return false;
            }
        }
        function btnExit_onclick() {
            window.open("../../home.aspx", "_self");
        }

    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 60%; position: relative">
                <tr>
                    <td style="width: 129px">&nbsp;Employee Code</td>
                    <td style="width: 100px; text-align: left;">
                        <asp:TextBox ID="txtecode" runat="server" MaxLength="6" Style="left: 40px; position: relative; top: 0px;"
                            Width="224px" onblur="detailDisplay()" onkeypress="detailDisplay()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnConfrm" runat="server" Style="left: -21px; position: relative"
                            Text="CONFIRM" Width="80px" />
                        <input id="btnExit" style="width: 80px; position: relative" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

