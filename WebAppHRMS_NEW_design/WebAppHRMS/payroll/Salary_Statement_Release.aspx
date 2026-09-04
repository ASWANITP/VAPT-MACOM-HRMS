<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Salary_Statement_Release.aspx.vb" Inherits="WebAppHRMS.Salary_Statement_Release_749f8a378927" Title="Salary Statement Release" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont = sal.split('Cmb');

        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function fill1() {
        }
        function sub_call_receiver(arg1) {
        }

        function init() {
        }
        window.onload = init;


    </script>

    <span style="font-family: Courier New">&nbsp; </span>
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;
        </div>
    </div>
    <div style="text-align: center">
        <div style="text-align: center">
            <table style="width: 718px; font-family: Courier New; background-color: transparent;" border="1">
                <tr>
                    <td colspan="2" style="height: 24px; text-align: center">
                        <strong><span style="font-size: 14pt; font-family: Times New Roman">SALARY STSTEMENT
                            RELEASE</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 211px; height: 24px; text-align: right">&nbsp;
                    </td>
                    <td style="width: 100px; height: 24px; text-align: left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 211px; text-align: right; height: 24px;">
                        <strong>Salary Statement </strong></td>
                    <td style="width: 100px; text-align: left; height: 24px;">
                        <asp:DropDownList ID="Cmb_action" runat="server" Width="192px">
                            <asp:ListItem Value="-1">----Select----</asp:ListItem>
                            <asp:ListItem Value="0">Block</asp:ListItem>
                            <asp:ListItem Value="1">Release</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 35px;">
                        <span style="font-size: 9pt; color: #0000ff">
                            <br />
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text="Status : "></asp:Label>
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Maroon"
                                Text="Label"></asp:Label></span></td>
                </tr>
            </table>
            <table border="1" style="font-family: Courier New">
                <tr>
                    <td colspan="2" style="height: 23px; text-align: left; width: 98px;">
                        <asp:Button ID="Cmd_Confirm" runat="server" Text="CONFIRM" Width="92px" /></td>
                    <td style="width: 57px; height: 23px; text-align: left"></td>
                    <td style="width: 47px; height: 23px; text-align: left">
                        <input id="Button2" type="button" value="EXIT" onclick="return Cmd_Exit_onclick()" style="width: 86px" /></td>
                </tr>
            </table>
            <br />
        </div>
        <div style="text-align: center">
            <br />
            <span style="font-family: Courier New">&nbsp;</span>
        </div>
    </div>
</asp:Content>

