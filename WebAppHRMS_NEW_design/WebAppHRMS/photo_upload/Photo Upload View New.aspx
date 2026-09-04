<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Photo Upload View New.aspx.vb" Inherits="WebAppHRMS.Photo_upload_Photo_Upload_View_New_b8b6f42e4250" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        function TABLE1_onclick() {

        }

    </script>

    <table width="406px" height="34px" border="1" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 122px; height: 21px">
                <strong><span style="font-size: 14pt; color: #0066ff">Photo Upload </span></strong>
            </td>
            <td style="width: 100px; height: 21px">
                <strong><span style="font-size: 14pt; color: #0066ff">View...</span></strong></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 21px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td

            <td style="width: 100px; height: 21px">
                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="DropDownList1">
                </cc1:ListSearchExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 122px; height: 26px;">
                <strong>&nbsp;<span style="color: #0066ff">Select Status</span></strong></td>
            <td style="width: 100px; height: 26px;">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="167px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Value="1">Verified...</asp:ListItem>
                    <asp:ListItem Value="0">Applied..</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 122px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 26px;">
                <asp:Button ID="Button1" runat="server" Text="View Report" Width="112px" /></td>
            <td style="width: 100px; height: 26px;">
                <asp:Button ID="Button2" runat="server" Text="Exit" Width="95px" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

