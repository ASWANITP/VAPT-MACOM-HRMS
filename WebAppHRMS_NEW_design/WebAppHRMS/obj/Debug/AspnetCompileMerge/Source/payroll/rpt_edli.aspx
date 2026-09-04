<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_edli.aspx.vb" Inherits="WebAppHRMS.EDLI_rpt_edli_03809aa89734" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('edli_main.aspx','_self');
}

// ]]>
</script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" type="button" value="<< EXIT" onclick="return Button1_onclick()" style="font-weight: bold; color: #ff0000" /><br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
             EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
        &nbsp;</div>
    </form>
</body>
</html>
