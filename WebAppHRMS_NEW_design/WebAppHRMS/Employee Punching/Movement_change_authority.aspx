<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Movement_change_authority.aspx.vb" Inherits="WebAppHRMS.Employee_Punching_Movement_change_authority_47bf526f4256" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[
var con = loanno.split("txt");


function cmdscancel_onclick() {
 window.open('../home.aspx','_self');
}
function cmdrcancel_onclick() {
 window.open('../home.aspx','_self');
}
// var st,st1;
//function emp_fill()
//{
// 
//  var ecode =document.getElementById(con[0]+"ddl_emp").value;
//  call_server("1*"+ecode,1);
//}
//function call_receiver(arg,context) 
//{
//  switch (context)
//   {
//     case 1:
//      {
//         DynmcTbleFill(arg);
//         break;
//      }   
//   }
//}  
//function DynmcTbleFill(str)
//{
//           st="";
//           st1="";
//           var rid;
//           var rnm;
//           var snm;
//           var qty=str.split("@");
//           for(a=0; a<qty.length-1; a++)
//           {
//             var msr=qty[a].split("*"); 
//             rid=a+1;
//             //debugger;
//             if(msr[6]==-1) 
//             {
//               rnm='NO AUTHORITY';
//             }
//             else
//             {
//              rnm=msr[2];
//             }
//              if(msr[7]==-1)
//             {
//               snm='NO AUTHORITY';
//             }
//             else
//             {
//              snm=msr[3];
//              
//              
//             }
//             st1=st1+"<tr><td><small>"+msr[0]+" TO "+msr[1]+"</td><td><small><a href=javascript:update("+ rid +",1)>"+rnm+"</td><td><small><a href=javascript:update("+ rid +",2)>"+snm+"</td><td style=display:none>"+msr[6]+"</td><td style=display:none>"+msr[7]+"</td><td style=display:none>"+msr[8]+"</td></tr>"
//             document.getElementById(con[0]+"txtBranch").value=msr[4];  
//             document.getElementById(con[0]+"txtPost").value=msr[5]; 
//                  
//            }
//      
//           st=st+"<table id='mytable' border=1 width='775px'><tr><td><small><b>Movement Date</b></td><td><small><b>Recommendation</b></td><td><small><b>Sanction</b></td></tr>"
//           st1=st+st1+"</table>" 
//           document.getElementById("row1").style.display="inline";  
//           document.getElementById(con[0]+"Panel1").innerHTML=st1
//}
//function update(id,opn)
//{

//  document.getElementById(con[0]+"hidden1").value=id;
//  if(opn==1)
//  { //debugger;
//    document.getElementById("rowrec").style.display="inline";
//    document.getElementById("rowsan").style.display="none";
//  
//   }  
//   else
//   {
//     document.getElementById("rowsan").style.display="inline";
//     document.getElementById("rowrec").style.display="none";
//   }   
//}
//function update_data(opt)
//{ //debugger;
// var rowid=0;
// rowid=document.getElementById(con[0]+"hidden1").value;
// if (opt==1)//recom
// {
//   if(document.getElementById(con[0]+"ddlRec").value==-1)
//    {
//      alert("Select Recommendation authority..!");
//      return false;
//    }
//   document.getElementById("mytable").rows[rowid].cells[1].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlRec").options[document.getElementById(con[0]+"ddlRec").selectedIndex].text;
//   document.getElementById("mytable").rows[rowid].cells[3].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlRec").value;
//   
// } 
// else
// {
//  if(document.getElementById(con[0]+"ddlSac").value==-1)
//    {
//      alert("Select Sanction authority..!");
//      return false;
//    }
//  document.getElementById("mytable").rows[rowid].cells[2].innerHTML="<small><a href=javascript:update("+rowid+",2)>"+document.getElementById(con[0]+"ddlSac").options[document.getElementById(con[0]+"ddlSac").selectedIndex].text;
//  document.getElementById("mytable").rows[rowid].cells[4].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlSac").value;
// }
//}
//function cancel()
//{
//     document.getElementById("rowsan").style.display="none";
//     document.getElementById("rowrec").style.display="none";
//     document.getElementById(con[0]+"hidden1").value="";
//}
//function OnConfirm()
//{
// var cnt;
// cnt=document.getElementById("mytable").rows.length;
// for(i=0;i<cnt-1;i++)
//  { //debugger;
//   if(document.getElementById(con[0]+"hidden2").value=="")
//    {
//     document.getElementById(con[0]+"hidden2").value=document.getElementById("mytable").rows[i+1].cells[3].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[4].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[5].innerText;
//    } 
//    else
//    {
//     document.getElementById(con[0]+"hidden2").value=document.getElementById(con[0]+"hidden2").value+"@"+document.getElementById("mytable").rows[i+1].cells[3].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[4].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[5].innerText;
//    }
//  }
//  // alert(document.getElementById(con[0]+"hidden2").value)
//}




// ]]>
    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="height: 23px">ASSIGN MOVEMENT AUTHORITY</td>
            </tr>
            <tr>
                <td style="width: 100px">Employee</td>
                <td colspan="3" style="text-align: left">
                    <asp:DropDownList ID="ddl_emp" runat="server" Width="404px" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">Department</td>
                <td style="width: 100px; text-align: left;">
                    <input id="txtBranch" runat="server" style="width: 307px" type="text" readonly="readOnly" /></td>
                <td style="width: 100px">Post</td>
                <td style="width: 100px">
                    <input id="txtPost" runat="server" style="width: 287px" type="text" readonly="readOnly" /></td>
            </tr>

            <tr>
                <td colspan="4" style="height: 26px; text-align: left">Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlRec" runat="server" Width="312px" AutoPostBack="True">
                    </asp:DropDownList>
                    <%--  <asp:Button ID="Button1"  runat="server" Text="UPDATE" />--%>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px; text-align: left">Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:DropDownList ID="ddlSac" runat="server" Width="312px">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 28px; text-align: center">
                    <asp:Button ID="Button2" runat="server" Style="width: 200px; font-size: 11pt; font-family: 'Courier New';" Text="UPDATE" />
                    <input id="cmdscancel" style="width: 200px; font-size: 11pt; font-family: 'Courier New';" type="button" value="EXIT" onclick="cmdscancel_onclick()" />
                    <%--                <input id="Button1" style="width: 200px; font-size: 11pt; font-family: 'Courier New';" type="button" value="Exit" onclick="return Button2_onclick()" /></td>--%>
                </td>
            </tr>

        </table>
    </div>
</asp:Content>

