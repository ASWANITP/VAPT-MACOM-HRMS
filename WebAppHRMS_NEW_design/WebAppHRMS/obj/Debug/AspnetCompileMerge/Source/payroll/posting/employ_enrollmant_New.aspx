<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employ_enrollmant_New.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_employ_enrollmant_New_28205b542528" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var con=header.split('txt');
 function correct(a) 
    {
   
     var v
     v=document.getElementById("ctl00_cph_edp_"+a).value
       if (isNaN(v))
          {
           document.getElementById("ctl00_cph_edp_"+a).value=""
           document.getElementById("ctl00_cph_edp_"+a).focus()
          }
    }
    
    function ValidateNumber(a)
    {                                   // alert(window.event.keyCode);
                          
         var txt = document.getElementById("ctl00_cph_edp_"+a);  
         if (!(((window.event.keyCode >=48) || (window.event.keyCode==46)) && (window.event.keyCode <= 57)) )
        {
                        
            window.event.cancelBubble = true;
            window.event.keyCode = 0;
            return false;
        }
        else 
        {
          if(window.event.keyCode ==46)
          {
              if(txt.value.indexOf(".")<0) 
              {
                   if(txt.value.length>7)
                   {
                     window.event.cancelBubble = true;
                     window.event.keyCode = 0;
                     alert("7 digits only allowed before decimal");
                     txt.focus();
                     return false;

                    }
              }else  
                  {
                     window.event.cancelBubble = true;
                     window.event.keyCode = 0;
                     alert("only one decimal allowed");
                      txt.focus();
                     return false;
                                        
                  }
           }         
           else
            {
               if(txt.value.indexOf(".")>=0) 
               {
                var str = txt.value.substring(txt.value.indexOf(".") + 1);
                if(str.length >= 2)
                {
                     window.event.cancelBubble = true;
                     window.event.keyCode = 0;
                     alert("Maximum 2 digits only allowed after decimal");
                      txt.focus();

                }

           }
          }
           
        }

    }
    
    function isNumeric()
{
     if (isNaN(document.getElementById(con[0]+"txtid").value)) 
     {
        document.getElementById(con[0]+"txtid").value="";
        return false; 
     }
}
    
    function datechk(a)
    {
       document.getElementById("ctl00_cph_edp_"+a).value=""
       document.getElementById("ctl00_cph_edp_"+a).focus()
      
    }
        
  function fillchk()
  {
   
   if(document.getElementById("ctl00_cph_edp_txt_applnno").value=="")
   {
    alert("Enter Application Number");
    return false;
   }
   else if(document.getElementById("ctl00_cph_edp_txt_period").value=="")
   {
    alert("Enter The Period");
    return false;
   }
   else if(document.getElementById("ctl00_cph_edp_txt_jodt").value=="")
   {
    alert("Enter Joining date");
    return false;
   }
   else if(document.getElementById("ctl00_cph_edp_txt_secdep").value=="")
   {
    alert("Enter Security Amount");
    return false;
   }
   else if(document.getElementById("ctl00_cph_edp_txt_depamt").value=="")
   {
    alert("Enter Deposit Amount");
    return false;
   }
   
   else if(document.getElementById("ctl00_cph_edp_txt_rdamt").value=="")
   {
    alert("Enter RD Amount");
    return false;
   }
   
    else if(document.getElementById("ctl00_cph_edp_txt_instno").value=="")
   {
    alert("Enter Inst No.");
    return false;
   }
   
         
  }  
    
   
    function detailDisplay()
{
 if (isNaN(document.getElementById(con[0]+"txtid").value)) 
     {
        document.getElementById(con[0]+"txtid").value="";
        return false; 
     }
      if(document.getElementById(con[0]+"txtid").value=="")
     {
         document.getElementById(con[0]+"txtname").value = "";
            
         return false; 
    }
     if(document.getElementById(con[0]+"txtid").value!="")
    {
        callserver("1$"+document.getElementById(con[0]+"txtid").value,1);  
    }
}
    
    function call_receiver(arg,context) 
{     
  //debugger;
  switch (context)
  {
    case 1:
    {   
        var accdtl = arg.split("~");    
        if(accdtl=="")
         { 
            alert("Please Select valid Employee Code");
            document.getElementById(con[0]+"txtid").value = "";
           document.getElementById(con[0]+"txtname").value = "";
            return false;
         }
         else
         {
            document.getElementById(con[0]+"txtname").value = accdtl[1];
//            document.getElementById(con[0]+"txtbranch").value = accdtl[2];
//            document.getElementById(con[0]+"txtDes").value = accdtl[3]; 
//            document.getElementById(con[0]+"txtjdate").value = accdtl[4];  
//            document.getElementById(con[0]+"txtdep").value = accdtl[5];  
//            document.getElementById(con[0]+"txtpost").value = accdtl[6];  
//            document.getElementById(con[0]+"txtpf_no").value = accdtl[7];     
//            document.getElementById(con[0]+"txtpf").value = accdtl[8];        
         } 
         break;   
     }
   }
}
    
    
</script>
    <table align="center" border="1">
        <tr>
        
        
        
            <td style="text-align: center; height: 44px;" colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <strong><span style="font-size: 11pt">EMPLOYEE ENROLLMENT</span></strong> &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 183px;" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<TABLE style="WIDTH: 656px" align=center border=1><TBODY><TR><TD style="TEXT-ALIGN: center" colSpan=4><cc1:CalendarExtender id="ce_jodt" runat="server" BehaviorID="CalendarExtender1" Format="d/MMM/yyyy" TargetControlID="txt_jodt">
                                    </cc1:CalendarExtender> <asp:Label id="lbl_err" runat="server" Width="206px"></asp:Label> &nbsp; </TD></TR><TR><TD style="WIDTH: 150px">Application No</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_applnno" onkeyup="correct('txt_applnno') " runat="server" Width="159px" MaxLength="8" AutoPostBack="True" OnTextChanged="txt_applnno_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 100px">Name</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_cname" runat="server" Width="208px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px">Employee Type</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_type" runat="server" Width="163px"><asp:ListItem Value="1">PERMANENT</asp:ListItem>
<asp:ListItem Value="2">OUTSOURCE</asp:ListItem>
<asp:ListItem Value="3">TRAINEE</asp:ListItem>
<asp:ListItem Value="4">PART TIME</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px">Period</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_period" onkeyup="correct('txt_period')" runat="server" Width="173px" MaxLength="2"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px">Firm </TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_firm" runat="server" Width="163px">
                                    </asp:DropDownList></TD><TD style="WIDTH: 100px">Joining Date</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_jodt" onkeyup="datechk('txt_jodt')" runat="server" Width="173px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 150px">ESI&nbsp; Declaratiom</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:RadioButtonList id="rd_esi" runat="server" Width="146px" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="T">Yes</asp:ListItem>
                                        <asp:ListItem Value="F">No</asp:ListItem>
                                    </asp:RadioButtonList></TD><TD style="WIDTH: 100px">Medical Claim</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:RadioButtonList id="rd_medical" runat="server" Width="157px" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="T">Yes</asp:ListItem>
                                        <asp:ListItem Value="F">No</asp:ListItem>
                                    </asp:RadioButtonList></TD></TR><TR><TD style="WIDTH: 150px">Provident Fund</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:RadioButtonList id="rd_pf" runat="server" Width="144px" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="T">Yes</asp:ListItem>
                                        <asp:ListItem Value="F">No</asp:ListItem>
                                    </asp:RadioButtonList></TD><TD style="WIDTH: 100px">Designation</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_desigation" runat="server" Width="264px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px">Retired Professionals</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:RadioButtonList id="rd_retired" runat="server" Width="144px" RepeatDirection="Horizontal"><asp:ListItem Value="1">Yes</asp:ListItem>
<asp:ListItem Selected="True" Value="0">No</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 100px">Department</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_dep" runat="server" Width="264px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"></TD><TD colSpan=2></TD></TR><TR><TD style="WIDTH: 150px">Pay </TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:DropDownList id="cmb_pay" runat="server" Width="163px" AutoPostBack="True" OnSelectedIndexChanged="cmb_pay_SelectedIndexChanged">
                                    </asp:DropDownList></TD><TD style="WIDTH: 100px">Basic Pay</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:DropDownList id="cmb_basic" runat="server" Width="178px" AutoPostBack="True" OnSelectedIndexChanged="cmb_basic_SelectedIndexChanged">
                                    </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 150px">Variable DA</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:RadioButtonList id="rd_da" runat="server" Width="148px" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rd_da_SelectedIndexChanged">
                                        <asp:ListItem Value="T">Yes</asp:ListItem>
                                        <asp:ListItem Value="F">No</asp:ListItem>
                                    </asp:RadioButtonList></TD><TD style="WIDTH: 100px">Security&nbsp;Deposit</TD><TD style="WIDTH: 100px; TEXT-ALIGN: center"><asp:RadioButtonList id="rd_secdep" runat="server" Width="153px" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rd_secdep_SelectedIndexChanged">
                                        <asp:ListItem Value="T">Yes</asp:ListItem>
                                        <asp:ListItem Value="F">No</asp:ListItem>
                                    </asp:RadioButtonList></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:Panel id="pnl_secdep" runat="server" Width="125px" Height="50px"><TABLE style="WIDTH: 605px" border=1><TBODY><TR><TD style="WIDTH: 108px; TEXT-ALIGN: left">Security&nbsp;Deposit</TD><TD style="WIDTH: 99px"><asp:TextBox id="txt_secdep" onkeypress="ValidateNumber('txt_secdep')" runat="server" Width="195px" MaxLength="7"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Deposit&nbsp;Amount</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_depamt" onkeypress="ValidateNumber('txt_depamt')" runat="server" Width="163px" MaxLength="7"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 108px; TEXT-ALIGN: left">RD&nbsp;Amount</TD><TD style="WIDTH: 99px"><asp:TextBox id="txt_rdamt" onkeypress="ValidateNumber('txt_rdamt')" runat="server" Width="195px" MaxLength="6"></asp:TextBox></TD><TD style="WIDTH: 100px; TEXT-ALIGN: left">Inst No</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txt_instno" onkeyup="correct('txt_instno')" runat="server" Width="79px" MaxLength="3"></asp:TextBox>&nbsp;Months</TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 150px; HEIGHT: 28px">Total Salary</TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txt_salary" runat="server" Width="158px" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 28px">Bond</TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:DropDownList id="cmb_bond" runat="server" Width="179px" AutoPostBack="True" OnSelectedIndexChanged="cmb_bond_SelectedIndexChanged">
                                        <asp:ListItem Value="0">No Bond</asp:ListItem>
                                        <asp:ListItem Value="1">Indeminity Cum Surety</asp:ListItem>
                                        <asp:ListItem Value="2">Assurance Bond</asp:ListItem>
                                    </asp:DropDownList></TD></TR>
    <tr>
        <td colspan="2" style="height: 28px">
            Authorised Person </td>
        <td colspan="2" style="height: 28px">
            <asp:TextBox ID="txtid" runat="server" Style="position: relative" onblur="detailDisplay()" onkeyup="isNumeric()" Width="90%"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2" style="height: 28px">
            Name</td>
        <td colspan="2" style="height: 28px">
            <asp:TextBox ID="txtname" runat="server" Style="position: relative" Width="90%" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:Panel id="pnl_bond" runat="server" Width="125px" Height="50px">
                                        <table border="1" style="width: 609px">
                                            <tr>
                                                <td style="width: 111px">
                                                    Bond Amount</td>
                                                <td style="width: 79px">
                                                    <asp:TextBox ID="txt_bondamt" runat="server" Width="195px"></asp:TextBox></td>
                                                <td style="width: 100px">
                                                    Period</td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txt_bondprd" runat="server" Width="163px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </asp:Panel> </TD></TR><TR><TD style="WIDTH: 150px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rd_secdep" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" >
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" OnClientClick="return fillchk()" /></td>
            <td style="text-align: center" >
                <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="62px" BorderStyle="None" ForeColor="Transparent" /></td>
        </tr>
    </table>
</asp:Content>

