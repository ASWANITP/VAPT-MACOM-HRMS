<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="securitydeposit.aspx.vb" Inherits="WebAppHRMS.SecurityDep_securitydeposit_7e49a34a1830" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

var cont_name=header_txt.split("txt");

function FromServer(arg,context)
{ 
    switch (context)
    {
    case 1:
        {debugger
        var empid = arg.split("~");
            if (empid[0]!="")
            {
            document.getElementById(cont_name[0]+"txtempcode").value = empid[0];
            document.getElementById(cont_name[0]+"txtempname").value = empid[1];
            document.getElementById(cont_name[0]+"txtrdnum").value = empid[2];
            document.getElementById(cont_name[0]+"txtbranch").value = empid[4];
            var des =empid[5].split("^")
            document.getElementById(cont_name[0]+"txtdesg").value = des[0];
            document.getElementById(cont_name[0]+"txtjoindt").value = empid[3];
            }
            else
            {
             alert("No Such Employee ..!!");
             return false;
           break;
            }
       }
    }
}


function emponchange()
{
 var empCode = document.getElementById(cont_name[0]+"cmbemployee").value  ;
            if (empCode ==-1)
            {
                alert("Select Employee");
            }
            else
            {
                ToServer('1^'+empCode,1)
            }
}






function btnexit_onclick() 
{
window.open('../home.aspx','_self')
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="2">
            <tr>
                <td colspan="4" style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                    <strong>
                        <div style="text-align: center">
                            <table style="width: 530px">
                                <tr>
                                    <td style="width: 161px; text-align: center">
                                        Security Deposit </td>
                                </tr>
                            </table>
                        </div>
                    </strong></td>
            </tr>
            <tr>
                <td colspan="2" style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                    Select Employee</td>
                <td colspan="2" style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                    <asp:DropDownList ID="cmbemployee" runat="server" Width="258px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    EmpCode</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtempcode" runat="server"></asp:TextBox></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    EmpName</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtempname" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    RD Num</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtrdnum" runat="server"></asp:TextBox></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    JoinDate</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtjoindt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    Branch</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtbranch" runat="server"></asp:TextBox></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    Desg</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtdesg" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double; text-align: left;">
                    &nbsp; .</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    Amount</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <asp:TextBox ID="txtamount" runat="server"></asp:TextBox></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double; text-align: right;">
                    .&nbsp;</td>
            </tr>
            <tr>
                <td style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px;
                    border-top-style: double; border-top-color: #ff00ff; border-right-style: double;
                    border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                </td>
                <td style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px;
                    border-top-style: double; border-top-color: #ff00ff; border-right-style: double;
                    border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                </td>
                <td style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px;
                    border-top-style: double; border-top-color: #ff00ff; border-right-style: double;
                    border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                </td>
                <td style="border-left-color: #ff00ff; border-bottom-color: #ff00ff; width: 100px;
                    border-top-style: double; border-top-color: #ff00ff; border-right-style: double;
                    border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double; text-align: left;">
                    .</td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double; text-align: right;">
                    <asp:Button ID="btnconfirm" runat="server" Text="CONFIRM" Width="87px" /></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double;">
                    <input id="btnexit" style="width: 95px" type="button" value="EXIT" onclick="return btnexit_onclick()" /></td>
                <td style="width: 100px; border-left-color: #ff00ff; border-bottom-color: #ff00ff; border-top-style: double; border-top-color: #ff00ff; border-right-style: double; border-left-style: double; border-right-color: #ff00ff; border-bottom-style: double; text-align: right;">
                    .</td>
            </tr>
        </table>
    </div>
</asp:Content>

