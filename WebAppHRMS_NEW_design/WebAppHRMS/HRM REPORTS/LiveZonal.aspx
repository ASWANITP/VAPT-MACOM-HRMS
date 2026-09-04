<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="LiveZonal.aspx.vb" Inherits="WebAppHRMS.HRM_ResignedZonal_08317a9b6352" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<script type="text/javascript">
function nextpage(ZonalID,Status,FromDt,ToDt)
{
window.open('LiveRegion.aspx?ZonalID='+ ZonalID +'&Status='+Status+'&FromDt='+ FromDt +'&ToDt='+ ToDt +'','_self');
}

</script>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="60%">
            </asp:Panel>

        </div>
    </form>
</body>
</html>
