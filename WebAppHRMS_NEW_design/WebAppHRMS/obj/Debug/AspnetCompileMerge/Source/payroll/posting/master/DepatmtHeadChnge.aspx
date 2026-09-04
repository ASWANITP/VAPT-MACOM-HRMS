<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="DepatmtHeadChnge.aspx.vb" Inherits="WebAppHRMS.DepatmtHeadChnge_919afd7b5596" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">


<script type="text/javascript">

function fill_res()
{
   var arg;
         arg=9+"$"+document.getElementById(cont[0]+"DropDownList1").value;
         sub_call_server(arg,2);
}
</script>



     <div style="text-align: center">
        <table border="1" style="width: 656px; height: 72px; margin: 0 auto;">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">
                        DepartmentHead Change </span></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Select Department</span>
                </td>
                
                
                <td style="width: 100px; height: 7px; text-align: left">
                   <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server" AutoPostBack="True" Width="304px" height="26px" >
                      </asp:DropDownList>
                    <asp:TextBox ID="dep_id" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 90px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Current Department Head</span>
                </td>
                <td style="width: 60px; height: 7px; text-align: left;">
                   <asp:TextBox ID="txt_previousdptmt" style="width: 300px; font-family: 'Courier New';" type="text"
                        runat="server" readonly="true" />   
                        
                        
                </td>
               
            </tr>
            
            
            <tr>
                <td style="width: 90px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Select New Department Head</span>
                </td>
                <td style="width: 100px; height: 7px; text-align: left">
                   <asp:DropDownList ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server" AutoPostBack="True" Width="304px" height="26px" >
                      </asp:DropDownList>
                </td>
                
                  
            </tr>
          
               
           
           
            <tr>
                <%--<td colspan="4" style="width: 100%; height: 7px; text-align: center">
                 <asp:Panel ID="mypanel" runat="server">
                    <span style="font-size: 11pt; font-family: Courier New">BROWSE : </span>
                    <asp:FileUpload ID="Upload" runat="server" />
                          <asp:Button ID="btnUpload" runat="server" Text="Upload" />

      <asp:Label foreColor="red" ID="lblError" runat="server" Visible="false" />
      </asp:Panel>
                    </td>--%>
               
               
            </tr>
            <tr>
                <td colspan="5" style="text-align: center; height: 50px;">
                    
                    
                 
                    
                    <asp:Button ID="btnconfirm" runat="server" Text="CONFIRM" Width="140px" height="25px" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                     
                    
                    <asp:Button ID="btnext" runat="server" Text="EXIT" Width="140px" height="25px" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    
                    
                </td>
            </tr>
        </table>
    </div>











</asp:Content>

