<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="discwhole.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_hrm_Add_Post_528746864699" Title="Untitled Page" EnableEventValidation="false" %>

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
        <p>&nbsp;</p>
        <div style="text-align: center">
            <table style="border: none; border-collapse: collapse; width: 584pt;">
                <tbody>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 51.0pt; width: 48pt;">
                            <br>
                        </td>
                        <td colspan="3" style="padding: 0px; color: black; font-size: 27px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Algerian, fantasy; text-align: center; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: none; border-bottom: none; border-left: none; width: 482pt;">DISCIPLINARY ACTION REPORT</td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: 1.0pt solid windowtext; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 398px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 1556px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 455px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px; height: 36px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 45px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; height: 45px; width: 398px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 1556px; height: 45px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 455px; height: 45px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px; height: 45px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 20px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; width: 298px; height: 20px;">Select Disciplinary Action</td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 1056px; height: 20px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; vertical-align: top; border: none; width: 455px; height: 20px;">&nbsp;<table>
                            <tbody>
                                <tr>
                                    <td style="padding: 0px; color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; height: 16pt; width: 107pt;">
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" BackColor="AliceBlue"
                                            Width="300px">
                                            <asp:ListItem>List of Disciplinary Actions</asp:ListItem>
                                            <asp:ListItem>All</asp:ListItem>
                                            <asp:ListItem>Not using ID card</asp:ListItem>
                                            <asp:ListItem>Uninformed leave</asp:ListItem>
                                            <asp:ListItem>Excess leave</asp:ListItem>
                                            <asp:ListItem>Excess attendance regularizations</asp:ListItem>
                                            <asp:ListItem>Dress code violation</asp:ListItem>
                                            <asp:ListItem>Damaging company assets</asp:ListItem>
                                            <asp:ListItem>Excess late attendance marking</asp:ListItem>
                                            <asp:ListItem>Uninformed movements</asp:ListItem>
                                            <asp:ListItem>Movement without entering in movement register</asp:ListItem>
                                            <asp:ListItem>Partial/ Wrong entry in Movement register</asp:ListItem>
                                            <asp:ListItem>Wasting productive time</asp:ListItem>
                                            <asp:ListItem>Information security violation</asp:ListItem>
                                            <asp:ListItem>Misconduct</asp:ListItem>
                                            <asp:ListItem>Violating policy reg. POSH</asp:ListItem>
                                            <asp:ListItem>Proxy punching</asp:ListItem>
                                            <asp:ListItem>No photo in punching</asp:ListItem>
                                            <asp:ListItem>Notice period shortfall</asp:ListItem>
                                            <asp:ListItem>Absconding</asp:ListItem>
                                            <asp:ListItem>Resignation without completing formalities</asp:ListItem>
                                            <asp:ListItem>Excess punching block</asp:ListItem>
                                            <asp:ListItem>Others</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </tbody>
                        </table>
                            &nbsp;</td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px; height: 20px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 398px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 1556px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 455px; height: 36px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px; height: 36px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 49px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; height: 49px; width: 398px;">From Date</td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 49px; width: 1556px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; width: 455px;">To Date</td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 36px; height: 49px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: none; border-left: 1.0pt solid windowtext; height: 23px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: #A6A6A6; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; border-top: none; height: 23px; width: 398px;">
                            <asp:TextBox ID="TextBox1" onkeydown="return false" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MMM/yyyy" TargetControlID="TextBox1" runat="server"></cc1:CalendarExtender>
                        </td>

                        <td style="padding: 0px; color: #A6A6A6; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; width: 1556px; height: 23px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: #A6A6A6; font-size: 15px; font-weight: 700; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: 1.5pt solid windowtext; border-top: none; height: 23px; width: 455px;">&nbsp;<asp:TextBox ID="TextBox2" onkeydown="return false" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="TextBox2" runat="server"></cc1:CalendarExtender>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: none; border-left: none; width: 38px; height: 23px;">
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: 1.0pt solid windowtext; height: 38px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; height: 38px; width: 398px;">
                            <br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; height: 38px; width: 1556px;">
                            <asp:Button ID="Button1" runat="server" Text="CONFIRM" />
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="EXIT" Width="96px" /><br>
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: none; border-bottom: 1.0pt solid windowtext; border-left: none; height: 38px; width: 455px;">
                            <br>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td style="padding: 0px; color: black; font-size: 15px; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; text-align: general; vertical-align: bottom; border: none; border-top: none; border-right: 1.0pt solid windowtext; border-bottom: 1.0pt solid windowtext; border-left: none; width: 38px; height: 38px;">
                            <br>
                        </td>
                    </tr>
                </tbody>
            </table>


        </div>
    </div>
</asp:Content>

