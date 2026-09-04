<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="WebAppHRMS.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script type="text/javascript">	


        String.prototype.lpad = function (num, cpad) {
            var i;
            var a = this.split('');
            for (i = 0; i < num - this.length; i++) {
                a.unshift(cpad)
            }
            return a.join('')
        }
        function show() {
            showtime();
        }


        function showtime() {
            var dt, t
            dt = new Date()
            var a_p = ""
            var curr_hour = dt.getHours()
            if (curr_hour < 12) {
                a_p = "AM"
            }
            else {
                a_p = "PM"
            }
            if (curr_hour == 0) {
                curr_hour = 12
            }
            if (curr_hour > 12) {
                curr_hour = curr_hour - 12
            }
            t = "<align=center><STRONG>" + curr_hour.toString().lpad(2, '0') + ":" + dt.getMinutes().toString().lpad(2, '0') + ":" + dt.getSeconds().toString().lpad(2, '0') + ":" + a_p + "</STRONG>"
            window.setTimeout("showtime()", 60000)
            document.getElementById("ctl00_lbl_time").innerHTML = t
        }

        function togglePassword() {
            var passwordField = document.getElementById('<%= txt_password.ClientID %>');
            var toggleIcon = document.getElementById("toggleIcon");

            if (passwordField.type === "password") {
                passwordField.type = "text";
                toggleIcon.src = "Assets/Images/eye.png"; 
            } else {
                passwordField.type = "password";
                toggleIcon.src = "Assets/Images/hidden.png"; 
            }
        }

    </script>

    <title>Login To Manappuram</title>
    <link href="Assets/Bootstrap/bootstrap-5.2.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Assets/css/custom.css" rel="stylesheet" />
    <link href="Assets/css/login.css" rel="stylesheet" />
    <style type="text/css">
        body, html {
            height: 100%;
            margin: 0;
            font-family: Poppins;
        }

        .loginbg {
            background-color: #C3D9EF;
        }

        .opacity {
            background-color: rgb(63 79 87 / 79%) !important;
        }

        .btn-primary {
            background-color: rgb(37 82 120) !important;
            border: 2px solid #fff;
            font-weight: 600;
        }

            .btn-primary:hover {
                background-color: rgb(68 134 190) !important;
                border: 2px solid #fff;
            }

        .text-bg-primary {
            background-color: rgb(51,81, 106,0.8) !important;
        }

        a {
            color: #fff;
            text-decoration: none;
        }

            a:hover {
                color: #fff;
                text-decoration: underline;
            }

        .login-header {
            padding: 30px 0 0 0;
            color: #fff;
        }
    </style>
</head>
<body bgcolor="antiquewhite" class="loginbg">
    <form id="login_form" runat="server">
        <section class="bg-light p-3 p-md-4 p-xl-5">
            <div class="container mt-large">
                <div class="row justify-content-center">
                    <div class="col-12 col-md-9 col-lg-4 col-xl-12 col-xxl-12">
                        <div class="card border border-light-subtle rounded-4 opacity" style="border-radius: 12px;">
                            <div class="login-header text-center">
                                <img src="Assets/Images/logo/mlogo.png" alt="Icon" style="vertical-align: middle; margin-right: 8px; width: 70px; height: auto;" />
                                <h3><strong>MACOM  HRMS</strong></h3>
                            </div>
                            <div class="card-body p-2 p-md-4 p-xl-5">
                                <div class="row">
                                    <div class="row gy-2 overflow-hidden">
                                        <div class="col-12">
                                            <div class="form-floating mb-3">
                                                <asp:TextBox CssClass="form-control" ID="txt_user_id" placeholder="User Id" runat="server" MaxLength="6" onkeypress="return validNumber()" TabIndex="1"></asp:TextBox>
                                                <label for="email" class="form-label">User Id <span style="color: #ff0000">*</span></label>
                                            </div>
                                        </div>
                                       
                                        <div class="col-12">
                                            <div class="form-floating mb-3 position-relative">
                                                <asp:TextBox ID="txt_password" CssClass="form-control" placeholder="Password" runat="server" MaxLength="12" onkeypress="return validText()" TabIndex="2" TextMode="Password"></asp:TextBox>
                                                <label for="password" class="form-label">Password<span style="color: #ff0000">*</span></label>
                                                <span class="position-absolute end-0 top-50 translate-middle-y me-3" style="cursor: pointer;" onclick="togglePassword()">
                                                    <img src="Assets/Images/hidden.png" id="toggleIcon" alt="Show Password" width="20px"/>
                                                </span>
                                            </div>
                                        </div>

                                        <div class="col-12" style="display: none">
                                            <div class="form-floating mb-3">
                                                <asp:DropDownList ID="cmb_firm" CssClass="form-select" runat="server" TabIndex="3" placeholder="Select Firm">
                                                </asp:DropDownList>
                                                <label for="floatingSelect">Select Firm<span style="color: #ff0000">*</span></label>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-grid">
                                                <asp:Button CssClass="btn bsb-btn-xl btn-primary" ID="cmd_login" runat="server" TabIndex="4" Text="LOGIN" OnClientClick="return login()" />
                                            </div>
                                        </div>
                                        <div class="col-12" style="padding-top: 0px!important; margin-top: 0px!important;">
                                            <div class="d-grid text-center">
                                                <a href="general/change_passwd.aspx">Change Password</a>
                                            </div>
                                        </div>
                                        <div class="col-12" style="padding-top: 0px!important; margin-top: 0px!important;">
                                            <div class="d-grid text-center">
                                                <asp:Label ID="lbl_err" runat="server" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="d-grid">
                                <p class="text-center log-footer" style="font-size: 0.8rem; color: midnightblue">
                                    <%--Manappuram e Business Suite ver 1.0--%>
                                    <br />
                                    Designed & Developed by <a href="https://macomsolutions.com/" target="_blank" style="color: midnightblue"><strong>MACOM</strong></a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <input id="hdn_key" runat="server" style="width: 1px" type="hidden" />
        <asp:Label ID="lbl_key" runat="server" ForeColor="Red"></asp:Label>
        <asp:HiddenField ID="hdnMnID" runat="server" />
        <asp:HiddenField ID="hdnBrID" runat="server" />
        <asp:HiddenField ID="hdnBrNm" runat="server" />
    </form>
</body>
</html>

