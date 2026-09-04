<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="PunchingList.aspx.vb" Inherits="WebAppHRMS.HRM_PunchingList_c0bdebd64254" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <script language="javascript" type="text/javascript">
function PunchingPage(EmpCode)
{
   //window.open('HRMTraining_AttendancePunching.aspx?&EmpCode='+ EmpCode +'','_self');
   window.open('HRMTraining_AttendancePunching.aspx?&EmpCode='+ EmpCode +'','open_window','width=600, height=600,toolbar=no,location=no,directories=no,status=no,menubar=no, scrollbars=no,resizable=yes,copyhistory=no');
}
//function AbsenteePage(EmpCode,TrainId)
//{   
//   window.open('AbsenteeCheck.aspx?&EmpCode='+ EmpCode +'&TrainId='+ TrainId +'','open_window','width=600, height=400');
//}
function AbsenteePage(EmpCode,TrainId)
{     

     var Flag=confirm("Are You Sure to Confirm");
     if (Flag==true)
      {
        data=EmpCode+"%"+TrainId+"%"+111;
        document.getElementById("hid_value").value=TrainId;
        ToServer(data+"#"+1,1);        
      }
     if (Flag==false)
      {
       document.getElementById("hid_value").value=TrainId;
       window.open("PunchingList.aspx?TrainId="+document.getElementById("hid_value").value+"","_self");
       return false;
      }   
}
function btnExit_onclick() 
{
    window.open("../home.aspx","_self")
}
function FromServer (arg,context) 
{ 
 //debugger;
 var Data=arg.split("@")
 switch (context)
 { 
    case 1:
          alert(arg) ;
          window.open("PunchingList.aspx?TrainId="+document.getElementById("hid_value").value+"","_self");
          break; 
  }      
}

    </script>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Height="53px" Width="100%">
            </asp:Panel>
            <input id="hid_value" type="hidden" />&nbsp;<br />
            <input id="btnExit" onclick="return btnExit_onclick()" style="width: 67px; cursor: hand; font-family: 'Courier New'"
                type="button" value="Exit" />

        </div>
    </form>
</body>
</html>
