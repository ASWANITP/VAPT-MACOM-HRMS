<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="reg_wise.aspx.vb" Inherits="WebAppHRMS.staff_noms_reg_wise_85a1d8d04699" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<script type="text/javascript">

 function openwin(reg_id)
    {
      window.open("div_wise.aspx?rid="+reg_id,"_self")
    }
function openback()
   {
    window.open('zonal_norms.aspx','_self');
   }
</script>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="725px">
        </asp:Panel>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return openback()">BACK</asp:LinkButton></div>
    </form>
</body>
</html>
