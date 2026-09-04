<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="leave_appli_to_mageeth.aspx.vb" Inherits="WebAppHRMS.macom_shift_change_leave_appli_to_mageeth_da50c7f93658" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script type="text/javascript">
var cont=loanno.split("txt")
function proc_leave()
{
  var id;
  id=document.getElementById(cont[0]+"cmb_ltype").value;
   clear_all()
  if (id==1)
   {
   if((document.getElementById(cont[0]+"txt_lcasual").value)==0 || (document.getElementById(cont[0]+"txt_lcasual").value)<0 ) 
     {
      alert("You have no Casual Leave to Apply")
      document.getElementById(cont[0]+"cmb_ltype").value=0;
      return  false;
     }
   }  
  else if(id==2)
   {
   if((document.getElementById(cont[0]+"txt_lsick").value)==0 || (document.getElementById(cont[0]+"txt_lsick").value)<0 ) 
     {
      alert("You have no Sick Leave to Apply")
      document.getElementById(cont[0]+"cmb_ltype").value=0;
      return  false;
     }  
    } 
  else if(id==3)
   {
   if((document.getElementById(cont[0]+"txt_learned").value)==0 || (document.getElementById(cont[0]+"txt_learned").value)<0 ) 
     {
          alert("You have no Earned Leave to Apply")
          document.getElementById(cont[0]+"cmb_ltype").value=0;
          return  false;
     }    
   }
   else if(id==8)
   {
   if((document.getElementById(cont[0]+"Text1").value)==0 || (document.getElementById(cont[0]+"Text1").value)<0 ) 
     {
          alert("You have no Onam Leave to Apply")
          document.getElementById(cont[0]+"cmb_ltype").value=0;
          return  false;
     }    
   }
  else if(id==9)
   {
   if((document.getElementById(cont[0]+"Text2").value)==0 || (document.getElementById(cont[0]+"Text2").value)<0 ) 
     {
          alert("You have no Christmas Leave to Apply")
          document.getElementById(cont[0]+"cmb_ltype").value=0;
          return  false;
     }    
   }
   else if(id==11)
   {
   if((document.getElementById(cont[0]+"Text3").value)==0 || (document.getElementById(cont[0]+"Text3").value)<0 ) 
     {
          alert("You have no Vacation Leave to Apply")
          document.getElementById(cont[0]+"cmb_ltype").value=0;
          return  false;
     }    
   }
  else
   return true;   
 }
 
  function checkradio()
 {debugger;
 document.getElementById(cont[0]+"txt_lfdt").value="";
 document.getElementById(cont[0]+"txt_ltodt").value="";
   if (document.getElementById(cont[0]+"CheckBox1").checked==true)
   {
     document.getElementById(cont[0]+"Hidden1").value="1";
   }
   else if (document.getElementById(cont[0]+"CheckBox2").checked==true)
   {
     document.getElementById(cont[0]+"Hidden1").value="2";
   }
   else if (document.getElementById(cont[0]+"CheckBox3").checked==true)
   {
     document.getElementById(cont[0]+"Hidden1").value="3";
   }
   else
   {
     document.getElementById(cont[0]+"Hidden1").value="0";
   }
 }
 
 function check_dt()
 {debugger;
  alert("Select Date From Calender")
  return false;
 }
 function error_dt()
 {debugger;
   var arg;
   if((document.getElementById(cont[0]+"cmb_ltype").value)==0)
    {
     alert("Select Leave type");
     clear_all();
     return false;
    }
   if((document.getElementById(cont[0]+"txt_lfdt").value)!="")
     {
       if((document.getElementById(cont[0]+"txt_ltodt").value)!="")
         {
            if (document.getElementById(cont[0]+"Hidden1").value=="0")
            {
                alert("Please choose duration category!");
				clear_all();
                return false;
            }
            else
            {
                arg=8+"$"+document.getElementById(cont[0]+"txt_lfdt").value+"$"+document.getElementById(cont[0]+"txt_ltodt").value+"$"+document.getElementById(cont[0]+"cmb_ltype").value+"$"+document.getElementById(cont[0]+"Hidden1").value;
                sub_call_server(arg,1);
            }
        }
     }
     else
     {
       alert("Select From Date")
       document.getElementById(cont[0]+"txt_ltodt").value="";
       return false;
     } 
 }
 function sub_call_receiver(arg1,arg2)
{debugger;
 var ar,ar1,ar2,cnt;
 ar=arg1.split("^^")
 if(arg2==1)
 {
    if(ar[0]=="NO")
    {
     alert("HALF DAY LEAVE CAN BE APPLIED FOR ONE DAY ONLY");
     clear_all();
     return  false;
    }
    if(ar[0]==0)
    {
     alert("Check Date Selection")
     clear_all();
     return  false;
    }
   if(ar[0]==-1)
    {
     alert("Long Leave Limit is 9 Days")
     clear_all();
     return  false;
    } 
    document.getElementById(cont[0]+"txt_ldays").value=ar[1];
  
 }
 else if(arg2==2)
 {
 debugger;
 
            var ar;
            var ar1;
            if((document.getElementById(cont[0]+"cmb_category").value)!=0) 
             {
                ar=arg1.split("**")
                document.getElementById(cont[0]+"cmb_reason").options.length=0
                var option1=document.createElement("OPTION")
                 for(a=1;a<ar.length-1;a++)
                 { 
                   ar1=ar[a].split("%%")
                   var option1=document.createElement("OPTION")
                   option1.text=ar1[1]
                   option1.value=ar1[0]
                   document.getElementById(cont[0]+"cmb_reason").add(option1)
                 }
//                 if(document.getElementById(cont[0]+"cmb_category").value==6)
//                 {
//                   var option1=document.createElement("OPTION")
//                   option1.text="OTHERS"
//                   option1.value=999
//                   document.getElementById(cont[0]+"cmb_reason").add(option1);
//                 } 


                  document.getElementById("tr2222").style.display="inline";
                document.getElementById("Tr2").style.display="none"; 


 
              }
             else
             { 
             if((document.getElementById(cont[0]+"cmb_category").value)==0) 
             {
             document.getElementById("tr2222").style.display="none";
             document.getElementById("Tr2").style.display="inline";
             }
              
              
              
              
              
             else
             { 
                   document.getElementById(cont[0]+"cmb_reason").options.length=0
                   var option1=document.createElement("OPTION")
                   option1.text="--Select--"
                   option1.value=0;
                   document.getElementById(cont[0]+"cmb_reason").add(option1);
              
             }    
 
 }
 
}
}
function clear_all()
{
     document.getElementById(cont[0]+"txt_lfdt").value="";
     document.getElementById(cont[0]+"txt_ltodt").value="";
     document.getElementById(cont[0]+"txt_ldays").value="";
     document.getElementById(cont[0]+"Hidden1").value="0";
     document.getElementById(cont[0]+"CheckBox1").checked=false;
     document.getElementById(cont[0]+"CheckBox2").checked=false;
     document.getElementById(cont[0]+"CheckBox3").checked=false;
}
function fill_res()
{
   var arg;
         arg=9+"$"+document.getElementById(cont[0]+"cmb_category").value;
         sub_call_server(arg,2);
}


function check_con()
{
debugger;
  var arg,val;
  if((document.getElementById(cont[0]+"cmb_ltype").value)==0)
   {
        alert("Select leave Type")
        return false;
   }
  if((document.getElementById(cont[0]+"txt_lfdt").value)=="")
   {
        alert("Enter From Date")
        return false;
   }
   if((document.getElementById(cont[0]+"txt_ltodt").value)=="")
   {
        alert("Enter To Date")
        return false;
   }
   if((document.getElementById(cont[0]+"txt_ldays").value)=="")
   {
        alert("Leave Days is Null")
        return false;
   }
   if((document.getElementById(cont[0]+"cmb_category").value)=="")
   {
        alert("Select Category")
        return false;
   }
   
   if((document.getElementById(cont[0]+"cmb_category").value)==0 &&  (document.getElementById(cont[0]+"txt_oth_reason").value)=="") 
   {
        alert("Please enter leave reason")
        return false;
   }
//   if((document.getElementById(cont[0]+"cmb_category").value)==-1 &&  (document.getElementById(cont[0]+"cmb_reason").value)==1) 
//   {
//        alert("Please select one category")
//        return false;
//   }

   
   if((document.getElementById(cont[0]+"cmb_category").value)==0)
   {
        document.getElementById(cont[0]+"cmb_reason").value=0;
   }
   
//   if((document.getElementById(cont[0]+"cmb_category").value)==-1)
//   {
//        document.getElementById(cont[0]+"cmb_reason").value=0;
//   }
   
   
   
   
   
//    if((document.getElementById(cont[0]+"txt_oth_reason").value)<=100)
//   {
//        alert("Max. limit is 100")
//        return false;
//   }
//   
//   if((document.getElementById(cont[0]+"txt_oth_reason").value)="")
//   {
//        alert("Enter Reason")
//        return false;
//   }
//   

// if (document.getElementById(cont[0]+"txt_oth_reason").value == "") {
//    alert("Enter Reason");
//    return false;
//}


// if((document.getElementById(cont[0]+"cmb_category").value)=0) && ((document.getElementById(cont[0]+"txt_oth_reason").value)=="")
//   {
//        alert("Enter Reason")
//        return false;
//   }
//   






//   if((document.getElementById(cont[0]+"cmb_reason").value)==0)
//   {
//        alert("Select Reason")
//        return false;
//   }
  
   
   
   
   
   
   
  arg=document.getElementById(cont[0]+"txt_ecode").value+"#"+document.getElementById(cont[0]+"cmb_ltype").value+"#"+document.getElementById(cont[0]+"txt_ldays").value+"#"+document.getElementById(cont[0]+"txt_lfdt").value+"#"+document.getElementById(cont[0]+"txt_ltodt").value+"#"+document.getElementById(cont[0]+"txt_lappdt").value+"#"+document.getElementById(cont[0]+"cmb_category").value+"#"+val+"#"+document.getElementById(cont[0]+"cmb_reason").value;
  document.getElementById(cont[0]+"hid_val").value=arg
 
  }
  
  
  
function Button2_onclick() 
{
  window.open("../home.aspx",'_self')
}
function chky()
{
    if(document.getElementById(cont[0]+"Chk_yes").checked==true)
    {
        document.getElementById("cr3").style.display="inline";
        document.getElementById(cont[0]+"Chk_yes").checked=true
        document.getElementById(cont[0]+"Chk_no").checked=false
        document.getElementById(cont[0]+"Chk_1st").style .visibility ="visible";
        document.getElementById(cont[0]+"Chk_1st").checked=true
        document.getElementById(cont[0]+"Chk_2").style .visibility ="visible";
        document.getElementById(cont[0]+"Chk_3").style .visibility ="visible";
        document.getElementById(cont[0]+"Chk_4").style .visibility ="visible";
        document.getElementById(cont[0]+"Chk_5").style .visibility ="visible";
        document.getElementById(cont[0]+"file_support1").style .visibility ="visible";
        document.getElementById("cr1").style.display="inline"
        document.getElementById("cr2").style.display="inline"
        document.getElementById("cr3").style.display="inline"
        document.getElementById("cr4").style.display="inline"
        document.getElementById("cr5").style.display="inline"
    }
    else
    {
        document.getElementById("cr3").style.display="none";
        document.getElementById(cont[0]+"Chk_yes").checked=false
        document.getElementById(cont[0]+"Chk_no").checked=true
        document.getElementById(cont[0]+"file_support1").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support2").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support3").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support4").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support5").style .visibility ="hidden";
    }

}
function chkn()
{
    if(document.getElementById(cont[0]+"Chk_no").checked==true)
    {
        document.getElementById("cr3").style.display="none";
        document.getElementById(cont[0]+"Chk_yes").checked=false
        document.getElementById(cont[0]+"Chk_no").checked=true
        document.getElementById(cont[0]+"file_support1").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support2").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support3").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support4").style .visibility ="hidden";
        document.getElementById(cont[0]+"file_support5").style .visibility ="hidden";
    }
    else
    {
        document.getElementById("cr3").style.display="inline";
        document.getElementById(cont[0]+"Chk_yes").checked=true
        document.getElementById(cont[0]+"Chk_no").checked=false
        document.getElementById(cont[0]+"file_support1").style .visibility ="visible";
        document.getElementById(cont[0]+"file_support2").style .visibility ="visible";
        document.getElementById(cont[0]+"file_support3").style .visibility ="visible";
        document.getElementById(cont[0]+"file_support4").style .visibility ="visible";
        document.getElementById(cont[0]+"file_support5").style .visibility ="visible";
    }
}

function window_onload() 
{
    document.getElementById("cr1").style.display="none"
    document.getElementById("cr2").style.display="none"
    document.getElementById("cr3").style.display="none"
    document.getElementById("cr4").style.display="none"
    document.getElementById("cr5").style.display="none"
    document.getElementById("Tr2").style.display="none"
    document.getElementById(cont[0]+"Chk_1st").style .visibility ="hidden";
    document.getElementById(cont[0]+"Chk_2").style .visibility ="hidden";
    document.getElementById(cont[0]+"Chk_3").style .visibility ="hidden";
    document.getElementById(cont[0]+"Chk_4").style .visibility ="hidden";
    document.getElementById(cont[0]+"Chk_5").style .visibility ="hidden";

    document.getElementById(cont[0]+"file_support1").style .visibility ="hidden";
    document.getElementById(cont[0]+"file_support2").style .visibility ="hidden";
    document.getElementById(cont[0]+"file_support3").style .visibility ="hidden";
    document.getElementById(cont[0]+"file_support4").style .visibility ="hidden";
    document.getElementById(cont[0]+"file_support5").style .visibility ="hidden";
    
    document.getElementById(cont[0]+"Chk_1st").checked=false;
    document.getElementById(cont[0]+"Chk_2").checked=false;
    document.getElementById(cont[0]+"Chk_3").checked=false;
    document.getElementById(cont[0]+"Chk_4").checked=false;
    document.getElementById(cont[0]+"Chk_5").checked=false;
    document.getElementById(cont[0]+"Chk_no").checked=true;
    document.getElementById(cont[0]+"Chk_yes").checked=false;

}
function seup()
{
    if(document.getElementById(cont[0]+"Chk_1st").checked==true)
    {
    document.getElementById(cont[0]+"file_support1").style .visibility ="visible";
    }
    else
    {
    document.getElementById(cont[0]+"file_support1").style .visibility ="hidden";
    }

    if(document.getElementById(cont[0]+"Chk_2").checked==true)
    {
    document.getElementById(cont[0]+"file_support2").style .visibility ="visible";
    }
    else
    {
    document.getElementById(cont[0]+"file_support2").style .visibility ="hidden";
    }
    if(document.getElementById(cont[0]+"Chk_3").checked==true)
    {
    document.getElementById(cont[0]+"file_support3").style .visibility ="visible";
    }
    else
    {
    document.getElementById(cont[0]+"file_support3").style .visibility ="hidden";
    }
    if(document.getElementById(cont[0]+"Chk_4").checked==true)
    {
    document.getElementById(cont[0]+"file_support4").style .visibility ="visible";
    }
    else
    {
    document.getElementById(cont[0]+"file_support4").style .visibility ="hidden";
    }
    if(document.getElementById(cont[0]+"Chk_5").checked==true)
    {
    document.getElementById(cont[0]+"file_support5").style .visibility ="visible";
    }
    else
    {
    document.getElementById(cont[0]+"file_support5").style .visibility ="hidden";
    }

}
function show_oth_reas()
{
    if((document.getElementById(cont[0]+"cmb_reason").value)==999) 
    {
        document.getElementById("rrow").style.display="inline";
        document.getElementById(cont[0]+"txt_oth_reason").focus();
    }
    else
    {
        document.getElementById("rrow").style.display="none";
    }
}


</script>
    <div style="text-align: center">
       
        <table border="1" style="width: 656px; height: 72px">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>LEAVE
                        APPLICATION</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 24px">
                    <asp:Label ID="Label1" runat="server" Width="610px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Code</span></td>
                <td style="width: 100px; height: 7px; text-align: center;">
                    <input id="txt_ecode" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Name</span></td>
                <td style="width: 100px; height: 7px; text-align: center;">
                    <input id="txt_ename" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Designation</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <input id="txt_edesig" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Department</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <input id="txt_edep" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 16px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Post</span></td>
                <td style="width: 100px; height: 16px; text-align: center;">
                    <input id="txt_epost" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 16px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Current&nbsp;branch</span></td>
                <td style="width: 100px; height: 16px; text-align: center;">
                    <input id="txt_ebr" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Join&nbsp;Date</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <input id="txt_ejoindt" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Type</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <input id="txt_etype" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 1px; text-align: center">
                    <span style="font-family: Courier New"><strong style="font-size: 13pt">LEAVE&nbsp;DETAILS</strong></span></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-family: Courier New; font-size: 12pt;"><strong>Eligible&nbsp;Leaves</strong></span></td>
                <td style="width: 100px; height: 1px; text-align: right">
                    <div style="text-align: center" id="clrow" runat="server">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <span style="font-size: 11pt; font-family: Courier New">Casual</span></td>
                                <td style="width: 100px">
                                    <input id="txt_lcasual" style="width: 31px; height: 16px;"
                        type="text" readonly="readOnly" runat="server" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 100px; height: 1px; text-align: right">
                    <span style="font-size: 11pt; font-family: Courier New">
                       
                        <div style="text-align: center" id="vrow" runat="server">
                           <table>
                                <tr>
                                    <td style="width: 100px; height: 26px">
                                        Vacation</td>
                                    <td style="width: 100px; height: 26px">
                                        <input id="Text3" style="width: 29px; height: 18px;"
                        type="text" readonly="readOnly" runat="server" /></td>
                                </tr>
                            </table>
                            
                        </div>
                    </span></td>
                    

                    
                    
                    
                   </tr> 
                    <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-family: Courier New; font-size: 12pt;"><strong></strong></span></td>
                <td style="width: 100px; height: 1px; text-align: right">
                    <div style="text-align: center" id="orow" runat="server" >
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <span style="font-size: 11pt; font-family: Courier New">Onam</span></td>
                                <td style="width: 100px">
                                    <input id="Text1" style="width: 31px; height: 16px;"
                        type="text" readonly="readOnly" runat="server" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width: 100px; height: 1px; text-align: right">
                    <span style="font-size: 11pt; font-family: Courier New">
                        <div style="text-align: center" id="crow" runat="server">
                        
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        Christmas</td>
                                    <td style="width: 100px">
                                        <input id="Text2" style="width: 31px; height: 16px;"
                        type="text" readonly="readOnly" runat="server" /></td>
                                </tr>
                            </table>
                            </div>
                    </span>
  </td>
                    </tr>
                    
                    
    <%--</TR>--%><tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Leave&nbsp;Type</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <asp:DropDownList ID="cmb_ltype" runat="server" Width="123px" style="font-family: 'Courier New'" Onchange="return proc_leave()">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">CASUAL </asp:ListItem>
                        <asp:ListItem Value="2">SICK</asp:ListItem>
                        <asp:ListItem Value="3">EARNED</asp:ListItem>
                        <asp:ListItem Value="4">LOP</asp:ListItem>
                        <asp:ListItem Value="10">MATERNITY</asp:ListItem>
                    </asp:DropDownList></td>
                    
                    
                    
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Applied&nbsp;Date</span></td>
                <td style="width: 100px; height: 1px; text-align: center;">
                    <input id="txt_lappdt" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
       <%--  ------   --%>
           
            
           
           
           
            
            <tr>
            <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Duration&nbsp;Category</span></td>
                <td style="width: 200px; height: 7px; text-align: center">
                    <input id="CheckBox1" onclick="checkradio()" runat="server" name="t" type="radio" />
                            First Half</td>
                <td style="width: 200px; height: 7px; text-align: center">
                    <input id="CheckBox2" onclick="checkradio()" runat="server" name="t" type="radio" />
                           Second Half</td>
                            <td style="width: 200px; height: 7px; text-align: center">
                    <input id="CheckBox3" onclick="checkradio()" runat="server" name="t" type="radio" />
                            Full Day</td>
            </tr>
            
            
            
            
            
            
            
            
            
<%-- --- --%>    
            
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">From&nbsp;date </span>
                </td>
                <td style="width: 100px; height: 1px; text-align: left;">
                    <asp:TextBox ID="txt_lfdt" runat="server" Width="117px" onkeypress="return check_dt()" OnChange="return error_dt()" style="font-family: 'Courier New'"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_lfdt">
                    </cc1:CalendarExtender>
                    </td>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">To&nbsp;Date</span></td>
                <td style="width: 100px; height: 1px; text-align: left;">
                    <asp:TextBox ID="txt_ltodt" runat="server" Width="117px" onkeypress="return check_dt()" OnChange="return error_dt()" style="font-family: 'Courier New'"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Days</span></td>
                <td style="height: 1px; text-align: left;" colspan="3">
                    <input id="txt_ldays" style="width: 117px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly" /></td>
            </tr>
    <tr>
        <td style="width: 100px; height: 1px; text-align: left">
            <span style="font-size: 11pt; font-family: Courier New">Select&nbsp;Catagory</span></td>
        <td colspan="3" style="height: 1px; text-align: left">
            <asp:DropDownList ID="cmb_category" runat="server" Width="350px" style="font-size: 11pt; font-family: 'Courier New'" OnChange="return fill_res()">
            </asp:DropDownList></td>
    </tr>
            <tr id ="tr2222">
                <td style="width: 100px; height: 1px; text-align: left">
                    <span style="font-family: Courier New; font-size: 11pt;">Reason</span></td>
                <td colspan="3" style="height: 1px; text-align: left">
                <%--    <asp:DropDownList ID="DropDownList1" runat="server" Width="350px" style="font-size: 11pt; font-family: 'Courier New'" onchange="return show_oth_reas()">--%>
                    <asp:DropDownList ID="cmb_reason" runat="server" Width="350px" style="font-size: 11pt; font-family: 'Courier New'" >
                    </asp:DropDownList></td>
            </tr>
                    <%--<tr id="rrow" style="display:none">--%>
                    
                    <tr id="Tr2" >
                    
                        <td style="width: 100px; height: 1px; text-align: left">
                            <span style="font-size: 10pt; font-family: Courier New">Enter Reason</span>(Max. limit 100)</td>
                        <td colspan="3" style="height: 1px; text-align: left">
                            <input id="txt_oth_reason" maxlength="80" style="width: 343px" type="text" runat="server" /></td>
                            
                          <%-- <td colspan="3" style="height: 1px; text-align: left">
                            <input id="Text4" maxlength="80" style="width: 343px" type="text" runat="server" /></td>  
                            --%>
                            
                            
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 1px; text-align: left">
                            <span style="font-size: 10pt; font-family: Courier New">If Any Supportings</span></td>
                        <td colspan="3" style="height: 1px; text-align: left">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:CheckBox ID="Chk_yes" onclick="chky()" runat="server" Font-Names="Courier New" Text="Yes" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:CheckBox ID="Chk_no" onclick="chkn()" runat="server" Checked="True" Font-Names="Courier New"
                                Text="No" /></td>
                    </tr>
                    <tr id="cr3" style="display:none">
                        <td colspan="4" style="height: 1px; text-align: left">
                            <table border="0" style="width: 650px; height: 17px" id="tb1">
                                <tr id="cr1">
                                    <td style="width: 1258px; height: 1px; text-align: left">
                                        <span style="font-size: 10pt; color: #ff0033; font-family: Courier New">
                                            <asp:CheckBox ID="chk_1st" onclick="seup()" runat="server" Text="1st Supporting File" ForeColor="#000099" /></span></td>
                                    <td colspan="3" style="height: 1px; text-align: left; width: 548px;">
                                        <asp:FileUpload ID="file_support1" runat="server" Width="446px" BackColor="Snow" ForeColor="Black" /></td>
                                </tr>
                            </table><table border="0" style="width: 650px; height: 17px" id="tb2">
                                <tr id="cr2" >
                                    <td style="width: 1258px; height: 1px; text-align: left">
                                        <span style="font-size: 10pt; color: #ff0033; font-family: Courier New">
                                            <asp:CheckBox ID="chk_2" onclick="seup()" runat="server" Text="2nd Supporting File" ForeColor="#000099" /></span></td>
                                    <td colspan="3" style="height: 1px; text-align: left; width: 548px;">
                                        <asp:FileUpload ID="file_support2" runat="server" Width="446px" BackColor="Snow" /></td>
                                </tr>
                            </table>
                            <table border="0" style="width: 650px; height: 17px" id="tb3">
                                <tr id="Tr1">
                                    <td style="width: 1258px; height: 1px; text-align: left">
                                        <span style="font-size: 10pt; color: #ff0033; font-family: Courier New">
                                            <asp:CheckBox ID="Chk_3" onclick="seup()" runat="server" Text="3rd Supporting File" ForeColor="#000099" /></span></td>
                                    <td colspan="3" style="height: 1px; text-align: left; width: 548px;">
                                        <asp:FileUpload ID="file_support3" runat="server" Width="446px" BackColor="Snow" /></td>
                                </tr>
                            </table>
                            <table border="0" style="width: 650px; height: 17px" id="tb4">
                                <tr id="cr4">
                                    <td style="width: 1258px; height: 1px; text-align: left">
                                        <span style="font-size: 10pt; color: #ff0033; font-family: Courier New">
                                            <asp:CheckBox ID="Chk_4" onclick="seup()" runat="server" Text="4th Supporting File" ForeColor="#000099" /></span></td>
                                    <td colspan="3" style="height: 1px; text-align: left; width: 548px;">
                                        <asp:FileUpload ID="file_support4" runat="server" Width="446px" BackColor="Snow" /></td>
                                </tr>
                            </table>
                            <table border="0" style="width: 650px; height: 17px" id="tb5">
                                <tr id="cr5">
                                    <td style="width: 1258px; height: 1px; text-align: left">
                                        <span style="font-size: 10pt; color: #ff0033; font-family: Courier New">
                                            <asp:CheckBox ID="Chk_5" onclick="seup()" runat="server" Text="5th Supporting File" ForeColor="#000099" /></span></td>
                                    <td colspan="3" style="height: 1px; text-align: left; width: 548px;">
                                        <asp:FileUpload ID="file_support5" runat="server" Width="446px" BackColor="Snow" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 1px; text-align: left">
                            <input id="hid_val" runat="server" style="width: 1px" type="hidden" />
                            <input id="Hidden1" runat="server" style="width: 1px" type="hidden" /></td>
                    </tr>
            <tr>
                <td colspan="2" style="height: 1px; text-align: right;">
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="APPLY" Width="77px"  OnClientClick="return check_con()" Height="27px"/>
                </td>
                <td style="height: 1px; text-align: left" colspan="2">
                    <input id="Button2" style="width: 69px; height: 27px;" type="button" value="EXIT" onclick="return Button2_onclick()" />
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_ltodt">
                    </cc1:CalendarExtender>
                </td>
            </tr>
 <%--   </TBODY></TABLE> </DIV><cc1:calendarextender id="CalendarExtender1" runat="server"
        format="dd/MMM/yyyy" targetcontrolid="txt_lfdt"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
        targetcontrolid="txt_ltodt"></cc1:calendarextender>--%>
        </TABLE>
    </div>
</asp:Content>


