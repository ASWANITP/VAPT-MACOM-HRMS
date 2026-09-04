<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Holiday_Register_Form.aspx.vb" Inherits="WebAppHRMS.Holiday_Register_Form_da9e27878725" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <strong><span style="text-decoration: underline">REGISTER OF LEAVE<br />
            <br />
        </span></strong>
        <table style="font-weight: bold; text-decoration: underline">
            <tr>
                <td style="width: 209px; height: 21px">Select Employee code :
                </td>
                <td style="width: 100px; height: 21px">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="120px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 209px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <td style="width: 209px"></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="Confirm" Width="147px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

