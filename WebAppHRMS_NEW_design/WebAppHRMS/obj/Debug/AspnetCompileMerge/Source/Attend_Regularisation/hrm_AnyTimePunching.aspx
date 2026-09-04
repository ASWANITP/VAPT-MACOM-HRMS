<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_AnyTimePunching.aspx.vb" Inherits="WebAppHRMS.AnyTimePunching_New_hrm_AnyTimePunching_fd4356312934" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
 window.open('../home.aspx','_self')
}
var cont = master_no.split("hid");

function disp()
{   

   //debugger;
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    var count=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cont[0]+"Hidden1").value=="")
    {  
        document.getElementById("panel_row").style.display="none";  
        document.getElementById(cont[0]+"Panel1").innerHTML=""; 
        return;
    }
    st2=document.getElementById(cont[0]+"Hidden1").value.split("!");
    ar=st2.length-1;
    if(document.getElementById(cont[0]+"Hidden1").value!="")
    document.getElementById("hid_Counter").value=0
        
           
    {
        for(i=0;i<ar;i++)
       {
        document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value)+1;
        var coun=document.getElementById("hid_Counter").value;
        st3=st2[i].split("*");                                                                                                                                                                                        //onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL" onclick=chek('chk_"+i+"')<a href=javascript:chkk('" + i + "')>
        st1=st1+"<tr  bgcolor='MistyRose'><td><small>"+coun+"</td><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><input type='checkbox' id='chkm_"+i+"' name='txtm_"+i+"'></td><td><input type='textbox' id='txt_"+i+"' name='txt_"+i+"' style='text-transform:capitalize' maxlength='100'></td></tr>"          
       }
        st=st+"<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>SLNO</b></td><td><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;DESIGNATION&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;PUNCHING&nbsp;TIME&nbsp;&nbsp;</b></td><td><b>&nbsp;ACTUAL&nbsp;TIME&nbsp;&nbsp;</b></td><td><b>&nbsp;MARK IF REGULARISING ONLY </b></td><td><b>REMARKS</b></td></tr>"
        st1=st+st1+tot+"</table>" 
        document.getElementById("panel_row").style.display="inline";  
    }
    document.getElementById(cont[0]+"Panel1").innerHTML=st1;
}
function window_onload() 

{
  
   if(document.getElementById(cont[0]+"Hidden3").value!="")
     {
      
       document.getElementById(cont[0]+"Hidden1").value=document.getElementById(cont[0]+"Hidden3").value;
       disp();
     }
   else
     {alert("No Details!!!");window.open('../home.aspx','_self');return false;}
}
function FromServer (arg,context) 
{ 
//debugger;
 var Data=arg.split("@")
 switch (context)
 {               
  case 1:
          alert(arg) ;
          window.open('../home.aspx','_self')  ;
          break; 
  }      
}

function onclickconfirm()
{
 //debugger;
 var Flag=confirm("Are You Sure to Confirm");
  if (Flag==true)
  {
  document.getElementById(cont[0]+"Hidden4").value = ""; 
   
  if (document.getElementById(cont[0]+"Hidden1").value !="")
   {  var st3 = "";
      st2=document.getElementById(cont[0]+"Hidden1").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
         st3=st2[i].split("*")
         var Regular = "T";
         if (document.getElementById("chkm_"+i+"").checked==false)  Regular= "F";
         if (document.getElementById("txt_"+i+"").value =="")  Remarks= "NIL";
//         if (document.getElementById("chkm_"+i+"").checked==true || document.getElementById("txt_"+i+"").value =="")  { alert("Please Enter Remarks ") ; document.getElementById("txt_"+i+"").focus(); return false;}   
         else
         {Remarks = document.getElementById("txt_"+i+"").value;}
         document.getElementById(cont[0]+"Hidden4").value += st3[0] + "^" +st3[1] + "^" +st3[2] + "^" +st3[3] + "^" +Regular + "^" +Remarks + "$" ; 
       }
    }
    var Dataa = document.getElementById(cont[0]+"Hidden4").value;
    var UserID=document.getElementById(cont[0]+"hid_sre").value;
    var BrID=document.getElementById(cont[0]+"hid_br").value;
    if (document.getElementById(cont[0]+"txt_complaint").value=="")
    {var ComplaintID=0 }     
    else
    {var ComplaintID=document.getElementById(cont[0]+"txt_complaint").value;}
    data=Dataa+"%"+UserID+"%"+BrID+"%"+ComplaintID+"%"+111;
    ToServer(data+"#"+1,1);
   }
   if (Flag==false)
  {
   return false;
  }
}


function isNumberKey()
{ //debugger;
 var charcode = (event.which) ? event.which : event.keyCode 
 
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))
  {
    return false;
  } 
    else
     return true;  
 
     
} 
// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 40%; height: 154px;">
            <tr>
                <td colspan="4" style="height: 46px">
                    Please Contact HO for Complaint Registration</td>
            </tr>
            <tr id="panel_row">
                <td style="height: 46px;" colspan="4">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
               <td colspan="2">
                   Hard&nbsp;Ware&nbsp;Complaint&nbsp;Number</td>
                    <td style="text-align: left;" colspan="2">
                        <asp:TextBox ID="txt_complaint" runat="server" Width="215px" MaxLength="13"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 17px;" colspan="4">
                    <input id="Button1" onclick="onclickconfirm()" style="font-size: 12pt; width: 97px; font-family: 'Times New Roman'"
                        type="button" value="CONFIRM" />&nbsp;
                    <input id="Button2" style="font-size: 12pt; width: 96px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
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
            <tr>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
            </tr>
        </table>
        <div style="text-align: left">
            &nbsp;</div>
    </div>
    <input id="hid_branch" runat="server" style="width: 13px" type="hidden" />
    <input id="Hidden3" runat="server" style="width: 17px" type="hidden" />
    <input id="hid_sre" runat="server" type="hidden" style="width: 15px" />
    <input id="Hidden1" runat="server" type="hidden" style="width: 11px" />
    <input id="hid_Counter" type="hidden" style="width: 42px" />
    <input id="Hidden4" runat="server" type="hidden" style="width: 35px" />
    <input id="hid_br" runat="server" type="hidden" />
</asp:Content>

