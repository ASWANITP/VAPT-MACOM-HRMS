<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="increment_all_approve.aspx.vb" Inherits="WebAppHRMS.increment_all_approve" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    
        <script language="javascript" type="text/javascript" for="window" event="onload">
            window.onload = callback();
            function callback() {
         return window_onload();
     }
    </script>


 
 <script type="text/javascript" language="javascript">
          var cs = cont_name.split("cmb");


          function btnExit_onclick() {
              window.open('../home.aspx', '_self');
     }
       

</script>
    <table align="center" border="1" style="width: 710px; height: 452px;">
        <tr>
            <td colspan="4" style="text-align: center; width: 748px;">
                <strong><span style="color: #990033">SALARY INCREMENT<br />
                </span></strong>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Label ID="lbl_err" runat="server" ForeColor="#400000" Width="543px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center; height: 229px; width: 748px;">
                <table align="center" style="width: 533px">
                    <tr>
                        <td colspan="4" style="height: 18px; text-align: center; background-color: #ffcccc;">
                            <table align="center" style="width: 533px" border="1">
                                <tr>
                                    <td colspan="2" style="height: 24px; text-align: left; width: 112px;">
                                        <strong><span style="color: #cc0033">Select&nbsp;Employee</span></strong></td>
                                    <td colspan="2" style="height: 24px; text-align: left">
                                        <asp:DropDownList ID="cmb_employee" runat="server" Width="420px" BackColor="WhiteSmoke" autopostback="true" Font-Bold="True">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                           <%-- <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_employee">
                            </cc1:ListSearchExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">Name</td>
                        <td style="width: 100px">
                            <input id="txt_name" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; text-align: left">Post</td>
                        <td style="width: 112px">
                            <input id="txt_post" runat="server" readonly="readonly" type="text" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">Designation</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_designtn" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">Department</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_deptmnt" runat="server" readonly="readonly" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">Branch</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_branch" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">Joining Date</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_joindt" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 26px; text-align: left">Firm</td>
                        <td style="width: 100px; height: 26px">
                            <input id="txt_firm" runat="server" readonly="readonly" type="text" />
                        </td>
                        <td style="width: 116px; height: 26px; text-align: left">Current Basic</td>
                        <td style="width: 112px; height: 26px">
                            <input id="txt_basic" runat="server" readonly="readonly" type="text" />
                        </td>
                    </tr>
                  
                                <tr>
                                    <td colspan="4" style="height: 24px; text-align: center">
                                        <strong><span style="font-size: 11pt; color: #cc0033; text-decoration: underline;">INCREMENT DETAILS</span></strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Pay&nbsp;Scale</span></strong></td>
                                    <td style="width: 82px; height: 24px">
                                         
                                    <input id="cmb_pay" runat="server" readonly="readonly" type="text" />
                                        </td>
                                   
                                </tr>
                                <tr id="spcl_row">
                                    <td style="width: 100px; height: 24px; text-align: left"></td>
                                    <td style="width: 82px; height: 24px"></td>
                                    <td style="width: 889px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Amount</span></strong></td>
                                      <td style="width: 100px; height: 26px">
                                <input id="txt_amount" runat="server" readonly="readonly" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Effective&nbsp;Date</span></strong></td>
                                     <td style="width: 100px; height: 26px">
                                 <input id="txt_effdt" runat="server" readonly="readonly" type="text" />
                                    </td>
                                    <td style="width: 889px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Total&nbsp;Salary</span></strong></td>
                                         <td style="width: 100px; height: 26px">
                                            <input id="txt_totalsal" runat="server" readonly="readonly" type="text" />
                                         </td>
                                </tr>
                                <tr>

                                    <td style="width: 100px; height: 24px; text-align: left">
                                        <strong><span style="color: #ff0033">Remark</span></strong></td>
                                      <td style="width: 100px; height: 26px">
                                    <input id="text_remark" runat="server" readonly="readonly" type="text" />
                                    </td>
                                </tr>
                            </table>
                        
                &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 110px; width: 748px;" colspan="4">
                
                <table style="width: 349px">
                    <tr>
                        <td>
                            <asp:Button ID="cmd_confirm" runat="server" Text="Approve" Font-Bold="True" Width="100px" BackColor="#C0C0FF" /></td>
                          <td>
                            <asp:Button ID="cmd_reject" runat="server" Text="Reject" Font-Bold="True" Width="100px" BackColor="#C0C0FF" /></td>
                        <td>
                            <asp:Button ID="cmd_exit" runat="server" Text="  Exit  " Font-Bold="True" Width="100px" BackColor="#C0C0FF" /></td>
                         <td>
                         <asp:Button ID="cmd_report" runat="server" Font-Bold="True" Text="Report" Width="100px" BackColor="#C0C0FF" /></td>
                    </tr>
                </table>
                
                
        </tr>
    </table>
</asp:Content>
