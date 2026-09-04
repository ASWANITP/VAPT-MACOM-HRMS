<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_empsearch_location.aspx.vb" Inherits="WebAppHRMS.employeesearch_location_rpt_empsearch_location_b6a002804583" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_back_onclick() {
window.open('empsearch_location.aspx','_self');
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <input id="cmd_back" style="height: 20px" type="button" value="BACK" onclick="return cmd_back_onclick()" /><br />
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="700px">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
