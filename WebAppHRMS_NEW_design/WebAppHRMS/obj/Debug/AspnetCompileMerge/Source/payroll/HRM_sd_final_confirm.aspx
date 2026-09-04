<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_sd_final_confirm.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_HRM_SALARY_cd0a3f603800" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("Panel1");
function btn_Exit_onclick() 
{
window.open('../home.aspx','_self')
}

function OnClickSalary()
{
      var Status="111";
      ToServer(Status+"#"+1,1);
}


function OnClickIncentive()
{
      var Status="222";
      ToServer(Status+"#"+1,1);
}

function checkallfunction()
{
    if(document.getElementById("txt_all").checked==true)
    {
        var scount=0
        for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
        {
            var arr
            var arr1
            var arr2
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
                arr1=arr2[1];
            if(arr1=="")
            {
                scount=1
                document.getElementById("txt_"+k).checked=false;
            }
            else if(arr1.length<16)
            {
                scount=1
                document.getElementById("txt_"+k).checked=false;
            }
            else if(parseInt(arr2[2])>parseInt(20000))
            {
                scount=2
                document.getElementById("txt_"+k).checked=false;
            }
            else if(arr1!="")
            {
                document.getElementById("txt_"+k).checked=true;
            }
        } 
        if(scount==1)
        {
                alert('Sorry, SD.No is Missing,You Cant Select Some Records');
        }
        if(scount==2)
        {
                alert('Sorry, Amount>20000,You Cant Select Some Records');
        }
         
    }
    
    if(document.getElementById("txt_all").checked==false)
    {
        for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
        {
            document.getElementById("txt_"+k).checked=false;
 
        }  
    }
}


function sdselect(k)
{
    if(document.getElementById("txt_"+k).checked==true)
        {
            var arr
            var arr1
            var arr2
            arr=document.getElementById("txt_"+k).id.split("_") 
            arr2=arr[1].split("@");
                arr1=arr2[1];
            if(arr1=="")
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, SD.No is incorrect,You Cant Select This');
                return false;
            }
            else if(arr1.length<16)
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, SD.No is incorrect,You Cant Select This');
                return false;
            }
            else if(parseInt(arr2[2])>parseInt(20000))
            {
                document.getElementById("txt_"+k).checked=false;
                alert('Sorry, Amount>20000,You Cant Select This');
                return false;
            }
        }
}

 function checkbeforeconfirm() 
 {
// debugger;
    document.getElementById(cs[0]+"hid2").value="";
    for (k=1;k<=document.getElementById(cs[0]+"hid1").value;k++)
    {
        if(document.getElementById("txt_"+k).checked==true)
        {
            var arr
            var arr1
            var arr2
            
            arr=document.getElementById("txt_"+k).id.split("_") 
            //arr2=arr[1].split("@");
          //  arr1=arr[1] +  " $ " + "1";
            if(k==1)
            {
                document.getElementById(cs[0]+"hid2").value=arr[1];
            }
            if (k!=1)
            {
                document.getElementById(cs[0]+"hid2").value+="!"+arr[1];
            }
        }
//        if(document.getElementById("txt_"+k).checked==false)
//        {
//           var arr
//            var arr1
//              var arr2
//            arr=document.getElementById("txt_"+k).id.split("_") 
////            arr2=arr[1].split("@");
////            arr1=arr2[0] +  " $ " + "0";
//            arr1=arr[1] +  " $ " + "1";
//            if(k==1)
//            {
//                document.getElementById(cs[0]+"hid2").value=arr1;
//            }
//            if (k!=1)
//            {
//                document.getElementById(cs[0]+"hid2").value+="!"+arr1;
//            }
//        }
    }  
   
}    

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;</div>
    </div>
    <asp:HiddenField ID="hid1" runat="server" />
    <asp:HiddenField ID="hid2" runat="server" />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Purple" Width="657px"></asp:Label><br />
            <table border="0" style="width: 70%" align="center">
                <tr>
                    <td colspan="2" style="height: 24px; text-align: center;">
                        </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 73px;">
                        
                        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                            
                                              </asp:Panel>
                                            </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btn_Confirm" OnClientClick="checkbeforeconfirm()" runat="server" Text="CONFIRM" />
                        <input id="btn_Exit" type="button" value="EXIT" style="width: 86px" onclick="return btn_Exit_onclick()" /></td>
                </tr>
            </table>
</asp:Content>

