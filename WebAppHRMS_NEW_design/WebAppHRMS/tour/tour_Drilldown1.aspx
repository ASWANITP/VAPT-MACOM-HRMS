<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="tour_Drilldown1.aspx.vb" Inherits="WebAppHRMS.tour_Drilldown1_7b63df988861" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function next(dtl, frdt, todt) {

            window.open('tour_ao_rpt1.aspx?dtl=' + dtl + '&frdt=' + frdt + '&todt=' + todt, '_self');

        }

    </script>
</head>
<body onload="return window_onload()">

    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="PanelDrilldownshort" runat="server" Height="50px" Width="60%">
            </asp:Panel>

        </div>
    </form>
</body>
</html>
