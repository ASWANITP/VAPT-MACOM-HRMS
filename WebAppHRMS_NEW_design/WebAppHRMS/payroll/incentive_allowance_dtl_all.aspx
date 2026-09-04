<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="incentive_allowance_dtl_all.aspx.vb" Inherits="WebAppHRMS.incentive_allowance_incentive_allowance_dtl_all_eab8d84a5823" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Button1_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1" style="width: 523px; height: 65px">
            <tr>
                <td style="width: 177px; text-align: left">
                    <asp:RadioButton ID="rdb_name" runat="server" GroupName="g" Text="Allowance Name :" />&nbsp;</td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_allname" runat="server" Width="334px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 177px; text-align: left">
                    <asp:RadioButton ID="rdb_all" runat="server" Checked="True" GroupName="g" Text="All" /></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 177px; text-align: right">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; text-align: left">
                    <input id="Button1" style="width: 86px" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
</asp:Content>

