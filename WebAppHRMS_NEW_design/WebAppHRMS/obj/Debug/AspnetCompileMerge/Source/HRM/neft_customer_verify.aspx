<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="neft_customer_verify.aspx.vb" Inherits="WebAppHRMS.neft_customer_verify_00_e9f18c947720" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[

var cnt_id =invoice.split("hdn");

function Button1_onclick() 
{ 
window.open('../home.aspx','_self'); }

function window_onload()
{          
      document.getElementById(cnt_id[0]+"Label1").style .display ="inline";
      ToServer('1^'+'1'+'^'+'-1',1)   
}

function cmb_srtBranchChange()
{
 row_panel.style.display="none";
  document.getElementById(cnt_id[0]+"Label1").style .display ="inline";
      cmb_sort_branch=document.getElementById(cnt_id[0]+"cmb_sort_branch").value;
       if (cmb_sort_branch=='-1')
        {
         
         ToServer('1^'+'1'+'^'+'-1',1)          
        }
       else {           
            ToServer('2^'+'2'+'^'+cmb_sort_branch,1)  
            } 
}

function txtEmpcodeOnblur()
{
  row_panel.style.display="none";
  document.getElementById(cnt_id[0]+"Label1").style .display ="inline"; 
      cmb_sort_branch=document.getElementById(cnt_id[0]+"cmb_sort_branch").value;    
      txtEmpCode=document.getElementById(cnt_id[0]+"txtEmpCode").value;
      if (txtEmpCode=="")
      {
       alert("Wrong Employee Code, Check Details");    
       if (cmb_sort_branch=='-1')
        {         
         ToServer('1^'+'1'+'^'+'-1',1)          
        }
       else 
       {           
         ToServer('2^'+'2'+'^'+cmb_sort_branch,1)  
        } 
      }
      
      if (txtEmpCode!="")
            {           
            ToServer('3^'+'3'+'^'+txtEmpCode,1)  
            } 
}

 function FromServer(Arg1,Arg2)
 {
 
 switch (Arg2)
 { 
 
  case 1:
      {             
      if (Arg1=="æ")
      {
      alert("No Data found!! Please verify The Data");
      return false;
      }
      
      document.getElementById(cnt_id[0]+"hdnDisplay").value=Arg1      
      count_chkbx=0;
         var st,st1,st2,st3,ar,ar1,tot;
         st1="";
         st="";
         tot="";
         j=1;
         if (document.getElementById(cnt_id[0]+"hdnDisplay").value=="")
           {  
              document.getElementById(cnt_id[0]+"Panel1").innerHTML="";      
              return;
           }
          st2=document.getElementById(cnt_id[0]+"hdnDisplay").value.split("¶")
          ar=st2.length-1;  
          
            if(document.getElementById(cnt_id[0]+"hdnDisplay").value!="")
              {
               tot_pay=0;
               tot_ta=0;
                 for(i=0;i<ar;i++)
                  {
                    st3=st2[i].split("®")
                    document.getElementById(cnt_id[0]+"Hidd_month0").value=st3[17];                    
                    document.getElementById(cnt_id[0]+"Hidd_sal_year").value=st3[16];
                    document.getElementById(cnt_id[0]+"Hidd_sal_month").value=st3[15];
                                       
                      if(st1=="")
                        {                        
                              count_chkbx=i;                                                                                         
                              st1="<tr style='width:100%; text-align:left;  background-color: aliceblue;' ><td style='width:50%; '>"+st3[1]+"</td><td>"+st3[12]+"</td><td>"+st3[3]+"</td><td text-align:center>"+st3[4]+"</td><td>"+st3[5]+"</td><td>"+st3[6]+"</td><td style='text-align:right'>"+(st3[13])+"</td><td style='text-align:right'>"+st3[14]+"</td><td style='width:50%;text-align:left'><INPUT TYPE=CHECKBOX NAME=chk_segw"+st3[0]+" value=chk_seg"+count_chkbx+" id=chk_seg"+count_chkbx+"></td></tr>"                                                                                 
                        }
                      else
                        {                                                                 
                              count_chkbx=i;
                              st1=st1+"<tr style='width:100%; text-align:left ; background-color: aliceblue; '  ><td style='width:50%; '>"+st3[1]+"</td><td>"+st3[12]+"</td><td>"+st3[3]+"</td><td text-align:center>"+st3[4]+"</td><td>"+st3[5]+"</td><td>"+st3[6]+"</td><td style='text-align:right'>"+st3[13]+"</td><td style='text-align:right'>"+st3[14]+"</td><td style='width:50% ;text-align:left'><INPUT TYPE=CHECKBOX NAME=chk_segw"+st3[0]+" value=chk_seg"+count_chkbx+ " id=chk_seg"+count_chkbx+"></td></tr>"                            
                              
                        }   
                        tot_pay=Math.abs(tot_pay)+Math.abs(st3[13])    
                        tot_ta=Math.abs(tot_ta)+Math.abs(st3[14])
                                              
                  } 
                              
                st=st+"<table border=1 style='width:100%' ><tr style='background-color: gainsboro; font-weight: bold; ' ><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>Branch</td><td style='width:100%;border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>CustName</td><td style='width:100%;border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>Code</td><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>IFSC&nbsp;Code</td><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>Beneficiary&nbsp;Account</td><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>Beneficiary&nbsp;Branch</td><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>Net&nbsp;Pay</td><td style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'>TA&nbsp;Total</td><td></td></tr>"
                tot="<tr style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'><td colspan='5' style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'><b>Total</b></td><td colspan='1' style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'><b>"+Math.abs (count_chkbx)+"</b></td><td colspan='1' style='border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'><b>"+(Math.abs (tot_pay))+"</b></td><td colspan='1' style='text-align:right; border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; border-bottom: gainsboro thin solid;'><b>"+(Math.abs (tot_ta))+"</b></td><td></td></tr>"
                st1=st+st1+tot+"</table>" 
             }
             else
             {  
               st1=st+"</table>";
             }   
            document.getElementById(cnt_id[0]+"Hdn_chbx_cnt").value=count_chkbx
            row_panel.style.display="inline";  
            document.getElementById(cnt_id[0]+"Panel1").innerHTML=st1;  
                  
         document.getElementById(cnt_id[0]+"Label1").style .display ="none";
         
         var Hidd_month0=document.getElementById(cnt_id[0]+"Hidd_month0").value;
         var Hidd_sal_year=document.getElementById(cnt_id[0]+"Hidd_sal_year").value;     
         
         document.getElementById(cnt_id[0]+"Label2").innerHTML="Salary Date: "+Hidd_month0+","+Hidd_sal_year;             
        break;
       }
     }
 }


function checkall_select()
{

if (document.getElementById(cnt_id[0]+"Hdn_chbx_cnt").value!="")
{
  var ChBoxCount1=Math.abs(document.getElementById(cnt_id[0]+"Hdn_chbx_cnt").value)
  
  if (document.getElementById(cnt_id[0]+"Check_all").checked==true)
   {   
      for(m=0;m<=Math.abs(ChBoxCount1);m++)
      {
        document.getElementById("chk_seg"+m).checked=true;
      }
   }
  else
   {
   
    for(m=0;m<=Math.abs(ChBoxCount1);m++)
    {
    document.getElementById("chk_seg"+m).checked=false;
    }
   }
  }
  else
  {
  alert("No Data Found,\nPlease Wait !..")
  return false;
  } 
}


function confirm_CheckNeftData()
{

 var ChBoxCount1;
 var chboxValue="";
 var Hidden_chk;
 ChBoxCount1=Math.abs(document.getElementById(cnt_id[0]+"Hdn_chbx_cnt").value)
  
  var Hidd_display=document.getElementById(cnt_id[0]+"hdnDisplay").value;  
  st2=Hidd_display.split("¶")
  ar=st2.length-1;
  for(i=0;i<ar;i++)
  {     
   if ( document.getElementById("chk_seg"+i).checked==true)
   {
    document.getElementById(cnt_id[0]+"Hidd_confirm").value=document.getElementById(cnt_id[0]+"Hidd_confirm").value+st2[i]+"¶";   
   }
  }
    
  Hidden_chk=document.getElementById(cnt_id[0]+"Hidd_confirm").value;
      
  if (Hidden_chk=='')
  {
   alert('Please..Check Data. \n Error Code: Empty, Select Any Data !!');
   return false;
  } 
   
}

</script>

    &nbsp;<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table border="0" id ="tableCursor01" align="center" style="font-family: 'Courier New'; width:90%">
        <tr style="width: 100%;">
          
        </tr>
        <tr style="width: 100%;">
        </tr>
        <tr style="width: 100%;" >
        </tr>
        <tr style="width: 100%;" >
        </tr>
        <tr style="width: 100%" >
        </tr>
        <tr style="width: 100%">
            <td colspan="2" style="border-right: darkgray thin solid; border-top: darkgray thin solid;
                border-left: darkgray thin solid; border-bottom: darkgray thin solid; font-family: 'Times New Roman';
                height: 25px; background-color: peachpuff; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana"></asp:Label></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="2" style="font-family: 'Times New Roman';  text-align: left; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; height: 20px; background-color: peachpuff;">
                <asp:Label ID="lbl_srt_brnch" runat="server" Font-Names="Verdana" Text="Sort By Branch:" Font-Bold="True" Font-Size="10pt"></asp:Label>
                &nbsp; &nbsp;
                <asp:DropDownList ID="cmb_sort_branch" runat="server" Font-Names="Times New Roman" Width="256px">
                </asp:DropDownList>
                &nbsp; 
            <%--</td> 
               <td  style="font-family: 'Times New Roman';  text-align: right">--%>
            <asp:CheckBox ID="Check_all" runat="server" Text="Select checkbox all" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" />
                &nbsp;
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                    Text="Search By Emp Code:"></asp:Label>
                <asp:TextBox ID="txtEmpCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="width: 100%">
            <td colspan="2" style="font-family: 'Times New Roman'; height: 19px; text-align: center">
                <table border="0" align="center" style="font-family: 'Times New Roman'; width:100%;">
                    <tr id="row_panel" >
                        <td style="font-family: 'Times New Roman'; height: 28px; text-align: center" colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                            </asp:Panel>
                <asp:Label ID="Label1" runat="server" Width="100%" Font-Bold="True">Processing...</asp:Label></td>
                    </tr>
                </table>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;
                &nbsp;
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr style="width: 100%; cursor:hand" >
            <td style="width: 50%; height: 28px; text-align: right; font-family: 'Times New Roman'; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; background-color: peachpuff;">
                <asp:Button ID="cmd_report" runat="server" Text="VERIFY" Font-Names="Courier New" Width="95px" Height="27px" /></td>
            <td style="width: 50%; height: 28px; text-align: left; font-family: 'Times New Roman'; border-right: darkgray thin solid; border-top: darkgray thin solid; border-left: darkgray thin solid; border-bottom: darkgray thin solid; background-color: peachpuff;">
                <input id="Button1" style="width: 105px; font-family: 'Courier New'; height: 26px;" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtEmpCode" FilterType ="Numbers" >
    </cc1:FilteredTextBoxExtender>
    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_sort_branch">
                </cc1:ListSearchExtender>
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
<asp:HiddenField ID="Hdn_chbx_cnt" runat="server" /><asp:HiddenField ID="Hidd_choice" runat="server" />
                <asp:HiddenField ID="Hidd_month0" runat="server" />
                <asp:HiddenField ID="hdnDisplay" runat="server" />
                <asp:HiddenField ID="Hidd_sal_year" runat="server" />
                <asp:HiddenField ID="Hidd_sal_month" runat="server" />
                <asp:HiddenField ID="Hidd_confirm" runat="server" />

    <input id="hidCase" runat="server" style="width: 12px" type="hidden" />
</asp:Content>

