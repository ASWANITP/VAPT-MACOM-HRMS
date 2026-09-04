<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="LeaveRegisterCover.aspx.vb" Inherits="WebAppHRMS.LeaveRegisterCover_46e5cf265548" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="675px"  Width="628px" style="margin: 0 auto; text-align: center; display: flex; justify-content: center;">
                     
                  <br />     
                        
            <span style="font-family: @MS Mincho"><span style="font-size: 14pt">KERALA SHOPS &amp;
                COMMERCIAL ESTABLISHMENT ACT, 1960<br />
                <br />
                FORM F<br />
                <br />
                [ See Rule 10 (9)]<br />
            </span>
                <br />
                <br />
                <br />
                <br />
                <br />
                <span style="font-size: 24pt">REGISTER OF HOLIDAYS &amp; LEAVE<br />
                    <br />
                    <br />
                    <br />
                    <%--<br />
                    <br />--%>
                    <span style="font-size: 14pt">
                        Name of the Firm :
                        <asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label>
                        <br />
                        
                        Place :
                        <asp:Label ID="Label2" runat="server"  Text="Label"></asp:Label>
                        <br />
                        <br />
                        <br />
                        Year ...............................................<br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/leave/Holiday_Register_Form.aspx">View Report</asp:HyperLink><br />
                        <br />
                        <br />
                        
                    </span></span></span></strong>
        </asp:Panel>

    
    </div>
    </form>
</body>
</html>
