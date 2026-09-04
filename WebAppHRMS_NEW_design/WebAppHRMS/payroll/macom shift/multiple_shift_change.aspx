<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="multiple_shift_change.aspx.vb"
    Inherits="feb2009_change_shift_press_4f8ff6be4197" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
var con=sal.split('lbl');
window.onload=getr();

function getr()
{
//alert('hi');
var inp=document.getElementById('txtEcode').focus();
}

//function Cmd_exit_onclick() 
//{
//debugger;
//  window.open('../../home.aspx','_self');  

//}
function gov()
{
alert(document.getElementById(cont_name[0]+"lbl_msg"))
 document.getElementById(cont_name[0]+"lbl_msg").innerHTML="SELECT THE EFFECTIVE DATE BEFORE TAKING REPORT";

}

function titleCase(str) {
   var splitStr = str.toLowerCase().split(' ');
   for (var i = 0; i < splitStr.length; i++) {
       // You do not need to check if i is larger than splitStr length, as your for does that for you
       // Assign it back to the array
       splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].substring(1);     
   }
   // Directly return the joined string
   return splitStr.join(' '); 
}

function emp_fill()
{debugger;
 if(document.getElementById(con[0]+"Txt_effdt").value==""){
 alert("Select Effetive Date!!");
 document.getElementById(con[0]+"cmb_shift").options.length=0;
 return false;
 }
  var ecode =document.getElementById(con[0]+"txtEcode").value+"*"+document.getElementById(con[0]+"Cmb_shift").options[document.getElementById(con[0]+"Cmb_shift").selectedIndex].text+"*"+document.getElementById(con[0]+"Txt_effdt").value;
  callserver("2$"+ecode,2);
}

function date_check()
{debugger;
 
  var ecode =document.getElementById(con[0]+"Txt_effdt").value+"*"+document.getElementById(con[0]+"txtEcode").value;
  callserver("4$"+ecode,4);
}

function myFunction(q)
{debugger;
var d=q.split("~")
document.getElementById("tbl").deleteRow("er"+d[1]+1);
//document.getElementById("er"+d[1]).remove();
}

function viewrep()
{debugger;
window.open("leave_sele2.aspx","_self");
}

function deleteRow(btn) {debugger;
  var row = btn.parentNode.parentNode;
  row.parentNode.removeChild(row);
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



function detailDisplay()

{debugger;


     if(document.getElementById(con[0]+"txtEcode").value=="")
     {
         document.getElementById(con[0]+"txtEname").value = ""; 
                   
         return false; 
      }
    if(document.getElementById(con[0]+"txtEcode").value!="")
    {
        callserver("1$"+document.getElementById(con[0]+"txtEcode").value,1);
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
            alert("Please Enter Valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = ""; 
            return false;
         }
        var accdtl = arg.split("#");  
        var shop= accdtl[1].split("@");
        var sh1;
         if(accdtl[0].split("^")[1]=="0")
         { 
            alert("This Employee Is Not Belongs To Your Department!!");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = "";
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtEname").value = accdtl[0].split("^")[0];
            document.getElementById(con[0]+"Txt_dep").value = accdtl[0].split("^")[2];
            document.getElementById(con[0]+"cmb_shift").options.length=0;
            for (i=0;i<=shop.length-1;i++)
            {
               sh1=shop[i].split("~")
               var option1=document.createElement("OPTION")
               option1.text=sh1[0];
               option1.value=sh1[1];
               document.getElementById(con[0]+"cmb_shift").add(option1);
            }
               
         } 
         break;   
 }
 case 2:
 {
   var sh;
   if (arg=="NOT"){
   alert('EFFECTIVE DATE MUST GREATER THAN TODAY.\nIF YOU WANT, DO THAT IN TODAY SHIFT CHANGE OPTION!!');
   document.getElementById(con[0]+"Txt_effdt").value = "";
   return false;
   }
   
   else{
      var shabhai = arg.split("@"); 
   document.getElementById(con[0]+"cmb_shift2").options.length=0;
   for (i=0;i<=shabhai.length-1;i++)
   {
     sh=shabhai[i].split("~")
     var option1=document.createElement("OPTION")
     option1.text=sh[0];
     option1.value=sh[1];
     document.getElementById(con[0]+"cmb_shift2").add(option1);
   }
   }
   break;
  }
  case 4:{
   if (arg=="NOT")
   {
   alert("EFFECTIVE DATE MUST GREATER THAN TODAY.\nIF YOU WANT, DO THAT IN TODAY SHIFT CHANGE OPTION!!");
   document.getElementById(con[0]+"Txt_effdt").value = "";
   return false;
   }
      if (arg=="CODE")
   {
   alert("Please Type Any Employee Code!!");
   document.getElementById(con[0]+"Txt_effdt").value = "";
   return false;
   }
   else
   {
   var accdtl = arg.split("#");
   var shop= accdtl[1].split("@");
            document.getElementById(con[0]+"txtEname").value = accdtl[0].split("^")[0];
            document.getElementById(con[0]+"Txt_dep").value = accdtl[0].split("^")[2];
            document.getElementById(con[0]+"cmb_shift").options.length=0;
            for (i=0;i<=shop.length-1;i++)
            {
               sh1=shop[i].split("~")
               var option1=document.createElement("OPTION")
               option1.text=sh1[0];
               option1.value=sh1[1];
               document.getElementById(con[0]+"cmb_shift").add(option1);
            }
   }
   break;
 }
 
 
 case 3:
 {
 var cnt,fp;
 cnt=document.getElementById("tbl").rows.length;
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
 
 
 var empcode = document.getElementById(con[0]+"txtEcode").value;
 var empname = document.getElementById(con[0]+"txtEname").value;
 var shiftdate = document.getElementById(con[0]+"Txt_effdt").value;
 var intime = document.getElementById(con[0]+"Cmb_shift").options[document.getElementById(con[0]+"Cmb_shift").selectedIndex].text;
var outtime = document.getElementById(con[0]+"Cmb_shift2").options[document.getElementById(con[0]+"Cmb_shift2").selectedIndex].text;
var aji = arg.split("@"); 
var td1 = document.createElement("td");
var td2 = document.createElement("td");
var td3 = document.createElement("td");
var td4 = document.createElement("td");
var td5 = document.createElement("td");
var td6 = document.createElement("td");
var td7 = document.createElement("td");
var td8 = document.createElement("td");
var td9 = document.createElement("td");
var row= document.createElement("tr");
td1.innerText = empcode;
td2.innerText = titleCase(empname);
td3.innerText = shiftdate;
td4.innerText = intime;
td5.innerText = outtime;
td6.innerText = titleCase(aji[0].split('/')[0]);
td7.innerText = aji[0].split('/')[1];
td8.innerText = aji[1];

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
td9.innerHTML = "<input type='button' value='Delete' style='border:none;text-decoration:underline;color:blue;background-color: Transparent;cursor:pointer;' onclick='deleteRow(this)'/>";
row.appendChild(td9);
document.getElementById("myid").style.display="block";
document.getElementById("tblbody").appendChild(row);
document.getElementById("tbl").style.display = "block";
   break;
  
 } 
 }
 }
 
 
function Add(){

var empcode = document.getElementById(con[0]+"txtEcode").value;
if(empcode == "")
    {
      alert("PLEASE TYPE EMPLOYEE CODE!!");
      return false;
    }
var empname = document.getElementById(con[0]+"txtEname").value;
if(empname == "")
    {
      alert("PLEASE TYPE EMPLOYEE CODE!!");
      return false;
    }
var shiftdate = document.getElementById(con[0]+"Txt_effdt").value;
if(shiftdate == "")
    {
      alert("Select Effetive Date!!");
      return false;
    }
    
    
if(document.getElementById(con[0]+"Cmb_shift").value == 0){
 alert("PLEASE SELECT IN TIME!!");
      return false;
 }
  if(document.getElementById(con[0]+"Cmb_shift2").value == 0){
 alert("PLEASE SELECT OUT TIME!!");
      return false;
 }
callserver("3$"+document.getElementById(con[0]+"Cmb_shift").options[document.getElementById(con[0]+"Cmb_shift").selectedIndex].text+"$"+document.getElementById(con[0]+"Cmb_shift2").options[document.getElementById(con[0]+"Cmb_shift2").selectedIndex].text+"$"+document.getElementById(con[0]+"txtEcode").value,3);
//var td1 = document.createElement("td");
//td1.innerText = empcode;
//var td2 = document.createElement("td");
//td2.innerText = empname;
//var td3 = document.createElement("td");
//td1.innerText = shiftdate;
//var td4 = document.createElement("td");
//td2.innerText = intime;
//var td4 = document.createElement("td");
//td2.innerText = intime;
//var td5 = document.createElement("td");
//td3.innerText = outtime;
//row.appendChild(td1);
//row.appendChild(td2);
//row.appendChild(td3);
//row.appendChild(td4);
//document.getElementById("tblbody").appendChild(row);
//document.getElementById("tbl").style.display = "block";
}

function OnConfirm()
{debugger;
 var cnt;
 if (document.getElementById("tbl").rows.length==1||document.getElementById("tbl").rows.length==0){
 alert("Please Fill All Fields Properly!!");
 return false;
 }
 document.getElementById(con[0]+"hidden2").value="";
 cnt=document.getElementById("tbl").rows.length;
 for(i=0;i<cnt-1;i++)
  { 
   if (document.getElementById("tbl").rows[i+1].cells[0].innerText!="emp code" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="emp name" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="shift from date" && document.getElementById("tbl").rows[i+1].cells[0].innerText!="intime"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="out name"&& document.getElementById("tbl").rows[i+1].cells[0].innerText!="shift name")
   {
   if(document.getElementById(con[0]+"hidden2").value=="")
    {
     document.getElementById(con[0]+"hidden2").value=document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;
    } 
    else
    {
     document.getElementById(con[0]+"hidden2").value=document.getElementById(con[0]+"hidden2").value+"@"+document.getElementById("tbl").rows[i+1].cells[0].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[6].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[7].innerText;
    }
   }
//   else
//   {
//     if(document.getElementById(con[0]+"hidden3").value=="")
//    {
//     document.getElementById(con[0]+"hidden3").value=document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText;
//    } 
//    else
//    {
//     document.getElementById(con[0]+"hidden3").value=document.getElementById(con[0]+"hidden3").value+"@"+document.getElementById("tbl").rows[i+1].cells[2].innerText+"#"+document.getElementById("tbl").rows[i+1].cells[5].innerText;
//    }
//   }
  }
  // alert(document.getElementById(con[0]+"hidden2").value)
}
//function Button2_onclick() {

//}

    </script>

    <div style="text-align: center">
        <table border="1" style="width: 825px">
            <tr>
                <td colspan="4" style="background-color: #ffcc33; height: 50px;">
                    <strong><span style="font-size: 14pt; color: #ff0000">ASSIGN FUTURE SHIFT</span></strong></td>
            </tr>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                    <span style="font-family: Georgia">Emp Code</span></td>

                <td style="height: 26px; text-align: left">
                    <asp:TextBox ID="txtEcode" runat="server" onblur="detailDisplay()" onkeypress="return isNumberKey(3)"
                        Width="150px" BackColor="Azure" Font-Bold="True" ForeColor="Black" MaxLength="6">
                    </asp:TextBox></td>

                <td style="width: 150px; height: 26px;">
                    <span style="font-family: Georgia">Emp Name</span></td>

                <td style="height: 26px; text-align: left">
                    <asp:TextBox ID="txtEname" runat="server" BackColor="Azure" Font-Bold="True" ForeColor="Black"
                        ReadOnly="True" Width="290px">
                    </asp:TextBox></td>

            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                    <span style="font-family: Georgia">Department</span></td>
                <td style="text-align: left; height: 26px;">
                    <asp:TextBox TextMode="SingleLine" ID="Txt_dep" runat="server" ForeColor="Black" BackColor="Azure"></asp:TextBox>
                </td>
                <td style="width: 150px; height: 26px;">
                    <span style="font-family: Georgia">Effective Date</span></td>
                <td style="text-align: left; height: 26px;">
                    <asp:TextBox ID="Txt_effdt" runat="server" ForeColor="Black" BackColor="Azure"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="Txt_effdt" runat="server" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;">
                    <span style="font-family: Georgia">&nbsp;Time In</span></td>
                <td style="text-align: left; height: 26px;">
                    <asp:DropDownList ID="Cmb_shift" runat="server" Width="150px" BackColor="Azure" ForeColor="Blue">
                    </asp:DropDownList>
                </td>
                <td style="width: 150px; height: 26px;">
                    <span style="font-family: Georgia">&nbsp;Time Out</span></td>
                <td style="text-align: left; height: 26px;">
                    <asp:DropDownList ID="Cmb_shift2" runat="server" Width="150px" BackColor="Azure"
                        ForeColor="Blue">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="width: 100px; height: 26px;">
                    <span style="font-family: Georgia"></span></td>
                <td style="text-align: left; height: 26px;"></td>
                <td style="width: 150px; height: 26px;">
                    <span style="font-family: Georgia">
                        <input type="button" id="Button1" value="ADD" onclick="Add()" /></span></td>
                <td style="text-align: left; height: 26px;"></td>
            </tr>

            <tr id="myid" style="display: none;">
                <th colspan="6">
                    <div style="padding-left: 10px; padding-right: 10px; padding-top: 5px; padding-bottom: 5px;">
                        <table style="width: 100%; text-align: center; border-style: groove;" id="tbl">
                            <thead>
                                <tr>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">EMPCODE</th>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">NAME</th>

                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">FROM DATE</th>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">IN TIME</th>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">OUT TIME</th>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">SHIFT</th>
                                    <th style="display: none;">shiftid</th>
                                    <th style="display: none;">depart</th>
                                    <th style="height: 25px; width: 20%; text-decoration: underline; border-bottom: 2px dashed black;">REMOVE</th>
                                </tr>
                            </thead>
                            <tbody id="tblbody">
                            </tbody>
                        </table>
                    </div>
                </th>
            </tr>
            <tr style="display: none;">
                <td colspan="4">
                    <asp:Label ID="lbl_msg" runat="server" Width="806px" Font-Bold="True" Font-Italic="True"
                        ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 55px;">
                    <table style="width: 506px; margin-left: 30%; height: 45px;">
                        <tr>
                            <td style="width: 200px; text-align: center; height: 26px;">
                                <asp:Button ID="Cmd_confirm" runat="server" Text="CONFIRM" OnClientClick="return OnConfirm()" Width="107px" /></td>
                            <td style="width: 125px; height: 26px; text-align: center">
                                <%--<input id="Button2" style="width: 104px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>--%>

                                <asp:Button ID="Button2" runat="server" Text="EXIT" Width="107px" />
                            <td style="width: 125px; height: 26px; text-align: center">
                                <%--<asp:Button ID="Cmd_report" onmouseover="gov()" onmouseout="gou()" runat="server"
                                    Text="REPORT" Width="93px" />--%></td>
                            <td style="width: 125px; height: 26px; text-align: center">
                                <asp:Button ID="Button3" runat="server" Text="VIEW REPORT" OnClientClick="return viewrep()" Width="107px" />
                            </td>
                            <td style="width: 154px; text-align: center; height: 26px;"></td>

                        </tr>

                        <input id="Hidden2" runat="server" type="hidden" style="height: 22px" />
                        <input id="Hidden3" runat="server" type="hidden" />



                    </table>
                </td>
            </tr>
        </table>
        &nbsp;
    </div>
</asp:Content>
