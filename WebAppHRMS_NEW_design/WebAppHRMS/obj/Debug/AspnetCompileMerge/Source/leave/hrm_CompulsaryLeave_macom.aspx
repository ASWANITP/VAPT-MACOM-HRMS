
<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_CompulsaryLeave_macom.aspx.vb" Inherits="WebAppHRMS.Compulsary_Leave_hrm_CompulsaryLeave_12b9105a6682" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    document.getElementById("row1").style.display='none';
}
function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value = "";
   return false;
}

function check_date(Control)
  {
    document.getElementById("row1").style.display='none';
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
//function isNumeric()
//{
//     if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
//     {
//        document.getElementById(con[0]+"txtEcode").value="";
//        return false; 
//     }
//}

function isNumberKey(ids)
{ 
    var charcode = (event.which) ? event.which : event.keyCode
    if(ids==1)
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32))
        {
            return true;
        } 
        else
            return false;  
    }
    if(ids==2)
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32) ||(charcode > 46 && charcode <58))
        {
            return true;
        } 
        else
            return false;  
    }
    if(ids==3)    
    {
        if (charcode > 31 && (charcode < 48 || charcode > 57  ))
        {
            return false;
        } 
        else
            return true;  
    }
} 






function detailDisplay()
{
    document.getElementById("row1").style.display='none';
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
      document.getElementById("row1").style.display='none';
      document.getElementById("row2").style.display='none';
      document.getElementById("row3").style.display='none';
      document.getElementById("row4").style.display='table-row';
    }
    
    else  if (document.getElementById(con[0]+"cmb_type").value==1)
    {
      document.getElementById("row2").style.display='table-row';
      document.getElementById("row1").style.display='none';
      document.getElementById("row3").style.display='table-row';
            document.getElementById("row4").style.display='none';
    }
     
    else  if (document.getElementById(con[0]+"cmb_type").value==3)
    {
      document.getElementById("row2").style.display='none';
      document.getElementById("row1").style.display='none';
      document.getElementById("row3").style.display='table-row';
        document.getElementById("row4").style.display='none';
    }
    else
    {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='none';
        document.getElementById("row3").style.display='none';
        document.getElementById("row4").style.display='none';
    }
    
    
}
function show()
{debugger;
    document.getElementById(con[0]+"chkMor").checked=false;
    document.getElementById(con[0]+"chkEve").checked=false;
    document.getElementById(con[0]+"chk_lop1").checked=false;
    document.getElementById(con[0]+"chk_lop2").checked=false;
    
      if(document.getElementById(con[0]+"cmb_type").value==4)
       {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='table-row';
        document.getElementById("row3").style.display='none';
        document.getElementById("row4").style.display='table-row';
       }
 
        else
    {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='none';
        document.getElementById("row3").style.display='none';
        document.getElementById("row4").style.display='none';
    }
       }
       
       
       
       function showother()
       {
    document.getElementById(con[0]+"chkMor").checked=false;
    document.getElementById(con[0]+"chkEve").checked=false;
    document.getElementById(con[0]+"chk_lop1").checked=false;
    document.getElementById(con[0]+"chk_lop2").checked=false;
    
       
        if(document.getElementById(con[0]+"cmb_type").value==4)
       {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='table-row';
        document.getElementById("row3").style.display='table-row';
        document.getElementById("row4").style.display='table-row';
       }
       
        else
    {
        document.getElementById("row2").style.display='none';
        document.getElementById("row1").style.display='none';
        document.getElementById("row3").style.display='none';
        document.getElementById("row4").style.display='none';
    }}
  
function btnExit_onclick() 
{
    window.open("../../Home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
              <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtDate" runat="server">
                </cc1:CalendarExtender>
                <table border="1" style="width: 60%; border:unset;">
                    <tr>
                        <td colspan="2">
                            Enter Emp. Code</td>
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txtEcode" runat="server" onblur="detailDisplay()"  onkeypress="return isNumberKey(3)"  MaxLength="6" Width="70%"></asp:TextBox></td>
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
                            <asp:TextBox ID="txtDate" runat="server" onkeyup="DateCheck()" onblur="check_date('txtDate')" Width="71%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Select Type :
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:DropDownList ID="cmb_type" runat="server" Width="214px" onchange="return hiderow()">
                                <asp:ListItem Value="0">---SELECT TYPE---</asp:ListItem>
                                <asp:ListItem Value="1">COMPULSORY LEAVE</asp:ListItem>
                                <asp:ListItem Value="2">LATE</asp:ListItem>
                                <asp:ListItem Value="3">EARLY GOING</asp:ListItem>
                                <asp:ListItem Value="4">REGULARISE</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr id="row4">
                        <td colspan="2" style="text-align: right">
                          <input id="CheckBox1" runat="server" name="t" type="radio" onclick= "return show()"/>
                            FORGOT or LATE</td>
                         <td colspan="2" style="text-align: left">
                          <input id="CheckBox2" runat="server" name="t" type="radio" onclick= "return showother()"/>
                            TECHNICAL ISSUE</td>
                    </tr>
                        
                        
                       <%-- <asp:CheckBox ID="CheckBox1" runat="server" Text="FORGOT"  onclick= "return show()"/></td>--%>
                       <%-- <td colspan="2" style="text-align: left">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="OTHER"  onclick= "return showother()"/></td>--%>
                    
                    <tr id="row1">
                        <td colspan="2" style="text-align: right">
                            <asp:CheckBox ID="chkMor" runat="server" Text="MORNING"  /></td>
                        <td colspan="2" style="text-align: left">
                            <asp:CheckBox ID="chkEve" runat="server" Text="EVENING"  /></td>
                    </tr>
                    <tr id="row2">
                        <td colspan="2" style="text-align: right">
                            <input id="chk_lop1" runat="server" name="t" type="radio" />
                            1 LOP</td>
                        <td colspan="2" style="text-align: left">
                            <input id="chk_lop2" runat="server" name="t" type="radio" />
                            2 LOP</td>
                    </tr>
                    <tr id="row3">
                        <td colspan="2" style="text-align: right">
                            Remarks :
                        </td>
                        <td colspan="2" style="text-align: left">
                            <input id="txt_remarks" runat="server" maxlength="50" style="width: 281px" type="text" /></td>
                    </tr>
                     
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnConfirm" runat="server" Width="88px" OnClientClick="return OnConClick()" Text="CONFIRM" />
                               <asp:Button ID="btnExit" runat="server" Width="88px" OnClientClick="return btnExit_onclick()" Text="EXIT" />      
                          <%--<input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" />--%>
                            </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>



