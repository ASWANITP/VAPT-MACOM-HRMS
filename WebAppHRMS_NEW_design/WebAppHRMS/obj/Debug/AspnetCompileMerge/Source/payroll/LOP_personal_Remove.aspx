<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="LOP_personal_Remove.aspx.vb" Inherits="WebAppHRMS.LOP_to_Personal_Account_LOP_Remove_d7419c009593" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
var cont_name=header.split('cmb');

function ClassOnChange()

{

    document.getElementById(cont_name[0]+"hdn1").value=document.getElementById(cont_name[0]+"cmb_emp").value;
    
    if (document.getElementById(cont_name[0]+"hdn1").value==-1)
    { 
        document.getElementById("row1").style.display='none';
        return false;
    }
    if(document.getElementById(cont_name[0]+"hdn1").value!=-1)
    {
        callserver("2$"+document.getElementById(cont_name[0]+"cmb_emp").value,2);  
    }
}
function call_receiver(arg,context) 
{  
  
  switch (context)
  { 
    case 1:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"cmb_emp").options.length=0;
        if (dist[0]=="")
         {  alert("No Details ..!!!");
           return false; 
         }
          ComboFill(dist[0],"cmb_emp"); 
        break;
    } 
    case 2: 
    {       

        var data = arg.split("@"); 
        if(document.getElementById(cont_name[0]+"hdn1").value==-1)
        {
               document.getElementById("row1").style.display='none';
               return false;
              
        }
        else
        {   
        
            document.getElementById("row1").style.display='inline';                 
            document.getElementById(cont_name[0]+"Hidden2").value=data[0];
            if(document.getElementById(cont_name[0]+"Hidden2").value=="")
            {
                alert("No Data......!!!");
                document.getElementById("row1").style.display='none';
                
            }
            else
            {
//                document.getElementById(cont_name[0]+"txtfdt").value='';
//                document.getElementById(cont_name[0]+"txttdt").value='';
//                document.getElementById(cont_name[0]+"ddlmanual").value=-1;
                disp(); 
            }
        }
        break;
    }
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

    if (document.getElementById(cont_name[0]+"hdn1").value==-1)
    {  
        document.getElementById(cont_name[0]+"pnl1").innerHTML=""; 
        document.getElementById("row1").style.display="none";
        return false;
    }
    st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
    ar=st2.length-1;
    if(document.getElementById(cont_name[0]+"Hidden2").value!="")
    {
        for(k=0;k<ar;k++)
        {
        
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td><td><input type='checkbox' id='chkm_"+k+"' name='txtm_"+k+"'></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='840px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;FROM_DATE&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;TO_DATE&nbsp;&nbsp;</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(cont_name[0]+"pnl1").innerHTML=st1;
}

function btnsend_onclick() 
{

   if(document.getElementById(cont_name[0]+"hdn1").value=="")
   {
        alert("Please Select Employee Code....!");
        document.getElementById(cont_name[0]+"cmb_emp").focus();
        return false;
   }
   
    if (document.getElementById(cont_name[0]+"Hidden2").value !="")
    {  
        var st3 = "";
        var st2=document.getElementById(cont_name[0]+"Hidden2").value.split("!")
        var ar=st2.length
        for(i=0;i<ar-1;i++)
        {
            st3=st2[i].split("*")
            var Regular = "T";
            if (document.getElementById("chkm_"+i+"").checked==false)  Regular= "F";
            if (document.getElementById("chkm_"+i+"").checked==true )  Regular= "T"; 
//            document.getElementById(cont_name[0]+"Hidden3").value += st3[0] + "^" +st3[1] + "^" +st3[2] + "^" + st3[3] + "^" +Regular+"#" ; 
            document.getElementById(cont_name[0]+"Hidden3").value += st3[0] +"^" +st3[1] +"^" +st3[2] +"^" +Regular+"#" ; 
            document.getElementById(cont_name[0]+"Hidden4").value ="#" + document.getElementById(cont_name[0]+"Hidden3").value;
        }
    }
}
//function window_onload() 
//{
//    document.getElementById("row1").style.display='none';
//}
// ]]>
</script>

    <br />
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>&nbsp;<asp:HiddenField ID="Hidden4" runat="server" />
        <asp:HiddenField ID="Hidden3" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="hdn1" runat="server" />
        <table border="1" style="width: 514px; height: 74px">
            <tr>
                <td style="width: 206px; text-align: right">
                    Select Employee:&nbsp;
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="350px" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                </td>
            </tr>
            <tr id="row1">
                <td colspan="4" style="text-align: left">
                    <asp:Panel ID="pnl1" runat="server" Style="position: relative">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 206px; text-align: right">
                    <input id="cmd_exit" style="width: 84px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px; text-align: left">
                    &nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" OnClientClick ="return btnsend_onclick()" /></td>
            </tr>
        </table>
        <cc1:listsearchextender id="ListSearchExtender1" runat="server" targetcontrolid="cmb_emp"></cc1:listsearchextender>
    </div>
</asp:Content>

