<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="TA_recom.aspx.vb"
    Inherits="TA_TA_recom_6aadb41f5342" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script type="text/javascript">
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
        function isNumberKey(evt, element) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 8))
                return false;
        }
       function caluculate_fare() 
{ 
     var k = document.getElementById("<%=txt_km.ClientID%>").value;
     var rt = document.getElementById("<%=txt_rate.ClientID%>").value;
     var fr;
     fr = k * rt;
     document.getElementById("<%=txt_fare.ClientID%>").value = fr;
}
 function caluculate_fr() 
{ 
     var k = document.getElementById("<%=txt_km.ClientID%>").value;
     var rt = document.getElementById("<%=txt_rate.ClientID%>").value;
     var fr;
     fr = k * rt;
     document.getElementById("<%=txt_fare.ClientID%>").value = fr;
}
function caluculate_ta() 
{ 
     var rr = parseInt(document.getElementById("<%=txt_fare.ClientID%>").value);
     var bat = parseInt(document.getElementById("<%=txt_bata.ClientID%>").value);
     var ta;
     ta = parseInt(rr + bat);
     document.getElementById("<%=txt_totta.ClientID%>").value = parseInt(ta);
}
function calculate_totta()
{
debugger;
 var rr = parseInt(document.getElementById("<%=txt_fare.ClientID%>").value);
     var bat = parseInt(document.getElementById("<%=txt_bata.ClientID%>").value);
     var ta;
     ta = parseInt(rr + bat);
     document.getElementById("<%=txt_totta.ClientID%>").value = parseInt(ta);
}
function fill_dtl()
{
debugger;
    var confirmstr = "";
       var slno = document.getElementById("<%=txt_slno.ClientID%>").value;
            var emp = document.getElementById("<%=drp_empl.ClientID%>").value;
            var dat = document.getElementById("<%=txt_date.ClientID%>").value;
             var dis = document.getElementById("<%=txt_nmdis.ClientID%>").value;
             var frm = document.getElementById("<%=txt_frmpl.ClientID%>").value;
              var top = document.getElementById("<%=txt_topl.ClientID%>").value;
            var fm = document.getElementById("<%=txt_firm.ClientID%>").value;
             var k = document.getElementById("<%=txt_km.ClientID%>").value;
            var rt = document.getElementById("<%=txt_rate.ClientID%>").value;
              var fr = document.getElementById("<%=txt_fare.ClientID%>").value;
              var bt = document.getElementById("<%=txt_bata.ClientID%>").value;
             var tot = document.getElementById("<%=txt_totta.ClientID%>").value;
             var rmrk = document.getElementById("<%=txt_remark.ClientID%>").value;
             debugger;
          if(confirmstr == ""){
         
             confirmstr = emp +"~"+ slno +"~"+ k +"~"+ rt +"~"+ fr +"~"+ bt +"~"+ tot +"~"+ rmrk
          }
          else{
              confirmstr = confirmstr + "~" + emp +"~"+ slno +"~"+ k +"~"+ rt +"~"+ fr +"~"+ bt +"~"+ tot +"~"+ rmrk
              }
       var data =   call_server(confirmstr)
      
  }
  function call_receiver(arg1)
{
document.getElementById("<%=bt1.ClientID %>").click()
}

    </script>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div class="col-md-2" align="center">
        <label class="col-md-3 cntr-text" runat="server" id="lbl_cmpnm">
            Select Employee</label>
        <div class="col-md-4">
            <asp:DropDownList ID="drp_empl" runat="server" Height="30px" Width="200px" OnSelectedIndexChanged="drp_empl_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <div runat="server" align="center" id="Div2">
    
        <table align="center">
       
            <asp:GridView ID="Grid_view1" runat="server" AutoGenerateColumns="False" DataKeyNames="ta_id"
                OnRowCommand="GridView1_RowCommand" align="center">
                <Columns>
                    <asp:BoundField DataField="ta_id" HeaderText="TA id" />
                    <asp:BoundField DataField="ta_date" HeaderText="TA date" />
                    <asp:BoundField DataField="district" HeaderText="District" />
                    <asp:BoundField DataField="frm_plc" HeaderText="From place" />
                    <asp:BoundField DataField="to_plc" HeaderText="To place" />
                    <asp:BoundField DataField="firm" HeaderText="Firm" />
                    <asp:BoundField DataField="km" HeaderText="Km" />
                    <asp:BoundField DataField="rate" HeaderText="Rate" />
                    <asp:BoundField DataField="fare" HeaderText="Fare" />
                    <asp:BoundField DataField="bata" HeaderText="Bata" />
                    <asp:BoundField DataField="req_amnt" HeaderText="Request amnt" />
                    <asp:BoundField DataField="remark" HeaderText="Remark"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Edit" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
            </asp:GridView>
             
        </table>
      
    </div>
      <div runat="server" align="center" id="Div1">
    
        <table align="center">
       
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ta_id"
                 align="center" OnRowCommand="GridView2_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ta_id" HeaderText="TA id" />
                    <asp:BoundField DataField="ta_date" HeaderText="TA date" />
                    <asp:BoundField DataField="district" HeaderText="District" />
                    <asp:BoundField DataField="frm_plc" HeaderText="From place" />
                    <asp:BoundField DataField="to_plc" HeaderText="To place" />
                    <asp:BoundField DataField="firm" HeaderText="Firm" />
                    <asp:BoundField DataField="km" HeaderText="Km" />
                    <asp:BoundField DataField="rate" HeaderText="Rate" />
                    <asp:BoundField DataField="fare" HeaderText="Fare" />
                    <asp:BoundField DataField="bata" HeaderText="Bata" />
                    <asp:BoundField DataField="rec_amnt" HeaderText="Recommend amnt" />
                    <asp:BoundField DataField="remark" HeaderText="Remark"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" Text="Edit" runat="server" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   </Columns>
            </asp:GridView>
             
        </table>
      
    </div>
    <br />
    <br />
    <br />
    <br />
    <div runat="server" align="center" id="Div3">
        <input id="hid_details" runat="server" style="width: 16px" type="hidden" />
        <table border="1" style="width: 70%; height: 50%">
            <tr>
                <th colspan="1" style="text-align: center">
                    SL_no</th>
                <th colspan="1" style="text-align: center">
                    TA Date</th>
                <th colspan="1" style="text-align: center">
                    District</th>
                <th colspan="1" style="text-align: center">
                    From Place</th>
                <th colspan="1" style="text-align: center">
                    To Place</th>
                <th colspan="1" style="text-align: center">
                    Firm</th>
                <th colspan="1" style="text-align: center">
                    KM</th>
                <th colspan="1" style="text-align: center">
                    Rate</th>
                <th colspan="1" style="text-align: center">
                    Fare</th>
                <th colspan="1" style="text-align: center">
                    Bata</th>
                <th colspan="1" style="text-align: center">
                    TA Amount</th>
                    <th colspan="1" style="text-align: center">
                    Remark</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txt_slno" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_date" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_nmdis" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_frmpl" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_topl" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_firm" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_km" runat="server" Width="100%" ReadOnly="false" MaxLength="4" AutoPostBack="false"
                        onchange="return caluculate_fr()" onkeypress="return isNumberKey(event);"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_rate" runat="server" Width="100%" ReadOnly="false" MaxLength="4" AutoPostBack="false"
                        onchange="return caluculate_fare()" onkeypress="return isNumberKey(event);"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_fare" runat="server" Width="100%" ReadOnly="true" AutoPostBack="false"
                          onfocus="return calculate_totta()"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_bata" runat="server" Width="100%" ReadOnly="false" MaxLength="4" AutoPostBack="false"
                        onchange="return caluculate_ta()" onkeypress="return isNumberKey(event);"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt_totta" runat="server" Width="100%" AutoPostBack="false" ReadOnly="true"></asp:TextBox></td>
                      <td>
                    <asp:TextBox ID="txt_remark" runat="server" Width="100%" AutoPostBack="false"></asp:TextBox></td>
                <td colspan="5" style="text-align: center">
                    <asp:Button runat="server" ID="Update" Text="update" OnClientClick="return fill_dtl()" AutoPostBack="true" />
                        
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <input type="button" runat="server" id="bt1" style="display:none;" />
    <div runat="server" align="center" id="buttons" visible="false">
        <asp:Button ID="Button1" runat="server" Text="RECOMMEND" />
        <asp:Button ID="btn_cnfrm" runat="server" Text="REJECT" Width="117px" />
        <asp:Button ID="btn_ext" runat="server" Text="EXIT" Width="107px" />
    </div>
  <br /><br /><br /><br />
</asp:Content>
