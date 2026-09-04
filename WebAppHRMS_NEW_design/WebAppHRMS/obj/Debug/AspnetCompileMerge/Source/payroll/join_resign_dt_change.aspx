<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="join_resign_dt_change.aspx.vb" Inherits="WebAppHRMS.HRM_JOIN_DT_CHANGE_ce99096c3438" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function btnExit_onclick() 
{
 window.open("../home.aspx","_self");
}


// ]]>
</script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="new_join" runat="server">
                </cc1:CalendarExtender>
    <table border="2" style="left: 200px; width: 29%; position: relative; top: -6px; height: 1px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr align="right">
            <td colspan="4" style="height: 5px ; vertical-align:top" align="center"><b>JOIN DATE CHANGE</b></td>
        </tr>
        <tr align="right">
            <td style="width: 53%; height: 5px ; vertical-align:top" align="center">
                Employee Code</td>
            <td style="width:14%; height: 5px ; vertical-align:top" align="center">
                <asp:TextBox ID="txtecode" runat="server" Style="left: 0px; position: relative;
                    top: 0px" Width="240px" OnTextChanged="txtecode_TextChanged" AutoPostBack="True"></asp:TextBox></td>
            <td style="width: 14%; height: 5px ; vertical-align:top" align="center">
                Employee Name</td>
            <td style="width:14%; height: 5px ; vertical-align:top" align="center">
                <asp:TextBox ID="txtename" runat="server" Style="position: relative" Width="240px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr align="right">
            <td style="width:53%; height: 12px ; vertical-align:top" align="center">
                Current Date</td>
            <td style="width: 14%; height: 12px ; vertical-align:top" align="center">
                <asp:TextBox ID="txt_date" runat="server" Width="240px" ReadOnly="True"></asp:TextBox></td>
            <td style="width:14%; height: 12px ; vertical-align:top" align="center">
                New Date</td>
            <td style="width:14%; height: 12px ; vertical-align:top" align="center">
                <asp:TextBox ID="new_join" runat="server" Width="240px"></asp:TextBox></td>
        </tr >
        <tr align="center">
            <td style="height: 10px ; vertical-align:top" colspan="4" align="center">
                </td>
        </tr>
         <tr align="right">
          <td style="height: 10px; vertical-align:top" colspan="4" align="center">
           
                <asp:Button ID="btnConfrm" runat="server" Style="left: 32px; position: relative;
                    top: 80px" Text="CONFIRM" /><input id="btnExit" onclick="return btnExit_onclick()"
                        style="left: 48px; width: 88px; position: relative; top: 80px; height: 24px"
                        type="button" value="EXIT" /></td>
                        </tr>
        
   </table></ContentTemplate>
   </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </asp:Content>

