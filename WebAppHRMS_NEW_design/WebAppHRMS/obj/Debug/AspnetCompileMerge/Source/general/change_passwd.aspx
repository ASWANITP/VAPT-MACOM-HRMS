<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="change_passwd.aspx.vb" Inherits="WebAppHRMS.change_passwding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Manappuram Change Password</title>
    <link href="../Assets/Bootstrap/bootstrap-5.2.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/css/custom.css" rel="stylesheet" />
    <link href="../Assets/css/login.css" rel="stylesheet" />
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
            color: #fff;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var txt = "cph_edp_";
        function correct(a) {
            var charcode = (event.which) ? event.which : event.keyCode
            var v;
            v = document.getElementById(a).value;
            if (isNaN(v)) {
                document.getElementById(a).value = "";
                document.getElementById(a).focus();
            }
            else {
                if (charcode == 32) {
                    document.getElementById(a).value = "";
                    document.getElementById(a).focus();
                }
            }
        }
        function dhanya() {
            if (document.getElementById("txt_user").value != "") {
                var aa;
                aa = document.getElementById("txt_user").value + "#222";
                rcpt_call_server(aa, 1);
            }
        }
        function arun() {
            if (document.getElementById("txt_oldpass").value != "") {
                var aa;
                aa = document.getElementById("txt_user").value + "|" + document.getElementById("txt_oldpass").value + "#333";
                rcpt_call_server(aa, 1);
            }

        }
        function arun1() {
            debugger;

            if (document.getElementById("txt_newpass").value != "") {
                if (document.getElementById("txt_newpass").value != document.getElementById("txt_oldpass").value) {
                    var len;
                    len = document.getElementById("txt_newpass").value.length;
                    if (len >= 8) {
                        alert("Please Re enter Your Password for confirmation");
                        document.getElementById("txt_confpass").focus();

                    }
                    else {
                        alert("Password Requires More than 8 Charecters");
                        document.getElementById("txt_newpass").value = "";
                        document.getElementById("txt_confpass").value = "";
                        document.getElementById("txt_newpass").focus();
                    }
                }
                else {
                    alert("Your Current password and New Password cannot be equal")
                    document.getElementById("txt_newpass").value = "";
                    document.getElementById("txt_newpass").focus();
                }
            }
            else {
                alert("Enter Your New Password1");
            }
        }
        function arun2() {
            debugger;
            if (document.getElementById("txt_confpass").value != "") {
                if (document.getElementById("txt_newpass").value != document.getElementById("txt_confpass").value) {
                    alert("Password Does not Match.......Pls Enter Once More");
                    document.getElementById("txt_newpass").value = "";
                    document.getElementById("txt_confpass").value = "";
                    document.getElementById("txt_newpass").focus();
                }
            }
            else {
                alert("Enter Your New Password Agian2");
            }
        }
        function rcpt_receiver(arg1, arg2) {

            var str, str5

            str5 = arg1.split("#")
            if (str5[1] == "1") {
                document.getElementById("txt_oldpass").focus()
            }
            else if (str5[1] == "9991") {
                alert("This employee not belongs to MANAPPURAM");
                document.getElementById("txt_user").value = "";
                document.getElementById("txt_user").focus();
            }
            else if (str5[1] == "2") {
                document.getElementById("txt_newpass").focus();
            }
            else if (str5[1] == "9992") {
                alert("Enter Your Current Password Correctly");
                document.getElementById("txt_oldpass").value = "";
                document.getElementById("txt_oldpass").focus();
            }
        }

        function validText() {
            var charcode = (event.which) ? event.which : event.keyCode
            if (charcode == 63) {
                alert("Invalid character!")
                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
        }
        function togglePassword(fieldId, iconId) {
            var passwordField = document.getElementById(fieldId);
            var toggleIcon = document.getElementById(iconId);

            if (passwordField.type === "password") {
                passwordField.type = "text";
                toggleIcon.src = "../Assets/Images/eye.png";
            } else {
                passwordField.type = "password";
                toggleIcon.src = "../Assets/Images/hidden.png";
            }
        }


    </script>

</head>
<body bgcolor="antiquewhite" class="loginbg">
    <form id="form1" runat="server">
        <section class="bg-light p-3 p-md-4 p-xl-5">
            <div class="container" style="padding-top: 60px;">
                <div class="row justify-content-center">
                    <div class="col-12 col-md-9 col-lg-4 col-xl-12 col-xxl-12">
                        <div class="card border border-light-subtle rounded-4 opacity" style="border-radius: 12px;">
                            <div class="card-body p-3 p-md-4 p-xl-5">
                                <div class="row">
                                    <div class="row gy-2 overflow-hidden">
                                        <div class="col-12">
                                            <div class="form-floating mb-3">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </div>
                                        </div>
                                        <div class="col-12">

                                            <div class="login-header text-center">
                                                <h5><strong>CHANGE PASSWORD</strong></h5>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txt_user" CssClass="form-control" onkeyup="correct('txt_user')" onblur="dhanya()" runat="server" MaxLength="6"></asp:TextBox>
                                                <label for="username" class="form-label">User Name<span style="color: #ff0000">*</span></label>
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <div class="form-floating mb-3 position-relative">
                                                <asp:TextBox ID="txt_oldpass" ClientIDMode="Static" CssClass="form-control pe-5" placeholder="Password"
                                                    runat="server" MaxLength="12" onkeypress="return validText()" TabIndex="2" TextMode="Password"></asp:TextBox>
                                                <label for="oldpassword" class="form-label">Old Password<span style="color: #ff0000">*</span></label>

                                                <!-- Eye icon inside textbox -->
                                                <span class="position-absolute end-0 top-50 translate-middle-y me-3" style="cursor: pointer;"
                                                    onclick="togglePassword('txt_oldpass', 'toggleIcon1')">
                                                    <img src="../Assets/Images/hidden.png" id="toggleIcon1" alt="Show Password" width="20px" />
                                                </span>
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <div class="form-floating mb-3 position-relative">
                                                <asp:TextBox ID="txt_newpass" ClientIDMode="Static" CssClass="form-control pe-5" placeholder="Password"
                                                    runat="server" MaxLength="12" onkeypress="return validText()" TabIndex="2" TextMode="Password"></asp:TextBox>
                                                <label for="newpassword" class="form-label">New Password<span style="color: #ff0000">*</span></label>

                                                <span class="position-absolute end-0 top-50 translate-middle-y me-3" style="cursor: pointer;"
                                                    onclick="togglePassword('txt_newpass', 'toggleIcon2')">
                                                    <img src="../Assets/Images/hidden.png" id="toggleIcon2" alt="Show Password" width="20px" />
                                                </span>
                                            </div>
                                        </div>

                                             <div class="col-12">
                                            <div class="form-floating mb-3 position-relative">
                                                <asp:TextBox ID="txt_confpass" ClientIDMode="Static" CssClass="form-control pe-5" placeholder="Password"
                                                    runat="server" MaxLength="12" onkeypress="return validText()" TabIndex="2" TextMode="Password"></asp:TextBox>
                                                <label for="confirmnewpassword" class="form-label">Confirm Password<span style="color: #ff0000">*</span></label>

                                                <span class="position-absolute end-0 top-50 translate-middle-y me-3" style="cursor: pointer;"
                                                    onclick="togglePassword('txt_confpass', 'toggleIcon3')">
                                                    <img src="../Assets/Images/hidden.png" id="toggleIcon3" alt="Show Password" width="20px" />
                                                </span>
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <div class="d-grid">
                                                <asp:Button CssClass="btn bsb-btn-sm btn-primary" ID="cmd_confirm" runat="server" TabIndex="4" Text="CONFIRM" />
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="form-floating mb-3" style="color:yellow;">
                                                <cc1:PasswordStrength ID="PasswordStrength1" runat="server" HelpHandlePosition="RightSide"
                                                    MinimumNumericCharacters="2" MinimumSymbolCharacters="0" PreferredPasswordLength="8"
                                                    TargetControlID="txt_newpass" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" CalculationWeightings="50;15;15;20"></cc1:PasswordStrength>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_newpass"
                                                    ErrorMessage="*One alphabet and One numeric character and One special character is Must*" SetFocusOnError="True" ValidationExpression="^.*(?=.{6,})(?=.*\d)(?=.*[a-z,A-Z]).*$"
                                                    Width="327px"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="d-grid">
                                <%-- <p class="text-center log-footer" style="font-size: 0.8rem; color: #fff">
                                    Manappuram e Business Suite ver 1.0
                                    <br />
                                    Designed & Developed by <a href="https://macomsolutions.com/" target="_blank"><strong>MACOM</strong></a>
                                </p>--%>
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

    </form>
</body>
</html>

