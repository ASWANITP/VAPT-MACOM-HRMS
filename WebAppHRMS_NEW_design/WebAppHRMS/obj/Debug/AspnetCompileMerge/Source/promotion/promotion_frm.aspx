<%@ Page Language="VB" MasterPageFile="~/edp.master" ValidateRequest="false" AutoEventWireup="false" CodeBehind="promotion_frm.aspx.vb" Inherits="WebAppHRMS.PROMOTION_promotion_frm_fc97d4d36758" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server"><center>
<div id="d_demo" style="text-align:center;width:750px">
<asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
<%--<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
     <ContentTemplate>--%>
                <table border="1" width="750"  id="TABLE1" align="center">
                
     
                    <tr>
                        <td colspan="4" style="text-align: center; width: 727px;">
                            <asp:Label ID="Label1" runat="server" BackColor="#E0E0E0" Font-Bold="True" Text="EMPLOYEE PROMOTION OR REVERTING FORM"
                                Width="765px" Font-Size="Larger" ForeColor="#C00000" Height="29px"></asp:Label>
    <asp:Label ID="Label3" runat="server" BackColor="#E0E0E0" Font-Bold="True" Text=""
                                Width="765px" Font-Size="Larger" ForeColor="#C00000" Height="29px"></asp:Label>
                               
                           
    </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center; width: 727px; background-color: #ffcccc;">
                            <asp:Label ID="Label2" runat="server" BackColor="#FFC0C0" Font-Bold="True" Text="CURRENT EMPLOYEE DETAILS"
                                Width="415px" Height="31px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 22px; text-align: left; width: 727px;" colspan="4">
                            <table border="1" width="750">
                                <tr>
                                    <td style="width: 100px; text-align: left">
                                        Select Employee</td>
                                    <td colspan="3" style="width: 264px">
                                        <%--<cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" PromptText="" TargetControlID="cmb_employee">
                                        </cc1:ListSearchExtender>--%>
                                        <asp:DropDownList ID="cmb_employee" runat="server" AutoPostBack="True" Width="280px">
                                        </asp:DropDownList></td>
                                    <td style="width: 1px; text-align: left">
                                        Name</td>
                                    <td style="width: 114px; text-align: left">
                                        <asp:TextBox ID="txt_name" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; text-align: left">
                                        Designation</td>
                                    <td colspan="3" style="text-align: left; width: 264px;">
                                        <asp:TextBox ID="txt_desination" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                    <td style="width: 1px; text-align: left">
                                        Post Offered</td>
                                    <td style="width: 114px; text-align: left">
                                        <asp:TextBox ID="txt_postoffer" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 28px; text-align: left">
                                        Branch Name</td>
                                    <td colspan="3" style="height: 28px; text-align: left; width: 264px;">
                                        <asp:TextBox ID="txt_branch" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                    <td style="width: 1px; height: 28px; text-align: left">
                                        Department</td>
                                    <td style="width: 114px; height: 28px; text-align: left">
                                        <asp:TextBox ID="txt_department" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="height: 28px; background-color: #ffcccc; text-align: center">
                                        <asp:Label ID="Label4" runat="server" BackColor="#FFC0C0" Font-Bold="True" Height="33px"
                                            Text="PROMOTION DETAILS" Width="754px"></asp:Label></td>
                                </tr>
                                
                                <tr>
                               
                                    <td style="width: 100px; height: 28px; text-align: left">
                                        Designation</td>
                                    <td colspan="4" style="height: 28px; text-align: left">
                                        <asp:DropDownList ID="cmb_pdesig" runat="server" Width="280px" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                    <td style="width: 114px; height: 28px; text-align: left">
                                        <cc1:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="cmb_pdesig">
                                        </cc1:ListSearchExtender>
                                    </td>
                                    
                                </tr>
                                <tr>
                               
                                  <td style="width: 100px; height: 28px; text-align: left">
                                        Pay Scale</td>
                                    <td style="height: 28px; text-align: left; width: 264px;" colspan="3">
                                        <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" PromptText="" TargetControlID="cmb_designation">
                                        </cc1:ListSearchExtender>
                                        <asp:DropDownList ID="cmb_designation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_designation_SelectedIndexChanged"
                                            Width="304px">
                                        </asp:DropDownList></td>
                                    <td style="width: 1px; height: 28px; text-align: left">
                                        Effective Date</td>
                                    <td style="width: 114px; height: 28px; text-align: left">
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                                            TargetControlID="txt_effective_date">
                                        </cc1:CalendarExtender>
                                        <asp:TextBox ID="txt_effective_date" runat="server" AutoPostBack="True" OnTextChanged="txt_effective_date_TextChanged"
                                            Width="280px"></asp:TextBox></td>
                                        
                                        
                                </tr>
                                <tr>
                              
                                  
                                    <td style="width: 100px; height: 28px; text-align: left">
                                        Basic Salary</td>
                                    <td style="width: 264px; height: 28px; text-align: left" colspan="3">
                                        <asp:DropDownList ID="cmb_pay_amnt" runat="server" AutoPostBack="True" Width="304px" OnSelectedIndexChanged="cmb_pay_amnt_SelectedIndexChanged" >
                                        </asp:DropDownList></td>
                                    <td style="width: 1px; height: 28px; text-align: left">
                                        Total Salary</td>
                                    <td style="width: 114px; height: 28px; text-align: left">
                                        <asp:TextBox ID="txt_totalsalary" runat="server" ReadOnly="True" Width="280px"></asp:TextBox></td>
                                 
                                </tr>
                            <tr id="spcl_tr" runat="server">
                            
                                    <td id="Td1" runat="server" style="width: 311px; height: 28px; text-align: left">
                                        Enter amount</td>
                                    <td id="Td2" runat="server" style="Width:300px; height: 28px; text-align: left">
                                    <asp:TextBox ID="txt_enter" runat="server" Width="296px" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        
                                        
                                      
                                </tr>
                                
                                   <tr id="Tr1" runat="server">
                            
                                    <%--<td id="Td3" runat="server" style="width: 311px; height: 28px; text-align: left">
                                        Remark</td>
                                    <td id="Td4" runat="server" style="Width:300px; height: 28px; text-align: left">
                                    <asp:TextBox ID="text_remark" runat="server" Width="296px" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        --%>
                                        
                                      
                                </tr>
                                <%--<tr id="Tr1" runat="server">
                            
                                    <td id="Td3" runat="server" style="width: 311px; height: 28px; text-align: left">
                                        Enter amount</td>
                                    <td id="Td4" runat="server" style="Width:292px; height: 28px; text-align: left">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="296px" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        
                                </tr>--%>
                                
                            </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 23px; width: 727px;">
                           
<asp:Label id="Lbl_MESSAGE" runat="server" Width="732px" Text="Label" ForeColor="Red"></asp:Label><BR /><%--<asp:Timer id="Timer1" runat="server" Interval="1000"></asp:Timer> --%>
</td>
                    </tr>
                    
                  
                
              
                <tr>
                        <td colspan="4" style="width: 727px; height: 9px">
                            <table border="1" width="762">
                                <tr>
                                    <td style="width: 94px">
                                    </td>
                                    <td align="center">
                <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="126px" /></td>
                                    <td align="center" style="width: 203px">
                                        <asp:Button ID="Cmd_Clear" runat="server" OnClick="Cmd_Clear_Click" Text="CLEAR"
                                            Width="126px" /></td>
                                    <td  align="center" style="width: 208px">
                                        <asp:Button ID="Cmd_Exit" runat="server" OnClick="Cmd_Exit_Click" Text="EXIT" Width="126px" /></td>
                                </tr>
<%--                             </ContentTemplate>
                             </asp:UpdatePanel>--%>
                                <div>
                                </div>
                                <center>
                                </center>
                            
                       
<script type="text/javascript">
 // script will use to exit the button
 
function exit()
{
   //alert("Closing");
   window.open('../home.aspx','_self');
   
}

</script>

    <br />
    <br />
    <br />
    <br />
</tr>
                                 
                            </table>
                            </div></center>
</asp:Content>

