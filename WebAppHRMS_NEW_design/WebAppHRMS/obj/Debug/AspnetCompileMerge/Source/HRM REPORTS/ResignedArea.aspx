<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="ResignedArea.aspx.vb" Inherits="WebAppHRMS.HRM_ResignedArea_5a7fd99d4251" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center">
<script type="text/javascript">
function nextpage(AreaID,Status,FromDt,ToDt)
{
window.open('ResignedBranch.aspx?AreaID='+ AreaID +'&Status='+ Status +'&FromDt='+ FromDt +'&ToDt='+ ToDt +'','_self');
}

</script>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="60%">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
