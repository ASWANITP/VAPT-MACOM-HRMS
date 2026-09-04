<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_WeekoffImmedchange_cancel.aspx.vb" Inherits="WebAppHRMS.WeeklyOff_hrm_WeekoffImmedchange_cancel_487a6e2f9687" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');
function ddlOnchange()
{
    document.getElementById(con[0]+"hdnEcode").value=document.getElementById(con[0]+"ddlEcode").value;
    if(document.getElementById(con[0]+"hdnEcode").value==-1)
    {
         document.getElementById(con[0]+"txtEcode").value = "";
         document.getElementById(con[0]+"txtEName").value = "";
         document.getElementById(con[0]+"txtBranch").value = "";
         document.getElementById(con[0]+"txtPost").value = "";  
         document.getElementById(con[0]+"txtOffday").value = "";     
         document.getElementById(con[0]+"txtChday").value="";   
         return false; 
    }
    else
    {
        callserver("1$"+document.getElementById(con[0]+"hdnEcode").value,1);  
    }
}
function call_receiver(arg,context) 
{  
  
  switch (context)
  { 
    case 1:
    {       
        var accdtl = arg.split("*");    
        if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEName").value = "";
            document.getElementById(con[0]+"txtBranch").value = "";
            document.getElementById(con[0]+"txtPost").value = "";  
            document.getElementById(con[0]+"txtOffday").value = "";     
            document.getElementById(con[0]+"txtChday").value="";
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtEcode").value = accdtl[0];  
            document.getElementById(con[0]+"txtEName").value = accdtl[1];  
            document.getElementById(con[0]+"txtBranch").value = accdtl[2];  
            document.getElementById(con[0]+"txtPost").value = accdtl[3];  
            document.getElementById(con[0]+"txtOffday").value = accdtl[4];    
            document.getElementById(con[0]+"txtChday").value=accdtl[5];  
         }  
        break;
    }  
  }
}
function onConfClick()
{
    if(document.getElementById(con[0]+"ddlEcode").value==-1)
    {
        alert("Please Select Employee....!");
        document.getElementById(con[0]+"ddlEcode").focus();
        return false;
    }

}
function btnExit_onclick() 
{
    window.open("../Home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">
                    Select Employee</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlEcode" runat="server" Width="95%" onchange="ddlOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    Emp Code</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEcode" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">
                    Emp Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEname" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtBranch" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">
                    Post</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtPost" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    Weekly off Day</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtOffday" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">
                    Changed Day</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtChday" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick=" return onConfClick()" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

