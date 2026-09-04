<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="LiveDivision.aspx.vb" Inherits="WebAppHRMS.HRM_ResignedDivision_839af5253454" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<script type="text/javascript">
function nextpage(DivisionID,Status,FromDt,ToDt)
{
window.open('LiveArea.aspx?DivisionID='+ DivisionID +'&Status='+ Status +'&FromDt='+ FromDt +'&ToDt='+ ToDt +'','_self');
}

</script>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="60%">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
