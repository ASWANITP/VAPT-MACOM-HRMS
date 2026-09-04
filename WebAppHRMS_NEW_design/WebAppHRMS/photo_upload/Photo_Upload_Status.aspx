<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Photo_Upload_Status.aspx.vb" Inherits="WebAppHRMS.Photo_upload_Photo_Upload_Status_04e0bd099083" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Button2_onclick() {
            window.open("../home.aspx", "_self");
        }

    </script>

    <asp:Panel ID="Panel1" runat="server" Height="140px" Style="z-index: 100; left: 378px; position: absolute; top: 230px"
        Width="370px" BorderColor="Cyan">
        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;
        <table style="z-index: 104; left: 34px; width: 317px; position: absolute; top: 40px; height: 138px"
            border="5">
            <tr>
                <td style="width: 100px">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Not Updated List" GroupName="Radio" Width="173px" Checked="True" /></td>
                <td style="width: 100px">
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Rejected List" GroupName="Radio" Width="122px" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px">
                    <asp:Button ID="Button1" runat="server" Text="Confirm.." Width="107px" Font-Bold="True" ForeColor="Black" /></td>
                <td style="width: 100px; height: 21px">
                    <asp:Button ID="Button2" runat="server" Text="Exit.." Width="98px" Font-Bold="True" ForeColor="Black" /></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

