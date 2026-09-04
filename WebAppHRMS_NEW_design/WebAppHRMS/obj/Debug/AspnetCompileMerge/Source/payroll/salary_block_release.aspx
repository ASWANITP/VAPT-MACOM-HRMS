<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="salary_block_release.aspx.vb" Inherits="WebAppHRMS.Salary_Calculation_salary_block_release_bb7ba7c84202" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../home.aspx','_Self');
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 456px">
            <tr>
                <td style="width: 138px">
                    Select Employee Code :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_block" runat="server" Width="246px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 138px; text-align: right">
                    &nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="79px" /></td>
                <td style="width: 100px; text-align: left">
                    <input id="Button2" style="width: 80px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 138px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

