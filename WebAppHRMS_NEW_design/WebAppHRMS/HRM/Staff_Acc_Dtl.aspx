<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Staff_Acc_Dtl.aspx.vb"
    Inherits="Staff_Account_Staff_Acc_Dtl_12fe44a33050" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
    </script>

    <script language="javascript" type="text/javascript">
// <!CDATA[
var cnt_id =invoice.split("txt");
function window_onload()
{
    row_name.style.display="none";
    row_des.style.display="none";
    row_acc.style.display="none";
    row_ver.style.display="none";
    row_con.style.display="none";
    row_bal.style.display="none";
    document.getElementById(cnt_id[0]+"txtcode").value="";
}
function getDetail()
{
    var e_code=document.getElementById(cnt_id[0]+"txtcode").value;
    if(e_code=='')
    {
    alert("Please Enter The Employee Code");
    return false;
    }
    else
    {
        ToServer('1^'+e_code,1);
    }
}
function btn_verify()
{
    ToServer('2^'+document.getElementById(cnt_id[0]+"HidAcc").value,2);
}
function btn_confirm()
{
    ToServer('3^'+document.getElementById(cnt_id[0]+"HidAcc").value,3);
}
function FromServer(Arg1,Arg2)
{
    switch (Arg2)
    {
        case 1:
        {
            if(Arg1=="0")
            {
                window_onload();
                alert("Enter Correct Employee Code");
            }
            else if(Arg1=="00")
            {
                window_onload();
                alert("No Account For This Employe Please Add New");
            }
            else if(Arg1=="000")
            {
                window_onload();
                alert("This Employee Not Resigned OR Not Completed 1Year After Resignation");
                return false;
            }
            else if (Arg1!="") 
            {
                var cols=Arg1.split("�");
                document.getElementById(cnt_id[0]+"txtname").value=cols[1];
                document.getElementById(cnt_id[0]+"txtdesign").value=cols[3];
                document.getElementById(cnt_id[0]+"txtaccno").value=cols[0];
                document.getElementById(cnt_id[0]+"HidAcc").value=cols[0];
                inlinetable();
                row_con.style.display="none";
            }
            break;
        }
        case 2:
        {
            if (Arg1!="") 
            {
                var bal=Arg1;
                inlinetable();
                if(bal==0)//17618
                {
                    row_bal.style.display="inline";
                    row_con.style.display="inline";
                    document.getElementById(cnt_id[0]+"txtbal").value=Math.abs(bal);
                    document.getElementById(cnt_id[0]+"lbl_mode").disabled=true;
                }
                else if(bal<0)
                {
                     row_bal.style.display="inline";
                     row_con.style.display="inline";
                     document.getElementById(cnt_id[0]+"txtbal").value=Math.abs(bal);
                     document.getElementById(cnt_id[0]+"lbl_mode").innerHTML="DEBIT";
                     document.getElementById(cnt_id[0]+"lbl_mode").disabled=false;
                     document.getElementById(cnt_id[0]+"btn_confirm").disabled=true;
                }
                else if(bal>0)
                {
                    row_bal.style.display="inline";
                    row_con.style.display="inline";
                    document.getElementById(cnt_id[0]+"txtbal").value=Math.abs(bal);
                    document.getElementById(cnt_id[0]+"lbl_mode").innerHTML="CREDIT";
                    document.getElementById(cnt_id[0]+"lbl_mode").disabled=false;
                    document.getElementById(cnt_id[0]+"btn_confirm").disabled=true;
                }
           }
           else
              {    
                  window_onload();            
                  alert("This Account Already Settled");
              }
            break;
        }
        case 3:
        {
            if(Arg1!="")
            {
                window_onload();
                alert(Arg1);
            }
        }
    }  
}
function inlinetable()
{
    row_name.style.display="inline";
    row_des.style.display="inline";
    row_acc.style.display="inline";
    row_ver.style.display="inline";
}
function isNumberKey(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode 
    if (charCode > 31 && (charCode < 48 || charCode > 57))
    {
        alert("U Can Enter Numbers Only")
        return false;   
    }         
    return true;
}
// ]]>
    </script>

    <div style="text-align: center">
        &nbsp;<div style="text-align: center">
            <table border="1" style="border-right: #ff99ff thin double; border-top: #ff99ff thin double; border-left: #ff99ff thin double; border-bottom: #ff99ff thin double;">
                <tr>
                    <td colspan="2">
                        <span style="color: #99005e; text-decoration: underline"><strong>STAFF ACCOUNT SETTILMENT</strong></span></td>
                </tr>
                <tr id="row_code">
                    <td style="text-align: center; width: 180px;">&nbsp;Employee&nbsp;Code&nbsp;:</td>
                    <td style="width: 198px; text-align: left">
                        <asp:TextBox ID="txtcode" runat="server" Height="21px" Width="189px" MaxLength="6"></asp:TextBox></td>
                </tr>
                <tr id="row_name">
                    <td style="text-align: center; width: 180px;">&nbsp;Name&nbsp;:&nbsp;</td>
                    <td style="width: 198px; text-align: left">
                        <asp:TextBox ID="txtname" runat="server" Height="21px" Width="189px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr id="row_des">
                    <td style="text-align: center; width: 180px;">&nbsp;Designation&nbsp;:&nbsp;</td>
                    <td style="width: 198px; text-align: left">
                        <asp:TextBox ID="txtdesign" runat="server" Height="21px" Width="189px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr id="row_acc">
                    <td style="text-align: center; width: 180px;">&nbsp;Staff&nbsp;Account&nbsp; Number&nbsp: &nbsp;&nbsp</td>
                    <td style="width: 198px; text-align: left">
                        <asp:TextBox ID="txtaccno" runat="server" Height="21px" Width="189px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr id="row_ver">
                    <td style="text-align: center; height: 27px;" colspan="2">
                        <input id="btn_verify" runat="server" style="height: 24px; width: 66px" type="button"
                            value="Verify" />
                        &nbsp; &nbsp;
                    </td>
                </tr>
                <tr id="row_bal">
                    <td style="width: 180px; text-align: center">Balance 
                    </td>
                    <td style="width: 198px; text-align: left">
                        <asp:TextBox ID="txtbal" runat="server" Height="17px" Width="92px" ReadOnly="True"></asp:TextBox>
                        &nbsp; &nbsp; 
                        <asp:Label ID="lbl_mode" runat="server" Width="71px" Font-Bold="True" ForeColor="#00C000"></asp:Label></td>
                </tr>
                <tr id="row_con">
                    <td colspan="2">
                        <asp:Button ID="btn_confirm" runat="server" Text="Confirm" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btn_exit" runat="server" Height="24px" Text="Exit" Width="66px" /></td>
                </tr>
            </table>
        </div>
    </div>
    &nbsp;<br />
    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:HiddenField ID="HidAcc" runat="server" />
</asp:Content>
