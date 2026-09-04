<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="EmpAddressEdit.aspx.vb" Inherits="WebAppHRMS.test_EmpAddressEdit_bc3b5c8c2679" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Address Edit Form</title>
<script language="javascript" type="text/javascript">
function cmdExit_onclick() 
{
   window.close();
}
function call_receiver(arg1)
{ //debugger;
  var arg2,Alldat,Dat1,StateDat,PermDisDat,PermPinDat,PreDisDat,PrePinDat,SplitDat1,perAllDat,PerDisDa,PerPoDat;
  arg2 = arg1.split("^");
  if(arg2[0]==11)
  {    
    if(arg2[1]=="N")
    {
       alert('There is No Data Found..!! Please Check..!!');       
       document.getElementById("hidEmpCode").value          = 0;       
       document.getElementById("hidPermState").value        = 0;  
       document.getElementById("hidPermDistrict").value     = 0;  
       document.getElementById("hidPermPin").value          = 0;  
       document.getElementById("hidPreState").value         = 0;  
       document.getElementById("hidPreDistrict").value      = 0;  
       document.getElementById("hidPrePin").value           = 0;   
    }        
    else
    {
       Alldat        = arg2[1].split("$"); 
       Dat1          = Alldat[0];
       StateDat      = Alldat[1];
       PermDisDat    = Alldat[2];
       PermPinDat    = Alldat[3];
       PreDisDat     = Alldat[4]; 
       PrePinDat     = Alldat[5];     
       SplitDat1 = Dat1.split("~");       
       document.getElementById("txtPermHouse").value       = SplitDat1[0];
       document.getElementById("txtPresHouse").value       = SplitDat1[5];
       document.getElementById("txtPermPin").value         = SplitDat1[4];
       document.getElementById("txtPresPin").value         = SplitDat1[9];            
       //-=-=-=-=-=-=-=-=-=-=-=- Combo State =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       document.getElementById("cmbPermState").options.length = 0;       
       var rows = StateDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPermState").add(option1);                           
       }
        document.getElementById("cmbPermState").value = SplitDat1[3];        
        document.getElementById("hidPermState").value = SplitDat1[3];        
        //-=-=-=-=-=-=-=-=-=-=-=- Combo Present State =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//       
       document.getElementById("cmbPresState").options.length = 0;
       var rows = StateDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];          
          document.getElementById("cmbPresState").add(option1);                 
       }        
       document.getElementById("cmbPresState").value = SplitDat1[8];        
       document.getElementById("hidPreState").value  = SplitDat1[8]; 
       //-=-=-=-=-=-=-=-=-=-=-=- Combo Perm District =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       document.getElementById("cmbPermDistrict").options.length = 0;
       rows = PermDisDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPermDistrict").add(option1);                   
       }
        document.getElementById("cmbPermDistrict").value = SplitDat1[2];
        document.getElementById("hidPermDistrict").value = SplitDat1[2]; 
       //-==-=-=-==-==-=-=-=--=-==-=-=-=--=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-//
        //-=-=-=-=-=-=-=-=-=-=-=- Combo Perm Post =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       document.getElementById("cmbPermPost").options.length = 0;
       rows = PermPinDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPermPost").add(option1);                   
       }
        document.getElementById("cmbPermPost").value   = SplitDat1[1];
        document.getElementById("hidPermPin").value    = SplitDat1[1]; 
       //-==-=-=-==-==-=-=-=--=-==-=-=-=--=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-//
       //-=-=-=-=-=-=-=-=-=-=-=- Combo Pres District =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       document.getElementById("cmbPresDistrict").options.length = 0;
       rows = PreDisDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresDistrict").add(option1);                   
       }
       document.getElementById("cmbPresDistrict").value = SplitDat1[7];
       document.getElementById("hidPreDistrict").value  = SplitDat1[7]; 
       //-==-=-=-==-==-=-=-=--=-==-=-=-=--=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-//
       //-=-=-=-=-=-=-=-=-=-=-=- Combo Pres Post =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       document.getElementById("cmbPresPost").options.length = 0;
       rows = PrePinDat.split("%");       
       var len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresPost").add(option1);                   
       }
        document.getElementById("cmbPresPost").value    = SplitDat1[6];
        document.getElementById("hidPrePin").value      = SplitDat1[6]; 
       //-==-=-=-==-==-=-=-=--=-==-=-=-=--=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-//
    } 
  }
  if (arg2[0] == 12)
  {
      //-=-=-=-=-=-=-=-=-=-=-=- Combo Perm District =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       perAllDat = arg2[1].split("$"); 
       PerDisDa  = perAllDat[0];
       PerPoDat  = perAllDat[1];
       document.getElementById("txtPermPin").value = perAllDat[2];
       document.getElementById("cmbPermDistrict").options.length = 0;
       rows = PerDisDa.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPermDistrict").add(option1); 
          if(i==0)
          {
             document.getElementById("hidPermDistrict").value = cols[0];
          }                  
       }     
       //-=-==-=-=-=-=-=-=-=-=
       document.getElementById("cmbPermPost").options.length = 0;
       rows = PerPoDat.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPermPost").add(option1); 
          if(i==0)
          {
             document.getElementById("hidPermPin").value = cols[0];
          }                  
       } 
  }
  if (arg2[0] == 13)
  {
     perAllDat = arg2[1].split("$");      
     PerPoDat  = perAllDat[0];
     document.getElementById("txtPermPin").value = perAllDat[1];
     document.getElementById("cmbPermPost").options.length = 0;
     rows = PerPoDat.split("%");       
     len  = rows.length - 1;
     for(i = 0;i < len; i++)
     {
        var cols      = rows[i].split("�");
        var option1   = document.createElement("OPTION");          
        option1.value = cols[0];
        option1.text  = cols[1];
        document.getElementById("cmbPermPost").add(option1); 
        if(i==0)
        {
           document.getElementById("hidPermPin").value = cols[0];
        }                  
     } 
  }   //if (arg2[0] == 13)
  if (arg2[0] == 14)
  {
     document.getElementById("txtPermPin").value = arg2[1];
  }
  if (arg2[0] == 15)
  {
      //-=-=-=-=-=-=-=-=-=-=-=- Combo Present District =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       perAllDat = arg2[1].split("$"); 
       PerDisDa  = perAllDat[0];
       PerPoDat  = perAllDat[1];
       document.getElementById("txtPresPin").value = perAllDat[2];
       document.getElementById("cmbPresDistrict").options.length = 0;
       rows = PerDisDa.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresDistrict").add(option1); 
          if(i==0)
          {
             document.getElementById("hidPreDistrict").value = cols[0];
          }                  
       }     
       //-=-==-=-=-=-=-=-=-=-=
       document.getElementById("cmbPresPost").options.length = 0;
       rows = PerPoDat.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresPost").add(option1); 
          if(i==0)
          {
             document.getElementById("hidPrePin").value = cols[0];
          }                  
       } 
  }
  if (arg2[0] == 16)
  {
     perAllDat = arg2[1].split("$");      
     PerPoDat  = perAllDat[0];
     document.getElementById("txtPresPin").value = perAllDat[1];
     document.getElementById("cmbPresPost").options.length = 0;
     rows = PerPoDat.split("%");       
     len  = rows.length - 1;
     for(i = 0;i < len; i++)
     {
        var cols      = rows[i].split("�");
        var option1   = document.createElement("OPTION");          
        option1.value = cols[0];
        option1.text  = cols[1];
        document.getElementById("cmbPresPost").add(option1); 
        if(i==0)
        {
           document.getElementById("hidPrePin").value = cols[0];
        }                  
     } 
  }
  if (arg2[0] == 17)
  {
     document.getElementById("txtPresPin").value = arg2[1];
  }
  if (arg2[0] == 18)
  {//debugger;
      //-=-=-=-=-=-=-=-=-=-=-=- Combo Present District =-=-=-=-=-=-=-=-=-=-=-=-=-=-=//
       perAllDat = arg2[1].split("$"); 
       PerDisDa  = perAllDat[0];
       PerPoDat  = perAllDat[1];       
       document.getElementById("cmbPresDistrict").options.length = 0;
       rows = PerDisDa.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresDistrict").add(option1);                    
       }
       document.getElementById("cmbPresDistrict").value = document.getElementById("hidPermDistrict").value;
       document.getElementById("hidPreDistrict").value  = document.getElementById("hidPermDistrict").value;    
       //-=-==-=-=-=-=-=-=-=-=
       document.getElementById("cmbPresPost").options.length = 0;
       rows = PerPoDat.split("%");       
       len  = rows.length - 1;
       for(i = 0;i < len; i++)
       {
          var cols      = rows[i].split("�");
          var option1   = document.createElement("OPTION");          
          option1.value = cols[0];
          option1.text  = cols[1];
          document.getElementById("cmbPresPost").add(option1);         
       }       
       document.getElementById("hidPrePin").value   = document.getElementById("hidPermPin").value;
       document.getElementById("cmbPresPost").value = document.getElementById("hidPermPin").value;        
  }  
}
function PermStateChange()
{
   document.getElementById("hidPermState").value = document.getElementById("cmbPermState").value;
   call_server("2$"+document.getElementById("hidPermState").value);
}
function PermDistChange()
{
   document.getElementById("hidPermDistrict").value = document.getElementById("cmbPermDistrict").value;
   call_server("3$"+document.getElementById("hidPermDistrict").value);
}
function PermPostChange()
{
   document.getElementById("hidPermPin").value = document.getElementById("cmbPermPost").value;
   call_server("4$"+document.getElementById("hidPermPin").value);
}
function PresStateChange()
{
   document.getElementById("hidPreState").value = document.getElementById("cmbPresState").value;
   call_server("5$"+document.getElementById("hidPreState").value);
}
function PresDisChange()
{
   document.getElementById("hidPreDistrict").value = document.getElementById("cmbPresDistrict").value;
   call_server("6$"+document.getElementById("hidPreDistrict").value);
}
function PrePostChange()
{
   document.getElementById("hidPrePin").value = document.getElementById("cmbPresPost").value;
   call_server("7$"+document.getElementById("hidPrePin").value);
}
function AddSameClick()
{
   if(document.getElementById("chkAddressSame").checked == true)
   {
      document.getElementById("txtPresHouse").value    = document.getElementById("txtPermHouse").value;
      document.getElementById("hidPreState").value     = document.getElementById("hidPermState").value;
      document.getElementById("cmbPresState").value    = document.getElementById("hidPermState").value;
      document.getElementById("txtPresPin").value      = document.getElementById("txtPermPin").value;
      call_server("8$"+document.getElementById("hidPermState").value+"$"+document.getElementById("hidPermDistrict").value+"$"+document.getElementById("hidPermPin").value);
   }
}
function CheckClient()
{
   if(document.getElementById("txtPermHouse").value =="")
   {
      alert('Please Enter Permanant Address House Name..!!');
      document.getElementById("txtPermHouse").focus();
      return false;
   }
   if(document.getElementById("txtPresHouse").value =="")
   {
      alert('Please Enter Present Address House Name..!!');
      document.getElementById("txtPresHouse").focus();
      return false;
   }
   if(document.getElementById("hidEmpCode").value =="")
   {
      alert('EmployeeCode Missing..Cannot do Updation.. Please retake all forms..!!');      
      return false;
   }
   if(document.getElementById("hidPermState").value =="" || document.getElementById("hidPermState").value ==0)
   {
      alert('Permanant State Missing..Cannot do Updation.. Select Correct Permanant State..!!');      
      return false;
   }
   if(document.getElementById("hidPermDistrict").value =="" || document.getElementById("hidPermDistrict").value ==0)
   {
      alert('Permanant District Missing..Cannot do Updation.. Select Correct Permanant District..!!');      
      return false;
   }
   if(document.getElementById("hidPermPin").value =="" || document.getElementById("hidPermPin").value ==0)
   {
      alert('Permanant Post Missing..Cannot do Updation.. Select Correct Permanant Post Office..!!');      
      return false;
   }
   if(document.getElementById("hidPreState").value =="" || document.getElementById("hidPreState").value ==0)
   {
      alert('Present State Missing..Cannot do Updation.. Select Correct present State..!!');      
      return false;
   }
   if(document.getElementById("hidPreDistrict").value =="" || document.getElementById("hidPreDistrict").value ==0)
   {
      alert('Present District Missing..Cannot do Updation.. Select Correct Present District..!!');      
      return false;
   }
   if(document.getElementById("hidPrePin").value =="" || document.getElementById("hidPrePin").value ==0)
   {
      alert('Present Post Missing..Cannot do Updation.. Select Correct Present Post Office..!!');      
      return false;
   }
}
function init()
{   
   if(document.getElementById("hidEmpCode").value != 0)
   {
      call_server("1$"+document.getElementById("hidEmpCode").value);
   }
}
window.onload=init;
function cmdConfirm_onclick() 
{
   if(document.getElementById("txtPermHouse").value != "" && document.getElementById("txtPresHouse").value != "")
   {        
      opener.document.forms[0].ctl00_cph_edp_txtPermHouse.value            = document.getElementById("txtPermHouse").value;
      opener.document.forms[0].ctl00_cph_edp_txtPresHouse.value            = document.getElementById("txtPresHouse").value;
      opener.document.forms[0].ctl00_cph_edp_txtPermDistrict.value         = document.getElementById("cmbPermDistrict").options[document.getElementById("cmbPermDistrict").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPresDistrict.value         = document.getElementById("cmbPresDistrict").options[document.getElementById("cmbPresDistrict").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPermState.value            = document.getElementById("cmbPermState").options[document.getElementById("cmbPermState").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPresState.value            = document.getElementById("cmbPresState").options[document.getElementById("cmbPresState").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPermPost.value             = document.getElementById("cmbPermPost").options[document.getElementById("cmbPermPost").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPresPost.value             = document.getElementById("cmbPresPost").options[document.getElementById("cmbPresPost").selectedIndex].text;
      opener.document.forms[0].ctl00_cph_edp_txtPermPin.value              = document.getElementById("txtPermPin").value;
      opener.document.forms[0].ctl00_cph_edp_txtPresPin.value              = document.getElementById("txtPresPin").value;
      opener.document.forms[0].ctl00_cph_edp_hidNewPermSrNumber.value      = document.getElementById("cmbPermPost").value;
      opener.document.forms[0].ctl00_cph_edp_hidNewPresSrNumber.value      = document.getElementById("cmbPresPost").value;
      opener.document.forms[0].action = "editempaddresshrm.aspx";
      //window.opener.fReject(0);
      window.close("EmpAddressEdit.aspx");        
      return true; 
   }
   else
   {
      alert("Please Enter all Data Required..Some fields are missing Data..!!")
      return false;
   }  
}
function IsCharacterextent(a)
{ 
  strString = document.getElementById(a).value;
  //var strValidChars = "0123456789.";   //"0123456789.-";
  var strValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-/.,# ";  ///  0123456789 also der..!!
  var strChar;
  var blnResult = true;
  if (strString.length == 0) return false;
     // test strString consists of valid characters listed above
  for (i = 0; i < strString.length && blnResult == true; i++)
  {
    strChar = strString.charAt(i);
    if (strValidChars.indexOf(strChar) == -1)
    {
      blnResult = false;
      document.getElementById(a).value="";
      alert("Please Enter Characters only..!");
    }
  }
  return blnResult;
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>            
            <table border="1" style="width: 52%; text-transform: capitalize; font-family: 'Bookman Old Style';">
                <tr>
                    <td colspan="2" style="height: 10px; text-align: center">
                        Permanant Address</td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left;">
                        &nbsp;Permanant House Name</td>
                    <td style="width: 40%; text-align: left;">
                        <asp:TextBox ID="txtPermHouse" onkeyup="IsCharacterextent('txtPermHouse')" runat="server" Style="text-transform: uppercase; font-family: 'Bookman Old Style'"
                            Width="237px" MaxLength="45"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;State</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPermState" onchange="PermStateChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;District</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPermDistrict" onchange="PermDistChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;Post Office</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPermPost" onchange="PermPostChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;P.I.N Code</td>
                    <td style="width: 40%; text-align: left">
                        <asp:TextBox ID="txtPermPin" runat="server" ReadOnly="True" Style="text-transform: uppercase;
                            font-family: 'Bookman Old Style'; text-align: center" Width="237px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        Present Address</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:CheckBox ID="chkAddressSame" onclick="AddSameClick()" runat="server" Style="cursor: hand" Text=" Present Address Same as Permanant Address"
                            Width="402px" /></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;Present House Name</td>
                    <td style="width: 40%; text-align: left">
                        <asp:TextBox ID="txtPresHouse" onkeyup="IsCharacterextent('txtPresHouse')" runat="server" Style="text-transform: uppercase; font-family: 'Bookman Old Style'"
                            Width="237px" MaxLength="45"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;State</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPresState" onchange="PresStateChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;District</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPresDistrict" onchange="PresDisChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;Post Office</td>
                    <td style="width: 40%; text-align: left">
                        <asp:DropDownList ID="cmbPresPost" onchange="PrePostChange()" runat="server" Style="text-transform: uppercase;
                            cursor: hand; font-family: 'Bookman Old Style'" Width="242px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: left">
                        &nbsp;P.I.N Code</td>
                    <td style="width: 40%; text-align: left">
                        <asp:TextBox ID="txtPresPin" runat="server" ReadOnly="True" Style="text-transform: uppercase;
                            font-family: 'Bookman Old Style'; text-align: center" Width="237px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 40%; text-align: right">
                        <input id="cmdConfirm" style="cursor: hand; font-family: 'Bookman Old Style'" type="button"
                            value="Confirm" onclick="return cmdConfirm_onclick()" /></td>
                    <td style="width: 40%; text-align: left">
                        <input id="cmdExit" style="cursor: hand; font-family: 'Bookman Old Style'; width: 82px;" type="button"
                            value="Exit" onclick="return cmdExit_onclick()" /></td>
                </tr>
            </table>
            <input id="hidEmpCode" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPermState" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPermDistrict" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPermPin" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPreState" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPreDistrict" runat="server" style="width: 5px" type="hidden" />
            <input id="hidPrePin" runat="server" style="width: 5px" type="hidden" /></div>
    
    </div>
    </form>
</body>
</html>
