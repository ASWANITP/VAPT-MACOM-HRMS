<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="HRM_TA_RECC_SANC.aspx.vb" Inherits="WebAppHRMS.HRM_TA_RECC_SANC_6ceb55d63629" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
//return window_onload()

// ]]>---

</script>
<script language="javascript" type="text/javascript">
// <!CDATA[
//KRISHNADAS--------JEWEL REQUEST--------10621
function all_select()
{

var data="";
var data=document.getElementById('<%= cmb_details.ClientID %>').value;
if(data!=0)
{
    data=data+"%"+22;
    ToServer(data+"#"+1,1);
}
}


function FromServer (arg,context) 
{
//debugger;  
  if(context==1)
   {
       if (arg=="NOT FOUND")
       {
       alert('No Details Found.!!');       
       }
       else
       {
       display_check(arg);
       }
   
   }
   else if(context==2)
   {
       if (arg=="NOT FOUND")
       {
       alert('Nothing Deleted.!!');       
       }
       else
       {
       alert('Removed..!'); 
       if(arg=="")
       {
            var selitem=document.getElementById('<%= cmb_details.ClientID %>').selectedIndex;
            var givenValue=document.getElementById('<%= cmb_details.ClientID %>').options[0].text
            for(var x=0;x < document.getElementById('<%= cmb_details.ClientID %>').length -1 ; x++)
                {   if(givenValue == document.getElementById('<%= cmb_details.ClientID %>').options[x].text)
                    document.getElementById('<%= cmb_details.ClientID %>').selectedIndex = x;
                }
            document.getElementById("panel_row").style.display="none";
            document.getElementById('<%= hdnDisplay.ClientID %>').value="";
       }
       else
       {
       display_check(arg);
       }
       
       
       }
   
   }
}
   function adjust_combo()
   {
//   debugger;
   document.getElementById("panel_row").style.display="none";
   var selitem=document.getElementById('<%= cmb_details.ClientID %>').selectedIndex;
   var givenValue=document.getElementById('<%= cmb_details.ClientID %>').options[selitem].text
   for(var x=0;x <= document.getElementById('<%= cmb_details.ClientID %>').length -1 ; x++)
    {  
        if(givenValue == document.getElementById('<%= cmb_details.ClientID %>').options[x].text)
        document.getElementById('<%= cmb_details.ClientID %>').remove(x);
    }
   var selitem2=document.getElementById('<%= cmb_details.ClientID %>').selectedIndex;
   var givenValue2=document.getElementById('<%= cmb_details.ClientID %>').options[0].text
   for(var x=0;x < document.getElementById('<%= cmb_details.ClientID %>').length -1 ; x++)
    {  
        if(givenValue2 == document.getElementById('<%= cmb_details.ClientID %>').options[x].text)
        document.getElementById('<%= cmb_details.ClientID %>').selectedIndex = x;
    }
   }


function display_check(str)
{

    var test2=str;
    var tmptab;
    tmptab  ="";
    tmptab  ="<table align=center width=100% border=1 style='border-collapse:collapse;'><tr width=100% style='background-color:#CCDBBF'>"  
    tmptab  =tmptab+"<td width=20% align=left style='font-size: 10pt;' ><b>SERIEL&nbsp;NO&nbsp;</b></td>"; 
    tmptab  =tmptab+"<td width=20% align=left style='font-size: 10pt;' ><b>EMPLOYEE&nbsp;CODE&nbsp;</b></td>"; 
     tmptab  =tmptab+"<td width=20% align=left style='font-size: 10pt;' ><b>FROM&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>"; 
    tmptab  =tmptab+"<td width=19% align=left style='font-size: 10pt;' ><b>TO&nbsp;DATE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>PLACE&nbsp;FROM&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>PLACE&nbsp;TO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>MODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>DISTANCE&nbsp;&nbsp;</b></td>";
    tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>AMOUNT&nbsp;&nbsp;</b></td>";
     tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>TYPE&nbsp;&nbsp;&nbsp;</b></td>";
     tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>PURPOSE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>";
       tmptab  =tmptab+"<td width=15% align=left style='font-size: 10pt;' ><b>DELETE&nbsp;&nbsp;&nbsp;</b></td></tr>";
      
    document.getElementById('<%= hid_Counter.ClientID %>').value=0;     
    var rowSplitarr =str.split("@");
    var colSplitarr;
    var row_bg1     = 0;  
    var total_amount=0;
    var m,j,cnt,TotalPrice,TotalWarranty;
    m=0;j=0;cnt=0;TotalPrice=0;TotalWarranty=0;count=0;
     for (m=0;m<=rowSplitarr.length-2;m++)
      {
     count=count+1;
        if (row_bg1 == 0)
        {
         row_bg1 = 1;
         tmptab += "<tr style='background-color:#CCDDEE;'>";
        }
        else
        {
         row_bg1 = 0;  
         tmptab += "<tr style='background-color:#CCDDEE;'>";             
        }
        
        colSplitarr     =   rowSplitarr[m].split("!");
         tmptab          =   tmptab +"<td width=3% align=left style= ><small>" + count + "</td>"  ;
         tmptab          =   tmptab +"<td width=3% align=left style= ><small>" + colSplitarr[0] + "</td>"  ;
         tmptab          =   tmptab +"<td width=5% align=left style= ><small>" + colSplitarr[1] + "</td>"  ;
         tmptab          =   tmptab +"<td width=5% align=left style= ><small>" + colSplitarr[2] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[3] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[4] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[5] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[6] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[7] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[8] + "</td>"  ;
         tmptab          =   tmptab +"<td width=6% align=left style= ><small>" +colSplitarr[9] + "</td>"  ;
         tmptab          =   tmptab +"<td width=5% align=left style= ><small><a href=javascript:delf(" + colSplitarr[10] + ")><b>Delete</b></a></td>"  ;
         total_amount=(parseFloat(total_amount)+parseFloat(colSplitarr[7])).toFixed(2);
         document.getElementById('<%= hid_Counter.ClientID %>').value=count
    } 
    tmptab          =   tmptab +"<tr style='background-color:#CCDBBF;'><td colspan=8 width=5% align=left style= ><small><b>TOTAL</b></td><td colspan=4 width=5% align=left style= ><small><b>" + total_amount + "</b></td></tr>"  ;
    tmptab          =   tmptab+"</table>";
    document.getElementById('<%= hdnDisplay.ClientID %>').value=str;
     document.getElementById("panel_row").style.display="inline";
     var col=document.getElementById('<%= hid_Counter.ClientID %>').value
     document.getElementById('<%= Panel1.ClientID %>').innerHTML =tmptab;
     }



function delf(i) 
{
    var data=i;
    data=data+"%"+33;
    ToServer(data+"#"+2,2);
}















</script>

    <div style="text-align: center; height:250" id="hidden4">
        <table border="1" style="width: 79%; height: 56px; text-align:left">
        <tr id="Tr1">
                <td style="text-align:center;" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="TA RECOMMENDATION" Font-Bold="True" Font-Size="Medium" Width="352px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr id="rw1">
                <td style="width: 47%; text-align: right;">
                    Select Employee&nbsp;
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="cmb_details" runat="server" Width="456px">
                    </asp:DropDownList></td>
            </tr>
            <tr id="panel_row" style="display:none;">
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center ">
                    <asp:Button ID="Button3" runat="server" Text="Confirm"/><input id="Button2" runat="server" style="width: 65px" type="button" value="Exit" /></td>
            </tr>
        </table>
        <asp:HiddenField ID="hdn_sysdate" runat="server" />
        &nbsp;<asp:HiddenField ID="hdnDisplay" runat="server" />
        &nbsp;&nbsp;
        <input id="hid_details" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_Counter" runat="server" style="width: 1px" type="hidden" />
        <input id="Hid_del" runat="server" style="width: 1px" type="hidden" />
        <input id="Hidden4" runat="server" style="width: 1px" type="hidden" />
        <input id="hid_rep" runat="server" style="width: 1px" type="hidden" />
        <input id="hidden1" runat="server" style="width: 1px" type="hidden" />&nbsp;
    </div>
</asp:Content>

