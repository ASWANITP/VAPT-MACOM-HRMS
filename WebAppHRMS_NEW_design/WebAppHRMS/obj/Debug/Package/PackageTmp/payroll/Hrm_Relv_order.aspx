<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Hrm_Relv_order.aspx.vb" Inherits="WebAppHRMS.Check_Hrm_Relv_order_09f7a56f8716" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="Viewer1" runat="server" AutoDataBind="true" Style="position: relative" />
    
    </div>
    </form>
</body>
</html>
