<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="resignation_enter.aspx.vb" Inherits="WebAppHRMS.new_resignation_enter_a858a39d2739" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
    // <!CDATA[

    function Button2_onclick()
    {
        window.open('../../home.aspx', '_self');
    }


    var cs = cont_name.split("Txt");
    //function isNumberKey(ids) 
    //{ 
    ////debugger;
    //    var charcode = (event.which) ? event.which : event.keyCode 
    //    if(ids==1) 
    //    {
    //        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32)) 
    //        {
    //            return true; 
    //        } 
    //        else 
    //            return false; 
    //    }
    //    if(ids==2) 
    //    {
    //        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64 ) || (charcode==32) || (charcode > 46 && charcode <58)) 
    //        {
    //            return true; 
    //        } 
    //        else 
    //            return false; 
    //    }
    //    if(ids==3) 
    //    {
    //        if (charcode > 31 && (charcode < 48 || charcode > 57 )) 
    //        {
    //            return false; 
    //        } 
    //        else 
    //            return true; 
    //    }

    //}

    function change(a) {
        var str = document.getElementById(cs[0] + a).value;
        if (str == ' ') {
            document.getElementById(cs[0] + a).value = "";
            document.getElementById(cs[0] + a).focus;
            return false;
        }
        if (isNaN(str)) {
            document.getElementById(cs[0] + a).value = "";
            document.getElementById(cs[0] + a).focus;
            return false;
        }

    }

    function van() {
        alert("Please select date from calendar! ")
        return false;
    }
    // ]]>
</script>

    <div style="text-align: center"><table border="1" style="width:24px"><tr align="left"><td align ="center"><span style="color: #ff0033" > RESIGNATION APPLICATION</span><asp:ScriptManager id="ScriptManager1"
                        runat="server"></asp:ScriptManager><cc1:CalendarExtender ID="CalendarExtender1"
                            runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_rsdt">
                        </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_rsdt1">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="Txt_reldt">
                    </cc1:CalendarExtender></td></tr>
       <tr align="left"><td align="left"><asp:Panel ID="Panel1" runat="server" Height="300px" Width="125px">
            <table border="1" style="width: 256px; height:300px">
            
                <tr align="left">
                    <td align="left" style="width: 24px;  text-align: left">
                        <span style="color: #3300cc">Employee Code</span></td>
                    <td align="left" style="width: 11px; text-align: left">
                        <asp:Label ID="lbl_code" runat="server" ForeColor="#C00000" Text="Label" Width="136px"></asp:Label></td>
                    <td align="left" style="width: 142px;">
                        <span style="color: #3300cc">Employee Name</span></td>
                    <td align="left" style="width: 27px;">
                        <asp:Label ID="lbl_name" runat="server" ForeColor="#C00000" Text="Label" Width="250px"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left"  style="width: 24px;text-align: left; height: 5px;">
                        <span style="color: #3300cc">Resignation Notice Submitted Date</span></td>
                    <td align="left"  style="width: 11px;text-align: left; height: 5px;">
                        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox><br />
                    </td>
                    <td align="left"  style="width: 142px; height: 5px;">
                        <span style="color: #0000cc">When is your last day of work?</span></td>
                    <td align="left" style="width: 27px; height: 5px;">
                        <asp:TextBox ID="Txt_rsdt" runat="server" onkeypress="return van()"></asp:TextBox>&nbsp;</td>
                </tr>
                <tr align="left">
                    <td align="left" style="width: 24px;text-align: left">
                        <span style="color: #3300cc">Resignation Reason</span></td>
                    <td align="left" colspan="3" style="text-align: left">
                        <asp:DropDownList ID="cmb_reason" runat="server" AutoPostBack="true" Width="430px">
                        </asp:DropDownList></td>
                </tr>
                <tr align="left">
                    <td align="left" colspan="4" style="text-align: left;">
                        <asp:Panel ID="hs1" runat="server" Width="720px" Height="100px">
                            <div style="text-align: center">
                                <table style="width: 730px">
                                    <tr align="left">
                                        <td align="left" style="width: 171px">
                                            <span style="color: #0033cc">College name</span></td>
                                        <td align="left" colspan="3" style="text-align: left">
                                            <asp:TextBox ID="Txt_coll" runat="server" Width="541px"></asp:TextBox></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="left" style="width: 171px">
                                            <span style="color: #0033cc">Course</span></td>
                                        <td align="left" style="width: 51px; text-align: left">
                                            <asp:TextBox ID="Txt_cou" runat="server" Width="327px"></asp:TextBox></td>
                                        <td align="left" style="width: 77px">
                                            <span style="color: #3333cc">Duration</span></td>
                                        <td align="left" style="width: 250px; text-align: left">
                                            <asp:TextBox ID="Txt_du" runat="server" onkeyup="return change('Txt_du')" Width="57px"></asp:TextBox><span
                                                style="color: #ff0000"> in months</span></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="orr" runat="server" Width="730px" Height="60 px">
                            <div style="text-align: center ; height:150px" >
                                <table style="height:100px">
                                    <tr align="left">
                                        <td style="width: 75px">
                                            <span style="color: #3333cc">Reason</span></td>
                                        <td style="width: 250px">
                                            <asp:TextBox ID="Txt_or" runat="server" Width="639px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pr1" runat="server" Width="720px" Height="150px">
                            <div style="text-align: center">
                                <table style="width: 729px">
                                    <tr align="left">
                                        <td align="left" style="width: 209px;">
                                            <span style="color: #0033cc">Select category</span></td>
                                        <td align="left" style="width: 250px;">
                                            <asp:DropDownList ID="cmb_pr" runat="server" Width="378px">
                                            </asp:DropDownList></td>
                                        <td align="left" style="width: 250px;">
                                        </td>
                                        <td style="width: 250px;">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="oe1" runat="server" Width="720px" Height="200px">
                            <div style="text-align: center">
                                <table style="width : 728px">
                                    <tr>
                                        <td style="width: 134px;">
                                            <span style="color: #3333cc">Firm</span></td>
                                        <td style="width: 90px;; text-align: left">
                                            <asp:TextBox ID="Txt_fir" runat="server" Width="233px"></asp:TextBox></td>
                                        <td style="width: 65px;">
                                            <span style="color: #3333cc">Reason</span></td>
                                        <td style="width: 250px; text-align: left">
                                            <asp:TextBox ID="Txt_rea" runat="server" Width="307px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 134px;">
                                            <span style="color: #3333cc">Nature of work</span></td>
                                        <td style="width: 90px; text-align: left">
                                            <asp:TextBox ID="Txt_nw" runat="server" Width="233px"></asp:TextBox></td>
                                        <td style="width: 65px;">
                                            <span style="color: #3333cc">Salary</span></td>
                                        <td style="width: 250px; text-align: left">
                                            <asp:TextBox ID="Txt_sal" runat="server" onkeyup="return change('Txt_sal')"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="mr1" runat="server" Width="720px" Height="200px">
                            <table style="width: 728px">
                                <tr>
                                    <td style="width: 118px">
                                        <span style="color: #3333cc">Place of marriage </span>
                                    </td>
                                    <td style="width: 93px">
                                        <asp:TextBox ID="Txt_pm" runat="server" Width="258px"></asp:TextBox></td>
                                    <td style="width: 106px">
                                        <span style="color: #3333cc">Name of Partner</span></td>
                                    <td style="width: 250px">
                                        <asp:TextBox ID="Txt_np" runat="server" Width="194px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 118px;">
                                        <span style="color: #3333cc">Job of Partner</span></td>
                                    <td style="width: 93px; ">
                                        <asp:TextBox ID="Txt_jp" runat="server" Width="258px"></asp:TextBox></td>
                                    <td style="width: 106px;">
                                    </td>
                                    <td style="width: 250px;">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
                    </td>
                </tr>
            </table>
            </asp:Panel></td></tr>
        <tr align="left"><td align="left"><asp:Panel id="Panel2" runat="server" Width="125px" Height="250px"><table style="WIDTH: 743px" border="1"><tbody><tr><td style="WIDTH: 362px; TEXT-ALIGN: left"><span style="COLOR: #0033cc">Select Employee</span></td><td style="TEXT-ALIGN: left" colspan="3"><asp:DropDownList id="cmb_employee" runat="server" Width="576px" AutoPostBack="true">
                                    </asp:DropDownList></td></tr><tr><td style="WIDTH: 362px; TEXT-ALIGN: left"><span style="COLOR: #3300cc">Employee Code</span></td><td style="WIDTH: 250px; TEXT-ALIGN: left"><asp:Label id="lbl_code1" runat="server" Width="136px" Text="Label" ForeColor="#C00000"></asp:Label></td><td style="WIDTH: 133px"><span style="COLOR: #3300cc">Employee Name</span></td><td style="WIDTH: 167px; TEXT-ALIGN: left"><asp:Label id="lbl_name1" runat="server" Width="218px" Text="Label" ForeColor="#C00000"></asp:Label>&nbsp; </td></tr><tr><td style="WIDTH: 362px; HEIGHT: 23px; TEXT-ALIGN: left"><span style="COLOR: #3300cc">Resignation Enter Date</span></td><td style="WIDTH: 250px; HEIGHT: 23px; TEXT-ALIGN: left"><asp:TextBox id="TextBox2" runat="server" Enabled="False"></asp:TextBox></td><td style="WIDTH: 133px; HEIGHT: 23px; TEXT-ALIGN: center"></td><td style="WIDTH: 167px; HEIGHT: 23px; TEXT-ALIGN: left"></td></tr><tr><td style="WIDTH: 362px; HEIGHT: 18px; TEXT-ALIGN: left"><span style="COLOR: #3300cc">Resignation Date</span></td><td style="WIDTH: 250px; HEIGHT: 18px"><asp:TextBox id="Txt_rsdt1" onkeypress="return van()" runat="server"></asp:TextBox></td><td style="WIDTH: 133px; HEIGHT: 18px; TEXT-ALIGN: center"><span style="COLOR: #3300ff">Relieving Date</span></td><td style="WIDTH: 167px; HEIGHT: 18px; TEXT-ALIGN: left"><asp:TextBox id="Txt_reldt" onkeypress="return van()" runat="server"></asp:TextBox> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </td></tr><tr><td style="WIDTH: 362px; HEIGHT: 33px; TEXT-ALIGN: left"><span style="COLOR: #3300cc">Resignation Reason</span></td><td style="HEIGHT: 33px; TEXT-ALIGN: left" colspan="3"><asp:DropDownList id="cmb_reason2" runat="server" Width="362px" AutoPostBack="true">
                                    </asp:DropDownList></td></tr><tr><td style="HEIGHT: 33px; TEXT-ALIGN: left" colspan="4"><asp:Panel id="mr2" runat="server" Width="720px" Height="200px">
                                        <table style="width: 728px">
                                            <tr>
                                                <td style="width: 122px">
                                                    <span style="color: #3333cc">Place of marriage </span>
                                                </td>
                                                <td style="width: 93px">
                                                    <asp:TextBox ID="Txt_pm1" runat="server" Width="255px"></asp:TextBox></td>
                                                <td style="width: 114px">
                                                    <span style="color: #3333cc">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Name of&nbsp;
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Partner</span></td>
                                                <td style="width: 250px">
                                                    <asp:TextBox ID="Txt_np1" runat="server" Width="194px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 122px">
                                                    <span style="color: #3333cc">Job of Partner</span></td>
                                                <td style="width: 93px">
                                                    <asp:TextBox ID="Txt_jp1" runat="server" Width="258px"></asp:TextBox></td>
                                                <td style="width: 114px">
                                                </td>
                                                <td style="width: 250px">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel> <asp:Panel id="oe2" runat="server" Width="720px"><div style="TEXT-ALIGN: center"><table style="height:96px; width: 728px;"><tbody><tr><td style="WIDTH: 134px; HEIGHT: 21px"><span style="COLOR: #3333cc">Firm</span></td><td style="WIDTH: 90px;TEXT-ALIGN: left"><asp:TextBox id="Txt_firm1" runat="server" Width="233px"></asp:TextBox></td><td style="WIDTH: 65px"; ><span style="COLOR: #3333cc">Reason</span></td><td style="WIDTH: 250px;TEXT-ALIGN: left"><asp:TextBox id="Txt_rea1" runat="server" Width="307px"></asp:TextBox></td></tr><tr><td style="WIDTH: 134px";><span style="COLOR: #3333cc">Nature of work</span></td><td style="WIDTH: 90px;TEXT-ALIGN: left"><asp:TextBox id="Txt_naw1" runat="server" Width="233px"></asp:TextBox></td><td style="WIDTH: 65px; HEIGHT: 21px"><span style="COLOR: #3333cc">Salary</span></td><td style="WIDTH: 250px;TEXT-ALIGN: left"><asp:TextBox id="Txt_sal1" onkeyup="return change('Txt_sal1')" runat="server"></asp:TextBox></td></tr></tbody></table></div></asp:Panel> <asp:Panel id="pr2" runat="server" Width="720px">
                                        <div style="text-align: center">
                                            <table style=" height:200px;width:729px">
                                                <tr>
                                                    <td style="width: 209px; height: 11px">
                                                        <span style="color: #0033cc">Select category</span></td>
                                                    <td style="width: 250px; height: 11px">
                                                        <asp:DropDownList ID="cmb_pr1" runat="server" AutoPostBack="true" Width="378px">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 250px; height: 11px">
                                                    </td>
                                                    <td style="width: 250px; height: 11px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel> <asp:Panel id="hs2" runat="server" Width="720px"><div style="TEXT-ALIGN: center"><table style="WIDTH: 730px"><tbody><tr><td style="WIDTH: 171px; height: 26px;"><span style="COLOR: #0033cc">College name</span></td><td style="TEXT-ALIGN: left; height: 26px;" colspan="3"><asp:TextBox id="Txt_coll1" runat="server" Width="541px"></asp:TextBox></td></tr><tr><td style="WIDTH: 171px"><span style="COLOR: #0033cc">Course</span></td><td style="WIDTH: 51px; TEXT-ALIGN: left"><asp:TextBox id="Txt_cou1" runat="server" Width="327px"></asp:TextBox></td><td style="WIDTH: 77px"><span style="COLOR: #3333cc">Duration</span></td><td style="WIDTH: 250px; TEXT-ALIGN: left"><asp:TextBox id="Txt_dur1" onkeyup="return change('Txt_dur1')" runat="server" Width="57px"></asp:TextBox><span style="COLOR: #ff0000">&nbsp;in&nbsp;months</span></td></tr></tbody></table></div></asp:Panel> 
                                    <asp:Panel id="or1" runat="server" Width="730px">
                                        <div style="text-align: center">
                                            <table style="height:40px">
                                                <tr align="left">
                                                    <td style="width: 75px" align="left">
                                                        <span style="color: #3333cc">Reason</span></td>
                                                    <td style="width: 250px">
                                                        <asp:TextBox ID="Txt_or1" runat="server" Width="639px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel> </td></tr></tbody></table></asp:Panel></td></tr>
                                  <tr align="left"><td align="left"> <table style="width: 744px"><tr> <td style="width: 141px">
                    <span style="color: #0000cc">Attach Resign letter:</span></td>
                <td colspan="2" style="text-align: center">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="394px" /></td>
                <td style="width: 213px">
                </td></tr><tr>
                <td style="width: 141px;">
                    &nbsp;
                </td>
                <td style="width: 250px; text-align: center;">
                    <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="83px" /></td>
                <td style="width: 133px; text-align: center;">
                    &nbsp;<input id="Button2" style="width: 76px" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
                <td style="width: 213px;">
                    &nbsp;&nbsp;
                </td>
            </tr></table></td></tr> </table>
    </div>
</asp:Content>

