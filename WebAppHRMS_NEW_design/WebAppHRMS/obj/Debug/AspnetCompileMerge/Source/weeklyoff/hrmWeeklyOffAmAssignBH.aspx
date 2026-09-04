<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="hrmWeeklyOffAmAssignBH.aspx.vb" Inherits="WebAppHRMS.WeeklyOff_hrmWeeklyOffAmAssignBH_2ed9e8923190" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');
function ddlDayChange()
{  
    document.getElementById(con[0]+"hdnDay").value=document.getElementById(con[0]+"ddlDay").value;     
    document.getElementById(con[0]+"txtName").value = "";
    document.getElementById(con[0]+"txtBranch").value = "";
    document.getElementById(con[0]+"txtPost").value = "";  
    document.getElementById(con[0]+"txtDept").value = "";     
    document.getElementById(con[0]+"ddlEcode").options.length=0;
    document.getElementById(con[0]+"ddlEcode").value=-1;
    document.getElementById(con[0]+"ddlPost").value=-1;
    document.getElementById(con[0]+"txtDate").value="";   
     
    
}
function classOnChange()
{   
    if(document.getElementById(con[0]+"hdnDay").value=="")
    {
        document.getElementById(con[0]+"hdnDay").value=1;
    }
    
    document.getElementById(con[0]+"hdnPost").value=document.getElementById(con[0]+"ddlPost").value;
    if(document.getElementById(con[0]+"hdnPost").value==-1)
    {
        
         document.getElementById(con[0]+"txtName").value = "";
         document.getElementById(con[0]+"txtBranch").value = "";
         document.getElementById(con[0]+"txtPost").value = "";  
         document.getElementById(con[0]+"txtDept").value = "";     
         document.getElementById(con[0]+"ddlEcode").options.length=0;
         document.getElementById(con[0]+"ddlEcode").value=-1;   
         return false; 
    }
    else
    {
        callserver("1$"+document.getElementById(con[0]+"hdnPost").value+"$"+document.getElementById(con[0]+"hdnDay").value,1);
        document.getElementById(con[0]+"txtName").value = "";
        document.getElementById(con[0]+"txtBranch").value = "";
        document.getElementById(con[0]+"txtPost").value = "";  
        document.getElementById(con[0]+"txtDept").value = "";     
        document.getElementById(con[0]+"ddlEcode").options.length=0;
        document.getElementById(con[0]+"ddlEcode").value=-1;   
        return false;   
    }
   
}
function ddlOnchangeEcode()
{
    if(document.getElementById(con[0]+"hdnDay").value=="")
    {
        document.getElementById(con[0]+"hdnDay").value=1;
    }
    document.getElementById(con[0]+"hdnEcode").value=document.getElementById(con[0]+"ddlEcode").value;
    if(document.getElementById(con[0]+"hdnEcode").value==-1)
    {
         document.getElementById(con[0]+"txtName").value = "";
         document.getElementById(con[0]+"txtBranch").value = "";
         document.getElementById(con[0]+"txtPost").value = "";  
         document.getElementById(con[0]+"txtDept").value = "";     
         document.getElementById(con[0]+"ddlEcode").value=-1;   
         return false; 
    }
    else
    {
        callserver("2$"+document.getElementById(con[0]+"hdnEcode").value+"$"+document.getElementById(con[0]+"hdnDay").value,2);  
    }
}
function call_receiver(arg,context) 
{  
  
  switch (context)
  { 
    case 1:
    {   
        var dist = arg.split("@"); 
        document.getElementById(con[0]+"ddlEcode").options.length=0;
        if (dist[0]=="")
         {  alert("No Details ..!!!");
           return false; 
         }
          ComboFill(dist[0],"ddlEcode"); 
        break;
    }
    case 2:
    {       
        var accdt=arg.split("@");
        document.getElementById(con[0]+"txtDate").value =accdt[0];
        document.getElementById(con[0]+"hdnDate").value =accdt[0];
        var accdtl = accdt[1].split("*");    
        if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(con[0]+"txtName").value = "";
            document.getElementById(con[0]+"txtBranch").value = "";  
            document.getElementById(con[0]+"txtPost").value = "";  
            document.getElementById(con[0]+"txtDept").value = ""; 
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtName").value = accdtl[0];  
            document.getElementById(con[0]+"txtBranch").value = accdtl[1];  
            document.getElementById(con[0]+"txtPost").value = accdtl[2];  
            document.getElementById(con[0]+"txtDept").value = accdtl[3];  
         }  
        break;
    }  
  }
}
function ComboFill(Data,ComboName)
{
       if (Data[0] == '') return;
       
       var rows = Data.split("*");
       for(a=0; a<rows.length; a++)
   {
      var cols      = rows[a].split("$");
      var option1   = document.createElement("OPTION");
      option1.value = cols[0];
      option1.text  = cols[1];
      document.getElementById(con[0]+ComboName).add(option1);
   }
  
}
function OnclickConfirm()
{
    if(document.getElementById(con[0]+"ddlPost").value==-1)
    {
        alert("Please Select Post....!");
        document.getElementById(con[0]+"ddlPost").focus();
        return false;
    }
    if(document.getElementById(con[0]+"ddlEcode").value==-1)
    {
        alert("Please Select Employee Code....!");
        document.getElementById(con[0]+"ddlEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtName").value=="")
    {
        alert("Please Select Employee Code....!");
        document.getElementById(con[0]+"ddlEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Select Date....!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtReason").value=="")
    {
        alert("Please Enter Reason....!");
        document.getElementById(con[0]+"txtReason").focus();
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
        <asp:HiddenField ID="hdnPost" runat="server" />
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <asp:HiddenField ID="hdnDate" runat="server" />
        <asp:HiddenField ID="hdnRm" runat="server" />
        <asp:HiddenField ID="hdnDay" runat="server" />
        <asp:HiddenField ID="hid_zonal" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="text-align: left">
                    Select Day</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlDay" runat="server" Width="97%" onchange="ddlDayChange()">
                        <asp:ListItem Value="1">TODAY</asp:ListItem>
                        <asp:ListItem Value="2">TOMORROW</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    &nbsp;Select Post</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlPost" runat="server" Width="97%" onchange="classOnChange()">
                        <asp:ListItem Value="-1">-----SELECT-----</asp:ListItem>
                        <asp:ListItem Value="1">B.H</asp:ListItem>
                        <asp:ListItem Value="2">A.B.H</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Select Employee 
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlEcode" runat="server" Width="97%" onchange="ddlOnchangeEcode()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtName" runat="server" Width="97%"></asp:TextBox></td>
                <td style="width: 15%; text-align: left">
                    Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtBranch" runat="server" Width="97%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left; height: 28px;">
                    Post</td>
                <td style="width: 15%; height: 28px;">
                    <asp:TextBox ID="txtPost" runat="server" Width="97%"></asp:TextBox></td>
                <td style="width: 15%; text-align: left; height: 28px;">
                    Department</td>
                <td style="width: 15%; height: 28px;">
                    <asp:TextBox ID="txtDept" runat="server" Width="97%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Date Of &nbsp;Holiday Change</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtDate" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px; text-align: left">
                    Reason For Change</td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return OnclickConfirm()" />
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

