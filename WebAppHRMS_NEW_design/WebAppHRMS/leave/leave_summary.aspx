<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_summary.aspx.vb" Inherits="WebAppHRMS.Auction_Listed_pledges_448d588b8861" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">



    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.3/jquery.js" type="text/javascript"></script>


    <script type="text/javascript"> 
        var cont = cont_name.split("txt")
        $(function () {//debugger;  
            $("input[type=text]").keypress(function () {
                alert("Choose Date From Calender");
                return false;
            });
        });

        $(function () {//debugger;  
            $("input[type=text]").keydown(function () {
                alert("Choose Date From Calender");
                return false;
            });
        });


        function checkdatet(txt) { //debugger;
            call_server("8$" + document.getElementById(cont[0] + 'txt_frDt').value + "$" + document.getElementById(cont[0] + 'txt_toDt').value, 8);
        }

        function loads() { //debugger;
            if (document.getElementById(cont[0] + 'hids').value == "1") {
                document.getElementById('myid').style.display = "inline";
                document.getElementById(cont[0] + 'GridView2').style.display = "none";
                //call_server("5$"+ document.getElementById(cont[0]+'txt_frDt').value+"$"+document.getElementById(cont[0]+'txt_toDt').value,8); 
            }
            else {
                alert('Select Both From Date & To Date!!')
                return false;
            }
        }

        function call_receiver(arg, context) {
            debugger;
            document.getElementById('myid').style.display = "none";
            //var data=arg.split("$");
            if (arg == "") {
                document.getElementById(cont[0] + 'hids').value = "1";
                return true;
            }
            else {
                alert(arg);
                document.getElementById(cont[0] + 'txt_toDt').value = "";
                document.getElementById(cont[0] + 'hids').value = "0";
                return false;
            }
        }
        function myid_onclick() {

        }

    </script>

    <asp:Panel Style="left: 0px; position: relative; top: 0px" ID="Panel1" BorderColor="black" runat="server" Width="1221px">
        <table border="0" style="width: 1339px; border-color: Black; font-family: Courier New; border-bottom: 0px;">
            <tr>
                <td colspan="29" style="height: 90px; text-align: center; width: 107%; background-color: #ffd700;">
                    <strong><span style="font-size: 14pt; color: Red; font-family: Times New Roman;"><u>MANAPPURAM COMPTECH & CONSULTANTS LTD.</u></span></strong><br>
                    <strong><span style="font-size: 14pt; color: blue; font-family: Times New Roman;">LEAVE REPORT FOR A PERIOD</span></strong></td>
            </tr>
            <tr>
                <td style="text-align: left; background-color: Silver;">
                    <strong>From Date :</strong>
                    <asp:TextBox ID="txt_frDt" runat="server" MaxLength="35" Width="220px" Font-Names="Courier New" Height="16px"></asp:TextBox>
                </td>

                <td style="text-align: left; background-color: Silver; width: 479px;">
                    <strong>To Date :</strong>
                    <asp:TextBox ID="txt_toDt" onchange="checkdatet(this)" runat="server" MaxLength="11" Width="150px" Font-Names="Courier New" Height="16px"></asp:TextBox>

                    <asp:Button ID="Button1" runat="server" OnClientClick="loads()" Text="Proceed" />
                    <asp:Button ID="Button3" runat="server" Text="Export" Width="57px" Visible="False" />
                    <asp:Button ID="Button2" runat="server" Text="Exit" />
                </td>



        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt="IMG" id="myid" style="display: none; width: 1153px; height: 549px;" src="../leave/loadround.gif" onclick="return myid_onclick()" /><br>
        <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="silver" AutoGenerateColumns="False" AllowPaging="True"
            OnPageIndexChanging="OnPageIndexChanging" PageSize="15" Width="1342px">
            <Columns>
                <asp:BoundField DataField="EMP_CODE" HeaderText="EMP CODE">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="NAME" HeaderText="NAME">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="FROM_DATE" HeaderText="FROM">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TO_DATE" HeaderText="TO">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="LEAVE_TYPE" HeaderText="TYPE">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="TOTAL_DAYS" HeaderText="DAYS">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="REASON" HeaderText="REASON">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="dep_name" HeaderText="DEPARTMENT">
                    <ItemStyle Width="200px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="Silver" />
        </asp:GridView>
    </asp:Panel>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
        TargetControlID="txt_frDt"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
        TargetControlID="txt_toDt"></cc1:CalendarExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:GridView ID="GridView3" runat="server">
    </asp:GridView>
    <asp:HiddenField Value="0" ID="hids" runat="server" />

</asp:Content>
