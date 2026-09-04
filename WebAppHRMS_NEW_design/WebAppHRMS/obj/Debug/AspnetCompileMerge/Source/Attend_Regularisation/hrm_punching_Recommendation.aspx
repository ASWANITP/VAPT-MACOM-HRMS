<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false"  CodeBehind="hrm_punching_Recommendation.aspx.vb" Inherits="WebAppHRMS.Punching_Sanction_hrm_punching_Recommendation_994262ab4327" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('ddl');
function btnExit_onclick() 
{
    window.open('../home.aspx','_self');
}
function ClassOnChange()
{
   //debugger;
   var TT=(document.getElementById(con[0]+"ddlBranch").value).split("~");
   
   document.getElementById(con[0]+"Hidden1").value=TT[0];
   document.getElementById(con[0]+"hid_att").value=TT[1];
   document.getElementById(con[0]+"hid_status").value=TT[2];
   var kk=document.getElementById(con[0]+"ddlBranch").options[document.getElementById(con[0]+"ddlBranch").selectedIndex].text
   Dt=kk.split("~")     
   ReqDt=Dt[1];
   document.getElementById(con[0]+"Hidden4").value=Dt[1];   
   if(document.getElementById(con[0]+"Hidden1").value!=-1)
   { 
                
      callserver("1$"+document.getElementById(con[0]+"Hidden1").value+"%"+ReqDt+"%"+document.getElementById(con[0]+"hid_att").value+"%"+document.getElementById(con[0]+"hid_status").value+"%"+document.getElementById(con[0]+"hid_rule").value,1);  
   }
   else
   {
       document.getElementById("row1").style.display='none';
       document.getElementById("row2").style.display='none';
       document.getElementById("row3").style.display='none';
       document.getElementById("row9").style.display='none';
       document.getElementById("row4").style.display='none';
       //document.getElementById("row5").style.display='none';
   }
}
function call_receiver(arg,context) 
{  
   //debugger;
  var Data=arg.split("@")
  switch (context)
  { 
    case 1:        
        
        if(document.getElementById(con[0]+"ddlBranch").value==-1)
        {
               document.getElementById("row1").style.display='none';
               document.getElementById("row2").style.display='none';
               document.getElementById("row3").style.display='none';
               document.getElementById("row9").style.display='none';
               document.getElementById("row4").style.display='none';
               //document.getElementById("row5").style.display='none';
               return false;
        }
         else
        {                    
         document.getElementById(con[0]+"Hidden2").value=Data[0];
         document.getElementById(con[0]+"Hidden3").value=Data[1];
         document.getElementById("row3").style.display='inline';
          document.getElementById("row9").style.display='inline';
         document.getElementById("row4").style.display='inline';
         //document.getElementById("row5").style.display='inline';
         disp(); 
         disp1();                         
        }
        break;
      case 2:
          alert(arg) ;
          window.open('hrm_punching_Recommendation.aspx','_self');
          break;   
          
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
    if (document.getElementById(con[0]+"Hidden2").value=="")
    {  
        document.getElementById(con[0]+"Panel1").innerHTML=""; 
        document.getElementById("row1").style.display="none";
        return;
    }
   
    st2=document.getElementById(con[0]+"Hidden2").value.split("!")
    ar=st2.length-1;
    if(document.getElementById(con[0]+"Hidden2").value!="")
     if (document.getElementById(con[0]+"hid_post").value==136 || document.getElementById(con[0]+"hid_post").value==197)
    {
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")            
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><input type='checkbox' id='chkm_"+k+"' name='txtm_"+k+"'></td><td><input type='textbox' id='txt_"+k+"' name='txt_"+k+"' style='text-transform:capitalize' maxlength='100'></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARKS&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;POST&nbsp;&nbsp;&nbsp;</b></td><td style='color:blue'><small><b>*&nbsp;MARK&nbsp;IF&nbsp;RECOMMEND&nbsp;ONLY&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARK IF ANY&nbsp;&nbsp;&nbsp;</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }}
    else
    {
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*") 
            if (st3[5]=="") {st3[5]='-';}  
            if (st3[6]=="") {st3[6]='-';}  
            if (st3[7]=="") {st3[7]='-';}          
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><small>"+st3[7]+"</td><td><input type='checkbox' id='chkm_"+k+"' name='txtm_"+k+"'></td><td><input type='textbox' id='txt_"+k+"' name='txt_"+k+"' style='text-transform:capitalize' maxlength='100'></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARKS&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;POST&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;AM RECOMMEND REASON&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;RM RECOMMEND REASON&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;RH RECOMMEND REASON&nbsp;&nbsp;&nbsp;</b></td><td style='color:blue'><small><b>*&nbsp;MARK&nbsp;IF&nbsp;RECOMMEND&nbsp;ONLY&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARK IF ANY&nbsp;&nbsp;&nbsp;</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(con[0]+"Panel1").innerHTML=st1;
}

function disp1()
{

   var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(con[0]+"Hidden3").value=="")
    {  
        document.getElementById(con[0]+"Panel2").innerHTML=""; 
        document.getElementById("row2").style.display="none";
        return;
    }
    st2=document.getElementById(con[0]+"Hidden3").value.split("!")
    ar=st2.length-1;
    if(document.getElementById(con[0]+"Hidden3").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2] +"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP CODE</b></td><td><small><b>EMP NAME</b></td><td><small><b>POST</b></td><td><small><b>ACTUAL IN TIME</b></td><td><small><b>MORNING PUNCH TIME</b></td><td><small><b>ACTUAL OUT TIME</b></td><td><small><b>EVENING PUNCH TIME</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row2").style.display="inline";  
    document.getElementById(con[0]+"Panel2").innerHTML=st1;
}

function window_onload() 
{
    document.getElementById("row1").style.display='none';
    document.getElementById("row2").style.display='none';
    document.getElementById("row3").style.display='none';
     document.getElementById("row9").style.display='none';
    document.getElementById("row4").style.display='none';
    //document.getElementById("row5").style.display='none';
}

function onclickconf()
{
 //debugger;
// var Flag=confirm("Are You Sure to Confirm");
//  if (Flag==true)
//  {
  document.getElementById(con[0]+"Hidden5").value = ""; 
   
  if (document.getElementById(con[0]+"Hidden2").value !="")
  document.getElementById(con[0]+"hid_Counter").value=0
  document.getElementById(con[0]+"hid_Counter1").value=0
  var coun1=0
   {  var st3 = "";
      st2=document.getElementById(con[0]+"Hidden2").value.split("!")
      ar=st2.length
      for(i=0;i<ar-1;i++)
       {
        document.getElementById(con[0]+"hid_Counter").value = Math.abs(document.getElementById(con[0]+"hid_Counter").value)+1;
        var coun=document.getElementById(con[0]+"hid_Counter").value;
         st3=st2[i].split("*")
         var Regular = "T";
         
         if (document.getElementById("chkm_"+i+"").checked==true)
         {
         document.getElementById(con[0]+"hid_Counter1").value = Math.abs(document.getElementById(con[0]+"hid_Counter1").value)+1;
         var coun1=document.getElementById(con[0]+"hid_Counter1").value;}
        
         if (document.getElementById("chkm_"+i+"").checked==false)  Regular= "F";
         if (document.getElementById("chkm_"+i+"").checked==false && document.getElementById("txt_"+i+"").value =="")  {alert("Enter Remarks!!!");document.getElementById("txt_"+i+"").focus();return false;}
         else
         {
         if (document.getElementById("txt_"+i+"").value==""){Remarks="Nil";}
         else
         {Remarks = document.getElementById("txt_"+i+"").value;}
         }
         document.getElementById(con[0]+"Hidden5").value += st3[0] + "^" +st3[1] + "^" +st3[2] + "^" +st3[3] + "^" +st3[4]+ "^" +Regular + "^" +Remarks+ "^" +document.getElementById(con[0]+"hid_att").value+"#" ; 
       }
    }
     var Flag=confirm(coun1+" Out Of  "+coun+"  You Are Recommended" + "***" + "Are You Sure to Confirm");
     if (Flag==true)
    {
    
    var Dataa = document.getElementById(con[0]+"Hidden5").value;      
    var ReqDT=document.getElementById(con[0]+"Hidden4").value;
    data=Dataa+"%"+ReqDT+"%"+112;
    callserver("2$"+data,2);
    }
   if (Flag==false)
  {
   return false;
  }
  
  
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="hid_zonal" runat="server" />
        &nbsp;<table border="1" style="width: 69%">
            <tr>
                <td style="width: 25%">
                    Select Branch</td>
                <td style="width: 67%">
                    <asp:DropDownList ID="ddlBranch" onchange="ClassOnChange()" runat="server" Width="99%">
                    </asp:DropDownList></td> 
            </tr>
            <tr>
                <td colspan="2" id= "row3">
                    <span style="color: #cc0033"><span style="font-size: 14pt">
                    &nbsp;<strong>Not Punching Staffs</strong></span></span></td>
            </tr>
            <tr style=""display:none; font-size: 12pt" id="row9" >
                <td colspan="2" style="text-align: center; height: 23px; background-color: #ffe7ff;">
                    <strong><span style="color: #0000ff; font-size: 13pt;"><span style="color: #ff0000">
                        Note&nbsp;:</span>&nbsp;Please&nbsp;Mark&nbsp;The&nbsp;Check&nbsp;Box&nbsp;To Recommend,&nbsp;Otherwise&nbsp;It&nbsp;Will&nbsp;be&nbsp;Rejected</span></strong></td>
            </tr>
            <tr style="font-size: 12pt">
                <td id="row1" colspan="2" style="display:none">
                    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="100%">
                    </asp:Panel>
                </td>
            </tr>
            <tr style="font-size: 12pt">
                <td colspan="2" id= "row4" >
                    <span style="color: #009900; font-size: 14pt;"><strong>&nbsp;Punching Staffs</strong></span></td>
            </tr>
            <tr>
                <td colspan="2" id= "row2" style="display:none">
                    <asp:Panel ID="Panel2" runat="server" Height="0px" Width="100%">
                    </asp:Panel>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 26px" id= "row5">
                    <input id="btnConf" type="button" value="RECOMMEND/SANCTION" onclick="onclickconf()" style="width: 178px; height: 28px" />
                    &nbsp;<input id="btnExit" style="width: 91px; height: 28px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <input id="hid_att" runat="server" type="hidden" style="width: 4px" />
    <input id="hid_post" runat="server" type="hidden" style="width: 3px" />
    <input id="hid_area" runat="server" style="width: 1px" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
        <asp:HiddenField ID="Hidden5" runat="server" />
        <asp:HiddenField ID="Hidden4" runat="server" />
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="Hidden3" runat="server" />
    <input id="hid_status" runat="server" type="hidden" />
    <asp:HiddenField ID="hid_Counter" runat="server" />
    <asp:HiddenField ID="hid_Counter1" runat="server" />
    <asp:HiddenField ID="hid_rule" runat="server" />
</asp:Content>

