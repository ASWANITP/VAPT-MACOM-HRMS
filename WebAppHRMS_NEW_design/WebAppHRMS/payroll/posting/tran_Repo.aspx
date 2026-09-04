<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="tran_Repo.aspx.vb" Inherits="WebAppHRMS.tran_Repo_cd52ecde1951" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">

        function Button2_onclick() {
            window.open("../../home.aspx", '_self');
        }
        function demo() {
            document.getElementById('Button2').style.display = 'none'
            document.getElementById('Submit1').style.display = 'none'
            window.print();
            document.getElementById('Button2').style.display = 'inline'
            document.getElementById('Submit1').style.display = 'inline'
        }
    </script>



    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body style="display: flex; justify-content: center; align-items: center; margin: 0;">
    <form id="form1" runat="server">
        <div style="width: 80%; max-width: 800px; text-align: center;">
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="713px"></asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="651px"></asp:Panel>
            <br />
            <br />
            <div style="left: 50%; text-align: center; margin-top: 650px; float: right;">
                <input id="Submit1" style="width: 86px" type="submit" onclick="return demo()" value="PRINT" />
                <input id="Button2" style="width: 83px" type="button" onclick="return Button2_onclick()" value="EXIT" />
            </div>
        </div>
    </form>
</body>

</html>
