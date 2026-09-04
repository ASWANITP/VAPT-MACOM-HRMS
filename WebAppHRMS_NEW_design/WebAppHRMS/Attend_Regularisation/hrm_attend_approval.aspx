<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_attend_approval.aspx.vb" Inherits="WebAppHRMS.Attend_Regularisation_hrm_attend_recommend_61b494ff6809" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt")
function btn_Exit_onclick() 
{
window.open('../home.aspx','_self')
}
    function FillEmployDetails()

{     data=document.getElementById(cont[0]+"cmb_Branch").value;
      var kk=document.getElementById(cont[0]+"cmb_Branch").options[document.getElementById(cont[0]+"cmb_Branch").selectedIndex].text
        Dt=kk.split("~")     
        ReqDt=Dt[1];
        document.getElementById(cont[0]+"hid_ReqDT").value=Dt[1];
        data=data+"%"+ReqDt+"%"+111;
        ToServer(data+"#"+1,1);
      
}

function disp()
{

   //debugger;
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    if (document.getElementById(cont[0]+"Hidden1").value=="")
    {  
        document.getElementById(cont[0]+"Panel1").innerHTML=""; 
        document.getElementById("row1").style.display="none";
        return;
    }
    st2=document.getElementById(cont[0]+"Hidden1").value.split("~")
    ar=st2.length-1;
    if(document.getElementById(cont[0]+"Hidden1").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("!")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>Emp Code</b></td><td><small><b>Emp Name</b></td><td><small><b>Punching Time</b></tr>"
        st1=st+st1+tot+"</table>" 
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("row1").style.display="inline";  
    document.getElementById(cont[0]+"Panel1").innerHTML=st1;
}


function FromServer (arg,context) 
{ 
//debugger;
 var Data=arg.split("@")
 switch (context)
 { 
  case 1:
        
        
        
        if(document.getElementById(cont[0]+"cmb_Branch").value==0)
           {
               document.getElementById("row1").style.display="none";
               document.getElementById(cont[0]+"txt_Reason").value="";
               return false;
           }
         else
         {
         Data1=Data[0].split("~")
         arg1=Data1[0].split("!")
         
         {               
         document.getElementById(cont[0]+"txt_Reason").value=arg1[3];
         document.getElementById("Hidden2").value=arg1[4];
         if (arg1[5]=="")
         {document.getElementById(cont[0]+"txt_AmReason").value='AM LEAVE'}
         else
         {
         document.getElementById(cont[0]+"txt_AmReason").value=arg1[5];}
         
         document.getElementById("Hidden3").value=arg1[6];
         //document.getElementById(cont[0]+"txt_HWreason").value=arg1[7];
         //document.getElementById("Hidden4").value=arg1[8];
         document.getElementById(cont[0]+"Hidden1").value=Data[0];
         document.getElementById("Hidden5").value=arg1[7];
         disp();
         break;
        }
        }
        
  case 2:
          alert(arg) ;
          window.open('hrm_attend_approval.aspx','_self')  ;
          break; 
  }      
}
function CheckLength(Control,MaxNum)
{      
     if(Control.value.length<=MaxNum)
     {return true;}
     else
     {
        alert("Only "+MaxNum +" Characters Allowed...!!!");
        return false;
     }
}


function OnClickReject()
{   
        //debugger;          
        var Status=2;
        var brid=document.getElementById(cont[0]+"cmb_branch").value;
        var requester=document.getElementById("Hidden2").value;
        var recomm=document.getElementById("Hidden3").value;    
        //var hw=document.getElementById("Hidden4").value;       
        var reqdate=document.getElementById("Hidden5").value;         
       ToData = Status+"%"+brid+"%"+requester+"%"+recomm+"%"+reqdate;
       ToServer(ToData+"#"+2,2)
}
function OnClickConfirm()
 {
       
       //debugger;
       
        if (document.getElementById(cont[0]+"txt_AmReason").value=="")
          {
           alert("Enter Recommend Reason...!!!");
           document.getElementById(cont[0]+"txt_AmReason").focus();
           return false;
           }
           
        var Status=1;
        var brid=document.getElementById(cont[0]+"cmb_branch").value;
        var requester=document.getElementById("Hidden2").value;
        var recomm=document.getElementById("Hidden3").value;  
        //var hw=document.getElementById("Hidden4").value;   
        var reqdate=document.getElementById("Hidden5").value;       
       ToData = Status+"%"+brid+"%"+requester+"%"+recomm+"%"+reqdate;
       ToServer(ToData+"#"+2,2)
}

function textupper(name)
{
    document.getElementById(cont[0]+name).value=document.getElementById(cont[0]+name).value.toUpperCase();
    return true;
}  
// ]]>
</script>

    <div style="text-align: center">
        <input id="Hidden1" runat="server" type="hidden" style="width: 1px" />
        <input id="Hidden2" type="hidden" style="width: 1px" />
        <input id="Hidden3" type="hidden" style="width: 1px" />
        <asp:HiddenField ID="hid_s" runat="server" />
        <table border="1" style="width: 57%; height: 1px">
            <caption>
                <strong><span style="color: #660033">ATTENDANCE REGULARISATION RECOMMEND </span></strong>
            </caption>
            <tr>
                <td style="height: 13px; text-align: center;" colspan="2">
                    Branch &nbsp;</td>
                <td style="height: 13px; text-align: left;" colspan="2">
                    <asp:DropDownList ID="cmb_Branch" runat="server" onchange="FillEmployDetails()" Font-Names="Times New Roman" Font-Size="Medium"
                        Width="318px">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="height: 9px; text-align: center;" colspan="2">
                    Request Reason &nbsp;</td>
                <td style="height: 9px; text-align: left;" colspan="2">
    <asp:TextBox ID="txt_Reason" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
        ReadOnly="True" Width="311px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 9px; text-align: center">
                    AM/AH Recommended Reason</td>
                <td colspan="2" style="height: 9px; text-align: left">
                    <asp:TextBox ID="txt_AmReason" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        ReadOnly="True" Width="311px"></asp:TextBox></td>
            </tr>
            <tr id="row1" style="display:none">
                <td colspan="4" style="height: 5px">
                    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                    </asp:Panel>
                    &nbsp; &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 4px" colspan="4">
                    <input id="btn_Recommend" onclick="return OnClickConfirm()" style="font-size: 12pt; font-family: 'Times New Roman'; width: 119px;"
                        type="button" value="Approval" />
                    <input id="btn_Reject" onclick="return OnClickReject()" style="font-size: 12pt; width: 112px; font-family: 'Times New Roman'"
                        type="button" value="Reject" />
                    <input id="btn_Exit" style="font-size: 12pt; width: 108px; font-family: 'Times New Roman'"
                        type="button" value="Exit" onclick="return btn_Exit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%; height: 4px">
                    <input id="hid_ReqDT" runat="server" type="hidden" /></td>
                <td style="width: 10%; height: 4px">
                </td>
                <td style="width: 10%; height: 4px">
                </td>
                <td style="width: 10%; height: 4px">
                </td>
            </tr>
        </table>
    </div>
    <input id="hid_area" runat="server" type="hidden" style="width: 4px" />
    <input id="Hidden4" style="width: 1px" type="hidden" />
    <input id="Hidden5" type="hidden" />
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
    <br />
    <asp:HiddenField ID="hid_zonal" runat="server" />
</asp:Content>

