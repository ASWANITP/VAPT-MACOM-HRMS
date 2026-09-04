<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Employee_Leave_RptCode.aspx.vb" Inherits="WebAppHRMS.Store_drill_storeinventorylist_72e46ba67609" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style media=print> .hide_print {display:none;} </style>
    <%--<script language="javascript" type="text/javascript">
    
    function btn_exit_onclick() 
    {
        window.open('../../home.aspx','_self');
    }
    </script>--%>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Panel ID="Panel1" runat="server" align="center" Width="100%">
        </asp:Panel>
        <%--<input id="btn_exit" style="width: 112px" type="button" value="EXIT" onclick="return btn_exit_onclick()" />--%>
         <asp:Button ID="btn_Exit" runat="server" Text="Exit" style="width: 100px" />
        </div>
    </form>
</body>
</html>
