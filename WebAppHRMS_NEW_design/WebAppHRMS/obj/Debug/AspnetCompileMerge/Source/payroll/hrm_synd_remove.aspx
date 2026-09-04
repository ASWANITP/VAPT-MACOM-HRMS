<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_synd_remove.aspx.vb" Inherits="WebAppHRMS.Honey_Payroll_hrm_synd_remove_e39993ae4772" title="Untitled Page" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[


var cont_name=header.split('Cmb');
function ClassOnChange()

{

    document.getElementById(cont_name[0]+"hdn1").value=document.getElementById(cont_name[0]+"Cmb_emp").value;
    
    if (document.getElementById(cont_name[0]+"hdn1").value==-1)
    { 
        document.getElementById("row1").style.display='none';
        return false;
    }
    if(document.getElementById(cont_name[0]+"hdn1").value!=-1)
    {
        callserver("2$"+document.getElementById(cont_name[0]+"Cmb_emp").value,2);  
    }
}
function call_receiver(arg,context) 
{  
  
  switch (context)
  { 
    case 1:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"Cmb_emp").options.length=0;
        if (dist[0]=="")
         {  alert("No Details ..!!!");
           return false; 
         }
          ComboFill(dist[0],"Cmb_emp"); 
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
        document.getElementById(cont_name[0]+"pnl").innerHTML=""; 
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
          st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='840px' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP NAME&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;A/C&nbsp;Number&nbsp;&nbsp;</b></td></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(cont_name[0]+"pnl").innerHTML=st1;
}
function cmd_exit_onclick(){
window.open('../home.aspx','_self');
}
function button1_onclick() 
{

   if(document.getElementById(cont_name[0]+"hdn1").value=="")
   {
        alert("Please Select Employee Code....!");
        document.getElementById(cont_name[0]+"cmb_emp").focus();
        return false;
   }
}



</script>
    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="hdn1" runat="server" />
        <table style="width: 488px; height: 112px" border="1">
            <caption style="text-align: center">
               
                SYNDICATE A/C NUMBER REMOVAL</caption>
            <tr>
                <td style="width: 134px">
                    <strong>
                    Select Employee</strong></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="Cmb_emp" runat="server" Height="22px" Width="308px">
                    </asp:DropDownList>
                    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_emp">
                    </cc1:ListSearchExtender>
                </td>
            </tr>
            <tr id="row1">
                <td colspan="2">
                    <asp:Panel ID="pnl" runat="server" Height="10px" Width="100px">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 134px">
                </td>
                <td style="width: 100px">
                    &nbsp;<table style="width: 262px; height: 38px">
                        <tr>
                            <td style="width: 100px">
                                <asp:Button ID="Button1" runat="server" Text="REMOVE" Width="109px" OnClientClick="return button1_onclick()" /></td>
                            <td style="width: 100px">
                                <input id="cmd_exit" runat="server" type="button" value="EXIT" style="width: 110px" onclick ="return cmd_exit_onclick()"  /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

