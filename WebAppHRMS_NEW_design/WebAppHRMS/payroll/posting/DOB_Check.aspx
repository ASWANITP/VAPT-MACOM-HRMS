<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="DOB_Check.aspx.vb" Inherits="WebAppHRMS.HRM_DOB_Check_7509bda16559" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

function btnExit_onclick() 
{
    window.open("../../home.aspx","_self");
}

// ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="1" style="width: 60%; position: relative">
                <caption>
                    <strong>NAME AND DOB CHECKING</strong></caption>
                <tr>
                    <td style="width: 20%">EMPLOYEE NAME</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtname" runat="server" Style="position: relative; left: -1px;" Width="96%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 20%">DATE OF BIRTH</td>
                    <td style="width: 20%">
                        <asp:TextBox ID="txtdob" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        <asp:Button ID="Button1" runat="server" Style="position: relative" Text="CHECK" Width="120px" /></td>
                    <td style="width: 20%"></td>
                    <td style="width: 20%">
                        <input id="btnExit" onclick="btnExit_onclick()" style="left: -22px; width: 80px; position: relative" type="button"
                            value="EXIT" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

