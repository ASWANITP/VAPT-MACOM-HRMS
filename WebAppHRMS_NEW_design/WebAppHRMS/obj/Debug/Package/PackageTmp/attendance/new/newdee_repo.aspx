<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="newdee_repo.aspx.vb" Inherits="WebAppHRMS.attendance_newdee_repo_5ef00a631900" title="Untitled Page" %>

<%@ Register Src="../../control/DateFiller.ascx" TagName="DateFiller" TagPrefix="uc3" %>
<%@ Register Src="~/datefiller.ascx" TagName="datefiller" TagPrefix="uc2" %>
<%@ Register Src="~/datefiller.ascx" TagName="datefiller" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">

 function Got_home()
    {
        window.open('../../home.aspx','_self')
    }
function cmd_exit_onclick() {
Got_home()
}

 </script>
    <div style="text-align: center">
                    &nbsp;</div>
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="3" style="font-weight: bold; height: 1px">
                    PUNCHING SUMMARY(ALL)</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 1px">
                        <table border="0">
                            <tr>
                                <td style="width: 100px; height: 24px;">
                                    <asp:Label ID="Label1" runat="server" Text="Select Category"></asp:Label></td>
                                <td style="width: 100px; height: 24px;">
                                    <asp:DropDownList ID="CMB_CAT" runat="server" Width="160px">
                                        <asp:ListItem Value="1">PRESENT</asp:ListItem>
                                        <asp:ListItem Value="2">ABSENT</asp:ListItem>
                                        <asp:ListItem Value="3">LATE</asp:ListItem>
                                        <asp:ListItem Value="4">EARLY GOING</asp:ListItem>
                                        <asp:ListItem Value="5">NON MARKING</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<uc3:DateFiller ID="DateFiller1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table border="0" style="width: 412px">
                        <tr>
                            <td style="width: 100px; height: 26px;">
                                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
                            <td style="width: 100px; height: 26px;">
                            </td>
                            <td style="width: 100px; height: 26px;">
                            </td>
                            <td style="width: 100px; height: 26px;">
                                <input id="cmd_exit" style="width: 72px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

