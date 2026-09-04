<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="approve shift.aspx.vb"
    Inherits="feb2009_change_shift_press_4f8ff6be3738" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
var con=sal.split('lbl');


function Cmd_exit_onclick() 
{
 window.open('../../home.aspx','_self');
}

function deleteRow(btn) {
debugger;
  var row = btn.parentNode.parentNode;
  row.parentNode.removeChild(row);
}

function fill_table()

{
debugger;
if(document.getElementById(con[0]+"emp_code").value == 0)
{
 alert("PLEASE SELECT ANY DEPARTMENT!!");
 var cnt=document.getElementById("tbl").rows.length;
 for (var i = cnt - 1; i > 0; i--) {
            document.getElementById("tbl").deleteRow(i);
        }
 return false;
 }
 else
 {
 //var ecode=document.getElementById(con[0]+"emp_code").value;
    callserver("1$"+document.getElementById(con[0]+"emp_code").value,1);
  }
}


function call_receiver(arg,context) 
{     
  debugger;
  switch (context)
  {
    case 1:
    {       
     if(arg=="")
         { 
            alert("No More Data For Approval");
            var cnt=document.getElementById("tbl").rows.length;
 for (var i = cnt - 1; i > 0; i--) {
            document.getElementById("tbl").deleteRow(i);
        }
            return false;
         }
        var accdt = arg.split("@"); 
        var sh1;
 var cnt,fp;
 cnt=document.getElementById("tbl").rows.length;
 for (var i = cnt - 1; i > 0; i--) {
            document.getElementById("tbl").deleteRow(i);
        }
 if (cnt==1){
 fp=1;
 }
 else
 {
 for(i=1;i<cnt+1;i++)
 {
 fp=i;
 }
 }
            for (i=0;i<accdt.length-1;i++)
            {
               sh1=accdt[i].split("~")
               var td1 = document.createElement("td");
var td2 = document.createElement("td");
var td3 = document.createElement("td");
var td4 = document.createElement("td");
var td5 = document.createElement("td");
var td6 = document.createElement("td");
var td7 = document.createElement("td");
var td8 = document.createElement("td");
var td9 = document.createElement("td");
var td10 = document.createElement("td");
var row= document.createElement("tr");
td1.innerText = sh1[0];
td2.innerText = sh1[1];
td3.innerText = sh1[2];
td4.innerText = sh1[3];
td5.innerText = sh1[4];
td6.innerText = sh1[5];
td7.innerText = sh1[6];
td8.innerText = sh1[7];

td7.style.display="none";
td8.style.display="none"; 
row.appendChild(td1);
row.appendChild(td2);
row.appendChild(td3);
row.appendChild(td4);
row.appendChild(td5);
row.appendChild(td6);
row.appendChild(td7);
row.appendChild(td8);

row.id="er"+fp;
td9.innerHTML = "<input id='ck"+fp+"' type='checkbox' onclick='return check1()' name='tick"+fp+"'/>";
td10.innerHTML = "<input id='ckh"+fp+"' type='checkbox' onclick='return check2()' name='tick"+fp+"'/>";
fp+=1;

row.appendChild(td9);
row.appendChild(td10);
document.getElementById("Tr1").style.display="block";
document.getElementById("tblbody").appendChild(row);
document.getElementById("tbl").style.display = "block";
            }

         break;   
 }
 }
 }
 
 function check1()
 {
 debugger;

//if (chk == true) 
//{
    debugger;
    var table = document.getElementById("tbl");
    var rowIndex = 0;
    var row = table.rows[rowIndex];
    var checkboxes = row.getElementsByTagName('input');
    var  cnt=document.getElementById("tbl").rows.length;
    //var chkb=checkboxes.length
   
for (var shabai = 1; shabai <=cnt-1; shabai++) 
{
  chk=document.getElementById("ck"+shabai+"").checked
debugger;
    if (chk == true) 
    {
    debugger;
   document.getElementById("ckh"+shabai+"").checked=false;
   document.getElementById(con[0]+"rejectbtn").style.display = "none";
    document.getElementById(con[0]+"Cmd_confirm").style.display = "inline";

//   document.getElementById("chk_bx").checked=false;
//   document.getElementById("ck"+shabai+"").checked=false;
   }
   if(chk == false)
    document.getElementById("ck"+shabai+"").checked=false;
//}
}
 
 }
 
 
 function check2()
 {
 debugger;

//if (chk == true) 
//{
    debugger;
    var table = document.getElementById("tbl");
    var rowIndex = 0;
    var row = table.rows[rowIndex];
    var checkboxes = row.getElementsByTagName('input');
    var  cnt=document.getElementById("tbl").rows.length;
    //var chkb=checkboxes.length
    
for (var shabai = 1; shabai <=cnt-1; shabai++) 
{
 chk=document.getElementById("ckh"+shabai+"").checked
debugger;
    if (chk == true) 
    {
    debugger;
   document.getElementById("ck"+shabai+"").checked=false;
   document.getElementById(con[0]+"Cmd_confirm").style.display = "none";
    document.getElementById(con[0] + "rejectbtn").style.display = "inline";
//   document.getElementById("chk_bx").checked=false;
//   document.getElementById("ck"+shabai+"").checked=false;
   }
   if(chk == false)
    document.getElementById("ckh"+shabai+"").checked=false;
//}
}
 
 }
 
 
 function OnConfirm()
{debugger;
 var cnt;
 
if (document.getElementById("Checkbox1").checked == false && document.getElementById("chk_bx").checked == false) {
    debugger;
    // {   document.getElementById(con[0]+"hidden2").value="";
    var  cnt=document.getElementById("tbl").rows.length;
    for (var shabai = 1; shabai <=cnt-1; shabai++) 
    {
    
     if (document.getElementById("ck"+shabai+"").checked==false && document.getElementById("ckh"+shabai+"").checked==false)
        {
              alert("PLEASE SELECT APPROVE OR REJECT OPTION!!");
              return false;
         }
}
}

// if (document.getElementById("chk_bx").checked == true)
//debugger;
// {   document.getElementById(con[0]+"hidden2").value="";
//    var  cnt=document.getElementById("tbl").rows.length;
//    for (var shabai = 1; shabai <=cnt-1; shabai++) 
//  {
//    if (document.getElementById("ck"+shabai+"").checked==false)
//   
//   {    debugger;
//        alert("PLEASE SELECT ANY Employee!!");
//        return false;
//    }
//    }
// 
// }
// 
 
 
 
 if(document.getElementById(con[0]+"emp_code").value == 0)
{
 alert("PLEASE SELECT ANY DEPARTMENT!!");
 return false;
 }
  if(document.getElementById("tbl").rows.length == 1)
{
 alert("SELECT ANY DEPARTMENT!!");
 return false;
 }
 document.getElementById(con[0]+"hidden2").value="";
 cnt=document.getElementById("tbl").rows.length;
 for(i=0;i<cnt-1;i++)
  { 
   if (document.getElementById("tbl").rows[i+1].cells[0].innerText!="empcode" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="name" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="from date" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="in time"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="out time"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="shift")
   {
   if(document.getElementById(con[0]+"hidden2").value=="")
    {
    var shabai=i+1;
     if (document.getElementById("ck"+shabai+"").checked==true)  
     document.getElementById(con[0]+"hidden2").value=document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;
    
    }
    else
    {
    var shabai=i+1;
    if (document.getElementById("ck"+shabai+"").checked==true) 
     document.getElementById(con[0]+"hidden2").value=document.getElementById(con[0]+"hidden2").value+"@"+document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;

    }
   }
  }
}


function Onreject()
{
debugger;
 var cnt;
 
if (document.getElementById("Checkbox1").checked == false && document.getElementById("chk_bx").checked == false) {
    debugger;
    // {   document.getElementById(con[0]+"hidden2").value="";
    var  cnt=document.getElementById("tbl").rows.length;
    for (var shabai = 1; shabai <=cnt-1; shabai++) 
    {
    
     if (document.getElementById("ck"+shabai+"").checked==false && document.getElementById("ckh"+shabai+"").checked==false)
        {
              alert("PLEASE SELECT APPROVE OR REJECT OPTION!!");
              return false;
         }
}
}

 if(document.getElementById(con[0]+"emp_code").value == 0)
{
 alert("PLEASE SELECT ANY DEPARTMENT!!");
 return false;
 }
  if(document.getElementById("tbl").rows.length == 1)
{
 alert("SELECT ANY DEPARTMENT!!");
 return false;
 }
 document.getElementById(con[0]+"hidden2").value="";
 cnt=document.getElementById("tbl").rows.length;
 for(i=0;i<cnt-1;i++)
  { 
   if (document.getElementById("tbl").rows[i+1].cells[0].innerText!="empcode" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="name" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="from date" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="in time"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="out time"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="shift")
   {
   if(document.getElementById(con[0]+"hidden2").value=="")
    {
    var shabai=i+1;
     if (document.getElementById("ckh"+shabai+"").checked==true) 
     document.getElementById(con[0]+"hidden2").value=document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;
    
    }
    else
    {
    var shabai=i+1;
    if (document.getElementById("ckh"+shabai+"").checked==true) 
     document.getElementById(con[0]+"hidden2").value=document.getElementById(con[0]+"hidden2").value+"@"+document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;

    }
   }
  }
}




function myFunction(q)
{debugger;
var d=q.split("~")
document.getElementById("tbl").deleteRow("er"+d[1]+1);
//document.getElementById("er"+d[1]).remove();
}
function deleteRow(btn) {debugger;
  var row = btn.parentNode.parentNode;
  row.parentNode.removeChild(row);
}


function chk_bx_onclick()
 {
 
 chk=document.getElementById("chk_bx").checked
 chkr=document.getElementById("Checkbox1").checked
//if (chk == true) 
//{
    debugger;
    var table = document.getElementById("tbl");
    var rowIndex = 0;
    var row = table.rows[rowIndex];
    var checkboxes = row.getElementsByTagName('input');
    var  cnt=document.getElementById("tbl").rows.length;
    //var chkb=checkboxes.length
for (var shabai = 1; shabai <=cnt-1; shabai++) 
{
debugger;
    if (chk == true) 
    {
    debugger;
   document.getElementById("ck"+shabai+"").checked=true;
    document.getElementById("Checkbox1").checked=false;
    document.getElementById("ckh"+shabai+"").checked=false;
    document.getElementById(con[0]+"rejectbtn").style.display = "none";
    document.getElementById(con[0]+"Cmd_confirm").style.display = "inline";
    
    }
   if(chk == false)
    document.getElementById("ck"+shabai+"").checked=false;
//}
}
}

function Checkbox1_onclick()
 {
 
 chk=document.getElementById("Checkbox1").checked
//if (chk == true) 
//{
    debugger;
    var table = document.getElementById("tbl");
    var rowIndex = 0;
    var row = table.rows[rowIndex];
    var checkboxes = row.getElementsByTagName('input');
    var  cnt=document.getElementById("tbl").rows.length;
    //var chkb=checkboxes.length
for (var shabai = 1; shabai <=cnt-1; shabai++) 
{
debugger;
    if (chk == true) 
    {
    debugger;
   document.getElementById("ckh"+shabai+"").checked=true;
   document.getElementById("chk_bx").checked=false;
   document.getElementById("ck"+shabai+"").checked=false;
   document.getElementById(con[0]+"Cmd_confirm").style.display = "none";
   document.getElementById(con[0] + "rejectbtn").style.display = "inline";

   
   }
   if(chk == false)
    document.getElementById("ckh"+shabai+"").checked=false;
//}
}
}


    </script>

    <div style="text-align: center">
        <table border="1" style="width: 825px">
            <tr>
                <td colspan="4" style="background-color: #ffcc33; height: 50px;">
                    <strong><span style="font-size: 14pt; color: #ff0000">APPROVE/REJECT SHIFTS</span></strong></td>
            </tr>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 150px; height: 26px;text-align:center;">
                    <span style="font-family: Georgia">Select Department</span></td>
                    
                    
                <td  style="height: 26px; text-align: left">
                   <asp:DropDownList ID="emp_code" runat="server" Width="350px" BackColor="Azure"
                        ForeColor="Blue">
                    </asp:DropDownList></td></tr>
            <tr>
            </tr>
            <tr>           

            </tr>
            
            <tr>
                <td style="width: 100px; height: 26px;">
                    <span style="font-family: Georgia"></span></td>
                <td style=" text-align: left; height: 26px;">
 
                </td>
            </tr>
                
                
                <tr id="Tr1" style="display:none;">
                <th colspan="6">
                    <div style="padding-left:10px;padding-right:10px;padding-top:5px;padding-bottom:5px;">
                        <table style="width:100%;text-align:center;border-style:groove ;" id="tbl">
                            <thead>
                                <tr><th style="height: 25px; width: 12%;text-decoration:underline;border-bottom:2px dashed black;">
                                        EMPCODE</th>
                                        <th style="height: 25px; width: 20%;text-decoration:underline;border-bottom:2px dashed black;">
                                       NAME</th>
                                
                                    <th style="height: 25px; width: 17%;text-decoration:underline;border-bottom:2px dashed black;">
                                        FROM DATE</th>
                                    <th style="height: 25px; width: 16%;text-decoration:underline;border-bottom:2px dashed black;">
                                        IN TIME</th>
                                    <th style="height: 25px; width: 17%;text-decoration:underline;border-bottom:2px dashed black;">
                                        OUT TIME</th>
                                    <th style="height: 25px; width: 16%;text-decoration:underline;border-bottom:2px dashed black;">
                                        SHIFT</th>
                                    <th style="display:none; height: 25px;">
                                        shiftid</th>
                                    <th style="display:none; height: 25px;">
                                        depart</th>
                                        <th style="height: 25px; width: 17%;text-decoration:underline;border-bottom:2px dashed black;">
                                        APPROVE <input type="checkbox" id="chk_bx" onclick="return chk_bx_onclick()"/></th>&nbsp;&nbsp;&nbsp;
                                        
                                         <th style="height: 25px; width: 17%;text-decoration:underline;border-bottom:2px dashed black;">
                                        REJECT <input type="checkbox" id="Checkbox1" onclick="return Checkbox1_onclick()"/></th>
                                </tr>
                            </thead>
                            <tbody id="tblbody">
                            </tbody>
                        </table>
                    </div>
                </th>
            </tr>
                

                <td style="text-align: left; height: 26px;">

                </td>
           
            <tr id="myid" style="display:none;">
                <th colspan="6">
                    <div style="padding-left:10px;padding-right:10px;padding-top:5px;padding-bottom:5px;">
                        
                </th>
            </tr>
            <tr style="display:none;">
                <td colspan="4">
                    <asp:Label ID="lbl_msg" runat="server" Width="806px" Font-Bold="True" Font-Italic="True"
                        ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 55px;" >
                        
                  <input id="Hidden2" runat="server" type="hidden" style="height: 22px" />
                    <table style="width: 506px;margin-left:30%;height: 45px;">
                        <tr>
                            <td style="width: 733px; text-align: center; height: 26px;">&nbsp;<asp:Button ID="Cmd_confirm" runat="server" Text="CONFIRM" OnClientClick="return OnConfirm()"  Width="83px" /></td>
                                  <td style="width: 1761px; height: 26px; text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:Button ID="rejectbtn" runat="server" Text="REJECT" OnClientClick="return Onreject()"  Width="79px" /></td>
                            <td style="width: 756px; height: 26px; text-align: center">
                            
                           <%-- <asp:Button ID="Button1" runat="server" OnClientClick="return Cmd_exit_onclick()" Text="EXIT"  Width="83px" />--%>
                                <%--<input id="Button2" style="width: 100px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" />--%>
                                 <asp:Button ID="Button2" runat="server" Text="EXIT"  Width="107px" />
                                </td>
                          
                            <%--<td style="width: 125px; height: 26px; text-align: center">
                            </td>--%>
                            <%--<td style="width: 154px; text-align: center; height: 26px;">
                                </td>--%>
                            <input id="Hidden3" runat="server" type="hidden" />
                         <asp:HiddenField ID="hdnDelData" runat="server" />
                    
                        </tr>
                        
                    </table>&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
        &nbsp;</div>
</asp:Content>
