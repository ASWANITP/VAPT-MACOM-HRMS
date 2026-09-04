<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rec_res_ho.aspx.vb" Inherits="WebAppHRMS.leave_rec_res_ho_d1b5f1c72471" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick()
{   debugger;
      if((document.getElementById("txt_rej").value)!="")
       {  
        opener.document.forms[0].ctl00_cph_edp_Hiddate.value=document.getElementById("txt_rej").value;
        opener.document.forms[0].ctl00_cph_edp_hid_rej.value=document.getElementById("hids").value;
        opener.document.forms[0].action="masterpiece.aspx"
        window.opener.cmd_rec_onclick()
        window.close("rec_res_ho.aspx");
        
        return true; 
       }
       else
       {
        alert("Enter date ")
        return  false;
       }  
}

function window_onload() {
document.getElementById("txt_rej").focus();
}
function okonkeydown()
{

 if (window.event.keyCode == 13) btnOK_onclick();
 }
// ]]>
</script>
</head>
<body onload="return window_onload()">
    <form id="form1" runat="server" style="background-color:antiquewhite">
    <div>
      <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="text-align: center ">
            <br />
            <table>
            <%--<caption>THE EMPLOYEE IS IN LONG LEAVE/MATERNITY STATUS, PLEASE FILL END DATE</caption>--%>
            <caption><asp:Label ID="labs" runat="server"></asp:Label></caption>
                <tr>
                    <td> 
                        End Date :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txt_rej" ></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 26px;">
                    <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="txt_rej" runat="server" ID="Calenresub"></cc1:CalendarExtender>
                        <input id="Button1" style="width: 60px" onkeypress="return okonkeydown()" type="button" value="OK" onclick="return Button1_onclick()" /></td>
                </tr>
                
            </table>
        </div>
    <input id="hids" runat="server" style="width: 1px" type="hidden" />
    </div>
    </form>
</body>
</html>
