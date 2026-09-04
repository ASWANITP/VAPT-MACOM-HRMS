<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="pl3absent.aspx.vb" Inherits="WebAppHRMS._pl3absent_b889fcdb6028" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
  window.open("../home.aspx",'_self');
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}
</script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
            <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/><input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />&nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            BorderColor="#FFE0C0" BorderStyle="Dotted" BorderWidth="2px" HasRefreshButton="True" Width="350px"  EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
        <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"
            Height="75px" Width="555px"></asp:Label>&nbsp;
        <br />
            
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
