<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Transfer_Promotion_Receival.aspx.vb" Inherits="WebAppHRMS.Transfer_Promotion_Receival_6350809b4851" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <div style="text-align: center">
        <br />
        <strong><span style="font-size: 14pt; font-family: @MS Mincho; text-decoration: underline">
            Transfer/Promotion and Appointment Order Receival</span></strong><br />
        <br />
        <table>
            <tr>
                <td style="width: 155px">
                    Select Employee</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 155px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 155px">
                    <asp:Button ID="Button1" runat="server" Text="Confirm" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" Text="Reject" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

