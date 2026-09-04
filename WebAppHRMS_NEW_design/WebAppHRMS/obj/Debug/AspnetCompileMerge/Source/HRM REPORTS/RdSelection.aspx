<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="RdSelection.aspx.vb" Inherits="WebAppHRMS.Auction_date_87ab45252667" title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont=loanno.split('dpl')

function generateonclick()
{
//if (document.getElementById(cont[0]+"dplAuctionDATE").value=="-1") 
if(document.getElementById(cont[0]+"dplAuctionDATE").options[document.getElementById(cont[0]+"dplAuctionDATE").selectedIndex].text=='--SELECT--')
{
alert("Please Select Auction Date");
document.getElementById(cont[0]+"dplAuctionDATE").focus();
return false;
}
if(document.getElementById(cont[0]+"rbnStatusREPORT").checked==false && document.getElementById(cont[0]+"rbnViewATTACHMENT").checked==false )
{
alert("Please Select Status Report OR View Attachments");
return false;
}
}
</script>
    <br />
    <br />
    <br />
    <br />
    <table style="text-align: center; height: 221px;" align="center" border="1" >
        <tr>
            <td colspan="3" style="height: 8px">
                <strong>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                    <span style="text-decoration: underline">
                    EMPLOYEE WISE - RD BALANCE REPORT</span></strong></td>
        </tr>
        <tr>
            <td style="width: 171px;">
                Live/Resigned/All ?</td>
            <td style="text-align: center;" colspan="2">
                <asp:DropDownList ID="dplType" runat="server" Width="136px">
                    <asp:ListItem Value="0">-------Select-------</asp:ListItem>
                    <asp:ListItem Value="1">Live</asp:ListItem>
                    <asp:ListItem Value="2">Resigned</asp:ListItem>
                    <asp:ListItem Value="3">All</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 171px;">
                <asp:Button ID="Btn_Exit" runat="server" Font-Bold="True" Text="Exit" Width="90px" /></td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnGenerate" runat="server" Text="List" Width="84px" Font-Bold="True" OnClientClick="return generateonclick()"  /></td>
        </tr>
        <tr>
            <td style="width: 171px;">
                </td>
            <td colspan="2">
                </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

