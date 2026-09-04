<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="photo report view.aspx.vb" Inherits="WebAppHRMS.vipin_forms_photo_report_view_14d1b1ef3831" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <div style="text-align: center">
        <table border="1">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <span style="color: maroon"><strong>&lt;---View Photo---&gt;</strong></span></caption>
            <tr>
                <td style="width: 167px">
                    <span style="color: maroon"><strong>&lt;---Select Employee---&gt;</strong></span></td>
                <td style="width: 100px"></td>
                <td style="width: 104px">
                    <asp:DropDownList ID="drpdwn_employee" runat="server" AutoPostBack="True" Width="284px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3" rowspan="2" style="height: 22px"></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td style="width: 167px">
                    <asp:Button ID="Button1" runat="server" BackColor="Transparent" BorderStyle="Ridge"
                        Text="View Report" Width="120px" /></td>
                <td style="width: 100px"></td>
                <td style="width: 104px">
                    <asp:Button ID="Button2" runat="server" BackColor="Transparent" BorderColor="White"
                        BorderStyle="Outset" Text="Exit" Width="120px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

