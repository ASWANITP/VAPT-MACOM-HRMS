<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_AnyTimePunch_RH.aspx.vb" Inherits="WebAppHRMS.AnyTimePunching_New_hrm_AnyTimePunch_RH_671e60db5367" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("hid");


function Button2_onclick() 
{
 window.open('../home.aspx','_self')
}
function FillEmployDetails()
{     
      data=document.getElementById(cont[0]+"cmb_Branch").value;
      var kk=document.getElementById(cont[0]+"cmb_Branch").options[document.getElementById(cont[0]+"cmb_Branch").selectedIndex].text
      Dt=kk.split("~")     
      ReqDt=Dt[1];
      document.getElementById(cont[0]+"hid_ReqDT").value=Dt[1];        
      document.getElementById(cont[0]+"hid_br").value=document.getElementById(cont[0]+"cmb_Branch").value;
      data=data+"%"+ReqDt+"%"+111;
      ToServer(data+"#"+1,1);      
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
    st2=document.getElementById(cont[0]+"Hidden1").value.split("!")
    ar=st2.length-1;
    if(document.getElementById(cont[0]+"Hidden1").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[5] +"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><input type='checkbox' id='chkm_"+k+"' name='txtm_"+k+"'></td><td><input type='textbox' id='txt_"+k+"' name='txt_"+k+"' style='text-transform:capitalize' maxlength='100'></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>DESIGNATION</b></td><td><small><b>PUNCHING&nbsp;TIME</b></td><td><small><b>ACTUAL&nbsp;TIME</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REASON&nbsp;&nbsp;&nbsp;</b></td><td><small><b>AM RECOMMENDED REASON</b></td><td><small><b>RM RECOMMENDED REASON</b></td><td><small><b>MARK IF RECOMMENDING ONLY</b></td><td><small><b>REMARKS&nbsp;IF&nbsp;ANY</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(cont[0]+"Panel1").innerHTML=st1;
}

function disp1()
{

    //debugger;
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cont[0]+"Hidden5").value=="")
    {  
        document.getElementById(cont[0]+"Panel2").innerHTML=""; 
        document.getElementById("row2").style.display="none";
        return;
    }
    st2=document.getElementById(cont[0]+"Hidden5").value.split("!")
    ar=st2.length-1;
    if(document.getElementById(cont[0]+"Hidden5").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[4] +"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP CODE</b></td><td><small><b>EMP NAME</b></td><td><small><b>DESIGNATION</b></td><td><small><b>PUNCHING TIME</b></td><td><small><b>ACTUAL TIME</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row2").style.display="inline";  
    document.getElementById(cont[0]+"Panel2").innerHTML=st1;
}

function FromServer (arg,context) 
{ 
//debugger;
 var Data=arg.split("@")
 switch (context)
 { 
  case 1:        
        
        if(document.getElementById(cont[0]+"cmb_Branch").value==0)
           {
               document.getElementById("row1").style.display="none";
               document.getElementById("row2").style.display="none";
               return false;
           }
         else
         {                    
         document.getElementById(cont[0]+"Hidden1").value=Data[0];
         document.getElementById(cont[0]+"Hidden5").value=Data[1];
         disp(); 
         disp1();  
                       
        }
      break;  
  case 2:
          alert(arg) ;
          window.open('hrm_AnyTimePunch_RH.aspx','_self');
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
         if (document.getElementById("txt_"+i+"").value =="")  {alert("Please Enter Remarks");document.getElementById("txt_"+i+"").focus();return false;}
//         if (document.getElementById("chkm_"+i+"").checked==true || document.getElementById("txt_"+i+"").value =="")  { alert("Please Enter Remarks ") ; document.getElementById("txt_"+i+"").focus(); return false;}   
         else
         {Remarks = document.getElementById("txt_"+i+"").value;}
         document.getElementById(cont[0]+"Hidden4").value += st3[0] + "^" +st3[1] + "^" +st3[2] + "^" +st3[3] + "^" +st3[4]+ "^" +Regular + "^" +Remarks + "$" ; 
       }
    }
    var Dataa = document.getElementById(cont[0]+"Hidden4").value;
    var UserID=document.getElementById(cont[0]+"hid_sre").value;
    var BrID=document.getElementById(cont[0]+"hid_br").value;
    var ReqDT=document.getElementById(cont[0]+"hid_ReqDT").value;
    data=Dataa+"%"+UserID+"%"+BrID+"%"+ReqDT+"%"+112;
    ToServer(data+"#"+2,2);
   }
   if (Flag==false)
  {
   return false;
  }
}
// ]]>
</script>

    <div style="text-align: center">
        <input id="hid_ReqDT" runat="server" type="hidden" />
        <table border="1" style="width: 40%">
            <tr>
                <td colspan="2">
                    Select Branch</td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="cmb_branch" onchange="FillEmployDetails()" runat="server" Width="330px" Font-Names="Times New Roman" Font-Size="Medium">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row1" style="display:none">
                <td colspan="4" style="height: 50px">
                    <span style="color: #ff0033; text-decoration: underline">Late Punching Employee Details</span><asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="row2" style="display:none">
                <td colspan="4" rowspan="2">
                    <span style="color: #ff0033; text-decoration: underline">Normal Punching Employee Details</span><asp:Panel ID="Panel2" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="4" style="height: 15px">
                    <input id="Button1"  onclick="onclickconfirm()" style="font-size: 12pt; width: 91px; font-family: 'Times New Roman'"
                        type="button" value="CONFIRM" />
                    &nbsp;
                    <input id="Button2" style="font-size: 12pt; width: 88px; font-family: 'Times New Roman'"
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
    <input id="hid_sre" runat="server" style="width: 9px" type="hidden" />
    <input id="Hidden1" runat="server" type="hidden" style="width: 4px" />
    <input id="Hidden5" runat="server" type="hidden" style="width: 12px" />
    <input id="hid_br" runat="server" style="width: 11px" type="hidden" />
    <input id="Hidden4" runat="server" type="hidden" style="width: 3px" />
    <input id="hid_area" runat="server" type="hidden" />
</asp:Content>

