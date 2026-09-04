<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="discemp.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_hrm_Add_Post_528746865453" Title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
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

function TABLE1_onclick() {

}

// ]]>
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table style="border: none; border-collapse: collapse; width: 633pt;">
                    <tbody>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 15.0pt; width: 49pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 48pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 196pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 91pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 195pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 54pt;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 14.4pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 28.2pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td colspan="3" style="color: black; font-size: 27px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none;">DISCIPLINARY ACTION EMPLOYEE-WISE REPORT</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 14.4pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 48.0pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 15.0pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 49px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 49px;">
                                <br>
                            </td>
                            <td style="color: windowtext; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.0pt solid windowtext; height: 49px;">Select Employee</td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 49px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.0pt solid windowtext; height: 49px;">

                                <asp:DropDownList ID="DropDownList1emp" runat="server" Width="294px">
                                </asp:DropDownList></td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; height: 49px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 15.0pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none;">
                                <br>
                            </td>
                        </tr>

                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 47px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 47px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 47px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 47px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 47px;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; height: 47px;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 15.0pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: 1.0pt solid windowtext;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none;">
                                <asp:Button ID="Button1" runat="server" Text="CONFIRM" /><br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none;">
                                <asp:Button ID="Button3" runat="server" Text="EXIT" Width="72px" /><br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext; border-left: none;">
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 14.4pt;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                            <td style="color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none;">
                                <br>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />

                <br />
                <br />



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

