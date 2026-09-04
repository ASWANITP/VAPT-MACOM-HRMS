<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_leave_rec_sanmac.aspx.vb"
    Inherits="HRM_SECURITY_HRM_AllowanceUpdation_9a7f00b32376" Title="Leave Recommend/Sanction" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
        window.onload = callback;
        function callback() {
            return window_onload();
        }
// ]]>
    </script>

    <script language="javascript" type="text/javascript">
// <!CDATA[


function window_onload() 
{
debugger;
document.getElementById("rw1").style.display="none"
document.getElementById("panel_row").style.display="none";
document.getElementById("amount_row").style.display="none";
document.getElementById("date_row").style.display="none";
document.getElementById('<%= btn1.ClientID %>').style.display="none";
document.getElementById('<%= btn2.ClientID %>').style.display="none";
document.getElementById('<%= btn3.ClientID %>').style.display="none";
document.getElementById("del_row").style.display="none";
    /*document.getElementById("un_row").style.display="inline";*/
    let element = document.getElementById("un_row");
    if (element) {
        element.style.display = "inline";
    }
document.getElementById("del_row").style.display="none";
//document.getElementById(cs[0]+"chk_del").checked=false;
//document.getElementById(cs[0]+"chk_add").checked=false;
if (document.getElementById(cs[0]+"chk_del").checked==true)
ToServer("a#"+2,2);

if (document.getElementById(cs[0]+"chk_add").checked==true)
ToServer("a#"+1,2);
}



function chk_add1()
{
debugger;
if(document.getElementById(cs[0]+"chk_del").checked==true){
document.getElementById(cs[0]+"chk_del").checked= false;

document.getElementById('<%= btn2.ClientID %>').style.display="none";
}
if (document.getElementById(cs[0]+"chk_add").checked==true  && document.getElementById(cs[0]+"chk_del").checked==false)
{
document.getElementById('<%= btn1.ClientID %>').style.display="inline";
//document.getElementById('<%= btn2.ClientID %>').style.display="inline";
document.getElementById('<%= btn3.ClientID %>').style.display="inline"
////      document.getElementById(cs[0]+'Button3').style.visibility='visible';
      ToServer("a#"+1,2);
}
else if (document.getElementById(cs[0]+"chk_add").checked== false && document.getElementById(cs[0]+"chk_del").checked==false)
{
   document.getElementById(cs[0]+'Panel1').style.visibility='hidden';
//   location.reload();
}
else
{
document.getElementById(cs[0]+"chk_add").checked=false;


//document.getElementById(cs[0]+'Button3').style.visibility='hidden';
}
}



function selectalls()
{debugger;
var bool = document.getElementById('chksel').checked;

      st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
       if(bool == true)
         document.getElementById("chkm_"+i+"").checked=true;
         else
          document.getElementById("chkm_"+i+"").checked=false;
          

       }
     
       
}

        function selectall2() {
            debugger;
        var bool2 = document.getElementById('txtun').checked;
        st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
        if(bool2 == true)
            document.getElementById("chkun_"+i).checked = true;
         else
             document.getElementById("chkun_"+i).checked = false;
             }
             
}

function all_select()
{
if (document.getElementById(cs[0]+"chk_add").checked==true)
{
data=document.getElementById(cs[0]+"cmb_allowance").value;
if (data!=0)
{
      data=data+"%"+33;
      ToServer(data+"#"+2,2);
}
}
}


/////
function rejectbutton()
{
debugger;
var st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      var ajil=0;
      for(i=0;i<ar-1;i++)
       {
         if (document.getElementById("chkm_"+i+"").checked==true)
         ajil=1;
       }
if (ajil==0)
{
  alert("Please Select Any Leaves!!!")
  return false;
}


 var Flag=confirm("Are You Sure to Confirm");
  if (Flag==true)
  {
  document.getElementById(cs[0]+"Hidden4").value = ""; 
   
  if (document.getElementById(cs[0]+"hid_del").value !="")
   {  var st3 = "";
      st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
         st3=st2[i].split("*")
         if (document.getElementById("chkm_"+i+"").checked==true)  
         document.getElementById(cs[0]+"Hidden4").value += st2[i]+ "^" ; 
       }
    }
    var string =document.getElementById(cs[0]+"Hidden4").value;
    string = string.substring(0, string.length-1);
    var Dataa = string;
    //data=Dataa+"%"+44;
    ToServer(Dataa+"#"+3,2);
    }
   if (Flag==false)
  {
   return false;
  }
      //ToServer("a#"+3,2);

}

function sancbutton()
{
debugger;
var st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      var ajil=0;
      for(i=0;i<ar-1;i++)
       {
         if (document.getElementById("chkm_"+i+"").checked==true)
         ajil=1;
       }
if (ajil==0)
{
  alert("Please Select Any Leaves!!!")
  return false;
}


 var Flag=confirm("Are You Sure to Confirm");
  if (Flag==true)
  {
  document.getElementById(cs[0]+"Hidden4").value = ""; 
   
  if (document.getElementById(cs[0]+"hid_del").value !="")
   {  var st3 = "";
      st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
         st3=st2[i].split("*")
         if (document.getElementById("chkm_"+i+"").checked==true)  
         document.getElementById(cs[0]+"Hidden4").value += st2[i]+ "^" ; 
       }
    }
    var string =document.getElementById(cs[0]+"Hidden4").value;
    string = string.substring(0, string.length-1);
    var Dataa = string;
    //data=Dataa+"%"+44;
    ToServer(Dataa+"#"+4,4);
    }
   if (Flag==false)
  {
   return false;
  }
    
//      ToServer("a#"+4,2);

}
function recombutton()
{
debugger;
var st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      var ajil=0;
      for(i=0;i<ar-1;i++)
       {
         if (document.getElementById("chkm_"+i+"").checked==true)
         ajil=1;
       }
if (ajil==0)
{
  alert("Please Select Any Leaves!!!")
  return false;
}


var Flag=confirm("Are You Sure to Confirm");
  if (Flag==true)
  {
  document.getElementById(cs[0]+"Hidden4").value = ""; 
   
  if (document.getElementById(cs[0]+"hid_del").value !="")
   {  var st3 = "";
      st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
         st3=st2[i].split("*")
         if (document.getElementById("chkm_"+i+"").checked==true)  
         {
            if (document.getElementById("chkun_"+i+"").checked==true)
            {
               document.getElementById(cs[0]+"Hidden4").value += st2[i]+ "%Y^" ;
            }
            else
            {
               document.getElementById(cs[0]+"Hidden4").value += st2[i]+ "^" ;
            }
         }
       }
    }
    var string =document.getElementById(cs[0]+"Hidden4").value;
    string = string.substring(0, string.length-1);
    var Dataa = string;
    //data=Dataa+"%"+44;
    ToServer(Dataa+"#"+5,5);
    }
   if (Flag==false)
  {
   return false;
  }

//      ToServer("a#"+5,2);

}
//



function chk_del1()
{
if(document.getElementById(cs[0]+"chk_add").checked==true ){
document.getElementById(cs[0]+"chk_add").checked=false; 
document.getElementById('<%= btn1.ClientID %>').style.display="none";
}
debugger;
if (document.getElementById(cs[0]+"chk_del").checked==true  && document.getElementById(cs[0]+"chk_add").checked==false)
{
//document.getElementById('<%= btn1.ClientID %>').style.display="inline";
document.getElementById('<%= btn2.ClientID %>').style.display="inline";
document.getElementById('<%= btn3.ClientID %>').style.display="inline";
//      document.getElementById(cs[0]+'Button3').style.visibility='visible';
      ToServer("a#"+2,2);
      }
      else if (document.getElementById(cs[0]+"chk_add").checked== false && document.getElementById(cs[0]+"chk_del").checked==false)
{
      document.getElementById(cs[0]+'Panel1').style.visibility='hidden';
      location.reload();
      
}
else
{
document.getElementById(cs[0]+"chk_del").checked=false;
}
}
function all_select()
{
if (document.getElementById(cs[0]+"chk_del").checked==true)
{

data=document.getElementById(cs[0]+"cmb_allowance").value;
if (data!=0)
{
      data=data+"%"+33;
      ToServer(data+"#"+2,2);
}
}
}
function display_check()
{   debugger;

    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    var count=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cs[0]+"hid_del").value=="")
    {  
        document.getElementById("panel_row").style.display="none";  
        document.getElementById(cs[0]+"Panel1").innerHTML=""; 
        return;
    }
    st2=document.getElementById(cs[0]+"hid_del").value.split("!");
    ar=st2.length-1;
    if(document.getElementById(cs[0]+"hid_del").value!="")
    document.getElementById("hid_Counter").value=0
        
           
    {
        for(i=0;i<ar;i++)
       {
        document.getElementById("hid_Counter").value = Math.abs(document.getElementById("hid_Counter").value)+1;
        var coun=document.getElementById("hid_Counter").value;
        st3=st2[i].split("*");                                                                                                                                                                                       
        //st1=st1+"<tr  bgcolor='#CCDDEE'><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><a href='previous_deatils.aspx?code="+st3[0]+"&seq=" +st3[8]+ "'><small>MORE DETAILS</a></td>";
        if(document.getElementById("<%=chk_add.ClientID %>").checked == true){
        st1=st1+"<tr  bgcolor='#CCDDEE'><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><a href='#' onclick='newpage("+st3[0]+"," +st3[8]+ "," +st3[14]+ ",1)'><small>MORE DETAILS</a></td>";
        }
        else
        {
        st1=st1+"<tr  bgcolor='#CCDDEE'><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><a href='#' onclick='newpage("+st3[0]+"," +st3[8]+ "," +st3[15]+ ",2)'><small>MORE DETAILS</a></td>";
        }
        //st1=st1+"<tr  bgcolor='#CCDDEE'><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><a href='#' onclick='newpage("+st3[0]+"," +st3[8]+ "," +st3[14]+ ")'><small>MORE DETAILS</a></td>";
        if(document.getElementById("<%=chk_add.ClientID %>").checked == true){
        st1 += "<td><input type='checkbox' id='chkun_"+i+"' name='txtm_"+i+"'></td>";
        }else{
        st1+="<td><small>"+st3[14]+"</td>"          
        }
        st1+="<td><small><input type='checkbox' id='chkm_"+i+"' name='txtm_"+i+"'></td>";
        st1+="</tr>";
       }
        st=st+"<table id='mytable' border=1 style='width:200px; height:auto; text-align:left'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>&nbsp;EMP CODE&nbsp;</b><td><b>&nbsp;EMP NAME&nbsp;</b></td><td><b>&nbsp;LEAVE TYPE&nbsp;</b></td><td><b>&nbsp;FROM DATE &nbsp;</b><td><b>&nbsp;TO DATE &nbsp;</b></td><td><b>&nbsp;LEAVE DAYS &nbsp;</b></td><td><b>&nbsp;APPLY DATE</b></td><td><b>&nbsp;LEAVE REASON</b></td><td><b>&nbsp;PREVIOUS DETAILS </b>";
        
        if(document.getElementById("<%=chk_add.ClientID %>").checked == true){
        st+="<td><b>&nbsp;Uninformed <input type='checkbox' onclick='selectall2()' id='txtun' name='txtun_"+i+"'/></b>"
        }
        else{
        st+="<td><b>&nbsp;Remark</b></td>"
        }
        st+="<td><b>&nbsp;SELECT <input type='checkbox' onclick='selectalls()' id='chksel' name='txtm_"+i+"'/> </b>";
        
        st1=st+st1+tot+"</tr></table>" 
        document.getElementById("panel_row").style.display="table-row";  
    }
    document.getElementById(cs[0]+"Panel1").innerHTML=st1;
    //document.getElementById(cs[0]+"Panel1").style.height=30*ar;
}


function check_null()
{
    var arg;
    if(document.getElementById(cont[0]+"cmb_leave").options.length==0)
    {
    alert("NO LEAVE FOR REJECTION")
    return false;
    }
    else
    {  if((document.getElementById(cont[0]+"txt_name").value)!="")
        {  if((document.getElementById(cont[0]+"hid_rej").value)=="")
            {
            mywin=window.open("rej_res_ho.aspx", "WinC", "width=650,height=120,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            }
            else
            {
                 arg=2+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*pp*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
                 sub_call_server(arg,2);
                 return false;
            }  
        }
        else
        {
        alert("Select Employee");
        return false;
        } 
    }
}

function check_null2()
{
    var arg;
    if(document.getElementById(cont[0]+"cmb_leave").options.length==0)
    {
    alert("NO LEAVE FOR RECOMMEND")
    return false;
    }
    else
    {
        if((document.getElementById(cont[0]+"txt_name").value)!="")
        {
           
            if((document.getElementById(cont[0]+"hid_rej").value)=="")
            {
               mywin=window.open("rec_res_ho.aspx", "WinC", "width=650,height=120,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
               mywin.moveTo(200,300);
               return false;
            }
            else
            {
            if(document.getElementById(cont[0]+"Checkbox1").checked==true)
            {
             arg=3+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value+"*"+(document.getElementById(cont[0]+"txt_appdt").value).split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value;
            }
            else
            
            {
            arg=3+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+(document.getElementById(cont[0]+"txt_appdt").value).split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*"+document.getElementById(cont[0]+"hid_rej").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
            }
            //sreeeee
            sub_call_server(arg,3);
            return false;
        }  
        
        }
        else
        {
        alert("Select Employee");
        return false;
        } 
    }
}

function check_null1()
{
    var arg;
    if(document.getElementById(cont[0]+"cmb_leave").options.length==0)
    {
    alert("NO LEAVE FOR SANCTION")
    return false;
    }
    else
    {
        if((document.getElementById(cont[0]+"txt_name").value)!="")
        {
        
       //sreeeee
       if(document.getElementById(cont[0]+"Checkbox1").checked==true)
       {
        arg=1+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*pp*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value;
       }
       else
       {
       arg=1+"$"+document.getElementById(cont[0]+"hid_empcode").value+"*"+document.getElementById(cont[0]+"txt_name").value+"*"+document.getElementById(cont[0]+"txt_ltyp").value+"*"+document.getElementById(cont[0]+"txt_frdt").value+"*"+document.getElementById(cont[0]+"txt_todt").value+"*"+document.getElementById(cont[0]+"txt_dur").value+"*"+document.getElementById(cont[0]+"txt_appdt").value.split("-")[0]+"*"+document.getElementById(cont[0]+"txt_reason").value+"*"+document.getElementById(cont[0]+"hid_seq").value+"*"+document.getElementById(cont[0]+"txt_tot_mon").value+"*pp*"+document.getElementById(cont[0]+"txt_ParFrDt").value+"*"+document.getElementById(cont[0]+"txt_ParToDt").value+"*"+document.getElementById(cont[0]+"txt_par_days").value;
       }
       //sreeeee
        sub_call_server(arg,1);
        return false;
        }
        else
        {
        alert("Select Employee");
        return false;
        } 
    }
}


function Button2_onclick() 
{
alert(1);
window.open("../../home.aspx","_self")
}

var cs=loanno.split('txt')

function btn_okonclick() 
{   
    if(document.getElementById(cs[0]+"txt_code").value=="") 
    {
        alert('Please Enter Emp Code');
        document.getElementById(cs[0]+"txt_code").focus();
        return false;
    }
      document.getElementById("amount_row").style.display="inline";
      document.getElementById("date_row").style.display="inline";
      data=document.getElementById(cs[0]+"txt_code").value;
      data=data+"%"+22;
      ToServer(data+"#"+1,1);
       
}

function FromServer (arg,context) 
{
var Data = arg.split("@") ;             
       debugger;  
  if(context==1)
   {
    
            document.getElementById(cs[0]+"hidden1").value=arg;
            if (document.getElementById(cs[0]+"hidden1").value=="")
            {
               alert('No Details to Display');
               document.getElementById(cs[0]+"txt_code").focus();
               document.getElementById("amount_row").style.display="none";
               document.getElementById("date_row").style.display="none";
               
            }
            disp();
           
   }
   else if (context==2)
   {
               document.getElementById(cs[0]+"hid_del").value=arg;
            if (document.getElementById(cs[0]+"hid_del").value=="")
            {
            document.getElementById(cs[0]+'Panel1').innerHTML='';
               alert('No detalis ');
               document.getElementById("amount_row").style.display="none";
               document.getElementById("date_row").style.display="none";
               
            }
            if (document.getElementById(cs[0]+"chk_del").checked==true){
            document.getElementById('<%= btn2.ClientID %>').style.display="inline";
              document.getElementById('<%= btn3.ClientID %>').style.display="inline";
            display_check (); 
            }
             if (document.getElementById(cs[0]+"chk_add").checked==true)
             {
         document.getElementById('<%= btn1.ClientID %>').style.display="inline";
          document.getElementById('<%= btn3.ClientID %>').style.display="inline";
            display_check ();
            } 
                      
   }
   else if (context==3)
   {
        var msg
        if (arg!="")
        {
        msg=arg;
        }
        else
        {
        msg="Something went Wrong.. Try again";
        }
        alert("SUCCESSFULLY REJECTED");
   }
      else if (context==4)
   {
        var msg
        if (arg!="")
        {
        msg=arg;
        }
        else
        {
        msg="Something went Wrong.. Try again";
        }
        alert("SUCCESSFULLY SANCTIONED");
   }
      else if (context==5)
   {
        var msg
        if (arg!="")
        {
        msg=arg;
        }
        else
        {
        msg="Something went Wrong.. Try again";
        }
        alert("SUCCESSFULLY RECOMMENDED");
   }
   } 
function disp()
{   
    
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cs[0]+"hidden1").value=="")
    {  
        document.getElementById("panel_row").style.display="none";  
        document.getElementById(cs[0]+"Panel1").innerHTML=""; 
        return;
    }
    st2=document.getElementById(cs[0]+"hidden1").value.split("@")
    ar=st2.length-1;
    if(document.getElementById(cs[0]+"hidden1").value!="")
    {
        for(i=0;i<ar;i++)
        {
          st3=st2[i].split("!")                                                             
          st1=st1+"<tr  bgcolor='#CCDDEE'><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td></tr>"             
             
        }
        st=st+"<table border=1 style='width:1000; height: 36px; text-align:left'><tr  bgcolor='#CCCCEE' style='font-size:85%'><td><b>EMP CODE</b></td><td><b>NAME</b></td><td><b>POST</b></td><td><b>DESIGNATION</b></td><td><b>BRANCH</b></td></tr>"
        st1=st+st1+tot+"</table>" 
        document.getElementById("panel_row").style.display="table-row";  
    }
    document.getElementById(cs[0]+"Panel1").innerHTML=st1;
    //document.getElementById(cs[0]+"Panel1").style.height=30*ar;
}
function del(id)
{ 
  var at="";
  var rid;
  ar=document.getElementById(cs[0]+"hidden1").value.split("!")
  for (funi=0;funi<ar.length;funi++)
     {
      if(funi!=id)
       {
         if(at!="")
           {
            at=at+"!"+ar[funi]
           } 
          else
          {
           at=ar[funi]
          } 
        }
      }
   document.getElementById(cs[0]+"hidden1").value=at
   disp(document.getElementById(cs[0]+"hidden1").value)
   }
   
   
   
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
 if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32) || (charcode > 46 && charcode <58))
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

function Numberonly(Control)
{
     if (isNaN(document.getElementById(cs[0]+Control).value)) 
     {
        document.getElementById(cs[0]+Control).value="";
        return false; 
     }
}


function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cs[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");  
   document.getElementById(cs[0]+Control).value=document.getElementById(cs[0]+"hdn_sysdate").value;
  }
}





function delconfirm()
{debugger;
 var Flag=confirm("Are You Sure to Confirm");
  if (Flag==true)
  {
  document.getElementById(cs[0]+"Hidden4").value = ""; 
   
  if (document.getElementById(cs[0]+"hid_del").value !="")
   {  var st3 = "";
      st2=document.getElementById(cs[0]+"hid_del").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
         st3=st2[i].split("*")
         var Regular = "T";
         if (document.getElementById("chkm_"+i+"").checked==false)  Regular= "F";
         
         
         document.getElementById(cs[0]+"Hidden4").value += st3[0] + "^" ; 
       }
    }
    var Dataa = document.getElementById(cs[0]+"Hidden4").value;
    //data=Dataa+"%"+44;
    ToServer(data+"#"+3,3);
    }
   if (Flag==false)
  {
   return false;
  }
}

// ]]>
function newpage(code,seqn,auth,type)
{debugger;

if (auth=="100063" && type==1) 
{mywin=window.open("previous_deatils_rec.aspx?code="+code+"&seq="+seqn+"", "WinC", "width=700,height=520,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            } 
else if(auth=="100063" && type==2)

   {mywin=window.open("previous_deatils_san.aspx?code="+code+"&seq="+seqn+"", "WinC", "width=700,height=520,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            }

      else if(auth=="100188" && type==1)

   {mywin=window.open("previous_deatils_san.aspx?code="+code+"&seq="+seqn+"", "WinC", "width=700,height=520,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            }
     
          else if(auth=="100188" && type==2)

   {mywin=window.open("previous_deatils_san.aspx?code="+code+"&seq="+seqn+"", "WinC", "width=700,height=520,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            }

          
          
          
            
             
            else{
            mywin=window.open("previous_deatils.aspx?code="+code+"&seq="+seqn+"", "WinC", "width=700,height=520,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
            mywin.moveTo(200,300);
            return false;
            }
}
    </script>

    <div style="text-align: center; height: auto;" id="hidden84">
        <table border="1" style="width: 51%; height: 56px; text-align: left;border:unset;">
            <tr style="background-color: #CCCCEE;">
                <td colspan="2" style="text-align: center">
                    <asp:CheckBox ID="chk_add" runat="server" Text="RECOMMEND" Font-Bold="True" ForeColor="Black" /></td>
                <td colspan="2" style="text-align: center">
                    <asp:CheckBox ID="chk_del" runat="server" Text="SANCTION" Font-Bold="True" ForeColor="Black" /></td>
            </tr>
            <tr id="rw1">
                <td style="width: 20%; text-align: right;">
                </td>
                <td colspan="2" style="text-align: left">
                </td>
            </tr>

            <tr id="panel_row" style="display: none;">
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" Width="125px" >
                    </asp:Panel>
                </td>
            </tr>
            <tr id="amount_row" style="display: none;">
                <td style="width: 20%; text-align: right">
                    Amount&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_amount" onfocusout="Numberonly('txt_amount')" runat="server"
                        Width="181px" MaxLength="6" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <tr id="date_row" style="display: none;">
                <td style="width: 20%; text-align: right">
                    Effective Date&nbsp;
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_date" runat="server" Width="181px" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr id="del_row">
                <td colspan="3" style="text-align: center">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: center">
                    <%--<input id="Button2" runat="server" style="width: 65px" type="button" value="Exit" onclick="return Button2_onclick()" />--%>
                    <asp:Button ID="btn1" runat="server" Text="Recommend" Height="23px"  />
                    <asp:Button ID="btn2" runat="server" Text="Sanction" Height="24px"  />
                    <asp:Button ID="btn3" runat="server" Text="Reject" Height="24px"  />
                    <asp:Button ID="Button2" runat="server" Text="Exit" Height="24px"  />
                </td>
            </tr>
            <%--<tr id="un_row">
                <td style="height: 23px;" colspan="3">
                </td>
            </tr>--%>
        </table>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
            TargetControlID="txt_date">
        </cc1:CalendarExtender>
        <asp:HiddenField ID="hdn_sysdate" runat="server" />
        &nbsp; &nbsp;&nbsp;
        <input id="hid_key" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_Counter" style="width: 1px" type="hidden" />
        <input id="hid_del" runat="server" style="width: 1px" type="hidden" />
        <input id="Hidden4" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_rep" runat="server" style="width: 1px" type="hidden" />
        <input id="hidden1" runat="server" style="width: 1px" type="hidden" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
</asp:Content>

