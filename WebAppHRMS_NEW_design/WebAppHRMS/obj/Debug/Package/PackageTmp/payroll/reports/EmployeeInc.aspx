<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="EmployeeInc.aspx.vb" Inherits="WebAppHRMS.EmployeeInc_e79c7c569031" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
   
   <script type ="text/javascript" >

       function waitingwindow() {
           document.getElementById('<%= Me.ButtonExccel.ClientID %>').disabled = true;
           document.getElementById('datadiv').style.visibility = 'hidden';
           document.getElementById('waitdiv').style.visibility = 'visible';
           document.getElementById('<%= Me.LabelMonth.ClientID %>').innerHTML = '';

       }
       function Button1_onclick() {
           window.open("../../home.aspx", '_self');
       }
   </script>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <table style ="width :100%;">
       
            <caption style="padding:20px;font-size:20px;"><strong> INCREMENT DATA </strong></caption>
        
        <tr>
            <td align="left" style="text-align:center;" >
             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15px"  Text="SELECT DATE:"></asp:Label>
           <%-- <td align="right" style="width: 100px;text-align:center;">
                </td>
            <td align="right" style="width :100px;text-align:center;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13px"  Text="Select Date:"></asp:Label></td>--%>
         <asp:TextBox ID="txt_date" runat="server" Width="200px" ></asp:TextBox>
           
  <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy" targetcontrolid="txt_date">                
   </cc1:calendarextender>
             <asp:Button ID="btn_Report" runat="server" Text="Report" OnClick="btn_Report_Click"/>
            </td>
                </tr>
            <tr>
            <td align="left" style="text-align:center;padding:5px;"  >
<%--               <asp:DropDownList ID="DDLMonths" runat="server" onchange="waitingwindow()" AutoPostBack="True" OnSelectedIndexChanged ="DDLMonths_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">January</asp:ListItem>
                     <asp:ListItem  Value="2">February</asp:ListItem>
                      <asp:ListItem  Value="3">March</asp:ListItem>
                       <asp:ListItem  Value="4">April</asp:ListItem>
                        <asp:ListItem  Value="5">May</asp:ListItem>
                         <asp:ListItem  Value="6">June</asp:ListItem>
                          <asp:ListItem  Value="7">July</asp:ListItem>
                           <asp:ListItem  Value="8">August</asp:ListItem>
                            <asp:ListItem  Value="9">September</asp:ListItem>
                             <asp:ListItem  Value="10">October</asp:ListItem>
                              <asp:ListItem  Value="11">November</asp:ListItem>
                               <asp:ListItem  Value="12">December</asp:ListItem>
                </asp:DropDownList>--%>
                
                
               
                 <input id="Button1" style="width: 150px" type="button" value="Exit" onclick="return Button1_onclick()" />
                 <asp:Button ID="ButtonExccel" OnClick ="ButtonExccel_Click" runat="server" Width="150px" Text="Export To Excel" /></td>
        </tr>
    </table>
    
   
    
     
     
   
    
     <div id="waitdiv" style ="visibility :hidden ;text-align :center;"> 
      <asp:Label id="Lblwait" runat="server" Text="Processing Please wait..." Font-Names="Verdana" Font-Bold="True" Font-Size="12px"></asp:Label>
     </div>
      <div id="Div1" style =" ;text-align :center;"> 
      <asp:Label id="LabelMonth" runat="server" Text="" Font-Names="Verdana" Font-Bold="True" Font-Size="12px"></asp:Label>
     </div><br/>
     
    
   <div id="datadiv" style ="width :100%;text-align :center ;">  
    <asp:GridView id="GrvEmp" runat="server" AutoGenerateColumns="False" Width="1154px">
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
                                <asp:Label ID="lblEmpcode" runat="server" Text='<%# Eval("e_code") %>'></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="center"   Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="left"  Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Basic Pay">
                            <ItemTemplate>
                                <asp:Label ID="lblBPay" runat="server" Text='<%# Eval("basic_pay") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Inc. Date">
                            <ItemTemplate>
                                <asp:Label ID="lblincDate" runat="server" Text='<%# Convert.ToDateTime(Eval("last_increment")).ToString("dd-MMM-yyyy") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Join Date">
                            <ItemTemplate>
                                <asp:Label ID="lbljDate" runat="server" Text='<%# Convert.ToDateTime(Eval("join_date")).ToString("dd-MMM-yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server"  Text='<% # Eval("Designation") %>'  ></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Post">
                            <ItemTemplate>
                                <asp:Label ID="lblPost" runat="server" Text='<% # Eval("post_name") %>'></asp:Label>
                            </ItemTemplate>
                              <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate>
                                <asp:Label ID="lblQualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign ="Center" Font-Size ="Small"  />
                            <HeaderStyle Font-Size ="Small"  />
                        </asp:TemplateField>
                        
                    </Columns>
                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" BorderColor="Black"  />
                  <%--  <EmptyDataTemplate>
                    
                        <asp:Label ID="LblEmpty" style="text-align :center ;" runat="server" Text="No Records Found" Width ="100%" Font-Bold="True"  Font-Names="Verdana" Font-Size="12px" ForeColor="Red"></asp:Label>
                    </EmptyDataTemplate>--%>
                    <RowStyle HorizontalAlign="Center" BackColor="Transparent" BorderColor ="White"    />
                </asp:GridView></div> 
                              
</asp:Content>

