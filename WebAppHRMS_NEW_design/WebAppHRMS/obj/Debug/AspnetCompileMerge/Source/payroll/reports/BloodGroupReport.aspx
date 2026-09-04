<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="BloodGroupReport.aspx.vb"  Inherits="WebAppHRMS.Auction_Listed_pledges_3b4510c88157" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
   
    
    <script language="javascript" type="text/javascript">
        function cmd_exit_onclick() {
            window.open('../../home.aspx', '_self');
        }
    </script>
    
    
    
</head>


<body style="text-align: center">
    <form id="form1" runat="server">
        <input id="cmd_exit" style="width: 67px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />
        <asp:Panel ID="Panel1" runat="server" Width="100%">
        </asp:Panel>
        &nbsp;
    </form>
</body>
</html>
