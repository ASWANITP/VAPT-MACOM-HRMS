<%@ Page Language="VB" MasterPageFile="~/mailReport.master" AutoEventWireup="false" CodeBehind="mailReport_Dailystatus.aspx.vb" Inherits="WebAppHRMS.mailReport_Dailystatus_55cdfc835892" title="Untitled Page" %>

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
        &nbsp;<span style="font-size: 14pt">DAILY LEAVE STATUS <br />
        </span>
        <asp:Label ID="lblSubHead" runat="server" ForeColor="Navy"></asp:Label><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Font-Size="9pt" ForeColor="#333333" EnableTheming="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" />
            <Columns>
                <asp:BoundField DataField="emp_code" HeaderText="Emp Code">
                    <ControlStyle Width="100px" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="emp_name" HeaderText="Employee Name">
                    <ControlStyle Width="175px" />
                    <ItemStyle HorizontalAlign="Left" Width="175px" />
                </asp:BoundField>
                                    
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
                <asp:BoundField DataField="Remark" HeaderText="Remark">
                    <ControlStyle Width="120px" />
                    <ItemStyle HorizontalAlign="Center" Font-Size="10pt" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="11pt" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" BorderColor="Silver" />
            <EmptyDataRowStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
        </asp:GridView>
        &nbsp;&nbsp;<br />
        <table style="width: 1064px">
            <tr>
                <td colspan="3" style="height: 21px" align="left">
                    <asp:Label ID="lblTotal" runat="server" Font-Size="13pt" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Red"
            Text="Label"></asp:Label><br />
        <br />
        <asp:Button ID="cmdClose" runat="server" Height="26px" Text="Close" Width="79px" /><br />
        &nbsp;<br />
    </div>
   
</asp:Content>

