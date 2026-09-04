<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="ADDSUPERIOR.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_ADDSUPERIOR_28f54fb89270" title="Untitled Page"  EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split('txt')
function btn_Exit_onclick() 
{
window.open('../home.aspx','_self')
}
function OnClickRadioAdd()
{ 
      var Status="-22";
      ToServer(Status+"#"+1,1);
}
function OnClickRadioEdit()
{  
      var Status="-33";
      ToServer(Status+"#"+1,1);
}
function OnClickRadioDelete()
{
      var Status="-44";
      ToServer(Status+"#"+1,1);
}

function FillEmployDetails()
{     data=document.getElementById(cont[0]+"cmb_Select").value;
      data=data+"%"+222;
      ToServer(data+"#"+2,2);
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


function FromServer (arg,context) 
{var Data = arg.split("@") ;             
       //debugger;  
  switch (context)
   {
   
     case 1:       
                document.getElementById(cont[0]+"cmb_select").options.length=0;
                if (Data[0]=="") { alert("No Employee ..!!!"); return false; }
                ComboFill(Data[0],"cmb_select"); 
                
                Data1=Data[1].split("!");
                arg1=Data[1]  ;
           {    
                document.getElementById(cont[0]+"txt_Code").value=Data1[0];
                document.getElementById(cont[0]+"txt_Name").value=Data1[1];
                document.getElementById(cont[0]+"txt_Desig").value=Data1[2];
                document.getElementById(cont[0]+"txt_Depart").value=Data1[3];
                document.getElementById(cont[0]+"txt_Post").value=Data1[4];
           } 
                break;
     case 2:
                Data1=Data[1].split("!")
                arg1=Data[1]  
           {    
                document.getElementById(cont[0]+"txt_Code").value=Data1[0];
                document.getElementById(cont[0]+"txt_Name").value=Data1[1];
                document.getElementById(cont[0]+"txt_Desig").value=Data1[2];
                document.getElementById(cont[0]+"txt_Depart").value=Data1[3];
                document.getElementById(cont[0]+"txt_Post").value=Data1[4];
           }
                document.getElementById(cont[0]+"cmb_Superior").options.length=0;
                if (Data[0]=="") { alert("No Employee ..!!!"); return false; }
                ComboFill(Data[0],"cmb_Superior");  
                break;
     case 3:  
                if(document.getElementById(cont[0]+"txt_Code").value=="")
                {
                    alert("Select Employee...!!!");
                    return false;                               
                }
                alert(arg) ;
                window.open('ADDSUPERIOR.aspx','_self')  ;
                break; 
    }
}
function OnClickConfirm()
{   
        var EmpCode=document.getElementById(cont[0]+"cmb_Select").value;
        var SupCode=document.getElementById(cont[0]+"cmb_Superior").value;
        
        if (document.getElementById(cont[0]+"rbt_Add").checked==true)
          Status=1;
        if (document.getElementById(cont[0]+"rbt_edit").checked==true)   
          Status=2;
        if (document.getElementById(cont[0]+"rbt_Delete").checked==true)   
          Status=3;
         
       ToData = EmpCode+"%"+SupCode+"%"+Status;
       ToServer(ToData+"#"+3,3)
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <div style="text-align: center">
                    <div style="text-align: center">
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <table border="1" style="width: 88%; height: 206px;">
                            <tr>
                                <td colspan="4">
                                    <asp:RadioButton ID="rbt_Add" runat="server" GroupName="a" Text="ADD" Checked="True" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:RadioButton ID="rbt_Edit" runat="server" GroupName="a" Text="EDIT" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RadioButton ID="rbt_Delete" runat="server"
                                        GroupName="a" Text="DELETE" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Select Employee</td>
                                <td colspan="2">
                                    &nbsp;<asp:DropDownList ID="cmb_Select" onclick="FillEmployDetails()" runat="server" Width="450px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 17%; text-align: left">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;Emp Code</td>
                                <td style="width: 15%">
                                    <asp:TextBox ID="txt_Code" runat="server" ReadOnly="True" Width="181px"></asp:TextBox></td>
                                <td style="width: 15%">
                                    Emp Name</td>
                                <td style="width: 15%">
                                    <asp:TextBox ID="txt_Name" runat="server" ReadOnly="True" Width="219px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 17%; text-align: left">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Designation&nbsp;</td>
                                <td style="width: 15%">
                                    <asp:TextBox ID="txt_Desig" runat="server" ReadOnly="True" Width="179px"></asp:TextBox></td>
                                <td style="width: 15%">
                                    Department</td>
                                <td style="width: 15%">
                                    <asp:TextBox ID="txt_Depart" runat="server" ReadOnly="True" Width="219px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 17%; height: 28px; text-align: left;">
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;Post</td>
                                <td style="width: 15%; height: 28px">
                                    <asp:TextBox ID="txt_Post" runat="server" ReadOnly="True" Width="179px"></asp:TextBox></td>
                                <td style="height: 28px" colspan="2">
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 23px">
                                    Select Superior ID</td>
                                <td colspan="2" style="height: 23px">
                                    &nbsp;<asp:DropDownList ID="cmb_Superior" runat="server" Width="452px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 23px; text-align: center;" colspan="4">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;
                                    <input id="btn_Confirm" style="width: 95px" type="button" value="CONFIRM" onclick="OnClickConfirm()" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<input id="btn_Exit" style="width: 84px" type="button" value="EXIT" onclick="return btn_Exit_onclick()" />
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_Select">
                        </cc1:ListSearchExtender>
                        <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="cmb_Superior">
                        </cc1:ListSearchExtender>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

