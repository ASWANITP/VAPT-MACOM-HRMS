<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="br_select_promo.aspx.vb" Inherits="WebAppHRMS.nov2009_mmm_br_select_promo_b84839234561" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        var cs = cont_name.split("Txt");
        function change(a) {
            //debugger;
            var str = document.getElementById(cs[0] + a).value;
            if (str == ' ') {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

        }
    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="2">
                    <strong>Promotion Report</strong></td>
            </tr>
            <tr>
                <td style="width: 150px; height: 23px">
                    <strong>Enter employee code.</strong></td>
                <td style="width: 308px; height: 23px; text-align: left">
                    <asp:TextBox ID="Txt_emp" onkeyup="return change('Txt_emp')" runat="server" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px"></td>
                <td style="width: 308px; text-align: left">
                    <asp:Button ID="Button1" runat="server" Text="Submit" />
                    <asp:Button ID="btn_exit" runat="server" Text="EXIT" Width="56px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

