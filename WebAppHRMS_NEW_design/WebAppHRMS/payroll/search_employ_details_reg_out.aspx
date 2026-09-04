<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="search_employ_details_reg_out.aspx.vb" Inherits="WebAppHRMS.december_search_report_search_employ_details_reg_out_29ccd4071719" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>

    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("Txt");
        function change(a) {
            var str = document.getElementById(cs[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
        }


        function sol_dat() {
            if (document.getElementById(cs[0] + "Chk_exp").checked == true) {
                document.getElementById(cs[0] + "Txt_exp").style.display = "inline"
                document.getElementById("tb1").style.display = "inline"
                document.getElementById("tb2").style.display = "inline"
            }
            else {
                document.getElementById(cs[0] + "Txt_exp").style.display = "none"
                document.getElementById("tb1").style.display = "none"
                document.getElementById("tb2").style.display = "none"
            }
        }


        function Button2_onclick() {
            window.open('../home.aspx', '_self');
        }

        function window_onload() {
            if (document.getElementById(cs[0] + "Chk_exp").checked == true) {
                document.getElementById(cs[0] + "Txt_exp").style.display = "inline"
                document.getElementById("tb1").style.display = "inline"
                document.getElementById("tb2").style.display = "inline"
            }
            else {
                document.getElementById(cs[0] + "Txt_exp").style.display = "none"
                document.getElementById("tb1").style.display = "none"
                document.getElementById("tb2").style.display = "none"
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="height: 21px">
                    <strong>EMPLOYEE DETAILS -EXPERIENCE WISE SEARCH</strong></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 24px">SELECT CATEGORY:</td>
                <td colspan="2" style="height: 24px">
                    <asp:DropDownList ID="Cmb_Cate" runat="server" Width="204px">
                        <asp:ListItem Value="3">ALL</asp:ListItem>
                        <asp:ListItem Value="1">REGULAR</asp:ListItem>
                        <asp:ListItem Value="2">OUTSOURCE</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 204px; height: 42px;">
                    <asp:CheckBox ID="Chk_exp" onclick="sol_dat()" runat="server" Text="SELECT EXPERIENCE" Width="190px" />(<span style="color: #ff0066">in month wise)</span></td>
                <td colspan="2" style="height: 42px" id="tb1">
                    <asp:TextBox ID="Txt_exp" onkeyup="return change('Txt_exp')" runat="server"></asp:TextBox></td>
                <td style="width: 207px; height: 42px;" id="tb2"></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 204px; height: 23px"></td>
                <td style="width: 100px; height: 23px">
                    <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; height: 23px">
                    <input id="Cmd_Exit" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 98px" /></td>
                <td style="width: 207px; height: 23px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

