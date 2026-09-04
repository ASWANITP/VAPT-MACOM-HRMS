<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="hrm_CompulsoryLeave_Mac_Approve.aspx.vb" Inherits="WebAppHRMS.hrm_CompulsoryLeave_Mac_Approve" Title="Untitled Page"%>
<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript" for="window" event="onload">
        // <!CDATA[
        return window_onload()
        // ]]>
    </script>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('txt');
        
    function btnExit_onclick() {
            window.open("../../Home.aspx", "_self");
        }

      
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MMM/yyyy" TargetControlID="txtDate" runat="server"></cc1:CalendarExtender>
                <table border="1" style="width: 60%; border: unset;">
                    <tr>
                        <td colspan="2">Select Emp. Code</td>
                        <td colspan="2" style="text-align: left">
                       <asp:DropDownList ID="ddlEcode" runat="server" AutoPostBack="true" MaxLength="6" Width="70%" OnSelectedIndexChanged="ddlEcode_SelectedIndexChanged">
                    </asp:DropDownList>
                    </tr>
                    <tr>
                        <td style="width: 5%; text-align: left;">Name</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtEname" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">Branch</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtBranch" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 5%; text-align: left;">Post</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtPost" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 7%; text-align: left;">Designation</td>
                        <td style="width: 15%">
                            <asp:TextBox ID="txtDes" runat="server" Width="98%" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"> Date</td>
                        <td colspan="2" style="text-align: left">
                            <asp:TextBox ID="txtDate" runat="server" readonly="true" Width="71%" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
       <td colspan="2"> Catagory</td>
       <td colspan="2" style="text-align: left">
           <asp:TextBox ID="cmb_type" runat="server" ReadOnly="True" Width="214px"></asp:TextBox></td>
            </tr>
                    <tr id="row4">
                        <td colspan="2" style="text-align: right">
                            <input id="CheckBox1" runat="server" name="t" type="radio" enabled="false" onclick="return show()" />
                            <span id="spnforgot" runat="server">FORGOT or LATE</span></td>
                        <td colspan="2" style="text-align: left">
                            <input id="CheckBox2" runat="server" name="t" type="radio" enabled="false" onclick="return showother()" />
                            <span id="spntech" runat="server">TECHNICAL ISSUE</span></td>
                    </tr>


                    <%-- <asp:CheckBox ID="CheckBox1" runat="server" Text="FORGOT"  onclick= "return show()"/></td>--%>
                    <%-- <td colspan="2" style="text-align: left">
                            <asp:CheckBox ID="CheckBox2" runat="server" Text="OTHER"  onclick= "return showother()"/></td>--%>

                    <tr id="row1">
                        <td colspan="2" style="text-align: right">
                            <asp:CheckBox ID="chkMor" runat="server" Enabled="false" Text="MORNING" /></td>
                        <td colspan="2" style="text-align: left">
                            <asp:CheckBox ID="chkEve" runat="server" Enabled="false" Text="EVENING" /></td>
                    </tr>
                    <tr id="row2">
                        <td colspan="2" style="text-align: right">
                            <input id="chk_lop1" runat="server" enabled="false" name="t" type="radio" />
                             <span id="Span1" runat="server">1 LOP</span></td>
                        <td colspan="2" style="text-align: left">
                            <input id="chk_lop2" runat="server" enabled="false" name="t" type="radio" />
                             <span id="Span2" runat="server">2 LOP</span></td>
                    </tr>
                    
                    <tr>
                     <td colspan="2" id="tdRemarks" runat="server">Remarks</td>
                        <td colspan="2" style="text-align: left">
                         <asp:TextBox ID="txt_remarks" runat="server" ReadOnly="True" Width="214px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnConfirm" runat="server" Width="88px" OnClientClick="return OnConClick()" Text="APPROVE" />
                            <asp:Button ID="btnReject" runat="server" Width="88px" OnClientClick="return OnConClick()" Text="REJECT" />
                            <asp:Button ID="btnExit" runat="server" Width="88px" OnClientClick="return btnExit_onclick()" Text="EXIT" />
                            <%--<input id="btnExit" style="width: 88px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" />--%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>



