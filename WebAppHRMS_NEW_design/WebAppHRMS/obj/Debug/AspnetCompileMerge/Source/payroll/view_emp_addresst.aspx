<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="view_emp_addresst.aspx.vb" Inherits="WebAppHRMS.view_emp_address_view_emp_addresst_cab9ce948539" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <table border="1" style="width: 846px; height: 239px">
        <tr>
            <td colspan="4" style="text-align: center">
                <strong><span style="font-size: 14pt; color: #ff0000">VIEW EMPLOYEE ADDRESS</span></strong></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                &nbsp;Employee :
            </td>
            <td colspan="2" style="text-align: left">
                <asp:TextBox ID="txt_emp" runat="server" Width="388px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px">
                <span style="color: #000000"><span><span style="color: #000000">*</span> <span style="text-decoration: underline">
                    Permanent Ad<span>dress</span></span></span> </span>
            </td>
            <td colspan="2" style="color: #000000; height: 23px">
                <span style="color: #000000; text-decoration: underline"><span style="color: #ff0000">
                    *</span> Present Address</span></td>
        </tr>
        <tr>
            <td style="width: 126px; text-align: right">
                House Name :&nbsp;
            </td>
            <td style="width: 174px; text-align: left">
                <asp:TextBox ID="txt_house1" runat="server" ReadOnly="True" Width="271px"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">
                House Name :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_house2" runat="server" ReadOnly="True" Width="271px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; text-align: right">
                State :&nbsp;
            </td>
            <td style="width: 174px; text-align: left">
                <asp:TextBox ID="txt_state1" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">
                State :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_state2" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; text-align: right">
                District :&nbsp;
            </td>
            <td style="width: 174px; text-align: left">
                <asp:TextBox ID="txt_district1" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">
                District :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_district2" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; height: 6px; text-align: right">
                Post :&nbsp;
            </td>
            <td style="width: 174px; height: 6px; text-align: left">
                <asp:TextBox ID="txt_post1" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
            <td style="width: 123px; height: 6px; text-align: right">
                Post :&nbsp;
            </td>
            <td style="width: 100px; height: 6px; text-align: left">
                <asp:TextBox ID="txt_post2" runat="server" ReadOnly="True" Width="270px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 126px; text-align: right">
                Pin Code :&nbsp;
            </td>
            <td style="width: 174px; text-align: left">
                <asp:TextBox ID="txt_pin1" runat="server" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 123px; text-align: right">
                Pin Code :&nbsp;
            </td>
            <td style="width: 100px; text-align: left">
                <asp:TextBox ID="txt_pin2" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 13px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#C00000" Text="To Change Your Address, Please Contact HRM"
                    Width="718px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 13px; text-align: center;">
                <input id="Button1" type="button" value="EXIT" onclick="return Button1_onclick()" style="width: 87px" /></td>
        </tr>
    </table>
</asp:Content>

