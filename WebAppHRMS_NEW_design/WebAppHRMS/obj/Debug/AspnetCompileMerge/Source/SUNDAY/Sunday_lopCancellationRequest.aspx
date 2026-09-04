<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Sunday_lopCancellationRequest.aspx.vb" Inherits="WebAppHRMS.Sunday_lopCancellationRequest_78fdc6344226" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript" >
<!--
//return window_onload()
// -->
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('ddl');

function early_goingOnchange()
{
 debugger;
if(document.getElementById(con[0]+"ddl_lop").value!='-1')
{
var aaa=document.getElementById(con[0]+"ddl_lop").value;
var bbb=document.getElementById(con[0]+"ddl_lop").text;
call_server("1*"+document.getElementById(con[0]+"ddl_lop").value,1);
}

else
{
document.getElementById(con[0]+"txt_empcd").value="";
document.getElementById(con[0]+"txt_empnme").value="";


document.getElementById(con[0]+"txt_branch").value="";
document.getElementById(con[0]+"txt_post").value="";


document.getElementById(con[0]+"txtworked_date").value="";
document.getElementById(con[0]+"txtlopcanclltn_date").value="";
document.getElementById(con[0]+"txtemp_rmrks").value="";
document.getElementById(con[0]+"txtapplied_date").value="";

//document.getElementById(con[0]+"txt_remarks").value="";
}
}
function call_receiver(arg,context) 
{
debugger;
  switch (context)
  { 
    case 1://  0              1                     2                  3                    4               5                   6
    { 
         //el.emp_code||'*'||em.emp_name||'*'||br.branch_name||'*'||pm.post_name||'*'||el.going_dt||'*'||el.going_time||'*'||el.reason 
         //select distinct em.emp_code,em.emp_name || '*' || br.branch_name || '*' || pm.post_name || '*' || ca.workeddate || '*' || ca.lopcancelltndate || '*' || ca.remarks || '*' || ca.applieddate || '*' || ca.recommenderremarks from employee_master em, post_mst pm, branch br, tbl_lop_cancelled ca where em.post_id = pm.post_id and em.branch_id = br.branch_id and ca.empcode = em.emp_code and ca.status in (0, 4) and ca.empcode = 101057
       // document.getElementById(con[0]+"Hidden1").value=arg;
       if (arg==4)
       {
        document.getElementById(con[0]+"txt_empcd").value="";
        document.getElementById(con[0]+"txt_empnme").value="";
        
        
        document.getElementById(con[0]+"txt_branch").value="";
        document.getElementById(con[0]+"txt_post").value="";
        
        
        document.getElementById(con[0]+"txtworked_date").value="";
        document.getElementById(con[0]+"txtlopcanclltn_date").value="";
        document.getElementById(con[0]+"txtemp_rmrks").value="";
        document.getElementById(con[0]+"txtapplied_date").value="";
       
//        document.getElementById(con[0]+"txt_remarks").value="";
       break;
       }
       else
       {
        var ar=arg.split("*");
        document.getElementById(con[0]+"txt_empcd").value=ar[0];
        document.getElementById(con[0]+"txt_empnme").value=ar[1];
        
        
        document.getElementById(con[0]+"txt_branch").value=ar[2];
        document.getElementById(con[0]+"txt_post").value=ar[3];
        
        
        document.getElementById(con[0]+"txtworked_date").value=ar[4];
        document.getElementById(con[0]+"txtlopcanclltn_date").value=ar[5];
        document.getElementById(con[0]+"txtemp_rmrks").value=ar[6];
        document.getElementById(con[0]+"txtapplied_date").value=ar[7];
////        document.getElementById(con[0]+"txt_exp_dt").value=ar[8];
//        document.getElementById(con[0]+"txt_remarks").value=ar[9];      
        break;
       }
    }
    case 2:
    {
        var arg1=arg.split("*")
        alert(arg1[1]);
        if (arg1[0]==1)
        {
            window.open('compensatory_sanction.aspx','_self');
        }
    }
  }         
}

function cmd_ext_onclick() {
window.open('../Home.aspx','_self')
}

//function window_onload() {
////debugger;

//document.getElementById(con[0]+"cmd_app").style.display='none'
//document.getElementById(con[0]+"cmd_rec").style.display='inline'
//}

//function chk_data()
//{
//if(document.getElementById(con[0]+"ddl_lop").value=='-1' || document.getElementById(con[0]+"ddl_lop").options.length==0)
//{
//alert("Select Employee");
//return false;
//}
//if(document.getElementById(con[0]+"txt_empcd").value=="")
//{
//alert("Select Employee");
//return false;
//}
//}
//function chk_data1()
//{
//if(document.getElementById(con[0]+"ddl_lop").value=='-1' || document.getElementById(con[0]+"ddl_lop").options.length==0)
//{
//alert("Select Employee");
//return false;
//}

//if(document.getElementById(con[0]+"txt_empcd").value=="")
//{
//alert("Select Employee");
//return false;
//}

//            if((document.getElementById(con[0]+"hid_rej").value)=="")
//             {
//                mywin=window.open("rej_res1.aspx", "WinC", "width=500,height=50,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=no,copyhistory=no")
//                mywin.moveTo(200,300);
//                return false;
//             }
//            else
//             {
//                arg=2+"*"+document.getElementById(con[0]+"ddl_lop").value+"*"+document.getElementById(con[0]+"emp_type").value+"*"+document.getElementById(con[0]+"hid_user").value+"*"+document.getElementById(con[0]+"hid_rej").value
//                call_server(arg,2);
//                return false;
//             }           
//}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 685px; height: 275px">
            <tr>
                <td colspan="4" style="height: 30px">
                    <span style="font-family: Courier New">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" BackColor="WhiteSmoke" ForeColor="#C00000" Height="27px" Width="672px">SUNDAY LOP CANCELLATION RECOMMEND/APPROVE</asp:Label></span></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <asp:CheckBox ID="chk_rec" runat="server" AutoPostBack="True" Checked="True" Font-Bold="True"
                        Text="Recommend" Width="209px" ForeColor="#C00000" /></td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:CheckBox ID="chk_app" runat="server" AutoPostBack="True" Font-Bold="True" 
                    Text="Sanction" Width="183px" ForeColor="#C00000" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    <span style="font-family: Courier New"><strong>Select </strong></span></td>
                <td colspan="2" style="height: 23px; text-align: left">
                    <asp:DropDownList ID="ddl_lop" runat="server" Width="358px" onchange="return early_goingOnchange()" >
                    </asp:DropDownList></td>
                    
            </tr>
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;code</span></td>
                <td style="width: 141px; height: 23px">
                    <input id="txt_empcd" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;name</span></td>
                <td style="width: 72px; height: 23px; text-align: left">
                    <input id="txt_empnme" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'; width: 171px;" /></td>
            </tr>
            
            
            
            
            
            
            
            <tr>
                <td style="width: 114px; text-align: left; height: 28px;">
                    <span style="font-family: Courier New">Branch</span></td>
                <td style="width: 141px; height: 28px;">
                    <input id="txt_branch" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; text-align: left; height: 28px;">
                    <span style="font-family: Courier New">Post</span></td>
                <td style="width: 72px; text-align: left; height: 28px;">
                    <input id="txt_post" runat="server" type="text" readonly="readOnly" style="font-family: 'Courier New'; width: 171px;" /></td>
            </tr>
            
            
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Worked&nbsp;Date</span></td>
                <td style="width: 141px; height: 23px; text-align: left">
                    <input id="txtworked_date" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Cancellation&nbsp;Date</span></td>
                <td style="width: 72px; height: 23px; text-align: left">
                    <%--<asp:TextBox ID="txtlopcanclltn_date" runat="server" style="font-family: 'Courier New'" Width="171px" ReadOnly="True"></asp:TextBox>--%>
                    <input id="txtlopcanclltn_date" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                   
            </tr>
            <tr>
                <td style="width: 114px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Employee&nbsp;Remarks</span></td>
                <td style="width: 141px; height: 23px; text-align: left">
                <input id="txtemp_rmrks" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 23px; text-align: left">
                    <span style="font-family: Courier New">Applied&nbsp;Date</span></td>
                <td style="width: 72px; height: 23px; text-align: left">
                <input id="txtapplied_date" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
            </tr>
           <%-- <tr>
                <td style="width: 114px; height: 5px; text-align: left">
                    <span style="font-family: Courier New">Expiry&nbsp;Date</span></td>
                <td style="width: 141px; height: 5px; text-align: left">
                    <input id="txt_exp_dt" runat="server" style="width: 171px; font-family: 'Courier New';" type="text" readonly="readOnly" /></td>
                <td style="width: 76px; height: 5px; text-align: left">
                    <span style="font-family: Courier New"></span></td>
                <td style="width: 72px; height: 5px; text-align: left">
                    </td>
            </tr>--%>
            <tr>
                <td style="width: 114px; text-align: left">
                    <span style="font-family: Courier New">Remarks </span>
                </td>
                <td colspan="3" style="text-align: left">
                    <input id="txt_remarks" runat="server" style="width: 537px; font-family: 'Courier New';" type="text"/></td>
            </tr>
            <tr>
                <td style="height: 23px" colspan="4">
                    <input id="emp_type" runat="server" style="width: 1px" type="hidden" />
                    <input id="Hidden1" runat="server" style="width: 7px" type="hidden" />
                    <input id="hid_user" runat="server" style="width: 5px" type="hidden" />
                    <input id="hid_rej" runat="server" style="width: 5px" type="hidden" />
                    <input id="hid_access" runat="server" style="width: 5px" type="hidden" />
                    <asp:Button ID="cmd_rec" runat="server" Text="RECOMMEND" Width="95px" OnClientClick="return chk_data()" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True"/>&nbsp;
                    <asp:Button ID="cmd_app" runat="server" Text="SANCTION" Width="95px" OnClientClick="return chk_data()" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True"/>&nbsp;
                    <asp:Button ID="cmd_rej" runat="server" Height="25px" Text="REJECT" Width="95px" OnClientClick="return chk_data()" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True"/>&nbsp;
                    <input id="cmd_ext"  style="width: 95px; height: 24px; font-family: 'Courier New'; font-weight: bold; "  type="button" value="EXIT" onclick="return cmd_ext_onclick()" /></td>
            </tr>
        </table>
    </div>
</asp:Content>