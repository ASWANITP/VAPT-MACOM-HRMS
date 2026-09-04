<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_Absentees.aspx.vb" Inherits="WebAppHRMS.HRM_Reports_rpt_Absentees_46296bec1157" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <script language="javascript" type="text/javascript">
function nextpage(TRAINID,FromDt,ToDt)
{
   window.open('rpt_Absentees01.aspx?&TRAINID='+ TRAINID +'&FromDt='+ FromDt +'&ToDt='+ ToDt +'','_self');
}
function btnExit_onclick() 
{
    window.open("../home.aspx","_self")
}

    </script>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
            </asp:Panel>
            <br />
            <input id="btnExit" onclick="return btnExit_onclick()" style="cursor: hand; font-family: 'Courier New'" type="button"
                value="Exit" />
        </div>
    </form>
</body>
</html>
