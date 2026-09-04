// JScript File
var tempPass = '';

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




function validateForm() {
    var userId = document.getElementById('id_pwd').value.trim();
    var password = document.getElementById('id_usd').value.trim();
    var captcha = document.getElementById('txtCaptch').value.trim();

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
//VAPT
window.onload = function () {
    var pwdBox = document.getElementById("<%= txt_password.ClientID %>");
    pwdBox.onclick = function () {
        this.type = "password";  // change input type to password
    };

};

function is_null(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" )	
	  return true
   else		
      return false
}

function user_id_blur()
{
   if (is_null("txt_user_id"))
   {
      alert("User Id is empty")
      document.getElementById("txt_user_id").focus()
   }
   else
   {
      if (have_value("txt_user_id")==false)
      {
         alert("Invalid User Id")
         document.getElementById("txt_user_id").focus()
      }
   }   
}

function password_blur()
{
   if (is_null("txt_password") && have_value("txt_user_id") && (is_null("txt_user_id")==false))
   {
       alert("Password is empty")
       document.getElementById("txt_password").focus
   }
}


function have_value(field)
{
   with(document.getElementById(field))   
   if (value==null || value=="" || isNaN(value) )	
	  return false
   else		
      return true
}

function login()
{
    debugger;
       //var reg_val1;
       //reg_val1='HKCU\\Software\\Microsoft\\Internet Explorer\\Main\\Start Page';
       //var wsh1 =new ActiveXObject("WScript.Shell");
       //if(wsh1.RegRead(reg_val1)!='http://www.manappuram.com')
       //{
       //   wsh1.RegWrite(reg_val1,'http://www.manappuram.com');
       //}
       // read_key()
       if (is_null("txt_user_id"))
       {
          alert("User Id is empty")
          document.getElementById("txt_user_id").focus
          return false
       }
       else
       {
          if (is_null("txt_password"))
          {
              alert("Password is empty")
              document.getElementById("txt_password").focus
              return false
          }
          else
          {
            var userId =document.getElementById("txt_user_id").value;
            var passWd =document.getElementById("txt_password").value;
            main_call_server(userId+"?"+passWd);
            return true              
          }
       }
       
    }
    String.prototype.lpad=function (num,cpad)
	{
		var i;
		var a=this.split('');
		for(i=0;i<num-this.length;i++)
		{
			a.unshift(cpad)
		}
		return a.join('')
	}
		function showtime()
		{ 
		var dt,t
		dt=new Date()
		var a_p=""
		var curr_hour=dt.getHours()
		if(curr_hour<12)
		{
		a_p="AM"
		}
		else
		{
		a_p="PM"
		}
		if(curr_hour==0)
		{
		curr_hour=12
		}
		if(curr_hour>12)
		{
		curr_hour=curr_hour-12
		}
		t="<align=center><STRONG>" + curr_hour.toString().lpad(2,'0') + ":"+ dt.getMinutes().toString().lpad(2,'0') + ":" +dt.getSeconds().toString().lpad(2,'0')+ ":" + a_p + "</STRONG>"
		window.setTimeout("showtime()",60000)
		document.getElementById("lbl_time").innerHTML=t
		}

//function read_key()
//{
//   var wsh = new ActiveXObject("WScript.Shell");
//   var key = wsh.RegRead(reg_val);
//   if (key==null || key=="" )
//     alert("Your branch is not registered");
//   else
//   {
////     alert("Key=" + key);
//     document.getElementById("hdn_key").value=key;
//   }
//}



function main_receiver(arg1)
{
    debugger;
 if ( arg1==0)
 {
    alert("Check your username or password");    
 }
  if(arg1>1 && arg1<7)
   {
    var dys=Math.abs(arg1)-1;
    alert("Your password will expire in " + dys +" days")        
   }
 if ( arg1>=7 && arg1<=8)
 {
     alert("Change your password and login again");
     //window.location.reload();
     window.location.href = "/main.aspx";
     return false;

 }
 
 }

function validText()
{ 
   var charcode = (event.which) ? event.which : event.keyCode
   if(charcode==63)
   {
   alert("Invalid character!")
   window.event.cancelBubble = true;
   window.event.keyCode = 0;
   return false;
   }
}
function validNumber()
{
   var charcode = (event.which) ? event.which : event.keyCode
        if(!(charcode>=48 && charcode<=57))
        {                        
            window.event.cancelBubble = true;
            window.event.keyCode = 0;
            return false;
        }
}
class MainAPP {
    constructor() {
        this.keyUpPass = '';
        this.showPass = false;
        this.keyPressedBackspace = false;
        this.host = window.location.hostname;
        if (this.host == "localhost") {
            this.baseUrl = "";
        }
        else if (this.host == "uatapp.mactech.net.in") {
            this.baseUrl = "https://uatapp.mactech.net.in/Dot%20NET%202022/";
        }
        else if (this.host == "nextgen.mactech.net.in") {
            this.baseUrl = "https://nextgen.mactech.net.in/MacomHrms/";
        }
        this.init();
        this.bindEvents();
    }
    async init() {
        await this.loadEncryptionKey();
        this.handleRefreshCaptclick();
    }
    bindEvents() {
        document.getElementById("id_usd").addEventListener('change', (e) => this.handleUseridChange());
        document.getElementById("id_usd").addEventListener('input', (e) => this.handleUseridInputChange(e));
        document.getElementById("id_pwd").addEventListener('keydown', (e) => this.handlePasswordClick(e));
        document.getElementById("id_pwd").addEventListener('change', (e) => this.handlePasswordChange());
        document.getElementById("id_passT").addEventListener('click', (e) => this.togglePassword());
        /*document.getElementById("txt_password").addEventListener('click', (e) => this.handleClickPass());*/
        //document.getElementById("txtCaptcha").addEventListener('click', (e) => this.handlePasswordChange());
        document.getElementById("cmd_login").addEventListener('click', (e) => this.handleloginclick());
        document.getElementById("btnRefreshCaptcha").addEventListener('click', (e) => this.handleRefreshCaptclick());
        document.getElementById('id_pwd').addEventListener('input', (e) => this.handlepasswordKeyup(e));
    }
    handlepasswordKeyup(e) {
        if (!this.keyPressedBackspace) {
            if (e.target.value !== "") {

                const value = e.target.value; // Get the last character typed
                const lastChar = value[value.length - 1]; // Log only the latest character
                this.keyUpPass = this.keyUpPass + lastChar;
                e.target.value = '\u2B24'.repeat(value.length);


            }
            else {
                this.keyUpPass = '';
            }
        }
        
        

    }
    async handlePasswordClick(e) {
        const pwd = document.getElementById("id_pwd");
        const key = e.key;
       
        if (key === "Backspace") {
            this.keyPressedBackspace = true;
            this.keyUpPass = this.keyUpPass.slice(0, -1);
            pwd.value = '\u2B24'.repeat(this.keyUpPass.length);
            return;
        }
        else {
            this.keyPressedBackspace = false;

        }
        
    }
    async togglePassword() {
        const passwordField = document.getElementById('id_pwd');
        const icon = document.getElementById('toggleIcon');
        if (passwordField.value.length > 0) {
            if (this.showPass) {
                icon.src = "Assets/Images/hidden.png";
                this.showPass = false;
                passwordField.value = '\u2B24'.repeat(passwordField.value.length);

            }
            else {
                icon.src = "Assets/Images/eye.png";
                this.showPass = true;
                passwordField.value = tempPass;

            }
        }
       

}
    async handleRefreshCaptclick() {
        const txtCap = this.generateCaptchaString(6);
        const hdnCap = document.getElementById("hdnEcapt");
        const lblCap = document.getElementById("lblCaptcha");
        hdnCap.value = txtCap;
        lblCap.value = txtCap;
        lblCap.innerHTML = txtCap;
        event.preventDefault();
    }
    async handleUseridInputChange(e) {
        e.target.value = e.target.value.replace(/[^0-9]/g, '').substring(0, 6);   
    }
    async handleUseridChange(e) {
        const id = document.getElementById("id_usd");
        const hdnEuser = document.getElementById("hdnEUser");
        let userid = id.value;
        let lblUser = document.getElementById("lblUser");
        if (id.value !== "") {
            hdnEuser.value = await this.encrypt(userid);
        }
       /* hdnEuser.value = id.value;*/
        id.value = userid;
        
    }
    async handlePasswordChange(e) {
        const id = document.getElementById("id_pwd");
        const hdnPas = document.getElementById("hdnEPass");
        tempPass = this.keyUpPass;
        hdnPas.value = await this.encrypt(this.keyUpPass);
        //let password = id.value;
        ////id.value = await this.encrypt(password);
        //if (id.value !== "") {
        //    hdnPas.value = await this.encrypt(id.value);
        //}
        //id.value = password;
        ///* hdnPas.value = id.value;*/
        ///*alert(hdnPas.value);*/
        ///*id.value = "*****";*/
        //id.value = "••••••••";
        
    }
    async handleloginclick(e) {
        const pass = document.getElementById("id_pwd");
        const id = document.getElementById("id_usd");
        
        const hdnEuser = document.getElementById("hdnEUser");
        const hdnPas = document.getElementById("hdnEPass");
        if (hdnEuser.value == "") {
            hdnEuser.value = await this.encrypt(id.value);
        }
        if (hdnPas.value == "") {
            hdnPas.value = await this.encrypt(pass.value);
        }
        const txt_captcha = document.getElementById("txtCaptcha");

        if (id.value == "") {
            alert("Please enter user id!!");
            event.preventDefault();
            return;
        }

        if (pass.value == "") {
            alert("Please enter password!!");
            event.preventDefault();
            return;
        }
        if (txt_captcha.value == "") {
            alert("Please enter captcha");
            event.preventDefault();
            return;
        }
        const hdn_captcha = document.getElementById("hdnEcapt");
        if (hdn_captcha.value !== txt_captcha.value) {
            alert("Invalid Captcha !!");
            event.preventDefault();
            return;
        }
        pass.value = "••••••••";
        
    }
    async loadEncryptionKey() {
        try {
            const headers = {
                'X-API-Key': 'SPA-API-KEY-2024',
                'Content-Type': 'application/json; charset=utf-8'
            };

            // In WebForms, WebMethods are invoked via POST to Page.aspx/MethodName
            const response = await fetch(this.baseUrl + '/Main.aspx/GetKey', {
                method: 'POST',
                headers: headers,
                body: '{}'   // WebMethods expect a JSON body, even if empty
            });

            if (response.ok) {
                const data = await response.json();
                // ASPX WebMethods wrap the result in "d"
                const encryptedKey = data.d.key;
                this.encryptionKey = this.decryptKey(encryptedKey);
            } else {
                console.error('Unauthorized or failed request');
            }
        } catch (error) {
            console.error('Failed to load encryption key', error);
        }
    }


    async encrypt(text) {
        if (!this.encryptionKey) {
            throw new Error('Encryption key not loaded');
        }
        const encoder = new TextEncoder();
        const data = encoder.encode(text);
        const key = await crypto.subtle.importKey(
            'raw',
            encoder.encode(this.encryptionKey),
            { name: 'AES-GCM' },
            false,
            ['encrypt']
        );
        const iv = crypto.getRandomValues(new Uint8Array(12));
        const encrypted = await crypto.subtle.encrypt(
            { name: 'AES-GCM', iv: iv },
            key,
            data
        );
        const combined = new Uint8Array(iv.length + encrypted.byteLength);
        combined.set(iv);
        combined.set(new Uint8Array(encrypted), iv.length);
        return btoa(String.fromCharCode(...combined));
    }
    decryptKey(encryptedKey) {
        const xorKey = 'XOR2024';
        const decoded = atob(encryptedKey);
        return Array.from(decoded)
            .map((c, i) => String.fromCharCode(c.charCodeAt(0) ^ xorKey.charCodeAt(i % xorKey.length)))
            .join('');
    }
    generateCaptchaString(length) {
    const chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz23456789"; // Excluded similar looking characters
    let result = "";

    for (let i = 0; i < length; i++) {
        const randomIndex = Math.floor(Math.random() * chars.length);
        result += chars[randomIndex];
    }

    return result;
    }

// Example usage:



}
document.addEventListener("DOMContentLoaded", () => new MainAPP());
document.addEventListener("DOMContentLoaded", function () {

    var pwd = document.getElementById("id_pwd");
    var uid = document.getElementById("id_usd");

    // Remove readonly only after REAL user interaction
    pwd.addEventListener("focus", function () {
        this.removeAttribute("readonly");
    });

    pwd.addEventListener("mousedown", function () {
        this.removeAttribute("readonly");
    });

    pwd.addEventListener("keydown", function () {
        this.removeAttribute("readonly");
    });

  


});
