<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Referral_ince_report.aspx.vb" Inherits="WebAppHRMS.Referral_incentive_report_8e854ba32547" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
        function go() {
            window.open('../home.aspx', '_self');
            //            '--KRISHNADAS CREATED FOR JEWEL REFERRAL INCENTIVE
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <asp:Panel ID="Panel1" runat="server" Width="70%">
            </asp:Panel>
            <input style="width: 72px; cursor: hand; font-family: 'Courier New'" id="cmd_Exit" onclick="return go()" type="button" value="Exit" />
        </div>
    </form>
</body>
</html>
