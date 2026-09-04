<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SessionExpired.aspx.vb" Inherits="WebAppHRMS.SessionExpired" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Session Expired</title>
    <style>
        /* Page background */
        body {
            font-family: Arial, sans-serif;
            background-color: #d6eaf8; /* light blue */
            text-align: center;
            padding-top: 100px;
            margin: 0;
        }

        /* Container styling */
        #shiftApprovalFormContainer {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px 25px;
            background-color: #ffffff; /* white card on blue background */
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            box-sizing: border-box;
            text-align: center;
        }

        h1 {
            color: #d9534f;
            margin-bottom: 15px;
        }

        p {
            font-size: 16px;
            color: #2F4F6F;
            margin: 8px 0;
        }

        #countdown {
            font-weight: bold;
            color: #333;
        }

        .scrButton {
            padding: 8px 20px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            transition: background-color .3s ease;
            margin-top: 15px;
        }
        .scrButton:hover {
            background-color: #1c5fc0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="shiftApprovalFormContainer">
            <h1>Session Expired</h1>
            <p>Your session has timed out due to inactivity.</p>
            <p>You will be redirected to the login page in <span id="countdown">10</span> seconds.</p>
            <asp:Button ID="btnLogin" runat="server" CssClass="scrButton" Text="Login Again" PostBackUrl="~/Main.aspx" />
        </div>
    </form>

    <script type="text/javascript">
        var seconds = 10;
        var countdownElem = document.getElementById("countdown");
        var timer = setInterval(function () {
            seconds--;
            countdownElem.textContent = seconds;
            if (seconds <= 0) {
                clearInterval(timer);
                window.location.href = 'Main.aspx';
            }
        }, 1000);
    </script>
</body>
</html>--%>

<%--<!DOCTYPE html>
<html>
<head>
    <title>Session Expired</title>
    <style>
        body {
            margin: 0;
            font-family: 'Arial', sans-serif;
            background: #f0f4f8;
        }
        .overlay {
            position: fixed;
            top: 0; left: 0;
            width: 100%; height: 100%;
            background: rgba(0,0,0,0.6);
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .modal {
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            text-align: center;
            width: 450px;
            animation: fadeIn 0.5s ease;
        }
        @keyframes fadeIn {
            from {opacity: 0; transform: scale(0.9);}
            to {opacity: 1; transform: scale(1);}
        }
        h1 {
            color: #c0392b;
        }
        p {
            color: #444;
        }
        #countdown {
            font-weight: bold;
            color: #000;
        }
        .btn {
            margin-top: 20px;
            padding: 12px 30px;
            border: none;
            border-radius: 6px;
            background: #2980b9;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }
        .btn:hover {
            background: #1c5fc0;
        }
    </style>
</head>
<body>
    <div class="overlay">
        <div class="modal">
            <h1>Session Expired</h1>
            <p>Your session has timed out due to inactivity.</p>
            <p>Redirecting in <span id="countdown">10</span> seconds...</p>
            <button class="btn" onclick="window.location.href='Main.aspx'">Login Again</button>
        </div>
    </div>

    <script>
        let seconds = 10;
        const countdownElem = document.getElementById("countdown");
        const timer = setInterval(() => {
            seconds--;
            countdownElem.textContent = seconds;
            if (seconds <= 0) {
                clearInterval(timer);
                window.location.href = 'Main.aspx';
            }
        }, 1000);
    </script>
</body>
</html>--%>


<!DOCTYPE html>
<html>
<head>
    <title>Session Expired</title>
    <style>
        body {
            margin: 0;
            font-family: 'Arial', sans-serif;
            background: #1ca2c0; /* bright orange background */
        }
        .overlay {
            position: fixed;
            top: 0; left: 0;
            width: 100%; height: 100%;
            background: rgba(0,0,0,0.6);
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .modal {
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            text-align: center;
            width: 450px;
            animation: fadeIn 0.5s ease;
        }
        @keyframes fadeIn {
            from {opacity: 0; transform: scale(0.9);}
            to {opacity: 1; transform: scale(1);}
        }
        h1 {
            color: #c0392b;
        }
        p {
            color: #444;
        }
        #countdown {
            font-weight: bold;
            color: #000;
        }
        .btn {
            margin-top: 20px;
            padding: 12px 30px;
            border: none;
            border-radius: 6px;
            background: #2980b9;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }
        .btn:hover {
            background: #1c5fc0;
        }
    </style>
</head>
<body>
    <div class="overlay">
        <div class="modal">
            <h1>Session Expired</h1>
            <p>Your session has timed out due to inactivity.</p>
            <p>Redirecting in <span id="countdown">10</span> seconds...</p>
            <button class="btn" onclick="window.location.href='Main.aspx'">Please Login Again</button>
        </div>
    </div>

    <script>
        let seconds = 10;
        const countdownElem = document.getElementById("countdown");
        const timer = setInterval(() => {
            seconds--;
            countdownElem.textContent = seconds;
            if (seconds <= 0) {
                clearInterval(timer);
                window.location.href = 'Main.aspx';
            }
        }, 1000);
    </script>
</body>
</html>

