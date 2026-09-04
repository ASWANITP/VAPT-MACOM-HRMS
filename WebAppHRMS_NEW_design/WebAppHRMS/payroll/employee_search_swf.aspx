<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employee_search_swf.aspx.vb" Inherits="WebAppHRMS.employee_search_for_staff_welfare_employee_search_swf_3a91ce263046" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;&nbsp;<br />
        &nbsp;
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table border="1" style="width: 244px; height: 62px">
                        <tr>
                            <td style="width: 117px; text-align: left">&nbsp;
                        <asp:RadioButton ID="rdb_month" runat="server" Checked="True" GroupName="g" Text="Month" AutoPostBack="True" OnCheckedChanged="rdb_month_CheckedChanged" /></td>
                            <td style="width: 89px; text-align: left">
                                <asp:DropDownList ID="cmb_month" runat="server" Width="128px">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">Auguest</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">Novamber</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 117px; height: 17px; text-align: left">&nbsp;
                        <asp:RadioButton ID="rdb_date" runat="server" GroupName="g" Text="Date" AutoPostBack="True" OnCheckedChanged="rdb_date_CheckedChanged" /></td>
                            <td style="width: 89px; height: 17px; text-align: left">
                                <asp:TextBox ID="txt_date" runat="server" Width="121px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM" TargetControlID="txt_date"></cc1:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        <table border="1">
            <tr>
                <td style="width: 100px">
                    <input id="cmd_exit" style="width: 95px; height: 26px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
            </tr>
        </table>
        &nbsp;&nbsp;<br />
        <br />
    </div>

</asp:Content>

