<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="BlockDtlsCancel.aspx.vb" Inherits="WebAppHRMS.BlockALert_BlockDtlsCancel_8f62e1657807" title="Punch Block Details in a Date of an Employee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont=loanno.split('txt');
function fill1()
{
   if(document.getElementById(cont[0]+"txtEmpCode").value == "")
   {
      alert('Please Enter a Valid Employee Code..!!');
      init();       
   }
   if(document.getElementById(cont[0]+"txtEmpCode").value != "")
   {
      document.getElementById(cont[0]+"hidEmpCode").value = document.getElementById(cont[0]+"txtEmpCode").value;
      sub_call_server("1$"+document.getElementById(cont[0]+"txtEmpCode").value);
   } 
}
function sub_call_receiver(arg1)
{debugger;
   var arg2,Data,subData;
   arg2 = arg1.split("^");
   if(arg2[0]==11)
   {
      if(arg2[1]=="N")
      {
         alert('This Number is INVALID..!! Please Enter Correct Employee Code..!!');
         init();
      }
      if(arg2[1]=="E")
      {
         alert('This Employee Is Not Belongs To Your Firm ..!! Please Check Employee Code..!!');
         init();
      }
      else
      {
         Data = arg2[1].split("@");
         if(Data[0] == "$")
         {
            alert('No Details Found for this EmpCode..!! Please try after sometime..!!');
            init();
         }
         else
         {
            subData = Data[0].split("*");
            document.getElementById(cont[0]+"txtEmpName").value   = subData[0];
            
            document.getElementById(cont[0]+"txtEmpStatus").value = subData[3];
            document.getElementById(cont[0]+"txtEmpBranch").value = subData[1];
            document.getElementById(cont[0]+"txtEmpPost").value   = subData[2];
            sub_call_server("2$"+document.getElementById(cont[0]+"hidEmpCode").value+"~");
         }
      }
   }
   if(arg2[0]==12)
   {
            if(arg2[1]=="E")
      {
         alert('This Employee Is Not Belongs To Your Firm ..!! Please Check Employee Code..!!');
         init();
      }
      if(arg2[1]=="N")
      {
         alert('This Employee has NO PUNCH BLOCKS on this Day ..!! Please Check..!!');
         init();
      }

      else
      {
         Data = arg2[1].split("@");
         if(Data[0] == "$")
         {
            alert('No Details Found for this EmpCode..!! Please try after sometime..!!');
            init();
         }
         else
         {
           document.getElementById(cont[0]+"hidBlockData").value   = arg2[1];
           //alert(document.getElementById(cont[0]+"hidBlockData").value);
           TableFill();
         }
      }
   }
}
function CheckEmpCode()
{
   document.getElementById(cont[0]+"txtEmpName").value   = "";
   document.getElementById(cont[0]+"txtEmpStatus").value = "";
   document.getElementById(cont[0]+"txtEmpBranch").value = "";
   document.getElementById(cont[0]+"txtEmpPost").value   = "";
   RowHeading.style.display = "none";
   RowPanel.style.display   = "none";
   RowRmvAll.style.display  = "none";  
   document.getElementById(cont[0]+"hidEmpCode").value = "";  
   strString = document.getElementById(cont[0]+"txtEmpCode").value;
   var strValidChars = "0123456789";
   var strChar;
   var blnResult = true;
   if (strString.length == 0) return false;
   for (i = 0; i < strString.length && blnResult == true; i++)
   {
       strChar = strString.charAt(i);
       if(i==0 && strChar == 0)
       {
          blnResult = false;
          document.getElementById(cont[0]+"txtEmpCode").value = "";
          alert("First Number will not be ZERO..!");
       }
       if (strValidChars.indexOf(strChar) == -1)
       {
           blnResult = false;
           document.getElementById(cont[0]+"txtEmpCode").value = "";
           alert("Please Enter Digits Only..!");
       }
   }
   return blnResult;   
}

//function Fill_Dateto()   // subcallserver(2$..) is calling in this function..when copy please note..!!
//{ debugger;
//   var day1,day2;
//   var month1,month2;
//   var year1,year2;
//   if(document.getElementById(cont[0]+"txtBlockDate").value!="")
//   {
//        var value1 = document.getElementById(cont[0]+"txtBlockDate").value;
//        var dt = new Date().format("dd/MMM/yyyy");
//        var value2=dt;    
//        
//        day1= value1.substring (0, value1.indexOf ("/"));
//        month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
//        year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

//        day2= value2.substring (0, value2.indexOf ("/"));
//        month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
//        year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);    
//     
//        date1 = year1+"/"+month1+"/"+day1;
//        date2 = year2+"/"+month2+"/"+day2;   
//        
//        firstDate = Date.parse(date1);
//        secondDate= Date.parse(date2) ;    

//        msPerDay = 24 * 60 * 60 * 1000;
//        
//        dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;         
//        if(dbd<0)
//        {
//           alert("Please Do Not Enter Future Date ..!!")
//           document.getElementById(cont[0]+"txtBlockDate").value="";
//           document.getElementById(cont[0]+"txtBlockDate").focus();
//           return false;
//        }
//        else
//        {
//           sub_call_server("2$"+document.getElementById(cont[0]+"hidEmpCode").value+"~"+document.getElementById(cont[0]+"txtBlockDate").value);
//        } 
//   }
//}
function TableFill()
{  
   var FullData    = document.getElementById(cont[0]+"hidBlockData").value;
   var IndividData = FullData.split("@");
   var len         = IndividData.length - 1;
   var st;
   var New         = "";
   var st1         = "";
   var st3         = "";
   var last        = "";
   var ConfLast    = "";
   var i           = 0;
   var hstat       = "";   
   var AllConf     = 0;    // For Confirm ALL Button..!! :
   var sino        = 0;   
   for(i=0;i<len;i++)
   {
      sino = i+1;
      st3      = IndividData[i].split("*");     //  em.emp_code||'*'||em.emp_name||'*'||bm.block_reason          
      if(st1 == "")
      {
         st1    = "<tr style='background-color:orange'><td style='text-align=center'>"+ sino +"</td><td style='text-align=center'>"+st3[0]+"</td><td style='text-align=left'>"+st3[1]+"</td><td style='text-align=left'>"+st3[2]+"</td><td style='text-align=center'><input type='CheckBox' id='checkRemvBlk"+ i +"' value='checkRemvBlk"+ i +"' onclick=FuncCheckBlkClick('checkRemvBlk"+ i +"','"+st3[3]+"')></td></tr>";        
      }
      else
      {
         st1    = st1 + "<tr style='background-color:orange'><td style='text-align=center'>"+ sino +"</td><td style='text-align=center'>"+st3[0]+"</td><td style='text-align=left'>"+st3[1]+"</td><td style='text-align=left'>"+st3[2]+"</td><td style='text-align=center'><input type='CheckBox' id='checkRemvBlk"+ i +"' value='checkRemvBlk"+ i +"' onclick=FuncCheckBlkClick('checkRemvBlk"+ i +"','"+st3[3]+"')></td></tr>";        
      }
   }
   st       = "<table border=1 style='background-color:orange' ><tr><td style='text-align=center'><b>Si&nbsp;No</b></td><td ><b>Emp.&nbsp;Code</b></td><td><b>&nbsp;Emp&nbsp;Name&nbsp;</b></td><td><b>Block&nbsp;Reason</b></td><td style='text-align=left'><b>Remove&nbsp;Block</b></td></tr>";
   //New      = "<tr style='background-color:PapayaWhip'><td style='text-align=center'>Tick To Remove All Punching Blocks..</td><td style='text-align=center'><input type='CheckBox' name='checkRemvBlkAll' onclick='FuncCheckBlkAllClick()'></td></tr>";   
   //last     = "<tr style='background-color:ThreeDFace'><td><b>&nbsp;</b></td><td><b>Emp.&nbsp;Total</b></td><td><b>Entered:</b></td><td style='text-align=right'><b>"+batAmt+"</b></td><td style='text-align=right'><b>"+taAmt+"</b></td><td><b>&nbsp;</b></td><td><b>&nbsp;</b></td><td><b>&nbsp;</b></td><td><b>&nbsp;</b></td></tr>";
   //ConfLast = "<tr style='background-color:ThreeDFace'><td><b>&nbsp;</b></td><td><b>HRM&nbsp;Conf.</b></td><td><b>Total:</b></td><td style='text-align=right'><b><font color='green'>"+ConfBatAmt+"</font></b></td><td style='text-align=right'><b><font color='green'>"+ConfTaAmt+"</font></b></td><td><b><font color='green'>=&nbsp;"+Math.abs(TotConfAmt).toFixed(2)+"</font></b></td><td><b>&nbsp;</b></td><td><b>&nbsp;</b></td><td><b>&nbsp;</b></td></tr>";
   st1      = st+st1+"</table>";      //+last+ConfLast+"</table>"
   RowHeading.style.display = "inline";
   RowPanel.style.display   = "inline";
   RowRmvAll.style.display  = "inline";
   document.getElementById(cont[0]+"chkRemoveAll").checked      = false;
   document.getElementById(cont[0]+"panBlockDetails").innerHTML = st1;  
   document.getElementById(cont[0]+'cmdConfirm').disabled       = false;     
}
function CheckClient()
{
   if(document.getElementById(cont[0]+"hidEmpCode").value == "")
   {
      alert('Enter Employee Code for Checking Punch Block..!!');
      document.getElementById(cont[0]+"txtEmpCode").focus();
      return false;
   }

   if(document.getElementById(cont[0]+"hidBlockData").value == "")
   {
      alert('No Punch Block Found..!!');
      document.getElementById(cont[0]+"txtEmpCode").focus();
      return false;
   }

   if(document.getElementById(cont[0]+"hidBlockID").value == "")
   {
      alert('Please Select Blocks to be Removed..!!');
      return false;
   }
}
function FuncCheckBlkClick(ChkBx,BlkId)
{//debugger;
//   alert(ChkBx);
//   alert(BlkId);
   var Cnt,BlockDt,Sing;
   var ApDat = "";
   var DpDat = "";
   var AllDat = document.getElementById(cont[0]+"hidBlockID").value;
   if(document.getElementById(ChkBx).checked==true)
   {
      if(AllDat == "")
      {
         AllDat = BlkId+"*";
      }
      else
      {
         Sing = AllDat.split("*");
         for(Cnt = 0;Cnt <= Sing.length - 2;Cnt++)
         {
            if(Sing[Cnt] == BlkId)
            {
               alert('You have Already Selected this Punch Block to Remove..!!');
               return false;
            }            
         }
         AllDat = AllDat+BlkId+"*";               
      }
      document.getElementById(cont[0]+"hidBlockID").value = AllDat;
   }
   if(document.getElementById(ChkBx).checked == false)
   {
      if (AllDat != "")
      {
         Sing = AllDat.split("*");
         for(Cnt = 0;Cnt <= Sing.length - 2;Cnt++)
         {
            if(Sing[Cnt] != BlkId)
            {
               if (ApDat == "")
               {
                  ApDat = Sing[Cnt]+"*";
               }
               else
               {
                  ApDat = ApDat+Sing[Cnt]+"*";
               }
            }
         }
      }
      else
      {
         ApDat = "";
      }
      document.getElementById(cont[0]+"hidBlockID").value = ApDat;
   }
   //alert(document.getElementById(cont[0]+"hidBlockID").value); 
}
function FuncCheckBlkAllClick()  // Remove all at a aOnce..!!
{
   if(document.getElementById(cont[0]+"chkRemoveAll").checked==true)
   {
       var Answer = confirm("This Will Select All Punching Blocks Of this Employee of This Date..!!\n Are You Sure ..?");
       if(Answer)
       {
          //alert("O.K..,Going to Clear all Blocks..!! Click CONFIRM..!!");     
          if(document.getElementById(cont[0]+"hidBlockData").value == "")
          {
             alert('But No Block Details Found..!!');
             return false;
          }
          else
          {         
             var FullData    = document.getElementById(cont[0]+"hidBlockData").value;
             //alert(FullData);
             var IndividData = FullData.split("@");
             var len         = IndividData.length - 1;
             var st1 = "";
             var st  = "";
             for(i=0;i<len;i++)
             {      
                 st3      = IndividData[i].split("*");     //  em.emp_code||'*'||em.emp_name||'*'||bm.block_reason          
                 if(st1 == "")
                 {
                    st1    = st3[3]+"*";        
                 }
                 else
                 {
                    st1    = st1 + st3[3]+"*";        
                 }
                 document.getElementById("checkRemvBlk"+ i).checked  = true;
                 document.getElementById("checkRemvBlk"+ i).disabled = true;
             }
             document.getElementById(cont[0]+"hidBlockID").value = st1;
             //alert(document.getElementById(cont[0]+"hidBlockID").value);
          }
       }
       else
       {
          alert("Immediate Punch Block Removal Cancelled ..!!");
          document.getElementById(cont[0]+"chkRemoveAll").checked = false;
          if(document.getElementById(cont[0]+"hidBlockID").value != "")
          {
             var dat  = document.getElementById(cont[0]+"hidBlockID").value;
             var DatR = dat.split("*");
             var LenR = DatR.length - 2;
             for(i=0; i <= LenR; i++)
             {
                document.getElementById("checkRemvBlk"+ i).checked  = false;
                document.getElementById("checkRemvBlk"+ i).disabled = false;
             }
             document.getElementById(cont[0]+"hidBlockID").value = "";
          }
          return false;
       }
   } // checked==true
   else
   {
      var conf = confirm("Are You Sure..?");
      if(conf)
      {
         if(document.getElementById(cont[0]+"hidBlockID").value != "")
         {
            var dat  = document.getElementById(cont[0]+"hidBlockID").value;
            var DatR = dat.split("*");
            var LenR = DatR.length - 2;
            for(i=0; i <= LenR; i++)
            {
               document.getElementById("checkRemvBlk"+ i).checked  = false;
               document.getElementById("checkRemvBlk"+ i).disabled = false;
            }
            document.getElementById(cont[0]+"hidBlockID").value = "";
         }
      }
      else
      {
         document.getElementById(cont[0]+"chkRemoveAll").checked = true;
         return false;
      }
   }
}
function init()
{
  document.getElementById(cont[0]+"txtEmpName").value     = "";
  document.getElementById(cont[0]+"txtEmpStatus").value   = "";
  document.getElementById(cont[0]+"txtEmpBranch").value   = "";
  document.getElementById(cont[0]+"txtEmpPost").value     = "";
  document.getElementById(cont[0]+"chkRemoveAll").checked = false;
  RowHeading.style.display = "none";
  RowPanel.style.display   = "none";
  RowRmvAll.style.display  = "none";
  document.getElementById(cont[0]+"txtEmpCode").value     = "";
  document.getElementById(cont[0]+"hidEmpCode").value     = "";
  document.getElementById(cont[0]+"hidBlockData").value   = "";
  document.getElementById(cont[0]+"hidBlockID").value     = "";
  document.getElementById(cont[0]+'cmdConfirm').disabled  = true;
  document.getElementById(cont[0]+"label1").value         = "";
  document.getElementById(cont[0]+"txtEmpCode").focus();
}
window.onload = init;
function cmdExit_onclick() 
{
   window.open('../home.aspx','_self');
}

</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 92%; font-family: 'Bookman Old Style'; font-variant: small-caps;">
            <tr>
                <td colspan="2" style="width: 23%; text-align: left">
                    &nbsp;Type Employee Code</td>
                <%--<td style="width: 23%; text-align: left">
                    <asp:TextBox ID="txtEmpCode" onchange="fill1()" onkeyup="CheckEmpCode()" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: center" TabIndex="1"></asp:TextBox></td>--%>
<%--                <td style="width: 23%; text-align: left">
                    &nbsp;Select Block Date</td>--%>
                <td colspan="2" style="width: 23%; text-align: left">
                   <%-- <asp:TextBox ID="txtBlockDate" onkeyup="CheckDate()" onchange="Fill_Dateto()" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: center; cursor: hand;" TabIndex="0"></asp:TextBox>--%>
                        <asp:TextBox ID="txtEmpCode" onchange="fill1()" onkeyup="CheckEmpCode()" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: center" TabIndex="1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 23%; text-align: left">
                    &nbsp;Employee Name</td>
                <td style="width: 23%; text-align: left">
                    <asp:TextBox ID="txtEmpName" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: left" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 23%; text-align: left">
                    &nbsp;Working Branch</td>
                <td style="width: 23%; text-align: left">
                    <asp:TextBox ID="txtEmpBranch" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: left" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 23%; text-align: left">
                    &nbsp;Post</td>
                <td style="width: 23%; text-align: left">
                    <asp:TextBox ID="txtEmpPost" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: left" Width="97%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 23%; text-align: left">
                    &nbsp;Curr. Status</td>
                <td style="width: 23%; text-align: left">
                    <asp:TextBox ID="txtEmpStatus" runat="server" Style="font-family: 'Bookman Old Style';
                        text-align: left" Width="97%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="RowHeading" style="display:none">
                <td style="text-align: center; height: 24px;" colspan="4">
                    <strong>Punch Block Details of Today</strong></td>
            </tr>
            <tr id="RowRmvAll" style="display: none">
                <td colspan="4" style="height: 24px; text-align: center">
                    <asp:CheckBox ID="chkRemoveAll" onclick="FuncCheckBlkAllClick()" runat="server" Text=" Tick to Remove All PunchBlocks of this Employee for this Day at once..!!"
                        Width="752px" style="cursor: hand" /></td>
            </tr>
            <tr id="RowPanel" style="display:none">
                <td style="text-align: center" colspan="4">
                    <asp:Panel ID="panBlockDetails" runat="server" >
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right; height: 31px;">
                    <asp:Button ID="cmdConfirm" OnClientClick="CheckClient()" runat="server" Style="cursor: hand; font-family: 'Bookman Old Style'"
                        Text="Confirm" /></td>
                <td colspan="2" style="text-align: left; height: 31px;">
                    <input id="cmdExit" style="cursor: hand; font-family: 'Bookman Old Style'; width: 81px;" type="button"
                        value="Exit" onclick="return cmdExit_onclick()"/></td>
            </tr>
        </table>
                        <asp:Label ID="Label1" runat="server" Style="font-family: 'Bookman Old Style'" Width="867px"></asp:Label></div>
    <input id="hidEmpCode" runat="server" style="width:8px" type="hidden" />
    <input id="hidBlockData" runat="server" style="width:8px" type="hidden" />
    <input id="hidUserCode" runat="server" style="width:8px" type="hidden" />
    <input id="hidBlockID" runat="server" style="width:8px" type="hidden" />
   
</asp:Content>

