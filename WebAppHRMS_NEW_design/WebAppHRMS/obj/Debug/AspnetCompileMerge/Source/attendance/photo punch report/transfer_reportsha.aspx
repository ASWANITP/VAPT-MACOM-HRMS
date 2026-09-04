<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" ValidateRequest="false" CodeBehind="transfer_reportsha.aspx.vb" Inherits="WebAppHRMS.transferreport_transfer_report_7f7fd11c1873" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
    window.onload = callback;
    function callback() {
        return window_onload();
    }

</script>
  <script language="javascript" type="text/javascript">

function window_onload()
{debugger;
document.getElementById("jio").innerHTML = "<img src='load.gif' alt='gif image' />";
     ToServer(1,1);
     return false;
}

function FromServer(arg,context)
{   debugger;
var args=arg.split('@');
   document.getElementById("jio").innerHTML = args[0]; 
   document.getElementById("jios").innerHTML = args[1]; 
}

function Button1_onclick() 
{debugger;
  document.getElementById("jio").innerHTML = "<img src='load.gif' alt='gif image' />"; 
  var href = document.getElementById("jios").innerText;
  ToServer(href,1); 
}
  function ChangeDiv() {debugger;
            var div = document.getElementById("jio");
            var hdn = document.getElementById("<%=hdnText.ClientID %>");
            hdn.value = div.innerHTML;
			document.getElementById("<%=bt1.ClientID %>").click();
        }
		  function exitcode() {debugger;
            window.open('ajax_punch_report.aspx','_self');
        }
</script>
    <div id="jio" style ="text-align:center;" class="avoid">
    </div>
	    <div id="jios" style ="text-align:center;display:none;" class="avoid">
    </div>
	<asp:HiddenField ID="hdnText" runat="server" />
       <input style="width :0.01px;height:0px;color:#faebd7 ;border-color:#faebd7 ;background-color: #faebd7;float:right;display:none ;" type="button" id="bt1" runat="server" />
</asp:Content>

