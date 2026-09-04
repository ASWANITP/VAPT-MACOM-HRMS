<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="photo_upload_confirm.aspx.vb" Inherits="WebAppHRMS.vipin_forms_photo_upload_confirm_11f27b001778" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Button2_onclick() {
            window.open("../home.aspx", "_self");
        }

    </script>

    <div style="text-align: center">
        <table border="1">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </caption>
            <tr>
                <td style="width: 171px">
                    <strong>&lt;---Select Employee---&gt;</strong></td>
                <td style="width: 100px"></td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="204px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                    <span style="color: maroon"><strong>&lt;--------------------------------------------------&gt;</strong></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="View Report" Width="105px" /></td>
                <td colspan="2">
                    <input id="Button2" type="button" value="Exit" onclick="return Button2_onclick()" style="width: 80px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

