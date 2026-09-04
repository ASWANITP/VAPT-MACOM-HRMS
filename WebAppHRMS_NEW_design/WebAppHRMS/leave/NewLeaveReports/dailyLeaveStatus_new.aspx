<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="dailyLeaveStatus_new.aspx.vb" Inherits="WebAppHRMS.dailyLeaveStatus_new_3e95c9886762" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function correct(a, e) {

            document.getElementById("ctl00_cph_edp_" + a).value = ""
            document.getElementById("ctl00_cph_edp_" + a).focus()

        }

        // ]]>


        HideWait();

    </script>

    <div style="text-align: center">
        <br />
        &nbsp;<span style="font-size: 14pt">DAILY LEAVE STATUS REPORT<br />
            <asp:Label ID="lblmsghead" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Navy"
                Visible="False">(Processed at 10 AM)</asp:Label><br />
        </span>
        <asp:Label ID="lblDate" runat="server" ForeColor="Navy"></asp:Label><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Size="9px" ForeColor="#333333" BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px">
            <RowStyle BackColor="WhiteSmoke" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="emp_code" HeaderText="Emp Code">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" Font-Size="9pt" />
                </asp:BoundField>
                <asp:BoundField DataField="emp_name" HeaderText="Employee Name">
                    <ControlStyle Width="175px" />
                    <ItemStyle HorizontalAlign="Left" Width="175px" Font-Size="9pt" />
                </asp:BoundField>

                <asp:BoundField DataField="branch_name" HeaderText="Branch Name">
                    <ControlStyle Font-Size="9pt" Width="250px" />
                    <ItemStyle Font-Size="8pt" HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="post_name" HeaderText="Post">
                    <ControlStyle Font-Size="9pt" Width="200px" />
                    <ItemStyle Font-Size="8pt" HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="status" HeaderText="Status">
                    <ControlStyle Width="120px" />
                    <ItemStyle HorizontalAlign="Center" Font-Size="8pt" BackColor="WhiteSmoke" />
                </asp:BoundField>
                <asp:BoundField DataField="Reason" HeaderText="Reason">
                    <ControlStyle Width="250px" />
                    <ItemStyle HorizontalAlign="Left" Width="250px" Font-Size="8pt" />
                </asp:BoundField>
                <asp:BoundField DataField="leave_status" HeaderText="Applied/Informed_Status">
                    <ItemStyle Font-Size="8pt" />
                </asp:BoundField>
                <asp:BoundField DataField="sanctioned_by" HeaderText="Sanctioned_by">
                    <ItemStyle Font-Size="8pt" />
                </asp:BoundField>
                <asp:BoundField DataField="monthly" HeaderText="Monthly ">
                    <ItemStyle Font-Size="10pt" />
                </asp:BoundField>
                <asp:BoundField DataField="yearly" HeaderText="Yearly">
                    <ItemStyle Font-Size="10pt" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="11pt" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Red"
            Text="Label"></asp:Label>
        <br />
        <table style="width: 1148px">
            <tr>
                <td align="left" colspan="3" style="height: 21px">
                    <asp:Label ID="lblTotal" runat="server" Font-Size="13pt" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" Width="133px" OnClientClick="JavaScript:window.history.back(1); return false;" /><br />
        &nbsp;<br />
    </div>

</asp:Content>

