<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_tour_applied_status.aspx.vb" Inherits="WebAppHRMS.tour_cancellation_rpt_tour_applied_status_3a0aca325312" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style media="print">
        .hide_print {
            display: none;
        }
    </style>
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">


          function btnExit_onclick() {
              window.open('../home.aspx', '_self');
          }

    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div style="text-align: left">
            <span class="hide_print">
                <input id="btnExit" style="width: 75px; height: 27px" type="button" value="Exit" onclick="return btnExit_onclick()" />
                <br />
            </span>

            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="727px">
            </asp:Panel>

        </div>
    </form>
</body
</html>
