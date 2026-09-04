<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_rd_Add_Delete.aspx.vb" Inherits="WebAppHRMS.RD_Aadd_and_Delete_hrm_rd_Add_Delete_04b314898919" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function detailDisplay()
{
 if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        return false; 
     }
     if(document.getElementById(con[0]+"txtEcode").value=="")
     {
         document.getElementById(con[0]+"txtEname").value = "";
         document.getElementById(con[0]+"txtPost").value = "";
         document.getElementById(con[0]+"txtDes").value = "";  
         document.getElementById(con[0]+"txtBranch").value = "";  
         document.getElementById(con[0]+"txtDept").value = "";   
         document.getElementById(con[0]+"txtType").value = "";  
         document.getElementById(con[0]+"txtAmt").value = "";     
         return false; 
    }
    if(document.getElementById(con[0]+"txtEcode").value!="")
    {
        callserver("1$"+document.getElementById(con[0]+"txtEcode").value,1);  
    }
}
function isNumeric()
{
     if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        return false; 
     }
}
function call_receiver(arg,context) 
{     
  //debugger;
  switch (context)
  {
    case 1:
    {   
        var accdtl = arg.split("*");    
        if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = "";
            document.getElementById(con[0]+"txtPost").value = "";
            document.getElementById(con[0]+"txtDes").value = "";  
            document.getElementById(con[0]+"txtBranch").value = "";  
            document.getElementById(con[0]+"txtDept").value = "";   
            document.getElementById(con[0]+"txtType").value = "";   
            document.getElementById(con[0]+"txtRd").value = ""; 
             document.getElementById(con[0]+"txtAmt").value = "";             
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtEname").value = accdtl[0];
            document.getElementById(con[0]+"txtPost").value = accdtl[1];
            document.getElementById(con[0]+"txtDes").value = accdtl[2];  
            document.getElementById(con[0]+"txtBranch").value = accdtl[3];  
            document.getElementById(con[0]+"txtDept").value = accdtl[4]; 
            document.getElementById(con[0]+"txtType").value = accdtl[5];
            document.getElementById(con[0]+"txtAmt").value = accdtl[6]; 
            document.getElementById(con[0]+"txtRd").value = "";        
         } 
         break;   
     }
  }
}
function RadDeleteClick()
{
   document.getElementById("row1").style.display="none";
   document.getElementById(con[0]+"txtRd").value = "";  
   return false;  
}
function RadAddClick()
{
   document.getElementById("row1").style.display='inline';
}
function RdCheck()
{
   var a=document.getElementById(con[0]+"txtRd").value;
   if(isNaN(a))
   {
      alert('Please Enter Amount in Digits..!!');
      document.getElementById(con[0]+"txtRd").value = "";
      return false;
   }         
}
function ConfirmOnClick()
{   
    if(document.getElementById(con[0]+"txtEcode").value=="")
    {
        alert("Enter Employee Code.....!!!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEname").value=="")
    {
        alert("Enter Employee Code.....!!!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"rdAdd").checked==true)
    {
        if(document.getElementById(con[0]+"txtRd").value=="")
        {
            alert("Enter Amount.....!!!");
            document.getElementById(con[0]+"txtRd").focus();
            return false;
        }
    }
}
function btnExit_onclick() 
{
    window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 80%">
            <tr>
                <td colspan="2">
                    Enter Employee Code</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtEcode" runat="server" Width="60%" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="7"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 18%; text-align: left;">
                    Employee Name</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 18%; text-align: left;">
                    Post</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtPost" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 18%; text-align: left;">
                    Designation</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtDes" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 18%; text-align: left;">
                    Branch</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 18%; text-align: left;">
                    Department</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtDept" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 18%; text-align: left;">
                    Basic Pay</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtType" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    Already Entered Amount</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtAmt" runat="server" ReadOnly="True" Width="50%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 24px">
                    <asp:RadioButton ID="rdAdd" onclick="RadAddClick()" runat="server" Checked="True" GroupName="rd" Height="20px"
                        Text="ADD" Width="76px" />
                    <asp:RadioButton ID="rdDelete" onclick="RadDeleteClick()" runat="server" GroupName="rd" Text="DELETE"/></td>
            </tr>
            <tr id="row1">
                <td colspan="2" style="height: 28px">
                    Enter Amount To Add</td>
                <td colspan="2" style="height: 28px; text-align: left">
                    <asp:TextBox ID="txtRd" runat="server"  onkeyup="return RdCheck()" Width="70%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px">
                    <asp:Button ID="btnConfirm" OnClientClick=" return ConfirmOnClick()" runat="server" Text="CONFIRM" />
                    <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

