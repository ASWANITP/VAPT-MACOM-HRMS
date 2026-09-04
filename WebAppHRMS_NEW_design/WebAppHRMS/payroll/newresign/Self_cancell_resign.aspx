<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Self_cancell_resign.aspx.vb" Inherits="WebAppHRMS.New_folder__3_Self_cancell_resign_6e4849046935" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button2_onclick() {
            window.open('../../home.aspx', '_self');
        }
        //function van()
        //{
        //alert ("Please select date from calendar! ")
        //  return false;
        //}
        // ]]>
    </script>

    &nbsp;<div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>CANCEL RESIGNATION<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>&nbsp;Employee Name</strong></td>


                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="txt_name" runat="server" Width="582px" ReadOnly="true">
                                            </asp:TextBox></td>
                                    </tr>



                                    <tr>
                                        <td style="text-align: left" colspan="2"><strong>Employee&nbsp;Code :</strong>
                                            <asp:Label ID="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></td>
                                        <%-- <TD style="WIDTH: 392px; TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Name :</STRONG>&nbsp; <asp:Label id="lbl_name" runat="server" Width="226px" Text="No Employee" ForeColor="Navy"></asp:Label>
                    </TD>--%>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Resigning&nbsp;Date</strong></td>
                                        <td style="width: 106px">
                                            <asp:TextBox ID="Txt_rsdt" runat="server" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 392px" colspan="2">&nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Reason&nbsp;for&nbsp;Resigning</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rea" runat="server" Width="571px" ForeColor="Navy" Height="22px" ReadOnly="True" TextMode="singleLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; height: 23px; text-align: left"><strong>Relieving&nbsp;Date</strong></td>
                                        <td style="width: 106px; height: 23px">
                                            <asp:TextBox ID="Txt_rdt" runat="server" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 392px; height: 23px" colspan="2">
                                            <%--<cc1:CalendarExtender TargetControlID="txt_rdt" runat="server" ID="datetime"></cc1:CalendarExtender>--%>
    &nbsp; </td>
                                    </tr>


                                    <td>
                                        <tr>
                                            <td style="width: 2773px; text-align: left; height: 26px;"><strong>Remarks</strong></td>
                                            <td colspan="3">
                                                <asp:TextBox ID="Text_remar" Width="577px" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </td>

                                </tbody>


                            </table>
                            <%--<cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmb_emp">
                    </cc1:ListSearchExtender>--%>&nbsp; &nbsp;
                    
                    
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 160px">&nbsp;
                </td>
                <td style="width: 79px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CANCEL" /></td>



                <td style="width: 122px">
                    <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                <td style="width: 128px">&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


