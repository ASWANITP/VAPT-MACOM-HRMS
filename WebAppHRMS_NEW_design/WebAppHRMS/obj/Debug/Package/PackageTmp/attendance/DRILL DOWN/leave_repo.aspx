<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="leave_repo.aspx.vb" Inherits="WebAppHRMS.leaverepo_9ff5ab3a4581" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Insurance&nbsp;Top&nbsp;Performing&nbsp;Staff&nbsp;Report</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
<!--

function Button1_onclick() {
 window.open('../../home.aspx','_self');
}


// -->
</script>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        <input id="Button1" class="bttn_design"  style="width: 66px"
            type="button" value="Exit" onclick="return Button1_onclick()" /><br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="50px" ReportSourceID="CrystalReportSource1" Width="200px"  />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="PTASAL.rpt">
            </Report>
        </CR:CrystalReportSource>
        &nbsp;&nbsp;
        <asp:HiddenField ID="HiddenField1" runat="server"/>
       
    </div>
    </form>
</body>
</html>

