<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="pl3_submit_new.aspx.vb" Inherits="WebAppHRMS.pl3_pl3_submit_new_58b07fd55633" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = master_no.split("txt")

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }
        function textupper(name) {
            document.getElementById(cont[0] + name).value = document.getElementById(cont[0] + name).value.toUpperCase();
            return true;
        }
        // ]]>
    </script>

    <div style="text-align: center">
        <br />
        <table border="1" style="width: 66%; height: 112px;">
            <tr>
                <td style="width: 10%">Employee&nbsp;Name</td>
                <td style="width: 10%">
                    <asp:DropDownList ID="cmb_Employee" runat="server" Width="280px" Font-Names="Times New Roman" Font-Size="Medium">
                    </asp:DropDownList></td>
                <td style="width: 10%">Leave&nbsp;Particulars</td>
                <td style="width: 10%">
                    <asp:DropDownList ID="cmb_particulars" runat="server" Height="35px" Width="213px" Font-Names="Times New Roman" Font-Size="Medium">
                        <asp:ListItem Value="1">INFORMED</asp:ListItem>
                        <asp:ListItem Value="0">NOT INFORMED</asp:ListItem>
                        <asp:ListItem Value="2">APPROVED</asp:ListItem>
                        <asp:ListItem Value="3">SHIFT</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 10%; height: 23px;">Reason</td>
                <td style="height: 23px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_Reason" runat="server" onkeyup="return textupper('txt_Reason')" Width="384px" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
                <td style="width: 10%; height: 23px;"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_Confirm" runat="server" Text="Confirm" />
                    <input id="btn_Exit" type="button" value="Exit" onclick="return Button1_onclick()" style="width: 64px" /></td>
            </tr>
            <tr>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
            </tr>
        </table>
    </div>
</asp:Content>

