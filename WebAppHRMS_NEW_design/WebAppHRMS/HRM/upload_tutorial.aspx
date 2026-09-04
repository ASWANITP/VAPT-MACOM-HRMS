<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="upload_tutorial.aspx.vb" Inherits="WebAppHRMS.oct2010_upload_tutorial_a40b26834227" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <div style="text-align: center">
        <table style="width: 488px">
            <tr>
                <td colspan="4">
                    <strong>UPLOAD TUTORIAL<br />
                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <strong>Select the file :</strong></td>
                <td colspan="3">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="366px" /></td>
            </tr>
            <tr>
                <td style="width: 152px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px">
                    <asp:Button ID="upload" runat="server" Text="UPLOAD" Width="79px" /></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
        </table>
    </div>
</asp:Content>

