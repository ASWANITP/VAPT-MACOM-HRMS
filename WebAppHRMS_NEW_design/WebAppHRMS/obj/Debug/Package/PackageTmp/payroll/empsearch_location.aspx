<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="empsearch_location.aspx.vb" Inherits="WebAppHRMS.employeesearch_location_empsearch_location_ca663f5c1093" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>


    <br />
    <div style="text-align: center">
        <table border="1" style="width: 383px; height: 177px">
            <tr>
                <td colspan="2" style="height: 8px; text-align: center">
                    <strong><span style="color: #cc0000">&nbsp;SEARCH BY LOCATION</span></strong></td>
            </tr>
            <tr>
                <td style="width: 172px; height: 8px; text-align: left">&nbsp;<asp:RadioButton ID="rdb_state" runat="server" GroupName="g" Text="State " Checked="True" /></td>
                <td style="width: 100px; height: 8px; text-align: left">
                    <asp:DropDownList ID="cmb_state" runat="server" Width="240px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 172px; text-align: left">&nbsp;<asp:RadioButton ID="rdb_district" runat="server" GroupName="g" Text="District" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_district" runat="server" Width="240px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 172px; text-align: left">&nbsp;<asp:CheckBox ID="chk_post" runat="server" Text="Post Office" /></td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_post" runat="server" Width="238px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 172px; text-align: left">&nbsp;Gender :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_gender" runat="server" Width="238px">
                        <asp:ListItem Value="2">All</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="0">Female</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 29px">&nbsp;<input id="cmd_exit" type="button" value="EXIT" onclick="return cmd_exit_onclick()" style="width: 64px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmd_report" runat="server" Text="REPORT" /></td>
            </tr>
        </table>
    </div>

</asp:Content>

