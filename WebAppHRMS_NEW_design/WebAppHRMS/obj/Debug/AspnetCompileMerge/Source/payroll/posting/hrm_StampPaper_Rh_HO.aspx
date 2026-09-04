<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_StampPaper_Rh_HO.aspx.vb" Inherits="WebAppHRMS.Stamp_Paper_Module_hrm_StampPaper_Rh_HO_de296b734260" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function window_onload() 
{
    document.getElementById("rowRes").style.display='none';
}
function ddlOnchange()
{
   document.getElementById(con[0]+"hdnEcode").value=document.getElementById(con[0]+"ddlEcode").value; 
   if(document.getElementById(con[0]+"ddlEcode").value!=-1)
   {
        callserver("1$"+document.getElementById(con[0]+"hdnEcode").value,1);  
   }
   else
   {
        document.getElementById(con[0]+"txtEcode").value = "";
        document.getElementById(con[0]+"txtEname").value = "";
        document.getElementById(con[0]+"txtPost").value = "";
        document.getElementById(con[0]+"txtBranch").value = "";
        document.getElementById(con[0]+"txtDes").value = "";
        document.getElementById(con[0]+"txtJdate").value = "";
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
            
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = "";
            document.getElementById(con[0]+"txtPost").value = "";
            document.getElementById(con[0]+"txtBranch").value = "";
            document.getElementById(con[0]+"txtDes").value = "";
            document.getElementById(con[0]+"txtJdate").value = "";     
         }
         else
         {
            document.getElementById(con[0]+"txtEcode").value = accdtl[0];
            document.getElementById(con[0]+"txtEname").value = accdtl[1];
            document.getElementById(con[0]+"txtPost").value = accdtl[2];
            document.getElementById(con[0]+"txtBranch").value = accdtl[3];
            document.getElementById(con[0]+"txtDes").value = accdtl[4];
            document.getElementById(con[0]+"txtJdate").value = accdtl[5]; 
         } 
         break;   
     }
  }
}
function chkOnClick()
{
   if(document.getElementById(con[0]+"Chkreject").checked==true)
    {
       document.getElementById("rowRes").style.display='inline';
    } 
    else
    {
        document.getElementById("rowRes").style.display='none';
    }
}
function onConfClick()
{
    if(document.getElementById(con[0]+"ddlEcode").value==-1)
    {
        alert("Please Select Employee...!!!");
        document.getElementById(con[0]+"ddlEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEcode").value=="")
    {
        alert("Please Select Employee...!!!");
        document.getElementById(con[0]+"ddlEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"Chkreject").checked==true)
    {
        if(document.getElementById(con[0]+"txtReason").value=="")
        {
            alert("Please Enter Reject Reason");
            document.getElementById(con[0]+"txtreason").focus();
            return false;
        }
    }
}
function btnExit_onclick() 
{
    window.open("../../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <table border="1" style="width: 80%">
            <tr>
                <td colspan="2" style="text-align: left">
                    Select Employee</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlEcode" runat="server" Width="97%" onchange="ddlOnchange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left;">
                    Employee Code</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEcode" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left;">
                    Employee Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtEname" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left;">
                    Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtBranch" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; text-align: left;">
                    Post</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtPost" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%; height: 23px; text-align: left;">
                    Department</td>
                <td style="width: 15%; height: 23px">
                    <asp:TextBox ID="txtDes" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; height: 23px; text-align: left;">
                    Joining Date</td>
                <td style="width: 15%; height: 23px">
                    <asp:TextBox ID="txtJdate" runat="server" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px; text-align: center">
                    <asp:CheckBox ID="Chkreject" runat="server" Text="Reject" onclick="chkOnClick()" /></td>
            </tr>
            <tr id="rowRes">
                <td colspan="2" style="height: 23px; text-align: left">
                    Reject Reason</td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:TextBox ID="txtReason" runat="server" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" OnClientClick="return onConfClick()" />
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

