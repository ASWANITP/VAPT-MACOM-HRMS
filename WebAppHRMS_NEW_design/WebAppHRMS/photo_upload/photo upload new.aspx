<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="photo upload new.aspx.vb" Inherits="WebAppHRMS.vipin_forms_photo_upload_new_ff8d610d8011" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Button2_onclick() {
            window.open("../home.aspx", "_self");
        }

    </script>

    <div style="text-align: center">

        <div style="text-align: center">
            <table border="1">
                <caption>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy" TargetControlID="txt_select"></cc1:CalendarExtender>
                    &nbsp;
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="DropDownList1">
                    </cc1:ListSearchExtender>
                </caption>
                <tr>
                    <td colspan="2" style="height: 26px">
                        <span style="color: maroon"><strong>---Select Employee---</strong></span></td>
                    <td style="width: 100px; height: 26px;"></td>
                    <td colspan="2" style="width: 237px; height: 26px;">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="358px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <span style="color: maroon">&lt;------------------------------------------------------------------&gt;</span></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span style="color: maroon"><strong>&lt;---Upload Photo--&gt;-</strong></span></td>
                    <td colspan="3">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="332px" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <strong><span style="color: maroon">Enter SSLC Number</span></strong></td>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox1" runat="server" Width="433px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <strong><span style="color: maroon">Select Date Of Birth</span></strong></td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_select" runat="server" Width="435px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Update" Width="113px" /></td>
                    <td style="width: 100px">
                        <span style="color: purple"></span></td>
                    <td colspan="2" style="width: 237px">
                        <input id="Button2" style="width: 90px" type="button" value="Exit" onclick="return Button2_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

