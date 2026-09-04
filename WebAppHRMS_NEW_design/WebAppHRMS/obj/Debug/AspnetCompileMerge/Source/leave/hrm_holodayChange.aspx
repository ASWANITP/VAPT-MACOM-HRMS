<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="hrm_holodayChange.aspx.vb" Inherits="WebAppHRMS.Holiday_Change_hrm_holodayChange_f727a9fc6124" title="Untitled Page" %>
<%@ Register Assembly ="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split('ddl');
function btnExit_onclick()
{
    window.open('../home.aspx','_self');
}
function CheckZone()
{
   if(document.getElementById(cont_name[0]+"rdZone").checked==true)
   {      
      document.getElementById(cont_name[0]+"ddlZone").options.value=-1; 
      document.getElementById(cont_name[0]+"lblZone").style.display="inline";
      document.getElementById(cont_name[0]+"lblRegion").style.display="none";
      document.getElementById(cont_name[0]+"lblArea").style.display="none";
      document.getElementById(cont_name[0]+"lblState").style.display="none";
      document.getElementById(cont_name[0]+"lblDistrict").style.display="none";
      document.getElementById(cont_name[0]+"lblBranch").style.display="none";
      document.getElementById(cont_name[0]+"ddlZone").style.display='inline';
      document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
      document.getElementById(cont_name[0]+"ddlArea").style.display='none';
      document.getElementById(cont_name[0]+"ddlState").style.display='none';
      document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
      document.getElementById(cont_name[0]+"ddlBranch").style.display='none';
     
     //To Give Value and Text to Drop Down Box
      document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
      var optn = document.createElement("OPTION");
      optn.text = "--- Select HoliDay ---";
      optn.value = " 15-Aug-1947";
      document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
   }
}
function CheckRegion()
{
    if(document.getElementById(cont_name[0]+"rdRegion").checked==true)
    {
        callserver("8$",2); 
        document.getElementById(cont_name[0]+"ddlRegion").options.value=-1; 
        document.getElementById(cont_name[0]+"lblZone").style.display='none';        
        document.getElementById(cont_name[0]+"lblRegion").style.display='inline';
        document.getElementById(cont_name[0]+"lblArea").style.display='none';
        document.getElementById(cont_name[0]+"lblState").style.display='none';
        document.getElementById(cont_name[0]+"lblDistrict").style.display='none';
        document.getElementById(cont_name[0]+"lblBranch").style.display='none';
        document.getElementById(cont_name[0]+"ddlZone").style.display='none';
        document.getElementById(cont_name[0]+"ddlRegion").style.display='inline';
        document.getElementById(cont_name[0]+"ddlArea").style.display='none';
        document.getElementById(cont_name[0]+"ddlState").style.display='none';
        document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
        document.getElementById(cont_name[0]+"ddlBranch").style.display='none'; 
       
       //To Give Value and Text to Drop Down Box
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
        var optn = document.createElement("OPTION");
        optn.text = "--- Select HoliDay ---";
        optn.value = " 15-Aug-1947";
        document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
        
         
    }
}
function CheckArea()
{   
    if(document.getElementById(cont_name[0]+"rdArea").checked==true)
    {
        callserver("9$",3); 
        document.getElementById(cont_name[0]+"ddlArea").options.value=-1;  
        document.getElementById(cont_name[0]+"lblZone").style.display='none';
        document.getElementById(cont_name[0]+"lblRegion").style.display='none';
        document.getElementById(cont_name[0]+"lblArea").style.display='inline';
        document.getElementById(cont_name[0]+"lblState").style.display='none';
        document.getElementById(cont_name[0]+"lblDistrict").style.display='none';
        document.getElementById(cont_name[0]+"lblBranch").style.display='none';
        document.getElementById(cont_name[0]+"ddlZone").style.display='none';
        document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
        document.getElementById(cont_name[0]+"ddlArea").style.display='inline';
        document.getElementById(cont_name[0]+"ddlState").style.display='none';
        document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
        document.getElementById(cont_name[0]+"ddlBranch").style.display='none';
        
        //To Give Value and Text to Drop Down Box
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
        var optn = document.createElement("OPTION");
        optn.text = "--- Select HoliDay ---";
        optn.value = " 15-Aug-1947";
        document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
    }
}
function CheckState()
{
    if(document.getElementById(cont_name[0]+"rdState").checked==true)
    {
        callserver("10$",4); 
        document.getElementById(cont_name[0]+"ddlState").options.value=-1;  
        document.getElementById(cont_name[0]+"lblZone").style.display='none';
        document.getElementById(cont_name[0]+"lblRegion").style.display='none';
        document.getElementById(cont_name[0]+"lblArea").style.display='none';
        document.getElementById(cont_name[0]+"lblState").style.display='inline';
        document.getElementById(cont_name[0]+"lblDistrict").style.display='none';
        document.getElementById(cont_name[0]+"lblBranch").style.display='none';
        document.getElementById(cont_name[0]+"ddlZone").style.display='none';
        document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
        document.getElementById(cont_name[0]+"ddlArea").style.display='none';
        document.getElementById(cont_name[0]+"ddlState").style.display='inline';
        document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
        document.getElementById(cont_name[0]+"ddlBranch").style.display='none';
        
        //To Give Value and Text to Drop Down Box
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
        var optn = document.createElement("OPTION");
        optn.text = "--- Select HoliDay ---";
        optn.value = " 15-Aug-1947";
        document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
    }
}
function CheckDistrict()
{
    if(document.getElementById(cont_name[0]+"rdDistrict").checked==true)
    {
     
        callserver("11$",5);    
        document.getElementById(cont_name[0]+"ddlDistrict").options.value=-1;   
        document.getElementById(cont_name[0]+"lblZone").style.display='none';
        document.getElementById(cont_name[0]+"lblRegion").style.display='none';
        document.getElementById(cont_name[0]+"lblArea").style.display='none';
        document.getElementById(cont_name[0]+"lblState").style.display='none';
        document.getElementById(cont_name[0]+"lblDistrict").style.display='inline';
        document.getElementById(cont_name[0]+"lblBranch").style.display='none';
        document.getElementById(cont_name[0]+"ddlZone").style.display='none';
        document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
        document.getElementById(cont_name[0]+"ddlArea").style.display='none';
        document.getElementById(cont_name[0]+"ddlState").style.display='none';
        document.getElementById(cont_name[0]+"ddlDistrict").style.display='inline';
        document.getElementById(cont_name[0]+"ddlBranch").style.display='none'; 
        
        //To Give Value and Text to Drop Down Box
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
        var optn = document.createElement("OPTION");
        optn.text = "--- Select HoliDay ---";
        optn.value = " 15-Aug-1947";
        document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
    }
}
function CheckBranch()
{
    if(document.getElementById(cont_name[0]+"rdBranch").checked==true)
    {
    
        callserver("12$",6);    
        document.getElementById(cont_name[0]+"ddlBranch").options.value=-1;  
        document.getElementById(cont_name[0]+"lblZone").style.display='none';
        document.getElementById(cont_name[0]+"lblRegion").style.display='none';
        document.getElementById(cont_name[0]+"lblArea").style.display='none';
        document.getElementById(cont_name[0]+"lblState").style.display='none';
        document.getElementById(cont_name[0]+"lblDistrict").style.display='none';
        document.getElementById(cont_name[0]+"lblBranch").style.display='inline';
        document.getElementById(cont_name[0]+"ddlZone").style.display='none';
        document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
        document.getElementById(cont_name[0]+"ddlArea").style.display='none';
        document.getElementById(cont_name[0]+"ddlState").style.display='none';
        document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
        document.getElementById(cont_name[0]+"ddlBranch").style.display='inline';
        
        //To Give Value and Text to Drop Down Box
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
        var optn = document.createElement("OPTION");
        optn.text = "--- Select HoliDay ---";
        optn.value = " 15-Aug-1947";
        document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
    }
}
function window_onload() 
{
       document.getElementById(cont_name[0]+"rdZone").checked=true;
       document.getElementById(cont_name[0]+"lblZone").style.display="inline";
       document.getElementById(cont_name[0]+"lblRegion").style.display="none";
       document.getElementById(cont_name[0]+"lblArea").style.display="none";
       document.getElementById(cont_name[0]+"lblState").style.display="none";
       document.getElementById(cont_name[0]+"lblDistrict").style.display="none";
       document.getElementById(cont_name[0]+"lblBranch").style.display="none";
       document.getElementById(cont_name[0]+"ddlZone").style.display='inline';
       document.getElementById(cont_name[0]+"ddlRegion").style.display='none';
       document.getElementById(cont_name[0]+"ddlArea").style.display='none';
       document.getElementById(cont_name[0]+"ddlState").style.display='none';
       document.getElementById(cont_name[0]+"ddlDistrict").style.display='none';
       document.getElementById(cont_name[0]+"ddlBranch").style.display='none';
       
       //To Give Value and Text to Drop Down Box
       document.getElementById(cont_name[0]+"ddlHoliday").options.length=0; 
       var optn = document.createElement("OPTION");
       optn.text = "--- Select HoliDay ---";
       optn.value = " 15-Aug-1947";
       document.getElementById(cont_name[0]+"ddlHoliday").options.add(optn);
}
function FuncDisChange()
{
    if(document.getElementById(cont_name[0]+"rdDistrict").checked==true) // District 
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlDistrict").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("1$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
    if(document.getElementById(cont_name[0]+"rdBranch").checked==true) //Branch
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlBranch").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("2$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
   if(document.getElementById(cont_name[0]+"rdState").checked==true) //State
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlState").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("3$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
    if(document.getElementById(cont_name[0]+"rdZone").checked==true) //Zone
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlZone").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("4$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
    if(document.getElementById(cont_name[0]+"rdRegion").checked==true) //Region
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlRegion").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("5$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
    if(document.getElementById(cont_name[0]+"rdArea").checked==true) //Area
    {
        document.getElementById(cont_name[0]+"Hidden1").value=document.getElementById(cont_name[0]+"ddlArea").value;
       
        if(document.getElementById(cont_name[0]+"Hidden1").value!=-1)
        {
            callserver("6$"+document.getElementById(cont_name[0]+"Hidden1").value,1);  
        }
    }
}
function call_receiver(arg,context) 
{  
   
  switch (context)
  {
    case 1:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"ddlHoliday").options.length=0;
        if (dist[0]=="") { alert("No Details ..!!!"); return false; }
          ComboFill(dist[0],"ddlHoliday"); 
        break;
    }
    case 2:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"ddlRegion").options.length=0;
        if (dist[0]=="") 
        { 
            alert("No Details ..!!!"); 
            return false; 
        }
        ComboFill(dist[0],"ddlRegion"); 
        break;
    }
    case 3:
    {
        var dist= arg.split("@");
        document.getElementById(cont_name[0]+"ddlArea").options.length=0;
        if(dist[0]=="")
        {
            alert("No Details.....");
            return false;
        }
        ComboFill(dist[0],"ddlArea");
        break;
    }
    case 4:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"ddlState").options.length=0;
        if (dist[0]=="") 
        { 
            alert("No Details ..!!!"); 
            return false; 
        }
        ComboFill(dist[0],"ddlState"); 
        break;
    }
    case 5:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"ddlDistrict").options.length=0;
        if (dist[0]=="") 
        { 
            alert("No Details ..!!!"); 
            return false; 
        }
        ComboFill(dist[0],"ddlDistrict"); 
        break;
    }
    case 6:
    {   
        var dist = arg.split("@"); 
        document.getElementById(cont_name[0]+"ddlBranch").options.length=0;
        if (dist[0]=="") 
        { 
            alert("No Details ..!!!"); 
            return false; 
        }
        ComboFill(dist[0],"ddlBranch"); 
        break;
    }
  }         
}
function ComboFill(Data,ComboName)
{
       if (Data[0] == '') return;
       
       var rows = Data.split("*");
       for(a=0; a<rows.length; a++)
   {
      var cols      = rows[a].split("$");
      var option1   = document.createElement("OPTION");
      option1.value = cols[0];
      option1.text  = cols[1];
      document.getElementById(cont_name[0]+ComboName).add(option1);
   }
  
}

function ConfirmOnClick()
{
    if(document.getElementById(cont_name[0]+"rdZone").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlZone").value;
        if(document.getElementById(cont_name[0]+"ddlZone").value==-1)
        {
            alert("Please Select Zone");
            return false;
        }
        
    }
    else if(document.getElementById(cont_name[0]+"rdRegion").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlRegion").value;
        if(document.getElementById(cont_name[0]+"ddlRegion").value==-1)
        {
            alert("Please Select Region");
            return false;
        }
        
    }
    else if(document.getElementById(cont_name[0]+"rdArea").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlArea").value;
        if(document.getElementById(cont_name[0]+"ddlArea").value==-1)
        {
            alert("Please Select Area");
            return false;
        }
        
    }
    else if(document.getElementById(cont_name[0]+"rdState").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlState").value;
        if(document.getElementById(cont_name[0]+"ddlState").value==-1)
        {
            alert("Please Select State");
            return false;
        }
        
    }
    else if(document.getElementById(cont_name[0]+"rdDistrict").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlDistrict").value;
        if(document.getElementById(cont_name[0]+"ddlDistrict").value==-1)
        {
            alert("Please Select District");
            return false;
        }
        
    }
    else if(document.getElementById(cont_name[0]+"rdBranch").checked==true)
    {
        document.getElementById(cont_name[0]+"Hidden2").value=document.getElementById(cont_name[0]+"ddlBranch").value;
        if(document.getElementById(cont_name[0]+"ddlBranch").value==-1)
        {
            alert("Please Select Branch");
            return false;
        }    
    }
    
    if(document.getElementById(cont_name[0]+"ddlHoliday").value==" 15-Aug-1947")
        {
            alert("Please Select Holiday");
            return false;
        }
  
}
function FuncLoadVal()
{
   document.getElementById(cont_name[0]+"Hidden3").value=document.getElementById(cont_name[0]+"ddlHoliday").value; 
}
</script>
 


    <div style="text-align: center">
        <asp:HiddenField ID="Hidden1" runat="server" />
        <asp:HiddenField ID="Hidden2" runat="server" />
        <asp:HiddenField ID="Hidden3" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <table border="1" style="width: 60%">
         <tr>
       <td style="text-align:center" colspan="4">
            <strong><span style="font-size: 16pt">
        Holiday Change </span></strong>
        </td>
        </tr>
            <tr>
                <td style="text-align: justify;" colspan="2">
                    <asp:RadioButton ID="rdZone" runat="server" GroupName="gpHoliday" onclick="CheckZone()" Height="20px" Text="Zone" Width="62px" /></td>
                <td style="width: 20%; text-align: justify;">
                    <asp:Label ID="lblZone" runat="server" Text="Select Zone"></asp:Label></td>
                <td style="width: 20%">
                    <asp:DropDownList ID="ddlZone" runat="server" Width="97%" onchange="FuncDisChange()" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 24px; text-align: justify">
                    <asp:RadioButton ID="rdRegion" runat="server" GroupName="gpHoliday" Text="Region" onclick="CheckRegion()"  /></td> 
                <td style="width: 20%; height: 24px; text-align: justify">
                    <asp:Label ID="lblRegion" runat="server" Text="Select Region"></asp:Label></td>
                <td style="width: 20%; height: 24px">
                    <asp:DropDownList ID="ddlRegion" runat="server" Width="97%" onchange="FuncDisChange()" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 24px; text-align: justify">
                    <asp:RadioButton ID="rdArea" runat="server" GroupName="gpHoliday" onclick="CheckArea()" Height="20px" Text="Area"
                        Width="62px" /></td>
                <td style="width: 20%; height: 24px; text-align: justify">
                    <asp:Label ID="lblArea" runat="server" Text="Select Area"></asp:Label></td>
                <td style="width: 20%; height: 24px">
                    <asp:DropDownList ID="ddlArea" runat="server" Width="97%" onchange="FuncDisChange()"  >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 26px; text-align: justify">
                    <asp:RadioButton ID="rdState" runat="server" GroupName="gpHoliday" onclick="CheckState()" Height="20px"
                        Text="State" Width="62px" /></td>
                <td style="width: 20%; height: 26px; text-align: justify">
                    <asp:Label ID="lblState" runat="server" Text="Select State"></asp:Label></td>
                <td style="width: 20%; height: 26px">
                    <asp:DropDownList ID="ddlState" runat="server" Width="97%" onchange="FuncDisChange()" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: justify">
                    <asp:RadioButton ID="rdDistrict" runat="server" GroupName="gpHoliday" onclick="CheckDistrict()" Height="20px"
                        Text="District" Width="62px" /></td>
                <td style="width: 20%; text-align: justify">
                    <asp:Label ID="lblDistrict" runat="server" Text="Select District"></asp:Label></td>
                <td style="width: 20%">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="97%" onchange="FuncDisChange()" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: justify">
                    <asp:RadioButton ID="rdBranch" runat="server" GroupName="gpHoliday" onclick="CheckBranch()" Height="20px"
                        Text="Branch" Width="62px" /></td>
                <td style="width: 20%; text-align: justify">
                    <asp:Label ID="lblBranch" runat="server" Text="Select Branch"></asp:Label></td>
                <td style="width: 20%">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="97%" onchange="FuncDisChange()" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px">
                    Common Holidays</td>
                <td colspan="2" style="height: 23px">
                    <asp:DropDownList ID="ddlHoliday" runat="server" Width="95%" onchange="FuncLoadVal()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" />
                    <input id="btnExit" style="width: 75px; height: 24px" type="button" value="EXIT" onclick="return btnExit_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 20%">
                </td>
                <td style="width: 1%">
                </td>
                <td style="width: 20%">
                </td>
                <td style="width: 20%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

