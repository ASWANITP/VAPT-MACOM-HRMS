<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="masterpiece.aspx.vb" Inherits="WebAppHRMS.emp_transfer_0011b6051410" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script type="text/javascript"  src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script type ="text/javascript" >
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
function cmd_rec_onclick() 
{debugger;

document.getElementById("<%=cmd_confirm1.ClientID %>").click();
}
 function integersOnly(obj) {
        obj.value = obj.value.replace(/[^0-9.]/g,'');

    }
    function chkemail(a) {
       // alert(a);
        var email = document.getElementById(a);
            //alert(email);
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!filter.test(email.value)) {            
                alert('Please provide a valid email address');
                email.focus;
                email.clear;
                // $("#txt_emailid").val('');
             
                return false;
            }
        }
        
        
        
        
        
        
            function IsSpecialKeys(e) {debugger;
            var specialKeys = new Array();
            specialKeys.push(')');
            specialKeys.push('(');
            specialKeys.push('*');
            specialKeys.push('&');
            specialKeys.push('^');
            specialKeys.push('%');
            specialKeys.push('$');
            specialKeys.push('#');
            specialKeys.push('@');
            specialKeys.push('!');
            specialKeys.push('<');
            specialKeys.push('>');
            specialKeys.push('/');
            specialKeys.push('\\');
            if (specialKeys.indexOf(e.key) != -1) {
                alert("SPECIAL CHARACTERS NOT ALLOWED")
                return false;
            }
            return true;
        }
        
        

//function emailValidate() {
//        var email = document.getElementById("<%=textepmail.ClientID%>");
//        var email = document.getElementById("<%=textoffmail.ClientID%>");
//        //var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
//        var filter = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{3,}$/;
//        if (!filter.test(email.value)) {
//            alert('Please provide a valid email address');
//            email.value = '' ;
//            email.focus;
//            return false;
//        }
//        return true;
//}


//        $(document).ready(function ifscvalid() {
//        alert(1);
//        $('#textifsc').keypress(function (event) {
//            var keycode = (event.keyCode ? event.keyCode : event.which);
//            var TextValue = document.getElementById("textifsc").value;
//            var firstFourLetter =  TextValue.substring(1,4); 
//            var lastFourLetter = TextValue.substring(5,10);
//            if (firstFourLetter.keycode >= '65' && lastFourLetter.keycode <= '90') {
//                return true;
//            }
//            return false;
//        });
//    });

    
    
    function ifscvalid(l) {
    alert(1);
            var ifsc = document.getElementById('<%=textifsc.ClientID%>').value;
            var reg = /^[A-Za-z]{4}[a-zA-Z0-9]{7}$/;

            if (ifsc.match(reg)) {
                return true;
            }
            else {
                alert("You Entered Wrong IFSC Code \n\n ------ or------ \n\n IFSC code should be count 11 \n\n-> Starting 4 should be only alphabets[A-Z] \n\n-> Remaining 7 should be accepting only alphanumeric");
                document.getElementById("<%=textifsc.ClientID%>").focus();
                return false;
            }

        }
        
        
         function ph_val() {
    alert(1);
             var ph = document.getElementById('<%=txtcontno.ClientID%>').value;
            var reg = /^[0-9]+$/;

            if (ph.match(reg)) {
                return true;
            }
            else {
                alert("You Entered Wrong IFSC Code \n\n ------ or------ \n\n IFSC code should be count 11 \n\n-> Starting 4 should be only alphabets[A-Z] \n\n-> Remaining 7 should be accepting only alphanumeric");
                document.getElementById("<%=textifsc.ClientID%>").focus();
                return false;
            }

        }
        
        
        
        function ValidateId() {debugger

        var result = document.getElementById("ctl00_cph_edp_dropid").value;
        //aadhar
        if (result == 8) {
            var aadhaar = document.getElementById("ctl00_cph_edp_dropid").value;
            var expr = /^(\d{4}\d{4}\d{4}$)|(\d{4}\s\d{4}\s\d{4}$)|(\d{4}-\d{4}-\d{4}$)/;
            if (!expr.test(aadhaar)) {
                alert("Invalid Aadhar Number");
                  document.getElementById("ctl00_cph_edp_textidpoorf").value = '';
            }
        }

        //passport
        if (result == 1) {

            var passportNumber = document.getElementById("ctl00_cph_edp_dropid").value;
            var expr = /^[A-PR-WY][1-9]\d\s?\d{4}[1-9]$/;
            if (!expr.test(passportNumber)) {
                alert("Invalid Passport Number");
                document.getElementById("ctl00_cph_edp_textidpoorf").value = '';
            }
        }


        //license number

        if (result == 2) {


            var expr = /^[a-zA-Z]{2}-\d\d-(19\d\d|20[01][0-9])-\d{7}$/;

            var obj = document.getElementById("ctl00_cph_edp_dropid").value;
            if (!expr.test(obj)) {
                alert("Invalid Liscence Number");
               document.getElementById("ctl00_cph_edp_textidpoorf").value = '';
            }
        }
        //id voters


        if (result == 3) {

            var expr = /^[A-Z]{3}\d{7}$/;
            var obj = document.getElementById("ctl00_cph_edp_dropid").value;
            if (!expr.test(obj)) {
                alert("Invalid Voter's Id Number");
                document.getElementById("ctl00_cph_edp_textidpoorf").value = '';
            }
        }

        //Ration card

        if (result == 4) {
            var expr = /^([a-zA-Z0-9]){8,12}\s*$/;
            var obj = document.getElementById("ctl00_cph_edp_dropid").value;
            if (!expr.test(obj)) {
                alert("Invalid Ration Card Number");
                document.getElementById("ctl00_cph_edp_dropid").value = '';
            }
        }

        //Pan card

        if (result == 5) {
            var expr = /[A-Z]{5}[0-9]{4}[A-Z]{1}$/;
            var obj = document.getElementById("ctl00_cph_edp_dropid").value;
            if (!expr.test(obj)) {
                alert("Invalid Pan Card Number");
                document.getElementById("ctl00_cph_edp_textidpoorf").value = '';
            }
        }
    }




    function Validateformat() {debugger

        var label = document.getElementById("ctl00_cph_edp_Labelid1");
        //alert(label.innerHTML);
        var resu = document.getElementById("ctl00_cph_edp_dropid").value;

        if (resu == 1) {
            label.innerHTML = 'S2893644';
        }
        if (resu == 2) {
            label.innerHTML = 'KL-09-20220010949';
        }

        if (resu == 3) {
            label.innerHTML = 'ABE1234566';
        }
        if (resu == 4) {
            label.innerHTML = 'FAFAAFAF8989';
        }
        if (resu == 5) {
            label.innerHTML = 'EEEEE2689M';
        }
        if (resu == 8) {
            label.innerHTML = '1111-4444-8888';

        }
        if (resu == 9) {
            label.innerHTML = '';
        }

    }

    

</script>

    <div style="text-align: center">
  <table>
    <tr>
      <td style="width: 25px; height: 1192px;">
        <table border="1" style="text-align: center; background-color: transparent;">
          <tr>
            <td colspan="4" style="text-align: center; height: 44px; background-color: #ffcc33; border-right: #ff3333 thin solid; border-top: #ff3333 thin solid; border-left: #ff3333 thin solid; border-bottom: #ff3333 thin solid; width: 1180px;">
              <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16pt" Text="MASTER MODIFICATION" ForeColor="Red" Height="27px"></asp:Label>
            </td>
          </tr>
          <tr>
            <td colspan="4" style="text-align: center; height: 28px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="BASIC DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <tr>
            <td colspan="4" style="height: 17px; text-align: center; width: 1180px;">
              <table style="BORDER-RIGHT: gold thin dotted; BORDER-TOP: gold thin dotted; BORDER-LEFT: gold thin dotted; BORDER-BOTTOM: gold thin dotted; TEXT-ALIGN: center; height: 249px;" border="1" id="TABLE1">
                <TBODY>
                  <TR>
                    <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 118px;"> Emp Name
    </TD>
                    <TD style="height: 118px">
                      <asp:CheckBox ID="Checkname" AutoPostBack="true" OnCheckedChanged="Checkname_CheckedChanged" runat="server"  />
                    </TD>
                    <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 118px;">
                      <asp:TextBox id="textname" runat="server" Width="245px" ReadOnly="True"  MaxLength="40"></asp:TextBox>
                    <TD style="WIDTH: 109px; TEXT-ALIGN: left; height: 118px;"> House Name
    </TD>
                    <TD style="width: 173px; height: 118px;">
                      <asp:CheckBox ID="Checkhouse" AutoPostBack="true" OnCheckedChanged="Checkhouse_CheckedChanged" runat="server" />
                    </TD>
                    <TD style="TEXT-ALIGN: left; height: 118px;">
                      <asp:TextBox id="texthouse" runat="server" Width="245px" ReadOnly="True"  MaxLength="40"></asp:TextBox>
                    </TD><%--
											<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 2px;">
          Post Office
      </TD>
											<TD>
												<asp:CheckBox ID="Checkpost"  AutoPostBack="true" OnCheckedChanged=" Checkpost_CheckedChanged" runat="server" />
											</TD>
											<TD style="WIDTH: 128px; TEXT-ALIGN: left; height: 2px;">
												<asp:TextBox id="textpost" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
											</TD>--%> <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 118px;"> Pincode </TD>
                    <TD style="height: 118px">
                      <asp:CheckBox ID="Checkpin" AutoPostBack="true" OnCheckedChanged=" Checkpin_CheckedChanged" runat="server" />
                    </TD>
                    <TD style="WIDTH: 128px; TEXT-ALIGN: left; height: 118px;">
                      <asp:TextBox id="textpin" runat="server" Width="245px" ReadOnly="True" MaxLength="6"  onkeyup="integersOnly(this)"></asp:TextBox>
                      <asp:Button ID="Button1" runat="server" Text="Check" />
                      <asp:Panel id="pnl" runat="server">
                  <tr>
                    <td colspan="2" style=" text-align: left; width: 198px; height: 25px;">
                      <asp:Label ID="Label7" runat="server" Text="Select Exact Place :" Width="150px"></asp:Label>
                    </td>
                    <td colspan="3" style=" text-align: left; height: 25px;">
                      <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="cmb_dist_select_SelectedIndexChanged" ID="cmb_dist_select" runat="server" Width="150px" Font-Names="Verdana"></asp:DropDownList>
                    </td>
                  </tr>
                  </asp:Panel>
            </TD>
          </TR>
          <TR><%--
											<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 28px;">
          Land mark 
      </TD>
											<TD>
												<asp:CheckBox ID="Checland" AutoPostBack="true" OnCheckedChanged=" Checland_CheckedChanged" runat="server" />
											</TD>
											<TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 28px;">
												<asp:TextBox id="textland" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
											</TD>--%> <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 44px;"> State
    </TD>
            <TD style="height: 44px"> &nbsp; </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 44px;">
              <asp:TextBox id="Textstate" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 109px; TEXT-ALIGN: left; height: 28px;"> District </TD>
            <TD style="width: 173px"> &nbsp; </TD>
            <TD style="TEXT-ALIGN: left; height: 28px;">
              <asp:TextBox id="textdistrict" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 2px;"> Post Office </TD>
            <TD> &nbsp; </TD>
            <TD style="WIDTH: 128px; TEXT-ALIGN: left; height: 2px;">
              <asp:TextBox id="textpost" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
            </TD>
          </TR>
          <TR><%--      
											<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 44px;">
          state
      </TD>
											<TD style="height: 44px">
												<asp:CheckBox ID="Checkstate" AutoPostBack="true" OnCheckedChanged=" Checkgender_CheckedChanged" runat="server" />
											</TD>
											<TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 44px;">
												<asp:TextBox id="Textstate" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
											</TD>
      --%> <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 28px;"> Land Mark
    </TD>
            <TD>
              <asp:CheckBox ID="Checland" AutoPostBack="true" OnCheckedChanged=" Checland_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 28px;">
              <asp:TextBox id="textland" runat="server" Width="245px" ReadOnly="True" MaxLength="30"></asp:TextBox>
            </TD>
          </TR>
          <tr>
            <td colspan="9" style="text-align: center; height: 38px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="PERSONAL DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <TR>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 101px;"> DOB </TD>
            <TD style="height: 101px">
              <asp:CheckBox ID="Checkdob" AutoPostBack="true" OnCheckedChanged=" Checkpin_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 101px;">
              <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
              <asp:TextBox id="textdob" onkeypress="return van()" runat="server" Width="245px" MaxLength="10" ReadOnly="True"></asp:TextBox>
              <cc1:CalendarExtender TargetControlID="textdob" Format="dd/MMM/yyyy" runat="server" ID="caldob"></cc1:CalendarExtender>
            </TD><%--
											<TD style="WIDTH: 109px; TEXT-ALIGN: left">
          Pan No.&nbsp;
      </TD>
											<TD>
												<asp:CheckBox ID="Checkpan"  AutoPostBack="true" OnCheckedChanged=" Checkql_CheckedChanged" runat="server" />
											</TD>
											<TD style="WIDTH: 146px; TEXT-ALIGN: left">
												<asp:TextBox id="Textpan" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
											</TD>--%> <TD style="WIDTH: 110px;text-align :left ; height: 101px;"> Contact No </TD>
            <TD style="height: 101px">
              <asp:CheckBox ID="Checkcontno" AutoPostBack="true" OnCheckedChanged=" Checkcontno_CheckedChanged" runat="server" />
            </TD>
            <TD style="TEXT-ALIGN: left; height: 101px;">
              <asp:TextBox id="txtcontno" runat="server" Width="245px" ReadOnly="True"  MaxLength="10" onkeyup="integersOnly(this)" AutoPostBack="True"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 101px;"> Blood Group </TD>
            <TD style="height: 101px">
              <asp:CheckBox ID="Checkblood" AutoPostBack="true" OnCheckedChanged=" Checkblood_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 87px; TEXT-ALIGN: left; height: 101px;">
              <asp:TextBox id="txtblood" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
              <asp:DropDownList ID="dropblood" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropblood_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
          </TR>
          <TR>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 39px;"> Gender </TD>
            <TD style="height: 39px">
              <asp:CheckBox ID="Checkgender" AutoPostBack="true" OnCheckedChanged=" Checkgender_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 39px;">
              <asp:TextBox id="textgender" runat="server" Width="245px" MaxLength="2" ReadOnly="True"></asp:TextBox>
              <asp:DropDownList ID="dropgender" AutoPostBack="true" OnSelectedIndexChanged="dropgender_SelectedIndexChanged" runat="server" Width="172px">
                <asp:ListItem Value="1">M</asp:ListItem>
                <asp:ListItem Value="0">F</asp:ListItem>
              </asp:DropDownList>
            </TD>
            <TD style="WIDTH: 109px; TEXT-ALIGN: left; height: 39px;"> Marital Status </TD>
            <TD style="height: 39px; width: 173px;">
              <asp:CheckBox ID="Checkmarital" AutoPostBack="true" OnCheckedChanged=" Checkmarital_CheckedChanged" runat="server" />
            </TD>
            <TD style="TEXT-ALIGN: left; height: 39px;">
              <asp:TextBox id="textmarital" runat="server" Width="245px" ReadOnly="True" MaxLength="10"></asp:TextBox>
              <asp:DropDownList ID="dropmari" AutoPostBack="true" OnSelectedIndexChanged="dropmari_SelectedIndexChanged" runat="server" Width="172px">
                <asp:ListItem Value="1">SINGLE</asp:ListItem>
                <asp:ListItem Value="2">MARRIED</asp:ListItem>
              </asp:DropDownList>
            </TD><%--
											<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 44px;">
          Blood Group 
      </TD>
											<TD style="height: 44px">
												<asp:CheckBox ID="Checkblood" AutoPostBack="true" OnCheckedChanged=" Checkblood_CheckedChanged" runat="server" />
											</TD>
											<TD style="WIDTH: 87px; TEXT-ALIGN: left; height: 28px;">
												<asp:TextBox id="TextBox4" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
											</TD>--%> <TD style="WIDTH: 110px; HEIGHT: 39px; TEXT-ALIGN: left"> ID Proof No. </TD>
            <TD style="height: 39px">
              <asp:CheckBox ID="Checkidpoorf" AutoPostBack="true" OnCheckedChanged=" Checkidpoorf_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 128px; HEIGHT: 39px; TEXT-ALIGN: left">
        <asp:Label ID="Labelid1" runat="server"  ForeColor="#FF3300" Width="110px"></asp:Label>
              <asp:TextBox id="textidpoorf" runat="server" Width="245px"  onchange=" ValidateId()"  MaxLength="18"></asp:TextBox>
            </TD>
          </TR>
          <TR>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 48px;"> Emp Mail </TD>
            <TD style="height: 48px">
              <asp:CheckBox ID="Checkepmail" AutoPostBack="true"   OnCheckedChanged=" Checkgender_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 48px;">
          <asp:TextBox id="textepmail" runat="server" Width="245px" ReadOnly="True" onblur="return chkemail(this.id);" MaxLength="25" onchange="emailValidate(this.value)"
></asp:TextBox>
            </TD>
            <TD style="WIDTH: 109px; HEIGHT: 48px; TEXT-ALIGN: left"> ID Name </TD>
            <TD style="height: 48px">
              <asp:CheckBox ID="Checkidname" AutoPostBack="true" OnCheckedChanged=" Checkidname_CheckedChanged" runat="server" />
            </TD>
            <TD style="HEIGHT: 48px; TEXT-ALIGN: left">
              <asp:TextBox id="textidname" runat="server" Width="243px" ReadOnly="True" MaxLength="5"></asp:TextBox>
              <asp:DropDownList ID="dropid" runat="server" onchange="Validateformat()" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
             <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 48px;">Residence Phone No </TD>
            <TD style="height: 48px">
              <asp:CheckBox ID="Checkres" AutoPostBack="true" OnCheckedChanged=" Checkres_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 48px;">
              <asp:TextBox id="Textres" runat="server" Width="245px" MaxLength="10" ReadOnly="True" onkeyup="integersOnly(this)" ></asp:TextBox>
            </TD><%--
											<TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left">
           ID Proof No.  
      </TD> 
											<TD>
												<asp:CheckBox ID="CheckBox26" AutoPostBack="true" OnCheckedChanged=" Checkidpoorf_CheckedChanged"  runat="server" />
											</TD>
											<TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
			
			
										<asp:TextBox id="TextBox27" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
									</TD>--%>
        <tr>
          <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 48px;">Qualification </TD>
            <TD style="height: 48px">
              <asp:CheckBox ID="Checkqul" AutoPostBack="true" OnCheckedChanged=" Checkres_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 48px;">
              <asp:TextBox id="Textqul" runat="server" MaxLength="20" Width="245px"  />
            </TD>
  
     
            
            
         
         
         
          </TR>
          <tr>
            <td colspan="9" style="text-align: center; height: 28px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="EMPLOYMENT DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <TR>
            <TD style="WIDTH: 110px; HEIGHT: 9px; TEXT-ALIGN: left"> Designation </TD>
            <TD style="height: 9px">
              <asp:CheckBox ID="Checkdesignation" AutoPostBack="true" OnCheckedChanged=" Checkdesignation_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; HEIGHT: 9px; TEXT-ALIGN: left">
              <asp:TextBox id="textdesignation" runat="server" Width="243px"  ReadOnly="True" MaxLength="25"></asp:TextBox>
              <asp:DropDownList ID="dropdesig" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdesig_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
            <TD style="WIDTH: 109px; HEIGHT: 9px; TEXT-ALIGN: left"> Post Name </TD>
            <TD style="height: 9px; width: 173px;">
              <asp:CheckBox ID="Checkpostname" AutoPostBack="true" OnCheckedChanged=" Checkpostname_CheckedChanged" runat="server" />
            </TD>
            <TD style="HEIGHT: 9px; TEXT-ALIGN: left">
              <asp:TextBox id="textpostname" runat="server" Width="243px" ReadOnly="True" MaxLength="20"></asp:TextBox>
              <asp:DropDownList ID="Droppost" runat="server" AutoPostBack="true" OnSelectedIndexChanged="droppost_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
            <TD style="WIDTH: 110px; HEIGHT: 9px; TEXT-ALIGN: left"> Department </TD>
            <TD style="height: 9px">
              <asp:CheckBox ID="Checkdep" AutoPostBack="true"  OnCheckedChanged=" Checkdep_CheckedChanged"  runat="server"  />
            </TD>
            <TD style="WIDTH: 128px; HEIGHT: 9px; TEXT-ALIGN: left">
              <asp:TextBox id="textdep" runat="server" Width="245px" ReadOnly="True" MaxLength="20"></asp:TextBox>
              <asp:DropDownList ID="DropDep" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdep_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
          </TR>
          <TR>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 80px;"> DOJ </TD>
            <TD style="width: 173px; height: 80px;">
              <asp:CheckBox ID="Checkdoj" AutoPostBack="true" onkeypress="return van()" OnCheckedChanged="Checkdoj_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 87px; TEXT-ALIGN: left; height: 80px;">
              <asp:TextBox id="textdoj" runat="server" Width="245px" ReadOnly="True" MaxLength="10"></asp:TextBox>
              <cc1:CalendarExtender TargetControlID="textdoj" Format="dd/MMM/yyyy" runat="server" ID="caldoj"></cc1:CalendarExtender>
            </TD>
            <%--<TD style="WIDTH: 109px; TEXT-ALIGN: left"> Department Head
            <TD style="width: 173px">
              <asp:CheckBox ID="Checkdh" AutoPostBack="true" OnCheckedChanged=" Checkdh_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 87px; TEXT-ALIGN: left">
              <asp:TextBox id="textdh" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
              <asp:DropDownList ID="Dropdh" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdh_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>--%>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 80px;"> Official Mail </TD>
            <TD style="height: 80px">
              <asp:CheckBox ID="Checkoffmail" AutoPostBack="true" OnCheckedChanged=" Checkoffmail_CheckedChanged" runat="server" />
            </TD>
            <TD style="TEXT-ALIGN: left; height: 80px;">
              <asp:TextBox id="textoffmail" runat="server" Width="245px" ReadOnly="True" MaxLength="30" onblur="return chkemail(this.id);"  onchange="emailValidate(this.value)"
></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 80px;"> First Line Manager </TD>
            <TD style="height: 80px">
              <asp:CheckBox ID="Checktlm" AutoPostBack="true" OnCheckedChanged=" Checktlm_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 128px; TEXT-ALIGN: left; height: 80px;">
              <asp:TextBox id="texttlm" runat="server" Width="245px" ReadOnly="True" MaxLength="15"></asp:TextBox>
              <asp:DropDownList ID="Droptlm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="droptlm_SelectedIndexChanged" TabIndex="26" Width="181px" Font-Names="Verdana"></asp:DropDownList>
            </TD>
          </TR>
          <TR>
            <TD style="WIDTH: 110px; HEIGHT: 59px; TEXT-ALIGN: left"> Position Category
    </TD>
            <TD style="height: 59px">
              <asp:CheckBox ID="Checkpc" AutoPostBack="true" OnCheckedChanged=" Checkpc_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 128px; HEIGHT: 59px; TEXT-ALIGN: left">
              <asp:TextBox id="textpc" runat="server" Width="245px" ReadOnly="True" MaxLength="35"></asp:TextBox>
            </TD>
												<TD style="WIDTH: 109px; TEXT-ALIGN: left; height: 59px;">
                                                           Status</td>
          
													<TD style="width: 173px; height: 59px;">
														<asp:CheckBox ID="Checksts" AutoPostBack="true" OnCheckedChanged="Checksts_CheckedChanged" runat="server" />
													</TD>
													<TD style="TEXT-ALIGN: left; height: 59px;">
														<asp:TextBox id="textsts" runat="server" Width="245px" ReadOnly="True" MaxLength="15"></asp:TextBox>
														<asp:DropDownList ID="Dropsts" AutoPostBack="true" OnSelectedIndexChanged="dropsts_SelectedIndexChanged" runat="server" Width="245px">
                <asp:ListItem Value="0">---SELECT---</asp:ListItem>
                <asp:ListItem Value="1">LIVE</asp:ListItem>
                <asp:ListItem Value="2">NOTICE PERIOD</asp:ListItem>
                <asp:ListItem Value="3">LONG LEAVE</asp:ListItem>
                <asp:ListItem Value="4">MATERNITY LEAVE</asp:ListItem>
                <asp:ListItem Value="5">RESIGNED</asp:ListItem>
              </asp:DropDownList>
													</TD>	
													
													
												
									<TD style="WIDTH: 119px; TEXT-ALIGN: left; height: 59px;">
                                                           Second Line Manager</td>
          
													<TD style="width: 173px; height: 59px;">
														<asp:CheckBox ID="checksclma" AutoPostBack="true" OnCheckedChanged=" Checksclm_CheckedChanged" runat="server" />
													</TD>
													<TD style="TEXT-ALIGN: left; height: 59px;">
														<asp:TextBox id="textsclm" runat="server" Width="245px" ReadOnly="True" MaxLength="15"></asp:TextBox>
														<asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="dropsclm_SelectedIndexChanged" runat="server" Width="245px">
                
              </asp:DropDownList>
													</TD>				
												
												
												
													
													
													
																			
													
														<TD style="height: 59px">
														<label runat="server" style="color:Red;" id="mylab1">
        *Start Date:</label>
														<cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="startdt" runat="server" ID="Calenstart"></cc1:CalendarExtender>
														<asp:TextBox  runat="server" id="startdt"></asp:TextBox>
														<label runat="server" style="color:Red;" id="mylab2">
        *Resign Submitted Date:</label>
														<cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="resig_sub_dt" runat="server" ID="Calenresub"></cc1:CalendarExtender>
														<asp:TextBox  runat="server" id="resig_sub_dt"></asp:TextBox>
													</TD>
														<TD style="height: 59px">
														<label runat="server" style="color:Red;" id="mylab3">
        *End Date:</label>
														<cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="enddt" runat="server" ID="Calend"></cc1:CalendarExtender>
														<asp:TextBox  runat="server" id="enddt"></asp:TextBox>
														<cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="prop_exit_dt" runat="server" ID="Calenproex"></cc1:CalendarExtender>
														<label runat="server" style="color:Red;" id="mylab4">*Proposed or Exit Date:</label>
														<asp:TextBox  runat="server" id="prop_exit_dt"></asp:TextBox>
													</TD>
														<TD style="height: 59px">
														<label runat="server" style="color:Red;" id="mylab5">
        *Reason:</label>
														<asp:TextBox  runat="server" id="reason"></asp:TextBox>
													</TD>
          </TR>
          
          
         <TR>
         
           
           
             <TD style="WIDTH: 109px; TEXT-ALIGN: left; height: 39px;"> Category </TD>
            <TD style="height: 39px; width: 173px;">
              <asp:CheckBox ID="Checkcategory" AutoPostBack="true" OnCheckedChanged=" Checkcategory_CheckedChanged" runat="server" />
            </TD>
            <TD style="TEXT-ALIGN: left; height: 39px;">
              <asp:TextBox id="Textcategory" runat="server" Width="245px" ReadOnly="True" MaxLength="10"></asp:TextBox>
              <asp:DropDownList ID="dropcategory" AutoPostBack="true" OnSelectedIndexChanged="dropcategory_SelectedIndexChanged" runat="server" Width="172px">
                <asp:ListItem Value="1">IT</asp:ListItem>
                <asp:ListItem Value="2">NON IT</asp:ListItem>
              </asp:DropDownList>
            </TD>
           
           
           
           
           
           
           
          
            
          </TR>
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
          
          
          
          
          
          
          
          
          
          
          
          
          
          <tr>
            <td colspan="9" style="text-align: center; height: 76px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="SALARY DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <TR>
            <TD style="WIDTH: 110px; text-align :left ; height: 28px;"> *Basic Pay
            <TD style="width: 173px">
              <asp:CheckBox ID="Checkbpay" AutoPostBack="true" OnCheckedChanged=" Checkcontno_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 87px; TEXT-ALIGN: left; height: 28px;">
              <asp:TextBox id="textbpay" runat="server" Width="245px" ReadOnly="True"  onkeyup="integersOnly(this)" MaxLength="20"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> *CTC Adjustment </TD>
            <TD>
              <asp:CheckBox ID="Checkctcadj" AutoPostBack="true" OnCheckedChanged=" Checkctcadj_CheckedChanged" runat="server" />
            </TD>
            <TD style="HEIGHT: 28px; TEXT-ALIGN: left">
              <asp:TextBox id="textctcadj" runat="server" Width="245px" ReadOnly="True"  onkeyup="integersOnly(this)" MaxLength="20"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> *Level </td>
            <TD style="width: 173px">
              <asp:CheckBox ID="Checklvl" AutoPostBack="true" OnCheckedChanged=" Checklvl_CheckedChanged" runat="server" />
            </TD>
            
            
            <TD style="WIDTH: 87px; HEIGHT: 28px; TEXT-ALIGN: left">
              <asp:TextBox id="textlvl" runat="server" Width="243px" ReadOnly="True" MaxLength="25"></asp:TextBox>
            </TD><%--      
														<TD style="WIDTH: 109px; TEXT-ALIGN: left">
          TA Total 
           
															<TD style="width: 173px">
																<asp:CheckBox ID="CheckBox6" AutoPostBack="true" OnCheckedChanged=" Checkta_CheckedChanged" runat="server" />
															</TD>
															<TD style="WIDTH: 87px; TEXT-ALIGN: left">
																<asp:TextBox id="TextBox7" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
															</TD>--%><%--
															<TD style="WIDTH: 110px; TEXT-ALIGN: left">
          Gross Salary
      </TD>
															<TD>
																<asp:CheckBox ID="CheckBox7"  AutoPostBack="true" OnCheckedChanged=" Checkgros_CheckedChanged"  runat="server" />
															</TD>
															<TD style="WIDTH: 128px; TEXT-ALIGN: left">
																<asp:TextBox id="TextBox8" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
															</TD>--%><%--
															<TR>
																<TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left">
         Fixed TA 
      </TD>
																<TD>
																	<asp:CheckBox ID="Checkfixta"  AutoPostBack="true" OnCheckedChanged=" Checkfixta_CheckedChanged" runat="server" />
																</TD>
																<TD style="WIDTH: 146px; HEIGHT: 28px; TEXT-ALIGN: left">
																	<asp:TextBox id="txtfixta" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																</TD>
																<TD style="WIDTH: 90px; HEIGHT: 28px; TEXT-ALIGN: left">
          Outstation 
          
																	<TD style="width: 173px">
																		<asp:CheckBox ID="Checkoutstation"  AutoPostBack="true" OnCheckedChanged=" Checkoutstation_CheckedChanged" runat="server" />
																	</TD>
																	<TD style="WIDTH: 87px; HEIGHT: 28px; TEXT-ALIGN: left">
																		<asp:TextBox id="textoutstation" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																	</TD>
																	<TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left">
          Telephone Allowance 
      </TD>
																	<TD>
																		<asp:CheckBox ID="Checktelallow"  AutoPostBack="true" OnCheckedChanged=" Checktelallow_CheckedChanged" runat="server" />
																	</TD>
																	<TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
																		<asp:TextBox id="txttelallow" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																	</TD>
																</TR>--%><%--
																<TR>
																	<TD style="WIDTH: 110px; HEIGHT: 16px; TEXT-ALIGN: left">
           Distance Allowance 
        </TD>
																	<TD>
																		<asp:CheckBox ID="Checkdisallow"  AutoPostBack="true" OnCheckedChanged=" Checkdisallow_CheckedChanged" runat="server" />
																	</TD>
																	<TD style="WIDTH: 146px; HEIGHT: 16px; TEXT-ALIGN: left">
																		<asp:TextBox id="txtdisallow" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																	</TD>
																	<TD style="WIDTH: 90px; HEIGHT: 16px; TEXT-ALIGN: left">
           Special allowance
            
																		<TD style="width: 173px">
																			<asp:CheckBox ID="Checkdistallow"  AutoPostBack="true" OnCheckedChanged=" Checkdisallow_CheckedChanged"  runat="server" />
																		</TD>
																		<TD style="WIDTH: 87px; HEIGHT: 16px; TEXT-ALIGN: left">
																			<asp:TextBox id="textspallow" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																		</TD>
																		<TD style="WIDTH: 110px; HEIGHT: 16px; TEXT-ALIGN: left">
           Hardware TA 
      </TD>
																		<TD>
																			<asp:CheckBox ID="Checkharta" AutoPostBack="true" OnCheckedChanged=" Checkharta_CheckedChanged" runat="server" />
																		</TD>
																		<TD style="WIDTH: 128px; HEIGHT: 16px; TEXT-ALIGN: left">
																			<asp:TextBox id="txtharta" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																		</TD>
																	</TR>--%><%-- 
																	<TR>
																		<TD style="WIDTH: 110px; HEIGHT: 21px; TEXT-ALIGN: left">
            HRA 
        </TD>
																		<TD>
																			<asp:CheckBox ID="Checkhra" AutoPostBack="true" OnCheckedChanged=" Checkhra_CheckedChanged" runat="server" />
																		</TD>
																		<TD style="WIDTH: 146px; HEIGHT: 21px; TEXT-ALIGN: left">
																			<asp:TextBox id="txthra" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																		</TD>
																		<TD style="WIDTH: 90px; HEIGHT: 21px; TEXT-ALIGN: left">
           Fixed Variable Allowance
            
																			<TD style="width: 173px">
																				<asp:CheckBox ID="Checkfixallow" AutoPostBack="true" OnCheckedChanged=" Checkfixallow_CheckedChanged" runat="server" />
																			</TD>
																			<TD style="WIDTH: 87px; HEIGHT: 21px; TEXT-ALIGN: left">
																				<asp:TextBox id="textfixallow" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																			</TD>
																			<TD style="WIDTH: 110px; HEIGHT: 21px; TEXT-ALIGN: left">
         Vehicle Fuel Maintenance </TD>
																			<TD>
																				<asp:CheckBox ID="Checkvfm" AutoPostBack="true" OnCheckedChanged=" Checkvfm_CheckedChanged"  runat="server" />
																			</TD>
																			<TD style="WIDTH: 128px; HEIGHT: 21px; TEXT-ALIGN: left">
																				<asp:TextBox id="txtvfm" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																			</TD>
																		</TR>--%><%-- 
																		<TR>
																			<TD style="WIDTH: 110px; HEIGHT: 67px; TEXT-ALIGN: left">
          Driver Salary Reimbursement 
        </TD>
																			<TD style="height: 67px">
																				<asp:CheckBox ID="Checkdsr"  AutoPostBack="true" OnCheckedChanged=" Checkdsr_CheckedChanged" runat="server" />
																			</TD>
																			<TD style="WIDTH: 146px; HEIGHT: 67px; TEXT-ALIGN: left">
																				<asp:TextBox id="txtdsr" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																			</TD>
																			<TD style="WIDTH: 90px; HEIGHT: 67px; TEXT-ALIGN: left">
           Child Education Allowance 
            
																				<TD style="width: 173px; height: 67px;">
																					<asp:CheckBox ID="Checkchilallow"  AutoPostBack="true" OnCheckedChanged=" Checkchilallow_CheckedChanged" runat="server" />
																				</TD>
																				<TD style="WIDTH: 87px; HEIGHT: 67px; TEXT-ALIGN: left">
																					<asp:TextBox id="textchilallow" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																				</TD>
																				<TD style="WIDTH: 110px; HEIGHT: 67px; TEXT-ALIGN: left">
           LTA 
      </TD>
																				<TD style="height: 67px">
																					<asp:CheckBox ID="Checklta"  AutoPostBack="true" OnCheckedChanged=" Checklta_CheckedChanged"  runat="server" />
																				</TD>
																				<TD style="WIDTH: 128px; HEIGHT: 67px; TEXT-ALIGN: left">
																					<asp:TextBox id="textlta" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																				</TD>
																			</TR>--%>
          <TR><%--
																				<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 37px;">
         Medical Reimbursement 
      </TD>
																				<TD>
																					<asp:CheckBox ID="Checkmedicalr" AutoPostBack="true" OnCheckedChanged=" Checkmedicalr_CheckedChanged" runat="server" />
																				</TD>
																				<TD style="WIDTH: 146px; TEXT-ALIGN: left; height: 37px;">
																					<asp:TextBox id="textmedicalr" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																				</TD>
																				<TD style="WIDTH: 90px; TEXT-ALIGN: left; height: 37px;">
          Sodexo
              
																					<TD style="width: 173px">
																						<asp:CheckBox ID="Checksodexo" AutoPostBack="true" OnCheckedChanged=" Checksodexo_CheckedChanged" runat="server" />
																					</TD>
																					<TD style="WIDTH: 87px; TEXT-ALIGN: left; height: 37px;">
																						<asp:TextBox id="textsodexo" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																					</TD>
																					<TD style="WIDTH: 110px; TEXT-ALIGN: left; height: 37px;">
          Audit Allowance
      </TD>
																					<TD>
																						<asp:CheckBox ID="Checkautallow" AutoPostBack="true" OnCheckedChanged=" Checkautallow_CheckedChanged" runat="server" />
																					</TD>
																					<TD style="WIDTH: 128px; TEXT-ALIGN: left; height: 37px;">
																						<asp:TextBox id="textautallow" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																					</TD>
																				</TR>--%> </TR>
          <TR><%--
																				<TD style="WIDTH: 110px; TEXT-ALIGN: left">
          Bonus/Exgratia
      </TD>
																				<TD>
																					<asp:CheckBox ID="CheckBox8"  AutoPostBack="true" OnCheckedChanged=" Checkbonus_CheckedChanged" runat="server" />
																				</TD>
																				<TD style="WIDTH: 146px; TEXT-ALIGN: left">
																					<asp:TextBox id="TextBox9" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																				</TD>--%><%--
																				<TD style="WIDTH: 109px; TEXT-ALIGN: left">
          Employer PF
             
																					<TD style="width: 173px">
																						<asp:CheckBox ID="CheckBox9"   AutoPostBack="true" OnCheckedChanged=" Checkepf_CheckedChanged"  runat="server" />
																					</TD>
																					<TD style="WIDTH: 87px; TEXT-ALIGN: left">
																						<asp:TextBox id="TextBox10" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																					</TD>
																					<TD style="WIDTH: 90px; TEXT-ALIGN: left">
          Employer PF
             
																						<TD style="width: 173px">
																							<asp:CheckBox ID="CheckBox10"   AutoPostBack="true" OnCheckedChanged=" Checkepf_CheckedChanged"  runat="server" />
																						</TD>
																						<TD style="WIDTH: 87px; TEXT-ALIGN: left">
																							<asp:TextBox id="TextBox11" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																						</TD>--%> </TR>
          <TR><%--
																						<TD style="WIDTH: 110px; HEIGHT: 35px; TEXT-ALIGN: left">
           Total CTC
        </TD>
																						<TD style="height: 35px">
																							<asp:CheckBox ID="CheckBox11" AutoPostBack="true" OnCheckedChanged=" Checktctc_CheckedChanged" runat="server" />
																						</TD>
																						<TD style="WIDTH: 146px; HEIGHT: 35px; TEXT-ALIGN: left">
																							<asp:TextBox id="TextBox12" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																						</TD>--%><%--   
																						<TD style="WIDTH: 109px; HEIGHT: 28px; TEXT-ALIGN: left">
           Bank Name   
        </TD>
																						<TD>
																							<asp:CheckBox ID="CheckBox12" AutoPostBack="true" OnCheckedChanged=" Checkbkname_CheckedChanged" runat="server" />
																						</TD>
																						<TD style="WIDTH: 146px; HEIGHT: 28px; TEXT-ALIGN: left">
																							<asp:TextBox id="TextBox13" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
																						</TD>--%> </TR>
          <TR>
            <TD style="WIDTH: 110px; HEIGHT: 47px; TEXT-ALIGN: left"> *ESI No </TD>
            <TD style="height: 47px">
              <asp:CheckBox ID="Checkesino" AutoPostBack="true" OnCheckedChanged=" Checkesino_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 128px; HEIGHT: 47px; TEXT-ALIGN: left">
              <asp:TextBox id="textesino" runat="server" Width="245px" ReadOnly="True"  onkeyup="integersOnly(this)" MaxLength="20" ></asp:TextBox>
            </TD>
            <TD style="WIDTH: 109px; HEIGHT: 47px; TEXT-ALIGN: left"> *UAN No </TD>
            <TD style="height: 47px">
              <asp:CheckBox ID="Checkuan" AutoPostBack="true" OnCheckedChanged="Checkuan_CheckedChanged" runat="server" />
            </TD>
            <TD style="HEIGHT: 47px; TEXT-ALIGN: left">
              <asp:TextBox id="Textuan" runat="server" Width="243px" ReadOnly="True" onkeyup="integersOnly(this)"  MaxLength="20"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 110px; TEXT-ALIGN: left"> *Pan No.&nbsp; </TD>
            <TD>
              <asp:CheckBox ID="Checkpan" AutoPostBack="true" OnCheckedChanged="Checkpan_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; TEXT-ALIGN: left">
              <asp:TextBox id="Textpan" runat="server" Width="245px" ReadOnly="True" MaxLength="10"></asp:TextBox>
            </TD>
          </TR>
          <tr>
            <td colspan="9" style="text-align: center; height: 19px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="BANK DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <TR><%--
																						<TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left">
          Date Of Resignation Submitted 
      </TD>
																						<TD>
																							<asp:CheckBox ID="CheckBox22"   AutoPostBack="true" OnCheckedChanged=" Checkdrs_CheckedChanged" runat="server" />
																						</TD>
																						<TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
																							<asp:TextBox id="TextBox23" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																						</TD>--%> 
					<TD style="WIDTH: 109px; HEIGHT: 51px; TEXT-ALIGN: left"> *Bank Name </TD>
            <TD style="height: 51px">
              <asp:CheckBox ID="Checkbkname" AutoPostBack="true" OnCheckedChanged=" Checkbkname_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; HEIGHT: 51px; TEXT-ALIGN: left">
              <asp:TextBox id="textbkname" runat="server" Width="243px" ReadOnly="True" MaxLength="200"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 109px; HEIGHT: 51px; TEXT-ALIGN: left"> *Bank Account no
            <TD style="width: 173px; height: 51px;">
              <asp:CheckBox ID="Checkbkaccont" AutoPostBack="true" OnCheckedChanged=" Checkbkaccont_CheckedChanged" runat="server" />
            </TD>
            <TD style="HEIGHT: 51px; TEXT-ALIGN: left">
              <asp:TextBox id="Textbkaccont" runat="server" Width="243px" ReadOnly="True" onkeyup="integersOnly(this)" MaxLength="16"></asp:TextBox>
            </TD><%--
																							<TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left">
         position category
      </TD>
																							<TD>
																								<asp:CheckBox ID="CheckBox24"  AutoPostBack="true" OnCheckedChanged=" Checkpc_CheckedChanged" runat="server" />
																							</TD>
																							<TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
																								<asp:TextBox id="TextBox25" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
																							</TD>--%> <TD style="WIDTH: 110px; HEIGHT: 51px; TEXT-ALIGN: left"> *IFSC </TD>
            <TD style="width: 173px; height: 51px;">
              <asp:CheckBox ID="Checkifsc" AutoPostBack="true" OnCheckedChanged=" Checkifsc_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 87px; HEIGHT: 51px; TEXT-ALIGN: left">
              <asp:TextBox id="textifsc" runat="server" Width="243px"  MaxLength= "11" onkeypress="return IsSpecialKeys(event);" ReadOnly="True" ></asp:TextBox>
              <%--<asp:RegularExpressionValidator ID="revBillNo" runat="server" ControlToValidate="textifsc"
                        Display="Dynamic" ErrorMessage="CHECK IFSC CODE" SetFocusOnError="True" ValidationExpression="^[0-9a-zA-Z;/?'*@-]*"></asp:RegularExpressionValidator>--%>
            </TD>
          </TR>
          <tr>
            <td colspan="9" style="text-align: center; height: 10px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="RESIGNATION DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <tR>
            <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> Exit Or Proposed Exit Date </TD>
            <TD>
              <asp:CheckBox ID="Checkexit" AutoPostBack="true" OnCheckedChanged=" Checkexit_CheckedChanged" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; HEIGHT: 28px; TEXT-ALIGN: left">
              <asp:TextBox id="textexit" onkeypress="return van()" runat="server" Width="243px" ReadOnly="True"></asp:TextBox>
              <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="textexit" runat="server" ID="calepd"></cc1:CalendarExtender>
            </TD>
        &nbsp;<TD style="WIDTH: 109px; HEIGHT: 28px; TEXT-ALIGN: left"> Reason For Resignation <TD style="width: 173px">
                <asp:CheckBox ID="Checkrfr" AutoPostBack="true" OnCheckedChanged=" Checkrfr_CheckedChanged" runat="server" />
              </TD>
              <TD style="HEIGHT: 28px; TEXT-ALIGN: left">
                <asp:TextBox id="textrfr" runat="server" Width="243px" ReadOnly="True" MaxLength="30"></asp:TextBox>
              </TD>
              <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> Date Of Resignation Submitted </TD>
              <TD>
                <asp:CheckBox ID="Checkdrs" AutoPostBack="true" OnCheckedChanged=" Checkdrs_CheckedChanged" runat="server" />
              </TD>
              <TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
                <asp:TextBox id="Textdrs" runat="server" Width="245px" ReadOnly="True" onkeyup="this.value=''" MaxLength="1"></asp:TextBox>
                <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="textdrs" runat="server" ID="caldrs"></cc1:CalendarExtender>
              </tR>
              <tr>
            <td colspan="16" style="text-align: center; height: 28px; background-color: moccasin; width: 1180px;"> &nbsp; <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="ANOTHER DETAILS" BackColor="Transparent" style="border-bottom: #ff9933 thin dotted" ForeColor="DimGray"></asp:Label>
            </td>
          </tr>
          <tR>
            <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> Skill  </TD>
            <TD>
              <asp:CheckBox ID="Checkskils" AutoPostBack="true" OnCheckedChanged=" Checkskils_CheckedChanged" runat="server"  />
            </TD>
            <TD style="WIDTH: 146px; HEIGHT: 28px; TEXT-ALIGN: left">
              <asp:TextBox
            ID="Textskils" runat="server" ReadOnly="True"
            Width="243px" ></asp:TextBox>
             
            </TD>
        &nbsp;<TD style="WIDTH: 109px; HEIGHT: 28px; TEXT-ALIGN: left"> Other firm employee Code <TD style="width: 173px">
                <asp:CheckBox ID="Checkoec" AutoPostBack="true" OnCheckedChanged=" Checkoec_CheckedChanged" runat="server" />
              </TD>
              <TD style="HEIGHT: 28px; TEXT-ALIGN: left">
                <asp:TextBox id="Textoec" runat="server" Width="243px" ReadOnly="True"  onkeyup="integersOnly(this)" MaxLength="6" ></asp:TextBox>
              </TD>
              <TD style="WIDTH: 110px; HEIGHT: 28px; TEXT-ALIGN: left"> Increment  Date </TD>
              <TD>
                <asp:CheckBox ID="Checkincrement" AutoPostBack="true" OnCheckedChanged=" Checkincrement_CheckedChanged" runat="server" />
                   <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="Textincrement" runat="server" ID="CalendarExtender2"></cc1:CalendarExtender>
              </TD>
              <TD style="WIDTH: 128px; HEIGHT: 28px; TEXT-ALIGN: left">
                <asp:TextBox id="Textincrement" runat="server" onkeyup="this.value=''" Width="245px" ReadOnly="true" MaxLength="10"></asp:TextBox>
                
              </tR>
             
          <tR>
            <TD style="WIDTH: 110px; HEIGHT: 72px; TEXT-ALIGN: left">Place Of Seating</TD>
            <TD style="height: 72px">
              <asp:CheckBox ID="Checkpos" AutoPostBack="true" OnCheckedChanged=" Checkpos_Checkepos" runat="server" />
            </TD>
            <TD style="WIDTH: 146px; HEIGHT: 72px; TEXT-ALIGN: left">
              <asp:TextBox id="Textpos" runat="server" Width="243px" ReadOnly="True" MaxLength="30"></asp:TextBox>
              
            </TD>
        &nbsp;<TD style="WIDTH: 109px; HEIGHT: 72px; TEXT-ALIGN: left"> Doj of Previous Group Company  <TD style="width: 173px; height: 72px;">
                <asp:CheckBox ID="Checkofdoj" AutoPostBack="true" OnCheckedChanged="Checkofdoj_CheckedChanged" runat="server" />
                   <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="Textdoj1" runat="server" ID="CalendarExtender1"></cc1:CalendarExtender>
              </TD>
              <TD style="HEIGHT: 72px; TEXT-ALIGN: left">
                <asp:TextBox id="Textdoj1" runat="server" Width="243px" ReadOnly="True" MaxLength="10" ></asp:TextBox>
              </TD>
              <TD style="WIDTH: 110px; HEIGHT: 72px; TEXT-ALIGN: left"> Source </TD>
              <TD style="height: 72px">
                <asp:CheckBox ID="Checksource" AutoPostBack="true" OnCheckedChanged=" Checksource_CheckedChanged" runat="server" />
              </TD>
              <TD style="WIDTH: 128px; HEIGHT: 72px; TEXT-ALIGN: left">
                <asp:TextBox id="Textsource" runat="server" Width="245px" ReadOnly="True" MaxLength="10"></asp:TextBox>
                <tr>
                
               <TD style="WIDTH: 176px; HEIGHT: 39px; TEXT-ALIGN: left"> Current Job Role Start Date </TD>
              <TD>
                <asp:CheckBox ID="cjstdte" AutoPostBack="true" OnCheckedChanged=" Checkcurrentjbstrtdte_CheckedChanged" runat="server" />
                   <cc1:CalendarExtender Format="dd/MMM/yyyy" TargetControlID="cjsdte" runat="server" ID="CalendarExtender3"></cc1:CalendarExtender>
              </TD>
              <TD style="WIDTH: 169px; HEIGHT: 29px; TEXT-ALIGN: left">
                <asp:TextBox id="cjsdte" runat="server" onkeyup="this.value=''" Width="246px" ReadOnly="true" MaxLength="11"></asp:TextBox>
                
                
                
                </tr>
          </TBODY>
        </TABLE>
      </td>
    </tr>
    <tr>
      <td colspan="4" style="background-color: moccasin; height: 59px; width: 1180px;">
        <table style="width: 690px">
          <tr>
            <td style="width: 65px; height: 7px;"></td>
            <td style="width: 100px; height: 7px;">
              <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="108px" BackColor="SeaShell" BorderColor="#FFC0C0" Font-Bold="True" Height="28px" BorderStyle="Dashed" />
            <input id="cmd_confirm1" style=" display:none;" type="submit" value="CONFIRM" onclick="return cmd_rec_onclick()" runat="server" />
            </td>
            <td style="width: 24px; height: 7px;"></td>
            <td style="width: 23px; height: 7px;"></td>
            <td style="width: 119px; height: 7px;"></td>
            <td style="width: 25px; height: 7px;"></td>
            <td style="width: 119px; height: 7px;">
              <asp:Button ID="cmd_exit" runat="server" BackColor="SeaShell" BorderColor="#FFC0C0" BorderStyle="Dashed" Font-Bold="True" Height="31px" Text="EXIT" Width="114px" />
            </td>
            <td style="width: 49px; height: 7px;"><input id="hid_rej" runat="server" style="width: 1px" type="hidden" />
            <input id="Hiddate" runat="server" style="width: 1px" type="hidden" /></td>
          </tr>
        </table> &nbsp;
      </td>
    </tr>
  </table>
  </td>
  </tr>
  </table>
</div>
</asp:Content>

