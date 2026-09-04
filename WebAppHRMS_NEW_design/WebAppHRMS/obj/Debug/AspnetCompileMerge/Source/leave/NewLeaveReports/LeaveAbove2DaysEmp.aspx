<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LeaveAbove2DaysEmp.aspx.vb" Inherits="WebAppHRMS.LeaveAbove2DaysEmp_8c39c2921599" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
function correct(a,e) 
{

        document.getElementById("ctl00_cph_edp_"+a).value=""
        document.getElementById("ctl00_cph_edp_"+a).focus()
              
}

// ]]>
</script>

    <div style="text-align: center">
        <br />
        &nbsp;<span style="font-size: 14pt"><strong><span>MORE THAN 2 DAYS LEAVE REPORT<br />
        </span></strong>
            <asp:Label ID="lblDate" runat="server" ForeColor="Navy"></asp:Label><br />
        </span>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Size="10pt" ForeColor="#333333" GridLines="None" BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px">
            <RowStyle BackColor="White" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="emp_code" HeaderText="Emp Code">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="emp_name" HeaderText="Employee Name">
                    <ControlStyle Width="175px" />
                    <ItemStyle HorizontalAlign="Left" Width="175px" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="leave_count" HeaderText="No. Of Leaves">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="branch_name" HeaderText="Branch Name">
                    <ControlStyle Font-Size="9pt" Width="250px" />
                    <ItemStyle Font-Size="9pt" HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="post_name" HeaderText="Post">
                    <ControlStyle Font-Size="9pt" Width="200px" />
                    <ItemStyle Font-Size="9pt" HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Dep_name" HeaderText="Department">
                    <ControlStyle Font-Size="9pt" Width="200px" />
                    <ItemStyle Font-Size="9pt" HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <span>
            <br />
            </span><strong><span style="font-size: 11pt">LEAVE DETAILS<br />
        </span></strong>
        <br /><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Size="11pt" ForeColor="#333333" GridLines="None" BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px">
            <RowStyle BackColor="#FFEEEA" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="slno" HeaderText="Sl No">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="leave_frdate" HeaderText="Date From">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="leave_todate" HeaderText="Date To">
                    <ControlStyle Width="175px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="days" HeaderText="Days">
                    <ControlStyle Width="50px" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="leavetype" HeaderText="Leave Type">
                    <ControlStyle Font-Size="9pt" Width="200px" />
                    <ItemStyle Font-Size="12pt" HorizontalAlign="Center" Width="250px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <br />
    <asp:Button ID="btnBack" runat="server" Text="Back" Width="133px" OnClientClick="JavaScript:window.history.back(1); return false;" /><br />
        <br />
        <br />
    </div>
   
</asp:Content>

