<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Rpt_DepHeadNew.aspx.vb" Inherits="WebAppHRMS.pl3_Rpt_DepHeadNew_1fa769ec4994" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        div {
            margin: 0 auto;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
window.open('../home.aspx','_self')
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="Hidden1" runat="server" type="hidden" />
            <asp:Panel ID="Panel1" runat="server" Width="80%" BackColor="MistyRose" BorderColor="Fuchsia" BorderStyle="Solid" BorderWidth="1px">
            </asp:Panel>
            &nbsp;<br />
            <input id="Button1" style="width: 80px; height: 32px" type="button" value="Exit" onclick="return Button1_onclick()" />

        </div>
    </form>
</body>
</html>

