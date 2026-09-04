<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="add_norm.aspx.vb" Inherits="WebAppHRMS.audit_staffnorm_audit_norm_cf88f00a6132" title="Untitled Page" %>

<script runat="server">

        
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
function isNumberKey(ids)
{ 
    var charcode = (event.which) ? event.which : event.keyCode
    if(ids==1)
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32))
        {
            return true;
        } 
        else
            return false;  
    }
    if(ids==2)
    {
        if ((charcode > 96 && charcode <127) ||(charcode < 91 && charcode > 64  ) || (charcode==32) ||(charcode > 46 && charcode <58))
        {
            return true;
        } 
        else
            return false;  
    }
    if(ids==3)    
    {
        if (charcode > 31 && (charcode < 48 || charcode > 57  ))
        {
            return false;
        } 
        else
            return true;  
    }
}  
// <!CDATA[

function btn_exit_onclick()
 {
 window.open('../../home.aspx','_self');

}


// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table border="1">
                    <caption>
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                        
                        </asp:ScriptManager>--%>
                    </caption>
                    <%--<tr>
                        <td colspan="2" style="width: 238px">
                            SELECT BRANCH</td>
                        <td style="text-align: left;" colspan="3">
                            <asp:DropDownList ID="drpdwn_region" OnSelectedIndexChanged="drpdwn_region_SelectedIndexChanged" AutoPostBack="true"  runat="server" Width="422px">
                            </asp:DropDownList></td>
                    </tr>--%>
<%--                    <tr>
                        <td colspan="2" style="height: 23px; width: 238px;">
                        </td>
                        <td colspan="3" style="height: 23px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="2" style="text-align: center; width: 238px;">
                            SELECT DEPARTMENT</td>
                        <td colspan="3" style="text-align: left">
                            &nbsp;<asp:DropDownList ID="drp_post" runat="server" AutoPostBack="True" Width="418px">
                            </asp:DropDownList>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 23px; width: 238px;">
                        </td>
                        <td colspan="3" style="height: 23px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 238px">
                            ENTER THE REQUIRED NUMBER </td>
                        <td style="text-align: left;" colspan="3">
                            &nbsp;<asp:TextBox AutoPostBack="true" OnTextChanged="txt_req_num_TextChanged" ID="txt_req_num" runat="server" Width="131px" MaxLength="3" onkeypress="return isNumberKey(3)"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 238px">
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 238px">
                            <asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" Width="123px" /></td>
                        <td colspan="3">
                            <input id="btn_exit" style="width: 120px" type="button" value="EXIT" onclick="return btn_exit_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

