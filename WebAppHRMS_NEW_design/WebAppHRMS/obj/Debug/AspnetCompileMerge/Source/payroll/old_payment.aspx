<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="old_payment.aspx.vb" Inherits="WebAppHRMS.Individual_Indiv_payment_03fcc1784685" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
  <script type="text/javascript">
var cont=cont_name.split("txt")
function visib_false()
{
  document.getElementById("pan").style.display="none"
 }

function disp()
{
 var ar,con,arr,tab,at,head,tot,tail;
 var str="";
   
 ar=document.getElementById(cont[0]+"hid_value").value.split("*");
 con=ar.length;
 tot=0;
 document.getElementById(cont[0]+"hid_sal").value=0;
 document.getElementById(cont[0]+"hid_ta").value=0;
 for(i=0;i<con;i++)
 {
    arr=ar[i].split("~")
    if(arr[2]==0)
      {
        document.getElementById(cont[0]+"hid_sal").value=arr[1];
      }
     else
      {
        document.getElementById(cont[0]+"hid_ta").value=parseFloat(document.getElementById(cont[0]+"hid_ta").value)+parseFloat(arr[1]);
      }
    if(str=="")
    {
     str="<tr><td align=left Font size=2>"+arr[0]+"</td><td align=right>"+arr[1]+"</td><td><a href=javascript:desp('" +arr[2] + "')><input id="+arr[2]+" type=checkbox Disabled=disabled>Click Here</td></td></tr>"
     tot=parseFloat(tot)+parseFloat(arr[1]);
    }
    else
    {
      str=str+"<tr><td align=left>"+arr[0]+"</td><td align=right>"+arr[1]+"</td><td><a href=javascript:desp('" +arr[2] + "')><input id="+arr[2]+" type=checkbox Disabled=disabled>Click Here</td></tr>"
      tot=parseFloat(tot)+parseFloat(arr[1]);
    }
 }
 tab="<table border=1 width=422px><tr><td><b>TYPE</b></td><td><b>AMOUNT</b></td><td><b>STATUS</b></td></tr>"
 head="<tr><td><b>SPLIT UP AMOUNT</b></td></tr>"
 tail="<tr><td><b>TOTAL</b></td><td align=right><b>"+tot+"</b></td><td><b></b></td></tr>"
 document.getElementById(cont[0]+"hid_tot").value=tot
 at=head+tab+str+tail+"</table>"
 document.getElementById(cont[0]+"panel1").innerHTML=at 
}
function cmd_generate_onclick()
{
  if((document.getElementById(cont[0]+"txt_eMPCODE").value)=="")
  {
   return false
  }
 //alert(document.getElementById(cont[0]+"hid_value").value)
 if(document.getElementById(cont[0]+"hid_value")!="")
  {
   disp()
   document.getElementById("verify").style.display="inline"
  }
  else
  {
   alert("Nothing to Generate")
   return false
  }
}
function desp(id)
{
 if(document.getElementById(id).checked==false)
  {
    document.getElementById(id).checked=true
  }  
 else
  {
   document.getElementById(id).checked=false
  } 
}
//window.onload=visib_false()
function Button1_onclick() 
{
  var i;
  i=confirm("Are you really want to Exit")
  if(i==true) 
  {
    window.open("../home.aspx",'_self')
  }
  else
  {
   return false;
  }  
}
function check_fill()
{
 var ar,con,arr,tot,i;
 ar=document.getElementById(cont[0]+"hid_value").value.split("*");
 con=ar.length;
 tot=0;
 for(i=0;i<con;i++)
 {
   arr=ar[i].split("~")
   if((document.getElementById(arr[2]).checked)==false)
    {
     tot=1;
     alert("Verify "+arr[0]+".If it is not correct inform HRM")
     return false;
    }
    
 }
 i=confirm("Are you really want to Confirm")
  if(i==true) 
  {
    return true;
  }
  else
  {
   return false;
  }   
}
function Button3_onclick()
{
var i;
  i=confirm("Are you really want to Exit")
  if(i==true) 
  {
    window.open("../home.aspx",'_self')
  }
  else
  {
   return false;
  }  
}

function Button4_onclick()
{
 if((document.getElementById(cont[0]+"txt_eMPCODE").value)!="")
   {
     window.open("salstatement_individ_report.aspx?empcode="+document.getElementById(cont[0]+"txt_eMPCODE").value)
   } 
}

</script>
    <div style="text-align: center">
        &nbsp;</div>
    <div style="text-align: center">
        <table border="1" style="width: 342px; height: 159px">
            <tr>
                <td colspan="3">
                    <strong>OLD&nbsp; EMPLOYEE SAL /TA VERIFICATION</strong></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Width="354px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 238px; text-align: left">
                    EmpCode</td>
                <td colspan="2">
                    <input id="txt_eMPCODE" runat="server" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 238px; text-align: left">
                    EmpName</td>
                <td colspan="2">
                    <input id="txt_eMPNAME" runat="server" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="cmd_generate" style="width: 103px; height: 25px" type="button" value="Generate" onclick="return cmd_generate_onclick()" /></td>
                <td style="width: 100px">
                    <input id="Button3" style="width: 75px" type="button" value="Exit" onclick="return Button3_onclick()" />
                    <input id="hid_sal" runat="server" style="width: 1px" type="hidden" /></td>
            </tr>
            <tr id="pan">
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" Height="10px" Width="460px">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </asp:Panel>
                </td>
            </tr>
            <tr id="verify" style="display:none">
                <td style="width: 238px; height: 15px;">
                    <input id="hid_value" runat="server" style="width: 1px" type="hidden" />
                    <input id="hid_ta" runat="server" style="width: 1px" type="hidden" />
                    <asp:Button ID="Button2" runat="server" Text="Verify" Width="109px"  OnClientClick="return check_fill()"/>
                    </td>
                <td style="width: 100px; height: 15px;">
                    <input id="Button5" style="width: 89px" type="button" value="Print" onclick="return Button4_onclick()" />
                    </td>
                <td style="width: 100px; height: 15px;">
                    <input id="Button6" style="width: 80px" type="button" value="Exit" onclick="return Button1_onclick()" />
                    <input id="hid_tot" runat="server" style="width: 1px" type="hidden" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

