<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="sal_individ_HO_select.aspx.vb" Inherits="WebAppHRMS.Salary_Individ_Ho_statement_sal_individ_HO_select_dcb5317a7224" Title="Salary Statement HO Select" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        var cs = cont_name.split("Txt");
        function change(a) {
            debugger;
            var str = document.getElementById(cs[0] + a).value;
            var len = str.length;
            var dat = new Date();
            var dt = dat.getFullYear();
            var dtlen = dt.toString().length;
            var yr = parseInt(str)

            if (isNaN(str)) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }
            if (len > dtlen) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }

            if (yr > dt) {
                document.getElementById(cs[0] + a).value = "";
                document.getElementById(cs[0] + a).focus;
                return false;
            }



        }



        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <table border="1" style="width: 624px; height: 80px">
            <tr>
                <td colspan="5" style="text-align: center">
                    <strong>Salary Statement of Administartive Office ( A.O Valapad )</strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="Radio_Permanant" runat="server" Font-Bold="True" Text="Permanant" GroupName="sal" /></td>
                <td colspan="1">
                    <asp:RadioButton ID="Radio_all" runat="server" Font-Bold="True" TabIndex="1"
                        Text="All" GroupName="sal" Width="136px" /></td>
                <td colspan="2">
                    <asp:RadioButton ID="Radio_Outsource" runat="server" Font-Bold="True" TabIndex="1"
                        Text="Outsource" GroupName="sal" /></td>
            </tr>
            <tr>
                <td style="width: 100px">Select Month</td>
                <td style="width: 67px">
                    <asp:DropDownList ID="Cmb_month" runat="server" Width="120px">
                        <asp:ListItem Value="01">January</asp:ListItem>
                        <asp:ListItem Value="02">February</asp:ListItem>
                        <asp:ListItem Value="03">March</asp:ListItem>
                        <asp:ListItem Value="04">April</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">June</asp:ListItem>
                        <asp:ListItem Value="07">July</asp:ListItem>
                        <asp:ListItem Value="08">August</asp:ListItem>
                        <asp:ListItem Value="09">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList></td>
                <td rowspan="2" style="width: 100px"></td>
                <td style="width: 100px">Enter Year</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_yr" runat="server" MaxLength="4" onkeyup="return change('Txt_yr')"
                        Width="109px"></asp:TextBox></td>
            </tr>
            <tr id="aa" style="display: none">
                <td style="width: 100px"></td>
                <td style="width: 67px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table border="1" style="width: 112px; height: 31px">
            <tr>
                <td style="width: 100px; text-align: right">
                    <input id="Cmd_Exit" style="width: 88px" tabindex="2" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:Button ID="Cmd_Confirm" runat="server" TabIndex="3" Text="CONFIRM" /></td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>

