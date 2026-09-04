<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="return_neft_salary.aspx.vb"
    Inherits="Return_Neft_Salary_return_neft_salary_7b2cfa886629" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
    </script>

    <script language="javascript" type="text/javascript">
// <!CDATA[
var cnt_id =invoice.split("Hid");

function window_onload() {
    row1.style.display="none";
    row2.style.display="none";
    row3.style.display="none";
    row4.style.display="none";
    row5.style.display="none";
    row6.style.display="none";
    row7.style.display="none";
    row8.style.display="none";
    row9.style.display="none";
    document.getElementById(cnt_id[0]+"txtEmpCode").value='';
    document.getElementById(cnt_id[0]+"chkSelBr").checked = false;
    document.getElementById(cnt_id[0]+"radDb").checked=false;
    document.getElementById(cnt_id[0]+"radNeft").checked=false;
}
function getReturnData()
{
    if(document.getElementById(cnt_id[0]+"txtEmpCode").value != "")
    {
        ToServer('1^'+document.getElementById(cnt_id[0]+"txtEmpCode").value,1)
    }
    
}
function getEmpDtl()
{
    var index = document.getElementById(cnt_id[0]+"cmbNeftDtl").selectedIndex;
    if(index != -1)
    {
        ToServer('2^'+document.getElementById(cnt_id[0]+"cmbNeftDtl").value+'^'+document.getElementById(cnt_id[0]+"cmbNeftDtl").options[index].text,2);    
    }
    else
    {
        alert("Select Any Detail");
        return false;
    }
}
function FromServer(Arg1,Arg2)
{
    switch (Arg2)
    {  
        case 1:
        {
            if (Arg1!="!~")
            {
                document.getElementById(cnt_id[0]+"cmbNeftDtl").options.length = 0;
                var rows = Arg1.split("�");                
                for(a=0;a<rows.length-1;a++)
                {
                    var cols = rows[a].split("�");                        
                    var option1 = document.createElement("OPTION");
                    option1.value = cols[0];
                    option1.text  = cols[1];
                    document.getElementById(cnt_id[0]+"cmbNeftDtl").add(option1);                       
                }
                row1.style.display="inline";
                row2.style.display="none";
                row3.style.display="none";
                row4.style.display="none";
                row5.style.display="none";
                row6.style.display="none";
                row7.style.display="none";
                row8.style.display="none";
                row9.style.display="none";
                document.getElementById(cnt_id[0]+"chkSelBr").checked = false;
                document.getElementById(cnt_id[0]+"radDb").checked=false;
                document.getElementById(cnt_id[0]+"radNeft").checked=false;
            }
            else
            {
                alert('Enter Currect Employee Code!!');                  
                row1.style.display="none";
                row2.style.display="none";
                row3.style.display="none";
                row4.style.display="none";
                row5.style.display="none";
                row6.style.display="none";
                row7.style.display="none";
                row8.style.display="none";
                row9.style.display="none";  
                return false;
            }
            break;
        }
        case 2:
        {
            if (Arg1!="~*")
            {
                var empDtl = Arg1.split("�"); 
                document.getElementById(cnt_id[0]+"txtName").value=empDtl[0];
                document.getElementById(cnt_id[0]+"txtBranch").value=empDtl[1];
                document.getElementById(cnt_id[0]+"txtAmt").value=empDtl[2];
                document.getElementById(cnt_id[0]+"HidAmt").value=empDtl[2];
                document.getElementById(cnt_id[0]+"txtValDt").value=empDtl[3];
                document.getElementById(cnt_id[0]+"HidValueDt").value=empDtl[3];
                document.getElementById(cnt_id[0]+"txtNetSal").value=empDtl[4];
                document.getElementById(cnt_id[0]+"HidNetSal").value=empDtl[4];
                document.getElementById(cnt_id[0]+"txtTa").value=empDtl[5];
                document.getElementById(cnt_id[0]+"HidTa").value=empDtl[5];
                
                document.getElementById(cnt_id[0]+"txtBenAcct").value=empDtl[6];
                document.getElementById(cnt_id[0]+"txtBenBranch").value=empDtl[7];
                document.getElementById(cnt_id[0]+"txtIfsc").value=empDtl[8];
                document.getElementById(cnt_id[0]+"txtSendDt").value=empDtl[9];
                document.getElementById(cnt_id[0]+"HidSendDt").value=empDtl[9];
                document.getElementById(cnt_id[0]+"HidBranch").value=empDtl[10];
                
                row1.style.display="inline";
                row2.style.display="inline";
                row3.style.display="inline";
                row4.style.display="inline";
                row5.style.display="inline";
                row6.style.display="none";
                row7.style.display="none";
                row8.style.display="none";
                row9.style.display="none";
                document.getElementById(cnt_id[0]+"chkSelBr").checked = false;
                document.getElementById(cnt_id[0]+"radDb").checked=false;
                document.getElementById(cnt_id[0]+"radNeft").checked=false;
            }
            else
            {
                alert('No details Found!!');
                row1.style.display="none";
                row2.style.display="none";
                row3.style.display="none";
                row4.style.display="none";
                row5.style.display="none";
                row6.style.display="none";
                row7.style.display="none";
                row8.style.display="none";
                row9.style.display="none"; 
                document.getElementById(cnt_id[0]+"chkSelBr").checked = false;
                document.getElementById(cnt_id[0]+"radDb").checked=false;
                document.getElementById(cnt_id[0]+"radNeft").checked=false;  
                return false;
            }
            break;
        }
        case 3:
        {
            if (Arg1 == "@@@")
            {
                alert('Neft Details Not Verified!!');  
                document.getElementById(cnt_id[0]+"radDb").checked=true; 
                row8.style.display="inline";
                row6.style.display="none";
                row7.style.display="none";
                return false;
            }
            if(Arg1 == "~@!")
            {
                alert('Neft Details Not Added!!');   
                document.getElementById(cnt_id[0]+"radDb").checked=true;
                row8.style.display="inline";
                row6.style.display="none";
                row7.style.display="none";
                return false;
            }
            break;
        }  
    }
} 
function isNumberKey(evt)
{
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
    {
        alert("Press Only Numbers")
        return false;   
    }         
    return true;
}
function checkCustomer()
{
    if(document.getElementById(cnt_id[0]+"radNeft").checked == true)
    {
        row1.style.display="inline";
        row2.style.display="inline";
        row3.style.display="inline";
        row4.style.display="inline";
        row5.style.display="inline";
        row6.style.display="inline";
        row7.style.display="inline";
        row8.style.display="none";
        row9.style.display="none"; 
        ToServer('3^'+document.getElementById(cnt_id[0]+"txtEmpCode").value,3);       
    }
}     
function checkBranch()
{
    if(document.getElementById(cnt_id[0]+"radDb").checked == true)
    {
        row1.style.display="inline";
        row2.style.display="inline";
        row3.style.display="inline";
        row4.style.display="inline";
        row5.style.display="inline";
        row6.style.display="none";
        row7.style.display="none";
        row8.style.display="inline";
        row9.style.display="none";  
    }
}
function getBranch()
{
    if(document.getElementById(cnt_id[0]+"chkSelBr").checked == true)
    {
        row9.style.display="inline";
    }
    else
    {
        row9.style.display="none";
    }
}

function btnExit_onclick() {
    window.open ('../home.aspx','_self');
}

function btnConfirmOnclick()
{    
    if(document.getElementById(cnt_id[0]+"txtEmpCode").value=='')
    {
        alert('Employee Code is blank!!');   
        return false;
    }
    if(document.getElementById(cnt_id[0]+"cmbNeftDtl").value == -1)
    {
        alert('Select Salary Details!!');   
        return false;
    }   
    if(document.getElementById(cnt_id[0]+"chkSelBr").checked == true)
    {
        if(document.getElementById(cnt_id[0]+"cmbBranch").value == -1)
        {
            alert('Select Receiving Branch!!');   
            return false;
        }
    } 
    if(document.getElementById(cnt_id[0]+"radNeft").checked == false)
    {
        if(document.getElementById(cnt_id[0]+"radDb").checked == false)
        {
            alert('Select PayMode(Neft/Debit Advice)!!');   
            return false;
        } 
    }   
}

// ]]>
    </script>

    <div style="text-align: center">
        <br />
        <table style="border-right: #ff99cc thin double; border-top: #ff99cc thin double;
            border-left: #ff99cc thin double; border-bottom: #ff99cc thin double">
            <tr>
                <td colspan="2" style="height: 24px; border-right: #cc99ff thin double; border-top: #cc99ff thin double;
                    border-left: #cc99ff thin double; border-bottom: #cc99ff thin double; background-color: #ccccff;">
                    <span style="color: #660045; text-decoration: underline"><strong>RESENDING NEFT RETURN</strong></span></td>
            </tr>
            <tr>
                <td style="width: 375px; text-align: right; height: 24px; border-right: #999999 thin double;
                    border-top: #999999 thin double; border-left: #999999 thin double; border-bottom: #999999 thin double;">
                    Enter&nbsp;Employee&nbsp;Code&nbsp;:&nbsp;</td>
                <td style="width: 300px; text-align: left; height: 24px; border-right: #999999 thin double;
                    border-top: #999999 thin double; border-left: #999999 thin double; border-bottom: #999999 thin double;">
                    <asp:TextBox ID="txtEmpCode" runat="server" Width="184px" MaxLength="5"></asp:TextBox></td>
            </tr>
            <tr id="row1">
                <td style="height: 23px; border-right: #999999 thin double; border-top: #999999 thin double;
                    border-left: #999999 thin double; border-bottom: #999999 thin double;" colspan="2">
                    Select&nbsp;Neft&nbsp;:&nbsp;<asp:DropDownList ID="cmbNeftDtl" runat="server" Width="484px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="row2">
                <td style="width: 375px; height: 24px; text-align: right; border-right: #ccccff thin double;
                    border-top: #ccccff thin double; border-left: #ccccff thin double; border-bottom: #ccccff thin double;">
                    Employee&nbsp;Name&nbsp;:&nbsp;<asp:TextBox ID="txtName" runat="server" Width="230px"
                        ReadOnly="True"></asp:TextBox></td>
                <td style="width: 300px; height: 24px; text-align: right; border-right: #ccccff thin double;
                    border-top: #ccccff thin double; border-left: #ccccff thin double; border-bottom: #ccccff thin double;">
                    Amount&nbsp;:&nbsp;<asp:TextBox ID="txtAmt" runat="server" Width="192px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="row3">
                <td style="width: 375px; height: 24px; text-align: right; border-right: #ccccff thin double;
                    border-top: #ccccff thin double; border-left: #ccccff thin double; border-bottom: #ccccff thin double;">
                    Branch&nbsp;:&nbsp;<asp:TextBox ID="txtBranch" runat="server" Width="230px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 300px; height: 24px; text-align: right; border-right: #ccccff thin double;
                    border-top: #ccccff thin double; border-left: #ccccff thin double; border-bottom: #ccccff thin double;">
                    Value&nbsp;Date&nbsp;:&nbsp;<asp:TextBox ID="txtValDt" runat="server" Width="192px"
                        ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="row4">
                <td style="border-right: #ccccff thin double; border-top: #ccccff thin double; border-left: #ccccff thin double;
                    width: 375px; border-bottom: #ccccff thin double; height: 24px; text-align: right">
                    Net&nbsp;Salary&nbsp;:&nbsp;<asp:TextBox ID="txtNetSal" runat="server" Width="230px"
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td style="border-right: #ccccff thin double; border-top: #ccccff thin double; border-left: #ccccff thin double;
                    width: 300px; border-bottom: #ccccff thin double; height: 24px; text-align: right">
                    TA&nbsp;:&nbsp;<asp:TextBox ID="txtTa" runat="server" Width="192px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr id="row5">
                <td style="height: 24px; border-right: #ccccff thin double; border-top: #ccccff thin double;
                    border-left: #ccccff thin double; border-bottom: #ccccff thin double;" colspan="2">
                    <asp:RadioButton ID="radNeft" runat="server" onclick="checkCustomer()" Text="Neft"
                        Font-Bold="True" GroupName="radPaymode" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:RadioButton ID="radDb" runat="server" onclick="checkBranch()" Text="Debit Advice"
                        Font-Bold="True" GroupName="radPaymode" /></td>
            </tr>
            <tr id="row6">
                <td style="width: 375px; height: 25px; text-align: right; border-right: #ffccff thin double;
                    border-top: #ffccff thin double; border-left: #ffccff thin double; border-bottom: #ffccff thin double;">
                    Benificiary&nbsp;Account&nbsp;:&nbsp;<asp:TextBox ID="txtBenAcct" runat="server"
                        Width="230px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 300px; height: 25px; text-align: right; border-right: #ffccff thin double;
                    border-top: #ffccff thin double; border-left: #ffccff thin double; border-bottom: #ffccff thin double;">
                    IFSC&nbsp;Code&nbsp;:&nbsp;<asp:TextBox ID="txtIfsc" runat="server" Width="192px"
                        ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr id="row7">
                <td style="border-right: #ffccff thin double; border-top: #ffccff thin double; border-left: #ffccff thin double;
                    width: 375px; border-bottom: #ffccff thin double; height: 25px; text-align: right">
                    Benificiary&nbsp;Branch&nbsp;:&nbsp;<asp:TextBox ID="txtBenBranch" runat="server"
                        Width="230px" ReadOnly="True"></asp:TextBox></td>
                <td style="border-right: #ffccff thin double; border-top: #ffccff thin double; border-left: #ffccff thin double;
                    width: 300px; border-bottom: #ffccff thin double; height: 25px; text-align: right">
                    Send&nbsp;Date&nbsp;:&nbsp;<asp:TextBox ID="txtSendDt" runat="server" Width="192px"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr id="row8">
                <td style="height: 25px; border-right: #cc99cc thin double; border-top: #cc99cc thin double;
                    border-left: #cc99cc thin double; border-bottom: #cc99cc thin double;" colspan="2">
                    &nbsp;<asp:CheckBox ID="chkSelBr" runat="server" onclick="getBranch()" Text="Change Receiving Branch"
                        Width="264px" /></td>
            </tr>
            <tr id="row9">
                <td style="height: 25px; border-right: #cc99cc thin double; border-top: #cc99cc thin double;
                    border-left: #cc99cc thin double; border-bottom: #cc99cc thin double;" colspan="2">
                    Select&nbsp;Branch&nbsp;:&nbsp;<asp:DropDownList ID="cmbBranch" runat="server" Width="424px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 25px; border-right: #999999 thin double; border-top: #999999 thin double;
                    border-left: #999999 thin double; border-bottom: #999999 thin double;" colspan="2">
                    <asp:Button ID="btnConfirm" runat="server" Text="CONFIRM" Width="88px" />
                    &nbsp;&nbsp;
                    <input id="btnExit" type="button" value="EXIT" style="width: 88px" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HidAmt" runat="server" />
    <asp:HiddenField ID="HidBranch" runat="server" />
    <asp:HiddenField ID="HidNetSal" runat="server" />
    <asp:HiddenField ID="HidTa" runat="server" />
    <asp:HiddenField ID="HidSendDt" runat="server" />
    <asp:HiddenField ID="HidValueDt" runat="server" />
</asp:Content>
