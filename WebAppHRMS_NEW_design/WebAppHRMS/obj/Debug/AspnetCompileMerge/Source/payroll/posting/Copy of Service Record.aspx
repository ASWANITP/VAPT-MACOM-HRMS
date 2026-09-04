<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Copy of Service Record.aspx.vb" Inherits="WebAppHRMS.Service_Record_ad1a4eee3189" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Get Record</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        <asp:Button ID="ids" runat ="server" style="border:2px solid red;width:150px;left:200%;" OnClientClick=" return win();" Text ="Get Record List" />
        <script type ="text/javascript" >
        function win()
        {
        window.open("../Posting/ServiceRecord/")
        }
        </script>
    </div>
    </form>
</body>
</html>
