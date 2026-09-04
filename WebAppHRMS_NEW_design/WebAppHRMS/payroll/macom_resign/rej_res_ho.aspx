<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rej_res_ho.aspx.vb" Inherits="WebAppHRMS.feb2009_change_shift_press_reports_d2cb19252879" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick()
{   
debugger;
      opener.document.forms[0].cph_edp_Button1.disabled=false;
      opener.document.forms[0].cph_edp_cmb_reason.disabled=false;
      opener.document.forms[0].action="resignation_enter.aspx"
      window.close("rej_res_ho.aspx");
     
      
//     return false; 
  
//      if((document.getElementById("txt_rej").value)!="")
//       {  
//        
//        opener.document.forms[0].ctl00_cph_edp_hid_rej.value=document.getElementById("txt_rej").value;
         // opener.document.forms[0].action="resignation_enter.aspx"
//           window.opener.Button2_onclick()
////        window.close("rej_res_ho.aspx");
////        
//              return false; 
//       }
//       else
//       {
//        alert("Enter Reason ")
//        return  false;
//       }  
}

//function window_onload() {
//document.getElementById("txt_rej").focus();
//}
//function okonkeydown()
//{

// if (window.event.keyCode == 13) btnOK_onclick();
// }
// ]]>
    </script>
</head>
<body>
    <%--   <form id="form1" runat="server" style="background-color:antiquewhite">--%>
    <div>


        <asp:Panel ID="Panel1" ScrollBars="Vertical" Height="250px" runat="server" BorderColor="#FFE0C0" BorderStyle="Double"
            Width="100%">
        </asp:Panel>





        <center>
            <input id="Button1" style="width: 60px" onkeypress="return okonkeydown()" type="button" value="OK" onclick="return Button1_onclick()" /></center>


    </div>

    <%--
    </form>--%>
</body>
</html>
