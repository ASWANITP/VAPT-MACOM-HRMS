<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebAppHRMS._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

  <title></title>

 <%--<link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.15/css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.15/js/jquery.Jcrop.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.15/js/jquery.Jcrop.js"></script>--%>


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.15/css/jquery.Jcrop.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-jcrop/0.9.15/js/jquery.Jcrop.min.js"></script>

<%--<script type="text/javascript">

  jQuery(document).ready(function() {

    jQuery('#imgCrop').Jcrop({

      onSelect: storeCoords

    });

  });

 

  function storeCoords(c) {

    jQuery('#X').val(c.x);

    jQuery('#Y').val(c.y);

    jQuery('#W').val(c.w);

    jQuery('#H').val(c.h);

  };

 

</script>--%>
    <script type="text/javascript">
        $(window).on('load', function () {
            var $img = $("[id$='imgCrop']");

            if ($img.length > 0 && $img.attr('src')) {
                $img.Jcrop({
                    onSelect: storeCoords
                });
            }
        });

        function storeCoords(c) {
            $("[id$='X']").val(c.x);
            $("[id$='Y']").val(c.y);
            $("[id$='W']").val(c.w);
            $("[id$='H']").val(c.h);
        }
</script>
<script>
function Button2_onclick()
{
window.open("../home.aspx","_self")
}
</script>
    
<style type="text/css">
        table{
            margin:0 auto;
            border:unset;
        }
    
</style>
</head>

<body>

  <form id="form1" runat="server">

  <div style="text-align:center;">
  <table border="1" style="width: 656px; height: 72px">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">
EMPLOYEE ID-CARD CREATION</span></strong></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 24px">
                   <span style="font-size: 11pt; font-family: Courier New">SELECT EMPLOYEE : </span> <asp:DropDownList ID="mydrop" runat="server" AutoPostBack="true" Width="300px" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 100%; height: 7px; text-align: center">
                 <asp:Panel ID="mypanel" runat="server">
                    <span style="font-size: 11pt; font-family: Courier New">BROWSE FOR IMAGE : </span>
                    <asp:FileUpload ID="Upload" runat="server" />
                          <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />

      <asp:Label foreColor="red" ID="lblError" runat="server" Visible="false" />
      </asp:Panel>
                    </td>
            </tr>
                        <tr>

                <td colspan="4" style="width: 100%; height: 7px; text-align: center">
                        <asp:Panel ID="pnlCrop" runat="server" Visible="false">
<asp:Label foreColor="blue" ID="Label1" runat="server" Font-Underline ="true" text="Image Preview" />
      <asp:Image ID="imgCrop" runat="server" />

      <br />

      <asp:HiddenField ID="X" runat="server" />

      <asp:HiddenField ID="Y" runat="server" />

      <asp:HiddenField ID="W" runat="server" />

      <asp:HiddenField ID="H" runat="server" />

      <asp:Button ID="btnCrop" runat="server" Text="Crop" OnClick="btnCrop_Click" />

    </asp:Panel>
        <asp:Panel ID="pnlCropped" runat="server" Visible="false">
<asp:Label foreColor="blue" ID="Label2" runat="server" Font-Underline ="true" text="Image Preview" /><br />
      <asp:Image ID="imgCropped" runat="server" /><br /><br />
<asp:Button id="retry" Text="Try Again" runat="server" />
    </asp:Panel>
                    </td>
            </tr>
            <tr>

                <td colspan="4" style="width: 100%; height: 7px; text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="GENERATE" Width="86px"  OnClientClick="return check_con()" Height="29px"/>
                    <input id="Button2" style="width: 79px; height: 29px;" type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>

  </div>

  </form>
</body>
</html>
