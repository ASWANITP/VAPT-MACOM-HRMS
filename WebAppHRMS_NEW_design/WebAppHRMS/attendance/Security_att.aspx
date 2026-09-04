<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Security_att.aspx.vb" Inherits="WebAppHRMS.specificempattend_atterepo_d50e23416100" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function correct(a, e) {

            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()

        }

        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 731px; height: 217px">
            <tr>
                <td colspan="4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <strong style="background-color: #ffcc33"><span style="font-size: 14pt">SECURITY ATTENDANCE REGULARISATION</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 11px"></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; width: 111px; height: 46px;">
                    <strong>BRANCH</strong></td>
                <td colspan="2" style="height: 46px; text-align: left">
                    <asp:DropDownList ID="ddlbranch" runat="server" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Day Security1</strong></td>
                <td colspan="2" style="width: 247px; text-align: left">

                    <asp:DropDownList ID="ddldaydec" runat="server" Width="70px" AutoPostBack="true">
                        <asp:ListItem Text="select" Value="0" />
                        <asp:ListItem Value="1" />
                        <asp:ListItem Value="2" />
                        <asp:ListItem Value="3" />
                        <asp:ListItem Value="4" />
                        <asp:ListItem Value="5" />
                        <asp:ListItem Value="6" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="8" />
                        <asp:ListItem Value="9" />
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="11" />
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="13" />
                        <asp:ListItem Value="14" />
                        <asp:ListItem Value="15" />
                        <asp:ListItem Value="16" />
                        <asp:ListItem Value="17" />
                        <asp:ListItem Value="18" />
                        <asp:ListItem Value="19" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="21" />
                        <asp:ListItem Value="22" />
                        <asp:ListItem Value="23" />
                        <asp:ListItem Value="24" />
                        <asp:ListItem Value="25" />
                        <asp:ListItem Value="26" />
                        <asp:ListItem Value="27" />
                        <asp:ListItem Value="28" />
                        <asp:ListItem Value="29" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="31" />

                    </asp:DropDownList></td>

            </tr>
            <tr>
                <td colspan="2" style="text-align: left; width: 111px; height: 17px;">
                    <strong>Day Security2<br />
                    </strong></td>
                <td style="height: 17px; text-align: left">

                    <asp:DropDownList ID="DropDownList1" runat="server" Width="70px" AutoPostBack="true">
                        <asp:ListItem Text="select" Value="0" />
                        <asp:ListItem Value="1" />
                        <asp:ListItem Value="2" />
                        <asp:ListItem Value="3" />
                        <asp:ListItem Value="4" />
                        <asp:ListItem Value="5" />
                        <asp:ListItem Value="6" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="8" />
                        <asp:ListItem Value="9" />
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="11" />
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="13" />
                        <asp:ListItem Value="14" />
                        <asp:ListItem Value="15" />
                        <asp:ListItem Value="16" />
                        <asp:ListItem Value="17" />
                        <asp:ListItem Value="18" />
                        <asp:ListItem Value="19" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="21" />
                        <asp:ListItem Value="22" />
                        <asp:ListItem Value="23" />
                        <asp:ListItem Value="24" />
                        <asp:ListItem Value="25" />
                        <asp:ListItem Value="26" />
                        <asp:ListItem Value="27" />
                        <asp:ListItem Value="28" />
                        <asp:ListItem Value="29" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="31" />

                    </asp:DropDownList><br />
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: left; width: 111px; height: 26px;">
                    <strong>Night Security</strong></td>
                <td colspan="2" style="text-align: left; height: 26px;">
                    <asp:DropDownList ID="ddlnightsec" runat="server" Width="70px">
                        <asp:ListItem Text="select" Value="0" />
                        <asp:ListItem Value="1" />
                        <asp:ListItem Value="2" />
                        <asp:ListItem Value="3" />
                        <asp:ListItem Value="4" />
                        <asp:ListItem Value="5" />
                        <asp:ListItem Value="6" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="8" />
                        <asp:ListItem Value="9" />
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="11" />
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="13" />
                        <asp:ListItem Value="14" />
                        <asp:ListItem Value="15" />
                        <asp:ListItem Value="16" />
                        <asp:ListItem Value="17" />
                        <asp:ListItem Value="18" />
                        <asp:ListItem Value="19" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="21" />
                        <asp:ListItem Value="22" />
                        <asp:ListItem Value="23" />
                        <asp:ListItem Value="24" />
                        <asp:ListItem Value="25" />
                        <asp:ListItem Value="26" />
                        <asp:ListItem Value="27" />
                        <asp:ListItem Value="28" />
                        <asp:ListItem Value="29" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="31" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Day Gun Man</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddldaygunman" runat="server" Width="70px">
                        <asp:ListItem Text="select" Value="0" />
                        <asp:ListItem Value="1" />
                        <asp:ListItem Value="2" />
                        <asp:ListItem Value="3" />
                        <asp:ListItem Value="4" />
                        <asp:ListItem Value="5" />
                        <asp:ListItem Value="6" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="8" />
                        <asp:ListItem Value="9" />
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="11" />
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="13" />
                        <asp:ListItem Value="14" />
                        <asp:ListItem Value="15" />
                        <asp:ListItem Value="16" />
                        <asp:ListItem Value="17" />
                        <asp:ListItem Value="18" />
                        <asp:ListItem Value="19" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="21" />
                        <asp:ListItem Value="22" />
                        <asp:ListItem Value="23" />
                        <asp:ListItem Value="24" />
                        <asp:ListItem Value="25" />
                        <asp:ListItem Value="26" />
                        <asp:ListItem Value="27" />
                        <asp:ListItem Value="28" />
                        <asp:ListItem Value="29" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="31" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Night Gun Man</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlnightgunman" runat="server" Width="70px">
                        <asp:ListItem Text="select" Value="0" />
                        <asp:ListItem Value="1" />
                        <asp:ListItem Value="2" />
                        <asp:ListItem Value="3" />
                        <asp:ListItem Value="4" />
                        <asp:ListItem Value="5" />
                        <asp:ListItem Value="6" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="8" />
                        <asp:ListItem Value="9" />
                        <asp:ListItem Value="10" />
                        <asp:ListItem Value="11" />
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="13" />
                        <asp:ListItem Value="14" />
                        <asp:ListItem Value="15" />
                        <asp:ListItem Value="16" />
                        <asp:ListItem Value="17" />
                        <asp:ListItem Value="18" />
                        <asp:ListItem Value="19" />
                        <asp:ListItem Value="20" />
                        <asp:ListItem Value="21" />
                        <asp:ListItem Value="22" />
                        <asp:ListItem Value="23" />
                        <asp:ListItem Value="24" />
                        <asp:ListItem Value="25" />
                        <asp:ListItem Value="26" />
                        <asp:ListItem Value="27" />
                        <asp:ListItem Value="28" />
                        <asp:ListItem Value="29" />
                        <asp:ListItem Value="30" />
                        <asp:ListItem Value="31" />
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: left; width: 111px;">
                    <strong>Start Date</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="Txt_Start" runat="server" Width="150px" onkeyup="return correct('Txt_Start',event)"></asp:TextBox></td>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Txt_Start" Format="dd/MMM/yyyy"></cc1:CalendarExtender>


            </tr>

            <tr>
                <td colspan="2" style="text-align: left; height: 44px">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="121px" /></td>
                <td colspan="2" style="text-align: left; height: 44px">
                    <asp:Button ID="Button2" runat="server" Text="EXIT" Width="133px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

