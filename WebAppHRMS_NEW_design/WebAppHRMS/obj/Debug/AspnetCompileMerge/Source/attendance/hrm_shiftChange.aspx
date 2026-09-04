<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_shiftChange.aspx.vb" Inherits="WebAppHRMS.Shift_Change_hrm_shiftChange_c4120c359563" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('ddl');
function btnExit_onclick() 
{
  window.open('../home.aspx','_self');  
}
function detailDisplay()
{

    document.getElementById(con[0]+"Hidden1").value=document.getElementById(con[0]+"ddlEmpname").value;
    if(document.getElementById(con[0]+"Hidden1").value!=-1)
    {
        callserver("1$"+document.getElementById(con[0]+"Hidden1").value,1);  
    }
    else
    {
        document.getElementById(con[0]+"txtEname").value = "";
        document.getElementById(con[0]+"txtDep").value = "";
        document.getElementById(con[0]+"txtPost").value = "";  
        document.getElementById(con[0]+"txtDes").value = "";  
        document.getElementById(con[0]+"txtShift").value = "";  
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
        document.getElementById(con[0]+"txtEname").value = accdtl[0];
        document.getElementById(con[0]+"txtDep").value = accdtl[1];
        document.getElementById(con[0]+"txtPost").value = accdtl[2];  
        document.getElementById(con[0]+"txtDes").value = accdtl[3];  
        document.getElementById(con[0]+"txtShift").value = accdtl[4];     
        
         break;   
     }
     case 2:
     {
            alert(arg) ;
            window.open('hrm_shiftChange.aspx','_self');
            break;  
     } 
     
   }
}
function ShiftChange()
{    
    document.getElementById(con[0]+"Hidden2").value=document.getElementById(con[0]+"ddlShiftChange").value;
}
function conOnClick()
{
     if(document.getElementById(con[0]+"Hidden1").value ==-1)
    {
        alert("Please Select Employee Name");
        document.getElementById(con[0]+"ddlEmpname").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEname").value =="")
    {
        alert("Please Select Employee Name");
        document.getElementById(con[0]+"ddlEmpname").focus();
        return false;
    }
    if(document.getElementById(con[0]+"ddlShiftChange").value ==-1)
    {
        alert("Please Select New Shift");
        document.getElementById(con[0]+"ddlShiftChange").focus();
        return false;
    }
    var Flag=confirm("Are You Sure to Confirm");
   
    if (Flag==true)
    {
        callserver("2$"+document.getElementById(con[0]+"Hidden1").value+"$"+document.getElementById(con[0]+"Hidden2").value,2);  
    }
    if (Flag==false)
    {
        return false;
    }
}
// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="Hidden1" runat="server" /><asp:HiddenField ID="Hidden2" runat="server" />
        <table border="1" style="width: 80%">
            <tr>
                <td colspan="2">
                    Select Employee</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlEmpname" runat="server" Width="75%" onchange="detailDisplay()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 20%; text-align: left">
                    Name</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtEname" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 20%; text-align: left">
                    Department</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtDep" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%; text-align: left">
                    Post</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtPost" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 20%; text-align: left">
                    Designation</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txtDes" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 25px; text-align: left">
                    Shift</td>
                <td style="width: 20%; height: 25px">
                    <asp:TextBox ID="txtShift" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 20%; height: 25px; text-align: left">
                    Date</td>
                <td style="width: 20%; height: 25px">
                    <asp:TextBox ID="txtDate" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    Change Shift</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="ddlShiftChange" runat="server" Width="75%" onchange="ShiftChange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btnConfirm" type="button" value="CONFIRM" onclick="conOnClick()" />
                    <input id="btnExit" type="button" value="EXIT" onclick="return btnExit_onclick()" style="width: 90px; height: 24px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

