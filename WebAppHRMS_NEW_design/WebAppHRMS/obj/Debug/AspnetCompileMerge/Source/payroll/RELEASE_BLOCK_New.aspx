<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="RELEASE_BLOCK_New.aspx.vb" Inherits="WebAppHRMS.RELEASE_BLOCK_New_cb83f1319890" title="Relese Punch Block New" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cs = cont_name.split("lst_emp");
function call_receiver(arg1)
{
    var arg10=arg1.split("^")

    if (arg10[1]==2)
    {
        var rs1=arg10[0].split("!");
        document.getElementById("cmd_insert").style.display="none";
        document.getElementById(cs[0]+"lst_emp").options.length=0;
        document.getElementById(cs[0]+"cmb_emp").options.length=0;
        document.getElementById(cs[0]+"Hidden2").value="";
        for (h=0;h<rs1.length-1;h++)
        {	  
            var em=rs1[h].split("*");
            var option2 = document.createElement("OPTION");
            option2.value =em[0];
            option2.text  =em[1];
            document.getElementById(cs[0]+"cmb_emp").add(option2);
        }
        document.getElementById("cmd_insert").style.display="inline";
    }
}
function listadd()
{
    document.getElementById("txt_del").style.display="inline";
    if (document.getElementById(cs[0]+"cmb_emp").value==-1)
    {
        alert("Select employee");
        return false;
    }
    debugger;
    for(b=0;b<document.getElementById(cs[0]+"lst_emp").options.length;b++)
    {
        if(document.getElementById(cs[0]+"lst_emp").options[b].value==document.getElementById(cs[0]+"cmb_emp").value)
        {
            alert("Already Added");
            return false;
        }
    }
    var option1=document.createElement("OPTION")
    option1.text=option1.text+document.getElementById(cs[0]+"cmb_emp").options[document.getElementById(cs[0]+"cmb_emp").selectedIndex].text;
    option1.value=document.getElementById(cs[0]+"cmb_emp").value;
    if(document.getElementById(cs[0]+"Hidden2").value=="")
    {
        document.getElementById(cs[0]+"Hidden2").value=document.getElementById(cs[0]+"cmb_emp").value;
    }
    else
    {           
        document.getElementById(cs[0]+"Hidden2").value=document.getElementById(cs[0]+"Hidden2").value+"#"+document.getElementById(cs[0]+"cmb_emp").value;
    }
    document.getElementById(cs[0]+"lst_emp").options.add(option1);
}
function del()
{
    var count; 
    for(count =document.getElementById(cs[0]+"lst_emp").options.length-1;count>=0;count--) 
    {
        if(document.getElementById(cs[0]+"lst_emp").options[count].selected) 
        {
            var ar=document.getElementById(cs[0]+"Hidden2").value.split("#")
            document.getElementById(cs[0]+"Hidden2").value=""
            for(n=0;n<ar.length;n++)
            {
                if(ar[n]!=document.getElementById(cs[0]+"lst_emp").options[count].value)
                {
                    if(document.getElementById(cs[0]+"Hidden2").value=="")
                    {
                       document.getElementById(cs[0]+"Hidden2").value=ar[n]
                    }
                    else
                    {
                       document.getElementById(cs[0]+"Hidden2").value=document.getElementById(cs[0]+"Hidden2").value+"#"+ar[n]
                    }
                }
            }
            document.getElementById(cs[0]+"lst_emp").remove(count);    
        } 
    } 
    if(document.getElementById(cs[0]+"lst_emp").options.length==0)
    {
       document.getElementById("txt_del").style.display="none";
    }
    else
    {
       document.getElementById("txt_del").style.display="inline";
    }
}
function da()
{
      alert('Please Enter Date using Calendar!!');
      document.getElementById(cs[0]+"Txt_dt").value="";
  
}
function fill()
{
   document.getElementById("cmd_insert").style.display="none";
   call_server("1@"+document.getElementById(cs[0]+"cmb_block").value+"@"+document.getElementById(cs[0]+"Txt_dt").value);
}
function cmd_exit_onclick() 
{
    window.open('../home.aspx','_self');
}
</script>

    <div style="text-align: center">
        <table style="width: 649px">
            <tr>
                <td colspan="4" style="height: 21px">
                    <strong><span style="color: #ff0033">Punch BLOCK Release - II<asp:ScriptManager ID="ScriptManager1"
                        runat="server">
                    </asp:ScriptManager>
                    </span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 21px">
                    <table>
                        <tr>
                <td style="width: 100px">
                    <strong>Select&nbsp;Date</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="Txt_dt" onkeyup="da()" onchange="fill()" runat="server" Width="125px"></asp:TextBox></td>
                <td style="width: 100px">
                    <strong>Select&nbsp;Block</strong></td>
                <td style="width: 100px">
                    <asp:DropDownList ID="cmb_block" runat="server"  Width="369px" Font-Bold="True" Font-Size="X-Small" ForeColor="Blue">
                    </asp:DropDownList></td>
                        </tr>
                    </table>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_dt">
                    </cc1:CalendarExtender>
                    <input id="Hidden2" runat="server" type="hidden" style="width: 1px" /></td>
            </tr>
            <tr>
                <td style="width: 102px; height: 21px;">
                    <strong>Select&nbsp; Employees</strong></td>
                <td colspan="2" style="height: 21px">
                    <asp:DropDownList ID="cmb_emp" runat="server" Width="341px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 21px;">
                    <input id="cmd_insert" onclick="listadd()" style="width: 97px" type="button" value="INSERT" /></td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="4">
                    <asp:ListBox ID="lst_emp" runat="server" Width="721px"></asp:ListBox></td>
            </tr>
            <tr>
                <td style="width: 102px">
                </td>
                <td style="width: 100px; text-align: center;">
                    <input id="txt_del" onclick="del()" style="font-weight: bold; font-family: 'Courier New';
                        background-color: gainsboro" type="button" value="DELETE" /></td>
                <td style="width: 100px">
                    <input id="cmd_exit" style="font-weight: bold; width: 71px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 102px; height: 21px;">
                </td>
                <td colspan="2" style="height: 21px">
                    <asp:Button ID="Cmd_confirm" runat="server" Font-Bold="True" Text="RELEASE BLOCK"
                        Width="205px" /></td>
                <td style="width: 100px; height: 21px;">
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

