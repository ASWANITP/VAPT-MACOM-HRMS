<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Firmwise_salary_new.aspx.vb" Inherits="WebAppHRMS.Leave_Firmwise_salary_new_1aba1a552965" Title="Untitled Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        function Button2_onclick() {

        }
    </script>

    <div style="text-align: center">
        &nbsp;<table border="1">
            <caption>
                SALARY REPORT - HRM</caption>
            <tr>
                <td style="width: 100px"></td>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td id="row1" style="width: 100px">CATEGORY</td>
                <td colspan="3">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="95%">
                        <asp:ListItem Value="0">---------- SELECT --------</asp:ListItem>
                        <asp:ListItem Value="1">SALARY</asp:ListItem>
                        <asp:ListItem Value="2">ALLOWANCE</asp:ListItem>
                        <asp:ListItem Value="3">Employee RD</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="REPORT" OnClick="Button1_Click" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button3" runat="server" Text="EXIT" Width="88px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

