<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_block_release_AMRec_new.aspx.vb" Inherits="WebAppHRMS.Block_Release_Request_hrm_punchblock_release_AMRec_new_0f3e1cd26704" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
//return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split('ddl');

function window_onload() 
{
     document.getElementById("row1").style.display="none";
     document.getElementById(cont_name[0]+"hdnDataSend").value="";
     document.getElementById(cont_name[0]+"hdnReqDt").value="";
     document.getElementById(cont_name[0]+"hdnDataDis").value="";
     document.getElementById(cont_name[0]+"hdnEcode").value="";
     document.getElementById(cont_name[0]+"hdnBlockId").value="";
}
function FillDetails()
{
// document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlEcode").value;
     document.getElementById(cont_name[0]+"Hidden1").value= document.getElementById(cont_name[0]+"ddlEcode").options[document.getElementById(cont_name[0]+"ddlEcode").selectedIndex].text
     if(document.getElementById(cont_name[0]+"ddlEcode").value==-1)
     {
         document.getElementById(cont_name[0]+"txtname").value = "";
         document.getElementById(cont_name[0]+"txtcode").value = "";
         document.getElementById(cont_name[0]+"txtBranch").value = "";
         document.getElementById(cont_name[0]+"txtbr").value = "";  
         document.getElementById(cont_name[0]+"txtrr").value = "";
         document.getElementById(cont_name[0]+"txtdt").value = "";
         return false; 
    }
    else
    {
        callserver("2:"+document.getElementById(cont_name[0]+"Hidden1").value,2);  
    }
}

function FillEmployDetails()
{     
      if(document.getElementById(cont_name[0]+"ddlEcode").value==-1)
      {
        document.getElementById("row1").style.display="none";       
      }
      else
      {
         document.getElementById("row1").style.display="inline";
         data=document.getElementById(cont_name[0]+"ddlEcode").value;
         var kk=document.getElementById(cont_name[0]+"ddlEcode").options[document.getElementById(cont_name[0]+"ddlEcode").selectedIndex].text
         Dt=kk.split(":")     
         ReqDt=Dt[2];
         stat=Dt[3];
         document.getElementById(cont_name[0]+"hdnReqDt").value= ReqDt;
         document.getElementById(cont_name[0]+"hdnStat").value=stat; 
         document.getElementById(cont_name[0]+"hdnEcode").value=document.getElementById(cont_name[0]+"ddlEcode").value;
         callserver("1$"+document.getElementById(cont_name[0]+"hdnReqDt").value+"$"+document.getElementById(cont_name[0]+"hdnEcode").value+"$"+document.getElementById(cont_name[0]+"hdnStat").value,1); 
      }
}
function call_receiver(arg,context) 
{// debugger;
 var Data=arg.split("@")
 switch (context)
 { 
     case 1:        
        
        if(document.getElementById(cont_name[0]+"ddlEcode").value==-1)
        {
             document.getElementById("row1").style.display="none";
             return false;
        }
        else
        {                    
         document.getElementById(cont_name[0]+"hdnDataDis").value=Data[0];
//         disp(); 
                       
        }
     case 2:
    {
    
     document.getElementById(cont_name[0]+"hdnDataDis").value=Data[0];
     var f=document.getElementById(cont_name[0]+"hdnDataDis").value;
//     alert(f);
         var accdtl = arg.split("*");   
//         alert(accdt1); 
         if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(cont_name[0]+"txtEcode").value = "";
            document.getElementById(cont_name[0]+"txtname").value = "";
            document.getElementById(cont_name[0]+"txtBranch").value = "";
            document.getElementById(cont_name[0]+"txtbr").value = "";  
            document.getElementById(cont_name[0]+"txtrr").value = "";  
            document.getElementById(cont_name[0]+"txtdt").value = "";
    
            return false;
         }
         else
         {
            var stat;

            document.getElementById(cont_name[0]+"txtname").value = accdtl[1];
            document.getElementById(cont_name[0]+"txtBranch").value = accdtl[2];
            document.getElementById(cont_name[0]+"txtbr").value = accdtl[4];
            document.getElementById(cont_name[0]+"txtrr").value = accdtl[5];
            document.getElementById(cont_name[0]+"txtdt").value = accdtl[6];
            document.getElementById(cont_name[0]+"txtcode").value = accdtl[0];
            document.getElementById(cont_name[0]+"txtpost").value = accdtl[7];
            document.getElementById(cont_name[0]+"hdnBlockid").value = accdtl[3];
//            if(accdtl[3]==1)
//            {
//                stat="Live";
//            }
//            else
//            {
//                stat="Resigned";
//            }
//            document.getElementById(cont_name[0]+"txtStatus").value = stat; 
 
         }  
           
        break;
        }
  }      
}
//function disp()
//{
//    var st,st1,st2,st3,ar,ar1,tot;
//    var amt=0;
//    var days=0;
//    st1="";
//    st="";
//    tot="";
//    if (document.getElementById(cont_name[0]+"hdnDataDis").value=="")
//    {  
//        document.getElementById(cont_name[0]+"Panel1").innerHTML=""; 
//        document.getElementById("row1").style.display="none";
//        return;
//    }
//    st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")

//    ar=st2.length-1;
//    if(document.getElementById(cont_name[0]+"Hidden2").value!="")
//    {
//        for(k=0;k<ar;k++)
//        {
//            st3=st2[k].split("#")
//            alert(st3);
//            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2] +"</td><td><small>"+st3[3]+"</td><td><small>"+st3[7]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td><td><small>"+st3[6]+"</td><td><input type='checkbox' id='chkm_"+k+"' name='txtm_"+k+"'></td></tr>"
//        }
//        st=st+"<table id='mytable' border='1'  width='100%' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;Branch&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;Post&nbsp;&nbsp; </b></td><td><small><b>&nbsp;&nbsp;Block ID&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;Block Type&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;Reson For Request&nbsp;&nbsp;</b></td><td><small><b>&nbsp;Date&nbsp;</b></td><td><small><b>Recccom/Sanction</b></td></tr>"
//        st1=st+st1+tot+"</table>" 
//    }
//    else
//    {  
//        st1=st+"</table>";
//    }  
//    document.getElementById("row1").style.display="inline";  
//    document.getElementById(cont_name[0]+"Panel1").innerHTML=st1;
//}

function OnConfClick()
{
//debugger;
    if(document.getElementById(cont_name[0]+"Hidden2").value=="")
    {
        alert("Please Add Data...!");
        document.getElementById(cont_name[0]+"txtDate").focus();
        return false;
    }
    if (document.getElementById(cont_name[0]+"Hidden2").value!="")
    {  
            var st3 = "";
            st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
            ar=st2.length
            for(i=1;i<ar;i++)
            {
                st3=st2[i].split("#")
//                var r=document.getElementById(cont_name[0]+"st3").value;
//                alert(st3[7]);
                document.getElementById(cont_name[0]+"hdnDataSend").value +="^"+st3[0]+"#"+st3[6]+"#"+st3[7];
            }
    }
}
//function OnConfClick()
//{
//
//   if(document.getElementById(cont_name[0]+"Hidden2").value=="")
//   {
//        alert("There is No Employees To Recommend...!");
//        document.getElementById(cont_name[0]+"ddlEcode").focus();
//        return false;
//   }
//   if (document.getElementById(cont_name[0]+"Hidden2").value !="")
//   { 
//    var st3 = "";

//      st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
//      ar=st2.length
//      for(i=0;i<=ar-1;i++)
//       {
//         st3=st2[i].split("*")
//         var Regular = "T";
//            if (document.getElementById(cont_name[0]+"chkm_"+i+"").checked==false)  Regular= "F";
//            if (document.getElementById(cont_name[0]+"chkm_"+i+"").checked==true )  Regular= "T";
//            
//            
////         var Regular = "T";
////         if (document.getElementById("chkm_"+i+"").checked==false)
////         {  
////            Regular= "F";
////         }
////         else
////         {
////            document.getElementById(cont_name[0]+"hdnBlockId").value+= st3[7] + "*";
////         }
//         
//         if (document.getElementById("txt_"+i+"").value =="") 
//         { 
//            alert("Please Enter Remarks ") ;
//            document.getElementById(cont_name[0]+"hdnBlockId").value=""; 
//            document.getElementById(cont_name[0]+"hdnDataSend").value="";
//            document.getElementById("txt_"+i+"").focus(); 
//            return false;
//         } 
//           
//         if (document.getElementById("txt_"+i+"").value =="")  Remarks= "NIL";
//         else
//         {
//            Remarks = document.getElementById("txt_"+i+"").value;
//         }
//         
//        

//         document.getElementById(cont_name[0]+"hdnDataSend").value += st3[0] + "^" + st3[6] + "^" + st3[7] + "^" + Regular +  "!" ; 
//       }
//    }
//}
function btnExit_onclick() 
{
    window.open("../Home.aspx","_self");
}

function btnAdd_onclick() 
{
//debugger;
    var ecode=document.getElementById(cont_name[0]+"ddlEcode").value;
    
    if(document.getElementById(cont_name[0]+"ddlEcode").value==-1)
    {
        alert('Please Select Employee..!!');
        document.getElementById(cont_name[0]+"ddlEcode").focus(); 
        return false;
    }
    if(document.getElementById(cont_name[0]+"Hidden2").value!="")
    {
       
       document.getElementById(cont_name[0]+"Hidden3").value=document.getElementById(cont_name[0]+"Hidden2").value+"!"+document.getElementById(cont_name[0]+"txtDt").value+"#"+document.getElementById(cont_name[0]+"ddlEcode").value+"#"+document.getElementById(cont_name[0]+"txtname").value+"#"+document.getElementById(cont_name[0]+"txtBranch").value+"#"+document.getElementById(cont_name[0]+"txtPost").value;
       var data = document.getElementById(cont_name[0]+"Hidden3").value;
       var rows = data.split("!");

       for(i=0;i<=rows.length-2;i++)
       {
          cols = rows[i].split("#");
          if(cols[0]==ecode)
          {
             alert('Already Added..!');
             document.getElementById(cont_name[0]+"ddlEcode").value = -1;
             document.getElementById(cont_name[0]+"txtcode").value = "";
            document.getElementById(cont_name[0]+"txtname").value = "";
            document.getElementById(cont_name[0]+"txtBranch").value = "";
            document.getElementById(cont_name[0]+"txtbr").value = "";  
            document.getElementById(cont_name[0]+"txtrr").value = "";  
            document.getElementById(cont_name[0]+"txtdt").value = "";
            document.getElementById(cont_name[0]+"txtpost").value = "";
             return false;
          }
          
       }
     }
     document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"Hidden2").value+"!"+document.getElementById(cont_name[0]+"ddlEcode").value+"#"+document.getElementById(cont_name[0]+"txtname").value+"#"+document.getElementById(cont_name[0]+"txtBranch").value+"#"+document.getElementById(cont_name[0]+"txtPost").value+"#"+document.getElementById(cont_name[0]+"txtbr").value+"#"+document.getElementById(cont_name[0]+"txtrr").value+"#"+document.getElementById(cont_name[0]+"txtdt").value+"#"+document.getElementById(cont_name[0]+"hdnBlockId").value;
     var ds=document.getElementById(cont_name[0]+"Hidden2").value;
//     alert(ds);
     showDetails();
  
//disp();
            document.getElementById(cont_name[0]+"ddlEcode").value = -1;
            document.getElementById(cont_name[0]+"txtname").value = "";
            document.getElementById(cont_name[0]+"txtBranch").value = "";
            document.getElementById(cont_name[0]+"txtbr").value = "";  
            document.getElementById(cont_name[0]+"txtrr").value = "";  
            document.getElementById(cont_name[0]+"txtdt").value = "";
            document.getElementById(cont_name[0]+"txtpost").value = "";
            document.getElementById(cont_name[0]+"txtcode").value = "";
}


function showDetails()
{
//debugger;
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1><tr></tr>";
    
     tmptab  =tmptab+"<tr style='background-color:Wheat'><td width=5% align=left style= 'font-size: 10pt;'><b>EMP CODE</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style= 'font-size: 10pt;'><b>EMP NAME</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style= 'font-size: 10pt;'><b>   BRANCH     </b> </td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'><b>POST</b></td>";
    tmptab  =tmptab+"<td width=5% align=left style= 'font-size: 10pt;'><b>BLOCK ID</b></td>";
    tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'><b>BLOCK TYPE</b></td>";
     tmptab  =tmptab+"<td width=15% align=left style= 'font-size: 10pt;'><b>REASON FOR REQUEST</b></td>";
     tmptab  =tmptab+"<td width=10% align=left style= 'font-size: 10pt;'><b>DATE</b></td>";
    tmptab  =tmptab+"<td width=5% align=cENTER style= 'font-size: 10pt;'><b>DELETE</b></td></tr>";
   // tmptab  =tmptab+"<td width=10% align=right style= 'font-size: 10pt;'><b>REMARKS</b></td></tr>";
    
    var rowSplitarr =document.getElementById(cont_name[0]+"Hidden2").value.split("!");
    var colSplitarr;
//    alert(rowSplitarr);
    var row_bg1     = 0;  
    var m,j,cnt,TotalPrice,TotalWarranty;
    m=0;j=0;cnt=0;TotalPrice=0;TotalWarranty=0;
    for (m=1;m<rowSplitarr.length;m++)
    {	
        if (row_bg1 == 0)
        {
         row_bg1 = 1;
         tmptab += "<tr style='background-color:OldLace'>";
        }
        else
        {
         row_bg1 = 0;  
         tmptab += "<tr style='background-color:Wheat'>";             
        }
        colSplitarr     =   rowSplitarr[m].split("#");
//        alert(colSplitarr[5]);
//        alert(m);
        tmptab          =   tmptab +"<tr style='background-color:Wheat'><td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[0] + "</td>"  ;
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[1] + "</td>"  ;
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[2] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[3] + "</td>"  ;
         tmptab          =   tmptab +"<td width=5% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[7] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[4] + "</td>"  ;
        tmptab          =   tmptab +"<td width=15% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[5] + "</td>"  ;
        tmptab          =   tmptab +"<td width=10% align=left style= 'font-size: 10pt;'><small>" + colSplitarr[6] + "</td>"  ;
         tmptab          =   tmptab +"<td width=10% align=CENTER style= 'font-size: 10pt;'><a href=javascript:delf("+m+")>Del</a></td></tr>";
//        tmptab          =   tmptab+"<td width=5% align=center style= 'font-size: 10pt;'><input type='checkbox' id='chkm_"+m+"' name='txtm_"+m+"'></td></tr>"
        //tmptab          =   tmptab+"<td width=10% align=center style= 'font-size: 10pt;'><input type='textbox' id='txt_"+m+"' name='txt_"+m+"' style='text-transform:capitalize' maxlength='100'></td></tr>"
        //tmptab          =   tmptab +"<td width=10% align=right style= 'font-size: 10pt;'><a href=javascript:delf("+m+")>Del</a></td></tr>";
    }
    if (row_bg1 == 0)
            tmptab += "<tr style='background-color:OldLace'>";
    else
            tmptab += "<tr style='background-color:Wheat'>"; 
    tmptab          =   tmptab+"</table>";
    document.getElementById(cont_name[0]+"Panel1").innerHTML=tmptab;
    document.getElementById("row1").style.display="inline";
}

function delf(m)
{
    var j=m-1,k
    var new_tran=""
    var new_tran1=""
    var arr=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
    for(k=1;k<=j;k++)
    {
        new_tran=new_tran+"!"+ arr[k]
    }
    for(k=j+2;k<arr.length;k++)
    {
        new_tran=new_tran+"!"+arr[k]
    }
    document.getElementById(cont_name[0]+"Hidden2").value=new_tran
    showDetails();
}
// ]]>
</script>

    <div style="text-align: center">
        <asp:HiddenField ID="hdnReqDt" runat="server" />
        <asp:HiddenField ID="hdnEcode" runat="server" />
        <asp:HiddenField ID="hdnDataDis" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="Hidden3" runat="server" />
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="hdnStat" runat="server" />
        <asp:HiddenField ID="hdnDataSend" runat="server" />
        <asp:HiddenField ID="hdnBlockId" runat="server" />
        <table border="1" style="width: 80%">
            <tr>
                <td colspan="2" style="text-align: left; height: 26px;">
                    Select Employee To Recommend
                </td>
                <td colspan="2" style="text-align: left; height: 26px;">
                    <asp:DropDownList ID="ddlEcode" runat="server" onchange="FillDetails()"  Width="97%">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
                <td style="width: 15%">
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    Emp Code</td>
                <td style="width: 15%; text-align: left;">
                    <asp:TextBox ID="txtcode" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                <td style="width: 15%">
                    Name</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtname" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    Branch</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtbranch" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                <td style="width: 15%">
                    Block Date</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtdt" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    Block Reason</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtbr" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                <td style="width: 15%">
                    Request Reason</td>
                <td style="width: 15%">
                    <asp:TextBox ID="txtrr" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    Post</td>
                <td colspan="2">
                    <asp:TextBox ID="txtpost" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<input id="btnAdd" onclick="return btnAdd_onclick()" style="width: 68px; position: relative"
                        type="button" value="ADD" /></td>
            </tr>
            <tr id="row1">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="100%" style="position: relative">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" OnClientClick="return OnConfClick()" Text="CONFIRM" Height="24px" Width="88px" style="position: relative" />
                    <asp:Button ID="btnSanction" runat="server" Height="24px" Text="SANCTION" OnClientClick="return OnConfClick()" Width="88px" style="position: relative" />
                    <asp:Button ID="Button1" runat="server" OnClientClick="return OnConfClick()" Text="REJECT" Height="24px" Width="88px" style="position: relative" />
                    <input id="btnExit" style="width: 88px; height: 24px; position: relative;" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

