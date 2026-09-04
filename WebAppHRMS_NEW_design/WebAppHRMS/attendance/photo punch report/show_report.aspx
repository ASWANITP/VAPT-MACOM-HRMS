<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="show_report.aspx.vb"  Inherits="WebAppHRMS.Auction_Listed_pledges_d40b1d3c4410" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Untitled Page</title>
        <script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return winonload()
// ]]>
    </script>
    <script language="javascript" src="https://cdnjs.cloudflare.com/ajax/libs/blob-polyfill/7.0.20220408/Blob.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script language="javascript" type="text/javascript">
    //var contid=contids.split('drop');

function winonload()
{debugger;
//  if (document.getElementById("asp").value==1)
//  {
//      document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><img src='load.gif' alt='Please Wait...' />";
//      ToServer("1$1",1);
//  }
//  if (document.getElementById("asp").value==2)
//  {
//      document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><img src='load.gif' alt='Please Wait...' />";
//      ToServer("1$2",1);
//  }
//  else
//  {
//    if (document.getElementById("asp").value=="")
//    {
document.getElementById("b1").style.display="none"; 
document.getElementById("Button1").style.display="none"; 
         document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><img src='load.gif' alt='Please Wait...' />";
         ToServer("1$1$0$10~10",1);
//    }
//  }
}


function next()
{debugger;
document.getElementById("b1").style.display="none"; 
document.getElementById("Button1").style.display="none"; 
var rnk1=0;
    document.getElementById("Panel2").innerHTML="";
    document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><img src='load.gif' alt='Please Wait...' />";
rnk1=parseInt(document.getElementById("hdnDelData").value.split("%")[2].split("&")[0])+1;
var rnk2=parseInt(document.getElementById("hdnDelData").value.split("%")[2].split("&")[0])+parseInt(document.getElementById("drop_auth").value);
var pageno=parseInt(document.getElementById("hdnDelData").value.split("%")[2].split("&")[1])+1;
ToServer("1$"+pageno+"$"+rnk1+"$"+rnk2+"~"+document.getElementById("drop_auth").value,2);
}


function fill_data()

{debugger;
document.getElementById("b1").style.display="none"; 
document.getElementById("Button1").style.display="none"; 
document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><img src='load.gif' alt='Please Wait...' />";
ToServer("1$1$0$"+document.getElementById("drop_auth").value+"~"+document.getElementById("drop_auth").value,1);
}

function FromServer(arg,context)

{debugger;

if(context == 1)
{
var Data=arg.split("@")

  if(arg=="L")
  {
    document.getElementById("rowDel").style.display='inline'; 
    document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><span style='color:red;'>Session Time Out! Please Login And Try Again</span>";
    document.getElementById("Button1").style.display='none'; 
    document.getElementById("b1").style.display='none'; 
    return false;
  }
  if(arg=="E")
  {
    document.getElementById("rowDel").style.display='inline'; 
    document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><span style='color:red;'>An Error Occured. Inform IT!</span>";
    document.getElementById("Button1").style.display='none'; 
    document.getElementById("b1").style.display='none'; 
    return false;
  }
var Data=arg.split("@")


  document.getElementById("asp").value=Data[1];
            document.getElementById("rowDel").style.display='inline';                 
            document.getElementById("hdnDelData").value=Data[1];
            //document.getElementById("au").innerHTML="<span>"+Data[0].split("^")[0]+"</span>";
            //document.getElementById("fr").innerHTML="<span>"+Data[0].split("^")[1]+"</span>";
            //document.getElementById("too").innerHTML="<span>"+Data[0].split("^")[2]+"</span>";
            document.getElementById("italics").innerHTML="<span>PHOTO PUNCH REPORT OF "+ Data[0].split("^")[0] +" FROM: " + Data[0].split("^")[1] + " TO: "+ Data[0].split("^")[2] +"</span>";
            dispe(); 

}

if(context == 2)
{
  if(arg=="L")
  {
    document.getElementById("rowDel").style.display='inline'; 
    document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><span style='color:red;'>Session Time Out! Please Login And Try Again</span>";
  }
  if(arg=="E")
  {
    document.getElementById("rowDel").style.display='inline'; 
    document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><span style='color:red;'>An Error Occured. Inform IT!</span>";
  }
  var Data=arg.split("@")
document.getElementById("asp").value=Data[1];
            document.getElementById("rowDel").style.display='inline';                 
            document.getElementById("hdnDelData").value=Data[1];
            //document.getElementById("au").innerHTML="<span>"+Data[0].split("^")[0]+"</span>";
            //document.getElementById("fr").innerHTML="<span>"+Data[0].split("^")[1]+"</span>";
            //document.getElementById("too").innerHTML="<span>"+Data[0].split("^")[2]+"</span>";
            document.getElementById("italics").innerHTML="<span>PHOTO PUNCH REPORT OF "+ Data[0].split("^")[0] +" FROM: " + Data[0].split("^")[1] + " TO: "+ Data[0].split("^")[2] +"</span>";
            dispe1(); 
}
}

function dispe()
{
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    st2=document.getElementById("hdnDelData").value.split("!")
    ar=st2.length-1;
    if (ar==0)
    {
      document.getElementById("rowDel").style.display='inline'; 
      document.getElementById("Panel2").innerHTML="<br><br><br><br><br><br><br><br><br><br><span style='color:red;'>No Data Found To Display</span>";
      document.getElementById("Button1").style.display='none'; 
      document.getElementById("b1").style.display='none'; 
      return false;
    }
    if(document.getElementById("hdnDelData").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2] +"</td><td><small>"+st3[3] +"</td><td><small>"+st3[4] +"</td><td><small>"+st3[5] +"</td><td><small>"+st3[6] +"</td><td><small><img src="+st3[7] +" alt='Mphoto' width='100' height='100'/></td><td><small><img src="+st3[8] +" alt='Ephoto' width='100' height='100'/></td><td><small><img src="+st3[9] +" alt='Pphoto' width='100' height='100'/></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr style=' text-align: left; background-color:Silver;height:30px;'><td><small><b>&nbsp;SL.&nbsp;NO.&nbsp;</b></td><td><small><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DAY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;MORNING&nbsp;TIME&nbsp;</b></td><td><small><b>&nbsp;EVENING&nbsp;TIME&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARKS&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;MORNING&nbsp;PHOTO&nbsp;</b></td><td><small><b>&nbsp;EVENING&nbsp;PHOTO&nbsp;</b></td><td><small><b>&nbsp;PROFILE&nbsp;PHOTO&nbsp;</b></td></tr>"
        st1=st+st1+"<tr style=' text-align: CENTER; background-color:Silver;height:20px;'><td colspan='10'><small><b>"+document.getElementById("hdnDelData").value.split("%")[1]+"</b></td></tr></table>" ;
    }
    else
    {  
        st1=st+"</table>";
    }  
    document.getElementById("rowDel").style.display="inline";  
    document.getElementById("Panel2").innerHTML=st1;
        if(document.getElementById("hdnDelData").value.split("%")[1]=="END OF THE REPORT")
        {
        document.getElementById("Button1").style.display="inline";
    document.getElementById("b1").style.display="none"; 
    }
    else
    {
    document.getElementById("b1").style.display="inline"; 
    document.getElementById("Button1").style.display="inline";
    }
}




function dispe1()
{
    var st,st1,st2,st3,ar,ar1,tot;
    var amt=0;
    var days=0;
    st1="";
    st="";
    tot="";
    st2=document.getElementById("hdnDelData").value.split("!")
    ar=st2.length-1;
    if(document.getElementById("hdnDelData").value!="")
    {
        for(k=0;k<ar;k++)
        {
            st3=st2[k].split("*")
            st1=st1+"<tr><td><small>"+st3[0]+"</td><td><small>"+st3[1]+"</td><td><small>"+st3[2] +"</td><td><small>"+st3[3] +"</td><td><small>"+st3[4] +"</td><td><small>"+st3[5] +"</td><td><small>"+st3[6] +"</td><td><small><img src="+st3[7] +" alt='Mphoto' width='100' height='100'/></td><td><small><img src="+st3[8] +" alt='Ephoto' width='100' height='100'/></td><td><small><img src="+st3[9] +" alt='Pphoto' width='100' height='100'/></td></tr>"
        }
        st=st+"<table id='mytable' border='1'  width='600px' ><tr style=' text-align: left; background-color:Silver;height:30px;'><td><small><b>&nbsp;SL.&nbsp;NO.&nbsp;</b></td><td><small><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DAY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;MORNING&nbsp;TIME&nbsp;</b></td><td><small><b>&nbsp;EVENING&nbsp;TIME&nbsp;</b></td><td><small><b>&nbsp;&nbsp;&nbsp;REMARKS&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;MORNING&nbsp;PHOTO&nbsp;</b></td><td><small><b>&nbsp;EVENING&nbsp;PHOTO&nbsp;</b></td><td><small><b>&nbsp;PROFILE&nbsp;PHOTO&nbsp;</b></td></tr>"
        st1=st+st1+"<tr style=' text-align: CENTER; background-color:Silver;height:20px;'><td colspan='10'><small><b>"+document.getElementById("hdnDelData").value.split("%")[1]+"</b></td></tr></table>" ;
    }
    else
    {  
        st1=st+"</table>";
    }    
    document.getElementById("Panel2").innerHTML=st1;
    if(document.getElementById("hdnDelData").value.split("%")[1]=="END OF THE REPORT")
    {
    document.getElementById("b1").style.display="none";  
    document.getElementById("Button1").style.display="inline";
    }
    else
    {
    document.getElementById("b1").style.display="inline"; 
    document.getElementById("Button1").style.display="inline";
    }
}




function quit()
{debugger;
    window.open('punch_report.aspx','_self');
}


function saveLongData() {debugger;
//      var longContent = document.getElementById('Panel2').innerHTML; // Fetch the long content
//      var blob = new Blob([longContent], { type: 'text/html' }); // Create a Blob

//      if (window.navigator && window.navigator.msSaveBlob) { // Check for compatibility
//        window.navigator.msSaveBlob(blob, 'downloaded_data.html'); // Trigger the download
//      } else {
//        console.log('This feature is not supported in your current browser.');
//      }
    var data = document.getElementById('Panel2').innerHTML;

    // Create a Blob from the data
    var blob = new Blob([data], { type: "text/html" });

    // Create a link element
    var link = document.createElement("a");

    // Set the link's href attribute to the Blob object
    link.href = window.URL.createObjectURL(blob);

    // Set the file name
    link.download = "downloaded_data.html"; // Specify the file name with the desired extension

    // Append the link to the body
    document.body.appendChild(link);

    // Trigger the download
    link.click();

    // Remove the link from the body
    //document.body.removeChild(link);
    }
    
    
    
function saveInnerHtml() {debugger;
//            var content = document.getElementById('Panel2').innerHTML;
//            var windowUrl = 'about:blank';
//            var uniqueName = new Date();
//            var windowName = 'Download_' + uniqueName.getTime();
//            var newWindow = window.open(windowUrl, windowName);
//            newWindow.document.write(content);
//            newWindow.document.execCommand('Save', true,windowName+'.html');
//            newWindow.close();


//var content = document.getElementById('Panel2').innerHTML;
//            var ie = new ActiveXObject("WScript.Shell");
//            var fileName = "download.html";
//            var fso = new ActiveXObject("Scripting.FileSystemObject");
//            var file = fso.CreateTextFile(fileName, true);
//            file.Write(content);
//            file.Close();
//            ie.Run(fileName);

        var table = document.getElementById('Panel2'); // id of table
        var tableHTML = table.innerHTML;
        var fileName ="";
        if (document.getElementById("hdnDelData").value.split("%")[1]=="END OF THE REPORT")
           fileName="FINAL PAGE";
        if (document.getElementById("hdnDelData").value.split("%")[1]!="END OF THE REPORT")
           fileName=document.getElementById("hdnDelData").value.split("%")[1].slice(0, 6);

        var msie = window.navigator.userAgent.indexOf("MSIE ");

        // If Internet Explorer
        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
            dummyFrame.document.open('txt/html', 'replace');
            dummyFrame.document.write(tableHTML);
            dummyFrame.document.close();
            dummyFrame.focus();
            return dummyFrame.document.execCommand('SaveAs', true, fileName);
        }
        //other browsers
        else {
            var a = document.createElement('a');
            tableHTML = tableHTML.replace(/  /g, '').replace(/ /g, '%20'); // replaces spaces
            a.href = 'data:application/vnd.ms-excel,' + tableHTML;
            a.setAttribute('download', fileName);
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        }

        }
    </script>
 
</head>


<body style="text-align: center">
    <form id="form1" runat="server">
    
            <table border="3" style="width:100%;  font-family: Courier New; height:100%;">
                <tr>
                    <td colspan="29" style="height: 24px; text-align: center; width :100%; background-color :#ffd700;">
                        <strong><span style=" font-size: 14pt; color :Red ; font-family: Times New Roman;">MANAPPURAM AGRO FARMS LIMITED</span></strong>
                <br>
                        <strong><span style=" font-size: 11pt; color :Red ; font-family: Times New Roman; background:green;color:White;"><i id="italics"></i></span></strong></td>
                </tr>
                <tr>
                    <td  style=" text-align: left; background-color:Silver;height:35px;">
                        <strong> No.of Records Per Sheet :</strong>
                        <asp:DropDownList ID="Drop_auth" Height="22px" runat="server" Width="50px">
                        </asp:DropDownList>  <%-- <asp:Button ID="Button3" BorderStyle="Solid" BorderColor="silver" OnClientClick="go()" Font-Bold="true"  runat="server" Text="Go" />--%></td>    
                </tr>

                <tr id="rowDel">
                    <td colspan="29" style="width:auto;" text-align: center;  background-color :#fff;">
                        
                         <asp:Panel  ScrollBars="Vertical" ID="Panel2" Height="450px" runat="server" >

                         <span id="loasp" style=" font-size: 13pt; color :Red ;"></span>
                    </asp:Panel>
                        </td>
                </tr>
                <tr>
                    <td  style=" text-align: center; background-color:Silver;">
                        <%--<asp:Button ID="Button1" BorderStyle="Solid" BorderColor="silver" OnClientClick="saveInnerHtml()" Font-Bold="true"  runat="server" Text="Download" />--%>
                        <%--<asp:Button ID="b1" BorderStyle="Solid" BorderColor="silver" OnClientClick="next()" Font-Bold="true"  runat="server" Text="Next" />--%>
                        <input id="Button1" onclick="saveInnerHtml()" type="button" style="border-style:solid ; border-color:Silver; font-style:bold;" value="Save" />
                        <input id="b1" onclick="next()" type="button" style="border-style:solid ; border-color:Silver; font-style:bold;" value="Next" />
                         <asp:Button ID="Button2" BorderStyle="Solid" BorderColor="silver" OnClientClick="quit()"  runat="server" Text="Exit" />
                        </td>
                </tr>
        <asp:HiddenField ID="hdnToSendDel" runat="server" />
        <asp:HiddenField ID="hdnDelChange" runat="server" />
        <asp:HiddenField ID="hdnDelData" runat="server" />
        <asp:HiddenField ID="asp" runat="server" />
        <iframe id="dummyFrame" style="display:none"></iframe>
            </table>
 

    </form>
</body>
</html>
