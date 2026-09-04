<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="resignation_enter.aspx.vb" Inherits="WebAppHRMS.new_resignation_enter_76bbc5f21103" title="Untitled Page" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../../home.aspx','_self');
}
var cs = cont_name.split("Txt");




//window.onload=ap();

// function ap() 
//            {
//            debugger;
//            document.getElementById(cs[0]+"hid").value=1;
//            if(document.getElementById(cs[0]+"hid").value==0)
//            return false;
//            else
//            {
//            mywin=window.open("rej_res_ho.aspx", "WinC", "width=750px,height=300px,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
//            mywin.moveTo(200,300);
//            //return false;
//            }
//            };
            


//function isNumberKey(ids) 
//{ 
////debugger;
//    var charcode = (event.which) ? event.which : event.keyCode 
//    if(ids==1) 
//    {
//        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32)) 
//        {
//            return true; 
//        } 
//        else 
//            return false; 
//    }
//    if(ids==2) 
//    {
//        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32) || (charcode > 46 && charcode <58)) 
//        {
//            return true; 
//        } 
//        else 
//            return false; 
//    }
//    if(ids==3) 
//    {
//        if (charcode > 31 && (charcode < 48 || charcode > 57 )) 
//        {
//            return false; 
//        } 
//        else 
//            return true; 
//    }

//}
//debugger;
function addDays(date, days) {
    var result = new Date(date); // Create a new date object
    result.setDate(result.getDate() + days); // Add days to the new date object
    return result;
}

function changes(v)
{ 
debugger;
    var mm;
    parts=v.split('/');
    
       if (parts[1]=='Jan'){
       mm="01";}
       if (parts[1]=='Feb'){
       mm="02";}
       if (parts[1]=='Mar'){
       mm="03";}
       if (parts[1]=='Apr'){
       mm="04";}
       if (parts[1]=='May'){
       mm="05";}
       if (parts[1]=='Jun'){
       mm="06";}
       if (parts[1]=='Jul'){
       mm="07";}
       if (parts[1]=='Aug'){
       mm="08";}
       if (parts[1]=='Sep'){
       mm="09";}
       if (parts[1]=='Oct'){
       mm="10";}
       if (parts[1]=='Nov'){
       mm="11";} 
       if (parts[1]=='Dec'){
       mm="12";} 
       
       var parts1=parts[2]+"-"+mm+"-"+parts[0];
       parts1=parts1.split('-');
    var givenDate = new Date(parts1[0],parts1[1]-1,parts1[2]); 
    var givenDates = new Date(parts1[0]+'/'+parts1[1]+'/'+parts1[2]); 
    var yyyy=new Date().getFullYear();
    var mmm=new Date().getMonth();
    if(mmm.toString.length==1)
    {
      mmm=mmm+1;
      mmm="0"+mmm;
    }
    var dd=new Date().getDate();
    var todays = new Date(yyyy+'/'+mmm+'/'+dd)
    if (givenDates<todays)
    {
    alert("YOU CANNOT ENTER BACK DATE IN RESIGNATION!!!");
    window.open('../../home.aspx','_self');
    return false;
    }
 var newDate = addDays(givenDate, 90);
   var endDate = newDate.toDateString();
 var month=endDate.substring(4,7);
 month=month.trim();
 var day=endDate.substring(7,10);
 day=day.trim();
 var year=endDate.substring(10,15);
 year=year.trim();
 if(day.length==1)
 day="0"+day;
 var date_nw=day+'/'+month+'/'+year;
   document.getElementById(cs[0]+"Txt_rsdt").value =date_nw;
   return false;
   
  
 }


function change(a) {
var str=document.getElementById(cs[0]+a).value;
if (str==' ')
  {document.getElementById(cs[0]+a).value="";
    document.getElementById(cs[0]+a).focus;
    return false;
   }
 if (isNaN(str))
   {
    document.getElementById(cs[0]+a).value="";
    document.getElementById(cs[0]+a).focus;
    return false;
   }

}

 function check_dt()
 {
  alert("Select Date From Calender")
  return false;
 }

function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
// ]]>
</script>

    <div style="text-align: center"><table border="1" style="width:24px"><tr align="left"><td align ="center"><span style="color: #ff0033" > RESIGNATION APPLICATION</span><asp:ScriptManager id="ScriptManager1"
                        runat="server"></asp:ScriptManager>
                        
                        
                        <cc1:CalendarExtender ID="CalendarExtender1"
                            runat="server" Format="dd/MMM/yyyy" TargetControlID="TextBox1">

                   
                    </cc1:CalendarExtender>
                    
                    </td></tr>
       <tr align="left"><td align="left"><asp:Panel ID="Panel1" runat="server" Height="300px" Width="125px">
            <table border="1" style="width: 256px; height:300px">
            
                <tr align="left">
                    <td align="left" style="width: 24px;  text-align: left">
                        <span style="color: #3300cc">Employee Code</span></td>
                    <td align="left" style="width: 11px; text-align: left">
                        <asp:Label ID="lbl_code" runat="server" ForeColor="#C00000" Text="Label" Width="136px"></asp:Label></td>
                    <td align="left" style="width: 142px;">
                        <span style="color: #3300cc">Employee Name</span></td>
                    <td align="left" style="width: 27px;">
                        <asp:Label ID="lbl_name" runat="server" ForeColor="#C00000" Text="Label" Width="250px"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left"  style="width: 24px;text-align: left; height: 5px;">
                        <span style="color: #3300cc">Resignation Notice Submitted Date</span></td>
                    <td align="left"  style="width: 11px;text-align: left; height: 5px;">
                        <asp:TextBox ID="TextBox1" runat="server" Enabled="True" Onchange="changes(this.value)" onkeypress="return check_dt()"  ></asp:TextBox><br />
                    </td>
                    <td align="left"  style="width: 142px; height: 5px;">
                        <span style="color: #0000cc">When is your last day of work?</span></td>
                    <td align="left" style="width: 27px; height: 5px;">
                        <%--<asp:TextBox ID="Txt_rsdt" runat="server" ReadOnly="true">--%><%--</asp:TextBox>--%>
                        
                        <input type="text" runat="server" readonly="readonly" id="Txt_rsdt" />
                        
                        &nbsp;</td>
                </tr>
                <tr align="left">
                    <td align="left" style="width: 24px;text-align: left">
                        <span style="color: #3300cc">Resignation Reason</span></td>
                    <td align="left" colspan="3" style="text-align: left">
                        <asp:DropDownList ID="cmb_reason" runat="server" AutoPostBack="true" Width="430px">
                        </asp:DropDownList></td>
                </tr>
                <tr align="left">
                    <td align="left" colspan="4" style="text-align: left;">
                        <asp:Panel ID="hs1" runat="server" Width="720px" Height="100px">
                            <div style="text-align: center">
                                <table style="width: 730px">
                                    <tr align="left">
                                        <td align="left" style="width: 171px">
                                            <span style="color: #0033cc">College name</span></td>
                                        <td align="left" colspan="3" style="text-align: left">
                                            <asp:TextBox ID="Txt_coll" runat="server" Width="541px"></asp:TextBox></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="left" style="width: 171px">
                                            <span style="color: #0033cc">Course</span></td>
                                        <td align="left" style="width: 51px; text-align: left">
                                            <asp:TextBox ID="Txt_cou" runat="server" Width="327px"></asp:TextBox></td>
                                        <td align="left" style="width: 77px">
                                            <span style="color: #3333cc">Duration</span></td>
                                        <td align="left" style="width: 250px; text-align: left">
                                            <asp:TextBox MaxLength="3" ID="Txt_du" runat="server" onkeyup="return change('Txt_du')" Width="57px"></asp:TextBox><span
                                                style="color: #ff0000"> in months</span></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="orr" runat="server" Width="730px" Height="60 px">
                            <div style="text-align: center ; height:150px" >
                                <table style="height:100px">
                                    <tr align="left">
                                        <td style="width: 75px">
                                            <span style="color: #3333cc">Reason</span></td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="Txt_or" runat="server" Width="639px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pr1" runat="server" Width="720px" Height="150px">
                            <div style="text-align: center">
                                <table style="width: 729px">
                                    <tr align="left">
                                        <td align="left" style="width: 209px;">
                                            <span style="color: #0033cc">Select category</span></td>
                                        <td align="left" style="width: 250px;">
                                            <asp:DropDownList ID="cmb_pr" runat="server" Width="378px">
                                            </asp:DropDownList></td>
                                        <td align="left" style="width: 250px;">
                                        </td>
                                        <td style="width: 250px;">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="oe1" runat="server" Width="720px" Height="200px">
                            <div style="text-align: center">
                                <table style="width : 728px">
                                    <tr>
                                        <td style="width: 134px;">
                                            <span style="color: #3333cc">Firm</span></td>
                                        <td style="width: 90px;; text-align: left">
                                            <asp:TextBox ID="Txt_fir" runat="server" Width="233px"></asp:TextBox></td>
                                        <td style="width: 65px;">
                                            <span style="color: #3333cc">Reason</span></td>
                                        <td style="width: 250px; text-align: left">
                                            <asp:TextBox ID="Txt_rea" runat="server" Width="307px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 134px;">
                                            <span style="color: #3333cc">Nature of work</span></td>
                                        <td style="width: 90px; text-align: left">
                                            <asp:TextBox ID="Txt_nw" runat="server" Width="233px"></asp:TextBox></td>
                                        <td style="width: 65px;">
                                            <span style="color: #3333cc">Salary</span></td>
                                        <td style="width: 250px; text-align: left">
                                            <asp:TextBox ID="Txt_sal" runat="server" onkeyup="return change('Txt_sal')"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="mr1" runat="server" Width="720px" Height="200px">
                            <table style="width: 728px">
                                <tr>
                                    <td style="width: 118px">
                                        <span style="color: #3333cc">Place of marriage </span>
                                    </td>
                                    <td style="width: 93px">
                                        <asp:TextBox ID="Txt_pm" runat="server" Width="258px"></asp:TextBox></td>
                                    <td style="width: 106px">
                                        <span style="color: #3333cc">Name of Partner</span></td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="Txt_np" runat="server" Width="194px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 118px;">
                                        <span style="color: #3333cc">Job of Partner</span></td>
                                    <td style="width: 93px; ">
                                        <asp:TextBox ID="Txt_jp" runat="server" Width="258px"></asp:TextBox></td>
                                    <td style="width: 106px;">
                                  </td>
                                    <td style="width: 250px;">  
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            
            
            </asp:Panel>                         <asp:Panel ID="Panel2" runat="server" Width="125px">
                            <table style="width: 720px" border ="1">
                                <tr>
                                   
                                    <td style="width: 115px;">
                                     <span style="color: #3333cc">Select Team Lead</span>
                                  </td>
                                    <td style="width: 150px;">  <asp:DropDownList ID="DropDownList2"
                                    runat="server" >
                                </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 200px;">
                                     <span style="color: #3333cc">Approval Authority 1 :</span>
                                  </td>
                                    <td style="width: 250px;">
                                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#C00000"></asp:Label>
                                    </td>
                                </tr>
                                                                <tr>
                                    <td style="width: 200px;">
                                     <span style="color: #3333cc">Approval Authority 2 :</span>
                                  </td>
                                    <td style="width: 250px;">
                                    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="#C00000"></asp:Label>
                                    </td>
                                </tr>
                                                                <tr>
                                    <td style="width: 200px;">
                                     <span style="color: #3333cc">Final Approver:</span>
                                  </td>
                                    <td style="width: 250px;">
                                    <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#C00000"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel></td></tr>
        
                                  <tr><td> 
                                      <table style="width: 730px">
                                          <tr> 
                                              <td>
                    <span style="color: #0000cc">Attach Resign letter:</span></td>
                                              <td  colspan="3">
                                                  <asp:FileUpload ID="FileUpload1" runat="server" /><span style="color:red;">(only .jpg .jpeg .png .bmp are allowed)</span>
                                              </td>
                
           
         
                                          </tr>
                                          <tr align="left"><td align="left"></td></tr>
                                          <tr align="left"><td align="left"></td></tr>
                                          <tr align="left"><td align="left"></td></tr>
              <tr>
                <td style="width: 141px;">
                    &nbsp;
                </td>
                <td style="width: 250px; text-align: center;">
                    <asp:Button ID="Button1"  runat="server" Text="CONFIRM" Width="83px" /></td>
                <td style="width: 133px; text-align: center;">
                    &nbsp;<input id="Button2" style="width: 76px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                <td style="width: 213px;">
                    &nbsp;
                </td>
            </tr></table></td></tr> </table>
            
            <asp:HiddenField ID="hid" runat="server" />
    </div>
</asp:Content>



