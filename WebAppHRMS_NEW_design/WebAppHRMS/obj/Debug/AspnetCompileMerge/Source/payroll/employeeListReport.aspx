<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employeeListReport.aspx.vb" Inherits="WebAppHRMS.employeeListReport_employeeListReport_b24d42606947" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 797px" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td colspan="4" style="height: 28px; background-color: #ffffcc;">
                    <strong><span style="font-size: 16pt; color: #cc0033">EMPLOYEE LIST SEARCH (BRANCH-WISE&amp;
                        AREA-WISE)</span></strong></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 34px">
                    <strong></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 187px">
                    <strong>AREA</strong></td>
                <td style="width: 103px">
                    <asp:DropDownList ID="cmb_area" runat="server" Width="280px" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td style="width: 110px">
                    <strong>BRANCH</strong></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="280px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 187px">
                    <asp:CheckBox ID="chk_ar" runat="server" AutoPostBack="True" /></td>
                <td style="width: 103px">
                    <asp:Label ID="lbl" runat="server" Font-Bold="True" Text="SELECT ALL BRANCHES IN AREA"
                        Width="290px"></asp:Label></td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_are" runat="server" Width="348px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 187px">
                </td>
                <td style="width: 103px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="133px" Font-Bold="True" /></td>
                <td style="width: 110px">
                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="133px" Font-Bold="True" /></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

