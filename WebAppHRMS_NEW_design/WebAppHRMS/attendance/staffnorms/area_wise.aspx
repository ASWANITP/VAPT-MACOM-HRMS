<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="area_wise.aspx.vb" Inherits="WebAppHRMS.staff_noms_area_wise_e2dd00368958" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Staff Norm:Areawise</title>
</head>
<body>

<script type="text/javascript">

 function openwin(area_id)
    {
      window.open("staffnoms_rpt.aspx?arid="+area_id,"_self")
    }
</script>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="725px">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
