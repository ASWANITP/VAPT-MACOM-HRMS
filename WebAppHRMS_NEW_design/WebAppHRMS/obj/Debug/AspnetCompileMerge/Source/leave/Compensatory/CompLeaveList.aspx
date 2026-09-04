<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="CompLeaveList.aspx.vb" Inherits="WebAppHRMS.CompLeaveList_0ff0a11c8833" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
   
   
   <table style="width: 73%;">
       <tr>
           <td align="center" colspan="13">
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="14px"
                   ForeColor="Black" Text="COMPENSATORY OFF STATUS AND EXTENTION"></asp:Label><br />
           </td>
       </tr>
   <tr >
   <td style="width:130px;">
       &nbsp;
   </td>
      
       <td style="width:90px;">
           &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtEmpcode" ValidationGroup="grp1" runat="server" ValidationExpression ="^(\d{5,8})" ErrorMessage="Numbers Only" Font-Size="12px"></asp:RegularExpressionValidator><%--  onclick="cleargrv()"--%></td>
       <td style="width: 11px">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmpcode"
             ValidationGroup="grp1"  ErrorMessage="*"></asp:RequiredFieldValidator> </td>
              <td> <asp:Label ID="Label2" Text="Emp.Code:" runat="server" Font-Bold="True" Font-Size="12px"></asp:Label></td>
              <td>
             <asp:TextBox ID="TxtEmpcode" runat="server"></asp:TextBox></td>
           
           <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromdate"
             ValidationGroup="grp1"  ErrorMessage="*"></asp:RequiredFieldValidator> </td>
               <td> <asp:Label ID="Label3" Text="From:" runat="server" Font-Bold="True" Font-Size="12px"></asp:Label></td>
              <td>
           <asp:TextBox ID="txtFromdate" runat="server"></asp:TextBox>
             
           </td>
            <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTodate"
             ValidationGroup="grp1"  ErrorMessage="*"></asp:RequiredFieldValidator> </td>
               <td> <asp:Label ID="Label4" Text="To:" runat="server" Font-Bold="True" Font-Size="12px"></asp:Label><br />
               </td>
              <td>
            <asp:TextBox ID="txtTodate"  runat="server"></asp:TextBox>
             </td>
   <td><asp:Button ID="ButnExcel" runat="server"  ValidationGroup="grp1" Text="Search" Width="80px" />
           </td> <td>
           <asp:Button ID="ButnExit" runat="server" Text="Exit" Width="80px" PostBackUrl="~/home.aspx" /></td>
   </tr>
       <tr>
           <td style="width: 130px">
           </td>
           <td style="width: 90px">
           </td>
           <td style="width: 11px">
           </td>
           <td>
           </td>
           <td colspan="7">
       <asp:Label ID="LblEmpName" runat="server" Font-Bold="True"></asp:Label></td>
           <td>
           </td>
           <td>
           </td>
       </tr>
   </table>
   <cc1:CalendarExtender ID="CalendarExtender3" TargetControlID ="txtTodate" Format="dd-MMM-yyyy" runat="server">
               </cc1:CalendarExtender>  <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFromdate" Format="dd-MMM-yyyy" runat="server">
               </cc1:CalendarExtender>
   
    <table style="width: 100%;">
   <tr >
       <td style="width:100px;">
           </td>
   <td colspan="4" >
         
                 <div id="grvdivcnt" >
                   <asp:GridView ID="GrvCompLeave" runat="server" AutoGenerateColumns="False" Width="944px" >
                    <Columns>
                     <asp:TemplateField HeaderText="SL No " >
                            <ItemTemplate>
                                <asp:Label ID="lblsln" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="Comp.Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcompname" runat="server" Text='<%# Eval("comp_name") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Comp.Date">
                            <ItemTemplate>
                                <asp:Label ID="lblcompdate" runat="server" Text='<%# Convert.ToDateTime(Eval("comp_date")).ToString("dd-MMM-yyyy (ddd)") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Exp.Date">
                            <ItemTemplate>
                                <asp:Label ID="lblexpdate" runat="server" Text='<%# Convert.ToDateTime(Eval("exp_date")).ToString("dd-MMM-yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Validity" >
                            <ItemTemplate> <%--expired or not--%>
                                <asp:Label ID="lblvalidity" runat="server"  Text='<%#  IIf(Convert.ToInt32(Eval("c_e_sts")) = 1, "Expired", "Active") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="center"   Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Approval" >
                            <ItemTemplate> <%-- apprv_sts, compnstry lv reqst is aprvd or not  0 apl 1 app 2 rec 3 rej --%> 
                                <asp:Label ID="lblaprval" runat="server"  Text='<%# ProcessLeaveApproval(Convert.ToString(Eval("apprv_sts")))  %>'  ></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="center"   Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        
                         
                        
                          <asp:TemplateField HeaderText="Leave Date">
                            <ItemTemplate>
                           <%-- Visible = '<%#  IIf(Convert.ToInt32(Eval("comp_dtl_sts")) = 0,false ,true ) %>'--%>
                              <asp:Label ID="lblname" runat="server"  Text='<%# ProcessLeaveDate(Convert.ToString(Eval("leave_dt"))) %>' ></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        
                         
                         
                         <asp:TemplateField>  
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkExtend"  CommandArgument  ='<%# Convert.ToString(Eval("comp_id")) + "*" + Convert.ToString(Convert.ToDateTime(Eval("exp_date")).ToString("dd-MMM-yyyy")) + "*" + Convert.ToString(Convert.ToDateTime(Eval("comp_date")).ToString("dd-MMM-yyyy"))  %>' CommandName ='<%# Eval("emp_code")  %>' Visible = '<%# ExtendorNot(Convert.ToString(Eval("comp_dtl_sts")), Convert.ToString(Eval("apprv_sts"))) %>'  runat="server" OnCommand="LnkExtend_Command">Click to Extend</asp:LinkButton>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" BorderColor="Black" />
                    <EmptyDataTemplate>
                    
                        <asp:Label ID="LblEmpty" style="text-align :center ;" runat="server" Text="No Records Found" Width ="100%" Font-Bold="True"  Font-Names="Verdana" Font-Size="12px" ForeColor="Red"></asp:Label>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" BackColor="Transparent" BorderColor ="White"   />
                </asp:GridView>
                    <%-- <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server">
                     </cc1:ModalPopupExtender>--%>
             <%--    --%>   <cc1:ModalPopupExtender ID="ModalPopupExtender12" runat="server"
             TargetControlID="LinkButton1"
            PopupControlID="Panel1" 
            BackgroundCssClass="modalBackground" 
            OkControlID="CancelButton"
            OnOkScript="onOk()" 
            CancelControlID="CancelButton" 
            DropShadow="true"
            PopupDragHandleControlID="Panel3" />
            
           <%--   <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Admin/images/view.gif" />--%>
                     <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server" 
                                  style="BORDER-RIGHT: black 2px solid; PADDING-RIGHT: 20px; BORDER-TOP: black 2px solid; DISPLAY: none; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; BORDER-LEFT: black 2px solid; WIDTH: 550px; PADDING-TOP: 20px; BORDER-BOTTOM: black 2px solid; BACKGROUND-COLOR: white">
        <div style="text-align: center">
          
          <table>
              <tr>
                  <td>
                  </td>
                  <td colspan="3">
                      <asp:Label ID="Lblmessage" runat="server"></asp:Label></td>
              </tr>
          <tr>
          <td><asp:Label runat="Server" Text="Date:" ID="imageTitle"/></td>
          <td>
              <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID ="TxtExtDate" Format="dd-MMM-yyyy" runat="server">
              </cc1:CalendarExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup ="grp2" ControlToValidate ="TxtExtDate" runat="server"  ErrorMessage="*"></asp:RequiredFieldValidator>
              
              <asp:TextBox ID="TxtExtDate" runat="server"></asp:TextBox></td>
              <td>
                  <asp:Button ID="ButSubmit" ValidationGroup ="grp2" runat="server" Text="Submit" /></td><td><asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="submit_btn" /></td>
          </tr>
          </table>
            <asp:HiddenField ID="HdnEmpcode" runat="server" />
            <asp:HiddenField ID="hdnCmpid" runat="server" />
             <asp:HiddenField ID="hidCompdt" runat="server" />
           
             
            <%--<asp:Label runat="server" ID="imageDescription" ></asp:Label>--%>
           
           
          
        </div>
        </asp:Panel>
        
                     
                     
                     
                     &nbsp;</div>
                
                
            </td>
   </tr>
   </table>
</asp:Content>

