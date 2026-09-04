<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="AssignOthLeave_authority.aspx.vb" Inherits="WebAppHRMS.leave_AssignLeave_authority_54ff50e74446" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var con = loanno.split("txt");
function txtexit_onclick() {
 window.open('../home.aspx','_self');
}
 var st,st1;
function emp_fill()
{
 
  var ecode =document.getElementById(con[0]+"ddl_emp").value;  
  var lvid=document.getElementById(con[0]+"ddlCtgry").value;
  if(lvid>0)
  {
   call_server("1*"+ecode+"*"+lvid,1);
  }
}
function call_receiver(arg,context) 
{
  switch (context)
   {
     case 1:
      {
         DynmcTbleFill(arg);
         break;
      }   
   }
}  
function DynmcTbleFill(str)
{
           st="";
           st1="";
           var rid;
           var rnm;
           var snm;
           var qty=str.split("@");
           for(a=0; a<qty.length-1; a++)
           {
             var msr=qty[a].split("*"); 
             rid=a+1;
           // debugger;
            if(msr[4]==-1) 
             {
               rnm='NO AUTHORITY';
             }
             else
             {
              rnm=msr[0];
             }
              if(msr[5]==-1)
             {
               snm='NO AUTHORITY';
             }
             else
             {
              snm=msr[1];
              
              
             }
             st1=st1+"<tr><td><small><a href=javascript:update("+ rid +",1)>"+rnm+"</td><td><small><a href=javascript:update("+ rid +",2)>"+snm+"</td><td style=display:none>"+msr[4]+"</td><td style=display:none>"+msr[5]+"</td><td style=display:none>"+msr[6]+"</td><tdstyle=display:none>"+document.getElementById(con[0]+"ddlCtgry").value+"</td></tr>"
             document.getElementById(con[0]+"txtBranch").value=msr[2];  
             document.getElementById(con[0]+"txtPost").value=msr[3]; 
                  
            }
      
           st=st+"<table id='mytable' border=1 width='775px'><tr><td><small><b>Recommendation</b></td><td><small><b>Sanction</b></td></tr>"
           st1=st+st1+"</table>" 
           document.getElementById("row1").style.display="inline";  
           document.getElementById(con[0]+"Panel1").innerHTML=st1
}
function update(id,opn)
{

  document.getElementById(con[0]+"hidden1").value=id;
  if(opn==1)
  { //debugger;
    document.getElementById("rowrec").style.display="inline";
    document.getElementById("rowsan").style.display="none";
  
   }  
   else
   {
     document.getElementById("rowsan").style.display="inline";
     document.getElementById("rowrec").style.display="none";
   }   
}
function update_data(opt)
{ //debugger;
 var rowid=0;
 rowid=document.getElementById(con[0]+"hidden1").value;
 if (opt==1)//recom
 {
   if(document.getElementById(con[0]+"ddlRec").value==-1)
    {
      alert("Select Recommendation authority..!");
      return false;
    }
   document.getElementById("mytable").rows[rowid].cells[0].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlRec").options[document.getElementById(con[0]+"ddlRec").selectedIndex].text;
   document.getElementById("mytable").rows[rowid].cells[2].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlRec").value;
   
 } 
 else
 {
  if(document.getElementById(con[0]+"ddlSac").value==-1)
    {
      alert("Select Sanction authority..!");
      return false;
    }
  document.getElementById("mytable").rows[rowid].cells[1].innerHTML="<small><a href=javascript:update("+rowid+",2)>"+document.getElementById(con[0]+"ddlSac").options[document.getElementById(con[0]+"ddlSac").selectedIndex].text;
  document.getElementById("mytable").rows[rowid].cells[3].innerHTML="<small><a href=javascript:update("+rowid+",1)>"+document.getElementById(con[0]+"ddlSac").value;
 }
}
function cancel()
{
     document.getElementById("rowsan").style.display="none";
     document.getElementById("rowrec").style.display="none";
     document.getElementById(con[0]+"hidden1").value="";
}
function OnConfirm()
{
 var cnt;
 cnt=document.getElementById("mytable").rows.length;
 for(i=0;i<cnt-1;i++)
  {// debugger;
   if(document.getElementById(con[0]+"hidden2").value=="")
    {
     document.getElementById(con[0]+"hidden2").value=document.getElementById("mytable").rows[i+1].cells[2].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[3].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[4].innerText+"#"+document.getElementById(con[0]+"ddlCtgry").value;
    } 
    else
    {
     document.getElementById(con[0]+"hidden2").value=document.getElementById(con[0]+"hidden2").value+"@"+document.getElementById("mytable").rows[i+1].cells[2].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[3].innerText+"#"+document.getElementById("mytable").rows[i+1].cells[4].innerText+"#"+document.getElementById(con[0]+"ddlCtgry").value;
    }
  }
  // alert(document.getElementById(con[0]+"hidden2").value)
}
// ]]>
</script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4" style="height: 23px">
                    ASSIGN OTHER LEAVE AUTHORITY</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Employee</td>
                <td colspan="3" style="text-align: left">
                    <asp:DropDownList ID="ddl_emp" runat="server" Width="404px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Category</td>
                <td colspan="3" style="text-align: left">
                    <asp:DropDownList ID="ddlCtgry" runat="server" Width="404px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Branch</td>
                <td style="width: 100px; text-align: left;">
                    <input id="txtBranch" runat="server" style="width: 307px" type="text" readonly="readOnly" /></td>
                <td style="width: 100px">
                    Post</td>
                <td style="width: 100px">
                    <input id="txtPost" runat="server" style="width: 287px" type="text" readonly="readOnly" /></td>
            </tr>
            <tr id="row1" style="display:none">
                <td colspan="4" style="height: 41px">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="rowrec" style="display:none">
                <td colspan="4" style="height: 26px; text-align: left">
                    Recommendation &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlRec" runat="server" Width="312px">
                    </asp:DropDownList>
                    <input id="cmdrec" type="button" value="UPDATE" onclick="update_data(1)" />
                    <input id="cmdrcancel" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr id="rowsan" style="display:none">
                <td colspan="4" style="height: 28px; text-align: left">
                    Sanction &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:DropDownList ID="ddlSac" runat="server" Width="312px">
                    </asp:DropDownList>
                    <input id="cmdsan" type="button" value="UPDATE" onclick="update_data(2)" />
                    <input id="cmdscancel" type="button" value="CANCEL" onclick="cancel()" /></td>
            </tr>
            <tr>
                <td style="height: 28px; text-align: right;" colspan="2">
                    <input id="Hidden1" type="hidden" runat="server" />
                    <asp:Button ID="cmd_cfm" runat="server" Text="SUBMIT" OnClientClick="return OnConfirm()" /></td>
                <td colspan="2" style="height: 28px; text-align: left">
                    <input id="txtexit" style="width: 86px" type="button" value="EXIT" onclick="return txtexit_onclick()" />
                    <input id="Hidden2" runat="server" type="hidden" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

