<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="previous_deatils_san.aspx.vb" Title="Previous Leave Details" Inherits="WebAppHRMS.leave_Leave_sanction2_978d56b37917" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body  onload="startTime()" style="background-color:#CCDDEE">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table border="1" style="width:650px; height: 113px">
        <caption><h4 style="width:100%;">EMPLOYEE PREVIOUS DETAILS</h4></caption>
          <%--  <tr<%-->
                <td colspan="6" style="height: 19px">
                    <asp:Label ID="Label1" runat="server" Width="574px"></asp:Label></td>
            </tr>--%>
     <%--       <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
                    <asp:RadioButton ID="rdbHo" runat="server" AutoPostBack="True" Checked="True" GroupName="rdbctgry"
                        Text="HO Staff" />
                    <asp:RadioButton ID="rdbBr" runat="server" AutoPostBack="True" GroupName="rdbctgry"
                        Text="Branch Staff" Width="115px" /></td>
          <%--  </tr>--%>
           <%-- <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                    <asp:RadioButton ID="rdbRec" runat="server" AutoPostBack="True" Checked="True" GroupName="rdboptn"
                        Text="Recommend" />&nbsp;
                    <asp:RadioButton ID="rdbSanc" runat="server" AutoPostBack="True" GroupName="rdboptn"
                        Text="Sanction" Width="102px" /></td>
            </tr>--%>
            <%--&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;--%>
            <%--<tr><td colspan="5" style="text-align:center;"><h4 style="width:100%;">EMPLOYEE PREVIOUS DETAILS</h4></td></tr>--%><%--<%--   <tr>
             id='row2'>
                <td style="width: 225px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommend By</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="txt_rec_by" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="100" /></td>
            </tr>
            <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                </td>
            </tr>--%><%--<tr>--%>
                <%--<td colspan="10" style="color: #cc0000; height: 19px">
                    &nbsp;<asp:DropDownList ID="cmb_leave" runat="server" Width="610px" OnChange="return emp_fill()" onblur="emp_fill()" onfocus="emp_fill()" style="font-size: 11pt; font-family: 'Courier New'" AutoPostBack="True">
                    </asp:DropDownList></td>
            </tr>--%>
          <%--  <tr>
                <td colspan="10" style="color: #cc0000; height: 19px">
                </td>
            </tr>
        --%>
            
         <%--   <tr>
                <td colspan="6" style="color: #cc0000;">
                    <span style="font-size: 11pt; font-family: Courier New">
                    (Emp.Code&nbsp; -&nbsp;Leave From date - Leave To Date -Applied Date- Name )</span></td>
            </tr>--%>
           <%-- <t<%--r>
                <td colspan="6" style="text-align: center">
                    <asp:Panel ID="Panel1" runat="server">
                        <table border="1" style="width: 664px; height: 1px">
                            <tr>
                <td colspan="6" style="height: 1px; text-align: center">
                    <strong><span style="color: #6600cc; font-family: Courier New; text-decoration: underline">
                        Details Of Available Leave</span></strong></td>
                            </tr>
                            <tr>
                <td style="height: 1px; text-align: center" valign="top" colspan="6">
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">
                        Casual : <span style="font-size: 24pt"></span>
                        <input id="txt_cas" style="width: 40px" type="text" runat="server" readonly="readOnly" /></span><span style="color: #0000cc"> 
                            &nbsp; &nbsp;&nbsp;&nbsp;<span style="font-size: 14pt">|</span>&nbsp;
                            </span></span>
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">
                        Sick :&nbsp;
                        <input id="txt_sik" style="width: 40px" type="text" runat="server" readonly="readOnly" />
                        &nbsp; &nbsp; <span style="font-size: 14pt"></span></span><span style="color: #0000cc">
                            <span style="font-size: 14pt">|</span> &nbsp; </span>
                    </span>
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #0000cc">
                        Earned :&nbsp;
                        <input id="txt_earn" style="width: 40px" type="text" runat="server" readonly="readOnly" /></span><span style="color: #ff3399"><span style="color: #0000cc"></span></span></span></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>--%>
         <%--   <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Emp Name</span></td>
                <td colspan="2" style="height: 1px; width: 122px; text-align: left;">
                    <input id="txt_name" style="height: 16px; font-size: 11pt; width: 153px; font-family: 'Courier New';" type="text" runat="server" readonly="readOnly"/></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Duration</span></td>
                <td colspan="2" style="width: 105px; height: 1px; text-align: left">
                    <input id="txt_dur" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'; height: 16px" /></td>
            </tr>--%>
         <%--   <tr>
                <td style="width: 243px; text-align: left; height: 22px;">
                    <span style="font-size: 11pt; font-family: Courier New">Apply Date</span></td>
                <td colspan="2" style="height: 22px; width: 122px;">
                    <input id="txt_appdt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 237px; font-family: 'Courier New'; height: 15px" /></td>
                <td style="width: 147px; text-align: left; height: 22px;">
                    <span style="font-size: 11pt; font-family: Courier New">Leave Type</span></td>
                <td colspan="2" style="width: 105px; height: 22px; text-align: left">
                    <input id="txt_ltyp" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'; height: 15px" /></td>
            </tr>--%>
          <%--  <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">From Date </span>
                </td>
                <td colspan="2" style="height: 1px; width: 122px; text-align: left;">
                    <input id="txt_frdt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 153px; font-family: 'Courier New'" /></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">To Date</span></td>
                <td style="width: 105px; height: 1px; text-align: left;" colspan="2">
                    <input id="txt_todt" readonly="readonly" type="text" runat="server" style="font-size: 11pt; width: 151px; font-family: 'Courier New'" /></td>
            </tr>--%>
         <%--   <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Branch</span></td>
                <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <asp:DropDownList ID="cmb_branch" runat="server" Enabled="False" Width="160px" Font-Bold="False" style="font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
                <td style="width: 147px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Post</span></td>
                <td style="width: 105px; height: 1px; text-align: left" colspan="2">
                    <asp:DropDownList ID="cmb_post" runat="server" Enabled="False" Width="194px" style="font-size: 11pt; font-family: 'Courier New'">
                    </asp:DropDownList></td>
            </tr>--%>
                        <tr>
                <td style="width: 325px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">EMPLOYEE CODE</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text1" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
            </tr>
          
                <td style="width: 325px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">EMPLOYEE NAME</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text2" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
            <tr>
             <tr>
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL
                        LEAVE TO BE SANCTIONED</span></td>
                          <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text6" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="text_sick" type="text" runat="server" readonly="readOnly" style="width: 96px; font-family: 'Courier New';" /></td>--%>
              </tr>
               <tr>
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL
                        LEAVE SANCTIONED</span></td>
                          <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text7" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="text_sick" type="text" runat="server" readonly="readOnly" style="width: 96px; font-family: 'Courier New';" /></td>--%>
              </tr>
            <tr>
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL EARLY GOING TO BE SANCTIONED</span></td>
                        <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text4" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
        
                        
                        
               <%-- <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="txt_tot_mon" type="text" runat="server" readonly="readOnly" style="width: 100px; font-family: 'Courier New';" /></td>--%>
              </tr>
               <tr>
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL EARLY GOING SANCTIONED</span></td>
                        <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text8" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
        
                        
                        
               <%-- <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="txt_tot_mon" type="text" runat="server" readonly="readOnly" style="width: 100px; font-family: 'Courier New';" /></td>--%>
              </tr>
              <tr>
              
                <td style="width: 325px; height: 17px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL COMPENSATORY TO BE SANCTIONED</span></td>
                      <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text5" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td style="width: 74px; height: 1px; text-align: left" colspan="2">
                    <input id="txt_CASUL" type="text" style="width: 95px; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>--%>
            </tr>
             <tr>
              
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL COMPENSATORY SANCTIONED</span></td>
                      <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text9" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td style="width: 74px; height: 1px; text-align: left" colspan="2">
                    <input id="txt_CASUL" type="text" style="width: 95px; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>--%>
            </tr>
            
            
            
            
             <tr>
              
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL TOUR TO BE SANCTIONED</span></td>
                      <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text10" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td style="width: 74px; height: 1px; text-align: left" colspan="2">
                    <input id="txt_CASUL" type="text" style="width: 95px; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>--%>
            </tr>
             <tr>
              
                <td style="width: 325px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL TOUR SANCTIONED</span></td>
                      <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text11" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="50" /></td>
      
              <%--  <td style="width: 74px; height: 1px; text-align: left" colspan="2">
                    <input id="txt_CASUL" type="text" style="width: 95px; font-family: 'Courier New';" runat="server" readonly="readOnly" /></td>--%>
            </tr>
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            <%--
              <tr>
               <td style="width: 225px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">TOTAL
                       </span></td>
               <%-- <td colspan="2" style="height: 1px; text-align: left; width: 122px;">
                    <input id="text3" type="text" runat="server" readonly="readOnly" style="width: 96px; font-family: 'Courier New';" /></td>--%> 
                     <%-- <td colspan="5" style="height: 17px; text-align: left">
                    <input id="Text3" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="100" /></td>
      
            </tr>--%>
           
<%--            <tr id='row1'>
                <td style="width: 573px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommend<br />
                        Reason</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="txt_recom_reason" runat="server" readonly="readonly" style="font-size: 11pt; width: 361px;
                        font-family: 'Courier New'" type="text" maxlength="100" /></td>
            </tr>--%>
          <%--  <tr id='row2'>
                <td style="width: 225px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommend By</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <input id="txt_rec_by" runat="server" readonly="readonly" style="font-size: 11pt; width: 100%;
                        font-family: 'Courier New'" type="text" maxlength="100" /></td>
            </tr>
            <tr>
                <td style="width: 225px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Recommend Date</span></td>
                <td colspan="5" style="height: 17px; text-align: left">
                    <asp:TextBox ID="txt_RecDate" runat="server" ReadOnly="True" style="width:100%; "></asp:TextBox></td>
            </tr>--%>
         <%--   <tr>
                <td colspan="6" style="height: 15px; text-align: center">
                    <span style="color: #cc0000; font-family: Courier New">
                        <strong><span style="color: #ff0000; text-decoration: underline;">Employee Requested Details</span></strong></span></td>
            </tr>--%>
            <%--<t<%--<%--r>
                <td colspan="6" style="height: 15px; text-align: center">
                    <div style="text-align: center">
                        <table border="0" style="width: 648px; height: 24px">
                            <tr>
                                <td style="width: 103px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">From&nbsp;Date</span></td>
                                <td style="width: 87px; text-align: left">
                        <asp:TextBox ID="txt_ReqFrDt" runat="server" Font-Names="Courier New" ReadOnly="True" Width="117px" BackColor="MintCream" ForeColor="Blue" Height="16px"></asp:TextBox></td>
                                <td style="width: 94px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">To&nbsp;Date</span></td>
                                <td style="width: 72px; text-align: left">
                    <asp:TextBox ID="txt_ReqToDt" runat="server" Font-Names="Courier New" ReadOnly="True" Width="127px" BackColor="MintCream" ForeColor="Blue" Height="16px"></asp:TextBox></td>
                                <td style="width: 100px; text-align: right">
                                    <span style="font-size: 11pt; color: #3300ff; font-family: Courier New">Duration</span></td>
                                <td style="width: 100px; text-align: left; font-size: 12pt; font-family: Times New Roman;">
                                    <asp:TextBox ID="txt_req_days" runat="server" BackColor="MintCream" Font-Names="Courier New"
                                        MaxLength="3" ReadOnly="True" Width="99px" style="vertical-align: middle; text-align: center"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>--%>
                <%-- <tr>
                    <td style="width: 187px; height: 15px; text-align: left;">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                    <td style="width: 100px; height: 15px;">
                        </td>
                    <td style="width: 122px; height: 15px;" colspan="2">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                <td style="width: 100px; height: 15px; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="width: 187px; height: 15px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #3300ff">
                        </span> </span>
                </td>
                <td style="width: 100px; height: 15px; text-align: left">
                    <asp:TextBox ID="txt_req_days1" runat="server" BackColor="MintCream" Font-Names="Courier New"
                        ForeColor="Blue" ReadOnly="True" Width="155px"></asp:TextBox></td>
                <td colspan="2" style="width: 122px; height: 15px">
                    &nbsp;
                </td>
                <td style="font-size: 12pt; width: 100px; height: 15px">
                    &nbsp;
                </td>
            </tr>--%><%--   <tr id ="lima" style="font-size: 12pt; font-family: Times New Roman;">
                <td style="height: 13px; text-align: center;" colspan="6">
                    &nbsp;
                    <input id="Checkbox1" style="width: 20px; height: 21px; font-weight: bold; font-size: 14pt; color: #ff0000;" type="checkbox" onclick="return Checkbox1_onclick()" runat="server" />
                    &nbsp; <span
                        style="font-family: Courier New; color: #ff0000; text-decoration: underline;"><strong>Partial
                    Recommendation</strong></span></td>
            </tr>--%><%-- <tr id="sre"  style="display:none; font-size: 12pt; font-family: Times New Roman;">
                <td colspan="6" style="height: 13px">
                    <div style="text-align: center">
                        <table border="0" style="width: 652px; height: 28px;">
                            <tr>
                                <td style="width: 99px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">From&nbsp;Date</span></td>
                                <td style="width: 69px; text-align: left">
                    <asp:TextBox ID="txt_ParFrDt" onblur="OnCheckDate()" runat="server" MaxLength="11" Width="117px" Font-Names="Courier New" Height="16px"></asp:TextBox></td>
                                <td style="width: 91px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">To&nbsp;Date</span></td>
                                <td style="width: 106px; text-align: left">
                    <asp:TextBox ID="txt_ParToDt" onblur="OnCheckToDate()" runat="server" MaxLength="11" Width="127px" Font-Names="Courier New" Height="16px"></asp:TextBox></td>
                                <td style="width: 100px; text-align: right">
                                    <span style="font-size: 11pt; font-family: Courier New">Duration</span></td>
                                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_par_days" runat="server" Font-Names="Courier New" MaxLength="3"
                        Width="99px" ReadOnly="True" style="vertical-align: middle; text-align: center"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>--%><%--<%--<tr>
                <td colspan="6" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                        <table border="0">
                            <tr>
                                <td style="width: 103px; height: 23px">
                                    <input id="btn_Previous" style="width: 165px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="PREVIOUS DETAILS" onclick="return cmd_previous_onclick()" /></td>
                                <td style="width: 100px; height: 23px;">
                    <input id="cmd_details" style="width: 95px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="DETAILS" onclick="return cmd_details_onclick()" /></td>
                                <td style="width: 100px; height: 23px;"><input id="cmd_applnform" style="width: 165px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="APPLICATION FORM" onclick="return cmd_applnform_onclick()" runat="server"  /></td>
                                <td colspan="2" style="width: 5px; height: 23px;">
                                    <input id="cmd_support" style="width: 119px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="SUPPORTINGS " onclick="return cmd_support_onclick()" runat="server" /></td>
                                    <td style="height: 23px"> <input id="cmd_pl28" style="width: 79px; height: 28px; font-size: 12pt; font-family: 'Courier New';" type="button" value="PL 28" onclick="return cmd_pl28_onclick()" runat="server"  /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="6" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                    <table border="0" style="width: 386px; height: 37px">
                            <tr>
                                <td colspan="2" style="height: 31px">
                                    <input id="cmd_rec" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="RECOMMEND" onclick="return cmd_rec_onclick()" runat="server" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="cmb_acc" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="SANCTION" onclick="return cmb_acc_onclick()" runat="server" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="cmd_reject" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="submit" value="REJECT" onclick="return cmd_reject_onclick()" /></td>
                                <td style="width: 100px; height: 31px;">
                    <input id="Button2" style="width: 98px; height: 26px; font-size: 12pt; font-family: 'Courier New';" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>--%>
        </table>
        <br />
        <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
       
            &nbsp;</div>
       
                    <input id="hid_empcode" runat="server" style="width: 1px" type="hidden" />
                    <input id="hid_str" runat="server" style="width: 1px" type="hidden" />
                    <input id="hid_seq" runat="server" style="width: 1px" type="hidden" />
                        <input id="hid_rej" runat="server" style="width: 1px" type="hidden" />
       
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    </form>
            <%--  </tr>--%>
</body>
</html>
           
