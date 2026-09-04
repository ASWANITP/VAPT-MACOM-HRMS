<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="WebAppHRMS.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
   
   
    <script type="text/javascript">	

        function refreshCaptcha() {
            __doPostBack('<%= btnRefreshCaptcha.UniqueID %>', '');
    return false;
        }


    </script>

    <title>Login To Manappuram</title>


    <link href="Assets/Bootstrap/bootstrap-5.2.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Assets/css/custom.css" rel="stylesheet" />
    <link href="Assets/css/login.css" rel="stylesheet" />
    <link href="CSS/Main.css" rel="stylesheet" />
</head>


<body class="loginbg" style="background-color: antiquewhite;">
  <form id="login_form" runat="server" autocomplete="off">
    <section class="bg-light p-2 p-md-2 ">
      <div class="container mt-5">
        <div class="row justify-content-center">
          <div class="col-12 col-sm-10 col-md-6 col-lg-5 col-xl-4">
            <div class="card border-0 shadow rounded bg-light11">
              <!-- Header -->
              <div class="login-header text-center p-1">
                <img src="Assets/Images/logo-dark.png" alt="Icon" class="w-25"  />
                <h3><strong>MACOM HRMS</strong></h3>
              </div>

              <!-- Body -->
              <div class="card-body p-1  bg-opacity-50">
                <div class="form-group form-floating">
                
                    <input type="text" id="id_usd" class="form-control" placeholder="User id" autocomplete="off"  onkeypress="return isNumber(event)"/>
                      <label for="id_usd" >User Id <span class="text-danger">*</span></label>

<%--                  <asp:TextBox CssClass="form-control" ID="id_usd" placeholder="User Id" runat="server" MaxLength="6" TabIndex="1" autocomplete="off" onkeypress="return isNumber(event)"></asp:TextBox>--%>
                </div>

                <div class="form-group position-relative form-floating mt-3">
                  
                      <input type="text" id="id_pwd" readonly class="form-control pw" placeholder="User id" autocomplete="off"  />
                    <label for="id_pwd">Password <span class="text-danger">*</span></label>
<%--                  <asp:TextBox CssClass="form-control txtPass" ID="id_pwd" placeholder="Password" TextMode="Password" runat="server" MaxLength="50" TabIndex="2" autocomplete="off" ></asp:TextBox>--%>
                  <span id="id_passT" class="position-absolute top-50 end-0 translate-middle-y me-2 mt-2" style="cursor:pointer;"> <img src="Assets/Images/hidden.png" id="toggleIcon" width="20" alt="Show/Hide" /> </span>
                </div>

                <div class="form-group d-none">
                  <label for="cmb_firm">Select Firm <span class="text-danger">*</span></label>
                  <asp:DropDownList CssClass="form-control" ID="cmb_firm" runat="server" TabIndex="3"></asp:DropDownList>
                </div>

               <div class="form-group d-flex ">
               <asp:Label ID="lblCaptcha" runat="server" CssClass="h4 captcha-outline "></asp:Label>
               <asp:LinkButton ID="btnRefreshCaptcha" runat="server" 
                               CssClass="btn-ref p-2 text-decoration-none" 
                               OnClick="btnRefreshCaptcha_Click" ToolTip="Refresh Captcha">
                 &#x21bb;
               </asp:LinkButton>
            </div>
                  


                <div class="form-group p-2">
                  <label for="txtCaptcha">Enter Captcha <span class="text-danger">*</span></label>
                  <asp:TextBox CssClass="form-control me-2 " ID="txtCaptcha" runat="server" placeholder="Enter Captcha" TabIndex="4" MaxLength="6"></asp:TextBox>
                </div>
                  
              
                <div class="form-group d-flex justify-content-center p-2 ">
                  <asp:Button CssClass="btn btn-primary btn-block btn-login text-white w-100 shadow-lg btn-outline-dark" ID="cmd_login" runat="server" TabIndex="5" Text="LOGIN" OnClientClick="return validateForm();" />
                </div>
                  
                <div class="text-center mb-2">
                  <a class="text-decoration-none text-white" href="general/change_passwd.aspx">Change Password</a>
                </div>

                <div class="text-center">
                  <asp:Label ID="lbl_err" runat="server" CssClass="text-danger"></asp:Label>
                </div>
              </div>
            </div>

            <!-- Footer -->
            <div class="text-center mt-3">
              <p class="small text-black m-0">
                Designed & Developed by 
                <a href="https://macomsolutions.com/" target="_blank" class="text-black text-decoration-none font-weight-bold">MACOM</a>
              </p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Hidden Fields -->
    <input id="hdn_key" runat="server" type="hidden" />
    <asp:Label ID="lbl_key" runat="server" CssClass="text-danger"></asp:Label>
    <asp:HiddenField ID="hdnMnID" runat="server" />
    <asp:HiddenField ID="hdnBrID" runat="server" />
    <asp:HiddenField ID="hdnBrNm" runat="server" />
    <asp:HiddenField ID="hdnEdata" runat="server" />
    <asp:HiddenField ID="hdnEUser" runat="server" />
    <asp:HiddenField ID="hdnEPass" runat="server" />
    <asp:HiddenField ID="hdnEcapt" runat="server" />
  </form>

  <script>
     
      function validateForm() {
          var userId = document.getElementById("id_usd");
          var password = document.getElementById("id_pwd");
          var captcha = document.getElementById("<%= txtCaptcha.ClientID %>");

          if (userId === '') {
              alert('Please enter User ID');
              return false;
          }

          if (password === '') {
              alert('Please enter Password');
              return false;
          }

          if (captcha === '') {
              alert('Please enter Captcha');
              return false;
          }

          return true;
      }

      function isNumber(evt) {
          var charCode = evt.which ? evt.which : evt.keyCode;
          if (charCode < 48 || charCode > 57) {
              return false;
          }
          return true;
      }


  </script>
</body>
</html>





