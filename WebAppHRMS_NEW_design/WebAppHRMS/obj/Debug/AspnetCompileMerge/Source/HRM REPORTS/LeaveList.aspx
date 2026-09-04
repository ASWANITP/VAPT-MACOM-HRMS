<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="LeaveList.aspx.vb" Inherits="WebAppHRMS.LeaveList_c56207c69507" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">
    <table style="width: 100%;">
       <tr>
           <td align="center" colspan="6" style="height: 18px">
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="14px"
                   ForeColor="Black" Text="LEAVE STATUS REPORT"></asp:Label></td>
       </tr>
       <tr>
           <td align="center" colspan="6" style="height: 18px">
           </td>
       </tr>
       <tr>
           <td align="center" colspan="6" style="height: 18px">
               <asp:Label ID="emcde" runat="server" Text="Employee Code" Width="136px"></asp:Label>
               <asp:TextBox ID="txt_empcde" runat="server" Width="216px"></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_empcde" runat="server" ValidationExpression ="^(\d{4,6})" ErrorMessage="Invalid ID" ></asp:RegularExpressionValidator></td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_empcde"
              ErrorMessage="*"></asp:RequiredFieldValidator></tr>
   <tr >
       <td style="width:100px;">
           </td>
   <td style="width:130px;"><asp:RadioButton ID="RdoRecommendation" OnCheckedChanged="RdoRecommendation_CheckedChanged"  AutoPostBack ="true" Checked ="true" GroupName ="grp1" Text="Recommendation " runat="server" /></td>
       <td style="width:90px;">
       <asp:RadioButton ID="RdoSanction"  GroupName ="grp1" OnCheckedChanged="RdoRecommendation_CheckedChanged" AutoPostBack ="true"  Text="Sanction"  runat="server" />
      <%--  onclick="cleargrv()"--%>
       </td>
       <td style="width:100px;">
     <%--  <asp:Button ID="ButSubmit" runat="server" Text="Submit" />--%>
       
       </td>
   <td><asp:Button ID="ButnExcel" runat="server" Text="Export to Excel" Enabled="False" /></td>
       <td>
           <asp:Button ID="ButnExit" runat="server" Text="Exit" Width="80px" PostBackUrl="~/home.aspx" /></td>
   </tr>
   </table>
   
    <script language="javascript" type="text/javascript">
        function cleargrv() {

            document.getElementById('grvdivcnt').style.visibility = 'hidden';
            document.getElementById('<%=ButnExcel.ClientID  %>').disabled = true;
        }
    </script>
    <table style="width: 100%;">
   <tr >
       <td style="width:100px;">
           </td>
   <td colspan="4" >
         
                 <div id="grvdivcnt" >
                <asp:GridView ID="GrvLeave" runat="server" AutoGenerateColumns="False" Width="944px" >
                    <Columns>
                     <asp:TemplateField HeaderText="SL No " >
                            <ItemTemplate>
                                <asp:Label ID="lblsln" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblcode" runat="server" Text='<%# Eval("emp_code") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="left"  Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("emp_name") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="From Date">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%# Convert.ToDateTime(Eval("leave_frdate")).ToString("dd-MMM-yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="To Date">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server"  Text='<% # IIf(Convert.ToDateTime(Eval("leave_frdate")) <> Convert.ToDateTime(Eval("leave_todate")), Convert.ToDateTime(Eval("leave_todate")).ToString("dd-MMM-yyyy"), "") %>'  ></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Days">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<% # IIf(Convert.ToDateTime(Eval("leave_frdate")) = Convert.ToDateTime(Eval("leave_todate")), "1", Convert.ToString(DateDiff(DateInterval.Day, Convert.ToDateTime(Eval("leave_frdate")), Convert.ToDateTime(Eval("leave_todate")), Microsoft.VisualBasic.FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))) %>'></asp:Label>
                            </ItemTemplate>
                              <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("leave_reason") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Leave"> 
                           
                        
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#  IIf(Convert.ToInt32(Eval("leave_id")) = 1, "CL", IIf(Convert.ToInt32(Eval("leave_id")) = 2,"SL",IIf(Convert.ToInt32(Eval("leave_id")) = 3,"EL","LOP") )   ) %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status">  
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#  IIf(Convert.ToInt32(Eval("status_id")) = 0, "APPLIED",IIf(Convert.ToInt32(Eval("status_id")) = 1, "SANCTIONED",IIf(Convert.ToInt32(Eval("status_id")) = 2, "REJECTED",IIf(Convert.ToInt32(Eval("status_id")) = 3, "CANCELLED","RECOMMENDED"))))  %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small" />
                            <HeaderStyle Font-Size ="Small" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" BorderColor="Black" />
                    <EmptyDataTemplate>
                    
                        <asp:Label ID="LblEmpty" style="text-align :center ;" runat="server" Text="No Records Found" Width ="100%" Font-Bold="True"  Font-Names="Verdana" Font-Size="12px" ForeColor="Red"></asp:Label>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" BackColor="transparent" BorderColor ="White"   />
                </asp:GridView></div>
                
                
            </td>
   </tr>
   </table>
</asp:Content>
