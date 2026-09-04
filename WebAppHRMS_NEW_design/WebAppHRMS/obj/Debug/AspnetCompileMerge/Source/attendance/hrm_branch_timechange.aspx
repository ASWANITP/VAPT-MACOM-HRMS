<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_branch_timechange.aspx.vb" Inherits="WebAppHRMS.RajBranchTime_hrm_branch_timechange_06a3c2186712" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
    var cont_name=header.split('txt');
function btnExit_onclick() 
{
    window.open("../home.aspx","_self");
}
function classOnchange1()
{
   document.getElementById(cont_name[0]+"HiddenField2").value=document.getElementById(cont_name[0]+"ddl_changetime").value;
   if(document.getElementById(cont_name[0]+"ddl_changetime").value==-1)
   {
       document.getElementById(cont_name[0]+"txt_effdate").value='';
       
   }
}
function classOnchange()
{
   document.getElementById(cont_name[0]+"HiddenField1").value=document.getElementById(cont_name[0]+"ddl_branch").value;
   
   if(document.getElementById(cont_name[0]+"ddl_branch").value==0)
   {
       document.getElementById(cont_name[0]+"txt_start").value='';
       document.getElementById(cont_name[0]+"txt_end").value='';
       document.getElementById(cont_name[0]+"ddl_changetime").value=-1; 
        document.getElementById(cont_name[0]+"txt_effdate").value=''; 
   }
   if(document.getElementById(cont_name[0]+"ddl_branch").value!=0)
   {
              
      callserver("1$"+document.getElementById(cont_name[0]+"ddl_branch").value,1);  
    }
    
}
function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(cont_name[0]+"txt_effdate").value ='';
   return false;
}
function call_receiver(arg,context) 
{     
  switch (context)
  {
    case 1:
    {   
          
         var brtime = arg.split("*");              
         document.getElementById(cont_name[0]+"txt_start").value = brtime[0];
         document.getElementById(cont_name[0]+"txt_end").value = brtime[1];   
         
     }
   }
}
 function ConfirmOnClick()
 {
  if(document.getElementById(cont_name[0]+"ddl_branch").value==0)
   {
    alert("Please Select Branch.....!");
    return false;
   
   }
   if(document.getElementById(cont_name[0]+"ddl_changetime").value==-1)
   {
    alert("Please Select Time Shift.....!");
    return false;
   
   }
   if(document.getElementById(cont_name[0]+"txt_effdate").value=='')
   {
    alert("Please Select Date.....!");
    return false;
   
   }
 }
function check_date(Control)
{
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(cont_name[0]+Control).value!="")
    {
        var value1 = document.getElementById(cont_name[0]+Control).value;
        var dt = new Date().format("dd/MMM/yyyy");
        var value2=dt;
    
        day1= value1.substring (0, value1.indexOf ("/"));
        month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
        year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

        day2= value2.substring (0, value2.indexOf ("/"));
        month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
        year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);

        date1 = year1+"/"+month1+"/"+day1;
        date2 = year2+"/"+month2+"/"+day2;
    
        firstDate = Date.parse(date1)
        secondDate= Date.parse(date2)
   
        msPerDay = 24 * 60 * 60 * 1000
    
        dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
        if(dbd>0)
        {
            alert("Please Do Not Enter Earlier Date ..!!")
            document.getElementById(cont_name[0]+Control).value='';
            document.getElementById(cont_name[0]+Control).focus();
            return false;
        }
    }

 } 

function window_onload() 
{
   document.getElementById(cont_name[0]+"txt_start").value = '';
         document.getElementById(cont_name[0]+"txt_end").value = '';
         document.getElementById(cont_name[0]+"txt_effdate").value = '';
         
}

</script>
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_effdate">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2" style="height: 25px">
                    BRANCH ID &amp;NAME</td>
                <td colspan="2" style="height: 25px">
                    <asp:DropDownList ID="ddl_branch" runat="server"  onchange="return classOnchange()" Width="99%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%; height: 25px">
                    START TIME</td>
                <td style="width: 15%; height: 25px">
                    <asp:TextBox ID="txt_start" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 15%; height: 25px">
                    END TIME</td>
                <td style="width: 15%; height: 25px">
                    <asp:TextBox ID="txt_end" runat="server" Width="95%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 25px" colspan="2">
                    CHANGE TIMING</td>
                <td style="height: 23px" colspan="2">
                    <asp:DropDownList ID="ddl_changetime" runat="server" onchange="classOnchange1()" Width="99%" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 25px" colspan="2">
                    EFFECTIVE FROM</td>
                <td style="height: 25px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_effdate" runat="server" Width="70%" onkeyup="DateCheck()" onblur="check_date('txt_effdate')"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 31px">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" Height="28px" />
                    <input id="btnExit" type="button" value="EXIT" style="width: 88px; height: 28px" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

