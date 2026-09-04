<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Regularisation_Request.aspx.vb" Inherits="WebAppHRMS.Regularisation_Regularisation_Request_2fe6d9d75747" %>

<%--<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Regularization.aspx.vb" Inherits="Compulsary_Leave_hrm_CompulsaryLeave" title="Untitled Page" %>--%>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('txt');

function window_onload()
{
    document.getElementById("row1").style.display='none';
    document.getElementById("TR1").style.display='none';
}
function DateCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value = "";
   return false;
}

//function check_date(Control)
//  {
//    document.getElementById("row1").style.display='none';
//    document.getElementById("TR1").style.display='none';
//    var day1, day2;
//    var month1, month2;
//    var year1, year2;
//    if(document.getElementById(con[0]+Control).value!="")
//    {
//        var value1 = document.getElementById(con[0]+Control).value;
//        var dt = new Date().format("dd/MMM/yyyy");
//        var value2=dt;
//    
//        day1= value1.substring (0, value1.indexOf ("/"));
//        month1 = value1.substring (value1.indexOf ("/")+1, value1.lastIndexOf ("/"));
//        year1 = value1.substring (value1.lastIndexOf ("/")+1, value1.length);

//        day2= value2.substring (0, value2.indexOf ("/"));
//        month2 = value2.substring (value2.indexOf ("/")+1, value2.lastIndexOf ("/"));
//        year2 = value2.substring (value2.lastIndexOf ("/")+1, value2.length);

//        date1 = year1+"/"+month1+"/"+day1;
//        date2 = year2+"/"+month2+"/"+day2;
//    
//        firstDate = Date.parse(date1)
//        secondDate= Date.parse(date2)
//   
//        msPerDay = 24 * 60 * 60 * 1000
//    
//        dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
//        if(dbd<0)
//        {
//            alert("Please Do Not Enter Future Date ..!!")
//            document.getElementById(con[0]+Control).value='';
//            document.getElementById(con[0]+Control).focus();
//            return false;
//        }
//    }

// } 
function isNumeric()
{
     if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
     {
        document.getElementById(con[0]+"txtEcode").value="";
        return false; 
     }
}
//function detailDisplay()
//{
//    document.getElementById("row1").style.display='none';
//    document.getElementById("TR1").style.display='none';
// if (isNaN(document.getElementById(con[0]+"txtEcode").value)) 
//     {
//        document.getElementById(con[0]+"txtEcode").value="";
//        return false; 
//     }
//     if(document.getElementById(con[0]+"txtEcode").value=="")
//     {
//         document.getElementById(con[0]+"txtEname").value = "";
//         document.getElementById(con[0]+"txtBranch").value = "";  
//         document.getElementById(con[0]+"txtPost").value = "";
//         document.getElementById(con[0]+"txtDes").value = "";  
//         document.getElementById(con[0]+"txtDate").value = "";   
//         return false; 
//    }
//    if(document.getElementById(con[0]+"txtEcode").value!="")
//    {
//        callserver("1$"+document.getElementById(con[0]+"txtEcode").value,1);  
//    }
//}
function call_receiver(arg,context) 
{     
  switch (context)
  {
    case 1:
    {   
        var accdtl = arg.split("*");    
        if(accdtl=="")
         { 
            alert("Please Enter Valid Employee Code");
            document.getElementById(con[0]+"txtEcode").value = "";
            document.getElementById(con[0]+"txtEname").value = "";
            document.getElementById(con[0]+"txtBranch").value = "";  
            document.getElementById(con[0]+"txtPost").value = "";
            document.getElementById(con[0]+"txtDes").value = "";  
            document.getElementById(con[0]+"txtDate").value = "";           
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtEname").value = accdtl[0];
            document.getElementById(con[0]+"txtBranch").value=accdtl[1];
            document.getElementById(con[0]+"txtPost").value = accdtl[2];
            document.getElementById(con[0]+"txtDes").value = accdtl[3];  
            document.getElementById(con[0]+"txtDate").value = "";      
         } 
         break;   
     }
  }
}

function OnConClick()
{
    if(document.getElementById(con[0]+"txtEcode").value=="")
    {
        alert("Please Enter Employee Code...!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtEname").value=="")
    {
        alert("Please Enter Employee Code...!");
        document.getElementById(con[0]+"txtEcode").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Select Date...!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
}
//function hiderow()
//{
//    document.getElementById(con[0]+"chkMor").checked=false;
//    document.getElementById(con[0]+"chkEve").checked=false;
//    document.getElementById(con[0]+"chk_lop1").checked=false;
//    document.getElementById(con[0]+"chk_lop2").checked=false;
//    
//    if (document.getElementById(con[0]+"cmb_type").value==4)
//    {
//      document.getElementById("row1").style.display='inline';
//      document.getElementById("TR1").style.display='inline';
//      document.getElementById("row2").style.display='none';
//      document.getElementById("row3").style.display='none';
//    }
//    
//    else  if (document.getElementById(con[0]+"cmb_type").value==1)
//    {
//      document.getElementById("row2").style.display='inline';
//      document.getElementById("row1").style.display='none';
//      document.getElementById("TR1").style.display='none';
//      document.getElementById("row3").style.display='inline';
//    }
//    else
//    {
//        document.getElementById("row2").style.display='none';
//        document.getElementById("row1").style.display='none';
//        document.getElementById("TR1").style.display='none';
//        document.getElementById("row3").style.display='none';
//    }
//    
//    
//}
function btnExit_onclick() 
{
    window.open("../Home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtDate" runat="server">
                </cc1:CalendarExtender>
                <table border="1" style="width: 656px; height: 72px">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">
                     REGULARISATION
                        APPLICATION</span></strong></td></tr>
                        </table>
                <table border="1" style="width:55%">
                    <tr>
                  <td colspan="2" style="text-align: left">
                      <strong>
                            Enter Employee Code :</strong></td>
                           
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txtEcode" runat="server" ReadOnly="True" onblur="detailDisplay()" onkeypress="isNumeric()"  MaxLength="6" Width="70%" ForeColor="#C00000"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10%; text-align: justify;">
                            <strong>
                            Name :</strong></td>
                        <td style="width: 10%">
                            <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True" ForeColor="#C00000"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">
                            <strong>
                            Branch :</strong></td>
                        <td style="width: 10%">
                            <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True" ForeColor="#C00000"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 5%; text-align: justify;">
                            <strong>
                            Post :</strong></td>
                        <td style="width: 10%">
                            <asp:TextBox ID="txtPost" runat="server" Width="98%" ReadOnly="True" ForeColor="#C00000"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">
                            <strong>
                            Designation :</strong></td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtDes" runat="server" Width="98%" ReadOnly="True" ForeColor="#C00000"></asp:TextBox></td>
                    </tr>
                    </table>
                         <table border="1" style="width: 55%">
                    <tr>
                        <td colspan="3" style="text-align: left; height: 31px; width: 402px;">
                            <strong>
                            Select Date To be Regularised :</strong></td>
                        <td colspan="1" style="text-align: left; height: 31px;">
                            <asp:TextBox ID="txtDate" runat="server" Autopostback="true" onkeyup="DateCheck()" onblur="check_date('txtDate')" Width="40%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: left; width: 402px; height: 29px;">
                            <strong>Regularisation Type</strong></td>
                        <td colspan="3" style="text-align: left; height: 29px;">
                            <asp:DropDownList ID="cmb_type" runat="server" Width="214px" >
                               
                                <asp:ListItem >----- Select -----</asp:ListItem>
                                <asp:ListItem Value="1">System Error</asp:ListItem>
                                <asp:ListItem Value="2">Non-Marking</asp:ListItem>
                                <asp:ListItem Value="3">Individual Late</asp:ListItem>
                          </asp:DropDownList></td>
                    </tr>
                             <tr>
                                 <td colspan="3" style="text-align: left; height: 26px; width: 402px;">
                                     <strong>(Mor---Eve---Both--) :</strong></td>
                                 <td colspan="3" style="text-align: left; height: 26px;">
                                     <asp:CheckBox ID="chk_mor" runat="server" Text="Morning" />
                                     <asp:CheckBox ID="chk_eve" runat="server" Text="Evening" /></td>
                             </tr>
                             <tr>
                                 <td colspan="3" style="text-align: left; width: 402px;">
                                 </td>
                                 <td colspan="3" style="text-align: left">
                                     <asp:Label ID="lbl_error" runat="server" ForeColor="#F00000"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td colspan="3" style="text-align: left; width: 402px;">
                                     <strong>Select Techlead :</strong></td>
                                 <td colspan="3" style="text-align: left">
                                     <asp:DropDownList ID="Ddltech" runat="server" Width="214px" >
                                      <%--   <asp:ListItem Value=""></asp:ListItem>--%>
                                     </asp:DropDownList></td>
                             </tr>
                             <tr>
                                 <td colspan="3" style="text-align: left; width: 402px;">
                                     <strong>Department Head :</strong></td>
                                 <td colspan="3" style="text-align: left">
                               <%--      <input id="TxtDep" runat="server" maxlength="50" style="width: 281px" type="text" ForeColor="#C00000" />--%>
                                      <asp:TextBox ID="TxtDep" runat="server" Width="98%" ReadOnly="True" ForeColor="#C00000"></asp:TextBox></td>
                             </tr>
                    <tr id="row3">
                        <td colspan="3" style="text-align: left; width: 402px;">
                            <strong>
                            Remarks :</strong></td>
                        <td colspan="3" style="text-align: left">
                            <input id="txt_remarks" runat="server" maxlength="50" style="width: 281px" type="text" /></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: left; width: 402px;">
                            <strong>
                            Document Upload :</strong></td>
                       <td style="text-align: left"> <asp:FileUpload ID="file_support1" runat="server" Width="280px" BackColor="Snow" ForeColor="Black" />
                           <asp:Label ID="Label1" runat="server" ForeColor="#F00000">You can Upload pdf Only!</asp:Label></td>
              
                    </tr>
                 
             <tr>
             
             </tr>
                 
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnConfirm" runat="server" OnClientClick="return OnConClick()" Text="CONFIRM" />
                            <input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" />
                            </td>
                         
                    </tr>
                </table>
              <%--  <form action="mailto:megha.pk@macomsolutions.com" method="post" enctype="text/plain">
                Comment:<br>
                     <input type="text" name="comment" size="50">
                     E-mail:<br>
<input type="text" name="mail"><br>
</form>
                   <asp:Button ID="mail" runat="server" Text="mail" />--%>
            <%--     <input type="submit" value="SUBMIT EMAIL TO: info@whatshouldisay.ca" <a href="mailto:info@whatshouldisay.ca"></a>--%>
            </div>
        </div>
    </div>
</asp:Content>


