<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="visit employee photo.aspx.vb" Inherits="WebAppHRMS.vipin_forms_visit_employee_photo_b4c8c1b89480" Title="Untitled Page" %>

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
                <td style="width: 205px">
                    <strong><span style="color: maroon">&lt;----Enter Employee Code----&gt;</span></strong></td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox1" runat="server" Width="249px" BackColor="White" BorderColor="#E0E0E0" BorderStyle="Ridge"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="2">
                    <strong><span style="color: maroon">&lt;------------view photo ------------&gt;</span></strong></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td style="width: 205px">
                    <asp:Button ID="Button1" runat="server" Text="Confirm" Width="98px" /></td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <input id="Button2" type="button" value="Exit" style="width: 96px" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

