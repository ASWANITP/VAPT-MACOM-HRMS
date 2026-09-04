<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Visual.aspx.vb" Inherits="WebAppHRMS.HRM_Visual_0ceb7a503821" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function btnClose_onclick() {
window.open("../home.aspx","_self")
}

// ]]>
    </script>
    <link href="../HRM/ValidateStyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body alink="dimgray" bgcolor="inactivecaptiontext" background="Library/wood.jpg">
    <form id="form1" runat="server">
        <div>
            <div style="font-family: 'Courier New'; text-align: center; font-weight: bold; font-size: large; background-attachment: scroll; background-repeat: no-repeat; background-color: transparent; font-variant: normal;" id="DIV1" runat="server">
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Size="X-Large" Text="Firm"
                    Width="488px"></asp:Label><br />
                <br />
                <br />
                &nbsp;<br />
                <br />
                <table border="1" style="width: 432px; height: 144px; font-weight: bold;">
                    <tr>
                        <td style="width: 20%; height: 28px">Company Profile</td>
                        <td style="width: 20%; height: 28px">
                            <asp:Button ID="btnCompProfile" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 28px">Our Vision</td>
                        <td style="width: 20%; height: 28px">
                            <asp:Button ID="btnVision" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Money Transfer</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnMoneyTransfer" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 28px">Outward Remittance</td>
                        <td style="width: 20%; height: 28px">
                            <asp:Button ID="btnOutward" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Gold Coin</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnGoldCoin" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Gold Loan Schemes</td>
                        <td style="width: 20%">
                            <asp:Button ID="Button1" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Gold Loan Recovery</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnGLRecovery" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Strong Room Plan</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnStrongPlan" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>

                    <tr>
                        <td style="width: 20%">Customer Service</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnCustService" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Successfull&nbsp;Communication</td>
                        <td style="width: 20%">
                            <asp:Button ID="btnCommunication" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Induction
                        </td>
                        <td style="width: 20%">
                            <asp:Button ID="cmd_induction" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 20%">Gold Loan</td>
                        <td style="width: 20%">
                            <asp:Button ID="cmd_goldloan" runat="server" CssClass="groovybutton" Text="Download" Width="120px" Visible="False" /></td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnClose" runat="server" CssClass="FirstButton" Text="Click To Close" Width="136px" /><br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>

        </div>
    </form>
</body>
</html>
