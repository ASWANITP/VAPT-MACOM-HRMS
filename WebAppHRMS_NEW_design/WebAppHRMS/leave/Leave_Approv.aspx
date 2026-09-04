<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_Approv.aspx.vb" Inherits="WebAppHRMS.report_AgencyWiseTrxn_0357ac432644" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont_name = header.split("Txt");
        function Cmd_Exit_onclick() {
            window.open('../../home.aspx', '_self');
        }



        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <table border="1" style="width: 380px">
            <tr>
                <td colspan="2" style="text-align: left">
                    <span style="color: #0033cc"><strong>Paste Here</strong></span></td>
                <td colspan="2" style="text-align: left">
                    <strong style="font-family: 'Courier New'">
                        <asp:TextBox ID="Txt_Problem_id" runat="server" Style="font-family: 'Courier New'" TextMode="MultiLine" Width="129px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:Button ID="Butn_Rectify" runat="server" Text="Approve" Font-Bold="True" Font-Names="Courier New" Width="75px" /></td>
                <td colspan="2" style="text-align: left">
                    <input id="Cmd_Exit" type="button" value="Exit" style="width: 76px; cursor: hand; font-family: 'Courier New'; font-weight: bold;" onclick="return Cmd_Exit_onclick()" /></td>

            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblMessage" ForeColor="red" Font-Bold="true" Font-Size="Larger" runat="server"></asp:Label>
    </div>
    &nbsp;
    <br />
</asp:Content>
