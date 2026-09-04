<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_leave_applied_status_new.aspx.vb" Inherits="WebAppHRMS.Leave_Module_rpt_leave_applied_status_86b9fe5d8741" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="44px" Width="725px">
            </asp:Panel>
            &nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False">
                <RowStyle Font-Size="8pt" ForeColor="#000066" />
                <FooterStyle BackColor="Gainsboro" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="8pt" Font-Strikeout="False"
                    ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="From_Date" HeaderText="From DT">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="To_Date" HeaderText="To DT">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LEAVE_APPLY_DATE" HeaderText="Apply DT">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LEAVE_DAYS" HeaderText="Days">
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LEAVE_ABBR" HeaderText="Leave Type">
                        <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REASON_NAME" HeaderText="Reason">
                        <ItemStyle Width="125px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATUS" HeaderText="Status">
                        <ItemStyle Width="125px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FIRST_REC_PERSON" HeaderText="1st Recom. By">
                        <ItemStyle Width="175px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FIRST_RECOM_DATE" HeaderText="1st Recom. DT">
                        <ItemStyle Width="175px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REC_PERSON" HeaderText="Recomm. By">
                        <ItemStyle Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RECOM_DATE" HeaderText="Recomm. DT">
                        <ItemStyle Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REJECT_REASON" HeaderText="Reject Reason">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SANC_PERSON" HeaderText="Sanctioned/Rejected By">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SANC_DATE" HeaderText="Sanctioned/Rejected Date">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblNoData" runat="server" ForeColor="#C04000" Text="No Details available. "
                Visible="False"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
