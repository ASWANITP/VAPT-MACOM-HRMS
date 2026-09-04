<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="comp_cancel.aspx.vb" Inherits="WebAppHRMS.RAJEESH_comp_cancel_5f3a74087842" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table style="width: 892px; position: static; height: 89px" border="1">
                    <tbody>
                        <tr>
                            <td style="text-align: center" colspan="2"><strong><span style="text-decoration: underline"><span style="font-size: 14pt">C</span>OMPENSATORY&nbsp; CANCELATION</span></strong></td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="2">
                                <asp:Label Style="position: static" ID="Label2" runat="server" Width="617px" ForeColor="Red" __designer:wfdid="w3"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="2">
                                <asp:Label Style="position: static" ID="Label1" runat="server" Width="374px" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 387px; height: 23px; text-align: center">EmpCode</td>
                            <td style="width: 100px; height: 23px; text-align: left">
                                <asp:TextBox Style="position: static" ID="txt_empcode" runat="server" Width="144px" OnTextChanged="txt_empcode_TextChanged" AutoPostBack="True" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 387px; height: 1px; text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Compensatory Type</td>
                            <td style="width: 100px; height: 1px; text-align: left">
                                <asp:DropDownList Style="position: static" ID="cmb_type" runat="server" Width="219px" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 387px; height: 21px; text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Compensatory Date</td>
                            <td style="width: 100px; height: 21px; text-align: left">
                                <asp:TextBox Style="position: static" ID="txt_dt" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 387px; height: 21px; text-align: center">Leave Date</td>
                            <td style="width: 100px; height: 21px; text-align: left">
                                <asp:TextBox Style="position: static" ID="txt_ldt" runat="server" __designer:wfdid="w1" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 27px; text-align: center" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button Style="position: static" ID="Button1" OnClick="Button1_Click" runat="server" Width="135px" Text="CANCEL" __designer:wfdid="w5"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton Style="position: static" ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" __designer:wfdid="w6" PostBackUrl="~/home.aspx">Home</asp:LinkButton></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
</asp:Content>

