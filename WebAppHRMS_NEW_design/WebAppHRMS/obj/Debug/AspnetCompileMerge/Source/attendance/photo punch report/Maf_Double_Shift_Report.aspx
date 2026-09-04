<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Maf_Double_Shift_Report.aspx.vb" Inherits="WebAppHRMS.maf_report_242ff21c6333" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Employee Report</title>
    </head>
<script language="javascript" type="text/javascript">

function Button1_onclick() 
{
  window.open("../home.aspx",'_self');
}
function demo()
{
  window.open("viewrep.aspx",'_self');
}
</script>
<body>
    <form id="form1" runat="server">
     <div>
     <input type="button" visible ="false"  style="width: 113px" value="Back" runat ="server" id="submit"  onclick="return demo()"/>
            <input visible ="false" id="Button1" style="width: 105px" runat ="server" type="button" value="Exit" onclick="return Button1_onclick()" />
        <asp:Panel ID="Panel1" style="LEFT: 0px; POSITION: relative; TOP: 0px" runat="server" Height="50px" Width="713px">
        </asp:Panel>
              
    </div>
    </form>
</body>
</html>
