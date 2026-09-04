<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Photo_verify.aspx.vb" Inherits="WebAppHRMS.Photo_verify_2d59f3e31679" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open("../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 587px">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <strong><span style="font-size: 14pt">Employee Photo Verification&nbsp;</span></strong></caption>
            <tr>
                <td style="width: 169px">
                    <strong>&lt;---Select Employee---&gt;</strong></td>
                <td style="width: 50px">
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="346px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                    <span style="color: maroon"><strong>
                    &lt;--------------------------------------------------&gt;</strong></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="View Report" Width="105px" /></td>
                <td colspan="2">
                    <input id="Button2" type="button" value="Exit" onclick="return Button2_onclick()" style="width: 112px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

