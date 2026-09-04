<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Add_Post.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_hrm_Add_Post_521c77fd3783" title="Untitled Page" EnableEventValidation="false"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt")

function Button2_onclick()
{
 window.open('../home.aspx','_self')
}
function isNumberKey(ids)
{ //debugger;
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

function FillEmployDetails()
{
      data=document.getElementById(cont[0]+"txt_EmpCode").value;
      data=data+"%"+111;
      ToServer(data+"#"+1,1);

}

function FromServer (arg,context)
{
//debugger;
 var Data=arg.split("@")
 switch (context)
 {
  case 1:
        if (Data[0]=="")
        {alert("Please Enter Correct Employee Code!!!"); document.getElementById(cont[0]+"txt_EmpCode").value="";return false;}
if(document.getElementById(cont[0]+"txt_EmpCode").value<10000 ||document.getElementById(cont[0]+"txt_EmpCode").value=="")
           {
document.getElementById("row1").style.display="none";
               alert("Please Enter Correct Employee Code!!!")
               return false;
           }
         else
         {
             Data1=Data[0].split("~")
             arg1=Data1[0].split("!")
document.getElementById(cont[0]+"Hidden1").value=Data[0];
             disp();
             break;
         }

  case 2:
          document.getElementById("row4").style.display="inline";
          document.getElementById("row2").style.display="none";
document.getElementById("row3").style.display="none";
document.getElementById(cont[0]+"cmb_select").options.length=0;
          if (Data[0]=="") { alert("No Details ..!!!"); return false; }
          ComboFill(Data[0],"cmb_select");
          break;
  case 3:
          alert(arg) ;
          window.open('hrm_Add_Post.aspx','_self');
          break;
  }
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
        for(kk=0;kk<ar;kk++)
        {
            st3=st2[kk].split("!")
st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1] +"</td><td><small>"+st3[2]+"</td><td><small>"+st3[3]+"</td><td><small>"+st3[4]+"</td><td><small>"+st3[5]+"</td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr ><td><small><b>EMP NAME</b></td><td><small><b>D O J</b></td><td><small><b>POST</b></td><td><small><b>DESIGNATION</b></td><td><small><b>DEPARTMENT</b></td><td><small><b>SALARY</b></td></tr>"
        st1=st+st1+tot+"</table>"
    }
    else
    {
        st1=st+"</table>";
    }
    document.getElementById("row1").style.display="inline";
    document.getElementById(cont[0]+"Panel1").innerHTML=st1;
}
function OnClickRadioDate()
{
      document.getElementById("row4").style.display="none";
      document.getElementById("row2").style.display="inline";
      document.getElementById("row3").style.display="none";
      document.getElementById(cont[0]+"txt_Date").focus();

}
function OnClickRadioPost()
{
      var Status="-33";
      ToServer(Status+"#"+2,2);
}
function OnClickRadioDesig()
{
      var Status="-44";
      ToServer(Status+"#"+2,2);
}

function OnClickRadioDep()
{
      var Status="-55";
      ToServer(Status+"#"+2,2);
}
function OnClickRadioSalary()
{
      document.getElementById("row4").style.display="none";
      document.getElementById("row2").style.display="none";
      document.getElementById("row3").style.display="inline";
      document.getElementById(cont[0]+"txt_Salary").focus();
}
function OnClickRadioCode()
{
//      var Status="-77";
//      ToServer(Status+"#"+2,2);
      document.getElementById("row4").style.display="none";
      document.getElementById("row2").style.display="none";
      document.getElementById("row3").style.display="none";
}
function ComboFill(Data,ComboName)
{
       if (Data[0] == '') return;

       var rows = Data.split("*");
       for(a=0; a<rows.length; a++)
   {
      var cols      = rows[a].split("$");
      var option1   = document.createElement("OPTION");
      option1.value = cols[0];
      option1.text  = cols[1];
      document.getElementById(cont[0]+ComboName).add(option1);
   }

}

function OnkeyUpChqDate(Control)
{
  if (document.getElementById(cont[0]+Control).value!="")
  {
   alert("Select Date from Calender ..!!!!");
document.getElementById(cont[0]+Control).value=document.getElementById(cont[0]+"hdn_sysdate").value;
  }
}
function Enter()
{
   //debugger;
   if (event.which == 13 || event.keyCode == 13)
     {
      FillEmployDetails();
     }

}

function OnClickConfirm()
{
        var EmpCode=document.getElementById(cont[0]+"txt_EmpCode").value;
        var Post=document.getElementById(cont[0]+"cmb_Select").value;
        var JoinDate=document.getElementById(cont[0]+"txt_Date").value;
        var Salary=document.getElementById(cont[0]+"txt_Salary").value;
        if (document.getElementById(cont[0]+"rdb_Join").checked==true)
          Status=1;
        if (document.getElementById(cont[0]+"rdb_Post").checked==true)
          Status=2;
        if (document.getElementById(cont[0]+"rdb_Desig").checked==true)
          Status=3;
        if (document.getElementById(cont[0]+"rdb_Dept").checked==true)
          Status=4;
        if (document.getElementById(cont[0]+"rdb_Salary").checked==true)
          Status=5;
        if (document.getElementById(cont[0]+"rdb_Cancel").checked==true)
          Status=6;

       ToData = EmpCode+"%"+Post+"%"+JoinDate+"%"+Salary+"%"+Status;
       ToServer(ToData+"#"+3,3)
}
// ]]>
</script>

    <div style="text-align: center">
        &nbsp;<table border="1" style="width: 59%; height: 147px;">
            <tr>
                <td colspan="2">
                    Enter Emp Code</td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txt_EmpCode" onkeypress="return isNumberKey(3)" onchange="FillEmployDetails()" runat="server" Width="229px" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr id="row1" style="display:none">
                <td colspan="5" style="height: 73px">
                    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:RadioButton ID="rdb_Join" runat="server" Text="Join Date" Width="99px" GroupName="a" />
                    <asp:RadioButton ID="rdb_Post" runat="server" Text="Post" Width="87px" GroupName="a" />
                    &nbsp; &nbsp;<asp:RadioButton ID="rdb_Desig" runat="server" Text="Designation" Width="130px" GroupName="a" />
                    &nbsp;<asp:RadioButton ID="rdb_Dept" runat="server" Text="Department" Width="111px" GroupName="a" />&nbsp;
                    <asp:RadioButton ID="rdb_Salary" runat="server" Text="Salary" Width="80px" GroupName="a" />&nbsp;
                    <asp:RadioButton ID="rdb_Cancel" runat="server" Text="Cancel Emp Code" Width="146px" GroupName="a" /></td>
            </tr>
            <tr id="row4" style="display:none;">
                <td colspan="2" style="height: 8px; text-align: right;">
                    Select&nbsp; &nbsp;</td>
                <td colspan="3" style="text-align: left; height: 8px;">
                    <asp:DropDownList ID="cmb_Select" runat="server" Width="364px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row2" style="display:none;">
                <td colspan="2" style="height: 10px">
                    Select Date</td>
                <td style="text-align: left; height: 10px;" colspan="3">
                    <asp:TextBox ID="txt_Date" runat="server" Width="233px" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr id="row3" style="display:none;">
                <td colspan="2" style="height: 10px">
                    Enter Salary</td>
                <td colspan="3" style="height: 10px; text-align: left">
                    <asp:TextBox ID="txt_Salary" onkeypress="return isNumberKey(3)" runat="server" MaxLength="10" Width="233px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 4px;" colspan="5">
                    <input id="Button3" onclick="OnClickConfirm()" type="button" value="CONFIRM" />&nbsp;
                    <input id="Button2" style="width: 86px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 10%">
                </td>
            </tr>
            <tr>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
                <td style="width: 10%; height: 23px;">
                </td>
            </tr>
        </table>
    </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_Date"></cc1:calendarextender>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    &nbsp;
    <input id="Hidden1" runat="server" type="hidden" />
    <input id="hdn_sysdate" runat="server" type="hidden" />
</asp:Content>

