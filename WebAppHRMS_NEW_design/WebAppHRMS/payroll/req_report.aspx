<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="req_report.aspx.vb" Inherits="WebAppHRMS.req_report_37518d1f3839" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Company&nbsp;bussiness</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
<!--

    function Button2_onclick() {
        window.open('../home.aspx', '_self');
    }

    // -->
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="Button2" class="bttn_design" style="width: 58px;" type="button" value="Exit" onclick="return Button2_onclick()" /><br />
            <br />
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Width="100%" />

        </div>
    </form>
</body>
</html>
