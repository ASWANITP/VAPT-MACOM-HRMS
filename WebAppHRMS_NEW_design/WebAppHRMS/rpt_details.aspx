<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_details.aspx.vb" Inherits="WebAppHRMS.accounts_Period_wide_rpt_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <asp:LinkButton ID="lnkbutExportXL" CommandName="Export" runat="server" Text="Export to Excel"></asp:LinkButton>
        &nbsp;<asp:Panel ID="pn3" runat="server" Height="50px" Width="140%">
        </asp:Panel>
    </form>
</body>
</html>
