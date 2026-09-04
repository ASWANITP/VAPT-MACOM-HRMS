<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Transfer_Promotion Order.aspx.vb" Inherits="WebAppHRMS.Transfer_Promotion_Order_d1e939898147" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <strong><span style="font-family: @MS Mincho; text-decoration: underline">
            <br />
            <span style="font-size: 14pt">..Transfer/Promotion &amp; Appointment Order Sending..</span></span></strong><br />
        <br />
        <table border="3">
            <tr>
                <td style="width: 224px; height: 22px">
                    <asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" GroupName="Radio"
                        Text="Transfer/Promotion Order" /></td>
            </tr>
            <tr>
                <td style="width: 224px; height: 21px"></td>
            </tr>
            <tr>
                <td style="width: 224px">
                    <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" GroupName="Radio"
                        Text="Appointment Order" /></td>
            </tr>
            <tr>
                <td style="width: 224px"></td>
            </tr>
            <tr>
                <td style="width: 224px">
                    <asp:Button ID="Button1" runat="server" Text=">> Send" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

