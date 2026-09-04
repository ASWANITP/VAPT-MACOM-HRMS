
<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="ho_for_br.aspx.vb" Inherits="WebAppHRMS.punching_ho_for_br_634273e19131" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
   <script type="text/javascript">
var cont=cont_name.split("txt")
function checkid(id)
{
   var main,tos
   if (document.getElementById(cont[0]+id).value=="")
    {
    }
   else
   {
     check_emp(id)
   }
}
function btn_check()
{
   if(document.getElementById(cont[0]+"txt_date").value=="") 
    {
     alert("Select Date")
     return false
    }
  if(document.getElementById(cont[0]+"RadioButton1").checked==false)
    {
     if(document.getElementById(cont[0]+"RadioButton2").checked==false)     
        {
          alert("Select Morning Or Evening")
          return false
        }  
    }
   if(document.getElementById(cont[0]+"Panel1").value=="")
    {
    alert("Could not Confirm")
    return false
    }  
  else
   return true  
}
function check_emp(id)
{
    
     var str;    
     var st;
     var flag
     flag=1
     if(document.getElementById(cont[0]+"Hid_id").value=="")
     {
     
       if(document.getElementById(cont[0]+id).value=="__:__:__")
       {
         alert("Enter Time")
         return false
       }
       else
       {
         check_time(id)
       }  
     }
     else
     {
      st=document.getElementById(cont[0]+"Hid_id").value.split("@")
      for (funi=0;funi<st.length;funi++)
        {
        if(id==st[funi])
         {
         // flag=0
          flag=1
         // return false
         }
       }  
    if(flag=1)
     {
       
       if(document.getElementById(cont[0]+id).value=="__:__:__")
        {
          alert("Enter Time")
          return false
        }   
       else
        {
        check_time1(id)
        }
     
     }
    }
}
function check_time(id)
{
 var st,flag
  flag=1
  st=document.getElementById(cont[0]+id).value.split(":")
  for (funi=0;funi<st.length;funi++)
        {
        if(st[funi]=="__")
         {
           if(funi==0)
            {
            alert("Hour is not correct.Enter it once more")
            flag=0
            return false
            }
           if(funi==1)
            {
            flag=0
            alert("minit is not correct.Enter it once more")
            return false
            }
           if(funi==2)
            {
            flag=0
            alert("Second is not correct.Enter it once more")
            return false
            }
         }
       } 
        if(flag=1)
         {
         document.getElementById(cont[0]+"hid_time").value=document.getElementById(cont[0]+"hid_time").value+":"+document.getElementById(cont[0]+id).value
         document.getElementById(cont[0]+"Hid_id").value=id
         str=id+"*"+document.getElementById(cont[0]+id).value 
         alert(str)
         document.getElementById(cont[0]+"Hidden1").value=str     
         }
}
function check_time1(id)
{
 var st,flag
 flag=1
  st=document.getElementById(cont[0]+id).value.split(":")
  for (funi=0;funi<st.length;funi++)
        {
        if(st[funi]=="__")
         {
           if(funi==0)
            {
            flag=0
            alert("Hour is not correct.Enter it once more")
            return false
            }
           if(funi==1)
            {
            flag=0
            alert("minit is not correct.Enter it once more")
            return false
            }
           if(funi==2)
            {
            flag=0
            alert("Second is not correct.Enter it once more")
            return false
            }
         }
       }  
    if(flag=1)
     {
       document.getElementById(cont[0]+"hid_time").value=document.getElementById(cont[0]+"hid_time").value+":"+document.getElementById(cont[0]+id).value
       document.getElementById(cont[0]+"Hid_id").value=document.getElementById(cont[0]+"Hid_id").value+"@"+id
       str=id+"*"+document.getElementById(cont[0]+id).value     
       document.getElementById(cont[0]+"Hidden1").value=document.getElementById(cont[0]+"Hidden1").value+"!"+str
       alert(str)
     }   
}
function btn_check_time(str)
{
  var st,flag
  flag=1
  st=str.value.split(":")
  for (funi=0;funi<st.length;funi++)
        {
        if(st[funi]=="__")
         {
           if(funi==0)
            {
            alert("Hour is not correct.Enter it once more")
            flag=0
            return false
            }
           if(funi==1)
            {
            flag=0
            alert("minit is not correct.Enter it once more")
            return false
            }
           if(funi==2)
            {
            flag=0
            alert("Second is not correct.Enter it once more")
            return false
            }
         }
       } 
   if(flag=1)
    {
     document.getElementById(cont[0]+"Hid_id").value=id
     str=id+"*"+document.getElementById(cont[0]+id).value 
     document.getElementById(cont[0]+"Hidden1").value=str     
    }
}
</script>
    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>&nbsp;
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 792px; POSITION: static; HEIGHT: 51px" border=1><TBODY><TR><TD colSpan=5><SPAN style="TEXT-DECORATION: underline"><strong>BRANCH&nbsp;&nbsp;PUNCH</strong></SPAN></TD></TR><TR><TD colSpan=5><asp:Label style="POSITION: static" id="Label1" runat="server" Width="540px"></asp:Label></TD></TR><TR><TD style="WIDTH: 193px; HEIGHT: 28px" colSpan=2><STRONG>Select Morning/evening</STRONG></TD><TD style="HEIGHT: 28px; TEXT-ALIGN: center" colSpan=3><asp:RadioButton style="POSITION: static" id="RadioButton1" runat="server" Text="MORNING" Font-Bold="True" AutoPostBack="True" GroupName="raj" OnCheckedChanged="RadioButton1_CheckedChanged"></asp:RadioButton> <asp:RadioButton style="POSITION: static" id="RadioButton2" runat="server" Text="EVENING" Font-Bold="True" AutoPostBack="True" GroupName="raj" OnCheckedChanged="RadioButton2_CheckedChanged"></asp:RadioButton></TD></TR><TR><TD style="WIDTH: 193px; HEIGHT: 28px" id="TD1" colSpan=2 runat="server"><asp:Label style="POSITION: static" id="Label2" runat="server" Width="102px" Text="Select Date" Font-Bold="True"></asp:Label></TD><TD style="HEIGHT: 28px; TEXT-ALIGN: center" id="TD2" colSpan=3 runat="server"><asp:TextBox style="POSITION: static" id="txt_date" runat="server" Font-Bold="True" AutoPostBack="True" OnTextChanged="txt_date_TextChanged"></asp:TextBox>&nbsp;</TD></TR><TR><TD style="WIDTH: 193px; HEIGHT: 28px" colSpan=2><STRONG>Select Branch</STRONG></TD><TD style="HEIGHT: 28px; TEXT-ALIGN: center" colSpan=3><asp:DropDownList style="POSITION: static" id="cmb_branch" runat="server" Width="270px" AutoPostBack="True" OnSelectedIndexChanged="cmb_branch_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;&nbsp; <asp:TextBox style="POSITION: static" id="txt_hid" runat="server" Width="1px" Visible="False"></asp:TextBox> <INPUT style="WIDTH: 1px; POSITION: static" id="Hidden1" type=hidden runat="server" /> <INPUT style="WIDTH: 1px; POSITION: static" id="Hid_id" type=hidden runat="server" /> <INPUT style="WIDTH: 1px; POSITION: static" id="hid_time" type=hidden runat="server" />
    <asp:TextBox ID="txt_cntd" runat="server" Style="position: static" Visible="False"
        Width="1px"></asp:TextBox>
    <asp:TextBox ID="txt_cnt" runat="server" Style="position: static" Visible="False"
        Width="1px"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 59px" colSpan=5><asp:Panel style="POSITION: static" id="Panel1" runat="server" Width="125px" Height="50px">
                    </asp:Panel>&nbsp;&nbsp; </TD></TR><TR><TD colSpan=5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button style="POSITION: static" id="Button1" onclick="Button1_click" runat="server" Width="135px" Text="Confirm" Font-Bold="True" ></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button style="POSITION: static" id="Button2" runat="server" Width="61px" Text="Exit" Font-Bold="True" OnClick="Button2_Click"></asp:Button> <cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_date"></cc1:CalendarExtender> <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmb_branch"></cc1:ListSearchExtender></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

