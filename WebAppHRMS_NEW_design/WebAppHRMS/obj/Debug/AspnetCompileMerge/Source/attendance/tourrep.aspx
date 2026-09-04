<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="tourrep.aspx.vb" Inherits="WebAppHRMS.payroll_tourrep_b419bb0e4994" %>

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
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
 window.open("../home.aspx",'_self')
}

// ]]>
</script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" style="width: 46px" type="button" value="Back" onclick="return Button1_onclick()" />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
             EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
            ReuseParameterValuesOnRefresh="True" />
    
    </div>
    </form>
</body>
</html>
