<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_resignemp_data.aspx.vb" Inherits="WebAppHRMS.Resigned_Emp_hrm_resignemp_data_259137708795" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function isNumeric()
{
     if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        document.getElementById(con[0]+"txtCode").value = ""; 
        document.getElementById(con[0]+"txtName").value = "";
        document.getElementById(con[0]+"txtRdate").value = "";
        document.getElementById(con[0]+"txtDdate").value = "";
        document.getElementById(con[0]+"txtReason").value = "";
        return false; 
     }
}
function detailDisplay()
{
     if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        document.getElementById(con[0]+"txtCode").value = ""; 
        document.getElementById(con[0]+"txtName").value = "";
        document.getElementById(con[0]+"txtRdate").value = "";
        document.getElementById(con[0]+"txtDdate").value = "";
        document.getElementById(con[0]+"txtReason").value = "";
        return false; 
     }
     if(document.getElementById(con[0]+"txtEcode").value=="")
     {
           
         document.getElementById(con[0]+"txtCode").value = ""; 
         document.getElementById(con[0]+"txtName").value = "";
         document.getElementById(con[0]+"txtRdate").value = "";
         document.getElementById(con[0]+"txtDdate").value = "";
         document.getElementById(con[0]+"txtReason").value = "";
             
         return false; 
    }
    if(document.getElementById(con[0]+"txtEcode").value!="")
    {
        callserver("1$"+document.getElementById(con[0]+"txtEcode").value,1);  
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
            document.getElementById(con[0]+"txtCode").value = ""; 
            document.getElementById(con[0]+"txtName").value = "";
            document.getElementById(con[0]+"txtRdate").value = "";
            document.getElementById(con[0]+"txtDdate").value = "";
            document.getElementById(con[0]+"txtReason").value = "";             
            return false;
         }
         else if (accdtl=="This Employee is not in Resigned Status")
         {
            alert("This Employee is not in Resigned Status");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtCode").value = ""; 
            document.getElementById(con[0]+"txtName").value = "";
            document.getElementById(con[0]+"txtRdate").value = "";
            document.getElementById(con[0]+"txtDdate").value = "";
            document.getElementById(con[0]+"txtReason").value = "";             
            return false;
         }
         else if(accdtl=="NULL")
         {
            alert("Please Select valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = ""; 
            document.getElementById(con[0]+"txtCode").value = ""; 
            document.getElementById(con[0]+"txtName").value = "";
            document.getElementById(con[0]+"txtRdate").value = "";
            document.getElementById(con[0]+"txtDdate").value = "";
            document.getElementById(con[0]+"txtReason").value = "";             
            return false; 
         }
         else
         {
            document.getElementById(con[0]+"txtCode").value = accdtl[0];
            document.getElementById(con[0]+"txtName").value = accdtl[1];
            document.getElementById(con[0]+"txtRdate").value = accdtl[2];
            document.getElementById(con[0]+"txtDdate").value = accdtl[3];
            document.getElementById(con[0]+"txtReason").value = accdtl[4];
         } 
         break;   
     }
  }
}

    function btnExit_onclick() {
        window.open("../../Home.aspx", "_self");
    }

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 80%; font-family: 'Courier New';">
                <tr>
                    <td colspan="2">
                        Enter Employee Code</td>
                    <td colspan="2" style="text-align: left">
                        <asp:TextBox ID="txtEcode" runat="server" onblur="detailDisplay()" onkeypress="isNumeric()" MaxLength="7" Width="60%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left;">
                        Employee Code</td>
                    <td style="width: 15%; text-align: left;">
                        <asp:TextBox ID="txtCode" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                    <td style="width: 15%; text-align: left;">
                        Employee Name</td>
                    <td style="width: 15%; text-align: left;">
                        <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; height: 22px;">
                        Resig. Enter Date</td>
                    <td style="width: 15%; height: 22px; text-align: left;">
                        <asp:TextBox ID="txtRdate" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                    <td style="width: 15%; height: 22px;">
                        Dis.Continue Date</td>
                    <td style="width: 15%; height: 22px; text-align: left;">
                        <asp:TextBox ID="txtDdate" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        Reason</td>
                    <td style="text-align: left;" colspan="2">
                        <asp:TextBox ID="txtReason" runat="server" ReadOnly="True" Width="98%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input id="btnExit" type="button" value="EXIT" style="width: 82px" onclick="return btnExit_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

