<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="pf_form5.aspx.vb" Inherits="WebAppHRMS.PF_REPORT_pf_form5_b3fbf9126278" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function Button1_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="Button1" type="button" value="<< EXIT" onclick="return Button1_onclick()" /><br />
            <asp:Panel ID="Panel1" runat="server" Height="43px" Width="725px">
            </asp:Panel>
            &nbsp;
        </div>
    </form>
</body>
</html>
