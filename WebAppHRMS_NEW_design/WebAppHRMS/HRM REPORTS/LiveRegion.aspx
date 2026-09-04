<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="LiveRegion.aspx.vb" Inherits="WebAppHRMS.HRM_LiveRegion_ba6d2a6c6250" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <script type="text/javascript">
function nextpage(RegionID,Status,FromDt,ToDt)
{
window.open('LiveDivision.aspx?RegionID='+ RegionID +'&Status='+ Status +'&FromDt='+ FromDt +'&ToDt='+ ToDt +'','_self');
}

    </script>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="70%">
            </asp:Panel>

        </div>
    </form>
</body>
</html>
