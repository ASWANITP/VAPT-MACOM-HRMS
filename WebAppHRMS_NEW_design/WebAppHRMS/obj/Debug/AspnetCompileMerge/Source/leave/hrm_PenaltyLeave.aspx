<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_PenaltyLeave.aspx.vb" Inherits="WebAppHRMS.Compulsary_Leave_hrm_CompulsaryLeave_12b9105a9704" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
//return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

//function window_onload()
//{
//    document.getElementById("row1").style.display='none';
//}
function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value = "";
   return false;
}

function check_date(Control)
  {
    //document.getElementById("row1").style.display='none';
    var day1, day2;
    var month1, month2;
    var year1, year2;
    if(document.getElementById(con[0]+Control).value!="")
    {
        var value1 = document.getElementById(con[0]+Control).value;
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
        if(dbd<0)
        {
            alert("Please Do Not Enter Future Date ..!!")
            document.getElementById(con[0]+Control).value='';
            document.getElementById(con[0]+Control).focus();
            return false;
        }
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


function isNumericDays()
{
     if (isNaN(document.getElementById(con[0]+"txt_Days").value)) 
     {
        document.getElementById(con[0]+"txt_Days").value="";
        return false; 
     }
}



function detailDisplay()
{
    //document.getElementById("row1").style.display='none';
 if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        return false; 
     }
     if(document.getElementById(con[0]+"txtEcode").value=="")
     {
         document.getElementById(con[0]+"txtEname").value = "";
         document.getElementById(con[0]+"txtBranch").value = "";  
         document.getElementById(con[0]+"txtPost").value = "";
         document.getElementById(con[0]+"txtDes").value = "";  
         document.getElementById(con[0]+"txtDate").value = "";   
         return false; 
    }
    if(document.getElementById(con[0]+"txtEcode").value!="")
    {
        callserver("1$"+document.getElementById(con[0]+"txtEcode").value,1);  
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
            alert("Please Enter Valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = "";
            document.getElementById(con[0]+"txtBranch").value = "";  
            document.getElementById(con[0]+"txtPost").value = "";
            document.getElementById(con[0]+"txtDes").value = "";  
            document.getElementById(con[0]+"txtDate").value = "";           
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtEname").value = accdtl[0];
            document.getElementById(con[0]+"txtBranch").value=accdtl[1];
            document.getElementById(con[0]+"txtPost").value = accdtl[2];
            document.getElementById(con[0]+"txtDes").value = accdtl[3];  
            document.getElementById(con[0]+"txtDate").value = "";      
         } 
         break;   
     }
  }
}

function OnConClick()
{
    if(document.getElementById(con[0]+"txtEcode").value=="")
    {
        alert("Please Enter Employee Code...!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEname").value=="")
    {
        alert("Please Enter Employee Code...!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Select Date...!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
}
function hiderow()
{
    document.getElementById(con[0]+"chkMor").checked=false;
    document.getElementById(con[0]+"chkEve").checked=false;
    document.getElementById(con[0]+"chk_lop1").checked=false;
    document.getElementById(con[0]+"chk_lop2").checked=false;
    
    if (document.getElementById(con[0]+"cmb_type").value==4)
    {
      document.getElementById("row1").style.display='inline';
      document.getElementById("row2").style.display='none';
      document.getElementById("row3").style.display='none';
    }
    
    else  if (document.getElementById(con[0]+"cmb_type").value==1)
    {
      document.getElementById("row2").style.display='inline';
      document.getElementById("row1").style.display='none';
      document.getElementById("row3").style.display='inline';
    }
    else
    {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='none';
        document.getElementById("row3").style.display='none';
    }
    
    
}
function btnExit_onclick() 
{
    window.open("../Home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager><table border="1" style="width: 60%;border:unset;">
                    <tr>
                        <td colspan="4">
                            <strong>PENALTY LEAVE</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Enter Emp. Code</td>
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txtEcode" runat="server" onblur="detailDisplay()" onkeypress="isNumeric()"  MaxLength="6" Width="70%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 5%; text-align: left;">
                            Name</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">
                            Branch</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 5%; text-align: left;">
                            Post</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtPost" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">
                            Designation</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtDes" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Select Date</td>
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txtDate" runat="server" onkeyup="DateCheck()" onblur="check_date('txtDate')" Width="72%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            Enter Leave Days</td>
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txt_Days" runat="server" onkeypress="isNumericDays()" Width="211px"></asp:TextBox></td>
                    </tr>
                    <tr id="row3">
                        <td colspan="2" style="text-align: center">
                            Remarks&nbsp;
                        </td>
                        <td colspan="2" style="text-align: left">
                            <input id="txt_remarks" runat="server" maxlength="50" style="width: 281px" type="text" /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnConfirm" runat="server" OnClientClick="return OnConClick()" Text="CONFIRM" />
                            <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

