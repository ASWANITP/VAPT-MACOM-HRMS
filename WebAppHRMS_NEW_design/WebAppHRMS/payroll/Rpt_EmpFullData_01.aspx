<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Rpt_EmpFullData_01.aspx.vb" Inherits="WebAppHRMS.PayRoll_Rpt_EmpFullData_01_560e82904062" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = header.split("cmb");
        function btn_exit_onclick() { window.open('../home.aspx', '_self'); }
        function btn_confirm_onclick() {
            var PostID = document.getElementById(cont_name[0] + "cmbPost").value;
            var Experience = document.getElementById(cont_name[0] + "txtExp").value;
            var StateID = document.getElementById(cont_name[0] + "cmbState").value;
            var Gender = document.getElementById(cont_name[0] + "cmbGender").value;
            if (Experience == "") { alert("Enter Experience in Months ..!!!!"); document.getElementById(cont_name[0] + "txtExp").focus(); return false; }
            window.open('Rpt_EmpFullData_02.aspx?PostID=' + PostID + '&Experience=' + Experience + '&StateID=' + StateID + '&Gender=' + Gender + '', '_self');
        }
    </script>
    <div style="text-align: center">
        <table border="1" style="width: 50%; font-family: Courier New">
            <tr>
                <td style="width: 20%">Post</td>
                <td style="width: 20%; text-align: left;">
                    <asp:DropDownList ID="cmbPost" runat="server" Font-Names="Courier New" Width="80%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 20%">Experience<span style="font-size: 10pt; color: #ff0000;"><strong>(Months)</strong></span></td>
                <td style="width: 20%; text-align: left;">
                    <input id="txtExp" style="width: 184px; font-family: 'Courier New'" type="text" runat="server" maxlength="3" /></td>
            </tr>
            <tr>
                <td style="width: 20%">Branch State</td>
                <td style="width: 20%; text-align: left;">
                    <asp:DropDownList ID="cmbState" runat="server" Font-Names="Courier New" Width="80%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 20%">Gender</td>
                <td style="width: 20%; text-align: left">
                    <asp:DropDownList ID="cmbGender" runat="server" Font-Names="Courier New" Width="80%">
                        <asp:ListItem Value="-1">-All-</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="0">Female</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="btn_confirm" onclick="return btn_confirm_onclick()" style="width: 72px; cursor: hand; font-family: 'Book Antiqua'; height: 25px"
                        type="button" value="VIEW" />&nbsp;
                    <input id="btn_exit" onclick="return btn_exit_onclick()" style="width: 70px; cursor: hand; font-family: 'Book Antiqua'; height: 25px"
                        type="button" value="EXIT" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

