<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="sd_updation_ho.aspx.vb" Inherits="WebAppHRMS.sd_updation_sd_updation_ho_ca22701b6306" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("cmb");

function Button2_onclick() {
window.open('../home.aspx','_self');
}
function combochange()
{
    document.getElementById("p1").style.display="none";
    document.getElementById("p2").style.display="none";
    document.getElementById(cs[0] + "Label1").value="";
    
}
function sdselect(k)
{
    if(document.getElementById("txt_"+k).checked==true)
        {
            var arr
            var arr1
            var arr2
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
                arr1=arr2[1];
            if(arr1=="")
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, SD.No is incorrect,You Cant Select This');
                return false;
            }
            else if(arr1.length<16)
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, SD.No is incorrect,You Cant Select This');
                return false;
            }
            else if(parseInt(arr2[2])>parseInt(20000))
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, Amount>20000,You Cant Select This');
                return false;
            }
        }
}
 function checkbeforeconfirm() 
 {
    document.getElementById(cs[0]+"hid2").value="";
    for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
    {
        if(document.getElementById("txt_"+k).checked==true)
        {
            var arr
            var arr1
            var arr2
            
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
            arr1=arr2[0] +  " $ " + "1";
            if(k==1)
            {
                document.getElementById(cs[0]+"hid2").value=arr1;
            }
            if (k!=1)
            {
                document.getElementById(cs[0]+"hid2").value+="!"+arr1;
            }
        }
        if(document.getElementById("txt_"+k).checked==false)
        {
           var arr
            var arr1
              var arr2
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
            arr1=arr2[0] +  " $ " + "0";
            if(k==1)
            {
                document.getElementById(cs[0]+"hid2").value=arr1;
            }
            if (k!=1)
            {
                document.getElementById(cs[0]+"hid2").value+="!"+arr1;
            }
        }
    }  
   
}    
    
function checkallfunction()
{
    if(document.getElementById("txt_all").checked==true)
    {
        var scount=0
        for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
        {
            var arr
            var arr1
            var arr2
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
                arr1=arr2[1];
            if(arr1=="")
            {
                scount=1
                document.getElementById("txt_"+k).checked=false;
            }
            else if(arr1.length<16)
            {
                scount=1
                document.getElementById("txt_"+k).checked=false;
            }
            else if(parseInt(arr2[2])>parseInt(20000))
            {
                scount=2
                document.getElementById("txt_"+k).checked=false;
            }
            else if(arr1!="")
            {
                document.getElementById("txt_"+k).checked=true;
            }
        } 
        if(scount==1)
        {
                alert('Sorry, SD.No is Missing,You Cant Select Some Records');
        }
        if(scount==2)
        {
                alert('Sorry, Amount>20000,You Cant Select Some Records');
        }
         
    }
    
    if(document.getElementById("txt_all").checked==false)
    {
        for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
        {
            document.getElementById("txt_"+k).checked=false;
 
        }  
    }
}

</script>

    <div style="text-align: center">
        <br />
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager><br />
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 472px; HEIGHT: 82px" border=1><TBODY><TR><TD style="HEIGHT: 44px; TEXT-ALIGN: center" colSpan=2><SPAN style="COLOR: #ff0099; TEXT-DECORATION: underline"><STRONG>HRM SD CONFIRMATION</STRONG></SPAN></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 28px; TEXT-ALIGN: right">Select :</TD><TD style="WIDTH: 100px; HEIGHT: 28px; TEXT-ALIGN: left"><DIV style="TEXT-ALIGN: left"><asp:RadioButtonList id="RadioButtonList1" runat="server" Width="327px" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">Salary</asp:ListItem>
                            <asp:ListItem Value="1">Allowances</asp:ListItem>
                        </asp:RadioButtonList>&nbsp;</DIV></TD></TR><TR><TD style="WIDTH: 120px; TEXT-ALIGN: right">Department : </TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:DropDownList id="cmb_dpt" runat="server" Width="332px" >
                    </asp:DropDownList></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
        <table border="1" style="width: 472px; height: 3px">
            <tr>
                <td style="text-align: center; height: 9px;" colspan="2">
                    <div style="text-align: center">
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="cmd_confirm"  runat="server" Text="CONFIRM" /></td>
                                <td style="width: 100px">
                    <input id="Button2" style="width: 74px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        &nbsp;
        &nbsp;
        &nbsp;&nbsp;<asp:HiddenField ID="hid3" runat="server" />
        <br />
                    <asp:Label ID="Label1" runat="server" Width="657px" Font-Bold="True" ForeColor="Purple"></asp:Label><br />
        <div style="text-align: center">
            <table border="0">
                <tr id="p1">
                    <td style="width: 100px; height: 63px;">
    <asp:Panel ID="Panel1" runat="server" Height="40px" Visible="False" Width="805px">
        <asp:HiddenField ID="hid2" runat="server" />
    </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
            <table border="0">
                <tr id="p2">
                    <td style="width: 100px; height: 28px;">
            <asp:Panel ID="Panel2" runat="server" Height="50px" Visible="False" Width="125px">
                &nbsp;<asp:Button ID="cmd_confirm1" OnClientClick="checkbeforeconfirm()" runat="server" Text="CONFIRM" Width="106px" /></asp:Panel>
                        </td>
                </tr>
            </table>
        <br />
        &nbsp;<asp:HiddenField ID="hid1" runat="server" />
        <br />
        <div style="text-align: center">
            &nbsp;</div>
        <br />
        <br />
     </div>
</asp:Content>

