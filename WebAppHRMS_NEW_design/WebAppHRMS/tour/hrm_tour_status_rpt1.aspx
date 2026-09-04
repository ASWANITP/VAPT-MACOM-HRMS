<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="hrm_tour_status_rpt1.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_hrm_tour_status_rpt1_91bab1816942" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }

    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Width="80%">
            </asp:Panel>
            <br />
            <input id="Button2" onclick="history.go(-1)" type="button" value="Go Back" />&nbsp;
        </div>
    </form>
</body>
</html>
