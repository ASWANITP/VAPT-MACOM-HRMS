<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Additional_emp_details.aspx.vb" Inherits="WebAppHRMS.Additional_emp_details_a74e8e202020" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button2_onclick() {
            window.open('../../home.aspx', '_self');
        }
        function van() {
            alert("Please select date from calendar! ")
            return false;
        }

        function integersOnly(obj) {
            obj.value = obj.value.replace(/[^0-9-.]/g, '');
        }

        function onlyAlphabets(e, t) {

            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 8) || (charCode == 32))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }


        function blockSpecialChar(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || (k >= 48 && k <= 57));
        }

        function allowNumTextSpace(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }

        function allowNumeric(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k >= 48 && k <= 57));
        }



        function emailValidate() {
            var email = document.getElementById("<%=txtOfficemail.ClientID%>");
            var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
            if (!filter.test(email.value)) {
                alert('Please provide a valid email address');
                email.focus;
                return false;
            }
            return true;
        }

        function chkdt(a) {
            var value1 = document.getElementById("<%=txtstartdate.ClientID%>").value;
      var value2 = document.getElementById("<%=txtenddate.ClientID%>").value;

      var day1, day2;
      var month1, month2;
      var year1, year2;
      day1 = value1.substring(0, value1.indexOf("/"));
      month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
      year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

      day2 = value2.substring(0, value2.indexOf("/"));
      month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
      year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

      date1 = year1 + "/" + month1 + "/" + day1;
      date2 = year2 + "/" + month2 + "/" + day2;

      firstDate = Date.parse(date1)
      secondDate = Date.parse(date2)

      msPerDay = 24 * 60 * 60 * 1000;

      dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);

      if (dbd < 0) {
          alert("End date cannot be less than start date!")
          document.getElementById("<%=txtenddate.ClientID%>").value = "";
             document.getElementById("<%=txtenddate.ClientID%>").focus();
             return false;
         }
         else {
             document.getElementById("<%=cmd_confirm.ClientID%>").focus();
                return true;
            }
        }


        function chkdt1(a) {
            var value1 = document.getElementById("<%=txtstartdate.ClientID%>").value;
     var value2 = document.getElementById("<%=txtenddate.ClientID%>").value;

     var day1, day2;
     var month1, month2;
     var year1, year2;
     day1 = value1.substring(0, value1.indexOf("/"));
     month1 = value1.substring(value1.indexOf("/") + 1, value1.lastIndexOf("/"));
     year1 = value1.substring(value1.lastIndexOf("/") + 1, value1.length);

     day2 = value2.substring(0, value2.indexOf("/"));
     month2 = value2.substring(value2.indexOf("/") + 1, value2.lastIndexOf("/"));
     year2 = value2.substring(value2.lastIndexOf("/") + 1, value2.length);

     date1 = year1 + "/" + month1 + "/" + day1;
     date2 = year2 + "/" + month2 + "/" + day2;

     firstDate = Date.parse(date1)
     secondDate = Date.parse(date2)

     msPerDay = 24 * 60 * 60 * 1000;

     dbd = Math.round((secondDate.valueOf() - firstDate.valueOf()) / msPerDay);

     if (dbd < 0) {
         alert("Start date cannot be greater than end date!")
         document.getElementById("<%=txtstartdate.ClientID%>").value = "";
             document.getElementById("<%=txtstartdate.ClientID%>").focus();
             return false;
         }
         else {
             document.getElementById("<%=cmd_confirm.ClientID%>").focus();
                return true;
            }
        }





        //$(window).on('popstate', function(event) {
        // return true;
        //});


        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" width="70%">
            <tr>
                <td colspan="5">
                    <strong>EMPLOYEE ADDITIONAL DETAILS<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 500px; text-align: left; height: 16px;"><strong>Enter Employee Code</strong></td>
                                        <td style="text-align: left; height: 16px;" colspan="3">&nbsp;<asp:TextBox ID="txtEcode" runat="server" AutoPostBack="True" MaxLength="6"
                                            OnTextChanged="txtEcode_TextChanged" Width="95px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 500px; text-align: left" colspan="1"><strong>Employee&nbsp;Code :</strong> </td>
                                        <td style="width: 392px; text-align: left" colspan="1">
                                            <asp:Label ID="lbl_code" runat="server" Width="148px" ForeColor="Navy"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" style="width: 500px; text-align: left">
                                            <strong>Employee&nbsp;Name :</strong>&nbsp;</td>
                                        <td colspan="1" style="width: 392px; text-align: left">
                                            <asp:Label ID="lbl_name" runat="server" Width="226px" ForeColor="Navy"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 500px; text-align: left"><strong>Post</strong></td>
                                        <td style="width: 106px; text-align: left;">
                                            <asp:Label ID="lblPost" runat="server" ForeColor="Navy" Width="226px"></asp:Label></td>
                                        <td style="width: 392px" colspan="2">
                                            <asp:Label ID="lblpostid" runat="server" Width="148px" Text="0" ForeColor="Navy" Visible="False"></asp:Label>&nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1390px; text-align: left"><strong>Branch</strong></td>
                                        <td style="width: 106px; text-align: left;">
                                            <asp:Label ID="lblBranch" runat="server" ForeColor="Navy" Width="226px"></asp:Label></td>
                                        <td style="width: 392px" colspan="2">
                                            <asp:Label ID="lblbranchid" runat="server" Width="148px" Text="0" ForeColor="Navy" Visible="False"></asp:Label>&nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; background: lightgrey; color: maroon; font-size: 10pt; font-weight: bold;" colspan="4">PERSONAL IDENTITY</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; height: 367px;" colspan="4" rowspan="2">
                                            <table>
                                                <tr>
                                                    <td style="width: 150;">Aadhar No</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAadhar" runat="server" Style="width: 200px; text-align: left" MaxLength="12" onkeypress="return allowNumeric(event)"></asp:TextBox></td>
                                                    <td style="width: 50;"></td>
                                                    <td style="width: 150;">PAN No</td>
                                                    <td>
                                                        <asp:TextBox ID="txtPan" runat="server" Style="width: 200px; text-align: left" MaxLength="10" onkeypress="return blockSpecialChar(event)"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">UAN No</td>
                                                    <td>
                                                        <asp:TextBox ID="txtUAN" runat="server" Style="width: 200px; text-align: left" MaxLength="12" onkeypress="return blockSpecialChar(event)"></asp:TextBox></td>
                                                    <td style="width: 50px"></td>
                                                    <td style="width: 150px">ESI No</td>
                                                    <td>
                                                        <asp:TextBox ID="txtESI" runat="server" Style="width: 200px; text-align: left" MaxLength="10" onkeypress="return blockSpecialChar(event)"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        <br />
                                                    </td>
                                                    <td></td>
                                                    <td style="width: 50px"></td>
                                                    <td style="width: 150px"></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">Locality/Land Mark</td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtLocality" runat="server" Style="width: 300px; text-align: left" Width="2594px" MaxLength="99" onkeypress="return allowNumTextSpace(event)"></asp:TextBox>
                                                        (Employee's present Location)</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">Official Mail ID</td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtOfficemail" runat="server" Style="width: 300px; text-align: left"
                                                            Width="2594px" MaxLength="49" onchange="emailValidate(this.value)"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="text-align: left; background: lightgrey; color: maroon; font-size: 10pt; font-weight: bold;">BANK DETAILS</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="text-align: left">
                                                        <table>
                                                            <tr style="font-size: 11pt;">
                                                                <td style="width: 150px; text-align: center;">A/C No.</td>
                                                                <td style="width: 350px; text-align: center;">BANK</td>
                                                                <td style="width: 250px; text-align: center;">BRANCH</td>
                                                                <td style="width: 150px; text-align: center;">IFSC</td>
                                                            </tr>
                                                            <tr style="font-size: 9pt;">
                                                                <td style="width: 150px; text-align: center; height: 26px;">
                                                                    <asp:TextBox ID="txtacno" runat="server" Style="width: 150px; text-align: left"
                                                                        Width="1px" MaxLength="24" onkeypress="return allowNumeric(event)"></asp:TextBox></td>
                                                                <td style="width: 150px; text-align: center; height: 26px;">
                                                                    <asp:TextBox ID="txtbank" runat="server" Style="width: 300px; text-align: left"
                                                                        Width="1px" MaxLength="49" onkeypress="return allowNumTextSpace(event)"></asp:TextBox></td>
                                                                <td style="width: 300px; text-align: center; height: 26px;">
                                                                    <asp:TextBox ID="txtbranch" runat="server" Style="width: 300px; text-align: left"
                                                                        Width="1px" MaxLength="49" onkeypress="return allowNumTextSpace(event)"></asp:TextBox></td>
                                                                <td style="width: 300px; text-align: center; height: 26px;">
                                                                    <asp:TextBox ID="txtifc" runat="server" Style="width: 150px; text-align: left"
                                                                        Width="1px" MaxLength="15" onkeypress="return blockSpecialChar(event)"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                        <asp:LinkButton ID="lnkbank" runat="server" ForeColor="Maroon" OnClick="lnkbank_Click">Delete This Bank Account</asp:LinkButton>
                                                        <asp:HiddenField ID="hdnacno" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" style="background-position: 0% 0%; font-weight: bold; font-size: 10pt; background-attachment: scroll; background-image: none; color: maroon; background-repeat: repeat; text-align: left">-</td>
                                                </tr>



                                                <tr>
                                                    <td colspan="5" style="text-align: left; background: lightgrey; color: maroon; font-size: 10pt; font-weight: bold;">MEDICAL INSURANCE DETAILS</td>
                                                </tr>

                                                <tr>
                                                    <td colspan="5" style="text-align: left; height: 2px;">
                                                        <table>
                                                            <tr style="font-size: 11pt;">
                                                                <td style="width: 150px; text-align: center; height: 19px;">INSURANCE NO.</td>
                                                                <td style="width: 350px; text-align: center; height: 19px;">COMPANY</td>
                                                                <td style="width: 250px; text-align: center; height: 19px;">START DATE</td>
                                                                <td style="width: 150px; text-align: center; height: 19px;">END. DATE</td>
                                                            </tr>
                                                            <tr style="font-size: 9pt;">
                                                                <td style="width: 150px; text-align: center;">
                                                                    <asp:TextBox ID="txtinsno" runat="server" Style="width: 150px; text-align: left"
                                                                        Width="1px" MaxLength="25" onkeypress="return blockSpecialChar(event)"></asp:TextBox></td>
                                                                <td style="width: 1500px; text-align: center;">
                                                                    <asp:TextBox ID="txtinscompany" runat="server" Style="width: 300px; text-align: left"
                                                                        Width="1px" MaxLength="49" onkeypress="return allowNumTextSpace(event)"></asp:TextBox></td>
                                                                <td style="width: 300px; text-align: center;">
                                                                    <asp:TextBox ID="txtstartdate" runat="server" Style="width: 300px; text-align: left"
                                                                        Width="1px" MaxLength="11" onchange="chkdt1(this.value)"></asp:TextBox>
                                                                </td>
                                                                <td style="width: 300px; text-align: center;">
                                                                    <asp:TextBox ID="txtenddate" runat="server" Style="width: 150px; text-align: left"
                                                                        Width="1px" MaxLength="11" onchange="chkdt(this.value)"></asp:TextBox>&nbsp;

                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:LinkButton ID="lnkins" runat="server" ForeColor="Maroon" OnClick="lnkins_Click">Delete This Medical Insurance</asp:LinkButton>&nbsp;
                   <asp:HiddenField ID="hdninsno" runat="server" />
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtenddate" BehaviorID="ctl20_CalendarExtender2" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtstartdate" BehaviorID="ctl20_CalendarExtender1" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="5" style="background-position: 0% 0%; font-weight: bold; font-size: 10pt; background-attachment: scroll; background-image: none; color: maroon; background-repeat: repeat; text-align: left">-</td>
                                                </tr>


                                                <tr>

                                                    <td colspan="5" style="text-align: left; background: lightgrey; color: maroon; font-size: 10pt; font-weight: bold;">OTHER DETAILS</td>
                                                </tr>

                                                <tr>
                                                    <td colspan="5" style="text-align: left; height: 2px;">
                                                        <table>
                                                            <tr style="font-size: 11pt;">
                                                                <td style="width: 150px; text-align: center; height: 19px;">POSITION CATEGORY.</td>
                                                                <td style="width: 350px; text-align: center; height: 19px;">TECH LEAD</td>
                                                                <td style="width: 250px; text-align: center; height: 19px;">TRANSFER FROM FIRM</td>
                                                                <td style="width: 150px; text-align: center; height: 19px;">EMPLOYEE LEVEL</td>
                                                            </tr>
                                                            <tr style="font-size: 9pt;">
                                                                <td style="width: 150px; text-align: center;">
                                                                    <asp:TextBox ID="Txtposition" runat="server" Style="width: 150px; text-align: left"
                                                                        Width="1px" MaxLength="25" onkeypress=" return onlyAlphabets(event)"></asp:TextBox></td>
                                                                <td style="width: 1500px; text-align: center;">
                                                                    <asp:DropDownList ID="DDLTL" runat="server" Width="171px">
                                                                    </asp:DropDownList></td>
                                                    </td>
                                                    <td style="width: 300px; text-align: center;">
                                                        <asp:TextBox ID="Txttransfr" runat="server" Style="width: 300px; text-align: left"
                                                            Width="1px" MaxLength="25" onkeypress="return onlyAlphabets(event)"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 300px; text-align: center;">
                                                        <asp:DropDownList ID="DDLL" runat="server" Width="171px"></asp:DropDownList>&nbsp;
                                                    </td>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
               &nbsp; &nbsp; &nbsp; &nbsp;
                                                </tr>
                                        </td>
                                    </tr>
                            </table>
                            &nbsp; &nbsp;
                   
               </td>
           </tr>
                        
                        
                         </tr>
    
    
  
    
    </TR>
       </tr>
    
    
    
    
    
    </TBODY></TABLE>
       
       </table>
    </TD></TR>
    
       
    

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 164px">&nbsp;
                </td>
                <td style="width: 79px; text-align: right;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 122px; text-align: left;">&nbsp;
                    <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                <td style="width: 122px; text-align: left">
                    <asp:Button ID="btnReset" runat="server" Text="RESET" /></td>
                <td style="width: 128px">
                    <asp:Button ID="btnReport" runat="server" Text="Export to Excel" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

