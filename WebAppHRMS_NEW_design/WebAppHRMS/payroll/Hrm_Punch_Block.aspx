<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Hrm_Punch_Block.aspx.vb" Inherits="WebAppHRMS.new_leave_Hrm_Leave_Status_a800cb2b9443" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont = master_no.split("cmb")

function Button2_onclick() 
{
    window.open('../home.aspx','_self')
}

function FillLeaveDetails()
{     data=document.getElementById(cont[0]+"cmb_Select").value;
      document.getElementById(cont[0]+"hid_emp").value=document.getElementById(cont[0]+"cmb_Select").value;
      data=data+"%"+111;
      ToServer(data+"#"+1,1);
      
}
function FromServer (arg,context) 
{ 
//debugger;
 var Data=arg.split("@")
 switch (context)
 { 
  case 1:          
        
        if(document.getElementById(cont[0]+"cmb_Select").value==0)
           {
               document.getElementById("row1").style.display="none";
               return false;
           }
         else
                          
         {         
         
           Data1=Data[0].split("~")
           arg1=Data1[0].split("!")    
                        
           document.getElementById(cont[0]+"Hidden1").value=Data[0];
           disp();
         
          }
        break;        
  case 2:
          alert(arg) ;
          window.open('Hrm_Punch_Block.aspx','_self')  ;
          break; 
  }      
}
function CheckLength(Control,MaxNum)
{      
     if(Control.value.length<=MaxNum)
       {return true;}
     else
     {alert("Only "+MaxNum +" Characters Allowed...!!!");
     return false;
     }
}


function disp()
{

    //debugger;
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cont[0]+"Hidden1").value=="")
    {  
        document.getElementById(cont[0]+"Panel1").innerHTML=""; 
        document.getElementById("row1").style.display="none";
        return;
    }
    st2=document.getElementById(cont[0]+"Hidden1").value.split("~")
    ar=st2.length-1;
    if(document.getElementById(cont[0]+"Hidden1").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("!")
            st1=st1+"<tr bgcolor='MistyRose'><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr bgcolor='#CCDDEE'><td><small><b>BRANCH NAME</b></td><td><small><b>POST</b></td><td><small><b>DEPARTMENT</b></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(cont[0]+"Panel1").innerHTML=st1;
}


function OnClickConfirm()
{
  var EmpCode=document.getElementById(cont[0]+"hid_emp").value;
  var Reason=document.getElementById(cont[0]+"txt_Reason").value;
  ToData = EmpCode+"%"+Reason;
  ToServer(ToData+"#"+2,2)
}
// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 40%">
            <tr>
                <td colspan="2">
                    Select Employee Code</td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="cmb_Select" onchange="FillLeaveDetails()" runat="server" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row1" style="display:none">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Enter Reason For Punch Block</td>
                <td style="text-align: left;" colspan="2">
                    <textarea id="txt_Reason" onkeypress="return CheckLength(this,'100')"  rows="2" style="text-transform:capitalize; font-size: 12pt; width: 246px; font-family: 'Times New Roman';" runat="server"></textarea></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="Button1"  onclick="OnClickConfirm()" style="font-weight: bold; font-size: 12pt; width: 81px; font-family: 'Times New Roman'"
                        type="button" value="Confirm" />&nbsp;
                    <input id="Button2" style="font-weight: bold; font-size: 12pt; width: 81px; font-family: 'Times New Roman'"
                        type="button" value="Exit" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
            </tr>
        </table>
    </div>
    <input id="Hidden1" runat="server" type="hidden" style="width: 4px" />
    <input id="hid_emp" runat="server" style="width: 8px" type="hidden" />
    &nbsp;
</asp:Content>

