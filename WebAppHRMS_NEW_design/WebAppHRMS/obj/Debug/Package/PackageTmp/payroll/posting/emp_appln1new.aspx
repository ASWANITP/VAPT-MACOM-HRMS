<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="emp_appln1new.aspx.vb" Inherits="WebAppHRMS.payroll_posting_emp_appln1_77b999515466" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split("txt")
function Button1_onclick() 
{
    window.open('../../home.aspx','_self')
}

function string1(a) 
{
    var v
    v=document.getElementById("ctl00_cph_edp_"+a).value
    document.getElementById("ctl00_cph_edp_"+a).value=v.toUpperCase()
    document.getElementById("ctl00_cph_edp_"+a).focus();
}
function check_null()
{
    alert("Select Date From Calender")
    return  false;
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


function setval()
{
document.getElementById(cont[0]+"hid_emp").value =  document.getElementById(cont[0]+"cmb_emp").value;
}



function hiderow()
{
debugger;
var res=document.getElementById(cont[0]+"cmb_vacanysource").value;
    if(document.getElementById(cont[0]+"cmb_vacanysource").value==0)
    {
        document.getElementById("row1").style.display="inline";
        document.getElementById("row2").style.display="none";
        call_server("10$",15);
    }
    else if(document.getElementById(cont[0]+"cmb_vacanysource").value==4)
    {
         
        document.getElementById("row1").style.display="none";
        document.getElementById("row2").style.display="inline";
    }
    else
    {
        document.getElementById("row1").style.display="none";
        document.getElementById("row2").style.display="none";
    }
}

function perm_state_change()
{
debugger;
      document.getElementById(cont[0]+"chk_add").checked=false;
      if (document.getElementById(cont[0]+"cmb_state_select").value!=0) 
      {
        document.getElementById(cont[0]+"hid_perm_state").value=document.getElementById(cont[0]+"cmb_state_select").value;
        call_server("1$" + document.getElementById(cont[0]+"hid_perm_state").value,1);
      }        

}
function perm_district_change()
{
debugger;
      document.getElementById(cont[0]+"chk_add").checked=false;
      if (document.getElementById(cont[0]+"cmb_dist_select").value!=0) 
      {
        document.getElementById(cont[0]+"hid_perm_district").value=document.getElementById(cont[0]+"cmb_dist_select").value;
        call_server("2$" + document.getElementById(cont[0]+"hid_perm_district").value,2);
      }
}
function perm_post_change()
{
debugger;
      document.getElementById(cont[0]+"chk_add").checked=false;
      if (document.getElementById(cont[0]+"cmb_post_select").value!=0) 
      {
        document.getElementById(cont[0]+"hid_perm_post").value=document.getElementById(cont[0]+"cmb_post_select").value;
        call_server("3$" + document.getElementById(cont[0]+"hid_perm_post").value,3);
      }
}
function pres_state_change()
{
    document.getElementById(cont[0]+"chk_add").checked=false;
    if (document.getElementById(cont[0]+"cmb_pres_state").value!=0) 
      {
        document.getElementById(cont[0]+"hid_pres_state").value=document.getElementById(cont[0]+"cmb_pres_state").value;
        call_server("4$" + document.getElementById(cont[0]+"hid_pres_state").value,4);
      }
}
function pres_district_change()
{
debugger;
      document.getElementById(cont[0]+"chk_add").checked=false;
      if (document.getElementById(cont[0]+"cmb_pres_district").value!=0) 
      {
        document.getElementById(cont[0]+"hid_pres_district").value=document.getElementById(cont[0]+"cmb_pres_district").value;
        call_server("5$" + document.getElementById(cont[0]+"hid_pres_district").value,5);
      }
}
function pres_post_change()
{
debugger;
      document.getElementById(cont[0]+"chk_add").checked=false;
      if (document.getElementById(cont[0]+"cmb_pres_post").value!=0) 
      {
        document.getElementById(cont[0]+"hid_pres_post").value=document.getElementById(cont[0]+"cmb_pres_post").value;
        call_server("6$" + document.getElementById(cont[0]+"hid_pres_post").value,6);
      }  
}

function chk_add_CheckedChanged()
{

     if (document.getElementById(cont[0]+"chk_add").checked==true)
     {
//         document.getElementById(cont[0]+"txt_Pres_hs_name").value=document.getElementById(cont[0]+"txt_perm_hs_name").value;
//         document.getElementById(cont[0]+"txt_pres_pin").value=document.getElementById(cont[0]+"txt_perm_pin").value;
//         document.getElementById(cont[0]+"hid_pres_state").value=document.getElementById(cont[0]+"hid_perm_state").value;
//         document.getElementById(cont[0]+"hid_pres_district").value=document.getElementById(cont[0]+"hid_perm_district").value;
//         document.getElementById(cont[0]+"cmb_pres_state").value=document.getElementById(cont[0]+"hid_perm_state").value;
//         document.getElementById(cont[0]+"hid_pres_post").value=document.getElementById(cont[0]+"hid_perm_post").value;
//         call_server("7$" + document.getElementById(cont[0]+"hid_perm_state").value+ "#" + document.getElementById(cont[0]+"hid_perm_district").value , 7);
     
     document.getElementById(cont[0]+"txt_Pres_hs_name").value= document.getElementById(cont[0]+"txt_perm_hs_name").value;
 document.getElementById(cont[0]+"txt_pres_pin").value=document.getElementById(cont[0]+"txt_perm_pin").value;
 
  var option1   = document.createElement("OPTION");
                        option1.value = document.getElementById(cont[0]+"cmb_prem_state").options[document.getElementById(cont[0]+"cmb_prem_state").selectedIndex].value;
                        option1.text  = document.getElementById(cont[0]+"cmb_prem_state").options[document.getElementById(cont[0]+"cmb_prem_state").selectedIndex].text;
                        document.getElementById(cont[0]+"cmb_pres_state").add(option1);
 var option2   = document.createElement("OPTION");
                        option2.value = document.getElementById(cont[0]+"cmb_prem_district").options[document.getElementById(cont[0]+"cmb_prem_district").selectedIndex].value;
                        option2.text  = document.getElementById(cont[0]+"cmb_prem_district").options[document.getElementById(cont[0]+"cmb_prem_district").selectedIndex].text;
                        document.getElementById(cont[0]+"cmb_pres_district").add(option2);
   var option3   = document.createElement("OPTION");
                       option3.value = document.getElementById(cont[0]+"cmb_perm_post").options[document.getElementById(cont[0]+"cmb_perm_post").selectedIndex].value;
                       option3.text  = document.getElementById(cont[0]+"cmb_perm_post").options[document.getElementById(cont[0]+"cmb_perm_post").selectedIndex].text;
                       document.getElementById(cont[0]+"cmb_pres_post").add(option3);
                        
// document.getElementById(cont[0]+"hid_pres_state").value=document.getElementById(cont[0]+"cmb_prem_state").options[document.getElementById(cont[0]+"cmb_prem_state").selectedIndex].value;
// document.getElementById(cont[0]+"hid_pres_district").value=document.getElementById(cont[0]+"cmb_prem_district").options[document.getElementById(cont[0]+"cmb_prem_district").selectedIndex].value;        
// document.getElementById(cont[0]+"hid_pres_post").value=document.getElementById(cont[0]+"cmb_perm_post").options[document.getElementById(cont[0]+"cmb_perm_post").selectedIndex].value;
//       
     }
     else
     {
        document.getElementById(cont[0]+"txt_Pres_hs_name").value='';
     }
}

function rd_marital_change()
{
    if (document.getElementById(cont[0]+"rd_marital_yes").checked==true) 
    {
        document.getElementById("row3").style.display="inline"
    }
    else
    {
        document.getElementById("row3").style.display="none"
    }
    if (document.getElementById(cont[0]+"rd_marital_no").checked==true) 
    {
        document.getElementById("row3").style.display="none"
    }
    else
    {
        document.getElementById("row3").style.display="inline"
    }
}
function call_receiver(arg,context)
{
  debugger;
   var data=arg.split("$");
   
    switch (context)
    {
        
        case 1 : document.getElementById(cont[0]+"cmb_dist_select").options.length=0;
                 document.getElementById(cont[0]+"cmb_post_select").options.length=0;
                 document.getElementById(cont[0]+"Txt_pin_select").value='';
                  
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';

                 document.getElementById(cont[0]+"cmb_dist_select").add(optionall);
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_dist_select").add(option1);
                      }
                      document.getElementById(cont[0]+"hid_perm_district").value=document.getElementById(cont[0]+"cmb_dist_select").value;
                 }
                 break; 
        case 4 : document.getElementById(cont[0]+"cmb_pres_district").options.length=0;
                 document.getElementById(cont[0]+"cmb_pres_post").options.length=0;
                 document.getElementById(cont[0]+"txt_pres_pin").value='';
                 
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';
                 document.getElementById(cont[0]+"cmb_pres_district").add(optionall);
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_pres_district").add(option1);
                      }
                      document.getElementById(cont[0]+"hid_pres_district").value=document.getElementById(cont[0]+"cmb_pres_district").value;
                      
                 }
                    document.getElementById(cont[0]+"txt_perm_pin").value='';
                 break;   
        case 2 : document.getElementById(cont[0]+"cmb_post_select").options.length=0;
                 document.getElementById(cont[0]+"Txt_pin_select").value='';
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';
               
                 document.getElementById(cont[0]+"cmb_post_select").add(optionall); 
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_post_select").add(option1);
                      }
                      document.getElementById(cont[0]+"hid_perm_post").value=document.getElementById(cont[0]+"cmb_post_select").value;
                      
                 }
               
                  document.getElementById(cont[0]+"Txt_pin_select").value='';
                 break;    
         case 5 : document.getElementById(cont[0]+"cmb_pres_post").options.length=0;
                 document.getElementById(cont[0]+"txt_pres_pin").value='';
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';
                              
                 document.getElementById(cont[0]+"cmb_pres_post").add(optionall);                 
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_pres_post").add(option1);
                      }
                      document.getElementById(cont[0]+"hid_pres_post").value=document.getElementById(cont[0]+"cmb_pres_post").value;
                      
                 }
                    document.getElementById(cont[0]+"txt_perm_pin").value='';
                 break;  
         case 3 : document.getElementById(cont[0]+"Txt_pin_select").value='';    
                 if(data[0]!='') 
                 {
                    document.getElementById(cont[0]+"Txt_pin_select").value= data[0].split("#")[0];
                 }  
                  else
                 {
                    document.getElementById(cont[0]+"Txt_pin_select").value='';
                 }                           
                 break;       
         case 6 : document.getElementById(cont[0]+"txt_pres_pin").value='';    
                 if(data[0]!='') 
                 {
                    document.getElementById(cont[0]+"txt_pres_pin").value= data[0].split("#")[0];
                 }  
                  else
                 {
                    document.getElementById(cont[0]+"txt_perm_pin").value='';
                 }                           
                 break;        
         case 7 : 
                 document.getElementById(cont[0]+"cmb_pres_district").options.length=0;
                 document.getElementById(cont[0]+"cmb_pres_post").options.length=0;
                 
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';
                 var optionall1 =  document.createElement("OPTION");
                 optionall1.value = 0;
                 optionall1.text  = '---SELECT---';
                 
                 document.getElementById(cont[0]+"cmb_pres_district").add(optionall);
                 document.getElementById(cont[0]+"cmb_pres_post").add(optionall1);
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_pres_district").add(option1);
                      }                     
                 }
                 document.getElementById(cont[0]+"cmb_pres_district").value=document.getElementById(cont[0]+"hid_pres_district").value;
                 if(data[1]!='') 
                 {
                      var rows=data[1].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_pres_post").add(option1);
                      }
                 }  
                 document.getElementById(cont[0]+"cmb_pres_post").value=document.getElementById(cont[0]+"hid_pres_post").value;                                                             
                 break;
                 
        case 8: document.getElementById(cont[0]+"txt_age").value=data[0];         
                break;
        case 15: document.getElementById(cont[0]+"cmb_emp").options.length=0;
                 document.getElementById(cont[0]+"cmb_emp").value='';
                 var optionall =  document.createElement("OPTION");
                 optionall.value = 0;
                 optionall.text  = '---SELECT---';
                              
                 document.getElementById(cont[0]+"cmb_emp").add(optionall);                 
                 if(data[0]!='') 
                 {
                      var rows=data[0].split("#");
                      for(a=0;a<rows.length-1;a++)
                      {
                          var cols      = rows[a].split("!");
                          var option1   = document.createElement("OPTION");
                          option1.value = cols[0];
                          option1.text  = cols[1];
                          document.getElementById(cont[0]+"cmb_emp").add(option1);
                      }
                      //document.getElementById(cont[0]+"cmb_emp").value=document.getElementById(cont[0]+"cmb_pres_post").value;
                      
                 }
                break; 
                
        case 9: if (data[0]!='')
                {
                    var pq;
                    pq=data[0].split("#");
                    var st;
                    st=pq[0].split("!");
                    document.getElementById(cont[0]+"cmb_perm_district").options.length = 0;
                    document.getElementById(cont[0]+"cmb_perm_post").options.length=0;
                    document.getElementById(cont[0]+"cmb_pres_district").options.length=0;
                    document.getElementById(cont[0]+"cmb_pres_post").options.length=0;
                   
                    document.getElementById(cont[0]+"txt_name").value=st[0];
                    document.getElementById(cont[0]+"txt_Perm_hs_name").value=st[1];
                    document.getElementById(cont[0]+"cmb_perm_state").value=st[4];
                    document.getElementById(cont[0]+"txt_perm_pin").value=st[5];
                    document.getElementById(cont[0]+"txt_Pres_hs_name").value=st[6];
                    document.getElementById(cont[0]+"cmb_pres_state").value=st[9];
                    document.getElementById(cont[0]+"txt_pres_pin").value=st[10];
                    
                    if (st[23]==2)
                    {
                        document.getElementById(cont[0]+"rd_marital_yes").checked=true;
                        document.getElementById(cont[0]+"rd_marital_no").checked=false;
                        document.getElementById("row3").style.display="inline";
                    }
                    else
                    {
                        document.getElementById(cont[0]+"rd_marital_yes").checked=false;
                        document.getElementById(cont[0]+"rd_marital_no").checked=true;
                        document.getElementById("row3").style.display="none";
                    }
                    if(st[18]==0) 
                    {
                       document.getElementById(cont[0]+"chk_pp").checked=false;
                    }
                    else
                    {
                       document.getElementById(cont[0]+"chk_pp").checked=true;
                    }
                    document.getElementById(cont[0]+"txt_spousename").value=st[24];
                    document.getElementById(cont[0]+"txt_phone").value=st[12];
                    document.getElementById(cont[0]+"txt_contactno").value=st[13];
                    document.getElementById(cont[0]+"txt_email").value=st[14];
                    document.getElementById(cont[0]+"txt_idno").value=st[17];
                    document.getElementById(cont[0]+"cmb_religion").value=st[19];
                    document.getElementById(cont[0]+"cmb_idproof").value=st[16];
                    document.getElementById(cont[0]+"cmb_bloodgp").value=st[15];
                    document.getElementById(cont[0]+"txt_caste").value=st[20];
                    document.getElementById(cont[0]+"txt_fathus").value=st[21];
                    document.getElementById(cont[0]+"txt_dob").value=st[25];
                    document.getElementById(cont[0]+"txt_child").value=st[26];
                    document.getElementById(cont[0]+"cmb_vacanysource").value=st[27];
                    document.getElementById(cont[0]+"txt_sslc").value=st[31];
                    document.getElementById(cont[0]+"cmb_nrbr").value=st[30];
                    if(document.getElementById(cont[0]+"cmb_vacanysource").value==0)
                    {
                        document.getElementById("row1").style.display="inline";
                        document.getElementById("row2").style.display="none";
                    }
                    else if(document.getElementById(cont[0]+"cmb_vacanysource").value==4)
                    {
                        document.getElementById("row1").style.display="none";
                        document.getElementById("row2").style.display="inline";
                    }
                    else
                    {
                        document.getElementById("row1").style.display="none";
                        document.getElementById("row2").style.display="none";
                    }
                    
                    if (st[18]=1)
                    {
                        document.getElementById(cont[0]+"chk_pp").checked=true;
                    }    
                    else
                    {
                        document.getElementById(cont[0]+"chk_pp").checked=false;
                    }
                    document.getElementById(cont[0]+"rd_gender").value=st[22];                         
                    document.getElementById(cont[0]+"txt_lankmark" ).value=st[11];
                   
                    var rows=data[1].split("#");
                    for(a=0;a<rows.length-1;a++)
                    {
                        var cols      = rows[a].split("!");
                        var option1   = document.createElement("OPTION");
                        option1.value = cols[0];
                        option1.text  = cols[1];
                        document.getElementById(cont[0]+"cmb_perm_district").add(option1);
                        
                    } 
                    document.getElementById(cont[0]+"cmb_perm_district").value=st[3];
                    document.getElementById(cont[0]+"hid_perm_district").value=st[3];
                    
                    var rows1=data[2].split("#");
                    for(a=0;a<rows1.length-1;a++)
                    {
                        var cols      = rows1[a].split("!");
                        var option1   = document.createElement("OPTION");
                        option1.value = cols[0];
                        option1.text  = cols[1];
                        document.getElementById(cont[0]+"cmb_perm_post").add(option1);
                    }
                    document.getElementById(cont[0]+"cmb_perm_post").value=st[2];
                    document.getElementById(cont[0]+"hid_perm_post").value=st[2];
                    
                    var rows2=data[4].split("#");
                    for(a=0;a<rows2.length-1;a++)
                    {
                        var cols      = rows2[a].split("!");
                        var option1   = document.createElement("OPTION");
                        option1.value = cols[0];
                        option1.text  = cols[1];
                        document.getElementById(cont[0]+"cmb_pres_district").add(option1);                                             
                    }
                    document.getElementById(cont[0]+"cmb_pres_district").value=st[8];
                    document.getElementById(cont[0]+"hid_pres_district").value=st[8];
                    
                    var rows3=data[5].split("#");
                    for(a=0;a<rows3.length-1;a++)
                    {
                        var cols      = rows3[a].split("!");
                        var option1   = document.createElement("OPTION");
                        option1.value = cols[0];
                        option1.text  = cols[1];
                        document.getElementById(cont[0]+"cmb_pres_post").add(option1);
                    }
                    document.getElementById(cont[0]+"cmb_pres_post").value=st[7];
                    document.getElementById(cont[0]+"hid_pres_post").value=st[7];                  
                }
                else
                {
                    alert('Sorry, No Such Application Exists');
                    document.getElementById(cont[0]+'txt_appln_no').value='';
                    document.getElementById(cont[0]+"rdb_new").checked=true;                    
                    break;
                }
                document.getElementById(cont[0]+"cmd_edit").disabled=false;
    }        
}


function txt_dob_TextChanged()
{
      call_server("8$" + document.getElementById(cont[0]+"txt_dob").value,8); 
}

function checkbeforeconfirm()
{
    if((document.getElementById(cont[0]+"rd_marital_yes").checked==true) && (document.getElementById(cont[0]+"txt_spousename").value=='')) 
    {
        alert("Please Enter Spouse Name");
        return;
    }
    if (document.getElementById(cont[0]+"txt_caste").value=='')
    {
        alert("Please Enter Caste");
        return;
    }
    if (document.getElementById(cont[0]+"txt_idno").value=='')
    {
        alert("Please Enter Id Proof No");
        return;
    }
    if (document.getElementById(cont[0]+"txt_fathus").value=='')
    {
        alert("Please Enter Father/Husbands name");
        return;
    }
    if (document.getElementById(cont[0]+"cmb_nrbr").value==0)
    {
        alert("Please Enter Nearest Branch");
        return;
    } 
    if (document.getElementById(cont[0]+"txt_lankmark").value=='')
    {
        alert("Please Enter Land Mark");
        return;
    } 
    if (document.getElementById(cont[0]+"cmb_perm_state").value==0) 
    {
        alert("Please Select Permanant State");
        return;
    } 
    if (document.getElementById(cont[0]+"cmb_pres_state").value==0) 
    {
        alert("Please Select Presant State");
        return;
    } 
    if (document.getElementById(cont[0]+"cmb_perm_district").value==0) 
    {
        alert("Please Select Permanant District");
        return;
    }     
    if (document.getElementById(cont[0]+"cmb_pres_district").value==0) 
    {
        alert("Please Select Presant District");
        return;
    }     
    if (document.getElementById(cont[0]+"cmb_perm_post").value==0) 
    {
        alert("Please Select Permanant Post");
        return;
    }   
    if (document.getElementById(cont[0]+"cmb_pres_post").value==0) 
    {
        alert("Please Select Presant Post");
        return;
    }     
      
}

function hiderow6()
{
   // debugger;
    document.getElementById(cont[0]+"txt_lankmark" ).value='';
    document.getElementById(cont[0]+"txt_child" ).value='';
    document.getElementById(cont[0]+"cmb_perm_district").options.length = 0;
    document.getElementById(cont[0]+"cmb_perm_post").options.length=0;
    document.getElementById(cont[0]+"cmb_pres_district").options.length=0;
    document.getElementById(cont[0]+"cmb_pres_post").options.length=0;
    document.getElementById(cont[0]+"cmb_perm_state").value=0;
    document.getElementById(cont[0]+"cmb_pres_state").value=0;
    document.getElementById(cont[0]+"cmb_post_select").value=0;
    document.getElementById(cont[0]+"cmb_dist_select").value=0;
    document.getElementById(cont[0]+"cmb_state_select").value=0;
    document.getElementById(cont[0]+"cmb_post_select").options.length=0;
    document.getElementById(cont[0]+"cmb_dist_select").options.length=0;
    document.getElementById(cont[0]+"cmb_state_select").options.length=0;
    
    document.getElementById(cont[0]+"txt_Perm_hs_select").value='';
    document.getElementById(cont[0]+"Txt_pin_select").value='';
    document.getElementById(cont[0]+"txt_name").value='';
    document.getElementById(cont[0]+"txt_Perm_hs_name").value='';
    document.getElementById(cont[0]+"txt_perm_pin").value='';
    document.getElementById(cont[0]+"txt_Pres_hs_name").value='';
    document.getElementById(cont[0]+"txt_pres_pin").value='';
    document.getElementById(cont[0]+"txt_phone").value='';
    document.getElementById(cont[0]+"txt_contactno").value='';
    document.getElementById(cont[0]+"txt_email").value='';
    document.getElementById(cont[0]+"txt_idno").value='';
    document.getElementById(cont[0]+"cmb_religion").value=0;
    document.getElementById(cont[0]+"txt_caste").value='';
    document.getElementById(cont[0]+"txt_fathus").value='';
    document.getElementById(cont[0]+"txt_sslc").value='';
    document.getElementById(cont[0]+"txt_dob").value='';
    document.getElementById(cont[0]+"txt_age").value='';
    document.getElementById(cont[0]+"rd_marital_yes").checked=true;
    document.getElementById(cont[0]+"rd_marital_no").checked=false;
    
    document.getElementById(cont[0]+"txt_spousename").value='';
    
    document.getElementById("row3").style.display="inline";
    document.getElementById(cont[0]+"cmb_idproof").value=0;
    document.getElementById(cont[0]+"cmb_bloodgp").value=0;
    document.getElementById(cont[0]+"hid_perm_district").value=0;
    document.getElementById(cont[0]+"hid_perm_state").value=0;
    document.getElementById(cont[0]+"hid_pres_district").value=0;
    document.getElementById(cont[0]+"hid_pres_state").value=0;
    document.getElementById(cont[0]+"hid_perm_post").value=0;
    document.getElementById(cont[0]+"hid_pres_post").value=0;
    document.getElementById(cont[0]+"cmb_vacanysource").value=0;
    document.getElementById(cont[0]+"rd_gender").value=1;
    document.getElementById(cont[0]+"cmb_nrbr").value=0;
    if (document.getElementById(cont[0]+"rdb_new").checked==true)
    {
        document.getElementById("row6").style.display="none";
        document.getElementById(cont[0]+"txt_appln_no").value='';
        document.getElementById(cont[0]+"cmd_confirm").disabled=false;
        document.getElementById(cont[0]+"cmd_edit").disabled=true;
        
    }
    else if (document.getElementById(cont[0]+"rdb_edit").checked==true)
    {
        document.getElementById("row6").style.display="inline";
        document.getElementById(cont[0]+"txt_appln_no").value='';
        document.getElementById(cont[0]+"txt_appln_no").focus();
        document.getElementById(cont[0]+"cmd_confirm").disabled=true;
        
    }
}

function filleditdata()
{
    if (document.getElementById(cont[0]+"txt_appln_no").value!='') 
    {
        document.getElementById(cont[0]+"cmd_edit").disabled=true;
        call_server("9$" + document.getElementById(cont[0]+"txt_appln_no").value,9); 
    }
}

function clearDropDown(dropDownbox) {   

    var theDropDown = document.getElementById(cont[0]+dropDownbox) 
    var numberOfOptions = theDropDown.options.length  
    for (i=0; i<numberOfOptions; i++) 
    {      
     //Note: Always remove(0) and NOT remove(i) ; Remove zero' th position of the dropdownbox'  
     theDropDown.remove(0)  
    }  
}  


function Button2_onclick() {

    if  (document.getElementById("Checkbox3").checked==true)
    {
    clearDropDown("cmb_perm_district")
    clearDropDown("cmb_perm_post")
    clearDropDown("cmb_perm_state")
    
     document.getElementById(cont[0]+"txt_Perm_hs_name").value= document.getElementById(cont[0]+"txt_Perm_hs_select").value;
     document.getElementById(cont[0]+"txt_perm_pin").value=document.getElementById(cont[0]+"Txt_pin_select").value;
     document.getElementById(cont[0]+"txt_perm_pin").value=document.getElementById(cont[0]+"Txt_pin_select").value;
     var option1   = document.createElement("OPTION");
                            option1.value = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
                            option1.text  = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].text;
                            document.getElementById(cont[0]+"cmb_perm_state").add(option1);
     var option2   = document.createElement("OPTION");
                            option2.value = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;
                            option2.text  = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].text;
                            document.getElementById(cont[0]+"cmb_perm_district").add(option2);
     var option3   = document.createElement("OPTION");
                            option3.value = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
                            option3.text  = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].text;
                            document.getElementById(cont[0]+"cmb_perm_post").add(option3);
                            
     document.getElementById(cont[0]+"hid_perm_state").value=document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
     document.getElementById(cont[0]+"hid_perm_district").value=document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;        
     document.getElementById(cont[0]+"hid_perm_post").value=document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
                            
    }
        
    if  (document.getElementById("Checkbox4").checked==true)
    {
     document.getElementById(cont[0]+"txt_Pres_hs_name").value= document.getElementById(cont[0]+"txt_Perm_hs_select").value;
     document.getElementById(cont[0]+"txt_pres_pin").value=document.getElementById(cont[0]+"Txt_pin_select").value;
     
     clearDropDown("cmb_pres_district")
     clearDropDown("cmb_pres_post")
     clearDropDown("cmb_pres_state")
    
      var option1   = document.createElement("OPTION");
                            option1.value = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
                            option1.text  = document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].text;
                            document.getElementById(cont[0]+"cmb_pres_state").add(option1);
     var option2   = document.createElement("OPTION");
                            option2.value = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;
                            option2.text  = document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].text;
                            document.getElementById(cont[0]+"cmb_pres_district").add(option2);
       var option3   = document.createElement("OPTION");
                           option3.value = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
                            option3.text  = document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].text;
                             document.getElementById(cont[0]+"cmb_pres_post").add(option3);
                            
     document.getElementById(cont[0]+"hid_pres_state").value=document.getElementById(cont[0]+"cmb_state_select").options[document.getElementById(cont[0]+"cmb_state_select").selectedIndex].value;
     document.getElementById(cont[0]+"hid_pres_district").value=document.getElementById(cont[0]+"cmb_dist_select").options[document.getElementById(cont[0]+"cmb_dist_select").selectedIndex].value;        
     document.getElementById(cont[0]+"hid_pres_post").value=document.getElementById(cont[0]+"cmb_post_select").options[document.getElementById(cont[0]+"cmb_post_select").selectedIndex].value;
    }
}


function Checkbox3_onclick() {
    if  (document.getElementById("Checkbox3").checked==true)
    {
      document.getElementById('Checkbox4').checked=false;
      document.getElementById("Checkbox3").checked=true;
    }
    if  (document.getElementById("Checkbox3").checked==false)
    {
      document.getElementById("Checkbox3").checked=false;
      document.getElementById("Checkbox4").checked=true;
    }
}

function Checkbox4_onclick() {
    if  (document.getElementById("Checkbox4").checked==true)
    {
      document.getElementById("Checkbox3").checked=false;
      document.getElementById("Checkbox4").checked=true;
    }
    if  (document.getElementById("Checkbox4").checked==false)
    {
      document.getElementById("Checkbox4").checked=false;
      document.getElementById("Checkbox3").checked=true;
    }
}

// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
        TargetControlID="txt_dob"></cc1:CalendarExtender>

    <table id="tab_01" border="1" style="width: 80%" align="center">
        <tr>
            <td colspan="2" style="height: 27px; text-align: right">
                <input id="rdb_new" runat="server" name="aaa" type="radio" style="color: #ff0066" onclick="return hiderow6()" /><span
                    style="font-size: 14pt; color: #ff0066">New
                Application &nbsp; &nbsp; </span>
            </td>
            <td colspan="2" style="height: 27px; text-align: left">&nbsp;&nbsp;
                <input id="rdb_edit" runat="server" name="aaa" type="radio" style="color: #ff0066" onclick="return hiderow6()" /><span
                    style="color: #ff0066"> <span style="font-size: 14pt">Edit Application</span></span></td>
        </tr>
        <tr id="row6" style="display: none">
            <td colspan="2" style="height: 10px; text-align: right">Enter Application No :</td>
            <td colspan="2" style="height: 10px; text-align: left">
                <input id="txt_Appln_no" maxlength="10" style="width: 162px; font-family: Verdana;" type="text" onchange="return filleditdata()" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; height: 28px;">Name (As given <span style="color: #000000">i</span><span style="color: #ff0000">n SSLC
                    Book)</span><span style="color: #ff0000"><span style="color: #000000"> </span><span
                        style="color: #000000">*</span></span></td>
            <td colspan="2" style="text-align: left; height: 28px;">
                <input id="txt_name" runat="server" maxlength="75" style="width: 319px; font-family: Verdana;" type="text" onkeyup="return string1('txt_name')" /></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 164px; text-align: right">
                <span style="color: #000099"></span>
                <table border="1" style="width: 100%; height: 208px;">
                    <tr>
                        <td colspan="5" style="text-align: center; height: 23px;">
                            <strong><span style="color: #000099"></span></strong></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong><span style="color: #cc3300"><span style="color: #000099">Select State,District &amp; Post for </span>
                                Permanant/Present selection</span></strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px; height: 24px;">
                            <strong><span style="color: #ff0000">Select category</span></strong></td>
                        <td colspan="3" style="height: 24px; text-align: left">&nbsp;
                            <input id="Checkbox3" type="checkbox" onclick="return Checkbox3_onclick()" checked="CHECKED" /><strong>Permanant </strong>
                            <input id="Checkbox4" type="checkbox" onclick="return Checkbox4_onclick()" /><strong>Present</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label7" runat="server" Text="House Name :" Width="88px"></asp:Label></td>
                        <td colspan="3" style="text-align: left;">
                            <asp:TextBox ID="txt_Perm_hs_select" runat="server" Height="24px" MaxLength="50"
                                onkeyup="string1('txt_Perm_hs_select')" TabIndex="2" Width="222px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label3" runat="server" Text="state :" Width="64px"></asp:Label></td>
                        <td colspan="3" style="text-align: left"><%--onchange="return perm_state_change()"--%>
                            <asp:DropDownList ID="cmb_state_select" runat="server" onchange="return perm_state_change()" onkeypress="return perm_state_change()"
                                TabIndex="3" Width="224px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px; height: 26px;">
                            <asp:Label ID="Label4" runat="server" Text="District :" Width="64px"></asp:Label></td>
                        <td colspan="3" style="text-align: left; height: 26px;">
                            <asp:DropDownList ID="cmb_dist_select" runat="server" onchange="return perm_district_change()" onkeypress="return perm_district_change()"
                                TabIndex="4" Width="224px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label5" runat="server" Text="Post :" Width="63px"></asp:Label></td>
                        <td colspan="3" style="text-align: left">
                            <asp:DropDownList ID="cmb_post_select" runat="server" onchange="return perm_post_change()" onkeypress="return perm_post_change()"
                                TabIndex="5" Width="224px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;">
                            <asp:Label ID="Label2" runat="server" Text="PIN :" Width="62px"></asp:Label></td>
                        <td colspan="3" style="text-align: left">
                            <asp:TextBox ID="Txt_pin_select" runat="server" ReadOnly="True" Width="216px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left; width: 198px;"></td>
                        <td colspan="3" style="text-align: left">
                            <input id="Button2" style="font-weight: bold; width: 225px" type="button" value="ADD" onclick="return Button2_onclick()" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <span style="color: #3300cc"><strong>Address : <span style="color: #ff0033">*</span></strong></span></td>
            <td style="width: 222px; text-align: left">
                <table border="1" style="width: 302px">
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong>Permanant</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 27px; text-align: left">
                            <asp:Label ID="Label6" runat="server" Text="House Name :" Width="88px"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 27px">
                            <asp:TextBox ID="txt_Perm_hs_name" runat="server" Height="24px" MaxLength="50"
                                TabIndex="2" Width="193px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; text-align: left">
                            <asp:Label ID="Lbl7" runat="server" Text="state :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; text-align: left">
                            <asp:DropDownList ID="cmb_perm_state" runat="server"
                                TabIndex="3" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; text-align: left">
                            <asp:Label ID="Label8" runat="server" Text="District :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; text-align: left">
                            <asp:DropDownList ID="cmb_perm_district" runat="server"
                                TabIndex="4" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 12px; text-align: left">
                            <asp:Label ID="Label9" runat="server" Text="Post :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 12px; text-align: left">
                            <asp:DropDownList ID="cmb_perm_post" runat="server"
                                TabIndex="5" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 124px; height: 24px; text-align: left">
                            <asp:Label ID="Label10" runat="server" Text="PIN :"></asp:Label></td>
                        <td colspan="3" style="width: 292px; height: 24px; text-align: left">
                            <asp:TextBox ID="txt_perm_pin" runat="server" ReadOnly="True" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:CheckBox ID="chk_add" runat="server" onclick="return chk_add_CheckedChanged()"
                    TabIndex="6" Text="Present address same as Permenant address" Height="34px" Width="304px" Enabled="False" /></td>
            <td colspan="2" style="text-align: left">
                <table border="1">
                    <tr>
                        <td colspan="5" style="text-align: center">
                            <strong>Present</strong></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label11" runat="server" Text="House Name :" Width="90px"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:TextBox ID="txt_Pres_hs_name" runat="server" Height="28px" MaxLength="50" onkeyup="string1('txt_Pres_hs_name')"
                                TabIndex="7" Width="197px" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label12" runat="server" Text="State :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:DropDownList ID="cmb_pres_state" runat="server"
                                TabIndex="8" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label13" runat="server" Text="District :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:DropDownList ID="cmb_pres_district" runat="server"
                                TabIndex="9" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; text-align: left">
                            <asp:Label ID="Label14" runat="server" Text="Post :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; text-align: left">
                            <asp:DropDownList ID="cmb_pres_post" runat="server"
                                TabIndex="10" Width="200px" Font-Names="Verdana">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 101px; height: 8px; text-align: left">
                            <asp:Label ID="Label15" runat="server" Text="PIN :"></asp:Label></td>
                        <td colspan="4" style="width: 289px; height: 8px; text-align: left">
                            <asp:TextBox ID="txt_pres_pin" runat="server" ReadOnly="True" Font-Names="Verdana"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Width="323px" Height="35px"></asp:Label></td>
        </tr>
        <tr>
            <td>Land&nbsp;Mark : <span style="color: #ff0033">*</span></td>
            <td colspan="3" style="text-align: left">
                <asp:TextBox ID="txt_lankmark" runat="server" MaxLength="60" onkeyup="string1('txt_lankmark')"
                    TabIndex="11" Width="626px" Height="17px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>(Residence)
                Phone<span style="color: #ff0000">* :</span></td>
            <td style="width: 222px">
                <asp:TextBox ID="txt_phone" runat="server" MaxLength="15" onkeypress="return isNumberKey(3)"
                    TabIndex="13" Width="210px"></asp:TextBox></td>
            <td colspan="2">
                <asp:CheckBox ID="chk_pp" runat="server" TabIndex="12" Text="PP" /></td>
        </tr>
        <tr>
            <td>Contact No :</td>
            <td style="width: 222px">
                <asp:TextBox ID="txt_contactno" runat="server" MaxLength="15" onkeypress="return isNumberKey(3)"
                    TabIndex="14" Width="210px"></asp:TextBox></td>
            <td colspan="2">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>Email ID:
            </td>
            <td style="width: 222px">
                <asp:TextBox ID="txt_email" runat="server" Height="15px" MaxLength="30" TabIndex="15"
                    Width="298px"></asp:TextBox></td>
            <td colspan="2">
                <asp:RegularExpressionValidator ID="val_email" runat="server" ControlToValidate="txt_email"
                    ErrorMessage="Enter Correct Email Add" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Father/Husband&nbsp;Name :
            </td>
            <td style="width: 222px">
                <asp:TextBox ID="txt_fathus" runat="server" MaxLength="40" onkeyup="string1('txt_fathus')"
                    TabIndex="17" Width="298px"></asp:TextBox></td>
            <td colspan="2">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center; height: 198px;">
                <div style="text-align: center">
                    <table style="width: 840px; height: 386px;" border="1">
                        <tr>
                            <td style="width: 123px; text-align: left">Gender : &nbsp;</td>
                            <td style="width: 190px; text-align: left">
                                <asp:RadioButtonList ID="rd_gender" runat="server" RepeatDirection="Horizontal" TabIndex="16"
                                    Width="205px">
                                    <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                    <asp:ListItem Value="0">Female</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="width: 98px; text-align: right">Marital&nbsp;Status&nbsp;<span style="color: #ff0033">*</span>&nbsp;:<span style="color: #ff0033"></span><span style="color: #ff0000"></span>
                            </td>
                            <td style="width: 100px; text-align: left">
                                <table style="width: 172px">
                                    <tr>
                                        <td style="width: 100px">
                                            <input id="rd_marital_yes" name="v" type="radio" onclick="rd_marital_change()" runat="server" />Married</td>
                                        <td style="width: 100px">
                                            <input id="rd_marital_no" name="v" type="radio" onclick="rd_marital_change()" runat="server" />Single</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="row3">
                            <td style="width: 123px; text-align: left">Spouse :
                            </td>
                            <td style="width: 190px; text-align: left">
                                <asp:TextBox ID="txt_spousename" runat="server" MaxLength="40" onkeyup="string1('txt_spousename')"
                                    TabIndex="19" Width="173px" Font-Names="Verdana"></asp:TextBox></td>
                            <td style="width: 98px; text-align: right;">No&nbsp;Of&nbsp;Children&nbsp;:</td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_child" runat="server" onkeypress="return isNumberKey(3)" TabIndex="20"
                                    Width="66px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: left; height: 16px;">Date&nbsp;of&nbsp;Birth&nbsp;<span style="color: #ff0033">*</span>&nbsp;:&nbsp;</td>
                            <td style="width: 190px; height: 16px; text-align: left;">
                                <asp:TextBox ID="txt_dob" runat="server" onkeypress="return check_null()"
                                    Onchange="txt_dob_TextChanged()" TabIndex="21" Width="173px" Font-Names="Verdana"></asp:TextBox></td>
                            <td style="width: 98px; height: 16px; text-align: left;">Age :&nbsp;</td>
                            <td style="width: 100px; height: 16px; text-align: left;">
                                <asp:TextBox ID="txt_age" runat="server" ReadOnly="True" Width="65px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: left;">Religion :&nbsp;</td>
                            <td style="width: 190px; text-align: left;">
                                <asp:DropDownList ID="cmb_religion" runat="server" TabIndex="22" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left;">Caste<span style="color: #ff3300">* :&nbsp; </span>
                            </td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_caste" runat="server" MaxLength="15" onkeyup="string1('txt_caste')"
                                    TabIndex="23" Width="268px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: left;">ID Proof&nbsp; :&nbsp;
                            </td>
                            <td style="width: 190px; text-align: left;">
                                <asp:DropDownList ID="cmb_idproof" runat="server" TabIndex="24" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left;">ID No :&nbsp;
                            </td>
                            <td style="width: 100px; text-align: left;">
                                <asp:TextBox ID="txt_idno" runat="server" MaxLength="25" onkeyup="string1('txt_idno')"
                                    TabIndex="25" Width="269px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: left">Blood Group :&nbsp;
                            </td>
                            <td style="width: 190px; text-align: left">
                                <asp:DropDownList ID="cmb_bloodgp" runat="server" TabIndex="26" Width="181px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td style="width: 98px; text-align: left">SSLC No :
                            </td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txt_sslc" runat="server" AutoCompleteType="Disabled" MaxLength="40"
                                    onkeyup="string1('txt_sslc')" TabIndex="19" Width="173px" Font-Names="Verdana"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: left;"></td>
                            <td style="width: 190px; text-align: left;"></td>
                            <td style="text-align: left;" colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">Nearest Manappuram Branch In Your Location :</td>
                            <td colspan="2" style="text-align: left">
                                <select id="cmb_nrbr" runat="server" style="width: 310px">
                                    <option selected="selected"></option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">Information Source of Vacancy :</td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_vacanysource" runat="server" onchange="hiderow()"
                                    TabIndex="24" Width="310px" Font-Names="Verdana">
                                    <asp:ListItem Value="0">Directors / Employee </asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">News Paper</asp:ListItem>
                                    <asp:ListItem Value="2">Internet</asp:ListItem>
                                    <asp:ListItem Value="3">Friends</asp:ListItem>
                                    <asp:ListItem Value="4">Others</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr id="row1" style="display: none">
                            <td colspan="2" style="text-align: left">Employee Code &amp; Name :</td>
                            <td colspan="2" style="text-align: left">
                                <asp:DropDownList ID="cmb_emp" runat="server" Width="310px" Font-Names="Verdana" onchange="setval()">
                                </asp:DropDownList></td>
                        </tr>
                        <tr id="row2" style="display: none">
                            <td colspan="2" style="text-align: left; height: 28px;">If Other Specify :</td>
                            <td colspan="2" style="text-align: left; height: 28px;">
                                <asp:TextBox ID="txt_other" runat="server" Width="305px"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="cmd_confirm" runat="server" Text="ADD" Width="68px" OnClientClick="return checkbeforeconfirm()" Font-Names="Verdana" /></td>
                        <td style="width: 100px">
                            <asp:Button ID="cmd_edit" runat="server" Text="EDIT" Width="74px" Font-Names="Verdana" /></td>
                        <td style="width: 100px">
                            <input id="Button1" style="width: 69px; font-family: Verdana;" type="button"
                                value="EXIT" onclick="return Button1_onclick()" /></td>
                    </tr>
                </table>
                `</td>
        </tr>
    </table>
    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_perm_district">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender7" runat="server" TargetControlID="cmb_vacanysource">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender4" runat="server" TargetControlID="cmb_pres_state">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender8" runat="server" TargetControlID="cmb_state_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_perm_state">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender9" runat="server" TargetControlID="cmb_dist_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender10" runat="server" TargetControlID="cmb_post_select">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender6" runat="server" TargetControlID="cmb_pres_post">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_perm_post">
    </cc1:ListSearchExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender5" runat="server" TargetControlID="cmb_pres_district">
    </cc1:ListSearchExtender>
    <input id="hid_perm_district" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_district" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_perm_state" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_state" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_perm_post" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_pres_post" runat="server" style="width: 21px" type="hidden" />
    <input id="hid_emp" runat="server" style="width: 21px" type="hidden" />&nbsp;
</asp:Content>

