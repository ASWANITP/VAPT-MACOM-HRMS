<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Add_comp_id.aspx.vb" Inherits="WebAppHRMS.compensatory_extension_Add_compensatory_78d2ea263586" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">

</script>

<script language="javascript" type="text/javascript">
var cs = cont_name.split("ListBox1");
function listadd()
{
            for(b=0;b<document.getElementById(cs[0]+"ListBox1").options.length;b++)
            {
              if(document.getElementById(cs[0]+"ListBox1").options[b].value==document.getElementById(cs[0]+"drp_emp").value)
                {
                    alert("Already Added");
                    return false;
                }
            }
                        
            var option1=document.createElement("OPTION")
            option1.text=option1.text+document.getElementById(cs[0]+"drp_emp").options[document.getElementById(cs[0]+"drp_emp").selectedIndex].text;
                      option1.value=document.getElementById(cs[0]+"drp_emp").value;
            if(document.getElementById(cs[0]+"Hidden2").value=="")
            {
              document.getElementById(cs[0]+"Hidden2").value=document.getElementById(cs[0]+"drp_emp").value;
            }
            else
              {
//            
                document.getElementById(cs[0]+"Hidden2").value=document.getElementById(cs[0]+"Hidden2").value+"#"+document.getElementById(cs[0]+"drp_emp").value;
              }
              
              
            document.getElementById(cs[0]+"ListBox1").options.add(option1);
   }

 


function Reset1_onclick() {
 
}

// ]]>
</script>
    <div style="text-align: center">
        <asp:HiddenField ID="Hidden2" runat="server" />
        <table border="1" style="width: 898px; height: 200px;">
            <caption>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_calender">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_exp">
                </cc1:CalendarExtender>
            </caption>
            <tr>
                <td style="width: 308px; text-align: left;">
                    <strong>ENTER COMPENSATORY NAME</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="Cmp_name" runat="server" Width="333px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 308px; text-align: left;">
                    <strong>SELECT COMPENSATORY DATE</strong></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_calender" runat="server" Width="333px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 308px; text-align: left; height: 26px;">
                    <strong>SELECT EMPLOYEES</strong></td>
                <td style="width: 100px; height: 26px;">
                    <asp:DropDownList ID="drp_emp" runat="server" Width="342px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 308px; height: 26px; text-align: left">
                </td>
                <td style="width: 100px; height: 26px; text-align: justify;">
                    <input id="button1" onclick="listadd()" style="width: 112px" type="button" value="ADD" />&nbsp;&nbsp;&nbsp;
                    <input id="Reset1" type="reset" value="REMOVE" onclick="return Reset1_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 308px; text-align: left; height: 25px;">
                </td>
                <td style="width: 100px; height: 25px; text-align: left;">
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Width="340px"></asp:ListBox></td>
            </tr>
            <tr>
                <td style="width: 308px; height: 23px; text-align: left">
                    <strong>EXPIERY DATE</strong></td>
                <td style="width: 100px; height: 23px; text-align: left;">
                    <asp:TextBox ID="txt_exp" runat="server" Width="235px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 308px; text-align: right; height: 28px;">
                    &nbsp;<asp:Button ID="Button" runat="server" Text="CONFIRM" Width="105px" /></td>
                <td style="width: 100px; text-align: justify; height: 28px;">
                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="104px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

