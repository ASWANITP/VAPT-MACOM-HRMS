<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="show_err.aspx.vb" Inherits="WebAppHRMS.show_err" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script>
        window.onload = callback;
        function callback() {
            return window_onload();
        }

        //function window_onload() {
        //    debugger;
        //    alert("You are not authorised to view this page");
        //    var baseurl = window.location.origin + "/";
        //    window.open(baseurl + "home.aspx", "_self");
        //}


        function window_onload() {
            debugger;
            alert("You are not authorised to view this page");
            var homeUrl = '<%= ResolveUrl("~/home.aspx") %>';
            window.location.replace(homeUrl);
        }
  
    </script>
</head>
<body bgcolor="antiquewhite">
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
