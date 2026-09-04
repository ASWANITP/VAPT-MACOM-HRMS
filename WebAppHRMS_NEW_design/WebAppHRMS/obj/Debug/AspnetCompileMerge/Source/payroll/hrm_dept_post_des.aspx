<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_dept_post_des.aspx.vb" Inherits="WebAppHRMS.RajDeptPost_hrm_dept_post_des_ce46433c9615" title="Untitled Page" %>
<%@ Register Assembly ="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onclick">
// <!CDATA[
//return window_onclick()
// ]]>
</script>

<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
    window.onload = callback;
    function callback() {
        return window_onload();
    }
// ]]>
</script>

<script language="javascript" type="text/javascript">
var cont_name=header.split('ddl');
function CheckDep()
{
    if(document.getElementById(cont_name[0]+"rdDept").checked==true)
    {
        document.getElementById(cont_name[0]+"txtdpd").value="";
        document.getElementById(cont_name[0]+"lblFirst").innerHTML="Select Main Department";
        document.getElementById(cont_name[0]+"lblSecond").innerHTML="Enter new Department";
        document.getElementById(cont_name[0]+"ddlGrade").style.display='none';
        document.getElementById(cont_name[0]+"lblFirst").style.display='inline';
        document.getElementById(cont_name[0]+"ddlMainDept").style.display='inline';       
    }
}
function CheckPost()
{
    if(document.getElementById(cont_name[0]+"rdPost").checked==true)
    {
        document.getElementById(cont_name[0]+"txtdpd").value="";
        document.getElementById(cont_name[0]+"lblSecond").innerHTML="Enter Post";
        document.getElementById(cont_name[0]+"lblFirst").style.display='none';
        document.getElementById(cont_name[0]+"ddlGrade").style.display='none';
        document.getElementById(cont_name[0]+"ddlMainDept").style.display='none';
    }
}
function CheckDes()
{
    if(document.getElementById(cont_name[0]+"rdDes").checked==true)
    {
        
        document.getElementById(cont_name[0]+"txtdpd").value="";
        document.getElementById(cont_name[0]+"lblFirst").innerHTML="Select Grade";
        document.getElementById(cont_name[0]+"lblSecond").innerHTML="Enter new Designation";
        document.getElementById(cont_name[0]+"lblFirst").style.display='inline';
        document.getElementById(cont_name[0]+"ddlGrade").style.display='inline';
        document.getElementById(cont_name[0]+"ddlMainDept").style.display='none';

        
//        return false;
    }
}
function window_onload() 
{

    document.getElementById(cont_name[0]+"rdDept").checked=true;
    document.getElementById(cont_name[0]+"lblFirst").innerHTML ="Select Main Department";
    document.getElementById(cont_name[0]+"lblSecond").innerHTML="Enter new Department";
    document.getElementById(cont_name[0]+"ddlGrade").style.display='none';

    
}

function ConfirmOnClick()
{
   if(document.getElementById(cont_name[0]+"rdDept").checked==true)
   {
       
      if(document.getElementById(cont_name[0]+"ddlMainDept").value==-1)
      {
            alert("Please Select Department.....!");
            return false;  
      }
      if(document.getElementById(cont_name[0]+"txtdpd").value=="")
      {
            alert("Please Enter Value.....!");
             return false;  
      }  
   } 
  if(document.getElementById(cont_name[0]+"rdPost").checked==true)
   {
   
      if(document.getElementById(cont_name[0]+"txtdpd").value=="")
      {
            alert("Please Enter Value.....!");
             return false;  
      } 
   }
 if(document.getElementById(cont_name[0]+"rdDes").checked==true)
  {   
    if(document.getElementById(cont_name[0]+"ddlGrade").value==-1)
      {
            alert("Please Select Grade.....!");
            return false;  
      }
      if(document.getElementById(cont_name[0]+"txtdpd").value=="")
      {
            alert("Please Enter Value.....!");
             return false;  
      }  
   
   }

}
function btnExit_onclick() 
{
    window.open('../home.aspx','_self');
}

</script>
    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 60%">
                <tr>
                    <td style="width: 20%; height: 25px">
                        <asp:RadioButton ID="rdDept" runat="server" Text="Department" onclick="CheckDep()" GroupName="dpd" /></td>
                    <td style="width: 20%; height: 25px">
                        <asp:RadioButton ID="rdPost" runat="server" GroupName="dpd"  Text="Post" onclick="CheckPost()" Width="123px" /></td>
                    <td style="width: 20%; height: 25px">
                        <asp:RadioButton ID="rdDes" runat="server" GroupName="dpd" onclick="CheckDes()" Text="Designation" /></td>
                </tr>
                <tr>
                    <td style="width: 20%; height: 25px">
                        <asp:Label ID="lblFirst" runat="server" Width="179px"></asp:Label></td>
                    <td style="height: 25px; text-align: left;" colspan="2">
                        <asp:DropDownList ID="ddlMainDept" runat="server" Width="226px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlGrade" runat="server" Width="224px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 20%; height: 25px">
                        <asp:Label ID="lblSecond" runat="server" Width="176px"></asp:Label></td>
                    <td style="height: 25px; text-align: left;" colspan="2">
                        <asp:TextBox ID="txtdpd" runat="server" Width="221px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 35px" colspan="3">
                        <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" Height="35px" />
                        <input id="btnExit" type="button" value="EXIT" style="width: 88px; height: 35px" onclick="return btnExit_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

