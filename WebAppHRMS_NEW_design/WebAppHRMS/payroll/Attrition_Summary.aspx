<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Attrition_Summary.aspx.vb" Inherits="WebAppHRMS.Auction_Listed_pledges_3b4510c82682" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>


    <script language="javascript" type="text/javascript">


        function to_area(rid, tdt) {
            window.open('TargetArea.aspx?REGID=' + rid + '&tdat=' + tdt + '', '_self');
        }

    </script>



</head>


<body style="text-align: center">
    <form id="form1" runat="server">
        <asp:Panel Style="left: 0px; position: relative; top: 0px" ID="Panel1" runat="server">
            <table border="3" style="width: 928.5px; border-color: Black; font-family: Courier New; border-bottom: 0px;">
                <tr>
                    <td colspan="29" style="height: 24px; text-align: center; width: 100%; background-color: #ffd700;">
                        <strong><span style="font-size: 14pt; color: Red; font-family: Times New Roman;">MABEN NIDHI LIMITED</span></strong></td>
                </tr>
                <tr>
                    <td style="text-align: left; background-color: Silver;">
                        <strong>Select Year :</strong><%--</td>
                    <td style="text-align: left; height: 24px;">--%>
                        <asp:DropDownList ID="years" runat="server" Width="220px">
                        </asp:DropDownList></td>

                    <td style="text-align: left; background-color: Silver;">
                        <strong>Select Month :</strong><%--</td>
                    <td style="text-align: left; height: 24px;">--%>
                        <asp:DropDownList ID="months" runat="server" Width="150px">
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" OnClientClick="loads()" Text="Proceed" /></td>
                </tr>

            </table>
        </asp:Panel>
        <%--<asp:Label ID="Labelerror" runat="server" Text="HI"></asp:Label>--%>

        <asp:Panel Style="left: 0px; position: relative; top: 0px" ID="Panel2" runat="server">
            <table border="3" style="width: 928.5px; border-color: Black; font-family: Courier New; border-bottom: 0px;">
                <tr>
                    <td colspan="29" style="height: 24px; text-align: center; width: 100%; background-color: #fff; border-bottom: 0px;"></td>
                </tr>
                <tr>
                    <td colspan="29" style="height: 24px; text-align: center; width: 100%; background-color: #fff;">
                        <strong><span style="font-size: 14pt; color: Red; font-family: Times New Roman;">! NO DATA FOUND !</span></strong></td>
                </tr>
                <tr>
                    <td style="text-align: center; background-color: Silver;">
                        <strong>Select Year & Month To Display Attrition Data</strong></td>
                </tr>

            </table>
        </asp:Panel>

        <asp:Panel Style="left: 0px; position: relative; top: 0px" ID="Panel3" runat="server">
            <table border="3" style="width: 928.5px; border-color: Black; font-family: Courier New;">
                <tr>
                    <td colspan="29" style="height: 24px; text-align: center; width: 100%; background-color: #fff; border-bottom: 0px;">
                        <asp:Button ID="Button2" runat="server" OnClientClick="loads()" Text="Exit Now" />
                    </td>
                </tr>

            </table>
        </asp:Panel>
    </form>
</body>
</html>
