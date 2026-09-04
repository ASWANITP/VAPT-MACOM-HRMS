<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="simplerpt.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_Hrm_Earlygoing_status_rpt1_a2e43fec8207" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function Button1_onclick() {
            window.open('date_enter.aspx', '_self')
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Width="100%">
            </asp:Panel>
            &nbsp;<br />
            &nbsp;
        <input id="Button1" style="width: 77px" type="button" value="Exit" onclick="return Button1_onclick()" />
        </div>
    </form>
</body>
</html>
