<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="evening_notpunching.aspx.vb" Inherits="WebAppHRMS.evening_notpunching_5da2d2287056" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../control/uc_date.ascx" TagName="uc_date" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = master_no.split("txt");

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function OnkeyUpChqDate(Control) {
            if (document.getElementById(cont[0] + Control).value != "") {
                alert("Select Date from Calender ..!!!!");
                document.getElementById(cont[0] + Control).value = document.getElementById(cont[0] + "hdn_sysdate").value;
            }
        }
        // ]]>
    </script>


    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" BorderColor="Olive" BorderStyle="Solid" BorderWidth="2px"
            Height="43px" Width="167px">
            <div style="text-align: center">
                <table border="0" style="width: 314px; height: 159px; text-align: left">
                    <tr>
                        <td colspan="2" style="border-bottom: olive thin solid; text-align: center;" valign="middle">
                            <span style="color: #cc0000; text-decoration: underline">REPORT-EVENING NOT PUNCHED</span></td>
                    </tr>
                    <tr>
                        <td style="text-align: left; height: 38px;" colspan="2">&nbsp; &nbsp;&nbsp; Select &nbsp;Date:
                            <asp:TextBox ID="txt_date" runat="server" Width="183px"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 23px; text-align: center">&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp;<asp:Button ID="cmd_report" runat="server" Height="24px" Text="REPORT"
                                Width="71px" BackColor="Transparent" />
                            &nbsp;
                            <input id="cmd_exit" style="width: 69px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        &nbsp;
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_date"></cc1:CalendarExtender>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
        <input id="hdn_sysdate" runat="server" type="hidden" />&nbsp;
    </div>
</asp:Content>

