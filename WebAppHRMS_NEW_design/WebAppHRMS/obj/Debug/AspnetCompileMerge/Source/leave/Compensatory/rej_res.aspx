<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rej_res.aspx.vb" Inherits="WebAppHRMS.leave_rej_res_bf15cd913094" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick()
{   
      if((document.getElementById("txt_rej").value)!="")
       {  
        
        opener.document.forms[0].ctl00_cph_edp_hid_rej.value=document.getElementById("txt_rej").value;
        opener.document.forms[0].action="compensatory_sanction.aspx"
        window.opener.chk_data1()
        window.close("rej_res.aspx");
        
        return true; 
       }
       else
       {
        alert("Enter Reason for Rejection")
        return  false;
       }  
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server" style="background-color:antiquewhite">
    <div>
        <div style="text-align: left">
            <br />
            <table>
                <tr>
                    <td style="width: 183px">
                        Enter Reason for Rejection</td>
                    <td style="width: 100px">
                        <input id="txt_rej" type="text" style="width: 208px" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 26px;">
                        <input id="Button1" style="width: 60px" type="button" value="OK" onclick="return Button1_onclick()" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>
